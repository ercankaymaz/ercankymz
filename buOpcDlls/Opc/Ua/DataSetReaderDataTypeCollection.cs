// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataSetReaderDataTypeCollection
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
[CollectionDataContract(Name = "ListOfDataSetReaderDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetReaderDataType")]
[ComVisible(true)]
public class DataSetReaderDataTypeCollection : List<DataSetReaderDataType>, ICloneable
{
  public DataSetReaderDataTypeCollection()
  {
  }

  public DataSetReaderDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public DataSetReaderDataTypeCollection(IEnumerable<DataSetReaderDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator DataSetReaderDataTypeCollection(DataSetReaderDataType[] values)
  {
    return values != null ? new DataSetReaderDataTypeCollection((IEnumerable<DataSetReaderDataType>) values) : new DataSetReaderDataTypeCollection();
  }

  public static explicit operator DataSetReaderDataType[](DataSetReaderDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (DataSetReaderDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataSetReaderDataTypeCollection dataTypeCollection = new DataSetReaderDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((DataSetReaderDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
