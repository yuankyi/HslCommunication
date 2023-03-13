using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.LogNet;
using HslCommunication.Robot.YASKAWA;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormYRCHighEthernet : HslFormContent
	{
		private YRCHighEthernet YRC1000Tcp = null;

		private IContainer components = null;

		private Panel panel1;

		private Label label1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private GroupBox groupBox2;

		private TextBox textBox7;

		private Label label9;

		private TextBox textBox_command;

		private Label label10;

		private GroupBox groupBox1;

		private TextBox textBox4;

		private Label label7;

		private Label label22;

		private Label label21;

		private UserControlHead userControlHead1;

		private Button button4;

		private Button button3;

		private Button button18;

		private Label label5;

		private Button button17;

		private Button button16;

		private Button button15;

		private Button button13;

		private Label label4;

		private Button button12;

		private Button button11;

		private Button button10;

		private Button button9;

		private Button button8;

		private TextBox textBox5;

		private Label label2;

		private Button button7;

		private Button button6;

		private Button button5;

		private Label label11;

		private ComboBox comboBox1;

		private Button button22;

		private Button button21;

		private Label label12;

		private TextBox textBox_dataHandle;

		private Label label15;

		private TextBox textBox_dataAttribute;

		private Label label14;

		private TextBox textBox_dataAddress;

		private Label label13;

		private Label label16;

		private TextBox textBox_dataPart;

		private Button button14;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private Button button23;

		private Button button24;

		private Button button25;

		private Button button19;

		private TextBox textBox6;

		private Label label8;

		private TextBox textBox3;

		private Label label6;

		private Button button27;

		private Button button26;

		private Button button20;

		private Button button28;

		public FormYRCHighEthernet()
		{
			InitializeComponent();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			comboBox1.DataSource = new string[12]
			{
				"基坐标",
				"机器坐标",
				"用户1",
				"用户2",
				"用户3",
				"用户4",
				"用户5",
				"用户6",
				"用户7",
				"用户8",
				"用户9",
				"用户10"
			};
			comboBox1.SelectedIndex = 0;
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "YASKAWA Robot Demo";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
				label7.Text = "result:";
				label10.Text = "Address:";
				label9.Text = "Value:";
				groupBox1.Text = "Single Data Read test";
				groupBox2.Text = "Single Data Write test";
				label22.Text = "Parameter name of robot";
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
				MessageBox.Show("端口输入格式不正确！");
			}
			else
			{
				YRC1000Tcp = new YRCHighEthernet(textBox1.Text, result);
				YRC1000Tcp.LogNet = new LogNetSingle("");
				try
				{
					MessageBox.Show("打开UDP成功！");
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void LogNet_BeforeSaveToFile(object sender, HslEventArgs e)
		{
			Invoke((Action)delegate
			{
				textBox4.AppendText(e.HslMessage.ToString());
			});
		}

		private void button2_Click(object sender, EventArgs e)
		{
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button14_Click(object sender, EventArgs e)
		{
			OperateResult<int> operateResult = DemoUtils.ParseInt(textBox_command.Text);
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Command input wrong: " + operateResult.Message);
			}
			else
			{
				OperateResult<int> operateResult2 = DemoUtils.ParseInt(textBox_dataAddress.Text);
				if (!operateResult2.IsSuccess)
				{
					MessageBox.Show("Data Address input wrong: " + operateResult2.Message);
				}
				else
				{
					OperateResult<int> operateResult3 = DemoUtils.ParseInt(textBox_dataAttribute.Text);
					if (!operateResult3.IsSuccess)
					{
						MessageBox.Show("单元编号输入错误:" + operateResult3.Message);
					}
					else
					{
						OperateResult<int> operateResult4 = DemoUtils.ParseInt(textBox_dataHandle.Text);
						if (!operateResult4.IsSuccess)
						{
							MessageBox.Show("处理请求输入错误:" + operateResult3.Message);
						}
						else
						{
							byte[] dataPart = string.IsNullOrEmpty(textBox_dataPart.Text) ? new byte[0] : textBox_dataPart.Text.ToHexBytes();
							OperateResult<byte[]> operateResult5 = YRC1000Tcp.ReadCommand((ushort)operateResult.Content, (ushort)operateResult2.Content, (byte)operateResult3.Content, (byte)operateResult4.Content, dataPart);
							if (!operateResult5.IsSuccess)
							{
								MessageBox.Show("Read failed: " + operateResult5.Message);
							}
							else if (radioButton1.Checked)
							{
								textBox7.Text = operateResult5.Content.ToHexString();
							}
							else
							{
								textBox7.Text = SoftBasic.GetAsciiStringRender(operateResult5.Content);
							}
						}
					}
				}
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OperateResult<YRCAlarmItem[]> operateResult = YRC1000Tcp.ReadAlarms();
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OperateResult<string[]> operateResult = YRC1000Tcp.ReadPose();
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			OperateResult<YRCRobotData> operateResult = YRC1000Tcp.ReadPOSC(comboBox1.SelectedIndex, true);
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			OperateResult<bool[]> operateResult = YRC1000Tcp.ReadStats();
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + "[ 0] 单步              " + operateResult.Content[0].ToString() + Environment.NewLine + "[ 1] 1循环             " + operateResult.Content[1].ToString() + Environment.NewLine + "[ 2] 自动连续          " + operateResult.Content[2].ToString() + Environment.NewLine + "[ 3] 运行中            " + operateResult.Content[3].ToString() + Environment.NewLine + "[ 4] 运转中            " + operateResult.Content[4].ToString() + Environment.NewLine + "[ 5] 示教              " + operateResult.Content[5].ToString() + Environment.NewLine + "[ 6] 在线              " + operateResult.Content[6].ToString() + Environment.NewLine + "[ 7] 命令模式          " + operateResult.Content[7].ToString() + Environment.NewLine + "[ 9] 示教编程器HOLD中   " + operateResult.Content[9].ToString() + Environment.NewLine + "[10] 外部HOLD中        " + operateResult.Content[10].ToString() + Environment.NewLine + "[11] 命令HOLD中        " + operateResult.Content[11].ToString() + Environment.NewLine + "[12] 发生警报          " + operateResult.Content[12].ToString() + Environment.NewLine + "[13] 发生错误          " + operateResult.Content[13].ToString() + Environment.NewLine + "[14] 伺服ON            " + operateResult.Content[14].ToString() + Environment.NewLine;
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			OperateResult<string[]> operateResult = YRC1000Tcp.ReadJSeq(1);
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + "程序名: " + operateResult.Content[0] + Environment.NewLine + "行编号: " + operateResult.Content[1] + Environment.NewLine + "步编号: " + operateResult.Content[2] + Environment.NewLine + "速度超出值: " + operateResult.Content[3] + Environment.NewLine;
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			DemoUtils.ReadResultRender(YRC1000Tcp.ReadByteVariable(ushort.Parse(textBox5.Text)), textBox5.Text, textBox4);
		}

		private void button9_Click(object sender, EventArgs e)
		{
			DemoUtils.ReadResultRender(YRC1000Tcp.ReadIntegerVariable(ushort.Parse(textBox5.Text)), textBox5.Text, textBox4);
		}

		private void button10_Click(object sender, EventArgs e)
		{
			DemoUtils.ReadResultRender(YRC1000Tcp.ReadDoubleIntegerVariable(ushort.Parse(textBox5.Text)), textBox5.Text, textBox4);
		}

		private void button11_Click(object sender, EventArgs e)
		{
			DemoUtils.ReadResultRender(YRC1000Tcp.ReadRealVariable(ushort.Parse(textBox5.Text)), textBox5.Text, textBox4);
		}

		private void button12_Click(object sender, EventArgs e)
		{
			DemoUtils.ReadResultRender(YRC1000Tcp.ReadStringVariable(ushort.Parse(textBox5.Text)), textBox5.Text, textBox4);
		}

		private void button19_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(YRC1000Tcp.WriteStringVariable(ushort.Parse(textBox3.Text), textBox6.Text), textBox3.Text);
		}

		private void button20_Click(object sender, EventArgs e)
		{
			try
			{
				DemoUtils.WriteResultRender(YRC1000Tcp.WriteIntegerVariable(ushort.Parse(textBox3.Text), short.Parse(textBox6.Text)), textBox3.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Write Failed: " + ex.Message);
			}
		}

		private void button26_Click(object sender, EventArgs e)
		{
			try
			{
				DemoUtils.WriteResultRender(YRC1000Tcp.WriteDoubleIntegerVariable(ushort.Parse(textBox3.Text), int.Parse(textBox6.Text)), textBox3.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Write Failed: " + ex.Message);
			}
		}

		private void button27_Click(object sender, EventArgs e)
		{
			try
			{
				DemoUtils.WriteResultRender(YRC1000Tcp.WriteRealVariable(ushort.Parse(textBox3.Text), float.Parse(textBox6.Text)), textBox3.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Write Failed: " + ex.Message);
			}
		}

		private void button28_Click(object sender, EventArgs e)
		{
			try
			{
				DemoUtils.WriteResultRender(YRC1000Tcp.WriteByteVariable(ushort.Parse(textBox3.Text), byte.Parse(textBox6.Text)), textBox3.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Write Failed: " + ex.Message);
			}
		}

		private void button13_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = YRC1000Tcp.Hold(true);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("HOLD ON Success");
			}
			else
			{
				MessageBox.Show("HOLD ON Failed: " + operateResult.Message);
			}
		}

		private void button15_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = YRC1000Tcp.Hold(false);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("HOLD OFF Success");
			}
			else
			{
				MessageBox.Show("HOLD OFF Failed: " + operateResult.Message);
			}
		}

		private void button16_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = YRC1000Tcp.Reset();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("RESET Success");
			}
			else
			{
				MessageBox.Show("RESET Failed: " + operateResult.Message);
			}
		}

		private void button17_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = YRC1000Tcp.Cancel();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Cancel Success");
			}
			else
			{
				MessageBox.Show("Cancel Failed: " + operateResult.Message);
			}
		}

		private void button21_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = YRC1000Tcp.Svon(true);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("SVON ON Success");
			}
			else
			{
				MessageBox.Show("SVON ON Failed: " + operateResult.Message);
			}
		}

		private void button22_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = YRC1000Tcp.Svon(false);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("SVON OFF Success");
			}
			else
			{
				MessageBox.Show("SVON OFF Failed: " + operateResult.Message);
			}
		}

		private void button18_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = YRC1000Tcp.Start();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Start Success");
			}
			else
			{
				MessageBox.Show("Start Failed: " + operateResult.Message);
			}
		}

		private void button23_Click(object sender, EventArgs e)
		{
			OperateResult<DateTime> operateResult = YRC1000Tcp.ReadManagementTime(1);
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + operateResult.Content.ToString();
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button24_Click(object sender, EventArgs e)
		{
			OperateResult<DateTime> operateResult = YRC1000Tcp.ReadManagementTime(10);
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + operateResult.Content.ToString();
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button25_Click(object sender, EventArgs e)
		{
			OperateResult<DateTime> operateResult = YRC1000Tcp.ReadManagementTime(210);
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + operateResult.Content.ToString();
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
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
			label22 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			groupBox2 = new System.Windows.Forms.GroupBox();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton1 = new System.Windows.Forms.RadioButton();
			button14 = new System.Windows.Forms.Button();
			textBox_dataPart = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			textBox_dataHandle = new System.Windows.Forms.TextBox();
			label15 = new System.Windows.Forms.Label();
			textBox_dataAttribute = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			textBox_dataAddress = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			textBox7 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			textBox_command = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			button27 = new System.Windows.Forms.Button();
			button26 = new System.Windows.Forms.Button();
			button20 = new System.Windows.Forms.Button();
			button19 = new System.Windows.Forms.Button();
			textBox6 = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			button25 = new System.Windows.Forms.Button();
			button24 = new System.Windows.Forms.Button();
			button23 = new System.Windows.Forms.Button();
			button22 = new System.Windows.Forms.Button();
			button21 = new System.Windows.Forms.Button();
			comboBox1 = new System.Windows.Forms.ComboBox();
			button18 = new System.Windows.Forms.Button();
			label5 = new System.Windows.Forms.Label();
			button17 = new System.Windows.Forms.Button();
			button16 = new System.Windows.Forms.Button();
			button15 = new System.Windows.Forms.Button();
			button13 = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			button12 = new System.Windows.Forms.Button();
			button11 = new System.Windows.Forms.Button();
			button10 = new System.Windows.Forms.Button();
			button9 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			textBox5 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			button7 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			button28 = new System.Windows.Forms.Button();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
			panel1.Size = new System.Drawing.Size(997, 42);
			panel1.TabIndex = 0;
			label22.Location = new System.Drawing.Point(651, 0);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(341, 45);
			label22.TabIndex = 7;
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(581, 0);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(80, 17);
			label21.TabIndex = 6;
			label21.Text = "自定义示例：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(468, 6);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(368, 6);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(272, 9);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(83, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "10040";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(218, 12);
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
			panel2.Controls.Add(groupBox2);
			panel2.Controls.Add(groupBox1);
			panel2.Location = new System.Drawing.Point(3, 80);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 563);
			panel2.TabIndex = 1;
			groupBox2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			groupBox2.Controls.Add(radioButton2);
			groupBox2.Controls.Add(radioButton1);
			groupBox2.Controls.Add(button14);
			groupBox2.Controls.Add(textBox_dataPart);
			groupBox2.Controls.Add(label16);
			groupBox2.Controls.Add(textBox_dataHandle);
			groupBox2.Controls.Add(label15);
			groupBox2.Controls.Add(textBox_dataAttribute);
			groupBox2.Controls.Add(label14);
			groupBox2.Controls.Add(textBox_dataAddress);
			groupBox2.Controls.Add(label13);
			groupBox2.Controls.Add(label12);
			groupBox2.Controls.Add(textBox7);
			groupBox2.Controls.Add(label9);
			groupBox2.Controls.Add(textBox_command);
			groupBox2.Controls.Add(label10);
			groupBox2.Location = new System.Drawing.Point(653, 2);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(339, 556);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "详细命令测试";
			radioButton2.AutoSize = true;
			radioButton2.Location = new System.Drawing.Point(117, 250);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(57, 21);
			radioButton2.TabIndex = 17;
			radioButton2.Text = "ASCII";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton1.AutoSize = true;
			radioButton1.Checked = true;
			radioButton1.Location = new System.Drawing.Point(63, 250);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(48, 21);
			radioButton1.TabIndex = 16;
			radioButton1.TabStop = true;
			radioButton1.Text = "Hex";
			radioButton1.UseVisualStyleBackColor = true;
			button14.Location = new System.Drawing.Point(260, 63);
			button14.Name = "button14";
			button14.Size = new System.Drawing.Size(75, 67);
			button14.TabIndex = 15;
			button14.Text = "Read";
			button14.UseVisualStyleBackColor = true;
			button14.Click += new System.EventHandler(button14_Click);
			textBox_dataPart.Location = new System.Drawing.Point(83, 136);
			textBox_dataPart.Multiline = true;
			textBox_dataPart.Name = "textBox_dataPart";
			textBox_dataPart.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_dataPart.Size = new System.Drawing.Size(250, 107);
			textBox_dataPart.TabIndex = 14;
			label16.Location = new System.Drawing.Point(9, 139);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(68, 68);
			label16.TabIndex = 13;
			label16.Text = "附加数据：\r\n(16进制字符串)";
			textBox_dataHandle.Location = new System.Drawing.Point(101, 108);
			textBox_dataHandle.Name = "textBox_dataHandle";
			textBox_dataHandle.Size = new System.Drawing.Size(151, 23);
			textBox_dataHandle.TabIndex = 12;
			textBox_dataHandle.Text = "0x01";
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(9, 111);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(76, 17);
			label15.TabIndex = 11;
			label15.Text = "处理(请求)：";
			textBox_dataAttribute.Location = new System.Drawing.Point(101, 81);
			textBox_dataAttribute.Name = "textBox_dataAttribute";
			textBox_dataAttribute.Size = new System.Drawing.Size(151, 23);
			textBox_dataAttribute.TabIndex = 10;
			textBox_dataAttribute.Text = "0";
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(9, 84);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(68, 17);
			label14.TabIndex = 9;
			label14.Text = "单元编号：";
			textBox_dataAddress.Location = new System.Drawing.Point(101, 54);
			textBox_dataAddress.Name = "textBox_dataAddress";
			textBox_dataAddress.Size = new System.Drawing.Size(151, 23);
			textBox_dataAddress.TabIndex = 8;
			textBox_dataAddress.Text = "11";
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 57);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(92, 17);
			label13.TabIndex = 7;
			label13.Text = "数据队列编号：";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(268, 31);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(46, 17);
			label12.TabIndex = 6;
			label12.Text = "16进制";
			textBox7.Location = new System.Drawing.Point(63, 277);
			textBox7.Multiline = true;
			textBox7.Name = "textBox7";
			textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox7.Size = new System.Drawing.Size(270, 273);
			textBox7.TabIndex = 5;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(9, 252);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(32, 17);
			label9.TabIndex = 4;
			label9.Text = "值：";
			textBox_command.Location = new System.Drawing.Point(101, 27);
			textBox_command.Name = "textBox_command";
			textBox_command.Size = new System.Drawing.Size(151, 23);
			textBox_command.TabIndex = 3;
			textBox_command.Text = "0x89";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(9, 30);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(68, 17);
			label10.TabIndex = 2;
			label10.Text = "命令编号：";
			groupBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox1.Controls.Add(button28);
			groupBox1.Controls.Add(button27);
			groupBox1.Controls.Add(button26);
			groupBox1.Controls.Add(button20);
			groupBox1.Controls.Add(button19);
			groupBox1.Controls.Add(textBox6);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(textBox3);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(button25);
			groupBox1.Controls.Add(button24);
			groupBox1.Controls.Add(button23);
			groupBox1.Controls.Add(button22);
			groupBox1.Controls.Add(button21);
			groupBox1.Controls.Add(comboBox1);
			groupBox1.Controls.Add(button18);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(button17);
			groupBox1.Controls.Add(button16);
			groupBox1.Controls.Add(button15);
			groupBox1.Controls.Add(button13);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(button12);
			groupBox1.Controls.Add(button11);
			groupBox1.Controls.Add(button10);
			groupBox1.Controls.Add(button9);
			groupBox1.Controls.Add(button8);
			groupBox1.Controls.Add(textBox5);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(button7);
			groupBox1.Controls.Add(button6);
			groupBox1.Controls.Add(button5);
			groupBox1.Controls.Add(button4);
			groupBox1.Controls.Add(button3);
			groupBox1.Controls.Add(textBox4);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(label11);
			groupBox1.Location = new System.Drawing.Point(4, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(643, 555);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "单数据读取测试";
			button27.Location = new System.Drawing.Point(565, 146);
			button27.Name = "button27";
			button27.Size = new System.Drawing.Size(69, 28);
			button27.TabIndex = 54;
			button27.Text = "实数写入";
			button27.UseVisualStyleBackColor = true;
			button27.Click += new System.EventHandler(button27_Click);
			button26.Location = new System.Drawing.Point(485, 146);
			button26.Name = "button26";
			button26.Size = new System.Drawing.Size(76, 28);
			button26.TabIndex = 53;
			button26.Text = "双整型写入";
			button26.UseVisualStyleBackColor = true;
			button26.Click += new System.EventHandler(button26_Click);
			button20.Location = new System.Drawing.Point(409, 146);
			button20.Name = "button20";
			button20.Size = new System.Drawing.Size(73, 28);
			button20.TabIndex = 52;
			button20.Text = "整型写入";
			button20.UseVisualStyleBackColor = true;
			button20.Click += new System.EventHandler(button20_Click);
			button19.Location = new System.Drawing.Point(320, 146);
			button19.Name = "button19";
			button19.Size = new System.Drawing.Size(86, 28);
			button19.TabIndex = 51;
			button19.Text = "字符串写入";
			button19.UseVisualStyleBackColor = true;
			button19.Click += new System.EventHandler(button19_Click);
			textBox6.Location = new System.Drawing.Point(193, 149);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(121, 23);
			textBox6.TabIndex = 50;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(134, 152);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(56, 17);
			label8.TabIndex = 49;
			label8.Text = "变量值：";
			textBox3.Location = new System.Drawing.Point(67, 149);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(61, 23);
			textBox3.TabIndex = 48;
			textBox3.Text = "000";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(5, 152);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(68, 17);
			label6.TabIndex = 47;
			label6.Text = "变量地址：";
			button25.Location = new System.Drawing.Point(344, 116);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(95, 28);
			button25.TabIndex = 46;
			button25.Text = "动作时间";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			button24.Location = new System.Drawing.Point(205, 116);
			button24.Name = "button24";
			button24.Size = new System.Drawing.Size(133, 28);
			button24.TabIndex = 45;
			button24.Text = "伺服电源接通时间";
			button24.UseVisualStyleBackColor = true;
			button24.Click += new System.EventHandler(button24_Click);
			button23.Location = new System.Drawing.Point(66, 116);
			button23.Name = "button23";
			button23.Size = new System.Drawing.Size(133, 28);
			button23.TabIndex = 44;
			button23.Text = "控制电源接通时间";
			button23.UseVisualStyleBackColor = true;
			button23.Click += new System.EventHandler(button23_Click);
			button22.Location = new System.Drawing.Point(478, 84);
			button22.Name = "button22";
			button22.Size = new System.Drawing.Size(80, 28);
			button22.TabIndex = 43;
			button22.Text = "Svon OFF";
			button22.UseVisualStyleBackColor = true;
			button22.Click += new System.EventHandler(button22_Click);
			button21.Location = new System.Drawing.Point(392, 84);
			button21.Name = "button21";
			button21.Size = new System.Drawing.Size(80, 28);
			button21.TabIndex = 42;
			button21.Text = "Svon ON";
			button21.UseVisualStyleBackColor = true;
			button21.Click += new System.EventHandler(button21_Click);
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(445, 24);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(82, 25);
			comboBox1.TabIndex = 41;
			button18.Location = new System.Drawing.Point(564, 84);
			button18.Name = "button18";
			button18.Size = new System.Drawing.Size(68, 28);
			button18.TabIndex = 37;
			button18.Text = "Start";
			button18.UseVisualStyleBackColor = true;
			button18.Click += new System.EventHandler(button18_Click);
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(4, 121);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(44, 17);
			label5.TabIndex = 35;
			label5.Text = "时间：";
			button17.Location = new System.Drawing.Point(321, 84);
			button17.Name = "button17";
			button17.Size = new System.Drawing.Size(65, 28);
			button17.TabIndex = 34;
			button17.Text = "Cancel";
			button17.UseVisualStyleBackColor = true;
			button17.Click += new System.EventHandler(button17_Click);
			button16.Location = new System.Drawing.Point(250, 84);
			button16.Name = "button16";
			button16.Size = new System.Drawing.Size(65, 28);
			button16.TabIndex = 33;
			button16.Text = "Reset";
			button16.UseVisualStyleBackColor = true;
			button16.Click += new System.EventHandler(button16_Click);
			button15.Location = new System.Drawing.Point(158, 84);
			button15.Name = "button15";
			button15.Size = new System.Drawing.Size(86, 28);
			button15.TabIndex = 32;
			button15.Text = "Hold OFF";
			button15.UseVisualStyleBackColor = true;
			button15.Click += new System.EventHandler(button15_Click);
			button13.Location = new System.Drawing.Point(66, 84);
			button13.Name = "button13";
			button13.Size = new System.Drawing.Size(86, 28);
			button13.TabIndex = 31;
			button13.Text = "Hold ON";
			button13.UseVisualStyleBackColor = true;
			button13.Click += new System.EventHandler(button13_Click);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(4, 90);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(68, 17);
			label4.TabIndex = 30;
			label4.Text = "控制操作：";
			button12.Location = new System.Drawing.Point(531, 54);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(95, 28);
			button12.TabIndex = 29;
			button12.Text = "字符串读取";
			button12.UseVisualStyleBackColor = true;
			button12.Click += new System.EventHandler(button12_Click);
			button11.Location = new System.Drawing.Point(430, 54);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(95, 28);
			button11.TabIndex = 28;
			button11.Text = "实数读取";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			button10.Location = new System.Drawing.Point(333, 54);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(91, 28);
			button10.TabIndex = 27;
			button10.Text = "双整型读取";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(button10_Click);
			button9.Location = new System.Drawing.Point(245, 54);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(82, 28);
			button9.TabIndex = 26;
			button9.Text = "整型读取";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			button8.Location = new System.Drawing.Point(157, 54);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(82, 28);
			button8.TabIndex = 25;
			button8.Text = "字节读取";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			textBox5.Location = new System.Drawing.Point(66, 57);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(85, 23);
			textBox5.TabIndex = 24;
			textBox5.Text = "000";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(4, 60);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(68, 17);
			label2.TabIndex = 23;
			label2.Text = "变量地址：";
			button7.Location = new System.Drawing.Point(356, 23);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(83, 28);
			button7.TabIndex = 22;
			button7.Text = "程序名读取";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			button6.Location = new System.Drawing.Point(271, 23);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(79, 28);
			button6.TabIndex = 21;
			button6.Text = "状态读取";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button5.Location = new System.Drawing.Point(531, 22);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(101, 28);
			button5.TabIndex = 20;
			button5.Text = "姿态坐标读取";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			button4.Location = new System.Drawing.Point(174, 23);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(91, 28);
			button4.TabIndex = 19;
			button4.Text = "关节坐标读取";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button3.Location = new System.Drawing.Point(66, 23);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(102, 28);
			button3.TabIndex = 18;
			button3.Text = "报警信息读取";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox4.Location = new System.Drawing.Point(58, 208);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox4.Size = new System.Drawing.Size(579, 341);
			textBox4.TabIndex = 5;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(5, 211);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(44, 17);
			label7.TabIndex = 4;
			label7.Text = "结果：";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(4, 29);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(68, 17);
			label11.TabIndex = 40;
			label11.Text = "状态读取：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "YASKAWA - Ethernet 高速服务器功能";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.SupportListVisiable = true;
			userControlHead1.TabIndex = 2;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			button28.Location = new System.Drawing.Point(320, 178);
			button28.Name = "button28";
			button28.Size = new System.Drawing.Size(82, 28);
			button28.TabIndex = 55;
			button28.Text = "字节写入";
			button28.UseVisualStyleBackColor = true;
			button28.Click += new System.EventHandler(button28_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormYRCHighEthernet";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "安川机器人访问Demo";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
