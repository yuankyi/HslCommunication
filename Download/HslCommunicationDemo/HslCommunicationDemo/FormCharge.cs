using HslCommunicationDemo.Properties;
using HslControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormCharge : HslFormContent
	{
		private Timer timer1s;

		private IContainer components = null;

		private TableLayoutPanel tableLayoutPanel1;

		private Panel panel5;

		private Label label8;

		private Label label9;

		private Panel panel3;

		private Label label4;

		private Panel panel1;

		private Label label3;

		private Label label2;

		private Label label1;

		private HslPanel hslPanel3;

		private HslPanel hslPanel2;

		private HslPanel hslPanel1;

		private Label label7;

		private TableLayoutPanel tableLayoutPanel2;

		private Panel panel7;

		private Panel panel6;

		private Panel panel4;

		private Panel panel2;

		private TableLayoutPanel tableLayoutPanel3;

		private Panel panel9;

		private Panel panel8;

		private Label label5;

		private PictureBox pictureBox2;

		private PictureBox pictureBox1;

		private Label label16;

		private Label label12;

		private Label label15;

		private Label label10;

		private Label label14;

		private Label label6;

		private PictureBox pictureBox3;

		private Label label17;

		private Label label11;

		public FormCharge()
		{
			InitializeComponent();
		}

		private void FormCharge_Load(object sender, EventArgs e)
		{
			if (!Program.IsActive)
			{
				timer1s = new Timer();
				timer1s.Tick += Timer1s_Tick;
				timer1s.Interval = 500;
				timer1s.Start();
			}
			if (Program.Language == 2)
			{
				Text = "Charge";
				label17.Text = "The copyright of this component belongs to Hangzhou Hu Gong Iot Technology Co., Ltd., commercial use please contact authorization, thank you for China's industrial software industry, automation industry support. Any misappropriated software, cracking software, commercial use without formal contract authorization is considered infringement, will be held accountable according to law, commercial use includes direct integrated sales and internal use of economic benefits.";
				label7.Text = "One-time payment, permanent authorization\r\nC#+Java+Python all code\r\nSupport subsequent updates\r\nSupport windows+linux\r\nConsulting QQ:200962190\r\nEmail: hsl200909@163.com";
				label9.Text = "Enterprise commercial + source code";
				label8.Text = "Please contact for a quote";
				label3.Text = "Can only call C# dll\r\nContinuous operation for 20 years\r\nUp to 100 PLCs per project\r\nSoftware restart and re-time\r\nScan the QR code below to pay and add vip group\r\nOnly for testing environment and academic research";
				label1.Text = "Personal non-commercial";
				label2.Text = "39 $";
			}
		}

		private void Timer1s_Tick(object sender, EventArgs e)
		{
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void label1_Click(object sender, EventArgs e)
		{
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
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			panel5 = new System.Windows.Forms.Panel();
			hslPanel3 = new HslControls.HslPanel();
			label7 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			hslPanel2 = new HslControls.HslPanel();
			label4 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			hslPanel1 = new HslControls.HslPanel();
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			panel7 = new System.Windows.Forms.Panel();
			label16 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			panel6 = new System.Windows.Forms.Panel();
			label15 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			panel4 = new System.Windows.Forms.Panel();
			label14 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			label11 = new System.Windows.Forms.Label();
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			pictureBox3 = new System.Windows.Forms.PictureBox();
			panel9 = new System.Windows.Forms.Panel();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			panel8 = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label5 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			tableLayoutPanel1.SuspendLayout();
			panel5.SuspendLayout();
			hslPanel3.SuspendLayout();
			panel3.SuspendLayout();
			hslPanel2.SuspendLayout();
			panel1.SuspendLayout();
			hslPanel1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			panel7.SuspendLayout();
			panel6.SuspendLayout();
			panel4.SuspendLayout();
			panel2.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			panel9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			panel8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			tableLayoutPanel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.1688f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.46495f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.36625f));
			tableLayoutPanel1.Controls.Add(panel5, 2, 0);
			tableLayoutPanel1.Controls.Add(panel3, 1, 0);
			tableLayoutPanel1.Controls.Add(panel1, 0, 0);
			tableLayoutPanel1.Location = new System.Drawing.Point(10, 69);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 1;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300f));
			tableLayoutPanel1.Size = new System.Drawing.Size(821, 257);
			tableLayoutPanel1.TabIndex = 1;
			tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(tableLayoutPanel1_Paint);
			panel5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel5.Controls.Add(hslPanel3);
			panel5.Location = new System.Drawing.Point(549, 3);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(269, 294);
			panel5.TabIndex = 2;
			hslPanel3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			hslPanel3.CenterColor = System.Drawing.Color.Snow;
			hslPanel3.Controls.Add(label7);
			hslPanel3.Controls.Add(label9);
			hslPanel3.Controls.Add(label8);
			hslPanel3.EdgeColor = System.Drawing.Color.MistyRose;
			hslPanel3.Location = new System.Drawing.Point(4, 8);
			hslPanel3.Name = "hslPanel3";
			hslPanel3.Size = new System.Drawing.Size(262, 242);
			hslPanel3.TabIndex = 1;
			hslPanel3.Text = "hslPanel3";
			label7.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label7.BackColor = System.Drawing.Color.Transparent;
			label7.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label7.ForeColor = System.Drawing.Color.Red;
			label7.Location = new System.Drawing.Point(0, 82);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(262, 158);
			label7.TabIndex = 6;
			label7.Text = "一次付费，永久授权\r\nC#+Java+Python所有代码\r\n支持后续更新\r\n支持windows+linux\r\n咨询QQ:200962190\r\n咨询微信：xyz200962190\r\nEmail: hsltechnology@163.com";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label9.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label9.BackColor = System.Drawing.Color.Transparent;
			label9.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label9.ForeColor = System.Drawing.Color.Black;
			label9.Location = new System.Drawing.Point(0, 20);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(262, 36);
			label9.TabIndex = 0;
			label9.Text = "企业商用+源码";
			label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label8.BackColor = System.Drawing.Color.Transparent;
			label8.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label8.ForeColor = System.Drawing.Color.Blue;
			label8.Location = new System.Drawing.Point(3, 50);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(262, 36);
			label8.TabIndex = 1;
			label8.Text = "请联系报价";
			label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel3.Controls.Add(hslPanel2);
			panel3.Location = new System.Drawing.Point(275, 3);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(268, 294);
			panel3.TabIndex = 1;
			hslPanel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			hslPanel2.CenterColor = System.Drawing.Color.Azure;
			hslPanel2.Controls.Add(label4);
			hslPanel2.EdgeColor = System.Drawing.Color.LightCyan;
			hslPanel2.Location = new System.Drawing.Point(3, 8);
			hslPanel2.Name = "hslPanel2";
			hslPanel2.Size = new System.Drawing.Size(262, 242);
			hslPanel2.TabIndex = 1;
			hslPanel2.Text = "hslPanel2";
			label4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label4.ForeColor = System.Drawing.Color.Red;
			label4.Location = new System.Drawing.Point(3, 42);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(262, 172);
			label4.TabIndex = 2;
			label4.Text = "QQ群信息\r\n群1: 592132877\r\n群2: 948305931\r\n群3: 767856490\r\n群4: 818409889\r\n群5: 474160094\r\n普通vip群: 838185568 (赞助240元)";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.Controls.Add(hslPanel1);
			panel1.Location = new System.Drawing.Point(3, 3);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(266, 294);
			panel1.TabIndex = 0;
			hslPanel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			hslPanel1.CenterColor = System.Drawing.Color.WhiteSmoke;
			hslPanel1.Controls.Add(label1);
			hslPanel1.Controls.Add(label3);
			hslPanel1.Controls.Add(label2);
			hslPanel1.EdgeColor = System.Drawing.Color.FromArgb(224, 224, 224);
			hslPanel1.Location = new System.Drawing.Point(3, 7);
			hslPanel1.Name = "hslPanel1";
			hslPanel1.Size = new System.Drawing.Size(260, 241);
			hslPanel1.TabIndex = 0;
			hslPanel1.Text = "hslPanel1";
			label1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.ForeColor = System.Drawing.Color.Black;
			label1.Location = new System.Drawing.Point(0, 21);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(260, 36);
			label1.TabIndex = 0;
			label1.Text = "个人使用";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label1.Click += new System.EventHandler(label1_Click);
			label3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label3.ForeColor = System.Drawing.Color.Red;
			label3.Location = new System.Drawing.Point(3, 100);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(260, 141);
			label3.TabIndex = 2;
			label3.Text = "调用C#的dll或java的jar包\r\n连续运行10年\r\n软件重启重新计时\r\n扫描下方二维码付款然后加vip群\r\n高级API限制使用24小时\r\n注释带[商业授权]字样的";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label2.ForeColor = System.Drawing.Color.Blue;
			label2.Location = new System.Drawing.Point(0, 65);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(260, 36);
			label2.TabIndex = 1;
			label2.Text = "240 ￥";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			tableLayoutPanel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			tableLayoutPanel2.ColumnCount = 4;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120f));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120f));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120f));
			tableLayoutPanel2.Controls.Add(panel7, 3, 0);
			tableLayoutPanel2.Controls.Add(panel6, 2, 0);
			tableLayoutPanel2.Controls.Add(panel4, 1, 0);
			tableLayoutPanel2.Controls.Add(panel2, 0, 0);
			tableLayoutPanel2.Location = new System.Drawing.Point(12, 330);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayoutPanel2.Size = new System.Drawing.Size(822, 268);
			tableLayoutPanel2.TabIndex = 8;
			panel7.Controls.Add(label16);
			panel7.Controls.Add(label12);
			panel7.Dock = System.Windows.Forms.DockStyle.Fill;
			panel7.Location = new System.Drawing.Point(705, 3);
			panel7.Name = "panel7";
			panel7.Size = new System.Drawing.Size(114, 262);
			panel7.TabIndex = 3;
			label16.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label16.BackColor = System.Drawing.Color.Transparent;
			label16.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label16.ForeColor = System.Drawing.Color.Red;
			label16.Location = new System.Drawing.Point(5, 38);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(106, 218);
			label16.TabIndex = 5;
			label16.Text = "ab-plc\r\nsiemens-s7\r\nsiemens-fw\r\nmelsec-3e\r\nmelsec-1e\r\nmodbus-tcp\r\nomron-finsTcp";
			label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label12.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label12.Location = new System.Drawing.Point(3, 5);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(91, 33);
			label12.TabIndex = 1;
			label12.Text = "Python 版本";
			label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel6.Controls.Add(label15);
			panel6.Controls.Add(label10);
			panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			panel6.Location = new System.Drawing.Point(585, 3);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(114, 262);
			panel6.TabIndex = 2;
			label15.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label15.BackColor = System.Drawing.Color.Transparent;
			label15.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label15.ForeColor = System.Drawing.Color.Red;
			label15.Location = new System.Drawing.Point(6, 38);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(108, 218);
			label15.TabIndex = 4;
			label15.Text = "ab-plc\r\nsiemens-s7\r\nsiemens-fw\r\nmelsec-3e\r\nmelsec-1e\r\nmodbus-tcp\r\nomron-finsTcp";
			label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label10.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label10.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label10.Location = new System.Drawing.Point(3, 8);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(111, 30);
			label10.TabIndex = 1;
			label10.Text = "Java 版本";
			label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel4.Controls.Add(label14);
			panel4.Controls.Add(label6);
			panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			panel4.Location = new System.Drawing.Point(465, 3);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(114, 262);
			panel4.TabIndex = 1;
			label14.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label14.BackColor = System.Drawing.Color.Transparent;
			label14.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label14.ForeColor = System.Drawing.Color.Red;
			label14.Location = new System.Drawing.Point(3, 38);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(108, 218);
			label14.TabIndex = 3;
			label14.Text = "winform\r\nwpf\r\nunity\r\nasp.net\r\n.net core\r\nwindows\r\nlinux\r\nXamarin\r\nandriod\r\nuwp\r\nraspberry pi";
			label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label6.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label6.Location = new System.Drawing.Point(3, 8);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(108, 30);
			label6.TabIndex = 0;
			label6.Text = "C# 版本";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel2.Controls.Add(label11);
			panel2.Controls.Add(tableLayoutPanel3);
			panel2.Controls.Add(label5);
			panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			panel2.Location = new System.Drawing.Point(3, 3);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(456, 262);
			panel2.TabIndex = 0;
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label11.ForeColor = System.Drawing.Color.DarkOrchid;
			label11.Location = new System.Drawing.Point(7, 27);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(261, 17);
			label11.TabIndex = 10;
			label11.Text = "本软件已经申请著作权：软著登字第5219522号";
			tableLayoutPanel3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			tableLayoutPanel3.ColumnCount = 3;
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
			tableLayoutPanel3.Controls.Add(pictureBox3, 0, 0);
			tableLayoutPanel3.Controls.Add(panel9, 1, 0);
			tableLayoutPanel3.Controls.Add(panel8, 0, 0);
			tableLayoutPanel3.Location = new System.Drawing.Point(3, 52);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 1;
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayoutPanel3.Size = new System.Drawing.Size(450, 204);
			tableLayoutPanel3.TabIndex = 1;
			pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			pictureBox3.Image = HslCommunicationDemo.Properties.Resources.weipay;
			pictureBox3.Location = new System.Drawing.Point(153, 3);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new System.Drawing.Size(144, 198);
			pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox3.TabIndex = 2;
			pictureBox3.TabStop = false;
			panel9.Controls.Add(pictureBox2);
			panel9.Dock = System.Windows.Forms.DockStyle.Fill;
			panel9.Location = new System.Drawing.Point(303, 3);
			panel9.Name = "panel9";
			panel9.Size = new System.Drawing.Size(144, 198);
			panel9.TabIndex = 1;
			pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			pictureBox2.Image = HslCommunicationDemo.Properties.Resources.copyright;
			pictureBox2.Location = new System.Drawing.Point(0, 0);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(144, 198);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox2.TabIndex = 1;
			pictureBox2.TabStop = false;
			panel8.Controls.Add(pictureBox1);
			panel8.Dock = System.Windows.Forms.DockStyle.Fill;
			panel8.Location = new System.Drawing.Point(3, 3);
			panel8.Name = "panel8";
			panel8.Size = new System.Drawing.Size(144, 198);
			panel8.TabIndex = 0;
			pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			pictureBox1.Image = HslCommunicationDemo.Properties.Resources.alipay;
			pictureBox1.Location = new System.Drawing.Point(0, 0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(144, 198);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label5.Location = new System.Drawing.Point(7, 5);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(260, 17);
			label5.TabIndex = 0;
			label5.Text = "个人非商用付款方式（企业商用请联系公司）：";
			label17.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label17.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label17.Location = new System.Drawing.Point(7, 0);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(827, 69);
			label17.TabIndex = 9;
			label17.Text = "本组件的版权归杭州胡工物联科技有限公司所有，商业使用请联系授权，感谢对中国工业软件行业，自动化行业的支持\r\n任何盗用软件，破解软件，未经正式合同授权而商业使用均视为侵权，将依法追究责任，商用用途包含直接集成销售及企业内部使用产生经济效益。";
			label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			AutoScroll = true;
			BackColor = System.Drawing.Color.AliceBlue;
			base.ClientSize = new System.Drawing.Size(845, 600);
			base.Controls.Add(label17);
			base.Controls.Add(tableLayoutPanel2);
			base.Controls.Add(tableLayoutPanel1);
			base.Name = "FormCharge";
			Text = "关于授权";
			base.Load += new System.EventHandler(FormCharge_Load);
			tableLayoutPanel1.ResumeLayout(false);
			panel5.ResumeLayout(false);
			hslPanel3.ResumeLayout(false);
			panel3.ResumeLayout(false);
			hslPanel2.ResumeLayout(false);
			panel1.ResumeLayout(false);
			hslPanel1.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			panel7.ResumeLayout(false);
			panel6.ResumeLayout(false);
			panel4.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			tableLayoutPanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			panel9.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			panel8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}
