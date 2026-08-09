using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public class SelectedSketchCurve : SelectedSubItem
{
	protected override int SubItemSortPriority => 1;

	public SelectedSketchCurve()
	{
	}

	public SelectedSketchCurve(Stack<BlockReference> parents, ISelectableItem item, int index)
		: base(parents, item, index)
	{
	}

	public override void Select(bool select)
	{
		SketchEntity sketchEntity = (SketchEntity)base.Item;
		if (base.Index > sketchEntity.CurveList.Count)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997471));
		}
		SelectionInfoSubItems._0023_003DzTaF8sCpHm_00245q((sketchEntity.CurveList[base.Index] is Point) ? selectionFilterType.SketchPoint : selectionFilterType.SketchCurve, base.Index, select, sketchEntity, sketchEntity.CurveList.Count, sketchEntity.SketchCurvesSelectionInfo, base.Parents);
	}
}
