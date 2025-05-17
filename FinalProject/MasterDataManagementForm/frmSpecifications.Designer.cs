
namespace FinalProject
{
    partial class frmSpecifications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpecifications));
            this.btnCopy = new System.Windows.Forms.Button();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.dgvQuality = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInspectionCode = new System.Windows.Forms.TextBox();
            this.txtInspectionItem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNewProductCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNewProcessCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cboNewProductName = new System.Windows.Forms.ComboBox();
            this.cboNewProcessName = new System.Windows.Forms.ComboBox();
            this.nmrUSL = new System.Windows.Forms.NumericUpDown();
            this.nmrLSL = new System.Windows.Forms.NumericUpDown();
            this.nmrSL = new System.Windows.Forms.NumericUpDown();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.cboProcessName = new System.Windows.Forms.ComboBox();
            this.txtProcessCode = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.cboProductName = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnClearText = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nmrSampleSize = new System.Windows.Forms.NumericUpDown();
            this.cboInspectiontList = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlSubBottons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrUSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrLSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSL)).BeginInit();
            this.tblSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSampleSize)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.SetChildIndex(this.lblTitle, 0);
            this.panel1.Controls.SetChildIndex(this.pnlSearch, 0);
            this.panel1.Controls.SetChildIndex(this.splitContainer1, 0);
            this.panel1.Controls.SetChildIndex(this.label4, 0);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label16);
            this.splitContainer1.Panel1.Controls.Add(this.dgvProduct);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label17);
            this.splitContainer1.Panel2.Controls.Add(this.dgvQuality);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tblSearch);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(208, 40);
            this.lblTitle.Text = "품질규격 설정";
            // 
            // pnlCondition
            // 
            this.pnlCondition.Controls.Add(this.cboInspectiontList);
            this.pnlCondition.Controls.Add(this.label18);
            this.pnlCondition.Controls.Add(this.nmrSampleSize);
            this.pnlCondition.Controls.Add(this.nmrSL);
            this.pnlCondition.Controls.Add(this.nmrLSL);
            this.pnlCondition.Controls.Add(this.nmrUSL);
            this.pnlCondition.Controls.Add(this.cboNewProcessName);
            this.pnlCondition.Controls.Add(this.cboNewProductName);
            this.pnlCondition.Controls.Add(this.label15);
            this.pnlCondition.Controls.Add(this.txtNote);
            this.pnlCondition.Controls.Add(this.txtUnit);
            this.pnlCondition.Controls.Add(this.label14);
            this.pnlCondition.Controls.Add(this.label13);
            this.pnlCondition.Controls.Add(this.label12);
            this.pnlCondition.Controls.Add(this.label11);
            this.pnlCondition.Controls.Add(this.label10);
            this.pnlCondition.Controls.Add(this.txtNewProcessCode);
            this.pnlCondition.Controls.Add(this.label9);
            this.pnlCondition.Controls.Add(this.label8);
            this.pnlCondition.Controls.Add(this.txtNewProductCode);
            this.pnlCondition.Controls.Add(this.label7);
            this.pnlCondition.Controls.Add(this.label6);
            this.pnlCondition.Controls.Add(this.txtInspectionItem);
            this.pnlCondition.Controls.Add(this.label5);
            this.pnlCondition.Controls.Add(this.txtInspectionCode);
            this.pnlCondition.Controls.Add(this.label3);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCopy);
            // 
            // pnlSubBottons
            // 
            this.pnlSubBottons.Controls.Add(this.btnClearText);
            this.pnlSubBottons.Controls.Add(this.btnSave);
            // 
            // label2
            // 
            this.label2.Size = new System.Drawing.Size(177, 32);
            this.label2.Text = "☷ 품질규격 등록";
            // 
            // lblSubTitle1
            // 
            this.lblSubTitle1.Size = new System.Drawing.Size(96, 31);
            this.lblSubTitle1.Text = "☷ 품목";
            // 
            // lblSubTitle2
            // 
            this.lblSubTitle2.Size = new System.Drawing.Size(177, 31);
            this.lblSubTitle2.Text = "☷ 품질규격 설정";
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
            this.btnCopy.TabIndex = 19;
            this.btnCopy.Text = "품질규격복사";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // dgvProduct
            // 
            this.dgvProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProduct.BackgroundColor = System.Drawing.Color.White;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Location = new System.Drawing.Point(0, 35);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.RowTemplate.Height = 23;
            this.dgvProduct.Size = new System.Drawing.Size(483, 856);
            this.dgvProduct.TabIndex = 24;
            this.dgvProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellDoubleClick);
            // 
            // dgvQuality
            // 
            this.dgvQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuality.BackgroundColor = System.Drawing.Color.White;
            this.dgvQuality.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuality.Location = new System.Drawing.Point(2, 38);
            this.dgvQuality.Name = "dgvQuality";
            this.dgvQuality.RowTemplate.Height = 23;
            this.dgvQuality.Size = new System.Drawing.Size(964, 685);
            this.dgvQuality.TabIndex = 41;
            this.dgvQuality.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuality_CellDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = " ✧  검사코드";
            // 
            // txtInspectionCode
            // 
            this.txtInspectionCode.Location = new System.Drawing.Point(86, 47);
            this.txtInspectionCode.Name = "txtInspectionCode";
            this.txtInspectionCode.ReadOnly = true;
            this.txtInspectionCode.Size = new System.Drawing.Size(101, 23);
            this.txtInspectionCode.TabIndex = 1;
            // 
            // txtInspectionItem
            // 
            this.txtInspectionItem.Location = new System.Drawing.Point(86, 81);
            this.txtInspectionItem.Name = "txtInspectionItem";
            this.txtInspectionItem.Size = new System.Drawing.Size(101, 23);
            this.txtInspectionItem.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = " ✧  검사항목";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = " ✧  품목명";
            // 
            // txtNewProductCode
            // 
            this.txtNewProductCode.Location = new System.Drawing.Point(269, 48);
            this.txtNewProductCode.Name = "txtNewProductCode";
            this.txtNewProductCode.ReadOnly = true;
            this.txtNewProductCode.Size = new System.Drawing.Size(101, 23);
            this.txtNewProductCode.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(193, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = " ✧  품목코드";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(378, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = " ✧  공정명";
            // 
            // txtNewProcessCode
            // 
            this.txtNewProcessCode.Location = new System.Drawing.Point(466, 49);
            this.txtNewProcessCode.Name = "txtNewProcessCode";
            this.txtNewProcessCode.ReadOnly = true;
            this.txtNewProcessCode.Size = new System.Drawing.Size(101, 23);
            this.txtNewProcessCode.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(378, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = " ✧  공정코드";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(573, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = " ✧  규격상한값USL";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(573, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 15);
            this.label11.TabIndex = 14;
            this.label11.Text = " ✧  규격기준값SL";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(573, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 15);
            this.label12.TabIndex = 16;
            this.label12.Text = " ✧  규격하한값LSL";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(193, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 15);
            this.label13.TabIndex = 18;
            this.label13.Text = " ✧  샘플크기";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(466, 81);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(101, 23);
            this.txtUnit.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(378, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 15);
            this.label14.TabIndex = 20;
            this.label14.Text = " ✧  단위";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(842, 10);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(118, 101);
            this.txtNote.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(783, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 15);
            this.label15.TabIndex = 22;
            this.label15.Text = " ✧  비고";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(75, 135);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(317, 15);
            this.label16.TabIndex = 25;
            this.label16.Text = "품목/품목코드 - 이건 품목등록에서 등록한 품목들 리스트";
            this.label16.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(66, 118);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(301, 15);
            this.label17.TabIndex = 42;
            this.label17.Text = "이건 여기서 추가/관리해서 품목에 추가/적용 시키는것";
            this.label17.Visible = false;
            // 
            // cboNewProductName
            // 
            this.cboNewProductName.FormattingEnabled = true;
            this.cboNewProductName.Location = new System.Drawing.Point(269, 13);
            this.cboNewProductName.Name = "cboNewProductName";
            this.cboNewProductName.Size = new System.Drawing.Size(101, 23);
            this.cboNewProductName.TabIndex = 26;
            this.cboNewProductName.SelectedIndexChanged += new System.EventHandler(this.cboNewProductName_SelectedIndexChanged);
            // 
            // cboNewProcessName
            // 
            this.cboNewProcessName.FormattingEnabled = true;
            this.cboNewProcessName.Location = new System.Drawing.Point(466, 14);
            this.cboNewProcessName.Name = "cboNewProcessName";
            this.cboNewProcessName.Size = new System.Drawing.Size(101, 23);
            this.cboNewProcessName.TabIndex = 27;
            this.cboNewProcessName.SelectedIndexChanged += new System.EventHandler(this.cboNewProcessName_SelectedIndexChanged);
            // 
            // nmrUSL
            // 
            this.nmrUSL.Location = new System.Drawing.Point(686, 15);
            this.nmrUSL.Name = "nmrUSL";
            this.nmrUSL.Size = new System.Drawing.Size(91, 23);
            this.nmrUSL.TabIndex = 28;
            // 
            // nmrLSL
            // 
            this.nmrLSL.Location = new System.Drawing.Point(687, 78);
            this.nmrLSL.Name = "nmrLSL";
            this.nmrLSL.Size = new System.Drawing.Size(91, 23);
            this.nmrLSL.TabIndex = 29;
            // 
            // nmrSL
            // 
            this.nmrSL.Location = new System.Drawing.Point(686, 48);
            this.nmrSL.Name = "nmrSL";
            this.nmrSL.Size = new System.Drawing.Size(91, 23);
            this.nmrSL.TabIndex = 30;
            // 
            // tblSearch
            // 
            this.tblSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblSearch.ColumnCount = 7;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblSearch.Controls.Add(this.cboProcessName, 4, 0);
            this.tblSearch.Controls.Add(this.txtProcessCode, 5, 0);
            this.tblSearch.Controls.Add(this.label19, 3, 0);
            this.tblSearch.Controls.Add(this.label20, 0, 0);
            this.tblSearch.Controls.Add(this.txtProductCode, 2, 0);
            this.tblSearch.Controls.Add(this.cboProductName, 1, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.Size = new System.Drawing.Size(1460, 55);
            this.tblSearch.TabIndex = 4;
            // 
            // cboProcessName
            // 
            this.cboProcessName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProcessName.FormattingEnabled = true;
            this.cboProcessName.Location = new System.Drawing.Point(733, 16);
            this.cboProcessName.Name = "cboProcessName";
            this.cboProcessName.Size = new System.Drawing.Size(187, 23);
            this.cboProcessName.TabIndex = 35;
            this.cboProcessName.SelectedIndexChanged += new System.EventHandler(this.cboProcessName_SelectedIndexChanged);
            // 
            // txtProcessCode
            // 
            this.txtProcessCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessCode.Location = new System.Drawing.Point(927, 16);
            this.txtProcessCode.Name = "txtProcessCode";
            this.txtProcessCode.Size = new System.Drawing.Size(236, 23);
            this.txtProcessCode.TabIndex = 34;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label19.Location = new System.Drawing.Point(587, 1);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(139, 53);
            this.label19.TabIndex = 3;
            this.label19.Text = "공정";
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
            this.label20.Size = new System.Drawing.Size(139, 53);
            this.label20.TabIndex = 0;
            this.label20.Text = "품목";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductCode.Location = new System.Drawing.Point(344, 16);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(236, 23);
            this.txtProductCode.TabIndex = 1;
            // 
            // cboProductName
            // 
            this.cboProductName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProductName.FormattingEnabled = true;
            this.cboProductName.Location = new System.Drawing.Point(150, 17);
            this.cboProductName.Name = "cboProductName";
            this.cboProductName.Size = new System.Drawing.Size(187, 23);
            this.cboProductName.TabIndex = 2;
            this.cboProductName.SelectedIndexChanged += new System.EventHandler(this.cboProductName_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LightCoral;
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(270, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 32);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "💾저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(589, 15);
            this.label1.TabIndex = 43;
            this.label1.Text = "공정 / 검사항목 / 규격구분 / SPEC /  기준값 / 샘플크기 / 검사기기 / 규격구분 / 측정여부 / 비고 / 사용여부";
            this.label1.Visible = false;
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
            this.btnClearText.Location = new System.Drawing.Point(232, 0);
            this.btnClearText.Name = "btnClearText";
            this.btnClearText.Size = new System.Drawing.Size(32, 30);
            this.btnClearText.TabIndex = 67;
            this.btnClearText.Text = "⟳";
            this.btnClearText.UseVisualStyleBackColor = false;
            this.btnClearText.Click += new System.EventHandler(this.btnClearText_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(476, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 15);
            this.label4.TabIndex = 34;
            this.label4.Text = "검사항목규격설정 테이블";
            this.label4.Visible = false;
            // 
            // nmrSampleSize
            // 
            this.nmrSampleSize.Location = new System.Drawing.Point(270, 81);
            this.nmrSampleSize.Name = "nmrSampleSize";
            this.nmrSampleSize.Size = new System.Drawing.Size(102, 23);
            this.nmrSampleSize.TabIndex = 31;
            // 
            // cboInspectiontList
            // 
            this.cboInspectiontList.FormattingEnabled = true;
            this.cboInspectiontList.Location = new System.Drawing.Point(86, 15);
            this.cboInspectiontList.Name = "cboInspectiontList";
            this.cboInspectiontList.Size = new System.Drawing.Size(101, 23);
            this.cboInspectiontList.TabIndex = 33;
            this.cboInspectiontList.SelectedIndexChanged += new System.EventHandler(this.cboInspectiontList_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 15);
            this.label18.TabIndex = 32;
            this.label18.Text = " ✧  검사목록";
            // 
            // frmSpecifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 1038);
            this.Name = "frmSpecifications";
            this.Text = "품질규격 설정";
            this.Load += new System.EventHandler(this.frmSpecifications_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            this.pnlCondition.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlSubBottons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrUSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrLSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSL)).EndInit();
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSampleSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.DataGridView dgvQuality;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNewProcessCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNewProductCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInspectionItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInspectionCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown nmrSL;
        private System.Windows.Forms.NumericUpDown nmrLSL;
        private System.Windows.Forms.NumericUpDown nmrUSL;
        private System.Windows.Forms.ComboBox cboNewProcessName;
        private System.Windows.Forms.ComboBox cboNewProductName;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.ComboBox cboProcessName;
        private System.Windows.Forms.TextBox txtProcessCode;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.ComboBox cboProductName;
        protected System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        protected System.Windows.Forms.Button btnClearText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nmrSampleSize;
        private System.Windows.Forms.ComboBox cboInspectiontList;
        private System.Windows.Forms.Label label18;
    }
}
