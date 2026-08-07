// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DoorRuntimeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buClipperLib;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class DoorRuntimeSettings : buSerilization5
{
  public int InsideIndex;
  public static byte f003A2E;
  public static string CustomTag;
  public static int Version;
  public static byte f003A31;
  public double X;
  public double Y;
  internal List<PolyNode> \u0001;
  internal PolyNode \u0001;
  internal List<IntPoint> \u0001;
  internal int \u0001;
  internal JoinType \u0001;
  internal EndType \u0001;
  internal List<PolyNode> \u0001;
  private long \u0001;
  private ulong \u0001;
  public long X;
  public long Y;
  public long Z;

  public DoorRuntimeSettings(long l, long t, long r, long b)
  {
    ((DoorTempVars) this).left = l;
    ((DoorTempVars) this).top = t;
    ((DoorTempVars) this).right = r;
    ((DoorTempVars) this).bottom = b;
  }

  public DoorRuntimeSettings(IntRect ir)
  {
    ((DoorTempVars) this).left = ir.left;
    ((DoorTempVars) this).top = ir.top;
    ((DoorTempVars) this).right = ir.right;
    ((DoorTempVars) this).bottom = ir.bottom;
  }
}
