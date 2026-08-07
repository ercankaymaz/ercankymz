// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataTypeDescriptionCollection
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
[CollectionDataContract(Name = "ListOfDataTypeDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataTypeDescription")]
[ComVisible(true)]
public class DataTypeDescriptionCollection : List<DataTypeDescription>, ICloneable
{
  public DataTypeDescriptionCollection()
  {
  }

  public DataTypeDescriptionCollection(int capacity)
    : base(capacity)
  {
  }

  public DataTypeDescriptionCollection(IEnumerable<DataTypeDescription> collection)
    : base(collection)
  {
  }

  public static implicit operator DataTypeDescriptionCollection(DataTypeDescription[] values)
  {
    return values != null ? new DataTypeDescriptionCollection((IEnumerable<DataTypeDescription>) values) : new DataTypeDescriptionCollection();
  }

  public static explicit operator DataTypeDescription[](DataTypeDescriptionCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (DataTypeDescriptionCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataTypeDescriptionCollection descriptionCollection = new DataTypeDescriptionCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      descriptionCollection.Add((DataTypeDescription) Utils.Clone((object) this[index]));
    return (object) descriptionCollection;
  }
}
