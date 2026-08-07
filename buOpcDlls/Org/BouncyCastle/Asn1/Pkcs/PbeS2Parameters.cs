// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.PbeS2Parameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class PbeS2Parameters : Asn1Encodable
{
  private readonly KeyDerivationFunc func;
  private readonly EncryptionScheme scheme;

  public static PbeS2Parameters GetInstance(object obj)
  {
    if (obj == null)
      return (PbeS2Parameters) null;
    return obj is PbeS2Parameters pbeS2Parameters ? pbeS2Parameters : new PbeS2Parameters(Asn1Sequence.GetInstance(obj));
  }

  public PbeS2Parameters(KeyDerivationFunc keyDevFunc, EncryptionScheme encScheme)
  {
    this.func = keyDevFunc;
    this.scheme = encScheme;
  }

  private PbeS2Parameters(Asn1Sequence seq)
  {
    Asn1Sequence seq1 = seq.Count == 2 ? (Asn1Sequence) seq[0].ToAsn1Object() : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.func = !seq1[0].Equals((object) PkcsObjectIdentifiers.IdPbkdf2) ? new KeyDerivationFunc(seq1) : new KeyDerivationFunc(PkcsObjectIdentifiers.IdPbkdf2, (Asn1Encodable) Pbkdf2Params.GetInstance((object) seq1[1]));
    this.scheme = EncryptionScheme.GetInstance((object) seq[1].ToAsn1Object());
  }

  public KeyDerivationFunc KeyDerivationFunc => this.func;

  public EncryptionScheme EncryptionScheme => this.scheme;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.func, (Asn1Encodable) this.scheme);
  }
}
