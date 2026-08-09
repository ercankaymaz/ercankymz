using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonContextMenuItemCollection : TypedRestrictCollection<KryptonContextMenuItemBase>
{
	private static readonly Type[] _types = new Type[3]
	{
		typeof(KryptonContextMenuItem),
		typeof(KryptonContextMenuSeparator),
		typeof(KryptonContextMenuHeading)
	};

	public override Type[] RestrictTypes => _types;

	public bool ProcessShortcut(Keys keyData)
	{
		using (IEnumerator<KryptonContextMenuItemBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KryptonContextMenuItemBase current = enumerator.Current;
				if (current.ProcessShortcut(keyData))
				{
					return true;
				}
			}
		}
		return false;
	}

	internal void GenerateView(IContextMenuProvider provider, KryptonContextMenuItems items, object parent, ViewLayoutStack columns, bool standardStyle, bool imageColumn)
	{
		ViewBase viewBase = AddColumn(provider, items, columns, standardStyle, imageColumn);
		using IEnumerator<KryptonContextMenuItemBase> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			KryptonContextMenuItemBase current = enumerator.Current;
			if (!current.Visible)
			{
				continue;
			}
			if (current is KryptonContextMenuSeparator)
			{
				KryptonContextMenuSeparator kryptonContextMenuSeparator = (KryptonContextMenuSeparator)current;
				if (!kryptonContextMenuSeparator.Horizontal)
				{
					columns.Add(kryptonContextMenuSeparator.GenerateView(provider, this, columns, standardStyle, imageColumn));
					viewBase = AddColumn(provider, items, columns, standardStyle, imageColumn);
				}
				else
				{
					viewBase.Add(kryptonContextMenuSeparator.GenerateView(provider, this, columns, standardStyle, imageColumn));
				}
			}
			else
			{
				viewBase.Add(current.GenerateView(provider, this, columns, standardStyle, imageColumn));
			}
		}
	}

	private ViewBase AddColumn(IContextMenuProvider provider, KryptonContextMenuItems items, ViewLayoutStack columns, bool standardStyle, bool imageColumn)
	{
		ViewLayoutMenuItemsPile viewLayoutMenuItemsPile = new ViewLayoutMenuItemsPile(provider, items, standardStyle, imageColumn);
		columns.Add(viewLayoutMenuItemsPile);
		return viewLayoutMenuItemsPile.ItemStack;
	}
}
