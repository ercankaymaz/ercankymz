// Decompiled with JetBrains decompiler
// Type: buClass.PlcDeviceData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
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
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields != null)
    {
      for (int index = 0; index <= fields.Length - 1; ++index)
      {
        string name = fields[index].Name;
        object obj = fields[index].GetValue(CopiedClass);
        fields[index].SetValue((object) this, obj);
      }
    }
  }

  public override string ToString() => "IP: " + this.IPNumber;
}
