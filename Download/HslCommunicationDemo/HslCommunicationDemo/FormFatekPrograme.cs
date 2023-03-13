using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.LogNet;
using HslCommunication.Profinet.FATEK;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormFatekPrograme : HslFormContent
	{
		private FatekProgram fatekProgram = null;

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

		private ComboBox comboBox1;

		private Label label1;

		private TextBox textBox17;

		private Label label3;

		private TextBox textBox16;

		private Label label25;

		private TextBox textBox2;

		private Label label26;

		private Label label27;

		private TextBox textBox15;

		private Label label21;

		private UserControlHead userControlHead1;

		private GroupBox groupBox5;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private ComboBox comboBox3;

		private Button button_stop;

		private Button button_run;

		private Label label_bit1_false;

		private Label label_bit1_true;

		private Label label_bit0_false;

		private Label label_bit0_true;

		private Button button_read_status;

		private Label label_bit2_false;

		private Label label_bit2_true;

		private Label label_bit4_false;

		private Label label_bit4_true;

		private Label label_bit3_false;

		private Label label_bit3_true;

		private Label label_bit6_false;

		private Label label_bit6_true;

		private Label label_bit5_false;

		private Label label_bit5_true;

		public FormFatekPrograme()
		{
			InitializeComponent();
			fatekProgram = new FatekProgram();
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
				Text = "FATEK Read PLC Demo";
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
				FatekProgram obj = fatekProgram;
				if (obj != null)
				{
					obj.Close();
				}
				fatekProgram = new FatekProgram();
				fatekProgram.LogNet = base.LogNet;
				try
				{
					fatekProgram.SerialPortInni(delegate(SerialPort sp)
					{
						sp.PortName = comboBox3.Text;
						sp.BaudRate = baudRate;
						sp.DataBits = dataBits;
						sp.StopBits = ((stopBits != 0) ? ((stopBits == 1) ? StopBits.One : StopBits.Two) : StopBits.None);
						sp.Parity = ((comboBox1.SelectedIndex != 0) ? ((comboBox1.SelectedIndex == 1) ? Parity.Odd : Parity.Even) : Parity.None);
					});
					fatekProgram.Station = byte.Parse(textBox15.Text);
					fatekProgram.Open();
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
					userControlReadWriteOp1.SetReadWriteNet(fatekProgram, "D100");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			fatekProgram.Close();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			DemoUtils.BulkReadRenderResult(fatekProgram, textBox6, textBox9, textBox10);
		}

		private void button26_Click(object sender, EventArgs e)
		{
			OperateResult<byte[]> operateResult = fatekProgram.ReadFromCoreServer(SoftBasic.HexStringToBytes(textBox13.Text));
			if (operateResult.IsSuccess)
			{
				textBox11.Text = "Result：" + SoftBasic.ByteToHexString(operateResult.Content);
			}
			else
			{
				MessageBox.Show("Read Failed：" + operateResult.ToMessageShowString());
			}
		}

		private void test1()
		{
			OperateResult<bool[]> operateResult = fatekProgram.ReadBool("M100", 10);
			if (operateResult.IsSuccess)
			{
				bool flag = operateResult.Content[0];
				bool flag2 = operateResult.Content[9];
			}
		}

		private void test3()
		{
			short content = fatekProgram.ReadInt16("D100").Content;
			ushort content2 = fatekProgram.ReadUInt16("D100").Content;
			int content3 = fatekProgram.ReadInt32("D100").Content;
			uint content4 = fatekProgram.ReadUInt32("D100").Content;
			long content5 = fatekProgram.ReadInt64("D100").Content;
			ulong content6 = fatekProgram.ReadUInt64("D100").Content;
			float content7 = fatekProgram.ReadFloat("D100").Content;
			double content8 = fatekProgram.ReadDouble("D100").Content;
			string content9 = fatekProgram.ReadString("D100", 10).Content;
		}

		private void test4()
		{
			fatekProgram.Write("D100", (short)5);
			fatekProgram.Write("D100", (ushort)5);
			fatekProgram.Write("D100", 5);
			fatekProgram.Write("D100", 5u);
			fatekProgram.Write("D100", 5L);
			fatekProgram.Write("D100", 5uL);
			fatekProgram.Write("D100", 5f);
			fatekProgram.Write("D100", 5.0);
			fatekProgram.Write("D100", "12345678");
		}

		private void test5()
		{
			OperateResult<byte[]> operateResult = fatekProgram.Read("D100", 10);
			if (operateResult.IsSuccess)
			{
				int num = fatekProgram.ByteTransform.TransInt32(operateResult.Content, 0);
				float num2 = fatekProgram.ByteTransform.TransSingle(operateResult.Content, 4);
				short num3 = fatekProgram.ByteTransform.TransInt16(operateResult.Content, 8);
				string @string = Encoding.ASCII.GetString(operateResult.Content, 10, 10);
			}
		}

		private void test6()
		{
			OperateResult<UserType> operateResult = fatekProgram.ReadCustomer<UserType>("D100");
			if (operateResult.IsSuccess)
			{
				UserType content = operateResult.Content;
			}
			fatekProgram.WriteCustomer("D100", new UserType());
			fatekProgram.LogNet = new LogNetSingle(Application.StartupPath + "\\Logs.txt");
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlCom, comboBox3.Text);
			element.SetAttributeValue(DemoDeviceList.XmlBaudRate, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlDataBits, textBox16.Text);
			element.SetAttributeValue(DemoDeviceList.XmlStopBit, textBox17.Text);
			element.SetAttributeValue(DemoDeviceList.XmlParity, comboBox1.SelectedIndex);
			element.SetAttributeValue(DemoDeviceList.XmlStation, textBox15.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			comboBox3.Text = element.Attribute(DemoDeviceList.XmlCom).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlBaudRate).Value;
			textBox16.Text = element.Attribute(DemoDeviceList.XmlDataBits).Value;
			textBox17.Text = element.Attribute(DemoDeviceList.XmlStopBit).Value;
			comboBox1.SelectedIndex = int.Parse(element.Attribute(DemoDeviceList.XmlParity).Value);
			textBox15.Text = element.Attribute(DemoDeviceList.XmlStation).Value;
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
		}

		private void button_run_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = fatekProgram.Run();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Run Success!");
			}
			else
			{
				MessageBox.Show("Run failed: " + operateResult.Message);
			}
		}

		private void button_stop_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = fatekProgram.Stop();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Stop Success!");
			}
			else
			{
				MessageBox.Show("Stop failed: " + operateResult.Message);
			}
		}

		public static void SetColorFromStatus(bool status, Label labelTrue, Label labelFalse)
		{
			if (status)
			{
				labelTrue.BackColor = Color.Tomato;
				labelFalse.BackColor = Color.Silver;
			}
			else
			{
				labelFalse.BackColor = Color.Tomato;
				labelTrue.BackColor = Color.Silver;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OperateResult<bool[]> operateResult = fatekProgram.ReadStatus();
			if (operateResult.IsSuccess)
			{
				SetColorFromStatus(operateResult.Content[0], label_bit0_true, label_bit0_false);
				SetColorFromStatus(operateResult.Content[1], label_bit1_true, label_bit1_false);
				SetColorFromStatus(operateResult.Content[2], label_bit2_true, label_bit2_false);
				SetColorFromStatus(operateResult.Content[3], label_bit3_true, label_bit3_false);
				SetColorFromStatus(operateResult.Content[4], label_bit4_true, label_bit4_false);
				SetColorFromStatus(operateResult.Content[5], label_bit5_true, label_bit5_false);
				SetColorFromStatus(operateResult.Content[6], label_bit6_true, label_bit6_false);
			}
			else
			{
				MessageBox.Show("Read failed: " + operateResult.Message);
			}
		}

		private void label_bit6_true_Click(object sender, EventArgs e)
		{
		}

		private void label_bit5_false_Click(object sender, EventArgs e)
		{
		}

		private void label_bit5_true_Click(object sender, EventArgs e)
		{
		}

		private void label_bit4_false_Click(object sender, EventArgs e)
		{
		}

		private void label_bit4_true_Click(object sender, EventArgs e)
		{
		}

		private void label_bit3_false_Click(object sender, EventArgs e)
		{
		}

		private void label_bit3_true_Click(object sender, EventArgs e)
		{
		}

		private void label_bit2_false_Click(object sender, EventArgs e)
		{
		}

		private void label_bit2_true_Click(object sender, EventArgs e)
		{
		}

		private void label_bit1_false_Click(object sender, EventArgs e)
		{
		}

		private void label_bit1_true_Click(object sender, EventArgs e)
		{
		}

		private void label_bit0_false_Click(object sender, EventArgs e)
		{
		}

		private void label_bit0_true_Click(object sender, EventArgs e)
		{
		}

		private void label_bit6_false_Click(object sender, EventArgs e)
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
			comboBox3 = new System.Windows.Forms.ComboBox();
			textBox15 = new System.Windows.Forms.TextBox();
			label21 = new System.Windows.Forms.Label();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label1 = new System.Windows.Forms.Label();
			textBox17 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox16 = new System.Windows.Forms.TextBox();
			label25 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			label26 = new System.Windows.Forms.Label();
			label27 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox5 = new System.Windows.Forms.GroupBox();
			label_bit6_false = new System.Windows.Forms.Label();
			label_bit6_true = new System.Windows.Forms.Label();
			label_bit5_false = new System.Windows.Forms.Label();
			label_bit5_true = new System.Windows.Forms.Label();
			label_bit4_false = new System.Windows.Forms.Label();
			label_bit4_true = new System.Windows.Forms.Label();
			label_bit3_false = new System.Windows.Forms.Label();
			label_bit3_true = new System.Windows.Forms.Label();
			label_bit2_false = new System.Windows.Forms.Label();
			label_bit2_true = new System.Windows.Forms.Label();
			label_bit1_false = new System.Windows.Forms.Label();
			label_bit1_true = new System.Windows.Forms.Label();
			label_bit0_false = new System.Windows.Forms.Label();
			label_bit0_true = new System.Windows.Forms.Label();
			button_read_status = new System.Windows.Forms.Button();
			button_stop = new System.Windows.Forms.Button();
			button_run = new System.Windows.Forms.Button();
			groupBox4 = new System.Windows.Forms.GroupBox();
			textBox11 = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			button26 = new System.Windows.Forms.Button();
			textBox13 = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
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
			groupBox5.SuspendLayout();
			groupBox4.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(comboBox3);
			panel1.Controls.Add(textBox15);
			panel1.Controls.Add(label21);
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(textBox17);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox16);
			panel1.Controls.Add(label25);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label26);
			panel1.Controls.Add(label27);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 46);
			panel1.TabIndex = 0;
			comboBox3.FormattingEnabled = true;
			comboBox3.Location = new System.Drawing.Point(63, 9);
			comboBox3.Name = "comboBox3";
			comboBox3.Size = new System.Drawing.Size(67, 25);
			comboBox3.TabIndex = 39;
			textBox15.Location = new System.Drawing.Point(643, 9);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(39, 23);
			textBox15.TabIndex = 28;
			textBox15.Text = "1";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(592, 12);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(44, 17);
			label21.TabIndex = 27;
			label21.Text = "站号：";
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[3]
			{
				"无",
				"奇",
				"偶"
			});
			comboBox1.Location = new System.Drawing.Point(515, 9);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(58, 25);
			comboBox1.TabIndex = 25;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(463, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(44, 17);
			label1.TabIndex = 24;
			label1.Text = "奇偶：";
			textBox17.Location = new System.Drawing.Point(429, 9);
			textBox17.Name = "textBox17";
			textBox17.Size = new System.Drawing.Size(23, 23);
			textBox17.TabIndex = 23;
			textBox17.Text = "2";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(364, 12);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 22;
			label3.Text = "停止位：";
			textBox16.Location = new System.Drawing.Point(327, 9);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(24, 23);
			textBox16.TabIndex = 21;
			textBox16.Text = "7";
			label25.AutoSize = true;
			label25.Location = new System.Drawing.Point(263, 12);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(56, 17);
			label25.TabIndex = 20;
			label25.Text = "数据位：";
			textBox2.Location = new System.Drawing.Point(205, 9);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(47, 23);
			textBox2.TabIndex = 19;
			textBox2.Text = "9600";
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(138, 12);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(56, 17);
			label26.TabIndex = 18;
			label26.Text = "波特率：";
			label27.AutoSize = true;
			label27.Location = new System.Drawing.Point(8, 12);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(59, 17);
			label27.TabIndex = 16;
			label27.Text = "Com口：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(796, 6);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭串口";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(699, 6);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "打开串口";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteOp1);
			panel2.Controls.Add(groupBox5);
			panel2.Controls.Add(groupBox4);
			panel2.Controls.Add(groupBox3);
			panel2.Location = new System.Drawing.Point(3, 85);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 557);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Location = new System.Drawing.Point(3, 2);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(989, 240);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox5.Controls.Add(label_bit6_false);
			groupBox5.Controls.Add(label_bit6_true);
			groupBox5.Controls.Add(label_bit5_false);
			groupBox5.Controls.Add(label_bit5_true);
			groupBox5.Controls.Add(label_bit4_false);
			groupBox5.Controls.Add(label_bit4_true);
			groupBox5.Controls.Add(label_bit3_false);
			groupBox5.Controls.Add(label_bit3_true);
			groupBox5.Controls.Add(label_bit2_false);
			groupBox5.Controls.Add(label_bit2_true);
			groupBox5.Controls.Add(label_bit1_false);
			groupBox5.Controls.Add(label_bit1_true);
			groupBox5.Controls.Add(label_bit0_false);
			groupBox5.Controls.Add(label_bit0_true);
			groupBox5.Controls.Add(button_read_status);
			groupBox5.Controls.Add(button_stop);
			groupBox5.Controls.Add(button_run);
			groupBox5.Location = new System.Drawing.Point(572, 243);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(420, 309);
			groupBox5.TabIndex = 4;
			groupBox5.TabStop = false;
			groupBox5.Text = "特殊功能测试";
			label_bit6_false.BackColor = System.Drawing.Color.Silver;
			label_bit6_false.Location = new System.Drawing.Point(176, 268);
			label_bit6_false.Name = "label_bit6_false";
			label_bit6_false.Size = new System.Drawing.Size(150, 20);
			label_bit6_false.TabIndex = 25;
			label_bit6_false.Text = "Normal";
			label_bit6_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit6_false.Click += new System.EventHandler(label_bit6_false_Click);
			label_bit6_true.BackColor = System.Drawing.Color.Silver;
			label_bit6_true.Location = new System.Drawing.Point(6, 268);
			label_bit6_true.Name = "label_bit6_true";
			label_bit6_true.Size = new System.Drawing.Size(150, 20);
			label_bit6_true.TabIndex = 24;
			label_bit6_true.Text = "Emergency stop";
			label_bit6_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit6_true.Click += new System.EventHandler(label_bit6_true_Click);
			label_bit5_false.BackColor = System.Drawing.Color.Silver;
			label_bit5_false.Location = new System.Drawing.Point(176, 238);
			label_bit5_false.Name = "label_bit5_false";
			label_bit5_false.Size = new System.Drawing.Size(150, 20);
			label_bit5_false.TabIndex = 23;
			label_bit5_false.Text = "Not Set ID";
			label_bit5_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit5_false.Click += new System.EventHandler(label_bit5_false_Click);
			label_bit5_true.BackColor = System.Drawing.Color.Silver;
			label_bit5_true.Location = new System.Drawing.Point(6, 238);
			label_bit5_true.Name = "label_bit5_true";
			label_bit5_true.Size = new System.Drawing.Size(150, 20);
			label_bit5_true.TabIndex = 22;
			label_bit5_true.Text = "Set ID";
			label_bit5_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit5_true.Click += new System.EventHandler(label_bit5_true_Click);
			label_bit4_false.BackColor = System.Drawing.Color.Silver;
			label_bit4_false.Location = new System.Drawing.Point(176, 209);
			label_bit4_false.Name = "label_bit4_false";
			label_bit4_false.Size = new System.Drawing.Size(150, 20);
			label_bit4_false.TabIndex = 21;
			label_bit4_false.Text = "Normal";
			label_bit4_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit4_false.Click += new System.EventHandler(label_bit4_false_Click);
			label_bit4_true.BackColor = System.Drawing.Color.Silver;
			label_bit4_true.Location = new System.Drawing.Point(6, 209);
			label_bit4_true.Name = "label_bit4_true";
			label_bit4_true.Size = new System.Drawing.Size(150, 20);
			label_bit4_true.TabIndex = 20;
			label_bit4_true.Text = "WDT Timeout";
			label_bit4_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit4_true.Click += new System.EventHandler(label_bit4_true_Click);
			label_bit3_false.BackColor = System.Drawing.Color.Silver;
			label_bit3_false.Location = new System.Drawing.Point(176, 179);
			label_bit3_false.Name = "label_bit3_false";
			label_bit3_false.Size = new System.Drawing.Size(150, 20);
			label_bit3_false.TabIndex = 19;
			label_bit3_false.Text = "Not used";
			label_bit3_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit3_false.Click += new System.EventHandler(label_bit3_false_Click);
			label_bit3_true.BackColor = System.Drawing.Color.Silver;
			label_bit3_true.Location = new System.Drawing.Point(6, 179);
			label_bit3_true.Name = "label_bit3_true";
			label_bit3_true.Size = new System.Drawing.Size(150, 20);
			label_bit3_true.TabIndex = 18;
			label_bit3_true.Text = "Use ROM Pack";
			label_bit3_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit3_true.Click += new System.EventHandler(label_bit3_true_Click);
			label_bit2_false.BackColor = System.Drawing.Color.Silver;
			label_bit2_false.Location = new System.Drawing.Point(176, 151);
			label_bit2_false.Name = "label_bit2_false";
			label_bit2_false.Size = new System.Drawing.Size(150, 20);
			label_bit2_false.TabIndex = 17;
			label_bit2_false.Text = "Normal";
			label_bit2_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit2_false.Click += new System.EventHandler(label_bit2_false_Click);
			label_bit2_true.BackColor = System.Drawing.Color.Silver;
			label_bit2_true.Location = new System.Drawing.Point(6, 151);
			label_bit2_true.Name = "label_bit2_true";
			label_bit2_true.Size = new System.Drawing.Size(150, 20);
			label_bit2_true.TabIndex = 16;
			label_bit2_true.Text = "Ladder checksum error";
			label_bit2_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit2_true.Click += new System.EventHandler(label_bit2_true_Click);
			label_bit1_false.BackColor = System.Drawing.Color.Silver;
			label_bit1_false.Location = new System.Drawing.Point(176, 123);
			label_bit1_false.Name = "label_bit1_false";
			label_bit1_false.Size = new System.Drawing.Size(150, 20);
			label_bit1_false.TabIndex = 15;
			label_bit1_false.Text = "Normal";
			label_bit1_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit1_false.Click += new System.EventHandler(label_bit1_false_Click);
			label_bit1_true.BackColor = System.Drawing.Color.Silver;
			label_bit1_true.Location = new System.Drawing.Point(6, 123);
			label_bit1_true.Name = "label_bit1_true";
			label_bit1_true.Size = new System.Drawing.Size(150, 20);
			label_bit1_true.TabIndex = 14;
			label_bit1_true.Text = "BAT LOW";
			label_bit1_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit1_true.Click += new System.EventHandler(label_bit1_true_Click);
			label_bit0_false.BackColor = System.Drawing.Color.Silver;
			label_bit0_false.Location = new System.Drawing.Point(176, 96);
			label_bit0_false.Name = "label_bit0_false";
			label_bit0_false.Size = new System.Drawing.Size(150, 20);
			label_bit0_false.TabIndex = 13;
			label_bit0_false.Text = "STOP";
			label_bit0_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit0_false.Click += new System.EventHandler(label_bit0_false_Click);
			label_bit0_true.BackColor = System.Drawing.Color.Silver;
			label_bit0_true.Location = new System.Drawing.Point(6, 96);
			label_bit0_true.Name = "label_bit0_true";
			label_bit0_true.Size = new System.Drawing.Size(150, 20);
			label_bit0_true.TabIndex = 12;
			label_bit0_true.Text = "RUN";
			label_bit0_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit0_true.Click += new System.EventHandler(label_bit0_true_Click);
			button_read_status.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_read_status.Location = new System.Drawing.Point(6, 62);
			button_read_status.Name = "button_read_status";
			button_read_status.Size = new System.Drawing.Size(82, 28);
			button_read_status.TabIndex = 11;
			button_read_status.Text = "Status";
			button_read_status.UseVisualStyleBackColor = true;
			button_read_status.Click += new System.EventHandler(button3_Click);
			button_stop.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_stop.Location = new System.Drawing.Point(94, 30);
			button_stop.Name = "button_stop";
			button_stop.Size = new System.Drawing.Size(82, 28);
			button_stop.TabIndex = 10;
			button_stop.Text = "Stop";
			button_stop.UseVisualStyleBackColor = true;
			button_stop.Click += new System.EventHandler(button_stop_Click);
			button_run.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_run.Location = new System.Drawing.Point(6, 30);
			button_run.Name = "button_run";
			button_run.Size = new System.Drawing.Size(82, 28);
			button_run.TabIndex = 9;
			button_run.Text = "Run";
			button_run.UseVisualStyleBackColor = true;
			button_run.Click += new System.EventHandler(button_run_Click);
			groupBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox4.Controls.Add(textBox11);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(button26);
			groupBox4.Controls.Add(textBox13);
			groupBox4.Controls.Add(label16);
			groupBox4.Location = new System.Drawing.Point(11, 403);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(555, 149);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "报文读取测试，此处需要填入完整的16进制报文字符串";
			textBox11.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox11.Location = new System.Drawing.Point(63, 60);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox11.Size = new System.Drawing.Size(486, 83);
			textBox11.TabIndex = 10;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(9, 62);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 9;
			label14.Text = "结果：";
			button26.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button26.Location = new System.Drawing.Point(467, 24);
			button26.Name = "button26";
			button26.Size = new System.Drawing.Size(82, 28);
			button26.TabIndex = 8;
			button26.Text = "报文读取";
			button26.UseVisualStyleBackColor = true;
			button26.Click += new System.EventHandler(button26_Click);
			textBox13.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox13.Location = new System.Drawing.Point(63, 27);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(398, 23);
			textBox13.TabIndex = 5;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(9, 30);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(44, 17);
			label16.TabIndex = 4;
			label16.Text = "报文：";
			groupBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox3.Controls.Add(textBox10);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(button25);
			groupBox3.Controls.Add(textBox9);
			groupBox3.Controls.Add(label12);
			groupBox3.Controls.Add(textBox6);
			groupBox3.Controls.Add(label11);
			groupBox3.Location = new System.Drawing.Point(3, 243);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(563, 154);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试";
			textBox10.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox10.Location = new System.Drawing.Point(63, 60);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(494, 88);
			textBox10.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 62);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "结果：";
			button25.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button25.Location = new System.Drawing.Point(475, 24);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(82, 28);
			button25.TabIndex = 8;
			button25.Text = "批量读取";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			textBox9.Location = new System.Drawing.Point(239, 27);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(102, 23);
			textBox9.TabIndex = 7;
			textBox9.Text = "10";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(185, 30);
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
			userControlHead1.ProtocolInfo = "编程口协议 programe";
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
			base.Name = "FormFatekPrograme";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "永宏PLC访问Demo";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			groupBox5.ResumeLayout(false);
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			ResumeLayout(false);
		}
	}
}
