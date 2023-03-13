using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Profinet.Siemens;
using HslCommunicationDemo.DemoControl;
using Newtonsoft.Json.Linq;
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
	public class FormSiemensWebApi : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003CButton7_Click_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemensWebApi _003C_003E4__this;

			private OperateResult<DateTime> _003Cread_003E5__1;

			private OperateResult<DateTime> _003C_003Es__2;

			private TaskAwaiter<OperateResult<DateTime>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<DateTime>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.siemensTcpNet.ReadDateTimeAsync(_003C_003E4__this.textBox8.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CButton7_Click_003Ed__7 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<DateTime>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox7.Text = _003Cread_003E5__1.Content.ToString();
					}
					else
					{
						MessageBox.Show("Failed:" + _003Cread_003E5__1.Message);
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cread_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cread_003E5__1 = null;
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
		private sealed class _003CButton8_Click_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemensWebApi _003C_003E4__this;

			private DateTime _003Cvalue_003E5__1;

			private OperateResult _003C_003Es__2;

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
						goto IL_00a9;
					}
					if (DateTime.TryParse(_003C_003E4__this.textBox7.Text, out _003Cvalue_003E5__1))
					{
						awaiter = _003C_003E4__this.siemensTcpNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CButton8_Click_003Ed__8 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_00a9;
					}
					MessageBox.Show("DateTime Data is not corrent: " + _003C_003E4__this.textBox7.Text);
					goto end_IL_0007;
					IL_00a9:
					_003C_003Es__2 = awaiter.GetResult();
					DemoUtils.WriteResultRender(_003C_003Es__2, _003C_003E4__this.textBox8.Text);
					_003C_003Es__2 = null;
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
		private sealed class _003Cbutton3_Click_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemensWebApi _003C_003E4__this;

			private OperateResult<JToken[]> _003Cread_003E5__1;

			private OperateResult<JToken[]> _003C_003Es__2;

			private JArray _003Cjson_003E5__3;

			private int _003Ci_003E5__4;

			private TaskAwaiter<OperateResult<JToken[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<JToken[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.siemensTcpNet.ReadAsync(_003C_003E4__this.textBox6.Text.Split(new char[1]
						{
							';'
						}, StringSplitOptions.RemoveEmptyEntries)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton3_Click_003Ed__10 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<JToken[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed：" + _003Cread_003E5__1.ToMessageShowString());
					}
					else
					{
						_003Cjson_003E5__3 = new JArray();
						_003Ci_003E5__4 = 0;
						while (_003Ci_003E5__4 < _003Cread_003E5__1.Content.Length)
						{
							_003Cjson_003E5__3.Add(_003Cread_003E5__1.Content[_003Ci_003E5__4]);
							_003Ci_003E5__4++;
						}
						_003C_003E4__this.textBox10.Text = _003Cjson_003E5__3.ToString();
						_003Cjson_003E5__3 = null;
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cread_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cread_003E5__1 = null;
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
		private sealed class _003Cbutton4_Click_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemensWebApi _003C_003E4__this;

			private OperateResult<double> _003Cread_003E5__1;

			private OperateResult<double> _003C_003Es__2;

			private TaskAwaiter<OperateResult<double>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<double>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.siemensTcpNet.ReadVersionAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton4_Click_003Ed__23 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<double>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show(_003Cread_003E5__1.Content.ToString());
					}
					else
					{
						MessageBox.Show("Read Failed: " + _003Cread_003E5__1.ToMessageShowString());
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cread_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cread_003E5__1 = null;
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
		private sealed class _003Cbutton5_Click_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemensWebApi _003C_003E4__this;

			private OperateResult _003Cread_003E5__1;

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
						awaiter = _003C_003E4__this.siemensTcpNet.ReadPingAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton5_Click_003Ed__24 stateMachine = this;
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
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Ping Success");
					}
					else
					{
						MessageBox.Show("Read Failed: " + _003Cread_003E5__1.ToMessageShowString());
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cread_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cread_003E5__1 = null;
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
		private sealed class _003Cthread_test1_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public FormSiemensWebApi _003C_003E4__this;

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
						_003Ccount_003E5__1 = 100000;
						goto IL_01ab;
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
						IL_01ab:
						if (_003Ccount_003E5__1 <= 0)
						{
							break;
						}
						awaiter2 = _003C_003E4__this.siemensTcpNet.WriteAsync("M100", (short)1234).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003Cthread_test1_003Ed__18 stateMachine = this;
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
						awaiter = _003C_003E4__this.siemensTcpNet.ReadInt16Async("M100").GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003Cthread_test1_003Ed__18 stateMachine = this;
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
						_003C_003E4__this.successCount++;
						goto IL_01ab;
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

		private SiemensWebApi siemensTcpNet = null;

		private int thread_status = 0;

		private int failed = 0;

		private DateTime thread_time_start = DateTime.Now;

		private long successCount = 0L;

		private System.Windows.Forms.Timer timer;

		private IContainer components = null;

		private Panel panel1;

		private Label label1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private GroupBox groupBox3;

		private TextBox textBox10;

		private Label label13;

		private Button button25;

		private TextBox textBox6;

		private Label label11;

		private TextBox textBox7;

		private Label label9;

		private TextBox textBox8;

		private Label label10;

		private Label label19;

		private Button button3;

		private TextBox textBox16;

		private Label label24;

		private TextBox textBox15;

		private Label label23;

		protected UserControlHead userControlHead1;

		private Button button8;

		private Button button7;

		private GroupBox groupBox5;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private Button button9;

		private Label label2;

		private Button button4;

		private Button button5;

		public FormSiemensWebApi()
		{
			InitializeComponent();
			siemensTcpNet = new SiemensWebApi();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "Siemens Read PLC Demo";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				button7.Text = "r-time";
				label11.Text = "Address:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				label10.Text = "Address:";
				label9.Text = "Value:";
				label19.Text = "Note: The value of the string needs to be converted";
				button8.Text = "w-time";
				groupBox3.Text = "Bulk Read test";
				groupBox5.Text = "Special function test";
				button3.Text = "Order";
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show(DemoUtils.PortInputWrong);
			}
			else
			{
				siemensTcpNet.IpAddress = textBox1.Text;
				siemensTcpNet.Port = result;
				siemensTcpNet.LogNet = base.LogNet;
				try
				{
					siemensTcpNet.UserName = textBox15.Text;
					siemensTcpNet.Password = textBox16.Text;
					OperateResult operateResult = siemensTcpNet.ConnectServer();
					if (operateResult.IsSuccess)
					{
						MessageBox.Show(StringResources.Language.ConnectedSuccess);
						button2.Enabled = true;
						button1.Enabled = false;
						panel2.Enabled = true;
						userControlReadWriteOp1.SetReadWriteNet(siemensTcpNet, "\"全局DB\".Static_14");
					}
					else
					{
						MessageBox.Show(StringResources.Language.ConnectedFailed + operateResult.Message);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			siemensTcpNet.ConnectClose();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		[AsyncStateMachine(typeof(_003CButton7_Click_003Ed__7))]
		[DebuggerStepThrough]
		private void Button7_Click(object sender, EventArgs e)
		{
			_003CButton7_Click_003Ed__7 stateMachine = new _003CButton7_Click_003Ed__7();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CButton8_Click_003Ed__8))]
		[DebuggerStepThrough]
		private void Button8_Click(object sender, EventArgs e)
		{
			_003CButton8_Click_003Ed__8 stateMachine = new _003CButton8_Click_003Ed__8();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button25_Click(object sender, EventArgs e)
		{
			try
			{
				OperateResult<byte[]> operateResult = siemensTcpNet.Read(textBox6.Text, 0);
				if (operateResult.IsSuccess)
				{
					textBox10.Text = "Result：" + SoftBasic.ByteToHexString(operateResult.Content);
				}
				else
				{
					MessageBox.Show("Read Failed：" + operateResult.ToMessageShowString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Read Failed：" + ex.Message);
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton3_Click_003Ed__10))]
		[DebuggerStepThrough]
		private void button3_Click(object sender, EventArgs e)
		{
			_003Cbutton3_Click_003Ed__10 stateMachine = new _003Cbutton3_Click_003Ed__10();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button9_Click(object sender, EventArgs e)
		{
			thread_status = 3;
			failed = 0;
			thread_time_start = DateTime.Now;
			Thread thread = new Thread(thread_test1);
			thread.IsBackground = true;
			thread.Start();
			Thread thread2 = new Thread(thread_test1);
			thread2.IsBackground = true;
			thread2.Start();
			Thread thread3 = new Thread(thread_test1);
			thread3.IsBackground = true;
			thread3.Start();
			button9.Enabled = false;
			timer = new System.Windows.Forms.Timer();
			timer.Interval = 1000;
			timer.Tick += Timer_Tick;
			timer.Start();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			label2.Text = successCount.ToString();
		}

		[AsyncStateMachine(typeof(_003Cthread_test1_003Ed__18))]
		[DebuggerStepThrough]
		private void thread_test1()
		{
			_003Cthread_test1_003Ed__18 stateMachine = new _003Cthread_test1_003Ed__18();
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
					label2.Text = successCount.ToString();
					timer.Stop();
					button9.Enabled = true;
					MessageBox.Show("Spend：" + (DateTime.Now - thread_time_start).TotalSeconds.ToString() + Environment.NewLine + " Failed Count：" + failed.ToString());
				});
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlUserName, textBox15.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPassword, textBox16.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox15.Text = element.Attribute(DemoDeviceList.XmlUserName).Value;
			textBox16.Text = element.Attribute(DemoDeviceList.XmlPassword).Value;
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
		}

		[AsyncStateMachine(typeof(_003Cbutton4_Click_003Ed__23))]
		[DebuggerStepThrough]
		private void button4_Click(object sender, EventArgs e)
		{
			_003Cbutton4_Click_003Ed__23 stateMachine = new _003Cbutton4_Click_003Ed__23();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton5_Click_003Ed__24))]
		[DebuggerStepThrough]
		private void button5_Click(object sender, EventArgs e)
		{
			_003Cbutton5_Click_003Ed__24 stateMachine = new _003Cbutton5_Click_003Ed__24();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
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
			textBox16 = new System.Windows.Forms.TextBox();
			label24 = new System.Windows.Forms.Label();
			textBox15 = new System.Windows.Forms.TextBox();
			label23 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox5 = new System.Windows.Forms.GroupBox();
			button5 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			button9 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			label19 = new System.Windows.Forms.Label();
			textBox7 = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			textBox8 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			button3 = new System.Windows.Forms.Button();
			textBox10 = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			button25 = new System.Windows.Forms.Button();
			textBox6 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox5.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox16);
			panel1.Controls.Add(label24);
			panel1.Controls.Add(textBox15);
			panel1.Controls.Add(label23);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 54);
			panel1.TabIndex = 0;
			textBox16.Location = new System.Drawing.Point(494, 15);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(77, 23);
			textBox16.TabIndex = 11;
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(448, 18);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(45, 17);
			label24.TabIndex = 10;
			label24.Text = "pwd：";
			textBox15.Location = new System.Drawing.Point(366, 15);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(76, 23);
			textBox15.TabIndex = 9;
			textBox15.Text = "admin";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(317, 18);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(52, 17);
			label23.TabIndex = 8;
			label23.Text = "name：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(728, 10);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(632, 10);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(238, 15);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(61, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "443";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(184, 18);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 15);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(116, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "192.168.0.100";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 18);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteOp1);
			panel2.Controls.Add(groupBox5);
			panel2.Controls.Add(groupBox3);
			panel2.Location = new System.Drawing.Point(3, 92);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 550);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Location = new System.Drawing.Point(3, 2);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(989, 240);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox5.Controls.Add(button5);
			groupBox5.Controls.Add(button4);
			groupBox5.Controls.Add(label2);
			groupBox5.Controls.Add(button9);
			groupBox5.Controls.Add(button8);
			groupBox5.Controls.Add(button7);
			groupBox5.Controls.Add(label19);
			groupBox5.Controls.Add(textBox7);
			groupBox5.Controls.Add(label10);
			groupBox5.Controls.Add(textBox8);
			groupBox5.Controls.Add(label9);
			groupBox5.Location = new System.Drawing.Point(573, 243);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(419, 302);
			groupBox5.TabIndex = 4;
			groupBox5.TabStop = false;
			groupBox5.Text = "特殊功能测试";
			button5.Location = new System.Drawing.Point(137, 138);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(107, 30);
			button5.TabIndex = 25;
			button5.Text = "Ping";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			button4.Location = new System.Drawing.Point(24, 138);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(107, 30);
			button4.TabIndex = 24;
			button4.Text = "Version";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(123, 250);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(15, 17);
			label2.TabIndex = 23;
			label2.Text = "0";
			button9.Location = new System.Drawing.Point(24, 244);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(82, 28);
			button9.TabIndex = 22;
			button9.Text = "压力测试";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			button8.Location = new System.Drawing.Point(320, 27);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(82, 28);
			button8.TabIndex = 21;
			button8.Text = "time写入";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(Button8_Click);
			button7.Location = new System.Drawing.Point(232, 27);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(82, 28);
			button7.TabIndex = 17;
			button7.Text = "time读取";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(Button7_Click);
			label19.ForeColor = System.Drawing.Color.Red;
			label19.Location = new System.Drawing.Point(58, 89);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(147, 58);
			label19.TabIndex = 17;
			label19.Text = "注意：值的字符串需要能转化成对应的数据类型";
			textBox7.Location = new System.Drawing.Point(74, 63);
			textBox7.Name = "textBox7";
			textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox7.Size = new System.Drawing.Size(152, 23);
			textBox7.TabIndex = 5;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(6, 33);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(44, 17);
			label10.TabIndex = 2;
			label10.Text = "地址：";
			textBox8.Location = new System.Drawing.Point(74, 30);
			textBox8.Name = "textBox8";
			textBox8.Size = new System.Drawing.Size(152, 23);
			textBox8.TabIndex = 3;
			textBox8.Text = "\"全局DB\".Static_14";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(6, 65);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(32, 17);
			label9.TabIndex = 4;
			label9.Text = "值：";
			groupBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox3.Controls.Add(button3);
			groupBox3.Controls.Add(textBox10);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(button25);
			groupBox3.Controls.Add(textBox6);
			groupBox3.Controls.Add(label11);
			groupBox3.Location = new System.Drawing.Point(3, 243);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(564, 302);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试";
			button3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button3.Location = new System.Drawing.Point(388, 24);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(82, 28);
			button3.TabIndex = 15;
			button3.Text = "批量读取";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox10.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox10.Location = new System.Drawing.Point(63, 60);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(495, 236);
			textBox10.TabIndex = 10;
			textBox10.Text = "批量读取时，多个标签按照 ';' 英文的分号进行分割";
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 62);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "结果：";
			button25.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button25.Location = new System.Drawing.Point(476, 24);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(82, 28);
			button25.TabIndex = 8;
			button25.Text = "原始读取";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			textBox6.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox6.Location = new System.Drawing.Point(63, 27);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(319, 23);
			textBox6.TabIndex = 5;
			textBox6.Text = "\"全局DB\".Static_14";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(9, 30);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 4;
			label11.Text = "地址：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/8685855.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "s1500 web api";
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
			base.Name = "FormSiemensWebApi";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "西门子PLC访问Demo";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			ResumeLayout(false);
		}
	}
}
