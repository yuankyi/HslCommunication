using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Profinet.Omron;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormOmronCip : HslFormContent
	{
		private OmronCipNet omronCipNet = null;

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

		private TextBox textBox6;

		private Label label11;

		private Label label22;

		private Label label21;

		private TextBox textBox15;

		private Label label23;

		private UserControlHead userControlHead1;

		private Button button3;

		private GroupBox groupBox5;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private TextBox textBox5;

		private Label label6;

		private TextBox textBox4;

		private Label label5;

		private Button button4;

		private TextBox textBox3;

		private Label label4;

		private TextBox textBox7;

		private Label label7;

		private TextBox textBox9;

		private Label label12;

		private Button button5;

		private GroupBox groupBox1;

		private Button button6;

		private TextBox textBox_date_render;

		private Label label8;

		private TextBox textBox_date_address;

		private Label label2;

		private Button button7;

		private Button button9;

		private Button button8;

		private Button button11;

		private Button button10;

		private Button button12;

		public FormOmronCip()
		{
			InitializeComponent();
			omronCipNet = new OmronCipNet("192.168.0.110");
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
				Text = "Omron Read PLC Demo";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
				label11.Text = "Address:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				label16.Text = "Message:";
				label14.Text = "Results:";
				button26.Text = "Read";
				button3.Text = "Build";
				groupBox3.Text = "Bulk Read test";
				groupBox4.Text = "CIP reading test, hex string needs to be filled in";
				groupBox5.Text = "Special function test";
				label22.Text = "plc tag name";
				groupBox1.Text = "Time Read Write";
				label2.Text = "Address:";
				label4.Text = "Address:";
				label8.Text = "Data:";
				label5.Text = "Type:";
				label7.Text = "Length:";
				label6.Text = "Data:";
				button4.Text = "Write";
				button5.Text = "Read Type Data";
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
			else if (!byte.TryParse(textBox15.Text, out result2))
			{
				MessageBox.Show(DemoUtils.SlotInputWrong);
			}
			else
			{
				omronCipNet.IpAddress = textBox1.Text;
				omronCipNet.Port = result;
				omronCipNet.Slot = result2;
				omronCipNet.LogNet = base.LogNet;
				try
				{
					OperateResult operateResult = omronCipNet.ConnectServer();
					if (operateResult.IsSuccess)
					{
						MessageBox.Show(StringResources.Language.ConnectedSuccess);
						button2.Enabled = true;
						button1.Enabled = false;
						panel2.Enabled = true;
						userControlReadWriteOp1.SetReadWriteNet(omronCipNet, "A1", true);
					}
					else
					{
						MessageBox.Show(StringResources.Language.ConnectedFailed + operateResult.ToMessageShowString());
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
			omronCipNet.ConnectClose();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			try
			{
				OperateResult<byte[]> operateResult = null;
				operateResult = (textBox6.Text.Contains(";") ? omronCipNet.Read(textBox6.Text.Split(';')) : omronCipNet.Read(new string[1]
				{
					textBox6.Text
				}, new int[1]
				{
					ushort.Parse(textBox9.Text)
				}));
				if (operateResult.IsSuccess)
				{
					textBox10.Text = "Result：" + SoftBasic.ByteToHexString(operateResult.Content);
				}
				else
				{
					MessageBox.Show("Read failed：" + operateResult.ToMessageShowString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Read failed：" + ex.Message);
			}
		}

		private void button26_Click(object sender, EventArgs e)
		{
			OperateResult<byte[]> operateResult = omronCipNet.ReadCipFromServer(SoftBasic.HexStringToBytes(textBox13.Text));
			if (operateResult.IsSuccess)
			{
				textBox11.Text = "Result：" + SoftBasic.ByteToHexString(operateResult.Content);
			}
			else
			{
				MessageBox.Show("Read failed：" + operateResult.ToMessageShowString());
			}
		}

		private void Button3_Click(object sender, EventArgs e)
		{
		}

		private void button4_Click(object sender, EventArgs e)
		{
			try
			{
				OperateResult result = omronCipNet.WriteTag(textBox3.Text, Convert.ToUInt16(textBox4.Text, 16), textBox5.Text.ToHexBytes(), int.Parse(textBox7.Text));
				DemoUtils.WriteResultRender(result, textBox3.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show("write failed：" + ex.Message);
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			OperateResult<ushort, byte[]> operateResult = omronCipNet.ReadTag(textBox3.Text, int.Parse(textBox7.Text));
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Read failed! " + operateResult.Message);
			}
			else
			{
				textBox4.Text = operateResult.Content1.ToString("X");
				textBox5.Text = operateResult.Content2.ToHexString(' ');
			}
		}

		private void button12_Click(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = omronCipNet.ReadPlcType();
			if (operateResult.IsSuccess)
			{
				textBox5.Text = operateResult.Content;
			}
			else
			{
				MessageBox.Show("Read failed! " + operateResult.Message);
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			OperateResult<DateTime> operateResult = omronCipNet.ReadDate(textBox_date_address.Text);
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Read failed! " + operateResult.Message);
			}
			else
			{
				textBox_date_render.Text = operateResult.Content.ToString();
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = omronCipNet.WriteDate(textBox_date_address.Text, DateTime.Parse(textBox_date_render.Text));
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Write failed! " + operateResult.Message);
			}
			else
			{
				MessageBox.Show("Write Success");
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			OperateResult<TimeSpan> operateResult = omronCipNet.ReadTime(textBox_date_address.Text);
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Read failed! " + operateResult.Message);
			}
			else
			{
				textBox_date_render.Text = operateResult.Content.ToString();
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = omronCipNet.WriteTime(textBox_date_address.Text, TimeSpan.Parse(textBox_date_render.Text));
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Write failed! " + operateResult.Message);
			}
			else
			{
				MessageBox.Show("Write Success");
			}
		}

		private void button10_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = omronCipNet.WriteTimeAndDate(textBox_date_address.Text, DateTime.Parse(textBox_date_render.Text));
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Write failed! " + operateResult.Message);
			}
			else
			{
				MessageBox.Show("Write Success");
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = omronCipNet.WriteTimeOfDate(textBox_date_address.Text, TimeSpan.Parse(textBox_date_render.Text));
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Write failed! " + operateResult.Message);
			}
			else
			{
				MessageBox.Show("Write Success");
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlSlot, textBox15.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox15.Text = element.Attribute(DemoDeviceList.XmlSlot).Value;
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
			textBox15 = new System.Windows.Forms.TextBox();
			label23 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			groupBox1 = new System.Windows.Forms.GroupBox();
			button11 = new System.Windows.Forms.Button();
			button10 = new System.Windows.Forms.Button();
			button9 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			textBox_date_render = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			textBox_date_address = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox5 = new System.Windows.Forms.GroupBox();
			button12 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			textBox7 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			button4 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			groupBox4 = new System.Windows.Forms.GroupBox();
			textBox11 = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			button26 = new System.Windows.Forms.Button();
			textBox13 = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			button3 = new System.Windows.Forms.Button();
			textBox9 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			textBox10 = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			button25 = new System.Windows.Forms.Button();
			textBox6 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox1.SuspendLayout();
			groupBox5.SuspendLayout();
			groupBox4.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox15);
			panel1.Controls.Add(label23);
			panel1.Controls.Add(label22);
			panel1.Controls.Add(label21);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(4, 36);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(996, 42);
			panel1.TabIndex = 0;
			textBox15.Location = new System.Drawing.Point(410, 9);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(49, 23);
			textBox15.TabIndex = 9;
			textBox15.Text = "0";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(366, 12);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(41, 17);
			label23.TabIndex = 8;
			label23.Text = "slot：";
			label22.Location = new System.Drawing.Point(819, 2);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(158, 45);
			label22.TabIndex = 7;
			label22.Text = "变量的标签名";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(745, 2);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(68, 17);
			label21.TabIndex = 6;
			label21.Text = "地址示例：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(629, 6);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(522, 6);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(269, 9);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(84, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "44818";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(215, 12);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 9);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(141, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "192.168.0.100";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(groupBox1);
			panel2.Controls.Add(userControlReadWriteOp1);
			panel2.Controls.Add(groupBox5);
			panel2.Controls.Add(groupBox4);
			panel2.Controls.Add(groupBox3);
			panel2.Location = new System.Drawing.Point(4, 82);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(996, 559);
			panel2.TabIndex = 1;
			groupBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox1.Controls.Add(button11);
			groupBox1.Controls.Add(button10);
			groupBox1.Controls.Add(button9);
			groupBox1.Controls.Add(button8);
			groupBox1.Controls.Add(button7);
			groupBox1.Controls.Add(button6);
			groupBox1.Controls.Add(textBox_date_render);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(textBox_date_address);
			groupBox1.Controls.Add(label2);
			groupBox1.Location = new System.Drawing.Point(535, 243);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(456, 154);
			groupBox1.TabIndex = 6;
			groupBox1.TabStop = false;
			groupBox1.Text = "时间格式";
			button11.Location = new System.Drawing.Point(284, 116);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(162, 28);
			button11.TabIndex = 21;
			button11.Text = "w-DateOfTime";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			button10.Location = new System.Drawing.Point(284, 52);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(162, 28);
			button10.TabIndex = 20;
			button10.Text = "w-DateAndTime";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(button10_Click);
			button9.Location = new System.Drawing.Point(368, 84);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(78, 28);
			button9.TabIndex = 19;
			button9.Text = "w-Time";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			button8.Location = new System.Drawing.Point(284, 84);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(78, 28);
			button8.TabIndex = 18;
			button8.Text = "r-Time";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			button7.Location = new System.Drawing.Point(368, 21);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(78, 28);
			button7.TabIndex = 17;
			button7.Text = "w-Date";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			button6.Location = new System.Drawing.Point(284, 21);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(78, 28);
			button6.TabIndex = 16;
			button6.Text = "r-Date";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			textBox_date_render.Location = new System.Drawing.Point(64, 57);
			textBox_date_render.Multiline = true;
			textBox_date_render.Name = "textBox_date_render";
			textBox_date_render.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_date_render.Size = new System.Drawing.Size(214, 81);
			textBox_date_render.TabIndex = 15;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(10, 60);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(44, 17);
			label8.TabIndex = 14;
			label8.Text = "数据：";
			textBox_date_address.Location = new System.Drawing.Point(64, 24);
			textBox_date_address.Name = "textBox_date_address";
			textBox_date_address.Size = new System.Drawing.Size(214, 23);
			textBox_date_address.TabIndex = 9;
			textBox_date_address.Text = "A1";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(10, 27);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 17);
			label2.TabIndex = 8;
			label2.Text = "地址：";
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Location = new System.Drawing.Point(3, 2);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(988, 240);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox5.Controls.Add(button12);
			groupBox5.Controls.Add(button5);
			groupBox5.Controls.Add(textBox7);
			groupBox5.Controls.Add(label7);
			groupBox5.Controls.Add(textBox5);
			groupBox5.Controls.Add(label6);
			groupBox5.Controls.Add(textBox4);
			groupBox5.Controls.Add(label5);
			groupBox5.Controls.Add(button4);
			groupBox5.Controls.Add(textBox3);
			groupBox5.Controls.Add(label4);
			groupBox5.Location = new System.Drawing.Point(535, 403);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(452, 147);
			groupBox5.TabIndex = 4;
			groupBox5.TabStop = false;
			groupBox5.Text = "类型及原始数据读写测试";
			button12.Location = new System.Drawing.Point(343, 114);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(99, 28);
			button12.TabIndex = 26;
			button12.Text = "PLC 型号";
			button12.UseVisualStyleBackColor = true;
			button12.Click += new System.EventHandler(button12_Click);
			button5.Location = new System.Drawing.Point(247, 114);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(92, 28);
			button5.TabIndex = 16;
			button5.Text = "读取";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			textBox7.Location = new System.Drawing.Point(64, 116);
			textBox7.Name = "textBox7";
			textBox7.Size = new System.Drawing.Size(87, 23);
			textBox7.TabIndex = 15;
			textBox7.Text = "1";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(10, 119);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(44, 17);
			label7.TabIndex = 14;
			label7.Text = "长度：";
			textBox5.Location = new System.Drawing.Point(64, 56);
			textBox5.Multiline = true;
			textBox5.Name = "textBox5";
			textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox5.Size = new System.Drawing.Size(378, 52);
			textBox5.TabIndex = 13;
			textBox5.Text = "64 00";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(10, 59);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(44, 17);
			label6.TabIndex = 12;
			label6.Text = "数据：";
			textBox4.Location = new System.Drawing.Point(363, 27);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(79, 23);
			textBox4.TabIndex = 11;
			textBox4.Text = "C1";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(309, 30);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(44, 17);
			label5.TabIndex = 10;
			label5.Text = "类型：";
			button4.Location = new System.Drawing.Point(157, 114);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(86, 28);
			button4.TabIndex = 9;
			button4.Text = "写入";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			textBox3.Location = new System.Drawing.Point(64, 27);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(239, 23);
			textBox3.TabIndex = 7;
			textBox3.Text = "A1";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(10, 30);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(44, 17);
			label4.TabIndex = 6;
			label4.Text = "地址：";
			groupBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox4.Controls.Add(textBox11);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(button26);
			groupBox4.Controls.Add(textBox13);
			groupBox4.Controls.Add(label16);
			groupBox4.Location = new System.Drawing.Point(3, 403);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(526, 147);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "CIP报文读取测试，此处需要填入完整的16进制报文字符串";
			textBox11.Location = new System.Drawing.Point(63, 60);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox11.Size = new System.Drawing.Size(457, 81);
			textBox11.TabIndex = 10;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(9, 62);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 9;
			label14.Text = "结果：";
			button26.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button26.Location = new System.Drawing.Point(438, 24);
			button26.Name = "button26";
			button26.Size = new System.Drawing.Size(82, 28);
			button26.TabIndex = 8;
			button26.Text = "报文读取";
			button26.UseVisualStyleBackColor = true;
			button26.Click += new System.EventHandler(button26_Click);
			textBox13.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox13.Location = new System.Drawing.Point(63, 27);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(357, 23);
			textBox13.TabIndex = 5;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(9, 30);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(44, 17);
			label16.TabIndex = 4;
			label16.Text = "报文：";
			groupBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox3.Controls.Add(button3);
			groupBox3.Controls.Add(textBox9);
			groupBox3.Controls.Add(label12);
			groupBox3.Controls.Add(textBox10);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(button25);
			groupBox3.Controls.Add(textBox6);
			groupBox3.Controls.Add(label11);
			groupBox3.Location = new System.Drawing.Point(3, 243);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(526, 154);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试，分号间隔";
			button3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button3.Location = new System.Drawing.Point(438, 24);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(82, 28);
			button3.TabIndex = 15;
			button3.Text = "报文生成";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(Button3_Click);
			textBox9.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			textBox9.Location = new System.Drawing.Point(266, 27);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(76, 23);
			textBox9.TabIndex = 12;
			textBox9.Text = "1";
			label12.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(216, 30);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(44, 17);
			label12.TabIndex = 11;
			label12.Text = "长度：";
			textBox10.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox10.Location = new System.Drawing.Point(63, 60);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(457, 88);
			textBox10.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 62);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "结果：";
			button25.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button25.Location = new System.Drawing.Point(348, 24);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(75, 28);
			button25.TabIndex = 8;
			button25.Text = "读取";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			textBox6.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox6.Location = new System.Drawing.Point(63, 27);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(150, 23);
			textBox6.TabIndex = 5;
			textBox6.Text = "A1;A2";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(9, 30);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 4;
			label11.Text = "地址：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/9607929.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "CIP";
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
			base.Name = "FormOmronCip";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Omron访问Demo";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
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
