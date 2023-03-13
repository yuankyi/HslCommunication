using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using HslCommunication.Enthernet;
using HslCommunication.MQTT;
using HslCommunication.Profinet.AllenBradley;
using HslCommunication.Profinet.Siemens;
using HslCommunication.Reflection;
using HslCommunicationDemo.DemoControl;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormHttpServer : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003CReadDatabaseAsync_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<short> _003C_003Et__builder;

			public string abc;

			public FormHttpServer _003C_003E4__this;

			private short _003C_003Es__1;

			private TaskAwaiter _003C_003Eu__1;

			private TaskAwaiter<short> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				short result;
				try
				{
					TaskAwaiter awaiter2;
					TaskAwaiter<short> awaiter;
					switch (num)
					{
					default:
						awaiter2 = Task.Delay(1000).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CReadDatabaseAsync_003Ed__14 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
							return;
						}
						goto IL_0076;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0076;
					case 1:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<short>);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0076:
						awaiter2.GetResult();
						awaiter = Task.FromResult(short.Parse(abc)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CReadDatabaseAsync_003Ed__14 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						break;
					}
					_003C_003Es__1 = awaiter.GetResult();
					result = _003C_003Es__1;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetResult(result);
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private AllenBradleyPcccNet pcccNet;

		private SiemensS7Net siemens;

		private HttpServer httpServer;

		private Dictionary<string, UserWebApis> userApis = new Dictionary<string, UserWebApis>();

		private IContainer components = null;

		private Panel panel1;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private Panel panel2;

		private Label label12;

		private Button button_get;

		private TextBox textBox_body;

		private Label label9;

		private Label label8;

		private TextBox textBox_api;

		private Label label7;

		private UserControlHead userControlHead1;

		private Button button_post;

		private WebBrowser webBrowser1;

		private Button button2;

		private TextBox textBox1;

		private Button button4;

		private CheckBox checkBox_IsCrossDomain;

		private Label label1;

		private ComboBox comboBox1;

		private CheckBox checkBox2;

		private Panel panel3;

		private ListBox listBox1;

		private Label label2;

		private Button button_delete;

		public FormHttpServer()
		{
			InitializeComponent();
		}

		private void FormClient_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			comboBox1.DataSource = new string[5]
			{
				"text/html",
				"text/plain",
				"text/xml",
				"application/xml",
				"application/json"
			};
			Language(Program.Language);
			listBox1.SelectedValueChanged += ListBox1_SelectedValueChanged;
		}

		private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			UserWebApis userWebApis = listBox1.SelectedItem as UserWebApis;
			if (userWebApis != null)
			{
				textBox_api.Text = userWebApis.Name;
				textBox_body.Text = userWebApis.Body;
				comboBox1.SelectedItem = userWebApis.ContentType;
			}
		}

		private void Language(int language)
		{
			if (language != 1)
			{
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				siemens = new SiemensS7Net(SiemensPLCS.S1200, "127.0.0.1");
				siemens.SetPersistentConnection();
				pcccNet = new AllenBradleyPcccNet("127.0.0.1");
				pcccNet.SetPersistentConnection();
				httpServer = new HttpServer();
				httpServer.Start(int.Parse(textBox2.Text));
				httpServer.HandleRequestFunc = HandleRequest;
				httpServer.HandleFileUpload = HandleFileUpload;
				httpServer.IsCrossDomain = checkBox_IsCrossDomain.Checked;
				httpServer.RegisterHttpRpcApi("", this);
				httpServer.RegisterHttpRpcApi("Siemens", siemens);
				httpServer.RegisterHttpRpcApi("TimeOut", typeof(HslTimeOut));
				httpServer.RegisterHttpRpcApi("PCCC", pcccNet);
				httpServer.DealWithHttpListenerRequest = DealWithHttpListenerRequest;
				if (checkBox2.Checked)
				{
					httpServer.SetLoginAccessControl(new MqttCredential[1]
					{
						new MqttCredential("admin", "123456")
					});
				}
				panel2.Enabled = true;
				button1.Enabled = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Started Failed:" + ex.Message);
			}
		}

		private void DealWithHttpListenerRequest(HttpListenerRequest request, ISessionContext session)
		{
			string[] values = request.Headers.GetValues("ClientID");
			if (values != null && values.Length != 0)
			{
				session.ClientId = values[0];
			}
		}

		private void RenderGetPost()
		{
			listBox1.SelectedValueChanged -= ListBox1_SelectedValueChanged;
			listBox1.DataSource = userApis.Values.ToList();
			listBox1.SelectedValueChanged += ListBox1_SelectedValueChanged;
		}

		[HslMqttApi(HttpMethod = "POST")]
		public OperateResult CheckAccount(ISessionContext session, string name, string password)
		{
			if (string.IsNullOrEmpty(session.ClientId))
			{
				if (name != "admin")
				{
					return new OperateResult("用户名错误");
				}
				if (password != "123456")
				{
					return new OperateResult("密码错误");
				}
				return OperateResult.CreateSuccessResult();
			}
			return new OperateResult("ClientID: " + session.ClientId);
		}

		[HslMqttApi(HttpMethod = "GET")]
		public OperateResult CheckAccountChinese(string name, string password)
		{
			if (name != "张三")
			{
				return new OperateResult("用户名错误");
			}
			if (password != "123456")
			{
				return new OperateResult("密码错误");
			}
			return OperateResult.CreateSuccessResult();
		}

		[HslMqttApi(HttpMethod = "GET")]
		public OperateResult 检查AccountChinese(string name, string password)
		{
			if (name != "张三")
			{
				return new OperateResult("用户名错误");
			}
			if (password != "123456")
			{
				return new OperateResult("密码错误");
			}
			return OperateResult.CreateSuccessResult();
		}

		[AsyncStateMachine(typeof(_003CReadDatabaseAsync_003Ed__14))]
		[DebuggerStepThrough]
		[HslMqttApi("异步的读取方法，需要传入字符串的值")]
		public Task<short> ReadDatabaseAsync(string abc = "123")
		{
			_003CReadDatabaseAsync_003Ed__14 stateMachine = new _003CReadDatabaseAsync_003Ed__14();
			stateMachine._003C_003Et__builder = AsyncTaskMethodBuilder<short>.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.abc = abc;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
			return stateMachine._003C_003Et__builder.Task;
		}

		[HslMqttApi("异步的读取方法，需要传入字符串的值")]
		public Task WriteDatabaseAsync(string abc = "123")
		{
			return Task.Delay(500);
		}

		[HslMqttApi(HttpMethod = "GET")]
		public int GetHslCommunication(int id)
		{
			return id + 1;
		}

		[HslMqttApi(HttpMethod = "POST")]
		public int GetTest(int id)
		{
			return id + 1;
		}

		[HslMqttApi(HttpMethod = "POST")]
		public string GetJObjectTest(JObject json)
		{
			return json.ToString();
		}

		[HslMqttApi("读取设备的Int16信息，address: 设备的地址 length: 读取的数据长度")]
		public short ReadFloat(ISessionContext context, string address, short length = 12345)
		{
			if (((context != null) ? context.UserName : null) != "hsl")
			{
				return -100;
			}
			return (short)HslHelper.HslRandom.Next(10000);
		}

		[HslMqttApi("读取设备的信息，address: 设备的地址 length: 读取的数据长度")]
		public OperateResult<int, string> ReadABC(string address)
		{
			return OperateResult.CreateSuccessResult(HslHelper.HslRandom.Next(1000), "成功:" + address);
		}

		private string HandleFileUpload(HttpListenerRequest request, HttpListenerResponse response, HttpUploadFile file)
		{
			File.WriteAllBytes(Path.Combine(Application.StartupPath, file.FileName), file.Content);
			return "GET/POST File";
		}

		private string HandleRequest(HttpListenerRequest request, HttpListenerResponse response, string data)
		{
			if (request.RawUrl.StartsWith("/FormHttpServer/"))
			{
				return HttpServer.HandleObjectMethod(request, request.RawUrl, data, this, null).Result;
			}
			if (userApis.ContainsKey(request.RawUrl))
			{
				if (request.HttpMethod == userApis[request.RawUrl].HttpMethod)
				{
					response.AddHeader("Content-type", userApis[request.RawUrl].ContentType + "; charset=utf-8");
					return userApis[request.RawUrl].Body;
				}
				return "GET/POST Wrong";
			}
			return "Undefined Apis";
		}

		private void button3_Click(object sender, EventArgs e)
		{
			UserWebApis userWebApis = new UserWebApis
			{
				Name = textBox_api.Text,
				HttpMethod = "GET",
				ContentType = comboBox1.SelectedItem.ToString(),
				Body = textBox_body.Text
			};
			if (userApis.ContainsKey(userWebApis.Name))
			{
				userApis[userWebApis.Name] = userWebApis;
			}
			else
			{
				userApis.Add(userWebApis.Name, userWebApis);
			}
			RenderGetPost();
		}

		private void Button7_Click(object sender, EventArgs e)
		{
			UserWebApis userWebApis = new UserWebApis
			{
				Name = textBox_api.Text,
				HttpMethod = "POST",
				ContentType = comboBox1.SelectedItem.ToString(),
				Body = textBox_body.Text
			};
			if (userApis.ContainsKey(userWebApis.Name))
			{
				userApis[userWebApis.Name] = userWebApis;
			}
			else
			{
				userApis.Add(userWebApis.Name, userWebApis);
			}
			RenderGetPost();
		}

		private void button_delete_Click(object sender, EventArgs e)
		{
			if (userApis.ContainsKey(textBox_api.Text))
			{
				userApis.Remove(textBox_api.Text);
			}
			RenderGetPost();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			webBrowser1.Url = new Uri(textBox1.Text);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			HttpServer obj = httpServer;
			if (obj != null)
			{
				obj.Close();
			}
			panel2.Enabled = false;
			button1.Enabled = true;
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue("IsCrossDomain", checkBox_IsCrossDomain.Checked);
			element.SetAttributeValue("LoginAccessControl", checkBox2.Checked);
			if (userApis.Count > 0)
			{
				foreach (UserWebApis value in userApis.Values)
				{
					element.Add(value.ToXml());
				}
			}
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			checkBox_IsCrossDomain.Checked = SoftBasic.GetXmlValue(element, "IsCrossDomain", false);
			checkBox2.Checked = SoftBasic.GetXmlValue(element, "LoginAccessControl", false);
			foreach (XElement item in element.Elements("UserWebApis"))
			{
				UserWebApis userWebApis = new UserWebApis();
				userWebApis.LoadByXml(item);
				if (userApis.ContainsKey(userWebApis.Name))
				{
					userApis[userWebApis.Name] = userWebApis;
				}
				else
				{
					userApis.Add(userWebApis.Name, userWebApis);
				}
			}
			RenderGetPost();
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
			checkBox2 = new System.Windows.Forms.CheckBox();
			checkBox_IsCrossDomain = new System.Windows.Forms.CheckBox();
			button4 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			comboBox1 = new System.Windows.Forms.ComboBox();
			panel2 = new System.Windows.Forms.Panel();
			button_delete = new System.Windows.Forms.Button();
			webBrowser1 = new System.Windows.Forms.WebBrowser();
			button2 = new System.Windows.Forms.Button();
			textBox1 = new System.Windows.Forms.TextBox();
			button_post = new System.Windows.Forms.Button();
			label12 = new System.Windows.Forms.Label();
			button_get = new System.Windows.Forms.Button();
			textBox_body = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			textBox_api = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel3 = new System.Windows.Forms.Panel();
			label2 = new System.Windows.Forms.Label();
			listBox1 = new System.Windows.Forms.ListBox();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(checkBox2);
			panel1.Controls.Add(checkBox_IsCrossDomain);
			panel1.Controls.Add(button4);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(998, 41);
			panel1.TabIndex = 7;
			checkBox2.AutoSize = true;
			checkBox2.Location = new System.Drawing.Point(279, 7);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new System.Drawing.Size(263, 21);
			checkBox2.TabIndex = 20;
			checkBox2.Text = "启动账户控制？Name:admin  pwd:123456";
			checkBox2.UseVisualStyleBackColor = true;
			checkBox_IsCrossDomain.AutoSize = true;
			checkBox_IsCrossDomain.Location = new System.Drawing.Point(150, 7);
			checkBox_IsCrossDomain.Name = "checkBox_IsCrossDomain";
			checkBox_IsCrossDomain.Size = new System.Drawing.Size(123, 21);
			checkBox_IsCrossDomain.TabIndex = 17;
			checkBox_IsCrossDomain.Text = "是否支持跨域请求";
			checkBox_IsCrossDomain.UseVisualStyleBackColor = true;
			button4.Location = new System.Drawing.Point(661, 2);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(91, 28);
			button4.TabIndex = 16;
			button4.Text = "关闭服务";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button1.Location = new System.Drawing.Point(564, 2);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "启动服务";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(62, 5);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(79, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "12345";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(8, 8);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 184);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(84, 17);
			label1.TabIndex = 19;
			label1.Text = "ContentType:";
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(94, 181);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(134, 25);
			comboBox1.TabIndex = 18;
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(button_delete);
			panel2.Controls.Add(webBrowser1);
			panel2.Controls.Add(label1);
			panel2.Controls.Add(comboBox1);
			panel2.Controls.Add(button2);
			panel2.Controls.Add(textBox1);
			panel2.Controls.Add(button_post);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(button_get);
			panel2.Controls.Add(textBox_body);
			panel2.Controls.Add(label9);
			panel2.Controls.Add(label8);
			panel2.Controls.Add(textBox_api);
			panel2.Controls.Add(label7);
			panel2.Location = new System.Drawing.Point(188, 83);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(813, 538);
			panel2.TabIndex = 13;
			button_delete.Location = new System.Drawing.Point(533, 180);
			button_delete.Name = "button_delete";
			button_delete.Size = new System.Drawing.Size(148, 28);
			button_delete.TabIndex = 24;
			button_delete.Text = "Delete Api";
			button_delete.UseVisualStyleBackColor = true;
			button_delete.Click += new System.EventHandler(button_delete_Click);
			webBrowser1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			webBrowser1.Location = new System.Drawing.Point(62, 243);
			webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			webBrowser1.Name = "webBrowser1";
			webBrowser1.Size = new System.Drawing.Size(742, 287);
			webBrowser1.TabIndex = 23;
			button2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button2.Location = new System.Drawing.Point(713, 211);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 22;
			button2.Text = "请求";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			textBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox1.Location = new System.Drawing.Point(62, 214);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(645, 23);
			textBox1.TabIndex = 21;
			textBox1.Text = "http://127.0.0.1:12345/GetA";
			button_post.Location = new System.Drawing.Point(379, 180);
			button_post.Name = "button_post";
			button_post.Size = new System.Drawing.Size(148, 28);
			button_post.TabIndex = 20;
			button_post.Text = "设置Post";
			button_post.UseVisualStyleBackColor = true;
			button_post.Click += new System.EventHandler(Button7_Click);
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(8, 217);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(56, 17);
			label12.TabIndex = 19;
			label12.Text = "网页浏览";
			button_get.Location = new System.Drawing.Point(234, 180);
			button_get.Name = "button_get";
			button_get.Size = new System.Drawing.Size(139, 28);
			button_get.TabIndex = 12;
			button_get.Text = "设置Get";
			button_get.UseVisualStyleBackColor = true;
			button_get.Click += new System.EventHandler(button3_Click);
			textBox_body.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_body.Location = new System.Drawing.Point(62, 36);
			textBox_body.Multiline = true;
			textBox_body.Name = "textBox_body";
			textBox_body.Size = new System.Drawing.Size(742, 138);
			textBox_body.TabIndex = 8;
			textBox_body.Text = "<html><head><title>HslWebServer</title></head><body><p style=\"color:red\">这是一个测试的消息内容</p></body></html>";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(8, 39);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(44, 17);
			label9.TabIndex = 11;
			label9.Text = "数据：";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(249, 11);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(188, 17);
			label8.TabIndex = 10;
			label8.Text = "在请求的时候就会得到下面的信息";
			textBox_api.Location = new System.Drawing.Point(62, 7);
			textBox_api.Name = "textBox_api";
			textBox_api.Size = new System.Drawing.Size(181, 23);
			textBox_api.TabIndex = 9;
			textBox_api.Text = "/GetA";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(8, 11);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(32, 17);
			label7.TabIndex = 7;
			label7.Text = "网址";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.hslcommunication.cn/";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "html / WebApi";
			userControlHead1.Size = new System.Drawing.Size(1005, 32);
			userControlHead1.TabIndex = 14;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			panel3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel3.Controls.Add(label2);
			panel3.Controls.Add(listBox1);
			panel3.Location = new System.Drawing.Point(3, 83);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(179, 538);
			panel3.TabIndex = 15;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 1);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(104, 17);
			label2.TabIndex = 8;
			label2.Text = "已设置接口列表：";
			listBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 17;
			listBox1.Location = new System.Drawing.Point(3, 20);
			listBox1.Name = "listBox1";
			listBox1.Size = new System.Drawing.Size(171, 514);
			listBox1.TabIndex = 0;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1005, 624);
			base.Controls.Add(panel3);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormHttpServer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Web轻量级的服务器";
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
