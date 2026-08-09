using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.PropertyEditing;

public abstract class PropertyEntry : INotifyPropertyChanged, IPropertyFilterTarget
{
	private PropertyValue _parentValue;

	private bool _matchesFilter = true;

	private PropertyValue _value;

	public abstract string PropertyName { get; }

	public virtual string DisplayName => PropertyName;

	public abstract Type PropertyType { get; }

	public abstract PropertyIdentifier Identifier { get; }

	public abstract string CategoryName { get; }

	public abstract string Description { get; }

	protected virtual bool HasStandardValues
	{
		get
		{
			ICollection standardValues = StandardValues;
			if (standardValues != null)
			{
				return standardValues.Count > 0;
			}
			return false;
		}
	}

	internal bool HasStandardValuesInternal => HasStandardValues;

	public abstract bool IsReadOnly { get; }

	public abstract bool IsAdvanced { get; }

	public abstract ICollection StandardValues { get; }

	public abstract PropertyValueEditor PropertyValueEditor { get; }

	public PropertyValue ParentValue => _parentValue;

	public virtual PropertyValue PropertyValue
	{
		get
		{
			if (_value == null)
			{
				_value = CreatePropertyValueInstance();
			}
			return _value;
		}
	}

	public abstract EditingContext Context { get; }

	public abstract IEnumerable<ModelProperty> ModelProperties { get; }

	public bool MatchesFilter
	{
		get
		{
			return _matchesFilter;
		}
		protected set
		{
			if (value != _matchesFilter)
			{
				_matchesFilter = value;
				OnPropertyChanged("MatchesFilter");
			}
		}
	}

	public event EventHandler<PropertyFilterAppliedEventArgs> FilterApplied;

	public event PropertyChangedEventHandler PropertyChanged;

	protected PropertyEntry()
		: this(null)
	{
	}

	protected PropertyEntry(PropertyValue parentValue)
	{
		_parentValue = parentValue;
	}

	protected abstract PropertyValue CreatePropertyValueInstance();

	public virtual bool MatchesPredicate(PropertyFilterPredicate predicate)
	{
		if (predicate != null)
		{
			if (!predicate.Match(DisplayName))
			{
				return predicate.Match(PropertyType.Name);
			}
			return true;
		}
		return false;
	}

	public virtual void ApplyFilter(PropertyFilter filter)
	{
		MatchesFilter = filter?.Match(this) ?? true;
		OnFilterApplied(filter);
	}

	protected virtual void OnFilterApplied(PropertyFilter filter)
	{
		if (this.FilterApplied != null)
		{
			this.FilterApplied(this, new PropertyFilterAppliedEventArgs(filter));
		}
	}

	protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
	{
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, e);
		}
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
}
