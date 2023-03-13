using HslCommunication.BasicFramework;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormMail : HslFormContent
	{
		private IContainer components = null;

		private Panel panel2;

		private Button button3;

		private TextBox textBox4;

		private Label label9;

		private TextBox textBox5;

		private Label label7;

		private Label label1;

		private TextBox textBox1;

		private Panel panel1;

		private Label label3;

		private TextBox textBox2;

		private Button button1;

		private TextBox textBox3;

		private Label label6;

		private TextBox textBox6;

		private Label label8;

		private UserControlHead userControlHead1;

		public FormMail()
		{
			InitializeComponent();
		}

		private void FormMail_Load(object sender, EventArgs e)
		{
			textBox3.Text = "<html><body style=\"background-color:PowderBlue;\"><h1>Look! Styles and colors</h1><p style=\"font-family:verdana;color:red\">This text is in Verdana and red</p><p style=\"font-family:times;color:green\">This text is in Times and green</p><p style=\"font-size:30px\">This text is 30 pixels high</p></body></html> ";
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language == 1)
			{
				Text = "邮件发送测试";
				label7.Text = "发送地址：";
				label9.Text = "主题：";
				label1.Text = "内容：(字符串)";
				textBox1.Text = "测试主题";
				textBox4.Text = "测试内容";
				button3.Text = "发送";
				label8.Text = "发送地址：";
				label6.Text = "主题：";
				label3.Text = "内容：(html)";
				textBox2.Text = "测试主题";
				button1.Text = "发送";
			}
			else
			{
				Text = "Mail Send Test";
				label7.Text = "Address:";
				label9.Text = "Subject:";
				label1.Text = "String Content:";
				textBox1.Text = "Test Subject";
				textBox4.Text = "Test Content";
				button3.Text = "Send";
				label8.Text = "Address:";
				label6.Text = "Subject:";
				label3.Text = "Html Content:";
				textBox2.Text = "Test Subject";
				button1.Text = "Send";
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				SoftMail.MailSystem163.SendMail(textBox5.Text, textBox1.Text, textBox4.Text);
				MessageBox.Show("发送成功！");
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage(ex);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				SoftMail.MailSystem163.SendMail(textBox6.Text, textBox2.Text, textBox3.Text, true);
				MessageBox.Show("发送成功！");
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage(ex);
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
			panel2 = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			button3 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			label3 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel2.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(label1);
			panel2.Controls.Add(textBox1);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label9);
			panel2.Controls.Add(textBox5);
			panel2.Controls.Add(label7);
			panel2.Location = new System.Drawing.Point(13, 51);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(977, 279);
			panel2.TabIndex = 27;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 71);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(88, 17);
			label1.TabIndex = 14;
			label1.Text = "内容：(字符串)";
			textBox1.Location = new System.Drawing.Point(102, 38);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(181, 23);
			textBox1.TabIndex = 13;
			textBox1.Text = "测试主题";
			button3.Location = new System.Drawing.Point(102, 238);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(91, 28);
			button3.TabIndex = 12;
			button3.Text = "发送";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox4.Location = new System.Drawing.Point(102, 68);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(852, 164);
			textBox4.TabIndex = 8;
			textBox4.Text = "测试内容";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(8, 41);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(44, 17);
			label9.TabIndex = 11;
			label9.Text = "主题：";
			textBox5.Location = new System.Drawing.Point(102, 8);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(181, 23);
			textBox5.TabIndex = 9;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(8, 11);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(68, 17);
			label7.TabIndex = 7;
			label7.Text = "发送地址：";
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(textBox6);
			panel1.Controls.Add(label8);
			panel1.Location = new System.Drawing.Point(13, 336);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(977, 297);
			panel1.TabIndex = 28;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(8, 71);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(77, 17);
			label3.TabIndex = 14;
			label3.Text = "内容：(html)";
			textBox2.Location = new System.Drawing.Point(102, 38);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(181, 23);
			textBox2.TabIndex = 13;
			textBox2.Text = "测试主题";
			button1.Location = new System.Drawing.Point(102, 238);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 12;
			button1.Text = "发送";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox3.Location = new System.Drawing.Point(102, 68);
			textBox3.Multiline = true;
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(852, 164);
			textBox3.TabIndex = 8;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(8, 41);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(44, 17);
			label6.TabIndex = 11;
			label6.Text = "主题：";
			textBox6.Location = new System.Drawing.Point(102, 8);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(181, 23);
			textBox6.TabIndex = 9;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(8, 11);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(68, 17);
			label8.TabIndex = 7;
			label8.Text = "发送地址：";
			userControlHead1.BackColor = System.Drawing.Color.MediumPurple;
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/8463613.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "smtp";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 29;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel1);
			base.Controls.Add(panel2);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormMail";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Mail Send Test";
			base.Load += new System.EventHandler(FormMail_Load);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
