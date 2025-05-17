
namespace FinalProject
{
    partial class frmPackagingPaletteFinishing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPackagingPaletteFinishing));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucPeriodControl1 = new FinalProject.UcPeriodControl();
            this.btnFinishInstruction = new System.Windows.Forms.Button();
            this.dgvProductionList = new System.Windows.Forms.DataGridView();
            this.dgvPalleteList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnFinishPallete = new System.Windows.Forms.Button();
            this.btnModifyGrade = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblworkOrderNum = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductionList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalleteList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblworkOrderNum);
            this.panel1.Controls.SetChildIndex(this.lblTitle, 0);
            this.panel1.Controls.SetChildIndex(this.lblSubTitle, 0);
            this.panel1.Controls.SetChildIndex(this.pnlSearch, 0);
            this.panel1.Controls.SetChildIndex(this.splitContainer1, 0);
            this.panel1.Controls.SetChildIndex(this.pnlButtons, 0);
            this.panel1.Controls.SetChildIndex(this.lblworkOrderNum, 0);
            // 
            // lblSubTitle2
            // 
            this.lblSubTitle2.Size = new System.Drawing.Size(161, 31);
            this.lblSubTitle2.Text = "☷ 팔레트 목록";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tableLayoutPanel1);
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Size = new System.Drawing.Size(127, 35);
            this.lblSubTitle.Text = "☷ 조회내역";
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(252, 40);
            this.lblTitle.Text = "포장 팔레트 마감";
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dgvProductionList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.dgvPalleteList);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnModifyGrade);
            this.pnlButtons.Controls.Add(this.btnFinishPallete);
            this.pnlButtons.Controls.Add(this.btnFinishInstruction);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.3544F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.64561F));
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1457, 55);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(4, 1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(202, 53);
            this.label14.TabIndex = 1;
            this.label14.Text = "생산일자";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucPeriodControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(213, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1240, 47);
            this.panel2.TabIndex = 2;
            // 
            // ucPeriodControl1
            // 
            this.ucPeriodControl1.dtFrom = "2021-07-07";
            this.ucPeriodControl1.dtTo = "2021-07-26";
            this.ucPeriodControl1.Location = new System.Drawing.Point(3, 8);
            this.ucPeriodControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucPeriodControl1.Name = "ucPeriodControl1";
            this.ucPeriodControl1.Size = new System.Drawing.Size(310, 31);
            this.ucPeriodControl1.TabIndex = 0;
            // 
            // btnFinishInstruction
            // 
            this.btnFinishInstruction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnFinishInstruction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinishInstruction.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFinishInstruction.ForeColor = System.Drawing.Color.White;
            this.btnFinishInstruction.Location = new System.Drawing.Point(268, 1);
            this.btnFinishInstruction.Name = "btnFinishInstruction";
            this.btnFinishInstruction.Size = new System.Drawing.Size(101, 31);
            this.btnFinishInstruction.TabIndex = 35;
            this.btnFinishInstruction.Text = "작업지시 마감";
            this.btnFinishInstruction.UseVisualStyleBackColor = false;
            this.btnFinishInstruction.Click += new System.EventHandler(this.btnFinishInstruction_Click);
            // 
            // dgvProductionList
            // 
            this.dgvProductionList.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductionList.Location = new System.Drawing.Point(0, 0);
            this.dgvProductionList.Name = "dgvProductionList";
            this.dgvProductionList.RowTemplate.Height = 23;
            this.dgvProductionList.Size = new System.Drawing.Size(1457, 430);
            this.dgvProductionList.TabIndex = 0;
            this.dgvProductionList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductionList_CellDoubleClick);
            // 
            // dgvPalleteList
            // 
            this.dgvPalleteList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPalleteList.BackgroundColor = System.Drawing.Color.White;
            this.dgvPalleteList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPalleteList.Location = new System.Drawing.Point(3, 36);
            this.dgvPalleteList.Name = "dgvPalleteList";
            this.dgvPalleteList.RowTemplate.Height = 23;
            this.dgvPalleteList.Size = new System.Drawing.Size(1451, 390);
            this.dgvPalleteList.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(612, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "선택(체크박스)/ 생산일자/ 작업상태 / 작업지시번호 / 품목코드 / 품목명 / 작업장 / 투입수량/산출수량/생산수량";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 334);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(445, 15);
            this.label2.TabIndex = 33;
            this.label2.Text = "선택 / 팔렛트번호 / 등급 / 등급상세 코드 / 등급상세 명 / 수량 / ERP 업로드 여부";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "생산한 품목을 팔레트에 실어서 포장하는 작업";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(788, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(513, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "작업지시 마감: 작업지시를 선택후 마감버튼 클릭시 해당 작업지시에 포함된 모든 팔레트 마감.";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(804, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(262, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "팔레트 마감: 팔레ㅔ트 선택후 개별 팔레트 마감";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(788, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(533, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "등급상세 수정 : 포장 팔레트의 등급 상세ㅔ를 수정합니다.(마감 이전의 팔레트만 수정 가능합니다)";
            this.label6.Visible = false;
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
            // btnFinishPallete
            // 
            this.btnFinishPallete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnFinishPallete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinishPallete.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFinishPallete.ForeColor = System.Drawing.Color.White;
            this.btnFinishPallete.Location = new System.Drawing.Point(375, 1);
            this.btnFinishPallete.Name = "btnFinishPallete";
            this.btnFinishPallete.Size = new System.Drawing.Size(101, 31);
            this.btnFinishPallete.TabIndex = 83;
            this.btnFinishPallete.Text = "팔레트 마감";
            this.btnFinishPallete.UseVisualStyleBackColor = false;
            this.btnFinishPallete.Click += new System.EventHandler(this.btnFinishPallete_Click);
            // 
            // btnModifyGrade
            // 
            this.btnModifyGrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnModifyGrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifyGrade.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnModifyGrade.ForeColor = System.Drawing.Color.White;
            this.btnModifyGrade.Location = new System.Drawing.Point(482, 1);
            this.btnModifyGrade.Name = "btnModifyGrade";
            this.btnModifyGrade.Size = new System.Drawing.Size(101, 31);
            this.btnModifyGrade.TabIndex = 84;
            this.btnModifyGrade.Text = "등급상세 수정";
            this.btnModifyGrade.UseVisualStyleBackColor = false;
            this.btnModifyGrade.Click += new System.EventHandler(this.btnModifyGrade_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(506, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(400, 15);
            this.label7.TabIndex = 34;
            this.label7.Text = "pop에서 포장하면 포장실적 테이블에 작업지시번호에 팔레트가 할당된다";
            this.label7.Visible = false;
            // 
            // lblworkOrderNum
            // 
            this.lblworkOrderNum.AutoSize = true;
            this.lblworkOrderNum.Location = new System.Drawing.Point(572, 26);
            this.lblworkOrderNum.Name = "lblworkOrderNum";
            this.lblworkOrderNum.Size = new System.Drawing.Size(105, 15);
            this.lblworkOrderNum.TabIndex = 35;
            this.lblworkOrderNum.Text = "lblWorkOrderNum";
            this.lblworkOrderNum.Visible = false;
            // 
            // frmPackagingPaletteFinishing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 1038);
            this.Name = "frmPackagingPaletteFinishing";
            this.Text = "포장 팔레트 마감";
            this.Load += new System.EventHandler(this.frmPackagingPaletteFinishing_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductionList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalleteList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFinishInstruction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvProductionList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvPalleteList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnModifyGrade;
        private System.Windows.Forms.Button btnFinishPallete;
        private System.Windows.Forms.ImageList imageList1;
        private UcPeriodControl ucPeriodControl1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblworkOrderNum;
    }
}
