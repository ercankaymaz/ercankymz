using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public abstract class SelectedSubItem : SelectedItem
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzU1CozGG3RwnyADLWgA_003D_003D = -1;

	public int Index
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzU1CozGG3RwnyADLWgA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzU1CozGG3RwnyADLWgA_003D_003D = value;
		}
	}

	protected abstract int SubItemSortPriority { get; }

	public SelectedSubItem()
	{
	}

	public SelectedSubItem(Stack<BlockReference> parents, ISelectableItem item, int index)
		: base(parents, item)
	{
		Index = index;
	}

	public override void Init(Stack<BlockReference> parents, ISelectableItem item, int subItemIndex = -1, int shellIndex = -1, int nSubItems = -1, object[][] subItemsArray = null)
	{
		Index = subItemIndex;
		base.Init(parents, item);
	}

	public override bool Equals(object other)
	{
		if (base.Equals(other))
		{
			if (other is SelectedSubItem selectedSubItem)
			{
				return Index == selectedSubItem.Index;
			}
			return false;
		}
		return false;
	}

	public override int CompareTo(object obj)
	{
		return SubItemSortPriority.CompareTo(((SelectedSubItem)obj).SubItemSortPriority);
	}
}
