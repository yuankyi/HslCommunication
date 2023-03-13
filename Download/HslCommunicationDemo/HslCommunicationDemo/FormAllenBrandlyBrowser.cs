using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.LogNet;
using HslCommunication.Profinet.AllenBradley;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormAllenBrandlyBrowser : HslFormContent
	{
		private AllenBradleyNet allenBradleyNet = null;

		private TreeNode treeViewSelectedNode = null;

		private AbTagItem[] rootTags = null;

		private Dictionary<int, AbTagItem[]> dictStructDefine;

		private IContainer components = null;

		private Panel panel1;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private Label label1;

		private SplitContainer splitContainer1;

		private TreeView treeView1;

		private Panel panel2;

		private TextBox textBox4;

		private Label label2;

		private Button button3;

		private Panel panel3;

		private Panel panel4;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private TextBox textBox16;

		private Label label8;

		private TextBox textBox15;

		private Label label23;

		private UserControlHead userControlHead1;

		private DataGridView dataGridView1;

		private Button button4;

		private DataGridViewTextBoxColumn Column_number;

		private DataGridViewImageColumn Column_image;

		private DataGridViewTextBoxColumn Column_name;

		private DataGridViewTextBoxColumn Column_type;

		private DataGridViewTextBoxColumn Column_TypeName;

		private DataGridViewTextBoxColumn Column_value;

		private TextBox textBox_regex;

		public FormAllenBrandlyBrowser()
		{
			InitializeComponent();
		}

		private void RedisBrowser_Load(object sender, EventArgs e)
		{
			ImageList imageList = new ImageList();
			imageList.Images.Add("VirtualMachine", Resources.VirtualMachine);
			imageList.Images.Add("Class_489", Resources.Class_489);
			imageList.Images.Add("Enum_582", Resources.Enum_582);
			imageList.Images.Add("brackets_Square_16xMD", Resources.brackets_Square_16xMD);
			imageList.Images.Add("Method_636", Resources.Method_636);
			imageList.Images.Add("Module_648", Resources.Module_648);
			imageList.Images.Add("Structure_507", Resources.Structure_507);
			treeView1.ImageList = imageList;
			treeView1.Nodes.Add("Values");
			treeView1.Nodes[0].ImageKey = "VirtualMachine";
			treeView1.Nodes[0].SelectedImageKey = "VirtualMachine";
			treeViewSelectedNode = treeView1.Nodes[0];
			panel3.Enabled = false;
			panel4.Dock = DockStyle.Fill;
			dataGridView1.SizeChanged += DataGridView1_SizeChanged;
		}

		private void DataGridView1_SizeChanged(object sender, EventArgs e)
		{
			dataGridView1.Columns[5].Width = dataGridView1.Width - 21 - 435;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int result;
			byte result2;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show(DemoUtils.PortInputWrong);
			}
			else if (!byte.TryParse(textBox15.Text, out result2))
			{
				MessageBox.Show(DemoUtils.SlotInputWrong);
			}
			else
			{
				dictStructDefine = new Dictionary<int, AbTagItem[]>();
				AllenBradleyNet obj = allenBradleyNet;
				if (obj != null)
				{
					obj.ConnectClose();
				}
				allenBradleyNet = new AllenBradleyNet();
				allenBradleyNet.IpAddress = textBox1.Text;
				allenBradleyNet.Port = result;
				allenBradleyNet.Slot = result2;
				if (!string.IsNullOrEmpty(textBox16.Text))
				{
					allenBradleyNet.MessageRouter = new MessageRouter(textBox16.Text);
				}
				OperateResult operateResult = allenBradleyNet.ConnectServer();
				if (operateResult.IsSuccess)
				{
					MessageBox.Show(StringResources.Language.ConnectedSuccess);
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
					panel3.Enabled = true;
					TagRefresh();
				}
				else
				{
					MessageBox.Show(StringResources.Language.ConnectedFailed + operateResult.ToMessageShowString());
				}
			}
		}

		private void LogNet_BeforeSaveToFile(object sender, HslEventArgs e)
		{
			Invoke((Action)delegate
			{
			});
		}

		private void button3_Click(object sender, EventArgs e)
		{
			TagRefresh();
		}

		private void TagRefresh()
		{
			treeView1.Nodes[0].Nodes.Clear();
			OperateResult<AbTagItem[]> operateResult = allenBradleyNet.TagEnumerator();
			if (!operateResult.IsSuccess)
			{
				MessageBox.Show(operateResult.Message);
			}
			else
			{
				rootTags = operateResult.Content;
				AddTreeNode(treeView1.Nodes[0], operateResult.Content, string.Empty, true, true);
				treeView1.Nodes[0].Expand();
			}
		}

		private string GetIamgeKeyByTag(AbTagItem abTag)
		{
			if (abTag.ArrayDimension == 1)
			{
				return "brackets_Square_16xMD";
			}
			if (abTag.ArrayDimension > 1)
			{
				return "Module_648";
			}
			if (abTag.IsStruct)
			{
				return "Class_489";
			}
			return "Enum_582";
		}

		private void RenderDataGridView(AbTagItem[] items)
		{
			if (items == null)
			{
				items = new AbTagItem[0];
			}
			DemoUtils.DataGridSpecifyRowCount(dataGridView1, items.Length);
			for (int i = 0; i < items.Length; i++)
			{
				dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
				dataGridView1.Rows[i].Cells[1].Value = treeView1.ImageList.Images[GetIamgeKeyByTag(items[i])];
				dataGridView1.Rows[i].Cells[2].Value = items[i].Name;
				dataGridView1.Rows[i].Cells[3].Value = items[i].SymbolType.ToString("X");
				dataGridView1.Rows[i].Cells[4].Value = items[i].GetTypeText();
				if (items[i].Tag != null)
				{
					dataGridView1.Rows[i].Cells[5].Value = items[i].Tag.ToString();
				}
				else
				{
					dataGridView1.Rows[i].Cells[5].Value = "";
				}
			}
		}

		private void AddTreeNode(TreeNode parent, AbTagItem[] items, string parentName, bool showDataGrid, bool regexMatch)
		{
			foreach (AbTagItem abTagItem in items)
			{
				if (!regexMatch || string.IsNullOrEmpty(textBox_regex.Text) || Regex.IsMatch(abTagItem.Name, textBox_regex.Text))
				{
					TreeNode treeNode = new TreeNode(abTagItem.Name);
					treeNode.Name = (string.IsNullOrEmpty(parentName) ? abTagItem.Name : (parentName + "." + abTagItem.Name));
					treeNode.ImageKey = GetIamgeKeyByTag(abTagItem);
					treeNode.SelectedImageKey = GetIamgeKeyByTag(abTagItem);
					treeNode.Tag = abTagItem;
					parent.Nodes.Add(treeNode);
					if (abTagItem.IsStruct)
					{
						OperateResult<AbTagItem[]> @struct = GetStruct(abTagItem);
						if (@struct.IsSuccess)
						{
							abTagItem.Members = @struct.Content;
							if (abTagItem.ArrayDimension == 0)
							{
								AddTreeNode(treeNode, @struct.Content, treeNode.Name, false, false);
							}
							else if (abTagItem.ArrayDimension == 1)
							{
								for (int j = 0; j < abTagItem.ArrayLength[0]; j++)
								{
									TreeNode treeNode2 = new TreeNode(abTagItem.Name + string.Format("[{0}]", j));
									treeNode2.Name = (string.IsNullOrEmpty(parentName) ? (abTagItem.Name + string.Format("[{0}]", j)) : (parentName + "." + abTagItem.Name + string.Format("[{0}]", j)));
									treeNode2.ImageKey = GetIamgeKeyByTag(abTagItem);
									treeNode2.SelectedImageKey = GetIamgeKeyByTag(abTagItem);
									AbTagItem abTagItem2 = new AbTagItem();
									abTagItem2.Name = abTagItem.Name + string.Format("[{0}]", j);
									abTagItem2.InstanceID = abTagItem.InstanceID;
									abTagItem2.SymbolType = abTagItem.SymbolType;
									abTagItem2.IsStruct = abTagItem.IsStruct;
									abTagItem2.ArrayDimension = 0;
									abTagItem2.ArrayLength = abTagItem.ArrayLength;
									abTagItem2.Members = AbTagItem.CloneBy(abTagItem.Members);
									treeNode2.Tag = abTagItem2;
									AddTreeNode(treeNode2, @struct.Content, treeNode2.Name, false, false);
									treeNode.Nodes.Add(treeNode2);
								}
							}
							else if (abTagItem.ArrayDimension == 2)
							{
								for (int k = 0; k < abTagItem.ArrayLength[0]; k++)
								{
									for (int l = 0; l < abTagItem.ArrayLength[1]; l++)
									{
										TreeNode treeNode3 = new TreeNode(abTagItem.Name + string.Format("[{0},{1}]", k, l));
										treeNode3.Name = (string.IsNullOrEmpty(parentName) ? (abTagItem.Name + string.Format("[{0},{1}]", k, l)) : (parentName + "." + abTagItem.Name + string.Format("[{0},{1}]", k, l)));
										treeNode3.ImageKey = GetIamgeKeyByTag(abTagItem);
										treeNode3.SelectedImageKey = GetIamgeKeyByTag(abTagItem);
										AbTagItem abTagItem3 = new AbTagItem();
										abTagItem3.Name = abTagItem.Name + string.Format("[{0},{1}]", k, l);
										abTagItem3.InstanceID = abTagItem.InstanceID;
										abTagItem3.SymbolType = abTagItem.SymbolType;
										abTagItem3.IsStruct = abTagItem.IsStruct;
										abTagItem3.ArrayDimension = 0;
										abTagItem3.ArrayLength = abTagItem.ArrayLength;
										abTagItem3.Members = AbTagItem.CloneBy(abTagItem.Members);
										treeNode3.Tag = abTagItem3;
										AddTreeNode(treeNode3, @struct.Content, treeNode3.Name, false, false);
										treeNode.Nodes.Add(treeNode3);
									}
								}
							}
						}
					}
				}
			}
			if (showDataGrid)
			{
				RenderDataGridView(items);
			}
		}

		private OperateResult<AbTagItem[]> GetStruct(AbTagItem tagItem)
		{
			int key = tagItem.SymbolType & 0xFFF;
			if (dictStructDefine.ContainsKey(key))
			{
				return OperateResult.CreateSuccessResult(AbTagItem.CloneBy(dictStructDefine[key]));
			}
			OperateResult<AbTagItem[]> operateResult = allenBradleyNet.StructTagEnumerator(tagItem);
			if (operateResult.IsSuccess)
			{
				dictStructDefine.Add(key, AbTagItem.CloneBy(operateResult.Content));
			}
			return operateResult;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			panel3.Enabled = false;
			button1.Enabled = true;
			button2.Enabled = false;
			allenBradleyNet.ConnectClose();
		}

		private void ShowDataRoots()
		{
			if (rootTags != null)
			{
				AbTagItem[] array = rootTags;
				foreach (AbTagItem abTagItem in array)
				{
					if (!abTagItem.IsStruct)
					{
						if (abTagItem.ArrayDimension == 0)
						{
							if (abTagItem.SymbolType == 194)
							{
								OperateResult<byte> operateResult = allenBradleyNet.ReadByte(abTagItem.Name);
								if (operateResult.IsSuccess)
								{
									abTagItem.Tag = (sbyte)operateResult.Content;
								}
							}
							else if (abTagItem.SymbolType == 195)
							{
								OperateResult<short> operateResult2 = allenBradleyNet.ReadInt16(abTagItem.Name);
								if (operateResult2.IsSuccess)
								{
									abTagItem.Tag = operateResult2.Content;
								}
							}
							else if (abTagItem.SymbolType == 196)
							{
								OperateResult<int> operateResult3 = allenBradleyNet.ReadInt32(abTagItem.Name);
								if (operateResult3.IsSuccess)
								{
									abTagItem.Tag = operateResult3.Content;
								}
							}
							else if (abTagItem.SymbolType == 197)
							{
								OperateResult<long> operateResult4 = allenBradleyNet.ReadInt64(abTagItem.Name);
								if (operateResult4.IsSuccess)
								{
									abTagItem.Tag = operateResult4.Content;
								}
							}
							else if (abTagItem.SymbolType == 198)
							{
								OperateResult<byte> operateResult5 = allenBradleyNet.ReadByte(abTagItem.Name);
								if (operateResult5.IsSuccess)
								{
									abTagItem.Tag = operateResult5.Content;
								}
							}
							else if (abTagItem.SymbolType == 199)
							{
								OperateResult<ushort> operateResult6 = allenBradleyNet.ReadUInt16(abTagItem.Name);
								if (operateResult6.IsSuccess)
								{
									abTagItem.Tag = operateResult6.Content;
								}
							}
							else if (abTagItem.SymbolType == 200)
							{
								OperateResult<uint> operateResult7 = allenBradleyNet.ReadUInt32(abTagItem.Name);
								if (operateResult7.IsSuccess)
								{
									abTagItem.Tag = operateResult7.Content;
								}
							}
							else if (abTagItem.SymbolType == 201)
							{
								OperateResult<ulong> operateResult8 = allenBradleyNet.ReadUInt64(abTagItem.Name);
								if (operateResult8.IsSuccess)
								{
									abTagItem.Tag = operateResult8.Content;
								}
							}
							else if (abTagItem.SymbolType == 193)
							{
								OperateResult<bool> operateResult9 = allenBradleyNet.ReadBool(abTagItem.Name);
								if (operateResult9.IsSuccess)
								{
									abTagItem.Tag = operateResult9.Content;
								}
							}
							else if (abTagItem.SymbolType == 202)
							{
								OperateResult<float> operateResult10 = allenBradleyNet.ReadFloat(abTagItem.Name);
								if (operateResult10.IsSuccess)
								{
									abTagItem.Tag = operateResult10.Content;
								}
							}
							else if (abTagItem.SymbolType == 203)
							{
								OperateResult<double> operateResult11 = allenBradleyNet.ReadDouble(abTagItem.Name);
								if (operateResult11.IsSuccess)
								{
									abTagItem.Tag = operateResult11.Content;
								}
							}
						}
						else if (abTagItem.ArrayDimension == 1)
						{
							if (abTagItem.SymbolType == 194)
							{
								OperateResult<byte[]> operateResult12 = allenBradleyNet.Read(abTagItem.Name, (ushort)abTagItem.ArrayLength[0]);
								if (operateResult12.IsSuccess)
								{
									sbyte[] array2 = new sbyte[operateResult12.Content.Length];
									for (int j = 0; j < array2.Length; j++)
									{
										array2[j] = (sbyte)operateResult12.Content[j];
									}
									abTagItem.Tag = array2.ToArrayString();
								}
							}
							else if (abTagItem.SymbolType == 195)
							{
								OperateResult<short[]> operateResult13 = allenBradleyNet.ReadInt16(abTagItem.Name, (ushort)abTagItem.ArrayLength[0]);
								if (operateResult13.IsSuccess)
								{
									abTagItem.Tag = operateResult13.Content.ToArrayString();
								}
							}
							else if (abTagItem.SymbolType == 196)
							{
								OperateResult<int[]> operateResult14 = allenBradleyNet.ReadInt32(abTagItem.Name, (ushort)abTagItem.ArrayLength[0]);
								if (operateResult14.IsSuccess)
								{
									abTagItem.Tag = operateResult14.Content.ToArrayString();
								}
							}
							else if (abTagItem.SymbolType == 197)
							{
								OperateResult<long[]> operateResult15 = allenBradleyNet.ReadInt64(abTagItem.Name, (ushort)abTagItem.ArrayLength[0]);
								if (operateResult15.IsSuccess)
								{
									abTagItem.Tag = operateResult15.Content.ToArrayString();
								}
							}
							else if (abTagItem.SymbolType == 198)
							{
								OperateResult<byte[]> operateResult16 = allenBradleyNet.Read(abTagItem.Name, (ushort)abTagItem.ArrayLength[0]);
								if (operateResult16.IsSuccess)
								{
									abTagItem.Tag = operateResult16.Content.ToArrayString();
								}
							}
							else if (abTagItem.SymbolType == 199)
							{
								OperateResult<ushort[]> operateResult17 = allenBradleyNet.ReadUInt16(abTagItem.Name, (ushort)abTagItem.ArrayLength[0]);
								if (operateResult17.IsSuccess)
								{
									abTagItem.Tag = operateResult17.Content.ToArrayString();
								}
							}
							else if (abTagItem.SymbolType == 200)
							{
								OperateResult<uint[]> operateResult18 = allenBradleyNet.ReadUInt32(abTagItem.Name, (ushort)abTagItem.ArrayLength[0]);
								if (operateResult18.IsSuccess)
								{
									abTagItem.Tag = operateResult18.Content.ToArrayString();
								}
							}
							else if (abTagItem.SymbolType == 201)
							{
								OperateResult<ulong[]> operateResult19 = allenBradleyNet.ReadUInt64(abTagItem.Name, (ushort)abTagItem.ArrayLength[0]);
								if (operateResult19.IsSuccess)
								{
									abTagItem.Tag = operateResult19.Content.ToArrayString();
								}
							}
							else if (abTagItem.SymbolType == 202)
							{
								OperateResult<float[]> operateResult20 = allenBradleyNet.ReadFloat(abTagItem.Name, (ushort)abTagItem.ArrayLength[0]);
								if (operateResult20.IsSuccess)
								{
									abTagItem.Tag = operateResult20.Content.ToArrayString();
								}
							}
							else if (abTagItem.SymbolType == 203)
							{
								OperateResult<double[]> operateResult21 = allenBradleyNet.ReadDouble(abTagItem.Name, (ushort)abTagItem.ArrayLength[0]);
								if (operateResult21.IsSuccess)
								{
									abTagItem.Tag = operateResult21.Content.ToArrayString();
								}
							}
							else if (abTagItem.SymbolType == 211)
							{
								OperateResult<int[]> operateResult22 = allenBradleyNet.ReadInt32(abTagItem.Name, (ushort)abTagItem.ArrayLength[0]);
								if (operateResult22.IsSuccess)
								{
									abTagItem.Tag = SoftBasic.BoolArrayToString(allenBradleyNet.ByteTransform.TransByte(operateResult22.Content).ToBoolArray());
								}
							}
						}
					}
				}
			}
		}

		private void ReadStruct(AbTagItem tagItem, string tagName)
		{
			if (tagItem.IsStruct)
			{
				OperateResult<byte[]> operateResult = allenBradleyNet.Read(tagName, 1);
				if (operateResult.IsSuccess && tagItem.Members != null)
				{
					AbTagItem[] members = tagItem.Members;
					foreach (AbTagItem abTagItem in members)
					{
						if (!abTagItem.IsStruct)
						{
							if (abTagItem.ArrayDimension == 0)
							{
								if (abTagItem.SymbolType == 194)
								{
									abTagItem.Tag = ((sbyte)operateResult.Content[abTagItem.ByteOffset]).ToString();
								}
								else if (abTagItem.SymbolType == 195)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransInt16(operateResult.Content, abTagItem.ByteOffset).ToString();
								}
								else if (abTagItem.SymbolType == 196)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransInt32(operateResult.Content, abTagItem.ByteOffset).ToString();
								}
								else if (abTagItem.SymbolType == 197)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransInt64(operateResult.Content, abTagItem.ByteOffset).ToString();
								}
								else if (abTagItem.SymbolType == 198)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransByte(operateResult.Content, abTagItem.ByteOffset).ToString();
								}
								else if (abTagItem.SymbolType == 199)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransUInt16(operateResult.Content, abTagItem.ByteOffset).ToString();
								}
								else if (abTagItem.SymbolType == 200)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransUInt32(operateResult.Content, abTagItem.ByteOffset).ToString();
								}
								else if (abTagItem.SymbolType == 201)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransUInt64(operateResult.Content, abTagItem.ByteOffset).ToString();
								}
								else if (abTagItem.SymbolType == 193)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransBool(operateResult.Content, abTagItem.ByteOffset * 8 + abTagItem.ArrayLength[0]).ToString();
								}
								else if (abTagItem.SymbolType == 202)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransSingle(operateResult.Content, abTagItem.ByteOffset).ToString();
								}
								else if (abTagItem.SymbolType == 203)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransDouble(operateResult.Content, abTagItem.ByteOffset).ToString();
								}
								else if (abTagItem.SymbolType == 211)
								{
									abTagItem.Tag = SoftBasic.BoolArrayToString(allenBradleyNet.ByteTransform.TransByte(operateResult.Content, abTagItem.ByteOffset, 4).ToBoolArray());
								}
							}
							else if (abTagItem.ArrayDimension == 1)
							{
								if (abTagItem.SymbolType == 194)
								{
									abTagItem.Tag = Encoding.UTF8.GetString(operateResult.Content, abTagItem.ByteOffset, abTagItem.ArrayLength[0]);
								}
								else if (abTagItem.SymbolType == 195)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransInt16(operateResult.Content, abTagItem.ByteOffset, abTagItem.ArrayLength[0]).ToArrayString();
								}
								else if (abTagItem.SymbolType == 196)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransInt32(operateResult.Content, abTagItem.ByteOffset, abTagItem.ArrayLength[0]).ToArrayString();
								}
								else if (abTagItem.SymbolType == 197)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransInt64(operateResult.Content, abTagItem.ByteOffset, abTagItem.ArrayLength[0]).ToArrayString();
								}
								else if (abTagItem.SymbolType == 198)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransByte(operateResult.Content, abTagItem.ByteOffset, abTagItem.ArrayLength[0]).ToArrayString();
								}
								else if (abTagItem.SymbolType == 199)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransUInt16(operateResult.Content, abTagItem.ByteOffset, abTagItem.ArrayLength[0]).ToArrayString();
								}
								else if (abTagItem.SymbolType == 200)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransUInt32(operateResult.Content, abTagItem.ByteOffset, abTagItem.ArrayLength[0]).ToArrayString();
								}
								else if (abTagItem.SymbolType == 201)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransUInt64(operateResult.Content, abTagItem.ByteOffset, abTagItem.ArrayLength[0]).ToArrayString();
								}
								else if (abTagItem.SymbolType == 202)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransSingle(operateResult.Content, abTagItem.ByteOffset, abTagItem.ArrayLength[0]).ToArrayString();
								}
								else if (abTagItem.SymbolType == 203)
								{
									abTagItem.Tag = allenBradleyNet.ByteTransform.TransDouble(operateResult.Content, abTagItem.ByteOffset, abTagItem.ArrayLength[0]).ToArrayString();
								}
								else if (abTagItem.SymbolType == 211)
								{
									abTagItem.Tag = SoftBasic.BoolArrayToString(allenBradleyNet.ByteTransform.TransByte(operateResult.Content, abTagItem.ByteOffset, abTagItem.ArrayLength[0] * 4).ToBoolArray());
								}
							}
						}
					}
				}
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (treeViewSelectedNode != null)
			{
				AbTagItem abTagItem = treeViewSelectedNode.Tag as AbTagItem;
				if (abTagItem != null)
				{
					if (abTagItem.IsStruct && abTagItem.ArrayDimension == 0)
					{
						ReadStruct(abTagItem, treeViewSelectedNode.Name);
						RenderDataGridView(abTagItem.Members);
					}
					else if (treeViewSelectedNode.Parent.ImageKey == "VirtualMachine")
					{
						ShowDataRoots();
						RenderDataGridView(rootTags);
					}
				}
				else if (treeViewSelectedNode.ImageKey == "VirtualMachine")
				{
					ShowDataRoots();
					RenderDataGridView(rootTags);
				}
			}
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			treeViewSelectedNode = e.Node;
			RenderDataGridViewBySelect(e.Node);
		}

		private void RenderDataGridViewBySelect(TreeNode treeNode)
		{
			AbTagItem abTagItem = treeNode.Tag as AbTagItem;
			if (abTagItem != null)
			{
				textBox4.Text = treeNode.Name;
				if (abTagItem.IsStruct)
				{
					RenderStructDataSelect(treeNode);
				}
				else
				{
					AbTagItem abTagItem2 = treeNode.Parent.Tag as AbTagItem;
					if (abTagItem2 != null)
					{
						if (abTagItem2.IsStruct && abTagItem2.ArrayDimension == 1)
						{
							RenderDataGridView(abTagItem2.Members);
						}
					}
					else if (treeNode.Parent.Tag == null)
					{
						RenderDataGridView(rootTags);
					}
				}
			}
			else if (treeNode.ImageKey == "VirtualMachine")
			{
				textBox4.Text = string.Empty;
				RenderDataGridView(rootTags);
			}
		}

		private void RenderStructDataSelect(TreeNode treeNode)
		{
			AbTagItem abTagItem = treeNode.Tag as AbTagItem;
			if (abTagItem != null)
			{
				if (abTagItem.IsStruct)
				{
					if (abTagItem.ArrayDimension == 0)
					{
						RenderDataGridView(abTagItem.Members);
					}
					else
					{
						RenderStructDataSelect(treeNode.Parent);
					}
				}
			}
			else
			{
				RenderDataGridView(rootTags);
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlSlot, textBox15.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox15.Text = element.Attribute(DemoDeviceList.XmlSlot).Value;
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			panel1 = new System.Windows.Forms.Panel();
			textBox16 = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			textBox15 = new System.Windows.Forms.TextBox();
			label23 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			textBox_regex = new System.Windows.Forms.TextBox();
			button3 = new System.Windows.Forms.Button();
			treeView1 = new System.Windows.Forms.TreeView();
			panel2 = new System.Windows.Forms.Panel();
			panel4 = new System.Windows.Forms.Panel();
			button4 = new System.Windows.Forms.Button();
			dataGridView1 = new System.Windows.Forms.DataGridView();
			Column_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column_image = new System.Windows.Forms.DataGridViewImageColumn();
			Column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column_TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			label2 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			panel3 = new System.Windows.Forms.Panel();
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			panel2.SuspendLayout();
			panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			panel3.SuspendLayout();
			statusStrip1.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox16);
			panel1.Controls.Add(label8);
			panel1.Controls.Add(textBox15);
			panel1.Controls.Add(label23);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(2, 34);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(976, 40);
			panel1.TabIndex = 8;
			textBox16.Location = new System.Drawing.Point(576, 7);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(159, 23);
			textBox16.TabIndex = 19;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(520, 10);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(50, 17);
			label8.TabIndex = 18;
			label8.Text = "Router:";
			textBox15.Location = new System.Drawing.Point(469, 7);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(32, 23);
			textBox15.TabIndex = 17;
			textBox15.Text = "0";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(425, 10);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(41, 17);
			label23.TabIndex = 16;
			label23.Text = "slot：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(838, 4);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "disconnect";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(741, 4);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "connect";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(276, 7);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(141, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "44818";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(222, 10);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(45, 17);
			label3.TabIndex = 2;
			label3.Text = "port：";
			textBox1.Location = new System.Drawing.Point(66, 7);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(141, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 10);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(55, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip addr:";
			splitContainer1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			splitContainer1.Location = new System.Drawing.Point(3, 3);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Panel1.Controls.Add(textBox_regex);
			splitContainer1.Panel1.Controls.Add(button3);
			splitContainer1.Panel1.Controls.Add(treeView1);
			splitContainer1.Panel2.Controls.Add(panel2);
			splitContainer1.Size = new System.Drawing.Size(970, 539);
			splitContainer1.SplitterDistance = 218;
			splitContainer1.TabIndex = 9;
			textBox_regex.Location = new System.Drawing.Point(3, 6);
			textBox_regex.Name = "textBox_regex";
			textBox_regex.Size = new System.Drawing.Size(129, 23);
			textBox_regex.TabIndex = 2;
			button3.Location = new System.Drawing.Point(142, 5);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(75, 26);
			button3.TabIndex = 1;
			button3.Text = "refresh";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			treeView1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			treeView1.Location = new System.Drawing.Point(3, 32);
			treeView1.Name = "treeView1";
			treeView1.Size = new System.Drawing.Size(207, 504);
			treeView1.TabIndex = 0;
			treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);
			panel2.Controls.Add(panel4);
			panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			panel2.Location = new System.Drawing.Point(0, 0);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(748, 539);
			panel2.TabIndex = 0;
			panel4.Controls.Add(button4);
			panel4.Controls.Add(dataGridView1);
			panel4.Controls.Add(label2);
			panel4.Controls.Add(textBox4);
			panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			panel4.Location = new System.Drawing.Point(0, 0);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(748, 539);
			panel4.TabIndex = 5;
			button4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button4.Location = new System.Drawing.Point(648, 3);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(91, 27);
			button4.TabIndex = 6;
			button4.Text = "Show Value";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.AllowUserToResizeRows = false;
			dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(236, 236, 255);
			dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			dataGridView1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			dataGridView1.BackgroundColor = System.Drawing.Color.White;
			dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(Column_number, Column_image, Column_name, Column_type, Column_TypeName, Column_value);
			dataGridView1.Location = new System.Drawing.Point(3, 35);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersVisible = false;
			dataGridView1.RowTemplate.Height = 23;
			dataGridView1.Size = new System.Drawing.Size(736, 501);
			dataGridView1.TabIndex = 5;
			Column_number.HeaderText = "Number";
			Column_number.Name = "Column_number";
			Column_number.ReadOnly = true;
			Column_number.Width = 80;
			Column_image.HeaderText = "";
			Column_image.Name = "Column_image";
			Column_image.ReadOnly = true;
			Column_image.Width = 25;
			Column_name.HeaderText = "Name";
			Column_name.Name = "Column_name";
			Column_name.ReadOnly = true;
			Column_name.Width = 170;
			Column_type.HeaderText = "TypeCode";
			Column_type.Name = "Column_type";
			Column_type.ReadOnly = true;
			Column_type.Width = 80;
			Column_TypeName.HeaderText = "TypeName";
			Column_TypeName.Name = "Column_TypeName";
			Column_TypeName.ReadOnly = true;
			Column_TypeName.Width = 80;
			Column_value.HeaderText = "Value";
			Column_value.Name = "Column_value";
			Column_value.ReadOnly = true;
			Column_value.Width = 298;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 9);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(67, 17);
			label2.TabIndex = 0;
			label2.Text = "string tag:";
			textBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox4.Location = new System.Drawing.Point(73, 6);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(569, 23);
			textBox4.TabIndex = 1;
			panel3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel3.Controls.Add(splitContainer1);
			panel3.Location = new System.Drawing.Point(2, 77);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(976, 545);
			panel3.TabIndex = 10;
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1]
			{
				toolStripStatusLabel1
			});
			statusStrip1.Location = new System.Drawing.Point(0, 625);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(981, 22);
			statusStrip1.TabIndex = 11;
			statusStrip1.Text = "statusStrip1";
			toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			toolStripStatusLabel1.Size = new System.Drawing.Size(188, 17);
			toolStripStatusLabel1.Text = "就绪，支持节点的正则表达式查询";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/9607929.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "CIP";
			userControlHead1.Size = new System.Drawing.Size(981, 32);
			userControlHead1.TabIndex = 12;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(981, 647);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(statusStrip1);
			base.Controls.Add(panel3);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormAllenBrandlyBrowser";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Allen Brandly Browser";
			base.Load += new System.EventHandler(RedisBrowser_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			panel3.ResumeLayout(false);
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
