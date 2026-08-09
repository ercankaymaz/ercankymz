using System;
using System.Collections.ObjectModel;
using System.Globalization;
using MS.Internal.Properties;
using Microsoft.Windows.Design.Metadata;

namespace Microsoft.Windows.Design.Model;

public class PropertyIdentifierCollection : Collection<PropertyIdentifier>
{
	public void Add(TypeIdentifier typeIdentifier, string name)
	{
		Add(new PropertyIdentifier(typeIdentifier, name));
	}

	public void Add(Type ownerType, string name)
	{
		Add(new PropertyIdentifier(ownerType, name));
	}

	protected override void InsertItem(int index, PropertyIdentifier item)
	{
		if (item.IsEmpty)
		{
			throw new ArgumentNullException("item");
		}
		if (Contains(item))
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_DuplicateItem, new object[1] { item.Name }));
		}
		base.InsertItem(index, item);
	}

	protected override void SetItem(int index, PropertyIdentifier item)
	{
		if (item.IsEmpty)
		{
			throw new ArgumentNullException("item");
		}
		if (Contains(item))
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_DuplicateItem, new object[1] { item.Name }));
		}
		base.SetItem(index, item);
	}
}
