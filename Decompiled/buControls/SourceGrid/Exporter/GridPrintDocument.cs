using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using DevAge.Drawing;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;
using SourceGrid.Cells.Virtual;
using ns27;

namespace SourceGrid.Exporter;

[ToolboxItem(false)]
public class GridPrintDocument : PrintDocument
{
	private GridVirtual grid;

	private SourceGrid.Cells.Views.Cell cell_0 = new SourceGrid.Cells.Views.Cell();

	private SourceGrid.Cells.Views.Cell cell_1 = new SourceGrid.Cells.Views.Cell();

	private Range range_0 = Range.Empty;

	private Font font_0 = null;

	private string string_0 = string.Empty;

	private Font font_1 = null;

	private string string_1 = string.Empty;

	private Font font_2 = null;

	private string string_2 = string.Empty;

	private bool bool_0 = false;

	private int int_0 = 0;

	private int int_1 = 0;

	private float float_0 = 0f;

	private float float_1 = 0f;

	private float float_2 = 0f;

	private int int_2 = 0;

	private int int_3 = 0;

	private Pen pen_0 = null;

	public SourceGrid.Cells.Views.Cell CellPrintView => cell_0;

	public SourceGrid.Cells.Views.Cell HeaderCellPrintView => cell_1;

	public Range RangeToPrint
	{
		get
		{
			return range_0;
		}
		set
		{
			if (value.Start.Row < 0 || value.Start.Column < 0 || value.Start.Row >= grid.Rows.Count || value.Start.Column >= grid.Columns.Count)
			{
				throw new ArgumentOutOfRangeException("RangeToPrint");
			}
			range_0 = value;
		}
	}

	public Font PageHeaderFont
	{
		get
		{
			return font_0;
		}
		set
		{
			font_0 = value;
		}
	}

	public string PageHeaderText
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Font PageFooterFont
	{
		get
		{
			return font_1;
		}
		set
		{
			font_1 = value;
		}
	}

	public string PageFooterText
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public Font PageTitleFont
	{
		get
		{
			return font_2;
		}
		set
		{
			font_2 = value;
		}
	}

	public string PageTitleText
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public bool RepeatFixedRows
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public int PageCount
	{
		get
		{
			if (int_2 == 0)
			{
				throw new ArgumentNullException("Page count not yet calculated");
			}
			return int_2;
		}
	}

	public GridPrintDocument(GridVirtual grid)
	{
		this.grid = grid;
		cell_0.BackColor = Color.Empty;
		cell_1.BackColor = Color.Empty;
		font_0 = new Font(grid.Font, FontStyle.Regular);
		font_2 = new Font(grid.Font, FontStyle.Bold);
		font_1 = new Font(grid.Font, FontStyle.Regular);
	}

	protected virtual float GetHeaderHeight(Graphics g)
	{
		if (!string.IsNullOrEmpty(PageHeaderText))
		{
			return g.MeasureString(PageHeaderText, PageHeaderFont).Height * 1.5f;
		}
		return 0f;
	}

	protected virtual float GetTitleHeight(Graphics g)
	{
		if (!string.IsNullOrEmpty(PageTitleText))
		{
			return g.MeasureString(PageTitleText, PageTitleFont).Height * 2f;
		}
		return 0f;
	}

	protected virtual float GetFooterHeight(Graphics g)
	{
		if (!string.IsNullOrEmpty(PageFooterText))
		{
			return g.MeasureString(PageFooterText, PageFooterFont).Height * 1.5f;
		}
		return 0f;
	}

	internal static string smethod_0(string string_3, int int_4, int int_5)
	{
		return string_3.Replace("[PageNo]", int_4.ToString()).Replace("[PageCount]", int_5.ToString());
	}

	protected virtual void DrawHeader(Graphics g, RectangleF clip, int pageNo, int pageCount)
	{
		string pageHeaderText = PageHeaderText;
		Font pageHeaderFont = PageHeaderFont;
		Brush black = Brushes.Black;
		Class76.smethod_504(pageNo, pageHeaderText, pageCount, g, black, pageHeaderFont, clip);
	}

