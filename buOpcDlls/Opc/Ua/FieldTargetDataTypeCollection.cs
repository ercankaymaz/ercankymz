// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FieldTargetDataTypeCollection
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
[CollectionDataContract(Name = "ListOfFieldTargetDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "FieldTargetDataType")]
[ComVisible(true)]
public class FieldTargetDataTypeCollection : List<FieldTargetDataType>, ICloneable
{
  public FieldTargetDataTypeCollection()
  {
  }

  public FieldTargetDataTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public FieldTargetDataTypeCollection(IEnumerable<FieldTargetDataType> collection)
    : base(collection)
  {
  }

  public static implicit operator FieldTargetDataTypeCollection(FieldTargetDataType[] values)
  {
    return values != null ? new FieldTargetDataTypeCollection((IEnumerable<FieldTargetDataType>) values) : new FieldTargetDataTypeCollection();
  }

  public static explicit operator FieldTargetDataType[](FieldTargetDataTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (FieldTargetDataTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    FieldTargetDataTypeCollection dataTypeCollection = new FieldTargetDataTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      dataTypeCollection.Add((FieldTargetDataType) Utils.Clone((object) this[index]));
    return (object) dataTypeCollection;
  }
}
