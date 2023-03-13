using HslCommunication;
using HslCommunication.Robot.ABB;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.Robot
{
	public class FormABBWebApi : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003CButton10_Click_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormABBWebApi _003C_003E4__this;

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
						awaiter = _003C_003E4__this.webApiClient.GetIO2OutAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CButton10_Click_003Ed__15 stateMachine = this;
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
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed:" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.textBox6.Text = _003Cread_003E5__1.Content;
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
		private sealed class _003CButton11_Click_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormABBWebApi _003C_003E4__this;

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
						awaiter = _003C_003E4__this.webApiClient.GetIO2InAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CButton11_Click_003Ed__14 stateMachine = this;
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
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed:" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.textBox6.Text = _003Cread_003E5__1.Content;
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
		private sealed class _003CButton12_Click_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormABBWebApi _003C_003E4__this;

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
						awaiter = _003C_003E4__this.webApiClient.GetLogAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CButton12_Click_003Ed__16 stateMachine = this;
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
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed:" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.textBox6.Text = _003Cread_003E5__1.Content;
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
		private sealed class _003CButton2_Click_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormABBWebApi _003C_003E4__this;

			private OperateResult<string> _003Cread_003E5__1;

			private OperateResult<string> _003C_003Es__2;

			private OperateResult _003Cwrite_003E5__3;

			private OperateResult _003C_003Es__4;

			private TaskAwaiter<OperateResult<string>> _003C_003Eu__1;

			private TaskAwaiter<OperateResult> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<string>> awaiter2;
					TaskAwaiter<OperateResult> awaiter;
					switch (num)
					{
					default:
						if (_003C_003E4__this.comboBox1.SelectedIndex == 0)
						{
							awaiter2 = _003C_003E4__this.webApiClient.ReadStringAsync(_003C_003E4__this.textBox5.Text).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CButton2_Click_003Ed__3 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
								return;
							}
							goto IL_00a7;
						}
						awaiter = _003C_003E4__this.webApiClient.WriteAsync(_003C_003E4__this.textBox5.Text, _003C_003E4__this.textBox7.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CButton2_Click_003Ed__3 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_01c4;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<string>>);
						num = (_003C_003E1__state = -1);
						goto IL_00a7;
					case 1:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<OperateResult>);
							num = (_003C_003E1__state = -1);
							goto IL_01c4;
						}
						IL_00a7:
						_003C_003Es__2 = awaiter2.GetResult();
						_003Cread_003E5__1 = _003C_003Es__2;
						_003C_003Es__2 = null;
						if (_003Cread_003E5__1.IsSuccess)
						{
							_003C_003E4__this.textBox6.Text = _003Cread_003E5__1.Content;
							_003C_003E4__this.webBrowser1.DocumentText = _003Cread_003E5__1.Content;
						}
						else
						{
							MessageBox.Show("Read Failed:" + _003Cread_003E5__1.Message);
						}
						_003Cread_003E5__1 = null;
						break;
						IL_01c4:
						_003C_003Es__4 = awaiter.GetResult();
						_003Cwrite_003E5__3 = _003C_003Es__4;
						_003C_003Es__4 = null;
						if (_003Cwrite_003E5__3.IsSuccess)
						{
							MessageBox.Show("Write Success");
						}
						else
						{
							MessageBox.Show("Read Failed:" + _003Cwrite_003E5__3.Message);
						}
						_003Cwrite_003E5__3 = null;
						break;
					}
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
		private sealed class _003CButton3_Click_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormABBWebApi _003C_003E4__this;

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
						awaiter = _003C_003E4__this.webApiClient.GetErrorStateAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CButton3_Click_003Ed__7 stateMachine = this;
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
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed:" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.textBox6.Text = _003Cread_003E5__1.Content;
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
		private sealed class _003CButton4_Click_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormABBWebApi _003C_003E4__this;

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
						awaiter = _003C_003E4__this.webApiClient.GetJointTargetAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CButton4_Click_003Ed__8 stateMachine = this;
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
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed:" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.textBox6.Text = _003Cread_003E5__1.Content;
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
		private sealed class _003CButton5_Click_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormABBWebApi _003C_003E4__this;

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
						awaiter = _003C_003E4__this.webApiClient.GetSpeedRatioAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CButton5_Click_003Ed__9 stateMachine = this;
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
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed:" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.textBox6.Text = _003Cread_003E5__1.Content;
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
		private sealed class _003CButton6_Click_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormABBWebApi _003C_003E4__this;

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
						awaiter = _003C_003E4__this.webApiClient.GetOperationModeAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CButton6_Click_003Ed__10 stateMachine = this;
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
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed:" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.textBox6.Text = _003Cread_003E5__1.Content;
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
		private sealed class _003CButton7_Click_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormABBWebApi _003C_003E4__this;

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
						awaiter = _003C_003E4__this.webApiClient.GetCtrlStateAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CButton7_Click_003Ed__11 stateMachine = this;
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
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed:" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.textBox6.Text = _003Cread_003E5__1.Content;
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
		private sealed class _003CButton8_Click_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormABBWebApi _003C_003E4__this;

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
						awaiter = _003C_003E4__this.webApiClient.GetIOInAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CButton8_Click_003Ed__12 stateMachine = this;
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
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed:" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.textBox6.Text = _003Cread_003E5__1.Content;
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
		private sealed class _003CButton9_Click_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormABBWebApi _003C_003E4__this;

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
						awaiter = _003C_003E4__this.webApiClient.GetIOOutAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CButton9_Click_003Ed__13 stateMachine = this;
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
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed:" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.textBox6.Text = _003Cread_003E5__1.Content;
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
		private sealed class _003Cbutton13_Click_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormABBWebApi _003C_003E4__this;

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
						awaiter = _003C_003E4__this.webApiClient.GetSystemAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton13_Click_003Ed__17 stateMachine = this;
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
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed:" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.textBox6.Text = _003Cread_003E5__1.Content;
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
		private sealed class _003Cbutton14_Click_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormABBWebApi _003C_003E4__this;

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
						awaiter = _003C_003E4__this.webApiClient.GetRobotTargetAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton14_Click_003Ed__18 stateMachine = this;
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
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed:" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.textBox6.Text = _003Cread_003E5__1.Content;
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
		private sealed class _003Cbutton15_Click_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormABBWebApi _003C_003E4__this;

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
						awaiter = _003C_003E4__this.webApiClient.GetServoEnableAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton15_Click_003Ed__19 stateMachine = this;
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
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed:" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.textBox6.Text = _003Cread_003E5__1.Content;
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
		private sealed class _003Cbutton16_Click_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormABBWebApi _003C_003E4__this;

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
						awaiter = _003C_003E4__this.webApiClient.GetRapidExecutionAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton16_Click_003Ed__20 stateMachine = this;
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
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed:" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.textBox6.Text = _003Cread_003E5__1.Content;
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
		private sealed class _003Cbutton17_Click_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormABBWebApi _003C_003E4__this;

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
						awaiter = _003C_003E4__this.webApiClient.GetRapidTasksAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton17_Click_003Ed__21 stateMachine = this;
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
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed:" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.textBox6.Text = _003Cread_003E5__1.Content;
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

		private ABBWebApiClient webApiClient;

		private IContainer components = null;

		private UserControlHead userControlHead1;

		private Panel panel1;

		private Button button1;

		private TextBox textBox4;

		private Label label4;

		private TextBox textBox3;

		private Label label3;

		private TextBox textBox2;

		private Label label2;

		private TextBox textBox1;

		private Label label1;

		private Panel panel2;

		private TextBox textBox7;

		private Label label9;

		private Panel panel3;

		private TextBox textBox6;

		private WebBrowser webBrowser1;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private ComboBox comboBox1;

		private Button button2;

		private Label label6;

		private TextBox textBox5;

		private Label label5;

		private Button button6;

		private Button button5;

		private Button button4;

		private Button button3;

		private Button button7;

		private Button button12;

		private Button button10;

		private Button button11;

		private Button button9;

		private Button button8;

		private Button button13;

		private Button button14;

		private Button button15;

		private Button button16;

		private Button button17;

		public FormABBWebApi()
		{
			InitializeComponent();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			try
			{
				webApiClient = new ABBWebApiClient(textBox1.Text, int.Parse(textBox2.Text), textBox3.Text, textBox4.Text);
				panel2.Enabled = true;
				button1.Enabled = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Input Data is wrong! please int again!" + Environment.NewLine + ex.Message);
			}
		}

		[AsyncStateMachine(typeof(_003CButton2_Click_003Ed__3))]
		[DebuggerStepThrough]
		private void Button2_Click(object sender, EventArgs e)
		{
			_003CButton2_Click_003Ed__3 stateMachine = new _003CButton2_Click_003Ed__3();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void FormABBWebApi_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			comboBox1.SelectedIndex = 0;
			radioButton1.CheckedChanged += RadioButton1_CheckedChanged;
			radioButton2.CheckedChanged += RadioButton2_CheckedChanged;
		}

		private void RadioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton2.Checked)
			{
				textBox6.Visible = false;
				webBrowser1.Visible = true;
			}
		}

		private void RadioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
			{
				textBox6.Visible = true;
				webBrowser1.Visible = false;
			}
		}

		[AsyncStateMachine(typeof(_003CButton3_Click_003Ed__7))]
		[DebuggerStepThrough]
		private void Button3_Click(object sender, EventArgs e)
		{
			_003CButton3_Click_003Ed__7 stateMachine = new _003CButton3_Click_003Ed__7();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CButton4_Click_003Ed__8))]
		[DebuggerStepThrough]
		private void Button4_Click(object sender, EventArgs e)
		{
			_003CButton4_Click_003Ed__8 stateMachine = new _003CButton4_Click_003Ed__8();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CButton5_Click_003Ed__9))]
		[DebuggerStepThrough]
		private void Button5_Click(object sender, EventArgs e)
		{
			_003CButton5_Click_003Ed__9 stateMachine = new _003CButton5_Click_003Ed__9();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CButton6_Click_003Ed__10))]
		[DebuggerStepThrough]
		private void Button6_Click(object sender, EventArgs e)
		{
			_003CButton6_Click_003Ed__10 stateMachine = new _003CButton6_Click_003Ed__10();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CButton7_Click_003Ed__11))]
		[DebuggerStepThrough]
		private void Button7_Click(object sender, EventArgs e)
		{
			_003CButton7_Click_003Ed__11 stateMachine = new _003CButton7_Click_003Ed__11();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CButton8_Click_003Ed__12))]
		[DebuggerStepThrough]
		private void Button8_Click(object sender, EventArgs e)
		{
			_003CButton8_Click_003Ed__12 stateMachine = new _003CButton8_Click_003Ed__12();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CButton9_Click_003Ed__13))]
		[DebuggerStepThrough]
		private void Button9_Click(object sender, EventArgs e)
		{
			_003CButton9_Click_003Ed__13 stateMachine = new _003CButton9_Click_003Ed__13();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CButton11_Click_003Ed__14))]
		[DebuggerStepThrough]
		private void Button11_Click(object sender, EventArgs e)
		{
			_003CButton11_Click_003Ed__14 stateMachine = new _003CButton11_Click_003Ed__14();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CButton10_Click_003Ed__15))]
		[DebuggerStepThrough]
		private void Button10_Click(object sender, EventArgs e)
		{
			_003CButton10_Click_003Ed__15 stateMachine = new _003CButton10_Click_003Ed__15();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CButton12_Click_003Ed__16))]
		[DebuggerStepThrough]
		private void Button12_Click(object sender, EventArgs e)
		{
			_003CButton12_Click_003Ed__16 stateMachine = new _003CButton12_Click_003Ed__16();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton13_Click_003Ed__17))]
		[DebuggerStepThrough]
		private void button13_Click(object sender, EventArgs e)
		{
			_003Cbutton13_Click_003Ed__17 stateMachine = new _003Cbutton13_Click_003Ed__17();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton14_Click_003Ed__18))]
		[DebuggerStepThrough]
		private void button14_Click(object sender, EventArgs e)
		{
			_003Cbutton14_Click_003Ed__18 stateMachine = new _003Cbutton14_Click_003Ed__18();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton15_Click_003Ed__19))]
		[DebuggerStepThrough]
		private void button15_Click(object sender, EventArgs e)
		{
			_003Cbutton15_Click_003Ed__19 stateMachine = new _003Cbutton15_Click_003Ed__19();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton16_Click_003Ed__20))]
		[DebuggerStepThrough]
		private void button16_Click(object sender, EventArgs e)
		{
			_003Cbutton16_Click_003Ed__20 stateMachine = new _003Cbutton16_Click_003Ed__20();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton17_Click_003Ed__21))]
		[DebuggerStepThrough]
		private void button17_Click(object sender, EventArgs e)
		{
			_003Cbutton17_Click_003Ed__21 stateMachine = new _003Cbutton17_Click_003Ed__21();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlUserName, textBox3.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPassword, textBox4.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox3.Text = element.Attribute(DemoDeviceList.XmlUserName).Value;
			textBox4.Text = element.Attribute(DemoDeviceList.XmlPassword).Value;
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
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1 = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			button17 = new System.Windows.Forms.Button();
			button16 = new System.Windows.Forms.Button();
			button15 = new System.Windows.Forms.Button();
			button14 = new System.Windows.Forms.Button();
			button13 = new System.Windows.Forms.Button();
			button12 = new System.Windows.Forms.Button();
			button10 = new System.Windows.Forms.Button();
			button11 = new System.Windows.Forms.Button();
			button9 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			textBox7 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			textBox6 = new System.Windows.Forms.TextBox();
			webBrowser1 = new System.Windows.Forms.WebBrowser();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton1 = new System.Windows.Forms.RadioButton();
			comboBox1 = new System.Windows.Forms.ComboBox();
			button2 = new System.Windows.Forms.Button();
			label6 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			SuspendLayout();
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "web api";
			userControlHead1.Size = new System.Drawing.Size(1023, 32);
			userControlHead1.SupportListVisiable = true;
			userControlHead1.TabIndex = 30;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox4);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(4, 37);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1017, 56);
			panel1.TabIndex = 31;
			button1.Location = new System.Drawing.Point(631, 11);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(93, 25);
			button1.TabIndex = 17;
			button1.Text = "open";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1_Click);
			textBox4.Location = new System.Drawing.Point(528, 12);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(97, 23);
			textBox4.TabIndex = 16;
			textBox4.Text = "robotics";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(461, 15);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(65, 17);
			label4.TabIndex = 15;
			label4.Text = "password";
			textBox3.Location = new System.Drawing.Point(372, 12);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(83, 23);
			textBox3.TabIndex = 14;
			textBox3.Text = "Default User";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(326, 15);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(43, 17);
			label3.TabIndex = 13;
			label3.Text = "Name";
			textBox2.Location = new System.Drawing.Point(269, 12);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(44, 23);
			textBox2.TabIndex = 12;
			textBox2.Text = "80";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(229, 15);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(32, 17);
			label2.TabIndex = 11;
			label2.Text = "Port";
			textBox1.Location = new System.Drawing.Point(92, 12);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(125, 23);
			textBox1.TabIndex = 10;
			textBox1.Text = "192.168.125.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(17, 15);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(72, 17);
			label1.TabIndex = 9;
			label1.Text = "Ip Address";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(button17);
			panel2.Controls.Add(button16);
			panel2.Controls.Add(button15);
			panel2.Controls.Add(button14);
			panel2.Controls.Add(button13);
			panel2.Controls.Add(button12);
			panel2.Controls.Add(button10);
			panel2.Controls.Add(button11);
			panel2.Controls.Add(button9);
			panel2.Controls.Add(button8);
			panel2.Controls.Add(button7);
			panel2.Controls.Add(button6);
			panel2.Controls.Add(button5);
			panel2.Controls.Add(button4);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(textBox7);
			panel2.Controls.Add(label9);
			panel2.Controls.Add(panel3);
			panel2.Controls.Add(radioButton2);
			panel2.Controls.Add(radioButton1);
			panel2.Controls.Add(comboBox1);
			panel2.Controls.Add(button2);
			panel2.Controls.Add(label6);
			panel2.Controls.Add(textBox5);
			panel2.Controls.Add(label5);
			panel2.Location = new System.Drawing.Point(4, 101);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(1017, 531);
			panel2.TabIndex = 32;
			button17.Location = new System.Drawing.Point(598, 105);
			button17.Name = "button17";
			button17.Size = new System.Drawing.Size(119, 27);
			button17.TabIndex = 34;
			button17.Text = "RapidTasks";
			button17.UseVisualStyleBackColor = true;
			button17.Click += new System.EventHandler(button17_Click);
			button16.Location = new System.Drawing.Point(473, 105);
			button16.Name = "button16";
			button16.Size = new System.Drawing.Size(119, 27);
			button16.TabIndex = 33;
			button16.Text = "RapidExecution";
			button16.UseVisualStyleBackColor = true;
			button16.Click += new System.EventHandler(button16_Click);
			button15.Location = new System.Drawing.Point(822, 68);
			button15.Name = "button15";
			button15.Size = new System.Drawing.Size(102, 27);
			button15.TabIndex = 32;
			button15.Text = "servo enable";
			button15.UseVisualStyleBackColor = true;
			button15.Click += new System.EventHandler(button15_Click);
			button14.Location = new System.Drawing.Point(714, 68);
			button14.Name = "button14";
			button14.Size = new System.Drawing.Size(102, 27);
			button14.TabIndex = 31;
			button14.Text = "robtarget";
			button14.UseVisualStyleBackColor = true;
			button14.Click += new System.EventHandler(button14_Click);
			button13.Location = new System.Drawing.Point(606, 68);
			button13.Name = "button13";
			button13.Size = new System.Drawing.Size(102, 27);
			button13.TabIndex = 30;
			button13.Text = "System";
			button13.UseVisualStyleBackColor = true;
			button13.Click += new System.EventHandler(button13_Click);
			button12.Location = new System.Drawing.Point(375, 105);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(67, 27);
			button12.TabIndex = 29;
			button12.Text = "log";
			button12.UseVisualStyleBackColor = true;
			button12.Click += new System.EventHandler(Button12_Click);
			button10.Location = new System.Drawing.Point(297, 105);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(67, 27);
			button10.TabIndex = 28;
			button10.Text = "io2 out";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(Button10_Click);
			button11.Location = new System.Drawing.Point(223, 105);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(68, 27);
			button11.TabIndex = 27;
			button11.Text = "io2 in";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(Button11_Click);
			button9.Location = new System.Drawing.Point(150, 105);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(67, 27);
			button9.TabIndex = 26;
			button9.Text = "io out";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(Button9_Click);
			button8.Location = new System.Drawing.Point(76, 105);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(68, 27);
			button8.TabIndex = 25;
			button8.Text = "io in";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(Button8_Click);
			button7.Location = new System.Drawing.Point(498, 68);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(102, 27);
			button7.TabIndex = 24;
			button7.Text = "CtrlState";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(Button7_Click);
			button6.Location = new System.Drawing.Point(375, 68);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(117, 27);
			button6.TabIndex = 23;
			button6.Text = "OperationMode";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(Button6_Click);
			button5.Location = new System.Drawing.Point(267, 68);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(102, 27);
			button5.TabIndex = 22;
			button5.Text = "SpeedRatio";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(Button5_Click);
			button4.Location = new System.Drawing.Point(184, 68);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(77, 27);
			button4.TabIndex = 21;
			button4.Text = "Joints";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(Button4_Click);
			button3.Location = new System.Drawing.Point(76, 68);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(102, 27);
			button3.TabIndex = 20;
			button3.Text = "ErrorState";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(Button3_Click);
			textBox7.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox7.Location = new System.Drawing.Point(99, 38);
			textBox7.Name = "textBox7";
			textBox7.Size = new System.Drawing.Size(707, 23);
			textBox7.TabIndex = 19;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(16, 43);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(81, 17);
			label9.TabIndex = 18;
			label9.Text = "post content";
			panel3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel3.Controls.Add(textBox6);
			panel3.Controls.Add(webBrowser1);
			panel3.Location = new System.Drawing.Point(76, 140);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(924, 380);
			panel3.TabIndex = 17;
			textBox6.Dock = System.Windows.Forms.DockStyle.Fill;
			textBox6.Location = new System.Drawing.Point(0, 0);
			textBox6.Multiline = true;
			textBox6.Name = "textBox6";
			textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox6.Size = new System.Drawing.Size(922, 378);
			textBox6.TabIndex = 5;
			webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			webBrowser1.Location = new System.Drawing.Point(0, 0);
			webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			webBrowser1.Name = "webBrowser1";
			webBrowser1.Size = new System.Drawing.Size(922, 378);
			webBrowser1.TabIndex = 14;
			radioButton2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			radioButton2.AutoSize = true;
			radioButton2.Location = new System.Drawing.Point(905, 39);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(84, 21);
			radioButton2.TabIndex = 16;
			radioButton2.Text = "web page";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			radioButton1.AutoSize = true;
			radioButton1.Checked = true;
			radioButton1.Location = new System.Drawing.Point(838, 39);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(47, 21);
			radioButton1.TabIndex = 15;
			radioButton1.TabStop = true;
			radioButton1.Text = "text";
			radioButton1.UseVisualStyleBackColor = true;
			comboBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[2]
			{
				"GET",
				"POST"
			});
			comboBox1.Location = new System.Drawing.Point(725, 7);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(81, 25);
			comboBox1.TabIndex = 13;
			button2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button2.Location = new System.Drawing.Point(828, 7);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(84, 27);
			button2.TabIndex = 9;
			button2.Text = "read";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(Button2_Click);
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(16, 144);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(51, 17);
			label6.TabIndex = 4;
			label6.Text = "content";
			textBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox5.Location = new System.Drawing.Point(76, 7);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(643, 23);
			textBox5.TabIndex = 3;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(16, 10);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(23, 17);
			label5.TabIndex = 2;
			label5.Text = "url";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1023, 634);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			base.Controls.Add(userControlHead1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "FormABBWebApi";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormABBWebApi";
			base.Load += new System.EventHandler(FormABBWebApi_Load);
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
