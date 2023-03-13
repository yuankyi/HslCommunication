using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.LogNet;
using HslCommunication.Profinet.Geniitek;
using HslCommunicationDemo.DemoControl;
using HslControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormVibrationSensorClient : HslFormContent
	{
		private VibrationSensorClient client;

		private int receiveCount = 0;

		private long receiveTotalCount = 0L;

		private SharpList<VibrationSensorActualValue> actValues = new SharpList<VibrationSensorActualValue>(1024);

		private IContainer components = null;

		private Panel panel1;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private Label label1;

		private Panel panel2;

		private TextBox textBox8;

		private Label label12;

		private Button button4;

		private Button button3;

		private UserControlHead userControlHead1;

		private TextBox textBox5;

		private Label label5;

		private Button button6;

		private TextBox textBox3;

		private Button button5;

		private HslPanelHead hslPanelHead2;

		private Label label18;

		private TextBox textBox20;

		private TextBox textBox19;

		private Label label19;

		private Label label17;

		private TextBox textBox17;

		private TextBox textBox18;

		private Label label16;

		private HslPanelHead hslPanelHead1;

		private Label label2;

		private TextBox textBox4;

		private Label label4;

		private TextBox textBox6;

		private Label label6;

		private TextBox textBox7;

		private Label label9;

		private TextBox textBox11;

		private TextBox textBox15;

		private Label label8;

		private Label label14;

		private TextBox textBox10;

		private TextBox textBox16;

		private Label label7;

		private Label label15;

		private TextBox textBox9;

		private TextBox textBox12;

		private Label label13;

		private Label label10;

		private TextBox textBox14;

		private TextBox textBox13;

		private Label label11;

		public FormVibrationSensorClient()
		{
			InitializeComponent();
		}

		private void FormClient_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			button2.Enabled = false;
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "VibrationSensor Client Test";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			ushort result2;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show(DemoUtils.PortInputWrong);
			}
			else if (!ushort.TryParse(textBox5.Text, out result2))
			{
				MessageBox.Show("Address input wrong!");
			}
			else
			{
				VibrationSensorClient vibrationSensorClient = client;
				if (vibrationSensorClient != null)
				{
					vibrationSensorClient.ConnectClose();
				}
				client = new VibrationSensorClient(textBox1.Text, result);
				client.Address = result2;
				client.LogNet = new LogNetSingle(string.Empty);
				client.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
				client.OnPeekValueReceive += Client_OnPeekValueReceive;
				client.OnActualValueReceive += Client_OnActualValueReceive;
				client.OnNetworkError += WsClient_OnNetworkError;
				OperateResult operateResult = client.ConnectServer();
				if (operateResult.IsSuccess)
				{
					button1.Enabled = false;
					button2.Enabled = true;
					panel2.Enabled = true;
					MessageBox.Show(StringResources.Language.ConnectServerSuccess);
				}
				else
				{
					MessageBox.Show(StringResources.Language.ConnectedFailed + operateResult.ToMessageShowString());
				}
			}
		}

		private void Client_OnActualValueReceive(VibrationSensorActualValue actualValue)
		{
			receiveCount++;
			receiveTotalCount++;
			actValues.Add(actualValue);
			if (receiveCount == 4096)
			{
				Invoke((Action)delegate
				{
					textBox19.Text = actualValue.AcceleratedSpeedX.ToString();
					textBox18.Text = actualValue.AcceleratedSpeedY.ToString();
					textBox17.Text = actualValue.AcceleratedSpeedZ.ToString();
					textBox20.Text = receiveTotalCount.ToString();
				});
				receiveCount = 0;
			}
		}

		private void Client_OnPeekValueReceive(VibrationSensorPeekValue peekValue)
		{
			if (base.InvokeRequired)
			{
				Invoke(new Action<VibrationSensorPeekValue>(Client_OnPeekValueReceive), peekValue);
			}
			else
			{
				textBox4.Text = peekValue.AcceleratedSpeedX.ToString();
				textBox6.Text = peekValue.AcceleratedSpeedY.ToString();
				textBox7.Text = peekValue.AcceleratedSpeedZ.ToString();
				textBox11.Text = peekValue.SpeedX.ToString();
				textBox10.Text = peekValue.SpeedY.ToString();
				textBox9.Text = peekValue.SpeedZ.ToString();
				textBox14.Text = peekValue.OffsetX.ToString();
				textBox13.Text = peekValue.OffsetY.ToString();
				textBox12.Text = peekValue.OffsetZ.ToString();
				textBox16.Text = peekValue.Temperature.ToString();
				textBox15.Text = peekValue.Voltage.ToString();
			}
		}

		private void WsClient_OnNetworkError(object sender, EventArgs e)
		{
			VibrationSensorClient vibrationSensorClient = sender as VibrationSensorClient;
			if (vibrationSensorClient != null)
			{
				ILogNet logNet = vibrationSensorClient.LogNet;
				if (logNet != null)
				{
					logNet.WriteInfo("网络异常，准备10秒后重新连接。");
				}
				while (true)
				{
					Thread.Sleep(10000);
					ILogNet logNet2 = vibrationSensorClient.LogNet;
					if (logNet2 != null)
					{
						logNet2.WriteInfo("准备重新连接服务器...");
					}
					OperateResult operateResult = vibrationSensorClient.ConnectServer();
					if (operateResult.IsSuccess)
					{
						break;
					}
					ILogNet logNet3 = vibrationSensorClient.LogNet;
					if (logNet3 != null)
					{
						logNet3.WriteInfo("连接失败，准备10秒后重新连接。");
					}
				}
				ILogNet logNet4 = vibrationSensorClient.LogNet;
				if (logNet4 != null)
				{
					logNet4.WriteInfo("连接服务器成功！");
				}
			}
		}

		private void LogNet_BeforeSaveToFile(object sender, HslEventArgs e)
		{
			try
			{
				Invoke((Action)delegate
				{
					textBox8.AppendText(e.HslMessage.ToString() + Environment.NewLine);
				});
			}
			catch
			{
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;
			VibrationSensorClient vibrationSensorClient = client;
			if (vibrationSensorClient != null)
			{
				vibrationSensorClient.ConnectClose();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = client.SetReadStatus();
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Send Failed:" + operateResult.Message);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			textBox8.Clear();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = client.SetReadActual();
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Send Failed:" + operateResult.Message);
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			int result;
			if (int.TryParse(textBox3.Text, out result))
			{
				OperateResult operateResult = client.SetReadStatusInterval(result);
				if (!operateResult.IsSuccess)
				{
					MessageBox.Show("Send Failed:" + operateResult.Message);
				}
				else
				{
					MessageBox.Show("Success");
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			panel1 = new System.Windows.Forms.Panel();
			textBox5 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			hslPanelHead2 = new HslControls.HslPanelHead();
			button5 = new System.Windows.Forms.Button();
			label18 = new System.Windows.Forms.Label();
			textBox20 = new System.Windows.Forms.TextBox();
			textBox19 = new System.Windows.Forms.TextBox();
			label19 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			textBox17 = new System.Windows.Forms.TextBox();
			textBox18 = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			hslPanelHead1 = new HslControls.HslPanelHead();
			button3 = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			textBox7 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			textBox11 = new System.Windows.Forms.TextBox();
			textBox15 = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			textBox10 = new System.Windows.Forms.TextBox();
			textBox16 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			textBox9 = new System.Windows.Forms.TextBox();
			textBox12 = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			textBox14 = new System.Windows.Forms.TextBox();
			textBox13 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			button6 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			textBox8 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			button4 = new System.Windows.Forms.Button();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			hslPanelHead2.SuspendLayout();
			hslPanelHead1.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox5);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 75);
			panel1.TabIndex = 7;
			textBox5.Location = new System.Drawing.Point(412, 18);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(91, 23);
			textBox5.TabIndex = 20;
			textBox5.Text = "1";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(348, 21);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(44, 17);
			label5.TabIndex = 19;
			label5.Text = "地址：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(633, 15);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(536, 15);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(253, 18);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(79, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "3001";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(199, 21);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 18);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(131, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "192.168.1.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 21);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(hslPanelHead2);
			panel2.Controls.Add(hslPanelHead1);
			panel2.Controls.Add(button6);
			panel2.Controls.Add(textBox3);
			panel2.Controls.Add(textBox8);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(button4);
			panel2.Location = new System.Drawing.Point(3, 115);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 529);
			panel2.TabIndex = 13;
			hslPanelHead2.Controls.Add(button5);
			hslPanelHead2.Controls.Add(label18);
			hslPanelHead2.Controls.Add(textBox20);
			hslPanelHead2.Controls.Add(textBox19);
			hslPanelHead2.Controls.Add(label19);
			hslPanelHead2.Controls.Add(label17);
			hslPanelHead2.Controls.Add(textBox17);
			hslPanelHead2.Controls.Add(textBox18);
			hslPanelHead2.Controls.Add(label16);
			hslPanelHead2.Location = new System.Drawing.Point(467, 6);
			hslPanelHead2.Name = "hslPanelHead2";
			hslPanelHead2.Size = new System.Drawing.Size(227, 216);
			hslPanelHead2.TabIndex = 54;
			hslPanelHead2.Text = "实时读取";
			button5.Location = new System.Drawing.Point(19, 38);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(99, 28);
			button5.TabIndex = 20;
			button5.Text = "读取实时加速度";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(16, 81);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(64, 17);
			label18.TabIndex = 45;
			label18.Text = "加速度X：";
			textBox20.Location = new System.Drawing.Point(85, 175);
			textBox20.Name = "textBox20";
			textBox20.Size = new System.Drawing.Size(91, 23);
			textBox20.TabIndex = 52;
			textBox20.Text = "0";
			textBox19.Location = new System.Drawing.Point(84, 78);
			textBox19.Name = "textBox19";
			textBox19.Size = new System.Drawing.Size(91, 23);
			textBox19.TabIndex = 46;
			textBox19.Text = "0";
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(17, 178);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(56, 17);
			label19.TabIndex = 51;
			label19.Text = "数据量：";
			label17.AutoSize = true;
			label17.Location = new System.Drawing.Point(16, 108);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(63, 17);
			label17.TabIndex = 47;
			label17.Text = "加速度Y：";
			textBox17.Location = new System.Drawing.Point(84, 132);
			textBox17.Name = "textBox17";
			textBox17.Size = new System.Drawing.Size(91, 23);
			textBox17.TabIndex = 50;
			textBox17.Text = "0";
			textBox18.Location = new System.Drawing.Point(84, 105);
			textBox18.Name = "textBox18";
			textBox18.Size = new System.Drawing.Size(91, 23);
			textBox18.TabIndex = 48;
			textBox18.Text = "0";
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(16, 135);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(63, 17);
			label16.TabIndex = 49;
			label16.Text = "加速度Z：";
			hslPanelHead1.Controls.Add(button3);
			hslPanelHead1.Controls.Add(label2);
			hslPanelHead1.Controls.Add(textBox4);
			hslPanelHead1.Controls.Add(label4);
			hslPanelHead1.Controls.Add(textBox6);
			hslPanelHead1.Controls.Add(label6);
			hslPanelHead1.Controls.Add(textBox7);
			hslPanelHead1.Controls.Add(label9);
			hslPanelHead1.Controls.Add(textBox11);
			hslPanelHead1.Controls.Add(textBox15);
			hslPanelHead1.Controls.Add(label8);
			hslPanelHead1.Controls.Add(label14);
			hslPanelHead1.Controls.Add(textBox10);
			hslPanelHead1.Controls.Add(textBox16);
			hslPanelHead1.Controls.Add(label7);
			hslPanelHead1.Controls.Add(label15);
			hslPanelHead1.Controls.Add(textBox9);
			hslPanelHead1.Controls.Add(textBox12);
			hslPanelHead1.Controls.Add(label13);
			hslPanelHead1.Controls.Add(label10);
			hslPanelHead1.Controls.Add(textBox14);
			hslPanelHead1.Controls.Add(textBox13);
			hslPanelHead1.Controls.Add(label11);
			hslPanelHead1.Location = new System.Drawing.Point(4, 5);
			hslPanelHead1.Name = "hslPanelHead1";
			hslPanelHead1.Size = new System.Drawing.Size(457, 216);
			hslPanelHead1.TabIndex = 53;
			hslPanelHead1.Text = "状态读取";
			button3.Location = new System.Drawing.Point(350, 37);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(99, 28);
			button3.TabIndex = 12;
			button3.Text = "读取状态";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(9, 38);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(64, 17);
			label2.TabIndex = 23;
			label2.Text = "加速度X：";
			textBox4.Location = new System.Drawing.Point(75, 35);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(91, 23);
			textBox4.TabIndex = 24;
			textBox4.Text = "0";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(9, 65);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(63, 17);
			label4.TabIndex = 25;
			label4.Text = "加速度Y：";
			textBox6.Location = new System.Drawing.Point(75, 62);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(91, 23);
			textBox6.TabIndex = 26;
			textBox6.Text = "0";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(9, 92);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(63, 17);
			label6.TabIndex = 27;
			label6.Text = "加速度Z：";
			textBox7.Location = new System.Drawing.Point(75, 89);
			textBox7.Name = "textBox7";
			textBox7.Size = new System.Drawing.Size(91, 23);
			textBox7.TabIndex = 28;
			textBox7.Text = "0";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(9, 134);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(52, 17);
			label9.TabIndex = 29;
			label9.Text = "速度X：";
			textBox11.Location = new System.Drawing.Point(75, 131);
			textBox11.Name = "textBox11";
			textBox11.Size = new System.Drawing.Size(91, 23);
			textBox11.TabIndex = 30;
			textBox11.Text = "0";
			textBox15.Location = new System.Drawing.Point(247, 172);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(91, 23);
			textBox15.TabIndex = 44;
			textBox15.Text = "0";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(9, 161);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(51, 17);
			label8.TabIndex = 31;
			label8.Text = "速度Y：";
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(185, 175);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 43;
			label14.Text = "电压：";
			textBox10.Location = new System.Drawing.Point(75, 158);
			textBox10.Name = "textBox10";
			textBox10.Size = new System.Drawing.Size(91, 23);
			textBox10.TabIndex = 32;
			textBox10.Text = "0";
			textBox16.Location = new System.Drawing.Point(247, 145);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(91, 23);
			textBox16.TabIndex = 42;
			textBox16.Text = "0";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(9, 188);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(51, 17);
			label7.TabIndex = 33;
			label7.Text = "速度Z：";
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(185, 148);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(44, 17);
			label15.TabIndex = 41;
			label15.Text = "温度：";
			textBox9.Location = new System.Drawing.Point(75, 185);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(91, 23);
			textBox9.TabIndex = 34;
			textBox9.Text = "0";
			textBox12.Location = new System.Drawing.Point(246, 89);
			textBox12.Name = "textBox12";
			textBox12.Size = new System.Drawing.Size(91, 23);
			textBox12.TabIndex = 40;
			textBox12.Text = "0";
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(184, 38);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(52, 17);
			label13.TabIndex = 35;
			label13.Text = "位移X：";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(184, 92);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(51, 17);
			label10.TabIndex = 39;
			label10.Text = "位移Z：";
			textBox14.Location = new System.Drawing.Point(246, 35);
			textBox14.Name = "textBox14";
			textBox14.Size = new System.Drawing.Size(91, 23);
			textBox14.TabIndex = 36;
			textBox14.Text = "0";
			textBox13.Location = new System.Drawing.Point(246, 62);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(91, 23);
			textBox13.TabIndex = 38;
			textBox13.Text = "0";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(184, 65);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(51, 17);
			label11.TabIndex = 37;
			label11.Text = "位移Y：";
			button6.Location = new System.Drawing.Point(872, 3);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(91, 28);
			button6.TabIndex = 22;
			button6.Text = "设置时间";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			textBox3.Location = new System.Drawing.Point(700, 6);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(164, 23);
			textBox3.TabIndex = 21;
			textBox3.Text = "2";
			textBox8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox8.Location = new System.Drawing.Point(62, 237);
			textBox8.Multiline = true;
			textBox8.Name = "textBox8";
			textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox8.Size = new System.Drawing.Size(921, 284);
			textBox8.TabIndex = 18;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(3, 237);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(61, 17);
			label12.TabIndex = 19;
			label12.Text = "receive：";
			button4.Location = new System.Drawing.Point(872, 203);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(91, 28);
			button4.TabIndex = 17;
			button4.Text = "清空";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/12303098.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 14;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormVibrationSensorClient";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "震动传感器客户端";
			base.Load += new System.EventHandler(FormClient_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			hslPanelHead2.ResumeLayout(false);
			hslPanelHead2.PerformLayout();
			hslPanelHead1.ResumeLayout(false);
			hslPanelHead1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
