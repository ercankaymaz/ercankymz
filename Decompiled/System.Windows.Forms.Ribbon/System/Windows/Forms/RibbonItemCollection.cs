using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms.Classes.Collections;

namespace System.Windows.Forms;

[Editor(typeof(RibbonItemCollectionEditor), typeof(UITypeEditor))]
public class RibbonItemCollection : RibbonCollectionBase<RibbonItem>
{
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonPanel OwnerPanel { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonTab OwnerTab { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonItem OwnerItem { get; private set; }

	internal RibbonItemCollection()
		: base((Ribbon)null)
	{
	}

	internal void SetOwnerTab(RibbonTab tab)
	{
		OwnerTab = tab;
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.SetOwnerTab(tab);
		}
	}

	internal void SetOwnerPanel(RibbonPanel panel)
	{
		OwnerPanel = panel;
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.SetOwnerPanel(panel);
		}
	}

	internal void SetOwnerItem(RibbonItem item)
	{
		OwnerItem = item;
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.SetOwnerItem(item);
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

	internal override void SetOwner(RibbonItem item)
	{
		item.SetOwner(Owner);
		item.SetOwnerPanel(OwnerPanel);
		item.SetOwnerTab(OwnerTab);
		item.SetOwnerItem(OwnerItem);
	}

	internal override void ClearOwner(RibbonItem item)
	{
		item.ClearOwner();
	}

	internal override void UpdateRegions()
	{
		try
		{
			OwnerTab?.UpdatePanelsRegions();
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

	internal int GetItemsLeft(IEnumerable<RibbonItem> items)
	{
		if (base.Count == 0)
		{
			return 0;
		}
		int num = int.MaxValue;
		foreach (RibbonItem item in items)
		{
			if (item.Bounds.X < num)
			{
				num = item.Bounds.X;
			}
		}
		return num;
	}

	internal int GetItemsRight(IEnumerable<RibbonItem> items)
	{
		if (base.Count == 0)
		{
			return 0;
		}
		int num = int.MinValue;
		foreach (RibbonItem item in items)
		{
			if (item.Bounds.Right > num)
			{
				num = item.Bounds.Right;
			}
		}
		return num;
	}

	internal int GetItemsTop(IEnumerable<RibbonItem> items)
	{
		if (base.Count == 0)
		{
			return 0;
		}
		int num = int.MaxValue;
		foreach (RibbonItem item in items)
		{
			if (item.Bounds.Y < num)
			{
				num = item.Bounds.Y;
			}
		}
		return num;
	}

	internal int GetItemsBottom(IEnumerable<RibbonItem> items)
	{
		if (base.Count == 0)
		{
			return 0;
		}
		int num = int.MinValue;
		foreach (RibbonItem item in items)
		{
			if (item.Bounds.Bottom > num)
			{
				num = item.Bounds.Bottom;
			}
		}
		return num;
	}

	internal int GetItemsWidth(IEnumerable<RibbonItem> items)
	{
		return GetItemsRight(items) - GetItemsLeft(items);
	}

	internal int GetItemsHeight(IEnumerable<RibbonItem> items)
	{
		return GetItemsBottom(items) - GetItemsTop(items);
	}

	internal Rectangle GetItemsBounds(IEnumerable<RibbonItem> items)
	{
		return Rectangle.FromLTRB(GetItemsLeft(items), GetItemsTop(items), GetItemsRight(items), GetItemsBottom(items));
	}

	internal int GetItemsLeft()
	{
		if (base.Count == 0)
		{
			return 0;
		}
		int num = int.MaxValue;
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			RibbonItem current = enumerator.Current;
			if (current.Bounds.X < num)
			{
				num = current.Bounds.X;
			}
		}
		return num;
	}

	internal int GetItemsRight()
	{
		if (base.Count == 0)
		{
			return 0;
		}
		int num = int.MinValue;
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				RibbonItem current = enumerator.Current;
				if (current.Visible && current.Bounds.Right > num)
				{
					num = current.Bounds.Right;
				}
			}
		}
		if (num == int.MinValue)
		{
			num = 0;
		}
		return num;
	}

