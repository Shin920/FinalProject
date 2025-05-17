
namespace POP
{
    partial class frmLoadPerformance
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
            this.dgvDryCar = new System.Windows.Forms.DataGridView();
            this.btnLoading = new System.Windows.Forms.Button();
            this.dgvFireCar = new System.Windows.Forms.DataGridView();
            this.button9 = new System.Windows.Forms.Button();
            this.btnDry = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDry = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLoadQty = new System.Windows.Forms.TextBox();
            this.btnFire = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFire = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWorkDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWorkNO = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWorkPlace = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDryCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFireCar)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDryCar
            // 
            this.dgvDryCar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDryCar.BackgroundColor = System.Drawing.Color.White;
            this.dgvDryCar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDryCar.Location = new System.Drawing.Point(1062, 322);
            this.dgvDryCar.Name = "dgvDryCar";
            this.dgvDryCar.RowTemplate.Height = 23;
            this.dgvDryCar.Size = new System.Drawing.Size(858, 492);
            this.dgvDryCar.TabIndex = 44;
            this.dgvDryCar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDryCar_CellClick);
            // 
            // btnLoading
            // 
            this.btnLoading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnLoading.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoading.Font = new System.Drawing.Font("맑은 고딕", 54.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnLoading.Location = new System.Drawing.Point(658, 322);
            this.btnLoading.Name = "btnLoading";
            this.btnLoading.Size = new System.Drawing.Size(398, 221);
            this.btnLoading.TabIndex = 43;
            this.btnLoading.Text = "옮겨타기";
            this.btnLoading.UseVisualStyleBackColor = false;
            this.btnLoading.Click += new System.EventHandler(this.btnLoading_Click);
            // 
            // dgvFireCar
            // 
            this.dgvFireCar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvFireCar.BackgroundColor = System.Drawing.Color.White;
            this.dgvFireCar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFireCar.Location = new System.Drawing.Point(0, 322);
            this.dgvFireCar.Name = "dgvFireCar";
            this.dgvFireCar.RowTemplate.Height = 23;
            this.dgvFireCar.Size = new System.Drawing.Size(652, 492);
            this.dgvFireCar.TabIndex = 42;
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button9.Font = new System.Drawing.Font("맑은 고딕", 54.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.button9.Location = new System.Drawing.Point(658, 549);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(398, 265);
            this.button9.TabIndex = 58;
            this.button9.Text = "건조대차\r\n비우기";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // btnDry
            // 
            this.btnDry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnDry.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDry.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnDry.Location = new System.Drawing.Point(1756, 236);
            this.btnDry.Name = "btnDry";
            this.btnDry.Size = new System.Drawing.Size(165, 71);
            this.btnDry.TabIndex = 67;
            this.btnDry.Text = "검색";
            this.btnDry.UseVisualStyleBackColor = false;
            this.btnDry.Click += new System.EventHandler(this.btnDry_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.label9.Location = new System.Drawing.Point(1062, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(226, 70);
            this.label9.TabIndex = 65;
            this.label9.Text = "대차검색";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDry
            // 
            this.txtDry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDry.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtDry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.txtDry.Location = new System.Drawing.Point(1294, 236);
            this.txtDry.Name = "txtDry";
            this.txtDry.Size = new System.Drawing.Size(456, 70);
            this.txtDry.TabIndex = 66;
            this.txtDry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDry_KeyDown);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.label7.Location = new System.Drawing.Point(659, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 70);
            this.label7.TabIndex = 63;
            this.label7.Text = "수량";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLoadQty
            // 
            this.txtLoadQty.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLoadQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.txtLoadQty.Location = new System.Drawing.Point(809, 236);
            this.txtLoadQty.Name = "txtLoadQty";
            this.txtLoadQty.Size = new System.Drawing.Size(247, 70);
            this.txtLoadQty.TabIndex = 64;
            // 
            // btnFire
            // 
            this.btnFire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnFire.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFire.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFire.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnFire.Location = new System.Drawing.Point(488, 236);
            this.btnFire.Name = "btnFire";
            this.btnFire.Size = new System.Drawing.Size(164, 70);
            this.btnFire.TabIndex = 62;
            this.btnFire.Text = "검색";
            this.btnFire.UseVisualStyleBackColor = false;
            this.btnFire.Click += new System.EventHandler(this.btnFire_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.label8.Location = new System.Drawing.Point(4, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(222, 69);
            this.label8.TabIndex = 60;
            this.label8.Text = "대차검색";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFire
            // 
            this.txtFire.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtFire.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.txtFire.Location = new System.Drawing.Point(232, 236);
            this.txtFire.Name = "txtFire";
            this.txtFire.Size = new System.Drawing.Size(250, 70);
            this.txtFire.TabIndex = 61;
            this.txtFire.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFire_KeyDown);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtQty, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtWorkDate, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtProd, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtWorkNO, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtUnit, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtWorkPlace, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1924, 220);
            this.tableLayoutPanel2.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 72);
            this.label1.TabIndex = 12;
            this.label1.Text = "작업장";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQty
            // 
            this.txtQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQty.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtQty.Location = new System.Drawing.Point(1348, 83);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(572, 54);
            this.txtQty.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(964, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(377, 72);
            this.label5.TabIndex = 8;
            this.label5.Text = "계획수량";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWorkDate
            // 
            this.txtWorkDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWorkDate.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWorkDate.Location = new System.Drawing.Point(388, 83);
            this.txtWorkDate.Name = "txtWorkDate";
            this.txtWorkDate.Size = new System.Drawing.Size(569, 54);
            this.txtWorkDate.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(377, 72);
            this.label4.TabIndex = 6;
            this.label4.Text = "작업지시일";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProd
            // 
            this.txtProd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProd.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProd.Location = new System.Drawing.Point(1348, 10);
            this.txtProd.Name = "txtProd";
            this.txtProd.Size = new System.Drawing.Size(572, 54);
            this.txtProd.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(964, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(377, 72);
            this.label6.TabIndex = 2;
            this.label6.Text = "품목";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 72);
            this.label2.TabIndex = 0;
            this.label2.Text = "작업지시번호";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWorkNO
            // 
            this.txtWorkNO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkNO.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWorkNO.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWorkNO.Location = new System.Drawing.Point(388, 10);
            this.txtWorkNO.Name = "txtWorkNO";
            this.txtWorkNO.Size = new System.Drawing.Size(569, 54);
            this.txtWorkNO.TabIndex = 1;
            // 
            // txtUnit
            // 
            this.txtUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnit.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtUnit.Location = new System.Drawing.Point(1348, 156);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(572, 54);
            this.txtUnit.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(964, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(377, 72);
            this.label3.TabIndex = 13;
            this.label3.Text = "단위";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWorkPlace
            // 
            this.txtWorkPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkPlace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWorkPlace.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWorkPlace.Location = new System.Drawing.Point(388, 156);
            this.txtWorkPlace.Name = "txtWorkPlace";
            this.txtWorkPlace.Size = new System.Drawing.Size(569, 54);
            this.txtWorkPlace.TabIndex = 11;
            // 
            // frmLoadPerformance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 819);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.btnDry);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDry);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLoadQty);
            this.Controls.Add(this.btnFire);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFire);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.dgvDryCar);
            this.Controls.Add(this.btnLoading);
            this.Controls.Add(this.dgvFireCar);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmLoadPerformance";
            this.Text = "적재 실적 등록";
            this.Load += new System.EventHandler(this.frmLoadPerformance_Load);
            this.Shown += new System.EventHandler(this.frmLoadPerformance_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDryCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFireCar)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDryCar;
        private System.Windows.Forms.Button btnLoading;
        private System.Windows.Forms.DataGridView dgvFireCar;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnDry;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLoadQty;
        private System.Windows.Forms.Button btnFire;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFire;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWorkDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWorkNO;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWorkPlace;
    }
}