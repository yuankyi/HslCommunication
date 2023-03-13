using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Core;
using System;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	public class DemoUtils
	{
		public static readonly string IpAddressInputWrong = "IpAddress input wrong";

		public static readonly string PortInputWrong = "Port input wrong";

		public static readonly string SlotInputWrong = "Slot input wrong";

		public static readonly string BaudRateInputWrong = "Baud rate input wrong";

		public static readonly string DataBitsInputWrong = "Data bit input wrong";

		public static readonly string StopBitInputWrong = "Stop bit input wrong";

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

		public static void ReadResultRender<T>(OperateResult<T> result, string address, TextBox textBox)
		{
			if (result.IsSuccess)
			{
				if (((object)result.Content) is Array)
				{
					textBox.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[" + address + "] " + SoftBasic.ArrayFormat(result.Content) + Environment.NewLine);
				}
				else
				{
					textBox.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + string.Format("[{0}] {1}{2}", address, result.Content, Environment.NewLine));
				}
			}
			else
			{
				MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + "[" + address + "] Read Failed " + Environment.NewLine + "Reason：" + result.ToMessageShowString());
			}
		}

		public static void WriteResultRender(OperateResult result, string address)
		{
			if (result.IsSuccess)
			{
				MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + "[" + address + "] Write Success");
			}
			else
			{
				MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + "[" + address + "] Write Failed " + Environment.NewLine + " Reason：" + result.ToMessageShowString());
			}
		}

		public static void WriteResultRender(OperateResult result)
		{
			if (result.IsSuccess)
			{
				MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + "Success");
			}
			else
			{
				MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + "Failed " + Environment.NewLine + " Reason：" + result.ToMessageShowString());
			}
		}

		public static void WriteResultRender(Func<OperateResult> write, string address)
		{
			try
			{
				OperateResult operateResult = write();
				if (operateResult.IsSuccess)
				{
					MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + "[" + address + "] Write Success");
				}
				else
				{
					MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + "[" + address + "] Write Failed " + Environment.NewLine + " Reason：" + operateResult.ToMessageShowString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Data for writting is not corrent: " + ex.Message);
			}
		}

		public static void BulkReadRenderResult(IReadWriteNet readWrite, TextBox addTextBox, TextBox lengthTextBox, TextBox resultTextBox)
		{
			try
			{
				OperateResult<byte[]> operateResult = readWrite.Read(addTextBox.Text, ushort.Parse(lengthTextBox.Text));
				if (operateResult.IsSuccess)
				{
					resultTextBox.Text = "Result：" + SoftBasic.ByteToHexString(operateResult.Content);
				}
				else
				{
					MessageBox.Show("Read Failed：" + operateResult.ToMessageShowString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Read Failed：" + ex.Message);
			}
		}

		public static void AppendTextBox(TextBox textBox, string key, string message, int maxKeyLength = -1)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "] ");
			if (!string.IsNullOrEmpty(key))
			{
				stringBuilder.Append("[" + key + "] ");
			}
			stringBuilder.Append(message);
			stringBuilder.Append(Environment.NewLine);
			textBox.AppendText(stringBuilder.ToString());
		}

		public static OperateResult<int> ParseInt(string text)
		{
			try
			{
				if (text.StartsWith("0x") || text.StartsWith("0X"))
				{
					return OperateResult.CreateSuccessResult(Convert.ToInt32(text.Substring(2), 16));
				}
				return OperateResult.CreateSuccessResult(Convert.ToInt32(text));
			}
			catch (Exception ex)
			{
				return new OperateResult<int>("Convert Int Failed: " + ex.Message);
			}
		}

		public static string[] GetEncodings()
		{
			return new string[7]
			{
				"ASCII",
				"Unicode",
				"Unicode-big",
				"UTF8",
				"UTF32",
				"ANSI",
				"GB2312"
			};
		}

		public static Encoding GetEncodingFromIndex(int index)
		{
			switch (index)
			{
			case 0:
				return Encoding.ASCII;
			case 1:
				return Encoding.Unicode;
			case 2:
				return Encoding.BigEndianUnicode;
			case 3:
				return Encoding.UTF8;
			case 4:
				return Encoding.UTF32;
			case 5:
				return Encoding.Default;
			case 6:
				return Encoding.GetEncoding("gb2312");
			default:
				return Encoding.ASCII;
			}
		}
	}
}
