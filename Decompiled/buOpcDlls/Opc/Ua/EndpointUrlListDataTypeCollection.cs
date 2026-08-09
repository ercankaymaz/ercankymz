using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfEndpointUrlListDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "EndpointUrlListDataType")]
[ComVisible(true)]
public class EndpointUrlListDataTypeCollection : List<EndpointUrlListDataType>, ICloneable
{
	public EndpointUrlListDataTypeCollection()
	{
	}

	public EndpointUrlListDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public EndpointUrlListDataTypeCollection(IEnumerable<EndpointUrlListDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator EndpointUrlListDataTypeCollection(EndpointUrlListDataType[] values)
	{
		if (values != null)
		{
			return new EndpointUrlListDataTypeCollection(values);
		}
		return new EndpointUrlListDataTypeCollection();
	}

	public static explicit operator EndpointUrlListDataType[](EndpointUrlListDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (EndpointUrlListDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EndpointUrlListDataTypeCollection endpointUrlListDataTypeCollection = new EndpointUrlListDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			endpointUrlListDataTypeCollection.Add((EndpointUrlListDataType)Utils.Clone(base[i]));
		}
		return endpointUrlListDataTypeCollection;
	}
}
