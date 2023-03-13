using HslCommunication.Algorithms.Fourier;
using HslControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HslCommunicationDemo.Algorithms
{
	public class FourierFilter : HslFormContent
	{
		private Random random;

		private int count = 1024;

		private float[] sources;

		private float[] values;

		private float[] filters;

		private DateTime[] dateTimes;

		private IContainer components = null;

		private HslCurveHistory hslCurveHistory1;

		private Label label1;

		private Label label2;

		private Button button1;

		private Label label3;

		private TextBox textBox1;

		private Button button2;

		private Label label4;

		private Button button3;

		public FourierFilter()
		{
			InitializeComponent();
			sources = new float[count];
			values = new float[count];
			filters = new float[count];
			dateTimes = new DateTime[count];
		}

		private void FourierFilter_Load(object sender, EventArgs e)
		{
			random = new Random();
			for (int i = 0; i < sources.Length; i++)
			{
				sources[i] = (float)(Math.Sin(6.2831853071795862 * (double)i / 500.0) * 40.0 + 50.0);
				values[i] = sources[i];
				if (random.Next(100) < 50)
				{
					values[i] = sources[i] + (float)random.Next(101) / 20f - 2f;
				}
				dateTimes[i] = DateTime.Now.AddSeconds((double)(i - 1000));
			}
			filters = FFTFilter.FilterFFT(values, 0.002);
			hslCurveHistory1.SetLeftCurve("原始数据", values, Color.LightGray);
			hslCurveHistory1.SetLeftCurve("滤波数据", filters, Color.Tomato);
			hslCurveHistory1.SetDateTimes(dateTimes);
			hslCurveHistory1.RenderCurveUI();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			using (FormImage formImage = new FormImage(FFTHelper.GetFFTImage((from m in values
			select (double)m).ToArray(), 1000, 600, Color.Blue)))
			{
				formImage.ShowDialog();
			}
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			try
			{
				filters = FFTFilter.FilterFFT(values, double.Parse(textBox1.Text));
				hslCurveHistory1.SetLeftCurve("滤波数据", filters, Color.Tomato);
				hslCurveHistory1.RenderCurveUI();
			}
			catch (Exception ex)
			{
				MessageBox.Show("数据输入错误！" + ex.Message);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			using (FormImage formImage = new FormImage(FFTHelper.GetFFTImage((from m in values
			select (double)m).ToArray(), 1000, 600, Color.Blue, true)))
			{
				formImage.ShowDialog();
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
			hslCurveHistory1 = new HslControls.HslCurveHistory();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			button2 = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			SuspendLayout();
			hslCurveHistory1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			hslCurveHistory1.BackColor = System.Drawing.Color.FromArgb(46, 46, 46);
			hslCurveHistory1.DashCoordinateColor = System.Drawing.Color.FromArgb(72, 72, 72);
			hslCurveHistory1.Location = new System.Drawing.Point(12, 75);
			hslCurveHistory1.MarkTextColor = System.Drawing.Color.Yellow;
			hslCurveHistory1.Name = "hslCurveHistory1";
			hslCurveHistory1.Size = new System.Drawing.Size(980, 558);
			hslCurveHistory1.TabIndex = 0;
			hslCurveHistory1.Text = "hslCurveHistory1";
			hslCurveHistory1.ValueSegment = 10;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(291, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(440, 17);
			label1.TabIndex = 1;
			label1.Text = "这是一个基于傅立叶变换的高阶曲线拟合，现在只要一个方法就可以方便的实现了";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(9, 55);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(188, 17);
			label2.TabIndex = 2;
			label2.Text = "我们生成一个随机波动的正弦曲线";
			button1.Location = new System.Drawing.Point(684, 49);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(117, 23);
			button1.TabIndex = 3;
			button1.Text = "傅立叶图形";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1_Click);
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(9, 29);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(32, 17);
			label3.TabIndex = 4;
			label3.Text = "系数";
			textBox1.Location = new System.Drawing.Point(47, 26);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(100, 23);
			textBox1.TabIndex = 5;
			textBox1.Text = "0.002";
			button2.Location = new System.Drawing.Point(153, 26);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(117, 23);
			button2.TabIndex = 6;
			button2.Text = "调整系数";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(Button2_Click);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(273, 28);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(600, 17);
			label4.TabIndex = 7;
			label4.Text = "滤波值：最大值为1，不能低于0，越接近1，滤波强度越强，也可能会导致失去真实信号，为0时没有滤波效果。";
			button3.Location = new System.Drawing.Point(807, 49);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(185, 23);
			button3.TabIndex = 8;
			button3.Text = "傅立叶图形(2次根)";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(button3);
			base.Controls.Add(label4);
			base.Controls.Add(button2);
			base.Controls.Add(textBox1);
			base.Controls.Add(label3);
			base.Controls.Add(button1);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(hslCurveHistory1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FourierFilter";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "傅立叶滤波";
			base.Load += new System.EventHandler(FourierFilter_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
