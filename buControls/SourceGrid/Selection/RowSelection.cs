// Decompiled with JetBrains decompiler
// Type: SourceGrid.Selection.RowSelection
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using SourceGrid.Decorators;
using System;

#nullable disable
namespace SourceGrid.Selection;

public class RowSelection : SelectionBase
{
  private DecoratorSelection decoratorSelection_0;
  private RangeMergerByRows rangeMergerByRows_0 = new RangeMergerByRows();

  public override void BindToGrid(GridVirtual p_grid)
  {
    base.BindToGrid(p_grid);
    this.decoratorSelection_0 = new DecoratorSelection((SelectionBase) this);
    this.Grid.Decorators.Add((DecoratorBase) this.decoratorSelection_0);
  }

  public override void UnBindToGrid()
  {
    this.Grid.Decorators.Remove((DecoratorBase) this.decoratorSelection_0);
    base.UnBindToGrid();
  }

  public override bool IsSelectedColumn(int column) => false;

  public override void SelectColumn(int column, bool select)
  {
    throw new Exception("The method or operation is not implemented.");
  }

  public override bool IsSelectedRow(int row) => this.rangeMergerByRows_0.IsSelectedRow(row);

  public override void SelectRow(int row, bool select)
  {
    Range range = this.Grid.Rows.GetRange(row);
    if ((!select ? 0 : (!this.rangeMergerByRows_0.IsSelectedRow(row) ? 1 : 0)) != 0)
    {
      Position activePosition = this.ActivePosition;
      if (!this.EnableMultiSelection)
        this.Grid.Selection.ResetSelection(false);
      this.rangeMergerByRows_0.AddRange(range);
      this.ActivePosition = activePosition;
      this.OnSelectionChanged(new RangeRegionChangedEventArgs(range, Range.Empty));
    }
    else
    {
      if ((select ? 0 : (this.rangeMergerByRows_0.IsSelectedRow(row) ? 1 : 0)) == 0)
        return;
      this.rangeMergerByRows_0.RemoveRange(range);
      this.OnSelectionChanged(new RangeRegionChangedEventArgs(Range.Empty, range));
    }
  }

  public override bool IsSelectedCell(Position position) => this.IsSelectedRow(position.Row);

  public override void SelectCell(Position position, bool select)
  {
    this.SelectRow(position.Row, select);
  }

  public override bool IsSelectedRange(Range range)
  {
    bool flag;
    for (int row = range.Start.Row; row <= range.End.Row; ++row)
    {
      if (!this.IsSelectedRow(row))
      {
        flag = false;
        goto label_6;
      }
    }
    flag = true;
label_6:
    return flag;
  }

  public override void SelectRange(Range range, bool select)
  {
    Range range1 = Class39.smethod_760(range, this);
    if (select)
      this.rangeMergerByRows_0.AddRange(range1);
    else
      this.rangeMergerByRows_0.RemoveRange(range1);
    this.OnSelectionChanged(new RangeRegionChangedEventArgs(range1, Range.Empty));
  }

  protected override void OnResetSelection()
  {
    RangeRegion selectionRegion = this.GetSelectionRegion();
    this.rangeMergerByRows_0.Clear();
    this.OnSelectionChanged(new RangeRegionChangedEventArgs((RangeRegion) null, selectionRegion));
  }

  public override bool IsEmpty() => this.rangeMergerByRows_0.IsEmpty();

  public override RangeRegion GetSelectionRegion()
  {
    RangeRegion rangeRegion = new RangeRegion();
    RangeRegion selectionRegion;
    if (this.Grid.Columns.Count == 0)
    {
      selectionRegion = rangeRegion;
    }
    else
    {
      foreach (Range selectedRowRegion in this.rangeMergerByRows_0.GetSelectedRowRegions(0, this.Grid.Columns.Count))
        rangeRegion.Add(this.ValidateRange(selectedRowRegion));
      selectionRegion = rangeRegion;
    }
    return selectionRegion;
  }

  public override bool IntersectsWith(Range rng)
  {
    bool flag;
    for (int row = rng.Start.Row; row <= rng.End.Row; ++row)
    {
      if (this.IsSelectedRow(row))
      {
        flag = true;
        goto label_6;
      }
    }
    flag = false;
label_6:
    return flag;
  }
}
