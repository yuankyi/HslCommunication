using HslCommunication.LogNet;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace HslCommunicationDemo.DemoControl
{
	public class FormLogRender : DockContent
	{
		private ILogNet logNet = null;

		private IContainer components = null;

		private TextBox textBox1;

		public FormLogRender(ILogNet logNet)
		{
			InitializeComponent();
			this.logNet = logNet;
		}

		private void FormLogRender_Load(object sender, EventArgs e)
		{
			logNet.BeforeSaveToFile += LogNet_BeforeSaveToFile;
		}

		private void LogNet_BeforeSaveToFile(object sender, HslEventArgs e)
		{
			try
			{
				Invoke((Action)delegate
				{
					textBox1.AppendText(e.HslMessage.ToString() + Environment.NewLine);
				});
			}
			catch
			{
			}
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			logNet.BeforeSaveToFile -= LogNet_BeforeSaveToFile;
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
			textBox1 = new System.Windows.Forms.TextBox();
			SuspendLayout();
			textBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox1.Location = new System.Drawing.Point(1, 3);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox1.Size = new System.Drawing.Size(906, 244);
			textBox1.TabIndex = 0;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(909, 247);
			base.Controls.Add(textBox1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "FormLogRender";
			Text = "日志显示";
			base.Load += new System.EventHandler(FormLogRender_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
