// Decompiled with JetBrains decompiler
// Type: Opc.Ua.HistoryUpdateResultCollection
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
[CollectionDataContract(Name = "ListOfHistoryUpdateResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "HistoryUpdateResult")]
[ComVisible(true)]
public class HistoryUpdateResultCollection : List<HistoryUpdateResult>, ICloneable
{
  public HistoryUpdateResultCollection()
  {
  }

  public HistoryUpdateResultCollection(int capacity)
    : base(capacity)
  {
  }

  public HistoryUpdateResultCollection(IEnumerable<HistoryUpdateResult> collection)
    : base(collection)
  {
  }

  public static implicit operator HistoryUpdateResultCollection(HistoryUpdateResult[] values)
  {
    return values != null ? new HistoryUpdateResultCollection((IEnumerable<HistoryUpdateResult>) values) : new HistoryUpdateResultCollection();
  }

  public static explicit operator HistoryUpdateResult[](HistoryUpdateResultCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (HistoryUpdateResultCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    HistoryUpdateResultCollection resultCollection = new HistoryUpdateResultCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      resultCollection.Add((HistoryUpdateResult) Utils.Clone((object) this[index]));
    return (object) resultCollection;
  }
}
