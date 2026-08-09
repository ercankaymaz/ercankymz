namespace SourceGrid.Cells.Models;

public class ToolTip : IModel, IToolTipText
{
	private string string_0;

	public string ToolTipText
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public string GetToolTipText(CellContext cellContext)
	{
		if (!string.IsNullOrEmpty(string_0) || cellContext.IsEmpty())
		{
			return string_0;
		}
		return cellContext.DisplayText;
	}
}
