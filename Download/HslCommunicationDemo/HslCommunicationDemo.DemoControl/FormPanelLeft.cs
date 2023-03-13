using HslCommunication.LogNet;
using HslCommunicationDemo.Algorithms;
using HslCommunicationDemo.BarCode;
using HslCommunicationDemo.Control;
using HslCommunicationDemo.HslDebug;
using HslCommunicationDemo.Light;
using HslCommunicationDemo.MQTT;
using HslCommunicationDemo.PLC;
using HslCommunicationDemo.PLC.Secs;
using HslCommunicationDemo.Properties;
using HslCommunicationDemo.Redis;
using HslCommunicationDemo.Robot;
using HslCommunicationDemo.Toledo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;
using WeifenLuo.WinFormsUI.Docking;

namespace HslCommunicationDemo.DemoControl
{
	public class FormPanelLeft : DockContent
	{
		private ILogNet logNet = null;

		private ImageList imageList;

		private Dictionary<string, int> formIconImageIndex = new Dictionary<string, int>();

		private DockPanel dockPanel1;

		public static Type[] formTypes = Assembly.GetExecutingAssembly().GetTypes();

		private IContainer components = null;

		private TreeView treeView1;

		public Dictionary<string, int> IconImageIndex
		{
			get
			{
				return formIconImageIndex;
			}
		}

		public FormPanelLeft(DockPanel dockPanel, ImageList imageList, ILogNet logNet)
		{
			dockPanel1 = dockPanel;
			this.logNet = logNet;
			this.imageList = imageList;
			InitializeComponent();
		}

		private void FormPanelLeft_Load(object sender, EventArgs e)
		{
			base.CloseButtonVisible = false;
			treeView1.ImageList = imageList;
			TreeViewIni();
			treeView1.DoubleClick += TreeView1_DoubleClick;
			treeView1.MouseClick += TreeView1_MouseClick;
			SetLanguage();
		}

		public void SetLanguage()
		{
			if (Program.Language == 1)
			{
				Text = "设备列表";
			}
			else
			{
				Text = "Device List";
			}
		}

