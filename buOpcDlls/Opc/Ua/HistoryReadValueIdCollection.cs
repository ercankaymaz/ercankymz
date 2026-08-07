// Decompiled with JetBrains decompiler
// Type: Opc.Ua.HistoryReadValueIdCollection
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
[CollectionDataContract(Name = "ListOfHistoryReadValueId", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "HistoryReadValueId")]
[ComVisible(true)]
public class HistoryReadValueIdCollection : List<HistoryReadValueId>, ICloneable
{
  public HistoryReadValueIdCollection()
  {
  }

  public HistoryReadValueIdCollection(int capacity)
    : base(capacity)
  {
  }

  public HistoryReadValueIdCollection(IEnumerable<HistoryReadValueId> collection)
    : base(collection)
  {
  }

  public static implicit operator HistoryReadValueIdCollection(HistoryReadValueId[] values)
  {
    return values != null ? new HistoryReadValueIdCollection((IEnumerable<HistoryReadValueId>) values) : new HistoryReadValueIdCollection();
  }

  public static explicit operator HistoryReadValueId[](HistoryReadValueIdCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (HistoryReadValueIdCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    HistoryReadValueIdCollection valueIdCollection = new HistoryReadValueIdCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      valueIdCollection.Add((HistoryReadValueId) Utils.Clone((object) this[index]));
    return (object) valueIdCollection;
  }
}
