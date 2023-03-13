using HslCommunication.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo.Control
{
	public class FormPipe : HslFormContent
	{
		private Timer timer = new Timer();

		private Timer timer2 = new Timer();

		private Random random = new Random();

		private IContainer components = null;

		private UserBottle userBottle1;

		private UserBottle userBottle2;

		private UserBottle userBottle3;

		private UserBottle userBottle4;

		private UserBottle userBottle5;

		private UserBottle userBottle6;

		private UserBottle userBottle7;

		private UserPipe userPipe1;

		private UserPipe userPipe2;

		private UserCurve userCurve1;

		private UserPipe userPipe3;

		private UserPipe userPipe4;

		private UserPipe userPipe5;

		private UserPipe userPipe6;

		private UserPipe userPipe7;

		private UserPipe userPipe8;

		private UserPipe userPipe9;

		public FormPipe()
		{
			InitializeComponent();
			DoubleBuffered = true;
		}

		private void FormPipe_Load(object sender, EventArgs e)
		{
			timer.Interval = 50;
			timer.Tick += Timer_Tick;
			timer.Start();
			timer2.Interval = 200;
			timer2.Tick += Timer2_Tick;
			timer2.Start();
			userCurve1.SetLeftCurve("A", new float[0]);
		}

		private void Timer2_Tick(object sender, EventArgs e)
		{
			if (userBottle1.Value > 0.0)
			{
				UserBottle userBottle = userBottle1;
				double value = userBottle.Value;
				userBottle.Value = value - 1.0;
				if (userBottle1.Value <= 0.0)
				{
					userBottle1.IsOpen = false;
					userPipe1.MoveSpeed = 0f;
				}
			}
			if (userBottle6.Value < 100.0)
			{
				UserBottle userBottle2 = userBottle6;
				double value = userBottle2.Value;
				userBottle2.Value = value + 1.0;
				if (userBottle6.Value >= 100.0)
				{
					userBottle6.IsOpen = false;
					userPipe2.MoveSpeed = 0f;
				}
			}
			userCurve1.AddCurveData("A", (float)random.Next(100));
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.DrawString(DateTime.Now.Millisecond.ToString(), Font, Brushes.Black, 0f, 0f);
			userPipe1.OnPaintMainWindow(e.Graphics);
			userPipe2.OnPaintMainWindow(e.Graphics);
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
			userPipe9 = new HslCommunication.Controls.UserPipe();
			userPipe8 = new HslCommunication.Controls.UserPipe();
			userPipe7 = new HslCommunication.Controls.UserPipe();
			userPipe6 = new HslCommunication.Controls.UserPipe();
			userPipe5 = new HslCommunication.Controls.UserPipe();
			userPipe4 = new HslCommunication.Controls.UserPipe();
			userPipe3 = new HslCommunication.Controls.UserPipe();
			userCurve1 = new HslCommunication.Controls.UserCurve();
			userBottle1 = new HslCommunication.Controls.UserBottle();
			userBottle7 = new HslCommunication.Controls.UserBottle();
			userBottle6 = new HslCommunication.Controls.UserBottle();
			userBottle5 = new HslCommunication.Controls.UserBottle();
			userBottle4 = new HslCommunication.Controls.UserBottle();
			userBottle3 = new HslCommunication.Controls.UserBottle();
			userBottle2 = new HslCommunication.Controls.UserBottle();
			userPipe2 = new HslCommunication.Controls.UserPipe();
			userPipe1 = new HslCommunication.Controls.UserPipe();
			SuspendLayout();
			userPipe9.BackColor = System.Drawing.Color.Transparent;
			userPipe9.LineColor = System.Drawing.Color.FromArgb(150, 150, 150);
			userPipe9.LinePoints = "10,50;300,50;40,240;150,10;260,240;10,60";
			userPipe9.Location = new System.Drawing.Point(652, 291);
			userPipe9.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			userPipe9.Name = "userPipe9";
			userPipe9.Size = new System.Drawing.Size(320, 255);
			userPipe9.TabIndex = 16;
			userPipe8.ActiveColor = System.Drawing.Color.FromArgb(255, 128, 255);
			userPipe8.BackColor = System.Drawing.Color.Transparent;
			userPipe8.LineColor = System.Drawing.Color.FromArgb(150, 150, 150);
			userPipe8.LinePoints = "0,3;400,3";
			userPipe8.LineWidth = 10f;
			userPipe8.Location = new System.Drawing.Point(503, 233);
			userPipe8.Margin = new System.Windows.Forms.Padding(3, 23, 3, 23);
			userPipe8.MoveSpeed = -0.4f;
			userPipe8.Name = "userPipe8";
			userPipe8.Size = new System.Drawing.Size(451, 29);
			userPipe8.TabIndex = 15;
			userPipe7.ActiveColor = System.Drawing.Color.FromArgb(255, 128, 255);
			userPipe7.BackColor = System.Drawing.Color.Transparent;
			userPipe7.LineColor = System.Drawing.Color.FromArgb(150, 150, 150);
			userPipe7.LinePoints = "0,3;400,3";
			userPipe7.Location = new System.Drawing.Point(503, 204);
			userPipe7.Margin = new System.Windows.Forms.Padding(3, 16, 3, 16);
			userPipe7.MoveSpeed = 0.4f;
			userPipe7.Name = "userPipe7";
			userPipe7.Size = new System.Drawing.Size(469, 50);
			userPipe7.TabIndex = 14;
			userPipe6.ActiveColor = System.Drawing.Color.FromArgb(255, 128, 0);
			userPipe6.BackColor = System.Drawing.Color.Transparent;
			userPipe6.LineColor = System.Drawing.Color.FromArgb(192, 192, 255);
			userPipe6.LinePoints = "0,3;400,3";
			userPipe6.Location = new System.Drawing.Point(503, 164);
			userPipe6.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
			userPipe6.MoveSpeed = 0.4f;
			userPipe6.Name = "userPipe6";
			userPipe6.Size = new System.Drawing.Size(451, 35);
			userPipe6.TabIndex = 13;
			userPipe5.BackColor = System.Drawing.Color.Transparent;
			userPipe5.LineColor = System.Drawing.Color.FromArgb(150, 150, 150);
			userPipe5.LinePoints = "0,3;400,3";
			userPipe5.Location = new System.Drawing.Point(503, 120);
			userPipe5.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
			userPipe5.MoveSpeed = 0.4f;
			userPipe5.Name = "userPipe5";
			userPipe5.Size = new System.Drawing.Size(547, 25);
			userPipe5.TabIndex = 12;
			userPipe4.BackColor = System.Drawing.Color.Transparent;
			userPipe4.LineColor = System.Drawing.Color.FromArgb(150, 150, 150);
			userPipe4.LinePoints = "0,3;400,3";
			userPipe4.Location = new System.Drawing.Point(503, 88);
			userPipe4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			userPipe4.MoveSpeed = 0.6f;
			userPipe4.Name = "userPipe4";
			userPipe4.Size = new System.Drawing.Size(469, 18);
			userPipe4.TabIndex = 11;
			userPipe3.BackColor = System.Drawing.Color.Transparent;
			userPipe3.LineColor = System.Drawing.Color.FromArgb(150, 150, 150);
			userPipe3.LinePoints = "0,3;400,3";
			userPipe3.Location = new System.Drawing.Point(503, 65);
			userPipe3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userPipe3.Name = "userPipe3";
			userPipe3.Size = new System.Drawing.Size(402, 13);
			userPipe3.TabIndex = 10;
			userCurve1.BackColor = System.Drawing.Color.Transparent;
			userCurve1.Location = new System.Drawing.Point(304, 379);
			userCurve1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userCurve1.Name = "userCurve1";
			userCurve1.Size = new System.Drawing.Size(356, 167);
			userCurve1.TabIndex = 9;
			userBottle1.BackColor = System.Drawing.Color.Transparent;
			userBottle1.BottleTag = "1#";
			userBottle1.IsOpen = true;
			userBottle1.Location = new System.Drawing.Point(30, 13);
			userBottle1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userBottle1.Name = "userBottle1";
			userBottle1.Size = new System.Drawing.Size(35, 153);
			userBottle1.TabIndex = 0;
			userBottle1.Value = 50.0;
			userBottle7.BackColor = System.Drawing.Color.Transparent;
			userBottle7.HeadTag = "";
			userBottle7.Location = new System.Drawing.Point(212, 390);
			userBottle7.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
			userBottle7.Name = "userBottle7";
			userBottle7.Size = new System.Drawing.Size(72, 191);
			userBottle7.TabIndex = 6;
			userBottle7.Value = 50.0;
			userBottle6.BackColor = System.Drawing.Color.Transparent;
			userBottle6.HeadTag = "原料6";
			userBottle6.IsOpen = true;
			userBottle6.Location = new System.Drawing.Point(382, 13);
			userBottle6.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
			userBottle6.Name = "userBottle6";
			userBottle6.Size = new System.Drawing.Size(35, 153);
			userBottle6.TabIndex = 5;
			userBottle6.Value = 50.0;
			userBottle5.BackColor = System.Drawing.Color.Transparent;
			userBottle5.HeadTag = "原料5";
			userBottle5.Location = new System.Drawing.Point(304, 13);
			userBottle5.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
			userBottle5.Name = "userBottle5";
			userBottle5.Size = new System.Drawing.Size(35, 153);
			userBottle5.TabIndex = 4;
			userBottle5.Value = 50.0;
			userBottle4.BackColor = System.Drawing.Color.Transparent;
			userBottle4.HeadTag = "原料4";
			userBottle4.Location = new System.Drawing.Point(226, 13);
			userBottle4.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
			userBottle4.Name = "userBottle4";
			userBottle4.Size = new System.Drawing.Size(35, 153);
			userBottle4.TabIndex = 3;
			userBottle4.Value = 70.0;
			userBottle3.BackColor = System.Drawing.Color.Transparent;
			userBottle3.HeadTag = "原料3";
			userBottle3.Location = new System.Drawing.Point(153, 13);
			userBottle3.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
			userBottle3.Name = "userBottle3";
			userBottle3.Size = new System.Drawing.Size(35, 153);
			userBottle3.TabIndex = 2;
			userBottle3.Value = 70.0;
			userBottle2.BackColor = System.Drawing.Color.Transparent;
			userBottle2.BottleTag = "2#";
			userBottle2.HeadTag = "原料2";
			userBottle2.Location = new System.Drawing.Point(86, 13);
			userBottle2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			userBottle2.Name = "userBottle2";
			userBottle2.Size = new System.Drawing.Size(35, 153);
			userBottle2.TabIndex = 1;
			userBottle2.Value = 50.0;
			userPipe2.ActiveColor = System.Drawing.Color.Black;
			userPipe2.BackColor = System.Drawing.Color.Transparent;
			userPipe2.LineColor = System.Drawing.Color.FromArgb(150, 150, 150);
			userPipe2.LinePoints = "145,0;145,200;2,200;2,270";
			userPipe2.LineWidth = 10f;
			userPipe2.Location = new System.Drawing.Point(254, 144);
			userPipe2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			userPipe2.MoveSpeed = -0.5f;
			userPipe2.Name = "userPipe2";
			userPipe2.Size = new System.Drawing.Size(228, 291);
			userPipe2.TabIndex = 8;
			userPipe2.Visible = false;
			userPipe1.BackColor = System.Drawing.Color.Transparent;
			userPipe1.LineColor = System.Drawing.Color.FromArgb(150, 150, 150);
			userPipe1.LinePoints = "15,0;15,200;200,200;200,270";
			userPipe1.Location = new System.Drawing.Point(32, 144);
			userPipe1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userPipe1.MoveSpeed = 0.6f;
			userPipe1.Name = "userPipe1";
			userPipe1.Size = new System.Drawing.Size(231, 299);
			userPipe1.TabIndex = 7;
			userPipe1.TabStop = false;
			userPipe1.Visible = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userPipe9);
			base.Controls.Add(userPipe8);
			base.Controls.Add(userPipe7);
			base.Controls.Add(userPipe6);
			base.Controls.Add(userPipe5);
			base.Controls.Add(userPipe4);
			base.Controls.Add(userPipe3);
			base.Controls.Add(userCurve1);
			base.Controls.Add(userBottle1);
			base.Controls.Add(userBottle7);
			base.Controls.Add(userBottle6);
			base.Controls.Add(userBottle5);
			base.Controls.Add(userBottle4);
			base.Controls.Add(userBottle3);
			base.Controls.Add(userBottle2);
			base.Controls.Add(userPipe2);
			base.Controls.Add(userPipe1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormPipe";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormPipe";
			base.Load += new System.EventHandler(FormPipe_Load);
			ResumeLayout(false);
		}
	}
}
