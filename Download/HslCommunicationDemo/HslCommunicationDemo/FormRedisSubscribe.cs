using HslCommunication;
using HslCommunication.Enthernet.Redis;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormRedisSubscribe : HslFormContent
	{
		private RedisSubscribe redisSubscribe = null;

		private int count = 0;

		private Random random = new Random();

		private IContainer components = null;

		private Panel panel1;

		private TextBox textBox3;

		private Label label6;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private Label label1;

		private Panel panel2;

		private TextBox textBox4;

		private Label label9;

		private Label label8;

		private Label label10;

		private Label label11;

		private Label label12;

		private UserControlHead userControlHead1;

		private Button button4;

		private Button button3;

		private TextBox textBox5;

		private Label label7;

		public FormRedisSubscribe()
		{
			InitializeComponent();
		}

		private void FormClient_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			button2.Enabled = false;
			if (Program.Language == 2)
			{
				label1.Text = "IP:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "DisConnect";
				label6.Text = "Password";
				label7.Text = "Keyword: all input is batch subscription";
				button3.Text = "Subscribe";
				button4.Text = "UnSubscribe";
				label12.Text = "Time:";
				label10.Text = "Count:";
				label9.Text = "Data:";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				redisSubscribe = new RedisSubscribe(textBox1.Text, int.Parse(textBox2.Text));
				redisSubscribe.Password = textBox3.Text;
				redisSubscribe.OnRedisMessageReceived += RedisSubscribe_OnRedisMessageReceived;
			}
			catch (Exception ex)
			{
				MessageBox.Show("输入错误：" + ex.Message);
				return;
			}
			OperateResult operateResult = redisSubscribe.ConnectServer();
			if (operateResult.IsSuccess)
			{
				button1.Enabled = false;
				button2.Enabled = true;
				panel2.Enabled = true;
				MessageBox.Show(StringResources.Language.ConnectServerSuccess);
			}
			else
			{
				MessageBox.Show(StringResources.Language.ConnectedFailed + operateResult.ToMessageShowString());
			}
		}

		private void RedisSubscribe_OnRedisMessageReceived(string topic, string message)
		{
			ShowSubscribe(topic, message);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;
			redisSubscribe.ConnectClose();
		}

		private void ShowSubscribe(string key, string content)
		{
			if (base.InvokeRequired)
			{
				Invoke(new Action<string, string>(ShowSubscribe), key, content);
			}
			else
			{
				count++;
				label11.Text = DateTime.Now.ToString();
				label8.Text = count.ToString();
				textBox4.AppendText(DateTime.Now.ToString() + "  Topic:[" + key + "] Message:" + content);
				textBox4.AppendText(Environment.NewLine);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = redisSubscribe.SubscribeMessage(textBox5.Text);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("订阅成功");
			}
			else
			{
				MessageBox.Show("订阅失败");
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = redisSubscribe.UnSubscribeMessage(textBox5.Text);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("取消订阅成功");
			}
			else
			{
				MessageBox.Show("取消订阅失败");
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
			label6 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			textBox5 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(15, 43);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(978, 83);
			panel1.TabIndex = 7;
			textBox3.Location = new System.Drawing.Point(78, 47);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(368, 23);
			textBox3.TabIndex = 7;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(8, 50);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(44, 17);
			label6.TabIndex = 6;
			label6.Text = "密码：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(584, 11);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(475, 11);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(305, 14);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(141, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "6379";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(251, 17);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(78, 14);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(125, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 17);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(button4);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(textBox5);
			panel2.Controls.Add(label7);
			panel2.Controls.Add(label8);
			panel2.Controls.Add(label10);
			panel2.Controls.Add(label11);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label9);
			panel2.Location = new System.Drawing.Point(15, 133);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(977, 508);
			panel2.TabIndex = 13;
			button4.Location = new System.Drawing.Point(383, 31);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(103, 25);
			button4.TabIndex = 20;
			button4.Text = "取消订阅";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button3.Location = new System.Drawing.Point(274, 31);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(103, 25);
			button3.TabIndex = 19;
			button3.Text = "订阅";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox5.Location = new System.Drawing.Point(62, 32);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(206, 23);
			textBox5.TabIndex = 18;
			textBox5.Text = "A";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(8, 8);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(164, 17);
			label7.TabIndex = 17;
			label7.Text = "关键字：都输入就是批量订阅";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(441, 75);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(15, 17);
			label8.TabIndex = 15;
			label8.Text = "0";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(367, 75);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(68, 17);
			label10.TabIndex = 14;
			label10.Text = "接收次数：";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(133, 75);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(15, 17);
			label11.TabIndex = 13;
			label11.Text = "0";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(59, 75);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(68, 17);
			label12.TabIndex = 12;
			label12.Text = "接收时间：";
			textBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox4.Location = new System.Drawing.Point(62, 95);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox4.Size = new System.Drawing.Size(904, 407);
			textBox4.TabIndex = 8;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(8, 101);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(44, 17);
			label9.TabIndex = 11;
			label9.Text = "数据：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/9998013.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Redis";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 14;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormRedisSubscribe";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Redis订阅客户端";
			base.Load += new System.EventHandler(FormClient_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
