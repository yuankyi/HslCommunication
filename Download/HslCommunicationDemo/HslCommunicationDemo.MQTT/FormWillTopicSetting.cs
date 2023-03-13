using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo.MQTT
{
	public class FormWillTopicSetting : Form
	{
		private string topic;

		private string message;

		private IContainer components = null;

		private Label label1;

		private TextBox textBox_topic;

		private TextBox textBox_message;

		private Label label2;

		private Button button1;

		public string Topic
		{
			get
			{
				return topic;
			}
		}

		public string Message
		{
			get
			{
				return message;
			}
		}

		public FormWillTopicSetting(string topic, string message)
		{
			InitializeComponent();
			this.topic = topic;
			this.message = message;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			topic = textBox_topic.Text;
			message = textBox_message.Text;
			base.DialogResult = DialogResult.OK;
		}

		private void FormWillTopicSetting_Load(object sender, EventArgs e)
		{
			textBox_topic.Text = topic;
			textBox_message.Text = message;
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
			textBox_topic = new System.Windows.Forms.TextBox();
			textBox_message = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(19, 20);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(68, 17);
			label1.TabIndex = 0;
			label1.Text = "Wiil Topic:";
			textBox_topic.Location = new System.Drawing.Point(93, 17);
			textBox_topic.Name = "textBox_topic";
			textBox_topic.Size = new System.Drawing.Size(240, 23);
			textBox_topic.TabIndex = 1;
			textBox_message.Location = new System.Drawing.Point(22, 79);
			textBox_message.Multiline = true;
			textBox_message.Name = "textBox_message";
			textBox_message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_message.Size = new System.Drawing.Size(311, 154);
			textBox_message.TabIndex = 3;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(19, 54);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(89, 17);
			label2.TabIndex = 2;
			label2.Text = "Wiil Message:";
			button1.Location = new System.Drawing.Point(104, 249);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(135, 37);
			button1.TabIndex = 4;
			button1.Text = "OK";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(348, 307);
			base.Controls.Add(button1);
			base.Controls.Add(textBox_message);
			base.Controls.Add(label2);
			base.Controls.Add(textBox_topic);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormWillTopicSetting";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "WillTopicSetting";
			base.Load += new System.EventHandler(FormWillTopicSetting_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
