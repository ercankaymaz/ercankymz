// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.Pbkdf2Params
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class Pbkdf2Params : Asn1Encodable
{
  private static AlgorithmIdentifier algid_hmacWithSHA1 = new AlgorithmIdentifier(PkcsObjectIdentifiers.IdHmacWithSha1, (Asn1Encodable) DerNull.Instance);
  private readonly Asn1OctetString octStr;
  private readonly DerInteger iterationCount;
  private readonly DerInteger keyLength;
  private readonly AlgorithmIdentifier prf;

  public static Pbkdf2Params GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case Pbkdf2Params _:
        return (Pbkdf2Params) obj;
      case Asn1Sequence _:
        return new Pbkdf2Params((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public Pbkdf2Params(Asn1Sequence seq)
  {
    this.octStr = seq.Count >= 2 && seq.Count <= 4 ? (Asn1OctetString) seq[0] : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.iterationCount = (DerInteger) seq[1];
    Asn1Encodable asn1Encodable1 = (Asn1Encodable) null;
    Asn1Encodable asn1Encodable2 = (Asn1Encodable) null;
    if (seq.Count > 3)
    {
      asn1Encodable1 = seq[2];
      asn1Encodable2 = seq[3];
    }
    else if (seq.Count > 2)
    {
      if (seq[2] is DerInteger)
        asn1Encodable1 = seq[2];
      else
        asn1Encodable2 = seq[2];
    }
    if (asn1Encodable1 != null)
      this.keyLength = (DerInteger) asn1Encodable1;
    if (asn1Encodable2 == null)
      return;
    this.prf = AlgorithmIdentifier.GetInstance((object) asn1Encodable2);
  }

  public Pbkdf2Params(byte[] salt, int iterationCount)
  {
    this.octStr = (Asn1OctetString) new DerOctetString(salt);
    this.iterationCount = new DerInteger(iterationCount);
  }

  public Pbkdf2Params(byte[] salt, int iterationCount, int keyLength)
    : this(salt, iterationCount)
  {
    this.keyLength = new DerInteger(keyLength);
  }

  public Pbkdf2Params(byte[] salt, int iterationCount, int keyLength, AlgorithmIdentifier prf)
    : this(salt, iterationCount, keyLength)
  {
    this.prf = prf;
  }

  public Pbkdf2Params(byte[] salt, int iterationCount, AlgorithmIdentifier prf)
    : this(salt, iterationCount)
  {
    this.prf = prf;
  }

  public byte[] GetSalt() => this.octStr.GetOctets();

  public BigInteger IterationCount => this.iterationCount.Value;

  public BigInteger KeyLength => this.keyLength != null ? this.keyLength.Value : (BigInteger) null;

  public bool IsDefaultPrf
  {
    get => this.prf == null || this.prf.Equals((object) Pbkdf2Params.algid_hmacWithSHA1);
  }

  public AlgorithmIdentifier Prf => this.prf == null ? Pbkdf2Params.algid_hmacWithSHA1 : this.prf;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.octStr, (Asn1Encodable) this.iterationCount);
    elementVector.AddOptional((Asn1Encodable) this.keyLength);
    if (!this.IsDefaultPrf)
      elementVector.Add((Asn1Encodable) this.prf);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
