using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Serial;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo.HslDebug
{
	public class FormCheck : HslFormContent
	{
		private IContainer components = null;

		private UserControlHead userControlHead1;

		private GroupBox groupBox1;

		private Label label3;

		private TextBox textBox_crc16;

		private TextBox textBox_crc16_source;

		private Label label2;

		private Label label1;

		private TextBox textBox_crc16_code;

		private Button button_crc16_check;

		private Button button_crc16_calcu;

		private Panel panel1;

		private RadioButton radioButton_crc16_acii;

		private RadioButton radioButton_crc16_hex;

		private TextBox textBox_crc16_fill;

		private Label label4;

		private GroupBox groupBox2;

		private Button button_fcs_check;

		private Button button_fcs_calcu;

		private TextBox textBox_fcs_right;

		private Label label7;

		private TextBox textBox_fcs_left;

		private Label label8;

		private TextBox textBox_fcs;

		private Label label6;

		private TextBox textBox_fcs_source;

		private Label label5;

		private GroupBox groupBox3;

		private Button button_acc_check;

		private Button button_acc_calcu;

		private TextBox textBox_acc_right;

		private Label label9;

		private TextBox textBox_acc_left;

		private Label label10;

		private TextBox textBox_acc;

		private Label label11;

		private TextBox textBox_acc_source;

		private Label label12;

		private GroupBox groupBox4;

		private Button button_lrc_check;

		private Button button_lrc_calcu;

		private TextBox textBox_lrc_right;

		private Label label13;

		private TextBox textBox_lrc_left;

		private Label label14;

		private TextBox textBox_lrc;

		private Label label15;

		private TextBox textBox_lrc_source;

		private Label label16;

		private Panel panel2;

		private RadioButton radioButton_fcs_ascii;

		private RadioButton radioButton_fcs_hex;

		private Panel panel3;

		private RadioButton radioButton_acc_ascii;

		private RadioButton radioButton_acc_hex;

		private Panel panel4;

		private RadioButton radioButton_lrc_ascii;

		private RadioButton radioButton_lrc_hex;

		private TextBox textBox_crc16_ascii;

		private TextBox textBox_fcs_ascii;

		private TextBox textBox_acc_ascii;

		private TextBox textBox_lrc_ascii;

		public FormCheck()
		{
			InitializeComponent();
		}

		private void FormCheck_Load(object sender, EventArgs e)
		{
		}

		private void button_crc16_calcu_Click(object sender, EventArgs e)
		{
			byte[] array = textBox_crc16_code.Text.ToHexBytes();
			byte[] array2 = textBox_crc16_fill.Text.ToHexBytes();
			byte[] array3 = radioButton_crc16_hex.Checked ? textBox_crc16_source.Text.ToHexBytes() : SoftBasic.GetFromAsciiStringRender(textBox_crc16_source.Text);
			byte[] array4 = SoftCRC16.CRC16Only(array3, 0, array3.Length, array[0], array[1], array2[0], array2[1]);
			textBox_crc16.Text = array4.ToHexString(' ');
			textBox_crc16_ascii.Text = SoftBasic.GetAsciiStringRender(array4);
		}

		private void button_crc16_check_Click(object sender, EventArgs e)
		{
			byte[] value = radioButton_crc16_hex.Checked ? textBox_crc16_source.Text.ToHexBytes() : SoftBasic.GetFromAsciiStringRender(textBox_crc16_source.Text);
			MessageBox.Show(SoftCRC16.CheckCRC16(value) ? "Good!" : "Bad!");
		}

		private byte[] GetFcs(byte[] source, int left, int right)
		{
			int num = source[left];
			for (int i = left + 1; i < source.Length - right; i++)
			{
				num ^= source[i];
			}
			return new byte[2]
			{
				SoftBasic.BuildAsciiBytesFrom((byte)num)[0],
				SoftBasic.BuildAsciiBytesFrom((byte)num)[1]
			};
		}

		private void button_fcs_calcu_Click(object sender, EventArgs e)
		{
			byte[] source = radioButton_fcs_hex.Checked ? textBox_fcs_source.Text.ToHexBytes() : SoftBasic.GetFromAsciiStringRender(textBox_fcs_source.Text);
			int left = Convert.ToInt32(textBox_fcs_left.Text);
			int right = Convert.ToInt32(textBox_fcs_right.Text);
			byte[] fcs = GetFcs(source, left, right);
			textBox_fcs.Text = fcs.ToHexString(' ');
			textBox_fcs_ascii.Text = SoftBasic.GetAsciiStringRender(fcs);
		}

		private void button_fcs_check_Click(object sender, EventArgs e)
		{
			byte[] array = radioButton_fcs_hex.Checked ? textBox_fcs_source.Text.ToHexBytes() : SoftBasic.GetFromAsciiStringRender(textBox_fcs_source.Text);
			int left = Convert.ToInt32(textBox_fcs_left.Text);
			int num = Convert.ToInt32(textBox_fcs_right.Text);
			byte[] fcs = GetFcs(array, left, num);
			MessageBox.Show((array[array.Length - num] == fcs[0] && array[array.Length - num + 1] == fcs[1]) ? "Good!" : "Bad!");
		}

		private void button_acc_calcu_Click(object sender, EventArgs e)
		{
			byte[] buffer = radioButton_acc_hex.Checked ? textBox_acc_source.Text.ToHexBytes() : SoftBasic.GetFromAsciiStringRender(textBox_acc_source.Text);
			int headCount = Convert.ToInt32(textBox_acc_left.Text);
			int lastCount = Convert.ToInt32(textBox_acc_right.Text);
			byte[] array = new byte[1]
			{
				(byte)SoftLRC.CalculateAcc(buffer, headCount, lastCount)
			};
			textBox_acc.Text = array.ToHexString(' ');
			textBox_acc_ascii.Text = SoftBasic.GetAsciiStringRender(array);
		}

		private void button_acc_check_Click(object sender, EventArgs e)
		{
			byte[] buffer = radioButton_acc_hex.Checked ? textBox_acc_source.Text.ToHexBytes() : SoftBasic.GetFromAsciiStringRender(textBox_acc_source.Text);
			int headCount = Convert.ToInt32(textBox_acc_left.Text);
			int lastCount = Convert.ToInt32(textBox_acc_right.Text);
			MessageBox.Show(SoftLRC.CalculateAccAndCheck(buffer, headCount, lastCount) ? "Good!" : "Bad!");
		}

		private byte GetLRC(byte[] source, int left, int right)
		{
			int num = 0;
			for (int i = left; i < source.Length - right; i++)
			{
				num += source[i];
			}
			num %= 256;
			num = 256 - num;
			return (byte)num;
		}

		private void button_lrc_calcu_Click(object sender, EventArgs e)
		{
			byte[] source = radioButton_lrc_hex.Checked ? textBox_lrc_source.Text.ToHexBytes() : SoftBasic.GetFromAsciiStringRender(textBox_lrc_source.Text);
			int left = Convert.ToInt32(textBox_lrc_left.Text);
			int right = Convert.ToInt32(textBox_lrc_right.Text);
			byte[] array = new byte[1]
			{
				GetLRC(source, left, right)
			};
			textBox_lrc.Text = array.ToHexString(' ');
			textBox_lrc_ascii.Text = SoftBasic.GetAsciiStringRender(array);
		}

		private void button_lrc_check_Click(object sender, EventArgs e)
		{
			byte[] array = radioButton_lrc_hex.Checked ? textBox_lrc_source.Text.ToHexBytes() : SoftBasic.GetFromAsciiStringRender(textBox_lrc_source.Text);
			int left = Convert.ToInt32(textBox_lrc_left.Text);
			int num = Convert.ToInt32(textBox_lrc_right.Text);
			byte[] array2 = new byte[1]
			{
				GetLRC(array, left, num)
			};
			MessageBox.Show((array[array.Length - num] == array2[0]) ? "Good!" : "Bad!");
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
			groupBox1 = new System.Windows.Forms.GroupBox();
			button_crc16_check = new System.Windows.Forms.Button();
			button_crc16_calcu = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			radioButton_crc16_acii = new System.Windows.Forms.RadioButton();
			radioButton_crc16_hex = new System.Windows.Forms.RadioButton();
			textBox_crc16_fill = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox_crc16_code = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox_crc16 = new System.Windows.Forms.TextBox();
			textBox_crc16_source = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			panel2 = new System.Windows.Forms.Panel();
			radioButton_fcs_ascii = new System.Windows.Forms.RadioButton();
			radioButton_fcs_hex = new System.Windows.Forms.RadioButton();
			button_fcs_check = new System.Windows.Forms.Button();
			button_fcs_calcu = new System.Windows.Forms.Button();
			textBox_fcs_right = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			textBox_fcs_left = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			textBox_fcs = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			textBox_fcs_source = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			panel3 = new System.Windows.Forms.Panel();
			radioButton_acc_ascii = new System.Windows.Forms.RadioButton();
			radioButton_acc_hex = new System.Windows.Forms.RadioButton();
			button_acc_check = new System.Windows.Forms.Button();
			button_acc_calcu = new System.Windows.Forms.Button();
			textBox_acc_right = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			textBox_acc_left = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			textBox_acc = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			textBox_acc_source = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			groupBox4 = new System.Windows.Forms.GroupBox();
			panel4 = new System.Windows.Forms.Panel();
			radioButton_lrc_ascii = new System.Windows.Forms.RadioButton();
			radioButton_lrc_hex = new System.Windows.Forms.RadioButton();
			button_lrc_check = new System.Windows.Forms.Button();
			button_lrc_calcu = new System.Windows.Forms.Button();
			textBox_lrc_right = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			textBox_lrc_left = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			textBox_lrc = new System.Windows.Forms.TextBox();
			label15 = new System.Windows.Forms.Label();
			textBox_lrc_source = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			textBox_crc16_ascii = new System.Windows.Forms.TextBox();
			textBox_fcs_ascii = new System.Windows.Forms.TextBox();
			textBox_acc_ascii = new System.Windows.Forms.TextBox();
			textBox_lrc_ascii = new System.Windows.Forms.TextBox();
			groupBox1.SuspendLayout();
			panel1.SuspendLayout();
			groupBox2.SuspendLayout();
			panel2.SuspendLayout();
			groupBox3.SuspendLayout();
			panel3.SuspendLayout();
			groupBox4.SuspendLayout();
			panel4.SuspendLayout();
			SuspendLayout();
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.hslcommunication.cn/";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "各种校验调试";
			userControlHead1.Size = new System.Drawing.Size(984, 32);
			userControlHead1.TabIndex = 15;
			groupBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox1.Controls.Add(textBox_crc16_ascii);
			groupBox1.Controls.Add(button_crc16_check);
			groupBox1.Controls.Add(button_crc16_calcu);
			groupBox1.Controls.Add(panel1);
			groupBox1.Controls.Add(textBox_crc16_fill);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(textBox_crc16_code);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(textBox_crc16);
			groupBox1.Controls.Add(textBox_crc16_source);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label1);
			groupBox1.Location = new System.Drawing.Point(4, 35);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(978, 119);
			groupBox1.TabIndex = 16;
			groupBox1.TabStop = false;
			groupBox1.Text = "CRC16 (常用于 Modbus 协议)";
			button_crc16_check.Location = new System.Drawing.Point(877, 80);
			button_crc16_check.Name = "button_crc16_check";
			button_crc16_check.Size = new System.Drawing.Size(91, 27);
			button_crc16_check.TabIndex = 10;
			button_crc16_check.Text = "校验CRC";
			button_crc16_check.UseVisualStyleBackColor = true;
			button_crc16_check.Click += new System.EventHandler(button_crc16_check_Click);
			button_crc16_calcu.Location = new System.Drawing.Point(763, 80);
			button_crc16_calcu.Name = "button_crc16_calcu";
			button_crc16_calcu.Size = new System.Drawing.Size(108, 27);
			button_crc16_calcu.TabIndex = 9;
			button_crc16_calcu.Text = "计算CRC";
			button_crc16_calcu.UseVisualStyleBackColor = true;
			button_crc16_calcu.Click += new System.EventHandler(button_crc16_calcu_Click);
			panel1.Controls.Add(radioButton_crc16_acii);
			panel1.Controls.Add(radioButton_crc16_hex);
			panel1.Location = new System.Drawing.Point(615, 78);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(142, 34);
			panel1.TabIndex = 8;
			radioButton_crc16_acii.AutoSize = true;
			radioButton_crc16_acii.Location = new System.Drawing.Point(65, 5);
			radioButton_crc16_acii.Name = "radioButton_crc16_acii";
			radioButton_crc16_acii.Size = new System.Drawing.Size(57, 21);
			radioButton_crc16_acii.TabIndex = 1;
			radioButton_crc16_acii.Text = "ASCII";
			radioButton_crc16_acii.UseVisualStyleBackColor = true;
			radioButton_crc16_hex.AutoSize = true;
			radioButton_crc16_hex.Checked = true;
			radioButton_crc16_hex.Location = new System.Drawing.Point(6, 5);
			radioButton_crc16_hex.Name = "radioButton_crc16_hex";
			radioButton_crc16_hex.Size = new System.Drawing.Size(48, 21);
			radioButton_crc16_hex.TabIndex = 0;
			radioButton_crc16_hex.TabStop = true;
			radioButton_crc16_hex.Text = "Hex";
			radioButton_crc16_hex.UseVisualStyleBackColor = true;
			textBox_crc16_fill.Location = new System.Drawing.Point(537, 82);
			textBox_crc16_fill.Name = "textBox_crc16_fill";
			textBox_crc16_fill.Size = new System.Drawing.Size(70, 23);
			textBox_crc16_fill.TabIndex = 7;
			textBox_crc16_fill.Text = "FFFF";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(472, 85);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(68, 17);
			label4.TabIndex = 6;
			label4.Text = "填充因子：";
			textBox_crc16_code.Location = new System.Drawing.Point(388, 82);
			textBox_crc16_code.Name = "textBox_crc16_code";
			textBox_crc16_code.Size = new System.Drawing.Size(70, 23);
			textBox_crc16_code.TabIndex = 5;
			textBox_crc16_code.Text = "A001";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(324, 85);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 4;
			label3.Text = "多项式：";
			textBox_crc16.Location = new System.Drawing.Point(114, 82);
			textBox_crc16.Name = "textBox_crc16";
			textBox_crc16.Size = new System.Drawing.Size(89, 23);
			textBox_crc16.TabIndex = 3;
			textBox_crc16_source.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_crc16_source.Location = new System.Drawing.Point(114, 22);
			textBox_crc16_source.Multiline = true;
			textBox_crc16_source.Name = "textBox_crc16_source";
			textBox_crc16_source.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_crc16_source.Size = new System.Drawing.Size(853, 52);
			textBox_crc16_source.TabIndex = 2;
			textBox_crc16_source.Text = "01 03 00 00 00 01";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(9, 85);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(82, 17);
			label2.TabIndex = 1;
			label2.Text = "CRC16(ascii):";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(9, 25);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(68, 17);
			label1.TabIndex = 0;
			label1.Text = "原始数据：";
			groupBox2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox2.Controls.Add(textBox_fcs_ascii);
			groupBox2.Controls.Add(panel2);
			groupBox2.Controls.Add(button_fcs_check);
			groupBox2.Controls.Add(button_fcs_calcu);
			groupBox2.Controls.Add(textBox_fcs_right);
			groupBox2.Controls.Add(label7);
			groupBox2.Controls.Add(textBox_fcs_left);
			groupBox2.Controls.Add(label8);
			groupBox2.Controls.Add(textBox_fcs);
			groupBox2.Controls.Add(label6);
			groupBox2.Controls.Add(textBox_fcs_source);
			groupBox2.Controls.Add(label5);
			groupBox2.Location = new System.Drawing.Point(4, 160);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(978, 118);
			groupBox2.TabIndex = 17;
			groupBox2.TabStop = false;
			groupBox2.Text = "FCS,异或校验（用于 OmronHostlink） ";
			panel2.Controls.Add(radioButton_fcs_ascii);
			panel2.Controls.Add(radioButton_fcs_hex);
			panel2.Location = new System.Drawing.Point(615, 81);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(142, 34);
			panel2.TabIndex = 14;
			radioButton_fcs_ascii.AutoSize = true;
			radioButton_fcs_ascii.Checked = true;
			radioButton_fcs_ascii.Location = new System.Drawing.Point(65, 5);
			radioButton_fcs_ascii.Name = "radioButton_fcs_ascii";
			radioButton_fcs_ascii.Size = new System.Drawing.Size(57, 21);
			radioButton_fcs_ascii.TabIndex = 1;
			radioButton_fcs_ascii.TabStop = true;
			radioButton_fcs_ascii.Text = "ASCII";
			radioButton_fcs_ascii.UseVisualStyleBackColor = true;
			radioButton_fcs_hex.AutoSize = true;
			radioButton_fcs_hex.Location = new System.Drawing.Point(6, 5);
			radioButton_fcs_hex.Name = "radioButton_fcs_hex";
			radioButton_fcs_hex.Size = new System.Drawing.Size(48, 21);
			radioButton_fcs_hex.TabIndex = 0;
			radioButton_fcs_hex.Text = "Hex";
			radioButton_fcs_hex.UseVisualStyleBackColor = true;
			button_fcs_check.Location = new System.Drawing.Point(877, 85);
			button_fcs_check.Name = "button_fcs_check";
			button_fcs_check.Size = new System.Drawing.Size(91, 27);
			button_fcs_check.TabIndex = 13;
			button_fcs_check.Text = "校验FCS";
			button_fcs_check.UseVisualStyleBackColor = true;
			button_fcs_check.Click += new System.EventHandler(button_fcs_check_Click);
			button_fcs_calcu.Location = new System.Drawing.Point(763, 85);
			button_fcs_calcu.Name = "button_fcs_calcu";
			button_fcs_calcu.Size = new System.Drawing.Size(108, 27);
			button_fcs_calcu.TabIndex = 12;
			button_fcs_calcu.Text = "计算FCS";
			button_fcs_calcu.UseVisualStyleBackColor = true;
			button_fcs_calcu.Click += new System.EventHandler(button_fcs_calcu_Click);
			textBox_fcs_right.Location = new System.Drawing.Point(549, 85);
			textBox_fcs_right.Name = "textBox_fcs_right";
			textBox_fcs_right.Size = new System.Drawing.Size(60, 23);
			textBox_fcs_right.TabIndex = 11;
			textBox_fcs_right.Text = "4";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(469, 88);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(80, 17);
			label7.TabIndex = 10;
			label7.Text = "尾部字节数：";
			textBox_fcs_left.Location = new System.Drawing.Point(397, 85);
			textBox_fcs_left.Name = "textBox_fcs_left";
			textBox_fcs_left.Size = new System.Drawing.Size(57, 23);
			textBox_fcs_left.TabIndex = 9;
			textBox_fcs_left.Text = "0";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(324, 88);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(80, 17);
			label8.TabIndex = 8;
			label8.Text = "头部字节数：";
			textBox_fcs.Location = new System.Drawing.Point(114, 85);
			textBox_fcs.Name = "textBox_fcs";
			textBox_fcs.Size = new System.Drawing.Size(89, 23);
			textBox_fcs.TabIndex = 6;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(10, 88);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(71, 17);
			label6.TabIndex = 5;
			label6.Text = "FCS(ASCII):";
			textBox_fcs_source.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_fcs_source.Location = new System.Drawing.Point(114, 27);
			textBox_fcs_source.Multiline = true;
			textBox_fcs_source.Name = "textBox_fcs_source";
			textBox_fcs_source.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_fcs_source.Size = new System.Drawing.Size(854, 52);
			textBox_fcs_source.TabIndex = 4;
			textBox_fcs_source.Text = "@00FA00000000001018200000000017C*\\0D";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(10, 30);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(68, 17);
			label5.TabIndex = 3;
			label5.Text = "原始数据：";
			groupBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox3.Controls.Add(textBox_acc_ascii);
			groupBox3.Controls.Add(panel3);
			groupBox3.Controls.Add(button_acc_check);
			groupBox3.Controls.Add(button_acc_calcu);
			groupBox3.Controls.Add(textBox_acc_right);
			groupBox3.Controls.Add(label9);
			groupBox3.Controls.Add(textBox_acc_left);
			groupBox3.Controls.Add(label10);
			groupBox3.Controls.Add(textBox_acc);
			groupBox3.Controls.Add(label11);
			groupBox3.Controls.Add(textBox_acc_source);
			groupBox3.Controls.Add(label12);
			groupBox3.Location = new System.Drawing.Point(4, 284);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(978, 118);
			groupBox3.TabIndex = 18;
			groupBox3.TabStop = false;
			groupBox3.Text = "ACC,和校验（用于 MelsecFxLinks） ";
			panel3.Controls.Add(radioButton_acc_ascii);
			panel3.Controls.Add(radioButton_acc_hex);
			panel3.Location = new System.Drawing.Point(615, 80);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(142, 34);
			panel3.TabIndex = 15;
			radioButton_acc_ascii.AutoSize = true;
			radioButton_acc_ascii.Checked = true;
			radioButton_acc_ascii.Location = new System.Drawing.Point(65, 5);
			radioButton_acc_ascii.Name = "radioButton_acc_ascii";
			radioButton_acc_ascii.Size = new System.Drawing.Size(57, 21);
			radioButton_acc_ascii.TabIndex = 1;
			radioButton_acc_ascii.TabStop = true;
			radioButton_acc_ascii.Text = "ASCII";
			radioButton_acc_ascii.UseVisualStyleBackColor = true;
			radioButton_acc_hex.AutoSize = true;
			radioButton_acc_hex.Location = new System.Drawing.Point(6, 5);
			radioButton_acc_hex.Name = "radioButton_acc_hex";
			radioButton_acc_hex.Size = new System.Drawing.Size(48, 21);
			radioButton_acc_hex.TabIndex = 0;
			radioButton_acc_hex.Text = "Hex";
			radioButton_acc_hex.UseVisualStyleBackColor = true;
			button_acc_check.Location = new System.Drawing.Point(877, 83);
			button_acc_check.Name = "button_acc_check";
			button_acc_check.Size = new System.Drawing.Size(91, 27);
			button_acc_check.TabIndex = 13;
			button_acc_check.Text = "校验ACC";
			button_acc_check.UseVisualStyleBackColor = true;
			button_acc_check.Click += new System.EventHandler(button_acc_check_Click);
			button_acc_calcu.Location = new System.Drawing.Point(763, 83);
			button_acc_calcu.Name = "button_acc_calcu";
			button_acc_calcu.Size = new System.Drawing.Size(108, 27);
			button_acc_calcu.TabIndex = 12;
			button_acc_calcu.Text = "计算ACC";
			button_acc_calcu.UseVisualStyleBackColor = true;
			button_acc_calcu.Click += new System.EventHandler(button_acc_calcu_Click);
			textBox_acc_right.Location = new System.Drawing.Point(549, 85);
			textBox_acc_right.Name = "textBox_acc_right";
			textBox_acc_right.Size = new System.Drawing.Size(60, 23);
			textBox_acc_right.TabIndex = 11;
			textBox_acc_right.Text = "2";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(469, 88);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(80, 17);
			label9.TabIndex = 10;
			label9.Text = "尾部字节数：";
			textBox_acc_left.Location = new System.Drawing.Point(397, 85);
			textBox_acc_left.Name = "textBox_acc_left";
			textBox_acc_left.Size = new System.Drawing.Size(57, 23);
			textBox_acc_left.TabIndex = 9;
			textBox_acc_left.Text = "1";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(324, 88);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(80, 17);
			label10.TabIndex = 8;
			label10.Text = "头部字节数：";
			textBox_acc.Location = new System.Drawing.Point(114, 85);
			textBox_acc.Name = "textBox_acc";
			textBox_acc.Size = new System.Drawing.Size(89, 23);
			textBox_acc.TabIndex = 6;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(10, 88);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(74, 17);
			label11.TabIndex = 5;
			label11.Text = "ACC(ASCII):";
			textBox_acc_source.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_acc_source.Location = new System.Drawing.Point(114, 27);
			textBox_acc_source.Multiline = true;
			textBox_acc_source.Name = "textBox_acc_source";
			textBox_acc_source.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_acc_source.Size = new System.Drawing.Size(854, 52);
			textBox_acc_source.TabIndex = 4;
			textBox_acc_source.Text = "\\0500FFWR0D0100012B";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(10, 30);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(68, 17);
			label12.TabIndex = 3;
			label12.Text = "原始数据：";
			groupBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox4.Controls.Add(textBox_lrc_ascii);
			groupBox4.Controls.Add(panel4);
			groupBox4.Controls.Add(button_lrc_check);
			groupBox4.Controls.Add(button_lrc_calcu);
			groupBox4.Controls.Add(textBox_lrc_right);
			groupBox4.Controls.Add(label13);
			groupBox4.Controls.Add(textBox_lrc_left);
			groupBox4.Controls.Add(label14);
			groupBox4.Controls.Add(textBox_lrc);
			groupBox4.Controls.Add(label15);
			groupBox4.Controls.Add(textBox_lrc_source);
			groupBox4.Controls.Add(label16);
			groupBox4.Location = new System.Drawing.Point(4, 408);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(978, 118);
			groupBox4.TabIndex = 19;
			groupBox4.TabStop = false;
			groupBox4.Text = "LRC（用于 ModbusASCII） ";
			panel4.Controls.Add(radioButton_lrc_ascii);
			panel4.Controls.Add(radioButton_lrc_hex);
			panel4.Location = new System.Drawing.Point(616, 81);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(142, 34);
			panel4.TabIndex = 16;
			radioButton_lrc_ascii.AutoSize = true;
			radioButton_lrc_ascii.Location = new System.Drawing.Point(65, 5);
			radioButton_lrc_ascii.Name = "radioButton_lrc_ascii";
			radioButton_lrc_ascii.Size = new System.Drawing.Size(57, 21);
			radioButton_lrc_ascii.TabIndex = 1;
			radioButton_lrc_ascii.Text = "ASCII";
			radioButton_lrc_ascii.UseVisualStyleBackColor = true;
			radioButton_lrc_hex.AutoSize = true;
			radioButton_lrc_hex.Checked = true;
			radioButton_lrc_hex.Location = new System.Drawing.Point(6, 5);
			radioButton_lrc_hex.Name = "radioButton_lrc_hex";
			radioButton_lrc_hex.Size = new System.Drawing.Size(48, 21);
			radioButton_lrc_hex.TabIndex = 0;
			radioButton_lrc_hex.TabStop = true;
			radioButton_lrc_hex.Text = "Hex";
			radioButton_lrc_hex.UseVisualStyleBackColor = true;
			button_lrc_check.Location = new System.Drawing.Point(878, 83);
			button_lrc_check.Name = "button_lrc_check";
			button_lrc_check.Size = new System.Drawing.Size(91, 27);
			button_lrc_check.TabIndex = 13;
			button_lrc_check.Text = "校验LRC";
			button_lrc_check.UseVisualStyleBackColor = true;
			button_lrc_check.Click += new System.EventHandler(button_lrc_check_Click);
			button_lrc_calcu.Location = new System.Drawing.Point(764, 83);
			button_lrc_calcu.Name = "button_lrc_calcu";
			button_lrc_calcu.Size = new System.Drawing.Size(108, 27);
			button_lrc_calcu.TabIndex = 12;
			button_lrc_calcu.Text = "计算LRC";
			button_lrc_calcu.UseVisualStyleBackColor = true;
			button_lrc_calcu.Click += new System.EventHandler(button_lrc_calcu_Click);
			textBox_lrc_right.Location = new System.Drawing.Point(549, 85);
			textBox_lrc_right.Name = "textBox_lrc_right";
			textBox_lrc_right.Size = new System.Drawing.Size(60, 23);
			textBox_lrc_right.TabIndex = 11;
			textBox_lrc_right.Text = "1";
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(469, 88);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(80, 17);
			label13.TabIndex = 10;
			label13.Text = "尾部字节数：";
			textBox_lrc_left.Location = new System.Drawing.Point(397, 85);
			textBox_lrc_left.Name = "textBox_lrc_left";
			textBox_lrc_left.Size = new System.Drawing.Size(57, 23);
			textBox_lrc_left.TabIndex = 9;
			textBox_lrc_left.Text = "0";
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(324, 88);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(80, 17);
			label14.TabIndex = 8;
			label14.Text = "头部字节数：";
			textBox_lrc.Location = new System.Drawing.Point(114, 85);
			textBox_lrc.Name = "textBox_lrc";
			textBox_lrc.Size = new System.Drawing.Size(89, 23);
			textBox_lrc.TabIndex = 6;
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(10, 88);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(72, 17);
			label15.TabIndex = 5;
			label15.Text = "LRC(ASCII):";
			textBox_lrc_source.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_lrc_source.Location = new System.Drawing.Point(114, 27);
			textBox_lrc_source.Multiline = true;
			textBox_lrc_source.Name = "textBox_lrc_source";
			textBox_lrc_source.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_lrc_source.Size = new System.Drawing.Size(854, 52);
			textBox_lrc_source.TabIndex = 4;
			textBox_lrc_source.Text = "01 03 00 64 00 01 97";
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(10, 30);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(68, 17);
			label16.TabIndex = 3;
			label16.Text = "原始数据：";
			textBox_crc16_ascii.Location = new System.Drawing.Point(209, 82);
			textBox_crc16_ascii.Name = "textBox_crc16_ascii";
			textBox_crc16_ascii.Size = new System.Drawing.Size(89, 23);
			textBox_crc16_ascii.TabIndex = 11;
			textBox_fcs_ascii.Location = new System.Drawing.Point(209, 85);
			textBox_fcs_ascii.Name = "textBox_fcs_ascii";
			textBox_fcs_ascii.Size = new System.Drawing.Size(89, 23);
			textBox_fcs_ascii.TabIndex = 15;
			textBox_acc_ascii.Location = new System.Drawing.Point(209, 85);
			textBox_acc_ascii.Name = "textBox_acc_ascii";
			textBox_acc_ascii.Size = new System.Drawing.Size(89, 23);
			textBox_acc_ascii.TabIndex = 16;
			textBox_lrc_ascii.Location = new System.Drawing.Point(209, 85);
			textBox_lrc_ascii.Name = "textBox_lrc_ascii";
			textBox_lrc_ascii.Size = new System.Drawing.Size(89, 23);
			textBox_lrc_ascii.TabIndex = 17;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(984, 598);
			base.Controls.Add(groupBox4);
			base.Controls.Add(groupBox3);
			base.Controls.Add(groupBox2);
			base.Controls.Add(groupBox1);
			base.Controls.Add(userControlHead1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "FormCheck";
			Text = "FormCheck";
			base.Load += new System.EventHandler(FormCheck_Load);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			ResumeLayout(false);
		}
	}
}
