using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[Editor("ComponentFactory.Krypton.Toolkit.KryptonContextMenuCollectionEditor, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e", typeof(UITypeEditor))]
public class KryptonContextMenuCollection : TypedRestrictCollection<KryptonContextMenuItemBase>
{
	private static readonly Type[] _types = new Type[10]
	{
		typeof(KryptonContextMenuItems),
		typeof(KryptonContextMenuSeparator),
		typeof(KryptonContextMenuHeading),
		typeof(KryptonContextMenuLinkLabel),
		typeof(KryptonContextMenuCheckBox),
		typeof(KryptonContextMenuCheckButton),
		typeof(KryptonContextMenuRadioButton),
		typeof(KryptonContextMenuColorColumns),
		typeof(KryptonContextMenuMonthCalendar),
		typeof(KryptonContextMenuImageSelect)
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

	public void GenerateView(IContextMenuProvider provider, object parent, ViewLayoutStack columns, bool standardStyle, bool imageColumn)
	{
		ViewLayoutStack viewLayoutStack = AddColumn(columns);
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
					provider.ProviderViewColumns.Add(kryptonContextMenuSeparator.GenerateView(provider, this, columns, standardStyle, imageColumn));
					viewLayoutStack = AddColumn(columns);
				}
				else
				{
					viewLayoutStack.Add(kryptonContextMenuSeparator.GenerateView(provider, this, columns, standardStyle, imageColumn));
				}
			}
			else
			{
				viewLayoutStack.Add(current.GenerateView(provider, this, columns, standardStyle, imageColumn));
			}
		}
	}

	protected override void OnInserted(TypedCollectionEventArgs<KryptonContextMenuItemBase> e)
	{
		base.OnInserted(e);
		if (e.Item is KryptonContextMenuRadioButton kryptonContextMenuRadioButton)
		{
			kryptonContextMenuRadioButton.CheckedChanged += OnRadioButtonCheckedChanged;
		}
	}

	protected override void OnRemoving(TypedCollectionEventArgs<KryptonContextMenuItemBase> e)
	{
		if (e.Item is KryptonContextMenuRadioButton kryptonContextMenuRadioButton)
		{
			kryptonContextMenuRadioButton.CheckedChanged -= OnRadioButtonCheckedChanged;
		}
		base.OnRemoving(e);
	}

	private void OnRadioButtonCheckedChanged(object sender, EventArgs e)
	{
		KryptonContextMenuRadioButton kryptonContextMenuRadioButton = sender as KryptonContextMenuRadioButton;
		if (kryptonContextMenuRadioButton.Checked)
		{
			int num = IndexOf(kryptonContextMenuRadioButton);
			UncheckRadioButtons(num - 1, 0, -1);
			UncheckRadioButtons(num + 1, base.Count - 1, 1);
		}
	}

	private void UncheckRadioButtons(int start, int end, int change)
	{
		if (start < 0 || start >= base.Count)
		{
			return;
		}
		while (base[start] is KryptonContextMenuRadioButton kryptonContextMenuRadioButton)
		{
			if (kryptonContextMenuRadioButton.Checked)
			{
				kryptonContextMenuRadioButton.Checked = false;
			}
			if (start == end)
			{
				break;
			}
			start += change;
			bool flag = true;
		}
	}

	private ViewLayoutStack AddColumn(ViewLayoutStack columns)
	{
		ViewLayoutStack viewLayoutStack = new ViewLayoutStack(horizontal: false);
		columns.Add(viewLayoutStack);
		return viewLayoutStack;
	}
}
