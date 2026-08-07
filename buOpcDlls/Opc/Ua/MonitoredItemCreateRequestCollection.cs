// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MonitoredItemCreateRequestCollection
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
[CollectionDataContract(Name = "ListOfMonitoredItemCreateRequest", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "MonitoredItemCreateRequest")]
[ComVisible(true)]
public class MonitoredItemCreateRequestCollection : List<MonitoredItemCreateRequest>, ICloneable
{
  public MonitoredItemCreateRequestCollection()
  {
  }

  public MonitoredItemCreateRequestCollection(int capacity)
    : base(capacity)
  {
  }

  public MonitoredItemCreateRequestCollection(IEnumerable<MonitoredItemCreateRequest> collection)
    : base(collection)
  {
  }

  public static implicit operator MonitoredItemCreateRequestCollection(
    MonitoredItemCreateRequest[] values)
  {
    return values != null ? new MonitoredItemCreateRequestCollection((IEnumerable<MonitoredItemCreateRequest>) values) : new MonitoredItemCreateRequestCollection();
  }

  public static explicit operator MonitoredItemCreateRequest[](
    MonitoredItemCreateRequestCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (MonitoredItemCreateRequestCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    MonitoredItemCreateRequestCollection requestCollection = new MonitoredItemCreateRequestCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      requestCollection.Add((MonitoredItemCreateRequest) Utils.Clone((object) this[index]));
    return (object) requestCollection;
  }
}
