// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DoubleCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfDouble", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Double")]
[ComVisible(true)]
public class DoubleCollection : List<double>, ICloneable
{
  public DoubleCollection()
  {
  }

  public DoubleCollection(int capacity)
    : base(capacity)
  {
  }

  public DoubleCollection(IEnumerable<double> collection)
    : base(collection)
  {
  }

  public static DoubleCollection ToDoubleCollection(double[] values)
  {
    return values != null ? new DoubleCollection((IEnumerable<double>) values) : new DoubleCollection();
  }

  public static implicit operator DoubleCollection(double[] values)
  {
    return DoubleCollection.ToDoubleCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new DoubleCollection((IEnumerable<double>) this);
}
