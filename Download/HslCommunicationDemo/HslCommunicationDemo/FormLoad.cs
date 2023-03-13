using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Enthernet;
using HslCommunication.Profinet.Siemens;
using HslCommunicationDemo.Algorithms;
using HslCommunicationDemo.BarCode;
using HslCommunicationDemo.Control;
using HslCommunicationDemo.Redis;
using HslCommunicationDemo.Robot;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormLoad : Form
	{
		public static Color ThemeColor = Color.AliceBlue;

		private IContainer components = null;

		private GroupBox groupBox1;

		private Button button3;

		private Button button2;

		private Button button1;

		private GroupBox groupBox2;

		private Button button6;

		private GroupBox groupBox3;

		private Button button4;

		private Button button5;

		private Button button7;

		private GroupBox groupBox4;

		private Button button8;

		private Button button9;

		private Button button10;

		private GroupBox groupBox5;

		private Button button11;

		private Button button12;

		private Button button13;

		private Button button14;

		private Button button15;

		private GroupBox groupBox6;

		private Button button16;

		private Button button18;

		private Button button17;

		private Button button19;

		private Button button20;

		private Button button21;

		private Button button22;

		private GroupBox groupBox7;

		private Button button23;

		private GroupBox groupBox8;

		private Button button24;

		private Button button25;

		private Button button27;

		private Button button26;

		private Button button28;

		private Button button29;

		private Button button30;

		private Button button31;

		private Button button32;

		private GroupBox groupBox9;

		private Button button33;

		private Button button34;

		private GroupBox groupBox10;

		private Button button35;

		private Button button36;

		private GroupBox groupBox11;

		private Button button37;

		private Button button38;

		private Button button39;

		private MenuStrip menuStrip1;

		private ToolStripMenuItem aboutToolStripMenuItem;

		private ToolStripMenuItem blogsToolStripMenuItem;

		private ToolStripMenuItem webSideToolStripMenuItem;

		private ToolStripMenuItem mesDemoToolStripMenuItem;

		private ToolStripMenuItem rToolStripMenuItem;

		private ToolStripMenuItem 简体中文ToolStripMenuItem;

		private ToolStripMenuItem englishToolStripMenuItem;

		private ToolStripMenuItem 日志ToolStripMenuItem;

		private ToolStripMenuItem verisonToolStripMenuItem;

		private GroupBox groupBox12;

		private Button button40;

		private Button button41;

		private Button button42;

		private Button button43;

		private ToolStripMenuItem 免责条款ToolStripMenuItem;

		private LinkLabel linkLabel1;

		private Label label1;

		private Button button44;

		private Button button45;

		private Button button46;

		private Button button47;

		private Button button48;

		private GroupBox groupBox13;

		private Button button50;

		private Button button49;

		private Button button51;

		private Button button52;

		private Button button53;

		private Button button54;

		private ToolStripMenuItem 论坛toolStripMenuItem;

		private Label label2;

		private GroupBox groupBox14;

		private Button button55;

		private Button button56;

		private Button button57;

		private Button button58;

		private Button button59;

		private Button button60;

		private ToolStripMenuItem 授权ToolStripMenuItem;

		private ToolStripMenuItem support赞助ToolStripMenuItem;

		private Button button61;

		private GroupBox groupBox15;

		private Button button63;

		private GroupBox groupBox16;

		private Button button62;

		private GroupBox groupBox17;

		private Button button64;

		private Button button65;

		private Button button66;

		private Button button67;

		private Button button68;

		private Button button69;

		private Button button70;

		public FormLoad()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormSiemens formSiemens = new FormSiemens(SiemensPLCS.S1200))
			{
				formSiemens.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormModbus formModbus = new FormModbus())
			{
				formModbus.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormMelsecBinary formMelsecBinary = new FormMelsecBinary())
			{
				formMelsecBinary.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormSiemens formSiemens = new FormSiemens(SiemensPLCS.S1500))
			{
				formSiemens.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormSiemens formSiemens = new FormSiemens(SiemensPLCS.S300))
			{
				formSiemens.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button39_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormSiemens formSiemens = new FormSiemens(SiemensPLCS.S400))
			{
				formSiemens.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormSiemens formSiemens = new FormSiemens(SiemensPLCS.S200Smart))
			{
				formSiemens.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start("http://118.24.36.220:8080/html/c136d3de-eab7-9b0f-4bdf-d891297c8018.htm");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormMelsecAscii formMelsecAscii = new FormMelsecAscii())
			{
				formMelsecAscii.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void linkLabel2_Click(object sender, EventArgs e)
		{
			FormSupport formSupport = new FormSupport();
			formSupport.ShowDialog();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormSimplifyNet formSimplifyNet = new FormSimplifyNet())
			{
				formSimplifyNet.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormUdpNet formUdpNet = new FormUdpNet())
			{
				formUdpNet.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button10_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormSiemensFW formSiemensFW = new FormSiemensFW())
			{
				formSiemensFW.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button11_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormOmron formOmron = new FormOmron())
			{
				formOmron.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button12_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormFileClient formFileClient = new FormFileClient())
			{
				formFileClient.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button14_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormComplexNet formComplexNet = new FormComplexNet())
			{
				formComplexNet.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button13_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormMelsec1EBinary formMelsec1EBinary = new FormMelsec1EBinary())
			{
				formMelsec1EBinary.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button15_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormLogNet formLogNet = new FormLogNet())
			{
				formLogNet.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button16_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormBasicControl formBasicControl = new FormBasicControl())
			{
				formBasicControl.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button17_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormGauge formGauge = new FormGauge())
			{
				formGauge.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button18_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormCurve formCurve = new FormCurve())
			{
				formCurve.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button19_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormModbusAlien formModbusAlien = new FormModbusAlien())
			{
				formModbusAlien.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void FormLoad_Load(object sender, EventArgs e)
		{
			ThemeColor = menuStrip1.BackColor;
			verisonToolStripMenuItem.Text = "Version: " + SoftBasic.FrameworkVersion.ToString();
			if (Settings1.Default.language == 1)
			{
				if (CultureInfo.CurrentCulture.ToString().StartsWith("zh"))
				{
					Program.Language = 1;
					Language(Program.Language);
				}
				else
				{
					StringResources.SeteLanguageEnglish();
					Program.Language = 2;
					Language(Program.Language);
				}
			}
			else
			{
				Program.Language = 2;
				StringResources.SeteLanguageEnglish();
				Language(Program.Language);
			}
			support赞助ToolStripMenuItem.Click += Support赞助ToolStripMenuItem_Click;
		}

		private void Support赞助ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (FormSupport formSupport = new FormSupport())
			{
				formSupport.ShowDialog();
			}
		}

		private void Language(int language)
		{
			if (language == 1)
			{
				button19.Text = "异形 Modbus Tcp";
				button24.Text = "串口调试助手";
				button30.Text = "以太网调试助手";
				button25.Text = "傅立叶变换";
				button26.Text = "订单号测试";
				button27.Text = "注册码功能";
				button28.Text = "邮件发送";
				button31.Text = "字节变换";
				button29.Text = "异形 Simplify Net";
				button16.Text = "常用简单控件";
				Text = "HslCommunication 测试工具";
				免责条款ToolStripMenuItem.Text = "免责条款";
				论坛toolStripMenuItem.Text = "论坛";
				授权ToolStripMenuItem.Text = "授权";
			}
			else
			{
				button19.Text = "Alien Modbus Tcp";
				button24.Text = "Serial debug";
				button30.Text = "Tcp/Ip debug";
				button25.Text = "Fourier transformation";
				button26.Text = "OrderNumbe";
				button27.Text = "Registration";
				button28.Text = "Mail Send";
				button31.Text = "Bytes Transform";
				button29.Text = "Alien Simplify Net";
				button16.Text = "Simple Control";
				Text = "HslCommunication Test Tool";
				论坛toolStripMenuItem.Text = "BBS";
				免责条款ToolStripMenuItem.Text = "Disclaimer";
				授权ToolStripMenuItem.Text = "Authorize";
			}
		}

		private void LinkLabel6_Click(object sender, EventArgs e)
		{
			StringResources.SeteLanguageEnglish();
			Program.Language = 2;
			Language(Program.Language);
			MessageBox.Show("Select English!");
		}

		private void LinkLabel5_Click(object sender, EventArgs e)
		{
			StringResources.SetLanguageChinese();
			Program.Language = 1;
			Language(Program.Language);
			MessageBox.Show("已选择中文");
		}

		private void 论坛toolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start("http://bbs.hslcommunication.cn/");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button20_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormPieChart formPieChart = new FormPieChart())
			{
				formPieChart.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button21_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormModbusRtu formModbusRtu = new FormModbusRtu())
			{
				formModbusRtu.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button22_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormPushNet formPushNet = new FormPushNet())
			{
				formPushNet.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button23_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormEfort formEfort = new FormEfort())
			{
				formEfort.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button24_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormSerialDebug formSerialDebug = new FormSerialDebug())
			{
				formSerialDebug.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button25_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FourierTransform fourierTransform = new FourierTransform())
			{
				fourierTransform.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button26_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormSeqCreate formSeqCreate = new FormSeqCreate())
			{
				formSeqCreate.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button27_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormRegister formRegister = new FormRegister())
			{
				formRegister.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button28_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormMail formMail = new FormMail())
			{
				formMail.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button29_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormSimplifyNetAlien formSimplifyNetAlien = new FormSimplifyNetAlien())
			{
				formSimplifyNetAlien.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button30_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormTcpDebug formTcpDebug = new FormTcpDebug())
			{
				formTcpDebug.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button31_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormByteTransfer formByteTransfer = new FormByteTransfer())
			{
				formByteTransfer.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button32_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormMelsecSerial formMelsecSerial = new FormMelsecSerial())
			{
				formMelsecSerial.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button33_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormAllenBrandly formAllenBrandly = new FormAllenBrandly())
			{
				formAllenBrandly.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button34_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormModbusAscii formModbusAscii = new FormModbusAscii())
			{
				formModbusAscii.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button35_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormPanasonicMew formPanasonicMew = new FormPanasonicMew())
			{
				formPanasonicMew.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button36_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormSiemensPPI formSiemensPPI = new FormSiemensPPI())
			{
				formSiemensPPI.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button37_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormDAM3601 formDAM = new FormDAM3601())
			{
				formDAM.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button38_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormMelsecLinks formMelsecLinks = new FormMelsecLinks())
			{
				formMelsecLinks.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		public static void OpenWebside(string url)
		{
			try
			{
				Process.Start(url);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void blogsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenWebside("http://www.cnblogs.com/dathlin/p/7703805.html");
		}

		private void webSideToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenWebside("http://www.hslcommunication.cn/");
		}

		private void mesDemoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenWebside("http://118.24.36.220:8081/");
		}

		private void gitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenWebside("https://github.com/dathlin/HslCommunication");
		}

		private void patronageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormSupport formSupport = new FormSupport();
			formSupport.ShowDialog();
		}

		private void 简体中文ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringResources.SetLanguageChinese();
			Program.Language = 1;
			Settings1.Default.language = Program.Language;
			Settings1.Default.Save();
			Language(Program.Language);
			MessageBox.Show("已选择中文");
		}

		private void englishToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringResources.SeteLanguageEnglish();
			Program.Language = 2;
			Settings1.Default.language = Program.Language;
			Settings1.Default.Save();
			Language(Program.Language);
			MessageBox.Show("Select English!");
		}

		private void 日志ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenWebside("http://118.24.36.220:8080/html/c136d3de-eab7-9b0f-4bdf-d891297c8018.htm");
		}

		private void button40_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormRedisClient formRedisClient = new FormRedisClient())
			{
				formRedisClient.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button41_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormPipe formPipe = new FormPipe())
			{
				formPipe.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button42_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (RedisBrowser redisBrowser = new RedisBrowser())
			{
				redisBrowser.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button43_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormRedisSubscribe formRedisSubscribe = new FormRedisSubscribe())
			{
				formRedisSubscribe.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void FormLoad_Shown(object sender, EventArgs e)
		{
			ThreadPool.QueueUserWorkItem(ThreadPoolCheckVersion, null);
		}

		private void ThreadPoolCheckVersion(object obj)
		{
			Thread.Sleep(100);
			NetSimplifyClient netSimplifyClient = new NetSimplifyClient("118.24.36.220", 18467);
			OperateResult<NetHandle, string> read = netSimplifyClient.ReadCustomerFromServer(1, SoftBasic.FrameworkVersion.ToString());
			if (read.IsSuccess)
			{
				SystemVersion sV = new SystemVersion(read.Content2);
				if (sV > SoftBasic.FrameworkVersion)
				{
					Invoke((Action)delegate
					{
						if (MessageBox.Show("服务器有新版本：" + read.Content2 + Environment.NewLine + "是否启动更新？", "检测到更新", MessageBoxButtons.YesNo) == DialogResult.Yes)
						{
							try
							{
								Process.Start(Application.StartupPath + "\\软件自动更新.exe");
								Thread.Sleep(50);
								Close();
							}
							catch (Exception ex)
							{
								MessageBox.Show("更新软件丢失，无法启动更新： " + ex.Message);
							}
						}
					});
				}
			}
		}

		private void 免责条款ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormDisclaimer formDisclaimer = new FormDisclaimer())
			{
				formDisclaimer.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			OpenWebside("https://github.com/dathlin/HslControlsDemo");
		}

		private void rToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (FormAuthor formAuthor = new FormAuthor())
			{
				formAuthor.ShowDialog();
			}
		}

		private void button44_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormEfortPrevious formEfortPrevious = new FormEfortPrevious())
			{
				formEfortPrevious.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button45_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormModbusServer formModbusServer = new FormModbusServer())
			{
				formModbusServer.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button46_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormS7Server formS7Server = new FormS7Server())
			{
				formS7Server.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button47_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormMelsec3C formMelsec3C = new FormMelsec3C())
			{
				formMelsec3C.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button48_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormOmronHostLink formOmronHostLink = new FormOmronHostLink())
			{
				formOmronHostLink.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button49_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormKeyenceBinary formKeyenceBinary = new FormKeyenceBinary())
			{
				formKeyenceBinary.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button50_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormKeyenceAscii formKeyenceAscii = new FormKeyenceAscii())
			{
				formKeyenceAscii.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button51_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormKuka formKuka = new FormKuka())
			{
				formKuka.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button52_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormOmronUdp formOmronUdp = new FormOmronUdp())
			{
				formOmronUdp.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void Button53_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormSiemens formSiemens = new FormSiemens(SiemensPLCS.S200))
			{
				formSiemens.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void button54_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormKeyenceNanoSerial formKeyenceNanoSerial = new FormKeyenceNanoSerial())
			{
				formKeyenceNanoSerial.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void Button55_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormLsisFEnet formLsisFEnet = new FormLsisFEnet())
			{
				formLsisFEnet.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void Button56_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormMcServer formMcServer = new FormMcServer())
			{
				formMcServer.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void Button57_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormLsisCnet formLsisCnet = new FormLsisCnet())
			{
				formLsisCnet.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void Button58_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormPanasonicBinary formPanasonicBinary = new FormPanasonicBinary())
			{
				formPanasonicBinary.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void Button59_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormLSisServer formLSisServer = new FormLSisServer())
			{
				formLSisServer.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void Button61_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormOmronCip formOmronCip = new FormOmronCip())
			{
				formOmronCip.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void Button63_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormFatekPrograme formFatekPrograme = new FormFatekPrograme())
			{
				formFatekPrograme.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void Button62_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormFujiSPB formFujiSPB = new FormFujiSPB())
			{
				formFujiSPB.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void Button64_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormOpenProtocol formOpenProtocol = new FormOpenProtocol())
			{
				formOpenProtocol.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void Button65_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormPid formPid = new FormPid())
			{
				formPid.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void Button66_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormSickBarCode formSickBarCode = new FormSickBarCode())
			{
				formSickBarCode.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void Button67_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormTcpServer formTcpServer = new FormTcpServer())
			{
				formTcpServer.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void Button68_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormModbusRtuOverTcp formModbusRtuOverTcp = new FormModbusRtuOverTcp())
			{
				formModbusRtuOverTcp.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void Button69_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FormABBWebApi formABBWebApi = new FormABBWebApi())
			{
				formABBWebApi.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
		}

		private void Button70_Click(object sender, EventArgs e)
		{
			Hide();
			Thread.Sleep(200);
			using (FourierFilter fourierFilter = new FourierFilter())
			{
				fourierFilter.ShowDialog();
			}
			Thread.Sleep(200);
			Show();
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
			groupBox1 = new System.Windows.Forms.GroupBox();
			button53 = new System.Windows.Forms.Button();
			button46 = new System.Windows.Forms.Button();
			button39 = new System.Windows.Forms.Button();
			button36 = new System.Windows.Forms.Button();
			button10 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			groupBox2 = new System.Windows.Forms.GroupBox();
			button68 = new System.Windows.Forms.Button();
			button45 = new System.Windows.Forms.Button();
			button34 = new System.Windows.Forms.Button();
			button21 = new System.Windows.Forms.Button();
			button19 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			groupBox3 = new System.Windows.Forms.GroupBox();
			button56 = new System.Windows.Forms.Button();
			button47 = new System.Windows.Forms.Button();
			button38 = new System.Windows.Forms.Button();
			button32 = new System.Windows.Forms.Button();
			button13 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			groupBox4 = new System.Windows.Forms.GroupBox();
			button29 = new System.Windows.Forms.Button();
			button22 = new System.Windows.Forms.Button();
			button15 = new System.Windows.Forms.Button();
			button14 = new System.Windows.Forms.Button();
			button12 = new System.Windows.Forms.Button();
			button9 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			groupBox5 = new System.Windows.Forms.GroupBox();
			button61 = new System.Windows.Forms.Button();
			button52 = new System.Windows.Forms.Button();
			button48 = new System.Windows.Forms.Button();
			button11 = new System.Windows.Forms.Button();
			groupBox6 = new System.Windows.Forms.GroupBox();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			label1 = new System.Windows.Forms.Label();
			button41 = new System.Windows.Forms.Button();
			button20 = new System.Windows.Forms.Button();
			button18 = new System.Windows.Forms.Button();
			button17 = new System.Windows.Forms.Button();
			button16 = new System.Windows.Forms.Button();
			groupBox7 = new System.Windows.Forms.GroupBox();
			button69 = new System.Windows.Forms.Button();
			button60 = new System.Windows.Forms.Button();
			button51 = new System.Windows.Forms.Button();
			button44 = new System.Windows.Forms.Button();
			button23 = new System.Windows.Forms.Button();
			groupBox8 = new System.Windows.Forms.GroupBox();
			button31 = new System.Windows.Forms.Button();
			button30 = new System.Windows.Forms.Button();
			button28 = new System.Windows.Forms.Button();
			button27 = new System.Windows.Forms.Button();
			button26 = new System.Windows.Forms.Button();
			button25 = new System.Windows.Forms.Button();
			button24 = new System.Windows.Forms.Button();
			groupBox9 = new System.Windows.Forms.GroupBox();
			button33 = new System.Windows.Forms.Button();
			groupBox10 = new System.Windows.Forms.GroupBox();
			button58 = new System.Windows.Forms.Button();
			button35 = new System.Windows.Forms.Button();
			groupBox11 = new System.Windows.Forms.GroupBox();
			button37 = new System.Windows.Forms.Button();
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			blogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			webSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			mesDemoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			rToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			support赞助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			简体中文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			论坛toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			verisonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			免责条款ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			授权ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			groupBox12 = new System.Windows.Forms.GroupBox();
			button43 = new System.Windows.Forms.Button();
			button42 = new System.Windows.Forms.Button();
			button40 = new System.Windows.Forms.Button();
			groupBox13 = new System.Windows.Forms.GroupBox();
			button54 = new System.Windows.Forms.Button();
			button50 = new System.Windows.Forms.Button();
			button49 = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			groupBox14 = new System.Windows.Forms.GroupBox();
			button59 = new System.Windows.Forms.Button();
			button57 = new System.Windows.Forms.Button();
			button55 = new System.Windows.Forms.Button();
			groupBox15 = new System.Windows.Forms.GroupBox();
			button63 = new System.Windows.Forms.Button();
			groupBox16 = new System.Windows.Forms.GroupBox();
			button62 = new System.Windows.Forms.Button();
			groupBox17 = new System.Windows.Forms.GroupBox();
			button70 = new System.Windows.Forms.Button();
			button67 = new System.Windows.Forms.Button();
			button66 = new System.Windows.Forms.Button();
			button65 = new System.Windows.Forms.Button();
			button64 = new System.Windows.Forms.Button();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox4.SuspendLayout();
			groupBox5.SuspendLayout();
			groupBox6.SuspendLayout();
			groupBox7.SuspendLayout();
			groupBox8.SuspendLayout();
			groupBox9.SuspendLayout();
			groupBox10.SuspendLayout();
			groupBox11.SuspendLayout();
			menuStrip1.SuspendLayout();
			groupBox12.SuspendLayout();
			groupBox13.SuspendLayout();
			groupBox14.SuspendLayout();
			groupBox15.SuspendLayout();
			groupBox16.SuspendLayout();
			groupBox17.SuspendLayout();
			SuspendLayout();
			groupBox1.Controls.Add(button53);
			groupBox1.Controls.Add(button46);
			groupBox1.Controls.Add(button39);
			groupBox1.Controls.Add(button36);
			groupBox1.Controls.Add(button10);
			groupBox1.Controls.Add(button5);
			groupBox1.Controls.Add(button3);
			groupBox1.Controls.Add(button2);
			groupBox1.Controls.Add(button1);
			groupBox1.Location = new System.Drawing.Point(203, 29);
			groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox1.Size = new System.Drawing.Size(186, 335);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Siemens PLC(西门子 PLC)";
			button53.Location = new System.Drawing.Point(18, 104);
			button53.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button53.Name = "button53";
			button53.Size = new System.Drawing.Size(150, 32);
			button53.TabIndex = 8;
			button53.Text = "s7-200";
			button53.UseVisualStyleBackColor = true;
			button53.Click += new System.EventHandler(Button53_Click);
			button46.Location = new System.Drawing.Point(18, 264);
			button46.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button46.Name = "button46";
			button46.Size = new System.Drawing.Size(150, 32);
			button46.TabIndex = 7;
			button46.Text = "S7 Virtual Server";
			button46.UseVisualStyleBackColor = true;
			button46.Click += new System.EventHandler(button46_Click);
			button39.Location = new System.Drawing.Point(98, 64);
			button39.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button39.Name = "button39";
			button39.Size = new System.Drawing.Size(70, 32);
			button39.TabIndex = 6;
			button39.Text = "s7-400";
			button39.UseVisualStyleBackColor = true;
			button39.Click += new System.EventHandler(button39_Click);
			button36.Location = new System.Drawing.Point(18, 224);
			button36.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button36.Name = "button36";
			button36.Size = new System.Drawing.Size(150, 32);
			button36.TabIndex = 5;
			button36.Text = "PPI";
			button36.UseVisualStyleBackColor = true;
			button36.Click += new System.EventHandler(button36_Click);
			button10.Location = new System.Drawing.Point(18, 184);
			button10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(150, 32);
			button10.TabIndex = 4;
			button10.Text = "Fetch/Write";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(button10_Click);
			button5.Location = new System.Drawing.Point(18, 144);
			button5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(150, 32);
			button5.TabIndex = 3;
			button5.Text = "s7-200Smart";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			button3.Location = new System.Drawing.Point(18, 64);
			button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(70, 32);
			button3.TabIndex = 2;
			button3.Text = "s7-300";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button2.Location = new System.Drawing.Point(98, 24);
			button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(70, 32);
			button2.TabIndex = 1;
			button2.Text = "s7-1500";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(18, 24);
			button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(70, 32);
			button1.TabIndex = 0;
			button1.Text = "s7-1200";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			groupBox2.Controls.Add(button68);
			groupBox2.Controls.Add(button45);
			groupBox2.Controls.Add(button34);
			groupBox2.Controls.Add(button21);
			groupBox2.Controls.Add(button19);
			groupBox2.Controls.Add(button6);
			groupBox2.Location = new System.Drawing.Point(395, 29);
			groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox2.Size = new System.Drawing.Size(185, 335);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "Modbus";
			button68.Location = new System.Drawing.Point(19, 224);
			button68.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button68.Name = "button68";
			button68.Size = new System.Drawing.Size(150, 32);
			button68.TabIndex = 5;
			button68.Text = "ModbusRtu Over Tcp";
			button68.UseVisualStyleBackColor = true;
			button68.Click += new System.EventHandler(Button68_Click);
			button45.Location = new System.Drawing.Point(19, 184);
			button45.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button45.Name = "button45";
			button45.Size = new System.Drawing.Size(150, 32);
			button45.TabIndex = 4;
			button45.Text = "Modbus Server";
			button45.UseVisualStyleBackColor = true;
			button45.Click += new System.EventHandler(button45_Click);
			button34.Location = new System.Drawing.Point(19, 144);
			button34.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button34.Name = "button34";
			button34.Size = new System.Drawing.Size(150, 32);
			button34.TabIndex = 3;
			button34.Text = "Modbus Ascii";
			button34.UseVisualStyleBackColor = true;
			button34.Click += new System.EventHandler(button34_Click);
			button21.Location = new System.Drawing.Point(19, 104);
			button21.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button21.Name = "button21";
			button21.Size = new System.Drawing.Size(150, 32);
			button21.TabIndex = 2;
			button21.Text = "Modbus Rtu";
			button21.UseVisualStyleBackColor = true;
			button21.Click += new System.EventHandler(button21_Click);
			button19.Location = new System.Drawing.Point(19, 64);
			button19.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button19.Name = "button19";
			button19.Size = new System.Drawing.Size(150, 32);
			button19.TabIndex = 1;
			button19.Text = "异形 Modbus Tcp";
			button19.UseVisualStyleBackColor = true;
			button19.Click += new System.EventHandler(button19_Click);
			button6.Location = new System.Drawing.Point(19, 24);
			button6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(150, 32);
			button6.TabIndex = 0;
			button6.Text = "Modbus Tcp";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			groupBox3.Controls.Add(button56);
			groupBox3.Controls.Add(button47);
			groupBox3.Controls.Add(button38);
			groupBox3.Controls.Add(button32);
			groupBox3.Controls.Add(button13);
			groupBox3.Controls.Add(button7);
			groupBox3.Controls.Add(button4);
			groupBox3.Location = new System.Drawing.Point(9, 29);
			groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox3.Name = "groupBox3";
			groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox3.Size = new System.Drawing.Size(183, 335);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "Melsec PLC(三菱 PLC)";
			button56.Location = new System.Drawing.Point(15, 264);
			button56.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button56.Name = "button56";
			button56.Size = new System.Drawing.Size(150, 32);
			button56.TabIndex = 7;
			button56.Text = "Mc Virtual Server";
			button56.UseVisualStyleBackColor = true;
			button56.Click += new System.EventHandler(Button56_Click);
			button47.Location = new System.Drawing.Point(15, 224);
			button47.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button47.Name = "button47";
			button47.Size = new System.Drawing.Size(150, 32);
			button47.TabIndex = 6;
			button47.Text = "A-3C (format1)";
			button47.UseVisualStyleBackColor = true;
			button47.Click += new System.EventHandler(button47_Click);
			button38.Location = new System.Drawing.Point(15, 184);
			button38.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button38.Name = "button38";
			button38.Size = new System.Drawing.Size(150, 32);
			button38.TabIndex = 5;
			button38.Text = "Fx Links【485】";
			button38.UseVisualStyleBackColor = true;
			button38.Click += new System.EventHandler(button38_Click);
			button32.Location = new System.Drawing.Point(15, 144);
			button32.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button32.Name = "button32";
			button32.Size = new System.Drawing.Size(150, 32);
			button32.TabIndex = 4;
			button32.Text = "Fx Serial【编程口】";
			button32.UseVisualStyleBackColor = true;
			button32.Click += new System.EventHandler(button32_Click);
			button13.Location = new System.Drawing.Point(15, 104);
			button13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button13.Name = "button13";
			button13.Size = new System.Drawing.Size(150, 32);
			button13.TabIndex = 3;
			button13.Text = "A-1E (Binary)";
			button13.UseVisualStyleBackColor = true;
			button13.Click += new System.EventHandler(button13_Click);
			button7.Location = new System.Drawing.Point(15, 64);
			button7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(150, 32);
			button7.TabIndex = 2;
			button7.Text = "MC(ASCII)";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			button4.Location = new System.Drawing.Point(15, 24);
			button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(150, 32);
			button4.TabIndex = 1;
			button4.Text = "MC (Binary)";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			groupBox4.Controls.Add(button29);
			groupBox4.Controls.Add(button22);
			groupBox4.Controls.Add(button15);
			groupBox4.Controls.Add(button14);
			groupBox4.Controls.Add(button12);
			groupBox4.Controls.Add(button9);
			groupBox4.Controls.Add(button8);
			groupBox4.Location = new System.Drawing.Point(9, 372);
			groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox4.Name = "groupBox4";
			groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox4.Size = new System.Drawing.Size(183, 315);
			groupBox4.TabIndex = 7;
			groupBox4.TabStop = false;
			groupBox4.Text = "Hsl Support(HSL 协议)";
			button29.Location = new System.Drawing.Point(15, 64);
			button29.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button29.Name = "button29";
			button29.Size = new System.Drawing.Size(150, 32);
			button29.TabIndex = 6;
			button29.Text = "异形 Simplify Net";
			button29.UseVisualStyleBackColor = true;
			button29.Click += new System.EventHandler(button29_Click);
			button22.Location = new System.Drawing.Point(15, 264);
			button22.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button22.Name = "button22";
			button22.Size = new System.Drawing.Size(150, 32);
			button22.TabIndex = 5;
			button22.Text = "Push Net (消息推送)";
			button22.UseVisualStyleBackColor = true;
			button22.Click += new System.EventHandler(button22_Click);
			button15.Location = new System.Drawing.Point(15, 224);
			button15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button15.Name = "button15";
			button15.Size = new System.Drawing.Size(150, 32);
			button15.TabIndex = 4;
			button15.Text = "Log (日志记录)";
			button15.UseVisualStyleBackColor = true;
			button15.Click += new System.EventHandler(button15_Click);
			button14.Location = new System.Drawing.Point(15, 104);
			button14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button14.Name = "button14";
			button14.Size = new System.Drawing.Size(150, 32);
			button14.TabIndex = 3;
			button14.Text = "Complex (复杂交互)";
			button14.UseVisualStyleBackColor = true;
			button14.Click += new System.EventHandler(button14_Click);
			button12.Location = new System.Drawing.Point(15, 184);
			button12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(150, 32);
			button12.TabIndex = 2;
			button12.Text = "File Net (文件收发)";
			button12.UseVisualStyleBackColor = true;
			button12.Click += new System.EventHandler(button12_Click);
			button9.Location = new System.Drawing.Point(15, 144);
			button9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(150, 32);
			button9.TabIndex = 1;
			button9.Text = "Udp Net (Udp数据)";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			button8.Location = new System.Drawing.Point(15, 24);
			button8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(150, 32);
			button8.TabIndex = 0;
			button8.Text = "Simplify Net (请求交互)";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			groupBox5.Controls.Add(button61);
			groupBox5.Controls.Add(button52);
			groupBox5.Controls.Add(button48);
			groupBox5.Controls.Add(button11);
			groupBox5.Location = new System.Drawing.Point(586, 29);
			groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox5.Name = "groupBox5";
			groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox5.Size = new System.Drawing.Size(185, 187);
			groupBox5.TabIndex = 11;
			groupBox5.TabStop = false;
			groupBox5.Text = "Omron PLC(欧姆龙 PLC)";
			button61.Location = new System.Drawing.Point(19, 144);
			button61.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button61.Name = "button61";
			button61.Size = new System.Drawing.Size(150, 32);
			button61.TabIndex = 3;
			button61.Text = "CIP net";
			button61.UseVisualStyleBackColor = true;
			button61.Click += new System.EventHandler(Button61_Click);
			button52.Location = new System.Drawing.Point(19, 64);
			button52.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button52.Name = "button52";
			button52.Size = new System.Drawing.Size(150, 32);
			button52.TabIndex = 2;
			button52.Text = "Fins Udp";
			button52.UseVisualStyleBackColor = true;
			button52.Click += new System.EventHandler(button52_Click);
			button48.Location = new System.Drawing.Point(19, 104);
			button48.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button48.Name = "button48";
			button48.Size = new System.Drawing.Size(150, 32);
			button48.TabIndex = 1;
			button48.Text = "Fins HostLink";
			button48.UseVisualStyleBackColor = true;
			button48.Click += new System.EventHandler(button48_Click);
			button11.Location = new System.Drawing.Point(19, 24);
			button11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(150, 32);
			button11.TabIndex = 0;
			button11.Text = "Fins Tcp";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			groupBox6.Controls.Add(linkLabel1);
			groupBox6.Controls.Add(label1);
			groupBox6.Controls.Add(button41);
			groupBox6.Controls.Add(button20);
			groupBox6.Controls.Add(button18);
			groupBox6.Controls.Add(button17);
			groupBox6.Controls.Add(button16);
			groupBox6.Location = new System.Drawing.Point(203, 372);
			groupBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox6.Name = "groupBox6";
			groupBox6.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox6.Size = new System.Drawing.Size(185, 315);
			groupBox6.TabIndex = 12;
			groupBox6.TabStop = false;
			groupBox6.Text = "Controls(控件)";
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new System.Drawing.Point(16, 279);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(110, 17);
			linkLabel1.TabIndex = 6;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "HslControlsDemo";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			label1.ForeColor = System.Drawing.Color.Red;
			label1.Location = new System.Drawing.Point(16, 236);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(153, 38);
			label1.TabIndex = 5;
			label1.Text = "控件不再更新，所有控件转移到专门的控件库。";
			button41.Location = new System.Drawing.Point(19, 184);
			button41.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button41.Name = "button41";
			button41.Size = new System.Drawing.Size(150, 32);
			button41.TabIndex = 4;
			button41.Text = "Pipe (管道组态)";
			button41.UseVisualStyleBackColor = true;
			button41.Click += new System.EventHandler(button41_Click);
			button20.Location = new System.Drawing.Point(19, 143);
			button20.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button20.Name = "button20";
			button20.Size = new System.Drawing.Size(150, 32);
			button20.TabIndex = 3;
			button20.Text = "Pie Chart (饼图)";
			button20.UseVisualStyleBackColor = true;
			button20.Click += new System.EventHandler(button20_Click);
			button18.Location = new System.Drawing.Point(19, 103);
			button18.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button18.Name = "button18";
			button18.Size = new System.Drawing.Size(150, 32);
			button18.TabIndex = 2;
			button18.Text = "Curve (曲线)";
			button18.UseVisualStyleBackColor = true;
			button18.Click += new System.EventHandler(button18_Click);
			button17.Location = new System.Drawing.Point(19, 63);
			button17.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button17.Name = "button17";
			button17.Size = new System.Drawing.Size(150, 32);
			button17.TabIndex = 1;
			button17.Text = "Gauge (仪表盘)";
			button17.UseVisualStyleBackColor = true;
			button17.Click += new System.EventHandler(button17_Click);
			button16.Location = new System.Drawing.Point(19, 24);
			button16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button16.Name = "button16";
			button16.Size = new System.Drawing.Size(150, 32);
			button16.TabIndex = 0;
			button16.Text = "Simple Control";
			button16.UseVisualStyleBackColor = true;
			button16.Click += new System.EventHandler(button16_Click);
			groupBox7.Controls.Add(button69);
			groupBox7.Controls.Add(button60);
			groupBox7.Controls.Add(button51);
			groupBox7.Controls.Add(button44);
			groupBox7.Controls.Add(button23);
			groupBox7.Location = new System.Drawing.Point(395, 372);
			groupBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox7.Name = "groupBox7";
			groupBox7.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox7.Size = new System.Drawing.Size(185, 315);
			groupBox7.TabIndex = 14;
			groupBox7.TabStop = false;
			groupBox7.Text = "Robot(机器人)";
			button69.Location = new System.Drawing.Point(19, 184);
			button69.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button69.Name = "button69";
			button69.Size = new System.Drawing.Size(150, 32);
			button69.TabIndex = 4;
			button69.Text = "ABB";
			button69.UseVisualStyleBackColor = true;
			button69.Click += new System.EventHandler(Button69_Click);
			button60.Location = new System.Drawing.Point(19, 143);
			button60.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button60.Name = "button60";
			button60.Size = new System.Drawing.Size(150, 32);
			button60.TabIndex = 3;
			button60.Text = "YRC1000(YASKAWA)";
			button60.UseVisualStyleBackColor = true;
			button51.Location = new System.Drawing.Point(19, 103);
			button51.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button51.Name = "button51";
			button51.Size = new System.Drawing.Size(150, 32);
			button51.TabIndex = 2;
			button51.Text = "KUKA";
			button51.UseVisualStyleBackColor = true;
			button51.Click += new System.EventHandler(button51_Click);
			button44.Location = new System.Drawing.Point(19, 63);
			button44.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button44.Name = "button44";
			button44.Size = new System.Drawing.Size(150, 32);
			button44.TabIndex = 1;
			button44.Text = "EFORT-ER7BC10 (旧版)";
			button44.UseVisualStyleBackColor = true;
			button44.Click += new System.EventHandler(button44_Click);
			button23.Location = new System.Drawing.Point(19, 24);
			button23.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button23.Name = "button23";
			button23.Size = new System.Drawing.Size(150, 32);
			button23.TabIndex = 0;
			button23.Text = "EFORT-ER7BC10";
			button23.UseVisualStyleBackColor = true;
			button23.Click += new System.EventHandler(button23_Click);
			groupBox8.Controls.Add(button31);
			groupBox8.Controls.Add(button30);
			groupBox8.Controls.Add(button28);
			groupBox8.Controls.Add(button27);
			groupBox8.Controls.Add(button26);
			groupBox8.Controls.Add(button25);
			groupBox8.Controls.Add(button24);
			groupBox8.Location = new System.Drawing.Point(777, 372);
			groupBox8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox8.Name = "groupBox8";
			groupBox8.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox8.Size = new System.Drawing.Size(185, 315);
			groupBox8.TabIndex = 15;
			groupBox8.TabStop = false;
			groupBox8.Text = "Others(其他)";
			button31.Location = new System.Drawing.Point(19, 262);
			button31.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button31.Name = "button31";
			button31.Size = new System.Drawing.Size(150, 32);
			button31.TabIndex = 6;
			button31.Text = "Bytes Transform";
			button31.UseVisualStyleBackColor = true;
			button31.Click += new System.EventHandler(button31_Click);
			button30.Location = new System.Drawing.Point(18, 63);
			button30.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button30.Name = "button30";
			button30.Size = new System.Drawing.Size(150, 32);
			button30.TabIndex = 5;
			button30.Text = "Tcp/Ip debug";
			button30.UseVisualStyleBackColor = true;
			button30.Click += new System.EventHandler(button30_Click);
			button28.Location = new System.Drawing.Point(19, 222);
			button28.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button28.Name = "button28";
			button28.Size = new System.Drawing.Size(150, 32);
			button28.TabIndex = 4;
			button28.Text = "Mail Send";
			button28.UseVisualStyleBackColor = true;
			button28.Click += new System.EventHandler(button28_Click);
			button27.Location = new System.Drawing.Point(19, 182);
			button27.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button27.Name = "button27";
			button27.Size = new System.Drawing.Size(150, 32);
			button27.TabIndex = 3;
			button27.Text = "Registration";
			button27.UseVisualStyleBackColor = true;
			button27.Click += new System.EventHandler(button27_Click);
			button26.Location = new System.Drawing.Point(19, 143);
			button26.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button26.Name = "button26";
			button26.Size = new System.Drawing.Size(150, 32);
			button26.TabIndex = 2;
			button26.Text = "OrderNumbe";
			button26.UseVisualStyleBackColor = true;
			button26.Click += new System.EventHandler(button26_Click);
			button25.Location = new System.Drawing.Point(19, 103);
			button25.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(150, 32);
			button25.TabIndex = 1;
			button25.Text = "Fourier transformation";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			button24.Location = new System.Drawing.Point(19, 24);
			button24.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button24.Name = "button24";
			button24.Size = new System.Drawing.Size(150, 32);
			button24.TabIndex = 0;
			button24.Text = "Serial debug";
			button24.UseVisualStyleBackColor = true;
			button24.Click += new System.EventHandler(button24_Click);
			groupBox9.Controls.Add(button33);
			groupBox9.Location = new System.Drawing.Point(968, 133);
			groupBox9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox9.Name = "groupBox9";
			groupBox9.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox9.Size = new System.Drawing.Size(185, 121);
			groupBox9.TabIndex = 18;
			groupBox9.TabStop = false;
			groupBox9.Text = "AB PLC";
			button33.Location = new System.Drawing.Point(19, 24);
			button33.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button33.Name = "button33";
			button33.Size = new System.Drawing.Size(150, 32);
			button33.TabIndex = 0;
			button33.Text = "Logix Tcp";
			button33.UseVisualStyleBackColor = true;
			button33.Click += new System.EventHandler(button33_Click);
			groupBox10.Controls.Add(button58);
			groupBox10.Controls.Add(button35);
			groupBox10.Location = new System.Drawing.Point(777, 29);
			groupBox10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox10.Name = "groupBox10";
			groupBox10.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox10.Size = new System.Drawing.Size(185, 187);
			groupBox10.TabIndex = 19;
			groupBox10.TabStop = false;
			groupBox10.Text = "Panasonic(松下 PLC)";
			button58.Location = new System.Drawing.Point(19, 64);
			button58.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button58.Name = "button58";
			button58.Size = new System.Drawing.Size(150, 32);
			button58.TabIndex = 3;
			button58.Text = "MC-3E (Binary)";
			button58.UseVisualStyleBackColor = true;
			button58.Click += new System.EventHandler(Button58_Click);
			button35.Location = new System.Drawing.Point(19, 24);
			button35.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button35.Name = "button35";
			button35.Size = new System.Drawing.Size(150, 32);
			button35.TabIndex = 0;
			button35.Text = "Mewtocol";
			button35.UseVisualStyleBackColor = true;
			button35.Click += new System.EventHandler(button35_Click);
			groupBox11.Controls.Add(button37);
			groupBox11.Location = new System.Drawing.Point(586, 372);
			groupBox11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox11.Name = "groupBox11";
			groupBox11.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox11.Size = new System.Drawing.Size(185, 156);
			groupBox11.TabIndex = 22;
			groupBox11.TabStop = false;
			groupBox11.Text = "Instrument(仪器仪表)";
			button37.Location = new System.Drawing.Point(19, 24);
			button37.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button37.Name = "button37";
			button37.Size = new System.Drawing.Size(150, 32);
			button37.TabIndex = 0;
			button37.Text = "阿尔泰科技-DAM3601";
			button37.UseVisualStyleBackColor = true;
			button37.Click += new System.EventHandler(button37_Click);
			menuStrip1.BackColor = System.Drawing.Color.MediumPurple;
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[8]
			{
				aboutToolStripMenuItem,
				简体中文ToolStripMenuItem,
				englishToolStripMenuItem,
				论坛toolStripMenuItem,
				日志ToolStripMenuItem,
				verisonToolStripMenuItem,
				免责条款ToolStripMenuItem,
				授权ToolStripMenuItem
			});
			menuStrip1.Location = new System.Drawing.Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new System.Drawing.Size(1159, 25);
			menuStrip1.TabIndex = 26;
			menuStrip1.Text = "menuStrip1";
			aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5]
			{
				blogsToolStripMenuItem,
				webSideToolStripMenuItem,
				mesDemoToolStripMenuItem,
				rToolStripMenuItem,
				support赞助ToolStripMenuItem
			});
			aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
			aboutToolStripMenuItem.Text = "About";
			blogsToolStripMenuItem.Name = "blogsToolStripMenuItem";
			blogsToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
			blogsToolStripMenuItem.Text = "Blogs [博客]";
			blogsToolStripMenuItem.Click += new System.EventHandler(blogsToolStripMenuItem_Click);
			webSideToolStripMenuItem.Name = "webSideToolStripMenuItem";
			webSideToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
			webSideToolStripMenuItem.Text = "WebSide [官网]";
			webSideToolStripMenuItem.Click += new System.EventHandler(webSideToolStripMenuItem_Click);
			mesDemoToolStripMenuItem.Name = "mesDemoToolStripMenuItem";
			mesDemoToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
			mesDemoToolStripMenuItem.Text = "Mes Demo [简易MES系统示例]";
			mesDemoToolStripMenuItem.Click += new System.EventHandler(mesDemoToolStripMenuItem_Click);
			rToolStripMenuItem.Name = "rToolStripMenuItem";
			rToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
			rToolStripMenuItem.Text = "Richard Hu [作者]";
			rToolStripMenuItem.Click += new System.EventHandler(rToolStripMenuItem_Click);
			support赞助ToolStripMenuItem.Name = "support赞助ToolStripMenuItem";
			support赞助ToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
			support赞助ToolStripMenuItem.Text = "Support [赞助]";
			简体中文ToolStripMenuItem.Name = "简体中文ToolStripMenuItem";
			简体中文ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
			简体中文ToolStripMenuItem.Text = "简体中文";
			简体中文ToolStripMenuItem.Click += new System.EventHandler(简体中文ToolStripMenuItem_Click);
			englishToolStripMenuItem.Name = "englishToolStripMenuItem";
			englishToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
			englishToolStripMenuItem.Text = "English";
			englishToolStripMenuItem.Click += new System.EventHandler(englishToolStripMenuItem_Click);
			论坛toolStripMenuItem.Name = "论坛toolStripMenuItem";
			论坛toolStripMenuItem.Size = new System.Drawing.Size(43, 21);
			论坛toolStripMenuItem.Text = "BBS";
			论坛toolStripMenuItem.Click += new System.EventHandler(论坛toolStripMenuItem_Click);
			日志ToolStripMenuItem.Name = "日志ToolStripMenuItem";
			日志ToolStripMenuItem.Size = new System.Drawing.Size(83, 21);
			日志ToolStripMenuItem.Text = "Changelog";
			日志ToolStripMenuItem.Click += new System.EventHandler(日志ToolStripMenuItem_Click);
			verisonToolStripMenuItem.Name = "verisonToolStripMenuItem";
			verisonToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
			verisonToolStripMenuItem.Text = "Verison";
			免责条款ToolStripMenuItem.Name = "免责条款ToolStripMenuItem";
			免责条款ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
			免责条款ToolStripMenuItem.Text = "免责条款";
			免责条款ToolStripMenuItem.Click += new System.EventHandler(免责条款ToolStripMenuItem_Click);
			授权ToolStripMenuItem.Name = "授权ToolStripMenuItem";
			授权ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
			授权ToolStripMenuItem.Text = "授权";
			groupBox12.Controls.Add(button43);
			groupBox12.Controls.Add(button42);
			groupBox12.Controls.Add(button40);
			groupBox12.Location = new System.Drawing.Point(586, 536);
			groupBox12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox12.Name = "groupBox12";
			groupBox12.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox12.Size = new System.Drawing.Size(185, 151);
			groupBox12.TabIndex = 27;
			groupBox12.TabStop = false;
			groupBox12.Text = "Redis";
			button43.Location = new System.Drawing.Point(19, 102);
			button43.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button43.Name = "button43";
			button43.Size = new System.Drawing.Size(150, 32);
			button43.TabIndex = 2;
			button43.Text = "Redis Subscribe";
			button43.UseVisualStyleBackColor = true;
			button43.Click += new System.EventHandler(button43_Click);
			button42.Location = new System.Drawing.Point(19, 64);
			button42.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button42.Name = "button42";
			button42.Size = new System.Drawing.Size(150, 32);
			button42.TabIndex = 1;
			button42.Text = "Redis Browser";
			button42.UseVisualStyleBackColor = true;
			button42.Click += new System.EventHandler(button42_Click);
			button40.Location = new System.Drawing.Point(19, 24);
			button40.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button40.Name = "button40";
			button40.Size = new System.Drawing.Size(150, 32);
			button40.TabIndex = 0;
			button40.Text = "RedisClient";
			button40.UseVisualStyleBackColor = true;
			button40.Click += new System.EventHandler(button40_Click);
			groupBox13.Controls.Add(button54);
			groupBox13.Controls.Add(button50);
			groupBox13.Controls.Add(button49);
			groupBox13.Location = new System.Drawing.Point(777, 224);
			groupBox13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox13.Name = "groupBox13";
			groupBox13.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox13.Size = new System.Drawing.Size(185, 140);
			groupBox13.TabIndex = 28;
			groupBox13.TabStop = false;
			groupBox13.Text = "Keyence(基恩士 PLC)";
			button54.Location = new System.Drawing.Point(18, 100);
			button54.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button54.Name = "button54";
			button54.Size = new System.Drawing.Size(150, 32);
			button54.TabIndex = 4;
			button54.Text = "Nano(ASCII)";
			button54.UseVisualStyleBackColor = true;
			button54.Click += new System.EventHandler(button54_Click);
			button50.Location = new System.Drawing.Point(18, 64);
			button50.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button50.Name = "button50";
			button50.Size = new System.Drawing.Size(150, 32);
			button50.TabIndex = 3;
			button50.Text = "MC-3E (ASCII)";
			button50.UseVisualStyleBackColor = true;
			button50.Click += new System.EventHandler(button50_Click);
			button49.Location = new System.Drawing.Point(18, 24);
			button49.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button49.Name = "button49";
			button49.Size = new System.Drawing.Size(150, 32);
			button49.TabIndex = 2;
			button49.Text = "MC-3E (Binary)";
			button49.UseVisualStyleBackColor = true;
			button49.Click += new System.EventHandler(button49_Click);
			label2.BackColor = System.Drawing.Color.MediumPurple;
			label2.ForeColor = System.Drawing.Color.White;
			label2.Location = new System.Drawing.Point(449, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(704, 25);
			label2.TabIndex = 29;
			label2.Text = "如果你有什么问题，可以先去论坛看看";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			groupBox14.Controls.Add(button59);
			groupBox14.Controls.Add(button57);
			groupBox14.Controls.Add(button55);
			groupBox14.Location = new System.Drawing.Point(586, 224);
			groupBox14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox14.Name = "groupBox14";
			groupBox14.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox14.Size = new System.Drawing.Size(185, 140);
			groupBox14.TabIndex = 30;
			groupBox14.TabStop = false;
			groupBox14.Text = "LSIS PLC";
			button59.Location = new System.Drawing.Point(19, 95);
			button59.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button59.Name = "button59";
			button59.Size = new System.Drawing.Size(150, 32);
			button59.TabIndex = 8;
			button59.Text = "LSis Virtual Server";
			button59.UseVisualStyleBackColor = true;
			button59.Click += new System.EventHandler(Button59_Click);
			button57.Location = new System.Drawing.Point(19, 55);
			button57.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button57.Name = "button57";
			button57.Size = new System.Drawing.Size(150, 32);
			button57.TabIndex = 1;
			button57.Text = "XGB Cnet";
			button57.UseVisualStyleBackColor = true;
			button57.Click += new System.EventHandler(Button57_Click);
			button55.Location = new System.Drawing.Point(19, 18);
			button55.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button55.Name = "button55";
			button55.Size = new System.Drawing.Size(150, 32);
			button55.TabIndex = 0;
			button55.Text = "XGB Fast Enet";
			button55.UseVisualStyleBackColor = true;
			button55.Click += new System.EventHandler(Button55_Click);
			groupBox15.Controls.Add(button63);
			groupBox15.Location = new System.Drawing.Point(968, 29);
			groupBox15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox15.Name = "groupBox15";
			groupBox15.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox15.Size = new System.Drawing.Size(185, 96);
			groupBox15.TabIndex = 31;
			groupBox15.TabStop = false;
			groupBox15.Text = "FATEK(永宏 PLC)";
			button63.Location = new System.Drawing.Point(19, 24);
			button63.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button63.Name = "button63";
			button63.Size = new System.Drawing.Size(150, 32);
			button63.TabIndex = 0;
			button63.Text = "programe [编程口]";
			button63.UseVisualStyleBackColor = true;
			button63.Click += new System.EventHandler(Button63_Click);
			groupBox16.Controls.Add(button62);
			groupBox16.Location = new System.Drawing.Point(968, 262);
			groupBox16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox16.Name = "groupBox16";
			groupBox16.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox16.Size = new System.Drawing.Size(185, 102);
			groupBox16.TabIndex = 32;
			groupBox16.TabStop = false;
			groupBox16.Text = "Fuji(富士 PLC)";
			button62.Location = new System.Drawing.Point(19, 24);
			button62.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button62.Name = "button62";
			button62.Size = new System.Drawing.Size(150, 32);
			button62.TabIndex = 0;
			button62.Text = "SPB [串口]";
			button62.UseVisualStyleBackColor = true;
			button62.Click += new System.EventHandler(Button62_Click);
			groupBox17.Controls.Add(button70);
			groupBox17.Controls.Add(button67);
			groupBox17.Controls.Add(button66);
			groupBox17.Controls.Add(button65);
			groupBox17.Controls.Add(button64);
			groupBox17.Location = new System.Drawing.Point(968, 372);
			groupBox17.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox17.Name = "groupBox17";
			groupBox17.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox17.Size = new System.Drawing.Size(185, 315);
			groupBox17.TabIndex = 33;
			groupBox17.TabStop = false;
			groupBox17.Text = "Special Protocols(特殊协议)";
			button70.Location = new System.Drawing.Point(19, 182);
			button70.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button70.Name = "button70";
			button70.Size = new System.Drawing.Size(150, 32);
			button70.TabIndex = 10;
			button70.Text = "Fourier Filter";
			button70.UseVisualStyleBackColor = true;
			button70.Click += new System.EventHandler(Button70_Click);
			button67.Location = new System.Drawing.Point(19, 64);
			button67.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button67.Name = "button67";
			button67.Size = new System.Drawing.Size(150, 32);
			button67.TabIndex = 9;
			button67.Text = "Tcp/Ip server";
			button67.UseVisualStyleBackColor = true;
			button67.Click += new System.EventHandler(Button67_Click);
			button66.Location = new System.Drawing.Point(19, 222);
			button66.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button66.Name = "button66";
			button66.Size = new System.Drawing.Size(150, 32);
			button66.TabIndex = 8;
			button66.Text = "Sick";
			button66.UseVisualStyleBackColor = true;
			button66.Click += new System.EventHandler(Button66_Click);
			button65.Location = new System.Drawing.Point(19, 262);
			button65.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button65.Name = "button65";
			button65.Size = new System.Drawing.Size(150, 32);
			button65.TabIndex = 7;
			button65.Text = "Pid";
			button65.UseVisualStyleBackColor = true;
			button65.Click += new System.EventHandler(Button65_Click);
			button64.Location = new System.Drawing.Point(19, 24);
			button64.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			button64.Name = "button64";
			button64.Size = new System.Drawing.Size(150, 32);
			button64.TabIndex = 1;
			button64.Text = "Open Protocol";
			button64.UseVisualStyleBackColor = true;
			button64.Click += new System.EventHandler(Button64_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.AliceBlue;
			base.ClientSize = new System.Drawing.Size(1159, 700);
			base.Controls.Add(groupBox17);
			base.Controls.Add(groupBox16);
			base.Controls.Add(groupBox15);
			base.Controls.Add(groupBox14);
			base.Controls.Add(label2);
			base.Controls.Add(groupBox13);
			base.Controls.Add(groupBox9);
			base.Controls.Add(groupBox12);
			base.Controls.Add(groupBox11);
			base.Controls.Add(groupBox10);
			base.Controls.Add(groupBox8);
			base.Controls.Add(groupBox7);
			base.Controls.Add(groupBox6);
			base.Controls.Add(groupBox5);
			base.Controls.Add(groupBox4);
			base.Controls.Add(groupBox3);
			base.Controls.Add(groupBox2);
			base.Controls.Add(groupBox1);
			base.Controls.Add(menuStrip1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.MainMenuStrip = menuStrip1;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormLoad";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "HslCommunication Test Tools";
			base.Load += new System.EventHandler(FormLoad_Load);
			base.Shown += new System.EventHandler(FormLoad_Shown);
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			groupBox4.ResumeLayout(false);
			groupBox5.ResumeLayout(false);
			groupBox6.ResumeLayout(false);
			groupBox6.PerformLayout();
			groupBox7.ResumeLayout(false);
			groupBox8.ResumeLayout(false);
			groupBox9.ResumeLayout(false);
			groupBox10.ResumeLayout(false);
			groupBox11.ResumeLayout(false);
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			groupBox12.ResumeLayout(false);
			groupBox13.ResumeLayout(false);
			groupBox14.ResumeLayout(false);
			groupBox15.ResumeLayout(false);
			groupBox16.ResumeLayout(false);
			groupBox17.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
