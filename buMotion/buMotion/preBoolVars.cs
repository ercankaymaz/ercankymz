// Decompiled with JetBrains decompiler
// Type: buMotion.preBoolVars
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buClass;
using System;

#nullable disable
namespace buMotion;

[Serializable]
public class preBoolVars : buSerilization
{
  public double MaxX;
  public double MaxY;
  public double MaxZ;
  public bool ParWriting;
  public bool Start;
  public bool Stop;
  public bool Pause;
  public bool Warning;
  public bool Alarm;
  public bool Saw;
  public bool Spindle;
  public int AlarmCountPre;

  public preBoolVars()
  {
    ((typeMinMaxXYZ) this).MinX = 0.0;
    ((typeMinMaxXYZ) this).MinY = 0.0;
    ((typeMinMaxXYZ) this).MinZ = 0.0;
    this.MaxX = 0.0;
    this.MaxY = 0.0;
    this.MaxZ = 0.0;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
