using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public class SelectedEdge : SelectedSubItem
{
	protected override int SubItemSortPriority => 1;

	public SelectedEdge()
	{
	}

	public SelectedEdge(Stack<BlockReference> parents, ISelectableItem item, int index)
		: base(parents, item, index)
	{
	}

	public override void Select(bool select)
	{
		Brep brep = (Brep)base.Item;
		SelectionInfoSubItems._0023_003DzTaF8sCpHm_00245q(selectionFilterType.Edge, base.Index, select, brep, brep.Edges, brep.EdgesSelectionInfo, base.Parents);
	}
}
