// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrokerDataSetWriterTransportDataTypeCollection
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
[CollectionDataContract(Name = "ListOfBrokerDataSetWriterTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrokerDataSetWriterTransportDataType")]
[ComVisible(true)]
public class BrokerDataSetWriterTransportDataTypeCollection : 
  List<BrokerDataSetWriterTransportDataType>,
  ICloneable
{
  public BrokerDataSetWriterTransportDataTypeCollection()
  {
  }

  public BrokerDataSetWriterTransportDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public BrokerDataSetWriterTransportDataTypeCollection(
    IEnumerable<BrokerDataSetWriterTransportDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator BrokerDataSetWriterTransportDataTypeCollection(
    BrokerDataSetWriterTransportDataType[] values)
  {
    return values != null ? new BrokerDataSetWriterTransportDataTypeCollection((IEnumerable<BrokerDataSetWriterTransportDataType>) values) : new BrokerDataSetWriterTransportDataTypeCollection();
  }

  public static explicit operator BrokerDataSetWriterTransportDataType[](
    BrokerDataSetWriterTransportDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (BrokerDataSetWriterTransportDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    BrokerDataSetWriterTransportDataTypeCollection dataTypeCollection = new BrokerDataSetWriterTransportDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((BrokerDataSetWriterTransportDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
