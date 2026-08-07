// Decompiled with JetBrains decompiler
// Type: SourceGrid.RangeRegionChangedEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

public class RangeRegionChangedEventArgs : EventArgs
{
  private RangeRegion addedRange;
  private RangeRegion removedRange;

  public RangeRegionChangedEventArgs(Range addedRange, Range removedRange)
  {
    if (!addedRange.IsEmpty())
      this.addedRange = new RangeRegion(addedRange);
    if (removedRange.IsEmpty())
      return;
    this.removedRange = new RangeRegion(removedRange);
  }

  public RangeRegionChangedEventArgs(RangeRegion addedRange, RangeRegion removedRange)
  {
    this.addedRange = addedRange;
    this.removedRange = removedRange;
  }

  public RangeRegion AddedRange => this.addedRange;

  public RangeRegion RemovedRange => this.removedRange;
}
