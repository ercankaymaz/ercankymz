// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TsnTalkerStatusCollection
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
[CollectionDataContract(Name = "ListOfTsnTalkerStatus", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "TsnTalkerStatus")]
[ComVisible(true)]
public class TsnTalkerStatusCollection : List<TsnTalkerStatus>, ICloneable
{
  public TsnTalkerStatusCollection()
  {
  }

  public TsnTalkerStatusCollection(int capacity)
    : base(capacity)
  {
  }

  public TsnTalkerStatusCollection(IEnumerable<TsnTalkerStatus> collection)
    : base(collection)
  {
  }

  public static implicit operator TsnTalkerStatusCollection(TsnTalkerStatus[] values)
  {
    return values != null ? new TsnTalkerStatusCollection((IEnumerable<TsnTalkerStatus>) values) : new TsnTalkerStatusCollection();
  }

  public static explicit operator TsnTalkerStatus[](TsnTalkerStatusCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (TsnTalkerStatusCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    TsnTalkerStatusCollection statusCollection = new TsnTalkerStatusCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      statusCollection.Add((TsnTalkerStatus) Utils.Clone((object) this[index]));
    return (object) statusCollection;
  }
}
