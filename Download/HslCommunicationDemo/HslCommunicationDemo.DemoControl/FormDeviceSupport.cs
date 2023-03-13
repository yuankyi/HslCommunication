using HslCommunication;
using HslCommunication.MQTT;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace HslCommunicationDemo.DemoControl
{
	public class FormDeviceSupport : Form
	{
		[CompilerGenerated]
		private sealed class _003CThreadPoolCheckVersion_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object obj;

			public FormDeviceSupport _003C_003E4__this;

			private MqttSyncClient _003Cmqtt_003E5__1;

			private OperateResult<string> _003Cread_003E5__2;

			private OperateResult<string> _003C_003Es__3;

			private List<DeviceSupportList> _003Cdevices_003E5__4;

			private TaskAwaiter<OperateResult<string>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<string>> awaiter;
					if (num != 0)
					{
						Thread.Sleep(100);
						_003Cmqtt_003E5__1 = new MqttSyncClient(new MqttConnectionOptions
						{
							IpAddress = "118.24.36.220",
							Port = 1883,
							UseRSAProvider = true
						});
						awaiter = _003Cmqtt_003E5__1.ReadRpcAsync<string>("SupportList/GetDeviceSupport", new
						{
							token = string.Empty,
							unique = _003C_003E4__this.formName
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CThreadPoolCheckVersion_003Ed__3 stateMachine = this;
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
					_003C_003Es__3 = awaiter.GetResult();
					_003Cread_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cread_003E5__2.IsSuccess)
					{
						if (!string.IsNullOrEmpty(_003Cread_003E5__2.Content))
						{
							_003Cdevices_003E5__4 = JArray.Parse(_003Cread_003E5__2.Content).ToObject<List<DeviceSupportList>>();
							_003C_003E4__this.Invoke(new Action<List<DeviceSupportList>>(_003C_003E4__this.RenderDevice), _003Cdevices_003E5__4);
							_003Cdevices_003E5__4 = null;
						}
					}
					else
					{
						MessageBox.Show("Request Server failed: " + _003Cread_003E5__2.Message);
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cmqtt_003E5__1 = null;
					_003Cread_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cmqtt_003E5__1 = null;
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

		[CompilerGenerated]
		private sealed class _003Cbutton1_Click_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public EventArgs e;

			public FormDeviceSupport _003C_003E4__this;

			private MqttSyncClient _003Cmqtt_003E5__1;

			private OperateResult<List<DeviceSupportList>> _003Cread_003E5__2;

			private OperateResult<List<DeviceSupportList>> _003C_003Es__3;

			private TaskAwaiter<OperateResult<List<DeviceSupportList>>> _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<OperateResult<List<DeviceSupportList>>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<OperateResult<List<DeviceSupportList>>>);
						num = (_003C_003E1__state = -1);
						goto IL_0125;
					}
					if (!string.IsNullOrEmpty(_003C_003E4__this.textBox1.Text))
					{
						_003C_003E4__this.button1.Enabled = false;
						_003Cmqtt_003E5__1 = new MqttSyncClient(new MqttConnectionOptions
						{
							IpAddress = "118.24.36.220",
							Port = 1883,
							UseRSAProvider = true
						});
						awaiter = _003Cmqtt_003E5__1.ReadRpcAsync<List<DeviceSupportList>>("SupportList/UploadSupport", new
						{
							token = string.Empty,
							unique = _003C_003E4__this.formName,
							model = _003C_003E4__this.textBox1.Text,
							qq = _003C_003E4__this.textBox2.Text,
							name = _003C_003E4__this.textBox3.Text
						}).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003Cbutton1_Click_003Ed__1 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_0125;
					}
					MessageBox.Show("Model can't be null!");
					goto end_IL_0007;
					IL_0125:
					_003C_003Es__3 = awaiter.GetResult();
					_003Cread_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cread_003E5__2.IsSuccess)
					{
						MessageBox.Show("Upload data success");
						ThreadPool.QueueUserWorkItem(_003C_003E4__this.ThreadPoolCheckVersion, null);
					}
					else
					{
						MessageBox.Show("Request Server failed: " + _003Cread_003E5__2.Message);
					}
					_003C_003E4__this.button1.Enabled = true;
					end_IL_0007:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003Cmqtt_003E5__1 = null;
					_003Cread_003E5__2 = null;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003Cmqtt_003E5__1 = null;
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

		private string formName = string.Empty;

		private IContainer components = null;

		private Label label1;

		private DataGridView dataGridView1;

		private Label label2;

		private Label label3;

		private TextBox textBox1;

		private TextBox textBox2;

		private Label label4;

		private Button button1;

		private TextBox textBox3;

		private Label label5;

		private DataGridViewTextBoxColumn Model;

		private DataGridViewTextBoxColumn ColumnName;

		private DataGridViewTextBoxColumn QQ;

		private DataGridViewTextBoxColumn ColumnTime;

		public FormDeviceSupport(string formName)
		{
			InitializeComponent();
			this.formName = formName;
		}

		[AsyncStateMachine(typeof(_003Cbutton1_Click_003Ed__1))]
		[DebuggerStepThrough]
		private void button1_Click(object sender, EventArgs e)
		{
			_003Cbutton1_Click_003Ed__1 stateMachine = new _003Cbutton1_Click_003Ed__1();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void FormDeviceSupport_Shown(object sender, EventArgs e)
		{
			ThreadPool.QueueUserWorkItem(ThreadPoolCheckVersion, null);
		}

		[AsyncStateMachine(typeof(_003CThreadPoolCheckVersion_003Ed__3))]
		[DebuggerStepThrough]
		private void ThreadPoolCheckVersion(object obj)
		{
			_003CThreadPoolCheckVersion_003Ed__3 stateMachine = new _003CThreadPoolCheckVersion_003Ed__3();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.obj = obj;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void RenderDevice(List<DeviceSupportList> devices)
		{
			if (devices == null)
			{
				DataGridSpecifyRowCount(dataGridView1, 0);
			}
			else
			{
				DataGridSpecifyRowCount(dataGridView1, devices.Count);
				for (int i = 0; i < devices.Count; i++)
				{
					dataGridView1.Rows[i].Cells[0].Value = devices[i].Model;
					dataGridView1.Rows[i].Cells[1].Value = devices[i].Name;
					dataGridView1.Rows[i].Cells[2].Value = devices[i].QQ;
					dataGridView1.Rows[i].Cells[3].Value = devices[i].Time.ToString("yyyy-MM-dd");
				}
			}
		}

		public static void DataGridSpecifyRowCount(DataGridView dataGridView1, int row)
		{
			if (dataGridView1.AllowUserToAddRows)
			{
				row++;
			}
			if (dataGridView1.RowCount < row)
			{
				dataGridView1.Rows.Add(row - dataGridView1.RowCount);
			}
			else if (dataGridView1.RowCount > row)
			{
				int num = dataGridView1.RowCount - row;
				for (int i = 0; i < num; i++)
				{
					dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
				}
			}
			if (row > 0)
			{
				dataGridView1.Rows[0].Cells[0].Selected = false;
			}
		}

		private void FormDeviceSupport_Load(object sender, EventArgs e)
		{
			if (Program.Language == 1)
			{
				dataGridView1.Columns[0].HeaderText = "系列及型号";
				dataGridView1.Columns[1].HeaderText = "上传者";
				dataGridView1.Columns[2].HeaderText = "联系方式（QQ）";
				dataGridView1.Columns[3].HeaderText = "上传时间";
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			label1 = new System.Windows.Forms.Label();
			dataGridView1 = new System.Windows.Forms.DataGridView();
			Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
			ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			QQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
			ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			textBox2 = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			textBox3 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(116, 17);
			label1.TabIndex = 0;
			label1.Text = "支持的设备列表信息";
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(210, 210, 255);
			dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			dataGridView1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			dataGridView1.BackgroundColor = System.Drawing.Color.White;
			dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(Model, ColumnName, QQ, ColumnTime);
			dataGridView1.Location = new System.Drawing.Point(15, 39);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersVisible = false;
			dataGridView1.RowTemplate.Height = 23;
			dataGridView1.Size = new System.Drawing.Size(711, 457);
			dataGridView1.TabIndex = 1;
			Model.HeaderText = "Model";
			Model.Name = "Model";
			Model.ReadOnly = true;
			Model.Width = 260;
			ColumnName.HeaderText = "Name";
			ColumnName.Name = "ColumnName";
			ColumnName.ReadOnly = true;
			ColumnName.Width = 160;
			QQ.HeaderText = "Contact: QQ";
			QQ.Name = "QQ";
			QQ.ReadOnly = true;
			QQ.Width = 150;
			ColumnTime.HeaderText = "Date";
			ColumnTime.Name = "ColumnTime";
			ColumnTime.ReadOnly = true;
			ColumnTime.Width = 120;
			label2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(733, 9);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(104, 17);
			label2.TabIndex = 2;
			label2.Text = "上传新的设备信息";
			label3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(733, 34);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(44, 17);
			label3.TabIndex = 3;
			label3.Text = "型号：";
			textBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			textBox1.Location = new System.Drawing.Point(736, 54);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(216, 23);
			textBox1.TabIndex = 4;
			textBox2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			textBox2.Location = new System.Drawing.Point(736, 159);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(216, 23);
			textBox2.TabIndex = 6;
			label4.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(733, 134);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(96, 17);
			label4.TabIndex = 5;
			label4.Text = "QQ(联系方式)：";
			button1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			button1.Location = new System.Drawing.Point(787, 225);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(107, 35);
			button1.TabIndex = 7;
			button1.Text = "上传";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			textBox3.Location = new System.Drawing.Point(736, 105);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(216, 23);
			textBox3.TabIndex = 9;
			label5.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(733, 84);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(80, 17);
			label5.TabIndex = 8;
			label5.Text = "上传人昵称：";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(958, 510);
			base.Controls.Add(textBox3);
			base.Controls.Add(label5);
			base.Controls.Add(button1);
			base.Controls.Add(textBox2);
			base.Controls.Add(label4);
			base.Controls.Add(textBox1);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(dataGridView1);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "FormDeviceSupport";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "FormDeviceSupport";
			base.Load += new System.EventHandler(FormDeviceSupport_Load);
			base.Shown += new System.EventHandler(FormDeviceSupport_Shown);
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
