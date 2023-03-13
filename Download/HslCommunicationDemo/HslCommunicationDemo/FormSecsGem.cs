using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.LogNet;
using HslCommunication.Secs;
using HslCommunication.Secs.Types;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormSecsGem : HslFormContent
	{
		public class SecsTreeItem
		{
			public byte S
			{
				get;
				set;
			}

			public byte F
			{
				get;
				set;
			}

			public bool W
			{
				get;
				set;
			}

			public SecsValue Value
			{
				get;
				set;
			}

			public string Description
			{
				get;
				set;
			}

			public SecsValue ValueSingular
			{
				get;
				set;
			}

			public SecsTreeItem(byte s, byte f, bool w, SecsValue value, string decs, SecsValue singular = null)
			{
				S = s;
				F = f;
				W = w;
				Value = value;
				Description = decs;
				ValueSingular = singular;
			}
		}

		private SecsHsms secs = null;

		private IContainer components = null;

		private Panel panel1;

		private Panel panel2;

		private Button button2;

		private Button button1;

		private GroupBox groupBox3;

		private TextBox textBox_log;

		private Label label13;

		private Button button25;

		private TextBox textBox_function;

		private Label label12;

		private TextBox textBox_stream;

		private Label label11;

		private TextBox textBox_deviceID;

		private Label label21;

		private UserControlHead userControlHead1;

		private TextBox textBox_port;

		private Label label3;

		private TextBox textBox_ip;

		private Label label1;

		private TextBox textBox_receive;

		private Label label2;

		private CheckBox checkBox1;

		private TextBox textBox_data;

		private Label D;

		private CheckBox checkBox_back;

		private Button button3;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private Button button_S1F1;

		private TextBox textBox_s1;

		private Button button_s1f11;

		private TextBox textBox4;

		private Label label4;

		private Button button_s1f13;

		private Button button_s1f15;

		private Button button_s1f17;

		private TabPage tabPage_s2;

		private Panel panel3;

		private TextBox textBox_s2;

		private Button button_s2f13;

		private TreeView treeView1;

		private TextBox textBox_example;

		private SplitContainer splitContainer1;

		private SplitContainer splitContainer2;

		private CheckBox checkBox2;

		private ComboBox comboBox1;

		private Label label5;

		private Button button4;

		public FormSecsGem()
		{
			InitializeComponent();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			comboBox1.SelectedIndex = 1;
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
			Language(Program.Language);
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
			AddTree(treeNode, new SecsTreeItem(1, 1, true, null, "Are You Online"));
			AddTree(treeNode, new SecsTreeItem(1, 3, true, new SecsValue(new object[2]
			{
				1u,
				2u
			}), "Selected Equipment Status"));
			AddTree(treeNode, new SecsTreeItem(1, 5, true, new SecsValue(new byte[1]
			{
				1
			}), "Formatted Status"));
			AddTree(treeNode, new SecsTreeItem(1, 7, false, new SecsValue(new byte[1]
			{
				1
			}), "Fixed Form Request"));
			AddTree(treeNode, new SecsTreeItem(1, 9, true, null, "Material Transfer Status"));
			AddTree(treeNode, new SecsTreeItem(1, 11, true, new SecsValue(new object[2]
			{
				1u,
				2u
			}), "Status Variable Namelist"));
			AddTree(treeNode, new SecsTreeItem(1, 13, true, new SecsValue(new object[2]
			{
				new byte[1]
				{
					1
				},
				new object[0]
			}), "Establish Communications"));
			AddTree(treeNode, new SecsTreeItem(1, 15, true, null, "Request OFF-LINE"));
			AddTree(treeNode, new SecsTreeItem(1, 17, true, null, "Request ON-LINE"));
			AddTree(treeNode, new SecsTreeItem(1, 19, true, new SecsValue(new object[3]
			{
				"object class name",
				new object[2]
				{
					"Job0001",
					"Job0002"
				},
				new object[2]
				{
					"attribute1",
					"attribute2"
				}
			}), "Get Attribute"));
			AddTree(treeNode, new SecsTreeItem(1, 21, true, new SecsValue(new object[2]
			{
				"Variable ID1",
				"Variable ID2"
			}), "Data Variable Namelist"));
			AddTree(treeNode, new SecsTreeItem(1, 23, true, new SecsValue(new object[2]
			{
				1u,
				2u
			}), "Collection Event Namelist"));
			treeView1.Nodes.Add(treeNode);
			TreeNode treeNode2 = new TreeNode("S2");
			AddTree(treeNode2, new SecsTreeItem(2, 1, false, new SecsValue(new byte[3]
			{
				1,
				2,
				3
			}), "Service Program Load Grant"));
			AddTree(treeNode2, new SecsTreeItem(2, 3, false, new SecsValue(new byte[3]
			{
				1,
				2,
				3
			}), "Service Program Send"));
			AddTree(treeNode2, new SecsTreeItem(2, 5, false, new SecsValue("bin00"), "Service Program Load"));
			AddTree(treeNode2, new SecsTreeItem(2, 7, false, new SecsValue("bin00"), "Service Program Run Send"));
			AddTree(treeNode2, new SecsTreeItem(2, 9, false, new SecsValue("bin00"), "Service Program Results"));
			AddTree(treeNode2, new SecsTreeItem(2, 11, false, null, "Service Program Directory"));
			AddTree(treeNode2, new SecsTreeItem(2, 13, true, new SecsValue(new object[2]
			{
				1u,
				2u
			}), "Equipment Constant"));
			AddTree(treeNode2, new SecsTreeItem(2, 15, true, new SecsValue(new object[2]
			{
				new object[2]
				{
					1u,
					"1"
				},
				new object[2]
				{
					2u,
					"2"
				}
			}), "New Equipment Constant Send"));
			AddTree(treeNode2, new SecsTreeItem(2, 17, true, null, "Date and Time"));
			AddTree(treeNode2, new SecsTreeItem(2, 19, true, new SecsValue((byte)1), "Reset/Initialize Send"));
			AddTree(treeNode2, new SecsTreeItem(2, 21, true, new SecsValue("pause"), "Remote Command Send"));
			AddTree(treeNode2, new SecsTreeItem(2, 23, true, new SecsValue(new object[5]
			{
				"TRID",
				"000500",
				4u,
				5u,
				new object[2]
				{
					1u,
					2u
				}
			}), "Trace Initialize Send"));
			AddTree(treeNode2, new SecsTreeItem(2, 25, true, new SecsValue("00 01 03 03 0a 0d 1b 5d 18 18 1a 04 13 7f 80 fe ff".ToHexBytes()), "Loopback Diagnostic"));
			AddTree(treeNode2, new SecsTreeItem(2, 27, true, new SecsValue(new object[3]
			{
				new byte[1]
				{
					1
				},
				"banana",
				new object[1]
				{
					"ee052793.1"
				}
			}), "Initiate Processing Request"));
			AddTree(treeNode2, new SecsTreeItem(2, 29, true, new SecsValue(new object[1]
			{
				220u
			}), "Equipment Constant Namelist"));
			AddTree(treeNode2, new SecsTreeItem(2, 31, true, new SecsValue(DateTime.Now.ToString("yyyyMMddHHmmss")), "Date and Time Set"));
			AddTree(treeNode2, new SecsTreeItem(2, 33, true, new SecsValue(new object[2]
			{
				1u,
				new object[1]
				{
					new object[2]
					{
						4u,
						new object[1]
						{
							"810"
						}
					}
				}
			}), "Define Report"));
			AddTree(treeNode2, new SecsTreeItem(2, 35, true, new SecsValue(new object[2]
			{
				1u,
				new object[1]
				{
					new object[2]
					{
						4050u,
						new object[1]
						{
							1u
						}
					}
				}
			}), "Link Event Report"));
			AddTree(treeNode2, new SecsTreeItem(2, 37, true, new SecsValue(new object[2]
			{
				1u,
				new object[1]
				{
					new object[2]
					{
						4050u,
						new object[1]
						{
							1u
						}
					}
				}
			}), "Enable/Disable Event Report"));
			AddTree(treeNode2, new SecsTreeItem(2, 39, true, new SecsValue(new object[2]
			{
				1u,
				649u
			}), "Multi-block Inquire"));
			AddTree(treeNode2, new SecsTreeItem(2, 41, true, new SecsValue(new object[2]
			{
				"pause",
				new object[1]
				{
					new object[2]
					{
						"ppexecname",
						"cmos168-zl0EC"
					}
				}
			}), "Host Command Send"));
			treeView1.Nodes.Add(treeNode2);
			TreeNode treeNode3 = new TreeNode("S3");
			AddTree(treeNode3, new SecsTreeItem(3, 1, true, null, "Material Status"));
			AddTree(treeNode3, new SecsTreeItem(3, 3, true, null, "Time to Completion Data"));
			AddTree(treeNode3, new SecsTreeItem(3, 5, true, new SecsValue(new object[2]
			{
				new byte[1]
				{
					1
				},
				new byte[1]
				{
					24
				}
			}), "Material Found Send"));
			AddTree(treeNode3, new SecsTreeItem(3, 7, true, new SecsValue(new object[3]
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
			}), "Material Lost Send"));
			AddTree(treeNode3, new SecsTreeItem(3, 9, true, new SecsValue(new object[2]
			{
				"ee052793.1",
				"1"
			}), "Matl ID Equate Send"));
			AddTree(treeNode3, new SecsTreeItem(3, 11, true, new SecsValue((byte)1), "Matl ID Request"));
			AddTree(treeNode3, new SecsTreeItem(3, 13, true, new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			}), "Matl ID Send"));
			AddTree(treeNode3, new SecsTreeItem(3, 17, true, new SecsValue(new object[5]
			{
				1u,
				"ProceedWithCarrier",
				"CSX 52078",
				(byte)1,
				new object[1]
				{
					new object[2]
					{
						"Usage",
						"product"
					}
				}
			}), "Carrier Action Request"));
			AddTree(treeNode3, new SecsTreeItem(3, 19, true, null, "Cancel All Carrier Out Req"));
			AddTree(treeNode3, new SecsTreeItem(3, 21, true, new SecsValue(new object[3]
			{
				"buffer1",
				(byte)1,
				new object[1]
				{
					(byte)1
				}
			}), "Port Group Defn"));
			AddTree(treeNode3, new SecsTreeItem(3, 23, true, new SecsValue(new object[3]
			{
				"CancelReservationAtPort",
				"buffer1",
				new object[2]
				{
					"ServiceStatus",
					(byte)1
				}
			}), "Port Group Action Req"));
			AddTree(treeNode3, new SecsTreeItem(3, 25, true, new SecsValue(new object[3]
			{
				" ChangeServiceStatus",
				(byte)1,
				new object[1]
				{
					new object[2]
					{
						"ServiceStatus",
						(byte)1
					}
				}
			}), "Port Action Req"));
			AddTree(treeNode3, new SecsTreeItem(3, 27, true, new SecsValue(new object[2]
			{
				(byte)0,
				new object[1]
				{
					(byte)1
				}
			}), "Change Access"));
			AddTree(treeNode3, new SecsTreeItem(3, 29, true, new SecsValue(new object[4]
			{
				"logical ID",
				"Carrier:CSX 52078",
				"S01",
				649u
			}), "Carrier Tag Read Req"));
			AddTree(treeNode3, new SecsTreeItem(3, 31, true, new SecsValue(new object[5]
			{
				"logical ID",
				"Carrier:CSX 52078",
				"S01",
				649u,
				"unformatted data"
			}), "Carrier Tag Write Data"));
			AddTree(treeNode3, new SecsTreeItem(3, 33, true, null, "Cancel All Pod Out Req"));
			treeView1.Nodes.Add(treeNode3);
			TreeNode treeNode4 = new TreeNode("S4");
			AddTree(treeNode4, new SecsTreeItem(4, 1, true, new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			}), "Ready to Send Materials"));
			AddTree(treeNode4, new SecsTreeItem(4, 3, false, new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			}), "Send Material"));
			AddTree(treeNode4, new SecsTreeItem(4, 5, false, new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			}), "Handshake Complete"));
			AddTree(treeNode4, new SecsTreeItem(4, 9, false, new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			}), "Stuck in Sender"));
			AddTree(treeNode4, new SecsTreeItem(4, 11, false, new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			}), "Stuck in Receiver"));
			AddTree(treeNode4, new SecsTreeItem(4, 13, false, new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			}), "Send Incomplete Timeout"));
			AddTree(treeNode4, new SecsTreeItem(4, 15, false, new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			}), "Material Received"));
			AddTree(treeNode4, new SecsTreeItem(4, 17, true, new SecsValue(new object[2]
			{
				(byte)1,
				"ee052793.1"
			}), "Request to Receive"));
			AddTree(treeNode4, new SecsTreeItem(4, 19, true, new SecsValue(new object[2]
			{
				1u,
				new object[2]
				{
					"TJH_U_M_E1086",
					new object[12]
					{
						3u,
						1u,
						"c000678",
						7u,
						(byte)1,
						"standard exchange",
						"AGV0001",
						1u,
						(byte)1,
						(byte)1,
						1u,
						"TF:1 0"
					}
				}
			}), "Transfer Job Create"));
			AddTree(treeNode4, new SecsTreeItem(4, 21, true, new SecsValue(new object[3]
			{
				new byte[1]
				{
					96
				},
				"PAUSE",
				new object[1]
				{
					new object[2]
					{
						"ppexecname",
						"cmos168-zl0EC3"
					}
				}
			}), "Transfer Job Command"));
			treeView1.Nodes.Add(treeNode4);
			TreeNode treeNode5 = new TreeNode("S5");
			AddTree(treeNode5, new SecsTreeItem(5, 3, true, new SecsValue(new object[2]
			{
				new byte[1],
				1000u
			}), "Enable/Disable Alarm Send"));
			AddTree(treeNode5, new SecsTreeItem(5, 5, true, new SecsValue(0u), "List Alarms Request"));
			AddTree(treeNode5, new SecsTreeItem(5, 7, true, null, "List Enabled Alarm Request"));
			AddTree(treeNode5, new SecsTreeItem(5, 9, true, new SecsValue(new object[5]
			{
				"YYMMDDHHMMSS",
				"out of ink",
				"ALARM",
				"ink not sensed at nozzle inlet",
				new object[1]
				{
					"manually insert new ink cartridge"
				}
			}), "Exception Post Notify"));
			AddTree(treeNode5, new SecsTreeItem(5, 11, true, new SecsValue(new object[4]
			{
				"YYMMDDHHMMSS",
				"out of ink",
				"ALARM",
				"ink not sensed at nozzle inlet"
			}), "Exception Clear Notify"));
			AddTree(treeNode5, new SecsTreeItem(5, 13, true, new SecsValue(new object[2]
			{
				"out of ink",
				"manually insert new ink cartridge"
			}), "Exception Recover Request"));
			AddTree(treeNode5, new SecsTreeItem(5, 17, true, new SecsValue("out of ink"), "Exception Recovery Abort Request"));
			treeView1.Nodes.Add(treeNode5);
			TreeNode treeNode6 = new TreeNode("S6");
			AddTree(treeNode6, new SecsTreeItem(6, 1, true, new SecsValue(new object[4]
			{
				"1",
				10u,
				"YYMMDDHHMMSS",
				new object[1]
				{
					(byte)65
				}
			}), "Trace Data Send"));
			AddTree(treeNode6, new SecsTreeItem(6, 3, true, new SecsValue(new object[3]
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
			}), "Discrete Variable Data Send"));
			AddTree(treeNode6, new SecsTreeItem(6, 5, true, new SecsValue(new object[2]
			{
				1u,
				649u
			}), "Multi-block Data Send Inquire"));
			AddTree(treeNode6, new SecsTreeItem(6, 7, true, new SecsValue(1u), "Data Transfer Request"));
			AddTree(treeNode6, new SecsTreeItem(6, 9, true, new SecsValue(new object[4]
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
			}), "Formatted Variable Send"));
			treeView1.Nodes.Add(treeNode6);
			TreeNode treeNode7 = new TreeNode("S7");
			AddTree(treeNode7, new SecsTreeItem(7, 1, true, new SecsValue(new object[2]
			{
				"banana",
				322u
			}), "Process Program Load Inquire"));
			AddTree(treeNode7, new SecsTreeItem(7, 3, true, new SecsValue(new object[2]
			{
				"banana",
				new byte[1]
			}), "Process Program Send\t"));
			treeView1.AfterSelect += TreeView1_AfterSelect;
		}

		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (secs != null)
			{
				switch (comboBox1.SelectedIndex)
				{
				case 0:
					secs.StringEncoding = Encoding.ASCII;
					break;
				case 1:
					secs.StringEncoding = Encoding.Default;
					break;
				case 2:
					secs.StringEncoding = Encoding.UTF8;
					break;
				case 3:
					secs.StringEncoding = Encoding.Unicode;
					break;
				case 4:
					secs.StringEncoding = Encoding.GetEncoding("gb2312");
					break;
				}
			}
		}

		private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			SecsTreeItem secsTreeItem = e.Node.Tag as SecsTreeItem;
			if (secsTreeItem != null)
			{
				textBox_stream.Text = secsTreeItem.S.ToString();
				textBox_function.Text = secsTreeItem.F.ToString();
				checkBox_back.Checked = secsTreeItem.W;
				if (secsTreeItem.Value != null)
				{
					textBox_data.Text = secsTreeItem.Value.ToXElement().ToString();
				}
				else
				{
					textBox_data.Text = string.Empty;
				}
			}
		}

		public void AddTree(TreeNode treeNode, SecsTreeItem treeItem)
		{
			TreeNode treeNode2 = new TreeNode(string.Format("S{0}F{1}{2} {3}", treeItem.S, treeItem.F, treeItem.W ? "W" : "", treeItem.Description));
			treeNode2.Tag = treeItem;
			treeNode.Nodes.Add(treeNode2);
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "SECS Read Demo";
				label1.Text = "Com:";
				label3.Text = "baudRate:";
				label21.Text = "station";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				button3.Text = "Active";
				label11.Text = "Address:";
				label12.Text = "length:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				groupBox3.Text = "Log";
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox_port.Text, out result))
			{
				MessageBox.Show(DemoUtils.PortInputWrong);
			}
			else
			{
				SecsHsms secsHsms = secs;
				if (secsHsms != null)
				{
					secsHsms.ConnectClose();
				}
				secs = new SecsHsms(textBox_ip.Text, result);
				secs.DeviceID = ushort.Parse(textBox_deviceID.Text);
				secs.OnSecsMessageReceived += Secs_OnSecsMessageReceived;
				secs.InitializationS0F0 = checkBox2.Checked;
				ComboBox1_SelectedIndexChanged(comboBox1, e);
				secs.LogNet = base.LogNet;
				try
				{
					OperateResult operateResult = secs.ConnectServer();
					if (operateResult.IsSuccess)
					{
						MessageBox.Show(StringResources.Language.ConnectedSuccess);
						button2.Enabled = true;
						button1.Enabled = false;
						panel2.Enabled = true;
					}
					else
					{
						MessageBox.Show(StringResources.Language.ConnectedFailed + operateResult.Message + Environment.NewLine + "Error: " + operateResult.ErrorCode.ToString());
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void Secs_OnSecsMessageReceived(object sender, SecsMessage secsMessage)
		{
			if (base.InvokeRequired)
			{
				Invoke(new Action<object, SecsMessage>(Secs_OnSecsMessageReceived), sender, secsMessage);
			}
			else if (!checkBox1.Checked)
			{
				textBox_log.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + secsMessage.ToString() + Environment.NewLine);
			}
		}

		private void LogNet_BeforeSaveToFile(object sender, HslEventArgs e)
		{
			if (base.InvokeRequired)
			{
				Invoke((Action)delegate
				{
					LogNet_BeforeSaveToFile(sender, e);
				});
			}
			else if (checkBox1.Checked)
			{
				textBox_log.AppendText(e.HslMessage.ToString() + Environment.NewLine);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			secs.ConnectClose();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			SecsValue data = string.IsNullOrEmpty(textBox_data.Text) ? new SecsValue() : new SecsValue(XElement.Parse(textBox_data.Text));
			OperateResult<SecsMessage> operateResult = secs.ReadSecsMessage(byte.Parse(textBox_stream.Text), byte.Parse(textBox_function.Text), data, checkBox_back.Checked);
			if (operateResult.IsSuccess)
			{
				TextBox textBox = textBox_receive;
				string str = DateTime.Now.ToString("HH:mm:ss");
				string newLine = Environment.NewLine;
				SecsValue itemValues = operateResult.Content.GetItemValues();
				textBox.Text = str + ": " + newLine + ((itemValues != null) ? itemValues.ToString() : null);
			}
			else
			{
				MessageBox.Show("读取失败！" + operateResult.ToMessageShowString());
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = secs.SendByCommand(byte.Parse(textBox_stream.Text), byte.Parse(textBox_function.Text), string.IsNullOrEmpty(textBox_data.Text) ? SecsValue.EmptySecsValue() : new SecsValue(XElement.Parse(textBox_data.Text)), checkBox_back.Checked);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("发送成功！");
			}
			else
			{
				MessageBox.Show("发送失败！" + operateResult.ToMessageShowString());
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox_ip.Text);
			element.SetAttributeValue(DemoDeviceList.XmlBaudRate, textBox_port.Text);
			element.SetAttributeValue(DemoDeviceList.XmlStation, textBox_deviceID.Text);
			element.SetAttributeValue("Encoding", comboBox1.SelectedIndex);
			element.SetAttributeValue("S0F0", checkBox2.Checked);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox_ip.Text = SoftBasic.GetXmlValue(element, DemoDeviceList.XmlIpAddress, "127.0.0.1");
			textBox_port.Text = element.Attribute(DemoDeviceList.XmlBaudRate).Value;
			textBox_deviceID.Text = element.Attribute(DemoDeviceList.XmlStation).Value;
			comboBox1.SelectedIndex = SoftBasic.GetXmlValue(element, "Encoding", 1);
			checkBox2.Checked = SoftBasic.GetXmlValue(element, "S0F0", false);
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
		}

		private void button_S1F1_Click(object sender, EventArgs e)
		{
			OperateResult<OnlineData> operateResult = secs.Gem.S1F1_AreYouThere();
			if (operateResult.IsSuccess)
			{
				textBox_s1.Text = operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read failed: " + operateResult.Message);
			}
		}

		private void button_s1f11_Click(object sender, EventArgs e)
		{
			OperateResult<VariableName[]> operateResult = null;
			operateResult = ((!string.IsNullOrEmpty(textBox4.Text)) ? secs.Gem.S1F11_StatusVariableNamelist(textBox4.Text.ToStringArray<int>()) : secs.Gem.S1F11_StatusVariableNamelist());
			if (operateResult.IsSuccess)
			{
				textBox_s1.Text = operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read failed: " + operateResult.Message);
			}
		}

		private void button_s1f13_Click(object sender, EventArgs e)
		{
			OperateResult<OnlineData> operateResult = secs.Gem.S1F13_EstablishCommunications();
			if (operateResult.IsSuccess)
			{
				textBox_s1.Text = operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read failed: " + operateResult.Message);
			}
		}

		private void button_s1f15_Click(object sender, EventArgs e)
		{
			OperateResult<byte> operateResult = secs.Gem.S1F15_OfflineRequest();
			if (operateResult.IsSuccess)
			{
				textBox_s1.Text = operateResult.Content.ToString() + Environment.NewLine + "返回值说明，0: ok, 1: refused, 2: already online";
			}
			else
			{
				MessageBox.Show("Read failed: " + operateResult.Message);
			}
		}

		private void button_s1f17_Click(object sender, EventArgs e)
		{
			OperateResult<byte> operateResult = secs.Gem.S1F17_OnlineRequest();
			if (operateResult.IsSuccess)
			{
				textBox_s1.Text = operateResult.Content.ToString() + Environment.NewLine + "返回值说明，0: ok, 1: refused, 2: already online";
			}
			else
			{
				MessageBox.Show("Read failed: " + operateResult.Message);
			}
		}

		private void button_s2f13_Click(object sender, EventArgs e)
		{
			OperateResult<SecsValue> operateResult = secs.Gem.S2F13_EquipmentConstantRequest();
			if (operateResult.IsSuccess)
			{
				textBox_s1.Text = operateResult.Content.ToString();
			}
			else
			{
				MessageBox.Show("Read failed: " + operateResult.Message);
			}
		}

		private void button4_Click_1(object sender, EventArgs e)
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
			panel1 = new System.Windows.Forms.Panel();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label5 = new System.Windows.Forms.Label();
			checkBox2 = new System.Windows.Forms.CheckBox();
			textBox_port = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox_ip = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			textBox_deviceID = new System.Windows.Forms.TextBox();
			label21 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			panel2 = new System.Windows.Forms.Panel();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			splitContainer2 = new System.Windows.Forms.SplitContainer();
			textBox_data = new System.Windows.Forms.TextBox();
			textBox_receive = new System.Windows.Forms.TextBox();
			textBox_example = new System.Windows.Forms.TextBox();
			treeView1 = new System.Windows.Forms.TreeView();
			button3 = new System.Windows.Forms.Button();
			label11 = new System.Windows.Forms.Label();
			checkBox_back = new System.Windows.Forms.CheckBox();
			textBox_stream = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox_function = new System.Windows.Forms.TextBox();
			button25 = new System.Windows.Forms.Button();
			label12 = new System.Windows.Forms.Label();
			D = new System.Windows.Forms.Label();
			tabPage2 = new System.Windows.Forms.TabPage();
			button_s1f17 = new System.Windows.Forms.Button();
			button_s1f15 = new System.Windows.Forms.Button();
			button_s1f13 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			button_s1f11 = new System.Windows.Forms.Button();
			textBox_s1 = new System.Windows.Forms.TextBox();
			button_S1F1 = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			tabPage_s2 = new System.Windows.Forms.TabPage();
			panel3 = new System.Windows.Forms.Panel();
			textBox_s2 = new System.Windows.Forms.TextBox();
			button_s2f13 = new System.Windows.Forms.Button();
			groupBox3 = new System.Windows.Forms.GroupBox();
			button4 = new System.Windows.Forms.Button();
			textBox_log = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			checkBox1 = new System.Windows.Forms.CheckBox();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.Panel2.SuspendLayout();
			splitContainer2.SuspendLayout();
			tabPage2.SuspendLayout();
			tabPage_s2.SuspendLayout();
			panel3.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(checkBox2);
			panel1.Controls.Add(textBox_port);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox_ip);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(textBox_deviceID);
			panel1.Controls.Add(label21);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(989, 38);
			panel1.TabIndex = 0;
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
			comboBox1.Location = new System.Drawing.Point(668, 4);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(104, 25);
			comboBox1.TabIndex = 14;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(600, 9);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(63, 17);
			label5.TabIndex = 13;
			label5.Text = "Encode：";
			checkBox2.AutoSize = true;
			checkBox2.Location = new System.Drawing.Point(458, 8);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new System.Drawing.Size(136, 21);
			checkBox2.TabIndex = 12;
			checkBox2.Text = "初始化时发送 S0F0?";
			checkBox2.UseVisualStyleBackColor = true;
			textBox_port.Location = new System.Drawing.Point(250, 6);
			textBox_port.Name = "textBox_port";
			textBox_port.Size = new System.Drawing.Size(76, 23);
			textBox_port.TabIndex = 11;
			textBox_port.Text = "5000";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(196, 9);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 10;
			label3.Text = "端口号：";
			textBox_ip.Location = new System.Drawing.Point(62, 6);
			textBox_ip.Name = "textBox_ip";
			textBox_ip.Size = new System.Drawing.Size(128, 23);
			textBox_ip.TabIndex = 9;
			textBox_ip.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 8;
			label1.Text = "Ip地址：";
			textBox_deviceID.Location = new System.Drawing.Point(408, 6);
			textBox_deviceID.Name = "textBox_deviceID";
			textBox_deviceID.Size = new System.Drawing.Size(44, 23);
			textBox_deviceID.TabIndex = 7;
			textBox_deviceID.Text = "1";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(332, 9);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(71, 17);
			label21.TabIndex = 6;
			label21.Text = "DeviceID：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(875, 3);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(778, 3);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(splitContainer1);
			panel2.Location = new System.Drawing.Point(3, 76);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(989, 592);
			panel2.TabIndex = 1;
			splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer1.Location = new System.Drawing.Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			splitContainer1.Panel1.Controls.Add(tabControl1);
			splitContainer1.Panel2.Controls.Add(groupBox3);
			splitContainer1.Size = new System.Drawing.Size(987, 590);
			splitContainer1.SplitterDistance = 372;
			splitContainer1.TabIndex = 7;
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage_s2);
			tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			tabControl1.Location = new System.Drawing.Point(0, 0);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(987, 372);
			tabControl1.TabIndex = 6;
			tabPage1.BackColor = System.Drawing.SystemColors.Control;
			tabPage1.Controls.Add(splitContainer2);
			tabPage1.Controls.Add(textBox_example);
			tabPage1.Controls.Add(treeView1);
			tabPage1.Controls.Add(button3);
			tabPage1.Controls.Add(label11);
			tabPage1.Controls.Add(checkBox_back);
			tabPage1.Controls.Add(textBox_stream);
			tabPage1.Controls.Add(label2);
			tabPage1.Controls.Add(textBox_function);
			tabPage1.Controls.Add(button25);
			tabPage1.Controls.Add(label12);
			tabPage1.Controls.Add(D);
			tabPage1.Location = new System.Drawing.Point(4, 26);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(979, 342);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Base";
			splitContainer2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			splitContainer2.Location = new System.Drawing.Point(325, 51);
			splitContainer2.Name = "splitContainer2";
			splitContainer2.Panel1.Controls.Add(textBox_data);
			splitContainer2.Panel2.Controls.Add(textBox_receive);
			splitContainer2.Size = new System.Drawing.Size(648, 255);
			splitContainer2.SplitterDistance = 291;
			splitContainer2.TabIndex = 26;
			textBox_data.Dock = System.Windows.Forms.DockStyle.Fill;
			textBox_data.Location = new System.Drawing.Point(0, 0);
			textBox_data.Multiline = true;
			textBox_data.Name = "textBox_data";
			textBox_data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_data.Size = new System.Drawing.Size(291, 255);
			textBox_data.TabIndex = 20;
			textBox_receive.Dock = System.Windows.Forms.DockStyle.Fill;
			textBox_receive.Location = new System.Drawing.Point(0, 0);
			textBox_receive.Multiline = true;
			textBox_receive.Name = "textBox_receive";
			textBox_receive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_receive.Size = new System.Drawing.Size(353, 255);
			textBox_receive.TabIndex = 12;
			textBox_example.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_example.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox_example.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			textBox_example.ForeColor = System.Drawing.Color.Green;
			textBox_example.Location = new System.Drawing.Point(6, 309);
			textBox_example.Multiline = true;
			textBox_example.Name = "textBox_example";
			textBox_example.ReadOnly = true;
			textBox_example.Size = new System.Drawing.Size(970, 49);
			textBox_example.TabIndex = 25;
			textBox_example.Text = "Example:";
			treeView1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			treeView1.Location = new System.Drawing.Point(5, 6);
			treeView1.Name = "treeView1";
			treeView1.Size = new System.Drawing.Size(311, 300);
			treeView1.TabIndex = 24;
			button3.Location = new System.Drawing.Point(718, 5);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(87, 28);
			button3.TabIndex = 22;
			button3.Text = "仅发送";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(322, 10);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(61, 17);
			label11.TabIndex = 4;
			label11.Text = "Stream：";
			checkBox_back.AutoSize = true;
			checkBox_back.Location = new System.Drawing.Point(564, 9);
			checkBox_back.Name = "checkBox_back";
			checkBox_back.Size = new System.Drawing.Size(105, 21);
			checkBox_back.TabIndex = 21;
			checkBox_back.Text = "W? [必须回复]";
			checkBox_back.UseVisualStyleBackColor = true;
			textBox_stream.Location = new System.Drawing.Point(384, 7);
			textBox_stream.Name = "textBox_stream";
			textBox_stream.Size = new System.Drawing.Size(49, 23);
			textBox_stream.TabIndex = 5;
			textBox_stream.Text = "1";
			label2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(926, 31);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(44, 17);
			label2.TabIndex = 11;
			label2.Text = "结果：";
			textBox_function.Location = new System.Drawing.Point(506, 7);
			textBox_function.Name = "textBox_function";
			textBox_function.Size = new System.Drawing.Size(51, 23);
			textBox_function.TabIndex = 7;
			textBox_function.Text = "1";
			button25.Location = new System.Drawing.Point(811, 5);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(95, 28);
			button25.TabIndex = 8;
			button25.Text = "应答";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(439, 10);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(68, 17);
			label12.TabIndex = 6;
			label12.Text = "Function：";
			D.AutoSize = true;
			D.Location = new System.Drawing.Point(325, 31);
			D.Name = "D";
			D.Size = new System.Drawing.Size(47, 17);
			D.TabIndex = 19;
			D.Text = "Data：";
			tabPage2.BackColor = System.Drawing.SystemColors.Control;
			tabPage2.Controls.Add(button_s1f17);
			tabPage2.Controls.Add(button_s1f15);
			tabPage2.Controls.Add(button_s1f13);
			tabPage2.Controls.Add(textBox4);
			tabPage2.Controls.Add(button_s1f11);
			tabPage2.Controls.Add(textBox_s1);
			tabPage2.Controls.Add(button_S1F1);
			tabPage2.Controls.Add(label4);
			tabPage2.Location = new System.Drawing.Point(4, 22);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3);
			tabPage2.Size = new System.Drawing.Size(979, 346);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "S1";
			button_s1f17.Location = new System.Drawing.Point(10, 152);
			button_s1f17.Name = "button_s1f17";
			button_s1f17.Size = new System.Drawing.Size(222, 30);
			button_s1f17.TabIndex = 29;
			button_s1f17.Text = "S1F17-OnlineRequest";
			button_s1f17.UseVisualStyleBackColor = true;
			button_s1f17.Click += new System.EventHandler(button_s1f17_Click);
			button_s1f15.Location = new System.Drawing.Point(10, 116);
			button_s1f15.Name = "button_s1f15";
			button_s1f15.Size = new System.Drawing.Size(222, 30);
			button_s1f15.TabIndex = 28;
			button_s1f15.Text = "S1F15-OfflineRequest";
			button_s1f15.UseVisualStyleBackColor = true;
			button_s1f15.Click += new System.EventHandler(button_s1f15_Click);
			button_s1f13.Location = new System.Drawing.Point(10, 80);
			button_s1f13.Name = "button_s1f13";
			button_s1f13.Size = new System.Drawing.Size(222, 30);
			button_s1f13.TabIndex = 27;
			button_s1f13.Text = "S1F13-EstablishCommunications";
			button_s1f13.UseVisualStyleBackColor = true;
			button_s1f13.Click += new System.EventHandler(button_s1f13_Click);
			textBox4.Location = new System.Drawing.Point(282, 48);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(194, 23);
			textBox4.TabIndex = 25;
			button_s1f11.Location = new System.Drawing.Point(10, 44);
			button_s1f11.Name = "button_s1f11";
			button_s1f11.Size = new System.Drawing.Size(222, 30);
			button_s1f11.TabIndex = 24;
			button_s1f11.Text = "S1F11-StatusVariableNamelist";
			button_s1f11.UseVisualStyleBackColor = true;
			button_s1f11.Click += new System.EventHandler(button_s1f11_Click);
			textBox_s1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			textBox_s1.Location = new System.Drawing.Point(714, 6);
			textBox_s1.Multiline = true;
			textBox_s1.Name = "textBox_s1";
			textBox_s1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_s1.Size = new System.Drawing.Size(259, 329);
			textBox_s1.TabIndex = 23;
			button_S1F1.Location = new System.Drawing.Point(10, 8);
			button_S1F1.Name = "button_S1F1";
			button_S1F1.Size = new System.Drawing.Size(222, 30);
			button_S1F1.TabIndex = 0;
			button_S1F1.Text = "S1F1-AreYouThere";
			button_S1F1.UseVisualStyleBackColor = true;
			button_S1F1.Click += new System.EventHandler(button_S1F1_Click);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(240, 51);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(38, 17);
			label4.TabIndex = 26;
			label4.Text = "VIDs:";
			tabPage_s2.BackColor = System.Drawing.SystemColors.Control;
			tabPage_s2.Controls.Add(panel3);
			tabPage_s2.Location = new System.Drawing.Point(4, 22);
			tabPage_s2.Name = "tabPage_s2";
			tabPage_s2.Padding = new System.Windows.Forms.Padding(3);
			tabPage_s2.Size = new System.Drawing.Size(979, 346);
			tabPage_s2.TabIndex = 2;
			tabPage_s2.Text = "S2";
			panel3.AutoScroll = true;
			panel3.Controls.Add(textBox_s2);
			panel3.Controls.Add(button_s2f13);
			panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			panel3.Location = new System.Drawing.Point(3, 3);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(973, 340);
			panel3.TabIndex = 0;
			textBox_s2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			textBox_s2.Location = new System.Drawing.Point(711, 3);
			textBox_s2.Multiline = true;
			textBox_s2.Name = "textBox_s2";
			textBox_s2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_s2.Size = new System.Drawing.Size(259, 338);
			textBox_s2.TabIndex = 24;
			button_s2f13.Location = new System.Drawing.Point(8, 7);
			button_s2f13.Name = "button_s2f13";
			button_s2f13.Size = new System.Drawing.Size(222, 30);
			button_s2f13.TabIndex = 1;
			button_s2f13.Text = "S2F13-EquipmentConstant";
			button_s2f13.UseVisualStyleBackColor = true;
			button_s2f13.Click += new System.EventHandler(button_s2f13_Click);
			groupBox3.Controls.Add(button4);
			groupBox3.Controls.Add(textBox_log);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(checkBox1);
			groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			groupBox3.Location = new System.Drawing.Point(0, 0);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(987, 214);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "日志";
			button4.Location = new System.Drawing.Point(4, 69);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(55, 26);
			button4.TabIndex = 16;
			button4.Text = "clear";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click_1);
			textBox_log.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_log.Location = new System.Drawing.Point(63, 17);
			textBox_log.Multiline = true;
			textBox_log.Name = "textBox_log";
			textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_log.Size = new System.Drawing.Size(918, 191);
			textBox_log.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 19);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "接收：";
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(7, 41);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(58, 21);
			checkBox1.TabIndex = 15;
			checkBox1.Text = "STOP";
			checkBox1.UseVisualStyleBackColor = true;
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "http://www.cnblogs.com/dathlin/p/8974215.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Secs gem HSMS";
			userControlHead1.Size = new System.Drawing.Size(996, 32);
			userControlHead1.TabIndex = 2;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(996, 671);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormSecsGem";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Secs/Gem访问Demo";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel1.PerformLayout();
			splitContainer2.Panel2.ResumeLayout(false);
			splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
			splitContainer2.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			tabPage_s2.ResumeLayout(false);
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			ResumeLayout(false);
		}
	}
}
