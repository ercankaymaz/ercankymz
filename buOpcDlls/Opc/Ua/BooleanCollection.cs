// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BooleanCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfBoolean", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Boolean")]
[ComVisible(true)]
public class BooleanCollection : List<bool>, ICloneable
{
  public BooleanCollection()
  {
  }

  public BooleanCollection(IEnumerable<bool> collection)
    : base(collection)
  {
  }

  public BooleanCollection(int capacity)
    : base(capacity)
  {
  }

  public static BooleanCollection ToBooleanCollection(bool[] values)
  {
    return values != null ? new BooleanCollection((IEnumerable<bool>) values) : new BooleanCollection();
  }

  public static implicit operator BooleanCollection(bool[] values)
  {
    return BooleanCollection.ToBooleanCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new BooleanCollection((IEnumerable<bool>) this);
}
