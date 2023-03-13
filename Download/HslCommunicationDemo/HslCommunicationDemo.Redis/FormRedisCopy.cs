using HslCommunication;
using HslCommunication.Enthernet.Redis;
using HslCommunicationDemo.DemoControl;
using HslControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace HslCommunicationDemo.Redis
{
	public class FormRedisCopy : HslFormContent
	{
		private RedisClient client1 = null;

		private RedisClient client2 = null;

		private System.Threading.Timer timer = null;

		private IContainer components = null;

		private UserControlHead userControlHead1;

		private HslPanelTextBack hslPanelTextBack1;

		private TextBox textBox3;

		private Label label3;

		private TextBox textBox2;

		private Label label2;

		private TextBox textBox1;

		private Label label1;

		private HslPanelTextBack hslPanelTextBack2;

		private TextBox textBox4;

		private Label label4;

		private TextBox textBox5;

		private Label label5;

		private TextBox textBox6;

		private Label label6;

		private HslPanelHead hslPanelHead1;

		private HslPanelHead hslPanelHead2;

		private Button button3;

		private Button button2;

		private TextBox textBox8;

		private Label label8;

		private Button button5;

		private Label label7;

		private TextBox textBox7;

		private Button button4;

		private TextBox textBox9;

		private Label label9;

		private TextBox textBox10;

		private Button button7;

		private Button button6;

		private HslProgress hslProgress1;

		private Button button8;

		public FormRedisCopy()
		{
			InitializeComponent();
		}

		private void FormRedisCopy_Load(object sender, EventArgs e)
		{
			hslPanelHead1.Enabled = false;
			button3.Enabled = false;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			int result;
			int result2;
			int result3;
			int result4;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show(DemoUtils.PortInputWrong);
			}
			else if (!int.TryParse(textBox5.Text, out result2))
			{
				MessageBox.Show(DemoUtils.PortInputWrong);
			}
			else if (!int.TryParse(textBox8.Text, out result3))
			{
				MessageBox.Show("DB Block input wrong");
			}
			else if (!int.TryParse(textBox9.Text, out result4))
			{
				MessageBox.Show("DB Block input wrong");
			}
			else
			{
				RedisClient redisClient = client1;
				if (redisClient != null)
				{
					redisClient.ConnectClose();
				}
				RedisClient redisClient2 = client2;
				if (redisClient2 != null)
				{
					redisClient2.ConnectClose();
				}
				client1 = new RedisClient(textBox1.Text, result, textBox3.Text);
				client2 = new RedisClient(textBox6.Text, result2, textBox4.Text);
				OperateResult operateResult = client1.ConnectServer();
				if (!operateResult.IsSuccess)
				{
					MessageBox.Show(StringResources.Language.ConnectedFailed + " " + operateResult.Message);
				}
				else
				{
					OperateResult operateResult2 = client2.ConnectServer();
					if (!operateResult2.IsSuccess)
					{
						MessageBox.Show(StringResources.Language.ConnectedFailed + " " + operateResult2.Message);
					}
					else
					{
						OperateResult operateResult3 = client1.SelectDB(result3);
						if (!operateResult3.IsSuccess)
						{
							MessageBox.Show("client1 DB Block select wrong");
						}
						else
						{
							OperateResult operateResult4 = client2.SelectDB(result4);
							if (!operateResult4.IsSuccess)
							{
								MessageBox.Show("client2 DB Block select wrong");
							}
							else
							{
								button2.Enabled = false;
								button3.Enabled = true;
								hslPanelTextBack1.Enabled = false;
								hslPanelTextBack2.Enabled = false;
								hslPanelHead1.Enabled = true;
								MessageBox.Show("Success");
							}
						}
					}
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			RedisClient redisClient = client1;
			if (redisClient != null)
			{
				redisClient.ConnectClose();
			}
			RedisClient redisClient2 = client2;
			if (redisClient2 != null)
			{
				redisClient2.ConnectClose();
			}
			hslPanelTextBack1.Enabled = true;
			hslPanelTextBack2.Enabled = true;
			button2.Enabled = true;
			button3.Enabled = false;
			hslPanelHead1.Enabled = false;
			System.Threading.Timer obj = timer;
			if (obj != null)
			{
				obj.Dispose();
			}
			button5.Text = "定时同步";
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Clear sure?", "check", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				OperateResult operateResult = client1.FlushDB();
				if (operateResult.IsSuccess)
				{
					MessageBox.Show("Flush Success!");
				}
				else
				{
					MessageBox.Show("Flush Failed!" + operateResult.Message);
				}
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Clear sure?", "check", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				OperateResult operateResult = client2.FlushDB();
				if (operateResult.IsSuccess)
				{
					MessageBox.Show("Flush Success!");
				}
				else
				{
					MessageBox.Show("Flush Failed!" + operateResult.Message);
				}
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			ThreadPool.QueueUserWorkItem(RedisCopy, null);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (button5.Text == "定时同步")
			{
				timer = new System.Threading.Timer(RedisCopy, null, 1000, int.Parse(textBox7.Text));
				button5.Text = "关闭同步";
			}
			else
			{
				System.Threading.Timer obj = timer;
				if (obj != null)
				{
					obj.Dispose();
				}
				button5.Text = "定时同步";
			}
		}

		private void MsgShow(string msg, int progress = -1)
		{
			if (base.InvokeRequired)
			{
				Invoke(new Action<string, int>(MsgShow), msg, progress);
			}
			else
			{
				textBox10.AppendText(DateTime.Now.ToString() + " " + msg + Environment.NewLine);
				if (progress > 0)
				{
					hslProgress1.Value = progress;
				}
			}
		}

		private void RedisCopy(object obj)
		{
			if (client1 != null && client2 != null)
			{
				OperateResult<long> operateResult = client1.DBSize();
				if (!operateResult.IsSuccess)
				{
					MsgShow("Size Get Failed");
				}
				else if (operateResult.Content == 0)
				{
					MsgShow("No Key Value");
				}
				else
				{
					MsgShow("Getting all key Name");
					OperateResult<string[]> operateResult2 = client1.ReadAllKeys("*");
					if (!operateResult2.IsSuccess)
					{
						MsgShow("Key Names Get Failed");
					}
					else
					{
						hslProgress1.Max = operateResult2.Content.Length;
						hslProgress1.Value = 0;
						MsgShow("Begin Copy key value to redis2");
						for (int i = 0; i < operateResult2.Content.Length; i++)
						{
							OperateResult<string> operateResult3 = client1.ReadKeyType(operateResult2.Content[i]);
							if (!operateResult3.IsSuccess)
							{
								MsgShow("Key[" + operateResult2.Content[i] + "] Get type Failed");
								return;
							}
							MsgShow("Copy Key[" + operateResult2.Content[i] + "] Type[" + operateResult3.Content + "] ...", i + 1);
							if (operateResult3.Content == "string")
							{
								OperateResult<string> operateResult4 = client1.ReadKey(operateResult2.Content[i]);
								if (!operateResult4.IsSuccess)
								{
									MsgShow("Redis1 Key[" + operateResult2.Content[i] + "] Read Failed");
									return;
								}
								OperateResult operateResult5 = client2.WriteKey(operateResult2.Content[i], operateResult4.Content);
								if (!operateResult5.IsSuccess)
								{
									MsgShow("Redis2 Key[" + operateResult2.Content[i] + "] Copy Failed");
									return;
								}
							}
							else if (operateResult3.Content == "hash")
							{
								OperateResult<string[]> operateResult6 = client1.ReadHashKeys(operateResult2.Content[i]);
								if (!operateResult6.IsSuccess)
								{
									MsgShow("Redis1 Key[" + operateResult2.Content[i] + "] Read Failed");
									return;
								}
								OperateResult<string[]> operateResult7 = client1.ReadHashValues(operateResult2.Content[i]);
								if (!operateResult7.IsSuccess)
								{
									MsgShow("Redis1 Key[" + operateResult2.Content[i] + "] Read Failed");
									return;
								}
								OperateResult operateResult8 = client2.WriteHashKey(operateResult2.Content[i], operateResult6.Content, operateResult7.Content);
								if (!operateResult8.IsSuccess)
								{
									MsgShow("Redis2 Key[" + operateResult2.Content[i] + "] Copy Failed");
									return;
								}
							}
							else if (operateResult3.Content == "list")
							{
								OperateResult<string[]> operateResult9 = client1.ListRange(operateResult2.Content[i], 0L, -1L);
								if (!operateResult9.IsSuccess)
								{
									MsgShow("Redis1 Key[" + operateResult2.Content[i] + "] Read Failed");
									return;
								}
								OperateResult<int> listLength = client2.GetListLength(operateResult2.Content[i]);
								if (!listLength.IsSuccess)
								{
									MsgShow("Redis2 Key[" + operateResult2.Content[i] + "] Get Length Failed");
									return;
								}
								if (listLength.Content != operateResult9.Content.Length)
								{
									OperateResult operateResult10 = client2.DeleteKey(operateResult2.Content[i]);
									if (!operateResult10.IsSuccess)
									{
										MsgShow("Redis2 Key[" + operateResult2.Content[i] + "] Delete Failed");
										return;
									}
									OperateResult operateResult11 = client2.ListRightPush(operateResult2.Content[i], operateResult9.Content);
									if (!operateResult11.IsSuccess)
									{
										MsgShow("Redis2 Key[" + operateResult2.Content[i] + "] Copy Failed");
										return;
									}
								}
								else
								{
									for (int j = 0; j < operateResult9.Content.Length; j++)
									{
										OperateResult operateResult12 = client2.ListSet(operateResult2.Content[i], j, operateResult9.Content[j]);
										if (!operateResult12.IsSuccess)
										{
											MsgShow(string.Format("Redis2 Key[{0}] Index[{1}] Copy Failed", operateResult2.Content[i], j));
											return;
										}
									}
								}
							}
							else if (operateResult3.Content == "set")
							{
								OperateResult<string[]> operateResult13 = client1.SetMembers(operateResult2.Content[i]);
								if (!operateResult13.IsSuccess)
								{
									MsgShow("Redis1 Key[" + operateResult2.Content[i] + "] Read Failed");
									return;
								}
								OperateResult operateResult14 = client2.DeleteKey(operateResult2.Content[i]);
								if (!operateResult14.IsSuccess)
								{
									MsgShow("Redis2 Key[" + operateResult2.Content[i] + "] Delete Failed");
									return;
								}
								OperateResult operateResult15 = client2.SetAdd(operateResult2.Content[i], operateResult13.Content);
								if (!operateResult15.IsSuccess)
								{
									MsgShow("Redis2 Key[" + operateResult2.Content[i] + "] Write Failed");
									return;
								}
							}
							else if (operateResult3.Content == "zset")
							{
								OperateResult<string[]> operateResult16 = client1.ZSetRange(operateResult2.Content[i], 0, -1, true);
								if (!operateResult16.IsSuccess)
								{
									MsgShow("Redis1 Key[" + operateResult2.Content[i] + "] Read Failed");
									return;
								}
								OperateResult operateResult17 = client2.DeleteKey(operateResult2.Content[i]);
								if (!operateResult17.IsSuccess)
								{
									MsgShow("Redis2 Key[" + operateResult2.Content[i] + "] Delete Failed");
									return;
								}
								string[] array = new string[operateResult16.Content.Length / 2];
								double[] array2 = new double[operateResult16.Content.Length / 2];
								for (int k = 0; k < array.Length; k++)
								{
									array[i] = operateResult16.Content[i * 2];
									array2[i] = double.Parse(operateResult16.Content[i * 2 + 1]);
								}
								OperateResult operateResult18 = client2.ZSetAdd(operateResult2.Content[i], array, array2);
								if (!operateResult18.IsSuccess)
								{
									MsgShow("Redis2 Key[" + operateResult2.Content[i] + "] Write Failed");
									return;
								}
							}
						}
						MsgShow("Copy Finish");
					}
				}
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			textBox10.Clear();
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
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			hslPanelTextBack1 = new HslControls.HslPanelTextBack();
			textBox8 = new System.Windows.Forms.TextBox();
			textBox3 = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			hslPanelTextBack2 = new HslControls.HslPanelTextBack();
			textBox9 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			hslPanelHead1 = new HslControls.HslPanelHead();
			button8 = new System.Windows.Forms.Button();
			hslProgress1 = new HslControls.HslProgress();
			textBox10 = new System.Windows.Forms.TextBox();
			button7 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			label7 = new System.Windows.Forms.Label();
			textBox7 = new System.Windows.Forms.TextBox();
			button4 = new System.Windows.Forms.Button();
			hslPanelHead2 = new HslControls.HslPanelHead();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			hslPanelTextBack1.SuspendLayout();
			hslPanelTextBack2.SuspendLayout();
			hslPanelHead1.SuspendLayout();
			hslPanelHead2.SuspendLayout();
			SuspendLayout();
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
			userControlHead1.TabIndex = 15;
			hslPanelTextBack1.Controls.Add(textBox8);
			hslPanelTextBack1.Controls.Add(textBox3);
			hslPanelTextBack1.Controls.Add(label8);
			hslPanelTextBack1.Controls.Add(label3);
			hslPanelTextBack1.Controls.Add(textBox2);
			hslPanelTextBack1.Controls.Add(label2);
			hslPanelTextBack1.Controls.Add(textBox1);
			hslPanelTextBack1.Controls.Add(label1);
			hslPanelTextBack1.Location = new System.Drawing.Point(3, 35);
			hslPanelTextBack1.Name = "hslPanelTextBack1";
			hslPanelTextBack1.PanelBackColor = System.Drawing.Color.AliceBlue;
			hslPanelTextBack1.PanelTextBackColor = System.Drawing.Color.PaleTurquoise;
			hslPanelTextBack1.Size = new System.Drawing.Size(318, 157);
			hslPanelTextBack1.TabIndex = 16;
			hslPanelTextBack1.Text = "原Redis";
			hslPanelTextBack1.TextOffect = 20;
			textBox8.Location = new System.Drawing.Point(113, 121);
			textBox8.Name = "textBox8";
			textBox8.Size = new System.Drawing.Size(145, 23);
			textBox8.TabIndex = 26;
			textBox8.Text = "0";
			textBox3.Location = new System.Drawing.Point(113, 91);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(145, 23);
			textBox3.TabIndex = 5;
			label8.AutoSize = true;
			label8.BackColor = System.Drawing.Color.Transparent;
			label8.Location = new System.Drawing.Point(24, 124);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(59, 17);
			label8.TabIndex = 25;
			label8.Text = "dbBlock:";
			label3.AutoSize = true;
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.Location = new System.Drawing.Point(24, 94);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(67, 17);
			label3.TabIndex = 4;
			label3.Text = "Password:";
			textBox2.Location = new System.Drawing.Point(113, 61);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(145, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "6379";
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Location = new System.Drawing.Point(24, 64);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(35, 17);
			label2.TabIndex = 2;
			label2.Text = "Port:";
			textBox1.Location = new System.Drawing.Point(113, 31);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(145, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Location = new System.Drawing.Point(24, 34);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(75, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip Address:";
			hslPanelTextBack2.Controls.Add(textBox9);
			hslPanelTextBack2.Controls.Add(label9);
			hslPanelTextBack2.Controls.Add(textBox4);
			hslPanelTextBack2.Controls.Add(label4);
			hslPanelTextBack2.Controls.Add(textBox5);
			hslPanelTextBack2.Controls.Add(label5);
			hslPanelTextBack2.Controls.Add(textBox6);
			hslPanelTextBack2.Controls.Add(label6);
			hslPanelTextBack2.Location = new System.Drawing.Point(327, 35);
			hslPanelTextBack2.Name = "hslPanelTextBack2";
			hslPanelTextBack2.PanelBackColor = System.Drawing.Color.AliceBlue;
			hslPanelTextBack2.PanelTextBackColor = System.Drawing.Color.PaleTurquoise;
			hslPanelTextBack2.Size = new System.Drawing.Size(320, 157);
			hslPanelTextBack2.TabIndex = 17;
			hslPanelTextBack2.Text = "新Redis";
			hslPanelTextBack2.TextOffect = 20;
			textBox9.Location = new System.Drawing.Point(118, 121);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(145, 23);
			textBox9.TabIndex = 28;
			textBox9.Text = "0";
			label9.AutoSize = true;
			label9.BackColor = System.Drawing.Color.Transparent;
			label9.Location = new System.Drawing.Point(29, 124);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(59, 17);
			label9.TabIndex = 27;
			label9.Text = "dbBlock:";
			textBox4.Location = new System.Drawing.Point(118, 91);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(145, 23);
			textBox4.TabIndex = 11;
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.Location = new System.Drawing.Point(29, 94);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(67, 17);
			label4.TabIndex = 10;
			label4.Text = "Password:";
			textBox5.Location = new System.Drawing.Point(118, 61);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(145, 23);
			textBox5.TabIndex = 9;
			textBox5.Text = "6379";
			label5.AutoSize = true;
			label5.BackColor = System.Drawing.Color.Transparent;
			label5.Location = new System.Drawing.Point(29, 64);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(35, 17);
			label5.TabIndex = 8;
			label5.Text = "Port:";
			textBox6.Location = new System.Drawing.Point(118, 31);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(145, 23);
			textBox6.TabIndex = 7;
			label6.AutoSize = true;
			label6.BackColor = System.Drawing.Color.Transparent;
			label6.Location = new System.Drawing.Point(29, 34);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(75, 17);
			label6.TabIndex = 6;
			label6.Text = "Ip Address:";
			hslPanelHead1.Controls.Add(button8);
			hslPanelHead1.Controls.Add(hslProgress1);
			hslPanelHead1.Controls.Add(textBox10);
			hslPanelHead1.Controls.Add(button7);
			hslPanelHead1.Controls.Add(button6);
			hslPanelHead1.Controls.Add(button5);
			hslPanelHead1.Controls.Add(label7);
			hslPanelHead1.Controls.Add(textBox7);
			hslPanelHead1.Controls.Add(button4);
			hslPanelHead1.Location = new System.Drawing.Point(4, 246);
			hslPanelHead1.Name = "hslPanelHead1";
			hslPanelHead1.Size = new System.Drawing.Size(996, 395);
			hslPanelHead1.TabIndex = 19;
			hslPanelHead1.Text = "操作区域";
			button8.Location = new System.Drawing.Point(885, 83);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(75, 25);
			button8.TabIndex = 29;
			button8.Text = "Clear";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			hslProgress1.BackColor = System.Drawing.Color.AliceBlue;
			hslProgress1.Location = new System.Drawing.Point(15, 113);
			hslProgress1.Name = "hslProgress1";
			hslProgress1.ProgressColor = System.Drawing.Color.LightSkyBlue;
			hslProgress1.ProgressStyle = HslControls.HslProgressStyle.Horizontal;
			hslProgress1.Size = new System.Drawing.Size(945, 22);
			hslProgress1.TabIndex = 28;
			hslProgress1.TextRenderFormat = "{0} / {1}";
			hslProgress1.Value = 0;
			textBox10.Location = new System.Drawing.Point(15, 141);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(945, 229);
			textBox10.TabIndex = 27;
			button7.Location = new System.Drawing.Point(805, 41);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(155, 37);
			button7.TabIndex = 26;
			button7.Text = "清空Redis2";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			button6.Location = new System.Drawing.Point(15, 41);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(155, 37);
			button6.TabIndex = 25;
			button6.Text = "清空Redis1";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button5.Location = new System.Drawing.Point(492, 73);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(155, 37);
			button5.TabIndex = 23;
			button5.Text = "定时同步";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			label7.AutoSize = true;
			label7.BackColor = System.Drawing.Color.Transparent;
			label7.Location = new System.Drawing.Point(473, 41);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(41, 17);
			label7.TabIndex = 22;
			label7.Text = "Timer";
			textBox7.Location = new System.Drawing.Point(535, 38);
			textBox7.Name = "textBox7";
			textBox7.Size = new System.Drawing.Size(145, 23);
			textBox7.TabIndex = 21;
			textBox7.Text = "1000";
			button4.Location = new System.Drawing.Point(315, 73);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(155, 37);
			button4.TabIndex = 20;
			button4.Text = "立即同步";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			hslPanelHead2.Controls.Add(button3);
			hslPanelHead2.Controls.Add(button2);
			hslPanelHead2.Controls.Add(hslPanelTextBack1);
			hslPanelHead2.Controls.Add(hslPanelTextBack2);
			hslPanelHead2.Location = new System.Drawing.Point(4, 37);
			hslPanelHead2.Name = "hslPanelHead2";
			hslPanelHead2.Size = new System.Drawing.Size(996, 205);
			hslPanelHead2.TabIndex = 20;
			hslPanelHead2.Text = "参数设置区域";
			button3.Location = new System.Drawing.Point(668, 114);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(155, 37);
			button3.TabIndex = 20;
			button3.Text = "断开连接";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button2.Location = new System.Drawing.Point(668, 59);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(155, 37);
			button2.TabIndex = 19;
			button2.Text = "连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			AutoScroll = true;
			BackColor = System.Drawing.Color.Lavender;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(hslPanelHead2);
			base.Controls.Add(hslPanelHead1);
			base.Controls.Add(userControlHead1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "FormRedisCopy";
			Text = "Redis Copy";
			base.Load += new System.EventHandler(FormRedisCopy_Load);
			hslPanelTextBack1.ResumeLayout(false);
			hslPanelTextBack1.PerformLayout();
			hslPanelTextBack2.ResumeLayout(false);
			hslPanelTextBack2.PerformLayout();
			hslPanelHead1.ResumeLayout(false);
			hslPanelHead1.PerformLayout();
			hslPanelHead2.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
