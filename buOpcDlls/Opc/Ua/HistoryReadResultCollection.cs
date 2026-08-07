// Decompiled with JetBrains decompiler
// Type: Opc.Ua.HistoryReadResultCollection
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
[CollectionDataContract(Name = "ListOfHistoryReadResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "HistoryReadResult")]
[ComVisible(true)]
public class HistoryReadResultCollection : List<HistoryReadResult>, ICloneable
{
  public HistoryReadResultCollection()
  {
  }

  public HistoryReadResultCollection(int capacity)
    : base(capacity)
  {
  }

  public HistoryReadResultCollection(IEnumerable<HistoryReadResult> collection)
    : base(collection)
  {
  }

  public static implicit operator HistoryReadResultCollection(HistoryReadResult[] values)
  {
    return values != null ? new HistoryReadResultCollection((IEnumerable<HistoryReadResult>) values) : new HistoryReadResultCollection();
  }

  public static explicit operator HistoryReadResult[](HistoryReadResultCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (HistoryReadResultCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    HistoryReadResultCollection resultCollection = new HistoryReadResultCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      resultCollection.Add((HistoryReadResult) Utils.Clone((object) this[index]));
    return (object) resultCollection;
  }
}
