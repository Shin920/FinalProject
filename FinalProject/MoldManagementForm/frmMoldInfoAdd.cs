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
    public partial class frmMoldInfoAdd : Form
    {
        frmMain frm = null;
        List<MoldVO> moldList;
        List<MoldVO> moldSearchList;
        MoldService service = new MoldService();
        List<MoldVO> moldGroup;
        DataSet ds = new DataSet();

        public frmMoldInfoAdd()
        {
            InitializeComponent();
        }

        private void frmMoldInfoAdd_Load(object sender, EventArgs e)
        {
           frm = (frmMain)this.MdiParent; //함수에 전달해주기위해 
            frm.Select += OnSelect; //조회
            frm.Refresh += OnRefresh; //새로고침
            frm.Delete += OnDelete; //삭제
            frm.Insert += OnInsert;//등록
 
            //데이터 그리드뷰
            MainLoad();
            //전체항목보여주기
            moldList = service.GetMoldList(); //금형리스트
            moldGroup = service.selectMoldGroup(); //금형그룹조회
            dgvMoldList.DataSource = moldList;
          //  ds = service.MoldWorkCenter();// 금형정보 등록에 필요한 작업장정보 조회
            ComboBinding();
            txtCode1.Focus();

        }

        private void ComboBinding()
        {
            cboMoldcode.Items.Insert(0, "선택");
            cboMoldcode.SelectedIndex = 0;
            foreach (var item in moldGroup)
            {
                cboMoldcode.Items.Add(item.Mold_Group);
            }

            cboWorkCenter.DisplayMember = "Wc_Name";
            cboWorkCenter.ValueMember = "Wc_Code";
            cboWorkCenter.DataSource = ds.Tables["Wc"];
            cboWorkCenter.Text = "선택";
        }

        private void MainLoad() // 금형데이터그리드뷰
        {
            CommonUtil.SetInitGridView(dgvMoldList);
            CommonUtil.AddGridTextColumn(dgvMoldList, "금형 코드", "Mold_Code", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvMoldList, "금형명", "Mold_Name", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvMoldList, "금형그룹", "Mold_Group", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvMoldList, "금형상태", "Mold_Status", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvMoldList, "금형누적타수", "Cum_Shot_Cnt", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvMoldList, "금형누적생산량", "Cum_Prd_Qty", colWidth: 150);
            CommonUtil.AddGridTextColumn(dgvMoldList, "금형누적사용시간", "Cum_Time", colWidth: 150);
            CommonUtil.AddGridTextColumn(dgvMoldList, "보장타수", "Guar_Shot_Cnt", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvMoldList, "구매금액", "Purchase_Amt", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvMoldList, "입고일자", "In_Date", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvMoldList, "최종장착일시", "Last_Setup_Time", colWidth: 150);
            CommonUtil.AddGridTextColumn(dgvMoldList, "사용여부", "Use_YN", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvMoldList, "비고", "Remark", colWidth: 300);
            //   사용안하는 컬럼
            CommonUtil.AddGridTextColumn(dgvMoldList, "금형ID", "Mold_ID", visibility: false);
            CommonUtil.AddGridTextColumn(dgvMoldList, "장착작업장코드", "Wc_Code", visibility: false);
            CommonUtil.AddGridTextColumn(dgvMoldList, "최조 입력일자", "Ins_Date", visibility: false);
            CommonUtil.AddGridTextColumn(dgvMoldList, "최초 입력자", "Ins_Emp", visibility: false);
            CommonUtil.AddGridTextColumn(dgvMoldList, "최초 수정일자", "Up_Date", visibility: false);
            CommonUtil.AddGridTextColumn(dgvMoldList, "최종 수정자", "Up_Emp", visibility: false);
        }
        private void Refresh()//새로고침
        {
            moldList = service.GetMoldList();
            dgvMoldList.DataSource = moldList;
            //콤보박스비우기
            cboMoldcode.SelectedIndex = 0;
            cboWorkCenter.SelectedIndex = 0;

            txtCode.Text = txtName.Text = txtCode1.Text = txtMoldName1.Text = txtMoldGroup.Text = txtRemark.Text = txtMoldPrice.Text = "";
            numHit.Value = 0;
            //  dtpIn_date.Value = 0;
            //  dtpLast_setup_Time.Value    

        }
        private void OnRefresh(object sender, EventArgs e) //검색, 아래 정보 새로고침
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMoldInfoAdd) && frm.ActiveMdiChild == this)
                {
                    Refresh();//새로고침
                }
            }
        }

        private void OnInsert(object sender, EventArgs e) //등록버튼을 눌렀을 경우
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMoldInfoAdd) && frm.ActiveMdiChild == this)
                {
                    if (moldList.Count < 1)
                    {
                        txtCode1.Text = "MOLD001";
            //            btnSave.Enabled = true;
                        return;
                    }

                    int code = int.Parse(moldList[moldList.Count - 1].Mold_Code.Replace("MOLD", ""));
                    txtCode1.Text = "MOLD" + (code + 1);

                 //   btnSave.Enabled = true;

                    MoldVO minfo = new MoldVO
                    {
                        Mold_Code = txtCode1.Text,
                        Mold_Name = txtMoldName1.Text,
                        Mold_Group = txtMoldGroup.Text,
                        Mold_Status = "대기",
                        Cum_Prd_Qty = 0,
                        Cum_Shot_Cnt = 0,
                        Cum_Time = 0,
                        Guar_Shot_Cnt = Convert.ToInt32(numHit.Value),
                        In_Date = dtpInDate.Value,
                        Last_Setup_Time = dtpLastEquip.Value,
                        Purchase_Amt = Convert.ToInt32(txtMoldPrice.Text),
                        Remark = txtRemark.Text,
                        Use_YN = "N",
                        Wc_Code = cboWorkCenter.SelectedValue.ToString()
                    };
                    bool result = service.InsertMold(minfo);
                    if (result)
                        MessageBox.Show("금형정보가 등록되었습니다.", "금형관리");
                    else
                        MessageBox.Show("금형정보등록에 실패하였습니다.", "금형관리", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Refresh();///새로고침
                }
            }
        }
        private void OnDelete(object sender, EventArgs e) //삭제버튼을 눌렀을 경우
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMoldInfoAdd) && frm.ActiveMdiChild == this)
                {
                    if (dgvMoldList.Focused)
                    {
                        string moldno = dgvMoldList[0, dgvMoldList.CurrentRow.Index].Value.ToString();
                        bool result = service.DeleteMold(moldno);
                        if (result)
                        {
                            MessageBox.Show("금형정보가 삭제되었습니다.", "금형관리");
                            Refresh();
                        }
                        else
                            MessageBox.Show("금형정보가 삭제되지 않았습니다.", "금형관리", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("삭제할 목록을 선택해 주세요.", "금형관리", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void OnSelect(object sender, EventArgs e) //조회버튼을 눌렀을 경우
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMoldInfoAdd) && frm.ActiveMdiChild == this)
                {
                    if (txtCode.Text.Length > 0 && txtName.Text.Length <= 0)
                    {
                        moldSearchList = (from data in moldList
                                          where data.Mold_Code.Contains(txtCode.Text)
                                          select data).ToList();
                        txtCode.Text = "";
                    }
                    else if (txtName.Text.Length > 0 && txtCode.Text.Length <= 0)
                    {
                        moldSearchList = (from data in moldList
                                          where data.Mold_Name.Contains(txtName.Text)
                                          select data).ToList();
                        txtName.Text = "";
                    }
                    else if (txtCode.Text.Length > 0 && txtName.Text.Length > 0)
                    {
                        moldSearchList = (from data in moldList
                                          where data.Mold_Code.Contains(txtCode.Text) || data.Mold_Name.Contains(txtName.Text)
                                          select data).ToList();
                        txtCode.Text = "";
                        txtName.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("검색조건을 입력해 주세요.", "금형관리", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    dgvMoldList.DataSource = moldSearchList;
                }
            }
        }

        private void dgvMoldList_CellClick(object sender, DataGridViewCellEventArgs e) //셀이 클릭되었을 때 아래 정보 
        {
            //if (e.RowIndex < 0) return;
            //int mold_code = Convert.ToInt32(dgvMoldList[0, e.RowIndex].Value);

            //MoldService service = new MoldService();
            //MoldVO mold = service.GetMoldInfo(mold_code);
            //if (mold != null)
            //{
               
            //    txtCode1.Text = mold.Mold_Code.ToString();   //금형코드
            //    txtMoldName1.Text = mold.Mold_Name;  //금형명
            //    txtMoldGroup.Text = mold.Mold_Group;// 금형그룹
            //    numHit.Value = mold.Guar_Shot_Cnt;//보장타수
            //    txtMoldPrice.Text = mold.Purchase_Amt.ToString();//구매금액
            //    dtpInDate.Value = mold.In_Date; //입고일자
            //    cboWorkCenter.Text = mold.Wc_Code;//장착작업장
            //    dtpLastEquip.Value = mold.Last_Setup_Time;  //최종장착일시
            //    txtRemark.Text = mold.Remark;  //비고
            //}
            //else
            //{
            //    MessageBox.Show("조회 중 오류가 발생했습니다.");
            //}
        }

        private void cboMoldcode_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

    }
}
