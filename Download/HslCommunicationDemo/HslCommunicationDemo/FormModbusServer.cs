using HslCommunication.Core;
using HslCommunication.Core.Net;
using HslCommunication.ModBus;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormModbusServer : HslFormContent
	{
		private ModbusTcpServer busTcpServer;

		private IContainer components = null;

		private Panel panel1;

		private Panel panel2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private Button button3;

		private Button button5;

		private TextBox textBox10;

		private Label label14;

		private CheckBox checkBox3;

		private Button button11;

		private ComboBox comboBox2;

		private UserControlHead userControlHead1;

		private CheckBox checkBox_account;

		private UserControlReadWriteServer userControlReadWriteServer1;

		private CheckBox checkBox_remote_write;

		private CheckBox checkBox4;

		private CheckBox checkBox_ipv6;

		private TextBox textBox3;

		private Label label2;

		private CheckBox checkBox_station_isolation;

		private TextBox textBox_station;

		private Label label1;

		private CheckBox checkBox_forceReceiveOnce;

		public FormModbusServer()
		{
			InitializeComponent();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			comboBox2.SelectedIndex = 2;
			comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
			checkBox_remote_write.CheckedChanged += CheckBox1_CheckedChanged;
			checkBox3.CheckedChanged += CheckBox3_CheckedChanged;
			checkBox_account.CheckedChanged += CheckBox2_CheckedChanged;
			if (Program.Language == 2)
			{
				Text = "Modbus Virtual Server[supports TCP and RTU, support coil and register reading and writing, input register read, discrete input read]";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
				checkBox_account.Text = "Account Login";
				button3.Text = "filter-cli";
				label14.Text = "Com:";
				button5.Text = "Open Com";
				checkBox3.Text = "str-reverse";
				checkBox_remote_write.Text = "Whether to run remote write operation";
			}
			else
			{
				checkBox_station_isolation.Text = "站号数据隔离";
			}
		}

		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (busTcpServer != null)
			{
				busTcpServer.EnableWrite = checkBox_remote_write.Checked;
			}
		}

		private void CheckBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (busTcpServer != null)
			{
				busTcpServer.IsUseAccountCertificate = checkBox_account.Checked;
			}
		}

		private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (busTcpServer != null)
			{
				switch (comboBox2.SelectedIndex)
				{
				case 0:
					busTcpServer.DataFormat = DataFormat.ABCD;
					break;
				case 1:
					busTcpServer.DataFormat = DataFormat.BADC;
					break;
				case 2:
					busTcpServer.DataFormat = DataFormat.CDAB;
					break;
				case 3:
					busTcpServer.DataFormat = DataFormat.DCBA;
					break;
				}
			}
		}

		private void CheckBox3_CheckedChanged(object sender, EventArgs e)
		{
			if (busTcpServer != null)
			{
				busTcpServer.IsStringReverse = checkBox3.Checked;
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
			ModbusTcpServer modbusTcpServer = busTcpServer;
			if (modbusTcpServer != null)
			{
				modbusTcpServer.ServerClose();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			byte result2;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show(DemoUtils.PortInputWrong);
			}
			else if (!byte.TryParse(textBox_station.Text, out result2))
			{
				MessageBox.Show("Station input wrong!");
			}
			else
			{
				try
				{
					busTcpServer = new ModbusTcpServer();
					busTcpServer.ActiveTimeSpan = TimeSpan.FromHours(1.0);
					busTcpServer.OnDataReceived += BusTcpServer_OnDataReceived;
					busTcpServer.EnableWrite = checkBox_remote_write.Checked;
					busTcpServer.EnableIPv6 = checkBox_ipv6.Checked;
					busTcpServer.Station = result2;
					busTcpServer.StationDataIsolation = checkBox_station_isolation.Checked;
					busTcpServer.UseModbusRtuOverTcp = checkBox4.Checked;
					busTcpServer.IsUseAccountCertificate = checkBox_account.Checked;
					busTcpServer.ForceSerialReceiveOnce = checkBox_forceReceiveOnce.Checked;
					busTcpServer.AddAccount("admin", "123456");
					busTcpServer.AddAccount("hsl", "test");
					ComboBox2_SelectedIndexChanged(null, new EventArgs());
					busTcpServer.IsStringReverse = checkBox3.Checked;
					userControlReadWriteServer1.SetReadWriteServer(busTcpServer, "100");
					busTcpServer.ServerStart(result);
					button1.Enabled = false;
					panel2.Enabled = true;
					button11.Enabled = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			ModbusTcpServer modbusTcpServer = busTcpServer;
			if (modbusTcpServer != null)
			{
				modbusTcpServer.CloseSerialSlave();
			}
			ModbusTcpServer modbusTcpServer2 = busTcpServer;
			if (modbusTcpServer2 != null)
			{
				modbusTcpServer2.ServerClose();
			}
			ModbusTcpServer modbusTcpServer3 = busTcpServer;
			if (modbusTcpServer3 != null)
			{
				modbusTcpServer3.Dispose();
			}
			button1.Enabled = true;
			button5.Enabled = true;
			button11.Enabled = false;
		}

		private void BusTcpServer_OnDataReceived(object sender, object source, byte[] modbus)
		{
			AppSession appSession = source as AppSession;
			if (appSession != null)
			{
				string ipAddress = appSession.IpAddress;
			}
			SerialPort serialPort = source as SerialPort;
			if (serialPort != null)
			{
				string portName = serialPort.PortName;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (busTcpServer == null)
			{
				MessageBox.Show("Must Start Server！");
			}
			else
			{
				using (FormTrustedClient formTrustedClient = new FormTrustedClient(busTcpServer))
				{
					formTrustedClient.ShowDialog();
				}
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (busTcpServer != null)
			{
				try
				{
					busTcpServer.SerialReceiveAtleastTime = Convert.ToInt32(textBox3.Text);
					busTcpServer.StartSerialSlave(textBox10.Text);
					button5.Enabled = false;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Start Failed：" + ex.Message);
				}
			}
			else
			{
				MessageBox.Show("Start tcp server first please!");
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlCom, textBox10.Text);
			element.SetAttributeValue(DemoDeviceList.XmlDataFormat, comboBox2.SelectedIndex);
			element.SetAttributeValue(DemoDeviceList.XmlStringReverse, checkBox3.Checked);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox10.Text = element.Attribute(DemoDeviceList.XmlCom).Value;
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
			textBox_station = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			checkBox_station_isolation = new System.Windows.Forms.CheckBox();
			textBox3 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			checkBox_ipv6 = new System.Windows.Forms.CheckBox();
			checkBox4 = new System.Windows.Forms.CheckBox();
			checkBox_remote_write = new System.Windows.Forms.CheckBox();
			checkBox_account = new System.Windows.Forms.CheckBox();
			comboBox2 = new System.Windows.Forms.ComboBox();
			button11 = new System.Windows.Forms.Button();
			checkBox3 = new System.Windows.Forms.CheckBox();
			button5 = new System.Windows.Forms.Button();
			textBox10 = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteServer1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteServer();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			checkBox_forceReceiveOnce = new System.Windows.Forms.CheckBox();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(checkBox_forceReceiveOnce);
			panel1.Controls.Add(textBox_station);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(checkBox_station_isolation);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(checkBox_ipv6);
			panel1.Controls.Add(checkBox4);
			panel1.Controls.Add(checkBox_remote_write);
			panel1.Controls.Add(checkBox_account);
			panel1.Controls.Add(comboBox2);
			panel1.Controls.Add(button11);
			panel1.Controls.Add(checkBox3);
			panel1.Controls.Add(button5);
			panel1.Controls.Add(textBox10);
			panel1.Controls.Add(label14);
			panel1.Controls.Add(button3);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 61);
			panel1.TabIndex = 0;
			textBox_station.Location = new System.Drawing.Point(588, 33);
			textBox_station.Name = "textBox_station";
			textBox_station.Size = new System.Drawing.Size(28, 23);
			textBox_station.TabIndex = 40;
			textBox_station.Text = "1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(516, 36);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(60, 17);
			label1.TabIndex = 39;
			label1.Text = "Station：";
			checkBox_station_isolation.AutoSize = true;
			checkBox_station_isolation.Location = new System.Drawing.Point(295, 35);
			checkBox_station_isolation.Name = "checkBox_station_isolation";
			checkBox_station_isolation.Size = new System.Drawing.Size(127, 21);
			checkBox_station_isolation.TabIndex = 38;
			checkBox_station_isolation.Text = "Station Isolation?";
			checkBox_station_isolation.UseVisualStyleBackColor = true;
			textBox3.Location = new System.Drawing.Point(723, 32);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(39, 23);
			textBox3.TabIndex = 37;
			textBox3.Text = "20";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(622, 36);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(92, 17);
			label2.TabIndex = 36;
			label2.Text = "最短接收时间：";
			checkBox_ipv6.AutoSize = true;
			checkBox_ipv6.Location = new System.Drawing.Point(430, 35);
			checkBox_ipv6.Name = "checkBox_ipv6";
			checkBox_ipv6.Size = new System.Drawing.Size(77, 21);
			checkBox_ipv6.TabIndex = 33;
			checkBox_ipv6.Text = "Use IPv6";
			checkBox_ipv6.UseVisualStyleBackColor = true;
			checkBox4.AutoSize = true;
			checkBox4.Location = new System.Drawing.Point(6, 34);
			checkBox4.Name = "checkBox4";
			checkBox4.Size = new System.Drawing.Size(148, 21);
			checkBox4.TabIndex = 32;
			checkBox4.Text = "使用ModbusRTU报文";
			checkBox4.UseVisualStyleBackColor = true;
			checkBox_remote_write.AutoSize = true;
			checkBox_remote_write.Checked = true;
			checkBox_remote_write.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox_remote_write.Location = new System.Drawing.Point(165, 35);
			checkBox_remote_write.Name = "checkBox_remote_write";
			checkBox_remote_write.Size = new System.Drawing.Size(123, 21);
			checkBox_remote_write.TabIndex = 31;
			checkBox_remote_write.Text = "是否允许远程写入";
			checkBox_remote_write.UseVisualStyleBackColor = true;
			checkBox_account.AutoSize = true;
			checkBox_account.Location = new System.Drawing.Point(884, 35);
			checkBox_account.Name = "checkBox_account";
			checkBox_account.Size = new System.Drawing.Size(75, 21);
			checkBox_account.TabIndex = 30;
			checkBox_account.Text = "账户登录";
			checkBox_account.UseVisualStyleBackColor = true;
			comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox2.FormattingEnabled = true;
			comboBox2.Items.AddRange(new object[4]
			{
				"ABCD",
				"BADC",
				"CDAB",
				"DCBA"
			});
			comboBox2.Location = new System.Drawing.Point(726, 4);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new System.Drawing.Size(142, 25);
			comboBox2.TabIndex = 29;
			button11.Enabled = false;
			button11.Location = new System.Drawing.Point(218, 3);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(83, 28);
			button11.TabIndex = 28;
			button11.Text = "关闭服务";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			checkBox3.AutoSize = true;
			checkBox3.Location = new System.Drawing.Point(884, 9);
			checkBox3.Name = "checkBox3";
			checkBox3.Size = new System.Drawing.Size(87, 21);
			checkBox3.TabIndex = 27;
			checkBox3.Text = "字符串颠倒";
			checkBox3.UseVisualStyleBackColor = true;
			button5.Location = new System.Drawing.Point(622, 3);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(91, 28);
			button5.TabIndex = 9;
			button5.Text = "启动串口";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			textBox10.Location = new System.Drawing.Point(461, 6);
			textBox10.Name = "textBox10";
			textBox10.Size = new System.Drawing.Size(155, 23);
			textBox10.TabIndex = 8;
			textBox10.Text = "COM4-9600-8-N-1";
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(415, 9);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 7;
			label14.Text = "串口：";
			button3.Location = new System.Drawing.Point(309, 3);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(102, 28);
			button3.TabIndex = 5;
			button3.Text = "客户端过滤";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button1.Location = new System.Drawing.Point(128, 3);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(83, 28);
			button1.TabIndex = 4;
			button1.Text = "启动服务";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(57, 6);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(65, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "502";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(3, 9);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteServer1);
			panel2.Location = new System.Drawing.Point(3, 100);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 541);
			panel2.TabIndex = 1;
			userControlReadWriteServer1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteServer1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlReadWriteServer1.Location = new System.Drawing.Point(3, 0);
			userControlReadWriteServer1.Name = "userControlReadWriteServer1";
			userControlReadWriteServer1.Size = new System.Drawing.Size(989, 536);
			userControlReadWriteServer1.TabIndex = 0;
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7782315.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Modbus Tcp + Rtu + Ascii";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 2;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			checkBox_forceReceiveOnce.AutoSize = true;
			checkBox_forceReceiveOnce.Location = new System.Drawing.Point(768, 34);
			checkBox_forceReceiveOnce.Name = "checkBox_forceReceiveOnce";
			checkBox_forceReceiveOnce.Size = new System.Drawing.Size(107, 21);
			checkBox_forceReceiveOnce.TabIndex = 41;
			checkBox_forceReceiveOnce.Text = "ReceiveOnce?";
			checkBox_forceReceiveOnce.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormModbusServer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Modbus虚拟服务器【同时支持Tcp和Rtu模式的服务器，数据支持线圈读写和寄存器读写，输入寄存器读取，离散输入读取】";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
