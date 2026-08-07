// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.AttributeTable
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Collections;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class AttributeTable
{
  private readonly IDictionary<DerObjectIdentifier, AttributeX509> m_attributes;

  public AttributeTable(
    IDictionary<DerObjectIdentifier, AttributeX509> attrs)
  {
    this.m_attributes = (IDictionary<DerObjectIdentifier, AttributeX509>) new Dictionary<DerObjectIdentifier, AttributeX509>(attrs);
  }

  public AttributeTable(Asn1EncodableVector v)
  {
    this.m_attributes = (IDictionary<DerObjectIdentifier, AttributeX509>) new Dictionary<DerObjectIdentifier, AttributeX509>(v.Count);
    for (int index = 0; index != v.Count; ++index)
    {
      AttributeX509 instance = AttributeX509.GetInstance((object) v[index]);
      this.m_attributes.Add(instance.AttrType, instance);
    }
  }

  public AttributeTable(Asn1Set s)
  {
    this.m_attributes = (IDictionary<DerObjectIdentifier, AttributeX509>) new Dictionary<DerObjectIdentifier, AttributeX509>(s.Count);
    for (int index = 0; index != s.Count; ++index)
    {
      AttributeX509 instance = AttributeX509.GetInstance((object) s[index]);
      this.m_attributes.Add(instance.AttrType, instance);
    }
  }

  public AttributeX509 Get(DerObjectIdentifier oid)
  {
    return CollectionUtilities.GetValueOrNull<DerObjectIdentifier, AttributeX509>(this.m_attributes, oid);
  }

  public IDictionary<DerObjectIdentifier, AttributeX509> ToDictionary()
  {
    return (IDictionary<DerObjectIdentifier, AttributeX509>) new Dictionary<DerObjectIdentifier, AttributeX509>(this.m_attributes);
  }
}
