using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Enthernet;
using HslCommunication.LogNet;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormPlainSocket : HslFormContent
	{
		private NetPlainSocket plainSocket = null;

		private IContainer components = null;

		private Panel panel2;

		private TextBox textBox8;

		private Label label12;

		private Button button4;

		private TextBox textBox6;

		private Label label10;

		private Button button3;

		private TextBox textBox4;

		private Label label9;

		private Panel panel1;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private Label label1;

		private UserControlHead userControlHead1;

		private Label label11;

		private RadioButton radioButton4;

		private RadioButton radioButton3;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private Label label2;

		public FormPlainSocket()
		{
			InitializeComponent();
		}

		private void FormComplexNet_Load(object sender, EventArgs e)
		{
			button2.Enabled = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			IPAddress address;
			int result;
			if (!IPAddress.TryParse(textBox1.Text, out address))
			{
				MessageBox.Show("IP地址填写不正确");
			}
			else if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show("port填写不正确");
			}
			else
			{
				try
				{
					plainSocket = new NetPlainSocket(textBox1.Text, result);
					plainSocket.LogNet = new LogNetSingle(string.Empty);
					plainSocket.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
					plainSocket.ReceivedString += PlainSocket_ReceivedString;
					if (radioButton1.Checked)
					{
						plainSocket.Encoding = Encoding.ASCII;
					}
					if (radioButton2.Checked)
					{
						plainSocket.Encoding = Encoding.Default;
					}
					if (radioButton3.Checked)
					{
						plainSocket.Encoding = Encoding.Unicode;
					}
					if (radioButton4.Checked)
					{
						plainSocket.Encoding = Encoding.UTF8;
					}
					OperateResult operateResult = plainSocket.ConnectServer();
					if (operateResult.IsSuccess)
					{
						MessageBox.Show("Connect Success!");
						button1.Enabled = false;
						button2.Enabled = true;
						panel2.Enabled = true;
					}
					else
					{
						MessageBox.Show("Connect Failed:" + operateResult.Message);
					}
				}
				catch (Exception ex)
				{
					SoftBasic.ShowExceptionMessage(ex);
				}
			}
		}

		private void LogNet_BeforeSaveToFile(object sender, HslEventArgs e)
		{
			Invoke((Action)delegate
			{
				textBox8.AppendText(e.HslMessage.ToString() + Environment.NewLine);
			});
		}

		private void PlainSocket_ReceivedString(string obj)
		{
			ShowTextInfo(" " + obj);
		}

		private void ComplexClient_MessageAlerts(string text)
		{
			if (base.InvokeRequired)
			{
				Invoke(new Action<string>(ComplexClient_MessageAlerts), text);
			}
			else
			{
				label11.Text = text;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			plainSocket.ConnectClose();
			button1.Enabled = true;
			button2.Enabled = false;
		}

		private void ShowTextInfo(string text)
		{
			if (base.InvokeRequired)
			{
				Invoke(new Action<string>(ShowTextInfo), text);
			}
			else
			{
				textBox8.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " : " + text + Environment.NewLine);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox6.Text, out result))
			{
				MessageBox.Show("数据发送次数输入异常");
			}
			else
			{
				int num = 0;
				for (int i = 0; i < result; i++)
				{
					if (!plainSocket.SendString(textBox4.Text).IsSuccess)
					{
						num++;
					}
				}
				if (num > 0)
				{
					MessageBox.Show("Send Faield count: " + num.ToString());
				}
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
			panel2 = new System.Windows.Forms.Panel();
			label11 = new System.Windows.Forms.Label();
			textBox8 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			button4 = new System.Windows.Forms.Button();
			textBox6 = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			label2 = new System.Windows.Forms.Label();
			radioButton1 = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton3 = new System.Windows.Forms.RadioButton();
			radioButton4 = new System.Windows.Forms.RadioButton();
			panel2.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(label11);
			panel2.Controls.Add(textBox8);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(button4);
			panel2.Controls.Add(textBox6);
			panel2.Controls.Add(label10);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label9);
			panel2.Enabled = false;
			panel2.Location = new System.Drawing.Point(13, 120);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(977, 518);
			panel2.TabIndex = 20;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(59, 492);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(32, 17);
			label11.TabIndex = 20;
			label11.Text = "消息";
			textBox8.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox8.Location = new System.Drawing.Point(62, 214);
			textBox8.Multiline = true;
			textBox8.Name = "textBox8";
			textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox8.Size = new System.Drawing.Size(892, 272);
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
			textBox4.Location = new System.Drawing.Point(62, 13);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(892, 161);
			textBox4.TabIndex = 8;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(8, 13);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(44, 17);
			label9.TabIndex = 11;
			label9.Text = "数据：";
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(radioButton4);
			panel1.Controls.Add(radioButton3);
			panel1.Controls.Add(radioButton2);
			panel1.Controls.Add(radioButton1);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(13, 40);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(978, 73);
			panel1.TabIndex = 14;
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(490, 7);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(393, 7);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(277, 10);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(85, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "12345";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(219, 13);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 10);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(141, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 13);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7697782.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 21;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(8, 41);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 17);
			label2.TabIndex = 6;
			label2.Text = "编码：";
			radioButton1.AutoSize = true;
			radioButton1.Location = new System.Drawing.Point(58, 39);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(57, 21);
			radioButton1.TabIndex = 7;
			radioButton1.Text = "ASCII";
			radioButton1.UseVisualStyleBackColor = true;
			radioButton2.AutoSize = true;
			radioButton2.Location = new System.Drawing.Point(134, 39);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(55, 21);
			radioButton2.TabIndex = 8;
			radioButton2.Text = "ANSI";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton3.AutoSize = true;
			radioButton3.Location = new System.Drawing.Point(204, 39);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(74, 21);
			radioButton3.TabIndex = 9;
			radioButton3.Text = "Unicode";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton4.AutoSize = true;
			radioButton4.Checked = true;
			radioButton4.Location = new System.Drawing.Point(299, 39);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new System.Drawing.Size(55, 21);
			radioButton4.TabIndex = 10;
			radioButton4.TabStop = true;
			radioButton4.Text = "UTF8";
			radioButton4.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormPlainSocket";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormPlainSocket";
			base.Load += new System.EventHandler(FormComplexNet_Load);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
