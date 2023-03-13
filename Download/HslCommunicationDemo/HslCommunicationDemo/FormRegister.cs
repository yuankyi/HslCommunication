using HslCommunication.BasicFramework;
using HslCommunication.LogNet;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormRegister : HslFormContent
	{
		private SoftAuthorize softAuthorize = null;

		private IContainer components = null;

		private Panel panel2;

		private Button button1;

		private Label label6;

		private TextBox textBox3;

		private Label label7;

		private TextBox textBox4;

		private Panel panel1;

		private Label label1;

		private Button button3;

		private Button button2;

		private CheckBox checkBox1;

		private TextBox textBox1;

		private Label label3;

		private Button button4;

		private CheckBox checkBox2;

		private Label label8;

		private UserControlHead userControlHead1;

		public FormRegister()
		{
			InitializeComponent();
		}

		private void FormRegister_Load(object sender, EventArgs e)
		{
			softAuthorize = new SoftAuthorize(Settings1.Default.UseAdmin);
			softAuthorize.ILogNet = new LogNetSingle("log.txt");
			softAuthorize.FileSavePath = Application.StartupPath + "\\Authorize.txt";
			softAuthorize.LoadByFile();
			checkBox2.Checked = Settings1.Default.UseAdmin;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			textBox3.Text = softAuthorize.GetMachineCodeString();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			textBox4.AppendText(DateTime.Now.ToString() + " " + AuthorizeEncrypted(textBox3.Text) + Environment.NewLine);
		}

		private string AuthorizeEncrypted(string origin)
		{
			return SoftSecurity.MD5Encrypt(origin, textBox1.Text);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (!softAuthorize.IsAuthorizeSuccess(AuthorizeEncrypted))
			{
				using (FormAuthorize formAuthorize = new FormAuthorize(softAuthorize, "请联系XXX获取激活码", AuthorizeEncrypted))
				{
					if (formAuthorize.ShowDialog() != DialogResult.OK)
					{
						MessageBox.Show("授权失败！");
					}
					else
					{
						MessageBox.Show("授权成功！");
					}
				}
			}
			else
			{
				MessageBox.Show("授权成功！");
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				textBox1.PasswordChar = '\0';
			}
			else
			{
				textBox1.PasswordChar = '*';
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			try
			{
				File.Delete(Application.StartupPath + "\\Authorize.txt");
				MessageBox.Show("删除成功，重新打开窗口生效。");
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage(ex);
			}
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			Settings1.Default.UseAdmin = checkBox2.Checked;
			Settings1.Default.Save();
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
			checkBox2 = new System.Windows.Forms.CheckBox();
			button4 = new System.Windows.Forms.Button();
			checkBox1 = new System.Windows.Forms.CheckBox();
			textBox1 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			label8 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel2.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(checkBox2);
			panel2.Controls.Add(button4);
			panel2.Controls.Add(checkBox1);
			panel2.Controls.Add(textBox1);
			panel2.Controls.Add(label3);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(button2);
			panel2.Controls.Add(button1);
			panel2.Controls.Add(textBox3);
			panel2.Controls.Add(label7);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label6);
			panel2.Location = new System.Drawing.Point(3, 93);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 549);
			panel2.TabIndex = 8;
			checkBox2.AutoSize = true;
			checkBox2.Location = new System.Drawing.Point(513, 53);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new System.Drawing.Size(135, 21);
			checkBox2.TabIndex = 13;
			checkBox2.Text = "是否使用管理员模式";
			checkBox2.UseVisualStyleBackColor = true;
			checkBox2.CheckedChanged += new System.EventHandler(checkBox2_CheckedChanged);
			button4.Location = new System.Drawing.Point(774, 10);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(132, 26);
			button4.TabIndex = 12;
			button4.Text = "删除验证";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(402, 52);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(99, 21);
			checkBox1.TabIndex = 11;
			checkBox1.Text = "是否显示密钥";
			checkBox1.UseVisualStyleBackColor = true;
			checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
			textBox1.Location = new System.Drawing.Point(74, 50);
			textBox1.Name = "textBox1";
			textBox1.PasswordChar = '*';
			textBox1.Size = new System.Drawing.Size(295, 23);
			textBox1.TabIndex = 10;
			textBox1.Text = "abcdefgh";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(20, 53);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(44, 17);
			label3.TabIndex = 9;
			label3.Text = "密钥：";
			button3.Location = new System.Drawing.Point(623, 10);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(132, 26);
			button3.TabIndex = 8;
			button3.Text = "验证本机是否注册";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button2.Location = new System.Drawing.Point(513, 10);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(86, 26);
			button2.TabIndex = 7;
			button2.Text = "计算注册码";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(402, 10);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(86, 26);
			button1.TabIndex = 6;
			button1.Text = "获取本机码";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox3.Location = new System.Drawing.Point(74, 12);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(295, 23);
			textBox3.TabIndex = 3;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(20, 113);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(44, 17);
			label7.TabIndex = 4;
			label7.Text = "结果：";
			textBox4.Location = new System.Drawing.Point(74, 111);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox4.Size = new System.Drawing.Size(914, 428);
			textBox4.TabIndex = 5;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(20, 15);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(56, 17);
			label6.TabIndex = 2;
			label6.Text = "机器码：";
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(label8);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 54);
			panel1.TabIndex = 7;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(3, 27);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(417, 17);
			label8.TabIndex = 4;
			label8.Text = "如果使用管理员模式则读取物理硬盘号(设置/取消管理员模式后需要重启软件)";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(3, 10);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(809, 17);
			label1.TabIndex = 3;
			label1.Text = "注册码的生成和测试，原理获取cpu号，内存号，硬盘号，主板号，SMBIOS号生成，作为改进后的版本已经在一定程度上能够分别批量采购的计算机。";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7832315.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 9;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormRegister";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "注册码测试";
			base.Load += new System.EventHandler(FormRegister_Load);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
