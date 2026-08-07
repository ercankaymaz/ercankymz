// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkcs.Pkcs12Entry
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Utilities.Collections;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pkcs;

public abstract class Pkcs12Entry
{
  private readonly IDictionary<DerObjectIdentifier, Asn1Encodable> m_attributes;

  protected internal Pkcs12Entry(
    IDictionary<DerObjectIdentifier, Asn1Encodable> attributes)
  {
    this.m_attributes = attributes;
  }

  public Asn1Encodable this[DerObjectIdentifier oid]
  {
    get
    {
      return CollectionUtilities.GetValueOrNull<DerObjectIdentifier, Asn1Encodable>(this.m_attributes, oid);
    }
  }

  public IEnumerable<DerObjectIdentifier> BagAttributeKeys
  {
    get
    {
      return CollectionUtilities.Proxy<DerObjectIdentifier>((IEnumerable<DerObjectIdentifier>) this.m_attributes.Keys);
    }
  }
}
