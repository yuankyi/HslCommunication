using HslCommunication;
using HslCommunication.Core.Security;
using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormHslCertificate : HslFormContent
	{
		private IContainer components = null;

		private Panel panel1;

		private Button button_verify;

		private Button button_load;

		private Button button_create;

		private GroupBox groupBox2;

		private TextBox textBox_From;

		private Label label1;

		private GroupBox groupBox1;

		private Panel panel2;

		private Label label3;

		private RadioButton radioButton1;

		private RadioButton radioButton2;

		private TextBox textBox_pri_key;

		private Label label4;

		private TextBox textBox_pub_key;

		private Label label2;

		private TextBox textBox_NotBefore;

		private Label label6;

		private TextBox textBox_To;

		private Label label5;

		private TextBox textBox_Unique;

		private Label label9;

		private TextBox textBox_KeyWord;

		private Label label8;

		private TextBox textBox_NotAfter;

		private Label label7;

		private TextBox textBox_Descriptions;

		private Label label10;

		private UserControlHead userControlHead1;

		private Button button1;

		private TextBox textBox_hours;

		private Label label_hours;

		private TextBox textBox_createDate;

		private Label label11;

		public FormHslCertificate()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
			textBox_pri_key.Text = Convert.ToBase64String(rsa.GetPEMPrivateKey());
			textBox_pub_key.Text = Convert.ToBase64String(rsa.GetPEMPublicKey());
			textBox_NotBefore.Text = DateTime.Now.ToString("yyyy-MM-dd");
			textBox_NotAfter.Text = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
			textBox_createDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language != 1)
			{
				groupBox1.Text = "Public and private keys";
				label2.Text = "Public:";
				label3.Text = "Data formate:";
				label4.Text = "Private:";
				groupBox2.Text = "Certificate information";
				label1.Text = "Issuing:";
				label5.Text = "Holder:";
				label6.Text = "Not Before:";
				label7.Text = "Not After:";
				label11.Text = "Create Date:";
				label_hours.Text = "Hours: ";
				label8.Text = "Key Word:";
				label9.Text = "Unique:";
				label10.Text = "Extra info (key-value pairs + line breaks): For example: A: Hello";
				button_create.Text = "Create certificate";
				button_load.Text = "Load certificate";
				button_verify.Text = "Verify certificate";
			}
		}

		private void button_create_Click(object sender, EventArgs e)
		{
			byte[] pubKey = radioButton2.Checked ? Convert.FromBase64String(textBox_pub_key.Text) : textBox_pub_key.Text.ToHexBytes();
			byte[] priKey = radioButton2.Checked ? Convert.FromBase64String(textBox_pri_key.Text) : textBox_pri_key.Text.ToHexBytes();
			HslCertificate hslCertificate = new HslCertificate(pubKey, priKey);
			hslCertificate.From = textBox_From.Text;
			hslCertificate.To = textBox_To.Text;
			hslCertificate.NotBefore = DateTime.Parse(textBox_NotBefore.Text);
			hslCertificate.NotAfter = DateTime.Parse(textBox_NotAfter.Text);
			hslCertificate.CreateTime = DateTime.Parse(textBox_createDate.Text);
			hslCertificate.EffectiveHours = Convert.ToInt32(textBox_hours.Text);
			hslCertificate.KeyWord = textBox_KeyWord.Text;
			hslCertificate.UniqueID = textBox_Unique.Text;
			string[] lines = textBox_Descriptions.Lines;
			if (lines != null && lines.Length != 0)
			{
				hslCertificate.Descriptions = new Dictionary<string, string>();
				string[] lines2 = textBox_Descriptions.Lines;
				foreach (string text in lines2)
				{
					string[] array = text.Split(new char[3]
					{
						',',
						'/',
						':'
					}, StringSplitOptions.RemoveEmptyEntries);
					if (array.Length == 2)
					{
						hslCertificate.Descriptions.Add(array[0], array[1]);
					}
				}
			}
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.FileName = "hsl.cert";
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					File.WriteAllBytes(saveFileDialog.FileName, hslCertificate.GetSaveBytes());
				}
			}
			string text2 = "创建证书完成，是否复制证书到剪切板？";
			if (Program.Language == 2)
			{
				text2 = "After creating the certificate, do you want to copy the certificate to the clipboard?";
			}
			if (MessageBox.Show(text2, "Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Clipboard.SetText(Convert.ToBase64String(hslCertificate.GetSaveBytes()));
			}
		}

		private void button_load_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						byte[] hslCertificate = File.ReadAllBytes(openFileDialog.FileName);
						HslCertificate hslCertificate2 = HslCertificate.CreateFrom(hslCertificate);
						textBox_pub_key.Text = (radioButton2.Checked ? Convert.ToBase64String(hslCertificate2.PublicKey) : hslCertificate2.PublicKey.ToHexString(' '));
						textBox_From.Text = hslCertificate2.From;
						textBox_To.Text = hslCertificate2.To;
						textBox_NotBefore.Text = hslCertificate2.NotBefore.ToString("yyyy-MM-dd HH:mm:ss");
						textBox_NotAfter.Text = hslCertificate2.NotAfter.ToString("yyyy-MM-dd HH:mm:ss");
						textBox_KeyWord.Text = hslCertificate2.KeyWord;
						textBox_Unique.Text = hslCertificate2.UniqueID;
						textBox_createDate.Text = hslCertificate2.CreateTime.ToString("yyyy-MM-dd");
						textBox_hours.Text = hslCertificate2.EffectiveHours.ToString();
						Dictionary<string, string> descriptions = hslCertificate2.Descriptions;
						if (descriptions != null && descriptions.Count > 0)
						{
							StringBuilder stringBuilder = new StringBuilder();
							foreach (KeyValuePair<string, string> description in hslCertificate2.Descriptions)
							{
								stringBuilder.Append(description.Key);
								stringBuilder.Append(":");
								stringBuilder.Append(description.Value);
								stringBuilder.Append(Environment.NewLine);
							}
							textBox_Descriptions.Text = stringBuilder.ToString().TrimEnd('\r', '\n');
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Verify failed: " + ex.Message);
					}
				}
			}
		}

		private void button_verify_Click(object sender, EventArgs e)
		{
			byte[] publicKey = string.IsNullOrEmpty(textBox_pub_key.Text) ? null : (radioButton2.Checked ? Convert.FromBase64String(textBox_pub_key.Text) : textBox_pub_key.Text.ToHexBytes());
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						byte[] hslCertificate = File.ReadAllBytes(openFileDialog.FileName);
						if (HslCertificate.VerifyCer(publicKey, hslCertificate))
						{
							MessageBox.Show("Verify success");
						}
						else
						{
							MessageBox.Show("Verify failed");
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Verify failed: " + ex.Message);
					}
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			textBox_Unique.Text = Guid.NewGuid().ToString();
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
			panel1 = new System.Windows.Forms.Panel();
			button_verify = new System.Windows.Forms.Button();
			button_load = new System.Windows.Forms.Button();
			button_create = new System.Windows.Forms.Button();
			groupBox2 = new System.Windows.Forms.GroupBox();
			textBox_hours = new System.Windows.Forms.TextBox();
			label_hours = new System.Windows.Forms.Label();
			textBox_createDate = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			textBox_Descriptions = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			textBox_Unique = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			textBox_KeyWord = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			textBox_NotAfter = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			textBox_NotBefore = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			textBox_To = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			textBox_From = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			panel2 = new System.Windows.Forms.Panel();
			label3 = new System.Windows.Forms.Label();
			radioButton1 = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			textBox_pri_key = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox_pub_key = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(button_verify);
			panel1.Controls.Add(button_load);
			panel1.Controls.Add(button_create);
			panel1.Controls.Add(groupBox2);
			panel1.Controls.Add(groupBox1);
			panel1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel1.Location = new System.Drawing.Point(4, 34);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(996, 608);
			panel1.TabIndex = 37;
			button_verify.Location = new System.Drawing.Point(616, 565);
			button_verify.Name = "button_verify";
			button_verify.Size = new System.Drawing.Size(180, 39);
			button_verify.TabIndex = 4;
			button_verify.Text = "验证证书";
			button_verify.UseVisualStyleBackColor = true;
			button_verify.Click += new System.EventHandler(button_verify_Click);
			button_load.Location = new System.Drawing.Point(418, 565);
			button_load.Name = "button_load";
			button_load.Size = new System.Drawing.Size(180, 39);
			button_load.TabIndex = 3;
			button_load.Text = "加载证书";
			button_load.UseVisualStyleBackColor = true;
			button_load.Click += new System.EventHandler(button_load_Click);
			button_create.Location = new System.Drawing.Point(218, 565);
			button_create.Name = "button_create";
			button_create.Size = new System.Drawing.Size(180, 39);
			button_create.TabIndex = 2;
			button_create.Text = "创建证书";
			button_create.UseVisualStyleBackColor = true;
			button_create.Click += new System.EventHandler(button_create_Click);
			groupBox2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox2.Controls.Add(textBox_hours);
			groupBox2.Controls.Add(label_hours);
			groupBox2.Controls.Add(textBox_createDate);
			groupBox2.Controls.Add(label11);
			groupBox2.Controls.Add(button1);
			groupBox2.Controls.Add(textBox_Descriptions);
			groupBox2.Controls.Add(label10);
			groupBox2.Controls.Add(textBox_Unique);
			groupBox2.Controls.Add(label9);
			groupBox2.Controls.Add(textBox_KeyWord);
			groupBox2.Controls.Add(label8);
			groupBox2.Controls.Add(textBox_NotAfter);
			groupBox2.Controls.Add(label7);
			groupBox2.Controls.Add(textBox_NotBefore);
			groupBox2.Controls.Add(label6);
			groupBox2.Controls.Add(textBox_To);
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(textBox_From);
			groupBox2.Controls.Add(label1);
			groupBox2.Location = new System.Drawing.Point(3, 304);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(988, 258);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "证书信息";
			textBox_hours.Location = new System.Drawing.Point(316, 195);
			textBox_hours.Name = "textBox_hours";
			textBox_hours.Size = new System.Drawing.Size(115, 23);
			textBox_hours.TabIndex = 18;
			textBox_hours.Text = "0";
			label_hours.AutoSize = true;
			label_hours.Location = new System.Drawing.Point(223, 198);
			label_hours.Name = "label_hours";
			label_hours.Size = new System.Drawing.Size(59, 17);
			label_hours.TabIndex = 17;
			label_hours.Text = "有效小时:";
			textBox_createDate.Location = new System.Drawing.Point(93, 195);
			textBox_createDate.Name = "textBox_createDate";
			textBox_createDate.Size = new System.Drawing.Size(115, 23);
			textBox_createDate.TabIndex = 16;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(11, 198);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(59, 17);
			label11.TabIndex = 15;
			label11.Text = "发证日期:";
			button1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button1.Location = new System.Drawing.Point(913, 21);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(69, 25);
			button1.TabIndex = 14;
			button1.Text = "Random";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox_Descriptions.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_Descriptions.Location = new System.Drawing.Point(453, 90);
			textBox_Descriptions.Multiline = true;
			textBox_Descriptions.Name = "textBox_Descriptions";
			textBox_Descriptions.Size = new System.Drawing.Size(529, 158);
			textBox_Descriptions.TabIndex = 13;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(450, 64);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(227, 17);
			label10.TabIndex = 12;
			label10.Text = "额外信息(键值对+换行符): 例如： A:你好";
			textBox_Unique.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_Unique.Location = new System.Drawing.Point(532, 23);
			textBox_Unique.Name = "textBox_Unique";
			textBox_Unique.Size = new System.Drawing.Size(374, 23);
			textBox_Unique.TabIndex = 11;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(450, 26);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(59, 17);
			label9.TabIndex = 10;
			label9.Text = "唯一编号:";
			textBox_KeyWord.Location = new System.Drawing.Point(93, 225);
			textBox_KeyWord.Name = "textBox_KeyWord";
			textBox_KeyWord.Size = new System.Drawing.Size(338, 23);
			textBox_KeyWord.TabIndex = 9;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(11, 228);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(47, 17);
			label8.TabIndex = 8;
			label8.Text = "关键字:";
			textBox_NotAfter.Location = new System.Drawing.Point(93, 163);
			textBox_NotAfter.Name = "textBox_NotAfter";
			textBox_NotAfter.Size = new System.Drawing.Size(338, 23);
			textBox_NotAfter.TabIndex = 7;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(11, 166);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(59, 17);
			label7.TabIndex = 6;
			label7.Text = "结束日期:";
			textBox_NotBefore.Location = new System.Drawing.Point(93, 132);
			textBox_NotBefore.Name = "textBox_NotBefore";
			textBox_NotBefore.Size = new System.Drawing.Size(338, 23);
			textBox_NotBefore.TabIndex = 5;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(11, 135);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(59, 17);
			label6.TabIndex = 4;
			label6.Text = "开始日期:";
			textBox_To.Location = new System.Drawing.Point(93, 76);
			textBox_To.Multiline = true;
			textBox_To.Name = "textBox_To";
			textBox_To.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_To.Size = new System.Drawing.Size(338, 50);
			textBox_To.TabIndex = 3;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(11, 79);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(47, 17);
			label5.TabIndex = 2;
			label5.Text = "持有者:";
			textBox_From.Location = new System.Drawing.Point(93, 20);
			textBox_From.Multiline = true;
			textBox_From.Name = "textBox_From";
			textBox_From.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_From.Size = new System.Drawing.Size(338, 50);
			textBox_From.TabIndex = 1;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(11, 23);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(47, 17);
			label1.TabIndex = 0;
			label1.Text = "发证人:";
			groupBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox1.Controls.Add(panel2);
			groupBox1.Controls.Add(textBox_pri_key);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(textBox_pub_key);
			groupBox1.Controls.Add(label2);
			groupBox1.Location = new System.Drawing.Point(3, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(988, 303);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "公钥及私钥";
			panel2.Controls.Add(label3);
			panel2.Controls.Add(radioButton1);
			panel2.Controls.Add(radioButton2);
			panel2.Location = new System.Drawing.Point(71, 21);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(232, 23);
			panel2.TabIndex = 53;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(4, 4);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(68, 17);
			label3.TabIndex = 28;
			label3.Text = "数据类型：";
			radioButton1.AutoSize = true;
			radioButton1.Location = new System.Drawing.Point(98, 2);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(50, 21);
			radioButton1.TabIndex = 15;
			radioButton1.Text = "HEX";
			radioButton1.UseVisualStyleBackColor = true;
			radioButton2.AutoSize = true;
			radioButton2.Checked = true;
			radioButton2.Location = new System.Drawing.Point(162, 2);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(60, 21);
			radioButton2.TabIndex = 16;
			radioButton2.TabStop = true;
			radioButton2.Text = "String";
			radioButton2.UseVisualStyleBackColor = true;
			textBox_pri_key.AllowDrop = true;
			textBox_pri_key.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_pri_key.Location = new System.Drawing.Point(339, 46);
			textBox_pri_key.Multiline = true;
			textBox_pri_key.Name = "textBox_pri_key";
			textBox_pri_key.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_pri_key.Size = new System.Drawing.Size(646, 249);
			textBox_pri_key.TabIndex = 52;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(339, 25);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(44, 17);
			label4.TabIndex = 51;
			label4.Text = "私钥：";
			textBox_pub_key.AllowDrop = true;
			textBox_pub_key.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			textBox_pub_key.Location = new System.Drawing.Point(6, 46);
			textBox_pub_key.Multiline = true;
			textBox_pub_key.Name = "textBox_pub_key";
			textBox_pub_key.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_pub_key.Size = new System.Drawing.Size(327, 249);
			textBox_pub_key.TabIndex = 50;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(4, 26);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 17);
			label2.TabIndex = 49;
			label2.Text = "公钥：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/15227913.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "RSA 证书";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 38;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel1);
			base.Name = "FormHslCertificate";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Certificate Test";
			base.Load += new System.EventHandler(Form1_Load);
			panel1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
