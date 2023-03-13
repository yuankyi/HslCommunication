using HslCommunication;
using HslCommunication.Enthernet;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormPushNet : HslFormContent
	{
		private NetPushClient pushClient;

		private int receiveCount = 0;

		private IContainer components = null;

		private Panel panel1;

		private Label label21;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private Label label1;

		private TextBox textBox3;

		private Label label6;

		private TextBox textBox15;

		private Panel panel2;

		private TextBox textBox4;

		private Label label9;

		private Label label10;

		private Label label8;

		private Label label7;

		private UserControlHead userControlHead1;

		public FormPushNet()
		{
			InitializeComponent();
		}

		private void FormPushNet_Load(object sender, EventArgs e)
		{
			textBox15.Text = Guid.Empty.ToString();
			panel2.Enabled = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show("端口号输入错误");
			}
			else if (string.IsNullOrEmpty(textBox3.Text))
			{
				MessageBox.Show("关键字不能为空");
			}
			else
			{
				NetPushClient netPushClient = pushClient;
				if (netPushClient != null)
				{
					netPushClient.ClosePush();
				}
				pushClient = new NetPushClient(textBox1.Text, result, textBox3.Text);
				OperateResult operateResult = pushClient.CreatePush(PushFromServer);
				if (operateResult.IsSuccess)
				{
					button1.Enabled = false;
					button2.Enabled = true;
					MessageBox.Show("成功");
					panel2.Enabled = true;
				}
				else
				{
					MessageBox.Show("失败：" + operateResult.Message);
				}
			}
		}

		private void PushFromServer(NetPushClient pushClient, string data)
		{
			if (base.IsHandleCreated)
			{
				Invoke((Action<string>)delegate(string m)
				{
					label8.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
					receiveCount++;
					label9.Text = receiveCount.ToString();
					textBox4.Text = m;
				}, data);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			NetPushClient netPushClient = pushClient;
			if (netPushClient != null)
			{
				netPushClient.ClosePush();
			}
			panel2.Enabled = false;
			button1.Enabled = true;
			button2.Enabled = false;
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlToken, textBox15.Text);
			element.SetAttributeValue(DemoDeviceList.XmlTopic, textBox3.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox15.Text = element.Attribute(DemoDeviceList.XmlToken).Value;
			textBox3.Text = element.Attribute(DemoDeviceList.XmlTopic).Value;
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
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			textBox15 = new System.Windows.Forms.TextBox();
			label21 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			textBox4 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(textBox15);
			panel1.Controls.Add(label21);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(14, 38);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(978, 54);
			panel1.TabIndex = 1;
			textBox3.Location = new System.Drawing.Point(673, 14);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(76, 23);
			textBox3.TabIndex = 9;
			textBox3.Text = "A";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(619, 17);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(56, 17);
			label6.TabIndex = 8;
			label6.Text = "关键字：";
			textBox15.Location = new System.Drawing.Point(386, 14);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(227, 23);
			textBox15.TabIndex = 7;
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(332, 17);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(44, 17);
			label21.TabIndex = 6;
			label21.Text = "令牌：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(875, 11);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(772, 11);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(250, 14);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(76, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "12345";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(196, 17);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 14);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(128, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 17);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label9);
			panel2.Controls.Add(label10);
			panel2.Controls.Add(label8);
			panel2.Controls.Add(label7);
			panel2.Location = new System.Drawing.Point(14, 99);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(978, 534);
			panel2.TabIndex = 12;
			textBox4.Location = new System.Drawing.Point(11, 69);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(955, 450);
			textBox4.TabIndex = 8;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(82, 38);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(15, 17);
			label9.TabIndex = 6;
			label9.Text = "0";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(8, 38);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(68, 17);
			label10.TabIndex = 5;
			label10.Text = "接收次数：";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(82, 11);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(15, 17);
			label8.TabIndex = 4;
			label8.Text = "0";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(8, 11);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(68, 17);
			label7.TabIndex = 3;
			label7.Text = "接收时间：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/8992315.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Hsl - push net";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 13;
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
			base.Name = "FormPushNet";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "数据推送客户端";
			base.Load += new System.EventHandler(FormPushNet_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
