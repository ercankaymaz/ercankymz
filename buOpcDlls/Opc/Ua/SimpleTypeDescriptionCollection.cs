// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SimpleTypeDescriptionCollection
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
[CollectionDataContract(Name = "ListOfSimpleTypeDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SimpleTypeDescription")]
[ComVisible(true)]
public class SimpleTypeDescriptionCollection : List<SimpleTypeDescription>, ICloneable
{
  public SimpleTypeDescriptionCollection()
  {
  }

  public SimpleTypeDescriptionCollection(int capacity)
    : base(capacity)
  {
  }

  public SimpleTypeDescriptionCollection(IEnumerable<SimpleTypeDescription> collection)
    : base(collection)
  {
  }

  public static implicit operator SimpleTypeDescriptionCollection(SimpleTypeDescription[] values)
  {
    return values != null ? new SimpleTypeDescriptionCollection((IEnumerable<SimpleTypeDescription>) values) : new SimpleTypeDescriptionCollection();
  }

  public static explicit operator SimpleTypeDescription[](SimpleTypeDescriptionCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (SimpleTypeDescriptionCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SimpleTypeDescriptionCollection descriptionCollection = new SimpleTypeDescriptionCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      descriptionCollection.Add((SimpleTypeDescription) Utils.Clone((object) this[index]));
    return (object) descriptionCollection;
  }
}
