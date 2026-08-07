// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UnionCollection
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
[CollectionDataContract(Name = "ListOfUnion", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Union")]
[ComVisible(true)]
public class UnionCollection : List<Union>, ICloneable
{
  public UnionCollection()
  {
  }

  public UnionCollection(int capacity)
    : base(capacity)
  {
  }

  public UnionCollection(IEnumerable<Union> collection)
    : base(collection)
  {
  }

  public static implicit operator UnionCollection(Union[] values)
  {
    return values != null ? new UnionCollection((IEnumerable<Union>) values) : new UnionCollection();
  }

  public static explicit operator Union[](UnionCollection values) => values?.ToArray();

  public object Clone() => (object) (UnionCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    UnionCollection unionCollection = new UnionCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      unionCollection.Add((Union) Utils.Clone((object) this[index]));
    return (object) unionCollection;
  }
}
