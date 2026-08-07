// Decompiled with JetBrains decompiler
// Type: SourceGrid.RangeRegionChangingEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

public class RangeRegionChangingEventArgs : EventArgs
{
  private RangeRegion pRangeToExclude;
  private RangeRegion pRangeToInclude;
  private RangeRegion pCurrentRegion;

  public RangeRegionChangingEventArgs(
    RangeRegion pCurrentRegion,
    RangeRegion pRangeToExclude,
    RangeRegion pRangeToInclude)
  {
    this.pRangeToExclude = pRangeToExclude;
    this.pCurrentRegion = pCurrentRegion;
    this.pRangeToInclude = pRangeToInclude;
  }

  public RangeRegion CurrentRegion => this.pCurrentRegion;

  public RangeRegion RegionToInclude => this.pRangeToInclude;

  public RangeRegion RegionToExclude => this.pRangeToExclude;
}
