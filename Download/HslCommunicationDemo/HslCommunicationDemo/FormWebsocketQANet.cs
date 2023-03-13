using HslCommunication;
using HslCommunication.LogNet;
using HslCommunication.WebSocket;
using HslCommunicationDemo.DemoControl;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormWebsocketQANet : HslFormContent
	{
		private WebSocketQANet wsClient;

		private IContainer components = null;

		private Panel panel1;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private Label label1;

		private Panel panel2;

		private TextBox textBox8;

		private Label label12;

		private Button button4;

		private Button button3;

		private TextBox textBox4;

		private Label label9;

		private UserControlHead userControlHead1;

		private TextBox textBox10;

		private Label label4;

		private TextBox textBox9;

		private Label label2;

		private TextBox textBox11;

		private Label label5;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private RadioButton radioButton5;

		private RadioButton radioButton4;

		private RadioButton radioButton3;

		private Panel panel3;

		private Label label7;

		private Button button5;

		public FormWebsocketQANet()
		{
			InitializeComponent();
		}

		private void FormClient_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			button2.Enabled = false;
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language == 1)
			{
				Text = "Websocket同步访问客户端";
				label1.Text = "Ip地址：";
				label3.Text = "端口号：";
				button1.Text = "连接";
				button2.Text = "断开连接";
				label9.Text = "Payload：";
				button3.Text = "发送";
				button4.Text = "清空";
				label12.Text = "接收：";
				button5.Text = "压力测试";
			}
			else
			{
				Text = "Websocket QA Test";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label9.Text = "Payload:";
				button3.Text = "Send";
				button4.Text = "Clear";
				label12.Text = "Receive:";
				button5.Text = "Press Test";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			panel2.Enabled = true;
			if (!string.IsNullOrEmpty(textBox9.Text) || !string.IsNullOrEmpty(textBox10.Text))
			{
			}
			wsClient = new WebSocketQANet(textBox1.Text, int.Parse(textBox2.Text));
			wsClient.LogNet = new LogNetSingle(string.Empty);
			wsClient.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
			OperateResult operateResult = null;
			operateResult = wsClient.ConnectServer();
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

		private void LogNet_BeforeSaveToFile(object sender, HslEventArgs e)
		{
			try
			{
				Invoke((Action)delegate
				{
					if (radioButton2.Checked)
					{
						textBox8.AppendText(e.HslMessage.ToString() + Environment.NewLine);
					}
				});
			}
			catch
			{
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;
			wsClient.ConnectClose();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = wsClient.ReadFromServer(textBox4.Text);
			if (operateResult.IsSuccess)
			{
				string text = operateResult.Content;
				if (radioButton4.Checked)
				{
					try
					{
						text = XElement.Parse(text).ToString();
					}
					catch
					{
					}
				}
				else if (radioButton5.Checked)
				{
					try
					{
						text = JObject.Parse(text).ToString();
					}
					catch
					{
					}
				}
				if (radioButton2.Checked)
				{
					textBox8.AppendText(text + Environment.NewLine);
				}
				else if (radioButton1.Checked)
				{
					textBox8.Text = text;
				}
			}
			else
			{
				MessageBox.Show("read Failed:" + operateResult.Message);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			textBox8.Clear();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			button5.Enabled = false;
			MessageBox.Show("暂时不支持");
		}

		private void ThreadPoolTest()
		{
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlTimeout, textBox11.Text);
			element.SetAttributeValue(DemoDeviceList.XmlUserName, textBox9.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPassword, textBox10.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox11.Text = element.Attribute(DemoDeviceList.XmlTimeout).Value;
			textBox9.Text = element.Attribute(DemoDeviceList.XmlUserName).Value;
			textBox10.Text = element.Attribute(DemoDeviceList.XmlPassword).Value;
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
			button5 = new System.Windows.Forms.Button();
			label7 = new System.Windows.Forms.Label();
			textBox11 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			textBox10 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox9 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			panel3 = new System.Windows.Forms.Panel();
			radioButton5 = new System.Windows.Forms.RadioButton();
			radioButton3 = new System.Windows.Forms.RadioButton();
			radioButton4 = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton1 = new System.Windows.Forms.RadioButton();
			textBox8 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(button5);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(textBox11);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(textBox10);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(textBox9);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 72);
			panel1.TabIndex = 7;
			button5.Location = new System.Drawing.Point(882, 5);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(91, 28);
			button5.TabIndex = 19;
			button5.Text = "压力测试";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			label7.AutoSize = true;
			label7.ForeColor = System.Drawing.Color.Gray;
			label7.Location = new System.Drawing.Point(341, 44);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(338, 17);
			label7.TabIndex = 18;
			label7.Text = "主题只对hsl的websocket服务器有效，用户名密码暂时不支持";
			textBox11.Location = new System.Drawing.Point(446, 8);
			textBox11.Name = "textBox11";
			textBox11.Size = new System.Drawing.Size(79, 23);
			textBox11.TabIndex = 15;
			textBox11.Text = "5000";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(380, 11);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(68, 17);
			label5.TabIndex = 14;
			label5.Text = "接收超时：";
			textBox10.Location = new System.Drawing.Point(244, 41);
			textBox10.Name = "textBox10";
			textBox10.Size = new System.Drawing.Size(91, 23);
			textBox10.TabIndex = 13;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(180, 44);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(44, 17);
			label4.TabIndex = 12;
			label4.Text = "密码：";
			textBox9.Location = new System.Drawing.Point(73, 41);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(91, 23);
			textBox9.TabIndex = 11;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(9, 44);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(56, 17);
			label2.TabIndex = 10;
			label2.Text = "用户名：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(664, 5);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(567, 5);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(279, 8);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(79, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "1883";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(225, 11);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 8);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(141, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 11);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(panel3);
			panel2.Controls.Add(radioButton2);
			panel2.Controls.Add(radioButton1);
			panel2.Controls.Add(textBox8);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(button4);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label9);
			panel2.Location = new System.Drawing.Point(3, 111);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 534);
			panel2.TabIndex = 13;
			panel3.Controls.Add(radioButton5);
			panel3.Controls.Add(radioButton3);
			panel3.Controls.Add(radioButton4);
			panel3.Location = new System.Drawing.Point(651, 179);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(184, 28);
			panel3.TabIndex = 26;
			radioButton5.AutoSize = true;
			radioButton5.Location = new System.Drawing.Point(123, 3);
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new System.Drawing.Size(52, 21);
			radioButton5.TabIndex = 28;
			radioButton5.Text = "Json";
			radioButton5.UseVisualStyleBackColor = true;
			radioButton3.AutoSize = true;
			radioButton3.Checked = true;
			radioButton3.Location = new System.Drawing.Point(13, 3);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(50, 21);
			radioButton3.TabIndex = 26;
			radioButton3.TabStop = true;
			radioButton3.Text = "Text";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton4.AutoSize = true;
			radioButton4.Location = new System.Drawing.Point(69, 3);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new System.Drawing.Size(48, 21);
			radioButton4.TabIndex = 27;
			radioButton4.Text = "Xml";
			radioButton4.UseVisualStyleBackColor = true;
			radioButton2.AutoSize = true;
			radioButton2.Checked = true;
			radioButton2.Location = new System.Drawing.Point(567, 174);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(74, 21);
			radioButton2.TabIndex = 25;
			radioButton2.TabStop = true;
			radioButton2.Text = "追加显示";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton1.AutoSize = true;
			radioButton1.Location = new System.Drawing.Point(567, 193);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(74, 21);
			radioButton1.TabIndex = 24;
			radioButton1.Text = "覆盖显示";
			radioButton1.UseVisualStyleBackColor = true;
			textBox8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox8.Location = new System.Drawing.Point(62, 214);
			textBox8.Multiline = true;
			textBox8.Name = "textBox8";
			textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox8.Size = new System.Drawing.Size(930, 315);
			textBox8.TabIndex = 18;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(4, 217);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(61, 17);
			label12.TabIndex = 19;
			label12.Text = "receive：";
			button4.Location = new System.Drawing.Point(863, 180);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(91, 28);
			button4.TabIndex = 17;
			button4.Text = "清空";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button3.Location = new System.Drawing.Point(62, 180);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(91, 28);
			button3.TabIndex = 12;
			button3.Text = "发送";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox4.Location = new System.Drawing.Point(62, 3);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(930, 171);
			textBox4.TabIndex = 8;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(5, 6);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(66, 17);
			label9.TabIndex = 11;
			label9.Text = "Payload：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/12303098.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "WebSocket";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 14;
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
			base.Name = "FormWebsocketQANet";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Websocket同步访问客户端";
			base.Load += new System.EventHandler(FormClient_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			ResumeLayout(false);
		}
	}
}
