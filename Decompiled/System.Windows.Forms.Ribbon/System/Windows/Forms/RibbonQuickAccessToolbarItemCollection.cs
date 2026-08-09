using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace System.Windows.Forms;

[Editor(typeof(RibbonQuickAccessToolbarItemCollectionEditor), typeof(UITypeEditor))]
public class RibbonQuickAccessToolbarItemCollection : RibbonItemCollection
{
	public RibbonQuickAccessToolbar OwnerToolbar { get; }

	internal RibbonQuickAccessToolbarItemCollection(RibbonQuickAccessToolbar toolbar)
	{
		OwnerToolbar = toolbar;
		SetOwner(toolbar.Owner);
	}

	internal sealed override void SetOwner(Ribbon owner)
	{
		base.SetOwner(owner);
	}

	public override void Add(RibbonItem item)
	{
		item.MaxSizeMode = RibbonElementSizeMode.Compact;
		base.Add(item);
	}

	public override void AddRange(IEnumerable<RibbonItem> items)
	{
		foreach (RibbonItem item in items)
		{
			item.MaxSizeMode = RibbonElementSizeMode.Compact;
		}
		base.AddRange(items);
	}

	public override void Insert(int index, RibbonItem item)
	{
		item.MaxSizeMode = RibbonElementSizeMode.Compact;
		base.Insert(index, item);
	}
}
