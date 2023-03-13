using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace HslCommunicationDemo
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.2.0.0")]
	internal sealed class Settings1 : ApplicationSettingsBase
	{
		private static Settings1 defaultInstance = (Settings1)SettingsBase.Synchronized(new Settings1());

		public static Settings1 Default
		{
			get
			{
				return defaultInstance;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("1")]
		public int language
		{
			get
			{
				return (int)this["language"];
			}
			set
			{
				this["language"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool UseAdmin
		{
			get
			{
				return (bool)this["UseAdmin"];
			}
			set
			{
				this["UseAdmin"] = value;
			}
		}
	}
}
