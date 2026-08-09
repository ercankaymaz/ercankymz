using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Data;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Interaction;

public class Selection : ContextItem
{
	private ICollection<ModelItem> _selectedObjects;

	private Selection _viewSelection;

	private static readonly TypeIdentifier CollectionViewSourceType = new TypeIdentifier(typeof(CollectionViewSource).FullName);

	private static readonly TypeIdentifier DomainDataSourceType = new TypeIdentifier("System.Windows.Controls.DomainDataSource");

	public Selection ViewSelection
	{
		get
		{
			if (_viewSelection == null)
			{
				bool flag = false;
				if (_selectedObjects.Count > 0)
				{
					foreach (ModelItem selectedObject in _selectedObjects)
					{
						if (!HasView(selectedObject))
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					HashSet<ModelItem> hashSet = new HashSet<ModelItem>();
					List<ModelItem> list = new List<ModelItem>(_selectedObjects.Count);
					foreach (ModelItem selectedObject2 in _selectedObjects)
					{
						ModelItem modelItem = selectedObject2;
						while (modelItem != null && !HasView(modelItem))
						{
							modelItem = modelItem.Parent;
						}
						if (modelItem != null && !hashSet.Contains(modelItem))
						{
							hashSet.Add(modelItem);
							list.Add(modelItem);
						}
					}
					_viewSelection = new Selection(list);
				}
				else
				{
					_viewSelection = this;
				}
			}
			return _viewSelection;
		}
	}

	public ModelItem PrimarySelection
	{
		get
		{
			using (IEnumerator<ModelItem> enumerator = _selectedObjects.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					return enumerator.Current;
				}
			}
			return null;
		}
	}

	public IEnumerable<ModelItem> SelectedObjects => _selectedObjects;

	public int SelectionCount => _selectedObjects.Count;

	public sealed override Type ItemType => typeof(Selection);

	public Selection()
	{
		_selectedObjects = new ModelItem[0];
	}

	public Selection(IEnumerable<ModelItem> selectedObjects)
	{
		if (selectedObjects == null)
		{
			throw new ArgumentNullException("selectedObjects");
		}
		List<ModelItem> list = new List<ModelItem>();
		list.AddRange(selectedObjects);
		_selectedObjects = list;
	}

	public Selection(IEnumerable<ModelItem> selectedObjects, Predicate<ModelItem> match)
	{
		if (selectedObjects == null)
		{
			throw new ArgumentNullException("selectedObjects");
		}
		if (match == null)
		{
			throw new ArgumentNullException("match");
		}
		List<ModelItem> list = new List<ModelItem>();
		foreach (ModelItem selectedObject in selectedObjects)
		{
			if (match(selectedObject))
			{
				list.Add(selectedObject);
			}
		}
		_selectedObjects = list;
	}

	public Selection(IEnumerable selectedObjects)
	{
		if (selectedObjects == null)
		{
			throw new ArgumentNullException("selectedObjects");
		}
		List<ModelItem> list = new List<ModelItem>();
		foreach (object selectedObject in selectedObjects)
		{
			if (selectedObject is ModelItem item)
			{
				list.Add(item);
			}
		}
		_selectedObjects = list;
	}

	public Selection(IEnumerable selectedObjects, Predicate<ModelItem> match)
	{
		if (selectedObjects == null)
		{
			throw new ArgumentNullException("selectedObjects");
		}
		if (match == null)
		{
			throw new ArgumentNullException("match");
		}
		List<ModelItem> list = new List<ModelItem>();
		foreach (object selectedObject in selectedObjects)
		{
			if (selectedObject is ModelItem modelItem && match(modelItem))
			{
				list.Add(modelItem);
			}
		}
		_selectedObjects = list;
	}

	public Selection(params ModelItem[] selectedObjects)
		: this((IEnumerable<ModelItem>)selectedObjects)
	{
	}

	private bool HasView(ModelItem modelItem)
	{
		if (!(modelItem.View != null) && !modelItem.IsItemOfType(CollectionViewSourceType))
		{
			return modelItem.IsItemOfType(DomainDataSourceType);
		}
		return true;
	}
}
