// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.CutterProgramSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class CutterProgramSettings : buSerilization
{
  public double Height;
  public double Angle;
  public string TextString;
  public bool isWire;
  public Font TextFont;
  public static byte f003944;
  public double NotchWidth;
  public double NotchHeight;
  public double NotchStartHeight;
  public double NotchAngle;
  public UpDownLocationType NotchUpDown;
  public FrontBackType NotchFrontBack;
  public ProfileNotchLocationType NotchLocation;
  public ProfileNotchOperationType NotchOPType;
  public static byte f00394D;
  public ColorType colorHole;
  public ColorType colorShape;
  public ColorType colorCut;
  public ColorType colorProfiling;
  public ColorType colorJunktion;
  public ColorType colorEngraving;
  public ColorType colorText;
  public ColorType colorOnline;
  public ColorType colorOperation;
  public ColorType colorOperationSelected;
  public ColorType colorOperationDisable;
  public ColorType colorOperationDisableSelected;
  public ColorType colorCam;
  public static byte f00395E;

  [CompilerGenerated]
  [SpecialName]
  public void set_infoString(string value) => ((Router3AXDisplaySettings) this).\u0005 = value;

  [CompilerGenerated]
  [SpecialName]
  public string get_infoData() => ((Router3AXDisplaySettings) this).\u0006;

  [CompilerGenerated]
  [SpecialName]
  public void set_infoData(string value) => ((Router3AXDisplaySettings) this).\u0006 = value;

  [CompilerGenerated]
  [SpecialName]
  public double get_infoLength() => ((Router3AXDisplaySettings) this).\u0005;

  [CompilerGenerated]
  [SpecialName]
  public void set_infoLength(double value) => ((Router3AXDisplaySettings) this).\u0005 = value;
}
