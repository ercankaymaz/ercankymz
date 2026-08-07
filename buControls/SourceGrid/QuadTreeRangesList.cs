// Decompiled with JetBrains decompiler
// Type: SourceGrid.QuadTreeRangesList
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using QuadTreeLib;
using System.Collections.Generic;

#nullable disable
namespace SourceGrid;

public class QuadTreeRangesList(Range bounds) : QuadTree(bounds), ISpannedRangesCollection
{
  public Range[] ToArray() => this.Contents.ToArray();

  public void Remove(Range range) => base.Remove(range);

  public void Redim(int rowCount, int colCount)
  {
    Range bounds;
    while (true)
    {
      bounds = this.Bounds;
      if (bounds.RowsCount <= rowCount)
        this.Grow();
      else
        break;
    }
    while (true)
    {
      bounds = this.Bounds;
      if (bounds.ColumnsCount <= colCount)
        this.Grow();
      else
        break;
    }
  }

  public void Update(Range oldRange, Range newRange)
  {
    if (!this.QueryFirst(oldRange.Start).HasValue)
      throw new RangeNotFoundException();
    this.Remove(oldRange);
    this.Insert(newRange);
  }

  public void Add(Range range) => this.Insert(range);

  public List<Range> GetRanges(Range range) => this.Query(range);

  public Range? GetFirstIntersectedRange(Position pos) => this.QueryFirst(pos) ?? new Range?();

  public Range? FindRangeWithStart(Position start) => this.QueryFirst(start);
}
