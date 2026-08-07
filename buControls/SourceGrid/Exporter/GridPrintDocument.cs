// Decompiled with JetBrains decompiler
// Type: SourceGrid.Exporter.GridPrintDocument
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using ns7;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;

#nullable disable
namespace SourceGrid.Exporter;

[ToolboxItem(false)]
public class GridPrintDocument : PrintDocument
{
  private GridVirtual grid;
  private SourceGrid.Cells.Views.Cell cell_0 = new SourceGrid.Cells.Views.Cell();
  private SourceGrid.Cells.Views.Cell cell_1 = new SourceGrid.Cells.Views.Cell();
  private Range range_0 = Range.Empty;
  private Font font_0 = (Font) null;
  private string string_0 = string.Empty;
  private Font font_1 = (Font) null;
  private string string_1 = string.Empty;
  private Font font_2 = (Font) null;
  private string string_2 = string.Empty;
  private bool bool_0 = false;
  private int int_0 = 0;
  private int int_1 = 0;
  private float float_0 = 0.0f;
  private float float_1 = 0.0f;
  private float float_2 = 0.0f;
  private int int_2 = 0;
  private int int_3 = 0;
  private Pen pen_0 = (Pen) null;

  public SourceGrid.Cells.Views.Cell CellPrintView => this.cell_0;

  public SourceGrid.Cells.Views.Cell HeaderCellPrintView => this.cell_1;

  public GridPrintDocument(GridVirtual grid)
  {
    this.grid = grid;
    this.cell_0.BackColor = Color.Empty;
    this.cell_1.BackColor = Color.Empty;
    this.font_0 = new Font(grid.Font, FontStyle.Regular);
    this.font_2 = new Font(grid.Font, FontStyle.Bold);
    this.font_1 = new Font(grid.Font, FontStyle.Regular);
  }

  public Range RangeToPrint
  {
    get => this.range_0;
    set
    {
      if ((value.Start.Row < 0 || value.Start.Column < 0 || value.Start.Row >= this.grid.Rows.Count ? 1 : (value.Start.Column >= this.grid.Columns.Count ? 1 : 0)) != 0)
        throw new ArgumentOutOfRangeException(nameof (RangeToPrint));
      this.range_0 = value;
    }
  }

  public Font PageHeaderFont
  {
    get => this.font_0;
    set => this.font_0 = value;
  }

  public string PageHeaderText
  {
    get => this.string_0;
    set => this.string_0 = value;
  }

  public Font PageFooterFont
  {
    get => this.font_1;
    set => this.font_1 = value;
  }

  public string PageFooterText
  {
    get => this.string_1;
    set => this.string_1 = value;
  }

  public Font PageTitleFont
  {
    get => this.font_2;
    set => this.font_2 = value;
  }

  public string PageTitleText
  {
    get => this.string_2;
    set => this.string_2 = value;
  }

  protected virtual float GetHeaderHeight(Graphics g)
  {
    return !string.IsNullOrEmpty(this.PageHeaderText) ? g.MeasureString(this.PageHeaderText, this.PageHeaderFont).Height * 1.5f : 0.0f;
  }

  protected virtual float GetTitleHeight(Graphics g)
  {
    return !string.IsNullOrEmpty(this.PageTitleText) ? g.MeasureString(this.PageTitleText, this.PageTitleFont).Height * 2f : 0.0f;
  }

  protected virtual float GetFooterHeight(Graphics g)
  {
    return !string.IsNullOrEmpty(this.PageFooterText) ? g.MeasureString(this.PageFooterText, this.PageFooterFont).Height * 1.5f : 0.0f;
  }

  internal static string smethod_0(string string_3, int int_4, int int_5)
  {
    return string_3.Replace("[PageNo]", int_4.ToString()).Replace("[PageCount]", int_5.ToString());
  }

  protected virtual void DrawHeader(Graphics g, RectangleF clip, int pageNo, int pageCount)
  {
    string pageHeaderText = this.PageHeaderText;
    Font pageHeaderFont = this.PageHeaderFont;
    Brush black = Brushes.Black;
    Class39.smethod_504(pageNo, pageHeaderText, pageCount, g, black, pageHeaderFont, clip);
  }

