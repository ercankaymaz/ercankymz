using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms.Classes.Collections;

namespace System.Windows.Forms;

public sealed class RibbonPanelCollection : RibbonCollectionBase<RibbonPanel>
{
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Ribbon Owner => base.Owner ?? OwnerTab.Owner;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonTab OwnerTab { get; private set; }

	public RibbonPanelCollection(RibbonTab ownerTab)
		: base((Ribbon)null)
	{
		OwnerTab = ownerTab ?? throw new ArgumentNullException("ownerTab");
	}

	internal override void SetOwner(RibbonPanel item)
	{
		item.SetOwner(Owner);
		item.SetOwnerTab(OwnerTab);
	}

	internal override void ClearOwner(RibbonPanel item)
	{
		item.ClearOwner();
	}

	internal override void UpdateRegions()
	{
		try
		{
			OwnerTab.UpdatePanelsRegions();
			if (Owner != null && !Owner.IsDisposed)
			{
				Owner.UpdateRegions();
				Owner.Invalidate();
			}
		}
		catch
		{
		}
	}

	internal override void SetOwner(Ribbon owner)
	{
		base.SetOwner(owner);
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.SetOwner(owner);
		}
	}

	internal void SetOwnerTab(RibbonTab ownerTab)
	{
		OwnerTab = ownerTab;
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.SetOwnerTab(OwnerTab);
		}
	}
}
