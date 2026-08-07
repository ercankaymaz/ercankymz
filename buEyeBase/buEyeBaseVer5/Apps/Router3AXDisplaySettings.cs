// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Router3AXDisplaySettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buClipperLib;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class Router3AXDisplaySettings : buSerilization5
{
  [SpecialName]
  public int get_ChildCount() => ((DoorRuntimeSettings) this).\u0001.Count;

  [SpecialName]
  public List<IntPoint> get_Contour() => ((DoorRuntimeSettings) this).\u0001;
}
