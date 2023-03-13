using HslCommunication;
using HslCommunication.Instrument.Light;
using HslCommunication.LogNet;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace HslCommunicationDemo.Light
{
	public class FormShineInLight : HslFormContent
	{
		private ShineInLightSourceController lightSourceController;

		private IContainer components = null;

		private UserControlHead userControlHead1;

		private Panel panel1;

		private ComboBox comboBox3;

		private ComboBox comboBox1;

		private Label label1;

		private TextBox textBox17;

		private Label label3;

		private TextBox textBox16;

		private Label label25;

		private TextBox textBox2;

		private Label label26;

		private Label label27;

		private Button button2;

		private Button button1;

		private Panel panel2;

		private GroupBox groupBox1;

		private Label label2;

		private Label label15;

		private TextBox textBox8;

		private Label label16;

		private Label label13;

		private TextBox textBox7;

		private Label label14;

		private Label label11;

		private TextBox textBox6;

		private Label label12;

		private Label label9;

		private TextBox textBox5;

		private Label label10;

		private Label label7;

		private TextBox textBox4;

		private Label label8;

		private Label label6;

		private TextBox textBox3;

		private Label label5;

		private TextBox textBox1;

		private Label label4;

		private GroupBox groupBox2;

		private Panel panel3;

		private RadioButton radioButton1;

		private TextBox textBox9;

		private Label label17;

		private TextBox textBox10;

		private Label label18;

		private TextBox textBox11;

		private Label label19;

		private Label label20;

		private TextBox textBox13;

		private Label label21;

		private TextBox textBox14;

		private Label label22;

		private Label label23;

		private Button button3;

		private Button button4;

		private Panel panel4;

		private RadioButton radioButton10;

		private RadioButton radioButton9;

		private RadioButton radioButton8;

		private RadioButton radioButton7;

		private RadioButton radioButton6;

		private RadioButton radioButton5;

		private RadioButton radioButton4;

		private RadioButton radioButton3;

		private RadioButton radioButton2;

		private Label label24;

		private Label label28;

		private TextBox textBox12;

		private TextBox textBox15;

		private Label label29;

		private CheckBox checkBox5;

		public FormShineInLight()
		{
			InitializeComponent();
		}

		private void FormShineInLight_Load(object sender, EventArgs e)
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
		}

		private void button2_Click(object sender, EventArgs e)
		{
			ShineInLightSourceController shineInLightSourceController = lightSourceController;
			if (shineInLightSourceController != null)
			{
				shineInLightSourceController.Close();
			}
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
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
				ShineInLightSourceController shineInLightSourceController = lightSourceController;
				if (shineInLightSourceController != null)
				{
					shineInLightSourceController.Close();
				}
				lightSourceController = new ShineInLightSourceController();
				try
				{
					lightSourceController.SerialPortInni(delegate(SerialPort sp)
					{
						sp.PortName = comboBox3.Text;
						sp.BaudRate = baudRate;
						sp.DataBits = dataBits;
						sp.StopBits = ((stopBits != 0) ? ((stopBits == 1) ? StopBits.One : StopBits.Two) : StopBits.None);
						sp.Parity = ((comboBox1.SelectedIndex != 0) ? ((comboBox1.SelectedIndex == 1) ? Parity.Odd : Parity.Even) : Parity.None);
						sp.RtsEnable = checkBox5.Checked;
					});
					lightSourceController.LogNet = new LogNetFileSize("");
					lightSourceController.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
					lightSourceController.Open();
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
			textBox12.BeginInvoke((Action)delegate
			{
				textBox12.AppendText(e.HslMessage.ToString() + Environment.NewLine);
			});
		}

		private void button3_Click(object sender, EventArgs e)
		{
			byte result;
			if (!byte.TryParse(textBox15.Text, out result))
			{
				MessageBox.Show("通道号输入错误，为十进制的整数。");
			}
			else
			{
				OperateResult<ShineInLightData> operateResult = lightSourceController.Read(result);
				if (!operateResult.IsSuccess)
				{
					MessageBox.Show("Read Failed: " + operateResult.ToMessageShowString());
				}
				else
				{
					ShowLightData(operateResult.Content);
				}
			}
		}

		private void ShowLightData(ShineInLightData data)
		{
			textBox1.Text = data.Color.ToString();
			if (data.Color == 1)
			{
				label5.Text = "红色";
			}
			else if (data.Color == 2)
			{
				label5.Text = "绿色";
			}
			else if (data.Color == 3)
			{
				label5.Text = "蓝色";
			}
			else if (data.Color == 4)
			{
				label5.Text = "白色";
			}
			else
			{
				label5.Text = "未知";
			}
			textBox3.Text = data.Light.ToString();
			textBox4.Text = data.LightDegree.ToString();
			textBox5.Text = data.WorkMode.ToString();
			if (data.WorkMode == 0)
			{
				label9.Text = "延时常亮";
			}
			else if (data.WorkMode == 1)
			{
				label9.Text = "通道一频闪";
			}
			else if (data.WorkMode == 2)
			{
				label9.Text = "通道二频闪";
			}
			else if (data.WorkMode == 3)
			{
				label9.Text = "通道一二频闪";
			}
			else if (data.WorkMode == 4)
			{
				label9.Text = "普通常亮";
			}
			else if (data.WorkMode == 5)
			{
				label9.Text = "关闭";
			}
			else
			{
				label9.Text = "未知";
			}
			textBox6.Text = data.Address.ToString();
			textBox7.Text = data.PulseWidth.ToString();
			textBox8.Text = data.Channel.ToString();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			ShineInLightData shineInLightData = new ShineInLightData();
			if (radioButton1.Checked)
			{
				shineInLightData.Color = 1;
			}
			else if (radioButton2.Checked)
			{
				shineInLightData.Color = 2;
			}
			else if (radioButton3.Checked)
			{
				shineInLightData.Color = 3;
			}
			else if (radioButton4.Checked)
			{
				shineInLightData.Color = 4;
			}
			byte result;
			if (!byte.TryParse(textBox14.Text, out result))
			{
				MessageBox.Show("光源亮度输入失败，需要输入十进制的整数");
			}
			else
			{
				shineInLightData.Light = result;
				byte result2;
				if (!byte.TryParse(textBox13.Text, out result2))
				{
					MessageBox.Show("光源亮度等级输入失败，需要输入十进制的整数");
				}
				else
				{
					shineInLightData.LightDegree = result2;
					if (radioButton5.Checked)
					{
						shineInLightData.WorkMode = 0;
					}
					else if (radioButton6.Checked)
					{
						shineInLightData.WorkMode = 1;
					}
					else if (radioButton7.Checked)
					{
						shineInLightData.WorkMode = 2;
					}
					else if (radioButton8.Checked)
					{
						shineInLightData.WorkMode = 3;
					}
					else if (radioButton9.Checked)
					{
						shineInLightData.WorkMode = 4;
					}
					else if (radioButton10.Checked)
					{
						shineInLightData.WorkMode = 5;
					}
					byte result3;
					if (!byte.TryParse(textBox11.Text, out result3))
					{
						MessageBox.Show("地址位输入失败，需要输入十进制的整数");
					}
					else
					{
						shineInLightData.Address = result3;
						byte result4;
						if (!byte.TryParse(textBox10.Text, out result4))
						{
							MessageBox.Show("脉冲宽度输入失败，需要输入十进制的整数");
						}
						else
						{
							shineInLightData.PulseWidth = result4;
							byte result5;
							if (!byte.TryParse(textBox9.Text, out result5))
							{
								MessageBox.Show("通道输入失败，需要输入十进制的整数");
							}
							else
							{
								shineInLightData.Channel = result5;
								OperateResult operateResult = lightSourceController.Write(shineInLightData);
								if (operateResult.IsSuccess)
								{
									MessageBox.Show("写入成功");
								}
								else
								{
									MessageBox.Show("写入失败:" + operateResult.ToMessageShowString());
								}
							}
						}
					}
				}
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
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1 = new System.Windows.Forms.Panel();
			label24 = new System.Windows.Forms.Label();
			comboBox3 = new System.Windows.Forms.ComboBox();
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
			label28 = new System.Windows.Forms.Label();
			textBox12 = new System.Windows.Forms.TextBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			button4 = new System.Windows.Forms.Button();
			panel4 = new System.Windows.Forms.Panel();
			radioButton10 = new System.Windows.Forms.RadioButton();
			radioButton9 = new System.Windows.Forms.RadioButton();
			radioButton8 = new System.Windows.Forms.RadioButton();
			radioButton7 = new System.Windows.Forms.RadioButton();
			radioButton6 = new System.Windows.Forms.RadioButton();
			radioButton5 = new System.Windows.Forms.RadioButton();
			panel3 = new System.Windows.Forms.Panel();
			radioButton4 = new System.Windows.Forms.RadioButton();
			radioButton3 = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton1 = new System.Windows.Forms.RadioButton();
			textBox9 = new System.Windows.Forms.TextBox();
			label17 = new System.Windows.Forms.Label();
			textBox10 = new System.Windows.Forms.TextBox();
			label18 = new System.Windows.Forms.Label();
			textBox11 = new System.Windows.Forms.TextBox();
			label19 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			textBox13 = new System.Windows.Forms.TextBox();
			label21 = new System.Windows.Forms.Label();
			textBox14 = new System.Windows.Forms.TextBox();
			label22 = new System.Windows.Forms.Label();
			label23 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			textBox15 = new System.Windows.Forms.TextBox();
			label29 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			label15 = new System.Windows.Forms.Label();
			textBox8 = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			textBox7 = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			checkBox5 = new System.Windows.Forms.CheckBox();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox2.SuspendLayout();
			panel4.SuspendLayout();
			panel3.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "专用协议";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 3;
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(checkBox5);
			panel1.Controls.Add(label24);
			panel1.Controls.Add(comboBox3);
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
			panel1.Location = new System.Drawing.Point(12, 40);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(978, 66);
			panel1.TabIndex = 4;
			label24.AutoSize = true;
			label24.ForeColor = System.Drawing.Color.Gray;
			label24.Location = new System.Drawing.Point(9, 41);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(368, 17);
			label24.TabIndex = 41;
			label24.Text = "昱行智造科技（深圳）有限公司的光源控制器，用于视觉中补光操作";
			comboBox3.FormattingEnabled = true;
			comboBox3.Location = new System.Drawing.Point(62, 9);
			comboBox3.Name = "comboBox3";
			comboBox3.Size = new System.Drawing.Size(67, 25);
			comboBox3.TabIndex = 40;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[3]
			{
				"无",
				"奇",
				"偶"
			});
			comboBox1.Location = new System.Drawing.Point(521, 9);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(57, 25);
			comboBox1.TabIndex = 25;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(470, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(44, 17);
			label1.TabIndex = 24;
			label1.Text = "奇偶：";
			textBox17.Location = new System.Drawing.Point(430, 9);
			textBox17.Name = "textBox17";
			textBox17.Size = new System.Drawing.Size(23, 23);
			textBox17.TabIndex = 23;
			textBox17.Text = "1";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(371, 12);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 22;
			label3.Text = "停止位：";
			textBox16.Location = new System.Drawing.Point(333, 9);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(24, 23);
			textBox16.TabIndex = 21;
			textBox16.Text = "8";
			label25.AutoSize = true;
			label25.Location = new System.Drawing.Point(270, 12);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(56, 17);
			label25.TabIndex = 20;
			label25.Text = "数据位：";
			textBox2.Location = new System.Drawing.Point(202, 9);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(47, 23);
			textBox2.TabIndex = 19;
			textBox2.Text = "57600";
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(135, 12);
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
			button2.Location = new System.Drawing.Point(875, 6);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭串口";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(778, 6);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "打开串口";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(label28);
			panel2.Controls.Add(textBox12);
			panel2.Controls.Add(groupBox2);
			panel2.Controls.Add(groupBox1);
			panel2.Location = new System.Drawing.Point(12, 113);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(978, 528);
			panel2.TabIndex = 5;
			label28.AutoSize = true;
			label28.Location = new System.Drawing.Point(13, 372);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(44, 17);
			label28.TabIndex = 3;
			label28.Text = "日志：";
			textBox12.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			textBox12.Location = new System.Drawing.Point(11, 392);
			textBox12.Multiline = true;
			textBox12.Name = "textBox12";
			textBox12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox12.Size = new System.Drawing.Size(955, 131);
			textBox12.TabIndex = 2;
			groupBox2.Controls.Add(button4);
			groupBox2.Controls.Add(panel4);
			groupBox2.Controls.Add(panel3);
			groupBox2.Controls.Add(textBox9);
			groupBox2.Controls.Add(label17);
			groupBox2.Controls.Add(textBox10);
			groupBox2.Controls.Add(label18);
			groupBox2.Controls.Add(textBox11);
			groupBox2.Controls.Add(label19);
			groupBox2.Controls.Add(label20);
			groupBox2.Controls.Add(textBox13);
			groupBox2.Controls.Add(label21);
			groupBox2.Controls.Add(textBox14);
			groupBox2.Controls.Add(label22);
			groupBox2.Controls.Add(label23);
			groupBox2.Location = new System.Drawing.Point(10, 165);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(955, 202);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "Write";
			button4.Location = new System.Drawing.Point(821, 38);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(103, 34);
			button4.TabIndex = 36;
			button4.Text = "写入";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			panel4.Controls.Add(radioButton10);
			panel4.Controls.Add(radioButton9);
			panel4.Controls.Add(radioButton8);
			panel4.Controls.Add(radioButton7);
			panel4.Controls.Add(radioButton6);
			panel4.Controls.Add(radioButton5);
			panel4.Location = new System.Drawing.Point(356, 44);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(120, 152);
			panel4.TabIndex = 35;
			radioButton10.AutoSize = true;
			radioButton10.Location = new System.Drawing.Point(19, 128);
			radioButton10.Name = "radioButton10";
			radioButton10.Size = new System.Drawing.Size(50, 21);
			radioButton10.TabIndex = 6;
			radioButton10.Text = "关闭";
			radioButton10.UseVisualStyleBackColor = true;
			radioButton9.AutoSize = true;
			radioButton9.Location = new System.Drawing.Point(19, 101);
			radioButton9.Name = "radioButton9";
			radioButton9.Size = new System.Drawing.Size(74, 21);
			radioButton9.TabIndex = 5;
			radioButton9.Text = "普通常亮";
			radioButton9.UseVisualStyleBackColor = true;
			radioButton8.AutoSize = true;
			radioButton8.Location = new System.Drawing.Point(18, 74);
			radioButton8.Name = "radioButton8";
			radioButton8.Size = new System.Drawing.Size(98, 21);
			radioButton8.TabIndex = 4;
			radioButton8.Text = "通道一二频闪";
			radioButton8.UseVisualStyleBackColor = true;
			radioButton7.AutoSize = true;
			radioButton7.Location = new System.Drawing.Point(18, 49);
			radioButton7.Name = "radioButton7";
			radioButton7.Size = new System.Drawing.Size(86, 21);
			radioButton7.TabIndex = 3;
			radioButton7.Text = "通道二频闪";
			radioButton7.UseVisualStyleBackColor = true;
			radioButton6.AutoSize = true;
			radioButton6.Location = new System.Drawing.Point(18, 27);
			radioButton6.Name = "radioButton6";
			radioButton6.Size = new System.Drawing.Size(86, 21);
			radioButton6.TabIndex = 2;
			radioButton6.Text = "通道一频闪";
			radioButton6.UseVisualStyleBackColor = true;
			radioButton5.AutoSize = true;
			radioButton5.Checked = true;
			radioButton5.Location = new System.Drawing.Point(18, 5);
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new System.Drawing.Size(74, 21);
			radioButton5.TabIndex = 1;
			radioButton5.TabStop = true;
			radioButton5.Text = "延时常亮";
			radioButton5.UseVisualStyleBackColor = true;
			panel3.Controls.Add(radioButton4);
			panel3.Controls.Add(radioButton3);
			panel3.Controls.Add(radioButton2);
			panel3.Controls.Add(radioButton1);
			panel3.Location = new System.Drawing.Point(29, 44);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(105, 152);
			panel3.TabIndex = 34;
			radioButton4.AutoSize = true;
			radioButton4.Location = new System.Drawing.Point(7, 69);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new System.Drawing.Size(50, 21);
			radioButton4.TabIndex = 3;
			radioButton4.Text = "白色";
			radioButton4.UseVisualStyleBackColor = true;
			radioButton3.AutoSize = true;
			radioButton3.Location = new System.Drawing.Point(7, 47);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(50, 21);
			radioButton3.TabIndex = 2;
			radioButton3.Text = "蓝色";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton2.AutoSize = true;
			radioButton2.Location = new System.Drawing.Point(7, 25);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(50, 21);
			radioButton2.TabIndex = 1;
			radioButton2.Text = "绿色";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton1.AutoSize = true;
			radioButton1.Checked = true;
			radioButton1.Location = new System.Drawing.Point(7, 3);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(50, 21);
			radioButton1.TabIndex = 0;
			radioButton1.TabStop = true;
			radioButton1.Text = "红色";
			radioButton1.UseVisualStyleBackColor = true;
			textBox9.Location = new System.Drawing.Point(714, 44);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(88, 23);
			textBox9.TabIndex = 33;
			textBox9.Text = "1";
			label17.AutoSize = true;
			label17.Location = new System.Drawing.Point(712, 22);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(32, 17);
			label17.TabIndex = 32;
			label17.Text = "通道";
			textBox10.Location = new System.Drawing.Point(602, 44);
			textBox10.Name = "textBox10";
			textBox10.Size = new System.Drawing.Size(88, 23);
			textBox10.TabIndex = 31;
			textBox10.Text = "1";
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(600, 22);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(56, 17);
			label18.TabIndex = 30;
			label18.Text = "脉冲宽度";
			textBox11.Location = new System.Drawing.Point(486, 44);
			textBox11.Name = "textBox11";
			textBox11.Size = new System.Drawing.Size(88, 23);
			textBox11.TabIndex = 29;
			textBox11.Text = "0";
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(484, 22);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(44, 17);
			label19.TabIndex = 28;
			label19.Text = "地址位";
			label20.AutoSize = true;
			label20.Location = new System.Drawing.Point(372, 22);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(56, 17);
			label20.TabIndex = 26;
			label20.Text = "工作模式";
			textBox13.Location = new System.Drawing.Point(262, 44);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(88, 23);
			textBox13.TabIndex = 25;
			textBox13.Text = "1";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(260, 22);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(56, 17);
			label21.TabIndex = 24;
			label21.Text = "光源等级";
			textBox14.Location = new System.Drawing.Point(146, 44);
			textBox14.Name = "textBox14";
			textBox14.Size = new System.Drawing.Size(88, 23);
			textBox14.TabIndex = 23;
			textBox14.Text = "0";
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(144, 22);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(56, 17);
			label22.TabIndex = 21;
			label22.Text = "光源亮度";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(29, 22);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(32, 17);
			label23.TabIndex = 20;
			label23.Text = "颜色";
			groupBox1.Controls.Add(textBox15);
			groupBox1.Controls.Add(label29);
			groupBox1.Controls.Add(button3);
			groupBox1.Controls.Add(label15);
			groupBox1.Controls.Add(textBox8);
			groupBox1.Controls.Add(label16);
			groupBox1.Controls.Add(label13);
			groupBox1.Controls.Add(textBox7);
			groupBox1.Controls.Add(label14);
			groupBox1.Controls.Add(label11);
			groupBox1.Controls.Add(textBox6);
			groupBox1.Controls.Add(label12);
			groupBox1.Controls.Add(label9);
			groupBox1.Controls.Add(textBox5);
			groupBox1.Controls.Add(label10);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(textBox4);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(textBox3);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(textBox1);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label2);
			groupBox1.Location = new System.Drawing.Point(10, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(955, 156);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Read";
			textBox15.Location = new System.Drawing.Point(67, 28);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(74, 23);
			textBox15.TabIndex = 23;
			textBox15.Text = "1";
			label29.AutoSize = true;
			label29.Location = new System.Drawing.Point(29, 31);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(32, 17);
			label29.TabIndex = 22;
			label29.Text = "通道";
			button3.Location = new System.Drawing.Point(160, 22);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(103, 34);
			button3.TabIndex = 21;
			button3.Text = "读取一次";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(712, 128);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(13, 17);
			label15.TabIndex = 20;
			label15.Text = "-";
			textBox8.Location = new System.Drawing.Point(714, 95);
			textBox8.Name = "textBox8";
			textBox8.Size = new System.Drawing.Size(88, 23);
			textBox8.TabIndex = 19;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(712, 73);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(32, 17);
			label16.TabIndex = 18;
			label16.Text = "通道";
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(600, 128);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(13, 17);
			label13.TabIndex = 17;
			label13.Text = "-";
			textBox7.Location = new System.Drawing.Point(602, 95);
			textBox7.Name = "textBox7";
			textBox7.Size = new System.Drawing.Size(88, 23);
			textBox7.TabIndex = 16;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(600, 73);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(56, 17);
			label14.TabIndex = 15;
			label14.Text = "脉冲宽度";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(484, 128);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(13, 17);
			label11.TabIndex = 14;
			label11.Text = "-";
			textBox6.Location = new System.Drawing.Point(486, 95);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(88, 23);
			textBox6.TabIndex = 13;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(484, 73);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(44, 17);
			label12.TabIndex = 12;
			label12.Text = "地址位";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(372, 128);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(13, 17);
			label9.TabIndex = 11;
			label9.Text = "-";
			textBox5.Location = new System.Drawing.Point(374, 95);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(88, 23);
			textBox5.TabIndex = 10;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(372, 73);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(56, 17);
			label10.TabIndex = 9;
			label10.Text = "工作模式";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(260, 128);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(13, 17);
			label7.TabIndex = 8;
			label7.Text = "-";
			textBox4.Location = new System.Drawing.Point(262, 95);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(88, 23);
			textBox4.TabIndex = 7;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(260, 73);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(56, 17);
			label8.TabIndex = 6;
			label8.Text = "光源等级";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(144, 128);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(13, 17);
			label6.TabIndex = 5;
			label6.Text = "-";
			textBox3.Location = new System.Drawing.Point(146, 95);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(88, 23);
			textBox3.TabIndex = 4;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(29, 128);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(13, 17);
			label5.TabIndex = 3;
			label5.Text = "-";
			textBox1.Location = new System.Drawing.Point(31, 95);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(88, 23);
			textBox1.TabIndex = 2;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(144, 73);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(56, 17);
			label4.TabIndex = 1;
			label4.Text = "光源亮度";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(29, 73);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(32, 17);
			label2.TabIndex = 0;
			label2.Text = "颜色";
			checkBox5.AutoSize = true;
			checkBox5.Location = new System.Drawing.Point(601, 11);
			checkBox5.Name = "checkBox5";
			checkBox5.Size = new System.Drawing.Size(84, 21);
			checkBox5.TabIndex = 42;
			checkBox5.Text = "RtsEnable";
			checkBox5.UseVisualStyleBackColor = true;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			base.Controls.Add(userControlHead1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "FormShineInLight";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormShineInLight";
			base.Load += new System.EventHandler(FormShineInLight_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
