using SourceGrid.Cells;

namespace SourceGrid.Conditions;

public class ConditionCell : ICondition
{
	public delegate bool EvaluateFunctionDelegate(DataGridColumn column, int gridRow, object itemRow);

	public EvaluateFunctionDelegate EvaluateFunction;

	private ICellVirtual cell;

	public ICellVirtual Cell => cell;

	public ConditionCell(ICellVirtual cell)
	{
		this.cell = cell;
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
		return Cell;
	}
}
