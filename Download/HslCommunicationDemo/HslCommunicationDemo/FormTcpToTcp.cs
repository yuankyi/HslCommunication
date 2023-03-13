using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Enthernet;
using HslCommunication.LogNet;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormTcpToTcp : HslFormContent
	{
		private TcpForward tcpForward;

		private Timer timer;

		private IContainer components = null;

		private Panel panel1;

		private Button button2;

		private Button button1;

		private Panel panel2;

		private TextBox textBox6;

		private Label label7;

		private UserControlHead userControlHead1;

		private TextBox textBox1;

		private Label label2;

		private CheckBox checkBox1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox3;

		private Label label1;

		private ListBox listBox1;

		public FormTcpToTcp()
		{
			InitializeComponent();
		}

		private void FormSerialDebug_Load(object sender, EventArgs e)
		{
			Language(Program.Language);
			timer = new Timer();
			timer.Interval = 1000;
			timer.Tick += Timer_Tick;
			timer.Start();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if (tcpForward != null)
			{
				listBox1.DataSource = tcpForward.GetSessionInfos();
			}
		}

		private void Language(int language)
		{
			if (language == 1)
			{
				Text = "网口转网口调试助手";
				label7.Text = "数据接收区：";
			}
			else
			{
				Text = "TCP TO TCP Debug Tools";
				label7.Text = "Data receiving Area:";
				checkBox1.Text = "use binary format to show";
				button1.Text = "Open tcp to tcp";
				button2.Text = "Close forward";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show((Program.Language == 1) ? "端口号输入错误！" : "IpAddress port input error");
			}
			else
			{
				try
				{
					tcpForward = new TcpForward(int.Parse(textBox1.Text), textBox3.Text, result);
					tcpForward.LogMsgFormatBinary = checkBox1.Checked;
					tcpForward.LogNet = new LogNetSingle("");
					tcpForward.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
					tcpForward.ServerStart();
					button1.Enabled = false;
					button2.Enabled = true;
					MessageBox.Show(StringResources.Language.ConnectServerSuccess);
				}
				catch (Exception ex)
				{
					MessageBox.Show(StringResources.Language.ConnectedFailed + Environment.NewLine + ex.Message);
				}
			}
		}

		private void LogNet_BeforeSaveToFile(object sender, HslEventArgs e)
		{
			if (base.InvokeRequired)
			{
				Invoke(new Action<object, HslEventArgs>(LogNet_BeforeSaveToFile), sender, e);
			}
			else
			{
				textBox6.AppendText(e.HslMessage.ToString() + Environment.NewLine);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				tcpForward.ServerClose();
				button2.Enabled = false;
				button1.Enabled = true;
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage(ex);
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox3.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue("LocalPort", textBox1.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox3.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox1.Text = element.Attribute("LocalPort").Value;
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
			textBox3 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			panel2 = new System.Windows.Forms.Panel();
			checkBox1 = new System.Windows.Forms.CheckBox();
			textBox6 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			listBox1 = new System.Windows.Forms.ListBox();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(listBox1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Location = new System.Drawing.Point(4, 37);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(995, 67);
			panel1.TabIndex = 7;
			textBox2.Location = new System.Drawing.Point(438, 5);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(65, 23);
			textBox2.TabIndex = 23;
			textBox2.Text = "1000";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(339, 8);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(93, 17);
			label3.TabIndex = 22;
			label3.Text = "Remote Port：";
			textBox3.Location = new System.Drawing.Point(82, 5);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(249, 23);
			textBox3.TabIndex = 21;
			textBox3.Text = "192.168.0.100";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(4, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(80, 17);
			label1.TabIndex = 20;
			label1.Text = "Remote IP：";
			textBox1.Location = new System.Drawing.Point(81, 35);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(118, 23);
			textBox1.TabIndex = 19;
			textBox1.Text = "2000";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 38);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(78, 17);
			label2.TabIndex = 18;
			label2.Text = "Local Port：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(368, 32);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(135, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭转换";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(240, 32);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(122, 28);
			button1.TabIndex = 4;
			button1.Text = "打开转换";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(checkBox1);
			panel2.Controls.Add(textBox6);
			panel2.Controls.Add(label7);
			panel2.Location = new System.Drawing.Point(4, 107);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(995, 533);
			panel2.TabIndex = 13;
			checkBox1.AutoSize = true;
			checkBox1.Checked = true;
			checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox1.Location = new System.Drawing.Point(152, 3);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(135, 21);
			checkBox1.TabIndex = 22;
			checkBox1.Text = "是否使用二进制通信";
			checkBox1.UseVisualStyleBackColor = true;
			textBox6.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox6.Location = new System.Drawing.Point(6, 30);
			textBox6.Multiline = true;
			textBox6.Name = "textBox6";
			textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox6.Size = new System.Drawing.Size(984, 495);
			textBox6.TabIndex = 21;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(3, 4);
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
			userControlHead1.ProtocolInfo = "TCP - TCP";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 14;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			listBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			listBox1.BackColor = System.Drawing.Color.LightGray;
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 17;
			listBox1.Location = new System.Drawing.Point(568, 5);
			listBox1.Name = "listBox1";
			listBox1.Size = new System.Drawing.Size(422, 55);
			listBox1.TabIndex = 32;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormTcpToTcp";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "TCP转TCP调试工具";
			base.Load += new System.EventHandler(FormSerialDebug_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
