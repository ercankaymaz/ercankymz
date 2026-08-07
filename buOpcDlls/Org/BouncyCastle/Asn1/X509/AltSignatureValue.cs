// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.AltSignatureValue
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class AltSignatureValue : Asn1Encodable
{
  private readonly DerBitString m_signature;

  public static AltSignatureValue GetInstance(object obj)
  {
    if (obj == null)
      return (AltSignatureValue) null;
    return obj is AltSignatureValue altSignatureValue ? altSignatureValue : new AltSignatureValue(DerBitString.GetInstance(obj));
  }

  public static AltSignatureValue GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return AltSignatureValue.GetInstance((object) DerBitString.GetInstance(taggedObject, declaredExplicit));
  }

  public static AltSignatureValue FromExtensions(X509Extensions extensions)
  {
    return AltSignatureValue.GetInstance((object) X509Extensions.GetExtensionParsedValue(extensions, X509Extensions.AltSignatureValue));
  }

  private AltSignatureValue(DerBitString signature) => this.m_signature = signature;

  public AltSignatureValue(byte[] signature) => this.m_signature = new DerBitString(signature);

  public DerBitString Signature => this.m_signature;

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.m_signature;
}
