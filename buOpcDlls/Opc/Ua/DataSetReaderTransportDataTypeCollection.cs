// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataSetReaderTransportDataTypeCollection
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
[CollectionDataContract(Name = "ListOfDataSetReaderTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetReaderTransportDataType")]
[ComVisible(true)]
public class DataSetReaderTransportDataTypeCollection : 
  List<DataSetReaderTransportDataType>,
  ICloneable
{
  public DataSetReaderTransportDataTypeCollection()
  {
  }

  public DataSetReaderTransportDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public DataSetReaderTransportDataTypeCollection(
    IEnumerable<DataSetReaderTransportDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator DataSetReaderTransportDataTypeCollection(
    DataSetReaderTransportDataType[] values)
  {
    return values != null ? new DataSetReaderTransportDataTypeCollection((IEnumerable<DataSetReaderTransportDataType>) values) : new DataSetReaderTransportDataTypeCollection();
  }

  public static explicit operator DataSetReaderTransportDataType[](
    DataSetReaderTransportDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone()
  {
    return (object) (DataSetReaderTransportDataTypeCollection) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    DataSetReaderTransportDataTypeCollection dataTypeCollection = new DataSetReaderTransportDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((DataSetReaderTransportDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
