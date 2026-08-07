// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.DefaultSignedAttributeTableGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class DefaultSignedAttributeTableGenerator : CmsAttributeTableGenerator
{
  private readonly IDictionary<DerObjectIdentifier, object> m_table;

  public DefaultSignedAttributeTableGenerator()
  {
    this.m_table = (IDictionary<DerObjectIdentifier, object>) new Dictionary<DerObjectIdentifier, object>();
  }

  public DefaultSignedAttributeTableGenerator(AttributeTable attributeTable)
  {
    if (attributeTable != null)
      this.m_table = attributeTable.ToDictionary();
    else
      this.m_table = (IDictionary<DerObjectIdentifier, object>) new Dictionary<DerObjectIdentifier, object>();
  }

  protected virtual IDictionary<DerObjectIdentifier, object> CreateStandardAttributeTable(
    IDictionary<CmsAttributeTableParameter, object> parameters)
  {
    Dictionary<DerObjectIdentifier, object> std = new Dictionary<DerObjectIdentifier, object>(this.m_table);
    this.DoCreateStandardAttributeTable(parameters, (IDictionary<DerObjectIdentifier, object>) std);
    return (IDictionary<DerObjectIdentifier, object>) std;
  }

  private void DoCreateStandardAttributeTable(
    IDictionary<CmsAttributeTableParameter, object> parameters,
    IDictionary<DerObjectIdentifier, object> std)
  {
    object element;
    if (!std.ContainsKey(CmsAttributes.ContentType) && parameters.TryGetValue(CmsAttributeTableParameter.ContentType, out element))
    {
      Org.BouncyCastle.Asn1.Cms.Attribute attribute = new Org.BouncyCastle.Asn1.Cms.Attribute(CmsAttributes.ContentType, (Asn1Set) new DerSet((Asn1Encodable) element));
      std[attribute.AttrType] = (object) attribute;
    }
    if (!std.ContainsKey(CmsAttributes.SigningTime))
    {
      Org.BouncyCastle.Asn1.Cms.Attribute attribute = new Org.BouncyCastle.Asn1.Cms.Attribute(CmsAttributes.SigningTime, (Asn1Set) new DerSet((Asn1Encodable) new Time(DateTime.UtcNow)));
      std[attribute.AttrType] = (object) attribute;
    }
    if (std.ContainsKey(CmsAttributes.MessageDigest))
      return;
    byte[] parameter = (byte[]) parameters[CmsAttributeTableParameter.Digest];
    Org.BouncyCastle.Asn1.Cms.Attribute attribute1 = new Org.BouncyCastle.Asn1.Cms.Attribute(CmsAttributes.MessageDigest, (Asn1Set) new DerSet((Asn1Encodable) new DerOctetString(parameter)));
    std[attribute1.AttrType] = (object) attribute1;
  }

  public virtual AttributeTable GetAttributes(
    IDictionary<CmsAttributeTableParameter, object> parameters)
  {
    return new AttributeTable(this.CreateStandardAttributeTable(parameters));
  }
}
