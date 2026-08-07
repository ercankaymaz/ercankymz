// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Macs.HMac
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Macs;

public class HMac : IMac
{
  private const byte IPAD = 54;
  private const byte OPAD = 92;
  private readonly IDigest digest;
  private readonly int digestSize;
  private readonly int blockLength;
  private IMemoable ipadState;
  private IMemoable opadState;
  private readonly byte[] inputPad;
  private readonly byte[] outputBuf;

  public HMac(IDigest digest)
    : this(digest, digest.GetByteLength())
  {
  }

  public HMac(IDigest digest, int blockLength)
  {
    if (blockLength < 16 /*0x10*/)
      throw new ArgumentException("must be at least 16 bytes", nameof (blockLength));
    this.digest = digest;
    this.digestSize = digest.GetDigestSize();
    this.blockLength = blockLength;
    this.inputPad = new byte[blockLength];
    this.outputBuf = new byte[blockLength + this.digestSize];
  }

  public virtual string AlgorithmName => this.digest.AlgorithmName + "/HMAC";

  public virtual IDigest GetUnderlyingDigest() => this.digest;

  public virtual void Init(ICipherParameters parameters)
  {
    this.digest.Reset();
    byte[] key = ((KeyParameter) parameters).GetKey();
    int num = key.Length;
    if (num > this.blockLength)
    {
      this.digest.BlockUpdate(key, 0, num);
      this.digest.DoFinal(this.inputPad, 0);
      num = this.digestSize;
    }
    else
      Array.Copy((Array) key, 0, (Array) this.inputPad, 0, num);
    Array.Clear((Array) this.inputPad, num, this.blockLength - num);
    Array.Copy((Array) this.inputPad, 0, (Array) this.outputBuf, 0, this.blockLength);
    HMac.XorPad(this.inputPad, this.blockLength, (byte) 54);
    HMac.XorPad(this.outputBuf, this.blockLength, (byte) 92);
    if (this.digest is IMemoable)
    {
      this.opadState = ((IMemoable) this.digest).Copy();
      ((IDigest) this.opadState).BlockUpdate(this.outputBuf, 0, this.blockLength);
    }
    this.digest.BlockUpdate(this.inputPad, 0, this.inputPad.Length);
    if (!(this.digest is IMemoable))
      return;
    this.ipadState = ((IMemoable) this.digest).Copy();
  }

  public virtual int GetMacSize() => this.digestSize;

  public virtual void Update(byte input) => this.digest.Update(input);

  public virtual void BlockUpdate(byte[] input, int inOff, int len)
  {
    this.digest.BlockUpdate(input, inOff, len);
  }

  public virtual int DoFinal(byte[] output, int outOff)
  {
    this.digest.DoFinal(this.outputBuf, this.blockLength);
    if (this.opadState != null)
    {
      ((IMemoable) this.digest).Reset(this.opadState);
      this.digest.BlockUpdate(this.outputBuf, this.blockLength, this.digestSize);
    }
    else
      this.digest.BlockUpdate(this.outputBuf, 0, this.outputBuf.Length);
    int num = this.digest.DoFinal(output, outOff);
    Array.Clear((Array) this.outputBuf, this.blockLength, this.digestSize);
    if (this.ipadState != null)
    {
      ((IMemoable) this.digest).Reset(this.ipadState);
      return num;
    }
    this.digest.BlockUpdate(this.inputPad, 0, this.inputPad.Length);
    return num;
  }

  public virtual void Reset()
  {
    if (this.ipadState != null)
    {
      ((IMemoable) this.digest).Reset(this.ipadState);
    }
    else
    {
      this.digest.Reset();
      this.digest.BlockUpdate(this.inputPad, 0, this.inputPad.Length);
    }
  }

  private static void XorPad(byte[] pad, int len, byte n)
  {
    for (int index = 0; index < len; ++index)
      pad[index] ^= n;
  }
}
