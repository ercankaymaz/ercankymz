// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StructureDefinitionCollection
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
[CollectionDataContract(Name = "ListOfStructureDefinition", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "StructureDefinition")]
[ComVisible(true)]
public class StructureDefinitionCollection : List<StructureDefinition>, ICloneable
{
  public StructureDefinitionCollection()
  {
  }

  public StructureDefinitionCollection(int capacity)
    : base(capacity)
  {
  }

  public StructureDefinitionCollection(IEnumerable<StructureDefinition> collection)
    : base(collection)
  {
  }

  public static implicit operator StructureDefinitionCollection(StructureDefinition[] values)
  {
    return values != null ? new StructureDefinitionCollection((IEnumerable<StructureDefinition>) values) : new StructureDefinitionCollection();
  }

  public static explicit operator StructureDefinition[](StructureDefinitionCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (StructureDefinitionCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    StructureDefinitionCollection definitionCollection = new StructureDefinitionCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      definitionCollection.Add((StructureDefinition) Utils.Clone((object) this[index]));
    return (object) definitionCollection;
  }
}
