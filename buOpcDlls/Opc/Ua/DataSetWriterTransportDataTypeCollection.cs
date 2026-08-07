// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataSetWriterTransportDataTypeCollection
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
[CollectionDataContract(Name = "ListOfDataSetWriterTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetWriterTransportDataType")]
[ComVisible(true)]
public class DataSetWriterTransportDataTypeCollection : 
  List<DataSetWriterTransportDataType>,
  ICloneable
{
  public DataSetWriterTransportDataTypeCollection()
  {
  }

  public DataSetWriterTransportDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public DataSetWriterTransportDataTypeCollection(
    IEnumerable<DataSetWriterTransportDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator DataSetWriterTransportDataTypeCollection(
    DataSetWriterTransportDataType[] values)
  {
    return values != null ? new DataSetWriterTransportDataTypeCollection((IEnumerable<DataSetWriterTransportDataType>) values) : new DataSetWriterTransportDataTypeCollection();
  }

  public static explicit operator DataSetWriterTransportDataType[](
    DataSetWriterTransportDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (DataSetWriterTransportDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    DataSetWriterTransportDataTypeCollection dataTypeCollection = new DataSetWriterTransportDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((DataSetWriterTransportDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
