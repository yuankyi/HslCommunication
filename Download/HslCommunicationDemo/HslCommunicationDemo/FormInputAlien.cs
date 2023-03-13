using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormInputAlien : HslFormContent
	{
		private IContainer components = null;

		private Label label1;

		private Label label2;

		private Label label3;

		private TextBox textBox1;

		private TextBox textBox2;

		private TextBox textBox3;

		private Button button1;

		private TextBox textBox4;

		private Label label4;

		public string IpAddress
		{
			get;
			set;
		}

		public int Port
		{
			get;
			set;
		}

		public string DTU
		{
			get;
			set;
		}

		public string Pwd
		{
			get;
			set;
		}

		public FormInputAlien()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			IPAddress address;
			int result;
			if (!IPAddress.TryParse(textBox1.Text, out address))
			{
				MessageBox.Show("IP地址填写失败");
			}
			else if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show("端口号填写失败！");
			}
			else
			{
				IpAddress = address.ToString();
				Port = result;
				DTU = textBox3.Text;
				Pwd = textBox4.Text;
				base.DialogResult = DialogResult.OK;
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
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			textBox2 = new System.Windows.Forms.TextBox();
			textBox3 = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(39, 26);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(60, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip 地址：";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(39, 54);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(56, 17);
			label2.TabIndex = 1;
			label2.Text = "端口号：";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(39, 81);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(57, 17);
			label3.TabIndex = 2;
			label3.Text = "唯一ID：";
			textBox1.Location = new System.Drawing.Point(105, 23);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(182, 23);
			textBox1.TabIndex = 3;
			textBox1.Text = "192.168.0.105";
			textBox2.Location = new System.Drawing.Point(105, 51);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(182, 23);
			textBox2.TabIndex = 4;
			textBox2.Text = "10000";
			textBox3.Location = new System.Drawing.Point(105, 78);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(182, 23);
			textBox3.TabIndex = 5;
			textBox3.Text = "12345678901";
			button1.Location = new System.Drawing.Point(129, 145);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 6;
			button1.Text = "确认";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox4.Location = new System.Drawing.Point(105, 107);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(182, 23);
			textBox4.TabIndex = 8;
			textBox4.Text = "123456";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(39, 110);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(44, 17);
			label4.TabIndex = 7;
			label4.Text = "密码：";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(337, 185);
			base.Controls.Add(textBox4);
			base.Controls.Add(label4);
			base.Controls.Add(button1);
			base.Controls.Add(textBox3);
			base.Controls.Add(textBox2);
			base.Controls.Add(textBox1);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormInputAlien";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormInputAlien";
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
