// Decompiled with JetBrains decompiler
// Type: buCore.buCommon
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;
using System.Collections.Generic;
using System.Management;
using System.Net.NetworkInformation;

#nullable disable
namespace buCore;

public class buCommon
{
  public static string getCpuID(ref List<string> CpuAddress)
  {
    string cpuId = "";
    try
    {
      foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("Select ProcessorID From Win32_processor").Get())
      {
        cpuId = managementBaseObject["ProcessorID"].ToString();
        CpuAddress.Add(cpuId);
      }
      return cpuId;
    }
    catch (Exception ex)
    {
      return cpuId;
    }
  }

  public static string getHddID(ref List<string> HddAddress)
  {
    ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
    HddAddress.Clear();
    foreach (ManagementObject managementObject in managementObjectSearcher.Get())
    {
      if (managementObject["SerialNumber"] != null)
      {
        string str = managementObject["SerialNumber"].ToString();
        HddAddress.Add(str);
      }
    }
    return "";
  }

  public static void getMacAddress(ref List<string> MacAddress)
  {
    MacAddress.Clear();
    NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
    for (int index = 0; index <= networkInterfaces.Length - 1; ++index)
    {
      string str = networkInterfaces[index].GetPhysicalAddress().ToString();
      if (str.Length == 12 & (networkInterfaces[index].NetworkInterfaceType == NetworkInterfaceType.Ethernet | networkInterfaces[index].NetworkInterfaceType == NetworkInterfaceType.Wireless80211) && str.Substring(0, 4) != "0000")
        MacAddress.Add(str);
    }
  }
}
