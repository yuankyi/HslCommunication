using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Profinet.Toledo;
using HslCommunicationDemo.DemoControl;
using HslControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.Toledo
{
	public class FormToledoTcpServer : HslFormContent
	{
		private ToledoTcpServer toledoTcpServer;

		private long receiveTimes = 0L;

		private IContainer components = null;

		private UserControlHead userControlHead1;

		private Panel panel2;

		private TextBox textBox6;

		private CheckBox checkBox4;

		private Label label7;

		private Panel panel1;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private CheckBox checkBox1;

		private ToledoDataControl toledoDataControl1;

		private Label label2;

		private TextBox textBox1;

		private Label label1;

		private TextBox textBox3;

		private Label label4;

		private Button button3;

		private TextBox textBox4;

		private Label label5;

		private HslDialPlate hslDialPlate1;

		private HslCurve hslCurve1;

		private Label label8;

		public FormToledoTcpServer()
		{
			InitializeComponent();
		}

		private void FormToledoTcpServer_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			button2.Enabled = false;
			Language(Program.Language);
			hslCurve1.SetLeftCurve("重量", null, Color.Red);
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "Toledo Tcp Server Demo";
				button1.Text = "Open";
				button2.Text = "Close";
				label7.Text = "Data receiving Area:";
				checkBox4.Text = "Whether to show time";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show((Program.Language == 1) ? "端口号输入错误！" : "Port input wrong");
			}
			else
			{
				try
				{
					toledoTcpServer = new ToledoTcpServer();
					toledoTcpServer.HasChk = checkBox1.Checked;
					toledoTcpServer.OnToledoStandardDataReceived += ToledoTcpServer_OnToledoStandardDataReceived;
					toledoTcpServer.ServerStart(result);
					button1.Enabled = false;
					button2.Enabled = true;
					panel2.Enabled = true;
				}
				catch (Exception ex)
				{
					SoftBasic.ShowExceptionMessage(ex);
				}
			}
		}

		private void ToledoTcpServer_OnToledoStandardDataReceived(object sender, ToledoStandardData e)
		{
			if (base.InvokeRequired)
			{
				Invoke(new Action<object, ToledoStandardData>(ToledoTcpServer_OnToledoStandardDataReceived), sender, e);
			}
			else
			{
				receiveTimes++;
				StringBuilder stringBuilder = new StringBuilder();
				if (checkBox4.Checked)
				{
					stringBuilder.Append(DateTime.Now.ToString() + Environment.NewLine);
				}
				stringBuilder.Append(e.ToJsonString() + Environment.NewLine);
				textBox6.Text = stringBuilder.ToString();
				textBox1.Text = e.SourceData.ToHexString(' ');
				textBox3.Text = Encoding.ASCII.GetString(e.SourceData);
				toledoDataControl1.SetToledoData(e);
				hslCurve1.AddCurveData("重量", e.Weight);
				hslDialPlate1.Value = e.Weight;
				label2.Text = "Receive Times:" + receiveTimes.ToString();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				ToledoTcpServer obj = toledoTcpServer;
				if (obj != null)
				{
					obj.ServerClose();
				}
				button2.Enabled = false;
				button1.Enabled = true;
				panel2.Enabled = false;
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage(ex);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			float result;
			if (float.TryParse(textBox4.Text, out result))
			{
				hslCurve1.ValueMaxLeft = result;
				hslDialPlate1.MaxValue = result;
			}
			else
			{
				MessageBox.Show("Input Wrong");
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlSumCheck, checkBox1.Checked);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			checkBox1.Checked = bool.Parse(element.Attribute(DemoDeviceList.XmlSumCheck).Value);
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
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel2 = new System.Windows.Forms.Panel();
			button3 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			hslDialPlate1 = new HslControls.HslDialPlate();
			hslCurve1 = new HslControls.HslCurve();
			textBox3 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			toledoDataControl1 = new HslCommunicationDemo.Toledo.ToledoDataControl();
			checkBox4 = new System.Windows.Forms.CheckBox();
			label7 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			checkBox1 = new System.Windows.Forms.CheckBox();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			panel2.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Toledo Tcp Server";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 16;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(label8);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(textBox4);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(textBox6);
			panel2.Controls.Add(hslDialPlate1);
			panel2.Controls.Add(hslCurve1);
			panel2.Controls.Add(textBox3);
			panel2.Controls.Add(label4);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(textBox1);
			panel2.Controls.Add(label1);
			panel2.Controls.Add(toledoDataControl1);
			panel2.Controls.Add(checkBox4);
			panel2.Controls.Add(label7);
			panel2.Location = new System.Drawing.Point(3, 93);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(997, 551);
			panel2.TabIndex = 19;
			button3.Location = new System.Drawing.Point(310, 95);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(91, 28);
			button3.TabIndex = 32;
			button3.Text = "Setting";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox4.Location = new System.Drawing.Point(194, 98);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(100, 23);
			textBox4.TabIndex = 31;
			textBox4.Text = "100";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(116, 101);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(72, 17);
			label5.TabIndex = 30;
			label5.Text = "Max Value:";
			textBox6.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			textBox6.Location = new System.Drawing.Point(555, 101);
			textBox6.Multiline = true;
			textBox6.Name = "textBox6";
			textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox6.Size = new System.Drawing.Size(209, 415);
			textBox6.TabIndex = 21;
			hslDialPlate1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			hslDialPlate1.BoderColor2 = System.Drawing.Color.FromArgb(228, 229, 229);
			hslDialPlate1.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
			hslDialPlate1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			hslDialPlate1.Location = new System.Drawing.Point(792, 329);
			hslDialPlate1.Name = "hslDialPlate1";
			hslDialPlate1.Size = new System.Drawing.Size(192, 188);
			hslDialPlate1.TabIndex = 29;
			hslCurve1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			hslCurve1.Location = new System.Drawing.Point(3, 137);
			hslCurve1.Name = "hslCurve1";
			hslCurve1.Size = new System.Drawing.Size(546, 379);
			hslCurve1.TabIndex = 28;
			hslCurve1.Title = "重力曲线图";
			textBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox3.Location = new System.Drawing.Point(62, 61);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(698, 23);
			textBox3.TabIndex = 27;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(8, 63);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(42, 17);
			label4.TabIndex = 26;
			label4.Text = "ASCII:";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(324, 11);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(93, 17);
			label2.TabIndex = 25;
			label2.Text = "Receive Times:";
			textBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox1.Location = new System.Drawing.Point(62, 34);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(698, 23);
			textBox1.TabIndex = 24;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 37);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(33, 17);
			label1.TabIndex = 23;
			label1.Text = "Hex:";
			toledoDataControl1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			toledoDataControl1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			toledoDataControl1.Location = new System.Drawing.Point(770, 3);
			toledoDataControl1.Name = "toledoDataControl1";
			toledoDataControl1.Size = new System.Drawing.Size(216, 320);
			toledoDataControl1.TabIndex = 22;
			checkBox4.AutoSize = true;
			checkBox4.Checked = true;
			checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox4.Location = new System.Drawing.Point(94, 10);
			checkBox4.Name = "checkBox4";
			checkBox4.Size = new System.Drawing.Size(99, 21);
			checkBox4.TabIndex = 20;
			checkBox4.Text = "是否显示时间";
			checkBox4.UseVisualStyleBackColor = true;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(8, 11);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(80, 17);
			label7.TabIndex = 18;
			label7.Text = "数据接收区：";
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(checkBox1);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 54);
			panel1.TabIndex = 18;
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(192, 17);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(99, 21);
			checkBox1.TabIndex = 6;
			checkBox1.Text = "是否有校验位";
			checkBox1.UseVisualStyleBackColor = true;
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(434, 11);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "关闭服务";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(337, 11);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "打开服务";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(75, 14);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(100, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "6000";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(8, 17);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(44, 17);
			label3.TabIndex = 2;
			label3.Text = "Port：";
			label8.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(4, 528);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(272, 17);
			label8.TabIndex = 48;
			label8.Text = "支持连续标准输出的格式，支持连续扩展输出格式";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			base.Controls.Add(userControlHead1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormToledoTcpServer";
			Text = "托利多网口调试工具";
			base.Load += new System.EventHandler(FormToledoTcpServer_Load);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
