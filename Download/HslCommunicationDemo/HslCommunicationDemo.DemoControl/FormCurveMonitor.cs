using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using HslControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HslCommunicationDemo.DemoControl
{
	public class FormCurveMonitor : Form
	{
		[CompilerGenerated]
		private sealed class _003CFormCurveMonitor_FormClosing_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object sender;

			public FormClosingEventArgs e;

			public FormCurveMonitor _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						_003C_003E4__this.isQuit = true;
						awaiter = Task.Delay(200).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CFormCurveMonitor_FormClosing_003Ed__11 stateMachine = this;
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

		private IReadWriteNet readWriteNet;

		private string address = string.Empty;

		private int timeSpan = 1000;

		private string readType = string.Empty;

		private Thread thread;

		private bool isQuit = false;

		private IContainer components = null;

		private TextBox textBox3;

		private Label label6;

		private TextBox textBox1;

		private Label label1;

		private Button button_read_double;

		private Button button_read_float;

		private Button button_read_ulong;

		private Button button_read_long;

		private Button button_read_uint;

		private Button button_read_int;

		private Button button_read_ushort;

		private Button button_read_short;

		private Button button_read_bool;

		private HslCurve hslCurve1;

		private PropertyGrid propertyGrid1;

		private Label label2;

		private LinkLabel linkLabel1;

		private Label label3;

		private Button button1;

		private Label label_value;

		public FormCurveMonitor()
		{
			InitializeComponent();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start(linkLabel1.Text);
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage(ex);
			}
		}

		private void FormCurveMonitor_Load(object sender, EventArgs e)
		{
			propertyGrid1.SelectedObject = hslCurve1;
			hslCurve1.SetLeftCurve("Test", null, Color.Blue);
		}

		public void SetReadWrite(IReadWriteNet readWrite, string address)
		{
			readWriteNet = readWrite;
			textBox3.Text = address;
			thread = new Thread(ThreadRead);
			thread.IsBackground = false;
			thread.Start();
		}

		private void ThreadRead()
		{
			OperateResult<bool> read;
			OperateResult<short> read2;
			OperateResult<ushort> read3;
			OperateResult<int> read4;
			OperateResult<uint> read5;
			OperateResult<long> read6;
			OperateResult<ulong> read7;
			OperateResult<float> read8;
			OperateResult<double> read9;
			do
			{
				Thread.Sleep(timeSpan);
				if (isQuit)
				{
					break;
				}
				try
				{
					if (readType == "bool")
					{
						read = readWriteNet.ReadBool(address);
						if (!read.IsSuccess)
						{
							MessageBox.Show("Read Failed");
							return;
						}
						if (!isQuit)
						{
							Invoke((Action)delegate
							{
								if (read.Content)
								{
									hslCurve1.AddCurveData("Test", 1f);
								}
								else
								{
									hslCurve1.AddCurveData("Test", 0f);
								}
								label_value.Text = "Value: " + read.Content.ToString();
							});
						}
					}
					else if (readType == "short")
					{
						read2 = readWriteNet.ReadInt16(address);
						if (!read2.IsSuccess)
						{
							MessageBox.Show("Read Failed");
							return;
						}
						if (!isQuit)
						{
							Invoke((Action)delegate
							{
								hslCurve1.AddCurveData("Test", (float)read2.Content);
								label_value.Text = "Value: " + read2.Content.ToString();
							});
						}
					}
					else if (readType == "ushort")
					{
						read3 = readWriteNet.ReadUInt16(address);
						if (!read3.IsSuccess)
						{
							MessageBox.Show("Read Failed");
							return;
						}
						if (!isQuit)
						{
							Invoke((Action)delegate
							{
								hslCurve1.AddCurveData("Test", (float)(int)read3.Content);
								label_value.Text = "Value: " + read3.Content.ToString();
							});
						}
					}
					else if (readType == "int")
					{
						read4 = readWriteNet.ReadInt32(address);
						if (!read4.IsSuccess)
						{
							MessageBox.Show("Read Failed");
							return;
						}
						if (!isQuit)
						{
							Invoke((Action)delegate
							{
								hslCurve1.AddCurveData("Test", (float)read4.Content);
								label_value.Text = "Value: " + read4.Content.ToString();
							});
						}
					}
					else if (readType == "uint")
					{
						read5 = readWriteNet.ReadUInt32(address);
						if (!read5.IsSuccess)
						{
							MessageBox.Show("Read Failed");
							return;
						}
						if (!isQuit)
						{
							Invoke((Action)delegate
							{
								hslCurve1.AddCurveData("Test", (float)(double)read5.Content);
								label_value.Text = "Value: " + read5.Content.ToString();
							});
						}
					}
					else if (readType == "long")
					{
						read6 = readWriteNet.ReadInt64(address);
						if (!read6.IsSuccess)
						{
							MessageBox.Show("Read Failed");
							return;
						}
						if (!isQuit)
						{
							Invoke((Action)delegate
							{
								hslCurve1.AddCurveData("Test", (float)read6.Content);
								label_value.Text = "Value: " + read6.Content.ToString();
							});
						}
					}
					else if (readType == "ulong")
					{
						read7 = readWriteNet.ReadUInt64(address);
						if (!read7.IsSuccess)
						{
							MessageBox.Show("Read Failed");
							return;
						}
						if (!isQuit)
						{
							Invoke((Action)delegate
							{
								hslCurve1.AddCurveData("Test", (float)(double)read7.Content);
								label_value.Text = "Value: " + read7.Content.ToString();
							});
						}
					}
					else if (readType == "float")
					{
						read8 = readWriteNet.ReadFloat(address);
						if (!read8.IsSuccess)
						{
							MessageBox.Show("Read Failed");
							return;
						}
						if (!isQuit)
						{
							Invoke((Action)delegate
							{
								hslCurve1.AddCurveData("Test", read8.Content);
								label_value.Text = "Value: " + read8.Content.ToString();
							});
						}
					}
					else if (readType == "double")
					{
						read9 = readWriteNet.ReadDouble(address);
						if (!read9.IsSuccess)
						{
							MessageBox.Show("Read Failed");
							return;
						}
						if (!isQuit)
						{
							Invoke((Action)delegate
							{
								hslCurve1.AddCurveData("Test", (float)read9.Content);
								label_value.Text = "Value: " + read9.Content.ToString();
							});
						}
					}
				}
				catch
				{
					if (isQuit)
					{
						return;
					}
				}
			}
			while (!isQuit);
		}

		[AsyncStateMachine(typeof(_003CFormCurveMonitor_FormClosing_003Ed__11))]
		[DebuggerStepThrough]
		private void FormCurveMonitor_FormClosing(object sender, FormClosingEventArgs e)
		{
			_003CFormCurveMonitor_FormClosing_003Ed__11 stateMachine = new _003CFormCurveMonitor_FormClosing_003Ed__11();
			stateMachine._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			stateMachine._003C_003E4__this = this;
			stateMachine.sender = sender;
			stateMachine.e = e;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		private void SetEnable(bool enable)
		{
			button_read_bool.Enabled = enable;
			button_read_short.Enabled = enable;
			button_read_ushort.Enabled = enable;
			button_read_int.Enabled = enable;
			button_read_uint.Enabled = enable;
			button_read_long.Enabled = enable;
			button_read_ulong.Enabled = enable;
			button_read_float.Enabled = enable;
			button_read_double.Enabled = enable;
		}

		private void button_read_bool_Click(object sender, EventArgs e)
		{
			readType = "bool";
			address = textBox3.Text;
			timeSpan = int.Parse(textBox1.Text);
			SetEnable(false);
		}

		private void button_read_byte_Click(object sender, EventArgs e)
		{
			readType = "byte";
			address = textBox3.Text;
			timeSpan = int.Parse(textBox1.Text);
			SetEnable(false);
		}

		private void button_read_short_Click(object sender, EventArgs e)
		{
			readType = "short";
			address = textBox3.Text;
			timeSpan = int.Parse(textBox1.Text);
			SetEnable(false);
		}

		private void button_read_ushort_Click(object sender, EventArgs e)
		{
			readType = "ushort";
			address = textBox3.Text;
			timeSpan = int.Parse(textBox1.Text);
			SetEnable(false);
		}

		private void button_read_int_Click(object sender, EventArgs e)
		{
			readType = "int";
			address = textBox3.Text;
			timeSpan = int.Parse(textBox1.Text);
			SetEnable(false);
		}

		private void button_read_uint_Click(object sender, EventArgs e)
		{
			readType = "uint";
			address = textBox3.Text;
			timeSpan = int.Parse(textBox1.Text);
			SetEnable(false);
		}

		private void button_read_long_Click(object sender, EventArgs e)
		{
			readType = "long";
			address = textBox3.Text;
			timeSpan = int.Parse(textBox1.Text);
			SetEnable(false);
		}

		private void button_read_ulong_Click(object sender, EventArgs e)
		{
			readType = "ulong";
			address = textBox3.Text;
			timeSpan = int.Parse(textBox1.Text);
			SetEnable(false);
		}

		private void button_read_float_Click(object sender, EventArgs e)
		{
			readType = "float";
			address = textBox3.Text;
			timeSpan = int.Parse(textBox1.Text);
			SetEnable(false);
		}

		private void button_read_double_Click(object sender, EventArgs e)
		{
			readType = "double";
			address = textBox3.Text;
			timeSpan = int.Parse(textBox1.Text);
			SetEnable(false);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			readType = string.Empty;
			address = textBox3.Text;
			timeSpan = int.Parse(textBox1.Text);
			SetEnable(true);
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
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			button_read_double = new System.Windows.Forms.Button();
			button_read_float = new System.Windows.Forms.Button();
			button_read_ulong = new System.Windows.Forms.Button();
			button_read_long = new System.Windows.Forms.Button();
			button_read_uint = new System.Windows.Forms.Button();
			button_read_int = new System.Windows.Forms.Button();
			button_read_ushort = new System.Windows.Forms.Button();
			button_read_short = new System.Windows.Forms.Button();
			button_read_bool = new System.Windows.Forms.Button();
			hslCurve1 = new HslControls.HslCurve();
			propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			label2 = new System.Windows.Forms.Label();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			label3 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			label_value = new System.Windows.Forms.Label();
			SuspendLayout();
			textBox3.Location = new System.Drawing.Point(59, 4);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(185, 23);
			textBox3.TabIndex = 5;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(5, 7);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(44, 17);
			label6.TabIndex = 4;
			label6.Text = "地址：";
			textBox1.Location = new System.Drawing.Point(372, 4);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(102, 23);
			textBox1.TabIndex = 7;
			textBox1.Text = "1000";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(279, 7);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(81, 17);
			label1.TabIndex = 6;
			label1.Text = "时间间隔(ms)";
			button_read_double.Location = new System.Drawing.Point(800, 33);
			button_read_double.Name = "button_read_double";
			button_read_double.Size = new System.Drawing.Size(82, 28);
			button_read_double.TabIndex = 25;
			button_read_double.Text = "double读取";
			button_read_double.UseVisualStyleBackColor = true;
			button_read_double.Click += new System.EventHandler(button_read_double_Click);
			button_read_float.Location = new System.Drawing.Point(712, 33);
			button_read_float.Name = "button_read_float";
			button_read_float.Size = new System.Drawing.Size(82, 28);
			button_read_float.TabIndex = 24;
			button_read_float.Text = "float读取";
			button_read_float.UseVisualStyleBackColor = true;
			button_read_float.Click += new System.EventHandler(button_read_float_Click);
			button_read_ulong.Location = new System.Drawing.Point(624, 33);
			button_read_ulong.Name = "button_read_ulong";
			button_read_ulong.Size = new System.Drawing.Size(82, 28);
			button_read_ulong.TabIndex = 23;
			button_read_ulong.Text = "ulong读取";
			button_read_ulong.UseVisualStyleBackColor = true;
			button_read_ulong.Click += new System.EventHandler(button_read_ulong_Click);
			button_read_long.Location = new System.Drawing.Point(536, 33);
			button_read_long.Name = "button_read_long";
			button_read_long.Size = new System.Drawing.Size(82, 28);
			button_read_long.TabIndex = 22;
			button_read_long.Text = "long读取";
			button_read_long.UseVisualStyleBackColor = true;
			button_read_long.Click += new System.EventHandler(button_read_long_Click);
			button_read_uint.Location = new System.Drawing.Point(448, 33);
			button_read_uint.Name = "button_read_uint";
			button_read_uint.Size = new System.Drawing.Size(82, 28);
			button_read_uint.TabIndex = 21;
			button_read_uint.Text = "uint读取";
			button_read_uint.UseVisualStyleBackColor = true;
			button_read_uint.Click += new System.EventHandler(button_read_uint_Click);
			button_read_int.Location = new System.Drawing.Point(360, 33);
			button_read_int.Name = "button_read_int";
			button_read_int.Size = new System.Drawing.Size(82, 28);
			button_read_int.TabIndex = 20;
			button_read_int.Text = "int读取";
			button_read_int.UseVisualStyleBackColor = true;
			button_read_int.Click += new System.EventHandler(button_read_int_Click);
			button_read_ushort.Location = new System.Drawing.Point(272, 33);
			button_read_ushort.Name = "button_read_ushort";
			button_read_ushort.Size = new System.Drawing.Size(82, 28);
			button_read_ushort.TabIndex = 19;
			button_read_ushort.Text = "ushort读取";
			button_read_ushort.UseVisualStyleBackColor = true;
			button_read_ushort.Click += new System.EventHandler(button_read_ushort_Click);
			button_read_short.Location = new System.Drawing.Point(184, 33);
			button_read_short.Name = "button_read_short";
			button_read_short.Size = new System.Drawing.Size(82, 28);
			button_read_short.TabIndex = 18;
			button_read_short.Text = "short读取";
			button_read_short.UseVisualStyleBackColor = true;
			button_read_short.Click += new System.EventHandler(button_read_short_Click);
			button_read_bool.Location = new System.Drawing.Point(8, 33);
			button_read_bool.Name = "button_read_bool";
			button_read_bool.Size = new System.Drawing.Size(82, 28);
			button_read_bool.TabIndex = 16;
			button_read_bool.Text = "bool读取";
			button_read_bool.UseVisualStyleBackColor = true;
			button_read_bool.Click += new System.EventHandler(button_read_bool_Click);
			hslCurve1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			hslCurve1.BackColor = System.Drawing.Color.White;
			hslCurve1.Location = new System.Drawing.Point(8, 67);
			hslCurve1.Name = "hslCurve1";
			hslCurve1.Size = new System.Drawing.Size(689, 473);
			hslCurve1.TabIndex = 26;
			propertyGrid1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			propertyGrid1.BackColor = System.Drawing.Color.White;
			propertyGrid1.Location = new System.Drawing.Point(703, 68);
			propertyGrid1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			propertyGrid1.Name = "propertyGrid1";
			propertyGrid1.Size = new System.Drawing.Size(185, 471);
			propertyGrid1.TabIndex = 27;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(9, 546);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(460, 17);
			label2.TabIndex = 28;
			label2.Text = "更高级的数据分析，诊断，曲线分析，诊断，请访问下面的优秀产品：PLC-Recorder";
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new System.Drawing.Point(490, 546);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(120, 17);
			linkLabel1.TabIndex = 29;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "www.hiddenmap.cn";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(657, 546);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(115, 17);
			label3.TabIndex = 30;
			label3.Text = "QQ群：877456127";
			button1.Location = new System.Drawing.Point(801, 2);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(82, 28);
			button1.TabIndex = 31;
			button1.Text = "取消";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			label_value.AutoSize = true;
			label_value.Location = new System.Drawing.Point(490, 7);
			label_value.Name = "label_value";
			label_value.Size = new System.Drawing.Size(47, 17);
			label_value.TabIndex = 32;
			label_value.Text = "Value: ";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(894, 570);
			base.Controls.Add(label_value);
			base.Controls.Add(button1);
			base.Controls.Add(label3);
			base.Controls.Add(linkLabel1);
			base.Controls.Add(label2);
			base.Controls.Add(propertyGrid1);
			base.Controls.Add(hslCurve1);
			base.Controls.Add(button_read_double);
			base.Controls.Add(button_read_float);
			base.Controls.Add(button_read_ulong);
			base.Controls.Add(button_read_long);
			base.Controls.Add(button_read_uint);
			base.Controls.Add(button_read_int);
			base.Controls.Add(button_read_ushort);
			base.Controls.Add(button_read_short);
			base.Controls.Add(button_read_bool);
			base.Controls.Add(textBox1);
			base.Controls.Add(label1);
			base.Controls.Add(textBox3);
			base.Controls.Add(label6);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.MinimizeBox = false;
			base.Name = "FormCurveMonitor";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "曲线的实时监控";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormCurveMonitor_FormClosing);
			base.Load += new System.EventHandler(FormCurveMonitor_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
