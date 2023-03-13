using HslCommunication;
using HslCommunication.Core;
using HslCommunication.Enthernet;
using HslCommunication.LogNet;
using HslCommunicationDemo.DemoControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormFileClient : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003CServerPressureTest2_003Ed__32 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object obj;

			public FormFileClient _003C_003E4__this;

			private string _003Cpath_003E5__1;

			private string _003CpathNew_003E5__2;

			private int _003Cj_003E5__3;

			private string _003CfileName_003E5__4;

			private string _003CfullName_003E5__5;

			private StringBuilder _003Csb_003E5__6;

			private int _003Ci_003E5__7;

			private OperateResult _003C_003Es__8;

			private OperateResult _003C_003Es__9;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter2;
					TaskAwaiter<OperateResult> awaiter;
					switch (num)
					{
					default:
						_003Cpath_003E5__1 = (obj as string);
						if (_003Cpath_003E5__1 == null)
						{
							break;
						}
						_003CpathNew_003E5__2 = Path.Combine(Application.StartupPath, _003Cpath_003E5__1);
						Directory.CreateDirectory(_003CpathNew_003E5__2);
						_003Cj_003E5__3 = 0;
						goto IL_02ce;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
						num = (_003C_003E1__state = -1);
						goto IL_0194;
					case 1:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
							num = (_003C_003E1__state = -1);
							goto IL_025f;
						}
						IL_0194:
						_003C_003Es__8 = awaiter2.GetResult();
						if (_003C_003Es__8.IsSuccess)
						{
							_003C_003Es__8 = null;
							_003C_003E4__this.upSuccess++;
						}
						File.Delete(_003CfullName_003E5__5);
						awaiter = _003C_003E4__this.integrationFileClient.DownloadFileAsync(_003CfileName_003E5__4, "Files", "Group", "id", null, _003CfullName_003E5__5).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003CServerPressureTest2_003Ed__32 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_025f;
						IL_02ce:
						if (_003Cj_003E5__3 >= 100)
						{
							Directory.Delete(_003CpathNew_003E5__2);
							if (Interlocked.Decrement(ref _003C_003E4__this.threadlength) == 0)
							{
								_003C_003E4__this.Invoke((Action)delegate
								{
									_003C_003E4__this.button8.Enabled = true;
									MessageBox.Show("成功上传次数：" + _003C_003E4__this.upSuccess.ToString() + Environment.NewLine + "成功下载次数：" + _003C_003E4__this.downSuccess.ToString() + Environment.NewLine + "成功删除次数：" + _003C_003E4__this.deleteSuccess.ToString());
								});
							}
							_003CpathNew_003E5__2 = null;
							break;
						}
						_003CfileName_003E5__4 = "A" + _003C_003E4__this.random.Next(500).ToString() + ".txt";
						_003CfullName_003E5__5 = Path.Combine(_003CpathNew_003E5__2, _003CfileName_003E5__4);
						_003Csb_003E5__6 = new StringBuilder();
						_003Ci_003E5__7 = 0;
						while (_003Ci_003E5__7 < 1024)
						{
							_003Csb_003E5__6.Append('1');
							_003Ci_003E5__7++;
						}
						File.WriteAllText(_003CfullName_003E5__5, _003Csb_003E5__6.ToString(), Encoding.UTF8);
						awaiter2 = _003C_003E4__this.integrationFileClient.UploadFileAsync(_003CfullName_003E5__5, "Files", "Group", "id", null).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CServerPressureTest2_003Ed__32 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
							return;
						}
						goto IL_0194;
						IL_025f:
						_003C_003Es__9 = awaiter.GetResult();
						if (_003C_003Es__9.IsSuccess)
						{
							_003C_003Es__9 = null;
							_003C_003E4__this.downSuccess++;
						}
						File.Delete(_003CfullName_003E5__5);
						_003CfileName_003E5__4 = null;
						_003CfullName_003E5__5 = null;
						_003Csb_003E5__6 = null;
						_003Cj_003E5__3++;
						goto IL_02ce;
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cpath_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cpath_003E5__1 = null;
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
		private sealed class _003Cbutton12_Click_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFileClient _003C_003E4__this;

			private OperateResult<GroupFileInfo> _003Cresult_003E5__1;

			private OperateResult<GroupFileInfo> _003C_003Es__2;

			private TaskAwaiter<OperateResult<GroupFileInfo>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<GroupFileInfo>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.integrationFileClient.GetGroupFileInfoAsync(_003C_003E4__this.textBox_delete_factory.Text, _003C_003E4__this.textBox_delete_group.Text, _003C_003E4__this.textBox_delete_id.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton12_Click_003Ed__16 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<GroupFileInfo>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cresult_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cresult_003E5__1.IsSuccess)
					{
						_003C_003E4__this.label22.Text = _003Cresult_003E5__1.Content.ToString();
					}
					else
					{
						MessageBox.Show("获取文件大小失败，原因：" + _003Cresult_003E5__1.ToMessageShowString());
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cresult_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cresult_003E5__1 = null;
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
		private sealed class _003Cbutton13_Click_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFileClient _003C_003E4__this;

			private OperateResult<GroupFileInfo[]> _003Cresult_003E5__1;

			private OperateResult<GroupFileInfo[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<GroupFileInfo[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<GroupFileInfo[]>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.integrationFileClient.GetSubGroupFileInfosAsync(_003C_003E4__this.textBox_delete_factory.Text, _003C_003E4__this.textBox_delete_group.Text, _003C_003E4__this.textBox_delete_id.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton13_Click_003Ed__17 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<GroupFileInfo[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cresult_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cresult_003E5__1.IsSuccess)
					{
						MessageBox.Show(_003Cresult_003E5__1.Content.ToJsonString());
					}
					else
					{
						MessageBox.Show("获取文件大小失败，原因：" + _003Cresult_003E5__1.ToMessageShowString());
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cresult_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cresult_003E5__1 = null;
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
		private sealed class _003Cbutton3_Click_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFileClient _003C_003E4__this;

			private string _003CfileName_003E5__1;

			private FileInfo _003CfileInfo_003E5__2;

			private DateTime _003CuploadStartTime_003E5__3;

			private OperateResult _003Cresult_003E5__4;

			private OperateResult _003C_003Es__5;

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
						goto IL_0178;
					}
					if (!string.IsNullOrEmpty(_003C_003E4__this.textBox3.Text))
					{
						if (File.Exists(_003C_003E4__this.textBox3.Text))
						{
							_003C_003E4__this.button3.Enabled = false;
							_003CfileName_003E5__1 = _003C_003E4__this.textBox3.Text;
							_003CfileInfo_003E5__2 = new FileInfo(_003CfileName_003E5__1);
							_003CuploadStartTime_003E5__3 = DateTime.Now;
							awaiter = _003C_003E4__this.integrationFileClient.UploadFileAsync(_003CfileName_003E5__1, _003CfileInfo_003E5__2.Name, _003C_003E4__this.textBox_upload_factory.Text, _003C_003E4__this.textBox_upload_group.Text, _003C_003E4__this.textBox_upload_id.Text, _003C_003E4__this.textBox_upload_tag.Text, _003C_003E4__this.textBox_upload_name.Text, _003C_003E4__this.UpdateReportProgress).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003Cbutton3_Click_003Ed__6 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
								return;
							}
							goto IL_0178;
						}
						MessageBox.Show("选择的文件不存在，退出！");
					}
					else
					{
						MessageBox.Show("Please Select a File");
					}
					goto end_IL_0007;
					IL_0178:
					_003C_003Es__5 = awaiter.GetResult();
					_003Cresult_003E5__4 = _003C_003Es__5;
					_003C_003Es__5 = null;
					_003C_003E4__this.button3.Enabled = true;
					if (_003Cresult_003E5__4.IsSuccess)
					{
						MessageBox.Show("文件上传成功！耗时：" + (DateTime.Now - _003CuploadStartTime_003E5__3).TotalSeconds.ToString("F1") + " 秒");
					}
					else
					{
						MessageBox.Show("文件上传失败：" + _003Cresult_003E5__4.ToMessageShowString());
					}
					_003CfileName_003E5__1 = null;
					_003CfileInfo_003E5__2 = null;
					_003Cresult_003E5__4 = null;
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
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
		private sealed class _003Cbutton4_Click_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFileClient _003C_003E4__this;

			private string _003CfileName_003E5__1;

			private DateTime _003CdownloadStartTime_003E5__2;

			private OperateResult _003Cresult_003E5__3;

			private OperateResult _003C_003Es__4;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					if (num != 0)
					{
						_003C_003E4__this.progressBar2.Value = 0;
						_003C_003E4__this.button4.Enabled = false;
						_003CfileName_003E5__1 = _003C_003E4__this.textBox_download_fileName.Text;
						_003CdownloadStartTime_003E5__2 = DateTime.Now;
						awaiter = _003C_003E4__this.integrationFileClient.DownloadFileAsync(_003CfileName_003E5__1, _003C_003E4__this.textBox_download_factory.Text, _003C_003E4__this.textBox_download_group.Text, _003C_003E4__this.textBox_download_id.Text, _003C_003E4__this.DownloadReportProgress, Application.StartupPath + "\\Files\\" + _003CfileName_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton4_Click_003Ed__9 stateMachine = this;
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
					_003C_003Es__4 = awaiter.GetResult();
					_003Cresult_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					_003C_003E4__this.button4.Enabled = true;
					if (_003Cresult_003E5__3.IsSuccess)
					{
						MessageBox.Show("文件下载成功！耗时：" + (DateTime.Now - _003CdownloadStartTime_003E5__2).TotalSeconds.ToString("F1") + " 秒");
					}
					else
					{
						MessageBox.Show("文件下载失败：" + _003Cresult_003E5__3.ToMessageShowString());
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003CfileName_003E5__1 = null;
					_003Cresult_003E5__3 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003CfileName_003E5__1 = null;
				_003Cresult_003E5__3 = null;
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
		private sealed class _003Cbutton5_Click_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFileClient _003C_003E4__this;

			private OperateResult _003Cresult_003E5__1;

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
						awaiter = _003C_003E4__this.integrationFileClient.DeleteFileAsync(_003C_003E4__this.textBox_delete_fileName.Text, _003C_003E4__this.textBox_delete_factory.Text, _003C_003E4__this.textBox_delete_group.Text, _003C_003E4__this.textBox_delete_id.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton5_Click_003Ed__13 stateMachine = this;
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
					_003Cresult_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cresult_003E5__1.IsSuccess)
					{
						MessageBox.Show("文件删除成功！");
					}
					else
					{
						MessageBox.Show("文件删除失败，原因：" + _003Cresult_003E5__1.ToMessageShowString());
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cresult_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cresult_003E5__1 = null;
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
		private sealed class _003Cbutton6_Click_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFileClient _003C_003E4__this;

			private TreeNode _003C_003Es__1;

			private OperateResult<string[]> _003C_003Es__2;

			private TaskAwaiter<OperateResult<string[]>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<string[]>> awaiter;
					if (num != 0)
					{
						_003C_003E4__this.treeView1.Nodes[0].Nodes.Clear();
						_003C_003E4__this.button6.Enabled = false;
						_003C_003Es__1 = _003C_003E4__this.treeView1.Nodes[0];
						awaiter = _003C_003E4__this.integrationFileClient.DownloadPathFoldersAsync("", "", "").GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton6_Click_003Ed__20 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<string[]>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003C_003E4__this.FillNodeByFactoryGroupId(_003C_003Es__1, _003C_003Es__2, 1);
					_003C_003Es__1 = null;
					_003C_003Es__2 = null;
					_003C_003E4__this.button6.Enabled = true;
					_003C_003E4__this.treeView1.Nodes[0].ExpandAll();
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
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
		private sealed class _003Cbutton9_Click_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormFileClient _003C_003E4__this;

			private OperateResult _003Cresult_003E5__1;

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
						awaiter = _003C_003E4__this.integrationFileClient.DeleteFolderFilesAsync(_003C_003E4__this.textBox_delete_factory.Text, _003C_003E4__this.textBox_delete_group.Text, _003C_003E4__this.textBox_delete_id.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton9_Click_003Ed__14 stateMachine = this;
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
					_003Cresult_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cresult_003E5__1.IsSuccess)
					{
						MessageBox.Show("文件信息删除成功！");
					}
					else
					{
						MessageBox.Show("文件删除失败，原因：" + _003Cresult_003E5__1.ToMessageShowString());
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cresult_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cresult_003E5__1 = null;
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
		private sealed class _003CtreeView1_BeforeExpand_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public TreeViewCancelEventArgs e;

			public FormFileClient _003C_003E4__this;

			private TreeNode _003Cnode_003E5__1;

			private int _003Cgrade_003E5__2;

			private TreeNode _003C_003Es__3;

			private OperateResult<string[]> _003C_003Es__4;

			private TreeNode _003C_003Es__5;

			private OperateResult<string[]> _003C_003Es__6;

			private TreeNode _003C_003Es__7;

			private OperateResult<GroupFileItem[]> _003C_003Es__8;

			private TaskAwaiter<OperateResult<string[]>> _003C_003Eu__1;

			private TaskAwaiter<OperateResult<GroupFileItem[]>> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<string[]>> awaiter3;
					TaskAwaiter<OperateResult<string[]>> awaiter2;
					TaskAwaiter<OperateResult<GroupFileItem[]>> awaiter;
					switch (num)
					{
					default:
					{
						_003Cnode_003E5__1 = e.Node;
						if (_003Cnode_003E5__1.Tag == null)
						{
							break;
						}
						object tag = _003Cnode_003E5__1.Tag;
						int num2;
						if (tag is int)
						{
							_003Cgrade_003E5__2 = (int)tag;
							num2 = 1;
						}
						else
						{
							num2 = 0;
						}
						if (num2 == 0)
						{
							break;
						}
						if (_003Cgrade_003E5__2 == 1)
						{
							_003C_003Es__3 = _003Cnode_003E5__1;
							awaiter3 = _003C_003E4__this.integrationFileClient.DownloadPathFoldersAsync(_003Cnode_003E5__1.Text, "", "").GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003CtreeView1_BeforeExpand_003Ed__21 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter3, ref stateMachine);
								return;
							}
							goto IL_0118;
						}
						if (_003Cgrade_003E5__2 == 2)
						{
							_003C_003Es__5 = _003Cnode_003E5__1;
							awaiter2 = _003C_003E4__this.integrationFileClient.DownloadPathFoldersAsync(_003Cnode_003E5__1.Parent.Text, _003Cnode_003E5__1.Text, "").GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter2;
								_003CtreeView1_BeforeExpand_003Ed__21 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
								return;
							}
							goto IL_01f7;
						}
						if (_003Cgrade_003E5__2 != 3)
						{
							break;
						}
						_003C_003Es__7 = _003Cnode_003E5__1;
						awaiter = _003C_003E4__this.integrationFileClient.DownloadPathFileNamesAsync(_003Cnode_003E5__1.Parent.Parent.Text, _003Cnode_003E5__1.Parent.Text, _003Cnode_003E5__1.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter;
							_003CtreeView1_BeforeExpand_003Ed__21 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_02e6;
					}
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<string[]>>);
						num = (_003C_003E1__state = -1);
						goto IL_0118;
					case 1:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<string[]>>);
						num = (_003C_003E1__state = -1);
						goto IL_01f7;
					case 2:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<OperateResult<GroupFileItem[]>>);
							num = (_003C_003E1__state = -1);
							goto IL_02e6;
						}
						IL_0118:
						_003C_003Es__4 = awaiter3.GetResult();
						_003C_003E4__this.FillNodeByFactoryGroupId(_003C_003Es__3, _003C_003Es__4, 2);
						_003C_003Es__3 = null;
						_003C_003Es__4 = null;
						break;
						IL_01f7:
						_003C_003Es__6 = awaiter2.GetResult();
						_003C_003E4__this.FillNodeByFactoryGroupId(_003C_003Es__5, _003C_003Es__6, 3);
						_003C_003Es__5 = null;
						_003C_003Es__6 = null;
						break;
						IL_02e6:
						_003C_003Es__8 = awaiter.GetResult();
						_003C_003E4__this.FillNodeFilesByFactoryGroupId(_003C_003Es__7, _003C_003Es__8);
						_003C_003Es__7 = null;
						_003C_003Es__8 = null;
						break;
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cnode_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cnode_003E5__1 = null;
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

		private IntegrationFileClient integrationFileClient;

		private int threadlength = 20;

		private Random random = new Random();

		private int upSuccess = 0;

		private int downSuccess = 0;

		private int deleteSuccess = 0;

		private IContainer components = null;

		private Panel panel1;

		private TextBox textBox15;

		private Label label21;

		private Button button1;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private Label label1;

		private Panel panel2;

		private GroupBox groupBox1;

		private ProgressBar progressBar1;

		private Label label7;

		private Button button3;

		private Button button2;

		private TextBox textBox3;

		private Label label6;

		private GroupBox groupBox4;

		private TextBox textBox_file_date;

		private Label label32;

		private TextBox textBox_file_tag;

		private Label label26;

		private TextBox textBox_file_upload;

		private Label label25;

		private TextBox textBox_file_dowloadTimes;

		private Label label24;

		private TextBox textBox_file_fileSize;

		private Label label23;

		private TextBox textBox_file_fileName;

		private Label label11;

		private TreeView treeView1;

		private GroupBox groupBox3;

		private TextBox textBox_delete_fileName;

		private Label label8;

		private TextBox textBox_delete_id;

		private Label label_delete_id;

		private TextBox textBox_delete_group;

		private Label label_delete_group;

		private Button button5;

		private TextBox textBox_delete_factory;

		private Label label17;

		private GroupBox groupBox2;

		private TextBox textBox_download_fileName;

		private Label label16;

		private TextBox textBox_download_id;

		private Label label15;

		private TextBox textBox_download_group;

		private Label label14;

		private ProgressBar progressBar2;

		private Label label12;

		private Button button4;

		private TextBox textBox_download_factory;

		private Label label13;

		private TextBox textBox_upload_tag;

		private Label label31;

		private TextBox textBox_upload_name;

		private Label label30;

		private TextBox textBox_upload_id;

		private Label label27;

		private TextBox textBox_upload_group;

		private Label label28;

		private TextBox textBox_upload_factory;

		private Label label29;

		private Button button6;

		private Label label9;

		private Label label10;

		private Label label18;

		private UserControlHead userControlHead1;

		private Button button7;

		private Button button8;

		private Button button9;

		private Button button10;

		private TextBox textBox_show_id;

		private Label label2;

		private TextBox textBox_show_group;

		private Label label4;

		private TextBox textBox_show_factory;

		private Label label5;

		private Label label20;

		private TextBox textBox4;

		private Label label19;

		private Button button11;

		private Button button12;

		private Label label22;

		private Button button13;

		public FormFileClient()
		{
			InitializeComponent();
		}

		private void FormFileClient_Load(object sender, EventArgs e)
		{
			textBox15.Text = Guid.Empty.ToString();
		}

		private void IntegrationFileClientInitialization()
		{
			int result;
			int result2;
			if (!int.TryParse(textBox2.Text, out result))
			{
				MessageBox.Show("Port输入异常，请重新输入！");
			}
			else if (!int.TryParse(textBox4.Text, out result2))
			{
				MessageBox.Show("FileCache输入异常，请重新输入！");
			}
			else
			{
				integrationFileClient = new IntegrationFileClient(textBox1.Text, result)
				{
					ConnectTimeOut = 5000,
					Token = new Guid(textBox15.Text),
					LogNet = new LogNetSingle(Application.StartupPath + "\\Logs\\log.txt"),
					FileCacheSize = result2 * 1024
				};
				string path = Application.StartupPath + "\\Files";
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
				button1.Enabled = false;
				panel2.Enabled = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			IntegrationFileClientInitialization();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					textBox3.Text = openFileDialog.FileName;
				}
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton3_Click_003Ed__6))]
		[DebuggerStepThrough]
		private void button3_Click(object sender, EventArgs e)
		{
			_003Cbutton3_Click_003Ed__6 stateMachine = new _003Cbutton3_Click_003Ed__6();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void ThreadUploadFile(object filename)
		{
			string text = filename as string;
			if (text != null)
			{
				FileInfo fileInfo = new FileInfo(text);
				OperateResult result = integrationFileClient.UploadFile(text, fileInfo.Name, textBox_upload_factory.Text, textBox_upload_group.Text, textBox_upload_id.Text, textBox_upload_tag.Text, textBox_upload_name.Text, UpdateReportProgress);
				Invoke((Action<OperateResult>)delegate
				{
					button3.Enabled = true;
					if (result.IsSuccess)
					{
						MessageBox.Show("文件上传成功！");
					}
					else
					{
						MessageBox.Show("文件上传失败：" + result.ToMessageShowString());
					}
				}, result);
			}
		}

		private void UpdateReportProgress(long sended, long totle)
		{
			if (progressBar1.InvokeRequired)
			{
				progressBar1.Invoke(new Action<long, long>(UpdateReportProgress), sended, totle);
			}
			else
			{
				int value = (int)(sended * 100 / totle);
				label10.Text = sended.ToString() + "/" + totle.ToString();
				progressBar1.Value = value;
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton4_Click_003Ed__9))]
		[DebuggerStepThrough]
		private void button4_Click(object sender, EventArgs e)
		{
			_003Cbutton4_Click_003Ed__9 stateMachine = new _003Cbutton4_Click_003Ed__9();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button10_Click(object sender, EventArgs e)
		{
			string text = textBox_download_fileName.Text;
			OperateResult<bool> operateResult = integrationFileClient.IsFileExists(text, textBox_download_factory.Text, textBox_download_group.Text, textBox_download_id.Text);
			if (operateResult.IsSuccess)
			{
				if (operateResult.Content)
				{
					MessageBox.Show("文件存在！");
				}
				else
				{
					MessageBox.Show("文件不存在！");
				}
			}
			else
			{
				MessageBox.Show(operateResult.Message);
			}
		}

		private void ThreadDownloadFile(object filename)
		{
			string text = filename as string;
			if (text != null)
			{
				OperateResult result = integrationFileClient.DownloadFile(text, textBox_download_factory.Text, textBox_download_group.Text, textBox_download_id.Text, DownloadReportProgress, Application.StartupPath + "\\Files\\" + ((filename != null) ? filename.ToString() : null));
				Invoke((Action<OperateResult>)delegate
				{
					button4.Enabled = true;
					if (result.IsSuccess)
					{
						MessageBox.Show("文件下载成功！");
					}
					else
					{
						MessageBox.Show("文件下载失败：" + result.ToMessageShowString());
					}
				}, result);
			}
		}

		private void DownloadReportProgress(long receive, long totle)
		{
			if (progressBar2.InvokeRequired)
			{
				progressBar2.Invoke(new Action<long, long>(DownloadReportProgress), receive, totle);
			}
			else
			{
				int value = (int)(receive * 100 / totle);
				progressBar2.Value = value;
				label9.Text = receive.ToString() + "/" + totle.ToString();
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton5_Click_003Ed__13))]
		[DebuggerStepThrough]
		private void button5_Click(object sender, EventArgs e)
		{
			_003Cbutton5_Click_003Ed__13 stateMachine = new _003Cbutton5_Click_003Ed__13();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton9_Click_003Ed__14))]
		[DebuggerStepThrough]
		private void button9_Click(object sender, EventArgs e)
		{
			_003Cbutton9_Click_003Ed__14 stateMachine = new _003Cbutton9_Click_003Ed__14();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void button11_Click(object sender, EventArgs e)
		{
			OperateResult operateResult = integrationFileClient.DeleteEmptyFolders(textBox_delete_factory.Text, textBox_delete_group.Text, textBox_delete_id.Text);
			if (operateResult.IsSuccess)
			{
				MessageBox.Show("空目录信息删除成功！");
			}
			else
			{
				MessageBox.Show("空目录信息删除失败，原因：" + operateResult.ToMessageShowString());
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton12_Click_003Ed__16))]
		[DebuggerStepThrough]
		private void button12_Click(object sender, EventArgs e)
		{
			_003Cbutton12_Click_003Ed__16 stateMachine = new _003Cbutton12_Click_003Ed__16();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton13_Click_003Ed__17))]
		[DebuggerStepThrough]
		private void button13_Click(object sender, EventArgs e)
		{
			_003Cbutton13_Click_003Ed__17 stateMachine = new _003Cbutton13_Click_003Ed__17();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void FillNodeByFactoryGroupId(TreeNode root, OperateResult<string[]> read, int grade)
		{
			root.Nodes.Clear();
			if (read.IsSuccess)
			{
				string[] content = read.Content;
				foreach (string text in content)
				{
					TreeNode treeNode = new TreeNode(text);
					treeNode.Tag = grade;
					treeNode.Nodes.Add(new TreeNode());
					root.Nodes.Add(treeNode);
				}
			}
			else
			{
				MessageBox.Show(read.ToMessageShowString());
			}
		}

		private void FillNodeFilesByFactoryGroupId(TreeNode root, OperateResult<GroupFileItem[]> read)
		{
			root.Nodes.Clear();
			root.ExpandAll();
			if (read.IsSuccess)
			{
				GroupFileItem[] content = read.Content;
				foreach (GroupFileItem groupFileItem in content)
				{
					TreeNode treeNode = new TreeNode(groupFileItem.FileName);
					treeNode.Tag = groupFileItem;
					root.Nodes.Add(treeNode);
				}
			}
			else
			{
				MessageBox.Show(read.ToMessageShowString());
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton6_Click_003Ed__20))]
		[DebuggerStepThrough]
		private void button6_Click(object sender, EventArgs e)
		{
			_003Cbutton6_Click_003Ed__20 stateMachine = new _003Cbutton6_Click_003Ed__20();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CtreeView1_BeforeExpand_003Ed__21))]
		[DebuggerStepThrough]
		private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			_003CtreeView1_BeforeExpand_003Ed__21 stateMachine = new _003CtreeView1_BeforeExpand_003Ed__21();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			TreeNode node = e.Node;
			if (node.Tag != null)
			{
				GroupFileItem groupFileItem = node.Tag as GroupFileItem;
				if (groupFileItem != null)
				{
					List<string> list = new List<string>(3)
					{
						string.Empty,
						string.Empty,
						string.Empty
					};
					List<string> list2 = list;
					TreeNode parent = node.Parent;
					object value;
					if (parent == null)
					{
						value = null;
					}
					else
					{
						TreeNode parent2 = parent.Parent;
						if (parent2 == null)
						{
							value = null;
						}
						else
						{
							TreeNode parent3 = parent2.Parent;
							value = ((parent3 != null) ? parent3.Text : null);
						}
					}
					list2[0] = (string)value;
					List<string> list3 = list;
					TreeNode parent4 = node.Parent;
					object value2;
					if (parent4 == null)
					{
						value2 = null;
					}
					else
					{
						TreeNode parent5 = parent4.Parent;
						value2 = ((parent5 != null) ? parent5.Text : null);
					}
					list3[1] = (string)value2;
					List<string> list4 = list;
					TreeNode parent6 = node.Parent;
					list4[2] = ((parent6 != null) ? parent6.Text : null);
					for (int num = 2; num >= 0; num--)
					{
						if (string.IsNullOrEmpty(list[num]))
						{
							list.RemoveAt(num);
						}
					}
					if (list.Count > 0)
					{
						textBox_show_factory.Text = list[0];
					}
					if (list.Count > 1)
					{
						textBox_show_group.Text = list[1];
					}
					if (list.Count > 2)
					{
						textBox_show_id.Text = list[2];
					}
					textBox_file_fileName.Text = groupFileItem.FileName;
					textBox_file_fileSize.Text = groupFileItem.FileSize.ToString();
					textBox_file_date.Text = groupFileItem.UploadTime.ToString();
					textBox_file_dowloadTimes.Text = groupFileItem.DownloadTimes.ToString();
					textBox_file_upload.Text = groupFileItem.Owner;
					textBox_file_tag.Text = groupFileItem.Description;
				}
			}
		}

		private void TestMethod()
		{
			OperateResult<GroupFileItem[]> operateResult = integrationFileClient.DownloadPathFileNames("Files", "Group", "id");
			if (operateResult.IsSuccess)
			{
				GroupFileItem[] content = operateResult.Content;
				foreach (GroupFileItem groupFileItem in content)
				{
				}
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			threadlength = 20;
			upSuccess = 0;
			downSuccess = 0;
			deleteSuccess = 0;
			for (int i = 0; i < threadlength; i++)
			{
				Thread thread = new Thread(ServerPressureTest);
				thread.IsBackground = true;
				thread.Start("B" + i.ToString());
			}
			button7.Enabled = false;
		}

		private void ServerPressureTest(object obj)
		{
			string text = obj as string;
			if (text != null)
			{
				string text2 = Path.Combine(Application.StartupPath, text);
				Directory.CreateDirectory(text2);
				for (int i = 0; i < 100; i++)
				{
					string text3 = text + "-A" + random.Next(500).ToString() + ".txt";
					string text4 = Path.Combine(text2, text3);
					StringBuilder stringBuilder = new StringBuilder();
					for (int j = 0; j < 1024; j++)
					{
						stringBuilder.Append('1');
					}
					File.WriteAllText(text4, stringBuilder.ToString(), Encoding.UTF8);
					if (integrationFileClient.UploadFile(text4, "Files", "Group", "id", null).IsSuccess)
					{
						upSuccess++;
					}
					File.Delete(text4);
					if (!integrationFileClient.IsFileExists(text3, "Files", "Group", "id").Content)
					{
						upSuccess--;
					}
					else
					{
						if (integrationFileClient.DownloadFile(text3, "Files", "Group", "id", null, text4).IsSuccess)
						{
							downSuccess++;
						}
						File.Delete(text4);
						if (integrationFileClient.DeleteFile(text3, "Files", "Group", "id").IsSuccess)
						{
							deleteSuccess++;
						}
						if (integrationFileClient.IsFileExists(text3, "Files", "Group", "id").Content)
						{
							deleteSuccess--;
						}
					}
				}
				Directory.Delete(text2);
				if (Interlocked.Decrement(ref threadlength) == 0)
				{
					Invoke((Action)delegate
					{
						button7.Enabled = true;
						MessageBox.Show("成功上传次数：" + upSuccess.ToString() + Environment.NewLine + "成功下载次数：" + downSuccess.ToString() + Environment.NewLine + "成功删除次数：" + deleteSuccess.ToString());
					});
				}
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			threadlength = 20;
			upSuccess = 0;
			downSuccess = 0;
			deleteSuccess = 0;
			for (int i = 0; i < threadlength; i++)
			{
				ThreadPool.QueueUserWorkItem(ServerPressureTest2, "B" + i.ToString());
			}
			button8.Enabled = false;
		}

		[AsyncStateMachine(typeof(_003CServerPressureTest2_003Ed__32))]
		[DebuggerStepThrough]
		private void ServerPressureTest2(object obj)
		{
			_003CServerPressureTest2_003Ed__32 stateMachine = new _003CServerPressureTest2_003Ed__32();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.obj = obj;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlToken, textBox15.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox15.Text = element.Attribute(DemoDeviceList.XmlToken).Value;
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
			System.Windows.Forms.TreeNode treeNode = new System.Windows.Forms.TreeNode("文件列表");
			panel1 = new System.Windows.Forms.Panel();
			label20 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label19 = new System.Windows.Forms.Label();
			textBox15 = new System.Windows.Forms.TextBox();
			label21 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			groupBox4 = new System.Windows.Forms.GroupBox();
			textBox_show_id = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox_show_group = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox_show_factory = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			button8 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			label18 = new System.Windows.Forms.Label();
			button6 = new System.Windows.Forms.Button();
			textBox_file_date = new System.Windows.Forms.TextBox();
			label32 = new System.Windows.Forms.Label();
			textBox_file_tag = new System.Windows.Forms.TextBox();
			label26 = new System.Windows.Forms.Label();
			textBox_file_upload = new System.Windows.Forms.TextBox();
			label25 = new System.Windows.Forms.Label();
			textBox_file_dowloadTimes = new System.Windows.Forms.TextBox();
			label24 = new System.Windows.Forms.Label();
			textBox_file_fileSize = new System.Windows.Forms.TextBox();
			label23 = new System.Windows.Forms.Label();
			textBox_file_fileName = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			treeView1 = new System.Windows.Forms.TreeView();
			groupBox3 = new System.Windows.Forms.GroupBox();
			label22 = new System.Windows.Forms.Label();
			button12 = new System.Windows.Forms.Button();
			button11 = new System.Windows.Forms.Button();
			button9 = new System.Windows.Forms.Button();
			textBox_delete_fileName = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			textBox_delete_id = new System.Windows.Forms.TextBox();
			label_delete_id = new System.Windows.Forms.Label();
			textBox_delete_group = new System.Windows.Forms.TextBox();
			label_delete_group = new System.Windows.Forms.Label();
			button5 = new System.Windows.Forms.Button();
			textBox_delete_factory = new System.Windows.Forms.TextBox();
			label17 = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			button10 = new System.Windows.Forms.Button();
			label9 = new System.Windows.Forms.Label();
			textBox_download_fileName = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			textBox_download_id = new System.Windows.Forms.TextBox();
			label15 = new System.Windows.Forms.Label();
			textBox_download_group = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			progressBar2 = new System.Windows.Forms.ProgressBar();
			label12 = new System.Windows.Forms.Label();
			button4 = new System.Windows.Forms.Button();
			textBox_download_factory = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			label10 = new System.Windows.Forms.Label();
			textBox_upload_tag = new System.Windows.Forms.TextBox();
			label31 = new System.Windows.Forms.Label();
			textBox_upload_name = new System.Windows.Forms.TextBox();
			label30 = new System.Windows.Forms.Label();
			textBox_upload_id = new System.Windows.Forms.TextBox();
			label27 = new System.Windows.Forms.Label();
			textBox_upload_group = new System.Windows.Forms.TextBox();
			label28 = new System.Windows.Forms.Label();
			textBox_upload_factory = new System.Windows.Forms.TextBox();
			label29 = new System.Windows.Forms.Label();
			progressBar1 = new System.Windows.Forms.ProgressBar();
			label7 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			button13 = new System.Windows.Forms.Button();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox4.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(label20);
			panel1.Controls.Add(textBox4);
			panel1.Controls.Add(label19);
			panel1.Controls.Add(textBox15);
			panel1.Controls.Add(label21);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(15, 45);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(978, 42);
			panel1.TabIndex = 7;
			label20.AutoSize = true;
			label20.Location = new System.Drawing.Point(474, 12);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(24, 17);
			label20.TabIndex = 10;
			label20.Text = "KB";
			textBox4.Location = new System.Drawing.Point(395, 9);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(72, 23);
			textBox4.TabIndex = 9;
			textBox4.Text = "100";
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(325, 12);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(65, 17);
			label19.TabIndex = 8;
			label19.Text = "FileCache:";
			textBox15.Location = new System.Drawing.Point(552, 9);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(302, 23);
			textBox15.TabIndex = 7;
			textBox15.Text = "1";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(498, 12);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(44, 17);
			label21.TabIndex = 6;
			label21.Text = "令牌：";
			button1.Location = new System.Drawing.Point(875, 6);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 4;
			button1.Text = "初始化";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox2.Location = new System.Drawing.Point(244, 9);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(65, 23);
			textBox2.TabIndex = 3;
			textBox2.Text = "35002";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(190, 12);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 2;
			label3.Text = "端口号：";
			textBox1.Location = new System.Drawing.Point(62, 9);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(113, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 17);
			label1.TabIndex = 0;
			label1.Text = "Ip地址：";
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(groupBox4);
			panel2.Controls.Add(groupBox3);
			panel2.Controls.Add(groupBox2);
			panel2.Controls.Add(groupBox1);
			panel2.Enabled = false;
			panel2.Location = new System.Drawing.Point(15, 94);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(978, 539);
			panel2.TabIndex = 13;
			groupBox4.Controls.Add(textBox_show_id);
			groupBox4.Controls.Add(label2);
			groupBox4.Controls.Add(textBox_show_group);
			groupBox4.Controls.Add(label4);
			groupBox4.Controls.Add(textBox_show_factory);
			groupBox4.Controls.Add(label5);
			groupBox4.Controls.Add(button8);
			groupBox4.Controls.Add(button7);
			groupBox4.Controls.Add(label18);
			groupBox4.Controls.Add(button6);
			groupBox4.Controls.Add(textBox_file_date);
			groupBox4.Controls.Add(label32);
			groupBox4.Controls.Add(textBox_file_tag);
			groupBox4.Controls.Add(label26);
			groupBox4.Controls.Add(textBox_file_upload);
			groupBox4.Controls.Add(label25);
			groupBox4.Controls.Add(textBox_file_dowloadTimes);
			groupBox4.Controls.Add(label24);
			groupBox4.Controls.Add(textBox_file_fileSize);
			groupBox4.Controls.Add(label23);
			groupBox4.Controls.Add(textBox_file_fileName);
			groupBox4.Controls.Add(label11);
			groupBox4.Controls.Add(treeView1);
			groupBox4.Location = new System.Drawing.Point(11, 289);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(955, 246);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "浏览服务器文件";
			textBox_show_id.Location = new System.Drawing.Point(850, 58);
			textBox_show_id.Name = "textBox_show_id";
			textBox_show_id.Size = new System.Drawing.Size(84, 23);
			textBox_show_id.TabIndex = 41;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(817, 61);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(32, 17);
			label2.TabIndex = 40;
			label2.Text = "Id：";
			textBox_show_group.Location = new System.Drawing.Point(723, 58);
			textBox_show_group.Name = "textBox_show_group";
			textBox_show_group.Size = new System.Drawing.Size(84, 23);
			textBox_show_group.TabIndex = 39;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(667, 61);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(57, 17);
			label4.TabIndex = 38;
			label4.Text = "Group：";
			textBox_show_factory.Location = new System.Drawing.Point(577, 58);
			textBox_show_factory.Name = "textBox_show_factory";
			textBox_show_factory.Size = new System.Drawing.Size(84, 23);
			textBox_show_factory.TabIndex = 37;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(503, 61);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(62, 17);
			label5.TabIndex = 36;
			label5.Text = "Factory：";
			button8.Location = new System.Drawing.Point(424, 211);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(70, 32);
			button8.TabIndex = 35;
			button8.Text = "单上传";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			button7.Location = new System.Drawing.Point(424, 175);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(70, 32);
			button7.TabIndex = 34;
			button7.Text = "压力测试";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			label18.ForeColor = System.Drawing.Color.Red;
			label18.Location = new System.Drawing.Point(509, 14);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(425, 43);
			label18.TabIndex = 33;
			label18.Text = "注意：当服务器是AFS时，只有文件名和文件大小是有效的，而UFS时，下面数据都是有效的";
			button6.Location = new System.Drawing.Point(424, 20);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(70, 28);
			button6.TabIndex = 32;
			button6.Text = "刷新";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			textBox_file_date.Location = new System.Drawing.Point(576, 189);
			textBox_file_date.Name = "textBox_file_date";
			textBox_file_date.Size = new System.Drawing.Size(357, 23);
			textBox_file_date.TabIndex = 31;
			label32.AutoSize = true;
			label32.Location = new System.Drawing.Point(502, 192);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(68, 17);
			label32.TabIndex = 30;
			label32.Text = "上传日期：";
			textBox_file_tag.Location = new System.Drawing.Point(576, 216);
			textBox_file_tag.Name = "textBox_file_tag";
			textBox_file_tag.Size = new System.Drawing.Size(357, 23);
			textBox_file_tag.TabIndex = 29;
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(502, 219);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(44, 17);
			label26.TabIndex = 28;
			label26.Text = "备注：";
			textBox_file_upload.Location = new System.Drawing.Point(802, 161);
			textBox_file_upload.Name = "textBox_file_upload";
			textBox_file_upload.Size = new System.Drawing.Size(132, 23);
			textBox_file_upload.TabIndex = 27;
			label25.AutoSize = true;
			label25.Location = new System.Drawing.Point(728, 164);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(56, 17);
			label25.TabIndex = 26;
			label25.Text = "上传人：";
			textBox_file_dowloadTimes.Location = new System.Drawing.Point(576, 161);
			textBox_file_dowloadTimes.Name = "textBox_file_dowloadTimes";
			textBox_file_dowloadTimes.Size = new System.Drawing.Size(132, 23);
			textBox_file_dowloadTimes.TabIndex = 25;
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(502, 164);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(68, 17);
			label24.TabIndex = 24;
			label24.Text = "下载次数：";
			textBox_file_fileSize.Location = new System.Drawing.Point(576, 132);
			textBox_file_fileSize.Name = "textBox_file_fileSize";
			textBox_file_fileSize.Size = new System.Drawing.Size(357, 23);
			textBox_file_fileSize.TabIndex = 23;
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(502, 135);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(68, 17);
			label23.TabIndex = 22;
			label23.Text = "文件大小：";
			textBox_file_fileName.Location = new System.Drawing.Point(576, 102);
			textBox_file_fileName.Name = "textBox_file_fileName";
			textBox_file_fileName.Size = new System.Drawing.Size(357, 23);
			textBox_file_fileName.TabIndex = 15;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(502, 105);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(68, 17);
			label11.TabIndex = 14;
			label11.Text = "文件名称：";
			treeView1.Location = new System.Drawing.Point(9, 22);
			treeView1.Name = "treeView1";
			treeNode.Name = "节点0";
			treeNode.Text = "文件列表";
			treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[1]
			{
				treeNode
			});
			treeView1.Size = new System.Drawing.Size(409, 218);
			treeView1.TabIndex = 0;
			treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(treeView1_BeforeExpand);
			treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);
			groupBox3.Controls.Add(button13);
			groupBox3.Controls.Add(label22);
			groupBox3.Controls.Add(button12);
			groupBox3.Controls.Add(button11);
			groupBox3.Controls.Add(button9);
			groupBox3.Controls.Add(textBox_delete_fileName);
			groupBox3.Controls.Add(label8);
			groupBox3.Controls.Add(textBox_delete_id);
			groupBox3.Controls.Add(label_delete_id);
			groupBox3.Controls.Add(textBox_delete_group);
			groupBox3.Controls.Add(label_delete_group);
			groupBox3.Controls.Add(button5);
			groupBox3.Controls.Add(textBox_delete_factory);
			groupBox3.Controls.Add(label17);
			groupBox3.Location = new System.Drawing.Point(11, 213);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(955, 74);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "文件删除";
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(118, 48);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(15, 17);
			label22.TabIndex = 21;
			label22.Text = "0";
			button12.Location = new System.Drawing.Point(9, 42);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(95, 28);
			button12.TabIndex = 20;
			button12.Text = "文件夹信息";
			button12.UseVisualStyleBackColor = true;
			button12.Click += new System.EventHandler(button12_Click);
			button11.Location = new System.Drawing.Point(866, 42);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(78, 28);
			button11.TabIndex = 19;
			button11.Text = "空目录删除";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			button9.Location = new System.Drawing.Point(866, 13);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(78, 28);
			button9.TabIndex = 18;
			button9.Text = "全部删除";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			textBox_delete_fileName.Location = new System.Drawing.Point(517, 16);
			textBox_delete_fileName.Name = "textBox_delete_fileName";
			textBox_delete_fileName.Size = new System.Drawing.Size(267, 23);
			textBox_delete_fileName.TabIndex = 17;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(443, 19);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(56, 17);
			label8.TabIndex = 16;
			label8.Text = "文件名：";
			textBox_delete_id.Location = new System.Drawing.Point(353, 16);
			textBox_delete_id.Name = "textBox_delete_id";
			textBox_delete_id.Size = new System.Drawing.Size(84, 23);
			textBox_delete_id.TabIndex = 15;
			textBox_delete_id.Text = "Admin";
			label_delete_id.AutoSize = true;
			label_delete_id.Location = new System.Drawing.Point(320, 19);
			label_delete_id.Name = "label_delete_id";
			label_delete_id.Size = new System.Drawing.Size(32, 17);
			label_delete_id.TabIndex = 14;
			label_delete_id.Text = "Id：";
			textBox_delete_group.Location = new System.Drawing.Point(226, 16);
			textBox_delete_group.Name = "textBox_delete_group";
			textBox_delete_group.Size = new System.Drawing.Size(84, 23);
			textBox_delete_group.TabIndex = 13;
			textBox_delete_group.Text = "Personal";
			label_delete_group.AutoSize = true;
			label_delete_group.Location = new System.Drawing.Point(170, 19);
			label_delete_group.Name = "label_delete_group";
			label_delete_group.Size = new System.Drawing.Size(57, 17);
			label_delete_group.TabIndex = 12;
			label_delete_group.Text = "Group：";
			button5.Location = new System.Drawing.Point(790, 13);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(70, 28);
			button5.TabIndex = 7;
			button5.Text = "删除";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			textBox_delete_factory.Location = new System.Drawing.Point(80, 16);
			textBox_delete_factory.Name = "textBox_delete_factory";
			textBox_delete_factory.Size = new System.Drawing.Size(84, 23);
			textBox_delete_factory.TabIndex = 5;
			textBox_delete_factory.Text = "Files";
			label17.AutoSize = true;
			label17.Location = new System.Drawing.Point(6, 19);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(62, 17);
			label17.TabIndex = 4;
			label17.Text = "Factory：";
			groupBox2.Controls.Add(button10);
			groupBox2.Controls.Add(label9);
			groupBox2.Controls.Add(textBox_download_fileName);
			groupBox2.Controls.Add(label16);
			groupBox2.Controls.Add(textBox_download_id);
			groupBox2.Controls.Add(label15);
			groupBox2.Controls.Add(textBox_download_group);
			groupBox2.Controls.Add(label14);
			groupBox2.Controls.Add(progressBar2);
			groupBox2.Controls.Add(label12);
			groupBox2.Controls.Add(button4);
			groupBox2.Controls.Add(textBox_download_factory);
			groupBox2.Controls.Add(label13);
			groupBox2.Location = new System.Drawing.Point(11, 125);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(955, 86);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "文件下载";
			button10.Location = new System.Drawing.Point(874, 52);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(70, 28);
			button10.TabIndex = 19;
			button10.Text = "是否存在";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(button10_Click);
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(762, 56);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(27, 17);
			label9.TabIndex = 18;
			label9.Text = "0/0";
			textBox_download_fileName.Location = new System.Drawing.Point(517, 25);
			textBox_download_fileName.Name = "textBox_download_fileName";
			textBox_download_fileName.Size = new System.Drawing.Size(341, 23);
			textBox_download_fileName.TabIndex = 17;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(443, 28);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(56, 17);
			label16.TabIndex = 16;
			label16.Text = "文件名：";
			textBox_download_id.Location = new System.Drawing.Point(353, 25);
			textBox_download_id.Name = "textBox_download_id";
			textBox_download_id.Size = new System.Drawing.Size(84, 23);
			textBox_download_id.TabIndex = 15;
			textBox_download_id.Text = "Admin";
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(320, 28);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(32, 17);
			label15.TabIndex = 14;
			label15.Text = "Id：";
			textBox_download_group.Location = new System.Drawing.Point(226, 25);
			textBox_download_group.Name = "textBox_download_group";
			textBox_download_group.Size = new System.Drawing.Size(84, 23);
			textBox_download_group.TabIndex = 13;
			textBox_download_group.Text = "Personal";
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(170, 28);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(57, 17);
			label14.TabIndex = 12;
			label14.Text = "Group：";
			progressBar2.Location = new System.Drawing.Point(80, 56);
			progressBar2.Name = "progressBar2";
			progressBar2.Size = new System.Drawing.Size(669, 17);
			progressBar2.TabIndex = 9;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(6, 56);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(44, 17);
			label12.TabIndex = 8;
			label12.Text = "进度：";
			button4.Location = new System.Drawing.Point(874, 22);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(70, 28);
			button4.TabIndex = 7;
			button4.Text = "下载";
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			textBox_download_factory.Location = new System.Drawing.Point(80, 25);
			textBox_download_factory.Name = "textBox_download_factory";
			textBox_download_factory.Size = new System.Drawing.Size(84, 23);
			textBox_download_factory.TabIndex = 5;
			textBox_download_factory.Text = "Files";
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(6, 28);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(62, 17);
			label13.TabIndex = 4;
			label13.Text = "Factory：";
			groupBox1.Controls.Add(label10);
			groupBox1.Controls.Add(textBox_upload_tag);
			groupBox1.Controls.Add(label31);
			groupBox1.Controls.Add(textBox_upload_name);
			groupBox1.Controls.Add(label30);
			groupBox1.Controls.Add(textBox_upload_id);
			groupBox1.Controls.Add(label27);
			groupBox1.Controls.Add(textBox_upload_group);
			groupBox1.Controls.Add(label28);
			groupBox1.Controls.Add(textBox_upload_factory);
			groupBox1.Controls.Add(label29);
			groupBox1.Controls.Add(progressBar1);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(button3);
			groupBox1.Controls.Add(button2);
			groupBox1.Controls.Add(textBox3);
			groupBox1.Controls.Add(label6);
			groupBox1.Location = new System.Drawing.Point(11, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(955, 117);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "文件上传";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(762, 87);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(27, 17);
			label10.TabIndex = 26;
			label10.Text = "0/0";
			textBox_upload_tag.Location = new System.Drawing.Point(709, 56);
			textBox_upload_tag.Name = "textBox_upload_tag";
			textBox_upload_tag.Size = new System.Drawing.Size(235, 23);
			textBox_upload_tag.TabIndex = 25;
			textBox_upload_tag.Text = "test test for example it is import";
			label31.AutoSize = true;
			label31.Location = new System.Drawing.Point(669, 59);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(44, 17);
			label31.TabIndex = 24;
			label31.Text = "备注：";
			textBox_upload_name.Location = new System.Drawing.Point(578, 56);
			textBox_upload_name.Name = "textBox_upload_name";
			textBox_upload_name.Size = new System.Drawing.Size(84, 23);
			textBox_upload_name.TabIndex = 23;
			textBox_upload_name.Text = "you name";
			label30.AutoSize = true;
			label30.Location = new System.Drawing.Point(521, 59);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(56, 17);
			label30.TabIndex = 22;
			label30.Text = "上传人：";
			textBox_upload_id.Location = new System.Drawing.Point(424, 56);
			textBox_upload_id.Name = "textBox_upload_id";
			textBox_upload_id.Size = new System.Drawing.Size(84, 23);
			textBox_upload_id.TabIndex = 21;
			textBox_upload_id.Text = "Admin";
			label27.AutoSize = true;
			label27.Location = new System.Drawing.Point(391, 59);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(32, 17);
			label27.TabIndex = 20;
			label27.Text = "Id：";
			textBox_upload_group.Location = new System.Drawing.Point(297, 56);
			textBox_upload_group.Name = "textBox_upload_group";
			textBox_upload_group.Size = new System.Drawing.Size(84, 23);
			textBox_upload_group.TabIndex = 19;
			textBox_upload_group.Text = "Personal";
			label28.AutoSize = true;
			label28.Location = new System.Drawing.Point(241, 59);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(57, 17);
			label28.TabIndex = 18;
			label28.Text = "Group：";
			textBox_upload_factory.Location = new System.Drawing.Point(151, 56);
			textBox_upload_factory.Name = "textBox_upload_factory";
			textBox_upload_factory.Size = new System.Drawing.Size(84, 23);
			textBox_upload_factory.TabIndex = 17;
			textBox_upload_factory.Text = "Files";
			label29.AutoSize = true;
			label29.Location = new System.Drawing.Point(77, 59);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(62, 17);
			label29.TabIndex = 16;
			label29.Text = "Factory：";
			progressBar1.Location = new System.Drawing.Point(80, 87);
			progressBar1.Name = "progressBar1";
			progressBar1.Size = new System.Drawing.Size(669, 17);
			progressBar1.TabIndex = 9;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(6, 87);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(44, 17);
			label7.TabIndex = 8;
			label7.Text = "进度：";
			button3.Location = new System.Drawing.Point(874, 22);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(70, 28);
			button3.TabIndex = 7;
			button3.Text = "上传";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button2.Location = new System.Drawing.Point(798, 22);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(70, 28);
			button2.TabIndex = 6;
			button2.Text = "选择";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			textBox3.Location = new System.Drawing.Point(80, 25);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(708, 23);
			textBox3.TabIndex = 5;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(6, 28);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(68, 17);
			label6.TabIndex = 4;
			label6.Text = "文件路径：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/7746113.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "Hsl - File";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 14;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			button13.Location = new System.Drawing.Point(765, 42);
			button13.Name = "button13";
			button13.Size = new System.Drawing.Size(95, 28);
			button13.TabIndex = 22;
			button13.Text = "子文件夹信息";
			button13.UseVisualStyleBackColor = true;
			button13.Click += new System.EventHandler(button13_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormFileClient";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "文件客户端窗口";
			base.Load += new System.EventHandler(FormFileClient_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
