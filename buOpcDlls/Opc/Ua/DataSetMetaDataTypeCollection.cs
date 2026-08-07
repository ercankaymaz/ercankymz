// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataSetMetaDataTypeCollection
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
[CollectionDataContract(Name = "ListOfDataSetMetaDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetMetaDataType")]
[ComVisible(true)]
public class DataSetMetaDataTypeCollection : List<DataSetMetaDataType>, ICloneable
{
  public DataSetMetaDataTypeCollection()
  {
  }

  public DataSetMetaDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public DataSetMetaDataTypeCollection(IEnumerable<DataSetMetaDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator DataSetMetaDataTypeCollection(DataSetMetaDataType[] values)
  {
    return values != null ? new DataSetMetaDataTypeCollection((IEnumerable<DataSetMetaDataType>) values) : new DataSetMetaDataTypeCollection();
  }

  public static explicit operator DataSetMetaDataType[](DataSetMetaDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (DataSetMetaDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataSetMetaDataTypeCollection dataTypeCollection = new DataSetMetaDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((DataSetMetaDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
