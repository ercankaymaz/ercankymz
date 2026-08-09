using System;
using SourceGrid.Cells.Models;

namespace SourceGrid;

public class ArrayColumnHeaderModel : IValueModel, IModel
{
	public virtual object GetValue(CellContext cellContext)
	{
		return cellContext.Position.Column - cellContext.Grid.FixedColumns;
	}

	public virtual void SetValue(CellContext cellContext, object p_Value)
	{
		throw new ApplicationException("Not supported");
	}
}
