// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NegotiationStatusCollection
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
[CollectionDataContract(Name = "ListOfNegotiationStatus", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "NegotiationStatus")]
[ComVisible(true)]
public class NegotiationStatusCollection : List<NegotiationStatus>, ICloneable
{
  public NegotiationStatusCollection()
  {
  }

  public NegotiationStatusCollection(int capacity)
    : base(capacity)
  {
  }

  public NegotiationStatusCollection(IEnumerable<NegotiationStatus> collection)
    : base(collection)
  {
  }

  public static implicit operator NegotiationStatusCollection(NegotiationStatus[] values)
  {
    return values != null ? new NegotiationStatusCollection((IEnumerable<NegotiationStatus>) values) : new NegotiationStatusCollection();
  }

  public static explicit operator NegotiationStatus[](NegotiationStatusCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (NegotiationStatusCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    NegotiationStatusCollection statusCollection = new NegotiationStatusCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      statusCollection.Add((NegotiationStatus) Utils.Clone((object) this[index]));
    return (object) statusCollection;
  }
}
