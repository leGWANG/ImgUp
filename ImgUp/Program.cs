using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgUp
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process[] process = Process.GetProcessesByName("ImgUp");
            
            if (process.Length > 1)
            {
                MessageBox.Show("Application already running!", "ImgUp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ImgUp());
            }
        }
    }
}
