using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Profinet.Keyence;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormKeyenceNanoSerial : HslFormContent
	{
		private KeyenceNanoSerial keyenceNanoSerial = null;

		private IContainer components = null;

		private Panel panel1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private GroupBox groupBox4;

		private TextBox textBox11;

		private Label label14;

		private Button button26;

		private TextBox textBox13;

		private Label label16;

		private GroupBox groupBox3;

		private TextBox textBox10;

		private Label label13;

		private Button button25;

		private TextBox textBox9;

		private Label label12;

		private TextBox textBox6;

		private Label label11;

		private Label label22;

		private Label label21;

		private ComboBox comboBox1;

		private Label label1;

		private TextBox textBox17;

		private Label label3;

		private TextBox textBox16;

		private Label label25;

		private TextBox textBox2;

		private Label label26;

		private Label label27;

		private UserControlCurve userControlCurve1;

		private UserControlHead userControlHead1;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private ComboBox comboBox3;

		private TextBox textBox3;

		private Label label2;

		private Button button3;

		private Button button4;

		private CheckBox checkBox1;

		public FormKeyenceNanoSerial()
		{
			InitializeComponent();
			keyenceNanoSerial = new KeyenceNanoSerial();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			comboBox1.SelectedIndex = 2;
			comboBox3.DataSource = SerialPort.GetPortNames();
			try
			{
				comboBox3.SelectedIndex = 0;
			}
			catch
			{
				comboBox3.Text = "COM3";
			}
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "Keyence Read PLC Demo";
				label1.Text = "parity:";
				label3.Text = "Stop bits";
				label27.Text = "Com:";
				label26.Text = "BaudRate";
				label25.Text = "Data bits";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
				label11.Text = "Address:";
				label12.Text = "length:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				label16.Text = "Message:";
				label14.Text = "Results:";
				button26.Text = "Read";
				label2.Text = "Station:";
				button4.Text = "Annotation";
				groupBox3.Text = "Bulk Read test";
				groupBox4.Text = "Message reading test, hex string needs to be filled in";
				comboBox1.DataSource = new string[3]
				{
					"None",
					"Odd",
					"Even"
				};
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int baudRate;
			int dataBits;
			int stopBits;
			byte result;
			if (!int.TryParse(textBox2.Text, out baudRate))
			{
				MessageBox.Show(DemoUtils.BaudRateInputWrong);
			}
			else if (!int.TryParse(textBox16.Text, out dataBits))
			{
				MessageBox.Show(DemoUtils.DataBitsInputWrong);
			}
			else if (!int.TryParse(textBox17.Text, out stopBits))
			{
				MessageBox.Show(DemoUtils.StopBitInputWrong);
			}
			else if (!byte.TryParse(textBox3.Text, out result))
			{
				MessageBox.Show("Station int wrong, it needs 0 - 255");
			}
			else
			{
				KeyenceNanoSerial obj = keyenceNanoSerial;
				if (obj != null)
				{
					obj.Close();
				}
				keyenceNanoSerial = new KeyenceNanoSerial();
				keyenceNanoSerial.UseStation = checkBox1.Checked;
				keyenceNanoSerial.Station = result;
				keyenceNanoSerial.LogNet = base.LogNet;
				try
				{
					keyenceNanoSerial.SerialPortInni(delegate(SerialPort sp)
					{
						sp.PortName = comboBox3.Text;
						sp.BaudRate = baudRate;
						sp.DataBits = dataBits;
						sp.StopBits = ((stopBits != 0) ? ((stopBits == 1) ? StopBits.One : StopBits.Two) : StopBits.None);
						sp.Parity = ((comboBox1.SelectedIndex != 0) ? ((comboBox1.SelectedIndex == 1) ? Parity.Odd : Parity.Even) : Parity.None);
					});
					keyenceNanoSerial.Open();
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
					userControlReadWriteOp1.SetReadWriteNet(keyenceNanoSerial, "DM0");
					userControlCurve1.ReadWriteNet = keyenceNanoSerial;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			keyenceNanoSerial.Close();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			if (int.Parse(textBox9.Text) > 64)
			{
				MessageBox.Show("批量读取int32最多支持64个！");
			}
			else
			{
				try
				{
					OperateResult<int[]> operateResult = keyenceNanoSerial.ReadInt32(textBox6.Text, ushort.Parse(textBox9.Text));
					if (operateResult.IsSuccess)
					{
						string text = "";
						for (int i = 0; i < operateResult.Content.Length; i++)
						{
							text = text + operateResult.Content[i].ToString() + ",";
						}
						textBox10.Text = "Result：" + text;
					}
					else
					{
						MessageBox.Show("Read Failed：" + operateResult.ToMessageShowString());
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Read Failed：" + ex.Message);
				}
			}
		}

		private void button26_Click(object sender, EventArgs e)
		{
			OperateResult<byte[]> operateResult = keyenceNanoSerial.ReadFromCoreServer(SoftBasic.HexStringToBytes(textBox13.Text));
			if (operateResult.IsSuccess)
			{
				textBox11.Text = "Result：" + SoftBasic.ByteToHexString(operateResult.Content);
			}
			else
			{
				MessageBox.Show("Read Failed：" + operateResult.ToMessageShowString());
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OperateResult<KeyencePLCS> operateResult = keyenceNanoSerial.ReadPlcType();
			if (operateResult.IsSuccess)
			{
				textBox10.Text = operateResult.Content.ToString();
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = keyenceNanoSerial.ReadAddressAnnotation(textBox6.Text);
			if (operateResult.IsSuccess)
			{
				textBox10.Text = operateResult.Content;
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlCom, comboBox3.Text);
			element.SetAttributeValue(DemoDeviceList.XmlBaudRate, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlDataBits, textBox16.Text);
			element.SetAttributeValue(DemoDeviceList.XmlStopBit, textBox17.Text);
			element.SetAttributeValue(DemoDeviceList.XmlParity, comboBox1.SelectedIndex);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			comboBox3.Text = element.Attribute(DemoDeviceList.XmlCom).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlBaudRate).Value;
			textBox16.Text = element.Attribute(DemoDeviceList.XmlDataBits).Value;
			textBox17.Text = element.Attribute(DemoDeviceList.XmlStopBit).Value;
			comboBox1.SelectedIndex = int.Parse(element.Attribute(DemoDeviceList.XmlParity).Value);
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
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
			checkBox1 = new System.Windows.Forms.CheckBox();
			textBox3 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			comboBox3 = new System.Windows.Forms.ComboBox();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label1 = new System.Windows.Forms.Label();
			textBox17 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox16 = new System.Windows.Forms.TextBox();
			label25 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			label26 = new System.Windows.Forms.Label();
			label27 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			userControlCurve1 = new HslCommunicationDemo.DemoControl.UserControlCurve();
			groupBox4 = new System.Windows.Forms.GroupBox();
			textBox11 = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			button26 = new System.Windows.Forms.Button();
			textBox13 = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			textBox10 = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			button25 = new System.Windows.Forms.Button();
			textBox9 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox4.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(checkBox1);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(comboBox3);
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(textBox17);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox16);
			panel1.Controls.Add(label25);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label26);
			panel1.Controls.Add(label27);
			panel1.Controls.Add(label22);
			panel1.Controls.Add(label21);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 64);
			panel1.TabIndex = 0;
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(305, 39);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(99, 21);
			checkBox1.TabIndex = 42;
			checkBox1.Text = "Use Station?";
			checkBox1.UseVisualStyleBackColor = true;
			textBox3.Location = new System.Drawing.Point(479, 37);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(65, 23);
			textBox3.TabIndex = 41;
			textBox3.Text = "0";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(411, 40);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 17);
			label2.TabIndex = 40;
			label2.Text = "站号：";
			comboBox3.FormattingEnabled = true;
			comboBox3.Location = new System.Drawing.Point(61, 7);
			comboBox3.Name = "comboBox3";
			comboBox3.Size = new System.Drawing.Size(67, 25);
			comboBox3.TabIndex = 39;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[3]
			{
				"无",
				"奇",
				"偶"
			});
			comboBox1.Location = new System.Drawing.Point(483, 8);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(64, 25);
			comboBox1.TabIndex = 25;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(430, 11);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(44, 17);
			label1.TabIndex = 24;
			label1.Text = "奇偶：";
			textBox17.Location = new System.Drawing.Point(399, 8);
			textBox17.Name = "textBox17";
			textBox17.Size = new System.Drawing.Size(23, 23);
			textBox17.TabIndex = 23;
			textBox17.Text = "1";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(337, 11);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 22;
			label3.Text = "停止位：";
			textBox16.Location = new System.Drawing.Point(305, 8);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(24, 23);
			textBox16.TabIndex = 21;
			textBox16.Text = "8";
			label25.AutoSize = true;
			label25.Location = new System.Drawing.Point(241, 11);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(56, 17);
			label25.TabIndex = 20;
			label25.Text = "数据位：";
			textBox2.Location = new System.Drawing.Point(191, 8);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(47, 23);
			textBox2.TabIndex = 19;
			textBox2.Text = "9600";
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(134, 11);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(56, 17);
			label26.TabIndex = 18;
			label26.Text = "波特率：";
			label27.AutoSize = true;
			label27.Location = new System.Drawing.Point(8, 11);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(59, 17);
			label27.TabIndex = 16;
			label27.Text = "Com口：";
			label22.Location = new System.Drawing.Point(817, 1);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(156, 45);
			label22.TabIndex = 7;
			label22.Text = "MR100 DM100.";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(752, 1);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(68, 17);
			label21.TabIndex = 6;
			label21.Text = "地址示例：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(659, 5);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭串口";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(559, 5);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "打开串口";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteOp1);
			panel2.Controls.Add(userControlCurve1);
			panel2.Controls.Add(groupBox4);
			panel2.Controls.Add(groupBox3);
			panel2.Location = new System.Drawing.Point(3, 103);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 537);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Location = new System.Drawing.Point(4, 3);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(988, 240);
			userControlReadWriteOp1.TabIndex = 5;
			userControlCurve1.AddressExample = "D100";
			userControlCurve1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			userControlCurve1.Location = new System.Drawing.Point(572, 243);
			userControlCurve1.Name = "userControlCurve1";
			userControlCurve1.ReadWriteNet = null;
			userControlCurve1.Size = new System.Drawing.Size(420, 289);
			userControlCurve1.TabIndex = 4;
			groupBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox4.Controls.Add(textBox11);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(button26);
			groupBox4.Controls.Add(textBox13);
			groupBox4.Controls.Add(label16);
			groupBox4.Location = new System.Drawing.Point(4, 403);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(562, 126);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "报文读取测试，此处需要填入完整的16进制报文字符串";
			textBox11.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox11.Location = new System.Drawing.Point(63, 60);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox11.Size = new System.Drawing.Size(493, 60);
			textBox11.TabIndex = 10;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(9, 62);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 9;
			label14.Text = "结果：";
			button26.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button26.Location = new System.Drawing.Point(475, 24);
			button26.Name = "button26";
			button26.Size = new System.Drawing.Size(82, 28);
			button26.TabIndex = 8;
			button26.Text = "报文读取";
			button26.UseVisualStyleBackColor = true;
			button26.Click += new System.EventHandler(button26_Click);
			textBox13.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox13.Location = new System.Drawing.Point(63, 27);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(407, 23);
			textBox13.TabIndex = 5;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(9, 30);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(44, 17);
			label16.TabIndex = 4;
			label16.Text = "报文：";
			groupBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox3.Controls.Add(button4);
			groupBox3.Controls.Add(button3);
			groupBox3.Controls.Add(textBox10);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(button25);
			groupBox3.Controls.Add(textBox9);
			groupBox3.Controls.Add(label12);
			groupBox3.Controls.Add(textBox6);
			groupBox3.Controls.Add(label11);
			groupBox3.Location = new System.Drawing.Point(4, 243);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(562, 154);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试";
			button4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button4.Location = new System.Drawing.Point(410, 24);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(72, 28);
			button4.TabIndex = 12;
			button4.Text = "注释";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button3.Location = new System.Drawing.Point(332, 24);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(72, 28);
			button3.TabIndex = 11;
			button3.Text = "plc-type";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox10.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox10.Location = new System.Drawing.Point(63, 60);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(493, 88);
			textBox10.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 62);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "结果：";
			button25.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button25.Location = new System.Drawing.Point(489, 24);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(67, 28);
			button25.TabIndex = 8;
			button25.Text = "批量读取";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			textBox9.Location = new System.Drawing.Point(225, 27);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(60, 23);
			textBox9.TabIndex = 7;
			textBox9.Text = "10";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(171, 30);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(44, 17);
			label12.TabIndex = 6;
			label12.Text = "长度：";
			textBox6.Location = new System.Drawing.Point(63, 27);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(102, 23);
			textBox6.TabIndex = 5;
			textBox6.Text = "D100";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(9, 30);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 4;
			label11.Text = "地址：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "KV 编程口 上位链路协议";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.SupportListVisiable = true;
			userControlHead1.TabIndex = 2;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormKeyenceNanoSerial";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "基恩士PLC串口访问Demo";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			ResumeLayout(false);
		}
	}
}
