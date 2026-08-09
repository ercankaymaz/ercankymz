using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfSubscriptionDiagnosticsDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SubscriptionDiagnosticsDataType")]
[ComVisible(true)]
public class SubscriptionDiagnosticsDataTypeCollection : List<SubscriptionDiagnosticsDataType>, ICloneable
{
	public SubscriptionDiagnosticsDataTypeCollection()
	{
	}

	public SubscriptionDiagnosticsDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public SubscriptionDiagnosticsDataTypeCollection(IEnumerable<SubscriptionDiagnosticsDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator SubscriptionDiagnosticsDataTypeCollection(SubscriptionDiagnosticsDataType[] values)
	{
		if (values != null)
		{
			return new SubscriptionDiagnosticsDataTypeCollection(values);
		}
		return new SubscriptionDiagnosticsDataTypeCollection();
	}

	public static explicit operator SubscriptionDiagnosticsDataType[](SubscriptionDiagnosticsDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (SubscriptionDiagnosticsDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SubscriptionDiagnosticsDataTypeCollection subscriptionDiagnosticsDataTypeCollection = new SubscriptionDiagnosticsDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			subscriptionDiagnosticsDataTypeCollection.Add((SubscriptionDiagnosticsDataType)Utils.Clone(base[i]));
		}
		return subscriptionDiagnosticsDataTypeCollection;
	}
}
