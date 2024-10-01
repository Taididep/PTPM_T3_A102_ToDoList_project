using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDL.Client
{
    internal static class Program
    {
        public static frm_main mainForm = null;
        public static frm_login loginForm = null; 
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginForm = new frm_login();
            Application.Run(loginForm);
        }
    }
}
