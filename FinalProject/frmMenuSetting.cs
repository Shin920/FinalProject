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
    public partial class frmMenuSetting : Form
    {
        DataTable dtMenuAuth;
        int sel_menu_id;

        public frmMenuSetting()
        {
            InitializeComponent();


        }

        private void frmMenuSetting_Load(object sender, EventArgs e)
        {
            MenuBinding();  //트리뷰 컨트롤에 메뉴 바인딩
            AuthBinding();  //리스트박스 컨트롤에 권한 바인딩
            MenuAuthBinding();  //메뉴별 권한정보를 데이터테이블에 저장

            lstSelect.Enabled = lstAll.Enabled = false; //2레벨 메뉴를 선택했을때 활성화되게
        }

        private void MenuAuthBinding()
        {
            MenuService service = new MenuService();
            dtMenuAuth = service.GetMenuAuthList();
            
        }

        private void AuthBinding()
        {
            MenuService service = new MenuService();
            DataTable dtAuth = service.GetAuthList();

            lstAll.Items.Clear();   //혹시 여러번 호출이 되게 된다면 아이템이 중복될수있어서 이런 습관이 좋다

            foreach (DataRow dr in dtAuth.Rows)
            {
                lstAll.Items.Add($"{dr["UserGroup_Code"].ToString()}|{dr["UserGroup_Name"].ToString()}");
            }
        }

        private void MenuBinding()
        {
            MenuService service = new MenuService();

            DataTable dtMenu = service.GetMenu();   
            DataView dv0 = new DataView(dtMenu);    
            //DataView dv1 = dtMenu.DefaultView;  //이것도 뷰를 만들어주는데 필터링등을 하다가 잘못되면 원본에 영향이 갈수있다
            dv0.RowFilter = "Menu_level=1"; 
            dv0.Sort = "Sort_index";     

            for (int i = 0; i < dv0.Count; i++)
            {
                TreeNode node = new TreeNode(dv0[i]["Menu_Name"].ToString());   //메뉴명을 텍스트로 하는 노드 만들기
                node.Tag = $"{dv0[i]["Menu_level"].ToString()}|{dv0[i]["Screen_Code"].ToString()}";    
                treeView1.Nodes.Add(node);  //1레벨 수준의 노드로 생성

                DataView dv1 = new DataView(dtMenu);
                dv1.RowFilter = "Menu_level = 2 and Parent_Screen_Code =" + dv0[i]["Screen_Code"].ToString();  //이 위에 메뉴 아이디에서 2레벨인 애들만 가져오는
                dv1.Sort = "Sort_index";
                for (int k = 0; k < dv1.Count; k++)
                {
                    TreeNode c_node = new TreeNode(dv1[k]["Menu_Name"].ToString());
                    c_node.Tag = $"{dv1[k]["Menu_level"].ToString()}|{dv1[k]["Screen_Code"].ToString()}";
                    node.Nodes.Add(c_node);
                }
            }
            treeView1.ExpandAll();  //트리뷰가 쫙 펼쳐져있게
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            TreeNode node = e.Node; //내가 선택한 노드 //TreeNode node = treeview1.seletedNode;로 할수도있다(근데 만약 노드를 다중선택이 가능하게 했다면 X)
            string[] arrMenu = node.Tag.ToString().Split('|');
            if (arrMenu.Length != 2) return;

            if (arrMenu[0] == "1")   //1레벨 메뉴를 선택했다면
            {
                lstSelect.Items.Clear();
                lstSelect.Enabled = lstAll.Enabled = false;
            }
            else
            {
                node.BackColor = Color.Yellow;
                sel_menu_id = int.Parse(arrMenu[1]);    //메뉴id를 변수에 담아두기 (그리고 menuid는 분명히 있는것. 왜냐면 위에서 length가 2가 아니면 return시켰으니 int.Parse                                          를 과감하게 사용했다)

                //현재 메뉴권한 정보를 바인딩
                if (dtMenuAuth == null) //그럴일은 없겠지만 혹시 dtMenuAuth가 널이라면 다시 데이터 가져오게
                {
                    MenuService service = new MenuService();
                    dtMenuAuth = service.GetMenuAuthList();
                }


                DataTable dt = dtMenuAuth.Copy();  //Deep Copy함수 , 원본을 다시 조회할수도있어서 훼손하지않으려고
                DataRow[] rows = dt.Select("Screen_Code=" + arrMenu[1]); //지금은 id가 숫자니까 상관없는데 문자열이면 "menu_id='" + arrMenu[1] +"'" 이런식 필요
                                                                         //select로 데이터 필터링(view의 rowFilter로 해도 상관없다)
                lstSelect.Items.Clear();
                foreach (DataRow dr in rows)
                {
                    lstSelect.Items.Add($"{dr["UserGroup_Code"].ToString()}|{dr["UserGroup_Name"].ToString()}");
                }

                lstSelect.Enabled = lstAll.Enabled = true;
            }
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            ClearBackColor();
        }
        private void ClearBackColor()
        {
            

            //foreach(TreeNode n in treeView1.Nodes)  //1레벨 노드들을 n에 담는
            //{
            //    foreach(TreeNode s in n.Nodes)  //1레벨 노드의 자식노드들을 담는
            //    {
            //        ClearRecursive(n);
            //    }
            //}
            foreach (TreeNode n in treeView1.Nodes)  //근데 레벨이 많아지면 foreach를 계속 추가해야하니 재귀호출로 하겠다
            {
                ClearRecursive(n);
            }
        }
        private void ClearRecursive(TreeNode node)
        {
            //근데 멘가 2레벨까지가 아니라 3레벨,4레벨 까지 있을수있는데 그럴때 재귀호출로 하는것

            foreach (TreeNode n in node.Nodes)
            {
                n.BackColor = Color.White;  //다시 색 되돌리려고
                ClearRecursive(n);  //이러면 본인이 본인을 부르는것
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            //이미 리스트박스에 있는 권한이 아니라면 추가
            foreach (var item in lstAll.SelectedItems)   //SelectedItem과 SelectedItems가 있는데 여러개일수 있으니 s붙은거
            {
                if (lstSelect.Items.IndexOf(item.ToString()) < 0)    //없으면
                {
                    lstSelect.Items.Add(item);
                }
            }

            for (int i = 0; i < lstAll.Items.Count; i++)
            {
                lstAll.SetSelected(i, false);   //선택이 되지않은 상태로 만드는것 ( 권한을 추가하고 나면 셀렉트가 풀리게하려고)
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            lstSelect.Items.Remove(lstSelect.SelectedItem);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> authList = new List<string>();

            foreach (var item in lstSelect.Items)
            {
                string[] temp = item.ToString().Split('|');
                if (temp.Length == 2)    //제대로 되었으면 2일것
                {
                    authList.Add(temp[0]);
                }
            }
            MenuService service = new MenuService();
            bool result = service.SaveMenuAuth(sel_menu_id, authList);
            if (result)
            {
                MessageBox.Show("저장 완료되었습니다.");
                MenuAuthBinding();
                ClearBackColor();
                lstSelect.Items.Clear();
                lstSelect.Enabled = lstAll.Enabled = false;
            }
            else
                MessageBox.Show("다시 저장하여 주십시오.");
        }
    }
}
