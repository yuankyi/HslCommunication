using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Instrument.DLT;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormDLT698 : HslFormContent
	{
		private DLT698 dLT698 = null;

		private IContainer components = null;

		private Panel panel1;

		private Label label1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

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

		private TextBox textBox_station;

		private Label label_address;

		private ComboBox comboBox1;

		private Label label24;

		private TextBox textBox17;

		private Label label23;

		private TextBox textBox16;

		private Label label22;

		private ComboBox comboBox3;

		private UserControlHead userControlHead1;

		private CheckBox checkBox5;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private GroupBox groupBox5;

		private TextBox textBox12;

		private Button button3;

		private Button button4;

		private Button button5;

		private TextBox textBox1;

		private Label label2;

		private Button button6;

		private TextBox textBox_op_code;

		private Label label_op_code;

		private TextBox textBox_password;

		private Label label_password;

		private Button button7;

		private Button button8;

		private Label label4;

		private CheckBox checkBox_enable_Fe;

		public FormDLT698()
		{
			InitializeComponent();
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
				Text = "DLT698 Read Demo";
				label1.Text = "Com:";
				label3.Text = "baudRate:";
				label22.Text = "DataBit";
				label23.Text = "StopBit";
				label24.Text = "parity";
				label_address.Text = "station";
				label_password.Text = "Pwd:";
				label_op_code.Text = "Op Code";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				button3.Text = "Active";
				label11.Text = "Address:";
				label12.Text = "length:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				label16.Text = "Message:";
				label14.Text = "Results:";
				button26.Text = "Read";
				groupBox3.Text = "Bulk Read test";
				groupBox4.Text = "Message reading test, hex string needs to be filled in";
				groupBox5.Text = "Special function test";
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
			else
			{
				DLT698 obj = dLT698;
				if (obj != null)
				{
					obj.Close();
				}
				dLT698 = new DLT698(textBox_station.Text);
				dLT698.LogNet = base.LogNet;
				dLT698.EnableCodeFE = checkBox_enable_Fe.Checked;
				try
				{
					dLT698.SerialPortInni(delegate(SerialPort sp)
					{
						sp.PortName = comboBox3.Text;
						sp.BaudRate = baudRate;
						sp.DataBits = dataBits;
						sp.StopBits = ((stopBits != 0) ? ((stopBits == 1) ? StopBits.One : StopBits.Two) : StopBits.None);
						sp.Parity = ((comboBox1.SelectedIndex != 0) ? ((comboBox1.SelectedIndex == 1) ? Parity.Odd : Parity.Even) : Parity.None);
					});
					dLT698.RtsEnable = checkBox5.Checked;
					dLT698.Open();
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
					userControlReadWriteOp1.SetReadWriteNet(dLT698, "20-00-02-00");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			dLT698.Close();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			try
			{
				OperateResult<byte[]> operateResult = dLT698.Read(textBox6.Text, ushort.Parse(textBox9.Text));
				if (operateResult.IsSuccess)
				{
					textBox10.Text = "Result：" + SoftBasic.ByteToHexString(operateResult.Content, ' ');
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

		private void button26_Click(object sender, EventArgs e)
		{
			OperateResult<byte[]> operateResult = dLT698.ReadByApdu(SoftBasic.HexStringToBytes(textBox13.Text));
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
			OperateResult operateResult = dLT698.ActiveDeveice();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Send Active Code Success");
			}
			else
			{
				MessageBox.Show("Active Code failed:" + operateResult.Message);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = dLT698.ReadAddress();
			if (operateResult.IsSuccess)
			{
				textBox_station.Text = operateResult.Content;
				textBox12.Text = string.Format("[{0:HH:mm:ss}] Address:{1}", DateTime.Now, operateResult.Content);
			}
			else
			{
				MessageBox.Show("Read failed: " + operateResult.Message);
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
		}

		private void button5_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = dLT698.WriteAddress(textBox1.Text);
			if (operateResult.IsSuccess)
			{
				textBox12.Text = string.Format("[{0:HH:mm:ss}] Write Success", DateTime.Now);
			}
			else
			{
				MessageBox.Show("Read failed: " + operateResult.Message);
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			OperateResult<string[]> operateResult = dLT698.ReadStringArray(textBox1.Text);
			if (operateResult.IsSuccess)
			{
				textBox12.Text = string.Format("[{0:HH:mm:ss}] Read Result: {1}", DateTime.Now, Environment.NewLine);
				if (operateResult.Content != null)
				{
					string[] content = operateResult.Content;
					foreach (string text in content)
					{
						if (!string.IsNullOrEmpty(text))
						{
							textBox12.AppendText(text);
							textBox12.AppendText(Environment.NewLine);
						}
					}
				}
			}
			else
			{
				MessageBox.Show("Read failed: " + operateResult.Message);
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlCom, comboBox3.Text);
			element.SetAttributeValue(DemoDeviceList.XmlBaudRate, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlDataBits, textBox16.Text);
			element.SetAttributeValue(DemoDeviceList.XmlStopBit, textBox17.Text);
			element.SetAttributeValue(DemoDeviceList.XmlParity, comboBox1.SelectedIndex);
			element.SetAttributeValue(DemoDeviceList.XmlStation, textBox_station.Text);
			element.SetAttributeValue(DemoDeviceList.XmlRtsEnable, checkBox5.Checked);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			comboBox3.Text = element.Attribute(DemoDeviceList.XmlCom).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlBaudRate).Value;
			textBox16.Text = element.Attribute(DemoDeviceList.XmlDataBits).Value;
			textBox17.Text = element.Attribute(DemoDeviceList.XmlStopBit).Value;
			comboBox1.SelectedIndex = int.Parse(element.Attribute(DemoDeviceList.XmlParity).Value);
			textBox_station.Text = element.Attribute(DemoDeviceList.XmlStation).Value;
			checkBox5.Checked = bool.Parse(element.Attribute(DemoDeviceList.XmlRtsEnable).Value);
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
		}

		private void button8_Click(object sender, EventArgs e)
		{
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
			label4 = new System.Windows.Forms.Label();
			textBox_op_code = new System.Windows.Forms.TextBox();
			label_op_code = new System.Windows.Forms.Label();
			textBox_password = new System.Windows.Forms.TextBox();
			label_password = new System.Windows.Forms.Label();
			checkBox5 = new System.Windows.Forms.CheckBox();
			comboBox3 = new System.Windows.Forms.ComboBox();
			comboBox1 = new System.Windows.Forms.ComboBox();
			textBox17 = new System.Windows.Forms.TextBox();
			label23 = new System.Windows.Forms.Label();
			textBox16 = new System.Windows.Forms.TextBox();
			label22 = new System.Windows.Forms.Label();
			textBox_station = new System.Windows.Forms.TextBox();
			label_address = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox5 = new System.Windows.Forms.GroupBox();
			button7 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			textBox1 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			textBox12 = new System.Windows.Forms.TextBox();
			groupBox4 = new System.Windows.Forms.GroupBox();
			textBox11 = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			button26 = new System.Windows.Forms.Button();
			textBox13 = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			button8 = new System.Windows.Forms.Button();
			textBox10 = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			button25 = new System.Windows.Forms.Button();
			textBox9 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			checkBox_enable_Fe = new System.Windows.Forms.CheckBox();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox5.SuspendLayout();
			groupBox4.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(label4);
			panel1.Controls.Add(checkBox_enable_Fe);
			panel1.Controls.Add(textBox_op_code);
			panel1.Controls.Add(label_op_code);
			panel1.Controls.Add(textBox_password);
			panel1.Controls.Add(label_password);
			panel1.Controls.Add(checkBox5);
			panel1.Controls.Add(comboBox3);
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(textBox17);
			panel1.Controls.Add(label23);
			panel1.Controls.Add(textBox16);
			panel1.Controls.Add(label22);
			panel1.Controls.Add(textBox_station);
			panel1.Controls.Add(label_address);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(label24);
			panel1.Location = new System.Drawing.Point(4, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 59);
			panel1.TabIndex = 0;
			label4.AutoSize = true;
			label4.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			label4.Location = new System.Drawing.Point(843, 5);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(146, 17);
			label4.TabIndex = 35;
			label4.Text = "Use double read write !";
			textBox_op_code.Location = new System.Drawing.Point(333, 31);
			textBox_op_code.Name = "textBox_op_code";
			textBox_op_code.ReadOnly = true;
			textBox_op_code.Size = new System.Drawing.Size(159, 23);
			textBox_op_code.TabIndex = 34;
			label_op_code.AutoSize = true;
			label_op_code.Location = new System.Drawing.Point(247, 34);
			label_op_code.Name = "label_op_code";
			label_op_code.Size = new System.Drawing.Size(80, 17);
			label_op_code.TabIndex = 33;
			label_op_code.Text = "操作者代码：";
			textBox_password.Location = new System.Drawing.Point(61, 31);
			textBox_password.Name = "textBox_password";
			textBox_password.ReadOnly = true;
			textBox_password.Size = new System.Drawing.Size(180, 23);
			textBox_password.TabIndex = 32;
			label_password.AutoSize = true;
			label_password.Location = new System.Drawing.Point(11, 34);
			label_password.Name = "label_password";
			label_password.Size = new System.Drawing.Size(44, 17);
			label_password.TabIndex = 31;
			label_password.Text = "密码：";
			checkBox5.AutoSize = true;
			checkBox5.Location = new System.Drawing.Point(624, 5);
			checkBox5.Name = "checkBox5";
			checkBox5.Size = new System.Drawing.Size(84, 21);
			checkBox5.TabIndex = 30;
			checkBox5.Text = "RtsEnable";
			checkBox5.UseVisualStyleBackColor = true;
			comboBox3.FormattingEnabled = true;
			comboBox3.Location = new System.Drawing.Point(61, 3);
			comboBox3.Name = "comboBox3";
			comboBox3.Size = new System.Drawing.Size(85, 25);
			comboBox3.TabIndex = 29;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[3]
			{
				"无",
				"奇",
				"偶"
			});
			comboBox1.Location = new System.Drawing.Point(553, 3);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(62, 25);
			comboBox1.TabIndex = 15;
			textBox17.Location = new System.Drawing.Point(457, 3);
			textBox17.Name = "textBox17";
			textBox17.Size = new System.Drawing.Size(35, 23);
			textBox17.TabIndex = 13;
			textBox17.Text = "1";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(387, 6);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(56, 17);
			label23.TabIndex = 12;
			label23.Text = "停止位：";
			textBox16.Location = new System.Drawing.Point(342, 3);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(33, 23);
			textBox16.TabIndex = 11;
			textBox16.Text = "8";
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(279, 6);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(56, 17);
			label22.TabIndex = 10;
			label22.Text = "数据位：";
			textBox_station.Location = new System.Drawing.Point(554, 30);
			textBox_station.Name = "textBox_station";
			textBox_station.Size = new System.Drawing.Size(180, 23);
			textBox_station.TabIndex = 7;
			textBox_station.Text = "1";
			label_address.AutoSize = true;
			label_address.Location = new System.Drawing.Point(506, 33);
			label_address.Name = "label_address";
			label_address.Size = new System.Drawing.Size(44, 17);
			label_address.TabIndex = 6;
			label_address.Text = "站号：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(834, 28);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭串口";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(740, 28);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "打开串口";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(212, 3);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(56, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "9600";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(152, 6);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "波特率：";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 6);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(59, 17);
			label1.TabIndex = 0;
			label1.Text = "Com口：";
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(505, 6);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(44, 17);
			label24.TabIndex = 14;
			label24.Text = "奇偶：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteOp1);
			panel2.Controls.Add(groupBox5);
			panel2.Controls.Add(groupBox4);
			panel2.Controls.Add(groupBox3);
			panel2.Location = new System.Drawing.Point(4, 98);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(1000, 545);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Location = new System.Drawing.Point(2, 2);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(993, 240);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox5.Controls.Add(button7);
			groupBox5.Controls.Add(button6);
			groupBox5.Controls.Add(button5);
			groupBox5.Controls.Add(textBox1);
			groupBox5.Controls.Add(label2);
			groupBox5.Controls.Add(button4);
			groupBox5.Controls.Add(button3);
			groupBox5.Controls.Add(textBox12);
			groupBox5.Location = new System.Drawing.Point(575, 244);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(420, 296);
			groupBox5.TabIndex = 4;
			groupBox5.TabStop = false;
			groupBox5.Text = "特殊功能测试";
			button7.Location = new System.Drawing.Point(259, 57);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(151, 28);
			button7.TabIndex = 18;
			button7.Text = "读取原始字符串";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			button6.Location = new System.Drawing.Point(217, 24);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(81, 28);
			button6.TabIndex = 17;
			button6.Text = "广播时间";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button5.Location = new System.Drawing.Point(304, 24);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(106, 28);
			button5.TabIndex = 16;
			button5.Text = "写入通信地址";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			textBox1.Location = new System.Drawing.Point(65, 60);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(188, 23);
			textBox1.TabIndex = 15;
			textBox1.Text = "20-01-02-00";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(11, 63);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 17);
			label2.TabIndex = 14;
			label2.Text = "地址：";
			button4.Location = new System.Drawing.Point(116, 24);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(95, 28);
			button4.TabIndex = 13;
			button4.Text = "读取通信地址";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button3.Location = new System.Drawing.Point(14, 24);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(96, 28);
			button3.TabIndex = 12;
			button3.Text = "唤醒接收";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox12.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox12.Location = new System.Drawing.Point(14, 90);
			textBox12.Multiline = true;
			textBox12.Name = "textBox12";
			textBox12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox12.Size = new System.Drawing.Size(396, 201);
			textBox12.TabIndex = 11;
			groupBox4.Controls.Add(textBox11);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(button26);
			groupBox4.Controls.Add(textBox13);
			groupBox4.Controls.Add(label16);
			groupBox4.Location = new System.Drawing.Point(2, 403);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(567, 137);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "APDU读取测试，此处需要填入16进制报文字符串";
			textBox11.Location = new System.Drawing.Point(63, 60);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox11.Size = new System.Drawing.Size(498, 71);
			textBox11.TabIndex = 10;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(9, 62);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 9;
			label14.Text = "结果：";
			button26.Location = new System.Drawing.Point(479, 24);
			button26.Name = "button26";
			button26.Size = new System.Drawing.Size(82, 28);
			button26.TabIndex = 8;
			button26.Text = "报文读取";
			button26.UseVisualStyleBackColor = true;
			button26.Click += new System.EventHandler(button26_Click);
			textBox13.Location = new System.Drawing.Point(63, 27);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(410, 23);
			textBox13.TabIndex = 5;
			textBox13.Text = "05 01 01 20 10 02 00 00";
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(9, 30);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(44, 17);
			label16.TabIndex = 4;
			label16.Text = "报文：";
			groupBox3.Controls.Add(button8);
			groupBox3.Controls.Add(textBox10);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(button25);
			groupBox3.Controls.Add(textBox9);
			groupBox3.Controls.Add(label12);
			groupBox3.Controls.Add(textBox6);
			groupBox3.Controls.Add(label11);
			groupBox3.Location = new System.Drawing.Point(2, 244);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(567, 154);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试";
			button8.Location = new System.Drawing.Point(388, 21);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(82, 28);
			button8.TabIndex = 11;
			button8.Text = "建立连接";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			textBox10.Location = new System.Drawing.Point(63, 55);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(498, 93);
			textBox10.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 58);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "结果：";
			button25.Location = new System.Drawing.Point(479, 21);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(82, 28);
			button25.TabIndex = 8;
			button25.Text = "批量读取";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			textBox9.Location = new System.Drawing.Point(239, 24);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(102, 23);
			textBox9.TabIndex = 7;
			textBox9.Text = "1";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(185, 27);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(44, 17);
			label12.TabIndex = 6;
			label12.Text = "长度：";
			textBox6.Location = new System.Drawing.Point(63, 24);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(102, 23);
			textBox6.TabIndex = 5;
			textBox6.Text = "20-00-02-00";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(9, 27);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 4;
			label11.Text = "地址：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/8974215.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "DLT 698";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 2;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			checkBox_enable_Fe.AutoSize = true;
			checkBox_enable_Fe.Location = new System.Drawing.Point(713, 5);
			checkBox_enable_Fe.Name = "checkBox_enable_Fe";
			checkBox_enable_Fe.Size = new System.Drawing.Size(130, 21);
			checkBox_enable_Fe.TabIndex = 36;
			checkBox_enable_Fe.Text = "FE FE FE FE head?";
			checkBox_enable_Fe.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormDLT698";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "DLT698访问Demo";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			ResumeLayout(false);
		}
	}
}
