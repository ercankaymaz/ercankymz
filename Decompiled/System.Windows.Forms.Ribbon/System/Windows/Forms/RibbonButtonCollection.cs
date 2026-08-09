using System.Collections.Generic;
using System.ComponentModel;

namespace System.Windows.Forms;

public class RibbonButtonCollection : RibbonItemCollection
{
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonButtonList OwnerList { get; }

	internal RibbonButtonCollection(RibbonButtonList list)
	{
		OwnerList = list;
	}

	private void CheckRestrictions(RibbonButton button)
	{
		if (button == null)
		{
			throw new ArgumentNullException("button", "The RibbonButtonList only accepts button in the Buttons collection");
		}
		if (button.Style != RibbonButtonStyle.Normal)
		{
			throw new ArgumentException("The only style supported by the RibbonButtonList is Normal");
		}
	}

	public override void Add(RibbonItem item)
	{
		CheckRestrictions(item as RibbonButton);
		item.SetOwner(Owner);
		item.SetOwnerPanel(base.OwnerPanel);
		item.SetOwnerTab(base.OwnerTab);
		item.SetOwnerItem(base.OwnerItem);
		item.Click += OwnerList.item_Click;
		base.Add(item);
	}

	public override void AddRange(IEnumerable<RibbonItem> items)
	{
		foreach (RibbonItem item in items)
		{
			CheckRestrictions(item as RibbonButton);
			item.SetOwner(Owner);
			item.SetOwnerPanel(base.OwnerPanel);
			item.SetOwnerTab(base.OwnerTab);
			item.SetOwnerItem(base.OwnerItem);
		}
		base.AddRange(items);
	}

	public override void Insert(int index, RibbonItem item)
	{
		CheckRestrictions(item as RibbonButton);
		item.SetOwner(Owner);
		item.SetOwnerPanel(base.OwnerPanel);
		item.SetOwnerTab(base.OwnerTab);
		item.SetOwnerItem(OwnerList);
		base.Insert(index, item);
	}
}
