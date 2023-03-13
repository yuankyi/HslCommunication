using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Profinet.Yokogawa;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormYokogawaLinkTcp : HslFormContent
	{
		private YokogawaLinkTcp yokogawa = null;

		private IContainer components = null;

		private Panel panel1;

		private Label label1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

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

		private TextBox textBox16;

		private Label label24;

		private UserControlHead userControlHead1;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private GroupBox groupBox5;

		private Button button3;

		private TextBox textBox5;

		private Label label5;

		private TextBox textBox4;

		private Label label4;

		private Button button4;

		private Button button6;

		private Button button5;

		private Button button8;

		private Button button7;

		private Button button9;

		private Button button10;

		private Button button11;

		public FormYokogawaLinkTcp()
		{
			InitializeComponent();
			yokogawa = new YokogawaLinkTcp();
			yokogawa.ConnectTimeOut = 2000;
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
				Text = "Yokogawa Read PLC Demo";
				label1.Text = "Ip:";
				label3.Text = "Port:";
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
			byte result2;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show(DemoUtils.PortInputWrong);
			}
			else if (!byte.TryParse(textBox16.Text, out result2))
			{
				MessageBox.Show("Cpu Number input wrong！");
			}
			else
			{
				yokogawa.IpAddress = textBox1.Text;
				yokogawa.Port = result;
				yokogawa.CpuNumber = result2;
				yokogawa.LogNet = base.LogNet;
				OperateResult operateResult = yokogawa.ConnectServer();
				if (operateResult.IsSuccess)
				{
					MessageBox.Show(StringResources.Language.ConnectedSuccess);
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
					userControlReadWriteOp1.SetReadWriteNet(yokogawa, "D100");
				}
				else
				{
					MessageBox.Show(StringResources.Language.ConnectedFailed);
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			yokogawa.ConnectClose();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			DemoUtils.BulkReadRenderResult(yokogawa, textBox6, textBox9, textBox10);
		}

		private void button26_Click(object sender, EventArgs e)
		{
			OperateResult<byte[]> operateResult = yokogawa.ReadFromCoreServer(SoftBasic.HexStringToBytes(textBox13.Text));
			if (operateResult.IsSuccess)
			{
				textBox11.Text = "Result：" + SoftBasic.ByteToHexString(operateResult.Content);
			}
			else
			{
				MessageBox.Show("Read Failed：" + operateResult.ToMessageShowString());
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlUnitNumber, textBox16.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox16.Text = element.Attribute(DemoDeviceList.XmlUnitNumber).Value;
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
		}

		private void groupBox5_Enter(object sender, EventArgs e)
		{
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OperateResult<bool[]> operateResult = yokogawa.ReadRandomBool(textBox5.Text.Split(';'));
			if (operateResult.IsSuccess)
			{
				textBox4.Text = operateResult.Content.ToArrayString();
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.ToMessageShowString());
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = yokogawa.WriteRandomBool(textBox5.Text.Split(';'), textBox4.Text.ToStringArray<bool>());
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Write Success!");
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.ToMessageShowString());
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			OperateResult<short[]> operateResult = yokogawa.ReadRandomInt16(textBox5.Text.Split(';'));
			if (operateResult.IsSuccess)
			{
				textBox4.Text = operateResult.Content.ToArrayString();
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.ToMessageShowString());
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = yokogawa.WriteRandom(textBox5.Text.Split(';'), textBox4.Text.ToStringArray<short>());
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Write Success!");
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.ToMessageShowString());
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = yokogawa.Start();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Started Success!");
			}
			else
			{
				MessageBox.Show("Started failed: " + operateResult.ToMessageShowString());
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = yokogawa.Stop();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Stop Success!");
			}
			else
			{
				MessageBox.Show("Stop failed: " + operateResult.ToMessageShowString());
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			OperateResult<int> operateResult = yokogawa.ReadProgramStatus();
			if (operateResult.IsSuccess)
			{
				switch (operateResult.Content)
				{
				case 1:
					textBox4.Text = "1 : RUN";
					break;
				case 2:
					textBox4.Text = "2 : Stop";
					break;
				case 3:
					textBox4.Text = "3 : Debug";
					break;
				case 4:
					textBox4.Text = "4 : Rom writer";
					break;
				default:
					textBox4.Text = operateResult.Content.ToString();
					break;
				}
			}
			else
			{
				MessageBox.Show("Read failed: " + operateResult.ToMessageShowString());
			}
		}

		private void button10_Click(object sender, EventArgs e)
		{
			OperateResult<YokogawaSystemInfo> operateResult = yokogawa.ReadSystemInfo();
			if (operateResult.IsSuccess)
			{
				textBox4.Text = operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read failed: " + operateResult.ToMessageShowString());
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			OperateResult<DateTime> operateResult = yokogawa.ReadDateTime();
			if (operateResult.IsSuccess)
			{
				textBox4.Text = operateResult.Content.ToString();
			}
			else
			{
				MessageBox.Show("Read failed: " + operateResult.ToMessageShowString());
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
			textBox16 = new System.Windows.Forms.TextBox();
			label24 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox5 = new System.Windows.Forms.GroupBox();
			button11 = new System.Windows.Forms.Button();
			button10 = new System.Windows.Forms.Button();
			button9 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			textBox5 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
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
			panel1.Controls.Add(textBox16);
			panel1.Controls.Add(label24);
			panel1.Controls.Add(label22);
			panel1.Controls.Add(label21);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 45);
			panel1.TabIndex = 0;
			textBox16.Location = new System.Drawing.Point(407, 9);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(56, 23);
			textBox16.TabIndex = 11;
			textBox16.Text = "1";
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(311, 12);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(95, 17);
			label24.TabIndex = 10;
			label24.Text = "Cpu Number：";
			label22.Location = new System.Drawing.Point(840, 3);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(148, 37);
			label22.TabIndex = 7;
			label22.Text = "D100 C100 W100 H100 A100";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(769, 7);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(68, 17);
			label21.TabIndex = 6;
			label21.Text = "地址示例：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(640, 6);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(106, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(516, 6);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(99, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(236, 9);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(69, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "12289";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(182, 12);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 9);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(114, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "192.168.0.2";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteOp1);
			panel2.Controls.Add(groupBox5);
			panel2.Controls.Add(groupBox4);
			panel2.Controls.Add(groupBox3);
			panel2.Location = new System.Drawing.Point(3, 83);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 559);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Location = new System.Drawing.Point(4, 3);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(988, 240);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox5.Controls.Add(button11);
			groupBox5.Controls.Add(button10);
			groupBox5.Controls.Add(button9);
			groupBox5.Controls.Add(button8);
			groupBox5.Controls.Add(button7);
			groupBox5.Controls.Add(button6);
			groupBox5.Controls.Add(button5);
			groupBox5.Controls.Add(button4);
			groupBox5.Controls.Add(textBox4);
			groupBox5.Controls.Add(label4);
			groupBox5.Controls.Add(button3);
			groupBox5.Controls.Add(textBox5);
			groupBox5.Controls.Add(label5);
			groupBox5.Location = new System.Drawing.Point(573, 243);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(419, 311);
			groupBox5.TabIndex = 4;
			groupBox5.TabStop = false;
			groupBox5.Text = "特殊功能测试";
			groupBox5.Enter += new System.EventHandler(groupBox5_Enter);
			button11.Location = new System.Drawing.Point(178, 245);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(111, 28);
			button11.TabIndex = 27;
			button11.Text = "DateTime";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			button10.Location = new System.Drawing.Point(61, 245);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(111, 28);
			button10.TabIndex = 26;
			button10.Text = "SystemInfo";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(button10_Click);
			button9.Location = new System.Drawing.Point(295, 211);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(118, 28);
			button9.TabIndex = 25;
			button9.Text = "ProgramStatus";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			button8.Location = new System.Drawing.Point(355, 177);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(58, 28);
			button8.TabIndex = 24;
			button8.Text = "Stop";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			button7.Location = new System.Drawing.Point(295, 177);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(58, 28);
			button7.TabIndex = 23;
			button7.Text = "Start";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			button6.Location = new System.Drawing.Point(178, 211);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(111, 28);
			button6.TabIndex = 22;
			button6.Text = "随机写入读取";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button5.Location = new System.Drawing.Point(61, 211);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(111, 28);
			button5.TabIndex = 21;
			button5.Text = "随机word读取";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			button4.Location = new System.Drawing.Point(178, 177);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(111, 28);
			button4.TabIndex = 20;
			button4.Text = "随机Bool写入";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			textBox4.Location = new System.Drawing.Point(61, 98);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox4.Size = new System.Drawing.Size(342, 73);
			textBox4.TabIndex = 19;
			textBox4.Text = "true,true,true,true";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(7, 101);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(32, 17);
			label4.TabIndex = 18;
			label4.Text = "值：";
			button3.Location = new System.Drawing.Point(61, 177);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(111, 28);
			button3.TabIndex = 17;
			button3.Text = "随机Bool读取";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox5.Location = new System.Drawing.Point(61, 30);
			textBox5.Multiline = true;
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(342, 62);
			textBox5.TabIndex = 12;
			textBox5.Text = "Y100;Y200;M100;M300";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(7, 33);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(44, 17);
			label5.TabIndex = 11;
			label5.Text = "地址：";
			groupBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox4.Controls.Add(textBox11);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(button26);
			groupBox4.Controls.Add(textBox13);
			groupBox4.Controls.Add(label16);
			groupBox4.Location = new System.Drawing.Point(4, 403);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(563, 151);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "报文读取测试，此处需要填入完整的16进制报文字符串";
			textBox11.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox11.Location = new System.Drawing.Point(63, 60);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox11.Size = new System.Drawing.Size(494, 85);
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
			textBox13.Size = new System.Drawing.Size(396, 23);
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
			groupBox3.Location = new System.Drawing.Point(4, 243);
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
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7469679.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "横河协议";
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
			base.Name = "FormYokogawaLinkTcp";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "横河PLC访问Demo";
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
