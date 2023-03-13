using HslCommunication.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormPieChart : HslFormContent
	{
		private UserPieChart[] charts = new UserPieChart[5];

		private Random random = new Random();

		private Timer timerTick = null;

		private IContainer components = null;

		private UserPieChart userPieChart1;

		private UserPieChart userPieChart2;

		private UserPieChart userPieChart3;

		private UserPieChart userPieChart4;

		private UserPieChart userPieChart5;

		public FormPieChart()
		{
			InitializeComponent();
		}

		private void FormPieChart_Load(object sender, EventArgs e)
		{
			charts[0] = userPieChart1;
			charts[1] = userPieChart2;
			charts[2] = userPieChart3;
			charts[3] = userPieChart4;
			charts[4] = userPieChart5;
			timerTick = new Timer();
			timerTick.Interval = 5000;
			timerTick.Tick += TimerTick_Tick;
			timerTick.Start();
			TimerTick_Tick(sender, e);
		}

		private void TimerTick_Tick(object sender, EventArgs e)
		{
			for (int i = 0; i < 5; i++)
			{
				List<string> list = new List<string>();
				List<int> list2 = new List<int>();
				for (int j = 0; j < random.Next(4, 12); j++)
				{
					list.Add(random.Next(100, 999).ToString());
					list2.Add(random.Next(0, 5));
				}
				charts[i].SetDataSource(list.ToArray(), list2.ToArray());
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
			userPieChart1 = new HslCommunication.Controls.UserPieChart();
			userPieChart2 = new HslCommunication.Controls.UserPieChart();
			userPieChart3 = new HslCommunication.Controls.UserPieChart();
			userPieChart4 = new HslCommunication.Controls.UserPieChart();
			userPieChart5 = new HslCommunication.Controls.UserPieChart();
			SuspendLayout();
			userPieChart1.BackColor = System.Drawing.Color.Transparent;
			userPieChart1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userPieChart1.Location = new System.Drawing.Point(37, 13);
			userPieChart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userPieChart1.Name = "userPieChart1";
			userPieChart1.Size = new System.Drawing.Size(279, 273);
			userPieChart1.TabIndex = 0;
			userPieChart2.BackColor = System.Drawing.Color.Transparent;
			userPieChart2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userPieChart2.Location = new System.Drawing.Point(364, 13);
			userPieChart2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userPieChart2.Name = "userPieChart2";
			userPieChart2.Size = new System.Drawing.Size(279, 273);
			userPieChart2.TabIndex = 1;
			userPieChart3.BackColor = System.Drawing.Color.Transparent;
			userPieChart3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userPieChart3.IsRenderPercent = true;
			userPieChart3.Location = new System.Drawing.Point(688, 13);
			userPieChart3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userPieChart3.Name = "userPieChart3";
			userPieChart3.Size = new System.Drawing.Size(279, 273);
			userPieChart3.TabIndex = 2;
			userPieChart4.BackColor = System.Drawing.Color.Transparent;
			userPieChart4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userPieChart4.IsRenderPercent = true;
			userPieChart4.IsRenderSmall = false;
			userPieChart4.Location = new System.Drawing.Point(37, 312);
			userPieChart4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userPieChart4.Name = "userPieChart4";
			userPieChart4.Size = new System.Drawing.Size(279, 273);
			userPieChart4.TabIndex = 3;
			userPieChart5.BackColor = System.Drawing.Color.Transparent;
			userPieChart5.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userPieChart5.Location = new System.Drawing.Point(480, 288);
			userPieChart5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userPieChart5.Name = "userPieChart5";
			userPieChart5.Size = new System.Drawing.Size(362, 344);
			userPieChart5.TabIndex = 4;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userPieChart5);
			base.Controls.Add(userPieChart4);
			base.Controls.Add(userPieChart3);
			base.Controls.Add(userPieChart2);
			base.Controls.Add(userPieChart1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormPieChart";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "饼图控件";
			base.Load += new System.EventHandler(FormPieChart_Load);
			ResumeLayout(false);
		}
	}
}
