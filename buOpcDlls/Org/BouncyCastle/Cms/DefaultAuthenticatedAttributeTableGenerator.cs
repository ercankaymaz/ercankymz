// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.DefaultAuthenticatedAttributeTableGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class DefaultAuthenticatedAttributeTableGenerator : CmsAttributeTableGenerator
{
  private readonly IDictionary<DerObjectIdentifier, object> m_table;

  public DefaultAuthenticatedAttributeTableGenerator()
  {
    this.m_table = (IDictionary<DerObjectIdentifier, object>) new Dictionary<DerObjectIdentifier, object>();
  }

  public DefaultAuthenticatedAttributeTableGenerator(AttributeTable attributeTable)
  {
    if (attributeTable != null)
      this.m_table = attributeTable.ToDictionary();
    else
      this.m_table = (IDictionary<DerObjectIdentifier, object>) new Dictionary<DerObjectIdentifier, object>();
  }

  protected virtual IDictionary<DerObjectIdentifier, object> CreateStandardAttributeTable(
    IDictionary<CmsAttributeTableParameter, object> parameters)
  {
    Dictionary<DerObjectIdentifier, object> standardAttributeTable = new Dictionary<DerObjectIdentifier, object>(this.m_table);
    if (!standardAttributeTable.ContainsKey(CmsAttributes.ContentType))
    {
      DerObjectIdentifier parameter = (DerObjectIdentifier) parameters[CmsAttributeTableParameter.ContentType];
      Attribute attribute = new Attribute(CmsAttributes.ContentType, (Asn1Set) new DerSet((Asn1Encodable) parameter));
      standardAttributeTable[attribute.AttrType] = (object) attribute;
    }
    if (!standardAttributeTable.ContainsKey(CmsAttributes.MessageDigest))
    {
      byte[] parameter = (byte[]) parameters[CmsAttributeTableParameter.Digest];
      Attribute attribute = new Attribute(CmsAttributes.MessageDigest, (Asn1Set) new DerSet((Asn1Encodable) new DerOctetString(parameter)));
      standardAttributeTable[attribute.AttrType] = (object) attribute;
    }
    return (IDictionary<DerObjectIdentifier, object>) standardAttributeTable;
  }

  public virtual AttributeTable GetAttributes(
    IDictionary<CmsAttributeTableParameter, object> parameters)
  {
    return new AttributeTable(this.CreateStandardAttributeTable(parameters));
  }
}
