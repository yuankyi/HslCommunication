using HslCommunication;
using HslCommunication.Core.Net;
using HslCommunication.LogNet;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HslCommunicationDemo.DemoControl
{
	public class UserControlReadWriteServer : UserControl
	{
		private Timer timerSecond;

		private NetworkDataServerBase dataServerBase;

		private Random random = new Random();

		private string timerAddress = string.Empty;

		private long timerValue = 0L;

		private Timer timerWrite = null;

		private bool timeWriteEnable = false;

		private IContainer components = null;

		private UserControlReadWriteOp userControlReadWriteOp1;

		private Button button10;

		private Label label15;

		private Button button9;

		private Label label16;

		private Button button8;

		private CheckBox checkBox1;

		private TextBox textBox1;

		private Button button1;

		public UserControlReadWriteServer()
		{
			InitializeComponent();
		}

		public void SetReadWriteServer(NetworkDataServerBase dataServerBase, string address, int strLength = 10)
		{
			this.dataServerBase = dataServerBase;
			this.dataServerBase.LogNet = new LogNetSingle("");
			this.dataServerBase.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
			userControlReadWriteOp1.SetReadWriteNet(dataServerBase, address, false, strLength);
			Timer timer = timerSecond;
			if (timer != null)
			{
				timer.Dispose();
			}
			timerSecond = new Timer();
			timerSecond.Interval = 1000;
			timerSecond.Tick += TimerSecond_Tick;
			timerSecond.Start();
		}

		private void TimerSecond_Tick(object sender, EventArgs e)
		{
			label15.Text = dataServerBase.OnlineCount.ToString();
		}

		private void LogNet_BeforeSaveToFile(object sender, HslEventArgs e)
		{
			if (checkBox1.Checked)
			{
				try
				{
					if (base.InvokeRequired)
					{
						Invoke(new Action<object, HslEventArgs>(LogNet_BeforeSaveToFile), sender, e);
					}
					else
					{
						if (textBox1.TextLength > 1000000)
						{
							textBox1.Clear();
						}
						textBox1.AppendText(e.HslMessage.ToString() + Environment.NewLine);
					}
				}
				catch
				{
				}
			}
		}

		private void UserControlReadWriteServer_Load(object sender, EventArgs e)
		{
			if (Program.Language == 2)
			{
				button8.Text = "Load";
				button9.Text = "Save";
				button10.Text = "Timed writing";
				checkBox1.Text = "Display log data?";
				label16.Text = "Client-Online:";
				button1.Text = "Connecting Alien client";
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			if (dataServerBase != null)
			{
				if (File.Exists("123.txt"))
				{
					dataServerBase.LoadDataPool("123.txt");
					MessageBox.Show("Load data finish");
				}
				else
				{
					MessageBox.Show("File is not exist！");
				}
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			if (dataServerBase != null)
			{
				dataServerBase.SaveDataPool("123.txt");
				MessageBox.Show("Save file finish: 123.txt");
			}
		}

		private void button10_Click(object sender, EventArgs e)
		{
			if (timeWriteEnable)
			{
				timeWriteEnable = false;
				Timer timer = timerWrite;
				if (timer != null)
				{
					timer.Dispose();
				}
				button10.Text = ((Program.Language == 2) ? "Timed writing" : "定时写");
			}
			else
			{
				timeWriteEnable = true;
				timerWrite = new Timer();
				timerWrite.Interval = 300;
				timerWrite.Tick += TimerWrite_Tick;
				timerWrite.Start();
				timerAddress = userControlReadWriteOp1.GetWriteAddress();
				button10.Text = ((Program.Language == 2) ? "Stop Timer" : "停止写入");
			}
		}

		private void TimerWrite_Tick(object sender, EventArgs e)
		{
			ushort value = (ushort)(Math.Sin(6.2831853071795862 * (double)timerValue / 100.0) * 100.0 + 100.0);
			dataServerBase.Write(timerAddress, value);
			timerValue++;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (FormInputAlien formInputAlien = new FormInputAlien())
			{
				if (formInputAlien.ShowDialog() == DialogResult.OK)
				{
					OperateResult operateResult = dataServerBase.ConnectHslAlientClient(formInputAlien.IpAddress, formInputAlien.Port, formInputAlien.DTU, formInputAlien.Pwd);
					if (operateResult.IsSuccess)
					{
						MessageBox.Show(StringResources.Language.ConnectedSuccess);
					}
					else
					{
						MessageBox.Show(StringResources.Language.ConnectedFailed + operateResult.Message);
					}
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
			userControlReadWriteOp1 = new HslCommunicationDemo.DemoControl.UserControlReadWriteOp();
			button10 = new System.Windows.Forms.Button();
			label15 = new System.Windows.Forms.Label();
			button9 = new System.Windows.Forms.Button();
			label16 = new System.Windows.Forms.Label();
			button8 = new System.Windows.Forms.Button();
			checkBox1 = new System.Windows.Forms.CheckBox();
			textBox1 = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			SuspendLayout();
			userControlReadWriteOp1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			userControlReadWriteOp1.Location = new System.Drawing.Point(2, 1);
			userControlReadWriteOp1.Name = "userControlReadWriteOp1";
			userControlReadWriteOp1.Size = new System.Drawing.Size(956, 240);
			userControlReadWriteOp1.TabIndex = 0;
			button10.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button10.Location = new System.Drawing.Point(858, 238);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(100, 28);
			button10.TabIndex = 29;
			button10.Text = "定时写";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(button10_Click);
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("微软雅黑", 21f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label15.Location = new System.Drawing.Point(406, 235);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(31, 36);
			label15.TabIndex = 26;
			label15.Text = "0";
			button9.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button9.Location = new System.Drawing.Point(792, 238);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(60, 28);
			button9.TabIndex = 28;
			button9.Text = "存储";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font("微软雅黑", 21f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label16.Location = new System.Drawing.Point(217, 234);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(183, 36);
			label16.TabIndex = 25;
			label16.Text = "在线客户端：";
			button8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button8.Location = new System.Drawing.Point(725, 238);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(60, 28);
			button8.TabIndex = 27;
			button8.Text = "加载";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			checkBox1.AutoSize = true;
			checkBox1.Checked = true;
			checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox1.Location = new System.Drawing.Point(3, 245);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(123, 21);
			checkBox1.TabIndex = 24;
			checkBox1.Text = "显示运行日志数据";
			checkBox1.UseVisualStyleBackColor = true;
			textBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox1.Location = new System.Drawing.Point(1, 272);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox1.Size = new System.Drawing.Size(957, 231);
			textBox1.TabIndex = 23;
			button1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button1.Location = new System.Drawing.Point(611, 238);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(108, 28);
			button1.TabIndex = 30;
			button1.Text = "连接异形服务器";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(button1);
			base.Controls.Add(button10);
			base.Controls.Add(label15);
			base.Controls.Add(button9);
			base.Controls.Add(button8);
			base.Controls.Add(checkBox1);
			base.Controls.Add(textBox1);
			base.Controls.Add(userControlReadWriteOp1);
			base.Controls.Add(label16);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "UserControlReadWriteServer";
			base.Size = new System.Drawing.Size(960, 505);
			base.Load += new System.EventHandler(UserControlReadWriteServer_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
