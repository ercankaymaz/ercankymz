using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfXmlElement", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "XmlElement")]
[ComVisible(true)]
public class XmlElementCollection : List<XmlElement>, ICloneable
{
	public XmlElementCollection()
	{
	}

	public XmlElementCollection(int capacity)
		: base(capacity)
	{
	}

	public XmlElementCollection(IEnumerable<XmlElement> collection)
		: base(collection)
	{
	}

	public static XmlElementCollection ToXmlElementCollection(XmlElement[] values)
	{
		if (values != null)
		{
			return new XmlElementCollection(values);
		}
		return new XmlElementCollection();
	}

	public static implicit operator XmlElementCollection(XmlElement[] values)
	{
		return ToXmlElementCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		XmlElementCollection xmlElementCollection = new XmlElementCollection(base.Count);
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			XmlElement current = enumerator.Current;
			xmlElementCollection.Add((XmlElement)Utils.Clone(current));
		}
		return xmlElementCollection;
	}
}
