// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EventFieldListCollection
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
[CollectionDataContract(Name = "ListOfEventFieldList", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "EventFieldList")]
[ComVisible(true)]
public class EventFieldListCollection : List<EventFieldList>, ICloneable
{
  public EventFieldListCollection()
  {
  }

  public EventFieldListCollection(int capacity)
    : base(capacity)
  {
  }

  public EventFieldListCollection(IEnumerable<EventFieldList> collection)
    : base(collection)
  {
  }

  public static implicit operator EventFieldListCollection(EventFieldList[] values)
  {
    return values != null ? new EventFieldListCollection((IEnumerable<EventFieldList>) values) : new EventFieldListCollection();
  }

  public static explicit operator EventFieldList[](EventFieldListCollection values)
  {
    return values?.ToArray();
  }

  public object Clone() => (object) (EventFieldListCollection) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EventFieldListCollection fieldListCollection = new EventFieldListCollection(this.Count);
    for (int index = 0; index < this.Count; ++index)
      fieldListCollection.Add((EventFieldList) Utils.Clone((object) this[index]));
    return (object) fieldListCollection;
  }
}
