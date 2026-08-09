using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua.Client;

[CollectionDataContract(Name = "ListOfSubscription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Subscription")]
[ComVisible(true)]
public class SubscriptionCollection : List<Subscription>, ICloneable
{
	public SubscriptionCollection()
	{
	}

	public SubscriptionCollection(IEnumerable<Subscription> collection)
		: base(collection)
	{
	}

	public SubscriptionCollection(int capacity)
		: base(capacity)
	{
	}

	public virtual object Clone()
	{
		return (SubscriptionCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SubscriptionCollection subscriptionCollection = new SubscriptionCollection();
		subscriptionCollection.AddRange(this.Select((Subscription item) => (Subscription)item.Clone()));
		return subscriptionCollection;
	}

	public virtual SubscriptionCollection CloneSubscriptions(bool copyEventhandlers)
	{
		SubscriptionCollection subscriptionCollection = new SubscriptionCollection();
		subscriptionCollection.AddRange(this.Select((Subscription item) => item.CloneSubscription(copyEventhandlers)));
		return subscriptionCollection;
	}
}
