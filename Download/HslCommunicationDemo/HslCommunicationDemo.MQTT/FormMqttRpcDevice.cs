using HslCommunication;
using HslCommunication.MQTT;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.MQTT
{
	public class FormMqttRpcDevice : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003Cbutton1_Click_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttRpcDevice _003C_003E4__this;

			private MqttConnectionOptions _003Coptions_003E5__1;

			private OperateResult _003Cconnect_003E5__2;

			private OperateResult _003C_003Es__3;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					if (num != 0)
					{
						_003Coptions_003E5__1 = new MqttConnectionOptions
						{
							IpAddress = _003C_003E4__this.textBox1.Text,
							Port = int.Parse(_003C_003E4__this.textBox2.Text),
							ClientId = _003C_003E4__this.textBox3.Text,
							UseRSAProvider = _003C_003E4__this.checkBox_rsa.Checked
						};
						if (!string.IsNullOrEmpty(_003C_003E4__this.textBox9.Text) || !string.IsNullOrEmpty(_003C_003E4__this.textBox10.Text))
						{
							_003Coptions_003E5__1.Credentials = new MqttCredential(_003C_003E4__this.textBox9.Text, _003C_003E4__this.textBox10.Text);
						}
						_003C_003E4__this.button1.Enabled = false;
						_003C_003E4__this.rpc = new MqttRpcDevice(_003Coptions_003E5__1, _003C_003E4__this.textBox_deviceTopic.Text);
						awaiter = _003C_003E4__this.rpc.ConnectServerAsync().GetAwaiter();
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
					_003C_003Es__3 = awaiter.GetResult();
					_003Cconnect_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cconnect_003E5__2.IsSuccess)
					{
						_003C_003E4__this.panel2.Enabled = true;
						_003C_003E4__this.button1.Enabled = false;
						_003C_003E4__this.button2.Enabled = true;
						_003C_003E4__this.panel2.Enabled = true;
						_003C_003E4__this.userControlReadWriteOp1.SetReadWriteNet(_003C_003E4__this.rpc, "100", true);
						MessageBox.Show(StringResources.Language.ConnectServerSuccess);
					}
					else
					{
						_003C_003E4__this.button1.Enabled = true;
						MessageBox.Show(_003Cconnect_003E5__2.Message);
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Coptions_003E5__1 = null;
					_003Cconnect_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Coptions_003E5__1 = null;
				_003Cconnect_003E5__2 = null;
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

		private MqttRpcDevice rpc;

		private IContainer components = null;

		private Panel panel1;

		private CheckBox checkBox_rsa;

		private TextBox textBox3;

		private Label label6;

		private TextBox textBox10;

		private Label label4;

		private TextBox textBox9;

		private Label label2;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private Label label1;

		private Panel panel2;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private GroupBox groupBox3;

		private TextBox textBox5;

		private Label label13;

		private Button button25;

		private TextBox textBox6;

		private Label label12;

		private TextBox textBox7;

		private Label label11;

		private UserControlHead userControlHead1;

		private TextBox textBox_deviceTopic;

		private Label label5;

		public FormMqttRpcDevice()
		{
			InitializeComponent();
		}

		private void FormMqttRpcDevice_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			button2.Enabled = false;
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
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;
			rpc.ConnectClose();
		}

		private void button25_Click(object sender, EventArgs e)
		{
			DemoUtils.BulkReadRenderResult(rpc, textBox7, textBox6, textBox5);
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlCompanyID, textBox3.Text);
			element.SetAttributeValue(DemoDeviceList.XmlUserName, textBox9.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPassword, textBox10.Text);
			element.SetAttributeValue("DeviceTopic", textBox_deviceTopic.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox3.Text = element.Attribute(DemoDeviceList.XmlCompanyID).Value;
			textBox9.Text = element.Attribute(DemoDeviceList.XmlUserName).Value;
			textBox10.Text = element.Attribute(DemoDeviceList.XmlPassword).Value;
			textBox_deviceTopic.Text = element.Attribute("DeviceTopic").Value;
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
			textBox_deviceTopic = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			checkBox_rsa = new System.Windows.Forms.CheckBox();
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			textBox10 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox9 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox3 = new System.Windows.Forms.GroupBox();
			textBox5 = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			button25 = new System.Windows.Forms.Button();
			textBox6 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			textBox7 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox_deviceTopic);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(checkBox_rsa);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(textBox10);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(textBox9);
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
			panel1.Size = new System.Drawing.Size(1001, 61);
			panel1.TabIndex = 8;
			textBox_deviceTopic.Location = new System.Drawing.Point(575, 32);
			textBox_deviceTopic.Name = "textBox_deviceTopic";
			textBox_deviceTopic.Size = new System.Drawing.Size(134, 23);
			textBox_deviceTopic.TabIndex = 20;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(497, 35);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(68, 17);
			label5.TabIndex = 19;
			label5.Text = "设备主题：";
			checkBox_rsa.AutoSize = true;
			checkBox_rsa.Location = new System.Drawing.Point(705, 5);
			checkBox_rsa.Name = "checkBox_rsa";
			checkBox_rsa.Size = new System.Drawing.Size(287, 21);
			checkBox_rsa.TabIndex = 18;
			checkBox_rsa.Text = "RSA加密 (支持v10.2.0版本及以上的MqttServer)";
			checkBox_rsa.UseVisualStyleBackColor = true;
			textBox3.Location = new System.Drawing.Point(86, 32);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(405, 23);
			textBox3.TabIndex = 17;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(8, 35);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(80, 17);
			label6.TabIndex = 16;
			label6.Text = "客户端标识：";
			textBox10.Location = new System.Drawing.Point(584, 3);
			textBox10.Name = "textBox10";
			textBox10.Size = new System.Drawing.Size(113, 23);
			textBox10.TabIndex = 13;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(520, 6);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(44, 17);
			label4.TabIndex = 12;
			label4.Text = "密码：";
			textBox9.Location = new System.Drawing.Point(417, 3);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(91, 23);
			textBox9.TabIndex = 11;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(341, 6);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(56, 17);
			label2.TabIndex = 10;
			label2.Text = "用户名：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(823, 29);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(719, 29);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(243, 3);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(79, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "1883";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(189, 6);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 3);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(115, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 6);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteOp1);
			panel2.Controls.Add(groupBox3);
			panel2.Location = new System.Drawing.Point(3, 99);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(1001, 513);
			panel2.TabIndex = 9;
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlReadWriteOp1.Location = new System.Drawing.Point(3, 1);
			userControlReadWriteOp1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(993, 240);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox3.Controls.Add(textBox5);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(button25);
			groupBox3.Controls.Add(textBox6);
			groupBox3.Controls.Add(label12);
			groupBox3.Controls.Add(textBox7);
			groupBox3.Controls.Add(label11);
			groupBox3.Location = new System.Drawing.Point(3, 243);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(993, 265);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试";
			textBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox5.Location = new System.Drawing.Point(63, 60);
			textBox5.Multiline = true;
			textBox5.Name = "textBox5";
			textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox5.Size = new System.Drawing.Size(924, 199);
			textBox5.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 62);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "结果：";
			button25.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button25.Location = new System.Drawing.Point(355, 24);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(82, 28);
			button25.TabIndex = 8;
			button25.Text = "批量读取";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			textBox6.Location = new System.Drawing.Point(279, 27);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(59, 23);
			textBox6.TabIndex = 7;
			textBox6.Text = "10";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(237, 30);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(44, 17);
			label12.TabIndex = 6;
			label12.Text = "长度：";
			textBox7.Location = new System.Drawing.Point(63, 27);
			textBox7.Name = "textBox7";
			textBox7.Size = new System.Drawing.Size(168, 23);
			textBox7.TabIndex = 5;
			textBox7.Text = "D100";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(9, 30);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 4;
			label11.Text = "地址：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.hsltechnology.cn/";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "MRPC";
			userControlHead1.Size = new System.Drawing.Size(1008, 32);
			userControlHead1.SupportListVisiable = true;
			userControlHead1.TabIndex = 10;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1008, 615);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "FormMqttRpcDevice";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "MqttRpcDevice [基于MRPC的PLC设备访问]";
			base.Load += new System.EventHandler(FormMqttRpcDevice_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			ResumeLayout(false);
		}
	}
}
