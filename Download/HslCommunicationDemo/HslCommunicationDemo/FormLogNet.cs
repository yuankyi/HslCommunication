using HslCommunication.BasicFramework;
using HslCommunication.LogNet;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormLogNet : HslFormContent
	{
		private ILogNet logNet;

		private int threadCount = 3;

		private IContainer components = null;

		private Panel panel1;

		private Button button2;

		private Button button1;

		private Label label4;

		private TextBox textBox2;

		private Label label3;

		private ComboBox comboBox1;

		private TextBox textBox1;

		private Label label1;

		private Panel panel2;

		private Button button4;

		private Button button3;

		private Label label5;

		private TextBox textBox3;

		private Button button7;

		private Button button6;

		private Button button5;

		private ComboBox comboBox2;

		private Label label6;

		private Label label8;

		private Label label7;

		private Button button8;

		private CheckBox checkBox1;

		private UserControlHead userControlHead1;

		private Button button9;

		private Button button_hour_offset;

		private Label label2;

		private TextBox textBox_hour_offset;

		public FormLogNet()
		{
			InitializeComponent();
		}

		private void FormLogNet_Load(object sender, EventArgs e)
		{
			logNet = new LogNetSingle("log.txt");
			comboBox1.DataSource = SoftBasic.GetEnumValues<HslMessageDegree>();
			comboBox1.SelectedItem = HslMessageDegree.DEBUG;
			comboBox2.DataSource = SoftBasic.GetEnumValues<HslMessageDegree>();
			comboBox2.SelectedItem = HslMessageDegree.DEBUG;
			comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
			logNet.FiltrateKeyword("123");
			logNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		}

		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Exception ex = e.ExceptionObject as Exception;
			if (ex != null)
			{
				ILogNet obj = logNet;
				if (obj != null)
				{
					obj.WriteException("UnhandledException", ex);
				}
			}
		}

		private void LogNet_BeforeSaveToFile(object sender, HslEventArgs e)
		{
			e.HslMessage.Cancel = checkBox1.Checked;
		}

		private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			HslMessageDegree messageDegree = (HslMessageDegree)comboBox2.SelectedItem;
			logNet.SetMessageDegree(messageDegree);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			HslMessageDegree degree = (HslMessageDegree)comboBox1.SelectedItem;
			logNet.RecordMessage(degree, textBox1.Text, textBox2.Text);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			logNet.WriteNewLine();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			logNet.WriteDescrition("这是一条注释");
		}

		private void button7_Click(object sender, EventArgs e)
		{
			try
			{
				int num = 0;
				int num2 = 100 / num;
			}
			catch (Exception ex)
			{
				logNet.WriteException(textBox1.Text, ex);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			threadCount = 3;
			for (int i = 0; i < threadCount; i++)
			{
				Thread thread = new Thread(ThreadLogTest);
				thread.IsBackground = true;
				thread.Start();
			}
			button2.Enabled = false;
		}

		private void ThreadLogTest()
		{
			DateTime now = DateTime.Now;
			for (int i = 0; i < 330000; i++)
			{
				logNet.WriteInfo("key", "这是一条测试日志");
			}
			TimeSpan ts = DateTime.Now - now;
			if (Interlocked.Decrement(ref threadCount) == 0)
			{
				Invoke((Action)delegate
				{
					MessageBox.Show("完成！耗时：" + ts.TotalMilliseconds.ToString("F3") + " 毫秒");
					button2.Enabled = true;
				});
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (File.Exists("log.txt"))
			{
				using (StreamReader streamReader = new StreamReader("log.txt", Encoding.UTF8))
				{
					textBox3.Text = streamReader.ReadToEnd();
				}
			}
			else
			{
				MessageBox.Show("没有文件！");
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			File.WriteAllBytes("log.txt", new byte[0]);
		}

		private void button8_Click(object sender, EventArgs e)
		{
			using (FormLogNetView formLogNetView = new FormLogNetView())
			{
				formLogNetView.ShowDialog();
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			FormSiemensFW formSiemensFW = null;
			formSiemensFW.AcceptButton = button1;
		}

		private void button_hour_offset_Click(object sender, EventArgs e)
		{
			logNet.HourDeviation = int.Parse(textBox_hour_offset.Text);
			MessageBox.Show("Finish");
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
			button9 = new System.Windows.Forms.Button();
			checkBox1 = new System.Windows.Forms.CheckBox();
			label8 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			comboBox2 = new System.Windows.Forms.ComboBox();
			label6 = new System.Windows.Forms.Label();
			button7 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			comboBox1 = new System.Windows.Forms.ComboBox();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			button8 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			label5 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			label2 = new System.Windows.Forms.Label();
			textBox_hour_offset = new System.Windows.Forms.TextBox();
			button_hour_offset = new System.Windows.Forms.Button();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(button_hour_offset);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(textBox_hour_offset);
			panel1.Controls.Add(button9);
			panel1.Controls.Add(checkBox1);
			panel1.Controls.Add(label8);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(comboBox2);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(button7);
			panel1.Controls.Add(button6);
			panel1.Controls.Add(button5);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 206);
			panel1.TabIndex = 25;
			button9.Location = new System.Drawing.Point(612, 164);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(132, 28);
			button9.TabIndex = 18;
			button9.Text = "强制引发异常";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(251, 39);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(171, 21);
			checkBox1.TabIndex = 17;
			checkBox1.Text = "是否取消存储，打勾则取消";
			checkBox1.UseVisualStyleBackColor = true;
			label8.AutoSize = true;
			label8.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			label8.Location = new System.Drawing.Point(443, 43);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(221, 17);
			label8.TabIndex = 16;
			label8.Text = "当前已经设置过滤关键字123的日志存储";
			label7.AutoSize = true;
			label7.ForeColor = System.Drawing.Color.Blue;
			label7.Location = new System.Drawing.Point(679, 43);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(164, 17);
			label7.TabIndex = 15;
			label7.Text = "文件路径：当前目录下log.txt";
			comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox2.FormattingEnabled = true;
			comboBox2.Location = new System.Drawing.Point(312, 5);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new System.Drawing.Size(121, 25);
			comboBox2.TabIndex = 14;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(231, 8);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(68, 17);
			label6.TabIndex = 13;
			label6.Text = "存储等级：";
			button7.Location = new System.Drawing.Point(372, 164);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(90, 28);
			button7.TabIndex = 12;
			button7.Text = "写异常";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			button6.Location = new System.Drawing.Point(276, 164);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(90, 28);
			button6.TabIndex = 11;
			button6.Text = "写注释";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button5.Location = new System.Drawing.Point(180, 164);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(90, 28);
			button5.TabIndex = 10;
			button5.Text = "写换行";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			button2.Location = new System.Drawing.Point(818, 164);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(170, 28);
			button2.TabIndex = 9;
			button2.Text = "100万条日志测试";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(84, 164);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(90, 28);
			button1.TabIndex = 8;
			button1.Text = "写日志";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(3, 71);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(68, 17);
			label4.TabIndex = 7;
			label4.Text = "日志信息：";
			textBox2.Location = new System.Drawing.Point(84, 71);
			textBox2.Multiline = true;
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(904, 87);
			textBox2.TabIndex = 6;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(3, 40);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 5;
			label3.Text = "关键字：";
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(84, 5);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(121, 25);
			comboBox1.TabIndex = 4;
			textBox1.Location = new System.Drawing.Point(84, 37);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(141, 23);
			textBox1.TabIndex = 3;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(3, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(68, 17);
			label1.TabIndex = 2;
			label1.Text = "日志等级：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(button8);
			panel2.Controls.Add(button4);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(textBox3);
			panel2.Location = new System.Drawing.Point(3, 244);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 398);
			panel2.TabIndex = 26;
			button8.Location = new System.Drawing.Point(276, 7);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(90, 28);
			button8.TabIndex = 12;
			button8.Text = "日志分析器";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			button4.Location = new System.Drawing.Point(180, 7);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(90, 28);
			button4.TabIndex = 11;
			button4.Text = "清空文件";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button3.Location = new System.Drawing.Point(84, 7);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(90, 28);
			button3.TabIndex = 10;
			button3.Text = "加载文件";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(3, 47);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(68, 17);
			label5.TabIndex = 9;
			label5.Text = "日志文件：";
			textBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox3.Location = new System.Drawing.Point(84, 44);
			textBox3.Multiline = true;
			textBox3.Name = "textBox3";
			textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox3.Size = new System.Drawing.Size(904, 344);
			textBox3.TabIndex = 8;
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7691693.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 27;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(452, 8);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(68, 17);
			label2.TabIndex = 20;
			label2.Text = "小时偏移：";
			textBox_hour_offset.Location = new System.Drawing.Point(525, 6);
			textBox_hour_offset.Name = "textBox_hour_offset";
			textBox_hour_offset.Size = new System.Drawing.Size(68, 23);
			textBox_hour_offset.TabIndex = 19;
			textBox_hour_offset.Text = "0";
			button_hour_offset.Location = new System.Drawing.Point(601, 4);
			button_hour_offset.Name = "button_hour_offset";
			button_hour_offset.Size = new System.Drawing.Size(90, 28);
			button_hour_offset.TabIndex = 21;
			button_hour_offset.Text = "设置";
			button_hour_offset.UseVisualStyleBackColor = true;
			button_hour_offset.Click += new System.EventHandler(button_hour_offset_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormLogNet";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormLogNet";
			base.Load += new System.EventHandler(FormLogNet_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
