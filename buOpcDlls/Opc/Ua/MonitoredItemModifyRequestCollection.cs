// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MonitoredItemModifyRequestCollection
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
[CollectionDataContract(Name = "ListOfMonitoredItemModifyRequest", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "MonitoredItemModifyRequest")]
[ComVisible(true)]
public class MonitoredItemModifyRequestCollection : List<MonitoredItemModifyRequest>, ICloneable
{
  public MonitoredItemModifyRequestCollection()
  {
  }

  public MonitoredItemModifyRequestCollection(int capacity)
    : base(capacity)
  {
  }

  public MonitoredItemModifyRequestCollection(IEnumerable<MonitoredItemModifyRequest> collection)
    : base(collection)
  {
  }

  public static implicit operator MonitoredItemModifyRequestCollection(
    MonitoredItemModifyRequest[] values)
  {
    return values != null ? new MonitoredItemModifyRequestCollection((IEnumerable<MonitoredItemModifyRequest>) values) : new MonitoredItemModifyRequestCollection();
  }

  public static explicit operator MonitoredItemModifyRequest[](
    MonitoredItemModifyRequestCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (MonitoredItemModifyRequestCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    MonitoredItemModifyRequestCollection requestCollection = new MonitoredItemModifyRequestCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      requestCollection.Add((MonitoredItemModifyRequest) Utils.Clone((object) this[index]));
    return (object) requestCollection;
  }
}
