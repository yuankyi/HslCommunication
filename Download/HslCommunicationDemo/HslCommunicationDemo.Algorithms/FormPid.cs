using HslCommunication.Algorithms.PID;
using HslCommunication.Controls;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo.Algorithms
{
	public class FormPid : HslFormContent
	{
		private PIDHelper pIDHelper;

		private Timer timer;

		private IContainer components = null;

		private UserCurve userCurve1;

		private Label label1;

		private TextBox textBox1;

		private TextBox textBox2;

		private Label label2;

		private TextBox textBox3;

		private Label label3;

		private TextBox textBox4;

		private Label label4;

		private UserControlHead userControlHead1;

		private TextBox textBox5;

		private Label label5;

		private Button button1;

		private Button button2;

		public FormPid()
		{
			InitializeComponent();
		}

		private void FormPid_Load(object sender, EventArgs e)
		{
			userCurve1.SetLeftCurve("Pid", null, Color.Green);
			pIDHelper = new PIDHelper();
			timer = new Timer();
			timer.Interval = 100;
			timer.Tick += Timer_Tick;
			timer.Start();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			userCurve1.AddCurveData("Pid", (float)pIDHelper.PidCalculate());
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			try
			{
				pIDHelper.SetValue = double.Parse(textBox5.Text);
			}
			catch
			{
				MessageBox.Show("Input Wrong, please check the input value!");
			}
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			try
			{
				pIDHelper.Kp = double.Parse(textBox1.Text);
				pIDHelper.Ki = double.Parse(textBox2.Text);
				pIDHelper.Kd = double.Parse(textBox3.Text);
				pIDHelper.DeadBand = double.Parse(textBox4.Text);
			}
			catch
			{
				MessageBox.Show("Input Wrong, please check the input value!");
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
			textBox3 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			userCurve1 = new HslCommunication.Controls.UserCurve();
			button2 = new System.Windows.Forms.Button();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(38, 61);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(17, 12);
			label1.TabIndex = 1;
			label1.Text = "P:";
			textBox1.Location = new System.Drawing.Point(65, 58);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(100, 21);
			textBox1.TabIndex = 2;
			textBox1.Text = "0.7";
			textBox2.Location = new System.Drawing.Point(222, 58);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(100, 21);
			textBox2.TabIndex = 4;
			textBox2.Text = "0.4";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(195, 61);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(17, 12);
			label2.TabIndex = 3;
			label2.Text = "I:";
			textBox3.Location = new System.Drawing.Point(392, 58);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(100, 21);
			textBox3.TabIndex = 6;
			textBox3.Text = "0";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(365, 61);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(17, 12);
			label3.TabIndex = 5;
			label3.Text = "D:";
			textBox4.Location = new System.Drawing.Point(589, 58);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(100, 21);
			textBox4.TabIndex = 8;
			textBox4.Text = "2";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(517, 61);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(65, 12);
			label4.TabIndex = 7;
			label4.Text = "DeadBlock:";
			textBox5.Location = new System.Drawing.Point(95, 103);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(100, 21);
			textBox5.TabIndex = 11;
			textBox5.Text = "1";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(38, 106);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(41, 12);
			label5.TabIndex = 10;
			label5.Text = "Value:";
			button1.Location = new System.Drawing.Point(231, 100);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(102, 24);
			button1.TabIndex = 12;
			button1.Text = "set value";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1_Click);
			userCurve1.BackColor = System.Drawing.Color.Transparent;
			userCurve1.IsAbscissaStrech = true;
			userCurve1.Location = new System.Drawing.Point(12, 151);
			userCurve1.Name = "userCurve1";
			userCurve1.Size = new System.Drawing.Size(980, 482);
			userCurve1.StrechDataCountMax = 100;
			userCurve1.TabIndex = 0;
			userCurve1.ValueMaxLeft = 400f;
			userCurve1.ValueMaxRight = 400f;
			button2.Location = new System.Drawing.Point(720, 55);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(102, 24);
			button2.TabIndex = 13;
			button2.Text = "set para";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(Button2_Click);
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 9;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(textBox5);
			base.Controls.Add(label5);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(textBox4);
			base.Controls.Add(label4);
			base.Controls.Add(textBox3);
			base.Controls.Add(label3);
			base.Controls.Add(textBox2);
			base.Controls.Add(label2);
			base.Controls.Add(textBox1);
			base.Controls.Add(label1);
			base.Controls.Add(userCurve1);
			base.Name = "FormPid";
			Text = "FormPid";
			base.Load += new System.EventHandler(FormPid_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
