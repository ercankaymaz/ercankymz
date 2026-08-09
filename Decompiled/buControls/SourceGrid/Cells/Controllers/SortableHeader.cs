using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using DevAge.Drawing;
using SourceGrid.Cells.Models;

namespace SourceGrid.Cells.Controllers;

public class SortableHeader : ControllerBase
{
	public static readonly SortableHeader Default;

	public RectangleBorder LogicalBorder = new RectangleBorder(new BorderLine(Color.Black, 4f), new BorderLine(Color.Black, 4f));

	private IRangeLoader p_RangeToSort;

	private IRangeLoader p_HeaderRange;

	public IRangeLoader RangeToSort => p_RangeToSort;

	public IRangeLoader RangeHeader => p_HeaderRange;

	static SortableHeader()
	{
		Default = new SortableHeader();
	}

	public SortableHeader()
		: this(null, null)
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
		Point point = sender.Grid.PointToClient(Control.MousePosition);
		Rectangle rectangle = sender.Grid.PositionToRectangle(sender.Position);
		float distanceFromBorder;
		RectanglePartType pointPartType = LogicalBorder.GetPointPartType(rectangle, point, out distanceFromBorder);
		if (IsSortEnable(sender) && pointPartType == RectanglePartType.ContentArea && e.Button == MouseButtons.Left)
		{
			ISortableHeader sortableHeader = (ISortableHeader)sender.Cell.Model.FindModel(typeof(ISortableHeader));
			SortStatus sortStatus = sortableHeader.GetSortStatus(sender);
			if (sortStatus.Style != HeaderSortStyle.Ascending)
			{
				SortColumn(sender, p_bAscending: true, sortStatus.Comparer);
			}
			else
			{
				SortColumn(sender, p_bAscending: false, sortStatus.Comparer);
			}
		}
	}

	public bool IsSortEnable(CellContext sender)
	{
		if (sender.Grid.EnableSort)
		{
			if (sender.Cell.Model.FindModel(typeof(ISortableHeader)) == null)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public void SortColumn(CellContext sender, bool p_bAscending, IComparer p_Comparer)
	{
		if (!IsSortEnable(sender) || sender.Position.Row >= sender.Grid.Rows.Count || sender.Grid.Columns.Count <= 0)
		{
			return;
		}
		Range p_Range = ((p_RangeToSort != null) ? p_RangeToSort.GetRange(sender.Grid) : new Range(sender.Position.Row + 1, 0, sender.Grid.Rows.Count - 1, sender.Grid.Columns.Count - 1));
		Range range = ((p_HeaderRange != null) ? p_HeaderRange.GetRange(sender.Grid) : new Range(0, 0, sender.Position.Row, sender.Grid.Columns.Count - 1));
		ISortableHeader sortableHeader = (ISortableHeader)sender.Cell.Model.FindModel(typeof(ISortableHeader));
		if (sender.Grid.Rows.Count <= sender.Position.Row + 1 || sender.Grid.Columns.Count <= sender.Grid.FixedColumns)
		{
			return;
		}
		sender.Grid.SortRangeRows(p_Range, sender.Position.Column, p_bAscending, p_Comparer);
		if (!p_bAscending)
		{
			sortableHeader.SetSortMode(sender, HeaderSortStyle.Descending);
		}
		else
		{
			sortableHeader.SetSortMode(sender, HeaderSortStyle.Ascending);
		}
		for (int i = range.Start.Row; i <= range.End.Row; i++)
		{
			for (int j = range.Start.Column; j <= range.End.Column; j++)
			{
				ICellVirtual cell = sender.Grid.GetCell(i, j);
				if (cell != sender.Cell && cell != null && cell.Model.FindModel(typeof(ISortableHeader)) != null)
				{
					ISortableHeader sortableHeader2 = (ISortableHeader)cell.Model.FindModel(typeof(ISortableHeader));
					sortableHeader2.SetSortMode(new CellContext(sender.Grid, new Position(i, j), cell), HeaderSortStyle.None);
				}
			}
		}
		sender.Grid.InvalidateRange(range);
	}
}
