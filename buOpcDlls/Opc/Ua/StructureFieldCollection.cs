// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StructureFieldCollection
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
[CollectionDataContract(Name = "ListOfStructureField", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "StructureField")]
[ComVisible(true)]
public class StructureFieldCollection : List<StructureField>, ICloneable
{
  public StructureFieldCollection()
  {
  }

  public StructureFieldCollection(int capacity)
    : base(capacity)
  {
  }

  public StructureFieldCollection(IEnumerable<StructureField> collection)
    : base(collection)
  {
  }

  public static implicit operator StructureFieldCollection(StructureField[] values)
  {
    return values != null ? new StructureFieldCollection((IEnumerable<StructureField>) values) : new StructureFieldCollection();
  }

  public static explicit operator StructureField[](StructureFieldCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (StructureFieldCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    StructureFieldCollection structureFieldCollection = new StructureFieldCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      structureFieldCollection.Add((StructureField) Utils.Clone((object) this[index]));
    return (object) structureFieldCollection;
  }
}
