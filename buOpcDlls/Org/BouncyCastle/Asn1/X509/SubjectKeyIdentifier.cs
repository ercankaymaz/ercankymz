// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.SubjectKeyIdentifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class SubjectKeyIdentifier : Asn1Encodable
{
  private readonly byte[] keyIdentifier;

  public static SubjectKeyIdentifier GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return SubjectKeyIdentifier.GetInstance((object) Asn1OctetString.GetInstance(obj, explicitly));
  }

  public static SubjectKeyIdentifier GetInstance(object obj)
  {
    switch (obj)
    {
      case SubjectKeyIdentifier _:
        return (SubjectKeyIdentifier) obj;
      case SubjectPublicKeyInfo _:
        return new SubjectKeyIdentifier((SubjectPublicKeyInfo) obj);
      case X509Extension _:
        return SubjectKeyIdentifier.GetInstance((object) X509Extension.ConvertValueToObject((X509Extension) obj));
      case null:
        return (SubjectKeyIdentifier) null;
      default:
        return new SubjectKeyIdentifier(Asn1OctetString.GetInstance(obj));
    }
  }

  public static SubjectKeyIdentifier FromExtensions(X509Extensions extensions)
  {
    return SubjectKeyIdentifier.GetInstance((object) X509Extensions.GetExtensionParsedValue(extensions, X509Extensions.SubjectKeyIdentifier));
  }

  public SubjectKeyIdentifier(byte[] keyID)
  {
    this.keyIdentifier = keyID != null ? Arrays.Clone(keyID) : throw new ArgumentNullException(nameof (keyID));
  }

  public SubjectKeyIdentifier(Asn1OctetString keyID)
    : this(keyID.GetOctets())
  {
  }

  public SubjectKeyIdentifier(SubjectPublicKeyInfo spki)
  {
    this.keyIdentifier = SubjectKeyIdentifier.GetDigest(spki);
  }

  public byte[] GetKeyIdentifier() => Arrays.Clone(this.keyIdentifier);

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerOctetString(this.GetKeyIdentifier());
  }

  public static SubjectKeyIdentifier CreateSha1KeyIdentifier(SubjectPublicKeyInfo keyInfo)
  {
    return new SubjectKeyIdentifier(keyInfo);
  }

  public static SubjectKeyIdentifier CreateTruncatedSha1KeyIdentifier(SubjectPublicKeyInfo keyInfo)
  {
    byte[] digest = SubjectKeyIdentifier.GetDigest(keyInfo);
    byte[] numArray = new byte[8];
    Array.Copy((Array) digest, digest.Length - 8, (Array) numArray, 0, numArray.Length);
    numArray[0] &= (byte) 15;
    numArray[0] |= (byte) 64 /*0x40*/;
    return new SubjectKeyIdentifier(numArray);
  }

  private static byte[] GetDigest(SubjectPublicKeyInfo spki)
  {
    Sha1Digest sha1Digest = new Sha1Digest();
    byte[] output = new byte[sha1Digest.GetDigestSize()];
    byte[] bytes = spki.PublicKeyData.GetBytes();
    sha1Digest.BlockUpdate(bytes, 0, bytes.Length);
    sha1Digest.DoFinal(output, 0);
    return output;
  }
}
