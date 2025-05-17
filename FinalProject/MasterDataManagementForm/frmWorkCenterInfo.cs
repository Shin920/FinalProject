using FinalProject.Service;
using FinalProjectVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmWorkCenterInfo : Form
    {
        frmMain frm = null;
        List<WorkCenterVO> list;
        public frmWorkCenterInfo()
        {
            InitializeComponent();
        }

        private void frmWorkCenterInfo_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.MdiParent;
            frm.Select += Frm_Select;
            frm.Refresh += Frm_Refresh;
            frm.Delete += Frm_Delete;
            frm.Insert += Frm_Insert;
            frm.UpDate += Frm_UpDate;


            CommonUtil.SetInitGridView(dgvWCList);
            CommonUtil.AddGridTextColumn(dgvWCList, "작업장코드", "Wc_Code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvWCList, "작업장이름", "Wc_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvWCList, "공정코드", "Process_Code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvWCList, "공정이름", "Process_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvWCList, "비가동상태", "Wo_Status", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvWCList, "최종실적처리시간", "Last_Cnt_Time", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvWCList, "실적등록유형", "Prd_Req_Type", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvWCList, "팔렛생성여부", "Pallet_YN", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvWCList, "최종작업품목", "Item_Code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvWCList, "실적단위", "Prd_Unit", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvWCList, "금형장착여부", "Mold_Setup_YN", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvWCList, "사용여부", "Use_YN", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvWCList, "비고", "Remark", colWidth: 100);

            //사용여부 변경버튼 생성
            DataGridViewButtonColumn btnCell = new DataGridViewButtonColumn();

            btnCell.HeaderText = "사용여부";
            btnCell.Text = "변경";
            btnCell.Width = 110;
            btnCell.FlatStyle = FlatStyle.Standard;
            /*btnCell.DefaultCellStyle.Padding = new Padding(2, 2, 2, 2);*/     //이 간격은 없어도 될듯
            btnCell.CellTemplate.Style.BackColor = Color.White;
            btnCell.UseColumnTextForButtonValue = true;

            dgvWCList.Columns.Add(btnCell);

            LoadData();

            cboWCName.SelectedIndex = 0;
        }

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmWorkCenterInfo) && frm.ActiveMdiChild == this)
                {
                    LoadData();
                }
            }

        }

        private void Frm_Insert(object sender, EventArgs e)
        {

            if (frm.ActiveMdiChild == this)
            {
                frmAddWorkplace newForm = new frmAddWorkplace();
                newForm.no = null;
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("등록 완료");
                    LoadData();
                }
            }

        }

        private void Frm_Delete(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmWorkCenterInfo) && frm.ActiveMdiChild == this)
                {
                    DialogResult dr = MessageBox.Show($"{dgvWCList.CurrentRow.Cells[1].Value.ToString()}을 삭제하시겠습니까?", "작업장 삭제", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        WorkCenterService service = new WorkCenterService();
                        bool result = service.DeleteWorkCenter(dgvWCList.CurrentRow.Cells[0].Value.ToString());
                        if (result)
                            MessageBox.Show("삭제되었습니다.");
                        else
                            MessageBox.Show("삭제 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
                    }

                }
            }
            LoadData();
        }

        private void Frm_UpDate(object sender, EventArgs e)
        {
            // 새 창에서 추가 로직


            if (frm.ActiveMdiChild == this)
            {
                frmAddWorkplace newForm = new frmAddWorkplace();
                if (lblCode.Text == "")
                {
                    MessageBox.Show("수정할 작업장을 선택하세요");
                }
                else
                {
                    newForm.no = list.Find(x => x.Wc_Code.Contains(lblCode.Text));
                    if (newForm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("수정 완료");
                    }
                }
            }


        }




        private void Frm_Select(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmWorkCenterInfo) && frm.ActiveMdiChild == this)
                {
                    if (rdoName.Checked) // 작업장명에 체크
                    {
                        if (cboWCName.SelectedIndex <= 0 && string.IsNullOrWhiteSpace(txtWCCode.Text))
                        {
                            MessageBox.Show("검색하실 조건을 입력해주십시오.");
                        }
                        else if (cboWCName.SelectedIndex > 0 && !string.IsNullOrWhiteSpace(txtWCCode.Text))
                        {
                            List<WorkCenterVO> findList = list.FindAll(x => x.Wc_Code.Contains(txtWCCode.Text) && x.Wc_Name.Equals(cboWCName.SelectedValue.ToString()));
                            if (findList.Count < 1)
                                MessageBox.Show("검색된 데이터가 없습니다.");
                            else
                            {
                                dgvWCList.DataSource = null;
                                dgvWCList.DataSource = findList;

                            }

                        }
                        else if (!string.IsNullOrWhiteSpace(txtWCCode.Text))
                        {
                            List<WorkCenterVO> findList = list.FindAll(x => x.Wc_Code.Contains(txtWCCode.Text));
                            if (findList.Count < 1)
                                MessageBox.Show("검색된 데이터가 없습니다.");
                            else
                            {
                                dgvWCList.DataSource = null;
                                dgvWCList.DataSource = findList;
                            }

                        }
                        else if (cboWCName.SelectedIndex > 0)
                        {
                            List<WorkCenterVO> findList = list.FindAll(x => x.Wc_Name.Equals(cboWCName.SelectedItem));
                            if (findList.Count < 1)
                                MessageBox.Show("검색된 데이터가 없습니다.");
                            else
                            {
                                dgvWCList.DataSource = null;
                                dgvWCList.DataSource = findList;
                            }

                        }
                    }
                    else // 공정쪽 체크
                    {
                        if (!string.IsNullOrWhiteSpace(txtProcess.Text))
                        {
                            List<WorkCenterVO> findList = list.FindAll(x => x.Process_Name.Contains(txtProcess.Text));
                            if (findList.Count < 1)
                                MessageBox.Show("검색된 데이터가 없습니다.");
                            else
                            {
                                dgvWCList.DataSource = null;
                                dgvWCList.DataSource = findList;
                            }

                        }
                    }

                }
            }
        }


        private void dgvWCList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            lblCode.Text = dgvWCList[0, dgvWCList.CurrentRow.Index].Value.ToString();

            if (e.ColumnIndex == 13)  //사용여부 변경버튼
            {
                //MessageBox.Show(dgvGroup[3, e.RowIndex].Value.ToString());

                //해당로우의 데이터부분을 DB에 사용여부N으로 업데이트 시키기
                string use;
                if (dgvWCList[11, e.RowIndex].Value.ToString() == "Y")
                    use = "N";
                else
                    use = "Y";

                WorkCenterService service = new WorkCenterService();
                bool result = service.UseYNSwap(use, dgvWCList[0, e.RowIndex].Value.ToString());

                if (result)
                {
                    MessageBox.Show("변경되었습니다.");
                    LoadData();
                }
                else
                    MessageBox.Show("변경 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
            }

        }

        private void LoadData()
        {
            WorkCenterService service = new WorkCenterService();
            list = service.GetWorkCenterList();

            dgvWCList.DataSource = null;
            dgvWCList.DataSource = list;


            //콤보박스 바인딩
            cboWCName.Items.Clear();
            foreach (WorkCenterVO no in list)
            {
                cboWCName.Items.Add(no.Wc_Name);
            }
            cboWCName.Items.Insert(0, "선택");   //빈값으로 된것도 주려고 (선택없음 역할)
        }

        private void rdoName_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoName.Checked)
            {
                rdoProcess.Checked = false;
            }
            else
            {
                rdoProcess.Checked = true;
            }
        }

        private void rdoProcess_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoProcess.Checked)
            {
                rdoName.Checked = false;
            }
            else
            {
                rdoName.Checked = true;
            }
        }
    }
}
