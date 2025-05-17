
namespace POP
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.picLogOut = new System.Windows.Forms.PictureBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tblButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnFiring = new System.Windows.Forms.Button();
            this.btnPacking = new System.Windows.Forms.Button();
            this.btnForming = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.pnlLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tblButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.pnlLog);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tblButtons);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1453, 807);
            this.panel1.TabIndex = 0;
            // 
            // pnlLog
            // 
            this.pnlLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLog.Controls.Add(this.picLogOut);
            this.pnlLog.Controls.Add(this.lblUser);
            this.pnlLog.Controls.Add(this.lblDate);
            this.pnlLog.Location = new System.Drawing.Point(796, 56);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(654, 100);
            this.pnlLog.TabIndex = 21;
            this.pnlLog.Visible = false;
            // 
            // picLogOut
            // 
            this.picLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogOut.Image = ((System.Drawing.Image)(resources.GetObject("picLogOut.Image")));
            this.picLogOut.Location = new System.Drawing.Point(573, 3);
            this.picLogOut.Name = "picLogOut";
            this.picLogOut.Size = new System.Drawing.Size(78, 85);
            this.picLogOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogOut.TabIndex = 20;
            this.picLogOut.TabStop = false;
            this.picLogOut.Click += new System.EventHandler(this.picLogOut_Click);
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.lblUser.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(308, 50);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(259, 38);
            this.lblUser.TabIndex = 18;
            this.lblUser.Text = "👤 관리자 님";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(19, 12);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(548, 38);
            this.lblDate.TabIndex = 19;
            this.lblDate.Text = "2021-06-25(금요일) 오전 02:48:33";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(93, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Felix Titling", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(303, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(442, 57);
            this.label2.TabIndex = 17;
            this.label2.Text = "Entertainment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Felix Titling", 95.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(288, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 149);
            this.label1.TabIndex = 16;
            this.label1.Text = "SSKY";
            // 
            // tblButtons
            // 
            this.tblButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblButtons.ColumnCount = 3;
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblButtons.Controls.Add(this.btnFiring, 1, 0);
            this.tblButtons.Controls.Add(this.btnPacking, 2, 0);
            this.tblButtons.Controls.Add(this.btnForming, 0, 0);
            this.tblButtons.Location = new System.Drawing.Point(93, 485);
            this.tblButtons.Name = "tblButtons";
            this.tblButtons.RowCount = 1;
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 275F));
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 275F));
            this.tblButtons.Size = new System.Drawing.Size(1267, 193);
            this.tblButtons.TabIndex = 15;
            this.tblButtons.Visible = false;
            // 
            // btnFiring
            // 
            this.btnFiring.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(50)))), ((int)(((byte)(49)))));
            this.btnFiring.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFiring.BackgroundImage")));
            this.btnFiring.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFiring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFiring.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiring.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFiring.ForeColor = System.Drawing.Color.White;
            this.btnFiring.Location = new System.Drawing.Point(425, 3);
            this.btnFiring.Name = "btnFiring";
            this.btnFiring.Size = new System.Drawing.Size(416, 187);
            this.btnFiring.TabIndex = 8;
            this.btnFiring.Text = "적재/소성";
            this.btnFiring.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFiring.UseVisualStyleBackColor = false;
            this.btnFiring.Click += new System.EventHandler(this.btnFiring_Click);
            // 
            // btnPacking
            // 
            this.btnPacking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(50)))), ((int)(((byte)(49)))));
            this.btnPacking.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPacking.BackgroundImage")));
            this.btnPacking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPacking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPacking.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPacking.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPacking.ForeColor = System.Drawing.Color.White;
            this.btnPacking.Location = new System.Drawing.Point(847, 3);
            this.btnPacking.Name = "btnPacking";
            this.btnPacking.Size = new System.Drawing.Size(417, 187);
            this.btnPacking.TabIndex = 7;
            this.btnPacking.Text = "포장";
            this.btnPacking.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPacking.UseVisualStyleBackColor = false;
            this.btnPacking.Click += new System.EventHandler(this.btnPacking_Click);
            // 
            // btnForming
            // 
            this.btnForming.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(50)))), ((int)(((byte)(49)))));
            this.btnForming.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnForming.BackgroundImage")));
            this.btnForming.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnForming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnForming.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnForming.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnForming.ForeColor = System.Drawing.Color.White;
            this.btnForming.ImageIndex = 0;
            this.btnForming.Location = new System.Drawing.Point(3, 3);
            this.btnForming.Name = "btnForming";
            this.btnForming.Size = new System.Drawing.Size(416, 187);
            this.btnForming.TabIndex = 4;
            this.btnForming.Text = "성형";
            this.btnForming.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnForming.UseVisualStyleBackColor = false;
            this.btnForming.Click += new System.EventHandler(this.btnForming_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1453, 807);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tblButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tblButtons;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picLogOut;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.Button btnForming;
        private System.Windows.Forms.Button btnPacking;
        private System.Windows.Forms.Button btnFiring;
        private System.Windows.Forms.Timer timer1;
    }
}