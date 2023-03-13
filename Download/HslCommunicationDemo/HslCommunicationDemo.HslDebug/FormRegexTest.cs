using HslCommunication.BasicFramework;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HslCommunicationDemo.HslDebug
{
	public class FormRegexTest : HslFormContent
	{
		private IContainer components = null;

		private TextBox textBox_input;

		private Label label7;

		private Label label1;

		private TextBox textBox_patter;

		private Button button1;

		private Button button2;

		private TextBox textBox_result;

		private Label label2;

		private Button button3;

		private ComboBox comboBox1;

		private Button button4;

		private Button button5;

		private Button button6;

		private Button button7;

		private Button button8;

		private Button button9;

		private Panel panel1;

		private SplitContainer splitContainer1;

		private Panel panel2;

		public FormRegexTest()
		{
			InitializeComponent();
		}

		private void FormRegexTest_Load(object sender, EventArgs e)
		{
			comboBox1.DataSource = SoftBasic.GetEnumValues<RegexOptions>();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox_input.Text))
			{
				MessageBox.Show("Please input string");
			}
			else
			{
				MatchCollection matchCollection = Regex.Matches(textBox_input.Text, textBox_patter.Text, (RegexOptions)comboBox1.SelectedItem);
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("Result Count: ");
				stringBuilder.Append(matchCollection.Count);
				stringBuilder.AppendLine();
				for (int i = 0; i < matchCollection.Count; i++)
				{
					stringBuilder.Append("Result[" + i.ToString() + "]: =============================================================");
					stringBuilder.AppendLine();
					stringBuilder.Append(matchCollection[i].Value);
					stringBuilder.AppendLine();
					stringBuilder.AppendLine();
				}
				textBox_result.Text = stringBuilder.ToString();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			textBox_patter.Text = "[\\u4e00-\\u9fa5]";
		}

		private void button3_Click(object sender, EventArgs e)
		{
			textBox_patter.Text = "[\\w!#$%&'*+/=?^_`{|}~-]+(?:\\.[\\w!#$%&'*+/=?^_`{|}~-]+)*@(?:[\\w](?:[\\w-]*[\\w])?\\.)+[\\w](?:[\\w-]*[\\w])?";
		}

		private void button4_Click(object sender, EventArgs e)
		{
			textBox_patter.Text = "^(\\d{6})(\\d{4})(\\d{2})(\\d{2})(\\d{3})([0-9]|X)$";
		}

		private void button5_Click(object sender, EventArgs e)
		{
			textBox_patter.Text = "((2(5[0-5]|[0-4]\\d))|[0-1]?\\d{1,2})(\\.((2(5[0-5]|[0-4]\\d))|[0-1]?\\d{1,2})){3}";
		}

		private void button6_Click(object sender, EventArgs e)
		{
			textBox_patter.Text = "<(\\S*?)[^>]*>.*?|<.*? />";
		}

		private void button7_Click(object sender, EventArgs e)
		{
			textBox_patter.Text = "^(13[0-9]|14[5|7]|15[0|1|2|3|4|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\\d{8}$";
		}

		private void button8_Click(object sender, EventArgs e)
		{
			textBox_patter.Text = "^\\d{4}-\\d{1,2}-\\d{1,2}";
		}

		private void button9_Click(object sender, EventArgs e)
		{
			textBox_patter.Text = "^[A-Za-z0-9]+$ 或 ^[A-Za-z0-9]{4,40}$";
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
			textBox_input = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			textBox_patter = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			textBox_result = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			comboBox1 = new System.Windows.Forms.ComboBox();
			button4 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			button9 = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			panel2 = new System.Windows.Forms.Panel();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			textBox_input.AllowDrop = true;
			textBox_input.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_input.Location = new System.Drawing.Point(7, 25);
			textBox_input.Multiline = true;
			textBox_input.Name = "textBox_input";
			textBox_input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_input.Size = new System.Drawing.Size(819, 142);
			textBox_input.TabIndex = 11;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(5, 4);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(92, 17);
			label7.TabIndex = 10;
			label7.Text = "输入的字符串：";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(3, 14);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(68, 17);
			label1.TabIndex = 12;
			label1.Text = "正则字符串";
			textBox_patter.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_patter.Location = new System.Drawing.Point(85, 12);
			textBox_patter.Name = "textBox_patter";
			textBox_patter.Size = new System.Drawing.Size(514, 23);
			textBox_patter.TabIndex = 13;
			button1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button1.Location = new System.Drawing.Point(738, 10);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(88, 27);
			button1.TabIndex = 14;
			button1.Text = "匹配";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			button2.Location = new System.Drawing.Point(5, 40);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(68, 27);
			button2.TabIndex = 15;
			button2.Text = "中文";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			textBox_result.AllowDrop = true;
			textBox_result.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_result.Location = new System.Drawing.Point(7, 93);
			textBox_result.Multiline = true;
			textBox_result.Name = "textBox_result";
			textBox_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_result.Size = new System.Drawing.Size(819, 237);
			textBox_result.TabIndex = 17;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(5, 73);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(68, 17);
			label2.TabIndex = 16;
			label2.Text = "匹配结果：";
			button3.Location = new System.Drawing.Point(79, 40);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(78, 27);
			button3.TabIndex = 18;
			button3.Text = "Email";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			comboBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(611, 11);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(121, 25);
			comboBox1.TabIndex = 19;
			button4.Location = new System.Drawing.Point(163, 40);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(78, 27);
			button4.TabIndex = 20;
			button4.Text = "身份证";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button5.Location = new System.Drawing.Point(247, 40);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(78, 27);
			button5.TabIndex = 21;
			button5.Text = "IPv4";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			button6.Location = new System.Drawing.Point(331, 40);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(83, 27);
			button6.TabIndex = 22;
			button6.Text = "Html 标记";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button7.Location = new System.Drawing.Point(420, 40);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(83, 27);
			button7.TabIndex = 23;
			button7.Text = "手机号";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			button8.Location = new System.Drawing.Point(509, 40);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(83, 27);
			button8.TabIndex = 24;
			button8.Text = "日期";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			button9.Location = new System.Drawing.Point(598, 40);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(83, 27);
			button9.TabIndex = 25;
			button9.Text = "英文数字";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(button9);
			panel1.Controls.Add(textBox_patter);
			panel1.Controls.Add(button8);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(button7);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button6);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(button5);
			panel1.Controls.Add(textBox_result);
			panel1.Controls.Add(button4);
			panel1.Controls.Add(button3);
			panel1.Controls.Add(comboBox1);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(834, 335);
			panel1.TabIndex = 26;
			splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer1.Location = new System.Drawing.Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			splitContainer1.Panel1.Controls.Add(panel2);
			splitContainer1.Panel2.Controls.Add(panel1);
			splitContainer1.Size = new System.Drawing.Size(834, 510);
			splitContainer1.SplitterDistance = 171;
			splitContainer1.TabIndex = 27;
			panel2.Controls.Add(label7);
			panel2.Controls.Add(textBox_input);
			panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			panel2.Location = new System.Drawing.Point(0, 0);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(834, 171);
			panel2.TabIndex = 0;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(834, 510);
			base.Controls.Add(splitContainer1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "FormRegexTest";
			Text = "RegexTest";
			base.Load += new System.EventHandler(FormRegexTest_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
