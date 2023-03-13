using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormImage : Form
	{
		private Bitmap bitmap;

		private IContainer components = null;

		private PictureBox pictureBox1;

		private Label label1;

		public FormImage(Bitmap bitmap)
		{
			InitializeComponent();
			this.bitmap = bitmap;
		}

		private void FormImage_Load(object sender, EventArgs e)
		{
			label1.BackColor = FormLoad.ThemeColor;
			pictureBox1.Image = bitmap;
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
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			pictureBox1.Location = new System.Drawing.Point(2, 39);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(1001, 601);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			label1.Dock = System.Windows.Forms.DockStyle.Top;
			label1.Location = new System.Drawing.Point(0, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(1004, 26);
			label1.TabIndex = 1;
			label1.Text = "标准图形";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(label1);
			base.Controls.Add(pictureBox1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormImage";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormImage";
			base.Load += new System.EventHandler(FormImage_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}
