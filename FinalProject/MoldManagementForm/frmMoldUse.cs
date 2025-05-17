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
    public partial class frmMoldUse : Form
    {
        frmMain frm = null;
        List<Mold_J_Item_Wc_MuseVO> molditemList; 
        List<Mold_J_Item_Wc_MuseVO> moldSearchList;
        MoldService service = new MoldService();

        public frmMoldUse()
        {
            InitializeComponent();
        }

        private void frmMoldUse_Load(object sender, EventArgs e)
        {
            frm = (frmMain)this.MdiParent; //함수에 전달해주기위해 
            frm.Select += OnSelect; //조회
            frm.Refresh += OnRefresh; //새로고침

           // 데이터 그리드뷰 바인딩

            MainGridLoad();

            molditemList = service.SelectMold_Item_Wc_Muse();
            DataLoad(molditemList);
         
        }
        private void MainGridLoad()// 데이터 그리드뷰 바인딩
        {
            CommonUtil.SetInitGridView(dgvMoldList);
            CommonUtil.AddGridTextColumn(dgvMoldList, "생산일자", "Prd_Date", colWidth: 130);
            CommonUtil.AddGridTextColumn(dgvMoldList, "금형코드", "Mold_Code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvMoldList, "금형명", "Mold_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvMoldList, "작업지시번호", "Workorderno", colWidth: 110);
            CommonUtil.AddGridTextColumn(dgvMoldList, "품목코드", "Item_Code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvMoldList, "품목명", "Item_Name", colWidth: 90);
            CommonUtil.AddGridTextColumn(dgvMoldList, "작업장코드", "Wc_Code", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvMoldList, "작업장이름", "Wc_Name", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvMoldList, "금형타수", "Mold_Shot_Cnt", colWidth: 90);
            CommonUtil.AddGridTextColumn(dgvMoldList, "금형생산량", "Mold_Prd_Qty", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvMoldList, "금형사용시작시간", "Use_Starttime", colWidth: 200);
            CommonUtil.AddGridTextColumn(dgvMoldList, "금형사용종료시간", "Use_Endtime", colWidth: 200);
            CommonUtil.AddGridTextColumn(dgvMoldList, "금형사용시간", "Last_Setup_Time", colWidth: 200);
        }
        // 그리드뷰 데이터 바인딩
        private void DataLoad(List<Mold_J_Item_Wc_MuseVO> molditemList)
        {
            var molist = (from list in molditemList
                          select new
                          {
                              Prd_Date = list.Prd_Date,
                              Mold_Code = list.Mold_Code,
                              Mold_Name = list.Mold_Name,
                              Workorderno = list.Workorderno,
                              Item_Code = list.Item_Code,
                              Item_Name = list.Item_Name,
                              Wc_Code = list.Wc_Code,
                              Wc_Name = list.Wc_Name,
                              Mold_Shot_Cnt = list.Mold_Shot_Cnt,
                              Mold_Prd_Qty = list.Mold_Prd_Qty,
                              Use_Starttime = list.Use_Starttime,
                              Use_Endtime = list.Use_Endtime,
                              Last_Setup_Time = list.Use_Endtime.Subtract(list.Use_Starttime).Minutes < 0 ? "작업중" : $"{list.Use_Endtime.Subtract(list.Use_Starttime).Minutes}분"
                          }).ToList();
            dgvMoldList.DataSource = molist;
        }

        private void OnRefresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMoldUse) && frm.ActiveMdiChild == this)
                {
                    molditemList = service.SelectMold_Item_Wc_Muse();
                    DataLoad(molditemList);         
                }
            }
        }

        private void OnSelect(object sender, EventArgs e)
        { 
          
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMoldUse) && frm.ActiveMdiChild == this)
                {
                 DateTime startT = dateTimePickerSearch1.dateTimePickerValue1;
                 DateTime endT = dateTimePickerSearch1.dateTimePickerValue2;
                 endT = endT.AddDays(10);
                 moldSearchList = (from date in molditemList
                                    where date.Prd_Date >= startT && date.Prd_Date <= endT
                                    select date).ToList();

                    DataLoad(moldSearchList);
                }
            }
        }

        private void dateTimePickerSearch1_btnDateTimeSearch_Click(object sender, EventArgs args)// 기간조건검색
        {
            DateTime startT = dateTimePickerSearch1.dateTimePickerValue1;
            DateTime endT = dateTimePickerSearch1.dateTimePickerValue2;
            endT = endT.AddDays(10);
            moldSearchList = (from date in molditemList
                              where date.Prd_Date >= startT && date.Prd_Date <= endT
                              select date).ToList();

            DataLoad(moldSearchList);
        }
    }

}
