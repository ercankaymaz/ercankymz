// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataTypeSchemaHeaderCollection
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
[CollectionDataContract(Name = "ListOfDataTypeSchemaHeader", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataTypeSchemaHeader")]
[ComVisible(true)]
public class DataTypeSchemaHeaderCollection : List<DataTypeSchemaHeader>, ICloneable
{
  public DataTypeSchemaHeaderCollection()
  {
  }

  public DataTypeSchemaHeaderCollection(int capacity)
    : base(capacity)
  {
  }

  public DataTypeSchemaHeaderCollection(IEnumerable<DataTypeSchemaHeader> collection)
    : base(collection)
  {
  }

  public static implicit operator DataTypeSchemaHeaderCollection(DataTypeSchemaHeader[] values)
  {
    return values != null ? new DataTypeSchemaHeaderCollection((IEnumerable<DataTypeSchemaHeader>) values) : new DataTypeSchemaHeaderCollection();
  }

  public static explicit operator DataTypeSchemaHeader[](DataTypeSchemaHeaderCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (DataTypeSchemaHeaderCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataTypeSchemaHeaderCollection headerCollection = new DataTypeSchemaHeaderCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      headerCollection.Add((DataTypeSchemaHeader) Utils.Clone((object) this[index]));
    return (object) headerCollection;
  }
}
