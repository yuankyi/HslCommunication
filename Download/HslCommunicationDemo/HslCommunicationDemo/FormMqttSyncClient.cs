using HslCommunication;
using HslCommunication.MQTT;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.Properties;
using HslControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormMqttSyncClient : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003CTreeView1_AfterSelect_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public TreeViewEventArgs e;

			public FormMqttSyncClient _003C_003E4__this;

			private TreeNode _003Cnode_003E5__1;

			private MqttRpcApiInfo _003CapiInfo_003E5__2;

			private OperateResult<long[]> _003Cread_003E5__3;

			private long[] _003Cdata_003E5__4;

			private int[] _003Cydata_003E5__5;

			private string[] _003Cxdata_003E5__6;

			private int _003Ci_003E5__7;

			private string _003Ctopic_003E5__8;

			private OperateResult<MqttClientApplicationMessage> _003Cmessage_003E5__9;

			private OperateResult<MqttClientApplicationMessage> _003C_003Es__10;

			private TaskAwaiter<OperateResult<MqttClientApplicationMessage>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<MqttClientApplicationMessage>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<MqttClientApplicationMessage>>);
						num = (_003C_003E1__state = -1);
						goto IL_03ed;
					}
					_003Cnode_003E5__1 = _003C_003E4__this.treeView1.SelectedNode;
					if (_003Cnode_003E5__1 != null)
					{
						if (!(_003Cnode_003E5__1.SelectedImageKey == "VirtualMachine"))
						{
							object tag = _003Cnode_003E5__1.Tag;
							_003CapiInfo_003E5__2 = (tag as MqttRpcApiInfo);
							if (_003CapiInfo_003E5__2 == null)
							{
								tag = _003Cnode_003E5__1.Tag;
								_003Ctopic_003E5__8 = (tag as string);
								if (_003Ctopic_003E5__8 != null)
								{
									_003C_003E4__this.panel5.Visible = true;
									_003C_003E4__this.panel2.Visible = false;
									_003C_003E4__this.hslProgress3.Value = 0;
									awaiter = _003C_003E4__this.mqttSyncClient.ReadTopicPayloadAsync(_003Ctopic_003E5__8, _003C_003E4__this.ReceiveTopicProgressReport).GetAwaiter();
									if (!awaiter.IsCompleted)
									{
										num = (_003C_003E1__state = 0);
										_003C_003Eu__1 = awaiter;
										_003CTreeView1_AfterSelect_003Ed__18 stateMachine = this;
										_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
										return;
									}
									goto IL_03ed;
								}
								goto IL_0461;
							}
							_003C_003E4__this.panel5.Visible = false;
							_003C_003E4__this.panel2.Visible = true;
							_003C_003E4__this.textBox5.Text = _003CapiInfo_003E5__2.ApiTopic;
							_003C_003E4__this.textBox4.Text = _003CapiInfo_003E5__2.ExamplePayload;
							_003C_003E4__this.textBox12.Text = _003CapiInfo_003E5__2.CalledCount.ToString();
							_003C_003E4__this.textBox13.Text = _003CapiInfo_003E5__2.SpendTotalTime.ToString("F2");
							_003C_003E4__this.textBox_api_description.Text = _003CapiInfo_003E5__2.Description;
							_003C_003E4__this.textBox_api_sign.Text = _003CapiInfo_003E5__2.MethodSignature;
							_003Cread_003E5__3 = _003C_003E4__this.mqttSyncClient.ReadRpcApiLog(_003CapiInfo_003E5__2.ApiTopic);
							if (_003Cread_003E5__3.IsSuccess)
							{
								_003Cdata_003E5__4 = _003Cread_003E5__3.Content.SelectLast(7);
								_003Cydata_003E5__5 = new int[7];
								_003Cxdata_003E5__6 = new string[7];
								_003Ci_003E5__7 = 0;
								while (_003Ci_003E5__7 < 7)
								{
									_003Cydata_003E5__5[_003Ci_003E5__7] = (int)_003Cdata_003E5__4[_003Ci_003E5__7];
									_003Cxdata_003E5__6[_003Ci_003E5__7] = DateTime.Now.AddDays((double)(_003Ci_003E5__7 - 6)).ToString("M-d");
									_003C_003E4__this.hslBarChart1.SetDataSource(_003Cydata_003E5__5, _003Cxdata_003E5__6);
									_003Ci_003E5__7++;
								}
								_003Cdata_003E5__4 = null;
								_003Cydata_003E5__5 = null;
								_003Cxdata_003E5__6 = null;
							}
							else
							{
								_003C_003E4__this.hslBarChart1.SetDataSource(new int[7]);
							}
							_003Cread_003E5__3 = null;
							goto IL_0468;
						}
						if (_003Cnode_003E5__1.Text == "Rpc Apis")
						{
							_003C_003E4__this.panel5.Visible = false;
							_003C_003E4__this.panel2.Visible = true;
						}
						else
						{
							_003C_003E4__this.panel5.Visible = true;
							_003C_003E4__this.panel2.Visible = false;
						}
					}
					goto end_IL_0007;
					IL_0461:
					_003Ctopic_003E5__8 = null;
					goto IL_0468;
					IL_03ed:
					_003C_003Es__10 = awaiter.GetResult();
					_003Cmessage_003E5__9 = _003C_003Es__10;
					_003C_003Es__10 = null;
					if (!_003Cmessage_003E5__9.IsSuccess)
					{
						MessageBox.Show("Failed: " + _003Cmessage_003E5__9.Message);
					}
					else
					{
						_003C_003E4__this.UpdateMqttTopicMessage(_003Cmessage_003E5__9.Content);
					}
					_003Cmessage_003E5__9 = null;
					goto IL_0461;
					IL_0468:
					_003CapiInfo_003E5__2 = null;
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cnode_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cnode_003E5__1 = null;
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
		private sealed class _003Cbutton1_Click_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttSyncClient _003C_003E4__this;

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
							UseRSAProvider = _003C_003E4__this.checkBox_rsa.Checked
						};
						if (!string.IsNullOrEmpty(_003C_003E4__this.textBox9.Text) || !string.IsNullOrEmpty(_003C_003E4__this.textBox10.Text))
						{
							_003Coptions_003E5__1.Credentials = new MqttCredential(_003C_003E4__this.textBox9.Text, _003C_003E4__this.textBox10.Text);
						}
						_003C_003E4__this.button1.Enabled = false;
						_003C_003E4__this.mqttSyncClient = new MqttSyncClient(_003Coptions_003E5__1);
						awaiter = _003C_003E4__this.mqttSyncClient.ConnectServerAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton1_Click_003Ed__4 stateMachine = this;
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
						_003C_003E4__this.panel4.Enabled = true;
						_003C_003E4__this.panel2.Enabled = true;
						_003C_003E4__this.MqttRpcApiRefresh(_003C_003E4__this.treeView1.Nodes[0]);
						_003C_003E4__this.TopicsRefresh(_003C_003E4__this.treeView1.Nodes[1]);
						MessageBox.Show(StringResources.Language.ConnectServerSuccess);
					}
					else
					{
						_003C_003E4__this.button1.Enabled = true;
						MessageBox.Show(_003Cconnect_003E5__2.Message);
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

		[CompilerGenerated]
		private sealed class _003Cbutton3_Click_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttSyncClient _003C_003E4__this;

			private DateTime _003Cstart_003E5__1;

			private OperateResult<string, byte[]> _003Cread_003E5__2;

			private string _003Cmsg_003E5__3;

			private OperateResult<string, byte[]> _003C_003Es__4;

			private MqttRpcApiInfo _003Capi_003E5__5;

			private TaskAwaiter<OperateResult<string, byte[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<string, byte[]>> awaiter;
					if (num != 0)
					{
						_003C_003E4__this.hslProgress1.Value = 0;
						_003C_003E4__this.hslProgress1.TextRenderFormat = "Send {0}%";
						_003Cstart_003E5__1 = DateTime.Now;
						_003C_003E4__this.button3.Enabled = false;
						awaiter = _003C_003E4__this.mqttSyncClient.ReadAsync(_003C_003E4__this.textBox5.Text, Encoding.UTF8.GetBytes(_003C_003E4__this.textBox4.Text), _003C_003E4__this.ProgressReport, null, _003C_003E4__this.ProgressReport).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton3_Click_003Ed__8 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<string, byte[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter.GetResult();
					_003Cread_003E5__2 = _003C_003Es__4;
					_003C_003Es__4 = null;
					_003C_003E4__this.button3.Enabled = true;
					_003C_003E4__this.textBox7.Text = ((int)(DateTime.Now - _003Cstart_003E5__1).TotalMilliseconds).ToString() + " ms";
					if (!_003Cread_003E5__2.IsSuccess)
					{
						MessageBox.Show("Read Failed:" + _003Cread_003E5__2.ToMessageShowString());
					}
					else
					{
						if (_003C_003E4__this.mqttRpcApiInfos != null)
						{
							_003Capi_003E5__5 = _003C_003E4__this.mqttRpcApiInfos.FirstOrDefault((MqttRpcApiInfo m) => m.ApiTopic == _003C_003E4__this.textBox5.Text);
							if (_003Capi_003E5__5 != null)
							{
								_003Capi_003E5__5.ExamplePayload = _003C_003E4__this.textBox4.Text;
							}
							_003Capi_003E5__5 = null;
						}
						_003C_003E4__this.textBox6.Text = _003Cread_003E5__2.Content1;
						_003Cmsg_003E5__3 = Encoding.UTF8.GetString(_003Cread_003E5__2.Content2);
						if (_003C_003E4__this.radioButton4.Checked)
						{
							try
							{
								_003Cmsg_003E5__3 = XElement.Parse(_003Cmsg_003E5__3).ToString();
							}
							catch
							{
							}
						}
						else if (_003C_003E4__this.radioButton5.Checked)
						{
							try
							{
								if (_003Cmsg_003E5__3.StartsWith("\"{") && _003Cmsg_003E5__3.EndsWith("}\""))
								{
									_003Cmsg_003E5__3 = JObject.Parse(JsonConvert.DeserializeObject<string>(_003Cmsg_003E5__3)).ToString();
								}
								else
								{
									_003Cmsg_003E5__3 = JObject.Parse(_003Cmsg_003E5__3).ToString();
								}
							}
							catch
							{
							}
						}
						_003C_003E4__this.textBox8.Text = _003Cmsg_003E5__3;
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cread_003E5__2 = null;
					_003Cmsg_003E5__3 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cread_003E5__2 = null;
				_003Cmsg_003E5__3 = null;
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

		private MqttSyncClient mqttSyncClient;

		private MqttRpcApiInfo[] mqttRpcApiInfos;

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

		private TextBox textBox5;

		private Label label7;

		private UserControlHead userControlHead1;

		private TextBox textBox10;

		private Label label4;

		private TextBox textBox9;

		private Label label2;

		private TextBox textBox3;

		private Label label6;

		private RadioButton radioButton5;

		private RadioButton radioButton4;

		private RadioButton radioButton3;

		private Panel panel3;

		private TextBox textBox7;

		private TextBox textBox6;

		private HslProgress hslProgress1;

		private Panel panel4;

		private TreeView treeView1;

		private Label label10;

		private Button button7;

		private TextBox textBox13;

		private Label label14;

		private TextBox textBox12;

		private Label label13;

		private Label label11;

		private Button button8;

		private Label label5;

		private Panel panel5;

		private TextBox textBox14;

		private Label label17;

		private HslProgress hslProgress3;

		private Panel panel6;

		private RadioButton radioButton1;

		private RadioButton radioButton2;

		private RadioButton radioButton6;

		private TextBox textBox17;

		private Label label19;

		private Button button12;

		private TextBox textBox19;

		private Label label21;

		private Label label22;

		private Label label8;

		private TextBox textBox16;

		private Label label16;

		private Label label18;

		private Panel panel7;

		private HslBarChart hslBarChart1;

		private CheckBox checkBox_rsa;

		private Label label23;

		private TextBox textBox_api_description;

		private Label label15;

		private Label label24;

		private TextBox textBox_api_sign;

		public FormMqttSyncClient()
		{
			InitializeComponent();
		}

		private void FormClient_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			panel4.Enabled = false;
			button2.Enabled = false;
			Language(Program.Language);
			ImageList imageList = new ImageList();
			imageList.Images.Add("VirtualMachine", Resources.VirtualMachine);
			imageList.Images.Add("Class_489", Resources.Class_489);
			imageList.Images.Add("Enum_582", Resources.Enum_582);
			imageList.Images.Add("brackets_Square_16xMD", Resources.brackets_Square_16xMD);
			imageList.Images.Add("Method_636", Resources.Method_636);
			imageList.Images.Add("Module_648", Resources.Module_648);
			imageList.Images.Add("Structure_507", Resources.Structure_507);
			treeView1.AfterSelect += TreeView1_AfterSelect;
			treeView1.ImageList = imageList;
			treeView1.Nodes[0].ImageKey = "VirtualMachine";
			treeView1.Nodes[0].SelectedImageKey = "VirtualMachine";
			treeView1.Nodes[1].ImageKey = "VirtualMachine";
			treeView1.Nodes[1].SelectedImageKey = "VirtualMachine";
			panel5.Visible = false;
			panel2.Dock = DockStyle.Fill;
			panel5.Dock = DockStyle.Fill;
		}

		private void Language(int language)
		{
			if (language != 1)
			{
				Text = "Mqtt Sync Client [RPC remote call client]";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label7.Text = "Topic:";
				label9.Text = "Payload:";
				button3.Text = "Read";
				button4.Text = "Clear";
				label12.Text = "R-Topic:";
				label5.Text = "R-Payload:";
				button3.Text = "Read";
				hslProgress1.TextRenderFormat = "Send {0}%";
				label6.Text = "Client ID:";
				label2.Text = "UserName:";
				label4.Text = "Password:";
				label11.Text = "Spend-Time:";
				button8.Text = "Refresh";
				label24.Text = "[Sign]";
				label15.Text = "[Note]";
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton1_Click_003Ed__4))]
		[DebuggerStepThrough]
		private void button1_Click(object sender, EventArgs e)
		{
			_003Cbutton1_Click_003Ed__4 stateMachine = new _003Cbutton1_Click_003Ed__4();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;
			panel4.Enabled = false;
			mqttSyncClient.ConnectClose();
		}

		private void ProgressReport(long already, long total)
		{
			if (base.InvokeRequired)
			{
				Invoke(new Action<long, long>(ProgressReport), already, total);
			}
			else
			{
				hslProgress1.Value = (int)(already * 100 / total);
				if (already == total)
				{
					hslProgress1.TextRenderFormat = "Receive {0}%";
				}
			}
		}

		private void ReceiveProgressReport(long already, long total)
		{
			if (base.InvokeRequired)
			{
				Invoke(new Action<long, long>(ReceiveProgressReport), already, total);
			}
			else
			{
				hslProgress1.Value = (int)(already * 100 / total);
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton3_Click_003Ed__8))]
		[DebuggerStepThrough]
		private void button3_Click(object sender, EventArgs e)
		{
			_003Cbutton3_Click_003Ed__8 stateMachine = new _003Cbutton3_Click_003Ed__8();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			textBox8.Clear();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			OperateResult<MqttRpcApiInfo[]> operateResult = mqttSyncClient.ReadRpcApis();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.Message);
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			MqttRpcApiRefresh(treeView1.Nodes[0]);
			TopicsRefresh(treeView1.Nodes[1]);
		}

		public void UpdateMqttTopicMessage(MqttClientApplicationMessage message)
		{
			textBox19.Text = message.ClientId;
			textBox14.Text = message.UserName;
			label18.Text = message.CreateTime.ToString();
			textBox16.Text = message.Topic;
			label8.Text = message.QualityOfServiceLevel.ToString();
			string text = Encoding.UTF8.GetString(message.Payload);
			if (radioButton6.Checked)
			{
				try
				{
					text = XElement.Parse(text).ToString();
				}
				catch
				{
				}
			}
			else if (radioButton1.Checked)
			{
				try
				{
					text = ((!text.StartsWith("\"{") || !text.EndsWith("}\"")) ? JObject.Parse(text).ToString() : JObject.Parse(JsonConvert.DeserializeObject<string>(text)).ToString());
				}
				catch
				{
				}
			}
			textBox17.Text = ((text != null && text.Length > 10000) ? (text.Substring(0, 10000) + "...") : text);
		}

		private void MqttRpcApiRefresh(TreeNode rootNode)
		{
			rootNode.Nodes.Clear();
			OperateResult<MqttRpcApiInfo[]> operateResult = mqttSyncClient.ReadRpcApis();
			if (operateResult.IsSuccess)
			{
				mqttRpcApiInfos = operateResult.Content;
				MqttRpcApiInfo[] content = operateResult.Content;
				foreach (MqttRpcApiInfo mqttRpcApiInfo in content)
				{
					AddTreeNode(rootNode, mqttRpcApiInfo.ApiTopic, mqttRpcApiInfo.ApiTopic, mqttRpcApiInfo);
				}
				rootNode.Expand();
			}
		}

		private void TopicsRefresh(TreeNode rootNode)
		{
			rootNode.Nodes.Clear();
			OperateResult<string[]> operateResult = mqttSyncClient.ReadRetainTopics();
			if (operateResult.IsSuccess)
			{
				string[] content = operateResult.Content;
				foreach (string text in content)
				{
					AddTopicTreeNode(rootNode, text, text);
				}
				rootNode.Expand();
			}
		}

		private void AddTopicTreeNode(TreeNode parent, string key, string infactKey)
		{
			int num = key.IndexOf('/');
			if (num <= 0)
			{
				TreeNode treeNode = new TreeNode(key ?? "");
				treeNode.Tag = infactKey;
				treeNode.ImageKey = "Enum_582";
				treeNode.SelectedImageKey = "Enum_582";
				parent.Nodes.Add(treeNode);
			}
			else
			{
				TreeNode treeNode2 = null;
				for (int i = 0; i < parent.Nodes.Count; i++)
				{
					if (parent.Nodes[i].Text == key.Substring(0, num))
					{
						treeNode2 = parent.Nodes[i];
						break;
					}
				}
				if (treeNode2 == null)
				{
					treeNode2 = new TreeNode(key.Substring(0, num));
					treeNode2.ImageKey = "Class_489";
					treeNode2.SelectedImageKey = "Class_489";
					AddTopicTreeNode(treeNode2, key.Substring(num + 1), infactKey);
					parent.Nodes.Add(treeNode2);
				}
				else
				{
					AddTopicTreeNode(treeNode2, key.Substring(num + 1), infactKey);
				}
			}
		}

		private void AddTreeNode(TreeNode parent, string key, string infactKey, MqttRpcApiInfo mqttRpc)
		{
			int num = key.IndexOf('/');
			if (num <= 0)
			{
				TreeNode treeNode = new TreeNode(key ?? "");
				treeNode.Tag = mqttRpc;
				treeNode.ImageKey = (mqttRpc.IsMethodApi ? "Method_636" : "Enum_582");
				treeNode.SelectedImageKey = (mqttRpc.IsMethodApi ? "Method_636" : "Enum_582");
				parent.Nodes.Add(treeNode);
			}
			else
			{
				TreeNode treeNode2 = null;
				for (int i = 0; i < parent.Nodes.Count; i++)
				{
					if (parent.Nodes[i].Text == key.Substring(0, num))
					{
						treeNode2 = parent.Nodes[i];
						break;
					}
				}
				if (treeNode2 == null)
				{
					treeNode2 = new TreeNode(key.Substring(0, num));
					treeNode2.ImageKey = "Class_489";
					treeNode2.SelectedImageKey = "Class_489";
					AddTreeNode(treeNode2, key.Substring(num + 1), infactKey, mqttRpc);
					parent.Nodes.Add(treeNode2);
				}
				else
				{
					AddTreeNode(treeNode2, key.Substring(num + 1), infactKey, mqttRpc);
				}
			}
		}

		[AsyncStateMachine(typeof(_003CTreeView1_AfterSelect_003Ed__18))]
		[DebuggerStepThrough]
		private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			_003CTreeView1_AfterSelect_003Ed__18 stateMachine = new _003CTreeView1_AfterSelect_003Ed__18();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void ReceiveTopicProgressReport(long already, long total)
		{
			if (base.InvokeRequired)
			{
				Invoke(new Action<long, long>(ReceiveProgressReport), already, total);
			}
			else
			{
				hslProgress3.Value = (int)(already * 100 / total);
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlCompanyID, textBox3.Text);
			element.SetAttributeValue(DemoDeviceList.XmlUserName, textBox9.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPassword, textBox10.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox3.Text = element.Attribute(DemoDeviceList.XmlCompanyID).Value;
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
			System.Windows.Forms.TreeNode treeNode = new System.Windows.Forms.TreeNode("Rpc Apis");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Topics");
			panel1 = new System.Windows.Forms.Panel();
			checkBox_rsa = new System.Windows.Forms.CheckBox();
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
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
			label24 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			textBox_api_description = new System.Windows.Forms.TextBox();
			hslBarChart1 = new HslControls.HslBarChart();
			button7 = new System.Windows.Forms.Button();
			textBox13 = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			textBox12 = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			hslProgress1 = new HslControls.HslProgress();
			textBox7 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			panel3 = new System.Windows.Forms.Panel();
			radioButton5 = new System.Windows.Forms.RadioButton();
			radioButton3 = new System.Windows.Forms.RadioButton();
			radioButton4 = new System.Windows.Forms.RadioButton();
			textBox8 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label23 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel4 = new System.Windows.Forms.Panel();
			button8 = new System.Windows.Forms.Button();
			treeView1 = new System.Windows.Forms.TreeView();
			label10 = new System.Windows.Forms.Label();
			panel5 = new System.Windows.Forms.Panel();
			label18 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			textBox14 = new System.Windows.Forms.TextBox();
			label17 = new System.Windows.Forms.Label();
			hslProgress3 = new HslControls.HslProgress();
			textBox16 = new System.Windows.Forms.TextBox();
			panel6 = new System.Windows.Forms.Panel();
			radioButton1 = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton6 = new System.Windows.Forms.RadioButton();
			textBox17 = new System.Windows.Forms.TextBox();
			label19 = new System.Windows.Forms.Label();
			button12 = new System.Windows.Forms.Button();
			textBox19 = new System.Windows.Forms.TextBox();
			label21 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			panel7 = new System.Windows.Forms.Panel();
			textBox_api_sign = new System.Windows.Forms.TextBox();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			panel4.SuspendLayout();
			panel5.SuspendLayout();
			panel6.SuspendLayout();
			panel7.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(checkBox_rsa);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label6);
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
			panel1.Size = new System.Drawing.Size(1108, 61);
			panel1.TabIndex = 7;
			checkBox_rsa.AutoSize = true;
			checkBox_rsa.Location = new System.Drawing.Point(720, 5);
			checkBox_rsa.Name = "checkBox_rsa";
			checkBox_rsa.Size = new System.Drawing.Size(287, 21);
			checkBox_rsa.TabIndex = 18;
			checkBox_rsa.Text = "RSA加密 (支持v10.2.0版本及以上的MqttServer)";
			checkBox_rsa.UseVisualStyleBackColor = true;
			textBox3.Location = new System.Drawing.Point(86, 32);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(611, 23);
			textBox3.TabIndex = 17;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(8, 35);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(80, 17);
			label6.TabIndex = 16;
			label6.Text = "客户端标识：";
			textBox10.Location = new System.Drawing.Point(584, 3);
			textBox10.Name = "textBox10";
			textBox10.Size = new System.Drawing.Size(113, 23);
			textBox10.TabIndex = 13;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(520, 6);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(44, 17);
			label4.TabIndex = 12;
			label4.Text = "密码：";
			textBox9.Location = new System.Drawing.Point(417, 3);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(91, 23);
			textBox9.TabIndex = 11;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(341, 6);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(56, 17);
			label2.TabIndex = 10;
			label2.Text = "用户名：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(828, 27);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(718, 27);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(243, 3);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(79, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "1883";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(189, 6);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 3);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(115, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 6);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(textBox_api_sign);
			panel2.Controls.Add(label24);
			panel2.Controls.Add(label15);
			panel2.Controls.Add(textBox_api_description);
			panel2.Controls.Add(hslBarChart1);
			panel2.Controls.Add(button7);
			panel2.Controls.Add(textBox13);
			panel2.Controls.Add(label14);
			panel2.Controls.Add(textBox12);
			panel2.Controls.Add(label13);
			panel2.Controls.Add(hslProgress1);
			panel2.Controls.Add(textBox7);
			panel2.Controls.Add(label11);
			panel2.Controls.Add(textBox6);
			panel2.Controls.Add(panel3);
			panel2.Controls.Add(textBox8);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(button4);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label9);
			panel2.Controls.Add(textBox5);
			panel2.Controls.Add(label7);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(label23);
			panel2.Location = new System.Drawing.Point(59, 14);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(778, 497);
			panel2.TabIndex = 13;
			label24.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label24.AutoSize = true;
			label24.ForeColor = System.Drawing.Color.Gray;
			label24.Location = new System.Drawing.Point(0, 38);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(40, 17);
			label24.TabIndex = 51;
			label24.Text = "[签名]";
			label15.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label15.AutoSize = true;
			label15.ForeColor = System.Drawing.Color.Gray;
			label15.Location = new System.Drawing.Point(0, 60);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(40, 17);
			label15.TabIndex = 50;
			label15.Text = "[注释]";
			textBox_api_description.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_api_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox_api_description.ForeColor = System.Drawing.Color.Gray;
			textBox_api_description.Location = new System.Drawing.Point(62, 60);
			textBox_api_description.Multiline = true;
			textBox_api_description.Name = "textBox_api_description";
			textBox_api_description.ReadOnly = true;
			textBox_api_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_api_description.Size = new System.Drawing.Size(711, 56);
			textBox_api_description.TabIndex = 49;
			hslBarChart1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			hslBarChart1.BackColor = System.Drawing.Color.White;
			hslBarChart1.Location = new System.Drawing.Point(444, 122);
			hslBarChart1.Name = "hslBarChart1";
			hslBarChart1.ShowBarValueFormat = "{0}";
			hslBarChart1.Size = new System.Drawing.Size(329, 166);
			hslBarChart1.TabIndex = 46;
			hslBarChart1.Text = "hslBarChart1";
			hslBarChart1.Title = "Called Infomation";
			hslBarChart1.UseGradient = true;
			button7.Location = new System.Drawing.Point(138, 266);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(119, 28);
			button7.TabIndex = 40;
			button7.Text = "Apis Information";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			textBox13.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			textBox13.Location = new System.Drawing.Point(682, 8);
			textBox13.Name = "textBox13";
			textBox13.ReadOnly = true;
			textBox13.Size = new System.Drawing.Size(91, 23);
			textBox13.TabIndex = 39;
			label14.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(559, 11);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(113, 17);
			label14.TabIndex = 38;
			label14.Text = "Spend Total Time:";
			textBox12.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			textBox12.Location = new System.Drawing.Point(456, 8);
			textBox12.Name = "textBox12";
			textBox12.ReadOnly = true;
			textBox12.Size = new System.Drawing.Size(91, 23);
			textBox12.TabIndex = 37;
			label13.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(364, 11);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(85, 17);
			label13.TabIndex = 36;
			label13.Text = "Called Count:";
			hslProgress1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			hslProgress1.BackColor = System.Drawing.Color.Gainsboro;
			hslProgress1.Location = new System.Drawing.Point(62, 242);
			hslProgress1.Name = "hslProgress1";
			hslProgress1.ProgressColor = System.Drawing.Color.FromArgb(128, 255, 128);
			hslProgress1.ProgressStyle = HslControls.HslProgressStyle.Horizontal;
			hslProgress1.Size = new System.Drawing.Size(376, 18);
			hslProgress1.TabIndex = 32;
			hslProgress1.TextRenderFormat = "已发送 {0}%";
			hslProgress1.Value = 0;
			textBox7.Location = new System.Drawing.Point(345, 267);
			textBox7.Name = "textBox7";
			textBox7.ReadOnly = true;
			textBox7.Size = new System.Drawing.Size(81, 23);
			textBox7.TabIndex = 31;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(261, 270);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 30;
			label11.Text = "耗时：";
			textBox6.Location = new System.Drawing.Point(62, 298);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(399, 23);
			textBox6.TabIndex = 29;
			panel3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			panel3.Controls.Add(radioButton5);
			panel3.Controls.Add(radioButton3);
			panel3.Controls.Add(radioButton4);
			panel3.Location = new System.Drawing.Point(488, 293);
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
			textBox8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox8.Location = new System.Drawing.Point(62, 327);
			textBox8.Multiline = true;
			textBox8.Name = "textBox8";
			textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox8.Size = new System.Drawing.Size(711, 165);
			textBox8.TabIndex = 18;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(0, 301);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(68, 17);
			label12.TabIndex = 19;
			label12.Text = "接收主题：";
			button4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button4.Location = new System.Drawing.Point(704, 292);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(71, 28);
			button4.TabIndex = 17;
			button4.Text = "清空";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button3.Location = new System.Drawing.Point(62, 266);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(70, 28);
			button3.TabIndex = 12;
			button3.Text = "读取";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox4.Location = new System.Drawing.Point(62, 122);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox4.Size = new System.Drawing.Size(376, 115);
			textBox4.TabIndex = 8;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(0, 125);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(68, 17);
			label9.TabIndex = 11;
			label9.Text = "上传数据：";
			textBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox5.Location = new System.Drawing.Point(62, 7);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(296, 23);
			textBox5.TabIndex = 9;
			textBox5.Text = "A";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(0, 11);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(44, 17);
			label7.TabIndex = 7;
			label7.Text = "主题：";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(0, 331);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(68, 17);
			label5.TabIndex = 42;
			label5.Text = "接收数据：";
			label23.AutoSize = true;
			label23.ForeColor = System.Drawing.Color.Gray;
			label23.Location = new System.Drawing.Point(3, 243);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(44, 17);
			label23.TabIndex = 48;
			label23.Text = "进度：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/11631894.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "MQTT RPC";
			userControlHead1.Size = new System.Drawing.Size(1115, 32);
			userControlHead1.TabIndex = 14;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			panel4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel4.Controls.Add(button8);
			panel4.Controls.Add(treeView1);
			panel4.Controls.Add(label10);
			panel4.Location = new System.Drawing.Point(3, 100);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(259, 520);
			panel4.TabIndex = 15;
			button8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button8.Location = new System.Drawing.Point(180, 2);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(75, 23);
			button8.TabIndex = 2;
			button8.Text = "刷新";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			treeView1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			treeView1.Location = new System.Drawing.Point(3, 27);
			treeView1.Name = "treeView1";
			treeNode.Name = "节点0";
			treeNode.Text = "Rpc Apis";
			treeNode2.Name = "节点0";
			treeNode2.Text = "Topics";
			treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[2]
			{
				treeNode,
				treeNode2
			});
			treeView1.Size = new System.Drawing.Size(251, 485);
			treeView1.TabIndex = 1;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(5, 6);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(140, 17);
			label10.TabIndex = 0;
			label10.Text = "Api List: (RPC 接口列表)";
			panel5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel5.Controls.Add(label18);
			panel5.Controls.Add(label16);
			panel5.Controls.Add(label8);
			panel5.Controls.Add(textBox14);
			panel5.Controls.Add(label17);
			panel5.Controls.Add(hslProgress3);
			panel5.Controls.Add(textBox16);
			panel5.Controls.Add(panel6);
			panel5.Controls.Add(textBox17);
			panel5.Controls.Add(label19);
			panel5.Controls.Add(button12);
			panel5.Controls.Add(textBox19);
			panel5.Controls.Add(label21);
			panel5.Controls.Add(label22);
			panel5.Location = new System.Drawing.Point(21, 60);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(942, 525);
			panel5.TabIndex = 16;
			label18.AutoSize = true;
			label18.ForeColor = System.Drawing.Color.Gray;
			label18.Location = new System.Drawing.Point(62, 47);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(79, 17);
			label18.TabIndex = 45;
			label18.Text = "UpdateTime";
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(0, 47);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(48, 17);
			label16.TabIndex = 44;
			label16.Text = "Time：";
			label8.AutoSize = true;
			label8.ForeColor = System.Drawing.Color.Gray;
			label8.Location = new System.Drawing.Point(411, 83);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(37, 17);
			label8.TabIndex = 43;
			label8.Text = "Level";
			textBox14.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			textBox14.Location = new System.Drawing.Point(620, 8);
			textBox14.Name = "textBox14";
			textBox14.ReadOnly = true;
			textBox14.Size = new System.Drawing.Size(317, 23);
			textBox14.TabIndex = 37;
			label17.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label17.AutoSize = true;
			label17.Location = new System.Drawing.Point(532, 11);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(73, 17);
			label17.TabIndex = 36;
			label17.Text = "UserName:";
			hslProgress3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			hslProgress3.BackColor = System.Drawing.Color.Gainsboro;
			hslProgress3.Location = new System.Drawing.Point(62, 109);
			hslProgress3.Name = "hslProgress3";
			hslProgress3.ProgressColor = System.Drawing.Color.FromArgb(128, 255, 128);
			hslProgress3.ProgressStyle = HslControls.HslProgressStyle.Horizontal;
			hslProgress3.Size = new System.Drawing.Size(875, 18);
			hslProgress3.TabIndex = 33;
			hslProgress3.TextRenderFormat = "已接收 {0}%";
			hslProgress3.Value = 0;
			textBox16.Location = new System.Drawing.Point(62, 80);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(343, 23);
			textBox16.TabIndex = 29;
			panel6.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			panel6.Controls.Add(radioButton1);
			panel6.Controls.Add(radioButton2);
			panel6.Controls.Add(radioButton6);
			panel6.Location = new System.Drawing.Point(683, 78);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(184, 28);
			panel6.TabIndex = 26;
			radioButton1.AutoSize = true;
			radioButton1.Location = new System.Drawing.Point(123, 3);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(52, 21);
			radioButton1.TabIndex = 28;
			radioButton1.Text = "Json";
			radioButton1.UseVisualStyleBackColor = true;
			radioButton2.AutoSize = true;
			radioButton2.Checked = true;
			radioButton2.Location = new System.Drawing.Point(13, 3);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(50, 21);
			radioButton2.TabIndex = 26;
			radioButton2.TabStop = true;
			radioButton2.Text = "Text";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton6.AutoSize = true;
			radioButton6.Location = new System.Drawing.Point(69, 3);
			radioButton6.Name = "radioButton6";
			radioButton6.Size = new System.Drawing.Size(48, 21);
			radioButton6.TabIndex = 27;
			radioButton6.Text = "Xml";
			radioButton6.UseVisualStyleBackColor = true;
			textBox17.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox17.Location = new System.Drawing.Point(62, 133);
			textBox17.Multiline = true;
			textBox17.Name = "textBox17";
			textBox17.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox17.Size = new System.Drawing.Size(875, 384);
			textBox17.TabIndex = 18;
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(0, 83);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(68, 17);
			label19.TabIndex = 19;
			label19.Text = "接收主题：";
			button12.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button12.Location = new System.Drawing.Point(867, 78);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(71, 28);
			button12.TabIndex = 17;
			button12.Text = "清空";
			button12.UseVisualStyleBackColor = true;
			textBox19.Location = new System.Drawing.Point(62, 7);
			textBox19.Name = "textBox19";
			textBox19.ReadOnly = true;
			textBox19.Size = new System.Drawing.Size(237, 23);
			textBox19.TabIndex = 9;
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(0, 11);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(65, 17);
			label21.TabIndex = 7;
			label21.Text = "ClientID：";
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(0, 136);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(68, 17);
			label22.TabIndex = 42;
			label22.Text = "接收数据：";
			panel7.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel7.Controls.Add(panel2);
			panel7.Controls.Add(panel5);
			panel7.Location = new System.Drawing.Point(266, 102);
			panel7.Name = "panel7";
			panel7.Size = new System.Drawing.Size(843, 518);
			panel7.TabIndex = 17;
			textBox_api_sign.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_api_sign.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox_api_sign.ForeColor = System.Drawing.Color.Gray;
			textBox_api_sign.Location = new System.Drawing.Point(62, 39);
			textBox_api_sign.Name = "textBox_api_sign";
			textBox_api_sign.ReadOnly = true;
			textBox_api_sign.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_api_sign.Size = new System.Drawing.Size(711, 16);
			textBox_api_sign.TabIndex = 52;
			textBox_api_sign.Text = "[签名]";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1115, 625);
			base.Controls.Add(panel7);
			base.Controls.Add(panel4);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormMqttSyncClient";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "MQTT 同步客户端 (RPC远程调用客户端)";
			base.Load += new System.EventHandler(FormClient_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			panel6.ResumeLayout(false);
			panel6.PerformLayout();
			panel7.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
