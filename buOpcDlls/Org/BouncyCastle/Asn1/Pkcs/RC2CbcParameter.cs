// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.RC2CbcParameter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class RC2CbcParameter : Asn1Encodable
{
  internal DerInteger version;
  internal Asn1OctetString iv;

  public static RC2CbcParameter GetInstance(object obj)
  {
    return obj is Asn1Sequence ? new RC2CbcParameter((Asn1Sequence) obj) : throw new ArgumentException("Unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
  }

  public RC2CbcParameter(byte[] iv) => this.iv = (Asn1OctetString) new DerOctetString(iv);

  public RC2CbcParameter(int parameterVersion, byte[] iv)
  {
    this.version = new DerInteger(parameterVersion);
    this.iv = (Asn1OctetString) new DerOctetString(iv);
  }

  private RC2CbcParameter(Asn1Sequence seq)
  {
    if (seq.Count == 1)
    {
      this.iv = (Asn1OctetString) seq[0];
    }
    else
    {
      this.version = (DerInteger) seq[0];
      this.iv = (Asn1OctetString) seq[1];
    }
  }

  public BigInteger RC2ParameterVersion
  {
    get => this.version != null ? this.version.Value : (BigInteger) null;
  }

  public byte[] GetIV() => Arrays.Clone(this.iv.GetOctets());

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(2);
    elementVector.AddOptional((Asn1Encodable) this.version);
    elementVector.Add((Asn1Encodable) this.iv);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
