
namespace FinalProject
{
    partial class frmDefectiveDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDefectiveDetail));
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNewCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNewDetailCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNewDetailName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.dgvGroup = new System.Windows.Forms.DataGridView();
            this.dgvDetailGroup = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboSearchType = new System.Windows.Forms.ComboBox();
            this.txtSearchCode = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnClearText = new System.Windows.Forms.Button();
            this.lblDFCode = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            this.pnlSubBottons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailGroup)).BeginInit();
            this.tblSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDFCode);
            this.panel1.Controls.SetChildIndex(this.lblTitle, 0);
            this.panel1.Controls.SetChildIndex(this.pnlSearch, 0);
            this.panel1.Controls.SetChildIndex(this.splitContainer1, 0);
            this.panel1.Controls.SetChildIndex(this.lblDFCode, 0);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.dgvGroup);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetailGroup);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tblSearch);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(265, 40);
            this.lblTitle.Text = "불량현상 상세분류";
            // 
            // pnlCondition
            // 
            this.pnlCondition.Controls.Add(this.label10);
            this.pnlCondition.Controls.Add(this.txtNote);
            this.pnlCondition.Controls.Add(this.label9);
            this.pnlCondition.Controls.Add(this.txtNewDetailName);
            this.pnlCondition.Controls.Add(this.label8);
            this.pnlCondition.Controls.Add(this.txtNewDetailCode);
            this.pnlCondition.Controls.Add(this.label6);
            this.pnlCondition.Controls.Add(this.txtNewCode);
            // 
            // pnlSubBottons
            // 
            this.pnlSubBottons.Controls.Add(this.btnClearText);
            this.pnlSubBottons.Controls.Add(this.btnSave);
            // 
            // label2
            // 
            this.label2.Size = new System.Drawing.Size(173, 32);
            this.label2.Text = "☷ 불량현상 설정";
            // 
            // lblSubTitle1
            // 
            this.lblSubTitle1.Size = new System.Drawing.Size(196, 31);
            this.lblSubTitle1.Text = "☷ 불량현상 대분류";
            // 
            // lblSubTitle2
            // 
            this.lblSubTitle2.Size = new System.Drawing.Size(226, 31);
            this.lblSubTitle2.Text = "☷ 불량현상 상세분류";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(68, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(752, 45);
            this.label3.TabIndex = 34;
            this.label3.Text = "콤보박스에 대분류, 상세분류 선택할수 있게 하고 선택한 쪽의 코드명이나 코드명을 입력하면  상세내역에 해당하는 대분류 로우가 셀렉트 되게 하거나 " +
    "그거만 남게. 근데 셀렉트로 하는게 괜찮을듯. 그리고 상세분류로 검색했으면 해당되는 대분류에 해당되는 로우가 선택되고 그걸 더블클릭한 효과처럼 " +
    "오른족에 상세그리드에 그 코드의 상세내역나오게.";
            this.label3.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = " ✧  대분류코드";
            // 
            // txtNewCode
            // 
            this.txtNewCode.Location = new System.Drawing.Point(159, 12);
            this.txtNewCode.Name = "txtNewCode";
            this.txtNewCode.ReadOnly = true;
            this.txtNewCode.Size = new System.Drawing.Size(194, 23);
            this.txtNewCode.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = " ✧  상세분류코드";
            // 
            // txtNewDetailCode
            // 
            this.txtNewDetailCode.Location = new System.Drawing.Point(159, 50);
            this.txtNewDetailCode.Name = "txtNewDetailCode";
            this.txtNewDetailCode.ReadOnly = true;
            this.txtNewDetailCode.Size = new System.Drawing.Size(194, 23);
            this.txtNewDetailCode.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 15);
            this.label9.TabIndex = 11;
            this.label9.Text = " ✧  상세분류명";
            // 
            // txtNewDetailName
            // 
            this.txtNewDetailName.Location = new System.Drawing.Point(159, 88);
            this.txtNewDetailName.Name = "txtNewDetailName";
            this.txtNewDetailName.Size = new System.Drawing.Size(194, 23);
            this.txtNewDetailName.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(406, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 15);
            this.label10.TabIndex = 13;
            this.label10.Text = " ✧  비고";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(465, 15);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(194, 99);
            this.txtNote.TabIndex = 12;
            // 
            // dgvGroup
            // 
            this.dgvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGroup.BackgroundColor = System.Drawing.Color.White;
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroup.Location = new System.Drawing.Point(0, 35);
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.RowTemplate.Height = 23;
            this.dgvGroup.Size = new System.Drawing.Size(483, 856);
            this.dgvGroup.TabIndex = 24;
            this.dgvGroup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroup_CellDoubleClick);
            // 
            // dgvDetailGroup
            // 
            this.dgvDetailGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetailGroup.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetailGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailGroup.Location = new System.Drawing.Point(3, 35);
            this.dgvDetailGroup.Name = "dgvDetailGroup";
            this.dgvDetailGroup.RowTemplate.Height = 23;
            this.dgvDetailGroup.Size = new System.Drawing.Size(964, 682);
            this.dgvDetailGroup.TabIndex = 41;
            this.dgvDetailGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetailGroup_CellClick);
            this.dgvDetailGroup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetailGroup_CellDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(141, 367);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(328, 15);
            this.label7.TabIndex = 25;
            this.label7.Text = "불량현상대분류코드, 불량현상대분류명, 입력일자, 사용여부";
            this.label7.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(272, 331);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(403, 15);
            this.label11.TabIndex = 42;
            this.label11.Text = "불량현상상세분류코드, 불량현상상세분류명, 입력일자, 사용여부,변경버튼";
            this.label11.Visible = false;
            // 
            // tblSearch
            // 
            this.tblSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblSearch.ColumnCount = 6;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.66667F));
            this.tblSearch.Controls.Add(this.txtSearchName, 5, 0);
            this.tblSearch.Controls.Add(this.label12, 4, 0);
            this.tblSearch.Controls.Add(this.label13, 2, 0);
            this.tblSearch.Controls.Add(this.label14, 0, 0);
            this.tblSearch.Controls.Add(this.cboSearchType, 1, 0);
            this.tblSearch.Controls.Add(this.txtSearchCode, 3, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblSearch.Size = new System.Drawing.Size(1460, 55);
            this.tblSearch.TabIndex = 3;
            // 
            // txtSearchName
            // 
            this.txtSearchName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchName.Location = new System.Drawing.Point(1144, 16);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(312, 23);
            this.txtSearchName.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(974, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(163, 53);
            this.label12.TabIndex = 4;
            this.label12.Text = "분류명";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(489, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(163, 53);
            this.label13.TabIndex = 3;
            this.label13.Text = "코드번호";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.label14.Size = new System.Drawing.Size(163, 53);
            this.label14.TabIndex = 0;
            this.label14.Text = "조회조건";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboSearchType
            // 
            this.cboSearchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSearchType.FormattingEnabled = true;
            this.cboSearchType.Location = new System.Drawing.Point(174, 17);
            this.cboSearchType.Name = "cboSearchType";
            this.cboSearchType.Size = new System.Drawing.Size(308, 23);
            this.cboSearchType.TabIndex = 2;
            // 
            // txtSearchCode
            // 
            this.txtSearchCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchCode.Location = new System.Drawing.Point(659, 16);
            this.txtSearchCode.Name = "txtSearchCode";
            this.txtSearchCode.Size = new System.Drawing.Size(308, 23);
            this.txtSearchCode.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LightCoral;
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(272, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 32);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "💾저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnClearText.Location = new System.Drawing.Point(234, 2);
            this.btnClearText.Name = "btnClearText";
            this.btnClearText.Size = new System.Drawing.Size(32, 30);
            this.btnClearText.TabIndex = 63;
            this.btnClearText.Text = "⟳";
            this.btnClearText.UseVisualStyleBackColor = false;
            this.btnClearText.Click += new System.EventHandler(this.btnClearText_Click);
            // 
            // lblDFCode
            // 
            this.lblDFCode.BackColor = System.Drawing.Color.Black;
            this.lblDFCode.Location = new System.Drawing.Point(461, 47);
            this.lblDFCode.Name = "lblDFCode";
            this.lblDFCode.Size = new System.Drawing.Size(63, 15);
            this.lblDFCode.TabIndex = 34;
            this.lblDFCode.Visible = false;
            // 
            // frmDefectiveDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 1038);
            this.Name = "frmDefectiveDetail";
            this.Text = "불량현상 상세분류";
            this.Load += new System.EventHandler(this.frmDefectiveDetail_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            this.pnlCondition.PerformLayout();
            this.pnlSubBottons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailGroup)).EndInit();
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNewDetailName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNewDetailCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNewCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvGroup;
        private System.Windows.Forms.DataGridView dgvDetailGroup;
        private System.Windows.Forms.Label label11;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboSearchType;
        private System.Windows.Forms.TextBox txtSearchCode;
        protected System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ImageList imageList1;
        protected System.Windows.Forms.Button btnClearText;
        private System.Windows.Forms.Label lblDFCode;
    }
}
