using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmDefectiveImage : FinalProject.List_List_h
    {
        frmMain frm = null;
        List<DefectiveVO> woList;
        List<DefectiveVO> detailList;
        PictureBox pc = new PictureBox();
        bool havePc = false;

        bool isBookMark = false;


        public frmDefectiveImage()
        {
            InitializeComponent();
        }

        private void frmDefectiveImage_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvInstructionList);
            CommonUtil.AddGridTextColumn(dgvInstructionList, "작업지시상태", "Wo_Status", colWidth: 196);
            CommonUtil.AddGridTextColumn(dgvInstructionList, "작업지시번호", "Workorderno", colWidth: 196, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInstructionList, "생산일자", "Prd_Date", colWidth: 196, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInstructionList, "품목코드", "Item_Code", colWidth: 196, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInstructionList, "품목명", "Item_Name", colWidth: 196);
            CommonUtil.AddGridTextColumn(dgvInstructionList, "작업장", "Wc_Name", colWidth: 196);
            CommonUtil.AddGridTextColumn(dgvInstructionList, "실적", "Prd_Qty", colWidth: 196, align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvInstructionList, "불량이미지 등록건수", "Bad_Prd_Qty", colWidth: 196, align: DataGridViewContentAlignment.MiddleRight);  //불량수량으로 이름 바꾸고 보여주는게 더 맞을듯

            CommonUtil.SetInitGridView(dgvDetailInstructionList);
            CommonUtil.AddGridTextColumn(dgvDetailInstructionList, "작업지시번호", "Workorderno", colWidth: 184, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDetailInstructionList, "품목코드", "Item_Code", colWidth: 184, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDetailInstructionList, "품목명", "Item_Name", colWidth: 183);
            CommonUtil.AddGridTextColumn(dgvDetailInstructionList, "불량대분류", "Def_Ma_Name", colWidth: 184, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDetailInstructionList, "불량상세분류", "Def_Mi_Name", colWidth: 184, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDetailInstructionList, "발생일시", "Def_Date", colWidth: 184, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDetailInstructionList, "불량수량", "Def_Qty", colWidth: 183, align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvDetailInstructionList, "불량사진명", "Def_Image_Name", colWidth: 183);
            //CommonUtil.AddGridTextColumn(dgvDetailInstructionList, "불량사진", "Def_Image_Binary");

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.HeaderText = "불량사진";
            img.DataPropertyName = "Def_Image_Binary";
            img.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dgvDetailInstructionList.Columns.Add(img);

            CommonUtil.AddGridTextColumn(dgvDetailInstructionList, "불량번호", "Def_Seq", visibility:false);

            ucPeriodControl1.dtFrom = DateTime.Now.AddDays(-3).ToShortDateString();

            //def_History 테이블 참고
            LoadData(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);

            //추가 누르면 팝업창 뜨고 불량등록과 이미지 등록할수있게
            frm = (frmMain)this.MdiParent;

            frm.Select += Frm_Select;
            frm.Insert += Frm_Insert;
            frm.Refresh += Frm_Refresh;
            frm.UpDate += Frm_UpDate;
            frm.Delete += Frm_Delete;
            frm.BookMarkReg += Frm_BookMarkReg;

            //if (frm.BookMarkList != null)
            //{
            //    foreach (string r in frm.BookMarkList)
            //    {
            //        if (this.GetType().ToString().Split('.')[1].Trim() == r.Trim())     //그냥 getType으로 하면 클래스명까지 붙어서 .으로 잘라주고 trim을 양쪽다 안하니 안나와서
            //        {
            //            frm.btnBookMarkColor = Color.Yellow;
            //            isBookMark = true;
            //        }
            //        else
            //        {
            //            frm.btnBookMarkColor = Color.Transparent;   //다른 폼으로 갔는데 거기는 즐겨찾기 아니면 다시 원래 색으로
            //        }
            //    }
            //}

        }

        private void Frm_BookMarkReg(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmDefectiveImage) && frm.ActiveMdiChild == this)
                {
                    if (frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmDefectiveImage");
                        if (result)
                        {
                            MessageBox.Show("즐겨찾기 등록되었습니다.");
                            isBookMark = true;
                            frm.btnBookMarkColor = Color.SteelBlue;
                        }
                        else
                            MessageBox.Show("즐겨찾기 등록 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
                    }
                    else
                    {
                        MenuService service = new MenuService();
                        bool result = service.DeleteBookMark(frm.UserID, "frmDefectiveImage");
                        if (result)
                        {
                            MessageBox.Show("즐겨찾기 해제되었습니다.");
                            isBookMark = false;
                            frm.btnBookMarkColor = Color.FromArgb(57, 61, 70);
                        }

                        else
                            MessageBox.Show("즐겨찾기 해제 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
                    }

                }
            }
        }

        private void LoadData(string begDate, string endDate)
        {
            DefectiveService service = new DefectiveService();
            woList = service.GetWorkOrderListwithBadCount(begDate, endDate);

            dgvInstructionList.DataSource = null;
            dgvInstructionList.DataSource = woList;

            //dgvInstructionList.Paint += DgvInstructionList_Paint;
        }

        //private void DgvInstructionList_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvInstructionList.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvInstructionList.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvInstructionList.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        private void Frm_Delete(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmDefectiveImage) && frm.ActiveMdiChild == this)
                {
                   //삭제는 불가능하게
                }
            }
        }

        private void Frm_UpDate(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmDefectiveImage) && frm.ActiveMdiChild == this)
                {
                    if(dgvDetailInstructionList.CurrentRow == null)
                    {
                        MessageBox.Show("수정할 불량상세내역을 선택해주십시오.");
                        return;
                    }
                    if(dgvDetailInstructionList.CurrentRow.Cells[7].Value == null)
                    {
                        dgvDetailInstructionList.CurrentRow.Cells[7].Value = "";
                    }
                    frmDefectiveImageRegPopUp frm = new frmDefectiveImageRegPopUp(dgvDetailInstructionList.CurrentRow.Cells[0].Value.ToString(), Convert.ToInt32(dgvDetailInstructionList.CurrentRow.Cells[9].Value), dgvDetailInstructionList.CurrentRow.Cells[7].Value.ToString(), CommonUtil.ByteToImage(detailList[dgvDetailInstructionList.CurrentRow.Index].Def_Image_Binary));
                    frm.Show();

                    frm.SaveEvent += Frm_SaveEvent;
                   

                    break;

                }
            }
        }

        private void Frm_SaveEvent(object sender, EventArgs e)
        {
            LoadData(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);
            LoadDetailData();
        }

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmDefectiveImage) && frm.ActiveMdiChild == this)
                {
                    LoadData(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);
                }
            }
        }

        private void Frm_Insert(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmDefectiveImage) && frm.ActiveMdiChild == this)
                {
                    
                    if(dgvInstructionList.CurrentRow == null)
                    {
                        MessageBox.Show("불량이미지를 추가할 작업지시를 선택해주십시오.");
                        return;
                    }       
                    if(dgvDetailInstructionList.CurrentRow == null)
                    {
                        MessageBox.Show("불량이미지를 추가할 불량품이 없습니다.");
                        return;
                    }
                    if(dgvDetailInstructionList.CurrentRow.Cells[8].Value != null)
                    {
                        MessageBox.Show("이미 이미지가 등록되어있습니다.");
                        return;
                    }
                    frmDefectiveImageRegPopUp frm = new frmDefectiveImageRegPopUp(dgvDetailInstructionList.CurrentRow.Cells[0].Value.ToString(), Convert.ToInt32(dgvDetailInstructionList.CurrentRow.Cells[9].Value));
                    frm.Show();

                    frm.SaveEvent += Frm_SaveEvent1;
                   

                    break;
                }
            }
        }

        private void Frm_SaveEvent1(object sender, EventArgs e)
        {
            LoadData(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);
            LoadDetailData();
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmDefectiveImage) && frm.ActiveMdiChild == this)
                {
                    DefectiveService service = new DefectiveService();
                    List<DefectiveVO> list = service.GetWorkOrderListwithBadCount(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);

                    if (string.IsNullOrWhiteSpace(txtItemCode.Text) && string.IsNullOrWhiteSpace(txtItemName.Text) && string.IsNullOrWhiteSpace(txtWorkPlaceCode.Text) && string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                    {
                        dgvInstructionList.DataSource = list;
                    }
                    else if (!string.IsNullOrWhiteSpace(txtItemCode.Text) && !string.IsNullOrWhiteSpace(txtItemName.Text))
                    {
                        dgvInstructionList.DataSource = list.FindAll(x => x.Item_Code.Contains(txtItemCode.Text) && x.Item_Name.Contains(txtItemName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkPlaceCode.Text) && !string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                    {
                        dgvInstructionList.DataSource = list.FindAll(x => x.Wc_Code.Contains(txtWorkPlaceCode.Text) && x.Wc_Name.Contains(txtWorkPlaceName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtItemCode.Text))
                    {
                        dgvInstructionList.DataSource = list.FindAll(x => x.Item_Code.Contains(txtItemCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtItemName.Text))
                    {
                        dgvInstructionList.DataSource = list.FindAll(x => x.Item_Name.Contains(txtItemName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkPlaceCode.Text))
                    {
                        dgvInstructionList.DataSource = list.FindAll(x => x.Wc_Code.Contains(txtWorkPlaceCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtWorkPlaceName.Text))
                    {
                        dgvInstructionList.DataSource = list.FindAll(x => x.Wc_Name.Contains(txtWorkPlaceName.Text));
                    }
                }
            }
        }

        private void LoadDetailData()
        {
            if (detailList != null)
                detailList.Clear();

            DefectiveService service = new DefectiveService();
            detailList = service.GetDetailDefInWorkOrderNum(dgvInstructionList.CurrentRow.Cells[1].Value.ToString());

            dgvDetailInstructionList.DataSource = null;
            dgvDetailInstructionList.DataSource = detailList;

            dgvDetailInstructionList.Paint += DgvDetailInstructionList_Paint;
        }

        private void DgvDetailInstructionList_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < dgvDetailInstructionList.Rows.Count; i++)
            {
                if (i % 2 != 0)
                {
                    this.dgvDetailInstructionList.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
                }
                else
                {
                    this.dgvDetailInstructionList.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void dgvInstructionList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDetailData();
        }

        private void btnProcessList_Click(object sender, EventArgs e)
        {
            frmGridPopUp frm = new frmGridPopUp("품목");
            frm.Show();

            frm.CodeName += Frm_CodeName;
        }

        private void Frm_CodeName(object sender, CodeNameArgs e)
        {
            txtItemCode.Text = e.Code;
            txtItemName.Text = e.Name;
        }

        private void btnWorkPlaceList_Click(object sender, EventArgs e)
        {
            frmGridPopUp frm = new frmGridPopUp("작업장");
            frm.Show();

            frm.CodeName += Frm_CodeName1;
        }

        private void Frm_CodeName1(object sender, CodeNameArgs e)
        {
            txtWorkPlaceCode.Text = e.Code;
            txtWorkPlaceName.Text = e.Name;
        }

        private void dgvDetailInstructionList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
           if (e.ColumnIndex == 8 && e.RowIndex < detailList.Count)
           {
                if (detailList[e.RowIndex].Def_Image_Binary != null)
                {
                    Image img = CommonUtil.ByteToImage(detailList[e.RowIndex].Def_Image_Binary);

                    //Image img = Image.FromFile(fileName);

                    e.Value = img;
                }
                else
                {
                    e.Value = e.CellStyle.NullValue;
                    e.FormattingApplied = true;
                }                    
            }

        }

        private void dgvDetailInstructionList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 8 && dgvDetailInstructionList[8, e.RowIndex].Value != null)
            {

                if (havePc == false)
                {
                    Point clickP = Cursor.Position;

                    //pc = new PictureBox();
                    pc.Name = "asdasd";
                    pc.Size = new Size(200, 200);
                    pc.Location = new Point(clickP.X - 500, clickP.Y - 700);
                    pc.SizeMode = PictureBoxSizeMode.StretchImage;
                    pc.BorderStyle = BorderStyle.FixedSingle;
                    pc.Image = CommonUtil.ByteToImage((byte[])dgvDetailInstructionList.CurrentRow.Cells[8].Value);

                    dgvDetailInstructionList.Controls.Add(pc);
                    havePc = true;
                }
                else
                {
                    dgvDetailInstructionList.Controls.Remove(pc);
                    //pc.Dispose();
                    havePc = false;
                }

                pc.Click += Pc_Click;
                //pc.Click += (obj, asd) => havePc = false;
            }
        }

        private void Pc_Click(object sender, EventArgs e)
        {
            dgvDetailInstructionList.Controls.Remove(pc);
            //pc.Dispose();
            havePc = false;
        }
    }
}
