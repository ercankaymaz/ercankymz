using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;
using Microsoft.Windows.Design.Services;

namespace MS.Internal;

internal static class SelectionImplementation
{
	internal static Selection SelectParent(EditingContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ModelService requiredService = context.Services.GetRequiredService<ModelService>();
		Selection value = context.Items.GetValue<Selection>();
		Selection selection = new Selection();
		ModelItem primarySelection = value.PrimarySelection;
		if (AreSiblings(value))
		{
			selection = new Selection(primarySelection.Parent);
		}
		if (selection.PrimarySelection == null)
		{
			selection = new Selection(requiredService.Root);
		}
		context.Items.SetValue(selection);
		return selection;
	}

	private static IEnumerable<ModelItem> EnumerateContents(ModelItem start)
	{
		if (!IsSelectable(start))
		{
			yield break;
		}
		yield return start;
		ModelProperty content = start.Content;
		if (!(content != null) || !content.IsSet)
		{
			yield break;
		}
		if (content.IsCollection)
		{
			foreach (ModelItem child in content.Collection)
			{
				foreach (ModelItem item in EnumerateContents(child))
				{
					yield return item;
				}
			}
			yield break;
		}
		ModelItem value = content.Value;
		if (value == null)
		{
			yield break;
		}
		foreach (ModelItem item2 in EnumerateContents(value))
		{
			yield return item2;
		}
	}

