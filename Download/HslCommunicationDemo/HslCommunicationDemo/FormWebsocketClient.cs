using HslCommunication;
using HslCommunication.LogNet;
using HslCommunication.WebSocket;
using HslCommunicationDemo.DemoControl;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormWebsocketClient : HslFormContent
	{
		private WebSocketClient wsClient;

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

		private TextBox textBox3;

		private Label label6;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private RadioButton radioButton5;

		private RadioButton radioButton4;

		private RadioButton radioButton3;

		private Panel panel3;

		private Label label7;

		private Button button5;

		private TextBox textBox5;

		private Label label8;

		private Label label10;

		private CheckBox checkBox1;

		private ComboBox comboBox1;

		private Label label11;

		private CheckBox checkBox_logHex;

		private RadioButton radioButton_hex;

		public FormWebsocketClient()
		{
			InitializeComponent();
		}

		private void FormClient_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			button2.Enabled = false;
			comboBox1.DataSource = DemoUtils.GetEncodings();
			comboBox1.SelectedIndex = 3;
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language == 1)
			{
				Text = "Websocket客户端";
				label1.Text = "Ip地址：";
				label3.Text = "端口号：";
				button1.Text = "连接";
				button2.Text = "断开连接";
				label6.Text = "主题：";
				label9.Text = "Payload：";
				button3.Text = "发送";
				button4.Text = "清空";
				label12.Text = "接收：";
				button5.Text = "压力测试";
			}
			else
			{
				Text = "Websocket Client Test";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label6.Text = "Topic:";
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
			WebSocketClient webSocketClient = wsClient;
			if (webSocketClient != null)
			{
				webSocketClient.ConnectClose();
			}
			wsClient = new WebSocketClient(textBox1.Text, int.Parse(textBox2.Text), textBox5.Text);
			wsClient.LogNet = new LogNetSingle(string.Empty);
			wsClient.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
			wsClient.OnClientApplicationMessageReceive += WebSocket_OnWebSocketMessageReceived;
			OperateResult operateResult = null;
			operateResult = ((!string.IsNullOrEmpty(textBox3.Text)) ? wsClient.ConnectServer(textBox3.Text.Split(new char[1]
			{
				','
			}, StringSplitOptions.RemoveEmptyEntries)) : wsClient.ConnectServer());
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

		private void WsClient_OnNetworkError(object sender, EventArgs e)
		{
			WebSocketClient webSocketClient = sender as WebSocketClient;
			if (webSocketClient != null)
			{
				ILogNet logNet = webSocketClient.LogNet;
				if (logNet != null)
				{
					logNet.WriteInfo("网络异常，准备10秒后重新连接。");
				}
				while (true)
				{
					Thread.Sleep(10000);
					ILogNet logNet2 = webSocketClient.LogNet;
					if (logNet2 != null)
					{
						logNet2.WriteInfo("准备重新连接服务器...");
					}
					if (webSocketClient.IsClosed)
					{
						return;
					}
					OperateResult operateResult = webSocketClient.ConnectServer();
					if (operateResult.IsSuccess)
					{
						break;
					}
					ILogNet logNet3 = webSocketClient.LogNet;
					if (logNet3 != null)
					{
						logNet3.WriteInfo("连接失败，准备10秒后重新连接。");
					}
				}
				ILogNet logNet4 = webSocketClient.LogNet;
				if (logNet4 != null)
				{
					logNet4.WriteInfo("连接服务器成功！");
				}
			}
		}

		private void WebSocket_OnWebSocketMessageReceived(WebSocketMessage message)
		{
			try
			{
				if (checkBox_logHex.Checked)
				{
					ILogNet logNet = wsClient.LogNet;
					if (logNet != null)
					{
						logNet.WriteDebug(wsClient.ToString(), string.Format("OpCode[{0}] HasMask[{1}] Payload: {2}", message.OpCode, message.HasMask, message.Payload.ToHexString(' ')));
					}
				}
				Invoke((Action)delegate
				{
					string empty = string.Empty;
					if (radioButton_hex.Checked)
					{
						empty = message.Payload.ToHexString(' ');
					}
					else
					{
						empty = DemoUtils.GetEncodingFromIndex(comboBox1.SelectedIndex).GetString(message.Payload);
						if (radioButton4.Checked)
						{
							try
							{
								empty = XElement.Parse(empty).ToString();
							}
							catch
							{
							}
						}
						else if (radioButton5.Checked)
						{
							try
							{
								empty = JObject.Parse(empty).ToString();
							}
							catch
							{
							}
						}
					}
					if (radioButton2.Checked)
					{
						ILogNet logNet2 = wsClient.LogNet;
						if (logNet2 != null)
						{
							logNet2.WriteInfo(empty);
						}
					}
					else if (radioButton1.Checked)
					{
						textBox8.Text = empty;
					}
				});
			}
			catch
			{
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
			WebSocketClient webSocketClient = wsClient;
			if (webSocketClient != null)
			{
				webSocketClient.ConnectClose();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = wsClient.SendServer(checkBox1.Checked, textBox4.Text);
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Send Failed:" + operateResult.Message);
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

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlUrl, textBox5.Text);
			element.SetAttributeValue(DemoDeviceList.XmlTimeout, textBox11.Text);
			element.SetAttributeValue(DemoDeviceList.XmlTopic, textBox3.Text);
			element.SetAttributeValue(DemoDeviceList.XmlUserName, textBox9.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPassword, textBox10.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox5.Text = element.Attribute(DemoDeviceList.XmlUrl).Value;
			textBox11.Text = element.Attribute(DemoDeviceList.XmlTimeout).Value;
			textBox3.Text = element.Attribute(DemoDeviceList.XmlTopic).Value;
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
			textBox5 = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			button5 = new System.Windows.Forms.Button();
			label7 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
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
			label10 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			checkBox_logHex = new System.Windows.Forms.CheckBox();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label11 = new System.Windows.Forms.Label();
			checkBox1 = new System.Windows.Forms.CheckBox();
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
			radioButton_hex = new System.Windows.Forms.RadioButton();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox5);
			panel1.Controls.Add(label8);
			panel1.Controls.Add(button5);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label6);
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
			panel1.Controls.Add(label10);
			panel1.Location = new System.Drawing.Point(3, 36);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 72);
			panel1.TabIndex = 7;
			textBox5.Location = new System.Drawing.Point(346, 2);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(221, 23);
			textBox5.TabIndex = 21;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(362, 25);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(127, 17);
			label8.TabIndex = 20;
			label8.Text = "举例 /A/B?C=123456";
			button5.Location = new System.Drawing.Point(897, 5);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(91, 28);
			button5.TabIndex = 19;
			button5.Text = "压力测试";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			label7.AutoSize = true;
			label7.ForeColor = System.Drawing.Color.Gray;
			label7.Location = new System.Drawing.Point(646, 44);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(338, 17);
			label7.TabIndex = 18;
			label7.Text = "主题只对hsl的websocket服务器有效，用户名密码暂时不支持";
			textBox3.Location = new System.Drawing.Point(62, 44);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(181, 23);
			textBox3.TabIndex = 17;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(8, 47);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(44, 17);
			label6.TabIndex = 16;
			label6.Text = "主题：";
			textBox11.Location = new System.Drawing.Point(639, 5);
			textBox11.Name = "textBox11";
			textBox11.Size = new System.Drawing.Size(51, 23);
			textBox11.TabIndex = 15;
			textBox11.Text = "5000";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(573, 8);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(68, 17);
			label5.TabIndex = 14;
			label5.Text = "接收超时：";
			textBox10.Location = new System.Drawing.Point(527, 43);
			textBox10.Name = "textBox10";
			textBox10.Size = new System.Drawing.Size(114, 23);
			textBox10.TabIndex = 13;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(463, 46);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(44, 17);
			label4.TabIndex = 12;
			label4.Text = "密码：";
			textBox9.Location = new System.Drawing.Point(313, 44);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(144, 23);
			textBox9.TabIndex = 11;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(249, 47);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(56, 17);
			label2.TabIndex = 10;
			label2.Text = "用户名：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(795, 3);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(698, 3);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(250, 3);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(65, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "1883";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(196, 6);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(59, 3);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(131, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(5, 6);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(317, 4);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(35, 17);
			label10.TabIndex = 22;
			label10.Text = "url：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(checkBox_logHex);
			panel2.Controls.Add(comboBox1);
			panel2.Controls.Add(label11);
			panel2.Controls.Add(checkBox1);
			panel2.Controls.Add(panel3);
			panel2.Controls.Add(radioButton2);
			panel2.Controls.Add(radioButton1);
			panel2.Controls.Add(textBox8);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(button4);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label9);
			panel2.Location = new System.Drawing.Point(3, 113);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 530);
			panel2.TabIndex = 13;
			checkBox_logHex.AutoSize = true;
			checkBox_logHex.Location = new System.Drawing.Point(252, 185);
			checkBox_logHex.Name = "checkBox_logHex";
			checkBox_logHex.Size = new System.Drawing.Size(81, 21);
			checkBox_logHex.TabIndex = 30;
			checkBox_logHex.Text = "Log Hex?";
			checkBox_logHex.UseVisualStyleBackColor = true;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(419, 182);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(100, 25);
			comboBox1.TabIndex = 29;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(346, 186);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(65, 17);
			label11.TabIndex = 28;
			label11.Text = "Encoding:";
			checkBox1.AutoSize = true;
			checkBox1.Checked = true;
			checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox1.Location = new System.Drawing.Point(166, 185);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(65, 21);
			checkBox1.TabIndex = 27;
			checkBox1.Text = "Mask?";
			checkBox1.UseVisualStyleBackColor = true;
			panel3.Controls.Add(radioButton_hex);
			panel3.Controls.Add(radioButton5);
			panel3.Controls.Add(radioButton3);
			panel3.Controls.Add(radioButton4);
			panel3.Location = new System.Drawing.Point(614, 179);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(243, 28);
			panel3.TabIndex = 26;
			radioButton5.AutoSize = true;
			radioButton5.Location = new System.Drawing.Point(165, 3);
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new System.Drawing.Size(52, 21);
			radioButton5.TabIndex = 28;
			radioButton5.Text = "Json";
			radioButton5.UseVisualStyleBackColor = true;
			radioButton3.AutoSize = true;
			radioButton3.Checked = true;
			radioButton3.Location = new System.Drawing.Point(55, 3);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(50, 21);
			radioButton3.TabIndex = 26;
			radioButton3.Text = "Text";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton4.AutoSize = true;
			radioButton4.Location = new System.Drawing.Point(111, 3);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new System.Drawing.Size(48, 21);
			radioButton4.TabIndex = 27;
			radioButton4.Text = "Xml";
			radioButton4.UseVisualStyleBackColor = true;
			radioButton2.AutoSize = true;
			radioButton2.Checked = true;
			radioButton2.Location = new System.Drawing.Point(534, 174);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(74, 21);
			radioButton2.TabIndex = 25;
			radioButton2.TabStop = true;
			radioButton2.Text = "追加显示";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton1.AutoSize = true;
			radioButton1.Location = new System.Drawing.Point(534, 193);
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
			textBox8.Size = new System.Drawing.Size(926, 311);
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
			textBox4.Size = new System.Drawing.Size(926, 171);
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
			radioButton_hex.AutoSize = true;
			radioButton_hex.Location = new System.Drawing.Point(3, 3);
			radioButton_hex.Name = "radioButton_hex";
			radioButton_hex.Size = new System.Drawing.Size(48, 21);
			radioButton_hex.TabIndex = 29;
			radioButton_hex.Text = "Hex";
			radioButton_hex.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormWebsocketClient";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Websocket客户端";
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
