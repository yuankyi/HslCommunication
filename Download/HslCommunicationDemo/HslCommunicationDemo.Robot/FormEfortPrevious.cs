using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Robot.EFORT;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.Robot
{
	public class FormEfortPrevious : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003CThreadReadRobot_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public FormEfortPrevious _003C_003E4__this;

			private OperateResult<EfortData> _003Cread_003E5__1;

			private OperateResult<EfortData> _003C_003Es__2;

			private TaskAwaiter<OperateResult<EfortData>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<EfortData>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<EfortData>>);
						num = (_003C_003E1__state = -1);
						goto IL_009b;
					}
					goto IL_0109;
					IL_0109:
					do
					{
						Thread.Sleep(_003C_003E4__this.timeSpeep);
					}
					while (!_003C_003E4__this.isReadPlc);
					awaiter = _003C_003E4__this.efortRobot.ReadEfortDataAsync().GetAwaiter();
					if (awaiter.IsCompleted)
					{
						goto IL_009b;
					}
					num = (_003C_003E1__state = 0);
					_003C_003Eu__1 = awaiter;
					_003CThreadReadRobot_003Ed__10 stateMachine = this;
					_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
					goto end_IL_0007;
					IL_009b:
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.RenderRobotData(_003Cread_003E5__1.Content);
					}
					else
					{
						_003C_003E4__this.RenderErrorMessage(_003Cread_003E5__1.Message);
					}
					_003Cread_003E5__1 = null;
					goto IL_0109;
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003C_003Et__builder.SetException(exception);
				}
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
		private sealed class _003CTimer_Tick_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormEfortPrevious _003C_003E4__this;

			private OperateResult<EfortData> _003Cread_003E5__1;

			private OperateResult<EfortData> _003C_003Es__2;

			private TaskAwaiter<OperateResult<EfortData>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<EfortData>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.efortRobot.ReadEfortDataAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CTimer_Tick_003Ed__15 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<EfortData>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.RenderRobotData(_003Cread_003E5__1.Content);
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
		private sealed class _003Cbutton1_Click_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormEfortPrevious _003C_003E4__this;

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
							_003C_003E4__this.efortRobot = new ER7BC10Previous(_003C_003E4__this.textBox1.Text, int.Parse(_003C_003E4__this.textBox2.Text));
							_003C_003E4__this.efortRobot.ConnectTimeOut = 2000;
							awaiter = _003C_003E4__this.efortRobot.ConnectServerAsync().GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003Cbutton1_Click_003Ed__7 stateMachine = this;
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
						}
						else
						{
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
		private sealed class _003Cbutton2_Click_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormEfortPrevious _003C_003E4__this;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					if (num != 0)
					{
						_003C_003E4__this.isReadPlc = false;
						ER7BC10Previous efortRobot = _003C_003E4__this.efortRobot;
						awaiter = ((efortRobot != null) ? efortRobot.ConnectCloseAsync() : null).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton2_Click_003Ed__8 stateMachine = this;
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
					_003C_003E4__this.button2.Enabled = false;
					_003C_003E4__this.panel2.Enabled = false;
					_003C_003E4__this.button1.Enabled = true;
					Thread threadRead = _003C_003E4__this.threadRead;
					if (threadRead != null)
					{
						threadRead.Abort();
					}
					_003C_003E4__this.button3.Enabled = true;
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
		private sealed class _003Cbutton_read_short_Click_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormEfortPrevious _003C_003E4__this;

			private OperateResult<EfortData> _003Cread_003E5__1;

			private OperateResult<EfortData> _003C_003Es__2;

			private TaskAwaiter<OperateResult<EfortData>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<EfortData>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.efortRobot.ReadEfortDataAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_read_short_Click_003Ed__9 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<EfortData>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (!_003Cread_003E5__1.IsSuccess)
					{
						MessageBox.Show("读取失败！" + _003Cread_003E5__1.Message);
					}
					else
					{
						_003C_003E4__this.RenderRobotData(_003Cread_003E5__1.Content);
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

		private ER7BC10Previous efortRobot;

		private Thread threadRead;

		private int timeSpeep = 1000;

		private bool isReadPlc = false;

		private IContainer components = null;

		private Panel panel1;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private Label label1;

		private Panel panel2;

		private Button button3;

		private TextBox textBox3;

		private Label label6;

		private Button button_read_short;

		private GroupBox groupBox1;

		private TextBox textBox7;

		private Label label10;

		private TextBox textBox6;

		private Label label9;

		private TextBox textBox5;

		private Label label8;

		private TextBox textBox4;

		private Label label7;

		private TextBox textBox38;

		private TextBox textBox39;

		private TextBox textBox40;

		private Label label64;

		private Label label61;

		private TextBox textBox33;

		private TextBox textBox34;

		private TextBox textBox35;

		private TextBox textBox36;

		private Label label62;

		private Label label59;

		private TextBox textBox29;

		private TextBox textBox30;

		private TextBox textBox31;

		private TextBox textBox32;

		private Label label60;

		private Label label57;

		private TextBox textBox25;

		private TextBox textBox26;

		private TextBox textBox27;

		private TextBox textBox28;

		private Label label58;

		private Label label55;

		private TextBox textBox21;

		private TextBox textBox22;

		private TextBox textBox23;

		private TextBox textBox24;

		private Label label56;

		private Label label53;

		private TextBox textBox17;

		private TextBox textBox18;

		private TextBox textBox19;

		private TextBox textBox20;

		private Label label54;

		private Label label52;

		private TextBox textBox16;

		private TextBox textBox15;

		private TextBox textBox14;

		private TextBox textBox13;

		private Label label51;

		private TextBox textBox12;

		private Label label50;

		private TextBox textBox11;

		private Label label45;

		private TextBox textBox10;

		private Label label44;

		private TextBox textBox9;

		private Label label43;

		private TextBox textBox8;

		private Label label42;

		private Label label48;

		private Label label49;

		private Label label46;

		private Label label47;

		private Label label40;

		private Label label41;

		private Label label39;

		private Label label36;

		private Label label37;

		private Label label38;

		private Label label33;

		private Label label34;

		private Label label35;

		private Label label30;

		private Label label31;

		private Label label32;

		private Label label27;

		private Label label28;

		private Label label29;

		private Label label24;

		private Label label25;

		private Label label26;

		private Label label21;

		private Label label22;

		private Label label23;

		private Label label17;

		private Label label18;

		private Label label19;

		private Label label14;

		private Label label15;

		private Label label16;

		private Label label13;

		private Label label12;

		private Label label11;

		private Label label63;

		private Label label65;

		private Label label67;

		private Label label66;

		private Label label71;

		private TextBox textBox61;

		private TextBox textBox62;

		private TextBox textBox63;

		private TextBox textBox64;

		private TextBox textBox65;

		private TextBox textBox66;

		private TextBox textBox67;

		private Label label70;

		private TextBox textBox54;

		private TextBox textBox55;

		private TextBox textBox56;

		private TextBox textBox57;

		private TextBox textBox58;

		private TextBox textBox59;

		private TextBox textBox60;

		private Label label69;

		private TextBox textBox47;

		private TextBox textBox48;

		private TextBox textBox49;

		private TextBox textBox50;

		private TextBox textBox51;

		private TextBox textBox52;

		private TextBox textBox53;

		private Label label68;

		private TextBox textBox37;

		private TextBox textBox41;

		private TextBox textBox42;

		private TextBox textBox43;

		private TextBox textBox44;

		private TextBox textBox45;

		private TextBox textBox46;

		private Label label72;

		private Label label73;

		private Label label74;

		private UserControlHead userControlHead1;

		public FormEfortPrevious()
		{
			InitializeComponent();
		}

		private void FormEfort_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			button2.Enabled = false;
			threadRead = new Thread(ThreadReadRobot);
			threadRead.IsBackground = true;
			threadRead.Start();
		}

		private void RenderRobotData(EfortData efortData)
		{
			if (base.InvokeRequired)
			{
				try
				{
					Invoke(new Action<EfortData>(RenderRobotData), efortData);
				}
				catch
				{
				}
			}
			else
			{
				textBox4.Text = efortData.PacketStart;
				textBox6.Text = efortData.PacketOrders.ToString();
				textBox7.Text = efortData.PacketHeartbeat.ToString();
				textBox5.Text = efortData.PacketEnd.ToString();
				if (efortData.ErrorStatus == 1)
				{
					label13.BackColor = Color.Red;
					label12.BackColor = SystemColors.Control;
				}
				else
				{
					label13.BackColor = SystemColors.Control;
					label12.BackColor = Color.Red;
				}
				if (efortData.HstopStatus == 1)
				{
					label15.BackColor = Color.Red;
					label14.BackColor = SystemColors.Control;
				}
				else
				{
					label15.BackColor = SystemColors.Control;
					label14.BackColor = Color.Red;
				}
				if (efortData.AuthorityStatus == 1)
				{
					label18.BackColor = Color.Red;
					label17.BackColor = SystemColors.Control;
				}
				else
				{
					label18.BackColor = SystemColors.Control;
					label17.BackColor = Color.Red;
				}
				if (efortData.ServoStatus == 1)
				{
					label22.BackColor = Color.Red;
					label21.BackColor = SystemColors.Control;
				}
				else
				{
					label22.BackColor = SystemColors.Control;
					label21.BackColor = Color.Red;
				}
				if (efortData.AxisMoveStatus == 1)
				{
					label25.BackColor = Color.Red;
					label24.BackColor = SystemColors.Control;
				}
				else
				{
					label25.BackColor = SystemColors.Control;
					label24.BackColor = Color.Red;
				}
				if (efortData.ProgMoveStatus == 1)
				{
					label28.BackColor = Color.Red;
					label27.BackColor = SystemColors.Control;
				}
				else
				{
					label28.BackColor = SystemColors.Control;
					label27.BackColor = Color.Red;
				}
				if (efortData.ProgLoadStatus == 1)
				{
					label31.BackColor = Color.Red;
					label30.BackColor = SystemColors.Control;
				}
				else
				{
					label31.BackColor = SystemColors.Control;
					label30.BackColor = Color.Red;
				}
				if (efortData.ProgHoldStatus == 1)
				{
					label34.BackColor = Color.Red;
					label33.BackColor = SystemColors.Control;
				}
				else
				{
					label34.BackColor = SystemColors.Control;
					label33.BackColor = Color.Red;
				}
				if (efortData.ModeStatus == 1)
				{
					label39.BackColor = Color.Red;
					label37.BackColor = SystemColors.Control;
					label36.BackColor = SystemColors.Control;
				}
				else if (efortData.ModeStatus == 2)
				{
					label39.BackColor = SystemColors.Control;
					label37.BackColor = Color.Red;
					label36.BackColor = SystemColors.Control;
				}
				else
				{
					label39.BackColor = SystemColors.Control;
					label37.BackColor = SystemColors.Control;
					label36.BackColor = Color.Red;
				}
				label40.Text = efortData.SpeedStatus.ToString() + " %";
				label46.Text = efortData.ProjectName;
				label48.Text = efortData.ProgramName;
				label72.Text = efortData.DbDeviceTime.ToString();
				textBox8.Text = GetStringFromArray(efortData.IoDOut);
				textBox9.Text = GetStringFromArray(efortData.IoDIn);
				textBox10.Text = GetStringFromArray(efortData.IoIOut);
				textBox11.Text = GetStringFromArray(efortData.IoIIn);
				textBox12.Text = efortData.ErrorText;
				textBox13.Text = efortData.DbAxisPos[0].ToString();
				textBox20.Text = efortData.DbAxisPos[1].ToString();
				textBox24.Text = efortData.DbAxisPos[2].ToString();
				textBox28.Text = efortData.DbAxisPos[3].ToString();
				textBox32.Text = efortData.DbAxisPos[4].ToString();
				textBox36.Text = efortData.DbAxisPos[5].ToString();
				textBox40.Text = efortData.DbAxisPos[6].ToString();
				textBox16.Text = efortData.DbCartPos[0].ToString();
				textBox17.Text = efortData.DbCartPos[1].ToString();
				textBox21.Text = efortData.DbCartPos[2].ToString();
				textBox25.Text = efortData.DbCartPos[3].ToString();
				textBox29.Text = efortData.DbCartPos[4].ToString();
				textBox33.Text = efortData.DbCartPos[5].ToString();
				textBox14.Text = efortData.DbAxisSpeed[0].ToString();
				textBox19.Text = efortData.DbAxisSpeed[1].ToString();
				textBox23.Text = efortData.DbAxisSpeed[2].ToString();
				textBox27.Text = efortData.DbAxisSpeed[3].ToString();
				textBox31.Text = efortData.DbAxisSpeed[4].ToString();
				textBox35.Text = efortData.DbAxisSpeed[5].ToString();
				textBox39.Text = efortData.DbAxisSpeed[6].ToString();
				textBox46.Text = efortData.DbAxisAcc[0].ToString();
				textBox45.Text = efortData.DbAxisAcc[1].ToString();
				textBox44.Text = efortData.DbAxisAcc[2].ToString();
				textBox43.Text = efortData.DbAxisAcc[3].ToString();
				textBox42.Text = efortData.DbAxisAcc[4].ToString();
				textBox41.Text = efortData.DbAxisAcc[5].ToString();
				textBox37.Text = efortData.DbAxisAcc[6].ToString();
				textBox53.Text = efortData.DbAxisAccAcc[0].ToString();
				textBox52.Text = efortData.DbAxisAccAcc[1].ToString();
				textBox51.Text = efortData.DbAxisAccAcc[2].ToString();
				textBox50.Text = efortData.DbAxisAccAcc[3].ToString();
				textBox49.Text = efortData.DbAxisAccAcc[4].ToString();
				textBox48.Text = efortData.DbAxisAccAcc[5].ToString();
				textBox47.Text = efortData.DbAxisAccAcc[6].ToString();
				textBox15.Text = efortData.DbAxisTorque[0].ToString();
				textBox18.Text = efortData.DbAxisTorque[1].ToString();
				textBox22.Text = efortData.DbAxisTorque[2].ToString();
				textBox26.Text = efortData.DbAxisTorque[3].ToString();
				textBox30.Text = efortData.DbAxisTorque[4].ToString();
				textBox34.Text = efortData.DbAxisTorque[5].ToString();
				textBox38.Text = efortData.DbAxisTorque[6].ToString();
				textBox60.Text = efortData.DbAxisDirCnt[0].ToString();
				textBox59.Text = efortData.DbAxisDirCnt[1].ToString();
				textBox58.Text = efortData.DbAxisDirCnt[2].ToString();
				textBox57.Text = efortData.DbAxisDirCnt[3].ToString();
				textBox56.Text = efortData.DbAxisDirCnt[4].ToString();
				textBox55.Text = efortData.DbAxisDirCnt[5].ToString();
				textBox54.Text = efortData.DbAxisDirCnt[6].ToString();
				textBox67.Text = efortData.DbAxisTime[0].ToString();
				textBox66.Text = efortData.DbAxisTime[1].ToString();
				textBox65.Text = efortData.DbAxisTime[2].ToString();
				textBox64.Text = efortData.DbAxisTime[3].ToString();
				textBox63.Text = efortData.DbAxisTime[4].ToString();
				textBox62.Text = efortData.DbAxisTime[5].ToString();
				textBox61.Text = efortData.DbAxisTime[6].ToString();
			}
		}

		private string GetStringFromArray(Array array)
		{
			StringBuilder stringBuilder = new StringBuilder("[");
			foreach (object item in array)
			{
				stringBuilder.Append(item.ToString() + ",");
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}

		private void RenderErrorMessage(string msg)
		{
			if (base.InvokeRequired)
			{
				try
				{
					Invoke(new Action<string>(RenderErrorMessage), msg);
				}
				catch
				{
				}
			}
			else
			{
				label74.Text = "异常消息：[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "] " + msg;
				label74.BackColor = Color.Blue;
				ThreadPool.QueueUserWorkItem(Reset, null);
			}
		}

		private void Reset(object obj)
		{
			Thread.Sleep(2000);
			label74.Invoke((Action)delegate
			{
				label74.BackColor = Color.Transparent;
			});
		}

		[AsyncStateMachine(typeof(_003Cbutton1_Click_003Ed__7))]
		[DebuggerStepThrough]
		private void button1_Click(object sender, EventArgs e)
		{
			_003Cbutton1_Click_003Ed__7 stateMachine = new _003Cbutton1_Click_003Ed__7();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton2_Click_003Ed__8))]
		[DebuggerStepThrough]
		private void button2_Click(object sender, EventArgs e)
		{
			_003Cbutton2_Click_003Ed__8 stateMachine = new _003Cbutton2_Click_003Ed__8();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_read_short_Click_003Ed__9))]
		[DebuggerStepThrough]
		private void button_read_short_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_short_Click_003Ed__9 stateMachine = new _003Cbutton_read_short_Click_003Ed__9();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CThreadReadRobot_003Ed__10))]
		[DebuggerStepThrough]
		private void ThreadReadRobot()
		{
			_003CThreadReadRobot_003Ed__10 stateMachine = new _003CThreadReadRobot_003Ed__10();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				timeSpeep = int.Parse(textBox3.Text);
				isReadPlc = true;
				button3.Enabled = false;
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage(ex);
			}
		}

		[AsyncStateMachine(typeof(_003CTimer_Tick_003Ed__15))]
		[DebuggerStepThrough]
		private void Timer_Tick(object sender, EventArgs e)
		{
			_003CTimer_Tick_003Ed__15 stateMachine = new _003CTimer_Tick_003Ed__15();
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
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			label74 = new System.Windows.Forms.Label();
			label71 = new System.Windows.Forms.Label();
			textBox61 = new System.Windows.Forms.TextBox();
			textBox62 = new System.Windows.Forms.TextBox();
			textBox63 = new System.Windows.Forms.TextBox();
			textBox64 = new System.Windows.Forms.TextBox();
			textBox65 = new System.Windows.Forms.TextBox();
			textBox66 = new System.Windows.Forms.TextBox();
			textBox67 = new System.Windows.Forms.TextBox();
			label70 = new System.Windows.Forms.Label();
			textBox54 = new System.Windows.Forms.TextBox();
			textBox55 = new System.Windows.Forms.TextBox();
			textBox56 = new System.Windows.Forms.TextBox();
			textBox57 = new System.Windows.Forms.TextBox();
			textBox58 = new System.Windows.Forms.TextBox();
			textBox59 = new System.Windows.Forms.TextBox();
			textBox60 = new System.Windows.Forms.TextBox();
			label69 = new System.Windows.Forms.Label();
			textBox47 = new System.Windows.Forms.TextBox();
			textBox48 = new System.Windows.Forms.TextBox();
			textBox49 = new System.Windows.Forms.TextBox();
			textBox50 = new System.Windows.Forms.TextBox();
			textBox51 = new System.Windows.Forms.TextBox();
			textBox52 = new System.Windows.Forms.TextBox();
			textBox53 = new System.Windows.Forms.TextBox();
			label68 = new System.Windows.Forms.Label();
			textBox37 = new System.Windows.Forms.TextBox();
			textBox41 = new System.Windows.Forms.TextBox();
			textBox42 = new System.Windows.Forms.TextBox();
			textBox43 = new System.Windows.Forms.TextBox();
			textBox44 = new System.Windows.Forms.TextBox();
			textBox45 = new System.Windows.Forms.TextBox();
			textBox46 = new System.Windows.Forms.TextBox();
			label67 = new System.Windows.Forms.Label();
			label66 = new System.Windows.Forms.Label();
			label65 = new System.Windows.Forms.Label();
			label63 = new System.Windows.Forms.Label();
			textBox38 = new System.Windows.Forms.TextBox();
			textBox39 = new System.Windows.Forms.TextBox();
			textBox40 = new System.Windows.Forms.TextBox();
			label64 = new System.Windows.Forms.Label();
			textBox33 = new System.Windows.Forms.TextBox();
			textBox34 = new System.Windows.Forms.TextBox();
			textBox35 = new System.Windows.Forms.TextBox();
			textBox36 = new System.Windows.Forms.TextBox();
			label62 = new System.Windows.Forms.Label();
			textBox29 = new System.Windows.Forms.TextBox();
			textBox30 = new System.Windows.Forms.TextBox();
			textBox31 = new System.Windows.Forms.TextBox();
			textBox32 = new System.Windows.Forms.TextBox();
			label60 = new System.Windows.Forms.Label();
			textBox25 = new System.Windows.Forms.TextBox();
			textBox26 = new System.Windows.Forms.TextBox();
			textBox27 = new System.Windows.Forms.TextBox();
			textBox28 = new System.Windows.Forms.TextBox();
			label58 = new System.Windows.Forms.Label();
			textBox21 = new System.Windows.Forms.TextBox();
			textBox22 = new System.Windows.Forms.TextBox();
			textBox23 = new System.Windows.Forms.TextBox();
			textBox24 = new System.Windows.Forms.TextBox();
			label56 = new System.Windows.Forms.Label();
			textBox17 = new System.Windows.Forms.TextBox();
			textBox18 = new System.Windows.Forms.TextBox();
			textBox19 = new System.Windows.Forms.TextBox();
			textBox20 = new System.Windows.Forms.TextBox();
			label54 = new System.Windows.Forms.Label();
			textBox16 = new System.Windows.Forms.TextBox();
			textBox15 = new System.Windows.Forms.TextBox();
			textBox14 = new System.Windows.Forms.TextBox();
			textBox13 = new System.Windows.Forms.TextBox();
			label51 = new System.Windows.Forms.Label();
			textBox12 = new System.Windows.Forms.TextBox();
			label50 = new System.Windows.Forms.Label();
			textBox11 = new System.Windows.Forms.TextBox();
			label45 = new System.Windows.Forms.Label();
			textBox10 = new System.Windows.Forms.TextBox();
			label44 = new System.Windows.Forms.Label();
			textBox9 = new System.Windows.Forms.TextBox();
			label43 = new System.Windows.Forms.Label();
			textBox8 = new System.Windows.Forms.TextBox();
			label42 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			label72 = new System.Windows.Forms.Label();
			label73 = new System.Windows.Forms.Label();
			label48 = new System.Windows.Forms.Label();
			label49 = new System.Windows.Forms.Label();
			label46 = new System.Windows.Forms.Label();
			label47 = new System.Windows.Forms.Label();
			label40 = new System.Windows.Forms.Label();
			label41 = new System.Windows.Forms.Label();
			label39 = new System.Windows.Forms.Label();
			label36 = new System.Windows.Forms.Label();
			label37 = new System.Windows.Forms.Label();
			label38 = new System.Windows.Forms.Label();
			label33 = new System.Windows.Forms.Label();
			label34 = new System.Windows.Forms.Label();
			label35 = new System.Windows.Forms.Label();
			label30 = new System.Windows.Forms.Label();
			label31 = new System.Windows.Forms.Label();
			label32 = new System.Windows.Forms.Label();
			label27 = new System.Windows.Forms.Label();
			label28 = new System.Windows.Forms.Label();
			label29 = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			label25 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			label23 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			textBox7 = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			button_read_short = new System.Windows.Forms.Button();
			label61 = new System.Windows.Forms.Label();
			label59 = new System.Windows.Forms.Label();
			label57 = new System.Windows.Forms.Label();
			label55 = new System.Windows.Forms.Label();
			label53 = new System.Windows.Forms.Label();
			label52 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(4, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(975, 42);
			panel1.TabIndex = 12;
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(875, 5);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(772, 5);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(250, 8);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(76, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "8008";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(196, 11);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 8);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(128, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "192.168.0.100";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 11);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(label74);
			panel2.Controls.Add(label71);
			panel2.Controls.Add(textBox61);
			panel2.Controls.Add(textBox62);
			panel2.Controls.Add(textBox63);
			panel2.Controls.Add(textBox64);
			panel2.Controls.Add(textBox65);
			panel2.Controls.Add(textBox66);
			panel2.Controls.Add(textBox67);
			panel2.Controls.Add(label70);
			panel2.Controls.Add(textBox54);
			panel2.Controls.Add(textBox55);
			panel2.Controls.Add(textBox56);
			panel2.Controls.Add(textBox57);
			panel2.Controls.Add(textBox58);
			panel2.Controls.Add(textBox59);
			panel2.Controls.Add(textBox60);
			panel2.Controls.Add(label69);
			panel2.Controls.Add(textBox47);
			panel2.Controls.Add(textBox48);
			panel2.Controls.Add(textBox49);
			panel2.Controls.Add(textBox50);
			panel2.Controls.Add(textBox51);
			panel2.Controls.Add(textBox52);
			panel2.Controls.Add(textBox53);
			panel2.Controls.Add(label68);
			panel2.Controls.Add(textBox37);
			panel2.Controls.Add(textBox41);
			panel2.Controls.Add(textBox42);
			panel2.Controls.Add(textBox43);
			panel2.Controls.Add(textBox44);
			panel2.Controls.Add(textBox45);
			panel2.Controls.Add(textBox46);
			panel2.Controls.Add(label67);
			panel2.Controls.Add(label66);
			panel2.Controls.Add(label65);
			panel2.Controls.Add(label63);
			panel2.Controls.Add(textBox38);
			panel2.Controls.Add(textBox39);
			panel2.Controls.Add(textBox40);
			panel2.Controls.Add(label64);
			panel2.Controls.Add(textBox33);
			panel2.Controls.Add(textBox34);
			panel2.Controls.Add(textBox35);
			panel2.Controls.Add(textBox36);
			panel2.Controls.Add(label62);
			panel2.Controls.Add(textBox29);
			panel2.Controls.Add(textBox30);
			panel2.Controls.Add(textBox31);
			panel2.Controls.Add(textBox32);
			panel2.Controls.Add(label60);
			panel2.Controls.Add(textBox25);
			panel2.Controls.Add(textBox26);
			panel2.Controls.Add(textBox27);
			panel2.Controls.Add(textBox28);
			panel2.Controls.Add(label58);
			panel2.Controls.Add(textBox21);
			panel2.Controls.Add(textBox22);
			panel2.Controls.Add(textBox23);
			panel2.Controls.Add(textBox24);
			panel2.Controls.Add(label56);
			panel2.Controls.Add(textBox17);
			panel2.Controls.Add(textBox18);
			panel2.Controls.Add(textBox19);
			panel2.Controls.Add(textBox20);
			panel2.Controls.Add(label54);
			panel2.Controls.Add(textBox16);
			panel2.Controls.Add(textBox15);
			panel2.Controls.Add(textBox14);
			panel2.Controls.Add(textBox13);
			panel2.Controls.Add(label51);
			panel2.Controls.Add(textBox12);
			panel2.Controls.Add(label50);
			panel2.Controls.Add(textBox11);
			panel2.Controls.Add(label45);
			panel2.Controls.Add(textBox10);
			panel2.Controls.Add(label44);
			panel2.Controls.Add(textBox9);
			panel2.Controls.Add(label43);
			panel2.Controls.Add(textBox8);
			panel2.Controls.Add(label42);
			panel2.Controls.Add(groupBox1);
			panel2.Controls.Add(textBox7);
			panel2.Controls.Add(label10);
			panel2.Controls.Add(textBox6);
			panel2.Controls.Add(label9);
			panel2.Controls.Add(textBox5);
			panel2.Controls.Add(label8);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label7);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(textBox3);
			panel2.Controls.Add(label6);
			panel2.Controls.Add(button_read_short);
			panel2.Controls.Add(label61);
			panel2.Controls.Add(label59);
			panel2.Controls.Add(label57);
			panel2.Controls.Add(label55);
			panel2.Controls.Add(label53);
			panel2.Controls.Add(label52);
			panel2.Location = new System.Drawing.Point(4, 82);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(974, 554);
			panel2.TabIndex = 13;
			label74.ForeColor = System.Drawing.Color.Red;
			label74.Location = new System.Drawing.Point(510, 0);
			label74.Name = "label74";
			label74.Size = new System.Drawing.Size(463, 36);
			label74.TabIndex = 108;
			label74.Text = "异常信息：";
			label71.AutoSize = true;
			label71.Location = new System.Drawing.Point(782, 330);
			label71.Name = "label71";
			label71.Size = new System.Drawing.Size(80, 17);
			label71.TabIndex = 107;
			label71.Text = "七轴工作时长";
			textBox61.Location = new System.Drawing.Point(791, 513);
			textBox61.Name = "textBox61";
			textBox61.Size = new System.Drawing.Size(68, 23);
			textBox61.TabIndex = 106;
			textBox62.Location = new System.Drawing.Point(791, 486);
			textBox62.Name = "textBox62";
			textBox62.Size = new System.Drawing.Size(68, 23);
			textBox62.TabIndex = 105;
			textBox63.Location = new System.Drawing.Point(791, 459);
			textBox63.Name = "textBox63";
			textBox63.Size = new System.Drawing.Size(68, 23);
			textBox63.TabIndex = 104;
			textBox64.Location = new System.Drawing.Point(791, 432);
			textBox64.Name = "textBox64";
			textBox64.Size = new System.Drawing.Size(68, 23);
			textBox64.TabIndex = 103;
			textBox65.Location = new System.Drawing.Point(791, 405);
			textBox65.Name = "textBox65";
			textBox65.Size = new System.Drawing.Size(68, 23);
			textBox65.TabIndex = 102;
			textBox66.Location = new System.Drawing.Point(791, 377);
			textBox66.Name = "textBox66";
			textBox66.Size = new System.Drawing.Size(68, 23);
			textBox66.TabIndex = 101;
			textBox67.Location = new System.Drawing.Point(791, 350);
			textBox67.Name = "textBox67";
			textBox67.Size = new System.Drawing.Size(68, 23);
			textBox67.TabIndex = 100;
			label70.AutoSize = true;
			label70.Location = new System.Drawing.Point(706, 330);
			label70.Name = "label70";
			label70.Size = new System.Drawing.Size(80, 17);
			label70.TabIndex = 99;
			label70.Text = "七轴反向计数";
			textBox54.Location = new System.Drawing.Point(715, 513);
			textBox54.Name = "textBox54";
			textBox54.Size = new System.Drawing.Size(68, 23);
			textBox54.TabIndex = 98;
			textBox55.Location = new System.Drawing.Point(715, 486);
			textBox55.Name = "textBox55";
			textBox55.Size = new System.Drawing.Size(68, 23);
			textBox55.TabIndex = 97;
			textBox56.Location = new System.Drawing.Point(715, 459);
			textBox56.Name = "textBox56";
			textBox56.Size = new System.Drawing.Size(68, 23);
			textBox56.TabIndex = 96;
			textBox57.Location = new System.Drawing.Point(715, 432);
			textBox57.Name = "textBox57";
			textBox57.Size = new System.Drawing.Size(68, 23);
			textBox57.TabIndex = 95;
			textBox58.Location = new System.Drawing.Point(715, 405);
			textBox58.Name = "textBox58";
			textBox58.Size = new System.Drawing.Size(68, 23);
			textBox58.TabIndex = 94;
			textBox59.Location = new System.Drawing.Point(715, 377);
			textBox59.Name = "textBox59";
			textBox59.Size = new System.Drawing.Size(68, 23);
			textBox59.TabIndex = 93;
			textBox60.Location = new System.Drawing.Point(715, 350);
			textBox60.Name = "textBox60";
			textBox60.Size = new System.Drawing.Size(68, 23);
			textBox60.TabIndex = 92;
			label69.AutoSize = true;
			label69.Location = new System.Drawing.Point(562, 330);
			label69.Name = "label69";
			label69.Size = new System.Drawing.Size(80, 17);
			label69.TabIndex = 91;
			label69.Text = "七轴加加速度";
			textBox47.Location = new System.Drawing.Point(569, 513);
			textBox47.Name = "textBox47";
			textBox47.Size = new System.Drawing.Size(68, 23);
			textBox47.TabIndex = 90;
			textBox48.Location = new System.Drawing.Point(569, 486);
			textBox48.Name = "textBox48";
			textBox48.Size = new System.Drawing.Size(68, 23);
			textBox48.TabIndex = 89;
			textBox49.Location = new System.Drawing.Point(569, 459);
			textBox49.Name = "textBox49";
			textBox49.Size = new System.Drawing.Size(68, 23);
			textBox49.TabIndex = 88;
			textBox50.Location = new System.Drawing.Point(569, 432);
			textBox50.Name = "textBox50";
			textBox50.Size = new System.Drawing.Size(68, 23);
			textBox50.TabIndex = 87;
			textBox51.Location = new System.Drawing.Point(569, 405);
			textBox51.Name = "textBox51";
			textBox51.Size = new System.Drawing.Size(68, 23);
			textBox51.TabIndex = 86;
			textBox52.Location = new System.Drawing.Point(569, 377);
			textBox52.Name = "textBox52";
			textBox52.Size = new System.Drawing.Size(68, 23);
			textBox52.TabIndex = 85;
			textBox53.Location = new System.Drawing.Point(569, 350);
			textBox53.Name = "textBox53";
			textBox53.Size = new System.Drawing.Size(68, 23);
			textBox53.TabIndex = 84;
			label68.AutoSize = true;
			label68.Location = new System.Drawing.Point(495, 330);
			label68.Name = "label68";
			label68.Size = new System.Drawing.Size(68, 17);
			label68.TabIndex = 83;
			label68.Text = "七轴加速度";
			textBox37.Location = new System.Drawing.Point(495, 513);
			textBox37.Name = "textBox37";
			textBox37.Size = new System.Drawing.Size(68, 23);
			textBox37.TabIndex = 82;
			textBox41.Location = new System.Drawing.Point(495, 486);
			textBox41.Name = "textBox41";
			textBox41.Size = new System.Drawing.Size(68, 23);
			textBox41.TabIndex = 81;
			textBox42.Location = new System.Drawing.Point(495, 459);
			textBox42.Name = "textBox42";
			textBox42.Size = new System.Drawing.Size(68, 23);
			textBox42.TabIndex = 80;
			textBox43.Location = new System.Drawing.Point(495, 432);
			textBox43.Name = "textBox43";
			textBox43.Size = new System.Drawing.Size(68, 23);
			textBox43.TabIndex = 79;
			textBox44.Location = new System.Drawing.Point(495, 405);
			textBox44.Name = "textBox44";
			textBox44.Size = new System.Drawing.Size(68, 23);
			textBox44.TabIndex = 78;
			textBox45.Location = new System.Drawing.Point(495, 377);
			textBox45.Name = "textBox45";
			textBox45.Size = new System.Drawing.Size(68, 23);
			textBox45.TabIndex = 77;
			textBox46.Location = new System.Drawing.Point(495, 350);
			textBox46.Name = "textBox46";
			textBox46.Size = new System.Drawing.Size(68, 23);
			textBox46.TabIndex = 76;
			label67.AutoSize = true;
			label67.Location = new System.Drawing.Point(906, 330);
			label67.Name = "label67";
			label67.Size = new System.Drawing.Size(32, 17);
			label67.TabIndex = 75;
			label67.Text = "方向";
			label66.AutoSize = true;
			label66.Location = new System.Drawing.Point(648, 330);
			label66.Name = "label66";
			label66.Size = new System.Drawing.Size(56, 17);
			label66.TabIndex = 74;
			label66.Text = "七轴力矩";
			label65.AutoSize = true;
			label65.Location = new System.Drawing.Point(425, 330);
			label65.Name = "label65";
			label65.Size = new System.Drawing.Size(56, 17);
			label65.TabIndex = 73;
			label65.Text = "七轴速度";
			label63.AutoSize = true;
			label63.Location = new System.Drawing.Point(353, 330);
			label63.Name = "label63";
			label63.Size = new System.Drawing.Size(56, 17);
			label63.TabIndex = 72;
			label63.Text = "七轴角度";
			textBox38.Location = new System.Drawing.Point(642, 513);
			textBox38.Name = "textBox38";
			textBox38.Size = new System.Drawing.Size(68, 23);
			textBox38.TabIndex = 71;
			textBox39.Location = new System.Drawing.Point(421, 513);
			textBox39.Name = "textBox39";
			textBox39.Size = new System.Drawing.Size(68, 23);
			textBox39.TabIndex = 70;
			textBox40.Location = new System.Drawing.Point(347, 513);
			textBox40.Name = "textBox40";
			textBox40.Size = new System.Drawing.Size(68, 23);
			textBox40.TabIndex = 69;
			label64.AutoSize = true;
			label64.Location = new System.Drawing.Point(271, 516);
			label64.Name = "label64";
			label64.Size = new System.Drawing.Size(68, 17);
			label64.TabIndex = 68;
			label64.Text = "七轴数据：";
			textBox33.Location = new System.Drawing.Point(886, 486);
			textBox33.Name = "textBox33";
			textBox33.Size = new System.Drawing.Size(68, 23);
			textBox33.TabIndex = 66;
			textBox34.Location = new System.Drawing.Point(642, 486);
			textBox34.Name = "textBox34";
			textBox34.Size = new System.Drawing.Size(68, 23);
			textBox34.TabIndex = 65;
			textBox35.Location = new System.Drawing.Point(421, 486);
			textBox35.Name = "textBox35";
			textBox35.Size = new System.Drawing.Size(68, 23);
			textBox35.TabIndex = 64;
			textBox36.Location = new System.Drawing.Point(347, 486);
			textBox36.Name = "textBox36";
			textBox36.Size = new System.Drawing.Size(68, 23);
			textBox36.TabIndex = 63;
			label62.AutoSize = true;
			label62.Location = new System.Drawing.Point(271, 489);
			label62.Name = "label62";
			label62.Size = new System.Drawing.Size(68, 17);
			label62.TabIndex = 62;
			label62.Text = "六轴数据：";
			textBox29.Location = new System.Drawing.Point(886, 459);
			textBox29.Name = "textBox29";
			textBox29.Size = new System.Drawing.Size(68, 23);
			textBox29.TabIndex = 60;
			textBox30.Location = new System.Drawing.Point(642, 459);
			textBox30.Name = "textBox30";
			textBox30.Size = new System.Drawing.Size(68, 23);
			textBox30.TabIndex = 59;
			textBox31.Location = new System.Drawing.Point(421, 459);
			textBox31.Name = "textBox31";
			textBox31.Size = new System.Drawing.Size(68, 23);
			textBox31.TabIndex = 58;
			textBox32.Location = new System.Drawing.Point(347, 459);
			textBox32.Name = "textBox32";
			textBox32.Size = new System.Drawing.Size(68, 23);
			textBox32.TabIndex = 57;
			label60.AutoSize = true;
			label60.Location = new System.Drawing.Point(271, 462);
			label60.Name = "label60";
			label60.Size = new System.Drawing.Size(68, 17);
			label60.TabIndex = 56;
			label60.Text = "五轴数据：";
			textBox25.Location = new System.Drawing.Point(886, 432);
			textBox25.Name = "textBox25";
			textBox25.Size = new System.Drawing.Size(68, 23);
			textBox25.TabIndex = 54;
			textBox26.Location = new System.Drawing.Point(642, 432);
			textBox26.Name = "textBox26";
			textBox26.Size = new System.Drawing.Size(68, 23);
			textBox26.TabIndex = 53;
			textBox27.Location = new System.Drawing.Point(421, 432);
			textBox27.Name = "textBox27";
			textBox27.Size = new System.Drawing.Size(68, 23);
			textBox27.TabIndex = 52;
			textBox28.Location = new System.Drawing.Point(347, 432);
			textBox28.Name = "textBox28";
			textBox28.Size = new System.Drawing.Size(68, 23);
			textBox28.TabIndex = 51;
			label58.AutoSize = true;
			label58.Location = new System.Drawing.Point(271, 435);
			label58.Name = "label58";
			label58.Size = new System.Drawing.Size(68, 17);
			label58.TabIndex = 50;
			label58.Text = "四轴数据：";
			textBox21.Location = new System.Drawing.Point(886, 405);
			textBox21.Name = "textBox21";
			textBox21.Size = new System.Drawing.Size(68, 23);
			textBox21.TabIndex = 48;
			textBox22.Location = new System.Drawing.Point(642, 405);
			textBox22.Name = "textBox22";
			textBox22.Size = new System.Drawing.Size(68, 23);
			textBox22.TabIndex = 47;
			textBox23.Location = new System.Drawing.Point(421, 405);
			textBox23.Name = "textBox23";
			textBox23.Size = new System.Drawing.Size(68, 23);
			textBox23.TabIndex = 46;
			textBox24.Location = new System.Drawing.Point(347, 405);
			textBox24.Name = "textBox24";
			textBox24.Size = new System.Drawing.Size(68, 23);
			textBox24.TabIndex = 45;
			label56.AutoSize = true;
			label56.Location = new System.Drawing.Point(271, 408);
			label56.Name = "label56";
			label56.Size = new System.Drawing.Size(68, 17);
			label56.TabIndex = 44;
			label56.Text = "三轴数据：";
			textBox17.Location = new System.Drawing.Point(886, 377);
			textBox17.Name = "textBox17";
			textBox17.Size = new System.Drawing.Size(68, 23);
			textBox17.TabIndex = 42;
			textBox18.Location = new System.Drawing.Point(642, 377);
			textBox18.Name = "textBox18";
			textBox18.Size = new System.Drawing.Size(68, 23);
			textBox18.TabIndex = 41;
			textBox19.Location = new System.Drawing.Point(421, 377);
			textBox19.Name = "textBox19";
			textBox19.Size = new System.Drawing.Size(68, 23);
			textBox19.TabIndex = 40;
			textBox20.Location = new System.Drawing.Point(347, 377);
			textBox20.Name = "textBox20";
			textBox20.Size = new System.Drawing.Size(68, 23);
			textBox20.TabIndex = 39;
			label54.AutoSize = true;
			label54.Location = new System.Drawing.Point(271, 380);
			label54.Name = "label54";
			label54.Size = new System.Drawing.Size(68, 17);
			label54.TabIndex = 38;
			label54.Text = "二轴数据：";
			textBox16.Location = new System.Drawing.Point(886, 350);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(68, 23);
			textBox16.TabIndex = 36;
			textBox15.Location = new System.Drawing.Point(642, 350);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(68, 23);
			textBox15.TabIndex = 35;
			textBox14.Location = new System.Drawing.Point(421, 350);
			textBox14.Name = "textBox14";
			textBox14.Size = new System.Drawing.Size(68, 23);
			textBox14.TabIndex = 34;
			textBox13.Location = new System.Drawing.Point(347, 350);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(68, 23);
			textBox13.TabIndex = 33;
			label51.AutoSize = true;
			label51.Location = new System.Drawing.Point(271, 353);
			label51.Name = "label51";
			label51.Size = new System.Drawing.Size(68, 17);
			label51.TabIndex = 32;
			label51.Text = "一轴数据：";
			textBox12.Location = new System.Drawing.Point(347, 281);
			textBox12.Multiline = true;
			textBox12.Name = "textBox12";
			textBox12.Size = new System.Drawing.Size(604, 42);
			textBox12.TabIndex = 31;
			label50.AutoSize = true;
			label50.Location = new System.Drawing.Point(271, 284);
			label50.Name = "label50";
			label50.Size = new System.Drawing.Size(68, 17);
			label50.TabIndex = 30;
			label50.Text = "错误信息：";
			textBox11.Location = new System.Drawing.Point(347, 227);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.Size = new System.Drawing.Size(604, 42);
			textBox11.TabIndex = 29;
			label45.AutoSize = true;
			label45.Location = new System.Drawing.Point(271, 230);
			label45.Name = "label45";
			label45.Size = new System.Drawing.Size(47, 17);
			label45.TabIndex = 28;
			label45.Text = "IoIIn：";
			textBox10.Location = new System.Drawing.Point(347, 172);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.Size = new System.Drawing.Size(604, 42);
			textBox10.TabIndex = 27;
			label44.AutoSize = true;
			label44.Location = new System.Drawing.Point(271, 175);
			label44.Name = "label44";
			label44.Size = new System.Drawing.Size(57, 17);
			label44.TabIndex = 26;
			label44.Text = "IoIOut：";
			textBox9.Location = new System.Drawing.Point(347, 119);
			textBox9.Multiline = true;
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(604, 42);
			textBox9.TabIndex = 25;
			label43.AutoSize = true;
			label43.Location = new System.Drawing.Point(271, 122);
			label43.Name = "label43";
			label43.Size = new System.Drawing.Size(52, 17);
			label43.TabIndex = 24;
			label43.Text = "IoDIn：";
			textBox8.Location = new System.Drawing.Point(347, 69);
			textBox8.Multiline = true;
			textBox8.Name = "textBox8";
			textBox8.Size = new System.Drawing.Size(604, 42);
			textBox8.TabIndex = 23;
			label42.AutoSize = true;
			label42.Location = new System.Drawing.Point(271, 72);
			label42.Name = "label42";
			label42.Size = new System.Drawing.Size(62, 17);
			label42.TabIndex = 22;
			label42.Text = "IoDOut：";
			groupBox1.Controls.Add(label72);
			groupBox1.Controls.Add(label73);
			groupBox1.Controls.Add(label48);
			groupBox1.Controls.Add(label49);
			groupBox1.Controls.Add(label46);
			groupBox1.Controls.Add(label47);
			groupBox1.Controls.Add(label40);
			groupBox1.Controls.Add(label41);
			groupBox1.Controls.Add(label39);
			groupBox1.Controls.Add(label36);
			groupBox1.Controls.Add(label37);
			groupBox1.Controls.Add(label38);
			groupBox1.Controls.Add(label33);
			groupBox1.Controls.Add(label34);
			groupBox1.Controls.Add(label35);
			groupBox1.Controls.Add(label30);
			groupBox1.Controls.Add(label31);
			groupBox1.Controls.Add(label32);
			groupBox1.Controls.Add(label27);
			groupBox1.Controls.Add(label28);
			groupBox1.Controls.Add(label29);
			groupBox1.Controls.Add(label24);
			groupBox1.Controls.Add(label25);
			groupBox1.Controls.Add(label26);
			groupBox1.Controls.Add(label21);
			groupBox1.Controls.Add(label22);
			groupBox1.Controls.Add(label23);
			groupBox1.Controls.Add(label17);
			groupBox1.Controls.Add(label18);
			groupBox1.Controls.Add(label19);
			groupBox1.Controls.Add(label14);
			groupBox1.Controls.Add(label15);
			groupBox1.Controls.Add(label16);
			groupBox1.Controls.Add(label13);
			groupBox1.Controls.Add(label12);
			groupBox1.Controls.Add(label11);
			groupBox1.Location = new System.Drawing.Point(11, 66);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(243, 471);
			groupBox1.TabIndex = 21;
			groupBox1.TabStop = false;
			groupBox1.Text = "状态";
			label72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label72.Location = new System.Drawing.Point(101, 398);
			label72.Name = "label72";
			label72.Size = new System.Drawing.Size(120, 19);
			label72.TabIndex = 35;
			label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label73.AutoSize = true;
			label73.Location = new System.Drawing.Point(9, 399);
			label73.Name = "label73";
			label73.Size = new System.Drawing.Size(92, 17);
			label73.TabIndex = 34;
			label73.Text = "设备开机总长：";
			label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label48.Location = new System.Drawing.Point(101, 370);
			label48.Name = "label48";
			label48.Size = new System.Drawing.Size(120, 19);
			label48.TabIndex = 33;
			label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label49.AutoSize = true;
			label49.Location = new System.Drawing.Point(9, 371);
			label49.Name = "label49";
			label49.Size = new System.Drawing.Size(80, 17);
			label49.TabIndex = 32;
			label49.Text = "加载程序名：";
			label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label46.Location = new System.Drawing.Point(101, 341);
			label46.Name = "label46";
			label46.Size = new System.Drawing.Size(120, 19);
			label46.TabIndex = 31;
			label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label47.AutoSize = true;
			label47.Location = new System.Drawing.Point(9, 342);
			label47.Name = "label47";
			label47.Size = new System.Drawing.Size(80, 17);
			label47.TabIndex = 30;
			label47.Text = "加载工程名：";
			label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label40.Location = new System.Drawing.Point(101, 313);
			label40.Name = "label40";
			label40.Size = new System.Drawing.Size(120, 19);
			label40.TabIndex = 29;
			label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label41.AutoSize = true;
			label41.Location = new System.Drawing.Point(9, 314);
			label41.Name = "label41";
			label41.Size = new System.Drawing.Size(68, 17);
			label41.TabIndex = 28;
			label41.Text = "速度状态：";
			label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label39.Location = new System.Drawing.Point(12, 283);
			label39.Name = "label39";
			label39.Size = new System.Drawing.Size(59, 19);
			label39.TabIndex = 27;
			label39.Text = "手动";
			label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label36.Location = new System.Drawing.Point(162, 283);
			label36.Name = "label36";
			label36.Size = new System.Drawing.Size(59, 19);
			label36.TabIndex = 26;
			label36.Text = "远程";
			label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label37.Location = new System.Drawing.Point(87, 283);
			label37.Name = "label37";
			label37.Size = new System.Drawing.Size(59, 19);
			label37.TabIndex = 25;
			label37.Text = "自动";
			label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label38.AutoSize = true;
			label38.Location = new System.Drawing.Point(9, 257);
			label38.Name = "label38";
			label38.Size = new System.Drawing.Size(44, 17);
			label38.TabIndex = 24;
			label38.Text = "模式：";
			label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label33.Location = new System.Drawing.Point(166, 212);
			label33.Name = "label33";
			label33.Size = new System.Drawing.Size(59, 19);
			label33.TabIndex = 23;
			label33.Text = "无暂停";
			label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label34.Location = new System.Drawing.Point(101, 212);
			label34.Name = "label34";
			label34.Size = new System.Drawing.Size(59, 19);
			label34.TabIndex = 22;
			label34.Text = "暂停中";
			label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label35.AutoSize = true;
			label35.Location = new System.Drawing.Point(9, 213);
			label35.Name = "label35";
			label35.Size = new System.Drawing.Size(92, 17);
			label35.TabIndex = 21;
			label35.Text = "程序暂停状态：";
			label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label30.Location = new System.Drawing.Point(166, 185);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(59, 19);
			label30.TabIndex = 20;
			label30.Text = "未加载";
			label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label31.Location = new System.Drawing.Point(101, 185);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(59, 19);
			label31.TabIndex = 19;
			label31.Text = "有加载";
			label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label32.AutoSize = true;
			label32.Location = new System.Drawing.Point(9, 186);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(92, 17);
			label32.TabIndex = 18;
			label32.Text = "程序加载状态：";
			label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label27.Location = new System.Drawing.Point(166, 158);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(59, 19);
			label27.TabIndex = 17;
			label27.Text = "未运行";
			label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label28.Location = new System.Drawing.Point(101, 158);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(59, 19);
			label28.TabIndex = 16;
			label28.Text = "有运行";
			label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label29.AutoSize = true;
			label29.Location = new System.Drawing.Point(9, 159);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(92, 17);
			label29.TabIndex = 15;
			label29.Text = "程序运行状态：";
			label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label24.Location = new System.Drawing.Point(166, 131);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(59, 19);
			label24.TabIndex = 14;
			label24.Text = "未运动";
			label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label25.Location = new System.Drawing.Point(101, 131);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(59, 19);
			label25.TabIndex = 13;
			label25.Text = "有运动";
			label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(9, 132);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(80, 17);
			label26.TabIndex = 12;
			label26.Text = "轴运动状态：";
			label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label21.Location = new System.Drawing.Point(166, 103);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(59, 19);
			label21.TabIndex = 11;
			label21.Text = "未使能";
			label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label22.Location = new System.Drawing.Point(101, 103);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(59, 19);
			label22.TabIndex = 10;
			label22.Text = "有使能";
			label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(9, 104);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(68, 17);
			label23.TabIndex = 9;
			label23.Text = "伺服状态：";
			label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label17.Location = new System.Drawing.Point(166, 76);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(59, 19);
			label17.TabIndex = 8;
			label17.Text = "无权限";
			label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label18.Location = new System.Drawing.Point(101, 76);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(59, 19);
			label18.TabIndex = 7;
			label18.Text = "有权限";
			label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(9, 77);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(68, 17);
			label19.TabIndex = 6;
			label19.Text = "权限状态：";
			label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label14.Location = new System.Drawing.Point(166, 48);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(59, 19);
			label14.TabIndex = 5;
			label14.Text = "有急停";
			label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label15.Location = new System.Drawing.Point(101, 48);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(59, 19);
			label15.TabIndex = 4;
			label15.Text = "无急停";
			label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(9, 49);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(68, 17);
			label16.TabIndex = 3;
			label16.Text = "急停状态：";
			label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label13.Location = new System.Drawing.Point(166, 21);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(59, 19);
			label13.TabIndex = 2;
			label13.Text = "报警中";
			label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label12.Location = new System.Drawing.Point(101, 21);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(59, 19);
			label12.TabIndex = 1;
			label12.Text = "无报警";
			label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(9, 22);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(68, 17);
			label11.TabIndex = 0;
			label11.Text = "报警状态：";
			textBox7.Location = new System.Drawing.Point(570, 40);
			textBox7.Name = "textBox7";
			textBox7.Size = new System.Drawing.Size(89, 23);
			textBox7.TabIndex = 20;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(494, 43);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(68, 17);
			label10.TabIndex = 19;
			label10.Text = "数据心跳：";
			textBox6.Location = new System.Drawing.Point(386, 40);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(89, 23);
			textBox6.TabIndex = 18;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(310, 43);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(68, 17);
			label9.TabIndex = 17;
			label9.Text = "数据命令：";
			textBox5.Location = new System.Drawing.Point(741, 40);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(197, 23);
			textBox5.TabIndex = 16;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(665, 43);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(68, 17);
			label8.TabIndex = 15;
			label8.Text = "报文结束：";
			textBox4.Location = new System.Drawing.Point(84, 40);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(197, 23);
			textBox4.TabIndex = 14;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(8, 43);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(68, 17);
			label7.TabIndex = 13;
			label7.Text = "报文开始：";
			button3.Location = new System.Drawing.Point(395, 8);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(109, 28);
			button3.TabIndex = 12;
			button3.Text = "开始";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox3.Location = new System.Drawing.Point(289, 11);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(89, 23);
			textBox3.TabIndex = 11;
			textBox3.Text = "1000";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(213, 14);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(68, 17);
			label6.TabIndex = 10;
			label6.Text = "定时刷新：";
			button_read_short.Location = new System.Drawing.Point(11, 8);
			button_read_short.Name = "button_read_short";
			button_read_short.Size = new System.Drawing.Size(109, 28);
			button_read_short.TabIndex = 9;
			button_read_short.Text = "刷新数据";
			button_read_short.UseVisualStyleBackColor = true;
			button_read_short.Click += new System.EventHandler(button_read_short_Click);
			label61.AutoSize = true;
			label61.Location = new System.Drawing.Point(863, 489);
			label61.Name = "label61";
			label61.Size = new System.Drawing.Size(28, 17);
			label61.TabIndex = 67;
			label61.Text = "C：";
			label59.AutoSize = true;
			label59.Location = new System.Drawing.Point(863, 462);
			label59.Name = "label59";
			label59.Size = new System.Drawing.Size(28, 17);
			label59.TabIndex = 61;
			label59.Text = "B：";
			label57.AutoSize = true;
			label57.Location = new System.Drawing.Point(863, 435);
			label57.Name = "label57";
			label57.Size = new System.Drawing.Size(28, 17);
			label57.TabIndex = 55;
			label57.Text = "A：";
			label55.AutoSize = true;
			label55.Location = new System.Drawing.Point(863, 408);
			label55.Name = "label55";
			label55.Size = new System.Drawing.Size(27, 17);
			label55.TabIndex = 49;
			label55.Text = "Z：";
			label53.AutoSize = true;
			label53.Location = new System.Drawing.Point(863, 380);
			label53.Name = "label53";
			label53.Size = new System.Drawing.Size(27, 17);
			label53.TabIndex = 43;
			label53.Text = "Y：";
			label52.AutoSize = true;
			label52.Location = new System.Drawing.Point(863, 353);
			label52.Name = "label52";
			label52.Size = new System.Drawing.Size(28, 17);
			label52.TabIndex = 37;
			label52.Text = "X：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Previous";
			userControlHead1.Size = new System.Drawing.Size(982, 32);
			userControlHead1.SupportListVisiable = true;
			userControlHead1.TabIndex = 14;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(982, 648);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormEfortPrevious";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "埃夫特机器人(旧版)";
			base.Load += new System.EventHandler(FormEfort_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
