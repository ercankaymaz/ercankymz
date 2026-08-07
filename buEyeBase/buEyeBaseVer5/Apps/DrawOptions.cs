// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrawOptions
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
public class DrawOptions : buSerilization5
{
  public string EntityName;
  public string ActionName;
  public int CamID;
  public int GroupIdIndex;
  public int OriginalEntityIndex;

  [CompilerGenerated]
  [SpecialName]
  public bool get_IsOpen() => ((DoorRuntimeSettings) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_IsOpen(bool value) => ((DoorRuntimeSettings) this).\u0001 = value;

  public DrawOptions()
  {
    ((DoorRuntimeSettings) this).\u0001 = new List<IntPoint>();
    ((DoorRuntimeSettings) this).\u0001 = new List<PolyNode>();
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
