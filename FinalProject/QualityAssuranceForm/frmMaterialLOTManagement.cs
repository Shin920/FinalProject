using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmMaterialLOTManagement : FinalProject.List
    {
        frmMain frm = null;
        bool isBookMark = false;
        public frmMaterialLOTManagement()
        {
            InitializeComponent();
        }

        private void frmMaterialLOTManagement_Load(object sender, EventArgs e)
        {
            nmrYear.Value = Convert.ToDecimal(DateTime.Now.ToString("yyyy"));
         
            CommonUtil.SetInitGridView(dgvLOT);
            CommonUtil.AddGridTextColumn(dgvLOT, "품목코드", "Item_Code", colWidth:262, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvLOT, "품목명", "Item_Name", colWidth: 262);
            CommonUtil.AddGridTextColumn(dgvLOT, "품목유형", "Item_Type", colWidth: 262);
            CommonUtil.AddGridTextColumn(dgvLOT, "사양", "Item_Spec", colWidth: 262);
            CommonUtil.AddGridTextColumn(dgvLOT, "단위", "Item_Unit", colWidth: 262);
            CommonUtil.AddGridTextColumn(dgvLOT, "LOT", "LotSize", colWidth: 262, align: DataGridViewContentAlignment.MiddleRight);

            LoadData(nmrYear.Value.ToString());

            frm = (frmMain)this.MdiParent;

            frm.Select += Frm_Select;
            frm.Refresh += Frm_Refresh;           
            frm.BookMarkReg += Frm_BookMarkReg;

            //if(frm.BookMarkList != null)
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
                if (fr.GetType() == typeof(frmMaterialLOTManagement) && frm.ActiveMdiChild == this)
                {
                    if(frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmMaterialLOTManagement");
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
                        bool result = service.DeleteBookMark(frm.UserID, "frmMaterialLOTManagement");
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
     

        private void LoadData(string year)
        {
            BoxingService service = new BoxingService();
            DataTable dt = service.GetLOTList(year);

            dgvLOT.DataSource = null;
            dgvLOT.DataSource = dt;

            //dgvLOT.Paint += DgvLOT_Paint;

            //MessageBox.Show(this.GetType().ToString());
            
        }

        //private void DgvLOT_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvLOT.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvLOT.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvLOT.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMaterialLOTManagement) && frm.ActiveMdiChild == this)
                {
                    LoadData(nmrYear.Value.ToString());
                }
            }
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMaterialLOTManagement) && frm.ActiveMdiChild == this)
                {
                    LoadData(nmrYear.Value.ToString());
                }
            }
        }
    }
}
