
namespace FinalProject
{
    partial class frmItemInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemInfo));
            this.dgvItemList = new System.Windows.Forms.DataGridView();
            this.nmcUdtPCS = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUdtItemCode = new System.Windows.Forms.TextBox();
            this.txtUdtItemName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nmcUdtLineCavity = new System.Windows.Forms.NumericUpDown();
            this.nmcUdtCavity = new System.Windows.Forms.NumericUpDown();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblCode = new System.Windows.Forms.Label();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.rdoItemKind = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.cboItemName = new System.Windows.Forms.ComboBox();
            this.txtSearchCode = new System.Windows.Forms.TextBox();
            this.rdoItemName = new System.Windows.Forms.RadioButton();
            this.cboItemKind = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            this.pnlDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcUdtPCS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcUdtLineCavity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcUdtCavity)).BeginInit();
            this.tblSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCode);
            this.panel1.Controls.SetChildIndex(this.lblTitle, 0);
            this.panel1.Controls.SetChildIndex(this.pnlSearch, 0);
            this.panel1.Controls.SetChildIndex(this.lblSubTitle2, 0);
            this.panel1.Controls.SetChildIndex(this.pnlCondition, 0);
            this.panel1.Controls.SetChildIndex(this.pnlButtons, 0);
            this.panel1.Controls.SetChildIndex(this.pnlDataGridView, 0);
            this.panel1.Controls.SetChildIndex(this.pnlSubBottons, 0);
            this.panel1.Controls.SetChildIndex(this.lblSubTitle, 0);
            this.panel1.Controls.SetChildIndex(this.lblCode, 0);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tblSearch);
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(147, 40);
            this.lblTitle.Text = "품목정보";
            // 
            // pnlCondition
            // 
            this.pnlCondition.Controls.Add(this.nmcUdtCavity);
            this.pnlCondition.Controls.Add(this.nmcUdtLineCavity);
            this.pnlCondition.Controls.Add(this.txtUdtItemName);
            this.pnlCondition.Controls.Add(this.label4);
            this.pnlCondition.Controls.Add(this.txtUdtItemCode);
            this.pnlCondition.Controls.Add(this.label2);
            this.pnlCondition.Controls.Add(this.nmcUdtPCS);
            this.pnlCondition.Controls.Add(this.label3);
            this.pnlCondition.Controls.Add(this.label10);
            this.pnlCondition.Controls.Add(this.label12);
            // 
            // lblSubTitle2
            // 
            this.lblSubTitle2.Text = "☷ 품목수정";
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Controls.Add(this.dgvItemList);
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Text = "☷ 품목정보";
            // 
            // dgvItemList
            // 
            this.dgvItemList.BackgroundColor = System.Drawing.Color.White;
            this.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItemList.Location = new System.Drawing.Point(0, 0);
            this.dgvItemList.Name = "dgvItemList";
            this.dgvItemList.RowTemplate.Height = 23;
            this.dgvItemList.Size = new System.Drawing.Size(1457, 688);
            this.dgvItemList.TabIndex = 0;
            this.dgvItemList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemList_CellClick);
            this.dgvItemList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemList_CellDoubleClick);
            // 
            // nmcUdtPCS
            // 
            this.nmcUdtPCS.Location = new System.Drawing.Point(1073, 82);
            this.nmcUdtPCS.Name = "nmcUdtPCS";
            this.nmcUdtPCS.Size = new System.Drawing.Size(272, 23);
            this.nmcUdtPCS.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(950, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = " ✧  Shot당PCS수";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(488, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 15);
            this.label10.TabIndex = 25;
            this.label10.Text = " ✧  성형줄당캐비티수";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(43, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 15);
            this.label12.TabIndex = 26;
            this.label12.Text = " ✧  캐비티수";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = " ✧  품목코드";
            // 
            // txtUdtItemCode
            // 
            this.txtUdtItemCode.Location = new System.Drawing.Point(145, 34);
            this.txtUdtItemCode.Name = "txtUdtItemCode";
            this.txtUdtItemCode.ReadOnly = true;
            this.txtUdtItemCode.Size = new System.Drawing.Size(272, 23);
            this.txtUdtItemCode.TabIndex = 30;
            // 
            // txtUdtItemName
            // 
            this.txtUdtItemName.Location = new System.Drawing.Point(638, 34);
            this.txtUdtItemName.Name = "txtUdtItemName";
            this.txtUdtItemName.ReadOnly = true;
            this.txtUdtItemName.Size = new System.Drawing.Size(272, 23);
            this.txtUdtItemName.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(488, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = " ✧  품목명";
            // 
            // nmcUdtLineCavity
            // 
            this.nmcUdtLineCavity.Location = new System.Drawing.Point(638, 82);
            this.nmcUdtLineCavity.Name = "nmcUdtLineCavity";
            this.nmcUdtLineCavity.Size = new System.Drawing.Size(272, 23);
            this.nmcUdtLineCavity.TabIndex = 33;
            // 
            // nmcUdtCavity
            // 
            this.nmcUdtCavity.Location = new System.Drawing.Point(145, 82);
            this.nmcUdtCavity.Name = "nmcUdtCavity";
            this.nmcUdtCavity.Size = new System.Drawing.Size(272, 23);
            this.nmcUdtCavity.TabIndex = 34;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "plus.png");
            this.imageList1.Images.SetKeyName(1, "minus.png");
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(219, 26);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(39, 15);
            this.lblCode.TabIndex = 33;
            this.lblCode.Text = "label5";
            this.lblCode.Visible = false;
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
            this.tblSearch.Controls.Add(this.rdoItemKind, 4, 0);
            this.tblSearch.Controls.Add(this.label13, 2, 0);
            this.tblSearch.Controls.Add(this.cboItemName, 1, 0);
            this.tblSearch.Controls.Add(this.txtSearchCode, 3, 0);
            this.tblSearch.Controls.Add(this.rdoItemName, 0, 0);
            this.tblSearch.Controls.Add(this.cboItemKind, 5, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblSearch.Size = new System.Drawing.Size(1457, 55);
            this.tblSearch.TabIndex = 6;
            // 
            // rdoItemKind
            // 
            this.rdoItemKind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoItemKind.AutoSize = true;
            this.rdoItemKind.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rdoItemKind.Location = new System.Drawing.Point(974, 4);
            this.rdoItemKind.Name = "rdoItemKind";
            this.rdoItemKind.Size = new System.Drawing.Size(163, 47);
            this.rdoItemKind.TabIndex = 36;
            this.rdoItemKind.TabStop = true;
            this.rdoItemKind.Text = "품목유형";
            this.rdoItemKind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoItemKind.UseVisualStyleBackColor = false;
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
            this.label13.Text = "품목코드";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboItemName
            // 
            this.cboItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboItemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemName.FormattingEnabled = true;
            this.cboItemName.Location = new System.Drawing.Point(174, 16);
            this.cboItemName.Name = "cboItemName";
            this.cboItemName.Size = new System.Drawing.Size(308, 23);
            this.cboItemName.TabIndex = 2;
            // 
            // txtSearchCode
            // 
            this.txtSearchCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchCode.Location = new System.Drawing.Point(659, 16);
            this.txtSearchCode.Name = "txtSearchCode";
            this.txtSearchCode.Size = new System.Drawing.Size(308, 23);
            this.txtSearchCode.TabIndex = 1;
            // 
            // rdoItemName
            // 
            this.rdoItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoItemName.AutoSize = true;
            this.rdoItemName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rdoItemName.Location = new System.Drawing.Point(4, 4);
            this.rdoItemName.Name = "rdoItemName";
            this.rdoItemName.Size = new System.Drawing.Size(163, 47);
            this.rdoItemName.TabIndex = 35;
            this.rdoItemName.TabStop = true;
            this.rdoItemName.Text = "품목명";
            this.rdoItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoItemName.UseVisualStyleBackColor = false;
            // 
            // cboItemKind
            // 
            this.cboItemKind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboItemKind.FormattingEnabled = true;
            this.cboItemKind.Location = new System.Drawing.Point(1144, 17);
            this.cboItemKind.Name = "cboItemKind";
            this.cboItemKind.Size = new System.Drawing.Size(309, 23);
            this.cboItemKind.TabIndex = 37;
            // 
            // frmItemInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 1038);
            this.Name = "frmItemInfo";
            this.Load += new System.EventHandler(this.frmItemInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            this.pnlCondition.PerformLayout();
            this.pnlDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcUdtPCS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcUdtLineCavity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcUdtCavity)).EndInit();
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvItemList;
        private System.Windows.Forms.NumericUpDown nmcUdtCavity;
        private System.Windows.Forms.NumericUpDown nmcUdtLineCavity;
        protected System.Windows.Forms.TextBox txtUdtItemName;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox txtUdtItemCode;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nmcUdtPCS;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.Label label12;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblCode;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.RadioButton rdoItemKind;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboItemName;
        private System.Windows.Forms.TextBox txtSearchCode;
        private System.Windows.Forms.RadioButton rdoItemName;
        private System.Windows.Forms.ComboBox cboItemKind;
    }
}