	protected virtual void DrawTitle(Graphics g, RectangleF clip, int pageNo, int pageCount)
	{
		string pageTitleText = PageTitleText;
		Font pageTitleFont = PageTitleFont;
		Brush black = Brushes.Black;
		Class76.smethod_504(pageNo, pageTitleText, pageCount, g, black, pageTitleFont, clip);
	}

	protected virtual void DrawFooter(Graphics g, RectangleF clip, int pageNo, int pageCount)
	{
		string pageFooterText = PageFooterText;
		Font pageFooterFont = PageFooterFont;
		Brush black = Brushes.Black;
		Class76.smethod_504(pageNo, pageFooterText, pageCount, g, black, pageFooterFont, clip);
	}

	protected virtual int PrecalculatePageCount(PrintPageEventArgs e)
	{
		int num = 1;
		int num2 = 1;
		float num3 = e.MarginBounds.Width;
		float num4 = RangeToPrint.Start.Column;
		for (int i = RangeToPrint.Start.Column; i <= RangeToPrint.End.Column; i++)
		{
			float num5 = GetColumnWidth(e.Graphics, i);
			if ((float)i == num4 && num5 > (float)e.MarginBounds.Width)
			{
				num5 = e.MarginBounds.Width;
			}
			if (!(num3 - num5 >= 0f))
			{
				num2++;
				num3 = e.MarginBounds.Width;
				num4 = i;
				i--;
			}
			else
			{
				num3 -= num5;
			}
		}
		float num6 = 0f;
		float num7 = (float)e.MarginBounds.Height - float_0 - float_1 - float_2;
		for (int j = RangeToPrint.Start.Row; j <= RangeToPrint.End.Row; j++)
		{
			float rowHeight = GetRowHeight(e.Graphics, j);
			if (RepeatFixedRows && j < grid.ActualFixedRows - RangeToPrint.Start.Row)
			{
				num6 += rowHeight;
			}
			if (!(num7 - rowHeight >= 0f))
			{
				if (j <= grid.ActualFixedRows)
				{
					num6 = 0f;
					bool_0 = false;
				}
				num7 = (float)e.MarginBounds.Height - float_0 - float_2 - num6;
				num++;
				j--;
			}
			else
			{
				num7 -= rowHeight;
			}
		}
		return num * num2;
	}

	protected override void OnBeginPrint(PrintEventArgs e)
	{
		base.OnBeginPrint(e);
		if (RangeToPrint.IsEmpty())
		{
			RangeToPrint = new Range(0, 0, grid.Rows.Count - 1, grid.Columns.Count - 1);
		}
		cell_0.Border = RectangleBorder.NoBorder;
		cell_1.Border = RectangleBorder.NoBorder;
		int_0 = RangeToPrint.Start.Row;
		int_1 = RangeToPrint.Start.Column;
		float_0 = 0f;
		float_1 = 0f;
		float_2 = 0f;
		int_2 = 0;
		int_3 = 0;
	}

	protected virtual float GetRowHeight(Graphics g, int row)
	{
		return grid.Rows.GetHeight(row);
	}

	protected virtual float GetColumnWidth(Graphics g, int column)
	{
		return grid.Columns.GetWidth(column);
	}

