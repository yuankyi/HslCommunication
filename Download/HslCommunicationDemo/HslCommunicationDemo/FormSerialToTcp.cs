using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormSerialToTcp : HslFormContent
	{
		private SerialPort SP_ReadData = null;

		private Socket socketCore = null;

		private Socket client = null;

		private byte[] buffer = new byte[2048];

		private IContainer components = null;

		private Panel panel1;

		private ComboBox comboBox1;

		private Label label24;

		private TextBox textBox17;

		private Label label23;

		private TextBox textBox16;

		private Label label22;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private Label label1;

		private Panel panel2;

		private TextBox textBox6;

		private CheckBox checkBox3;

		private Label label7;

		private ComboBox comboBox2;

		private UserControlHead userControlHead1;

		private CheckBox checkBox5;

		private TextBox textBox1;

		private Label label2;

		private CheckBox checkBox1;

		public FormSerialToTcp()
		{
			InitializeComponent();
		}

		private void FormSerialDebug_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			comboBox1.SelectedIndex = 0;
			comboBox2.DataSource = SerialPort.GetPortNames();
			try
			{
				comboBox2.SelectedIndex = 0;
			}
			catch
			{
				comboBox2.Text = "COM3";
			}
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language == 1)
			{
				Text = "串口调试助手";
				label1.Text = "Com口：";
				label3.Text = "波特率:";
				label22.Text = "数据位:";
				label23.Text = "停止位:";
				label24.Text = "奇偶：";
				button1.Text = "打开串口";
				button2.Text = "关闭串口";
				label7.Text = "数据接收区：";
				checkBox3.Text = "是否显示发送数据";
				comboBox1.DataSource = new string[3]
				{
					"无",
					"奇",
					"偶"
				};
			}
			else
			{
				Text = "Serial Debug Tools";
				label1.Text = "Com:";
				label3.Text = "Baud rate:";
				label22.Text = "Data bits:";
				label23.Text = "Stop bits:";
				label24.Text = "parity:";
				button1.Text = "Open";
				button2.Text = "Close";
				label7.Text = "Data receiving Area:";
				checkBox3.Text = "Whether to display send data";
				comboBox1.DataSource = new string[3]
				{
					"None",
					"Odd",
					"Even"
				};
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			int result2;
			int result3;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show((Program.Language == 1) ? "波特率输入错误！" : "Baud rate input error");
			}
			else if (!int.TryParse(textBox16.Text, out result2))
			{
				MessageBox.Show((Program.Language == 1) ? "数据位输入错误！" : "Data bits input error");
			}
			else if (!int.TryParse(textBox17.Text, out result3))
			{
				MessageBox.Show((Program.Language == 1) ? "停止位输入错误！" : "Stop bits input error");
			}
			else
			{
				SP_ReadData = new SerialPort();
				SP_ReadData.PortName = comboBox2.Text;
				SP_ReadData.BaudRate = result;
				SP_ReadData.DataBits = result2;
				SerialPort sP_ReadData = SP_ReadData;
				int stopBits;
				switch (result3)
				{
				default:
					stopBits = 2;
					break;
				case 1:
					stopBits = 1;
					break;
				case 0:
					stopBits = 0;
					break;
				}
				sP_ReadData.StopBits = (StopBits)stopBits;
				SP_ReadData.Parity = ((comboBox1.SelectedIndex != 0) ? ((comboBox1.SelectedIndex == 1) ? Parity.Odd : Parity.Even) : Parity.None);
				SP_ReadData.RtsEnable = checkBox5.Checked;
				try
				{
					SP_ReadData.DataReceived += SP_ReadData_DataReceived;
					SP_ReadData.Open();
					button1.Enabled = false;
					button2.Enabled = true;
					panel2.Enabled = true;
				}
				catch (Exception ex)
				{
					SoftBasic.ShowExceptionMessage(ex);
				}
				try
				{
					socketCore = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					socketCore.Bind(new IPEndPoint(0L, int.Parse(textBox1.Text)));
					socketCore.Listen(500);
					socketCore.BeginAccept(AsyncAcceptCallback, socketCore);
					button1.Enabled = false;
					button2.Enabled = true;
					panel2.Enabled = true;
					MessageBox.Show(StringResources.Language.ConnectServerSuccess);
				}
				catch (Exception ex2)
				{
					MessageBox.Show(StringResources.Language.ConnectedFailed + Environment.NewLine + ex2.Message);
				}
			}
		}

		protected void AsyncAcceptCallback(IAsyncResult iar)
		{
			Socket socket = iar.AsyncState as Socket;
			if (socket != null)
			{
				ClientSession session = new ClientSession();
				try
				{
					client = socket.EndAccept(iar);
					session.Socket = client;
					session.EndPoint = (IPEndPoint)client.RemoteEndPoint;
					client.BeginReceive(buffer, 0, 2048, SocketFlags.None, ReceiveCallBack, session);
					Invoke((Action)delegate
					{
						DemoUtils.AppendTextBox(textBox6, session.EndPoint.ToString(), "Client Online");
					});
				}
				catch (ObjectDisposedException)
				{
					client = null;
					return;
				}
				catch
				{
					client = null;
					Socket socket2 = client;
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
			ClientSession client2 = asyncState as ClientSession;
			if (client2 != null)
			{
				try
				{
					int num = client2.Socket.EndReceive(ar);
					if (num == 0)
					{
						Invoke((Action)delegate
						{
							client2.Socket.Close();
							DemoUtils.AppendTextBox(textBox6, client2.EndPoint.ToString(), "Client Offline");
						});
						ClientSession client = null;
					}
					else
					{
						client2.Socket.BeginReceive(buffer, 0, 2048, SocketFlags.None, ReceiveCallBack, client2);
						byte[] data = new byte[num];
						Array.Copy(buffer, 0, data, 0, num);
						SP_ReadData.Write(data, 0, data.Length);
						Invoke((Action)delegate
						{
							string empty = string.Empty;
							DemoUtils.AppendTextBox(message: (!checkBox1.Checked) ? SoftBasic.GetAsciiStringRender(data) : SoftBasic.ByteToHexString(data, ' '), textBox: textBox6, key: "Tcp-Serial");
						});
					}
				}
				catch
				{
					Invoke((Action)delegate
					{
						this.client = null;
						DemoUtils.AppendTextBox(textBox6, "Client Offline", (Program.Language == 1) ? "服务器断开连接。" : "DisConnect from remote");
					});
				}
			}
		}

		private void SP_ReadData_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			List<byte> buffer = new List<byte>();
			byte[] array = new byte[1024];
			while (true)
			{
				Thread.Sleep(20);
				if (SP_ReadData.BytesToRead < 1)
				{
					break;
				}
				int num = SP_ReadData.Read(array, 0, Math.Min(SP_ReadData.BytesToRead, array.Length));
				byte[] array2 = new byte[num];
				Array.Copy(array, 0, array2, 0, num);
				buffer.AddRange(array2);
			}
			if (buffer.Count != 0)
			{
				try
				{
					byte[] array3 = buffer.ToArray();
					client.Send(array3, 0, array3.Length, SocketFlags.None);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Client Send Failed! " + ex.Message);
					return;
				}
				Invoke((Action)delegate
				{
					string empty = string.Empty;
					DemoUtils.AppendTextBox(message: (!checkBox1.Checked) ? SoftBasic.GetAsciiStringRender(buffer.ToArray()) : SoftBasic.ByteToHexString(buffer.ToArray(), ' '), textBox: textBox6, key: "Serial-Tcp");
				});
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				SP_ReadData.Close();
				button2.Enabled = false;
				button1.Enabled = true;
				panel2.Enabled = false;
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage(ex);
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
			textBox1 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			checkBox5 = new System.Windows.Forms.CheckBox();
			comboBox2 = new System.Windows.Forms.ComboBox();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label24 = new System.Windows.Forms.Label();
			textBox17 = new System.Windows.Forms.TextBox();
			label23 = new System.Windows.Forms.Label();
			textBox16 = new System.Windows.Forms.TextBox();
			label22 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			checkBox1 = new System.Windows.Forms.CheckBox();
			textBox6 = new System.Windows.Forms.TextBox();
			checkBox3 = new System.Windows.Forms.CheckBox();
			label7 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(checkBox5);
			panel1.Controls.Add(comboBox2);
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(label24);
			panel1.Controls.Add(textBox17);
			panel1.Controls.Add(label23);
			panel1.Controls.Add(textBox16);
			panel1.Controls.Add(label22);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(4, 37);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(995, 74);
			panel1.TabIndex = 7;
			textBox1.Location = new System.Drawing.Point(81, 39);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(118, 23);
			textBox1.TabIndex = 19;
			textBox1.Text = "502";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(10, 42);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(69, 17);
			label2.TabIndex = 18;
			label2.Text = "Tcp Port：";
			checkBox5.AutoSize = true;
			checkBox5.Location = new System.Drawing.Point(578, 12);
			checkBox5.Name = "checkBox5";
			checkBox5.Size = new System.Drawing.Size(84, 21);
			checkBox5.TabIndex = 17;
			checkBox5.Text = "RtsEnable";
			checkBox5.UseVisualStyleBackColor = true;
			comboBox2.FormattingEnabled = true;
			comboBox2.Location = new System.Drawing.Point(62, 7);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new System.Drawing.Size(84, 25);
			comboBox2.TabIndex = 16;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[3]
			{
				"无",
				"奇",
				"偶"
			});
			comboBox1.Location = new System.Drawing.Point(503, 9);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(59, 25);
			comboBox1.TabIndex = 15;
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(460, 12);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(44, 17);
			label24.TabIndex = 14;
			label24.Text = "奇偶：";
			textBox17.Location = new System.Drawing.Point(430, 9);
			textBox17.Name = "textBox17";
			textBox17.Size = new System.Drawing.Size(23, 23);
			textBox17.TabIndex = 13;
			textBox17.Text = "1";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(371, 12);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(56, 17);
			label23.TabIndex = 12;
			label23.Text = "停止位：";
			textBox16.Location = new System.Drawing.Point(334, 9);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(24, 23);
			textBox16.TabIndex = 11;
			textBox16.Text = "8";
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(272, 12);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(56, 17);
			label22.TabIndex = 10;
			label22.Text = "数据位：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(331, 37);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭转换";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(219, 37);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "打开转换";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(219, 9);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(47, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "9600";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(152, 12);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "波特率：";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(59, 17);
			label1.TabIndex = 0;
			label1.Text = "Com口：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(checkBox1);
			panel2.Controls.Add(textBox6);
			panel2.Controls.Add(checkBox3);
			panel2.Controls.Add(label7);
			panel2.Location = new System.Drawing.Point(4, 116);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(995, 523);
			panel2.TabIndex = 13;
			checkBox1.AutoSize = true;
			checkBox1.Checked = true;
			checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox1.Location = new System.Drawing.Point(334, 3);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(135, 21);
			checkBox1.TabIndex = 22;
			checkBox1.Text = "是否使用二进制通信";
			checkBox1.UseVisualStyleBackColor = true;
			textBox6.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox6.Location = new System.Drawing.Point(11, 30);
			textBox6.Multiline = true;
			textBox6.Name = "textBox6";
			textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox6.Size = new System.Drawing.Size(976, 486);
			textBox6.TabIndex = 21;
			checkBox3.AutoSize = true;
			checkBox3.Checked = true;
			checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox3.Location = new System.Drawing.Point(146, 3);
			checkBox3.Name = "checkBox3";
			checkBox3.Size = new System.Drawing.Size(123, 21);
			checkBox3.TabIndex = 19;
			checkBox3.Text = "是否显示发送数据";
			checkBox3.UseVisualStyleBackColor = true;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(8, 4);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(80, 17);
			label7.TabIndex = 18;
			label7.Text = "数据接收区：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/8974215.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "serial";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 14;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormSerialToTcp";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "串口转TCP调试工具";
			base.Load += new System.EventHandler(FormSerialDebug_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
