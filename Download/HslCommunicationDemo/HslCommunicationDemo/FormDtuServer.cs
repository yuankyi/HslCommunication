using HslCommunication;
using HslCommunication.Core.Net;
using HslCommunication.DTU;
using HslCommunication.LogNet;
using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormDtuServer : HslFormContent
	{
		private ILogNet logNet = null;

		private DTUServer dTUServer = null;

		private Timer timer;

		private IContainer components = null;

		private Panel panel1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private UserControlHead userControlHead1;

		private ListBox listBox1;

		private Label label5;

		private Label label2;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private ComboBox comboBox1;

		private Label label7;

		private TextBox textBox1;

		private TextBox textBox3;

		private Label label1;

		public FormDtuServer()
		{
			InitializeComponent();
			logNet = new LogNetSingle("");
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			Language(Program.Language);
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
			timer = new Timer();
			timer.Tick += Timer_Tick;
			timer.Interval = 1000;
			timer.Start();
			logNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
		}

		private void LogNet_BeforeSaveToFile(object sender, HslEventArgs e)
		{
			if (base.IsHandleCreated)
			{
				Invoke((Action)delegate
				{
					textBox1.AppendText(e.HslMessage.ToString() + Environment.NewLine);
				});
			}
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if (dTUServer != null)
			{
				AlienSession[] alienSessions = dTUServer.GetAlienSessions();
				listBox1.DataSource = (from m in alienSessions
				where m != null
				select m).ToArray();
				label2.Text = "Client Count:" + alienSessions.Length.ToString();
				int num = 0;
				for (int i = 0; i < alienSessions.Length; i++)
				{
					if (alienSessions[i] != null && alienSessions[i].IsStatusOk)
					{
						num++;
					}
				}
				label5.Text = "Online Count：" + num.ToString();
			}
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "Alien Modbus Tcp Read Demo";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void DtuServerStart(int port)
		{
			List<DTUSettingType> list = new List<DTUSettingType>();
			list.Add(new DTUSettingType
			{
				DtuId = "10000",
				DtuType = "ModbusRtuOverTcp",
				JsonParameter = new
				{
					Station = 1
				}.ToJsonString()
			});
			list.Add(new DTUSettingType
			{
				DtuId = "10001",
				DtuType = "ModbusRtuOverTcp",
				JsonParameter = new
				{
					Station = 1
				}.ToJsonString()
			});
			list.Add(new DTUSettingType
			{
				DtuId = "10002",
				DtuType = "ModbusRtuOverTcp",
				JsonParameter = new
				{
					Station = 1
				}.ToJsonString()
			});
			list.Add(new DTUSettingType
			{
				DtuId = "10003",
				DtuType = "ModbusRtuOverTcp",
				JsonParameter = new
				{
					Station = 1
				}.ToJsonString()
			});
			list.Add(new DTUSettingType
			{
				DtuId = "10004",
				DtuType = "ModbusTcpNet",
				JsonParameter = new
				{
					Station = 1
				}.ToJsonString()
			});
			list.Add(new DTUSettingType
			{
				DtuId = "10005",
				DtuType = "MelsecMcNet"
			});
			list.Add(new DTUSettingType
			{
				DtuId = "10006",
				DtuType = "SiemensS7Net",
				JsonParameter = new
				{
					SiemensPLCS = 1.ToString()
				}.ToJsonString()
			});
			dTUServer = new DTUServer(list);
			dTUServer.OnClientConnected += NetworkAlien_OnClientConnected;
			dTUServer.LogNet = logNet;
			dTUServer.SetPassword(Encoding.ASCII.GetBytes(textBox3.Text));
			dTUServer.ServerStart(port);
			comboBox1.DataSource = list.ToArray();
			if (list.Count > 0)
			{
				comboBox1.SelectedIndex = 0;
			}
		}

		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (dTUServer != null)
			{
				DTUSettingType dTUSettingType = comboBox1.SelectedItem as DTUSettingType;
				if (dTUSettingType != null && !string.IsNullOrEmpty(dTUSettingType.DtuId))
				{
					userControlReadWriteOp1.SetReadWriteNet(dTUServer[dTUSettingType.DtuId], "0");
				}
			}
		}

		private void NetworkAlien_OnClientConnected(AlienSession session)
		{
			Invoke((Action)delegate
			{
			});
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show("端口输入不正确！");
			}
			else
			{
				try
				{
					DtuServerStart(result);
					MessageBox.Show("等待服务器的连接！");
					button1.Enabled = false;
					button2.Enabled = true;
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
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;
			DTUServer obj = dTUServer;
			if (obj != null)
			{
				obj.ServerClose();
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
			textBox3 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			textBox1 = new System.Windows.Forms.TextBox();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label7 = new System.Windows.Forms.Label();
			listBox1 = new System.Windows.Forms.ListBox();
			label5 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 42);
			panel1.TabIndex = 0;
			textBox3.Location = new System.Drawing.Point(221, 7);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(76, 23);
			textBox3.TabIndex = 7;
			textBox3.Text = "123456";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(168, 10);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(44, 17);
			label1.TabIndex = 6;
			label1.Text = "密码：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(406, 5);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(309, 5);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "创建";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(74, 7);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(76, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "10000";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(20, 10);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(textBox1);
			panel2.Controls.Add(userControlReadWriteOp1);
			panel2.Controls.Add(comboBox1);
			panel2.Controls.Add(label7);
			panel2.Controls.Add(listBox1);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(label2);
			panel2.Location = new System.Drawing.Point(3, 80);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 563);
			panel2.TabIndex = 1;
			textBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox1.Location = new System.Drawing.Point(339, 3);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox1.Size = new System.Drawing.Size(649, 242);
			textBox1.TabIndex = 38;
			userControlReadWriteOp1.Location = new System.Drawing.Point(5, 287);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(987, 242);
			userControlReadWriteOp1.TabIndex = 37;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(52, 254);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(477, 25);
			comboBox1.TabIndex = 36;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(7, 258);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(39, 17);
			label7.TabIndex = 35;
			label7.Text = "List：";
			listBox1.BackColor = System.Drawing.Color.LightGray;
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 17;
			listBox1.Location = new System.Drawing.Point(4, 3);
			listBox1.Name = "listBox1";
			listBox1.Size = new System.Drawing.Size(328, 242);
			listBox1.TabIndex = 34;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(783, 258);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(95, 17);
			label5.TabIndex = 33;
			label5.Text = "Online Count：";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(570, 258);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(81, 17);
			label2.TabIndex = 32;
			label2.Text = "Client Count:";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7885368.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Dtu";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 2;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormDtuServer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "DTU 服务器";
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
