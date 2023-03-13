using HslCommunication.LogNet;
using HslCommunicationDemo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;
using WeifenLuo.WinFormsUI.Docking;

namespace HslCommunicationDemo.DemoControl
{
	public class FormSaveList : DockContent
	{
		private DemoDeviceList deviceList = new DemoDeviceList();

		private ILogNet logNet = null;

		private ImageList imageList;

		private Dictionary<string, int> formIconImageIndex = new Dictionary<string, int>();

		private DockPanel dockPanel1;

		public static Type[] formTypes = Assembly.GetExecutingAssembly().GetTypes();

		private IContainer components = null;

		private TreeView treeView2;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem deleteDeviceToolStripMenuItem;

		public FormSaveList(DockPanel dockPanel, ImageList imageList, ILogNet logNet, Dictionary<string, int> iconImageIndex)
		{
			InitializeComponent();
			dockPanel1 = dockPanel;
			this.logNet = logNet;
			this.imageList = imageList;
			formIconImageIndex = iconImageIndex;
		}

		private void FormSaveList_Load(object sender, EventArgs e)
		{
			base.CloseButtonVisible = false;
			treeView2.ImageList = imageList;
			treeView2.MouseClick += TreeView2_MouseClick;
			treeView2.MouseDoubleClick += TreeView2_MouseDoubleClick;
			deleteDeviceToolStripMenuItem.Click += DeleteDeviceToolStripMenuItem_Click;
			SetLanguage();
		}

		public void SetLanguage()
		{
			if (Program.Language == 1)
			{
				Text = "保存列表";
			}
			else
			{
				Text = "Save List";
			}
		}

		public bool LoadDeviceList()
		{
			if (File.Exists(Path.Combine(Application.StartupPath, "devices.xml")))
			{
				deviceList.SetDevices(XElement.Load(Path.Combine(Application.StartupPath, "devices.xml")));
				RefreshSaveDevices();
				return true;
			}
			return false;
		}

		public void AddDeviceList(XElement element)
		{
			deviceList.AddDevice(element);
			RefreshSaveDevices();
			File.WriteAllText(Path.Combine(Application.StartupPath, "devices.xml"), deviceList.GetDevices.ToString());
		}

		public void RefreshSaveDevices()
		{
			treeView2.Nodes.Clear();
			foreach (XElement item in deviceList.GetDevices.Elements())
			{
				string value = item.Attribute("Name").Value;
				AddTreeNode(treeView2, null, item, value);
			}
			treeView2.ExpandAll();
		}

		private void DeleteDeviceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (treeView2.SelectedNode != null && treeView2.SelectedNode.Tag != null)
			{
				XElement xElement = treeView2.SelectedNode.Tag as XElement;
				if (xElement != null)
				{
					deviceList.DeleteDevice(xElement);
					RefreshSaveDevices();
					File.WriteAllText(Path.Combine(Application.StartupPath, "devices.xml"), deviceList.GetDevices.ToString());
					MessageBox.Show("Delete Success!");
				}
			}
		}

		private void TreeView2_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				treeView2.SelectedNode = treeView2.GetNodeAt(e.Location);
				contextMenuStrip1.Show(treeView2, e.Location);
			}
		}

		private void TreeView2_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			TreeNode selectedNode = treeView2.SelectedNode;
			if (selectedNode != null && selectedNode.Tag != null)
			{
				XElement xElement = selectedNode.Tag as XElement;
				if (xElement != null)
				{
					string value = xElement.Attribute(DemoDeviceList.XmlType).Value;
					HslFormContent hslFormContent = null;
					Type[] array = formTypes;
					foreach (Type type in array)
					{
						if (type.Name == value)
						{
							hslFormContent = (HslFormContent)type.GetConstructors()[0].Invoke(null);
							hslFormContent.LogNet = logNet;
							break;
						}
					}
					if (hslFormContent != null)
					{
						if (selectedNode.ImageIndex >= 0)
						{
							hslFormContent.Icon = Icon.FromHandle(((Bitmap)imageList.Images[selectedNode.ImageIndex]).GetHicon());
						}
						else
						{
							hslFormContent.Icon = Icon.FromHandle(Resources.Method_636.GetHicon());
						}
						hslFormContent.Show(dockPanel1);
						hslFormContent.LoadXmlParameter(xElement);
					}
				}
			}
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
			components = new System.ComponentModel.Container();
			treeView2 = new System.Windows.Forms.TreeView();
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
			deleteDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
			treeView2.Location = new System.Drawing.Point(0, 0);
			treeView2.Name = "treeView2";
			treeView2.Size = new System.Drawing.Size(221, 561);
			treeView2.TabIndex = 1;
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
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(221, 561);
			base.Controls.Add(treeView2);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormSaveList";
			Text = "Save List";
			base.Load += new System.EventHandler(FormSaveList_Load);
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
