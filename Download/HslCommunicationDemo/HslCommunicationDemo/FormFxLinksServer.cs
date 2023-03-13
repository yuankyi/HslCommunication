using HslCommunication.Core.Net;
using HslCommunication.Profinet.Melsec;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormFxLinksServer : HslFormContent
	{
		private MelsecFxLinksServer fxLinksServer;

		private IContainer components = null;

		private Panel panel1;

		private Panel panel2;

		private Button button1;

		private TextBox textBox_port;

		private Label label3;

		private Button button11;

		private Label label11;

		private UserControlHead userControlHead1;

		private CheckBox checkBox_sumCheck;

		private UserControlReadWriteServer userControlReadWriteServer1;

		private Label label1;

		private ComboBox comboBox_serialPort;

		private Button button5;

		private Label label14;

		private ComboBox comboBox_format;

		private TextBox textBox_station;

		private Label label4;

		private TextBox textBox1;

		private Label label5;

		public FormFxLinksServer()
		{
			InitializeComponent();
			fxLinksServer = new MelsecFxLinksServer();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			comboBox_format.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
			comboBox_format.SelectedIndex = 0;
			comboBox_serialPort.DataSource = SerialPort.GetPortNames();
			if (Program.Language == 2)
			{
				Text = "MC Virtual Server [data support, bool: x,y,m   word: x,y,m,d,w]";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
				label11.Text = "This server is not a strict mc protocol and only supports perfect communication with HSL components.";
				label4.Text = "Station:";
				label5.Text = "Para:";
				label1.Text = "Format:";
			}
			checkBox_sumCheck.CheckedChanged += CheckBox2_CheckedChanged;
		}

		private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (fxLinksServer != null)
			{
				fxLinksServer.Format = int.Parse(comboBox_format.SelectedItem.ToString());
			}
		}

		private void CheckBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (fxLinksServer != null)
			{
				fxLinksServer.SumCheck = checkBox_sumCheck.Checked;
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
			MelsecFxLinksServer melsecFxLinksServer = fxLinksServer;
			if (melsecFxLinksServer != null)
			{
				melsecFxLinksServer.ServerClose();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox_port.Text, out result))
			{
				MessageBox.Show(DemoUtils.PortInputWrong);
			}
			else
			{
				try
				{
					fxLinksServer.SumCheck = checkBox_sumCheck.Checked;
					fxLinksServer.Format = int.Parse(comboBox_format.SelectedItem.ToString());
					fxLinksServer.ActiveTimeSpan = TimeSpan.FromHours(1.0);
					fxLinksServer.Station = byte.Parse(textBox_station.Text);
					fxLinksServer.ServerStart(result);
					userControlReadWriteServer1.SetReadWriteServer(fxLinksServer, "D100");
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

		private void button5_Click(object sender, EventArgs e)
		{
			if (fxLinksServer != null)
			{
				fxLinksServer.StartSerialSlave(comboBox_serialPort.SelectedItem.ToString() + "-" + textBox1.Text);
				button5.Enabled = false;
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			MelsecFxLinksServer melsecFxLinksServer = fxLinksServer;
			if (melsecFxLinksServer != null)
			{
				melsecFxLinksServer.CloseSerialSlave();
			}
			MelsecFxLinksServer melsecFxLinksServer2 = fxLinksServer;
			if (melsecFxLinksServer2 != null)
			{
				melsecFxLinksServer2.ServerClose();
			}
			button5.Enabled = true;
			button1.Enabled = true;
			button11.Enabled = false;
		}

		private void MelsecMcServer_OnDataReceived(object sender, object source, byte[] receive)
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

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox_port.Text);
			element.SetAttributeValue(DemoDeviceList.XmlBinary, checkBox_sumCheck.Checked);
			element.SetAttributeValue(DemoDeviceList.XmlDataFormat, comboBox_format.SelectedIndex);
			element.SetAttributeValue(DemoDeviceList.XmlStation, textBox_station.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox_port.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			checkBox_sumCheck.Checked = bool.Parse(element.Attribute(DemoDeviceList.XmlBinary).Value);
			if (element.Attribute(DemoDeviceList.XmlDataFormat) != null)
			{
				comboBox_format.SelectedIndex = int.Parse(element.Attribute(DemoDeviceList.XmlDataFormat).Value);
			}
			if (element.Attribute(DemoDeviceList.XmlStation) != null)
			{
				textBox_station.Text = element.Attribute(DemoDeviceList.XmlStation).Value;
			}
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
			label4 = new System.Windows.Forms.Label();
			comboBox_format = new System.Windows.Forms.ComboBox();
			comboBox_serialPort = new System.Windows.Forms.ComboBox();
			button5 = new System.Windows.Forms.Button();
			label14 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			checkBox_sumCheck = new System.Windows.Forms.CheckBox();
			label11 = new System.Windows.Forms.Label();
			button11 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox_port = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteServer1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteServer();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			label5 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(textBox_station);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(comboBox_format);
			panel1.Controls.Add(comboBox_serialPort);
			panel1.Controls.Add(button5);
			panel1.Controls.Add(label14);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(checkBox_sumCheck);
			panel1.Controls.Add(label11);
			panel1.Controls.Add(button11);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox_port);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 68);
			panel1.TabIndex = 0;
			textBox_station.Location = new System.Drawing.Point(287, 38);
			textBox_station.Name = "textBox_station";
			textBox_station.Size = new System.Drawing.Size(65, 23);
			textBox_station.TabIndex = 40;
			textBox_station.Text = "0";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(227, 41);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(44, 17);
			label4.TabIndex = 39;
			label4.Text = "站号：";
			comboBox_format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox_format.FormattingEnabled = true;
			comboBox_format.Items.AddRange(new object[2]
			{
				"1",
				"4"
			});
			comboBox_format.Location = new System.Drawing.Point(129, 38);
			comboBox_format.Name = "comboBox_format";
			comboBox_format.Size = new System.Drawing.Size(68, 25);
			comboBox_format.TabIndex = 38;
			comboBox_serialPort.FormattingEnabled = true;
			comboBox_serialPort.Location = new System.Drawing.Point(489, 9);
			comboBox_serialPort.Name = "comboBox_serialPort";
			comboBox_serialPort.Size = new System.Drawing.Size(109, 25);
			comboBox_serialPort.TabIndex = 36;
			button5.Location = new System.Drawing.Point(604, 7);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(91, 28);
			button5.TabIndex = 35;
			button5.Text = "启动串口";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(439, 13);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 33;
			label14.Text = "串口：";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(73, 41);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(44, 17);
			label1.TabIndex = 31;
			label1.Text = "格式：";
			checkBox_sumCheck.AutoSize = true;
			checkBox_sumCheck.Checked = true;
			checkBox_sumCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox_sumCheck.Location = new System.Drawing.Point(156, 11);
			checkBox_sumCheck.Name = "checkBox_sumCheck";
			checkBox_sumCheck.Size = new System.Drawing.Size(87, 21);
			checkBox_sumCheck.TabIndex = 30;
			checkBox_sumCheck.Text = "SumCheck";
			checkBox_sumCheck.UseVisualStyleBackColor = true;
			label11.ForeColor = System.Drawing.Color.FromArgb(192, 0, 192);
			label11.Location = new System.Drawing.Point(724, 6);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(249, 41);
			label11.TabIndex = 29;
			label11.Text = "本服务器不是严格的mc协议，仅支持和HSL组件完美通信。";
			button11.Enabled = false;
			button11.Location = new System.Drawing.Point(340, 7);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(83, 28);
			button11.TabIndex = 28;
			button11.Text = "关闭服务";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			button1.Location = new System.Drawing.Point(250, 7);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(83, 28);
			button1.TabIndex = 4;
			button1.Text = "启动服务";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox_port.Location = new System.Drawing.Point(74, 9);
			textBox_port.Name = "textBox_port";
			textBox_port.Size = new System.Drawing.Size(65, 23);
			textBox_port.TabIndex = 3;
			textBox_port.Text = "2000";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(20, 12);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteServer1);
			panel2.Location = new System.Drawing.Point(3, 107);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 535);
			panel2.TabIndex = 1;
			userControlReadWriteServer1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteServer1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlReadWriteServer1.Location = new System.Drawing.Point(3, 2);
			userControlReadWriteServer1.Name = "userControlReadWriteServer1";
			userControlReadWriteServer1.Size = new System.Drawing.Size(989, 528);
			userControlReadWriteServer1.TabIndex = 0;
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "FxLinks Server";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 2;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(439, 41);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(44, 17);
			label5.TabIndex = 41;
			label5.Text = "参数：";
			textBox1.Location = new System.Drawing.Point(489, 39);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(116, 23);
			textBox1.TabIndex = 42;
			textBox1.Text = "9600-8-N-1";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormFxLinksServer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "FxLinks虚拟服务器【数据支持，bool是M,X,Y, S，字操作是x,y,m,d,r】";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
