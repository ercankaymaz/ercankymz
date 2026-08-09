using System;
using SourceGrid.Cells;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Virtual;

namespace SourceGrid.Extensions.PingGrids.Cells;

public class Cell : CellVirtual
{
	public Cell()
	{
		base.Model.AddModel(new PingGridValueModel());
	}

	public static ICellVirtual Create(Type type, bool editable)
	{
		ICellVirtual cellVirtual;
		if (!(type == typeof(bool)))
		{
			cellVirtual = new Cell();
			cellVirtual.Editor = Factory.Create(type);
		}
		else
		{
			cellVirtual = new CheckBox();
		}
		if (cellVirtual.Editor != null)
		{
			cellVirtual.Editor.AllowNull = true;
			cellVirtual.Editor.EnableEdit = editable;
		}
		return cellVirtual;
	}
}
