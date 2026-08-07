// Decompiled with JetBrains decompiler
// Type: SourceGrid.ISpannedRangesCollection
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Collections.Generic;

#nullable disable
namespace SourceGrid;

public interface ISpannedRangesCollection
{
  int Count { get; }

  void Add(Range range);

  void Update(Range oldRange, Range newRange);

  void Redim(int rowCount, int colCount);

  void Remove(Range range);

  Range? GetFirstIntersectedRange(Position pos);

  List<Range> GetRanges(Range range);

  Range? FindRangeWithStart(Position start);

  Range[] ToArray();
}
