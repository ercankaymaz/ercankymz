// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TsnListenerStatusCollection
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
[CollectionDataContract(Name = "ListOfTsnListenerStatus", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "TsnListenerStatus")]
[ComVisible(true)]
public class TsnListenerStatusCollection : List<TsnListenerStatus>, ICloneable
{
  public TsnListenerStatusCollection()
  {
  }

  public TsnListenerStatusCollection(int capacity)
    : base(capacity)
  {
  }

  public TsnListenerStatusCollection(IEnumerable<TsnListenerStatus> collection)
    : base(collection)
  {
  }

  public static implicit operator TsnListenerStatusCollection(TsnListenerStatus[] values)
  {
    return values != null ? new TsnListenerStatusCollection((IEnumerable<TsnListenerStatus>) values) : new TsnListenerStatusCollection();
  }

  public static explicit operator TsnListenerStatus[](TsnListenerStatusCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (TsnListenerStatusCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    TsnListenerStatusCollection statusCollection = new TsnListenerStatusCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      statusCollection.Add((TsnListenerStatus) Utils.Clone((object) this[index]));
    return (object) statusCollection;
  }
}
