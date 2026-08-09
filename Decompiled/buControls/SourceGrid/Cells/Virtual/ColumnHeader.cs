using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Views;

namespace SourceGrid.Cells.Virtual;

public class ColumnHeader : CellVirtual
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

	public ColumnHeader()
	{
		View = SourceGrid.Cells.Views.ColumnHeader.Default;
		base.Model.AddModel(new SourceGrid.Cells.Models.SortableHeader());
		AddController(Unselectable.Default);
		AddController(MouseInvalidate.Default);
		ResizeEnabled = true;
		AutomaticSortEnabled = true;
	}
}
