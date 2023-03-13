using HslCommunication;
using HslCommunication.Core.Security;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormRSADebug : HslFormContent
	{
		private IContainer components = null;

		private Panel panel2;

		private Button button_jiami;

		private Label label3;

		private RadioButton radioButton1;

		private Label label1;

		private TextBox textBox_jiami_result;

		private TextBox textBox_jiami_input;

		private Label label7;

		private Button button_jiemi;

		private UserControlHead userControlHead1;

		private Panel panel3;

		private Label label8;

		private RadioButton radioButton3;

		private RadioButton radioButton4;

		private Panel panel1;

		private RadioButton radioButton2;

		private Label label6;

		private TextBox textBox_jiemi_result;

		private TextBox textBox_jiemi_input;

		private Label label5;

		private TextBox textBox_pri_key;

		private Label label4;

		private TextBox textBox_pub_key;

		private Label label2;

		private Button button1;

		private Label label9;

		private Button button2;

		private Button button3;

		private ComboBox comboBox1;

		public FormRSADebug()
		{
			InitializeComponent();
		}

		private void FormByteTransfer_Load(object sender, EventArgs e)
		{
			Language(Program.Language);
			RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
			textBox_pri_key.Text = Convert.ToBase64String(rsa.GetPEMPrivateKey());
			textBox_pub_key.Text = Convert.ToBase64String(rsa.GetPEMPublicKey());
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < 117; i++)
			{
				stringBuilder.Append("1");
			}
			textBox_jiami_input.Text = stringBuilder.ToString();
			comboBox1.DataSource = new object[5]
			{
				new SHA1CryptoServiceProvider(),
				new SHA256CryptoServiceProvider(),
				new SHA384CryptoServiceProvider(),
				new SHA512CryptoServiceProvider(),
				new MD5CryptoServiceProvider()
			};
		}

		private void Language(int language)
		{
			if (language != 1)
			{
				Text = "RSA encryption and decryption tool";
				label7.Text = "Original data: (Drag the file to the box below in non-admin mode)";
				label2.Text = "Public key";
				label4.Text = "Private Key";
				button_jiami.Text = "Encrypt";
				button_jiemi.Text = "Decrypt";
				label1.Text = "Output(HEX)";
				label6.Text = "Output(HEX)";
				label5.Text = "Encrypted data";
				label3.Text = "DataType:";
				label8.Text = "DataType:";
				button1.Text = "Result Save As";
			}
		}

		private void FormByteTransfer_Shown(object sender, EventArgs e)
		{
		}

		private void button3_Click(object sender, EventArgs e)
		{
		}

		private void textBox2_DragEnter(object sender, DragEventArgs e)
		{
		}

		private void textBox2_DragDrop(object sender, DragEventArgs e)
		{
		}

		private void textBox_jiemi_input_DragDrop(object sender, DragEventArgs e)
		{
			string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
			if (File.Exists(path))
			{
				textBox_jiemi_input.Text = File.ReadAllBytes(path).ToHexString(' ');
			}
			textBox_jiami_input.Cursor = Cursors.IBeam;
		}

		private void textBox_jiemi_input_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Link;
				textBox_jiami_input.Cursor = Cursors.Arrow;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void textBox_pri_key_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Link;
				textBox_pri_key.Cursor = Cursors.Arrow;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void textBox_pri_key_DragDrop(object sender, DragEventArgs e)
		{
			string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
			if (File.Exists(path))
			{
				textBox_pri_key.Text = File.ReadAllText(path, Encoding.UTF8);
			}
			textBox_pri_key.Cursor = Cursors.IBeam;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			RSACryptoServiceProvider rsa = RSAHelper.CreateRsaProviderFromPrivateKey(textBox_pri_key.Text);
			byte[] array = rsa.DecryptLargeData(textBox_jiemi_input.Text.ToHexBytes());
			if (radioButton3.Checked)
			{
				textBox_jiemi_result.Text = array.ToHexString(' ');
			}
			else
			{
				textBox_jiemi_result.Text = Encoding.UTF8.GetString(array);
			}
		}

		private void textBox_jiami_input_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Link;
				textBox_jiami_input.Cursor = Cursors.Arrow;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void textBox_jiami_input_DragDrop(object sender, DragEventArgs e)
		{
			string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
			if (File.Exists(path))
			{
				textBox_jiami_input.Text = File.ReadAllText(path, Encoding.UTF8);
			}
			textBox_jiami_input.Cursor = Cursors.IBeam;
		}

		private void textBox_pub_key_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Link;
				textBox_pub_key.Cursor = Cursors.Arrow;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void textBox_pub_key_DragDrop(object sender, DragEventArgs e)
		{
			string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
			if (File.Exists(path))
			{
				textBox_pub_key.Text = File.ReadAllText(path, Encoding.UTF8);
			}
			textBox_pub_key.Cursor = Cursors.IBeam;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			RSACryptoServiceProvider rsa = RSAHelper.CreateRsaProviderFromPublicKey(textBox_pub_key.Text);
			byte[] array = null;
			array = ((!radioButton1.Checked) ? rsa.EncryptLargeData(Encoding.UTF8.GetBytes(textBox_jiami_input.Text)) : rsa.EncryptLargeData(textBox_jiami_input.Text.ToHexBytes()));
			textBox_jiami_result.Text = array.ToHexString(' ');
			label9.Text = (array.Length.ToString() ?? "");
		}

		private object GetHalg()
		{
			return comboBox1.SelectedItem;
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			RSACryptoServiceProvider rSACryptoServiceProvider = RSAHelper.CreateRsaProviderFromPublicKey(textBox_pub_key.Text);
			byte[] array = null;
			array = ((!radioButton1.Checked) ? Encoding.UTF8.GetBytes(textBox_jiami_input.Text) : textBox_jiami_input.Text.ToHexBytes());
			if (rSACryptoServiceProvider.VerifyData(array, GetHalg(), textBox_jiami_result.Text.ToHexBytes()))
			{
				MessageBox.Show("Sign verify success!");
			}
			else
			{
				MessageBox.Show("Sign verify failed");
			}
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			RSACryptoServiceProvider rSACryptoServiceProvider = RSAHelper.CreateRsaProviderFromPrivateKey(textBox_pri_key.Text);
			byte[] array = null;
			array = ((!radioButton1.Checked) ? rSACryptoServiceProvider.SignData(Encoding.UTF8.GetBytes(textBox_jiami_input.Text), GetHalg()) : rSACryptoServiceProvider.SignData(textBox_jiami_input.Text.ToHexBytes(), GetHalg()));
			textBox_jiami_result.Text = array.ToHexString(' ');
			label9.Text = (array.Length.ToString() ?? "");
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllBytes(saveFileDialog.FileName, textBox_jiami_result.Text.ToHexBytes());
				MessageBox.Show("Save Success");
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
			panel2 = new System.Windows.Forms.Panel();
			comboBox1 = new System.Windows.Forms.ComboBox();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			label9 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			panel3 = new System.Windows.Forms.Panel();
			label8 = new System.Windows.Forms.Label();
			radioButton3 = new System.Windows.Forms.RadioButton();
			radioButton4 = new System.Windows.Forms.RadioButton();
			panel1 = new System.Windows.Forms.Panel();
			label3 = new System.Windows.Forms.Label();
			radioButton1 = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			label6 = new System.Windows.Forms.Label();
			textBox_jiemi_result = new System.Windows.Forms.TextBox();
			textBox_jiemi_input = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			textBox_pri_key = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox_pub_key = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			button_jiemi = new System.Windows.Forms.Button();
			button_jiami = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			textBox_jiami_result = new System.Windows.Forms.TextBox();
			textBox_jiami_input = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(comboBox1);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(button2);
			panel2.Controls.Add(label9);
			panel2.Controls.Add(button1);
			panel2.Controls.Add(panel3);
			panel2.Controls.Add(panel1);
			panel2.Controls.Add(label6);
			panel2.Controls.Add(textBox_jiemi_result);
			panel2.Controls.Add(textBox_jiemi_input);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(textBox_pri_key);
			panel2.Controls.Add(label4);
			panel2.Controls.Add(textBox_pub_key);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(button_jiemi);
			panel2.Controls.Add(button_jiami);
			panel2.Controls.Add(label1);
			panel2.Controls.Add(textBox_jiami_result);
			panel2.Controls.Add(textBox_jiami_input);
			panel2.Controls.Add(label7);
			panel2.Location = new System.Drawing.Point(5, 38);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(994, 601);
			panel2.TabIndex = 33;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(326, 340);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(395, 25);
			comboBox1.TabIndex = 54;
			button3.Location = new System.Drawing.Point(193, 339);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(129, 26);
			button3.TabIndex = 53;
			button3.Text = "签名(原始数据)";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click_1);
			button2.Location = new System.Drawing.Point(100, 339);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(87, 26);
			button2.TabIndex = 52;
			button2.Text = "验签";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click_1);
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(107, 372);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(34, 17);
			label9.TabIndex = 51;
			label9.Text = "Size:";
			button1.Location = new System.Drawing.Point(328, 370);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(142, 26);
			button1.TabIndex = 50;
			button1.Text = "加密结果另存为";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click_1);
			panel3.Controls.Add(label8);
			panel3.Controls.Add(radioButton3);
			panel3.Controls.Add(radioButton4);
			panel3.Location = new System.Drawing.Point(754, 368);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(232, 28);
			panel3.TabIndex = 49;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(4, 4);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(68, 17);
			label8.TabIndex = 28;
			label8.Text = "数据类型：";
			radioButton3.AutoSize = true;
			radioButton3.Location = new System.Drawing.Point(98, 2);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(50, 21);
			radioButton3.TabIndex = 15;
			radioButton3.Text = "HEX";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton4.AutoSize = true;
			radioButton4.Checked = true;
			radioButton4.Location = new System.Drawing.Point(162, 2);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new System.Drawing.Size(60, 21);
			radioButton4.TabIndex = 16;
			radioButton4.TabStop = true;
			radioButton4.Text = "String";
			radioButton4.UseVisualStyleBackColor = true;
			panel1.Controls.Add(label3);
			panel1.Controls.Add(radioButton1);
			panel1.Controls.Add(radioButton2);
			panel1.Location = new System.Drawing.Point(75, 159);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(232, 23);
			panel1.TabIndex = 48;
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
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(626, 375);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(74, 17);
			label6.TabIndex = 47;
			label6.Text = "输出：(Hex)";
			textBox_jiemi_result.AllowDrop = true;
			textBox_jiemi_result.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_jiemi_result.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox_jiemi_result.Location = new System.Drawing.Point(475, 399);
			textBox_jiemi_result.Multiline = true;
			textBox_jiemi_result.Name = "textBox_jiemi_result";
			textBox_jiemi_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_jiemi_result.Size = new System.Drawing.Size(514, 196);
			textBox_jiemi_result.TabIndex = 46;
			textBox_jiemi_input.AllowDrop = true;
			textBox_jiemi_input.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_jiemi_input.Location = new System.Drawing.Point(476, 38);
			textBox_jiemi_input.Multiline = true;
			textBox_jiemi_input.Name = "textBox_jiemi_input";
			textBox_jiemi_input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_jiemi_input.Size = new System.Drawing.Size(513, 119);
			textBox_jiemi_input.TabIndex = 45;
			textBox_jiemi_input.DragDrop += new System.Windows.Forms.DragEventHandler(textBox_jiemi_input_DragDrop);
			textBox_jiemi_input.DragEnter += new System.Windows.Forms.DragEventHandler(textBox_jiemi_input_DragEnter);
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(473, 12);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(100, 17);
			label5.TabIndex = 44;
			label5.Text = "加密数据(HEX)：";
			textBox_pri_key.AllowDrop = true;
			textBox_pri_key.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_pri_key.Location = new System.Drawing.Point(476, 184);
			textBox_pri_key.Multiline = true;
			textBox_pri_key.Name = "textBox_pri_key";
			textBox_pri_key.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_pri_key.Size = new System.Drawing.Size(513, 153);
			textBox_pri_key.TabIndex = 43;
			textBox_pri_key.DragDrop += new System.Windows.Forms.DragEventHandler(textBox_pri_key_DragDrop);
			textBox_pri_key.DragEnter += new System.Windows.Forms.DragEventHandler(textBox_pri_key_DragEnter);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(473, 164);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(44, 17);
			label4.TabIndex = 42;
			label4.Text = "私钥：";
			textBox_pub_key.AllowDrop = true;
			textBox_pub_key.Location = new System.Drawing.Point(10, 184);
			textBox_pub_key.Multiline = true;
			textBox_pub_key.Name = "textBox_pub_key";
			textBox_pub_key.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_pub_key.Size = new System.Drawing.Size(460, 153);
			textBox_pub_key.TabIndex = 41;
			textBox_pub_key.DragDrop += new System.Windows.Forms.DragEventHandler(textBox_pub_key_DragDrop);
			textBox_pub_key.DragEnter += new System.Windows.Forms.DragEventHandler(textBox_pub_key_DragEnter);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(8, 164);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 17);
			label2.TabIndex = 40;
			label2.Text = "公钥：";
			button_jiemi.Location = new System.Drawing.Point(475, 370);
			button_jiemi.Name = "button_jiemi";
			button_jiemi.Size = new System.Drawing.Size(110, 26);
			button_jiemi.TabIndex = 32;
			button_jiemi.Text = "解密";
			button_jiemi.UseVisualStyleBackColor = true;
			button_jiemi.Click += new System.EventHandler(button2_Click);
			button_jiami.Location = new System.Drawing.Point(11, 339);
			button_jiami.Name = "button_jiami";
			button_jiami.Size = new System.Drawing.Size(83, 26);
			button_jiami.TabIndex = 31;
			button_jiami.Text = "加密";
			button_jiami.UseVisualStyleBackColor = true;
			button_jiami.Click += new System.EventHandler(button1_Click);
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 372);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(74, 17);
			label1.TabIndex = 14;
			label1.Text = "输出：(Hex)";
			textBox_jiami_result.AllowDrop = true;
			textBox_jiami_result.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			textBox_jiami_result.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox_jiami_result.Location = new System.Drawing.Point(10, 399);
			textBox_jiami_result.Multiline = true;
			textBox_jiami_result.Name = "textBox_jiami_result";
			textBox_jiami_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_jiami_result.Size = new System.Drawing.Size(460, 196);
			textBox_jiami_result.TabIndex = 8;
			textBox_jiami_result.DragDrop += new System.Windows.Forms.DragEventHandler(textBox2_DragDrop);
			textBox_jiami_result.DragEnter += new System.Windows.Forms.DragEventHandler(textBox2_DragEnter);
			textBox_jiami_input.AllowDrop = true;
			textBox_jiami_input.Location = new System.Drawing.Point(11, 38);
			textBox_jiami_input.Multiline = true;
			textBox_jiami_input.Name = "textBox_jiami_input";
			textBox_jiami_input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_jiami_input.Size = new System.Drawing.Size(459, 119);
			textBox_jiami_input.TabIndex = 9;
			textBox_jiami_input.DragDrop += new System.Windows.Forms.DragEventHandler(textBox_jiami_input_DragDrop);
			textBox_jiami_input.DragEnter += new System.Windows.Forms.DragEventHandler(textBox_jiami_input_DragEnter);
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(3, 8);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(292, 17);
			label7.TabIndex = 7;
			label7.Text = "原始数据：(非管理员模式下文件拖到下面的框里即可)";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/15227913.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "RSA非对称加密解密";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 34;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormRSADebug";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "RSA加密解密工具";
			base.Load += new System.EventHandler(FormByteTransfer_Load);
			base.Shown += new System.EventHandler(FormByteTransfer_Shown);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
