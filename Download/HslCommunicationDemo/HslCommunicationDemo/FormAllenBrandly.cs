using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Profinet.AllenBradley;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormAllenBrandly : HslFormContent
	{
		private AllenBradleyNet allenBradleyNet = null;

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

		private TextBox textBox9;

		private Label label12;

		private TextBox textBox15;

		private Label label23;

		private UserControlHead userControlHead1;

		private TextBox textBox12;

		private Label label2;

		private Button button3;

		private TextBox textBox16;

		private Label label4;

		private Button button4;

		private GroupBox groupBox5;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private Label label6;

		private Button button5;

		private TextBox textBox3;

		private Label label5;

		private TextBox textBox4;

		private Label label7;

		private TextBox textBox_router;

		private Label label8;

		private Label label9;

		private Button button_type_read;

		private Button button_read_plc_type;

		private TextBox textBox_type_length;

		private Label label10;

		private TextBox textBox_type_data;

		private Label label15;

		private TextBox textBox_type_code;

		private Label label17;

		private Button button_type_write;

		private TextBox textBox_type_address;

		private Label label18;

		private GroupBox groupBox1;

		public FormAllenBrandly()
		{
			InitializeComponent();
			allenBradleyNet = new AllenBradleyNet("192.168.0.110");
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
				Text = "AllenBrandly Read PLC Demo";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label11.Text = "Address:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				label16.Text = "Message:";
				label14.Text = "Results:";
				button26.Text = "Read";
				button3.Text = "Build";
				label2.Text = "Start:";
				groupBox3.Text = "Bulk Read test";
				groupBox4.Text = "CIP reading test, hex string needs to be filled in";
				groupBox5.Text = "Special function test";
				label22.Text = "Tag name, if the bool array is of type int, access begin with \"i=\"";
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
				allenBradleyNet.IpAddress = textBox1.Text;
				allenBradleyNet.Port = result;
				allenBradleyNet.Slot = result2;
				allenBradleyNet.LogNet = base.LogNet;
				if (!string.IsNullOrEmpty(textBox_router.Text))
				{
					allenBradleyNet.MessageRouter = new MessageRouter(textBox_router.Text);
				}
				try
				{
					OperateResult operateResult = allenBradleyNet.ConnectServer();
					if (operateResult.IsSuccess)
					{
						MessageBox.Show(StringResources.Language.ConnectedSuccess);
						button2.Enabled = true;
						button1.Enabled = false;
						panel2.Enabled = true;
						userControlReadWriteOp1.SetReadWriteNet(allenBradleyNet, "A1", true, 1);
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
			allenBradleyNet.ConnectClose();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			try
			{
				OperateResult<byte[]> operateResult = null;
				operateResult = (textBox6.Text.Contains(";") ? allenBradleyNet.Read(textBox6.Text.Split(';')) : allenBradleyNet.ReadSegment(textBox6.Text, ushort.Parse(textBox12.Text), ushort.Parse(textBox9.Text)));
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
			OperateResult<byte[]> operateResult = allenBradleyNet.ReadCipFromServer(SoftBasic.HexStringToBytes(textBox13.Text));
			if (operateResult.IsSuccess)
			{
				textBox11.Text = "Result：" + SoftBasic.ByteToHexString(operateResult.Content, ' ');
			}
			else
			{
				MessageBox.Show("Read failed：" + operateResult.ToMessageShowString());
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OperateResult<byte[]> operateResult = allenBradleyNet.ReadEipFromServer(SoftBasic.HexStringToBytes(textBox13.Text));
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
			try
			{
				byte[] inBytes = AllenBradleyHelper.PackRequestReadSegment(textBox6.Text, ushort.Parse(textBox12.Text), ushort.Parse(textBox9.Text));
				textBox10.Text = "Result：" + SoftBasic.ByteToHexString(inBytes, ' ');
			}
			catch (Exception ex)
			{
				MessageBox.Show("Build failed：" + ex.Message);
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			OperateResult<bool[]> operateResult = allenBradleyNet.ReadBoolArray(textBox3.Text);
			if (operateResult.IsSuccess)
			{
				textBox4.Text = string.Format("Result[{0:HH:mm:ss}]：", DateTime.Now) + SoftBasic.ArrayFormat(operateResult.Content);
			}
			else
			{
				MessageBox.Show("Read failed：" + operateResult.ToMessageShowString());
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

		private void button_type_read_Click(object sender, EventArgs e)
		{
			try
			{
				OperateResult<ushort, byte[]> operateResult = allenBradleyNet.ReadTag(textBox_type_address.Text, ushort.Parse(textBox_type_length.Text));
				if (operateResult.IsSuccess)
				{
					textBox_type_code.Text = operateResult.Content1.ToString("X2");
					textBox_type_data.Text = operateResult.Content2.ToHexString(' ');
				}
				else
				{
					MessageBox.Show("read failed：" + operateResult.Message);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("read failed：" + ex.Message);
			}
		}

		private void button_type_write_Click(object sender, EventArgs e)
		{
			try
			{
				OperateResult result = allenBradleyNet.WriteTag(textBox_type_address.Text, Convert.ToUInt16(textBox_type_code.Text, 16), textBox_type_data.Text.ToHexBytes(), int.Parse(textBox_type_length.Text));
				DemoUtils.WriteResultRender(result, textBox_type_address.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show("write failed：" + ex.Message);
			}
		}

		private void button_read_plc_type_Click(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = allenBradleyNet.ReadPlcType();
			if (operateResult.IsSuccess)
			{
				textBox_type_data.Text = operateResult.Content;
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
			label8 = new System.Windows.Forms.Label();
			textBox_router = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			label9 = new System.Windows.Forms.Label();
			textBox16 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			label23 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox5 = new System.Windows.Forms.GroupBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			button_type_read = new System.Windows.Forms.Button();
			button_read_plc_type = new System.Windows.Forms.Button();
			textBox_type_length = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			textBox_type_data = new System.Windows.Forms.TextBox();
			label15 = new System.Windows.Forms.Label();
			textBox_type_code = new System.Windows.Forms.TextBox();
			label17 = new System.Windows.Forms.Label();
			button_type_write = new System.Windows.Forms.Button();
			textBox_type_address = new System.Windows.Forms.TextBox();
			label18 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			button5 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			groupBox4 = new System.Windows.Forms.GroupBox();
			button4 = new System.Windows.Forms.Button();
			textBox11 = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			button26 = new System.Windows.Forms.Button();
			textBox13 = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			button3 = new System.Windows.Forms.Button();
			textBox12 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
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
			groupBox5.SuspendLayout();
			groupBox4.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox15);
			panel1.Controls.Add(label8);
			panel1.Controls.Add(textBox_router);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(label9);
			panel1.Controls.Add(textBox16);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label23);
			panel1.Controls.Add(label22);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(993, 56);
			panel1.TabIndex = 0;
			textBox15.Location = new System.Drawing.Point(373, 13);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(32, 23);
			textBox15.TabIndex = 9;
			textBox15.Text = "0";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(411, 16);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(47, 17);
			label8.TabIndex = 12;
			label8.Text = "Router";
			textBox_router.Location = new System.Drawing.Point(469, 13);
			textBox_router.Name = "textBox_router";
			textBox_router.Size = new System.Drawing.Size(134, 23);
			textBox_router.TabIndex = 13;
			button1.Location = new System.Drawing.Point(609, 10);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(63, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			label9.AutoSize = true;
			label9.ForeColor = System.Drawing.Color.DarkGray;
			label9.Location = new System.Drawing.Point(401, 36);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(220, 17);
			label9.TabIndex = 14;
			label9.Text = "if use router, example: 1.15.2.18.1.12";
			textBox16.Location = new System.Drawing.Point(853, 30);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(134, 23);
			textBox16.TabIndex = 11;
			textBox16.Visible = false;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(795, 33);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(54, 17);
			label4.TabIndex = 10;
			label4.Text = "PortSlot";
			label4.Visible = false;
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(329, 16);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(41, 17);
			label23.TabIndex = 8;
			label23.Text = "slot：";
			label22.Location = new System.Drawing.Point(760, -1);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(232, 45);
			label22.TabIndex = 7;
			label22.Text = "变量的标签名，bool数组如果是int类型，则带i=开头访问";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(678, 10);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(76, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			textBox2.Location = new System.Drawing.Point(269, 13);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(52, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "44818";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(215, 16);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 13);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(141, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "192.168.0.100";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 16);
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
			panel2.Location = new System.Drawing.Point(3, 94);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(993, 554);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Location = new System.Drawing.Point(3, 3);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(985, 240);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox5.Controls.Add(groupBox1);
			groupBox5.Controls.Add(button_type_read);
			groupBox5.Controls.Add(button_read_plc_type);
			groupBox5.Controls.Add(textBox_type_length);
			groupBox5.Controls.Add(label10);
			groupBox5.Controls.Add(textBox_type_data);
			groupBox5.Controls.Add(label15);
			groupBox5.Controls.Add(textBox_type_code);
			groupBox5.Controls.Add(label17);
			groupBox5.Controls.Add(button_type_write);
			groupBox5.Controls.Add(textBox_type_address);
			groupBox5.Controls.Add(label18);
			groupBox5.Controls.Add(textBox4);
			groupBox5.Controls.Add(label7);
			groupBox5.Controls.Add(label6);
			groupBox5.Controls.Add(button5);
			groupBox5.Controls.Add(textBox3);
			groupBox5.Controls.Add(label5);
			groupBox5.Location = new System.Drawing.Point(563, 243);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(419, 300);
			groupBox5.TabIndex = 4;
			groupBox5.TabStop = false;
			groupBox5.Text = "特殊功能测试";
			groupBox1.Location = new System.Drawing.Point(6, 117);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(410, 11);
			groupBox1.TabIndex = 38;
			groupBox1.TabStop = false;
			button_type_read.Location = new System.Drawing.Point(177, 268);
			button_type_read.Name = "button_type_read";
			button_type_read.Size = new System.Drawing.Size(105, 28);
			button_type_read.TabIndex = 37;
			button_type_read.Text = "读取";
			button_type_read.UseVisualStyleBackColor = true;
			button_type_read.Click += new System.EventHandler(button_type_read_Click);
			button_read_plc_type.Location = new System.Drawing.Point(286, 268);
			button_read_plc_type.Name = "button_read_plc_type";
			button_read_plc_type.Size = new System.Drawing.Size(127, 28);
			button_read_plc_type.TabIndex = 36;
			button_read_plc_type.Text = "PLC 型号";
			button_read_plc_type.UseVisualStyleBackColor = true;
			button_read_plc_type.Click += new System.EventHandler(button_read_plc_type_Click);
			textBox_type_length.Location = new System.Drawing.Point(275, 163);
			textBox_type_length.Name = "textBox_type_length";
			textBox_type_length.Size = new System.Drawing.Size(138, 23);
			textBox_type_length.TabIndex = 35;
			textBox_type_length.Text = "1";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(221, 166);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(44, 17);
			label10.TabIndex = 34;
			label10.Text = "长度：";
			textBox_type_data.Location = new System.Drawing.Point(60, 193);
			textBox_type_data.Multiline = true;
			textBox_type_data.Name = "textBox_type_data";
			textBox_type_data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_type_data.Size = new System.Drawing.Size(353, 72);
			textBox_type_data.TabIndex = 33;
			textBox_type_data.Text = "64";
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(6, 196);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(44, 17);
			label15.TabIndex = 32;
			label15.Text = "数据：";
			textBox_type_code.Location = new System.Drawing.Point(60, 163);
			textBox_type_code.Name = "textBox_type_code";
			textBox_type_code.Size = new System.Drawing.Size(155, 23);
			textBox_type_code.TabIndex = 31;
			textBox_type_code.Text = "C1";
			label17.AutoSize = true;
			label17.Location = new System.Drawing.Point(6, 166);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(44, 17);
			label17.TabIndex = 30;
			label17.Text = "类型：";
			button_type_write.Location = new System.Drawing.Point(60, 268);
			button_type_write.Name = "button_type_write";
			button_type_write.Size = new System.Drawing.Size(111, 28);
			button_type_write.TabIndex = 29;
			button_type_write.Text = "写入";
			button_type_write.UseVisualStyleBackColor = true;
			button_type_write.Click += new System.EventHandler(button_type_write_Click);
			textBox_type_address.Location = new System.Drawing.Point(60, 134);
			textBox_type_address.Name = "textBox_type_address";
			textBox_type_address.Size = new System.Drawing.Size(353, 23);
			textBox_type_address.TabIndex = 28;
			textBox_type_address.Text = "A1";
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(6, 137);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(44, 17);
			label18.TabIndex = 27;
			label18.Text = "地址：";
			textBox4.Location = new System.Drawing.Point(60, 64);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox4.Size = new System.Drawing.Size(353, 52);
			textBox4.TabIndex = 14;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(6, 67);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(44, 17);
			label7.TabIndex = 13;
			label7.Text = "结果：";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(6, 16);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(255, 17);
			label6.TabIndex = 12;
			label6.Text = "批量读取bool的方法，调用：ReadBoolArray";
			button5.Location = new System.Drawing.Point(309, 35);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(104, 28);
			button5.TabIndex = 11;
			button5.Text = "读取";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			textBox3.Location = new System.Drawing.Point(60, 37);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(243, 23);
			textBox3.TabIndex = 10;
			textBox3.Text = "A1";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(6, 40);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(44, 17);
			label5.TabIndex = 9;
			label5.Text = "地址：";
			groupBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox4.Controls.Add(button4);
			groupBox4.Controls.Add(textBox11);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(button26);
			groupBox4.Controls.Add(textBox13);
			groupBox4.Controls.Add(label16);
			groupBox4.Location = new System.Drawing.Point(3, 399);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(554, 145);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "CIP报文读取测试，此处需要填入完整的16进制报文字符串";
			button4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button4.Location = new System.Drawing.Point(499, 24);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(48, 28);
			button4.TabIndex = 11;
			button4.Text = "eip";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			textBox11.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox11.Location = new System.Drawing.Point(63, 60);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox11.Size = new System.Drawing.Size(483, 79);
			textBox11.TabIndex = 10;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(9, 62);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 9;
			label14.Text = "结果：";
			button26.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button26.Location = new System.Drawing.Point(445, 24);
			button26.Name = "button26";
			button26.Size = new System.Drawing.Size(48, 28);
			button26.TabIndex = 8;
			button26.Text = "cip";
			button26.UseVisualStyleBackColor = true;
			button26.Click += new System.EventHandler(button26_Click);
			textBox13.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox13.Location = new System.Drawing.Point(63, 27);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(376, 23);
			textBox13.TabIndex = 5;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(9, 30);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(44, 17);
			label16.TabIndex = 4;
			label16.Text = "报文：";
			groupBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox3.Controls.Add(button3);
			groupBox3.Controls.Add(textBox12);
			groupBox3.Controls.Add(label2);
			groupBox3.Controls.Add(textBox9);
			groupBox3.Controls.Add(label12);
			groupBox3.Controls.Add(textBox10);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(button25);
			groupBox3.Controls.Add(textBox6);
			groupBox3.Controls.Add(label11);
			groupBox3.Location = new System.Drawing.Point(3, 243);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(554, 154);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试，分号间隔";
			button3.Location = new System.Drawing.Point(470, 24);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(82, 28);
			button3.TabIndex = 15;
			button3.Text = "报文生成";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(Button3_Click);
			textBox12.Location = new System.Drawing.Point(241, 27);
			textBox12.Name = "textBox12";
			textBox12.Size = new System.Drawing.Size(51, 23);
			textBox12.TabIndex = 14;
			textBox12.Text = "0";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(190, 30);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 17);
			label2.TabIndex = 13;
			label2.Text = "起始：";
			textBox9.Location = new System.Drawing.Point(354, 27);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(47, 23);
			textBox9.TabIndex = 12;
			textBox9.Text = "1";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(300, 30);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(44, 17);
			label12.TabIndex = 11;
			label12.Text = "长度：";
			textBox10.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox10.Location = new System.Drawing.Point(63, 60);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(483, 88);
			textBox10.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 62);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "结果：";
			button25.Location = new System.Drawing.Point(405, 24);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(62, 28);
			button25.TabIndex = 8;
			button25.Text = "读取";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			textBox6.Location = new System.Drawing.Point(63, 27);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(121, 23);
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
			userControlHead1.Size = new System.Drawing.Size(1000, 32);
			userControlHead1.SupportListVisiable = true;
			userControlHead1.TabIndex = 2;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1000, 651);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormAllenBrandly";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "AB PLC访问Demo";
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
