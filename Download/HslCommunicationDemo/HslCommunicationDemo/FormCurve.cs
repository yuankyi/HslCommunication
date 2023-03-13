using HslCommunication.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormCurve : HslFormContent
	{
		private Timer timerTick = null;

		private Random random;

		private bool isVisiable = true;

		private IContainer components = null;

		private Label label11;

		private UserCurve userCurve1;

		private Label label12;

		private UserCurve userCurve2;

		private Label label1;

		private UserCurve userCurve3;

		private UserButton userButton8;

		private UserButton userButton7;

		private UserButton userButton6;

		private TextBox textBox1;

		private UserButton userButton1;

		public FormCurve()
		{
			InitializeComponent();
		}

		private float[] GetRandomValueByCount(int count, float min, float max)
		{
			float[] array = new float[count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (float)random.NextDouble() * (max - min) + min;
			}
			return array;
		}

		private void FormCurve_Load(object sender, EventArgs e)
		{
			random = new Random();
			userCurve1.SetLeftCurve("A", GetRandomValueByCount(12, 0f, 200f), Color.DodgerBlue);
			userCurve1.SetCurveText(new string[12]
			{
				"一月",
				"二月",
				"三月",
				"四月",
				"五月",
				"六月",
				"七月",
				"八月",
				"九月",
				"十月",
				"十一月",
				"十二月"
			});
			userCurve3.SetLeftCurve("A", GetRandomValueByCount(400, 100f, 150f), Color.Tomato);
			userCurve3.SetRightCurve("B", GetRandomValueByCount(400, 1.2f, 2f), Color.LimeGreen);
			userCurve2.SetLeftCurve("A", null, Color.DodgerBlue);
			userCurve2.SetLeftCurve("B", null, Color.Tomato);
			userCurve2.SetRightCurve("C", null, Color.LimeGreen);
			userCurve2.SetRightCurve("D", null, Color.Orchid);
			timerTick = new Timer();
			timerTick.Interval = 300;
			timerTick.Tick += TimerTick_Tick;
			timerTick.Start();
		}

		private void TimerTick_Tick(object sender, EventArgs e)
		{
			userCurve2.AddCurveData(new string[4]
			{
				"A",
				"B",
				"C",
				"D"
			}, new float[4]
			{
				(float)random.Next(170, 190),
				(float)random.Next(140, 160),
				(float)random.NextDouble() * 0.5f + 1f,
				(float)random.NextDouble() * 1f + 2f
			});
			userCurve2.SetCurveVisible(new string[2]
			{
				"A",
				"B"
			}, isVisiable);
		}

		private void userButton6_Click(object sender, EventArgs e)
		{
			float result;
			if (float.TryParse(textBox1.Text, out result))
			{
				userCurve2.AddLeftAuxiliary(result, Color.Yellow);
			}
		}

		private void userButton8_Click(object sender, EventArgs e)
		{
			float result;
			if (float.TryParse(textBox1.Text, out result))
			{
				userCurve2.AddRightAuxiliary(result, Color.Chocolate);
			}
		}

		private void userButton7_Click(object sender, EventArgs e)
		{
			float result;
			if (float.TryParse(textBox1.Text, out result))
			{
				userCurve2.RemoveAuxiliary(result);
			}
		}

		private void userButton1_Click(object sender, EventArgs e)
		{
			isVisiable = !isVisiable;
			userCurve2.SetCurveVisible(new string[2]
			{
				"A",
				"B"
			}, isVisiable);
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
			label11 = new System.Windows.Forms.Label();
			userCurve1 = new HslCommunication.Controls.UserCurve();
			label12 = new System.Windows.Forms.Label();
			userCurve2 = new HslCommunication.Controls.UserCurve();
			label1 = new System.Windows.Forms.Label();
			userCurve3 = new HslCommunication.Controls.UserCurve();
			userButton8 = new HslCommunication.Controls.UserButton();
			userButton7 = new HslCommunication.Controls.UserButton();
			userButton6 = new HslCommunication.Controls.UserButton();
			textBox1 = new System.Windows.Forms.TextBox();
			userButton1 = new HslCommunication.Controls.UserButton();
			SuspendLayout();
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(421, 619);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(212, 17);
			label11.TabIndex = 34;
			label11.Text = "曲线控件，此处只显示简单的一条曲线";
			userCurve1.BackColor = System.Drawing.Color.Transparent;
			userCurve1.ColorDashLines = System.Drawing.Color.LightGray;
			userCurve1.IsAbscissaStrech = true;
			userCurve1.Location = new System.Drawing.Point(12, 418);
			userCurve1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userCurve1.Name = "userCurve1";
			userCurve1.Size = new System.Drawing.Size(1000, 198);
			userCurve1.StrechDataCountMax = 12;
			userCurve1.TabIndex = 33;
			userCurve1.Title = "信息表";
			userCurve1.ValueMaxLeft = 200f;
			userCurve1.ValueMaxRight = 200f;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(89, 272);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(327, 17);
			label12.TabIndex = 37;
			label12.Text = "曲线控件，相对复杂的显示，2种坐标系，多条曲线同时显示";
			userCurve2.BackColor = System.Drawing.Color.FromArgb(36, 36, 36);
			userCurve2.ColorDashLines = System.Drawing.Color.DimGray;
			userCurve2.ColorLinesAndText = System.Drawing.Color.Gray;
			userCurve2.Location = new System.Drawing.Point(-1, 13);
			userCurve2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userCurve2.Name = "userCurve2";
			userCurve2.Size = new System.Drawing.Size(497, 255);
			userCurve2.TabIndex = 36;
			userCurve2.ValueMaxLeft = 200f;
			userCurve2.ValueMaxRight = 5f;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(725, 272);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 39;
			label1.Text = "静态曲线";
			userCurve3.BackColor = System.Drawing.Color.FromArgb(36, 36, 36);
			userCurve3.ColorDashLines = System.Drawing.Color.DimGray;
			userCurve3.ColorLinesAndText = System.Drawing.Color.Gray;
			userCurve3.Location = new System.Drawing.Point(502, 13);
			userCurve3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			userCurve3.Name = "userCurve3";
			userCurve3.Size = new System.Drawing.Size(500, 255);
			userCurve3.TabIndex = 38;
			userCurve3.ValueMaxLeft = 200f;
			userCurve3.ValueMaxRight = 5f;
			userButton8.BackColor = System.Drawing.Color.Transparent;
			userButton8.CustomerInformation = "";
			userButton8.EnableColor = System.Drawing.Color.FromArgb(190, 190, 190);
			userButton8.Font = new System.Drawing.Font("微软雅黑", 9f);
			userButton8.Location = new System.Drawing.Point(216, 301);
			userButton8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userButton8.Name = "userButton8";
			userButton8.Size = new System.Drawing.Size(78, 25);
			userButton8.TabIndex = 43;
			userButton8.UIText = "右辅助新增";
			userButton8.Click += new System.EventHandler(userButton8_Click);
			userButton7.BackColor = System.Drawing.Color.Transparent;
			userButton7.CustomerInformation = "";
			userButton7.EnableColor = System.Drawing.Color.FromArgb(190, 190, 190);
			userButton7.Font = new System.Drawing.Font("微软雅黑", 9f);
			userButton7.Location = new System.Drawing.Point(300, 301);
			userButton7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userButton7.Name = "userButton7";
			userButton7.Size = new System.Drawing.Size(78, 25);
			userButton7.TabIndex = 42;
			userButton7.UIText = "辅助线移除";
			userButton7.Click += new System.EventHandler(userButton7_Click);
			userButton6.BackColor = System.Drawing.Color.Transparent;
			userButton6.CustomerInformation = "";
			userButton6.EnableColor = System.Drawing.Color.FromArgb(190, 190, 190);
			userButton6.Font = new System.Drawing.Font("微软雅黑", 9f);
			userButton6.Location = new System.Drawing.Point(132, 301);
			userButton6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userButton6.Name = "userButton6";
			userButton6.Size = new System.Drawing.Size(78, 25);
			userButton6.TabIndex = 41;
			userButton6.UIText = "左辅助新增";
			userButton6.Click += new System.EventHandler(userButton6_Click);
			textBox1.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox1.Location = new System.Drawing.Point(43, 302);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(83, 26);
			textBox1.TabIndex = 40;
			userButton1.BackColor = System.Drawing.Color.Transparent;
			userButton1.CustomerInformation = "";
			userButton1.EnableColor = System.Drawing.Color.FromArgb(190, 190, 190);
			userButton1.Font = new System.Drawing.Font("微软雅黑", 9f);
			userButton1.Location = new System.Drawing.Point(384, 301);
			userButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userButton1.Name = "userButton1";
			userButton1.Size = new System.Drawing.Size(78, 25);
			userButton1.TabIndex = 44;
			userButton1.UIText = "隐藏曲线";
			userButton1.Click += new System.EventHandler(userButton1_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userButton1);
			base.Controls.Add(userButton8);
			base.Controls.Add(userButton7);
			base.Controls.Add(userButton6);
			base.Controls.Add(textBox1);
			base.Controls.Add(label1);
			base.Controls.Add(userCurve3);
			base.Controls.Add(label12);
			base.Controls.Add(userCurve2);
			base.Controls.Add(label11);
			base.Controls.Add(userCurve1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormCurve";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "曲线控件";
			base.Load += new System.EventHandler(FormCurve_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
