using System;

namespace SourceGrid.Cells.Models;

public class ValueModel : IValueModel, IModel
{
	private object val;

	public ValueModel()
	{
	}

	public ValueModel(object val)
	{
		this.val = val;
	}

	public object GetValue(CellContext cellContext)
	{
		return val;
	}

	public void SetValue(CellContext cellContext, object newValue)
	{
		if (!IsNewValueEqual(newValue))
		{
			ValueChangeEventArgs e = new ValueChangeEventArgs(val, newValue);
			if (cellContext.Grid != null)
			{
				cellContext.Grid.Controller.OnValueChanging(cellContext, e);
			}
			val = e.NewValue;
			if (cellContext.Grid != null)
			{
				cellContext.Grid.Controller.OnValueChanged(cellContext, EventArgs.Empty);
			}
		}
	}

	public bool IsNewValueEqual(object newValue)
	{
		if (newValue != val)
		{
			object empty = val;
			if (empty == null)
			{
				empty = string.Empty;
			}
			if (newValue == null)
			{
				newValue = string.Empty;
			}
			return newValue.Equals(empty);
		}
		return true;
	}
}
