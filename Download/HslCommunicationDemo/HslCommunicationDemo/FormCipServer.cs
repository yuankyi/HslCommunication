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
	public class FormCipServer : HslFormContent
	{
		private AllenBradleyServer cipServer;

		private IContainer components = null;

		private Panel panel1;

		private Panel panel2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private Button button11;

		private Label label11;

		private UserControlHead userControlHead1;

		private Label label2;

		private UserControlReadWriteServer userControlReadWriteServer1;

		private CheckBox checkBox1;

		public FormCipServer()
		{
			InitializeComponent();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			if (Program.Language == 2)
			{
				Text = "Cip Virtual Server [support single value]";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
				label11.Text = "This server is not a strict cip protocol and only supports perfect communication with HSL components.";
				checkBox1.Text = "Create Tag when write";
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
			AllenBradleyServer allenBradleyServer = cipServer;
			if (allenBradleyServer != null)
			{
				allenBradleyServer.ServerClose();
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
					cipServer = new AllenBradleyServer();
					cipServer.ActiveTimeSpan = TimeSpan.FromHours(1.0);
					cipServer.OnDataReceived += BusTcpServer_OnDataReceived;
					cipServer.CreateTagWithWrite = checkBox1.Checked;
					short[] array = new short[2000];
					float[] array2 = new float[2000];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = (short)(i + 1);
						array2[i] = (float)array[i];
					}
					cipServer.ServerStart(result);
					cipServer.AddTagValue("A", (short)10);
					cipServer.AddTagValue("A1", array2);
					cipServer.AddTagValue("B", 123);
					cipServer.AddTagValue("C", 123f);
					cipServer.AddTagValue("D", array);
					cipServer.AddTagValue("E", true);
					cipServer.AddTagValue("F", "12345", 100);
					cipServer.AddTagValue("G", new string[5]
					{
						"123",
						"123456",
						string.Empty,
						"abcd",
						"测试"
					}, 100);
					cipServer.AddTagValue("AB.C", new short[5]
					{
						1,
						2,
						3,
						4,
						5
					});
					cipServer.AddTagValue("M", new uint[4]
					{
						1u,
						2u,
						3u,
						4u
					});
					cipServer.AddTagValue("REAL500", new float[500]);
					cipServer.AddTagValue("N", 100L);
					button1.Enabled = false;
					panel2.Enabled = true;
					button11.Enabled = true;
					userControlReadWriteServer1.SetReadWriteServer(cipServer, "A", 1);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			AllenBradleyServer allenBradleyServer = cipServer;
			if (allenBradleyServer != null)
			{
				allenBradleyServer.ServerClose();
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
			checkBox1 = new System.Windows.Forms.CheckBox();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteServer1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteServer();
			label2 = new System.Windows.Forms.Label();
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
			panel1.Controls.Add(checkBox1);
			panel1.Location = new System.Drawing.Point(3, 36);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 46);
			panel1.TabIndex = 0;
			label11.ForeColor = System.Drawing.Color.FromArgb(192, 0, 192);
			label11.Location = new System.Drawing.Point(475, 0);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(447, 41);
			label11.TabIndex = 29;
			label11.Text = "本服务器不是严格的cip协议，仅支持和HSL组件通信。";
			button11.Enabled = false;
			button11.Location = new System.Drawing.Point(386, 8);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(83, 28);
			button11.TabIndex = 28;
			button11.Text = "关闭服务";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			button1.Location = new System.Drawing.Point(299, 8);
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
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(141, 11);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(111, 21);
			checkBox1.TabIndex = 30;
			checkBox1.Text = "写入时创建标签";
			checkBox1.UseVisualStyleBackColor = true;
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteServer1);
			panel2.Controls.Add(label2);
			panel2.Location = new System.Drawing.Point(3, 85);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 557);
			panel2.TabIndex = 1;
			userControlReadWriteServer1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteServer1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlReadWriteServer1.Location = new System.Drawing.Point(2, 31);
			userControlReadWriteServer1.Name = "userControlReadWriteServer1";
			userControlReadWriteServer1.Size = new System.Drawing.Size(990, 521);
			userControlReadWriteServer1.TabIndex = 19;
			userControlReadWriteServer1.Load += new System.EventHandler(userControlReadWriteServer1_Load);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(8, 10);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(893, 17);
			label2.TabIndex = 18;
			label2.Text = "服务器值列表：   A short ; A1  float[2000]  ;  B int ;  C   float ;     D  short[2000];     E  bool;     F  string ;  G  sting[5];   AB.C  short[5];   M  uint[4];  N   long";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Cip";
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
			base.Name = "FormCipServer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "AB PLC虚拟服务器【仅支持单数据，一维数组】";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}