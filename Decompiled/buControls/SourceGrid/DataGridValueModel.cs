using System;
using System.ComponentModel;
using SourceGrid.Cells.Models;

namespace SourceGrid;

public class DataGridValueModel : IValueModel, IModel
{
	public object GetValue(CellContext cellContext)
	{
		DataGrid dataGrid = (DataGrid)cellContext.Grid;
		PropertyDescriptor propertyColumn = dataGrid.Columns[cellContext.Position.Column].PropertyColumn;
		int num = dataGrid.Rows.IndexToDataSourceIndex(cellContext.Position.Row);
		if (num < dataGrid.DataSource.Count)
		{
			return dataGrid.DataSource.GetItemValue(num, propertyColumn);
		}
		return null;
	}

	public void SetValue(CellContext cellContext, object value)
	{
		DataGrid dataGrid = (DataGrid)cellContext.Grid;
		PropertyDescriptor propertyColumn = dataGrid.Columns[cellContext.Position.Column].PropertyColumn;
		object value2 = GetValue(cellContext);
		ValueChangeEventArgs e = new ValueChangeEventArgs(value2, value);
		if (cellContext.Grid != null)
		{
			cellContext.Grid.Controller.OnValueChanging(cellContext, e);
		}
		dataGrid.DataSource.SetEditValue(propertyColumn, e.NewValue);
		if (cellContext.Grid != null)
		{
			cellContext.Grid.Controller.OnValueChanged(cellContext, EventArgs.Empty);
		}
	}
}
