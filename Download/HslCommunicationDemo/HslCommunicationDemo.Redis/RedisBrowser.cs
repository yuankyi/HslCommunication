using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Enthernet.Redis;
using HslCommunicationDemo.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo.Redis
{
	public class RedisBrowser : HslFormContent
	{
		private int dbSelect = 0;

		private RedisClient redisClient = null;

		private Timer timer1s = null;

		private string lastNodeSelected = string.Empty;

		private TreeNode treeViewSelectedNode = null;

		private int selectRowIndex = -1;

		private IContainer components = null;

		private Panel panel1;

		private TextBox textBox3;

		private Label label6;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private Label label1;

		private SplitContainer splitContainer1;

		private TreeView treeView1;

		private Panel panel2;

		private TextBox textBox5;

		private TextBox textBox4;

		private Label label2;

		private Button button3;

		private Panel panel3;

		private Label label5;

		private Label label4;

		private Panel panel5;

		private DataGridView dataGridView1;

		private Label label7;

		private TextBox textBox6;

		private Label label9;

		private TextBox textBox7;

		private Panel panel4;

		private Label label11;

		private Label label12;

		private Label label13;

		private SplitContainer splitContainer2;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private Button button5;

		private Button button4;

		private Button button6;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private CheckBox checkBox1;

		private Panel panel6;

		private RadioButton radioButton3;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private Button button7;

		private Panel panel7;

		private RadioButton radioButton4;

		private RadioButton radioButton5;

		private RadioButton radioButton6;

		private Button button8;

		private LinkLabel linkLabel1;

		public RedisBrowser()
		{
			InitializeComponent();
		}

		private int GetDbFromTreeNode(TreeNode node)
		{
			while (!(node.ImageKey == "VirtualMachine"))
			{
				node = node.Parent;
			}
			return int.Parse(node.Text.Substring(2));
		}

		private void RedisBrowser_Load(object sender, EventArgs e)
		{
			if (Program.Language == 2)
			{
				linkLabel1.Text = "For a more powerful Redis desktop application, click browse";
			}
			ImageList imageList = new ImageList();
			imageList.Images.Add("VirtualMachine", Resources.VirtualMachine);
			imageList.Images.Add("Class_489", Resources.Class_489);
			imageList.Images.Add("Enum_582", Resources.Enum_582);
			imageList.Images.Add("brackets_Square_16xMD", Resources.brackets_Square_16xMD);
			imageList.Images.Add("Method_636", Resources.Method_636);
			imageList.Images.Add("Module_648", Resources.Module_648);
			imageList.Images.Add("Structure_507", Resources.Structure_507);
			treeView1.ImageList = imageList;
			for (int i = 0; i < treeView1.Nodes.Count; i++)
			{
				treeView1.Nodes[i].ImageKey = "VirtualMachine";
				treeView1.Nodes[i].SelectedImageKey = "VirtualMachine";
			}
			panel3.Enabled = false;
			panel4.Dock = DockStyle.Fill;
			panel4.Visible = false;
			panel5.Dock = DockStyle.Fill;
			panel5.Visible = false;
			timer1s = new Timer();
			timer1s.Interval = 800;
			timer1s.Tick += Timer1s_Tick;
			timer1s.Start();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			redisClient = new RedisClient(textBox3.Text);
			redisClient.IpAddress = textBox1.Text;
			redisClient.Port = int.Parse(textBox2.Text);
			OperateResult operateResult = redisClient.ConnectServer();
			if (operateResult.IsSuccess)
			{
				button1.Enabled = false;
				button2.Enabled = true;
				panel3.Enabled = true;
				MessageBox.Show(StringResources.Language.ConnectServerSuccess);
				RedisRefresh(treeView1.Nodes[dbSelect]);
			}
			else
			{
				MessageBox.Show(StringResources.Language.ConnectedFailed + operateResult.ToMessageShowString());
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			RedisRefresh(treeView1.Nodes[dbSelect]);
		}

		private void RedisRefresh(TreeNode rootNode)
		{
			rootNode.Nodes.Clear();
			OperateResult<string[]> operateResult = redisClient.ReadAllKeys("*");
			if (operateResult.IsSuccess)
			{
				string[] content = operateResult.Content;
				foreach (string text in content)
				{
					AddTreeNode(rootNode, text, text);
				}
				rootNode.ExpandAll();
			}
		}

		private void AddTreeNode(TreeNode parent, string key, string infactKey)
		{
			int num = key.IndexOf(':');
			if (num <= 0)
			{
				TreeNode treeNode = new TreeNode(infactKey);
				treeNode.Tag = infactKey;
				OperateResult<string> operateResult = redisClient.ReadKeyType(infactKey);
				if (operateResult.Content == "string")
				{
					treeNode.ImageKey = "Enum_582";
					treeNode.SelectedImageKey = "Enum_582";
				}
				else if (operateResult.Content == "list")
				{
					treeNode.ImageKey = "brackets_Square_16xMD";
					treeNode.SelectedImageKey = "brackets_Square_16xMD";
				}
				else if (operateResult.Content == "hash")
				{
					treeNode.ImageKey = "Method_636";
					treeNode.SelectedImageKey = "Method_636";
				}
				else if (operateResult.Content == "set")
				{
					treeNode.ImageKey = "Module_648";
					treeNode.SelectedImageKey = "Module_648";
				}
				else if (operateResult.Content == "zset")
				{
					treeNode.ImageKey = "Structure_507";
					treeNode.SelectedImageKey = "Structure_507";
				}
				parent.Nodes.Add(treeNode);
			}
			else
			{
				TreeNode treeNode2 = null;
				for (int i = 0; i < parent.Nodes.Count; i++)
				{
					if (parent.Nodes[i].Text == key.Substring(0, num))
					{
						treeNode2 = parent.Nodes[i];
						break;
					}
				}
				if (treeNode2 == null)
				{
					treeNode2 = new TreeNode(key.Substring(0, num));
					treeNode2.ImageKey = "Class_489";
					treeNode2.SelectedImageKey = "Class_489";
					AddTreeNode(treeNode2, key.Substring(num + 1), infactKey);
					parent.Nodes.Add(treeNode2);
				}
				else
				{
					AddTreeNode(treeNode2, key.Substring(num + 1), infactKey);
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			panel3.Enabled = false;
			button1.Enabled = true;
			button2.Enabled = false;
			redisClient.ConnectClose();
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			int dbFromTreeNode = GetDbFromTreeNode(e.Node);
			if (dbSelect != dbFromTreeNode)
			{
				dbSelect = dbFromTreeNode;
				if (!redisClient.SelectDB(dbSelect).IsSuccess)
				{
					MessageBox.Show("Db select failed");
					return;
				}
			}
			if (e.Node.ImageKey == "Enum_582")
			{
				panel4.Visible = true;
				panel4.BringToFront();
				textBox4.Text = e.Node.Tag.ToString();
				DateTime now = DateTime.Now;
				OperateResult<string> operateResult = redisClient.ReadKey(e.Node.Tag.ToString());
				label5.Text = "Time: " + (DateTime.Now - now).TotalMilliseconds.ToString("F0") + " ms";
				if (operateResult.IsSuccess)
				{
					label4.Text = "Size: " + SoftBasic.GetSizeDescription(Encoding.UTF8.GetBytes(operateResult.Content).Length);
					string content = operateResult.Content;
					try
					{
						if (radioButton6.Checked)
						{
							textBox5.Text = content;
						}
						else if (radioButton5.Checked)
						{
							textBox5.Text = XElement.Parse(content).ToString();
						}
						else if (radioButton4.Checked)
						{
							textBox5.Text = JObject.Parse(content).ToString();
						}
					}
					catch
					{
						textBox5.Text = content;
					}
					lastNodeSelected = e.Node.Tag.ToString();
					selectRowIndex = -1;
				}
				else
				{
					MessageBox.Show(operateResult.Message);
				}
			}
			else if (e.Node.ImageKey == "brackets_Square_16xMD")
			{
				panel5.Visible = true;
				panel5.BringToFront();
				label7.Text = "list key:";
				textBox7.Text = string.Empty;
				dataGridView1.Rows.Clear();
				if (e.Node.Tag.ToString() != lastNodeSelected)
				{
					selectRowIndex = -1;
				}
				Refresh();
				textBox6.Text = e.Node.Tag.ToString();
				DateTime now2 = DateTime.Now;
				OperateResult<string[]> operateResult2 = redisClient.ListRange(e.Node.Tag.ToString(), 0L, -1L);
				if (!operateResult2.IsSuccess)
				{
					textBox7.Text = operateResult2.Message;
					return;
				}
				label12.Text = "Time: " + (DateTime.Now - now2).TotalMilliseconds.ToString("F0") + " ms";
				int num = 0;
				for (int i = 0; i < operateResult2.Content.Length; i++)
				{
					num += Encoding.UTF8.GetBytes(operateResult2.Content[i]).Length;
				}
				label13.Text = "Size: " + SoftBasic.GetSizeDescription(num);
				label11.Text = "Array: " + operateResult2.Content.Length.ToString();
				if (operateResult2.IsSuccess)
				{
					for (int j = 0; j < operateResult2.Content.Length; j++)
					{
						dataGridView1.Rows.Add(j, operateResult2.Content[j]);
					}
					lastNodeSelected = e.Node.Tag.ToString();
				}
				else
				{
					MessageBox.Show(operateResult2.Message);
				}
			}
			else if (e.Node.ImageKey == "Method_636")
			{
				panel5.Visible = true;
				panel5.BringToFront();
				label7.Text = "hash key:";
				textBox7.Text = string.Empty;
				dataGridView1.Rows.Clear();
				if (e.Node.Tag.ToString() != lastNodeSelected)
				{
					selectRowIndex = -1;
				}
				Refresh();
				textBox6.Text = e.Node.Tag.ToString();
				DateTime now3 = DateTime.Now;
				OperateResult<string[]> operateResult3 = redisClient.ReadHashKeyAll(e.Node.Tag.ToString());
				if (!operateResult3.IsSuccess)
				{
					textBox7.Text = operateResult3.Message;
					return;
				}
				label12.Text = "Time: " + (DateTime.Now - now3).TotalMilliseconds.ToString("F0") + " ms";
				int num2 = 0;
				for (int k = 0; k < operateResult3.Content.Length; k++)
				{
					num2 += Encoding.UTF8.GetBytes(operateResult3.Content[k]).Length;
				}
				label13.Text = "Size: " + SoftBasic.GetSizeDescription(num2);
				label11.Text = "Array: " + operateResult3.Content.Length.ToString();
				if (operateResult3.IsSuccess)
				{
					for (int l = 0; l < operateResult3.Content.Length / 2; l++)
					{
						dataGridView1.Rows.Add(operateResult3.Content[2 * l], operateResult3.Content[2 * l + 1]);
					}
					lastNodeSelected = e.Node.Tag.ToString();
				}
				else
				{
					MessageBox.Show(operateResult3.Message);
				}
			}
			else if (!(e.Node.ImageKey == "Class_489"))
			{
				if (e.Node.ImageKey == "VirtualMachine")
				{
					button3_Click(sender, e);
				}
				else
				{
					MessageBox.Show("Not supported");
				}
			}
			treeViewSelectedNode = e.Node;
		}

		private void Timer1s_Tick(object sender, EventArgs e)
		{
			if (treeViewSelectedNode != null && checkBox1.Checked)
			{
				treeView1_AfterSelect(null, new TreeViewEventArgs(treeViewSelectedNode));
				if (selectRowIndex >= 0)
				{
					textBox7.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
					label9.Text = "Size: " + SoftBasic.GetSizeDescription(Encoding.UTF8.GetBytes(textBox7.Text).Length);
				}
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void panel5_SizeChanged(object sender, EventArgs e)
		{
			if (panel5.Width > 0)
			{
				dataGridView1.Columns[1].Width = panel5.Width - 175;
			}
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && dataGridView1.SelectedRows.Count > 0)
			{
				selectRowIndex = e.RowIndex;
				string text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
				try
				{
					if (radioButton1.Checked)
					{
						textBox7.Text = text;
					}
					else if (radioButton2.Checked)
					{
						textBox7.Text = XElement.Parse(text).ToString();
					}
					else if (radioButton3.Checked)
					{
						textBox7.Text = JObject.Parse(text).ToString();
					}
				}
				catch
				{
					textBox7.Text = text;
				}
				label9.Text = "Size: " + SoftBasic.GetSizeDescription(Encoding.UTF8.GetBytes(text).Length);
			}
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = redisClient.DeleteKey(textBox4.Text);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Delect Success!");
			}
			else
			{
				MessageBox.Show("Delect Failed:" + operateResult.Message);
			}
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = redisClient.DeleteKey(textBox6.Text);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Delect Success!");
			}
			else
			{
				MessageBox.Show("Delect Failed:" + operateResult.Message);
			}
		}

		private void Button6_Click(object sender, EventArgs e)
		{
			OperateResult<DateTime> operateResult = redisClient.ReadServerTime();
			if (operateResult.IsSuccess)
			{
				toolStripStatusLabel1.Text = "ServerTime: " + operateResult.Content.ToString("yyyy-MM-dd HH:mm:ss");
			}
			else
			{
				MessageBox.Show("ReadTime Failed:" + operateResult.Message);
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void button7_Click(object sender, EventArgs e)
		{
			using (FormRedisInput formRedisInput = new FormRedisInput(redisClient))
			{
				formRedisInput.ShowDialog();
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			OperateResult<long> operateResult = redisClient.DBSize();
			if (operateResult.IsSuccess)
			{
				toolStripStatusLabel1.Text = "Key Number: " + operateResult.Content.ToString();
			}
			else
			{
				MessageBox.Show("ReadTime Failed:" + operateResult.Message);
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start("https://github.com/dathlin/HslRedisDesktop");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
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
			System.Windows.Forms.TreeNode treeNode = new System.Windows.Forms.TreeNode("db0");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("db1");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("db2");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("db3");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("db4");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("db5");
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("db6");
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("db7");
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("db8");
			System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("db9");
			System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("db10");
			System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("db11");
			System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("db12");
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			panel1 = new System.Windows.Forms.Panel();
			checkBox1 = new System.Windows.Forms.CheckBox();
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			button8 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			button6 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			treeView1 = new System.Windows.Forms.TreeView();
			panel2 = new System.Windows.Forms.Panel();
			panel5 = new System.Windows.Forms.Panel();
			button5 = new System.Windows.Forms.Button();
			splitContainer2 = new System.Windows.Forms.SplitContainer();
			label13 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			dataGridView1 = new System.Windows.Forms.DataGridView();
			Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			label12 = new System.Windows.Forms.Label();
			panel6 = new System.Windows.Forms.Panel();
			radioButton3 = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton1 = new System.Windows.Forms.RadioButton();
			label9 = new System.Windows.Forms.Label();
			textBox7 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			panel4 = new System.Windows.Forms.Panel();
			panel7 = new System.Windows.Forms.Panel();
			radioButton4 = new System.Windows.Forms.RadioButton();
			radioButton5 = new System.Windows.Forms.RadioButton();
			radioButton6 = new System.Windows.Forms.RadioButton();
			button4 = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			panel3 = new System.Windows.Forms.Panel();
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			panel2.SuspendLayout();
			panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.Panel2.SuspendLayout();
			splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			panel6.SuspendLayout();
			panel4.SuspendLayout();
			panel7.SuspendLayout();
			panel3.SuspendLayout();
			statusStrip1.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(linkLabel1);
			panel1.Controls.Add(checkBox1);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(12, 13);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(978, 83);
			panel1.TabIndex = 8;
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(477, 50);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(71, 21);
			checkBox1.TabIndex = 15;
			checkBox1.Text = "Refresh";
			checkBox1.UseVisualStyleBackColor = true;
			textBox3.Location = new System.Drawing.Point(62, 47);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(384, 23);
			textBox3.TabIndex = 7;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(8, 50);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(36, 17);
			label6.TabIndex = 6;
			label6.Text = "pwd:";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(584, 11);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "disconnect";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(477, 11);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "connect";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(305, 14);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(141, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "6379";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(251, 17);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(45, 17);
			label3.TabIndex = 2;
			label3.Text = "port：";
			textBox1.Location = new System.Drawing.Point(62, 14);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(141, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 17);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(55, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip addr:";
			splitContainer1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			splitContainer1.Location = new System.Drawing.Point(3, 3);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Panel1.Controls.Add(button8);
			splitContainer1.Panel1.Controls.Add(button7);
			splitContainer1.Panel1.Controls.Add(button6);
			splitContainer1.Panel1.Controls.Add(button3);
			splitContainer1.Panel1.Controls.Add(treeView1);
			splitContainer1.Panel2.Controls.Add(panel2);
			splitContainer1.Size = new System.Drawing.Size(974, 514);
			splitContainer1.SplitterDistance = 303;
			splitContainer1.TabIndex = 9;
			button8.Location = new System.Drawing.Point(143, 5);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(58, 23);
			button8.TabIndex = 4;
			button8.Text = "Count";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			button7.Location = new System.Drawing.Point(276, 5);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(23, 23);
			button7.TabIndex = 3;
			button7.Text = "+";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			button6.Location = new System.Drawing.Point(84, 5);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(53, 23);
			button6.TabIndex = 2;
			button6.Text = "Time";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(Button6_Click);
			button3.Location = new System.Drawing.Point(3, 5);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(75, 23);
			button3.TabIndex = 1;
			button3.Text = "refresh";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			treeView1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			treeView1.Location = new System.Drawing.Point(3, 32);
			treeView1.Name = "treeView1";
			treeNode.Name = "节点0";
			treeNode.Text = "db0";
			treeNode2.Name = "节点1";
			treeNode2.Text = "db1";
			treeNode3.Name = "节点2";
			treeNode3.Text = "db2";
			treeNode4.Name = "节点3";
			treeNode4.Text = "db3";
			treeNode5.Name = "节点4";
			treeNode5.Text = "db4";
			treeNode6.Name = "节点5";
			treeNode6.Text = "db5";
			treeNode7.Name = "节点6";
			treeNode7.Text = "db6";
			treeNode8.Name = "节点7";
			treeNode8.Text = "db7";
			treeNode9.Name = "节点8";
			treeNode9.Text = "db8";
			treeNode10.Name = "节点9";
			treeNode10.Text = "db9";
			treeNode11.Name = "节点10";
			treeNode11.Text = "db10";
			treeNode12.Name = "节点11";
			treeNode12.Text = "db11";
			treeNode13.Name = "节点12";
			treeNode13.Text = "db12";
			treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[13]
			{
				treeNode,
				treeNode2,
				treeNode3,
				treeNode4,
				treeNode5,
				treeNode6,
				treeNode7,
				treeNode8,
				treeNode9,
				treeNode10,
				treeNode11,
				treeNode12,
				treeNode13
			});
			treeView1.Size = new System.Drawing.Size(297, 479);
			treeView1.TabIndex = 0;
			treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);
			panel2.Controls.Add(panel5);
			panel2.Controls.Add(panel4);
			panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			panel2.Location = new System.Drawing.Point(0, 0);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(667, 514);
			panel2.TabIndex = 0;
			panel5.Controls.Add(button5);
			panel5.Controls.Add(splitContainer2);
			panel5.Controls.Add(label7);
			panel5.Controls.Add(textBox6);
			panel5.Location = new System.Drawing.Point(189, 14);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(496, 272);
			panel5.TabIndex = 6;
			panel5.SizeChanged += new System.EventHandler(panel5_SizeChanged);
			button5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button5.Location = new System.Drawing.Point(433, 3);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(57, 26);
			button5.TabIndex = 16;
			button5.Text = "delete";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(Button5_Click);
			splitContainer2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			splitContainer2.Location = new System.Drawing.Point(7, 34);
			splitContainer2.Name = "splitContainer2";
			splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			splitContainer2.Panel1.Controls.Add(label13);
			splitContainer2.Panel1.Controls.Add(label11);
			splitContainer2.Panel1.Controls.Add(dataGridView1);
			splitContainer2.Panel1.Controls.Add(label12);
			splitContainer2.Panel2.Controls.Add(panel6);
			splitContainer2.Panel2.Controls.Add(label9);
			splitContainer2.Panel2.Controls.Add(textBox7);
			splitContainer2.Size = new System.Drawing.Size(486, 232);
			splitContainer2.SplitterDistance = 136;
			splitContainer2.TabIndex = 15;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(3, 2);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(34, 17);
			label13.TabIndex = 12;
			label13.Text = "Size:";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(246, 2);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(42, 17);
			label11.TabIndex = 14;
			label11.Text = "Array:";
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			dataGridView1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			dataGridView1.BackgroundColor = System.Drawing.Color.White;
			dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(Column1, Column2);
			dataGridView1.Location = new System.Drawing.Point(2, 21);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowTemplate.Height = 23;
			dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.Size = new System.Drawing.Size(481, 112);
			dataGridView1.TabIndex = 10;
			dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellClick);
			dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellContentClick);
			Column1.HeaderText = "Index";
			Column1.Name = "Column1";
			Column1.ReadOnly = true;
			Column2.HeaderText = "Value";
			Column2.Name = "Column2";
			Column2.ReadOnly = true;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(132, 2);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(39, 17);
			label12.TabIndex = 13;
			label12.Text = "Time:";
			panel6.Controls.Add(radioButton3);
			panel6.Controls.Add(radioButton2);
			panel6.Controls.Add(radioButton1);
			panel6.Location = new System.Drawing.Point(124, 1);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(226, 22);
			panel6.TabIndex = 9;
			radioButton3.AutoSize = true;
			radioButton3.Location = new System.Drawing.Point(133, 0);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(52, 21);
			radioButton3.TabIndex = 2;
			radioButton3.Text = "Json";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton3.CheckedChanged += new System.EventHandler(radioButton3_CheckedChanged);
			radioButton2.AutoSize = true;
			radioButton2.Location = new System.Drawing.Point(73, 1);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(48, 21);
			radioButton2.TabIndex = 1;
			radioButton2.Text = "Xml";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton2.CheckedChanged += new System.EventHandler(radioButton2_CheckedChanged);
			radioButton1.AutoSize = true;
			radioButton1.Checked = true;
			radioButton1.Location = new System.Drawing.Point(5, 1);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(53, 21);
			radioButton1.TabIndex = 0;
			radioButton1.TabStop = true;
			radioButton1.Text = "Plain";
			radioButton1.UseVisualStyleBackColor = true;
			radioButton1.CheckedChanged += new System.EventHandler(radioButton1_CheckedChanged);
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(3, 3);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(34, 17);
			label9.TabIndex = 8;
			label9.Text = "Size:";
			textBox7.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox7.Location = new System.Drawing.Point(3, 23);
			textBox7.Multiline = true;
			textBox7.Name = "textBox7";
			textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox7.Size = new System.Drawing.Size(480, 66);
			textBox7.TabIndex = 7;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(4, 8);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(51, 17);
			label7.TabIndex = 5;
			label7.Text = "list key:";
			textBox6.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox6.Location = new System.Drawing.Point(74, 5);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(354, 23);
			textBox6.TabIndex = 6;
			panel4.Controls.Add(panel7);
			panel4.Controls.Add(button4);
			panel4.Controls.Add(label2);
			panel4.Controls.Add(label5);
			panel4.Controls.Add(textBox4);
			panel4.Controls.Add(label4);
			panel4.Controls.Add(textBox5);
			panel4.Location = new System.Drawing.Point(95, 314);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(472, 175);
			panel4.TabIndex = 5;
			panel7.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			panel7.Controls.Add(radioButton4);
			panel7.Controls.Add(radioButton5);
			panel7.Controls.Add(radioButton6);
			panel7.Location = new System.Drawing.Point(243, 33);
			panel7.Name = "panel7";
			panel7.Size = new System.Drawing.Size(226, 22);
			panel7.TabIndex = 10;
			radioButton4.AutoSize = true;
			radioButton4.Location = new System.Drawing.Point(133, 0);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new System.Drawing.Size(52, 21);
			radioButton4.TabIndex = 2;
			radioButton4.Text = "Json";
			radioButton4.UseVisualStyleBackColor = true;
			radioButton5.AutoSize = true;
			radioButton5.Location = new System.Drawing.Point(73, 1);
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new System.Drawing.Size(48, 21);
			radioButton5.TabIndex = 1;
			radioButton5.Text = "Xml";
			radioButton5.UseVisualStyleBackColor = true;
			radioButton6.AutoSize = true;
			radioButton6.Checked = true;
			radioButton6.Location = new System.Drawing.Point(5, 1);
			radioButton6.Name = "radioButton6";
			radioButton6.Size = new System.Drawing.Size(53, 21);
			radioButton6.TabIndex = 0;
			radioButton6.TabStop = true;
			radioButton6.Text = "Plain";
			radioButton6.UseVisualStyleBackColor = true;
			button4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button4.Location = new System.Drawing.Point(412, 5);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(57, 26);
			button4.TabIndex = 5;
			button4.Text = "delete";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(Button4_Click);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 9);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(68, 17);
			label2.TabIndex = 0;
			label2.Text = "string key:";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(132, 38);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(39, 17);
			label5.TabIndex = 4;
			label5.Text = "Time:";
			textBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox4.Location = new System.Drawing.Point(73, 6);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(333, 23);
			textBox4.TabIndex = 1;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(3, 38);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(34, 17);
			label4.TabIndex = 3;
			label4.Text = "Size:";
			textBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox5.Location = new System.Drawing.Point(3, 58);
			textBox5.Multiline = true;
			textBox5.Name = "textBox5";
			textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox5.Size = new System.Drawing.Size(466, 114);
			textBox5.TabIndex = 2;
			panel3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel3.Controls.Add(splitContainer1);
			panel3.Location = new System.Drawing.Point(12, 103);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(980, 520);
			panel3.TabIndex = 10;
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1]
			{
				toolStripStatusLabel1
			});
			statusStrip1.Location = new System.Drawing.Point(0, 623);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(1004, 22);
			statusStrip1.TabIndex = 11;
			statusStrip1.Text = "statusStrip1";
			toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			toolStripStatusLabel1.Size = new System.Drawing.Size(32, 17);
			toolStripStatusLabel1.Text = "就绪";
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new System.Drawing.Point(569, 51);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(220, 17);
			linkLabel1.TabIndex = 16;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "一个更强大的Redis桌面程序，点击浏览";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(statusStrip1);
			base.Controls.Add(panel3);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "RedisBrowser";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "RedisBrowser";
			base.Load += new System.EventHandler(RedisBrowser_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel1.PerformLayout();
			splitContainer2.Panel2.ResumeLayout(false);
			splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
			splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			panel6.ResumeLayout(false);
			panel6.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel7.ResumeLayout(false);
			panel7.PerformLayout();
			panel3.ResumeLayout(false);
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
