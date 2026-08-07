// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IdTypeCollection
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
[CollectionDataContract(Name = "ListOfIdType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "IdType")]
[ComVisible(true)]
public class IdTypeCollection : List<IdType>, ICloneable
{
  public IdTypeCollection()
  {
  }

  public IdTypeCollection(int capacity)
    : base(capacity)
  {
  }

  public IdTypeCollection(IEnumerable<IdType> collection)
    : base(collection)
  {
  }

  public static implicit operator IdTypeCollection(IdType[] values)
  {
    return values != null ? new IdTypeCollection((IEnumerable<IdType>) values) : new IdTypeCollection();
  }

  public static explicit operator IdType[](IdTypeCollection values) => values?.ToArray();

  public object Clone() => (object) (IdTypeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    IdTypeCollection idTypeCollection = new IdTypeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      idTypeCollection.Add((IdType) Utils.Clone((object) this[index]));
    return (object) idTypeCollection;
  }
}
