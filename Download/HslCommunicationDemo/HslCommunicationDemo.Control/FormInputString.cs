using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo.Control
{
	public class FormInputString : Form
	{
		private IContainer components = null;

		private Label label1;

		private TextBox textBox1;

		private Button button1;

		public string DeviceAlias
		{
			get;
			set;
		}

		public FormInputString()
		{
			InitializeComponent();
		}

		private void FormInputString_Load(object sender, EventArgs e)
		{
			if (Program.Language == 2)
			{
				Text = "Please enter a string";
				label1.Text = "Please enter the alias information. If \":\" is entered in the middle, it will be used as the category separator";
				button1.Text = "ok";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox1.Text))
			{
				MessageBox.Show("Value can not be null");
			}
			else
			{
				DeviceAlias = textBox1.Text;
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
			textBox1 = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.Location = new System.Drawing.Point(3, 3);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(381, 46);
			label1.TabIndex = 0;
			label1.Text = "请输入别名信息，如果中间输入了 \":\"（英文），将作为类别分隔符";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			textBox1.Location = new System.Drawing.Point(12, 52);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(362, 23);
			textBox1.TabIndex = 1;
			button1.Location = new System.Drawing.Point(151, 81);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(93, 32);
			button1.TabIndex = 2;
			button1.Text = "确认";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(386, 125);
			base.Controls.Add(button1);
			base.Controls.Add(textBox1);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormInputString";
			base.ShowIcon = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "请输入字符串";
			base.Load += new System.EventHandler(FormInputString_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
