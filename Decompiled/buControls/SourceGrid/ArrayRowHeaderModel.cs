using System;
using SourceGrid.Cells.Models;

namespace SourceGrid;

public class ArrayRowHeaderModel : IValueModel, IModel
{
	public virtual object GetValue(CellContext cellContext)
	{
		return cellContext.Position.Row - cellContext.Grid.FixedRows;
	}

	public virtual void SetValue(CellContext cellContext, object p_Value)
	{
		throw new ApplicationException("Not supported");
	}
}
