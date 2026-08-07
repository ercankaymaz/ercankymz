// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.AttributeTable
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class AttributeTable
{
  private readonly Dictionary<DerObjectIdentifier, object> m_attributes;

  public AttributeTable(IDictionary<DerObjectIdentifier, object> attrs)
  {
    this.m_attributes = new Dictionary<DerObjectIdentifier, object>(attrs);
  }

  public AttributeTable(Asn1EncodableVector v)
  {
    this.m_attributes = new Dictionary<DerObjectIdentifier, object>(v.Count);
    foreach (object obj in v)
      this.AddAttribute(Attribute.GetInstance(obj));
  }

  public AttributeTable(Asn1Set s)
  {
    this.m_attributes = new Dictionary<DerObjectIdentifier, object>(s.Count);
    foreach (object obj in s)
      this.AddAttribute(Attribute.GetInstance(obj));
  }

  public AttributeTable(Attributes attrs)
    : this(Asn1Set.GetInstance((object) attrs.ToAsn1Object()))
  {
  }

  private void AddAttribute(Attribute a)
  {
    DerObjectIdentifier attrType = a.AttrType;
    object obj;
    if (!this.m_attributes.TryGetValue(attrType, out obj))
    {
      this.m_attributes[attrType] = (object) a;
    }
    else
    {
      switch (obj)
      {
        case IList<Attribute> attributeList:
          attributeList.Add(a);
          break;
        case Attribute attribute:
          this.m_attributes[attrType] = (object) new List<Attribute>()
          {
            attribute,
            a
          };
          break;
        default:
          throw new InvalidOperationException();
      }
    }
  }

  public Attribute this[DerObjectIdentifier oid]
  {
    get
    {
      object obj;
      if (!this.m_attributes.TryGetValue(oid, out obj))
        return (Attribute) null;
      switch (obj)
      {
        case IList<Attribute> attributeList:
          return attributeList[0];
        case Attribute attribute:
          return attribute;
        default:
          throw new InvalidOperationException();
      }
    }
  }

  public Asn1EncodableVector GetAll(DerObjectIdentifier oid)
  {
    Asn1EncodableVector all = new Asn1EncodableVector();
    object obj;
    if (this.m_attributes.TryGetValue(oid, out obj))
    {
      switch (obj)
      {
        case IList<Attribute> attributeList:
          using (IEnumerator<Attribute> enumerator = attributeList.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              Attribute current = enumerator.Current;
              all.Add((Asn1Encodable) current);
            }
            break;
          }
        case Attribute element:
          all.Add((Asn1Encodable) element);
          break;
        default:
          throw new InvalidOperationException();
      }
    }
    return all;
  }

  public int Count
  {
    get
    {
      int count = 0;
      foreach (object obj in this.m_attributes.Values)
      {
        switch (obj)
        {
          case IList<Attribute> attributeList:
            count += attributeList.Count;
            continue;
          case Attribute _:
            ++count;
            continue;
          default:
            throw new InvalidOperationException();
        }
      }
      return count;
    }
  }

  public IDictionary<DerObjectIdentifier, object> ToDictionary()
  {
    return (IDictionary<DerObjectIdentifier, object>) new Dictionary<DerObjectIdentifier, object>((IDictionary<DerObjectIdentifier, object>) this.m_attributes);
  }

  public Asn1EncodableVector ToAsn1EncodableVector()
  {
    Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector();
    foreach (object obj in this.m_attributes.Values)
    {
      switch (obj)
      {
        case IList<Attribute> attributeList:
          using (IEnumerator<Attribute> enumerator = attributeList.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              Attribute current = enumerator.Current;
              asn1EncodableVector.Add((Asn1Encodable) current);
            }
            continue;
          }
        case Attribute element:
          asn1EncodableVector.Add((Asn1Encodable) element);
          continue;
        default:
          throw new InvalidOperationException();
      }
    }
    return asn1EncodableVector;
  }

  public Attributes ToAttributes() => new Attributes(this.ToAsn1EncodableVector());

  public AttributeTable Add(params Attribute[] attributes)
  {
    if (attributes == null || attributes.Length < 1)
      return this;
    AttributeTable attributeTable = new AttributeTable((IDictionary<DerObjectIdentifier, object>) this.m_attributes);
    foreach (Attribute attribute in attributes)
      attributeTable.AddAttribute(attribute);
    return attributeTable;
  }

  public AttributeTable Add(DerObjectIdentifier attrType, Asn1Encodable attrValue)
  {
    AttributeTable attributeTable = new AttributeTable((IDictionary<DerObjectIdentifier, object>) this.m_attributes);
    attributeTable.AddAttribute(new Attribute(attrType, (Asn1Set) new DerSet(attrValue)));
    return attributeTable;
  }

  public AttributeTable Remove(DerObjectIdentifier attrType)
  {
    AttributeTable attributeTable = new AttributeTable((IDictionary<DerObjectIdentifier, object>) this.m_attributes);
    attributeTable.m_attributes.Remove(attrType);
    return attributeTable;
  }
}
