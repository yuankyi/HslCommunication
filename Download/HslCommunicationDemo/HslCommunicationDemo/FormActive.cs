using HslCommunication;
using HslCommunication.Core.Security;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormActive : Form
	{
		private string activePath = string.Empty;

		private IContainer components = null;

		private Button button1;

		private Label label1;

		private TextBox textBox1;

		public FormActive()
		{
			InitializeComponent();
			activePath = Path.Combine(Application.StartupPath, "active.txt");
			base.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			bool flag = false;
			if ((textBox1.Text.Length >= 100) ? Authorization.SetHslCertificate(Convert.FromBase64String(textBox1.Text)).IsSuccess : Authorization.SetAuthorizationCode(textBox1.Text))
			{
				MessageBox.Show((Program.Language == 1) ? "激活成功!" : "Activation successful!");
				File.WriteAllText(activePath, string.Empty, Encoding.UTF8);
				FileInfo fileInfo = new FileInfo(activePath);
				string text = fileInfo.CreationTime.ToString("yyyy-MM-dd-mm-ss");
				AesCryptography aesCryptography = new AesCryptography(text + text);
				File.WriteAllBytes(activePath, aesCryptography.Encrypt(Encoding.UTF8.GetBytes(textBox1.Text)));
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				MessageBox.Show((Program.Language == 1) ? "激活失败！" : "Activation failed!");
			}
		}

		private void FormActive_Load(object sender, EventArgs e)
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
			label1 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			SuspendLayout();
			button1.Location = new System.Drawing.Point(164, 159);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(132, 37);
			button1.TabIndex = 0;
			button1.Text = "Active (激活)";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(42, 17);
			label1.TabIndex = 1;
			label1.Text = "Code:";
			textBox1.Location = new System.Drawing.Point(12, 28);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.PasswordChar = '*';
			textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox1.Size = new System.Drawing.Size(463, 121);
			textBox1.TabIndex = 2;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(487, 213);
			base.Controls.Add(textBox1);
			base.Controls.Add(label1);
			base.Controls.Add(button1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "FormActive";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormActive";
			base.Load += new System.EventHandler(FormActive_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
