using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using HslCommunication.Profinet.Beckhoff;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormBeckhoffAdsNet : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003Cbutton3_Click_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormBeckhoffAdsNet _003C_003E4__this;

			private OperateResult<AdsDeviceInfo> _003Cread_003E5__1;

			private OperateResult<AdsDeviceInfo> _003C_003Es__2;

			private TaskAwaiter<OperateResult<AdsDeviceInfo>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<AdsDeviceInfo>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.beckhoffAdsNet.ReadAdsDeviceInfoAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton3_Click_003Ed__13 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<AdsDeviceInfo>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = string.Format("Major:{0}{1}", _003Cread_003E5__1.Content.Major, Environment.NewLine) + string.Format("Minor:{0}{1}", _003Cread_003E5__1.Content.Minor, Environment.NewLine) + string.Format("Build:{0}{1}", _003Cread_003E5__1.Content.Build, Environment.NewLine) + "Name:" + _003Cread_003E5__1.Content.DeviceName;
					}
					else
					{
						MessageBox.Show("Read Faild:" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton4_Click_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormBeckhoffAdsNet _003C_003E4__this;

			private OperateResult<ushort, ushort> _003Cread_003E5__1;

			private OperateResult<ushort, ushort> _003C_003Es__2;

			private TaskAwaiter<OperateResult<ushort, ushort>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<ushort, ushort>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.beckhoffAdsNet.ReadAdsStateAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton4_Click_003Ed__14 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<ushort, ushort>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cread_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cread_003E5__1.IsSuccess)
					{
						_003C_003E4__this.textBox3.Text = string.Format("Ads State:{0}{1}", _003Cread_003E5__1.Content1, Environment.NewLine) + string.Format("Device State:{0}{1}", _003Cread_003E5__1.Content2, Environment.NewLine);
					}
					else
					{
						MessageBox.Show("Read Faild:" + _003Cread_003E5__1.Message);
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
		private sealed class _003Cbutton5_Click_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormBeckhoffAdsNet _003C_003E4__this;

			private uint _003Chandle_003E5__1;

			private OperateResult _003Crelease_003E5__2;

			private OperateResult _003C_003Es__3;

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
						goto IL_00ad;
					}
					if (uint.TryParse(_003C_003E4__this.textBox4.Text, out _003Chandle_003E5__1))
					{
						awaiter = _003C_003E4__this.beckhoffAdsNet.ReleaseSystemHandleAsync(_003Chandle_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton5_Click_003Ed__15 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_00ad;
					}
					MessageBox.Show("Handle input not corrent");
					goto end_IL_0007;
					IL_00ad:
					_003C_003Es__3 = awaiter.GetResult();
					_003Crelease_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Crelease_003E5__2.IsSuccess)
					{
						MessageBox.Show("Release Success!");
					}
					else
					{
						MessageBox.Show("Release Failed:" + _003Crelease_003E5__2.Message);
					}
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Crelease_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Crelease_003E5__2 = null;
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

		private BeckhoffAdsNet beckhoffAdsNet = null;

		private IContainer components = null;

		private Panel panel1;

		private Label label1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

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

		private Label label22;

		private Label label21;

		private UserControlHead userControlHead1;

		private Label label4;

		private Label label2;

		private TextBox textBox14;

		private Label label5;

		private Label label8;

		private TextBox textBox15;

		private Label label15;

		private CheckBox checkBox_tag;

		private Label label17;

		private GroupBox groupBox5;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private TextBox textBox3;

		private Button button3;

		private Button button4;

		private Button button5;

		private TextBox textBox4;

		private TextBox textBox_ams_port;

		private CheckBox checkBox_auto;

		private Label label6;

		private Label label7;

		private Label label9;

		public FormBeckhoffAdsNet()
		{
			InitializeComponent();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			Language(Program.Language);
			checkBox_auto.CheckedChanged += CheckBox_auto_CheckedChanged;
			CheckBox_auto_CheckedChanged(checkBox_auto, e);
		}

		private void CheckBox_auto_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_auto.Checked)
			{
				textBox14.Enabled = false;
				textBox15.Enabled = false;
				textBox_ams_port.Enabled = true;
			}
			else
			{
				textBox14.Enabled = true;
				textBox15.Enabled = true;
				textBox_ams_port.Enabled = false;
			}
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "Beckhoff AdsNet Read PLC Demo";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
				label8.Text = "case: 192.168.1.100.1.1:801 or 192.168.1.100.1.1";
				checkBox_tag.Text = "Tag Cache";
				label17.Text = "TwinCAT2, port number 801; TwinCAT3, port number 851";
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
				checkBox_auto.Text = "Auto Ams NetID";
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show(DemoUtils.PortInputWrong);
			}
			else
			{
				BeckhoffAdsNet obj = beckhoffAdsNet;
				if (obj != null)
				{
					obj.ConnectClose();
				}
				beckhoffAdsNet = new BeckhoffAdsNet(textBox1.Text, result);
				beckhoffAdsNet.LogNet = base.LogNet;
				try
				{
					if (checkBox_auto.Checked)
					{
						beckhoffAdsNet.UseAutoAmsNetID = true;
						if (!string.IsNullOrEmpty(textBox_ams_port.Text))
						{
							beckhoffAdsNet.AmsPort = ushort.Parse(textBox_ams_port.Text);
						}
					}
					else
					{
						beckhoffAdsNet.SetTargetAMSNetId(textBox14.Text);
						beckhoffAdsNet.SetSenderAMSNetId(textBox15.Text);
					}
					beckhoffAdsNet.UseTagCache = checkBox_tag.Checked;
					OperateResult operateResult = beckhoffAdsNet.ConnectServer();
					if (operateResult.IsSuccess)
					{
						MessageBox.Show(StringResources.Language.ConnectedSuccess);
						button2.Enabled = true;
						button1.Enabled = false;
						panel2.Enabled = true;
						userControlReadWriteOp1.SetReadWriteNet(beckhoffAdsNet, "M100", true);
						if (checkBox_auto.Checked)
						{
							textBox14.Text = beckhoffAdsNet.GetTargetAMSNetId();
							textBox15.Text = beckhoffAdsNet.GetSenderAMSNetId();
						}
						else
						{
							if (string.IsNullOrEmpty(textBox14.Text))
							{
								textBox14.Text = beckhoffAdsNet.GetTargetAMSNetId();
							}
							if (string.IsNullOrEmpty(textBox15.Text))
							{
								textBox15.Text = beckhoffAdsNet.GetSenderAMSNetId();
							}
						}
					}
					else
					{
						MessageBox.Show(StringResources.Language.ConnectedFailed + Environment.NewLine + operateResult.ToMessageShowString());
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
			beckhoffAdsNet.ConnectClose();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			if (!textBox6.Text.Contains(";") && !textBox6.Text.Contains(","))
			{
				DemoUtils.BulkReadRenderResult(beckhoffAdsNet, textBox6, textBox9, textBox10);
			}
			else
			{
				string[] address = textBox6.Text.Split(new char[2]
				{
					',',
					';'
				}, StringSplitOptions.RemoveEmptyEntries);
				ushort[] length = (from m in textBox9.Text.Split(new char[2]
				{
					',',
					';'
				}, StringSplitOptions.RemoveEmptyEntries)
				select ushort.Parse(m)).ToArray();
				OperateResult<byte[]> operateResult = beckhoffAdsNet.Read(address, length);
				if (operateResult.IsSuccess)
				{
					textBox10.Text = operateResult.Content.ToHexString(' ');
					label9.Text = "Length:" + Environment.NewLine + operateResult.Content.Length.ToString();
				}
				else
				{
					MessageBox.Show("Read Failed: " + operateResult.ToMessageShowString());
				}
			}
		}

		private void button26_Click(object sender, EventArgs e)
		{
			OperateResult<byte[]> operateResult = beckhoffAdsNet.ReadFromCoreServer(SoftBasic.HexStringToBytes(textBox13.Text));
			if (operateResult.IsSuccess)
			{
				textBox11.Text = "Result：" + SoftBasic.ByteToHexString(operateResult.Content);
			}
			else
			{
				MessageBox.Show("Read Failed：" + operateResult.ToMessageShowString());
			}
		}

		private void Test1()
		{
			OperateResult<bool> operateResult = beckhoffAdsNet.ReadBool("M100.4");
			if (operateResult.IsSuccess)
			{
				bool content = operateResult.Content;
			}
			else
			{
				string message = operateResult.Message;
			}
			OperateResult operateResult2 = beckhoffAdsNet.Write("M100.4", true);
			if (!operateResult2.IsSuccess)
			{
				string message2 = operateResult2.Message;
			}
		}

		private void Test2()
		{
			byte content = beckhoffAdsNet.ReadByte("M100").Content;
			short content2 = beckhoffAdsNet.ReadInt16("M100").Content;
			ushort content3 = beckhoffAdsNet.ReadUInt16("M100").Content;
			int content4 = beckhoffAdsNet.ReadInt32("M100").Content;
			uint content5 = beckhoffAdsNet.ReadUInt32("M100").Content;
			float content6 = beckhoffAdsNet.ReadFloat("M100").Content;
			double content7 = beckhoffAdsNet.ReadDouble("M100").Content;
			string content8 = beckhoffAdsNet.ReadString("M100", 10).Content;
			IByteTransform byteTransform = new ReverseBytesTransform();
		}

		private void Test3()
		{
			bool content = beckhoffAdsNet.ReadBool("M100.7").Content;
			byte content2 = beckhoffAdsNet.ReadByte("M100").Content;
			short content3 = beckhoffAdsNet.ReadInt16("M100").Content;
			ushort content4 = beckhoffAdsNet.ReadUInt16("M100").Content;
			int content5 = beckhoffAdsNet.ReadInt32("M100").Content;
			uint content6 = beckhoffAdsNet.ReadUInt32("M100").Content;
			float content7 = beckhoffAdsNet.ReadFloat("M100").Content;
			long content8 = beckhoffAdsNet.ReadInt64("M100").Content;
			ulong content9 = beckhoffAdsNet.ReadUInt64("M100").Content;
			double content10 = beckhoffAdsNet.ReadDouble("M100").Content;
			string content11 = beckhoffAdsNet.ReadString("M100", 10).Content;
			beckhoffAdsNet.Write("M100.7", true);
			beckhoffAdsNet.Write("M100", 51);
			beckhoffAdsNet.Write("M100", (short)12345);
			beckhoffAdsNet.Write("M100", (ushort)45678);
			beckhoffAdsNet.Write("M100", 123456789);
			beckhoffAdsNet.Write("M100", 3456789123u);
			beckhoffAdsNet.Write("M100", 123.456f);
			beckhoffAdsNet.Write("M100", 1234556434534545L);
			beckhoffAdsNet.Write("M100", 523434234234343uL);
			beckhoffAdsNet.Write("M100", 123.456);
			beckhoffAdsNet.Write("M100", "K123456789");
			OperateResult<byte[]> operateResult = beckhoffAdsNet.Read("M100", 10);
			if (operateResult.IsSuccess)
			{
				byte b = operateResult.Content[0];
				byte b2 = operateResult.Content[1];
				byte b3 = operateResult.Content[2];
				byte b4 = operateResult.Content[3];
				byte b5 = operateResult.Content[4];
				byte b6 = operateResult.Content[5];
				byte b7 = operateResult.Content[6];
				byte b8 = operateResult.Content[7];
				byte b9 = operateResult.Content[8];
				byte b10 = operateResult.Content[9];
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton3_Click_003Ed__13))]
		[DebuggerStepThrough]
		private void button3_Click(object sender, EventArgs e)
		{
			_003Cbutton3_Click_003Ed__13 stateMachine = new _003Cbutton3_Click_003Ed__13();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton4_Click_003Ed__14))]
		[DebuggerStepThrough]
		private void button4_Click(object sender, EventArgs e)
		{
			_003Cbutton4_Click_003Ed__14 stateMachine = new _003Cbutton4_Click_003Ed__14();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton5_Click_003Ed__15))]
		[DebuggerStepThrough]
		private void button5_Click(object sender, EventArgs e)
		{
			_003Cbutton5_Click_003Ed__15 stateMachine = new _003Cbutton5_Click_003Ed__15();
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
			element.SetAttributeValue(DemoDeviceList.XmlTarget, textBox14.Text);
			element.SetAttributeValue(DemoDeviceList.XmlSender, textBox15.Text);
			element.SetAttributeValue(DemoDeviceList.XmlTagCache, checkBox_tag.Checked);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox14.Text = element.Attribute(DemoDeviceList.XmlTarget).Value;
			textBox15.Text = element.Attribute(DemoDeviceList.XmlSender).Value;
			checkBox_tag.Checked = bool.Parse(element.Attribute(DemoDeviceList.XmlTagCache).Value);
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
			label7 = new System.Windows.Forms.Label();
			textBox_ams_port = new System.Windows.Forms.TextBox();
			label17 = new System.Windows.Forms.Label();
			textBox15 = new System.Windows.Forms.TextBox();
			label15 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			textBox14 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			checkBox_auto = new System.Windows.Forms.CheckBox();
			label6 = new System.Windows.Forms.Label();
			checkBox_tag = new System.Windows.Forms.CheckBox();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox5 = new System.Windows.Forms.GroupBox();
			button5 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			button4 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			button3 = new System.Windows.Forms.Button();
			groupBox4 = new System.Windows.Forms.GroupBox();
			textBox11 = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			button26 = new System.Windows.Forms.Button();
			textBox13 = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			label9 = new System.Windows.Forms.Label();
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
			panel1.Controls.Add(label7);
			panel1.Controls.Add(textBox_ams_port);
			panel1.Controls.Add(label17);
			panel1.Controls.Add(textBox15);
			panel1.Controls.Add(label15);
			panel1.Controls.Add(label8);
			panel1.Controls.Add(textBox14);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label22);
			panel1.Controls.Add(label21);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(checkBox_auto);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(checkBox_tag);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1011, 79);
			panel1.TabIndex = 0;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(869, 52);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(128, 17);
			label7.TabIndex = 21;
			label7.Text = "4: M100.1 (bool读写)";
			textBox_ams_port.Location = new System.Drawing.Point(379, 52);
			textBox_ams_port.Name = "textBox_ams_port";
			textBox_ams_port.Size = new System.Drawing.Size(72, 23);
			textBox_ams_port.TabIndex = 19;
			textBox_ams_port.Text = "851";
			label17.AutoSize = true;
			label17.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
			label17.Location = new System.Drawing.Point(456, 54);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(402, 17);
			label17.TabIndex = 16;
			label17.Text = "TwinCAT2，端口号801,811,821,831；TwinCAT3，端口号为851,852,853";
			textBox15.Location = new System.Drawing.Point(273, 27);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(179, 23);
			textBox15.TabIndex = 14;
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(179, 30);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(98, 17);
			label15.TabIndex = 13;
			label15.Text = "Sender NetId：";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(459, 4);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(167, 17);
			label8.TabIndex = 12;
			label8.Text = "示例：192.168.1.100.1.1:801";
			textBox14.Location = new System.Drawing.Point(273, 2);
			textBox14.Name = "textBox14";
			textBox14.Size = new System.Drawing.Size(179, 23);
			textBox14.TabIndex = 11;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(179, 5);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(95, 17);
			label5.TabIndex = 10;
			label5.Text = "Target NetId：";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(790, 6);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(150, 17);
			label4.TabIndex = 9;
			label4.Text = "1: s=MAIN.ABC  (变量名)";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(715, 29);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(133, 17);
			label2.TabIndex = 8;
			label2.Text = "2: i=10000  (偏移地址)";
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(852, 28);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(131, 17);
			label22.TabIndex = 7;
			label22.Text = "3: M100  I100  Q100 ";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(716, 7);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(68, 17);
			label21.TabIndex = 6;
			label21.Text = "地址示例：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(630, 23);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(82, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(550, 23);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(76, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(62, 27);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(114, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "48898";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(8, 30);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 2);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(114, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 5);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			checkBox_auto.AutoSize = true;
			checkBox_auto.Location = new System.Drawing.Point(178, 54);
			checkBox_auto.Name = "checkBox_auto";
			checkBox_auto.Size = new System.Drawing.Size(115, 21);
			checkBox_auto.TabIndex = 17;
			checkBox_auto.Text = "自动AMS NetId";
			checkBox_auto.UseVisualStyleBackColor = true;
			label6.AutoSize = true;
			label6.ForeColor = System.Drawing.Color.Green;
			label6.Location = new System.Drawing.Point(310, 55);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(64, 17);
			label6.TabIndex = 20;
			label6.Text = "Ams Port:";
			checkBox_tag.AutoSize = true;
			checkBox_tag.Checked = true;
			checkBox_tag.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox_tag.Location = new System.Drawing.Point(462, 28);
			checkBox_tag.Name = "checkBox_tag";
			checkBox_tag.Size = new System.Drawing.Size(75, 21);
			checkBox_tag.TabIndex = 15;
			checkBox_tag.Text = "标签缓存";
			checkBox_tag.UseVisualStyleBackColor = true;
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteOp1);
			panel2.Controls.Add(groupBox5);
			panel2.Controls.Add(groupBox4);
			panel2.Controls.Add(groupBox3);
			panel2.Location = new System.Drawing.Point(3, 118);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(1011, 538);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Location = new System.Drawing.Point(3, 3);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(1003, 240);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			groupBox5.Controls.Add(button5);
			groupBox5.Controls.Add(textBox4);
			groupBox5.Controls.Add(button4);
			groupBox5.Controls.Add(textBox3);
			groupBox5.Controls.Add(button3);
			groupBox5.Location = new System.Drawing.Point(587, 243);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(419, 293);
			groupBox5.TabIndex = 4;
			groupBox5.TabStop = false;
			groupBox5.Text = "特殊功能测试";
			button5.Location = new System.Drawing.Point(140, 57);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(128, 28);
			button5.TabIndex = 14;
			button5.Text = "Release Handle";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			textBox4.Location = new System.Drawing.Point(6, 60);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(128, 23);
			textBox4.TabIndex = 13;
			textBox4.Text = "0";
			button4.Location = new System.Drawing.Point(140, 24);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(128, 28);
			button4.TabIndex = 12;
			button4.Text = "Read Ads State";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			textBox3.Location = new System.Drawing.Point(6, 92);
			textBox3.Multiline = true;
			textBox3.Name = "textBox3";
			textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox3.Size = new System.Drawing.Size(407, 185);
			textBox3.TabIndex = 11;
			button3.Location = new System.Drawing.Point(6, 24);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(128, 28);
			button3.TabIndex = 9;
			button3.Text = "Read Ads Info";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			groupBox4.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox4.Controls.Add(textBox11);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(button26);
			groupBox4.Controls.Add(textBox13);
			groupBox4.Controls.Add(label16);
			groupBox4.Location = new System.Drawing.Point(3, 416);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(578, 117);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "报文读取测试，此处需要填入完整的16进制报文字符串";
			textBox11.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox11.Location = new System.Drawing.Point(63, 60);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox11.Size = new System.Drawing.Size(509, 51);
			textBox11.TabIndex = 10;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(9, 62);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 9;
			label14.Text = "结果：";
			button26.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button26.Location = new System.Drawing.Point(490, 24);
			button26.Name = "button26";
			button26.Size = new System.Drawing.Size(82, 28);
			button26.TabIndex = 8;
			button26.Text = "报文读取";
			button26.UseVisualStyleBackColor = true;
			button26.Click += new System.EventHandler(button26_Click);
			textBox13.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox13.Location = new System.Drawing.Point(63, 27);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(421, 23);
			textBox13.TabIndex = 5;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(9, 30);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(44, 17);
			label16.TabIndex = 4;
			label16.Text = "报文：";
			groupBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox3.Controls.Add(label9);
			groupBox3.Controls.Add(textBox10);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(button25);
			groupBox3.Controls.Add(textBox9);
			groupBox3.Controls.Add(label12);
			groupBox3.Controls.Add(textBox6);
			groupBox3.Controls.Add(label11);
			groupBox3.Location = new System.Drawing.Point(3, 243);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(578, 167);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(7, 109);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(50, 34);
			label9.TabIndex = 11;
			label9.Text = "Length:\r\n0";
			textBox10.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox10.Location = new System.Drawing.Point(63, 60);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(509, 101);
			textBox10.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 62);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "结果：";
			button25.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button25.Location = new System.Drawing.Point(490, 24);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(82, 28);
			button25.TabIndex = 8;
			button25.Text = "批量读取";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			textBox9.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			textBox9.Location = new System.Drawing.Point(335, 27);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(135, 23);
			textBox9.TabIndex = 7;
			textBox9.Text = "2;4;2";
			label12.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(286, 30);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(44, 17);
			label12.TabIndex = 6;
			label12.Text = "长度：";
			textBox6.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox6.Location = new System.Drawing.Point(63, 27);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(217, 23);
			textBox6.TabIndex = 5;
			textBox6.Text = "M100;s=MAIN.dd;s=MAIN.a";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(9, 30);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 4;
			label11.Text = "地址：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/12051529.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "ADS";
			userControlHead1.Size = new System.Drawing.Size(1018, 32);
			userControlHead1.SupportListVisiable = true;
			userControlHead1.TabIndex = 2;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1018, 658);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormBeckhoffAdsNet";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "倍福PLC访问Demo";
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
