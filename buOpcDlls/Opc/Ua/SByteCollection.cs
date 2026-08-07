// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SByteCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfSByte", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SByte")]
[ComVisible(true)]
public class SByteCollection : List<sbyte>, ICloneable
{
  public SByteCollection()
  {
  }

  public SByteCollection(int capacity)
    : base(capacity)
  {
  }

  public SByteCollection(IEnumerable<sbyte> collection)
    : base(collection)
  {
  }

  public static SByteCollection ToSByteCollection(sbyte[] values)
  {
    return values != null ? new SByteCollection((IEnumerable<sbyte>) values) : new SByteCollection();
  }

  public static implicit operator SByteCollection(sbyte[] values)
  {
    return SByteCollection.ToSByteCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new SByteCollection((IEnumerable<sbyte>) this);
}
