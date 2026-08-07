// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Router3AXCamPlane
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buClipperLib;
using System;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class Router3AXCamPlane : buSerilization5
{
  public static byte f0039D6;
  public static byte f0039D7;

  public Router3AXCamPlane(DoublePoint dp)
  {
    ((DoorRuntimeSettings) this).X = dp.X;
    ((DoorRuntimeSettings) this).Y = dp.Y;
  }

  public Router3AXCamPlane(IntPoint ip)
  {
    ((DoorRuntimeSettings) this).X = (double) ip.X;
    ((DoorRuntimeSettings) this).Y = (double) ip.Y;
  }

  public void Clear()
  {
    for (int index = 0; index < ((DoorRuntimeSettings) this).\u0001.Count; ++index)
      ((DoorRuntimeSettings) this).\u0001[index] = (PolyNode) null;
    ((DoorRuntimeSettings) this).\u0001.Clear();
    ((DoorRuntimeSettings) this).\u0001.Clear();
  }

  public PolyNode GetFirst()
  {
    return ((DoorRuntimeSettings) this).\u0001.Count <= 0 ? (PolyNode) null : ((DoorRuntimeSettings) this).\u0001[0];
  }
}
