
namespace POP
{
    partial class frmLoadFiring
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
            this.btnRegPrdQuality = new System.Windows.Forms.Button();
            this.btnRegCondition = new System.Windows.Forms.Button();
            this.btnVacateCar = new System.Windows.Forms.Button();
            this.btnFiring = new System.Windows.Forms.Button();
            this.btnRegLoadPer = new System.Windows.Forms.Button();
            this.btnSetWorker = new System.Windows.Forms.Button();
            this.btnCreateWorkOrder = new System.Windows.Forms.Button();
            this.btnClosing = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.btnStart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEnd, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnClosing, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCreateWorkOrder, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSetWorker, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRegLoadPer, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFiring, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnVacateCar, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRegCondition, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRegPrdQuality, 9, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 475);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1277, 148);
            this.tableLayoutPanel1.TabIndex = 35;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // btnRegPrdQuality
            // 
            this.btnRegPrdQuality.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnRegPrdQuality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegPrdQuality.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegPrdQuality.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRegPrdQuality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnRegPrdQuality.Location = new System.Drawing.Point(1146, 3);
            this.btnRegPrdQuality.Name = "btnRegPrdQuality";
            this.btnRegPrdQuality.Size = new System.Drawing.Size(128, 142);
            this.btnRegPrdQuality.TabIndex = 10;
            this.btnRegPrdQuality.Text = "품질측정\r\n값 등록";
            this.btnRegPrdQuality.UseVisualStyleBackColor = false;
            this.btnRegPrdQuality.Click += new System.EventHandler(this.btnRegPrdQuality_Click);
            // 
            // btnRegCondition
            // 
            this.btnRegCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnRegCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegCondition.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegCondition.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRegCondition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnRegCondition.Location = new System.Drawing.Point(1019, 3);
            this.btnRegCondition.Name = "btnRegCondition";
            this.btnRegCondition.Size = new System.Drawing.Size(121, 142);
            this.btnRegCondition.TabIndex = 9;
            this.btnRegCondition.Text = "공정조건\r\n등록";
            this.btnRegCondition.UseVisualStyleBackColor = false;
            this.btnRegCondition.Click += new System.EventHandler(this.btnRegCondition_Click);
            // 
            // btnVacateCar
            // 
            this.btnVacateCar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnVacateCar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVacateCar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVacateCar.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnVacateCar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnVacateCar.Location = new System.Drawing.Point(892, 3);
            this.btnVacateCar.Name = "btnVacateCar";
            this.btnVacateCar.Size = new System.Drawing.Size(121, 142);
            this.btnVacateCar.TabIndex = 8;
            this.btnVacateCar.Text = "소성대차\r\n비우기";
            this.btnVacateCar.UseVisualStyleBackColor = false;
            this.btnVacateCar.Click += new System.EventHandler(this.btnVacateCar_Click);
            // 
            // btnFiring
            // 
            this.btnFiring.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnFiring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFiring.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiring.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFiring.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnFiring.Location = new System.Drawing.Point(765, 3);
            this.btnFiring.Name = "btnFiring";
            this.btnFiring.Size = new System.Drawing.Size(121, 142);
            this.btnFiring.TabIndex = 7;
            this.btnFiring.Text = "요입/\r\n요출";
            this.btnFiring.UseVisualStyleBackColor = false;
            this.btnFiring.Click += new System.EventHandler(this.btnFiring_Click);
            // 
            // btnRegLoadPer
            // 
            this.btnRegLoadPer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnRegLoadPer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegLoadPer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegLoadPer.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRegLoadPer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnRegLoadPer.Location = new System.Drawing.Point(638, 3);
            this.btnRegLoadPer.Name = "btnRegLoadPer";
            this.btnRegLoadPer.Size = new System.Drawing.Size(121, 142);
            this.btnRegLoadPer.TabIndex = 6;
            this.btnRegLoadPer.Text = "적재실적\r\n등록";
            this.btnRegLoadPer.UseVisualStyleBackColor = false;
            this.btnRegLoadPer.Click += new System.EventHandler(this.btnRegLoadPer_Click);
            // 
            // btnSetWorker
            // 
            this.btnSetWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnSetWorker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetWorker.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetWorker.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSetWorker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnSetWorker.ImageIndex = 3;
            this.btnSetWorker.Location = new System.Drawing.Point(511, 3);
            this.btnSetWorker.Name = "btnSetWorker";
            this.btnSetWorker.Size = new System.Drawing.Size(121, 142);
            this.btnSetWorker.TabIndex = 4;
            this.btnSetWorker.Text = "작업자\r\n할당";
            this.btnSetWorker.UseVisualStyleBackColor = false;
            this.btnSetWorker.Click += new System.EventHandler(this.btnSetWorker_Click);
            // 
            // btnCreateWorkOrder
            // 
            this.btnCreateWorkOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnCreateWorkOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreateWorkOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateWorkOrder.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCreateWorkOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnCreateWorkOrder.ImageIndex = 2;
            this.btnCreateWorkOrder.Location = new System.Drawing.Point(384, 3);
            this.btnCreateWorkOrder.Name = "btnCreateWorkOrder";
            this.btnCreateWorkOrder.Size = new System.Drawing.Size(121, 142);
            this.btnCreateWorkOrder.TabIndex = 3;
            this.btnCreateWorkOrder.Text = "작업지시\r\n생성";
            this.btnCreateWorkOrder.UseVisualStyleBackColor = false;
            this.btnCreateWorkOrder.Click += new System.EventHandler(this.btnCreateWorkOrder_Click);
            // 
            // btnClosing
            // 
            this.btnClosing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnClosing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClosing.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClosing.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClosing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnClosing.Location = new System.Drawing.Point(257, 3);
            this.btnClosing.Name = "btnClosing";
            this.btnClosing.Size = new System.Drawing.Size(121, 142);
            this.btnClosing.TabIndex = 2;
            this.btnClosing.Text = "현장마감";
            this.btnClosing.UseVisualStyleBackColor = false;
            this.btnClosing.Click += new System.EventHandler(this.btnClosing_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.Red;
            this.btnEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnd.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEnd.ForeColor = System.Drawing.Color.White;
            this.btnEnd.Location = new System.Drawing.Point(130, 3);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(121, 142);
            this.btnEnd.TabIndex = 1;
            this.btnEnd.Text = "작업종료";
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.ForestGreen;
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(121, 142);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "작업시작";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1277, 469);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // frmLoadFiring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 624);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmLoadFiring";
            this.Text = "작업지시 현황(적재/소성)";
            this.Load += new System.EventHandler(this.frmLoadFiring_Load);
            this.Shown += new System.EventHandler(this.frmLoadFiring_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnRegPrdQuality;
        private System.Windows.Forms.Button btnRegCondition;
        private System.Windows.Forms.Button btnVacateCar;
        private System.Windows.Forms.Button btnFiring;
        private System.Windows.Forms.Button btnRegLoadPer;
        private System.Windows.Forms.Button btnSetWorker;
        private System.Windows.Forms.Button btnCreateWorkOrder;
        private System.Windows.Forms.Button btnClosing;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}