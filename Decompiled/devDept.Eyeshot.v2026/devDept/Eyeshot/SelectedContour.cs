using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public class SelectedContour : SelectedSubItem
{
	protected override int SubItemSortPriority => -1;

	public SelectedContour()
	{
	}

	public SelectedContour(Stack<BlockReference> parents, ISelectableItem item, int index)
		: base(parents, item, index)
	{
	}

	public override void Select(bool select)
	{
		Region region = (Region)base.Item;
		SelectionInfoSubItems._0023_003DzTaF8sCpHm_00245q(selectionFilterType.Contour, base.Index, select, (ISelectableSubItems)base.Item, region.ContourList.Count, region.SubContoursSelectionInfo, base.Parents);
	}
}
