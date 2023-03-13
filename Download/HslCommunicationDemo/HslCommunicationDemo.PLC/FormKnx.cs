using HslCommunication.LogNet;
using HslCommunication.Profinet.Knx;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace HslCommunicationDemo.PLC
{
	public class FormKnx : HslFormContent
	{
		private KnxUdp kNX_Connection;

		private my_modbus_server my_server;

		private IContainer components = null;

		private GroupBox groupBox2;

		private TextBox data_box;

		private Label label8;

		private Button button7;

		private TextBox out_box;

		private Label label9;

		private Button Run_list_button;

		private Button Sotp_list_button;

		private GroupBox groupBox1;

		private TextBox addr;

		private Label label5;

		private Button button2;

		private Button button3;

		private TextBox data;

		private Label label6;

		private Label label7;

		private TextBox modbus_prot;

		private ListBox listBox1;

		private Label label3;

		private TextBox R_PROT;

		private Label label4;

		private TextBox R_IP;

		private Button button1;

		private UserControlHead userControlHead1;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private Button button4;

		public FormKnx()
		{
			kNX_Connection = new KnxUdp();
			InitializeComponent();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			try
			{
				IPEndPoint localEndpoint = new IPEndPoint(IPAddress.Any, 0);
				IPEndPoint rouEndpoint = new IPEndPoint(IPAddress.Parse(R_IP.Text), int.Parse(R_PROT.Text));
				kNX_Connection.LocalEndpoint = localEndpoint;
				kNX_Connection.RouEndpoint = rouEndpoint;
				kNX_Connection.ConnectKnx();
				Thread.Sleep(1000);
				if (kNX_Connection.IsConnect)
				{
					kNX_Connection.KnxCode.GetData_msg += KNX_CODE_GetData_msg;
					Thread thread = new Thread(KNX_KEEP_RUN);
					thread.IsBackground = true;
					thread.Start();
					button1.Enabled = false;
					my_server = new my_modbus_server(kNX_Connection);
					my_server.IsUseAccountCertificate = false;
					my_server.ServerStart(504);
					my_server.LogNet = new LogNetSingle("logs.txt");
					button2.Enabled = true;
					button3.Enabled = true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void KNX_CODE_GetData_msg(short addr, byte len, byte[] data)
		{
			if (!Run_list_button.Enabled)
			{
				listBox1.Invoke((Action)delegate
				{
					listBox1.Items.Add("地址：" + addr.ToString() + " 数据长度：" + len.ToString() + " 数据：" + data[0].ToString());
				});
			}
			my_server.Write(addr.ToString(), data[0]);
		}

		private void KNX_KEEP_RUN()
		{
			try
			{
				while (true)
				{
					kNX_Connection.KeepConnection();
					Thread.Sleep(80000);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("链接断开。。。 " + ex.Message);
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			KnxUdp knxUdp = kNX_Connection;
			if (knxUdp != null)
			{
				knxUdp.DisConnectKnx();
			}
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			try
			{
				string[] array = addr.Text.Split('\\');
				if (array.Length == 3)
				{
					int num = int.Parse(array[0]);
					int num2 = int.Parse(array[1]);
					int num3 = int.Parse(array[2]);
					if (num > 31 || num2 > 7 || num3 > 255 || num < 0 || num2 < 0 || num3 < 0)
					{
						MessageBox.Show("地址不合法");
					}
					else
					{
						num <<= 11;
						num2 <<= 8;
						int num4 = num | num2 | num3;
						short num5 = (short)num4;
						kNX_Connection.ReadKnxData(num5);
					}
				}
				else
				{
					MessageBox.Show("地址不合法");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("地址不合法  " + ex.Message);
			}
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			byte[] array = new byte[1];
			bool is_ok;
			if (data.Text == "1")
			{
				array[0] = 1;
				kNX_Connection.SetKnxData(kNX_Connection.KnxCode.Get_knx_addr(addr.Text, out is_ok), 1, array);
			}
			if (data.Text == "0")
			{
				array[0] = 0;
				kNX_Connection.SetKnxData(kNX_Connection.KnxCode.Get_knx_addr(addr.Text, out is_ok), 1, array);
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			try
			{
				string[] array = data_box.Text.Split('/');
				if (array.Length == 3)
				{
					int num = int.Parse(array[0]);
					int num2 = int.Parse(array[1]);
					int num3 = int.Parse(array[2]);
					if (num > 31 || num2 > 7 || num3 > 255 || num < 0 || num2 < 0 || num3 < 0)
					{
						MessageBox.Show("地址不合法");
					}
					else
					{
						num <<= 11;
						num2 <<= 8;
						int num4 = num | num2 | num3;
						short num5 = (short)num4;
						out_box.Text = (num5 + 1).ToString();
					}
				}
				else
				{
					MessageBox.Show("地址不合法");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("地址不合法  " + ex.Message);
			}
		}

		private void Sotp_list_button_Click(object sender, EventArgs e)
		{
			Sotp_list_button.Enabled = false;
			Run_list_button.Enabled = true;
		}

		private void Run_list_button_Click(object sender, EventArgs e)
		{
			Sotp_list_button.Enabled = true;
			Run_list_button.Enabled = false;
		}

		private void FormKnx_Load(object sender, EventArgs e)
		{
		}

		private void button4_Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
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
			groupBox2 = new System.Windows.Forms.GroupBox();
			data_box = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			button7 = new System.Windows.Forms.Button();
			out_box = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			Run_list_button = new System.Windows.Forms.Button();
			Sotp_list_button = new System.Windows.Forms.Button();
			groupBox1 = new System.Windows.Forms.GroupBox();
			addr = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			data = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			modbus_prot = new System.Windows.Forms.TextBox();
			listBox1 = new System.Windows.Forms.ListBox();
			label3 = new System.Windows.Forms.Label();
			R_PROT = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			R_IP = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			button4 = new System.Windows.Forms.Button();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			statusStrip1.SuspendLayout();
			SuspendLayout();
			groupBox2.Controls.Add(data_box);
			groupBox2.Controls.Add(label8);
			groupBox2.Controls.Add(button7);
			groupBox2.Controls.Add(out_box);
			groupBox2.Controls.Add(label9);
			groupBox2.Location = new System.Drawing.Point(485, 228);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(250, 114);
			groupBox2.TabIndex = 50;
			groupBox2.TabStop = false;
			groupBox2.Text = "地址转换器";
			data_box.Location = new System.Drawing.Point(77, 27);
			data_box.Name = "data_box";
			data_box.Size = new System.Drawing.Size(65, 23);
			data_box.TabIndex = 28;
			data_box.Text = "1/1/1";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(6, 30);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(44, 17);
			label8.TabIndex = 29;
			label8.Text = "组地址";
			button7.Location = new System.Drawing.Point(159, 27);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(75, 23);
			button7.TabIndex = 31;
			button7.Text = "地址转换";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			out_box.Location = new System.Drawing.Point(77, 70);
			out_box.Name = "out_box";
			out_box.Size = new System.Drawing.Size(65, 23);
			out_box.TabIndex = 32;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(6, 75);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(80, 17);
			label9.TabIndex = 33;
			label9.Text = "modbus地址";
			Run_list_button.Enabled = false;
			Run_list_button.Location = new System.Drawing.Point(577, 189);
			Run_list_button.Name = "Run_list_button";
			Run_list_button.Size = new System.Drawing.Size(89, 23);
			Run_list_button.TabIndex = 51;
			Run_list_button.Text = "继续列表显示";
			Run_list_button.UseVisualStyleBackColor = true;
			Run_list_button.Click += new System.EventHandler(Run_list_button_Click);
			Sotp_list_button.Location = new System.Drawing.Point(482, 189);
			Sotp_list_button.Name = "Sotp_list_button";
			Sotp_list_button.Size = new System.Drawing.Size(89, 23);
			Sotp_list_button.TabIndex = 46;
			Sotp_list_button.Text = "停止列表显示";
			Sotp_list_button.UseVisualStyleBackColor = true;
			Sotp_list_button.Click += new System.EventHandler(Sotp_list_button_Click);
			groupBox1.Controls.Add(addr);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(button2);
			groupBox1.Controls.Add(button3);
			groupBox1.Controls.Add(data);
			groupBox1.Controls.Add(label6);
			groupBox1.Location = new System.Drawing.Point(485, 69);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(250, 114);
			groupBox1.TabIndex = 49;
			groupBox1.TabStop = false;
			groupBox1.Text = "测试工具";
			addr.Location = new System.Drawing.Point(53, 27);
			addr.Name = "addr";
			addr.Size = new System.Drawing.Size(65, 23);
			addr.TabIndex = 28;
			addr.Text = "1\\1\\1";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(6, 32);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(44, 17);
			label5.TabIndex = 29;
			label5.Text = "组地址";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(159, 68);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(75, 23);
			button2.TabIndex = 30;
			button2.Text = "bool写入";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(Button2_Click);
			button3.Enabled = false;
			button3.Location = new System.Drawing.Point(159, 27);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(75, 23);
			button3.TabIndex = 31;
			button3.Text = "读取";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(Button3_Click);
			data.Location = new System.Drawing.Point(53, 70);
			data.Name = "data";
			data.Size = new System.Drawing.Size(65, 23);
			data.TabIndex = 32;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(6, 75);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(32, 17);
			label6.TabIndex = 33;
			label6.Text = "数据";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(25, 101);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(80, 17);
			label7.TabIndex = 48;
			label7.Text = "modbus端口";
			modbus_prot.Location = new System.Drawing.Point(111, 98);
			modbus_prot.Name = "modbus_prot";
			modbus_prot.Size = new System.Drawing.Size(45, 23);
			modbus_prot.TabIndex = 47;
			modbus_prot.Text = "504";
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 17;
			listBox1.Location = new System.Drawing.Point(27, 131);
			listBox1.Name = "listBox1";
			listBox1.Size = new System.Drawing.Size(416, 242);
			listBox1.TabIndex = 45;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(213, 74);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 44;
			label3.Text = "设备端口";
			R_PROT.Location = new System.Drawing.Point(280, 69);
			R_PROT.Name = "R_PROT";
			R_PROT.Size = new System.Drawing.Size(45, 23);
			R_PROT.TabIndex = 43;
			R_PROT.Text = "3671";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(25, 74);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(43, 17);
			label4.TabIndex = 42;
			label4.Text = "设备IP";
			R_IP.Location = new System.Drawing.Point(92, 69);
			R_IP.Name = "R_IP";
			R_IP.Size = new System.Drawing.Size(100, 23);
			R_IP.TabIndex = 41;
			R_IP.Text = "192.168.10.1";
			button1.Location = new System.Drawing.Point(353, 69);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(105, 23);
			button1.TabIndex = 40;
			button1.Text = "启动系统";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1_Click);
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Knx";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 52;
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1]
			{
				toolStripStatusLabel1
			});
			statusStrip1.Location = new System.Drawing.Point(0, 623);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(1004, 22);
			statusStrip1.TabIndex = 53;
			statusStrip1.Text = "statusStrip1";
			toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			toolStripStatusLabel1.Size = new System.Drawing.Size(323, 17);
			toolStripStatusLabel1.Text = "感谢上海网友（杨俊锋 QQ：136044669）提供的技术支持";
			button4.Location = new System.Drawing.Point(672, 189);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(63, 23);
			button4.TabIndex = 54;
			button4.Text = "清空";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(button4);
			base.Controls.Add(statusStrip1);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(groupBox2);
			base.Controls.Add(Run_list_button);
			base.Controls.Add(Sotp_list_button);
			base.Controls.Add(groupBox1);
			base.Controls.Add(label7);
			base.Controls.Add(modbus_prot);
			base.Controls.Add(listBox1);
			base.Controls.Add(label3);
			base.Controls.Add(R_PROT);
			base.Controls.Add(label4);
			base.Controls.Add(R_IP);
			base.Controls.Add(button1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormKnx";
			Text = "FormKnx";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
			base.Load += new System.EventHandler(FormKnx_Load);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
