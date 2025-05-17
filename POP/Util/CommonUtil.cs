using POP.Service;
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

namespace POP
{
    public class CommonUtil
    {
        public static void SetGridWidth(DataGridView dgv, string columnName, int width)
        {
            DataGridViewColumn colID = dgv.Columns[$"{columnName}"];
            colID.FillWeight = width;

            //하지만 처음 두 열을 // 읽을 수 있도록 최소 너비를 유지합니다. //이 시나리오의 또 다른 옵션은 // 설명 열에 채우기 모드 만 할당하는 것입니다. 
            colID.MinimumWidth = 75;
        }
        public static void buttonColorChangeWhenMouseLeave(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;

            if (thisButton.Name != "btnStart" && thisButton.Name != "btnEnd")
            {
                //thisButton.BackColor = Color.FromArgb(51, 154, 204);
                thisButton.BackColor = Color.FromArgb(255, 207, 135);
                thisButton.ForeColor = Color.FromArgb(36, 30, 29);
                //thisButton.ForeColor = Color.White;
            }
        }

        public static void buttonColorChangeWhenMouseEnter(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;
            if (thisButton.Name != "btnStart" && thisButton.Name != "btnEnd")
            {
                thisButton.BackColor = Color.FromArgb(36, 30, 29);
                thisButton.ForeColor = Color.FromArgb(255, 207, 135);
            }
        }


        public static void SetGridViewFontSize(DataGridView gridview, int fontsize = 20)
        {
            // 전체적으로 폰트 적용하기
            gridview.Font = new Font("맑은 고딕", fontsize, FontStyle.Regular);

            //// Colum 의 해더부분을 지정하기
            //gridview.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);

            //// Row 해더부분을 지정하기
            //gridview.RowHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);

            //// Cell 내용부분을 지정하기
            //gridview.DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);

        }
        public static void SetInitGridView(DataGridView dgv)
        {
            dgv.RowHeadersVisible = false;
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Font = new Font("맑은 고딕", 18, FontStyle.Regular);
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

        public static void SetGridColor(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells["wo_order"].Value.ToString() == "7" && dgv.Rows[i].Cells[0].Value.ToString() != "생산중지")
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.Gold;
                    dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (dgv.Rows[i].Cells[0].Value.ToString() == "생산중")
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.ForestGreen;
                    dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                else if (dgv.Rows[i].Cells[0].Value.ToString() == "생산중지")
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    dgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Black;

                }
            }
        }
        /// <summary>
        /// 바코드 프린트
        /// </summary>
        /// <param name="barcodeno"></param>
        public static void BarCodePrint(string barcodeno)
        {
            PackService service = new PackService();
            DataTable dt = new DataTable();
            dt = service.GetBarcodeInfo(barcodeno);

            XtraReport1 rpt = new XtraReport1();
            rpt.DataSource = dt;
            ReportPreviewForm frm = new ReportPreviewForm(rpt);
        }
        /// <summary>
        /// 리스트를 데이터테이블
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
