using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace LibraryRestorer
{
    public partial class frmMain : Form
    {
        #region -> CAMPOS
        //Campos
        private int borderRadius = 5;
        private int borderSize = 1;
        private Color borderColor;

        private string nombre = $"{Program.nombrePrograma}";
        private string version = $"{Global.DevuelveVersion()}";
        #endregion -> CAMPOS

        #region -> CONSTRUCTOR
        public frmMain()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);

            this.Text = $"{nombre} (Ver.{version})";
            lblTitle.Text = $"{nombre} (Ver.{version})";

            SetColors();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            CargarTabla();
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

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void tableMain_Paint(object sender, PaintEventArgs e)
        {
            ControlRegionAndBorder(tableMain, borderRadius - (borderSize / 2), e.Graphics, borderColor);
        }

        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        #endregion OVERRIDE

        #region -> METODOS
        private void SetColors()
        {
            Global.icon = new Icon(this.Icon, 18, 18).ToBitmap();
            Global.Logo = new Icon(this.Icon, 256, 256).ToBitmap();
            iconTitleBar.Image = Global.icon;

            borderColor = SystemColors.Control;
            this.BackColor = borderColor;
            tableMain.BackColor = borderColor;

            iconTitleBar.BackColor = SystemColors.ActiveCaption;
            lblTitle.BackColor = SystemColors.ActiveCaption;
            btnHelp.BackColor = SystemColors.ActiveCaption;
            btnMinimize.BackColor = SystemColors.ActiveCaption;
            btnClose.BackColor = SystemColors.ActiveCaption;
        }
        /// <summary>
        /// Carga la lista de los permisos completa
        /// </summary>
        private void CargarTabla()
        {
            cRegistry oReg = new cRegistry();

            DataTable dt = new DataTable();
            dt.Columns.Add("libName");
            dt.Columns.Add("Description");
            dt.Columns.Add("Pinned");

            oReg.DetectFoldersEnabled();

            DataRow _Objects3D = dt.NewRow();
            _Objects3D["libName"] = "ObjectsTD";
            _Objects3D["Description"] = "Objetos 3D";
            _Objects3D["Pinned"] = oReg.ThreeDObjects;
            dt.Rows.Add(_Objects3D);

            DataRow _Desktop = dt.NewRow();
            _Desktop["libName"] = "Desktop";
            _Desktop["Description"] = "Escritorio";
            _Desktop["Pinned"] = oReg.Desktop;
            dt.Rows.Add(_Desktop);

            DataRow _Documents = dt.NewRow();
            _Documents["libName"] = "Documents";
            _Documents["Description"] = "Documentos";
            _Documents["Pinned"] = oReg.Documents;
            dt.Rows.Add(_Documents);

            DataRow _Downloads = dt.NewRow();
            _Downloads["libName"] = "Downloads";
            _Downloads["Description"] = "Descargas";
            _Downloads["Pinned"] = oReg.Downloads;
            dt.Rows.Add(_Downloads);

            DataRow _Pictures = dt.NewRow();
            _Pictures["libName"] = "Pictures";
            _Pictures["Description"] = "Imágenes";
            _Pictures["Pinned"] = oReg.Pictures;
            dt.Rows.Add(_Pictures);

            DataRow _Music = dt.NewRow();
            _Music["libName"] = "Music";
            _Music["Description"] = "Música";
            _Music["Pinned"] = oReg.Music;
            dt.Rows.Add(_Music);

            DataRow _Videos = dt.NewRow();
            _Videos["libName"] = "Videos";
            _Videos["Description"] = "Vídeos";
            _Videos["Pinned"] = oReg.Videos;
            dt.Rows.Add(_Videos);

            dgvItems.DataSource = dt;

            foreach(DataGridViewRow fila in dgvItems.Rows)
            {
                switch(fila.Cells[txtcLibraryName.Name].Value.ToString().Trim())
                {
                    case "ObjectsTD":
                        dgvItems[imgcIcon.Index, fila.Index].Value = ListFolders.Images[ListFolders.Images.IndexOfKey("3DObjects")];
                        break;
                    case "Desktop":
                        dgvItems[imgcIcon.Index, fila.Index].Value = ListFolders.Images[ListFolders.Images.IndexOfKey("Desktop")];
                        break;
                    case "Documents":
                        dgvItems[imgcIcon.Index, fila.Index].Value = ListFolders.Images[ListFolders.Images.IndexOfKey("Documents")];
                        break;
                    case "Downloads":
                        dgvItems[imgcIcon.Index, fila.Index].Value = ListFolders.Images[ListFolders.Images.IndexOfKey("Downloads")];
                        break;
                    case "Pictures":
                        dgvItems[imgcIcon.Index, fila.Index].Value = ListFolders.Images[ListFolders.Images.IndexOfKey("Pictures")];
                        break;
                    case "Music":
                        dgvItems[imgcIcon.Index, fila.Index].Value = ListFolders.Images[ListFolders.Images.IndexOfKey("Music")];
                        break;
                    case "Videos":
                        dgvItems[imgcIcon.Index, fila.Index].Value = ListFolders.Images[ListFolders.Images.IndexOfKey("Videos")];
                        break;
                }
            }

            SetMarkAllStatus();
        }

        /// <summary>
        /// Cambia el estatus del botón marcar/desmarcar todos
        /// </summary>
        private void SetMarkAllStatus()
        {
            if(dgvItems.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Cells[chkcCheck.Name].Value.ToString().Equals(Convert.ToString(false))).Any())
            {
                btnTodosNinguno.Image = ListCheck.Images[ListCheck.Images.IndexOfKey("check")];
                btnTodosNinguno.Text = " Marcar Todos";
            }
            else
            {
                btnTodosNinguno.Image = ListCheck.Images[ListCheck.Images.IndexOfKey("uncheck")];
                btnTodosNinguno.Text = " Desmarcar Todos";
            }
        }
        #endregion -> METODOS

        #region -> EVENTOS
        /// <summary>
        /// Marca/Desmarca todos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTodosNinguno_Click(object sender, EventArgs e)
        {
            cRegistry oReg = new cRegistry();

            if (dgvItems.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Cells[chkcCheck.Name].Value.ToString().Equals(Convert.ToString(false))).Any())
            {
                for (int i = 0; i < dgvItems.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvItems.Rows[i].Cells[chkcCheck.Name].Value) == false)
                    {
                        dgvItems.Rows[i].Cells[chkcCheck.Name].Value = true;
                    }
                    oReg.SetFolderValue(dgvItems.Rows[i].Cells[txtcLibraryName.Name].Value.ToString(), Convert.ToBoolean(dgvItems.Rows[i].Cells[chkcCheck.Name].Value));
                }
            }
            else if (dgvItems.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Cells[chkcCheck.Name].Value.ToString().Equals(Convert.ToString(true))).Any())
            {
                for (int i = 0; i < dgvItems.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvItems.Rows[i].Cells[chkcCheck.Name].Value) == true)
                    {
                        dgvItems.Rows[i].Cells[chkcCheck.Name].Value = false;
                    }
                    oReg.SetFolderValue(dgvItems.Rows[i].Cells[txtcLibraryName.Name].Value.ToString(), Convert.ToBoolean(dgvItems.Rows[i].Cells[chkcCheck.Name].Value));
                }
            }

            CargarTabla();
        }

        /// <summary>
        /// Guarda el valor al modificar la celda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dgvItems.Columns[chkcCheck.Name].Index)
            {
                if (dgvItems.Rows[e.RowIndex].Cells[chkcCheck.Name].Value == DBNull.Value)
                    dgvItems.Rows[e.RowIndex].Cells[chkcCheck.Name].Value = false;

                cRegistry oReg = new cRegistry();
                oReg.SetFolderValue(dgvItems.Rows[e.RowIndex].Cells[txtcLibraryName.Name].Value.ToString(), Convert.ToBoolean(dgvItems.Rows[e.RowIndex].Cells[chkcCheck.Name].Value));
            }

            CargarTabla();
        }

        private void dgvItems_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.ColumnIndex == dgvItems.Columns[chkcCheck.Name].Index)
            {
                dgvItems.EndEdit();
            }
        }

        private void dgvItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvItems.CurrentCell is DataGridViewCheckBoxCell)
                dgvItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        /// <summary>
        /// Pinta los bordes de las filas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvItems_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                e.Handled = true;

                using (Brush b = new SolidBrush(dgvItems.DefaultCellStyle.BackColor))
                {
                    e.Graphics.FillRectangle(b, e.CellBounds);
                }
                using (Pen p = new Pen(Color.Gainsboro))
                {
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    e.Graphics.DrawLine(p, new Point(0, e.CellBounds.Bottom - 1), new Point(e.CellBounds.Right, e.CellBounds.Bottom - 1));
                }
                e.PaintContent(e.ClipBounds);
            }
        }

        /// <summary>
        /// Evento generico clic para los botones de la barra de titulo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch(btn.Name.Trim().Replace("btn", string.Empty).ToUpper())
            {
                case "HELP":
                    {
                        frmHelp help = new frmHelp();
                        help.ShowDialog(this);
                    }
                    break;
                case "MINIMIZE":
                    this.WindowState = FormWindowState.Minimized;
                    break;
                case "CLOSE":
                    Application.Exit();
                    break;
            }
        }

        /// <summary>
        /// Permite mover la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void titlebar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.Image = ListTitleBar.Images[ListTitleBar.Images.IndexOfKey("close_W")];
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            if(ListTitleBar.Images.Count > 0)
            {
                btnClose.Image = ListTitleBar.Images[ListTitleBar.Images.IndexOfKey("close_B")];
            }
        }

        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            btnClose.Image = ListTitleBar.Images[ListTitleBar.Images.IndexOfKey("close_B")];
        }
        #endregion -> EVENTOS
    }
}
