using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public class SelectedSubCurve : SelectedSubItem
{
	protected override int SubItemSortPriority => -1;

	public SelectedSubCurve()
	{
	}

	public SelectedSubCurve(Stack<BlockReference> parents, ISelectableItem item, int index)
		: base(parents, item, index)
	{
	}

	public override void Select(bool select)
	{
		CompositeCurve compositeCurve = (CompositeCurve)base.Item;
		SelectionInfoSubItems._0023_003DzTaF8sCpHm_00245q(selectionFilterType.SubCurve, base.Index, select, compositeCurve, compositeCurve.CurveList.Count, compositeCurve.SubCurvesSelectionInfo, base.Parents);
	}
}
