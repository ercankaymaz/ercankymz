// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EnumValueTypeCollection
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
[CollectionDataContract(Name = "ListOfEnumValueType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "EnumValueType")]
[ComVisible(true)]
public class EnumValueTypeCollection : List<EnumValueType>, ICloneable
{
  public EnumValueTypeCollection()
  {
  }

  public EnumValueTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public EnumValueTypeCollection(IEnumerable<EnumValueType> collection)
    : base(collection)
  {
  }

  public static implicit operator EnumValueTypeCollection(EnumValueType[] values)
  {
    return values != null ? new EnumValueTypeCollection((IEnumerable<EnumValueType>) values) : new EnumValueTypeCollection();
  }

  public static explicit operator EnumValueType[](EnumValueTypeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (EnumValueTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EnumValueTypeCollection valueTypeCollection = new EnumValueTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      valueTypeCollection.Add((EnumValueType) Utils.Clone((object) this[index]));
    return (object) valueTypeCollection;
  }
}
