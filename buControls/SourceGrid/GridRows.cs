// Decompiled with JetBrains decompiler
// Type: SourceGrid.GridRows
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;

#nullable disable
namespace SourceGrid;

public class GridRows(SourceGrid.Grid grid) : RowInfoCollection((GridVirtual) grid)
{
  public override void Swap(int p_RowIndex1, int p_RowIndex2)
  {
    base.Swap(p_RowIndex1, p_RowIndex2);
    this.Grid.SpannedCellReferences.Swap(p_RowIndex1, p_RowIndex2);
  }

  public void Insert(int p_Index) => this.InsertRange(p_Index, 1);

  public void InsertRange(int startIndex, int count)
  {
    RowInfo[] rows = new RowInfo[count];
    for (int index = 0; index < rows.Length; ++index)
      rows[index] = (RowInfo) this.CreateRow();
    this.InsertRange(startIndex, rows);
    Class39.smethod_359(this.Grid);
    this.Grid.SpannedCellReferences.MoveDownSpannedRanges(startIndex, count);
    this.Grid.SpannedCellReferences.ExpandSpannedRows(startIndex, count);
  }

  public SourceGrid.Grid Grid => base.Grid as SourceGrid.Grid;

  public override void RemoveRange(int startIndex, int count)
  {
    this.Grid.SpannedCellReferences.RemoveSpannedCellReferencesInRows(startIndex, count);
    base.RemoveRange(startIndex, count);
    this.Grid.SpannedCellReferences.ShrinkOrRemoveSpannedRows(startIndex, count);
    this.Grid.SpannedCellReferences.MoveUpSpannedRanges(startIndex, count);
  }

  protected GridRow CreateRow() => new GridRow(this.Grid);

  public GridRow this[int index] => (GridRow) base[index];

  public void SetCount(int value)
  {
    Class39.smethod_359(this.Grid);
    if (this.Count < value)
    {
      this.InsertRange(this.Count, value - this.Count);
    }
    else
    {
      if (this.Count <= value)
        return;
      this.RemoveRange(value, this.Count - value);
    }
  }
}
