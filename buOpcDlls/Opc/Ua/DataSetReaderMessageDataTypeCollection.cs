// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataSetReaderMessageDataTypeCollection
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
[CollectionDataContract(Name = "ListOfDataSetReaderMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetReaderMessageDataType")]
[ComVisible(true)]
public class DataSetReaderMessageDataTypeCollection : List<DataSetReaderMessageDataType>, ICloneable
{
  public DataSetReaderMessageDataTypeCollection()
  {
  }

  public DataSetReaderMessageDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public DataSetReaderMessageDataTypeCollection(
    IEnumerable<DataSetReaderMessageDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator DataSetReaderMessageDataTypeCollection(
    DataSetReaderMessageDataType[] values)
  {
    return values != null ? new DataSetReaderMessageDataTypeCollection((IEnumerable<DataSetReaderMessageDataType>) values) : new DataSetReaderMessageDataTypeCollection();
  }

  public static explicit operator DataSetReaderMessageDataType[](
    DataSetReaderMessageDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (DataSetReaderMessageDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataSetReaderMessageDataTypeCollection dataTypeCollection = new DataSetReaderMessageDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((DataSetReaderMessageDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
