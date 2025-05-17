
namespace FinalProject
{
    partial class frmDefectiveImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDefectiveImage));
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtWorkPlaceName = new System.Windows.Forms.TextBox();
            this.btnWorkPlaceList = new System.Windows.Forms.Button();
            this.txtWorkPlaceCode = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.btnProcessList = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucPeriodControl1 = new FinalProject.UcPeriodControl();
            this.dgvInstructionList = new System.Windows.Forms.DataGridView();
            this.dgvDetailInstructionList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tblSearch.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstructionList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailInstructionList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSubTitle2
            // 
            this.lblSubTitle2.Size = new System.Drawing.Size(130, 31);
            this.lblSubTitle2.Text = "☷ 상세내역";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tblSearch);
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Size = new System.Drawing.Size(173, 35);
            this.lblSubTitle.Text = "☷ 작업지시목록";
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(231, 40);
            this.lblTitle.Text = "불량이미지 등록";
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dgvInstructionList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetailInstructionList);
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
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 294F));
            this.tblSearch.Controls.Add(this.panel4, 7, 0);
            this.tblSearch.Controls.Add(this.txtWorkPlaceCode, 6, 0);
            this.tblSearch.Controls.Add(this.label13, 2, 0);
            this.tblSearch.Controls.Add(this.label12, 5, 0);
            this.tblSearch.Controls.Add(this.label14, 0, 0);
            this.tblSearch.Controls.Add(this.txtItemCode, 3, 0);
            this.tblSearch.Controls.Add(this.panel3, 4, 0);
            this.tblSearch.Controls.Add(this.panel2, 1, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblSearch.Size = new System.Drawing.Size(1457, 55);
            this.tblSearch.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtWorkPlaceName);
            this.panel4.Controls.Add(this.btnWorkPlaceList);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1162, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(291, 47);
            this.panel4.TabIndex = 39;
            // 
            // txtWorkPlaceName
            // 
            this.txtWorkPlaceName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkPlaceName.Location = new System.Drawing.Point(3, 13);
            this.txtWorkPlaceName.Name = "txtWorkPlaceName";
            this.txtWorkPlaceName.Size = new System.Drawing.Size(234, 23);
            this.txtWorkPlaceName.TabIndex = 2;
            // 
            // btnWorkPlaceList
            // 
            this.btnWorkPlaceList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWorkPlaceList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnWorkPlaceList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkPlaceList.ForeColor = System.Drawing.Color.White;
            this.btnWorkPlaceList.Location = new System.Drawing.Point(242, 12);
            this.btnWorkPlaceList.Name = "btnWorkPlaceList";
            this.btnWorkPlaceList.Size = new System.Drawing.Size(46, 26);
            this.btnWorkPlaceList.TabIndex = 36;
            this.btnWorkPlaceList.Text = "...";
            this.btnWorkPlaceList.UseVisualStyleBackColor = false;
            this.btnWorkPlaceList.Click += new System.EventHandler(this.btnWorkPlaceList_Click);
            // 
            // txtWorkPlaceCode
            // 
            this.txtWorkPlaceCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkPlaceCode.Location = new System.Drawing.Point(988, 16);
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
            this.label13.Location = new System.Drawing.Point(458, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 53);
            this.label13.TabIndex = 3;
            this.label13.Text = "품목";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(899, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 53);
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
            this.label14.Size = new System.Drawing.Size(87, 53);
            this.label14.TabIndex = 0;
            this.label14.Text = "작업지시일자";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemCode.Location = new System.Drawing.Point(560, 16);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(149, 23);
            this.txtItemCode.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtItemName);
            this.panel3.Controls.Add(this.btnProcessList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(716, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(176, 47);
            this.panel3.TabIndex = 38;
            // 
            // txtItemName
            // 
            this.txtItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemName.Location = new System.Drawing.Point(3, 13);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(119, 23);
            this.txtItemName.TabIndex = 2;
            // 
            // btnProcessList
            // 
            this.btnProcessList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(167)))));
            this.btnProcessList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessList.ForeColor = System.Drawing.Color.White;
            this.btnProcessList.Location = new System.Drawing.Point(128, 13);
            this.btnProcessList.Name = "btnProcessList";
            this.btnProcessList.Size = new System.Drawing.Size(45, 25);
            this.btnProcessList.TabIndex = 36;
            this.btnProcessList.Text = "...";
            this.btnProcessList.UseVisualStyleBackColor = false;
            this.btnProcessList.Click += new System.EventHandler(this.btnProcessList_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucPeriodControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(98, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(353, 47);
            this.panel2.TabIndex = 35;
            // 
            // ucPeriodControl1
            // 
            this.ucPeriodControl1.dtFrom = "2021-07-13";
            this.ucPeriodControl1.dtTo = "2021-07-26";
            this.ucPeriodControl1.Location = new System.Drawing.Point(3, 7);
            this.ucPeriodControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucPeriodControl1.Name = "ucPeriodControl1";
            this.ucPeriodControl1.Size = new System.Drawing.Size(308, 31);
            this.ucPeriodControl1.TabIndex = 0;
            // 
            // dgvInstructionList
            // 
            this.dgvInstructionList.BackgroundColor = System.Drawing.Color.White;
            this.dgvInstructionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstructionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInstructionList.Location = new System.Drawing.Point(0, 0);
            this.dgvInstructionList.Name = "dgvInstructionList";
            this.dgvInstructionList.RowTemplate.Height = 23;
            this.dgvInstructionList.Size = new System.Drawing.Size(1457, 430);
            this.dgvInstructionList.TabIndex = 0;
            this.dgvInstructionList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInstructionList_CellDoubleClick);
            // 
            // dgvDetailInstructionList
            // 
            this.dgvDetailInstructionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetailInstructionList.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetailInstructionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailInstructionList.Location = new System.Drawing.Point(0, 36);
            this.dgvDetailInstructionList.Name = "dgvDetailInstructionList";
            this.dgvDetailInstructionList.RowTemplate.Height = 23;
            this.dgvDetailInstructionList.Size = new System.Drawing.Size(1457, 393);
            this.dgvDetailInstructionList.TabIndex = 32;
            this.dgvDetailInstructionList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetailInstructionList_CellDoubleClick);
            this.dgvDetailInstructionList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetailInstructionList_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1142, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "이 추가는 이미지 추가 생각하고있고 어떤 생산일에 어떤 품목의 불량이 발생했을때 그 사진을 찍어 올리는것 같다. 불량현상 분류한거에 대해 그걸 선" +
    "택하고 이미지 내용 입력하고 이미지 추가 하는 팝업 필요할듯";
            this.label1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(495, 15);
            this.label3.TabIndex = 33;
            this.label3.Text = "이미지 보기 버튼을 셀로 만들어서 클릭시 픽쳐박스가 있는 작은 팝업창 떠서 확인할수있게";
            this.label3.Visible = false;
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
            // frmDefectiveImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1538, 1038);
            this.Name = "frmDefectiveImage";
            this.Text = "불량이미지 등록";
            this.Load += new System.EventHandler(this.frmDefectiveImage_Load);
            this.panel1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstructionList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailInstructionList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtWorkPlaceName;
        private System.Windows.Forms.Button btnWorkPlaceList;
        private System.Windows.Forms.TextBox txtWorkPlaceCode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Button btnProcessList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvInstructionList;
        private System.Windows.Forms.DataGridView dgvDetailInstructionList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
        private UcPeriodControl ucPeriodControl1;
    }
}
