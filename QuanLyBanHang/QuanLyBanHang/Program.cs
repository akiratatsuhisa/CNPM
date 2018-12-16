using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.GUI;

namespace QuanLyBanHang
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
            LoginFormGUI loginForm = new LoginFormGUI(); 
            Application.Run(loginForm);
            if (loginForm.Result)
            {
                Application.Run(new MainFormGUI());
            }
        }
    }
}
