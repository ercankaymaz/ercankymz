// Decompiled with JetBrains decompiler
// Type: SourceGrid.GridColumns
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;

#nullable disable
namespace SourceGrid;

public class GridColumns(SourceGrid.Grid grid) : ColumnInfoCollection((GridVirtual) grid)
{
  public SourceGrid.Grid Grid => base.Grid as SourceGrid.Grid;

  public void Insert(int p_Index) => this.InsertRange(p_Index, 1);

  public void InsertRange(int startIndex, int count)
  {
    GridColumn[] gridColumnArray = new GridColumn[count];
    for (int index = 0; index < gridColumnArray.Length; ++index)
      gridColumnArray[index] = this.CreateColumn();
    this.InsertRange(startIndex, (ColumnInfo[]) gridColumnArray);
    this.Grid.SpannedCellReferences.MoveRightSpannedRanges(startIndex, count);
    this.Grid.SpannedCellReferences.ExpandSpannedColumns(startIndex, count);
  }

  public override void RemoveRange(int startIndex, int count)
  {
    this.Grid.SpannedCellReferences.RemoveSpannedCellReferencesInColumns(startIndex, count);
    base.RemoveRange(startIndex, count);
    this.Grid.SpannedCellReferences.ShrinkOrRemoveSpannedColumns(startIndex, count);
    this.Grid.SpannedCellReferences.MoveLeftSpannedRanges(startIndex, count);
  }

  protected GridColumn CreateColumn() => new GridColumn(this.Grid);

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
