using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormNewVerison : Form
	{
		private IContainer components = null;

		private Button button1;

		private Button button2;

		private CheckBox checkBox1;

		private Label label1;

		public bool NewVersionIngored
		{
			get
			{
				return checkBox1.Checked;
			}
		}

		public FormNewVerison()
		{
			InitializeComponent();
		}

		public DialogResult ShowDialog(string caption, string info)
		{
			Text = caption;
			label1.Text = info;
			return ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.No;
		}

		private void FormNewVerison_Load(object sender, EventArgs e)
		{
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
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			checkBox1 = new System.Windows.Forms.CheckBox();
			label1 = new System.Windows.Forms.Label();
			SuspendLayout();
			button1.Location = new System.Drawing.Point(163, 145);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(116, 34);
			button1.TabIndex = 0;
			button1.Text = "Yes (是)";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			button2.Location = new System.Drawing.Point(285, 145);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(116, 34);
			button2.TabIndex = 1;
			button2.Text = "No (否)";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(209, 182);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(148, 21);
			checkBox1.TabIndex = 2;
			checkBox1.Text = "Do not remind again";
			checkBox1.UseVisualStyleBackColor = true;
			label1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(12, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(554, 124);
			label1.TabIndex = 3;
			label1.Text = "label1";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(578, 203);
			base.Controls.Add(label1);
			base.Controls.Add(checkBox1);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormNewVerison";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormNewVerison";
			base.Load += new System.EventHandler(FormNewVerison_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
