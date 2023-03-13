using HslCommunication;
using HslCommunication.Core.Net;
using HslCommunication.Enthernet;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormSimplifyNetAlien : HslFormContent
	{
		private NetSimplifyClient simplifyClient = new NetSimplifyClient();

		private NetworkAlienClient networkAlien = null;

		private IContainer components = null;

		private Panel panel1;

		private Panel panel2;

		private TextBox textBox8;

		private Label label12;

		private Button button4;

		private TextBox textBox7;

		private Label label11;

		private TextBox textBox6;

		private Label label10;

		private Button button3;

		private TextBox textBox4;

		private Label label9;

		private Label label8;

		private TextBox textBox5;

		private Label label7;

		private Label label22;

		private TextBox textBox1;

		private Label label1;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private UserControlHead userControlHead1;

		public FormSimplifyNetAlien()
		{
			InitializeComponent();
		}

		private void FormClient_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			button2.Enabled = false;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			NetHandle netHandle = default(NetHandle);
			if (textBox5.Text.IndexOf('.') >= 0)
			{
				string[] array = textBox5.Text.Split('.');
				netHandle = new NetHandle(byte.Parse(array[0]), byte.Parse(array[1]), ushort.Parse(array[2]));
			}
			else
			{
				netHandle = int.Parse(textBox5.Text);
			}
			int num = int.Parse(textBox6.Text);
			DateTime now = DateTime.Now;
			for (int i = 0; i < num; i++)
			{
				OperateResult<string> operateResult = simplifyClient.ReadFromServer(netHandle, textBox4.Text);
				if (operateResult.IsSuccess)
				{
					textBox8.AppendText(operateResult.Content + Environment.NewLine);
				}
				else
				{
					MessageBox.Show("读取失败：" + operateResult.ToMessageShowString());
				}
			}
			textBox7.Text = (DateTime.Now - now).TotalMilliseconds.ToString("F2");
		}

		private void button4_Click(object sender, EventArgs e)
		{
			textBox8.Clear();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show("端口输入不正确！");
			}
			else
			{
				simplifyClient = new NetSimplifyClient(textBox1.Text, result);
				try
				{
					simplifyClient.ConnectionId = textBox1.Text;
					NetworkAlienStart(result);
					simplifyClient.ConnectServer(null);
					MessageBox.Show("等待服务器的连接！");
					button1.Enabled = false;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void NetworkAlienStart(int port)
		{
			networkAlien = new NetworkAlienClient();
			networkAlien.OnClientConnected += NetworkAlien_OnClientConnected;
			networkAlien.ServerStart(port);
		}

		private void NetworkAlien_OnClientConnected(AlienSession session)
		{
			if (session.DTU == simplifyClient.ConnectionId)
			{
				simplifyClient.ConnectServer(session);
				Invoke((Action)delegate
				{
					panel2.Enabled = true;
					button2.Enabled = true;
				});
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
			label22 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			textBox8 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			button4 = new System.Windows.Forms.Button();
			textBox7 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(label22);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(15, 43);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(978, 70);
			panel1.TabIndex = 7;
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(478, 19);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(97, 17);
			label22.TabIndex = 22;
			label22.Text = "(11位ASCII字符)";
			textBox1.Location = new System.Drawing.Point(299, 16);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(171, 23);
			textBox1.TabIndex = 21;
			textBox1.Text = "12345678901";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(238, 19);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(62, 17);
			label1.TabIndex = 20;
			label1.Text = "DTU ID：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(873, 13);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 16;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button1.Location = new System.Drawing.Point(770, 13);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 15;
			button1.Text = "创建";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click_1);
			textBox2.Location = new System.Drawing.Point(72, 16);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(76, 23);
			textBox2.TabIndex = 14;
			textBox2.Text = "10000";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(18, 19);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 13;
			label3.Text = "端口号：";
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(textBox8);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(button4);
			panel2.Controls.Add(textBox7);
			panel2.Controls.Add(label11);
			panel2.Controls.Add(textBox6);
			panel2.Controls.Add(label10);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label9);
			panel2.Controls.Add(label8);
			panel2.Controls.Add(textBox5);
			panel2.Controls.Add(label7);
			panel2.Location = new System.Drawing.Point(15, 122);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(977, 518);
			panel2.TabIndex = 13;
			textBox8.Location = new System.Drawing.Point(62, 214);
			textBox8.Multiline = true;
			textBox8.Name = "textBox8";
			textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox8.Size = new System.Drawing.Size(892, 292);
			textBox8.TabIndex = 18;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(8, 217);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(44, 17);
			label12.TabIndex = 19;
			label12.Text = "接收：";
			button4.Location = new System.Drawing.Point(863, 180);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(91, 28);
			button4.TabIndex = 17;
			button4.Text = "清空";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			textBox7.Location = new System.Drawing.Point(456, 183);
			textBox7.Name = "textBox7";
			textBox7.ReadOnly = true;
			textBox7.Size = new System.Drawing.Size(141, 23);
			textBox7.TabIndex = 16;
			textBox7.Text = "0";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(402, 186);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 15;
			label11.Text = "耗时：";
			textBox6.Location = new System.Drawing.Point(241, 183);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(141, 23);
			textBox6.TabIndex = 14;
			textBox6.Text = "1";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(187, 186);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(44, 17);
			label10.TabIndex = 13;
			label10.Text = "次数：";
			button3.Location = new System.Drawing.Point(62, 180);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(91, 28);
			button3.TabIndex = 12;
			button3.Text = "发送";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox4.Location = new System.Drawing.Point(62, 36);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(892, 138);
			textBox4.TabIndex = 8;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(8, 39);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(44, 17);
			label9.TabIndex = 11;
			label9.Text = "数据：";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(249, 11);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(134, 17);
			label8.TabIndex = 10;
			label8.Text = "举例：12345 或是1.1.1";
			textBox5.Location = new System.Drawing.Point(62, 7);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(181, 23);
			textBox5.TabIndex = 9;
			textBox5.Text = "1";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(8, 11);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(56, 17);
			label7.TabIndex = 7;
			label7.Text = "指令头：";
			userControlHead1.BackColor = System.Drawing.Color.MediumPurple;
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7697782.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 14;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormSimplifyNetAlien";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Simplify网络客户端";
			base.Load += new System.EventHandler(FormClient_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
