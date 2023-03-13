using HslCommunication.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormGauge : HslFormContent
	{
		private Timer timerTick = null;

		private Random random;

		private IContainer components = null;

		private UserGaugeChart userGaugeChart4;

		private UserGaugeChart userGaugeChart3;

		private UserGaugeChart userGaugeChart2;

		private UserGaugeChart userGaugeChart1;

		private PropertyGrid propertyGrid1;

		private UserGaugeChart userGaugeChart5;

		private Label label1;

		public FormGauge()
		{
			InitializeComponent();
		}

		private void FormGauge_Load(object sender, EventArgs e)
		{
			Language(Program.Language);
			propertyGrid1.SelectedObject = userGaugeChart5;
			random = new Random();
			timerTick = new Timer();
			timerTick.Interval = 1000;
			timerTick.Tick += TimerTick_Tick;
			timerTick.Start();
		}

		private void Language(int language)
		{
			if (language == 1)
			{
				Text = "仪表盘控件";
				label1.Text = "该控件的基本属性可由右侧的控件界面设置";
			}
			else
			{
				Text = "Instrument panel Controls";
				label1.Text = "The control's basic properties can be set by the control interface on the right";
			}
		}

		private void TimerTick_Tick(object sender, EventArgs e)
		{
			userGaugeChart1.Value = Math.Round(random.NextDouble() * 100.0 - 200.0, 1);
			userGaugeChart2.Value = Math.Round(random.NextDouble() * 120.0, 1);
			userGaugeChart3.Value = Math.Round(random.NextDouble() * 100.0, 1);
			userGaugeChart4.Value = Math.Round(random.NextDouble() * 100.0, 1);
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
			propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			label1 = new System.Windows.Forms.Label();
			userGaugeChart5 = new HslCommunication.Controls.UserGaugeChart();
			userGaugeChart4 = new HslCommunication.Controls.UserGaugeChart();
			userGaugeChart3 = new HslCommunication.Controls.UserGaugeChart();
			userGaugeChart2 = new HslCommunication.Controls.UserGaugeChart();
			userGaugeChart1 = new HslCommunication.Controls.UserGaugeChart();
			SuspendLayout();
			propertyGrid1.Location = new System.Drawing.Point(673, 1);
			propertyGrid1.Name = "propertyGrid1";
			propertyGrid1.Size = new System.Drawing.Size(331, 638);
			propertyGrid1.TabIndex = 33;
			label1.Location = new System.Drawing.Point(350, 196);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(304, 75);
			label1.TabIndex = 35;
			label1.Text = "该控件的基本属性可由右侧的控件界面设置";
			userGaugeChart5.BackColor = System.Drawing.Color.Transparent;
			userGaugeChart5.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userGaugeChart5.IsTextUnderPointer = false;
			userGaugeChart5.Location = new System.Drawing.Point(338, 13);
			userGaugeChart5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userGaugeChart5.Name = "userGaugeChart5";
			userGaugeChart5.Size = new System.Drawing.Size(316, 179);
			userGaugeChart5.TabIndex = 34;
			userGaugeChart5.UnitText = "km/H";
			userGaugeChart5.Value = 50.0;
			userGaugeChart4.BackColor = System.Drawing.Color.FromArgb(36, 36, 36);
			userGaugeChart4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userGaugeChart4.Location = new System.Drawing.Point(353, 435);
			userGaugeChart4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userGaugeChart4.Name = "userGaugeChart4";
			userGaugeChart4.PointerColor = System.Drawing.Color.FromArgb(0, 192, 0);
			userGaugeChart4.Size = new System.Drawing.Size(301, 183);
			userGaugeChart4.TabIndex = 32;
			userGaugeChart4.Value = 50.0;
			userGaugeChart3.BackColor = System.Drawing.Color.Transparent;
			userGaugeChart3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userGaugeChart3.Location = new System.Drawing.Point(12, 435);
			userGaugeChart3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userGaugeChart3.Name = "userGaugeChart3";
			userGaugeChart3.PointerColor = System.Drawing.Color.FromArgb(0, 192, 0);
			userGaugeChart3.Size = new System.Drawing.Size(320, 197);
			userGaugeChart3.TabIndex = 31;
			userGaugeChart3.Value = 60.0;
			userGaugeChart2.BackColor = System.Drawing.Color.Transparent;
			userGaugeChart2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userGaugeChart2.IsBigSemiCircle = true;
			userGaugeChart2.IsTextUnderPointer = false;
			userGaugeChart2.Location = new System.Drawing.Point(12, 196);
			userGaugeChart2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userGaugeChart2.Name = "userGaugeChart2";
			userGaugeChart2.SegmentCount = 14;
			userGaugeChart2.Size = new System.Drawing.Size(320, 245);
			userGaugeChart2.TabIndex = 30;
			userGaugeChart2.UnitText = "km/H";
			userGaugeChart2.Value = 50.0;
			userGaugeChart2.ValueMax = 140.0;
			userGaugeChart1.BackColor = System.Drawing.Color.Transparent;
			userGaugeChart1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userGaugeChart1.IsTextUnderPointer = false;
			userGaugeChart1.Location = new System.Drawing.Point(12, 13);
			userGaugeChart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userGaugeChart1.Name = "userGaugeChart1";
			userGaugeChart1.SegmentCount = 5;
			userGaugeChart1.Size = new System.Drawing.Size(320, 183);
			userGaugeChart1.TabIndex = 29;
			userGaugeChart1.UnitText = "km/h";
			userGaugeChart1.Value = -100.0;
			userGaugeChart1.ValueAlarmMin = -180.0;
			userGaugeChart1.ValueMax = -100.0;
			userGaugeChart1.ValueStart = -200.0;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(label1);
			base.Controls.Add(userGaugeChart5);
			base.Controls.Add(propertyGrid1);
			base.Controls.Add(userGaugeChart4);
			base.Controls.Add(userGaugeChart3);
			base.Controls.Add(userGaugeChart2);
			base.Controls.Add(userGaugeChart1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormGauge";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "仪表盘控件";
			base.Load += new System.EventHandler(FormGauge_Load);
			ResumeLayout(false);
		}
	}
}
