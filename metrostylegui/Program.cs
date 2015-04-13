using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace metrostylegui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        public static void HideCaret(this MetroFramework.Controls.MetroTextBox textBox)
        {
            HideCaret(textBox.Handle);
        }
    }
}
