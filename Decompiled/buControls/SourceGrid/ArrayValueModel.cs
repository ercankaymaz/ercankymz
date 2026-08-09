using System;
using SourceGrid.Cells.Models;

namespace SourceGrid;

public class ArrayValueModel : IValueModel, IModel
{
	public virtual object GetValue(CellContext cellContext)
	{
		Array dataSource = ((ArrayGrid)cellContext.Grid).DataSource;
		return dataSource.GetValue(cellContext.Position.Row - cellContext.Grid.FixedRows, cellContext.Position.Column - cellContext.Grid.FixedColumns);
	}

	public virtual void SetValue(CellContext cellContext, object p_Value)
	{
		Array dataSource = ((ArrayGrid)cellContext.Grid).DataSource;
		object value = dataSource.GetValue(cellContext.Position.Row - cellContext.Grid.FixedRows, cellContext.Position.Column - cellContext.Grid.FixedColumns);
		ValueChangeEventArgs e = new ValueChangeEventArgs(value, p_Value);
		if (cellContext.Grid != null)
		{
			cellContext.Grid.Controller.OnValueChanging(cellContext, e);
		}
		dataSource.SetValue(p_Value, cellContext.Position.Row - cellContext.Grid.FixedRows, cellContext.Position.Column - cellContext.Grid.FixedColumns);
		if (cellContext.Grid != null)
		{
			cellContext.Grid.Controller.OnValueChanged(cellContext, EventArgs.Empty);
		}
	}
}
