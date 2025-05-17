
namespace FinalProject
{
    partial class frmMenuM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuM));
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tvMenu = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.dgvParent = new System.Windows.Forms.DataGridView();
            this.deletecheck1 = new System.Windows.Forms.CheckBox();
            this.pnlDataGridView = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvS = new System.Windows.Forms.DataGridView();
            this.deletecheck2 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParent)).BeginInit();
            this.pnlDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvS)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTitle.Location = new System.Drawing.Point(40, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(293, 40);
            this.lblTitle.TabIndex = 35;
            this.lblTitle.Text = "메뉴관리";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.tvMenu);
            this.panel2.Location = new System.Drawing.Point(885, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(607, 697);
            this.panel2.TabIndex = 41;
            // 
            // tvMenu
            // 
            this.tvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMenu.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.tvMenu.Location = new System.Drawing.Point(0, 0);
            this.tvMenu.Name = "tvMenu";
            this.tvMenu.Size = new System.Drawing.Size(607, 697);
            this.tvMenu.TabIndex = 0;
            this.tvMenu.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvMenu_ItemDrag);
            this.tvMenu.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvMenu_DragDrop);
            this.tvMenu.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvMenu_DragEnter);
            this.tvMenu.DragOver += new System.Windows.Forms.DragEventHandler(this.tvMenu_DragOver);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label2.Location = new System.Drawing.Point(880, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 29);
            this.label2.TabIndex = 42;
            this.label2.Text = "☷ 메뉴 트리뷰";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "minus.png");
            this.imageList1.Images.SetKeyName(1, "plus.png");
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSubTitle.Location = new System.Drawing.Point(42, 75);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(145, 29);
            this.lblSubTitle.TabIndex = 37;
            this.lblSubTitle.Text = "☷ 메뉴모듈";
            // 
            // dgvParent
            // 
            this.dgvParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvParent.BackgroundColor = System.Drawing.Color.White;
            this.dgvParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParent.Location = new System.Drawing.Point(0, 0);
            this.dgvParent.Name = "dgvParent";
            this.dgvParent.RowTemplate.Height = 23;
            this.dgvParent.Size = new System.Drawing.Size(808, 323);
            this.dgvParent.TabIndex = 0;
            this.dgvParent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParent_CellClick);
            this.dgvParent.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParent_CellDoubleClick);
            // 
            // deletecheck1
            // 
            this.deletecheck1.AutoSize = true;
            this.deletecheck1.Location = new System.Drawing.Point(14, 4);
            this.deletecheck1.Name = "deletecheck1";
            this.deletecheck1.Size = new System.Drawing.Size(15, 14);
            this.deletecheck1.TabIndex = 1;
            this.deletecheck1.UseVisualStyleBackColor = true;
            this.deletecheck1.Visible = false;
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDataGridView.Controls.Add(this.deletecheck1);
            this.pnlDataGridView.Controls.Add(this.dgvParent);
            this.pnlDataGridView.Location = new System.Drawing.Point(47, 110);
            this.pnlDataGridView.Name = "pnlDataGridView";
            this.pnlDataGridView.Size = new System.Drawing.Size(808, 323);
            this.pnlDataGridView.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label1.Location = new System.Drawing.Point(42, 449);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 29);
            this.label1.TabIndex = 39;
            this.label1.Text = "☷ 메뉴 하위목록";
            // 
            // dgvS
            // 
            this.dgvS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvS.BackgroundColor = System.Drawing.Color.White;
            this.dgvS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvS.Location = new System.Drawing.Point(0, 0);
            this.dgvS.Name = "dgvS";
            this.dgvS.RowTemplate.Height = 23;
            this.dgvS.Size = new System.Drawing.Size(808, 323);
            this.dgvS.TabIndex = 0;
            this.dgvS.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvS_CellClick);
            // 
            // deletecheck2
            // 
            this.deletecheck2.AutoSize = true;
            this.deletecheck2.Location = new System.Drawing.Point(13, 3);
            this.deletecheck2.Name = "deletecheck2";
            this.deletecheck2.Size = new System.Drawing.Size(15, 14);
            this.deletecheck2.TabIndex = 2;
            this.deletecheck2.UseVisualStyleBackColor = true;
            this.deletecheck2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.deletecheck2);
            this.panel1.Controls.Add(this.dgvS);
            this.panel1.Location = new System.Drawing.Point(47, 484);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 323);
            this.panel1.TabIndex = 40;
            // 
            // frmMenuM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1538, 830);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlDataGridView);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmMenuM";
            this.Text = "메뉴관리";
            this.Load += new System.EventHandler(this.frmMenuM_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParent)).EndInit();
            this.pnlDataGridView.ResumeLayout(false);
            this.pnlDataGridView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblTitle;
        protected System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView tvMenu;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        protected System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.DataGridView dgvParent;
        private System.Windows.Forms.CheckBox deletecheck1;
        protected System.Windows.Forms.Panel pnlDataGridView;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvS;
        private System.Windows.Forms.CheckBox deletecheck2;
        protected System.Windows.Forms.Panel panel1;
    }
}