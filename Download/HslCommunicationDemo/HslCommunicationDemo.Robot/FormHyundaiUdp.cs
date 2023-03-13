using HslCommunication.LogNet;
using HslCommunication.Robot.Hyundai;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo.Robot
{
	public class FormHyundaiUdp : HslFormContent
	{
		private HyundaiUdpNet hyundai;

		private IContainer components = null;

		private UserControlHead userControlHead1;

		private Panel panel1;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private GroupBox groupBox1;

		private TextBox textBox_rz;

		private Label label10;

		private TextBox textBox_ry;

		private Label label11;

		private TextBox textBox_rx;

		private Label label12;

		private TextBox textBox_z;

		private Label label9;

		private TextBox textBox_y;

		private Label label8;

		private TextBox textBox_x;

		private Label label7;

		private TextBox textBox6;

		private Label label6;

		private TextBox textBox5;

		private Label label5;

		private TextBox textBox4;

		private Label label4;

		private TextBox textBox3;

		private Label label2;

		private TextBox textBox1;

		private Label label1;

		private GroupBox groupBox2;

		private TextBox textBox19;

		private GroupBox groupBox3;

		private Button button13;

		private Button button14;

		private TextBox textBox12;

		private Button button11;

		private Button button12;

		private TextBox textBox11;

		private Button button9;

		private Button button10;

		private TextBox textBox10;

		private Button button7;

		private Button button8;

		private TextBox textBox9;

		private Button button5;

		private Button button6;

		private TextBox textBox8;

		private Button button4;

		private Label label13;

		private Label label14;

		private Label label15;

		private Label label16;

		private Label label17;

		private Label label18;

		private Button button3;

		private TextBox textBox7;

		private GroupBox groupBox4;

		private Button button15;

		private TextBox textBox13;

		private TextBox textBox14;

		private TextBox textBox15;

		private TextBox textBox16;

		private TextBox textBox17;

		private Label label19;

		private Label label20;

		private Label label21;

		private Label label22;

		private Label label23;

		private Label label24;

		private TextBox textBox18;

		private Label label27;

		private Label label28;

		private Label label26;

		private Label label25;

		public FormHyundaiUdp()
		{
			InitializeComponent();
		}

		private void FormHyundaiUdp_Load(object sender, EventArgs e)
		{
			if (Program.Language == 2)
			{
				label3.Text = "Port";
				button1.Text = "Start";
				button2.Text = "Stop";
				groupBox1.Text = "Robot Real Data";
				groupBox3.Text = "Increment Write";
				groupBox4.Text = "Increment Write";
				button15.Text = "Write";
				groupBox2.Text = "Log";
			}
			groupBox1.Enabled = false;
			groupBox2.Enabled = false;
			groupBox3.Enabled = false;
			groupBox4.Enabled = false;
			button2.Enabled = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show("Port input wrong!");
			}
			else
			{
				try
				{
					hyundai = new HyundaiUdpNet();
					hyundai.OnHyundaiMessageReceive += Hyundai_OnHyundaiMessageReceive;
					hyundai.LogNet = new LogNetSingle("");
					hyundai.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
					hyundai.ServerStart(result);
					MessageBox.Show("Start Success");
					groupBox1.Enabled = true;
					groupBox2.Enabled = true;
					groupBox3.Enabled = true;
					groupBox4.Enabled = true;
					button1.Enabled = false;
					button2.Enabled = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Start Failed: " + ex.Message);
				}
			}
		}

		private void LogNet_BeforeSaveToFile(object sender, HslEventArgs e)
		{
			Invoke((Action)delegate
			{
				textBox19.AppendText(e.HslMessage.ToString() + Environment.NewLine);
			});
		}

		private void Hyundai_OnHyundaiMessageReceive(HyundaiData data)
		{
			Invoke((Action)delegate
			{
				textBox1.Text = data.Command.ToString();
				textBox3.Text = data.CharDummy;
				textBox4.Text = data.State.ToString();
				textBox5.Text = data.Count.ToString();
				textBox6.Text = data.IntDummy.ToString();
				textBox_x.Text = data.Data[0].ToString();
				textBox_y.Text = data.Data[1].ToString();
				textBox_z.Text = data.Data[2].ToString();
				textBox_rx.Text = data.Data[3].ToString();
				textBox_ry.Text = data.Data[4].ToString();
				textBox_rz.Text = data.Data[5].ToString();
			});
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				hyundai.ServerClose();
				button1.Enabled = true;
				button2.Enabled = false;
				groupBox1.Enabled = false;
				groupBox2.Enabled = false;
				groupBox3.Enabled = false;
				groupBox4.Enabled = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Close Failed:" + ex.Message);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(() => hyundai.MoveX(double.Parse(textBox7.Text)), "X");
		}

		private void button4_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(() => hyundai.MoveX(0.0 - double.Parse(textBox7.Text)), "-X");
		}

		private void button6_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(() => hyundai.MoveY(double.Parse(textBox8.Text)), "Y");
		}

		private void button5_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(() => hyundai.MoveY(0.0 - double.Parse(textBox8.Text)), "-Y");
		}

		private void button8_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(() => hyundai.MoveZ(double.Parse(textBox9.Text)), "Z");
		}

		private void button7_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(() => hyundai.MoveZ(0.0 - double.Parse(textBox9.Text)), "-Z");
		}

		private void button10_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(() => hyundai.RotateX(double.Parse(textBox10.Text)), "Rx");
		}

		private void button9_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(() => hyundai.RotateX(0.0 - double.Parse(textBox10.Text)), "Rx");
		}

		private void button12_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(() => hyundai.RotateY(double.Parse(textBox11.Text)), "Ry");
		}

		private void button11_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(() => hyundai.RotateY(0.0 - double.Parse(textBox11.Text)), "Ry");
		}

		private void button14_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(() => hyundai.RotateZ(double.Parse(textBox12.Text)), "Rz");
		}

		private void button13_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(() => hyundai.RotateZ(0.0 - double.Parse(textBox12.Text)), "Rz");
		}

		private void button15_Click(object sender, EventArgs e)
		{
			DemoUtils.WriteResultRender(() => hyundai.WriteIncrementPos(double.Parse(textBox18.Text), double.Parse(textBox17.Text), double.Parse(textBox16.Text), double.Parse(textBox15.Text), double.Parse(textBox14.Text), double.Parse(textBox13.Text)), "X,Y,Z,Rx,Ry,Rz");
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
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1 = new System.Windows.Forms.Panel();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			textBox_rz = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			textBox_ry = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			textBox_rx = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			textBox_z = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			textBox_y = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			textBox_x = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			textBox19 = new System.Windows.Forms.TextBox();
			groupBox3 = new System.Windows.Forms.GroupBox();
			button13 = new System.Windows.Forms.Button();
			button14 = new System.Windows.Forms.Button();
			textBox12 = new System.Windows.Forms.TextBox();
			button11 = new System.Windows.Forms.Button();
			button12 = new System.Windows.Forms.Button();
			textBox11 = new System.Windows.Forms.TextBox();
			button9 = new System.Windows.Forms.Button();
			button10 = new System.Windows.Forms.Button();
			textBox10 = new System.Windows.Forms.TextBox();
			button7 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			textBox9 = new System.Windows.Forms.TextBox();
			button5 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			textBox8 = new System.Windows.Forms.TextBox();
			button4 = new System.Windows.Forms.Button();
			label13 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			textBox7 = new System.Windows.Forms.TextBox();
			groupBox4 = new System.Windows.Forms.GroupBox();
			label27 = new System.Windows.Forms.Label();
			label28 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			label25 = new System.Windows.Forms.Label();
			button15 = new System.Windows.Forms.Button();
			textBox13 = new System.Windows.Forms.TextBox();
			textBox14 = new System.Windows.Forms.TextBox();
			textBox15 = new System.Windows.Forms.TextBox();
			textBox16 = new System.Windows.Forms.TextBox();
			textBox17 = new System.Windows.Forms.TextBox();
			label19 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			label23 = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			textBox18 = new System.Windows.Forms.TextBox();
			panel1.SuspendLayout();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox4.SuspendLayout();
			SuspendLayout();
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Hyundai";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.SupportListVisiable = true;
			userControlHead1.TabIndex = 3;
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(14, 40);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(978, 42);
			panel1.TabIndex = 4;
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(333, 6);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "停止服务";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(236, 6);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "启动服务";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(78, 9);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(141, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "8000";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(24, 12);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			groupBox1.Controls.Add(textBox_rz);
			groupBox1.Controls.Add(label10);
			groupBox1.Controls.Add(textBox_ry);
			groupBox1.Controls.Add(label11);
			groupBox1.Controls.Add(textBox_rx);
			groupBox1.Controls.Add(label12);
			groupBox1.Controls.Add(textBox_z);
			groupBox1.Controls.Add(label9);
			groupBox1.Controls.Add(textBox_y);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(textBox_x);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(textBox6);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(textBox5);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(textBox4);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(textBox3);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(textBox1);
			groupBox1.Controls.Add(label1);
			groupBox1.Location = new System.Drawing.Point(14, 89);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(413, 208);
			groupBox1.TabIndex = 5;
			groupBox1.TabStop = false;
			groupBox1.Text = "机器人实时姿态";
			textBox_rz.Location = new System.Drawing.Point(265, 169);
			textBox_rz.Name = "textBox_rz";
			textBox_rz.ReadOnly = true;
			textBox_rz.Size = new System.Drawing.Size(133, 23);
			textBox_rz.TabIndex = 21;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(235, 172);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(25, 17);
			label10.TabIndex = 20;
			label10.Text = "Rz:";
			textBox_ry.Location = new System.Drawing.Point(265, 141);
			textBox_ry.Name = "textBox_ry";
			textBox_ry.ReadOnly = true;
			textBox_ry.Size = new System.Drawing.Size(133, 23);
			textBox_ry.TabIndex = 19;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(235, 144);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(25, 17);
			label11.TabIndex = 18;
			label11.Text = "Ry:";
			textBox_rx.Location = new System.Drawing.Point(265, 112);
			textBox_rx.Name = "textBox_rx";
			textBox_rx.ReadOnly = true;
			textBox_rx.Size = new System.Drawing.Size(133, 23);
			textBox_rx.TabIndex = 17;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(235, 115);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(25, 17);
			label12.TabIndex = 16;
			label12.Text = "Rx:";
			textBox_z.Location = new System.Drawing.Point(264, 83);
			textBox_z.Name = "textBox_z";
			textBox_z.ReadOnly = true;
			textBox_z.Size = new System.Drawing.Size(133, 23);
			textBox_z.TabIndex = 15;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(234, 86);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(18, 17);
			label9.TabIndex = 14;
			label9.Text = "Z:";
			textBox_y.Location = new System.Drawing.Point(264, 55);
			textBox_y.Name = "textBox_y";
			textBox_y.ReadOnly = true;
			textBox_y.Size = new System.Drawing.Size(133, 23);
			textBox_y.TabIndex = 13;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(234, 58);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(18, 17);
			label8.TabIndex = 12;
			label8.Text = "Y:";
			textBox_x.Location = new System.Drawing.Point(264, 26);
			textBox_x.Name = "textBox_x";
			textBox_x.ReadOnly = true;
			textBox_x.Size = new System.Drawing.Size(133, 23);
			textBox_x.TabIndex = 11;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(234, 29);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(19, 17);
			label7.TabIndex = 10;
			label7.Text = "X:";
			textBox6.Location = new System.Drawing.Point(109, 141);
			textBox6.Name = "textBox6";
			textBox6.ReadOnly = true;
			textBox6.Size = new System.Drawing.Size(111, 23);
			textBox6.TabIndex = 9;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(24, 141);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(70, 17);
			label6.TabIndex = 8;
			label6.Text = "IntDummy:";
			textBox5.Location = new System.Drawing.Point(109, 112);
			textBox5.Name = "textBox5";
			textBox5.ReadOnly = true;
			textBox5.Size = new System.Drawing.Size(111, 23);
			textBox5.TabIndex = 7;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(24, 112);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(45, 17);
			label5.TabIndex = 6;
			label5.Text = "Count:";
			textBox4.Location = new System.Drawing.Point(109, 83);
			textBox4.Name = "textBox4";
			textBox4.ReadOnly = true;
			textBox4.Size = new System.Drawing.Size(111, 23);
			textBox4.TabIndex = 5;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(24, 86);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(40, 17);
			label4.TabIndex = 4;
			label4.Text = "State:";
			textBox3.Location = new System.Drawing.Point(109, 54);
			textBox3.Name = "textBox3";
			textBox3.ReadOnly = true;
			textBox3.Size = new System.Drawing.Size(111, 23);
			textBox3.TabIndex = 3;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(24, 57);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(82, 17);
			label2.TabIndex = 2;
			label2.Text = "CharDummy:";
			textBox1.Location = new System.Drawing.Point(109, 26);
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.Size = new System.Drawing.Size(111, 23);
			textBox1.TabIndex = 1;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(24, 29);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(71, 17);
			label1.TabIndex = 0;
			label1.Text = "Command:";
			groupBox2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox2.Controls.Add(textBox19);
			groupBox2.Location = new System.Drawing.Point(14, 303);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(978, 330);
			groupBox2.TabIndex = 6;
			groupBox2.TabStop = false;
			groupBox2.Text = "日志记录";
			textBox19.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox19.Location = new System.Drawing.Point(6, 22);
			textBox19.Multiline = true;
			textBox19.Name = "textBox19";
			textBox19.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox19.Size = new System.Drawing.Size(966, 302);
			textBox19.TabIndex = 0;
			groupBox3.Controls.Add(button13);
			groupBox3.Controls.Add(button14);
			groupBox3.Controls.Add(textBox12);
			groupBox3.Controls.Add(button11);
			groupBox3.Controls.Add(button12);
			groupBox3.Controls.Add(textBox11);
			groupBox3.Controls.Add(button9);
			groupBox3.Controls.Add(button10);
			groupBox3.Controls.Add(textBox10);
			groupBox3.Controls.Add(button7);
			groupBox3.Controls.Add(button8);
			groupBox3.Controls.Add(textBox9);
			groupBox3.Controls.Add(button5);
			groupBox3.Controls.Add(button6);
			groupBox3.Controls.Add(textBox8);
			groupBox3.Controls.Add(button4);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(label14);
			groupBox3.Controls.Add(label15);
			groupBox3.Controls.Add(label16);
			groupBox3.Controls.Add(label17);
			groupBox3.Controls.Add(label18);
			groupBox3.Controls.Add(button3);
			groupBox3.Controls.Add(textBox7);
			groupBox3.Location = new System.Drawing.Point(433, 89);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(271, 208);
			groupBox3.TabIndex = 7;
			groupBox3.TabStop = false;
			groupBox3.Text = "增量数据写入";
			button13.Location = new System.Drawing.Point(204, 164);
			button13.Name = "button13";
			button13.Size = new System.Drawing.Size(51, 25);
			button13.TabIndex = 69;
			button13.Text = "-";
			button13.UseVisualStyleBackColor = true;
			button13.Click += new System.EventHandler(button13_Click);
			button14.Location = new System.Drawing.Point(147, 164);
			button14.Name = "button14";
			button14.Size = new System.Drawing.Size(51, 25);
			button14.TabIndex = 68;
			button14.Text = "+";
			button14.UseVisualStyleBackColor = true;
			button14.Click += new System.EventHandler(button14_Click);
			textBox12.Location = new System.Drawing.Point(45, 165);
			textBox12.Name = "textBox12";
			textBox12.Size = new System.Drawing.Size(96, 23);
			textBox12.TabIndex = 67;
			textBox12.Text = "0.5";
			button11.Location = new System.Drawing.Point(204, 136);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(51, 25);
			button11.TabIndex = 66;
			button11.Text = "-";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			button12.Location = new System.Drawing.Point(147, 136);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(51, 25);
			button12.TabIndex = 65;
			button12.Text = "+";
			button12.UseVisualStyleBackColor = true;
			button12.Click += new System.EventHandler(button12_Click);
			textBox11.Location = new System.Drawing.Point(45, 137);
			textBox11.Name = "textBox11";
			textBox11.Size = new System.Drawing.Size(96, 23);
			textBox11.TabIndex = 64;
			textBox11.Text = "0.5";
			button9.Location = new System.Drawing.Point(204, 107);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(51, 25);
			button9.TabIndex = 63;
			button9.Text = "-";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			button10.Location = new System.Drawing.Point(147, 107);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(51, 25);
			button10.TabIndex = 62;
			button10.Text = "+";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(button10_Click);
			textBox10.Location = new System.Drawing.Point(45, 108);
			textBox10.Name = "textBox10";
			textBox10.Size = new System.Drawing.Size(96, 23);
			textBox10.TabIndex = 61;
			textBox10.Text = "0.5";
			button7.Location = new System.Drawing.Point(204, 80);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(51, 25);
			button7.TabIndex = 60;
			button7.Text = "-";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			button8.Location = new System.Drawing.Point(147, 80);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(51, 25);
			button8.TabIndex = 59;
			button8.Text = "+";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			textBox9.Location = new System.Drawing.Point(45, 81);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(96, 23);
			textBox9.TabIndex = 58;
			textBox9.Text = "10";
			button5.Location = new System.Drawing.Point(204, 51);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(51, 25);
			button5.TabIndex = 57;
			button5.Text = "-";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			button6.Location = new System.Drawing.Point(147, 51);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(51, 25);
			button6.TabIndex = 56;
			button6.Text = "+";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			textBox8.Location = new System.Drawing.Point(45, 52);
			textBox8.Name = "textBox8";
			textBox8.Size = new System.Drawing.Size(96, 23);
			textBox8.TabIndex = 55;
			textBox8.Text = "10";
			button4.Location = new System.Drawing.Point(204, 20);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(51, 25);
			button4.TabIndex = 54;
			button4.Text = "-";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(6, 168);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(25, 17);
			label13.TabIndex = 53;
			label13.Text = "Rz:";
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(6, 140);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(25, 17);
			label14.TabIndex = 52;
			label14.Text = "Ry:";
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(6, 111);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(25, 17);
			label15.TabIndex = 51;
			label15.Text = "Rx:";
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(5, 82);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(18, 17);
			label16.TabIndex = 50;
			label16.Text = "Z:";
			label17.AutoSize = true;
			label17.Location = new System.Drawing.Point(5, 54);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(18, 17);
			label17.TabIndex = 49;
			label17.Text = "Y:";
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(5, 25);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(19, 17);
			label18.TabIndex = 48;
			label18.Text = "X:";
			button3.Location = new System.Drawing.Point(147, 20);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(51, 25);
			button3.TabIndex = 47;
			button3.Text = "+";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox7.Location = new System.Drawing.Point(45, 21);
			textBox7.Name = "textBox7";
			textBox7.Size = new System.Drawing.Size(96, 23);
			textBox7.TabIndex = 46;
			textBox7.Text = "10";
			groupBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox4.Controls.Add(label27);
			groupBox4.Controls.Add(label28);
			groupBox4.Controls.Add(label26);
			groupBox4.Controls.Add(label25);
			groupBox4.Controls.Add(button15);
			groupBox4.Controls.Add(textBox13);
			groupBox4.Controls.Add(textBox14);
			groupBox4.Controls.Add(textBox15);
			groupBox4.Controls.Add(textBox16);
			groupBox4.Controls.Add(textBox17);
			groupBox4.Controls.Add(label19);
			groupBox4.Controls.Add(label20);
			groupBox4.Controls.Add(label21);
			groupBox4.Controls.Add(label22);
			groupBox4.Controls.Add(label23);
			groupBox4.Controls.Add(label24);
			groupBox4.Controls.Add(textBox18);
			groupBox4.Location = new System.Drawing.Point(710, 89);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(282, 208);
			groupBox4.TabIndex = 8;
			groupBox4.TabStop = false;
			groupBox4.Text = "增量数据写入";
			label27.AutoSize = true;
			label27.Location = new System.Drawing.Point(146, 103);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(88, 17);
			label27.TabIndex = 72;
			label27.Text = "X,Y,Z 单位角度";
			label28.AutoSize = true;
			label28.Location = new System.Drawing.Point(146, 86);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(136, 17);
			label28.TabIndex = 71;
			label28.Text = "RX,RY,RZ Unit is angle";
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(146, 41);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(88, 17);
			label26.TabIndex = 70;
			label26.Text = "X,Y,Z 单位毫米";
			label25.AutoSize = true;
			label25.Location = new System.Drawing.Point(146, 24);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(102, 17);
			label25.TabIndex = 69;
			label25.Text = "X,Y,Z Unit is mm";
			button15.Location = new System.Drawing.Point(162, 164);
			button15.Name = "button15";
			button15.Size = new System.Drawing.Size(95, 25);
			button15.TabIndex = 68;
			button15.Text = "写入";
			button15.UseVisualStyleBackColor = true;
			button15.Click += new System.EventHandler(button15_Click);
			textBox13.Location = new System.Drawing.Point(45, 165);
			textBox13.Name = "textBox13";
			textBox13.Size = new System.Drawing.Size(96, 23);
			textBox13.TabIndex = 67;
			textBox13.Text = "0";
			textBox14.Location = new System.Drawing.Point(45, 137);
			textBox14.Name = "textBox14";
			textBox14.Size = new System.Drawing.Size(96, 23);
			textBox14.TabIndex = 64;
			textBox14.Text = "0";
			textBox15.Location = new System.Drawing.Point(45, 108);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(96, 23);
			textBox15.TabIndex = 61;
			textBox15.Text = "0";
			textBox16.Location = new System.Drawing.Point(45, 81);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(96, 23);
			textBox16.TabIndex = 58;
			textBox16.Text = "0";
			textBox17.Location = new System.Drawing.Point(45, 52);
			textBox17.Name = "textBox17";
			textBox17.Size = new System.Drawing.Size(96, 23);
			textBox17.TabIndex = 55;
			textBox17.Text = "0";
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(6, 168);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(25, 17);
			label19.TabIndex = 53;
			label19.Text = "Rz:";
			label20.AutoSize = true;
			label20.Location = new System.Drawing.Point(6, 140);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(25, 17);
			label20.TabIndex = 52;
			label20.Text = "Ry:";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(6, 111);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(25, 17);
			label21.TabIndex = 51;
			label21.Text = "Rx:";
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(5, 82);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(18, 17);
			label22.TabIndex = 50;
			label22.Text = "Z:";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(5, 54);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(18, 17);
			label23.TabIndex = 49;
			label23.Text = "Y:";
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(5, 25);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(19, 17);
			label24.TabIndex = 48;
			label24.Text = "X:";
			textBox18.Location = new System.Drawing.Point(45, 21);
			textBox18.Name = "textBox18";
			textBox18.Size = new System.Drawing.Size(96, 23);
			textBox18.TabIndex = 46;
			textBox18.Text = "0";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(groupBox4);
			base.Controls.Add(groupBox3);
			base.Controls.Add(groupBox2);
			base.Controls.Add(groupBox1);
			base.Controls.Add(panel1);
			base.Controls.Add(userControlHead1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormHyundaiUdp";
			Text = "FormHyundaiUdp";
			base.Load += new System.EventHandler(FormHyundaiUdp_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			ResumeLayout(false);
		}
	}
}
