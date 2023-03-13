using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core.Net;
using HslCommunication.Profinet.Siemens;
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
	public class FormSiemensDTU : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003CButton7_Click_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemensDTU _003C_003E4__this;

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
							_003CButton7_Click_003Ed__13 stateMachine = this;
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
		private sealed class _003CButton8_Click_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemensDTU _003C_003E4__this;

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
							_003CButton8_Click_003Ed__15 stateMachine = this;
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
		private sealed class _003Cbutton14_Click_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemensDTU _003C_003E4__this;

			private OperateResult _003C_003Es__1;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.siemensTcpNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003C_003E4__this.textBox7.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton14_Click_003Ed__14 stateMachine = this;
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
					_003C_003Es__1 = awaiter.GetResult();
					DemoUtils.WriteResultRender(_003C_003Es__1, _003C_003E4__this.textBox8.Text);
					_003C_003Es__1 = null;
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
		private sealed class _003Cbutton26_Click_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemensDTU _003C_003E4__this;

			private OperateResult<byte[]> _003Cread_003E5__1;

			private OperateResult<byte[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<byte[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<byte[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.siemensTcpNet.ReadFromCoreServerAsync(SoftBasic.HexStringToBytes(_003C_003E4__this.textBox13.Text)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton26_Click_003Ed__18 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<byte[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox11.Text = "Result：" + SoftBasic.ByteToHexString(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed：" + _003Cread_003E5__1.ToMessageShowString());
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
		private sealed class _003Cbutton3_Click_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemensDTU _003C_003E4__this;

			private OperateResult<string> _003Cread_003E5__1;

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
						awaiter = _003C_003E4__this.siemensTcpNet.ReadOrderNumberAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton3_Click_003Ed__17 stateMachine = this;
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
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox10.Text = "Order Number：" + _003Cread_003E5__1.Content;
					}
					else
					{
						MessageBox.Show("Read Failed：" + _003Cread_003E5__1.ToMessageShowString());
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
		private sealed class _003Cbutton4_Click_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemensDTU _003C_003E4__this;

			private OperateResult _003Cresult_003E5__1;

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
						awaiter = _003C_003E4__this.siemensTcpNet.HotStartAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton4_Click_003Ed__19 stateMachine = this;
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
					_003Cresult_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cresult_003E5__1.IsSuccess)
					{
						MessageBox.Show("Success");
					}
					else
					{
						MessageBox.Show("Failed: " + _003Cresult_003E5__1.Message);
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cresult_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cresult_003E5__1 = null;
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
		private sealed class _003Cbutton5_Click_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemensDTU _003C_003E4__this;

			private OperateResult _003Cresult_003E5__1;

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
						awaiter = _003C_003E4__this.siemensTcpNet.ColdStartAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton5_Click_003Ed__20 stateMachine = this;
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
					_003Cresult_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cresult_003E5__1.IsSuccess)
					{
						MessageBox.Show("Success");
					}
					else
					{
						MessageBox.Show("Failed: " + _003Cresult_003E5__1.Message);
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cresult_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cresult_003E5__1 = null;
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
		private sealed class _003Cbutton6_Click_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemensDTU _003C_003E4__this;

			private OperateResult _003Cresult_003E5__1;

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
						awaiter = _003C_003E4__this.siemensTcpNet.StopAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton6_Click_003Ed__21 stateMachine = this;
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
					_003Cresult_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cresult_003E5__1.IsSuccess)
					{
						MessageBox.Show("Success");
					}
					else
					{
						MessageBox.Show("Failed: " + _003Cresult_003E5__1.Message);
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cresult_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cresult_003E5__1 = null;
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
		private sealed class _003Cbutton_read_string_Click_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemensDTU _003C_003E4__this;

			private OperateResult<string> _003Cread_003E5__1;

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
						awaiter = _003C_003E4__this.siemensTcpNet.ReadStringAsync(_003C_003E4__this.textBox8.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_read_string_Click_003Ed__12 stateMachine = this;
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
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox7.Text = _003Cread_003E5__1.Content;
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
		private sealed class _003Cthread_test1_003Ed__29 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public FormSiemensDTU _003C_003E4__this;

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
							_003Cthread_test1_003Ed__29 stateMachine = this;
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
							_003Cthread_test1_003Ed__29 stateMachine = this;
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

		private SiemensS7Net siemensTcpNet = null;

		private SiemensPLCS siemensPLCSelected = SiemensPLCS.S1200;

		private NetworkAlienClient networkAlien = null;

		private int thread_status = 0;

		private int failed = 0;

		private DateTime thread_time_start = DateTime.Now;

		private long successCount = 0L;

		private System.Windows.Forms.Timer timer;

		private IContainer components = null;

		private Panel panel1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

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

		private Button button14;

		private TextBox textBox7;

		private Label label9;

		private TextBox textBox8;

		private Label label10;

		private Button button_read_string;

		private Label label19;

		private Button button3;

		private TextBox textBox16;

		private Label label24;

		private TextBox textBox15;

		private Label label23;

		private Label label25;

		private Button button6;

		private Button button5;

		private Button button4;

		protected UserControlHead userControlHead1;

		private Button button8;

		private Button button7;

		private GroupBox groupBox5;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private Button button9;

		private Label label2;

		private TextBox textBox1;

		private Label label1;

		private Label label22;

		private ComboBox comboBox1;

		public FormSiemensDTU()
		{
			InitializeComponent();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			comboBox1.SelectedIndex = 0;
			panel2.Enabled = false;
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
			Language(Program.Language);
		}

		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			siemensPLCSelected = ((comboBox1.SelectedItem.ToString() == "S1200") ? SiemensPLCS.S1200 : ((comboBox1.SelectedItem.ToString() == "S1500") ? SiemensPLCS.S1500 : ((comboBox1.SelectedItem.ToString() == "S300") ? SiemensPLCS.S300 : ((comboBox1.SelectedItem.ToString() == "S400") ? SiemensPLCS.S400 : ((comboBox1.SelectedItem.ToString() == "S200") ? SiemensPLCS.S200 : SiemensPLCS.S200Smart)))));
			if (siemensPLCSelected == SiemensPLCS.S400)
			{
				textBox15.Text = "0";
				textBox16.Text = "3";
			}
			else if (siemensPLCSelected == SiemensPLCS.S1200)
			{
				textBox15.Text = "0";
				textBox16.Text = "0";
			}
			else if (siemensPLCSelected == SiemensPLCS.S300)
			{
				textBox15.Text = "0";
				textBox16.Text = "2";
			}
			else if (siemensPLCSelected == SiemensPLCS.S1500)
			{
				textBox15.Text = "0";
				textBox16.Text = "0";
			}
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "Siemens Read PLC Demo";
				label3.Text = "Port:";
				button1.Text = "Create";
				button2.Text = "Disconnect";
				button_read_string.Text = "r-string";
				button7.Text = "r-time";
				label11.Text = "Address:";
				label12.Text = "length:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				label16.Text = "Message:";
				label14.Text = "Results:";
				button26.Text = "Read";
				label10.Text = "Address:";
				label9.Text = "Value:";
				label19.Text = "Note: The value of the string needs to be converted";
				button14.Text = "w-string";
				button8.Text = "w-time";
				groupBox3.Text = "Bulk Read test";
				groupBox4.Text = "Message reading test, hex string needs to be filled in";
				groupBox5.Text = "Special function test";
				button3.Text = "Order";
				button4.Text = "hot-start";
				button5.Text = "cold-start";
				button6.Text = "stop";
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void NetworkAlienStart(int port)
		{
			networkAlien = new NetworkAlienClient();
			networkAlien.OnClientConnected += NetworkAlien_OnClientConnected;
			networkAlien.ServerStart(port);
		}

		private void NetworkAlien_OnClientConnected(AlienSession session)
		{
			if (session.DTU == siemensTcpNet.ConnectionId)
			{
				siemensTcpNet.ConnectServer(session);
				Invoke((Action)delegate
				{
					panel2.Enabled = true;
					button2.Enabled = true;
				});
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show("端口输入不正确！");
			}
			else
			{
				siemensTcpNet = new SiemensS7Net(siemensPLCSelected, "127.0.0.1");
				siemensTcpNet.LogNet = base.LogNet;
				if (siemensPLCSelected != SiemensPLCS.S200Smart)
				{
					siemensTcpNet.Rack = byte.Parse(textBox15.Text);
					siemensTcpNet.Slot = byte.Parse(textBox16.Text);
				}
				try
				{
					siemensTcpNet.ConnectionId = textBox1.Text;
					NetworkAlienStart(result);
					siemensTcpNet.ConnectServer(null);
					userControlReadWriteOp1.SetReadWriteNet(siemensTcpNet, "M100", true);
					MessageBox.Show("等待服务器的连接！");
					button1.Enabled = false;
					button2.Enabled = true;
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

		[AsyncStateMachine(typeof(_003Cbutton_read_string_Click_003Ed__12))]
		[DebuggerStepThrough]
		private void button_read_string_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_string_Click_003Ed__12 stateMachine = new _003Cbutton_read_string_Click_003Ed__12();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CButton7_Click_003Ed__13))]
		[DebuggerStepThrough]
		private void Button7_Click(object sender, EventArgs e)
		{
			_003CButton7_Click_003Ed__13 stateMachine = new _003CButton7_Click_003Ed__13();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton14_Click_003Ed__14))]
		[DebuggerStepThrough]
		private void button14_Click(object sender, EventArgs e)
		{
			_003Cbutton14_Click_003Ed__14 stateMachine = new _003Cbutton14_Click_003Ed__14();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CButton8_Click_003Ed__15))]
		[DebuggerStepThrough]
		private void Button8_Click(object sender, EventArgs e)
		{
			_003CButton8_Click_003Ed__15 stateMachine = new _003CButton8_Click_003Ed__15();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button25_Click(object sender, EventArgs e)
		{
			DemoUtils.BulkReadRenderResult(siemensTcpNet, textBox6, textBox9, textBox10);
		}

		[AsyncStateMachine(typeof(_003Cbutton3_Click_003Ed__17))]
		[DebuggerStepThrough]
		private void button3_Click(object sender, EventArgs e)
		{
			_003Cbutton3_Click_003Ed__17 stateMachine = new _003Cbutton3_Click_003Ed__17();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton26_Click_003Ed__18))]
		[DebuggerStepThrough]
		private void button26_Click(object sender, EventArgs e)
		{
			_003Cbutton26_Click_003Ed__18 stateMachine = new _003Cbutton26_Click_003Ed__18();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton4_Click_003Ed__19))]
		[DebuggerStepThrough]
		private void button4_Click(object sender, EventArgs e)
		{
			_003Cbutton4_Click_003Ed__19 stateMachine = new _003Cbutton4_Click_003Ed__19();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton5_Click_003Ed__20))]
		[DebuggerStepThrough]
		private void button5_Click(object sender, EventArgs e)
		{
			_003Cbutton5_Click_003Ed__20 stateMachine = new _003Cbutton5_Click_003Ed__20();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton6_Click_003Ed__21))]
		[DebuggerStepThrough]
		private void button6_Click(object sender, EventArgs e)
		{
			_003Cbutton6_Click_003Ed__21 stateMachine = new _003Cbutton6_Click_003Ed__21();
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

		[AsyncStateMachine(typeof(_003Cthread_test1_003Ed__29))]
		[DebuggerStepThrough]
		private void thread_test1()
		{
			_003Cthread_test1_003Ed__29 stateMachine = new _003Cthread_test1_003Ed__29();
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
			element.SetAttributeValue("DTU", textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlRack, textBox15.Text);
			element.SetAttributeValue(DemoDeviceList.XmlSlot, textBox16.Text);
			element.SetAttributeValue("PlcType", comboBox1.SelectedIndex);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute("DTU").Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox15.Text = element.Attribute(DemoDeviceList.XmlRack).Value;
			textBox16.Text = element.Attribute(DemoDeviceList.XmlSlot).Value;
			comboBox1.SelectedIndex = int.Parse(element.Attribute("PlcType").Value);
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
			comboBox1 = new System.Windows.Forms.ComboBox();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			label25 = new System.Windows.Forms.Label();
			textBox16 = new System.Windows.Forms.TextBox();
			label24 = new System.Windows.Forms.Label();
			textBox15 = new System.Windows.Forms.TextBox();
			label23 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox5 = new System.Windows.Forms.GroupBox();
			label2 = new System.Windows.Forms.Label();
			button9 = new System.Windows.Forms.Button();
			button14 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			button_read_string = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			label19 = new System.Windows.Forms.Label();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			textBox7 = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			textBox8 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			groupBox4 = new System.Windows.Forms.GroupBox();
			textBox11 = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			button26 = new System.Windows.Forms.Button();
			textBox13 = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			button3 = new System.Windows.Forms.Button();
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
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(label22);
			panel1.Controls.Add(label25);
			panel1.Controls.Add(textBox16);
			panel1.Controls.Add(label24);
			panel1.Controls.Add(textBox15);
			panel1.Controls.Add(label23);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 54);
			panel1.TabIndex = 0;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[6]
			{
				"S1200",
				"S1500",
				"S300",
				"S400",
				"S200",
				"S200smart"
			});
			comboBox1.Location = new System.Drawing.Point(305, 13);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(111, 25);
			comboBox1.TabIndex = 16;
			textBox1.Location = new System.Drawing.Point(483, 14);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(171, 23);
			textBox1.TabIndex = 14;
			textBox1.Text = "12345678901";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(422, 17);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(62, 17);
			label1.TabIndex = 13;
			label1.Text = "DTU ID：";
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(662, 17);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(97, 17);
			label22.TabIndex = 15;
			label22.Text = "(11位ASCII字符)";
			label25.AutoSize = true;
			label25.ForeColor = System.Drawing.Color.Gray;
			label25.Location = new System.Drawing.Point(160, 30);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(110, 17);
			label25.TabIndex = 12;
			label25.Text = "Not s7-200 smart";
			textBox16.Location = new System.Drawing.Point(262, 4);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(33, 23);
			textBox16.TabIndex = 11;
			textBox16.Text = "0";
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(216, 7);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(42, 17);
			label24.TabIndex = 10;
			label24.Text = "Slot：";
			textBox15.Location = new System.Drawing.Point(177, 4);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(33, 23);
			textBox15.TabIndex = 9;
			textBox15.Text = "0";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(128, 7);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(48, 17);
			label23.TabIndex = 8;
			label23.Text = "Rack：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(879, 11);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(782, 11);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "创建";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(62, 14);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(61, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "10000";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(8, 17);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteOp1);
			panel2.Controls.Add(groupBox5);
			panel2.Controls.Add(groupBox4);
			panel2.Controls.Add(groupBox3);
			panel2.Location = new System.Drawing.Point(3, 94);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 547);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Location = new System.Drawing.Point(4, 2);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(988, 240);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox5.Controls.Add(label2);
			groupBox5.Controls.Add(button9);
			groupBox5.Controls.Add(button14);
			groupBox5.Controls.Add(button8);
			groupBox5.Controls.Add(button_read_string);
			groupBox5.Controls.Add(button7);
			groupBox5.Controls.Add(button4);
			groupBox5.Controls.Add(label19);
			groupBox5.Controls.Add(button6);
			groupBox5.Controls.Add(button5);
			groupBox5.Controls.Add(textBox7);
			groupBox5.Controls.Add(label10);
			groupBox5.Controls.Add(textBox8);
			groupBox5.Controls.Add(label9);
			groupBox5.Location = new System.Drawing.Point(573, 243);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(419, 299);
			groupBox5.TabIndex = 4;
			groupBox5.TabStop = false;
			groupBox5.Text = "特殊功能测试";
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
			button14.Location = new System.Drawing.Point(324, 120);
			button14.Name = "button14";
			button14.Size = new System.Drawing.Size(82, 28);
			button14.TabIndex = 16;
			button14.Text = "字符串写入";
			button14.UseVisualStyleBackColor = true;
			button14.Click += new System.EventHandler(button14_Click);
			button8.Location = new System.Drawing.Point(324, 88);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(82, 28);
			button8.TabIndex = 21;
			button8.Text = "time写入";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(Button8_Click);
			button_read_string.Location = new System.Drawing.Point(236, 121);
			button_read_string.Name = "button_read_string";
			button_read_string.Size = new System.Drawing.Size(82, 28);
			button_read_string.TabIndex = 16;
			button_read_string.Text = "字符串读取";
			button_read_string.UseVisualStyleBackColor = true;
			button_read_string.Click += new System.EventHandler(button_read_string_Click);
			button7.Location = new System.Drawing.Point(236, 88);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(82, 28);
			button7.TabIndex = 17;
			button7.Text = "time读取";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(Button7_Click);
			button4.Location = new System.Drawing.Point(24, 24);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(82, 28);
			button4.TabIndex = 18;
			button4.Text = "热启动";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			label19.ForeColor = System.Drawing.Color.Red;
			label19.Location = new System.Drawing.Point(62, 150);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(147, 58);
			label19.TabIndex = 17;
			label19.Text = "注意：值的字符串需要能转化成对应的数据类型";
			button6.Location = new System.Drawing.Point(226, 24);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(82, 28);
			button6.TabIndex = 20;
			button6.Text = "停止";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button5.Location = new System.Drawing.Point(126, 24);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(82, 28);
			button5.TabIndex = 19;
			button5.Text = "冷启动";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			textBox7.Location = new System.Drawing.Point(78, 124);
			textBox7.Name = "textBox7";
			textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox7.Size = new System.Drawing.Size(152, 23);
			textBox7.TabIndex = 5;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(10, 94);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(44, 17);
			label10.TabIndex = 2;
			label10.Text = "地址：";
			textBox8.Location = new System.Drawing.Point(78, 91);
			textBox8.Name = "textBox8";
			textBox8.Size = new System.Drawing.Size(152, 23);
			textBox8.TabIndex = 3;
			textBox8.Text = "M100";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(10, 126);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(32, 17);
			label9.TabIndex = 4;
			label9.Text = "值：";
			groupBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox4.Controls.Add(textBox11);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(button26);
			groupBox4.Controls.Add(textBox13);
			groupBox4.Controls.Add(label16);
			groupBox4.Location = new System.Drawing.Point(11, 403);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(556, 139);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "报文读取测试，此处需要填入完整的16进制报文字符串";
			textBox11.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox11.Location = new System.Drawing.Point(63, 60);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox11.Size = new System.Drawing.Size(485, 73);
			textBox11.TabIndex = 10;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(9, 62);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 9;
			label14.Text = "结果：";
			button26.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button26.Location = new System.Drawing.Point(466, 24);
			button26.Name = "button26";
			button26.Size = new System.Drawing.Size(82, 28);
			button26.TabIndex = 8;
			button26.Text = "报文读取";
			button26.UseVisualStyleBackColor = true;
			button26.Click += new System.EventHandler(button26_Click);
			textBox13.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox13.Location = new System.Drawing.Point(63, 27);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(397, 23);
			textBox13.TabIndex = 5;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(9, 30);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(44, 17);
			label16.TabIndex = 4;
			label16.Text = "报文：";
			groupBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox3.Controls.Add(button3);
			groupBox3.Controls.Add(textBox10);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(button25);
			groupBox3.Controls.Add(textBox9);
			groupBox3.Controls.Add(label12);
			groupBox3.Controls.Add(textBox6);
			groupBox3.Controls.Add(label11);
			groupBox3.Location = new System.Drawing.Point(4, 243);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(563, 154);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试";
			button3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button3.Location = new System.Drawing.Point(389, 24);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(82, 28);
			button3.TabIndex = 15;
			button3.Text = "订货号";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox10.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox10.Location = new System.Drawing.Point(63, 60);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(494, 87);
			textBox10.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 62);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "结果：";
			button25.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button25.Location = new System.Drawing.Point(473, 24);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(82, 28);
			button25.TabIndex = 8;
			button25.Text = "批量读取";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			textBox9.Location = new System.Drawing.Point(234, 27);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(102, 23);
			textBox9.TabIndex = 7;
			textBox9.Text = "10";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(185, 30);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(44, 17);
			label12.TabIndex = 6;
			label12.Text = "长度：";
			textBox6.Location = new System.Drawing.Point(63, 27);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(102, 23);
			textBox6.TabIndex = 5;
			textBox6.Text = "M100";
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
			userControlHead1.ProtocolInfo = "s7";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
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
			base.Name = "FormSiemensDTU";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "西门子PLC访问Demo";
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