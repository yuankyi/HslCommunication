using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using HslCommunication.Profinet.YASKAWA;
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
	public class FormYASKAWAMemobusTcpNet : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003Cbutton_read_random_Click_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormYASKAWAMemobusTcpNet _003C_003E4__this;

			private ushort[] _003Caddress_003E5__1;

			private OperateResult<byte[]> _003Cread_003E5__2;

			private OperateResult<byte[]> _003C_003Es__3;

			private ushort[] _003Cvalue_003E5__4;

			private TaskAwaiter<OperateResult<byte[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<byte[]>> awaiter;
					if (num != 0)
					{
						_003Caddress_003E5__1 = _003C_003E4__this.textBox_read_random.Text.ToStringArray<ushort>();
						_003C_003E4__this.button_read_random.Enabled = false;
						awaiter = _003C_003E4__this.memobus.ReadRandomAsync(_003Caddress_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_read_random_Click_003Ed__12 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<byte[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003Cread_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cread_003E5__2.IsSuccess)
					{
						_003Cvalue_003E5__4 = _003C_003E4__this.memobus.ByteTransform.TransUInt16(_003Cread_003E5__2.Content, 0, _003Caddress_003E5__1.Length);
						_003C_003E4__this.textBox_random_result.Text = _003Cvalue_003E5__4.ToArrayString();
						_003Cvalue_003E5__4 = null;
					}
					else
					{
						MessageBox.Show("Read failed: " + _003Cread_003E5__2.Message);
					}
					_003C_003E4__this.button_read_random.Enabled = true;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Caddress_003E5__1 = null;
					_003Cread_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Caddress_003E5__1 = null;
				_003Cread_003E5__2 = null;
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

		private MemobusTcpNet memobus = null;

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

		private ComboBox comboBox1;

		private TextBox textBox_cpu_from;

		private Label label1;

		private TextBox textBox19;

		private Label label28;

		private TextBox textBox20;

		private Label label29;

		private UserControlHead userControlHead1;

		private GroupBox groupBox5;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private TextBox textBox_cpu_to;

		private Label label2;

		private TextBox textBox_random_result;

		private Label label4;

		private Button button_read_random;

		private TextBox textBox_read_random;

		private Label label3;

		private Label label5;

		public FormYASKAWAMemobusTcpNet()
		{
			InitializeComponent();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			comboBox1.DataSource = SoftBasic.GetEnumValues<DataFormat>();
			comboBox1.SelectedItem = DataFormat.CDAB;
			panel2.Enabled = false;
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "YASKAWA Read PLC Demo";
				label1.Text = "Station:";
				button1.Text = "Open";
				button2.Text = "Close";
				label29.Text = "Ip:";
				label28.Text = "Port:";
				label11.Text = "Address:";
				label12.Text = "length:";
				button25.Text = "Bulk Read";
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
			byte result2;
			byte result3;
			if (!int.TryParse(textBox19.Text, out result))
			{
				MessageBox.Show(DemoUtils.PortInputWrong);
			}
			else if (!byte.TryParse(textBox_cpu_from.Text, out result2))
			{
				MessageBox.Show("PLC cpuFrom input wrong！");
			}
			else if (!byte.TryParse(textBox_cpu_to.Text, out result3))
			{
				MessageBox.Show("PLC cpuTo input wrong！");
			}
			else
			{
				MemobusTcpNet memobusTcpNet = memobus;
				if (memobusTcpNet != null)
				{
					memobusTcpNet.ConnectClose();
				}
				memobus = new MemobusTcpNet();
				memobus.IpAddress = textBox20.Text;
				memobus.Port = result;
				memobus.CpuFrom = result2;
				memobus.CpuTo = result3;
				memobus.LogNet = base.LogNet;
				try
				{
					memobus.ByteTransform.DataFormat = (DataFormat)comboBox1.SelectedItem;
					OperateResult operateResult = memobus.ConnectServer();
					if (operateResult.IsSuccess)
					{
						MessageBox.Show(StringResources.Language.ConnectedSuccess);
						button2.Enabled = true;
						button1.Enabled = false;
						panel2.Enabled = true;
						userControlReadWriteOp1.SetReadWriteNet(memobus, "100", true);
					}
					else
					{
						MessageBox.Show(StringResources.Language.ConnectedFailed + operateResult.Message);
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
			memobus.ConnectClose();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			DemoUtils.BulkReadRenderResult(memobus, textBox6, textBox9, textBox10);
		}

		private void button26_Click(object sender, EventArgs e)
		{
			OperateResult<byte[]> operateResult = memobus.ReadFromCoreServer(SoftBasic.HexStringToBytes(textBox13.Text));
			if (operateResult.IsSuccess)
			{
				textBox11.Text = "Result：" + SoftBasic.ByteToHexString(operateResult.Content);
			}
			else
			{
				MessageBox.Show("Read Failed：" + operateResult.ToMessageShowString());
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox20.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox19.Text);
			element.SetAttributeValue(DemoDeviceList.XmlDataFormat, comboBox1.SelectedIndex);
			element.SetAttributeValue("cpu_from", textBox_cpu_from.Text);
			element.SetAttributeValue("cpu_to", textBox_cpu_to.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox20.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox19.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			comboBox1.SelectedIndex = int.Parse(element.Attribute(DemoDeviceList.XmlDataFormat).Value);
			textBox_cpu_from.Text = element.Attribute("cpu_from").Value;
			textBox_cpu_to.Text = element.Attribute("cpu_to").Value;
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
		}

		[AsyncStateMachine(typeof(_003Cbutton_read_random_Click_003Ed__12))]
		[DebuggerStepThrough]
		private void button_read_random_Click(object sender, EventArgs e)
		{
			_003Cbutton_read_random_Click_003Ed__12 stateMachine = new _003Cbutton_read_random_Click_003Ed__12();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void label4_Click(object sender, EventArgs e)
		{
		}

		private void textBox_random_result_TextChanged(object sender, EventArgs e)
		{
		}

		private void textBox_read_random_TextChanged(object sender, EventArgs e)
		{
		}

		private void label3_Click(object sender, EventArgs e)
		{
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
			textBox_cpu_to = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox_cpu_from = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			textBox19 = new System.Windows.Forms.TextBox();
			label28 = new System.Windows.Forms.Label();
			textBox20 = new System.Windows.Forms.TextBox();
			label29 = new System.Windows.Forms.Label();
			comboBox1 = new System.Windows.Forms.ComboBox();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox5 = new System.Windows.Forms.GroupBox();
			textBox_random_result = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			button_read_random = new System.Windows.Forms.Button();
			textBox_read_random = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
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
			label5 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox5.SuspendLayout();
			groupBox4.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox_cpu_to);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(textBox_cpu_from);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(textBox19);
			panel1.Controls.Add(label28);
			panel1.Controls.Add(textBox20);
			panel1.Controls.Add(label29);
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 50);
			panel1.TabIndex = 0;
			textBox_cpu_to.Location = new System.Drawing.Point(636, 11);
			textBox_cpu_to.Name = "textBox_cpu_to";
			textBox_cpu_to.Size = new System.Drawing.Size(31, 23);
			textBox_cpu_to.TabIndex = 42;
			textBox_cpu_to.Text = "2";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(561, 14);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(62, 17);
			label2.TabIndex = 41;
			label2.Text = "Cpu To：";
			textBox_cpu_from.Location = new System.Drawing.Point(510, 11);
			textBox_cpu_from.Name = "textBox_cpu_from";
			textBox_cpu_from.Size = new System.Drawing.Size(31, 23);
			textBox_cpu_from.TabIndex = 40;
			textBox_cpu_from.Text = "1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(431, 14);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(77, 17);
			label1.TabIndex = 39;
			label1.Text = "Cpu From：";
			textBox19.Location = new System.Drawing.Point(233, 10);
			textBox19.Name = "textBox19";
			textBox19.Size = new System.Drawing.Size(53, 23);
			textBox19.TabIndex = 32;
			textBox19.Text = "9999";
			label28.AutoSize = true;
			label28.Location = new System.Drawing.Point(185, 13);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(44, 17);
			label28.TabIndex = 31;
			label28.Text = "端口：";
			textBox20.Location = new System.Drawing.Point(64, 10);
			textBox20.Name = "textBox20";
			textBox20.Size = new System.Drawing.Size(109, 23);
			textBox20.TabIndex = 30;
			textBox20.Text = "192.168.0.10";
			label29.AutoSize = true;
			label29.Location = new System.Drawing.Point(10, 13);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(56, 17);
			label29.TabIndex = 29;
			label29.Text = "Ip地址：";
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(307, 10);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(95, 25);
			comboBox1.TabIndex = 14;
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(808, 7);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(90, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(701, 7);
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
			panel2.Location = new System.Drawing.Point(3, 89);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 553);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Location = new System.Drawing.Point(3, 3);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(989, 240);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox5.Controls.Add(label5);
			groupBox5.Controls.Add(textBox_random_result);
			groupBox5.Controls.Add(label4);
			groupBox5.Controls.Add(button_read_random);
			groupBox5.Controls.Add(textBox_read_random);
			groupBox5.Controls.Add(label3);
			groupBox5.Location = new System.Drawing.Point(573, 243);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(419, 305);
			groupBox5.TabIndex = 4;
			groupBox5.TabStop = false;
			groupBox5.Text = "特殊功能测试";
			textBox_random_result.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_random_result.Location = new System.Drawing.Point(77, 96);
			textBox_random_result.Multiline = true;
			textBox_random_result.Name = "textBox_random_result";
			textBox_random_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_random_result.Size = new System.Drawing.Size(336, 203);
			textBox_random_result.TabIndex = 12;
			textBox_random_result.TextChanged += new System.EventHandler(textBox_random_result_TextChanged);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(9, 98);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(44, 17);
			label4.TabIndex = 11;
			label4.Text = "结果：";
			label4.Click += new System.EventHandler(label4_Click);
			button_read_random.Location = new System.Drawing.Point(77, 60);
			button_read_random.Name = "button_read_random";
			button_read_random.Size = new System.Drawing.Size(111, 28);
			button_read_random.TabIndex = 9;
			button_read_random.Text = "随机字读取";
			button_read_random.UseVisualStyleBackColor = true;
			button_read_random.Click += new System.EventHandler(button_read_random_Click);
			textBox_read_random.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_read_random.Location = new System.Drawing.Point(77, 27);
			textBox_read_random.Name = "textBox_read_random";
			textBox_read_random.Size = new System.Drawing.Size(336, 23);
			textBox_read_random.TabIndex = 7;
			textBox_read_random.Text = "1;10;100;300";
			textBox_read_random.TextChanged += new System.EventHandler(textBox_read_random_TextChanged);
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(9, 30);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(68, 17);
			label3.TabIndex = 6;
			label3.Text = "地址列表：";
			label3.Click += new System.EventHandler(label3_Click);
			groupBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox4.Controls.Add(textBox11);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(button26);
			groupBox4.Controls.Add(textBox13);
			groupBox4.Controls.Add(label16);
			groupBox4.Location = new System.Drawing.Point(3, 403);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(564, 145);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "报文读取测试，此处需要填入完整的16进制报文字符串";
			textBox11.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox11.Location = new System.Drawing.Point(63, 60);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox11.Size = new System.Drawing.Size(495, 79);
			textBox11.TabIndex = 10;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(9, 62);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 9;
			label14.Text = "结果：";
			button26.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button26.Location = new System.Drawing.Point(456, 30);
			button26.Name = "button26";
			button26.Size = new System.Drawing.Size(82, 28);
			button26.TabIndex = 8;
			button26.Text = "报文读取";
			button26.UseVisualStyleBackColor = true;
			button26.Click += new System.EventHandler(button26_Click);
			textBox13.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox13.Location = new System.Drawing.Point(63, 27);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(407, 23);
			textBox13.TabIndex = 5;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(9, 30);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(44, 17);
			label16.TabIndex = 4;
			label16.Text = "报文：";
			groupBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox3.Controls.Add(textBox10);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(button25);
			groupBox3.Controls.Add(textBox9);
			groupBox3.Controls.Add(label12);
			groupBox3.Controls.Add(textBox6);
			groupBox3.Controls.Add(label11);
			groupBox3.Location = new System.Drawing.Point(3, 243);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(564, 154);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试";
			textBox10.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox10.Location = new System.Drawing.Point(63, 60);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(495, 88);
			textBox10.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 62);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "结果：";
			button25.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button25.Location = new System.Drawing.Point(476, 24);
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
			textBox9.Text = "10";
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
			textBox6.Text = "100";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(9, 30);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 4;
			label11.Text = "地址：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7469679.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Memobus Tcp";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.SupportListVisiable = true;
			userControlHead1.TabIndex = 2;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			label5.AutoSize = true;
			label5.ForeColor = System.Drawing.Color.Red;
			label5.Location = new System.Drawing.Point(194, 66);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(178, 17);
			label5.TabIndex = 19;
			label5.Text = "针对09功能码的扩展保持寄存器";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormYASKAWAMemobusTcpNet";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "安川PLC访问Demo";
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
