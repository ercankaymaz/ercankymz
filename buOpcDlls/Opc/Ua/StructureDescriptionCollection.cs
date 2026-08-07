// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StructureDescriptionCollection
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
[CollectionDataContract(Name = "ListOfStructureDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "StructureDescription")]
[ComVisible(true)]
public class StructureDescriptionCollection : List<StructureDescription>, ICloneable
{
  public StructureDescriptionCollection()
  {
  }

  public StructureDescriptionCollection(int capacity)
    : base(capacity)
  {
  }

  public StructureDescriptionCollection(IEnumerable<StructureDescription> collection)
    : base(collection)
  {
  }

  public static implicit operator StructureDescriptionCollection(StructureDescription[] values)
  {
    return values != null ? new StructureDescriptionCollection((IEnumerable<StructureDescription>) values) : new StructureDescriptionCollection();
  }

  public static explicit operator StructureDescription[](StructureDescriptionCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (StructureDescriptionCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    StructureDescriptionCollection descriptionCollection = new StructureDescriptionCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      descriptionCollection.Add((StructureDescription) Utils.Clone((object) this[index]));
    return (object) descriptionCollection;
  }
}
