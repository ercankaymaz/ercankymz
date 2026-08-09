using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class PlcDeviceData : buSerilization
{
	public string CustomerName = "CMD";

	public string IPNumber = "172.16.39.2";

	public string DeviceAddress = "0";

	public string DeviceAddressSecond = "0";

	public string DeviceName = "";

	public string DeviceNameSecond = "";

	public bool UseSecondDeviceName = false;

	public bool ConnectMethodByIP = true;

	public string FtpUser = "Admin";

	public string FtpPassword = "";

	public string pathDeviceVariable = "\\Hard Disk\\Project";

	public string pathDeviceSend = "\\Project";

	public string pathCncFileName = "Cncfile.cnc";

	public string pathSystemSetFileName = "SystemSet.prm";

	public int FtpPort = 21;

	public bool UseSFtpProtocole = false;

	public CommunicationType CommType = CommunicationType.PlcHandler;

	public string RootGlobalString = "Application.gvlGlobal.";

	public string RootIOString = "Application.gvlIO.";

	public string RootHardwareString = "Application.gvlHardware.";

	public string RootCNCString = "Application.gvlCNC.";

	public string RootPersistentString = "Application.PersistentVars.";

	public string RootRetainString = "Application.PersistentVars.";

	public int ThreadWaitCount = 0;

	public PlcDeviceData()
	{
	}

	public PlcDeviceData(PlcDeviceData data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return "IP: " + IPNumber;
	}
}
