using HslCommunication;
using HslCommunication.Core;
using HslCommunication.Instrument.Temperature;
using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormDAM3601 : HslFormContent
	{
		private DAM3601 dAM3601 = null;

		private List<TextBox> allTextBox = new List<TextBox>();

		private IContainer components = null;

		private Panel panel1;

		private Label label1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private GroupBox groupBox1;

		private Button button_read_bool;

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

		public FormDAM3601()
		{
			InitializeComponent();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			comboBox1.SelectedIndex = 0;
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
			int num = 1;
			for (int i = 0; i < 16; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					Label label = new Label();
					label.Text = "温度" + num.ToString();
					label.AutoSize = true;
					TextBox textBox = new TextBox();
					textBox.Width = 50;
					label.Parent = groupBox1;
					label.Location = new Point(j * 115 + 5, i * 25 + 72);
					textBox.Parent = groupBox1;
					textBox.Location = new Point(j * 115 + 60, i * 25 + 70);
					allTextBox.Add(textBox);
					num++;
				}
			}
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "Modbus Rtu Read Demo";
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
				button_read_bool.Text = "r-coil";
				groupBox1.Text = "read test";
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
			if (dAM3601 != null)
			{
				dAM3601.IsStringReverse = checkBox3.Checked;
			}
		}

		private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (dAM3601 != null)
			{
				switch (comboBox2.SelectedIndex)
				{
				case 0:
					dAM3601.DataFormat = DataFormat.ABCD;
					break;
				case 1:
					dAM3601.DataFormat = DataFormat.BADC;
					break;
				case 2:
					dAM3601.DataFormat = DataFormat.CDAB;
					break;
				case 3:
					dAM3601.DataFormat = DataFormat.DCBA;
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
				MessageBox.Show("波特率输入错误！");
			}
			else if (!int.TryParse(textBox16.Text, out dataBits))
			{
				MessageBox.Show("数据位输入错误！");
			}
			else if (!int.TryParse(textBox17.Text, out stopBits))
			{
				MessageBox.Show("停止位输入错误！");
			}
			else if (!byte.TryParse(textBox15.Text, out result))
			{
				MessageBox.Show("站号输入不正确！");
			}
			else
			{
				DAM3601 obj = dAM3601;
				if (obj != null)
				{
					obj.Close();
				}
				dAM3601 = new DAM3601(result);
				dAM3601.AddressStartWithZero = checkBox1.Checked;
				dAM3601.LogNet = base.LogNet;
				ComboBox2_SelectedIndexChanged(null, new EventArgs());
				dAM3601.IsStringReverse = checkBox3.Checked;
				try
				{
					dAM3601.SerialPortInni(delegate(SerialPort sp)
					{
						sp.PortName = comboBox3.Text;
						sp.BaudRate = baudRate;
						sp.DataBits = dataBits;
						sp.StopBits = ((stopBits != 0) ? ((stopBits == 1) ? StopBits.One : StopBits.Two) : StopBits.None);
						sp.Parity = ((comboBox1.SelectedIndex != 0) ? ((comboBox1.SelectedIndex == 1) ? Parity.Odd : Parity.Even) : Parity.None);
					});
					dAM3601.Open();
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

		private void button2_Click(object sender, EventArgs e)
		{
			dAM3601.Close();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button_read_bool_Click(object sender, EventArgs e)
		{
			OperateResult<float[]> operateResult = dAM3601.ReadAllTemperature();
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("读取失败！原因：" + operateResult.Message);
			}
			else
			{
				for (int i = 0; i < allTextBox.Count; i++)
				{
					allTextBox[i].Text = operateResult.Content[i].ToString();
				}
			}
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
			groupBox1 = new System.Windows.Forms.GroupBox();
			button_read_bool = new System.Windows.Forms.Button();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
			panel1.Location = new System.Drawing.Point(12, 40);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(978, 65);
			panel1.TabIndex = 0;
			comboBox3.FormattingEnabled = true;
			comboBox3.Location = new System.Drawing.Point(61, 14);
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
			comboBox2.Location = new System.Drawing.Point(539, 35);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new System.Drawing.Size(111, 25);
			comboBox2.TabIndex = 28;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[3]
			{
				"无",
				"奇",
				"偶"
			});
			comboBox1.Location = new System.Drawing.Point(466, 14);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(57, 25);
			comboBox1.TabIndex = 15;
			textBox17.Location = new System.Drawing.Point(386, 14);
			textBox17.Name = "textBox17";
			textBox17.Size = new System.Drawing.Size(23, 23);
			textBox17.TabIndex = 13;
			textBox17.Text = "1";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(329, 17);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(56, 17);
			label23.TabIndex = 12;
			label23.Text = "停止位：";
			textBox16.Location = new System.Drawing.Point(295, 14);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(24, 23);
			textBox16.TabIndex = 11;
			textBox16.Text = "8";
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(238, 17);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(56, 17);
			label22.TabIndex = 10;
			label22.Text = "数据位：";
			checkBox1.AutoSize = true;
			checkBox1.Checked = true;
			checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox1.Location = new System.Drawing.Point(630, 7);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(106, 21);
			checkBox1.TabIndex = 9;
			checkBox1.Text = "首地址从0开始";
			checkBox1.UseVisualStyleBackColor = true;
			textBox15.Location = new System.Drawing.Point(579, 5);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(37, 23);
			textBox15.TabIndex = 7;
			textBox15.Text = "1";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(535, 8);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(44, 17);
			label21.TabIndex = 6;
			label21.Text = "站号：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(875, 11);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭串口";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(778, 11);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "打开串口";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(188, 14);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(47, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "9600";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(131, 17);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "波特率：";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 17);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(59, 17);
			label1.TabIndex = 0;
			label1.Text = "Com口：";
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(416, 17);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(44, 17);
			label24.TabIndex = 14;
			label24.Text = "奇偶：";
			checkBox3.AutoSize = true;
			checkBox3.Location = new System.Drawing.Point(656, 38);
			checkBox3.Name = "checkBox3";
			checkBox3.Size = new System.Drawing.Size(87, 21);
			checkBox3.TabIndex = 26;
			checkBox3.Text = "字符串颠倒";
			checkBox3.UseVisualStyleBackColor = true;
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(groupBox1);
			panel2.Location = new System.Drawing.Point(12, 113);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(983, 529);
			panel2.TabIndex = 1;
			groupBox1.Controls.Add(button_read_bool);
			groupBox1.Location = new System.Drawing.Point(11, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(945, 515);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "单数据读取测试";
			button_read_bool.Location = new System.Drawing.Point(23, 31);
			button_read_bool.Name = "button_read_bool";
			button_read_bool.Size = new System.Drawing.Size(127, 28);
			button_read_bool.TabIndex = 6;
			button_read_bool.Text = "温度数据读取";
			button_read_bool.UseVisualStyleBackColor = true;
			button_read_bool.Click += new System.EventHandler(button_read_bool_Click);
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/8974215.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Modbus rtu";
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
			base.Name = "FormDAM3601";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Modbus Rtu访问Demo";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
