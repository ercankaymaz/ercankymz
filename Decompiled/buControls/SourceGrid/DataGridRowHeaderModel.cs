using System;
using SourceGrid.Cells.Models;

namespace SourceGrid;

public class DataGridRowHeaderModel : IValueModel, IModel
{
	public object GetValue(CellContext cellContext)
	{
		DataGrid dataGrid = (DataGrid)cellContext.Grid;
		if (dataGrid.DataSource == null || !dataGrid.DataSource.AllowNew || cellContext.Position.Row != dataGrid.Rows.Count - 1)
		{
			return null;
		}
		return "*";
	}

	public void SetValue(CellContext cellContext, object p_Value)
	{
		throw new ApplicationException("Not supported");
	}
}
