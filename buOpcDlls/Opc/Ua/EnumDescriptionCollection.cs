// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EnumDescriptionCollection
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
[CollectionDataContract(Name = "ListOfEnumDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "EnumDescription")]
[ComVisible(true)]
public class EnumDescriptionCollection : List<EnumDescription>, ICloneable
{
  public EnumDescriptionCollection()
  {
  }

  public EnumDescriptionCollection(int capacity)
    : base(capacity)
  {
  }

  public EnumDescriptionCollection(IEnumerable<EnumDescription> collection)
    : base(collection)
  {
  }

  public static implicit operator EnumDescriptionCollection(EnumDescription[] values)
  {
    return values != null ? new EnumDescriptionCollection((IEnumerable<EnumDescription>) values) : new EnumDescriptionCollection();
  }

  public static explicit operator EnumDescription[](EnumDescriptionCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (EnumDescriptionCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EnumDescriptionCollection descriptionCollection = new EnumDescriptionCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      descriptionCollection.Add((EnumDescription) Utils.Clone((object) this[index]));
    return (object) descriptionCollection;
  }
}
