using HslCommunication;
using HslCommunication.Core.Net;
using HslCommunication.MQTT;
using HslCommunicationDemo.DemoControl;
using HslCommunicationDemo.Properties;
using HslControls;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HslCommunicationDemo
{
	public class FormHttpClient : HslFormContent
	{
		[CompilerGenerated]
		private sealed class _003CButton1_Click_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormHttpClient _003C_003E4__this;

			private Exception _003Cex_003E5__1;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					if (num != 0)
					{
					}
					try
					{
						TaskAwaiter awaiter;
						if (num != 0)
						{
							_003C_003E4__this.webApiClient = new NetworkWebApiBase(_003C_003E4__this.textBox1.Text, int.Parse(_003C_003E4__this.textBox2.Text), _003C_003E4__this.textBox3.Text, _003C_003E4__this.textBox4.Text);
							_003C_003E4__this.panel2.Enabled = true;
							_003C_003E4__this.button1.Enabled = false;
							_003C_003E4__this.button2.Enabled = true;
							_003C_003E4__this.webApiClient.UseHttps = _003C_003E4__this.checkBox1.Checked;
							_003C_003E4__this.webApiClient.UseEncodingISO = _003C_003E4__this.checkBox2.Checked;
							awaiter = _003C_003E4__this.MqttRpcApiRefresh(_003C_003E4__this.treeView1.Nodes[0]).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CButton1_Click_003Ed__2 stateMachine = this;
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
					}
					catch (Exception ex)
					{
						Exception ex2 = _003Cex_003E5__1 = ex;
						MessageBox.Show("Input Data is wrong! please int again!" + Environment.NewLine + _003Cex_003E5__1.Message);
					}
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
		private sealed class _003CMqttRpcApiRefresh_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public TreeNode rootNode;

			public FormHttpClient _003C_003E4__this;

			private MqttRpcApiInfo[] _003C_003Es__1;

			private MqttRpcApiInfo[] _003C_003Es__2;

			private int _003C_003Es__3;

			private MqttRpcApiInfo _003Citem_003E5__4;

			private TaskAwaiter<MqttRpcApiInfo[]> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<MqttRpcApiInfo[]> awaiter;
					if (num != 0)
					{
						rootNode.Nodes.Clear();
						awaiter = Task.Run(() => _003C_003E4__this.ReadMqttRpcApiInfo2()).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CMqttRpcApiRefresh_003Ed__18 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<MqttRpcApiInfo[]>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__1 = awaiter.GetResult();
					_003C_003E4__this.mqttRpcApiInfos = _003C_003Es__1;
					_003C_003Es__1 = null;
					if (_003C_003E4__this.mqttRpcApiInfos != null)
					{
						_003C_003Es__2 = _003C_003E4__this.mqttRpcApiInfos;
						for (_003C_003Es__3 = 0; _003C_003Es__3 < _003C_003Es__2.Length; _003C_003Es__3++)
						{
							_003Citem_003E5__4 = _003C_003Es__2[_003C_003Es__3];
							_003C_003E4__this.AddTreeNode(rootNode, _003Citem_003E5__4.ApiTopic, _003Citem_003E5__4.ApiTopic, _003Citem_003E5__4);
							_003Citem_003E5__4 = null;
						}
						_003C_003Es__2 = null;
						rootNode.Expand();
					}
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
		private sealed class _003CReadFromServer_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<OperateResult<string>> _003C_003Et__builder;

			public NetworkWebApiBase webApiBase;

			public HttpMethod httpMethod;

			public string url;

			public string body;

			public FormHttpClient _003C_003E4__this;

			private HttpRequestMessage _003Crequest_003E5__1;

			private string _003CcontentType_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpResponseMessage _003C_003Es__4;

			private HttpContent _003Ccontent_003E5__5;

			private string _003C_003Es__6;

			private Exception _003Cex_003E5__7;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				OperateResult<string> result;
				try
				{
					if ((uint)num > 1u)
					{
						url = string.Format("{0}://{1}:{2}/{3}", _003C_003E4__this.checkBox1.Checked ? "https" : "http", webApiBase.IpAddress, webApiBase.Port, url.StartsWith("/") ? url.Substring(1) : url);
					}
					try
					{
						if ((uint)num > 1u)
						{
							_003Crequest_003E5__1 = new HttpRequestMessage(httpMethod, url);
						}
						try
						{
							TaskAwaiter<HttpResponseMessage> awaiter;
							switch (num)
							{
							default:
								if (httpMethod != HttpMethod.Get)
								{
									_003Crequest_003E5__1.Content = new StringContent(body);
									_003CcontentType_003E5__2 = _003C_003E4__this.comboBox2.SelectedItem.ToString();
									if (_003CcontentType_003E5__2 != "none")
									{
										_003Crequest_003E5__1.Content.Headers.ContentType = new MediaTypeHeaderValue(_003CcontentType_003E5__2);
									}
									_003CcontentType_003E5__2 = null;
								}
								if (!string.IsNullOrEmpty(_003C_003E4__this.textBox3.Text))
								{
									_003Crequest_003E5__1.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(_003C_003E4__this.textBox3.Text + ":" + _003C_003E4__this.textBox4.Text)));
								}
								awaiter = webApiBase.Client.SendAsync(_003Crequest_003E5__1).GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter;
									_003CReadFromServer_003Ed__17 stateMachine = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
									return;
								}
								goto IL_0235;
							case 0:
								awaiter = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<HttpResponseMessage>);
								num = (_003C_003E1__state = -1);
								goto IL_0235;
							case 1:
								break;
								IL_0235:
								_003C_003Es__4 = awaiter.GetResult();
								_003Cresponse_003E5__3 = _003C_003Es__4;
								_003C_003Es__4 = null;
								break;
							}
							try
							{
								if (num != 1)
								{
									_003Ccontent_003E5__5 = _003Cresponse_003E5__3.Content;
								}
								try
								{
									TaskAwaiter<string> awaiter2;
									if (num != 1)
									{
										_003Cresponse_003E5__3.EnsureSuccessStatusCode();
										awaiter2 = _003Ccontent_003E5__5.ReadAsStringAsync().GetAwaiter();
										if (!awaiter2.IsCompleted)
										{
											num = (_003C_003E1__state = 1);
											_003C_003Eu__2 = awaiter2;
											_003CReadFromServer_003Ed__17 stateMachine = this;
											_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
											return;
										}
									}
									else
									{
										awaiter2 = _003C_003Eu__2;
										_003C_003Eu__2 = default(TaskAwaiter<string>);
										num = (_003C_003E1__state = -1);
									}
									_003C_003Es__6 = awaiter2.GetResult();
									result = OperateResult.CreateSuccessResult(_003C_003Es__6);
								}
								finally
								{
									if (num < 0 && _003Ccontent_003E5__5 != null)
									{
										((IDisposable)_003Ccontent_003E5__5).Dispose();
									}
								}
							}
							finally
							{
								if (num < 0 && _003Cresponse_003E5__3 != null)
								{
									((IDisposable)_003Cresponse_003E5__3).Dispose();
								}
							}
						}
						finally
						{
							if (num < 0 && _003Crequest_003E5__1 != null)
							{
								((IDisposable)_003Crequest_003E5__1).Dispose();
							}
						}
					}
					catch (Exception ex)
					{
						Exception ex2 = _003Cex_003E5__7 = ex;
						result = new OperateResult<string>(_003Cex_003E5__7.Message);
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
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
		private sealed class _003CReadMqttRpcApiInfo_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<MqttRpcApiInfo[]> _003C_003Et__builder;

			public NetworkWebApiBase webApiBase;

			public FormHttpClient _003C_003E4__this;

			private string _003Curl_003E5__1;

			private HttpRequestMessage _003Crequest_003E5__2;

			private HttpResponseMessage _003Cresponse_003E5__3;

			private HttpResponseMessage _003C_003Es__4;

			private HttpContent _003Ccontent_003E5__5;

			private string _003Cresult_003E5__6;

			private string _003C_003Es__7;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				MqttRpcApiInfo[] result;
				try
				{
					if ((uint)num > 1u)
					{
						_003Curl_003E5__1 = string.Format("{0}://{1}:{2}/Apis", _003C_003E4__this.checkBox1.Checked ? "https" : "http", webApiBase.IpAddress, webApiBase.Port);
					}
					try
					{
						if ((uint)num > 1u)
						{
							_003Crequest_003E5__2 = new HttpRequestMessage(new HttpMethod("HSL"), _003Curl_003E5__1);
						}
						try
						{
							TaskAwaiter<HttpResponseMessage> awaiter;
							switch (num)
							{
							default:
								awaiter = webApiBase.Client.SendAsync(_003Crequest_003E5__2).GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter;
									_003CReadMqttRpcApiInfo_003Ed__7 stateMachine = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
									return;
								}
								goto IL_00fa;
							case 0:
								awaiter = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<HttpResponseMessage>);
								num = (_003C_003E1__state = -1);
								goto IL_00fa;
							case 1:
								break;
								IL_00fa:
								_003C_003Es__4 = awaiter.GetResult();
								_003Cresponse_003E5__3 = _003C_003Es__4;
								_003C_003Es__4 = null;
								break;
							}
							try
							{
								if (num != 1)
								{
									_003Ccontent_003E5__5 = _003Cresponse_003E5__3.Content;
								}
								try
								{
									TaskAwaiter<string> awaiter2;
									if (num != 1)
									{
										_003Cresponse_003E5__3.EnsureSuccessStatusCode();
										awaiter2 = _003Ccontent_003E5__5.ReadAsStringAsync().GetAwaiter();
										if (!awaiter2.IsCompleted)
										{
											num = (_003C_003E1__state = 1);
											_003C_003Eu__2 = awaiter2;
											_003CReadMqttRpcApiInfo_003Ed__7 stateMachine = this;
											_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
											return;
										}
									}
									else
									{
										awaiter2 = _003C_003Eu__2;
										_003C_003Eu__2 = default(TaskAwaiter<string>);
										num = (_003C_003E1__state = -1);
									}
									_003C_003Es__7 = awaiter2.GetResult();
									_003Cresult_003E5__6 = _003C_003Es__7;
									_003C_003Es__7 = null;
									result = JArray.Parse(_003Cresult_003E5__6).ToObject<MqttRpcApiInfo[]>();
								}
								finally
								{
									if (num < 0 && _003Ccontent_003E5__5 != null)
									{
										((IDisposable)_003Ccontent_003E5__5).Dispose();
									}
								}
							}
							finally
							{
								if (num < 0 && _003Cresponse_003E5__3 != null)
								{
									((IDisposable)_003Cresponse_003E5__3).Dispose();
								}
							}
						}
						finally
						{
							if (num < 0 && _003Crequest_003E5__2 != null)
							{
								((IDisposable)_003Crequest_003E5__2).Dispose();
							}
						}
					}
					catch
					{
						result = null;
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Curl_003E5__1 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Curl_003E5__1 = null;
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
		private sealed class _003CTreeView1_AfterSelect_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public TreeViewEventArgs e;

			public FormHttpClient _003C_003E4__this;

			private TreeNode _003Cnode_003E5__1;

			private MqttRpcApiInfo _003CapiInfo_003E5__2;

			private OperateResult<string> _003Cread_003E5__3;

			private OperateResult<string> _003C_003Es__4;

			private long[] _003Cdata_003E5__5;

			private int[] _003Cydata_003E5__6;

			private string[] _003Cxdata_003E5__7;

			private int _003Ci_003E5__8;

			private Exception _003Cex_003E5__9;

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
						goto IL_0220;
					}
					_003Cnode_003E5__1 = _003C_003E4__this.treeView1.SelectedNode;
					if (_003Cnode_003E5__1 != null)
					{
						object tag = _003Cnode_003E5__1.Tag;
						_003CapiInfo_003E5__2 = (tag as MqttRpcApiInfo);
						if (_003CapiInfo_003E5__2 != null)
						{
							_003C_003E4__this.textBox9.Text = _003CapiInfo_003E5__2.ApiTopic;
							_003C_003E4__this.textBox5.Text = _003CapiInfo_003E5__2.ExamplePayload;
							_003C_003E4__this.textBox12.Text = _003CapiInfo_003E5__2.CalledCount.ToString();
							_003C_003E4__this.textBox13.Text = _003CapiInfo_003E5__2.SpendTotalTime.ToString("F2");
							_003C_003E4__this.textBox_api_description.Text = _003CapiInfo_003E5__2.Description;
							_003C_003E4__this.textBox_api_sign.Text = _003CapiInfo_003E5__2.MethodSignature;
							if (_003CapiInfo_003E5__2.HttpMethod.ToUpper() == "GET")
							{
								_003C_003E4__this.comboBox1.SelectedItem = HttpMethod.Get;
							}
							else if (_003CapiInfo_003E5__2.HttpMethod.ToUpper() == "POST")
							{
								_003C_003E4__this.comboBox1.SelectedItem = HttpMethod.Post;
							}
							awaiter = _003C_003E4__this.ReadFromServer(_003C_003E4__this.webApiClient, new HttpMethod("HSL"), "Logs/" + _003CapiInfo_003E5__2.ApiTopic, "").GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CTreeView1_AfterSelect_003Ed__5 stateMachine = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
								return;
							}
							goto IL_0220;
						}
					}
					goto end_IL_0007;
					IL_0220:
					_003C_003Es__4 = awaiter.GetResult();
					_003Cread_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cread_003E5__3.IsSuccess)
					{
						try
						{
							if (!string.IsNullOrEmpty(_003Cread_003E5__3.Content) && _003Cread_003E5__3.Content != "null")
							{
								_003Cdata_003E5__5 = JArray.Parse(_003Cread_003E5__3.Content).ToObject<long[]>().SelectLast(7);
								_003Cydata_003E5__6 = new int[7];
								_003Cxdata_003E5__7 = new string[7];
								_003Ci_003E5__8 = 0;
								while (_003Ci_003E5__8 < 7)
								{
									_003Cydata_003E5__6[_003Ci_003E5__8] = (int)_003Cdata_003E5__5[_003Ci_003E5__8];
									_003Cxdata_003E5__7[_003Ci_003E5__8] = DateTime.Now.AddDays((double)(_003Ci_003E5__8 - 6)).ToString("M-d");
									_003C_003E4__this.hslBarChart1.SetDataSource(_003Cydata_003E5__6, _003Cxdata_003E5__7);
									_003Ci_003E5__8++;
								}
								_003Cdata_003E5__5 = null;
								_003Cydata_003E5__6 = null;
								_003Cxdata_003E5__7 = null;
							}
							else
							{
								_003C_003E4__this.hslBarChart1.SetDataSource(new int[7]);
							}
						}
						catch (Exception ex)
						{
							Exception ex2 = _003Cex_003E5__9 = ex;
							MessageBox.Show(_003Cex_003E5__9.Message + Environment.NewLine + _003Cread_003E5__3.Content);
						}
					}
					_003Cread_003E5__3 = null;
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cnode_003E5__1 = null;
					_003CapiInfo_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cnode_003E5__1 = null;
				_003CapiInfo_003E5__2 = null;
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
		private sealed class _003Cbutton3_Click_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormHttpClient _003C_003E4__this;

			private DateTime _003Cstart_003E5__1;

			private OperateResult<string> _003Cread_003E5__2;

			private string _003Cmsg_003E5__3;

			private OperateResult<string> _003C_003Es__4;

			private MqttRpcApiInfo _003Capi_003E5__5;

			private TaskAwaiter<OperateResult<string>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<string>> awaiter;
					if (num != 0)
					{
						_003Cstart_003E5__1 = DateTime.Now;
						_003C_003E4__this.button3.Enabled = false;
						awaiter = _003C_003E4__this.ReadFromServer(_003C_003E4__this.webApiClient, (HttpMethod)_003C_003E4__this.comboBox1.SelectedItem, _003C_003E4__this.textBox9.Text, _003C_003E4__this.textBox5.Text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton3_Click_003Ed__21 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<string>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter.GetResult();
					_003Cread_003E5__2 = _003C_003Es__4;
					_003C_003Es__4 = null;
					_003C_003E4__this.button3.Enabled = true;
					_003C_003E4__this.textBox7.Text = ((int)(DateTime.Now - _003Cstart_003E5__1).TotalMilliseconds).ToString() + " ms";
					if (!_003Cread_003E5__2.IsSuccess)
					{
						MessageBox.Show("Read Failed:" + _003Cread_003E5__2.ToMessageShowString());
					}
					else
					{
						if (_003C_003E4__this.mqttRpcApiInfos != null)
						{
							_003Capi_003E5__5 = _003C_003E4__this.mqttRpcApiInfos.FirstOrDefault((MqttRpcApiInfo m) => m.ApiTopic == _003C_003E4__this.textBox5.Text);
							if (_003Capi_003E5__5 != null)
							{
								_003Capi_003E5__5.ExamplePayload = _003C_003E4__this.textBox5.Text;
							}
							_003Capi_003E5__5 = null;
						}
						_003Cmsg_003E5__3 = _003Cread_003E5__2.Content;
						if (_003C_003E4__this.radioButton4.Checked)
						{
							try
							{
								_003Cmsg_003E5__3 = XElement.Parse(_003Cmsg_003E5__3).ToString();
							}
							catch
							{
							}
						}
						else if (_003C_003E4__this.radioButton5.Checked)
						{
							try
							{
								_003Cmsg_003E5__3 = JObject.Parse(_003Cmsg_003E5__3).ToString();
							}
							catch
							{
							}
						}
						_003C_003E4__this.textBox8.Text = _003Cmsg_003E5__3;
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cread_003E5__2 = null;
					_003Cmsg_003E5__3 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cread_003E5__2 = null;
				_003Cmsg_003E5__3 = null;
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
		private sealed class _003Cbutton7_Click_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormHttpClient _003C_003E4__this;

			private MqttRpcApiInfo[] _003Capis_003E5__1;

			private MqttRpcApiInfo[] _003C_003Es__2;

			private TaskAwaiter<MqttRpcApiInfo[]> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<MqttRpcApiInfo[]> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<MqttRpcApiInfo[]>);
						num = (_003C_003E1__state = -1);
						goto IL_015e;
					}
					if (!_003C_003E4__this.isTest)
					{
						awaiter = _003C_003E4__this.ReadMqttRpcApiInfo(_003C_003E4__this.webApiClient).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton7_Click_003Ed__14 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_015e;
					}
					_003C_003E4__this.thread_status = 4;
					_003C_003E4__this.failed = 0;
					_003C_003E4__this.thread_time_start = DateTime.Now;
					Thread thread = new Thread(_003C_003E4__this.thread_test1);
					thread.IsBackground = true;
					thread.Start();
					Thread thread2 = new Thread(_003C_003E4__this.thread_test1);
					thread2.IsBackground = true;
					thread2.Start();
					Thread thread3 = new Thread(_003C_003E4__this.thread_test1);
					thread3.IsBackground = true;
					thread3.Start();
					Thread thread4 = new Thread(_003C_003E4__this.thread_test1);
					thread4.IsBackground = true;
					thread4.Start();
					_003C_003E4__this.button7.Enabled = false;
					goto end_IL_0007;
					IL_015e:
					_003C_003Es__2 = awaiter.GetResult();
					_003Capis_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Capis_003E5__1 != null)
					{
						_003C_003E4__this.textBox8.Text = JArray.FromObject(_003Capis_003E5__1).ToString();
					}
					_003Capis_003E5__1 = null;
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
		private sealed class _003Cbutton8_Click_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormHttpClient _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this.MqttRpcApiRefresh(_003C_003E4__this.treeView1.Nodes[0]).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton8_Click_003Ed__19 stateMachine = this;
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
		private sealed class _003Cthread_test1_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public FormHttpClient _003C_003E4__this;

			private string _003Curl_003E5__1;

			private string _003Cbody_003E5__2;

			private int _003Ccount_003E5__3;

			private OperateResult<string> _003Cread_003E5__4;

			private OperateResult<string> _003C_003Es__5;

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
						goto IL_00c8;
					}
					_003Curl_003E5__1 = _003C_003E4__this.textBox9.Text;
					_003Cbody_003E5__2 = _003C_003E4__this.textBox5.Text;
					_003Ccount_003E5__3 = 10000;
					goto IL_0188;
					IL_00c8:
					_003C_003Es__5 = awaiter.GetResult();
					_003Cread_003E5__4 = _003C_003Es__5;
					_003C_003Es__5 = null;
					if (!_003Cread_003E5__4.IsSuccess)
					{
						_003C_003E4__this.failed++;
					}
					else if (_003Cread_003E5__4.Content != (_003Ccount_003E5__3 + 1).ToString())
					{
						_003C_003E4__this.failed++;
					}
					_003Ccount_003E5__3--;
					_003C_003E4__this.successCount++;
					_003Cread_003E5__4 = null;
					goto IL_0188;
					IL_0188:
					if (_003Ccount_003E5__3 > 0)
					{
						awaiter = _003C_003E4__this.webApiClient.PostAsync(_003Curl_003E5__1, new
						{
							id = _003Ccount_003E5__3
						}.ToJsonString()).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cthread_test1_003Ed__15 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_00c8;
					}
					_003C_003E4__this.thread_end();
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Curl_003E5__1 = null;
					_003Cbody_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Curl_003E5__1 = null;
				_003Cbody_003E5__2 = null;
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

		private NetworkWebApiBase webApiClient;

		private MqttRpcApiInfo[] mqttRpcApiInfos;

		private bool isTest = false;

		private int thread_status = 0;

		private int failed = 0;

		private DateTime thread_time_start = DateTime.Now;

		private long successCount = 0L;

		private IContainer components = null;

		private UserControlHead userControlHead1;

		private Panel panel1;

		private Button button1;

		private TextBox textBox4;

		private Label label4;

		private TextBox textBox3;

		private Label label3;

		private TextBox textBox2;

		private Label label2;

		private TextBox textBox1;

		private Label label1;

		private Panel panel4;

		private Button button8;

		private TreeView treeView1;

		private Label label10;

		private Panel panel2;

		private Button button7;

		private TextBox textBox13;

		private Label label14;

		private TextBox textBox12;

		private Label label13;

		private TextBox textBox7;

		private Label label11;

		private Panel panel3;

		private RadioButton radioButton5;

		private RadioButton radioButton3;

		private RadioButton radioButton4;

		private TextBox textBox8;

		private Button button4;

		private Button button3;

		private TextBox textBox5;

		private Label label9;

		private TextBox textBox9;

		private Label label7;

		private Label label5;

		private ComboBox comboBox1;

		private Button button2;

		private Label label6;

		private HslBarChart hslBarChart1;

		private CheckBox checkBox1;

		private ComboBox comboBox2;

		private Label label8;

		private CheckBox checkBox2;

		private TextBox textBox_api_sign;

		private Label label24;

		private Label label15;

		private TextBox textBox_api_description;

		public FormHttpClient()
		{
			InitializeComponent();
		}

		[AsyncStateMachine(typeof(_003CButton1_Click_003Ed__2))]
		[DebuggerStepThrough]
		private void Button1_Click(object sender, EventArgs e)
		{
			_003CButton1_Click_003Ed__2 stateMachine = new _003CButton1_Click_003Ed__2();
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
		}

		private void FormABBWebApi_Load(object sender, EventArgs e)
		{
			if (Program.Language == 1)
			{
				label6.Text = "Body传入参数，如果是GET模式的话，参数需要通过地址传送，例如 GetA?id=5&&name=job";
			}
			else
			{
				label6.Text = "Body input parameters, if it is in GET mode, the parameters need to be transmitted through the address, such as GetA?id=5&&name=job";
			}
			comboBox2.DataSource = new string[6]
			{
				"none",
				"text/plain",
				"application/javascript",
				"application/json",
				"text/html",
				"application/xml"
			};
			button2.Enabled = false;
			panel2.Enabled = false;
			comboBox1.DataSource = new HttpMethod[7]
			{
				HttpMethod.Get,
				HttpMethod.Post,
				HttpMethod.Put,
				HttpMethod.Delete,
				HttpMethod.Options,
				HttpMethod.Head,
				HttpMethod.Trace
			};
			comboBox1.SelectedIndex = 0;
			ImageList imageList = new ImageList();
			imageList.Images.Add("VirtualMachine", Resources.VirtualMachine);
			imageList.Images.Add("Class_489", Resources.Class_489);
			imageList.Images.Add("Enum_582", Resources.Enum_582);
			imageList.Images.Add("brackets_Square_16xMD", Resources.brackets_Square_16xMD);
			imageList.Images.Add("Method_636", Resources.Method_636);
			imageList.Images.Add("Module_648", Resources.Module_648);
			imageList.Images.Add("Structure_507", Resources.Structure_507);
			treeView1.AfterSelect += TreeView1_AfterSelect;
			treeView1.ImageList = imageList;
			treeView1.Nodes[0].ImageKey = "VirtualMachine";
			treeView1.Nodes[0].SelectedImageKey = "VirtualMachine";
		}

		[AsyncStateMachine(typeof(_003CTreeView1_AfterSelect_003Ed__5))]
		[DebuggerStepThrough]
		private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			_003CTreeView1_AfterSelect_003Ed__5 stateMachine = new _003CTreeView1_AfterSelect_003Ed__5();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CReadMqttRpcApiInfo_003Ed__7))]
		[DebuggerStepThrough]
		private Task<MqttRpcApiInfo[]> ReadMqttRpcApiInfo(NetworkWebApiBase webApiBase)
		{
			_003CReadMqttRpcApiInfo_003Ed__7 stateMachine = new _003CReadMqttRpcApiInfo_003Ed__7();
			stateMachine._003C_003Et__builder = AsyncTaskMethodBuilder<MqttRpcApiInfo[]>.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.webApiBase = webApiBase;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
			return stateMachine._003C_003Et__builder.Task;
		}

		private MqttRpcApiInfo[] ReadMqttRpcApiInfo2()
		{
			try
			{
				string requestUriString = string.Format("{0}://{1}:{2}/Apis", checkBox1.Checked ? "https" : "http", webApiClient.IpAddress, webApiClient.Port);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.KeepAlive = false;
				httpWebRequest.AllowAutoRedirect = true;
				httpWebRequest.CookieContainer = new CookieContainer();
				httpWebRequest.Accept = "application/json, text/javascript, */*; q=0.01";
				httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.100 Safari/537.36";
				if (!string.IsNullOrEmpty(textBox3.Text))
				{
					httpWebRequest.Credentials = new NetworkCredential(textBox3.Text, textBox4.Text);
				}
				httpWebRequest.Method = "HSL";
				httpWebRequest.Timeout = 10000;
				string json = "";
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
				{
					json = streamReader.ReadToEnd();
				}
				return JArray.Parse(json).ToObject<MqttRpcApiInfo[]>();
			}
			catch
			{
				return null;
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton7_Click_003Ed__14))]
		[DebuggerStepThrough]
		private void button7_Click(object sender, EventArgs e)
		{
			_003Cbutton7_Click_003Ed__14 stateMachine = new _003Cbutton7_Click_003Ed__14();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003Cthread_test1_003Ed__15))]
		[DebuggerStepThrough]
		private void thread_test1()
		{
			_003Cthread_test1_003Ed__15 stateMachine = new _003Cthread_test1_003Ed__15();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void thread_end()
		{
			if (Interlocked.Decrement(ref thread_status) == 0)
			{
				Invoke((Action)delegate
				{
					label2.Text = successCount.ToString();
					button7.Enabled = true;
					MessageBox.Show("Spend：" + (DateTime.Now - thread_time_start).TotalSeconds.ToString() + Environment.NewLine + " Failed Count：" + failed.ToString());
				});
			}
		}

		[AsyncStateMachine(typeof(_003CReadFromServer_003Ed__17))]
		[DebuggerStepThrough]
		private Task<OperateResult<string>> ReadFromServer(NetworkWebApiBase webApiBase, HttpMethod httpMethod, string url, string body)
		{
			_003CReadFromServer_003Ed__17 stateMachine = new _003CReadFromServer_003Ed__17();
			stateMachine._003C_003Et__builder = AsyncTaskMethodBuilder<OperateResult<string>>.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.webApiBase = webApiBase;
			stateMachine.httpMethod = httpMethod;
			stateMachine.url = url;
			stateMachine.body = body;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
			return stateMachine._003C_003Et__builder.Task;
		}

		[AsyncStateMachine(typeof(_003CMqttRpcApiRefresh_003Ed__18))]
		[DebuggerStepThrough]
		private Task MqttRpcApiRefresh(TreeNode rootNode)
		{
			_003CMqttRpcApiRefresh_003Ed__18 stateMachine = new _003CMqttRpcApiRefresh_003Ed__18();
			stateMachine._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.rootNode = rootNode;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
			return stateMachine._003C_003Et__builder.Task;
		}

		[AsyncStateMachine(typeof(_003Cbutton8_Click_003Ed__19))]
		[DebuggerStepThrough]
		private void button8_Click(object sender, EventArgs e)
		{
			_003Cbutton8_Click_003Ed__19 stateMachine = new _003Cbutton8_Click_003Ed__19();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void AddTreeNode(TreeNode parent, string key, string infactKey, MqttRpcApiInfo mqttRpc)
		{
			int num = key.IndexOf('/');
			if (num <= 0)
			{
				TreeNode treeNode = new TreeNode(key ?? "");
				treeNode.Tag = mqttRpc;
				treeNode.ImageKey = (mqttRpc.IsMethodApi ? "Method_636" : "Enum_582");
				treeNode.SelectedImageKey = (mqttRpc.IsMethodApi ? "Method_636" : "Enum_582");
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
					AddTreeNode(treeNode2, key.Substring(num + 1), infactKey, mqttRpc);
					parent.Nodes.Add(treeNode2);
				}
				else
				{
					AddTreeNode(treeNode2, key.Substring(num + 1), infactKey, mqttRpc);
				}
			}
		}

		[AsyncStateMachine(typeof(_003Cbutton3_Click_003Ed__21))]
		[DebuggerStepThrough]
		private void button3_Click(object sender, EventArgs e)
		{
			_003Cbutton3_Click_003Ed__21 stateMachine = new _003Cbutton3_Click_003Ed__21();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		public override void SaveXmlParameter(XElement element)
		{
			element.SetAttributeValue(DemoDeviceList.XmlIpAddress, textBox1.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPort, textBox2.Text);
			element.SetAttributeValue(DemoDeviceList.XmlUserName, textBox3.Text);
			element.SetAttributeValue(DemoDeviceList.XmlPassword, textBox4.Text);
		}

		public override void LoadXmlParameter(XElement element)
		{
			base.LoadXmlParameter(element);
			textBox1.Text = element.Attribute(DemoDeviceList.XmlIpAddress).Value;
			textBox2.Text = element.Attribute(DemoDeviceList.XmlPort).Value;
			textBox3.Text = element.Attribute(DemoDeviceList.XmlUserName).Value;
			textBox4.Text = element.Attribute(DemoDeviceList.XmlPassword).Value;
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
			System.Windows.Forms.TreeNode treeNode = new System.Windows.Forms.TreeNode("Rpc Apis");
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1 = new System.Windows.Forms.Panel();
			checkBox2 = new System.Windows.Forms.CheckBox();
			label8 = new System.Windows.Forms.Label();
			checkBox1 = new System.Windows.Forms.CheckBox();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			panel4 = new System.Windows.Forms.Panel();
			button8 = new System.Windows.Forms.Button();
			treeView1 = new System.Windows.Forms.TreeView();
			label10 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			comboBox2 = new System.Windows.Forms.ComboBox();
			hslBarChart1 = new HslControls.HslBarChart();
			comboBox1 = new System.Windows.Forms.ComboBox();
			button7 = new System.Windows.Forms.Button();
			textBox13 = new System.Windows.Forms.TextBox();
			label14 = new System.Windows.Forms.Label();
			textBox12 = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			textBox7 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			radioButton5 = new System.Windows.Forms.RadioButton();
			radioButton3 = new System.Windows.Forms.RadioButton();
			radioButton4 = new System.Windows.Forms.RadioButton();
			textBox8 = new System.Windows.Forms.TextBox();
			button4 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			textBox5 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			textBox9 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			textBox_api_sign = new System.Windows.Forms.TextBox();
			label24 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			textBox_api_description = new System.Windows.Forms.TextBox();
			panel1.SuspendLayout();
			panel4.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			SuspendLayout();
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "web api";
			userControlHead1.Size = new System.Drawing.Size(1023, 32);
			userControlHead1.TabIndex = 30;
			userControlHead1.SaveConnectEvent += new System.EventHandler<System.EventArgs>(userControlHead1_SaveConnectEvent_1);
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(checkBox2);
			panel1.Controls.Add(label8);
			panel1.Controls.Add(checkBox1);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(textBox4);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(textBox3);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(textBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new System.Drawing.Point(4, 36);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1015, 56);
			panel1.TabIndex = 31;
			checkBox2.AutoSize = true;
			checkBox2.Location = new System.Drawing.Point(134, 31);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new System.Drawing.Size(124, 21);
			checkBox2.TabIndex = 21;
			checkBox2.Text = "UseEncodingISO";
			checkBox2.UseVisualStyleBackColor = true;
			label8.AutoSize = true;
			label8.ForeColor = System.Drawing.Color.Fuchsia;
			label8.Location = new System.Drawing.Point(333, 36);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(208, 17);
			label8.TabIndex = 20;
			label8.Text = "if use https, the port is default 443";
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(338, 14);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(80, 21);
			checkBox1.TabIndex = 19;
			checkBox1.Text = "UseHttps";
			checkBox1.UseVisualStyleBackColor = true;
			button2.Location = new System.Drawing.Point(861, 11);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(93, 25);
			button2.TabIndex = 18;
			button2.Text = "close";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(753, 11);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(93, 25);
			button1.TabIndex = 17;
			button1.Text = "open";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1_Click);
			textBox4.Location = new System.Drawing.Point(635, 12);
			textBox4.Name = "textBox4";
			textBox4.Size = new System.Drawing.Size(97, 23);
			textBox4.TabIndex = 16;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(568, 15);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(65, 17);
			label4.TabIndex = 15;
			label4.Text = "password";
			textBox3.Location = new System.Drawing.Point(479, 12);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(83, 23);
			textBox3.TabIndex = 14;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(433, 15);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(43, 17);
			label3.TabIndex = 13;
			label3.Text = "Name";
			textBox2.Location = new System.Drawing.Point(269, 5);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(51, 23);
			textBox2.TabIndex = 12;
			textBox2.Text = "80";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(229, 8);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(32, 17);
			label2.TabIndex = 11;
			label2.Text = "Port";
			textBox1.Location = new System.Drawing.Point(92, 5);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(125, 23);
			textBox1.TabIndex = 10;
			textBox1.Text = "127.0.0.1";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(17, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(72, 17);
			label1.TabIndex = 9;
			label1.Text = "Ip Address";
			panel4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel4.Controls.Add(button8);
			panel4.Controls.Add(treeView1);
			panel4.Controls.Add(label10);
			panel4.Location = new System.Drawing.Point(4, 97);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(259, 534);
			panel4.TabIndex = 33;
			button8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button8.Location = new System.Drawing.Point(180, 2);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(75, 23);
			button8.TabIndex = 2;
			button8.Text = "刷新";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			treeView1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			treeView1.Location = new System.Drawing.Point(3, 28);
			treeView1.Name = "treeView1";
			treeNode.Name = "节点0";
			treeNode.Text = "Rpc Apis";
			treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[1]
			{
				treeNode
			});
			treeView1.Size = new System.Drawing.Size(251, 499);
			treeView1.TabIndex = 1;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(5, 6);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(140, 17);
			label10.TabIndex = 0;
			label10.Text = "Api List: (RPC 接口列表)";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(textBox_api_sign);
			panel2.Controls.Add(label24);
			panel2.Controls.Add(label15);
			panel2.Controls.Add(textBox_api_description);
			panel2.Controls.Add(comboBox2);
			panel2.Controls.Add(hslBarChart1);
			panel2.Controls.Add(comboBox1);
			panel2.Controls.Add(button7);
			panel2.Controls.Add(textBox13);
			panel2.Controls.Add(label14);
			panel2.Controls.Add(textBox12);
			panel2.Controls.Add(label13);
			panel2.Controls.Add(textBox7);
			panel2.Controls.Add(label11);
			panel2.Controls.Add(panel3);
			panel2.Controls.Add(textBox8);
			panel2.Controls.Add(button4);
			panel2.Controls.Add(button3);
			panel2.Controls.Add(textBox5);
			panel2.Controls.Add(label9);
			panel2.Controls.Add(textBox9);
			panel2.Controls.Add(label7);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(label6);
			panel2.Location = new System.Drawing.Point(266, 97);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(753, 534);
			panel2.TabIndex = 34;
			comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox2.FormattingEnabled = true;
			comboBox2.Location = new System.Drawing.Point(217, 271);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new System.Drawing.Size(167, 25);
			comboBox2.TabIndex = 46;
			hslBarChart1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			hslBarChart1.BackColor = System.Drawing.Color.White;
			hslBarChart1.Location = new System.Drawing.Point(420, 121);
			hslBarChart1.Name = "hslBarChart1";
			hslBarChart1.ShowBarValueFormat = "{0}";
			hslBarChart1.Size = new System.Drawing.Size(329, 143);
			hslBarChart1.TabIndex = 45;
			hslBarChart1.Text = "hslBarChart1";
			hslBarChart1.Title = "Called Infomation";
			hslBarChart1.UseGradient = true;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(62, 271);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(69, 25);
			comboBox1.TabIndex = 43;
			button7.Location = new System.Drawing.Point(402, 270);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(119, 28);
			button7.TabIndex = 40;
			button7.Text = "Apis Information";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			textBox13.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			textBox13.Location = new System.Drawing.Point(657, 8);
			textBox13.Name = "textBox13";
			textBox13.ReadOnly = true;
			textBox13.Size = new System.Drawing.Size(91, 23);
			textBox13.TabIndex = 39;
			label14.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(541, 11);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(113, 17);
			label14.TabIndex = 38;
			label14.Text = "Spend Total Time:";
			textBox12.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			textBox12.Location = new System.Drawing.Point(453, 8);
			textBox12.Name = "textBox12";
			textBox12.ReadOnly = true;
			textBox12.Size = new System.Drawing.Size(79, 23);
			textBox12.TabIndex = 37;
			label13.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(357, 11);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(85, 17);
			label13.TabIndex = 36;
			label13.Text = "Called Count:";
			textBox7.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			textBox7.Location = new System.Drawing.Point(667, 270);
			textBox7.Name = "textBox7";
			textBox7.ReadOnly = true;
			textBox7.Size = new System.Drawing.Size(81, 23);
			textBox7.TabIndex = 31;
			label11.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(583, 272);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 30;
			label11.Text = "耗时：";
			panel3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			panel3.Controls.Add(radioButton5);
			panel3.Controls.Add(radioButton3);
			panel3.Controls.Add(radioButton4);
			panel3.Location = new System.Drawing.Point(494, 301);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(184, 28);
			panel3.TabIndex = 26;
			radioButton5.AutoSize = true;
			radioButton5.Location = new System.Drawing.Point(123, 3);
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new System.Drawing.Size(52, 21);
			radioButton5.TabIndex = 28;
			radioButton5.Text = "Json";
			radioButton5.UseVisualStyleBackColor = true;
			radioButton3.AutoSize = true;
			radioButton3.Checked = true;
			radioButton3.Location = new System.Drawing.Point(13, 3);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(50, 21);
			radioButton3.TabIndex = 26;
			radioButton3.TabStop = true;
			radioButton3.Text = "Text";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton4.AutoSize = true;
			radioButton4.Location = new System.Drawing.Point(69, 3);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new System.Drawing.Size(48, 21);
			radioButton4.TabIndex = 27;
			radioButton4.Text = "Xml";
			radioButton4.UseVisualStyleBackColor = true;
			textBox8.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox8.Location = new System.Drawing.Point(62, 341);
			textBox8.Multiline = true;
			textBox8.Name = "textBox8";
			textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox8.Size = new System.Drawing.Size(686, 187);
			textBox8.TabIndex = 18;
			button4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button4.Location = new System.Drawing.Point(678, 301);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(71, 28);
			button4.TabIndex = 17;
			button4.Text = "清空";
			button4.UseVisualStyleBackColor = true;
			button3.Location = new System.Drawing.Point(141, 270);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(70, 28);
			button3.TabIndex = 12;
			button3.Text = "读取";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			textBox5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox5.Location = new System.Drawing.Point(62, 121);
			textBox5.Multiline = true;
			textBox5.Name = "textBox5";
			textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox5.Size = new System.Drawing.Size(352, 145);
			textBox5.TabIndex = 8;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(-1, 121);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(50, 17);
			label9.TabIndex = 11;
			label9.Text = "Body：";
			textBox9.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox9.Location = new System.Drawing.Point(62, 7);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(277, 23);
			textBox9.TabIndex = 9;
			textBox9.Text = "A";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(0, 11);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(39, 17);
			label7.TabIndex = 7;
			label7.Text = "Api：";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(-1, 341);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(68, 17);
			label5.TabIndex = 42;
			label5.Text = "Response:";
			label6.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label6.Location = new System.Drawing.Point(60, 300);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(428, 36);
			label6.TabIndex = 44;
			textBox_api_sign.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_api_sign.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox_api_sign.ForeColor = System.Drawing.Color.Gray;
			textBox_api_sign.Location = new System.Drawing.Point(61, 38);
			textBox_api_sign.Name = "textBox_api_sign";
			textBox_api_sign.ReadOnly = true;
			textBox_api_sign.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_api_sign.Size = new System.Drawing.Size(683, 16);
			textBox_api_sign.TabIndex = 56;
			textBox_api_sign.Text = "[签名]";
			label24.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label24.AutoSize = true;
			label24.ForeColor = System.Drawing.Color.Gray;
			label24.Location = new System.Drawing.Point(-1, 37);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(40, 17);
			label24.TabIndex = 55;
			label24.Text = "[签名]";
			label15.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			label15.AutoSize = true;
			label15.ForeColor = System.Drawing.Color.Gray;
			label15.Location = new System.Drawing.Point(-1, 59);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(40, 17);
			label15.TabIndex = 54;
			label15.Text = "[注释]";
			textBox_api_description.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBox_api_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox_api_description.ForeColor = System.Drawing.Color.Gray;
			textBox_api_description.Location = new System.Drawing.Point(61, 59);
			textBox_api_description.Multiline = true;
			textBox_api_description.Name = "textBox_api_description";
			textBox_api_description.ReadOnly = true;
			textBox_api_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox_api_description.Size = new System.Drawing.Size(683, 56);
			textBox_api_description.TabIndex = 53;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1023, 634);
			base.Controls.Add(panel2);
			base.Controls.Add(panel4);
			base.Controls.Add(panel1);
			base.Controls.Add(userControlHead1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "FormHttpClient";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormWebClient";
			base.Load += new System.EventHandler(FormABBWebApi_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			ResumeLayout(false);
		}
	}
}
