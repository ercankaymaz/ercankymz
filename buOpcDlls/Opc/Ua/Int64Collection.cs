// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Int64Collection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfInt64", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Int64")]
[ComVisible(true)]
public class Int64Collection : List<long>, ICloneable
{
  public Int64Collection()
  {
  }

  public Int64Collection(int capacity)
    : base(capacity)
  {
  }

  public Int64Collection(IEnumerable<long> collection)
    : base(collection)
  {
  }

  public static Int64Collection ToInt64Collection(long[] values)
  {
    return values != null ? new Int64Collection((IEnumerable<long>) values) : new Int64Collection();
  }

  public static implicit operator Int64Collection(long[] values)
  {
    return Int64Collection.ToInt64Collection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new Int64Collection((IEnumerable<long>) this);
}
