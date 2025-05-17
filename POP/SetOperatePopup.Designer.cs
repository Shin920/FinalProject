
namespace POP
{
    partial class SetOperatePopup
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
            this.lblseq = new System.Windows.Forms.Label();
            this.lblWcName = new System.Windows.Forms.Label();
            this.cboNopMa = new System.Windows.Forms.ComboBox();
            this.cboNopMi = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblseq
            // 
            this.lblseq.AutoSize = true;
            this.lblseq.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblseq.Location = new System.Drawing.Point(15, 9);
            this.lblseq.Name = "lblseq";
            this.lblseq.Size = new System.Drawing.Size(54, 20);
            this.lblseq.TabIndex = 0;
            this.lblseq.Text = "작업장";
            // 
            // lblWcName
            // 
            this.lblWcName.AutoSize = true;
            this.lblWcName.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWcName.Location = new System.Drawing.Point(12, 29);
            this.lblWcName.Name = "lblWcName";
            this.lblWcName.Size = new System.Drawing.Size(221, 48);
            this.lblWcName.TabIndex = 0;
            this.lblWcName.Text = "소성작업장1";
            // 
            // cboNopMa
            // 
            this.cboNopMa.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboNopMa.FormattingEnabled = true;
            this.cboNopMa.Location = new System.Drawing.Point(19, 86);
            this.cboNopMa.Name = "cboNopMa";
            this.cboNopMa.Size = new System.Drawing.Size(582, 56);
            this.cboNopMa.TabIndex = 1;
            this.cboNopMa.SelectedIndexChanged += new System.EventHandler(this.cboNopMa_SelectedIndexChanged);
            // 
            // cboNopMi
            // 
            this.cboNopMi.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboNopMi.FormattingEnabled = true;
            this.cboNopMi.Location = new System.Drawing.Point(20, 148);
            this.cboNopMi.Name = "cboNopMi";
            this.cboNopMi.Size = new System.Drawing.Size(582, 56);
            this.cboNopMi.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.button4.Location = new System.Drawing.Point(189, 210);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(203, 60);
            this.button4.TabIndex = 64;
            this.button4.Text = "설정";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.button1.Location = new System.Drawing.Point(398, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 60);
            this.button1.TabIndex = 64;
            this.button1.Text = "취소";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SetOperatePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(630, 300);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cboNopMi);
            this.Controls.Add(this.cboNopMa);
            this.Controls.Add(this.lblWcName);
            this.Controls.Add(this.lblseq);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SetOperatePopup";
            this.Text = "비가동 사유 변경";
            this.Load += new System.EventHandler(this.SetOperatePopup_Load);
            this.Shown += new System.EventHandler(this.SetOperatePopup_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblseq;
        private System.Windows.Forms.Label lblWcName;
        private System.Windows.Forms.ComboBox cboNopMa;
        private System.Windows.Forms.ComboBox cboNopMi;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
    }
}