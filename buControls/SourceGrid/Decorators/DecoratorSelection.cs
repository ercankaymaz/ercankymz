// Decompiled with JetBrains decompiler
// Type: SourceGrid.Decorators.DecoratorSelection
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Selection;
using System.Drawing;

#nullable disable
namespace SourceGrid.Decorators;

public class DecoratorSelection : DecoratorBase
{
  private SelectionBase selection;

  public DecoratorSelection(SelectionBase selection) => this.selection = selection;

  public override bool IntersectWith(Range range) => this.selection.IntersectsWith(range);

  public override void Draw(RangePaintEventArgs e)
  {
    RangeRegion selectionRegion = this.selection.GetSelectionRegion();
    if (selectionRegion.IsEmpty())
      return;
    Range range1 = this.selection.Grid.RangeAtAreaExpanded(CellPositionType.Scrollable);
    Brush brush1 = (Brush) e.GraphicsCache.BrushsCache.GetBrush(this.selection.BackColor);
    CellContext cellContext = new CellContext(e.Grid, this.selection.ActivePosition);
    Range range2 = range1.Intersect(new Range(this.selection.ActivePosition, this.selection.ActivePosition));
    Rectangle rectangle1 = e.Grid.PositionToRectangle(range2.Start);
    foreach (Range p_Range in selectionRegion)
    {
      Range range3 = range1.Intersect(p_Range);
      Rectangle rectangle2 = e.Grid.RangeToRectangle(range3);
      if (!(rectangle2 == Rectangle.Empty))
      {
        Region region = new Region(rectangle2);
        if (rectangle2.IntersectsWith(rectangle1))
          region.Exclude(rectangle1);
        e.GraphicsCache.Graphics.FillRegion(brush1, region);
        if ((range3.Contains(this.selection.ActivePosition) ? 1 : (selectionRegion.Count == 1 ? 1 : 0)) != 0 && !cellContext.IsEditing())
          this.selection.Border.Draw(e.GraphicsCache, (RectangleF) rectangle2);
      }
    }
    Brush brush2 = (Brush) e.GraphicsCache.BrushsCache.GetBrush(this.selection.FocusBackColor);
    e.GraphicsCache.Graphics.FillRectangle(brush2, rectangle1);
  }
}
