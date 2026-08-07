// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrokerTransportQualityOfServiceCollection
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
[CollectionDataContract(Name = "ListOfBrokerTransportQualityOfService", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrokerTransportQualityOfService")]
[ComVisible(true)]
public class BrokerTransportQualityOfServiceCollection : 
  List<BrokerTransportQualityOfService>,
  ICloneable
{
  public BrokerTransportQualityOfServiceCollection()
  {
  }

  public BrokerTransportQualityOfServiceCollection(int capacity)
    : base(capacity)
  {
  }

  public BrokerTransportQualityOfServiceCollection(
    IEnumerable<BrokerTransportQualityOfService> collection)
    : base(collection)
  {
  }

  public static implicit operator BrokerTransportQualityOfServiceCollection(
    BrokerTransportQualityOfService[] values)
  {
    return values != null ? new BrokerTransportQualityOfServiceCollection((IEnumerable<BrokerTransportQualityOfService>) values) : new BrokerTransportQualityOfServiceCollection();
  }

  public static explicit operator BrokerTransportQualityOfService[](
    BrokerTransportQualityOfServiceCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (BrokerTransportQualityOfServiceCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    BrokerTransportQualityOfServiceCollection serviceCollection = new BrokerTransportQualityOfServiceCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      serviceCollection.Add((BrokerTransportQualityOfService) Utils.Clone((object) this[index]));
    return (object) serviceCollection;
  }
}
