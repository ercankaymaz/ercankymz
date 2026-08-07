// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataSetWriterMessageDataTypeCollection
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
[CollectionDataContract(Name = "ListOfDataSetWriterMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetWriterMessageDataType")]
[ComVisible(true)]
public class DataSetWriterMessageDataTypeCollection : List<DataSetWriterMessageDataType>, ICloneable
{
  public DataSetWriterMessageDataTypeCollection()
  {
  }

  public DataSetWriterMessageDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public DataSetWriterMessageDataTypeCollection(
    IEnumerable<DataSetWriterMessageDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator DataSetWriterMessageDataTypeCollection(
    DataSetWriterMessageDataType[] values)
  {
    return values != null ? new DataSetWriterMessageDataTypeCollection((IEnumerable<DataSetWriterMessageDataType>) values) : new DataSetWriterMessageDataTypeCollection();
  }

  public static explicit operator DataSetWriterMessageDataType[](
    DataSetWriterMessageDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (DataSetWriterMessageDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataSetWriterMessageDataTypeCollection dataTypeCollection = new DataSetWriterMessageDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((DataSetWriterMessageDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
