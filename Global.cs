using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace LibraryRestorer
{
    public class Global
    {
        public static Image icon;
        public static Image Logo;

        #region -> METODOS
        /// <summary>
        /// Devuelve la versión del compilado
        /// </summary>
        /// <returns></returns>
        public static Version DevuelveVersion()
        {
            Assembly assem = Assembly.GetEntryAssembly();
            AssemblyName assemblyName = assem.GetName();
            Version versionCliente = assemblyName.Version;

            return versionCliente;
        }

        /// <summary>
        /// Abre una ventana emergente
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="popUpForm"></param>
        /// <returns></returns>
        public static bool OpenPopUpForm(Form owner, Form popUpForm)
        {
            //Abrir Ventana Emergente
            Form formBG = new Form();
            using (popUpForm)
            {
                formBG.StartPosition = FormStartPosition.Manual;
                formBG.FormBorderStyle = FormBorderStyle.None;
                formBG.Opacity = .70d;
                formBG.BackColor = Color.Black;
                formBG.WindowState = FormWindowState.Maximized;
                //formBG.TopMost = true;
                formBG.Location = owner.Location;
                formBG.ShowInTaskbar = false;
                formBG.Owner = owner;
                formBG.Show();

                popUpForm.Owner = formBG;
                popUpForm.ShowDialog();

                formBG.Dispose();
            }

            return true;
        }

        /// <summary>
        /// Abre una ventana emergente oscureciendo todo lo que está detrás
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="popUpForm"></param>
        /// <returns></returns>
        public static DialogResult DialogResultPopUpForm(Form owner, Form popUpForm)
        {
            //Abrir Ventana Emergente tipo DialogResult
            Form formBG = new Form();
            DialogResult result;

            using (popUpForm)
            {
                formBG.StartPosition = FormStartPosition.Manual;
                formBG.FormBorderStyle = FormBorderStyle.None;
                formBG.Opacity = .70d;
                formBG.BackColor = Color.Black;
                formBG.WindowState = FormWindowState.Maximized;
                //formBG.TopMost = true;
                formBG.Location = owner.Location;
                formBG.ShowInTaskbar = false;
                formBG.Owner = owner;
                formBG.Show();

                popUpForm.Owner = formBG;
                popUpForm.ShowDialog();
                result = popUpForm.DialogResult;

                formBG.Dispose();
            }

            return result;
        }

        /// <summary>
        /// Abre el OpenFileDialog para cargar el archivo
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Fecha: 11.09.2023,  Autor: Camilo Leal
        /// </remarks>
        public string OpenFile(string title, string filter)
        {
            string ruta = string.Empty;

            using (OpenFileDialog fdlg = new OpenFileDialog())
            {
                fdlg.Title = title;
                fdlg.FileName = ruta != null ? ruta : "";
                fdlg.Filter = filter;
                fdlg.FilterIndex = 1;
                fdlg.RestoreDirectory = true;

                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    ruta = fdlg.FileName;
                }
            }

            return ruta;
        }

        /// <summary>
        /// Establece el color de la fuente dependiendo del color del fondo
        /// </summary>
        /// <param name="fondo"></param>
        /// <returns>
        /// 31, 31, 31: Si el fondo es claro
        /// 245, 245, 245: Si el fondo es Oscuro
        /// </returns>
        /// <remarks>
        /// Fecha: 16.04.2024,  Autor: Camilo Leal
        /// </remarks>
        public static Color ForeColor(Color fondo)
        {
            Color foreColor;

            try
            {
                double darknessRatioTitleBar = 0.2126 * fondo.R + 0.7152 * fondo.G + 0.0722 * fondo.B;

                foreColor = darknessRatioTitleBar > 100 ? Color.FromArgb(31, 31, 31) : Color.FromArgb(245, 245, 245);

                return foreColor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Color MouseHoverColor(Color fondo)
        {
            float correctionFactor = 0.3f;

            float red = (255 - fondo.R) * correctionFactor + fondo.R;
            float green = (255 - fondo.G) * correctionFactor + fondo.G;
            float blue = (255 - fondo.B) * correctionFactor + fondo.B;

            Color lighterColor = Color.FromArgb(fondo.A, (int)red, (int)green, (int)blue);

            return lighterColor;
        }
        #endregion -> METODOS
    }
}
