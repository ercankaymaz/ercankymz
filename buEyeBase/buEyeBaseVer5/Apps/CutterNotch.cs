// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.CutterNotch
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class CutterNotch : buSerilization5
{
  public static byte f003964;
  public static byte f003969;
  public static byte f00396D;
  public double xPos;

  [CompilerGenerated]
  [SpecialName]
  public double get_infoAngle() => ((Router3AXDisplaySettings) this).\u0006;

  [CompilerGenerated]
  [SpecialName]
  public void set_infoAngle(double value) => ((Router3AXDisplaySettings) this).\u0006 = value;

  [CompilerGenerated]
  [SpecialName]
  public double get_infoDirection() => ((Router3AXDisplaySettings) this).\u0007;

  [CompilerGenerated]
  [SpecialName]
  public void set_infoDirection(double value) => ((Router3AXDisplaySettings) this).\u0007 = value;
}
