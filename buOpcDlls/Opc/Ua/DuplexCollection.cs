// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DuplexCollection
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
[CollectionDataContract(Name = "ListOfDuplex", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Duplex")]
[ComVisible(true)]
public class DuplexCollection : List<Duplex>, ICloneable
{
  public DuplexCollection()
  {
  }

  public DuplexCollection(int capacity)
    : base(capacity)
  {
  }

  public DuplexCollection(IEnumerable<Duplex> collection)
    : base(collection)
  {
  }

  public static implicit operator DuplexCollection(Duplex[] values)
  {
    return values != null ? new DuplexCollection((IEnumerable<Duplex>) values) : new DuplexCollection();
  }

  public static explicit operator Duplex[](DuplexCollection values) => values?.ToArray();

  public object Clone() => (object) (DuplexCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DuplexCollection duplexCollection = new DuplexCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      duplexCollection.Add((Duplex) Utils.Clone((object) this[index]));
    return (object) duplexCollection;
  }
}
