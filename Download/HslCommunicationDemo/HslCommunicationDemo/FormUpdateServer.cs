using HslCommunication.Enthernet;
using HslCommunication.LogNet;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormUpdateServer : HslFormContent
	{
		private NetSoftUpdateServer updateServer;

		private IContainer components = null;

		private UserControlHead userControlHead1;

		private Panel panel2;

		private Button button3;

		private Button button2;

		private TextBox textBox4;

		private Label label9;

		private Panel panel1;

		private TextBox textBox3;

		private Label label6;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		public FormUpdateServer()
		{
			InitializeComponent();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			try
			{
				updateServer = new NetSoftUpdateServer();
				updateServer.FileUpdatePath = textBox3.Text;
				updateServer.LogNet = new LogNetSingle(Path.Combine(Application.StartupPath, "log.txt"));
				updateServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
				updateServer.ServerStart(int.Parse(textBox2.Text));
				button1.Enabled = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show("启动失败：" + ex.Message);
			}
		}

		private void LogNet_BeforeSaveToFile(object sender, HslEventArgs e)
		{
			Invoke((Action)delegate
			{
				textBox4.AppendText(e.HslMessage.ToString() + Environment.NewLine);
			});
			e.HslMessage.Cancel = true;
		}

		private void FormUpdateServer_Load(object sender, EventArgs e)
		{
			textBox3.Text = Application.StartupPath;
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			textBox4.Clear();
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			textBox4.Lines = NetSoftUpdateServer.GetAllFiles(textBox3.Text, null).ToArray();
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
			panel2 = new System.Windows.Forms.Panel();
			textBox4 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			panel2.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 15;
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(button3);
			panel2.Controls.Add(button2);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label9);
			panel2.Location = new System.Drawing.Point(12, 119);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(977, 518);
			panel2.TabIndex = 17;
			textBox4.Location = new System.Drawing.Point(62, 36);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(892, 477);
			textBox4.TabIndex = 8;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(8, 39);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(44, 17);
			label9.TabIndex = 11;
			label9.Text = "日志：";
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(12, 40);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(978, 72);
			panel1.TabIndex = 16;
			textBox3.Location = new System.Drawing.Point(62, 41);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(633, 23);
			textBox3.TabIndex = 7;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(8, 44);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(44, 17);
			label6.TabIndex = 6;
			label6.Text = "目录：";
			button1.Location = new System.Drawing.Point(733, 5);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "启动";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1_Click);
			textBox2.Location = new System.Drawing.Point(62, 8);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(141, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "12345";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(8, 11);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			button2.Location = new System.Drawing.Point(766, 5);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 12;
			button2.Text = "测试目录文件获取";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(Button2_Click);
			button3.Location = new System.Drawing.Point(863, 5);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(91, 28);
			button3.TabIndex = 13;
			button3.Text = "清空";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(Button3_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			base.Controls.Add(userControlHead1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormUpdateServer";
			Text = "更新服务器的测试";
			base.Load += new System.EventHandler(FormUpdateServer_Load);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
