using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using HslCommunication.MQTT;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormMqttFileClient : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003CDownloadFileExample_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public FormMqttFileClient _003C_003E4__this;

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
						_003C_003E4__this.button_download.Enabled = false;
						_003C_003E4__this.button_download_cancel.Enabled = true;
						_003C_003E4__this.label15.Text = "Start downloading...";
						_003CfileName_003E5__1 = _003C_003E4__this.textBox_download_fileName.Text;
						_003CdownloadStartTime_003E5__2 = DateTime.Now;
						awaiter = _003C_003E4__this.mqttSyncClient.DownloadFileAsync(_003C_003E4__this.textBox5.Text, _003CfileName_003E5__1, _003C_003E4__this.DownloadReportProgress, Application.StartupPath + "\\Files\\" + _003CfileName_003E5__1, _003C_003E4__this.downloadCacel).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CDownloadFileExample_003Ed__16 stateMachine = this;
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
					_003C_003E4__this.button_download.Enabled = true;
					_003C_003E4__this.button_download_cancel.Enabled = false;
					if (_003Cresult_003E5__3.IsSuccess)
					{
						_003C_003E4__this.label15.Text = "文件下载成功！耗时：" + (DateTime.Now - _003CdownloadStartTime_003E5__2).TotalSeconds.ToString("F1") + " 秒";
					}
					else
					{
						_003C_003E4__this.label15.Text = "文件下载失败：" + _003Cresult_003E5__3.Message;
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
		private sealed class _003CUploadFlieExample_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<OperateResult> _003C_003Et__builder;

			public FormMqttFileClient _003C_003E4__this;

			private string _003CfileName_003E5__1;

			private FileInfo _003CfileInfo_003E5__2;

			private OperateResult _003Cresult_003E5__3;

			private OperateResult _003C_003Es__4;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				OperateResult result;
				try
				{
					TaskAwaiter<OperateResult> awaiter;
					if (num != 0)
					{
						_003C_003E4__this.button_upload.Enabled = false;
						_003C_003E4__this.button_upload_cancel.Enabled = true;
						_003CfileName_003E5__1 = _003C_003E4__this.textBox3.Text;
						_003CfileInfo_003E5__2 = new FileInfo(_003CfileName_003E5__1);
						awaiter = _003C_003E4__this.mqttSyncClient.UploadFileAsync(_003CfileName_003E5__1, _003C_003E4__this.textBox_upload_group.Text, _003CfileInfo_003E5__2.Name, _003C_003E4__this.textBox_upload_tag.Text, _003C_003E4__this.UpdateReportProgress, _003C_003E4__this.uploadCacel).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CUploadFlieExample_003Ed__8 stateMachine = this;
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
					_003C_003E4__this.button_upload.Enabled = true;
					_003C_003E4__this.button_upload_cancel.Enabled = false;
					result = _003Cresult_003E5__3;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003CfileName_003E5__1 = null;
					_003CfileInfo_003E5__2 = null;
					_003Cresult_003E5__3 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003CfileName_003E5__1 = null;
				_003CfileInfo_003E5__2 = null;
				_003Cresult_003E5__3 = null;
				_003C_003Et__builder.SetResult(result);
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
		private sealed class _003Cbutton10_Click_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttFileClient _003C_003E4__this;

			private string _003CfileName_003E5__1;

			private OperateResult<bool> _003Cresult_003E5__2;

			private OperateResult<bool> _003C_003Es__3;

			private TaskAwaiter<OperateResult<bool>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<bool>> awaiter;
					if (num != 0)
					{
						_003CfileName_003E5__1 = _003C_003E4__this.textBox_download_fileName.Text;
						awaiter = _003C_003E4__this.mqttSyncClient.IsFileExistsAsync(_003C_003E4__this.textBox_upload_group.Text, _003CfileName_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton10_Click_003Ed__19 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<bool>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003Cresult_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cresult_003E5__2.IsSuccess)
					{
						if (_003Cresult_003E5__2.Content)
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
						MessageBox.Show(_003Cresult_003E5__2.Message);
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003CfileName_003E5__1 = null;
					_003Cresult_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003CfileName_003E5__1 = null;
				_003Cresult_003E5__2 = null;
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
		private sealed class _003Cbutton11_Click_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttFileClient _003C_003E4__this;

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
						awaiter = _003C_003E4__this.mqttSyncClient.GetGroupFileInfoAsync(_003C_003E4__this.textBox6.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton11_Click_003Ed__24 stateMachine = this;
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
						_003C_003E4__this.label17.Text = _003Cresult_003E5__1.Content.ToString();
					}
					else
					{
						MessageBox.Show("获取目录大小失败，原因：" + _003Cresult_003E5__1.ToMessageShowString());
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
		private sealed class _003Cbutton12_Click_003Ed__25 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttFileClient _003C_003E4__this;

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
						awaiter = _003C_003E4__this.mqttSyncClient.GetSubGroupFileInfosAsync(_003C_003E4__this.textBox6.Text, true).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton12_Click_003Ed__25 stateMachine = this;
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
						MessageBox.Show("获取目录大小失败，原因：" + _003Cresult_003E5__1.ToMessageShowString());
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
		private sealed class _003Cbutton5_Click_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttFileClient _003C_003E4__this;

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
						awaiter = _003C_003E4__this.mqttSyncClient.DeleteFileAsync(_003C_003E4__this.textBox6.Text, _003C_003E4__this.textBox_delete_fileName.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton5_Click_003Ed__21 stateMachine = this;
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
		private sealed class _003Cbutton6_Click_003Ed__29 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttFileClient _003C_003E4__this;

			private TreeNode _003C_003Es__1;

			private OperateResult<string[]> _003C_003Es__2;

			private TreeNode _003C_003Es__3;

			private OperateResult<GroupFileItem[]> _003C_003Es__4;

			private TaskAwaiter<OperateResult<string[]>> _003C_003Eu__1;

			private TaskAwaiter<OperateResult<GroupFileItem[]>> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<string[]>> awaiter2;
					TaskAwaiter<OperateResult<GroupFileItem[]>> awaiter;
					switch (num)
					{
					default:
						_003C_003E4__this.treeView1.Nodes[0].Nodes.Clear();
						_003C_003E4__this.button6.Enabled = false;
						_003C_003Es__1 = _003C_003E4__this.treeView1.Nodes[0];
						awaiter2 = _003C_003E4__this.mqttSyncClient.DownloadPathFoldersAsync(null).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003Cbutton6_Click_003Ed__29 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
							return;
						}
						goto IL_00cf;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<string[]>>);
						num = (_003C_003E1__state = -1);
						goto IL_00cf;
					case 1:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<OperateResult<GroupFileItem[]>>);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_00cf:
						_003C_003Es__2 = awaiter2.GetResult();
						_003C_003E4__this.FillNodeByFactoryGroupId(_003C_003Es__1, _003C_003Es__2);
						_003C_003Es__1 = null;
						_003C_003Es__2 = null;
						_003C_003Es__3 = _003C_003E4__this.treeView1.Nodes[0];
						awaiter = _003C_003E4__this.mqttSyncClient.DownloadPathFileNamesAsync(null).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003Cbutton6_Click_003Ed__29 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						break;
					}
					_003C_003Es__4 = awaiter.GetResult();
					_003C_003E4__this.FillNodeFilesByFactoryGroupId(_003C_003Es__3, _003C_003Es__4);
					_003C_003Es__3 = null;
					_003C_003Es__4 = null;
					_003C_003E4__this.button6.Enabled = true;
					_003C_003E4__this.treeView1.Nodes[0].Expand();
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
		private sealed class _003Cbutton7_Click_1_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttFileClient _003C_003E4__this;

			private MqttConnectionOptions _003Coptions_003E5__1;

			private OperateResult _003Cconnect_003E5__2;

			private string _003Cpath_003E5__3;

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
						_003Coptions_003E5__1 = new MqttConnectionOptions
						{
							IpAddress = _003C_003E4__this.textBox4.Text,
							Port = int.Parse(_003C_003E4__this.textBox2.Text),
							ClientId = _003C_003E4__this.textBox1.Text,
							UseRSAProvider = _003C_003E4__this.checkBox_rsa.Checked
						};
						if (!string.IsNullOrEmpty(_003C_003E4__this.textBox9.Text) || !string.IsNullOrEmpty(_003C_003E4__this.textBox10.Text))
						{
							_003Coptions_003E5__1.Credentials = new MqttCredential(_003C_003E4__this.textBox9.Text, _003C_003E4__this.textBox10.Text);
						}
						_003C_003E4__this.button7.Enabled = false;
						_003C_003E4__this.mqttSyncClient = new MqttSyncClient(_003Coptions_003E5__1);
						awaiter = _003C_003E4__this.mqttSyncClient.ConnectServerAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton7_Click_1_003Ed__3 stateMachine = this;
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
					_003Cconnect_003E5__2 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cconnect_003E5__2.IsSuccess)
					{
						_003C_003E4__this.mqttSyncClient.ConnectClose();
						_003C_003E4__this.panel2.Enabled = true;
						_003C_003E4__this.button7.Enabled = false;
						_003C_003E4__this.button1.Enabled = true;
						MessageBox.Show(StringResources.Language.ConnectServerSuccess);
					}
					else
					{
						_003C_003E4__this.button7.Enabled = true;
						MessageBox.Show(_003Cconnect_003E5__2.Message);
					}
					_003Cpath_003E5__3 = Application.StartupPath + "\\Files";
					if (!Directory.Exists(_003Cpath_003E5__3))
					{
						Directory.CreateDirectory(_003Cpath_003E5__3);
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Coptions_003E5__1 = null;
					_003Cconnect_003E5__2 = null;
					_003Cpath_003E5__3 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Coptions_003E5__1 = null;
				_003Cconnect_003E5__2 = null;
				_003Cpath_003E5__3 = null;
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
		private sealed class _003Cbutton9_Click_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttFileClient _003C_003E4__this;

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
						awaiter = _003C_003E4__this.mqttSyncClient.DeleteFolderFilesAsync(_003C_003E4__this.textBox6.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton9_Click_003Ed__23 stateMachine = this;
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
						MessageBox.Show("文件目录删除成功！");
					}
					else
					{
						MessageBox.Show("文件目录删除失败，原因：" + _003Cresult_003E5__1.ToMessageShowString());
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
		private sealed class _003Cbutton_download_Click_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttFileClient _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						_003C_003E4__this.downloadCacel = new HslCancelToken();
						awaiter = _003C_003E4__this.DownloadFileExample().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_download_Click_003Ed__15 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
					_003C_003E4__this.downloadCacel = null;
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
		private sealed class _003Cbutton_upload_Click_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttFileClient _003C_003E4__this;

			private DateTime _003CuploadStartTime_003E5__1;

			private OperateResult _003Cresult_003E5__2;

			private OperateResult _003C_003Es__3;

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
					_003C_003E4__this.uploadCacel = new HslCancelToken();
					if (string.IsNullOrEmpty(_003C_003E4__this.textBox3.Text))
					{
						MessageBox.Show("Please Select a File");
						goto IL_017d;
					}
					if (File.Exists(_003C_003E4__this.textBox3.Text))
					{
						_003CuploadStartTime_003E5__1 = DateTime.Now;
						awaiter = _003C_003E4__this.UploadFlieExample().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton_upload_Click_003Ed__7 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_00d8;
					}
					MessageBox.Show("选择的文件不存在，退出！");
					goto end_IL_0007;
					IL_00d8:
					_003C_003Es__3 = awaiter.GetResult();
					_003Cresult_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cresult_003E5__2.IsSuccess)
					{
						MessageBox.Show("文件上传成功！耗时：" + (DateTime.Now - _003CuploadStartTime_003E5__1).TotalSeconds.ToString("F1") + " 秒");
					}
					else
					{
						MessageBox.Show("文件上传失败：" + _003Cresult_003E5__2.ToMessageShowString());
					}
					_003Cresult_003E5__2 = null;
					goto IL_017d;
					IL_017d:
					_003C_003E4__this.uploadCacel = null;
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
		private sealed class _003CtreeView1_BeforeExpand_003Ed__30 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public TreeViewCancelEventArgs e;

			public FormMqttFileClient _003C_003E4__this;

			private TreeNode _003Cnode_003E5__1;

			private string _003Cgroups_003E5__2;

			private TreeNode _003C_003Es__3;

			private OperateResult<string[]> _003C_003Es__4;

			private TreeNode _003C_003Es__5;

			private OperateResult<GroupFileItem[]> _003C_003Es__6;

			private TaskAwaiter<OperateResult<string[]>> _003C_003Eu__1;

			private TaskAwaiter<OperateResult<GroupFileItem[]>> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<string[]>> awaiter2;
					TaskAwaiter<OperateResult<GroupFileItem[]>> awaiter;
					switch (num)
					{
					default:
						_003Cnode_003E5__1 = e.Node;
						if (_003Cnode_003E5__1.Tag == null)
						{
							break;
						}
						_003Cgroups_003E5__2 = _003C_003E4__this.GetGroupsFromNode(_003Cnode_003E5__1);
						_003C_003Es__3 = _003Cnode_003E5__1;
						awaiter2 = _003C_003E4__this.mqttSyncClient.DownloadPathFoldersAsync(_003Cgroups_003E5__2).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CtreeView1_BeforeExpand_003Ed__30 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
							return;
						}
						goto IL_00cf;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<string[]>>);
						num = (_003C_003E1__state = -1);
						goto IL_00cf;
					case 1:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<OperateResult<GroupFileItem[]>>);
							num = (_003C_003E1__state = -1);
							goto IL_0179;
						}
						IL_00cf:
						_003C_003Es__4 = awaiter2.GetResult();
						_003C_003E4__this.FillNodeByFactoryGroupId(_003C_003Es__3, _003C_003Es__4);
						_003C_003Es__3 = null;
						_003C_003Es__4 = null;
						_003C_003Es__5 = _003Cnode_003E5__1;
						awaiter = _003C_003E4__this.mqttSyncClient.DownloadPathFileNamesAsync(_003Cgroups_003E5__2).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CtreeView1_BeforeExpand_003Ed__30 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_0179;
						IL_0179:
						_003C_003Es__6 = awaiter.GetResult();
						_003C_003E4__this.FillNodeFilesByFactoryGroupId(_003C_003Es__5, _003C_003Es__6);
						_003C_003Es__5 = null;
						_003C_003Es__6 = null;
						_003Cgroups_003E5__2 = null;
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

		[CompilerGenerated]
		private sealed class _003C下载文件ToolStripMenuItem_Click_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttFileClient _003C_003E4__this;

			private TreeNode _003Cnode_003E5__1;

			private GroupFileItem _003CfileItem_003E5__2;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0132;
					}
					_003Cnode_003E5__1 = _003C_003E4__this.treeView1.SelectedNode;
					if (_003Cnode_003E5__1.Tag != null)
					{
						object tag = _003Cnode_003E5__1.Tag;
						_003CfileItem_003E5__2 = (tag as GroupFileItem);
						if (_003CfileItem_003E5__2 == null)
						{
							goto IL_013b;
						}
						if (_003C_003E4__this.button_download.Enabled)
						{
							_003C_003E4__this.textBox5.Text = _003C_003E4__this.GetGroupsFromNode(_003Cnode_003E5__1.Parent);
							_003C_003E4__this.textBox_download_fileName.Text = _003CfileItem_003E5__2.FileName;
							awaiter = _003C_003E4__this.DownloadFileExample().GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003C下载文件ToolStripMenuItem_Click_003Ed__12 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
								return;
							}
							goto IL_0132;
						}
						MessageBox.Show("请等待之前的下载完成再进行操作！");
					}
					goto end_IL_0007;
					IL_013b:
					_003CfileItem_003E5__2 = null;
					goto end_IL_0007;
					IL_0132:
					awaiter.GetResult();
					goto IL_013b;
					end_IL_0007:;
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

		[CompilerGenerated]
		private sealed class _003C全部下载ToolStripMenuItem_Click_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttFileClient _003C_003E4__this;

			private TreeNode _003Cnode_003E5__1;

			private GroupFileItem _003CgroupFile_003E5__2;

			private IEnumerator _003C_003Es__3;

			private TreeNode _003Citem_003E5__4;

			private GroupFileItem _003CfileItem_003E5__5;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					if (num == 0)
					{
						goto IL_0069;
					}
					_003Cnode_003E5__1 = _003C_003E4__this.treeView1.SelectedNode;
					object tag = _003Cnode_003E5__1.Tag;
					_003CgroupFile_003E5__2 = (tag as GroupFileItem);
					if (_003CgroupFile_003E5__2 == null)
					{
						_003C_003Es__3 = _003Cnode_003E5__1.Nodes.GetEnumerator();
						goto IL_0069;
					}
					goto end_IL_0007;
					IL_0069:
					try
					{
						TaskAwaiter awaiter;
						if (num == 0)
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_019b;
						}
						goto IL_01b3;
						IL_00a2:
						tag = _003Citem_003E5__4.Tag;
						_003CfileItem_003E5__5 = (tag as GroupFileItem);
						if (_003CfileItem_003E5__5 == null)
						{
							goto IL_01a4;
						}
						if (_003C_003E4__this.button_download.Enabled)
						{
							_003C_003E4__this.textBox5.Text = _003C_003E4__this.GetGroupsFromNode(_003Citem_003E5__4.Parent);
							_003C_003E4__this.textBox_download_fileName.Text = _003CfileItem_003E5__5.FileName;
							awaiter = _003C_003E4__this.DownloadFileExample().GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003C全部下载ToolStripMenuItem_Click_003Ed__13 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
								return;
							}
							goto IL_019b;
						}
						MessageBox.Show("请等待之前的下载完成再进行操作！");
						goto IL_0215;
						IL_019b:
						awaiter.GetResult();
						goto IL_01a4;
						IL_01a4:
						_003CfileItem_003E5__5 = null;
						_003Citem_003E5__4 = null;
						goto IL_01b3;
						IL_01b3:
						while (_003C_003Es__3.MoveNext())
						{
							_003Citem_003E5__4 = (TreeNode)_003C_003Es__3.Current;
							if (_003Citem_003E5__4 == null)
							{
								continue;
							}
							goto IL_00a2;
						}
					}
					finally
					{
						if (num < 0)
						{
							IDisposable disposable = _003C_003Es__3 as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
					_003C_003Es__3 = null;
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cnode_003E5__1 = null;
					_003CgroupFile_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				goto IL_0215;
				IL_0215:
				_003C_003E1__state = -2;
				_003Cnode_003E5__1 = null;
				_003CgroupFile_003E5__2 = null;
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
		private sealed class _003C删除文件ToolStripMenuItem_Click_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttFileClient _003C_003E4__this;

			private TreeNode _003Cnode_003E5__1;

			private GroupFileItem _003CfileItem_003E5__2;

			private OperateResult _003Cresult_003E5__3;

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
						goto IL_00ee;
					}
					_003Cnode_003E5__1 = _003C_003E4__this.treeView1.SelectedNode;
					if (_003Cnode_003E5__1.Tag != null)
					{
						object tag = _003Cnode_003E5__1.Tag;
						_003CfileItem_003E5__2 = (tag as GroupFileItem);
						if (_003CfileItem_003E5__2 != null)
						{
							awaiter = _003C_003E4__this.mqttSyncClient.DeleteFileAsync(_003C_003E4__this.GetGroupsFromNode(_003Cnode_003E5__1.Parent), _003CfileItem_003E5__2.FileName).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003C删除文件ToolStripMenuItem_Click_003Ed__20 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
								return;
							}
							goto IL_00ee;
						}
						goto IL_0157;
					}
					goto end_IL_0007;
					IL_00ee:
					_003C_003Es__4 = awaiter.GetResult();
					_003Cresult_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cresult_003E5__3.IsSuccess)
					{
						MessageBox.Show("文件删除成功！");
					}
					else
					{
						MessageBox.Show("文件删除失败，原因：" + _003Cresult_003E5__3.ToMessageShowString());
					}
					_003Cresult_003E5__3 = null;
					goto IL_0157;
					IL_0157:
					_003CfileItem_003E5__2 = null;
					end_IL_0007:;
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

		[CompilerGenerated]
		private sealed class _003C删除目录ToolStripMenuItem_Click_003Ed__22 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttFileClient _003C_003E4__this;

			private TreeNode _003Cnode_003E5__1;

			private OperateResult _003Cresult_003E5__2;

			private OperateResult _003C_003Es__3;

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
						goto IL_00ad;
					}
					_003Cnode_003E5__1 = _003C_003E4__this.treeView1.SelectedNode;
					if (_003Cnode_003E5__1 != null)
					{
						awaiter = _003C_003E4__this.mqttSyncClient.DeleteFolderFilesAsync(_003C_003E4__this.GetGroupsFromNode(_003Cnode_003E5__1)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003C删除目录ToolStripMenuItem_Click_003Ed__22 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_00ad;
					}
					goto end_IL_0007;
					IL_00ad:
					_003C_003Es__3 = awaiter.GetResult();
					_003Cresult_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cresult_003E5__2.IsSuccess)
					{
						MessageBox.Show("文件目录删除成功！");
					}
					else
					{
						MessageBox.Show("文件目录删除失败，原因：" + _003Cresult_003E5__2.ToMessageShowString());
					}
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cnode_003E5__1 = null;
					_003Cresult_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cnode_003E5__1 = null;
				_003Cresult_003E5__2 = null;
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
		private sealed class _003C批量上传ToolStripMenuItem_Click_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormMqttFileClient _003C_003E4__this;

			private TreeNode _003Cnode_003E5__1;

			private GroupFileItem _003CgroupFile_003E5__2;

			private OpenFileDialog _003Cofd_003E5__3;

			private string[] _003C_003Es__4;

			private int _003C_003Es__5;

			private string _003Citem_003E5__6;

			private TaskAwaiter<OperateResult> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					if (num == 0)
					{
						goto IL_005d;
					}
					_003Cnode_003E5__1 = _003C_003E4__this.treeView1.SelectedNode;
					object tag = _003Cnode_003E5__1.Tag;
					_003CgroupFile_003E5__2 = (tag as GroupFileItem);
					if (_003CgroupFile_003E5__2 == null)
					{
						_003Cofd_003E5__3 = new OpenFileDialog();
						goto IL_005d;
					}
					goto end_IL_0007;
					IL_005d:
					try
					{
						TaskAwaiter<OperateResult> awaiter;
						if (num == 0)
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<OperateResult>);
							num = (_003C_003E1__state = -1);
							goto IL_0136;
						}
						_003Cofd_003E5__3.Multiselect = true;
						if (_003Cofd_003E5__3.ShowDialog() == DialogResult.OK)
						{
							_003C_003Es__4 = _003Cofd_003E5__3.FileNames;
							_003C_003Es__5 = 0;
							goto IL_0154;
						}
						goto end_IL_005e;
						IL_0136:
						awaiter.GetResult();
						_003Citem_003E5__6 = null;
						_003C_003Es__5++;
						goto IL_0154;
						IL_0154:
						if (_003C_003Es__5 < _003C_003Es__4.Length)
						{
							_003Citem_003E5__6 = _003C_003Es__4[_003C_003Es__5];
							_003C_003E4__this.textBox3.Text = _003Citem_003E5__6;
							awaiter = _003C_003E4__this.UploadFlieExample().GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003C批量上传ToolStripMenuItem_Click_003Ed__4 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
								return;
							}
							goto IL_0136;
						}
						_003C_003Es__4 = null;
						MessageBox.Show("上传完成，共计文件：" + _003Cofd_003E5__3.FileNames.Length.ToString());
						end_IL_005e:;
					}
					finally
					{
						if (num < 0 && _003Cofd_003E5__3 != null)
						{
							((IDisposable)_003Cofd_003E5__3).Dispose();
						}
					}
					_003Cofd_003E5__3 = null;
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cnode_003E5__1 = null;
					_003CgroupFile_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cnode_003E5__1 = null;
				_003CgroupFile_003E5__2 = null;
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

		private MqttSyncClient mqttSyncClient;

		private HslCancelToken uploadCacel = null;

		private HslCancelToken downloadCacel = null;

		private int threadlength = 20;

		private Random random = new Random();

		private int upSuccess = 0;

		private int downSuccess = 0;

		private int deleteSuccess = 0;

		private IContainer components = null;

		private Panel panel1;

		private Panel panel2;

		private GroupBox groupBox1;

		private ProgressBar progressBar1;

		private Label label7;

		private Button button_upload;

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

		private Button button5;

		private GroupBox groupBox2;

		private TextBox textBox_download_fileName;

		private Label label16;

		private ProgressBar progressBar2;

		private Label label12;

		private Button button_download;

		private TextBox textBox_upload_tag;

		private Label label31;

		private TextBox textBox_upload_group;

		private Label label28;

		private Button button6;

		private Label label9;

		private Label label10;

		private UserControlHead userControlHead1;

		private Button button9;

		private Button button10;

		private TextBox textBox_show_group;

		private Label label4;

		private TextBox textBox1;

		private Label label1;

		private TextBox textBox10;

		private Label label3;

		private TextBox textBox9;

		private Label label19;

		private Button button1;

		private Button button7;

		private TextBox textBox2;

		private Label label20;

		private TextBox textBox4;

		private Label label21;

		private TextBox textBox5;

		private Label label2;

		private TextBox textBox6;

		private Label label5;

		private ContextMenuStrip contextMenuStrip1;

		private GroupBox groupBox5;

		private Label label13;

		private ToolStripMenuItem 下载文件ToolStripMenuItem;

		private ToolStripMenuItem 删除文件ToolStripMenuItem;

		private Button button8;

		private Label label15;

		private Label label14;

		private ContextMenuStrip contextMenuStrip2;

		private ToolStripMenuItem 删除目录ToolStripMenuItem;

		private ToolStripMenuItem 全部下载ToolStripMenuItem;

		private ToolStripMenuItem 批量上传ToolStripMenuItem;

		private Label label17;

		private Button button11;

		private Button button12;

		private CheckBox checkBox_rsa;

		private Button button_upload_cancel;

		private Button button_download_cancel;

		public FormMqttFileClient()
		{
			InitializeComponent();
		}

		private void FormFileClient_Load(object sender, EventArgs e)
		{
			ImageList imageList = new ImageList();
			imageList.Images.Add("VirtualMachine", Resources.VirtualMachine);
			imageList.Images.Add("Class_489", Resources.Class_489);
			imageList.Images.Add("Enum_582", Resources.Enum_582);
			imageList.Images.Add("brackets_Square_16xMD", Resources.brackets_Square_16xMD);
			imageList.Images.Add("Method_636", Resources.Method_636);
			imageList.Images.Add("Module_648", Resources.Module_648);
			imageList.Images.Add("Structure_507", Resources.Structure_507);
			imageList.Images.Add("loading", Resources.loading);
			imageList.Images.Add("file", Resources.file);
			imageList.Images.Add("dll", Resources.dll);
			imageList.Images.Add("exe", Resources.exe);
			imageList.Images.Add("xml", Resources.xml);
			imageList.Images.Add("png", Resources.png);
			imageList.Images.Add("doc", Resources.doc);
			imageList.Images.Add("chm", Resources.chm);
			imageList.Images.Add("ppt", Resources.ppt);
			imageList.Images.Add("xls", Resources.xls);
			imageList.Images.Add("vsd", Resources.vsd);
			imageList.Images.Add("pdf", Resources.pdf);
			imageList.Images.Add("ttf", Resources.ttf);
			imageList.Images.Add("txt", Resources.txt);
			imageList.Images.Add("js", Resources.js);
			imageList.Images.Add("jsp", Resources.jsp);
			imageList.Images.Add("msi", Resources.msi);
			imageList.Images.Add("rar", Resources.rar);
			imageList.Images.Add("sql", Resources.sql);
			imageList.Images.Add("cs", Resources.cs);
			imageList.Images.Add("java", Resources.java);
			imageList.Images.Add("py", Resources.py);
			imageList.Images.Add("css", Resources.css);
			imageList.Images.Add("vdo", Resources.vdo);
			imageList.Images.Add("wav", Resources.wav);
			treeView1.ImageList = imageList;
			treeView1.Nodes[0].ImageKey = "VirtualMachine";
			treeView1.Nodes[0].SelectedImageKey = "VirtualMachine";
		}

		[AsyncStateMachine(typeof(_003Cbutton7_Click_1_003Ed__3))]
		[DebuggerStepThrough]
		private void button7_Click_1(object sender, EventArgs e)
		{
			_003Cbutton7_Click_1_003Ed__3 stateMachine = new _003Cbutton7_Click_1_003Ed__3();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003C批量上传ToolStripMenuItem_Click_003Ed__4))]
		[DebuggerStepThrough]
		private void 批量上传ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_003C批量上传ToolStripMenuItem_Click_003Ed__4 stateMachine = new _003C批量上传ToolStripMenuItem_Click_003Ed__4();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
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

		[AsyncStateMachine(typeof(_003Cbutton_upload_Click_003Ed__7))]
		[DebuggerStepThrough]
		private void button_upload_Click(object sender, EventArgs e)
		{
			_003Cbutton_upload_Click_003Ed__7 stateMachine = new _003Cbutton_upload_Click_003Ed__7();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CUploadFlieExample_003Ed__8))]
		[DebuggerStepThrough]
		private Task<OperateResult> UploadFlieExample()
		{
			_003CUploadFlieExample_003Ed__8 stateMachine = new _003CUploadFlieExample_003Ed__8();
			stateMachine._003C_003Et__builder = AsyncTaskMethodBuilder<OperateResult>.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
			return stateMachine._003C_003Et__builder.Task;
		}

		private void button_upload_cancel_Click(object sender, EventArgs e)
		{
			if (uploadCacel != null)
			{
				uploadCacel.IsCancelled = true;
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
				label10.Text = SoftBasic.GetSizeDescription(sended) + "/" + SoftBasic.GetSizeDescription(totle);
				progressBar1.Value = value;
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			Process.Start(Application.StartupPath + "\\Files");
		}

		[AsyncStateMachine(typeof(_003C下载文件ToolStripMenuItem_Click_003Ed__12))]
		[DebuggerStepThrough]
		private void 下载文件ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_003C下载文件ToolStripMenuItem_Click_003Ed__12 stateMachine = new _003C下载文件ToolStripMenuItem_Click_003Ed__12();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003C全部下载ToolStripMenuItem_Click_003Ed__13))]
		[DebuggerStepThrough]
		private void 全部下载ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_003C全部下载ToolStripMenuItem_Click_003Ed__13 stateMachine = new _003C全部下载ToolStripMenuItem_Click_003Ed__13();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton_download_Click_003Ed__15))]
		[DebuggerStepThrough]
		private void button_download_Click(object sender, EventArgs e)
		{
			_003Cbutton_download_Click_003Ed__15 stateMachine = new _003Cbutton_download_Click_003Ed__15();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CDownloadFileExample_003Ed__16))]
		[DebuggerStepThrough]
		private Task DownloadFileExample()
		{
			_003CDownloadFileExample_003Ed__16 stateMachine = new _003CDownloadFileExample_003Ed__16();
			stateMachine._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
			return stateMachine._003C_003Et__builder.Task;
		}

		private void button_download_cancel_Click(object sender, EventArgs e)
		{
			if (downloadCacel != null)
			{
				downloadCacel.IsCancelled = true;
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
				label9.Text = SoftBasic.GetSizeDescription(receive) + "/" + SoftBasic.GetSizeDescription(totle);
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton10_Click_003Ed__19))]
		[DebuggerStepThrough]
		private void button10_Click(object sender, EventArgs e)
		{
			_003Cbutton10_Click_003Ed__19 stateMachine = new _003Cbutton10_Click_003Ed__19();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003C删除文件ToolStripMenuItem_Click_003Ed__20))]
		[DebuggerStepThrough]
		private void 删除文件ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_003C删除文件ToolStripMenuItem_Click_003Ed__20 stateMachine = new _003C删除文件ToolStripMenuItem_Click_003Ed__20();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton5_Click_003Ed__21))]
		[DebuggerStepThrough]
		private void button5_Click(object sender, EventArgs e)
		{
			_003Cbutton5_Click_003Ed__21 stateMachine = new _003Cbutton5_Click_003Ed__21();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003C删除目录ToolStripMenuItem_Click_003Ed__22))]
		[DebuggerStepThrough]
		private void 删除目录ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_003C删除目录ToolStripMenuItem_Click_003Ed__22 stateMachine = new _003C删除目录ToolStripMenuItem_Click_003Ed__22();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton9_Click_003Ed__23))]
		[DebuggerStepThrough]
		private void button9_Click(object sender, EventArgs e)
		{
			_003Cbutton9_Click_003Ed__23 stateMachine = new _003Cbutton9_Click_003Ed__23();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton11_Click_003Ed__24))]
		[DebuggerStepThrough]
		private void button11_Click(object sender, EventArgs e)
		{
			_003Cbutton11_Click_003Ed__24 stateMachine = new _003Cbutton11_Click_003Ed__24();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cbutton12_Click_003Ed__25))]
		[DebuggerStepThrough]
		private void button12_Click(object sender, EventArgs e)
		{
			_003Cbutton12_Click_003Ed__25 stateMachine = new _003Cbutton12_Click_003Ed__25();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void FillNodeByFactoryGroupId(TreeNode root, OperateResult<string[]> read)
		{
			root.Nodes.Clear();
			if (read.IsSuccess)
			{
				string[] content = read.Content;
				foreach (string text in content)
				{
					TreeNode treeNode = new TreeNode(text);
					treeNode.Tag = text;
					treeNode.Nodes.Add(new TreeNode("loading...")
					{
						ImageKey = "loading",
						SelectedImageKey = "loading"
					});
					root.Nodes.Add(treeNode);
					treeNode.ImageKey = "Class_489";
					treeNode.SelectedImageKey = "Class_489";
				}
			}
			else
			{
				MessageBox.Show(read.ToMessageShowString());
			}
		}

		private string GetFileExtensionIconKey(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				return "file";
			}
			if (fileName.LastIndexOf('.') < 0 && fileName.LastIndexOf('.') == fileName.Length - 1)
			{
				return "file";
			}
			string a = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
			if (a == "doc" || a == "docx")
			{
				return "doc";
			}
			if (a == "xls" || a == "xlsx")
			{
				return "xls";
			}
			if (a == "dll")
			{
				return "dll";
			}
			if (a == "exe")
			{
				return "exe";
			}
			if (a == "xml")
			{
				return "xml";
			}
			if (a == "png" || a == "bmp" || a == "jpg" || a == "jpeg" || a == "gif")
			{
				return "png";
			}
			if (a == "chm")
			{
				return "chm";
			}
			if (a == "ppt" || a == "pptx")
			{
				return "ppt";
			}
			if (a == "vsd")
			{
				return "vsd";
			}
			if (a == "pdf")
			{
				return "pdf";
			}
			if (a == "ttf")
			{
				return "ttf";
			}
			if (a == "txt")
			{
				return "txt";
			}
			if (a == "js")
			{
				return "js";
			}
			if (a == "jsp")
			{
				return "jsp";
			}
			if (a == "msi")
			{
				return "msi";
			}
			if (a == "rar" || a == "tar" || a == "zip" || a == "iso" || a == "7z")
			{
				return "rar";
			}
			if (a == "sql")
			{
				return "sql";
			}
			if (a == "cs")
			{
				return "cs";
			}
			if (a == "java")
			{
				return "java";
			}
			if (a == "py")
			{
				return "py";
			}
			if (a == "css")
			{
				return "css";
			}
			if (a == "avi" || a == "mov" || a == "rmvb" || a == "rm" || a == "flv" || a == "mp4" || a == "3gp")
			{
				return "vdo";
			}
			if (a == "wav" || a == "mp3" || a == "wma" || a == "midi")
			{
				return "wav";
			}
			return "file";
		}

		private void FillNodeFilesByFactoryGroupId(TreeNode root, OperateResult<GroupFileItem[]> read)
		{
			if (read.IsSuccess)
			{
				GroupFileItem[] content = read.Content;
				foreach (GroupFileItem groupFileItem in content)
				{
					TreeNode treeNode = new TreeNode(groupFileItem.FileName);
					treeNode.Tag = groupFileItem;
					root.Nodes.Add(treeNode);
					treeNode.ImageKey = GetFileExtensionIconKey(groupFileItem.FileName);
					treeNode.SelectedImageKey = GetFileExtensionIconKey(groupFileItem.FileName);
				}
			}
			else
			{
				MessageBox.Show(read.ToMessageShowString());
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton6_Click_003Ed__29))]
		[DebuggerStepThrough]
		private void button6_Click(object sender, EventArgs e)
		{
			_003Cbutton6_Click_003Ed__29 stateMachine = new _003Cbutton6_Click_003Ed__29();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CtreeView1_BeforeExpand_003Ed__30))]
		[DebuggerStepThrough]
		private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			_003CtreeView1_BeforeExpand_003Ed__30 stateMachine = new _003CtreeView1_BeforeExpand_003Ed__30();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private string GetGroupsFromNode(TreeNode node)
		{
			List<string> list = new List<string>();
			while (node != null)
			{
				list.Add(node.Text);
				node = node.Parent;
			}
			list.Reverse();
			list.RemoveAt(0);
			return GetGroupsString(list.ToArray());
		}

		private string GetGroupsString(string[] groups)
		{
			if (groups == null)
			{
				return string.Empty;
			}
			if (groups.Length == 0)
			{
				return string.Empty;
			}
			string text = groups[0];
			for (int i = 1; i < groups.Length; i++)
			{
				text = text + "/" + groups[i];
			}
			return text;
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			TreeNode node = e.Node;
			if (node.Tag != null)
			{
				GroupFileItem groupFileItem = node.Tag as GroupFileItem;
				if (groupFileItem != null)
				{
					textBox_show_group.Text = GetGroupsFromNode(node.Parent);
					textBox_file_fileName.Text = groupFileItem.FileName;
					textBox_file_fileSize.Text = groupFileItem.FileSize.ToString();
					textBox_file_date.Text = groupFileItem.UploadTime.ToString();
					textBox_file_dowloadTimes.Text = groupFileItem.DownloadTimes.ToString();
					textBox_file_upload.Text = groupFileItem.Owner;
					textBox_file_tag.Text = groupFileItem.Description;
				}
			}
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox4.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlCompanyID, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlUserName, textBox9.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPassword, textBox10.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox4.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox1.Text = element.Attribute(DemoDeviceList.XmlCompanyID).Value;
			textBox9.Text = element.Attribute(DemoDeviceList.XmlUserName).Value;
			textBox10.Text = element.Attribute(DemoDeviceList.XmlPassword).Value;
		}

		private void userControlHead1_SaveConnectEvent_1(object sender, EventArgs e)
		{
			userControlHead1_SaveConnectEvent(sender, e);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			mqttSyncClient.ConnectClose();
			button7.Enabled = true;
			button1.Enabled = false;
		}

		private void treeView1_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				treeView1.SelectedNode = treeView1.GetNodeAt(e.Location);
				TreeNode selectedNode = treeView1.SelectedNode;
				if (selectedNode.Tag != null)
				{
					GroupFileItem groupFileItem = selectedNode.Tag as GroupFileItem;
					if (groupFileItem != null)
					{
						contextMenuStrip1.Show(treeView1, e.Location);
					}
					else
					{
						contextMenuStrip2.Show(treeView1, e.Location);
					}
				}
				else
				{
					contextMenuStrip2.Show(treeView1, e.Location);
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
			System.Windows.Forms.TreeNode treeNode = new System.Windows.Forms.TreeNode("文件列表");
			panel1 = new System.Windows.Forms.Panel();
			checkBox_rsa = new System.Windows.Forms.CheckBox();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			textBox10 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox9 = new System.Windows.Forms.TextBox();
			label19 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			textBox2 = new System.Windows.Forms.TextBox();
			label20 = new System.Windows.Forms.Label();
			textBox4 = new System.Windows.Forms.TextBox();
			label21 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			groupBox4 = new System.Windows.Forms.GroupBox();
			groupBox5 = new System.Windows.Forms.GroupBox();
			label4 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			textBox_show_group = new System.Windows.Forms.TextBox();
			textBox_file_fileName = new System.Windows.Forms.TextBox();
			label23 = new System.Windows.Forms.Label();
			textBox_file_fileSize = new System.Windows.Forms.TextBox();
			label24 = new System.Windows.Forms.Label();
			textBox_file_dowloadTimes = new System.Windows.Forms.TextBox();
			label25 = new System.Windows.Forms.Label();
			textBox_file_date = new System.Windows.Forms.TextBox();
			textBox_file_upload = new System.Windows.Forms.TextBox();
			label32 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			textBox_file_tag = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			button12 = new System.Windows.Forms.Button();
			label17 = new System.Windows.Forms.Label();
			button11 = new System.Windows.Forms.Button();
			textBox6 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			button9 = new System.Windows.Forms.Button();
			textBox_delete_fileName = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			button5 = new System.Windows.Forms.Button();
			groupBox2 = new System.Windows.Forms.GroupBox();
			button_download_cancel = new System.Windows.Forms.Button();
			button8 = new System.Windows.Forms.Button();
			label15 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			textBox5 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			button10 = new System.Windows.Forms.Button();
			label9 = new System.Windows.Forms.Label();
			textBox_download_fileName = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			progressBar2 = new System.Windows.Forms.ProgressBar();
			label12 = new System.Windows.Forms.Label();
			button_download = new System.Windows.Forms.Button();
			groupBox1 = new System.Windows.Forms.GroupBox();
			button_upload_cancel = new System.Windows.Forms.Button();
			label10 = new System.Windows.Forms.Label();
			textBox_upload_tag = new System.Windows.Forms.TextBox();
			label31 = new System.Windows.Forms.Label();
			textBox_upload_group = new System.Windows.Forms.TextBox();
			label28 = new System.Windows.Forms.Label();
			progressBar1 = new System.Windows.Forms.ProgressBar();
			label7 = new System.Windows.Forms.Label();
			button_upload = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			button6 = new System.Windows.Forms.Button();
			treeView1 = new System.Windows.Forms.TreeView();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
			下载文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			删除文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(components);
			删除目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			全部下载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			批量上传ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox4.SuspendLayout();
			groupBox5.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			contextMenuStrip1.SuspendLayout();
			contextMenuStrip2.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(checkBox_rsa);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(textBox10);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox9);
			panel1.Controls.Add(label19);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(button7);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label20);
			panel1.Controls.Add(textBox4);
			panel1.Controls.Add(label21);
			panel1.Location = new System.Drawing.Point(6, 37);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(993, 60);
			panel1.TabIndex = 7;
			checkBox_rsa.AutoSize = true;
			checkBox_rsa.Location = new System.Drawing.Point(712, 4);
			checkBox_rsa.Name = "checkBox_rsa";
			checkBox_rsa.Size = new System.Drawing.Size(212, 21);
			checkBox_rsa.TabIndex = 30;
			checkBox_rsa.Text = "RSA加密 (V10.2.0版本以上服务器)";
			checkBox_rsa.UseVisualStyleBackColor = true;
			textBox1.Location = new System.Drawing.Point(87, 32);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(611, 23);
			textBox1.TabIndex = 29;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(9, 35);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(80, 17);
			label1.TabIndex = 28;
			label1.Text = "客户端标识：";
			textBox10.Location = new System.Drawing.Point(585, 4);
			textBox10.Name = "textBox10";
			textBox10.Size = new System.Drawing.Size(113, 23);
			textBox10.TabIndex = 27;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(521, 7);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(44, 17);
			label3.TabIndex = 26;
			label3.Text = "密码：";
			textBox9.Location = new System.Drawing.Point(418, 4);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(91, 23);
			textBox9.TabIndex = 25;
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(342, 7);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(56, 17);
			label19.TabIndex = 24;
			label19.Text = "用户名：";
			button1.Enabled = false;
			button1.Location = new System.Drawing.Point(808, 27);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 23;
			button1.Text = "断开连接";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			button7.Location = new System.Drawing.Point(708, 27);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(91, 28);
			button7.TabIndex = 22;
			button7.Text = "连接";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click_1);
			textBox2.Location = new System.Drawing.Point(244, 4);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(79, 23);
			textBox2.TabIndex = 21;
			textBox2.Text = "1883";
			label20.AutoSize = true;
			label20.Location = new System.Drawing.Point(190, 7);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(56, 17);
			label20.TabIndex = 20;
			label20.Text = "端口号：";
			textBox4.Location = new System.Drawing.Point(63, 4);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(115, 23);
			textBox4.TabIndex = 19;
			textBox4.Text = "127.0.0.1";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(9, 7);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(56, 17);
			label21.TabIndex = 18;
			label21.Text = "Ip地址：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(groupBox4);
			panel2.Enabled = false;
			panel2.Location = new System.Drawing.Point(6, 102);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(993, 539);
			panel2.TabIndex = 13;
			groupBox4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			groupBox4.Controls.Add(groupBox5);
			groupBox4.Controls.Add(label13);
			groupBox4.Controls.Add(groupBox3);
			groupBox4.Controls.Add(groupBox2);
			groupBox4.Controls.Add(groupBox1);
			groupBox4.Controls.Add(button6);
			groupBox4.Controls.Add(treeView1);
			groupBox4.Location = new System.Drawing.Point(5, 3);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(983, 531);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "浏览服务器文件";
			groupBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox5.Controls.Add(label4);
			groupBox5.Controls.Add(label11);
			groupBox5.Controls.Add(textBox_show_group);
			groupBox5.Controls.Add(textBox_file_fileName);
			groupBox5.Controls.Add(label23);
			groupBox5.Controls.Add(textBox_file_fileSize);
			groupBox5.Controls.Add(label24);
			groupBox5.Controls.Add(textBox_file_dowloadTimes);
			groupBox5.Controls.Add(label25);
			groupBox5.Controls.Add(textBox_file_date);
			groupBox5.Controls.Add(textBox_file_upload);
			groupBox5.Controls.Add(label32);
			groupBox5.Controls.Add(label26);
			groupBox5.Controls.Add(textBox_file_tag);
			groupBox5.Location = new System.Drawing.Point(383, 11);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(594, 141);
			groupBox5.TabIndex = 41;
			groupBox5.TabStop = false;
			groupBox5.Text = "选中文件详细信息";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(7, 23);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(57, 17);
			label4.TabIndex = 38;
			label4.Text = "Group：";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(6, 53);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(56, 17);
			label11.TabIndex = 14;
			label11.Text = "文件名：";
			textBox_show_group.Location = new System.Drawing.Point(106, 20);
			textBox_show_group.Name = "textBox_show_group";
			textBox_show_group.Size = new System.Drawing.Size(481, 23);
			textBox_show_group.TabIndex = 39;
			textBox_file_fileName.Location = new System.Drawing.Point(106, 50);
			textBox_file_fileName.Name = "textBox_file_fileName";
			textBox_file_fileName.Size = new System.Drawing.Size(481, 23);
			textBox_file_fileName.TabIndex = 15;
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(6, 83);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(68, 17);
			label23.TabIndex = 22;
			label23.Text = "文件大小：";
			textBox_file_fileSize.Location = new System.Drawing.Point(106, 80);
			textBox_file_fileSize.Name = "textBox_file_fileSize";
			textBox_file_fileSize.Size = new System.Drawing.Size(135, 23);
			textBox_file_fileSize.TabIndex = 23;
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(259, 83);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(68, 17);
			label24.TabIndex = 24;
			label24.Text = "下载次数：";
			textBox_file_dowloadTimes.Location = new System.Drawing.Point(347, 80);
			textBox_file_dowloadTimes.Name = "textBox_file_dowloadTimes";
			textBox_file_dowloadTimes.Size = new System.Drawing.Size(80, 23);
			textBox_file_dowloadTimes.TabIndex = 25;
			label25.AutoSize = true;
			label25.Location = new System.Drawing.Point(451, 83);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(56, 17);
			label25.TabIndex = 26;
			label25.Text = "上传人：";
			textBox_file_date.Location = new System.Drawing.Point(106, 110);
			textBox_file_date.Name = "textBox_file_date";
			textBox_file_date.Size = new System.Drawing.Size(187, 23);
			textBox_file_date.TabIndex = 31;
			textBox_file_upload.Location = new System.Drawing.Point(521, 80);
			textBox_file_upload.Name = "textBox_file_upload";
			textBox_file_upload.Size = new System.Drawing.Size(66, 23);
			textBox_file_upload.TabIndex = 27;
			label32.AutoSize = true;
			label32.Location = new System.Drawing.Point(6, 113);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(68, 17);
			label32.TabIndex = 30;
			label32.Text = "上传日期：";
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(299, 113);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(44, 17);
			label26.TabIndex = 28;
			label26.Text = "备注：";
			textBox_file_tag.Location = new System.Drawing.Point(399, 110);
			textBox_file_tag.Name = "textBox_file_tag";
			textBox_file_tag.Size = new System.Drawing.Size(188, 23);
			textBox_file_tag.TabIndex = 29;
			label13.AutoSize = true;
			label13.ForeColor = System.Drawing.Color.Gray;
			label13.Location = new System.Drawing.Point(8, 21);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(116, 17);
			label13.TabIndex = 40;
			label13.Text = "右键弹出菜单可操作";
			groupBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			groupBox3.Controls.Add(button12);
			groupBox3.Controls.Add(label17);
			groupBox3.Controls.Add(button11);
			groupBox3.Controls.Add(textBox6);
			groupBox3.Controls.Add(label5);
			groupBox3.Controls.Add(button9);
			groupBox3.Controls.Add(textBox_delete_fileName);
			groupBox3.Controls.Add(label8);
			groupBox3.Controls.Add(button5);
			groupBox3.Location = new System.Drawing.Point(383, 425);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(594, 100);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "文件删除";
			button12.Location = new System.Drawing.Point(156, 41);
			button12.Name = "button12";
			button12.Size = new System.Drawing.Size(75, 28);
			button12.TabIndex = 26;
			button12.Text = "子目录";
			button12.UseVisualStyleBackColor = true;
			button12.Click += new System.EventHandler(button12_Click);
			label17.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label17.Location = new System.Drawing.Point(344, 47);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(241, 50);
			label17.TabIndex = 25;
			label17.Text = "0";
			button11.Location = new System.Drawing.Point(237, 41);
			button11.Name = "button11";
			button11.Size = new System.Drawing.Size(101, 28);
			button11.TabIndex = 24;
			button11.Text = "目录文件信息";
			button11.UseVisualStyleBackColor = true;
			button11.Click += new System.EventHandler(button11_Click);
			textBox6.Location = new System.Drawing.Point(63, 17);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(178, 23);
			textBox6.TabIndex = 23;
			textBox6.Text = "Files/Personal/Admin";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(6, 20);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(57, 17);
			label5.TabIndex = 22;
			label5.Text = "Group：";
			button9.Location = new System.Drawing.Point(67, 41);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(83, 28);
			button9.TabIndex = 18;
			button9.Text = "删除目录";
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			textBox_delete_fileName.Location = new System.Drawing.Point(321, 17);
			textBox_delete_fileName.Name = "textBox_delete_fileName";
			textBox_delete_fileName.Size = new System.Drawing.Size(266, 23);
			textBox_delete_fileName.TabIndex = 17;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(247, 20);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(56, 17);
			label8.TabIndex = 16;
			label8.Text = "文件名：";
			button5.Location = new System.Drawing.Point(7, 41);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(54, 28);
			button5.TabIndex = 7;
			button5.Text = "删除";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			groupBox2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox2.Controls.Add(button_download_cancel);
			groupBox2.Controls.Add(button8);
			groupBox2.Controls.Add(label15);
			groupBox2.Controls.Add(label14);
			groupBox2.Controls.Add(textBox5);
			groupBox2.Controls.Add(label2);
			groupBox2.Controls.Add(button10);
			groupBox2.Controls.Add(label9);
			groupBox2.Controls.Add(textBox_download_fileName);
			groupBox2.Controls.Add(label16);
			groupBox2.Controls.Add(progressBar2);
			groupBox2.Controls.Add(label12);
			groupBox2.Controls.Add(button_download);
			groupBox2.Location = new System.Drawing.Point(383, 296);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(594, 128);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "文件下载";
			button_download_cancel.Enabled = false;
			button_download_cancel.Location = new System.Drawing.Point(517, 74);
			button_download_cancel.Name = "button_download_cancel";
			button_download_cancel.Size = new System.Drawing.Size(70, 25);
			button_download_cancel.TabIndex = 25;
			button_download_cancel.Text = "取消";
			button_download_cancel.UseVisualStyleBackColor = true;
			button_download_cancel.Click += new System.EventHandler(button_download_cancel_Click);
			button8.Location = new System.Drawing.Point(517, 101);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(70, 25);
			button8.TabIndex = 24;
			button8.Text = "打开目录";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(78, 104);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(65, 17);
			label15.TabIndex = 23;
			label15.Text = "等待下载...";
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(7, 104);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(44, 17);
			label14.TabIndex = 22;
			label14.Text = "状态：";
			textBox5.Location = new System.Drawing.Point(81, 21);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(430, 23);
			textBox5.TabIndex = 21;
			textBox5.Text = "Files/Personal/Admin";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(6, 24);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(57, 17);
			label2.TabIndex = 20;
			label2.Text = "Group：";
			button10.Location = new System.Drawing.Point(517, 19);
			button10.Name = "button10";
			button10.Size = new System.Drawing.Size(70, 25);
			button10.TabIndex = 19;
			button10.Text = "是否存在";
			button10.UseVisualStyleBackColor = true;
			button10.Click += new System.EventHandler(button10_Click);
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(417, 81);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(27, 17);
			label9.TabIndex = 18;
			label9.Text = "0/0";
			textBox_download_fileName.Location = new System.Drawing.Point(80, 52);
			textBox_download_fileName.Name = "textBox_download_fileName";
			textBox_download_fileName.Size = new System.Drawing.Size(431, 23);
			textBox_download_fileName.TabIndex = 17;
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(6, 55);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(56, 17);
			label16.TabIndex = 16;
			label16.Text = "文件名：";
			progressBar2.Location = new System.Drawing.Point(80, 81);
			progressBar2.Name = "progressBar2";
			progressBar2.Size = new System.Drawing.Size(331, 17);
			progressBar2.TabIndex = 9;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(6, 81);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(44, 17);
			label12.TabIndex = 8;
			label12.Text = "进度：";
			button_download.Location = new System.Drawing.Point(517, 47);
			button_download.Name = "button_download";
			button_download.Size = new System.Drawing.Size(70, 25);
			button_download.TabIndex = 7;
			button_download.Text = "下载";
			button_download.UseVisualStyleBackColor = true;
			button_download.Click += new System.EventHandler(button_download_Click);
			groupBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			groupBox1.Controls.Add(button_upload_cancel);
			groupBox1.Controls.Add(label10);
			groupBox1.Controls.Add(textBox_upload_tag);
			groupBox1.Controls.Add(label31);
			groupBox1.Controls.Add(textBox_upload_group);
			groupBox1.Controls.Add(label28);
			groupBox1.Controls.Add(progressBar1);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(button_upload);
			groupBox1.Controls.Add(button2);
			groupBox1.Controls.Add(textBox3);
			groupBox1.Controls.Add(label6);
			groupBox1.Location = new System.Drawing.Point(383, 154);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(594, 138);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "文件上传";
			button_upload_cancel.Enabled = false;
			button_upload_cancel.Location = new System.Drawing.Point(518, 83);
			button_upload_cancel.Name = "button_upload_cancel";
			button_upload_cancel.Size = new System.Drawing.Size(70, 28);
			button_upload_cancel.TabIndex = 27;
			button_upload_cancel.Text = "取消";
			button_upload_cancel.UseVisualStyleBackColor = true;
			button_upload_cancel.Click += new System.EventHandler(button_upload_cancel_Click);
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(464, 113);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(27, 17);
			label10.TabIndex = 26;
			label10.Text = "0/0";
			textBox_upload_tag.Location = new System.Drawing.Point(80, 84);
			textBox_upload_tag.Name = "textBox_upload_tag";
			textBox_upload_tag.Size = new System.Drawing.Size(431, 23);
			textBox_upload_tag.TabIndex = 25;
			textBox_upload_tag.Text = "test test for example it is import";
			label31.AutoSize = true;
			label31.Location = new System.Drawing.Point(7, 87);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(44, 17);
			label31.TabIndex = 24;
			label31.Text = "备注：";
			textBox_upload_group.Location = new System.Drawing.Point(80, 55);
			textBox_upload_group.Name = "textBox_upload_group";
			textBox_upload_group.Size = new System.Drawing.Size(431, 23);
			textBox_upload_group.TabIndex = 19;
			textBox_upload_group.Text = "Files/Personal/Admin";
			label28.AutoSize = true;
			label28.Location = new System.Drawing.Point(6, 58);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(57, 17);
			label28.TabIndex = 18;
			label28.Text = "Group：";
			progressBar1.Location = new System.Drawing.Point(80, 113);
			progressBar1.Name = "progressBar1";
			progressBar1.Size = new System.Drawing.Size(378, 17);
			progressBar1.TabIndex = 9;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(6, 113);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(44, 17);
			label7.TabIndex = 8;
			label7.Text = "进度：";
			button_upload.Location = new System.Drawing.Point(517, 51);
			button_upload.Name = "button_upload";
			button_upload.Size = new System.Drawing.Size(70, 28);
			button_upload.TabIndex = 7;
			button_upload.Text = "上传";
			button_upload.UseVisualStyleBackColor = true;
			button_upload.Click += new System.EventHandler(button_upload_Click);
			button2.Location = new System.Drawing.Point(517, 20);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(70, 28);
			button2.TabIndex = 6;
			button2.Text = "选择";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			textBox3.Location = new System.Drawing.Point(80, 25);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(431, 23);
			textBox3.TabIndex = 5;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(6, 28);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(68, 17);
			label6.TabIndex = 4;
			label6.Text = "文件路径：";
			button6.Location = new System.Drawing.Point(300, 15);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(74, 23);
			button6.TabIndex = 32;
			button6.Text = "刷新";
			button6.UseVisualStyleBackColor = true;
			button6.Click += new System.EventHandler(button6_Click);
			treeView1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			treeView1.Location = new System.Drawing.Point(9, 42);
			treeView1.Name = "treeView1";
			treeNode.Name = "节点0";
			treeNode.Text = "文件列表";
			treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[1]
			{
				treeNode
			});
			treeView1.Size = new System.Drawing.Size(368, 483);
			treeView1.TabIndex = 0;
			treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(treeView1_BeforeExpand);
			treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);
			treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(treeView1_MouseClick);
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.HelpLink = "https://www.cnblogs.com/dathlin/p/7746113.html";
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "MQTT - File";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 14;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
			{
				下载文件ToolStripMenuItem,
				删除文件ToolStripMenuItem
			});
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
			下载文件ToolStripMenuItem.Name = "下载文件ToolStripMenuItem";
			下载文件ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			下载文件ToolStripMenuItem.Text = "下载文件";
			下载文件ToolStripMenuItem.Click += new System.EventHandler(下载文件ToolStripMenuItem_Click);
			删除文件ToolStripMenuItem.Name = "删除文件ToolStripMenuItem";
			删除文件ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			删除文件ToolStripMenuItem.Text = "删除文件";
			删除文件ToolStripMenuItem.Click += new System.EventHandler(删除文件ToolStripMenuItem_Click);
			contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[3]
			{
				删除目录ToolStripMenuItem,
				全部下载ToolStripMenuItem,
				批量上传ToolStripMenuItem
			});
			contextMenuStrip2.Name = "contextMenuStrip2";
			contextMenuStrip2.Size = new System.Drawing.Size(125, 70);
			删除目录ToolStripMenuItem.Name = "删除目录ToolStripMenuItem";
			删除目录ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			删除目录ToolStripMenuItem.Text = "删除目录";
			删除目录ToolStripMenuItem.Click += new System.EventHandler(删除目录ToolStripMenuItem_Click);
			全部下载ToolStripMenuItem.Name = "全部下载ToolStripMenuItem";
			全部下载ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			全部下载ToolStripMenuItem.Text = "全部下载";
			全部下载ToolStripMenuItem.Click += new System.EventHandler(全部下载ToolStripMenuItem_Click);
			批量上传ToolStripMenuItem.Name = "批量上传ToolStripMenuItem";
			批量上传ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			批量上传ToolStripMenuItem.Text = "批量上传";
			批量上传ToolStripMenuItem.Click += new System.EventHandler(批量上传ToolStripMenuItem_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormMqttFileClient";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "文件客户端窗口";
			base.Load += new System.EventHandler(FormFileClient_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			contextMenuStrip1.ResumeLayout(false);
			contextMenuStrip2.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
