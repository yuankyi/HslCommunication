using HslCommunication.Algorithms.Fourier;
using HslCommunication.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HslCommunicationDemo.Algorithms
{
	public class FourierTransform : HslFormContent
	{
		private IContainer components = null;

		private Label label5;

		private UserCurve userCurve1;

		private UserCurve userCurve2;

		private Label label1;

		private Label label3;

		private UserCurve userCurve3;

		private UserCurve userCurve4;

		private Label label6;

		private UserCurve userCurve5;

		private UserCurve userCurve6;

		private UserButton userButton1;

		private UserButton userButton2;

		private UserButton userButton3;

		public FourierTransform()
		{
			InitializeComponent();
		}

		private void 傅立叶变换_Load(object sender, EventArgs e)
		{
			Squarewave();
			Sinawave();
			Others();
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language == 1)
			{
				Text = "傅里叶变换测试";
				label5.Text = "FFT 快速离散傅立叶变换";
				label1.Text = "方波及变换后的波形";
				label3.Text = "正弦波及变换后的波形";
				label6.Text = "混合波及变换后的波形";
				userButton1.UIText = "专用图形";
				userButton2.UIText = "专用图形";
				userButton3.UIText = "专用图形";
			}
			else
			{
				Text = "FFT Test";
				label5.Text = "FFT Fast discrete Fourier transform";
				label1.Text = "The waveform of the square sweep and the transformed";
				label3.Text = "Waveform after sine wave and transform";
				label6.Text = "Waveform after mixed sweep and transform";
				userButton1.UIText = "Graphics";
				userButton2.UIText = "Graphics";
				userButton3.UIText = "Graphics";
			}
		}

		private void Squarewave()
		{
			double[] array = new double[256];
			for (int i = 0; i < array.Length / 2; i++)
			{
				array[i] = 5.0;
			}
			userCurve1.SetCurve("A", true, (from m in array
			select (float)m).ToArray(), Color.Red, 1f);
			double[] source = FFTHelper.FFT(array);
			userCurve2.ValueMaxLeft = (float)source.Max();
			userCurve2.ValueMaxRight = (float)source.Max();
			userCurve2.SetCurve("A", true, (from m in source
			select (float)m).ToArray(), Color.Blue, 1f);
		}

		private void Sinawave()
		{
			double[] array = new double[256];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 5.0 * Math.Sin((double)i * 3.1415926535897931 / 128.0) + 5.0 + 0.5 * Math.Cos((double)(i * 8) * 3.1415926535897931 / 128.0);
			}
			userCurve4.SetCurve("A", true, (from m in array
			select (float)m).ToArray(), Color.Red, 1f);
			double[] source = FFTHelper.FFT(array);
			userCurve3.ValueMaxLeft = (float)source.Max();
			userCurve3.ValueMaxRight = (float)source.Max();
			userCurve3.SetCurve("A", true, (from m in source
			select (float)m).ToArray(), Color.Blue, 1f);
		}

		private void Others()
		{
			double[] array = new double[256];
			for (int i = 0; i < array.Length; i++)
			{
				if (i > 140 && i < 160)
				{
					array[i] = 5.0;
				}
			}
			userCurve6.SetCurve("A", true, (from m in array
			select (float)m).ToArray(), Color.Red, 1f);
			double[] source = FFTHelper.FFT(array);
			userCurve5.ValueMaxLeft = (float)source.Max();
			userCurve5.ValueMaxRight = (float)source.Max();
			userCurve5.SetCurve("A", true, (from m in source
			select (float)m).ToArray(), Color.Blue, 1f);
		}

		private void userButton1_Click(object sender, EventArgs e)
		{
			double[] array = new double[256];
			for (int i = 0; i < array.Length / 2; i++)
			{
				array[i] = 5.0;
			}
			using (FormImage formImage = new FormImage(FFTHelper.GetFFTImage(array, 1000, 600, Color.Blue)))
			{
				formImage.ShowDialog();
			}
		}

		private void userButton2_Click(object sender, EventArgs e)
		{
			double[] array = new double[256];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 5.0 * Math.Sin((double)i * 3.1415926535897931 / 128.0) + 5.0 + 0.5 * Math.Cos((double)(i * 8) * 3.1415926535897931 / 128.0);
			}
			using (FormImage formImage = new FormImage(FFTHelper.GetFFTImage(array, 1000, 600, Color.Blue)))
			{
				formImage.ShowDialog();
			}
		}

		private void userButton3_Click(object sender, EventArgs e)
		{
			double[] array = new double[256];
			for (int i = 0; i < array.Length; i++)
			{
				if (i > 140 && i < 160)
				{
					array[i] = 5.0;
				}
			}
			using (FormImage formImage = new FormImage(FFTHelper.GetFFTImage(array, 1000, 600, Color.Blue)))
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
			label5 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			userButton1 = new HslCommunication.Controls.UserButton();
			userCurve5 = new HslCommunication.Controls.UserCurve();
			userCurve6 = new HslCommunication.Controls.UserCurve();
			userCurve3 = new HslCommunication.Controls.UserCurve();
			userCurve4 = new HslCommunication.Controls.UserCurve();
			userCurve2 = new HslCommunication.Controls.UserCurve();
			userCurve1 = new HslCommunication.Controls.UserCurve();
			userButton2 = new HslCommunication.Controls.UserButton();
			userButton3 = new HslCommunication.Controls.UserButton();
			SuspendLayout();
			label5.AutoSize = true;
			label5.ForeColor = System.Drawing.Color.Red;
			label5.Location = new System.Drawing.Point(404, 3);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(139, 17);
			label5.TabIndex = 10;
			label5.Text = "FFT 快速离散傅立叶变换";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 25);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(116, 17);
			label1.TabIndex = 14;
			label1.Text = "方波及变换后的波形";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(8, 236);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(128, 17);
			label3.TabIndex = 17;
			label3.Text = "正弦波及变换后的波形";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(8, 445);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(128, 17);
			label6.TabIndex = 20;
			label6.Text = "混合波及变换后的波形";
			userButton1.BackColor = System.Drawing.Color.Transparent;
			userButton1.CustomerInformation = "";
			userButton1.EnableColor = System.Drawing.Color.FromArgb(190, 190, 190);
			userButton1.Font = new System.Drawing.Font("微软雅黑", 9f);
			userButton1.Location = new System.Drawing.Point(918, 25);
			userButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userButton1.Name = "userButton1";
			userButton1.Size = new System.Drawing.Size(78, 25);
			userButton1.TabIndex = 21;
			userButton1.UIText = "专用图形";
			userButton1.Click += new System.EventHandler(userButton1_Click);
			userCurve5.BackColor = System.Drawing.Color.Transparent;
			userCurve5.IsAbscissaStrech = true;
			userCurve5.Location = new System.Drawing.Point(510, 459);
			userCurve5.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
			userCurve5.Name = "userCurve5";
			userCurve5.Size = new System.Drawing.Size(463, 190);
			userCurve5.StrechDataCountMax = 256;
			userCurve5.TabIndex = 19;
			userCurve6.BackColor = System.Drawing.Color.Transparent;
			userCurve6.IsAbscissaStrech = true;
			userCurve6.Location = new System.Drawing.Point(24, 459);
			userCurve6.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
			userCurve6.Name = "userCurve6";
			userCurve6.Size = new System.Drawing.Size(463, 190);
			userCurve6.StrechDataCountMax = 256;
			userCurve6.TabIndex = 18;
			userCurve6.ValueMaxLeft = 10f;
			userCurve6.ValueMaxRight = 10f;
			userCurve3.BackColor = System.Drawing.Color.Transparent;
			userCurve3.IsAbscissaStrech = true;
			userCurve3.Location = new System.Drawing.Point(510, 255);
			userCurve3.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
			userCurve3.Name = "userCurve3";
			userCurve3.Size = new System.Drawing.Size(463, 190);
			userCurve3.StrechDataCountMax = 256;
			userCurve3.TabIndex = 16;
			userCurve4.BackColor = System.Drawing.Color.Transparent;
			userCurve4.IsAbscissaStrech = true;
			userCurve4.Location = new System.Drawing.Point(24, 255);
			userCurve4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			userCurve4.Name = "userCurve4";
			userCurve4.Size = new System.Drawing.Size(463, 190);
			userCurve4.StrechDataCountMax = 256;
			userCurve4.TabIndex = 15;
			userCurve4.ValueMaxLeft = 10f;
			userCurve4.ValueMaxRight = 10f;
			userCurve2.BackColor = System.Drawing.Color.Transparent;
			userCurve2.IsAbscissaStrech = true;
			userCurve2.Location = new System.Drawing.Point(510, 43);
			userCurve2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			userCurve2.Name = "userCurve2";
			userCurve2.Size = new System.Drawing.Size(463, 190);
			userCurve2.StrechDataCountMax = 256;
			userCurve2.TabIndex = 13;
			userCurve1.BackColor = System.Drawing.Color.Transparent;
			userCurve1.IsAbscissaStrech = true;
			userCurve1.Location = new System.Drawing.Point(24, 43);
			userCurve1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userCurve1.Name = "userCurve1";
			userCurve1.Size = new System.Drawing.Size(463, 190);
			userCurve1.StrechDataCountMax = 256;
			userCurve1.TabIndex = 12;
			userCurve1.ValueMaxLeft = 10f;
			userCurve1.ValueMaxRight = 10f;
			userButton2.BackColor = System.Drawing.Color.Transparent;
			userButton2.CustomerInformation = "";
			userButton2.EnableColor = System.Drawing.Color.FromArgb(190, 190, 190);
			userButton2.Font = new System.Drawing.Font("微软雅黑", 9f);
			userButton2.Location = new System.Drawing.Point(918, 236);
			userButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userButton2.Name = "userButton2";
			userButton2.Size = new System.Drawing.Size(78, 25);
			userButton2.TabIndex = 22;
			userButton2.UIText = "专用图形";
			userButton2.Click += new System.EventHandler(userButton2_Click);
			userButton3.BackColor = System.Drawing.Color.Transparent;
			userButton3.CustomerInformation = "";
			userButton3.EnableColor = System.Drawing.Color.FromArgb(190, 190, 190);
			userButton3.Font = new System.Drawing.Font("微软雅黑", 9f);
			userButton3.Location = new System.Drawing.Point(918, 437);
			userButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userButton3.Name = "userButton3";
			userButton3.Size = new System.Drawing.Size(78, 25);
			userButton3.TabIndex = 23;
			userButton3.UIText = "专用图形";
			userButton3.Click += new System.EventHandler(userButton3_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userButton3);
			base.Controls.Add(userButton2);
			base.Controls.Add(userButton1);
			base.Controls.Add(label6);
			base.Controls.Add(userCurve5);
			base.Controls.Add(userCurve6);
			base.Controls.Add(label3);
			base.Controls.Add(userCurve3);
			base.Controls.Add(userCurve4);
			base.Controls.Add(label1);
			base.Controls.Add(userCurve2);
			base.Controls.Add(userCurve1);
			base.Controls.Add(label5);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FourierTransform";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "傅立叶变换";
			base.Load += new System.EventHandler(傅立叶变换_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