  protected virtual void DrawTitle(Graphics g, RectangleF clip, int pageNo, int pageCount)
  {
    string pageTitleText = this.PageTitleText;
    Font pageTitleFont = this.PageTitleFont;
    Brush black = Brushes.Black;
    Class39.smethod_504(pageNo, pageTitleText, pageCount, g, black, pageTitleFont, clip);
  }

  protected virtual void DrawFooter(Graphics g, RectangleF clip, int pageNo, int pageCount)
  {
    string pageFooterText = this.PageFooterText;
    Font pageFooterFont = this.PageFooterFont;
    Brush black = Brushes.Black;
    Class39.smethod_504(pageNo, pageFooterText, pageCount, g, black, pageFooterFont, clip);
  }

  public bool RepeatFixedRows
  {
    get => this.bool_0;
    set => this.bool_0 = value;
  }

  protected virtual int PrecalculatePageCount(PrintPageEventArgs e)
  {
    int num1 = 1;
    int num2 = 1;
    float width1 = (float) e.MarginBounds.Width;
    float num3 = (float) this.RangeToPrint.Start.Column;
    Rectangle marginBounds;
    for (int column = this.RangeToPrint.Start.Column; column <= this.RangeToPrint.End.Column; ++column)
    {
      float num4 = this.GetColumnWidth(e.Graphics, column);
      int num5;
      if ((double) column == (double) num3)
      {
        double num6 = (double) num4;
        marginBounds = e.MarginBounds;
        double width2 = (double) marginBounds.Width;
        num5 = num6 > width2 ? 1 : 0;
      }
      else
        num5 = 0;
      if (num5 != 0)
      {
        marginBounds = e.MarginBounds;
        num4 = (float) marginBounds.Width;
      }
      if ((double) width1 - (double) num4 >= 0.0)
      {
        width1 -= num4;
      }
      else
      {
        ++num2;
        marginBounds = e.MarginBounds;
        width1 = (float) marginBounds.Width;
        num3 = (float) column;
        --column;
      }
    }
    float num7 = 0.0f;
    marginBounds = e.MarginBounds;
    float num8 = (float) marginBounds.Height - this.float_0 - this.float_1 - this.float_2;
    int row1 = this.RangeToPrint.Start.Row;
    while (true)
    {
      int num9 = row1;
      Position position = this.RangeToPrint.End;
      int row2 = position.Row;
      if (num9 <= row2)
      {
        float rowHeight = this.GetRowHeight(e.Graphics, row1);
        int num10;
        if (this.RepeatFixedRows)
        {
          int num11 = row1;
          int actualFixedRows = this.grid.ActualFixedRows;
          position = this.RangeToPrint.Start;
          int row3 = position.Row;
          int num12 = actualFixedRows - row3;
          num10 = num11 < num12 ? 1 : 0;
        }
        else
          num10 = 0;
        if (num10 != 0)
          num7 += rowHeight;
        if ((double) num8 - (double) rowHeight >= 0.0)
        {
          num8 -= rowHeight;
        }
        else
        {
          if (row1 <= this.grid.ActualFixedRows)
          {
            num7 = 0.0f;
            this.bool_0 = false;
          }
          marginBounds = e.MarginBounds;
          num8 = (float) marginBounds.Height - this.float_0 - this.float_2 - num7;
          ++num1;
          --row1;
        }
        ++row1;
      }
      else
        break;
    }
    return num1 * num2;
  }

  public int PageCount
  {
    get
    {
      return this.int_2 != 0 ? this.int_2 : throw new ArgumentNullException("Page count not yet calculated");
    }
  }

  protected override void OnBeginPrint(PrintEventArgs e)
  {
    base.OnBeginPrint(e);
    if (this.RangeToPrint.IsEmpty())
      this.RangeToPrint = new Range(0, 0, this.grid.Rows.Count - 1, this.grid.Columns.Count - 1);
    this.cell_0.Border = (IBorder) RectangleBorder.NoBorder;
    this.cell_1.Border = (IBorder) RectangleBorder.NoBorder;
    Range rangeToPrint = this.RangeToPrint;
    this.int_0 = rangeToPrint.Start.Row;
    rangeToPrint = this.RangeToPrint;
    this.int_1 = rangeToPrint.Start.Column;
    this.float_0 = 0.0f;
    this.float_1 = 0.0f;
    this.float_2 = 0.0f;
    this.int_2 = 0;
    this.int_3 = 0;
  }

