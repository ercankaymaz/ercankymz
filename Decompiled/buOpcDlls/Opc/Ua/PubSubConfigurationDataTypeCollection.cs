using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfPubSubConfigurationDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PubSubConfigurationDataType")]
[ComVisible(true)]
public class PubSubConfigurationDataTypeCollection : List<PubSubConfigurationDataType>, ICloneable
{
	public PubSubConfigurationDataTypeCollection()
	{
	}

	public PubSubConfigurationDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public PubSubConfigurationDataTypeCollection(IEnumerable<PubSubConfigurationDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator PubSubConfigurationDataTypeCollection(PubSubConfigurationDataType[] values)
	{
		if (values != null)
		{
			return new PubSubConfigurationDataTypeCollection(values);
		}
		return new PubSubConfigurationDataTypeCollection();
	}

	public static explicit operator PubSubConfigurationDataType[](PubSubConfigurationDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (PubSubConfigurationDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PubSubConfigurationDataTypeCollection pubSubConfigurationDataTypeCollection = new PubSubConfigurationDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			pubSubConfigurationDataTypeCollection.Add((PubSubConfigurationDataType)Utils.Clone(base[i]));
		}
		return pubSubConfigurationDataTypeCollection;
	}
}
