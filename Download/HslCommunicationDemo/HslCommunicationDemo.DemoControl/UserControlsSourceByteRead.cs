using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo.DemoControl
{
	public class UserControlsSourceByteRead : UserControl
	{
		private IContainer components = null;

		private TextBox textBox10;

		private Label label13;

		private Button button_read;

		private TextBox textBox_length;

		private Label label12;

		private TextBox textBox_address;

		private Label label11;

		public UserControlsSourceByteRead()
		{
			InitializeComponent();
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
			textBox10 = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			button_read = new System.Windows.Forms.Button();
			textBox_length = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			textBox_address = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			SuspendLayout();
			textBox10.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox10.Location = new System.Drawing.Point(57, 39);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(606, 137);
			textBox10.TabIndex = 17;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(3, 41);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 16;
			label13.Text = "结果：";
			button_read.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_read.Location = new System.Drawing.Point(563, 3);
			button_read.Name = "button_read";
			button_read.Size = new System.Drawing.Size(103, 28);
			button_read.TabIndex = 15;
			button_read.Text = "批量读取";
			button_read.UseVisualStyleBackColor = true;
			textBox_length.Location = new System.Drawing.Point(343, 6);
			textBox_length.Name = "textBox_length";
			textBox_length.Size = new System.Drawing.Size(123, 23);
			textBox_length.TabIndex = 14;
			textBox_length.Text = "10";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(289, 9);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(44, 17);
			label12.TabIndex = 13;
			label12.Text = "长度：";
			textBox_address.Location = new System.Drawing.Point(57, 6);
			textBox_address.Name = "textBox_address";
			textBox_address.Size = new System.Drawing.Size(226, 23);
			textBox_address.TabIndex = 12;
			textBox_address.Text = "100";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(3, 9);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 11;
			label11.Text = "地址：";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(textBox10);
			base.Controls.Add(label13);
			base.Controls.Add(button_read);
			base.Controls.Add(textBox_length);
			base.Controls.Add(label12);
			base.Controls.Add(textBox_address);
			base.Controls.Add(label11);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "UserControlsSourceByteRead";
			base.Size = new System.Drawing.Size(669, 182);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