	internal static Selection SelectAll(EditingContext context, bool local)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ModelService requiredService = context.Services.GetRequiredService<ModelService>();
		Selection value = context.Items.GetValue<Selection>();
		Selection selection = new Selection();
		ModelItem primarySelection = value.PrimarySelection;
		if (local && primarySelection != null)
		{
			if (!IsMultiSelection(value) && primarySelection.Content != null)
			{
				selection = SelectContent(primarySelection);
				if (selection.PrimarySelection == null && primarySelection.Parent != null)
				{
					selection = SelectContent(primarySelection.Parent);
				}
			}
			else if (AreSiblings(value))
			{
				selection = SelectContent(primarySelection.Parent);
			}
		}
		if (selection.PrimarySelection == null)
		{
			selection = new Selection(EnumerateContents(requiredService.Root));
		}
		context.Items.SetValue(selection);
		return selection;
	}

	internal static void SelectNext(EditingContext context)
	{
		Selection value = context.Items.GetValue<Selection>();
		if (IsMultiSelection(value))
		{
			SelectParent(context);
		}
		else if (value.PrimarySelection != null)
		{
			ModelItem modelItem = value.PrimarySelection;
			ViewService service = context.Services.GetService<ViewService>();
			ModelItem modelItem2 = GetFirstChild(value.PrimarySelection, service);
			while (modelItem2 == null && modelItem.Parent != null)
			{
				modelItem2 = GetNextSibling(modelItem, service);
				modelItem = modelItem.Parent;
			}
			if (modelItem2 == null)
			{
				modelItem2 = modelItem;
			}
			if (modelItem2 != null)
			{
				context.Items.SetValue(new Selection(modelItem2));
			}
		}
	}

	internal static void SelectPrevious(EditingContext context)
	{
		Selection value = context.Items.GetValue<Selection>();
		if (IsMultiSelection(value))
		{
			SelectParent(context);
		}
		else if (value.PrimarySelection != null)
		{
			ModelItem primarySelection = value.PrimarySelection;
			ViewService service = context.Services.GetService<ViewService>();
			ModelItem previousSibling = GetPreviousSibling(primarySelection, service);
			previousSibling = ((previousSibling != null) ? GetLastChild(previousSibling, service) : ((primarySelection.Parent != null) ? primarySelection.Parent : GetLastChild(primarySelection, service)));
			if (previousSibling != null)
			{
				context.Items.SetValue(new Selection(previousSibling));
			}
		}
	}

	private static ModelItem GetFirstChild(ModelItem modelItem, ViewService viewService)
	{
		ModelProperty content = modelItem.Content;
		if (content == null)
		{
			return null;
		}
		ModelItem modelItem2 = null;
		if (content.IsCollection)
		{
			modelItem2 = SelectionUtilities.GetNextSelectableChild(modelItem, 0, SelectionUtilities.CollectionTraversalDirection.Forward);
		}
		else if (content.IsSet)
		{
			modelItem2 = content.Value;
		}
		if (modelItem2 == null || !IsSelectable(modelItem2) || modelItem2.View == null)
		{
			return null;
		}
		return modelItem2;
	}

	private static ModelItem GetLastChild(ModelItem modelItem, ViewService viewService)
	{
		ModelItem result = modelItem;
		bool flag = false;
		while (modelItem != null && modelItem.Content != null && !flag)
		{
			if (modelItem.Content.IsCollection)
			{
				int count = modelItem.Content.Collection.Count;
				if (count > 0)
				{
					modelItem = SelectionUtilities.GetNextSelectableChild(modelItem, count - 1, SelectionUtilities.CollectionTraversalDirection.Backward);
				}
				else
				{
					flag = true;
				}
			}
			else if (modelItem.Content.IsSet)
			{
				modelItem = modelItem.Content.Value;
			}
			else
			{
				flag = true;
			}
			if (modelItem != null && IsSelectable(modelItem) && modelItem.View != null)
			{
				result = modelItem;
			}
		}
		return result;
	}

	private static ModelItem GetNextSibling(ModelItem modelItem, ViewService viewService)
	{
		ModelItem parent = modelItem.Parent;
		if (parent == null || parent.Content == null || !parent.Content.IsCollection)
		{
			return null;
		}
		int num = parent.Content.Collection.IndexOf(modelItem);
		return SelectionUtilities.GetNextSelectableChild(parent, num + 1, SelectionUtilities.CollectionTraversalDirection.Forward);
	}

	private static ModelItem GetPreviousSibling(ModelItem modelItem, ViewService viewService)
	{
		ModelItem parent = modelItem.Parent;
		if (parent == null || parent.Content == null || !parent.Content.IsCollection)
		{
			return null;
		}
		int num = parent.Content.Collection.IndexOf(modelItem);
		return SelectionUtilities.GetNextSelectableChild(parent, num - 1, SelectionUtilities.CollectionTraversalDirection.Backward);
	}

	private static bool AreSiblings(Selection s)
	{
		bool result = false;
		if (s != null && s.PrimarySelection != null)
		{
			ModelItem primarySelection = s.PrimarySelection;
			if (primarySelection != null && primarySelection.Parent != null)
			{
				ModelItem parent = primarySelection.Parent;
				result = true;
				foreach (ModelItem selectedObject in s.SelectedObjects)
				{
					if (selectedObject.Parent != parent)
					{
						result = false;
						break;
					}
				}
			}
		}
		return result;
	}

	private static bool IsMultiSelection(Selection s)
	{
		bool result = false;
		if (s != null && s.SelectionCount > 1)
		{
			result = true;
		}
		return result;
	}

	private static Selection SelectContent(ModelItem parent)
	{
		Selection result = new Selection();
		if (parent.Content.IsCollection)
		{
			result = new Selection((IEnumerable)parent.Content.Collection);
		}
		else if (parent.Content.IsDictionary)
		{
			result = new Selection((IEnumerable)parent.Content.Dictionary);
		}
		else if (parent.Content.IsSet && IsSelectable(parent) && IsSelectable(parent.Content.Value))
		{
			result = new Selection(parent.Content.Value);
		}
		return result;
	}

	private static bool IsSelectable(ModelItem item)
	{
		if (item != null && !item.ItemType.IsPrimitive)
		{
			return !typeof(string).Equals(item.ItemType);
		}
		return false;
	}

	internal static void ShowDefaultEvent(EditingContext context)
	{
		Selection value = context.Items.GetValue<Selection>();
		if (value == null)
		{
			return;
		}
		ModelItem primarySelection = value.PrimarySelection;
		if (primarySelection == null)
		{
			return;
		}
		object obj = null;
		foreach (object attribute in primarySelection.GetAttributes(typeof(object)))
		{
			if (attribute.GetType().FullName == typeof(DefaultEventAttribute).FullName)
			{
				obj = attribute;
				break;
			}
		}
		string text = null;
		if (obj != null)
		{
			PropertyInfo property = obj.GetType().GetProperty("Name");
			text = property.GetValue(obj, null) as string;
		}
		if (text == null || primarySelection.Events == null)
		{
			return;
		}
		ModelEvent modelEvent = primarySelection.Events.Find(text);
		if (modelEvent == null)
		{
			return;
		}
		EventBindingService service = context.Services.GetService<EventBindingService>();
		if (service == null)
		{
			return;
		}
		string text2;
		for (text2 = null; modelEvent.Handlers.Count > 0; modelEvent.Handlers.Remove(text2), text2 = null)
		{
			using (IEnumerator<string> enumerator2 = modelEvent.Handlers.GetEnumerator())
			{
				if (enumerator2.MoveNext())
				{
					string current2 = enumerator2.Current;
					text2 = current2;
				}
			}
			try
			{
				service.ValidateMethodName(modelEvent, text2);
			}
			catch (NotSupportedException)
			{
				continue;
			}
			break;
		}
		bool flag = false;
		foreach (string methodHandler in service.GetMethodHandlers(modelEvent))
		{
			if (text2 == null)
			{
				text2 = methodHandler;
				flag = !service.AllowClassNameForMethodName();
				break;
			}
			if (text2 == methodHandler)
			{
				flag = true;
				break;
			}
		}
		if (text2 == null || !flag)
		{
			if (text2 == null)
			{
				text2 = service.CreateUniqueMethodName(modelEvent);
				if (text2 == null)
				{
					return;
				}
			}
			else
			{
				flag = true;
			}
			if (!service.IsExistingMethodName(modelEvent, text2) && !service.CreateMethod(modelEvent, text2))
			{
				return;
			}
			if (!flag && !service.AddEventHandler(modelEvent, text2))
			{
				modelEvent.Handlers.Add(text2);
			}
		}
		service.ShowMethod(modelEvent, text2);
	}
}
