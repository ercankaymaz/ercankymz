using System;

namespace SourceGrid.Cells.Models;

public class NullValueModel : IValueModel, IModel
{
	public static readonly NullValueModel Default = new NullValueModel();

	public object GetValue(CellContext cellContext)
	{
		return null;
	}

	public void SetValue(CellContext cellContext, object p_Value)
	{
		throw new ApplicationException("This model doesn't support editing");
	}

	public string GetDisplayText(CellContext cellContext)
	{
		return null;
	}
}
