using HslCommunication.BasicFramework;
using HslCommunication.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormBasicControl : HslFormContent
	{
		private Timer timerTick = null;

		private Random random;

		private IContainer components = null;

		private Label label3;

		private Label label2;

		private Label label1;

		private UserButton userButton3;

		private UserButton userButton2;

		private UserButton userButton1;

		private Label label8;

		private UserLantern userLantern2;

		private UserLantern userLantern1;

		private Panel panel1;

		private Panel panel2;

		private Label label4;

		private Label label5;

		private UserClock userClock1;

		private Panel panel3;

		private Label label9;

		private UserSwitch userSwitch2;

		private UserSwitch userSwitch1;

		private Panel panel4;

		private Label label6;

		private UserVerticalProgress userVerticalProgress6;

		private UserVerticalProgress userVerticalProgress5;

		private UserVerticalProgress userVerticalProgress4;

		private UserVerticalProgress userVerticalProgress3;

		private UserVerticalProgress userVerticalProgress2;

		private UserVerticalProgress userVerticalProgress1;

		private Panel panel5;

		private Label label7;

		private UserVerticalProgress userVerticalProgress7;

		private UserLantern userLantern3;

		private UserVerticalProgress userVerticalProgress8;

		private Button button1;

		private Label label10;

		private UserDrum userDrum1;

		private UserBottle userBottle1;

		public FormBasicControl()
		{
			InitializeComponent();
		}

		private void FormBasicControl_Load(object sender, EventArgs e)
		{
			random = new Random();
			timerTick = new Timer();
			timerTick.Interval = 1000;
			timerTick.Tick += TimerTick_Tick;
			timerTick.Start();
			Language(Program.Language);
			userDrum1.Text = ((Program.Language == 1) ? "锅炉1#\r\n123.45 ℃" : "Boiler 1#\r\n123.45 ℃");
		}

		private void Language(int language)
		{
			if (language == 1)
			{
				Text = "常用的简单控件";
				label1.Text = "基础样式";
				label2.Text = "选中样式";
				label3.Text = "禁用样式";
				label8.Text = "状态灯控件，目前只有简单的颜色";
				label4.Text = "闪烁";
				label6.Text = "进度条控件，允许设置背景，文本，还有简单的动画";
				label7.Text = "随机";
				label9.Text = "旋转开关控件，只有2个状态";
				label10.Text = "罐子控件";
				label5.Text = "时钟控件";
				button1.Text = "右下角弹窗";
			}
			else
			{
				Text = "Common simple controls";
				label1.Text = "Base style";
				label2.Text = "Check Style";
				label3.Text = "Disabling styles";
				label8.Text = "Status light control, currently only a simple color";
				label4.Text = "Flashing";
				label6.Text = "Progress bar controls, allowing setting of backgrounds, text, and simple animations";
				label7.Text = "Random";
				label9.Text = "Rotary switch control, only 2 states";
				label10.Text = "Container control";
				label5.Text = "Clock control";
				button1.Text = "pop-up window";
			}
		}

		private void TimerTick_Tick(object sender, EventArgs e)
		{
			if (userLantern3.LanternBackground == Color.Gray)
			{
				userLantern3.LanternBackground = Color.Tomato;
			}
			else
			{
				userLantern3.LanternBackground = Color.Gray;
			}
			int value = random.Next(101);
			userVerticalProgress7.Value = value;
			userVerticalProgress8.Value = value;
			if (userBottle1.Value > 0.0)
			{
				UserBottle userBottle = userBottle1;
				double value2 = userBottle.Value;
				userBottle.Value = value2 - 1.0;
				if (userBottle1.Value == 0.0)
				{
					userBottle1.IsOpen = false;
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FormPopup formPopup = new FormPopup("This is a test message!", Color.Blue, 5000);
			formPopup.Show();
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
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(HslCommunicationDemo.FormBasicControl));
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			label10 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			label9 = new System.Windows.Forms.Label();
			panel4 = new System.Windows.Forms.Panel();
			label6 = new System.Windows.Forms.Label();
			panel5 = new System.Windows.Forms.Panel();
			label7 = new System.Windows.Forms.Label();
			userVerticalProgress8 = new HslCommunication.Controls.UserVerticalProgress();
			userVerticalProgress7 = new HslCommunication.Controls.UserVerticalProgress();
			userVerticalProgress1 = new HslCommunication.Controls.UserVerticalProgress();
			userVerticalProgress2 = new HslCommunication.Controls.UserVerticalProgress();
			userVerticalProgress6 = new HslCommunication.Controls.UserVerticalProgress();
			userVerticalProgress3 = new HslCommunication.Controls.UserVerticalProgress();
			userVerticalProgress5 = new HslCommunication.Controls.UserVerticalProgress();
			userVerticalProgress4 = new HslCommunication.Controls.UserVerticalProgress();
			userBottle1 = new HslCommunication.Controls.UserBottle();
			userSwitch1 = new HslCommunication.Controls.UserSwitch();
			userSwitch2 = new HslCommunication.Controls.UserSwitch();
			userDrum1 = new HslCommunication.Controls.UserDrum();
			userClock1 = new HslCommunication.Controls.UserClock();
			userLantern3 = new HslCommunication.Controls.UserLantern();
			userLantern1 = new HslCommunication.Controls.UserLantern();
			userLantern2 = new HslCommunication.Controls.UserLantern();
			userButton1 = new HslCommunication.Controls.UserButton();
			userButton2 = new HslCommunication.Controls.UserButton();
			userButton3 = new HslCommunication.Controls.UserButton();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			panel4.SuspendLayout();
			panel5.SuspendLayout();
			SuspendLayout();
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(274, 61);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 11;
			label3.Text = "禁用状态";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(137, 61);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(56, 17);
			label2.TabIndex = 10;
			label2.Text = "选中模式";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(17, 61);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 9;
			label1.Text = "基础按钮";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(3, 180);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(188, 17);
			label8.TabIndex = 27;
			label8.Text = "状态灯控件，目前只有简单的颜色";
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(userButton1);
			panel1.Controls.Add(userButton2);
			panel1.Controls.Add(userButton3);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label2);
			panel1.Location = new System.Drawing.Point(14, 16);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(533, 99);
			panel1.TabIndex = 28;
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(label4);
			panel2.Controls.Add(userLantern3);
			panel2.Controls.Add(userLantern1);
			panel2.Controls.Add(userLantern2);
			panel2.Controls.Add(label8);
			panel2.Location = new System.Drawing.Point(556, 16);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(436, 217);
			panel2.TabIndex = 29;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(327, 159);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(32, 17);
			label4.TabIndex = 29;
			label4.Text = "闪烁";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(315, 297);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(56, 17);
			label5.TabIndex = 31;
			label5.Text = "时钟控件";
			panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel3.Controls.Add(userDrum1);
			panel3.Controls.Add(label10);
			panel3.Controls.Add(button1);
			panel3.Controls.Add(userClock1);
			panel3.Controls.Add(label5);
			panel3.Location = new System.Drawing.Point(556, 239);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(436, 394);
			panel3.TabIndex = 32;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(69, 297);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(56, 17);
			label10.TabIndex = 34;
			label10.Text = "罐子控件";
			button1.Location = new System.Drawing.Point(300, 341);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(123, 38);
			button1.TabIndex = 32;
			button1.Text = "右下角弹窗";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(154, 204);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(159, 17);
			label9.TabIndex = 35;
			label9.Text = "旋转开关控件，只有2个状态";
			panel4.BackColor = System.Drawing.SystemColors.Control;
			panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel4.Controls.Add(userBottle1);
			panel4.Controls.Add(label9);
			panel4.Controls.Add(userSwitch1);
			panel4.Controls.Add(userSwitch2);
			panel4.Location = new System.Drawing.Point(14, 397);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(536, 236);
			panel4.TabIndex = 36;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(13, 242);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(284, 17);
			label6.TabIndex = 43;
			label6.Text = "进度条控件，允许设置背景，文本，还有简单的动画";
			panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel5.Controls.Add(userVerticalProgress8);
			panel5.Controls.Add(label7);
			panel5.Controls.Add(userVerticalProgress7);
			panel5.Controls.Add(userVerticalProgress1);
			panel5.Controls.Add(label6);
			panel5.Controls.Add(userVerticalProgress2);
			panel5.Controls.Add(userVerticalProgress6);
			panel5.Controls.Add(userVerticalProgress3);
			panel5.Controls.Add(userVerticalProgress5);
			panel5.Controls.Add(userVerticalProgress4);
			panel5.Location = new System.Drawing.Point(14, 121);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(536, 270);
			panel5.TabIndex = 44;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(479, 239);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(32, 17);
			label7.TabIndex = 45;
			label7.Text = "随机";
			userVerticalProgress8.BackColor = System.Drawing.SystemColors.Control;
			userVerticalProgress8.BorderColor = System.Drawing.Color.Blue;
			userVerticalProgress8.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userVerticalProgress8.Location = new System.Drawing.Point(430, 16);
			userVerticalProgress8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userVerticalProgress8.Name = "userVerticalProgress8";
			userVerticalProgress8.Size = new System.Drawing.Size(33, 216);
			userVerticalProgress8.TabIndex = 46;
			userVerticalProgress8.Value = 50;
			userVerticalProgress7.BackColor = System.Drawing.SystemColors.Control;
			userVerticalProgress7.BorderColor = System.Drawing.Color.Blue;
			userVerticalProgress7.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userVerticalProgress7.Location = new System.Drawing.Point(479, 16);
			userVerticalProgress7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userVerticalProgress7.Name = "userVerticalProgress7";
			userVerticalProgress7.Size = new System.Drawing.Size(33, 216);
			userVerticalProgress7.TabIndex = 44;
			userVerticalProgress7.UseAnimation = true;
			userVerticalProgress7.Value = 50;
			userVerticalProgress1.BackColor = System.Drawing.SystemColors.Control;
			userVerticalProgress1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userVerticalProgress1.Location = new System.Drawing.Point(15, 16);
			userVerticalProgress1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userVerticalProgress1.Name = "userVerticalProgress1";
			userVerticalProgress1.Size = new System.Drawing.Size(51, 216);
			userVerticalProgress1.TabIndex = 37;
			userVerticalProgress1.Value = 50;
			userVerticalProgress2.BackColor = System.Drawing.SystemColors.Control;
			userVerticalProgress2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userVerticalProgress2.IsTextRender = false;
			userVerticalProgress2.Location = new System.Drawing.Point(72, 16);
			userVerticalProgress2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userVerticalProgress2.Name = "userVerticalProgress2";
			userVerticalProgress2.Size = new System.Drawing.Size(42, 216);
			userVerticalProgress2.TabIndex = 38;
			userVerticalProgress2.Value = 50;
			userVerticalProgress6.BackColor = System.Drawing.Color.Blue;
			userVerticalProgress6.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userVerticalProgress6.Location = new System.Drawing.Point(216, 45);
			userVerticalProgress6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userVerticalProgress6.Name = "userVerticalProgress6";
			userVerticalProgress6.ProgressStyle = HslCommunication.Controls.ProgressStyle.Horizontal;
			userVerticalProgress6.Size = new System.Drawing.Size(191, 29);
			userVerticalProgress6.TabIndex = 42;
			userVerticalProgress6.Value = 80;
			userVerticalProgress3.BackColor = System.Drawing.SystemColors.Control;
			userVerticalProgress3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userVerticalProgress3.Location = new System.Drawing.Point(120, 16);
			userVerticalProgress3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userVerticalProgress3.Name = "userVerticalProgress3";
			userVerticalProgress3.ProgressColor = System.Drawing.Color.FromArgb(0, 192, 0);
			userVerticalProgress3.Size = new System.Drawing.Size(42, 216);
			userVerticalProgress3.TabIndex = 39;
			userVerticalProgress3.Value = 50;
			userVerticalProgress5.BackColor = System.Drawing.SystemColors.Control;
			userVerticalProgress5.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userVerticalProgress5.Location = new System.Drawing.Point(216, 16);
			userVerticalProgress5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userVerticalProgress5.Name = "userVerticalProgress5";
			userVerticalProgress5.ProgressStyle = HslCommunication.Controls.ProgressStyle.Horizontal;
			userVerticalProgress5.Size = new System.Drawing.Size(191, 28);
			userVerticalProgress5.TabIndex = 41;
			userVerticalProgress5.Value = 50;
			userVerticalProgress4.BackColor = System.Drawing.SystemColors.Control;
			userVerticalProgress4.BorderColor = System.Drawing.Color.Blue;
			userVerticalProgress4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userVerticalProgress4.Location = new System.Drawing.Point(168, 16);
			userVerticalProgress4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userVerticalProgress4.Name = "userVerticalProgress4";
			userVerticalProgress4.Size = new System.Drawing.Size(42, 216);
			userVerticalProgress4.TabIndex = 40;
			userVerticalProgress4.Value = 50;
			userBottle1.BackColor = System.Drawing.Color.Transparent;
			userBottle1.BottleTag = "1#";
			userBottle1.HeadTag = "1#";
			userBottle1.IsOpen = true;
			userBottle1.Location = new System.Drawing.Point(442, 17);
			userBottle1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userBottle1.Name = "userBottle1";
			userBottle1.Size = new System.Drawing.Size(45, 180);
			userBottle1.TabIndex = 36;
			userBottle1.Value = 20.0;
			userSwitch1.BackColor = System.Drawing.Color.Transparent;
			userSwitch1.Cursor = System.Windows.Forms.Cursors.Hand;
			userSwitch1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userSwitch1.Location = new System.Drawing.Point(34, 17);
			userSwitch1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userSwitch1.Name = "userSwitch1";
			userSwitch1.Size = new System.Drawing.Size(197, 204);
			userSwitch1.SwitchForeground = System.Drawing.Color.FromArgb(36, 36, 36);
			userSwitch1.SwitchStatusDescription = new string[2]
			{
				"Off",
				"On"
			};
			userSwitch1.TabIndex = 33;
			userSwitch2.BackColor = System.Drawing.Color.Transparent;
			userSwitch2.Cursor = System.Windows.Forms.Cursors.Hand;
			userSwitch2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userSwitch2.Location = new System.Drawing.Point(224, 12);
			userSwitch2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userSwitch2.Name = "userSwitch2";
			userSwitch2.Size = new System.Drawing.Size(197, 204);
			userSwitch2.SwitchForeground = System.Drawing.Color.FromArgb(36, 36, 36);
			userSwitch2.SwitchStatus = true;
			userSwitch2.SwitchStatusDescription = new string[2]
			{
				"Off",
				"On"
			};
			userSwitch2.TabIndex = 34;
			userDrum1.BackColor = System.Drawing.Color.Transparent;
			userDrum1.BorderColor = System.Drawing.Color.Red;
			userDrum1.DrumBackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			userDrum1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userDrum1.Location = new System.Drawing.Point(26, 22);
			userDrum1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userDrum1.Name = "userDrum1";
			userDrum1.Size = new System.Drawing.Size(149, 223);
			userDrum1.TabIndex = 35;
			userDrum1.Text = "userDrum1";
			userClock1.BackColor = System.Drawing.Color.Transparent;
			userClock1.BackgroundImage = (System.Drawing.Image)componentResourceManager.GetObject("userClock1.BackgroundImage");
			userClock1.Font = new System.Drawing.Font("Courier New", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userClock1.Location = new System.Drawing.Point(187, 3);
			userClock1.Name = "userClock1";
			userClock1.Size = new System.Drawing.Size(236, 259);
			userClock1.TabIndex = 30;
			userLantern3.BackColor = System.Drawing.Color.Transparent;
			userLantern3.LanternBackground = System.Drawing.Color.Tomato;
			userLantern3.Location = new System.Drawing.Point(280, 18);
			userLantern3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			userLantern3.Name = "userLantern3";
			userLantern3.Size = new System.Drawing.Size(143, 135);
			userLantern3.TabIndex = 28;
			userLantern1.BackColor = System.Drawing.Color.Transparent;
			userLantern1.Location = new System.Drawing.Point(3, 4);
			userLantern1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userLantern1.Name = "userLantern1";
			userLantern1.Size = new System.Drawing.Size(142, 152);
			userLantern1.TabIndex = 25;
			userLantern2.BackColor = System.Drawing.Color.Transparent;
			userLantern2.LanternBackground = System.Drawing.Color.Tomato;
			userLantern2.Location = new System.Drawing.Point(165, 18);
			userLantern2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userLantern2.Name = "userLantern2";
			userLantern2.Size = new System.Drawing.Size(100, 101);
			userLantern2.TabIndex = 26;
			userButton1.BackColor = System.Drawing.Color.Transparent;
			userButton1.CustomerInformation = "";
			userButton1.EnableColor = System.Drawing.Color.FromArgb(190, 190, 190);
			userButton1.Font = new System.Drawing.Font("微软雅黑", 9f);
			userButton1.Location = new System.Drawing.Point(15, 18);
			userButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userButton1.Name = "userButton1";
			userButton1.Size = new System.Drawing.Size(118, 39);
			userButton1.TabIndex = 6;
			userButton2.BackColor = System.Drawing.Color.Transparent;
			userButton2.CustomerInformation = "";
			userButton2.EnableColor = System.Drawing.Color.FromArgb(190, 190, 190);
			userButton2.Font = new System.Drawing.Font("微软雅黑", 9f);
			userButton2.Location = new System.Drawing.Point(139, 18);
			userButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userButton2.Name = "userButton2";
			userButton2.Selected = true;
			userButton2.Size = new System.Drawing.Size(131, 39);
			userButton2.TabIndex = 7;
			userButton3.BackColor = System.Drawing.Color.Transparent;
			userButton3.CustomerInformation = "";
			userButton3.EnableColor = System.Drawing.Color.FromArgb(190, 190, 190);
			userButton3.Enabled = false;
			userButton3.Font = new System.Drawing.Font("微软雅黑", 9f);
			userButton3.Location = new System.Drawing.Point(276, 19);
			userButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userButton3.Name = "userButton3";
			userButton3.Size = new System.Drawing.Size(131, 39);
			userButton3.TabIndex = 8;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(panel5);
			base.Controls.Add(panel4);
			base.Controls.Add(panel3);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormBasicControl";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormBasicControl";
			base.Load += new System.EventHandler(FormBasicControl_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			ResumeLayout(false);
		}
	}
}
