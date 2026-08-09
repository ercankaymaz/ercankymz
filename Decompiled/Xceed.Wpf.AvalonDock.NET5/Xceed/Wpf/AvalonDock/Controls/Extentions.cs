using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Xceed.Wpf.AvalonDock.Controls;

public static class Extentions
{
	public static IEnumerable<T> FindVisualChildren<T>(this DependencyObject depObj) where T : DependencyObject
	{
		if (depObj == null)
		{
			yield break;
		}
		for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
		{
			DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
			if (child != null && child is T)
			{
				yield return (T)(object)child;
			}
			foreach (T item in child.FindVisualChildren<T>())
			{
				yield return item;
			}
		}
	}

	public static IEnumerable<T> FindLogicalChildren<T>(this DependencyObject depObj) where T : DependencyObject
	{
		if (depObj == null)
		{
			yield break;
		}
		foreach (DependencyObject child in LogicalTreeHelper.GetChildren(depObj).OfType<DependencyObject>())
		{
			if (child != null && child is T)
			{
				yield return (T)(object)child;
			}
			foreach (T item in child.FindLogicalChildren<T>())
			{
				yield return item;
			}
		}
	}

	public static DependencyObject FindVisualTreeRoot(this DependencyObject initial)
	{
		DependencyObject val = initial;
		DependencyObject result = initial;
		while (val != null)
		{
			result = val;
			val = ((!(val is Visual) && !(val is Visual3D)) ? LogicalTreeHelper.GetParent(val) : VisualTreeHelper.GetParent(val));
		}
		return result;
	}

	public static T FindVisualAncestor<T>(this DependencyObject dependencyObject) where T : class
	{
		DependencyObject val = dependencyObject;
		do
		{
			val = VisualTreeHelper.GetParent(val);
		}
		while (val != null && !(val is T));
		return val as T;
	}

	public static T FindLogicalAncestor<T>(this DependencyObject dependencyObject) where T : class
	{
		DependencyObject val = dependencyObject;
		do
		{
			DependencyObject reference = val;
			val = LogicalTreeHelper.GetParent(val);
			if (val == null)
			{
				val = VisualTreeHelper.GetParent(reference);
			}
		}
		while (val != null && !(val is T));
		return val as T;
	}

	public static IEnumerable<DependencyObject> FindLogicalAncestorsAndSelf(this DependencyObject self)
	{
		while (self != null)
		{
			yield return self;
			self = LogicalTreeHelper.GetParent(self) ?? VisualTreeHelper.GetParent(self);
		}
	}
}
