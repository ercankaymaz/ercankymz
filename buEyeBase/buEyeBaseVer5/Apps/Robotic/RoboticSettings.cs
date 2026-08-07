// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Robotic.RoboticSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps.Marble;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps.Robotic;

[Serializable]
public class RoboticSettings : buSerilization5
{
  public bool UseLeadOut;
  public double LeadInDistance;
  public double LeadOutDistance;
  public bool isFirst;
  public bool MoveSafeZDistance;
  public double XOffset;
  public double YOffset;
  public double DeltaWidth;
  public double DeltaHeight;
  public double Thickness;
  public string Explanation;
  public static byte f00502D;
  public MarbleMotionCommands Cmd;
  public Point3D pntMove;
  public Plane refPlane;
  public Point pntScreen;
  [SpecialName]
  public int value__;

  public override string ToString() => "";

  static RoboticSettings() => marbleSawMillingPars.Captions = new List<string>();
}
