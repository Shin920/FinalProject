using FinalProject.Service;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace FinalProject
{
    public partial class frmCreateFigurationTask : FinalProject.List_List_h
    {
        frmMain frm = null;
        CheckBox chbox = new CheckBox();
        List<WorkReqVO> list;
        List<WorkOrderVO> wolist;

        string val;
        WorkReqVO vo;

       
        public frmCreateFigurationTask()
        {
            InitializeComponent();
        }

        private void frmCreateFigurationTask_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.MdiParent;
            frm.Insert += Frm_Insert;
            frm.Select += Frm_Select;
            frm.Refresh += Frm_Refresh;

            dtpFdate.Value = dtpLdate.Value.AddMonths(-1);

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "선택";
            chk.Name = "chk";
            chk.Width = 40;
            dgvRequest.Columns.Add(chk);


            CommonUtil.SetInitGridView(dgvRequest);
            CommonUtil.AddGridTextColumn(dgvRequest, "생산의뢰번호", "Wo_Req_No", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvRequest, "의뢰일자", "Ins_Date", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvRequest, "품목코드", "Item_Code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvRequest, "품목명", "Item_Name", colWidth: 150);
            CommonUtil.AddGridTextColumn(dgvRequest, "의뢰수량", "Req_Qty", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvRequest, "프로젝트명", "Project_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvRequest, "거래처명", "Cust_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvRequest, "영업담당", "Sale_Emp", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvRequest, "생산의뢰상태", "Req_Status", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvRequest, "생산완료예정일", "Prd_Plan_Date", colWidth: 130);

            CommonUtil.SetInitGridView(dgvOrder);
            CommonUtil.AddGridTextColumn(dgvOrder, "생산의뢰번호", "Wo_Req_No", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업지시상태", "Wo_Status", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업지시번호", "Workorderno", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업지시일자", "Plan_Date", colWidth: 150);
            CommonUtil.AddGridTextColumn(dgvOrder, "품목코드", "Item_Code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "품목명", "Item_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "작업장명", "Wc_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "계획수량", "Plan_Qty", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvOrder, "투입수량", "In_Qty_Main", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "산출수량", "Out_Qty_Main", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "생산수량", "Prd_Qty", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvOrder, "비고", "Remark", colWidth: 130);

            LoadData();
        }

        private void LoadData()
        {
            WorkReqService service = new WorkReqService();
            list = service.GetWorkReqList();

            dgvRequest.DataSource = null;
            dgvRequest.DataSource = list;

            WorkOrderService woservice = new WorkOrderService();
            wolist = woservice.GetWorkOrderList();

            dgvOrder.DataSource = null;
            dgvOrder.DataSource = wolist;
        }

        private void dgvRequest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //체크 중복 안되게
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                foreach (DataGridViewRow row in dgvRequest.Rows)
                {
                    if (row.Index == e.RowIndex)
                    {
                        row.Cells["chk"].Value = !Convert.ToBoolean(row.Cells["chk"].EditedFormattedValue);
                    }
                    else
                    {
                        row.Cells["chk"].Value = false;
                    }
                    //  체크된값 할당
                    if (Convert.ToBoolean(row.Cells["chk"].Value))// Select is the name 
                                                                  //of chkbox column
                    {
                        row.Selected = true;
                        val = row.Cells[1].Value.ToString();
                    }
                    else
                    {
                        row.Selected = false;
                    }

                    vo = list.Find(x => x.Wo_Req_No.Equals(val));

                }
            }



        }

        private void Frm_Insert(object sender, EventArgs e)
        {
            if (frm.ActiveMdiChild == this)
            {
                if (dgvRequest.CurrentRow.Cells[9].Value.ToString() == "대기")
                {

                    frmAddCreateFigurationTask newForm = new frmAddCreateFigurationTask();
                    if (vo != null)
                    {
                        newForm.selWorkReq = vo;
                    }

                    else
                    {
                        MessageBox.Show("선택된 생산의뢰건이 없습니다.");
                        return;
                    }

                    if (newForm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("생성 완료");
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("진행중이거나 완료된 작업입니다.");
                    return;
                }
            }
        }

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmCreateFigurationTask) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                }
            }

        }

        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmCreateFigurationTask) && frm.ActiveMdiChild == this)
                {

                    WorkReqService service = new WorkReqService();
                    list = service.SearchWorkReqList(dtpFdate.Value.ToString("yyyy-MM-dd"), dtpLdate.Value.ToString("yyyy-MM-dd"));
                    dgvRequest.DataSource = null;
                    dgvRequest.DataSource = list;

                }
            }
        }



        private void btnReqFin_Click(object sender, EventArgs e)
        {
            WorkReqService service = new WorkReqService();
            bool result = service.FinishWorkReq(dgvRequest.CurrentRow.Cells[1].Value.ToString());
            if (result)
            {
                MessageBox.Show("마감되었습니다.");
                LoadData();
            }
            else
                MessageBox.Show("마감 실패");

        }

        private void getExcelFile(DataGridView dgv)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel Files(*.xls)|*.xls";
            dlg.Title = "엑셀파일로 내보내기";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                //DataTable dt = (DataTable)dgv.DataSource; 오류로 개별함수 사용
                DataTable dt = GetDataGridViewAsDataTable(dgv);





                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    xlWorkSheet.Cells[1, c + 1] = dt.Columns[c].ColumnName;
                }

                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int c = 0; c < dt.Columns.Count; c++)
                    {
                        xlWorkSheet.Cells[r + 2, c + 1] = dt.Rows[r][c].ToString();
                    }
                }

                xlWorkBook.SaveAs(dlg.FileName, Excel.XlFileFormat.xlWorkbookNormal);
                xlWorkBook.Close(true);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("다운로드 완료");

            }
                      


        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        public static DataTable GetDataGridViewAsDataTable(DataGridView _DataGridView) //그리드뷰 소스를 DataTable로
        {
            try
            {
                if (_DataGridView.ColumnCount == 0)
                    return null;
                DataTable dtSource = new DataTable();
                // 컬럼 만듦
                foreach (DataGridViewColumn col in _DataGridView.Columns)
                {
                    if (col.ValueType == null)
                        dtSource.Columns.Add(col.Name, typeof(string));
                    else
                        dtSource.Columns.Add(col.Name, col.ValueType);
                    dtSource.Columns[col.Name].Caption = col.HeaderText;
                }
                // 열 데이터 삽입
                foreach (DataGridViewRow row in _DataGridView.Rows)
                {
                    DataRow drNewRow = dtSource.NewRow();
                    foreach (DataColumn col in dtSource.Columns)
                    {
                        drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
                    }
                    dtSource.Rows.Add(drNewRow);
                }
                return dtSource;
            }
            catch
            {
                return null;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            getExcelFile(dgvRequest);
        }
    }
}
