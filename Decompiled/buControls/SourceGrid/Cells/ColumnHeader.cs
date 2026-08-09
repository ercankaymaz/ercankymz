using System.Collections;
using System.Runtime.CompilerServices;
using DevAge.Drawing;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Views;

namespace SourceGrid.Cells;

public class ColumnHeader : Cell
{
	public bool ResizeEnabled
	{
		get
		{
			return FindController(typeof(Resizable)) == Resizable.ResizeWidth;
		}
		set
		{
			if (value != ResizeEnabled)
			{
				if (!value)
				{
					RemoveController(Resizable.ResizeWidth);
				}
				else
				{
					AddController(Resizable.ResizeWidth);
				}
			}
		}
	}

	public bool AutomaticSortEnabled
	{
		get
		{
			return FindController(typeof(SourceGrid.Cells.Controllers.SortableHeader)) == SourceGrid.Cells.Controllers.SortableHeader.Default;
		}
		set
		{
			if (value != AutomaticSortEnabled)
			{
				if (!value)
				{
					RemoveController(SourceGrid.Cells.Controllers.SortableHeader.Default);
				}
				else
				{
					AddController(SourceGrid.Cells.Controllers.SortableHeader.Default);
				}
			}
		}
	}

	public SortStatus SortStatus
	{
		get
		{
			return method_2().SortStatus;
		}
		set
		{
			method_2().SortStatus = value;
		}
	}

	public IComparer SortComparer
	{
		get
		{
			return SortStatus.Comparer;
		}
		set
		{
			SortStatus = new SortStatus(SortStatus.Style, value);
		}
	}

	public HeaderSortStyle SortStyle
	{
		get
		{
			return SortStatus.Style;
		}
		set
		{
			SortStatus = new SortStatus(value, SortStatus.Comparer);
		}
	}

	public ColumnHeader()
		: this(null)
	{
	}

	public ColumnHeader(object cellValue)
		: base(cellValue)
	{
		View = SourceGrid.Cells.Views.ColumnHeader.Default;
		base.Model.AddModel(new SourceGrid.Cells.Models.SortableHeader());
		AddController(Unselectable.Default);
		AddController(MouseInvalidate.Default);
		ResizeEnabled = true;
		AutomaticSortEnabled = true;
	}

	[SpecialName]
	private SourceGrid.Cells.Models.SortableHeader method_2()
	{
		return (SourceGrid.Cells.Models.SortableHeader)base.Model.FindModel(typeof(SourceGrid.Cells.Models.SortableHeader));
	}

	public void Sort(bool ascending)
	{
		SourceGrid.Cells.Controllers.SortableHeader sortableHeader = (SourceGrid.Cells.Controllers.SortableHeader)FindController(typeof(SourceGrid.Cells.Controllers.SortableHeader));
		if (sortableHeader == null)
		{
			throw new SourceGridException("No SortableHeader controller found");
		}
		sortableHeader.SortColumn(new CellContext(base.Grid, base.Range.Start, this), ascending, SortComparer);
	}
}
