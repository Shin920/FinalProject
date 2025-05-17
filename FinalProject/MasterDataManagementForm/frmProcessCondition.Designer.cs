
namespace FinalProject
{
    partial class frmProcessCondition
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessCondition));
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.cboSystemName = new System.Windows.Forms.ComboBox();
            this.txtSystemCode = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.cboProductName = new System.Windows.Forms.ComboBox();
            this.dgvProcessList = new System.Windows.Forms.DataGridView();
            this.dgvProductList = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnClearText = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.nmrSL = new System.Windows.Forms.NumericUpDown();
            this.nmrLSL = new System.Windows.Forms.NumericUpDown();
            this.nmrUSL = new System.Windows.Forms.NumericUpDown();
            this.cboNewWcName = new System.Windows.Forms.ComboBox();
            this.cboNewProductName = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNewWcCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNewProductCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNewConditionName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNewConditionCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboCondition = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlSubBottons.SuspendLayout();
            this.tblSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrLSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrUSL)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvProductList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvProcessList);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tblSearch);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(203, 40);
            this.lblTitle.Text = "공정조건 설정";
            // 
            // pnlCondition
            // 
            this.pnlCondition.Controls.Add(this.cboCondition);
            this.pnlCondition.Controls.Add(this.label1);
            this.pnlCondition.Controls.Add(this.nmrSL);
            this.pnlCondition.Controls.Add(this.nmrLSL);
            this.pnlCondition.Controls.Add(this.nmrUSL);
            this.pnlCondition.Controls.Add(this.cboNewWcName);
            this.pnlCondition.Controls.Add(this.cboNewProductName);
            this.pnlCondition.Controls.Add(this.label15);
            this.pnlCondition.Controls.Add(this.txtNote);
            this.pnlCondition.Controls.Add(this.txtUnit);
            this.pnlCondition.Controls.Add(this.label14);
            this.pnlCondition.Controls.Add(this.label12);
            this.pnlCondition.Controls.Add(this.label11);
            this.pnlCondition.Controls.Add(this.label10);
            this.pnlCondition.Controls.Add(this.txtNewWcCode);
            this.pnlCondition.Controls.Add(this.label9);
            this.pnlCondition.Controls.Add(this.label8);
            this.pnlCondition.Controls.Add(this.txtNewProductCode);
            this.pnlCondition.Controls.Add(this.label7);
            this.pnlCondition.Controls.Add(this.label6);
            this.pnlCondition.Controls.Add(this.txtNewConditionName);
            this.pnlCondition.Controls.Add(this.label5);
            this.pnlCondition.Controls.Add(this.txtNewConditionCode);
            this.pnlCondition.Controls.Add(this.label3);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCopy);
            // 
            // pnlSubBottons
            // 
            this.pnlSubBottons.Controls.Add(this.btnSave);
            this.pnlSubBottons.Controls.Add(this.btnClearText);
            // 
            // label2
            // 
            this.label2.Text = "☷ 공정규격";
            // 
            // lblSubTitle1
            // 
            this.lblSubTitle1.Size = new System.Drawing.Size(132, 31);
            this.lblSubTitle1.Text = "☷ 품목 목록";
            // 
            // lblSubTitle2
            // 
            this.lblSubTitle2.Size = new System.Drawing.Size(175, 31);
            this.lblSubTitle2.Text = "☷ 공정조건 목록";
            // 
            // tblSearch
            // 
            this.tblSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblSearch.ColumnCount = 6;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.67831F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.78473F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8156F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.89115F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.22556F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.49624F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tblSearch.Controls.Add(this.cboSystemName, 4, 0);
            this.tblSearch.Controls.Add(this.txtSystemCode, 5, 0);
            this.tblSearch.Controls.Add(this.label19, 3, 0);
            this.tblSearch.Controls.Add(this.label20, 0, 0);
            this.tblSearch.Controls.Add(this.txtProductCode, 2, 0);
            this.tblSearch.Controls.Add(this.cboProductName, 1, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblSearch.Size = new System.Drawing.Size(1460, 55);
            this.tblSearch.TabIndex = 5;
            // 
            // cboSystemName
            // 
            this.cboSystemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSystemName.FormattingEnabled = true;
            this.cboSystemName.Location = new System.Drawing.Point(897, 17);
            this.cboSystemName.Name = "cboSystemName";
            this.cboSystemName.Size = new System.Drawing.Size(215, 23);
            this.cboSystemName.TabIndex = 35;
            this.cboSystemName.SelectedIndexChanged += new System.EventHandler(this.cboSystemName_SelectedIndexChanged);
            // 
            // txtSystemCode
            // 
            this.txtSystemCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSystemCode.Location = new System.Drawing.Point(1119, 16);
            this.txtSystemCode.Name = "txtSystemCode";
            this.txtSystemCode.Size = new System.Drawing.Size(337, 23);
            this.txtSystemCode.TabIndex = 34;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label19.Location = new System.Drawing.Point(694, 1);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(196, 53);
            this.label19.TabIndex = 3;
            this.label19.Text = "설비";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label20.Location = new System.Drawing.Point(4, 1);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(222, 53);
            this.label20.TabIndex = 0;
            this.label20.Text = "품목";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductCode.Location = new System.Drawing.Point(449, 16);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(238, 23);
            this.txtProductCode.TabIndex = 1;
            // 
            // cboProductName
            // 
            this.cboProductName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProductName.FormattingEnabled = true;
            this.cboProductName.Location = new System.Drawing.Point(233, 17);
            this.cboProductName.Name = "cboProductName";
            this.cboProductName.Size = new System.Drawing.Size(209, 23);
            this.cboProductName.TabIndex = 2;
            this.cboProductName.SelectedIndexChanged += new System.EventHandler(this.cboProductName_SelectedIndexChanged);
            // 
            // dgvProcessList
            // 
            this.dgvProcessList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProcessList.BackgroundColor = System.Drawing.Color.White;
            this.dgvProcessList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcessList.Location = new System.Drawing.Point(3, 38);
            this.dgvProcessList.Name = "dgvProcessList";
            this.dgvProcessList.RowTemplate.Height = 23;
            this.dgvProcessList.Size = new System.Drawing.Size(964, 685);
            this.dgvProcessList.TabIndex = 42;
            this.dgvProcessList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProcessList_CellDoubleClick);
            // 
            // dgvProductList
            // 
            this.dgvProductList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductList.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductList.Location = new System.Drawing.Point(2, 38);
            this.dgvProductList.Name = "dgvProductList";
            this.dgvProductList.RowTemplate.Height = 23;
            this.dgvProductList.Size = new System.Drawing.Size(483, 850);
            this.dgvProductList.TabIndex = 25;
            this.dgvProductList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductList_CellDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "minus.png");
            this.imageList1.Images.SetKeyName(1, "plus.png");
            this.imageList1.Images.SetKeyName(2, "회색.png");
            this.imageList1.Images.SetKeyName(3, "흰색.png");
            // 
            // btnClearText
            // 
            this.btnClearText.BackColor = System.Drawing.Color.White;
            this.btnClearText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearText.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClearText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnClearText.Location = new System.Drawing.Point(235, 2);
            this.btnClearText.Name = "btnClearText";
            this.btnClearText.Size = new System.Drawing.Size(32, 30);
            this.btnClearText.TabIndex = 70;
            this.btnClearText.Text = "⟳";
            this.btnClearText.UseVisualStyleBackColor = false;
            this.btnClearText.Click += new System.EventHandler(this.btnClearText_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCopy.ForeColor = System.Drawing.Color.White;
            this.btnCopy.Location = new System.Drawing.Point(485, 1);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(100, 29);
            this.btnCopy.TabIndex = 67;
            this.btnCopy.Text = "공정조건복사";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // nmrSL
            // 
            this.nmrSL.Location = new System.Drawing.Point(687, 50);
            this.nmrSL.Name = "nmrSL";
            this.nmrSL.Size = new System.Drawing.Size(91, 23);
            this.nmrSL.TabIndex = 54;
            // 
            // nmrLSL
            // 
            this.nmrLSL.Location = new System.Drawing.Point(688, 80);
            this.nmrLSL.Name = "nmrLSL";
            this.nmrLSL.Size = new System.Drawing.Size(91, 23);
            this.nmrLSL.TabIndex = 53;
            // 
            // nmrUSL
            // 
            this.nmrUSL.Location = new System.Drawing.Point(687, 17);
            this.nmrUSL.Name = "nmrUSL";
            this.nmrUSL.Size = new System.Drawing.Size(91, 23);
            this.nmrUSL.TabIndex = 52;
            // 
            // cboNewWcName
            // 
            this.cboNewWcName.FormattingEnabled = true;
            this.cboNewWcName.Location = new System.Drawing.Point(467, 16);
            this.cboNewWcName.Name = "cboNewWcName";
            this.cboNewWcName.Size = new System.Drawing.Size(101, 23);
            this.cboNewWcName.TabIndex = 51;
            this.cboNewWcName.SelectedIndexChanged += new System.EventHandler(this.cboNewWcName_SelectedIndexChanged);
            // 
            // cboNewProductName
            // 
            this.cboNewProductName.FormattingEnabled = true;
            this.cboNewProductName.Location = new System.Drawing.Point(270, 15);
            this.cboNewProductName.Name = "cboNewProductName";
            this.cboNewProductName.Size = new System.Drawing.Size(101, 23);
            this.cboNewProductName.TabIndex = 50;
            this.cboNewProductName.SelectedIndexChanged += new System.EventHandler(this.cboNewProductName_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(784, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 15);
            this.label15.TabIndex = 48;
            this.label15.Text = " ✧  비고";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(843, 12);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(118, 101);
            this.txtNote.TabIndex = 49;
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(467, 83);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(101, 23);
            this.txtUnit.TabIndex = 47;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(379, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 15);
            this.label14.TabIndex = 46;
            this.label14.Text = " ✧  단위";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(574, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 15);
            this.label12.TabIndex = 43;
            this.label12.Text = " ✧  규격하한값LSL";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(574, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 15);
            this.label11.TabIndex = 42;
            this.label11.Text = " ✧  규격기준값SL";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(574, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 15);
            this.label10.TabIndex = 41;
            this.label10.Text = " ✧  규격상한값USL";
            // 
            // txtNewWcCode
            // 
            this.txtNewWcCode.Location = new System.Drawing.Point(467, 51);
            this.txtNewWcCode.Name = "txtNewWcCode";
            this.txtNewWcCode.Size = new System.Drawing.Size(101, 23);
            this.txtNewWcCode.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(379, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 15);
            this.label9.TabIndex = 39;
            this.label9.Text = " ✧  작업장코드";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(379, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 15);
            this.label8.TabIndex = 38;
            this.label8.Text = " ✧  작업장명";
            // 
            // txtNewProductCode
            // 
            this.txtNewProductCode.Location = new System.Drawing.Point(270, 50);
            this.txtNewProductCode.Name = "txtNewProductCode";
            this.txtNewProductCode.Size = new System.Drawing.Size(101, 23);
            this.txtNewProductCode.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(194, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 15);
            this.label7.TabIndex = 36;
            this.label7.Text = " ✧  품목코드";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 35;
            this.label6.Text = " ✧  품목명";
            // 
            // txtNewConditionName
            // 
            this.txtNewConditionName.Location = new System.Drawing.Point(87, 85);
            this.txtNewConditionName.Name = "txtNewConditionName";
            this.txtNewConditionName.Size = new System.Drawing.Size(101, 23);
            this.txtNewConditionName.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 33;
            this.label5.Text = " ✧  조건명";
            // 
            // txtNewConditionCode
            // 
            this.txtNewConditionCode.Location = new System.Drawing.Point(87, 51);
            this.txtNewConditionCode.Name = "txtNewConditionCode";
            this.txtNewConditionCode.ReadOnly = true;
            this.txtNewConditionCode.Size = new System.Drawing.Size(101, 23);
            this.txtNewConditionCode.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = " ✧  조건코드";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LightCoral;
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(273, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 32);
            this.btnSave.TabIndex = 68;
            this.btnSave.Text = "💾저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboCondition
            // 
            this.cboCondition.FormattingEnabled = true;
            this.cboCondition.Location = new System.Drawing.Point(87, 17);
            this.cboCondition.Name = "cboCondition";
            this.cboCondition.Size = new System.Drawing.Size(101, 23);
            this.cboCondition.TabIndex = 56;
            this.cboCondition.SelectedIndexChanged += new System.EventHandler(this.cboCondition_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 55;
            this.label1.Text = " ✧  조건목록";
            // 
            // frmProcessCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 1038);
            this.Name = "frmProcessCondition";
            this.Text = "공정조건 설정";
            this.Load += new System.EventHandler(this.frmProcessCondition_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            this.pnlCondition.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlSubBottons.ResumeLayout(false);
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrLSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrUSL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.ComboBox cboSystemName;
        private System.Windows.Forms.TextBox txtSystemCode;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.ComboBox cboProductName;
        private System.Windows.Forms.DataGridView dgvProcessList;
        private System.Windows.Forms.DataGridView dgvProductList;
        protected System.Windows.Forms.Button btnClearText;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.NumericUpDown nmrSL;
        private System.Windows.Forms.NumericUpDown nmrLSL;
        private System.Windows.Forms.NumericUpDown nmrUSL;
        private System.Windows.Forms.ComboBox cboNewWcName;
        private System.Windows.Forms.ComboBox cboNewProductName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNewWcCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNewProductCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNewConditionName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNewConditionCode;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cboCondition;
        private System.Windows.Forms.Label label1;
    }
}
