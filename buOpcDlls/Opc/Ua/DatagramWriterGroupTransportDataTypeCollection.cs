// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DatagramWriterGroupTransportDataTypeCollection
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
[CollectionDataContract(Name = "ListOfDatagramWriterGroupTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DatagramWriterGroupTransportDataType")]
[ComVisible(true)]
public class DatagramWriterGroupTransportDataTypeCollection : 
  List<DatagramWriterGroupTransportDataType>,
  ICloneable
{
  public DatagramWriterGroupTransportDataTypeCollection()
  {
  }

  public DatagramWriterGroupTransportDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public DatagramWriterGroupTransportDataTypeCollection(
    IEnumerable<DatagramWriterGroupTransportDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator DatagramWriterGroupTransportDataTypeCollection(
    DatagramWriterGroupTransportDataType[] values)
  {
    return values != null ? new DatagramWriterGroupTransportDataTypeCollection((IEnumerable<DatagramWriterGroupTransportDataType>) values) : new DatagramWriterGroupTransportDataTypeCollection();
  }

  public static explicit operator DatagramWriterGroupTransportDataType[](
    DatagramWriterGroupTransportDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (DatagramWriterGroupTransportDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    DatagramWriterGroupTransportDataTypeCollection dataTypeCollection = new DatagramWriterGroupTransportDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((DatagramWriterGroupTransportDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
