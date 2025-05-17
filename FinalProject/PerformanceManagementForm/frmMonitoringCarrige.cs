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
    public partial class frmMonitoringCarrige : Form
    {
        frmMain frm = null;
        List<CarriageVO> crList;
        List<CarriageVO> usingList;
        List<CarriageVO> emptyList;

        bool isBookMark = false;
        public frmMonitoringCarrige()
        {
            InitializeComponent();
        }


        //*************대차 컨트롤이 많아지면 스크롤로 내려볼수 있게 해야한다**************
        private void frmMonitoringCarrige_Load(object sender, EventArgs e)
        {
            // 이 폼에서는 mdi의 공통 CRUD 버튼을 enable = false로 해야한다. 그냥 모니터링이 전부이기때문에
            CommonUtil.SetInitGridView(dgvEmptyCarriageList);
            CommonUtil.AddGridTextColumn(dgvEmptyCarriageList, "대차코드", "GV_Code", colWidth:143, align: DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvEmptyCarriageList, "대차명", "GV_Name", colWidth: 143);

            LoadData();

            frm = (frmMain)this.MdiParent;

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
                if (fr.GetType() == typeof(frmMonitoringCarrige) && frm.ActiveMdiChild == this)
                {
                    if (frm.btnBookMarkColor != Color.SteelBlue)
                    {
                        MenuService service = new MenuService();
                        bool result = service.InsertBookMark(frm.UserID, "frmMonitoringCarrige");
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
                        bool result = service.DeleteBookMark(frm.UserID, "frmMonitoringCarrige");
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

        private void Frm_Refresh(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMonitoringCarrige) && frm.ActiveMdiChild == this)
                {
                    LoadData();

                }
            }
        }

        private void LoadData()
        {
            CarriageService service = new CarriageService();
            crList = service.GetCarriageStatusList();

            usingList = crList.FindAll(x => x.GV_Status.Equals("적재") || x.GV_Status.Equals("언로딩"));    
            emptyList = crList.FindAll(x => x.GV_Status.Equals("빈대차"));    
            //이 리스트에서 대차상태가 빈대차, 적재 로 구분해서 빈대차 목록은 그리드뷰로 적재는 패널에 유저컨트롤로 동적생성 (0419 프로젝트 참고)
            dgvEmptyCarriageList.DataSource = null;
            dgvEmptyCarriageList.DataSource = emptyList;

            int cnt = (int)Math.Ceiling(usingList.Count / 2.0);

            int idx = 1;
            for (int r = 0; r < cnt; r++)
            {
                for (int i = 0; i < 4; i++)
                {                   
                    if (idx > usingList.Count)
                        break;

                    UcCarriageMoniter car = new UcCarriageMoniter();
                    car.Name = $"car{idx}";
                    car.Location = new Point((i * 300) +80, (r * 235) + 100);
                    car.Size = new Size(273, 215);

                    car.CarriageName = usingList[idx - 1].GV_Name;
                    car.CarraigeStatus = usingList[idx - 1].GV_Status;
                    car.WorkOrderNum = usingList[idx - 1].Workorderno;
                    car.ItemCode = usingList[idx - 1].Item_Code;
                    car.ItemName = usingList[idx - 1].Item_Name;
                    car.LoadingTime = usingList[idx - 1].Loading_time.ToString();

                    splitContainer1.Panel1.Controls.Add(car);
                    idx++;
                }
            }
        }
    }
}
