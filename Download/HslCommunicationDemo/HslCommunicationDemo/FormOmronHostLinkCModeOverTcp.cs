using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using HslCommunication.Profinet.Omron;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormOmronHostLinkCModeOverTcp : HslFormContent
	{
		private OmronHostLinkCModeOverTcp omronHostLink = null;

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

		private TextBox textBox1;

		private Label label1;

		private TextBox textBox19;

		private Label label28;

		private TextBox textBox20;

		private Label label29;

		private UserControlHead userControlHead1;

		private GroupBox groupBox5;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private ComboBox comboBox4;

		private Button button5;

		private Button button4;

		private Button button3;

		private TextBox textBox3;

		private Label label2;

		public FormOmronHostLinkCModeOverTcp()
		{
			InitializeComponent();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			comboBox1.DataSource = SoftBasic.GetEnumValues<DataFormat>();
			comboBox1.SelectedItem = DataFormat.CDAB;
			panel2.Enabled = false;
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "Omron Read PLC Demo";
				label1.Text = "Station:";
				button1.Text = "Open";
				button2.Text = "Close";
				label21.Text = "Address:";
				label29.Text = "Ip:";
				label28.Text = "Port:";
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
				comboBox4.DataSource = new string[3]
				{
					"programming",
					"running",
					"monitoring"
				};
			}
			else
			{
				comboBox4.DataSource = new string[3]
				{
					"编程模式",
					"运行模式",
					"监视模式"
				};
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			byte result2;
			if (!int.TryParse(textBox19.Text, out result))
			{
				MessageBox.Show(DemoUtils.PortInputWrong);
			}
			else if (!byte.TryParse(textBox1.Text, out result2))
			{
				MessageBox.Show("PLC Station input wrong！");
			}
			else
			{
				OmronHostLinkCModeOverTcp omronHostLinkCModeOverTcp = omronHostLink;
				if (omronHostLinkCModeOverTcp != null)
				{
					omronHostLinkCModeOverTcp.ConnectClose();
				}
				omronHostLink = new OmronHostLinkCModeOverTcp();
				omronHostLink.IpAddress = textBox20.Text;
				omronHostLink.Port = result;
				omronHostLink.LogNet = base.LogNet;
				try
				{
					omronHostLink.UnitNumber = result2;
					omronHostLink.ByteTransform.DataFormat = (DataFormat)comboBox1.SelectedItem;
					OperateResult operateResult = omronHostLink.ConnectServer();
					if (operateResult.IsSuccess)
					{
						MessageBox.Show(StringResources.Language.ConnectedSuccess);
						button2.Enabled = true;
						button1.Enabled = false;
						panel2.Enabled = true;
						userControlReadWriteOp1.SetReadWriteNet(omronHostLink, "D100");
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
			omronHostLink.ConnectClose();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			DemoUtils.BulkReadRenderResult(omronHostLink, textBox6, textBox9, textBox10);
		}

		private void button26_Click(object sender, EventArgs e)
		{
			OperateResult<byte[]> operateResult = omronHostLink.ReadFromCoreServer(SoftBasic.HexStringToBytes(textBox13.Text));
			if (operateResult.IsSuccess)
			{
				textBox11.Text = "Result：" + SoftBasic.ByteToHexString(operateResult.Content);
			}
			else
			{
				MessageBox.Show("Read Failed：" + operateResult.ToMessageShowString());
			}
		}

		private void test()
		{
			bool content = omronHostLink.ReadBool("D100.7").Content;
			short content2 = omronHostLink.ReadInt16("D100").Content;
			ushort content3 = omronHostLink.ReadUInt16("D100").Content;
			int content4 = omronHostLink.ReadInt32("D100").Content;
			uint content5 = omronHostLink.ReadUInt32("D100").Content;
			float content6 = omronHostLink.ReadFloat("D100").Content;
			long content7 = omronHostLink.ReadInt64("D100").Content;
			ulong content8 = omronHostLink.ReadUInt64("D100").Content;
			double content9 = omronHostLink.ReadDouble("D100").Content;
			string content10 = omronHostLink.ReadString("D100", 5).Content;
			omronHostLink.Write("D100", (short)51);
			omronHostLink.Write("D100", (short)12345);
			omronHostLink.Write("D100", (ushort)45678);
			omronHostLink.Write("D100", 3456789123u);
			omronHostLink.Write("D100", 123.456f);
			omronHostLink.Write("D100", 1234556434534545L);
			omronHostLink.Write("D100", 523434234234343uL);
			omronHostLink.Write("D100", 123.456);
			omronHostLink.Write("D100", "K123456789");
			OperateResult<byte[]> operateResult = omronHostLink.Read("D100", 5);
			if (operateResult.IsSuccess)
			{
				short num = omronHostLink.ByteTransform.TransInt16(operateResult.Content, 0);
				short num2 = omronHostLink.ByteTransform.TransInt16(operateResult.Content, 2);
				short num3 = omronHostLink.ByteTransform.TransInt16(operateResult.Content, 4);
				short num4 = omronHostLink.ByteTransform.TransInt16(operateResult.Content, 6);
				short num5 = omronHostLink.ByteTransform.TransInt16(operateResult.Content, 7);
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox20.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox19.Text);
			element.SetAttributeValue(DemoDeviceList.XmlDataFormat, comboBox1.SelectedIndex);
			element.SetAttributeValue(DemoDeviceList.XmlStation, textBox1.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox20.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox19.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			comboBox1.SelectedIndex = int.Parse(element.Attribute(DemoDeviceList.XmlDataFormat).Value);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlStation).Value;
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = omronHostLink.ReadPlcType();
			if (operateResult.IsSuccess)
			{
				textBox3.Text = "Result：" + operateResult.Content;
			}
			else
			{
				MessageBox.Show("Read Failed：" + operateResult.ToMessageShowString());
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OperateResult<int> operateResult = omronHostLink.ReadPlcMode();
			if (operateResult.IsSuccess)
			{
				textBox3.Text = "Result：" + operateResult.Content.ToString() + Environment.NewLine + ((operateResult.Content == 0) ? "编程模式" : ((operateResult.Content == 1) ? "运行模式" : "监视模式"));
			}
			else
			{
				MessageBox.Show("Read Failed：" + operateResult.ToMessageShowString());
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = omronHostLink.ChangePlcMode((byte)comboBox4.SelectedIndex);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("success");
			}
			else
			{
				MessageBox.Show("failed:" + operateResult.Message);
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
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			textBox19 = new System.Windows.Forms.TextBox();
			label28 = new System.Windows.Forms.Label();
			textBox20 = new System.Windows.Forms.TextBox();
			label29 = new System.Windows.Forms.Label();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label22 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox5 = new System.Windows.Forms.GroupBox();
			comboBox4 = new System.Windows.Forms.ComboBox();
			button5 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
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
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(textBox19);
			panel1.Controls.Add(label28);
			panel1.Controls.Add(textBox20);
			panel1.Controls.Add(label29);
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(label22);
			panel1.Controls.Add(label21);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 59);
			panel1.TabIndex = 0;
			textBox1.Location = new System.Drawing.Point(494, 17);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(31, 23);
			textBox1.TabIndex = 40;
			textBox1.Text = "0";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(443, 20);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(44, 17);
			label1.TabIndex = 39;
			label1.Text = "站号：";
			textBox19.Location = new System.Drawing.Point(243, 17);
			textBox19.Name = "textBox19";
			textBox19.Size = new System.Drawing.Size(53, 23);
			textBox19.TabIndex = 32;
			textBox19.Text = "2000";
			label28.AutoSize = true;
			label28.Location = new System.Drawing.Point(195, 20);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(44, 17);
			label28.TabIndex = 31;
			label28.Text = "端口：";
			textBox20.Location = new System.Drawing.Point(63, 17);
			textBox20.Name = "textBox20";
			textBox20.Size = new System.Drawing.Size(109, 23);
			textBox20.TabIndex = 30;
			textBox20.Text = "192.168.0.10";
			label29.AutoSize = true;
			label29.Location = new System.Drawing.Point(9, 20);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(56, 17);
			label29.TabIndex = 29;
			label29.Text = "Ip地址：";
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(317, 17);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(95, 25);
			comboBox1.TabIndex = 14;
			label22.Location = new System.Drawing.Point(849, 4);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(139, 45);
			label22.TabIndex = 7;
			label22.Text = "D100 C100 W100 H100 A100";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(779, 5);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(68, 17);
			label21.TabIndex = 6;
			label21.Text = "地址示例：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(677, 14);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(90, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(570, 14);
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
			panel2.Location = new System.Drawing.Point(3, 97);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 545);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Location = new System.Drawing.Point(3, 3);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(989, 240);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox5.Controls.Add(comboBox4);
			groupBox5.Controls.Add(button5);
			groupBox5.Controls.Add(button4);
			groupBox5.Controls.Add(button3);
			groupBox5.Controls.Add(textBox3);
			groupBox5.Controls.Add(label2);
			groupBox5.Location = new System.Drawing.Point(573, 243);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(419, 297);
			groupBox5.TabIndex = 4;
			groupBox5.TabStop = false;
			groupBox5.Text = "特殊功能测试";
			comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox4.FormattingEnabled = true;
			comboBox4.Location = new System.Drawing.Point(136, 26);
			comboBox4.Name = "comboBox4";
			comboBox4.Size = new System.Drawing.Size(157, 25);
			comboBox4.TabIndex = 21;
			button5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button5.Location = new System.Drawing.Point(299, 24);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(101, 28);
			button5.TabIndex = 20;
			button5.Text = "Set Mode";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			button4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button4.Location = new System.Drawing.Point(6, 57);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(101, 28);
			button4.TabIndex = 19;
			button4.Text = "Read Mode";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button3.Location = new System.Drawing.Point(6, 24);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(101, 28);
			button3.TabIndex = 16;
			button3.Text = "Read Type";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click_1);
			textBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox3.Location = new System.Drawing.Point(41, 131);
			textBox3.Multiline = true;
			textBox3.Name = "textBox3";
			textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox3.Size = new System.Drawing.Size(369, 160);
			textBox3.TabIndex = 18;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 131);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 17);
			label2.TabIndex = 17;
			label2.Text = "结果：";
			groupBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox4.Controls.Add(textBox11);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(button26);
			groupBox4.Controls.Add(textBox13);
			groupBox4.Controls.Add(label16);
			groupBox4.Location = new System.Drawing.Point(3, 403);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(564, 137);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "报文读取测试，此处需要填入完整的16进制报文字符串";
			textBox11.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox11.Location = new System.Drawing.Point(63, 60);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox11.Size = new System.Drawing.Size(495, 71);
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
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7469679.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Omron HostLink-CMode OverTcp";
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
			base.Name = "FormOmronHostLinkCModeOverTcp";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "欧姆龙PLC访问Demo";
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
