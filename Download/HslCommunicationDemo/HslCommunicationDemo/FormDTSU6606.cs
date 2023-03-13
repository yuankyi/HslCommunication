using HslCommunication;
using HslCommunication.Core;
using HslCommunication.Instrument.Delixi;
using HslCommunicationDemo.DemoControl;
using HslControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormDTSU6606 : HslFormContent
	{
		private DTSU6606Serial delixi = null;

		private Timer timer;

		private bool timerRead = false;

		private IContainer components = null;

		private Panel panel1;

		private Label label1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox15;

		private Label label21;

		private CheckBox checkBox1;

		private ComboBox comboBox1;

		private Label label24;

		private TextBox textBox17;

		private Label label23;

		private TextBox textBox16;

		private Label label22;

		private CheckBox checkBox3;

		private ComboBox comboBox2;

		private ComboBox comboBox3;

		private UserControlHead userControlHead1;

		private CheckBox checkBox5;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private GroupBox groupBox5;

		private HslCurve hslCurve1;

		private Label label51;

		private TextBox textBox28;

		private Label label52;

		private Label label49;

		private TextBox textBox27;

		private Label label50;

		private Label label47;

		private TextBox textBox26;

		private Label label48;

		private Label label45;

		private TextBox textBox25;

		private Label label46;

		private Label label43;

		private TextBox textBox24;

		private Label label44;

		private Label label41;

		private TextBox textBox23;

		private Label label42;

		private Label label39;

		private TextBox textBox22;

		private Label label40;

		private Label label37;

		private TextBox textBox21;

		private Label label38;

		private Label label35;

		private TextBox textBox20;

		private Label label36;

		private Label label33;

		private TextBox textBox19;

		private Label label34;

		private Label label31;

		private TextBox textBox18;

		private Label label32;

		private Label label29;

		private TextBox textBox14;

		private Label label30;

		private Label label27;

		private TextBox textBox13;

		private Label label28;

		private Label label25;

		private TextBox textBox11;

		private Label label26;

		private Label label19;

		private TextBox textBox10;

		private Label label20;

		private Label label17;

		private TextBox textBox9;

		private Label label18;

		private Label label10;

		private Label label11;

		private Label label12;

		private Label label13;

		private Label label14;

		private Label label15;

		private Label label16;

		private TextBox textBox8;

		private Label label9;

		private TextBox textBox7;

		private Label label8;

		private TextBox textBox6;

		private Label label7;

		private TextBox textBox5;

		private Label label6;

		private TextBox textBox4;

		private Label label5;

		private TextBox textBox3;

		private Label label4;

		private TextBox textBox1;

		private Label label2;

		private Button button3;

		private Label label53;

		private TextBox textBox12;

		private Label label54;

		private Button button4;

		public FormDTSU6606()
		{
			InitializeComponent();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			comboBox1.SelectedIndex = 2;
			comboBox2.SelectedIndex = 0;
			comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
			checkBox3.CheckedChanged += CheckBox3_CheckedChanged;
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
			hslCurve1.SetLeftCurve("电压A", null);
			hslCurve1.SetLeftCurve("电压B", null);
			hslCurve1.SetLeftCurve("电压C", null);
			hslCurve1.SetRightCurve("频率", null);
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "Delixi Read Demo";
				label1.Text = "Com:";
				label3.Text = "baudRate:";
				label22.Text = "DataBit";
				label23.Text = "StopBit";
				label24.Text = "parity";
				label21.Text = "station";
				checkBox1.Text = "address from 0";
				checkBox3.Text = "string reverse";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label11.Text = "Address:";
				label12.Text = "length:";
				label13.Text = "Results:";
				label16.Text = "Message:";
				label14.Text = "Results:";
				groupBox5.Text = "Special function test";
				comboBox1.DataSource = new string[3]
				{
					"None",
					"Odd",
					"Even"
				};
			}
		}

		private void CheckBox3_CheckedChanged(object sender, EventArgs e)
		{
			if (delixi != null)
			{
				delixi.IsStringReverse = checkBox3.Checked;
			}
		}

		private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (delixi != null)
			{
				switch (comboBox2.SelectedIndex)
				{
				case 0:
					delixi.DataFormat = DataFormat.ABCD;
					break;
				case 1:
					delixi.DataFormat = DataFormat.BADC;
					break;
				case 2:
					delixi.DataFormat = DataFormat.CDAB;
					break;
				case 3:
					delixi.DataFormat = DataFormat.DCBA;
					break;
				}
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int baudRate;
			int dataBits;
			int stopBits;
			byte result;
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
			else if (!byte.TryParse(textBox15.Text, out result))
			{
				MessageBox.Show("Station input wrong！");
			}
			else
			{
				DTSU6606Serial dTSU6606Serial = delixi;
				if (dTSU6606Serial != null)
				{
					dTSU6606Serial.Close();
				}
				delixi = new DTSU6606Serial(result);
				delixi.AddressStartWithZero = checkBox1.Checked;
				delixi.LogNet = base.LogNet;
				ComboBox2_SelectedIndexChanged(null, new EventArgs());
				delixi.IsStringReverse = checkBox3.Checked;
				try
				{
					delixi.SerialPortInni(delegate(SerialPort sp)
					{
						sp.PortName = comboBox3.Text;
						sp.BaudRate = baudRate;
						sp.DataBits = dataBits;
						sp.StopBits = ((stopBits != 0) ? ((stopBits == 1) ? StopBits.One : StopBits.Two) : StopBits.None);
						sp.Parity = ((comboBox1.SelectedIndex != 0) ? ((comboBox1.SelectedIndex == 1) ? Parity.Odd : Parity.Even) : Parity.None);
					});
					delixi.RtsEnable = checkBox5.Checked;
					delixi.Open();
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
					userControlReadWriteOp1.SetReadWriteNet(delixi, "100");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			delixi.Close();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlCom, comboBox3.Text);
			element.SetAttributeValue(DemoDeviceList.XmlBaudRate, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlDataBits, textBox16.Text);
			element.SetAttributeValue(DemoDeviceList.XmlStopBit, textBox17.Text);
			element.SetAttributeValue(DemoDeviceList.XmlParity, comboBox1.SelectedIndex);
			element.SetAttributeValue(DemoDeviceList.XmlStation, textBox15.Text);
			element.SetAttributeValue(DemoDeviceList.XmlAddressStartWithZero, checkBox1.Checked);
			element.SetAttributeValue(DemoDeviceList.XmlDataFormat, comboBox2.SelectedIndex);
			element.SetAttributeValue(DemoDeviceList.XmlStringReverse, checkBox3.Checked);
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
			textBox15.Text = element.Attribute(DemoDeviceList.XmlStation).Value;
			checkBox1.Checked = bool.Parse(element.Attribute(DemoDeviceList.XmlAddressStartWithZero).Value);
			comboBox2.SelectedIndex = int.Parse(element.Attribute(DemoDeviceList.XmlDataFormat).Value);
			checkBox3.Checked = bool.Parse(element.Attribute(DemoDeviceList.XmlStringReverse).Value);
			checkBox5.Checked = bool.Parse(element.Attribute(DemoDeviceList.XmlRtsEnable).Value);
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OperateResult<ElectricalParameters> operateResult = delixi.ReadElectricalParameters();
			if (operateResult.IsSuccess)
			{
				ShowElectrical(operateResult.Content);
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void ShowElectrical(ElectricalParameters electrical)
		{
			textBox1.Text = electrical.VoltageA.ToString();
			textBox3.Text = electrical.VoltageB.ToString();
			textBox4.Text = electrical.VoltageC.ToString();
			textBox5.Text = electrical.CurrentA.ToString();
			textBox6.Text = electrical.CurrentB.ToString();
			textBox7.Text = electrical.CurrentC.ToString();
			textBox8.Text = electrical.Frequency.ToString();
			textBox9.Text = electrical.InstantaneousActivePowerA.ToString();
			textBox10.Text = electrical.InstantaneousActivePowerB.ToString();
			textBox11.Text = electrical.InstantaneousActivePowerC.ToString();
			textBox13.Text = electrical.InstantaneousTotalActivePower.ToString();
			textBox14.Text = electrical.InstantaneousReactivePowerA.ToString();
			textBox18.Text = electrical.InstantaneousReactivePowerB.ToString();
			textBox19.Text = electrical.InstantaneousReactivePowerC.ToString();
			textBox20.Text = electrical.InstantaneousTotalReactivePower.ToString();
			textBox21.Text = electrical.InstantaneousApparentPowerA.ToString();
			textBox22.Text = electrical.InstantaneousApparentPowerB.ToString();
			textBox23.Text = electrical.InstantaneousApparentPowerC.ToString();
			textBox24.Text = electrical.InstantaneousTotalApparentPower.ToString();
			textBox25.Text = electrical.PowerFactorA.ToString();
			textBox26.Text = electrical.PowerFactorB.ToString();
			textBox27.Text = electrical.PowerFactorC.ToString();
			textBox28.Text = electrical.TotalPowerFactor.ToString();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (timerRead)
			{
				timerRead = false;
				Timer obj = timer;
				if (obj != null)
				{
					obj.Dispose();
				}
				button4.Text = "定时读取";
			}
			else
			{
				timerRead = true;
				timer = new Timer();
				timer.Interval = int.Parse(textBox12.Text);
				timer.Tick += Timer_Tick;
				timer.Start();
				button4.Text = "Stop";
			}
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			OperateResult<ElectricalParameters> operateResult = delixi.ReadElectricalParameters();
			if (operateResult.IsSuccess)
			{
				ShowElectrical(operateResult.Content);
				hslCurve1.AddCurveData(new string[4]
				{
					"电压A",
					"电压B",
					"电压C",
					"频率"
				}, new float[4]
				{
					operateResult.Content.VoltageA,
					operateResult.Content.VoltageB,
					operateResult.Content.VoltageC,
					operateResult.Content.Frequency
				});
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
			checkBox5 = new System.Windows.Forms.CheckBox();
			comboBox3 = new System.Windows.Forms.ComboBox();
			comboBox2 = new System.Windows.Forms.ComboBox();
			comboBox1 = new System.Windows.Forms.ComboBox();
			textBox17 = new System.Windows.Forms.TextBox();
			label23 = new System.Windows.Forms.Label();
			textBox16 = new System.Windows.Forms.TextBox();
			label22 = new System.Windows.Forms.Label();
			checkBox1 = new System.Windows.Forms.CheckBox();
			textBox15 = new System.Windows.Forms.TextBox();
			label21 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			checkBox3 = new System.Windows.Forms.CheckBox();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox5 = new System.Windows.Forms.GroupBox();
			label53 = new System.Windows.Forms.Label();
			textBox12 = new System.Windows.Forms.TextBox();
			label54 = new System.Windows.Forms.Label();
			button4 = new System.Windows.Forms.Button();
			hslCurve1 = new HslControls.HslCurve();
			label51 = new System.Windows.Forms.Label();
			textBox28 = new System.Windows.Forms.TextBox();
			label52 = new System.Windows.Forms.Label();
			label49 = new System.Windows.Forms.Label();
			textBox27 = new System.Windows.Forms.TextBox();
			label50 = new System.Windows.Forms.Label();
			label47 = new System.Windows.Forms.Label();
			textBox26 = new System.Windows.Forms.TextBox();
			label48 = new System.Windows.Forms.Label();
			label45 = new System.Windows.Forms.Label();
			textBox25 = new System.Windows.Forms.TextBox();
			label46 = new System.Windows.Forms.Label();
			label43 = new System.Windows.Forms.Label();
			textBox24 = new System.Windows.Forms.TextBox();
			label44 = new System.Windows.Forms.Label();
			label41 = new System.Windows.Forms.Label();
			textBox23 = new System.Windows.Forms.TextBox();
			label42 = new System.Windows.Forms.Label();
			label39 = new System.Windows.Forms.Label();
			textBox22 = new System.Windows.Forms.TextBox();
			label40 = new System.Windows.Forms.Label();
			label37 = new System.Windows.Forms.Label();
			textBox21 = new System.Windows.Forms.TextBox();
			label38 = new System.Windows.Forms.Label();
			label35 = new System.Windows.Forms.Label();
			textBox20 = new System.Windows.Forms.TextBox();
			label36 = new System.Windows.Forms.Label();
			label33 = new System.Windows.Forms.Label();
			textBox19 = new System.Windows.Forms.TextBox();
			label34 = new System.Windows.Forms.Label();
			label31 = new System.Windows.Forms.Label();
			textBox18 = new System.Windows.Forms.TextBox();
			label32 = new System.Windows.Forms.Label();
			label29 = new System.Windows.Forms.Label();
			textBox14 = new System.Windows.Forms.TextBox();
			label30 = new System.Windows.Forms.Label();
			label27 = new System.Windows.Forms.Label();
			textBox13 = new System.Windows.Forms.TextBox();
			label28 = new System.Windows.Forms.Label();
			label25 = new System.Windows.Forms.Label();
			textBox11 = new System.Windows.Forms.TextBox();
			label26 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			textBox10 = new System.Windows.Forms.TextBox();
			label20 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			textBox9 = new System.Windows.Forms.TextBox();
			label18 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			textBox8 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			textBox7 = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox5.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(checkBox5);
			panel1.Controls.Add(comboBox3);
			panel1.Controls.Add(comboBox2);
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(textBox17);
			panel1.Controls.Add(label23);
			panel1.Controls.Add(textBox16);
			panel1.Controls.Add(label22);
			panel1.Controls.Add(checkBox1);
			panel1.Controls.Add(textBox15);
			panel1.Controls.Add(label21);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(label24);
			panel1.Controls.Add(checkBox3);
			panel1.Location = new System.Drawing.Point(5, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 64);
			panel1.TabIndex = 0;
			checkBox5.AutoSize = true;
			checkBox5.Location = new System.Drawing.Point(298, 34);
			checkBox5.Name = "checkBox5";
			checkBox5.Size = new System.Drawing.Size(84, 21);
			checkBox5.TabIndex = 30;
			checkBox5.Text = "RtsEnable";
			checkBox5.UseVisualStyleBackColor = true;
			comboBox3.FormattingEnabled = true;
			comboBox3.Location = new System.Drawing.Point(61, 3);
			comboBox3.Name = "comboBox3";
			comboBox3.Size = new System.Drawing.Size(67, 25);
			comboBox3.TabIndex = 29;
			comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox2.FormattingEnabled = true;
			comboBox2.Items.AddRange(new object[4]
			{
				"ABCD",
				"BADC",
				"CDAB",
				"DCBA"
			});
			comboBox2.Location = new System.Drawing.Point(388, 32);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new System.Drawing.Size(83, 25);
			comboBox2.TabIndex = 28;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[3]
			{
				"无",
				"奇",
				"偶"
			});
			comboBox1.Location = new System.Drawing.Point(605, 3);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(90, 25);
			comboBox1.TabIndex = 15;
			textBox17.Location = new System.Drawing.Point(490, 3);
			textBox17.Name = "textBox17";
			textBox17.Size = new System.Drawing.Size(23, 23);
			textBox17.TabIndex = 13;
			textBox17.Text = "1";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(418, 6);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(56, 17);
			label23.TabIndex = 12;
			label23.Text = "停止位：";
			textBox16.Location = new System.Drawing.Point(370, 3);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(24, 23);
			textBox16.TabIndex = 11;
			textBox16.Text = "8";
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(295, 6);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(56, 17);
			label22.TabIndex = 10;
			label22.Text = "数据位：";
			checkBox1.AutoSize = true;
			checkBox1.Checked = true;
			checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox1.Location = new System.Drawing.Point(117, 34);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(106, 21);
			checkBox1.TabIndex = 9;
			checkBox1.Text = "首地址从0开始";
			checkBox1.UseVisualStyleBackColor = true;
			textBox15.Location = new System.Drawing.Point(52, 32);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(37, 23);
			textBox15.TabIndex = 7;
			textBox15.Text = "1";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(8, 35);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(44, 17);
			label21.TabIndex = 6;
			label21.Text = "站号：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(863, 15);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭串口";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(748, 15);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "打开串口";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(211, 3);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(47, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "2400";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(143, 6);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "波特率：";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 6);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(59, 17);
			label1.TabIndex = 0;
			label1.Text = "Com口：";
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(567, 6);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(44, 17);
			label24.TabIndex = 14;
			label24.Text = "奇偶：";
			checkBox3.AutoSize = true;
			checkBox3.Location = new System.Drawing.Point(477, 35);
			checkBox3.Name = "checkBox3";
			checkBox3.Size = new System.Drawing.Size(87, 21);
			checkBox3.TabIndex = 26;
			checkBox3.Text = "字符串颠倒";
			checkBox3.UseVisualStyleBackColor = true;
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteOp1);
			panel2.Controls.Add(groupBox5);
			panel2.Location = new System.Drawing.Point(5, 103);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 540);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Location = new System.Drawing.Point(4, 2);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(988, 240);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox5.Controls.Add(label53);
			groupBox5.Controls.Add(textBox12);
			groupBox5.Controls.Add(label54);
			groupBox5.Controls.Add(button4);
			groupBox5.Controls.Add(hslCurve1);
			groupBox5.Controls.Add(label51);
			groupBox5.Controls.Add(textBox28);
			groupBox5.Controls.Add(label52);
			groupBox5.Controls.Add(label49);
			groupBox5.Controls.Add(textBox27);
			groupBox5.Controls.Add(label50);
			groupBox5.Controls.Add(label47);
			groupBox5.Controls.Add(textBox26);
			groupBox5.Controls.Add(label48);
			groupBox5.Controls.Add(label45);
			groupBox5.Controls.Add(textBox25);
			groupBox5.Controls.Add(label46);
			groupBox5.Controls.Add(label43);
			groupBox5.Controls.Add(textBox24);
			groupBox5.Controls.Add(label44);
			groupBox5.Controls.Add(label41);
			groupBox5.Controls.Add(textBox23);
			groupBox5.Controls.Add(label42);
			groupBox5.Controls.Add(label39);
			groupBox5.Controls.Add(textBox22);
			groupBox5.Controls.Add(label40);
			groupBox5.Controls.Add(label37);
			groupBox5.Controls.Add(textBox21);
			groupBox5.Controls.Add(label38);
			groupBox5.Controls.Add(label35);
			groupBox5.Controls.Add(textBox20);
			groupBox5.Controls.Add(label36);
			groupBox5.Controls.Add(label33);
			groupBox5.Controls.Add(textBox19);
			groupBox5.Controls.Add(label34);
			groupBox5.Controls.Add(label31);
			groupBox5.Controls.Add(textBox18);
			groupBox5.Controls.Add(label32);
			groupBox5.Controls.Add(label29);
			groupBox5.Controls.Add(textBox14);
			groupBox5.Controls.Add(label30);
			groupBox5.Controls.Add(label27);
			groupBox5.Controls.Add(textBox13);
			groupBox5.Controls.Add(label28);
			groupBox5.Controls.Add(label25);
			groupBox5.Controls.Add(textBox11);
			groupBox5.Controls.Add(label26);
			groupBox5.Controls.Add(label19);
			groupBox5.Controls.Add(textBox10);
			groupBox5.Controls.Add(label20);
			groupBox5.Controls.Add(label17);
			groupBox5.Controls.Add(textBox9);
			groupBox5.Controls.Add(label18);
			groupBox5.Controls.Add(label10);
			groupBox5.Controls.Add(label11);
			groupBox5.Controls.Add(label12);
			groupBox5.Controls.Add(label13);
			groupBox5.Controls.Add(label14);
			groupBox5.Controls.Add(label15);
			groupBox5.Controls.Add(label16);
			groupBox5.Controls.Add(textBox8);
			groupBox5.Controls.Add(label9);
			groupBox5.Controls.Add(textBox7);
			groupBox5.Controls.Add(label8);
			groupBox5.Controls.Add(textBox6);
			groupBox5.Controls.Add(label7);
			groupBox5.Controls.Add(textBox5);
			groupBox5.Controls.Add(label6);
			groupBox5.Controls.Add(textBox4);
			groupBox5.Controls.Add(label5);
			groupBox5.Controls.Add(textBox3);
			groupBox5.Controls.Add(label4);
			groupBox5.Controls.Add(textBox1);
			groupBox5.Controls.Add(label2);
			groupBox5.Controls.Add(button3);
			groupBox5.Location = new System.Drawing.Point(5, 243);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(987, 290);
			groupBox5.TabIndex = 4;
			groupBox5.TabStop = false;
			groupBox5.Text = "特殊功能测试";
			label53.AutoSize = true;
			label53.Location = new System.Drawing.Point(786, 32);
			label53.Name = "label53";
			label53.Size = new System.Drawing.Size(25, 17);
			label53.TabIndex = 86;
			label53.Text = "ms";
			textBox12.Location = new System.Drawing.Point(705, 29);
			textBox12.Name = "textBox12";
			textBox12.Size = new System.Drawing.Size(78, 23);
			textBox12.TabIndex = 85;
			textBox12.Text = "1000";
			label54.AutoSize = true;
			label54.Location = new System.Drawing.Point(659, 32);
			label54.Name = "label54";
			label54.Size = new System.Drawing.Size(32, 17);
			label54.TabIndex = 84;
			label54.Text = "间隔";
			button4.Location = new System.Drawing.Point(837, 26);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(91, 28);
			button4.TabIndex = 83;
			button4.Text = "定时读取";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			hslCurve1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			hslCurve1.BackColor = System.Drawing.Color.White;
			hslCurve1.Location = new System.Drawing.Point(594, 62);
			hslCurve1.Name = "hslCurve1";
			hslCurve1.Size = new System.Drawing.Size(387, 222);
			hslCurve1.TabIndex = 82;
			hslCurve1.ValueMaxLeft = 250f;
			label51.AutoSize = true;
			label51.Location = new System.Drawing.Point(561, 242);
			label51.Name = "label51";
			label51.Size = new System.Drawing.Size(0, 17);
			label51.TabIndex = 81;
			textBox28.Location = new System.Drawing.Point(480, 239);
			textBox28.Name = "textBox28";
			textBox28.Size = new System.Drawing.Size(78, 23);
			textBox28.TabIndex = 80;
			label52.AutoSize = true;
			label52.Location = new System.Drawing.Point(387, 242);
			label52.Name = "label52";
			label52.Size = new System.Drawing.Size(80, 17);
			label52.TabIndex = 79;
			label52.Text = "总相功率因数";
			label49.AutoSize = true;
			label49.Location = new System.Drawing.Point(561, 212);
			label49.Name = "label49";
			label49.Size = new System.Drawing.Size(0, 17);
			label49.TabIndex = 78;
			textBox27.Location = new System.Drawing.Point(480, 209);
			textBox27.Name = "textBox27";
			textBox27.Size = new System.Drawing.Size(78, 23);
			textBox27.TabIndex = 77;
			label50.AutoSize = true;
			label50.Location = new System.Drawing.Point(387, 212);
			label50.Name = "label50";
			label50.Size = new System.Drawing.Size(76, 17);
			label50.TabIndex = 76;
			label50.Text = "C相功率因数";
			label47.AutoSize = true;
			label47.Location = new System.Drawing.Point(561, 184);
			label47.Name = "label47";
			label47.Size = new System.Drawing.Size(0, 17);
			label47.TabIndex = 75;
			textBox26.Location = new System.Drawing.Point(480, 181);
			textBox26.Name = "textBox26";
			textBox26.Size = new System.Drawing.Size(78, 23);
			textBox26.TabIndex = 74;
			label48.AutoSize = true;
			label48.Location = new System.Drawing.Point(387, 184);
			label48.Name = "label48";
			label48.Size = new System.Drawing.Size(76, 17);
			label48.TabIndex = 73;
			label48.Text = "B相功率因数";
			label45.AutoSize = true;
			label45.Location = new System.Drawing.Point(560, 153);
			label45.Name = "label45";
			label45.Size = new System.Drawing.Size(0, 17);
			label45.TabIndex = 72;
			textBox25.Location = new System.Drawing.Point(479, 150);
			textBox25.Name = "textBox25";
			textBox25.Size = new System.Drawing.Size(78, 23);
			textBox25.TabIndex = 71;
			label46.AutoSize = true;
			label46.Location = new System.Drawing.Point(386, 153);
			label46.Name = "label46";
			label46.Size = new System.Drawing.Size(76, 17);
			label46.TabIndex = 70;
			label46.Text = "A相功率因数";
			label43.AutoSize = true;
			label43.Location = new System.Drawing.Point(560, 122);
			label43.Name = "label43";
			label43.Size = new System.Drawing.Size(31, 17);
			label43.TabIndex = 69;
			label43.Text = "kVA";
			textBox24.Location = new System.Drawing.Point(479, 119);
			textBox24.Name = "textBox24";
			textBox24.Size = new System.Drawing.Size(78, 23);
			textBox24.TabIndex = 68;
			label44.AutoSize = true;
			label44.Location = new System.Drawing.Point(386, 122);
			label44.Name = "label44";
			label44.Size = new System.Drawing.Size(92, 17);
			label44.TabIndex = 67;
			label44.Text = "瞬时总视在功率";
			label41.AutoSize = true;
			label41.Location = new System.Drawing.Point(560, 92);
			label41.Name = "label41";
			label41.Size = new System.Drawing.Size(31, 17);
			label41.TabIndex = 66;
			label41.Text = "kVA";
			textBox23.Location = new System.Drawing.Point(479, 89);
			textBox23.Name = "textBox23";
			textBox23.Size = new System.Drawing.Size(78, 23);
			textBox23.TabIndex = 65;
			label42.AutoSize = true;
			label42.Location = new System.Drawing.Point(386, 92);
			label42.Name = "label42";
			label42.Size = new System.Drawing.Size(88, 17);
			label42.TabIndex = 64;
			label42.Text = "瞬时C视在功率";
			label39.AutoSize = true;
			label39.Location = new System.Drawing.Point(560, 62);
			label39.Name = "label39";
			label39.Size = new System.Drawing.Size(31, 17);
			label39.TabIndex = 63;
			label39.Text = "kVA";
			textBox22.Location = new System.Drawing.Point(479, 59);
			textBox22.Name = "textBox22";
			textBox22.Size = new System.Drawing.Size(78, 23);
			textBox22.TabIndex = 62;
			label40.AutoSize = true;
			label40.Location = new System.Drawing.Point(386, 62);
			label40.Name = "label40";
			label40.Size = new System.Drawing.Size(88, 17);
			label40.TabIndex = 61;
			label40.Text = "瞬时B视在功率";
			label37.AutoSize = true;
			label37.Location = new System.Drawing.Point(560, 32);
			label37.Name = "label37";
			label37.Size = new System.Drawing.Size(31, 17);
			label37.TabIndex = 60;
			label37.Text = "kVA";
			textBox21.Location = new System.Drawing.Point(479, 29);
			textBox21.Name = "textBox21";
			textBox21.Size = new System.Drawing.Size(78, 23);
			textBox21.TabIndex = 59;
			label38.AutoSize = true;
			label38.Location = new System.Drawing.Point(386, 32);
			label38.Name = "label38";
			label38.Size = new System.Drawing.Size(88, 17);
			label38.TabIndex = 58;
			label38.Text = "瞬时A视在功率";
			label35.AutoSize = true;
			label35.Location = new System.Drawing.Point(343, 242);
			label35.Name = "label35";
			label35.Size = new System.Drawing.Size(33, 17);
			label35.TabIndex = 57;
			label35.Text = "kvar";
			textBox20.Location = new System.Drawing.Point(262, 239);
			textBox20.Name = "textBox20";
			textBox20.Size = new System.Drawing.Size(78, 23);
			textBox20.TabIndex = 56;
			label36.AutoSize = true;
			label36.Location = new System.Drawing.Point(169, 242);
			label36.Name = "label36";
			label36.Size = new System.Drawing.Size(92, 17);
			label36.TabIndex = 55;
			label36.Text = "瞬时总无功功率";
			label33.AutoSize = true;
			label33.Location = new System.Drawing.Point(343, 212);
			label33.Name = "label33";
			label33.Size = new System.Drawing.Size(33, 17);
			label33.TabIndex = 54;
			label33.Text = "kvar";
			textBox19.Location = new System.Drawing.Point(262, 209);
			textBox19.Name = "textBox19";
			textBox19.Size = new System.Drawing.Size(78, 23);
			textBox19.TabIndex = 53;
			label34.AutoSize = true;
			label34.Location = new System.Drawing.Point(169, 212);
			label34.Name = "label34";
			label34.Size = new System.Drawing.Size(88, 17);
			label34.TabIndex = 52;
			label34.Text = "瞬时C无功功率";
			label31.AutoSize = true;
			label31.Location = new System.Drawing.Point(343, 182);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(33, 17);
			label31.TabIndex = 51;
			label31.Text = "kvar";
			textBox18.Location = new System.Drawing.Point(262, 179);
			textBox18.Name = "textBox18";
			textBox18.Size = new System.Drawing.Size(78, 23);
			textBox18.TabIndex = 50;
			label32.AutoSize = true;
			label32.Location = new System.Drawing.Point(169, 182);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(88, 17);
			label32.TabIndex = 49;
			label32.Text = "瞬时B无功功率";
			label29.AutoSize = true;
			label29.Location = new System.Drawing.Point(343, 154);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(33, 17);
			label29.TabIndex = 48;
			label29.Text = "kvar";
			textBox14.Location = new System.Drawing.Point(262, 151);
			textBox14.Name = "textBox14";
			textBox14.Size = new System.Drawing.Size(78, 23);
			textBox14.TabIndex = 47;
			label30.AutoSize = true;
			label30.Location = new System.Drawing.Point(169, 154);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(88, 17);
			label30.TabIndex = 46;
			label30.Text = "瞬时A无功功率";
			label27.AutoSize = true;
			label27.Location = new System.Drawing.Point(343, 123);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(24, 17);
			label27.TabIndex = 45;
			label27.Text = "kw";
			textBox13.Location = new System.Drawing.Point(262, 120);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(78, 23);
			textBox13.TabIndex = 44;
			label28.AutoSize = true;
			label28.Location = new System.Drawing.Point(169, 123);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(92, 17);
			label28.TabIndex = 43;
			label28.Text = "瞬时总有功功率";
			label25.AutoSize = true;
			label25.Location = new System.Drawing.Point(343, 92);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(24, 17);
			label25.TabIndex = 42;
			label25.Text = "kw";
			textBox11.Location = new System.Drawing.Point(262, 89);
			textBox11.Name = "textBox11";
			textBox11.Size = new System.Drawing.Size(78, 23);
			textBox11.TabIndex = 41;
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(169, 92);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(88, 17);
			label26.TabIndex = 40;
			label26.Text = "瞬时C有功功率";
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(343, 62);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(24, 17);
			label19.TabIndex = 39;
			label19.Text = "kw";
			textBox10.Location = new System.Drawing.Point(262, 59);
			textBox10.Name = "textBox10";
			textBox10.Size = new System.Drawing.Size(78, 23);
			textBox10.TabIndex = 38;
			label20.AutoSize = true;
			label20.Location = new System.Drawing.Point(169, 62);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(88, 17);
			label20.TabIndex = 37;
			label20.Text = "瞬时B有功功率";
			label17.AutoSize = true;
			label17.Location = new System.Drawing.Point(343, 32);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(24, 17);
			label17.TabIndex = 36;
			label17.Text = "kw";
			textBox9.Location = new System.Drawing.Point(262, 29);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(78, 23);
			textBox9.TabIndex = 35;
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(169, 32);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(88, 17);
			label18.TabIndex = 34;
			label18.Text = "瞬时A有功功率";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(141, 242);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(23, 17);
			label10.TabIndex = 33;
			label10.Text = "Hz";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(141, 212);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(16, 17);
			label11.TabIndex = 32;
			label11.Text = "A";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(141, 184);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(16, 17);
			label12.TabIndex = 31;
			label12.Text = "A";
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(141, 153);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(16, 17);
			label13.TabIndex = 30;
			label13.Text = "A";
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(141, 122);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(16, 17);
			label14.TabIndex = 29;
			label14.Text = "V";
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(141, 92);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(16, 17);
			label15.TabIndex = 28;
			label15.Text = "V";
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(141, 62);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(16, 17);
			label16.TabIndex = 27;
			label16.Text = "V";
			textBox8.Location = new System.Drawing.Point(60, 239);
			textBox8.Name = "textBox8";
			textBox8.Size = new System.Drawing.Size(78, 23);
			textBox8.TabIndex = 26;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(14, 242);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(32, 17);
			label9.TabIndex = 25;
			label9.Text = "频率";
			textBox7.Location = new System.Drawing.Point(60, 209);
			textBox7.Name = "textBox7";
			textBox7.Size = new System.Drawing.Size(78, 23);
			textBox7.TabIndex = 24;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(14, 212);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(40, 17);
			label8.TabIndex = 23;
			label8.Text = "电流C";
			textBox6.Location = new System.Drawing.Point(60, 181);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(78, 23);
			textBox6.TabIndex = 22;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(14, 184);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(40, 17);
			label7.TabIndex = 21;
			label7.Text = "电流B";
			textBox5.Location = new System.Drawing.Point(60, 150);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(78, 23);
			textBox5.TabIndex = 20;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(14, 153);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(40, 17);
			label6.TabIndex = 19;
			label6.Text = "电流A";
			textBox4.Location = new System.Drawing.Point(60, 119);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(78, 23);
			textBox4.TabIndex = 18;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(14, 122);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(40, 17);
			label5.TabIndex = 17;
			label5.Text = "电压C";
			textBox3.Location = new System.Drawing.Point(60, 89);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(78, 23);
			textBox3.TabIndex = 16;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(14, 92);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(40, 17);
			label4.TabIndex = 15;
			label4.Text = "电压B";
			textBox1.Location = new System.Drawing.Point(60, 59);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(78, 23);
			textBox1.TabIndex = 14;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(14, 62);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(40, 17);
			label2.TabIndex = 13;
			label2.Text = "电压A";
			button3.Location = new System.Drawing.Point(41, 22);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(91, 28);
			button3.TabIndex = 12;
			button3.Text = "读取电表";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/8974215.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Modbus Rtu";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
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
			base.Name = "FormDTSU6606";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "DTSU6606";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			ResumeLayout(false);
		}
	}
}