		private void TreeView1_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				TreeNode nodeAt = treeView1.GetNodeAt(e.Location);
				if (nodeAt != null)
				{
					treeView1.SelectedNode = nodeAt;
				}
			}
		}

		private void TreeView1_DoubleClick(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeView1.SelectedNode;
			if (selectedNode != null && selectedNode.Tag != null)
			{
				Type type = selectedNode.Tag as Type;
				if ((object)type != null)
				{
					HslFormContent hslFormContent = (HslFormContent)type.GetConstructors()[0].Invoke(null);
					if (hslFormContent != null)
					{
						hslFormContent.LogNet = logNet;
						if (selectedNode.ImageIndex >= 0)
						{
							hslFormContent.Icon = Icon.FromHandle(((Bitmap)imageList.Images[selectedNode.ImageIndex]).GetHicon());
						}
						else
						{
							hslFormContent.Icon = Icon.FromHandle(Resources.Method_636.GetHicon());
						}
						if (hslFormContent != null)
						{
							hslFormContent.Show(dockPanel1);
						}
					}
				}
			}
		}

		private void TreeViewIni()
		{
			TreeNode treeNode = new TreeNode("Melsec Plc [三菱]", 8, 8);
			treeNode.Nodes.Add(GetTreeNodeByIndex("EtherNet/IP(CIP)", 8, typeof(FormMelsecCipNet)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("A-1E (Binary)", 8, typeof(FormMelsec1EBinary)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("A-1E (ASCII)", 8, typeof(FormMelsec1EAscii)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("A-1E Server", 8, typeof(FormMcA1EServer)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("MC (Binary)", 8, typeof(FormMelsecBinary)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("MC Udp(Binary)", 8, typeof(FormMelsecUdp)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("MC (ASCII)", 8, typeof(FormMelsecAscii)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("MC Udp(ASCII)", 8, typeof(FormMelsecAsciiUdp)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("MC-R (Binary)", 8, typeof(FormMelsecRBinary)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("Fx Serial【编程口】", 8, typeof(FormMelsecSerial)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("Fx Serial OverTcp", 8, typeof(FormMelsecSerialOverTcp)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("Fx Links【485】", 8, typeof(FormMelsecLinks)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("Fx Links OverTcp", 8, typeof(FormMelsecLinksOverTcp)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("FxLinks Server", 8, typeof(FormFxLinksServer)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("A-3C (串口)", 8, typeof(FormMelsec3C)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("A-3C OverTcp", 8, typeof(FormMelsec3COverTcp)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("A-3C Server", 8, typeof(FormMcA3CServer)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("Mc Virtual Server", 8, typeof(FormMcServer)));
			treeNode.Nodes.Add(GetTreeNodeByIndex("Mc Udp Server", 8, typeof(FormMcUdpServer)));
			treeView1.Nodes.Add(treeNode);
			TreeNode treeNode2 = new TreeNode("Siemens Plc [西门子]", 14, 14);
			treeNode2.Nodes.Add(GetTreeNodeByIndex("S7-S1200", 14, typeof(FormSiemensS1200)));
			treeNode2.Nodes.Add(GetTreeNodeByIndex("S7-S1500", 14, typeof(FormSiemensS1500)));
			treeNode2.Nodes.Add(GetTreeNodeByIndex("S7-S300", 14, typeof(FormSiemensS300)));
			treeNode2.Nodes.Add(GetTreeNodeByIndex("S7-S400", 14, typeof(FormSiemensS400)));
			treeNode2.Nodes.Add(GetTreeNodeByIndex("S7-S200", 14, typeof(FormSiemensS200)));
			treeNode2.Nodes.Add(GetTreeNodeByIndex("S7-S200 smart", 14, typeof(FormSiemensS200Smart)));
			treeNode2.Nodes.Add(GetTreeNodeByIndex("Fetch/Write", 14, typeof(FormSiemensFW)));
			treeNode2.Nodes.Add(GetTreeNodeByIndex("WebApi", 14, typeof(FormSiemensWebApi)));
			treeNode2.Nodes.Add(GetTreeNodeByIndex("PPI", 14, typeof(FormSiemensPPI)));
			treeNode2.Nodes.Add(GetTreeNodeByIndex("PPI OverTcp", 14, typeof(FormSiemensPPIOverTcp)));
			treeNode2.Nodes.Add(GetTreeNodeByIndex("MPI", 14, typeof(FormSiemensMPI)));
			treeNode2.Nodes.Add(GetTreeNodeByIndex("S7 Virtual Server", 14, typeof(FormS7Server)));
			treeNode2.Nodes.Add(GetTreeNodeByIndex("S7 PPI Server", 14, typeof(FormSiemensPPIServer)));
			treeNode2.Nodes.Add(GetTreeNodeByIndex("Fetch Write Server", 14, typeof(FormFetchWriteServer)));
			treeNode2.Nodes.Add(GetTreeNodeByIndex("Siemens DTU", 14, typeof(FormSiemensDTU)));
			treeView1.Nodes.Add(treeNode2);
			TreeNode treeNode3 = new TreeNode("Modbus", 9, 9);
			treeNode3.Nodes.Add(GetTreeNodeByIndex("Modbus Tcp", 9, typeof(FormModbus)));
			treeNode3.Nodes.Add(GetTreeNodeByIndex("Modbus Udp", 9, typeof(FormModbusUdp)));
			treeNode3.Nodes.Add(GetTreeNodeByIndex("Modbus Tcp[Alien]", 9, typeof(FormModbusAlien)));
			treeNode3.Nodes.Add(GetTreeNodeByIndex("Modbus Rtu", 9, typeof(FormModbusRtu)));
			treeNode3.Nodes.Add(GetTreeNodeByIndex("Modbus Rtu OverTcp", 9, typeof(FormModbusRtuOverTcp)));
			treeNode3.Nodes.Add(GetTreeNodeByIndex("Modbus Ascii", 9, typeof(FormModbusAscii)));
			treeNode3.Nodes.Add(GetTreeNodeByIndex("ModbusAscii OverTcp", 9, typeof(FormModbusAsciiOverTcp)));
			treeNode3.Nodes.Add(GetTreeNodeByIndex("Modbus Server", 9, typeof(FormModbusServer)));
			treeView1.Nodes.Add(treeNode3);
			TreeNode treeNode4 = new TreeNode("Inovance Plc[汇川]", 5, 5);
			treeNode4.Nodes.Add(GetTreeNodeByIndex("InovanceSerial", 5, typeof(FormInovanceSerial)));
			treeNode4.Nodes.Add(GetTreeNodeByIndex("InovanceSerialOverTcp", 5, typeof(FormInovanceSerialOverTcp)));
			treeNode4.Nodes.Add(GetTreeNodeByIndex("InovanceTcpNet", 5, typeof(FormInovanceTcpNet)));
			treeView1.Nodes.Add(treeNode4);
			TreeNode treeNode5 = new TreeNode("Omron Plc[欧姆龙]", 10, 10);
			treeNode5.Nodes.Add(GetTreeNodeByIndex("Fins Tcp", 10, typeof(FormOmron)));
			treeNode5.Nodes.Add(GetTreeNodeByIndex("Fins Udp", 10, typeof(FormOmronUdp)));
			treeNode5.Nodes.Add(GetTreeNodeByIndex("EtherNet/IP(CIP)", 10, typeof(FormOmronCip)));
			treeNode5.Nodes.Add(GetTreeNodeByIndex("Connected CIP", 10, typeof(FormOmronConnectedCip)));
			treeNode5.Nodes.Add(GetTreeNodeByIndex("HostLink 【串口】", 10, typeof(FormOmronHostLink)));
			treeNode5.Nodes.Add(GetTreeNodeByIndex("HostLink OverTcp", 10, typeof(FormOmronHostLinkOverTcp)));
			treeNode5.Nodes.Add(GetTreeNodeByIndex("HostLink C-Mode", 10, typeof(FormOmronHostLinkCMode)));
			treeNode5.Nodes.Add(GetTreeNodeByIndex("C-Mode OverTcp", 10, typeof(FormOmronHostLinkCModeOverTcp)));
			treeNode5.Nodes.Add(GetTreeNodeByIndex("Fins Virtual Server", 10, typeof(FormOmronServer)));
			treeNode5.Nodes.Add(GetTreeNodeByIndex("Fins Udp Server", 10, typeof(FormOmronUdpServer)));
			treeNode5.Nodes.Add(GetTreeNodeByIndex("HostLink Server", 10, typeof(FormOmronHostLinkServer)));
			treeNode5.Nodes.Add(GetTreeNodeByIndex("Cmode Server", 10, typeof(FormOmronHostLinkCModeServer)));
			treeView1.Nodes.Add(treeNode5);
			TreeNode treeNode6 = new TreeNode("LSis Plc", 7, 7);
			treeNode6.Nodes.Add(GetTreeNodeByIndex("XGB Fast Enet", 7, typeof(FormLsisFEnet)));
			treeNode6.Nodes.Add(GetTreeNodeByIndex("XGB Cnet", 7, typeof(FormLsisCnet)));
			treeNode6.Nodes.Add(GetTreeNodeByIndex("XGB Cnet OverTcp", 7, typeof(FormLsisCnetOverTcp)));
			treeNode6.Nodes.Add(GetTreeNodeByIndex("XGK Cnet", 7, typeof(FormLsisXGKCnet)));
			treeNode6.Nodes.Add(GetTreeNodeByIndex("XGK Fast Enet", 7, typeof(FormLsisXGKFEnet)));
			treeNode6.Nodes.Add(GetTreeNodeByIndex("LSis Virtual Server", 7, typeof(FormLSisServer)));
			treeView1.Nodes.Add(treeNode6);
			TreeNode treeNode7 = new TreeNode("Keyence Plc[基恩士]", 6, 6);
			treeNode7.Nodes.Add(GetTreeNodeByIndex("MC-3E (Binary)", 6, typeof(FormKeyenceBinary)));
			treeNode7.Nodes.Add(GetTreeNodeByIndex("MC-3E (ASCII)", 6, typeof(FormKeyenceAscii)));
			treeNode7.Nodes.Add(GetTreeNodeByIndex("Nano (ASCII)", 6, typeof(FormKeyenceNanoSerial)));
			treeNode7.Nodes.Add(GetTreeNodeByIndex("Nano OverTcp", 6, typeof(FormKeyenceNanoSerialOverTcp)));
			treeNode7.Nodes.Add(GetTreeNodeByIndex("Nano Server", 6, typeof(FormKeyenceNanoServer)));
			treeNode7.Nodes.Add(GetTreeNodeByIndex("SR2000 [读码]", 6, typeof(FormKeyenceSR2000)));
			treeNode7.Nodes.Add(GetTreeNodeByIndex("DL-EN1 [传感器]", 6, typeof(FormKeyenceDLEN1)));
			treeView1.Nodes.Add(treeNode7);
			TreeNode treeNode8 = new TreeNode("Panasonic Plc[松下]", 11, 11);
			treeNode8.Nodes.Add(GetTreeNodeByIndex("MC-3E (Binary)", 11, typeof(FormPanasonicBinary)));
			treeNode8.Nodes.Add(GetTreeNodeByIndex("Mewtocol", 11, typeof(FormPanasonicMew)));
			treeNode8.Nodes.Add(GetTreeNodeByIndex("Mewtocol OverTcp", 11, typeof(FormPanasonicMewOverTcp)));
			treeNode8.Nodes.Add(GetTreeNodeByIndex("Mewtocol Server", 11, typeof(FormPanasonicMewtocolServer)));
			treeView1.Nodes.Add(treeNode8);
			TreeNode treeNode9 = new TreeNode("AllenBrandly[罗克韦尔]", 1, 1);
			treeNode9.Nodes.Add(GetTreeNodeByIndex("EtherNet/IP(CIP)", 1, typeof(FormAllenBrandly)));
			treeNode9.Nodes.Add(GetTreeNodeByIndex("Connected CIP", 1, typeof(FormAllenBrandlyConnectedCip)));
			treeNode9.Nodes.Add(GetTreeNodeByIndex("MicroCip(Micro800)", 1, typeof(FormAllenBrandlyMicroCip)));
			treeNode9.Nodes.Add(GetTreeNodeByIndex("CIP Browser", 1, typeof(FormAllenBrandlyBrowser)));
			treeNode9.Nodes.Add(GetTreeNodeByIndex("CIP Virtual Server", 1, typeof(FormCipServer)));
			treeNode9.Nodes.Add(GetTreeNodeByIndex("CIP PCCC", 1, typeof(FormAllenBrandlyPCCC)));
			treeNode9.Nodes.Add(GetTreeNodeByIndex("CIP PCCC Server", 1, typeof(FormPcccServer)));
			treeNode9.Nodes.Add(GetTreeNodeByIndex("SLC Net", 1, typeof(FormAllenBrandlySLC)));
			treeNode9.Nodes.Add(GetTreeNodeByIndex("DF1", 1, typeof(FormAllenBradleyDF1Serial)));
			treeView1.Nodes.Add(treeNode9);
			TreeNode treeNode10 = new TreeNode("Beckhoff Plc[倍福]", 20, 20);
			treeNode10.Nodes.Add(GetTreeNodeByIndex("Ads Net", 20, typeof(FormBeckhoffAdsNet)));
			treeNode10.Nodes.Add(GetTreeNodeByIndex("Ads Server", 20, typeof(FormBeckhoffAdsServer)));
			treeView1.Nodes.Add(treeNode10);
			TreeNode treeNode11 = new TreeNode("GE Plc[通用电气]", 33, 33);
			treeNode11.Nodes.Add(GetTreeNodeByIndex("SRTP", 33, typeof(FormGeSRTP)));
			treeNode11.Nodes.Add(GetTreeNodeByIndex("SRTP Server", 33, typeof(FormGeSRTPServer)));
			treeView1.Nodes.Add(treeNode11);
			TreeNode treeNode12 = new TreeNode("Yaskawa Plc[安川]", 29, 29);
			treeNode12.Nodes.Add(GetTreeNodeByIndex("MemobusTcp", 29, typeof(FormYASKAWAMemobusTcpNet)));
			treeNode12.Nodes.Add(GetTreeNodeByIndex("MemobusUdp", 29, typeof(FormYASKAWAMemobusUdpNet)));
			treeNode12.Nodes.Add(GetTreeNodeByIndex("MemobusTcpServer", 29, typeof(FormMemobusTcpServer)));
			treeView1.Nodes.Add(treeNode12);
			TreeNode treeNode13 = new TreeNode("yamatake[山武]", 34, 34);
			treeNode13.Nodes.Add(GetTreeNodeByIndex("DigitronCPL", 34, typeof(FormDigitronCPL)));
			treeNode13.Nodes.Add(GetTreeNodeByIndex("DigitronCPL OverTcp", 34, typeof(FormDigitronCPLOverTcp)));
			treeNode13.Nodes.Add(GetTreeNodeByIndex("DigitronCPL Server", 34, typeof(FormDigitronCPLServer)));
			treeView1.Nodes.Add(treeNode13);
			TreeNode treeNode14 = new TreeNode("RKC[理化]", 35, 35);
			treeNode14.Nodes.Add(GetTreeNodeByIndex("温度控制器", 35, typeof(FormRkcTemperatureController)));
			treeNode14.Nodes.Add(GetTreeNodeByIndex("温度控制器TCP", 35, typeof(FormRkcTemperatureControllerOverTcp)));
			treeView1.Nodes.Add(treeNode14);
			TreeNode treeNode15 = new TreeNode("Fatek Plc[永宏]", 22, 22);
			treeNode15.Nodes.Add(GetTreeNodeByIndex("programe [编程口]", 22, typeof(FormFatekPrograme)));
			treeNode15.Nodes.Add(GetTreeNodeByIndex("programe OverTcp", 22, typeof(FormFatekProgrameOverTcp)));
			treeNode15.Nodes.Add(GetTreeNodeByIndex("programe Server", 22, typeof(FormFatekProgrameServer)));
			treeView1.Nodes.Add(treeNode15);
			TreeNode treeNode16 = new TreeNode("Vigor Plc[丰炜]", 36, 36);
			treeNode16.Nodes.Add(GetTreeNodeByIndex("Serial [编程口]", 36, typeof(FormVigorSerial)));
			treeNode16.Nodes.Add(GetTreeNodeByIndex("Serial OverTcp", 36, typeof(FormVigorSerialOverTcp)));
			treeNode16.Nodes.Add(GetTreeNodeByIndex("Virtual Server", 36, typeof(FormVigorServer)));
			treeView1.Nodes.Add(treeNode16);
			TreeNode treeNode17 = new TreeNode("Fuji Plc[富士]", 2, 2);
			treeNode17.Nodes.Add(GetTreeNodeByIndex("SPB [编程口]", 2, typeof(FormFujiSPB)));
			treeNode17.Nodes.Add(GetTreeNodeByIndex("SPB OverTcp", 2, typeof(FormFujiSPBOverTcp)));
			treeNode17.Nodes.Add(GetTreeNodeByIndex("SPB Server", 2, typeof(FormFujiSPBServer)));
			treeNode17.Nodes.Add(GetTreeNodeByIndex("SPH Net", 2, typeof(FormFujiSPHNet)));
			treeNode17.Nodes.Add(GetTreeNodeByIndex("SPH Server", 2, typeof(FormFujiSPHServer)));
			treeNode17.Nodes.Add(GetTreeNodeByIndex("CommandST", 2, typeof(FormFujiCSTNet)));
			treeNode17.Nodes.Add(GetTreeNodeByIndex("CommandST Server", 2, typeof(FormFujiCSTServer)));
			treeView1.Nodes.Add(treeNode17);
			TreeNode treeNode18 = new TreeNode("XinJE Plc[信捷]", 30, 30);
			treeNode18.Nodes.Add(GetTreeNodeByIndex("XinJE Serial", 30, typeof(FormXinJEXCSerial)));
			treeNode18.Nodes.Add(GetTreeNodeByIndex("XinJE Serial OverTcp", 30, typeof(FormXinJESerialOverTcp)));
			treeNode18.Nodes.Add(GetTreeNodeByIndex("XinJE TCP [Modbus]", 30, typeof(FormXinJETcpNet)));
			treeNode18.Nodes.Add(GetTreeNodeByIndex("XinJE Server", 30, typeof(FormXinJEInternalServer)));
			treeNode18.Nodes.Add(GetTreeNodeByIndex("XinJE TCP[专用]", 30, typeof(FormXinJEInternalTcp)));
			treeView1.Nodes.Add(treeNode18);
			TreeNode treeNode19 = new TreeNode("MegMeet Plc[麦格米特]", 0, 0);
			treeNode19.Nodes.Add(GetTreeNodeByIndex("MegMeet Serial", 0, typeof(FormMegMeetSerial)));
			treeNode19.Nodes.Add(GetTreeNodeByIndex("MegMeet Serial OverTcp", 0, typeof(FormMegMeetSerialOverTcp)));
			treeNode19.Nodes.Add(GetTreeNodeByIndex("MegMeet TCP [Modbus]", 0, typeof(FormMegMeetTcpNet)));
			treeView1.Nodes.Add(treeNode19);
			TreeNode treeNode20 = new TreeNode("Yokogawa Plc[横河]", 31, 31);
			treeNode20.Nodes.Add(GetTreeNodeByIndex("Yokogawa Link Tcp", 31, typeof(FormYokogawaLinkTcp)));
			treeNode20.Nodes.Add(GetTreeNodeByIndex("Yokogawa Link Server", 31, typeof(FormYokogawaLinkServer)));
			treeView1.Nodes.Add(treeNode20);
			TreeNode treeNode21 = new TreeNode("Delta Plc[台达]", 32, 32);
			treeNode21.Nodes.Add(GetTreeNodeByIndex("Serial", 32, typeof(FormDeltaDvpSerial)));
			treeNode21.Nodes.Add(GetTreeNodeByIndex("Serial Over Tcp", 32, typeof(FormDeltaSerialOverTcp)));
			treeNode21.Nodes.Add(GetTreeNodeByIndex("Serial Ascii", 32, typeof(FormDeltaDvpSerialAscii)));
			treeNode21.Nodes.Add(GetTreeNodeByIndex("Ascii Over Tcp", 32, typeof(FormDeltaSerialAsciiOverTcp)));
			treeNode21.Nodes.Add(GetTreeNodeByIndex("Tcp Net", 32, typeof(FormDeltaDvpTcpNet)));
			treeView1.Nodes.Add(treeNode21);
			TreeNode treeNode22 = new TreeNode("ID Card[身份证]", 4, 4);
			treeNode22.Nodes.Add(GetTreeNodeByIndex("SAM Serial", 27, typeof(FormSAMSerial)));
			treeNode22.Nodes.Add(GetTreeNodeByIndex("SAM Tcp", 27, typeof(FormSAMTcpNet)));
			treeView1.Nodes.Add(treeNode22);
			TreeNode treeNode23 = new TreeNode("Redis", 12, 12);
			treeNode23.Nodes.Add(GetTreeNodeByIndex("Redis Client", 12, typeof(FormRedisClient)));
			treeNode23.Nodes.Add(GetTreeNodeByIndex("Redis Browser", 12, typeof(RedisBrowser)));
			treeNode23.Nodes.Add(GetTreeNodeByIndex("Redis Subscribe", 12, typeof(FormRedisSubscribe)));
			treeNode23.Nodes.Add(GetTreeNodeByIndex("Redis Copy", 12, typeof(FormRedisCopy)));
			treeView1.Nodes.Add(treeNode23);
			TreeNode treeNode24 = new TreeNode("MQTT", 17, 17);
			treeNode24.Nodes.Add(GetTreeNodeByIndex("Mqtt Server", 17, typeof(FormMqttServer)));
			treeNode24.Nodes.Add(GetTreeNodeByIndex("Mqtt Client", 17, typeof(FormMqttClient)));
			treeNode24.Nodes.Add(GetTreeNodeByIndex("Mqtt RPC Client", 17, typeof(FormMqttSyncClient)));
			treeNode24.Nodes.Add(GetTreeNodeByIndex("Mqtt File Server", 17, typeof(FormMqttFileServer)));
			treeNode24.Nodes.Add(GetTreeNodeByIndex("Mqtt File Client", 17, typeof(FormMqttFileClient)));
			treeNode24.Nodes.Add(GetTreeNodeByIndex("Mqtt Rpc Device", 17, typeof(FormMqttRpcDevice)));
			treeView1.Nodes.Add(treeNode24);
			TreeNode treeNode25 = new TreeNode("WebSocket", 28, 28);
			treeNode25.Nodes.Add(GetTreeNodeByIndex("WebSocket Client", 28, typeof(FormWebsocketClient)));
			treeNode25.Nodes.Add(GetTreeNodeByIndex("WebSocket Server", 28, typeof(FormWebsocketServer)));
			treeNode25.Nodes.Add(GetTreeNodeByIndex("WebSocket QANet", 28, typeof(FormWebsocketQANet)));
			treeView1.Nodes.Add(treeNode25);
			TreeNode treeNode26 = new TreeNode("Http", 0, 0);
			treeNode26.Nodes.Add(GetTreeNodeByIndex("Http Web Server", 0, typeof(FormHttpServer)));
			treeNode26.Nodes.Add(GetTreeNodeByIndex("Http Web Client", 0, typeof(FormHttpClient)));
			treeView1.Nodes.Add(treeNode26);
			TreeNode treeNode27 = new TreeNode("Robot[机器人]", 19, 19);
			treeNode27.Nodes.Add(GetTreeNodeByIndex("EFORT New [新版]", 24, typeof(FormEfort)));
			treeNode27.Nodes.Add(GetTreeNodeByIndex("EFORT Pre [旧版]", 24, typeof(FormEfortPrevious)));
			treeNode27.Nodes.Add(GetTreeNodeByIndex("Kuka [库卡]", 23, typeof(FormKuka)));
			treeNode27.Nodes.Add(GetTreeNodeByIndex("Kuka Tcp [库卡]", 23, typeof(FormKukaTcp)));
			treeNode27.Nodes.Add(GetTreeNodeByIndex("YRC1000 [安川]", 29, typeof(FormYRC1000)));
			treeNode27.Nodes.Add(GetTreeNodeByIndex("HighEthernet [安川]", 29, typeof(FormYRCHighEthernet)));
			treeNode27.Nodes.Add(GetTreeNodeByIndex("ABB Web", 21, typeof(FormABBWebApi)));
			treeNode27.Nodes.Add(GetTreeNodeByIndex("ABB Web Server", 21, typeof(FormAbbServer)));
			treeNode27.Nodes.Add(GetTreeNodeByIndex("Fanuc [发那科]", 25, typeof(FormFanucRobot)));
			treeNode27.Nodes.Add(GetTreeNodeByIndex("Fanuc Server [发那科服务器]", 25, typeof(FormFanucRobotServer)));
			treeNode27.Nodes.Add(GetTreeNodeByIndex("Estun [埃斯顿]", 19, typeof(FormEstunTcp)));
			treeNode27.Nodes.Add(new TreeNode("Hyundai [现代]")
			{
				Tag = typeof(FormHyundaiUdp)
			});
			treeNode27.Nodes.Add(new TreeNode("YamahaRCX [雅马哈]")
			{
				Tag = typeof(FormYamahaRCX)
			});
			treeView1.Nodes.Add(treeNode27);
			TreeNode treeNode28 = new TreeNode("CNC[数控机床]");
			treeNode28.Nodes.Add(GetTreeNodeByIndex("Fanuc 0i [Test]", 25, typeof(FormCncFanuc)));
			treeView1.Nodes.Add(treeNode28);
			TreeNode treeNode29 = new TreeNode("Secs [半导体]");
			treeNode29.Nodes.Add(new TreeNode("Secs Gem")
			{
				Tag = typeof(FormSecsGem)
			});
			treeNode29.Nodes.Add(new TreeNode("Secs Server")
			{
				Tag = typeof(FormSecsHsmsServer)
			});
			treeView1.Nodes.Add(treeNode29);
			TreeNode treeNode30 = new TreeNode("Sensor[传感器]");
			treeNode30.Nodes.Add(new TreeNode("Vibration[捷杰振动]")
			{
				Tag = typeof(FormVibrationSensorClient)
			});
			treeView1.Nodes.Add(treeNode30);
			TreeNode treeNode31 = new TreeNode("Freedom[自由协议]");
			treeNode31.Nodes.Add(new TreeNode("TCP Net")
			{
				Tag = typeof(FormFreedomTcpNet)
			});
			treeNode31.Nodes.Add(new TreeNode("UDP Net")
			{
				Tag = typeof(FormFreedomUdpNet)
			});
			treeNode31.Nodes.Add(new TreeNode("Serial [串口]")
			{
				Tag = typeof(FormFreedomSerial)
			});
			treeView1.Nodes.Add(treeNode31);
			TreeNode treeNode32 = new TreeNode("Debug About[调试技术]", 15, 15);
			treeNode32.Nodes.Add(GetTreeNodeByIndex("Regex [正则表达式]", 15, typeof(FormRegexTest)));
			treeNode32.Nodes.Add(GetTreeNodeByIndex("Check [校验码调试]", 15, typeof(FormCheck)));
			treeNode32.Nodes.Add(GetTreeNodeByIndex("Serial [串口调试]", 15, typeof(FormSerialDebug)));
			treeNode32.Nodes.Add(GetTreeNodeByIndex("Tcp/Ip Client [网口调试]", 15, typeof(FormTcpDebug)));
			treeNode32.Nodes.Add(GetTreeNodeByIndex("Tcp/Ip Server [网口调试]", 15, typeof(FormTcpServer)));
			treeNode32.Nodes.Add(GetTreeNodeByIndex("Serial2Tcp [串口转网口]", 15, typeof(FormSerialToTcp)));
			treeNode32.Nodes.Add(GetTreeNodeByIndex("Tcp2Tcp [网口转网口]", 15, typeof(FormTcpToTcp)));
			treeNode32.Nodes.Add(GetTreeNodeByIndex("Bytes Data [数据调试]", 15, typeof(FormByteTransfer)));
			treeNode32.Nodes.Add(GetTreeNodeByIndex("Mail [邮件调试]", 15, typeof(FormMail)));
			treeNode32.Nodes.Add(GetTreeNodeByIndex("Order Number [订单号调试]", 15, typeof(FormSeqCreate)));
			treeNode32.Nodes.Add(GetTreeNodeByIndex("Regist [注册码调试]", 15, typeof(FormRegister)));
			treeView1.Nodes.Add(treeNode32);
			TreeNode treeNode33 = new TreeNode("Hsl Protocal[HSL 协议]", 3, 3);
			treeNode33.Nodes.Add(GetTreeNodeByIndex("Simplify Net [同步交互]", 3, typeof(FormSimplifyNet)));
			treeNode33.Nodes.Add(GetTreeNodeByIndex("Simplify Net Alien", 3, typeof(FormSimplifyNetAlien)));
			treeNode33.Nodes.Add(GetTreeNodeByIndex("Complex Net [异步交互]", 3, typeof(FormComplexNet)));
			treeNode33.Nodes.Add(GetTreeNodeByIndex("Udp Net [同步交互]", 3, typeof(FormUdpNet)));
			treeNode33.Nodes.Add(GetTreeNodeByIndex("File Net [文件收发]", 3, typeof(FormFileClient)));
			treeNode33.Nodes.Add(GetTreeNodeByIndex("Log Net [日志记录]", 3, typeof(FormLogNet)));
			treeNode33.Nodes.Add(GetTreeNodeByIndex("Push Net [消息推送]", 3, typeof(FormPushNet)));
			treeNode33.Nodes.Add(GetTreeNodeByIndex("SoftUpdate [软件更新]", 3, typeof(FormUpdateServer)));
			treeNode33.Nodes.Add(GetTreeNodeByIndex("Plain Net [明文交互]", 3, typeof(FormPlainSocket)));
			treeNode33.Nodes.Add(GetTreeNodeByIndex("Dtu Server[DTU服务器]", 3, typeof(FormDtuServer)));
			treeView1.Nodes.Add(treeNode33);
			TreeNode treeNode34 = new TreeNode("Bar/RFID[扫码及RFID]", 16, 16);
			treeNode34.Nodes.Add(GetTreeNodeByIndex("Sick", 16, typeof(FormSickBarCode)));
			treeNode34.Nodes.Add(GetTreeNodeByIndex("Turck Reader", 38, typeof(FormTurckReaderNet)));
			treeNode34.Nodes.Add(GetTreeNodeByIndex("Turck Reader Server", 38, typeof(FormTurckReaderServer)));
			treeView1.Nodes.Add(treeNode34);
			TreeNode treeNode35 = new TreeNode("Instrument [仪器仪表]");
			treeNode35.Nodes.Add(new TreeNode("DAM3601 [阿尔泰科技]")
			{
				Tag = typeof(FormDAM3601)
			});
			treeNode35.Nodes.Add(new TreeNode("DLT645 [电力规约]")
			{
				Tag = typeof(FormDLT645)
			});
			treeNode35.Nodes.Add(new TreeNode("DLT645 OverTcp")
			{
				Tag = typeof(FormDLT645OverTcp)
			});
			treeNode35.Nodes.Add(new TreeNode("DLT645-1997")
			{
				Tag = typeof(FormDLT645With1997)
			});
			treeNode35.Nodes.Add(new TreeNode("DLT645-1997 OverTcp")
			{
				Tag = typeof(FormDLT645With1997OverTcp)
			});
			treeNode35.Nodes.Add(new TreeNode("DLT698 [电力规约]")
			{
				Tag = typeof(FormDLT698)
			});
			treeNode35.Nodes.Add(new TreeNode("DLT698 OverTcp")
			{
				Tag = typeof(FormDLT698OverTcp)
			});
			treeNode35.Nodes.Add(new TreeNode("DLT698 TcpNet")
			{
				Tag = typeof(FormDLT698TcpNet)
			});
			treeNode35.Nodes.Add(new TreeNode("光源控制器")
			{
				Tag = typeof(FormShineInLight)
			});
			treeNode35.Nodes.Add(new TreeNode("DTSU6606 [德力西电表]")
			{
				Tag = typeof(FormDTSU6606)
			});
			treeNode35.Nodes.Add(new TreeNode("IEC104 [电力规约]", 37, 37)
			{
				Tag = typeof(FormIEC104)
			});
			treeNode35.Nodes.Add(new TreeNode("CJT188 [水表，燃气]")
			{
				Tag = typeof(FormCJT188)
			});
			treeNode35.Nodes.Add(new TreeNode("CJT188 OverTcp")
			{
				Tag = typeof(FormCJT188OverTcp)
			});
			treeView1.Nodes.Add(treeNode35);
			TreeNode treeNode36 = new TreeNode("Toledo [托利多]", 18, 18);
			treeNode36.Nodes.Add(GetTreeNodeByIndex("Serial [串口通讯]", 18, typeof(FormToledoSerial)));
			treeNode36.Nodes.Add(GetTreeNodeByIndex("Tcp Server [网口服务]", 18, typeof(FormToledoTcpServer)));
			treeView1.Nodes.Add(treeNode36);
			TreeNode treeNode37 = new TreeNode("Control [控件库]");
			treeNode37.Nodes.Add(new TreeNode("Simple Control")
			{
				Tag = typeof(FormBasicControl)
			});
			treeNode37.Nodes.Add(new TreeNode("Gauge [仪表盘]")
			{
				Tag = typeof(FormGauge)
			});
			treeNode37.Nodes.Add(new TreeNode("Curve [曲线]")
			{
				Tag = typeof(FormCurve)
			});
			treeNode37.Nodes.Add(new TreeNode("Pie Chart [饼图]")
			{
				Tag = typeof(FormPieChart)
			});
			treeNode37.Nodes.Add(new TreeNode("Pipe [管道组态]")
			{
				Tag = typeof(FormPipe)
			});
			treeView1.Nodes.Add(treeNode37);
			TreeNode treeNode38 = new TreeNode("Algorithms [算法]");
			treeNode38.Nodes.Add(new TreeNode("Fourier [傅立叶算法]")
			{
				Tag = typeof(FourierTransform)
			});
			treeNode38.Nodes.Add(new TreeNode("Fourier [傅立叶滤波]")
			{
				Tag = typeof(FourierFilter)
			});
			treeNode38.Nodes.Add(new TreeNode("PID [Pid模拟]")
			{
				Tag = typeof(FormPid)
			});
			treeNode38.Nodes.Add(new TreeNode("RSA [加密解密]")
			{
				Tag = typeof(FormRSADebug)
			});
			treeNode38.Nodes.Add(new TreeNode("Cert [Hsl证书]")
			{
				Tag = typeof(FormHslCertificate)
			});
			treeView1.Nodes.Add(treeNode38);
			TreeNode treeNode39 = new TreeNode("Special [特殊协议]");
			treeNode39.Nodes.Add(new TreeNode("Open Protocol")
			{
				Tag = typeof(FormOpenProtocol)
			});
			treeNode39.Nodes.Add(new TreeNode("南京自动化 DCS")
			{
				Tag = typeof(FormDcsNanJingAuto)
			});
			treeNode39.Nodes.Add(new TreeNode("Knx")
			{
				Tag = typeof(FormKnx)
			});
			treeView1.Nodes.Add(treeNode39);
		}

		private TreeNode GetTreeNodeByIndex(string name, int index, Type form)
		{
			formIconImageIndex.Add(form.Name, index);
			return new TreeNode(name, index, index)
			{
				Tag = form
			};
		}

		private void AddTreeNode(TreeView treeView, TreeNode parent, XElement element, string key)
		{
			int num = key.IndexOf(':');
			if (num <= 0)
			{
				TreeNode treeNode = new TreeNode(key);
				treeNode.Tag = element;
				string value = element.Attribute(DemoDeviceList.XmlType).Value;
				if (formIconImageIndex.ContainsKey(value))
				{
					treeNode.ImageIndex = formIconImageIndex[value];
					treeNode.SelectedImageIndex = formIconImageIndex[value];
				}
				else
				{
					treeNode.ImageIndex = 0;
					treeNode.SelectedImageIndex = 0;
				}
				if (parent == null)
				{
					treeView.Nodes.Add(treeNode);
				}
				else
				{
					parent.Nodes.Add(treeNode);
				}
			}
			else
			{
				TreeNode treeNode2 = null;
				if (parent == null)
				{
					for (int i = 0; i < treeView.Nodes.Count; i++)
					{
						if (treeView.Nodes[i].Text == key.Substring(0, num))
						{
							treeNode2 = treeView.Nodes[i];
							break;
						}
					}
				}
				else
				{
					for (int j = 0; j < parent.Nodes.Count; j++)
					{
						if (parent.Nodes[j].Text == key.Substring(0, num))
						{
							treeNode2 = parent.Nodes[j];
							break;
						}
					}
				}
				if (treeNode2 == null)
				{
					treeNode2 = new TreeNode(key.Substring(0, num));
					treeNode2.ImageKey = "Class_489";
					treeNode2.SelectedImageKey = "Class_489";
					AddTreeNode(treeView, treeNode2, element, key.Substring(num + 1));
					if (parent == null)
					{
						treeView.Nodes.Add(treeNode2);
					}
					else
					{
						parent.Nodes.Add(treeNode2);
					}
				}
				else
				{
					AddTreeNode(treeView, treeNode2, element, key.Substring(num + 1));
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
			treeView1 = new System.Windows.Forms.TreeView();
			SuspendLayout();
			treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			treeView1.Location = new System.Drawing.Point(0, 0);
			treeView1.Name = "treeView1";
			treeView1.Size = new System.Drawing.Size(234, 640);
			treeView1.TabIndex = 1;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(234, 640);
			base.Controls.Add(treeView1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormPanelLeft";
			Text = "Device List";
			base.Load += new System.EventHandler(FormPanelLeft_Load);
			ResumeLayout(false);
		}
	}
}
