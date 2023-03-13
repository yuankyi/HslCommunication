using HslCommunication;
using HslCommunication.CNC.Fanuc;
using HslCommunication.Core;
using HslCommunication.LogNet;
using HslCommunication.MQTT;
using HslCommunication.Profinet.AllenBradley;
using HslCommunication.Profinet.Siemens;
using HslCommunication.Reflection;
using HslCommunicationDemo.DemoControl;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormMqttServer : HslFormContent
	{
		public class Student
		{
			public string Name
			{
				get;
				set;
			}

			public int Age
			{
				get;
				set;
			}

			public string ID
			{
				get;
				set;
			}
		}

		[CompilerGenerated]
		private sealed class _003CReadDatabaseAsync_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<short> _003C_003Et__builder;

			public string abc;

			public FormMqttServer _003C_003E4__this;

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
							_003CReadDatabaseAsync_003Ed__21 stateMachine = this;
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
							_003CReadDatabaseAsync_003Ed__21 stateMachine = this;
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

		private System.Windows.Forms.Timer timer1s;

		private MqttServer mqttServer;

		private SiemensS7Net siemens;

		private System.Threading.Timer timerPublish;

		private int publishTick = 0;

		private long receiveCount = 0L;

		private Random random = new Random();

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

		private TextBox textBox1;

		private Label label1;

		private Button button5;

		private Button button6;

		private CheckBox checkBox1;

		private Label label2;

		private Button button7;

		private Label label4;

		private CheckBox checkBox3;

		private ListBox listBox1;

		private Label label5;

		private CheckBox checkBox2;

		private CheckBox checkBox_long_message_hide;

		private CheckBox checkBox_publish_isHex;

		private CheckBox checkBox_receive_isHex;

		public FormMqttServer()
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
			if (mqttServer != null)
			{
				label2.Text = "Online Count:" + mqttServer.OnlineCount.ToString();
				label4.Text = "Receive Count:" + receiveCount.ToString();
				listBox1.DataSource = mqttServer.OnlineSessions;
			}
		}

		private void Language(int language)
		{
			if (language != 1)
			{
				Text = "Mqtt Server Test";
				label3.Text = "Port:";
				button1.Text = "Start";
				button2.Text = "Close";
				button5.Text = "Publish Id";
				label7.Text = "Topic:";
				label8.Text = "";
				label9.Text = "Payload:";
				button3.Text = "Publish All";
				button4.Text = "Clear";
				button6.Text = "Publish";
				label12.Text = "Receive:";
				checkBox3.Text = "Send test message back when client connect";
				checkBox2.Text = "Willcards";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				siemens = new SiemensS7Net(SiemensPLCS.S1200, "127.0.0.1");
				siemens.SetPersistentConnection();
				mqttServer = new MqttServer();
				mqttServer.OnClientApplicationMessageReceive += MqttServer_OnClientApplicationMessageReceive;
				mqttServer.OnClientConnected += MqttServer_OnClientConnected;
				mqttServer.TopicWildcard = checkBox2.Checked;
				if (checkBox1.Checked)
				{
					mqttServer.ClientVerification += MqttServer_ClientVerification;
				}
				mqttServer.RegisterMqttRpcApi("Account", this);
				mqttServer.RegisterMqttRpcApi("Siemens", siemens);
				mqttServer.RegisterMqttRpcApi("TimeOut", typeof(HslTimeOut));
				mqttServer.RegisterMqttRpcApi("Fanuc", new FanucSeries0i("127.0.0.1"));
				mqttServer.RegisterMqttRpcApi("PCCC", new AllenBradleyPcccNet("127.0.0.1"));
				mqttServer.ServerStart(int.Parse(textBox2.Text));
				mqttServer.LogNet = new LogNetSingle("");
				mqttServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
				mqttServer.RegisterMqttRpcApi("Log", mqttServer.LogNet);
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

		private void button8_Click(object sender, EventArgs e)
		{
			timerPublish = new System.Threading.Timer(TimerPublish, null, 0, 1000);
		}

		private void TimerPublish(object obj)
		{
			mqttServer.PublishTopicPayload("A", Encoding.UTF8.GetBytes("A" + publishTick.ToString()));
			mqttServer.PublishTopicPayload("B", Encoding.UTF8.GetBytes("B" + publishTick.ToString()));
			mqttServer.PublishTopicPayload("C", Encoding.UTF8.GetBytes("C" + publishTick.ToString()));
			mqttServer.PublishTopicPayload("D", Encoding.UTF8.GetBytes("D" + publishTick.ToString()));
			publishTick++;
		}

		private void MqttServer_OnClientConnected(MqttSession session)
		{
			if (checkBox3.Checked)
			{
				mqttServer.PublishTopicPayload(session, "HslMqtt", Encoding.UTF8.GetBytes("This is a test message"));
			}
		}

		private int MqttServer_ClientVerification(MqttSession mqttSession, string clientId, string userName, string passwrod)
		{
			if (userName == "hsl")
			{
				mqttSession.DeveloperPermissions = false;
			}
			if (userName == "admin" && passwrod == "123456")
			{
				return 0;
			}
			if (userName == "hsl" && passwrod == "123456")
			{
				return 0;
			}
			return 5;
		}

		private void MqttServer_OnClientApplicationMessageReceive(MqttSession session, MqttClientApplicationMessage message)
		{
			if (message.Topic == "ndiwh是本地AIHDniwd")
			{
				mqttServer.PublishTopicPayload(session, message.Topic, message.Payload);
			}
			if (session.Protocol == "HUSL")
			{
				if (message.Topic == "A")
				{
					mqttServer.PublishTopicPayload(session, "B", Encoding.UTF8.GetBytes("这是回传的一条测试数据"));
				}
				else if (message.Topic == "B")
				{
					Thread.Sleep(1000);
					for (int i = 0; i < 10; i++)
					{
						Thread.Sleep(1000);
						mqttServer.ReportProgress(session, ((i + 1) * 10).ToString(), string.Format("当前正在处理{0}步", i + 1));
					}
					Thread.Sleep(1000);
					mqttServer.PublishTopicPayload(session, StringResources.Language.SuccessText, Encoding.UTF8.GetBytes("B操作处理成功"));
				}
				else if (message.Topic == "C")
				{
					byte[] array = new byte[1048576];
					for (int j = 0; j < array.Length; j++)
					{
						array[j] = 48;
					}
					mqttServer.PublishTopicPayload(session, "C", array);
				}
				else if (message.Topic == "D")
				{
					mqttServer.ReportOperateResult(session, "当前的功能码不支持！");
				}
				else if (message.Topic == "E")
				{
					if (random.Next(100) < 50)
					{
						mqttServer.ReportOperateResult(session, new OperateResult<string>("当前的结果为失败信息"));
					}
					else
					{
						mqttServer.ReportOperateResult(session, OperateResult.CreateSuccessResult("成功"));
					}
				}
				else if (message.Topic == "F")
				{
					mqttServer.PublishTopicPayload(session, "list", Encoding.UTF8.GetBytes(JArray.FromObject(MqttHelper.GetSyncServicesApiInformationFromObject(this)).ToString()));
				}
			}
			Invoke((Action)delegate
			{
				if (!isStop)
				{
					receiveCount++;
					byte[] payload = message.Payload;
					if (payload != null && payload.Length > 100 && checkBox_long_message_hide.Checked)
					{
						if (checkBox_receive_isHex.Checked)
						{
							textBox8.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Cliend Id[" + message.ClientId + "] Topic:[" + message.Topic + "] Payload:[" + message.Payload.SelectBegin(100).ToHexString(' ') + "...]" + Environment.NewLine);
						}
						else
						{
							textBox8.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Cliend Id[" + message.ClientId + "] Topic:[" + message.Topic + "] Payload:[" + Encoding.UTF8.GetString(message.Payload.SelectBegin(100)) + "...]" + Environment.NewLine);
						}
					}
					else if (checkBox_receive_isHex.Checked)
					{
						textBox8.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Cliend Id[" + message.ClientId + "] Topic:[" + message.Topic + "] Payload:[" + message.Payload.ToHexString(' ') + "]" + Environment.NewLine);
					}
					else
					{
						textBox8.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Cliend Id[" + message.ClientId + "] Topic:[" + message.Topic + "] Payload:[" + Encoding.UTF8.GetString(message.Payload) + "]" + Environment.NewLine);
					}
				}
			});
		}

		[HslMqttApi("检查账户的信息")]
		[HslMqttPermission(ClientID = "AAA")]
		public OperateResult<string> CheckName(string name, short value)
		{
			if (value < 10)
			{
				return new OperateResult<string>("值不能小于10");
			}
			return OperateResult.CreateSuccessResult("成功:" + name + " 年龄:" + value.ToString());
		}

		[HslMqttApi("读取设备的信息，\r\naddress: 设备的地址 \r\nlength: 读取的数据长度")]
		public OperateResult<string> ReadInt(string address, short length)
		{
			return OperateResult.CreateSuccessResult("成功:" + address);
		}

		[HslMqttApi("读取设备的信息，address: 设备的地址 length: 读取的数据长度")]
		public OperateResult<int, string> ReadABC(string address)
		{
			return OperateResult.CreateSuccessResult(random.Next(1000), "成功:" + address);
		}

		[HslMqttApi("读取设备的Int16信息，address: 设备的地址 length: 读取的数据长度")]
		public OperateResult<short> ReadInt16(string address = "100", short length = 10)
		{
			return OperateResult.CreateSuccessResult((short)random.Next(10000));
		}

		[HslMqttApi("读取设备的Int16数组信息，address: 设备的地址 length: 读取的数据长度")]
		public OperateResult<short[]> ReadInt16Array(string address, short length)
		{
			short[] array = new short[10];
			for (int i = 0; i < 10; i++)
			{
				array[i] = (short)random.Next(10000);
			}
			return OperateResult.CreateSuccessResult(array);
		}

		[AsyncStateMachine(typeof(_003CReadDatabaseAsync_003Ed__21))]
		[DebuggerStepThrough]
		[HslMqttApi("异步的读取方法，需要传入字符串的值")]
		public Task<short> ReadDatabaseAsync(string abc = "123")
		{
			_003CReadDatabaseAsync_003Ed__21 stateMachine = new _003CReadDatabaseAsync_003Ed__21();
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

		[HslMqttApi("读取设备的Int16信息，address: 设备的地址 length: 读取的数据长度")]
		public short ReadFloat(ISessionContext context, string address, short length = 12345)
		{
			if (context.UserName != "hsl")
			{
				return -100;
			}
			return (short)random.Next(10000);
		}

		[HslMqttApi("读取设备的学生信息\r\naddress: 设备的地址 length: 读取的数据长度")]
		public Student ReadStudent(string address = "M100", short length = 10)
		{
			return new Student
			{
				Name = "张三",
				Age = 23,
				ID = "1012312321"
			};
		}

		[HslMqttApi("读取设备的学生信息\r\naddress: 设备的地址 length: 读取的数据长度")]
		public OperateResult<Student> ReadStudentResult(string address, short length)
		{
			if (random.Next(1000) < 500)
			{
				return OperateResult.CreateSuccessResult(new Student
				{
					Name = "张三",
					Age = 23,
					ID = "1012312321"
				});
			}
			return new OperateResult<Student>("读取失败");
		}

		[HslMqttApi(Description = "写入设备的多个学生信息\r\naddress: 设备的地址 length: 读取的数据长度")]
		public OperateResult<string> WriteMultiStudentResult(string address, short length, Student[] student)
		{
			if (random.Next(1000) < 500)
			{
				if (student == null)
				{
					return new OperateResult<string>("student is null");
				}
				for (int i = 0; i < student.Length; i++)
				{
				}
				return OperateResult.CreateSuccessResult(string.Format("学生信息写入成功，数组数量：{0} ID列表:{1}", student.Length, (from m in student
				select m.ID).ToArray().ToArrayString()));
			}
			return new OperateResult<string>("写入失败");
		}

		[HslMqttApi(Description = "写入设备的学生信息\r\naddress: 设备的地址 length: 读取的数据长度")]
		public OperateResult<string> WriteStudentResult(string address, short length, Student student)
		{
			if (random.Next(1000) < 500)
			{
				if (student == null)
				{
					return new OperateResult<string>("student is null");
				}
				return OperateResult.CreateSuccessResult("学生信息写入成功：ID:" + student.ID + " Name:" + student.Name);
			}
			return new OperateResult<string>("写入失败");
		}

		[HslMqttApi("启动设备的接口信息")]
		public OperateResult<string> StartDevice(DateTime start)
		{
			return OperateResult.CreateSuccessResult(start.ToString());
		}

		[HslMqttApi("StopDevice", "关闭设备的接口信息")]
		public OperateResult<int> asdgasasdasd()
		{
			return OperateResult.CreateSuccessResult(random.Next(10000));
		}

		[HslMqttApi(HttpMethod = "POST")]
		public string GetJObjectTest(JObject json)
		{
			return json.ToString();
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
			mqttServer.ServerClose();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			mqttServer.PublishAllClientTopicPayload(textBox5.Text, checkBox_publish_isHex.Checked ? textBox4.Text.ToHexBytes() : Encoding.UTF8.GetBytes(textBox4.Text));
		}

		private void button4_Click(object sender, EventArgs e)
		{
			textBox8.Clear();
			receiveCount = 0L;
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			mqttServer.PublishTopicPayload(textBox1.Text, textBox5.Text, checkBox_publish_isHex.Checked ? textBox4.Text.ToHexBytes() : Encoding.UTF8.GetBytes(textBox4.Text));
		}

		private void button6_Click_1(object sender, EventArgs e)
		{
			mqttServer.PublishTopicPayload(textBox5.Text, checkBox_publish_isHex.Checked ? textBox4.Text.ToHexBytes() : Encoding.UTF8.GetBytes(textBox4.Text));
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

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlRetureMessage, checkBox3.Checked);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			checkBox3.Checked = bool.Parse(element.Attribute(DemoDeviceList.XmlRetureMessage).Value);
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
			checkBox3 = new System.Windows.Forms.CheckBox();
			checkBox1 = new System.Windows.Forms.CheckBox();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			checkBox_long_message_hide = new System.Windows.Forms.CheckBox();
			listBox1 = new System.Windows.Forms.ListBox();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			button7 = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			button6 = new System.Windows.Forms.Button();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
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
			checkBox_publish_isHex = new System.Windows.Forms.CheckBox();
			checkBox_receive_isHex = new System.Windows.Forms.CheckBox();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(checkBox2);
			panel1.Controls.Add(checkBox3);
			panel1.Controls.Add(checkBox1);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(5, 37);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(993, 60);
			panel1.TabIndex = 7;
			checkBox2.AutoSize = true;
			checkBox2.Location = new System.Drawing.Point(208, 9);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new System.Drawing.Size(87, 21);
			checkBox2.TabIndex = 10;
			checkBox2.Text = "主题通配符";
			checkBox2.UseVisualStyleBackColor = true;
			checkBox3.AutoSize = true;
			checkBox3.Location = new System.Drawing.Point(11, 34);
			checkBox3.Name = "checkBox3";
			checkBox3.Size = new System.Drawing.Size(147, 21);
			checkBox3.TabIndex = 9;
			checkBox3.Text = "是否回发一条测试数据";
			checkBox3.UseVisualStyleBackColor = true;
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(523, 7);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(288, 21);
			checkBox1.TabIndex = 6;
			checkBox1.Text = "启用用户名和密码(用户名 admin  密码: 123456)";
			checkBox1.UseVisualStyleBackColor = true;
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(416, 4);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭服务";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(319, 4);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "启动服务";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(62, 7);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(131, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "1883";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(8, 10);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(checkBox_receive_isHex);
			panel2.Controls.Add(checkBox_publish_isHex);
			panel2.Controls.Add(checkBox_long_message_hide);
			panel2.Controls.Add(listBox1);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(label4);
			panel2.Controls.Add(button7);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(button6);
			panel2.Controls.Add(textBox1);
			panel2.Controls.Add(label1);
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
			panel2.Location = new System.Drawing.Point(5, 101);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(993, 540);
			panel2.TabIndex = 13;
			checkBox_long_message_hide.AutoSize = true;
			checkBox_long_message_hide.Checked = true;
			checkBox_long_message_hide.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox_long_message_hide.Location = new System.Drawing.Point(435, 185);
			checkBox_long_message_hide.Name = "checkBox_long_message_hide";
			checkBox_long_message_hide.Size = new System.Drawing.Size(99, 21);
			checkBox_long_message_hide.TabIndex = 33;
			checkBox_long_message_hide.Text = "超长消息简略";
			checkBox_long_message_hide.UseVisualStyleBackColor = true;
			listBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			listBox1.BackColor = System.Drawing.Color.LightGray;
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 17;
			listBox1.Location = new System.Drawing.Point(573, 36);
			listBox1.Name = "listBox1";
			listBox1.Size = new System.Drawing.Size(413, 140);
			listBox1.TabIndex = 31;
			label5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(573, 10);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(93, 17);
			label5.TabIndex = 30;
			label5.Text = "Online Client：";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(617, 186);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(93, 17);
			label4.TabIndex = 29;
			label4.Text = "Receive Count:";
			button7.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button7.Location = new System.Drawing.Point(799, 180);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(91, 28);
			button7.TabIndex = 28;
			button7.Text = "暂停";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			label2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(876, 11);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(86, 17);
			label2.TabIndex = 27;
			label2.Text = "Online Count:";
			button6.Location = new System.Drawing.Point(159, 180);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(91, 28);
			button6.TabIndex = 26;
			button6.Text = "广播订阅";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click_1);
			textBox1.Location = new System.Drawing.Point(342, 7);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(209, 23);
			textBox1.TabIndex = 25;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(281, 11);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(68, 17);
			label1.TabIndex = 24;
			label1.Text = "Client Id：";
			button5.Location = new System.Drawing.Point(256, 180);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(141, 28);
			button5.TabIndex = 20;
			button5.Text = "广播指定id";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(Button5_Click);
			textBox8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox8.Location = new System.Drawing.Point(62, 214);
			textBox8.Multiline = true;
			textBox8.Name = "textBox8";
			textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox8.Size = new System.Drawing.Size(924, 318);
			textBox8.TabIndex = 18;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(3, 217);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(64, 17);
			label12.TabIndex = 19;
			label12.Text = "Receive：";
			button4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button4.Location = new System.Drawing.Point(896, 180);
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
			button3.Text = "广播所有";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox4.Location = new System.Drawing.Point(62, 36);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox4.Size = new System.Drawing.Size(505, 138);
			textBox4.TabIndex = 8;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(3, 39);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(66, 17);
			label9.TabIndex = 11;
			label9.Text = "Payload：";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(219, 11);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(56, 17);
			label8.TabIndex = 10;
			label8.Text = "主题信息";
			textBox5.Location = new System.Drawing.Point(62, 7);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(151, 23);
			textBox5.TabIndex = 9;
			textBox5.Text = "A";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(2, 11);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(52, 17);
			label7.TabIndex = 7;
			label7.Text = "Topic：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/12312952.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "MQTT";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 14;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			checkBox_publish_isHex.AutoSize = true;
			checkBox_publish_isHex.Location = new System.Drawing.Point(5, 62);
			checkBox_publish_isHex.Name = "checkBox_publish_isHex";
			checkBox_publish_isHex.Size = new System.Drawing.Size(55, 21);
			checkBox_publish_isHex.TabIndex = 36;
			checkBox_publish_isHex.Text = "Hex?";
			checkBox_publish_isHex.UseVisualStyleBackColor = true;
			checkBox_receive_isHex.AutoSize = true;
			checkBox_receive_isHex.Location = new System.Drawing.Point(5, 237);
			checkBox_receive_isHex.Name = "checkBox_receive_isHex";
			checkBox_receive_isHex.Size = new System.Drawing.Size(55, 21);
			checkBox_receive_isHex.TabIndex = 37;
			checkBox_receive_isHex.Text = "Hex?";
			checkBox_receive_isHex.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormMqttServer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "MQTT 服务器";
			base.Load += new System.EventHandler(FormClient_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
