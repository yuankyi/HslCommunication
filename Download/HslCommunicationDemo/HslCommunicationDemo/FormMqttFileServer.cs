using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using HslCommunication.LogNet;
using HslCommunication.MQTT;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormMqttFileServer : HslFormContent
	{
		private Timer timer1s;

		private MqttServer mqttServer;

		private bool isStop = false;

		private IContainer components = null;

		private Panel panel1;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private Panel panel2;

		private TextBox textBox8;

		private Label label12;

		private Button button4;

		private UserControlHead userControlHead1;

		private CheckBox checkBox1;

		private Label label2;

		private Button button7;

		private Label label4;

		private Label label5;

		private TextBox textBox1;

		private Label label13;

		private DataGridView dataGridView1;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewTextBoxColumn Column3;

		private DataGridViewTextBoxColumn Column4;

		private DataGridViewTextBoxColumn Column5;

		private DataGridViewTextBoxColumn Column6;

		private DataGridViewTextBoxColumn Column7;

		private DataGridViewTextBoxColumn Column8;

		private DataGridViewTextBoxColumn Column9;

		private DataGridViewTextBoxColumn Column10;

		private DataGridViewTextBoxColumn Column11;

		private Label label7;

		private Label label6;

		public FormMqttFileServer()
		{
			InitializeComponent();
		}

		private void FormClient_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			button2.Enabled = false;
			textBox1.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ServerFiles");
			Language(Program.Language);
			timer1s = new Timer();
			timer1s.Interval = 1000;
			timer1s.Tick += Timer1s_Tick;
			timer1s.Start();
		}

		private void Timer1s_Tick(object sender, EventArgs e)
		{
			if (mqttServer != null)
			{
				label2.Text = "Online Count:" + mqttServer.OnlineCount.ToString();
				MqttFileMonitorItem[] monitorItemsSnapShoot = mqttServer.GetMonitorItemsSnapShoot();
				DataGridSpecifyRowCount(monitorItemsSnapShoot.Length);
				long num = 0L;
				long num2 = 0L;
				for (int i = 0; i < monitorItemsSnapShoot.Length; i++)
				{
					DataGridViewRow dataGridViewRow = dataGridView1.Rows[i];
					MqttFileMonitorItem mqttFileMonitorItem = monitorItemsSnapShoot[i];
					dataGridViewRow.Cells[0].Value = mqttFileMonitorItem.UniqueId.ToString();
					dataGridViewRow.Cells[1].Value = mqttFileMonitorItem.EndPoint.ToString();
					dataGridViewRow.Cells[2].Value = mqttFileMonitorItem.ClientId;
					dataGridViewRow.Cells[3].Value = mqttFileMonitorItem.UserName;
					dataGridViewRow.Cells[4].Value = mqttFileMonitorItem.Operate;
					dataGridViewRow.Cells[5].Value = mqttFileMonitorItem.Groups;
					dataGridViewRow.Cells[6].Value = mqttFileMonitorItem.FileName;
					dataGridViewRow.Cells[7].Value = mqttFileMonitorItem.StartTime.ToString();
					dataGridViewRow.Cells[8].Value = SoftBasic.GetSizeDescription(mqttFileMonitorItem.TotalSize);
					dataGridViewRow.Cells[9].Value = ((mqttFileMonitorItem.TotalSize == 0L) ? "-" : (SoftBasic.GetSizeDescription(mqttFileMonitorItem.SpeedSecond) + "/s"));
					dataGridViewRow.Cells[10].Value = ((mqttFileMonitorItem.TotalSize == 0L) ? "-" : ((mqttFileMonitorItem.LastUpdateProgress * 100 / mqttFileMonitorItem.TotalSize).ToString() + "%"));
					if (mqttFileMonitorItem.Operate == "Upload")
					{
						num += mqttFileMonitorItem.SpeedSecond;
					}
					if (mqttFileMonitorItem.Operate == "Download")
					{
						num2 += mqttFileMonitorItem.SpeedSecond;
					}
				}
				label6.Text = "Upload:" + SoftBasic.GetSizeDescription(num) + "/s";
				label7.Text = "Download:" + SoftBasic.GetSizeDescription(num2) + "/s";
			}
		}

		private void DataGridSpecifyRowCount(int row)
		{
			if (dataGridView1.RowCount < row)
			{
				dataGridView1.Rows.Add(row - dataGridView1.RowCount);
			}
			else if (dataGridView1.RowCount > row)
			{
				int num = dataGridView1.RowCount - row;
				for (int i = 0; i < num; i++)
				{
					dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
				}
			}
			if (row > 0)
			{
				dataGridView1.Rows[0].Cells[0].Selected = false;
			}
		}

		private void Language(int language)
		{
			if (language != 1)
			{
				Text = "Mqtt File Server Test";
				label3.Text = "Port:";
				button1.Text = "Start";
				button2.Text = "Close";
				button4.Text = "Clear";
				label12.Text = "Receive:";
				label13.Text = "File Path:";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				mqttServer = new MqttServer();
				mqttServer.ClientVerification += MqttServer_ClientVerification;
				mqttServer.FileOperateVerification += MqttServer_FileOperateVerification;
				mqttServer.ServerStart(int.Parse(textBox2.Text));
				mqttServer.LogNet = new LogNetSingle("");
				mqttServer.LogNet.SetMessageDegree(HslMessageDegree.INFO);
				mqttServer.LogNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
				mqttServer.UseFileServer(textBox1.Text);
				button1.Enabled = false;
				button2.Enabled = true;
				panel2.Enabled = true;
				MessageBox.Show("Start Success");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Start Failed : " + ex.Message);
			}
		}

		private OperateResult MqttServer_FileOperateVerification(MqttSession session, byte code, string[] groups, string[] fileNames)
		{
			if (string.IsNullOrEmpty(session.UserName) && code == 103)
			{
				return new OperateResult("Null Account Not Allowed operation");
			}
			if (session.UserName == "hsl" && (code == 102 || code == 103 || code == 101))
			{
				return new OperateResult("Account hsl not Allowed operation");
			}
			return OperateResult.CreateSuccessResult();
		}

		private int MqttServer_ClientVerification(MqttSession mqttSession, string clientId, string userName, string passwrod)
		{
			if (!checkBox1.Checked)
			{
				return 0;
			}
			if (userName == "admin" && passwrod == "123456")
			{
				return 0;
			}
			return 5;
		}

		private void LogNet_BeforeSaveToFile(object sender, HslEventArgs e)
		{
			Invoke((Action)delegate
			{
				textBox8.AppendText(e.HslMessage.ToString() + Environment.NewLine);
			});
		}

		private void button2_Click(object sender, EventArgs e)
		{
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;
			mqttServer.ServerClose();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			textBox8.Clear();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (!isStop)
			{
				button7.Text = "继续";
				isStop = true;
			}
			else
			{
				isStop = false;
				button7.Text = "暂停";
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlFilePath, textBox1.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox1.Text = element.Attribute(DemoDeviceList.XmlFilePath).Value;
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			panel1 = new System.Windows.Forms.Panel();
			textBox1 = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			checkBox1 = new System.Windows.Forms.CheckBox();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			dataGridView1 = new System.Windows.Forms.DataGridView();
			Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			button7 = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			textBox8 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			button4 = new System.Windows.Forms.Button();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label13);
			panel1.Controls.Add(checkBox1);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 72);
			panel1.TabIndex = 7;
			textBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox1.Location = new System.Drawing.Point(95, 40);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(873, 23);
			textBox1.TabIndex = 8;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(7, 43);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(92, 17);
			label13.TabIndex = 7;
			label13.Text = "文件存储路径：";
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(163, 13);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(288, 21);
			checkBox1.TabIndex = 6;
			checkBox1.Text = "启用用户名和密码(用户名 admin  密码: 123456)";
			checkBox1.UseVisualStyleBackColor = true;
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(587, 6);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭服务";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(478, 6);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "启动服务";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(62, 11);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(75, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "1883";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(8, 14);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(label7);
			panel2.Controls.Add(label6);
			panel2.Controls.Add(dataGridView1);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(label4);
			panel2.Controls.Add(button7);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(textBox8);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(button4);
			panel2.Location = new System.Drawing.Point(3, 111);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 532);
			panel2.TabIndex = 13;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(260, 182);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(70, 17);
			label7.TabIndex = 33;
			label7.Text = "Download:";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(105, 182);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(54, 17);
			label6.TabIndex = 32;
			label6.Text = "Upload:";
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			dataGridView1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9, Column10, Column11);
			dataGridView1.Location = new System.Drawing.Point(3, 24);
			dataGridView1.MultiSelect = false;
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersVisible = false;
			dataGridView1.RowTemplate.Height = 23;
			dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.Size = new System.Drawing.Size(989, 150);
			dataGridView1.TabIndex = 31;
			Column1.HeaderText = "UniqueId";
			Column1.Name = "Column1";
			Column1.ReadOnly = true;
			Column1.Width = 86;
			Column2.HeaderText = "EndPoint";
			Column2.Name = "Column2";
			Column2.ReadOnly = true;
			Column2.Width = 84;
			Column3.HeaderText = "ClientId";
			Column3.Name = "Column3";
			Column3.ReadOnly = true;
			Column3.Width = 77;
			Column4.HeaderText = "UserName";
			Column4.Name = "Column4";
			Column4.ReadOnly = true;
			Column4.Width = 95;
			Column5.HeaderText = "Operate";
			Column5.Name = "Column5";
			Column5.ReadOnly = true;
			Column5.Width = 81;
			Column6.HeaderText = "Groups";
			Column6.Name = "Column6";
			Column6.ReadOnly = true;
			Column6.Width = 76;
			Column7.HeaderText = "FileName";
			Column7.Name = "Column7";
			Column7.ReadOnly = true;
			Column7.Width = 87;
			Column8.HeaderText = "StartTime";
			Column8.Name = "Column8";
			Column8.ReadOnly = true;
			Column8.Width = 88;
			Column9.HeaderText = "FileSize";
			Column9.Name = "Column9";
			Column9.ReadOnly = true;
			Column9.Width = 75;
			Column10.HeaderText = "Speed";
			Column10.Name = "Column10";
			Column10.ReadOnly = true;
			Column10.Width = 70;
			Column11.HeaderText = "Percent";
			Column11.Name = "Column11";
			Column11.ReadOnly = true;
			Column11.Width = 76;
			label5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(27, 4);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(93, 17);
			label5.TabIndex = 30;
			label5.Text = "Online Client：";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(8, 182);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(81, 17);
			label4.TabIndex = 29;
			label4.Text = "Total Speed:";
			button7.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button7.Location = new System.Drawing.Point(804, 180);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(91, 28);
			button7.TabIndex = 28;
			button7.Text = "暂停";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			label2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(874, 4);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(86, 17);
			label2.TabIndex = 27;
			label2.Text = "Online Count:";
			textBox8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox8.Location = new System.Drawing.Point(62, 214);
			textBox8.Multiline = true;
			textBox8.Name = "textBox8";
			textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox8.Size = new System.Drawing.Size(930, 313);
			textBox8.TabIndex = 18;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(8, 217);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(42, 17);
			label12.TabIndex = 19;
			label12.Text = "Log：";
			button4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button4.Location = new System.Drawing.Point(901, 180);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(91, 28);
			button4.TabIndex = 17;
			button4.Text = "清空";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/12312952.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "MQTT-FILE";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 14;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormMqttFileServer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "MQTT 文件服务器";
			base.Load += new System.EventHandler(FormClient_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
		}
	}
}
