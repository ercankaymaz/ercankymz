// Decompiled with JetBrains decompiler
// Type: SourceGrid.Selection.FreeSelection
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Decorators;

#nullable disable
namespace SourceGrid.Selection;

public class FreeSelection : SelectionBase
{
  private RangeRegion rangeRegion_0 = new RangeRegion();
  private DecoratorSelection decoratorSelection_0;

  public FreeSelection()
  {
    this.rangeRegion_0.Changed += (RangeRegionChangedEventHandler) ((sender, e) => this.OnSelectionChanged(e));
  }

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

  public override bool IsSelectedColumn(int column) => this.rangeRegion_0.ContainsColumn(column);

  public override void SelectColumn(int column, bool select)
  {
    this.SelectRange(this.Grid.Columns.GetRange(column), select);
  }

  public override bool IsSelectedRow(int row) => this.rangeRegion_0.ContainsRow(row);

  public override void SelectRow(int row, bool select)
  {
    this.SelectRange(this.Grid.Rows.GetRange(row), select);
  }

  public override bool IsSelectedCell(Position position) => this.rangeRegion_0.Contains(position);

  public override void SelectCell(Position position, bool select)
  {
    this.SelectRange(this.Grid.PositionToCellRange(position), select);
  }

  public override bool IsSelectedRange(Range range) => this.rangeRegion_0.Contains(range);

  public override void SelectRange(Range range, bool select)
  {
    Range cellRange = this.Grid.RangeToCellRange(range);
    if (select)
      this.rangeRegion_0.Add(this.ValidateRange(cellRange));
    else
      this.rangeRegion_0.Remove(cellRange);
  }

  protected override void OnResetSelection() => this.rangeRegion_0.Clear();

  public override bool IsEmpty() => this.rangeRegion_0.IsEmpty();

  public override RangeRegion GetSelectionRegion() => new RangeRegion(this.rangeRegion_0);

  public override bool IntersectsWith(Range rng) => this.rangeRegion_0.IntersectsWith(rng);
}
