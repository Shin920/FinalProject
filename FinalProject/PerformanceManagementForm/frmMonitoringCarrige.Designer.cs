
namespace FinalProject
{
    partial class frmMonitoringCarrige
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblSubTitle1 = new System.Windows.Forms.Label();
            this.dgvEmptyCarriageList = new System.Windows.Forms.DataGridView();
            this.lblSubTitle2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmptyCarriageList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1538, 830);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.lblSubTitle1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvEmptyCarriageList);
            this.splitContainer1.Panel2.Controls.Add(this.lblSubTitle2);
            this.splitContainer1.Size = new System.Drawing.Size(1497, 814);
            this.splitContainer1.SplitterDistance = 1182;
            this.splitContainer1.TabIndex = 33;
            // 
            // lblSubTitle1
            // 
            this.lblSubTitle1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSubTitle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSubTitle1.Location = new System.Drawing.Point(5, 5);
            this.lblSubTitle1.Name = "lblSubTitle1";
            this.lblSubTitle1.Size = new System.Drawing.Size(231, 31);
            this.lblSubTitle1.TabIndex = 22;
            this.lblSubTitle1.Text = "☷ 사용중인 대차 현황";
            // 
            // dgvEmptyCarriageList
            // 
            this.dgvEmptyCarriageList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmptyCarriageList.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmptyCarriageList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmptyCarriageList.Location = new System.Drawing.Point(3, 38);
            this.dgvEmptyCarriageList.Name = "dgvEmptyCarriageList";
            this.dgvEmptyCarriageList.RowTemplate.Height = 23;
            this.dgvEmptyCarriageList.Size = new System.Drawing.Size(305, 773);
            this.dgvEmptyCarriageList.TabIndex = 32;
            // 
            // lblSubTitle2
            // 
            this.lblSubTitle2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubTitle2.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSubTitle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSubTitle2.Location = new System.Drawing.Point(6, 3);
            this.lblSubTitle2.Name = "lblSubTitle2";
            this.lblSubTitle2.Size = new System.Drawing.Size(168, 32);
            this.lblSubTitle2.TabIndex = 31;
            this.lblSubTitle2.Text = "☷ 빈 대차 현황";
            // 
            // frmMonitoringCarrige
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 830);
            this.Controls.Add(this.panel1);
            this.Name = "frmMonitoringCarrige";
            this.Text = "대차 현황 모니터링";
            this.Load += new System.EventHandler(this.frmMonitoringCarrige_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmptyCarriageList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.SplitContainer splitContainer1;
        protected System.Windows.Forms.Label lblSubTitle1;
        protected System.Windows.Forms.Label lblSubTitle2;
        private System.Windows.Forms.DataGridView dgvEmptyCarriageList;
    }
}