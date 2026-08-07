// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Router3AXTempVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buClipperLib;
using dummy_ptr;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class Router3AXTempVars : buSerilization5
{
  public static byte f003A03;
  public string Tags;
  public string SceneName;

  [SpecialName]
  public PolyNode get_Parent() => ((DoorRuntimeSettings) this).\u0001;

  [SpecialName]
  public bool get_IsHole()
  {
    return \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((PolyNode) this);
  }
}
