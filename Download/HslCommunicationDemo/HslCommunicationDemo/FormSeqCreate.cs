using HslCommunication.BasicFramework;
using HslCommunication.Controls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormSeqCreate : HslFormContent
	{
		private SoftNumericalOrder softNumericalOrder;

		private IContainer components = null;

		private Label label1;

		private UserButton userButton3;

		private UserButton userButton2;

		private TextBox textBox1;

		private UserButton userButton1;

		private LinkLabel linkLabel1;

		private Label label2;

		public FormSeqCreate()
		{
			InitializeComponent();
		}

		private void FormSeqCreate_Load(object sender, EventArgs e)
		{
			label1.BackColor = FormLoad.ThemeColor;
			softNumericalOrder = new SoftNumericalOrder("ABC", "yyyyMMdd", 7, Application.StartupPath + "\\numericalOrder.txt");
			if (!Program.ShowAuthorInfomation)
			{
				label2.Visible = false;
				linkLabel1.Visible = false;
			}
		}

		private void userButton1_Click(object sender, EventArgs e)
		{
			string numericalOrder = softNumericalOrder.GetNumericalOrder();
			textBox1.AppendText(numericalOrder + Environment.NewLine);
		}

		private void userButton3_Click(object sender, EventArgs e)
		{
			string numericalOrder = softNumericalOrder.GetNumericalOrder("XYZ");
			textBox1.AppendText(numericalOrder + Environment.NewLine);
		}

		private void userButton2_Click(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;
			for (int i = 0; i < 1000000; i++)
			{
				string numericalOrder = softNumericalOrder.GetNumericalOrder("XYZ");
			}
			double totalMilliseconds = (DateTime.Now - now).TotalMilliseconds;
			textBox1.AppendText("耗时：" + totalMilliseconds.ToString() + Environment.NewLine);
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start(linkLabel1.Text);
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
			label1 = new System.Windows.Forms.Label();
			userButton3 = new HslCommunication.Controls.UserButton();
			userButton2 = new HslCommunication.Controls.UserButton();
			textBox1 = new System.Windows.Forms.TextBox();
			userButton1 = new HslCommunication.Controls.UserButton();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			label2 = new System.Windows.Forms.Label();
			SuspendLayout();
			label1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label1.BackColor = System.Drawing.Color.LightSkyBlue;
			label1.Font = new System.Drawing.Font("楷体", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.ForeColor = System.Drawing.Color.Black;
			label1.Location = new System.Drawing.Point(-9, -2);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(1052, 76);
			label1.TabIndex = 1;
			label1.Text = "流水号生成器测试";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			userButton3.BackColor = System.Drawing.Color.Transparent;
			userButton3.CustomerInformation = "";
			userButton3.EnableColor = System.Drawing.Color.FromArgb(190, 190, 190);
			userButton3.Font = new System.Drawing.Font("微软雅黑", 9f);
			userButton3.Location = new System.Drawing.Point(12, 137);
			userButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userButton3.Name = "userButton3";
			userButton3.Size = new System.Drawing.Size(136, 42);
			userButton3.TabIndex = 8;
			userButton3.UIText = "获取流水号";
			userButton3.Click += new System.EventHandler(userButton3_Click);
			userButton2.BackColor = System.Drawing.Color.Transparent;
			userButton2.CustomerInformation = "";
			userButton2.EnableColor = System.Drawing.Color.FromArgb(190, 190, 190);
			userButton2.Font = new System.Drawing.Font("微软雅黑", 9f);
			userButton2.Location = new System.Drawing.Point(12, 187);
			userButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userButton2.Name = "userButton2";
			userButton2.Size = new System.Drawing.Size(136, 42);
			userButton2.TabIndex = 7;
			userButton2.UIText = "百万流水号性能测试";
			userButton2.Click += new System.EventHandler(userButton2_Click);
			textBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox1.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox1.Location = new System.Drawing.Point(154, 87);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox1.Size = new System.Drawing.Size(848, 557);
			textBox1.TabIndex = 6;
			userButton1.BackColor = System.Drawing.Color.Transparent;
			userButton1.CustomerInformation = "";
			userButton1.EnableColor = System.Drawing.Color.FromArgb(190, 190, 190);
			userButton1.Font = new System.Drawing.Font("微软雅黑", 9f);
			userButton1.Location = new System.Drawing.Point(12, 87);
			userButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userButton1.Name = "userButton1";
			userButton1.Size = new System.Drawing.Size(136, 42);
			userButton1.TabIndex = 5;
			userButton1.UIText = "获取流水号";
			userButton1.Click += new System.EventHandler(userButton1_Click);
			linkLabel1.AutoSize = true;
			linkLabel1.BackColor = System.Drawing.Color.LightSkyBlue;
			linkLabel1.Location = new System.Drawing.Point(66, 9);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(287, 17);
			linkLabel1.TabIndex = 9;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "http://www.cnblogs.com/dathlin/p/7811489.html";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.LightSkyBlue;
			label2.Location = new System.Drawing.Point(17, 9);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 17);
			label2.TabIndex = 10;
			label2.Text = "博客：";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(label2);
			base.Controls.Add(linkLabel1);
			base.Controls.Add(userButton3);
			base.Controls.Add(userButton2);
			base.Controls.Add(textBox1);
			base.Controls.Add(userButton1);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormSeqCreate";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "序列号生成器";
			base.Load += new System.EventHandler(FormSeqCreate_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
