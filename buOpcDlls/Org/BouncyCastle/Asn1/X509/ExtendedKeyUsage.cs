// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.ExtendedKeyUsage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class ExtendedKeyUsage : Asn1Encodable
{
  internal readonly HashSet<DerObjectIdentifier> m_usageTable = new HashSet<DerObjectIdentifier>();
  internal readonly Asn1Sequence seq;

  public static ExtendedKeyUsage GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return ExtendedKeyUsage.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static ExtendedKeyUsage GetInstance(object obj)
  {
    switch (obj)
    {
      case ExtendedKeyUsage _:
        return (ExtendedKeyUsage) obj;
      case X509Extension _:
        return ExtendedKeyUsage.GetInstance((object) X509Extension.ConvertValueToObject((X509Extension) obj));
      case null:
        return (ExtendedKeyUsage) null;
      default:
        return new ExtendedKeyUsage(Asn1Sequence.GetInstance(obj));
    }
  }

  public static ExtendedKeyUsage FromExtensions(X509Extensions extensions)
  {
    return ExtendedKeyUsage.GetInstance((object) X509Extensions.GetExtensionParsedValue(extensions, X509Extensions.ExtendedKeyUsage));
  }

  private ExtendedKeyUsage(Asn1Sequence seq)
  {
    this.seq = seq;
    foreach (object obj in seq)
      this.m_usageTable.Add(DerObjectIdentifier.GetInstance(obj));
  }

  public ExtendedKeyUsage(params KeyPurposeID[] usages)
  {
    this.seq = (Asn1Sequence) new DerSequence((Asn1Encodable[]) usages);
    foreach (DerObjectIdentifier usage in usages)
      this.m_usageTable.Add(usage);
  }

  public ExtendedKeyUsage(IEnumerable<DerObjectIdentifier> usages)
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector();
    foreach (DerObjectIdentifier usage in usages)
    {
      elementVector.Add((Asn1Encodable) usage);
      this.m_usageTable.Add(usage);
    }
    this.seq = (Asn1Sequence) new DerSequence(elementVector);
  }

  public bool HasKeyPurposeId(KeyPurposeID keyPurposeId)
  {
    return this.m_usageTable.Contains((DerObjectIdentifier) keyPurposeId);
  }

  public IList<DerObjectIdentifier> GetAllUsages()
  {
    return (IList<DerObjectIdentifier>) new List<DerObjectIdentifier>((IEnumerable<DerObjectIdentifier>) this.m_usageTable);
  }

  public int Count => this.m_usageTable.Count;

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.seq;
}
