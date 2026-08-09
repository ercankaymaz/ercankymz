using System;
using System.Windows;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

public static class VisualTreeHelperEx
{
	public static DependencyObject FindAncestorByType(DependencyObject element, Type type, bool specificTypeOnly)
	{
		if (element == null)
		{
			return null;
		}
		bool num;
		if (!specificTypeOnly)
		{
			if (((object)element).GetType() == type)
			{
				goto IL_0035;
			}
			num = ((object)element).GetType().IsSubclassOf(type);
		}
		else
		{
			num = ((object)element).GetType() == type;
		}
		if (!num)
		{
			return FindAncestorByType(VisualTreeHelper.GetParent(element), type, specificTypeOnly);
		}
		goto IL_0035;
		IL_0035:
		return element;
	}

	public static T FindAncestorByType<T>(DependencyObject depObj) where T : DependencyObject
	{
		if (depObj == null)
		{
			return default(T);
		}
		if (depObj is T)
		{
			return (T)(object)depObj;
		}
		return FindAncestorByType<T>(VisualTreeHelper.GetParent(depObj));
	}

	public static Visual FindDescendantByName(Visual element, string name)
	{
		if (element != null && element is FrameworkElement && (element as FrameworkElement).Name == name)
		{
			return element;
		}
		Visual visual = null;
		if (element is FrameworkElement)
		{
			(element as FrameworkElement).ApplyTemplate();
		}
		for (int i = 0; i < VisualTreeHelper.GetChildrenCount((DependencyObject)(object)element); i++)
		{
			visual = FindDescendantByName(VisualTreeHelper.GetChild((DependencyObject)(object)element, i) as Visual, name);
			if (visual != null)
			{
				break;
			}
		}
		return visual;
	}

	public static Visual FindDescendantByType(Visual element, Type type)
	{
		return FindDescendantByType(element, type, specificTypeOnly: true);
	}

	public static Visual FindDescendantByType(Visual element, Type type, bool specificTypeOnly)
	{
		if (element == null)
		{
			return null;
		}
		bool num;
		if (!specificTypeOnly)
		{
			if (((object)element).GetType() == type)
			{
				goto IL_0035;
			}
			num = ((object)element).GetType().IsSubclassOf(type);
		}
		else
		{
			num = ((object)element).GetType() == type;
		}
		if (!num)
		{
			Visual visual = null;
			if (element is FrameworkElement)
			{
				(element as FrameworkElement).ApplyTemplate();
			}
			for (int i = 0; i < VisualTreeHelper.GetChildrenCount((DependencyObject)(object)element); i++)
			{
				visual = FindDescendantByType(VisualTreeHelper.GetChild((DependencyObject)(object)element, i) as Visual, type, specificTypeOnly);
				if (visual != null)
				{
					break;
				}
			}
			return visual;
		}
		goto IL_0035;
		IL_0035:
		return element;
	}

	public static T FindDescendantByType<T>(Visual element) where T : Visual
	{
		return (T)FindDescendantByType(element, typeof(T));
	}

	public static Visual FindDescendantWithPropertyValue(Visual element, DependencyProperty dp, object value)
	{
		if (element == null)
		{
			return null;
		}
		if (((DependencyObject)element).GetValue(dp).Equals(value))
		{
			return element;
		}
		Visual visual = null;
		if (element is FrameworkElement)
		{
			(element as FrameworkElement).ApplyTemplate();
		}
		for (int i = 0; i < VisualTreeHelper.GetChildrenCount((DependencyObject)(object)element); i++)
		{
			visual = FindDescendantWithPropertyValue(VisualTreeHelper.GetChild((DependencyObject)(object)element, i) as Visual, dp, value);
			if (visual != null)
			{
				break;
			}
		}
		return visual;
	}
}
