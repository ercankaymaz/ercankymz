// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Int32Collection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfInt32", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Int32")]
[ComVisible(true)]
public class Int32Collection : List<int>, ICloneable
{
  public Int32Collection()
  {
  }

  public Int32Collection(int capacity)
    : base(capacity)
  {
  }

  public Int32Collection(IEnumerable<int> collection)
    : base(collection)
  {
  }

  public static Int32Collection ToInt32Collection(int[] values)
  {
    return values != null ? new Int32Collection((IEnumerable<int>) values) : new Int32Collection();
  }

  public static implicit operator Int32Collection(int[] values)
  {
    return Int32Collection.ToInt32Collection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new Int32Collection((IEnumerable<int>) this);
}
