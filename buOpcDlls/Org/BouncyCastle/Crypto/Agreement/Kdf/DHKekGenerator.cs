// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.Kdf.DHKekGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement.Kdf;

public sealed class DHKekGenerator : IDerivationFunction
{
  private readonly IDigest m_digest;
  private DerObjectIdentifier algorithm;
  private int keySize;
  private byte[] z;
  private byte[] partyAInfo;

  public DHKekGenerator(IDigest digest) => this.m_digest = digest;

  public void Init(IDerivationParameters param)
  {
    DHKdfParameters dhKdfParameters = (DHKdfParameters) param;
    this.algorithm = dhKdfParameters.Algorithm;
    this.keySize = dhKdfParameters.KeySize;
    this.z = dhKdfParameters.GetZ();
    this.partyAInfo = dhKdfParameters.GetExtraInfo();
  }

  public IDigest Digest => this.m_digest;

  public int GenerateBytes(byte[] outBytes, int outOff, int length)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, length, "output buffer too small");
    long bytes = (long) length;
    int digestSize = this.m_digest.GetDigestSize();
    if (bytes > 8589934591L /*0x01FFFFFFFF*/)
      throw new ArgumentException("Output length too large");
    int num = (int) ((bytes + (long) digestSize - 1L) / (long) digestSize);
    byte[] numArray = new byte[digestSize];
    uint n = 1;
    for (int index = 0; index < num; ++index)
    {
      Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) new DerSequence((Asn1Encodable) this.algorithm, (Asn1Encodable) new DerOctetString(Pack.UInt32_To_BE(n))));
      if (this.partyAInfo != null)
        elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 0, (Asn1Encodable) new DerOctetString(this.partyAInfo)));
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 2, (Asn1Encodable) new DerOctetString(Pack.UInt32_To_BE((uint) this.keySize))));
      byte[] derEncoded = new DerSequence(elementVector).GetDerEncoded();
      this.m_digest.BlockUpdate(this.z, 0, this.z.Length);
      this.m_digest.BlockUpdate(derEncoded, 0, derEncoded.Length);
      this.m_digest.DoFinal(numArray, 0);
      if (length > digestSize)
      {
        Array.Copy((Array) numArray, 0, (Array) outBytes, outOff, digestSize);
        outOff += digestSize;
        length -= digestSize;
      }
      else
        Array.Copy((Array) numArray, 0, (Array) outBytes, outOff, length);
      ++n;
    }
    this.m_digest.Reset();
    return (int) bytes;
  }
}
