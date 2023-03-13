using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using HslCommunication.Core.Pipe;
using HslCommunication.Profinet.Siemens;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormSiemens : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003CButton7_Click_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemens _003C_003E4__this;

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
							_003CButton7_Click_003Ed__9 stateMachine = this;
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

			public FormSiemens _003C_003E4__this;

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
		private sealed class _003Cbutton10_Click_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemens _003C_003E4__this;

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
						awaiter = _003C_003E4__this.siemensTcpNet.WriteWStringAsync(_003C_003E4__this.textBox8.Text, _003C_003E4__this.textBox7.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton10_Click_003Ed__14 stateMachine = this;
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
		private sealed class _003Cbutton11_Click_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemens _003C_003E4__this;

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
						awaiter = _003C_003E4__this.siemensTcpNet.ReadWStringAsync(_003C_003E4__this.textBox8.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton11_Click_003Ed__11 stateMachine = this;
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
		private sealed class _003Cbutton14_Click_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemens _003C_003E4__this;

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
							_003Cbutton14_Click_003Ed__13 stateMachine = this;
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
		private sealed class _003Cbutton26_Click_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemens _003C_003E4__this;

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
							_003Cbutton26_Click_003Ed__20 stateMachine = this;
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
		private sealed class _003Cbutton3_Click_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemens _003C_003E4__this;

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
							_003Cbutton3_Click_003Ed__19 stateMachine = this;
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
		private sealed class _003Cbutton4_Click_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemens _003C_003E4__this;

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
							_003Cbutton4_Click_003Ed__24 stateMachine = this;
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
		private sealed class _003Cbutton5_Click_003Ed__25 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemens _003C_003E4__this;

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
							_003Cbutton5_Click_003Ed__25 stateMachine = this;
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
		private sealed class _003Cbutton6_Click_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemens _003C_003E4__this;

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
							_003Cbutton6_Click_003Ed__26 stateMachine = this;
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
		private sealed class _003Cbutton_read_date_Click_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemens _003C_003E4__this;

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
						awaiter = _003C_003E4__this.siemensTcpNet.ReadDateAsync(_003C_003E4__this.textBox8.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_read_date_Click_003Ed__10 stateMachine = this;
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
		private sealed class _003Cbutton_read_dtltime_Click_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemens _003C_003E4__this;

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
						awaiter = _003C_003E4__this.siemensTcpNet.ReadDTLDataTimeAsync(_003C_003E4__this.textBox8.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_read_dtltime_Click_003Ed__12 stateMachine = this;
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
		private sealed class _003Cbutton_read_string_Click_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemens _003C_003E4__this;

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
							_003Cbutton_read_string_Click_003Ed__8 stateMachine = this;
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
		private sealed class _003Cbutton_write_Date_Click_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemens _003C_003E4__this;

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
						awaiter = _003C_003E4__this.siemensTcpNet.WriteDateAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_write_Date_Click_003Ed__17 stateMachine = this;
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
		private sealed class _003Cbutton_write_dtltime_Click_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormSiemens _003C_003E4__this;

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
						awaiter = _003C_003E4__this.siemensTcpNet.WriteDTLTimeAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_write_dtltime_Click_003Ed__16 stateMachine = this;
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
		private sealed class _003Cthread_test1_003Ed__34 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object add;

			public FormSiemens _003C_003E4__this;

			private string _003Caddress_003E5__1;

			private int _003Ccount_003E5__2;

			private OperateResult<short> _003Cread_003E5__3;

			private OperateResult _003C_003Es__4;

			private OperateResult<short> _003C_003Es__5;

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
						_003Caddress_003E5__1 = (string)add;
						_003Ccount_003E5__2 = 10000;
						goto IL_020b;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
						num = (_003C_003E1__state = -1);
						goto IL_00ab;
					case 1:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<OperateResult<short>>);
							num = (_003C_003E1__state = -1);
							goto IL_0154;
						}
						IL_020b:
						if (_003Ccount_003E5__2 <= 0)
						{
							break;
						}
						awaiter2 = _003C_003E4__this.siemensTcpNet.WriteAsync(_003Caddress_003E5__1, (short)_003Ccount_003E5__2).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003Cthread_test1_003Ed__34 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
							return;
						}
						goto IL_00ab;
						IL_00ab:
						_003C_003Es__4 = awaiter2.GetResult();
						if (!_003C_003Es__4.IsSuccess)
						{
							_003C_003Es__4 = null;
							_003C_003E4__this.failed++;
						}
						awaiter = _003C_003E4__this.siemensTcpNet.ReadInt16Async(_003Caddress_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003Cthread_test1_003Ed__34 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_0154;
						IL_0154:
						_003C_003Es__5 = awaiter.GetResult();
						_003Cread_003E5__3 = _003C_003Es__5;
						_003C_003Es__5 = null;
						if (!_003Cread_003E5__3.IsSuccess)
						{
							_003C_003E4__this.failed++;
						}
						else if (_003Cread_003E5__3.Content != _003Ccount_003E5__2)
						{
							_003C_003E4__this.failed++;
						}
						_003Ccount_003E5__2--;
						_003C_003E4__this.successCount++;
						_003Cread_003E5__3 = null;
						goto IL_020b;
					}
					_003C_003E4__this.thread_end();
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Caddress_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Caddress_003E5__1 = null;
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
		private sealed class _003Cthread_test2_003Ed__38 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object add;

			public FormSiemens _003C_003E4__this;

			private string _003Caddress_003E5__1;

			private SiemensS7Net _003Cplc_003E5__2;

			private int _003Ccount_003E5__3;

			private OperateResult<short> _003Cread_003E5__4;

			private OperateResult _003C_003Es__5;

			private OperateResult<short> _003C_003Es__6;

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
						_003Caddress_003E5__1 = (string)add;
						_003Cplc_003E5__2 = ((_003Caddress_003E5__1 == "M100") ? _003C_003E4__this.siemensS[0] : ((_003Caddress_003E5__1 == "M200") ? _003C_003E4__this.siemensS[1] : _003C_003E4__this.siemensS[2]));
						_003Ccount_003E5__3 = 10000;
						goto IL_0259;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
						num = (_003C_003E1__state = -1);
						goto IL_00fe;
					case 1:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<OperateResult<short>>);
							num = (_003C_003E1__state = -1);
							goto IL_01a2;
						}
						IL_0259:
						if (_003Ccount_003E5__3 <= 0)
						{
							break;
						}
						awaiter2 = _003Cplc_003E5__2.WriteAsync(_003Caddress_003E5__1, (short)_003Ccount_003E5__3).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003Cthread_test2_003Ed__38 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
							return;
						}
						goto IL_00fe;
						IL_00fe:
						_003C_003Es__5 = awaiter2.GetResult();
						if (!_003C_003Es__5.IsSuccess)
						{
							_003C_003Es__5 = null;
							_003C_003E4__this.failed++;
						}
						awaiter = _003Cplc_003E5__2.ReadInt16Async(_003Caddress_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003Cthread_test2_003Ed__38 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_01a2;
						IL_01a2:
						_003C_003Es__6 = awaiter.GetResult();
						_003Cread_003E5__4 = _003C_003Es__6;
						_003C_003Es__6 = null;
						if (!_003Cread_003E5__4.IsSuccess)
						{
							_003C_003E4__this.failed++;
						}
						else if (_003Cread_003E5__4.Content != _003Ccount_003E5__3)
						{
							_003C_003E4__this.failed++;
						}
						_003Ccount_003E5__3--;
						_003C_003E4__this.successCount++;
						_003Cread_003E5__4 = null;
						goto IL_0259;
					}
					_003C_003E4__this.thread_end2();
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Caddress_003E5__1 = null;
					_003Cplc_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Caddress_003E5__1 = null;
				_003Cplc_003E5__2 = null;
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

		private int thread_status = 0;

		private int failed = 0;

		private DateTime thread_time_start = DateTime.Now;

		private long successCount = 0L;

		private System.Windows.Forms.Timer timer;

		private PipeSocket pipeSocket;

		private SiemensS7Net[] siemensS = new SiemensS7Net[3];

		private IContainer components = null;

		private Panel panel1;

		private Label label1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

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

		private Label label22;

		private Label label21;

		private Button button3;

		private TextBox textBox16;

		private Label label24;

		private TextBox textBox15;

		private Label label23;

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

		private TextBox textBox4;

		private Label label5;

		private TextBox textBox3;

		private Label label4;

		private Button button10;

		private Button button11;

		private Button button12;

		private Button button_read_date;

		private Button button_write_Date;

		private TextBox textBox_pdu;

		private Label label6;

		private Button button_write_dtltime;

		private Button button_read_dtltime;

		public FormSiemens(SiemensPLCS siemensPLCS)
		{
			InitializeComponent();
			siemensPLCSelected = siemensPLCS;
			siemensTcpNet = new SiemensS7Net(siemensPLCS);
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			Language(Program.Language);
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
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
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
				button_read_date.Text = "r-date";
				button_write_Date.Text = "w-date";
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
				try
				{
					siemensTcpNet.Rack = byte.Parse(textBox15.Text);
					siemensTcpNet.Slot = byte.Parse(textBox16.Text);
					siemensTcpNet.ConnectionType = byte.Parse(textBox3.Text);
					siemensTcpNet.LocalTSAP = int.Parse(textBox4.Text);
					siemensTcpNet.LogNet = base.LogNet;
					OperateResult operateResult = siemensTcpNet.ConnectServer();
					if (operateResult.IsSuccess)
					{
						textBox_pdu.Text = siemensTcpNet.PDULength.ToString();
						MessageBox.Show(StringResources.Language.ConnectedSuccess);
						button2.Enabled = true;
						button1.Enabled = false;
						panel2.Enabled = true;
						userControlReadWriteOp1.SetReadWriteNet(siemensTcpNet, "M100", true);
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

		[AsyncStateMachine(typeof(_003Cbutton_read_string_Click_003Ed__8))]
		[DebuggerStepThrough]
		private void button_read_string_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_string_Click_003Ed__8 stateMachine = new _003Cbutton_read_string_Click_003Ed__8();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CButton7_Click_003Ed__9))]
		[DebuggerStepThrough]
		private void Button7_Click(object sender, EventArgs e)
		{
			_003CButton7_Click_003Ed__9 stateMachine = new _003CButton7_Click_003Ed__9();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_read_date_Click_003Ed__10))]
		[DebuggerStepThrough]
		private void button_read_date_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_date_Click_003Ed__10 stateMachine = new _003Cbutton_read_date_Click_003Ed__10();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton11_Click_003Ed__11))]
		[DebuggerStepThrough]
		private void button11_Click(object sender, EventArgs e)
		{
			_003Cbutton11_Click_003Ed__11 stateMachine = new _003Cbutton11_Click_003Ed__11();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_read_dtltime_Click_003Ed__12))]
		[DebuggerStepThrough]
		private void button_read_dtltime_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_dtltime_Click_003Ed__12 stateMachine = new _003Cbutton_read_dtltime_Click_003Ed__12();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton14_Click_003Ed__13))]
		[DebuggerStepThrough]
		private void button14_Click(object sender, EventArgs e)
		{
			_003Cbutton14_Click_003Ed__13 stateMachine = new _003Cbutton14_Click_003Ed__13();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton10_Click_003Ed__14))]
		[DebuggerStepThrough]
		private void button10_Click(object sender, EventArgs e)
		{
			_003Cbutton10_Click_003Ed__14 stateMachine = new _003Cbutton10_Click_003Ed__14();
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

		[AsyncStateMachine(typeof(_003Cbutton_write_dtltime_Click_003Ed__16))]
		[DebuggerStepThrough]
		private void button_write_dtltime_Click(object sender, EventArgs e)
		{
			_003Cbutton_write_dtltime_Click_003Ed__16 stateMachine = new _003Cbutton_write_dtltime_Click_003Ed__16();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_write_Date_Click_003Ed__17))]
		[DebuggerStepThrough]
		private void button_write_Date_Click(object sender, EventArgs e)
		{
			_003Cbutton_write_Date_Click_003Ed__17 stateMachine = new _003Cbutton_write_Date_Click_003Ed__17();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button25_Click(object sender, EventArgs e)
		{
			if (textBox6.Text.Contains(";") && textBox9.Text.Contains(";"))
			{
				OperateResult<byte[]> operateResult = siemensTcpNet.Read(textBox6.Text.Split(new char[1]
				{
					';'
				}, StringSplitOptions.RemoveEmptyEntries).ToArray(), (from m in textBox9.Text.Split(new char[1]
				{
					';'
				}, StringSplitOptions.RemoveEmptyEntries)
				select ushort.Parse(m)).ToArray());
				if (operateResult.IsSuccess)
				{
					textBox10.Text = operateResult.Content.ToHexString(' ');
				}
				else
				{
					MessageBox.Show("Read failed: " + operateResult.Message);
				}
			}
			else
			{
				DemoUtils.BulkReadRenderResult(siemensTcpNet, textBox6, textBox9, textBox10);
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton3_Click_003Ed__19))]
		[DebuggerStepThrough]
		private void button3_Click(object sender, EventArgs e)
		{
			_003Cbutton3_Click_003Ed__19 stateMachine = new _003Cbutton3_Click_003Ed__19();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton26_Click_003Ed__20))]
		[DebuggerStepThrough]
		private void button26_Click(object sender, EventArgs e)
		{
			_003Cbutton26_Click_003Ed__20 stateMachine = new _003Cbutton26_Click_003Ed__20();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void Test1()
		{
			OperateResult<bool> operateResult = siemensTcpNet.ReadBool("M100.4");
			if (operateResult.IsSuccess)
			{
				bool content = operateResult.Content;
			}
			else
			{
				string message = operateResult.Message;
			}
			OperateResult operateResult2 = siemensTcpNet.Write("M100.4", true);
			if (!operateResult2.IsSuccess)
			{
				string message2 = operateResult2.Message;
			}
		}

		private void Test2()
		{
			byte content = siemensTcpNet.ReadByte("M100").Content;
			short content2 = siemensTcpNet.ReadInt16("M100").Content;
			ushort content3 = siemensTcpNet.ReadUInt16("M100").Content;
			int content4 = siemensTcpNet.ReadInt32("M100").Content;
			uint content5 = siemensTcpNet.ReadUInt32("M100").Content;
			float content6 = siemensTcpNet.ReadFloat("M100").Content;
			double content7 = siemensTcpNet.ReadDouble("M100").Content;
			string content8 = siemensTcpNet.ReadString("M100", 10).Content;
			IByteTransform byteTransform = new ReverseBytesTransform();
		}

		private void Test3()
		{
			bool content = siemensTcpNet.ReadBool("M100.7").Content;
			byte content2 = siemensTcpNet.ReadByte("M100").Content;
			short content3 = siemensTcpNet.ReadInt16("M100").Content;
			ushort content4 = siemensTcpNet.ReadUInt16("M100").Content;
			int content5 = siemensTcpNet.ReadInt32("M100").Content;
			uint content6 = siemensTcpNet.ReadUInt32("M100").Content;
			float content7 = siemensTcpNet.ReadFloat("M100").Content;
			long content8 = siemensTcpNet.ReadInt64("M100").Content;
			ulong content9 = siemensTcpNet.ReadUInt64("M100").Content;
			double content10 = siemensTcpNet.ReadDouble("M100").Content;
			string content11 = siemensTcpNet.ReadString("M100", 10).Content;
			siemensTcpNet.Write("M100.7", true);
			siemensTcpNet.Write("M100", 51);
			siemensTcpNet.Write("M100", (short)12345);
			siemensTcpNet.Write("M100", (ushort)45678);
			siemensTcpNet.Write("M100", 123456789);
			siemensTcpNet.Write("M100", 3456789123u);
			siemensTcpNet.Write("M100", 123.456f);
			siemensTcpNet.Write("M100", 1234556434534545L);
			siemensTcpNet.Write("M100", 523434234234343uL);
			siemensTcpNet.Write("M100", 123.456);
			siemensTcpNet.Write("M100", "K123456789");
			OperateResult<byte[]> operateResult = siemensTcpNet.Read("M100", 10);
			if (operateResult.IsSuccess)
			{
				byte b = operateResult.Content[0];
				byte b2 = operateResult.Content[1];
				byte b3 = operateResult.Content[2];
				byte b4 = operateResult.Content[3];
				byte b5 = operateResult.Content[4];
				byte b6 = operateResult.Content[5];
				byte b7 = operateResult.Content[6];
				byte b8 = operateResult.Content[7];
				byte b9 = operateResult.Content[8];
				byte b10 = operateResult.Content[9];
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton4_Click_003Ed__24))]
		[DebuggerStepThrough]
		private void button4_Click(object sender, EventArgs e)
		{
			_003Cbutton4_Click_003Ed__24 stateMachine = new _003Cbutton4_Click_003Ed__24();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton5_Click_003Ed__25))]
		[DebuggerStepThrough]
		private void button5_Click(object sender, EventArgs e)
		{
			_003Cbutton5_Click_003Ed__25 stateMachine = new _003Cbutton5_Click_003Ed__25();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton6_Click_003Ed__26))]
		[DebuggerStepThrough]
		private void button6_Click(object sender, EventArgs e)
		{
			_003Cbutton6_Click_003Ed__26 stateMachine = new _003Cbutton6_Click_003Ed__26();
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
			thread.Start("M100");
			Thread thread2 = new Thread(thread_test1);
			thread2.IsBackground = true;
			thread2.Start("M200");
			Thread thread3 = new Thread(thread_test1);
			thread3.IsBackground = true;
			thread3.Start("M300");
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

		[AsyncStateMachine(typeof(_003Cthread_test1_003Ed__34))]
		[DebuggerStepThrough]
		private void thread_test1(object add)
		{
			_003Cthread_test1_003Ed__34 stateMachine = new _003Cthread_test1_003Ed__34();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.add = add;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button12_Click(object sender, EventArgs e)
		{
			PipeSocket obj = pipeSocket;
			if (obj != null)
			{
				Socket socket = obj.Socket;
				if (socket != null)
				{
					socket.Close();
				}
			}
			pipeSocket = new PipeSocket("127.0.0.1", 102);
			siemensS[0] = new SiemensS7Net(SiemensPLCS.S1200);
			siemensS[1] = new SiemensS7Net(SiemensPLCS.S1200);
			siemensS[2] = new SiemensS7Net(SiemensPLCS.S1200);
			siemensS[0].SetPipeSocket(pipeSocket);
			siemensS[1].SetPipeSocket(pipeSocket);
			siemensS[2].SetPipeSocket(pipeSocket);
			thread_status = 3;
			failed = 0;
			thread_time_start = DateTime.Now;
			Thread thread = new Thread(thread_test2);
			thread.IsBackground = true;
			thread.Start("M100");
			Thread thread2 = new Thread(thread_test2);
			thread2.IsBackground = true;
			thread2.Start("M200");
			Thread thread3 = new Thread(thread_test2);
			thread3.IsBackground = true;
			thread3.Start("M300");
			button12.Enabled = false;
			timer = new System.Windows.Forms.Timer();
			timer.Interval = 1000;
			timer.Tick += Timer_Tick;
			timer.Start();
		}

		[AsyncStateMachine(typeof(_003Cthread_test2_003Ed__38))]
		[DebuggerStepThrough]
		private void thread_test2(object add)
		{
			_003Cthread_test2_003Ed__38 stateMachine = new _003Cthread_test2_003Ed__38();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.add = add;
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

		private void thread_end2()
		{
			if (Interlocked.Decrement(ref thread_status) == 0)
			{
				PipeSocket obj = pipeSocket;
				if (obj != null)
				{
					Socket socket = obj.Socket;
					if (socket != null)
					{
						socket.Close();
					}
				}
				Invoke((Action)delegate
				{
					label2.Text = successCount.ToString();
					timer.Stop();
					button12.Enabled = true;
					MessageBox.Show("Spend：" + (DateTime.Now - thread_time_start).TotalSeconds.ToString() + Environment.NewLine + " Failed Count：" + failed.ToString());
				});
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlRack, textBox15.Text);
			element.SetAttributeValue(DemoDeviceList.XmlSlot, textBox16.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox15.Text = element.Attribute(DemoDeviceList.XmlRack).Value;
			textBox16.Text = element.Attribute(DemoDeviceList.XmlSlot).Value;
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
			textBox_pdu = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox16 = new System.Windows.Forms.TextBox();
			label24 = new System.Windows.Forms.Label();
			textBox15 = new System.Windows.Forms.TextBox();
			label23 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox5 = new System.Windows.Forms.GroupBox();
			button_write_dtltime = new System.Windows.Forms.Button();
			button_read_dtltime = new System.Windows.Forms.Button();
			button_write_Date = new System.Windows.Forms.Button();
			button_read_date = new System.Windows.Forms.Button();
			button12 = new System.Windows.Forms.Button();
			button10 = new System.Windows.Forms.Button();
			button11 = new System.Windows.Forms.Button();
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
			panel1.Controls.Add(textBox_pdu);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(textBox4);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(textBox16);
			panel1.Controls.Add(label24);
			panel1.Controls.Add(textBox15);
			panel1.Controls.Add(label23);
			panel1.Controls.Add(label22);
			panel1.Controls.Add(label21);
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
			textBox_pdu.Location = new System.Drawing.Point(457, 27);
			textBox_pdu.Name = "textBox_pdu";
			textBox_pdu.ReadOnly = true;
			textBox_pdu.Size = new System.Drawing.Size(40, 23);
			textBox_pdu.TabIndex = 17;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(407, 30);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(45, 17);
			label6.TabIndex = 16;
			label6.Text = "PDU：";
			textBox4.Location = new System.Drawing.Point(361, 27);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(33, 23);
			textBox4.TabIndex = 15;
			textBox4.Text = "258";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(280, 30);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(79, 17);
			label5.TabIndex = 14;
			label5.Text = "LocalTSAP：";
			textBox3.Location = new System.Drawing.Point(241, 27);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(33, 23);
			textBox3.TabIndex = 13;
			textBox3.Text = "1";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(128, 30);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(113, 17);
			label4.TabIndex = 12;
			label4.Text = "ConnectionType：";
			textBox16.Location = new System.Drawing.Point(439, 2);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(33, 23);
			textBox16.TabIndex = 11;
			textBox16.Text = "0";
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(393, 5);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(42, 17);
			label24.TabIndex = 10;
			label24.Text = "Slot：";
			textBox15.Location = new System.Drawing.Point(354, 2);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(33, 23);
			textBox15.TabIndex = 9;
			textBox15.Text = "0";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(305, 5);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(48, 17);
			label23.TabIndex = 8;
			label23.Text = "Rack：";
			label22.Location = new System.Drawing.Point(826, 7);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(147, 45);
			label22.TabIndex = 7;
			label22.Text = "M100  I100  Q100 DB100.20   T100 C100";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(756, 7);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(68, 17);
			label21.TabIndex = 6;
			label21.Text = "地址示例：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(650, 11);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(554, 11);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(238, 2);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(61, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "102";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(184, 5);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 2);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(106, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "192.168.0.100";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 5);
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
			panel2.Location = new System.Drawing.Point(3, 92);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 549);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Location = new System.Drawing.Point(3, 2);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(989, 240);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox5.Controls.Add(button_write_dtltime);
			groupBox5.Controls.Add(button_read_dtltime);
			groupBox5.Controls.Add(button_write_Date);
			groupBox5.Controls.Add(button_read_date);
			groupBox5.Controls.Add(button12);
			groupBox5.Controls.Add(button10);
			groupBox5.Controls.Add(button11);
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
			groupBox5.Size = new System.Drawing.Size(419, 301);
			groupBox5.TabIndex = 4;
			groupBox5.TabStop = false;
			groupBox5.Text = "特殊功能测试";
			button_write_dtltime.Location = new System.Drawing.Point(324, 197);
			button_write_dtltime.Name = "button_write_dtltime";
			button_write_dtltime.Size = new System.Drawing.Size(89, 28);
			button_write_dtltime.TabIndex = 30;
			button_write_dtltime.Text = "DTL time-W";
			button_write_dtltime.UseVisualStyleBackColor = true;
			button_write_dtltime.Click += new System.EventHandler(button_write_dtltime_Click);
			button_read_dtltime.Location = new System.Drawing.Point(236, 197);
			button_read_dtltime.Name = "button_read_dtltime";
			button_read_dtltime.Size = new System.Drawing.Size(82, 28);
			button_read_dtltime.TabIndex = 29;
			button_read_dtltime.Text = "DTL time-R";
			button_read_dtltime.UseVisualStyleBackColor = true;
			button_read_dtltime.Click += new System.EventHandler(button_read_dtltime_Click);
			button_write_Date.Location = new System.Drawing.Point(324, 163);
			button_write_Date.Name = "button_write_Date";
			button_write_Date.Size = new System.Drawing.Size(89, 28);
			button_write_Date.TabIndex = 28;
			button_write_Date.Text = "日期写入";
			button_write_Date.UseVisualStyleBackColor = true;
			button_write_Date.Click += new System.EventHandler(button_write_Date_Click);
			button_read_date.Location = new System.Drawing.Point(236, 163);
			button_read_date.Name = "button_read_date";
			button_read_date.Size = new System.Drawing.Size(82, 28);
			button_read_date.TabIndex = 27;
			button_read_date.Text = "日期读取";
			button_read_date.UseVisualStyleBackColor = true;
			button_read_date.Click += new System.EventHandler(button_read_date_Click);
			button12.Location = new System.Drawing.Point(13, 233);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(82, 28);
			button12.TabIndex = 26;
			button12.Text = "共享测试";
			button12.UseVisualStyleBackColor = true;
			button12.Click += new System.EventHandler(button12_Click);
			button10.Location = new System.Drawing.Point(324, 128);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(89, 28);
			button10.TabIndex = 24;
			button10.Text = "WString-W";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(button10_Click);
			button11.Location = new System.Drawing.Point(236, 129);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(82, 28);
			button11.TabIndex = 25;
			button11.Text = "WString-R";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(112, 254);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(15, 17);
			label2.TabIndex = 23;
			label2.Text = "0";
			button9.Location = new System.Drawing.Point(13, 267);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(82, 28);
			button9.TabIndex = 22;
			button9.Text = "压力测试";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			button14.Location = new System.Drawing.Point(324, 94);
			button14.Name = "button14";
			button14.Size = new System.Drawing.Size(89, 28);
			button14.TabIndex = 16;
			button14.Text = "字符串写入";
			button14.UseVisualStyleBackColor = true;
			button14.Click += new System.EventHandler(button14_Click);
			button8.Location = new System.Drawing.Point(324, 62);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(89, 28);
			button8.TabIndex = 21;
			button8.Text = "time写入";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(Button8_Click);
			button_read_string.Location = new System.Drawing.Point(236, 95);
			button_read_string.Name = "button_read_string";
			button_read_string.Size = new System.Drawing.Size(82, 28);
			button_read_string.TabIndex = 16;
			button_read_string.Text = "字符串读取";
			button_read_string.UseVisualStyleBackColor = true;
			button_read_string.Click += new System.EventHandler(button_read_string_Click);
			button7.Location = new System.Drawing.Point(236, 62);
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
			label19.Location = new System.Drawing.Point(62, 124);
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
			textBox7.Location = new System.Drawing.Point(78, 98);
			textBox7.Name = "textBox7";
			textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox7.Size = new System.Drawing.Size(152, 23);
			textBox7.TabIndex = 5;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(10, 68);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(44, 17);
			label10.TabIndex = 2;
			label10.Text = "地址：";
			textBox8.Location = new System.Drawing.Point(78, 65);
			textBox8.Name = "textBox8";
			textBox8.Size = new System.Drawing.Size(152, 23);
			textBox8.TabIndex = 3;
			textBox8.Text = "M100";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(10, 100);
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
			groupBox4.Location = new System.Drawing.Point(3, 403);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(564, 141);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "报文读取测试，此处需要填入完整的16进制报文字符串";
			textBox11.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox11.Location = new System.Drawing.Point(63, 60);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox11.Size = new System.Drawing.Size(495, 75);
			textBox11.TabIndex = 10;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(9, 62);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 9;
			label14.Text = "结果：";
			button26.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button26.Location = new System.Drawing.Point(476, 24);
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
			groupBox3.Controls.Add(button3);
			groupBox3.Controls.Add(textBox10);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(button25);
			groupBox3.Controls.Add(textBox9);
			groupBox3.Controls.Add(label12);
			groupBox3.Controls.Add(textBox6);
			groupBox3.Controls.Add(label11);
			groupBox3.Location = new System.Drawing.Point(3, 243);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(564, 154);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试";
			button3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button3.Location = new System.Drawing.Point(390, 24);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(82, 28);
			button3.TabIndex = 15;
			button3.Text = "订货号";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox10.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox10.Location = new System.Drawing.Point(63, 60);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(495, 87);
			textBox10.TabIndex = 10;
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
			base.Name = "FormSiemens";
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
