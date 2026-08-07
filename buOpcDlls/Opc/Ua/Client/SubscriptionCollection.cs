// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.SubscriptionCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
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

  public virtual object Clone() => (object) (SubscriptionCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SubscriptionCollection subscriptionCollection = new SubscriptionCollection();
    subscriptionCollection.AddRange(this.Select<Subscription, Subscription>((Func<Subscription, Subscription>) (item => (Subscription) item.Clone())));
    return (object) subscriptionCollection;
  }

  public virtual SubscriptionCollection CloneSubscriptions(bool copyEventhandlers)
  {
    SubscriptionCollection subscriptionCollection = new SubscriptionCollection();
    subscriptionCollection.AddRange(this.Select<Subscription, Subscription>((Func<Subscription, Subscription>) (item => item.CloneSubscription(copyEventhandlers))));
    return subscriptionCollection;
  }
}
