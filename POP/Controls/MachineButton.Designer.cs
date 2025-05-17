
namespace POP.Controls
{
    partial class MachineButton
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.button4 = new System.Windows.Forms.Button();
            this.lblTask_IP = new System.Windows.Forms.Label();
            this.lblTask_Port = new System.Windows.Forms.Label();
            this.lblTask_ID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("맑은 고딕", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(632, 214);
            this.button4.TabIndex = 16;
            this.button4.Text = "성형기계1";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblTask_IP
            // 
            this.lblTask_IP.AutoSize = true;
            this.lblTask_IP.Location = new System.Drawing.Point(67, 167);
            this.lblTask_IP.Name = "lblTask_IP";
            this.lblTask_IP.Size = new System.Drawing.Size(63, 12);
            this.lblTask_IP.TabIndex = 17;
            this.lblTask_IP.Text = "lblTask_IP";
            this.lblTask_IP.Visible = false;
            // 
            // lblTask_Port
            // 
            this.lblTask_Port.AutoSize = true;
            this.lblTask_Port.Location = new System.Drawing.Point(192, 167);
            this.lblTask_Port.Name = "lblTask_Port";
            this.lblTask_Port.Size = new System.Drawing.Size(74, 12);
            this.lblTask_Port.TabIndex = 18;
            this.lblTask_Port.Text = "lblTask_Port";
            this.lblTask_Port.Visible = false;
            // 
            // lblTask_ID
            // 
            this.lblTask_ID.AutoSize = true;
            this.lblTask_ID.Location = new System.Drawing.Point(301, 167);
            this.lblTask_ID.Name = "lblTask_ID";
            this.lblTask_ID.Size = new System.Drawing.Size(63, 12);
            this.lblTask_ID.TabIndex = 19;
            this.lblTask_ID.Text = "lblTask_ID";
            this.lblTask_ID.Visible = false;
            // 
            // MachineButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTask_ID);
            this.Controls.Add(this.lblTask_Port);
            this.Controls.Add(this.lblTask_IP);
            this.Controls.Add(this.button4);
            this.Name = "MachineButton";
            this.Size = new System.Drawing.Size(632, 214);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblTask_IP;
        private System.Windows.Forms.Label lblTask_Port;
        private System.Windows.Forms.Label lblTask_ID;
    }
}
