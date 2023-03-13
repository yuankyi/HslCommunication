using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core.Address;
using HslCommunication.ModBus;
using HslCommunication.Profinet.Melsec;
using HslCommunication.Profinet.Melsec.Helper;
using HslCommunication.Profinet.Omron;
using HslCommunication.Profinet.Omron.Helper;
using HslCommunication.Profinet.Siemens;
using HslControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HslCommunicationDemo.HslDebug
{
	public class FormMessageCreate : Form
	{
		private MelsecMcNet melsec1 = new MelsecMcNet();

		private MelsecFxLinks melsec2 = new MelsecFxLinks();

		private OmronFinsNet omron1 = new OmronFinsNet();

		private OmronFinsUdp omron2 = new OmronFinsUdp();

		private OmronHostLink omron3 = new OmronHostLink();

		private IContainer components = null;

		private TreeView treeView1;

		private HslPanelHead hslPanelHead1;

		private Button button_read_word;

		private Button button_read_bool;

		private TextBox textBox2;

		private Label label2;

		private TextBox textBox1;

		private Label label1;

		private Label label3;

		public MessgaeCreate MessageCreate
		{
			get;
			set;
		}

		public FormMessageCreate()
		{
			InitializeComponent();
		}

		public void AddTreeChild(TreeNode parent, string text, Func<string, ushort, OperateResult<byte[]>> buildReadBool, Func<string, ushort, OperateResult<byte[]>> buildReadWord, bool hex = true)
		{
			MessgaeCreate messgaeCreate = new MessgaeCreate();
			messgaeCreate.BuildReadBool = buildReadBool;
			messgaeCreate.BuildReadWord = buildReadWord;
			messgaeCreate.Text = text;
			messgaeCreate.HexBinary = hex;
			TreeNode treeNode = new TreeNode(text);
			treeNode.Tag = messgaeCreate;
			parent.Nodes.Add(treeNode);
		}

		private void FormMessageCreate_Load(object sender, EventArgs e)
		{
			TreeNode treeNode = new TreeNode("Melsec");
			AddTreeChild(treeNode, "Qna3E-Binary", delegate(string address, ushort length)
			{
				OperateResult<McAddressData> operateResult19 = melsec1.McAnalysisAddress(address, length);
				if (!operateResult19.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult19);
				}
				byte[] mcCore4 = McBinaryHelper.BuildReadMcCoreCommand(operateResult19.Content, true);
				return OperateResult.CreateSuccessResult(McBinaryHelper.PackMcCommand(mcCore4, 0, 0));
			}, delegate(string address, ushort length)
			{
				OperateResult<McAddressData> operateResult18 = melsec1.McAnalysisAddress(address, length);
				if (!operateResult18.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult18);
				}
				byte[] mcCore3 = McBinaryHelper.BuildReadMcCoreCommand(operateResult18.Content, false);
				return OperateResult.CreateSuccessResult(McBinaryHelper.PackMcCommand(mcCore3, 0, 0));
			});
			AddTreeChild(treeNode, "Qna3E-Ascii", delegate(string address, ushort length)
			{
				OperateResult<McAddressData> operateResult17 = melsec1.McAnalysisAddress(address, length);
				if (!operateResult17.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult17);
				}
				byte[] mcCore2 = McAsciiHelper.BuildAsciiReadMcCoreCommand(operateResult17.Content, true);
				return OperateResult.CreateSuccessResult(McAsciiHelper.PackMcCommand(mcCore2, 0, 0));
			}, delegate(string address, ushort length)
			{
				OperateResult<McAddressData> operateResult16 = melsec1.McAnalysisAddress(address, length);
				if (!operateResult16.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult16);
				}
				byte[] mcCore = McAsciiHelper.BuildAsciiReadMcCoreCommand(operateResult16.Content, false);
				return OperateResult.CreateSuccessResult(McAsciiHelper.PackMcCommand(mcCore, 0, 0));
			}, false);
			AddTreeChild(treeNode, "A1E-Binary", (string address, ushort length) => MelsecA1ENet.BuildReadCommand(address, length, true, byte.MaxValue).Then((List<byte[]> m) => OperateResult.CreateSuccessResult(m[0])), (string address, ushort length) => MelsecA1ENet.BuildReadCommand(address, length, false, byte.MaxValue).Then((List<byte[]> m) => OperateResult.CreateSuccessResult(m[0])));
			AddTreeChild(treeNode, "A1E-Ascii", (string address, ushort length) => MelsecA1EAsciiNet.BuildReadCommand(address, length, true, byte.MaxValue), (string address, ushort length) => MelsecA1EAsciiNet.BuildReadCommand(address, length, false, byte.MaxValue), false);
			AddTreeChild(treeNode, "FxLinks", delegate(string address, ushort length)
			{
				OperateResult<List<byte[]>> operateResult15 = MelsecFxLinksHelper.BuildReadCommand(melsec2.Station, address, length, true, melsec2.WaittingTime);
				if (!operateResult15.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult15);
				}
				return OperateResult.CreateSuccessResult(melsec2.PackCommandWithHeader(operateResult15.Content[0]));
			}, delegate(string address, ushort length)
			{
				OperateResult<List<byte[]>> operateResult14 = MelsecFxLinksHelper.BuildReadCommand(melsec2.Station, address, length, false, melsec2.WaittingTime);
				if (!operateResult14.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult14);
				}
				return OperateResult.CreateSuccessResult(melsec2.PackCommandWithHeader(operateResult14.Content[0]));
			}, false);
			treeView1.Nodes.Add(treeNode);
			TreeNode treeNode2 = new TreeNode("Siemens");
			AddTreeChild(treeNode2, "S7", (string address, ushort length) => SiemensS7Net.BuildBitReadCommand(address), delegate(string address, ushort length)
			{
				OperateResult<S7AddressData> operateResult13 = S7AddressData.ParseFrom(address, length);
				if (!operateResult13.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult13);
				}
				return SiemensS7Net.BuildReadCommand(new S7AddressData[1]
				{
					operateResult13.Content
				});
			});
			treeView1.Nodes.Add(treeNode2);
			TreeNode treeNode3 = new TreeNode("Modbus");
			AddTreeChild(treeNode3, "Modbus Tcp", delegate(string address, ushort length)
			{
				OperateResult<byte[][]> operateResult12 = ModbusInfo.BuildReadModbusCommand(address, length, 1, true, 1);
				if (!operateResult12.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult12);
				}
				return OperateResult.CreateSuccessResult(ModbusInfo.PackCommandToTcp(operateResult12.Content[0], 0));
			}, delegate(string address, ushort length)
			{
				OperateResult<byte[][]> operateResult11 = ModbusInfo.BuildReadModbusCommand(address, length, 1, true, 3);
				if (!operateResult11.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult11);
				}
				return OperateResult.CreateSuccessResult(ModbusInfo.PackCommandToTcp(operateResult11.Content[0], 0));
			});
			AddTreeChild(treeNode3, "Modbus Rtu", delegate(string address, ushort length)
			{
				OperateResult<byte[][]> operateResult10 = ModbusInfo.BuildReadModbusCommand(address, length, 1, true, 1);
				if (!operateResult10.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult10);
				}
				return OperateResult.CreateSuccessResult(ModbusInfo.PackCommandToRtu(operateResult10.Content[0]));
			}, delegate(string address, ushort length)
			{
				OperateResult<byte[][]> operateResult9 = ModbusInfo.BuildReadModbusCommand(address, length, 1, true, 3);
				if (!operateResult9.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult9);
				}
				return OperateResult.CreateSuccessResult(ModbusInfo.PackCommandToRtu(operateResult9.Content[0]));
			});
			AddTreeChild(treeNode3, "Modbus Ascii", delegate(string address, ushort length)
			{
				OperateResult<byte[][]> operateResult8 = ModbusInfo.BuildReadModbusCommand(address, length, 1, true, 1);
				if (!operateResult8.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult8);
				}
				return OperateResult.CreateSuccessResult(ModbusInfo.TransModbusCoreToAsciiPackCommand(operateResult8.Content[0]));
			}, delegate(string address, ushort length)
			{
				OperateResult<byte[][]> operateResult7 = ModbusInfo.BuildReadModbusCommand(address, length, 1, true, 3);
				if (!operateResult7.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult7);
				}
				return OperateResult.CreateSuccessResult(ModbusInfo.TransModbusCoreToAsciiPackCommand(operateResult7.Content[0]));
			}, false);
			treeView1.Nodes.Add(treeNode3);
			TreeNode treeNode4 = new TreeNode("Omron");
			AddTreeChild(treeNode4, "Fins Tcp", delegate(string address, ushort length)
			{
				OperateResult<List<byte[]>> operateResult6 = OmronFinsNetHelper.BuildReadCommand(address, length, true, 2147483647);
				if (!operateResult6.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult6);
				}
				return OperateResult.CreateSuccessResult(omron1.PackCommandWithHeader(operateResult6.Content[0]));
			}, delegate(string address, ushort length)
			{
				OperateResult<List<byte[]>> operateResult5 = OmronFinsNetHelper.BuildReadCommand(address, length, false, 2147483647);
				if (!operateResult5.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult5);
				}
				return OperateResult.CreateSuccessResult(omron1.PackCommandWithHeader(operateResult5.Content[0]));
			});
			AddTreeChild(treeNode4, "Fins Udp", delegate(string address, ushort length)
			{
				OperateResult<List<byte[]>> operateResult4 = OmronFinsNetHelper.BuildReadCommand(address, length, true, 2147483647);
				if (!operateResult4.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult4);
				}
				return OperateResult.CreateSuccessResult(omron2.PackCommandWithHeader(operateResult4.Content[0]));
			}, delegate(string address, ushort length)
			{
				OperateResult<List<byte[]>> operateResult3 = OmronFinsNetHelper.BuildReadCommand(address, length, false, 2147483647);
				if (!operateResult3.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult3);
				}
				return OperateResult.CreateSuccessResult(omron2.PackCommandWithHeader(operateResult3.Content[0]));
			});
			AddTreeChild(treeNode4, "Host Link", delegate(string address, ushort length)
			{
				OperateResult<List<byte[]>> operateResult2 = OmronFinsNetHelper.BuildReadCommand(address, length, true, 2147483647);
				if (!operateResult2.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult2);
				}
				return OperateResult.CreateSuccessResult(OmronHostLinkHelper.PackCommand(omron3, 0, operateResult2.Content[0]));
			}, delegate(string address, ushort length)
			{
				OperateResult<List<byte[]>> operateResult = OmronFinsNetHelper.BuildReadCommand(address, length, false, 2147483647);
				if (!operateResult.IsSuccess)
				{
					return OperateResult.CreateFailedResult<byte[]>(operateResult);
				}
				return OperateResult.CreateSuccessResult(OmronHostLinkHelper.PackCommand(omron3, 0, operateResult.Content[0]));
			}, false);
			treeView1.Nodes.Add(treeNode4);
		}

		private void button_read_bool_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeView1.SelectedNode;
			if (selectedNode != null)
			{
				MessgaeCreate messgaeCreate = selectedNode.Tag as MessgaeCreate;
				if (messgaeCreate != null && messgaeCreate.BuildReadBool != null)
				{
					OperateResult<byte[]> operateResult = messgaeCreate.BuildReadBool(textBox1.Text, ushort.Parse(textBox2.Text));
					if (operateResult.IsSuccess)
					{
						messgaeCreate.Result = (messgaeCreate.HexBinary ? operateResult.Content.ToHexString(' ') : SoftBasic.GetAsciiStringRender(operateResult.Content));
						MessageCreate = messgaeCreate;
						base.DialogResult = DialogResult.OK;
					}
					else
					{
						MessageBox.Show("Build failed: " + operateResult.Message);
					}
				}
			}
		}

		private void button_read_word_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeView1.SelectedNode;
			if (selectedNode != null)
			{
				MessgaeCreate messgaeCreate = selectedNode.Tag as MessgaeCreate;
				if (messgaeCreate != null && messgaeCreate.BuildReadWord != null)
				{
					OperateResult<byte[]> operateResult = messgaeCreate.BuildReadWord(textBox1.Text, ushort.Parse(textBox2.Text));
					if (operateResult.IsSuccess)
					{
						messgaeCreate.Result = (messgaeCreate.HexBinary ? operateResult.Content.ToHexString(' ') : SoftBasic.GetAsciiStringRender(operateResult.Content));
						MessageCreate = messgaeCreate;
						base.DialogResult = DialogResult.OK;
					}
					else
					{
						MessageBox.Show("Build failed: " + operateResult.Message);
					}
				}
			}
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			TreeNode selectedNode = treeView1.SelectedNode;
			if (selectedNode != null)
			{
				MessgaeCreate messgaeCreate = selectedNode.Tag as MessgaeCreate;
				if (messgaeCreate != null)
				{
					label3.Text = "协议：" + messgaeCreate.Text;
				}
			}
		}

		private void FormMessageCreate_Shown(object sender, EventArgs e)
		{
			treeView1.ExpandAll();
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
			hslPanelHead1 = new HslControls.HslPanelHead();
			button_read_word = new System.Windows.Forms.Button();
			button_read_bool = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			hslPanelHead1.SuspendLayout();
			SuspendLayout();
			treeView1.Dock = System.Windows.Forms.DockStyle.Left;
			treeView1.Location = new System.Drawing.Point(0, 0);
			treeView1.Name = "treeView1";
			treeView1.Size = new System.Drawing.Size(227, 469);
			treeView1.TabIndex = 0;
			treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);
			hslPanelHead1.Controls.Add(button_read_word);
			hslPanelHead1.Controls.Add(button_read_bool);
			hslPanelHead1.Controls.Add(textBox2);
			hslPanelHead1.Controls.Add(label2);
			hslPanelHead1.Controls.Add(textBox1);
			hslPanelHead1.Controls.Add(label1);
			hslPanelHead1.Location = new System.Drawing.Point(233, 40);
			hslPanelHead1.Name = "hslPanelHead1";
			hslPanelHead1.Size = new System.Drawing.Size(562, 140);
			hslPanelHead1.TabIndex = 1;
			hslPanelHead1.Text = "读取";
			button_read_word.Location = new System.Drawing.Point(189, 93);
			button_read_word.Name = "button_read_word";
			button_read_word.Size = new System.Drawing.Size(162, 38);
			button_read_word.TabIndex = 5;
			button_read_word.Text = "Build Read Byte/Word";
			button_read_word.UseVisualStyleBackColor = true;
			button_read_word.Click += new System.EventHandler(button_read_word_Click);
			button_read_bool.Location = new System.Drawing.Point(14, 93);
			button_read_bool.Name = "button_read_bool";
			button_read_bool.Size = new System.Drawing.Size(162, 38);
			button_read_bool.TabIndex = 4;
			button_read_bool.Text = "Build Read Bool";
			button_read_bool.UseVisualStyleBackColor = true;
			button_read_bool.Click += new System.EventHandler(button_read_bool_Click);
			textBox2.Location = new System.Drawing.Point(426, 43);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(109, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "1";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(357, 46);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(50, 17);
			label2.TabIndex = 2;
			label2.Text = "Length:";
			textBox1.Location = new System.Drawing.Point(94, 43);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(257, 23);
			textBox1.TabIndex = 1;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(11, 46);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(59, 17);
			label1.TabIndex = 0;
			label1.Text = "Address:";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(233, 9);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(44, 17);
			label3.TabIndex = 2;
			label3.Text = "协议：";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(800, 469);
			base.Controls.Add(label3);
			base.Controls.Add(hslPanelHead1);
			base.Controls.Add(treeView1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "FormMessageCreate";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormMessageCreate";
			base.Load += new System.EventHandler(FormMessageCreate_Load);
			base.Shown += new System.EventHandler(FormMessageCreate_Shown);
			hslPanelHead1.ResumeLayout(false);
			hslPanelHead1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
