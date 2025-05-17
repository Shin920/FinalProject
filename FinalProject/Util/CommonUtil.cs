using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProjectVO;


namespace FinalProject
{
    class CommonUtil
    {
        public static void SetInitGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
        }

        public static void AddGridTextColumn(DataGridView dgv, 
                                        string headerText, 
                                        string propertyName,
                                        DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft, 
                                        int colWidth = 100, 
                                        bool visibility = true)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = propertyName;
            col.HeaderText = headerText;
            col.HeaderCell.Style.Alignment = align;
            col.DataPropertyName = propertyName;
            col.Width = colWidth;
            col.DefaultCellStyle.Alignment = align;
            col.Visible = visibility;
            col.ReadOnly = true;

            dgv.Columns.Add(col);
        }
        public static void ComboBinding(ComboBox cbo, List<ComboItemVO> list, string gubun, bool blankItem = true, string blankText = "")
        {
            
            var codeList = list.Where<ComboItemVO>((item) => item.com_Category.Equals(gubun)).ToList();
            
            if (blankItem)
            {
                ComboItemVO blank = new ComboItemVO
                { com_Code = "", com_Name = blankText };
                codeList.Insert(0, blank);
            }

            cbo.DisplayMember = "com_Name";
            cbo.ValueMember = "com_Code";
            cbo.DataSource = codeList;
        }
        
        public static byte[] ImageToByte(Image img)
        {
            try
            {
                ImageConverter ic = new ImageConverter();
                return (byte[])ic.ConvertTo(img, typeof(byte[]));
            }
            catch (Exception err)
            {
                Program.Log.WriteError("이미지 byte[] 변환오류", err);
                throw err;
            }
        }
        public static Image ByteToImage(byte[] data)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
            return (Bitmap)tc.ConvertFrom(data);
        }

        //public static string InputYNCheck(Panel pnl)      //강사님꺼
        //{
        //    StringBuilder sb = new StringBuilder();

        //    //패널안의 텍스트박스 컨트롤들의 입력여부를 체크
        //    foreach (Control ctrl in pnl.Controls)
        //    {
        //        if (ctrl is GudiTextBox txt)
        //        {
        //            if (txt.InputType == validType.Required || txt.InputType == validType.RequiredNumeric)
        //            {
        //                if (string.IsNullOrWhiteSpace(txt.Text.Trim()))
        //                {
        //                    sb.Append($"- {txt.Tag}을 입력해 주세요.\n");
        //                }
        //            }
        //        }
        //    }

        //    return sb.ToString();
        //}

        /// <summary>
        /// 패널/그룹박스 안의 텍스트 박스 내용 지우기
        /// </summary>
        /// <param name="pnl"></param>
        public static void ClearTextBox(Panel pnl = null, GroupBox grb = null)      //패널/그룹박스 안의 텍스트 박스 내용 지우기
        {
            if(pnl != null)
            {
                foreach (Control ctrl in pnl.Controls)
                {
                    if (ctrl.GetType() == typeof(TextBox))
                        ctrl.Text = "";
                }
            }
            if(grb != null)
            {
                foreach (Control ctrl in grb.Controls)
                {
                    if (ctrl.GetType() == typeof(TextBox))
                        ctrl.Text = "";
                }
            }
           
        }
        public static void SetDGVDesign(DataGridView dgv)// 그리드뷰 디자인 설정
        {
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.MultiSelect = false; //열하나만선택

            dgv.AllowUserToResizeColumns = true; // 칼럼 사용자 변경 o
            dgv.AllowUserToResizeRows = false; //사용자가임의로 로우의 크기를 변경시킬수 없게     

            dgv.RowHeadersVisible = false; // 맨왼쪽에 있는 컬럼 삭제
            // dgv.RowHeadersWidth = 20;     // 맨왼쪽에 있는 컬럼 사이즈 변경   

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // 한줄전체선택
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None; //테두리삭제

            dgv.BackgroundColor = Color.White; // Color.FromArgb(248, 241, 233); //그리드뷰 배경색
            // dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 175, 175);   // 로우 해더 색설정     
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(243, 228, 231); //홀수 행 색
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(248, 241, 233);//Color.FromArgb(248, 241, 233); // 전체 행 색
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(145, 224, 244); // 선택 로우 색

            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        }
        // 그리드뷰 칼럼 삽입
        public static void AddNewColumnToDataGridView(DataGridView dgv, string headerText,
                          string dataPropertyName, bool visibility, int colWidth = 100, DataGridViewContentAlignment textAlign = DataGridViewContentAlignment.MiddleLeft, bool isFillAll = false)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = headerText;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.DataPropertyName = dataPropertyName;
            col.Width = colWidth;
            col.Visible = visibility;
            col.ValueType = typeof(string);
            col.ReadOnly = true;
            col.DefaultCellStyle.Alignment = textAlign;
            col.AutoSizeMode = isFillAll ? DataGridViewAutoSizeColumnMode.Fill : default(DataGridViewAutoSizeColumnMode);
            dgv.Columns.Add(col);
        }
        public static void SetGridViewFontSize(DataGridView gridview)
        {
            // 전체적으로 폰트 적용하기
            gridview.Font = new Font("맑은 고딕", 25, FontStyle.Regular);

            //// Colum 의 해더부분을 지정하기
            //gridview.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);

            //// Row 해더부분을 지정하기
            //gridview.RowHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);

            //// Cell 내용부분을 지정하기
            //gridview.DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);

        }

        public static void OpenCreateForm(Form mdifrm, string prgName, string formText)
        {
            //문자열로부터 클래스명을 얻고 싶을때 => Type
            string appName = Assembly.GetEntryAssembly().GetName().Name;
            Type frmType = Type.GetType($"{appName}.{prgName}");

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == frmType)
                {
                    form.Activate();
                    form.BringToFront();
                    return;
                }
            }

            try
            {
                Form frm = (Form)Activator.CreateInstance(frmType);
                frm.MdiParent = mdifrm;
                frm.WindowState = FormWindowState.Maximized;
                frm.Text = formText;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("등록된 프로그램이 존재하지 않습니다. ");
            }
        }
    }
}
