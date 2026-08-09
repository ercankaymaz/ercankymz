using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;

namespace System.ServiceModel.Description;

public class MessageHeaderDescriptionCollection : KeyedCollection<XmlQualifiedName, MessageHeaderDescription>
{
	internal MessageHeaderDescriptionCollection()
		: base((IEqualityComparer<XmlQualifiedName>?)null, 4)
	{
	}

	protected override XmlQualifiedName GetKeyForItem(MessageHeaderDescription item)
	{
		return new XmlQualifiedName(item.Name, item.Namespace);
	}
}
