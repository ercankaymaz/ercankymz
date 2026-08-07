// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.AltSignatureAlgorithm
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class AltSignatureAlgorithm : Asn1Encodable
{
  private readonly AlgorithmIdentifier m_algorithm;

  public static AltSignatureAlgorithm GetInstance(object obj)
  {
    if (obj == null)
      return (AltSignatureAlgorithm) null;
    return obj is AltSignatureAlgorithm signatureAlgorithm ? signatureAlgorithm : new AltSignatureAlgorithm(AlgorithmIdentifier.GetInstance(obj));
  }

  public static AltSignatureAlgorithm GetInstance(
    Asn1TaggedObject taggedObject,
    bool declaredExplicit)
  {
    return AltSignatureAlgorithm.GetInstance((object) AlgorithmIdentifier.GetInstance(taggedObject, declaredExplicit));
  }

  public static AltSignatureAlgorithm FromExtensions(X509Extensions extensions)
  {
    return AltSignatureAlgorithm.GetInstance((object) X509Extensions.GetExtensionParsedValue(extensions, X509Extensions.AltSignatureAlgorithm));
  }

  public AltSignatureAlgorithm(AlgorithmIdentifier algorithm) => this.m_algorithm = algorithm;

  public AltSignatureAlgorithm(DerObjectIdentifier algorithm)
    : this(algorithm, (Asn1Encodable) null)
  {
  }

  public AltSignatureAlgorithm(DerObjectIdentifier algorithm, Asn1Encodable parameters)
  {
    this.m_algorithm = new AlgorithmIdentifier(algorithm, parameters);
  }

  public AlgorithmIdentifier Algorithm => this.m_algorithm;

  public override Asn1Object ToAsn1Object() => this.m_algorithm.ToAsn1Object();
}
