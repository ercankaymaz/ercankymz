// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.CutterIsoEntities
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class CutterIsoEntities : buSerilization
{
  public double Length;
  public double Width;
  public double Height;
  public ProfilingTypes ProfilingType;
  public static byte f003932;
  public double Width;
  public double Height;
  public bool isFinish;
  public Entity entityMesh;

  [CompilerGenerated]
  [SpecialName]
  public void set_CamFeedrate(double value) => ((Router3AXDisplaySettings) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public double get_OrientationA() => ((Router3AXDisplaySettings) this).\u0002;
}
