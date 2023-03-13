using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Profinet.Toledo;
using HslCommunicationDemo.DemoControl;
using HslControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.Toledo
{
	public class FormToledoSerial : HslFormContent
	{
		private ToledoSerial toledoSerial;

		private long receiveTimes = 0L;

		private IContainer components = null;

		private UserControlHead userControlHead1;

		private Panel panel2;

		private Panel panel1;

		private CheckBox checkBox5;

		private ComboBox comboBox3;

		private ComboBox comboBox1;

		private Label label24;

		private TextBox textBox17;

		private Label label23;

		private TextBox textBox16;

		private Label label22;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private Label label1;

		private Button button3;

		private TextBox textBox4;

		private Label label5;

		private TextBox textBox6;

		private HslDialPlate hslDialPlate1;

		private HslCurve hslCurve1;

		private TextBox textBox3;

		private Label label4;

		private Label label2;

		private TextBox textBox1;

		private Label label6;

		private ToledoDataControl toledoDataControl1;

		private CheckBox checkBox4;

		private Label label7;

		private Label label8;

		private CheckBox checkBox1;

		public FormToledoSerial()
		{
			InitializeComponent();
		}

		private void FormToledoSerial_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			hslCurve1.SetLeftCurve("重量", null, Color.Red);
			comboBox1.SelectedIndex = 0;
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
			if (language == 1)
			{
				Text = "托利多串口调试助手";
				label1.Text = "Com口：";
				label3.Text = "波特率:";
				label22.Text = "数据位:";
				label23.Text = "停止位:";
				label24.Text = "奇偶：";
				button1.Text = "打开串口";
				button2.Text = "关闭串口";
				label7.Text = "数据接收区：";
				checkBox4.Text = "是否显示时间";
				comboBox1.DataSource = new string[3]
				{
					"无",
					"奇",
					"偶"
				};
			}
			else
			{
				Text = "Toledo Serial Demo";
				label1.Text = "Com:";
				label3.Text = "Baud rate:";
				label22.Text = "Data bits:";
				label23.Text = "Stop bits:";
				label24.Text = "parity:";
				button1.Text = "Open";
				button2.Text = "Close";
				label7.Text = "Data receiving Area:";
				checkBox4.Text = "Whether to show time";
				comboBox1.DataSource = new string[3]
				{
					"None",
					"Odd",
					"Even"
				};
				checkBox1.Text = "Sum Check?";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int baudRate;
			int dataBits;
			int stopBits;
			if (!int.TryParse(textBox2.Text, out baudRate))
			{
				MessageBox.Show((Program.Language == 1) ? "波特率输入错误！" : "Baud rate input error");
			}
			else if (!int.TryParse(textBox16.Text, out dataBits))
			{
				MessageBox.Show((Program.Language == 1) ? "数据位输入错误！" : "Data bits input error");
			}
			else if (!int.TryParse(textBox17.Text, out stopBits))
			{
				MessageBox.Show((Program.Language == 1) ? "停止位输入错误！" : "Stop bits input error");
			}
			else
			{
				toledoSerial = new ToledoSerial();
				toledoSerial.OnToledoStandardDataReceived += ToledoSerial_OnToledoStandardDataReceived;
				toledoSerial.LogNet = base.LogNet;
				toledoSerial.HasChk = checkBox1.Checked;
				toledoSerial.SerialPortInni(delegate(SerialPort m)
				{
					m.PortName = comboBox3.Text;
					m.BaudRate = baudRate;
					m.DataBits = dataBits;
					m.StopBits = ((stopBits != 0) ? ((stopBits == 1) ? StopBits.One : StopBits.Two) : StopBits.None);
					m.Parity = ((comboBox1.SelectedIndex != 0) ? ((comboBox1.SelectedIndex == 1) ? Parity.Odd : Parity.Even) : Parity.None);
					m.RtsEnable = checkBox5.Checked;
				});
				try
				{
					toledoSerial.Open();
					button1.Enabled = false;
					button2.Enabled = true;
					panel2.Enabled = true;
				}
				catch (Exception ex)
				{
					SoftBasic.ShowExceptionMessage(ex);
				}
			}
		}

		private void ToledoSerial_OnToledoStandardDataReceived(object sender, ToledoStandardData e)
		{
			if (base.InvokeRequired)
			{
				Invoke(new Action<object, ToledoStandardData>(ToledoSerial_OnToledoStandardDataReceived), sender, e);
			}
			else
			{
				receiveTimes++;
				StringBuilder stringBuilder = new StringBuilder();
				if (checkBox4.Checked)
				{
					stringBuilder.Append(DateTime.Now.ToString() + Environment.NewLine);
				}
				stringBuilder.Append(e.ToJsonString() + Environment.NewLine);
				textBox6.Text = stringBuilder.ToString();
				textBox1.Text = e.SourceData.ToHexString(' ');
				textBox3.Text = Encoding.ASCII.GetString(e.SourceData);
				toledoDataControl1.SetToledoData(e);
				hslCurve1.AddCurveData("重量", e.Weight);
				hslDialPlate1.Value = e.Weight;
				label2.Text = "Receive Times:" + receiveTimes.ToString();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				ToledoSerial obj = toledoSerial;
				if (obj != null)
				{
					obj.Close();
				}
				button2.Enabled = false;
				button1.Enabled = true;
				panel2.Enabled = false;
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage(ex);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			float result;
			if (float.TryParse(textBox4.Text, out result))
			{
				hslCurve1.ValueMaxLeft = result;
				hslDialPlate1.MaxValue = result;
			}
			else
			{
				MessageBox.Show("Input Wrong");
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlCom, comboBox3.Text);
			element.SetAttributeValue(DemoDeviceList.XmlBaudRate, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlDataBits, textBox16.Text);
			element.SetAttributeValue(DemoDeviceList.XmlStopBit, textBox17.Text);
			element.SetAttributeValue(DemoDeviceList.XmlParity, comboBox1.SelectedIndex);
			element.SetAttributeValue(DemoDeviceList.XmlRtsEnable, checkBox5.Checked);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			comboBox3.Text = element.Attribute(DemoDeviceList.XmlCom).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlBaudRate).Value;
			textBox16.Text = element.Attribute(DemoDeviceList.XmlDataBits).Value;
			textBox17.Text = element.Attribute(DemoDeviceList.XmlStopBit).Value;
			comboBox1.SelectedIndex = int.Parse(element.Attribute(DemoDeviceList.XmlParity).Value);
			checkBox5.Checked = bool.Parse(element.Attribute(DemoDeviceList.XmlRtsEnable).Value);
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
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel2 = new System.Windows.Forms.Panel();
			label8 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			hslDialPlate1 = new HslControls.HslDialPlate();
			hslCurve1 = new HslControls.HslCurve();
			textBox3 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			toledoDataControl1 = new HslCommunicationDemo.Toledo.ToledoDataControl();
			checkBox4 = new System.Windows.Forms.CheckBox();
			label7 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			checkBox1 = new System.Windows.Forms.CheckBox();
			checkBox5 = new System.Windows.Forms.CheckBox();
			comboBox3 = new System.Windows.Forms.ComboBox();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label24 = new System.Windows.Forms.Label();
			textBox17 = new System.Windows.Forms.TextBox();
			label23 = new System.Windows.Forms.Label();
			textBox16 = new System.Windows.Forms.TextBox();
			label22 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			panel2.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Toledo Serial";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.SupportListVisiable = true;
			userControlHead1.TabIndex = 15;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(label8);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(textBox6);
			panel2.Controls.Add(hslDialPlate1);
			panel2.Controls.Add(hslCurve1);
			panel2.Controls.Add(textBox3);
			panel2.Controls.Add(label4);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(textBox1);
			panel2.Controls.Add(label6);
			panel2.Controls.Add(toledoDataControl1);
			panel2.Controls.Add(checkBox4);
			panel2.Controls.Add(label7);
			panel2.Location = new System.Drawing.Point(3, 94);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 550);
			panel2.TabIndex = 17;
			label8.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(8, 524);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(272, 17);
			label8.TabIndex = 47;
			label8.Text = "支持连续标准输出的格式，支持连续扩展输出格式";
			button3.Location = new System.Drawing.Point(313, 84);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(91, 28);
			button3.TabIndex = 46;
			button3.Text = "Setting";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox4.Location = new System.Drawing.Point(197, 87);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(100, 23);
			textBox4.TabIndex = 45;
			textBox4.Text = "100";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(119, 90);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(72, 17);
			label5.TabIndex = 44;
			label5.Text = "Max Value:";
			textBox6.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			textBox6.Location = new System.Drawing.Point(558, 99);
			textBox6.Multiline = true;
			textBox6.Name = "textBox6";
			textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox6.Size = new System.Drawing.Size(209, 415);
			textBox6.TabIndex = 35;
			hslDialPlate1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			hslDialPlate1.BoderColor2 = System.Drawing.Color.FromArgb(228, 229, 229);
			hslDialPlate1.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
			hslDialPlate1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			hslDialPlate1.Location = new System.Drawing.Point(790, 326);
			hslDialPlate1.Name = "hslDialPlate1";
			hslDialPlate1.Size = new System.Drawing.Size(192, 188);
			hslDialPlate1.TabIndex = 43;
			hslCurve1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			hslCurve1.Location = new System.Drawing.Point(6, 117);
			hslCurve1.Name = "hslCurve1";
			hslCurve1.Size = new System.Drawing.Size(546, 397);
			hslCurve1.TabIndex = 42;
			hslCurve1.Title = "重力曲线图";
			textBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox3.Location = new System.Drawing.Point(65, 59);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(698, 23);
			textBox3.TabIndex = 41;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(11, 61);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(42, 17);
			label4.TabIndex = 40;
			label4.Text = "ASCII:";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(327, 9);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(93, 17);
			label2.TabIndex = 39;
			label2.Text = "Receive Times:";
			textBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox1.Location = new System.Drawing.Point(65, 32);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(698, 23);
			textBox1.TabIndex = 38;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(11, 35);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(33, 17);
			label6.TabIndex = 37;
			label6.Text = "Hex:";
			toledoDataControl1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			toledoDataControl1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			toledoDataControl1.Location = new System.Drawing.Point(773, 1);
			toledoDataControl1.Name = "toledoDataControl1";
			toledoDataControl1.Size = new System.Drawing.Size(216, 319);
			toledoDataControl1.TabIndex = 36;
			checkBox4.AutoSize = true;
			checkBox4.Checked = true;
			checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox4.Location = new System.Drawing.Point(97, 8);
			checkBox4.Name = "checkBox4";
			checkBox4.Size = new System.Drawing.Size(99, 21);
			checkBox4.TabIndex = 34;
			checkBox4.Text = "是否显示时间";
			checkBox4.UseVisualStyleBackColor = true;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(11, 9);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(80, 17);
			label7.TabIndex = 33;
			label7.Text = "数据接收区：";
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(checkBox1);
			panel1.Controls.Add(checkBox5);
			panel1.Controls.Add(comboBox3);
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(label24);
			panel1.Controls.Add(textBox17);
			panel1.Controls.Add(label23);
			panel1.Controls.Add(textBox16);
			panel1.Controls.Add(label22);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 54);
			panel1.TabIndex = 16;
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(677, 16);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(99, 21);
			checkBox1.TabIndex = 18;
			checkBox1.Text = "是否有校验位";
			checkBox1.UseVisualStyleBackColor = true;
			checkBox5.AutoSize = true;
			checkBox5.Location = new System.Drawing.Point(585, 16);
			checkBox5.Name = "checkBox5";
			checkBox5.Size = new System.Drawing.Size(84, 21);
			checkBox5.TabIndex = 17;
			checkBox5.Text = "RtsEnable";
			checkBox5.UseVisualStyleBackColor = true;
			comboBox3.FormattingEnabled = true;
			comboBox3.Location = new System.Drawing.Point(60, 12);
			comboBox3.Name = "comboBox3";
			comboBox3.Size = new System.Drawing.Size(84, 25);
			comboBox3.TabIndex = 16;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[3]
			{
				"无",
				"奇",
				"偶"
			});
			comboBox1.Location = new System.Drawing.Point(511, 14);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(66, 25);
			comboBox1.TabIndex = 15;
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(465, 17);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(44, 17);
			label24.TabIndex = 14;
			label24.Text = "奇偶：";
			textBox17.Location = new System.Drawing.Point(433, 14);
			textBox17.Name = "textBox17";
			textBox17.Size = new System.Drawing.Size(23, 23);
			textBox17.TabIndex = 13;
			textBox17.Text = "1";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(369, 17);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(56, 17);
			label23.TabIndex = 12;
			label23.Text = "停止位：";
			textBox16.Location = new System.Drawing.Point(333, 14);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(24, 23);
			textBox16.TabIndex = 11;
			textBox16.Text = "8";
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(270, 17);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(56, 17);
			label22.TabIndex = 10;
			label22.Text = "数据位：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(882, 11);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭串口";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(785, 11);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "打开串口";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(217, 14);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(47, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "9600";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(150, 17);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "波特率：";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(6, 17);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(59, 17);
			label1.TabIndex = 0;
			label1.Text = "Com口：";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			base.Controls.Add(userControlHead1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormToledoSerial";
			Text = "FormToledoSerial";
			base.Load += new System.EventHandler(FormToledoSerial_Load);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
