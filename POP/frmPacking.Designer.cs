
namespace POP
{
    partial class frmPacking
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
            this.btnRegPrdQuality = new System.Windows.Forms.Button();
            this.btnUnloading = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnReceive = new System.Windows.Forms.Button();
            this.btnReCreatePalette = new System.Windows.Forms.Button();
            this.btnCreatePalette = new System.Windows.Forms.Button();
            this.btnSetWorker = new System.Windows.Forms.Button();
            this.btnCreateWorkOrder = new System.Windows.Forms.Button();
            this.btnClosing = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            // btnUnloading
            // 
            this.btnUnloading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnUnloading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUnloading.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUnloading.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUnloading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnUnloading.Location = new System.Drawing.Point(1019, 3);
            this.btnUnloading.Name = "btnUnloading";
            this.btnUnloading.Size = new System.Drawing.Size(121, 142);
            this.btnUnloading.TabIndex = 9;
            this.btnUnloading.Text = "언로딩";
            this.btnUnloading.UseVisualStyleBackColor = false;
            this.btnUnloading.Click += new System.EventHandler(this.btnUnloading_Click);
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
            this.dataGridView1.Size = new System.Drawing.Size(1275, 469);
            this.dataGridView1.TabIndex = 36;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnReceive
            // 
            this.btnReceive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReceive.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReceive.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReceive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnReceive.Location = new System.Drawing.Point(892, 3);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(121, 142);
            this.btnReceive.TabIndex = 8;
            this.btnReceive.Text = "입고등록";
            this.btnReceive.UseVisualStyleBackColor = false;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // btnReCreatePalette
            // 
            this.btnReCreatePalette.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnReCreatePalette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReCreatePalette.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReCreatePalette.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReCreatePalette.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnReCreatePalette.Location = new System.Drawing.Point(765, 3);
            this.btnReCreatePalette.Name = "btnReCreatePalette";
            this.btnReCreatePalette.Size = new System.Drawing.Size(121, 142);
            this.btnReCreatePalette.TabIndex = 7;
            this.btnReCreatePalette.Text = "바코드\r\n재발행";
            this.btnReCreatePalette.UseVisualStyleBackColor = false;
            this.btnReCreatePalette.Click += new System.EventHandler(this.btnReCreatePalette_Click);
            // 
            // btnCreatePalette
            // 
            this.btnCreatePalette.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnCreatePalette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreatePalette.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreatePalette.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCreatePalette.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnCreatePalette.Location = new System.Drawing.Point(638, 3);
            this.btnCreatePalette.Name = "btnCreatePalette";
            this.btnCreatePalette.Size = new System.Drawing.Size(121, 142);
            this.btnCreatePalette.TabIndex = 6;
            this.btnCreatePalette.Text = "팔레트\r\n생성";
            this.btnCreatePalette.UseVisualStyleBackColor = false;
            this.btnCreatePalette.Click += new System.EventHandler(this.btnCreatePalette_Click);
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
            this.tableLayoutPanel1.Controls.Add(this.btnCreatePalette, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnReCreatePalette, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnReceive, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUnloading, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRegPrdQuality, 9, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 475);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1277, 148);
            this.tableLayoutPanel1.TabIndex = 37;
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
            // frmPacking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 624);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPacking";
            this.Text = "작업지시 현황(포장)";
            this.Load += new System.EventHandler(this.frmPacking_Load);
            this.Shown += new System.EventHandler(this.frmPacking_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRegPrdQuality;
        private System.Windows.Forms.Button btnUnloading;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.Button btnReCreatePalette;
        private System.Windows.Forms.Button btnCreatePalette;
        private System.Windows.Forms.Button btnSetWorker;
        private System.Windows.Forms.Button btnCreateWorkOrder;
        private System.Windows.Forms.Button btnClosing;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnStart;
    }
}