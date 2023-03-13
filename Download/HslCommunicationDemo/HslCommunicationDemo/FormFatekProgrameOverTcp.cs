using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.LogNet;
using HslCommunication.Profinet.FATEK;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormFatekProgrameOverTcp : HslFormContent
	{
		private FatekProgramOverTcp fatekProgram = null;

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

		private TextBox textBox2;

		private Label label26;

		private TextBox textBox1;

		private Label label27;

		private TextBox textBox15;

		private Label label21;

		private UserControlHead userControlHead1;

		private GroupBox groupBox5;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private Button button_stop;

		private Button button_run;

		private Label label_bit6_false;

		private Label label_bit6_true;

		private Label label_bit5_false;

		private Label label_bit5_true;

		private Label label_bit4_false;

		private Label label_bit4_true;

		private Label label_bit3_false;

		private Label label_bit3_true;

		private Label label_bit2_false;

		private Label label_bit2_true;

		private Label label_bit1_false;

		private Label label_bit1_true;

		private Label label_bit0_false;

		private Label label_bit0_true;

		private Button button_read_status;

		public FormFatekProgrameOverTcp()
		{
			InitializeComponent();
			fatekProgram = new FatekProgramOverTcp();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "FATEK Read PLC Demo";
				label27.Text = "Ip:";
				label26.Text = "Port:";
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
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show(DemoUtils.PortInputWrong);
			}
			else
			{
				FatekProgramOverTcp fatekProgramOverTcp = fatekProgram;
				if (fatekProgramOverTcp != null)
				{
					fatekProgramOverTcp.ConnectClose();
				}
				fatekProgram = new FatekProgramOverTcp();
				fatekProgram.IpAddress = textBox1.Text;
				fatekProgram.Port = result;
				fatekProgram.LogNet = base.LogNet;
				try
				{
					fatekProgram.Station = byte.Parse(textBox15.Text);
					OperateResult operateResult = fatekProgram.ConnectServer();
					if (operateResult.IsSuccess)
					{
						MessageBox.Show(StringResources.Language.ConnectedSuccess);
						button2.Enabled = true;
						button1.Enabled = false;
						panel2.Enabled = true;
						userControlReadWriteOp1.SetReadWriteNet(fatekProgram, "D100", true);
					}
					else
					{
						MessageBox.Show(StringResources.Language.ConnectedFailed);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			fatekProgram.ConnectClose();
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
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlStation, textBox15.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
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

		private void button_read_status_Click(object sender, EventArgs e)
		{
			OperateResult<bool[]> operateResult = fatekProgram.ReadStatus();
			if (operateResult.IsSuccess)
			{
				FormFatekPrograme.SetColorFromStatus(operateResult.Content[0], label_bit0_true, label_bit0_false);
				FormFatekPrograme.SetColorFromStatus(operateResult.Content[1], label_bit1_true, label_bit1_false);
				FormFatekPrograme.SetColorFromStatus(operateResult.Content[2], label_bit2_true, label_bit2_false);
				FormFatekPrograme.SetColorFromStatus(operateResult.Content[3], label_bit3_true, label_bit3_false);
				FormFatekPrograme.SetColorFromStatus(operateResult.Content[4], label_bit4_true, label_bit4_false);
				FormFatekPrograme.SetColorFromStatus(operateResult.Content[5], label_bit5_true, label_bit5_false);
				FormFatekPrograme.SetColorFromStatus(operateResult.Content[6], label_bit6_true, label_bit6_false);
			}
			else
			{
				MessageBox.Show("Read failed: " + operateResult.Message);
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
			textBox15 = new System.Windows.Forms.TextBox();
			label21 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			label26 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
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
			panel1.Controls.Add(textBox15);
			panel1.Controls.Add(label21);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label26);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label27);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 46);
			panel1.TabIndex = 0;
			textBox15.Location = new System.Drawing.Point(397, 9);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(31, 23);
			textBox15.TabIndex = 28;
			textBox15.Text = "1";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(340, 12);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(44, 17);
			label21.TabIndex = 27;
			label21.Text = "站号：";
			textBox2.Location = new System.Drawing.Point(250, 9);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(57, 23);
			textBox2.TabIndex = 19;
			textBox2.Text = "2000";
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(196, 12);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(44, 17);
			label26.TabIndex = 18;
			label26.Text = "端口：";
			textBox1.Location = new System.Drawing.Point(73, 9);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(114, 23);
			textBox1.TabIndex = 17;
			textBox1.Text = "192.168.0.20";
			label27.AutoSize = true;
			label27.Location = new System.Drawing.Point(8, 12);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(56, 17);
			label27.TabIndex = 16;
			label27.Text = "Ip地址：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(567, 6);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(470, 6);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
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
			panel2.Size = new System.Drawing.Size(997, 558);
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
			groupBox5.Location = new System.Drawing.Point(573, 243);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(419, 310);
			groupBox5.TabIndex = 4;
			groupBox5.TabStop = false;
			groupBox5.Text = "特殊功能测试";
			label_bit6_false.BackColor = System.Drawing.Color.Silver;
			label_bit6_false.Location = new System.Drawing.Point(194, 268);
			label_bit6_false.Name = "label_bit6_false";
			label_bit6_false.Size = new System.Drawing.Size(150, 20);
			label_bit6_false.TabIndex = 40;
			label_bit6_false.Text = "Normal";
			label_bit6_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit6_true.BackColor = System.Drawing.Color.Silver;
			label_bit6_true.Location = new System.Drawing.Point(24, 268);
			label_bit6_true.Name = "label_bit6_true";
			label_bit6_true.Size = new System.Drawing.Size(150, 20);
			label_bit6_true.TabIndex = 39;
			label_bit6_true.Text = "Emergency stop";
			label_bit6_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit5_false.BackColor = System.Drawing.Color.Silver;
			label_bit5_false.Location = new System.Drawing.Point(194, 238);
			label_bit5_false.Name = "label_bit5_false";
			label_bit5_false.Size = new System.Drawing.Size(150, 20);
			label_bit5_false.TabIndex = 38;
			label_bit5_false.Text = "Not Set ID";
			label_bit5_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit5_true.BackColor = System.Drawing.Color.Silver;
			label_bit5_true.Location = new System.Drawing.Point(24, 238);
			label_bit5_true.Name = "label_bit5_true";
			label_bit5_true.Size = new System.Drawing.Size(150, 20);
			label_bit5_true.TabIndex = 37;
			label_bit5_true.Text = "Set ID";
			label_bit5_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit4_false.BackColor = System.Drawing.Color.Silver;
			label_bit4_false.Location = new System.Drawing.Point(194, 209);
			label_bit4_false.Name = "label_bit4_false";
			label_bit4_false.Size = new System.Drawing.Size(150, 20);
			label_bit4_false.TabIndex = 36;
			label_bit4_false.Text = "Normal";
			label_bit4_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit4_true.BackColor = System.Drawing.Color.Silver;
			label_bit4_true.Location = new System.Drawing.Point(24, 209);
			label_bit4_true.Name = "label_bit4_true";
			label_bit4_true.Size = new System.Drawing.Size(150, 20);
			label_bit4_true.TabIndex = 35;
			label_bit4_true.Text = "WDT Timeout";
			label_bit4_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit3_false.BackColor = System.Drawing.Color.Silver;
			label_bit3_false.Location = new System.Drawing.Point(194, 179);
			label_bit3_false.Name = "label_bit3_false";
			label_bit3_false.Size = new System.Drawing.Size(150, 20);
			label_bit3_false.TabIndex = 34;
			label_bit3_false.Text = "Not used";
			label_bit3_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit3_true.BackColor = System.Drawing.Color.Silver;
			label_bit3_true.Location = new System.Drawing.Point(24, 179);
			label_bit3_true.Name = "label_bit3_true";
			label_bit3_true.Size = new System.Drawing.Size(150, 20);
			label_bit3_true.TabIndex = 33;
			label_bit3_true.Text = "Use ROM Pack";
			label_bit3_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit2_false.BackColor = System.Drawing.Color.Silver;
			label_bit2_false.Location = new System.Drawing.Point(194, 151);
			label_bit2_false.Name = "label_bit2_false";
			label_bit2_false.Size = new System.Drawing.Size(150, 20);
			label_bit2_false.TabIndex = 32;
			label_bit2_false.Text = "Normal";
			label_bit2_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit2_true.BackColor = System.Drawing.Color.Silver;
			label_bit2_true.Location = new System.Drawing.Point(24, 151);
			label_bit2_true.Name = "label_bit2_true";
			label_bit2_true.Size = new System.Drawing.Size(150, 20);
			label_bit2_true.TabIndex = 31;
			label_bit2_true.Text = "Ladder checksum error";
			label_bit2_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit1_false.BackColor = System.Drawing.Color.Silver;
			label_bit1_false.Location = new System.Drawing.Point(194, 123);
			label_bit1_false.Name = "label_bit1_false";
			label_bit1_false.Size = new System.Drawing.Size(150, 20);
			label_bit1_false.TabIndex = 30;
			label_bit1_false.Text = "Normal";
			label_bit1_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit1_true.BackColor = System.Drawing.Color.Silver;
			label_bit1_true.Location = new System.Drawing.Point(24, 123);
			label_bit1_true.Name = "label_bit1_true";
			label_bit1_true.Size = new System.Drawing.Size(150, 20);
			label_bit1_true.TabIndex = 29;
			label_bit1_true.Text = "BAT LOW";
			label_bit1_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit0_false.BackColor = System.Drawing.Color.Silver;
			label_bit0_false.Location = new System.Drawing.Point(194, 96);
			label_bit0_false.Name = "label_bit0_false";
			label_bit0_false.Size = new System.Drawing.Size(150, 20);
			label_bit0_false.TabIndex = 28;
			label_bit0_false.Text = "STOP";
			label_bit0_false.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label_bit0_true.BackColor = System.Drawing.Color.Silver;
			label_bit0_true.Location = new System.Drawing.Point(24, 96);
			label_bit0_true.Name = "label_bit0_true";
			label_bit0_true.Size = new System.Drawing.Size(150, 20);
			label_bit0_true.TabIndex = 27;
			label_bit0_true.Text = "RUN";
			label_bit0_true.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_read_status.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_read_status.Location = new System.Drawing.Point(24, 62);
			button_read_status.Name = "button_read_status";
			button_read_status.Size = new System.Drawing.Size(82, 28);
			button_read_status.TabIndex = 26;
			button_read_status.Text = "Status";
			button_read_status.UseVisualStyleBackColor = true;
			button_read_status.Click += new System.EventHandler(button_read_status_Click);
			button_stop.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_stop.Location = new System.Drawing.Point(130, 24);
			button_stop.Name = "button_stop";
			button_stop.Size = new System.Drawing.Size(82, 28);
			button_stop.TabIndex = 12;
			button_stop.Text = "Stop";
			button_stop.UseVisualStyleBackColor = true;
			button_stop.Click += new System.EventHandler(button_stop_Click);
			button_run.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_run.Location = new System.Drawing.Point(24, 24);
			button_run.Name = "button_run";
			button_run.Size = new System.Drawing.Size(82, 28);
			button_run.TabIndex = 11;
			button_run.Text = "Run";
			button_run.UseVisualStyleBackColor = true;
			button_run.Click += new System.EventHandler(button_run_Click);
			groupBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox4.Controls.Add(textBox11);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(button26);
			groupBox4.Controls.Add(textBox13);
			groupBox4.Controls.Add(label16);
			groupBox4.Location = new System.Drawing.Point(3, 403);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(564, 150);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "报文读取测试，此处需要填入完整的16进制报文字符串";
			textBox11.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox11.Location = new System.Drawing.Point(63, 60);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox11.Size = new System.Drawing.Size(495, 84);
			textBox11.TabIndex = 10;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(9, 62);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 9;
			label14.Text = "结果：";
			button26.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button26.Location = new System.Drawing.Point(476, 24);
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
			groupBox3.Controls.Add(textBox10);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(button25);
			groupBox3.Controls.Add(textBox9);
			groupBox3.Controls.Add(label12);
			groupBox3.Controls.Add(textBox6);
			groupBox3.Controls.Add(label11);
			groupBox3.Location = new System.Drawing.Point(3, 243);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(564, 154);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试";
			textBox10.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox10.Location = new System.Drawing.Point(63, 60);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(495, 88);
			textBox10.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 62);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "结果：";
			button25.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button25.Location = new System.Drawing.Point(476, 24);
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
			userControlHead1.ProtocolInfo = "编程口协议 programe OverTcp";
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
			base.Name = "FormFatekProgrameOverTcp";
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
