// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.PbmParameter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class PbmParameter : Asn1Encodable
{
  private readonly Asn1OctetString m_salt;
  private readonly AlgorithmIdentifier m_owf;
  private readonly DerInteger m_iterationCount;
  private readonly AlgorithmIdentifier m_mac;

  public static PbmParameter GetInstance(object obj)
  {
    if (obj == null)
      return (PbmParameter) null;
    return obj is PbmParameter pbmParameter ? pbmParameter : new PbmParameter(Asn1Sequence.GetInstance(obj));
  }

  public static PbmParameter GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return PbmParameter.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private PbmParameter(Asn1Sequence seq)
  {
    this.m_salt = Asn1OctetString.GetInstance((object) seq[0]);
    this.m_owf = AlgorithmIdentifier.GetInstance((object) seq[1]);
    this.m_iterationCount = DerInteger.GetInstance((object) seq[2]);
    this.m_mac = AlgorithmIdentifier.GetInstance((object) seq[3]);
  }

  public PbmParameter(
    byte[] salt,
    AlgorithmIdentifier owf,
    int iterationCount,
    AlgorithmIdentifier mac)
    : this((Asn1OctetString) new DerOctetString(salt), owf, new DerInteger(iterationCount), mac)
  {
  }

  public PbmParameter(
    Asn1OctetString salt,
    AlgorithmIdentifier owf,
    DerInteger iterationCount,
    AlgorithmIdentifier mac)
  {
    this.m_salt = salt;
    this.m_owf = owf;
    this.m_iterationCount = iterationCount;
    this.m_mac = mac;
  }

  public virtual DerInteger IterationCount => this.m_iterationCount;

  public virtual AlgorithmIdentifier Mac => this.m_mac;

  public virtual AlgorithmIdentifier Owf => this.m_owf;

  public virtual Asn1OctetString Salt => this.m_salt;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence(new Asn1Encodable[4]
    {
      (Asn1Encodable) this.m_salt,
      (Asn1Encodable) this.m_owf,
      (Asn1Encodable) this.m_iterationCount,
      (Asn1Encodable) this.m_mac
    });
  }
}
