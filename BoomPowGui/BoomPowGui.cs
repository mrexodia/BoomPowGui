using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace BoomPowGui
{
    public partial class BoomPowGui : Form
    {
        private List<Process> _processes = new List<Process>();
        private Dictionary<string, StreamWriter> _logStreams = new Dictionary<string, StreamWriter>();

#if DEBUG
        private string _bpowClientDir = @"d:\Downloads\bpow-client";
        private string _pythonDir = @"d:\Downloads\bpow-client\python-3.8.3-embed-amd64";
#else
        private string _bpowClientDir = AppDomain.CurrentDomain.BaseDirectory;
        private string _pythonDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "python-3.8.3-embed-amd64");
#endif
        private string _pidsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BoomPowGui.pids");
        private bool _formHidden = false;

        public BoomPowGui(bool autostart)
        {
            InitializeComponent();

            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            notifyIcon.Text = Text;
            notifyIcon.Icon = Icon;

            tabControlProcesses.SelectedIndexChanged += TabControlProcesses_SelectedIndexChanged;
            Resize += BoomPowGui_Resize;
            FormClosing += BoomPowGui_FormClosing;
            Shown += BoomPowGui_Shown;
            notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;

            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            checkBoxAutostart.Checked = key.GetValue("BoomPowGui") != null;

            Directory.CreateDirectory(Path.Combine(_bpowClientDir, "logs"));

            if (autostart)
            {
                WindowState = FormWindowState.Minimized;
                buttonStart_Click(buttonStart, new EventArgs());
            }
            else
            {
                _formHidden = true;
            }
        }

        private void BoomPowGui_Shown(object sender, EventArgs e)
        {
            if (!_formHidden)
            {
                _formHidden = true;
                Hide();
            }
        }

        void BoomPowGui_FormClosing(object sender, FormClosingEventArgs e)
        {
            var settings = Properties.Settings.Default;
            settings["BananoAddress"] = textBoxBanAddress.Text;
            settings["ServiceArguments"] = textBoxServiceArguments.Text;
            settings.Save();
            stopProcesses();
        }

        private void BoomPowGui_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void TabControlProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControlProcesses.SelectedTab.Text = tabControlProcesses.SelectedTab.Text.TrimEnd('*');
        }

        private void tabUpdated(TabPage tab)
        {
            if (tabControlProcesses.SelectedTab != tab)
            {
                if (!tab.Text.EndsWith("*"))
                    tab.Text += "*";
            }
        }

        public delegate void AppendLine(string line);

        private Process doProcess(string filename, string arguments, string workingDir, AppendLine output)
        {
            var process = Process.Start(new ProcessStartInfo
            {
                FileName = filename,
                Arguments = arguments,
                WorkingDirectory = workingDir,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
            });
            process.OutputDataReceived += (sender, args) => output(string.IsNullOrEmpty(args.Data) ? "" : args.Data);
            process.ErrorDataReceived += (sender, args) => output(string.IsNullOrEmpty(args.Data) ? "" : args.Data);
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            _processes.Add(process);
            var pids = new List<string>();
            if (File.Exists(_pidsFile))
                pids = File.ReadAllLines(_pidsFile).ToList();
            pids.Add(process.Id.ToString());
            File.WriteAllLines(_pidsFile, pids.ToArray());
            return process;
        }

        private Process python(string script, string arguments, AppendLine output)
        {
            var workingDir = Path.GetDirectoryName(script);
            Environment.SetEnvironmentVariable("PYTHONHOME", _pythonDir);
            var filename = Path.Combine(_pythonDir, "python.exe");
            return doProcess(filename, $"\"{script}\" {arguments.Trim()}", workingDir, output);
        }

        private Process exec(string exe, string arguments, AppendLine output)
        {
            var workingDir = Path.GetDirectoryName(exe);
            return doProcess(exe, arguments, workingDir, output);
        }

        private void stopProcesses()
        {
            foreach (var process in _processes)
            {
                try
                {
                    process.Kill();
                    process.CancelOutputRead();
                    process.CancelErrorRead();
                    process.WaitForExit();
                }
                catch
                {
                }
            }
            _processes.Clear();

            if (File.Exists(_pidsFile))
                File.Delete(_pidsFile);

            foreach (var logStream in _logStreams)
                logStream.Value.Close();
            _logStreams.Clear();
        }

        StreamWriter findOrCreateStream(TabPage tab)
        {
            var logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, tab.Text.TrimEnd('*') + ".log");
            if (!_logStreams.ContainsKey(logFile))
            {
                var logStream = new StreamWriter(logFile, true);
                logStream.AutoFlush = true;
                _logStreams.Add(logFile, logStream);
            }
            return _logStreams[logFile];
        }

        AppendLine makeControlOutput(TabPage tab, TextBox textBox)
        {
            var logStream = findOrCreateStream(tab);
            return line => textBox.InvokeIfRequired(tb =>
            {
                var newline = line.Replace("\r", "").Replace("\n", "\r\n") + "\r\n";
                logStream.Write(newline);
                tb.AppendText(newline);
                tabUpdated(tab);
            });
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            if (_processes.Count == 0)
            {
                buttonStart.Enabled = false;
                if (File.Exists(_pidsFile))
                {
                    var pids = File.ReadAllLines(_pidsFile);
                    var processNames = new HashSet<string>(new[] { "python", "nano-work-server" });
                    foreach (var pidStr in pids)
                    {
                        int pid;
                        if (int.TryParse(pidStr, out pid))
                        {
                            try
                            {
                                var process = Process.GetProcessById(pid);
                                if (processNames.Contains(process.ProcessName))
                                {
                                    textBoxBpowClient.AppendText($"Killing {process.ProcessName} ({pid})\r\n");
                                    textBoxPowService.AppendText($"Killing {process.ProcessName} ({pid})\r\n");
                                    process.Kill();
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    File.Delete(_pidsFile);
                }

                // TODO: expose more via the ui
                var payoutAddress = textBoxBanAddress.Text;
                var desiredWorkType = "any";
                var asyncMode = true;
                var limitLogging = true;

                var clientArguments = "";
                clientArguments += "--payout " + payoutAddress;
                clientArguments += " --work " + desiredWorkType;
                if (asyncMode)
                    clientArguments += " --async_mode";
                if (limitLogging)
                    clientArguments += " --limit-logging";

                buttonStart.Text = "Stop";

                exec(Path.Combine(_bpowClientDir, @"bin\windows\nano-work-server.exe"), textBoxServiceArguments.Text + " -l 127.0.0.1:7000", makeControlOutput(tabPagePowService, textBoxPowService));
                await Task.Delay(200);
                python(Path.Combine(_bpowClientDir, "bpow_client.py"), clientArguments, makeControlOutput(tabPageBpowClient, textBoxBpowClient));
                await Task.Delay(200);
                buttonStart.Enabled = true;
            }
            else
            {
                stopProcesses();

                buttonStart.Text = "Start";
            }
        }

        private void checkBoxAutostart_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (checkBoxAutostart.Checked)
            {
                key.SetValue("BoomPowGui", $"\"{Application.ExecutablePath}\" --autostart");
            }
            else
            {
                key.DeleteValue("BoomPowGui", false);
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotifyIcon_MouseDoubleClick(notifyIcon, null);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabelGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/mrexodia/BoomPowGui");
        }
    }
}
