// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Router3AXRuntimeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buClipperLib;
using SmartAssembly.Delegates;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class Router3AXRuntimeSettings : buSerilization5
{
  public PolyNode GetNext()
  {
    return ((DoorRuntimeSettings) this).\u0001.Count <= 0 ? GetString.\u0001((PolyNode) this) : ((DoorRuntimeSettings) this).\u0001[0];
  }

  [SpecialName]
  public List<PolyNode> get_Childs() => ((DoorRuntimeSettings) this).\u0001;
}
