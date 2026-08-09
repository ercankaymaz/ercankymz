using System.Windows.Forms.Classes.Collections;

namespace System.Windows.Forms;

public sealed class RibbonTabCollection : RibbonCollectionBase<RibbonTab>
{
	internal RibbonTabCollection(Ribbon owner)
		: base(owner)
	{
		if (owner == null)
		{
			throw new ArgumentNullException("owner");
		}
	}

	internal override void SetOwner(RibbonTab item)
	{
		item.SetOwner(Owner);
	}

	internal override void ClearOwner(RibbonTab item)
	{
		item.ClearOwner();
	}

	internal override void UpdateRegions()
	{
		try
		{
			Owner.OnRegionsChanged();
		}
		catch
		{
		}
	}

	public new bool Remove(RibbonTab tab)
	{
		if (tab == Owner.ActiveTab)
		{
			if (Owner.Tabs.IndexOf(tab) > 0)
			{
				Owner.ActiveTab = Owner.Tabs[Owner.Tabs.IndexOf(tab) - 1];
				Owner.Tabs.Remove(tab);
			}
			else if (Owner.Tabs.IndexOf(tab) < Owner.Tabs.Count - 1)
			{
				Owner.ActiveTab = Owner.Tabs[Owner.Tabs.IndexOf(tab) + 1];
				Owner.Tabs.Remove(tab);
			}
		}
		return base.Remove(tab);
	}
}
