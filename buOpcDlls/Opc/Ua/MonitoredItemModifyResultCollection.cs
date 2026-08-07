// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MonitoredItemModifyResultCollection
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
[CollectionDataContract(Name = "ListOfMonitoredItemModifyResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "MonitoredItemModifyResult")]
[ComVisible(true)]
public class MonitoredItemModifyResultCollection : List<MonitoredItemModifyResult>, ICloneable
{
  public MonitoredItemModifyResultCollection()
  {
  }

  public MonitoredItemModifyResultCollection(int capacity)
    : base(capacity)
  {
  }

  public MonitoredItemModifyResultCollection(IEnumerable<MonitoredItemModifyResult> collection)
    : base(collection)
  {
  }

  public static implicit operator MonitoredItemModifyResultCollection(
    MonitoredItemModifyResult[] values)
  {
    return values != null ? new MonitoredItemModifyResultCollection((IEnumerable<MonitoredItemModifyResult>) values) : new MonitoredItemModifyResultCollection();
  }

  public static explicit operator MonitoredItemModifyResult[](
    MonitoredItemModifyResultCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (MonitoredItemModifyResultCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    MonitoredItemModifyResultCollection resultCollection = new MonitoredItemModifyResultCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      resultCollection.Add((MonitoredItemModifyResult) Utils.Clone((object) this[index]));
    return (object) resultCollection;
  }
}
