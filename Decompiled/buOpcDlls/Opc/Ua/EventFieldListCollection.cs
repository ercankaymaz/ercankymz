using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfEventFieldList", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "EventFieldList")]
[ComVisible(true)]
public class EventFieldListCollection : List<EventFieldList>, ICloneable
{
	public EventFieldListCollection()
	{
	}

	public EventFieldListCollection(int capacity)
		: base(capacity)
	{
	}

	public EventFieldListCollection(IEnumerable<EventFieldList> collection)
		: base(collection)
	{
	}

	public static implicit operator EventFieldListCollection(EventFieldList[] values)
	{
		if (values != null)
		{
			return new EventFieldListCollection(values);
		}
		return new EventFieldListCollection();
	}

	public static explicit operator EventFieldList[](EventFieldListCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (EventFieldListCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EventFieldListCollection eventFieldListCollection = new EventFieldListCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			eventFieldListCollection.Add((EventFieldList)Utils.Clone(base[i]));
		}
		return eventFieldListCollection;
	}
}
