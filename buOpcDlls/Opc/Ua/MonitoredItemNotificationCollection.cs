// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MonitoredItemNotificationCollection
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
[CollectionDataContract(Name = "ListOfMonitoredItemNotification", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "MonitoredItemNotification")]
[ComVisible(true)]
public class MonitoredItemNotificationCollection : List<MonitoredItemNotification>, ICloneable
{
  public MonitoredItemNotificationCollection()
  {
  }

  public MonitoredItemNotificationCollection(int capacity)
    : base(capacity)
  {
  }

  public MonitoredItemNotificationCollection(IEnumerable<MonitoredItemNotification> collection)
    : base(collection)
  {
  }

  public static implicit operator MonitoredItemNotificationCollection(
    MonitoredItemNotification[] values)
  {
    return values != null ? new MonitoredItemNotificationCollection((IEnumerable<MonitoredItemNotification>) values) : new MonitoredItemNotificationCollection();
  }

  public static explicit operator MonitoredItemNotification[](
    MonitoredItemNotificationCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (MonitoredItemNotificationCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    MonitoredItemNotificationCollection notificationCollection = new MonitoredItemNotificationCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      notificationCollection.Add((MonitoredItemNotification) Utils.Clone((object) this[index]));
    return (object) notificationCollection;
  }
}
