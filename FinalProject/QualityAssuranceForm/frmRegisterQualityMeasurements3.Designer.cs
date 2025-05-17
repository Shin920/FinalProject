
namespace FinalProject
{
    partial class frmRegisterQualityMeasurements3
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
            this.dgvInstrutionList = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCheckList = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCheckResult = new System.Windows.Forms.DataGridView();
            this.btnDelCheck = new System.Windows.Forms.Button();
            this.btnAddCheck = new System.Windows.Forms.Button();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucPeriodControl1 = new FinalProject.UcPeriodControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnWorkPlaceList = new System.Windows.Forms.Button();
            this.txtWorkPlaceName = new System.Windows.Forms.TextBox();
            this.txtWorkPlaceCode = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtProcessCode = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.btnProcessList = new System.Windows.Forms.Button();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblWcCode = new System.Windows.Forms.Label();
            this.lblWorkOrderNum = new System.Windows.Forms.Label();
            this.lblProcessCode = new System.Windows.Forms.Label();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstrutionList)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckResult)).BeginInit();
            this.tblSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblItemName);
            this.panel1.Controls.Add(this.lblWcCode);
            this.panel1.Controls.Add(this.lblWorkOrderNum);
            this.panel1.Controls.Add(this.lblProcessCode);
            this.panel1.Controls.Add(this.lblItemCode);
            this.panel1.Controls.SetChildIndex(this.lblTitle, 0);
            this.panel1.Controls.SetChildIndex(this.pnlSearch, 0);
            this.panel1.Controls.SetChildIndex(this.splitContainer1, 0);
            this.panel1.Controls.SetChildIndex(this.lblItemCode, 0);
            this.panel1.Controls.SetChildIndex(this.lblProcessCode, 0);
            this.panel1.Controls.SetChildIndex(this.lblWorkOrderNum, 0);
            this.panel1.Controls.SetChildIndex(this.lblWcCode, 0);
            this.panel1.Controls.SetChildIndex(this.lblItemName, 0);
            // 
            // lblSubTitle2
            // 
            this.lblSubTitle2.Size = new System.Drawing.Size(127, 32);
            this.lblSubTitle2.Text = "☷ 측정이력";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tblSearch);
            // 
            // lblSubTitle1
            // 
            this.lblSubTitle1.Size = new System.Drawing.Size(130, 31);
            this.lblSubTitle1.Text = "☷ 작업지시";
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(235, 40);
            this.lblTitle.Text = "품질측정값 등록";
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvInstrutionList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnDelCheck);
            this.pnlButtons.Controls.Add(this.btnAddCheck);
            // 
            // dgvInstrutionList
            // 
            this.dgvInstrutionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInstrutionList.BackgroundColor = System.Drawing.Color.White;
            this.dgvInstrutionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstrutionList.Location = new System.Drawing.Point(3, 42);
            this.dgvInstrutionList.Name = "dgvInstrutionList";
            this.dgvInstrutionList.RowTemplate.Height = 23;
            this.dgvInstrutionList.Size = new System.Drawing.Size(480, 844);
            this.dgvInstrutionList.TabIndex = 24;
            this.dgvInstrutionList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInstrutionList_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgvCheckList);
            this.groupBox1.Location = new System.Drawing.Point(3, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 851);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "검사항목";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 112);
            this.label2.TabIndex = 25;
            this.label2.Text = "측정항목 1~27(기준값)   / 화면설계서상의 컬럼은 측정항목명/기준값";
            this.label2.Visible = false;
            // 
            // dgvCheckList
            // 
            this.dgvCheckList.BackgroundColor = System.Drawing.Color.White;
            this.dgvCheckList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCheckList.Location = new System.Drawing.Point(3, 19);
            this.dgvCheckList.Name = "dgvCheckList";
            this.dgvCheckList.RowTemplate.Height = 23;
            this.dgvCheckList.Size = new System.Drawing.Size(325, 829);
            this.dgvCheckList.TabIndex = 0;
            this.dgvCheckList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCheckList_CellDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dgvCheckResult);
            this.groupBox2.Location = new System.Drawing.Point(344, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(626, 850);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "측정값";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(56, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 112);
            this.label4.TabIndex = 27;
            this.label4.Text = "4조꺼에는그리드뷰 3개에 다 조건순번이라는 컬럼이 맨앞에 있더라. 고민해보기 ";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(193, 369);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 112);
            this.label3.TabIndex = 26;
            this.label3.Text = "측정값 1~27 입력 / 화면설계서상의 컬럼은 측정일시/품목코드/품목명/편차/1/2/3/4/...";
            this.label3.Visible = false;
            // 
            // dgvCheckResult
            // 
            this.dgvCheckResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCheckResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvCheckResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckResult.Location = new System.Drawing.Point(6, 22);
            this.dgvCheckResult.Name = "dgvCheckResult";
            this.dgvCheckResult.RowTemplate.Height = 23;
            this.dgvCheckResult.Size = new System.Drawing.Size(614, 823);
            this.dgvCheckResult.TabIndex = 1;
            // 
            // btnDelCheck
            // 
            this.btnDelCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnDelCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelCheck.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDelCheck.ForeColor = System.Drawing.Color.White;
            this.btnDelCheck.Location = new System.Drawing.Point(460, 2);
            this.btnDelCheck.Name = "btnDelCheck";
            this.btnDelCheck.Size = new System.Drawing.Size(125, 28);
            this.btnDelCheck.TabIndex = 94;
            this.btnDelCheck.Text = "측정회차 삭제";
            this.btnDelCheck.UseVisualStyleBackColor = false;
            this.btnDelCheck.Click += new System.EventHandler(this.btnDelCheck_Click);
            // 
            // btnAddCheck
            // 
            this.btnAddCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnAddCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCheck.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAddCheck.ForeColor = System.Drawing.Color.White;
            this.btnAddCheck.Location = new System.Drawing.Point(329, 2);
            this.btnAddCheck.Name = "btnAddCheck";
            this.btnAddCheck.Size = new System.Drawing.Size(125, 28);
            this.btnAddCheck.TabIndex = 91;
            this.btnAddCheck.Text = "측정회차 추가";
            this.btnAddCheck.UseVisualStyleBackColor = false;
            this.btnAddCheck.Click += new System.EventHandler(this.btnAddCheck_Click);
            // 
            // tblSearch
            // 
            this.tblSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblSearch.ColumnCount = 8;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.534619F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.66288F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.32917F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.87453F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.63118F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.973081F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tblSearch.Controls.Add(this.panel2, 0, 0);
            this.tblSearch.Controls.Add(this.panel4, 7, 0);
            this.tblSearch.Controls.Add(this.txtWorkPlaceCode, 6, 0);
            this.tblSearch.Controls.Add(this.label13, 2, 0);
            this.tblSearch.Controls.Add(this.label12, 5, 0);
            this.tblSearch.Controls.Add(this.label14, 0, 0);
            this.tblSearch.Controls.Add(this.txtProcessCode, 3, 0);
            this.tblSearch.Controls.Add(this.panel3, 4, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblSearch.Size = new System.Drawing.Size(1460, 55);
            this.tblSearch.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucPeriodControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(101, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(363, 47);
            this.panel2.TabIndex = 40;
            // 
            // ucPeriodControl1
            // 
            this.ucPeriodControl1.dtFrom = "2021-07-13";
            this.ucPeriodControl1.dtTo = "2021-07-26";
            this.ucPeriodControl1.Location = new System.Drawing.Point(3, 9);
            this.ucPeriodControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucPeriodControl1.Name = "ucPeriodControl1";
            this.ucPeriodControl1.Size = new System.Drawing.Size(307, 28);
            this.ucPeriodControl1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnWorkPlaceList);
            this.panel4.Controls.Add(this.txtWorkPlaceName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1190, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(266, 47);
            this.panel4.TabIndex = 39;
            // 
            // btnWorkPlaceList
            // 
            this.btnWorkPlaceList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWorkPlaceList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnWorkPlaceList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkPlaceList.ForeColor = System.Drawing.Color.White;
            this.btnWorkPlaceList.Location = new System.Drawing.Point(218, 13);
            this.btnWorkPlaceList.Name = "btnWorkPlaceList";
            this.btnWorkPlaceList.Size = new System.Drawing.Size(40, 24);
            this.btnWorkPlaceList.TabIndex = 37;
            this.btnWorkPlaceList.Text = "...";
            this.btnWorkPlaceList.UseVisualStyleBackColor = false;
            this.btnWorkPlaceList.Click += new System.EventHandler(this.btnWorkPlaceList_Click);
            // 
            // txtWorkPlaceName
            // 
            this.txtWorkPlaceName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkPlaceName.Location = new System.Drawing.Point(3, 13);
            this.txtWorkPlaceName.Name = "txtWorkPlaceName";
            this.txtWorkPlaceName.Size = new System.Drawing.Size(209, 23);
            this.txtWorkPlaceName.TabIndex = 2;
            // 
            // txtWorkPlaceCode
            // 
            this.txtWorkPlaceCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkPlaceCode.Location = new System.Drawing.Point(1016, 16);
            this.txtWorkPlaceCode.Name = "txtWorkPlaceCode";
            this.txtWorkPlaceCode.Size = new System.Drawing.Size(167, 23);
            this.txtWorkPlaceCode.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(471, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 53);
            this.label13.TabIndex = 3;
            this.label13.Text = "공정";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(925, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 53);
            this.label12.TabIndex = 4;
            this.label12.Text = "작업장";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Location = new System.Drawing.Point(4, 1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 53);
            this.label14.TabIndex = 0;
            this.label14.Text = "생산일자";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtProcessCode
            // 
            this.txtProcessCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessCode.Location = new System.Drawing.Point(576, 16);
            this.txtProcessCode.Name = "txtProcessCode";
            this.txtProcessCode.Size = new System.Drawing.Size(154, 23);
            this.txtProcessCode.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtProcessName);
            this.panel3.Controls.Add(this.btnProcessList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(737, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(181, 47);
            this.panel3.TabIndex = 38;
            // 
            // txtProcessName
            // 
            this.txtProcessName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessName.Location = new System.Drawing.Point(3, 13);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(124, 23);
            this.txtProcessName.TabIndex = 2;
            // 
            // btnProcessList
            // 
            this.btnProcessList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnProcessList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessList.ForeColor = System.Drawing.Color.White;
            this.btnProcessList.Location = new System.Drawing.Point(134, 13);
            this.btnProcessList.Name = "btnProcessList";
            this.btnProcessList.Size = new System.Drawing.Size(40, 24);
            this.btnProcessList.TabIndex = 36;
            this.btnProcessList.Text = "...";
            this.btnProcessList.UseVisualStyleBackColor = false;
            this.btnProcessList.Click += new System.EventHandler(this.btnProcessList_Click);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(921, 36);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(39, 15);
            this.lblItemName.TabIndex = 43;
            this.lblItemName.Text = "label7";
            this.lblItemName.Visible = false;
            // 
            // lblWcCode
            // 
            this.lblWcCode.AutoSize = true;
            this.lblWcCode.Location = new System.Drawing.Point(863, 36);
            this.lblWcCode.Name = "lblWcCode";
            this.lblWcCode.Size = new System.Drawing.Size(39, 15);
            this.lblWcCode.TabIndex = 42;
            this.lblWcCode.Text = "label7";
            this.lblWcCode.Visible = false;
            // 
            // lblWorkOrderNum
            // 
            this.lblWorkOrderNum.AutoSize = true;
            this.lblWorkOrderNum.Location = new System.Drawing.Point(796, 36);
            this.lblWorkOrderNum.Name = "lblWorkOrderNum";
            this.lblWorkOrderNum.Size = new System.Drawing.Size(39, 15);
            this.lblWorkOrderNum.TabIndex = 41;
            this.lblWorkOrderNum.Text = "label7";
            this.lblWorkOrderNum.Visible = false;
            // 
            // lblProcessCode
            // 
            this.lblProcessCode.AutoSize = true;
            this.lblProcessCode.Location = new System.Drawing.Point(719, 36);
            this.lblProcessCode.Name = "lblProcessCode";
            this.lblProcessCode.Size = new System.Drawing.Size(39, 15);
            this.lblProcessCode.TabIndex = 40;
            this.lblProcessCode.Text = "label6";
            this.lblProcessCode.Visible = false;
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Location = new System.Drawing.Point(661, 36);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(39, 15);
            this.lblItemCode.TabIndex = 39;
            this.lblItemCode.Text = "label5";
            this.lblItemCode.Visible = false;
            // 
            // frmRegisterQualityMeasurements3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 1038);
            this.Name = "frmRegisterQualityMeasurements3";
            this.Text = "품질측정값 등록";
            this.Load += new System.EventHandler(this.frmRegisterQualityMeasurements3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstrutionList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckResult)).EndInit();
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInstrutionList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCheckList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvCheckResult;
        private System.Windows.Forms.Button btnDelCheck;
        private System.Windows.Forms.Button btnAddCheck;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnWorkPlaceList;
        private System.Windows.Forms.TextBox txtWorkPlaceName;
        private System.Windows.Forms.TextBox txtWorkPlaceCode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtProcessCode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.Button btnProcessList;
        private System.Windows.Forms.Panel panel2;
        private UcPeriodControl ucPeriodControl1;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblWcCode;
        private System.Windows.Forms.Label lblWorkOrderNum;
        private System.Windows.Forms.Label lblProcessCode;
        private System.Windows.Forms.Label lblItemCode;
    }
}
