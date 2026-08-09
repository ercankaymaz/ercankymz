using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace SourceGrid.Conditions;

public class ConditionView : ICondition
{
	public delegate bool EvaluateFunctionDelegate(DataGridColumn column, int gridRow, object itemRow);

	public EvaluateFunctionDelegate EvaluateFunction;

	private IView view;

	public IView View => view;

	public ConditionView(IView view)
	{
		this.view = view;
	}

	public bool Evaluate(DataGridColumn column, int gridRow, object itemRow)
	{
		if (EvaluateFunction != null)
		{
			return EvaluateFunction(column, gridRow, itemRow);
		}
		return false;
	}

	public ICellVirtual ApplyCondition(ICellVirtual cell)
	{
		ICellVirtual cellVirtual = cell.Copy();
		cellVirtual.View = View;
		return cellVirtual;
	}
}
