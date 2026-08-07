// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SubscriptionAcknowledgementCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
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

  public SubscriptionAcknowledgementCollection(
    IEnumerable<SubscriptionAcknowledgement> collection)
    : base(collection)
  {
  }

  public static implicit operator SubscriptionAcknowledgementCollection(
    SubscriptionAcknowledgement[] values)
  {
    return values != null ? new SubscriptionAcknowledgementCollection((IEnumerable<SubscriptionAcknowledgement>) values) : new SubscriptionAcknowledgementCollection();
  }

  public static explicit operator SubscriptionAcknowledgement[](
    SubscriptionAcknowledgementCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (SubscriptionAcknowledgementCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SubscriptionAcknowledgementCollection acknowledgementCollection = new SubscriptionAcknowledgementCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      acknowledgementCollection.Add((SubscriptionAcknowledgement) Utils.Clone((object) this[index]));
    return (object) acknowledgementCollection;
  }
}
