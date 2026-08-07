// Decompiled with JetBrains decompiler
// Type: SourceGrid.Selection.ColumnSelection
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Decorators;
using System;
using System.Collections.Generic;

#nullable disable
namespace SourceGrid.Selection;

public class ColumnSelection : SelectionBase
{
  private DecoratorSelection decoratorSelection_0;
  private List<int> list_0 = new List<int>();

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

  public override bool IsSelectedColumn(int column) => this.list_0.Contains(column);

  public override void SelectColumn(int column, bool select)
  {
    if ((!select ? 0 : (!this.list_0.Contains(column) ? 1 : 0)) != 0)
    {
      this.list_0.Add(column);
      this.OnSelectionChanged(new RangeRegionChangedEventArgs(this.Grid.Columns.GetRange(column), Range.Empty));
    }
    else
    {
      if ((select ? 0 : (this.list_0.Contains(column) ? 1 : 0)) == 0)
        return;
      this.list_0.Remove(column);
      this.OnSelectionChanged(new RangeRegionChangedEventArgs(Range.Empty, this.Grid.Columns.GetRange(column)));
    }
  }

  public override bool IsSelectedRow(int row) => false;

  public override void SelectRow(int row, bool select)
  {
    throw new Exception("The method or operation is not implemented.");
  }

  public override bool IsSelectedCell(Position position) => this.IsSelectedColumn(position.Column);

  public override void SelectCell(Position position, bool select)
  {
    this.SelectColumn(position.Column, select);
  }

  public override bool IsSelectedRange(Range range)
  {
    bool flag;
    for (int column = range.Start.Column; column <= range.End.Column; ++column)
    {
      if (!this.IsSelectedColumn(column))
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
    for (int column = range.Start.Column; column <= range.End.Column; ++column)
      this.SelectColumn(column, select);
  }

  protected override void OnResetSelection()
  {
    RangeRegion selectionRegion = this.GetSelectionRegion();
    this.list_0.Clear();
    this.OnSelectionChanged(new RangeRegionChangedEventArgs((RangeRegion) null, selectionRegion));
  }

  public override bool IsEmpty() => this.list_0.Count == 0;

  public override RangeRegion GetSelectionRegion()
  {
    RangeRegion selectionRegion = new RangeRegion();
    if (this.Grid.Rows.Count > 0)
    {
      foreach (int num in this.list_0)
        selectionRegion.Add(this.ValidateRange(new Range(this.Grid.FixedRows, num, this.Grid.Rows.Count - 1, num)));
    }
    return selectionRegion;
  }

  public override bool IntersectsWith(Range rng)
  {
    bool flag;
    for (int column = rng.Start.Column; column <= rng.End.Column; ++column)
    {
      if (this.IsSelectedColumn(column))
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
