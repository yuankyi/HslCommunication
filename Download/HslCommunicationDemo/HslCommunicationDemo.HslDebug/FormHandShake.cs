using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Profinet.AllenBradley;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo.HslDebug
{
	public class FormHandShake : Form
	{
		private List<byte[]> handShake = null;

		private IContainer components = null;

		private Label label1;

		private TextBox textBox1;

		private Panel panel3;

		private RadioButton radioButton_hex;

		private RadioButton radioButton_binary;

		private Label label6;

		private TextBox textBox2;

		private Label label2;

		private TextBox textBox3;

		private Label label3;

		private Label label4;

		private Button button1;

		private Button button2;

		private Button button3;

		private Button button_clear;

		private Button button_ok;

		private Button button_cancel;

		public List<byte[]> HandShake
		{
			get
			{
				return handShake;
			}
		}

		public FormHandShake(List<byte[]> handShake)
		{
			InitializeComponent();
			this.handShake = handShake;
		}

		private void button_clear_Click(object sender, EventArgs e)
		{
			textBox1.Text = string.Empty;
			textBox2.Text = string.Empty;
			textBox3.Text = string.Empty;
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			List<byte[]> list = new List<byte[]>();
			if (!string.IsNullOrEmpty(textBox1.Text))
			{
				list.Add(radioButton_binary.Checked ? textBox1.Text.ToHexBytes() : Encoding.ASCII.GetBytes(textBox1.Text));
			}
			if (!string.IsNullOrEmpty(textBox2.Text))
			{
				list.Add(radioButton_binary.Checked ? textBox2.Text.ToHexBytes() : Encoding.ASCII.GetBytes(textBox2.Text));
			}
			if (!string.IsNullOrEmpty(textBox3.Text))
			{
				list.Add(radioButton_binary.Checked ? textBox3.Text.ToHexBytes() : Encoding.ASCII.GetBytes(textBox3.Text));
			}
			handShake = list;
			base.DialogResult = DialogResult.OK;
		}

		private void FormHandShake_Load(object sender, EventArgs e)
		{
			if (handShake != null)
			{
				if (handShake.Count > 0)
				{
					textBox1.Text = (radioButton_binary.Checked ? handShake[0].ToHexString(' ') : SoftBasic.GetAsciiStringRender(handShake[0]));
				}
				if (handShake.Count > 1)
				{
					textBox2.Text = (radioButton_binary.Checked ? handShake[1].ToHexString(' ') : SoftBasic.GetAsciiStringRender(handShake[1]));
				}
				if (handShake.Count > 2)
				{
					textBox3.Text = (radioButton_binary.Checked ? handShake[2].ToHexString(' ') : SoftBasic.GetAsciiStringRender(handShake[2]));
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			textBox1.Text = new byte[22]
			{
				3,
				0,
				0,
				22,
				17,
				224,
				0,
				0,
				0,
				1,
				0,
				192,
				1,
				10,
				193,
				2,
				1,
				2,
				194,
				2,
				1,
				0
			}.ToHexString(' ');
			textBox2.Text = new byte[25]
			{
				3,
				0,
				0,
				25,
				2,
				240,
				128,
				50,
				1,
				0,
				0,
				4,
				0,
				0,
				8,
				0,
				0,
				240,
				0,
				0,
				1,
				0,
				1,
				1,
				224
			}.ToHexString(' ');
			textBox3.Text = string.Empty;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			textBox1.Text = new byte[20]
			{
				70,
				73,
				78,
				83,
				0,
				0,
				0,
				12,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			}.ToHexString(' ');
			textBox2.Text = string.Empty;
			textBox3.Text = string.Empty;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			textBox1.Text = AllenBradleyHelper.RegisterSessionHandle().ToHexString(' ');
			textBox2.Text = string.Empty;
			textBox3.Text = string.Empty;
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
			panel3 = new System.Windows.Forms.Panel();
			radioButton_hex = new System.Windows.Forms.RadioButton();
			radioButton_binary = new System.Windows.Forms.RadioButton();
			label6 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			button_clear = new System.Windows.Forms.Button();
			button_ok = new System.Windows.Forms.Button();
			button_cancel = new System.Windows.Forms.Button();
			panel3.SuspendLayout();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 39);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(63, 17);
			label1.TabIndex = 0;
			label1.Text = "握手报文1";
			textBox1.Location = new System.Drawing.Point(96, 36);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(609, 23);
			textBox1.TabIndex = 1;
			panel3.BackColor = System.Drawing.SystemColors.Control;
			panel3.Controls.Add(radioButton_hex);
			panel3.Controls.Add(radioButton_binary);
			panel3.Location = new System.Drawing.Point(96, 4);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(155, 28);
			panel3.TabIndex = 32;
			radioButton_hex.AutoSize = true;
			radioButton_hex.Location = new System.Drawing.Point(86, 3);
			radioButton_hex.Name = "radioButton_hex";
			radioButton_hex.Size = new System.Drawing.Size(57, 21);
			radioButton_hex.TabIndex = 1;
			radioButton_hex.Text = "ASCII";
			radioButton_hex.UseVisualStyleBackColor = true;
			radioButton_binary.AutoSize = true;
			radioButton_binary.Checked = true;
			radioButton_binary.Location = new System.Drawing.Point(7, 3);
			radioButton_binary.Name = "radioButton_binary";
			radioButton_binary.Size = new System.Drawing.Size(62, 21);
			radioButton_binary.TabIndex = 0;
			radioButton_binary.TabStop = true;
			radioButton_binary.Text = "Binary";
			radioButton_binary.UseVisualStyleBackColor = true;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(12, 9);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(68, 17);
			label6.TabIndex = 31;
			label6.Text = "数据格式：";
			textBox2.Location = new System.Drawing.Point(96, 69);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(609, 23);
			textBox2.TabIndex = 34;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(12, 72);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(63, 17);
			label2.TabIndex = 33;
			label2.Text = "握手报文2";
			textBox3.Location = new System.Drawing.Point(96, 104);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(609, 23);
			textBox3.TabIndex = 36;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(12, 107);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(63, 17);
			label3.TabIndex = 35;
			label3.Text = "握手报文3";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(12, 141);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(59, 17);
			label4.TabIndex = 37;
			label4.Text = "常见握手:";
			button1.Location = new System.Drawing.Point(93, 135);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(86, 27);
			button1.TabIndex = 38;
			button1.Text = "SiemensS7";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			button2.Location = new System.Drawing.Point(185, 135);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(86, 27);
			button2.TabIndex = 39;
			button2.Text = "FinsTcp";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button3.Location = new System.Drawing.Point(277, 135);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(86, 27);
			button3.TabIndex = 40;
			button3.Text = "cip";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button_clear.Location = new System.Drawing.Point(619, 4);
			button_clear.Name = "button_clear";
			button_clear.Size = new System.Drawing.Size(86, 27);
			button_clear.TabIndex = 41;
			button_clear.Text = "Clear";
			button_clear.UseVisualStyleBackColor = true;
			button_clear.Click += new System.EventHandler(button_clear_Click);
			button_ok.Location = new System.Drawing.Point(277, 273);
			button_ok.Name = "button_ok";
			button_ok.Size = new System.Drawing.Size(138, 41);
			button_ok.TabIndex = 42;
			button_ok.Text = "OK";
			button_ok.UseVisualStyleBackColor = true;
			button_ok.Click += new System.EventHandler(button_ok_Click);
			button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			button_cancel.Location = new System.Drawing.Point(-421, 285);
			button_cancel.Name = "button_cancel";
			button_cancel.Size = new System.Drawing.Size(138, 41);
			button_cancel.TabIndex = 43;
			button_cancel.Text = "CANCEL";
			button_cancel.UseVisualStyleBackColor = true;
			base.AcceptButton = button_ok;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.CancelButton = button_cancel;
			base.ClientSize = new System.Drawing.Size(717, 338);
			base.Controls.Add(button_cancel);
			base.Controls.Add(button_ok);
			base.Controls.Add(button_clear);
			base.Controls.Add(button3);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(label4);
			base.Controls.Add(textBox3);
			base.Controls.Add(label3);
			base.Controls.Add(textBox2);
			base.Controls.Add(label2);
			base.Controls.Add(panel3);
			base.Controls.Add(label6);
			base.Controls.Add(textBox1);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormHandShake";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "HandShake";
			base.Load += new System.EventHandler(FormHandShake_Load);
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
