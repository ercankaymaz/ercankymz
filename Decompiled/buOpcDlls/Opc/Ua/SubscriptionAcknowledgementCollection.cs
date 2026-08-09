using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfSubscriptionAcknowledgement", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SubscriptionAcknowledgement")]
[ComVisible(true)]
public class SubscriptionAcknowledgementCollection : List<SubscriptionAcknowledgement>, ICloneable
{
	public SubscriptionAcknowledgementCollection()
	{
	}

	public SubscriptionAcknowledgementCollection(int capacity)
		: base(capacity)
	{
	}

	public SubscriptionAcknowledgementCollection(IEnumerable<SubscriptionAcknowledgement> collection)
		: base(collection)
	{
	}

	public static implicit operator SubscriptionAcknowledgementCollection(SubscriptionAcknowledgement[] values)
	{
		if (values != null)
		{
			return new SubscriptionAcknowledgementCollection(values);
		}
		return new SubscriptionAcknowledgementCollection();
	}

	public static explicit operator SubscriptionAcknowledgement[](SubscriptionAcknowledgementCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (SubscriptionAcknowledgementCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SubscriptionAcknowledgementCollection subscriptionAcknowledgementCollection = new SubscriptionAcknowledgementCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			subscriptionAcknowledgementCollection.Add((SubscriptionAcknowledgement)Utils.Clone(base[i]));
		}
		return subscriptionAcknowledgementCollection;
	}
}
