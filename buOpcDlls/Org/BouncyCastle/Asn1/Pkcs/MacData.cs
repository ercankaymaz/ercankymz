// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.MacData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class MacData : Asn1Encodable
{
  internal DigestInfo digInfo;
  internal byte[] salt;
  internal BigInteger iterationCount;

  public static MacData GetInstance(object obj)
  {
    switch (obj)
    {
      case MacData _:
        return (MacData) obj;
      case Asn1Sequence _:
        return new MacData((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private MacData(Asn1Sequence seq)
  {
    this.digInfo = DigestInfo.GetInstance((object) seq[0]);
    this.salt = ((Asn1OctetString) seq[1]).GetOctets();
    if (seq.Count == 3)
      this.iterationCount = ((DerInteger) seq[2]).Value;
    else
      this.iterationCount = BigInteger.One;
  }

  public MacData(DigestInfo digInfo, byte[] salt, int iterationCount)
  {
    this.digInfo = digInfo;
    this.salt = (byte[]) salt.Clone();
    this.iterationCount = BigInteger.ValueOf((long) iterationCount);
  }

  public DigestInfo Mac => this.digInfo;

  public byte[] GetSalt() => (byte[]) this.salt.Clone();

  public BigInteger IterationCount => this.iterationCount;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.digInfo, (Asn1Encodable) new DerOctetString(this.salt));
    if (!this.iterationCount.Equals(BigInteger.One))
      elementVector.Add((Asn1Encodable) new DerInteger(this.iterationCount));
    return (Asn1Object) new DerSequence(elementVector);
  }
}
