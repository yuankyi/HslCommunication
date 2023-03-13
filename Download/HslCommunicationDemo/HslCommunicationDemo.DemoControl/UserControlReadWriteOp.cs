using HslCommunication;
using HslCommunication.Core;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace HslCommunicationDemo.DemoControl
{
	public class UserControlReadWriteOp : UserControl
	{
		[CompilerGenerated]
		private sealed class _003Cbutton_read_bool_Click_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private DateTime _003Cstart_003E5__1;

			private OperateResult<bool> _003Cread_003E5__2;

			private OperateResult<bool> _003C_003Es__3;

			private DateTime _003Cstart_003E5__4;

			private OperateResult<bool[]> _003Cread_003E5__5;

			private OperateResult<bool[]> _003C_003Es__6;

			private DateTime _003Cstart_003E5__7;

			private OperateResult<bool> _003Cread_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult<bool[]> _003Cread_003E5__10;

			private TaskAwaiter<OperateResult<bool>> _003C_003Eu__1;

			private TaskAwaiter<OperateResult<bool[]>> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<bool>> awaiter2;
					TaskAwaiter<OperateResult<bool[]>> awaiter;
					switch (num)
					{
					default:
						if (!_003C_003E4__this.isAsync)
						{
							if (_003C_003E4__this.textBox5.Text == "1")
							{
								_003Cstart_003E5__7 = DateTime.Now;
								_003Cread_003E5__8 = _003C_003E4__this.readWriteNet.ReadBool(_003C_003E4__this.textBox3.Text);
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__7).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__8, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__8 = null;
							}
							else
							{
								_003Cstart_003E5__9 = DateTime.Now;
								_003Cread_003E5__10 = _003C_003E4__this.readWriteNet.ReadBool(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text));
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__10, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__10 = null;
							}
							break;
						}
						_003C_003E4__this.button_read_bool.Enabled = false;
						if (_003C_003E4__this.textBox5.Text == "1")
						{
							_003Cstart_003E5__1 = DateTime.Now;
							awaiter2 = _003C_003E4__this.readWriteNet.ReadBoolAsync(_003C_003E4__this.textBox3.Text).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003Cbutton_read_bool_Click_003Ed__14 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
								return;
							}
							goto IL_00e2;
						}
						_003Cstart_003E5__4 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.ReadBoolAsync(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003Cbutton_read_bool_Click_003Ed__14 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_01f7;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<bool>>);
						num = (_003C_003E1__state = -1);
						goto IL_00e2;
					case 1:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<OperateResult<bool[]>>);
							num = (_003C_003E1__state = -1);
							goto IL_01f7;
						}
						IL_00e2:
						_003C_003Es__3 = awaiter2.GetResult();
						_003Cread_003E5__2 = _003C_003Es__3;
						_003C_003Es__3 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__1).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__2, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__2 = null;
						goto IL_0270;
						IL_01f7:
						_003C_003Es__6 = awaiter.GetResult();
						_003Cread_003E5__5 = _003C_003Es__6;
						_003C_003Es__6 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__4).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__5, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__5 = null;
						goto IL_0270;
						IL_0270:
						_003C_003E4__this.button_read_bool.Enabled = true;
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
		private sealed class _003Cbutton_read_double_Click_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private DateTime _003Cstart_003E5__1;

			private OperateResult<double> _003Cread_003E5__2;

			private OperateResult<double> _003C_003Es__3;

			private DateTime _003Cstart_003E5__4;

			private OperateResult<double[]> _003Cread_003E5__5;

			private OperateResult<double[]> _003C_003Es__6;

			private DateTime _003Cstart_003E5__7;

			private OperateResult<double> _003Cread_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult<double[]> _003Cread_003E5__10;

			private TaskAwaiter<OperateResult<double>> _003C_003Eu__1;

			private TaskAwaiter<OperateResult<double[]>> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<double>> awaiter2;
					TaskAwaiter<OperateResult<double[]>> awaiter;
					switch (num)
					{
					default:
						if (!_003C_003E4__this.isAsync)
						{
							if (_003C_003E4__this.textBox5.Text == "1")
							{
								_003Cstart_003E5__7 = DateTime.Now;
								_003Cread_003E5__8 = _003C_003E4__this.readWriteNet.ReadDouble(_003C_003E4__this.textBox3.Text);
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__7).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__8, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__8 = null;
							}
							else
							{
								_003Cstart_003E5__9 = DateTime.Now;
								_003Cread_003E5__10 = _003C_003E4__this.readWriteNet.ReadDouble(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text));
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__10, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__10 = null;
							}
							break;
						}
						_003C_003E4__this.button_read_double.Enabled = false;
						if (_003C_003E4__this.textBox5.Text == "1")
						{
							_003Cstart_003E5__1 = DateTime.Now;
							awaiter2 = _003C_003E4__this.readWriteNet.ReadDoubleAsync(_003C_003E4__this.textBox3.Text).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003Cbutton_read_double_Click_003Ed__23 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
								return;
							}
							goto IL_00e2;
						}
						_003Cstart_003E5__4 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.ReadDoubleAsync(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003Cbutton_read_double_Click_003Ed__23 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_01f7;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<double>>);
						num = (_003C_003E1__state = -1);
						goto IL_00e2;
					case 1:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<OperateResult<double[]>>);
							num = (_003C_003E1__state = -1);
							goto IL_01f7;
						}
						IL_00e2:
						_003C_003Es__3 = awaiter2.GetResult();
						_003Cread_003E5__2 = _003C_003Es__3;
						_003C_003Es__3 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__1).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__2, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__2 = null;
						goto IL_0270;
						IL_01f7:
						_003C_003Es__6 = awaiter.GetResult();
						_003Cread_003E5__5 = _003C_003Es__6;
						_003C_003Es__6 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__4).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__5, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__5 = null;
						goto IL_0270;
						IL_0270:
						_003C_003E4__this.button_read_double.Enabled = true;
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
		private sealed class _003Cbutton_read_float_Click_003Ed__22 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private DateTime _003Cstart_003E5__1;

			private OperateResult<float> _003Cread_003E5__2;

			private OperateResult<float> _003C_003Es__3;

			private DateTime _003Cstart_003E5__4;

			private OperateResult<float[]> _003Cread_003E5__5;

			private OperateResult<float[]> _003C_003Es__6;

			private DateTime _003Cstart_003E5__7;

			private OperateResult<float> _003Cread_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult<float[]> _003Cread_003E5__10;

			private TaskAwaiter<OperateResult<float>> _003C_003Eu__1;

			private TaskAwaiter<OperateResult<float[]>> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<float>> awaiter2;
					TaskAwaiter<OperateResult<float[]>> awaiter;
					switch (num)
					{
					default:
						if (!_003C_003E4__this.isAsync)
						{
							if (_003C_003E4__this.textBox5.Text == "1")
							{
								_003Cstart_003E5__7 = DateTime.Now;
								_003Cread_003E5__8 = _003C_003E4__this.readWriteNet.ReadFloat(_003C_003E4__this.textBox3.Text);
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__7).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__8, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__8 = null;
							}
							else
							{
								_003Cstart_003E5__9 = DateTime.Now;
								_003Cread_003E5__10 = _003C_003E4__this.readWriteNet.ReadFloat(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text));
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__10, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__10 = null;
							}
							break;
						}
						_003C_003E4__this.button_read_float.Enabled = false;
						if (_003C_003E4__this.textBox5.Text == "1")
						{
							_003Cstart_003E5__1 = DateTime.Now;
							awaiter2 = _003C_003E4__this.readWriteNet.ReadFloatAsync(_003C_003E4__this.textBox3.Text).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003Cbutton_read_float_Click_003Ed__22 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
								return;
							}
							goto IL_00e2;
						}
						_003Cstart_003E5__4 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.ReadFloatAsync(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003Cbutton_read_float_Click_003Ed__22 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_01f7;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<float>>);
						num = (_003C_003E1__state = -1);
						goto IL_00e2;
					case 1:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<OperateResult<float[]>>);
							num = (_003C_003E1__state = -1);
							goto IL_01f7;
						}
						IL_00e2:
						_003C_003Es__3 = awaiter2.GetResult();
						_003Cread_003E5__2 = _003C_003Es__3;
						_003C_003Es__3 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__1).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__2, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__2 = null;
						goto IL_0270;
						IL_01f7:
						_003C_003Es__6 = awaiter.GetResult();
						_003Cread_003E5__5 = _003C_003Es__6;
						_003C_003Es__6 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__4).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__5, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__5 = null;
						goto IL_0270;
						IL_0270:
						_003C_003E4__this.button_read_float.Enabled = true;
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
		private sealed class _003Cbutton_read_int_Click_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private DateTime _003Cstart_003E5__1;

			private OperateResult<int> _003Cread_003E5__2;

			private OperateResult<int> _003C_003Es__3;

			private DateTime _003Cstart_003E5__4;

			private OperateResult<int[]> _003Cread_003E5__5;

			private OperateResult<int[]> _003C_003Es__6;

			private DateTime _003Cstart_003E5__7;

			private OperateResult<int> _003Cread_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult<int[]> _003Cread_003E5__10;

			private TaskAwaiter<OperateResult<int>> _003C_003Eu__1;

			private TaskAwaiter<OperateResult<int[]>> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<int>> awaiter2;
					TaskAwaiter<OperateResult<int[]>> awaiter;
					switch (num)
					{
					default:
						if (!_003C_003E4__this.isAsync)
						{
							if (_003C_003E4__this.textBox5.Text == "1")
							{
								_003Cstart_003E5__7 = DateTime.Now;
								_003Cread_003E5__8 = _003C_003E4__this.readWriteNet.ReadInt32(_003C_003E4__this.textBox3.Text);
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__7).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__8, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__8 = null;
							}
							else
							{
								_003Cstart_003E5__9 = DateTime.Now;
								_003Cread_003E5__10 = _003C_003E4__this.readWriteNet.ReadInt32(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text));
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__10, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__10 = null;
							}
							break;
						}
						_003C_003E4__this.button_read_int.Enabled = false;
						if (_003C_003E4__this.textBox5.Text == "1")
						{
							_003Cstart_003E5__1 = DateTime.Now;
							awaiter2 = _003C_003E4__this.readWriteNet.ReadInt32Async(_003C_003E4__this.textBox3.Text).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003Cbutton_read_int_Click_003Ed__18 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
								return;
							}
							goto IL_00e2;
						}
						_003Cstart_003E5__4 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.ReadInt32Async(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003Cbutton_read_int_Click_003Ed__18 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_01f7;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<int>>);
						num = (_003C_003E1__state = -1);
						goto IL_00e2;
					case 1:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<OperateResult<int[]>>);
							num = (_003C_003E1__state = -1);
							goto IL_01f7;
						}
						IL_00e2:
						_003C_003Es__3 = awaiter2.GetResult();
						_003Cread_003E5__2 = _003C_003Es__3;
						_003C_003Es__3 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__1).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__2, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__2 = null;
						goto IL_0270;
						IL_01f7:
						_003C_003Es__6 = awaiter.GetResult();
						_003Cread_003E5__5 = _003C_003Es__6;
						_003C_003Es__6 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__4).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__5, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__5 = null;
						goto IL_0270;
						IL_0270:
						_003C_003E4__this.button_read_int.Enabled = true;
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
		private sealed class _003Cbutton_read_long_Click_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private DateTime _003Cstart_003E5__1;

			private OperateResult<long> _003Cread_003E5__2;

			private OperateResult<long> _003C_003Es__3;

			private DateTime _003Cstart_003E5__4;

			private OperateResult<long[]> _003Cread_003E5__5;

			private OperateResult<long[]> _003C_003Es__6;

			private DateTime _003Cstart_003E5__7;

			private OperateResult<long> _003Cread_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult<long[]> _003Cread_003E5__10;

			private TaskAwaiter<OperateResult<long>> _003C_003Eu__1;

			private TaskAwaiter<OperateResult<long[]>> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<long>> awaiter2;
					TaskAwaiter<OperateResult<long[]>> awaiter;
					switch (num)
					{
					default:
						if (!_003C_003E4__this.isAsync)
						{
							if (_003C_003E4__this.textBox5.Text == "1")
							{
								_003Cstart_003E5__7 = DateTime.Now;
								_003Cread_003E5__8 = _003C_003E4__this.readWriteNet.ReadInt64(_003C_003E4__this.textBox3.Text);
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__7).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__8, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__8 = null;
							}
							else
							{
								_003Cstart_003E5__9 = DateTime.Now;
								_003Cread_003E5__10 = _003C_003E4__this.readWriteNet.ReadInt64(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text));
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__10, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__10 = null;
							}
							break;
						}
						_003C_003E4__this.button_read_long.Enabled = false;
						if (_003C_003E4__this.textBox5.Text == "1")
						{
							_003Cstart_003E5__1 = DateTime.Now;
							awaiter2 = _003C_003E4__this.readWriteNet.ReadInt64Async(_003C_003E4__this.textBox3.Text).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003Cbutton_read_long_Click_003Ed__20 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
								return;
							}
							goto IL_00e2;
						}
						_003Cstart_003E5__4 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.ReadInt64Async(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003Cbutton_read_long_Click_003Ed__20 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_01f7;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<long>>);
						num = (_003C_003E1__state = -1);
						goto IL_00e2;
					case 1:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<OperateResult<long[]>>);
							num = (_003C_003E1__state = -1);
							goto IL_01f7;
						}
						IL_00e2:
						_003C_003Es__3 = awaiter2.GetResult();
						_003Cread_003E5__2 = _003C_003Es__3;
						_003C_003Es__3 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__1).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__2, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__2 = null;
						goto IL_0270;
						IL_01f7:
						_003C_003Es__6 = awaiter.GetResult();
						_003Cread_003E5__5 = _003C_003Es__6;
						_003C_003Es__6 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__4).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__5, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__5 = null;
						goto IL_0270;
						IL_0270:
						_003C_003E4__this.button_read_long.Enabled = true;
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
		private sealed class _003Cbutton_read_short_Click_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private DateTime _003Cstart_003E5__1;

			private OperateResult<short> _003Cread_003E5__2;

			private OperateResult<short> _003C_003Es__3;

			private DateTime _003Cstart_003E5__4;

			private OperateResult<short[]> _003Cread_003E5__5;

			private OperateResult<short[]> _003C_003Es__6;

			private DateTime _003Cstart_003E5__7;

			private OperateResult<short> _003Cread_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult<short[]> _003Cread_003E5__10;

			private TaskAwaiter<OperateResult<short>> _003C_003Eu__1;

			private TaskAwaiter<OperateResult<short[]>> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<short>> awaiter2;
					TaskAwaiter<OperateResult<short[]>> awaiter;
					switch (num)
					{
					default:
						if (!_003C_003E4__this.isAsync)
						{
							if (_003C_003E4__this.textBox5.Text == "1")
							{
								_003Cstart_003E5__7 = DateTime.Now;
								_003Cread_003E5__8 = _003C_003E4__this.readWriteNet.ReadInt16(_003C_003E4__this.textBox3.Text);
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__7).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__8, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__8 = null;
							}
							else
							{
								_003Cstart_003E5__9 = DateTime.Now;
								_003Cread_003E5__10 = _003C_003E4__this.readWriteNet.ReadInt16(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text));
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__10, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__10 = null;
							}
							break;
						}
						_003C_003E4__this.button_read_short.Enabled = false;
						if (_003C_003E4__this.textBox5.Text == "1")
						{
							_003Cstart_003E5__1 = DateTime.Now;
							awaiter2 = _003C_003E4__this.readWriteNet.ReadInt16Async(_003C_003E4__this.textBox3.Text).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003Cbutton_read_short_Click_003Ed__16 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
								return;
							}
							goto IL_00e2;
						}
						_003Cstart_003E5__4 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.ReadInt16Async(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003Cbutton_read_short_Click_003Ed__16 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_01f7;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<short>>);
						num = (_003C_003E1__state = -1);
						goto IL_00e2;
					case 1:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<OperateResult<short[]>>);
							num = (_003C_003E1__state = -1);
							goto IL_01f7;
						}
						IL_00e2:
						_003C_003Es__3 = awaiter2.GetResult();
						_003Cread_003E5__2 = _003C_003Es__3;
						_003C_003Es__3 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__1).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__2, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__2 = null;
						goto IL_0270;
						IL_01f7:
						_003C_003Es__6 = awaiter.GetResult();
						_003Cread_003E5__5 = _003C_003Es__6;
						_003C_003Es__6 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__4).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__5, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__5 = null;
						goto IL_0270;
						IL_0270:
						_003C_003E4__this.button_read_short.Enabled = true;
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
		private sealed class _003Cbutton_read_string_Click_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private DateTime _003Cstart_003E5__1;

			private OperateResult<string> _003C_003Es__2;

			private DateTime _003Cstart_003E5__3;

			private OperateResult<string> _003Cread_003E5__4;

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
						goto IL_00de;
					}
					if (_003C_003E4__this.isAsync)
					{
						_003C_003E4__this.button_read_string.Enabled = false;
						_003Cstart_003E5__1 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.ReadStringAsync(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox1.Text), DemoUtils.GetEncodingFromIndex(_003C_003E4__this.comboBox_read_encoding.SelectedIndex)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_read_string_Click_003Ed__24 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_00de;
					}
					_003Cstart_003E5__3 = DateTime.Now;
					_003Cread_003E5__4 = _003C_003E4__this.readWriteNet.ReadString(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox1.Text), DemoUtils.GetEncodingFromIndex(_003C_003E4__this.comboBox_read_encoding.SelectedIndex));
					_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__3).TotalMilliseconds));
					DemoUtils.ReadResultRender(_003Cread_003E5__4, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
					_003Cread_003E5__4 = null;
					goto end_IL_0007;
					IL_00de:
					_003C_003Es__2 = awaiter.GetResult();
					DemoUtils.ReadResultRender(_003C_003Es__2, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
					_003C_003Es__2 = null;
					_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__1).TotalMilliseconds));
					_003C_003E4__this.button_read_string.Enabled = true;
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
		private sealed class _003Cbutton_read_uint_Click_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private DateTime _003Cstart_003E5__1;

			private OperateResult<uint> _003Cread_003E5__2;

			private OperateResult<uint> _003C_003Es__3;

			private DateTime _003Cstart_003E5__4;

			private OperateResult<uint[]> _003Cread_003E5__5;

			private OperateResult<uint[]> _003C_003Es__6;

			private DateTime _003Cstart_003E5__7;

			private OperateResult<uint> _003Cread_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult<uint[]> _003Cread_003E5__10;

			private TaskAwaiter<OperateResult<uint>> _003C_003Eu__1;

			private TaskAwaiter<OperateResult<uint[]>> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<uint>> awaiter2;
					TaskAwaiter<OperateResult<uint[]>> awaiter;
					switch (num)
					{
					default:
						if (!_003C_003E4__this.isAsync)
						{
							if (_003C_003E4__this.textBox5.Text == "1")
							{
								_003Cstart_003E5__7 = DateTime.Now;
								_003Cread_003E5__8 = _003C_003E4__this.readWriteNet.ReadUInt32(_003C_003E4__this.textBox3.Text);
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__7).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__8, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__8 = null;
							}
							else
							{
								_003Cstart_003E5__9 = DateTime.Now;
								_003Cread_003E5__10 = _003C_003E4__this.readWriteNet.ReadUInt32(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text));
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__10, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__10 = null;
							}
							break;
						}
						_003C_003E4__this.button_read_uint.Enabled = false;
						if (_003C_003E4__this.textBox5.Text == "1")
						{
							_003Cstart_003E5__1 = DateTime.Now;
							awaiter2 = _003C_003E4__this.readWriteNet.ReadUInt32Async(_003C_003E4__this.textBox3.Text).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003Cbutton_read_uint_Click_003Ed__19 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
								return;
							}
							goto IL_00e2;
						}
						_003Cstart_003E5__4 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.ReadUInt32Async(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003Cbutton_read_uint_Click_003Ed__19 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_01f7;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<uint>>);
						num = (_003C_003E1__state = -1);
						goto IL_00e2;
					case 1:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<OperateResult<uint[]>>);
							num = (_003C_003E1__state = -1);
							goto IL_01f7;
						}
						IL_00e2:
						_003C_003Es__3 = awaiter2.GetResult();
						_003Cread_003E5__2 = _003C_003Es__3;
						_003C_003Es__3 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__1).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__2, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__2 = null;
						goto IL_0270;
						IL_01f7:
						_003C_003Es__6 = awaiter.GetResult();
						_003Cread_003E5__5 = _003C_003Es__6;
						_003C_003Es__6 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__4).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__5, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__5 = null;
						goto IL_0270;
						IL_0270:
						_003C_003E4__this.button_read_uint.Enabled = true;
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
		private sealed class _003Cbutton_read_ulong_Click_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private DateTime _003Cstart_003E5__1;

			private OperateResult<ulong> _003Cread_003E5__2;

			private OperateResult<ulong> _003C_003Es__3;

			private DateTime _003Cstart_003E5__4;

			private OperateResult<ulong[]> _003Cread_003E5__5;

			private OperateResult<ulong[]> _003C_003Es__6;

			private DateTime _003Cstart_003E5__7;

			private OperateResult<ulong> _003Cread_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult<ulong[]> _003Cread_003E5__10;

			private TaskAwaiter<OperateResult<ulong>> _003C_003Eu__1;

			private TaskAwaiter<OperateResult<ulong[]>> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<ulong>> awaiter2;
					TaskAwaiter<OperateResult<ulong[]>> awaiter;
					switch (num)
					{
					default:
						if (!_003C_003E4__this.isAsync)
						{
							if (_003C_003E4__this.textBox5.Text == "1")
							{
								_003Cstart_003E5__7 = DateTime.Now;
								_003Cread_003E5__8 = _003C_003E4__this.readWriteNet.ReadUInt64(_003C_003E4__this.textBox3.Text);
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__7).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__8, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__8 = null;
							}
							else
							{
								_003Cstart_003E5__9 = DateTime.Now;
								_003Cread_003E5__10 = _003C_003E4__this.readWriteNet.ReadUInt64(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text));
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__10, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__10 = null;
							}
							break;
						}
						_003C_003E4__this.button_read_ulong.Enabled = false;
						if (_003C_003E4__this.textBox5.Text == "1")
						{
							_003Cstart_003E5__1 = DateTime.Now;
							awaiter2 = _003C_003E4__this.readWriteNet.ReadUInt64Async(_003C_003E4__this.textBox3.Text).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003Cbutton_read_ulong_Click_003Ed__21 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
								return;
							}
							goto IL_00e2;
						}
						_003Cstart_003E5__4 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.ReadUInt64Async(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003Cbutton_read_ulong_Click_003Ed__21 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_01f7;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<ulong>>);
						num = (_003C_003E1__state = -1);
						goto IL_00e2;
					case 1:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<OperateResult<ulong[]>>);
							num = (_003C_003E1__state = -1);
							goto IL_01f7;
						}
						IL_00e2:
						_003C_003Es__3 = awaiter2.GetResult();
						_003Cread_003E5__2 = _003C_003Es__3;
						_003C_003Es__3 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__1).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__2, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__2 = null;
						goto IL_0270;
						IL_01f7:
						_003C_003Es__6 = awaiter.GetResult();
						_003Cread_003E5__5 = _003C_003Es__6;
						_003C_003Es__6 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__4).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__5, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__5 = null;
						goto IL_0270;
						IL_0270:
						_003C_003E4__this.button_read_ulong.Enabled = true;
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
		private sealed class _003Cbutton_read_ushort_Click_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private DateTime _003Cstart_003E5__1;

			private OperateResult<ushort> _003Cread_003E5__2;

			private OperateResult<ushort> _003C_003Es__3;

			private DateTime _003Cstart_003E5__4;

			private OperateResult<ushort[]> _003Cread_003E5__5;

			private OperateResult<ushort[]> _003C_003Es__6;

			private DateTime _003Cstart_003E5__7;

			private OperateResult<ushort> _003Cread_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult<ushort[]> _003Cread_003E5__10;

			private TaskAwaiter<OperateResult<ushort>> _003C_003Eu__1;

			private TaskAwaiter<OperateResult<ushort[]>> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<ushort>> awaiter2;
					TaskAwaiter<OperateResult<ushort[]>> awaiter;
					switch (num)
					{
					default:
						if (!_003C_003E4__this.isAsync)
						{
							if (_003C_003E4__this.textBox5.Text == "1")
							{
								_003Cstart_003E5__7 = DateTime.Now;
								_003Cread_003E5__8 = _003C_003E4__this.readWriteNet.ReadUInt16(_003C_003E4__this.textBox3.Text);
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__7).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__8, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__8 = null;
							}
							else
							{
								_003Cstart_003E5__9 = DateTime.Now;
								_003Cread_003E5__10 = _003C_003E4__this.readWriteNet.ReadUInt16(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text));
								_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
								DemoUtils.ReadResultRender(_003Cread_003E5__10, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
								_003Cread_003E5__10 = null;
							}
							break;
						}
						_003C_003E4__this.button_read_ushort.Enabled = false;
						if (_003C_003E4__this.textBox5.Text == "1")
						{
							_003Cstart_003E5__1 = DateTime.Now;
							awaiter2 = _003C_003E4__this.readWriteNet.ReadUInt16Async(_003C_003E4__this.textBox3.Text).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003Cbutton_read_ushort_Click_003Ed__17 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
								return;
							}
							goto IL_00e2;
						}
						_003Cstart_003E5__4 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.ReadUInt16Async(_003C_003E4__this.textBox3.Text, ushort.Parse(_003C_003E4__this.textBox5.Text)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003Cbutton_read_ushort_Click_003Ed__17 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_01f7;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<ushort>>);
						num = (_003C_003E1__state = -1);
						goto IL_00e2;
					case 1:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<OperateResult<ushort[]>>);
							num = (_003C_003E1__state = -1);
							goto IL_01f7;
						}
						IL_00e2:
						_003C_003Es__3 = awaiter2.GetResult();
						_003Cread_003E5__2 = _003C_003Es__3;
						_003C_003Es__3 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__1).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__2, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__2 = null;
						goto IL_0270;
						IL_01f7:
						_003C_003Es__6 = awaiter.GetResult();
						_003Cread_003E5__5 = _003C_003Es__6;
						_003C_003Es__6 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__4).TotalMilliseconds));
						DemoUtils.ReadResultRender(_003Cread_003E5__5, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
						_003Cread_003E5__5 = null;
						goto IL_0270;
						IL_0270:
						_003C_003E4__this.button_read_ushort.Enabled = true;
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
		private sealed class _003Cbutton_write_bool_Click_003Ed__25 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private bool[] _003Cvalue_003E5__1;

			private DateTime _003Cstart_003E5__2;

			private OperateResult _003Cwrite_003E5__3;

			private OperateResult _003C_003Es__4;

			private DateTime _003Cstart_003E5__5;

			private OperateResult _003Cwrite_003E5__6;

			private Exception _003Cex_003E5__7;

			private bool _003Cvalue_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult _003Cwrite_003E5__10;

			private OperateResult _003C_003Es__11;

			private DateTime _003Cstart_003E5__12;

			private OperateResult _003Cwrite_003E5__13;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					switch (num)
					{
					default:
						if (_003C_003E4__this.textBox7.Text.StartsWith("[") && _003C_003E4__this.textBox7.Text.EndsWith("]"))
						{
							goto case 0;
						}
						if (!bool.TryParse(_003C_003E4__this.textBox7.Text, out _003Cvalue_003E5__8))
						{
							MessageBox.Show("Bool Data is not corrent: " + _003C_003E4__this.textBox7.Text);
							break;
						}
						if (!_003C_003E4__this.isAsync)
						{
							_003Cstart_003E5__12 = DateTime.Now;
							_003Cwrite_003E5__13 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8);
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__12).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__13, _003C_003E4__this.textBox8.Text);
							_003Cwrite_003E5__13 = null;
							break;
						}
						_003C_003E4__this.button_write_bool.Enabled = false;
						_003Cstart_003E5__9 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_write_bool_Click_003Ed__25 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_0358;
					case 0:
						try
						{
							TaskAwaiter<OperateResult> awaiter2;
							if (num != 0)
							{
								_003Cvalue_003E5__1 = _003C_003E4__this.textBox7.Text.ToStringArray<bool>();
								if (!_003C_003E4__this.isAsync)
								{
									_003Cstart_003E5__5 = DateTime.Now;
									_003Cwrite_003E5__6 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1);
									_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__5).TotalMilliseconds));
									DemoUtils.WriteResultRender(_003Cwrite_003E5__6, _003C_003E4__this.textBox8.Text);
									_003Cwrite_003E5__6 = null;
									goto IL_0236;
								}
								_003C_003E4__this.button_write_bool.Enabled = false;
								_003Cstart_003E5__2 = DateTime.Now;
								awaiter2 = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter2;
									_003Cbutton_write_bool_Click_003Ed__25 stateMachine = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
									return;
								}
							}
							else
							{
								awaiter2 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
								num = (_003C_003E1__state = -1);
							}
							_003C_003Es__4 = awaiter2.GetResult();
							_003Cwrite_003E5__3 = _003C_003Es__4;
							_003C_003Es__4 = null;
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__2).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__3, _003C_003E4__this.textBox8.Text);
							_003C_003E4__this.button_write_bool.Enabled = true;
							_003Cwrite_003E5__3 = null;
							goto IL_0236;
							IL_0236:
							_003Cvalue_003E5__1 = null;
						}
						catch (Exception ex)
						{
							Exception ex2 = _003Cex_003E5__7 = ex;
							MessageBox.Show("Bool Data is not corrent: " + _003C_003E4__this.textBox7.Text + Environment.NewLine + _003Cex_003E5__7.Message);
						}
						break;
					case 1:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
							num = (_003C_003E1__state = -1);
							goto IL_0358;
						}
						IL_0358:
						_003C_003Es__11 = awaiter.GetResult();
						_003Cwrite_003E5__10 = _003C_003Es__11;
						_003C_003Es__11 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
						DemoUtils.WriteResultRender(_003Cwrite_003E5__10, _003C_003E4__this.textBox8.Text);
						_003C_003E4__this.button_write_bool.Enabled = true;
						_003Cwrite_003E5__10 = null;
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
		private sealed class _003Cbutton_write_byte_Click_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private byte[] _003Cvalue_003E5__1;

			private DateTime _003Cstart_003E5__2;

			private OperateResult _003Cwrite_003E5__3;

			private OperateResult _003C_003Es__4;

			private DateTime _003Cstart_003E5__5;

			private OperateResult _003Cwrite_003E5__6;

			private Exception _003Cex_003E5__7;

			private byte _003Cvalue_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult _003Cwrite_003E5__10;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					if (num == 0 || (_003C_003E4__this.textBox7.Text.StartsWith("[") && _003C_003E4__this.textBox7.Text.EndsWith("]")))
					{
						try
						{
							TaskAwaiter<OperateResult> awaiter;
							if (num != 0)
							{
								_003Cvalue_003E5__1 = _003C_003E4__this.textBox7.Text.ToStringArray<byte>();
								if (!_003C_003E4__this.isAsync)
								{
									_003Cstart_003E5__5 = DateTime.Now;
									_003Cwrite_003E5__6 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1);
									_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__5).TotalMilliseconds));
									DemoUtils.WriteResultRender(_003Cwrite_003E5__6, _003C_003E4__this.textBox8.Text);
									_003Cwrite_003E5__6 = null;
									goto IL_022b;
								}
								_003C_003E4__this.button_write_short.Enabled = false;
								_003Cstart_003E5__2 = DateTime.Now;
								awaiter = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1).GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter;
									_003Cbutton_write_byte_Click_003Ed__26 stateMachine = this;
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
							_003C_003Es__4 = awaiter.GetResult();
							_003Cwrite_003E5__3 = _003C_003Es__4;
							_003C_003Es__4 = null;
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__2).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__3, _003C_003E4__this.textBox8.Text);
							_003C_003E4__this.button_write_short.Enabled = true;
							_003Cwrite_003E5__3 = null;
							goto IL_022b;
							IL_022b:
							_003Cvalue_003E5__1 = null;
						}
						catch (Exception ex)
						{
							Exception ex2 = _003Cex_003E5__7 = ex;
							MessageBox.Show("byte Data is not corrent: " + _003C_003E4__this.textBox7.Text + Environment.NewLine + _003Cex_003E5__7.Message);
						}
					}
					else if (byte.TryParse(_003C_003E4__this.textBox7.Text, out _003Cvalue_003E5__8))
					{
						_003Cstart_003E5__9 = DateTime.Now;
						_003Cwrite_003E5__10 = (OperateResult)_003C_003E4__this.writeByteMethod.Invoke(_003C_003E4__this.readWriteNet, new object[2]
						{
							_003C_003E4__this.textBox8.Text,
							_003Cvalue_003E5__8
						});
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
						DemoUtils.WriteResultRender(_003Cwrite_003E5__10, _003C_003E4__this.textBox8.Text);
						_003Cwrite_003E5__10 = null;
					}
					else
					{
						MessageBox.Show("Byte Data is not corrent: " + _003C_003E4__this.textBox7.Text);
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
		private sealed class _003Cbutton_write_double_Click_003Ed__34 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private double[] _003Cvalue_003E5__1;

			private DateTime _003Cstart_003E5__2;

			private OperateResult _003Cwrite_003E5__3;

			private OperateResult _003C_003Es__4;

			private DateTime _003Cstart_003E5__5;

			private OperateResult _003Cwrite_003E5__6;

			private Exception _003Cex_003E5__7;

			private double _003Cvalue_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult _003Cwrite_003E5__10;

			private OperateResult _003C_003Es__11;

			private DateTime _003Cstart_003E5__12;

			private OperateResult _003Cwrite_003E5__13;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					switch (num)
					{
					default:
						if (_003C_003E4__this.textBox7.Text.StartsWith("[") && _003C_003E4__this.textBox7.Text.EndsWith("]"))
						{
							goto case 0;
						}
						if (!double.TryParse(_003C_003E4__this.textBox7.Text, out _003Cvalue_003E5__8))
						{
							MessageBox.Show("double Data is not corrent: " + _003C_003E4__this.textBox7.Text);
							break;
						}
						if (!_003C_003E4__this.isAsync)
						{
							_003Cstart_003E5__12 = DateTime.Now;
							_003Cwrite_003E5__13 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8);
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__12).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__13, _003C_003E4__this.textBox8.Text);
							_003Cwrite_003E5__13 = null;
							break;
						}
						_003C_003E4__this.button_write_double.Enabled = false;
						_003Cstart_003E5__9 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_write_double_Click_003Ed__34 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_0358;
					case 0:
						try
						{
							TaskAwaiter<OperateResult> awaiter2;
							if (num != 0)
							{
								_003Cvalue_003E5__1 = _003C_003E4__this.textBox7.Text.ToStringArray<double>();
								if (!_003C_003E4__this.isAsync)
								{
									_003Cstart_003E5__5 = DateTime.Now;
									_003Cwrite_003E5__6 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1);
									_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__5).TotalMilliseconds));
									DemoUtils.WriteResultRender(_003Cwrite_003E5__6, _003C_003E4__this.textBox8.Text);
									_003Cwrite_003E5__6 = null;
									goto IL_0236;
								}
								_003C_003E4__this.button_write_uint.Enabled = false;
								_003Cstart_003E5__2 = DateTime.Now;
								awaiter2 = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter2;
									_003Cbutton_write_double_Click_003Ed__34 stateMachine = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
									return;
								}
							}
							else
							{
								awaiter2 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
								num = (_003C_003E1__state = -1);
							}
							_003C_003Es__4 = awaiter2.GetResult();
							_003Cwrite_003E5__3 = _003C_003Es__4;
							_003C_003Es__4 = null;
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__2).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__3, _003C_003E4__this.textBox8.Text);
							_003C_003E4__this.button_write_uint.Enabled = true;
							_003Cwrite_003E5__3 = null;
							goto IL_0236;
							IL_0236:
							_003Cvalue_003E5__1 = null;
						}
						catch (Exception ex)
						{
							Exception ex2 = _003Cex_003E5__7 = ex;
							MessageBox.Show("float Data is not corrent: " + _003C_003E4__this.textBox7.Text + Environment.NewLine + _003Cex_003E5__7.Message);
						}
						break;
					case 1:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
							num = (_003C_003E1__state = -1);
							goto IL_0358;
						}
						IL_0358:
						_003C_003Es__11 = awaiter.GetResult();
						_003Cwrite_003E5__10 = _003C_003Es__11;
						_003C_003Es__11 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
						DemoUtils.WriteResultRender(_003Cwrite_003E5__10, _003C_003E4__this.textBox8.Text);
						_003C_003E4__this.button_write_double.Enabled = true;
						_003Cwrite_003E5__10 = null;
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
		private sealed class _003Cbutton_write_float_Click_003Ed__33 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private float[] _003Cvalue_003E5__1;

			private DateTime _003Cstart_003E5__2;

			private OperateResult _003Cwrite_003E5__3;

			private OperateResult _003C_003Es__4;

			private DateTime _003Cstart_003E5__5;

			private OperateResult _003Cwrite_003E5__6;

			private Exception _003Cex_003E5__7;

			private float _003Cvalue_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult _003Cwrite_003E5__10;

			private OperateResult _003C_003Es__11;

			private DateTime _003Cstart_003E5__12;

			private OperateResult _003Cwrite_003E5__13;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					switch (num)
					{
					default:
						if (_003C_003E4__this.textBox7.Text.StartsWith("[") && _003C_003E4__this.textBox7.Text.EndsWith("]"))
						{
							goto case 0;
						}
						if (!float.TryParse(_003C_003E4__this.textBox7.Text, out _003Cvalue_003E5__8))
						{
							MessageBox.Show("float Data is not corrent: " + _003C_003E4__this.textBox7.Text);
							break;
						}
						if (!_003C_003E4__this.isAsync)
						{
							_003Cstart_003E5__12 = DateTime.Now;
							_003Cwrite_003E5__13 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8);
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__12).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__13, _003C_003E4__this.textBox8.Text);
							_003Cwrite_003E5__13 = null;
							break;
						}
						_003C_003E4__this.button_write_float.Enabled = false;
						_003Cstart_003E5__9 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_write_float_Click_003Ed__33 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_0358;
					case 0:
						try
						{
							TaskAwaiter<OperateResult> awaiter2;
							if (num != 0)
							{
								_003Cvalue_003E5__1 = _003C_003E4__this.textBox7.Text.ToStringArray<float>();
								if (!_003C_003E4__this.isAsync)
								{
									_003Cstart_003E5__5 = DateTime.Now;
									_003Cwrite_003E5__6 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1);
									_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__5).TotalMilliseconds));
									DemoUtils.WriteResultRender(_003Cwrite_003E5__6, _003C_003E4__this.textBox8.Text);
									_003Cwrite_003E5__6 = null;
									goto IL_0236;
								}
								_003C_003E4__this.button_write_uint.Enabled = false;
								_003Cstart_003E5__2 = DateTime.Now;
								awaiter2 = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter2;
									_003Cbutton_write_float_Click_003Ed__33 stateMachine = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
									return;
								}
							}
							else
							{
								awaiter2 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
								num = (_003C_003E1__state = -1);
							}
							_003C_003Es__4 = awaiter2.GetResult();
							_003Cwrite_003E5__3 = _003C_003Es__4;
							_003C_003Es__4 = null;
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__2).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__3, _003C_003E4__this.textBox8.Text);
							_003C_003E4__this.button_write_uint.Enabled = true;
							_003Cwrite_003E5__3 = null;
							goto IL_0236;
							IL_0236:
							_003Cvalue_003E5__1 = null;
						}
						catch (Exception ex)
						{
							Exception ex2 = _003Cex_003E5__7 = ex;
							MessageBox.Show("float Data is not corrent: " + _003C_003E4__this.textBox7.Text + Environment.NewLine + _003Cex_003E5__7.Message);
						}
						break;
					case 1:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
							num = (_003C_003E1__state = -1);
							goto IL_0358;
						}
						IL_0358:
						_003C_003Es__11 = awaiter.GetResult();
						_003Cwrite_003E5__10 = _003C_003Es__11;
						_003C_003Es__11 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
						DemoUtils.WriteResultRender(_003Cwrite_003E5__10, _003C_003E4__this.textBox8.Text);
						_003C_003E4__this.button_write_float.Enabled = true;
						_003Cwrite_003E5__10 = null;
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
		private sealed class _003Cbutton_write_hex_Click_003Ed__36 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private DateTime _003Cstart_003E5__1;

			private OperateResult _003Cwrite_003E5__2;

			private OperateResult _003C_003Es__3;

			private DateTime _003Cstart_003E5__4;

			private OperateResult _003Cwrite_003E5__5;

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
						goto IL_00c9;
					}
					if (_003C_003E4__this.isAsync)
					{
						_003C_003E4__this.button_write_string.Enabled = false;
						_003Cstart_003E5__1 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003C_003E4__this.textBox7.Text.ToHexBytes()).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_write_hex_Click_003Ed__36 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_00c9;
					}
					_003Cstart_003E5__4 = DateTime.Now;
					_003Cwrite_003E5__5 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003C_003E4__this.textBox7.Text.ToHexBytes());
					_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__4).TotalMilliseconds));
					DemoUtils.WriteResultRender(_003Cwrite_003E5__5, _003C_003E4__this.textBox8.Text);
					_003Cwrite_003E5__5 = null;
					goto end_IL_0007;
					IL_00c9:
					_003C_003Es__3 = awaiter.GetResult();
					_003Cwrite_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__1).TotalMilliseconds));
					DemoUtils.WriteResultRender(_003Cwrite_003E5__2, _003C_003E4__this.textBox8.Text);
					_003C_003E4__this.button_write_string.Enabled = true;
					_003Cwrite_003E5__2 = null;
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
		private sealed class _003Cbutton_write_int_Click_003Ed__29 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private int[] _003Cvalue_003E5__1;

			private DateTime _003Cstart_003E5__2;

			private OperateResult _003Cwrite_003E5__3;

			private OperateResult _003C_003Es__4;

			private DateTime _003Cstart_003E5__5;

			private OperateResult _003Cwrite_003E5__6;

			private Exception _003Cex_003E5__7;

			private int _003Cvalue_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult _003Cwrite_003E5__10;

			private OperateResult _003C_003Es__11;

			private DateTime _003Cstart_003E5__12;

			private OperateResult _003Cwrite_003E5__13;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					switch (num)
					{
					default:
						if (_003C_003E4__this.textBox7.Text.StartsWith("[") && _003C_003E4__this.textBox7.Text.EndsWith("]"))
						{
							goto case 0;
						}
						if (!int.TryParse(_003C_003E4__this.textBox7.Text, out _003Cvalue_003E5__8))
						{
							MessageBox.Show("int Data is not corrent: " + _003C_003E4__this.textBox7.Text);
							break;
						}
						if (!_003C_003E4__this.isAsync)
						{
							_003Cstart_003E5__12 = DateTime.Now;
							_003Cwrite_003E5__13 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8);
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__12).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__13, _003C_003E4__this.textBox8.Text);
							_003Cwrite_003E5__13 = null;
							break;
						}
						_003C_003E4__this.button_write_int.Enabled = false;
						_003Cstart_003E5__9 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_write_int_Click_003Ed__29 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_0358;
					case 0:
						try
						{
							TaskAwaiter<OperateResult> awaiter2;
							if (num != 0)
							{
								_003Cvalue_003E5__1 = _003C_003E4__this.textBox7.Text.ToStringArray<int>();
								if (!_003C_003E4__this.isAsync)
								{
									_003Cstart_003E5__5 = DateTime.Now;
									_003Cwrite_003E5__6 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1);
									_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__5).TotalMilliseconds));
									DemoUtils.WriteResultRender(_003Cwrite_003E5__6, _003C_003E4__this.textBox8.Text);
									_003Cwrite_003E5__6 = null;
									goto IL_0236;
								}
								_003C_003E4__this.button_write_int.Enabled = false;
								_003Cstart_003E5__2 = DateTime.Now;
								awaiter2 = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter2;
									_003Cbutton_write_int_Click_003Ed__29 stateMachine = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
									return;
								}
							}
							else
							{
								awaiter2 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
								num = (_003C_003E1__state = -1);
							}
							_003C_003Es__4 = awaiter2.GetResult();
							_003Cwrite_003E5__3 = _003C_003Es__4;
							_003C_003Es__4 = null;
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__2).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__3, _003C_003E4__this.textBox8.Text);
							_003C_003E4__this.button_write_int.Enabled = true;
							_003Cwrite_003E5__3 = null;
							goto IL_0236;
							IL_0236:
							_003Cvalue_003E5__1 = null;
						}
						catch (Exception ex)
						{
							Exception ex2 = _003Cex_003E5__7 = ex;
							MessageBox.Show("int Data is not corrent: " + _003C_003E4__this.textBox7.Text + Environment.NewLine + _003Cex_003E5__7.Message);
						}
						break;
					case 1:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
							num = (_003C_003E1__state = -1);
							goto IL_0358;
						}
						IL_0358:
						_003C_003Es__11 = awaiter.GetResult();
						_003Cwrite_003E5__10 = _003C_003Es__11;
						_003C_003Es__11 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
						DemoUtils.WriteResultRender(_003Cwrite_003E5__10, _003C_003E4__this.textBox8.Text);
						_003C_003E4__this.button_write_int.Enabled = true;
						_003Cwrite_003E5__10 = null;
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
		private sealed class _003Cbutton_write_long_Click_003Ed__31 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private long[] _003Cvalue_003E5__1;

			private DateTime _003Cstart_003E5__2;

			private OperateResult _003Cwrite_003E5__3;

			private OperateResult _003C_003Es__4;

			private DateTime _003Cstart_003E5__5;

			private OperateResult _003Cwrite_003E5__6;

			private Exception _003Cex_003E5__7;

			private long _003Cvalue_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult _003Cwrite_003E5__10;

			private OperateResult _003C_003Es__11;

			private DateTime _003Cstart_003E5__12;

			private OperateResult _003Cwrite_003E5__13;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					switch (num)
					{
					default:
						if (_003C_003E4__this.textBox7.Text.StartsWith("[") && _003C_003E4__this.textBox7.Text.EndsWith("]"))
						{
							goto case 0;
						}
						if (!long.TryParse(_003C_003E4__this.textBox7.Text, out _003Cvalue_003E5__8))
						{
							MessageBox.Show("long Data is not corrent: " + _003C_003E4__this.textBox7.Text);
							break;
						}
						if (!_003C_003E4__this.isAsync)
						{
							_003Cstart_003E5__12 = DateTime.Now;
							_003Cwrite_003E5__13 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8);
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__12).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__13, _003C_003E4__this.textBox8.Text);
							_003Cwrite_003E5__13 = null;
							break;
						}
						_003C_003E4__this.button_write_long.Enabled = false;
						_003Cstart_003E5__9 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_write_long_Click_003Ed__31 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_0358;
					case 0:
						try
						{
							TaskAwaiter<OperateResult> awaiter2;
							if (num != 0)
							{
								_003Cvalue_003E5__1 = _003C_003E4__this.textBox7.Text.ToStringArray<long>();
								if (!_003C_003E4__this.isAsync)
								{
									_003Cstart_003E5__5 = DateTime.Now;
									_003Cwrite_003E5__6 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1);
									_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__5).TotalMilliseconds));
									DemoUtils.WriteResultRender(_003Cwrite_003E5__6, _003C_003E4__this.textBox8.Text);
									_003Cwrite_003E5__6 = null;
									goto IL_0236;
								}
								_003C_003E4__this.button_write_uint.Enabled = false;
								_003Cstart_003E5__2 = DateTime.Now;
								awaiter2 = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter2;
									_003Cbutton_write_long_Click_003Ed__31 stateMachine = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
									return;
								}
							}
							else
							{
								awaiter2 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
								num = (_003C_003E1__state = -1);
							}
							_003C_003Es__4 = awaiter2.GetResult();
							_003Cwrite_003E5__3 = _003C_003Es__4;
							_003C_003Es__4 = null;
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__2).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__3, _003C_003E4__this.textBox8.Text);
							_003C_003E4__this.button_write_uint.Enabled = true;
							_003Cwrite_003E5__3 = null;
							goto IL_0236;
							IL_0236:
							_003Cvalue_003E5__1 = null;
						}
						catch (Exception ex)
						{
							Exception ex2 = _003Cex_003E5__7 = ex;
							MessageBox.Show("long Data is not corrent: " + _003C_003E4__this.textBox7.Text + Environment.NewLine + _003Cex_003E5__7.Message);
						}
						break;
					case 1:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
							num = (_003C_003E1__state = -1);
							goto IL_0358;
						}
						IL_0358:
						_003C_003Es__11 = awaiter.GetResult();
						_003Cwrite_003E5__10 = _003C_003Es__11;
						_003C_003Es__11 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
						DemoUtils.WriteResultRender(_003Cwrite_003E5__10, _003C_003E4__this.textBox8.Text);
						_003C_003E4__this.button_write_long.Enabled = true;
						_003Cwrite_003E5__10 = null;
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
		private sealed class _003Cbutton_write_short_Click_003Ed__27 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private short[] _003Cvalue_003E5__1;

			private DateTime _003Cstart_003E5__2;

			private OperateResult _003Cwrite_003E5__3;

			private OperateResult _003C_003Es__4;

			private DateTime _003Cstart_003E5__5;

			private OperateResult _003Cwrite_003E5__6;

			private Exception _003Cex_003E5__7;

			private short _003Cvalue_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult _003Cwrite_003E5__10;

			private OperateResult _003C_003Es__11;

			private DateTime _003Cstart_003E5__12;

			private OperateResult _003Cwrite_003E5__13;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					switch (num)
					{
					default:
						if (_003C_003E4__this.textBox7.Text.StartsWith("[") && _003C_003E4__this.textBox7.Text.EndsWith("]"))
						{
							goto case 0;
						}
						if (!short.TryParse(_003C_003E4__this.textBox7.Text, out _003Cvalue_003E5__8))
						{
							MessageBox.Show("short Data is not corrent: " + _003C_003E4__this.textBox7.Text);
							break;
						}
						if (!_003C_003E4__this.isAsync)
						{
							_003Cstart_003E5__12 = DateTime.Now;
							_003Cwrite_003E5__13 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8);
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__12).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__13, _003C_003E4__this.textBox8.Text);
							_003Cwrite_003E5__13 = null;
							break;
						}
						_003C_003E4__this.button_write_short.Enabled = false;
						_003Cstart_003E5__9 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_write_short_Click_003Ed__27 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_0358;
					case 0:
						try
						{
							TaskAwaiter<OperateResult> awaiter2;
							if (num != 0)
							{
								_003Cvalue_003E5__1 = _003C_003E4__this.textBox7.Text.ToStringArray<short>();
								if (!_003C_003E4__this.isAsync)
								{
									_003Cstart_003E5__5 = DateTime.Now;
									_003Cwrite_003E5__6 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1);
									_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__5).TotalMilliseconds));
									DemoUtils.WriteResultRender(_003Cwrite_003E5__6, _003C_003E4__this.textBox8.Text);
									_003Cwrite_003E5__6 = null;
									goto IL_0236;
								}
								_003C_003E4__this.button_write_short.Enabled = false;
								_003Cstart_003E5__2 = DateTime.Now;
								awaiter2 = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter2;
									_003Cbutton_write_short_Click_003Ed__27 stateMachine = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
									return;
								}
							}
							else
							{
								awaiter2 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
								num = (_003C_003E1__state = -1);
							}
							_003C_003Es__4 = awaiter2.GetResult();
							_003Cwrite_003E5__3 = _003C_003Es__4;
							_003C_003Es__4 = null;
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__2).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__3, _003C_003E4__this.textBox8.Text);
							_003C_003E4__this.button_write_short.Enabled = true;
							_003Cwrite_003E5__3 = null;
							goto IL_0236;
							IL_0236:
							_003Cvalue_003E5__1 = null;
						}
						catch (Exception ex)
						{
							Exception ex2 = _003Cex_003E5__7 = ex;
							MessageBox.Show("short Data is not corrent: " + _003C_003E4__this.textBox7.Text + Environment.NewLine + _003Cex_003E5__7.Message);
						}
						break;
					case 1:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
							num = (_003C_003E1__state = -1);
							goto IL_0358;
						}
						IL_0358:
						_003C_003Es__11 = awaiter.GetResult();
						_003Cwrite_003E5__10 = _003C_003Es__11;
						_003C_003Es__11 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
						DemoUtils.WriteResultRender(_003Cwrite_003E5__10, _003C_003E4__this.textBox8.Text);
						_003C_003E4__this.button_write_short.Enabled = true;
						_003Cwrite_003E5__10 = null;
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
		private sealed class _003Cbutton_write_string_Click_003Ed__35 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private DateTime _003Cstart_003E5__1;

			private OperateResult _003Cwrite_003E5__2;

			private OperateResult _003C_003Es__3;

			private OperateResult _003C_003Es__4;

			private DateTime _003Cstart_003E5__5;

			private OperateResult _003Cwrite_003E5__6;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter2;
					TaskAwaiter<OperateResult> awaiter;
					switch (num)
					{
					default:
						if (!_003C_003E4__this.isAsync)
						{
							_003Cstart_003E5__5 = DateTime.Now;
							if (_003C_003E4__this.comboBox_write_Encoding.SelectedIndex == 0)
							{
								_003Cwrite_003E5__6 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003C_003E4__this.textBox7.Text);
							}
							else
							{
								_003Cwrite_003E5__6 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003C_003E4__this.textBox7.Text, DemoUtils.GetEncodingFromIndex(_003C_003E4__this.comboBox_write_Encoding.SelectedIndex));
							}
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__5).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__6, _003C_003E4__this.textBox8.Text);
							_003Cwrite_003E5__6 = null;
							break;
						}
						_003C_003E4__this.button_write_string.Enabled = false;
						_003Cstart_003E5__1 = DateTime.Now;
						if (_003C_003E4__this.comboBox_write_Encoding.SelectedIndex == 0)
						{
							awaiter2 = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003C_003E4__this.textBox7.Text).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003Cbutton_write_string_Click_003Ed__35 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
								return;
							}
							goto IL_00ea;
						}
						awaiter = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003C_003E4__this.textBox7.Text, DemoUtils.GetEncodingFromIndex(_003C_003E4__this.comboBox_write_Encoding.SelectedIndex)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_write_string_Click_003Ed__35 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_01aa;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
						num = (_003C_003E1__state = -1);
						goto IL_00ea;
					case 1:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
							num = (_003C_003E1__state = -1);
							goto IL_01aa;
						}
						IL_00ea:
						_003C_003Es__3 = awaiter2.GetResult();
						_003Cwrite_003E5__2 = _003C_003Es__3;
						_003C_003Es__3 = null;
						goto IL_01ca;
						IL_01aa:
						_003C_003Es__4 = awaiter.GetResult();
						_003Cwrite_003E5__2 = _003C_003Es__4;
						_003C_003Es__4 = null;
						goto IL_01ca;
						IL_01ca:
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__1).TotalMilliseconds));
						DemoUtils.WriteResultRender(_003Cwrite_003E5__2, _003C_003E4__this.textBox8.Text);
						_003C_003E4__this.button_write_string.Enabled = true;
						_003Cwrite_003E5__2 = null;
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
		private sealed class _003Cbutton_write_uint_Click_003Ed__30 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private uint[] _003Cvalue_003E5__1;

			private DateTime _003Cstart_003E5__2;

			private OperateResult _003Cwrite_003E5__3;

			private OperateResult _003C_003Es__4;

			private DateTime _003Cstart_003E5__5;

			private OperateResult _003Cwrite_003E5__6;

			private Exception _003Cex_003E5__7;

			private uint _003Cvalue_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult _003Cwrite_003E5__10;

			private OperateResult _003C_003Es__11;

			private DateTime _003Cstart_003E5__12;

			private OperateResult _003Cwrite_003E5__13;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					switch (num)
					{
					default:
						if (_003C_003E4__this.textBox7.Text.StartsWith("[") && _003C_003E4__this.textBox7.Text.EndsWith("]"))
						{
							goto case 0;
						}
						if (!uint.TryParse(_003C_003E4__this.textBox7.Text, out _003Cvalue_003E5__8))
						{
							MessageBox.Show("uint Data is not corrent: " + _003C_003E4__this.textBox7.Text);
							break;
						}
						if (!_003C_003E4__this.isAsync)
						{
							_003Cstart_003E5__12 = DateTime.Now;
							_003Cwrite_003E5__13 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8);
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__12).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__13, _003C_003E4__this.textBox8.Text);
							_003Cwrite_003E5__13 = null;
							break;
						}
						_003C_003E4__this.button_write_uint.Enabled = false;
						_003Cstart_003E5__9 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_write_uint_Click_003Ed__30 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_0358;
					case 0:
						try
						{
							TaskAwaiter<OperateResult> awaiter2;
							if (num != 0)
							{
								_003Cvalue_003E5__1 = _003C_003E4__this.textBox7.Text.ToStringArray<uint>();
								if (!_003C_003E4__this.isAsync)
								{
									_003Cstart_003E5__5 = DateTime.Now;
									_003Cwrite_003E5__6 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1);
									_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__5).TotalMilliseconds));
									DemoUtils.WriteResultRender(_003Cwrite_003E5__6, _003C_003E4__this.textBox8.Text);
									_003Cwrite_003E5__6 = null;
									goto IL_0236;
								}
								_003C_003E4__this.button_write_uint.Enabled = false;
								_003Cstart_003E5__2 = DateTime.Now;
								awaiter2 = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter2;
									_003Cbutton_write_uint_Click_003Ed__30 stateMachine = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
									return;
								}
							}
							else
							{
								awaiter2 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
								num = (_003C_003E1__state = -1);
							}
							_003C_003Es__4 = awaiter2.GetResult();
							_003Cwrite_003E5__3 = _003C_003Es__4;
							_003C_003Es__4 = null;
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__2).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__3, _003C_003E4__this.textBox8.Text);
							_003C_003E4__this.button_write_uint.Enabled = true;
							_003Cwrite_003E5__3 = null;
							goto IL_0236;
							IL_0236:
							_003Cvalue_003E5__1 = null;
						}
						catch (Exception ex)
						{
							Exception ex2 = _003Cex_003E5__7 = ex;
							MessageBox.Show("uint Data is not corrent: " + _003C_003E4__this.textBox7.Text + Environment.NewLine + _003Cex_003E5__7.Message);
						}
						break;
					case 1:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
							num = (_003C_003E1__state = -1);
							goto IL_0358;
						}
						IL_0358:
						_003C_003Es__11 = awaiter.GetResult();
						_003Cwrite_003E5__10 = _003C_003Es__11;
						_003C_003Es__11 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
						DemoUtils.WriteResultRender(_003Cwrite_003E5__10, _003C_003E4__this.textBox8.Text);
						_003C_003E4__this.button_write_uint.Enabled = true;
						_003Cwrite_003E5__10 = null;
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
		private sealed class _003Cbutton_write_ulong_Click_003Ed__32 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private ulong[] _003Cvalue_003E5__1;

			private DateTime _003Cstart_003E5__2;

			private OperateResult _003Cwrite_003E5__3;

			private OperateResult _003C_003Es__4;

			private DateTime _003Cstart_003E5__5;

			private OperateResult _003Cwrite_003E5__6;

			private Exception _003Cex_003E5__7;

			private ulong _003Cvalue_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult _003Cwrite_003E5__10;

			private OperateResult _003C_003Es__11;

			private DateTime _003Cstart_003E5__12;

			private OperateResult _003Cwrite_003E5__13;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					switch (num)
					{
					default:
						if (_003C_003E4__this.textBox7.Text.StartsWith("[") && _003C_003E4__this.textBox7.Text.EndsWith("]"))
						{
							goto case 0;
						}
						if (!ulong.TryParse(_003C_003E4__this.textBox7.Text, out _003Cvalue_003E5__8))
						{
							MessageBox.Show("ulong Data is not corrent: " + _003C_003E4__this.textBox7.Text);
							break;
						}
						if (!_003C_003E4__this.isAsync)
						{
							_003Cstart_003E5__12 = DateTime.Now;
							_003Cwrite_003E5__13 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8);
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__12).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__13, _003C_003E4__this.textBox8.Text);
							_003Cwrite_003E5__13 = null;
							break;
						}
						_003C_003E4__this.button_write_ulong.Enabled = false;
						_003Cstart_003E5__9 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_write_ulong_Click_003Ed__32 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_0358;
					case 0:
						try
						{
							TaskAwaiter<OperateResult> awaiter2;
							if (num != 0)
							{
								_003Cvalue_003E5__1 = _003C_003E4__this.textBox7.Text.ToStringArray<ulong>();
								if (!_003C_003E4__this.isAsync)
								{
									_003Cstart_003E5__5 = DateTime.Now;
									_003Cwrite_003E5__6 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1);
									_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__5).TotalMilliseconds));
									DemoUtils.WriteResultRender(_003Cwrite_003E5__6, _003C_003E4__this.textBox8.Text);
									_003Cwrite_003E5__6 = null;
									goto IL_0236;
								}
								_003C_003E4__this.button_write_uint.Enabled = false;
								_003Cstart_003E5__2 = DateTime.Now;
								awaiter2 = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter2;
									_003Cbutton_write_ulong_Click_003Ed__32 stateMachine = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
									return;
								}
							}
							else
							{
								awaiter2 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
								num = (_003C_003E1__state = -1);
							}
							_003C_003Es__4 = awaiter2.GetResult();
							_003Cwrite_003E5__3 = _003C_003Es__4;
							_003C_003Es__4 = null;
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__2).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__3, _003C_003E4__this.textBox8.Text);
							_003C_003E4__this.button_write_uint.Enabled = true;
							_003Cwrite_003E5__3 = null;
							goto IL_0236;
							IL_0236:
							_003Cvalue_003E5__1 = null;
						}
						catch (Exception ex)
						{
							Exception ex2 = _003Cex_003E5__7 = ex;
							MessageBox.Show("ulong Data is not corrent: " + _003C_003E4__this.textBox7.Text + Environment.NewLine + _003Cex_003E5__7.Message);
						}
						break;
					case 1:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
							num = (_003C_003E1__state = -1);
							goto IL_0358;
						}
						IL_0358:
						_003C_003Es__11 = awaiter.GetResult();
						_003Cwrite_003E5__10 = _003C_003Es__11;
						_003C_003Es__11 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
						DemoUtils.WriteResultRender(_003Cwrite_003E5__10, _003C_003E4__this.textBox8.Text);
						_003C_003E4__this.button_write_ulong.Enabled = true;
						_003Cwrite_003E5__10 = null;
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
		private sealed class _003Cbutton_write_ushort_Click_003Ed__28 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public UserControlReadWriteOp _003C_003E4__this;

			private ushort[] _003Cvalue_003E5__1;

			private DateTime _003Cstart_003E5__2;

			private OperateResult _003Cwrite_003E5__3;

			private OperateResult _003C_003Es__4;

			private DateTime _003Cstart_003E5__5;

			private OperateResult _003Cwrite_003E5__6;

			private Exception _003Cex_003E5__7;

			private ushort _003Cvalue_003E5__8;

			private DateTime _003Cstart_003E5__9;

			private OperateResult _003Cwrite_003E5__10;

			private OperateResult _003C_003Es__11;

			private DateTime _003Cstart_003E5__12;

			private OperateResult _003Cwrite_003E5__13;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					switch (num)
					{
					default:
						if (_003C_003E4__this.textBox7.Text.StartsWith("[") && _003C_003E4__this.textBox7.Text.EndsWith("]"))
						{
							goto case 0;
						}
						if (!ushort.TryParse(_003C_003E4__this.textBox7.Text, out _003Cvalue_003E5__8))
						{
							MessageBox.Show("ushort Data is not corrent: " + _003C_003E4__this.textBox7.Text);
							break;
						}
						if (!_003C_003E4__this.isAsync)
						{
							_003Cstart_003E5__12 = DateTime.Now;
							_003Cwrite_003E5__13 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8);
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__12).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__13, _003C_003E4__this.textBox8.Text);
							_003Cwrite_003E5__13 = null;
							break;
						}
						_003C_003E4__this.button_write_ushort.Enabled = false;
						_003Cstart_003E5__9 = DateTime.Now;
						awaiter = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__8).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_write_ushort_Click_003Ed__28 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_0358;
					case 0:
						try
						{
							TaskAwaiter<OperateResult> awaiter2;
							if (num != 0)
							{
								_003Cvalue_003E5__1 = _003C_003E4__this.textBox7.Text.ToStringArray<ushort>();
								if (!_003C_003E4__this.isAsync)
								{
									_003Cstart_003E5__5 = DateTime.Now;
									_003Cwrite_003E5__6 = _003C_003E4__this.readWriteNet.Write(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1);
									_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__5).TotalMilliseconds));
									DemoUtils.WriteResultRender(_003Cwrite_003E5__6, _003C_003E4__this.textBox8.Text);
									_003Cwrite_003E5__6 = null;
									goto IL_0236;
								}
								_003C_003E4__this.button_write_ushort.Enabled = false;
								_003Cstart_003E5__2 = DateTime.Now;
								awaiter2 = _003C_003E4__this.readWriteNet.WriteAsync(_003C_003E4__this.textBox8.Text, _003Cvalue_003E5__1).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter2;
									_003Cbutton_write_ushort_Click_003Ed__28 stateMachine = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
									return;
								}
							}
							else
							{
								awaiter2 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
								num = (_003C_003E1__state = -1);
							}
							_003C_003Es__4 = awaiter2.GetResult();
							_003Cwrite_003E5__3 = _003C_003Es__4;
							_003C_003Es__4 = null;
							_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__2).TotalMilliseconds));
							DemoUtils.WriteResultRender(_003Cwrite_003E5__3, _003C_003E4__this.textBox8.Text);
							_003C_003E4__this.button_write_ushort.Enabled = true;
							_003Cwrite_003E5__3 = null;
							goto IL_0236;
							IL_0236:
							_003Cvalue_003E5__1 = null;
						}
						catch (Exception ex)
						{
							Exception ex2 = _003Cex_003E5__7 = ex;
							MessageBox.Show("ushort Data is not corrent: " + _003C_003E4__this.textBox7.Text + Environment.NewLine + _003Cex_003E5__7.Message);
						}
						break;
					case 1:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
							num = (_003C_003E1__state = -1);
							goto IL_0358;
						}
						IL_0358:
						_003C_003Es__11 = awaiter.GetResult();
						_003Cwrite_003E5__10 = _003C_003Es__11;
						_003C_003Es__11 = null;
						_003C_003E4__this.SetTimeSpend(Convert.ToInt32((DateTime.Now - _003Cstart_003E5__9).TotalMilliseconds));
						DemoUtils.WriteResultRender(_003Cwrite_003E5__10, _003C_003E4__this.textBox8.Text);
						_003C_003E4__this.button_write_ushort.Enabled = true;
						_003Cwrite_003E5__10 = null;
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

		private string[] encodings = DemoUtils.GetEncodings();

		private string address = string.Empty;

		private IReadWriteNet readWriteNet;

		private bool isAsync = false;

		private MethodInfo readByteMethod = null;

		private MethodInfo writeByteMethod = null;

		private ValueLimit valueLimit = default(ValueLimit);

		private IContainer components = null;

		private GroupBox groupBox2;

		private Label label19;

		private Button button_write_string;

		private Button button_write_double;

		private Button button_write_float;

		private Button button_write_ulong;

		private Button button_write_long;

		private Button button_write_uint;

		private Button button_write_int;

		private Button button_write_ushort;

		private Button button_write_short;

		private Button button_write_byte;

		private Button button_write_bool;

		private TextBox textBox7;

		private Label label9;

		private TextBox textBox8;

		private Label label10;

		private GroupBox groupBox1;

		private TextBox textBox5;

		private Button button_read_string;

		private Button button_read_double;

		private Button button_read_float;

		private Button button_read_ulong;

		private Button button_read_long;

		private Button button_read_uint;

		private Button button_read_int;

		private Button button_read_ushort;

		private Button button_read_short;

		private Button button_read_byte;

		private Button button_read_bool;

		private TextBox textBox4;

		private Label label7;

		private TextBox textBox3;

		private Label label6;

		private TextBox textBox1;

		private Label label8;

		private Button button1;

		private Button button_write_hex;

		private Label label5;

		private Label label11;

		private Label label3;

		private Label label4;

		private Label label2;

		private Label label1;

		private ComboBox comboBox_write_Encoding;

		private Label label13;

		private ComboBox comboBox_read_encoding;

		private Label label12;

		public UserControlReadWriteOp()
		{
			InitializeComponent();
		}

		private void UserControlReadWriteOp_Load(object sender, EventArgs e)
		{
			Language(Program.Language);
			comboBox_read_encoding.DataSource = encodings;
			comboBox_write_Encoding.DataSource = encodings;
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "Curve Monitor";
				label6.Text = "address:";
				label7.Text = "result:";
				label8.Text = "length:";
				button_read_bool.Text = "Read Bit";
				button_read_byte.Text = "r-byte";
				button_read_short.Text = "r-short";
				button_read_ushort.Text = "r-ushort";
				button_read_int.Text = "r-int";
				button_read_uint.Text = "r-uint";
				button_read_long.Text = "r-long";
				button_read_ulong.Text = "r-ulong";
				button_read_float.Text = "r-float";
				button_read_double.Text = "r-double";
				button_read_string.Text = "r-string";
				label10.Text = "Address:";
				label9.Text = "Value:";
				label19.Text = "Note: The value of the string needs to be converted\r\nif array：[1,2,3]";
				button_write_bool.Text = "Write Bit";
				button_write_short.Text = "w-short";
				button_write_ushort.Text = "w-ushort";
				button_write_int.Text = "w-int";
				button_write_uint.Text = "w-uint";
				button_write_long.Text = "w-long";
				button_write_ulong.Text = "w-ulong";
				button_write_float.Text = "w-float";
				button_write_double.Text = "w-double";
				button_write_string.Text = "w-string";
				button_write_hex.Text = "w-hex";
				groupBox1.Text = "Single Data Read test";
				groupBox2.Text = "Single Data Write test";
				button_write_byte.Text = "w-byte";
				button1.Text = "Curve";
				label1.Text = "Time-Cost:";
				label12.Text = "Encoding:";
				label13.Text = "Encoding:";
			}
		}

		public void EnableRKC()
		{
			button_read_bool.Enabled = false;
			button_read_byte.Enabled = false;
			button_read_short.Enabled = false;
			button_read_ushort.Enabled = false;
			button_read_int.Enabled = false;
			button_read_uint.Enabled = false;
			button_read_long.Enabled = false;
			button_read_ulong.Enabled = false;
			button_read_float.Enabled = false;
			button_read_string.Enabled = false;
			button_write_bool.Enabled = false;
			button_write_byte.Enabled = false;
			button_write_short.Enabled = false;
			button_write_ushort.Enabled = false;
			button_write_int.Enabled = false;
			button_write_uint.Enabled = false;
			button_write_long.Enabled = false;
			button_write_ulong.Enabled = false;
			button_write_float.Enabled = false;
			button_write_hex.Enabled = false;
			button_write_string.Enabled = false;
		}

		public void SetReadWriteNet(IReadWriteNet readWrite, string address, bool isAsync = false, int strLength = 10)
		{
			this.isAsync = isAsync;
			this.address = address;
			if (string.IsNullOrEmpty(textBox3.Text))
			{
				textBox3.Text = address;
			}
			if (string.IsNullOrEmpty(textBox8.Text))
			{
				textBox8.Text = address;
			}
			textBox1.Text = strLength.ToString();
			readWriteNet = readWrite;
			Type type = readWrite.GetType();
			readByteMethod = type.GetMethod("ReadByte", new Type[1]
			{
				typeof(string)
			});
			if (readByteMethod == null)
			{
				button_read_byte.Enabled = false;
			}
			try
			{
				writeByteMethod = type.GetMethod("Write", new Type[2]
				{
					typeof(string),
					typeof(byte)
				});
				if (writeByteMethod == null)
				{
					button_write_byte.Enabled = false;
				}
			}
			catch
			{
				button_write_byte.Enabled = false;
			}
		}

		public string GetWriteAddress()
		{
			return textBox8.Text;
		}

		private void SetTimeSpend(int millseconds)
		{
			valueLimit.SetNewValue((double)millseconds);
			label2.Text = string.Format("{0} ms", valueLimit.Current);
			label3.Text = string.Format("{0} ms", valueLimit.MaxValue);
			label5.Text = string.Format("{0} ms", valueLimit.MinValue);
		}

		[AsyncStateMachine(typeof(_003Cbutton_read_bool_Click_003Ed__14))]
		[DebuggerStepThrough]
		private void button_read_bool_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_bool_Click_003Ed__14 stateMachine = new _003Cbutton_read_bool_Click_003Ed__14();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button_read_byte_Click(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;
			OperateResult<byte> result = (OperateResult<byte>)readByteMethod.Invoke(readWriteNet, new object[1]
			{
				textBox3.Text
			});
			SetTimeSpend(Convert.ToInt32((DateTime.Now - now).TotalMilliseconds));
			DemoUtils.ReadResultRender(result, textBox3.Text, textBox4);
		}

		[AsyncStateMachine(typeof(_003Cbutton_read_short_Click_003Ed__16))]
		[DebuggerStepThrough]
		private void button_read_short_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_short_Click_003Ed__16 stateMachine = new _003Cbutton_read_short_Click_003Ed__16();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_read_ushort_Click_003Ed__17))]
		[DebuggerStepThrough]
		private void button_read_ushort_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_ushort_Click_003Ed__17 stateMachine = new _003Cbutton_read_ushort_Click_003Ed__17();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_read_int_Click_003Ed__18))]
		[DebuggerStepThrough]
		private void button_read_int_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_int_Click_003Ed__18 stateMachine = new _003Cbutton_read_int_Click_003Ed__18();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_read_uint_Click_003Ed__19))]
		[DebuggerStepThrough]
		private void button_read_uint_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_uint_Click_003Ed__19 stateMachine = new _003Cbutton_read_uint_Click_003Ed__19();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_read_long_Click_003Ed__20))]
		[DebuggerStepThrough]
		private void button_read_long_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_long_Click_003Ed__20 stateMachine = new _003Cbutton_read_long_Click_003Ed__20();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_read_ulong_Click_003Ed__21))]
		[DebuggerStepThrough]
		private void button_read_ulong_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_ulong_Click_003Ed__21 stateMachine = new _003Cbutton_read_ulong_Click_003Ed__21();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_read_float_Click_003Ed__22))]
		[DebuggerStepThrough]
		private void button_read_float_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_float_Click_003Ed__22 stateMachine = new _003Cbutton_read_float_Click_003Ed__22();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_read_double_Click_003Ed__23))]
		[DebuggerStepThrough]
		private void button_read_double_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_double_Click_003Ed__23 stateMachine = new _003Cbutton_read_double_Click_003Ed__23();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_read_string_Click_003Ed__24))]
		[DebuggerStepThrough]
		private void button_read_string_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_string_Click_003Ed__24 stateMachine = new _003Cbutton_read_string_Click_003Ed__24();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_write_bool_Click_003Ed__25))]
		[DebuggerStepThrough]
		private void button_write_bool_Click(object sender, EventArgs e)
		{
			_003Cbutton_write_bool_Click_003Ed__25 stateMachine = new _003Cbutton_write_bool_Click_003Ed__25();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_write_byte_Click_003Ed__26))]
		[DebuggerStepThrough]
		private void button_write_byte_Click(object sender, EventArgs e)
		{
			_003Cbutton_write_byte_Click_003Ed__26 stateMachine = new _003Cbutton_write_byte_Click_003Ed__26();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_write_short_Click_003Ed__27))]
		[DebuggerStepThrough]
		private void button_write_short_Click(object sender, EventArgs e)
		{
			_003Cbutton_write_short_Click_003Ed__27 stateMachine = new _003Cbutton_write_short_Click_003Ed__27();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_write_ushort_Click_003Ed__28))]
		[DebuggerStepThrough]
		private void button_write_ushort_Click(object sender, EventArgs e)
		{
			_003Cbutton_write_ushort_Click_003Ed__28 stateMachine = new _003Cbutton_write_ushort_Click_003Ed__28();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_write_int_Click_003Ed__29))]
		[DebuggerStepThrough]
		private void button_write_int_Click(object sender, EventArgs e)
		{
			_003Cbutton_write_int_Click_003Ed__29 stateMachine = new _003Cbutton_write_int_Click_003Ed__29();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_write_uint_Click_003Ed__30))]
		[DebuggerStepThrough]
		private void button_write_uint_Click(object sender, EventArgs e)
		{
			_003Cbutton_write_uint_Click_003Ed__30 stateMachine = new _003Cbutton_write_uint_Click_003Ed__30();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_write_long_Click_003Ed__31))]
		[DebuggerStepThrough]
		private void button_write_long_Click(object sender, EventArgs e)
		{
			_003Cbutton_write_long_Click_003Ed__31 stateMachine = new _003Cbutton_write_long_Click_003Ed__31();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_write_ulong_Click_003Ed__32))]
		[DebuggerStepThrough]
		private void button_write_ulong_Click(object sender, EventArgs e)
		{
			_003Cbutton_write_ulong_Click_003Ed__32 stateMachine = new _003Cbutton_write_ulong_Click_003Ed__32();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_write_float_Click_003Ed__33))]
		[DebuggerStepThrough]
		private void button_write_float_Click(object sender, EventArgs e)
		{
			_003Cbutton_write_float_Click_003Ed__33 stateMachine = new _003Cbutton_write_float_Click_003Ed__33();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_write_double_Click_003Ed__34))]
		[DebuggerStepThrough]
		private void button_write_double_Click(object sender, EventArgs e)
		{
			_003Cbutton_write_double_Click_003Ed__34 stateMachine = new _003Cbutton_write_double_Click_003Ed__34();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_write_string_Click_003Ed__35))]
		[DebuggerStepThrough]
		private void button_write_string_Click(object sender, EventArgs e)
		{
			_003Cbutton_write_string_Click_003Ed__35 stateMachine = new _003Cbutton_write_string_Click_003Ed__35();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_write_hex_Click_003Ed__36))]
		[DebuggerStepThrough]
		private void button_write_hex_Click(object sender, EventArgs e)
		{
			_003Cbutton_write_hex_Click_003Ed__36 stateMachine = new _003Cbutton_write_hex_Click_003Ed__36();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FormCurveMonitor formCurveMonitor = new FormCurveMonitor();
			formCurveMonitor.SetReadWrite(readWriteNet, address);
			formCurveMonitor.Show();
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
			groupBox2 = new System.Windows.Forms.GroupBox();
			label5 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			button_write_hex = new System.Windows.Forms.Button();
			label19 = new System.Windows.Forms.Label();
			button_write_string = new System.Windows.Forms.Button();
			button_write_double = new System.Windows.Forms.Button();
			button_write_float = new System.Windows.Forms.Button();
			button_write_ulong = new System.Windows.Forms.Button();
			button_write_long = new System.Windows.Forms.Button();
			button_write_uint = new System.Windows.Forms.Button();
			button_write_int = new System.Windows.Forms.Button();
			button_write_ushort = new System.Windows.Forms.Button();
			button_write_short = new System.Windows.Forms.Button();
			button_write_byte = new System.Windows.Forms.Button();
			button_write_bool = new System.Windows.Forms.Button();
			textBox7 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			textBox8 = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			groupBox1 = new System.Windows.Forms.GroupBox();
			textBox1 = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			button_read_string = new System.Windows.Forms.Button();
			button_read_double = new System.Windows.Forms.Button();
			button_read_float = new System.Windows.Forms.Button();
			button_read_ulong = new System.Windows.Forms.Button();
			button_read_long = new System.Windows.Forms.Button();
			button_read_uint = new System.Windows.Forms.Button();
			button_read_int = new System.Windows.Forms.Button();
			button_read_ushort = new System.Windows.Forms.Button();
			button_read_short = new System.Windows.Forms.Button();
			button_read_byte = new System.Windows.Forms.Button();
			button_read_bool = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			comboBox_read_encoding = new System.Windows.Forms.ComboBox();
			comboBox_write_Encoding = new System.Windows.Forms.ComboBox();
			label13 = new System.Windows.Forms.Label();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			groupBox2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox2.Controls.Add(comboBox_write_Encoding);
			groupBox2.Controls.Add(label13);
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(label11);
			groupBox2.Controls.Add(label3);
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(label2);
			groupBox2.Controls.Add(label1);
			groupBox2.Controls.Add(button_write_hex);
			groupBox2.Controls.Add(label19);
			groupBox2.Controls.Add(button_write_string);
			groupBox2.Controls.Add(button_write_double);
			groupBox2.Controls.Add(button_write_float);
			groupBox2.Controls.Add(button_write_ulong);
			groupBox2.Controls.Add(button_write_long);
			groupBox2.Controls.Add(button_write_uint);
			groupBox2.Controls.Add(button_write_int);
			groupBox2.Controls.Add(button_write_ushort);
			groupBox2.Controls.Add(button_write_short);
			groupBox2.Controls.Add(button_write_byte);
			groupBox2.Controls.Add(button_write_bool);
			groupBox2.Controls.Add(textBox7);
			groupBox2.Controls.Add(label9);
			groupBox2.Controls.Add(textBox8);
			groupBox2.Controls.Add(label10);
			groupBox2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			groupBox2.Location = new System.Drawing.Point(535, 0);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(419, 234);
			groupBox2.TabIndex = 3;
			groupBox2.TabStop = false;
			groupBox2.Text = "单数据写入测试";
			label5.AutoSize = true;
			label5.ForeColor = System.Drawing.Color.LightSeaGreen;
			label5.Location = new System.Drawing.Point(168, 209);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(34, 17);
			label5.TabIndex = 25;
			label5.Text = "- ms";
			label11.AutoSize = true;
			label11.ForeColor = System.Drawing.Color.LightSeaGreen;
			label11.Location = new System.Drawing.Point(122, 209);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(42, 17);
			label11.TabIndex = 24;
			label11.Text = "Min：";
			label3.AutoSize = true;
			label3.ForeColor = System.Drawing.Color.LightSeaGreen;
			label3.Location = new System.Drawing.Point(55, 209);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(34, 17);
			label3.TabIndex = 23;
			label3.Text = "- ms";
			label4.AutoSize = true;
			label4.ForeColor = System.Drawing.Color.LightSeaGreen;
			label4.Location = new System.Drawing.Point(9, 209);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(45, 17);
			label4.TabIndex = 22;
			label4.Text = "Max：";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label2.ForeColor = System.Drawing.Color.LightSeaGreen;
			label2.Location = new System.Drawing.Point(133, 181);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 21);
			label2.TabIndex = 21;
			label2.Text = "- ms";
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.ForeColor = System.Drawing.Color.LightSeaGreen;
			label1.Location = new System.Drawing.Point(9, 181);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(122, 21);
			label1.TabIndex = 20;
			label1.Text = "当前通信耗时：";
			button_write_hex.Location = new System.Drawing.Point(238, 173);
			button_write_hex.Name = "button_write_hex";
			button_write_hex.Size = new System.Drawing.Size(84, 28);
			button_write_hex.TabIndex = 19;
			button_write_hex.Text = "Hex写入";
			button_write_hex.UseVisualStyleBackColor = true;
			button_write_hex.Click += new System.EventHandler(button_write_hex_Click);
			label19.ForeColor = System.Drawing.Color.Red;
			label19.Location = new System.Drawing.Point(61, 76);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(168, 85);
			label19.TabIndex = 17;
			label19.Text = "注意：值的字符串需要能转化成对应的数据类型\r\n如果是数组：[1,2,3]";
			button_write_string.Location = new System.Drawing.Point(329, 173);
			button_write_string.Name = "button_write_string";
			button_write_string.Size = new System.Drawing.Size(84, 28);
			button_write_string.TabIndex = 16;
			button_write_string.Text = "字符串写入";
			button_write_string.UseVisualStyleBackColor = true;
			button_write_string.Click += new System.EventHandler(button_write_string_Click);
			button_write_double.Location = new System.Drawing.Point(329, 142);
			button_write_double.Name = "button_write_double";
			button_write_double.Size = new System.Drawing.Size(84, 28);
			button_write_double.TabIndex = 15;
			button_write_double.Text = "double写入";
			button_write_double.UseVisualStyleBackColor = true;
			button_write_double.Click += new System.EventHandler(button_write_double_Click);
			button_write_float.Location = new System.Drawing.Point(238, 142);
			button_write_float.Name = "button_write_float";
			button_write_float.Size = new System.Drawing.Size(84, 28);
			button_write_float.TabIndex = 14;
			button_write_float.Text = "float写入";
			button_write_float.UseVisualStyleBackColor = true;
			button_write_float.Click += new System.EventHandler(button_write_float_Click);
			button_write_ulong.Location = new System.Drawing.Point(329, 111);
			button_write_ulong.Name = "button_write_ulong";
			button_write_ulong.Size = new System.Drawing.Size(84, 28);
			button_write_ulong.TabIndex = 13;
			button_write_ulong.Text = "ulong写入";
			button_write_ulong.UseVisualStyleBackColor = true;
			button_write_ulong.Click += new System.EventHandler(button_write_ulong_Click);
			button_write_long.Location = new System.Drawing.Point(238, 111);
			button_write_long.Name = "button_write_long";
			button_write_long.Size = new System.Drawing.Size(84, 28);
			button_write_long.TabIndex = 12;
			button_write_long.Text = "long写入";
			button_write_long.UseVisualStyleBackColor = true;
			button_write_long.Click += new System.EventHandler(button_write_long_Click);
			button_write_uint.Location = new System.Drawing.Point(329, 80);
			button_write_uint.Name = "button_write_uint";
			button_write_uint.Size = new System.Drawing.Size(84, 28);
			button_write_uint.TabIndex = 11;
			button_write_uint.Text = "uint写入";
			button_write_uint.UseVisualStyleBackColor = true;
			button_write_uint.Click += new System.EventHandler(button_write_uint_Click);
			button_write_int.Location = new System.Drawing.Point(238, 80);
			button_write_int.Name = "button_write_int";
			button_write_int.Size = new System.Drawing.Size(84, 28);
			button_write_int.TabIndex = 10;
			button_write_int.Text = "int写入";
			button_write_int.UseVisualStyleBackColor = true;
			button_write_int.Click += new System.EventHandler(button_write_int_Click);
			button_write_ushort.Location = new System.Drawing.Point(329, 49);
			button_write_ushort.Name = "button_write_ushort";
			button_write_ushort.Size = new System.Drawing.Size(84, 28);
			button_write_ushort.TabIndex = 9;
			button_write_ushort.Text = "ushort写入";
			button_write_ushort.UseVisualStyleBackColor = true;
			button_write_ushort.Click += new System.EventHandler(button_write_ushort_Click);
			button_write_short.Location = new System.Drawing.Point(238, 49);
			button_write_short.Name = "button_write_short";
			button_write_short.Size = new System.Drawing.Size(84, 28);
			button_write_short.TabIndex = 8;
			button_write_short.Text = "short写入";
			button_write_short.UseVisualStyleBackColor = true;
			button_write_short.Click += new System.EventHandler(button_write_short_Click);
			button_write_byte.Location = new System.Drawing.Point(329, 18);
			button_write_byte.Name = "button_write_byte";
			button_write_byte.Size = new System.Drawing.Size(84, 28);
			button_write_byte.TabIndex = 7;
			button_write_byte.Text = "byte写入";
			button_write_byte.UseVisualStyleBackColor = true;
			button_write_byte.Click += new System.EventHandler(button_write_byte_Click);
			button_write_bool.Location = new System.Drawing.Point(238, 18);
			button_write_bool.Name = "button_write_bool";
			button_write_bool.Size = new System.Drawing.Size(84, 28);
			button_write_bool.TabIndex = 6;
			button_write_bool.Text = "bool写入";
			button_write_bool.UseVisualStyleBackColor = true;
			button_write_bool.Click += new System.EventHandler(button_write_bool_Click);
			textBox7.Location = new System.Drawing.Point(63, 50);
			textBox7.Name = "textBox7";
			textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox7.Size = new System.Drawing.Size(166, 23);
			textBox7.TabIndex = 5;
			textBox7.Text = "False";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(9, 52);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(32, 17);
			label9.TabIndex = 4;
			label9.Text = "值：";
			textBox8.Location = new System.Drawing.Point(63, 21);
			textBox8.Name = "textBox8";
			textBox8.Size = new System.Drawing.Size(166, 23);
			textBox8.TabIndex = 3;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(9, 24);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(44, 17);
			label10.TabIndex = 2;
			label10.Text = "地址：";
			button1.Location = new System.Drawing.Point(3, 199);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(54, 27);
			button1.TabIndex = 18;
			button1.Text = "曲线";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			groupBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox1.Controls.Add(comboBox_read_encoding);
			groupBox1.Controls.Add(label12);
			groupBox1.Controls.Add(textBox1);
			groupBox1.Controls.Add(button1);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(textBox5);
			groupBox1.Controls.Add(button_read_string);
			groupBox1.Controls.Add(button_read_double);
			groupBox1.Controls.Add(button_read_float);
			groupBox1.Controls.Add(button_read_ulong);
			groupBox1.Controls.Add(button_read_long);
			groupBox1.Controls.Add(button_read_uint);
			groupBox1.Controls.Add(button_read_int);
			groupBox1.Controls.Add(button_read_ushort);
			groupBox1.Controls.Add(button_read_short);
			groupBox1.Controls.Add(button_read_byte);
			groupBox1.Controls.Add(button_read_bool);
			groupBox1.Controls.Add(textBox4);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(textBox3);
			groupBox1.Controls.Add(label6);
			groupBox1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			groupBox1.Location = new System.Drawing.Point(0, 0);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(529, 234);
			groupBox1.TabIndex = 2;
			groupBox1.TabStop = false;
			groupBox1.Text = "单数据读取测试";
			textBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			textBox1.Location = new System.Drawing.Point(386, 177);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(41, 23);
			textBox1.TabIndex = 19;
			textBox1.Text = "10";
			label8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(342, 180);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(44, 17);
			label8.TabIndex = 20;
			label8.Text = "长度：";
			textBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			textBox5.Location = new System.Drawing.Point(275, 23);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(64, 23);
			textBox5.TabIndex = 18;
			textBox5.Text = "1";
			button_read_string.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_read_string.Location = new System.Drawing.Point(436, 174);
			button_read_string.Name = "button_read_string";
			button_read_string.Size = new System.Drawing.Size(84, 28);
			button_read_string.TabIndex = 16;
			button_read_string.Text = "字符串读取";
			button_read_string.UseVisualStyleBackColor = true;
			button_read_string.Click += new System.EventHandler(button_read_string_Click);
			button_read_double.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_read_double.Location = new System.Drawing.Point(436, 144);
			button_read_double.Name = "button_read_double";
			button_read_double.Size = new System.Drawing.Size(84, 28);
			button_read_double.TabIndex = 15;
			button_read_double.Text = "double读取";
			button_read_double.UseVisualStyleBackColor = true;
			button_read_double.Click += new System.EventHandler(button_read_double_Click);
			button_read_float.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_read_float.Location = new System.Drawing.Point(345, 144);
			button_read_float.Name = "button_read_float";
			button_read_float.Size = new System.Drawing.Size(84, 28);
			button_read_float.TabIndex = 14;
			button_read_float.Text = "float读取";
			button_read_float.UseVisualStyleBackColor = true;
			button_read_float.Click += new System.EventHandler(button_read_float_Click);
			button_read_ulong.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_read_ulong.Location = new System.Drawing.Point(436, 113);
			button_read_ulong.Name = "button_read_ulong";
			button_read_ulong.Size = new System.Drawing.Size(84, 28);
			button_read_ulong.TabIndex = 13;
			button_read_ulong.Text = "ulong读取";
			button_read_ulong.UseVisualStyleBackColor = true;
			button_read_ulong.Click += new System.EventHandler(button_read_ulong_Click);
			button_read_long.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_read_long.Location = new System.Drawing.Point(345, 113);
			button_read_long.Name = "button_read_long";
			button_read_long.Size = new System.Drawing.Size(84, 28);
			button_read_long.TabIndex = 12;
			button_read_long.Text = "long读取";
			button_read_long.UseVisualStyleBackColor = true;
			button_read_long.Click += new System.EventHandler(button_read_long_Click);
			button_read_uint.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_read_uint.Location = new System.Drawing.Point(436, 82);
			button_read_uint.Name = "button_read_uint";
			button_read_uint.Size = new System.Drawing.Size(84, 28);
			button_read_uint.TabIndex = 11;
			button_read_uint.Text = "uint读取";
			button_read_uint.UseVisualStyleBackColor = true;
			button_read_uint.Click += new System.EventHandler(button_read_uint_Click);
			button_read_int.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_read_int.Location = new System.Drawing.Point(345, 82);
			button_read_int.Name = "button_read_int";
			button_read_int.Size = new System.Drawing.Size(84, 28);
			button_read_int.TabIndex = 10;
			button_read_int.Text = "int读取";
			button_read_int.UseVisualStyleBackColor = true;
			button_read_int.Click += new System.EventHandler(button_read_int_Click);
			button_read_ushort.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_read_ushort.Location = new System.Drawing.Point(436, 51);
			button_read_ushort.Name = "button_read_ushort";
			button_read_ushort.Size = new System.Drawing.Size(84, 28);
			button_read_ushort.TabIndex = 9;
			button_read_ushort.Text = "ushort读取";
			button_read_ushort.UseVisualStyleBackColor = true;
			button_read_ushort.Click += new System.EventHandler(button_read_ushort_Click);
			button_read_short.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_read_short.Location = new System.Drawing.Point(345, 51);
			button_read_short.Name = "button_read_short";
			button_read_short.Size = new System.Drawing.Size(84, 28);
			button_read_short.TabIndex = 8;
			button_read_short.Text = "short读取";
			button_read_short.UseVisualStyleBackColor = true;
			button_read_short.Click += new System.EventHandler(button_read_short_Click);
			button_read_byte.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_read_byte.Location = new System.Drawing.Point(436, 20);
			button_read_byte.Name = "button_read_byte";
			button_read_byte.Size = new System.Drawing.Size(84, 28);
			button_read_byte.TabIndex = 7;
			button_read_byte.Text = "byte读取";
			button_read_byte.UseVisualStyleBackColor = true;
			button_read_byte.Click += new System.EventHandler(button_read_byte_Click);
			button_read_bool.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_read_bool.Location = new System.Drawing.Point(345, 20);
			button_read_bool.Name = "button_read_bool";
			button_read_bool.Size = new System.Drawing.Size(84, 28);
			button_read_bool.TabIndex = 6;
			button_read_bool.Text = "bool读取";
			button_read_bool.UseVisualStyleBackColor = true;
			button_read_bool.Click += new System.EventHandler(button_read_bool_Click);
			textBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox4.Location = new System.Drawing.Point(63, 50);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox4.Size = new System.Drawing.Size(276, 181);
			textBox4.TabIndex = 5;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(9, 54);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(44, 17);
			label7.TabIndex = 4;
			label7.Text = "结果：";
			textBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox3.Location = new System.Drawing.Point(63, 23);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(206, 23);
			textBox3.TabIndex = 3;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(9, 26);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(44, 17);
			label6.TabIndex = 2;
			label6.Text = "地址：";
			label12.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(342, 209);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(44, 17);
			label12.TabIndex = 21;
			label12.Text = "编码：";
			comboBox_read_encoding.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			comboBox_read_encoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox_read_encoding.FormattingEnabled = true;
			comboBox_read_encoding.Location = new System.Drawing.Point(436, 205);
			comboBox_read_encoding.Name = "comboBox_read_encoding";
			comboBox_read_encoding.Size = new System.Drawing.Size(84, 25);
			comboBox_read_encoding.TabIndex = 22;
			comboBox_write_Encoding.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			comboBox_write_Encoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox_write_Encoding.FormattingEnabled = true;
			comboBox_write_Encoding.Location = new System.Drawing.Point(329, 205);
			comboBox_write_Encoding.Name = "comboBox_write_Encoding";
			comboBox_write_Encoding.Size = new System.Drawing.Size(84, 25);
			comboBox_write_Encoding.TabIndex = 27;
			label13.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(235, 209);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 26;
			label13.Text = "编码：";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(groupBox2);
			base.Controls.Add(groupBox1);
			base.Name = "UserControlReadWriteOp";
			base.Size = new System.Drawing.Size(954, 237);
			base.Load += new System.EventHandler(UserControlReadWriteOp_Load);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
