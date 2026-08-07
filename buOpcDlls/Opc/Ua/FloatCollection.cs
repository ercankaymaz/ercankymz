// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FloatCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfFloat", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Float")]
[ComVisible(true)]
public class FloatCollection : List<float>, ICloneable
{
  public FloatCollection()
  {
  }

  public FloatCollection(int capacity)
    : base(capacity)
  {
  }

  public FloatCollection(IEnumerable<float> collection)
    : base(collection)
  {
  }

  public static FloatCollection ToFloatCollection(float[] values)
  {
    return values != null ? new FloatCollection((IEnumerable<float>) values) : new FloatCollection();
  }

  public static implicit operator FloatCollection(float[] values)
  {
    return FloatCollection.ToFloatCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new FloatCollection((IEnumerable<float>) this);
}
