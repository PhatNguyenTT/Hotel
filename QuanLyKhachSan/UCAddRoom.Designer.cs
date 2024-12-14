namespace QuanLyKhachSan
{
    public partial class UCAddRoom
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRoomNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboRoomType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboRoomBed = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRoomPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnRoomAdd = new Guna.UI2.WinForms.Guna2Button();
            this.dtgvAddRoom = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRoomEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnRoomDelete = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAddRoom)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thêm Phòng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1291, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Số Phòng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1291, 226);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Loại Phòng";
            // 
            // txtRoomNo
            // 
            this.txtRoomNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRoomNo.DefaultText = "";
            this.txtRoomNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRoomNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRoomNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRoomNo.DisabledState.Parent = this.txtRoomNo;
            this.txtRoomNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRoomNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRoomNo.FocusedState.Parent = this.txtRoomNo;
            this.txtRoomNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomNo.ForeColor = System.Drawing.Color.Black;
            this.txtRoomNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRoomNo.HoverState.Parent = this.txtRoomNo;
            this.txtRoomNo.Location = new System.Drawing.Point(1296, 132);
            this.txtRoomNo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtRoomNo.Name = "txtRoomNo";
            this.txtRoomNo.PasswordChar = '\0';
            this.txtRoomNo.PlaceholderText = "";
            this.txtRoomNo.SelectedText = "";
            this.txtRoomNo.ShadowDecoration.Parent = this.txtRoomNo;
            this.txtRoomNo.Size = new System.Drawing.Size(481, 46);
            this.txtRoomNo.TabIndex = 8;
            // 
            // cboRoomType
            // 
            this.cboRoomType.BackColor = System.Drawing.Color.Transparent;
            this.cboRoomType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoomType.FocusedColor = System.Drawing.Color.Empty;
            this.cboRoomType.FocusedState.Parent = this.cboRoomType;
            this.cboRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoomType.ForeColor = System.Drawing.Color.Black;
            this.cboRoomType.FormattingEnabled = true;
            this.cboRoomType.HoverState.Parent = this.cboRoomType;
            this.cboRoomType.ItemHeight = 30;
            this.cboRoomType.Items.AddRange(new object[] {
            "Không Điều Hòa",
            "Điều Hòa"});
            this.cboRoomType.ItemsAppearance.Parent = this.cboRoomType;
            this.cboRoomType.Location = new System.Drawing.Point(1296, 300);
            this.cboRoomType.Margin = new System.Windows.Forms.Padding(4);
            this.cboRoomType.Name = "cboRoomType";
            this.cboRoomType.ShadowDecoration.Parent = this.cboRoomType;
            this.cboRoomType.Size = new System.Drawing.Size(480, 36);
            this.cboRoomType.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1291, 394);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Giường";
            // 
            // cboRoomBed
            // 
            this.cboRoomBed.BackColor = System.Drawing.Color.Transparent;
            this.cboRoomBed.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRoomBed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoomBed.FocusedColor = System.Drawing.Color.Empty;
            this.cboRoomBed.FocusedState.Parent = this.cboRoomBed;
            this.cboRoomBed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoomBed.ForeColor = System.Drawing.Color.Black;
            this.cboRoomBed.FormattingEnabled = true;
            this.cboRoomBed.HoverState.Parent = this.cboRoomBed;
            this.cboRoomBed.ItemHeight = 30;
            this.cboRoomBed.Items.AddRange(new object[] {
            "Đơn",
            "Đôi"});
            this.cboRoomBed.ItemsAppearance.Parent = this.cboRoomBed;
            this.cboRoomBed.Location = new System.Drawing.Point(1296, 468);
            this.cboRoomBed.Margin = new System.Windows.Forms.Padding(4);
            this.cboRoomBed.Name = "cboRoomBed";
            this.cboRoomBed.ShadowDecoration.Parent = this.cboRoomBed;
            this.cboRoomBed.Size = new System.Drawing.Size(480, 36);
            this.cboRoomBed.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(1291, 561);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Giá";
            // 
            // txtRoomPrice
            // 
            this.txtRoomPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRoomPrice.DefaultText = "";
            this.txtRoomPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRoomPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRoomPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRoomPrice.DisabledState.Parent = this.txtRoomPrice;
            this.txtRoomPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRoomPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRoomPrice.FocusedState.Parent = this.txtRoomPrice;
            this.txtRoomPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomPrice.ForeColor = System.Drawing.Color.Black;
            this.txtRoomPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRoomPrice.HoverState.Parent = this.txtRoomPrice;
            this.txtRoomPrice.Location = new System.Drawing.Point(1296, 635);
            this.txtRoomPrice.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtRoomPrice.Name = "txtRoomPrice";
            this.txtRoomPrice.PasswordChar = '\0';
            this.txtRoomPrice.PlaceholderText = "";
            this.txtRoomPrice.SelectedText = "";
            this.txtRoomPrice.ShadowDecoration.Parent = this.txtRoomPrice;
            this.txtRoomPrice.Size = new System.Drawing.Size(481, 46);
            this.txtRoomPrice.TabIndex = 15;
            // 
            // btnRoomAdd
            // 
            this.btnRoomAdd.BorderRadius = 20;
            this.btnRoomAdd.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.btnRoomAdd.BorderThickness = 1;
            this.btnRoomAdd.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(221)))));
            this.btnRoomAdd.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnRoomAdd.CheckedState.Parent = this.btnRoomAdd;
            this.btnRoomAdd.CustomImages.Parent = this.btnRoomAdd;
            this.btnRoomAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnRoomAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoomAdd.ForeColor = System.Drawing.Color.White;
            this.btnRoomAdd.HoverState.Parent = this.btnRoomAdd;
            this.btnRoomAdd.Location = new System.Drawing.Point(1198, 740);
            this.btnRoomAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnRoomAdd.Name = "btnRoomAdd";
            this.btnRoomAdd.ShadowDecoration.Parent = this.btnRoomAdd;
            this.btnRoomAdd.Size = new System.Drawing.Size(211, 64);
            this.btnRoomAdd.TabIndex = 16;
            this.btnRoomAdd.Text = "Thêm";
            this.btnRoomAdd.Click += new System.EventHandler(this.btnRoomAdd_Click);
            // 
            // dtgvAddRoom
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dtgvAddRoom.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dtgvAddRoom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvAddRoom.BackgroundColor = System.Drawing.Color.White;
            this.dtgvAddRoom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgvAddRoom.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgvAddRoom.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvAddRoom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dtgvAddRoom.ColumnHeadersHeight = 4;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvAddRoom.DefaultCellStyle = dataGridViewCellStyle12;
            this.dtgvAddRoom.EnableHeadersVisualStyles = false;
            this.dtgvAddRoom.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgvAddRoom.Location = new System.Drawing.Point(64, 132);
            this.dtgvAddRoom.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvAddRoom.Name = "dtgvAddRoom";
            this.dtgvAddRoom.RowHeadersVisible = false;
            this.dtgvAddRoom.RowHeadersWidth = 51;
            this.dtgvAddRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvAddRoom.Size = new System.Drawing.Size(1097, 672);
            this.dtgvAddRoom.TabIndex = 18;
            this.dtgvAddRoom.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dtgvAddRoom.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgvAddRoom.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgvAddRoom.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgvAddRoom.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgvAddRoom.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgvAddRoom.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgvAddRoom.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgvAddRoom.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgvAddRoom.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgvAddRoom.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtgvAddRoom.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgvAddRoom.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgvAddRoom.ThemeStyle.HeaderStyle.Height = 4;
            this.dtgvAddRoom.ThemeStyle.ReadOnly = false;
            this.dtgvAddRoom.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgvAddRoom.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgvAddRoom.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtgvAddRoom.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgvAddRoom.ThemeStyle.RowsStyle.Height = 22;
            this.dtgvAddRoom.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgvAddRoom.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgvAddRoom.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvAddRoom_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRoomEdit);
            this.panel1.Controls.Add(this.btnRoomDelete);
            this.panel1.Controls.Add(this.dtgvAddRoom);
            this.panel1.Controls.Add(this.btnRoomAdd);
            this.panel1.Controls.Add(this.txtRoomPrice);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboRoomBed);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboRoomType);
            this.panel1.Controls.Add(this.txtRoomNo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2000, 875);
            this.panel1.TabIndex = 0;
            // 
            // btnRoomEdit
            // 
            this.btnRoomEdit.BorderRadius = 20;
            this.btnRoomEdit.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.btnRoomEdit.BorderThickness = 1;
            this.btnRoomEdit.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(221)))));
            this.btnRoomEdit.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnRoomEdit.CheckedState.Parent = this.btnRoomEdit;
            this.btnRoomEdit.CustomImages.Parent = this.btnRoomEdit;
            this.btnRoomEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnRoomEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoomEdit.ForeColor = System.Drawing.Color.White;
            this.btnRoomEdit.HoverState.Parent = this.btnRoomEdit;
            this.btnRoomEdit.Location = new System.Drawing.Point(1463, 740);
            this.btnRoomEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnRoomEdit.Name = "btnRoomEdit";
            this.btnRoomEdit.ShadowDecoration.Parent = this.btnRoomEdit;
            this.btnRoomEdit.Size = new System.Drawing.Size(211, 64);
            this.btnRoomEdit.TabIndex = 20;
            this.btnRoomEdit.Text = "Sửa";
            this.btnRoomEdit.Click += new System.EventHandler(this.btnRoomEdit_Click);
            // 
            // btnRoomDelete
            // 
            this.btnRoomDelete.BorderRadius = 20;
            this.btnRoomDelete.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.btnRoomDelete.BorderThickness = 1;
            this.btnRoomDelete.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(221)))));
            this.btnRoomDelete.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnRoomDelete.CheckedState.Parent = this.btnRoomDelete;
            this.btnRoomDelete.CustomImages.Parent = this.btnRoomDelete;
            this.btnRoomDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnRoomDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoomDelete.ForeColor = System.Drawing.Color.White;
            this.btnRoomDelete.HoverState.Parent = this.btnRoomDelete;
            this.btnRoomDelete.Location = new System.Drawing.Point(1728, 740);
            this.btnRoomDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnRoomDelete.Name = "btnRoomDelete";
            this.btnRoomDelete.ShadowDecoration.Parent = this.btnRoomDelete;
            this.btnRoomDelete.Size = new System.Drawing.Size(211, 64);
            this.btnRoomDelete.TabIndex = 19;
            this.btnRoomDelete.Text = "Xóa";
            this.btnRoomDelete.Click += new System.EventHandler(this.btnRoomDelete_Click);
            // 
            // UCAddRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCAddRoom";
            this.Size = new System.Drawing.Size(2004, 894);
            this.Load += new System.EventHandler(this.UCAddRoom_Load);
            this.Enter += new System.EventHandler(this.UCAddRoom_Enter);
            this.Leave += new System.EventHandler(this.UCAddRoom_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAddRoom)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dtgvAddRoom;
        private Guna.UI2.WinForms.Guna2Button btnRoomAdd;
        private Guna.UI2.WinForms.Guna2TextBox txtRoomPrice;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cboRoomBed;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cboRoomType;
        private Guna.UI2.WinForms.Guna2TextBox txtRoomNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnRoomDelete;
        private Guna.UI2.WinForms.Guna2Button btnRoomEdit;
    }
}
