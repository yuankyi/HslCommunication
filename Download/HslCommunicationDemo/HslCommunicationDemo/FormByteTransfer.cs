using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunicationDemo.DemoControl;
using HslControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormByteTransfer : HslFormContent
	{
		private IContainer components = null;

		private Panel panel2;

		private Button button1;

		private Label label8;

		private Label label6;

		private Label label3;

		private RadioButton radioButton_utf32;

		private RadioButton radioButton_utf8;

		private RadioButton radioButton_unicode;

		private RadioButton radioButton_ascii;

		private RadioButton radioButton9;

		private RadioButton radioButton8;

		private RadioButton radioButton7;

		private RadioButton radioButton6;

		private RadioButton radioButton5;

		private RadioButton radioButton4;

		private RadioButton radioButton3;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private Label label1;

		private TextBox textBox2;

		private TextBox textBox1;

		private Label label7;

		private Button button2;

		private RadioButton radioButton_ansi;

		private UserControlHead userControlHead1;

		private RadioButton radioButton15;

		private Label label5;

		private HslPanelText hslPanelText1;

		private TextBox textBox_datetime;

		private Label label2;

		private Button button_open_file;

		private Button button4;

		private Button button5;

		private RadioButton radioButton_gb2312;

		private RadioButton radioButton_unicode_big;

		private RadioButton radioButton_base64;

		private Button button_url_decode;

		private Button button_url_encode;

		private Button button_save_file;

		public FormByteTransfer()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			byte[] array = null;
			RadioButton radioButton = null;
			try
			{
				if (radioButton1.Checked)
				{
					array = new byte[1]
					{
						byte.Parse(textBox1.Text)
					};
					radioButton = radioButton1;
				}
				else if (radioButton2.Checked)
				{
					array = BitConverter.GetBytes(short.Parse(textBox1.Text));
					radioButton = radioButton2;
				}
				else if (radioButton3.Checked)
				{
					array = BitConverter.GetBytes(ushort.Parse(textBox1.Text));
					radioButton = radioButton3;
				}
				else if (radioButton4.Checked)
				{
					array = BitConverter.GetBytes(int.Parse(textBox1.Text));
					radioButton = radioButton4;
				}
				else if (radioButton5.Checked)
				{
					array = BitConverter.GetBytes(uint.Parse(textBox1.Text));
					radioButton = radioButton5;
				}
				else if (radioButton6.Checked)
				{
					array = BitConverter.GetBytes(long.Parse(textBox1.Text));
					radioButton = radioButton6;
				}
				else if (radioButton7.Checked)
				{
					array = BitConverter.GetBytes(ulong.Parse(textBox1.Text));
					radioButton = radioButton7;
				}
				else if (radioButton8.Checked)
				{
					array = BitConverter.GetBytes(float.Parse(textBox1.Text));
					radioButton = radioButton8;
				}
				else if (radioButton9.Checked)
				{
					array = BitConverter.GetBytes(double.Parse(textBox1.Text));
					radioButton = radioButton9;
				}
				else if (radioButton_ascii.Checked)
				{
					array = Encoding.ASCII.GetBytes(textBox1.Text);
					radioButton = radioButton_ascii;
				}
				else if (radioButton_unicode.Checked)
				{
					array = Encoding.Unicode.GetBytes(textBox1.Text);
					radioButton = radioButton_unicode;
				}
				else if (radioButton_utf8.Checked)
				{
					array = Encoding.UTF8.GetBytes(textBox1.Text);
					radioButton = radioButton_utf8;
				}
				else if (radioButton_utf32.Checked)
				{
					array = Encoding.UTF32.GetBytes(textBox1.Text);
					radioButton = radioButton_utf32;
				}
				else if (radioButton_ansi.Checked)
				{
					array = Encoding.Default.GetBytes(textBox1.Text);
					radioButton = radioButton_ansi;
				}
				else
				{
					if (radioButton15.Checked)
					{
						DateTime dateTime = DateTime.Parse(textBox_datetime.Text);
						double value = double.Parse(textBox1.Text);
						radioButton = radioButton15;
						textBox2.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " [" + textBox1.Text + "] [" + radioButton.Text.PadRight(7, ' ') + "] Time " + dateTime.AddSeconds(value).ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
						return;
					}
					if (radioButton_gb2312.Checked)
					{
						array = Encoding.GetEncoding("gb2312").GetBytes(textBox1.Text);
						radioButton = radioButton_gb2312;
					}
					else if (radioButton_unicode_big.Checked)
					{
						array = Encoding.BigEndianUnicode.GetBytes(textBox1.Text);
						radioButton = radioButton_unicode_big;
					}
					else if (radioButton_base64.Checked)
					{
						array = Convert.FromBase64String(textBox1.Text);
						radioButton = radioButton_base64;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			textBox2.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " [" + textBox1.Text + "] [" + radioButton.Text.PadRight(7, ' ') + "] Length[" + array.Length.ToString() + "] " + SoftBasic.ByteToHexString(array, ' ') + Environment.NewLine);
		}

		private void FormByteTransfer_Load(object sender, EventArgs e)
		{
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language != 1)
			{
				Text = "ByteTransform Tools";
				label7.Text = "Input value:";
				label3.Text = "Integer:";
				label6.Text = "Float:";
				label8.Text = "String:";
				label1.Text = "Output:(Hex)";
				button1.Text = "Conver-byte[]";
				button2.Text = "Re-conversion";
			}
		}

		private void FormByteTransfer_Shown(object sender, EventArgs e)
		{
			textBox1.Focus();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string text = string.Empty;
			RadioButton radioButton = null;
			try
			{
				if (radioButton1.Checked)
				{
					text = SoftBasic.HexStringToBytes(textBox1.Text)[0].ToString();
					radioButton = radioButton1;
				}
				else if (radioButton2.Checked)
				{
					text = BitConverter.ToInt16(SoftBasic.HexStringToBytes(textBox1.Text), 0).ToString();
					radioButton = radioButton2;
				}
				else if (radioButton3.Checked)
				{
					text = BitConverter.ToUInt16(SoftBasic.HexStringToBytes(textBox1.Text), 0).ToString();
					radioButton = radioButton3;
				}
				else if (radioButton4.Checked)
				{
					text = BitConverter.ToInt32(SoftBasic.HexStringToBytes(textBox1.Text), 0).ToString();
					radioButton = radioButton4;
				}
				else if (radioButton5.Checked)
				{
					text = BitConverter.ToUInt32(SoftBasic.HexStringToBytes(textBox1.Text), 0).ToString();
					radioButton = radioButton5;
				}
				else if (radioButton6.Checked)
				{
					text = BitConverter.ToInt64(SoftBasic.HexStringToBytes(textBox1.Text), 0).ToString();
					radioButton = radioButton6;
				}
				else if (radioButton7.Checked)
				{
					text = BitConverter.ToUInt64(SoftBasic.HexStringToBytes(textBox1.Text), 0).ToString();
					radioButton = radioButton7;
				}
				else if (radioButton8.Checked)
				{
					text = BitConverter.ToSingle(SoftBasic.HexStringToBytes(textBox1.Text), 0).ToString();
					radioButton = radioButton8;
				}
				else if (radioButton9.Checked)
				{
					text = BitConverter.ToDouble(SoftBasic.HexStringToBytes(textBox1.Text), 0).ToString();
					radioButton = radioButton9;
				}
				else if (radioButton_ascii.Checked)
				{
					text = Encoding.ASCII.GetString(SoftBasic.HexStringToBytes(textBox1.Text)).ToString();
					radioButton = radioButton_ascii;
				}
				else if (radioButton_unicode.Checked)
				{
					text = Encoding.Unicode.GetString(SoftBasic.HexStringToBytes(textBox1.Text)).ToString();
					radioButton = radioButton_unicode;
				}
				else if (radioButton_utf8.Checked)
				{
					text = Encoding.UTF8.GetString(SoftBasic.HexStringToBytes(textBox1.Text)).ToString();
					radioButton = radioButton_utf8;
				}
				else if (radioButton_utf32.Checked)
				{
					text = Encoding.UTF32.GetString(SoftBasic.HexStringToBytes(textBox1.Text)).ToString();
					radioButton = radioButton_utf32;
				}
				else if (radioButton_ansi.Checked)
				{
					text = Encoding.Default.GetString(SoftBasic.HexStringToBytes(textBox1.Text)).ToString();
					radioButton = radioButton_utf32;
				}
				else if (radioButton_gb2312.Checked)
				{
					text = Encoding.GetEncoding("gb2312").GetString(SoftBasic.HexStringToBytes(textBox1.Text)).ToString();
					radioButton = radioButton_gb2312;
				}
				else if (radioButton_unicode_big.Checked)
				{
					text = Encoding.BigEndianUnicode.GetString(SoftBasic.HexStringToBytes(textBox1.Text)).ToString();
					radioButton = radioButton_unicode_big;
				}
				else if (radioButton_base64.Checked)
				{
					text = Convert.ToBase64String(SoftBasic.HexStringToBytes(textBox1.Text));
					radioButton = radioButton_base64;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			textBox2.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " [" + textBox1.Text + "] [" + radioButton.Text.PadRight(7, ' ') + "]  " + text + Environment.NewLine);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(textBox1.Text))
				{
					OpenFileDialog openFileDialog = new OpenFileDialog();
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						if (radioButton_base64.Checked)
						{
							textBox2.Text = Convert.ToBase64String(File.ReadAllBytes(openFileDialog.FileName));
						}
						else
						{
							textBox2.Text = SoftBasic.ByteToHexString(File.ReadAllBytes(openFileDialog.FileName), ' ', 32);
						}
					}
				}
				else if (radioButton_base64.Checked)
				{
					textBox2.Text = Convert.ToBase64String(File.ReadAllBytes(textBox1.Text));
				}
				else
				{
					textBox2.Text = SoftBasic.ByteToHexString(File.ReadAllBytes(textBox1.Text), ' ', 32);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Failed:" + ex.Message);
			}
		}

		private void button_save_file_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllBytes(saveFileDialog.FileName, textBox2.Text.ToHexBytes());
			}
		}

		private void textBox2_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Link;
				textBox1.Cursor = Cursors.Arrow;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void textBox2_DragDrop(object sender, DragEventArgs e)
		{
			string text = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
			textBox1.Text = text;
			button3_Click(sender, e);
			textBox1.Cursor = Cursors.IBeam;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			try
			{
				DateTime now = DateTime.Now;
				textBox2.Text = SoftBasic.CalculateFileMD5(textBox1.Text);
				textBox2.AppendText(Environment.NewLine + "Total Coust:" + (DateTime.Now - now).TotalSeconds.ToString("F2") + " s");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Failed:" + ex.Message);
			}
		}

		private string PrintBase64(byte[] content)
		{
			int num = 0;
			string text = Convert.ToBase64String(content);
			StringBuilder stringBuilder = new StringBuilder();
			while (num < text.Length)
			{
				int num2 = Math.Min(text.Length - num, 120);
				stringBuilder.Append(text.Substring(num, num2));
				num += num2;
				if (num < text.Length)
				{
					stringBuilder.Append(Environment.NewLine);
				}
			}
			return stringBuilder.ToString();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			try
			{
				if (!string.IsNullOrEmpty(textBox1.Text))
				{
					if (File.Exists(textBox1.Text))
					{
						byte[] content = File.ReadAllBytes(textBox1.Text);
						textBox2.Text = PrintBase64(content);
					}
				}
				else if (Clipboard.ContainsImage())
				{
					using (MemoryStream memoryStream = new MemoryStream())
					{
						Clipboard.GetImage().Save(memoryStream, ImageFormat.Png);
						byte[] content2 = memoryStream.ToArray();
						textBox2.Text = PrintBase64(content2);
					}
				}
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage(ex);
			}
		}

		private void button_url_encode_Click(object sender, EventArgs e)
		{
			Encoding e2 = Encoding.UTF8;
			if (radioButton_ascii.Checked)
			{
				e2 = Encoding.ASCII;
			}
			else if (radioButton_unicode.Checked)
			{
				e2 = Encoding.Unicode;
			}
			else if (radioButton_utf8.Checked)
			{
				e2 = Encoding.UTF8;
			}
			else if (radioButton_utf32.Checked)
			{
				e2 = Encoding.UTF32;
			}
			else if (radioButton_ansi.Checked)
			{
				e2 = Encoding.Default;
			}
			else if (radioButton_gb2312.Checked)
			{
				e2 = Encoding.GetEncoding("gb2312");
			}
			else if (radioButton_unicode_big.Checked)
			{
				e2 = Encoding.BigEndianUnicode;
			}
			textBox2.Text = SoftBasic.UrlEncode(textBox1.Text, e2);
		}

		private void button_url_decode_Click(object sender, EventArgs e)
		{
			Encoding encoding = Encoding.UTF8;
			if (radioButton_ascii.Checked)
			{
				encoding = Encoding.ASCII;
			}
			else if (radioButton_unicode.Checked)
			{
				encoding = Encoding.Unicode;
			}
			else if (radioButton_utf8.Checked)
			{
				encoding = Encoding.UTF8;
			}
			else if (radioButton_utf32.Checked)
			{
				encoding = Encoding.UTF32;
			}
			else if (radioButton_ansi.Checked)
			{
				encoding = Encoding.Default;
			}
			else if (radioButton_gb2312.Checked)
			{
				encoding = Encoding.GetEncoding("gb2312");
			}
			else if (radioButton_unicode_big.Checked)
			{
				encoding = Encoding.BigEndianUnicode;
			}
			textBox2.Text = SoftBasic.UrlDecode(textBox1.Text, encoding);
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
			button_url_decode = new System.Windows.Forms.Button();
			button_url_encode = new System.Windows.Forms.Button();
			radioButton_base64 = new System.Windows.Forms.RadioButton();
			radioButton_unicode_big = new System.Windows.Forms.RadioButton();
			radioButton_gb2312 = new System.Windows.Forms.RadioButton();
			button5 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button_open_file = new System.Windows.Forms.Button();
			radioButton15 = new System.Windows.Forms.RadioButton();
			label5 = new System.Windows.Forms.Label();
			hslPanelText1 = new HslControls.HslPanelText();
			textBox_datetime = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			radioButton_ansi = new System.Windows.Forms.RadioButton();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			label8 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			radioButton_utf32 = new System.Windows.Forms.RadioButton();
			radioButton_utf8 = new System.Windows.Forms.RadioButton();
			radioButton_unicode = new System.Windows.Forms.RadioButton();
			radioButton_ascii = new System.Windows.Forms.RadioButton();
			radioButton9 = new System.Windows.Forms.RadioButton();
			radioButton8 = new System.Windows.Forms.RadioButton();
			radioButton7 = new System.Windows.Forms.RadioButton();
			radioButton6 = new System.Windows.Forms.RadioButton();
			radioButton5 = new System.Windows.Forms.RadioButton();
			radioButton4 = new System.Windows.Forms.RadioButton();
			radioButton3 = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton1 = new System.Windows.Forms.RadioButton();
			label1 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			textBox1 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			button_save_file = new System.Windows.Forms.Button();
			panel2.SuspendLayout();
			hslPanelText1.SuspendLayout();
			SuspendLayout();
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(button_save_file);
			panel2.Controls.Add(button_url_decode);
			panel2.Controls.Add(button_url_encode);
			panel2.Controls.Add(radioButton_base64);
			panel2.Controls.Add(radioButton_unicode_big);
			panel2.Controls.Add(radioButton_gb2312);
			panel2.Controls.Add(button5);
			panel2.Controls.Add(button4);
			panel2.Controls.Add(button_open_file);
			panel2.Controls.Add(radioButton15);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(hslPanelText1);
			panel2.Controls.Add(radioButton_ansi);
			panel2.Controls.Add(button2);
			panel2.Controls.Add(button1);
			panel2.Controls.Add(label8);
			panel2.Controls.Add(label6);
			panel2.Controls.Add(label3);
			panel2.Controls.Add(radioButton_utf32);
			panel2.Controls.Add(radioButton_utf8);
			panel2.Controls.Add(radioButton_unicode);
			panel2.Controls.Add(radioButton_ascii);
			panel2.Controls.Add(radioButton9);
			panel2.Controls.Add(radioButton8);
			panel2.Controls.Add(radioButton7);
			panel2.Controls.Add(radioButton6);
			panel2.Controls.Add(radioButton5);
			panel2.Controls.Add(radioButton4);
			panel2.Controls.Add(radioButton3);
			panel2.Controls.Add(radioButton2);
			panel2.Controls.Add(radioButton1);
			panel2.Controls.Add(label1);
			panel2.Controls.Add(textBox2);
			panel2.Controls.Add(textBox1);
			panel2.Controls.Add(label7);
			panel2.Location = new System.Drawing.Point(3, 35);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 606);
			panel2.TabIndex = 33;
			button_url_decode.Location = new System.Drawing.Point(893, 146);
			button_url_decode.Name = "button_url_decode";
			button_url_decode.Size = new System.Drawing.Size(96, 26);
			button_url_decode.TabIndex = 44;
			button_url_decode.Text = "Url Decode";
			button_url_decode.UseVisualStyleBackColor = true;
			button_url_decode.Click += new System.EventHandler(button_url_decode_Click);
			button_url_encode.Location = new System.Drawing.Point(791, 146);
			button_url_encode.Name = "button_url_encode";
			button_url_encode.Size = new System.Drawing.Size(96, 26);
			button_url_encode.TabIndex = 43;
			button_url_encode.Text = "Url Encode";
			button_url_encode.UseVisualStyleBackColor = true;
			button_url_encode.Click += new System.EventHandler(button_url_encode_Click);
			radioButton_base64.AutoSize = true;
			radioButton_base64.Location = new System.Drawing.Point(613, 91);
			radioButton_base64.Name = "radioButton_base64";
			radioButton_base64.Size = new System.Drawing.Size(68, 21);
			radioButton_base64.TabIndex = 42;
			radioButton_base64.Text = "Base64";
			radioButton_base64.UseVisualStyleBackColor = true;
			radioButton_unicode_big.AutoSize = true;
			radioButton_unicode_big.Location = new System.Drawing.Point(311, 91);
			radioButton_unicode_big.Name = "radioButton_unicode_big";
			radioButton_unicode_big.Size = new System.Drawing.Size(96, 21);
			radioButton_unicode_big.TabIndex = 41;
			radioButton_unicode_big.Text = "unicode-big";
			radioButton_unicode_big.UseVisualStyleBackColor = true;
			radioButton_gb2312.AutoSize = true;
			radioButton_gb2312.Location = new System.Drawing.Point(536, 91);
			radioButton_gb2312.Name = "radioButton_gb2312";
			radioButton_gb2312.Size = new System.Drawing.Size(71, 21);
			radioButton_gb2312.TabIndex = 40;
			radioButton_gb2312.Text = "GB2312";
			radioButton_gb2312.UseVisualStyleBackColor = true;
			button5.Location = new System.Drawing.Point(675, 146);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(110, 26);
			button5.TabIndex = 39;
			button5.Text = "图片base64";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			button4.Location = new System.Drawing.Point(559, 146);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(110, 26);
			button4.TabIndex = 38;
			button4.Text = "计算MD5";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button_open_file.Location = new System.Drawing.Point(334, 146);
			button_open_file.Name = "button_open_file";
			button_open_file.Size = new System.Drawing.Size(110, 26);
			button_open_file.TabIndex = 37;
			button_open_file.Text = "打开文件";
			button_open_file.UseVisualStyleBackColor = true;
			button_open_file.Click += new System.EventHandler(button3_Click);
			radioButton15.AutoSize = true;
			radioButton15.Location = new System.Drawing.Point(102, 119);
			radioButton15.Name = "radioButton15";
			radioButton15.Size = new System.Drawing.Size(77, 21);
			radioButton15.TabIndex = 36;
			radioButton15.Text = "datetime";
			radioButton15.UseVisualStyleBackColor = true;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(8, 121);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(68, 17);
			label5.TabIndex = 35;
			label5.Text = "时间数据：";
			hslPanelText1.Controls.Add(textBox_datetime);
			hslPanelText1.Controls.Add(label2);
			hslPanelText1.Location = new System.Drawing.Point(716, 39);
			hslPanelText1.Name = "hslPanelText1";
			hslPanelText1.Size = new System.Drawing.Size(272, 101);
			hslPanelText1.TabIndex = 34;
			hslPanelText1.Text = "时间戳转换";
			hslPanelText1.TextOffect = 20;
			textBox_datetime.Location = new System.Drawing.Point(89, 24);
			textBox_datetime.Name = "textBox_datetime";
			textBox_datetime.Size = new System.Drawing.Size(144, 23);
			textBox_datetime.TabIndex = 1;
			textBox_datetime.Text = "1970-1-1 08:00:00";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(15, 27);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(68, 17);
			label2.TabIndex = 0;
			label2.Text = "起始时间：";
			radioButton_ansi.AutoSize = true;
			radioButton_ansi.Location = new System.Drawing.Point(166, 91);
			radioButton_ansi.Name = "radioButton_ansi";
			radioButton_ansi.Size = new System.Drawing.Size(49, 21);
			radioButton_ansi.TabIndex = 33;
			radioButton_ansi.Text = "ansi";
			radioButton_ansi.UseVisualStyleBackColor = true;
			button2.Location = new System.Drawing.Point(218, 146);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(110, 26);
			button2.TabIndex = 32;
			button2.Text = "反向转换";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(102, 146);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(110, 26);
			button1.TabIndex = 31;
			button1.Text = "转换byte[]";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(8, 93);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(68, 17);
			label8.TabIndex = 30;
			label8.Text = "字符数据：";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(8, 66);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(68, 17);
			label6.TabIndex = 29;
			label6.Text = "浮点数据：";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(8, 39);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(68, 17);
			label3.TabIndex = 28;
			label3.Text = "整型数据：";
			radioButton_utf32.AutoSize = true;
			radioButton_utf32.Location = new System.Drawing.Point(470, 91);
			radioButton_utf32.Name = "radioButton_utf32";
			radioButton_utf32.Size = new System.Drawing.Size(60, 21);
			radioButton_utf32.TabIndex = 27;
			radioButton_utf32.Text = "utf-32";
			radioButton_utf32.UseVisualStyleBackColor = true;
			radioButton_utf8.AutoSize = true;
			radioButton_utf8.Location = new System.Drawing.Point(411, 91);
			radioButton_utf8.Name = "radioButton_utf8";
			radioButton_utf8.Size = new System.Drawing.Size(53, 21);
			radioButton_utf8.TabIndex = 26;
			radioButton_utf8.Text = "utf-8";
			radioButton_utf8.UseVisualStyleBackColor = true;
			radioButton_unicode.AutoSize = true;
			radioButton_unicode.Location = new System.Drawing.Point(233, 91);
			radioButton_unicode.Name = "radioButton_unicode";
			radioButton_unicode.Size = new System.Drawing.Size(72, 21);
			radioButton_unicode.TabIndex = 25;
			radioButton_unicode.Text = "unicode";
			radioButton_unicode.UseVisualStyleBackColor = true;
			radioButton_ascii.AutoSize = true;
			radioButton_ascii.Location = new System.Drawing.Point(102, 91);
			radioButton_ascii.Name = "radioButton_ascii";
			radioButton_ascii.Size = new System.Drawing.Size(51, 21);
			radioButton_ascii.TabIndex = 24;
			radioButton_ascii.Text = "ascii";
			radioButton_ascii.UseVisualStyleBackColor = true;
			radioButton9.AutoSize = true;
			radioButton9.Location = new System.Drawing.Point(166, 64);
			radioButton9.Name = "radioButton9";
			radioButton9.Size = new System.Drawing.Size(67, 21);
			radioButton9.TabIndex = 23;
			radioButton9.Text = "double";
			radioButton9.UseVisualStyleBackColor = true;
			radioButton8.AutoSize = true;
			radioButton8.Location = new System.Drawing.Point(102, 64);
			radioButton8.Name = "radioButton8";
			radioButton8.Size = new System.Drawing.Size(52, 21);
			radioButton8.TabIndex = 22;
			radioButton8.Text = "float";
			radioButton8.UseVisualStyleBackColor = true;
			radioButton7.AutoSize = true;
			radioButton7.Location = new System.Drawing.Point(474, 37);
			radioButton7.Name = "radioButton7";
			radioButton7.Size = new System.Drawing.Size(59, 21);
			radioButton7.TabIndex = 21;
			radioButton7.Text = "ulong";
			radioButton7.UseVisualStyleBackColor = true;
			radioButton6.AutoSize = true;
			radioButton6.Location = new System.Drawing.Point(416, 37);
			radioButton6.Name = "radioButton6";
			radioButton6.Size = new System.Drawing.Size(52, 21);
			radioButton6.TabIndex = 20;
			radioButton6.Text = "long";
			radioButton6.UseVisualStyleBackColor = true;
			radioButton5.AutoSize = true;
			radioButton5.Location = new System.Drawing.Point(363, 37);
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new System.Drawing.Size(47, 21);
			radioButton5.TabIndex = 19;
			radioButton5.Text = "uint";
			radioButton5.UseVisualStyleBackColor = true;
			radioButton4.AutoSize = true;
			radioButton4.Checked = true;
			radioButton4.Location = new System.Drawing.Point(306, 37);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new System.Drawing.Size(40, 21);
			radioButton4.TabIndex = 18;
			radioButton4.TabStop = true;
			radioButton4.Text = "int";
			radioButton4.UseVisualStyleBackColor = true;
			radioButton3.AutoSize = true;
			radioButton3.Location = new System.Drawing.Point(233, 37);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(63, 21);
			radioButton3.TabIndex = 17;
			radioButton3.Text = "ushort";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton2.AutoSize = true;
			radioButton2.Location = new System.Drawing.Point(166, 37);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(56, 21);
			radioButton2.TabIndex = 16;
			radioButton2.Text = "short";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton1.AutoSize = true;
			radioButton1.Location = new System.Drawing.Point(102, 37);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(51, 21);
			radioButton1.TabIndex = 15;
			radioButton1.Text = "byte";
			radioButton1.UseVisualStyleBackColor = true;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 182);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(74, 17);
			label1.TabIndex = 14;
			label1.Text = "输出：(Hex)";
			textBox2.AllowDrop = true;
			textBox2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox2.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox2.Location = new System.Drawing.Point(102, 178);
			textBox2.Multiline = true;
			textBox2.Name = "textBox2";
			textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox2.Size = new System.Drawing.Size(890, 423);
			textBox2.TabIndex = 8;
			textBox2.DragDrop += new System.Windows.Forms.DragEventHandler(textBox2_DragDrop);
			textBox2.DragEnter += new System.Windows.Forms.DragEventHandler(textBox2_DragEnter);
			textBox1.Location = new System.Drawing.Point(102, 8);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(886, 23);
			textBox1.TabIndex = 9;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(8, 11);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(92, 17);
			label7.TabIndex = 7;
			label7.Text = "等待转换的值：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/7703805.htmln";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Byte";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 34;
			button_save_file.Location = new System.Drawing.Point(450, 146);
			button_save_file.Name = "button_save_file";
			button_save_file.Size = new System.Drawing.Size(103, 26);
			button_save_file.TabIndex = 45;
			button_save_file.Text = "保存文件";
			button_save_file.UseVisualStyleBackColor = true;
			button_save_file.Click += new System.EventHandler(button_save_file_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormByteTransfer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "字节转换工具";
			base.Load += new System.EventHandler(FormByteTransfer_Load);
			base.Shown += new System.EventHandler(FormByteTransfer_Shown);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			hslPanelText1.ResumeLayout(false);
			hslPanelText1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
