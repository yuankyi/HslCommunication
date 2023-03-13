using HslCommunication;
using HslCommunication.Profinet.Keyence;
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
	public class FormKeyenceSR2000 : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003Cbutton1_Click_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormKeyenceSR2000 _003C_003E4__this;

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
						goto IL_009e;
					}
					if (int.TryParse(_003C_003E4__this.textBox2.Text, out _003Cport_003E5__1))
					{
						KeyenceSR2000SeriesTcp keyence = _003C_003E4__this.keyence;
						if (keyence != null)
						{
							keyence.ConnectClose();
						}
						_003C_003E4__this.keyence = new KeyenceSR2000SeriesTcp(_003C_003E4__this.textBox1.Text, _003Cport_003E5__1);
						_003C_003E4__this.keyence.LogNet = _003C_003E4__this.LogNet;
						goto IL_009e;
					}
					MessageBox.Show("端口输入格式不正确！");
					goto end_IL_0007;
					IL_009e:
					try
					{
						TaskAwaiter<OperateResult> awaiter;
						if (num != 0)
						{
							awaiter = _003C_003E4__this.keyence.ConnectServerAsync().GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003Cbutton1_Click_003Ed__5 stateMachine = this;
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
		private sealed class _003Cbutton2_Click_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormKeyenceSR2000 _003C_003E4__this;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.keyence.ConnectCloseAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton2_Click_003Ed__6 stateMachine = this;
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
					_003C_003E4__this.button1.Enabled = true;
					_003C_003E4__this.panel2.Enabled = false;
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

		private KeyenceSR2000SeriesTcp keyence = null;

		private IContainer components = null;

		private Panel panel1;

		private Label label1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private GroupBox groupBox1;

		private Button button_read_string;

		private TextBox textBox4;

		private Label label7;

		private TextBox textBox3;

		private Label label6;

		private Label label22;

		private Label label21;

		private UserControlHead userControlHead1;

		private Button button3;

		private Button button4;

		private Button button5;

		private Button button6;

		private Button button9;

		private Button button8;

		private Button button7;

		private Button button12;

		private Button button11;

		private Button button10;

		public FormKeyenceSR2000()
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
				Text = "Keyence SR2000 Code Reader Demo";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
				label6.Text = "address:";
				label7.Text = "result:";
				button_read_string.Text = "r-string";
				groupBox1.Text = "Single Data Read test";
				label22.Text = "";
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		[AsyncStateMachine(typeof(_003Cbutton1_Click_003Ed__5))]
		[DebuggerStepThrough]
		private void button1_Click(object sender, EventArgs e)
		{
			_003Cbutton1_Click_003Ed__5 stateMachine = new _003Cbutton1_Click_003Ed__5();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton2_Click_003Ed__6))]
		[DebuggerStepThrough]
		private void button2_Click(object sender, EventArgs e)
		{
			_003Cbutton2_Click_003Ed__6 stateMachine = new _003Cbutton2_Click_003Ed__6();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button_read_string_Click(object sender, EventArgs e)
		{
			DemoUtils.ReadResultRender(keyence.ReadCustomer(textBox3.Text), textBox3.Text, textBox4);
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
			DemoUtils.ReadResultRender(keyence.ReadBarcode(), "ReadBarcode", textBox4);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(keyence.Reset());
		}

		private void button5_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(keyence.OpenIndicator());
		}

		private void button6_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(keyence.CloseIndicator());
		}

		private void button7_Click(object sender, EventArgs e)
		{
			DemoUtils.ReadResultRender(keyence.ReadVersion(), "ReadVersion", textBox4);
		}

		private void button8_Click(object sender, EventArgs e)
		{
			DemoUtils.ReadResultRender(keyence.ReadCommandState(), "ReadCommandState", textBox4);
		}

		private void button9_Click(object sender, EventArgs e)
		{
			DemoUtils.ReadResultRender(keyence.ReadErrorState(), "ReadErrorState", textBox4);
		}

		private void button10_Click(object sender, EventArgs e)
		{
			DemoUtils.ReadResultRender(keyence.ReadRecord(), "ReadRecord", textBox4);
		}

		private void button11_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(keyence.Lock());
		}

		private void button12_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(keyence.UnLock());
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
			groupBox1 = new System.Windows.Forms.GroupBox();
			button12 = new System.Windows.Forms.Button();
			button11 = new System.Windows.Forms.Button();
			button10 = new System.Windows.Forms.Button();
			button9 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			button_read_string = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
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
			panel1.Size = new System.Drawing.Size(997, 46);
			panel1.TabIndex = 0;
			label22.Location = new System.Drawing.Point(776, 1);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(197, 45);
			label22.TabIndex = 7;
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(702, 1);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(68, 17);
			label21.TabIndex = 6;
			label21.Text = "地址示例：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(584, 5);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(477, 5);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(305, 8);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(141, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "7000";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(251, 11);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 8);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(141, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "192.168.0.100";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 11);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(groupBox1);
			panel2.Location = new System.Drawing.Point(3, 84);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 561);
			panel2.TabIndex = 1;
			groupBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox1.Controls.Add(button12);
			groupBox1.Controls.Add(button11);
			groupBox1.Controls.Add(button10);
			groupBox1.Controls.Add(button9);
			groupBox1.Controls.Add(button8);
			groupBox1.Controls.Add(button7);
			groupBox1.Controls.Add(button6);
			groupBox1.Controls.Add(button5);
			groupBox1.Controls.Add(button4);
			groupBox1.Controls.Add(button3);
			groupBox1.Controls.Add(button_read_string);
			groupBox1.Controls.Add(textBox4);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(textBox3);
			groupBox1.Controls.Add(label6);
			groupBox1.Location = new System.Drawing.Point(3, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(989, 553);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "单数据读取测试";
			button12.Location = new System.Drawing.Point(867, 22);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(89, 28);
			button12.TabIndex = 26;
			button12.Text = "解锁";
			button12.UseVisualStyleBackColor = true;
			button12.Click += new System.EventHandler(button12_Click);
			button11.Location = new System.Drawing.Point(772, 22);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(89, 28);
			button11.TabIndex = 25;
			button11.Text = "锁定";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			button10.Location = new System.Drawing.Point(677, 22);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(89, 28);
			button10.TabIndex = 24;
			button10.Text = "扫码记录";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(button10_Click);
			button9.Location = new System.Drawing.Point(582, 22);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(89, 28);
			button9.TabIndex = 23;
			button9.Text = "错误状态";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			button8.Location = new System.Drawing.Point(487, 22);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(89, 28);
			button8.TabIndex = 22;
			button8.Text = "命令状态";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			button7.Location = new System.Drawing.Point(392, 22);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(89, 28);
			button7.TabIndex = 21;
			button7.Text = "版本";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			button6.Location = new System.Drawing.Point(297, 22);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(89, 28);
			button6.TabIndex = 20;
			button6.Text = "关闭指示灯";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button5.Location = new System.Drawing.Point(202, 22);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(89, 28);
			button5.TabIndex = 19;
			button5.Text = "打开指示灯";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			button4.Location = new System.Drawing.Point(107, 22);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(89, 28);
			button4.TabIndex = 18;
			button4.Text = "复位";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button3.Location = new System.Drawing.Point(12, 22);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(89, 28);
			button3.TabIndex = 17;
			button3.Text = "读条码";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button_read_string.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_read_string.Location = new System.Drawing.Point(867, 96);
			button_read_string.Name = "button_read_string";
			button_read_string.Size = new System.Drawing.Size(116, 28);
			button_read_string.TabIndex = 16;
			button_read_string.Text = "自定义命令";
			button_read_string.UseVisualStyleBackColor = true;
			button_read_string.Click += new System.EventHandler(button_read_string_Click);
			textBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox4.Location = new System.Drawing.Point(63, 128);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox4.Size = new System.Drawing.Size(920, 418);
			textBox4.TabIndex = 5;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(9, 130);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(44, 17);
			label7.TabIndex = 4;
			label7.Text = "结果：";
			textBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox3.Location = new System.Drawing.Point(63, 99);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(798, 23);
			textBox3.TabIndex = 3;
			textBox3.Text = "KEYENCE";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(9, 102);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(44, 17);
			label6.TabIndex = 2;
			label6.Text = "命令：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "SR 2000";
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
			base.Name = "FormKeyenceSR2000";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "基恩士SR2000扫码Demo";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
