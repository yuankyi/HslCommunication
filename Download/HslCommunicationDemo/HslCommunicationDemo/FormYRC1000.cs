using HslCommunication;
using HslCommunication.Robot.YASKAWA;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormYRC1000 : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003Cbutton14_Click_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormYRC1000 _003C_003E4__this;

			private OperateResult _003C_003Es__1;

			private Exception _003Cex_003E5__2;

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
							awaiter = _003C_003E4__this.YRC1000Tcp.WriteAsync(_003C_003E4__this.textBox8.Text, _003C_003E4__this.textBox7.Text).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003Cbutton14_Click_003Ed__10 stateMachine = this;
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
						_003C_003E4__this.writeResultRender(_003C_003Es__1, _003C_003E4__this.textBox8.Text);
						_003C_003Es__1 = null;
					}
					catch (Exception ex)
					{
						Exception ex2 = _003Cex_003E5__2 = ex;
						MessageBox.Show(_003Cex_003E5__2.Message);
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
		private sealed class _003Cbutton1_Click_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormYRC1000 _003C_003E4__this;

			private int _003Cport_003E5__1;

			private OperateResult _003Cconnect_003E5__2;

			private OperateResult _003C_003Es__3;

			private Exception _003Cex_003E5__4;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					if (num == 0)
					{
						goto IL_007f;
					}
					if (int.TryParse(_003C_003E4__this.textBox2.Text, out _003Cport_003E5__1))
					{
						YRC1000TcpNet yRC1000Tcp = _003C_003E4__this.YRC1000Tcp;
						if (yRC1000Tcp != null)
						{
							yRC1000Tcp.ConnectClose();
						}
						_003C_003E4__this.YRC1000Tcp = new YRC1000TcpNet(_003C_003E4__this.textBox1.Text, _003Cport_003E5__1);
						goto IL_007f;
					}
					MessageBox.Show("端口输入格式不正确！");
					goto end_IL_0007;
					IL_007f:
					try
					{
						TaskAwaiter<OperateResult> awaiter;
						if (num != 0)
						{
							awaiter = _003C_003E4__this.YRC1000Tcp.ConnectServerAsync().GetAwaiter();
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
						_003C_003Es__3 = awaiter.GetResult();
						_003Cconnect_003E5__2 = _003C_003Es__3;
						_003C_003Es__3 = null;
						if (_003Cconnect_003E5__2.IsSuccess)
						{
							MessageBox.Show("连接成功！");
							_003C_003E4__this.button2.Enabled = true;
							_003C_003E4__this.button1.Enabled = false;
							_003C_003E4__this.panel2.Enabled = true;
						}
						else
						{
							MessageBox.Show("连接失败！");
						}
						_003Cconnect_003E5__2 = null;
					}
					catch (Exception ex)
					{
						Exception ex2 = _003Cex_003E5__4 = ex;
						MessageBox.Show(_003Cex_003E5__4.Message);
					}
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
		private sealed class _003Cbutton_read_string_Click_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormYRC1000 _003C_003E4__this;

			private OperateResult<string> _003C_003Es__1;

			private TaskAwaiter<OperateResult<string>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<string>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.YRC1000Tcp.ReadStringAsync(_003C_003E4__this.textBox3.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_read_string_Click_003Ed__9 stateMachine = this;
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
					_003C_003Es__1 = awaiter.GetResult();
					_003C_003E4__this.readResultRender(_003C_003Es__1, _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4);
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

		private YRC1000TcpNet YRC1000Tcp = null;

		private IContainer components = null;

		private Panel panel1;

		private Label label1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private GroupBox groupBox2;

		private Button button14;

		private TextBox textBox7;

		private Label label9;

		private TextBox textBox8;

		private Label label10;

		private GroupBox groupBox1;

		private Button button_read_string;

		private TextBox textBox4;

		private Label label7;

		private TextBox textBox3;

		private Label label6;

		private Label label22;

		private Label label21;

		private Label label8;

		private UserControlHead userControlHead1;

		private Button button4;

		private Button button3;

		private Button button20;

		private Button button19;

		private Button button18;

		private TextBox textBox6;

		private Label label5;

		private Button button17;

		private Button button16;

		private Button button15;

		private Button button13;

		private Label label4;

		private Button button12;

		private Button button11;

		private Button button10;

		private Button button9;

		private Button button8;

		private TextBox textBox5;

		private Label label2;

		private Button button7;

		private Button button6;

		private Button button5;

		private Label label11;

		private ComboBox comboBox1;

		private Button button22;

		private Button button21;

		public FormYRC1000()
		{
			InitializeComponent();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			comboBox1.DataSource = new string[12]
			{
				"基坐标",
				"机器坐标",
				"用户1",
				"用户2",
				"用户3",
				"用户4",
				"用户5",
				"用户6",
				"用户7",
				"用户8",
				"用户9",
				"用户10"
			};
			comboBox1.SelectedIndex = 0;
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "YASKAWA Robot Demo";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
				label6.Text = "address:";
				label7.Text = "result:";
				button_read_string.Text = "r-string";
				label10.Text = "Address:";
				label9.Text = "Value:";
				button14.Text = "w-string";
				groupBox1.Text = "Single Data Read test";
				groupBox2.Text = "Single Data Write test";
				label22.Text = "Parameter name of robot";
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void readResultRender<T>(OperateResult<T> result, string address, TextBox textBox)
		{
			if (result.IsSuccess)
			{
				textBox.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + string.Format("[{0}] {1}{2}", address, result.Content, Environment.NewLine));
			}
			else
			{
				MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + "[" + address + "] Read Failed" + Environment.NewLine + " Reason：" + result.ToMessageShowString());
			}
		}

		private void writeResultRender(OperateResult result, string address)
		{
			if (result.IsSuccess)
			{
				MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + "[" + address + "] Write Success");
			}
			else
			{
				MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + "[" + address + "] Write Failed" + Environment.NewLine + " Reason：" + result.ToMessageShowString());
			}
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

		private void button2_Click(object sender, EventArgs e)
		{
			YRC1000Tcp.ConnectClose();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		[AsyncStateMachine(typeof(_003Cbutton_read_string_Click_003Ed__9))]
		[DebuggerStepThrough]
		private void button_read_string_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_string_Click_003Ed__9 stateMachine = new _003Cbutton_read_string_Click_003Ed__9();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton14_Click_003Ed__10))]
		[DebuggerStepThrough]
		private void button14_Click(object sender, EventArgs e)
		{
			_003Cbutton14_Click_003Ed__10 stateMachine = new _003Cbutton14_Click_003Ed__10();
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

		private void button3_Click(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = YRC1000Tcp.ReadALARM();
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + operateResult.Content;
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = YRC1000Tcp.ReadPOSJ();
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + operateResult.Content;
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			OperateResult<YRCRobotData> operateResult = YRC1000Tcp.ReadPOSC(comboBox1.SelectedIndex, true);
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			OperateResult<bool[]> operateResult = YRC1000Tcp.ReadStats();
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + "[ 0] 单步              " + operateResult.Content[0].ToString() + Environment.NewLine + "[ 1] 1循环             " + operateResult.Content[1].ToString() + Environment.NewLine + "[ 2] 自动连续          " + operateResult.Content[2].ToString() + Environment.NewLine + "[ 3] 运行中            " + operateResult.Content[3].ToString() + Environment.NewLine + "[ 4] 运转中            " + operateResult.Content[4].ToString() + Environment.NewLine + "[ 5] 示教              " + operateResult.Content[5].ToString() + Environment.NewLine + "[ 6] 在线              " + operateResult.Content[6].ToString() + Environment.NewLine + "[ 7] 命令模式          " + operateResult.Content[7].ToString() + Environment.NewLine + "[ 9] 示教编程器HOLD中   " + operateResult.Content[9].ToString() + Environment.NewLine + "[10] 外部HOLD中        " + operateResult.Content[10].ToString() + Environment.NewLine + "[11] 命令HOLD中        " + operateResult.Content[11].ToString() + Environment.NewLine + "[12] 发生警报          " + operateResult.Content[12].ToString() + Environment.NewLine + "[13] 发生错误          " + operateResult.Content[13].ToString() + Environment.NewLine + "[14] 伺服ON            " + operateResult.Content[14].ToString() + Environment.NewLine;
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = YRC1000Tcp.ReadJSeq();
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + "程序名，行编号，步编号: " + operateResult.Content;
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = YRC1000Tcp.ReadByteVariable(textBox5.Text);
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + operateResult.Content;
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = YRC1000Tcp.ReadIntegerVariable(textBox5.Text);
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + operateResult.Content;
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button10_Click(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = YRC1000Tcp.ReadDoubleIntegerVariable(textBox5.Text);
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + operateResult.Content;
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = YRC1000Tcp.ReadRealVariable(textBox5.Text);
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + operateResult.Content;
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button12_Click(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = YRC1000Tcp.ReadStringVariable(textBox5.Text);
			if (operateResult.IsSuccess)
			{
				textBox4.Text = DateTime.Now.ToString() + Environment.NewLine + operateResult.Content;
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button13_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = YRC1000Tcp.Hold(true);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("HOLD ON Success");
			}
			else
			{
				MessageBox.Show("HOLD ON Failed: " + operateResult.Message);
			}
		}

		private void button15_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = YRC1000Tcp.Hold(false);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("HOLD OFF Success");
			}
			else
			{
				MessageBox.Show("HOLD OFF Failed: " + operateResult.Message);
			}
		}

		private void button16_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = YRC1000Tcp.Reset();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("RESET Success");
			}
			else
			{
				MessageBox.Show("RESET Failed: " + operateResult.Message);
			}
		}

		private void button17_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = YRC1000Tcp.Cancel();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Cancel Success");
			}
			else
			{
				MessageBox.Show("Cancel Failed: " + operateResult.Message);
			}
		}

		private void button21_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = YRC1000Tcp.Svon(true);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("SVON ON Success");
			}
			else
			{
				MessageBox.Show("SVON ON Failed: " + operateResult.Message);
			}
		}

		private void button22_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = YRC1000Tcp.Svon(false);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("SVON OFF Success");
			}
			else
			{
				MessageBox.Show("SVON OFF Failed: " + operateResult.Message);
			}
		}

		private void button18_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = YRC1000Tcp.Start(textBox6.Text);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Start Success");
			}
			else
			{
				MessageBox.Show("Start Failed: " + operateResult.Message);
			}
		}

		private void button19_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = YRC1000Tcp.Delete(textBox6.Text);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Delte Success");
			}
			else
			{
				MessageBox.Show("Delte Failed: " + operateResult.Message);
			}
		}

		private void button20_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = YRC1000Tcp.SetMJ(textBox6.Text);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Set Success");
			}
			else
			{
				MessageBox.Show("Set Failed: " + operateResult.Message);
			}
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
			label22 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			groupBox2 = new System.Windows.Forms.GroupBox();
			button14 = new System.Windows.Forms.Button();
			textBox7 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			textBox8 = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			button22 = new System.Windows.Forms.Button();
			button21 = new System.Windows.Forms.Button();
			comboBox1 = new System.Windows.Forms.ComboBox();
			button20 = new System.Windows.Forms.Button();
			button19 = new System.Windows.Forms.Button();
			button18 = new System.Windows.Forms.Button();
			textBox6 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			button17 = new System.Windows.Forms.Button();
			button16 = new System.Windows.Forms.Button();
			button15 = new System.Windows.Forms.Button();
			button13 = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			button12 = new System.Windows.Forms.Button();
			button11 = new System.Windows.Forms.Button();
			button10 = new System.Windows.Forms.Button();
			button9 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			textBox5 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			button7 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			label8 = new System.Windows.Forms.Label();
			button_read_string = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
			panel1.Size = new System.Drawing.Size(997, 42);
			panel1.TabIndex = 0;
			label22.Location = new System.Drawing.Point(651, 0);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(341, 45);
			label22.TabIndex = 7;
			label22.Text = "RALARM      IOREAD;50010,24        HOLD;0      RPOSC:0,0";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(565, 0);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(80, 17);
			label21.TabIndex = 6;
			label21.Text = "自定义示例：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(468, 6);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(361, 6);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(272, 9);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(83, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "80";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(218, 12);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 9);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(141, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "192.168.0.100";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(groupBox2);
			panel2.Controls.Add(groupBox1);
			panel2.Location = new System.Drawing.Point(3, 80);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 563);
			panel2.TabIndex = 1;
			groupBox2.Controls.Add(button14);
			groupBox2.Controls.Add(textBox7);
			groupBox2.Controls.Add(label9);
			groupBox2.Controls.Add(textBox8);
			groupBox2.Controls.Add(label10);
			groupBox2.Location = new System.Drawing.Point(653, 2);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(339, 556);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "单数据写入测试";
			button14.Location = new System.Drawing.Point(251, 24);
			button14.Name = "button14";
			button14.Size = new System.Drawing.Size(82, 28);
			button14.TabIndex = 16;
			button14.Text = "字符串写入";
			button14.UseVisualStyleBackColor = true;
			button14.Click += new System.EventHandler(button14_Click);
			textBox7.Location = new System.Drawing.Point(63, 56);
			textBox7.Multiline = true;
			textBox7.Name = "textBox7";
			textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox7.Size = new System.Drawing.Size(270, 476);
			textBox7.TabIndex = 5;
			textBox7.Text = "10";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(9, 58);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(32, 17);
			label9.TabIndex = 4;
			label9.Text = "值：";
			textBox8.Location = new System.Drawing.Point(63, 27);
			textBox8.Name = "textBox8";
			textBox8.Size = new System.Drawing.Size(132, 23);
			textBox8.TabIndex = 3;
			textBox8.Text = "IOWRITE";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(9, 30);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(44, 17);
			label10.TabIndex = 2;
			label10.Text = "地址：";
			groupBox1.Controls.Add(button22);
			groupBox1.Controls.Add(button21);
			groupBox1.Controls.Add(comboBox1);
			groupBox1.Controls.Add(button20);
			groupBox1.Controls.Add(button19);
			groupBox1.Controls.Add(button18);
			groupBox1.Controls.Add(textBox6);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(button17);
			groupBox1.Controls.Add(button16);
			groupBox1.Controls.Add(button15);
			groupBox1.Controls.Add(button13);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(button12);
			groupBox1.Controls.Add(button11);
			groupBox1.Controls.Add(button10);
			groupBox1.Controls.Add(button9);
			groupBox1.Controls.Add(button8);
			groupBox1.Controls.Add(textBox5);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(button7);
			groupBox1.Controls.Add(button6);
			groupBox1.Controls.Add(button5);
			groupBox1.Controls.Add(button4);
			groupBox1.Controls.Add(button3);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(button_read_string);
			groupBox1.Controls.Add(textBox4);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(textBox3);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(label11);
			groupBox1.Location = new System.Drawing.Point(4, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(643, 555);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "单数据读取测试";
			button22.Location = new System.Drawing.Point(483, 118);
			button22.Name = "button22";
			button22.Size = new System.Drawing.Size(80, 28);
			button22.TabIndex = 43;
			button22.Text = "Svon OFF";
			button22.UseVisualStyleBackColor = true;
			button22.Click += new System.EventHandler(button22_Click);
			button21.Location = new System.Drawing.Point(397, 118);
			button21.Name = "button21";
			button21.Size = new System.Drawing.Size(80, 28);
			button21.TabIndex = 42;
			button21.Text = "Svon ON";
			button21.UseVisualStyleBackColor = true;
			button21.Click += new System.EventHandler(button21_Click);
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(450, 58);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(82, 25);
			comboBox1.TabIndex = 41;
			button20.Location = new System.Drawing.Point(384, 149);
			button20.Name = "button20";
			button20.Size = new System.Drawing.Size(82, 28);
			button20.TabIndex = 39;
			button20.Text = "设定主程序";
			button20.UseVisualStyleBackColor = true;
			button20.Click += new System.EventHandler(button20_Click);
			button19.Location = new System.Drawing.Point(296, 149);
			button19.Name = "button19";
			button19.Size = new System.Drawing.Size(82, 28);
			button19.TabIndex = 38;
			button19.Text = "删除程序";
			button19.UseVisualStyleBackColor = true;
			button19.Click += new System.EventHandler(button19_Click);
			button18.Location = new System.Drawing.Point(205, 149);
			button18.Name = "button18";
			button18.Size = new System.Drawing.Size(82, 28);
			button18.TabIndex = 37;
			button18.Text = "启动程序";
			button18.UseVisualStyleBackColor = true;
			button18.Click += new System.EventHandler(button18_Click);
			textBox6.Location = new System.Drawing.Point(71, 152);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(128, 23);
			textBox6.TabIndex = 36;
			textBox6.Text = "*";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(9, 155);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(56, 17);
			label5.TabIndex = 35;
			label5.Text = "程序名：";
			button17.Location = new System.Drawing.Point(326, 118);
			button17.Name = "button17";
			button17.Size = new System.Drawing.Size(65, 28);
			button17.TabIndex = 34;
			button17.Text = "Cancel";
			button17.UseVisualStyleBackColor = true;
			button17.Click += new System.EventHandler(button17_Click);
			button16.Location = new System.Drawing.Point(255, 118);
			button16.Name = "button16";
			button16.Size = new System.Drawing.Size(65, 28);
			button16.TabIndex = 33;
			button16.Text = "Reset";
			button16.UseVisualStyleBackColor = true;
			button16.Click += new System.EventHandler(button16_Click);
			button15.Location = new System.Drawing.Point(163, 118);
			button15.Name = "button15";
			button15.Size = new System.Drawing.Size(86, 28);
			button15.TabIndex = 32;
			button15.Text = "Hold OFF";
			button15.UseVisualStyleBackColor = true;
			button15.Click += new System.EventHandler(button15_Click);
			button13.Location = new System.Drawing.Point(71, 118);
			button13.Name = "button13";
			button13.Size = new System.Drawing.Size(86, 28);
			button13.TabIndex = 31;
			button13.Text = "Hold ON";
			button13.UseVisualStyleBackColor = true;
			button13.Click += new System.EventHandler(button13_Click);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(9, 124);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(68, 17);
			label4.TabIndex = 30;
			label4.Text = "控制操作：";
			button12.Location = new System.Drawing.Point(536, 88);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(95, 28);
			button12.TabIndex = 29;
			button12.Text = "字符串读取";
			button12.UseVisualStyleBackColor = true;
			button12.Click += new System.EventHandler(button12_Click);
			button11.Location = new System.Drawing.Point(435, 88);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(95, 28);
			button11.TabIndex = 28;
			button11.Text = "实数读取";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			button10.Location = new System.Drawing.Point(338, 88);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(91, 28);
			button10.TabIndex = 27;
			button10.Text = "双整型读取";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(button10_Click);
			button9.Location = new System.Drawing.Point(250, 88);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(82, 28);
			button9.TabIndex = 26;
			button9.Text = "整型读取";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			button8.Location = new System.Drawing.Point(162, 88);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(82, 28);
			button8.TabIndex = 25;
			button8.Text = "字节读取";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			textBox5.Location = new System.Drawing.Point(71, 91);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(85, 23);
			textBox5.TabIndex = 24;
			textBox5.Text = "000";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(9, 94);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(68, 17);
			label2.TabIndex = 23;
			label2.Text = "变量地址：";
			button7.Location = new System.Drawing.Point(361, 57);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(83, 28);
			button7.TabIndex = 22;
			button7.Text = "程序名读取";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			button6.Location = new System.Drawing.Point(276, 57);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(79, 28);
			button6.TabIndex = 21;
			button6.Text = "状态读取";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button5.Location = new System.Drawing.Point(536, 56);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(101, 28);
			button5.TabIndex = 20;
			button5.Text = "姿态坐标读取";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			button4.Location = new System.Drawing.Point(179, 57);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(91, 28);
			button4.TabIndex = 19;
			button4.Text = "关节坐标读取";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button3.Location = new System.Drawing.Point(71, 57);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(102, 28);
			button3.TabIndex = 18;
			button3.Text = "报警信息读取";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(55, 534);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(296, 17);
			label8.TabIndex = 17;
			label8.Text = "如果是带命令数据的。使用点，分号，冒号来区分指令";
			button_read_string.Location = new System.Drawing.Point(555, 24);
			button_read_string.Name = "button_read_string";
			button_read_string.Size = new System.Drawing.Size(82, 28);
			button_read_string.TabIndex = 16;
			button_read_string.Text = "字符串读取";
			button_read_string.UseVisualStyleBackColor = true;
			button_read_string.Click += new System.EventHandler(button_read_string_Click);
			textBox4.Location = new System.Drawing.Point(58, 179);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox4.Size = new System.Drawing.Size(579, 352);
			textBox4.TabIndex = 5;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(9, 179);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(44, 17);
			label7.TabIndex = 4;
			label7.Text = "结果：";
			textBox3.Location = new System.Drawing.Point(95, 27);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(454, 23);
			textBox3.TabIndex = 3;
			textBox3.Text = "RALARM";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(9, 30);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(80, 17);
			label6.TabIndex = 2;
			label6.Text = "自定义命令：";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(9, 63);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(68, 17);
			label11.TabIndex = 40;
			label11.Text = "状态读取：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "YASKAWA - Ethernet 服务器功能(非高速)";
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
			base.Name = "FormYRC1000";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "安川机器人访问Demo";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
