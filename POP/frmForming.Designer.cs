
namespace POP
{
    partial class frmForming
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnMachine = new System.Windows.Forms.Button();
            this.btnClosing = new System.Windows.Forms.Button();
            this.btnDryCarLoading = new System.Windows.Forms.Button();
            this.btnSetWorker = new System.Windows.Forms.Button();
            this.btnSetMold = new System.Windows.Forms.Button();
            this.btnRegCondition = new System.Windows.Forms.Button();
            this.btnRegPrdQuality = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlMachineButtonList = new System.Windows.Forms.Panel();
            this.progressBar1 = new POP.Controls.UserProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Controls.Add(this.btnStart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEnd, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMachine, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnClosing, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDryCarLoading, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSetWorker, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSetMold, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRegCondition, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRegPrdQuality, 8, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 476);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1277, 148);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.ForestGreen;
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(135, 142);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "작업시작";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.Red;
            this.btnEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnd.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEnd.ForeColor = System.Drawing.Color.White;
            this.btnEnd.Location = new System.Drawing.Point(144, 3);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(135, 142);
            this.btnEnd.TabIndex = 1;
            this.btnEnd.Text = "작업종료";
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnMachine
            // 
            this.btnMachine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMachine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMachine.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMachine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnMachine.Location = new System.Drawing.Point(285, 3);
            this.btnMachine.Name = "btnMachine";
            this.btnMachine.Size = new System.Drawing.Size(135, 142);
            this.btnMachine.TabIndex = 10;
            this.btnMachine.Text = "기계 시작";
            this.btnMachine.UseVisualStyleBackColor = false;
            this.btnMachine.Click += new System.EventHandler(this.btnMachine_Click);
            // 
            // btnClosing
            // 
            this.btnClosing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnClosing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClosing.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClosing.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClosing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnClosing.Location = new System.Drawing.Point(426, 3);
            this.btnClosing.Name = "btnClosing";
            this.btnClosing.Size = new System.Drawing.Size(135, 142);
            this.btnClosing.TabIndex = 2;
            this.btnClosing.Text = "현장마감";
            this.btnClosing.UseVisualStyleBackColor = false;
            this.btnClosing.Click += new System.EventHandler(this.btnClosing_Click);
            // 
            // btnDryCarLoading
            // 
            this.btnDryCarLoading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnDryCarLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDryCarLoading.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDryCarLoading.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDryCarLoading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnDryCarLoading.ImageIndex = 2;
            this.btnDryCarLoading.Location = new System.Drawing.Point(567, 3);
            this.btnDryCarLoading.Name = "btnDryCarLoading";
            this.btnDryCarLoading.Size = new System.Drawing.Size(135, 142);
            this.btnDryCarLoading.TabIndex = 3;
            this.btnDryCarLoading.Text = "건조대차\r\n로딩";
            this.btnDryCarLoading.UseVisualStyleBackColor = false;
            this.btnDryCarLoading.Click += new System.EventHandler(this.btnDryCarLoading_Click);
            // 
            // btnSetWorker
            // 
            this.btnSetWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnSetWorker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetWorker.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetWorker.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSetWorker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnSetWorker.ImageIndex = 3;
            this.btnSetWorker.Location = new System.Drawing.Point(708, 3);
            this.btnSetWorker.Name = "btnSetWorker";
            this.btnSetWorker.Size = new System.Drawing.Size(135, 142);
            this.btnSetWorker.TabIndex = 4;
            this.btnSetWorker.Text = "작업자\r\n할당";
            this.btnSetWorker.UseVisualStyleBackColor = false;
            this.btnSetWorker.Click += new System.EventHandler(this.btnSetWorker_Click);
            // 
            // btnSetMold
            // 
            this.btnSetMold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnSetMold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetMold.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetMold.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSetMold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnSetMold.Location = new System.Drawing.Point(849, 3);
            this.btnSetMold.Name = "btnSetMold";
            this.btnSetMold.Size = new System.Drawing.Size(135, 142);
            this.btnSetMold.TabIndex = 6;
            this.btnSetMold.Text = "금형장착\r\n/탈착";
            this.btnSetMold.UseVisualStyleBackColor = false;
            this.btnSetMold.Click += new System.EventHandler(this.btnSetMold_Click);
            // 
            // btnRegCondition
            // 
            this.btnRegCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnRegCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegCondition.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegCondition.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRegCondition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnRegCondition.Location = new System.Drawing.Point(990, 3);
            this.btnRegCondition.Name = "btnRegCondition";
            this.btnRegCondition.Size = new System.Drawing.Size(135, 142);
            this.btnRegCondition.TabIndex = 7;
            this.btnRegCondition.Text = "공정조건\r\n등록";
            this.btnRegCondition.UseVisualStyleBackColor = false;
            this.btnRegCondition.Click += new System.EventHandler(this.btnRegCondition_Click);
            // 
            // btnRegPrdQuality
            // 
            this.btnRegPrdQuality.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnRegPrdQuality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegPrdQuality.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegPrdQuality.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRegPrdQuality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnRegPrdQuality.Location = new System.Drawing.Point(1131, 3);
            this.btnRegPrdQuality.Name = "btnRegPrdQuality";
            this.btnRegPrdQuality.Size = new System.Drawing.Size(143, 142);
            this.btnRegPrdQuality.TabIndex = 8;
            this.btnRegPrdQuality.Text = "품질 측정값 등록";
            this.btnRegPrdQuality.UseVisualStyleBackColor = false;
            this.btnRegPrdQuality.Click += new System.EventHandler(this.btnRegPrdQuality_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1274, 398);
            this.dataGridView1.TabIndex = 32;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // pnlMachineButtonList
            // 
            this.pnlMachineButtonList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMachineButtonList.AutoScroll = true;
            this.pnlMachineButtonList.Location = new System.Drawing.Point(261, 75);
            this.pnlMachineButtonList.Name = "pnlMachineButtonList";
            this.pnlMachineButtonList.Size = new System.Drawing.Size(757, 388);
            this.pnlMachineButtonList.TabIndex = 37;
            this.pnlMachineButtonList.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.CustomText = null;
            this.progressBar1.DisplayStyle = POP.Controls.ProgressBarDisplayText.Percentage;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.progressBar1.Location = new System.Drawing.Point(2, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1274, 63);
            this.progressBar1.TabIndex = 36;
            // 
            // frmForming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 624);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pnlMachineButtonList);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmForming";
            this.Text = "작업지시 현황(성형)";
            this.Load += new System.EventHandler(this.frmForming_Load);
            this.Shown += new System.EventHandler(this.frmForming_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnRegPrdQuality;
        private System.Windows.Forms.Button btnRegCondition;
        private System.Windows.Forms.Button btnSetMold;
        private System.Windows.Forms.Button btnSetWorker;
        private System.Windows.Forms.Button btnDryCarLoading;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnMachine;
        private System.Windows.Forms.Button btnClosing;
        private Controls.UserProgressBar progressBar1;
        private System.Windows.Forms.Panel pnlMachineButtonList;
    }
}