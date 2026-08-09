using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Microsoft.Windows.Design.PropertyEditing;

public abstract class CategoryEntry : INotifyPropertyChanged, IPropertyFilterTarget
{
	private string _name;

	private bool _matchesFilter;

	public string CategoryName => _name;

	public abstract IEnumerable<PropertyEntry> Properties { get; }

	public abstract PropertyEntry this[string propertyName] { get; }

	public virtual bool MatchesFilter
	{
		get
		{
			return _matchesFilter;
		}
		protected set
		{
			if (_matchesFilter != value)
			{
				_matchesFilter = value;
				OnPropertyChanged("MatchesFilter");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	public event EventHandler<PropertyFilterAppliedEventArgs> FilterApplied;

	protected CategoryEntry(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new ArgumentNullException("name");
		}
		_name = name;
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (propertyName == null)
		{
			throw new ArgumentNullException("propertyName");
		}
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	protected virtual void OnFilterApplied(PropertyFilter filter)
	{
		if (this.FilterApplied != null)
		{
			this.FilterApplied(this, new PropertyFilterAppliedEventArgs(filter));
		}
	}

	public virtual void ApplyFilter(PropertyFilter filter)
	{
		MatchesFilter = filter?.Match(this) ?? true;
		OnFilterApplied(filter);
	}

	public abstract bool MatchesPredicate(PropertyFilterPredicate predicate);
}
