// Decompiled with JetBrains decompiler
// Type: Opc.Ua.GenericAttributeValueCollection
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
[CollectionDataContract(Name = "ListOfGenericAttributeValue", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "GenericAttributeValue")]
[ComVisible(true)]
public class GenericAttributeValueCollection : List<GenericAttributeValue>, ICloneable
{
  public GenericAttributeValueCollection()
  {
  }

  public GenericAttributeValueCollection(int capacity)
    : base(capacity)
  {
  }

  public GenericAttributeValueCollection(IEnumerable<GenericAttributeValue> collection)
    : base(collection)
  {
  }

  public static implicit operator GenericAttributeValueCollection(GenericAttributeValue[] values)
  {
    return values != null ? new GenericAttributeValueCollection((IEnumerable<GenericAttributeValue>) values) : new GenericAttributeValueCollection();
  }

  public static explicit operator GenericAttributeValue[](GenericAttributeValueCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (GenericAttributeValueCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    GenericAttributeValueCollection attributeValueCollection = new GenericAttributeValueCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      attributeValueCollection.Add((GenericAttributeValue) Utils.Clone((object) this[index]));
    return (object) attributeValueCollection;
  }
}
