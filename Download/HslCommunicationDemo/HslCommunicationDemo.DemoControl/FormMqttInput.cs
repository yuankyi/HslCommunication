using HslCommunication.MQTT;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo.DemoControl
{
	public class FormMqttInput : Form
	{
		private IContainer components = null;

		private Label label1;

		private TextBox textBox_ip;

		private TextBox textBox_port;

		private Label label2;

		private TextBox textBox_name;

		private Label label3;

		private TextBox textBox_password;

		private Label label4;

		private TextBox textBox_clientid;

		private Label label5;

		private TextBox textBox_read_topic;

		private Label label6;

		private TextBox textBox_write_topic;

		private Label label7;

		private Button button1;

		public MqttConnectionOptions MqttConnectionOptions
		{
			get;
			set;
		}

		public string ReadTopic
		{
			get;
			set;
		}

		public string WriteTopic
		{
			get;
			set;
		}

		public FormMqttInput()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MqttConnectionOptions = new MqttConnectionOptions();
			MqttConnectionOptions.IpAddress = textBox_ip.Text;
			MqttConnectionOptions.Port = int.Parse(textBox_port.Text);
			MqttConnectionOptions.ClientId = textBox_clientid.Text;
			if (!string.IsNullOrEmpty(textBox_name.Text))
			{
				MqttConnectionOptions.Credentials = new MqttCredential(textBox_name.Text, textBox_password.Text);
			}
			ReadTopic = textBox_read_topic.Text;
			WriteTopic = textBox_write_topic.Text;
			base.DialogResult = DialogResult.OK;
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
			textBox_ip = new System.Windows.Forms.TextBox();
			textBox_port = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox_name = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox_password = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox_clientid = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			textBox_read_topic = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			textBox_write_topic = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(27, 33);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(62, 17);
			label1.TabIndex = 0;
			label1.Text = "MQTT IP:";
			textBox_ip.Location = new System.Drawing.Point(111, 30);
			textBox_ip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			textBox_ip.Name = "textBox_ip";
			textBox_ip.Size = new System.Drawing.Size(306, 23);
			textBox_ip.TabIndex = 1;
			textBox_ip.Text = "127.0.0.1";
			textBox_port.Location = new System.Drawing.Point(111, 64);
			textBox_port.Margin = new System.Windows.Forms.Padding(4);
			textBox_port.Name = "textBox_port";
			textBox_port.Size = new System.Drawing.Size(306, 23);
			textBox_port.TabIndex = 3;
			textBox_port.Text = "1883";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label2.Location = new System.Drawing.Point(27, 67);
			label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(83, 17);
			label2.TabIndex = 2;
			label2.Text = "MQTT PORT:";
			textBox_name.Location = new System.Drawing.Point(111, 99);
			textBox_name.Margin = new System.Windows.Forms.Padding(4);
			textBox_name.Name = "textBox_name";
			textBox_name.Size = new System.Drawing.Size(306, 23);
			textBox_name.TabIndex = 5;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label3.Location = new System.Drawing.Point(27, 102);
			label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(73, 17);
			label3.TabIndex = 4;
			label3.Text = "UserName:";
			textBox_password.Location = new System.Drawing.Point(111, 135);
			textBox_password.Margin = new System.Windows.Forms.Padding(4);
			textBox_password.Name = "textBox_password";
			textBox_password.Size = new System.Drawing.Size(306, 23);
			textBox_password.TabIndex = 7;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label4.Location = new System.Drawing.Point(27, 138);
			label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(67, 17);
			label4.TabIndex = 6;
			label4.Text = "Password:";
			textBox_clientid.Location = new System.Drawing.Point(111, 174);
			textBox_clientid.Margin = new System.Windows.Forms.Padding(4);
			textBox_clientid.Name = "textBox_clientid";
			textBox_clientid.Size = new System.Drawing.Size(306, 23);
			textBox_clientid.TabIndex = 9;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label5.Location = new System.Drawing.Point(27, 177);
			label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(60, 17);
			label5.TabIndex = 8;
			label5.Text = "Client ID:";
			textBox_read_topic.Location = new System.Drawing.Point(162, 211);
			textBox_read_topic.Margin = new System.Windows.Forms.Padding(4);
			textBox_read_topic.Name = "textBox_read_topic";
			textBox_read_topic.Size = new System.Drawing.Size(255, 23);
			textBox_read_topic.TabIndex = 11;
			textBox_read_topic.Text = "DeviceToMqtt";
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label6.Location = new System.Drawing.Point(27, 214);
			label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(127, 17);
			label6.TabIndex = 10;
			label6.Text = "Device->Mqtt Topic:";
			textBox_write_topic.Location = new System.Drawing.Point(162, 243);
			textBox_write_topic.Margin = new System.Windows.Forms.Padding(4);
			textBox_write_topic.Name = "textBox_write_topic";
			textBox_write_topic.Size = new System.Drawing.Size(255, 23);
			textBox_write_topic.TabIndex = 13;
			textBox_write_topic.Text = "MqttToDevice";
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label7.Location = new System.Drawing.Point(27, 246);
			label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(127, 17);
			label7.TabIndex = 12;
			label7.Text = "Mqtt->Device Topic:";
			button1.Location = new System.Drawing.Point(139, 286);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(153, 38);
			button1.TabIndex = 14;
			button1.Text = "OK";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(450, 346);
			base.Controls.Add(button1);
			base.Controls.Add(textBox_write_topic);
			base.Controls.Add(label7);
			base.Controls.Add(textBox_read_topic);
			base.Controls.Add(label6);
			base.Controls.Add(textBox_clientid);
			base.Controls.Add(label5);
			base.Controls.Add(textBox_password);
			base.Controls.Add(label4);
			base.Controls.Add(textBox_name);
			base.Controls.Add(label3);
			base.Controls.Add(textBox_port);
			base.Controls.Add(label2);
			base.Controls.Add(textBox_ip);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			base.Name = "FormMqttInput";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormMqttInput";
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
