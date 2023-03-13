using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Instrument.IEC;
using HslCommunication.Instrument.IEC.Helper;
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
	public class FormIEC104 : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003Cbutton1_Click_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormIEC104 _003C_003E4__this;

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
						goto IL_00d2;
					}
					if (int.TryParse(_003C_003E4__this.textBox2.Text, out _003Cport_003E5__1))
					{
						_003C_003E4__this.button1.Enabled = false;
						IEC104 iec = _003C_003E4__this.iec104;
						if (iec != null)
						{
							iec.ConnectClose();
						}
						_003C_003E4__this.iec104 = new IEC104(_003C_003E4__this.textBox3.Text, _003Cport_003E5__1);
						_003C_003E4__this.iec104.OnIEC104MessageReceived += _003C_003E4__this.Iec104_IEC104MessageReceived;
						_003C_003E4__this.iec104.LogNet = _003C_003E4__this.LogNet;
						goto IL_00d2;
					}
					MessageBox.Show(DemoUtils.PortInputWrong);
					goto end_IL_0007;
					IL_00d2:
					try
					{
						TaskAwaiter<OperateResult> awaiter;
						if (num != 0)
						{
							awaiter = _003C_003E4__this.iec104.ConnectServerAsync().GetAwaiter();
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
							MessageBox.Show(StringResources.Language.ConnectedSuccess);
							_003C_003E4__this.button2.Enabled = true;
							_003C_003E4__this.button1.Enabled = false;
							_003C_003E4__this.panel2.Enabled = true;
							_003C_003E4__this.userControlReadWriteOp1.SetReadWriteNet(_003C_003E4__this.iec104, "0", true);
							_003C_003E4__this.userControlReadWriteOp1.Enabled = false;
							_003C_003E4__this.button_read_batch.Enabled = false;
						}
						else
						{
							_003C_003E4__this.button1.Enabled = true;
							MessageBox.Show(StringResources.Language.ConnectedFailed + _003Cconnect_003E5__2.Message + Environment.NewLine + "Error: " + _003Cconnect_003E5__2.ErrorCode.ToString());
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

		private IEC104 iec104 = null;

		private IContainer components = null;

		private Panel panel1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private GroupBox groupBox3;

		private TextBox textBox10;

		private Label label13;

		private Button button_read_batch;

		private TextBox textBox9;

		private Label label12;

		private TextBox textBox6;

		private Label label11;

		private TextBox textBox15;

		private Label label21;

		private UserControlHead userControlHead1;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox3;

		private Label label1;

		private Button button3;

		private TextBox textBox1;

		private Label label2;

		private CheckBox checkBox1;

		private Button button5;

		private TextBox textBox4;

		private Button button_u_test;

		private Button button_u_stop;

		private Button button_u_start;

		public FormIEC104()
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
				label21.Text = "station";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				button3.Text = "Active";
				label11.Text = "Address:";
				label12.Text = "length:";
				button_read_batch.Text = "Bulk Read";
				label13.Text = "Results:";
				groupBox3.Text = "Bulk Read test";
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

		private void Iec104_IEC104MessageReceived(object sender, IEC104MessageEventArgs e)
		{
			if (!checkBox1.Checked)
			{
				Invoke((Action)delegate
				{
					if (e.TypeID != 36 || e.InfoObjectCount != 1)
					{
						textBox10.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff ") + "Source: " + e.ASDU.ToHexString(' ') + Environment.NewLine);
					}
					else
					{
						try
						{
							IecValueObject<float> iecValueObject = IecValueObject<float>.PraseFloat(e.Body, 0);
							textBox10.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff  ") + string.Format("Float, Address[{0}] 品质[{1}] 值[{2}] 时标[{3}]", iecValueObject.Address, iecValueObject.Quality, iecValueObject.Value, iecValueObject.Time) + Environment.NewLine);
						}
						catch
						{
							textBox10.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff  ") + "Float failed, Source: " + e.ASDU.ToHexString(' ') + Environment.NewLine);
						}
					}
				});
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			iec104.ConnectClose();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			DemoUtils.BulkReadRenderResult(iec104, textBox6, textBox9, textBox10);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = iec104.SendFrameIMessage(SoftBasic.HexStringToBytes(textBox1.Text));
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Send Failed：" + operateResult.ToMessageShowString());
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlBaudRate, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlStation, textBox15.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox2.Text = element.Attribute(DemoDeviceList.XmlBaudRate).Value;
			textBox15.Text = element.Attribute(DemoDeviceList.XmlStation).Value;
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			textBox4.Text = IECHelper.GetAbsoluteTimeScale(DateTime.Now, true).ToHexString(' ');
		}

		private void button_u_start_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = iec104.SendFrameUMessage(7);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Send Success!");
			}
			else
			{
				MessageBox.Show("Send failed: " + operateResult.Message);
			}
		}

		private void button_u_stop_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = iec104.SendFrameUMessage(19);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Send Success!");
			}
			else
			{
				MessageBox.Show("Send failed: " + operateResult.Message);
			}
		}

		private void button_u_test_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = iec104.SendFrameUMessage(67);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Send Success!");
			}
			else
			{
				MessageBox.Show("Send failed: " + operateResult.Message);
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
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			textBox15 = new System.Windows.Forms.TextBox();
			label21 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox3 = new System.Windows.Forms.GroupBox();
			button_u_test = new System.Windows.Forms.Button();
			button_u_stop = new System.Windows.Forms.Button();
			button_u_start = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			button3 = new System.Windows.Forms.Button();
			textBox1 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox10 = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			button_read_batch = new System.Windows.Forms.Button();
			textBox9 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			checkBox1 = new System.Windows.Forms.CheckBox();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(textBox15);
			panel1.Controls.Add(label21);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 54);
			panel1.TabIndex = 0;
			textBox2.Location = new System.Drawing.Point(250, 14);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(76, 23);
			textBox2.TabIndex = 11;
			textBox2.Text = "2404";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(196, 17);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 10;
			label3.Text = "端口号：";
			textBox3.Location = new System.Drawing.Point(62, 14);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(128, 23);
			textBox3.TabIndex = 9;
			textBox3.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 17);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 8;
			label1.Text = "Ip地址：";
			textBox15.Location = new System.Drawing.Point(394, 14);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(37, 23);
			textBox15.TabIndex = 7;
			textBox15.Text = "1";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(346, 17);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(44, 17);
			label21.TabIndex = 6;
			label21.Text = "站号：";
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
			panel2.Controls.Add(groupBox3);
			panel2.Location = new System.Drawing.Point(3, 93);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 549);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Location = new System.Drawing.Point(4, 2);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(988, 240);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox3.Controls.Add(button_u_test);
			groupBox3.Controls.Add(button_u_stop);
			groupBox3.Controls.Add(button_u_start);
			groupBox3.Controls.Add(button5);
			groupBox3.Controls.Add(textBox4);
			groupBox3.Controls.Add(button3);
			groupBox3.Controls.Add(textBox1);
			groupBox3.Controls.Add(label2);
			groupBox3.Controls.Add(textBox10);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(button_read_batch);
			groupBox3.Controls.Add(textBox9);
			groupBox3.Controls.Add(label12);
			groupBox3.Controls.Add(textBox6);
			groupBox3.Controls.Add(label11);
			groupBox3.Controls.Add(checkBox1);
			groupBox3.Location = new System.Drawing.Point(4, 243);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(988, 301);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试";
			button_u_test.Location = new System.Drawing.Point(607, 19);
			button_u_test.Name = "button_u_test";
			button_u_test.Size = new System.Drawing.Size(81, 28);
			button_u_test.TabIndex = 21;
			button_u_test.Text = "U-Test";
			button_u_test.UseVisualStyleBackColor = true;
			button_u_test.Click += new System.EventHandler(button_u_test_Click);
			button_u_stop.Location = new System.Drawing.Point(520, 19);
			button_u_stop.Name = "button_u_stop";
			button_u_stop.Size = new System.Drawing.Size(81, 28);
			button_u_stop.TabIndex = 20;
			button_u_stop.Text = "U-Stop";
			button_u_stop.UseVisualStyleBackColor = true;
			button_u_stop.Click += new System.EventHandler(button_u_stop_Click);
			button_u_start.Location = new System.Drawing.Point(433, 19);
			button_u_start.Name = "button_u_start";
			button_u_start.Size = new System.Drawing.Size(81, 28);
			button_u_start.TabIndex = 19;
			button_u_start.Text = "U-Start";
			button_u_start.UseVisualStyleBackColor = true;
			button_u_start.Click += new System.EventHandler(button_u_start_Click);
			button5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button5.Location = new System.Drawing.Point(929, 16);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(53, 28);
			button5.TabIndex = 18;
			button5.Text = "时间";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			textBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			textBox4.Location = new System.Drawing.Point(761, 19);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(156, 23);
			textBox4.TabIndex = 17;
			button3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button3.Location = new System.Drawing.Point(814, 47);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(81, 28);
			button3.TabIndex = 13;
			button3.Text = "I帧报文";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox1.Location = new System.Drawing.Point(63, 50);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(745, 23);
			textBox1.TabIndex = 12;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(9, 53);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 17);
			label2.TabIndex = 11;
			label2.Text = "报文：";
			textBox10.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox10.Location = new System.Drawing.Point(63, 79);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(925, 216);
			textBox10.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 81);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "结果：";
			button_read_batch.Location = new System.Drawing.Point(305, 19);
			button_read_batch.Name = "button_read_batch";
			button_read_batch.Size = new System.Drawing.Size(82, 28);
			button_read_batch.TabIndex = 8;
			button_read_batch.Text = "批量读取";
			button_read_batch.UseVisualStyleBackColor = true;
			button_read_batch.Click += new System.EventHandler(button25_Click);
			textBox9.Location = new System.Drawing.Point(239, 22);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(60, 23);
			textBox9.TabIndex = 7;
			textBox9.Text = "10";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(185, 25);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(44, 17);
			label12.TabIndex = 6;
			label12.Text = "长度：";
			textBox6.Location = new System.Drawing.Point(63, 22);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(102, 23);
			textBox6.TabIndex = 5;
			textBox6.Text = "100";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(9, 25);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 4;
			label11.Text = "地址：";
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(7, 103);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(58, 21);
			checkBox1.TabIndex = 15;
			checkBox1.Text = "STOP";
			checkBox1.UseVisualStyleBackColor = true;
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/8974215.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "IEC104";
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
			base.Name = "FormIEC104";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "IEC104访问Demo";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			ResumeLayout(false);
		}
	}
}
