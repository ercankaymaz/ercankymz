using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public class SelectedVertex : SelectedSubItem
{
	protected override int SubItemSortPriority => 0;

	public SelectedVertex()
	{
	}

	public SelectedVertex(Stack<BlockReference> parents, ISelectableItem item, int index)
		: base(parents, item, index)
	{
	}

	public override void Select(bool select)
	{
		Brep brep = (Brep)base.Item;
		SelectionInfoSubItems._0023_003DzTaF8sCpHm_00245q(selectionFilterType.Vertex, base.Index, select, brep, brep.Vertices, brep.VerticesSelectionInfo, base.Parents);
	}
}
