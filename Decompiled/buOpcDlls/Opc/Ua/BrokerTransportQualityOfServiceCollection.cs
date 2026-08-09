using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfBrokerTransportQualityOfService", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrokerTransportQualityOfService")]
[ComVisible(true)]
public class BrokerTransportQualityOfServiceCollection : List<BrokerTransportQualityOfService>, ICloneable
{
	public BrokerTransportQualityOfServiceCollection()
	{
	}

	public BrokerTransportQualityOfServiceCollection(int capacity)
		: base(capacity)
	{
	}

	public BrokerTransportQualityOfServiceCollection(IEnumerable<BrokerTransportQualityOfService> collection)
		: base(collection)
	{
	}

	public static implicit operator BrokerTransportQualityOfServiceCollection(BrokerTransportQualityOfService[] values)
	{
		if (values != null)
		{
			return new BrokerTransportQualityOfServiceCollection(values);
		}
		return new BrokerTransportQualityOfServiceCollection();
	}

	public static explicit operator BrokerTransportQualityOfService[](BrokerTransportQualityOfServiceCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (BrokerTransportQualityOfServiceCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrokerTransportQualityOfServiceCollection brokerTransportQualityOfServiceCollection = new BrokerTransportQualityOfServiceCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			brokerTransportQualityOfServiceCollection.Add((BrokerTransportQualityOfService)Utils.Clone(base[i]));
		}
		return brokerTransportQualityOfServiceCollection;
	}
}
