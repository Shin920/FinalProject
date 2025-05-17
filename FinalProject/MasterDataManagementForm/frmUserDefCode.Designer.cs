
namespace FinalProject
{
    partial class frmUserDefCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserDefCode));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dgvUDCList = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUdtCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUdtName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTextClear = new System.Windows.Forms.Button();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUDName = new System.Windows.Forms.TextBox();
            this.txtUDCode = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            this.pnlDataGridView.SuspendLayout();
            this.pnlSubBottons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUDCList)).BeginInit();
            this.tblSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tblSearch);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(331, 40);
            this.lblTitle.Text = "사용자정의코드 대분류";
            // 
            // pnlCondition
            // 
            this.pnlCondition.Controls.Add(this.txtUdtName);
            this.pnlCondition.Controls.Add(this.label11);
            this.pnlCondition.Controls.Add(this.txtRemark);
            this.pnlCondition.Controls.Add(this.label10);
            this.pnlCondition.Controls.Add(this.txtUdtCode);
            this.pnlCondition.Controls.Add(this.label12);
            // 
            // lblSubTitle2
            // 
            this.lblSubTitle2.Text = "☷ 입력정보";
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Controls.Add(this.dgvUDCList);
            // 
            // pnlSubBottons
            // 
            this.pnlSubBottons.Controls.Add(this.btnTextClear);
            this.pnlSubBottons.Controls.Add(this.btnSave);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "plus.png");
            this.imageList1.Images.SetKeyName(1, "minus.png");
            // 
            // dgvUDCList
            // 
            this.dgvUDCList.BackgroundColor = System.Drawing.Color.White;
            this.dgvUDCList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUDCList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUDCList.Location = new System.Drawing.Point(0, 0);
            this.dgvUDCList.Name = "dgvUDCList";
            this.dgvUDCList.RowTemplate.Height = 23;
            this.dgvUDCList.Size = new System.Drawing.Size(1457, 688);
            this.dgvUDCList.TabIndex = 0;
            this.dgvUDCList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUDCList_CellClick);
            this.dgvUDCList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUDCList_CellDoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(727, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 15);
            this.label11.TabIndex = 23;
            this.label11.Text = " ✧  대분류명";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(381, 74);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(272, 23);
            this.txtRemark.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(306, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 15);
            this.label10.TabIndex = 21;
            this.label10.Text = " ✧  비고";
            // 
            // txtUdtCode
            // 
            this.txtUdtCode.Location = new System.Drawing.Point(381, 28);
            this.txtUdtCode.Name = "txtUdtCode";
            this.txtUdtCode.Size = new System.Drawing.Size(272, 23);
            this.txtUdtCode.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(270, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 15);
            this.label12.TabIndex = 22;
            this.label12.Text = " ✧  대분류코드";
            // 
            // txtUdtName
            // 
            this.txtUdtName.Location = new System.Drawing.Point(836, 28);
            this.txtUdtName.Name = "txtUdtName";
            this.txtUdtName.Size = new System.Drawing.Size(272, 23);
            this.txtUdtName.TabIndex = 24;
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
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "💾저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTextClear
            // 
            this.btnTextClear.BackColor = System.Drawing.Color.White;
            this.btnTextClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTextClear.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTextClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnTextClear.Location = new System.Drawing.Point(235, 2);
            this.btnTextClear.Name = "btnTextClear";
            this.btnTextClear.Size = new System.Drawing.Size(32, 30);
            this.btnTextClear.TabIndex = 67;
            this.btnTextClear.Text = "⟳";
            this.btnTextClear.UseVisualStyleBackColor = false;
            this.btnTextClear.Click += new System.EventHandler(this.btnTextClear_Click);
            // 
            // tblSearch
            // 
            this.tblSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblSearch.ColumnCount = 5;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.70569F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.73913F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.70569F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.73913F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.11036F));
            this.tblSearch.Controls.Add(this.label1, 2, 0);
            this.tblSearch.Controls.Add(this.label7, 0, 0);
            this.tblSearch.Controls.Add(this.txtUDName, 3, 0);
            this.tblSearch.Controls.Add(this.txtUDCode, 1, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.Size = new System.Drawing.Size(1457, 55);
            this.tblSearch.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(490, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 53);
            this.label1.TabIndex = 3;
            this.label1.Text = "대분류명";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(4, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 53);
            this.label7.TabIndex = 0;
            this.label7.Text = "대분류코드";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUDName
            // 
            this.txtUDName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUDName.Location = new System.Drawing.Point(660, 16);
            this.txtUDName.Name = "txtUDName";
            this.txtUDName.Size = new System.Drawing.Size(309, 23);
            this.txtUDName.TabIndex = 1;
            // 
            // txtUDCode
            // 
            this.txtUDCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUDCode.Location = new System.Drawing.Point(174, 16);
            this.txtUDCode.Name = "txtUDCode";
            this.txtUDCode.Size = new System.Drawing.Size(309, 23);
            this.txtUDCode.TabIndex = 4;
            // 
            // frmUserDefCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 1038);
            this.Name = "frmUserDefCode";
            this.Load += new System.EventHandler(this.frmUserDefCode_Load);
            this.panel1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            this.pnlCondition.PerformLayout();
            this.pnlDataGridView.ResumeLayout(false);
            this.pnlSubBottons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUDCList)).EndInit();
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dgvUDCList;
        protected System.Windows.Forms.TextBox txtUdtName;
        protected System.Windows.Forms.Label label11;
        protected System.Windows.Forms.TextBox txtRemark;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.TextBox txtUdtCode;
        protected System.Windows.Forms.Label label12;
        protected System.Windows.Forms.Button btnSave;
        protected System.Windows.Forms.Button btnTextClear;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUDName;
        private System.Windows.Forms.TextBox txtUDCode;
    }
}
