// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UuidCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfGuid", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Guid")]
[ComVisible(true)]
public class UuidCollection : List<Uuid>, ICloneable
{
  public UuidCollection()
  {
  }

  public UuidCollection(IEnumerable<Uuid> collection)
    : base(collection)
  {
  }

  public UuidCollection(int capacity)
    : base(capacity)
  {
  }

  public static UuidCollection ToUuidCollection(Uuid[] values)
  {
    return values != null ? new UuidCollection((IEnumerable<Uuid>) values) : new UuidCollection();
  }

  public static implicit operator UuidCollection(Uuid[] values)
  {
    return UuidCollection.ToUuidCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new UuidCollection((IEnumerable<Uuid>) this);
}
