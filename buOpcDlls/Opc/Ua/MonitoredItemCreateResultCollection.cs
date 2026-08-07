// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MonitoredItemCreateResultCollection
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
[CollectionDataContract(Name = "ListOfMonitoredItemCreateResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "MonitoredItemCreateResult")]
[ComVisible(true)]
public class MonitoredItemCreateResultCollection : List<MonitoredItemCreateResult>, ICloneable
{
  public MonitoredItemCreateResultCollection()
  {
  }

  public MonitoredItemCreateResultCollection(int capacity)
    : base(capacity)
  {
  }

  public MonitoredItemCreateResultCollection(IEnumerable<MonitoredItemCreateResult> collection)
    : base(collection)
  {
  }

  public static implicit operator MonitoredItemCreateResultCollection(
    MonitoredItemCreateResult[] values)
  {
    return values != null ? new MonitoredItemCreateResultCollection((IEnumerable<MonitoredItemCreateResult>) values) : new MonitoredItemCreateResultCollection();
  }

  public static explicit operator MonitoredItemCreateResult[](
    MonitoredItemCreateResultCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (MonitoredItemCreateResultCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    MonitoredItemCreateResultCollection resultCollection = new MonitoredItemCreateResultCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      resultCollection.Add((MonitoredItemCreateResult) Utils.Clone((object) this[index]));
    return (object) resultCollection;
  }
}
