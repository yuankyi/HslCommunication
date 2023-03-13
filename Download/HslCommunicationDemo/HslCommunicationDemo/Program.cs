using HslCommunication;
using HslCommunication.BasicFramework;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
	internal static class Program
	{
		public static int Language = 1;

		public static bool ShowAuthorInfomation = true;

		public static DateTime StartTime = DateTime.Now;

		public static string SystemName = "工业设备联网调试系统";

		public static bool IsActive
		{
			get;
			private set;
		}

		[STAThread]
		private static void Main()
		{
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			if (Authorization.SetAuthorizationCode("Your Code"))
			{
				IsActive = true;
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			ThreadPool.SetMaxThreads(2000, 800);
			Application.Run(new FormMain());
		}

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Exception ex = e.ExceptionObject as Exception;
			File.WriteAllText("123.txt", SoftBasic.GetExceptionMessage(ex));
		}
	}
}
