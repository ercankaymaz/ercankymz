// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MoveEventFormVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class MoveEventFormVars : buSerilization5
{
  public static byte f000450;
  public Pnt6D Position;
  public Pnt6D Offset;
  public Pnt6D CommonOffset;
  public double AngularPosition;

  public override string ToString()
  {
    return $"Feed: {((ToolLimits5) this).FeedSpeed.ToString()} - PlungeSpeed: {((ToolPositions5) this).PlungeSpeed.ToString()} - SpindleSpeed: {((ToolPositions5) this).SpindleSpeed.ToString()} - SpindleDir: {((LayerBase5) this).SpindleDirection.ToString()}";
  }

  public abstract void m0001A8();
}
