using FinalProjectDAC;
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
    public partial class frmMenuM : Form
    {
        List<MenuTreeMasterVO> menulist; //메뉴
        
        MainFormService service = new MainFormService();
        MainFormDAC db = new MainFormDAC();

        frmMain frm = null;
        public frmMenuM()
        {
            InitializeComponent();
        }

        private void frmMenuM_Load(object sender, EventArgs e)
        {
            tvMenu.AllowDrop = true;
            treeview();

            frm = (frmMain)this.MdiParent; //함수에 전달해주기위해 
            frm.Delete += OnDelete; //삭제
            frm.Insert += OnInsert;//등록
            frm.Refresh += OnRefresh; //새로고침

            //데이터그리드뷰
            CommonUtil.SetInitGridView(dgvParent);
            CommonUtil.AddGridTextColumn(dgvParent, "코드", "Screen_Code", colWidth: 210);
            CommonUtil.AddGridTextColumn(dgvParent, "이름", "Screen_Name", colWidth: 210);
            CommonUtil.AddGridTextColumn(dgvParent, "날자", "Ins_Date", colWidth: 210);
            CommonUtil.AddGridTextColumn(dgvParent, "입력자", "Ins_Emp", colWidth: 210);

           CommonUtil.SetInitGridView(dgvS);
           CommonUtil.AddGridTextColumn(dgvS, "부모코드", "Parent_Screen_Code", colWidth: 210);
           CommonUtil.AddGridTextColumn(dgvS, "화면코드", "Screen_Code", colWidth: 210);
           CommonUtil.AddGridTextColumn(dgvS, "화면이름", "Screen_Name", colWidth: 210);
           CommonUtil.AddGridTextColumn(dgvS, "날자", "Ins_Date", colWidth: 210);
           CommonUtil.AddGridTextColumn(dgvS, "입력자", "Ins_Emp", colWidth: 210);

            datagridviewsetting();
        }

        private void OnRefresh(object sender, EventArgs e)//새로고침
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMenuM) && frm.ActiveMdiChild == this)
                {               
                        treeview();
                        datagridviewsetting();
                }
            }
        }

        private void treeview()
        {
            DataTable dtMenu = db.GetMenuList();
            DataView dv0 = new DataView(dtMenu);
            dv0.RowFilter = "Menu_level = 1";
            dv0.Sort = "Sort_index";
            for (int i = 0; i < dv0.Count; i++)
            {
                TreeNode node = new TreeNode(dv0[i]["Menu_Name"].ToString());
                node.Tag = $"{dv0[i]["Menu_level"].ToString()}|{dv0[i]["Seq"].ToString()}";
                tvMenu.Nodes.Add(node);

                DataView dv1 = new DataView(dtMenu);
                dv1.RowFilter = "Menu_level = 2 and Parent_Screen_Code=" + dv0[i]["Seq"].ToString();
                dv1.Sort = "Sort_index";
                for (int k = 0; k < dv1.Count; k++)
                {
                    TreeNode c_node = new TreeNode(dv1[k]["Menu_Name"].ToString());
                    c_node.Tag = $"{dv1[k]["Menu_level"].ToString()}|{dv1[k]["Seq"].ToString()}";
                    node.Nodes.Add(c_node);
                }
            }
            tvMenu.ExpandAll();
            //    tvMenu.Nodes.Clear(); 방법1

            //    menulist = service.GetAll_MenuTree_Master();
            //    var parent = menulist.FindAll(p => p.Parent_Screen_Code == null);

            //    for (int i = 0; i < parent.Count; i++)
            //    {
            //        tvMenu.Nodes.Add(parent[i].Screen_Name);
            //        tvMenu.Nodes[i].Tag = parent[i].Screen_Code;
            //        var son = menulist.FindAll(s => s.Parent_Screen_Code == parent[i].Screen_Code);
            //        for (int j = 0; j < son.Count; j++)
            //        {
            //            tvMenu.Nodes[i].Nodes.Add(son[j].Screen_Name);
            //            tvMenu.Nodes[i].Nodes[j].Tag = son[j].Screen_Code;
            //        }
            //    }

            //    tvMenu.ExpandAll();
        }
        private void datagridviewsetting()
        {//왜안되는 것인가?var 의 초기화
        //    menulist = service.GetAll_MenuTree_Master();
       //     var parent = menulist.FindAll(p => p.Parent_Screen_Code == null);
     //       dgvParent.DataSource = parent;

     //       var son = menulist.FindAll(p => p.Parent_Screen_Code == dgvParent.SelectedRows[0].Cells[0].Value.ToString());
   //         dgvS.DataSource = son;
        }

        private void OnInsert(object sender, EventArgs e)//등록 팝업창이나와서 부모 자식폼등록
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMenuM) && frm.ActiveMdiChild == this)
                {
                    frmMenuM_AddDeletepop frm = new frmMenuM_AddDeletepop();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        treeview();
                        datagridviewsetting();
                    }
                }
            }
           
        }

        private void OnDelete(object sender, EventArgs e)
        {
            foreach (Form fr in Application.OpenForms)
            {
                if (fr.GetType() == typeof(frmMenuM) && frm.ActiveMdiChild == this)
                {
                    try
                    {
                            if (deletecheck1.Text == "1")
                            {
                                if (MessageBox.Show(dgvParent.SelectedRows[0].Cells[1].Value.ToString() + "하위항목도 모두 삭제됩니다. 메뉴를 삭제하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    if (service.DeleteMenuTree_Master_VO("1", dgvParent.SelectedRows[0].Cells[0].Value.ToString(), dgvParent.SelectedRows[0].Cells[0].Value.ToString()))
                                    {     
                                        treeview();
                                        datagridviewsetting();
                                       }
                                }
                            }
                            else if (deletecheck2.Text == "1")
                            {
                                if (MessageBox.Show(dgvS.SelectedRows[0].Cells[1].Value.ToString() + "메뉴를 삭제하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    MessageBox.Show(dgvS.SelectedRows[0].Cells[1].Value.ToString());
                                    if (service.DeleteMenuTree_Master_VO("-1", dgvS.SelectedRows[0].Cells[0].Value.ToString(), dgvS.SelectedRows[0].Cells[1].Value.ToString()))
                                    {
                                        treeview();
                                        datagridviewsetting();
                                   }
                                }
                            }
                    }
                    catch (Exception err)
                    {
                        Program.Log.WriteError(err.Message);
                    }
                }
            }
        }

        private void tvMenu_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = tvMenu.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = tvMenu.GetNodeAt(targetPoint);

            if (targetNode != null && targetNode.Level == 0) //레벨0인곳에만 이동가능하게
            {
                // Retrieve the node that was dragged.
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                if (draggedNode.Level != 0) // level0인 부모를 자식에게 넣지못하게
                {
                    if (!draggedNode.Equals(targetNode) && ! ContainsNode(draggedNode, targetNode))
                    {
                        if (e.Effect == DragDropEffects.Move)
                        {
                            draggedNode.Remove();
                            targetNode.Nodes.Add(draggedNode);
                            service.UpdateManu(targetNode.Tag.ToString(), draggedNode.Tag.ToString()); //메뉴 db변경
                        
                        }
                        else if (e.Effect == DragDropEffects.Copy)
                        {
                            targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("이동할 수 없는 경로입니다.");
                }
            }
            else
            {
                MessageBox.Show("이동할 수 없는 경로입니다.");
            }
        }
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;
            return ContainsNode(node1, node2.Parent);
        }

        private void tvMenu_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void tvMenu_DragOver(object sender, DragEventArgs e)    // 마우스 위치의 클라이언트 좌표를 가져오기
        {    
            // Retrieve the client coordinates of the mouse position.(마우스 위치의 클라이언트 좌표를 검색합니다.)
            Point targetPoint = tvMenu.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.(마우스 위치에서 노드를 선택합니다.)
            tvMenu.SelectedNode = tvMenu.GetNodeAt(targetPoint);
            //    tvMenu.tvPersonSaveXml();
        }

        private void tvMenu_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.(마우스 왼쪽 버튼을 사용할 때 끌린 노드를 이동합니다.)
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
            // Copy the dragged node when the right mouse button is used.(마우스 오른쪽 버튼을 사용하면 끌린 노드를 복사합니다.)
            else if (e.Button == MouseButtons.Right)
            {
                DoDragDrop(e.Item, DragDropEffects.Copy);
            }
        }

        private void dgvParent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvS.DataSource = null;
            var son = menulist.FindAll(p => p.Parent_Screen_Code == dgvParent.SelectedRows[0].Cells[0].Value.ToString());
            dgvS.DataSource = son;
        }

        private void dgvParent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            deletecheck1.Text = "1";
            deletecheck2.Text = "0";
        }

        private void dgvS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           deletecheck1.Text = "0";
           deletecheck2.Text = "1";
        }
    }
}
