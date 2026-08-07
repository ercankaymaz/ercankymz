// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrokerDataSetReaderTransportDataTypeCollection
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
[CollectionDataContract(Name = "ListOfBrokerDataSetReaderTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrokerDataSetReaderTransportDataType")]
[ComVisible(true)]
public class BrokerDataSetReaderTransportDataTypeCollection : 
  List<BrokerDataSetReaderTransportDataType>,
  ICloneable
{
  public BrokerDataSetReaderTransportDataTypeCollection()
  {
  }

  public BrokerDataSetReaderTransportDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public BrokerDataSetReaderTransportDataTypeCollection(
    IEnumerable<BrokerDataSetReaderTransportDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator BrokerDataSetReaderTransportDataTypeCollection(
    BrokerDataSetReaderTransportDataType[] values)
  {
    return values != null ? new BrokerDataSetReaderTransportDataTypeCollection((IEnumerable<BrokerDataSetReaderTransportDataType>) values) : new BrokerDataSetReaderTransportDataTypeCollection();
  }

  public static explicit operator BrokerDataSetReaderTransportDataType[](
    BrokerDataSetReaderTransportDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (BrokerDataSetReaderTransportDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    BrokerDataSetReaderTransportDataTypeCollection dataTypeCollection = new BrokerDataSetReaderTransportDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((BrokerDataSetReaderTransportDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
