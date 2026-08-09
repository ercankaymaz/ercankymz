using System;
using System.Collections.Generic;
using System.Management;
using System.Net.NetworkInformation;

namespace buCore;

public class buCommon
{
	public static string getCpuID(ref List<string> CpuAddress)
	{
		string text = "";
		try
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select ProcessorID From Win32_processor");
			ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			foreach (ManagementObject item in managementObjectCollection)
			{
				text = item["ProcessorID"].ToString();
				CpuAddress.Add(text);
			}
			return text;
		}
		catch (Exception)
		{
			return text;
		}
	}

	public static string getHddID(ref List<string> HddAddress)
	{
		ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
		HddAddress.Clear();
		foreach (ManagementObject item2 in managementObjectSearcher.Get())
		{
			if (item2["SerialNumber"] != null)
			{
				string item = item2["SerialNumber"].ToString();
				HddAddress.Add(item);
			}
		}
		return "";
	}

	public static void getMacAddress(ref List<string> MacAddress)
	{
		MacAddress.Clear();
		NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
		for (int i = 0; i <= allNetworkInterfaces.Length - 1; i++)
		{
			string text = allNetworkInterfaces[i].GetPhysicalAddress().ToString();
			if (((text.Length == 12) & ((allNetworkInterfaces[i].NetworkInterfaceType == NetworkInterfaceType.Ethernet) | (allNetworkInterfaces[i].NetworkInterfaceType == NetworkInterfaceType.Wireless80211))) && text.Substring(0, 4) != "0000")
			{
				MacAddress.Add(text);
			}
		}
	}
}
