// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.AuthorityKeyIdentifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities.Encoders;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class AuthorityKeyIdentifier : Asn1Encodable
{
  private readonly Asn1OctetString keyidentifier;
  private readonly GeneralNames certissuer;
  private readonly DerInteger certserno;

  public static AuthorityKeyIdentifier GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return AuthorityKeyIdentifier.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static AuthorityKeyIdentifier GetInstance(object obj)
  {
    switch (obj)
    {
      case AuthorityKeyIdentifier _:
        return (AuthorityKeyIdentifier) obj;
      case X509Extension _:
        return AuthorityKeyIdentifier.GetInstance((object) X509Extension.ConvertValueToObject((X509Extension) obj));
      case null:
        return (AuthorityKeyIdentifier) null;
      default:
        return new AuthorityKeyIdentifier(Asn1Sequence.GetInstance(obj));
    }
  }

  public static AuthorityKeyIdentifier FromExtensions(X509Extensions extensions)
  {
    return AuthorityKeyIdentifier.GetInstance((object) X509Extensions.GetExtensionParsedValue(extensions, X509Extensions.AuthorityKeyIdentifier));
  }

  protected internal AuthorityKeyIdentifier(Asn1Sequence seq)
  {
    foreach (object obj in seq)
    {
      Asn1TaggedObject instance = Asn1TaggedObject.GetInstance(obj);
      switch (instance.TagNo)
      {
        case 0:
          this.keyidentifier = Asn1OctetString.GetInstance(instance, false);
          continue;
        case 1:
          this.certissuer = GeneralNames.GetInstance(instance, false);
          continue;
        case 2:
          this.certserno = DerInteger.GetInstance(instance, false);
          continue;
        default:
          throw new ArgumentException("illegal tag");
      }
    }
  }

  public AuthorityKeyIdentifier(SubjectPublicKeyInfo spki)
    : this(spki, (GeneralNames) null, (BigInteger) null)
  {
  }

  public AuthorityKeyIdentifier(
    SubjectPublicKeyInfo spki,
    GeneralNames name,
    BigInteger serialNumber)
  {
    Sha1Digest sha1Digest = new Sha1Digest();
    byte[] numArray = new byte[sha1Digest.GetDigestSize()];
    byte[] bytes = spki.PublicKeyData.GetBytes();
    sha1Digest.BlockUpdate(bytes, 0, bytes.Length);
    sha1Digest.DoFinal(numArray, 0);
    this.keyidentifier = (Asn1OctetString) new DerOctetString(numArray);
    this.certissuer = name;
    this.certserno = serialNumber == null ? (DerInteger) null : new DerInteger(serialNumber);
  }

  public AuthorityKeyIdentifier(GeneralNames name, BigInteger serialNumber)
    : this((byte[]) null, name, serialNumber)
  {
  }

  public AuthorityKeyIdentifier(byte[] keyIdentifier)
    : this(keyIdentifier, (GeneralNames) null, (BigInteger) null)
  {
  }

  public AuthorityKeyIdentifier(byte[] keyIdentifier, GeneralNames name, BigInteger serialNumber)
  {
    this.keyidentifier = keyIdentifier == null ? (Asn1OctetString) null : (Asn1OctetString) new DerOctetString(keyIdentifier);
    this.certissuer = name;
    this.certserno = serialNumber == null ? (DerInteger) null : new DerInteger(serialNumber);
  }

  public byte[] GetKeyIdentifier()
  {
    return this.keyidentifier != null ? this.keyidentifier.GetOctets() : (byte[]) null;
  }

  public GeneralNames AuthorityCertIssuer => this.certissuer;

  public BigInteger AuthorityCertSerialNumber
  {
    get => this.certserno != null ? this.certserno.Value : (BigInteger) null;
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.keyidentifier);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.certissuer);
    elementVector.AddOptionalTagged(false, 2, (Asn1Encodable) this.certserno);
    return (Asn1Object) new DerSequence(elementVector);
  }

  public override string ToString()
  {
    return $"AuthorityKeyIdentifier: KeyID({(this.keyidentifier != null ? Hex.ToHexString(this.keyidentifier.GetOctets()) : "null")})";
  }
}
