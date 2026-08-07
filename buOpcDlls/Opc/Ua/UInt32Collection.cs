// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UInt32Collection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfUInt32", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UInt32")]
[ComVisible(true)]
public class UInt32Collection : List<uint>, ICloneable
{
  public UInt32Collection()
  {
  }

  public UInt32Collection(int capacity)
    : base(capacity)
  {
  }

  public UInt32Collection(IEnumerable<uint> collection)
    : base(collection)
  {
  }

  public static UInt32Collection ToUInt32Collection(uint[] values)
  {
    return values != null ? new UInt32Collection((IEnumerable<uint>) values) : new UInt32Collection();
  }

  public static implicit operator UInt32Collection(uint[] values)
  {
    return UInt32Collection.ToUInt32Collection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new UInt32Collection((IEnumerable<uint>) this);
}
