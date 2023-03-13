using HslCommunication.BasicFramework;
using HslCommunication.LogNet;
using HslCommunicationDemo.Control;
using HslCommunicationDemo.DemoControl;
using System;
using System.Windows.Forms;
using System.Xml.Linq;
using WeifenLuo.WinFormsUI.Docking;

namespace HslCommunicationDemo
{
	public class HslFormContent : DockContent
	{
		private XElement xElement = null;

		public ILogNet LogNet
		{
			get;
			set;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			AutoScroll = true;
		}

		public virtual void LoadXmlParameter(XElement element)
		{
			xElement = element;
			Text = xElement.Attribute(DemoDeviceList.XmlName).Value;
		}

		public virtual void SaveXmlParameter(XElement element)
		{
			throw new NotImplementedException("SaveXmlParameter Not Implemented");
		}

		public void userControlHead1_SaveConnectEvent(object sender, EventArgs e)
		{
			try
			{
				if (xElement == null)
				{
					using (FormInputString formInputString = new FormInputString())
					{
						if (formInputString.ShowDialog() == DialogResult.OK)
						{
							xElement = new XElement("Device");
							xElement.SetAttributeValue(DemoDeviceList.XmlGuid, Guid.NewGuid().ToString("N"));
							xElement.SetAttributeValue(DemoDeviceList.XmlType, GetType().Name);
							xElement.SetAttributeValue(DemoDeviceList.XmlName, formInputString.DeviceAlias);
							SaveXmlParameter(xElement);
							FormMain form = FormMain.Form;
							if (form != null)
							{
								FormSaveList panelLeft = form.GetPanelLeft();
								if (panelLeft != null)
								{
									panelLeft.AddDeviceList(xElement);
								}
							}
							MessageBox.Show("Save Success");
						}
					}
				}
				else
				{
					SaveXmlParameter(xElement);
					FormMain form2 = FormMain.Form;
					if (form2 != null)
					{
						FormSaveList panelLeft2 = form2.GetPanelLeft();
						if (panelLeft2 != null)
						{
							panelLeft2.AddDeviceList(xElement);
						}
					}
				}
			}
			catch (Exception ex)
			{
				SoftBasic.ShowExceptionMessage("Save failed:", ex);
			}
		}
	}
}
