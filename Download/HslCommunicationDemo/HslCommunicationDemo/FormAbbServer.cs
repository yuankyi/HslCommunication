using HslCommunication.LogNet;
using HslCommunication.Robot.ABB;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormAbbServer : HslFormContent
	{
		private ABBWebApiServer httpServer;

		private bool showLog = true;

		private IContainer components = null;

		private Panel panel1;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private Panel panel2;

		private TextBox textBox4;

		private Label label9;

		private UserControlHead userControlHead1;

		private Button button4;

		private CheckBox checkBox1;

		private Label label1;

		private ComboBox comboBox1;

		private TextBox textBox1;

		private Label label4;

		private TextBox textBox3;

		private Label label2;

		private LinkLabel linkLabel3;

		private LinkLabel linkLabel2;

		private LinkLabel linkLabel1;

		public FormAbbServer()
		{
			InitializeComponent();
		}

		private void FormClient_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			comboBox1.DataSource = new string[5]
			{
				"text/html",
				"text/plain",
				"text/xml",
				"application/xml",
				"application/json"
			};
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language != 1)
			{
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				httpServer = new ABBWebApiServer();
				httpServer.SetLoginAccount(textBox3.Text, textBox1.Text);
				httpServer.Start(int.Parse(textBox2.Text));
				httpServer.LogNet = new LogNetSingle("");
				httpServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
				httpServer.IsCrossDomain = checkBox1.Checked;
				panel2.Enabled = true;
				button1.Enabled = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Started Failed:" + ex.Message);
			}
		}

		private void LogNet_BeforeSaveToFile(object sender, HslEventArgs e)
		{
			Invoke((Action)delegate
			{
				if (showLog)
				{
					textBox4.AppendText(e.HslMessage.ToString() + Environment.NewLine);
				}
			});
		}

		private void button4_Click(object sender, EventArgs e)
		{
			ABBWebApiServer aBBWebApiServer = httpServer;
			if (aBBWebApiServer != null)
			{
				aBBWebApiServer.Close();
			}
			panel2.Enabled = false;
			button1.Enabled = true;
		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			textBox4.Clear();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			showLog = false;
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			showLog = true;
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlUserName, textBox3.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPassword, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlCrossDomain, checkBox1.Checked);
			element.SetAttributeValue(DemoDeviceList.XmlContentType, comboBox1.SelectedIndex);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox3.Text = element.Attribute(DemoDeviceList.XmlUserName).Value;
			textBox1.Text = element.Attribute(DemoDeviceList.XmlPassword).Value;
			checkBox1.Checked = bool.Parse(element.Attribute(DemoDeviceList.XmlCrossDomain).Value);
			comboBox1.SelectedIndex = int.Parse(element.Attribute(DemoDeviceList.XmlContentType).Value);
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
			textBox1 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			comboBox1 = new System.Windows.Forms.ComboBox();
			checkBox1 = new System.Windows.Forms.CheckBox();
			button4 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			linkLabel3 = new System.Windows.Forms.LinkLabel();
			linkLabel2 = new System.Windows.Forms.LinkLabel();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			textBox4 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(checkBox1);
			panel1.Controls.Add(button4);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(4, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 79);
			panel1.TabIndex = 7;
			textBox1.Location = new System.Drawing.Point(256, 42);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(116, 23);
			textBox1.TabIndex = 23;
			textBox1.Text = "robotics";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(189, 45);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(65, 17);
			label4.TabIndex = 22;
			label4.Text = "password";
			textBox3.Location = new System.Drawing.Point(55, 42);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(128, 23);
			textBox3.TabIndex = 21;
			textBox3.Text = "Default User";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(9, 45);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(43, 17);
			label2.TabIndex = 20;
			label2.Text = "Name";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(333, 11);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(80, 17);
			label1.TabIndex = 19;
			label1.Text = "返回内容方式";
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(419, 8);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(121, 25);
			comboBox1.TabIndex = 18;
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(173, 10);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(123, 21);
			checkBox1.TabIndex = 17;
			checkBox1.Text = "是否支持跨域请求";
			checkBox1.UseVisualStyleBackColor = true;
			button4.Location = new System.Drawing.Point(717, 5);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(91, 28);
			button4.TabIndex = 16;
			button4.Text = "关闭服务";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button1.Location = new System.Drawing.Point(620, 5);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "启动服务";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(62, 8);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(79, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "80";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(8, 11);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(linkLabel3);
			panel2.Controls.Add(linkLabel2);
			panel2.Controls.Add(linkLabel1);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label9);
			panel2.Location = new System.Drawing.Point(4, 120);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 523);
			panel2.TabIndex = 13;
			linkLabel3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			linkLabel3.AutoSize = true;
			linkLabel3.Location = new System.Drawing.Point(934, 11);
			linkLabel3.Name = "linkLabel3";
			linkLabel3.Size = new System.Drawing.Size(32, 17);
			linkLabel3.TabIndex = 14;
			linkLabel3.TabStop = true;
			linkLabel3.Text = "清空";
			linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel3_LinkClicked);
			linkLabel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			linkLabel2.AutoSize = true;
			linkLabel2.Location = new System.Drawing.Point(880, 11);
			linkLabel2.Name = "linkLabel2";
			linkLabel2.Size = new System.Drawing.Size(32, 17);
			linkLabel2.TabIndex = 13;
			linkLabel2.TabStop = true;
			linkLabel2.Text = "继续";
			linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel2_LinkClicked);
			linkLabel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new System.Drawing.Point(829, 11);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(32, 17);
			linkLabel1.TabIndex = 12;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "停止";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			textBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox4.Location = new System.Drawing.Point(62, 31);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox4.Size = new System.Drawing.Size(925, 487);
			textBox4.TabIndex = 8;
			textBox4.TextChanged += new System.EventHandler(textBox4_TextChanged);
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(9, 31);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(44, 17);
			label9.TabIndex = 11;
			label9.Text = "日志：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.hslcommunication.cn/";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "html";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 14;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormAbbServer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "ABB机器人的虚拟服务器";
			base.Load += new System.EventHandler(FormClient_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
