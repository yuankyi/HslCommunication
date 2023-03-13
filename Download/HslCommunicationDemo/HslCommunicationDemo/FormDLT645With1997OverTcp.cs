using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Instrument.DLT;
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
	public class FormDLT645With1997OverTcp : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003Cbutton3_Click_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormDLT645With1997OverTcp _003C_003E4__this;

			private OperateResult _003Cactive_003E5__1;

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
						awaiter = _003C_003E4__this.dLT645.ActiveDeveiceAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton3_Click_003Ed__9 stateMachine = this;
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
					_003Cactive_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cactive_003E5__1.IsSuccess)
					{
						MessageBox.Show("Send Active Code Success");
					}
					else
					{
						MessageBox.Show("Active Code failed:" + _003Cactive_003E5__1.Message);
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cactive_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cactive_003E5__1 = null;
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
		private sealed class _003Cbutton5_Click_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormDLT645With1997OverTcp _003C_003E4__this;

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
						awaiter = _003C_003E4__this.dLT645.WriteAddressAsync(_003C_003E4__this.textBox1.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton5_Click_003Ed__12 stateMachine = this;
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
						_003C_003E4__this.textBox12.Text = string.Format("[{0:HH:mm:ss}] Write Success", DateTime.Now);
					}
					else
					{
						MessageBox.Show("Read failed: " + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton6_Click_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormDLT645With1997OverTcp _003C_003E4__this;

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
						awaiter = _003C_003E4__this.dLT645.BroadcastTimeAsync(DateTime.Now).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton6_Click_003Ed__11 stateMachine = this;
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
						_003C_003E4__this.textBox12.Text = string.Format("[{0:HH:mm:ss}] BroadcastTime Success", DateTime.Now);
					}
					else
					{
						MessageBox.Show("Read failed: " + _003Cread_003E5__1.Message);
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

		private DLT645With1997OverTcp dLT645 = null;

		private IContainer components = null;

		private Panel panel1;

		private Panel panel2;

		private Button button2;

		private Button button1;

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

		private TextBox textBox_station;

		private Label label_address;

		private UserControlHead userControlHead1;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private GroupBox groupBox5;

		private TextBox textBox12;

		private Button button3;

		private Button button4;

		private Button button5;

		private TextBox textBox1;

		private Label label2;

		private Button button6;

		private TextBox textBox_port;

		private Label label3;

		private TextBox textBox_ip;

		private Label label1;

		private TextBox textBox_op_code;

		private Label label_op_code;

		private TextBox textBox_password;

		private Label label_password;

		private CheckBox checkBox_enable_Fe;

		public FormDLT645With1997OverTcp()
		{
			InitializeComponent();
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
				Text = "DLT645 Read Demo";
				label1.Text = "Com:";
				label3.Text = "baudRate:";
				label_address.Text = "station";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				button3.Text = "Active";
				label11.Text = "Address:";
				label12.Text = "length:";
				button25.Text = "Bulk Read";
				textBox_password.Text = "Pwd:";
				textBox_op_code.Text = "Op Code:";
				label13.Text = "Results:";
				label16.Text = "Message:";
				label14.Text = "Results:";
				button26.Text = "Read";
				groupBox3.Text = "Bulk Read test";
				groupBox4.Text = "Message reading test, hex string needs to be filled in";
				groupBox5.Text = "Special function test";
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox_port.Text, out result))
			{
				MessageBox.Show(DemoUtils.PortInputWrong);
			}
			else
			{
				DLT645With1997OverTcp dLT645With1997OverTcp = dLT645;
				if (dLT645With1997OverTcp != null)
				{
					dLT645With1997OverTcp.ConnectClose();
				}
				dLT645 = new DLT645With1997OverTcp(textBox_ip.Text, result, textBox_station.Text);
				dLT645.LogNet = base.LogNet;
				dLT645.EnableCodeFE = checkBox_enable_Fe.Checked;
				try
				{
					OperateResult operateResult = dLT645.ConnectServer();
					if (operateResult.IsSuccess)
					{
						MessageBox.Show(StringResources.Language.ConnectedSuccess);
						button2.Enabled = true;
						button1.Enabled = false;
						panel2.Enabled = true;
						userControlReadWriteOp1.SetReadWriteNet(dLT645, "B6-11", true);
					}
					else
					{
						MessageBox.Show(StringResources.Language.ConnectedFailed + operateResult.Message + Environment.NewLine + "Error: " + operateResult.ErrorCode.ToString());
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
			dLT645.ConnectClose();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			DemoUtils.BulkReadRenderResult(dLT645, textBox6, textBox9, textBox10);
		}

		private void button26_Click(object sender, EventArgs e)
		{
			OperateResult<byte[]> operateResult = dLT645.ReadFromCoreServer(SoftBasic.HexStringToBytes(textBox13.Text));
			if (operateResult.IsSuccess)
			{
				textBox11.Text = "Result：" + SoftBasic.ByteToHexString(operateResult.Content);
			}
			else
			{
				MessageBox.Show("Read Failed：" + operateResult.ToMessageShowString());
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton3_Click_003Ed__9))]
		[DebuggerStepThrough]
		private void button3_Click(object sender, EventArgs e)
		{
			_003Cbutton3_Click_003Ed__9 stateMachine = new _003Cbutton3_Click_003Ed__9();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button4_Click(object sender, EventArgs e)
		{
		}

		[AsyncStateMachine(typeof(_003Cbutton6_Click_003Ed__11))]
		[DebuggerStepThrough]
		private void button6_Click(object sender, EventArgs e)
		{
			_003Cbutton6_Click_003Ed__11 stateMachine = new _003Cbutton6_Click_003Ed__11();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton5_Click_003Ed__12))]
		[DebuggerStepThrough]
		private void button5_Click(object sender, EventArgs e)
		{
			_003Cbutton5_Click_003Ed__12 stateMachine = new _003Cbutton5_Click_003Ed__12();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlBaudRate, textBox_port.Text);
			element.SetAttributeValue(DemoDeviceList.XmlStation, textBox_station.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox_port.Text = element.Attribute(DemoDeviceList.XmlBaudRate).Value;
			textBox_station.Text = element.Attribute(DemoDeviceList.XmlStation).Value;
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
			checkBox_enable_Fe = new System.Windows.Forms.CheckBox();
			textBox_op_code = new System.Windows.Forms.TextBox();
			label_op_code = new System.Windows.Forms.Label();
			textBox_password = new System.Windows.Forms.TextBox();
			label_password = new System.Windows.Forms.Label();
			textBox_port = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox_ip = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			textBox_station = new System.Windows.Forms.TextBox();
			label_address = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox5 = new System.Windows.Forms.GroupBox();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			textBox1 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			textBox12 = new System.Windows.Forms.TextBox();
			groupBox4 = new System.Windows.Forms.GroupBox();
			textBox11 = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			button26 = new System.Windows.Forms.Button();
			textBox13 = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
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
			panel1.Controls.Add(checkBox_enable_Fe);
			panel1.Controls.Add(textBox_op_code);
			panel1.Controls.Add(label_op_code);
			panel1.Controls.Add(textBox_password);
			panel1.Controls.Add(label_password);
			panel1.Controls.Add(textBox_port);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox_ip);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(textBox_station);
			panel1.Controls.Add(label_address);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Location = new System.Drawing.Point(3, 36);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 62);
			panel1.TabIndex = 0;
			checkBox_enable_Fe.AutoSize = true;
			checkBox_enable_Fe.Location = new System.Drawing.Point(420, 6);
			checkBox_enable_Fe.Name = "checkBox_enable_Fe";
			checkBox_enable_Fe.Size = new System.Drawing.Size(130, 21);
			checkBox_enable_Fe.TabIndex = 39;
			checkBox_enable_Fe.Text = "FE FE FE FE head?";
			checkBox_enable_Fe.UseVisualStyleBackColor = true;
			textBox_op_code.Location = new System.Drawing.Point(330, 32);
			textBox_op_code.Name = "textBox_op_code";
			textBox_op_code.ReadOnly = true;
			textBox_op_code.Size = new System.Drawing.Size(159, 23);
			textBox_op_code.TabIndex = 38;
			label_op_code.AutoSize = true;
			label_op_code.Location = new System.Drawing.Point(244, 35);
			label_op_code.Name = "label_op_code";
			label_op_code.Size = new System.Drawing.Size(80, 17);
			label_op_code.TabIndex = 37;
			label_op_code.Text = "操作者代码：";
			textBox_password.Location = new System.Drawing.Point(58, 32);
			textBox_password.Name = "textBox_password";
			textBox_password.ReadOnly = true;
			textBox_password.Size = new System.Drawing.Size(180, 23);
			textBox_password.TabIndex = 36;
			label_password.AutoSize = true;
			label_password.Location = new System.Drawing.Point(8, 35);
			label_password.Name = "label_password";
			label_password.Size = new System.Drawing.Size(44, 17);
			label_password.TabIndex = 35;
			label_password.Text = "密码：";
			textBox_port.Location = new System.Drawing.Point(299, 4);
			textBox_port.Name = "textBox_port";
			textBox_port.Size = new System.Drawing.Size(105, 23);
			textBox_port.TabIndex = 11;
			textBox_port.Text = "502";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(245, 7);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 10;
			label3.Text = "端口号：";
			textBox_ip.Location = new System.Drawing.Point(62, 4);
			textBox_ip.Name = "textBox_ip";
			textBox_ip.Size = new System.Drawing.Size(176, 23);
			textBox_ip.TabIndex = 9;
			textBox_ip.Text = "192.168.0.100";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 7);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 8;
			label1.Text = "Ip地址：";
			textBox_station.Location = new System.Drawing.Point(554, 32);
			textBox_station.Name = "textBox_station";
			textBox_station.Size = new System.Drawing.Size(190, 23);
			textBox_station.TabIndex = 7;
			textBox_station.Text = "1";
			label_address.AutoSize = true;
			label_address.Location = new System.Drawing.Point(506, 35);
			label_address.Name = "label_address";
			label_address.Size = new System.Drawing.Size(44, 17);
			label_address.TabIndex = 6;
			label_address.Text = "站号：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(875, 11);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(778, 11);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteOp1);
			panel2.Controls.Add(groupBox5);
			panel2.Controls.Add(groupBox4);
			panel2.Controls.Add(groupBox3);
			panel2.Location = new System.Drawing.Point(3, 101);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 542);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Location = new System.Drawing.Point(3, 2);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(989, 240);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox5.Controls.Add(button6);
			groupBox5.Controls.Add(button5);
			groupBox5.Controls.Add(textBox1);
			groupBox5.Controls.Add(label2);
			groupBox5.Controls.Add(button4);
			groupBox5.Controls.Add(button3);
			groupBox5.Controls.Add(textBox12);
			groupBox5.Location = new System.Drawing.Point(546, 243);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(446, 294);
			groupBox5.TabIndex = 4;
			groupBox5.TabStop = false;
			groupBox5.Text = "特殊功能测试";
			button6.Location = new System.Drawing.Point(241, 24);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(106, 28);
			button6.TabIndex = 17;
			button6.Text = "广播时间";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button5.Location = new System.Drawing.Point(241, 56);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(106, 28);
			button5.TabIndex = 16;
			button5.Text = "写入通信地址";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			textBox1.Location = new System.Drawing.Point(65, 60);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(170, 23);
			textBox1.TabIndex = 15;
			textBox1.Text = "B6-11";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(11, 63);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 17);
			label2.TabIndex = 14;
			label2.Text = "地址：";
			button4.Enabled = false;
			button4.Location = new System.Drawing.Point(126, 24);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(106, 28);
			button4.TabIndex = 13;
			button4.Text = "读取通信地址";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button3.Location = new System.Drawing.Point(14, 24);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(106, 28);
			button3.TabIndex = 12;
			button3.Text = "唤醒接收";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox12.Location = new System.Drawing.Point(12, 102);
			textBox12.Multiline = true;
			textBox12.Name = "textBox12";
			textBox12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox12.Size = new System.Drawing.Size(428, 186);
			textBox12.TabIndex = 11;
			groupBox4.Controls.Add(textBox11);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(button26);
			groupBox4.Controls.Add(textBox13);
			groupBox4.Controls.Add(label16);
			groupBox4.Location = new System.Drawing.Point(3, 403);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(531, 134);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "报文读取测试，此处需要填入16进制报文字符串";
			textBox11.Location = new System.Drawing.Point(63, 60);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox11.Size = new System.Drawing.Size(462, 68);
			textBox11.TabIndex = 10;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(9, 62);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 9;
			label14.Text = "结果：";
			button26.Location = new System.Drawing.Point(443, 24);
			button26.Name = "button26";
			button26.Size = new System.Drawing.Size(82, 28);
			button26.TabIndex = 8;
			button26.Text = "报文读取";
			button26.UseVisualStyleBackColor = true;
			button26.Click += new System.EventHandler(button26_Click);
			textBox13.Location = new System.Drawing.Point(63, 27);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(374, 23);
			textBox13.TabIndex = 5;
			textBox13.Text = "68 00 00 00 00 00 01 68 01 B6 11 00 10 16";
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(9, 30);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(44, 17);
			label16.TabIndex = 4;
			label16.Text = "报文：";
			groupBox3.Controls.Add(textBox10);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(button25);
			groupBox3.Controls.Add(textBox9);
			groupBox3.Controls.Add(label12);
			groupBox3.Controls.Add(textBox6);
			groupBox3.Controls.Add(label11);
			groupBox3.Location = new System.Drawing.Point(3, 243);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(537, 154);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试";
			textBox10.Location = new System.Drawing.Point(63, 60);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(468, 88);
			textBox10.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 62);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "结果：";
			button25.Location = new System.Drawing.Point(426, 24);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(82, 28);
			button25.TabIndex = 8;
			button25.Text = "批量读取";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			textBox9.Location = new System.Drawing.Point(239, 27);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(102, 23);
			textBox9.TabIndex = 7;
			textBox9.Text = "1";
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
			textBox6.Text = "B6-11";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(9, 30);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 4;
			label11.Text = "地址：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/8974215.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "DLT 645 1997 Over Tcp";
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
			base.Name = "FormDLT645With1997OverTcp";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "DLT645访问Demo";
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
