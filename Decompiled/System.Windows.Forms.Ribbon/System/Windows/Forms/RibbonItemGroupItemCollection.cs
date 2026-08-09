using System.Collections.Generic;

namespace System.Windows.Forms;

public class RibbonItemGroupItemCollection : RibbonItemCollection
{
	public RibbonItemGroup OwnerGroup { get; }

	internal RibbonItemGroupItemCollection(RibbonItemGroup ownerGroup)
	{
		OwnerGroup = ownerGroup;
	}

	public override void Add(RibbonItem item)
	{
		item.MaxSizeMode = RibbonElementSizeMode.Compact;
		item.SetOwnerItem(OwnerGroup);
		base.Add(item);
	}

	public override void AddRange(IEnumerable<RibbonItem> items)
	{
		foreach (RibbonItem item in items)
		{
			item.MaxSizeMode = RibbonElementSizeMode.Compact;
			item.SetOwnerItem(OwnerGroup);
		}
		base.AddRange(items);
	}

	public override void Insert(int index, RibbonItem item)
	{
		item.MaxSizeMode = RibbonElementSizeMode.Compact;
		item.SetOwnerItem(OwnerGroup);
		base.Insert(index, item);
	}
}
