using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoomPowGui
{
    public static class Extensions
    {
        public static void InvokeIfRequired<T>(this T c, Action<T> action) where T : Control
        {
            try
            {
                if (c.InvokeRequired)
                {
                    c.Invoke(new Action(() => action(c)));
                }
                else
                {
                    action(c);
                }
            }
            catch (ObjectDisposedException)
            {
                // This can apparently happen during shutdown, just silently ignore this error
            }
        }
    }
}
