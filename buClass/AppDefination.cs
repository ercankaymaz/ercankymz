// Decompiled with JetBrains decompiler
// Type: buClass.AppDefination
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class AppDefination : buSerilization
{
  public string Name = "";
  public string Description = "";
  public string Vendor = "";
  public string Web = "";
  public string Mode = "";
  public string Type = "";
  public string Aux = "";
  public string CustomerInfo = "";
  public string MachineNo = "";
  public string MachineSerial = "";
  public string MachineName = "";
  public AppCustomerID CustomerID = AppCustomerID.CMD;
  public AppDefinationType AppType = AppDefinationType.None;
  public int AppID = 0;
  public string Command = "";
  public string ProgramCode = "";
  public int IntroAppNameLeft = 0;
  public int IntroAppNameTop = 0;
  public int IntroAppNameWidth = 0;
  public bool IntroAppNameVisible = false;
  public int IntroAppNameColor = 0;
  public int IntroAppNameFont = 0;
  public int IntroVersionLeft = 0;
  public int IntroVersionTop = 0;
  public int IntroVerisonWidth = 0;
  public bool IntroVersionVisible = false;
  public int IntroVersionColor = 0;
  public int IntroVersionFont = 0;
  public int IntroWebLeft = 0;
  public int IntroWebTop = 0;
  public int IntroWebWidth = 0;
  public bool IntroWebVisible = false;
  public int IntroWebColor = 0;
  public int IntroWebFont = 0;
  public int IntroVendorLeft = 0;
  public int IntroVendorTop = 0;
  public int IntroVendorWidth = 0;
  public bool IntroVendorVisible = false;
  public int IntroVendorColor = 0;
  public int IntroVendorFont = 0;
  public int IntroAuxLeft = 0;
  public int IntroAuxTop = 0;
  public int IntroAuxWidth = 0;
  public bool IntroAuxVisible = false;
  public int IntroAuxColor = 0;
  public int IntroAuxFont = 0;
  public int IntroOther1Left = 0;
  public int IntroOther1Top = 0;
  public int IntroOther1Width = 0;
  public bool IntroOther1Visible = false;
  public int IntroOther1Color = 0;
  public int IntroOther1Font = 0;
}
