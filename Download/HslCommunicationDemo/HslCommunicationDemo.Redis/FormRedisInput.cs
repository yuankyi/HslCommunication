using HslCommunication;
using HslCommunication.Enthernet.Redis;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo.Redis
{
	public class FormRedisInput : Form
	{
		private RedisClient redis;

		private IContainer components = null;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private Button button1;

		private TextBox textBox2;

		private Label label2;

		private TextBox textBox1;

		private Label label1;

		private TextBox textBox5;

		private Label label5;

		private Button button2;

		private TextBox textBox3;

		private Label label3;

		private TextBox textBox4;

		private Label label4;

		private TabPage tabPage3;

		private Button button3;

		private TextBox textBox6;

		private Label label6;

		private TextBox textBox7;

		private Label label7;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		public FormRedisInput(RedisClient redis)
		{
			InitializeComponent();
			this.redis = redis;
		}

		private void FormRedisInput_Load(object sender, EventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox1.Text))
			{
				MessageBox.Show("Key Can not be null");
			}
			else
			{
				OperateResult operateResult = redis.WriteKey(textBox1.Text, textBox2.Text);
				if (operateResult.IsSuccess)
				{
					MessageBox.Show("Write sucess");
				}
				else
				{
					MessageBox.Show("Failed:" + operateResult.Message);
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
			{
				MessageBox.Show("Key Can not be null");
			}
			else
			{
				OperateResult operateResult = redis.WriteHashKey(textBox4.Text, textBox5.Text, textBox3.Text);
				if (operateResult.IsSuccess)
				{
					MessageBox.Show("Write sucess");
				}
				else
				{
					MessageBox.Show("Failed:" + operateResult.Message);
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text))
			{
				MessageBox.Show("Key Can not be null");
			}
			else
			{
				OperateResult operateResult = null;
				operateResult = ((!radioButton2.Checked) ? redis.ListLeftPush(textBox7.Text, textBox6.Text) : redis.ListRightPush(textBox7.Text, textBox6.Text));
				if (operateResult.IsSuccess)
				{
					MessageBox.Show("Write sucess");
				}
				else
				{
					MessageBox.Show("Failed:" + operateResult.Message);
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
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			tabPage2 = new System.Windows.Forms.TabPage();
			textBox5 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			tabPage3 = new System.Windows.Forms.TabPage();
			radioButton1 = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			button3 = new System.Windows.Forms.Button();
			textBox6 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			textBox7 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			tabPage3.SuspendLayout();
			SuspendLayout();
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			tabControl1.Location = new System.Drawing.Point(0, 0);
			tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(411, 231);
			tabControl1.TabIndex = 0;
			tabPage1.Controls.Add(button1);
			tabPage1.Controls.Add(textBox2);
			tabPage1.Controls.Add(label2);
			tabPage1.Controls.Add(textBox1);
			tabPage1.Controls.Add(label1);
			tabPage1.Location = new System.Drawing.Point(4, 26);
			tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			tabPage1.Size = new System.Drawing.Size(403, 201);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "键值写入";
			tabPage1.UseVisualStyleBackColor = true;
			button1.Location = new System.Drawing.Point(125, 153);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(140, 31);
			button1.TabIndex = 4;
			button1.Text = "Write";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(98, 63);
			textBox2.Multiline = true;
			textBox2.Name = "textBox2";
			textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox2.Size = new System.Drawing.Size(249, 77);
			textBox2.TabIndex = 3;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(33, 66);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(40, 17);
			label2.TabIndex = 2;
			label2.Text = "Value";
			textBox1.Location = new System.Drawing.Point(98, 24);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(249, 23);
			textBox1.TabIndex = 1;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(33, 27);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(32, 17);
			label1.TabIndex = 0;
			label1.Text = "Key:";
			tabPage2.Controls.Add(textBox5);
			tabPage2.Controls.Add(label5);
			tabPage2.Controls.Add(button2);
			tabPage2.Controls.Add(textBox3);
			tabPage2.Controls.Add(label3);
			tabPage2.Controls.Add(textBox4);
			tabPage2.Controls.Add(label4);
			tabPage2.Location = new System.Drawing.Point(4, 26);
			tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			tabPage2.Size = new System.Drawing.Size(403, 201);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "哈希写入";
			tabPage2.UseVisualStyleBackColor = true;
			textBox5.Location = new System.Drawing.Point(102, 48);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(249, 23);
			textBox5.TabIndex = 11;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(37, 51);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(38, 17);
			label5.TabIndex = 10;
			label5.Text = "Field:";
			button2.Location = new System.Drawing.Point(129, 159);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(140, 31);
			button2.TabIndex = 9;
			button2.Text = "Write";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			textBox3.Location = new System.Drawing.Point(102, 80);
			textBox3.Multiline = true;
			textBox3.Name = "textBox3";
			textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox3.Size = new System.Drawing.Size(249, 66);
			textBox3.TabIndex = 8;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(37, 80);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(40, 17);
			label3.TabIndex = 7;
			label3.Text = "Value";
			textBox4.Location = new System.Drawing.Point(102, 14);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(249, 23);
			textBox4.TabIndex = 6;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(37, 17);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(32, 17);
			label4.TabIndex = 5;
			label4.Text = "Key:";
			tabPage3.Controls.Add(button3);
			tabPage3.Controls.Add(textBox6);
			tabPage3.Controls.Add(label6);
			tabPage3.Controls.Add(textBox7);
			tabPage3.Controls.Add(label7);
			tabPage3.Controls.Add(radioButton2);
			tabPage3.Controls.Add(radioButton1);
			tabPage3.Location = new System.Drawing.Point(4, 26);
			tabPage3.Name = "tabPage3";
			tabPage3.Padding = new System.Windows.Forms.Padding(3);
			tabPage3.Size = new System.Drawing.Size(403, 201);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "列表写入";
			tabPage3.UseVisualStyleBackColor = true;
			radioButton1.AutoSize = true;
			radioButton1.Location = new System.Drawing.Point(68, 6);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(78, 21);
			radioButton1.TabIndex = 0;
			radioButton1.Text = "Left Push";
			radioButton1.UseVisualStyleBackColor = true;
			radioButton2.AutoSize = true;
			radioButton2.Checked = true;
			radioButton2.Location = new System.Drawing.Point(225, 6);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(87, 21);
			radioButton2.TabIndex = 1;
			radioButton2.TabStop = true;
			radioButton2.Text = "Right Push";
			radioButton2.UseVisualStyleBackColor = true;
			button3.Location = new System.Drawing.Point(126, 148);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(140, 31);
			button3.TabIndex = 9;
			button3.Text = "Write";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox6.Location = new System.Drawing.Point(99, 76);
			textBox6.Multiline = true;
			textBox6.Name = "textBox6";
			textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox6.Size = new System.Drawing.Size(249, 61);
			textBox6.TabIndex = 8;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(34, 79);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(40, 17);
			label6.TabIndex = 7;
			label6.Text = "Value";
			textBox7.Location = new System.Drawing.Point(99, 37);
			textBox7.Name = "textBox7";
			textBox7.Size = new System.Drawing.Size(249, 23);
			textBox7.TabIndex = 6;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(34, 40);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(32, 17);
			label7.TabIndex = 5;
			label7.Text = "Key:";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(411, 231);
			base.Controls.Add(tabControl1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormRedisInput";
			base.ShowIcon = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Write Redis";
			base.Load += new System.EventHandler(FormRedisInput_Load);
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			tabPage3.ResumeLayout(false);
			tabPage3.PerformLayout();
			ResumeLayout(false);
		}
	}
}
