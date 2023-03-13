using HslCommunication.Core.Net;
using HslCommunication.Profinet.Omron;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormOmronHostLinkServer : HslFormContent
	{
		private OmronHostLinkServer omronFinsServer;

		private IContainer components = null;

		private Panel panel1;

		private Panel panel2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private Button button11;

		private Label label11;

		private UserControlHead userControlHead1;

		private UserControlReadWriteServer userControlReadWriteServer1;

		private Button button5;

		private Label label14;

		private Label label1;

		private ComboBox comboBox1;

		private TextBox textBox1;

		private Label label4;

		public FormOmronHostLinkServer()
		{
			InitializeComponent();
			omronFinsServer = new OmronHostLinkServer();
			omronFinsServer.OnDataReceived += BusTcpServer_OnDataReceived;
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			comboBox1.DataSource = SerialPort.GetPortNames();
			if (Program.Language == 2)
			{
				Text = "Omron Virtual Server [data support, d, a, h, c, w]";
				label3.Text = "port:";
				label4.Text = "Para:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
				label11.Text = "This server is not a strict fins protocol and only supports perfect communication with HSL components.";
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
			OmronHostLinkServer omronHostLinkServer = omronFinsServer;
			if (omronHostLinkServer != null)
			{
				omronHostLinkServer.ServerClose();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show(DemoUtils.PortInputWrong);
			}
			else
			{
				try
				{
					omronFinsServer.ActiveTimeSpan = TimeSpan.FromHours(1.0);
					omronFinsServer.ServerStart(result);
					userControlReadWriteServer1.SetReadWriteServer(omronFinsServer, "D100");
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
			if (comboBox1.SelectedItem == null)
			{
				MessageBox.Show("There is none serial port to use, try later!");
			}
			else
			{
				try
				{
					omronFinsServer.StartSerialSlave(comboBox1.SelectedItem.ToString() + "-" + textBox1.Text);
					userControlReadWriteServer1.SetReadWriteServer(omronFinsServer, "D100");
					button5.Enabled = false;
					panel2.Enabled = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			OmronHostLinkServer omronHostLinkServer = omronFinsServer;
			if (omronHostLinkServer != null)
			{
				omronHostLinkServer.CloseSerialSlave();
			}
			OmronHostLinkServer omronHostLinkServer2 = omronFinsServer;
			if (omronHostLinkServer2 != null)
			{
				omronHostLinkServer2.ServerClose();
			}
			button1.Enabled = true;
			button5.Enabled = true;
			button11.Enabled = false;
		}

		private void BusTcpServer_OnDataReceived(object sender, object source, byte[] receive)
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
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
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
			label1 = new System.Windows.Forms.Label();
			comboBox1 = new System.Windows.Forms.ComboBox();
			button5 = new System.Windows.Forms.Button();
			label14 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			button11 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteServer1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteServer();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			label4 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(button5);
			panel1.Controls.Add(label14);
			panel1.Controls.Add(label11);
			panel1.Controls.Add(button11);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 60);
			panel1.TabIndex = 0;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(335, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(62, 17);
			label1.TabIndex = 34;
			label1.Text = "Station: 0";
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(481, 2);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(104, 25);
			comboBox1.TabIndex = 33;
			button5.Location = new System.Drawing.Point(591, 1);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(91, 28);
			button5.TabIndex = 32;
			button5.Text = "启动串口";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(430, 7);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 30;
			label14.Text = "串口：";
			label11.ForeColor = System.Drawing.Color.FromArgb(192, 0, 192);
			label11.Location = new System.Drawing.Point(755, 3);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(218, 41);
			label11.TabIndex = 29;
			label11.Text = "本服务器不是严格的fins协议，仅支持和HSL组件完美通信。";
			button11.Enabled = false;
			button11.Location = new System.Drawing.Point(235, 6);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(83, 28);
			button11.TabIndex = 28;
			button11.Text = "关闭服务";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			button1.Location = new System.Drawing.Point(145, 6);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(83, 28);
			button1.TabIndex = 4;
			button1.Text = "启动服务";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(74, 9);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(65, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "2000";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(20, 12);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteServer1);
			panel2.Location = new System.Drawing.Point(3, 99);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 543);
			panel2.TabIndex = 1;
			userControlReadWriteServer1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteServer1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlReadWriteServer1.Location = new System.Drawing.Point(3, 3);
			userControlReadWriteServer1.Name = "userControlReadWriteServer1";
			userControlReadWriteServer1.Size = new System.Drawing.Size(989, 535);
			userControlReadWriteServer1.TabIndex = 0;
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Fins - HostLink";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 2;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(430, 35);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(44, 17);
			label4.TabIndex = 36;
			label4.Text = "参数：";
			textBox1.Location = new System.Drawing.Point(481, 32);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(139, 23);
			textBox1.TabIndex = 37;
			textBox1.Text = "9600-7-E-1";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormOmronHostLinkServer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "欧姆龙HostLink虚拟服务器【数据支持，D,H,A,W,C】";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
