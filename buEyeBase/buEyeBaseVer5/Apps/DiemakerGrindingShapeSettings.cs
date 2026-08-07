// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DiemakerGrindingShapeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class DiemakerGrindingShapeSettings : buSerilization5
{
  public static byte f003903;
  public double Diameter;
  public double Length;
  public double Angle;
  public static byte f003907;
  public double HeadDiameter;
  public double Diameter;
  public double Length;
  public double Angle;
  public static byte f00390C;
  public double Width;
  public double Height;
  public double Angle;
  public static byte f003910;
  public double Width;
  public double Height;
  public static byte f003913;
  public double Diameter;
  public drillTypes DrillType;
  public bool isMilling;
  public bool isTapping;
  public static byte f003918;
  public int Count;
  public double Distance;
  public double StartDistance;
  public double EndDistance;
  public double Angle;
  public static byte f00391E;
  public double DiameterOutside;
  public double Hole3Angle;
  public double DistanceX;
  public double DistanceY;
  public static byte f003923;
  public double Diameter;
  public double Length;
  public double Angle;
  public double StartDistance;
  public double EndDistance;
  public CutTypes CutType;
  public bool isMilling;

  [CompilerGenerated]
  [SpecialName]
  public int get_RefIndex() => ((Router3AXSettings) this).\u0005;

  [CompilerGenerated]
  [SpecialName]
  public void set_RefIndex(int value) => ((Router3AXSettings) this).\u0005 = value;
}
