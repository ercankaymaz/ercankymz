// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TsnFailureCodeCollection
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
[CollectionDataContract(Name = "ListOfTsnFailureCode", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "TsnFailureCode")]
[ComVisible(true)]
public class TsnFailureCodeCollection : List<TsnFailureCode>, ICloneable
{
  public TsnFailureCodeCollection()
  {
  }

  public TsnFailureCodeCollection(int capacity)
    : base(capacity)
  {
  }

  public TsnFailureCodeCollection(IEnumerable<TsnFailureCode> collection)
    : base(collection)
  {
  }

  public static implicit operator TsnFailureCodeCollection(TsnFailureCode[] values)
  {
    return values != null ? new TsnFailureCodeCollection((IEnumerable<TsnFailureCode>) values) : new TsnFailureCodeCollection();
  }

  public static explicit operator TsnFailureCode[](TsnFailureCodeCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (TsnFailureCodeCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    TsnFailureCodeCollection failureCodeCollection = new TsnFailureCodeCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      failureCodeCollection.Add((TsnFailureCode) Utils.Clone((object) this[index]));
    return (object) failureCodeCollection;
  }
}
