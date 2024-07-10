using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LibraryRestorer
{
    public partial class frmHelp : Form
    {
        #region -> CAMPOS
        //Campos
        private int borderRadius = 5;
        private int borderSize = 1;
        private Color borderColor;
        #endregion -> CAMPOS

        #region -> CONSTRUCTOR
        public frmHelp()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            SetValues();
        }
        #endregion -> CONSTRUCTOR

        #region OVERRIDE
        //Drag Form
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- Minimize borderless form from taskbar
                return cp;
            }
        }
        private GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void FormRegionAndBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(form.ClientRectangle, radius))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                using (Matrix transform = new Matrix())
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    form.Region = new Region(roundPath);
                    if (borderSize >= 1)
                    {
                        Rectangle rect = form.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);
                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);
                        graph.Transform = transform;
                        graph.DrawPath(penBorder, roundPath);
                    }
                }
            }
        }

        private void ControlRegionAndBorder(Control control, float radius, Graphics graph, Color borderColor)
        {
            using (GraphicsPath roundPath = GetRoundedPath(control.ClientRectangle, radius))
            using (Pen penBorder = new Pen(borderColor, 1))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                control.Region = new Region(roundPath);
                graph.DrawPath(penBorder, roundPath);
            }
        }

        private void DrawPath(Rectangle rect, Graphics graph, Color color)
        {
            using (GraphicsPath roundPath = GetRoundedPath(rect, borderRadius))
            using (Pen penBorder = new Pen(color, 3))
            {
                graph.DrawPath(penBorder, roundPath);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            //Smooth outer border
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidth = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();

            //Top Left
            DrawPath(rectForm, e.Graphics, fbColors.TopLeftColor);

            //Top Right
            Rectangle rectTopRight = new Rectangle(mWidth, rectForm.Y, mWidth, mHeight);
            DrawPath(rectTopRight, e.Graphics, fbColors.TopRightColor);

            //Bottom Left
            Rectangle rectBottomLeft = new Rectangle(rectForm.X, rectForm.X + mHeight, mWidth, mHeight);
            DrawPath(rectBottomLeft, e.Graphics, fbColors.BottomLeftColor);

            //Bottom Right
            Rectangle rectBottomRight = new Rectangle(mWidth, rectForm.Y + mHeight, mWidth, mHeight);
            DrawPath(rectBottomRight, e.Graphics, fbColors.BottomRightColor);
        }

        private struct FormBoundsColors
        {
            public Color TopLeftColor;
            public Color TopRightColor;
            public Color BottomLeftColor;
            public Color BottomRightColor;
        }
        private FormBoundsColors GetFormBoundsColors()
        {
            var fbColor = new FormBoundsColors();
            using (var bmp = new Bitmap(1, 1))
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle rectBmp = new Rectangle(0, 0, 1, 1);
                //Top Left
                rectBmp.X = this.Bounds.X - 1;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopLeftColor = bmp.GetPixel(0, 0);
                //Top Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopRightColor = bmp.GetPixel(0, 0);
                //Bottom Left
                rectBmp.X = this.Bounds.X;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomLeftColor = bmp.GetPixel(0, 0);
                //Bottom Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomRightColor = bmp.GetPixel(0, 0);
            }
            return fbColor;
        }

        private void frmHelp_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void tableMain_Paint(object sender, PaintEventArgs e)
        {
            ControlRegionAndBorder(tableMain, borderRadius - (borderSize / 2), e.Graphics, borderColor);
        }

        private void frmHelp_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmHelp_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmHelp_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        #endregion OVERRIDE

        #region -> METODOS
        private void SetValues()
        {
            iconTitleBar.BackColor = SystemColors.ActiveCaption;
            lblTitle.BackColor = SystemColors.ActiveCaption;
            btnClose.BackColor = SystemColors.ActiveCaption;

            iconTitleBar.Image = Global.ForeColor(iconTitleBar.BackColor) == Color.FromArgb(31, 31, 31)
                ? imageList1.Images[imageList1.Images.IndexOfKey("help_B")]
                : imageList1.Images[imageList1.Images.IndexOfKey("help_W")];

            lblTitle.Text = $"{this.Text}";

            picLogo.Image = Global.Logo;

            foreach(Label lbl in tableMain.Controls.OfType<Label>())
            {
                lbl.ForeColor = Color.DimGray;
            }

            lblProgramName.ForeColor = Color.SteelBlue;
            lblProgramName.Text = $"{Program.nombrePrograma}";
            lblVersion.Text = $"Versión: {Global.DevuelveVersion()}";
            lblLicense.Text = "Licencia: Software Gratuito";
            lblAutor.Text = $"Autor: Clipzer Soft.";
            linkWebSite.Text = "https://clipzer.mx/";

            lblTitle.ForeColor = Global.ForeColor(lblTitle.BackColor);
            lblHowTitle.ForeColor = Color.SteelBlue;
            lblRequeriments.ForeColor = Color.SteelBlue;
        }
        #endregion -> METODOS

        #region -> EVENTOS
        /// <summary>
        /// Cierra el cuadro de dialogo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.Image = imageList1.Images[imageList1.Images.IndexOfKey("close_W")];
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = imageList1.Images[imageList1.Images.IndexOfKey("close_B")];
        }

        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            btnClose.Image = imageList1.Images[imageList1.Images.IndexOfKey("close_B")];
            btnClose.BackColor = Global.MouseHoverColor(btnClose.BackColor);
        }

        private void btnClose_MouseUp(object sender, MouseEventArgs e)
        {
            btnClose.BackColor = SystemColors.ActiveCaption;
        }
        #endregion -> EVENTOS
    }
}
