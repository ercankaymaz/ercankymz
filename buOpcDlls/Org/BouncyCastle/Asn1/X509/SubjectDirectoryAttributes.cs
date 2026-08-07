// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.SubjectDirectoryAttributes
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Collections;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class SubjectDirectoryAttributes : Asn1Encodable
{
  private readonly List<AttributeX509> m_attributes;

  public static SubjectDirectoryAttributes GetInstance(object obj)
  {
    if (obj == null)
      return (SubjectDirectoryAttributes) null;
    return obj is SubjectDirectoryAttributes directoryAttributes ? directoryAttributes : new SubjectDirectoryAttributes(Asn1Sequence.GetInstance(obj));
  }

  private SubjectDirectoryAttributes(Asn1Sequence seq)
  {
    this.m_attributes = new List<AttributeX509>();
    foreach (object obj in seq)
      this.m_attributes.Add(AttributeX509.GetInstance((object) Asn1Sequence.GetInstance(obj)));
  }

  public SubjectDirectoryAttributes(IList<AttributeX509> attributes)
  {
    this.m_attributes = new List<AttributeX509>((IEnumerable<AttributeX509>) attributes);
  }

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable[]) this.m_attributes.ToArray());
  }

  public IEnumerable<AttributeX509> Attributes
  {
    get => CollectionUtilities.Proxy<AttributeX509>((IEnumerable<AttributeX509>) this.m_attributes);
  }
}
