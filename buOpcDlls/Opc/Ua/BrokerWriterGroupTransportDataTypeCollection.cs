// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrokerWriterGroupTransportDataTypeCollection
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
[CollectionDataContract(Name = "ListOfBrokerWriterGroupTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrokerWriterGroupTransportDataType")]
[ComVisible(true)]
public class BrokerWriterGroupTransportDataTypeCollection : 
  List<BrokerWriterGroupTransportDataType>,
  ICloneable
{
  public BrokerWriterGroupTransportDataTypeCollection()
  {
  }

  public BrokerWriterGroupTransportDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public BrokerWriterGroupTransportDataTypeCollection(
    IEnumerable<BrokerWriterGroupTransportDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator BrokerWriterGroupTransportDataTypeCollection(
    BrokerWriterGroupTransportDataType[] values)
  {
    return values != null ? new BrokerWriterGroupTransportDataTypeCollection((IEnumerable<BrokerWriterGroupTransportDataType>) values) : new BrokerWriterGroupTransportDataTypeCollection();
  }

  public static explicit operator BrokerWriterGroupTransportDataType[](
    BrokerWriterGroupTransportDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (BrokerWriterGroupTransportDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    BrokerWriterGroupTransportDataTypeCollection dataTypeCollection = new BrokerWriterGroupTransportDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((BrokerWriterGroupTransportDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
