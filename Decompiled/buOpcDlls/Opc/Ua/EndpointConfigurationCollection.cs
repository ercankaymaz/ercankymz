using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfEndpointConfiguration", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "EndpointConfiguration")]
[ComVisible(true)]
public class EndpointConfigurationCollection : List<EndpointConfiguration>, ICloneable
{
	public EndpointConfigurationCollection()
	{
	}

	public EndpointConfigurationCollection(int capacity)
		: base(capacity)
	{
	}

	public EndpointConfigurationCollection(IEnumerable<EndpointConfiguration> collection)
		: base(collection)
	{
	}

	public static implicit operator EndpointConfigurationCollection(EndpointConfiguration[] values)
	{
		if (values != null)
		{
			return new EndpointConfigurationCollection(values);
		}
		return new EndpointConfigurationCollection();
	}

	public static explicit operator EndpointConfiguration[](EndpointConfigurationCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (EndpointConfigurationCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EndpointConfigurationCollection endpointConfigurationCollection = new EndpointConfigurationCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			endpointConfigurationCollection.Add((EndpointConfiguration)Utils.Clone(base[i]));
		}
		return endpointConfigurationCollection;
	}
}
