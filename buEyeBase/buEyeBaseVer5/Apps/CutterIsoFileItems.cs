// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.CutterIsoFileItems
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class CutterIsoFileItems : buSerilization
{
  public JunctionTypes JunctionType;

  [CompilerGenerated]
  [SpecialName]
  public void set_OrientationC(double value) => ((Router3AXDisplaySettings) this).\u0004 = value;

  [CompilerGenerated]
  [SpecialName]
  public entitySortDirection get_sortDirection() => ((Router3AXDisplaySettings) this).\u0001;
}
