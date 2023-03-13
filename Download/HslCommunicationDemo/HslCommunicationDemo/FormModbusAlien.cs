using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Controls;
using HslCommunication.Core;
using HslCommunication.Core.Net;
using HslCommunication.ModBus;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormModbusAlien : HslFormContent
	{
		private ModbusTcpNet busTcpClient = null;

		private NetworkAlienClient networkAlien = null;

		private Thread thread = null;

		private int timeSleep = 300;

		private bool isThreadRun = false;

		private int thread_status = 0;

		private int failed = 0;

		private DateTime thread_time_start = DateTime.Now;

		private IContainer components = null;

		private Panel panel1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

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

		private TextBox textBox15;

		private Label label21;

		private CheckBox checkBox1;

		private Label label22;

		private TextBox textBox1;

		private Label label1;

		private UserControlHead userControlHead1;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private GroupBox groupBox5;

		private Button button27;

		private TextBox textBox14;

		private Label label18;

		private Label label17;

		private TextBox textBox12;

		private Label label15;

		private UserCurve userCurve1;

		public FormModbusAlien()
		{
			InitializeComponent();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			userCurve1.SetLeftCurve("A", new float[0], Color.Tomato);
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "Alien Modbus Tcp Read Demo";
				label3.Text = "Port:";
				label21.Text = "station";
				checkBox1.Text = "address from 0";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label11.Text = "Address:";
				label12.Text = "length:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				label16.Text = "Message:";
				label14.Text = "Results:";
				button26.Text = "Read";
				groupBox3.Text = "Bulk Read test";
				groupBox4.Text = "Message reading test, hex string needs to be filled in";
				groupBox5.Text = "Timed reading, curve display";
				label15.Text = "Address:";
				label18.Text = "Interval";
				button27.Text = "Start";
				label17.Text = "This assumes that the type of data is determined for short:";
				label22.Text = "(11-bit ASCII characters)";
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
			isThreadRun = false;
		}

		private void readResultRender<T>(OperateResult<T> result, string address, TextBox textBox)
		{
			if (result.IsSuccess)
			{
				textBox.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + string.Format("[{0}] {1}{2}", address, result.Content, Environment.NewLine));
			}
			else
			{
				MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + "[" + address + "] 读取失败" + Environment.NewLine + "原因：" + result.ToMessageShowString());
			}
		}

		private void writeResultRender(OperateResult result, string address)
		{
			if (result.IsSuccess)
			{
				MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + "[" + address + "] 写入成功");
			}
			else
			{
				MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + "[" + address + "] 写入失败" + Environment.NewLine + "原因：" + result.ToMessageShowString());
			}
		}

		private void NetworkAlienStart(int port)
		{
			networkAlien = new NetworkAlienClient();
			networkAlien.OnClientConnected += NetworkAlien_OnClientConnected;
			networkAlien.ServerStart(port);
		}

		private void NetworkAlien_OnClientConnected(AlienSession session)
		{
			if (session.DTU == busTcpClient.ConnectionId)
			{
				busTcpClient.ConnectServer(session);
				Invoke((Action)delegate
				{
					panel2.Enabled = true;
					button2.Enabled = true;
				});
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			byte result2;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show("端口输入不正确！");
			}
			else if (!byte.TryParse(textBox15.Text, out result2))
			{
				MessageBox.Show("站号输入不正确！");
			}
			else
			{
				busTcpClient = new ModbusTcpNet("127.0.0.1", result, result2);
				busTcpClient.LogNet = base.LogNet;
				busTcpClient.AddressStartWithZero = checkBox1.Checked;
				try
				{
					busTcpClient.ConnectionId = textBox1.Text;
					NetworkAlienStart(result);
					busTcpClient.ConnectServer(null);
					userControlReadWriteOp1.SetReadWriteNet(busTcpClient, "100", true);
					MessageBox.Show("等待服务器的连接！");
					button1.Enabled = false;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			busTcpClient.ConnectClose();
			button2.Enabled = false;
			panel2.Enabled = false;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			try
			{
				OperateResult<byte[]> operateResult = busTcpClient.Read(textBox6.Text, ushort.Parse(textBox9.Text));
				if (operateResult.IsSuccess)
				{
					textBox10.Text = "结果：" + SoftBasic.ByteToHexString(operateResult.Content);
				}
				else
				{
					MessageBox.Show("读取失败：" + operateResult.ToMessageShowString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("读取失败：" + ex.Message);
			}
		}

		private void button26_Click(object sender, EventArgs e)
		{
			try
			{
				OperateResult<byte[]> operateResult = busTcpClient.ReadFromCoreServer(SoftBasic.HexStringToBytes(textBox13.Text));
				if (operateResult.IsSuccess)
				{
					textBox11.Text = "结果：" + SoftBasic.ByteToHexString(operateResult.Content);
				}
				else
				{
					MessageBox.Show("读取失败：" + operateResult.ToMessageShowString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("读取失败：" + ex.Message);
			}
		}

		private void button27_Click(object sender, EventArgs e)
		{
			if (!isThreadRun)
			{
				if (!int.TryParse(textBox14.Text, out timeSleep))
				{
					MessageBox.Show("间隔时间格式输入错误！");
				}
				else
				{
					button27.Text = "停止";
					isThreadRun = true;
					thread = new Thread(ThreadReadServer);
					thread.IsBackground = true;
					thread.Start();
				}
			}
			else
			{
				button27.Text = "启动";
				isThreadRun = false;
			}
		}

		private void ThreadReadServer()
		{
			while (isThreadRun)
			{
				Thread.Sleep(timeSleep);
				try
				{
					OperateResult<short> operateResult = busTcpClient.ReadInt16(textBox12.Text);
					if (operateResult.IsSuccess && isThreadRun)
					{
						Invoke(new Action<short>(AddDataCurve), operateResult.Content);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("读取失败：" + ex.Message);
				}
			}
		}

		private void AddDataCurve(short data)
		{
			userCurve1.AddCurveData("A", (float)data);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			PressureTest2();
		}

		private void PressureTest2()
		{
			thread_status = 3;
			failed = 0;
			thread_time_start = DateTime.Now;
			Thread obj = new Thread(thread_test2);
			obj.IsBackground = true;
			obj.Start();
			Thread obj2 = new Thread(thread_test2);
			obj2.IsBackground = true;
			obj2.Start();
			Thread obj3 = new Thread(thread_test2);
			obj3.IsBackground = true;
			obj3.Start();
		}

		private void thread_test2()
		{
			for (int num = 500; num > 0; num--)
			{
				if (!busTcpClient.Write("100", (short)1234).IsSuccess)
				{
					failed++;
				}
				if (!busTcpClient.ReadInt16("100").IsSuccess)
				{
					failed++;
				}
			}
			thread_end();
		}

		private void thread_end()
		{
			if (Interlocked.Decrement(ref thread_status) == 0)
			{
				Invoke((Action)delegate
				{
					MessageBox.Show("耗时：" + (DateTime.Now - thread_time_start).TotalSeconds.ToString() + Environment.NewLine + "失败次数：" + failed.ToString());
				});
			}
		}

		private void Test1()
		{
			OperateResult<bool[]> operateResult = busTcpClient.ReadCoil("100", 10);
			if (operateResult.IsSuccess)
			{
				bool flag = operateResult.Content[0];
				bool flag2 = operateResult.Content[9];
			}
			else
			{
				string message = operateResult.Message;
			}
		}

		private void Test2()
		{
			bool[] value = new bool[10]
			{
				true,
				false,
				false,
				false,
				true,
				true,
				false,
				true,
				false,
				false
			};
			OperateResult operateResult = busTcpClient.Write("100", value);
			if (!operateResult.IsSuccess)
			{
				string message = operateResult.Message;
			}
			IByteTransform byteTransform = new ReverseWordTransform();
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
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			checkBox1 = new System.Windows.Forms.CheckBox();
			textBox15 = new System.Windows.Forms.TextBox();
			label21 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			groupBox5 = new System.Windows.Forms.GroupBox();
			button27 = new System.Windows.Forms.Button();
			textBox14 = new System.Windows.Forms.TextBox();
			label18 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			textBox12 = new System.Windows.Forms.TextBox();
			label15 = new System.Windows.Forms.Label();
			userCurve1 = new HslCommunication.Controls.UserCurve();
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
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(checkBox1);
			panel1.Controls.Add(textBox15);
			panel1.Controls.Add(label21);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label22);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 42);
			panel1.TabIndex = 0;
			textBox1.Location = new System.Drawing.Point(460, 7);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(171, 23);
			textBox1.TabIndex = 11;
			textBox1.Text = "12345678901";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(399, 10);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(62, 17);
			label1.TabIndex = 10;
			label1.Text = "DTU ID：";
			checkBox1.AutoSize = true;
			checkBox1.Checked = true;
			checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox1.Location = new System.Drawing.Point(287, 9);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(106, 21);
			checkBox1.TabIndex = 9;
			checkBox1.Text = "首地址从0开始";
			checkBox1.UseVisualStyleBackColor = true;
			textBox15.Location = new System.Drawing.Point(219, 7);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(58, 23);
			textBox15.TabIndex = 7;
			textBox15.Text = "1";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(165, 10);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(44, 17);
			label21.TabIndex = 6;
			label21.Text = "站号：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(875, 4);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(772, 4);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "创建";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(74, 7);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(76, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "10000";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(20, 10);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(639, 10);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(97, 17);
			label22.TabIndex = 12;
			label22.Text = "(11位ASCII字符)";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlReadWriteOp1);
			panel2.Controls.Add(groupBox5);
			panel2.Controls.Add(groupBox4);
			panel2.Controls.Add(groupBox3);
			panel2.Location = new System.Drawing.Point(3, 80);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 564);
			panel2.TabIndex = 1;
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Location = new System.Drawing.Point(3, 2);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(989, 237);
			userControlReadWriteOp1.TabIndex = 5;
			groupBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox5.Controls.Add(button27);
			groupBox5.Controls.Add(textBox14);
			groupBox5.Controls.Add(label18);
			groupBox5.Controls.Add(label17);
			groupBox5.Controls.Add(textBox12);
			groupBox5.Controls.Add(label15);
			groupBox5.Controls.Add(userCurve1);
			groupBox5.Location = new System.Drawing.Point(573, 243);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(419, 316);
			groupBox5.TabIndex = 4;
			groupBox5.TabStop = false;
			groupBox5.Text = "定时读取，曲线显示";
			button27.Location = new System.Drawing.Point(343, 25);
			button27.Name = "button27";
			button27.Size = new System.Drawing.Size(70, 28);
			button27.TabIndex = 9;
			button27.Text = "启动";
			button27.UseVisualStyleBackColor = true;
			button27.Click += new System.EventHandler(button27_Click);
			textBox14.Location = new System.Drawing.Point(255, 28);
			textBox14.Name = "textBox14";
			textBox14.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox14.Size = new System.Drawing.Size(82, 23);
			textBox14.TabIndex = 8;
			textBox14.Text = "300";
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(212, 30);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(44, 17);
			label18.TabIndex = 7;
			label18.Text = "间隔：";
			label17.AutoSize = true;
			label17.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			label17.Location = new System.Drawing.Point(60, 53);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(218, 17);
			label17.TabIndex = 6;
			label17.Text = "此处假设确定了数据的类型，为short：";
			textBox12.Location = new System.Drawing.Point(64, 27);
			textBox12.Name = "textBox12";
			textBox12.Size = new System.Drawing.Size(132, 23);
			textBox12.TabIndex = 5;
			textBox12.Text = "100";
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(10, 30);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(44, 17);
			label15.TabIndex = 4;
			label15.Text = "地址：";
			userCurve1.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
			userCurve1.Location = new System.Drawing.Point(13, 82);
			userCurve1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userCurve1.Name = "userCurve1";
			userCurve1.Size = new System.Drawing.Size(400, 226);
			userCurve1.TabIndex = 0;
			userCurve1.ValueMaxLeft = 200f;
			userCurve1.ValueMaxRight = 200f;
			groupBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox4.Controls.Add(textBox11);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(button26);
			groupBox4.Controls.Add(textBox13);
			groupBox4.Controls.Add(label16);
			groupBox4.Location = new System.Drawing.Point(3, 403);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(564, 156);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "报文读取测试，此处需要填入完整的16进制报文字符串";
			textBox11.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox11.Location = new System.Drawing.Point(63, 60);
			textBox11.Multiline = true;
			textBox11.Name = "textBox11";
			textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox11.Size = new System.Drawing.Size(495, 88);
			textBox11.TabIndex = 10;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(9, 62);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 9;
			label14.Text = "结果：";
			button26.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button26.Location = new System.Drawing.Point(476, 24);
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
			textBox13.Text = "00 00 00 00 00 06 FF 03 00 00 00 05";
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
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7885368.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Modbus Tcp - dtu";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 2;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormModbusAlien";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Modbus Tcp 异形客户端测试";
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
