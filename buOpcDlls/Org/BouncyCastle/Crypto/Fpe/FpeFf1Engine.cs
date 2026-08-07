// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Fpe.FpeFf1Engine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Fpe;

public class FpeFf1Engine : FpeEngine
{
  public FpeFf1Engine()
    : this(AesUtilities.CreateEngine())
  {
  }

  public FpeFf1Engine(IBlockCipher baseCipher)
    : base(baseCipher)
  {
    if (FpeEngine.IsOverrideSet(SP80038G.FPE_DISABLED) || FpeEngine.IsOverrideSet(SP80038G.FF1_DISABLED))
      throw new InvalidOperationException("FF1 encryption disabled");
  }

  public override void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.forEncryption = forEncryption;
    this.fpeParameters = (FpeParameters) parameters;
    this.baseCipher.Init(!this.fpeParameters.UseInverseFunction, (ICipherParameters) this.fpeParameters.Key);
  }

  protected override int EncryptBlock(
    byte[] inBuf,
    int inOff,
    int length,
    byte[] outBuf,
    int outOff)
  {
    byte[] sourceArray;
    if (this.fpeParameters.Radix > 256 /*0x0100*/)
    {
      if ((length & 1) != 0)
        throw new ArgumentException("input must be an even number of bytes for a wide radix");
      ushort[] uint16 = Pack.BE_To_UInt16(inBuf, inOff, length);
      ushort[] ns = SP80038G.EncryptFF1w(this.baseCipher, this.fpeParameters.Radix, this.fpeParameters.GetTweak(), uint16, 0, uint16.Length);
      sourceArray = Pack.UInt16_To_BE(ns, 0, ns.Length);
    }
    else
      sourceArray = SP80038G.EncryptFF1(this.baseCipher, this.fpeParameters.Radix, this.fpeParameters.GetTweak(), inBuf, inOff, length);
    Array.Copy((Array) sourceArray, 0, (Array) outBuf, outOff, length);
    return length;
  }

  protected override int DecryptBlock(
    byte[] inBuf,
    int inOff,
    int length,
    byte[] outBuf,
    int outOff)
  {
    byte[] sourceArray;
    if (this.fpeParameters.Radix > 256 /*0x0100*/)
    {
      if ((length & 1) != 0)
        throw new ArgumentException("input must be an even number of bytes for a wide radix");
      ushort[] uint16 = Pack.BE_To_UInt16(inBuf, inOff, length);
      ushort[] ns = SP80038G.DecryptFF1w(this.baseCipher, this.fpeParameters.Radix, this.fpeParameters.GetTweak(), uint16, 0, uint16.Length);
      sourceArray = Pack.UInt16_To_BE(ns, 0, ns.Length);
    }
    else
      sourceArray = SP80038G.DecryptFF1(this.baseCipher, this.fpeParameters.Radix, this.fpeParameters.GetTweak(), inBuf, inOff, length);
    Array.Copy((Array) sourceArray, 0, (Array) outBuf, outOff, length);
    return length;
  }
}
