using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public class SelectedItem : SelectedItemBase
{
	public SelectedItem(Stack<BlockReference> parents)
		: base(parents)
	{
	}

	public SelectedItem(ISelectableItem item)
		: base(item)
	{
	}

	public SelectedItem(Stack<BlockReference> parents, ISelectableItem item)
		: base(parents, item)
	{
	}

	public SelectedItem()
	{
	}

	internal static List<int> ConvertItemsToIndices(List<SelectedItem> _0023_003DzhrgkevI_003D, IList<Entity> _0023_003Dzv7xH9gk_003D)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < _0023_003DzhrgkevI_003D.Count; i++)
		{
			SelectedItem selectedItem = _0023_003DzhrgkevI_003D[i];
			int num = -1;
			if (selectedItem.Parents == null || selectedItem.Parents.Count == 0)
			{
				num = SelectedItemBase.FindEntityIndex((Entity)selectedItem.Item, _0023_003Dzv7xH9gk_003D);
			}
			if (num >= 0)
			{
				list.Add(num);
			}
		}
		return list;
	}

	internal static List<SelectedItem> ConvertIndicesToItems(IList<int> _0023_003DzDPPdnUk_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, IList<Entity> _0023_003Dzv7xH9gk_003D)
	{
		List<SelectedItem> list = new List<SelectedItem>();
		for (int i = 0; i < _0023_003DzDPPdnUk_003D.Count; i++)
		{
			list.Add(new SelectedItem(_0023_003Dzq5nwX2I_003D, _0023_003Dzv7xH9gk_003D[_0023_003DzDPPdnUk_003D[i]]));
		}
		return list;
	}

	public virtual void Select(bool select)
	{
		if (base.Item is Entity)
		{
			Entity entity = (Entity)base.Item;
			SelectionInfoItem selectionInfoItem = ((!select) ? SelectionInfoItemBase.FindInstance(base.Parents, entity, entity._selectionInfo, entity.InstanceSelectionInfo) : SelectionInfoItemBase.FindInstanceOrCreate(base.Parents, entity, entity._selectionInfo, entity.InstanceSelectionInfo));
			if (selectionInfoItem != null && selectionInfoItem.SelectionInfo.Selected != select)
			{
				selectionInfoItem.SelectionInfo.Selected = select;
				entity.isDirtyForFlattenTree = true;
			}
		}
	}
}
