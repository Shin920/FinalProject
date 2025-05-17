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
    public partial class frmCarriageStatus : FinalProject.List
    {
        frmMain frm = null;
        List<CarriageVO> crList;

        bool isBookMark = false;
        public frmCarriageStatus()
        {
            InitializeComponent();
        }

        private void frmCarriageStatus_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvCarriageCondition);
            CommonUtil.AddGridTextColumn(dgvCarriageCondition, "대차코드", "GV_Code", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageCondition, "대차명", "GV_Name");
            CommonUtil.AddGridTextColumn(dgvCarriageCondition, "작업지시번호", "Workorderno", colWidth: 140, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageCondition, "품목코드", "Item_Code", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageCondition, "품목명", "Item_Name");
            CommonUtil.AddGridTextColumn(dgvCarriageCondition, "대차상태", "GV_Status");    //언로딩 시간이 있으면 빈대차, 없으면 적재 인데 이 컬럼에 값을 pop에서 주는지?
            CommonUtil.AddGridTextColumn(dgvCarriageCondition, "대차수량", "GV_Qty", align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvCarriageCondition, "로딩일자", "Loading_date", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageCondition, "로딩시간", "Loading_time", colWidth: 140, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageCondition, "로딩작업장", "Loading_Wc", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageCondition, "언로딩일자", "Unloading_date", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageCondition, "언로딩일시", "Unloading_datetime", colWidth: 140, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageCondition, "언로딩작업장", "Unloading_wc", align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageCondition, "요입시간", "In_Time", colWidth: 140, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageCondition, "중간시간", "Center_Time", colWidth: 140, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCarriageCondition, "요출시간", "Out_Time", colWidth: 140, align: DataGridViewContentAlignment.MiddleCenter);

            LoadData();

            frm = (frmMain)this.MdiParent;

            frm.Select += Frm_Select;
            frm.Refresh += Frm_Refresh;
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
                if (fr.GetType() == typeof(frmCarriageStatus) && frm.ActiveMdiChild == this)
                {
                    if (frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmCarriageStatus");
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
                        bool result = service.DeleteBookMark(frm.UserID, "frmCarriageStatus");
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

        private void LoadData()
        {
            //대차를 사용하면 바로 대차이력으로 가는지 대차현황으로 가는지..? 근데 아마 대차사용 시작하면 현황으로 데이터가 오지않을까싶다.
            //그러면 현황에 일단 대차별로 가장 최근 사용이력을 보여주면 될듯
            CarriageService service = new CarriageService();
            crList = service.GetCarriageStatusList();

            dgvCarriageCondition.DataSource = null;
            dgvCarriageCondition.DataSource = crList;

            //dgvCarriageCondition.Paint += DgvCarriageCondition_Paint;

            foreach(CarriageVO cv in crList)    //그룹의 중복을 제거해서 콤보박스에 넣는것
            {             
                if(comboBox1.Items.IndexOf(cv.GV_Group) == -1)
                {
                    comboBox1.Items.Add(cv.GV_Group);
                }
            }
            comboBox1.Items.Insert(0, "");
            
        }

        //private void DgvCarriageCondition_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvCarriageCondition.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvCarriageCondition.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvCarriageCondition.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmCarriageStatus) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                }
            }
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmCarriageStatus) && frm.ActiveMdiChild == this)
                {
                    
                    if (comboBox1.SelectedIndex == 0 && string.IsNullOrWhiteSpace(txtCarriageName.Text) && string.IsNullOrWhiteSpace(txtProductCode.Text) && string.IsNullOrWhiteSpace(txtProductName.Text))
                    {
                        dgvCarriageCondition.DataSource = crList;
                    }
                    else if (comboBox1.SelectedIndex > 0 && !string.IsNullOrWhiteSpace(txtCarriageName.Text))
                    {
                        dgvCarriageCondition.DataSource = crList.FindAll(x => x.GV_Group.Contains(comboBox1.SelectedItem.ToString()) && x.GV_Name.Contains(txtCarriageName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProductCode.Text) && !string.IsNullOrWhiteSpace(txtProductName.Text))
                    {
                        dgvCarriageCondition.DataSource = crList.FindAll(x => x.Item_Code.Contains(txtProductCode.Text) && x.Item_Name.Contains(txtProductName.Text));
                    }
                    else if (comboBox1.SelectedIndex > 0)
                    {
                        dgvCarriageCondition.DataSource = crList.FindAll(x => x.GV_Group.Contains(comboBox1.SelectedItem.ToString()));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtCarriageName.Text))
                    {
                        dgvCarriageCondition.DataSource = crList.FindAll(x => x.GV_Name.Contains(txtCarriageName.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProductCode.Text))
                    {
                        dgvCarriageCondition.DataSource = crList.FindAll(x => x.Item_Code.Contains(txtProductCode.Text));
                    }
                    else if (!string.IsNullOrWhiteSpace(txtProductName.Text))
                    {
                        dgvCarriageCondition.DataSource = crList.FindAll(x => x.Item_Name.Contains(txtProductName.Text));
                    }
                }
            }
        }

        private void btnCarriageGroupList_Click(object sender, EventArgs e)
        {
            frmGridPopUp frm = new frmGridPopUp("대차그룹");
            frm.Show();

            frm.CodeName += Frm_CodeName;
        }

        private void Frm_CodeName(object sender, CodeNameArgs e)
        {
            //txtGroupName.Text = e.Code;
            txtCarriageName.Text = e.Name;
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            frmGridPopUp frm = new frmGridPopUp("품목");
            frm.Show();

            frm.CodeName += Frm_CodeName1;
        }

        private void Frm_CodeName1(object sender, CodeNameArgs e)
        {
            txtProductCode.Text = e.Code;
            txtProductName.Text = e.Name;
        }
    }
}
