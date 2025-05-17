
namespace POP
{
    partial class frmProductCar
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
            this.dgvFormingCar = new System.Windows.Forms.DataGridView();
            this.btnLoading = new System.Windows.Forms.Button();
            this.dgvDryCar = new System.Windows.Forms.DataGridView();
            this.btnDry = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDryCarS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLoadQty = new System.Windows.Forms.TextBox();
            this.btnForm = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFormingCarS = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWorkDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWorkNO = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWorkPlace = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormingCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDryCar)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFormingCar
            // 
            this.dgvFormingCar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFormingCar.BackgroundColor = System.Drawing.Color.White;
            this.dgvFormingCar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormingCar.Location = new System.Drawing.Point(1025, 314);
            this.dgvFormingCar.Name = "dgvFormingCar";
            this.dgvFormingCar.RowTemplate.Height = 23;
            this.dgvFormingCar.Size = new System.Drawing.Size(895, 410);
            this.dgvFormingCar.TabIndex = 19;
            this.dgvFormingCar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormingCar_CellClick);
            // 
            // btnLoading
            // 
            this.btnLoading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoading.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnLoading.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoading.Font = new System.Drawing.Font("맑은 고딕", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnLoading.Location = new System.Drawing.Point(668, 313);
            this.btnLoading.Name = "btnLoading";
            this.btnLoading.Size = new System.Drawing.Size(351, 410);
            this.btnLoading.TabIndex = 18;
            this.btnLoading.Text = "로딩";
            this.btnLoading.UseVisualStyleBackColor = false;
            this.btnLoading.Click += new System.EventHandler(this.btnLoading_Click);
            // 
            // dgvDryCar
            // 
            this.dgvDryCar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvDryCar.BackgroundColor = System.Drawing.Color.White;
            this.dgvDryCar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDryCar.Location = new System.Drawing.Point(0, 315);
            this.dgvDryCar.Name = "dgvDryCar";
            this.dgvDryCar.RowTemplate.Height = 23;
            this.dgvDryCar.Size = new System.Drawing.Size(662, 409);
            this.dgvDryCar.TabIndex = 16;
            // 
            // btnDry
            // 
            this.btnDry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnDry.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDry.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnDry.Location = new System.Drawing.Point(497, 226);
            this.btnDry.Name = "btnDry";
            this.btnDry.Size = new System.Drawing.Size(165, 72);
            this.btnDry.TabIndex = 25;
            this.btnDry.Text = "검색";
            this.btnDry.UseVisualStyleBackColor = false;
            this.btnDry.Click += new System.EventHandler(this.btnDry_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.label8.Location = new System.Drawing.Point(2, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(230, 68);
            this.label8.TabIndex = 23;
            this.label8.Text = "대차검색";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDryCarS
            // 
            this.txtDryCarS.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtDryCarS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.txtDryCarS.Location = new System.Drawing.Point(238, 228);
            this.txtDryCarS.Name = "txtDryCarS";
            this.txtDryCarS.Size = new System.Drawing.Size(253, 70);
            this.txtDryCarS.TabIndex = 24;
            this.txtDryCarS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDryCarS_KeyDown);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.label7.Location = new System.Drawing.Point(668, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 71);
            this.label7.TabIndex = 26;
            this.label7.Text = "수량";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLoadQty
            // 
            this.txtLoadQty.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLoadQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.txtLoadQty.Location = new System.Drawing.Point(816, 227);
            this.txtLoadQty.Name = "txtLoadQty";
            this.txtLoadQty.Size = new System.Drawing.Size(203, 70);
            this.txtLoadQty.TabIndex = 27;
            // 
            // btnForm
            // 
            this.btnForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.btnForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnForm.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(135)))));
            this.btnForm.Location = new System.Drawing.Point(1755, 228);
            this.btnForm.Name = "btnForm";
            this.btnForm.Size = new System.Drawing.Size(165, 70);
            this.btnForm.TabIndex = 31;
            this.btnForm.Text = "검색";
            this.btnForm.UseVisualStyleBackColor = false;
            this.btnForm.Click += new System.EventHandler(this.brnForm_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.label9.Location = new System.Drawing.Point(1025, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(217, 72);
            this.label9.TabIndex = 29;
            this.label9.Text = "대차검색";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFormingCarS
            // 
            this.txtFormingCarS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFormingCarS.Font = new System.Drawing.Font("맑은 고딕", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtFormingCarS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.txtFormingCarS.Location = new System.Drawing.Point(1248, 228);
            this.txtFormingCarS.Name = "txtFormingCarS";
            this.txtFormingCarS.Size = new System.Drawing.Size(501, 70);
            this.txtFormingCarS.TabIndex = 30;
            this.txtFormingCarS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFormingCarS_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtQty, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtWorkDate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtProd, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtWorkNO, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtUnit, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtWorkPlace, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1924, 210);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(377, 70);
            this.label3.TabIndex = 12;
            this.label3.Text = "작업장";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQty
            // 
            this.txtQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQty.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtQty.Location = new System.Drawing.Point(1348, 77);
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
            this.label5.Location = new System.Drawing.Point(964, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(377, 68);
            this.label5.TabIndex = 8;
            this.label5.Text = "실적수량";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWorkDate
            // 
            this.txtWorkDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWorkDate.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWorkDate.Location = new System.Drawing.Point(388, 77);
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
            this.label4.Location = new System.Drawing.Point(4, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(377, 68);
            this.label4.TabIndex = 6;
            this.label4.Text = "작업지시일";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProd
            // 
            this.txtProd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProd.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProd.Location = new System.Drawing.Point(1348, 8);
            this.txtProd.Name = "txtProd";
            this.txtProd.Size = new System.Drawing.Size(572, 54);
            this.txtProd.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(964, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 68);
            this.label2.TabIndex = 2;
            this.label2.Text = "품목";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "작업지시번호";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWorkNO
            // 
            this.txtWorkNO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkNO.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWorkNO.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWorkNO.Location = new System.Drawing.Point(388, 8);
            this.txtWorkNO.Name = "txtWorkNO";
            this.txtWorkNO.Size = new System.Drawing.Size(569, 54);
            this.txtWorkNO.TabIndex = 1;
            // 
            // txtUnit
            // 
            this.txtUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnit.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtUnit.Location = new System.Drawing.Point(1348, 147);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(572, 54);
            this.txtUnit.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(30)))), ((int)(((byte)(29)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(964, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(377, 70);
            this.label6.TabIndex = 13;
            this.label6.Text = "단위";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWorkPlace
            // 
            this.txtWorkPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkPlace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWorkPlace.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWorkPlace.Location = new System.Drawing.Point(388, 147);
            this.txtWorkPlace.Name = "txtWorkPlace";
            this.txtWorkPlace.Size = new System.Drawing.Size(569, 54);
            this.txtWorkPlace.TabIndex = 11;
            // 
            // frmProductCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 725);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnForm);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtFormingCarS);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLoadQty);
            this.Controls.Add(this.btnDry);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDryCarS);
            this.Controls.Add(this.dgvFormingCar);
            this.Controls.Add(this.btnLoading);
            this.Controls.Add(this.dgvDryCar);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmProductCar";
            this.Text = "건조대차로딩";
            this.Load += new System.EventHandler(this.frmProductCar_Load);
            this.Shown += new System.EventHandler(this.frmProductCar_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormingCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDryCar)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvFormingCar;
        private System.Windows.Forms.Button btnLoading;
        private System.Windows.Forms.DataGridView dgvDryCar;
        private System.Windows.Forms.Button btnDry;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDryCarS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLoadQty;
        private System.Windows.Forms.Button btnForm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFormingCarS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWorkDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWorkNO;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtWorkPlace;
    }
}