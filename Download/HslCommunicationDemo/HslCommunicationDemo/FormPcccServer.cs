using HslCommunication.Core.Net;
using HslCommunication.Profinet.AllenBradley;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormPcccServer : HslFormContent
	{
		private AllenBradleyPcccServer cipServer;

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

		public FormPcccServer()
		{
			InitializeComponent();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			if (Program.Language == 2)
			{
				Text = "Cip-PCCC Virtual Server [support single value]";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
				label11.Text = "This server is not a strict cip protocol and only supports perfect communication with HSL components.";
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
			AllenBradleyPcccServer allenBradleyPcccServer = cipServer;
			if (allenBradleyPcccServer != null)
			{
				allenBradleyPcccServer.ServerClose();
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
					cipServer = new AllenBradleyPcccServer();
					cipServer.ActiveTimeSpan = TimeSpan.FromHours(1.0);
					cipServer.OnDataReceived += BusTcpServer_OnDataReceived;
					cipServer.ServerStart(result);
					button1.Enabled = false;
					panel2.Enabled = true;
					button11.Enabled = true;
					userControlReadWriteServer1.SetReadWriteServer(cipServer, "F8:5");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			AllenBradleyPcccServer allenBradleyPcccServer = cipServer;
			if (allenBradleyPcccServer != null)
			{
				allenBradleyPcccServer.ServerClose();
			}
			button1.Enabled = true;
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

		private void userControlReadWriteServer1_Load(object sender, EventArgs e)
		{
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
			label11 = new System.Windows.Forms.Label();
			button11 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteServer1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteServer();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(label11);
			panel1.Controls.Add(button11);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(3, 36);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 46);
			panel1.TabIndex = 0;
			label11.ForeColor = System.Drawing.Color.FromArgb(192, 0, 192);
			label11.Location = new System.Drawing.Point(343, 2);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(653, 42);
			label11.TabIndex = 29;
			label11.Text = "本服务器不是严格的cip协议，仅支持和HSL组件通信。";
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
			textBox2.Text = "44818";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(11, 12);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteServer1);
			panel2.Location = new System.Drawing.Point(3, 85);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 557);
			panel2.TabIndex = 1;
			userControlReadWriteServer1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteServer1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlReadWriteServer1.Location = new System.Drawing.Point(2, 3);
			userControlReadWriteServer1.Name = "userControlReadWriteServer1";
			userControlReadWriteServer1.Size = new System.Drawing.Size(990, 549);
			userControlReadWriteServer1.TabIndex = 19;
			userControlReadWriteServer1.Load += new System.EventHandler(userControlReadWriteServer1_Load);
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Cip-PCCC";
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
			base.Name = "FormPcccServer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "AB PLC虚拟服务器【仅支持单数据，一维数组】";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
