// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Mozilla.PublicKeyAndChallenge
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Mozilla;

public class PublicKeyAndChallenge : Asn1Encodable
{
  private Asn1Sequence pkacSeq;
  private SubjectPublicKeyInfo spki;
  private DerIA5String challenge;

  public static PublicKeyAndChallenge GetInstance(object obj)
  {
    switch (obj)
    {
      case PublicKeyAndChallenge _:
        return (PublicKeyAndChallenge) obj;
      case Asn1Sequence _:
        return new PublicKeyAndChallenge((Asn1Sequence) obj);
      default:
        throw new ArgumentException($"unknown object in 'PublicKeyAndChallenge' factory : {Platform.GetTypeName(obj)}.");
    }
  }

  public PublicKeyAndChallenge(Asn1Sequence seq)
  {
    this.pkacSeq = seq;
    this.spki = SubjectPublicKeyInfo.GetInstance((object) seq[0]);
    this.challenge = DerIA5String.GetInstance((object) seq[1]);
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.pkacSeq;

  public SubjectPublicKeyInfo SubjectPublicKeyInfo => this.spki;

  public DerIA5String Challenge => this.challenge;
}
