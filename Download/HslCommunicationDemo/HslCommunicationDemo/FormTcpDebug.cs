using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using HslCommunication.Serial;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.HslDebug;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormTcpDebug : HslFormContent
	{
		private Socket socketCore = null;

		private bool connectSuccess = false;

		private byte[] buffer = new byte[2048];

		private System.Windows.Forms.Timer timer;

		private List<byte[]> connectHandShake;

		private EndPoint udpEndPoint = null;

		private Thread threadReceive;

		private bool IsStarted = false;

		private bool isBinary = true;

		private bool toledoThread = false;

		private Random random = new Random();

		private float toledoWeight = 30f;

		private IContainer components = null;

		private Panel panel_main;

		private TextBox textBox6;

		private CheckBox checkBox_show_time;

		private CheckBox checkBox_show_send;

		private Label label7;

		private Button button_send;

		private TextBox textBox5;

		private Label label6;

		private Panel panel1;

		private Button button2;

		private Button button1;

		private TextBox textBox_port;

		private Label label3;

		private TextBox textBox_ip;

		private Label label1;

		private Label label8;

		private Button button4;

		private Button button5;

		private UserControlHead userControlHead1;

		private Button button6;

		private Label label2;

		private Panel panel4;

		private RadioButton radioButton_append_0d0a;

		private RadioButton radioButton_append_none;

		private RadioButton radioButton_append_0a;

		private RadioButton radioButton_append_0d;

		private Label label_append;

		private Panel panel3;

		private RadioButton radioButton_ascii;

		private RadioButton radioButton_binary;

		private CheckBox checkBox_stop_show;

		private RadioButton radioButton_append_crc16;

		private Button button_edit_hand;

		private Label label4;

		private Label label5;

		private Panel panel_tcp_udp;

		private RadioButton radioButton_udp;

		private RadioButton radioButton_tcp;

		private CheckBox checkBox_auto_return;

		public FormTcpDebug()
		{
			InitializeComponent();
			connectHandShake = new List<byte[]>();
		}

		private void FormTcpDebug_Load(object sender, EventArgs e)
		{
			panel_main.Enabled = false;
			timer = new System.Windows.Forms.Timer();
			timer.Interval = 500;
			timer.Tick += Timer_Tick;
			timer.Start();
			Language(Program.Language);
			panel3.Paint += Panel3_Paint;
			panel4.Paint += Panel3_Paint;
			radioButton_binary.CheckedChanged += RadioButton_binary_CheckedChanged;
		}

		private void RadioButton_binary_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton_binary.Checked)
			{
				isBinary = true;
			}
			else
			{
				isBinary = false;
			}
		}

		private void Panel3_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(0, 0, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1));
		}

		private void Language(int language)
		{
			if (language == 1)
			{
				Text = "TCP/IP调试助手";
				label1.Text = "Ip地址：";
				label3.Text = "端口号：";
				button1.Text = "连接";
				button2.Text = "关闭连接";
				label6.Text = "数据发送区：";
				label7.Text = "数据收发显示：";
				checkBox_show_send.Text = "是否显示发送数据";
				checkBox_show_time.Text = "是否显示时间";
				button_send.Text = "发送数据";
				label8.Text = "已选择数据字节数：";
			}
			else
			{
				Text = "TCP/IP Debug Tools";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				button4.Text = "Build Message";
				label6.Text = "Data sending Area:";
				label7.Text = "Data sending and receiving display:";
				checkBox_show_send.Text = "Whether to display send data";
				checkBox_show_time.Text = "Whether to show time";
				button_send.Text = "Send Data";
				label8.Text = "Number of data bytes selected:";
				checkBox_stop_show.Text = "Stop Show";
			}
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox6.Text))
			{
				string selectedText = textBox6.SelectedText;
				if (!string.IsNullOrEmpty(selectedText))
				{
					if (isBinary)
					{
						byte[] array = SoftBasic.HexStringToBytes(selectedText);
						label8.Text = ((Program.Language == 1) ? "已选择数据字节数：" : "Number of data bytes selected:") + array.Length.ToString();
					}
					else
					{
						label8.Text = ((Program.Language == 1) ? "已选择数据字节数：" : "Number of data bytes selected:") + selectedText.Length.ToString();
					}
				}
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			textBox6.Clear();
		}

		private void button_edit_hand_Click(object sender, EventArgs e)
		{
			using (FormHandShake formHandShake = new FormHandShake(connectHandShake))
			{
				if (formHandShake.ShowDialog(this) == DialogResult.OK)
				{
					connectHandShake = formHandShake.HandShake;
					Label label = label4;
					string str = (Program.Language == 1) ? "握手包：" : "HandShanke: ";
					List<byte[]> handShake = formHandShake.HandShake;
					label.Text = str + ((handShake != null) ? new int?(handShake.Count) : null).ToString();
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				Socket socket = socketCore;
				if (socket != null)
				{
					socket.Close();
				}
				IPAddress iPAddress = IPAddress.Parse(HslHelper.GetIpAddressFromInput(textBox_ip.Text));
				if (radioButton_tcp.Checked)
				{
					socketCore = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
					connectSuccess = false;
					new Thread((ThreadStart)delegate
					{
						Thread.Sleep(5000);
						if (!connectSuccess)
						{
							Socket socket2 = socketCore;
							if (socket2 != null)
							{
								socket2.Close();
							}
						}
					}).Start();
					socketCore.Connect(iPAddress, int.Parse(textBox_port.Text));
					connectSuccess = true;
					if (connectHandShake.Count > 0)
					{
						for (int i = 0; i < connectHandShake.Count; i++)
						{
							SendData(connectHandShake[i]);
							int length = socketCore.Receive(buffer, 0, buffer.Length, SocketFlags.None);
							textBox6.AppendText(GetTextHeader(0, buffer.SelectBegin(length)));
						}
					}
					socketCore.BeginReceive(buffer, 0, 2048, SocketFlags.None, ReceiveCallBack, socketCore);
				}
				else
				{
					udpEndPoint = new IPEndPoint(iPAddress, int.Parse(textBox_port.Text));
					socketCore = new Socket(iPAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
					socketCore.SendTo(new byte[0], udpEndPoint);
					if (connectHandShake.Count > 0)
					{
						for (int j = 0; j < connectHandShake.Count; j++)
						{
							SendData(connectHandShake[j]);
							EndPoint remoteEP = new IPEndPoint((udpEndPoint.AddressFamily == AddressFamily.InterNetworkV6) ? IPAddress.IPv6Any : IPAddress.Any, 0);
							int length2 = socketCore.ReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref remoteEP);
							textBox6.AppendText(GetTextHeader(0, buffer.SelectBegin(length2)));
						}
					}
					IsStarted = true;
					threadReceive = new Thread(ThreadReceiveUdpCycle)
					{
						IsBackground = true
					};
					threadReceive.Start();
				}
				button1.Enabled = false;
				button2.Enabled = true;
				panel_main.Enabled = true;
				panel_tcp_udp.Enabled = false;
				button_send.Enabled = true;
				MessageBox.Show(StringResources.Language.ConnectServerSuccess);
			}
			catch (Exception ex)
			{
				MessageBox.Show(StringResources.Language.ConnectedFailed + Environment.NewLine + ex.Message);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			IsStarted = false;
			Socket socket = socketCore;
			if (socket != null)
			{
				socket.Close();
			}
			button1.Enabled = true;
			button2.Enabled = false;
			panel_tcp_udp.Enabled = true;
			button_send.Enabled = false;
		}

		private string GetTextHeader(int code, byte[] info)
		{
			if (isBinary)
			{
				return GetTextHeader(checkBox_show_time.Checked, code, SoftBasic.ByteToHexString(info, ' '));
			}
			return GetTextHeader(checkBox_show_time.Checked, code, SoftBasic.GetAsciiStringRender(info));
		}

		public static string GetTextHeader(bool timeShow, int code, string info)
		{
			string empty = string.Empty;
			if (Program.Language == 1)
			{
				object obj;
				switch (code)
				{
				default:
					obj = "None";
					break;
				case 2:
					obj = "关";
					break;
				case 1:
					obj = "发";
					break;
				case 0:
					obj = "收";
					break;
				}
				empty = (string)obj;
			}
			else
			{
				object obj2;
				switch (code)
				{
				default:
					obj2 = "None";
					break;
				case 2:
					obj2 = "Clos";
					break;
				case 1:
					obj2 = "Send";
					break;
				case 0:
					obj2 = "Recv";
					break;
				}
				empty = (string)obj2;
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (timeShow)
			{
				stringBuilder.Append("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "] ");
			}
			stringBuilder.Append("[" + empty + "]   ");
			stringBuilder.Append(info);
			stringBuilder.AppendLine();
			return stringBuilder.ToString();
		}

		protected virtual void ThreadReceiveUdpCycle()
		{
			IPEndPoint iPEndPoint = new IPEndPoint((udpEndPoint.AddressFamily == AddressFamily.InterNetworkV6) ? IPAddress.IPv6Any : IPAddress.Any, 0);
			EndPoint remoteEP = iPEndPoint;
			Exception ex;
			while (IsStarted)
			{
				int length = 0;
				try
				{
					length = socketCore.ReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref remoteEP);
					if (length > 0)
					{
						Invoke((Action)delegate
						{
							if (!checkBox_stop_show.Checked)
							{
								textBox6.AppendText(GetTextHeader(0, buffer.SelectBegin(length)));
							}
						});
					}
				}
				catch (Exception ex2)
				{
					Exception ex3 = ex = ex2;
					Invoke((Action)delegate
					{
						textBox6.AppendText(((Program.Language == 1) ? "服务器断开连接。原因：" : "DisConnect from remote, reason: ") + ex.Message + Environment.NewLine);
					});
				}
			}
		}

		private void ReceiveCallBack(IAsyncResult ar)
		{
			try
			{
				int num = socketCore.EndReceive(ar);
				byte[] data = new byte[num];
				if (num > 0)
				{
					Array.Copy(buffer, 0, data, 0, num);
				}
				socketCore.BeginReceive(buffer, 0, 2048, SocketFlags.None, ReceiveCallBack, socketCore);
				if (num == 0)
				{
					Invoke((Action)delegate
					{
						textBox6.AppendText(GetTextHeader(checkBox_show_time.Checked, 2, (Program.Language == 1) ? "远程关闭连接" : "Remote closes connection"));
						Socket socket = socketCore;
						if (socket != null)
						{
							socket.Close();
						}
						button_send.Enabled = false;
						button1.Enabled = true;
						button2.Enabled = false;
					});
				}
				else
				{
					Invoke((Action)delegate
					{
						if (!checkBox_stop_show.Checked)
						{
							textBox6.AppendText(GetTextHeader(0, data));
						}
						if (checkBox_auto_return.Checked)
						{
							button_send.PerformClick();
						}
					});
				}
			}
			catch (ObjectDisposedException)
			{
				Invoke((Action)delegate
				{
					textBox6.AppendText(GetTextHeader(checkBox_show_time.Checked, 2, (Program.Language == 1) ? "客户端关闭连接" : "Client closes connection"));
					button_send.Enabled = false;
					button1.Enabled = true;
					button2.Enabled = false;
				});
			}
			catch (Exception ex3)
			{
				Exception ex;
				Exception ex4 = ex = ex3;
				Invoke((Action)delegate
				{
					textBox6.AppendText(GetTextHeader(checkBox_show_time.Checked, 2, ((Program.Language == 1) ? "服务器断开连接: " : "DisConnect from remote: ") + ex.Message));
					button_send.Enabled = false;
					button1.Enabled = true;
					button2.Enabled = false;
				});
			}
		}

		private void SendData(byte[] send)
		{
			if (send != null)
			{
				try
				{
					if (radioButton_tcp.Checked)
					{
						Socket socket = socketCore;
						if (socket != null)
						{
							socket.Send(send, 0, send.Length, SocketFlags.None);
						}
					}
					else
					{
						Socket socket2 = socketCore;
						if (socket2 != null)
						{
							socket2.SendTo(send, 0, send.Length, SocketFlags.None, udpEndPoint);
						}
					}
					textBox6.AppendText(GetTextHeader(1, send));
				}
				catch (Exception ex)
				{
					SoftBasic.ShowExceptionMessage(ex);
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			byte[] array = isBinary ? SoftBasic.HexStringToBytes(textBox5.Text) : SoftBasic.GetFromAsciiStringRender(textBox5.Text);
			if (radioButton_append_0d.Checked)
			{
				array = SoftBasic.SpliceArray<byte>(array, new byte[1]
				{
					13
				});
			}
			else if (radioButton_append_0a.Checked)
			{
				array = SoftBasic.SpliceArray<byte>(array, new byte[1]
				{
					10
				});
			}
			else if (radioButton_append_0d0a.Checked)
			{
				array = SoftBasic.SpliceArray<byte>(array, new byte[2]
				{
					13,
					10
				});
			}
			else if (radioButton_append_crc16.Checked)
			{
				array = SoftCRC16.CRC16(array);
			}
			SendData(array);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			using (FormMessageCreate formMessageCreate = new FormMessageCreate())
			{
				if (formMessageCreate.ShowDialog() == DialogResult.OK && formMessageCreate.MessageCreate != null)
				{
					if (formMessageCreate.MessageCreate.HexBinary)
					{
						radioButton_binary.Checked = true;
					}
					else
					{
						radioButton_ascii.Checked = true;
					}
					textBox5.Text = formMessageCreate.MessageCreate.Result;
				}
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (button6.BackColor != Color.Green)
			{
				toledoThread = true;
				button6.BackColor = Color.Green;
				Thread thread = new Thread(ToledoTest);
				thread.IsBackground = true;
				thread.Start();
			}
			else
			{
				toledoThread = false;
				button6.BackColor = SystemColors.Control;
			}
		}

		private void ToledoTest()
		{
			while (toledoThread)
			{
				Thread.Sleep(30);
				byte[] array = "02 2C 30 20 20 20 33 38 36 32 20 20 20 30 30 30 0D".ToHexBytes();
				toledoWeight += (float)random.Next(200) / 100f - 1f;
				if (toledoWeight < 0f)
				{
					toledoWeight = 5f;
				}
				if (toledoWeight > 100f)
				{
					toledoWeight = 95f;
				}
				string s = toledoWeight.ToString("F2").Replace(".", "").PadLeft(6, ' ');
				Encoding.ASCII.GetBytes(s).CopyTo(array, 4);
				try
				{
					Socket socket = socketCore;
					if (socket != null)
					{
						socket.Send(array, 0, array.Length, SocketFlags.None);
					}
				}
				catch (Exception ex)
				{
					SoftBasic.ShowExceptionMessage(ex);
					return;
				}
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
			panel_main = new System.Windows.Forms.Panel();
			label5 = new System.Windows.Forms.Label();
			checkBox_stop_show = new System.Windows.Forms.CheckBox();
			panel4 = new System.Windows.Forms.Panel();
			radioButton_append_crc16 = new System.Windows.Forms.RadioButton();
			radioButton_append_0d0a = new System.Windows.Forms.RadioButton();
			radioButton_append_none = new System.Windows.Forms.RadioButton();
			radioButton_append_0a = new System.Windows.Forms.RadioButton();
			radioButton_append_0d = new System.Windows.Forms.RadioButton();
			label_append = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			radioButton_ascii = new System.Windows.Forms.RadioButton();
			radioButton_binary = new System.Windows.Forms.RadioButton();
			label2 = new System.Windows.Forms.Label();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			label8 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			checkBox_show_time = new System.Windows.Forms.CheckBox();
			checkBox_show_send = new System.Windows.Forms.CheckBox();
			label7 = new System.Windows.Forms.Label();
			button_send = new System.Windows.Forms.Button();
			textBox5 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			panel_tcp_udp = new System.Windows.Forms.Panel();
			radioButton_udp = new System.Windows.Forms.RadioButton();
			radioButton_tcp = new System.Windows.Forms.RadioButton();
			button_edit_hand = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox_port = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox_ip = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			checkBox_auto_return = new System.Windows.Forms.CheckBox();
			panel_main.SuspendLayout();
			panel4.SuspendLayout();
			panel3.SuspendLayout();
			panel1.SuspendLayout();
			panel_tcp_udp.SuspendLayout();
			SuspendLayout();
			panel_main.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_main.Controls.Add(checkBox_auto_return);
			panel_main.Controls.Add(label5);
			panel_main.Controls.Add(checkBox_stop_show);
			panel_main.Controls.Add(panel4);
			panel_main.Controls.Add(panel3);
			panel_main.Controls.Add(label2);
			panel_main.Controls.Add(button6);
			panel_main.Controls.Add(button5);
			panel_main.Controls.Add(button4);
			panel_main.Controls.Add(label8);
			panel_main.Controls.Add(textBox6);
			panel_main.Controls.Add(checkBox_show_time);
			panel_main.Controls.Add(checkBox_show_send);
			panel_main.Controls.Add(label7);
			panel_main.Controls.Add(button_send);
			panel_main.Controls.Add(textBox5);
			panel_main.Controls.Add(label6);
			panel_main.Location = new System.Drawing.Point(3, 103);
			panel_main.Name = "panel_main";
			panel_main.Size = new System.Drawing.Size(997, 528);
			panel_main.TabIndex = 20;
			label5.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label5.AutoSize = true;
			label5.ForeColor = System.Drawing.Color.Gray;
			label5.Location = new System.Drawing.Point(601, 506);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(78, 17);
			label5.TabIndex = 33;
			label5.Text = "Send Count:";
			checkBox_stop_show.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			checkBox_stop_show.AutoSize = true;
			checkBox_stop_show.Location = new System.Drawing.Point(881, 413);
			checkBox_stop_show.Name = "checkBox_stop_show";
			checkBox_stop_show.Size = new System.Drawing.Size(75, 21);
			checkBox_stop_show.TabIndex = 32;
			checkBox_stop_show.Text = "暂停显示";
			checkBox_stop_show.UseVisualStyleBackColor = true;
			panel4.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			panel4.BackColor = System.Drawing.SystemColors.Control;
			panel4.Controls.Add(radioButton_append_crc16);
			panel4.Controls.Add(radioButton_append_0d0a);
			panel4.Controls.Add(radioButton_append_none);
			panel4.Controls.Add(radioButton_append_0a);
			panel4.Controls.Add(radioButton_append_0d);
			panel4.Controls.Add(label_append);
			panel4.Location = new System.Drawing.Point(248, 409);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(348, 28);
			panel4.TabIndex = 31;
			radioButton_append_crc16.AutoSize = true;
			radioButton_append_crc16.Location = new System.Drawing.Point(281, 3);
			radioButton_append_crc16.Name = "radioButton_append_crc16";
			radioButton_append_crc16.Size = new System.Drawing.Size(57, 21);
			radioButton_append_crc16.TabIndex = 5;
			radioButton_append_crc16.Text = "crc16";
			radioButton_append_crc16.UseVisualStyleBackColor = true;
			radioButton_append_0d0a.AutoSize = true;
			radioButton_append_0d0a.Location = new System.Drawing.Point(223, 3);
			radioButton_append_0d0a.Name = "radioButton_append_0d0a";
			radioButton_append_0d0a.Size = new System.Drawing.Size(48, 21);
			radioButton_append_0d0a.TabIndex = 4;
			radioButton_append_0d0a.Text = "\\r\\n";
			radioButton_append_0d0a.UseVisualStyleBackColor = true;
			radioButton_append_none.AutoSize = true;
			radioButton_append_none.Checked = true;
			radioButton_append_none.Location = new System.Drawing.Point(69, 4);
			radioButton_append_none.Name = "radioButton_append_none";
			radioButton_append_none.Size = new System.Drawing.Size(58, 21);
			radioButton_append_none.TabIndex = 3;
			radioButton_append_none.TabStop = true;
			radioButton_append_none.Text = "None";
			radioButton_append_none.UseVisualStyleBackColor = true;
			radioButton_append_0a.AutoSize = true;
			radioButton_append_0a.Location = new System.Drawing.Point(179, 3);
			radioButton_append_0a.Name = "radioButton_append_0a";
			radioButton_append_0a.Size = new System.Drawing.Size(38, 21);
			radioButton_append_0a.TabIndex = 1;
			radioButton_append_0a.Text = "\\n";
			radioButton_append_0a.UseVisualStyleBackColor = true;
			radioButton_append_0d.AutoSize = true;
			radioButton_append_0d.Location = new System.Drawing.Point(133, 3);
			radioButton_append_0d.Name = "radioButton_append_0d";
			radioButton_append_0d.Size = new System.Drawing.Size(36, 21);
			radioButton_append_0d.TabIndex = 0;
			radioButton_append_0d.Text = "\\r";
			radioButton_append_0d.UseVisualStyleBackColor = true;
			label_append.AutoSize = true;
			label_append.Location = new System.Drawing.Point(4, 5);
			label_append.Name = "label_append";
			label_append.Size = new System.Drawing.Size(57, 17);
			label_append.TabIndex = 2;
			label_append.Text = "Append:";
			panel3.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			panel3.BackColor = System.Drawing.SystemColors.Control;
			panel3.Controls.Add(radioButton_ascii);
			panel3.Controls.Add(radioButton_binary);
			panel3.Location = new System.Drawing.Point(87, 409);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(155, 28);
			panel3.TabIndex = 30;
			radioButton_ascii.AutoSize = true;
			radioButton_ascii.Location = new System.Drawing.Point(86, 3);
			radioButton_ascii.Name = "radioButton_ascii";
			radioButton_ascii.Size = new System.Drawing.Size(57, 21);
			radioButton_ascii.TabIndex = 1;
			radioButton_ascii.Text = "ASCII";
			radioButton_ascii.UseVisualStyleBackColor = true;
			radioButton_binary.AutoSize = true;
			radioButton_binary.Checked = true;
			radioButton_binary.Location = new System.Drawing.Point(7, 3);
			radioButton_binary.Name = "radioButton_binary";
			radioButton_binary.Size = new System.Drawing.Size(62, 21);
			radioButton_binary.TabIndex = 0;
			radioButton_binary.TabStop = true;
			radioButton_binary.Text = "Binary";
			radioButton_binary.UseVisualStyleBackColor = true;
			label2.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label2.AutoSize = true;
			label2.ForeColor = System.Drawing.Color.Gray;
			label2.Location = new System.Drawing.Point(296, 506);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(273, 17);
			label2.TabIndex = 29;
			label2.Text = "If ASCII Format: use \\r , \\n means  0x0d  0x0a";
			button6.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			button6.Location = new System.Drawing.Point(602, 409);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(120, 28);
			button6.TabIndex = 26;
			button6.Text = "toledo msg test";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button5.Location = new System.Drawing.Point(902, 1);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(91, 25);
			button5.TabIndex = 25;
			button5.Text = "清空";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			button4.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			button4.Location = new System.Drawing.Point(728, 408);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(120, 28);
			button4.TabIndex = 23;
			button4.Text = "构建报文";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			label8.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label8.AutoSize = true;
			label8.ForeColor = System.Drawing.Color.Gray;
			label8.Location = new System.Drawing.Point(4, 506);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(116, 17);
			label8.TabIndex = 22;
			label8.Text = "已选择数据字节数：";
			textBox6.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox6.Location = new System.Drawing.Point(3, 29);
			textBox6.Multiline = true;
			textBox6.Name = "textBox6";
			textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox6.Size = new System.Drawing.Size(990, 376);
			textBox6.TabIndex = 21;
			checkBox_show_time.AutoSize = true;
			checkBox_show_time.Checked = true;
			checkBox_show_time.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox_show_time.Location = new System.Drawing.Point(299, 4);
			checkBox_show_time.Name = "checkBox_show_time";
			checkBox_show_time.Size = new System.Drawing.Size(99, 21);
			checkBox_show_time.TabIndex = 20;
			checkBox_show_time.Text = "是否显示时间";
			checkBox_show_time.UseVisualStyleBackColor = true;
			checkBox_show_send.AutoSize = true;
			checkBox_show_send.Checked = true;
			checkBox_show_send.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox_show_send.Location = new System.Drawing.Point(119, 4);
			checkBox_show_send.Name = "checkBox_show_send";
			checkBox_show_send.Size = new System.Drawing.Size(123, 21);
			checkBox_show_send.TabIndex = 19;
			checkBox_show_send.Text = "是否显示发送数据";
			checkBox_show_send.UseVisualStyleBackColor = true;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(3, 5);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(92, 17);
			label7.TabIndex = 18;
			label7.Text = "数据收发显示：";
			button_send.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			button_send.Location = new System.Drawing.Point(881, 465);
			button_send.Name = "button_send";
			button_send.Size = new System.Drawing.Size(107, 37);
			button_send.TabIndex = 17;
			button_send.Text = "发送数据";
			button_send.UseVisualStyleBackColor = true;
			button_send.Click += new System.EventHandler(button3_Click);
			textBox5.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox5.Location = new System.Drawing.Point(5, 441);
			textBox5.Multiline = true;
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(869, 61);
			textBox5.TabIndex = 16;
			label6.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(3, 414);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(80, 17);
			label6.TabIndex = 1;
			label6.Text = "数据发送区：";
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(panel_tcp_udp);
			panel1.Controls.Add(button_edit_hand);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox_port);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox_ip);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 61);
			panel1.TabIndex = 14;
			panel_tcp_udp.Controls.Add(radioButton_udp);
			panel_tcp_udp.Controls.Add(radioButton_tcp);
			panel_tcp_udp.Location = new System.Drawing.Point(51, 32);
			panel_tcp_udp.Name = "panel_tcp_udp";
			panel_tcp_udp.Size = new System.Drawing.Size(146, 23);
			panel_tcp_udp.TabIndex = 19;
			radioButton_udp.AutoSize = true;
			radioButton_udp.Location = new System.Drawing.Point(73, 1);
			radioButton_udp.Name = "radioButton_udp";
			radioButton_udp.Size = new System.Drawing.Size(51, 21);
			radioButton_udp.TabIndex = 1;
			radioButton_udp.Text = "UDP";
			radioButton_udp.UseVisualStyleBackColor = true;
			radioButton_tcp.AutoSize = true;
			radioButton_tcp.Checked = true;
			radioButton_tcp.Location = new System.Drawing.Point(10, 1);
			radioButton_tcp.Name = "radioButton_tcp";
			radioButton_tcp.Size = new System.Drawing.Size(48, 21);
			radioButton_tcp.TabIndex = 0;
			radioButton_tcp.TabStop = true;
			radioButton_tcp.Text = "TCP";
			radioButton_tcp.UseVisualStyleBackColor = true;
			button_edit_hand.Location = new System.Drawing.Point(540, 1);
			button_edit_hand.Name = "button_edit_hand";
			button_edit_hand.Size = new System.Drawing.Size(110, 31);
			button_edit_hand.TabIndex = 18;
			button_edit_hand.Text = "编辑握手包";
			button_edit_hand.UseVisualStyleBackColor = true;
			button_edit_hand.Click += new System.EventHandler(button_edit_hand_Click);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(463, 8);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(63, 17);
			label4.TabIndex = 6;
			label4.Text = "握手包：0";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(776, 3);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(679, 3);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox_port.Location = new System.Drawing.Point(374, 5);
			textBox_port.Name = "textBox_port";
			textBox_port.Size = new System.Drawing.Size(77, 23);
			textBox_port.TabIndex = 3;
			textBox_port.Text = "502";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(320, 8);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(44, 17);
			label3.TabIndex = 2;
			label3.Text = "Port：";
			textBox_ip.Location = new System.Drawing.Point(51, 5);
			textBox_ip.Name = "textBox_ip";
			textBox_ip.Size = new System.Drawing.Size(258, 23);
			textBox_ip.TabIndex = 1;
			textBox_ip.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(32, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "TCP/UDP Clinet";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 21;
			checkBox_auto_return.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			checkBox_auto_return.AutoSize = true;
			checkBox_auto_return.Location = new System.Drawing.Point(881, 438);
			checkBox_auto_return.Name = "checkBox_auto_return";
			checkBox_auto_return.Size = new System.Drawing.Size(75, 21);
			checkBox_auto_return.TabIndex = 34;
			checkBox_auto_return.Text = "暂停显示";
			checkBox_auto_return.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 633);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel_main);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormTcpDebug";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "TCP/IP调试助手";
			base.Load += new System.EventHandler(FormTcpDebug_Load);
			panel_main.ResumeLayout(false);
			panel_main.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel_tcp_udp.ResumeLayout(false);
			panel_tcp_udp.PerformLayout();
			ResumeLayout(false);
		}
	}
}
