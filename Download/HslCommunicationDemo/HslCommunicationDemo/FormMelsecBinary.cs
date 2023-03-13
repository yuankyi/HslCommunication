using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.LogNet;
using HslCommunication.MQTT;
using HslCommunication.Profinet.Melsec;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormMelsecBinary : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003Cbutton10_Click_003Ed__32 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMelsecBinary _003C_003E4__this;

			private OperateResult<TimeSpan> _003Cwait_003E5__1;

			private OperateResult<TimeSpan> _003C_003Es__2;

			private TaskAwaiter<OperateResult<TimeSpan>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<TimeSpan>> awaiter;
					if (num != 0)
					{
						_003C_003E4__this.button10.Enabled = false;
						awaiter = _003C_003E4__this.melsec_net.WaitAsync("M100", true, 100, 30000).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton10_Click_003Ed__32 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<TimeSpan>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cwait_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cwait_003E5__1.IsSuccess)
					{
						MessageBox.Show("Wait Success, Takes " + _003Cwait_003E5__1.Content.TotalSeconds.ToString("F1") + " Seconds");
					}
					else
					{
						MessageBox.Show("Wait Failed:" + _003Cwait_003E5__1.Message);
					}
					_003C_003E4__this.button10.Enabled = true;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cwait_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cwait_003E5__1 = null;
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
		private sealed class _003Cbutton11_Click_003Ed__33 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMelsecBinary _003C_003E4__this;

			private OperateResult<TimeSpan> _003Cwait_003E5__1;

			private OperateResult<TimeSpan> _003C_003Es__2;

			private TaskAwaiter<OperateResult<TimeSpan>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<TimeSpan>> awaiter;
					if (num != 0)
					{
						_003C_003E4__this.button11.Enabled = false;
						awaiter = _003C_003E4__this.melsec_net.WaitAsync("D100", (short)123, 100, 30000).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton11_Click_003Ed__33 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<TimeSpan>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cwait_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cwait_003E5__1.IsSuccess)
					{
						MessageBox.Show("Wait Success, Takes " + _003Cwait_003E5__1.Content.TotalSeconds.ToString("F1") + " Seconds");
					}
					else
					{
						MessageBox.Show("Wait Failed:" + _003Cwait_003E5__1.Message);
					}
					_003C_003E4__this.button11.Enabled = true;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cwait_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cwait_003E5__1 = null;
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
		private sealed class _003Cbutton1_Click_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMelsecBinary _003C_003E4__this;

			private OperateResult _003Cconnect_003E5__1;

			private int _003Cport_003E5__2;

			private OperateResult _003Cconnect_003E5__3;

			private OperateResult _003C_003Es__4;

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
						goto IL_02d0;
					}
					if (_003C_003E4__this.checkBox1.Checked)
					{
						_003Cconnect_003E5__1 = _003C_003E4__this.mqttClient.ConnectServer();
						if (!_003Cconnect_003E5__1.IsSuccess)
						{
							MessageBox.Show(_003Cconnect_003E5__1.Message + Environment.NewLine + "ErrorCode: " + _003Cconnect_003E5__1.ErrorCode.ToString());
							_003C_003E4__this.button1.Enabled = true;
						}
						else
						{
							_003Cconnect_003E5__1 = _003C_003E4__this.melsec_net.ConnectServer(_003C_003E4__this.mqttClient, _003C_003E4__this.readTopic, _003C_003E4__this.writeTopic);
							if (_003Cconnect_003E5__1.IsSuccess)
							{
								MessageBox.Show(StringResources.Language.ConnectedSuccess);
								_003C_003E4__this.button2.Enabled = true;
								_003C_003E4__this.button1.Enabled = false;
								_003C_003E4__this.panel2.Enabled = true;
								_003C_003E4__this.userControlReadWriteOp1.SetReadWriteNet(_003C_003E4__this.melsec_net, "D100", true);
							}
							else
							{
								MessageBox.Show(_003Cconnect_003E5__1.Message + Environment.NewLine + "ErrorCode: " + _003Cconnect_003E5__1.ErrorCode.ToString());
								_003C_003E4__this.button1.Enabled = true;
							}
							_003Cconnect_003E5__1 = null;
						}
					}
					else
					{
						_003C_003E4__this.melsec_net.IpAddress = _003C_003E4__this.textBox_ip.Text;
						if (int.TryParse(_003C_003E4__this.textBox_port.Text, out _003Cport_003E5__2))
						{
							_003C_003E4__this.melsec_net.Port = _003Cport_003E5__2;
							_003C_003E4__this.melsec_net.ConnectClose();
							_003C_003E4__this.melsec_net.LogNet = _003C_003E4__this.LogNet;
							_003C_003E4__this.button1.Enabled = false;
							_003C_003E4__this.melsec_net.ConnectTimeOut = 3000;
							awaiter = _003C_003E4__this.melsec_net.ConnectServerAsync().GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003Cbutton1_Click_003Ed__9 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
								return;
							}
							goto IL_02d0;
						}
						MessageBox.Show(DemoUtils.PortInputWrong);
					}
					goto end_IL_0007;
					IL_02d0:
					_003C_003Es__4 = awaiter.GetResult();
					_003Cconnect_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cconnect_003E5__3.IsSuccess)
					{
						MessageBox.Show(StringResources.Language.ConnectedSuccess);
						_003C_003E4__this.button2.Enabled = true;
						_003C_003E4__this.button1.Enabled = false;
						_003C_003E4__this.panel2.Enabled = true;
						_003C_003E4__this.userControlReadWriteOp1.SetReadWriteNet(_003C_003E4__this.melsec_net, "D100", true);
					}
					else
					{
						MessageBox.Show(_003Cconnect_003E5__3.Message + Environment.NewLine + "ErrorCode: " + _003Cconnect_003E5__3.ErrorCode.ToString());
						_003C_003E4__this.button1.Enabled = true;
					}
					_003Cconnect_003E5__3 = null;
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
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
		private sealed class _003Cbutton6_Click_003Ed__29 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMelsecBinary _003C_003E4__this;

			private OperateResult<string> _003CreadResult_003E5__1;

			private OperateResult<string> _003C_003Es__2;

			private TaskAwaiter<OperateResult<string>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<string>> awaiter;
					if (num != 0)
					{
						_003C_003E4__this.button6.Enabled = false;
						awaiter = _003C_003E4__this.melsec_net.ReadPlcTypeAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton6_Click_003Ed__29 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<string>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003CreadResult_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003CreadResult_003E5__1.IsSuccess)
					{
						MessageBox.Show("Type:" + _003CreadResult_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Failed: " + _003CreadResult_003E5__1.ToMessageShowString());
					}
					_003C_003E4__this.button6.Enabled = true;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003CreadResult_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003CreadResult_003E5__1 = null;
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
		private sealed class _003Cthread_test2_003Ed__25 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public FormMelsecBinary _003C_003E4__this;

			private int _003Ccount_003E5__1;

			private OperateResult _003C_003Es__2;

			private OperateResult<short> _003C_003Es__3;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private TaskAwaiter<OperateResult<short>> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter2;
					TaskAwaiter<OperateResult<short>> awaiter;
					switch (num)
					{
					default:
						_003Ccount_003E5__1 = 500;
						goto IL_0192;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
						num = (_003C_003E1__state = -1);
						goto IL_0097;
					case 1:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<OperateResult<short>>);
							num = (_003C_003E1__state = -1);
							goto IL_013f;
						}
						IL_0192:
						if (_003Ccount_003E5__1 <= 0)
						{
							break;
						}
						awaiter2 = _003C_003E4__this.melsec_net.WriteAsync("D100", (short)1234).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003Cthread_test2_003Ed__25 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
							return;
						}
						goto IL_0097;
						IL_0097:
						_003C_003Es__2 = awaiter2.GetResult();
						if (!_003C_003Es__2.IsSuccess)
						{
							_003C_003Es__2 = null;
							_003C_003E4__this.failed++;
						}
						awaiter = _003C_003E4__this.melsec_net.ReadInt16Async("D100").GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003Cthread_test2_003Ed__25 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_013f;
						IL_013f:
						_003C_003Es__3 = awaiter.GetResult();
						if (!_003C_003Es__3.IsSuccess)
						{
							_003C_003Es__3 = null;
							_003C_003E4__this.failed++;
						}
						_003Ccount_003E5__1--;
						goto IL_0192;
					}
					_003C_003E4__this.thread_end();
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
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

		private MelsecMcNet melsec_net = null;

		private MqttClient mqttClient;

		private string readTopic;

		private string writeTopic;

		private int thread_status = 0;

		private int failed = 0;

		private DateTime thread_time_start = DateTime.Now;

		private IContainer components = null;

		private Panel panel1;

		private Label label1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private TextBox textBox_port;

		private Label label3;

		private TextBox textBox_ip;

		private GroupBox groupBox4;

		private TextBox textBox11;

		private Label label14;

		private Button button26;

		private TextBox textBox13;

		private Label label16;

		private GroupBox groupBox3;

		private TextBox textBox10;

		private Label label13;

		private Button button25;

		private TextBox textBox9;

		private Label label12;

		private TextBox textBox6;

		private Label label11;

		private Label label22;

		private Label label21;

		private Button button3;

		private Button button5;

		private Button button4;

		private Button button6;

		private UserControlHead userControlHead1;

		private Button button8;

		private Button button7;

		private Button button9;

		private GroupBox groupBox5;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private TextBox textBox3;

		private Button button11;

		private Button button10;

		private CheckBox checkBox1;

		private Button button12;

		public FormMelsecBinary()
		{
			InitializeComponent();
			melsec_net = new MelsecMcNet();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			Language(Program.Language);
			checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
		}

		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				using (FormMqttInput formMqttInput = new FormMqttInput())
				{
					if (formMqttInput.ShowDialog() == DialogResult.OK)
					{
						mqttClient = new MqttClient(formMqttInput.MqttConnectionOptions);
						readTopic = formMqttInput.ReadTopic;
						writeTopic = formMqttInput.WriteTopic;
						textBox_ip.Enabled = false;
						textBox_port.Enabled = false;
					}
					else
					{
						checkBox1.Checked = false;
					}
				}
			}
			else
			{
				textBox_ip.Enabled = true;
				textBox_port.Enabled = true;
			}
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "Melsec Read PLC Demo";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
				label11.Text = "Address:";
				label12.Text = "length:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				label16.Text = "Message:";
				label14.Text = "Results:";
				button26.Text = "Read";
				button9.Text = "r-random";
				button12.Text = "r-block";
				groupBox3.Text = "Bulk Read test";
				groupBox4.Text = "Message reading test, hex string needs to be filled in";
				groupBox5.Text = "Special function test";
				button3.Text = "Pressure test, r/w 3,000s";
				label22.Text = "M100 D100 X1A0 Y1A0";
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		[AsyncStateMachine(typeof(_003Cbutton1_Click_003Ed__9))]
		[DebuggerStepThrough]
		private void button1_Click(object sender, EventArgs e)
		{
			_003Cbutton1_Click_003Ed__9 stateMachine = new _003Cbutton1_Click_003Ed__9();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			melsec_net.ConnectClose();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			DemoUtils.BulkReadRenderResult(melsec_net, textBox6, textBox9, textBox10);
		}

		private void button9_Click(object sender, EventArgs e)
		{
			OperateResult<byte[]> operateResult = melsec_net.ReadRandom(textBox6.Text.Split(new char[1]
			{
				';'
			}, StringSplitOptions.RemoveEmptyEntries));
			if (operateResult.IsSuccess)
			{
				textBox10.Text = "Result：" + SoftBasic.ByteToHexString(operateResult.Content);
			}
			else
			{
				MessageBox.Show("Read Failed：" + operateResult.ToMessageShowString());
			}
		}

		private void button12_Click(object sender, EventArgs e)
		{
			OperateResult<byte[]> operateResult = melsec_net.ReadRandom(textBox6.Text.Split(new char[1]
			{
				';'
			}, StringSplitOptions.RemoveEmptyEntries), (from m in textBox9.Text.Split(new char[1]
			{
				';'
			}, StringSplitOptions.RemoveEmptyEntries)
			select ushort.Parse(m)).ToArray());
			if (operateResult.IsSuccess)
			{
				textBox10.Text = "Result：" + SoftBasic.ByteToHexString(operateResult.Content);
			}
			else
			{
				MessageBox.Show("Read Failed：" + operateResult.ToMessageShowString());
			}
		}

		private void button26_Click(object sender, EventArgs e)
		{
			OperateResult<byte[]> operateResult = melsec_net.ReadFromCoreServer(SoftBasic.HexStringToBytes(textBox13.Text));
			if (operateResult.IsSuccess)
			{
				textBox11.Text = "Result：" + SoftBasic.ByteToHexString(operateResult.Content);
			}
			else
			{
				MessageBox.Show("Read Failed：" + operateResult.ToMessageShowString());
			}
		}

		private void test1()
		{
			OperateResult<bool[]> operateResult = melsec_net.ReadBool("M100", 10);
			if (operateResult.IsSuccess)
			{
				bool flag = operateResult.Content[0];
				bool flag2 = operateResult.Content[9];
			}
		}

		private void test2()
		{
			bool[] value = new bool[10]
			{
				true,
				false,
				true,
				true,
				false,
				true,
				false,
				true,
				true,
				false
			};
			OperateResult operateResult = melsec_net.Write("M100", value);
			if (!operateResult.IsSuccess)
			{
			}
		}

		private void test3()
		{
			short content = melsec_net.ReadInt16("D100").Content;
			ushort content2 = melsec_net.ReadUInt16("D100").Content;
			int content3 = melsec_net.ReadInt32("D100").Content;
			uint content4 = melsec_net.ReadUInt32("D100").Content;
			long content5 = melsec_net.ReadInt64("D100").Content;
			ulong content6 = melsec_net.ReadUInt64("D100").Content;
			float content7 = melsec_net.ReadFloat("D100").Content;
			double content8 = melsec_net.ReadDouble("D100").Content;
			string content9 = melsec_net.ReadString("D100", 10).Content;
		}

		private void test4()
		{
			melsec_net.Write("D100", (short)5);
			melsec_net.Write("D100", (ushort)5);
			melsec_net.Write("D100", 5);
			melsec_net.Write("D100", 5u);
			melsec_net.Write("D100", 5L);
			melsec_net.Write("D100", 5uL);
			melsec_net.Write("D100", 5f);
			melsec_net.Write("D100", 5.0);
			melsec_net.Write("D100", "12345678");
		}

		private void test5()
		{
			OperateResult<byte[]> operateResult = melsec_net.Read("D100", 10);
			if (operateResult.IsSuccess)
			{
				int num = melsec_net.ByteTransform.TransInt32(operateResult.Content, 0);
				float num2 = melsec_net.ByteTransform.TransSingle(operateResult.Content, 4);
				short num3 = melsec_net.ByteTransform.TransInt16(operateResult.Content, 8);
				string @string = Encoding.ASCII.GetString(operateResult.Content, 10, 10);
			}
		}

		private void test6()
		{
			OperateResult<UserType> operateResult = melsec_net.ReadCustomer<UserType>("D100");
			if (operateResult.IsSuccess)
			{
				UserType content = operateResult.Content;
			}
			melsec_net.WriteCustomer("D100", new UserType());
			melsec_net.LogNet = new LogNetSingle(Application.StartupPath + "\\Logs.txt");
		}

		private void button3_Click(object sender, EventArgs e)
		{
			thread_status = 3;
			failed = 0;
			thread_time_start = DateTime.Now;
			Thread thread = new Thread(thread_test2);
			thread.IsBackground = true;
			thread.Start();
			Thread thread2 = new Thread(thread_test2);
			thread2.IsBackground = true;
			thread2.Start();
			Thread thread3 = new Thread(thread_test2);
			thread3.IsBackground = true;
			thread3.Start();
			button3.Enabled = false;
		}

		[AsyncStateMachine(typeof(_003Cthread_test2_003Ed__25))]
		[DebuggerStepThrough]
		private void thread_test2()
		{
			_003Cthread_test2_003Ed__25 stateMachine = new _003Cthread_test2_003Ed__25();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void thread_end()
		{
			if (Interlocked.Decrement(ref thread_status) == 0)
			{
				Invoke((Action)delegate
				{
					button3.Enabled = true;
					MessageBox.Show("Spend：" + (DateTime.Now - thread_time_start).TotalSeconds.ToString() + Environment.NewLine + " Failed Count：" + failed.ToString());
				});
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = melsec_net.RemoteRun();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Run Success");
			}
			else
			{
				MessageBox.Show("Failed: " + operateResult.ToMessageShowString());
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = melsec_net.RemoteStop();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Stop Success");
			}
			else
			{
				MessageBox.Show("Failed: " + operateResult.ToMessageShowString());
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton6_Click_003Ed__29))]
		[DebuggerStepThrough]
		private void button6_Click(object sender, EventArgs e)
		{
			_003Cbutton6_Click_003Ed__29 stateMachine = new _003Cbutton6_Click_003Ed__29();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = melsec_net.RemoteReset();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("RemoteReset Success");
			}
			else
			{
				MessageBox.Show("Failed: " + operateResult.ToMessageShowString());
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = melsec_net.ErrorStateReset();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("ErrorStateReset Success");
			}
			else
			{
				MessageBox.Show("Failed: " + operateResult.ToMessageShowString());
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton10_Click_003Ed__32))]
		[DebuggerStepThrough]
		private void button10_Click(object sender, EventArgs e)
		{
			_003Cbutton10_Click_003Ed__32 stateMachine = new _003Cbutton10_Click_003Ed__32();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton11_Click_003Ed__33))]
		[DebuggerStepThrough]
		private void button11_Click(object sender, EventArgs e)
		{
			_003Cbutton11_Click_003Ed__33 stateMachine = new _003Cbutton11_Click_003Ed__33();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox_ip.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox_port.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox_ip.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox_port.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
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
			checkBox1 = new System.Windows.Forms.CheckBox();
			label22 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox_port = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox_ip = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox5 = new System.Windows.Forms.GroupBox();
			button11 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			button10 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			button7 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			groupBox4 = new System.Windows.Forms.GroupBox();
			textBox11 = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			button26 = new System.Windows.Forms.Button();
			textBox13 = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			button12 = new System.Windows.Forms.Button();
			button9 = new System.Windows.Forms.Button();
			textBox10 = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			button25 = new System.Windows.Forms.Button();
			textBox9 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox5.SuspendLayout();
			groupBox4.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(checkBox1);
			panel1.Controls.Add(label22);
			panel1.Controls.Add(label21);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox_port);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox_ip);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 42);
			panel1.TabIndex = 0;
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(381, 10);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(93, 21);
			checkBox1.TabIndex = 8;
			checkBox1.Text = "MQTT中转?";
			checkBox1.UseVisualStyleBackColor = true;
			label22.Location = new System.Drawing.Point(776, 1);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(197, 45);
			label22.TabIndex = 7;
			label22.Text = "M100 D100 X1A0 Y1A0 详细说明参照博客 X012就表示八进制";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(702, 1);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(68, 17);
			label21.TabIndex = 6;
			label21.Text = "地址示例：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(584, 5);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(477, 5);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox_port.Location = new System.Drawing.Point(274, 8);
			textBox_port.Name = "textBox_port";
			textBox_port.Size = new System.Drawing.Size(90, 23);
			textBox_port.TabIndex = 3;
			textBox_port.Text = "6000";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(220, 11);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox_ip.Location = new System.Drawing.Point(62, 8);
			textBox_ip.Name = "textBox_ip";
			textBox_ip.Size = new System.Drawing.Size(151, 23);
			textBox_ip.TabIndex = 1;
			textBox_ip.Text = "192.168.0.100";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 11);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteOp1);
			panel2.Controls.Add(groupBox5);
			panel2.Controls.Add(groupBox4);
			panel2.Controls.Add(groupBox3);
			panel2.Location = new System.Drawing.Point(3, 81);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 561);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlReadWriteOp1.Location = new System.Drawing.Point(1, 2);
			userControlReadWriteOp1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(991, 235);
			userControlReadWriteOp1.TabIndex = 27;
			groupBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox5.Controls.Add(button11);
			groupBox5.Controls.Add(button6);
			groupBox5.Controls.Add(button10);
			groupBox5.Controls.Add(textBox3);
			groupBox5.Controls.Add(button7);
			groupBox5.Controls.Add(button8);
			groupBox5.Controls.Add(button3);
			groupBox5.Controls.Add(button4);
			groupBox5.Controls.Add(button5);
			groupBox5.Location = new System.Drawing.Point(573, 243);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(419, 313);
			groupBox5.TabIndex = 26;
			groupBox5.TabStop = false;
			groupBox5.Text = "特殊功能测试";
			button11.Location = new System.Drawing.Point(210, 92);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(194, 28);
			button11.TabIndex = 28;
			button11.Text = "Wait D100 123";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			button6.Location = new System.Drawing.Point(16, 57);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(92, 28);
			button6.TabIndex = 24;
			button6.Text = "plc type";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button10.Location = new System.Drawing.Point(16, 92);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(190, 28);
			button10.TabIndex = 27;
			button10.Text = "Wait M100 True";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(button10_Click);
			textBox3.Location = new System.Drawing.Point(16, 127);
			textBox3.Multiline = true;
			textBox3.Name = "textBox3";
			textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox3.Size = new System.Drawing.Size(388, 145);
			textBox3.TabIndex = 26;
			button7.Location = new System.Drawing.Point(16, 24);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(92, 28);
			button7.TabIndex = 24;
			button7.Text = "remote reset";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			button8.Location = new System.Drawing.Point(114, 24);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(92, 28);
			button8.TabIndex = 25;
			button8.Text = "error reset";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			button3.Location = new System.Drawing.Point(220, 278);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(184, 28);
			button3.TabIndex = 21;
			button3.Text = "压力测试，快速读写3000次";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button4.Location = new System.Drawing.Point(212, 24);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(86, 28);
			button4.TabIndex = 22;
			button4.Text = "remote run";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button5.Location = new System.Drawing.Point(310, 24);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(94, 28);
			button5.TabIndex = 23;
			button5.Text = "remote stop";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			groupBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox4.Controls.Add(textBox11);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(button26);
			groupBox4.Controls.Add(textBox13);
			groupBox4.Controls.Add(label16);
			groupBox4.Location = new System.Drawing.Point(1, 403);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(566, 153);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "报文读取测试，此处需要填入完整的16进制报文字符串";
			textBox11.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox11.Location = new System.Drawing.Point(63, 60);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox11.Size = new System.Drawing.Size(497, 87);
			textBox11.TabIndex = 10;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(9, 62);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 9;
			label14.Text = "结果：";
			button26.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button26.Location = new System.Drawing.Point(478, 24);
			button26.Name = "button26";
			button26.Size = new System.Drawing.Size(82, 28);
			button26.TabIndex = 8;
			button26.Text = "报文读取";
			button26.UseVisualStyleBackColor = true;
			button26.Click += new System.EventHandler(button26_Click);
			textBox13.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox13.Location = new System.Drawing.Point(63, 27);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(409, 23);
			textBox13.TabIndex = 5;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(9, 30);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(44, 17);
			label16.TabIndex = 4;
			label16.Text = "报文：";
			groupBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox3.Controls.Add(button12);
			groupBox3.Controls.Add(button9);
			groupBox3.Controls.Add(textBox10);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(button25);
			groupBox3.Controls.Add(textBox9);
			groupBox3.Controls.Add(label12);
			groupBox3.Controls.Add(textBox6);
			groupBox3.Controls.Add(label11);
			groupBox3.Location = new System.Drawing.Point(1, 243);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(566, 154);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试";
			button12.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button12.Location = new System.Drawing.Point(407, 24);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(77, 28);
			button12.TabIndex = 26;
			button12.Text = "读块";
			button12.UseVisualStyleBackColor = true;
			button12.Click += new System.EventHandler(button12_Click);
			button9.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button9.Location = new System.Drawing.Point(327, 24);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(77, 28);
			button9.TabIndex = 25;
			button9.Text = "随机读字";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			textBox10.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox10.Location = new System.Drawing.Point(63, 60);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(497, 88);
			textBox10.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 62);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "结果：";
			button25.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button25.Location = new System.Drawing.Point(488, 24);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(72, 28);
			button25.TabIndex = 8;
			button25.Text = "批量读取";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			textBox9.Location = new System.Drawing.Point(222, 27);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(99, 23);
			textBox9.TabIndex = 7;
			textBox9.Text = "10";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(182, 30);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(44, 17);
			label12.TabIndex = 6;
			label12.Text = "长度：";
			textBox6.Location = new System.Drawing.Point(63, 27);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(116, 23);
			textBox6.TabIndex = 5;
			textBox6.Text = "D100";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(9, 30);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 4;
			label11.Text = "地址：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7469679.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "MC Qna3E Binary";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.SupportListVisiable = true;
			userControlHead1.TabIndex = 2;
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
			base.Name = "FormMelsecBinary";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "三菱PLC访问Demo";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			ResumeLayout(false);
		}
	}
}
