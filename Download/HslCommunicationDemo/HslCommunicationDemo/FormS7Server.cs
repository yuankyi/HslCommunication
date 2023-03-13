using HslCommunication.Core.Net;
using HslCommunication.Profinet.Siemens;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormS7Server : HslFormContent
	{
		private short m60 = 0;

		private bool m62 = false;

		private float m64 = 1.1f;

		private SiemensS7Server s7NetServer;

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

		private Button button_db_remove;

		private Button button_db_add;

		private TextBox textBox_db;

		private Label label1;

		private Label label2;

		public FormS7Server()
		{
			InitializeComponent();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			if (Program.Language == 2)
			{
				Text = "S7 Virtual Server [data support i,q,m,db block read and write, db block only one, whether it is DB1.1 or DB100.1 refers to the same]";
				label3.Text = "port:";
				button1.Text = "Start Server";
				button11.Text = "Close Server";
				label11.Text = "This server is not a strict S7 protocol and only supports perfect communication with HSL components.";
			}
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			m60++;
			s7NetServer.Write("M60", m60);
			s7NetServer.Write("M62", !m62);
			m62 = !m62;
			m64 += 1f;
			if (m64 > 2000f)
			{
				m64 = 1.1f;
			}
			s7NetServer.Write("M64", m64);
			s7NetServer.Write("M70", "A" + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString());
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
			SiemensS7Server siemensS7Server = s7NetServer;
			if (siemensS7Server != null)
			{
				siemensS7Server.ServerClose();
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
					s7NetServer = new SiemensS7Server();
					s7NetServer.ActiveTimeSpan = TimeSpan.FromHours(1.0);
					s7NetServer.OnDataReceived += BusTcpServer_OnDataReceived;
					s7NetServer.ServerStart(result);
					userControlReadWriteServer1.SetReadWriteServer(s7NetServer, "M100");
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
			SiemensS7Server siemensS7Server = s7NetServer;
			if (siemensS7Server != null)
			{
				siemensS7Server.ServerClose();
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

		private void button_db_add_Click(object sender, EventArgs e)
		{
			int result;
			if (int.TryParse(textBox_db.Text, out result))
			{
				if (s7NetServer == null)
				{
					MessageBox.Show("Must start s7 server first!");
				}
				else
				{
					s7NetServer.AddDbBlock(result);
					MessageBox.Show("Add db block success");
				}
			}
			else
			{
				MessageBox.Show("Please input correct db block number!");
			}
		}

		private void button_db_remove_Click(object sender, EventArgs e)
		{
			int result;
			if (int.TryParse(textBox_db.Text, out result))
			{
				if (s7NetServer == null)
				{
					MessageBox.Show("Must start s7 server first!");
				}
				else if (result == 1 || result == 2 || result == 3)
				{
					MessageBox.Show("Can not remove db block 1, 2, 3");
				}
				else
				{
					s7NetServer.RemoveDbBlock(result);
					MessageBox.Show("Remove db block success");
				}
			}
			else
			{
				MessageBox.Show("Please input correct db block number!");
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
			label11 = new System.Windows.Forms.Label();
			button11 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteServer1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteServer();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			textBox_db = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			button_db_add = new System.Windows.Forms.Button();
			button_db_remove = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(button_db_remove);
			panel1.Controls.Add(button_db_add);
			panel1.Controls.Add(textBox_db);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(label11);
			panel1.Controls.Add(button11);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label2);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 45);
			panel1.TabIndex = 0;
			label11.ForeColor = System.Drawing.Color.FromArgb(192, 0, 192);
			label11.Location = new System.Drawing.Point(325, 4);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(340, 41);
			label11.TabIndex = 29;
			label11.Text = "本服务器不是严格的s7协议，仅支持和HSL组件完美通信。";
			button11.Enabled = false;
			button11.Location = new System.Drawing.Point(235, 8);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(83, 28);
			button11.TabIndex = 28;
			button11.Text = "关闭服务";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			button1.Location = new System.Drawing.Point(145, 8);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(83, 28);
			button1.TabIndex = 4;
			button1.Text = "启动服务";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(74, 11);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(65, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "102";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(20, 14);
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
			panel2.Size = new System.Drawing.Size(997, 559);
			panel2.TabIndex = 1;
			userControlReadWriteServer1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteServer1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlReadWriteServer1.Location = new System.Drawing.Point(2, 2);
			userControlReadWriteServer1.Name = "userControlReadWriteServer1";
			userControlReadWriteServer1.Size = new System.Drawing.Size(990, 552);
			userControlReadWriteServer1.TabIndex = 0;
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/10425797.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "s7";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 2;
			textBox_db.Location = new System.Drawing.Point(762, 3);
			textBox_db.Name = "textBox_db";
			textBox_db.Size = new System.Drawing.Size(65, 23);
			textBox_db.TabIndex = 31;
			textBox_db.Text = "10";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(683, 6);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(73, 17);
			label1.TabIndex = 30;
			label1.Text = "DB block：";
			button_db_add.Location = new System.Drawing.Point(833, 0);
			button_db_add.Name = "button_db_add";
			button_db_add.Size = new System.Drawing.Size(61, 28);
			button_db_add.TabIndex = 32;
			button_db_add.Text = "Add";
			button_db_add.UseVisualStyleBackColor = true;
			button_db_add.Click += new System.EventHandler(button_db_add_Click);
			button_db_remove.Location = new System.Drawing.Point(900, 0);
			button_db_remove.Name = "button_db_remove";
			button_db_remove.Size = new System.Drawing.Size(70, 28);
			button_db_remove.TabIndex = 33;
			button_db_remove.Text = "Remove";
			button_db_remove.UseVisualStyleBackColor = true;
			button_db_remove.Click += new System.EventHandler(button_db_remove_Click);
			label2.AutoSize = true;
			label2.ForeColor = System.Drawing.Color.Blue;
			label2.Location = new System.Drawing.Point(683, 26);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(273, 17);
			label2.TabIndex = 34;
			label2.Text = "用来添加新的独立的DB块支持，无法移除DB1,2,3";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormS7Server";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "s7虚拟服务器【数据支持I，Q，M，DB块读写，DB块只有一个，无论是DB1.1还是DB100.1都是指同一个】";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
