using HslCommunication;
using HslCommunication.MQTT;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.MQTT
{
	public class FormMqttSubscribe : Form
	{
		private MqttClient mqttClient = null;

		private long receiveCount = 0L;

		private IContainer components = null;

		private TextBox textBox5;

		private Label label7;

		private Label label10;

		private Panel panel3;

		private RadioButton radioButton_binary;

		private RadioButton radioButton_json;

		private RadioButton radioButton_text;

		private RadioButton radioButton_xml;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private TextBox textBox8;

		private Label label12;

		private Button button4;

		private Button button8;

		private Button button7;

		private CheckBox checkBox_long_message_hide;

		public FormMqttSubscribe(MqttClient mqttClient)
		{
			InitializeComponent();
			this.mqttClient = mqttClient;
		}

		private void FormMqttSubscribe_Load(object sender, EventArgs e)
		{
			button8.Enabled = false;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = mqttClient.SubscribeMessage(new string[1]
			{
				textBox5.Text
			});
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show("SubscribeMessage Failed:" + operateResult.Message);
			}
			else
			{
				SubscribeTopic subscribeTopic = mqttClient.GetSubscribeTopic(textBox5.Text);
				if (subscribeTopic != null)
				{
					subscribeTopic.OnMqttMessageReceived += FormMqttSubscribe_OnMqttMessageReceived;
				}
				button7.Enabled = false;
				button8.Enabled = true;
			}
		}

		private void FormMqttSubscribe_OnMqttMessageReceived(MqttClient client, string topic, byte[] payload)
		{
			try
			{
				Invoke((Action)delegate
				{
					receiveCount++;
					label10.Text = "Receive Count: " + receiveCount.ToString();
					string text = string.Empty;
					if (radioButton_binary.Checked)
					{
						text = payload.ToHexString(' ');
					}
					else if (radioButton_text.Checked)
					{
						text = Encoding.UTF8.GetString(payload);
					}
					else if (radioButton_xml.Checked)
					{
						try
						{
							text = XElement.Parse(Encoding.UTF8.GetString(payload)).ToString();
						}
						catch
						{
							text = Encoding.UTF8.GetString(payload);
						}
					}
					else if (radioButton_json.Checked)
					{
						try
						{
							text = JObject.Parse(Encoding.UTF8.GetString(payload)).ToString();
						}
						catch
						{
							text = Encoding.UTF8.GetString(payload);
						}
					}
					if (checkBox_long_message_hide.Checked && text != null && text.Length > 200)
					{
						text = text.Substring(200);
					}
					if (radioButton2.Checked)
					{
						textBox8.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Topic[" + topic + "]: " + text + Environment.NewLine);
					}
					else if (radioButton1.Checked)
					{
						textBox8.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Topic[" + topic + "]: " + text;
					}
				});
			}
			catch
			{
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			SubscribeTopic subscribeTopic = mqttClient.GetSubscribeTopic(textBox5.Text);
			if (subscribeTopic != null)
			{
				subscribeTopic.OnMqttMessageReceived -= FormMqttSubscribe_OnMqttMessageReceived;
				if (subscribeTopic.RemoveSubscribeTick() <= 0)
				{
					OperateResult operateResult = mqttClient.UnSubscribeMessage(textBox5.Text);
					if (!operateResult.IsSuccess)
					{
						MessageBox.Show("UnSubscribeMessage Failed:" + operateResult.Message);
					}
					else
					{
						button7.Enabled = true;
						button8.Enabled = false;
					}
				}
				else
				{
					button7.Enabled = true;
					button8.Enabled = false;
				}
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			textBox8.Clear();
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
			textBox5 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			radioButton_binary = new System.Windows.Forms.RadioButton();
			radioButton_json = new System.Windows.Forms.RadioButton();
			radioButton_text = new System.Windows.Forms.RadioButton();
			radioButton_xml = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton1 = new System.Windows.Forms.RadioButton();
			textBox8 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			button4 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			checkBox_long_message_hide = new System.Windows.Forms.CheckBox();
			panel3.SuspendLayout();
			SuspendLayout();
			textBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox5.Location = new System.Drawing.Point(70, 19);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(559, 23);
			textBox5.TabIndex = 11;
			textBox5.Text = "A";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(12, 23);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(52, 17);
			label7.TabIndex = 10;
			label7.Text = "Topic：";
			label10.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(69, 430);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(93, 17);
			label10.TabIndex = 35;
			label10.Text = "Receive Count:";
			panel3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			panel3.Controls.Add(radioButton_binary);
			panel3.Controls.Add(radioButton_json);
			panel3.Controls.Add(radioButton_text);
			panel3.Controls.Add(radioButton_xml);
			panel3.Location = new System.Drawing.Point(538, 62);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(246, 28);
			panel3.TabIndex = 34;
			radioButton_binary.AutoSize = true;
			radioButton_binary.Location = new System.Drawing.Point(3, 3);
			radioButton_binary.Name = "radioButton_binary";
			radioButton_binary.Size = new System.Drawing.Size(62, 21);
			radioButton_binary.TabIndex = 29;
			radioButton_binary.Text = "Binary";
			radioButton_binary.UseVisualStyleBackColor = true;
			radioButton_json.AutoSize = true;
			radioButton_json.Location = new System.Drawing.Point(175, 3);
			radioButton_json.Name = "radioButton_json";
			radioButton_json.Size = new System.Drawing.Size(52, 21);
			radioButton_json.TabIndex = 28;
			radioButton_json.Text = "Json";
			radioButton_json.UseVisualStyleBackColor = true;
			radioButton_text.AutoSize = true;
			radioButton_text.Checked = true;
			radioButton_text.Location = new System.Drawing.Point(65, 3);
			radioButton_text.Name = "radioButton_text";
			radioButton_text.Size = new System.Drawing.Size(50, 21);
			radioButton_text.TabIndex = 26;
			radioButton_text.TabStop = true;
			radioButton_text.Text = "Text";
			radioButton_text.UseVisualStyleBackColor = true;
			radioButton_xml.AutoSize = true;
			radioButton_xml.Location = new System.Drawing.Point(121, 3);
			radioButton_xml.Name = "radioButton_xml";
			radioButton_xml.Size = new System.Drawing.Size(48, 21);
			radioButton_xml.TabIndex = 27;
			radioButton_xml.Text = "Xml";
			radioButton_xml.UseVisualStyleBackColor = true;
			radioButton2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			radioButton2.AutoSize = true;
			radioButton2.Checked = true;
			radioButton2.Location = new System.Drawing.Point(458, 56);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(74, 21);
			radioButton2.TabIndex = 33;
			radioButton2.TabStop = true;
			radioButton2.Text = "追加显示";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			radioButton1.AutoSize = true;
			radioButton1.Location = new System.Drawing.Point(458, 74);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(74, 21);
			radioButton1.TabIndex = 32;
			radioButton1.Text = "覆盖显示";
			radioButton1.UseVisualStyleBackColor = true;
			textBox8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox8.Location = new System.Drawing.Point(72, 96);
			textBox8.Multiline = true;
			textBox8.Name = "textBox8";
			textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox8.Size = new System.Drawing.Size(783, 331);
			textBox8.TabIndex = 30;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(12, 98);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(64, 17);
			label12.TabIndex = 31;
			label12.Text = "Receive：";
			button4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button4.Location = new System.Drawing.Point(784, 61);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(71, 28);
			button4.TabIndex = 29;
			button4.Text = "清空";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button8.Location = new System.Drawing.Point(750, 17);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(104, 28);
			button8.TabIndex = 37;
			button8.Text = "取消订阅";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			button7.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button7.Location = new System.Drawing.Point(646, 17);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(98, 28);
			button7.TabIndex = 36;
			button7.Text = "订阅";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			checkBox_long_message_hide.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			checkBox_long_message_hide.AutoSize = true;
			checkBox_long_message_hide.Checked = true;
			checkBox_long_message_hide.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox_long_message_hide.Location = new System.Drawing.Point(756, 433);
			checkBox_long_message_hide.Name = "checkBox_long_message_hide";
			checkBox_long_message_hide.Size = new System.Drawing.Size(99, 21);
			checkBox_long_message_hide.TabIndex = 38;
			checkBox_long_message_hide.Text = "超长消息简略";
			checkBox_long_message_hide.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(867, 456);
			base.Controls.Add(checkBox_long_message_hide);
			base.Controls.Add(button8);
			base.Controls.Add(button7);
			base.Controls.Add(label10);
			base.Controls.Add(panel3);
			base.Controls.Add(radioButton2);
			base.Controls.Add(radioButton1);
			base.Controls.Add(textBox8);
			base.Controls.Add(label12);
			base.Controls.Add(button4);
			base.Controls.Add(textBox5);
			base.Controls.Add(label7);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "FormMqttSubscribe";
			Text = "FormMqttSubscribe";
			base.Load += new System.EventHandler(FormMqttSubscribe_Load);
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
