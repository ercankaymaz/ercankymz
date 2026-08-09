using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfEndpointDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "EndpointDescription")]
[ComVisible(true)]
public class EndpointDescriptionCollection : List<EndpointDescription>, ICloneable
{
	public EndpointDescriptionCollection()
	{
	}

	public EndpointDescriptionCollection(int capacity)
		: base(capacity)
	{
	}

	public EndpointDescriptionCollection(IEnumerable<EndpointDescription> collection)
		: base(collection)
	{
	}

	public static implicit operator EndpointDescriptionCollection(EndpointDescription[] values)
	{
		if (values != null)
		{
			return new EndpointDescriptionCollection(values);
		}
		return new EndpointDescriptionCollection();
	}

	public static explicit operator EndpointDescription[](EndpointDescriptionCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (EndpointDescriptionCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EndpointDescriptionCollection endpointDescriptionCollection = new EndpointDescriptionCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			endpointDescriptionCollection.Add((EndpointDescription)Utils.Clone(base[i]));
		}
		return endpointDescriptionCollection;
	}
}
