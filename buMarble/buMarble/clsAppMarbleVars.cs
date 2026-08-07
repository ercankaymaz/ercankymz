// Decompiled with JetBrains decompiler
// Type: buMarble.clsAppMarbleVars
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using \u0005;
using buClass;
using buCore;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Marble;
using buEyeBaseVer5.Forms.Vision;
using buMotion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble;

public class clsAppMarbleVars
{
  internal static bool \u0001;
  public static MarbleCustomers customerType;
  public static clsAppMarble cmdMarble;
  public static clsAppMarbleMachineReport reportMachine;
  public static CodesysMachine cMachine;
  public static clsAppMarbleInterfaceVar varInterface;
  public static clsAppMarbleRuntimeVar varRuntime;
  public static clsAppMarbleOPVar varApp;
  public static clsAppMarbleFormVar varForms;
  public static F_MarbleToolSawMilling frmToolSawMilling;
  public static F_CameraLive FrmCameraLive;

  public abstract void m000001();

  public clsAppMarbleVars()
  {
    if (!clsAppMarbleVars.\u0001(nameof (clsAppMarbleVars)))
    {
      int num = (int) MessageBox.Show(nameof (clsAppMarbleVars));
      throw new RegisterException(nameof (clsAppMarbleVars));
    }
  }

  internal static bool \u0001([In] string obj0)
  {
    try
    {
      if (obj0 == "buViewerBrooOpen")
        return true;
      if (buVector.AskMeResult != "TesxCEguItdxXery89+dxdx+456(9004dxXXx5678X4Dfgytex &7fdxHRewxWw2" | buVector.AskMeValue != -5861345679435.9121)
      {
        BinaryReader binaryReader = (BinaryReader) null;
        try
        {
          FileInfo fileInfo = new FileInfo(AppPath.Base + "\\mnbucfd.dll");
          if (!fileInfo.Exists)
            throw new RegisterException(obj0);
          if (fileInfo.Exists)
          {
            List<double> doubleList = new List<double>();
            List<string> stringList1 = new List<string>();
            List<string> stringList2 = new List<string>();
            bool flag1;
            bool flag2;
            try
            {
              buLogVer5.addToLog("DefK", "Mode 14100", "mnb", "1", 0.0, 0.0);
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
              doubleList.Clear();
              stringList1.Clear();
              stringList2.Clear();
              for (int index1 = 0; index1 <= num6 - 1; ++index1)
              {
                double num7 = binaryReader.ReadDouble() / 65.87;
                doubleList.Add(num7);
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
              buLogVer5.addToLog("DefK", "Mode 14101", "mnb", "100", 0.0, 0.0);
            }
            catch (Exception ex)
            {
              int num = (int) MessageBox.Show(ex.Message);
              binaryReader.Close();
              throw new RegisterException(obj0);
            }
            List<string> MacAddress = new List<string>();
            List<string> CpuAddress = new List<string>();
            string MBAddress = "";
            clsAppMarbleVars.getMacAddress(ref MacAddress);
            buLogVer5.addToLog("DefK", "Mode 14102", "mnb", "100", 0.0, 0.0);
            clsAppMarbleVars.getCpuID(ref CpuAddress);
            buLogVer5.addToLog("DefK", "Mode 14103", "mnb", "100", 0.0, 0.0);
            clsAppMarbleVars.GetMotherBoardID(ref MBAddress);
            buLogVer5.addToLog("DefK", "Mode 14104", "mnb", "100", 0.0, 0.0);
            if (!flag1 & !flag2)
            {
              bool flag3 = \u0003.\u0001(MacAddress, MBAddress, doubleList, CpuAddress, obj0);
              buLogVer5.addToLog("DefK", "Mode 14104", "mnb", "100", 0.0, 0.0);
              if (flag3)
              {
                clsAppMarbleVars.\u0001 = true;
                return true;
              }
            }
            throw new RegisterException(obj0);
          }
          throw new RegisterException(obj0);
        }
        catch (Exception ex)
        {
          throw new RegisterException(obj0);
        }
      }
      else
      {
        clsAppMarbleVars.\u0001 = true;
        return true;
      }
    }
    catch (Exception ex)
    {
      throw new RegisterException(obj0);
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

  public void Init() => clsAppMarbleVars.cmdMarble = new clsAppMarble();
}
