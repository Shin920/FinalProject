
namespace FinalProject
{
    partial class frmPost
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtRoadPost = new System.Windows.Forms.TextBox();
            this.btnRoad = new System.Windows.Forms.Button();
            this.txtRoadAddr1 = new System.Windows.Forms.TextBox();
            this.txtRoadAddr2 = new System.Windows.Forms.TextBox();
            this.txtJibunAddr2 = new System.Windows.Forms.TextBox();
            this.txtJibunAddr1 = new System.Windows.Forms.TextBox();
            this.btnJibun = new System.Windows.Forms.Button();
            this.txtJibunPost = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(527, 176);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(46, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "주소검색";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(140, 75);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(198, 28);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnSearch.Location = new System.Drawing.Point(359, 73);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 30);
            this.btnSearch.TabIndex = 65;
            this.btnSearch.Text = "우편번호 검색";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtRoadPost
            // 
            this.txtRoadPost.Location = new System.Drawing.Point(140, 303);
            this.txtRoadPost.Name = "txtRoadPost";
            this.txtRoadPost.Size = new System.Drawing.Size(198, 28);
            this.txtRoadPost.TabIndex = 66;
            // 
            // btnRoad
            // 
            this.btnRoad.BackColor = System.Drawing.Color.White;
            this.btnRoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoad.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnRoad.Location = new System.Drawing.Point(12, 303);
            this.btnRoad.Name = "btnRoad";
            this.btnRoad.Size = new System.Drawing.Size(99, 44);
            this.btnRoad.TabIndex = 68;
            this.btnRoad.Text = "도로명 주소 확인";
            this.btnRoad.UseVisualStyleBackColor = false;
            this.btnRoad.Click += new System.EventHandler(this.btnRoad_Click);
            // 
            // txtRoadAddr1
            // 
            this.txtRoadAddr1.Location = new System.Drawing.Point(140, 337);
            this.txtRoadAddr1.Name = "txtRoadAddr1";
            this.txtRoadAddr1.Size = new System.Drawing.Size(379, 28);
            this.txtRoadAddr1.TabIndex = 69;
            // 
            // txtRoadAddr2
            // 
            this.txtRoadAddr2.Location = new System.Drawing.Point(140, 371);
            this.txtRoadAddr2.Name = "txtRoadAddr2";
            this.txtRoadAddr2.Size = new System.Drawing.Size(379, 28);
            this.txtRoadAddr2.TabIndex = 70;
            // 
            // txtJibunAddr2
            // 
            this.txtJibunAddr2.Location = new System.Drawing.Point(140, 503);
            this.txtJibunAddr2.Name = "txtJibunAddr2";
            this.txtJibunAddr2.Size = new System.Drawing.Size(379, 28);
            this.txtJibunAddr2.TabIndex = 74;
            // 
            // txtJibunAddr1
            // 
            this.txtJibunAddr1.Location = new System.Drawing.Point(140, 469);
            this.txtJibunAddr1.Name = "txtJibunAddr1";
            this.txtJibunAddr1.Size = new System.Drawing.Size(379, 28);
            this.txtJibunAddr1.TabIndex = 73;
            // 
            // btnJibun
            // 
            this.btnJibun.BackColor = System.Drawing.Color.White;
            this.btnJibun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJibun.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnJibun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnJibun.Location = new System.Drawing.Point(12, 435);
            this.btnJibun.Name = "btnJibun";
            this.btnJibun.Size = new System.Drawing.Size(99, 44);
            this.btnJibun.TabIndex = 72;
            this.btnJibun.Text = "지번 주소   확인";
            this.btnJibun.UseVisualStyleBackColor = false;
            this.btnJibun.Click += new System.EventHandler(this.btnJibun_Click);
            // 
            // txtJibunPost
            // 
            this.txtJibunPost.Location = new System.Drawing.Point(140, 435);
            this.txtJibunPost.Name = "txtJibunPost";
            this.txtJibunPost.Size = new System.Drawing.Size(198, 28);
            this.txtJibunPost.TabIndex = 71;
            // 
            // frmPost
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(553, 577);
            this.Controls.Add(this.txtJibunAddr2);
            this.Controls.Add(this.txtJibunAddr1);
            this.Controls.Add(this.btnJibun);
            this.Controls.Add(this.txtJibunPost);
            this.Controls.Add(this.txtRoadAddr2);
            this.Controls.Add(this.txtRoadAddr1);
            this.Controls.Add(this.btnRoad);
            this.Controls.Add(this.txtRoadPost);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPost";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "우편번호 검색";
            this.Load += new System.EventHandler(this.frmPost_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        protected System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtRoadPost;
        protected System.Windows.Forms.Button btnRoad;
        private System.Windows.Forms.TextBox txtRoadAddr1;
        private System.Windows.Forms.TextBox txtRoadAddr2;
        private System.Windows.Forms.TextBox txtJibunAddr2;
        private System.Windows.Forms.TextBox txtJibunAddr1;
        protected System.Windows.Forms.Button btnJibun;
        private System.Windows.Forms.TextBox txtJibunPost;
    }
}