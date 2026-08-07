// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EnumDefinitionCollection
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
[CollectionDataContract(Name = "ListOfEnumDefinition", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "EnumDefinition")]
[ComVisible(true)]
public class EnumDefinitionCollection : List<EnumDefinition>, ICloneable
{
  public EnumDefinitionCollection()
  {
  }

  public EnumDefinitionCollection(int capacity)
    : base(capacity)
  {
  }

  public EnumDefinitionCollection(IEnumerable<EnumDefinition> collection)
    : base(collection)
  {
  }

  public static implicit operator EnumDefinitionCollection(EnumDefinition[] values)
  {
    return values != null ? new EnumDefinitionCollection((IEnumerable<EnumDefinition>) values) : new EnumDefinitionCollection();
  }

  public static explicit operator EnumDefinition[](EnumDefinitionCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (EnumDefinitionCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EnumDefinitionCollection definitionCollection = new EnumDefinitionCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      definitionCollection.Add((EnumDefinition) Utils.Clone((object) this[index]));
    return (object) definitionCollection;
  }
}
