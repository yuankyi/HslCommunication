using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Robot.FANUC;
using HslCommunicationDemo.DemoControl;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.Robot
{
	public class FormFanucRobot : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003Cbutton10_Click_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<bool[]> _003Cread_003E5__1;

			private OperateResult<bool[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<bool[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<bool[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadSOAsync(0, 10).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton10_Click_003Ed__16 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<bool[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "SO:" + _003C_003E4__this.TransBoolArrayToString(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton11_Click_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<bool[]> _003Cread_003E5__1;

			private OperateResult<bool[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<bool[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<bool[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadSIAsync(0, 10).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton11_Click_003Ed__17 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<bool[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "SI:" + _003C_003E4__this.TransBoolArrayToString(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton12_Click_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<bool[]> _003Cread_003E5__1;

			private OperateResult<bool[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<bool[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<bool[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadUOAsync(1, 10).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton12_Click_003Ed__18 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<bool[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "UO:" + _003C_003E4__this.TransBoolArrayToString(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton13_Click_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<bool[]> _003Cread_003E5__1;

			private OperateResult<bool[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<bool[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<bool[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadUIAsync(1, 10).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton13_Click_003Ed__19 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<bool[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "UI:" + _003C_003E4__this.TransBoolArrayToString(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton14_Click_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<ushort[]> _003Cread_003E5__1;

			private OperateResult<ushort[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<ushort[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<ushort[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadGOAsync(1, 3).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton14_Click_003Ed__20 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<ushort[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "GO:" + SoftBasic.ArrayFormat(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton15_Click_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<ushort[]> _003Cread_003E5__1;

			private OperateResult<ushort[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<ushort[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<ushort[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadGOAsync(10001, 3).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton15_Click_003Ed__21 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<ushort[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "GO[1000x]:" + SoftBasic.ArrayFormat(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton16_Click_003Ed__22 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<ushort[]> _003Cread_003E5__1;

			private OperateResult<ushort[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<ushort[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<ushort[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadGIAsync(1, 3).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton16_Click_003Ed__22 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<ushort[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "GI:" + SoftBasic.ArrayFormat(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton17_Click_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<ushort[]> _003Cread_003E5__1;

			private OperateResult<ushort[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<ushort[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<ushort[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadGOAsync(1001, 3).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton17_Click_003Ed__23 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<ushort[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "AO:" + SoftBasic.ArrayFormat(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton18_Click_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<ushort[]> _003Cread_003E5__1;

			private OperateResult<ushort[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<ushort[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<ushort[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadGIAsync(1001, 2).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton18_Click_003Ed__24 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<ushort[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "AI:" + SoftBasic.ArrayFormat(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton19_Click_003Ed__25 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<bool[]> _003Cread_003E5__1;

			private OperateResult<bool[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<bool[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<bool[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadSDOAsync(8001, 5).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton19_Click_003Ed__25 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<bool[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "WO:" + _003C_003E4__this.TransBoolArrayToString(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton1_Click_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult _003Cconnect_003E5__1;

			private OperateResult _003C_003Es__2;

			private Exception _003Cex_003E5__3;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					if (num != 0)
					{
					}
					try
					{
						TaskAwaiter<OperateResult> awaiter;
						if (num != 0)
						{
							_003C_003E4__this.fanuc = new FanucInterfaceNet(_003C_003E4__this.textBox1.Text, int.Parse(_003C_003E4__this.textBox2.Text));
							_003C_003E4__this.fanuc.ConnectTimeOut = 2000;
							_003C_003E4__this.fanuc.LogNet = _003C_003E4__this.LogNet;
							_003C_003E4__this.button1.Enabled = false;
							awaiter = _003C_003E4__this.fanuc.ConnectServerAsync().GetAwaiter();
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
							MessageBox.Show("连接成功");
							_003C_003E4__this.button1.Enabled = false;
							_003C_003E4__this.button2.Enabled = true;
							_003C_003E4__this.panel2.Enabled = true;
							_003C_003E4__this.userControlReadWriteOp1.SetReadWriteNet(_003C_003E4__this.fanuc, "D1", true);
						}
						else
						{
							_003C_003E4__this.button1.Enabled = true;
							MessageBox.Show("连接失败");
						}
						_003Cconnect_003E5__1 = null;
					}
					catch (Exception ex)
					{
						Exception ex2 = _003Cex_003E5__3 = ex;
						SoftBasic.ShowExceptionMessage(_003Cex_003E5__3);
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
		private sealed class _003Cbutton20_Click_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<bool[]> _003Cread_003E5__1;

			private OperateResult<bool[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<bool[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<bool[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadSDIAsync(8001, 5).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton20_Click_003Ed__26 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<bool[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "WI:" + _003C_003E4__this.TransBoolArrayToString(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton21_Click_003Ed__27 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<bool[]> _003Cread_003E5__1;

			private OperateResult<bool[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<bool[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<bool[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadSDIAsync(8401, 1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton21_Click_003Ed__27 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<bool[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "WSI:" + _003C_003E4__this.TransBoolArrayToString(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton22_Click_003Ed__29 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private int _003CintStartIndex_003E5__1;

			private bool[] _003Cvalue_003E5__2;

			private OperateResult _003Cwrite_003E5__3;

			private int _003Ci_003E5__4;

			private OperateResult _003C_003Es__5;

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
						goto IL_015d;
					}
					if (MessageBox.Show(StringResources.Language.WriteWarning, "Write Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.Cancel)
					{
						_003CintStartIndex_003E5__1 = ((sender == _003C_003E4__this.button22) ? 1 : ((sender == _003C_003E4__this.button23) ? 10001 : 11001));
						_003C_003E4__this.w_sdo++;
						_003Cvalue_003E5__2 = new bool[100];
						if (_003C_003E4__this.w_sdo % 2 == 1)
						{
							_003Ci_003E5__4 = 0;
							while (_003Ci_003E5__4 < _003Cvalue_003E5__2.Length)
							{
								_003Cvalue_003E5__2[_003Ci_003E5__4] = true;
								_003Ci_003E5__4++;
							}
						}
						awaiter = _003C_003E4__this.fanuc.WriteSDOAsync((ushort)_003CintStartIndex_003E5__1, _003Cvalue_003E5__2).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton22_Click_003Ed__29 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_015d;
					}
					goto end_IL_0007;
					IL_015d:
					_003C_003Es__5 = awaiter.GetResult();
					_003Cwrite_003E5__3 = _003C_003Es__5;
					_003C_003Es__5 = null;
					if (_003Cwrite_003E5__3.IsSuccess)
					{
						MessageBox.Show("Write Success！value:" + _003Cvalue_003E5__2[0].ToString());
					}
					else
					{
						MessageBox.Show("Write Failed！" + _003Cwrite_003E5__3.Message);
					}
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cvalue_003E5__2 = null;
					_003Cwrite_003E5__3 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cvalue_003E5__2 = null;
				_003Cwrite_003E5__3 = null;
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
		private sealed class _003Cbutton25_Click_003Ed__31 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private bool[] _003Cvalue_003E5__1;

			private OperateResult _003Cwrite_003E5__2;

			private int _003Ci_003E5__3;

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
						goto IL_011c;
					}
					if (MessageBox.Show(StringResources.Language.WriteWarning, "Write Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.Cancel)
					{
						_003C_003E4__this.w_sdi++;
						_003Cvalue_003E5__1 = new bool[10];
						if (_003C_003E4__this.w_sdi % 2 == 1)
						{
							_003Ci_003E5__3 = 0;
							while (_003Ci_003E5__3 < _003Cvalue_003E5__1.Length)
							{
								_003Cvalue_003E5__1[_003Ci_003E5__3] = true;
								_003Ci_003E5__3++;
							}
						}
						awaiter = _003C_003E4__this.fanuc.WriteSDIAsync(1, _003Cvalue_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton25_Click_003Ed__31 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_011c;
					}
					goto end_IL_0007;
					IL_011c:
					_003C_003Es__4 = awaiter.GetResult();
					_003Cwrite_003E5__2 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cwrite_003E5__2.IsSuccess)
					{
						MessageBox.Show("Write Success！value:" + _003Cvalue_003E5__1[0].ToString());
					}
					else
					{
						MessageBox.Show("Write Failed！" + _003Cwrite_003E5__2.Message);
					}
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cvalue_003E5__1 = null;
					_003Cwrite_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cvalue_003E5__1 = null;
				_003Cwrite_003E5__2 = null;
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
		private sealed class _003Cbutton26_Click_003Ed__33 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private bool[] _003Cvalue_003E5__1;

			private OperateResult _003Cwrite_003E5__2;

			private int _003Ci_003E5__3;

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
						goto IL_011b;
					}
					if (MessageBox.Show(StringResources.Language.WriteWarning, "Write Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.Cancel)
					{
						_003C_003E4__this.w_rdo++;
						_003Cvalue_003E5__1 = new bool[8];
						if (_003C_003E4__this.w_rdo % 2 == 1)
						{
							_003Ci_003E5__3 = 0;
							while (_003Ci_003E5__3 < _003Cvalue_003E5__1.Length)
							{
								_003Cvalue_003E5__1[_003Ci_003E5__3] = true;
								_003Ci_003E5__3++;
							}
						}
						awaiter = _003C_003E4__this.fanuc.WriteRDOAsync(1, _003Cvalue_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton26_Click_003Ed__33 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_011b;
					}
					goto end_IL_0007;
					IL_011b:
					_003C_003Es__4 = awaiter.GetResult();
					_003Cwrite_003E5__2 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cwrite_003E5__2.IsSuccess)
					{
						MessageBox.Show("Write Success！value:" + _003Cvalue_003E5__1[0].ToString());
					}
					else
					{
						MessageBox.Show("Write Failed！" + _003Cwrite_003E5__2.Message);
					}
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cvalue_003E5__1 = null;
					_003Cwrite_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cvalue_003E5__1 = null;
				_003Cwrite_003E5__2 = null;
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
		private sealed class _003Cbutton27_Click_003Ed__35 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private bool[] _003Cvalue_003E5__1;

			private OperateResult _003Cwrite_003E5__2;

			private int _003Ci_003E5__3;

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
						goto IL_011b;
					}
					if (MessageBox.Show(StringResources.Language.WriteWarning, "Write Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.Cancel)
					{
						_003C_003E4__this.w_rdi++;
						_003Cvalue_003E5__1 = new bool[8];
						if (_003C_003E4__this.w_rdi % 2 == 1)
						{
							_003Ci_003E5__3 = 0;
							while (_003Ci_003E5__3 < _003Cvalue_003E5__1.Length)
							{
								_003Cvalue_003E5__1[_003Ci_003E5__3] = true;
								_003Ci_003E5__3++;
							}
						}
						awaiter = _003C_003E4__this.fanuc.WriteRDIAsync(1, _003Cvalue_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton27_Click_003Ed__35 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_011b;
					}
					goto end_IL_0007;
					IL_011b:
					_003C_003Es__4 = awaiter.GetResult();
					_003Cwrite_003E5__2 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cwrite_003E5__2.IsSuccess)
					{
						MessageBox.Show("Write Success！value:" + _003Cvalue_003E5__1[0].ToString());
					}
					else
					{
						MessageBox.Show("Write Failed！" + _003Cwrite_003E5__2.Message);
					}
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cvalue_003E5__1 = null;
					_003Cwrite_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cvalue_003E5__1 = null;
				_003Cwrite_003E5__2 = null;
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
		private sealed class _003Cbutton28_Click_003Ed__37 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private int _003CintStartIndex_003E5__1;

			private ushort[] _003Cvalue_003E5__2;

			private OperateResult _003Cwrite_003E5__3;

			private int _003Ci_003E5__4;

			private OperateResult _003C_003Es__5;

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
						goto IL_013c;
					}
					if (MessageBox.Show(StringResources.Language.WriteWarning, "Write Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.Cancel)
					{
						_003CintStartIndex_003E5__1 = ((sender == _003C_003E4__this.button28) ? 1 : 10001);
						_003C_003E4__this.w_go++;
						_003Cvalue_003E5__2 = new ushort[3];
						_003Ci_003E5__4 = 0;
						while (_003Ci_003E5__4 < _003Cvalue_003E5__2.Length)
						{
							_003Cvalue_003E5__2[_003Ci_003E5__4] = (ushort)((_003C_003E4__this.w_go % 3 + 1) * 11);
							_003Ci_003E5__4++;
						}
						awaiter = _003C_003E4__this.fanuc.WriteGOAsync((ushort)_003CintStartIndex_003E5__1, _003Cvalue_003E5__2).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton28_Click_003Ed__37 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_013c;
					}
					goto end_IL_0007;
					IL_013c:
					_003C_003Es__5 = awaiter.GetResult();
					_003Cwrite_003E5__3 = _003C_003Es__5;
					_003C_003Es__5 = null;
					if (_003Cwrite_003E5__3.IsSuccess)
					{
						MessageBox.Show("Write Success！value:" + _003Cvalue_003E5__2[0].ToString());
					}
					else
					{
						MessageBox.Show("Write Failed！" + _003Cwrite_003E5__3.Message);
					}
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cvalue_003E5__2 = null;
					_003Cwrite_003E5__3 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cvalue_003E5__2 = null;
				_003Cwrite_003E5__3 = null;
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
		private sealed class _003Cbutton30_Click_003Ed__39 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private ushort[] _003Cvalue_003E5__1;

			private OperateResult _003Cwrite_003E5__2;

			private int _003Ci_003E5__3;

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
						goto IL_0115;
					}
					if (MessageBox.Show(StringResources.Language.WriteWarning, "Write Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.Cancel)
					{
						_003C_003E4__this.w_gi++;
						_003Cvalue_003E5__1 = new ushort[3];
						_003Ci_003E5__3 = 0;
						while (_003Ci_003E5__3 < _003Cvalue_003E5__1.Length)
						{
							_003Cvalue_003E5__1[_003Ci_003E5__3] = (ushort)((_003C_003E4__this.w_gi % 3 + 1) * 11);
							_003Ci_003E5__3++;
						}
						awaiter = _003C_003E4__this.fanuc.WriteGIAsync(1, _003Cvalue_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton30_Click_003Ed__39 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_0115;
					}
					goto end_IL_0007;
					IL_0115:
					_003C_003Es__4 = awaiter.GetResult();
					_003Cwrite_003E5__2 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cwrite_003E5__2.IsSuccess)
					{
						MessageBox.Show("Write Success！value:" + _003Cvalue_003E5__1[0].ToString());
					}
					else
					{
						MessageBox.Show("Write Failed！" + _003Cwrite_003E5__2.Message);
					}
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cvalue_003E5__1 = null;
					_003Cwrite_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cvalue_003E5__1 = null;
				_003Cwrite_003E5__2 = null;
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

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<bool[]> _003Cread_003E5__1;

			private OperateResult<bool[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<bool[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<bool[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadSDOAsync(1, 100).GetAwaiter();
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
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<bool[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "SDO:" + _003C_003E4__this.TransBoolArrayToString(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton4_Click_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<FanucData> _003Cread_003E5__1;

			private OperateResult<FanucData> _003C_003Es__2;

			private TaskAwaiter<OperateResult<FanucData>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<FanucData>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadFanucDataAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton4_Click_003Ed__7 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<FanucData>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.textBox8.Text = _003Cread_003E5__1.Content.ToString();
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
		private sealed class _003Cbutton5_Click_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<bool[]> _003Cread_003E5__1;

			private OperateResult<bool[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<bool[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<bool[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadSDOAsync(10001, 100).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton5_Click_003Ed__11 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<bool[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "SDO[1000x]:" + _003C_003E4__this.TransBoolArrayToString(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton6_Click_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<bool[]> _003Cread_003E5__1;

			private OperateResult<bool[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<bool[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<bool[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadSDOAsync(11001, 100).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton6_Click_003Ed__12 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<bool[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "SDO[1100x]:" + _003C_003E4__this.TransBoolArrayToString(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton7_Click_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<bool[]> _003Cread_003E5__1;

			private OperateResult<bool[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<bool[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<bool[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadSDIAsync(1, 10).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton7_Click_003Ed__13 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<bool[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "SDI:" + _003C_003E4__this.TransBoolArrayToString(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton8_Click_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<bool[]> _003Cread_003E5__1;

			private OperateResult<bool[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<bool[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<bool[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadRDOAsync(1, 10).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton8_Click_003Ed__14 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<bool[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "RDO:" + _003C_003E4__this.TransBoolArrayToString(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton9_Click_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<bool[]> _003Cread_003E5__1;

			private OperateResult<bool[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<bool[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<bool[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadRDIAsync(1, 10).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton9_Click_003Ed__15 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<bool[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = "RDI:" + _003C_003E4__this.TransBoolArrayToString(_003Cread_003E5__1.Content);
					}
					else
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton_read_short_Click_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFanucRobot _003C_003E4__this;

			private OperateResult<FanucData> _003Cread_003E5__1;

			private OperateResult<FanucData> _003C_003Es__2;

			private TaskAwaiter<OperateResult<FanucData>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<FanucData>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.fanuc.ReadFanucDataAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_read_short_Click_003Ed__6 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<FanucData>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("Read Failed！" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.textBox8.Text = JObject.FromObject(_003Cread_003E5__1.Content).ToString();
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

		private FanucInterfaceNet fanuc;

		private int w_sdo = 0;

		private int w_sdi = 0;

		private int w_rdo = 0;

		private int w_rdi = 0;

		private int w_go = 0;

		private int w_gi = 0;

		private IContainer components = null;

		private Panel panel1;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private Label label1;

		private Panel panel2;

		private Button button_read_short;

		private UserControlHead userControlHead1;

		private TextBox textBox8;

		private Label label42;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private Button button4;

		private TabPage tabPage2;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private GroupBox groupBox1;

		private TextBox textBox3;

		private Button button3;

		private Button button5;

		private Button button6;

		private Button button7;

		private Button button8;

		private Button button9;

		private Button button10;

		private Button button11;

		private Button button12;

		private Button button13;

		private Button button14;

		private Button button15;

		private Button button16;

		private Button button17;

		private Button button18;

		private Button button19;

		private Button button21;

		private Button button20;

		private Button button22;

		private Button button24;

		private Button button23;

		private Button button25;

		private Button button26;

		private Button button27;

		private Button button28;

		private Button button29;

		private Button button30;

		private Label label2;

		private ComboBox comboBox1;

		private Button button31;

		private Label label4;

		private TextBox textBox6;

		private Label label7;

		private TextBox textBox5;

		private Label label6;

		private TextBox textBox4;

		private Label label5;

		private Button button32;

		private Label label8;

		private LinkLabel linkLabel1;

		public FormFanucRobot()
		{
			InitializeComponent();
		}

		private void FormEfort_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			button2.Enabled = false;
			if (Program.Language == 2)
			{
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label2.Text = "The writing operation needs to be careful and the data needs to be checked.";
				tabPage1.Text = "General read";
				tabPage2.Text = "Professional reading and writing";
				groupBox1.Text = "Special Function Test";
			}
			comboBox1.DataSource = (from m in typeof(FanucData).GetProperties()
			select m.Name).ToArray();
			linkLabel1.LinkClicked += LinkLabel1_LinkClicked;
		}

		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(linkLabel1.Text);
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
			FanucInterfaceNet fanucInterfaceNet = fanuc;
			if (fanucInterfaceNet != null)
			{
				fanucInterfaceNet.ConnectClose();
			}
			button2.Enabled = false;
			panel2.Enabled = false;
			button1.Enabled = true;
		}

		[AsyncStateMachine(typeof(_003Cbutton_read_short_Click_003Ed__6))]
		[DebuggerStepThrough]
		private void button_read_short_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_short_Click_003Ed__6 stateMachine = new _003Cbutton_read_short_Click_003Ed__6();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton4_Click_003Ed__7))]
		[DebuggerStepThrough]
		private void button4_Click(object sender, EventArgs e)
		{
			_003Cbutton4_Click_003Ed__7 stateMachine = new _003Cbutton4_Click_003Ed__7();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button31_Click(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = fanuc.ReadString(comboBox1.Text.ToString());
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Read Failed！" + operateResult.Message);
			}
			else
			{
				textBox8.Text = operateResult.Content;
			}
		}

		private string TransBoolArrayToString(bool[] array)
		{
			return SoftBasic.ArrayFormat((from m in array
			select m ? 1 : 0).ToArray()).Replace(",", "");
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

		[AsyncStateMachine(typeof(_003Cbutton5_Click_003Ed__11))]
		[DebuggerStepThrough]
		private void button5_Click(object sender, EventArgs e)
		{
			_003Cbutton5_Click_003Ed__11 stateMachine = new _003Cbutton5_Click_003Ed__11();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton6_Click_003Ed__12))]
		[DebuggerStepThrough]
		private void button6_Click(object sender, EventArgs e)
		{
			_003Cbutton6_Click_003Ed__12 stateMachine = new _003Cbutton6_Click_003Ed__12();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton7_Click_003Ed__13))]
		[DebuggerStepThrough]
		private void button7_Click(object sender, EventArgs e)
		{
			_003Cbutton7_Click_003Ed__13 stateMachine = new _003Cbutton7_Click_003Ed__13();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton8_Click_003Ed__14))]
		[DebuggerStepThrough]
		private void button8_Click(object sender, EventArgs e)
		{
			_003Cbutton8_Click_003Ed__14 stateMachine = new _003Cbutton8_Click_003Ed__14();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton9_Click_003Ed__15))]
		[DebuggerStepThrough]
		private void button9_Click(object sender, EventArgs e)
		{
			_003Cbutton9_Click_003Ed__15 stateMachine = new _003Cbutton9_Click_003Ed__15();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton10_Click_003Ed__16))]
		[DebuggerStepThrough]
		private void button10_Click(object sender, EventArgs e)
		{
			_003Cbutton10_Click_003Ed__16 stateMachine = new _003Cbutton10_Click_003Ed__16();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton11_Click_003Ed__17))]
		[DebuggerStepThrough]
		private void button11_Click(object sender, EventArgs e)
		{
			_003Cbutton11_Click_003Ed__17 stateMachine = new _003Cbutton11_Click_003Ed__17();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton12_Click_003Ed__18))]
		[DebuggerStepThrough]
		private void button12_Click(object sender, EventArgs e)
		{
			_003Cbutton12_Click_003Ed__18 stateMachine = new _003Cbutton12_Click_003Ed__18();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton13_Click_003Ed__19))]
		[DebuggerStepThrough]
		private void button13_Click(object sender, EventArgs e)
		{
			_003Cbutton13_Click_003Ed__19 stateMachine = new _003Cbutton13_Click_003Ed__19();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton14_Click_003Ed__20))]
		[DebuggerStepThrough]
		private void button14_Click(object sender, EventArgs e)
		{
			_003Cbutton14_Click_003Ed__20 stateMachine = new _003Cbutton14_Click_003Ed__20();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton15_Click_003Ed__21))]
		[DebuggerStepThrough]
		private void button15_Click(object sender, EventArgs e)
		{
			_003Cbutton15_Click_003Ed__21 stateMachine = new _003Cbutton15_Click_003Ed__21();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton16_Click_003Ed__22))]
		[DebuggerStepThrough]
		private void button16_Click(object sender, EventArgs e)
		{
			_003Cbutton16_Click_003Ed__22 stateMachine = new _003Cbutton16_Click_003Ed__22();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton17_Click_003Ed__23))]
		[DebuggerStepThrough]
		private void button17_Click(object sender, EventArgs e)
		{
			_003Cbutton17_Click_003Ed__23 stateMachine = new _003Cbutton17_Click_003Ed__23();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton18_Click_003Ed__24))]
		[DebuggerStepThrough]
		private void button18_Click(object sender, EventArgs e)
		{
			_003Cbutton18_Click_003Ed__24 stateMachine = new _003Cbutton18_Click_003Ed__24();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton19_Click_003Ed__25))]
		[DebuggerStepThrough]
		private void button19_Click(object sender, EventArgs e)
		{
			_003Cbutton19_Click_003Ed__25 stateMachine = new _003Cbutton19_Click_003Ed__25();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton20_Click_003Ed__26))]
		[DebuggerStepThrough]
		private void button20_Click(object sender, EventArgs e)
		{
			_003Cbutton20_Click_003Ed__26 stateMachine = new _003Cbutton20_Click_003Ed__26();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton21_Click_003Ed__27))]
		[DebuggerStepThrough]
		private void button21_Click(object sender, EventArgs e)
		{
			_003Cbutton21_Click_003Ed__27 stateMachine = new _003Cbutton21_Click_003Ed__27();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton22_Click_003Ed__29))]
		[DebuggerStepThrough]
		private void button22_Click(object sender, EventArgs e)
		{
			_003Cbutton22_Click_003Ed__29 stateMachine = new _003Cbutton22_Click_003Ed__29();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton25_Click_003Ed__31))]
		[DebuggerStepThrough]
		private void button25_Click(object sender, EventArgs e)
		{
			_003Cbutton25_Click_003Ed__31 stateMachine = new _003Cbutton25_Click_003Ed__31();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton26_Click_003Ed__33))]
		[DebuggerStepThrough]
		private void button26_Click(object sender, EventArgs e)
		{
			_003Cbutton26_Click_003Ed__33 stateMachine = new _003Cbutton26_Click_003Ed__33();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton27_Click_003Ed__35))]
		[DebuggerStepThrough]
		private void button27_Click(object sender, EventArgs e)
		{
			_003Cbutton27_Click_003Ed__35 stateMachine = new _003Cbutton27_Click_003Ed__35();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton28_Click_003Ed__37))]
		[DebuggerStepThrough]
		private void button28_Click(object sender, EventArgs e)
		{
			_003Cbutton28_Click_003Ed__37 stateMachine = new _003Cbutton28_Click_003Ed__37();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton30_Click_003Ed__39))]
		[DebuggerStepThrough]
		private void button30_Click(object sender, EventArgs e)
		{
			_003Cbutton30_Click_003Ed__39 stateMachine = new _003Cbutton30_Click_003Ed__39();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button32_Click(object sender, EventArgs e)
		{
			try
			{
				OperateResult<byte[]> operateResult = fanuc.Read(byte.Parse(textBox4.Text), ushort.Parse(textBox5.Text), ushort.Parse(textBox6.Text));
				if (operateResult.IsSuccess)
				{
					textBox3.Text = "Data: " + operateResult.Content.ToHexString(' ');
				}
				else
				{
					MessageBox.Show("Write Failed！" + operateResult.Message);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Read Failed: " + ex.Message);
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
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
			label2 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			label4 = new System.Windows.Forms.Label();
			comboBox1 = new System.Windows.Forms.ComboBox();
			button31 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button_read_short = new System.Windows.Forms.Button();
			textBox8 = new System.Windows.Forms.TextBox();
			label42 = new System.Windows.Forms.Label();
			tabPage2 = new System.Windows.Forms.TabPage();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			label8 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			button32 = new System.Windows.Forms.Button();
			textBox6 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			button30 = new System.Windows.Forms.Button();
			button29 = new System.Windows.Forms.Button();
			button28 = new System.Windows.Forms.Button();
			button27 = new System.Windows.Forms.Button();
			button26 = new System.Windows.Forms.Button();
			button25 = new System.Windows.Forms.Button();
			button24 = new System.Windows.Forms.Button();
			button23 = new System.Windows.Forms.Button();
			button22 = new System.Windows.Forms.Button();
			button21 = new System.Windows.Forms.Button();
			button20 = new System.Windows.Forms.Button();
			button19 = new System.Windows.Forms.Button();
			button18 = new System.Windows.Forms.Button();
			button17 = new System.Windows.Forms.Button();
			button16 = new System.Windows.Forms.Button();
			button15 = new System.Windows.Forms.Button();
			button14 = new System.Windows.Forms.Button();
			button13 = new System.Windows.Forms.Button();
			button12 = new System.Windows.Forms.Button();
			button11 = new System.Windows.Forms.Button();
			button10 = new System.Windows.Forms.Button();
			button9 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			button3 = new System.Windows.Forms.Button();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
			panel1.Size = new System.Drawing.Size(997, 43);
			panel1.TabIndex = 12;
			label2.ForeColor = System.Drawing.Color.Red;
			label2.Location = new System.Drawing.Point(332, 6);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(434, 35);
			label2.TabIndex = 6;
			label2.Text = "写入的操作需要小心，需要对数据进行检查。";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(875, 6);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(772, 6);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(250, 9);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(76, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "60008";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(196, 12);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 9);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(128, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(tabControl1);
			panel2.Location = new System.Drawing.Point(3, 82);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(1001, 568);
			panel2.TabIndex = 13;
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			tabControl1.Location = new System.Drawing.Point(0, 0);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(999, 566);
			tabControl1.TabIndex = 114;
			tabPage1.Controls.Add(label4);
			tabPage1.Controls.Add(comboBox1);
			tabPage1.Controls.Add(button31);
			tabPage1.Controls.Add(button4);
			tabPage1.Controls.Add(button_read_short);
			tabPage1.Controls.Add(textBox8);
			tabPage1.Controls.Add(label42);
			tabPage1.Location = new System.Drawing.Point(4, 26);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(991, 536);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "通用读取";
			tabPage1.UseVisualStyleBackColor = true;
			label4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(568, 12);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(93, 17);
			label4.TabIndex = 117;
			label4.Text = "PropertyInfo：";
			comboBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(664, 8);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(203, 25);
			comboBox1.TabIndex = 116;
			button31.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button31.Location = new System.Drawing.Point(873, 6);
			button31.Name = "button31";
			button31.Size = new System.Drawing.Size(112, 28);
			button31.TabIndex = 115;
			button31.Text = "Single Read";
			button31.UseVisualStyleBackColor = true;
			button31.Click += new System.EventHandler(button31_Click);
			button4.Location = new System.Drawing.Point(178, 6);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(113, 28);
			button4.TabIndex = 113;
			button4.Text = "String Read";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button_read_short.Location = new System.Drawing.Point(60, 6);
			button_read_short.Name = "button_read_short";
			button_read_short.Size = new System.Drawing.Size(112, 28);
			button_read_short.TabIndex = 9;
			button_read_short.Text = "JSON Read";
			button_read_short.UseVisualStyleBackColor = true;
			button_read_short.Click += new System.EventHandler(button_read_short_Click);
			textBox8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox8.Location = new System.Drawing.Point(61, 39);
			textBox8.Multiline = true;
			textBox8.Name = "textBox8";
			textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox8.Size = new System.Drawing.Size(924, 491);
			textBox8.TabIndex = 110;
			label42.AutoSize = true;
			label42.Location = new System.Drawing.Point(3, 37);
			label42.Name = "label42";
			label42.Size = new System.Drawing.Size(55, 17);
			label42.TabIndex = 109;
			label42.Text = "Result：";
			tabPage2.Controls.Add(linkLabel1);
			tabPage2.Controls.Add(label8);
			tabPage2.Controls.Add(groupBox1);
			tabPage2.Controls.Add(userControlReadWriteOp1);
			tabPage2.Location = new System.Drawing.Point(4, 26);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3);
			tabPage2.Size = new System.Drawing.Size(991, 536);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "专业读写";
			tabPage2.UseVisualStyleBackColor = true;
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new System.Drawing.Point(549, 247);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(490, 17);
			linkLabel1.TabIndex = 3;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "http://api.hslcommunication.cn/html/9a252da5-4341-0437-0fb7-27da2b49d3c4.htm";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(6, 248);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(546, 17);
			label8.TabIndex = 2;
			label8.Text = "Bool地址支持：SDO, SDI, RDI, RDO, UI, UO, SI, SO    字单位地址支持：GI, GO, D，其中D参考：\r\n";
			groupBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox1.Controls.Add(button32);
			groupBox1.Controls.Add(textBox6);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(textBox5);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(textBox4);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(button30);
			groupBox1.Controls.Add(button29);
			groupBox1.Controls.Add(button28);
			groupBox1.Controls.Add(button27);
			groupBox1.Controls.Add(button26);
			groupBox1.Controls.Add(button25);
			groupBox1.Controls.Add(button24);
			groupBox1.Controls.Add(button23);
			groupBox1.Controls.Add(button22);
			groupBox1.Controls.Add(button21);
			groupBox1.Controls.Add(button20);
			groupBox1.Controls.Add(button19);
			groupBox1.Controls.Add(button18);
			groupBox1.Controls.Add(button17);
			groupBox1.Controls.Add(button16);
			groupBox1.Controls.Add(button15);
			groupBox1.Controls.Add(button14);
			groupBox1.Controls.Add(button13);
			groupBox1.Controls.Add(button12);
			groupBox1.Controls.Add(button11);
			groupBox1.Controls.Add(button10);
			groupBox1.Controls.Add(button9);
			groupBox1.Controls.Add(button8);
			groupBox1.Controls.Add(button7);
			groupBox1.Controls.Add(button6);
			groupBox1.Controls.Add(button5);
			groupBox1.Controls.Add(textBox3);
			groupBox1.Controls.Add(button3);
			groupBox1.Location = new System.Drawing.Point(7, 268);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(977, 262);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "特殊功能测试";
			button32.Location = new System.Drawing.Point(772, 103);
			button32.Name = "button32";
			button32.Size = new System.Drawing.Size(77, 25);
			button32.TabIndex = 34;
			button32.Text = "Read";
			button32.UseVisualStyleBackColor = true;
			button32.Click += new System.EventHandler(button32_Click);
			textBox6.Location = new System.Drawing.Point(841, 77);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(92, 23);
			textBox6.TabIndex = 33;
			textBox6.Text = "4";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(770, 80);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(44, 17);
			label7.TabIndex = 32;
			label7.Text = "长度：";
			textBox5.Location = new System.Drawing.Point(841, 49);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(92, 23);
			textBox5.TabIndex = 31;
			textBox5.Text = "1";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(770, 52);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(68, 17);
			label6.TabIndex = 30;
			label6.Text = "偏移地址：";
			textBox4.Location = new System.Drawing.Point(841, 20);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(92, 23);
			textBox4.TabIndex = 29;
			textBox4.Text = "70";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(770, 23);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(56, 17);
			label5.TabIndex = 28;
			label5.Text = "数据块：";
			button30.Location = new System.Drawing.Point(681, 96);
			button30.Name = "button30";
			button30.Size = new System.Drawing.Size(69, 31);
			button30.TabIndex = 27;
			button30.Text = "w-GI";
			button30.UseVisualStyleBackColor = true;
			button30.Click += new System.EventHandler(button30_Click);
			button29.Location = new System.Drawing.Point(681, 59);
			button29.Name = "button29";
			button29.Size = new System.Drawing.Size(69, 31);
			button29.TabIndex = 26;
			button29.Text = "w-GO2";
			button29.UseVisualStyleBackColor = true;
			button29.Click += new System.EventHandler(button28_Click);
			button28.Location = new System.Drawing.Point(681, 22);
			button28.Name = "button28";
			button28.Size = new System.Drawing.Size(69, 31);
			button28.TabIndex = 25;
			button28.Text = "w-GO";
			button28.UseVisualStyleBackColor = true;
			button28.Click += new System.EventHandler(button28_Click);
			button27.Location = new System.Drawing.Point(606, 96);
			button27.Name = "button27";
			button27.Size = new System.Drawing.Size(69, 31);
			button27.TabIndex = 24;
			button27.Text = "w-RDI";
			button27.UseVisualStyleBackColor = true;
			button27.Click += new System.EventHandler(button27_Click);
			button26.Location = new System.Drawing.Point(606, 59);
			button26.Name = "button26";
			button26.Size = new System.Drawing.Size(69, 31);
			button26.TabIndex = 23;
			button26.Text = "w-RDO";
			button26.UseVisualStyleBackColor = true;
			button26.Click += new System.EventHandler(button26_Click);
			button25.Location = new System.Drawing.Point(606, 22);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(69, 31);
			button25.TabIndex = 22;
			button25.Text = "w-SDI";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			button24.Location = new System.Drawing.Point(492, 96);
			button24.Name = "button24";
			button24.Size = new System.Drawing.Size(108, 31);
			button24.TabIndex = 21;
			button24.Text = "w-SDO[1100x]";
			button24.UseVisualStyleBackColor = true;
			button24.Click += new System.EventHandler(button22_Click);
			button23.Location = new System.Drawing.Point(492, 59);
			button23.Name = "button23";
			button23.Size = new System.Drawing.Size(108, 31);
			button23.TabIndex = 20;
			button23.Text = "w-SDO[1000x]";
			button23.UseVisualStyleBackColor = true;
			button23.Click += new System.EventHandler(button22_Click);
			button22.Location = new System.Drawing.Point(492, 22);
			button22.Name = "button22";
			button22.Size = new System.Drawing.Size(108, 31);
			button22.TabIndex = 19;
			button22.Text = "w-SDO";
			button22.UseVisualStyleBackColor = true;
			button22.Click += new System.EventHandler(button22_Click);
			button21.Location = new System.Drawing.Point(414, 96);
			button21.Name = "button21";
			button21.Size = new System.Drawing.Size(72, 31);
			button21.TabIndex = 18;
			button21.Text = "r-WSI";
			button21.UseVisualStyleBackColor = true;
			button21.Click += new System.EventHandler(button21_Click);
			button20.Location = new System.Drawing.Point(414, 59);
			button20.Name = "button20";
			button20.Size = new System.Drawing.Size(72, 31);
			button20.TabIndex = 17;
			button20.Text = "r-WI";
			button20.UseVisualStyleBackColor = true;
			button20.Click += new System.EventHandler(button20_Click);
			button19.Location = new System.Drawing.Point(414, 22);
			button19.Name = "button19";
			button19.Size = new System.Drawing.Size(72, 31);
			button19.TabIndex = 16;
			button19.Text = "r-WO";
			button19.UseVisualStyleBackColor = true;
			button19.Click += new System.EventHandler(button19_Click);
			button18.Location = new System.Drawing.Point(336, 96);
			button18.Name = "button18";
			button18.Size = new System.Drawing.Size(72, 31);
			button18.TabIndex = 15;
			button18.Text = "r-AI";
			button18.UseVisualStyleBackColor = true;
			button18.Click += new System.EventHandler(button18_Click);
			button17.Location = new System.Drawing.Point(336, 59);
			button17.Name = "button17";
			button17.Size = new System.Drawing.Size(72, 31);
			button17.TabIndex = 14;
			button17.Text = "r-AO";
			button17.UseVisualStyleBackColor = true;
			button17.Click += new System.EventHandler(button17_Click);
			button16.Location = new System.Drawing.Point(336, 22);
			button16.Name = "button16";
			button16.Size = new System.Drawing.Size(72, 31);
			button16.TabIndex = 13;
			button16.Text = "r-GI";
			button16.UseVisualStyleBackColor = true;
			button16.Click += new System.EventHandler(button16_Click);
			button15.Location = new System.Drawing.Point(262, 96);
			button15.Name = "button15";
			button15.Size = new System.Drawing.Size(68, 31);
			button15.TabIndex = 12;
			button15.Text = "r-GO2";
			button15.UseVisualStyleBackColor = true;
			button15.Click += new System.EventHandler(button15_Click);
			button14.Location = new System.Drawing.Point(262, 59);
			button14.Name = "button14";
			button14.Size = new System.Drawing.Size(68, 31);
			button14.TabIndex = 11;
			button14.Text = "r-GO";
			button14.UseVisualStyleBackColor = true;
			button14.Click += new System.EventHandler(button14_Click);
			button13.Location = new System.Drawing.Point(262, 22);
			button13.Name = "button13";
			button13.Size = new System.Drawing.Size(68, 31);
			button13.TabIndex = 10;
			button13.Text = "r-UI";
			button13.UseVisualStyleBackColor = true;
			button13.Click += new System.EventHandler(button13_Click);
			button12.Location = new System.Drawing.Point(185, 96);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(71, 31);
			button12.TabIndex = 9;
			button12.Text = "r-UO";
			button12.UseVisualStyleBackColor = true;
			button12.Click += new System.EventHandler(button12_Click);
			button11.Location = new System.Drawing.Point(185, 59);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(71, 31);
			button11.TabIndex = 8;
			button11.Text = "r-SI";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			button10.Location = new System.Drawing.Point(185, 22);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(71, 31);
			button10.TabIndex = 7;
			button10.Text = "r-SO";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(button10_Click);
			button9.Location = new System.Drawing.Point(108, 96);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(71, 31);
			button9.TabIndex = 6;
			button9.Text = "r-RDI";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			button8.Location = new System.Drawing.Point(108, 59);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(71, 31);
			button8.TabIndex = 5;
			button8.Text = "r-RDO";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			button7.Location = new System.Drawing.Point(108, 22);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(71, 31);
			button7.TabIndex = 4;
			button7.Text = "r-SDI";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			button6.Location = new System.Drawing.Point(6, 96);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(96, 31);
			button6.TabIndex = 3;
			button6.Text = "r-SDO[1100x]";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button5.Location = new System.Drawing.Point(6, 59);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(96, 31);
			button5.TabIndex = 2;
			button5.Text = "r-SDO[1000x]";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			textBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox3.Location = new System.Drawing.Point(6, 133);
			textBox3.Multiline = true;
			textBox3.Name = "textBox3";
			textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox3.Size = new System.Drawing.Size(965, 123);
			textBox3.TabIndex = 1;
			button3.Location = new System.Drawing.Point(6, 22);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(96, 31);
			button3.TabIndex = 0;
			button3.Text = "r-SDO";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Location = new System.Drawing.Point(5, 6);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(979, 240);
			userControlReadWriteOp1.TabIndex = 0;
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Robot";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.SupportListVisiable = true;
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
			base.Name = "FormFanucRobot";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "发那科机器人";
			base.Load += new System.EventHandler(FormEfort_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
