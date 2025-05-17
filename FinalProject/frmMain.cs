using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmMain : Form
    {
        //string userID;
        frmLogin frmlogin;
        public string UserName { get; set; }
        //public string UserID { get { return userID; } }
        public string UserID { get; set; }
        public List<string> BookMarkList { get; set; }   //사용자가 로그인해서 폼이 열리면 그 사용자의 즐겨찾기 목록을 가져올때 여기에도 담아서 해당 폼을 열면 즐찾버튼                                                         색이 다르게 보이게 하려고
       
        //public bool IsBookMark { get { return IsBookMark; } set { IsBookMark = value; } }   //이미 북마크 상태이면 다시 버튼을 눌렀을때 해제되게 하려고
        public Color btnBookMarkColor { get { return btnBookMarkReg.BackColor; } set { btnBookMarkReg.BackColor = value; } }

        DataTable dtMenu;
        Panel panel1;
        TreeView treeView1;
        ListBox lst;
        bool havelst = false;
        string btnName = null;  

        public event EventHandler Select;   //조회이벤트 정의
        public event EventHandler UpDate;     //수정이벤트 정의
        public event EventHandler Delete;   //삭제이벤트 정의
        public event EventHandler Insert;  //저장이벤트 정의
        public event EventHandler Refresh; //새로고침
        public event EventHandler BookMark; //현재 활성화된 페이지 정보 저장
        public event EventHandler BookMarkReg; //북마크 등록
        public frmMain(string userID, frmLogin frm)
        {
            InitializeComponent();

            tabControl1.Visible = false;
            UserID = userID;
            this.frmlogin = frm;
        }
        private void ShowToolStripButton(bool bSelect = true, bool bUpdate = true, bool bDelete = true, bool bInsert = true, bool bRefresh =true)
        {
            btnSearch.Visible = bSelect; //조회
            btnInsert.Visible = bUpdate; //수정
            btnDelete.Visible = bDelete; //삭제
            btnUpDate.Visible = bInsert; //등록
            btnRefresh.Visible = bRefresh; //새로고침
        }


        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                tabControl1.Visible = false;
            }
            else
            {
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized;

                if (this.ActiveMdiChild.Tag == null || this.ActiveMdiChild.Tag.ToString() == "")
                {
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text + "   ");
                    
                    tp.Parent = tabControl1;
                    tp.Tag = this.ActiveMdiChild;
                    tabControl1.SelectedTab = tp;

                    this.ActiveMdiChild.FormClosed += ActiveMdiChild_FormClosed;
                    this.ActiveMdiChild.Tag = tp;
                }
            }

            if (!tabControl1.Visible)
            {
                tabControl1.Visible = true;
            }
        }
        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((TabPage)((Form)sender).Tag).Dispose();
        }


        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                var r = tabControl1.GetTabRect(i);
                var closeImage = Properties.Resources.close_grey;
                var closeRect = new Rectangle((r.Right - closeImage.Width), r.Top + (r.Height - closeImage.Height) / 2, closeImage.Width, closeImage.Height);
                if (closeRect.Contains(e.Location))
                {
                    this.ActiveMdiChild.Close();
                    break;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null && tabControl1.SelectedTab.Tag != null)
            {
                Form frm = (Form)tabControl1.SelectedTab.Tag;
                frm.Select();
                if (this.BookMarkList != null)
                {

                    foreach (string r in this.BookMarkList)
                    {
                        if (frm.GetType().ToString().Split('.')[1].Trim() == r.Trim())     //그냥 getType으로 하면 클래스명까지 붙어서 .으로 잘라주고 trim을 양쪽다 안하니 안나와서
                        {
                            this.btnBookMarkColor = Color.SteelBlue;
                            //isBookMark = true;
                            return;
                        }
                        else
                        {
                            this.btnBookMarkColor = Color.FromArgb(57, 61, 70);   //다른 폼으로 갔는데 거기는 즐겨찾기 아니면 다시 원래 색으로
                        }
                    }

                }
            }
        }
   

        private void frmMain_Load(object sender, EventArgs e)
        {
           
           

            MenuService service = new MenuService();
            DataTable userdt = service.GetUserInfo(UserID);
          
            dtMenu = service.GetUserMenuList(userdt.Rows[0][2].ToString());      // 그룹코드 => 이렇게 입력하면 된다. userdt.Rows[0][1].ToString()


            DrawMenuPanel();
            DrwaMenuStrip();

            DataTable dt = service.GetBookMarkList(UserID);     // userID로 바꾸면 된다

            BookMarkList = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //BookMarkList = new List<string>();
                BookMarkList.Add(dt.Rows[i]["Program_Name"].ToString());              
            }

            frmMain2 frm = new frmMain2();
            frm.MdiParent = this;
            frm.Show();

            this.UserName = frm.UserName;
            lblUserName.Text = "현재 관리자: " + frm.UserName + "님";

            btnBookMark.PerformClick();
            btnBookMark.PerformClick();
        }

        private void DrwaMenuStrip()
        {
            DataView dv0 = new DataView(dtMenu);
            dv0.RowFilter = "Menu_level = 1";
            dv0.Sort = "Sort_index";
            for (int i = 0; i < dv0.Count; i++)  //주메뉴 생성
            {
                ToolStripMenuItem f_menu = new ToolStripMenuItem();
                f_menu.Name = $"f_menu{dv0[i]["Screen_Code"].ToString()}";
                f_menu.Size = new System.Drawing.Size(100, 20);
                f_menu.Text = dv0[i]["Menu_Name"].ToString();

                menuStrip1.Items.Add(f_menu);

                DataView dv1 = new DataView(dtMenu);
                dv1.RowFilter = "Menu_level = 2 and Parent_Screen_Code = " + dv0[i]["Screen_Code"].ToString();
                dv1.Sort = "Sort_index";
                for (int k = 0; k < dv1.Count; k++)  //주메뉴 생성
                {
                    ToolStripMenuItem s_menu = new ToolStripMenuItem();
                    s_menu.Name = $"f_menu{dv1[k]["Screen_Code"].ToString()}";
                    s_menu.Size = new System.Drawing.Size(100, 20);
                    s_menu.Text = dv1[k]["Menu_Name"].ToString();
                    s_menu.Tag = dv1[k]["Program_Name"].ToString(); //소메뉴는 버튼을 클릭시 실제 폼을 열어야하니까 태그에 폼이름을 담아놓는다
                    s_menu.Click += Menu_Click;

                    f_menu.DropDownItems.Add(s_menu);
                }


            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;     //메뉴스트립바에서 클릭한 애를 찾아서
            //MessageBox.Show(menu.Tag.ToString());
            OpenCreateForm(menu.Tag.ToString(), menu.Text);
        }

        private void DrawMenuPanel()
        {
            DataView dv0 = new DataView(dtMenu);
            dv0.RowFilter = "Menu_level = 1";
            dv0.Sort = "Sort_index";
            for (int i = 0; i < dv0.Count; i++)  //주메뉴 생성
            {
                Button f_btn = new Button();

                f_btn.Dock = System.Windows.Forms.DockStyle.Top;
                f_btn.Location = new System.Drawing.Point(3, (i * 50));
                f_btn.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
                f_btn.Name = $"f_menu{dv0[i]["Screen_Code"].ToString()}";
                f_btn.Size = new System.Drawing.Size(197, 64);
                f_btn.BackColor = Color.FromArgb(97, 101, 110);
                f_btn.ForeColor = Color.White; 
                f_btn.Font = new Font("맑은고딕", 13, FontStyle.Bold);
                f_btn.FlatStyle = FlatStyle.Flat;
                f_btn.FlatAppearance.BorderColor = Color.FromArgb(97, 101, 110);
                f_btn.Tag = i;
                f_btn.Text = dv0[i]["Menu_Name"].ToString();

                f_btn.Click += new System.EventHandler(this.button25_Click);     //---이거 중요

                this.flowLayoutPanel1.Controls.Add(f_btn);
            }

            panel1 = new Panel();

            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(3, (dv0.Count * 50));
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(197, 328);

            this.flowLayoutPanel1.Controls.Add(panel1);

            treeView1 = new TreeView();
            treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            treeView1.Location = new System.Drawing.Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.ItemHeight = 20;  //노드와 노드간의 간격이 조금 벌어지게하려고
            treeView1.Size = new System.Drawing.Size(197, 328);
            treeView1.ImageList = imageList1;
            treeView1.AfterSelect += TreeView1_AfterSelect;     //노드가 선택될때 이벤트

            panel1.Controls.Add(treeView1);
        }
        private void button25_Click(object sender, EventArgs e)
        {
            //flowLayoutPanel이라는 컨트롤이 인덱스 순서를 제어하는게 쉽다.
            if (btnName != null && btnName == sender.ToString())
            {
                panel1.Visible = false;
                btnName = null;
            }
            else
            {

                flowLayoutPanel1.Controls.SetChildIndex(panel1, 1); //SetChildIndex은 부모 컨트롤에 있는 자식 컨트롤의 위치 인덱스를 바꾸는것.
                flowLayoutPanel1.Invalidate();  //다시 그림을 그려라 (컨트롤의 위치를 바꿨으니 다시 그리게하려는것)

                //그리고 모든 버튼이 같은 식으로 인덱스가 바뀔거니까 모두 click이벤트를 이걸 보게 설정하고
                //각 버튼의 tag에 0,1,2 순서를 준다

                Button btn = (Button)sender;    //여러버튼의 클릭이벤트를 이거 하나로 보게했으니까 어떤 버튼인지 알려면 sender로 (sender는 object니까 부모가 자식으로 형변환) 생성
                flowLayoutPanel1.Controls.SetChildIndex(panel1, (Convert.ToInt32(btn.Tag) + 1));     //위에를 보면 결국 패널이 어떤 버튼의 잉ㄴ덱스 + 1 위치로 가는거니까 이렇게해                                                                                  서 여러개를 같은 이벤트로 봐도 순서대로 잘되게                                                                              
                flowLayoutPanel1.Invalidate();  //적용시키는것

                //트리뷰 컨트롤에 바인딩
                treeView1.Nodes.Clear();

                DataView dv1 = new DataView(dtMenu);
                dv1.RowFilter = "Menu_level = 2 and Parent_Screen_Code = " + btn.Name.Replace("f_menu", "");
                dv1.Sort = "Sort_index";
                for (int k = 0; k < dv1.Count; k++)  //주메뉴 생성
                {
                    TreeNode c_node = new TreeNode(dv1[k]["Menu_Name"].ToString());
                    c_node.Tag = $"{dv1[k]["Screen_Code"].ToString()}|{dv1[k]["Program_Name"].ToString()}";
                    c_node.SelectedImageIndex = 0;
                    treeView1.Nodes.Add(c_node);


                }
                panel1.Visible = true;
                btnName = sender.ToString();
            }
        }
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string[] menuData = e.Node.Tag.ToString().Split('|');
            if (menuData.Length == 2)
            {
                //MessageBox.Show(menuData[1]);     //테스트로 폼이름 확인해보고
                OpenCreateForm(menuData[1], e.Node.Text);             
            }
        }

        private void OpenCreateForm(string prgName, string formText)
        {
            //문자열로부터 클래스명을 얻고 싶을때 => Type
            string appName = Assembly.GetEntryAssembly().GetName().Name;
            Type frmType = Type.GetType($"{appName.ToString().Trim()}.{prgName.ToString().Trim()}");    //이것도 Trim을 안하니까 안되는것도 있어서 Trim 해줘야함

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == frmType)
                {
                    form.Activate();
                    form.BringToFront();
                    if (this.BookMarkList != null)
                    {

                        foreach (string r in this.BookMarkList)
                        {
                            if (form.GetType().ToString().Split('.')[1].Trim() == r.Trim())     //그냥 getType으로 하면 클래스명까지 붙어서 .으로 잘라주고 trim을 양쪽다 안하니 안나와서
                            {
                                this.btnBookMarkColor = Color.SteelBlue;
                                return;
                                //isBookMark = true;
                            }
                            else
                            {
                                this.btnBookMarkColor = Color.FromArgb(57, 61, 70);   //다른 폼으로 갔는데 거기는 즐겨찾기 아니면 다시 원래 색으로
                            }
                        }

                    }
                    return;
                }
            }

            try
            {
                Form frm = (Form)Activator.CreateInstance(frmType);
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Text = formText;
                frm.Show();
                if (this.BookMarkList != null)
                {

                    foreach (string r in this.BookMarkList)
                    {
                        if (frm.GetType().ToString().Split('.')[1].Trim() == r.Trim())     //그냥 getType으로 하면 클래스명까지 붙어서 .으로 잘라주고 trim을 양쪽다 안하니 안나와서
                        {
                            this.btnBookMarkColor = Color.SteelBlue;
                            return;
                            //isBookMark = true;
                        }
                        else
                        {
                            this.btnBookMarkColor = Color.FromArgb(57, 61, 70);   //다른 폼으로 갔는데 거기는 즐겨찾기 아니면 다시 원래 색으로
                        }
                    }

                }
            }
            catch
            {
                MessageBox.Show("등록된 프로그램이 존재하지 않습니다. ");
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Select != null)
            {
                //null 사용가능 하지만 오류가 날수있음 받아주는 class에서 버튼에 등록된게 많음
                Select(this, new EventArgs());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (Refresh != null)
            {
                Refresh(this, new EventArgs());
            }
        }

        private void btnUpDate_Click(object sender, EventArgs e)
        {
            if (UpDate != null)
            {
                UpDate(this, new EventArgs());
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (Insert != null)
            {
                Insert(this, new EventArgs());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(this, new EventArgs());
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmlogin.ClearText();
            frmlogin.Show();
            this.Close();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            frmMenuSetting frm = new frmMenuSetting();
            frm.Show();
        }

        private void btnBookMark_Click(object sender, EventArgs e)
        {
            //if (BookMark != null)
            //{
            //    BookMark(this, new EventArgs());
            //}

            if (havelst == false)
            {
                Point clickP = Cursor.Position;

                lst = new ListBox();
                lst.Name = "BookMarkListBox";
                lst.Size = new Size(150, 200);
                lst.Location = new Point(clickP.X-50, clickP.Y + 10);          
                lst.BorderStyle = BorderStyle.FixedSingle;
                lst.BackColor = Color.White;
                

                this.Controls.Add(lst);
                lst.BringToFront();
                havelst = true;
            }
            else
            {
                this.Controls.Remove(lst);
                havelst = false;
            }

            MenuService service = new MenuService();
            DataTable dt = service.GetBookMarkList(UserID);
            //lst.Items.Clear();
            lst.DataSource = null;
            if (BookMarkList != null)
                BookMarkList.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {   
                //lst.DataSource = dt;

                //lst.DisplayMember = "Menu_Name";
                //lst.ValueMember = "Program_Name";

                lst.Items.Add($"{dt.Rows[i]["Menu_Name"].ToString()}                         |{dt.Rows[i]["Program_Name"].ToString()}");


                BookMarkList.Add(dt.Rows[i]["Program_Name"].ToString());
            }
            
                      
            lst.DoubleClick += Lst_DoubleClick;

        }

        private void Lst_DoubleClick(object sender, EventArgs e)
        {
            if (lst.SelectedIndex >= 0)
            {
               /* CommonUtil.OpenCreateForm(this, lst.SelectedValue.ToString().Trim(), lst.DisplayMember.ToString().Trim()); */   //***이 Trim이 정말 중요하다. 당연히 공백이 없을줄 알았는데 자꾸 GetType에서 인식을 못하고 null을 반환하길래 찾아봤더니 공백때문이라는 말이 있어서 혹시나 Trim을 했더니 잘된다.*****
                string[] arr = lst.SelectedItem.ToString().Split('|');
                CommonUtil.OpenCreateForm(this, arr[1].Trim(), arr[0].Trim());
                this.Controls.Remove(lst);
                havelst = false;
            }
        }

       
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //로그인폼 닫기
            //this.loginform.ClearControlText();
            //this.loginform.Show();  //받은 객체로 여는데 이렇게만 show만 하면 아이디,비밀번호가 적혀진 상태로 나온다.그래서 위에 ClearControlText는 로그인폼에 만든 퍼블릭메서드
            //                        //로 텍스트를 지운다. 물론 로그인폼에 프로퍼티로 텍스트박스를 지울수있게 할수도있다.
        }

        private void btnBookMarkReg_Click(object sender, EventArgs e)
        {
            if (BookMarkReg != null)
            {
                BookMarkReg(this, new EventArgs());
            }
            //foreach (Form fr in Application.OpenForms)
            //{
            //    if (fr.GetType() == typeof(frmDefectiveImage) && frm.ActiveMdiChild == this)
            //    {
            //        MenuService service = new MenuService();
            //        bool result = service.InsertBookMark("", "frmDefectiveImage");
            //        if (result)
            //            MessageBox.Show("즐겨찾기 등록되었습니다.");
            //        else
            //            MessageBox.Show("즐겨찾기 등록 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
            //    }
            //}
        }

        private void menuStrip1_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            //MessageBox.Show(e.Item.Text);
            if (e.Item.Text == "" || e.Item.Text == "닫기(&C)" || e.Item.Text == "최소화(&N)" || e.Item.Text == "이전 크기로(&R)")
                e.Item.Visible = false; //메뉴스트립의 컨트롤박스(아이콘)과 닫기버튼을 안보이게
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            btnBookMarkReg.PerformClick();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            btnBookMark.PerformClick();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            btnLogOut.PerformClick();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            btnSetting.PerformClick();

        }
    }
}
