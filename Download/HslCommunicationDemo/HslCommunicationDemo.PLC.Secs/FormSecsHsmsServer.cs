using HslCommunication;
using HslCommunication.Core.Net;
using HslCommunication.Secs;
using HslCommunication.Secs.Types;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.PLC.Secs
{
	public class FormSecsHsmsServer : HslFormContent
	{
		private SecsHsmsServer server;

		private Timer timer;

		private IContainer components = null;

		private UserControlHead userControlHead1;

		private Panel panel1;

		private Label label11;

		private Button button11;

		private Button button1;

		private TextBox textBox_port;

		private Label label3;

		private GroupBox groupBox3;

		private TextBox textBox_log;

		private GroupBox groupBox1;

		private TextBox textBox_data_back;

		private TextBox textBox_example;

		private TreeView treeView1;

		private Button button_save_tree;

		private Label label1;

		private TextBox textBox_stream;

		private TextBox textBox_function;

		private Button button25;

		private Label label12;

		private Label D;

		private ComboBox comboBox1;

		private Label label5;

		private Button button4;

		private Label label13;

		private CheckBox checkBox1;

		private SplitContainer splitContainer1;

		private Panel panel3;

		private Panel panel2;

		private ListBox listBox1;

		private Label label2;

		private Label label4;

		private Label label7;

		private Label label8;

		private Button button_device_save;

		private Button button_device_send;

		private TextBox textBox_device_f;

		private TextBox textBox_device_s;

		private TextBox textBox_device_send;

		private Label label6;

		private CheckBox checkBox_device_w;

		public FormSecsHsmsServer()
		{
			InitializeComponent();
		}

		private void FormSecsHsmsServer_Load(object sender, EventArgs e)
		{
			comboBox1.SelectedIndex = 1;
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
			StringBuilder stringBuilder = new StringBuilder("Example：");
			stringBuilder.Append(new SecsValue((sbyte)1));
			stringBuilder.Append(new SecsValue((byte)2));
			stringBuilder.Append(new SecsValue((short)3));
			stringBuilder.Append(new SecsValue((ushort)4));
			stringBuilder.Append(new SecsValue(5));
			stringBuilder.Append(new SecsValue(6u));
			stringBuilder.Append(new SecsValue(7L));
			stringBuilder.Append(new SecsValue(8uL));
			stringBuilder.Append(new SecsValue(9f));
			stringBuilder.Append(new SecsValue(10.0));
			stringBuilder.Append(new SecsValue("ABC"));
			stringBuilder.Append(new SecsValue(new byte[3]
			{
				1,
				2,
				3
			}));
			stringBuilder.Append(new SecsValue(true));
			textBox_example.Text = stringBuilder.ToString();
			TreeNode treeNode = new TreeNode("S1");
			AddTree(treeNode, new FormSecsGem.SecsTreeItem(1, 1, true, new SecsValue(new object[2]
			{
				"MDLN",
				"SOFTRev"
			}), "Are You Online"));
			AddTree(treeNode, new FormSecsGem.SecsTreeItem(1, 3, true, new SecsValue(new object[2]
			{
				1u,
				2u
			}), "Selected Equipment Status"));
			AddTree(treeNode, new FormSecsGem.SecsTreeItem(1, 5, true, new SecsValue(new object[2]
			{
				1u,
				2u
			}), "Formatted Status"));
			AddTree(treeNode, new FormSecsGem.SecsTreeItem(1, 7, false, new SecsValue(new object[1]
			{
				new object[2]
				{
					"AlarmsEnabled",
					"0"
				}
			}), "Fixed Form Request"));
			AddTree(treeNode, new FormSecsGem.SecsTreeItem(1, 9, true, new SecsValue(new object[2]
			{
				new byte[1]
				{
					1
				},
				new byte[1]
				{
					1
				}
			}), "Material Transfer Status"));
			AddTree(treeNode, new FormSecsGem.SecsTreeItem(1, 11, true, new SecsValue(new object[1]
			{
				new object[3]
				{
					"SVID",
					"SVNAME",
					"UNITS"
				}
			}), "Status Variable Namelist"));
			AddTree(treeNode, new FormSecsGem.SecsTreeItem(1, 13, true, new SecsValue(new object[2]
			{
				new byte[1]
				{
					1
				},
				new object[0]
			}), "Establish Communications", SecsValue.EmptyListValue()));
			AddTree(treeNode, new FormSecsGem.SecsTreeItem(1, 15, true, new SecsValue(new byte[1]
			{
				1
			}), "Request OFF-LINE"));
			AddTree(treeNode, new FormSecsGem.SecsTreeItem(1, 17, true, new SecsValue(new byte[1]
			{
				1
			}), "Request ON-LINE"));
			AddTree(treeNode, new FormSecsGem.SecsTreeItem(1, 19, true, new SecsValue(new object[2]
			{
				new object[1]
				{
					new object[2]
					{
						"ATTRDATA1",
						"ATTRDATA2"
					}
				},
				new object[1]
				{
					new object[2]
					{
						4u,
						"ERRTEXT"
					}
				}
			}), "Get Attribute", new SecsValue(new object[3]
			{
				"A Carrier",
				new object[1]
				{
					"Job0001"
				},
				new object[1]
				{
					"SourceURL"
				}
			})));
			AddTree(treeNode, new FormSecsGem.SecsTreeItem(1, 21, true, new SecsValue(new object[1]
			{
				new object[3]
				{
					"VID",
					"DVVALNAME",
					"Units"
				}
			}), "Data Variable Namelist"));
			AddTree(treeNode, new FormSecsGem.SecsTreeItem(1, 23, true, new SecsValue(new object[1]
			{
				new object[3]
				{
					123u,
					"ProcessStateUpdate",
					new object[1]
					{
						"810"
					}
				}
			}), "Collection Event Namelist Request"));
			treeView1.Nodes.Add(treeNode);
			TreeNode treeNode2 = new TreeNode("S2");
			AddTree(treeNode2, new FormSecsGem.SecsTreeItem(2, 1, false, new SecsValue(new byte[2]
			{
				1,
				2
			}), "Service Program Load Inquire", new SecsValue(new object[2]
			{
				"bin007",
				322u
			})));
			AddTree(treeNode2, new FormSecsGem.SecsTreeItem(2, 3, false, new SecsValue(199u), "Service Program Send", new SecsValue(new byte[3]
			{
				1,
				2,
				3
			})));
			AddTree(treeNode2, new FormSecsGem.SecsTreeItem(2, 5, false, new SecsValue(new byte[2]
			{
				1,
				2
			}), "Service Program Load Request", new SecsValue(new byte[3]
			{
				1,
				2,
				3
			})));
			AddTree(treeNode2, new FormSecsGem.SecsTreeItem(2, 7, false, new SecsValue(0u), "Service Program Run Send", new SecsValue("bin007")));
			AddTree(treeNode2, new FormSecsGem.SecsTreeItem(2, 9, false, new SecsValue("shutdown -i5 -g0 -y"), "Service Program Results Request", new SecsValue("bin007")));
			AddTree(treeNode2, new FormSecsGem.SecsTreeItem(2, 11, false, new SecsValue("bin007"), "Service Program Directory Request"));
			AddTree(treeNode2, new FormSecsGem.SecsTreeItem(2, 13, true, new SecsValue(new object[2]
			{
				"1",
				"2"
			}), "Equipment Constant Request"));
			AddTree(treeNode2, new FormSecsGem.SecsTreeItem(2, 15, true, new SecsValue(new byte[1]), "New Equipment Constant Send"));
			AddTree(treeNode2, new FormSecsGem.SecsTreeItem(2, 17, true, new SecsValue("2022121708371902"), "Date and Time Request"));
			AddTree(treeNode2, new FormSecsGem.SecsTreeItem(2, 19, true, new SecsValue((ushort)0), "Reset/Initialize Send"));
			AddTree(treeNode2, new FormSecsGem.SecsTreeItem(2, 21, true, new SecsValue(new byte[1]), "Remote Command Send"));
			AddTree(treeNode2, new FormSecsGem.SecsTreeItem(2, 23, true, new SecsValue(new byte[1]), "Trace Initialize Send"));
			AddTree(treeNode2, new FormSecsGem.SecsTreeItem(2, 25, true, new SecsValue(new byte[18]
			{
				0,
				1,
				3,
				3,
				10,
				13,
				27,
				93,
				24,
				24,
				24,
				26,
				4,
				19,
				127,
				128,
				254,
				byte.MaxValue
			}), "Trace Initialize Send", new SecsValue(new byte[18]
			{
				0,
				1,
				3,
				3,
				10,
				13,
				27,
				93,
				24,
				24,
				24,
				26,
				4,
				19,
				127,
				128,
				254,
				byte.MaxValue
			})));
			AddTree(treeNode2, new FormSecsGem.SecsTreeItem(2, 27, true, new SecsValue(new byte[1]), "Initiate Processing Request"));
			treeView1.Nodes.Add(treeNode2);
			TreeNode treeNode3 = new TreeNode("S3");
			AddTree(treeNode3, new FormSecsGem.SecsTreeItem(3, 1, true, new SecsValue(new object[2]
			{
				new byte[1],
				new object[1]
				{
					new object[3]
					{
						new byte[1],
						new byte[1]
						{
							24
						},
						"ee052793.1"
					}
				}
			}), "Material Status Request"));
			AddTree(treeNode3, new FormSecsGem.SecsTreeItem(3, 3, true, new SecsValue(new object[2]
			{
				new byte[1],
				new object[1]
				{
					new object[3]
					{
						286u,
						new byte[1]
						{
							24
						},
						"ee052793.1"
					}
				}
			}), "Time to Completion Data"));
			AddTree(treeNode3, new FormSecsGem.SecsTreeItem(3, 5, true, SecsValue.EmptySecsValue(), "Time to Completion Data", new SecsValue(new object[2]
			{
				new byte[1]
				{
					1
				},
				new byte[1]
				{
					24
				}
			})));
			AddTree(treeNode3, new FormSecsGem.SecsTreeItem(3, 7, true, SecsValue.EmptySecsValue(), "Material Lost Send", new SecsValue(new object[3]
			{
				new byte[1]
				{
					1
				},
				new byte[1]
				{
					24
				},
				"ee052793.1"
			})));
			AddTree(treeNode3, new FormSecsGem.SecsTreeItem(3, 9, true, SecsValue.EmptySecsValue(), "Matl ID Equate Send", new SecsValue(new object[2]
			{
				"ee052793.1",
				"1"
			})));
			AddTree(treeNode3, new FormSecsGem.SecsTreeItem(3, 11, true, SecsValue.EmptySecsValue(), "Matl ID Request", new SecsValue((byte)1)));
			AddTree(treeNode3, new FormSecsGem.SecsTreeItem(3, 13, true, new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			}), "Matl ID Send"));
			treeView1.Nodes.Add(treeNode3);
			TreeNode treeNode4 = new TreeNode("S4");
			AddTree(treeNode4, new FormSecsGem.SecsTreeItem(4, 1, true, new SecsValue(new byte[1]), "Ready to Send Materials", new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			})));
			AddTree(treeNode4, new FormSecsGem.SecsTreeItem(4, 3, false, SecsValue.EmptySecsValue(), "Send Material", new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			})));
			AddTree(treeNode4, new FormSecsGem.SecsTreeItem(4, 5, false, SecsValue.EmptySecsValue(), "Handshake Complete", new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			})));
			AddTree(treeNode4, new FormSecsGem.SecsTreeItem(4, 7, false, SecsValue.EmptySecsValue(), "Not Ready to Send", new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			})));
			AddTree(treeNode4, new FormSecsGem.SecsTreeItem(4, 9, false, SecsValue.EmptySecsValue(), "Stuck in Sender", new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			})));
			AddTree(treeNode4, new FormSecsGem.SecsTreeItem(4, 11, false, SecsValue.EmptySecsValue(), "Stuck in Receiver", new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			})));
			AddTree(treeNode4, new FormSecsGem.SecsTreeItem(4, 13, false, SecsValue.EmptySecsValue(), "Send Incomplete Timeout", new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			})));
			AddTree(treeNode4, new FormSecsGem.SecsTreeItem(4, 15, false, SecsValue.EmptySecsValue(), "Material Received", new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			})));
			AddTree(treeNode4, new FormSecsGem.SecsTreeItem(4, 17, true, new SecsValue(new byte[1]), "Ready to Send Materials", new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			})));
			treeView1.Nodes.Add(treeNode4);
			TreeNode treeNode5 = new TreeNode("S5");
			AddTree(treeNode5, new FormSecsGem.SecsTreeItem(5, 1, true, SecsValue.EmptySecsValue(), "Alarm Report Send", new SecsValue(new object[3]
			{
				new byte[1],
				1000u,
				"sensor timeout at load elevator"
			})));
			AddTree(treeNode5, new FormSecsGem.SecsTreeItem(5, 3, true, new SecsValue(new object[1]
			{
				(byte)0
			}), "Enable/Disable Alarm Send"));
			AddTree(treeNode5, new FormSecsGem.SecsTreeItem(5, 5, true, new SecsValue(new object[1]
			{
				new object[3]
				{
					(byte)0,
					1000u,
					"sensor timeout at load elevator"
				}
			}), "List Alarms Request"));
			AddTree(treeNode5, new FormSecsGem.SecsTreeItem(5, 7, true, new SecsValue(new object[1]
			{
				new object[3]
				{
					(byte)0,
					1000u,
					"sensor timeout at load elevator"
				}
			}), "List Enabled Alarm Request"));
			AddTree(treeNode5, new FormSecsGem.SecsTreeItem(5, 9, true, SecsValue.EmptySecsValue(), "Exception Post Notify", new SecsValue(new object[5]
			{
				DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss").Replace("-", ""),
				"out of ink",
				"ALARM",
				"ink not sensed at nozzle inlet",
				new object[1]
				{
					"manually insert new ink cartridge"
				}
			})));
			AddTree(treeNode5, new FormSecsGem.SecsTreeItem(5, 11, true, SecsValue.EmptySecsValue(), "Exception Clear Notify", new SecsValue(new object[4]
			{
				DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss").Replace("-", ""),
				"out of ink",
				"ALARM",
				"ink not sensed at nozzle inlet"
			})));
			treeView1.Nodes.Add(treeNode5);
			TreeNode treeNode6 = new TreeNode("S6");
			AddTree(treeNode6, new FormSecsGem.SecsTreeItem(6, 1, true, SecsValue.EmptySecsValue(), "Trace Data Send", new SecsValue(new object[4]
			{
				"1",
				10u,
				DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss").Replace("-", ""),
				new object[1]
				{
					(byte)65
				}
			})));
			AddTree(treeNode6, new FormSecsGem.SecsTreeItem(6, 3, true, SecsValue.EmptySecsValue(), "Discrete Variable Data Send", new SecsValue(new object[3]
			{
				1u,
				4050u,
				new object[1]
				{
					new object[2]
					{
						"12",
						new object[1]
						{
							new object[2]
							{
								10u,
								"54"
							}
						}
					}
				}
			})));
			AddTree(treeNode6, new FormSecsGem.SecsTreeItem(6, 5, true, SecsValue.EmptySecsValue(), "Multi-block Data Send Inquire", new SecsValue(new object[2]
			{
				1u,
				649u
			})));
			AddTree(treeNode6, new FormSecsGem.SecsTreeItem(6, 7, true, new SecsValue(new object[3]
			{
				1u,
				4050u,
				new object[2]
				{
					"12",
					new object[1]
					{
						new object[2]
						{
							10u,
							"54"
						}
					}
				}
			}), "Data Transfer Request"));
			AddTree(treeNode6, new FormSecsGem.SecsTreeItem(6, 9, true, SecsValue.EmptySecsValue(), "Formatted Variable Send", new SecsValue(new object[4]
			{
				new byte[1]
				{
					2
				},
				1u,
				4050u,
				new object[1]
				{
					new object[2]
					{
						"12",
						new object[1]
						{
							"54"
						}
					}
				}
			})));
			AddTree(treeNode6, new FormSecsGem.SecsTreeItem(6, 11, true, SecsValue.EmptySecsValue(), "Event Report Send", new SecsValue(new object[3]
			{
				1u,
				4050u,
				new object[1]
				{
					new object[2]
					{
						1u,
						new object[1]
						{
							"0"
						}
					}
				}
			})));
			AddTree(treeNode6, new FormSecsGem.SecsTreeItem(6, 13, true, SecsValue.EmptySecsValue(), "Annotated Event Report Send", new SecsValue(new object[3]
			{
				1u,
				4050u,
				new object[1]
				{
					new object[2]
					{
						1u,
						new object[1]
						{
							new object[2]
							{
								"810",
								"0"
							}
						}
					}
				}
			})));
			AddTree(treeNode6, new FormSecsGem.SecsTreeItem(6, 15, true, new SecsValue(new object[3]
			{
				1u,
				4050u,
				new object[1]
				{
					new object[2]
					{
						1u,
						new object[1]
						{
							"0"
						}
					}
				}
			}), "Event Report Request"));
			treeView1.Nodes.Add(treeNode6);
			treeView1.AfterSelect += TreeView1_AfterSelect;
			timer = new Timer();
			timer.Tick += Timer_Tick;
			timer.Start();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if (server != null)
			{
				listBox1.DataSource = server.GetOnlineSessions;
			}
		}

		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (server != null)
			{
				switch (comboBox1.SelectedIndex)
				{
				case 0:
					server.StringEncoding = Encoding.ASCII;
					break;
				case 1:
					server.StringEncoding = Encoding.Default;
					break;
				case 2:
					server.StringEncoding = Encoding.UTF8;
					break;
				case 3:
					server.StringEncoding = Encoding.Unicode;
					break;
				case 4:
					server.StringEncoding = Encoding.GetEncoding("gb2312");
					break;
				}
			}
		}

		private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			FormSecsGem.SecsTreeItem secsTreeItem = e.Node.Tag as FormSecsGem.SecsTreeItem;
			if (secsTreeItem != null)
			{
				textBox_stream.Text = secsTreeItem.S.ToString();
				textBox_function.Text = (secsTreeItem.F + 1).ToString();
				textBox_device_s.Text = secsTreeItem.S.ToString();
				textBox_device_f.Text = secsTreeItem.F.ToString();
				if (secsTreeItem.Value != null)
				{
					textBox_data_back.Text = secsTreeItem.Value.ToXElement().ToString();
				}
				else
				{
					textBox_data_back.Text = string.Empty;
				}
				if (secsTreeItem.ValueSingular != null)
				{
					textBox_device_send.Text = secsTreeItem.ValueSingular.ToXElement().ToString();
				}
				else
				{
					textBox_device_send.Text = string.Empty;
				}
			}
		}

		public void AddTree(TreeNode treeNode, FormSecsGem.SecsTreeItem treeItem)
		{
			TreeNode treeNode2 = new TreeNode(string.Format("S{0}F{1}{2} {3}", treeItem.S, treeItem.F, treeItem.W ? "W" : "", treeItem.Description));
			treeNode2.Tag = treeItem;
			treeNode.Nodes.Add(treeNode2);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				server = new SecsHsmsServer();
				server.OnSecsMessageReceived += Server_OnSecsMessageReceived;
				server.ServerStart(int.Parse(textBox_port.Text));
				ComboBox1_SelectedIndexChanged(comboBox1, e);
				button1.Enabled = false;
				button11.Enabled = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Start failed: " + ex.Message);
			}
		}

		private void Server_OnSecsMessageReceived(object sender, AppSession session, SecsMessage message)
		{
			SecsMessage secsMessage = null;
			foreach (TreeNode node in treeView1.Nodes)
			{
				foreach (TreeNode node2 in node.Nodes)
				{
					FormSecsGem.SecsTreeItem secsTreeItem = node2.Tag as FormSecsGem.SecsTreeItem;
					if (secsTreeItem != null && secsTreeItem.S == message.StreamNo && secsTreeItem.F == message.FunctionNo)
					{
						server.SendByCommand(session, message, message.StreamNo, (byte)(message.FunctionNo + 1), secsTreeItem.Value);
						secsMessage = new SecsMessage();
						secsMessage.StringEncoding = server.StringEncoding;
						secsMessage.StreamNo = message.StreamNo;
						secsMessage.FunctionNo = (byte)(message.FunctionNo + 1);
						secsMessage.Data = ((secsTreeItem.Value == null) ? new byte[0] : secsTreeItem.Value.ToSourceBytes(server.StringEncoding));
						break;
					}
				}
			}
			if (!checkBox1.Checked)
			{
				Invoke((Action)delegate
				{
					textBox_log.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Receive Data：" + message.ToString() + Environment.NewLine);
					if (secsMessage != null)
					{
						textBox_log.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Send Back Data：" + secsMessage.ToString() + Environment.NewLine);
					}
				});
			}
		}

		private void button_save_tree_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeView1.SelectedNode;
			if (selectedNode != null)
			{
				FormSecsGem.SecsTreeItem secsTreeItem = selectedNode.Tag as FormSecsGem.SecsTreeItem;
				if (secsTreeItem != null)
				{
					secsTreeItem.Value = new SecsValue(XElement.Parse(textBox_data_back.Text));
					MessageBox.Show("保存成功！");
				}
			}
		}

		private void button25_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = server.PublishSecsMessage(byte.Parse(textBox_stream.Text), byte.Parse(textBox_function.Text), string.IsNullOrEmpty(textBox_data_back.Text) ? null : new SecsValue(XElement.Parse(textBox_data_back.Text)));
			if (operateResult.IsSuccess)
			{
				textBox_log.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Send Data：S" + textBox_stream.Text + "F" + textBox_function.Text + Environment.NewLine + textBox_data_back.Text + Environment.NewLine);
			}
			else
			{
				MessageBox.Show("Failed: " + operateResult.Message);
			}
		}

		private void button_device_send_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = server.PublishSecsMessage(byte.Parse(textBox_device_s.Text), byte.Parse(textBox_device_f.Text), string.IsNullOrEmpty(textBox_device_send.Text) ? null : new SecsValue(XElement.Parse(textBox_device_send.Text)));
			if (operateResult.IsSuccess)
			{
				textBox_log.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " Send Data：S" + textBox_device_s.Text + "F" + textBox_device_f.Text + Environment.NewLine + textBox_device_send.Text + Environment.NewLine);
			}
			else
			{
				MessageBox.Show("Failed: " + operateResult.Message);
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			server.ServerClose();
			button1.Enabled = true;
			button11.Enabled = false;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			textBox_log.Clear();
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
			panel1 = new System.Windows.Forms.Panel();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label5 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			button11 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox_port = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			listBox1 = new System.Windows.Forms.ListBox();
			label2 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			button4 = new System.Windows.Forms.Button();
			textBox_log = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			checkBox1 = new System.Windows.Forms.CheckBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			panel3 = new System.Windows.Forms.Panel();
			checkBox_device_w = new System.Windows.Forms.CheckBox();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			button_device_save = new System.Windows.Forms.Button();
			button_device_send = new System.Windows.Forms.Button();
			textBox_device_f = new System.Windows.Forms.TextBox();
			textBox_device_s = new System.Windows.Forms.TextBox();
			textBox_device_send = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			textBox_data_back = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			D = new System.Windows.Forms.Label();
			button_save_tree = new System.Windows.Forms.Button();
			button25 = new System.Windows.Forms.Button();
			textBox_function = new System.Windows.Forms.TextBox();
			textBox_stream = new System.Windows.Forms.TextBox();
			textBox_example = new System.Windows.Forms.TextBox();
			treeView1 = new System.Windows.Forms.TreeView();
			panel1.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			panel3.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/8974215.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Secs gem HSMS Server";
			userControlHead1.Size = new System.Drawing.Size(1005, 32);
			userControlHead1.TabIndex = 3;
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(label11);
			panel1.Controls.Add(button11);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox_port);
			panel1.Controls.Add(label3);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(999, 41);
			panel1.TabIndex = 4;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[5]
			{
				"ASCII",
				"Default",
				"UTF8",
				"Unicode",
				"GB2312"
			});
			comboBox1.Location = new System.Drawing.Point(399, 6);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(104, 25);
			comboBox1.TabIndex = 31;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(331, 11);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(63, 17);
			label5.TabIndex = 30;
			label5.Text = "Encode：";
			label11.ForeColor = System.Drawing.Color.FromArgb(192, 0, 192);
			label11.Location = new System.Drawing.Point(512, 3);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(467, 35);
			label11.TabIndex = 29;
			label11.Text = "本服务器不是严格的secs协议，仅支持和HSL组件完美通信。";
			button11.Enabled = false;
			button11.Location = new System.Drawing.Point(235, 5);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(83, 28);
			button11.TabIndex = 28;
			button11.Text = "关闭服务";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			button1.Location = new System.Drawing.Point(145, 5);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(83, 28);
			button1.TabIndex = 4;
			button1.Text = "启动服务";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox_port.Location = new System.Drawing.Point(74, 8);
			textBox_port.Name = "textBox_port";
			textBox_port.Size = new System.Drawing.Size(65, 23);
			textBox_port.TabIndex = 3;
			textBox_port.Text = "5000";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(10, 11);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			groupBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox3.Controls.Add(listBox1);
			groupBox3.Controls.Add(label2);
			groupBox3.Controls.Add(label4);
			groupBox3.Controls.Add(button4);
			groupBox3.Controls.Add(textBox_log);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(checkBox1);
			groupBox3.Location = new System.Drawing.Point(3, 439);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(999, 173);
			groupBox3.TabIndex = 5;
			groupBox3.TabStop = false;
			groupBox3.Text = "日志";
			listBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			listBox1.BackColor = System.Drawing.Color.LightGray;
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 17;
			listBox1.Location = new System.Drawing.Point(726, 39);
			listBox1.Name = "listBox1";
			listBox1.Size = new System.Drawing.Size(269, 123);
			listBox1.TabIndex = 34;
			label2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(726, 16);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(93, 17);
			label2.TabIndex = 33;
			label2.Text = "Online Client：";
			label4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(909, 16);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(86, 17);
			label4.TabIndex = 32;
			label4.Text = "Online Count:";
			button4.Location = new System.Drawing.Point(6, 70);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(55, 26);
			button4.TabIndex = 19;
			button4.Text = "clear";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			textBox_log.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_log.Location = new System.Drawing.Point(70, 17);
			textBox_log.Multiline = true;
			textBox_log.Name = "textBox_log";
			textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_log.Size = new System.Drawing.Size(650, 150);
			textBox_log.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(11, 20);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 17;
			label13.Text = "接收：";
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(9, 42);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(58, 21);
			checkBox1.TabIndex = 18;
			checkBox1.Text = "STOP";
			checkBox1.UseVisualStyleBackColor = true;
			groupBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox1.Controls.Add(splitContainer1);
			groupBox1.Controls.Add(textBox_example);
			groupBox1.Controls.Add(treeView1);
			groupBox1.Location = new System.Drawing.Point(3, 79);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(999, 354);
			groupBox1.TabIndex = 6;
			groupBox1.TabStop = false;
			groupBox1.Text = "数据定义区";
			splitContainer1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			splitContainer1.Location = new System.Drawing.Point(324, 19);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Panel1.Controls.Add(panel3);
			splitContainer1.Panel2.Controls.Add(panel2);
			splitContainer1.Size = new System.Drawing.Size(669, 280);
			splitContainer1.SplitterDistance = 314;
			splitContainer1.TabIndex = 39;
			panel3.Controls.Add(checkBox_device_w);
			panel3.Controls.Add(label7);
			panel3.Controls.Add(label8);
			panel3.Controls.Add(button_device_save);
			panel3.Controls.Add(button_device_send);
			panel3.Controls.Add(textBox_device_f);
			panel3.Controls.Add(textBox_device_s);
			panel3.Controls.Add(textBox_device_send);
			panel3.Controls.Add(label6);
			panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			panel3.Location = new System.Drawing.Point(0, 0);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(314, 280);
			panel3.TabIndex = 1;
			checkBox_device_w.AutoSize = true;
			checkBox_device_w.Location = new System.Drawing.Point(140, 8);
			checkBox_device_w.Name = "checkBox_device_w";
			checkBox_device_w.Size = new System.Drawing.Size(45, 21);
			checkBox_device_w.TabIndex = 47;
			checkBox_device_w.Text = "W?";
			checkBox_device_w.UseVisualStyleBackColor = true;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(8, 9);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(27, 17);
			label7.TabIndex = 41;
			label7.Text = "S：";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(70, 9);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(26, 17);
			label8.TabIndex = 43;
			label8.Text = "F：";
			button_device_save.Location = new System.Drawing.Point(206, 4);
			button_device_save.Name = "button_device_save";
			button_device_save.Size = new System.Drawing.Size(49, 28);
			button_device_save.TabIndex = 46;
			button_device_save.Text = "保存";
			button_device_save.UseVisualStyleBackColor = true;
			button_device_send.Location = new System.Drawing.Point(261, 4);
			button_device_send.Name = "button_device_send";
			button_device_send.Size = new System.Drawing.Size(46, 28);
			button_device_send.TabIndex = 45;
			button_device_send.Text = "广播";
			button_device_send.UseVisualStyleBackColor = true;
			button_device_send.Click += new System.EventHandler(button_device_send_Click);
			textBox_device_f.Location = new System.Drawing.Point(102, 6);
			textBox_device_f.Name = "textBox_device_f";
			textBox_device_f.Size = new System.Drawing.Size(32, 23);
			textBox_device_f.TabIndex = 44;
			textBox_device_f.Text = "1";
			textBox_device_s.Location = new System.Drawing.Point(33, 6);
			textBox_device_s.Name = "textBox_device_s";
			textBox_device_s.Size = new System.Drawing.Size(32, 23);
			textBox_device_s.TabIndex = 42;
			textBox_device_s.Text = "1";
			textBox_device_send.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_device_send.Location = new System.Drawing.Point(9, 51);
			textBox_device_send.Multiline = true;
			textBox_device_send.Name = "textBox_device_send";
			textBox_device_send.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_device_send.Size = new System.Drawing.Size(302, 225);
			textBox_device_send.TabIndex = 40;
			label6.AutoSize = true;
			label6.ForeColor = System.Drawing.Color.Gray;
			label6.Location = new System.Drawing.Point(8, 31);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(127, 17);
			label6.TabIndex = 39;
			label6.Text = "Data(用于主动发送)：";
			panel2.Controls.Add(textBox_data_back);
			panel2.Controls.Add(label1);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(D);
			panel2.Controls.Add(button_save_tree);
			panel2.Controls.Add(button25);
			panel2.Controls.Add(textBox_function);
			panel2.Controls.Add(textBox_stream);
			panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			panel2.Location = new System.Drawing.Point(0, 0);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(351, 280);
			panel2.TabIndex = 0;
			textBox_data_back.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_data_back.Location = new System.Drawing.Point(4, 51);
			textBox_data_back.Multiline = true;
			textBox_data_back.Name = "textBox_data_back";
			textBox_data_back.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_data_back.Size = new System.Drawing.Size(341, 225);
			textBox_data_back.TabIndex = 38;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(3, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(61, 17);
			label1.TabIndex = 27;
			label1.Text = "Stream：";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(100, 8);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(68, 17);
			label12.TabIndex = 29;
			label12.Text = "Function：";
			D.AutoSize = true;
			D.ForeColor = System.Drawing.Color.Gray;
			D.Location = new System.Drawing.Point(3, 31);
			D.Name = "D";
			D.Size = new System.Drawing.Size(103, 17);
			D.TabIndex = 33;
			D.Text = "Data(用于应答)：";
			button_save_tree.Location = new System.Drawing.Point(206, 3);
			button_save_tree.Name = "button_save_tree";
			button_save_tree.Size = new System.Drawing.Size(73, 28);
			button_save_tree.TabIndex = 35;
			button_save_tree.Text = "保存应答";
			button_save_tree.UseVisualStyleBackColor = true;
			button_save_tree.Click += new System.EventHandler(button_save_tree_Click);
			button25.Location = new System.Drawing.Point(284, 3);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(61, 28);
			button25.TabIndex = 31;
			button25.Text = "广播";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			textBox_function.Location = new System.Drawing.Point(166, 5);
			textBox_function.Name = "textBox_function";
			textBox_function.Size = new System.Drawing.Size(32, 23);
			textBox_function.TabIndex = 30;
			textBox_function.Text = "1";
			textBox_stream.Location = new System.Drawing.Point(65, 5);
			textBox_stream.Name = "textBox_stream";
			textBox_stream.Size = new System.Drawing.Size(32, 23);
			textBox_stream.TabIndex = 28;
			textBox_stream.Text = "1";
			textBox_example.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_example.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox_example.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox_example.ForeColor = System.Drawing.Color.Green;
			textBox_example.Location = new System.Drawing.Point(13, 301);
			textBox_example.Multiline = true;
			textBox_example.Name = "textBox_example";
			textBox_example.ReadOnly = true;
			textBox_example.Size = new System.Drawing.Size(980, 47);
			textBox_example.TabIndex = 37;
			textBox_example.Text = "Example:";
			treeView1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			treeView1.Location = new System.Drawing.Point(7, 19);
			treeView1.Name = "treeView1";
			treeView1.Size = new System.Drawing.Size(311, 280);
			treeView1.TabIndex = 36;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1005, 616);
			base.Controls.Add(groupBox1);
			base.Controls.Add(groupBox3);
			base.Controls.Add(panel1);
			base.Controls.Add(userControlHead1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "FormSecsHsmsServer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormSecsHsmsServer";
			base.Load += new System.EventHandler(FormSecsHsmsServer_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
	}
}
