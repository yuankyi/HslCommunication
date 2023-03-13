using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Profinet.OpenProtocol;
using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormOpenProtocol : HslFormContent
	{
		private OpenProtocolNet openProtocol = null;

		private IContainer components = null;

		private UserControlHead userControlHead1;

		private Panel panel2;

		private GroupBox groupBox1;

		private Button button_read_string;

		private TextBox textBox_result;

		private Label label7;

		private TextBox textBox_mid;

		private Label label6;

		private Panel panel1;

		private Button button2;

		private Button button1;

		private TextBox textBox_port;

		private Label label3;

		private TextBox textBox_ip;

		private Label label1;

		private TextBox textBox_revision;

		private Label label2;

		private TextBox textBox_stationID;

		private Label label4;

		private TextBox textBox_spindleID;

		private Label label5;

		private TextBox textBox_dataField;

		private Label label8;

		private TreeView treeView1;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private TabPage tabPage2;

		public FormOpenProtocol()
		{
			InitializeComponent();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox_port.Text, out result))
			{
				MessageBox.Show("端口输入格式不正确！");
			}
			else
			{
				OpenProtocolNet openProtocolNet = openProtocol;
				if (openProtocolNet != null)
				{
					openProtocolNet.ConnectClose();
				}
				openProtocol = new OpenProtocolNet(textBox_ip.Text, result);
				openProtocol.LogNet = base.LogNet;
				openProtocol.OnReceivedOpenMessage += OpenProtocol_ReceivedMessage;
				try
				{
					OperateResult operateResult = openProtocol.ConnectServer();
					if (operateResult.IsSuccess)
					{
						MessageBox.Show("连接成功！");
						button2.Enabled = true;
						button1.Enabled = false;
						panel2.Enabled = true;
					}
					else
					{
						MessageBox.Show("连接失败：" + operateResult.Message);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void OpenProtocol_ReceivedMessage(object sender, OpenEventArgs e)
		{
			Invoke((Action)delegate
			{
				textBox_result.AppendText(DateTime.Now.ToString() + " : " + e.Content + Environment.NewLine);
			});
		}

		private void FormOpenProtocol_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			TreeNode treeNode = new TreeNode("Parameter set messages");
			treeNode.Nodes.Add(new TreeNode("MID 0010 Parameter set ID upload")
			{
				Tag = new OpenMessage(10, 1, -1, -1, null)
			});
			treeNode.Nodes.Add(new TreeNode("MID 0012 Parameter set data upload")
			{
				Tag = new OpenMessage(12, 1, -1, -1, new List<string>
				{
					"000"
				})
			});
			treeNode.Nodes.Add(new TreeNode("MID 0014 Parameter set selected subscribe")
			{
				Tag = new OpenMessage(14, 1, -1, -1, null)
			});
			treeNode.Nodes.Add(new TreeNode("MID 0017 Parameter set selected unsubscribe")
			{
				Tag = new OpenMessage(17, 1, -1, -1, null)
			});
			treeNode.Nodes.Add(new TreeNode("MID 0018 Select Parameter set")
			{
				Tag = new OpenMessage(18, 1, -1, -1, new List<string>
				{
					"000",
					"00"
				})
			});
			treeNode.Nodes.Add(new TreeNode("MID 0019 Set Parameter set batch size")
			{
				Tag = new OpenMessage(19, 1, -1, -1, new List<string>
				{
					"000",
					"00"
				})
			});
			treeNode.Nodes.Add(new TreeNode("MID 0020 Reset Parameter set batch counter")
			{
				Tag = new OpenMessage(20, 1, -1, -1, new List<string>
				{
					"000"
				})
			});
			treeView1.Nodes.Add(treeNode);
			TreeNode treeNode2 = new TreeNode("Job message");
			treeNode2.Nodes.Add(new TreeNode("MID 0030 Job ID upload")
			{
				Tag = new OpenMessage(30, 1, -1, -1, null)
			});
			treeNode2.Nodes.Add(new TreeNode("MID 0032 Job data upload")
			{
				Tag = new OpenMessage(32, 1, -1, -1, null)
			});
			treeNode2.Nodes.Add(new TreeNode("MID 0034 Job info subscribe")
			{
				Tag = new OpenMessage(34, 1, -1, -1, null)
			});
			treeNode2.Nodes.Add(new TreeNode("MID 0037 Job info unsubscribe")
			{
				Tag = new OpenMessage(37, 1, -1, -1, null)
			});
			treeNode2.Nodes.Add(new TreeNode("MID 0038 Select Job")
			{
				Tag = new OpenMessage(38, 1, -1, -1, new List<string>
				{
					"00"
				})
			});
			treeNode2.Nodes.Add(new TreeNode("MID 0039 Job restart")
			{
				Tag = new OpenMessage(39, 1, -1, -1, new List<string>
				{
					"00"
				})
			});
			treeView1.Nodes.Add(treeNode2);
			TreeNode treeNode3 = new TreeNode("Tool messages");
			treeNode3.Nodes.Add(new TreeNode("MID 0040 Tool data upload")
			{
				Tag = new OpenMessage(40, 1, -1, -1, null)
			});
			treeNode3.Nodes.Add(new TreeNode("MID 0042 Disable tool")
			{
				Tag = new OpenMessage(42, 1, -1, -1, null)
			});
			treeNode3.Nodes.Add(new TreeNode("MID 0043 Enable tool")
			{
				Tag = new OpenMessage(43, 1, -1, -1, null)
			});
			treeNode3.Nodes.Add(new TreeNode("MID 0044 Disconnect tool")
			{
				Tag = new OpenMessage(44, 1, -1, -1, null)
			});
			treeNode3.Nodes.Add(new TreeNode("MID 0045 Set calibration value")
			{
				Tag = new OpenMessage(44, 1, -1, -1, new List<string>
				{
					"011",
					"02003550"
				})
			});
			treeView1.Nodes.Add(treeNode3);
			TreeNode treeNode4 = new TreeNode("VIN Messages");
			treeNode4.Nodes.Add(new TreeNode("MID 0050 Vehicle ID Number download")
			{
				Tag = new OpenMessage(50, 1, -1, -1, new List<string>
				{
					"0000000000000000000000000"
				})
			});
			treeNode4.Nodes.Add(new TreeNode("MID 0051 Vehicle ID Number subscribe")
			{
				Tag = new OpenMessage(51, 1, -1, -1, null)
			});
			treeNode4.Nodes.Add(new TreeNode("MID 0054 Vehicle ID Number unsubscrib")
			{
				Tag = new OpenMessage(54, 1, -1, -1, null)
			});
			treeView1.Nodes.Add(treeNode4);
			TreeNode treeNode5 = new TreeNode("Tightening result messages");
			treeNode5.Nodes.Add(new TreeNode("MID 0060 Last tightening result data subscribe")
			{
				Tag = new OpenMessage(60, 1, -1, -1, null)
			});
			treeNode5.Nodes.Add(new TreeNode("MID 0063 Last tightening result data unsubscribe")
			{
				Tag = new OpenMessage(63, 1, -1, -1, null)
			});
			treeNode5.Nodes.Add(new TreeNode("MID 0064 Old tightening result upload")
			{
				Tag = new OpenMessage(64, 1, -1, -1, null)
			});
			treeView1.Nodes.Add(treeNode5);
			TreeNode treeNode6 = new TreeNode("Alarm messages");
			treeNode6.Nodes.Add(new TreeNode("MID 0070 Alarm subscribe")
			{
				Tag = new OpenMessage(70, 1, -1, -1, null)
			});
			treeNode6.Nodes.Add(new TreeNode("MID 0073 Alarm unsubscribe")
			{
				Tag = new OpenMessage(73, 1, -1, -1, null)
			});
			treeNode6.Nodes.Add(new TreeNode("MID 0078 Acknowledge alarm remotely on controller")
			{
				Tag = new OpenMessage(78, 1, -1, -1, null)
			});
			treeView1.Nodes.Add(treeNode6);
			TreeNode treeNode7 = new TreeNode("Time messages");
			treeNode7.Nodes.Add(new TreeNode("MID 0080 Read time upload")
			{
				Tag = new OpenMessage(80, 1, -1, -1, null)
			});
			treeNode7.Nodes.Add(new TreeNode("MID 0082 Set Time")
			{
				Tag = new OpenMessage(82, 1, -1, -1, new List<string>
				{
					DateTime.Now.ToString("yyyy-MM-dd:HH:mm:ss")
				})
			});
			treeView1.Nodes.Add(treeNode7);
			TreeNode treeNode8 = new TreeNode("Multi-spindle status messages");
			treeNode8.Nodes.Add(new TreeNode("MID 0090 Multi-spindle status subscribe")
			{
				Tag = new OpenMessage(90, 1, -1, -1, null)
			});
			treeNode8.Nodes.Add(new TreeNode("MID 0093 Multi-spindle status unsubscribe")
			{
				Tag = new OpenMessage(93, 1, -1, -1, null)
			});
			treeView1.Nodes.Add(treeNode8);
			TreeNode treeNode9 = new TreeNode("Multi-spindle status messages");
			treeNode9.Nodes.Add(new TreeNode("MID 0100 Multi-spindle result subscribe")
			{
				Tag = new OpenMessage(100, 1, -1, -1, null)
			});
			treeNode9.Nodes.Add(new TreeNode("MID 0103 Multi spindle result unsubscribe")
			{
				Tag = new OpenMessage(103, 1, -1, -1, null)
			});
			treeView1.Nodes.Add(treeNode9);
			treeView1.ExpandAll();
			treeView1.AfterSelect += TreeView1_AfterSelect;
		}

		private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			OpenMessage openMessage = e.Node.Tag as OpenMessage;
			if (openMessage != null)
			{
				textBox_mid.Text = openMessage.MID.ToString();
				textBox_revision.Text = openMessage.Revision.ToString();
				textBox_stationID.Text = openMessage.StationID.ToString();
				textBox_spindleID.Text = openMessage.SpindleID.ToString();
				if (openMessage.DataField != null)
				{
					textBox_dataField.Lines = openMessage.DataField.ToArray();
				}
				else
				{
					textBox_dataField.Text = string.Empty;
				}
			}
		}

		private void Button_read_string_Click(object sender, EventArgs e)
		{
			try
			{
				OperateResult<string> operateResult = openProtocol.ReadCustomer(int.Parse(textBox_mid.Text), int.Parse(textBox_revision.Text), int.Parse(textBox_stationID.Text), int.Parse(textBox_spindleID.Text), new List<string>(textBox_dataField.Lines));
				if (operateResult.IsSuccess)
				{
					textBox_result.AppendText(DateTime.Now.ToString() + " : " + operateResult.Content + Environment.NewLine);
				}
				else
				{
					MessageBox.Show("Read Failed:" + operateResult.Message);
				}
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage(ex);
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
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel2 = new System.Windows.Forms.Panel();
			treeView1 = new System.Windows.Forms.TreeView();
			groupBox1 = new System.Windows.Forms.GroupBox();
			textBox_revision = new System.Windows.Forms.TextBox();
			textBox_dataField = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			textBox_spindleID = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			textBox_stationID = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			button_read_string = new System.Windows.Forms.Button();
			textBox_result = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			textBox_mid = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox_port = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox_ip = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			tabPage2 = new System.Windows.Forms.TabPage();
			panel2.SuspendLayout();
			groupBox1.SuspendLayout();
			panel1.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			SuspendLayout();
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Open Protocol";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 3;
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(tabControl1);
			panel2.Location = new System.Drawing.Point(2, 81);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(1001, 560);
			panel2.TabIndex = 5;
			treeView1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			treeView1.Location = new System.Drawing.Point(6, 6);
			treeView1.Name = "treeView1";
			treeView1.Size = new System.Drawing.Size(309, 516);
			treeView1.TabIndex = 1;
			groupBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox1.Controls.Add(textBox_revision);
			groupBox1.Controls.Add(textBox_dataField);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(textBox_spindleID);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(textBox_stationID);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(button_read_string);
			groupBox1.Controls.Add(textBox_result);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(textBox_mid);
			groupBox1.Controls.Add(label6);
			groupBox1.Location = new System.Drawing.Point(321, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(664, 522);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Single Read";
			textBox_revision.Location = new System.Drawing.Point(175, 21);
			textBox_revision.Name = "textBox_revision";
			textBox_revision.Size = new System.Drawing.Size(50, 23);
			textBox_revision.TabIndex = 18;
			textBox_revision.Text = "10";
			textBox_dataField.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_dataField.Location = new System.Drawing.Point(94, 59);
			textBox_dataField.Multiline = true;
			textBox_dataField.Name = "textBox_dataField";
			textBox_dataField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_dataField.Size = new System.Drawing.Size(564, 86);
			textBox_dataField.TabIndex = 24;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(9, 59);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(87, 34);
			label8.TabIndex = 23;
			label8.Text = "parameters：\r\n多个参数换行";
			textBox_spindleID.Location = new System.Drawing.Point(444, 21);
			textBox_spindleID.Name = "textBox_spindleID";
			textBox_spindleID.Size = new System.Drawing.Size(48, 23);
			textBox_spindleID.TabIndex = 22;
			textBox_spindleID.Text = "0";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(367, 24);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(74, 17);
			label5.TabIndex = 21;
			label5.Text = "spindleId：";
			textBox_stationID.Location = new System.Drawing.Point(313, 21);
			textBox_stationID.Name = "textBox_stationID";
			textBox_stationID.Size = new System.Drawing.Size(48, 23);
			textBox_stationID.TabIndex = 20;
			textBox_stationID.Text = "0";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(233, 24);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(71, 17);
			label4.TabIndex = 19;
			label4.Text = "stationId：";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(114, 24);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(62, 17);
			label2.TabIndex = 17;
			label2.Text = "revison：";
			button_read_string.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button_read_string.Location = new System.Drawing.Point(524, 19);
			button_read_string.Name = "button_read_string";
			button_read_string.Size = new System.Drawing.Size(134, 28);
			button_read_string.TabIndex = 16;
			button_read_string.Text = "read";
			button_read_string.UseVisualStyleBackColor = true;
			button_read_string.Click += new System.EventHandler(Button_read_string_Click);
			textBox_result.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_result.Location = new System.Drawing.Point(94, 151);
			textBox_result.Multiline = true;
			textBox_result.Name = "textBox_result";
			textBox_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_result.Size = new System.Drawing.Size(564, 365);
			textBox_result.TabIndex = 5;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(9, 156);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(55, 17);
			label7.TabIndex = 4;
			label7.Text = "Result：";
			textBox_mid.Location = new System.Drawing.Point(60, 21);
			textBox_mid.Name = "textBox_mid";
			textBox_mid.Size = new System.Drawing.Size(51, 23);
			textBox_mid.TabIndex = 3;
			textBox_mid.Text = "10";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(9, 24);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(45, 17);
			label6.TabIndex = 2;
			label6.Text = "MID：";
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox_port);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox_ip);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(2, 34);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1001, 42);
			panel1.TabIndex = 4;
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(584, 6);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "disconnect";
			button2.UseVisualStyleBackColor = true;
			button1.Location = new System.Drawing.Point(477, 6);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "connect";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1_Click);
			textBox_port.Location = new System.Drawing.Point(318, 9);
			textBox_port.Name = "textBox_port";
			textBox_port.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_port.Size = new System.Drawing.Size(72, 23);
			textBox_port.TabIndex = 3;
			textBox_port.Text = "4545";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(264, 12);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(45, 17);
			label3.TabIndex = 2;
			label3.Text = "port：";
			textBox_ip.Location = new System.Drawing.Point(62, 9);
			textBox_ip.Name = "textBox_ip";
			textBox_ip.Size = new System.Drawing.Size(196, 23);
			textBox_ip.TabIndex = 1;
			textBox_ip.Text = "192.168.0.100";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(32, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip：";
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			tabControl1.Location = new System.Drawing.Point(0, 0);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(999, 558);
			tabControl1.TabIndex = 2;
			tabPage1.Controls.Add(treeView1);
			tabPage1.Controls.Add(groupBox1);
			tabPage1.Location = new System.Drawing.Point(4, 26);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(991, 528);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Base Test";
			tabPage1.UseVisualStyleBackColor = true;
			tabPage2.Location = new System.Drawing.Point(4, 26);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3);
			tabPage2.Size = new System.Drawing.Size(991, 528);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "API Test";
			tabPage2.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			base.Controls.Add(userControlHead1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormOpenProtocol";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormOpenProtocol";
			base.Load += new System.EventHandler(FormOpenProtocol_Load);
			panel2.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