	internal int GetItemsTop()
	{
		if (base.Count == 0)
		{
			return 0;
		}
		int num = int.MaxValue;
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			RibbonItem current = enumerator.Current;
			if (current.Bounds.Y < num)
			{
				num = current.Bounds.Y;
			}
		}
		return num;
	}

	internal int GetItemsBottom()
	{
		if (base.Count == 0)
		{
			return 0;
		}
		int num = int.MinValue;
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				RibbonItem current = enumerator.Current;
				if (current.Visible && current.Bounds.Bottom > num)
				{
					num = current.Bounds.Bottom;
				}
			}
		}
		if (num == int.MinValue)
		{
			num = 0;
		}
		return num;
	}

	internal int GetItemsWidth()
	{
		return GetItemsRight() - GetItemsLeft();
	}

	internal int GetItemsHeight()
	{
		return GetItemsBottom() - GetItemsTop();
	}

	internal Rectangle GetItemsBounds()
	{
		return Rectangle.FromLTRB(GetItemsLeft(), GetItemsTop(), GetItemsRight(), GetItemsBottom());
	}

	internal void MoveTo(Point p)
	{
		MoveTo(this, p);
	}

	internal void MoveTo(IEnumerable<RibbonItem> items, Point p)
	{
		Rectangle itemsBounds = GetItemsBounds(items);
		foreach (RibbonItem item in items)
		{
			int num = item.Bounds.X - itemsBounds.Left;
			int num2 = item.Bounds.Y - itemsBounds.Top;
			item.SetBounds(new Rectangle(new Point(p.X + num, p.Y + num2), item.Bounds.Size));
		}
	}

	internal void CenterItemsInto(Rectangle rectangle)
	{
		CenterItemsInto(this, rectangle);
	}

	internal void CenterItemsVerticallyInto(Rectangle rectangle)
	{
		CenterItemsVerticallyInto(this, rectangle);
	}

	internal void CenterItemsHorizontallyInto(Rectangle rectangle)
	{
		CenterItemsHorizontallyInto(this, rectangle);
	}

	internal void CenterItemsInto(IEnumerable<RibbonItem> items, Rectangle rectangle)
	{
		int x = rectangle.Left + (rectangle.Width - GetItemsWidth()) / 2;
		int y = rectangle.Top + (rectangle.Height - GetItemsHeight()) / 2;
		MoveTo(items, new Point(x, y));
	}

	internal void CenterItemsVerticallyInto(IEnumerable<RibbonItem> items, Rectangle rectangle)
	{
		int itemsLeft = GetItemsLeft(items);
		int y = rectangle.Top + (rectangle.Height - GetItemsHeight(items)) / 2;
		MoveTo(items, new Point(itemsLeft, y));
	}

	internal void CenterItemsHorizontallyInto(IEnumerable<RibbonItem> items, Rectangle rectangle)
	{
		int x = rectangle.Left + (rectangle.Width - GetItemsWidth(items)) / 2;
		int itemsTop = GetItemsTop(items);
		MoveTo(items, new Point(x, itemsTop));
	}

	private void CheckRestrictions(RibbonItem item)
	{
		if (OwnerItem == null && item is RibbonDescriptionMenuItem)
		{
			throw new ApplicationException("The RibbonDescriptionMenuItem item is not supported on a panel");
		}
	}

	public override void Add(RibbonItem item)
	{
		CheckRestrictions(item);
		item.SetOwner(Owner);
		item.SetOwnerPanel(OwnerPanel);
		item.SetOwnerTab(OwnerTab);
		item.SetOwnerItem(OwnerItem);
		base.Add(item);
	}

	public override void AddRange(IEnumerable<RibbonItem> items)
	{
		foreach (RibbonItem item in items)
		{
			CheckRestrictions(item);
			item.SetOwner(Owner);
			item.SetOwnerPanel(OwnerPanel);
			item.SetOwnerTab(OwnerTab);
			item.SetOwnerItem(OwnerItem);
		}
		base.AddRange(items);
	}

	public override void Insert(int index, RibbonItem item)
	{
		CheckRestrictions(item);
		item.SetOwner(Owner);
		item.SetOwnerPanel(OwnerPanel);
		item.SetOwnerTab(OwnerTab);
		base.Insert(index, item);
	}
}
