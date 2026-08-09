using System;
using System.Collections.Generic;

namespace Microsoft.Windows.Design.PropertyEditing;

public class PropertyFilter
{
	private List<PropertyFilterPredicate> _predicates = new List<PropertyFilterPredicate>();

	public bool IsEmpty
	{
		get
		{
			if (_predicates != null)
			{
				return _predicates.Count == 0;
			}
			return true;
		}
	}

	public PropertyFilter(string filterText)
	{
		SetPredicates(filterText);
	}

	public PropertyFilter(IEnumerable<PropertyFilterPredicate> predicates)
	{
		SetPredicates(predicates);
	}

	private void SetPredicates(string filterText)
	{
		if (string.IsNullOrEmpty(filterText))
		{
			return;
		}
		string[] array = filterText.Split(' ');
		for (int i = 0; i < array.Length; i++)
		{
			if (!string.IsNullOrEmpty(array[i]))
			{
				_predicates.Add(new PropertyFilterPredicate(array[i]));
			}
		}
	}

	private void SetPredicates(IEnumerable<PropertyFilterPredicate> predicates)
	{
		if (predicates == null)
		{
			return;
		}
		foreach (PropertyFilterPredicate predicate in predicates)
		{
			if (predicate != null)
			{
				_predicates.Add(predicate);
			}
		}
	}

	public bool Match(IPropertyFilterTarget target)
	{
		if (target == null)
		{
			throw new ArgumentNullException("target");
		}
		if (IsEmpty)
		{
			return true;
		}
		bool result = false;
		for (int i = 0; i < _predicates.Count; i++)
		{
			if (!target.MatchesPredicate(_predicates[i]))
			{
				return false;
			}
			result = true;
		}
		return result;
	}
}
