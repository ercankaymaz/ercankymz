using System;
using SourceGrid.Cells.Models;

namespace SourceGrid.Extensions.PingGrids;

public class PingGridValueModel : IValueModel, IModel
{
	public object GetValue(CellContext cellContext)
	{
		PingGrid pingGrid = cellContext.Grid as PingGrid;
		string propertyName = pingGrid.Columns[cellContext.Position.Column].PropertyName;
		int num = pingGrid.Rows.IndexToDataSourceIndex(cellContext.Position.Row);
		if (num < pingGrid.DataSource.Count)
		{
			return pingGrid.DataSource.GetItemValue(num, propertyName);
		}
		return null;
	}

	public void SetValue(CellContext cellContext, object value)
	{
		throw new NotImplementedException();
	}
}
