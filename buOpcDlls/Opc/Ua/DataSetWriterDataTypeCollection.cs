// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataSetWriterDataTypeCollection
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
[CollectionDataContract(Name = "ListOfDataSetWriterDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetWriterDataType")]
[ComVisible(true)]
public class DataSetWriterDataTypeCollection : List<DataSetWriterDataType>, ICloneable
{
  public DataSetWriterDataTypeCollection()
  {
  }

  public DataSetWriterDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public DataSetWriterDataTypeCollection(IEnumerable<DataSetWriterDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator DataSetWriterDataTypeCollection(DataSetWriterDataType[] values)
  {
    return values != null ? new DataSetWriterDataTypeCollection((IEnumerable<DataSetWriterDataType>) values) : new DataSetWriterDataTypeCollection();
  }

  public static explicit operator DataSetWriterDataType[](DataSetWriterDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (DataSetWriterDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataSetWriterDataTypeCollection dataTypeCollection = new DataSetWriterDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((DataSetWriterDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
