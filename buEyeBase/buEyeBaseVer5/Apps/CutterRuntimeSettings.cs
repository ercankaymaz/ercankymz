// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.CutterRuntimeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class CutterRuntimeSettings : buSerilization
{
  public bool isMilling;
  public static byte f00393D;
  public double Width;

  [CompilerGenerated]
  [SpecialName]
  public void set_sortDirection(entitySortDirection value)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXDisplaySettings) this).\u0001 = value;
  }

  [CompilerGenerated]
  [SpecialName]
  public entityTypeDefination get_typeDefination() => ((Router3AXDisplaySettings) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_typeDefination(entityTypeDefination value)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXDisplaySettings) this).\u0001 = value;
  }

  [CompilerGenerated]
  [SpecialName]
  public string get_infoString() => ((Router3AXDisplaySettings) this).\u0005;
}
