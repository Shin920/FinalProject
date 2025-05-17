using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FinalProject
{
    public partial class frmPost : Form
    {
        private string zipcode, address1, address2;
        public string Zipcode { get { return zipcode; } }
        public string Address1 { get { return address1; } }
        public string Address2 { get { return address2; } }
        public frmPost()
        {
            InitializeComponent();
        }

        private void frmPost_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dataGridView1);
            CommonUtil.AddGridTextColumn(dataGridView1, "우편번호", "zipNo", colWidth: 80);
            CommonUtil.AddGridTextColumn(dataGridView1, "도로명주소", "roadAddr", colWidth: 200);
            CommonUtil.AddGridTextColumn(dataGridView1, "지번주소", "jibunAddr", colWidth: 200);
            CommonUtil.AddGridTextColumn(dataGridView1, "주소", "roadAddrPart1", colWidth: 10, visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "주소", "roadAddrPart2", colWidth: 10, visibility: false);
            CommonUtil.AddGridTextColumn(dataGridView1, "주소", "bdNm", colWidth: 10, visibility: false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //유효성 검사

            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("검색하실 주소를 입력하세요.");
                return;
            }

            string url = "https://www.juso.go.kr/addrlink/addrLinkApi.do";
            string apiKey = ConfigurationManager.AppSettings["RoadAPIKey"];
            string apiUrl = $"{url}?confmKey={apiKey}&confmKey={apiKey}&currentPage=1&countPerPage1000&keyword={txtSearch.Text.Trim()}";

            WebClient wc = new WebClient();
            XmlReader reader = new XmlTextReader(wc.OpenRead(apiUrl));

            DataSet ds = new DataSet();
            ds.ReadXml(reader);

            if (ds.Tables.Count > 1)
            {
                dataGridView1.DataSource = ds.Tables[1];
            }
            else
            {
                MessageBox.Show(ds.Tables[0].Rows[0]["errorMessage"].ToString());
            }
        }

        private void btnRoad_Click(object sender, EventArgs e)
        {
            if (txtRoadAddr1.Text.Length < 1)
            {
                MessageBox.Show("주소를 선택해주세요.");
            }
            else
            {
                zipcode = txtRoadPost.Text;
                address1 = txtRoadAddr1.Text;
                address2 = txtRoadAddr2.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnJibun_Click(object sender, EventArgs e)
        {
            if (txtJibunAddr1.Text.Length < 1)
            {
                MessageBox.Show("주소를 선택해주세요.");
            }
            else
            {
                zipcode = txtJibunPost.Text;
                address1 = txtJibunAddr1.Text;
                address2 = txtJibunAddr2.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRoadPost.Text = txtJibunPost.Text = dataGridView1["zipNo", e.RowIndex].Value.ToString();

            txtRoadAddr1.Text = dataGridView1["roadAddrPart1", e.RowIndex].Value.ToString();
            txtRoadAddr2.Text = $"{dataGridView1["roadAddrPart2", e.RowIndex].Value} {dataGridView1["bdNm", e.RowIndex].Value}";

            txtJibunAddr1.Text = dataGridView1["JibunAddr", e.RowIndex].Value.ToString();
        }
    }
}
