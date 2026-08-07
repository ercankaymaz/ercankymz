// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TsnStreamStateCollection
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
[CollectionDataContract(Name = "ListOfTsnStreamState", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "TsnStreamState")]
[ComVisible(true)]
public class TsnStreamStateCollection : List<TsnStreamState>, ICloneable
{
  public TsnStreamStateCollection()
  {
  }

  public TsnStreamStateCollection(int capacity)
    : base(capacity)
  {
  }

  public TsnStreamStateCollection(IEnumerable<TsnStreamState> collection)
    : base(collection)
  {
  }

  public static implicit operator TsnStreamStateCollection(TsnStreamState[] values)
  {
    return values != null ? new TsnStreamStateCollection((IEnumerable<TsnStreamState>) values) : new TsnStreamStateCollection();
  }

  public static explicit operator TsnStreamState[](TsnStreamStateCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (TsnStreamStateCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    TsnStreamStateCollection streamStateCollection = new TsnStreamStateCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      streamStateCollection.Add((TsnStreamState) Utils.Clone((object) this[index]));
    return (object) streamStateCollection;
  }
}
