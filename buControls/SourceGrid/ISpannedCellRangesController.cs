// Decompiled with JetBrains decompiler
// Type: SourceGrid.ISpannedCellRangesController
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace SourceGrid;

public interface ISpannedCellRangesController
{
  ISpannedRangesCollection SpannedRangesCollection { get; }

  void MoveLeftSpannedRanges(int startIndex, int moveCount);

  void MoveUpSpannedRanges(int startIndex, int moveCount);

  void MoveDownSpannedRanges(int startIndex, int moveCount);

  void MoveRightSpannedRanges(int startIndex, int moveCount);

  void ExpandSpannedColumns(int startIndex, int count);

  void ExpandSpannedRows(int startIndex, int count);

  void ShrinkOrRemoveSpannedRows(int startIndex, int count);

  void ShrinkOrRemoveSpannedColumns(int startIndex, int count);

  void RemoveSpannedCellReferencesInRows(int startIndex, int count);

  void RemoveSpannedCellReferencesInColumns(int startIndex, int count);

  void Swap(int rowIndex1, int rowIndex2);

  void UpdateOrAdd(Range newRange);

  void Update(Range newRange);
}
