using System.Drawing;
using SourceGrid.Cells.Views;

namespace SourceGrid.Conditions;

public static class ConditionBuilder
{
	public static ICondition AlternateView(IView view, Color alternateBackcolor, Color alternateForecolor)
	{
		IView view2 = (IView)view.Clone();
		view2.BackColor = alternateBackcolor;
		view2.ForeColor = alternateForecolor;
		ConditionView conditionView = new ConditionView(view2);
		conditionView.EvaluateFunction = (DataGridColumn dataGridColumn_0, int int_0, object object_0) => (int_0 & 1) == 1;
		return conditionView;
	}
}
