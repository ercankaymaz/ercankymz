// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Int16Collection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfInt16", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Int16")]
[ComVisible(true)]
public class Int16Collection : List<short>, ICloneable
{
  public Int16Collection()
  {
  }

  public Int16Collection(int capacity)
    : base(capacity)
  {
  }

  public Int16Collection(IEnumerable<short> collection)
    : base(collection)
  {
  }

  public static Int16Collection ToInt16Collection(short[] values)
  {
    return values != null ? new Int16Collection((IEnumerable<short>) values) : new Int16Collection();
  }

  public static implicit operator Int16Collection(short[] values)
  {
    return Int16Collection.ToInt16Collection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new Int16Collection((IEnumerable<short>) this);
}
