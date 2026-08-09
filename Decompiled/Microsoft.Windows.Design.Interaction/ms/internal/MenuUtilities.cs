using System;
using System.Collections.Generic;
using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Interaction;

namespace MS.Internal;

internal static class MenuUtilities
{
	public delegate IEnumerable<MenuBase> MenuBaseEnumerator();

	public delegate IEnumerable<MenuBase> MenuBaseExpander(MenuGroup group);

	public static int CompareProviders<T>(T provider1, T provider2) where T : FeatureProvider
	{
		return string.Compare(provider1.GetType().FullName, provider2.GetType().FullName, StringComparison.Ordinal);
	}

	public static int CompareContextMenuProviders(ContextMenuProvider provider1, ContextMenuProvider provider2)
	{
		string text = ((provider1.Items.Count > 0) ? provider1.Items[0].Name : string.Empty);
		string text2 = ((provider2.Items.Count > 0) ? provider2.Items[0].Name : string.Empty);
		bool flag = !string.IsNullOrEmpty(text);
		bool flag2 = !string.IsNullOrEmpty(text2);
		if (flag && !flag2)
		{
			return -1;
		}
		if (!flag && flag2)
		{
			return 1;
		}
		int num = 0;
		if (flag && flag2)
		{
			num = string.Compare(text, text2, StringComparison.OrdinalIgnoreCase);
		}
		if (num == 0)
		{
			num = string.Compare(provider1.GetType().FullName, provider2.GetType().FullName, StringComparison.OrdinalIgnoreCase);
		}
		return num;
	}

	public static IEnumerable<MenuBase> ExpandMenuGroups(IEnumerable<MenuBase> items, MenuBaseExpander groupExpander)
	{
		if (items == null)
		{
			throw new ArgumentNullException("items");
		}
		if (groupExpander == null)
		{
			throw new ArgumentNullException("groupExpander");
		}
		foreach (MenuBase item in items)
		{
			if (item is MenuGroup group)
			{
				foreach (MenuBase item2 in ExpandMenuGroups(groupExpander(group), groupExpander))
				{
					yield return item2;
				}
			}
			else
			{
				yield return item;
			}
		}
	}

	public static IEnumerable<MenuBase> MergeMenuGroups(MenuBaseEnumerator rootItemEnumerator)
	{
		List<MenuBase> list = new List<MenuBase>();
		Dictionary<string, MenuGroup> dictionary = new Dictionary<string, MenuGroup>();
		foreach (MenuBase item in rootItemEnumerator())
		{
			if (item is MenuGroup menuGroup)
			{
				string key = menuGroup.Name + menuGroup.HasDropDown;
				if (dictionary.ContainsKey(key))
				{
					MenuGroup menuGroup2 = dictionary[key];
					int num = list.IndexOf(menuGroup2);
					if (num >= 0)
					{
						list.RemoveAt(num);
					}
					if (num >= 0 && num < list.Count)
					{
						list.Insert(num, MergeGroups(menuGroup2, menuGroup));
					}
					else
					{
						list.Add(MergeGroups(menuGroup2, menuGroup));
					}
				}
				else
				{
					dictionary.Add(key, menuGroup);
					list.Add(menuGroup);
				}
			}
			else
			{
				list.Add(item);
			}
		}
		return list;
	}

	private static MenuGroup MergeGroups(MenuGroup existingGroup, MenuGroup groupToMergeIn)
	{
		MenuGroup menuGroup = new MenuGroup(existingGroup.Name, existingGroup.DisplayName);
		menuGroup.HasDropDown = existingGroup.HasDropDown;
		Dictionary<string, MenuGroup> dictionary = new Dictionary<string, MenuGroup>();
		foreach (MenuBase item in existingGroup.Items)
		{
			if (item is MenuGroup menuGroup2)
			{
				string key = menuGroup2.Name + menuGroup2.HasDropDown;
				dictionary.Add(key, menuGroup2);
			}
			menuGroup.Items.Add(item);
		}
		foreach (MenuBase item2 in groupToMergeIn.Items)
		{
			if (item2 is MenuGroup menuGroup3)
			{
				string key2 = menuGroup3.Name + menuGroup3.HasDropDown;
				if (dictionary.ContainsKey(key2))
				{
					menuGroup.Items.Remove(dictionary[key2]);
					menuGroup.Items.Add(MergeGroups(dictionary[key2], menuGroup3));
				}
				else
				{
					menuGroup.Items.Add(item2);
				}
			}
			else
			{
				menuGroup.Items.Add(item2);
			}
		}
		return menuGroup;
	}
}
