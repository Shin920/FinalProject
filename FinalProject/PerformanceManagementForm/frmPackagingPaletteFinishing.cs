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
    public partial class frmPackagingPaletteFinishing : FinalProject.List_List_h
    {
        frmMain frm = null;
        CheckBox chbox = new CheckBox();
        CheckBox chbox2 = new CheckBox();

        bool isBookMark = false;

        List<WorkOrderVO> woList;
        public frmPackagingPaletteFinishing()
        {
            InitializeComponent();
        }

        private void frmPackagingPaletteFinishing_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Name = "chk";
            chk.Width = 30;
            dgvProductionList.Columns.Add(chk);

            Point headerPoint = dgvProductionList.GetCellDisplayRectangle(0, -1, true).Location;
            chbox.Location = new Point(headerPoint.X +7, headerPoint.Y + 4);
            chbox.Size = new Size(18, 18);
            chbox.BackColor = Color.White;
            chbox.Click += Chbox_Click;
            dgvProductionList.Controls.Add(chbox);

            CommonUtil.SetInitGridView(dgvProductionList);
            CommonUtil.AddGridTextColumn(dgvProductionList, "생산일자", "Prd_Date", colWidth: 171, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvProductionList, "작업상태", "Wo_Status", colWidth: 171);   
            CommonUtil.AddGridTextColumn(dgvProductionList, "작업지시번호", "Workorderno", colWidth: 171, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvProductionList, "품목코드", "Item_Code", colWidth: 171, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvProductionList, "품목명", "Item_Name", colWidth: 171);
            CommonUtil.AddGridTextColumn(dgvProductionList, "작업장", "Wc_Name", colWidth: 171);
            CommonUtil.AddGridTextColumn(dgvProductionList, "투입수량", "In_Qty_Main", colWidth: 171, align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvProductionList, "산출수량", "Out_Qty_Main", colWidth: 171, align: DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvProductionList, "생산수량", "Prd_Qty", colWidth: 171, align: DataGridViewContentAlignment.MiddleRight);

            DataGridViewCheckBoxColumn chk2 = new DataGridViewCheckBoxColumn();
            chk2.HeaderText = "";
            chk2.Name = "chk2";
            chk2.Width = 30;
            dgvPalleteList.Columns.Add(chk2);

            Point headerPoint2 = dgvPalleteList.GetCellDisplayRectangle(0, -1, true).Location;
            chbox2.Location = new Point(headerPoint2.X + 7, headerPoint2.Y + 4);
            chbox2.Size = new Size(18, 18);
            chbox2.BackColor = Color.White;
            chbox2.Click += Chbox2_Click;
            dgvPalleteList.Controls.Add(chbox2);

            CommonUtil.SetInitGridView(dgvPalleteList);
            CommonUtil.AddGridTextColumn(dgvPalleteList, "팔렛트번호", "Pallet_No", colWidth: 257, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPalleteList, "등급", "Grade_Code", colWidth: 257, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPalleteList, "등급상세 코드", "Grade_Detail_Code", colWidth: 257, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPalleteList, "등급상세명", "Grade_Detail_Name", colWidth: 257);
            //CommonUtil.AddGridTextColumn(dgvPalleteList, "최대 적재량", "Tot_Qty", colWidth: 170);
            //CommonUtil.AddGridTextColumn(dgvPalleteList, "현재 적재량", "Load_Qty", colWidth: 170);
            //CommonUtil.AddGridTextColumn(dgvPalleteList, "잔여 적재량", "Rest_Qty", colWidth: 170);
            CommonUtil.AddGridTextColumn(dgvPalleteList, "ERP 업로드 여부", "Upload_Flag", colWidth: 255, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPalleteList, "팔렛트 마감 여부", "In_YN", colWidth: 255, align: DataGridViewContentAlignment.MiddleCenter);  //입고여부에 따라
            CommonUtil.AddGridTextColumn(dgvPalleteList, "팔레트 일련번호", "Seq", visibility:false);


            ucPeriodControl1.dtFrom = DateTime.Now.AddDays(-3).ToShortDateString();
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
                if (fr.GetType() == typeof(frmPackagingPaletteFinishing) && frm.ActiveMdiChild == this)
                {
                    if (frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmPackagingPaletteFinishing");
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
                        bool result = service.DeleteBookMark(frm.UserID, "frmPackagingPaletteFinishing");
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
            WorkOrderService service = new WorkOrderService();
            woList = service.GetWorkOrderHistoryInPallete(ucPeriodControl1.dtFrom, ucPeriodControl1.dtTo);

            dgvProductionList.DataSource = null;
            dgvProductionList.DataSource = woList;

            //dgvProductionList.Paint += DgvProductionList_Paint;

         
            int rowIndex = -1;
            if (!string.IsNullOrWhiteSpace(lblworkOrderNum.Text))
            {
                foreach (DataGridViewRow row in dgvProductionList.Rows)
                {
                    if (row.Cells[3].Value.ToString().Contains(lblworkOrderNum.Text))
                    {
                        dgvProductionList.ClearSelection();
                        rowIndex = row.Index;
                        //dgvProduct.CurrentCell = dgvProduct.Rows[rowIndex].Cells[0];  //이렇게 하면 한개까지만 선택이 되서 아래처럼 Selected True하니까 여러개까지 가능
                        dgvProductionList.Rows[rowIndex].Selected = true;
                        break;    //한개만 찾는거면 찾으면 break로 바로 나가주는게 좋은데 contains로 포함하는 모든 애들을 찾을거라 중간에 나가는거 없이 하는것
                    }

                }
                //dgvPalleteList.DataSource = null;
                //dgvPalleteList.DataSource = .FindAll(x => x.Nop_Ma_Code.Equals(dgvGroup[0, rowIndex].Value.ToString()));
                //lblworkOrderNum.Text = "";
                //return;

            }
            //dgvDetailGroup.DataSource = null;
            //dgvDetailGroup.DataSource = nopDetailList.FindAll(x => x.Nop_Ma_Code.Equals(dgvGroup.CurrentRow.Cells[0].Value.ToString()));


        }

        //private void DgvProductionList_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvProductionList.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvProductionList.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvProductionList.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmPackagingPaletteFinishing) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                    dgvPalleteList.DataSource = null;
                    lblworkOrderNum.Text = "";
                }
            }
        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmPackagingPaletteFinishing) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                    lblworkOrderNum.Text = "";

                }
            }
        }

        

        private void Chbox2_Click(object sender, EventArgs e)
        {
            dgvPalleteList.EndEdit();
            //endEdit이란 그리드뷰에 포커스가 가있어서 편집상태가 되어있을때 오류나 값이 이상하게 되버리는데
            //이건 다른 셀을 클릭해서 편집상태를 끝냈다는 효과를 주는 메서드이다.
            foreach (DataGridViewRow row in dgvPalleteList.Rows)
            {
                DataGridViewCheckBoxCell box = (DataGridViewCheckBoxCell)row.Cells["chk2"];
                box.Value = chbox2.Checked;
            }
        }

        private void Chbox_Click(object sender, EventArgs e)
        {
            dgvProductionList.EndEdit();
            //endEdit이란 그리드뷰에 포커스가 가있어서 편집상태가 되어있을때 오류나 값이 이상하게 되버리는데
            //이건 다른 셀을 클릭해서 편집상태를 끝냈다는 효과를 주는 메서드이다.
            foreach (DataGridViewRow row in dgvProductionList.Rows)
            {
                DataGridViewCheckBoxCell box = (DataGridViewCheckBoxCell)row.Cells["chk"];
                box.Value = chbox.Checked;
            }
        }

        private void dgvProductionList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BoxingService service = new BoxingService();
            List<BoxingVO_Info> list = service.GetUsedPalleteList(dgvProductionList[3, e.RowIndex].Value.ToString());
            lblworkOrderNum.Text = dgvProductionList[3, e.RowIndex].Value.ToString();

            dgvPalleteList.DataSource = null;
            dgvPalleteList.DataSource = list;

            //dgvPalleteList.Paint += DgvPalleteList_Paint;
        }

        //private void DgvPalleteList_Paint(object sender, PaintEventArgs e)
        //{
        //    for (int i = 0; i < dgvPalleteList.Rows.Count; i++)
        //    {
        //        if (i % 2 != 0)
        //        {
        //            this.dgvPalleteList.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
        //        }
        //        else
        //        {
        //            this.dgvPalleteList.Rows[i].DefaultCellStyle.BackColor = Color.White;
        //        }
        //    }
        //}

        private void btnFinishInstruction_Click(object sender, EventArgs e)
        {
            List<string> chklist = new List<string>();
            int i;
            for (i = 0; i < dgvProductionList.Rows.Count; i++)
            {
                bool isChecked = (bool)dgvProductionList[0, i].EditedFormattedValue;

                if (isChecked)
                {
                    if (dgvProductionList[2, i].Value.ToString() == "생산대기" || dgvProductionList[2, i].Value.ToString() == "생산중지" || dgvProductionList[2, i].Value.ToString() == "생산중")
                    {
                        MessageBox.Show("현장마감이 되지않은 작업지시가 포함되어있습니다.");
                        return;
                    }
                    else if (dgvProductionList[2, i].Value.ToString() == "작업지시마감")
                    {
                        MessageBox.Show("이미 마감된 작업지시가 포함되어있습니다.");
                        return;
                    }

                    chklist.Add($"'{dgvProductionList[3, i].Value.ToString()}'");     //문자열마다 ' '가 있어야 쿼리문의 파라미터로 들어갈때 ' '가 붙어서 들어가진다.
                }
                   
            }
            string str = (string.Join(",", chklist));

            if(chklist.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show($"체크한 항목들을 마감하시겠습니까?", "작업지시 마감", MessageBoxButtons.YesNo))
                {
                   
                    BoxingService service2 = new BoxingService();
                    bool result = service2.FinishAllCheckList(str);
                    if (result)
                    {
                        MessageBox.Show("작업지시를 마감하였습니다.");
                        LoadData();
                        dgvPalleteList.DataSource = null;
                    }
                    else
                        MessageBox.Show("작업지시를 마감하던 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");

                }
                return;
            }

            if (dgvProductionList.CurrentRow.Cells[2].Value.ToString() == "생산대기" || dgvProductionList.CurrentRow.Cells[2].Value.ToString() == "생산중지" || dgvProductionList.CurrentRow.Cells[2].Value.ToString() == "생산중")
            {
                MessageBox.Show("현장마감이 되지않은 작업지시가 포함되어있습니다.");
                return;
            }

            BoxingService service = new BoxingService();
            List<BoxingVO_Info> list = service.GetUsedPalleteList(dgvProductionList.CurrentRow.Cells[3].Value.ToString());
            foreach(BoxingVO_Info box in list)
            {
                if(box.In_YN == "N")
                {
                    MessageBox.Show("해당 작업지시에 마감되지 않은 팔렛트가 있습니다.\n작업지시 마감은 팔렛트가 모두 마감되어야합니다.");
                    return;
                }
            }
            //작업지시번호로 작업지시 마감하기
            if (DialogResult.Yes == MessageBox.Show($"{dgvProductionList.CurrentRow.Cells[3].Value.ToString()}를 마감하시겠습니까?", "작업지시 마감", MessageBoxButtons.YesNo))
            {
                if(dgvProductionList.CurrentRow.Cells[2].Value.ToString() == "작업지시마감")
                {
                    MessageBox.Show("이미 마감된 작업입니다.");
                    return;
                }
                bool result = service.FinishWorkOrder(dgvProductionList.CurrentRow.Cells[3].Value.ToString());

                if (result)
                {
                    MessageBox.Show("해당 작업을 마감하였습니다.");
                    LoadData();
                    lblworkOrderNum.Text = "";
                }
                else
                    MessageBox.Show("마감 처리 중 오류가 발생하였습니다. 다시 시도하여 주십시오.");
            }
            

        }

       
        private void btnFinishPallete_Click(object sender, EventArgs e)
        {
            List<string> chklist = new List<string>();
            int i;
            for (i = 0; i < dgvPalleteList.Rows.Count; i++)
            {
                bool isChecked = (bool)dgvPalleteList[0, i].EditedFormattedValue;

                if (isChecked)
                {
                    chklist.Add($"'{dgvPalleteList[1, i].Value.ToString()}'");     //문자열마다 ' '가 있어야 쿼리문의 파라미터로 들어갈때 ' '가 붙어서 들어가진다.
                }

            }
            string str = (string.Join("','", chklist));

            if (dgvPalleteList.CurrentRow == null)
            {
                MessageBox.Show("마감할 팔렛트를 선택해주십시오.");
                return;
            }
            if (dgvPalleteList.CurrentRow.Cells[6].Value.ToString() == "Y")    //팔레트가 마감된 경우 수정불가 (입고여부가 Y, 입고된거면 수정x)
            {
                MessageBox.Show("이미 마감된 팔렛트입니다.");
                return;
            }
         
           
            if (DialogResult.Yes == MessageBox.Show($"{dgvPalleteList.CurrentRow.Cells[1].Value.ToString()}를 마감하시겠습니까?", "팔렛트 마감",MessageBoxButtons.YesNo))
            {
                bool result;
                BoxingService service = new BoxingService();
                if(str.Length > 0)
                    result = service.FinishPallete(lblworkOrderNum.Text, str, "로그인관리자");
                else
                    result = service.FinishPallete(lblworkOrderNum.Text, $"'{dgvPalleteList.CurrentRow.Cells[1].Value.ToString()}'", "로그인관리자");

                if (result)
                {
                    MessageBox.Show("정상적으로 마감되었습니다.");   
                    List<BoxingVO_Info> list = service.GetUsedPalleteList(lblworkOrderNum.Text);                      

                    dgvPalleteList.DataSource = null;
                    dgvPalleteList.DataSource = list;
                }
                else
                    MessageBox.Show("마감 처리 중 오류가 발생하였습니다. 다시 시도하여 주십시오.");
            }
            
        }

        private void btnModifyGrade_Click(object sender, EventArgs e)
        {
            if (dgvPalleteList.CurrentRow == null)
            {
                MessageBox.Show("수정하실 항목을 선택해주십시오.");
                return;
            }
            if (dgvPalleteList.CurrentRow.Cells[6].Value == null)
                return;
            if(dgvPalleteList.CurrentRow.Cells[6].Value.ToString() == "Y")    //팔레트가 마감된 경우 수정불가 (입고여부가 Y, 입고된거면 수정x)
            {
                MessageBox.Show("마감된 팔렛트는 수정이 불가합니다.");
                return;
            }
            //작업지시번호랑 팔레트번호 넘기기
            
            frmPalleteModifyRating frm = new frmPalleteModifyRating(lblworkOrderNum.Text, dgvPalleteList.CurrentRow.Cells[1].Value.ToString(), dgvPalleteList.CurrentRow.Cells[4].Value.ToString());
            frm.ShowDialog();   //이벤트 쓰기 번거로워서 다이얼로그 창으로 해서 닫으면 다음 구문으로 넘어가니까 이렇게 했다.

            LoadData();

            BoxingService service = new BoxingService();
            List<BoxingVO_Info> list = service.GetUsedPalleteList(lblworkOrderNum.Text);           

            dgvPalleteList.DataSource = null;
            dgvPalleteList.DataSource = list;

            lblworkOrderNum.Text = "";


        }
    }
}
