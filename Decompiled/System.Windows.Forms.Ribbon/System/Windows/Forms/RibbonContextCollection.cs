using System.Windows.Forms.Classes.Collections;

namespace System.Windows.Forms;

public sealed class RibbonContextCollection : RibbonCollectionBase<RibbonContext>
{
	internal RibbonContextCollection(Ribbon owner)
		: base(owner)
	{
		if (owner == null)
		{
			throw new ArgumentNullException("owner");
		}
	}

	public new void Remove(RibbonContext context)
	{
		foreach (RibbonTab contextualTab in context.ContextualTabs)
		{
			contextualTab.Context = null;
		}
		base.Remove(context);
	}

	public new int RemoveAll(Predicate<RibbonContext> predicate)
	{
		throw new NotSupportedException("RibbonContextCollectin.RemoveAll function is not supported");
	}

	public new void RemoveAt(int index)
	{
		foreach (RibbonTab contextualTab in this[index].ContextualTabs)
		{
			contextualTab.Context = null;
		}
		base.RemoveAt(index);
	}

	public new void RemoveRange(int index, int count)
	{
		throw new NotSupportedException("RibbonContextCollection.RemoveRange function is not supported");
	}

	internal override void SetOwner(RibbonContext item)
	{
		item.SetOwner(Owner);
	}

	internal override void ClearOwner(RibbonContext item)
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
}
