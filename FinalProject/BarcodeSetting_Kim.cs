using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class BarcodeSetting_Kim : Form
    {
        SerialPort _port;   //프라이빗 전역변수다 라는 의미로 _(언더바)를 붙이는 사람들도 있다.
        private bool IsOpen { get; set; }
        public BarcodeSetting_Kim()
        {
            InitializeComponent();
        }

        private void BarcodeSetting_Kim_Load(object sender, EventArgs e)
        {
            //IsOpen = false; //폼이 로드 될때는 연결이 아직 안되었을테니까
            //cboComPort.DataSource = SerialPort.GetPortNames();  //SerialPort의 GetPortName 메서드는 스트링의 배열로 현재 내 pc에 연결되어있는 포트이름들을 주고 그걸 바로 바인딩

            ////저장한 초기값으로 선택되게
            //cboComPort.SelectedIndex = cboComPort.Items.IndexOf(Properties.Settings.Default.PortName);  //읽어온 값(ex.COM3 이 오면 cbo안에 아이템중 COM3이 있는 인덱스 반환해서 그걸 셀렉트하게 하는
            //cboBaudRate.SelectedIndex = cboBaudRate.Items.IndexOf(Properties.Settings.Default.BaudRate);
            //cboDataSize.SelectedIndex = cboDataSize.Items.IndexOf(Properties.Settings.Default.DataSize);
            //cboParity.SelectedIndex = cboParity.Items.IndexOf(Properties.Settings.Default.Parity);
            //cboHandShake.SelectedIndex = cboHandShake.Items.IndexOf(Properties.Settings.Default.HandShake);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!IsOpen)  //btnConnect.Text == "연결"
            {
                if (_port == null)  //연결버튼 누를때마다 생성이 아닌 한번만
                {
                    _port = new SerialPort();
                    _port.DataReceived += _port_DataReceived;

                }
                _port.PortName = cboComPort.SelectedItem.ToString();
                _port.BaudRate = Convert.ToInt32(cboBaudRate.SelectedItem);
                _port.DataBits = Convert.ToInt32(cboDataSize.SelectedItem);
                _port.Parity = (Parity)cboParity.SelectedIndex;     //cboParity에 문자열로 값을 줬는데 이게 Parity는 열거형이기떄문에 이렇게 하고 Parity호 혈변환(Parity에 none == 1...이런식으로 되어앗다,
                _port.Handshake = (Handshake)cboHandShake.SelectedIndex;

                try
                {
                    _port.Open();
                    btnConnect.Text = "연결끊기";
                    IsOpen = true;

                    textBox1.AppendText("연결 됨");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                _port.Close();
                IsOpen = false;
            }
        }

        private void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);  //0.5초 정도만 있다가 실행해라. 밑에서 msg를 AppendText할때 크로스쓰레드 오류가 나기도 해서
            //즉 아래 msg쪽에 ReadExisting를 실행하는 쓰레드가 메인쓰레드가 아니기때문에 크로스쓰레드가 발생. 그래서 invoke를 해줘야한다.

            string msg = _port.ReadExisting();
            this.Invoke(new EventHandler(delegate { textBox1.AppendText(msg); }));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //    if (cboBaudRate.Text.Length < 1)
            //    {
            //        MessageBox.Show("BaudRate를 선택해주세요.");
            //        return;
            //    }
            //    Properties.Settings.Default.PortName = cboComPort.Text;
            //    Properties.Settings.Default.BaudRate = cboBaudRate.Text;
            //    Properties.Settings.Default.DataSize = cboDataSize.Text;
            //    Properties.Settings.Default.Parity = cboParity.Text;
            //    Properties.Settings.Default.HandShake = cboHandShake.Text;

            //    Properties.Settings.Default.Save();     //이 Save를 해줘야 저장이 된다.

            //    MessageBox.Show("시리얼포트 설정이 저장되었습니다.");
        }

        private void BarcodeSetting_Kim_FormClosing(object sender, FormClosingEventArgs e)
        {
            //만약 연결을 했는데 연결을 끊지않고 창을 닫는 버튼을 눌렀을때
            if (IsOpen)
            {
                _port.Close();  //이게 mdi에서 사용된다고 하면 여러개가 사용할때 이 사용하던 폼을 그냥 닫아버리면 연결이 안끊어지면 다른 폼에서 포트에 연결을 못하기때문에
                                //꼭 체크해줘야한다.
            }
        }
    }
}
