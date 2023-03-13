using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core.Net;
using HslCommunication.Enthernet;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormComplexNet : HslFormContent
	{
		private NetComplexClient complexClient = null;

		private AutoResetEvent autoResetWait = new AutoResetEvent(false);

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

		private Label label8;

		private TextBox textBox5;

		private Label label7;

		private Panel panel1;

		private TextBox textBox9;

		private Label label13;

		private Button button6;

		private TextBox textBox3;

		private Label label6;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private Label label1;

		private Button button5;

		private Label label11;

		private UserControlHead userControlHead1;

		public FormComplexNet()
		{
			InitializeComponent();
		}

		private void FormComplexNet_Load(object sender, EventArgs e)
		{
			button2.Enabled = false;
			textBox3.Text = Guid.Empty.ToString();
			button5.Enabled = false;
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
					complexClient = new NetComplexClient();
					complexClient.ClientAlias = textBox9.Text;
					complexClient.EndPointServer = new IPEndPoint(address, result);
					complexClient.Token = new Guid(textBox3.Text);
					complexClient.AcceptString += ComplexClient_AcceptString;
					complexClient.AcceptByte += ComplexClient_AcceptByte;
					complexClient.MessageAlerts += ComplexClient_MessageAlerts;
					complexClient.ClientStart();
					button1.Enabled = false;
					button2.Enabled = true;
					panel2.Enabled = true;
				}
				catch (Exception ex)
				{
					SoftBasic.ShowExceptionMessage(ex);
				}
			}
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

		private void ComplexClient_AcceptByte(AppSession session, NetHandle handle, byte[] data)
		{
			ShowTextInfo(string.Format("{0} [{1}] [{2}] {3}", DateTime.Now, session.IpEndPoint, handle, SoftBasic.ByteToHexString(data)));
		}

		private void ComplexClient_AcceptString(AppSession session, NetHandle handle, string data)
		{
			ShowTextInfo(string.Format("{0} [{1}] [{2}] {3}", DateTime.Now, session.IpEndPoint, handle, data));
		}

		private void button2_Click(object sender, EventArgs e)
		{
			complexClient.ClientClose();
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;
		}

		private void ShowTextInfo(string text)
		{
			if (base.InvokeRequired)
			{
				Invoke(new Action<string>(ShowTextInfo), text);
			}
			else
			{
				textBox8.AppendText(text + Environment.NewLine);
			}
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
			int result;
			if (!int.TryParse(textBox6.Text, out result))
			{
				MessageBox.Show("数据发送次数输入异常");
			}
			else
			{
				for (int i = 0; i < result; i++)
				{
					complexClient.Send(netHandle, textBox4.Text);
				}
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Thread thread = new Thread(ServerPressureTest);
			thread.IsBackground = true;
			thread.Start();
			button6.Enabled = false;
			button5.Enabled = true;
		}

		private void ServerPressureTest()
		{
			NetComplexClient[] array = new NetComplexClient[100];
			for (int i = 0; i < 100; i++)
			{
				array[i] = new NetComplexClient();
				array[i].EndPointServer = new IPEndPoint(IPAddress.Parse(textBox1.Text), int.Parse(textBox2.Text));
				array[i].ClientAlias = "Client" + (i + 1).ToString();
				array[i].ClientStart();
			}
			Thread.Sleep(2000);
			int num = 0;
			for (int j = 0; j < 100; j++)
			{
				for (int k = 0; k < 100; k++)
				{
					array[k].Send(1, "测试消息" + num++.ToString());
				}
			}
			autoResetWait.WaitOne();
			for (int l = 0; l < 100; l++)
			{
				array[l].ClientClose();
			}
			Invoke((Action)delegate
			{
				button6.Enabled = true;
			});
		}

		private void button5_Click(object sender, EventArgs e)
		{
			autoResetWait.Set();
			button5.Enabled = false;
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlToken, textBox3.Text);
			element.SetAttributeValue(DemoDeviceList.XmlAlias, textBox9.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox3.Text = element.Attribute(DemoDeviceList.XmlToken).Value;
			textBox9.Text = element.Attribute(DemoDeviceList.XmlAlias).Value;
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
			label8 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			button5 = new System.Windows.Forms.Button();
			textBox9 = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			button6 = new System.Windows.Forms.Button();
			label6 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
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
			panel2.Controls.Add(label8);
			panel2.Controls.Add(textBox5);
			panel2.Controls.Add(label7);
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
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(button5);
			panel1.Controls.Add(textBox9);
			panel1.Controls.Add(label13);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(button6);
			panel1.Controls.Add(label6);
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
			button5.Enabled = false;
			button5.Location = new System.Drawing.Point(833, 35);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(140, 28);
			button5.TabIndex = 12;
			button5.Text = "关闭";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			textBox9.Location = new System.Drawing.Point(444, 10);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(107, 23);
			textBox9.TabIndex = 11;
			textBox9.Text = "test name";
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(390, 13);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 10;
			label13.Text = "别名：";
			textBox3.Location = new System.Drawing.Point(62, 43);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(489, 23);
			textBox3.TabIndex = 7;
			button6.Location = new System.Drawing.Point(833, 7);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(140, 28);
			button6.TabIndex = 9;
			button6.Text = "多客户端压力测试";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(8, 46);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(44, 17);
			label6.TabIndex = 6;
			label6.Text = "令牌：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(683, 5);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(586, 5);
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
			textBox2.Text = "12346";
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
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7697782.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Hsl - Complex";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 21;
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
			base.Name = "FormComplexNet";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormComplexNet";
			base.Load += new System.EventHandler(FormComplexNet_Load);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
