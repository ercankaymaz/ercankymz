using System;
using System.Collections.Generic;
using Microsoft.Windows.Design.Model;
using Microsoft.Windows.Design.Services;

namespace Microsoft.Windows.Design.Interaction;

public static class SelectionOperations
{
	public static Selection Select(EditingContext context, ModelItem itemToSelect)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (itemToSelect == null)
		{
			throw new ArgumentNullException("itemToSelect");
		}
		Selection value = context.Items.GetValue<Selection>();
		if (value.PrimarySelection == itemToSelect)
		{
			return value;
		}
		Selection selection = null;
		foreach (ModelItem selectedObject in value.SelectedObjects)
		{
			if (selectedObject == itemToSelect)
			{
				List<ModelItem> list = new List<ModelItem>(value.SelectedObjects);
				list.Remove(itemToSelect);
				list.Insert(0, itemToSelect);
				selection = new Selection(list);
			}
		}
		if (selection == null)
		{
			selection = new Selection(itemToSelect);
		}
		context.Items.SetValue(selection);
		return selection;
	}

	public static Selection SelectOnly(EditingContext context, ModelItem itemToSelect)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (itemToSelect == null)
		{
			throw new ArgumentNullException("itemToSelect");
		}
		Selection value = context.Items.GetValue<Selection>();
		if (value.PrimarySelection == itemToSelect)
		{
			IEnumerator<ModelItem> enumerator = value.SelectedObjects.GetEnumerator();
			enumerator.MoveNext();
			if (!enumerator.MoveNext())
			{
				return value;
			}
		}
		Selection selection = new Selection(itemToSelect);
		context.Items.SetValue(selection);
		return selection;
	}

	public static void Subscribe(EditingContext context, SubscribeContextCallback<Selection> handler)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (handler == null)
		{
			throw new ArgumentNullException("handler");
		}
		context.Items.Subscribe(handler);
	}

	public static Selection Toggle(EditingContext context, ModelItem itemToToggle)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (itemToToggle == null)
		{
			throw new ArgumentNullException("itemToToggle");
		}
		Selection value = context.Items.GetValue<Selection>();
		List<ModelItem> list = new List<ModelItem>(value.SelectedObjects);
		if (list.Contains(itemToToggle))
		{
			list.Remove(itemToToggle);
		}
		else
		{
			list.Insert(0, itemToToggle);
		}
		if (list.Count == 0)
		{
			ModelService service = context.Services.GetService<ModelService>();
			if (service != null)
			{
				list.Add(service.Root);
			}
		}
		Selection selection = new Selection(list);
		context.Items.SetValue(selection);
		return selection;
	}

	public static Selection Union(EditingContext context, ModelItem itemToAdd)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (itemToAdd == null)
		{
			throw new ArgumentNullException("itemToAdd");
		}
		Selection value = context.Items.GetValue<Selection>();
		if (value.PrimarySelection == itemToAdd)
		{
			return value;
		}
		List<ModelItem> list = new List<ModelItem>(value.SelectedObjects);
		if (list.Contains(itemToAdd))
		{
			list.Remove(itemToAdd);
		}
		list.Insert(0, itemToAdd);
		Selection selection = new Selection(list);
		context.Items.SetValue(selection);
		return selection;
	}

	public static void Unsubscribe(EditingContext context, SubscribeContextCallback<Selection> handler)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (handler == null)
		{
			throw new ArgumentNullException("handler");
		}
		context.Items.Unsubscribe(handler);
	}
}
