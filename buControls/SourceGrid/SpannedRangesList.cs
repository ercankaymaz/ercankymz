// Decompiled with JetBrains decompiler
// Type: SourceGrid.SpannedRangesList
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Collections.Generic;

#nullable disable
namespace SourceGrid;

public class SpannedRangesList : List<Range>, ISpannedRangesCollection
{
  public void Update(Range oldRange, Range newRange)
  {
    int index = this.IndexOf(oldRange);
    if (index < 0)
      throw new RangeNotFoundException();
    this[index] = newRange;
  }

  public void Redim(int rowCount, int colCount)
  {
  }

  public void Remove(Range range)
  {
    int index = this.IndexOf(range);
    if (index < 0)
      throw new RangeNotFoundException();
    this.RemoveAt(index);
  }

  public Range? GetFirstIntersectedRange(Position pos)
  {
    Range? intersectedRange;
    for (int index = 0; index < this.Count; ++index)
    {
      Range range = this[index];
      if (range.Contains(pos))
      {
        intersectedRange = new Range?(range);
        goto label_6;
      }
    }
    intersectedRange = new Range?();
label_6:
    return intersectedRange;
  }

  public List<Range> GetRanges(Range range)
  {
    List<Range> ranges = new List<Range>();
    for (int index = 0; index < this.Count; ++index)
    {
      Range range1 = this[index];
      if (range1.Contains(range))
        ranges.Add(range1);
    }
    return ranges;
  }

  public Range? FindRangeWithStart(Position start)
  {
    Range? rangeWithStart;
    for (int index = 0; index < this.Count; ++index)
    {
      Range range = this[index];
      if (range.Start.Equals(start))
      {
        rangeWithStart = new Range?(range);
        goto label_6;
      }
    }
    rangeWithStart = new Range?();
label_6:
    return rangeWithStart;
  }

  Range[] ISpannedRangesCollection.ToArray() => this.ToArray();
}
