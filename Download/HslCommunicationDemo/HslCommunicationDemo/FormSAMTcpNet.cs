using HslCommunication;
using HslCommunication.Profinet.IDCard;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormSAMTcpNet : HslFormContent
	{
		private SAMTcpNet sAMTcpNet = null;

		private int sleep = 1000;

		private bool threadEnable = true;

		private IContainer components = null;

		private Panel panel1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private GroupBox groupBox1;

		private Button button_sam5;

		private Button button_sam4;

		private Button button_sam3;

		private Button button_sam2;

		private Button button_sam1;

		private TextBox textBox4;

		private Label label7;

		private Label label6;

		private UserControlHead userControlHead1;

		private GroupBox groupBox3;

		private PictureBox pictureBox1;

		private TextBox textBox10;

		private Label label13;

		private Button button_sam_start;

		private TextBox textBox9;

		private Label label11;

		private PictureBox pictureBox2;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private Label label1;

		private Button button3;

		public FormSAMTcpNet()
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
				SAMTcpNet obj = sAMTcpNet;
				if (obj != null)
				{
					obj.ConnectClose();
				}
				sAMTcpNet = new SAMTcpNet(textBox1.Text, result);
				try
				{
					OperateResult operateResult = sAMTcpNet.ConnectServer();
					if (operateResult.IsSuccess)
					{
						MessageBox.Show(StringResources.Language.ConnectedSuccess);
						button2.Enabled = true;
						button1.Enabled = false;
						panel2.Enabled = true;
					}
					else
					{
						MessageBox.Show(StringResources.Language.ConnectedFailed);
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
			sAMTcpNet.ConnectClose();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button_sam1_Click(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = sAMTcpNet.ReadSafeModuleNumber();
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Read Failed:" + operateResult.Message);
			}
			else
			{
				textBox4.Text = "Result:" + operateResult.Content;
			}
		}

		private void button_sam2_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = sAMTcpNet.CheckSafeModuleStatus();
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Read Failed:" + operateResult.Message);
			}
			else
			{
				textBox4.Text = "检查安全模块状态成功";
			}
		}

		private void button_sam3_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = sAMTcpNet.SearchCard();
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Read Failed:" + operateResult.Message);
			}
			else
			{
				textBox4.Text = "寻找卡片成功";
			}
		}

		private void button_sam4_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = sAMTcpNet.SelectCard();
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Read Failed:" + operateResult.Message);
			}
			else
			{
				textBox4.Text = "选择卡片成功";
			}
		}

		private void button_sam5_Click(object sender, EventArgs e)
		{
			OperateResult<IdentityCard> operateResult = sAMTcpNet.ReadCard();
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("Read Failed:" + operateResult.Message);
			}
			else
			{
				textBox4.Text = operateResult.Content.ToString();
			}
		}

		private void button_sam_start_Click(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox9.Text, out result))
			{
				MessageBox.Show("当前的数据错误，必须整数！");
			}
			else
			{
				sleep = result;
				threadEnable = true;
				Thread thread = new Thread(ThreadBackgroundReadCard);
				thread.IsBackground = true;
				thread.Start();
				button_sam_start.Enabled = false;
				button3.Enabled = true;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			threadEnable = false;
			button_sam_start.Enabled = true;
			button3.Enabled = false;
		}

		private void ThreadBackgroundReadCard()
		{
			while (threadEnable)
			{
				Thread.Sleep(sleep);
				OperateResult operateResult = sAMTcpNet.SearchCard();
				if (operateResult.IsSuccess)
				{
					Invoke((Action)delegate
					{
						textBox10.Text = "";
						pictureBox1.Image = null;
					});
					Thread.Sleep(100);
					if (sAMTcpNet.SelectCard().IsSuccess)
					{
						OperateResult<IdentityCard> read = sAMTcpNet.ReadCard();
						if (read.IsSuccess)
						{
							Invoke((Action<IdentityCard>)delegate
							{
								textBox10.Text = read.Content.ToString();
							}, read.Content);
						}
						else
						{
							Invoke((Action)delegate
							{
								textBox10.Text = "读卡失败：" + read.Message;
							});
						}
					}
				}
			}
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
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			panel2 = new System.Windows.Forms.Panel();
			groupBox3 = new System.Windows.Forms.GroupBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			textBox10 = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			button_sam_start = new System.Windows.Forms.Button();
			textBox9 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			button_sam5 = new System.Windows.Forms.Button();
			button_sam4 = new System.Windows.Forms.Button();
			button_sam3 = new System.Windows.Forms.Button();
			button_sam2 = new System.Windows.Forms.Button();
			button_sam1 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			button3 = new System.Windows.Forms.Button();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Location = new System.Drawing.Point(14, 40);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(978, 46);
			panel1.TabIndex = 0;
			textBox2.Location = new System.Drawing.Point(250, 9);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(61, 23);
			textBox2.TabIndex = 9;
			textBox2.Text = "801";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(196, 12);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 8;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(74, 9);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(106, 23);
			textBox1.TabIndex = 7;
			textBox1.Text = "192.168.0.100";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(20, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 6;
			label1.Text = "Ip地址：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(493, 6);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(381, 6);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(groupBox3);
			panel2.Controls.Add(groupBox1);
			panel2.Location = new System.Drawing.Point(14, 95);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(978, 537);
			panel2.TabIndex = 1;
			groupBox3.Controls.Add(button3);
			groupBox3.Controls.Add(pictureBox1);
			groupBox3.Controls.Add(textBox10);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(button_sam_start);
			groupBox3.Controls.Add(textBox9);
			groupBox3.Controls.Add(label11);
			groupBox3.Location = new System.Drawing.Point(11, 243);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(955, 278);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "定时读取测试";
			pictureBox1.Location = new System.Drawing.Point(767, 60);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(170, 201);
			pictureBox1.TabIndex = 11;
			pictureBox1.TabStop = false;
			textBox10.Location = new System.Drawing.Point(63, 60);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(684, 203);
			textBox10.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 62);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "结果：";
			button_sam_start.Location = new System.Drawing.Point(181, 24);
			button_sam_start.Name = "button_sam_start";
			button_sam_start.Size = new System.Drawing.Size(82, 28);
			button_sam_start.TabIndex = 8;
			button_sam_start.Text = "启动读取";
			button_sam_start.UseVisualStyleBackColor = true;
			button_sam_start.Click += new System.EventHandler(button_sam_start_Click);
			textBox9.Location = new System.Drawing.Point(63, 27);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(102, 23);
			textBox9.TabIndex = 7;
			textBox9.Text = "1000";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(9, 30);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 4;
			label11.Text = "间隔：";
			groupBox1.Controls.Add(pictureBox2);
			groupBox1.Controls.Add(button_sam5);
			groupBox1.Controls.Add(button_sam4);
			groupBox1.Controls.Add(button_sam3);
			groupBox1.Controls.Add(button_sam2);
			groupBox1.Controls.Add(button_sam1);
			groupBox1.Controls.Add(textBox4);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(label6);
			groupBox1.Location = new System.Drawing.Point(11, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(955, 234);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "单数据读取测试";
			pictureBox2.Location = new System.Drawing.Point(767, 56);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(138, 162);
			pictureBox2.TabIndex = 13;
			pictureBox2.TabStop = false;
			button_sam5.Location = new System.Drawing.Point(462, 24);
			button_sam5.Name = "button_sam5";
			button_sam5.Size = new System.Drawing.Size(92, 28);
			button_sam5.TabIndex = 12;
			button_sam5.Text = "读取身份证";
			button_sam5.UseVisualStyleBackColor = true;
			button_sam5.Click += new System.EventHandler(button_sam5_Click);
			button_sam4.Location = new System.Drawing.Point(370, 24);
			button_sam4.Name = "button_sam4";
			button_sam4.Size = new System.Drawing.Size(82, 28);
			button_sam4.TabIndex = 11;
			button_sam4.Text = "选择卡片";
			button_sam4.UseVisualStyleBackColor = true;
			button_sam4.Click += new System.EventHandler(button_sam4_Click);
			button_sam3.Location = new System.Drawing.Point(282, 24);
			button_sam3.Name = "button_sam3";
			button_sam3.Size = new System.Drawing.Size(82, 28);
			button_sam3.TabIndex = 10;
			button_sam3.Text = "寻找卡片";
			button_sam3.UseVisualStyleBackColor = true;
			button_sam3.Click += new System.EventHandler(button_sam3_Click);
			button_sam2.Location = new System.Drawing.Point(164, 24);
			button_sam2.Name = "button_sam2";
			button_sam2.Size = new System.Drawing.Size(112, 28);
			button_sam2.TabIndex = 9;
			button_sam2.Text = "检测安全模块状态";
			button_sam2.UseVisualStyleBackColor = true;
			button_sam2.Click += new System.EventHandler(button_sam2_Click);
			button_sam1.Location = new System.Drawing.Point(63, 24);
			button_sam1.Name = "button_sam1";
			button_sam1.Size = new System.Drawing.Size(95, 28);
			button_sam1.TabIndex = 8;
			button_sam1.Text = "安全模块号";
			button_sam1.UseVisualStyleBackColor = true;
			button_sam1.Click += new System.EventHandler(button_sam1_Click);
			textBox4.Location = new System.Drawing.Point(63, 56);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox4.Size = new System.Drawing.Size(684, 164);
			textBox4.TabIndex = 5;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(9, 58);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(44, 17);
			label7.TabIndex = 4;
			label7.Text = "结果：";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(9, 30);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(44, 17);
			label6.TabIndex = 2;
			label6.Text = "地址：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "SAM Over Tcp";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 2;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			button3.Location = new System.Drawing.Point(282, 24);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(82, 28);
			button3.TabIndex = 12;
			button3.Text = "停止读取";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormSAMTcpNet";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "身份证阅读器的SAM协议Demo";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
		}
	}
}