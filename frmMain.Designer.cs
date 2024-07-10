namespace LibraryRestorer
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnTodosNinguno = new System.Windows.Forms.Button();
            this.ListCheck = new System.Windows.Forms.ImageList(this.components);
            this.lblLeyenda = new System.Windows.Forms.Label();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.txtcLibraryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgcIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtcDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkcCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iconTitleBar = new System.Windows.Forms.PictureBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ListFolders = new System.Windows.Forms.ImageList(this.components);
            this.ListTitleBar = new System.Windows.Forms.ImageList(this.components);
            this.tableMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconTitleBar)).BeginInit();
            this.SuspendLayout();
            // 
            // tableMain
            // 
            this.tableMain.ColumnCount = 6;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.Controls.Add(this.btnTodosNinguno, 2, 2);
            this.tableMain.Controls.Add(this.lblLeyenda, 1, 2);
            this.tableMain.Controls.Add(this.pnlSeparador, 1, 4);
            this.tableMain.Controls.Add(this.dgvItems, 1, 5);
            this.tableMain.Controls.Add(this.iconTitleBar, 0, 0);
            this.tableMain.Controls.Add(this.btnHelp, 3, 0);
            this.tableMain.Controls.Add(this.btnMinimize, 4, 0);
            this.tableMain.Controls.Add(this.btnClose, 5, 0);
            this.tableMain.Controls.Add(this.lblTitle, 1, 0);
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMain.Location = new System.Drawing.Point(0, 0);
            this.tableMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableMain.Name = "tableMain";
            this.tableMain.RowCount = 7;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableMain.Size = new System.Drawing.Size(504, 661);
            this.tableMain.TabIndex = 0;
            this.tableMain.Paint += new System.Windows.Forms.PaintEventHandler(this.tableMain_Paint);
            // 
            // btnTodosNinguno
            // 
            this.btnTodosNinguno.AutoSize = true;
            this.btnTodosNinguno.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableMain.SetColumnSpan(this.btnTodosNinguno, 3);
            this.btnTodosNinguno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTodosNinguno.FlatAppearance.BorderSize = 0;
            this.btnTodosNinguno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTodosNinguno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTodosNinguno.ImageKey = "check";
            this.btnTodosNinguno.ImageList = this.ListCheck;
            this.btnTodosNinguno.Location = new System.Drawing.Point(354, 63);
            this.btnTodosNinguno.Name = "btnTodosNinguno";
            this.btnTodosNinguno.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnTodosNinguno.Size = new System.Drawing.Size(107, 26);
            this.btnTodosNinguno.TabIndex = 0;
            this.btnTodosNinguno.Text = " Marcar Todos";
            this.btnTodosNinguno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTodosNinguno.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTodosNinguno.UseVisualStyleBackColor = true;
            this.btnTodosNinguno.Click += new System.EventHandler(this.btnTodosNinguno_Click);
            // 
            // ListCheck
            // 
            this.ListCheck.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ListCheck.ImageStream")));
            this.ListCheck.TransparentColor = System.Drawing.Color.Transparent;
            this.ListCheck.Images.SetKeyName(0, "check");
            this.ListCheck.Images.SetKeyName(1, "uncheck");
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.AutoSize = true;
            this.lblLeyenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLeyenda.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeyenda.Location = new System.Drawing.Point(43, 60);
            this.lblLeyenda.Name = "lblLeyenda";
            this.lblLeyenda.Size = new System.Drawing.Size(305, 32);
            this.lblLeyenda.TabIndex = 1;
            this.lblLeyenda.Text = "Selecciona las Bibliotecas que quieres anclar";
            this.lblLeyenda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.Gainsboro;
            this.tableMain.SetColumnSpan(this.pnlSeparador, 4);
            this.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSeparador.Location = new System.Drawing.Point(43, 102);
            this.pnlSeparador.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlSeparador.MaximumSize = new System.Drawing.Size(0, 1);
            this.pnlSeparador.MinimumSize = new System.Drawing.Size(0, 1);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(418, 1);
            this.pnlSeparador.TabIndex = 2;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeColumns = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvItems.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.ColumnHeadersVisible = false;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtcLibraryName,
            this.imgcIcon,
            this.txtcDescription,
            this.chkcCheck});
            this.tableMain.SetColumnSpan(this.dgvItems, 4);
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.EnableHeadersVisualStyles = false;
            this.dgvItems.GridColor = System.Drawing.SystemColors.Control;
            this.dgvItems.Location = new System.Drawing.Point(43, 103);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvItems.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Gray;
            this.dgvItems.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(418, 528);
            this.dgvItems.TabIndex = 3;
            this.dgvItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellEndEdit);
            this.dgvItems.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvItems_CellMouseUp);
            this.dgvItems.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvItems_CellPainting);
            this.dgvItems.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvItems_CurrentCellDirtyStateChanged);
            // 
            // txtcLibraryName
            // 
            this.txtcLibraryName.DataPropertyName = "libName";
            this.txtcLibraryName.HeaderText = "Nombre";
            this.txtcLibraryName.Name = "txtcLibraryName";
            this.txtcLibraryName.ReadOnly = true;
            this.txtcLibraryName.Visible = false;
            // 
            // imgcIcon
            // 
            this.imgcIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.imgcIcon.DataPropertyName = "Icon";
            this.imgcIcon.HeaderText = "Icon";
            this.imgcIcon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.imgcIcon.Name = "imgcIcon";
            this.imgcIcon.ReadOnly = true;
            this.imgcIcon.Width = 5;
            // 
            // txtcDescription
            // 
            this.txtcDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtcDescription.DataPropertyName = "Description";
            this.txtcDescription.HeaderText = "Description";
            this.txtcDescription.Name = "txtcDescription";
            this.txtcDescription.ReadOnly = true;
            this.txtcDescription.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtcDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // chkcCheck
            // 
            this.chkcCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.chkcCheck.DataPropertyName = "Pinned";
            this.chkcCheck.HeaderText = "Marcar";
            this.chkcCheck.Name = "chkcCheck";
            this.chkcCheck.Width = 5;
            // 
            // iconTitleBar
            // 
            this.iconTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconTitleBar.Location = new System.Drawing.Point(0, 0);
            this.iconTitleBar.Margin = new System.Windows.Forms.Padding(0);
            this.iconTitleBar.Name = "iconTitleBar";
            this.iconTitleBar.Padding = new System.Windows.Forms.Padding(5);
            this.iconTitleBar.Size = new System.Drawing.Size(40, 40);
            this.iconTitleBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconTitleBar.TabIndex = 4;
            this.iconTitleBar.TabStop = false;
            this.iconTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
            // 
            // btnHelp
            // 
            this.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.ImageKey = "help_B";
            this.btnHelp.ImageList = this.ListTitleBar;
            this.btnHelp.Location = new System.Drawing.Point(384, 0);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(0);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(40, 40);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.button_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ImageKey = "min_B";
            this.btnMinimize.ImageList = this.ListTitleBar;
            this.btnMinimize.Location = new System.Drawing.Point(424, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(40, 40);
            this.btnMinimize.TabIndex = 6;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.button_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ImageKey = "close_B";
            this.btnClose.ImageList = this.ListTitleBar;
            this.btnClose.Location = new System.Drawing.Point(464, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 7;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.tableMain.SetColumnSpan(this.lblTitle, 2);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(40, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(344, 40);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Library Restorer";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
            // 
            // ListFolders
            // 
            this.ListFolders.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ListFolders.ImageStream")));
            this.ListFolders.TransparentColor = System.Drawing.Color.Transparent;
            this.ListFolders.Images.SetKeyName(0, "3DObjects");
            this.ListFolders.Images.SetKeyName(1, "Pictures");
            this.ListFolders.Images.SetKeyName(2, "Desktop");
            this.ListFolders.Images.SetKeyName(3, "Music");
            this.ListFolders.Images.SetKeyName(4, "Documents");
            this.ListFolders.Images.SetKeyName(5, "Videos");
            this.ListFolders.Images.SetKeyName(6, "Downloads");
            // 
            // ListTitleBar
            // 
            this.ListTitleBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ListTitleBar.ImageStream")));
            this.ListTitleBar.TransparentColor = System.Drawing.Color.Transparent;
            this.ListTitleBar.Images.SetKeyName(0, "help_B");
            this.ListTitleBar.Images.SetKeyName(1, "help_W");
            this.ListTitleBar.Images.SetKeyName(2, "min_B");
            this.ListTitleBar.Images.SetKeyName(3, "min_W");
            this.ListTitleBar.Images.SetKeyName(4, "close_B");
            this.ListTitleBar.Images.SetKeyName(5, "close_W");
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(504, 661);
            this.Controls.Add(this.tableMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Restorer";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.tableMain.ResumeLayout(false);
            this.tableMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconTitleBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.Button btnTodosNinguno;
        private System.Windows.Forms.Label lblLeyenda;
        private System.Windows.Forms.Panel pnlSeparador;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.PictureBox iconTitleBar;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ImageList ListCheck;
        private System.Windows.Forms.ImageList ListFolders;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcLibraryName;
        private System.Windows.Forms.DataGridViewImageColumn imgcIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtcDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkcCheck;
        private System.Windows.Forms.ImageList ListTitleBar;
    }
}

