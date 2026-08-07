// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FieldMetaDataCollection
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
[CollectionDataContract(Name = "ListOfFieldMetaData", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "FieldMetaData")]
[ComVisible(true)]
public class FieldMetaDataCollection : List<FieldMetaData>, ICloneable
{
  public FieldMetaDataCollection()
  {
  }

  public FieldMetaDataCollection(int capacity)
    : base(capacity)
  {
  }

  public FieldMetaDataCollection(IEnumerable<FieldMetaData> collection)
    : base(collection)
  {
  }

  public static implicit operator FieldMetaDataCollection(FieldMetaData[] values)
  {
    return values != null ? new FieldMetaDataCollection((IEnumerable<FieldMetaData>) values) : new FieldMetaDataCollection();
  }

  public static explicit operator FieldMetaData[](FieldMetaDataCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (FieldMetaDataCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    FieldMetaDataCollection metaDataCollection = new FieldMetaDataCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      metaDataCollection.Add((FieldMetaData) Utils.Clone((object) this[index]));
    return (object) metaDataCollection;
  }
}