  protected virtual float GetRowHeight(Graphics g, int row)
  {
    return (float) this.grid.Rows.GetHeight(row);
  }

  protected virtual float GetColumnWidth(Graphics g, int column)
  {
    return (float) this.grid.Columns.GetWidth(column);
  }

  protected virtual void DrawCell(Graphics g, CellContext ctx, RectangleF rect)
  {
    if (ctx.Cell == null)
      return;
    if ((ctx.Cell is SourceGrid.Cells.Virtual.ColumnHeader || ctx.Cell is SourceGrid.Cells.ColumnHeader || ctx.Cell is SourceGrid.Cells.Virtual.RowHeader || ctx.Cell is SourceGrid.Cells.RowHeader || ctx.Cell is SourceGrid.Cells.Virtual.Header ? 1 : (ctx.Cell is SourceGrid.Cells.Header ? 1 : 0)) != 0)
    {
      this.cell_1.DrawCell(ctx, new GraphicsCache(g), rect);
    }
    else
    {
      this.cell_0.TextAlignment = ctx.Cell.View.TextAlignment;
      if (ctx.Cell.View is SourceGrid.Cells.Views.Cell)
      {
        this.cell_0.AnchorArea = ((VisualElementBase) ctx.Cell.View).AnchorArea;
        this.cell_0.ImageAlignment = ((ViewBase) ctx.Cell.View).ImageAlignment;
        this.cell_0.ImageStretch = ((ViewBase) ctx.Cell.View).ImageStretch;
        this.cell_0.Padding = ((ViewBase) ctx.Cell.View).Padding;
        this.cell_0.TrimmingMode = ((ViewBase) ctx.Cell.View).TrimmingMode;
        this.cell_0.WordWrap = ((ViewBase) ctx.Cell.View).WordWrap;
      }
      this.cell_0.DrawCell(ctx, new GraphicsCache(g), rect);
    }
  }

  private static bool smethod_1(List<int> list_0, int int_4, int int_5)
  {
    bool flag;
    foreach (int num in list_0)
    {
      if ((num < int_4 ? 0 : (num <= int_5 ? 1 : 0)) != 0)
      {
        flag = true;
        goto label_7;
      }
    }
    flag = false;
label_7:
    return flag;
  }

