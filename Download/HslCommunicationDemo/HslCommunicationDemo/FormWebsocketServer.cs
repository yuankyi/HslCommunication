using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.LogNet;
using HslCommunication.WebSocket;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormWebsocketServer : HslFormContent
	{
		private System.Windows.Forms.Timer timer1s;

		private WebSocketServer wsServer;

		private Random random = new Random();

		private bool startThreadPublish = false;

		private Thread thread;

		private bool isStop = false;

		private IContainer components = null;

		private Panel panel1;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private Panel panel2;

		private TextBox textBox8;

		private Label label12;

		private Button button4;

		private Button button3;

		private TextBox textBox4;

		private Label label9;

		private Label label8;

		private TextBox textBox5;

		private Label label7;

		private UserControlHead userControlHead1;

		private Button button5;

		private Button button6;

		private CheckBox checkBox1;

		private Label label2;

		private Button button7;

		private CheckBox checkBox2;

		private CheckBox checkBox3;

		private Button button8;

		private ListBox listBox1;

		private Label label5;

		private Button button9;

		private CheckBox checkBox_willcard;

		private Panel panel3;

		private Button button10;

		private TextBox textBox_certFile;

		private CheckBox checkBox_ssl;

		public FormWebsocketServer()
		{
			InitializeComponent();
		}

		private void FormClient_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			button2.Enabled = false;
			Language(Program.Language);
			timer1s = new System.Windows.Forms.Timer();
			timer1s.Interval = 1000;
			timer1s.Tick += Timer1s_Tick;
			timer1s.Start();
		}

		private void Timer1s_Tick(object sender, EventArgs e)
		{
			if (wsServer != null)
			{
				label2.Text = "Online Count:" + wsServer.OnlineCount.ToString();
				listBox1.DataSource = wsServer.OnlineSessions;
			}
		}

		private void Language(int language)
		{
			if (language == 1)
			{
				Text = "Websocket服务器";
				label3.Text = "端口：";
				button1.Text = "启动服务";
				button2.Text = "关闭服务";
				button5.Text = "广播100K数据";
				label7.Text = "Topic：";
				label8.Text = "主题";
				label9.Text = "Payload：";
				button3.Text = "广播内容";
				button4.Text = "清空";
				label12.Text = "接收：";
				checkBox2.Text = "是否开启订阅缓存";
			}
			else
			{
				Text = "Websocket Server Test";
				label3.Text = "Port:";
				button1.Text = "Start";
				button2.Text = "Close";
				button5.Text = "Publish 100K Data";
				label7.Text = "Topic:";
				label8.Text = "";
				label9.Text = "Payload:";
				button3.Text = "Publish Payload";
				button4.Text = "Clear";
				label12.Text = "Receive:";
				checkBox2.Text = "Start Topic Cache";
				checkBox3.Text = "Send test message back when client connect";
				button8.Text = "web test";
				checkBox_willcard.Text = "Topic willcard?";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				wsServer = new WebSocketServer();
				wsServer.OnClientApplicationMessageReceive += WebSocket_OnClientApplicationMessageReceive;
				wsServer.OnClientConnected += WsServer_OnClientConnected;
				wsServer.IsTopicRetain = checkBox2.Checked;
				if (checkBox_ssl.Checked)
				{
					wsServer.UseSSL(textBox_certFile.Text);
				}
				wsServer.ServerStart(int.Parse(textBox2.Text));
				wsServer.LogNet = new LogNetSingle("");
				wsServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
				wsServer.TopicWildcard = checkBox_willcard.Checked;
				button1.Enabled = false;
				button2.Enabled = true;
				panel2.Enabled = true;
				MessageBox.Show("Start Success");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Start Failed : " + ex.Message);
			}
		}

		private void WsServer_OnClientConnected(WebSocketSession session)
		{
			if (checkBox3.Checked)
			{
				wsServer.SendClientPayload(session, "This a test message when client connect, url:" + session.Url);
			}
		}

		private void WebSocket_OnClientApplicationMessageReceive(WebSocketSession session, WebSocketMessage message)
		{
			Invoke((Action)delegate
			{
				if (!isStop)
				{
					textBox8.AppendText(string.Format("OpCode:[{0}] Mask:[{1}] Payload:[{2}]", message.OpCode, message.HasMask, Encoding.UTF8.GetString(message.Payload)) + Environment.NewLine);
				}
			});
			if (session.IsQASession)
			{
				wsServer.SendClientPayload(session, Encoding.UTF8.GetString(message.Payload) + random.Next(1000, 10000).ToString());
			}
		}

		private void LogNet_BeforeSaveToFile(object sender, HslEventArgs e)
		{
			Invoke((Action)delegate
			{
				textBox8.AppendText(e.HslMessage.ToString() + Environment.NewLine);
			});
		}

		private void button2_Click(object sender, EventArgs e)
		{
			button5.Enabled = true;
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;
			wsServer.ServerClose();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			wsServer.PublishAllClientPayload(textBox4.Text);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			textBox8.Clear();
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < 102400; i++)
			{
				stringBuilder.Append("2");
			}
			wsServer.PublishAllClientPayload(stringBuilder.ToString());
		}

		private void button9_Click(object sender, EventArgs e)
		{
			if (startThreadPublish)
			{
				startThreadPublish = false;
				button9.Text = "高频发布测试";
			}
			else
			{
				startThreadPublish = true;
				button9.Text = "停止";
				if (thread == null)
				{
					thread = new Thread(ThreadTest);
					thread.IsBackground = true;
					thread.Start();
				}
			}
		}

		private void ThreadTest()
		{
			int num = 0;
			while (true)
			{
				Thread.Sleep(200);
				if (startThreadPublish)
				{
					DateTime now = DateTime.Now;
					for (int i = 0; i < 10; i++)
					{
						byte[] array = new byte[1024];
						random.NextBytes(array);
						wsServer.PublishAllClientPayload(array.ToHexString() + "\r\n上次平均耗时：" + num.ToString() + "ms");
					}
					num = Convert.ToInt32((DateTime.Now - now).TotalSeconds / 10.0);
				}
			}
		}

		private void button6_Click_1(object sender, EventArgs e)
		{
			wsServer.PublishClientPayload(textBox5.Text, textBox4.Text);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (!isStop)
			{
				button7.Text = "继续";
				isStop = true;
			}
			else
			{
				isStop = false;
				button7.Text = "暂停";
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			string contents = "<html>\r\n\t<head>\r\n\t\t<title>\r\n\t\t\t测试的websocket信息-hslcommunication\r\n\t\t</title>\r\n\t</head>\r\n\t<body>\r\n\t\t<div id=\"hsl\"></div>\r\n\t</body>\r\n\t<script type=\"text/javascript\">\r\n\t\tif (\"WebSocket\" in window)\r\n\t\t{\r\n\t\t\t// 打开一个 web socket\r\n\t\t\tvar ws = new WebSocket('ws" + (checkBox_ssl.Checked ? "s" : "") + "://127.0.0.1:" + textBox2.Text + "');\r\n\t\t\tvar count = 0;\r\n\t\t\tws.onopen = function()\r\n\t\t\t{\r\n\t\t\t\t console.log('已经打开...');\r\n\t\t\t};\r\n\t\t\tws.onmessage = function (evt)\r\n\t\t\t{\r\n\t\t\t\tvar received_msg = evt.data;\r\n\t\t\t\tvar obj = document.getElementById('hsl');\r\n\t\t\t\tobj.innerText = received_msg;\r\n\t\t\t\tcount++;\r\n\t\t\t};\r\n\t\t\tvar int=self.setInterval(\"clock()\",1000);\r\n\t\t\tfunction clock()\r\n\t\t\t{\r\n\t\t\t\t console.log('接收次数:' + count);\r\n\t\t\t}\r\n\t\t}\r\n\t\telse\r\n\t\t{\r\n\t\t\tvar obj = document.getElementById('hsl');\r\n\t\t\tobj.innerText = '您的浏览器不支持 WebSocket!';\r\n\t\t}\r\n\t</script>\r\n</html>";
			try
			{
				File.WriteAllText("websocket.html", contents, Encoding.UTF8);
				Process.Start("websocket.html");
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage(ex);
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlTagCache, checkBox2.Checked);
			element.SetAttributeValue(DemoDeviceList.XmlRetureMessage, checkBox3.Checked);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			checkBox2.Checked = bool.Parse(element.Attribute(DemoDeviceList.XmlTagCache).Value);
			checkBox3.Checked = bool.Parse(element.Attribute(DemoDeviceList.XmlRetureMessage).Value);
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
		}

		private void button10_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					textBox_certFile.Text = openFileDialog.FileName;
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
			panel1 = new System.Windows.Forms.Panel();
			checkBox_willcard = new System.Windows.Forms.CheckBox();
			checkBox3 = new System.Windows.Forms.CheckBox();
			checkBox2 = new System.Windows.Forms.CheckBox();
			checkBox1 = new System.Windows.Forms.CheckBox();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			button9 = new System.Windows.Forms.Button();
			listBox1 = new System.Windows.Forms.ListBox();
			label5 = new System.Windows.Forms.Label();
			button8 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			textBox8 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel3 = new System.Windows.Forms.Panel();
			checkBox_ssl = new System.Windows.Forms.CheckBox();
			textBox_certFile = new System.Windows.Forms.TextBox();
			button10 = new System.Windows.Forms.Button();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(panel3);
			panel1.Controls.Add(checkBox_willcard);
			panel1.Controls.Add(checkBox3);
			panel1.Controls.Add(checkBox2);
			panel1.Controls.Add(checkBox1);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 72);
			panel1.TabIndex = 7;
			checkBox_willcard.AutoSize = true;
			checkBox_willcard.Location = new System.Drawing.Point(162, 40);
			checkBox_willcard.Name = "checkBox_willcard";
			checkBox_willcard.Size = new System.Drawing.Size(99, 21);
			checkBox_willcard.TabIndex = 9;
			checkBox_willcard.Text = "订阅通配符？";
			checkBox_willcard.UseVisualStyleBackColor = true;
			checkBox3.AutoSize = true;
			checkBox3.Checked = true;
			checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox3.Location = new System.Drawing.Point(280, 40);
			checkBox3.Name = "checkBox3";
			checkBox3.Size = new System.Drawing.Size(147, 21);
			checkBox3.TabIndex = 8;
			checkBox3.Text = "是否回发一条测试数据";
			checkBox3.UseVisualStyleBackColor = true;
			checkBox2.AutoSize = true;
			checkBox2.Checked = true;
			checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox2.Location = new System.Drawing.Point(11, 40);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new System.Drawing.Size(123, 21);
			checkBox2.TabIndex = 7;
			checkBox2.Text = "是否开启订阅缓存";
			checkBox2.UseVisualStyleBackColor = true;
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(468, 8);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(288, 21);
			checkBox1.TabIndex = 6;
			checkBox1.Text = "启用用户名和密码(用户名 admin  密码: 123456)";
			checkBox1.UseVisualStyleBackColor = true;
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(353, 8);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭服务";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(256, 8);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "启动服务";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(62, 11);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(160, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "1883";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(8, 14);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(button9);
			panel2.Controls.Add(listBox1);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(button8);
			panel2.Controls.Add(button7);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(button6);
			panel2.Controls.Add(button5);
			panel2.Controls.Add(textBox8);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(button4);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label9);
			panel2.Controls.Add(label8);
			panel2.Controls.Add(textBox5);
			panel2.Controls.Add(label7);
			panel2.Location = new System.Drawing.Point(3, 111);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 531);
			panel2.TabIndex = 13;
			button9.Location = new System.Drawing.Point(450, 180);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(145, 28);
			button9.TabIndex = 34;
			button9.Text = "高频发布测试";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			listBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			listBox1.BackColor = System.Drawing.Color.LightGray;
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 17;
			listBox1.Location = new System.Drawing.Point(649, 33);
			listBox1.Name = "listBox1";
			listBox1.Size = new System.Drawing.Size(339, 140);
			listBox1.TabIndex = 33;
			label5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(652, 13);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(93, 17);
			label5.TabIndex = 32;
			label5.Text = "Online Client：";
			button8.Location = new System.Drawing.Point(633, 180);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(102, 28);
			button8.TabIndex = 29;
			button8.Text = "测试网页";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			button7.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button7.Location = new System.Drawing.Point(773, 180);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(91, 28);
			button7.TabIndex = 28;
			button7.Text = "暂停";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			label2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(902, 13);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(86, 17);
			label2.TabIndex = 27;
			label2.Text = "Online Count:";
			button6.Location = new System.Drawing.Point(170, 180);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(91, 28);
			button6.TabIndex = 26;
			button6.Text = "广播订阅";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click_1);
			button5.Location = new System.Drawing.Point(280, 180);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(164, 28);
			button5.TabIndex = 20;
			button5.Text = "发布100K数据";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(Button5_Click);
			textBox8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox8.Location = new System.Drawing.Point(62, 214);
			textBox8.Multiline = true;
			textBox8.Name = "textBox8";
			textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox8.Size = new System.Drawing.Size(926, 312);
			textBox8.TabIndex = 18;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(8, 217);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(61, 17);
			label12.TabIndex = 19;
			label12.Text = "receive：";
			button4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button4.Location = new System.Drawing.Point(897, 180);
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
			button3.Text = "广播内容";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox4.Location = new System.Drawing.Point(62, 36);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(581, 138);
			textBox4.TabIndex = 8;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(8, 39);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(66, 17);
			label9.TabIndex = 11;
			label9.Text = "Payload：";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(249, 11);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(56, 17);
			label8.TabIndex = 10;
			label8.Text = "主题信息";
			textBox5.Location = new System.Drawing.Point(62, 7);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(181, 23);
			textBox5.TabIndex = 9;
			textBox5.Text = "A";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(8, 11);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(52, 17);
			label7.TabIndex = 7;
			label7.Text = "Topic：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/12303098.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Websocket";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 14;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			panel3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel3.Controls.Add(button10);
			panel3.Controls.Add(textBox_certFile);
			panel3.Controls.Add(checkBox_ssl);
			panel3.Location = new System.Drawing.Point(450, 32);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(541, 31);
			panel3.TabIndex = 10;
			checkBox_ssl.AutoSize = true;
			checkBox_ssl.Location = new System.Drawing.Point(18, 5);
			checkBox_ssl.Name = "checkBox_ssl";
			checkBox_ssl.Size = new System.Drawing.Size(59, 21);
			checkBox_ssl.TabIndex = 10;
			checkBox_ssl.Text = "SSL？";
			checkBox_ssl.UseVisualStyleBackColor = true;
			textBox_certFile.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_certFile.Location = new System.Drawing.Point(83, 3);
			textBox_certFile.Name = "textBox_certFile";
			textBox_certFile.Size = new System.Drawing.Size(408, 23);
			textBox_certFile.TabIndex = 11;
			button10.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button10.Location = new System.Drawing.Point(497, 0);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(44, 28);
			button10.TabIndex = 29;
			button10.Text = "FILE";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(button10_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormWebsocketServer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Websocket 服务器";
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
