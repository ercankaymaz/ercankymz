// Decompiled with JetBrains decompiler
// Type: Opc.Ua.HistoryEventFieldListCollection
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
[CollectionDataContract(Name = "ListOfHistoryEventFieldList", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "HistoryEventFieldList")]
[ComVisible(true)]
public class HistoryEventFieldListCollection : List<HistoryEventFieldList>, ICloneable
{
  public HistoryEventFieldListCollection()
  {
  }

  public HistoryEventFieldListCollection(int capacity)
    : base(capacity)
  {
  }

  public HistoryEventFieldListCollection(IEnumerable<HistoryEventFieldList> collection)
    : base(collection)
  {
  }

  public static implicit operator HistoryEventFieldListCollection(HistoryEventFieldList[] values)
  {
    return values != null ? new HistoryEventFieldListCollection((IEnumerable<HistoryEventFieldList>) values) : new HistoryEventFieldListCollection();
  }

  public static explicit operator HistoryEventFieldList[](HistoryEventFieldListCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (HistoryEventFieldListCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    HistoryEventFieldListCollection fieldListCollection = new HistoryEventFieldListCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      fieldListCollection.Add((HistoryEventFieldList) Utils.Clone((object) this[index]));
    return (object) fieldListCollection;
  }
}
