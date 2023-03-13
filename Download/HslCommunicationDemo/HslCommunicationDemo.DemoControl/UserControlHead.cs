using HslCommunication.BasicFramework;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo.DemoControl
{
	public class UserControlHead : UserControl
	{
		private IContainer components = null;

		private Label label2;

		private LinkLabel linkLabel1;

		private Label label4;

		private Label label5;

		private LinkLabel linkLabel2;

		private LinkLabel linkLabel3;

		[Browsable(true)]
		[Category("HslCommunicationDemo")]
		[DefaultValue("http://www.hslcommunication.cn")]
		public string HelpLink
		{
			get
			{
				return linkLabel1.Text;
			}
			set
			{
				linkLabel1.Text = value;
			}
		}

		[Browsable(true)]
		[Category("HslCommunicationDemo")]
		[DefaultValue("Hsl")]
		public string ProtocolInfo
		{
			get
			{
				return label5.Text;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					label4.Visible = false;
				}
				else
				{
					label4.Visible = true;
				}
				label5.Text = value;
			}
		}

		[Browsable(true)]
		[Category("HslCommunicationDemo")]
		[DefaultValue(false)]
		public bool SupportListVisiable
		{
			get
			{
				return linkLabel3.Visible;
			}
			set
			{
				linkLabel3.Visible = value;
			}
		}

		public event EventHandler<EventArgs> SaveConnectEvent;

		public UserControlHead()
		{
			InitializeComponent();
		}

		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start(linkLabel1.Text);
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage(ex);
			}
		}

		private void UserControlHead_Load(object sender, EventArgs e)
		{
			if (Program.Language == 1)
			{
				label2.Text = "博客地址：";
				label4.Text = "使用协议：";
				linkLabel2.Text = "保存连接";
				linkLabel3.Text = "支持列表";
			}
			else
			{
				label2.Text = "Blogs:";
				label4.Text = "Protocols:";
				linkLabel2.Text = "Save Connect";
			}
			if (!Program.ShowAuthorInfomation)
			{
				label2.Visible = false;
				linkLabel1.Visible = false;
			}
			BackColor = FormMain.ThemeColor;
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.SaveConnectEvent == null)
			{
				MessageBox.Show(new NotImplementedException().Message);
			}
			else
			{
				EventHandler<EventArgs> saveConnectEvent = this.SaveConnectEvent;
				if (saveConnectEvent != null)
				{
					saveConnectEvent(sender, new EventArgs());
				}
			}
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Windows.Forms.Control parent = base.Parent;
			while (!(parent is HslFormContent) && parent != null && parent.Parent != null)
			{
				parent = parent.Parent;
			}
			if (parent != null)
			{
				using (FormDeviceSupport formDeviceSupport = new FormDeviceSupport(parent.GetType().Name))
				{
					formDeviceSupport.ShowDialog();
				}
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
			label2 = new System.Windows.Forms.Label();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			linkLabel2 = new System.Windows.Forms.LinkLabel();
			linkLabel3 = new System.Windows.Forms.LinkLabel();
			SuspendLayout();
			label2.AutoSize = true;
			label2.ForeColor = System.Drawing.Color.White;
			label2.Location = new System.Drawing.Point(13, 6);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(68, 17);
			label2.TabIndex = 12;
			label2.Text = "博客地址：";
			linkLabel1.AutoSize = true;
			linkLabel1.LinkColor = System.Drawing.Color.FromArgb(255, 255, 128);
			linkLabel1.Location = new System.Drawing.Point(80, 6);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(194, 17);
			linkLabel1.TabIndex = 13;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "http://www.hslcommunication.cn";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(LinkLabel1_LinkClicked);
			label4.AutoSize = true;
			label4.ForeColor = System.Drawing.Color.White;
			label4.Location = new System.Drawing.Point(480, 6);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(68, 17);
			label4.TabIndex = 14;
			label4.Text = "使用协议：";
			label5.AutoSize = true;
			label5.ForeColor = System.Drawing.Color.White;
			label5.Location = new System.Drawing.Point(554, 6);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(26, 17);
			label5.TabIndex = 15;
			label5.Text = "Hsl";
			linkLabel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			linkLabel2.LinkColor = System.Drawing.Color.Lavender;
			linkLabel2.Location = new System.Drawing.Point(911, 2);
			linkLabel2.Name = "linkLabel2";
			linkLabel2.Size = new System.Drawing.Size(95, 26);
			linkLabel2.TabIndex = 16;
			linkLabel2.TabStop = true;
			linkLabel2.Text = "Save Connect";
			linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel2_LinkClicked);
			linkLabel3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			linkLabel3.LinkColor = System.Drawing.Color.Cyan;
			linkLabel3.Location = new System.Drawing.Point(811, 2);
			linkLabel3.Name = "linkLabel3";
			linkLabel3.Size = new System.Drawing.Size(89, 26);
			linkLabel3.TabIndex = 17;
			linkLabel3.TabStop = true;
			linkLabel3.Text = "Support List";
			linkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			linkLabel3.Visible = false;
			linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel3_LinkClicked);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			base.Controls.Add(linkLabel3);
			base.Controls.Add(linkLabel2);
			base.Controls.Add(label2);
			base.Controls.Add(linkLabel1);
			base.Controls.Add(label4);
			base.Controls.Add(label5);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			MinimumSize = new System.Drawing.Size(800, 32);
			base.Name = "UserControlHead";
			base.Size = new System.Drawing.Size(1008, 32);
			base.Load += new System.EventHandler(UserControlHead_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
