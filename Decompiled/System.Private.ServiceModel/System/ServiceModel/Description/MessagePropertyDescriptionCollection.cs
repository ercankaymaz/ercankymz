using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.ServiceModel.Description;

public class MessagePropertyDescriptionCollection : KeyedCollection<string, MessagePropertyDescription>
{
	internal MessagePropertyDescriptionCollection()
		: base((IEqualityComparer<string>?)null, 4)
	{
	}

	protected override string GetKeyForItem(MessagePropertyDescription item)
	{
		return item.Name;
	}
}
