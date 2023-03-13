using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Robot.EFORT;
using HslCommunication.Serial;
using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormTcpServer : HslFormContent
	{
		private object lockObject = new object();

		private Socket socketCore = null;

		private byte[] buffer = new byte[2048];

		private System.Windows.Forms.Timer timer;

		private List<ClientSession> sockets = new List<ClientSession>();

		private Thread threadReceive;

		private bool IsStarted = false;

		private EndPoint udpEndPoint = null;

		private IContainer components = null;

		private Panel panel_main;

		private TextBox textBox6;

		private CheckBox checkBox_show_time;

		private CheckBox checkBox3;

		private Label label7;

		private Button button3;

		private TextBox textBox5;

		private Label label6;

		private Panel panel1;

		private Button button_close;

		private Button button_start;

		private TextBox textBox_port;

		private Label label3;

		private Label label8;

		private Button button4;

		private Button button5;

		private UserControlHead userControlHead1;

		private Label label1;

		private ComboBox comboBox1;

		private Label label4;

		private Panel panel_tcp_udp;

		private RadioButton radioButton_udp;

		private RadioButton radioButton_tcp;

		private Panel panel4;

		private RadioButton radioButton_append_crc16;

		private RadioButton radioButton_append_0d0a;

		private RadioButton radioButton_append_none;

		private RadioButton radioButton_append_0a;

		private RadioButton radioButton_append_0d;

		private Label label_append;

		private Panel panel5;

		private RadioButton radioButton_ascii;

		private RadioButton radioButton_binary;

		private CheckBox checkBox_stop_show;

		public FormTcpServer()
		{
			InitializeComponent();
		}

		private void FormTcpDebug_Load(object sender, EventArgs e)
		{
			panel_main.Enabled = false;
			timer = new System.Windows.Forms.Timer();
			timer.Interval = 500;
			timer.Tick += Timer_Tick;
			timer.Start();
			Language(Program.Language);
			panel5.Paint += Panel3_Paint;
			panel4.Paint += Panel3_Paint;
			panel_tcp_udp.Paint += Panel3_Paint;
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
				button_start.Text = "启动";
				button_close.Text = "关闭";
				label6.Text = "数据发送区：";
				label7.Text = "数据接收区：";
				checkBox3.Text = "是否显示发送数据";
				checkBox_show_time.Text = "是否显示时间";
				button3.Text = "发送数据";
				label8.Text = "已选择数据字节数：";
			}
			else
			{
				Text = "TCP/IP Debug Tools";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button_start.Text = "Start";
				button_close.Text = "Close";
				label6.Text = "Data sending Area:";
				label7.Text = "Data receiving Area:";
				checkBox3.Text = "Whether to display send data";
				checkBox_show_time.Text = "Whether to show time";
				button3.Text = "Send Data";
				label8.Text = "Number of data bytes selected:";
			}
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox6.Text))
			{
				string selectedText = textBox6.SelectedText;
				if (!string.IsNullOrEmpty(selectedText))
				{
					if (radioButton_binary.Checked)
					{
						byte[] array = SoftBasic.HexStringToBytes(selectedText);
						label8.Text = ((Program.Language == 1) ? "已选择数据字节数：" : "Number of data bytes selected:") + array.Length.ToString();
					}
					else
					{
						label8.Text = ((Program.Language == 1) ? "已选择数据字节数：" : "Number of data bytes selected:") + selectedText.Length.ToString();
					}
				}
				label4.Text = "Onlines: " + sockets.Count.ToString();
			}
		}

		private void RenderReiceiveData(IPEndPoint endPoint, byte[] data)
		{
			string info = radioButton_binary.Checked ? SoftBasic.ByteToHexString(data, ' ') : SoftBasic.GetAsciiStringRender(data);
			if (!checkBox_stop_show.Checked)
			{
				textBox6.AppendText(FormTcpDebug.GetTextHeader(checkBox_show_time.Checked, 0, info));
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			byte[] array = radioButton_binary.Checked ? SoftBasic.HexStringToBytes(textBox5.Text) : SoftBasic.GetFromAsciiStringRender(textBox5.Text);
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
			if (checkBox3.Checked)
			{
				textBox6.AppendText(FormTcpDebug.GetTextHeader(checkBox_show_time.Checked, 1, radioButton_binary.Checked ? SoftBasic.ByteToHexString(array, ' ') : SoftBasic.GetAsciiStringRender(array)));
			}
			try
			{
				if (radioButton_tcp.Checked)
				{
					lock (lockObject)
					{
						int num = 0;
						while (true)
						{
							if (num >= sockets.Count)
							{
								return;
							}
							if (sockets[num].EndPoint.ToString() == comboBox1.Text)
							{
								break;
							}
							num++;
						}
						sockets[num].Socket.Send(array, 0, array.Length, SocketFlags.None);
					}
				}
				else if (udpEndPoint != null)
				{
					socketCore.SendTo(array, 0, array.Length, SocketFlags.None, udpEndPoint);
				}
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage(ex);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			ER7BC10 eR7BC = new ER7BC10("192.168.0.100", 8008);
			textBox5.Text = SoftBasic.ByteToHexString(eR7BC.GetReadCommand(), ' ');
		}

		private void ThreadReceiveUdpCycle()
		{
			EndPoint Remote;
			IPEndPoint iPEndPoint = (IPEndPoint)(Remote = new IPEndPoint(IPAddress.Any, 0));
			while (IsStarted)
			{
				byte[] data = new byte[2048];
				int length = 0;
				try
				{
					length = socketCore.ReceiveFrom(data, ref Remote);
					udpEndPoint = Remote;
					if (length > 0)
					{
						Invoke((Action)delegate
						{
							comboBox1.DataSource = new EndPoint[1]
							{
								udpEndPoint
							};
							RenderReiceiveData((IPEndPoint)Remote, data.SelectBegin(length));
						});
					}
				}
				catch
				{
					Invoke((Action)delegate
					{
						textBox6.AppendText(((Program.Language == 1) ? "服务器断开连接。" : "DisConnect from remote") + Environment.NewLine);
					});
				}
			}
		}

		protected void AsyncAcceptCallback(IAsyncResult iar)
		{
			Socket socket = iar.AsyncState as Socket;
			if (socket != null)
			{
				Socket socket2 = null;
				ClientSession session = new ClientSession();
				try
				{
					socket2 = socket.EndAccept(iar);
					session.Socket = socket2;
					session.EndPoint = (IPEndPoint)socket2.RemoteEndPoint;
					socket2.BeginReceive(buffer, 0, 2048, SocketFlags.None, ReceiveCallBack, session);
					lock (session)
					{
						sockets.Add(session);
					}
					Invoke((Action)delegate
					{
						textBox6.AppendText("Client Online[" + session.EndPoint.Address.ToString() + "]" + Environment.NewLine);
						lock (lockObject)
						{
							comboBox1.DataSource = (from m in sockets
							select m.EndPoint.ToString()).ToArray();
						}
					});
				}
				catch (ObjectDisposedException)
				{
					lock (lockObject)
					{
						sockets.Remove(session);
					}
					return;
				}
				catch
				{
					lock (lockObject)
					{
						sockets.Remove(session);
					}
					if (socket2 != null)
					{
						socket2.Close();
					}
				}
				socket.BeginAccept(AsyncAcceptCallback, socket);
			}
		}

		private void ReceiveCallBack(IAsyncResult ar)
		{
			object asyncState = ar.AsyncState;
			ClientSession client = asyncState as ClientSession;
			if (client != null)
			{
				try
				{
					int num = client.Socket.EndReceive(ar);
					if (num == 0)
					{
						Invoke((Action)delegate
						{
							client.Socket.Close();
							lock (lockObject)
							{
								sockets.Remove(client);
								comboBox1.DataSource = (from m in sockets
								select m.EndPoint.ToString()).ToArray();
							}
							textBox6.AppendText(FormTcpDebug.GetTextHeader(checkBox_show_time.Checked, 2, "Client Offline[" + client.EndPoint.Address.ToString() + "]" + ((Program.Language == 1) ? "远程关闭连接" : "Remote closes connection")));
						});
					}
					else
					{
						client.Socket.BeginReceive(buffer, 0, 2048, SocketFlags.None, ReceiveCallBack, client);
						byte[] data = new byte[num];
						Array.Copy(buffer, 0, data, 0, num);
						Invoke((Action)delegate
						{
							RenderReiceiveData(client.EndPoint, data);
						});
					}
				}
				catch (ObjectDisposedException)
				{
					Invoke((Action)delegate
					{
						lock (lockObject)
						{
							sockets.Remove(client);
							comboBox1.DataSource = (from m in sockets
							select m.EndPoint.ToString()).ToArray();
						}
					});
				}
				catch
				{
					Invoke((Action)delegate
					{
						lock (lockObject)
						{
							sockets.Remove(client);
							comboBox1.DataSource = (from m in sockets
							select m.EndPoint.ToString()).ToArray();
						}
						textBox6.AppendText((Program.Language == 1) ? "服务器断开连接。" : ("DisConnect from remote" + Environment.NewLine));
					});
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				if (radioButton_tcp.Checked)
				{
					socketCore = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					socketCore.Bind(new IPEndPoint(0L, int.Parse(textBox_port.Text)));
					socketCore.Listen(500);
					socketCore.BeginAccept(AsyncAcceptCallback, socketCore);
				}
				else
				{
					socketCore = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
					socketCore.Bind(new IPEndPoint(IPAddress.Any, int.Parse(textBox_port.Text)));
					threadReceive = new Thread(ThreadReceiveUdpCycle)
					{
						IsBackground = true
					};
					threadReceive.Start();
					IsStarted = true;
				}
				button_start.Enabled = false;
				button_close.Enabled = true;
				panel_main.Enabled = true;
				panel_tcp_udp.Enabled = false;
				MessageBox.Show(StringResources.Language.ConnectServerSuccess);
			}
			catch (Exception ex)
			{
				MessageBox.Show(StringResources.Language.NetEngineStart + Environment.NewLine + ex.Message);
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
			button_start.Enabled = true;
			button_close.Enabled = false;
			panel_main.Enabled = false;
			panel_tcp_udp.Enabled = true;
			lock (lockObject)
			{
				foreach (ClientSession socket3 in sockets)
				{
					if (socket3 != null)
					{
						Socket socket2 = socket3.Socket;
						if (socket2 != null)
						{
							socket2.Close();
						}
					}
				}
				sockets.Clear();
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
			checkBox_stop_show = new System.Windows.Forms.CheckBox();
			panel4 = new System.Windows.Forms.Panel();
			radioButton_append_crc16 = new System.Windows.Forms.RadioButton();
			radioButton_append_0d0a = new System.Windows.Forms.RadioButton();
			radioButton_append_none = new System.Windows.Forms.RadioButton();
			radioButton_append_0a = new System.Windows.Forms.RadioButton();
			radioButton_append_0d = new System.Windows.Forms.RadioButton();
			label_append = new System.Windows.Forms.Label();
			panel5 = new System.Windows.Forms.Panel();
			radioButton_ascii = new System.Windows.Forms.RadioButton();
			radioButton_binary = new System.Windows.Forms.RadioButton();
			label4 = new System.Windows.Forms.Label();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label1 = new System.Windows.Forms.Label();
			button5 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			label8 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			checkBox_show_time = new System.Windows.Forms.CheckBox();
			checkBox3 = new System.Windows.Forms.CheckBox();
			label7 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			textBox5 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			panel_tcp_udp = new System.Windows.Forms.Panel();
			radioButton_udp = new System.Windows.Forms.RadioButton();
			radioButton_tcp = new System.Windows.Forms.RadioButton();
			button_close = new System.Windows.Forms.Button();
			button_start = new System.Windows.Forms.Button();
			textBox_port = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel_main.SuspendLayout();
			panel4.SuspendLayout();
			panel5.SuspendLayout();
			panel1.SuspendLayout();
			panel_tcp_udp.SuspendLayout();
			SuspendLayout();
			panel_main.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel_main.Controls.Add(checkBox_stop_show);
			panel_main.Controls.Add(panel4);
			panel_main.Controls.Add(panel5);
			panel_main.Controls.Add(label4);
			panel_main.Controls.Add(comboBox1);
			panel_main.Controls.Add(label1);
			panel_main.Controls.Add(button5);
			panel_main.Controls.Add(button4);
			panel_main.Controls.Add(label8);
			panel_main.Controls.Add(textBox6);
			panel_main.Controls.Add(checkBox_show_time);
			panel_main.Controls.Add(checkBox3);
			panel_main.Controls.Add(label7);
			panel_main.Controls.Add(button3);
			panel_main.Controls.Add(textBox5);
			panel_main.Controls.Add(label6);
			panel_main.Location = new System.Drawing.Point(3, 82);
			panel_main.Name = "panel_main";
			panel_main.Size = new System.Drawing.Size(1016, 561);
			panel_main.TabIndex = 20;
			checkBox_stop_show.AutoSize = true;
			checkBox_stop_show.Location = new System.Drawing.Point(541, 6);
			checkBox_stop_show.Name = "checkBox_stop_show";
			checkBox_stop_show.Size = new System.Drawing.Size(75, 21);
			checkBox_stop_show.TabIndex = 34;
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
			panel4.Location = new System.Drawing.Point(447, 443);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(348, 28);
			panel4.TabIndex = 33;
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
			panel5.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			panel5.BackColor = System.Drawing.SystemColors.Control;
			panel5.Controls.Add(radioButton_ascii);
			panel5.Controls.Add(radioButton_binary);
			panel5.Location = new System.Drawing.Point(286, 443);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(155, 28);
			panel5.TabIndex = 32;
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
			label4.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label4.Location = new System.Drawing.Point(869, 537);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(119, 19);
			label4.TabIndex = 29;
			label4.Text = "Onlines: 0";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			comboBox1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(59, 446);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(145, 25);
			comboBox1.TabIndex = 27;
			label1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(5, 450);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 26;
			label1.Text = "指定Ip：";
			button5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button5.Location = new System.Drawing.Point(916, 3);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(91, 28);
			button5.TabIndex = 25;
			button5.Text = "清空";
			button5.UseVisualStyleBackColor = true;
			button4.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			button4.Location = new System.Drawing.Point(884, 443);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(120, 28);
			button4.TabIndex = 23;
			button4.Text = "efort msg test";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			label8.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(8, 538);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(116, 17);
			label8.TabIndex = 22;
			label8.Text = "已选择数据字节数：";
			textBox6.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox6.Location = new System.Drawing.Point(6, 33);
			textBox6.Multiline = true;
			textBox6.Name = "textBox6";
			textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox6.Size = new System.Drawing.Size(1001, 404);
			textBox6.TabIndex = 21;
			checkBox_show_time.AutoSize = true;
			checkBox_show_time.Checked = true;
			checkBox_show_time.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox_show_time.Location = new System.Drawing.Point(363, 6);
			checkBox_show_time.Name = "checkBox_show_time";
			checkBox_show_time.Size = new System.Drawing.Size(99, 21);
			checkBox_show_time.TabIndex = 20;
			checkBox_show_time.Text = "是否显示时间";
			checkBox_show_time.UseVisualStyleBackColor = true;
			checkBox3.AutoSize = true;
			checkBox3.Checked = true;
			checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox3.Location = new System.Drawing.Point(151, 6);
			checkBox3.Name = "checkBox3";
			checkBox3.Size = new System.Drawing.Size(123, 21);
			checkBox3.TabIndex = 19;
			checkBox3.Text = "是否显示发送数据";
			checkBox3.UseVisualStyleBackColor = true;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(8, 7);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(80, 17);
			label7.TabIndex = 18;
			label7.Text = "数据接收区：";
			button3.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			button3.Location = new System.Drawing.Point(939, 474);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(68, 60);
			button3.TabIndex = 17;
			button3.Text = "发送数据";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox5.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox5.Location = new System.Drawing.Point(8, 474);
			textBox5.Multiline = true;
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(925, 60);
			textBox5.TabIndex = 16;
			label6.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(210, 450);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(80, 17);
			label6.TabIndex = 1;
			label6.Text = "数据发送区：";
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(panel_tcp_udp);
			panel1.Controls.Add(button_close);
			panel1.Controls.Add(button_start);
			panel1.Controls.Add(textBox_port);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1016, 43);
			panel1.TabIndex = 14;
			panel_tcp_udp.Controls.Add(radioButton_udp);
			panel_tcp_udp.Controls.Add(radioButton_tcp);
			panel_tcp_udp.Location = new System.Drawing.Point(144, 6);
			panel_tcp_udp.Name = "panel_tcp_udp";
			panel_tcp_udp.Size = new System.Drawing.Size(148, 29);
			panel_tcp_udp.TabIndex = 6;
			radioButton_udp.AutoSize = true;
			radioButton_udp.Location = new System.Drawing.Point(73, 4);
			radioButton_udp.Name = "radioButton_udp";
			radioButton_udp.Size = new System.Drawing.Size(51, 21);
			radioButton_udp.TabIndex = 1;
			radioButton_udp.Text = "UDP";
			radioButton_udp.UseVisualStyleBackColor = true;
			radioButton_tcp.AutoSize = true;
			radioButton_tcp.Checked = true;
			radioButton_tcp.Location = new System.Drawing.Point(10, 4);
			radioButton_tcp.Name = "radioButton_tcp";
			radioButton_tcp.Size = new System.Drawing.Size(48, 21);
			radioButton_tcp.TabIndex = 0;
			radioButton_tcp.TabStop = true;
			radioButton_tcp.Text = "TCP";
			radioButton_tcp.UseVisualStyleBackColor = true;
			button_close.Enabled = false;
			button_close.Location = new System.Drawing.Point(399, 7);
			button_close.Name = "button_close";
			button_close.Size = new System.Drawing.Size(91, 28);
			button_close.TabIndex = 5;
			button_close.Text = "关闭服务";
			button_close.UseVisualStyleBackColor = true;
			button_close.Click += new System.EventHandler(button2_Click);
			button_start.Location = new System.Drawing.Point(302, 7);
			button_start.Name = "button_start";
			button_start.Size = new System.Drawing.Size(91, 28);
			button_start.TabIndex = 4;
			button_start.Text = "启动服务";
			button_start.UseVisualStyleBackColor = true;
			button_start.Click += new System.EventHandler(button1_Click);
			textBox_port.Location = new System.Drawing.Point(62, 9);
			textBox_port.Name = "textBox_port";
			textBox_port.Size = new System.Drawing.Size(76, 23);
			textBox_port.TabIndex = 3;
			textBox_port.Text = "502";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(8, 12);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(44, 17);
			label3.TabIndex = 2;
			label3.Text = "Port：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "TCP/UDP Server";
			userControlHead1.Size = new System.Drawing.Size(1023, 32);
			userControlHead1.TabIndex = 21;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1023, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel_main);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormTcpServer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "TCP/IP调试助手";
			base.Load += new System.EventHandler(FormTcpDebug_Load);
			panel_main.ResumeLayout(false);
			panel_main.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel_tcp_udp.ResumeLayout(false);
			panel_tcp_udp.PerformLayout();
			ResumeLayout(false);
		}
	}
}
