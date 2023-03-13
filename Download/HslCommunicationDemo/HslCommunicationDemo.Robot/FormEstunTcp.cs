using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Robot.Estun;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace HslCommunicationDemo.Robot
{
	public class FormEstunTcp : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003Cbutton1_Click_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormEstunTcp _003C_003E4__this;

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
							_003C_003E4__this.estun = new EstunTcpNet(_003C_003E4__this.textBox1.Text, int.Parse(_003C_003E4__this.textBox2.Text), 1);
							_003C_003E4__this.estun.ConnectTimeOut = 2000;
							awaiter = _003C_003E4__this.estun.ConnectServerAsync().GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003Cbutton1_Click_003Ed__3 stateMachine = this;
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

		private EstunTcpNet estun;

		private IContainer components = null;

		private UserControlHead userControlHead1;

		private Panel panel1;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private Label label1;

		private Panel panel2;

		private Button button_read_short;

		private GroupBox groupBox1;

		private Label label46;

		private Label label47;

		private Label label40;

		private Label label41;

		private Label label39;

		private Label label36;

		private Label label37;

		private Label label38;

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

		private Label label5;

		private Label label6;

		private Label label2;

		private Label label4;

		private GroupBox groupBox2;

		private TextBox textBox11;

		private Label label45;

		private TextBox textBox10;

		private Label label44;

		private TextBox textBox9;

		private Label label43;

		private TextBox textBox8;

		private Label label42;

		private Button button3;

		private Button button8;

		private Button button7;

		private TextBox textBox4;

		private Label label8;

		private Button button6;

		private TextBox textBox3;

		private Label label7;

		private Button button5;

		private Button button4;

		private Button button9;

		private Button button10;

		public FormEstunTcp()
		{
			InitializeComponent();
		}

		private void FormEstunTcp_Load(object sender, EventArgs e)
		{
			estun = new EstunTcpNet();
			panel2.Enabled = false;
		}

		[AsyncStateMachine(typeof(_003Cbutton1_Click_003Ed__3))]
		[DebuggerStepThrough]
		private void button1_Click(object sender, EventArgs e)
		{
			_003Cbutton1_Click_003Ed__3 stateMachine = new _003Cbutton1_Click_003Ed__3();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			EstunTcpNet estunTcpNet = estun;
			if (estunTcpNet != null)
			{
				estunTcpNet.ConnectClose();
			}
			button2.Enabled = false;
			panel2.Enabled = false;
			button1.Enabled = true;
		}

		private void button_read_short_Click(object sender, EventArgs e)
		{
			OperateResult<EstunData> operateResult = estun.ReadRobotData();
			if (operateResult.IsSuccess)
			{
				EstunData content = operateResult.Content;
				label12.BackColor = (content.ErrorStatus ? SystemColors.Control : Color.Tomato);
				label13.BackColor = (content.ErrorStatus ? Color.Tomato : SystemColors.Control);
				label15.BackColor = (content.EnableStatus ? SystemColors.Control : Color.Tomato);
				label14.BackColor = (content.EnableStatus ? Color.Tomato : SystemColors.Control);
				label18.BackColor = (content.RunStatus ? SystemColors.Control : Color.Tomato);
				label17.BackColor = (content.RunStatus ? Color.Tomato : SystemColors.Control);
				label22.BackColor = (content.ProgramRunStatus ? SystemColors.Control : Color.Tomato);
				label21.BackColor = (content.ProgramRunStatus ? Color.Tomato : SystemColors.Control);
				label25.BackColor = (content.RobotMoving ? SystemColors.Control : Color.Tomato);
				label24.BackColor = (content.RobotMoving ? Color.Tomato : SystemColors.Control);
				label39.BackColor = (content.ManualMode ? Color.Tomato : SystemColors.Control);
				label37.BackColor = (content.AutoMode ? Color.Tomato : SystemColors.Control);
				label36.BackColor = (content.RemoteMode ? Color.Tomato : SystemColors.Control);
				label40.Text = content.GlobalSpeedValue.ToString();
				label46.Text = content.ProjectName;
				label2.Text = "0x" + content.RobotCommandStatus.ToString("X");
				label5.Text = content.ReadWriteFlag.ToString();
				textBox8.Text = content.DO.ToArrayString();
				textBox9.Text = content.DI.ToArrayString();
				textBox10.Text = content.AO.ToArrayString();
				textBox11.Text = content.AI.ToArrayString();
			}
			else
			{
				MessageBox.Show("Read Failed: " + operateResult.Message);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = estun.RobotStartPrograme();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("启动成功！");
			}
			else
			{
				MessageBox.Show("启动失败！" + operateResult.Message);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = estun.RobotStopPrograme();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("停止成功！");
			}
			else
			{
				MessageBox.Show("停止失败！" + operateResult.Message);
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = estun.RobotResetError();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("复位成功！");
			}
			else
			{
				MessageBox.Show("复位失败！" + operateResult.Message);
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = estun.RobotCommandStatusRestart();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("重置成功！");
			}
			else
			{
				MessageBox.Show("重置失败！" + operateResult.Message);
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = estun.RobotUnregisterProject();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("卸载成功！");
			}
			else
			{
				MessageBox.Show("卸载失败！" + operateResult.Message);
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = estun.RobotLoadProject(textBox3.Text);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("加载成功！");
			}
			else
			{
				MessageBox.Show("加载失败！" + operateResult.Message);
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = estun.RobotSetGlobalSpeedValue(short.Parse(textBox4.Text));
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("加载成功！");
			}
			else
			{
				MessageBox.Show("加载失败！" + operateResult.Message);
			}
		}

		private void button10_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = estun.Write("36", (short)2049);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("下载成功！");
			}
			else
			{
				MessageBox.Show("下载失败！");
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
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1 = new System.Windows.Forms.Panel();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			groupBox2 = new System.Windows.Forms.GroupBox();
			button9 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			button6 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			button5 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			textBox11 = new System.Windows.Forms.TextBox();
			label45 = new System.Windows.Forms.Label();
			textBox10 = new System.Windows.Forms.TextBox();
			label44 = new System.Windows.Forms.Label();
			textBox9 = new System.Windows.Forms.TextBox();
			label43 = new System.Windows.Forms.Label();
			textBox8 = new System.Windows.Forms.TextBox();
			label42 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label46 = new System.Windows.Forms.Label();
			label47 = new System.Windows.Forms.Label();
			label40 = new System.Windows.Forms.Label();
			label41 = new System.Windows.Forms.Label();
			label39 = new System.Windows.Forms.Label();
			label36 = new System.Windows.Forms.Label();
			label37 = new System.Windows.Forms.Label();
			label38 = new System.Windows.Forms.Label();
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
			button_read_short = new System.Windows.Forms.Button();
			button10 = new System.Windows.Forms.Button();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "modbus tcp";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.SupportListVisiable = true;
			userControlHead1.TabIndex = 15;
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(2, 34);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1000, 43);
			panel1.TabIndex = 16;
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
			textBox2.Text = "502";
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
			panel2.Controls.Add(textBox11);
			panel2.Controls.Add(label45);
			panel2.Controls.Add(textBox10);
			panel2.Controls.Add(label44);
			panel2.Controls.Add(textBox9);
			panel2.Controls.Add(label43);
			panel2.Controls.Add(textBox8);
			panel2.Controls.Add(label42);
			panel2.Controls.Add(groupBox1);
			panel2.Controls.Add(button_read_short);
			panel2.Location = new System.Drawing.Point(2, 81);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(1000, 562);
			panel2.TabIndex = 17;
			groupBox2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox2.Controls.Add(button10);
			groupBox2.Controls.Add(button9);
			groupBox2.Controls.Add(button8);
			groupBox2.Controls.Add(button7);
			groupBox2.Controls.Add(textBox4);
			groupBox2.Controls.Add(label8);
			groupBox2.Controls.Add(button6);
			groupBox2.Controls.Add(textBox3);
			groupBox2.Controls.Add(label7);
			groupBox2.Controls.Add(button5);
			groupBox2.Controls.Add(button4);
			groupBox2.Controls.Add(button3);
			groupBox2.Location = new System.Drawing.Point(252, 228);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(737, 323);
			groupBox2.TabIndex = 38;
			groupBox2.TabStop = false;
			groupBox2.Text = "特殊功能";
			button9.Location = new System.Drawing.Point(475, 30);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(114, 30);
			button9.TabIndex = 44;
			button9.Text = "卸载工程文件";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			button8.Location = new System.Drawing.Point(340, 30);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(129, 30);
			button8.TabIndex = 43;
			button8.Text = "指令状态机重置";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			button7.Location = new System.Drawing.Point(387, 98);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(114, 30);
			button7.TabIndex = 42;
			button7.Text = "设置全局速度";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			textBox4.Location = new System.Drawing.Point(108, 102);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(263, 23);
			textBox4.TabIndex = 41;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(22, 105);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(68, 17);
			label8.TabIndex = 40;
			label8.Text = "全局速度：";
			button6.Location = new System.Drawing.Point(387, 64);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(114, 30);
			button6.TabIndex = 39;
			button6.Text = "加载工程文件";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			textBox3.Location = new System.Drawing.Point(108, 68);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(263, 23);
			textBox3.TabIndex = 38;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(22, 71);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(80, 17);
			label7.TabIndex = 37;
			label7.Text = "工程文件名：";
			button5.Location = new System.Drawing.Point(220, 30);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(114, 30);
			button5.TabIndex = 2;
			button5.Text = "机器人错误复位";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			button4.Location = new System.Drawing.Point(123, 30);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(91, 30);
			button4.TabIndex = 1;
			button4.Text = "停止程序";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button3.Location = new System.Drawing.Point(26, 30);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(91, 30);
			button3.TabIndex = 0;
			button3.Text = "启动程序";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox11.Location = new System.Drawing.Point(340, 169);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.Size = new System.Drawing.Size(649, 42);
			textBox11.TabIndex = 37;
			label45.AutoSize = true;
			label45.Location = new System.Drawing.Point(264, 172);
			label45.Name = "label45";
			label45.Size = new System.Drawing.Size(39, 17);
			label45.TabIndex = 36;
			label45.Text = "AIn：";
			textBox10.Location = new System.Drawing.Point(340, 114);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.Size = new System.Drawing.Size(649, 42);
			textBox10.TabIndex = 35;
			label44.AutoSize = true;
			label44.Location = new System.Drawing.Point(264, 117);
			label44.Name = "label44";
			label44.Size = new System.Drawing.Size(49, 17);
			label44.TabIndex = 34;
			label44.Text = "AOut：";
			textBox9.Location = new System.Drawing.Point(340, 61);
			textBox9.Multiline = true;
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(649, 42);
			textBox9.TabIndex = 33;
			label43.AutoSize = true;
			label43.Location = new System.Drawing.Point(264, 64);
			label43.Name = "label43";
			label43.Size = new System.Drawing.Size(40, 17);
			label43.TabIndex = 32;
			label43.Text = "DIn：";
			textBox8.Location = new System.Drawing.Point(340, 11);
			textBox8.Multiline = true;
			textBox8.Name = "textBox8";
			textBox8.Size = new System.Drawing.Size(649, 42);
			textBox8.TabIndex = 31;
			label42.AutoSize = true;
			label42.Location = new System.Drawing.Point(264, 14);
			label42.Name = "label42";
			label42.Size = new System.Drawing.Size(50, 17);
			label42.TabIndex = 30;
			label42.Text = "DOut：";
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label46);
			groupBox1.Controls.Add(label47);
			groupBox1.Controls.Add(label40);
			groupBox1.Controls.Add(label41);
			groupBox1.Controls.Add(label39);
			groupBox1.Controls.Add(label36);
			groupBox1.Controls.Add(label37);
			groupBox1.Controls.Add(label38);
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
			groupBox1.Location = new System.Drawing.Point(3, 37);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(243, 514);
			groupBox1.TabIndex = 22;
			groupBox1.TabStop = false;
			groupBox1.Text = "状态";
			label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label5.Location = new System.Drawing.Point(101, 300);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(120, 19);
			label5.TabIndex = 35;
			label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(9, 301);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(80, 17);
			label6.TabIndex = 34;
			label6.Text = "读写标志位：";
			label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label2.Location = new System.Drawing.Point(101, 272);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(120, 19);
			label2.TabIndex = 33;
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(9, 273);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(92, 17);
			label4.TabIndex = 32;
			label4.Text = "执行命令状态：";
			label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label46.Location = new System.Drawing.Point(101, 243);
			label46.Name = "label46";
			label46.Size = new System.Drawing.Size(120, 19);
			label46.TabIndex = 31;
			label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label47.AutoSize = true;
			label47.Location = new System.Drawing.Point(9, 244);
			label47.Name = "label47";
			label47.Size = new System.Drawing.Size(80, 17);
			label47.TabIndex = 30;
			label47.Text = "加载工程名：";
			label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label40.Location = new System.Drawing.Point(101, 215);
			label40.Name = "label40";
			label40.Size = new System.Drawing.Size(120, 19);
			label40.TabIndex = 29;
			label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label41.AutoSize = true;
			label41.Location = new System.Drawing.Point(9, 216);
			label41.Name = "label41";
			label41.Size = new System.Drawing.Size(68, 17);
			label41.TabIndex = 28;
			label41.Text = "全局速度：";
			label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label39.Location = new System.Drawing.Point(12, 185);
			label39.Name = "label39";
			label39.Size = new System.Drawing.Size(59, 19);
			label39.TabIndex = 27;
			label39.Text = "手动";
			label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label36.Location = new System.Drawing.Point(162, 185);
			label36.Name = "label36";
			label36.Size = new System.Drawing.Size(59, 19);
			label36.TabIndex = 26;
			label36.Text = "远程";
			label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label37.Location = new System.Drawing.Point(87, 185);
			label37.Name = "label37";
			label37.Size = new System.Drawing.Size(59, 19);
			label37.TabIndex = 25;
			label37.Text = "自动";
			label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label38.AutoSize = true;
			label38.Location = new System.Drawing.Point(9, 159);
			label38.Name = "label38";
			label38.Size = new System.Drawing.Size(44, 17);
			label38.TabIndex = 24;
			label38.Text = "模式：";
			label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label24.Location = new System.Drawing.Point(166, 131);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(59, 19);
			label24.TabIndex = 14;
			label24.Text = "动作中";
			label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label25.Location = new System.Drawing.Point(101, 131);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(59, 19);
			label25.TabIndex = 13;
			label25.Text = "无动作";
			label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(9, 132);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(80, 17);
			label26.TabIndex = 12;
			label26.Text = "机器人动作：";
			label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label21.Location = new System.Drawing.Point(166, 103);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(59, 19);
			label21.TabIndex = 11;
			label21.Text = "运行中";
			label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label22.Location = new System.Drawing.Point(101, 103);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(59, 19);
			label22.TabIndex = 10;
			label22.Text = "无运行";
			label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(9, 104);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(92, 17);
			label23.TabIndex = 9;
			label23.Text = "程序运行状态：";
			label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label17.Location = new System.Drawing.Point(166, 76);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(59, 19);
			label17.TabIndex = 8;
			label17.Text = "运行中";
			label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label18.Location = new System.Drawing.Point(101, 76);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(59, 19);
			label18.TabIndex = 7;
			label18.Text = "无运行";
			label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(9, 77);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(68, 17);
			label19.TabIndex = 6;
			label19.Text = "运行状态：";
			label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label14.Location = new System.Drawing.Point(166, 48);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(59, 19);
			label14.TabIndex = 5;
			label14.Text = "使能中";
			label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label15.Location = new System.Drawing.Point(101, 48);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(59, 19);
			label15.TabIndex = 4;
			label15.Text = "无使能";
			label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(9, 49);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(68, 17);
			label16.TabIndex = 3;
			label16.Text = "使能状态：";
			label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label13.Location = new System.Drawing.Point(166, 21);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(59, 19);
			label13.TabIndex = 2;
			label13.Text = "错误中";
			label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label12.Location = new System.Drawing.Point(101, 21);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(59, 19);
			label12.TabIndex = 1;
			label12.Text = "无错误";
			label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(9, 22);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(68, 17);
			label11.TabIndex = 0;
			label11.Text = "错误状态：";
			button_read_short.Location = new System.Drawing.Point(3, 3);
			button_read_short.Name = "button_read_short";
			button_read_short.Size = new System.Drawing.Size(109, 28);
			button_read_short.TabIndex = 10;
			button_read_short.Text = "刷新数据";
			button_read_short.UseVisualStyleBackColor = true;
			button_read_short.Click += new System.EventHandler(button_read_short_Click);
			button10.Location = new System.Drawing.Point(595, 30);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(129, 30);
			button10.TabIndex = 45;
			button10.Text = "强制0x801命令";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(button10_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			base.Controls.Add(userControlHead1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "FormEstunTcp";
			Text = "FormEstunTcp";
			base.Load += new System.EventHandler(FormEstunTcp_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
