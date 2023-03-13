using HslCommunication;
using HslCommunication.Enthernet;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormSimplifyNet : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003CButton7_Click_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSimplifyNet _003C_003E4__this;

			private NetHandle _003Chandle_003E5__1;

			private int _003Ccount_003E5__2;

			private DateTime _003Cstart_003E5__3;

			private string[] _003Cvalues_003E5__4;

			private int _003Ci_003E5__5;

			private OperateResult<NetHandle, string[]> _003Cread_003E5__6;

			private OperateResult<NetHandle, string[]> _003C_003Es__7;

			private TaskAwaiter<OperateResult<NetHandle, string[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<NetHandle, string[]>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<NetHandle, string[]>>);
						num = (_003C_003E1__state = -1);
						goto IL_017f;
					}
					_003Chandle_003E5__1 = default(NetHandle);
					if (_003C_003E4__this.textBox5.Text.IndexOf('.') >= 0)
					{
						_003Cvalues_003E5__4 = _003C_003E4__this.textBox5.Text.Split('.');
						_003Chandle_003E5__1 = new NetHandle(byte.Parse(_003Cvalues_003E5__4[0]), byte.Parse(_003Cvalues_003E5__4[1]), ushort.Parse(_003Cvalues_003E5__4[2]));
						_003Cvalues_003E5__4 = null;
					}
					else
					{
						_003Chandle_003E5__1 = int.Parse(_003C_003E4__this.textBox5.Text);
					}
					_003Ccount_003E5__2 = int.Parse(_003C_003E4__this.textBox6.Text);
					_003Cstart_003E5__3 = DateTime.Now;
					_003Ci_003E5__5 = 0;
					goto IL_0216;
					IL_0216:
					if (_003Ci_003E5__5 < _003Ccount_003E5__2)
					{
						awaiter = _003C_003E4__this.simplifyClient.ReadCustomerFromServerAsync(_003Chandle_003E5__1, _003C_003E4__this.textBox4.Text.Split(';')).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CButton7_Click_003Ed__10 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_017f;
					}
					_003C_003E4__this.textBox7.Text = (DateTime.Now - _003Cstart_003E5__3).TotalMilliseconds.ToString("F2");
					goto end_IL_0007;
					IL_017f:
					_003C_003Es__7 = awaiter.GetResult();
					_003Cread_003E5__6 = _003C_003Es__7;
					_003C_003Es__7 = null;
					if (_003Cread_003E5__6.IsSuccess)
					{
						_003C_003E4__this.textBox8.Lines = _003Cread_003E5__6.Content2;
					}
					else
					{
						MessageBox.Show((Program.Language == 1) ? "读取失败：" : ("Read Failed:" + _003Cread_003E5__6.ToMessageShowString()));
					}
					_003Cread_003E5__6 = null;
					_003Ci_003E5__5++;
					goto IL_0216;
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
		private sealed class _003Cbutton1_Click_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSimplifyNet _003C_003E4__this;

			private OperateResult _003Cconnect_003E5__1;

			private OperateResult _003C_003Es__2;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					if (num != 0)
					{
						_003C_003E4__this.simplifyClient.IpAddress = _003C_003E4__this.textBox1.Text;
						_003C_003E4__this.simplifyClient.Port = int.Parse(_003C_003E4__this.textBox2.Text);
						_003C_003E4__this.simplifyClient.ReceiveTimeOut = int.Parse(_003C_003E4__this.textBox11.Text);
						_003C_003E4__this.simplifyClient.Token = new Guid(_003C_003E4__this.textBox3.Text);
						_003C_003E4__this.simplifyClient.SetLoginAccount(_003C_003E4__this.textBox9.Text, _003C_003E4__this.textBox10.Text);
						awaiter = _003C_003E4__this.simplifyClient.ConnectServerAsync().GetAwaiter();
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
					_003C_003Es__2 = awaiter.GetResult();
					_003Cconnect_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cconnect_003E5__1.IsSuccess)
					{
						_003C_003E4__this.button1.Enabled = false;
						_003C_003E4__this.button2.Enabled = true;
						_003C_003E4__this.panel2.Enabled = true;
						_003C_003E4__this.button5.Enabled = false;
						MessageBox.Show(StringResources.Language.ConnectServerSuccess);
					}
					else
					{
						MessageBox.Show(StringResources.Language.ConnectedFailed + _003Cconnect_003E5__1.ToMessageShowString());
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cconnect_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cconnect_003E5__1 = null;
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
		private sealed class _003Cbutton2_Click_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSimplifyNet _003C_003E4__this;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					if (num != 0)
					{
						_003C_003E4__this.button5.Enabled = true;
						_003C_003E4__this.button1.Enabled = true;
						_003C_003E4__this.button2.Enabled = false;
						_003C_003E4__this.panel2.Enabled = false;
						awaiter = _003C_003E4__this.simplifyClient.ConnectCloseAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton2_Click_003Ed__5 stateMachine = this;
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
					awaiter.GetResult();
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
		private sealed class _003Cbutton3_Click_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSimplifyNet _003C_003E4__this;

			private NetHandle _003Chandle_003E5__1;

			private int _003Ccount_003E5__2;

			private DateTime _003Cstart_003E5__3;

			private string[] _003Cvalues_003E5__4;

			private int _003Ci_003E5__5;

			private OperateResult<string> _003Cread_003E5__6;

			private OperateResult<string> _003C_003Es__7;

			private TaskAwaiter<OperateResult<string>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<string>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<string>>);
						num = (_003C_003E1__state = -1);
						goto IL_0181;
					}
					_003C_003E4__this.button3.Enabled = false;
					_003Chandle_003E5__1 = default(NetHandle);
					if (_003C_003E4__this.textBox5.Text.IndexOf('.') >= 0)
					{
						_003Cvalues_003E5__4 = _003C_003E4__this.textBox5.Text.Split('.');
						_003Chandle_003E5__1 = new NetHandle(byte.Parse(_003Cvalues_003E5__4[0]), byte.Parse(_003Cvalues_003E5__4[1]), ushort.Parse(_003Cvalues_003E5__4[2]));
						_003Cvalues_003E5__4 = null;
					}
					else
					{
						_003Chandle_003E5__1 = int.Parse(_003C_003E4__this.textBox5.Text);
					}
					_003Ccount_003E5__2 = int.Parse(_003C_003E4__this.textBox6.Text);
					_003Cstart_003E5__3 = DateTime.Now;
					_003Ci_003E5__5 = 0;
					goto IL_0222;
					IL_0222:
					if (_003Ci_003E5__5 < _003Ccount_003E5__2)
					{
						awaiter = _003C_003E4__this.simplifyClient.ReadFromServerAsync(_003Chandle_003E5__1, _003C_003E4__this.textBox4.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton3_Click_003Ed__8 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_0181;
					}
					_003C_003E4__this.textBox7.Text = (DateTime.Now - _003Cstart_003E5__3).TotalMilliseconds.ToString("F2");
					_003C_003E4__this.button3.Enabled = true;
					goto end_IL_0007;
					IL_0181:
					_003C_003Es__7 = awaiter.GetResult();
					_003Cread_003E5__6 = _003C_003Es__7;
					_003C_003Es__7 = null;
					if (_003Cread_003E5__6.IsSuccess)
					{
						_003C_003E4__this.textBox8.AppendText(_003Cread_003E5__6.Content + Environment.NewLine);
					}
					else
					{
						MessageBox.Show((Program.Language == 1) ? "读取失败：" : ("Read Failed:" + _003Cread_003E5__6.ToMessageShowString()));
					}
					_003Cread_003E5__6 = null;
					_003Ci_003E5__5++;
					goto IL_0222;
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
		private sealed class _003Cthread_test2_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public FormSimplifyNet _003C_003E4__this;

			private int _003Ccount_003E5__1;

			private OperateResult<NetHandle, string> _003C_003Es__2;

			private TaskAwaiter<OperateResult<NetHandle, string>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<NetHandle, string>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<NetHandle, string>>);
						num = (_003C_003E1__state = -1);
						goto IL_008d;
					}
					_003Ccount_003E5__1 = 1000;
					goto IL_00de;
					IL_008d:
					_003C_003Es__2 = awaiter.GetResult();
					if (!_003C_003Es__2.IsSuccess)
					{
						_003C_003Es__2 = null;
						_003C_003E4__this.failed++;
					}
					_003Ccount_003E5__1--;
					goto IL_00de;
					IL_00de:
					if (_003Ccount_003E5__1 > 0)
					{
						awaiter = _003C_003E4__this.simplifyClient.ReadCustomerFromServerAsync(1, "").GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cthread_test2_003Ed__16 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_008d;
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

		private NetSimplifyClient simplifyClient = new NetSimplifyClient();

		private int status = 1;

		private int thread_status = 0;

		private int failed = 0;

		private DateTime thread_time_start = DateTime.Now;

		private IContainer components = null;

		private Panel panel1;

		private TextBox textBox3;

		private Label label6;

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

		private TextBox textBox7;

		private Label label11;

		private TextBox textBox6;

		private Label label10;

		private Button button3;

		private TextBox textBox4;

		private Label label9;

		private Label label8;

		private TextBox textBox5;

		private Label label7;

		private Button button5;

		private Button button6;

		private UserControlHead userControlHead1;

		private Button button7;

		private TextBox textBox10;

		private Label label4;

		private TextBox textBox9;

		private Label label2;

		private TextBox textBox11;

		private Label label5;

		public FormSimplifyNet()
		{
			InitializeComponent();
		}

		private void FormClient_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			textBox3.Text = Guid.Empty.ToString();
			button2.Enabled = false;
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language == 1)
			{
				Text = "Simplify网络客户端";
				label1.Text = "Ip地址：";
				label3.Text = "端口号：";
				button1.Text = "连接";
				button2.Text = "断开连接";
				label6.Text = "令牌：";
				button5.Text = "启动短连接";
				button6.Text = "压力测试";
				label7.Text = "指令头：";
				label8.Text = "举例：12345 或是1.1.1";
				label9.Text = "数据：";
				button3.Text = "发送";
				label10.Text = "次数：";
				label11.Text = "耗时：";
				button4.Text = "清空";
				label12.Text = "接收：";
			}
			else
			{
				Text = "Simplify Net Client Test";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label6.Text = "Token:";
				button5.Text = "Start a short connection";
				button6.Text = "Pressure test";
				label7.Text = "Command:";
				label8.Text = "Example: 12345 or 1.1.1";
				label9.Text = "Data:";
				button3.Text = "Send";
				label10.Text = "Times:";
				label11.Text = "Take:";
				button4.Text = "Clear";
				label12.Text = "Receive:";
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

		[AsyncStateMachine(typeof(_003Cbutton2_Click_003Ed__5))]
		[DebuggerStepThrough]
		private void button2_Click(object sender, EventArgs e)
		{
			_003Cbutton2_Click_003Ed__5 stateMachine = new _003Cbutton2_Click_003Ed__5();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (status == 1)
			{
				simplifyClient.IpAddress = textBox1.Text;
				simplifyClient.Port = int.Parse(textBox2.Text);
				simplifyClient.Token = new Guid(textBox3.Text);
				button1.Enabled = false;
				button2.Enabled = false;
				panel2.Enabled = true;
				status = 2;
				button5.Text = ((Program.Language == 1) ? "重新选择连接" : "Choose again");
			}
			else
			{
				status = 1;
				button1.Enabled = true;
				panel2.Enabled = false;
				button5.Text = ((Program.Language == 1) ? "启动短连接" : "Start a short connection");
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

		[AsyncStateMachine(typeof(_003CButton7_Click_003Ed__10))]
		[DebuggerStepThrough]
		private void Button7_Click(object sender, EventArgs e)
		{
			_003CButton7_Click_003Ed__10 stateMachine = new _003CButton7_Click_003Ed__10();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			PressureTest2();
		}

		private void PressureTest2()
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

		[AsyncStateMachine(typeof(_003Cthread_test2_003Ed__16))]
		[DebuggerStepThrough]
		private void thread_test2()
		{
			_003Cthread_test2_003Ed__16 stateMachine = new _003Cthread_test2_003Ed__16();
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
					MessageBox.Show("Spend：" + (DateTime.Now - thread_time_start).TotalSeconds.ToString() + Environment.NewLine + " Read Failed：" + failed.ToString());
				});
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlTimeout, textBox11.Text);
			element.SetAttributeValue(DemoDeviceList.XmlToken, textBox3.Text);
			element.SetAttributeValue(DemoDeviceList.XmlUserName, textBox9.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPassword, textBox10.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox11.Text = element.Attribute(DemoDeviceList.XmlTimeout).Value;
			textBox3.Text = element.Attribute(DemoDeviceList.XmlToken).Value;
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
			textBox11 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			textBox10 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox9 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			button7 = new System.Windows.Forms.Button();
			textBox8 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			button4 = new System.Windows.Forms.Button();
			textBox7 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox11);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(textBox10);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(textBox9);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(button6);
			panel1.Controls.Add(button5);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(15, 43);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(978, 72);
			panel1.TabIndex = 7;
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
			textBox10.Location = new System.Drawing.Point(572, 41);
			textBox10.Name = "textBox10";
			textBox10.Size = new System.Drawing.Size(91, 23);
			textBox10.TabIndex = 13;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(508, 44);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(44, 17);
			label4.TabIndex = 12;
			label4.Text = "密码：";
			textBox9.Location = new System.Drawing.Point(401, 41);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(91, 23);
			textBox9.TabIndex = 11;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(337, 44);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(56, 17);
			label2.TabIndex = 10;
			label2.Text = "用户名：";
			button6.Location = new System.Drawing.Point(798, 39);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(168, 28);
			button6.TabIndex = 9;
			button6.Text = "压力测试";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button5.Location = new System.Drawing.Point(798, 5);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(168, 28);
			button5.TabIndex = 8;
			button5.Text = "启动短连接";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			textBox3.Location = new System.Drawing.Point(62, 41);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(265, 23);
			textBox3.TabIndex = 7;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(8, 44);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(44, 17);
			label6.TabIndex = 6;
			label6.Text = "令牌：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(701, 5);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(604, 5);
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
			textBox2.Text = "12345";
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
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(button7);
			panel2.Controls.Add(textBox8);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(button4);
			panel2.Controls.Add(textBox7);
			panel2.Controls.Add(label11);
			panel2.Controls.Add(textBox6);
			panel2.Controls.Add(label10);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label9);
			panel2.Controls.Add(label8);
			panel2.Controls.Add(textBox5);
			panel2.Controls.Add(label7);
			panel2.Location = new System.Drawing.Point(15, 122);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(977, 518);
			panel2.TabIndex = 13;
			button7.Location = new System.Drawing.Point(159, 180);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(148, 28);
			button7.TabIndex = 20;
			button7.Text = "Send Array";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(Button7_Click);
			textBox8.Location = new System.Drawing.Point(62, 214);
			textBox8.Multiline = true;
			textBox8.Name = "textBox8";
			textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox8.Size = new System.Drawing.Size(892, 292);
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
			button4.Click += new System.EventHandler(button4_Click);
			textBox7.Location = new System.Drawing.Point(618, 183);
			textBox7.Name = "textBox7";
			textBox7.ReadOnly = true;
			textBox7.Size = new System.Drawing.Size(141, 23);
			textBox7.TabIndex = 16;
			textBox7.Text = "0";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(564, 186);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 15;
			label11.Text = "耗时：";
			textBox6.Location = new System.Drawing.Point(403, 183);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(141, 23);
			textBox6.TabIndex = 14;
			textBox6.Text = "1";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(349, 186);
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
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7697782.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Hsl - Simplify";
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
			base.Name = "FormSimplifyNet";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Simplify网络客户端";
			base.Load += new System.EventHandler(FormClient_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
