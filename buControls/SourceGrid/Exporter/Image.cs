// Decompiled with JetBrains decompiler
// Type: SourceGrid.Exporter.Image
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using SourceGrid.Cells;
using System;
using System.Drawing;

#nullable disable
namespace SourceGrid.Exporter;

public class Image
{
  public virtual Bitmap Export(GridVirtual grid, Range rangeToExport)
  {
    Bitmap bitmap = (Bitmap) null;
    try
    {
      Size size = grid.RangeToSize(rangeToExport);
      bitmap = new Bitmap(size.Width, size.Height);
      using (Graphics graphics = Graphics.FromImage((System.Drawing.Image) bitmap))
        this.Export(grid, graphics, rangeToExport, new Point(0, 0));
    }
    catch (Exception ex)
    {
      bitmap?.Dispose();
      throw;
    }
    return bitmap;
  }

  public virtual void Export(
    GridVirtual grid,
    Graphics graphics,
    Range rangeToExport,
    Point destinationLocation)
  {
    if (rangeToExport.IsEmpty())
      return;
    Point location = destinationLocation;
    using (GraphicsCache graphics1 = new GraphicsCache(graphics))
    {
      int row1 = rangeToExport.Start.Row;
      while (true)
      {
        int num1 = row1;
        Position position1 = rangeToExport.End;
        int row2 = position1.Row;
        if (num1 <= row2)
        {
          int height = grid.Rows.GetHeight(row1);
          position1 = rangeToExport.Start;
          int column1 = position1.Column;
          while (true)
          {
            int num2 = column1;
            position1 = rangeToExport.End;
            int column2 = position1.Column;
            if (num2 <= column2)
            {
              Position position2 = new Position(row1, column1);
              Size size1 = new Size(grid.Columns.GetWidth(column1), height);
              Range cellRange = grid.PositionToCellRange(position2);
              Rectangle rectangle;
              if ((cellRange.ColumnsCount > 1 ? 1 : (cellRange.RowsCount > 1 ? 1 : 0)) != 0)
              {
                if (cellRange.Start == position2)
                {
                  Size size2 = grid.RangeToSize(cellRange);
                  rectangle = new Rectangle(location, size2);
                }
                else
                  rectangle = Rectangle.Empty;
              }
              else
                rectangle = new Rectangle(location, size1);
              if (!rectangle.IsEmpty)
              {
                ICellVirtual cell = grid.GetCell(position2);
                this.ExportCell(new CellContext(grid, position2, cell), graphics1, rectangle);
              }
              location = new Point(location.X + size1.Width, location.Y);
              ++column1;
            }
            else
              break;
          }
          location = new Point(destinationLocation.X, location.Y + height);
          ++row1;
        }
        else
          break;
      }
    }
  }

  protected virtual void ExportCell(
    CellContext context,
    GraphicsCache graphics,
    Rectangle rectangle)
  {
    if (context.Cell == null)
      return;
    context.Cell.View.DrawCell(context, graphics, (RectangleF) rectangle);
  }
}
