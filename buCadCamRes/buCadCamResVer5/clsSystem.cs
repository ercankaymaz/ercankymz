// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.clsSystem
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buCadCamResVer5.Misc;
using buCadCamResVer5.Nesting;
using buClass;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5;

public class clsSystem
{
  public clsSystem()
  {
    if (!clsSystem.smethod_0(nameof (clsSystem)))
      throw new RegisterException(nameof (clsSystem));
  }

  internal static bool smethod_0(string string_0)
  {
    BinaryReader binaryReader = (BinaryReader) null;
    try
    {
      FileInfo fileInfo = new FileInfo(AppPath.Base + "\\mnbucfd.dll");
      if (!fileInfo.Exists)
        throw new RegisterException($"{string_0} - {AppPath.Base}");
      if (fileInfo.Exists)
      {
        List<double> list_0 = new List<double>();
        List<string> stringList1 = new List<string>();
        List<string> stringList2 = new List<string>();
        bool flag1;
        bool flag2;
        try
        {
          buLogVer5.addToLog("DefK", "Mode 12100", "mnb", "1", 0.0, 0.0);
          binaryReader = new BinaryReader((Stream) new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.None));
          string str1 = "";
          string str2 = "";
          string str3 = "";
          string str4 = "";
          string str5 = "";
          string str6 = "";
          string str7 = "";
          string str8 = "";
          string str9 = "";
          string str10 = "";
          string str11 = "";
          string str12 = "";
          string str13 = "";
          string str14 = "";
          Decimal num1 = 0M;
          for (int index = 0; index < 755; ++index)
          {
            double num2 = (double) binaryReader.ReadSingle();
          }
          for (int index = 0; index < 1274; ++index)
            binaryReader.ReadDouble();
          for (int index = 0; index < 1498; ++index)
            num1 = binaryReader.ReadDecimal();
          for (int index = 0; index < 5614; ++index)
          {
            double num3 = (double) binaryReader.ReadInt32();
          }
          for (int index = 0; index < 4243; ++index)
          {
            double num4 = (double) binaryReader.ReadSingle();
          }
          for (int index = 0; index < 9867; ++index)
            binaryReader.ReadDouble();
          for (int index = 0; index < 3886; ++index)
            num1 = binaryReader.ReadDecimal();
          for (int index = 0; index < 5765; ++index)
          {
            double num5 = (double) binaryReader.ReadInt32();
          }
          int num6 = binaryReader.ReadInt32();
          list_0.Clear();
          stringList1.Clear();
          stringList2.Clear();
          for (int index1 = 0; index1 <= num6 - 1; ++index1)
          {
            double num7 = binaryReader.ReadDouble() / 65.87;
            list_0.Add(num7);
            int num8 = binaryReader.ReadInt32();
            string str15 = "";
            for (int index2 = 0; index2 < num8; ++index2)
            {
              byte num9 = Convert.ToByte(binaryReader.ReadDouble() / 46.8613);
              str15 += Convert.ToChar(num9).ToString();
            }
            stringList1.Add(str15);
            int num10 = binaryReader.ReadInt32();
            string str16 = "";
            for (int index3 = 0; index3 < num10; ++index3)
            {
              byte num11 = Convert.ToByte(binaryReader.ReadDouble() / 86.3456);
              str16 += Convert.ToChar(num11).ToString();
            }
            stringList2.Add(str16);
          }
          int num12 = binaryReader.ReadInt32();
          for (int index = 0; index < num12; ++index)
          {
            byte num13 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str1 += Convert.ToChar(num13).ToString();
          }
          int num14 = binaryReader.ReadInt32();
          for (int index = 0; index < num14; ++index)
          {
            byte num15 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str2 += Convert.ToChar(num15).ToString();
          }
          int num16 = binaryReader.ReadInt32();
          for (int index = 0; index < num16; ++index)
          {
            byte num17 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str3 += Convert.ToChar(num17).ToString();
          }
          int num18 = binaryReader.ReadInt32();
          for (int index = 0; index < num18; ++index)
          {
            byte num19 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str4 += Convert.ToChar(num19).ToString();
          }
          int num20 = binaryReader.ReadInt32();
          for (int index = 0; index < num20; ++index)
          {
            byte num21 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str5 += Convert.ToChar(num21).ToString();
          }
          int num22 = binaryReader.ReadInt32();
          for (int index = 0; index < num22; ++index)
          {
            byte num23 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str6 += Convert.ToChar(num23).ToString();
          }
          int num24 = binaryReader.ReadInt32();
          for (int index = 0; index < num24; ++index)
          {
            byte num25 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str7 += Convert.ToChar(num25).ToString();
          }
          int num26 = binaryReader.ReadInt32();
          for (int index = 0; index < num26; ++index)
          {
            byte num27 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str8 += Convert.ToChar(num27).ToString();
          }
          int num28 = binaryReader.ReadInt32();
          for (int index = 0; index < num28; ++index)
          {
            byte num29 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str9 += Convert.ToChar(num29).ToString();
          }
          binaryReader.ReadDouble();
          binaryReader.ReadDouble();
          binaryReader.ReadDouble();
          binaryReader.ReadDouble();
          binaryReader.ReadDouble();
          binaryReader.ReadDouble();
          binaryReader.ReadDouble();
          binaryReader.ReadDouble();
          binaryReader.ReadDouble();
          int num30 = binaryReader.ReadInt32();
          for (int index = 0; index < num30; ++index)
          {
            byte num31 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
            str10 += Convert.ToChar(num31).ToString();
          }
          int num32 = binaryReader.ReadInt32();
          for (int index = 0; index < num32; ++index)
          {
            byte num33 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
            str11 += Convert.ToChar(num33).ToString();
          }
          int num34 = binaryReader.ReadInt32();
          for (int index = 0; index < num34; ++index)
          {
            byte num35 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
            str12 += Convert.ToChar(num35).ToString();
          }
          int num36 = binaryReader.ReadInt32();
          for (int index = 0; index < num36; ++index)
          {
            byte num37 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
            str13 += Convert.ToChar(num37).ToString();
          }
          int num38 = binaryReader.ReadInt32();
          for (int index = 0; index < num38; ++index)
          {
            byte num39 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
            str14 += Convert.ToChar(num39).ToString();
          }
          binaryReader.ReadDouble();
          binaryReader.ReadDouble();
          binaryReader.ReadDouble();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          flag1 = binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          flag2 = binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadDouble();
          binaryReader.ReadDouble();
          binaryReader.ReadDouble();
          binaryReader.Close();
          buLogVer5.addToLog("DefK", "Mode 12101", "mnb", "100", 0.0, 0.0);
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message);
          binaryReader.Close();
          throw new RegisterException(string_0);
        }
        if (!flag1 & !flag2)
        {
          List<string> MacAddress = new List<string>();
          List<string> CpuAddress = new List<string>();
          string MBAddress = "";
          clsSystem.getMacAddress(ref MacAddress);
          buLogVer5.addToLog("DefK", "Mode 12102", "mnb", "100", 0.0, 0.0);
          clsSystem.getCpuID(ref CpuAddress);
          buLogVer5.addToLog("DefK", "Mode 12103", "mnb", "100", 0.0, 0.0);
          clsSystem.GetMotherBoardID(ref MBAddress);
          buLogVer5.addToLog("DefK", "Mode 12104", "mnb", "100", 0.0, 0.0);
          buLogVer5.addToLog("DefK", "Mode 12104_0", "mnb", "100", 0.0, 0.0);
          bool flag3 = clsSystem.smethod_1(list_0, MacAddress, CpuAddress, MBAddress, string_0);
          buLogVer5.addToLog("DefK", "Mode 12104_1", "mnb", "100", 0.0, 0.0);
          if (flag3)
          {
            buVector5.AskMeResult = "TesxCEguItdxXery89+dxdx+456(9004dxXXx5678X4Dfgytex &7fdxHRewxWw2";
            buVector5.AskMeValue = -5861345679435.9121;
            buVector.AskMeResult = "TesxCEguItdxXery89+dxdx+456(9004dxXXx5678X4Dfgytex &7fdxHRewxWw2";
            buVector.AskMeValue = -5861345679435.9121;
            return true;
          }
          buString.MessageBoxError("No Valid License Available");
        }
        else if (flag1)
        {
          string Code = "";
          buLogVer5.addToLog("DefK", "Mode 12105_0", "mnb", "100", 0.0, 0.0);
          bool flag4 = clsHasp.InitHsKey(ref Code);
          buLogVer5.addToLog("DefK", "Mode 12105_1", "mnb", "100", 0.0, 0.0);
          if (flag4)
          {
            buVector5.AskMeResult = "TesxCEguItdxXery89+dxdx+456(9004dxXXx5678X4Dfgytex &7fdxHRewxWw2";
            buVector5.AskMeValue = -5861345679435.9121;
            buVector.AskMeResult = "TesxCEguItdxXery89+dxdx+456(9004dxXXx5678X4Dfgytex &7fdxHRewxWw2";
            buVector.AskMeValue = -5861345679435.9121;
            return true;
          }
          buString.MessageBoxError("No License Dongle Available");
        }
        else if (flag2)
        {
          buLogVer5.addToLog("DefK", "Mode 12106_0", "mnb", "100", 0.0, 0.0);
          clsInit.appNesting = new clsNesting("DontCheckLicKeyBro");
          buLogVer5.addToLog("DefK", "Mode 12106_1", "mnb", "100", 0.0, 0.0);
          clsInit.appNesting.Init();
          buLogVer5.addToLog("DefK", "Mode 12106_2", "mnb", "100", 0.0, 0.0);
          bool flag5 = clsInit.appNestingPower.isDongleAvailable();
          buLogVer5.addToLog("DefK", "Mode 12106_3", "mnb", "100", 0.0, 0.0);
          if (!flag5)
          {
            buString.MessageBoxError("No Nesting Dongle Available");
          }
          else
          {
            buVector5.AskMeResult = "TesxCEguItdxXery89+dxdx+456(9004dxXXx5678X4Dfgytex &7fdxHRewxWw2";
            buVector5.AskMeValue = -5861345679435.9121;
            buVector.AskMeResult = "TesxCEguItdxXery89+dxdx+456(9004dxXXx5678X4Dfgytex &7fdxHRewxWw2";
            buVector.AskMeValue = -5861345679435.9121;
            return true;
          }
        }
        buLogVer5.addToLog("DefK", "Mode 12107_0", "mnb", "100", 0.0, 0.0);
        throw new RegisterException(string_0);
      }
      throw new RegisterException(string_0);
    }
    catch (Exception ex)
    {
      throw new RegisterException(string_0);
    }
  }

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
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return "";
    }
  }

  public static string GetMotherBoardID(ref string MBAddress)
  {
    MBAddress = "";
    ManagementScope scope = new ManagementScope($"\\\\{Environment.MachineName}\\root\\cimv2");
    scope.Connect();
    foreach (PropertyData property in new ManagementObject(scope, new ManagementPath("Win32_BaseBoard.Tag=\"Base Board\""), new ObjectGetOptions()).Properties)
    {
      if (property.Name == "SerialNumber")
        MBAddress = $"{property.Name,-25}{Convert.ToString(property.Value)}";
    }
    return "";
  }

  public static void getMacAddress(ref List<string> MacAddress)
  {
    try
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
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static string getHddID(ref List<string> HddAddress)
  {
    try
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
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return "";
    }
  }

  public static string getDisplayID(ref List<string> DisplayAddress)
  {
    try
    {
      DisplayAddress.Clear();
      DisplayAddress.Add("YTRcae46746fDSw");
      DisplayAddress.Add("Awry876y54fds");
      DisplayAddress.Add("Eryvdw894342fV");
      return "";
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return "";
    }
  }

  private static bool smethod_1(
    List<double> list_0,
    List<string> list_1,
    List<string> list_2,
    string string_0,
    string string_1)
  {
    if (list_1.Count > 0 & list_2.Count > 0)
    {
      for (int index1 = 0; index1 <= list_1.Count - 1; ++index1)
      {
        double num1 = 0.0;
        double num2 = 0.0;
        double num3 = 0.0;
        for (int startIndex = 0; startIndex <= list_1[index1].Length - 1; ++startIndex)
        {
          double num4 = (double) Convert.ToByte(Convert.ToChar(list_1[index1].Substring(startIndex, 1)));
          num1 += num4 * 17.92;
        }
        for (int startIndex = 0; startIndex <= list_2[0].Length - 1; ++startIndex)
        {
          double num5 = (double) Convert.ToByte(Convert.ToChar(list_2[0].Substring(startIndex, 1)));
          num2 += num5 * 47.93;
        }
        for (int startIndex = 0; startIndex <= string_0.Length - 1; ++startIndex)
        {
          double num6 = (double) Convert.ToByte(Convert.ToChar(string_0.Substring(startIndex, 1)));
          num3 += num6 * 51.95;
        }
        double num7 = (num1 + num2 + num3) * 9.912;
        for (int index2 = 0; index2 <= list_0.Count - 1; ++index2)
        {
          if (Math.Abs(list_0[index2] - num7) < 0.0001)
          {
            clsVar.appDefination.ProgramCode = num7.ToString();
            return true;
          }
        }
      }
      buString.MessageBoxError("No Valid License Available");
      throw new RegisterException(string_1);
    }
    buString.MessageBoxError("No Valid License Available");
    throw new RegisterException(string_1);
  }

  public bool ReadHK(bool bdevfile)
  {
    string Code = "";
    bool flag;
    if (!clsHasp.InitHsKey(ref Code))
    {
      flag = bdevfile;
    }
    else
    {
      string[] strArr = HaspDemo.KeyCode.Split('-');
      if (strArr.Length >= 5)
      {
        buLog.addLog("ReadKey", "Ok", MethodBase.GetCurrentMethod().Name);
        flag = clsInit.appSystem.DecodeKeyCode(strArr) && (!clsVar.appModes_0.WorkAtMotionPC || new FileInfo(Environment.SystemDirectory + "\\bumotsys55.dll").Exists);
      }
      else
        flag = false;
    }
    return flag;
  }

  public void SetTr(double Mode)
  {
    RegistryKey subKey1 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Tdw");
    if (subKey1 != null)
    {
      subKey1.SetValue("Name", (object) "tqwr");
      subKey1.SetValue(nameof (Mode), (object) 0);
      subKey1.SetValue("Type1", (object) 145.145);
      subKey1.SetValue("Type2", (object) 164.18);
      subKey1.SetValue("Type3", (object) 195.16);
      subKey1.SetValue("Type4", (object) 1822.65);
      subKey1.SetValue("Type5", (object) Mode);
      subKey1.SetValue("Type6", (object) -1456.135);
      subKey1.SetValue("Type7", (object) 1743.765);
      subKey1.SetValue("Type8", (object) 685.486);
      subKey1.SetValue("Type9", (object) 185.2667);
      subKey1.SetValue("Type10", (object) 9356.24);
      subKey1.SetValue("Active", (object) 1);
      subKey1.SetValue("Time", (object) 1);
      subKey1.SetValue("Timeout", (object) 1);
      subKey1.SetValue("TimeZone", (object) 2);
      subKey1.Close();
    }
    RegistryKey subKey2 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Wingate");
    if (subKey2 == null)
      return;
    subKey2.SetValue("Name", (object) "yrewf");
    subKey2.SetValue("Run", (object) 0);
    subKey2.SetValue("Sets1", (object) 425.565);
    subKey2.SetValue("Sets2", (object) 157.185);
    subKey2.SetValue("Sets3", (object) 92.786);
    subKey2.SetValue("Sets4", (object) -135.678);
    subKey2.SetValue("Sets5", (object) Mode);
    subKey2.SetValue("Sets6", (object) 578.18544);
    subKey2.SetValue("Sets7", (object) 588.1234);
    subKey2.SetValue("Sets8", (object) 1095.688);
    subKey2.SetValue("Sets9", (object) 2567.678);
    subKey2.SetValue("Sets10", (object) 8266.345);
    subKey2.SetValue("Active", (object) 1);
    subKey2.SetValue("Available", (object) 2);
    subKey2.SetValue("Tip", (object) 1);
    subKey2.SetValue("Done", (object) 2);
    subKey2.SetValue("Reset", (object) 1);
    subKey2.SetValue("Play", (object) 0);
    subKey2.Close();
  }

  public void ResetTr()
  {
    try
    {
      RegistryKey subKey1 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Tdw");
      try
      {
        subKey1.DeleteValue("Name");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey1.DeleteValue("Mode");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey1.DeleteValue("Type1");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey1.DeleteValue("Type2");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey1.DeleteValue("Type3");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey1.DeleteValue("Type4");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey1.DeleteValue("Type5");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey1.DeleteValue("Type6");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey1.DeleteValue("Type7");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey1.DeleteValue("Type8");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey1.DeleteValue("Type9");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey1.DeleteValue("Type10");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey1.DeleteValue("Active");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey1.DeleteValue("Time");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey1.DeleteValue("Timeout");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey1.DeleteValue("TimeZone");
      }
      catch (Exception ex)
      {
      }
      subKey1.Close();
      RegistryKey subKey2 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Wingate");
      try
      {
        subKey2.DeleteValue("Name");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey2.DeleteValue("Run");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey2.DeleteValue("Sets1");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey2.DeleteValue("Sets2");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey2.DeleteValue("Sets3");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey2.DeleteValue("Sets4");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey2.DeleteValue("Sets5");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey2.DeleteValue("Sets6");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey2.DeleteValue("Sets7");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey2.DeleteValue("Sets8");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey2.DeleteValue("Sets9");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey2.DeleteValue("Sets10");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey2.DeleteValue("Active");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey2.DeleteValue("Available");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey2.DeleteValue("Tip");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey2.DeleteValue("Done");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey2.DeleteValue("Reset");
      }
      catch (Exception ex)
      {
      }
      try
      {
        subKey2.DeleteValue("Play");
      }
      catch (Exception ex)
      {
      }
      subKey2.Close();
    }
    catch (Exception ex)
    {
    }
  }

  public void CheckTr()
  {
    RegistryKey registryKey1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Tdw");
    if (registryKey1 != null)
    {
      object obj1 = registryKey1.GetValue("Mode");
      object obj2 = registryKey1.GetValue("Type5");
      object obj3 = registryKey1.GetValue("Type8");
      if (obj2 != null)
      {
        double num = Convert.ToDouble(obj2);
        if (num == 567.001)
        {
          buString.MessageBoxWarning("Trial Time Period has been Over ID:001");
          registryKey1.Close();
          clsVar.appModes_0.TimePeriodExpire = true;
          return;
        }
        if (num == 567.002)
        {
          buString.MessageBoxWarning("Illegal Usage Detected ID:002");
          Environment.Exit(0);
          registryKey1.Close();
          return;
        }
        if (num == 567.003)
        {
          buString.MessageBoxWarning("Registration Error ID:003");
          Environment.Exit(0);
          registryKey1.Close();
          return;
        }
      }
      if (obj3 != null && Convert.ToDouble(obj3) == 685.486)
      {
        buString.MessageBoxWarning("Trial Time Period has been Over ID:001");
        registryKey1.Close();
        clsVar.appModes_0.TimePeriodExpire = true;
        return;
      }
      if (obj1 != null)
      {
        buString.MessageBoxWarning("Trial Time Period has been Over ID:001");
        registryKey1.Close();
        clsVar.appModes_0.TimePeriodExpire = true;
        return;
      }
      registryKey1.Close();
    }
    RegistryKey registryKey2 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Wingate");
    if (registryKey2 == null)
      return;
    object obj4 = registryKey2.GetValue("Sets5");
    object obj5 = registryKey2.GetValue("Sets8");
    object obj6 = registryKey2.GetValue("Active");
    if (obj4 != null)
    {
      double num = Convert.ToDouble(obj4);
      if (num == 567.001)
      {
        buString.MessageBoxWarning("Trial Time Period has been Over ID:001");
        registryKey2.Close();
        clsVar.appModes_0.TimePeriodExpire = true;
        return;
      }
      if (num == 567.002)
      {
        buString.MessageBoxWarning("Illegal Usage Detected ID:002");
        Environment.Exit(0);
        registryKey1.Close();
        return;
      }
      if (num == 567.003)
      {
        buString.MessageBoxWarning("Registration Error ID:003");
        Environment.Exit(0);
        registryKey1.Close();
        return;
      }
    }
    if (obj5 != null && Convert.ToDouble(obj5) == 1095.688)
    {
      buString.MessageBoxWarning("Trial Time Period has been Over ID:001");
      registryKey2.Close();
      clsVar.appModes_0.TimePeriodExpire = true;
    }
    else if (obj6 != null)
    {
      buString.MessageBoxWarning("Trial Time Period has been Over ID:001");
      registryKey2.Close();
      clsVar.appModes_0.TimePeriodExpire = true;
    }
    else
      registryKey2.Close();
  }

  public void GetM(ref List<string> Subjects)
  {
    List<string> From = new List<string>();
    Subjects = new List<string>();
    List<DateTime> CommingDate = new List<DateTime>();
    List<string> Body = new List<string>();
    clsInit.cNet.GetEmailFromCmdConfirm(ref From, ref Subjects, ref CommingDate, ref Body);
  }

  public void SendM(string Subject, string Body)
  {
    clsInit.cNet.SendEmailFromCmdPrg("report@cmdsoft.com.tr", Subject, Body, new List<string>());
  }

  public void DeleteM() => clsInit.cNet.DeleteEmailFromCmdPrg(true);

  public bool DecodeKeyCode(string[] strArr)
  {
    try
    {
      if (strArr[4] != "bfTC7246" || !(strArr[0] == "CMD"))
        return false;
      if (strArr[1] == "0003" && strArr[2] == "0001" || strArr[1] == "0004" && strArr[2] == "0001" || strArr[1] == "0008" && strArr[2] == "0001" || strArr[1] == "0009" && strArr[2] == "0001" || strArr[1] == "0010" && strArr[2] == "0001" || strArr[1] == "0011" && (strArr[2] == "0001" || strArr[2] == "0020"))
        return true;
      if (strArr[1] == "0012")
      {
        if (strArr[2] == "0001")
          return true;
        if (strArr[2] == "0002")
        {
          clsVar.appModes_0.NestingMode.Mode1 = 2.0;
          return true;
        }
      }
      return strArr[1] == "0013" && strArr[2] == "0001" || strArr[1] == "0016" && (strArr[2] == "0001" || strArr[2] == "0020");
    }
    catch (Exception ex)
    {
      buLog.addLog("Decode Key", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return false;
    }
  }

  public void RecordStopAndSave()
  {
    try
    {
      DialogBoxMultiText dialogBoxMultiText = new DialogBoxMultiText();
      dialogBoxMultiText.Caption = AppLanguage.CadCamDynamic[41];
      dialogBoxMultiText.Text = AppLanguage.CadCamDynamic[41];
      dialogBoxMultiText.Init(AppLanguage.CadCamMessages[78]);
      int num = (int) dialogBoxMultiText.ShowDialog();
      if (dialogBoxMultiText.Result == DialogResult.OK)
      {
        if (!Directory.Exists(AppPath.Record))
          Directory.CreateDirectory(AppPath.Record);
        foreach (FileSystemInfo file in new DirectoryInfo(AppPath.Record).GetFiles())
          file.Delete();
        for (int index = 0; index <= clsVar.RecordScreens.Count - 1; ++index)
          clsVar.RecordScreens[index].Save($"{AppPath.Record}\\Rec{index.ToString("d5")}.jpg");
        buFile.SaveToFile(dialogBoxMultiText.Value, AppPath.Record + "\\Notes.txt");
        FileInfo fileInfo = new FileInfo(AppPath.Base + "\\Record.Zip");
        if (fileInfo.Exists)
          fileInfo.Delete();
        buFile.ZipFolderToFile(AppPath.Record, AppPath.Base + "\\Record.Zip", CompressionLevel.Optimal);
        foreach (FileSystemInfo file in new DirectoryInfo(AppPath.Record).GetFiles())
          file.Delete();
      }
      clsVar.RecordScreens.Clear();
      GC.Collect();
    }
    catch (Exception ex)
    {
    }
  }

  public void SendReport(ReportProgram Report, bool SendEmail, bool SaveBackup, bool AttachFile)
  {
    string FileName = AppPath.Base + "\\Temps\\Report.bureport";
    if (SaveBackup)
      clsFiles.SaveBackupFile(FileName, clsVar.varInterface.BackupMode, true);
    string name = WindowsIdentity.GetCurrent().Name;
    List<string> AttachmentFiles = new List<string>();
    if (AttachFile)
      AttachmentFiles.Add(FileName);
    string MailSubject = $"buCadCam Report - [ {clsVar.appDefination.CustomerInfo} ] [ {clsVar.appDefination.Mode} ]";
    string MailBody = $"{$"{$"{$"{$"App ID : {clsVar.appDefination.AppID.ToString()}{Environment.NewLine}Aux : {clsVar.appDefination.Aux}{Environment.NewLine}Command : {clsVar.appDefination.Command}{Environment.NewLine}CustomerID : {clsVar.appDefination.CustomerID.ToString()}{Environment.NewLine}CustomerInfo : {clsVar.appDefination.CustomerInfo}{Environment.NewLine}Description : {clsVar.appDefination.Description}{Environment.NewLine}Mode : {clsVar.appDefination.Mode}{Environment.NewLine}Name : {clsVar.appDefination.Name}{Environment.NewLine}ProgramCode : {clsVar.appDefination.ProgramCode}{Environment.NewLine}Type : {clsVar.appDefination.Type}{Environment.NewLine}Vendor : {clsVar.appDefination.Vendor}{Environment.NewLine}Web : {clsVar.appDefination.Web}{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}"}---------------------------------------------------{Environment.NewLine}{Environment.NewLine}"}Company : {Report.Company}{Environment.NewLine}Name : {Report.Name}{Environment.NewLine}Email : {Report.email}{Environment.NewLine}Buy From : {Report.Buy}{Environment.NewLine}Code : {Report.Code}{Environment.NewLine}Explanation : {Report.Explanation}"}---------------------------------------------------{Environment.NewLine}{Environment.NewLine}"}Windows User Name : {WindowsIdentity.GetCurrent().Name}";
    if (!SendEmail)
      return;
    clsInit.cNet.SendEmailFromCmdPrg("report@cmdsoft.com.tr", MailSubject, MailBody, AttachmentFiles);
  }

  public void getProgramInfo(ref string info)
  {
    info = "";
    info = $"{info}Version : {Application.ProductVersion}{Environment.NewLine}";
    info = $"{info}CustomerInfo : {clsVar.appDefination.CustomerInfo}{Environment.NewLine}";
    info = $"{info}CustomerID : {clsVar.appDefination.CustomerID.ToString()}{Environment.NewLine}";
    info = $"{info}Description : {clsVar.appDefination.Description}{Environment.NewLine}";
    info = $"{info}Mode : {clsVar.appDefination.Mode}{Environment.NewLine}";
    info = $"{info}Name : {clsVar.appDefination.Name}{Environment.NewLine}";
    info = $"{info}Type : {clsVar.appDefination.Type}{Environment.NewLine}";
    info = $"{info}Vendor : {clsVar.appDefination.Vendor}{Environment.NewLine}";
    info = $"{info}Web : {clsVar.appDefination.Web}{Environment.NewLine}";
    info = $"{info}Aux : {clsVar.appDefination.Aux}{Environment.NewLine}";
    info = $"{info}Command : {clsVar.appDefination.Command}{Environment.NewLine}";
    info = $"{info}Code {clsVar.appDefination.ProgramCode}{Environment.NewLine}";
  }

  public bool CheckSettingsFileAfterNewInstallation(ref string LoadadFiles)
  {
    DirectoryInfo directoryInfo1 = new DirectoryInfo(AppPath.Base + "\\NewVersion");
    LoadadFiles = "";
    bool flag;
    if (directoryInfo1.Exists)
    {
      if (buString.MessageBoxQuestion(AppLanguage.CadCamMessages[109]) == DialogResult.Yes)
      {
        DirectoryInfo directoryInfo2 = new DirectoryInfo(directoryInfo1.FullName + "\\Settings");
        if (directoryInfo2.Exists)
        {
          DirectoryInfo directoryInfo3 = new DirectoryInfo(AppPath.Settings);
          directoryInfo3.Delete(true);
          directoryInfo3.Create();
          buFile.CopyFromDirectortToAnotherDirectory(directoryInfo2.FullName, AppPath.Settings);
          LoadadFiles = $"{LoadadFiles}Settings{Environment.NewLine}";
        }
        DirectoryInfo directoryInfo4 = new DirectoryInfo(directoryInfo1.FullName + "\\Kinematic");
        if (directoryInfo4.Exists)
        {
          DirectoryInfo directoryInfo5 = new DirectoryInfo(AppPath.Kinematic);
          directoryInfo5.Delete(true);
          directoryInfo5.Create();
          buFile.CopyFromDirectortToAnotherDirectory(directoryInfo4.FullName, AppPath.Kinematic);
          LoadadFiles = $"{LoadadFiles}Kinematic{Environment.NewLine}";
        }
        DirectoryInfo directoryInfo6 = new DirectoryInfo(directoryInfo1.FullName + "\\PostProcessors");
        if (directoryInfo6.Exists)
        {
          DirectoryInfo directoryInfo7 = new DirectoryInfo(AppPath.PostProcessor);
          if (directoryInfo7.Exists)
          {
            directoryInfo7.Delete(true);
            directoryInfo7.Create();
            buFile.CopyFromDirectortToAnotherDirectory(directoryInfo6.FullName, AppPath.PostProcessor);
          }
          LoadadFiles = $"{LoadadFiles}PostProcessors{Environment.NewLine}";
        }
        directoryInfo1.Delete(true);
        flag = directoryInfo2.Exists | directoryInfo4.Exists | directoryInfo6.Exists;
      }
      else
      {
        directoryInfo1.Delete(true);
        flag = false;
      }
    }
    else
      flag = false;
    return flag;
  }

  public void NewVersion()
  {
    DirectoryInfo directoryInfo1 = new DirectoryInfo(AppPath.Base + "\\NewVersion");
    string str1 = "";
    if (directoryInfo1.Exists)
    {
      foreach (string file in Directory.GetFiles(directoryInfo1.FullName))
        File.Delete(file);
    }
    else
      directoryInfo1.Create();
    DirectoryInfo directoryInfo2 = new DirectoryInfo(AppPath.Base + "\\NewVersion\\Settings");
    DirectoryInfo directoryInfo3 = new DirectoryInfo(AppPath.Base + "\\NewVersion\\Kinematic");
    DirectoryInfo directoryInfo4 = new DirectoryInfo(AppPath.Base + "\\NewVersion\\PostProcessors");
    if (directoryInfo2.Exists)
    {
      directoryInfo2.Delete(true);
      directoryInfo2.Create();
    }
    else
      directoryInfo2.Create();
    buFile.CopyFromDirectortToAnotherDirectory(AppPath.Settings, directoryInfo2.FullName);
    string str2 = $"{str1}Settings{Environment.NewLine}";
    if (directoryInfo3.Exists)
    {
      directoryInfo3.Delete(true);
      directoryInfo3.Create();
    }
    else
      directoryInfo3.Create();
    buFile.CopyFromDirectortToAnotherDirectory(AppPath.Kinematic, directoryInfo3.FullName);
    string str3 = $"{str2}Kinematic{Environment.NewLine}";
    if (directoryInfo4.Exists)
    {
      directoryInfo4.Delete(true);
      directoryInfo4.Create();
    }
    else
      directoryInfo4.Create();
    buFile.CopyFromDirectortToAnotherDirectory(AppPath.PostProcessor, directoryInfo4.FullName);
    buString.MessageBoxInfo($"{str3}PostProcessor{Environment.NewLine}" + AppLanguage.CadCamMessages[108]);
  }

  public void RunTeamviewer()
  {
    FileInfo fileInfo = new FileInfo(AppPath.Base + "\\TeamViewer12QS.exe");
    if (fileInfo.Exists)
    {
      foreach (Process process in Process.GetProcesses())
      {
        if (!string.IsNullOrEmpty(process.MainWindowTitle) && process.ProcessName.ToLower().IndexOf("teamviewer") >= 0)
          process.Kill();
      }
      new Process()
      {
        StartInfo = {
          FileName = fileInfo.FullName,
          UseShellExecute = true,
          Verb = "runas"
        }
      }.Start();
    }
    else
      buString.MessageBoxWarning(AppLanguage.CadCamMessages[122]);
  }

  public void SetLanguage(string Lang, string FileName)
  {
    List<string> StringList = new List<string>();
    FileInfo fileInfo = FileName.Length != 0 ? new FileInfo(AppPath.Settings + "\\Runtime.prm") : new FileInfo(FileName);
    if (!fileInfo.Exists)
      return;
    bool flag = false;
    buFile5.OpenFromFile(fileInfo.FullName, ref StringList);
    for (int index = 0; index <= StringList.Count - 1; ++index)
    {
      if (StringList[index].ToLower().IndexOf("language") >= 0)
      {
        switch (Lang)
        {
          case "English":
            StringList[index] = "    setRuntime.Language = 0";
            flag = true;
            break;
          case "Turkish":
            StringList[index] = "    setRuntime.Language = 1";
            flag = true;
            break;
          case "China":
            StringList[index] = "    setRuntime.Language = 2";
            flag = true;
            break;
          case "German":
            StringList[index] = "    setRuntime.Language = 3";
            flag = true;
            break;
          case "Italy":
            StringList[index] = "    setRuntime.Language = 4";
            flag = true;
            break;
          case "Spain":
            StringList[index] = "    setRuntime.Language = 5";
            flag = true;
            break;
          case "Russian":
            StringList[index] = "    setRuntime.Language = 6";
            flag = true;
            break;
          case "Arabic":
            StringList[index] = "    setRuntime.Language = 7";
            flag = true;
            break;
          case "France":
            StringList[index] = "    setRuntime.Language = 8";
            flag = true;
            break;
          case "Polish":
            StringList[index] = "    setRuntime.Language = 9";
            flag = true;
            break;
          case "Portuguese":
            StringList[index] = "    setRuntime.Language = 10";
            flag = true;
            break;
        }
      }
      if (flag)
      {
        buFile5.SaveToFile(StringList, fileInfo.FullName);
        if (Lang == "Turkish")
          buString5.MessageBoxInfo("Program Kapanacaktır, Lütfen Tekrar Çalıştırınız");
        if (Lang == "English")
          buString5.MessageBoxInfo("Program will shot down, please restart it");
        if (Lang == "China")
          buString5.MessageBoxInfo("程序将停止运行，请重新启动");
        if (Lang == "German")
          buString5.MessageBoxInfo("Programm wird abgeschossen, bitte starten Sie es neu");
        if (Lang == "Italy")
          buString5.MessageBoxInfo("Il programma si blocca, riavviarlo");
        if (Lang == "Spain")
          buString5.MessageBoxInfo("El programa se caerá, por favor reinícielo");
        if (Lang == "Russian")
          buString5.MessageBoxInfo("Программа завершена, пожалуйста, перезапустите ее");
        if (Lang == "Arabic")
          buString5.MessageBoxInfo("سيتم إيقاف تشغيل البرنامج، يرجى إعادة تشغيله");
        if (Lang == "Persian")
          buString5.MessageBoxInfo("Program Kapanacaktır, Lütfen Takrar Çalıştırınız");
        if (Lang == "Serbia")
          buString5.MessageBoxInfo("Програм ће бити оборен, поново га покрените");
        if (Lang == "Polish")
          buString5.MessageBoxInfo("Program zostanie wyłączony, uruchom go ponownie");
        if (Lang == "Portuguese")
          buString5.MessageBoxInfo("O programa será interrompido, por favor reinicie-o");
      }
    }
  }

  public void SetLanguage(int LangID, string FileName, bool Message)
  {
    List<string> StringList = new List<string>();
    FileInfo fileInfo = FileName.Length != 0 ? new FileInfo(AppPath.Settings + "\\Runtime.prm") : new FileInfo(FileName);
    if (!fileInfo.Exists)
      return;
    bool flag = false;
    buFile5.OpenFromFile(fileInfo.FullName, ref StringList);
    for (int index = 0; index <= StringList.Count - 1; ++index)
    {
      if (StringList[index].ToLower().IndexOf("language") >= 0)
      {
        switch (LangID)
        {
          case 0:
            StringList[index] = "    setRuntime.Language = 0";
            flag = true;
            break;
          case 1:
            StringList[index] = "    setRuntime.Language = 1";
            flag = true;
            break;
          case 2:
            StringList[index] = "    setRuntime.Language = 2";
            flag = true;
            break;
          case 3:
            StringList[index] = "    setRuntime.Language = 3";
            flag = true;
            break;
          case 4:
            StringList[index] = "    setRuntime.Language = 4";
            flag = true;
            break;
          case 5:
            StringList[index] = "    setRuntime.Language = 5";
            flag = true;
            break;
          case 6:
            StringList[index] = "    setRuntime.Language = 6";
            flag = true;
            break;
          case 7:
            StringList[index] = "    setRuntime.Language = 7";
            flag = true;
            break;
          case 8:
            StringList[index] = "    setRuntime.Language = 8";
            flag = true;
            break;
          case 9:
            StringList[index] = "    setRuntime.Language = 9";
            flag = true;
            break;
          case 10:
            StringList[index] = "    setRuntime.Language = 10";
            flag = true;
            break;
        }
      }
      if (flag)
      {
        buFile5.SaveToFile(StringList, fileInfo.FullName);
        if (Message)
        {
          if (LangID == 1)
            buString5.MessageBoxInfo("Program Kapanacaktır, Lütfen Takrar Çalıştırınız");
          if (LangID == 0)
            buString5.MessageBoxInfo("Program will shot down, please restart it");
          if (LangID == 2)
            buString5.MessageBoxInfo("程序将停止运行，请重新启动");
          if (LangID == 3)
            buString5.MessageBoxInfo("Programm wird abgeschossen, bitte starten Sie es neu");
          if (LangID == 4)
            buString5.MessageBoxInfo("Il programma si blocca, riavviarlo");
          if (LangID == 5)
            buString5.MessageBoxInfo("El programa se caerá, por favor reinícielo");
          if (LangID == 6)
            buString5.MessageBoxInfo("Программа завершена, пожалуйста, перезапустите ее");
          if (LangID == 7)
            buString5.MessageBoxInfo("سيتم إيقاف تشغيل البرنامج، يرجى إعادة تشغيله");
          if (LangID == 8)
            buString5.MessageBoxInfo("Le programme se termine, veuillez le relancer");
          if (LangID == 9)
            buString5.MessageBoxInfo("Program zostanie wyłączony, uruchom go ponownie");
          if (LangID == 10)
            buString5.MessageBoxInfo("O programa será interrompido, por favor reinicie-o");
        }
      }
    }
  }

  public void SetMetric(int Unit, string FileName)
  {
    List<string> StringList = new List<string>();
    FileInfo fileInfo = FileName.Length != 0 ? new FileInfo(AppPath.Settings + "\\Runtime.prm") : new FileInfo(FileName);
    if (!fileInfo.Exists)
      return;
    buFile5.OpenFromFile(fileInfo.FullName, ref StringList);
    for (int index = 0; index <= StringList.Count - 1; ++index)
    {
      if (StringList[index].ToLower().IndexOf("metricunit") >= 0)
      {
        switch (Unit)
        {
          case 0:
            StringList[index] = "    setRuntime.MetricUnit = 0";
            continue;
          case 1:
            StringList[index] = "    setRuntime.MetricUnit = 1";
            continue;
          default:
            continue;
        }
      }
    }
    buFile5.SaveToFile(StringList, fileInfo.FullName);
  }
}
