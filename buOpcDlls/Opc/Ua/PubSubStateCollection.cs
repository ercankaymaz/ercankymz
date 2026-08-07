// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubStateCollection
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
[CollectionDataContract(Name = "ListOfPubSubState", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PubSubState")]
[ComVisible(true)]
public class PubSubStateCollection : List<PubSubState>, ICloneable
{
  public PubSubStateCollection()
  {
  }

  public PubSubStateCollection(int capacity)
    : base(capacity)
  {
  }

  public PubSubStateCollection(IEnumerable<PubSubState> collection)
    : base(collection)
  {
  }

  public static implicit operator PubSubStateCollection(PubSubState[] values)
  {
    return values != null ? new PubSubStateCollection((IEnumerable<PubSubState>) values) : new PubSubStateCollection();
  }

  public static explicit operator PubSubState[](PubSubStateCollection values) => values?.ToArray();

  public object Clone() => (object) (PubSubStateCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    PubSubStateCollection subStateCollection = new PubSubStateCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      subStateCollection.Add((PubSubState) Utils.Clone((object) this[index]));
    return (object) subStateCollection;
  }
}
