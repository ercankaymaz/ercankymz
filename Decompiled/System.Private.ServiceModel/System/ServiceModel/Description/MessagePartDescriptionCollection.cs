using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;

namespace System.ServiceModel.Description;

public class MessagePartDescriptionCollection : KeyedCollection<XmlQualifiedName, MessagePartDescription>
{
	internal MessagePartDescriptionCollection()
		: base((IEqualityComparer<XmlQualifiedName>?)null, 4)
	{
	}

	protected override XmlQualifiedName GetKeyForItem(MessagePartDescription item)
	{
		return new XmlQualifiedName(item.Name, item.Namespace);
	}
}
