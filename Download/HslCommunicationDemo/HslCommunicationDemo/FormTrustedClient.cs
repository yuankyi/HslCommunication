using HslCommunication.ModBus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormTrustedClient : Form
	{
		private ModbusTcpServer modbusTcpServer;

		private IContainer components = null;

		private Label label1;

		private TextBox textBox1;

		private Button button1;

		public FormTrustedClient(ModbusTcpServer modbusTcpServer)
		{
			InitializeComponent();
			this.modbusTcpServer = modbusTcpServer;
		}

		private void FormTrustedClient_Load(object sender, EventArgs e)
		{
			string[] trustedClients = modbusTcpServer.GetTrustedClients();
			for (int i = 0; i < trustedClients.Length; i++)
			{
				textBox1.AppendText(trustedClients[i] + Environment.NewLine);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string[] array = textBox1.Text.Split(new string[1]
			{
				Environment.NewLine
			}, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length != 0)
			{
				modbusTcpServer.SetTrustedIpAddress(new List<string>(array));
			}
			else
			{
				modbusTcpServer.SetTrustedIpAddress(null);
			}
			MessageBox.Show("成功");
			Close();
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
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(296, 17);
			label1.TabIndex = 0;
			label1.Text = "在下方输入受信任的Ip列表：（回车键区分不同的Ip）";
			textBox1.Location = new System.Drawing.Point(15, 29);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox1.Size = new System.Drawing.Size(396, 235);
			textBox1.TabIndex = 1;
			button1.Location = new System.Drawing.Point(159, 269);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(100, 30);
			button1.TabIndex = 2;
			button1.Text = "保存";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(432, 305);
			base.Controls.Add(button1);
			base.Controls.Add(textBox1);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormTrustedClient";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "获取或设置客户端的列表";
			base.Load += new System.EventHandler(FormTrustedClient_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
