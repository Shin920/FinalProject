
namespace FinalProject
{
    partial class frmUsergroupMSet_CRUD
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsergroupMSet_CRUD));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cboGroup = new System.Windows.Forms.ComboBox();
            this.Btngroup = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnScreen = new System.Windows.Forms.Button();
            this.rdoScreenName = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.rdoScreenCode = new System.Windows.Forms.RadioButton();
            this.BtnIn = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.BtnOut = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.dgvUseScreen = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.dgvNUseScreen = new System.Windows.Forms.DataGridView();
            this.lblSubTitle1 = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.tblSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUseScreen)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNUseScreen)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.cboGroup);
            this.panel3.Controls.Add(this.Btngroup);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtGroup);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(357, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(774, 52);
            this.panel3.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label7.Location = new System.Drawing.Point(9, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "그룹명";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboGroup
            // 
            this.cboGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGroup.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cboGroup.FormattingEnabled = true;
            this.cboGroup.Location = new System.Drawing.Point(73, 15);
            this.cboGroup.Name = "cboGroup";
            this.cboGroup.Size = new System.Drawing.Size(179, 23);
            this.cboGroup.TabIndex = 6;
            this.cboGroup.SelectedIndexChanged += new System.EventHandler(this.cboGroup_SelectedIndexChanged);
            // 
            // Btngroup
            // 
            this.Btngroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.Btngroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btngroup.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btngroup.ForeColor = System.Drawing.Color.White;
            this.Btngroup.Location = new System.Drawing.Point(742, 15);
            this.Btngroup.Name = "Btngroup";
            this.Btngroup.Size = new System.Drawing.Size(25, 25);
            this.Btngroup.TabIndex = 61;
            this.Btngroup.Text = "🔍";
            this.Btngroup.UseVisualStyleBackColor = false;
            this.Btngroup.Click += new System.EventHandler(this.Btngroup_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label6.Location = new System.Drawing.Point(270, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "그룹코드";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtGroup
            // 
            this.txtGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroup.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtGroup.Location = new System.Drawing.Point(342, 15);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(394, 23);
            this.txtGroup.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(4, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(346, 58);
            this.label8.TabIndex = 4;
            this.label8.Text = "화면";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(4, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(346, 58);
            this.label10.TabIndex = 0;
            this.label10.Text = "그룹";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblSearch
            // 
            this.tblSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblSearch.ColumnCount = 2;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.12875F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.87125F));
            this.tblSearch.Controls.Add(this.panel3, 1, 0);
            this.tblSearch.Controls.Add(this.label8, 0, 1);
            this.tblSearch.Controls.Add(this.label10, 0, 0);
            this.tblSearch.Controls.Add(this.panel2, 1, 1);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 2;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblSearch.Size = new System.Drawing.Size(1135, 119);
            this.tblSearch.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnScreen);
            this.panel2.Controls.Add(this.rdoScreenName);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.rdoScreenCode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(357, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(774, 52);
            this.panel2.TabIndex = 5;
            // 
            // BtnScreen
            // 
            this.BtnScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.BtnScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnScreen.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnScreen.ForeColor = System.Drawing.Color.White;
            this.BtnScreen.Location = new System.Drawing.Point(742, 12);
            this.BtnScreen.Name = "BtnScreen";
            this.BtnScreen.Size = new System.Drawing.Size(23, 25);
            this.BtnScreen.TabIndex = 63;
            this.BtnScreen.Text = "🔍";
            this.BtnScreen.UseVisualStyleBackColor = false;
            this.BtnScreen.Click += new System.EventHandler(this.BtnScreen_Click);
            // 
            // rdoScreenName
            // 
            this.rdoScreenName.AutoSize = true;
            this.rdoScreenName.BackColor = System.Drawing.Color.White;
            this.rdoScreenName.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.rdoScreenName.Location = new System.Drawing.Point(12, 16);
            this.rdoScreenName.Name = "rdoScreenName";
            this.rdoScreenName.Size = new System.Drawing.Size(61, 19);
            this.rdoScreenName.TabIndex = 9;
            this.rdoScreenName.TabStop = true;
            this.rdoScreenName.Text = "화면명";
            this.rdoScreenName.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtSearch.Location = new System.Drawing.Point(294, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(442, 23);
            this.txtSearch.TabIndex = 62;
            // 
            // rdoScreenCode
            // 
            this.rdoScreenCode.AutoSize = true;
            this.rdoScreenCode.BackColor = System.Drawing.Color.White;
            this.rdoScreenCode.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.rdoScreenCode.Location = new System.Drawing.Point(146, 16);
            this.rdoScreenCode.Name = "rdoScreenCode";
            this.rdoScreenCode.Size = new System.Drawing.Size(73, 19);
            this.rdoScreenCode.TabIndex = 10;
            this.rdoScreenCode.TabStop = true;
            this.rdoScreenCode.Text = "화면코드";
            this.rdoScreenCode.UseVisualStyleBackColor = false;
            // 
            // BtnIn
            // 
            this.BtnIn.BackColor = System.Drawing.Color.White;
            this.BtnIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIn.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.BtnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIn.ImageIndex = 1;
            this.BtnIn.ImageList = this.imageList1;
            this.BtnIn.Location = new System.Drawing.Point(447, 401);
            this.BtnIn.Name = "BtnIn";
            this.BtnIn.Size = new System.Drawing.Size(66, 30);
            this.BtnIn.TabIndex = 82;
            this.BtnIn.Text = "추가";
            this.BtnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnIn.UseVisualStyleBackColor = false;
            this.BtnIn.Click += new System.EventHandler(this.BtnIn_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "minus.png");
            this.imageList1.Images.SetKeyName(1, "plus.png");
            // 
            // BtnOut
            // 
            this.BtnOut.BackColor = System.Drawing.Color.White;
            this.BtnOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOut.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.BtnOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOut.ImageIndex = 0;
            this.BtnOut.ImageList = this.imageList1;
            this.BtnOut.Location = new System.Drawing.Point(447, 458);
            this.BtnOut.Name = "BtnOut";
            this.BtnOut.Size = new System.Drawing.Size(66, 30);
            this.BtnOut.TabIndex = 81;
            this.BtnOut.Text = "삭제";
            this.BtnOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOut.UseVisualStyleBackColor = false;
            this.BtnOut.Click += new System.EventHandler(this.BtnOut_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label3.Location = new System.Drawing.Point(515, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(442, 34);
            this.label3.TabIndex = 77;
            this.label3.Text = "☷ 추가 화면 등록";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(552, 25);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(30, 19);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Text = " ";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // dgvUseScreen
            // 
            this.dgvUseScreen.BackgroundColor = System.Drawing.Color.White;
            this.dgvUseScreen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUseScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUseScreen.Location = new System.Drawing.Point(0, 0);
            this.dgvUseScreen.Name = "dgvUseScreen";
            this.dgvUseScreen.RowTemplate.Height = 23;
            this.dgvUseScreen.Size = new System.Drawing.Size(630, 374);
            this.dgvUseScreen.TabIndex = 0;
            this.dgvUseScreen.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUseScreen_CellMouseClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.checkBox6);
            this.panel1.Controls.Add(this.dgvUseScreen);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Location = new System.Drawing.Point(520, 255);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 374);
            this.panel1.TabIndex = 79;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.button6.Location = new System.Drawing.Point(1082, 18);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(68, 26);
            this.button6.TabIndex = 80;
            this.button6.Text = "닫기";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.BackColor = System.Drawing.Color.LightCoral;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(1011, 17);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(68, 28);
            this.BtnSave.TabIndex = 78;
            this.BtnSave.Text = "💾저장";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // pnlDgv
            // 
            this.pnlDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDgv.Controls.Add(this.dgvNUseScreen);
            this.pnlDgv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnlDgv.Location = new System.Drawing.Point(17, 255);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Size = new System.Drawing.Size(424, 374);
            this.pnlDgv.TabIndex = 76;
            // 
            // dgvNUseScreen
            // 
            this.dgvNUseScreen.BackgroundColor = System.Drawing.Color.White;
            this.dgvNUseScreen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNUseScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNUseScreen.Location = new System.Drawing.Point(0, 0);
            this.dgvNUseScreen.Name = "dgvNUseScreen";
            this.dgvNUseScreen.RowTemplate.Height = 23;
            this.dgvNUseScreen.Size = new System.Drawing.Size(424, 374);
            this.dgvNUseScreen.TabIndex = 0;
            this.dgvNUseScreen.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvNUseScreen_CellMouseClick);
            // 
            // lblSubTitle1
            // 
            this.lblSubTitle1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSubTitle1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSubTitle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSubTitle1.Location = new System.Drawing.Point(12, 218);
            this.lblSubTitle1.Name = "lblSubTitle1";
            this.lblSubTitle1.Size = new System.Drawing.Size(158, 34);
            this.lblSubTitle1.TabIndex = 74;
            this.lblSubTitle1.Text = "☷ 화면 목록";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.Controls.Add(this.tblSearch);
            this.pnlSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnlSearch.Location = new System.Drawing.Point(18, 68);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1135, 119);
            this.pnlSearch.TabIndex = 75;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(122, 30);
            this.lblTitle.TabIndex = 73;
            this.lblTitle.Text = "그룹 추가";
            // 
            // frmUsergroupMSet_CRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1164, 644);
            this.Controls.Add(this.BtnIn);
            this.Controls.Add(this.BtnOut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.pnlDgv);
            this.Controls.Add(this.lblSubTitle1);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmUsergroupMSet_CRUD";
            this.Text = "사용자그룹별권한설정";
            this.Load += new System.EventHandler(this.frmUsergroupMSet_CRUD_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUseScreen)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNUseScreen)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboGroup;
        protected System.Windows.Forms.Button Btngroup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Button BtnScreen;
        protected System.Windows.Forms.RadioButton rdoScreenName;
        private System.Windows.Forms.TextBox txtSearch;
        protected System.Windows.Forms.RadioButton rdoScreenCode;
        protected System.Windows.Forms.Button BtnIn;
        protected System.Windows.Forms.ImageList imageList1;
        protected System.Windows.Forms.Button BtnOut;
        protected System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.DataGridView dgvUseScreen;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Button button6;
        protected System.Windows.Forms.Button BtnSave;
        protected System.Windows.Forms.Panel pnlDgv;
        private System.Windows.Forms.DataGridView dgvNUseScreen;
        protected System.Windows.Forms.Label lblSubTitle1;
        protected System.Windows.Forms.Panel pnlSearch;
        protected System.Windows.Forms.Label lblTitle;
    }
}