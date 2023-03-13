using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.MQTT;
using HslCommunication.Serial;
using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormSerialDebug : HslFormContent
	{
		private SerialPort SP_ReadData = null;

		private bool isBinary = true;

		private bool toledoThread = false;

		private Random random = new Random();

		private float toledoWeight = 30f;

		private MqttClient mqttClient;

		private IContainer components = null;

		private Panel panel1;

		private ComboBox comboBox1;

		private Label label24;

		private TextBox textBox17;

		private Label label23;

		private TextBox textBox16;

		private Label label22;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private Label label1;

		private Panel panel2;

		private TextBox textBox6;

		private CheckBox checkBox_show_time;

		private CheckBox checkBox_send_show;

		private Label label7;

		private Button button_send;

		private TextBox textBox5;

		private Label label6;

		private ComboBox comboBox2;

		private UserControlHead userControlHead1;

		private CheckBox checkBox5;

		private Button button6;

		private Panel panel3;

		private TextBox textBox1;

		private Label label2;

		private TextBox textBox7;

		private Label label4;

		private TextBox textBox8;

		private Label label5;

		private CheckBox checkBox6;

		private TextBox textBox9;

		private Label label8;

		private TextBox textBox10;

		private Label label9;

		private Label label10;

		private Label label11;

		private Label label12;

		private CheckBox checkBox_stop_show;

		private Panel panel4;

		private RadioButton radioButton_append_crc16;

		private RadioButton radioButton_append_0d0a;

		private RadioButton radioButton_append_none;

		private RadioButton radioButton_append_0a;

		private RadioButton radioButton_append_0d;

		private Label label_append;

		private Panel panel5;

		private RadioButton radioButton_ascii;

		private RadioButton radioButton_binary;

		private CheckBox checkBox_auto_return;

		public FormSerialDebug()
		{
			InitializeComponent();
		}

		private void FormSerialDebug_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			comboBox1.SelectedIndex = 0;
			comboBox2.DataSource = SerialPort.GetPortNames();
			try
			{
				comboBox2.SelectedIndex = 0;
			}
			catch
			{
				comboBox2.Text = "COM3";
			}
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language == 1)
			{
				Text = "串口调试助手";
				label1.Text = "Com口：";
				label3.Text = "波特率:";
				label22.Text = "数据位:";
				label23.Text = "停止位:";
				label24.Text = "奇偶：";
				button1.Text = "打开串口";
				button2.Text = "关闭串口";
				label6.Text = "数据发送区：";
				label7.Text = "数据接收区：";
				checkBox_send_show.Text = "是否显示发送数据";
				checkBox_show_time.Text = "是否显示时间";
				button_send.Text = "发送数据";
				comboBox1.DataSource = new string[3]
				{
					"无",
					"奇",
					"偶"
				};
			}
			else
			{
				Text = "Serial Debug Tools";
				label1.Text = "Com:";
				label3.Text = "Baud rate:";
				label22.Text = "Data bits:";
				label23.Text = "Stop bits:";
				label24.Text = "parity:";
				button1.Text = "Open";
				button2.Text = "Close";
				label6.Text = "Data sending Area:";
				label7.Text = "Data receiving Area:";
				checkBox_send_show.Text = "Whether to display send data";
				checkBox_show_time.Text = "Whether to show time";
				button_send.Text = "Send Data";
				label8.Text = "Number of data bytes selected:";
				checkBox_stop_show.Text = "Stop Show";
				comboBox1.DataSource = new string[3]
				{
					"None",
					"Odd",
					"Even"
				};
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			int result2;
			int result3;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show((Program.Language == 1) ? "波特率输入错误！" : "Baud rate input error");
			}
			else if (!int.TryParse(textBox16.Text, out result2))
			{
				MessageBox.Show((Program.Language == 1) ? "数据位输入错误！" : "Data bits input error");
			}
			else if (!int.TryParse(textBox17.Text, out result3))
			{
				MessageBox.Show((Program.Language == 1) ? "停止位输入错误！" : "Stop bits input error");
			}
			else
			{
				if (checkBox6.Checked)
				{
					MqttClient obj = mqttClient;
					if (obj != null)
					{
						obj.ConnectClose();
					}
					mqttClient = new MqttClient(new MqttConnectionOptions
					{
						IpAddress = textBox8.Text,
						Port = int.Parse(textBox7.Text),
						Credentials = new MqttCredential(textBox10.Text, textBox9.Text),
						ConnectTimeout = 3000
					});
					OperateResult operateResult = mqttClient.ConnectServer();
					if (!operateResult.IsSuccess)
					{
						MessageBox.Show("MQTT Connected failed, not use it");
						mqttClient = null;
					}
				}
				SP_ReadData = new SerialPort();
				SP_ReadData.PortName = comboBox2.Text;
				SP_ReadData.BaudRate = result;
				SP_ReadData.DataBits = result2;
				SerialPort sP_ReadData = SP_ReadData;
				int stopBits;
				switch (result3)
				{
				default:
					stopBits = 2;
					break;
				case 1:
					stopBits = 1;
					break;
				case 0:
					stopBits = 0;
					break;
				}
				sP_ReadData.StopBits = (StopBits)stopBits;
				SP_ReadData.Parity = ((comboBox1.SelectedIndex != 0) ? ((comboBox1.SelectedIndex == 1) ? Parity.Odd : Parity.Even) : Parity.None);
				SP_ReadData.RtsEnable = checkBox5.Checked;
				try
				{
					SP_ReadData.DataReceived += SP_ReadData_DataReceived;
					SP_ReadData.Open();
					button1.Enabled = false;
					button2.Enabled = true;
					panel2.Enabled = true;
				}
				catch (Exception ex)
				{
					SoftBasic.ShowExceptionMessage(ex);
				}
			}
		}

		private void RadioButton_binary_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton_binary.Checked)
			{
				isBinary = true;
			}
			else
			{
				isBinary = false;
			}
		}

		private string GetTextHeader(int code, byte[] info)
		{
			if (isBinary)
			{
				return GetTextHeader(code, SoftBasic.ByteToHexString(info, ' '));
			}
			return GetTextHeader(code, SoftBasic.GetAsciiStringRender(info));
		}

		private string GetTextHeader(int code, string info)
		{
			string empty = string.Empty;
			if (Program.Language == 1)
			{
				object obj;
				switch (code)
				{
				default:
					obj = "None";
					break;
				case 2:
					obj = "关";
					break;
				case 1:
					obj = "发";
					break;
				case 0:
					obj = "收";
					break;
				}
				empty = (string)obj;
			}
			else
			{
				object obj2;
				switch (code)
				{
				default:
					obj2 = "None";
					break;
				case 2:
					obj2 = "Clos";
					break;
				case 1:
					obj2 = "Send";
					break;
				case 0:
					obj2 = "Recv";
					break;
				}
				empty = (string)obj2;
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (checkBox_show_time.Checked)
			{
				stringBuilder.Append("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "] ");
			}
			stringBuilder.Append("[" + empty + "]   ");
			stringBuilder.Append(info);
			stringBuilder.AppendLine();
			return stringBuilder.ToString();
		}

		private void SP_ReadData_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			List<byte> buffer = new List<byte>();
			byte[] array = new byte[1024];
			while (true)
			{
				Thread.Sleep(20);
				if (SP_ReadData.BytesToRead < 1)
				{
					break;
				}
				int num = SP_ReadData.Read(array, 0, Math.Min(SP_ReadData.BytesToRead, array.Length));
				byte[] array2 = new byte[num];
				Array.Copy(array, 0, array2, 0, num);
				buffer.AddRange(array2);
			}
			if (buffer.Count != 0)
			{
				MqttClient obj = mqttClient;
				if (obj != null)
				{
					obj.PublishMessage(new MqttApplicationMessage
					{
						Topic = textBox1.Text,
						Payload = buffer.ToArray()
					});
				}
				Invoke((Action)delegate
				{
					if (!checkBox_stop_show.Checked)
					{
						textBox6.AppendText(GetTextHeader(0, buffer.ToArray()));
					}
					if (checkBox_auto_return.Checked)
					{
						button_send.PerformClick();
					}
				});
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			byte[] array = isBinary ? SoftBasic.HexStringToBytes(textBox5.Text) : SoftBasic.GetFromAsciiStringRender(textBox5.Text);
			if (radioButton_append_0d.Checked)
			{
				array = SoftBasic.SpliceArray<byte>(array, new byte[1]
				{
					13
				});
			}
			else if (radioButton_append_0a.Checked)
			{
				array = SoftBasic.SpliceArray<byte>(array, new byte[1]
				{
					10
				});
			}
			else if (radioButton_append_0d0a.Checked)
			{
				array = SoftBasic.SpliceArray<byte>(array, new byte[2]
				{
					13,
					10
				});
			}
			else if (radioButton_append_crc16.Checked)
			{
				array = SoftCRC16.CRC16(array);
			}
			if (array != null)
			{
				try
				{
					SerialPort sP_ReadData = SP_ReadData;
					if (sP_ReadData != null)
					{
						sP_ReadData.Write(array, 0, array.Length);
					}
					if (checkBox_send_show.Checked)
					{
						textBox6.AppendText(GetTextHeader(1, array));
					}
				}
				catch (Exception ex)
				{
					SoftBasic.ShowExceptionMessage(ex);
				}
			}
		}

		private void textBox5_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				button_send.PerformClick();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				SP_ReadData.Close();
				button2.Enabled = false;
				button1.Enabled = true;
				panel2.Enabled = false;
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage(ex);
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (button6.BackColor != Color.Green)
			{
				toledoThread = true;
				button6.BackColor = Color.Green;
				Thread thread = new Thread(ToledoTest);
				thread.IsBackground = true;
				thread.Start();
			}
			else
			{
				toledoThread = false;
				button6.BackColor = SystemColors.Control;
			}
		}

		private void ToledoTest()
		{
			while (toledoThread)
			{
				Thread.Sleep(50);
				byte[] array = "02 2C 30 20 20 20 33 38 36 32 20 20 20 30 30 30 0D".ToHexBytes();
				toledoWeight += (float)random.Next(200) / 100f - 1f;
				if (toledoWeight < 0f)
				{
					toledoWeight = 5f;
				}
				if (toledoWeight > 100f)
				{
					toledoWeight = 95f;
				}
				string s = toledoWeight.ToString("F2").Replace(".", "").PadLeft(6, ' ');
				Encoding.ASCII.GetBytes(s).CopyTo(array, 4);
				try
				{
					SerialPort sP_ReadData = SP_ReadData;
					if (sP_ReadData != null)
					{
						sP_ReadData.Write(array, 0, array.Length);
					}
				}
				catch (Exception ex)
				{
					SoftBasic.ShowExceptionMessage(ex);
					return;
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
			panel3 = new System.Windows.Forms.Panel();
			textBox9 = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			textBox10 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox7 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox8 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			checkBox6 = new System.Windows.Forms.CheckBox();
			checkBox5 = new System.Windows.Forms.CheckBox();
			comboBox2 = new System.Windows.Forms.ComboBox();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label24 = new System.Windows.Forms.Label();
			textBox17 = new System.Windows.Forms.TextBox();
			label23 = new System.Windows.Forms.Label();
			textBox16 = new System.Windows.Forms.TextBox();
			label22 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			panel4 = new System.Windows.Forms.Panel();
			radioButton_append_crc16 = new System.Windows.Forms.RadioButton();
			radioButton_append_0d0a = new System.Windows.Forms.RadioButton();
			radioButton_append_none = new System.Windows.Forms.RadioButton();
			radioButton_append_0a = new System.Windows.Forms.RadioButton();
			radioButton_append_0d = new System.Windows.Forms.RadioButton();
			label_append = new System.Windows.Forms.Label();
			panel5 = new System.Windows.Forms.Panel();
			radioButton_ascii = new System.Windows.Forms.RadioButton();
			radioButton_binary = new System.Windows.Forms.RadioButton();
			checkBox_stop_show = new System.Windows.Forms.CheckBox();
			button6 = new System.Windows.Forms.Button();
			textBox6 = new System.Windows.Forms.TextBox();
			checkBox_show_time = new System.Windows.Forms.CheckBox();
			checkBox_send_show = new System.Windows.Forms.CheckBox();
			label7 = new System.Windows.Forms.Label();
			button_send = new System.Windows.Forms.Button();
			textBox5 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			checkBox_auto_return = new System.Windows.Forms.CheckBox();
			panel1.SuspendLayout();
			panel3.SuspendLayout();
			panel2.SuspendLayout();
			panel4.SuspendLayout();
			panel5.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(panel3);
			panel1.Controls.Add(checkBox5);
			panel1.Controls.Add(comboBox2);
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(label24);
			panel1.Controls.Add(textBox17);
			panel1.Controls.Add(label23);
			panel1.Controls.Add(textBox16);
			panel1.Controls.Add(label22);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(3, 34);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(993, 77);
			panel1.TabIndex = 7;
			panel3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel3.Controls.Add(textBox9);
			panel3.Controls.Add(label8);
			panel3.Controls.Add(textBox10);
			panel3.Controls.Add(label9);
			panel3.Controls.Add(textBox1);
			panel3.Controls.Add(label2);
			panel3.Controls.Add(textBox7);
			panel3.Controls.Add(label4);
			panel3.Controls.Add(textBox8);
			panel3.Controls.Add(label5);
			panel3.Controls.Add(checkBox6);
			panel3.Location = new System.Drawing.Point(3, 40);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(985, 32);
			panel3.TabIndex = 18;
			textBox9.Location = new System.Drawing.Point(620, 3);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(110, 23);
			textBox9.TabIndex = 23;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(570, 6);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(44, 17);
			label8.TabIndex = 22;
			label8.Text = "Pwd：";
			textBox10.Location = new System.Drawing.Point(449, 4);
			textBox10.Name = "textBox10";
			textBox10.Size = new System.Drawing.Size(110, 23);
			textBox10.TabIndex = 21;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(396, 7);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(55, 17);
			label9.TabIndex = 20;
			label9.Text = "Name：";
			textBox1.Location = new System.Drawing.Point(795, 4);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(103, 23);
			textBox1.TabIndex = 19;
			textBox1.Text = "Data";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(736, 7);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(52, 17);
			label2.TabIndex = 18;
			label2.Text = "Topic：";
			textBox7.Location = new System.Drawing.Point(323, 3);
			textBox7.Name = "textBox7";
			textBox7.Size = new System.Drawing.Size(55, 23);
			textBox7.TabIndex = 17;
			textBox7.Text = "1883";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(274, 6);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(44, 17);
			label4.TabIndex = 16;
			label4.Text = "Port：";
			textBox8.Location = new System.Drawing.Point(139, 4);
			textBox8.Name = "textBox8";
			textBox8.Size = new System.Drawing.Size(129, 23);
			textBox8.TabIndex = 15;
			textBox8.Text = "127.0.0.1";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(107, 7);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(31, 17);
			label5.TabIndex = 14;
			label5.Text = "IP：";
			checkBox6.AutoSize = true;
			checkBox6.Location = new System.Drawing.Point(4, 5);
			checkBox6.Name = "checkBox6";
			checkBox6.Size = new System.Drawing.Size(87, 21);
			checkBox6.TabIndex = 0;
			checkBox6.Text = "转发MQTT";
			checkBox6.UseVisualStyleBackColor = true;
			checkBox5.AutoSize = true;
			checkBox5.Location = new System.Drawing.Point(578, 13);
			checkBox5.Name = "checkBox5";
			checkBox5.Size = new System.Drawing.Size(84, 21);
			checkBox5.TabIndex = 17;
			checkBox5.Text = "RtsEnable";
			checkBox5.UseVisualStyleBackColor = true;
			comboBox2.FormattingEnabled = true;
			comboBox2.Location = new System.Drawing.Point(62, 8);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new System.Drawing.Size(84, 25);
			comboBox2.TabIndex = 16;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[3]
			{
				"无",
				"奇",
				"偶"
			});
			comboBox1.Location = new System.Drawing.Point(503, 10);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(59, 25);
			comboBox1.TabIndex = 15;
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(460, 13);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(44, 17);
			label24.TabIndex = 14;
			label24.Text = "奇偶：";
			textBox17.Location = new System.Drawing.Point(430, 10);
			textBox17.Name = "textBox17";
			textBox17.Size = new System.Drawing.Size(23, 23);
			textBox17.TabIndex = 13;
			textBox17.Text = "1";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(371, 13);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(56, 17);
			label23.TabIndex = 12;
			label23.Text = "停止位：";
			textBox16.Location = new System.Drawing.Point(334, 10);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(24, 23);
			textBox16.TabIndex = 11;
			textBox16.Text = "8";
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(272, 13);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(56, 17);
			label22.TabIndex = 10;
			label22.Text = "数据位：";
			button2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(892, 8);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭串口";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button1.Location = new System.Drawing.Point(795, 8);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "打开串口";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(219, 10);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(47, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "9600";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(152, 13);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "波特率：";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 13);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(59, 17);
			label1.TabIndex = 0;
			label1.Text = "Com口：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(checkBox_auto_return);
			panel2.Controls.Add(panel4);
			panel2.Controls.Add(panel5);
			panel2.Controls.Add(checkBox_stop_show);
			panel2.Controls.Add(button6);
			panel2.Controls.Add(textBox6);
			panel2.Controls.Add(checkBox_show_time);
			panel2.Controls.Add(checkBox_send_show);
			panel2.Controls.Add(label7);
			panel2.Controls.Add(button_send);
			panel2.Controls.Add(textBox5);
			panel2.Controls.Add(label6);
			panel2.Controls.Add(label10);
			panel2.Controls.Add(label11);
			panel2.Controls.Add(label12);
			panel2.Location = new System.Drawing.Point(3, 114);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(993, 550);
			panel2.TabIndex = 13;
			panel4.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			panel4.BackColor = System.Drawing.SystemColors.Control;
			panel4.Controls.Add(radioButton_append_crc16);
			panel4.Controls.Add(radioButton_append_0d0a);
			panel4.Controls.Add(radioButton_append_none);
			panel4.Controls.Add(radioButton_append_0a);
			panel4.Controls.Add(radioButton_append_0d);
			panel4.Controls.Add(label_append);
			panel4.Location = new System.Drawing.Point(240, 424);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(348, 28);
			panel4.TabIndex = 39;
			radioButton_append_crc16.AutoSize = true;
			radioButton_append_crc16.Location = new System.Drawing.Point(281, 3);
			radioButton_append_crc16.Name = "radioButton_append_crc16";
			radioButton_append_crc16.Size = new System.Drawing.Size(57, 21);
			radioButton_append_crc16.TabIndex = 5;
			radioButton_append_crc16.Text = "crc16";
			radioButton_append_crc16.UseVisualStyleBackColor = true;
			radioButton_append_0d0a.AutoSize = true;
			radioButton_append_0d0a.Location = new System.Drawing.Point(223, 3);
			radioButton_append_0d0a.Name = "radioButton_append_0d0a";
			radioButton_append_0d0a.Size = new System.Drawing.Size(48, 21);
			radioButton_append_0d0a.TabIndex = 4;
			radioButton_append_0d0a.Text = "\\r\\n";
			radioButton_append_0d0a.UseVisualStyleBackColor = true;
			radioButton_append_none.AutoSize = true;
			radioButton_append_none.Checked = true;
			radioButton_append_none.Location = new System.Drawing.Point(69, 4);
			radioButton_append_none.Name = "radioButton_append_none";
			radioButton_append_none.Size = new System.Drawing.Size(58, 21);
			radioButton_append_none.TabIndex = 3;
			radioButton_append_none.TabStop = true;
			radioButton_append_none.Text = "None";
			radioButton_append_none.UseVisualStyleBackColor = true;
			radioButton_append_0a.AutoSize = true;
			radioButton_append_0a.Location = new System.Drawing.Point(179, 3);
			radioButton_append_0a.Name = "radioButton_append_0a";
			radioButton_append_0a.Size = new System.Drawing.Size(38, 21);
			radioButton_append_0a.TabIndex = 1;
			radioButton_append_0a.Text = "\\n";
			radioButton_append_0a.UseVisualStyleBackColor = true;
			radioButton_append_0d.AutoSize = true;
			radioButton_append_0d.Location = new System.Drawing.Point(133, 3);
			radioButton_append_0d.Name = "radioButton_append_0d";
			radioButton_append_0d.Size = new System.Drawing.Size(36, 21);
			radioButton_append_0d.TabIndex = 0;
			radioButton_append_0d.Text = "\\r";
			radioButton_append_0d.UseVisualStyleBackColor = true;
			label_append.AutoSize = true;
			label_append.Location = new System.Drawing.Point(4, 5);
			label_append.Name = "label_append";
			label_append.Size = new System.Drawing.Size(57, 17);
			label_append.TabIndex = 2;
			label_append.Text = "Append:";
			panel5.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			panel5.BackColor = System.Drawing.SystemColors.Control;
			panel5.Controls.Add(radioButton_ascii);
			panel5.Controls.Add(radioButton_binary);
			panel5.Location = new System.Drawing.Point(79, 424);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(155, 28);
			panel5.TabIndex = 38;
			radioButton_ascii.AutoSize = true;
			radioButton_ascii.Location = new System.Drawing.Point(86, 3);
			radioButton_ascii.Name = "radioButton_ascii";
			radioButton_ascii.Size = new System.Drawing.Size(57, 21);
			radioButton_ascii.TabIndex = 1;
			radioButton_ascii.Text = "ASCII";
			radioButton_ascii.UseVisualStyleBackColor = true;
			radioButton_binary.AutoSize = true;
			radioButton_binary.Checked = true;
			radioButton_binary.Location = new System.Drawing.Point(7, 3);
			radioButton_binary.Name = "radioButton_binary";
			radioButton_binary.Size = new System.Drawing.Size(62, 21);
			radioButton_binary.TabIndex = 0;
			radioButton_binary.TabStop = true;
			radioButton_binary.Text = "Binary";
			radioButton_binary.UseVisualStyleBackColor = true;
			radioButton_binary.CheckedChanged += new System.EventHandler(RadioButton_binary_CheckedChanged);
			checkBox_stop_show.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			checkBox_stop_show.AutoSize = true;
			checkBox_stop_show.Location = new System.Drawing.Point(874, 448);
			checkBox_stop_show.Name = "checkBox_stop_show";
			checkBox_stop_show.Size = new System.Drawing.Size(75, 21);
			checkBox_stop_show.TabIndex = 37;
			checkBox_stop_show.Text = "暂停显示";
			checkBox_stop_show.UseVisualStyleBackColor = true;
			button6.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			button6.Location = new System.Drawing.Point(637, 424);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(120, 28);
			button6.TabIndex = 27;
			button6.Text = "toledo msg test";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			textBox6.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox6.Location = new System.Drawing.Point(3, 22);
			textBox6.Multiline = true;
			textBox6.Name = "textBox6";
			textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox6.Size = new System.Drawing.Size(985, 401);
			textBox6.TabIndex = 21;
			checkBox_show_time.AutoSize = true;
			checkBox_show_time.Checked = true;
			checkBox_show_time.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox_show_time.Location = new System.Drawing.Point(330, 1);
			checkBox_show_time.Name = "checkBox_show_time";
			checkBox_show_time.Size = new System.Drawing.Size(99, 21);
			checkBox_show_time.TabIndex = 20;
			checkBox_show_time.Text = "是否显示时间";
			checkBox_show_time.UseVisualStyleBackColor = true;
			checkBox_send_show.AutoSize = true;
			checkBox_send_show.Checked = true;
			checkBox_send_show.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox_send_show.Location = new System.Drawing.Point(143, 1);
			checkBox_send_show.Name = "checkBox_send_show";
			checkBox_send_show.Size = new System.Drawing.Size(123, 21);
			checkBox_send_show.TabIndex = 19;
			checkBox_send_show.Text = "是否显示发送数据";
			checkBox_send_show.UseVisualStyleBackColor = true;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(5, 2);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(92, 17);
			label7.TabIndex = 18;
			label7.Text = "数据收发显示：";
			button_send.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			button_send.Location = new System.Drawing.Point(871, 490);
			button_send.Name = "button_send";
			button_send.Size = new System.Drawing.Size(112, 38);
			button_send.TabIndex = 17;
			button_send.Text = "发送数据";
			button_send.UseVisualStyleBackColor = true;
			button_send.Click += new System.EventHandler(button3_Click);
			textBox5.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox5.Location = new System.Drawing.Point(3, 452);
			textBox5.Multiline = true;
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(862, 74);
			textBox5.TabIndex = 16;
			textBox5.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox5_KeyDown);
			label6.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(5, 428);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(80, 17);
			label6.TabIndex = 1;
			label6.Text = "数据发送区：";
			label10.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label10.AutoSize = true;
			label10.ForeColor = System.Drawing.Color.Gray;
			label10.Location = new System.Drawing.Point(600, 528);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(78, 17);
			label10.TabIndex = 36;
			label10.Text = "Send Count:";
			label11.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label11.AutoSize = true;
			label11.ForeColor = System.Drawing.Color.Gray;
			label11.Location = new System.Drawing.Point(295, 528);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(273, 17);
			label11.TabIndex = 35;
			label11.Text = "If ASCII Format: use \\r , \\n means  0x0d  0x0a";
			label12.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label12.AutoSize = true;
			label12.ForeColor = System.Drawing.Color.Gray;
			label12.Location = new System.Drawing.Point(3, 528);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(116, 17);
			label12.TabIndex = 34;
			label12.Text = "已选择数据字节数：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/8974215.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "serial";
			userControlHead1.Size = new System.Drawing.Size(1000, 32);
			userControlHead1.TabIndex = 14;
			checkBox_auto_return.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			checkBox_auto_return.AutoSize = true;
			checkBox_auto_return.Location = new System.Drawing.Point(874, 468);
			checkBox_auto_return.Name = "checkBox_auto_return";
			checkBox_auto_return.Size = new System.Drawing.Size(75, 21);
			checkBox_auto_return.TabIndex = 40;
			checkBox_auto_return.Text = "自动返回";
			checkBox_auto_return.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1000, 666);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormSerialDebug";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "串口调试工具";
			base.Load += new System.EventHandler(FormSerialDebug_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			ResumeLayout(false);
		}
	}
}
