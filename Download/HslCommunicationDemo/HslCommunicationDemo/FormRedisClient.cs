using HslCommunication;
using HslCommunication.Enthernet.Redis;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormRedisClient : HslFormContent
	{
		private RedisClient redisClient = new RedisClient("");

		private int status = 1;

		private Random random = new Random();

		private IContainer components = null;

		private Panel panel1;

		private TextBox textBox3;

		private Label label6;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private Label label1;

		private Panel panel2;

		private TextBox textBox7;

		private Label label11;

		private TextBox textBox6;

		private Label label10;

		private Button button_set_key;

		private TextBox textBox4;

		private Label label9;

		private TextBox textBox_write_key;

		private Label label7;

		private Button button5;

		private Button button6;

		private TextBox textBox8;

		private Label label8;

		private TextBox textBox9;

		private Label label12;

		private Button button_get_key;

		private TextBox textBox_get_result;

		private Label label13;

		private TextBox textBox_get_key;

		private Label label14;

		private Button button7;

		private Button button_redis_execute_cmd;

		private Button button10;

		private Button button9;

		private Button button11;

		private Button button12;

		private UserControlHead userControlHead1;

		private Button button_redis_EXISTS;

		private GroupBox groupBox1;

		private Button button_redis_PERSIST;

		private TextBox textBox_redis_cmd;

		private Label label2;

		private Button button_redis_INCR;

		private Button button_redis_DECR;

		private Button button_redis_STRLEN;

		public FormRedisClient()
		{
			InitializeComponent();
		}

		private void FormClient_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			button2.Enabled = false;
			Language(Program.Language);
		}

		private void Language(int language)
		{
			if (language == 1)
			{
				Text = "Redis网络客户端";
				label1.Text = "Ip地址：";
				label3.Text = "端口号：";
				button1.Text = "连接";
				button2.Text = "断开连接";
				label6.Text = "密码：";
				button5.Text = "启动短连接";
				button6.Text = "压力测试";
				label7.Text = "指令头：";
				label8.Text = "耗时";
				label9.Text = "数据：";
				button_set_key.Text = "写入";
				label10.Text = "次数：";
				label11.Text = "耗时：";
				button_get_key.Text = "读取";
				label12.Text = "接收：";
			}
			else
			{
				Text = "Redis Client Test";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label6.Text = "Password:";
				button5.Text = "Start a short connection";
				button6.Text = "Pressure test";
				label7.Text = "Command:";
				label8.Text = "Take:";
				label9.Text = "Data:";
				label10.Text = "Times:";
				label11.Text = "Take:";
				label12.Text = "Receive:";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			redisClient = new RedisClient(textBox3.Text);
			redisClient.IpAddress = textBox1.Text;
			redisClient.Port = int.Parse(textBox2.Text);
			redisClient.LogNet = base.LogNet;
			OperateResult operateResult = redisClient.ConnectServer();
			if (operateResult.IsSuccess)
			{
				button1.Enabled = false;
				button2.Enabled = true;
				panel2.Enabled = true;
				button5.Enabled = false;
				MessageBox.Show(StringResources.Language.ConnectServerSuccess);
			}
			else
			{
				MessageBox.Show(StringResources.Language.ConnectedFailed + operateResult.ToMessageShowString());
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			button5.Enabled = true;
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;
			redisClient.ConnectClose();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (status == 1)
			{
				redisClient.IpAddress = textBox1.Text;
				redisClient.Port = int.Parse(textBox2.Text);
				button1.Enabled = false;
				button2.Enabled = false;
				panel2.Enabled = true;
				status = 2;
				button5.Text = ((Program.Language == 1) ? "重新选择连接" : "Choose again");
			}
			else
			{
				status = 1;
				button1.Enabled = true;
				panel2.Enabled = false;
				button5.Text = ((Program.Language == 1) ? "启动短连接" : "Start a short connection");
			}
		}

		private void button_set_key_Click(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;
			int num = int.Parse(textBox6.Text);
			for (int i = 0; i < num; i++)
			{
				OperateResult operateResult = redisClient.WriteKey(textBox_write_key.Text, textBox4.Text);
				if (operateResult.IsSuccess)
				{
					textBox7.Text = (DateTime.Now - now).TotalMilliseconds.ToString("F2");
					MessageBox.Show("success");
				}
				else
				{
					textBox7.Text = (DateTime.Now - now).TotalMilliseconds.ToString("F2");
					MessageBox.Show((Program.Language == 1) ? "写入失败：" : ("Write Failed:" + operateResult.ToMessageShowString()));
				}
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			textBox8.Clear();
		}

		private void button4_Click_1(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;
			int num = int.Parse(textBox9.Text);
			for (int i = 0; i < num; i++)
			{
				OperateResult<string> operateResult = redisClient.ReadKey(textBox_get_key.Text);
				if (operateResult.IsSuccess)
				{
					textBox_get_result.Text = operateResult.Content;
				}
				else
				{
					textBox_get_result.Text = ((Program.Language == 1) ? ("读取失败：" + operateResult.Message) : ("Read Failed:" + operateResult.Message));
				}
			}
			textBox8.Text = (DateTime.Now - now).TotalMilliseconds.ToString("F2");
		}

		private void button_execute_commands_Click(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;
			int num = int.Parse(textBox9.Text);
			for (int i = 0; i < num; i++)
			{
				OperateResult<string> operateResult = redisClient.ReadCustomer(textBox_redis_cmd.Text);
				if (operateResult.IsSuccess)
				{
					textBox_get_result.Text = operateResult.Content;
				}
				else
				{
					textBox_get_result.Text = ((Program.Language == 1) ? ("读取失败：" + operateResult.Message) : ("Read Failed:" + operateResult.Message));
				}
			}
			textBox8.Text = (DateTime.Now - now).TotalMilliseconds.ToString("F2");
		}

		private void button9_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = redisClient.ListLeftPush("B", random.Next(1000).ToString());
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("成功");
			}
			else
			{
				MessageBox.Show(operateResult.Message);
			}
		}

		private void button10_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = redisClient.ListTrim("B", 0L, 2L);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("成功");
			}
			else
			{
				MessageBox.Show(operateResult.Message);
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			OperateResult<int> listLength = redisClient.GetListLength("B");
			if (listLength.IsSuccess)
			{
				MessageBox.Show("成功：" + listLength.Content.ToString());
			}
			else
			{
				MessageBox.Show(listLength.Message);
			}
		}

		private void button12_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = redisClient.Publish(textBox_write_key.Text, textBox4.Text);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("success");
			}
			else
			{
				MessageBox.Show((Program.Language == 1) ? "写入失败：" : ("Write Failed:" + operateResult.ToMessageShowString()));
			}
		}

		private void button_redis_EXISTS_Click(object sender, EventArgs e)
		{
			OperateResult<int> operateResult = redisClient.ExistsKey(textBox_write_key.Text);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show((operateResult.Content == 1) ? "Exists!" : "None");
			}
			else
			{
				MessageBox.Show("request failed: " + operateResult.Message);
			}
		}

		private void button_redis_PERSIST_Click(object sender, EventArgs e)
		{
			OperateResult<int> operateResult = redisClient.PersistKey(textBox_write_key.Text);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show((operateResult.Content == 1) ? "Persist success!" : "Persist failed");
			}
			else
			{
				MessageBox.Show("request failed: " + operateResult.Message);
			}
		}

		private void button_redis_INCR_Click(object sender, EventArgs e)
		{
			OperateResult<long> operateResult = redisClient.IncrementKey(textBox_get_key.Text);
			if (operateResult.IsSuccess)
			{
				textBox_get_result.Text = operateResult.Content.ToString();
			}
			else
			{
				MessageBox.Show("request failed: " + operateResult.Message);
			}
		}

		private void button_redis_DECR_Click(object sender, EventArgs e)
		{
			OperateResult<long> operateResult = redisClient.DecrementKey(textBox_get_key.Text);
			if (operateResult.IsSuccess)
			{
				textBox_get_result.Text = operateResult.Content.ToString();
			}
			else
			{
				MessageBox.Show("request failed: " + operateResult.Message);
			}
		}

		private void button_redis_STRLEN_Click(object sender, EventArgs e)
		{
			OperateResult<int> operateResult = redisClient.ReadKeyLength(textBox_get_key.Text);
			if (operateResult.IsSuccess)
			{
				textBox_get_result.Text = operateResult.Content.ToString();
			}
			else
			{
				MessageBox.Show("request failed: " + operateResult.Message);
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
			panel1 = new System.Windows.Forms.Panel();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			textBox_redis_cmd = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			button_redis_PERSIST = new System.Windows.Forms.Button();
			button_redis_EXISTS = new System.Windows.Forms.Button();
			button12 = new System.Windows.Forms.Button();
			button11 = new System.Windows.Forms.Button();
			button10 = new System.Windows.Forms.Button();
			button9 = new System.Windows.Forms.Button();
			button_redis_execute_cmd = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			textBox8 = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			textBox9 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			button_get_key = new System.Windows.Forms.Button();
			textBox_get_result = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			textBox_get_key = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			textBox7 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			button_set_key = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			textBox_write_key = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			button_redis_INCR = new System.Windows.Forms.Button();
			button_redis_DECR = new System.Windows.Forms.Button();
			button_redis_STRLEN = new System.Windows.Forms.Button();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(button6);
			panel1.Controls.Add(button5);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 67);
			panel1.TabIndex = 7;
			button6.Location = new System.Drawing.Point(820, 32);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(168, 28);
			button6.TabIndex = 9;
			button6.Text = "压力测试";
			button6.UseVisualStyleBackColor = true;
			button5.Location = new System.Drawing.Point(820, 2);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(168, 28);
			button5.TabIndex = 8;
			button5.Text = "启动短连接";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			textBox3.Location = new System.Drawing.Point(81, 34);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(384, 23);
			textBox3.TabIndex = 7;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(8, 37);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(36, 17);
			label6.TabIndex = 6;
			label6.Text = "pwd:";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(653, 2);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "disconnect";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(546, 2);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "connect";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(418, 5);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(91, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "6379";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(364, 8);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(36, 17);
			label3.TabIndex = 2;
			label3.Text = "port:";
			textBox1.Location = new System.Drawing.Point(81, 5);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(257, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(55, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip addr:";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(button_redis_STRLEN);
			panel2.Controls.Add(button_redis_DECR);
			panel2.Controls.Add(button_redis_INCR);
			panel2.Controls.Add(textBox_redis_cmd);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(groupBox1);
			panel2.Controls.Add(button_redis_PERSIST);
			panel2.Controls.Add(button_redis_EXISTS);
			panel2.Controls.Add(button12);
			panel2.Controls.Add(button11);
			panel2.Controls.Add(button10);
			panel2.Controls.Add(button9);
			panel2.Controls.Add(button_redis_execute_cmd);
			panel2.Controls.Add(button7);
			panel2.Controls.Add(textBox8);
			panel2.Controls.Add(label8);
			panel2.Controls.Add(textBox9);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(button_get_key);
			panel2.Controls.Add(textBox_get_result);
			panel2.Controls.Add(label13);
			panel2.Controls.Add(textBox_get_key);
			panel2.Controls.Add(label14);
			panel2.Controls.Add(textBox7);
			panel2.Controls.Add(label11);
			panel2.Controls.Add(textBox6);
			panel2.Controls.Add(label10);
			panel2.Controls.Add(button_set_key);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label9);
			panel2.Controls.Add(textBox_write_key);
			panel2.Controls.Add(label7);
			panel2.Location = new System.Drawing.Point(3, 106);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 536);
			panel2.TabIndex = 13;
			textBox_redis_cmd.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_redis_cmd.Location = new System.Drawing.Point(62, 506);
			textBox_redis_cmd.Name = "textBox_redis_cmd";
			textBox_redis_cmd.Size = new System.Drawing.Size(365, 23);
			textBox_redis_cmd.TabIndex = 36;
			textBox_redis_cmd.Text = "GET A";
			label2.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(7, 510);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 17);
			label2.TabIndex = 35;
			label2.Text = "Cmds:";
			groupBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox1.Location = new System.Drawing.Point(10, 211);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(978, 5);
			groupBox1.TabIndex = 34;
			groupBox1.TabStop = false;
			button_redis_PERSIST.Location = new System.Drawing.Point(425, 5);
			button_redis_PERSIST.Name = "button_redis_PERSIST";
			button_redis_PERSIST.Size = new System.Drawing.Size(91, 28);
			button_redis_PERSIST.TabIndex = 33;
			button_redis_PERSIST.Text = "PERSIST";
			button_redis_PERSIST.UseVisualStyleBackColor = true;
			button_redis_PERSIST.Click += new System.EventHandler(button_redis_PERSIST_Click);
			button_redis_EXISTS.Location = new System.Drawing.Point(328, 5);
			button_redis_EXISTS.Name = "button_redis_EXISTS";
			button_redis_EXISTS.Size = new System.Drawing.Size(91, 28);
			button_redis_EXISTS.TabIndex = 32;
			button_redis_EXISTS.Text = "EXISTS";
			button_redis_EXISTS.UseVisualStyleBackColor = true;
			button_redis_EXISTS.Click += new System.EventHandler(button_redis_EXISTS_Click);
			button12.Location = new System.Drawing.Point(328, 180);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(91, 28);
			button12.TabIndex = 31;
			button12.Text = "publish key";
			button12.UseVisualStyleBackColor = true;
			button12.Click += new System.EventHandler(button12_Click);
			button11.Location = new System.Drawing.Point(825, 180);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(91, 28);
			button11.TabIndex = 30;
			button11.Text = "list length";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			button10.Location = new System.Drawing.Point(728, 180);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(91, 28);
			button10.TabIndex = 29;
			button10.Text = "list shrink";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(button10_Click);
			button9.Location = new System.Drawing.Point(631, 180);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(91, 28);
			button9.TabIndex = 28;
			button9.Text = "list add";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			button_redis_execute_cmd.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			button_redis_execute_cmd.Location = new System.Drawing.Point(433, 504);
			button_redis_execute_cmd.Name = "button_redis_execute_cmd";
			button_redis_execute_cmd.Size = new System.Drawing.Size(110, 28);
			button_redis_execute_cmd.TabIndex = 27;
			button_redis_execute_cmd.Text = "execute cmd";
			button_redis_execute_cmd.UseVisualStyleBackColor = true;
			button_redis_execute_cmd.Click += new System.EventHandler(button_execute_commands_Click);
			button7.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			button7.Location = new System.Drawing.Point(896, 504);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(91, 28);
			button7.TabIndex = 26;
			button7.Text = "clear";
			button7.UseVisualStyleBackColor = true;
			textBox8.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			textBox8.Location = new System.Drawing.Point(768, 507);
			textBox8.Name = "textBox8";
			textBox8.ReadOnly = true;
			textBox8.Size = new System.Drawing.Size(88, 23);
			textBox8.TabIndex = 25;
			textBox8.Text = "0";
			label8.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(718, 511);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(47, 17);
			label8.TabIndex = 24;
			label8.Text = "spend:";
			textBox9.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			textBox9.Location = new System.Drawing.Point(632, 507);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(80, 23);
			textBox9.TabIndex = 23;
			textBox9.Text = "1";
			label12.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(582, 510);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(51, 17);
			label12.TabIndex = 22;
			label12.Text = "times：";
			button_get_key.Location = new System.Drawing.Point(270, 222);
			button_get_key.Name = "button_get_key";
			button_get_key.Size = new System.Drawing.Size(91, 28);
			button_get_key.TabIndex = 21;
			button_get_key.Text = "Get Key";
			button_get_key.UseVisualStyleBackColor = true;
			button_get_key.Click += new System.EventHandler(button4_Click_1);
			textBox_get_result.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_get_result.Location = new System.Drawing.Point(62, 257);
			textBox_get_result.Multiline = true;
			textBox_get_result.Name = "textBox_get_result";
			textBox_get_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_get_result.Size = new System.Drawing.Size(922, 244);
			textBox_get_result.TabIndex = 18;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(8, 259);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(41, 17);
			label13.TabIndex = 20;
			label13.Text = "text：";
			textBox_get_key.Location = new System.Drawing.Point(62, 224);
			textBox_get_key.Name = "textBox_get_key";
			textBox_get_key.Size = new System.Drawing.Size(202, 23);
			textBox_get_key.TabIndex = 19;
			textBox_get_key.Text = "A";
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(8, 228);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(40, 17);
			label14.TabIndex = 17;
			label14.Text = "key：";
			textBox7.Location = new System.Drawing.Point(544, 183);
			textBox7.Name = "textBox7";
			textBox7.ReadOnly = true;
			textBox7.Size = new System.Drawing.Size(66, 23);
			textBox7.TabIndex = 16;
			textBox7.Text = "0";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(494, 186);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 15;
			label11.Text = "耗时：";
			textBox6.Location = new System.Drawing.Point(220, 183);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(76, 23);
			textBox6.TabIndex = 14;
			textBox6.Text = "1";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(173, 186);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(51, 17);
			label10.TabIndex = 13;
			label10.Text = "times：";
			button_set_key.Location = new System.Drawing.Point(62, 180);
			button_set_key.Name = "button_set_key";
			button_set_key.Size = new System.Drawing.Size(91, 28);
			button_set_key.TabIndex = 12;
			button_set_key.Text = "Set key";
			button_set_key.UseVisualStyleBackColor = true;
			button_set_key.Click += new System.EventHandler(button_set_key_Click);
			textBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox4.Location = new System.Drawing.Point(62, 36);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox4.Size = new System.Drawing.Size(922, 138);
			textBox4.TabIndex = 8;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(8, 39);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(41, 17);
			label9.TabIndex = 11;
			label9.Text = "text：";
			textBox_write_key.Location = new System.Drawing.Point(62, 7);
			textBox_write_key.Name = "textBox_write_key";
			textBox_write_key.Size = new System.Drawing.Size(260, 23);
			textBox_write_key.TabIndex = 9;
			textBox_write_key.Text = "A";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(8, 11);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(40, 17);
			label7.TabIndex = 7;
			label7.Text = "key：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/7697782.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Redis";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 14;
			button_redis_INCR.Location = new System.Drawing.Point(367, 222);
			button_redis_INCR.Name = "button_redis_INCR";
			button_redis_INCR.Size = new System.Drawing.Size(60, 28);
			button_redis_INCR.TabIndex = 37;
			button_redis_INCR.Text = "INCR";
			button_redis_INCR.UseVisualStyleBackColor = true;
			button_redis_INCR.Click += new System.EventHandler(button_redis_INCR_Click);
			button_redis_DECR.Location = new System.Drawing.Point(433, 222);
			button_redis_DECR.Name = "button_redis_DECR";
			button_redis_DECR.Size = new System.Drawing.Size(66, 28);
			button_redis_DECR.TabIndex = 38;
			button_redis_DECR.Text = "DECR";
			button_redis_DECR.UseVisualStyleBackColor = true;
			button_redis_DECR.Click += new System.EventHandler(button_redis_DECR_Click);
			button_redis_STRLEN.Location = new System.Drawing.Point(505, 222);
			button_redis_STRLEN.Name = "button_redis_STRLEN";
			button_redis_STRLEN.Size = new System.Drawing.Size(66, 28);
			button_redis_STRLEN.TabIndex = 39;
			button_redis_STRLEN.Text = "STRLEN";
			button_redis_STRLEN.UseVisualStyleBackColor = true;
			button_redis_STRLEN.Click += new System.EventHandler(button_redis_STRLEN_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormRedisClient";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Redis Client Test";
			base.Load += new System.EventHandler(FormClient_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
