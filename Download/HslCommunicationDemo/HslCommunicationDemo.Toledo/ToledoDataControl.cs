using HslCommunication.Profinet.Toledo;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo.Toledo
{
	public class ToledoDataControl : UserControl
	{
		private IContainer components = null;

		private Label label1;

		private Label label2;

		private Label label3;

		private Label label4;

		private Label label5;

		private Label label6;

		private Label label7;

		private Label label8;

		private TextBox textBox1;

		private Label label9;

		private Label label10;

		private Label label12;

		private TextBox textBox2;

		private Label label11;

		private Label label13;

		private Label label14;

		private Label label15;

		private TextBox textBox3;

		public ToledoDataControl()
		{
			InitializeComponent();
		}

		private void ToledoDataControl_Load(object sender, EventArgs e)
		{
		}

		public void SetToledoData(ToledoStandardData data)
		{
			if (data.Suttle)
			{
				label2.BackColor = Color.Red;
				label1.BackColor = SystemColors.Control;
			}
			else
			{
				label1.BackColor = Color.Red;
				label2.BackColor = SystemColors.Control;
			}
			if (data.Symbol)
			{
				label3.BackColor = Color.Red;
				label4.BackColor = SystemColors.Control;
			}
			else
			{
				label4.BackColor = Color.Red;
				label3.BackColor = SystemColors.Control;
			}
			if (data.BeyondScope)
			{
				label6.BackColor = Color.Red;
				label5.BackColor = SystemColors.Control;
			}
			else
			{
				label5.BackColor = Color.Red;
				label6.BackColor = SystemColors.Control;
			}
			if (data.DynamicState)
			{
				label7.BackColor = Color.Red;
				label8.BackColor = SystemColors.Control;
			}
			else
			{
				label8.BackColor = Color.Red;
				label7.BackColor = SystemColors.Control;
			}
			textBox1.Text = data.Weight.ToString();
			label10.Text = data.Unit;
			textBox2.Text = data.Tare.ToString();
			if (Program.Language == 1)
			{
				label13.Text = (data.DataValid ? "有效" : "无效");
			}
			else
			{
				label13.Text = (data.DataValid ? "Valid" : "Invalid");
			}
			if (data.IsTenExtend)
			{
				if (Program.Language == 1)
				{
					textBox3.Text = ((data.TareType == 0) ? "无皮重" : ((data.TareType == 1) ? "按键去皮" : ((data.TareType == 2) ? "预置皮重" : "皮重内存")));
				}
				else
				{
					textBox3.Text = ((data.TareType == 0) ? "without tare" : ((data.TareType == 1) ? "key peeling" : ((data.TareType == 2) ? "Preset tare" : "Tare memory")));
				}
			}
			else
			{
				textBox3.Text = string.Empty;
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
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			SuspendLayout();
			label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label1.Location = new System.Drawing.Point(17, 36);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(75, 28);
			label1.TabIndex = 0;
			label1.Text = "毛重";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label2.Location = new System.Drawing.Point(121, 36);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(75, 28);
			label2.TabIndex = 1;
			label2.Text = "净重";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label3.Location = new System.Drawing.Point(17, 73);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(75, 28);
			label3.TabIndex = 2;
			label3.Text = "正";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label4.Location = new System.Drawing.Point(121, 73);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(75, 28);
			label4.TabIndex = 3;
			label4.Text = "负";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label5.Location = new System.Drawing.Point(17, 110);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(75, 28);
			label5.TabIndex = 4;
			label5.Text = "范围内";
			label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label6.Location = new System.Drawing.Point(121, 110);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(75, 28);
			label6.TabIndex = 5;
			label6.Text = "范围外";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label7.Location = new System.Drawing.Point(17, 148);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(75, 28);
			label7.TabIndex = 6;
			label7.Text = "动态";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label8.Location = new System.Drawing.Point(121, 148);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(75, 28);
			label8.TabIndex = 7;
			label8.Text = "稳态";
			label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			textBox1.Location = new System.Drawing.Point(72, 227);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(91, 23);
			textBox1.TabIndex = 8;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(13, 230);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(23, 17);
			label9.TabIndex = 9;
			label9.Text = "值:";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(169, 230);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(32, 17);
			label10.TabIndex = 10;
			label10.Text = "单位";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(13, 261);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(35, 17);
			label12.TabIndex = 12;
			label12.Text = "皮重:";
			textBox2.Location = new System.Drawing.Point(72, 258);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(91, 23);
			textBox2.TabIndex = 11;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(10, 9);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(56, 17);
			label11.TabIndex = 13;
			label11.Text = "数据值：";
			label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label13.Location = new System.Drawing.Point(121, 186);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(75, 28);
			label13.TabIndex = 14;
			label13.Text = "有效";
			label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(22, 192);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(71, 17);
			label14.TabIndex = 15;
			label14.Text = "数据有效性:";
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(13, 293);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(59, 17);
			label15.TabIndex = 17;
			label15.Text = "皮重类型:";
			textBox3.Location = new System.Drawing.Point(72, 290);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(91, 23);
			textBox3.TabIndex = 16;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(label15);
			base.Controls.Add(textBox3);
			base.Controls.Add(label14);
			base.Controls.Add(label13);
			base.Controls.Add(label11);
			base.Controls.Add(label12);
			base.Controls.Add(textBox2);
			base.Controls.Add(label10);
			base.Controls.Add(label9);
			base.Controls.Add(textBox1);
			base.Controls.Add(label8);
			base.Controls.Add(label7);
			base.Controls.Add(label6);
			base.Controls.Add(label5);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "ToledoDataControl";
			base.Size = new System.Drawing.Size(216, 329);
			base.Load += new System.EventHandler(ToledoDataControl_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
