// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UInt16Collection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfUInt16", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UInt16")]
[ComVisible(true)]
public class UInt16Collection : List<ushort>, ICloneable
{
  public UInt16Collection()
  {
  }

  public UInt16Collection(int capacity)
    : base(capacity)
  {
  }

  public UInt16Collection(IEnumerable<ushort> collection)
    : base(collection)
  {
  }

  public static UInt16Collection ToUInt16Collection(ushort[] values)
  {
    return values != null ? new UInt16Collection((IEnumerable<ushort>) values) : new UInt16Collection();
  }

  public static implicit operator UInt16Collection(ushort[] values)
  {
    return UInt16Collection.ToUInt16Collection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new UInt16Collection((IEnumerable<ushort>) this);
}
