// Decompiled with JetBrains decompiler
// Type: Opc.Ua.VariantCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfVariant", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Variant")]
[ComVisible(true)]
public class VariantCollection : List<Variant>, ICloneable
{
  public VariantCollection()
  {
  }

  public VariantCollection(IEnumerable<Variant> collection)
    : base(collection)
  {
  }

  public VariantCollection(int capacity)
    : base(capacity)
  {
  }

  public static VariantCollection ToVariantCollection(Variant[] values)
  {
    return values != null ? new VariantCollection((IEnumerable<Variant>) values) : new VariantCollection();
  }

  public static implicit operator VariantCollection(Variant[] values)
  {
    return VariantCollection.ToVariantCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    VariantCollection variantCollection = new VariantCollection(this.Count);
    foreach (Variant variant in (List<Variant>) this)
      variantCollection.Add((Variant) Utils.Clone((object) variant));
    return (object) variantCollection;
  }
}
