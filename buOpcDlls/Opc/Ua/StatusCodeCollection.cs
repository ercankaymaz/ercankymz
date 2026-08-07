// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StatusCodeCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfStatusCode", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "StatusCode")]
[ComVisible(true)]
public class StatusCodeCollection : List<StatusCode>, ICloneable
{
  public StatusCodeCollection()
  {
  }

  public StatusCodeCollection(IEnumerable<StatusCode> collection)
    : base(collection)
  {
  }

  public StatusCodeCollection(int capacity)
    : base(capacity)
  {
  }

  public static StatusCodeCollection ToStatusCodeCollection(StatusCode[] values)
  {
    return values != null ? new StatusCodeCollection((IEnumerable<StatusCode>) values) : new StatusCodeCollection();
  }

  public static implicit operator StatusCodeCollection(StatusCode[] values)
  {
    return StatusCodeCollection.ToStatusCodeCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    return (object) new StatusCodeCollection((IEnumerable<StatusCode>) this);
  }
}