	protected virtual void DrawCell(Graphics g, CellContext ctx, RectangleF rect)
	{
		if (ctx.Cell == null)
		{
			return;
		}
		if (!(ctx.Cell is SourceGrid.Cells.Virtual.ColumnHeader) && !(ctx.Cell is SourceGrid.Cells.ColumnHeader) && !(ctx.Cell is SourceGrid.Cells.Virtual.RowHeader) && !(ctx.Cell is SourceGrid.Cells.RowHeader) && !(ctx.Cell is SourceGrid.Cells.Virtual.Header) && !(ctx.Cell is SourceGrid.Cells.Header))
		{
			cell_0.TextAlignment = ctx.Cell.View.TextAlignment;
			if (ctx.Cell.View is SourceGrid.Cells.Views.Cell)
			{
				cell_0.AnchorArea = ((SourceGrid.Cells.Views.Cell)ctx.Cell.View).AnchorArea;
				cell_0.ImageAlignment = ((SourceGrid.Cells.Views.Cell)ctx.Cell.View).ImageAlignment;
				cell_0.ImageStretch = ((SourceGrid.Cells.Views.Cell)ctx.Cell.View).ImageStretch;
				cell_0.Padding = ((SourceGrid.Cells.Views.Cell)ctx.Cell.View).Padding;
				cell_0.TrimmingMode = ((SourceGrid.Cells.Views.Cell)ctx.Cell.View).TrimmingMode;
				cell_0.WordWrap = ((SourceGrid.Cells.Views.Cell)ctx.Cell.View).WordWrap;
			}
			cell_0.DrawCell(ctx, new GraphicsCache(g), rect);
		}
		else
		{
			cell_1.DrawCell(ctx, new GraphicsCache(g), rect);
		}
	}

	private static bool smethod_1(List<int> list_0, int int_4, int int_5)
	{
		foreach (int item in list_0)
		{
			if (item >= int_4 && item <= int_5)
			{
				return true;
			}
		}
		return false;
	}

