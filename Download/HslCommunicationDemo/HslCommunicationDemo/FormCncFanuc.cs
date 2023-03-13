using HslCommunication;
using HslCommunication.CNC.Fanuc;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormCncFanuc : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003CAddNCToolStripMenuItem_Click_003Ed__49 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormCncFanuc _003C_003E4__this;

			private TreeNode _003CtreeNode_003E5__1;

			private FileDirInfo _003CfileDirInfo_003E5__2;

			private string _003Cpath_003E5__3;

			private OpenFileDialog _003CopenFileDialog_003E5__4;

			private OperateResult _003Cwrite_003E5__5;

			private OperateResult _003C_003Es__6;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
						num = (_003C_003E1__state = -1);
						goto IL_0144;
					}
					_003CtreeNode_003E5__1 = _003C_003E4__this.treeView1.SelectedNode;
					if (_003CtreeNode_003E5__1 != null)
					{
						object tag = _003CtreeNode_003E5__1.Tag;
						_003CfileDirInfo_003E5__2 = (tag as FileDirInfo);
						if (_003CfileDirInfo_003E5__2 != null)
						{
							if (_003CfileDirInfo_003E5__2.IsDirectory)
							{
								_003Cpath_003E5__3 = _003C_003E4__this.GetPathFromTree(_003CtreeNode_003E5__1);
								_003CopenFileDialog_003E5__4 = new OpenFileDialog();
								if (_003CopenFileDialog_003E5__4.ShowDialog(_003C_003E4__this) == DialogResult.OK)
								{
									awaiter = _003C_003E4__this.fanuc.WriteProgramFileAsync(_003CopenFileDialog_003E5__4.FileName, 512, _003Cpath_003E5__3).GetAwaiter();
									if (!awaiter.IsCompleted)
									{
										num = (_003C_003E1__state = 0);
										_003C_003Eu__1 = awaiter;
										_003CAddNCToolStripMenuItem_Click_003Ed__49 stateMachine = this;
										_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
										return;
									}
									goto IL_0144;
								}
								goto IL_01a9;
							}
							MessageBox.Show("Add nc program must select path!");
						}
					}
					goto end_IL_0007;
					IL_0144:
					_003C_003Es__6 = awaiter.GetResult();
					_003Cwrite_003E5__5 = _003C_003Es__6;
					_003C_003Es__6 = null;
					if (_003Cwrite_003E5__5.IsSuccess)
					{
						MessageBox.Show("Success！");
					}
					else
					{
						MessageBox.Show("failed！" + _003Cwrite_003E5__5.ToMessageShowString());
					}
					_003Cwrite_003E5__5 = null;
					goto IL_01a9;
					IL_01a9:
					_003Cpath_003E5__3 = null;
					_003CopenFileDialog_003E5__4 = null;
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003CtreeNode_003E5__1 = null;
					_003CfileDirInfo_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003CtreeNode_003E5__1 = null;
				_003CfileDirInfo_003E5__2 = null;
				_003C_003Et__builder.SetResult();
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		private sealed class _003CDeleteToolStripMenuItem_Click_003Ed__47 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormCncFanuc _003C_003E4__this;

			private TreeNode _003CtreeNode_003E5__1;

			private string _003Cpath_003E5__2;

			private OperateResult _003Cwrite_003E5__3;

			private OperateResult _003C_003Es__4;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
						num = (_003C_003E1__state = -1);
						goto IL_00b9;
					}
					_003CtreeNode_003E5__1 = _003C_003E4__this.treeView1.SelectedNode;
					if (_003CtreeNode_003E5__1 != null)
					{
						_003Cpath_003E5__2 = _003C_003E4__this.GetPathFromTree(_003CtreeNode_003E5__1);
						awaiter = _003C_003E4__this.fanuc.DeleteFileAsync(_003Cpath_003E5__2).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CDeleteToolStripMenuItem_Click_003Ed__47 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_00b9;
					}
					goto end_IL_0007;
					IL_00b9:
					_003C_003Es__4 = awaiter.GetResult();
					_003Cwrite_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cwrite_003E5__3.IsSuccess)
					{
						MessageBox.Show("Delete success！");
					}
					else
					{
						MessageBox.Show("delete failed！" + _003Cwrite_003E5__3.Message);
					}
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003CtreeNode_003E5__1 = null;
					_003Cpath_003E5__2 = null;
					_003Cwrite_003E5__3 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003CtreeNode_003E5__1 = null;
				_003Cpath_003E5__2 = null;
				_003Cwrite_003E5__3 = null;
				_003C_003Et__builder.SetResult();
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		private sealed class _003CReadNCToolStripMenuItem_Click_003Ed__48 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormCncFanuc _003C_003E4__this;

			private TreeNode _003CtreeNode_003E5__1;

			private FileDirInfo _003CfileDirInfo_003E5__2;

			private string _003Cpath_003E5__3;

			private int _003Cprogram_003E5__4;

			private OperateResult<string> _003Cread_003E5__5;

			private OperateResult<string> _003C_003Es__6;

			private TaskAwaiter<OperateResult<string>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<string>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<string>>);
						num = (_003C_003E1__state = -1);
						goto IL_0123;
					}
					_003CtreeNode_003E5__1 = _003C_003E4__this.treeView1.SelectedNode;
					if (_003CtreeNode_003E5__1 != null)
					{
						object tag = _003CtreeNode_003E5__1.Tag;
						_003CfileDirInfo_003E5__2 = (tag as FileDirInfo);
						if (_003CfileDirInfo_003E5__2 != null && !_003CfileDirInfo_003E5__2.IsDirectory)
						{
							_003Cpath_003E5__3 = _003C_003E4__this.GetPathFromTree(_003CtreeNode_003E5__1.Parent);
							_003Cprogram_003E5__4 = int.Parse(_003CfileDirInfo_003E5__2.Name.Substring(1));
							awaiter = _003C_003E4__this.fanuc.ReadProgramAsync(_003Cprogram_003E5__4, _003Cpath_003E5__3).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CReadNCToolStripMenuItem_Click_003Ed__48 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
								return;
							}
							goto IL_0123;
						}
					}
					goto end_IL_0007;
					IL_0123:
					_003C_003Es__6 = awaiter.GetResult();
					_003Cread_003E5__5 = _003C_003Es__6;
					_003C_003Es__6 = null;
					if (_003Cread_003E5__5.IsSuccess)
					{
						_003C_003E4__this.textBox_program.Text = "Program Content[" + _003Cpath_003E5__3 + "]：" + Environment.NewLine + _003Cread_003E5__5.Content;
					}
					else
					{
						MessageBox.Show("read failed！" + _003Cread_003E5__5.ToMessageShowString());
					}
					_003Cpath_003E5__3 = null;
					_003Cread_003E5__5 = null;
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003CtreeNode_003E5__1 = null;
					_003CfileDirInfo_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003CtreeNode_003E5__1 = null;
				_003CfileDirInfo_003E5__2 = null;
				_003C_003Et__builder.SetResult();
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		private sealed class _003Cbutton1_Click_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormCncFanuc _003C_003E4__this;

			private OperateResult _003Cconnect_003E5__1;

			private OperateResult _003C_003Es__2;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					if (num != 0)
					{
						FanucSeries0i fanuc = _003C_003E4__this.fanuc;
						if (fanuc != null)
						{
							fanuc.ConnectClose();
						}
						_003C_003E4__this.fanuc = new FanucSeries0i(_003C_003E4__this.textBox1.Text, int.Parse(_003C_003E4__this.textBox2.Text));
						_003C_003E4__this.fanuc.LogNet = _003C_003E4__this.LogNet;
						_003C_003E4__this.button1.Enabled = false;
						awaiter = _003C_003E4__this.fanuc.ConnectServerAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton1_Click_003Ed__5 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cconnect_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cconnect_003E5__1.IsSuccess)
					{
						_003C_003E4__this.panel2.Enabled = true;
						_003C_003E4__this.button1.Enabled = false;
						_003C_003E4__this.button2.Enabled = true;
						_003C_003E4__this.panel2.Enabled = true;
						MessageBox.Show(StringResources.Language.ConnectServerSuccess);
					}
					else
					{
						_003C_003E4__this.button1.Enabled = true;
						MessageBox.Show(_003Cconnect_003E5__1.Message);
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cconnect_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cconnect_003E5__1 = null;
				_003C_003Et__builder.SetResult();
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		private sealed class _003Cbutton27_Click_003Ed__31 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormCncFanuc _003C_003E4__this;

			private OperateResult _003Cwrite_003E5__1;

			private OperateResult _003C_003Es__2;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
						num = (_003C_003E1__state = -1);
						goto IL_00d8;
					}
					if (File.Exists(_003C_003E4__this.textBox7.Text))
					{
						_003C_003E4__this.button27.Enabled = false;
						awaiter = _003C_003E4__this.fanuc.WriteProgramFileAsync(_003C_003E4__this.textBox7.Text, 512, _003C_003E4__this.textBox_path.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton27_Click_003Ed__31 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_00d8;
					}
					MessageBox.Show("文件不存在!");
					goto end_IL_0007;
					IL_00d8:
					_003C_003Es__2 = awaiter.GetResult();
					_003Cwrite_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					_003C_003E4__this.button27.Enabled = true;
					if (_003Cwrite_003E5__1.IsSuccess)
					{
						MessageBox.Show("下载成功！");
					}
					else
					{
						MessageBox.Show("下载失败！" + _003Cwrite_003E5__1.Message);
					}
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cwrite_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cwrite_003E5__1 = null;
				_003C_003Et__builder.SetResult();
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		private sealed class _003Cbutton28_Click_003Ed__28 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormCncFanuc _003C_003E4__this;

			private ushort _003CprogramNum_003E5__1;

			private OperateResult<string> _003Cread_003E5__2;

			private OperateResult<string> _003C_003Es__3;

			private TaskAwaiter<OperateResult<string>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<string>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<string>>);
						num = (_003C_003E1__state = -1);
						goto IL_00cf;
					}
					if (ushort.TryParse(_003C_003E4__this.textBox9.Text, out _003CprogramNum_003E5__1))
					{
						_003C_003E4__this.button28.Enabled = false;
						awaiter = _003C_003E4__this.fanuc.ReadProgramAsync(_003CprogramNum_003E5__1, _003C_003E4__this.textBox_path.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton28_Click_003Ed__28 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_00cf;
					}
					MessageBox.Show("主程序号输入错误！");
					goto end_IL_0007;
					IL_00cf:
					_003C_003Es__3 = awaiter.GetResult();
					_003Cread_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					_003C_003E4__this.button28.Enabled = true;
					if (_003Cread_003E5__2.IsSuccess)
					{
						_003C_003E4__this.textBox_program.Text = "程序内容：" + Environment.NewLine + _003Cread_003E5__2.Content;
					}
					else
					{
						MessageBox.Show("读取失败！" + _003Cread_003E5__2.ToMessageShowString());
					}
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cread_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cread_003E5__2 = null;
				_003C_003Et__builder.SetResult();
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private FanucSeries0i fanuc;

		private ImageList imageList;

		private IContainer components = null;

		private Panel panel1;

		private Button button2;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private Label label1;

		private Panel panel2;

		private TextBox textBox8;

		private Label label12;

		private UserControlHead userControlHead1;

		private TextBox textBox11;

		private Label label5;

		private Button button3;

		private Button button4;

		private Button button5;

		private Button button6;

		private Button button7;

		private Button button8;

		private Button button9;

		private Button button10;

		private Button button11;

		private Button button12;

		private Button button13;

		private Button button14;

		private Button button15;

		private Button button16;

		private Button button17;

		private Button button18;

		private TextBox textBox3;

		private Label label2;

		private Button button21;

		private Button button20;

		private Button button19;

		private Button button22;

		private TextBox textBox_pmc_length;

		private Label label6;

		private Button button23;

		private TextBox textBox_pmc_read;

		private Label label4;

		private Button button24;

		private TextBox textBox6;

		private Label label7;

		private Button button25;

		private Button button26;

		private TextBox textBox7;

		private Label label8;

		private Button button27;

		private TextBox textBox9;

		private Label label9;

		private Button button28;

		private Button button29;

		private Button button30;

		private Panel panel3;

		private TextBox textBox_pmc_Data;

		private Label label10;

		private TextBox textBox_pmc_write;

		private Button button31;

		private Label label11;

		private Label label13;

		private TextBox textBox_path;

		private Label label14;

		private Button button32;

		private Button button33;

		private TreeView treeView1;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem AddNCToolStripMenuItem;

		private ToolStripMenuItem readNCToolStripMenuItem;

		private ToolStripMenuItem deleteToolStripMenuItem;

		private Label label15;

		private Button button34;

		private Button button35;

		private TextBox textBox_op_path;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private Panel panel4;

		private TextBox textBox_program;

		public FormCncFanuc()
		{
			InitializeComponent();
		}

		private void FormClient_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			button2.Enabled = false;
			textBox7.Text = Path.Combine(Application.StartupPath, "O6.txt");
			imageList = new ImageList();
			imageList.Images.Add("Class_489", Resources.Class_489);
			imageList.Images.Add("file", Resources.file);
			treeView1.ImageList = imageList;
			treeView1.AfterSelect += TreeView1_AfterSelect;
			treeView1.MouseDown += TreeView1_MouseDown;
			AddNCToolStripMenuItem.Click += AddNCToolStripMenuItem_Click;
			readNCToolStripMenuItem.Click += ReadNCToolStripMenuItem_Click;
			deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
			Language(Program.Language);
			panel4.Paint += Panel4_Paint;
		}

		private void Panel4_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(0, 0, panel4.Width - 1, panel4.Height - 1));
		}

		private void Language(int language)
		{
			if (language != 1)
			{
				Text = "Fanuc 0i-mf Test";
				label1.Text = "Ip:";
				label3.Text = "Port:";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label12.Text = "Receive:";
				label4.Text = "Addr:";
				label10.Text = "Addr:";
				label6.Text = "Len:";
				label8.Text = "Prog Path";
				label11.Text = "Data:";
				button23.Text = "Read";
				button25.Text = "Set Main Program";
				button31.Text = "Write";
				button27.Text = "Down Program";
				button28.Text = "Read Program";
				button29.Text = "Del Program";
				label15.Text = "Right Mouse Click";
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton1_Click_003Ed__5))]
		[DebuggerStepThrough]
		private void button1_Click(object sender, EventArgs e)
		{
			_003Cbutton1_Click_003Ed__5 stateMachine = new _003Cbutton1_Click_003Ed__5();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			button1.Enabled = true;
			button2.Enabled = false;
			panel2.Enabled = false;
			fanuc.ConnectClose();
		}

		private void button32_Click(object sender, EventArgs e)
		{
			OperateResult<FanucSysInfo> operateResult = fanuc.ReadSysInfo();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button34_Click(object sender, EventArgs e)
		{
			OperateResult<FanucOperatorMessage[]> operateResult = fanuc.ReadOperatorMessage();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OperateResult<SysStatusInfo> operateResult = fanuc.ReadSysStatusInfo();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OperateResult<SysAlarm[]> operateResult = fanuc.ReadSystemAlarm();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			OperateResult<SysAllCoors> operateResult = fanuc.ReadSysAllCoors();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			OperateResult<int[]> operateResult = fanuc.ReadProgramList();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			OperateResult<string, int> operateResult = fanuc.ReadSystemProgramCurrent();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = "程序名：" + operateResult.Content1 + Environment.NewLine + "程序号：" + operateResult.Content2.ToString();
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			OperateResult<double, double> operateResult = fanuc.ReadSpindleSpeedAndFeedRate();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = "主轴转速：" + operateResult.Content1.ToString() + Environment.NewLine + "进给倍率：" + operateResult.Content2.ToString();
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			OperateResult<double[]> operateResult = fanuc.ReadFanucAxisLoad();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button10_Click(object sender, EventArgs e)
		{
			OperateResult<CutterInfo[]> operateResult = fanuc.ReadCutterInfos();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = fanuc.ReadCurrentForegroundDir();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = operateResult.Content;
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button22_Click(object sender, EventArgs e)
		{
			OperateResult<ushort> operateResult = fanuc.ReadLanguage();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = operateResult.Content.ToString() + Environment.NewLine + "此处举几个常用值 0: 英语 1: 日语 2: 德语 3: 法语 4: 中文繁体 6: 韩语 15: 中文简体 16: 俄语 17: 土耳其语";
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button12_Click(object sender, EventArgs e)
		{
			OperateResult<double[]> operateResult = fanuc.ReadDeviceWorkPiecesSize();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = operateResult.Content.ToJsonString();
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button13_Click(object sender, EventArgs e)
		{
			OperateResult<int> operateResult = fanuc.ReadAlarmStatus();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = operateResult.Content.ToString();
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void ReadTimeData(int type)
		{
			OperateResult<long> operateResult = fanuc.ReadTimeData(type);
			if (operateResult.IsSuccess)
			{
				textBox8.Text = string.Format("{0} H {1} M {2} S", operateResult.Content / 3600, operateResult.Content % 3600 / 60, operateResult.Content % 3600 % 60);
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button14_Click(object sender, EventArgs e)
		{
			ReadTimeData(0);
		}

		private void button15_Click(object sender, EventArgs e)
		{
			ReadTimeData(1);
		}

		private void button16_Click(object sender, EventArgs e)
		{
			ReadTimeData(2);
		}

		private void button17_Click(object sender, EventArgs e)
		{
			ReadTimeData(3);
		}

		private void button24_Click(object sender, EventArgs e)
		{
			OperateResult<string> operateResult = fanuc.ReadCurrentProgram();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = "程序内容：" + Environment.NewLine + operateResult.Content;
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button30_Click(object sender, EventArgs e)
		{
			OperateResult<int> operateResult = fanuc.ReadCutterNumber();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = "刀号：" + Environment.NewLine + operateResult.Content.ToString();
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton28_Click_003Ed__28))]
		[DebuggerStepThrough]
		private void button28_Click(object sender, EventArgs e)
		{
			_003Cbutton28_Click_003Ed__28 stateMachine = new _003Cbutton28_Click_003Ed__28();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button29_Click(object sender, EventArgs e)
		{
			ushort result;
			if (!ushort.TryParse(textBox9.Text, out result))
			{
				MessageBox.Show("主程序号输入错误！");
			}
			else
			{
				OperateResult operateResult = fanuc.DeleteProgram(result);
				if (operateResult.IsSuccess)
				{
					textBox8.Text = "删除程序成功！";
				}
				else
				{
					MessageBox.Show("删除失败！" + operateResult.ToMessageShowString());
				}
			}
		}

		private void button25_Click(object sender, EventArgs e)
		{
			ushort result;
			if (!ushort.TryParse(textBox6.Text, out result))
			{
				MessageBox.Show("主程序号输入错误！");
			}
			else
			{
				OperateResult operateResult = fanuc.SetCurrentProgram(result);
				if (operateResult.IsSuccess)
				{
					MessageBox.Show("设置主程序成功！");
				}
				else
				{
					MessageBox.Show("设置主程序失败！" + operateResult.ToMessageShowString());
				}
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton27_Click_003Ed__31))]
		[DebuggerStepThrough]
		private void button27_Click(object sender, EventArgs e)
		{
			_003Cbutton27_Click_003Ed__31 stateMachine = new _003Cbutton27_Click_003Ed__31();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button26_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = fanuc.StartProcessing();
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("启动成功！");
			}
			else
			{
				MessageBox.Show("启动失败！" + operateResult.ToMessageShowString());
			}
		}

		private void button18_Click(object sender, EventArgs e)
		{
			int result;
			if (!int.TryParse(textBox3.Text, out result))
			{
				MessageBox.Show("宏变量地址输入错误！");
			}
			else
			{
				OperateResult<double> operateResult = fanuc.ReadSystemMacroValue(result);
				if (operateResult.IsSuccess)
				{
					textBox8.Text = operateResult.Content.ToString();
				}
				else
				{
					MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
				}
			}
		}

		private void button19_Click(object sender, EventArgs e)
		{
			OperateResult<DateTime> operateResult = fanuc.ReadCurrentDateTime();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = operateResult.Content.ToString("yyyy-MM-dd HH:mm:ss");
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button20_Click(object sender, EventArgs e)
		{
			OperateResult<int> operateResult = fanuc.ReadCurrentProduceCount();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = operateResult.Content.ToString();
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button21_Click(object sender, EventArgs e)
		{
			OperateResult<int> operateResult = fanuc.ReadExpectProduceCount();
			if (operateResult.IsSuccess)
			{
				textBox8.Text = operateResult.Content.ToString();
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button23_Click(object sender, EventArgs e)
		{
			OperateResult<byte[]> operateResult = fanuc.ReadPMCData(textBox_pmc_read.Text, ushort.Parse(textBox_pmc_length.Text));
			if (operateResult.IsSuccess)
			{
				textBox8.Text = operateResult.Content.ToHexString(' ');
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void button31_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = fanuc.WritePMCData(textBox_pmc_write.Text, textBox_pmc_Data.Text.ToHexBytes());
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("Write Success!");
			}
			else
			{
				MessageBox.Show("Write Failed:" + operateResult.ToMessageShowString());
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlTimeout, textBox11.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox11.Text = element.Attribute(DemoDeviceList.XmlTimeout).Value;
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
		}

		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(0, 0, panel3.Width - 1, panel3.Height - 1));
		}

		private string GetPathFromTree(TreeNode treeNode)
		{
			if (treeNode.Parent == null)
			{
				return "//" + treeNode.Text + "/";
			}
			FileDirInfo fileDirInfo = treeNode.Tag as FileDirInfo;
			if (fileDirInfo != null)
			{
				if (!fileDirInfo.IsDirectory)
				{
					return GetPathFromTree(treeNode.Parent) + treeNode.Text;
				}
				return GetPathFromTree(treeNode.Parent) + treeNode.Text + "/";
			}
			return GetPathFromTree(treeNode.Parent) + treeNode.Text + "/";
		}

		private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node != null)
			{
				FileDirInfo fileDirInfo = e.Node.Tag as FileDirInfo;
				if (fileDirInfo != null)
				{
					if (!fileDirInfo.IsDirectory)
					{
						textBox_program.Text = fileDirInfo.ToString();
					}
					else
					{
						textBox_path.Text = GetPathFromTree(e.Node);
						List<string> list = new List<string>();
						foreach (TreeNode node in e.Node.Nodes)
						{
							FileDirInfo fileDirInfo2 = node.Tag as FileDirInfo;
							if (fileDirInfo2 != null && !fileDirInfo2.IsDirectory)
							{
								list.Add(fileDirInfo2.ToString());
							}
						}
						textBox_program.Text = list.ToJsonString();
					}
				}
			}
		}

		private void BrowerFile(TreeNode treeNode)
		{
			OperateResult<FileDirInfo[]> operateResult = fanuc.ReadAllDirectoryAndFile(GetPathFromTree(treeNode));
			if (operateResult.IsSuccess)
			{
				FileDirInfo[] content = operateResult.Content;
				foreach (FileDirInfo fileDirInfo in content)
				{
					TreeNode treeNode2 = new TreeNode(fileDirInfo.Name);
					treeNode2.Tag = fileDirInfo;
					treeNode.Nodes.Add(treeNode2);
					if (fileDirInfo.IsDirectory)
					{
						treeNode2.ImageKey = "Class_489";
						treeNode2.SelectedImageKey = "Class_489";
						BrowerFile(treeNode2);
					}
					else
					{
						treeNode2.ImageKey = "file";
						treeNode2.SelectedImageKey = "file";
					}
				}
			}
			else
			{
				MessageBox.Show("Read Failed:" + operateResult.ToMessageShowString());
			}
		}

		private void TreeView1_MouseDown(object sender, MouseEventArgs e)
		{
			TreeNode nodeAt = treeView1.GetNodeAt(e.Location);
			if (nodeAt != null)
			{
				treeView1.SelectedNode = nodeAt;
				if (nodeAt.Parent != null && e.Button == MouseButtons.Right)
				{
					contextMenuStrip1.Show(treeView1, e.Location);
				}
			}
		}

		[AsyncStateMachine(typeof(_003CDeleteToolStripMenuItem_Click_003Ed__47))]
		[DebuggerStepThrough]
		private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_003CDeleteToolStripMenuItem_Click_003Ed__47 stateMachine = new _003CDeleteToolStripMenuItem_Click_003Ed__47();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CReadNCToolStripMenuItem_Click_003Ed__48))]
		[DebuggerStepThrough]
		private void ReadNCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_003CReadNCToolStripMenuItem_Click_003Ed__48 stateMachine = new _003CReadNCToolStripMenuItem_Click_003Ed__48();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CAddNCToolStripMenuItem_Click_003Ed__49))]
		[DebuggerStepThrough]
		private void AddNCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_003CAddNCToolStripMenuItem_Click_003Ed__49 stateMachine = new _003CAddNCToolStripMenuItem_Click_003Ed__49();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button33_Click(object sender, EventArgs e)
		{
			treeView1.Nodes[0].Nodes.Clear();
			BrowerFile(treeView1.Nodes[0]);
			treeView1.Nodes[0].ExpandAll();
		}

		private void button35_Click(object sender, EventArgs e)
		{
			fanuc.OperatePath = short.Parse(textBox_op_path.Text);
			MessageBox.Show("Success!");
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
			System.Windows.Forms.TreeNode treeNode = new System.Windows.Forms.TreeNode("CNC_MEM");
			panel1 = new System.Windows.Forms.Panel();
			textBox11 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			button3 = new System.Windows.Forms.Button();
			button35 = new System.Windows.Forms.Button();
			label12 = new System.Windows.Forms.Label();
			textBox_op_path = new System.Windows.Forms.TextBox();
			textBox8 = new System.Windows.Forms.TextBox();
			button34 = new System.Windows.Forms.Button();
			button4 = new System.Windows.Forms.Button();
			button32 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			panel3 = new System.Windows.Forms.Panel();
			label13 = new System.Windows.Forms.Label();
			textBox_pmc_Data = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			textBox_pmc_write = new System.Windows.Forms.TextBox();
			button31 = new System.Windows.Forms.Button();
			label11 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			textBox_pmc_read = new System.Windows.Forms.TextBox();
			button23 = new System.Windows.Forms.Button();
			label6 = new System.Windows.Forms.Label();
			textBox_pmc_length = new System.Windows.Forms.TextBox();
			button6 = new System.Windows.Forms.Button();
			button30 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			button26 = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			button24 = new System.Windows.Forms.Button();
			button9 = new System.Windows.Forms.Button();
			button22 = new System.Windows.Forms.Button();
			button10 = new System.Windows.Forms.Button();
			button21 = new System.Windows.Forms.Button();
			button11 = new System.Windows.Forms.Button();
			button20 = new System.Windows.Forms.Button();
			button12 = new System.Windows.Forms.Button();
			button19 = new System.Windows.Forms.Button();
			button13 = new System.Windows.Forms.Button();
			button18 = new System.Windows.Forms.Button();
			button14 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			button15 = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			button16 = new System.Windows.Forms.Button();
			button17 = new System.Windows.Forms.Button();
			tabPage2 = new System.Windows.Forms.TabPage();
			panel4 = new System.Windows.Forms.Panel();
			label14 = new System.Windows.Forms.Label();
			button29 = new System.Windows.Forms.Button();
			textBox9 = new System.Windows.Forms.TextBox();
			textBox_path = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			button28 = new System.Windows.Forms.Button();
			textBox_program = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			button25 = new System.Windows.Forms.Button();
			textBox6 = new System.Windows.Forms.TextBox();
			button27 = new System.Windows.Forms.Button();
			label15 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			treeView1 = new System.Windows.Forms.TreeView();
			textBox7 = new System.Windows.Forms.TextBox();
			button33 = new System.Windows.Forms.Button();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
			AddNCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			readNCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			panel3.SuspendLayout();
			tabPage2.SuspendLayout();
			panel4.SuspendLayout();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(textBox11);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(4, 36);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(996, 46);
			panel1.TabIndex = 7;
			textBox11.Location = new System.Drawing.Point(446, 8);
			textBox11.Name = "textBox11";
			textBox11.Size = new System.Drawing.Size(79, 23);
			textBox11.TabIndex = 15;
			textBox11.Text = "5000";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(380, 11);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(68, 17);
			label5.TabIndex = 14;
			label5.Text = "接收超时：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(664, 5);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 5;
			button2.Text = "断开连接";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(567, 5);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(279, 8);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(79, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "8193";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(225, 11);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 8);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(141, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "192.168.64.129";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 11);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(tabControl1);
			panel2.Location = new System.Drawing.Point(4, 87);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(996, 555);
			panel2.TabIndex = 13;
			tabControl1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Location = new System.Drawing.Point(2, 2);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(993, 552);
			tabControl1.TabIndex = 71;
			tabPage1.Controls.Add(button3);
			tabPage1.Controls.Add(button35);
			tabPage1.Controls.Add(label12);
			tabPage1.Controls.Add(textBox_op_path);
			tabPage1.Controls.Add(textBox8);
			tabPage1.Controls.Add(button34);
			tabPage1.Controls.Add(button4);
			tabPage1.Controls.Add(button32);
			tabPage1.Controls.Add(button5);
			tabPage1.Controls.Add(panel3);
			tabPage1.Controls.Add(button6);
			tabPage1.Controls.Add(button30);
			tabPage1.Controls.Add(button7);
			tabPage1.Controls.Add(button26);
			tabPage1.Controls.Add(button8);
			tabPage1.Controls.Add(button24);
			tabPage1.Controls.Add(button9);
			tabPage1.Controls.Add(button22);
			tabPage1.Controls.Add(button10);
			tabPage1.Controls.Add(button21);
			tabPage1.Controls.Add(button11);
			tabPage1.Controls.Add(button20);
			tabPage1.Controls.Add(button12);
			tabPage1.Controls.Add(button19);
			tabPage1.Controls.Add(button13);
			tabPage1.Controls.Add(button18);
			tabPage1.Controls.Add(button14);
			tabPage1.Controls.Add(textBox3);
			tabPage1.Controls.Add(button15);
			tabPage1.Controls.Add(label2);
			tabPage1.Controls.Add(button16);
			tabPage1.Controls.Add(button17);
			tabPage1.Location = new System.Drawing.Point(4, 26);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(985, 522);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "基本操作";
			tabPage1.UseVisualStyleBackColor = true;
			button3.Location = new System.Drawing.Point(4, 4);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(96, 29);
			button3.TabIndex = 20;
			button3.Text = "系统状态";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button35.Location = new System.Drawing.Point(877, 39);
			button35.Name = "button35";
			button35.Size = new System.Drawing.Size(96, 29);
			button35.TabIndex = 70;
			button35.Text = "设置路径";
			button35.UseVisualStyleBackColor = true;
			button35.Click += new System.EventHandler(button35_Click);
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(9, 187);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(61, 17);
			label12.TabIndex = 19;
			label12.Text = "receive：";
			textBox_op_path.Location = new System.Drawing.Point(806, 42);
			textBox_op_path.Name = "textBox_op_path";
			textBox_op_path.Size = new System.Drawing.Size(65, 23);
			textBox_op_path.TabIndex = 69;
			textBox_op_path.Text = "1";
			textBox8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox8.Location = new System.Drawing.Point(6, 207);
			textBox8.Multiline = true;
			textBox8.Name = "textBox8";
			textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox8.Size = new System.Drawing.Size(973, 312);
			textBox8.TabIndex = 18;
			button34.Location = new System.Drawing.Point(504, 74);
			button34.Name = "button34";
			button34.Size = new System.Drawing.Size(96, 29);
			button34.TabIndex = 68;
			button34.Text = "操作信息";
			button34.UseVisualStyleBackColor = true;
			button34.Click += new System.EventHandler(button34_Click);
			button4.Location = new System.Drawing.Point(104, 4);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(96, 29);
			button4.TabIndex = 21;
			button4.Text = "报警信息";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			button32.Location = new System.Drawing.Point(606, 74);
			button32.Name = "button32";
			button32.Size = new System.Drawing.Size(96, 29);
			button32.TabIndex = 64;
			button32.Text = "系统信息";
			button32.UseVisualStyleBackColor = true;
			button32.Click += new System.EventHandler(button32_Click);
			button5.Location = new System.Drawing.Point(204, 4);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(96, 29);
			button5.TabIndex = 22;
			button5.Text = "坐标数据";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			panel3.BackColor = System.Drawing.Color.FromArgb(232, 232, 255);
			panel3.Controls.Add(label13);
			panel3.Controls.Add(textBox_pmc_Data);
			panel3.Controls.Add(label10);
			panel3.Controls.Add(textBox_pmc_write);
			panel3.Controls.Add(button31);
			panel3.Controls.Add(label11);
			panel3.Controls.Add(label4);
			panel3.Controls.Add(textBox_pmc_read);
			panel3.Controls.Add(button23);
			panel3.Controls.Add(label6);
			panel3.Controls.Add(textBox_pmc_length);
			panel3.Location = new System.Drawing.Point(6, 109);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(592, 66);
			panel3.TabIndex = 61;
			panel3.Paint += new System.Windows.Forms.PaintEventHandler(panel3_Paint);
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(344, 9);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(181, 17);
			label13.TabIndex = 68;
			label13.Text = "Support: G,F,Y,X,A,R,T,K,C,D,E ";
			textBox_pmc_Data.Location = new System.Drawing.Point(169, 36);
			textBox_pmc_Data.Name = "textBox_pmc_Data";
			textBox_pmc_Data.Size = new System.Drawing.Size(309, 23);
			textBox_pmc_Data.TabIndex = 67;
			textBox_pmc_Data.Text = "01 02";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(3, 39);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(44, 17);
			label10.TabIndex = 61;
			label10.Text = "起始：";
			textBox_pmc_write.Location = new System.Drawing.Point(48, 36);
			textBox_pmc_write.Name = "textBox_pmc_write";
			textBox_pmc_write.Size = new System.Drawing.Size(65, 23);
			textBox_pmc_write.TabIndex = 62;
			textBox_pmc_write.Text = "R1200";
			button31.Location = new System.Drawing.Point(492, 33);
			button31.Name = "button31";
			button31.Size = new System.Drawing.Size(96, 29);
			button31.TabIndex = 63;
			button31.Text = "写数据";
			button31.UseVisualStyleBackColor = true;
			button31.Click += new System.EventHandler(button31_Click);
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(119, 39);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 64;
			label11.Text = "数据：";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(3, 10);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(44, 17);
			label4.TabIndex = 42;
			label4.Text = "起始：";
			textBox_pmc_read.Location = new System.Drawing.Point(48, 7);
			textBox_pmc_read.Name = "textBox_pmc_read";
			textBox_pmc_read.Size = new System.Drawing.Size(65, 23);
			textBox_pmc_read.TabIndex = 43;
			textBox_pmc_read.Text = "R1200";
			button23.Location = new System.Drawing.Point(242, 4);
			button23.Name = "button23";
			button23.Size = new System.Drawing.Size(96, 29);
			button23.TabIndex = 44;
			button23.Text = "读数据";
			button23.UseVisualStyleBackColor = true;
			button23.Click += new System.EventHandler(button23_Click);
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(119, 10);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(44, 17);
			label6.TabIndex = 45;
			label6.Text = "长度：";
			textBox_pmc_length.Location = new System.Drawing.Point(168, 7);
			textBox_pmc_length.Name = "textBox_pmc_length";
			textBox_pmc_length.Size = new System.Drawing.Size(62, 23);
			textBox_pmc_length.TabIndex = 46;
			textBox_pmc_length.Text = "10";
			button6.Location = new System.Drawing.Point(304, 4);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(96, 29);
			button6.TabIndex = 23;
			button6.Text = "程序列表";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			button30.Location = new System.Drawing.Point(404, 74);
			button30.Name = "button30";
			button30.Size = new System.Drawing.Size(96, 29);
			button30.TabIndex = 59;
			button30.Text = "当前刀具号";
			button30.UseVisualStyleBackColor = true;
			button30.Click += new System.EventHandler(button30_Click);
			button7.Location = new System.Drawing.Point(404, 4);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(96, 29);
			button7.TabIndex = 24;
			button7.Text = "当前程序名";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			button26.Location = new System.Drawing.Point(704, 39);
			button26.Name = "button26";
			button26.Size = new System.Drawing.Size(96, 29);
			button26.TabIndex = 51;
			button26.Text = "启动加工";
			button26.UseVisualStyleBackColor = true;
			button26.Click += new System.EventHandler(button26_Click);
			button8.Location = new System.Drawing.Point(504, 4);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(96, 29);
			button8.TabIndex = 25;
			button8.Text = "主轴转速进给";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			button24.Location = new System.Drawing.Point(604, 39);
			button24.Name = "button24";
			button24.Size = new System.Drawing.Size(96, 29);
			button24.TabIndex = 47;
			button24.Text = "读当前程序";
			button24.UseVisualStyleBackColor = true;
			button24.Click += new System.EventHandler(button24_Click);
			button9.Location = new System.Drawing.Point(604, 4);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(96, 29);
			button9.TabIndex = 26;
			button9.Text = "伺服负载";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			button22.Location = new System.Drawing.Point(504, 39);
			button22.Name = "button22";
			button22.Size = new System.Drawing.Size(96, 29);
			button22.TabIndex = 41;
			button22.Text = "系统语言";
			button22.UseVisualStyleBackColor = true;
			button22.Click += new System.EventHandler(button22_Click);
			button10.Location = new System.Drawing.Point(704, 4);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(96, 29);
			button10.TabIndex = 27;
			button10.Text = "刀具补偿";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(button10_Click);
			button21.Location = new System.Drawing.Point(404, 39);
			button21.Name = "button21";
			button21.Size = new System.Drawing.Size(96, 29);
			button21.TabIndex = 40;
			button21.Text = "总加工数量";
			button21.UseVisualStyleBackColor = true;
			button21.Click += new System.EventHandler(button21_Click);
			button11.Location = new System.Drawing.Point(804, 4);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(96, 29);
			button11.TabIndex = 28;
			button11.Text = "程序路径";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			button20.Location = new System.Drawing.Point(304, 39);
			button20.Name = "button20";
			button20.Size = new System.Drawing.Size(96, 29);
			button20.TabIndex = 39;
			button20.Text = "已加工数量";
			button20.UseVisualStyleBackColor = true;
			button20.Click += new System.EventHandler(button20_Click);
			button12.Location = new System.Drawing.Point(4, 39);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(96, 29);
			button12.TabIndex = 29;
			button12.Text = "工件尺寸";
			button12.UseVisualStyleBackColor = true;
			button12.Click += new System.EventHandler(button12_Click);
			button19.Location = new System.Drawing.Point(204, 39);
			button19.Name = "button19";
			button19.Size = new System.Drawing.Size(96, 29);
			button19.TabIndex = 38;
			button19.Text = "机床时间";
			button19.UseVisualStyleBackColor = true;
			button19.Click += new System.EventHandler(button19_Click);
			button13.Location = new System.Drawing.Point(104, 39);
			button13.Name = "button13";
			button13.Size = new System.Drawing.Size(96, 29);
			button13.TabIndex = 30;
			button13.Text = "报警代号";
			button13.UseVisualStyleBackColor = true;
			button13.Click += new System.EventHandler(button13_Click);
			button18.Location = new System.Drawing.Point(880, 170);
			button18.Name = "button18";
			button18.Size = new System.Drawing.Size(96, 29);
			button18.TabIndex = 37;
			button18.Text = "读宏变量";
			button18.UseVisualStyleBackColor = true;
			button18.Click += new System.EventHandler(button18_Click);
			button14.Location = new System.Drawing.Point(4, 74);
			button14.Name = "button14";
			button14.Size = new System.Drawing.Size(96, 29);
			button14.TabIndex = 31;
			button14.Text = "开机时间";
			button14.UseVisualStyleBackColor = true;
			button14.Click += new System.EventHandler(button14_Click);
			textBox3.Location = new System.Drawing.Point(755, 173);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(105, 23);
			textBox3.TabIndex = 36;
			textBox3.Text = "4320";
			button15.Location = new System.Drawing.Point(104, 74);
			button15.Name = "button15";
			button15.Size = new System.Drawing.Size(96, 29);
			button15.TabIndex = 32;
			button15.Text = "运行时间";
			button15.UseVisualStyleBackColor = true;
			button15.Click += new System.EventHandler(button15_Click);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(701, 177);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(56, 17);
			label2.TabIndex = 35;
			label2.Text = "宏变量：";
			button16.Location = new System.Drawing.Point(204, 74);
			button16.Name = "button16";
			button16.Size = new System.Drawing.Size(96, 29);
			button16.TabIndex = 33;
			button16.Text = "切削时间";
			button16.UseVisualStyleBackColor = true;
			button16.Click += new System.EventHandler(button16_Click);
			button17.Location = new System.Drawing.Point(304, 74);
			button17.Name = "button17";
			button17.Size = new System.Drawing.Size(96, 29);
			button17.TabIndex = 34;
			button17.Text = "循环时间";
			button17.UseVisualStyleBackColor = true;
			button17.Click += new System.EventHandler(button17_Click);
			tabPage2.Controls.Add(panel4);
			tabPage2.Controls.Add(textBox_program);
			tabPage2.Controls.Add(label7);
			tabPage2.Controls.Add(button25);
			tabPage2.Controls.Add(textBox6);
			tabPage2.Controls.Add(button27);
			tabPage2.Controls.Add(label15);
			tabPage2.Controls.Add(label8);
			tabPage2.Controls.Add(treeView1);
			tabPage2.Controls.Add(textBox7);
			tabPage2.Controls.Add(button33);
			tabPage2.Location = new System.Drawing.Point(4, 26);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3);
			tabPage2.Size = new System.Drawing.Size(985, 522);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "程序上传下载";
			tabPage2.UseVisualStyleBackColor = true;
			panel4.BackColor = System.Drawing.Color.AliceBlue;
			panel4.Controls.Add(label14);
			panel4.Controls.Add(button29);
			panel4.Controls.Add(textBox9);
			panel4.Controls.Add(textBox_path);
			panel4.Controls.Add(label9);
			panel4.Controls.Add(button28);
			panel4.Location = new System.Drawing.Point(3, 4);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(388, 62);
			panel4.TabIndex = 69;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(5, 7);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(51, 17);
			label14.TabIndex = 62;
			label14.Text = "PATH：";
			button29.Location = new System.Drawing.Point(177, 28);
			button29.Name = "button29";
			button29.Size = new System.Drawing.Size(96, 29);
			button29.TabIndex = 58;
			button29.Text = "删除程序";
			button29.UseVisualStyleBackColor = true;
			button29.Click += new System.EventHandler(button29_Click);
			textBox9.Location = new System.Drawing.Point(59, 31);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(105, 23);
			textBox9.TabIndex = 57;
			textBox9.Text = "33";
			textBox_path.Location = new System.Drawing.Point(59, 4);
			textBox_path.Name = "textBox_path";
			textBox_path.Size = new System.Drawing.Size(316, 23);
			textBox_path.TabIndex = 63;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(5, 34);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(56, 17);
			label9.TabIndex = 56;
			label9.Text = "程序号：";
			button28.Location = new System.Drawing.Point(279, 28);
			button28.Name = "button28";
			button28.Size = new System.Drawing.Size(96, 29);
			button28.TabIndex = 55;
			button28.Text = "读取程序";
			button28.UseVisualStyleBackColor = true;
			button28.Click += new System.EventHandler(button28_Click);
			textBox_program.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_program.Location = new System.Drawing.Point(215, 99);
			textBox_program.Multiline = true;
			textBox_program.Name = "textBox_program";
			textBox_program.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_program.Size = new System.Drawing.Size(764, 417);
			textBox_program.TabIndex = 68;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(397, 67);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(56, 17);
			label7.TabIndex = 49;
			label7.Text = "程序号：";
			button25.Location = new System.Drawing.Point(563, 61);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(122, 29);
			button25.TabIndex = 48;
			button25.Text = "设为主程序";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			textBox6.Location = new System.Drawing.Point(451, 64);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(105, 23);
			textBox6.TabIndex = 50;
			textBox6.Text = "33";
			button27.Location = new System.Drawing.Point(877, 28);
			button27.Name = "button27";
			button27.Size = new System.Drawing.Size(96, 29);
			button27.TabIndex = 52;
			button27.Text = "下传程序";
			button27.UseVisualStyleBackColor = true;
			button27.Click += new System.EventHandler(button27_Click);
			label15.AutoSize = true;
			label15.ForeColor = System.Drawing.Color.Green;
			label15.Location = new System.Drawing.Point(94, 73);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(80, 17);
			label15.TabIndex = 67;
			label15.Text = "右键菜单操作";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(397, 11);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(68, 17);
			label8.TabIndex = 53;
			label8.Text = "程序文件：";
			treeView1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			treeView1.Location = new System.Drawing.Point(5, 99);
			treeView1.Name = "treeView1";
			treeNode.Name = "节点0";
			treeNode.Text = "CNC_MEM";
			treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[1]
			{
				treeNode
			});
			treeView1.Size = new System.Drawing.Size(204, 417);
			treeView1.TabIndex = 66;
			textBox7.Location = new System.Drawing.Point(400, 31);
			textBox7.Name = "textBox7";
			textBox7.Size = new System.Drawing.Size(471, 23);
			textBox7.TabIndex = 54;
			textBox7.Text = "06.txt";
			button33.Location = new System.Drawing.Point(4, 70);
			button33.Name = "button33";
			button33.Size = new System.Drawing.Size(83, 23);
			button33.TabIndex = 65;
			button33.Text = "路径信息";
			button33.UseVisualStyleBackColor = true;
			button33.Click += new System.EventHandler(button33_Click);
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Fanuc Series 0iD/0iF/30i/31i/32i/35i 等新系统";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.SupportListVisiable = true;
			userControlHead1.TabIndex = 14;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3]
			{
				AddNCToolStripMenuItem,
				readNCToolStripMenuItem,
				deleteToolStripMenuItem
			});
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new System.Drawing.Size(143, 70);
			AddNCToolStripMenuItem.Name = "AddNCToolStripMenuItem";
			AddNCToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			AddNCToolStripMenuItem.Text = "添加NC程序";
			readNCToolStripMenuItem.Name = "readNCToolStripMenuItem";
			readNCToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			readNCToolStripMenuItem.Text = "读取NC程序";
			deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			deleteToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			deleteToolStripMenuItem.Text = "删除文件";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormCncFanuc";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Fanuc0i客户端";
			base.Load += new System.EventHandler(FormClient_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
