using HslCommunication.Core.Net;
using HslCommunication.Profinet.LSIS;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormLSisServer : HslFormContent
	{
		private LSisServer lSisServer;

		private IContainer components = null;

		private Panel panel1;

		private Panel panel2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private Button button11;

		private Button button5;

		private TextBox textBox10;

		private Label label14;

		private UserControlHead userControlHead1;

		private ComboBox cboxModel;

		private Label label2;

		private UserControlReadWriteServer userControlReadWriteServer1;

		private Button button2;

		public FormLSisServer()
		{
			InitializeComponent();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			cboxModel.DataSource = Enum.GetNames(typeof(LSCpuInfo));
			if (Program.Language == 2)
			{
				Text = "LSis Virtual Server";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
				label14.Text = "Com:";
				button5.Text = "start com";
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
			LSisServer obj = lSisServer;
			if (obj != null)
			{
				obj.ServerClose();
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
					lSisServer = new LSisServer(cboxModel.Text);
					lSisServer.OnDataReceived += BusTcpServer_OnDataReceived;
					lSisServer.ServerStart(result);
					userControlReadWriteServer1.SetReadWriteServer(lSisServer, "MB100");
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
			LSisServer obj = lSisServer;
			if (obj != null)
			{
				obj.ServerClose();
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

		private void Button5_Click(object sender, EventArgs e)
		{
			if (lSisServer != null)
			{
				try
				{
					lSisServer.StartSerialSlave(textBox10.Text);
					button5.Enabled = false;
					button2.Enabled = true;
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
			element.SetAttributeValue(DemoDeviceList.XmlCpuType, cboxModel.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox10.Text = element.Attribute(DemoDeviceList.XmlCom).Value;
			cboxModel.Text = element.Attribute(DemoDeviceList.XmlCpuType).Value;
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (lSisServer != null)
			{
				try
				{
					lSisServer.CloseSerialSlave();
					button2.Enabled = false;
					button5.Enabled = true;
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
			cboxModel = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			button5 = new System.Windows.Forms.Button();
			textBox10 = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			button11 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteServer1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteServer();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			button2 = new System.Windows.Forms.Button();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(button2);
			panel1.Controls.Add(cboxModel);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(button5);
			panel1.Controls.Add(textBox10);
			panel1.Controls.Add(label14);
			panel1.Controls.Add(button11);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 45);
			panel1.TabIndex = 0;
			cboxModel.FormattingEnabled = true;
			cboxModel.Location = new System.Drawing.Point(826, 8);
			cboxModel.Name = "cboxModel";
			cboxModel.Size = new System.Drawing.Size(83, 25);
			cboxModel.TabIndex = 33;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(764, 12);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(60, 17);
			label2.TabIndex = 32;
			label2.Text = "cpuType:";
			button5.Location = new System.Drawing.Point(535, 7);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(91, 28);
			button5.TabIndex = 31;
			button5.Text = "启动串口";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(Button5_Click);
			textBox10.Location = new System.Drawing.Point(371, 10);
			textBox10.Name = "textBox10";
			textBox10.Size = new System.Drawing.Size(158, 23);
			textBox10.TabIndex = 30;
			textBox10.Text = "COM4-9600-8-N-1";
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(326, 13);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 29;
			label14.Text = "串口：";
			button11.Enabled = false;
			button11.Location = new System.Drawing.Point(235, 7);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(83, 28);
			button11.TabIndex = 28;
			button11.Text = "关闭服务";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			button1.Location = new System.Drawing.Point(145, 7);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(83, 28);
			button1.TabIndex = 4;
			button1.Text = "启动服务";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(74, 10);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(65, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "2004";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(20, 13);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteServer1);
			panel2.Location = new System.Drawing.Point(3, 84);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 558);
			panel2.TabIndex = 1;
			userControlReadWriteServer1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteServer1.Font = new System.Drawing.Font("Microsoft YaHei", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlReadWriteServer1.Location = new System.Drawing.Point(4, 3);
			userControlReadWriteServer1.Name = "userControlReadWriteServer1";
			userControlReadWriteServer1.Size = new System.Drawing.Size(992, 550);
			userControlReadWriteServer1.TabIndex = 0;
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("Microsoft YaHei", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Fast Enet and Cnet";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 2;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			button2.Location = new System.Drawing.Point(632, 7);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 34;
			button2.Text = "Close Port";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Microsoft YaHei", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormLSisServer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "LSisServer";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