	protected override void OnPrintPage(PrintPageEventArgs e)
	{
		base.OnPrintPage(e);
		if (int_2 == 0)
		{
			float_0 = GetHeaderHeight(e.Graphics);
			float_1 = GetTitleHeight(e.Graphics);
			float_2 = GetFooterHeight(e.Graphics);
			int_2 = PrecalculatePageCount(e);
			int_3 = 1;
		}
		if (range_0.IsEmpty())
		{
			return;
		}
		if (pen_0 == null)
		{
			pen_0 = new Pen(Color.Black);
		}
		RectangleF rectangleF = new RectangleF(e.MarginBounds.Left, (float)e.MarginBounds.Top + float_0 + ((int_0 != RangeToPrint.Start.Row) ? 0f : float_1), e.MarginBounds.Width, (float)e.MarginBounds.Height - float_0 - ((int_0 != RangeToPrint.Start.Row) ? 0f : float_1) - float_2);
		DrawHeader(e.Graphics, new RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, float_0), int_3, int_2);
		if (int_3 == 1)
		{
			DrawTitle(e.Graphics, new RectangleF(e.MarginBounds.Left, (float)e.MarginBounds.Top + float_0, e.MarginBounds.Width, float_1), int_3, int_2);
		}
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		RangeCollection rangeCollection = new RangeCollection();
		int num = int_0;
		int num2 = int_1;
		int num3 = RangeToPrint.End.Column;
		float num4 = 0f;
		for (int i = int_1; i <= RangeToPrint.End.Column; i++)
		{
			float num5 = GetColumnWidth(e.Graphics, i);
			if (i == int_1 && num5 > rectangleF.Width)
			{
				num5 = rectangleF.Width;
			}
			if (!(num4 + num5 <= rectangleF.Width))
			{
				break;
			}
			num4 += num5;
		}
		if (RepeatFixedRows && grid.ActualFixedRows > RangeToPrint.Start.Row)
		{
			int_0 = RangeToPrint.Start.Row;
		}
		float num6 = rectangleF.Top;
		while (int_0 <= RangeToPrint.End.Row)
		{
			if (RepeatFixedRows && int_0 >= grid.ActualFixedRows && int_0 < num)
			{
				int_0 = num;
			}
			float rowHeight = GetRowHeight(e.Graphics, int_0);
			if (num6 + rowHeight > rectangleF.Bottom)
			{
				break;
			}
			float num7 = rectangleF.Left;
			while (int_1 <= num3)
			{
				float num8 = GetColumnWidth(e.Graphics, int_1);
				if (num7 + num8 > rectangleF.Right)
				{
					if (int_1 != num2)
					{
						num3 = int_1 - 1;
						break;
					}
					num8 = rectangleF.Right - num7;
				}
				Position position = new Position(int_0, int_1);
				Range range = grid.PositionToCellRange(position);
				RectangleF rect;
				if (range.ColumnsCount <= 1 && range.RowsCount <= 1)
				{
					rect = new RectangleF(num7, num6, num8, rowHeight);
				}
				else
				{
					Size size = grid.RangeToSize(range);
					if (!(range.Start == position))
					{
						if (rangeCollection.ContainsCell(position))
						{
							rect = RectangleF.Empty;
						}
						else
						{
							float num9 = num7;
							for (int num10 = position.Column - 1; num10 >= range.Start.Column; num10--)
							{
								float columnWidth = GetColumnWidth(e.Graphics, num10);
								num9 -= columnWidth;
							}
							float num11 = num6;
							for (int num12 = position.Row - 1; num12 >= range.Start.Row; num12--)
							{
								float rowHeight2 = GetRowHeight(e.Graphics, num12);
								num11 -= rowHeight2;
							}
							rect = new RectangleF(num9, num11, size.Width, size.Height);
							rangeCollection.Add(range);
						}
					}
					else
					{
						rect = new RectangleF(num7, num6, size.Width, size.Height);
						rangeCollection.Add(range);
					}
				}
				if (!rect.IsEmpty)
				{
					ICellVirtual cell = grid.GetCell(position);
					if (cell != null)
					{
						CellContext ctx = new CellContext(grid, position, cell);
						RectangleF rect2 = new RectangleF(Math.Max(rect.Left, rectangleF.Left), Math.Max(rect.Top, rectangleF.Top), Math.Min(rect.Right, rectangleF.Left + num4) - Math.Max(rect.Left, rectangleF.Left), Math.Min(rect.Bottom, rectangleF.Bottom) - Math.Max(rect.Top, rectangleF.Top));
						Region clip = e.Graphics.Clip;
						try
						{
							e.Graphics.Clip = new Region(rect2);
							DrawCell(e.Graphics, ctx, rect);
						}
						finally
						{
							e.Graphics.Clip = clip;
						}
						if (!smethod_1(list2, range.Start.Row, range.End.Row) && rect.Left >= rectangleF.Left)
						{
							e.Graphics.DrawLine(pen_0, rect.Left, rect2.Top, rect.Left, rect2.Bottom);
							Position start = range.Start;
							List<int> list_ = list2;
							int row = start.Row;
							start = range.End;
							int num13 = row;
							int row2 = start.Row;
							Class76.smethod_422(num13, row2, list_);
						}
						if (!smethod_1(list, range.Start.Column, range.End.Column) && rect.Top >= rectangleF.Top)
						{
							e.Graphics.DrawLine(pen_0, rect2.Left, rect.Top, rect2.Right, rect.Top);
							Position start = range.Start;
							List<int> list_ = list;
							int column = start.Column;
							start = range.End;
							int num13 = column;
							int row2 = start.Column;
							Class76.smethod_422(num13, row2, list_);
						}
						if (rect.Right <= rectangleF.Right)
						{
							e.Graphics.DrawLine(pen_0, rect.Right, rect2.Top, rect.Right, rect2.Bottom);
						}
						if (rect.Bottom <= rectangleF.Bottom)
						{
							e.Graphics.DrawLine(pen_0, rect2.Left, rect.Bottom, rect2.Right, rect.Bottom);
						}
					}
				}
				num7 += num8;
				int_1++;
			}
			num6 += rowHeight;
			int_0++;
			int_1 = num2;
		}
		if (num3 == RangeToPrint.End.Column)
		{
			int_1 = RangeToPrint.Start.Column;
		}
		else
		{
			int_0 = num;
			int_1 = num3 + 1;
		}
		DrawFooter(e.Graphics, new RectangleF(e.MarginBounds.Left, (float)e.MarginBounds.Bottom - float_2, e.MarginBounds.Width, float_2), int_3, int_2);
		e.HasMorePages = int_0 <= RangeToPrint.End.Row;
		if (e.HasMorePages)
		{
			int_3++;
		}
	}

	protected override void OnEndPrint(PrintEventArgs e)
	{
		base.OnEndPrint(e);
		if (pen_0 != null)
		{
			pen_0.Dispose();
			pen_0 = null;
		}
	}
}
