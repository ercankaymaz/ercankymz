using System;
using System.Drawing;
using DevAge.Drawing;
using SourceGrid.Cells;

namespace SourceGrid.Exporter;

public class Image
{
	public virtual Bitmap Export(GridVirtual grid, Range rangeToExport)
	{
		Bitmap bitmap = null;
		try
		{
			Size size = grid.RangeToSize(rangeToExport);
			bitmap = new Bitmap(size.Width, size.Height);
			using Graphics graphics = Graphics.FromImage(bitmap);
			Export(grid, graphics, rangeToExport, new Point(0, 0));
		}
		catch (Exception)
		{
			if (bitmap != null)
			{
				bitmap.Dispose();
				bitmap = null;
			}
			throw;
		}
		return bitmap;
	}

	public virtual void Export(GridVirtual grid, Graphics graphics, Range rangeToExport, Point destinationLocation)
	{
		if (rangeToExport.IsEmpty())
		{
			return;
		}
		Point location = destinationLocation;
		using GraphicsCache graphics2 = new GraphicsCache(graphics);
		for (int i = rangeToExport.Start.Row; i <= rangeToExport.End.Row; i++)
		{
			int height = grid.Rows.GetHeight(i);
			for (int j = rangeToExport.Start.Column; j <= rangeToExport.End.Column; j++)
			{
				Position position = new Position(i, j);
				Size size = new Size(grid.Columns.GetWidth(j), height);
				Range range = grid.PositionToCellRange(position);
				Rectangle rectangle;
				if (range.ColumnsCount <= 1 && range.RowsCount <= 1)
				{
					rectangle = new Rectangle(location, size);
				}
				else if (!(range.Start == position))
				{
					rectangle = Rectangle.Empty;
				}
				else
				{
					Size size2 = grid.RangeToSize(range);
					rectangle = new Rectangle(location, size2);
				}
				if (!rectangle.IsEmpty)
				{
					ICellVirtual cell = grid.GetCell(position);
					CellContext context = new CellContext(grid, position, cell);
					ExportCell(context, graphics2, rectangle);
				}
				location = new Point(location.X + size.Width, location.Y);
			}
			location = new Point(destinationLocation.X, location.Y + height);
		}
	}

	protected virtual void ExportCell(CellContext context, GraphicsCache graphics, Rectangle rectangle)
	{
		if (context.Cell != null)
		{
			context.Cell.View.DrawCell(context, graphics, rectangle);
		}
	}
}
