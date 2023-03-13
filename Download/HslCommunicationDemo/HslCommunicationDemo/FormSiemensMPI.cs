using HslCommunication;
using HslCommunication.Core;
using HslCommunication.Profinet.Siemens;
using HslCommunicationDemo.DemoControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class FormSiemensMPI : HslFormContent
	{
		private SiemensMPI siemensMPI = null;

		private IContainer components = null;

		private Panel panel1;

		private Panel panel2;

		private GroupBox groupBox3;

		private TextBox textBox10;

		private Label label13;

		private Button button25;

		private TextBox textBox9;

		private Label label12;

		private TextBox textBox6;

		private Label label11;

		private GroupBox groupBox2;

		private Button button14;

		private Button button15;

		private Button button16;

		private Button button17;

		private Button button18;

		private Button button19;

		private Button button20;

		private Button button21;

		private Button button22;

		private Button button24;

		private TextBox textBox7;

		private Label label9;

		private TextBox textBox8;

		private Label label10;

		private GroupBox groupBox1;

		private TextBox textBox5;

		private Button button_read_string;

		private Button button_read_double;

		private Button button_read_float;

		private Button button_read_ulong;

		private Button button_read_long;

		private Button button_read_uint;

		private Button button_read_int;

		private Button button_read_ushort;

		private Button button_read_short;

		private Button button_read_bool;

		private TextBox textBox4;

		private Label label7;

		private TextBox textBox3;

		private Label label6;

		private Label label8;

		private Label label19;

		private Label label22;

		private Label label21;

		private Button button23;

		private Button button_read_byte;

		private ComboBox comboBox1;

		private Label label1;

		private TextBox textBox17;

		private Label label3;

		private TextBox textBox16;

		private Label label25;

		private TextBox textBox2;

		private Label label26;

		private Label label27;

		private Button button2;

		private Button button1;

		private ComboBox comboBox3;

		private TextBox textBox15;

		private Label label23;

		private UserControlCurve userControlCurve1;

		private UserControlHead userControlHead1;

		private TextBox textBox1;

		private CheckBox checkBox1;

		public FormSiemensMPI()
		{
			InitializeComponent();
			siemensMPI = new SiemensMPI();
		}

		private void FormSiemens_Load(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			Language(Program.Language);
			comboBox3.DataSource = SerialPort.GetPortNames();
			try
			{
				comboBox3.SelectedIndex = 0;
			}
			catch
			{
				comboBox3.Text = "COM3";
			}
			comboBox1.SelectedIndex = 2;
		}

		private void Language(int language)
		{
			if (language == 2)
			{
				Text = "Siemens Read PLC Demo";
				label1.Text = "parity:";
				label3.Text = "Stop bits";
				label27.Text = "Com:";
				label26.Text = "BaudRate";
				label25.Text = "Data bits";
				button1.Text = "Connect";
				button2.Text = "Disconnect";
				label21.Text = "Address:";
				label6.Text = "address:";
				label7.Text = "result:";
				button_read_bool.Text = "Read Bit";
				button_read_byte.Text = "r-byte";
				button_read_short.Text = "r-short";
				button_read_ushort.Text = "r-ushort";
				button_read_int.Text = "r-int";
				button_read_uint.Text = "r-uint";
				button_read_long.Text = "r-long";
				button_read_ulong.Text = "r-ulong";
				button_read_float.Text = "r-float";
				button_read_double.Text = "r-double";
				button_read_string.Text = "r-string";
				label8.Text = "length:";
				label11.Text = "Address:";
				label12.Text = "length:";
				button25.Text = "Bulk Read";
				label13.Text = "Results:";
				label10.Text = "Address:";
				label9.Text = "Value:";
				label19.Text = "Note: The value of the string needs to be converted";
				button24.Text = "Write Bit";
				button22.Text = "w-short";
				button21.Text = "w-ushort";
				button20.Text = "w-int";
				button19.Text = "w-uint";
				button18.Text = "w-long";
				button17.Text = "w-ulong";
				button16.Text = "w-float";
				button15.Text = "w-double";
				button14.Text = "w-string";
				groupBox1.Text = "Single Data Read test";
				groupBox2.Text = "Single Data Write test";
				groupBox3.Text = "Bulk Read test";
				button23.Text = "w-byte";
			}
		}

		private void FormSiemens_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int baudRate;
			int dataBits;
			int stopBits;
			if (!int.TryParse(textBox2.Text, out baudRate))
			{
				MessageBox.Show(DemoUtils.BaudRateInputWrong);
			}
			else if (!int.TryParse(textBox16.Text, out dataBits))
			{
				MessageBox.Show(DemoUtils.DataBitsInputWrong);
			}
			else if (!int.TryParse(textBox17.Text, out stopBits))
			{
				MessageBox.Show(DemoUtils.StopBitInputWrong);
			}
			else
			{
				SiemensMPI obj = siemensMPI;
				if (obj != null)
				{
					obj.Close();
				}
				siemensMPI = new SiemensMPI();
				try
				{
					siemensMPI.SerialPortInni(delegate(SerialPort sp)
					{
						sp.PortName = comboBox3.Text;
						sp.BaudRate = baudRate;
						sp.DataBits = dataBits;
						sp.StopBits = ((stopBits != 0) ? ((stopBits == 1) ? StopBits.One : StopBits.Two) : StopBits.None);
						sp.Parity = ((comboBox1.SelectedIndex != 0) ? ((comboBox1.SelectedIndex == 1) ? Parity.Odd : Parity.Even) : Parity.None);
					});
					siemensMPI.Open();
					siemensMPI.Station = byte.Parse(textBox15.Text);
					if (!checkBox1.Checked)
					{
						goto IL_0140;
					}
					OperateResult operateResult = siemensMPI.Handle();
					if (operateResult.IsSuccess)
					{
						goto IL_0140;
					}
					MessageBox.Show("Hand Failed:" + operateResult.Message);
					goto end_IL_00b5;
					IL_0140:
					button2.Enabled = true;
					button1.Enabled = false;
					panel2.Enabled = true;
					userControlCurve1.ReadWriteNet = siemensMPI;
					end_IL_00b5:;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			siemensMPI.Close();
			button2.Enabled = false;
			button1.Enabled = true;
			panel2.Enabled = false;
		}

		private void button_read_bool_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "1")
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadBool(textBox3.Text), textBox3.Text, textBox4);
			}
			else
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadBool(textBox3.Text, ushort.Parse(textBox1.Text)), textBox3.Text, textBox4);
			}
		}

		private void button_read_byte_Click(object sender, EventArgs e)
		{
			DemoUtils.ReadResultRender(siemensMPI.ReadByte(textBox3.Text), textBox3.Text, textBox4);
		}

		private void button_read_short_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "1")
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadInt16(textBox3.Text), textBox3.Text, textBox4);
			}
			else
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadInt16(textBox3.Text, ushort.Parse(textBox1.Text)), textBox3.Text, textBox4);
			}
		}

		private void button_read_ushort_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "1")
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadUInt16(textBox3.Text), textBox3.Text, textBox4);
			}
			else
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadUInt16(textBox3.Text, ushort.Parse(textBox1.Text)), textBox3.Text, textBox4);
			}
		}

		private void button_read_int_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "1")
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadInt32(textBox3.Text), textBox3.Text, textBox4);
			}
			else
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadInt32(textBox3.Text, ushort.Parse(textBox1.Text)), textBox3.Text, textBox4);
			}
		}

		private void button_read_uint_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "1")
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadUInt32(textBox3.Text), textBox3.Text, textBox4);
			}
			else
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadUInt32(textBox3.Text, ushort.Parse(textBox1.Text)), textBox3.Text, textBox4);
			}
		}

		private void button_read_long_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "1")
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadInt64(textBox3.Text), textBox3.Text, textBox4);
			}
			else
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadInt64(textBox3.Text, ushort.Parse(textBox1.Text)), textBox3.Text, textBox4);
			}
		}

		private void button_read_ulong_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "1")
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadUInt64(textBox3.Text), textBox3.Text, textBox4);
			}
			else
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadUInt64(textBox3.Text, ushort.Parse(textBox1.Text)), textBox3.Text, textBox4);
			}
		}

		private void button_read_float_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "1")
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadFloat(textBox3.Text), textBox3.Text, textBox4);
			}
			else
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadFloat(textBox3.Text, ushort.Parse(textBox1.Text)), textBox3.Text, textBox4);
			}
		}

		private void button_read_double_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "1")
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadDouble(textBox3.Text), textBox3.Text, textBox4);
			}
			else
			{
				DemoUtils.ReadResultRender(siemensMPI.ReadDouble(textBox3.Text, ushort.Parse(textBox1.Text)), textBox3.Text, textBox4);
			}
		}

		private void button_read_string_Click(object sender, EventArgs e)
		{
			DemoUtils.ReadResultRender(siemensMPI.ReadString(textBox3.Text, ushort.Parse(textBox5.Text)), textBox3.Text, textBox4);
		}

		private void button24_Click(object sender, EventArgs e)
		{
			try
			{
				DemoUtils.WriteResultRender(siemensMPI.Write(textBox8.Text, bool.Parse(textBox7.Text)), textBox8.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button23_Click(object sender, EventArgs e)
		{
			try
			{
				DemoUtils.WriteResultRender(siemensMPI.Write(textBox8.Text, byte.Parse(textBox7.Text)), textBox8.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button22_Click(object sender, EventArgs e)
		{
			try
			{
				DemoUtils.WriteResultRender(siemensMPI.Write(textBox8.Text, short.Parse(textBox7.Text)), textBox8.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button21_Click(object sender, EventArgs e)
		{
			try
			{
				DemoUtils.WriteResultRender(siemensMPI.Write(textBox8.Text, ushort.Parse(textBox7.Text)), textBox8.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button20_Click(object sender, EventArgs e)
		{
			try
			{
				DemoUtils.WriteResultRender(siemensMPI.Write(textBox8.Text, int.Parse(textBox7.Text)), textBox8.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button19_Click(object sender, EventArgs e)
		{
			try
			{
				DemoUtils.WriteResultRender(siemensMPI.Write(textBox8.Text, uint.Parse(textBox7.Text)), textBox8.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button18_Click(object sender, EventArgs e)
		{
			try
			{
				DemoUtils.WriteResultRender(siemensMPI.Write(textBox8.Text, long.Parse(textBox7.Text)), textBox8.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button17_Click(object sender, EventArgs e)
		{
			try
			{
				DemoUtils.WriteResultRender(siemensMPI.Write(textBox8.Text, ulong.Parse(textBox7.Text)), textBox8.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button16_Click(object sender, EventArgs e)
		{
			try
			{
				DemoUtils.WriteResultRender(siemensMPI.Write(textBox8.Text, float.Parse(textBox7.Text)), textBox8.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button15_Click(object sender, EventArgs e)
		{
			try
			{
				DemoUtils.WriteResultRender(siemensMPI.Write(textBox8.Text, double.Parse(textBox7.Text)), textBox8.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button14_Click(object sender, EventArgs e)
		{
			try
			{
				DemoUtils.WriteResultRender(siemensMPI.Write(textBox8.Text, textBox7.Text), textBox8.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button25_Click(object sender, EventArgs e)
		{
			DemoUtils.BulkReadRenderResult(siemensMPI, textBox6, textBox9, textBox10);
		}

		private void Test1()
		{
			OperateResult<bool> operateResult = siemensMPI.ReadBool("M100.4");
			if (operateResult.IsSuccess)
			{
				bool content = operateResult.Content;
			}
			else
			{
				string message = operateResult.Message;
			}
			OperateResult operateResult2 = siemensMPI.Write("M100.4", true);
			if (!operateResult2.IsSuccess)
			{
				string message2 = operateResult2.Message;
			}
		}

		private void Test2()
		{
			byte content = siemensMPI.ReadByte("M100").Content;
			short content2 = siemensMPI.ReadInt16("M100").Content;
			ushort content3 = siemensMPI.ReadUInt16("M100").Content;
			int content4 = siemensMPI.ReadInt32("M100").Content;
			uint content5 = siemensMPI.ReadUInt32("M100").Content;
			float content6 = siemensMPI.ReadFloat("M100").Content;
			double content7 = siemensMPI.ReadDouble("M100").Content;
			string content8 = siemensMPI.ReadString("M100", 10).Content;
			IByteTransform byteTransform = new ReverseBytesTransform();
		}

		private void Test3()
		{
			bool content = siemensMPI.ReadBool("M100.7").Content;
			byte content2 = siemensMPI.ReadByte("M100").Content;
			short content3 = siemensMPI.ReadInt16("M100").Content;
			ushort content4 = siemensMPI.ReadUInt16("M100").Content;
			int content5 = siemensMPI.ReadInt32("M100").Content;
			uint content6 = siemensMPI.ReadUInt32("M100").Content;
			float content7 = siemensMPI.ReadFloat("M100").Content;
			long content8 = siemensMPI.ReadInt64("M100").Content;
			ulong content9 = siemensMPI.ReadUInt64("M100").Content;
			double content10 = siemensMPI.ReadDouble("M100").Content;
			string content11 = siemensMPI.ReadString("M100", 10).Content;
			siemensMPI.Write("M100.7", true);
			siemensMPI.Write("M100", (short)51);
			siemensMPI.Write("M100", (short)12345);
			siemensMPI.Write("M100", (ushort)45678);
			siemensMPI.Write("M100", 123456789);
			siemensMPI.Write("M100", 3456789123u);
			siemensMPI.Write("M100", 123.456f);
			siemensMPI.Write("M100", 1234556434534545L);
			siemensMPI.Write("M100", 523434234234343uL);
			siemensMPI.Write("M100", 123.456);
			siemensMPI.Write("M100", "K123456789");
			OperateResult<byte[]> operateResult = siemensMPI.Read("M100", 10);
			if (operateResult.IsSuccess)
			{
				byte b = operateResult.Content[0];
				byte b2 = operateResult.Content[1];
				byte b3 = operateResult.Content[2];
				byte b4 = operateResult.Content[3];
				byte b5 = operateResult.Content[4];
				byte b6 = operateResult.Content[5];
				byte b7 = operateResult.Content[6];
				byte b8 = operateResult.Content[7];
				byte b9 = operateResult.Content[8];
				byte b10 = operateResult.Content[9];
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
			panel1 = new System.Windows.Forms.Panel();
			checkBox1 = new System.Windows.Forms.CheckBox();
			textBox15 = new System.Windows.Forms.TextBox();
			label23 = new System.Windows.Forms.Label();
			comboBox3 = new System.Windows.Forms.ComboBox();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label1 = new System.Windows.Forms.Label();
			textBox17 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			textBox16 = new System.Windows.Forms.TextBox();
			label25 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			label26 = new System.Windows.Forms.Label();
			label27 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			label22 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			userControlCurve1 = new HslCommunicationDemo.DemoControl.UserControlCurve();
			groupBox3 = new System.Windows.Forms.GroupBox();
			textBox10 = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			button25 = new System.Windows.Forms.Button();
			textBox9 = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			textBox6 = new System.Windows.Forms.TextBox();
			label11 = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			label19 = new System.Windows.Forms.Label();
			button14 = new System.Windows.Forms.Button();
			button15 = new System.Windows.Forms.Button();
			button16 = new System.Windows.Forms.Button();
			button17 = new System.Windows.Forms.Button();
			button18 = new System.Windows.Forms.Button();
			button19 = new System.Windows.Forms.Button();
			button20 = new System.Windows.Forms.Button();
			button21 = new System.Windows.Forms.Button();
			button22 = new System.Windows.Forms.Button();
			button23 = new System.Windows.Forms.Button();
			button24 = new System.Windows.Forms.Button();
			textBox7 = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			textBox8 = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			textBox1 = new System.Windows.Forms.TextBox();
			textBox5 = new System.Windows.Forms.TextBox();
			button_read_string = new System.Windows.Forms.Button();
			button_read_double = new System.Windows.Forms.Button();
			button_read_float = new System.Windows.Forms.Button();
			button_read_ulong = new System.Windows.Forms.Button();
			button_read_long = new System.Windows.Forms.Button();
			button_read_uint = new System.Windows.Forms.Button();
			button_read_int = new System.Windows.Forms.Button();
			button_read_ushort = new System.Windows.Forms.Button();
			button_read_short = new System.Windows.Forms.Button();
			button_read_byte = new System.Windows.Forms.Button();
			button_read_bool = new System.Windows.Forms.Button();
			textBox4 = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			textBox3 = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			userControlHead1 = new HslCommunicationDemo.DemoControl.UserControlHead();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(checkBox1);
			panel1.Controls.Add(textBox15);
			panel1.Controls.Add(label23);
			panel1.Controls.Add(comboBox3);
			panel1.Controls.Add(comboBox1);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(textBox17);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(textBox16);
			panel1.Controls.Add(label25);
			panel1.Controls.Add(textBox2);
			panel1.Controls.Add(label26);
			panel1.Controls.Add(label27);
			panel1.Controls.Add(button2);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(label22);
			panel1.Controls.Add(label21);
			panel1.Location = new System.Drawing.Point(3, 35);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(997, 54);
			panel1.TabIndex = 0;
			checkBox1.AutoSize = true;
			checkBox1.Checked = true;
			checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox1.Location = new System.Drawing.Point(602, 0);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(75, 21);
			checkBox1.TabIndex = 41;
			checkBox1.Text = "握手检查";
			checkBox1.UseVisualStyleBackColor = true;
			textBox15.Location = new System.Drawing.Point(548, 15);
			textBox15.Name = "textBox15";
			textBox15.Size = new System.Drawing.Size(37, 23);
			textBox15.TabIndex = 40;
			textBox15.Text = "2";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(504, 18);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(44, 17);
			label23.TabIndex = 39;
			label23.Text = "站号：";
			comboBox3.FormattingEnabled = true;
			comboBox3.Location = new System.Drawing.Point(62, 12);
			comboBox3.Name = "comboBox3";
			comboBox3.Size = new System.Drawing.Size(67, 25);
			comboBox3.TabIndex = 38;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[3]
			{
				"无",
				"奇",
				"偶"
			});
			comboBox1.Location = new System.Drawing.Point(449, 15);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(49, 25);
			comboBox1.TabIndex = 37;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(413, 18);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(44, 17);
			label1.TabIndex = 36;
			label1.Text = "奇偶：";
			textBox17.Location = new System.Drawing.Point(383, 15);
			textBox17.Name = "textBox17";
			textBox17.Size = new System.Drawing.Size(23, 23);
			textBox17.TabIndex = 35;
			textBox17.Text = "1";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(329, 18);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(56, 17);
			label3.TabIndex = 34;
			label3.Text = "停止位：";
			textBox16.Location = new System.Drawing.Point(292, 15);
			textBox16.Name = "textBox16";
			textBox16.Size = new System.Drawing.Size(24, 23);
			textBox16.TabIndex = 33;
			textBox16.Text = "8";
			label25.AutoSize = true;
			label25.Location = new System.Drawing.Point(238, 18);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(56, 17);
			label25.TabIndex = 32;
			label25.Text = "数据位：";
			textBox2.Location = new System.Drawing.Point(185, 15);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(47, 23);
			textBox2.TabIndex = 31;
			textBox2.Text = "9600";
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(131, 18);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(56, 17);
			label26.TabIndex = 30;
			label26.Text = "波特率：";
			label27.AutoSize = true;
			label27.Location = new System.Drawing.Point(5, 18);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(59, 17);
			label27.TabIndex = 28;
			label27.Text = "Com口：";
			button2.Enabled = false;
			button2.Location = new System.Drawing.Point(699, 23);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(91, 28);
			button2.TabIndex = 27;
			button2.Text = "关闭串口";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			button1.Location = new System.Drawing.Point(602, 23);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(91, 28);
			button1.TabIndex = 26;
			button1.Text = "打开串口";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			label22.Location = new System.Drawing.Point(841, 0);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(132, 52);
			label22.TabIndex = 7;
			label22.Text = "M100  I100  Q100 DB100.20   T100 C100";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(767, 0);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(68, 17);
			label21.TabIndex = 6;
			label21.Text = "地址示例：";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(userControlCurve1);
			panel2.Controls.Add(groupBox3);
			panel2.Controls.Add(groupBox2);
			panel2.Controls.Add(groupBox1);
			panel2.Location = new System.Drawing.Point(14, 100);
			panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(978, 537);
			panel2.TabIndex = 1;
			userControlCurve1.AddressExample = "M100";
			userControlCurve1.Location = new System.Drawing.Point(545, 242);
			userControlCurve1.Name = "userControlCurve1";
			userControlCurve1.ReadWriteNet = null;
			userControlCurve1.Size = new System.Drawing.Size(420, 279);
			userControlCurve1.TabIndex = 3;
			groupBox3.Controls.Add(textBox10);
			groupBox3.Controls.Add(label13);
			groupBox3.Controls.Add(button25);
			groupBox3.Controls.Add(textBox9);
			groupBox3.Controls.Add(label12);
			groupBox3.Controls.Add(textBox6);
			groupBox3.Controls.Add(label11);
			groupBox3.Location = new System.Drawing.Point(11, 243);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(518, 278);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "批量读取测试";
			textBox10.Location = new System.Drawing.Point(63, 60);
			textBox10.Multiline = true;
			textBox10.Name = "textBox10";
			textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox10.Size = new System.Drawing.Size(445, 201);
			textBox10.TabIndex = 10;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(9, 62);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(44, 17);
			label13.TabIndex = 9;
			label13.Text = "结果：";
			button25.Location = new System.Drawing.Point(426, 24);
			button25.Name = "button25";
			button25.Size = new System.Drawing.Size(82, 28);
			button25.TabIndex = 8;
			button25.Text = "批量读取";
			button25.UseVisualStyleBackColor = true;
			button25.Click += new System.EventHandler(button25_Click);
			textBox9.Location = new System.Drawing.Point(234, 27);
			textBox9.Name = "textBox9";
			textBox9.Size = new System.Drawing.Size(102, 23);
			textBox9.TabIndex = 7;
			textBox9.Text = "10";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(185, 30);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(44, 17);
			label12.TabIndex = 6;
			label12.Text = "长度：";
			textBox6.Location = new System.Drawing.Point(63, 27);
			textBox6.Name = "textBox6";
			textBox6.Size = new System.Drawing.Size(102, 23);
			textBox6.TabIndex = 5;
			textBox6.Text = "V100";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(9, 30);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(44, 17);
			label11.TabIndex = 4;
			label11.Text = "地址：";
			groupBox2.Controls.Add(label19);
			groupBox2.Controls.Add(button14);
			groupBox2.Controls.Add(button15);
			groupBox2.Controls.Add(button16);
			groupBox2.Controls.Add(button17);
			groupBox2.Controls.Add(button18);
			groupBox2.Controls.Add(button19);
			groupBox2.Controls.Add(button20);
			groupBox2.Controls.Add(button21);
			groupBox2.Controls.Add(button22);
			groupBox2.Controls.Add(button23);
			groupBox2.Controls.Add(button24);
			groupBox2.Controls.Add(textBox7);
			groupBox2.Controls.Add(label9);
			groupBox2.Controls.Add(textBox8);
			groupBox2.Controls.Add(label10);
			groupBox2.Location = new System.Drawing.Point(546, 3);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(419, 234);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "单数据写入测试";
			label19.ForeColor = System.Drawing.Color.Red;
			label19.Location = new System.Drawing.Point(61, 82);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(147, 58);
			label19.TabIndex = 17;
			label19.Text = "注意：值的字符串需要能转化成对应的数据类型";
			button14.Location = new System.Drawing.Point(326, 197);
			button14.Name = "button14";
			button14.Size = new System.Drawing.Size(82, 28);
			button14.TabIndex = 16;
			button14.Text = "字符串写入";
			button14.UseVisualStyleBackColor = true;
			button14.Click += new System.EventHandler(button14_Click);
			button15.Location = new System.Drawing.Point(326, 163);
			button15.Name = "button15";
			button15.Size = new System.Drawing.Size(82, 28);
			button15.TabIndex = 15;
			button15.Text = "double写入";
			button15.UseVisualStyleBackColor = true;
			button15.Click += new System.EventHandler(button15_Click);
			button16.Location = new System.Drawing.Point(226, 163);
			button16.Name = "button16";
			button16.Size = new System.Drawing.Size(82, 28);
			button16.TabIndex = 14;
			button16.Text = "float写入";
			button16.UseVisualStyleBackColor = true;
			button16.Click += new System.EventHandler(button16_Click);
			button17.Location = new System.Drawing.Point(326, 129);
			button17.Name = "button17";
			button17.Size = new System.Drawing.Size(82, 28);
			button17.TabIndex = 13;
			button17.Text = "ulong写入";
			button17.UseVisualStyleBackColor = true;
			button17.Click += new System.EventHandler(button17_Click);
			button18.Location = new System.Drawing.Point(226, 129);
			button18.Name = "button18";
			button18.Size = new System.Drawing.Size(82, 28);
			button18.TabIndex = 12;
			button18.Text = "long写入";
			button18.UseVisualStyleBackColor = true;
			button18.Click += new System.EventHandler(button18_Click);
			button19.Location = new System.Drawing.Point(326, 95);
			button19.Name = "button19";
			button19.Size = new System.Drawing.Size(82, 28);
			button19.TabIndex = 11;
			button19.Text = "uint写入";
			button19.UseVisualStyleBackColor = true;
			button19.Click += new System.EventHandler(button19_Click);
			button20.Location = new System.Drawing.Point(226, 95);
			button20.Name = "button20";
			button20.Size = new System.Drawing.Size(82, 28);
			button20.TabIndex = 10;
			button20.Text = "int写入";
			button20.UseVisualStyleBackColor = true;
			button20.Click += new System.EventHandler(button20_Click);
			button21.Location = new System.Drawing.Point(326, 61);
			button21.Name = "button21";
			button21.Size = new System.Drawing.Size(82, 28);
			button21.TabIndex = 9;
			button21.Text = "ushort写入";
			button21.UseVisualStyleBackColor = true;
			button21.Click += new System.EventHandler(button21_Click);
			button22.Location = new System.Drawing.Point(226, 61);
			button22.Name = "button22";
			button22.Size = new System.Drawing.Size(82, 28);
			button22.TabIndex = 8;
			button22.Text = "short写入";
			button22.UseVisualStyleBackColor = true;
			button22.Click += new System.EventHandler(button22_Click);
			button23.Location = new System.Drawing.Point(326, 24);
			button23.Name = "button23";
			button23.Size = new System.Drawing.Size(82, 28);
			button23.TabIndex = 7;
			button23.Text = "byte写入";
			button23.UseVisualStyleBackColor = true;
			button23.Click += new System.EventHandler(button23_Click);
			button24.Location = new System.Drawing.Point(226, 24);
			button24.Name = "button24";
			button24.Size = new System.Drawing.Size(82, 28);
			button24.TabIndex = 6;
			button24.Text = "bool写入";
			button24.UseVisualStyleBackColor = true;
			button24.Click += new System.EventHandler(button24_Click);
			textBox7.Location = new System.Drawing.Point(63, 56);
			textBox7.Name = "textBox7";
			textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox7.Size = new System.Drawing.Size(132, 23);
			textBox7.TabIndex = 5;
			textBox7.Text = "False";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(9, 58);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(32, 17);
			label9.TabIndex = 4;
			label9.Text = "值：";
			textBox8.Location = new System.Drawing.Point(63, 27);
			textBox8.Name = "textBox8";
			textBox8.Size = new System.Drawing.Size(132, 23);
			textBox8.TabIndex = 3;
			textBox8.Text = "V100";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(9, 30);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(44, 17);
			label10.TabIndex = 2;
			label10.Text = "地址：";
			groupBox1.Controls.Add(textBox1);
			groupBox1.Controls.Add(textBox5);
			groupBox1.Controls.Add(button_read_string);
			groupBox1.Controls.Add(button_read_double);
			groupBox1.Controls.Add(button_read_float);
			groupBox1.Controls.Add(button_read_ulong);
			groupBox1.Controls.Add(button_read_long);
			groupBox1.Controls.Add(button_read_uint);
			groupBox1.Controls.Add(button_read_int);
			groupBox1.Controls.Add(button_read_ushort);
			groupBox1.Controls.Add(button_read_short);
			groupBox1.Controls.Add(button_read_byte);
			groupBox1.Controls.Add(button_read_bool);
			groupBox1.Controls.Add(textBox4);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(textBox3);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(label8);
			groupBox1.Location = new System.Drawing.Point(11, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(518, 234);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "单数据读取测试";
			textBox1.Location = new System.Drawing.Point(260, 27);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(41, 23);
			textBox1.TabIndex = 19;
			textBox1.Text = "1";
			textBox5.Location = new System.Drawing.Point(358, 195);
			textBox5.Name = "textBox5";
			textBox5.Size = new System.Drawing.Size(41, 23);
			textBox5.TabIndex = 17;
			textBox5.Text = "10";
			button_read_string.Location = new System.Drawing.Point(415, 192);
			button_read_string.Name = "button_read_string";
			button_read_string.Size = new System.Drawing.Size(82, 28);
			button_read_string.TabIndex = 16;
			button_read_string.Text = "字符串读取";
			button_read_string.UseVisualStyleBackColor = true;
			button_read_string.Click += new System.EventHandler(button_read_string_Click);
			button_read_double.Location = new System.Drawing.Point(415, 158);
			button_read_double.Name = "button_read_double";
			button_read_double.Size = new System.Drawing.Size(82, 28);
			button_read_double.TabIndex = 15;
			button_read_double.Text = "double读取";
			button_read_double.UseVisualStyleBackColor = true;
			button_read_double.Click += new System.EventHandler(button_read_double_Click);
			button_read_float.Location = new System.Drawing.Point(315, 158);
			button_read_float.Name = "button_read_float";
			button_read_float.Size = new System.Drawing.Size(82, 28);
			button_read_float.TabIndex = 14;
			button_read_float.Text = "float读取";
			button_read_float.UseVisualStyleBackColor = true;
			button_read_float.Click += new System.EventHandler(button_read_float_Click);
			button_read_ulong.Location = new System.Drawing.Point(415, 124);
			button_read_ulong.Name = "button_read_ulong";
			button_read_ulong.Size = new System.Drawing.Size(82, 28);
			button_read_ulong.TabIndex = 13;
			button_read_ulong.Text = "ulong读取";
			button_read_ulong.UseVisualStyleBackColor = true;
			button_read_ulong.Click += new System.EventHandler(button_read_ulong_Click);
			button_read_long.Location = new System.Drawing.Point(315, 124);
			button_read_long.Name = "button_read_long";
			button_read_long.Size = new System.Drawing.Size(82, 28);
			button_read_long.TabIndex = 12;
			button_read_long.Text = "long读取";
			button_read_long.UseVisualStyleBackColor = true;
			button_read_long.Click += new System.EventHandler(button_read_long_Click);
			button_read_uint.Location = new System.Drawing.Point(415, 90);
			button_read_uint.Name = "button_read_uint";
			button_read_uint.Size = new System.Drawing.Size(82, 28);
			button_read_uint.TabIndex = 11;
			button_read_uint.Text = "uint读取";
			button_read_uint.UseVisualStyleBackColor = true;
			button_read_uint.Click += new System.EventHandler(button_read_uint_Click);
			button_read_int.Location = new System.Drawing.Point(315, 90);
			button_read_int.Name = "button_read_int";
			button_read_int.Size = new System.Drawing.Size(82, 28);
			button_read_int.TabIndex = 10;
			button_read_int.Text = "int读取";
			button_read_int.UseVisualStyleBackColor = true;
			button_read_int.Click += new System.EventHandler(button_read_int_Click);
			button_read_ushort.Location = new System.Drawing.Point(415, 56);
			button_read_ushort.Name = "button_read_ushort";
			button_read_ushort.Size = new System.Drawing.Size(82, 28);
			button_read_ushort.TabIndex = 9;
			button_read_ushort.Text = "ushort读取";
			button_read_ushort.UseVisualStyleBackColor = true;
			button_read_ushort.Click += new System.EventHandler(button_read_ushort_Click);
			button_read_short.Location = new System.Drawing.Point(315, 56);
			button_read_short.Name = "button_read_short";
			button_read_short.Size = new System.Drawing.Size(82, 28);
			button_read_short.TabIndex = 8;
			button_read_short.Text = "short读取";
			button_read_short.UseVisualStyleBackColor = true;
			button_read_short.Click += new System.EventHandler(button_read_short_Click);
			button_read_byte.Location = new System.Drawing.Point(415, 19);
			button_read_byte.Name = "button_read_byte";
			button_read_byte.Size = new System.Drawing.Size(82, 28);
			button_read_byte.TabIndex = 7;
			button_read_byte.Text = "byte读取";
			button_read_byte.UseVisualStyleBackColor = true;
			button_read_byte.Click += new System.EventHandler(button_read_byte_Click);
			button_read_bool.Location = new System.Drawing.Point(315, 19);
			button_read_bool.Name = "button_read_bool";
			button_read_bool.Size = new System.Drawing.Size(82, 28);
			button_read_bool.TabIndex = 6;
			button_read_bool.Text = "bool读取";
			button_read_bool.UseVisualStyleBackColor = true;
			button_read_bool.Click += new System.EventHandler(button_read_bool_Click);
			textBox4.Location = new System.Drawing.Point(63, 56);
			textBox4.Multiline = true;
			textBox4.Name = "textBox4";
			textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox4.Size = new System.Drawing.Size(233, 164);
			textBox4.TabIndex = 5;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(9, 58);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(44, 17);
			label7.TabIndex = 4;
			label7.Text = "结果：";
			textBox3.Location = new System.Drawing.Point(63, 27);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(191, 23);
			textBox3.TabIndex = 3;
			textBox3.Text = "V100";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(9, 30);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(44, 17);
			label6.TabIndex = 2;
			label6.Text = "地址：";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(315, 198);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(44, 17);
			label8.TabIndex = 18;
			label8.Text = "长度：";
			userControlHead1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			userControlHead1.Dock = System.Windows.Forms.DockStyle.Top;
			userControlHead1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			userControlHead1.Location = new System.Drawing.Point(0, 0);
			userControlHead1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			userControlHead1.MinimumSize = new System.Drawing.Size(800, 32);
			userControlHead1.Name = "userControlHead1";
			userControlHead1.ProtocolInfo = "MPI";
			userControlHead1.Size = new System.Drawing.Size(1004, 32);
			userControlHead1.TabIndex = 2;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1004, 645);
			base.Controls.Add(userControlHead1);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "FormSiemensMPI";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "西门子PLC访问Demo";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormSiemens_FormClosing);
			base.Load += new System.EventHandler(FormSiemens_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
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
