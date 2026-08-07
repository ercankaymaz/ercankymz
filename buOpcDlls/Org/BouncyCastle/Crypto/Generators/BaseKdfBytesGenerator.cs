// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.BaseKdfBytesGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public abstract class BaseKdfBytesGenerator : IDerivationFunction
{
  private int counterStart;
  private IDigest digest;
  private byte[] shared;
  private byte[] iv;

  protected BaseKdfBytesGenerator(int counterStart, IDigest digest)
  {
    this.counterStart = counterStart;
    this.digest = digest;
  }

  public void Init(IDerivationParameters parameters)
  {
    switch (parameters)
    {
      case KdfParameters kdfParameters:
        this.shared = kdfParameters.GetSharedSecret();
        this.iv = kdfParameters.GetIV();
        break;
      case Iso18033KdfParameters iso18033KdfParameters:
        this.shared = iso18033KdfParameters.GetSeed();
        this.iv = (byte[]) null;
        break;
      default:
        throw new ArgumentException("KDF parameters required for KDF Generator");
    }
  }

  public IDigest Digest => this.digest;

  public int GenerateBytes(byte[] output, int outOff, int length)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, length, "output buffer too small");
    long bytes = (long) length;
    int digestSize = this.digest.GetDigestSize();
    if (bytes > 8589934591L /*0x01FFFFFFFF*/)
      throw new ArgumentException("Output length too large");
    int num = (int) ((bytes + (long) digestSize - 1L) / (long) digestSize);
    byte[] numArray1 = new byte[digestSize];
    byte[] numArray2 = new byte[4];
    Pack.UInt32_To_BE((uint) this.counterStart, numArray2, 0);
    uint n = (uint) (this.counterStart & -256);
    for (int index = 0; index < num; ++index)
    {
      this.digest.BlockUpdate(this.shared, 0, this.shared.Length);
      this.digest.BlockUpdate(numArray2, 0, 4);
      if (this.iv != null)
        this.digest.BlockUpdate(this.iv, 0, this.iv.Length);
      this.digest.DoFinal(numArray1, 0);
      if (length > digestSize)
      {
        Array.Copy((Array) numArray1, 0, (Array) output, outOff, digestSize);
        outOff += digestSize;
        length -= digestSize;
      }
      else
        Array.Copy((Array) numArray1, 0, (Array) output, outOff, length);
      if (++numArray2[3] == (byte) 0)
      {
        n += 256U /*0x0100*/;
        Pack.UInt32_To_BE(n, numArray2, 0);
      }
    }
    this.digest.Reset();
    return (int) bytes;
  }
}
