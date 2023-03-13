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
	public class FormOmron : HslFormContent
	{
		private OmronFinsNet omronFinsNet = null;

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

		private TextBox textBox15;

		private Label label23;

		private TextBox textBox16;

		private Label label24;

		private ComboBox comboBox1;

		private UserControlHead userControlHead1;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private GroupBox groupBox5;

		private TextBox textBox3;

		private Label label2;

		private Label label4;

		private Button button6;

		private Button button5;

		private Button button4;

		private Button button3;

		private TextBox textBox4;

		private CheckBox checkBox_isstringreverse;

		public FormOmron()
		{
			InitializeComponent();
			omronFinsNet = new OmronFinsNet();
			omronFinsNet.ConnectTimeOut = 2000;
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
				label24.Text = "Unit Num";
				label23.Text = "PC Net Num";
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
				label4.Text = "Run Stop Please be cautious and confirm safety as the prerequisite";
				groupBox3.Text = "Batch read test, supports random word addresses, such as D100;A100;C100;H100";
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
				MessageBox.Show("PLC DA2 input wrong！");
			}
			else
			{
				omronFinsNet.IpAddress = textBox1.Text;
				omronFinsNet.Port = result;
				omronFinsNet.DA2 = result2;
				omronFinsNet.ByteTransform.DataFormat = (DataFormat)comboBox1.SelectedItem;
				omronFinsNet.LogNet = base.LogNet;
				omronFinsNet.ByteTransform.IsStringReverseByteWord = checkBox_isstringreverse.Checked;
				OperateResult operateResult = omronFinsNet.ConnectServer();
				if (operateResult.IsSuccess)
				{
					MessageBox.Show(StringResources.Language.ConnectedSuccess);
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
					textBox15.Text = omronFinsNet.SA1.ToString();
					textBox3.Text = omronFinsNet.DA1.ToString();
					userControlReadWriteOp1.SetReadWriteNet(omronFinsNet, "D100", true);
				}
				else
				{
					MessageBox.Show(StringResources.Language.ConnectedFailed + " " + operateResult.ToMessageShowString());
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			omronFinsNet.ConnectClose();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			if (textBox6.Text.Contains(";"))
			{
				OperateResult<byte[]> operateResult = omronFinsNet.Read(textBox6.Text.Split(new char[1]
				{
					';'
				}, StringSplitOptions.None));
				if (operateResult.IsSuccess)
				{
					textBox10.Text = operateResult.Content.ToHexString(' ');
				}
				else
				{
					MessageBox.Show("Read Failed: " + operateResult.Message);
				}
			}
			else
			{
				DemoUtils.BulkReadRenderResult(omronFinsNet, textBox6, textBox9, textBox10);
			}
		}

		private void button26_Click(object sender, EventArgs e)
		{
			OperateResult<byte[]> operateResult = omronFinsNet.ReadFromCoreServer(SoftBasic.HexStringToBytes(textBox13.Text));
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
			element.SetAttributeValue(DemoDeviceList.XmlNetNumber, textBox15.Text);
			element.SetAttributeValue(DemoDeviceList.XmlUnitNumber, textBox16.Text);
			element.SetAttributeValue(DemoDeviceList.XmlDataFormat, comboBox1.SelectedIndex);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox15.Text = element.Attribute(DemoDeviceList.XmlNetNumber).Value;
			textBox16.Text = element.Attribute(DemoDeviceList.XmlUnitNumber).Value;
			comboBox1.SelectedIndex = int.Parse(element.Attribute(DemoDeviceList.XmlDataFormat).Value);
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
		}

		private void test()
		{
			bool content = omronFinsNet.ReadBool("D100.7").Content;
			short content2 = omronFinsNet.ReadInt16("D100").Content;
			ushort content3 = omronFinsNet.ReadUInt16("D100").Content;
			int content4 = omronFinsNet.ReadInt32("D100").Content;
			uint content5 = omronFinsNet.ReadUInt32("D100").Content;
			float content6 = omronFinsNet.ReadFloat("D100").Content;
			long content7 = omronFinsNet.ReadInt64("D100").Content;
			ulong content8 = omronFinsNet.ReadUInt64("D100").Content;
			double content9 = omronFinsNet.ReadDouble("D100").Content;
			string content10 = omronFinsNet.ReadString("D100", 5).Content;
			omronFinsNet.Write("D100", (short)51);
			omronFinsNet.Write("D100", (short)12345);
			omronFinsNet.Write("D100", (ushort)45678);
			omronFinsNet.Write("D100", 3456789123u);
			omronFinsNet.Write("D100", 123.456f);
			omronFinsNet.Write("D100", 1234556434534545L);
			omronFinsNet.Write("D100", 523434234234343uL);
			omronFinsNet.Write("D100", 123.456);
			omronFinsNet.Write("D100", "K123456789");
			OperateResult<byte[]> operateResult = omronFinsNet.Read("D100", 5);
			if (operateResult.IsSuccess)
			{
				short num = omronFinsNet.ByteTransform.TransInt16(operateResult.Content, 0);
				short num2 = omronFinsNet.ByteTransform.TransInt16(operateResult.Content, 2);
				short num3 = omronFinsNet.ByteTransform.TransInt16(operateResult.Content, 4);
				short num4 = omronFinsNet.ByteTransform.TransInt16(operateResult.Content, 6);
				short num5 = omronFinsNet.ByteTransform.TransInt16(operateResult.Content, 7);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = omronFinsNet.Run();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Run success");
			}
			else
			{
				MessageBox.Show("Run failed:" + operateResult.Message);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = omronFinsNet.Stop();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Run success");
			}
			else
			{
				MessageBox.Show("Run failed:" + operateResult.Message);
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			OperateResult<OmronCpuUnitData> operateResult = omronFinsNet.ReadCpuUnitData();
			if (operateResult.IsSuccess)
			{
				textBox4.Text = operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("read failed:" + operateResult.Message);
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			OperateResult<OmronCpuUnitStatus> operateResult = omronFinsNet.ReadCpuUnitStatus();
			if (operateResult.IsSuccess)
			{
				textBox4.Text = operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("read failed:" + operateResult.Message);
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
			checkBox_isstringreverse = new System.Windows.Forms.CheckBox();
			textBox3 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			comboBox1 = new System.Windows.Forms.ComboBox();
			textBox16 = new System.Windows.Forms.TextBox();
			label24 = new System.Windows.Forms.Label();
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
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox5 = new System.Windows.Forms.GroupBox();
			label4 = new System.Windows.Forms.Label();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
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
			panel1.Controls.Add(checkBox_isstringreverse);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(textBox16);
			panel1.Controls.Add(label24);
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
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1017, 60);
			panel1.TabIndex = 0;
			checkBox_isstringreverse.AutoSize = true;
			checkBox_isstringreverse.Checked = true;
			checkBox_isstringreverse.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox_isstringreverse.Location = new System.Drawing.Point(583, 35);
			checkBox_isstringreverse.Name = "checkBox_isstringreverse";
			checkBox_isstringreverse.Size = new System.Drawing.Size(127, 21);
			checkBox_isstringreverse.TabIndex = 17;
			checkBox_isstringreverse.Text = "Is string reverse?";
			checkBox_isstringreverse.UseVisualStyleBackColor = true;
			textBox3.Location = new System.Drawing.Point(515, 32);
			textBox3.Name = "textBox3";
			textBox3.ReadOnly = true;
			textBox3.Size = new System.Drawing.Size(45, 23);
			textBox3.TabIndex = 16;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(468, 35);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 17);
			label2.TabIndex = 15;
			label2.Text = "DA1：";
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(483, 4);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(80, 25);
			comboBox1.TabIndex = 14;
			textBox16.Location = new System.Drawing.Point(421, 5);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(56, 23);
			textBox16.TabIndex = 11;
			textBox16.Text = "0";
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(345, 8);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(77, 17);
			label24.TabIndex = 10;
			label24.Text = "PLC单元号：";
			textBox15.Location = new System.Drawing.Point(392, 32);
			textBox15.Name = "textBox15";
			textBox15.ReadOnly = true;
			textBox15.Size = new System.Drawing.Size(45, 23);
			textBox15.TabIndex = 9;
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(345, 35);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(42, 17);
			label23.TabIndex = 8;
			label23.Text = "SA1：";
			label22.Location = new System.Drawing.Point(834, 7);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(158, 45);
			label22.TabIndex = 7;
			label22.Text = "D100 C100 W100 H100 A100 DR0   E1.0";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(774, 5);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(68, 17);
			label21.TabIndex = 6;
			label21.Text = "地址示例：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(657, 3);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(75, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(582, 3);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(69, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(270, 16);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(69, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "9600";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(216, 19);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 16);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(148, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "192.168.0.100";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 19);
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
			panel2.Location = new System.Drawing.Point(3, 97);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(1017, 558);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Location = new System.Drawing.Point(3, 3);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(1009, 240);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox5.Controls.Add(label4);
			groupBox5.Controls.Add(button6);
			groupBox5.Controls.Add(button5);
			groupBox5.Controls.Add(button4);
			groupBox5.Controls.Add(button3);
			groupBox5.Controls.Add(textBox4);
			groupBox5.Location = new System.Drawing.Point(593, 243);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(419, 297);
			groupBox5.TabIndex = 4;
			groupBox5.TabStop = false;
			groupBox5.Text = "特殊功能测试";
			label4.AutoSize = true;
			label4.ForeColor = System.Drawing.Color.Red;
			label4.Location = new System.Drawing.Point(7, 56);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(221, 17);
			label4.TabIndex = 16;
			label4.Text = "Run Stop 请谨慎操作，确认安全为前提";
			button6.Location = new System.Drawing.Point(274, 22);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(104, 28);
			button6.TabIndex = 15;
			button6.Text = "Cpu Status";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button5.Location = new System.Drawing.Point(164, 22);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(104, 28);
			button5.TabIndex = 14;
			button5.Text = "Cpu Data";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			button4.Location = new System.Drawing.Point(85, 22);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(73, 28);
			button4.TabIndex = 13;
			button4.Text = "Stop";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button3.Location = new System.Drawing.Point(6, 22);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(73, 28);
			button3.TabIndex = 12;
			button3.Text = "Run";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox4.Location = new System.Drawing.Point(6, 80);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox4.Size = new System.Drawing.Size(407, 211);
			textBox4.TabIndex = 11;
			groupBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox4.Controls.Add(textBox11);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(button26);
			groupBox4.Controls.Add(textBox13);
			groupBox4.Controls.Add(label16);
			groupBox4.Location = new System.Drawing.Point(3, 403);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(584, 137);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "报文读取测试，此处需要填入完整的16进制报文字符串";
			textBox11.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox11.Location = new System.Drawing.Point(63, 60);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox11.Size = new System.Drawing.Size(515, 71);
			textBox11.TabIndex = 10;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(9, 62);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 9;
			label14.Text = "结果：";
			button26.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button26.Location = new System.Drawing.Point(496, 24);
			button26.Name = "button26";
			button26.Size = new System.Drawing.Size(82, 28);
			button26.TabIndex = 8;
			button26.Text = "报文读取";
			button26.UseVisualStyleBackColor = true;
			button26.Click += new System.EventHandler(button26_Click);
			textBox13.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox13.Location = new System.Drawing.Point(63, 27);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(427, 23);
			textBox13.TabIndex = 5;
			textBox13.Text = "01 01 B1 00 0A 00 00 01";
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
			groupBox3.Size = new System.Drawing.Size(584, 154);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试，支持随机字地址，例如 D100;A100;C100;H100";
			textBox10.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox10.Location = new System.Drawing.Point(63, 60);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(515, 88);
			textBox10.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 62);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "结果：";
			button25.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button25.Location = new System.Drawing.Point(496, 24);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(82, 28);
			button25.TabIndex = 8;
			button25.Text = "批量读取";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			textBox9.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			textBox9.Location = new System.Drawing.Point(380, 27);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(102, 23);
			textBox9.TabIndex = 7;
			textBox9.Text = "10";
			label12.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(326, 30);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(44, 17);
			label12.TabIndex = 6;
			label12.Text = "长度：";
			textBox6.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox6.Location = new System.Drawing.Point(63, 27);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(257, 23);
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
			userControlHead1.ProtocolInfo = "Fins-Tcp";
			userControlHead1.Size = new System.Drawing.Size(1024, 32);
			userControlHead1.SupportListVisiable = true;
			userControlHead1.TabIndex = 2;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1024, 658);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormOmron";
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
