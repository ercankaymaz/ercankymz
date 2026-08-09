using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public class SelectedFace : SelectedSubItem
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzroV1hxHK_0024nh_0024RaN0Sw_003D_003D;

	protected override int SubItemSortPriority => 2;

	public int ShellIndex
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzroV1hxHK_0024nh_0024RaN0Sw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzroV1hxHK_0024nh_0024RaN0Sw_003D_003D = value;
		}
	}

	public SelectedFace()
	{
	}

	public SelectedFace(Stack<BlockReference> parents, ISelectableItem item, int index)
		: base(parents, item, index)
	{
	}

	public override void Init(Stack<BlockReference> parents, ISelectableItem item, int subItemIndex = -1, int shellIndex = -1, int nSubItems = -1, object[][] subItemsArray = null)
	{
		base.Init(parents, item, subItemIndex, shellIndex, -1, (object[][])null);
		ShellIndex = shellIndex;
	}

	public override void Select(bool select)
	{
		if (ShellIndex <= 0)
		{
			SelectionInfoSubItems._0023_003DzTaF8sCpHm_00245q(selectionFilterType.Face, base.Index, select, (ISelectableSubItems)base.Item, ((Entity)base.Item)._0023_003Dz5RPGbcVkdZb3(), ((Entity)base.Item)._0023_003Dz4NlMyrooY_aHAHG2Ag_003D_003D(), base.Parents);
			return;
		}
		Brep brep = (Brep)base.Item;
		int shellIndex = ShellIndex;
		int index = base.Index;
		object[][] inners = brep.Inners;
		SelectionInfoSubItemsArray._0023_003DzTaF8sCpHm_00245q(selectionFilterType.Face, shellIndex, index, select, brep, inners, brep.InnerFacesSelectionInfo, base.Parents);
	}

	public override bool Equals(object other)
	{
		if (base.Equals(other))
		{
			if (other is SelectedFace selectedFace)
			{
				return ShellIndex == selectedFace.ShellIndex;
			}
			return false;
		}
		return false;
	}
}
