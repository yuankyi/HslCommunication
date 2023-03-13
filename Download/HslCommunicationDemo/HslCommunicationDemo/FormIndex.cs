using HslCommunicationDemo.Properties;
using HslControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormIndex : HslFormContent
	{
		private IContainer components = null;

		private HslTitle hslTitle1;

		private LinkLabel linkLabel1;

		private Label label10;

		private TextBox textBox1;

		private Label label14;

		private Label label15;

		private SplitContainer splitContainer1;

		private PictureBox pictureBox1;

		private PictureBox pictureBox2;

		public FormIndex()
		{
			InitializeComponent();
		}

		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			FormLoad.OpenWebside(linkLabel1.Text);
		}

		private void FormCharge_Load(object sender, EventArgs e)
		{
			SetUpdayeInfo();
			if (Program.Language == 2)
			{
				Text = "Start Page";
			}
		}

		private void SetUpdayeInfo()
		{
			textBox1.Text = "V11.3.3\r\n1. HslCertificate: 新增自定义的证书类，支持持有者颁发证书，对证书验证签名，例如可以使用证书实现对API接口权限验证，详细查看API文档。\r\n2. OmronCipNet: 修复异步写入字符串时，编码无法指定ASCII之外的bug，导致无法使用UTF8写入中文。\r\n3. ModbusTcpServer: 重新增加属性 StationCheck, ，当服务器只有一个站号的时候，设置为True表示校验客户端请求的站号，反之则不校验。\r\n4. DLT645及DLT645OverTcp: 支持写入字符串的方法，字符串将会转为二进制并且颠倒顺序，写入到仪表里去，写int及double数组也会转字符串数组写入。\r\n5. WebsocketServer: 服务器初步支持了SSL通信，使用证书通信，需要带私钥的证书才能成功创建，等待进一步的测试。\r\n6. LogNetBase: 日志获取相关的存储列表的方法中，增加一个错误捕获，在极端情况下可能会因为错误异常。\r\n7. Authorization: 激活系统的方法新增基于证书激活的方式，具体使用方法参考官网文档。\r\n8. Demo: Demo主界面的左侧的设备列表信息改为浮动窗体，可以自由隐藏，DEMO也支持了使用证书激活。\r\n9 新官网：http://www.hsltechnology.cn/，还有全新的使用文档的地址：http://www.hsltechnology.cn/Doc/HslCommunication\r\n10. 本软件已经申请软件著作权，软著登记号：2020SR0340826，任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权。";
		}

		private void ShowActiveCode()
		{
			textBox1.Text = "/// <summary>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  /// 应用程序的主入口点。\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t  /// </summary>\r\n[STAThread]\r\nstatic void Main( )\r\n{\r\n\t// 中文授权示例\r\n\tif(!HslCommunication.Authorization.SetAuthorizationCode( \"你的激活码\" ))\r\n\t{\r\n\t\tMessageBox.Show( \"授权失败！当前程序只能使用24小时！\" );\r\n\t\treturn; // 激活失败就退出系统\r\n\t}\r\n\r\n\t// English For example\r\n\tif(!HslCommunication.Authorization.SetAuthorizationCode( \"Your Active Code\" ))\r\n\t{\r\n\t\tMessageBox.Show( \"Active Failed! it can only use 24 hours\" );\r\n\t\treturn;  // quit if active failed\r\n\t}\r\n\tApplication.EnableVisualStyles( );\r\n\tApplication.SetCompatibleTextRenderingDefault( false );\r\n\tApplication.Run( new Form1( ) );\r\n}";
		}

		private void label15_Click(object sender, EventArgs e)
		{
			ShowActiveCode();
		}

		private void label14_Click(object sender, EventArgs e)
		{
			SetUpdayeInfo();
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
			hslTitle1 = new HslControls.HslTitle();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			label10 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			hslTitle1.Dock = System.Windows.Forms.DockStyle.Top;
			hslTitle1.EdgeColor = System.Drawing.Color.Bisque;
			hslTitle1.Font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			hslTitle1.FontLeft = null;
			hslTitle1.FontRight = null;
			hslTitle1.LeftRightEdgeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			hslTitle1.Location = new System.Drawing.Point(0, 0);
			hslTitle1.Name = "hslTitle1";
			hslTitle1.Size = new System.Drawing.Size(700, 58);
			hslTitle1.TabIndex = 0;
			hslTitle1.Text = "HslCommunication";
			hslTitle1.TextLeft = "";
			hslTitle1.TextRight = "";
			linkLabel1.AutoSize = true;
			linkLabel1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			linkLabel1.Location = new System.Drawing.Point(56, 367);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(199, 17);
			linkLabel1.TabIndex = 2;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "http://www.hslcommunication.cn/";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(LinkLabel1_LinkClicked);
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label10.Location = new System.Drawing.Point(12, 367);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(44, 17);
			label10.TabIndex = 3;
			label10.Text = "官网：";
			textBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox1.BackColor = System.Drawing.Color.AliceBlue;
			textBox1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox1.Location = new System.Drawing.Point(13, 386);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox1.Size = new System.Drawing.Size(676, 93);
			textBox1.TabIndex = 4;
			label14.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label14.ForeColor = System.Drawing.Color.Gray;
			label14.Location = new System.Drawing.Point(584, 367);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(104, 17);
			label14.TabIndex = 5;
			label14.Text = "本次更新日志如下";
			label14.Click += new System.EventHandler(label14_Click);
			label15.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label15.ForeColor = System.Drawing.Color.Blue;
			label15.Location = new System.Drawing.Point(522, 367);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(56, 17);
			label15.TabIndex = 6;
			label15.Text = "激活方法";
			label15.Click += new System.EventHandler(label15_Click);
			splitContainer1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			splitContainer1.Location = new System.Drawing.Point(15, 65);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Panel1.Controls.Add(pictureBox1);
			splitContainer1.Panel2.Controls.Add(pictureBox2);
			splitContainer1.Size = new System.Drawing.Size(673, 299);
			splitContainer1.SplitterDistance = 339;
			splitContainer1.TabIndex = 8;
			pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			pictureBox1.Image = HslCommunicationDemo.Properties.Resources.SupportDevice;
			pictureBox1.Location = new System.Drawing.Point(0, 0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(339, 299);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			pictureBox2.Image = HslCommunicationDemo.Properties.Resources.SupportRobot;
			pictureBox2.Location = new System.Drawing.Point(0, 0);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(330, 299);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox2.TabIndex = 1;
			pictureBox2.TabStop = false;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			AutoScroll = true;
			BackColor = System.Drawing.Color.AliceBlue;
			base.ClientSize = new System.Drawing.Size(700, 491);
			base.Controls.Add(splitContainer1);
			base.Controls.Add(label15);
			base.Controls.Add(label14);
			base.Controls.Add(textBox1);
			base.Controls.Add(label10);
			base.Controls.Add(linkLabel1);
			base.Controls.Add(hslTitle1);
			base.Name = "FormIndex";
			Text = "起始页";
			base.Load += new System.EventHandler(FormCharge_Load);
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
