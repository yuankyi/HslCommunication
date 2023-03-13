using HslCommunication;
using HslCommunication.Controls;
using HslCommunication.Core;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace HslCommunicationDemo.DemoControl
{
	public class UserControlCurve : UserControl
	{
		private Thread thread = null;

		private int timeSleep = 300;

		private bool isThreadRun = false;

		private IContainer components = null;

		private GroupBox groupBox5;

		private Button button27;

		private TextBox textBox14;

		private Label label18;

		private Label label17;

		private TextBox textBox12;

		private Label label15;

		private UserCurve userCurve1;

		[Browsable(false)]
		public IReadWriteNet ReadWriteNet
		{
			get;
			set;
		}

		[Category("Appearance")]
		[Description("设置或获取默认的地址信息")]
		[DefaultValue("")]
		public string AddressExample
		{
			get
			{
				return textBox12.Text;
			}
			set
			{
				textBox12.Text = value;
			}
		}

		public UserControlCurve()
		{
			InitializeComponent();
		}

		private void UserControlCurve_Load(object sender, EventArgs e)
		{
			if (Program.Language == 2)
			{
				groupBox5.Text = "Timed reading, curve display";
				label15.Text = "Address:";
				label18.Text = "Interval";
				button27.Text = "Start";
				label17.Text = "This assumes that the type of data is determined for short:";
			}
			userCurve1.SetLeftCurve("A", new float[0], Color.Tomato);
		}

		private void button27_Click(object sender, EventArgs e)
		{
			if (!isThreadRun)
			{
				if (!int.TryParse(textBox14.Text, out timeSleep))
				{
					MessageBox.Show("Time input wrong！");
				}
				else
				{
					button27.Text = "Stop";
					isThreadRun = true;
					thread = new Thread(ThreadReadServer);
					thread.IsBackground = true;
					thread.Start();
				}
			}
			else
			{
				button27.Text = "Start";
				isThreadRun = false;
			}
		}

		private void ThreadReadServer()
		{
			if (ReadWriteNet != null)
			{
				while (isThreadRun)
				{
					Thread.Sleep(timeSleep);
					try
					{
						OperateResult<short> operateResult = ReadWriteNet.ReadInt16(textBox12.Text);
						if (operateResult.IsSuccess && isThreadRun)
						{
							Invoke(new Action<short>(AddDataCurve), operateResult.Content);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Read failed：" + ex.Message);
					}
				}
			}
		}

		private void AddDataCurve(short data)
		{
			userCurve1.AddCurveData("A", (float)data);
		}

		public void ThreadQuit()
		{
			isThreadRun = false;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			isThreadRun = false;
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			groupBox5 = new System.Windows.Forms.GroupBox();
			button27 = new System.Windows.Forms.Button();
			textBox14 = new System.Windows.Forms.TextBox();
			label18 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			textBox12 = new System.Windows.Forms.TextBox();
			label15 = new System.Windows.Forms.Label();
			userCurve1 = new HslCommunication.Controls.UserCurve();
			groupBox5.SuspendLayout();
			SuspendLayout();
			groupBox5.Controls.Add(button27);
			groupBox5.Controls.Add(textBox14);
			groupBox5.Controls.Add(label18);
			groupBox5.Controls.Add(label17);
			groupBox5.Controls.Add(textBox12);
			groupBox5.Controls.Add(label15);
			groupBox5.Controls.Add(userCurve1);
			groupBox5.Location = new System.Drawing.Point(0, 0);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(419, 278);
			groupBox5.TabIndex = 5;
			groupBox5.TabStop = false;
			groupBox5.Text = "定时读取，曲线显示";
			button27.Location = new System.Drawing.Point(343, 25);
			button27.Name = "button27";
			button27.Size = new System.Drawing.Size(70, 28);
			button27.TabIndex = 9;
			button27.Text = "启动";
			button27.UseVisualStyleBackColor = true;
			button27.Click += new System.EventHandler(button27_Click);
			textBox14.Location = new System.Drawing.Point(267, 28);
			textBox14.Name = "textBox14";
			textBox14.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox14.Size = new System.Drawing.Size(70, 21);
			textBox14.TabIndex = 8;
			textBox14.Text = "300";
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(208, 31);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(41, 12);
			label18.TabIndex = 7;
			label18.Text = "间隔：";
			label17.AutoSize = true;
			label17.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			label17.Location = new System.Drawing.Point(76, 60);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(215, 12);
			label17.TabIndex = 6;
			label17.Text = "此处假设确定了数据的类型，为short：";
			textBox12.Location = new System.Drawing.Point(78, 27);
			textBox12.Name = "textBox12";
			textBox12.Size = new System.Drawing.Size(118, 21);
			textBox12.TabIndex = 5;
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(11, 31);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(41, 12);
			label15.TabIndex = 4;
			label15.Text = "地址：";
			userCurve1.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
			userCurve1.Location = new System.Drawing.Point(13, 82);
			userCurve1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userCurve1.Name = "userCurve1";
			userCurve1.Size = new System.Drawing.Size(400, 189);
			userCurve1.TabIndex = 0;
			userCurve1.ValueMaxLeft = 200f;
			userCurve1.ValueMaxRight = 200f;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(groupBox5);
			base.Name = "UserControlCurve";
			base.Size = new System.Drawing.Size(420, 279);
			base.Load += new System.EventHandler(UserControlCurve_Load);
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			ResumeLayout(false);
		}
	}
}
