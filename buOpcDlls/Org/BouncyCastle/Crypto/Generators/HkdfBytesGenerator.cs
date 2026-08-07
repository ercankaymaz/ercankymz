// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.HkdfBytesGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public sealed class HkdfBytesGenerator : IDerivationFunction
{
  private HMac hMacHash;
  private int hashLen;
  private byte[] info;
  private byte[] currentT;
  private int generatedBytes;

  public HkdfBytesGenerator(IDigest hash)
  {
    this.hMacHash = new HMac(hash);
    this.hashLen = hash.GetDigestSize();
  }

  public void Init(IDerivationParameters parameters)
  {
    if (!(parameters is HkdfParameters hkdfParameters))
      throw new ArgumentException("HKDF parameters required for HkdfBytesGenerator", nameof (parameters));
    if (hkdfParameters.SkipExtract)
      this.hMacHash.Init((ICipherParameters) new KeyParameter(hkdfParameters.GetIkm()));
    else
      this.hMacHash.Init((ICipherParameters) this.Extract(hkdfParameters.GetSalt(), hkdfParameters.GetIkm()));
    this.info = hkdfParameters.GetInfo();
    this.generatedBytes = 0;
    this.currentT = new byte[this.hashLen];
  }

  private KeyParameter Extract(byte[] salt, byte[] ikm)
  {
    if (salt == null)
      this.hMacHash.Init((ICipherParameters) new KeyParameter(new byte[this.hashLen]));
    else
      this.hMacHash.Init((ICipherParameters) new KeyParameter(salt));
    this.hMacHash.BlockUpdate(ikm, 0, ikm.Length);
    byte[] numArray = new byte[this.hashLen];
    this.hMacHash.DoFinal(numArray, 0);
    return new KeyParameter(numArray);
  }

  private void ExpandNext()
  {
    int input = this.generatedBytes / this.hashLen + 1;
    if (input >= 256 /*0x0100*/)
      throw new DataLengthException("HKDF cannot generate more than 255 blocks of HashLen size");
    if (this.generatedBytes != 0)
      this.hMacHash.BlockUpdate(this.currentT, 0, this.hashLen);
    this.hMacHash.BlockUpdate(this.info, 0, this.info.Length);
    this.hMacHash.Update((byte) input);
    this.hMacHash.DoFinal(this.currentT, 0);
  }

  public IDigest Digest => this.hMacHash.GetUnderlyingDigest();

  public int GenerateBytes(byte[] output, int outOff, int length)
  {
    if (this.generatedBytes > (int) byte.MaxValue * this.hashLen - length)
      throw new DataLengthException("HKDF may only be used for 255 * HashLen bytes of output");
    int val2 = length;
    int sourceIndex = this.generatedBytes % this.hashLen;
    if (sourceIndex != 0)
    {
      int length1 = Math.Min(this.hashLen - sourceIndex, val2);
      Array.Copy((Array) this.currentT, sourceIndex, (Array) output, outOff, length1);
      this.generatedBytes += length1;
      val2 -= length1;
      outOff += length1;
    }
    while (val2 > 0)
    {
      this.ExpandNext();
      int length2 = Math.Min(this.hashLen, val2);
      Array.Copy((Array) this.currentT, 0, (Array) output, outOff, length2);
      this.generatedBytes += length2;
      val2 -= length2;
      outOff += length2;
    }
    return length;
  }
}
