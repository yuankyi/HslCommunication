using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.LogNet;
using HslCommunication.MQTT;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.MQTT;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormMqttClient : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003CThreadPoolSendTest_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object obj;

			public FormMqttClient _003C_003E4__this;

			private MqttApplicationMessage _003Cmessage_003E5__1;

			private int _003Ci_003E5__2;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
						num = (_003C_003E1__state = -1);
						goto IL_00a6;
					}
					_003Cmessage_003E5__1 = (obj as MqttApplicationMessage);
					if (_003Cmessage_003E5__1 != null)
					{
						_003Ci_003E5__2 = 0;
						goto IL_00c1;
					}
					goto end_IL_0007;
					IL_00a6:
					awaiter.GetResult();
					_003Ci_003E5__2++;
					goto IL_00c1;
					IL_00c1:
					if (_003Ci_003E5__2 < 100)
					{
						awaiter = _003C_003E4__this.mqttClient.PublishMessageAsync(_003Cmessage_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CThreadPoolSendTest_003Ed__16 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_00a6;
					}
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cmessage_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cmessage_003E5__1 = null;
				_003C_003Et__builder.SetResult();
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

		[CompilerGenerated]
		private sealed class _003Cbutton1_Click_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttClient _003C_003E4__this;

			private MqttConnectionOptions _003Coptions_003E5__1;

			private OperateResult _003Cconnect_003E5__2;

			private OperateResult _003C_003Es__3;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					if (num != 0)
					{
						_003Coptions_003E5__1 = new MqttConnectionOptions
						{
							IpAddress = _003C_003E4__this.textBox1.Text,
							Port = int.Parse(_003C_003E4__this.textBox2.Text),
							ClientId = _003C_003E4__this.textBox3.Text,
							KeepAlivePeriod = TimeSpan.FromSeconds((double)int.Parse(_003C_003E4__this.textBox6.Text)),
							UseRSAProvider = _003C_003E4__this.checkBox_rsa.Checked
						};
						if (!string.IsNullOrEmpty(_003C_003E4__this.textBox9.Text) || !string.IsNullOrEmpty(_003C_003E4__this.textBox10.Text))
						{
							_003Coptions_003E5__1.Credentials = new MqttCredential(_003C_003E4__this.textBox9.Text, _003C_003E4__this.textBox10.Text);
						}
						if (!string.IsNullOrEmpty(_003C_003E4__this.mqtt_will_topic))
						{
							_003Coptions_003E5__1.WillMessage = new MqttApplicationMessage
							{
								Topic = _003C_003E4__this.mqtt_will_topic,
								Payload = Encoding.UTF8.GetBytes(_003C_003E4__this.mqtt_will_message)
							};
						}
						if (!string.IsNullOrEmpty(_003C_003E4__this.textBox_certificate.Text))
						{
							_003Coptions_003E5__1.CertificateFile = _003C_003E4__this.textBox_certificate.Text;
						}
						_003Coptions_003E5__1.SSLSecure = _003C_003E4__this.checkBox_sslSecure.Checked;
						_003C_003E4__this.button1.Enabled = false;
						MqttClient mqttClient = _003C_003E4__this.mqttClient;
						if (mqttClient != null)
						{
							mqttClient.ConnectClose();
						}
						_003C_003E4__this.mqttClient = new MqttClient(_003Coptions_003E5__1);
						_003C_003E4__this.mqttClient.LogNet = new LogNetSingle(string.Empty);
						_003C_003E4__this.mqttClient.LogNet.BeforeSaveToFile += _003C_003E4__this.LogNet_BeforeSaveToFile;
						_003C_003E4__this.mqttClient.OnMqttMessageReceived += _003C_003E4__this.MqttClient_OnMqttMessageReceived;
						awaiter = _003C_003E4__this.mqttClient.ConnectServerAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton1_Click_003Ed__5 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003Cconnect_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cconnect_003E5__2.IsSuccess)
					{
						_003C_003E4__this.panel2.Enabled = true;
						_003C_003E4__this.button1.Enabled = false;
						_003C_003E4__this.button2.Enabled = true;
						_003C_003E4__this.panel2.Enabled = true;
						_003C_003E4__this.listBox1.DataSource = _003C_003E4__this.mqttClient.SubcribeTopics;
						MessageBox.Show(StringResources.Language.ConnectServerSuccess);
					}
					else
					{
						_003C_003E4__this.mqttClient = null;
						_003C_003E4__this.button1.Enabled = true;
						MessageBox.Show(_003Cconnect_003E5__2.ToMessageShowString());
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Coptions_003E5__1 = null;
					_003Cconnect_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Coptions_003E5__1 = null;
				_003Cconnect_003E5__2 = null;
				_003C_003Et__builder.SetResult();
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

		private MqttClient mqttClient;

		private long receiveCount = 0L;

		private string mqtt_will_topic;

		private string mqtt_will_message;

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

		private TextBox textBox4;

		private Label label9;

		private Label label8;

		private TextBox textBox5;

		private Label label7;

		private UserControlHead userControlHead1;

		private TextBox textBox10;

		private Label label4;

		private TextBox textBox9;

		private Label label2;

		private TextBox textBox11;

		private Label label5;

		private TextBox textBox3;

		private Label label6;

		private Button button7;

		private Button button8;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private RadioButton radioButton_json;

		private RadioButton radioButton_xml;

		private RadioButton radioButton_text;

		private Panel panel3;

		private Button button9;

		private Label label10;

		private Button button_publish;

		private TextBox textBox6;

		private Label label11;

		private CheckBox checkBox1;

		private CheckBox checkBox_rsa;

		private Button button_will_topic;

		private Panel panel4;

		private ListBox listBox1;

		private Label label13;

		private ComboBox comboBox1;

		private CheckBox checkBox_long_message_hide;

		private CheckBox checkBox_debug_info_show;

		private RadioButton radioButton_binary;

		private Button button3;

		private CheckBox checkBox_publish_isHex;

		private Button button_certificate;

		private TextBox textBox_certificate;

		private Label label14;

		private CheckBox checkBox_sslSecure;

		public FormMqttClient()
		{
			InitializeComponent();
		}

		private void FormClient_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			button2.Enabled = false;
			comboBox1.DataSource = SoftBasic.GetEnumValues<MqttQualityOfServiceLevel>();
			Language(Program.Language);
			listBox1.MouseDoubleClick += ListBox1_MouseDoubleClick;
		}

		private void ListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			string text = listBox1.SelectedItem as string;
			if (text != null)
			{
				textBox5.Text = text;
			}
		}

		private void Language(int language)
		{
			if (language != 1)
			{
				Text = "Mqtt Client Test";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label7.Text = "Topic:";
				label8.Text = "";
				label9.Text = "Payload:";
				button4.Text = "Clear";
				label12.Text = "Receive:";
				button9.Text = "Press Test";
				button7.Text = "subscribe";
				button8.Text = "unsubscribe";
				button_publish.Text = "Publish";
				button_will_topic.Text = "Will";
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton1_Click_003Ed__5))]
		[DebuggerStepThrough]
		private void button1_Click(object sender, EventArgs e)
		{
			_003Cbutton1_Click_003Ed__5 stateMachine = new _003Cbutton1_Click_003Ed__5();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void MqttClient_OnNetworkError(object sender, EventArgs e)
		{
			MqttClient mqttClient = sender as MqttClient;
			if (mqttClient != null)
			{
				ILogNet logNet = mqttClient.LogNet;
				if (logNet != null)
				{
					logNet.WriteInfo("网络异常，准备10秒后重新连接。");
				}
				while (true)
				{
					Thread.Sleep(10000);
					ILogNet logNet2 = mqttClient.LogNet;
					if (logNet2 != null)
					{
						logNet2.WriteInfo("准备重新连接服务器...");
					}
					OperateResult operateResult = mqttClient.ConnectServer();
					if (operateResult.IsSuccess)
					{
						break;
					}
					ILogNet logNet3 = mqttClient.LogNet;
					if (logNet3 != null)
					{
						logNet3.WriteInfo("连接失败，准备10秒后重新连接。");
					}
				}
				ILogNet logNet4 = mqttClient.LogNet;
				if (logNet4 != null)
				{
					logNet4.WriteInfo("连接服务器成功！");
				}
			}
		}

		private void MqttClient_OnMqttMessageReceived(MqttClient client, string topic, byte[] payload)
		{
			try
			{
				Invoke((Action)delegate
				{
					receiveCount++;
					label10.Text = "Receive Count: " + receiveCount.ToString();
					string text = string.Empty;
					if (radioButton_binary.Checked)
					{
						text = payload.ToHexString(' ');
					}
					else if (radioButton_text.Checked)
					{
						text = Encoding.UTF8.GetString(payload);
					}
					else if (radioButton_xml.Checked)
					{
						try
						{
							text = XElement.Parse(Encoding.UTF8.GetString(payload)).ToString();
						}
						catch
						{
							text = Encoding.UTF8.GetString(payload);
						}
					}
					else if (radioButton_json.Checked)
					{
						try
						{
							text = JObject.Parse(Encoding.UTF8.GetString(payload)).ToString();
						}
						catch
						{
							text = Encoding.UTF8.GetString(payload);
						}
					}
					if (checkBox_long_message_hide.Checked && text != null && text.Length > 200)
					{
						text = text.Substring(200);
					}
					if (radioButton2.Checked)
					{
						textBox8.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Topic[" + topic + "]: " + text + Environment.NewLine);
					}
					else if (radioButton1.Checked)
					{
						textBox8.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Topic[" + topic + "]: " + text;
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
				if (checkBox_debug_info_show.Checked && radioButton2.Checked)
				{
					Invoke((Action)delegate
					{
						textBox8.AppendText(e.HslMessage.ToString() + Environment.NewLine);
					});
				}
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
			mqttClient.ConnectClose();
		}

		private void button10_Click(object sender, EventArgs e)
		{
			object selectedItem = comboBox1.SelectedItem;
			MqttQualityOfServiceLevel qualityOfServiceLevel = default(MqttQualityOfServiceLevel);
			int num;
			if (selectedItem is MqttQualityOfServiceLevel)
			{
				qualityOfServiceLevel = (MqttQualityOfServiceLevel)selectedItem;
				num = 1;
			}
			else
			{
				num = 0;
			}
			if (num != 0)
			{
				OperateResult operateResult = mqttClient.PublishMessage(new MqttApplicationMessage
				{
					QualityOfServiceLevel = qualityOfServiceLevel,
					Topic = textBox5.Text,
					Payload = (checkBox_publish_isHex.Checked ? textBox4.Text.ToHexBytes() : Encoding.UTF8.GetBytes(textBox4.Text)),
					Retain = checkBox1.Checked
				});
				if (!operateResult.IsSuccess)
				{
					MessageBox.Show("Send Failed:" + operateResult.Message);
				}
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			textBox8.Clear();
		}

		private void Button7_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = mqttClient.SubscribeMessage(new string[1]
			{
				textBox5.Text
			});
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("SubscribeMessage Failed:" + operateResult.Message);
			}
			else
			{
				listBox1.DataSource = mqttClient.SubcribeTopics;
			}
		}

		private void Button8_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = mqttClient.UnSubscribeMessage(textBox5.Text);
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("UnSubscribeMessage Failed:" + operateResult.Message);
			}
			else
			{
				listBox1.DataSource = mqttClient.SubcribeTopics;
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 20; i++)
			{
				ThreadPool.QueueUserWorkItem(ThreadPoolSendTest, new MqttApplicationMessage
				{
					QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,
					Topic = "ndiwh是本地AIHDniwd",
					Payload = Encoding.UTF8.GetBytes(textBox4.Text + (i + 1).ToString())
				});
			}
		}

		[AsyncStateMachine(typeof(_003CThreadPoolSendTest_003Ed__16))]
		[DebuggerStepThrough]
		private void ThreadPoolSendTest(object obj)
		{
			_003CThreadPoolSendTest_003Ed__16 stateMachine = new _003CThreadPoolSendTest_003Ed__16();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.obj = obj;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlTimeout, textBox11.Text);
			element.SetAttributeValue(DemoDeviceList.XmlKeepLive, textBox6.Text);
			element.SetAttributeValue(DemoDeviceList.XmlCompanyID, textBox3.Text);
			element.SetAttributeValue(DemoDeviceList.XmlUserName, textBox9.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPassword, textBox10.Text);
			element.SetAttributeValue("WillTopic", mqtt_will_topic);
			element.SetAttributeValue("WillMessage", mqtt_will_message);
			element.SetAttributeValue("certificate", textBox_certificate.Text);
			element.SetAttributeValue("sslSecure", checkBox_sslSecure.Checked);
			element.SetAttributeValue("rsa", checkBox_rsa.Checked);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox11.Text = element.Attribute(DemoDeviceList.XmlTimeout).Value;
			textBox6.Text = element.Attribute(DemoDeviceList.XmlKeepLive).Value;
			textBox3.Text = element.Attribute(DemoDeviceList.XmlCompanyID).Value;
			textBox9.Text = element.Attribute(DemoDeviceList.XmlUserName).Value;
			textBox10.Text = element.Attribute(DemoDeviceList.XmlPassword).Value;
			mqtt_will_topic = ((element.Attribute("WillTopic") == null) ? string.Empty : element.Attribute("WillTopic").Value);
			mqtt_will_message = ((element.Attribute("WillMessage") == null) ? string.Empty : element.Attribute("WillMessage").Value);
			textBox_certificate.Text = ((element.Attribute("certificate") == null) ? string.Empty : element.Attribute("certificate").Value);
			checkBox_sslSecure.Checked = (element.Attribute("sslSecure") != null && bool.Parse(element.Attribute("sslSecure").Value));
			checkBox_rsa.Checked = (element.Attribute("rsa") != null && bool.Parse(element.Attribute("rsa").Value));
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
		}

		private void button_will_topic_Click(object sender, EventArgs e)
		{
			using (FormWillTopicSetting formWillTopicSetting = new FormWillTopicSetting(mqtt_will_topic, mqtt_will_message))
			{
				if (formWillTopicSetting.ShowDialog() == DialogResult.OK)
				{
					mqtt_will_topic = formWillTopicSetting.Topic;
					mqtt_will_message = formWillTopicSetting.Message;
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			FormMqttSubscribe formMqttSubscribe = new FormMqttSubscribe(mqttClient);
			formMqttSubscribe.Show();
		}

		private void button_certificate_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					textBox_certificate.Text = openFileDialog.FileName;
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
			checkBox_sslSecure = new System.Windows.Forms.CheckBox();
			button_certificate = new System.Windows.Forms.Button();
			textBox_certificate = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			button_will_topic = new System.Windows.Forms.Button();
			checkBox_rsa = new System.Windows.Forms.CheckBox();
			textBox6 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
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
			panel2 = new System.Windows.Forms.Panel();
			checkBox_publish_isHex = new System.Windows.Forms.CheckBox();
			button3 = new System.Windows.Forms.Button();
			checkBox_debug_info_show = new System.Windows.Forms.CheckBox();
			checkBox_long_message_hide = new System.Windows.Forms.CheckBox();
			comboBox1 = new System.Windows.Forms.ComboBox();
			button_publish = new System.Windows.Forms.Button();
			label10 = new System.Windows.Forms.Label();
			button9 = new System.Windows.Forms.Button();
			panel3 = new System.Windows.Forms.Panel();
			radioButton_binary = new System.Windows.Forms.RadioButton();
			radioButton_json = new System.Windows.Forms.RadioButton();
			radioButton_text = new System.Windows.Forms.RadioButton();
			radioButton_xml = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton1 = new System.Windows.Forms.RadioButton();
			button8 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			textBox8 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			button4 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			checkBox1 = new System.Windows.Forms.CheckBox();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel4 = new System.Windows.Forms.Panel();
			listBox1 = new System.Windows.Forms.ListBox();
			label13 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			panel4.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(checkBox_sslSecure);
			panel1.Controls.Add(button_certificate);
			panel1.Controls.Add(textBox_certificate);
			panel1.Controls.Add(label14);
			panel1.Controls.Add(button_will_topic);
			panel1.Controls.Add(checkBox_rsa);
			panel1.Controls.Add(textBox6);
			panel1.Controls.Add(label11);
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
			panel1.Location = new System.Drawing.Point(4, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(996, 87);
			panel1.TabIndex = 7;
			checkBox_sslSecure.AutoSize = true;
			checkBox_sslSecure.Location = new System.Drawing.Point(723, 63);
			checkBox_sslSecure.Name = "checkBox_sslSecure";
			checkBox_sslSecure.Size = new System.Drawing.Size(181, 21);
			checkBox_sslSecure.TabIndex = 36;
			checkBox_sslSecure.Text = "SSL Secure ?(server check)";
			checkBox_sslSecure.UseVisualStyleBackColor = true;
			button_certificate.Location = new System.Drawing.Point(655, 57);
			button_certificate.Name = "button_certificate";
			button_certificate.Size = new System.Drawing.Size(63, 28);
			button_certificate.TabIndex = 35;
			button_certificate.Text = "选择";
			button_certificate.UseVisualStyleBackColor = true;
			button_certificate.Click += new System.EventHandler(button_certificate_Click);
			textBox_certificate.Location = new System.Drawing.Point(87, 61);
			textBox_certificate.Name = "textBox_certificate";
			textBox_certificate.Size = new System.Drawing.Size(565, 23);
			textBox_certificate.TabIndex = 34;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(20, 63);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(68, 17);
			label14.TabIndex = 33;
			label14.Text = "使用证书：";
			button_will_topic.Location = new System.Drawing.Point(922, 33);
			button_will_topic.Name = "button_will_topic";
			button_will_topic.Size = new System.Drawing.Size(63, 28);
			button_will_topic.TabIndex = 32;
			button_will_topic.Text = "遗嘱";
			button_will_topic.UseVisualStyleBackColor = true;
			button_will_topic.Click += new System.EventHandler(button_will_topic_Click);
			checkBox_rsa.AutoSize = true;
			checkBox_rsa.Location = new System.Drawing.Point(591, 10);
			checkBox_rsa.Name = "checkBox_rsa";
			checkBox_rsa.Size = new System.Drawing.Size(192, 21);
			checkBox_rsa.TabIndex = 31;
			checkBox_rsa.Text = "RSA加密 (需要HSL服务器支持)";
			checkBox_rsa.UseVisualStyleBackColor = true;
			textBox6.Location = new System.Drawing.Point(529, 8);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(50, 23);
			textBox6.TabIndex = 19;
			textBox6.Text = "100";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(456, 11);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(72, 17);
			label11.TabIndex = 18;
			label11.Text = "KeepLive：";
			textBox3.Location = new System.Drawing.Point(87, 34);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(290, 23);
			textBox3.TabIndex = 17;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(8, 37);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(80, 17);
			label6.TabIndex = 16;
			label6.Text = "客户端标识：";
			textBox11.Location = new System.Drawing.Point(395, 8);
			textBox11.Name = "textBox11";
			textBox11.Size = new System.Drawing.Size(54, 23);
			textBox11.TabIndex = 15;
			textBox11.Text = "5000";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(329, 11);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(68, 17);
			label5.TabIndex = 14;
			label5.Text = "接收超时：";
			textBox10.Location = new System.Drawing.Point(720, 34);
			textBox10.Name = "textBox10";
			textBox10.Size = new System.Drawing.Size(196, 23);
			textBox10.TabIndex = 13;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(658, 37);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(44, 17);
			label4.TabIndex = 12;
			label4.Text = "密码：";
			textBox9.Location = new System.Drawing.Point(447, 34);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(205, 23);
			textBox9.TabIndex = 11;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(383, 37);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(56, 17);
			label2.TabIndex = 10;
			label2.Text = "用户名：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(895, 4);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(798, 4);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(263, 8);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(55, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "1883";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(209, 11);
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
			panel2.Controls.Add(checkBox_publish_isHex);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(checkBox_debug_info_show);
			panel2.Controls.Add(checkBox_long_message_hide);
			panel2.Controls.Add(comboBox1);
			panel2.Controls.Add(button_publish);
			panel2.Controls.Add(label10);
			panel2.Controls.Add(button9);
			panel2.Controls.Add(panel3);
			panel2.Controls.Add(radioButton2);
			panel2.Controls.Add(radioButton1);
			panel2.Controls.Add(button8);
			panel2.Controls.Add(button7);
			panel2.Controls.Add(textBox8);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(button4);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label9);
			panel2.Controls.Add(label8);
			panel2.Controls.Add(textBox5);
			panel2.Controls.Add(label7);
			panel2.Controls.Add(checkBox1);
			panel2.Location = new System.Drawing.Point(148, 123);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(852, 517);
			panel2.TabIndex = 13;
			checkBox_publish_isHex.AutoSize = true;
			checkBox_publish_isHex.Location = new System.Drawing.Point(7, 68);
			checkBox_publish_isHex.Name = "checkBox_publish_isHex";
			checkBox_publish_isHex.Size = new System.Drawing.Size(55, 21);
			checkBox_publish_isHex.TabIndex = 35;
			checkBox_publish_isHex.Text = "Hex?";
			checkBox_publish_isHex.UseVisualStyleBackColor = true;
			button3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button3.Location = new System.Drawing.Point(670, 5);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(98, 28);
			button3.TabIndex = 34;
			button3.Text = "子窗体订阅";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			checkBox_debug_info_show.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			checkBox_debug_info_show.AutoSize = true;
			checkBox_debug_info_show.Location = new System.Drawing.Point(496, 495);
			checkBox_debug_info_show.Name = "checkBox_debug_info_show";
			checkBox_debug_info_show.Size = new System.Drawing.Size(128, 21);
			checkBox_debug_info_show.TabIndex = 33;
			checkBox_debug_info_show.Text = "Debug Info Show";
			checkBox_debug_info_show.UseVisualStyleBackColor = true;
			checkBox_long_message_hide.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			checkBox_long_message_hide.AutoSize = true;
			checkBox_long_message_hide.Checked = true;
			checkBox_long_message_hide.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox_long_message_hide.Location = new System.Drawing.Point(654, 495);
			checkBox_long_message_hide.Name = "checkBox_long_message_hide";
			checkBox_long_message_hide.Size = new System.Drawing.Size(99, 21);
			checkBox_long_message_hide.TabIndex = 32;
			checkBox_long_message_hide.Text = "超长消息简略";
			checkBox_long_message_hide.UseVisualStyleBackColor = true;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(148, 180);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(161, 25);
			comboBox1.TabIndex = 31;
			button_publish.Location = new System.Drawing.Point(315, 179);
			button_publish.Name = "button_publish";
			button_publish.Size = new System.Drawing.Size(94, 28);
			button_publish.TabIndex = 29;
			button_publish.Text = "发布";
			button_publish.UseVisualStyleBackColor = true;
			button_publish.Click += new System.EventHandler(button10_Click);
			label10.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(59, 496);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(93, 17);
			label10.TabIndex = 28;
			label10.Text = "Receive Count:";
			button9.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button9.Location = new System.Drawing.Point(774, 5);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(71, 28);
			button9.TabIndex = 27;
			button9.Text = "压力测试";
			button9.UseVisualStyleBackColor = true;
			button9.Visible = false;
			button9.Click += new System.EventHandler(button9_Click);
			panel3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			panel3.Controls.Add(radioButton_binary);
			panel3.Controls.Add(radioButton_json);
			panel3.Controls.Add(radioButton_text);
			panel3.Controls.Add(radioButton_xml);
			panel3.Location = new System.Drawing.Point(528, 180);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(246, 28);
			panel3.TabIndex = 26;
			radioButton_binary.AutoSize = true;
			radioButton_binary.Location = new System.Drawing.Point(3, 3);
			radioButton_binary.Name = "radioButton_binary";
			radioButton_binary.Size = new System.Drawing.Size(62, 21);
			radioButton_binary.TabIndex = 29;
			radioButton_binary.Text = "Binary";
			radioButton_binary.UseVisualStyleBackColor = true;
			radioButton_json.AutoSize = true;
			radioButton_json.Location = new System.Drawing.Point(175, 3);
			radioButton_json.Name = "radioButton_json";
			radioButton_json.Size = new System.Drawing.Size(52, 21);
			radioButton_json.TabIndex = 28;
			radioButton_json.Text = "Json";
			radioButton_json.UseVisualStyleBackColor = true;
			radioButton_text.AutoSize = true;
			radioButton_text.Checked = true;
			radioButton_text.Location = new System.Drawing.Point(65, 3);
			radioButton_text.Name = "radioButton_text";
			radioButton_text.Size = new System.Drawing.Size(50, 21);
			radioButton_text.TabIndex = 26;
			radioButton_text.TabStop = true;
			radioButton_text.Text = "Text";
			radioButton_text.UseVisualStyleBackColor = true;
			radioButton_xml.AutoSize = true;
			radioButton_xml.Location = new System.Drawing.Point(121, 3);
			radioButton_xml.Name = "radioButton_xml";
			radioButton_xml.Size = new System.Drawing.Size(48, 21);
			radioButton_xml.TabIndex = 27;
			radioButton_xml.Text = "Xml";
			radioButton_xml.UseVisualStyleBackColor = true;
			radioButton2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			radioButton2.AutoSize = true;
			radioButton2.Checked = true;
			radioButton2.Location = new System.Drawing.Point(448, 174);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(74, 21);
			radioButton2.TabIndex = 25;
			radioButton2.TabStop = true;
			radioButton2.Text = "追加显示";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			radioButton1.AutoSize = true;
			radioButton1.Location = new System.Drawing.Point(448, 192);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(74, 21);
			radioButton1.TabIndex = 24;
			radioButton1.Text = "覆盖显示";
			radioButton1.UseVisualStyleBackColor = true;
			button8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button8.Location = new System.Drawing.Point(560, 5);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(104, 28);
			button8.TabIndex = 23;
			button8.Text = "取消订阅";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(Button8_Click);
			button7.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button7.Location = new System.Drawing.Point(456, 5);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(98, 28);
			button7.TabIndex = 22;
			button7.Text = "订阅";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(Button7_Click);
			textBox8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox8.Location = new System.Drawing.Point(62, 214);
			textBox8.Multiline = true;
			textBox8.Name = "textBox8";
			textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox8.Size = new System.Drawing.Size(783, 279);
			textBox8.TabIndex = 18;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(2, 216);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(64, 17);
			label12.TabIndex = 19;
			label12.Text = "Receive：";
			button4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button4.Location = new System.Drawing.Point(774, 179);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(71, 28);
			button4.TabIndex = 17;
			button4.Text = "清空";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			textBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox4.Location = new System.Drawing.Point(62, 36);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(783, 138);
			textBox4.TabIndex = 8;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(4, 39);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(66, 17);
			label9.TabIndex = 11;
			label9.Text = "Payload：";
			label8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(393, 11);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(56, 17);
			label8.TabIndex = 10;
			label8.Text = "主题信息";
			textBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox5.Location = new System.Drawing.Point(62, 7);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(324, 23);
			textBox5.TabIndex = 9;
			textBox5.Text = "A";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(4, 11);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(52, 17);
			label7.TabIndex = 7;
			label7.Text = "Topic：";
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(62, 184);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(69, 21);
			checkBox1.TabIndex = 30;
			checkBox1.Text = "Retain?";
			checkBox1.UseVisualStyleBackColor = true;
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/11631894.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "MQTT";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 14;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			panel4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel4.Controls.Add(listBox1);
			panel4.Controls.Add(label13);
			panel4.Location = new System.Drawing.Point(4, 123);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(141, 517);
			panel4.TabIndex = 15;
			listBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 17;
			listBox1.Location = new System.Drawing.Point(3, 23);
			listBox1.Name = "listBox1";
			listBox1.Size = new System.Drawing.Size(133, 480);
			listBox1.TabIndex = 9;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(3, 3);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(129, 17);
			label13.TabIndex = 8;
			label13.Text = "Subscribed：(已订阅)";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(panel4);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormMqttClient";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "MQTT客户端";
			base.Load += new System.EventHandler(FormClient_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			ResumeLayout(false);
		}
	}
}
