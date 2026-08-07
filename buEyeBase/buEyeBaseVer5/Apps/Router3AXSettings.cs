// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Router3AXSettings
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
public class Router3AXSettings : buSerilization5
{
  [SpecialName]
  public int get_Total()
  {
    int count = ((DoorRuntimeSettings) this).\u0001.Count;
    if ((count <= 0 ? 0 : (((DoorRuntimeSettings) this).\u0001[0] != ((DoorRuntimeSettings) this).\u0001[0] ? 1 : 0)) != 0)
      --count;
    return count;
  }

  public Router3AXSettings()
  {
    ((DoorRuntimeSettings) this).\u0001 = new List<PolyNode>();
    // ISSUE: explicit constructor call
    ((DrawOptions) this).\u002Ector();
  }
}