  protected override void OnPrintPage(PrintPageEventArgs e)
  {
    base.OnPrintPage(e);
    if (this.int_2 == 0)
    {
      this.float_0 = this.GetHeaderHeight(e.Graphics);
      this.float_1 = this.GetTitleHeight(e.Graphics);
      this.float_2 = this.GetFooterHeight(e.Graphics);
      this.int_2 = this.PrecalculatePageCount(e);
      this.int_3 = 1;
    }
    if (this.range_0.IsEmpty())
      return;
    if (this.pen_0 == null)
      this.pen_0 = new Pen(Color.Black);
    RectangleF rectangleF = new RectangleF((float) e.MarginBounds.Left, (float) ((double) e.MarginBounds.Top + (double) this.float_0 + (this.int_0 == this.RangeToPrint.Start.Row ? (double) this.float_1 : 0.0)), (float) e.MarginBounds.Width, (float) ((double) e.MarginBounds.Height - (double) this.float_0 - (this.int_0 == this.RangeToPrint.Start.Row ? (double) this.float_1 : 0.0)) - this.float_2);
    this.DrawHeader(e.Graphics, new RectangleF((float) e.MarginBounds.Left, (float) e.MarginBounds.Top, (float) e.MarginBounds.Width, this.float_0), this.int_3, this.int_2);
    if (this.int_3 == 1)
      this.DrawTitle(e.Graphics, new RectangleF((float) e.MarginBounds.Left, (float) e.MarginBounds.Top + this.float_0, (float) e.MarginBounds.Width, this.float_1), this.int_3, this.int_2);
    List<int> intList1 = new List<int>();
    List<int> intList2 = new List<int>();
    RangeCollection rangeCollection = new RangeCollection();
    int int0_1 = this.int_0;
    int int1_1 = this.int_1;
    int num1 = this.RangeToPrint.End.Column;
    float num2 = 0.0f;
    int int1_2 = this.int_1;
    Position position1;
    while (true)
    {
      int num3 = int1_2;
      position1 = this.RangeToPrint.End;
      int column = position1.Column;
      if (num3 <= column)
      {
        float num4 = this.GetColumnWidth(e.Graphics, int1_2);
        if ((int1_2 != this.int_1 ? 0 : ((double) num4 > (double) rectangleF.Width ? 1 : 0)) != 0)
          num4 = rectangleF.Width;
        if ((double) num2 + (double) num4 <= (double) rectangleF.Width)
        {
          num2 += num4;
          ++int1_2;
        }
        else
          break;
      }
      else
        break;
    }
    int num5;
    if (this.RepeatFixedRows)
    {
      int actualFixedRows = this.grid.ActualFixedRows;
      position1 = this.RangeToPrint.Start;
      int row = position1.Row;
      num5 = actualFixedRows > row ? 1 : 0;
    }
    else
      num5 = 0;
    if (num5 != 0)
    {
      position1 = this.RangeToPrint.Start;
      this.int_0 = position1.Row;
    }
    float top = rectangleF.Top;
    while (true)
    {
      int int0_2 = this.int_0;
      position1 = this.RangeToPrint.End;
      int row1 = position1.Row;
      if (int0_2 <= row1)
      {
        if ((!this.RepeatFixedRows || this.int_0 < this.grid.ActualFixedRows ? 0 : (this.int_0 < int0_1 ? 1 : 0)) != 0)
          this.int_0 = int0_1;
        float rowHeight1 = this.GetRowHeight(e.Graphics, this.int_0);
        if ((double) top + (double) rowHeight1 <= (double) rectangleF.Bottom)
        {
          float left = rectangleF.Left;
          for (; this.int_1 <= num1; ++this.int_1)
          {
            float width = this.GetColumnWidth(e.Graphics, this.int_1);
            if ((double) left + (double) width > (double) rectangleF.Right)
            {
              if (this.int_1 == int1_1)
              {
                width = rectangleF.Right - left;
              }
              else
              {
                num1 = this.int_1 - 1;
                break;
              }
            }
            Position position2 = new Position(this.int_0, this.int_1);
            Range cellRange = this.grid.PositionToCellRange(position2);
            RectangleF rect1;
            if ((cellRange.ColumnsCount > 1 ? 1 : (cellRange.RowsCount > 1 ? 1 : 0)) != 0)
            {
              Size size = this.grid.RangeToSize(cellRange);
              if (cellRange.Start == position2)
              {
                rect1 = new RectangleF(left, top, (float) size.Width, (float) size.Height);
                rangeCollection.Add(cellRange);
              }
              else if (!rangeCollection.ContainsCell(position2))
              {
                float x = left;
                int column1 = position2.Column - 1;
                while (true)
                {
                  int num6 = column1;
                  position1 = cellRange.Start;
                  int column2 = position1.Column;
                  if (num6 >= column2)
                  {
                    float columnWidth = this.GetColumnWidth(e.Graphics, column1);
                    x -= columnWidth;
                    --column1;
                  }
                  else
                    break;
                }
                float y = top;
                int row2 = position2.Row - 1;
                while (true)
                {
                  int num7 = row2;
                  position1 = cellRange.Start;
                  int row3 = position1.Row;
                  if (num7 >= row3)
                  {
                    float rowHeight2 = this.GetRowHeight(e.Graphics, row2);
                    y -= rowHeight2;
                    --row2;
                  }
                  else
                    break;
                }
                rect1 = new RectangleF(x, y, (float) size.Width, (float) size.Height);
                rangeCollection.Add(cellRange);
              }
              else
                rect1 = RectangleF.Empty;
            }
            else
              rect1 = new RectangleF(left, top, width, rowHeight1);
            if (!rect1.IsEmpty)
            {
              ICellVirtual cell = this.grid.GetCell(position2);
              if (cell != null)
              {
                CellContext ctx = new CellContext(this.grid, position2, cell);
                RectangleF rect2 = new RectangleF(Math.Max(rect1.Left, rectangleF.Left), Math.Max(rect1.Top, rectangleF.Top), Math.Min(rect1.Right, rectangleF.Left + num2) - Math.Max(rect1.Left, rectangleF.Left), Math.Min(rect1.Bottom, rectangleF.Bottom) - Math.Max(rect1.Top, rectangleF.Top));
                Region clip = e.Graphics.Clip;
                try
                {
                  e.Graphics.Clip = new Region(rect2);
                  this.DrawCell(e.Graphics, ctx, rect1);
                }
                finally
                {
                  e.Graphics.Clip = clip;
                }
                List<int> list_0_1 = intList2;
                int row4 = cellRange.Start.Row;
                position1 = cellRange.End;
                int row5 = position1.Row;
                if ((GridPrintDocument.smethod_1(list_0_1, row4, row5) ? 0 : ((double) rect1.Left >= (double) rectangleF.Left ? 1 : 0)) != 0)
                {
                  e.Graphics.DrawLine(this.pen_0, rect1.Left, rect2.Top, rect1.Left, rect2.Bottom);
                  List<int> intList3 = intList2;
                  position1 = cellRange.Start;
                  List<int> list_0_2 = intList3;
                  int row6 = position1.Row;
                  position1 = cellRange.End;
                  Class39.smethod_422(row6, position1.Row, list_0_2);
                }
                List<int> list_0_3 = intList1;
                position1 = cellRange.Start;
                int column3 = position1.Column;
                position1 = cellRange.End;
                int column4 = position1.Column;
                if ((GridPrintDocument.smethod_1(list_0_3, column3, column4) ? 0 : ((double) rect1.Top >= (double) rectangleF.Top ? 1 : 0)) != 0)
                {
                  e.Graphics.DrawLine(this.pen_0, rect2.Left, rect1.Top, rect2.Right, rect1.Top);
                  List<int> intList4 = intList1;
                  position1 = cellRange.Start;
                  List<int> list_0_4 = intList4;
                  int column5 = position1.Column;
                  position1 = cellRange.End;
                  Class39.smethod_422(column5, position1.Column, list_0_4);
                }
                if ((double) rect1.Right <= (double) rectangleF.Right)
                  e.Graphics.DrawLine(this.pen_0, rect1.Right, rect2.Top, rect1.Right, rect2.Bottom);
                if ((double) rect1.Bottom <= (double) rectangleF.Bottom)
                  e.Graphics.DrawLine(this.pen_0, rect2.Left, rect1.Bottom, rect2.Right, rect1.Bottom);
              }
            }
            left += width;
          }
          top += rowHeight1;
          ++this.int_0;
          this.int_1 = int1_1;
        }
        else
          break;
      }
      else
        break;
    }
    int num8 = num1;
    position1 = this.RangeToPrint.End;
    int column6 = position1.Column;
    if (num8 != column6)
    {
      this.int_0 = int0_1;
      this.int_1 = num1 + 1;
    }
    else
    {
      position1 = this.RangeToPrint.Start;
      this.int_1 = position1.Column;
    }
    this.DrawFooter(e.Graphics, new RectangleF((float) e.MarginBounds.Left, (float) e.MarginBounds.Bottom - this.float_2, (float) e.MarginBounds.Width, this.float_2), this.int_3, this.int_2);
    PrintPageEventArgs printPageEventArgs = e;
    int int0_3 = this.int_0;
    position1 = this.RangeToPrint.End;
    int row7 = position1.Row;
    int num9 = int0_3 <= row7 ? 1 : 0;
    printPageEventArgs.HasMorePages = num9 != 0;
    if (!e.HasMorePages)
      return;
    ++this.int_3;
  }

  protected override void OnEndPrint(PrintEventArgs e)
  {
    base.OnEndPrint(e);
    if (this.pen_0 == null)
      return;
    this.pen_0.Dispose();
    this.pen_0 = (Pen) null;
  }
}
