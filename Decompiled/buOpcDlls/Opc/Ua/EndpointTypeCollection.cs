using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfEndpointType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "EndpointType")]
[ComVisible(true)]
public class EndpointTypeCollection : List<EndpointType>, ICloneable
{
	public EndpointTypeCollection()
	{
	}

	public EndpointTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public EndpointTypeCollection(IEnumerable<EndpointType> collection)
		: base(collection)
	{
	}

	public static implicit operator EndpointTypeCollection(EndpointType[] values)
	{
		if (values != null)
		{
			return new EndpointTypeCollection(values);
		}
		return new EndpointTypeCollection();
	}

	public static explicit operator EndpointType[](EndpointTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (EndpointTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EndpointTypeCollection endpointTypeCollection = new EndpointTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			endpointTypeCollection.Add((EndpointType)Utils.Clone(base[i]));
		}
		return endpointTypeCollection;
	}
}
