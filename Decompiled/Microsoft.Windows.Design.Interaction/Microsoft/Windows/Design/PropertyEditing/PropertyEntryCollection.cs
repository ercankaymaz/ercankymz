using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Windows.Design.PropertyEditing;

public abstract class PropertyEntryCollection : IEnumerable<PropertyEntry>, IEnumerable
{
	private PropertyValue _parentValue;

	public PropertyValue ParentValue => _parentValue;

	public abstract PropertyEntry this[string propertyName] { get; }

	public abstract int Count { get; }

	protected PropertyEntryCollection(PropertyValue parentValue)
	{
		if (parentValue == null)
		{
			throw new ArgumentNullException("parentValue");
		}
		_parentValue = parentValue;
	}

	public abstract IEnumerator<PropertyEntry> GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
