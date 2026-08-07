// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.SortableHeader
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using SourceGrid.Cells.Models;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class SortableHeader : ControllerBase
{
  public static readonly SortableHeader Default = new SortableHeader();
  public RectangleBorder LogicalBorder = new RectangleBorder(new BorderLine(Color.Black, 4f), new BorderLine(Color.Black, 4f));
  private IRangeLoader p_RangeToSort;
  private IRangeLoader p_HeaderRange;

  public SortableHeader()
    : this((IRangeLoader) null, (IRangeLoader) null)
  {
  }

  public SortableHeader(IRangeLoader p_RangeToSort, IRangeLoader p_HeaderRange)
  {
    this.p_HeaderRange = p_HeaderRange;
    this.p_RangeToSort = p_RangeToSort;
  }

  public override void OnMouseUp(CellContext sender, MouseEventArgs e)
  {
    base.OnMouseUp(sender, e);
    Point client = sender.Grid.PointToClient(Control.MousePosition);
    RectanglePartType pointPartType = this.LogicalBorder.GetPointPartType((RectangleF) sender.Grid.PositionToRectangle(sender.Position), (PointF) client, out float _);
    if ((!this.IsSortEnable(sender) || pointPartType != RectanglePartType.ContentArea ? 0 : (e.Button == MouseButtons.Left ? 1 : 0)) == 0)
      return;
    SortStatus sortStatus = ((ISortableHeader) sender.Cell.Model.FindModel(typeof (ISortableHeader))).GetSortStatus(sender);
    if (sortStatus.Style == HeaderSortStyle.Ascending)
      this.SortColumn(sender, false, sortStatus.Comparer);
    else
      this.SortColumn(sender, true, sortStatus.Comparer);
  }

  public IRangeLoader RangeToSort => this.p_RangeToSort;

  public IRangeLoader RangeHeader => this.p_HeaderRange;

  public bool IsSortEnable(CellContext sender)
  {
    return sender.Grid.EnableSort && sender.Cell.Model.FindModel(typeof (ISortableHeader)) != null;
  }

  public void SortColumn(CellContext sender, bool p_bAscending, IComparer p_Comparer)
  {
    if (!this.IsSortEnable(sender) || (sender.Position.Row >= sender.Grid.Rows.Count ? 0 : (sender.Grid.Columns.Count > 0 ? 1 : 0)) == 0)
      return;
    SourceGrid.Range p_Range = this.p_RangeToSort == null ? new SourceGrid.Range(sender.Position.Row + 1, 0, sender.Grid.Rows.Count - 1, sender.Grid.Columns.Count - 1) : this.p_RangeToSort.GetRange(sender.Grid);
    SourceGrid.Range range = this.p_HeaderRange == null ? new SourceGrid.Range(0, 0, sender.Position.Row, sender.Grid.Columns.Count - 1) : this.p_HeaderRange.GetRange(sender.Grid);
    ISortableHeader model = (ISortableHeader) sender.Cell.Model.FindModel(typeof (ISortableHeader));
    if ((sender.Grid.Rows.Count <= sender.Position.Row + 1 ? 0 : (sender.Grid.Columns.Count > sender.Grid.FixedColumns ? 1 : 0)) == 0)
      return;
    sender.Grid.SortRangeRows(p_Range, sender.Position.Column, p_bAscending, p_Comparer);
    if (p_bAscending)
      model.SetSortMode(sender, HeaderSortStyle.Ascending);
    else
      model.SetSortMode(sender, HeaderSortStyle.Descending);
    for (int row = range.Start.Row; row <= range.End.Row; ++row)
    {
      for (int column = range.Start.Column; column <= range.End.Column; ++column)
      {
        ICellVirtual cell = sender.Grid.GetCell(row, column);
        if ((cell == sender.Cell || cell == null ? 0 : (cell.Model.FindModel(typeof (ISortableHeader)) != null ? 1 : 0)) != 0)
          ((ISortableHeader) cell.Model.FindModel(typeof (ISortableHeader))).SetSortMode(new CellContext(sender.Grid, new Position(row, column), cell), HeaderSortStyle.None);
      }
    }
    sender.Grid.InvalidateRange(range);
  }
}
