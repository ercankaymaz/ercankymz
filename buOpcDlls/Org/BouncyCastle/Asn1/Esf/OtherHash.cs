// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.OtherHash
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class OtherHash : Asn1Encodable, IAsn1Choice
{
  private readonly Asn1OctetString sha1Hash;
  private readonly OtherHashAlgAndValue otherHash;

  public static OtherHash GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case OtherHash _:
        return (OtherHash) obj;
      case Asn1OctetString _:
        return new OtherHash((Asn1OctetString) obj);
      default:
        return new OtherHash(OtherHashAlgAndValue.GetInstance(obj));
    }
  }

  public OtherHash(byte[] sha1Hash)
  {
    this.sha1Hash = sha1Hash != null ? (Asn1OctetString) new DerOctetString(sha1Hash) : throw new ArgumentNullException(nameof (sha1Hash));
  }

  public OtherHash(Asn1OctetString sha1Hash)
  {
    this.sha1Hash = sha1Hash != null ? sha1Hash : throw new ArgumentNullException(nameof (sha1Hash));
  }

  public OtherHash(OtherHashAlgAndValue otherHash)
  {
    this.otherHash = otherHash != null ? otherHash : throw new ArgumentNullException(nameof (otherHash));
  }

  public AlgorithmIdentifier HashAlgorithm
  {
    get
    {
      return this.otherHash != null ? this.otherHash.HashAlgorithm : new AlgorithmIdentifier(OiwObjectIdentifiers.IdSha1);
    }
  }

  public byte[] GetHashValue()
  {
    return this.otherHash != null ? this.otherHash.GetHashValue() : this.sha1Hash.GetOctets();
  }

  public override Asn1Object ToAsn1Object()
  {
    return this.otherHash != null ? this.otherHash.ToAsn1Object() : (Asn1Object) this.sha1Hash;
  }
}
