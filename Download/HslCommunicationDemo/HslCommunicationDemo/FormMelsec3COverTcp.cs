using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.LogNet;
using HslCommunication.Profinet.Melsec;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormMelsec3COverTcp : HslFormContent
	{
		private MelsecA3CNetOverTcp melsecA3C = null;

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

		private Button button4;

		private Button button3;

		private UserControlHead userControlHead1;

		private GroupBox groupBox5;

		private TextBox textBox14;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private CheckBox checkBox1;

		private Label label2;

		private ComboBox comboBox2;

		public FormMelsec3COverTcp()
		{
			InitializeComponent();
			melsecA3C = new MelsecA3CNetOverTcp();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			comboBox2.SelectedIndex = 0;
			comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
			checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
			Language(Program.Language);
		}

		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (melsecA3C != null)
			{
				melsecA3C.SumCheck = checkBox1.Checked;
			}
		}

		private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (melsecA3C != null)
			{
				melsecA3C.Format = int.Parse(comboBox2.SelectedItem.ToString());
			}
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "Melsec Read PLC Demo";
				label27.Text = "Ip:";
				label26.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				button3.Text = "Start Plc";
				button4.Text = "Stop Plc";
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
				button3.Text = "Pressure test, r/w 3,000s";
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
				MelsecA3CNetOverTcp melsecA3CNetOverTcp = melsecA3C;
				if (melsecA3CNetOverTcp != null)
				{
					melsecA3CNetOverTcp.ConnectClose();
				}
				melsecA3C = new MelsecA3CNetOverTcp();
				melsecA3C.IpAddress = textBox1.Text;
				melsecA3C.Port = result;
				melsecA3C.LogNet = base.LogNet;
				try
				{
					melsecA3C.Station = byte.Parse(textBox15.Text);
					melsecA3C.SumCheck = checkBox1.Checked;
					melsecA3C.Format = int.Parse(comboBox2.SelectedItem.ToString());
					OperateResult operateResult = melsecA3C.ConnectServer();
					if (operateResult.IsSuccess)
					{
						MessageBox.Show(StringResources.Language.ConnectedSuccess);
						button2.Enabled = true;
						button1.Enabled = false;
						panel2.Enabled = true;
						userControlReadWriteOp1.SetReadWriteNet(melsecA3C, "D100", true);
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
			melsecA3C.ConnectClose();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			DemoUtils.BulkReadRenderResult(melsecA3C, textBox6, textBox9, textBox10);
		}

		private void button26_Click(object sender, EventArgs e)
		{
			OperateResult<byte[]> operateResult = melsecA3C.ReadFromCoreServer(SoftBasic.HexStringToBytes(textBox13.Text));
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
			OperateResult<bool[]> operateResult = melsecA3C.ReadBool("M100", 10);
			if (operateResult.IsSuccess)
			{
				bool flag = operateResult.Content[0];
				bool flag2 = operateResult.Content[9];
			}
			else
			{
				Console.WriteLine("Read failed: " + operateResult.ToMessageShowString());
			}
		}

		private void test2()
		{
			bool[] value = new bool[10]
			{
				true,
				false,
				true,
				true,
				false,
				true,
				false,
				true,
				true,
				false
			};
			OperateResult operateResult = melsecA3C.Write("M100", value);
			if (!operateResult.IsSuccess)
			{
			}
		}

		private void test3()
		{
			short content = melsecA3C.ReadInt16("D100").Content;
			ushort content2 = melsecA3C.ReadUInt16("D100").Content;
			int content3 = melsecA3C.ReadInt32("D100").Content;
			uint content4 = melsecA3C.ReadUInt32("D100").Content;
			long content5 = melsecA3C.ReadInt64("D100").Content;
			ulong content6 = melsecA3C.ReadUInt64("D100").Content;
			float content7 = melsecA3C.ReadFloat("D100").Content;
			double content8 = melsecA3C.ReadDouble("D100").Content;
			string content9 = melsecA3C.ReadString("D100", 10).Content;
		}

		private void test4()
		{
			melsecA3C.Write("D100", (short)5);
			melsecA3C.Write("D100", (ushort)5);
			melsecA3C.Write("D100", 5);
			melsecA3C.Write("D100", 5u);
			melsecA3C.Write("D100", 5L);
			melsecA3C.Write("D100", 5uL);
			melsecA3C.Write("D100", 5f);
			melsecA3C.Write("D100", 5.0);
			melsecA3C.Write("D100", "12345678");
		}

		private void test5()
		{
			OperateResult<byte[]> operateResult = melsecA3C.Read("D100", 10);
			if (operateResult.IsSuccess)
			{
				int num = melsecA3C.ByteTransform.TransInt32(operateResult.Content, 0);
				float num2 = melsecA3C.ByteTransform.TransSingle(operateResult.Content, 4);
				short num3 = melsecA3C.ByteTransform.TransInt16(operateResult.Content, 8);
				string @string = Encoding.ASCII.GetString(operateResult.Content, 10, 10);
			}
		}

		private void test6()
		{
			OperateResult<UserType> operateResult = melsecA3C.ReadCustomer<UserType>("D100");
			if (operateResult.IsSuccess)
			{
				UserType content = operateResult.Content;
			}
			melsecA3C.WriteCustomer("D100", new UserType());
			melsecA3C.LogNet = new LogNetSingle(Application.StartupPath + "\\Logs.txt");
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
		}

		private void button4_Click(object sender, EventArgs e)
		{
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
			comboBox2 = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			checkBox1 = new System.Windows.Forms.CheckBox();
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
			textBox14 = new System.Windows.Forms.TextBox();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
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
			panel1.Controls.Add(comboBox2);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(checkBox1);
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
			comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox2.FormattingEnabled = true;
			comboBox2.Items.AddRange(new object[4]
			{
				"1",
				"2",
				"3",
				"4"
			});
			comboBox2.Location = new System.Drawing.Point(605, 8);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new System.Drawing.Size(68, 25);
			comboBox2.TabIndex = 40;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(555, 11);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 17);
			label2.TabIndex = 36;
			label2.Text = "格式：";
			checkBox1.AutoSize = true;
			checkBox1.Checked = true;
			checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox1.Location = new System.Drawing.Point(457, 10);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(87, 21);
			checkBox1.TabIndex = 34;
			checkBox1.Text = "SumCheck";
			checkBox1.UseVisualStyleBackColor = true;
			textBox15.Location = new System.Drawing.Point(409, 8);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(31, 23);
			textBox15.TabIndex = 28;
			textBox15.Text = "0";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(367, 11);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(44, 17);
			label21.TabIndex = 27;
			label21.Text = "站号：";
			textBox2.Location = new System.Drawing.Point(269, 8);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(79, 23);
			textBox2.TabIndex = 19;
			textBox2.Text = "2000";
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(215, 11);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(44, 17);
			label26.TabIndex = 18;
			label26.Text = "端口：";
			textBox1.Location = new System.Drawing.Point(66, 8);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(138, 23);
			textBox1.TabIndex = 17;
			textBox1.Text = "192.168.0.100";
			label27.AutoSize = true;
			label27.Location = new System.Drawing.Point(8, 11);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(56, 17);
			label27.TabIndex = 16;
			label27.Text = "Ip地址：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(803, 5);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(706, 5);
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
			panel2.Size = new System.Drawing.Size(997, 559);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Location = new System.Drawing.Point(4, 2);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(988, 240);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox5.Controls.Add(textBox14);
			groupBox5.Controls.Add(button4);
			groupBox5.Controls.Add(button3);
			groupBox5.Location = new System.Drawing.Point(573, 243);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(419, 311);
			groupBox5.TabIndex = 4;
			groupBox5.TabStop = false;
			groupBox5.Text = "特殊功能测试";
			textBox14.Location = new System.Drawing.Point(12, 99);
			textBox14.Multiline = true;
			textBox14.Name = "textBox14";
			textBox14.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox14.Size = new System.Drawing.Size(401, 173);
			textBox14.TabIndex = 23;
			button4.Location = new System.Drawing.Point(100, 24);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(82, 28);
			button4.TabIndex = 22;
			button4.Text = "停止PLC";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button3.Location = new System.Drawing.Point(12, 24);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(82, 28);
			button3.TabIndex = 21;
			button3.Text = "启动PLC";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click_1);
			groupBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox4.Controls.Add(textBox11);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(button26);
			groupBox4.Controls.Add(textBox13);
			groupBox4.Controls.Add(label16);
			groupBox4.Location = new System.Drawing.Point(5, 403);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(562, 151);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "报文读取测试，此处需要填入完整的16进制报文字符串";
			textBox11.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox11.Location = new System.Drawing.Point(63, 60);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox11.Size = new System.Drawing.Size(493, 84);
			textBox11.TabIndex = 10;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(9, 62);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 9;
			label14.Text = "结果：";
			button26.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button26.Location = new System.Drawing.Point(480, 24);
			button26.Name = "button26";
			button26.Size = new System.Drawing.Size(82, 28);
			button26.TabIndex = 8;
			button26.Text = "报文读取";
			button26.UseVisualStyleBackColor = true;
			button26.Click += new System.EventHandler(button26_Click);
			textBox13.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox13.Location = new System.Drawing.Point(63, 27);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(411, 23);
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
			groupBox3.Location = new System.Drawing.Point(5, 243);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(562, 154);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试";
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
			button25.Location = new System.Drawing.Point(474, 24);
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
			userControlHead1.ProtocolInfo = "Qna 3C OverTcp";
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
			base.Name = "FormMelsec3COverTcp";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "三菱PLC访问Demo";
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
