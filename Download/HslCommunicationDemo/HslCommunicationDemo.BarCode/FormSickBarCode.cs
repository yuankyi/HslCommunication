using HslCommunication.BasicFramework;
using HslCommunication.Profinet.Sick;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace HslCommunicationDemo.BarCode
{
	public class FormSickBarCode : HslFormContent
	{
		private SickIcrTcpServer tcpServer;

		private Timer timer;

		private IContainer components = null;

		private UserControlHead userControlHead1;

		private Panel panel1;

		private Button button11;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private Panel panel2;

		private Label label15;

		private Label label16;

		private TextBox textBox1;

		private Label label1;

		private Label label2;

		private Button button2;

		private TextBox textBox4;

		private Label label5;

		private TextBox textBox3;

		private Label label4;

		private Label label6;

		public FormSickBarCode()
		{
			InitializeComponent();
		}

		private void FormSickBarCode_Load(object sender, EventArgs e)
		{
			button11.Enabled = false;
			timer = new Timer();
			timer.Interval = 1000;
			timer.Tick += Timer_Tick;
			timer.Start();
			panel2.Enabled = false;
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if (tcpServer != null)
			{
				label15.Text = tcpServer.OnlineCount.ToString();
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			try
			{
				tcpServer = new SickIcrTcpServer();
				tcpServer.ServerStart(int.Parse(textBox2.Text));
				tcpServer.OnReceivedBarCode += TcpServer_OnReceivedBarCode;
				button1.Enabled = false;
				button11.Enabled = true;
				panel2.Enabled = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Start Failed: " + ex.Message);
			}
		}

		private void TcpServer_OnReceivedBarCode(string ipAddress, string barCode)
		{
			Invoke((Action)delegate
			{
				textBox1.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss  [") + ipAddress + "] BarCode[" + barCode + "]" + Environment.NewLine);
			});
		}

		private void Button11_Click(object sender, EventArgs e)
		{
			SickIcrTcpServer sickIcrTcpServer = tcpServer;
			if (sickIcrTcpServer != null)
			{
				sickIcrTcpServer.ServerClose();
			}
			button1.Enabled = true;
			button11.Enabled = false;
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			try
			{
				IPAddress.Parse(textBox3.Text);
				tcpServer.AddConnectBarcodeScan(textBox3.Text, int.Parse(textBox4.Text));
			}
			catch (Exception ex)
			{
				MessageBox.Show("Data Input wrong: " + SoftBasic.GetExceptionMessage(ex));
			}
		}

		private void label6_Click(object sender, EventArgs e)
		{
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
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1 = new System.Windows.Forms.Panel();
			label6 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			button11 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			button2 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			userControlHead1.MinimumSize = new System.Drawing.Size(933, 20);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "";
			userControlHead1.Size = new System.Drawing.Size(1056, 32);
			userControlHead1.TabIndex = 3;
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(label6);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(button11);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(12, 44);
			panel1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1026, 63);
			panel1.TabIndex = 4;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(378, 38);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(308, 17);
			label6.TabIndex = 30;
			label6.Text = "实际测试，同样也适用于海康，基恩士，DATELOGIC 。";
			label6.Click += new System.EventHandler(label6_Click);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(378, 10);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(426, 17);
			label2.TabIndex = 29;
			label2.Text = "本服务器适合sick的扫码软件，需要在扫码设备配置信息，将条码发送至计算机";
			button11.Enabled = false;
			button11.Location = new System.Drawing.Point(274, 6);
			button11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(97, 40);
			button11.TabIndex = 28;
			button11.Text = "关闭服务";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(Button11_Click);
			button1.Location = new System.Drawing.Point(169, 6);
			button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(97, 40);
			button1.TabIndex = 4;
			button1.Text = "启动服务";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1_Click);
			textBox2.Location = new System.Drawing.Point(86, 10);
			textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(75, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "2004";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(23, 14);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(button2);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(textBox3);
			panel2.Controls.Add(label4);
			panel2.Controls.Add(label15);
			panel2.Controls.Add(label16);
			panel2.Controls.Add(textBox1);
			panel2.Controls.Add(label1);
			panel2.Location = new System.Drawing.Point(12, 119);
			panel2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(1026, 379);
			panel2.TabIndex = 5;
			button2.Location = new System.Drawing.Point(879, 4);
			button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(111, 32);
			button2.TabIndex = 22;
			button2.Text = "新增连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(Button2_Click);
			textBox4.Location = new System.Drawing.Point(793, 4);
			textBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(80, 23);
			textBox4.TabIndex = 21;
			textBox4.Text = "3004";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(730, 8);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(56, 17);
			label5.TabIndex = 20;
			label5.Text = "端口号：";
			textBox3.Location = new System.Drawing.Point(535, 4);
			textBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(173, 23);
			textBox3.TabIndex = 19;
			textBox3.Text = "192.168.1.100";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(469, 8);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(60, 17);
			label4.TabIndex = 18;
			label4.Text = "Ip 地址：";
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("微软雅黑", 21f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label15.Location = new System.Drawing.Point(328, 0);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(31, 36);
			label15.TabIndex = 17;
			label15.Text = "0";
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font("微软雅黑", 21f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label16.Location = new System.Drawing.Point(107, 0);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(183, 36);
			label16.TabIndex = 16;
			label16.Text = "在线客户端：";
			textBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox1.Location = new System.Drawing.Point(13, 40);
			textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox1.Size = new System.Drawing.Size(997, 329);
			textBox1.TabIndex = 6;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(3, 7);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(68, 17);
			label1.TabIndex = 4;
			label1.Text = "运行日志：";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1056, 502);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			base.Controls.Add(userControlHead1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormSickBarCode";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Sick Server";
			base.Load += new System.EventHandler(FormSickBarCode_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
