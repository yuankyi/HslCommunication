using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Robot.YAMAHA;
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
	public class FormYamahaRCX : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003CButton1_Click_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormYamahaRCX _003C_003E4__this;

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
							_003C_003E4__this.yamahaRCX = new YamahaRCX(_003C_003E4__this.textBox1.Text, int.Parse(_003C_003E4__this.textBox2.Text));
							_003C_003E4__this.yamahaRCX.ConnectTimeOut = 2000;
							_003C_003E4__this.button1.Enabled = false;
							awaiter = _003C_003E4__this.yamahaRCX.ConnectServerAsync().GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CButton1_Click_003Ed__2 stateMachine = this;
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

		private YamahaRCX yamahaRCX;

		private IContainer components = null;

		private UserControlHead userControlHead1;

		private Panel panel1;

		private Button button1;

		private TextBox textBox2;

		private Label label2;

		private TextBox textBox1;

		private Label label1;

		private Panel panel2;

		private Panel panel3;

		private Label label6;

		private Button button2;

		private TextBox textBox6;

		private Button button3;

		private Button button4;

		private Button button5;

		private Button button6;

		private Button button7;

		private Button button8;

		private Button button9;

		public FormYamahaRCX()
		{
			InitializeComponent();
		}

		[AsyncStateMachine(typeof(_003CButton1_Click_003Ed__2))]
		[DebuggerStepThrough]
		private void Button1_Click(object sender, EventArgs e)
		{
			_003CButton1_Click_003Ed__2 stateMachine = new _003CButton1_Click_003Ed__2();
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
		}

		private void button2_Click(object sender, EventArgs e)
		{
			YamahaRCX obj = yamahaRCX;
			if (obj != null)
			{
				obj.ConnectClose();
			}
			button2.Enabled = false;
			panel2.Enabled = false;
			button1.Enabled = true;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = yamahaRCX.Reset();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Reset success");
			}
			else
			{
				MessageBox.Show("Reset Faield:" + operateResult.Message);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = yamahaRCX.Run();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Run success");
			}
			else
			{
				MessageBox.Show("Run Faield:" + operateResult.Message);
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = yamahaRCX.Stop();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Stop success");
			}
			else
			{
				MessageBox.Show("Stop Faield:" + operateResult.Message);
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			OperateResult<int> operateResult = yamahaRCX.ReadMotorStatus();
			if (operateResult.IsSuccess)
			{
				if (operateResult.Content == 0)
				{
					textBox6.Text = "0 -> 马达电源关闭;";
				}
				else if (operateResult.Content == 1)
				{
					textBox6.Text = "1 -> 马达电源开启;";
				}
				else if (operateResult.Content == 2)
				{
					textBox6.Text = "2 -> 马达电源开启＋所有机器人伺服开启";
				}
				else
				{
					textBox6.Text = operateResult.Content.ToString() + " -> 未知的状态";
				}
			}
			else
			{
				MessageBox.Show("Read Faield:" + operateResult.Message);
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			OperateResult<int> operateResult = yamahaRCX.ReadModeStatus();
			if (operateResult.IsSuccess)
			{
				textBox6.Text = operateResult.Content.ToString();
			}
			else
			{
				MessageBox.Show("Read Faield:" + operateResult.Message);
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			OperateResult<float[]> operateResult = yamahaRCX.ReadJoints();
			if (operateResult.IsSuccess)
			{
				textBox6.Text = SoftBasic.ArrayFormat(operateResult);
			}
			else
			{
				MessageBox.Show("Read Faield:" + operateResult.Message);
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			OperateResult<int> operateResult = yamahaRCX.ReadEmergencyStatus();
			if (operateResult.IsSuccess)
			{
				if (operateResult.Content == 0)
				{
					textBox6.Text = "0 -> 正常状态;";
				}
				else if (operateResult.Content == 1)
				{
					textBox6.Text = "1 -> 紧急停止状态;";
				}
				else
				{
					textBox6.Text = operateResult.Content.ToString() + " -> 未知的状态";
				}
			}
			else
			{
				MessageBox.Show("Read Faield:" + operateResult.Message);
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
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1 = new System.Windows.Forms.Panel();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			button9 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			panel3 = new System.Windows.Forms.Panel();
			textBox6 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
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
			userControlHead1.ProtocolInfo = "TCP";
			userControlHead1.Size = new System.Drawing.Size(990, 32);
			userControlHead1.SupportListVisiable = true;
			userControlHead1.TabIndex = 30;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(11, 42);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(967, 56);
			panel1.TabIndex = 31;
			button2.Location = new System.Drawing.Point(474, 11);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(94, 24);
			button2.TabIndex = 18;
			button2.Text = "Close";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(365, 11);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(94, 24);
			button1.TabIndex = 17;
			button1.Text = "Connect";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1_Click);
			textBox2.Location = new System.Drawing.Point(269, 12);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(54, 23);
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
			textBox1.Text = "192.168.1.20";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(17, 15);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(72, 17);
			label1.TabIndex = 9;
			label1.Text = "Ip Address";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(button9);
			panel2.Controls.Add(button8);
			panel2.Controls.Add(button7);
			panel2.Controls.Add(button6);
			panel2.Controls.Add(button5);
			panel2.Controls.Add(button4);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(panel3);
			panel2.Controls.Add(label6);
			panel2.Location = new System.Drawing.Point(11, 104);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(967, 518);
			panel2.TabIndex = 32;
			button9.Location = new System.Drawing.Point(356, 41);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(81, 26);
			button9.TabIndex = 24;
			button9.Text = "Emergency";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			button8.Location = new System.Drawing.Point(269, 41);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(81, 26);
			button8.TabIndex = 23;
			button8.Text = "JOINTS";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			button7.Location = new System.Drawing.Point(180, 41);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(81, 26);
			button7.TabIndex = 22;
			button7.Text = "MODE";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			button6.Location = new System.Drawing.Point(89, 41);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(81, 26);
			button6.TabIndex = 21;
			button6.Text = "MOTOR";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button5.Location = new System.Drawing.Point(269, 9);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(81, 26);
			button5.TabIndex = 20;
			button5.Text = "STOP";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			button4.Location = new System.Drawing.Point(180, 9);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(81, 26);
			button4.TabIndex = 19;
			button4.Text = "RUN";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button3.Location = new System.Drawing.Point(88, 9);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(81, 26);
			button3.TabIndex = 18;
			button3.Text = "RESET";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			panel3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel3.Controls.Add(textBox6);
			panel3.Location = new System.Drawing.Point(88, 99);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(874, 414);
			panel3.TabIndex = 17;
			textBox6.Dock = System.Windows.Forms.DockStyle.Fill;
			textBox6.Location = new System.Drawing.Point(0, 0);
			textBox6.Multiline = true;
			textBox6.Name = "textBox6";
			textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox6.Size = new System.Drawing.Size(872, 412);
			textBox6.TabIndex = 5;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(17, 18);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(51, 17);
			label6.TabIndex = 4;
			label6.Text = "content";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(990, 634);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			base.Controls.Add(userControlHead1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "FormYamahaRCX";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormYamahaRCX";
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
