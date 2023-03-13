using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using HslCommunication.Core.Security;
using HslCommunication.Enthernet;
using HslCommunication.LogNet;
using HslCommunication.MQTT;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace HslCommunicationDemo
{
	public class FormMain : Form
	{
		public static Color ThemeColor = Color.FromArgb(64, 64, 64);

		private MqttClient mqttClient;

		private System.Windows.Forms.Timer timer;

		private Process cur = null;

		private PerformanceCounter curpcp = null;

		private const int MB_DIV = 1048576;

		private FormPanelLeft panelLeft;

		private FormSaveList panelSave;

		public static Type[] formTypes = Assembly.GetExecutingAssembly().GetTypes();

		private ILogNet logNet;

		private FormLogRender logRender;

		private IContainer components = null;

		private MenuStrip menuStrip1;

		private ToolStripMenuItem aboutToolStripMenuItem;

		private ToolStripMenuItem blogsToolStripMenuItem;

		private ToolStripMenuItem webSideToolStripMenuItem;

		private ToolStripMenuItem 日志ToolStripMenuItem;

		private ToolStripMenuItem verisonToolStripMenuItem;

		private ToolStripMenuItem 免责条款ToolStripMenuItem;

		private ToolStripMenuItem logToolStripMenuItem;

		private ToolStripMenuItem 授权ToolStripMenuItem;

		private ToolStripMenuItem support赞助ToolStripMenuItem;

		private VS2015BlueTheme vS2015BlueTheme1;

		private ToolStripMenuItem toolStripMenuItem_homepage;

		private DockPanel dockPanel1;

		private Label label1;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem authorization授权ToolStripMenuItem;

		private ToolStripMenuItem deleteDeviceToolStripMenuItem;

		private Label label2;

		private ToolStripMenuItem newVersionToolStripMenuItem;

		private ToolStripMenuItem activeToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem_language;

		private ToolStripMenuItem 简体中文ToolStripMenuItem;

		private ToolStripMenuItem englishToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem_doc;

		public static FormMain Form
		{
			get;
			set;
		}

		public FormMain()
		{
			InitializeComponent();
			Form = this;
			logNet = new LogNetSingle(string.Empty);
		}

		private void FormLoad_Load(object sender, EventArgs e)
		{
			LoadActive();
			dockPanel1.Theme = vS2015BlueTheme1;
			logRender = new FormLogRender(logNet);
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
			ImageList imageList = new ImageList();
			imageList.Images.Add("Method_636", Resources.Method_636);
			imageList.Images.Add("ab", Resources.ab);
			imageList.Images.Add("fujifilm", Resources.fujifilm);
			imageList.Images.Add("HslCommunication", Resources.HslCommunication);
			imageList.Images.Add("idcard", Resources.idcard);
			imageList.Images.Add("inovance", Resources.inovance);
			imageList.Images.Add("keyence", Resources.keyence);
			imageList.Images.Add("ls", Resources.ls);
			imageList.Images.Add("melsec", Resources.melsec);
			imageList.Images.Add("modbus", Resources.modbus);
			imageList.Images.Add("omron", Resources.omron);
			imageList.Images.Add("panasonic", Resources.panasonic);
			imageList.Images.Add("redis", Resources.redis);
			imageList.Images.Add("schneider", Resources.schneider);
			imageList.Images.Add("siemens", Resources.siemens);
			imageList.Images.Add("debug", Resources.debug);
			imageList.Images.Add("barcode", Resources.barcode);
			imageList.Images.Add("mqtt", Resources.mqtt);
			imageList.Images.Add("toledo", Resources.toledo);
			imageList.Images.Add("robot", Resources.robot);
			imageList.Images.Add("beckhoff", Resources.beckhoff);
			imageList.Images.Add("abb", Resources.abb);
			imageList.Images.Add("fatek", Resources.fatek);
			imageList.Images.Add("kuka", Resources.kuka);
			imageList.Images.Add("efort", Resources.efort);
			imageList.Images.Add("fanuc", Resources.fanuc);
			imageList.Images.Add("Class_489", Resources.Class_489);
			imageList.Images.Add("zkt", Resources.zkt);
			imageList.Images.Add("websocket", Resources.websocket);
			imageList.Images.Add("yaskawa", Resources.yaskawa);
			imageList.Images.Add("xinje", Resources.xinje);
			imageList.Images.Add("yokogawa", Resources.yokogawa);
			imageList.Images.Add("delta", Resources.delta);
			imageList.Images.Add("ge", Resources.ge);
			imageList.Images.Add("yamatake", Resources.Yamatake);
			imageList.Images.Add("rkc", Resources.rkc);
			imageList.Images.Add("vigor", Resources.vigor);
			imageList.Images.Add("iec", Resources.iec);
			imageList.Images.Add("turck", Resources.Turck);
			panelLeft = new FormPanelLeft(dockPanel1, imageList, logNet);
			panelLeft.FormClosing += PanelLeft_FormClosing;
			panelLeft.Show(dockPanel1, DockState.DockLeft);
			panelSave = new FormSaveList(dockPanel1, imageList, logNet, panelLeft.IconImageIndex);
			panelSave.FormClosing += PanelLeft_FormClosing;
			panelSave.Show(dockPanel1, DockState.DockLeft);
			if (panelSave.LoadDeviceList())
			{
				panelSave.Activate();
			}
			else
			{
				panelLeft.Activate();
			}
			FormIndex formIndex = new FormIndex();
			formIndex.Show(dockPanel1, DockState.Document);
			timer = new System.Windows.Forms.Timer();
			timer.Interval = 1000000;
			timer.Tick += Timer_Tick;
			timer.Start();
			newVersionToolStripMenuItem.Visible = false;
			activeToolStripMenuItem.Click += ActiveToolStripMenuItem_Click;
		}

		private void PanelLeft_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
		}

		private void FormSelect_FormClosing(object sender, FormClosingEventArgs e)
		{
			MqttClient obj = mqttClient;
			if (obj != null)
			{
				obj.ConnectClose();
			}
		}

		private void FormLoad_Shown(object sender, EventArgs e)
		{
			ThreadPool.QueueUserWorkItem(ThreadPoolCheckVersion, null);
		}

		private void ThreadPoolCheckVersion(object obj)
		{
			Thread.Sleep(100);
			mqttClient = new MqttClient(new MqttConnectionOptions
			{
				IpAddress = "118.24.36.220",
				Port = 1883,
				ClientId = "HslDemo"
			});
			mqttClient.ConnectServer();
			NetSimplifyClient netSimplifyClient = new NetSimplifyClient("118.24.36.220", 18467);
			OperateResult<NetHandle, string> read = netSimplifyClient.ReadCustomerFromServer(1, SoftBasic.FrameworkVersion.ToString());
			if (read.IsSuccess)
			{
				SystemVersion sV = new SystemVersion(read.Content2);
				if (sV > SoftBasic.FrameworkVersion)
				{
					Invoke((Action)delegate
					{
						if (!File.Exists(Path.Combine(Application.StartupPath, "newVersionIngored.txt")))
						{
							using (FormNewVerison formNewVerison = new FormNewVerison())
							{
								if (formNewVerison.ShowDialog("Version Check", "New version on server：" + read.Content2 + Environment.NewLine + " Start update?") == DialogResult.Yes)
								{
									NewVersionToolStripMenuItem_Click(null, new EventArgs());
								}
								if (formNewVerison.NewVersionIngored)
								{
									File.WriteAllText(Path.Combine(Application.StartupPath, "newVersionIngored.txt"), string.Empty, Encoding.UTF8);
								}
								else
								{
									File.Delete(Path.Combine(Application.StartupPath, "newVersionIngored.txt"));
								}
							}
						}
						else
						{
							newVersionToolStripMenuItem.Visible = true;
							newVersionToolStripMenuItem.Click += NewVersionToolStripMenuItem_Click;
						}
					});
				}
			}
			try
			{
				cur = Process.GetCurrentProcess();
				curpcp = new PerformanceCounter("Process", "Working Set - Private", cur.ProcessName);
			}
			catch
			{
			}
		}

		private void LoadActive()
		{
			try
			{
				string text = Path.Combine(Application.StartupPath, "active.txt");
				if (File.Exists(text))
				{
					FileInfo fileInfo = new FileInfo(text);
					string text2 = fileInfo.CreationTime.ToString("yyyy-MM-dd-mm-ss");
					AesCryptography aesCryptography = new AesCryptography(text2 + text2);
					string @string = Encoding.UTF8.GetString(aesCryptography.Decrypt(File.ReadAllBytes(text)));
					bool flag = false;
					if ((@string.Length >= 100) ? Authorization.SetHslCertificate(Convert.FromBase64String(@string)).IsSuccess : Authorization.SetAuthorizationCode(@string))
					{
						activeToolStripMenuItem.Text = "Actived!";
						activeToolStripMenuItem.ForeColor = Color.Lime;
					}
					else
					{
						File.Delete(text);
					}
				}
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage(ex);
			}
		}

		private void Language(int language)
		{
			if (language == 1)
			{
				Text = "HslCommunication 测试工具";
				免责条款ToolStripMenuItem.Text = "全国使用分布";
				logToolStripMenuItem.Text = "报文日志";
				日志ToolStripMenuItem.Text = "API 文档";
				deleteDeviceToolStripMenuItem.Text = "删除设备";
				toolStripMenuItem_language.Text = "语言";
				toolStripMenuItem_homepage.Text = "官网";
			}
			else
			{
				Text = "HslCommunication Test Tool";
				logToolStripMenuItem.Text = "MsgLog";
				免责条款ToolStripMenuItem.Text = "China Map";
				日志ToolStripMenuItem.Text = "API Doc";
				toolStripMenuItem_language.Text = "Language";
				toolStripMenuItem_homepage.Text = "Home";
			}
		}

		private void ActiveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (FormActive formActive = new FormActive())
			{
				formActive.ShowDialog();
				LoadActive();
			}
		}

		private void Support赞助ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (FormSupport formSupport = new FormSupport())
			{
				formSupport.ShowDialog();
			}
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if (curpcp != null)
			{
				string str = (curpcp.NextValue() / 1048576f).ToString("F1") + "MB";
				label2.Text = "Ram: " + str;
			}
			label1.Text = string.Format("Timeout:{0}  Lock:{1}  Wait:{2}", HslTimeOut.TimeOutCheckCount, SimpleHybirdLock.SimpleHybirdLockCount, SimpleHybirdLock.SimpleHybirdLockWaitCount);
		}

		private void logToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (logRender == null || logRender.IsDisposed)
			{
				logRender = new FormLogRender(logNet);
			}
			bool flag = false;
			foreach (DockPane pane in dockPanel1.Panes)
			{
				if (pane.DockState == DockState.Document)
				{
					logRender.Show(pane, DockAlignment.Bottom, 0.3);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				logRender.Show(dockPanel1, DockState.DockBottom);
			}
		}

		private void OpenWebside(string url)
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

		private void toolStripMenuItem_homepage_Click(object sender, EventArgs e)
		{
			OpenWebside("http://www.hsltechnology.cn");
		}

		private void toolStripMenuItem_doc_Click(object sender, EventArgs e)
		{
			OpenWebside("http://www.hsltechnology.cn/Doc/HslCommunication");
		}

		private void 简体中文ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringResources.SetLanguageChinese();
			Program.Language = 1;
			Settings1.Default.language = Program.Language;
			Settings1.Default.Save();
			Language(Program.Language);
			FormPanelLeft formPanelLeft = panelLeft;
			if (formPanelLeft != null)
			{
				formPanelLeft.SetLanguage();
			}
			FormSaveList formSaveList = panelSave;
			if (formSaveList != null)
			{
				formSaveList.SetLanguage();
			}
			MessageBox.Show("已选择中文");
		}

		private void englishToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringResources.SeteLanguageEnglish();
			Program.Language = 2;
			Settings1.Default.language = Program.Language;
			Settings1.Default.Save();
			Language(Program.Language);
			FormPanelLeft formPanelLeft = panelLeft;
			if (formPanelLeft != null)
			{
				formPanelLeft.SetLanguage();
			}
			FormSaveList formSaveList = panelSave;
			if (formSaveList != null)
			{
				formSaveList.SetLanguage();
			}
			MessageBox.Show("Select English!");
		}

		private void 免责条款ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new FormHslMap().Show(dockPanel1);
		}

		private void authorization授权ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new FormCharge().Show(dockPanel1);
		}

		private void 日志ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenWebside("http://api.hslcommunication.cn");
		}

		private void NewVersionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (File.Exists(Path.Combine(Application.StartupPath, "Upgrade.exe")))
				{
					Process.Start(Path.Combine(Application.StartupPath, "Upgrade.exe"));
				}
				else if (File.Exists(Path.Combine(Application.StartupPath, "AutoUpdate.exe")))
				{
					Process.Start(Path.Combine(Application.StartupPath, "AutoUpdate.exe"));
				}
				else
				{
					Process.Start(Path.Combine(Application.StartupPath, "软件自动更新.exe"));
				}
				Thread.Sleep(50);
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("更新软件丢失，无法启动更新： " + ex.Message);
			}
		}

		public FormSaveList GetPanelLeft()
		{
			return panelSave;
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(HslCommunicationDemo.FormMain));
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			blogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			webSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			support赞助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			authorization授权ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_language = new System.Windows.Forms.ToolStripMenuItem();
			简体中文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_homepage = new System.Windows.Forms.ToolStripMenuItem();
			日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_doc = new System.Windows.Forms.ToolStripMenuItem();
			verisonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			activeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			免责条款ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			授权ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			newVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			vS2015BlueTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme();
			dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			label1 = new System.Windows.Forms.Label();
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
			deleteDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			label2 = new System.Windows.Forms.Label();
			menuStrip1.SuspendLayout();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			menuStrip1.BackColor = System.Drawing.Color.FromArgb(92, 108, 124);
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[11]
			{
				aboutToolStripMenuItem,
				toolStripMenuItem_language,
				logToolStripMenuItem,
				toolStripMenuItem_homepage,
				日志ToolStripMenuItem,
				toolStripMenuItem_doc,
				verisonToolStripMenuItem,
				activeToolStripMenuItem,
				免责条款ToolStripMenuItem,
				授权ToolStripMenuItem,
				newVersionToolStripMenuItem
			});
			menuStrip1.Location = new System.Drawing.Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new System.Drawing.Size(1240, 25);
			menuStrip1.TabIndex = 26;
			menuStrip1.Text = "menuStrip1";
			aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4]
			{
				blogsToolStripMenuItem,
				webSideToolStripMenuItem,
				support赞助ToolStripMenuItem,
				authorization授权ToolStripMenuItem
			});
			aboutToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
			aboutToolStripMenuItem.Text = "About";
			blogsToolStripMenuItem.Name = "blogsToolStripMenuItem";
			blogsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			blogsToolStripMenuItem.Text = "Blogs [博客]";
			blogsToolStripMenuItem.Click += new System.EventHandler(blogsToolStripMenuItem_Click);
			webSideToolStripMenuItem.Name = "webSideToolStripMenuItem";
			webSideToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			webSideToolStripMenuItem.Text = "WebSide [官网]";
			webSideToolStripMenuItem.Click += new System.EventHandler(webSideToolStripMenuItem_Click);
			support赞助ToolStripMenuItem.Name = "support赞助ToolStripMenuItem";
			support赞助ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			support赞助ToolStripMenuItem.Text = "Support [赞助]";
			authorization授权ToolStripMenuItem.Name = "authorization授权ToolStripMenuItem";
			authorization授权ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			authorization授权ToolStripMenuItem.Text = "Authorization [授权]";
			authorization授权ToolStripMenuItem.Click += new System.EventHandler(authorization授权ToolStripMenuItem_Click);
			toolStripMenuItem_language.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2]
			{
				简体中文ToolStripMenuItem,
				englishToolStripMenuItem
			});
			toolStripMenuItem_language.ForeColor = System.Drawing.Color.WhiteSmoke;
			toolStripMenuItem_language.ImageTransparentColor = System.Drawing.Color.White;
			toolStripMenuItem_language.Name = "toolStripMenuItem_language";
			toolStripMenuItem_language.Size = new System.Drawing.Size(44, 21);
			toolStripMenuItem_language.Text = "语言";
			简体中文ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
			简体中文ToolStripMenuItem.Name = "简体中文ToolStripMenuItem";
			简体中文ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			简体中文ToolStripMenuItem.Text = "简体中文";
			简体中文ToolStripMenuItem.Click += new System.EventHandler(简体中文ToolStripMenuItem_Click);
			englishToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
			englishToolStripMenuItem.Name = "englishToolStripMenuItem";
			englishToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			englishToolStripMenuItem.Text = "English";
			englishToolStripMenuItem.Click += new System.EventHandler(englishToolStripMenuItem_Click);
			logToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			logToolStripMenuItem.Name = "logToolStripMenuItem";
			logToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
			logToolStripMenuItem.Text = "报文日志";
			logToolStripMenuItem.Click += new System.EventHandler(logToolStripMenuItem_Click);
			toolStripMenuItem_homepage.ForeColor = System.Drawing.Color.WhiteSmoke;
			toolStripMenuItem_homepage.Name = "toolStripMenuItem_homepage";
			toolStripMenuItem_homepage.Size = new System.Drawing.Size(44, 21);
			toolStripMenuItem_homepage.Text = "官网";
			toolStripMenuItem_homepage.Click += new System.EventHandler(toolStripMenuItem_homepage_Click);
			日志ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			日志ToolStripMenuItem.Name = "日志ToolStripMenuItem";
			日志ToolStripMenuItem.Size = new System.Drawing.Size(67, 21);
			日志ToolStripMenuItem.Text = "API 文档";
			日志ToolStripMenuItem.Click += new System.EventHandler(日志ToolStripMenuItem_Click);
			toolStripMenuItem_doc.ForeColor = System.Drawing.Color.White;
			toolStripMenuItem_doc.Name = "toolStripMenuItem_doc";
			toolStripMenuItem_doc.Size = new System.Drawing.Size(43, 21);
			toolStripMenuItem_doc.Text = "Doc";
			toolStripMenuItem_doc.Click += new System.EventHandler(toolStripMenuItem_doc_Click);
			verisonToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			verisonToolStripMenuItem.Name = "verisonToolStripMenuItem";
			verisonToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
			verisonToolStripMenuItem.Text = "Verison";
			activeToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			activeToolStripMenuItem.Name = "activeToolStripMenuItem";
			activeToolStripMenuItem.Size = new System.Drawing.Size(54, 21);
			activeToolStripMenuItem.Text = "Active";
			免责条款ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			免责条款ToolStripMenuItem.Name = "免责条款ToolStripMenuItem";
			免责条款ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
			免责条款ToolStripMenuItem.Text = "全国使用情况";
			免责条款ToolStripMenuItem.Click += new System.EventHandler(免责条款ToolStripMenuItem_Click);
			授权ToolStripMenuItem.Name = "授权ToolStripMenuItem";
			授权ToolStripMenuItem.Size = new System.Drawing.Size(12, 21);
			newVersionToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(255, 255, 128);
			newVersionToolStripMenuItem.Name = "newVersionToolStripMenuItem";
			newVersionToolStripMenuItem.Size = new System.Drawing.Size(98, 21);
			newVersionToolStripMenuItem.Text = "New Version!";
			dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			dockPanel1.DockLeftPortion = 225.0;
			dockPanel1.Location = new System.Drawing.Point(0, 25);
			dockPanel1.Name = "dockPanel1";
			dockPanel1.Size = new System.Drawing.Size(1240, 691);
			dockPanel1.TabIndex = 36;
			label1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label1.BackColor = System.Drawing.Color.FromArgb(92, 108, 124);
			label1.ForeColor = System.Drawing.Color.FromArgb(255, 255, 128);
			label1.Location = new System.Drawing.Point(1031, 3);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(209, 21);
			label1.TabIndex = 39;
			label1.Text = "Thread:0  Lock:0";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1]
			{
				deleteDeviceToolStripMenuItem
			});
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new System.Drawing.Size(152, 26);
			deleteDeviceToolStripMenuItem.Image = HslCommunicationDemo.Properties.Resources.action_Cancel_16xLG;
			deleteDeviceToolStripMenuItem.Name = "deleteDeviceToolStripMenuItem";
			deleteDeviceToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			deleteDeviceToolStripMenuItem.Text = "DeleteDevice";
			label2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label2.BackColor = System.Drawing.Color.FromArgb(92, 108, 124);
			label2.ForeColor = System.Drawing.Color.FromArgb(255, 255, 128);
			label2.Location = new System.Drawing.Point(816, 3);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(209, 21);
			label2.TabIndex = 42;
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.AliceBlue;
			base.ClientSize = new System.Drawing.Size(1240, 716);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(dockPanel1);
			base.Controls.Add(menuStrip1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			//base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.IsMdiContainer = true;
			base.MainMenuStrip = menuStrip1;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormMain";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "HslCommunication Test Tools";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSelect_FormClosing);
			base.Load += new System.EventHandler(FormLoad_Load);
			base.Shown += new System.EventHandler(FormLoad_Shown);
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
