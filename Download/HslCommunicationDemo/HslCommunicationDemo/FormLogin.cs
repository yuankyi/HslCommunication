using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormLogin : Form
	{
		private IContainer components = null;

		private Label label1;

		private TextBox textBox1;

		private TextBox textBox2;

		private Label label2;

		private Button button1;

		private Label label3;

		private LinkLabel linkLabel1;

		public FormLogin()
		{
			InitializeComponent();
		}

		private void FormLogin_Load(object sender, EventArgs e)
		{
			textBox1.Text = "admin";
			textBox2.Text = "123456";
			label3.Text = Program.SystemName;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "admin" && textBox2.Text == "123456")
			{
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				MessageBox.Show("用户名或密码错误，请重新输入！");
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
			label1 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			textBox2 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(63, 73);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "用户名：";
			textBox1.Location = new System.Drawing.Point(146, 69);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(204, 23);
			textBox1.TabIndex = 1;
			textBox2.Location = new System.Drawing.Point(146, 109);
			textBox2.Name = "textBox2";
			textBox2.PasswordChar = '*';
			textBox2.Size = new System.Drawing.Size(204, 23);
			textBox2.TabIndex = 3;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(63, 113);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 17);
			label2.TabIndex = 2;
			label2.Text = "密码：";
			button1.Location = new System.Drawing.Point(146, 158);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(119, 31);
			button1.TabIndex = 4;
			button1.Text = "登录";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			label3.Font = new System.Drawing.Font("微软雅黑", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label3.Location = new System.Drawing.Point(12, 9);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(381, 57);
			label3.TabIndex = 5;
			label3.Text = "xxxx";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new System.Drawing.Point(327, 198);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(68, 17);
			linkLabel1.TabIndex = 6;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "忘记密码？";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(405, 224);
			base.Controls.Add(linkLabel1);
			base.Controls.Add(label3);
			base.Controls.Add(button1);
			base.Controls.Add(textBox2);
			base.Controls.Add(label2);
			base.Controls.Add(textBox1);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormLogin";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Login";
			base.Load += new System.EventHandler(FormLogin_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
