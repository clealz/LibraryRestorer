using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LibraryRestorer
{
    internal static class Program
    {
        public static string nombrePrograma = "Library Restorer";

        #region Para saber si una aplicación está en memoria
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        #endregion

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Version ver = Global.DevuelveVersion();

                Application.Run(new frmMain());

                //IntPtr nWnd = FindWindow(null, nombrePrograma);
                //IntPtr nWndv = FindWindow(null, $"{nombrePrograma} (Ver. {ver.ToString()})");

                //Application.EnableVisualStyles();
                //Application.DoEvents();
                //if (nWnd.Equals(new System.IntPtr(0)) && nWndv.Equals(new System.IntPtr(0)))
                //{
                //    Application.Run(new frmMain());
                //}
                //else
                //{
                //    MessageBox.Show($"¡La aplicación «{nombrePrograma}» ya se encuentra en ejecución!", nombrePrograma,
                //        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                //    SetForegroundWindow(nWnd);
                //    Application.Exit();
                //}

                //Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new mdiMain());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, nombrePrograma, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
