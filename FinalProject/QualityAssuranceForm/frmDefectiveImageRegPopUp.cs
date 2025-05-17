using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmDefectiveImageRegPopUp : Form
    {
        public event EventHandler SaveEvent;

        string workOrderNum;
        int DefSeq;

        public frmDefectiveImageRegPopUp(string workOrderNum, int DefSeq, string imageName = null, Image image = null)
        {
            InitializeComponent();

            this.workOrderNum = workOrderNum;
            this.DefSeq = DefSeq;

            if (imageName != null)
                txtImageName.Text = imageName;
            if (image != null)
            {
                //DefectiveService service = new DefectiveService();
                //List<DefectiveVO> list =  service.GetDetailDefInWorkOrderNum(workOrderNum);
                //byte[] a = list.Find(x => x.Def_Seq.Equals(DefSeq)).Def_Image_Binary;
                //pictureBox1.Image = CommonUtil.ByteToImage(a);
                pictureBox1.Image = image;
               
            }
        }

            private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images Files(*.gif;*.jpg;*.jpeg;*.png;*.bmp)|*.gif;*.jpg;*.jpeg;*.png;*.bmp";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = dlg.FileName;
                pictureBox1.Image = Image.FromFile(dlg.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Tag = dlg.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            byte[] imageData = CommonUtil.ImageToByte(pictureBox1.Image);
            //byte[] imageData;

            //using (FileStream fs = new FileStream(pictureBox1.Tag.ToString(), FileMode.Open, FileAccess.Read))
            //{
            //    BinaryReader br = new BinaryReader(fs);
            //    imageData = br.ReadBytes((int)fs.Length);
            //    br.Close();
            //}
            DefectiveVO df = new DefectiveVO()
            {
                Workorderno = workOrderNum,
                Def_Seq = DefSeq,
                Def_Image_Name = txtImageName.Text,
                Up_Emp = "로그인관리자",
                Def_Image_Binary = imageData
            };
            DefectiveService service = new DefectiveService();
            bool result = service.UpdateDefImage(df);
            if (result)
            {
                MessageBox.Show("저장되었습니다.");
                if(SaveEvent != null)
                {
                    SaveEvent(this, null);
                }
            }
            else
                MessageBox.Show("저장 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("이미지를 삭제하시겠습니까?", "이미지 삭제", MessageBoxButtons.YesNo))
            {
                DefectiveVO df = new DefectiveVO()
                {
                    Workorderno = workOrderNum,
                    Def_Seq = DefSeq,
                    Up_Emp = "로그인관리자"

                };
                DefectiveService service = new DefectiveService();
                bool result = service.DeleteDefImage(df);
                if (result)
                {
                    MessageBox.Show("삭제되었습니다.");
                    if (SaveEvent != null)
                    {
                        SaveEvent(this, null);
                    }
                }
                else
                    MessageBox.Show("삭제 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");

                this.Close();
            }
        }
    }
}
