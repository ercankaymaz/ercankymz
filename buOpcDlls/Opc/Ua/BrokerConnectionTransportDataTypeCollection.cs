// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrokerConnectionTransportDataTypeCollection
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
[CollectionDataContract(Name = "ListOfBrokerConnectionTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrokerConnectionTransportDataType")]
[ComVisible(true)]
public class BrokerConnectionTransportDataTypeCollection : 
  List<BrokerConnectionTransportDataType>,
  ICloneable
{
  public BrokerConnectionTransportDataTypeCollection()
  {
  }

  public BrokerConnectionTransportDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public BrokerConnectionTransportDataTypeCollection(
    IEnumerable<BrokerConnectionTransportDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator BrokerConnectionTransportDataTypeCollection(
    BrokerConnectionTransportDataType[] values)
  {
    return values != null ? new BrokerConnectionTransportDataTypeCollection((IEnumerable<BrokerConnectionTransportDataType>) values) : new BrokerConnectionTransportDataTypeCollection();
  }

  public static explicit operator BrokerConnectionTransportDataType[](
    BrokerConnectionTransportDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (BrokerConnectionTransportDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    BrokerConnectionTransportDataTypeCollection dataTypeCollection = new BrokerConnectionTransportDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((BrokerConnectionTransportDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
