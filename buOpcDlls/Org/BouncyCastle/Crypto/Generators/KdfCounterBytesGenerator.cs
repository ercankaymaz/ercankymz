// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.KdfCounterBytesGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public sealed class KdfCounterBytesGenerator : IMacDerivationFunction, IDerivationFunction
{
  private readonly IMac prf;
  private readonly int h;
  private byte[] fixedInputDataCtrPrefix;
  private byte[] fixedInputData_afterCtr;
  private int maxSizeExcl;
  private byte[] ios;
  private int generatedBytes;
  private byte[] k;

  public KdfCounterBytesGenerator(IMac prf)
  {
    this.prf = prf;
    this.h = prf.GetMacSize();
    this.k = new byte[this.h];
  }

  public void Init(IDerivationParameters param)
  {
    if (!(param is KdfCounterParameters counterParameters))
      throw new ArgumentException("Wrong type of arguments given");
    this.prf.Init((ICipherParameters) new KeyParameter(counterParameters.Ki));
    this.fixedInputDataCtrPrefix = counterParameters.FixedInputDataCounterPrefix;
    this.fixedInputData_afterCtr = counterParameters.FixedInputDataCounterSuffix;
    int r = counterParameters.R;
    this.ios = new byte[r / 8];
    BigInteger bigInteger = BigInteger.One.ShiftLeft(r).Multiply(BigInteger.ValueOf((long) this.h));
    this.maxSizeExcl = bigInteger.BitLength > 31 /*0x1F*/ ? int.MaxValue : bigInteger.IntValueExact;
    this.generatedBytes = 0;
  }

  public IMac Mac => this.prf;

  public IDigest Digest => !(this.prf is HMac prf) ? (IDigest) null : prf.GetUnderlyingDigest();

  public int GenerateBytes(byte[] output, int outOff, int length)
  {
    if (this.generatedBytes >= this.maxSizeExcl - length)
      throw new DataLengthException($"Current KDFCTR may only be used for {this.maxSizeExcl.ToString()} bytes");
    int val2 = length;
    int sourceIndex = this.generatedBytes % this.h;
    if (sourceIndex != 0)
    {
      int length1 = System.Math.Min(this.h - sourceIndex, val2);
      Array.Copy((Array) this.k, sourceIndex, (Array) output, outOff, length1);
      this.generatedBytes += length1;
      val2 -= length1;
      outOff += length1;
    }
    while (val2 > 0)
    {
      this.GenerateNext();
      int length2 = System.Math.Min(this.h, val2);
      Array.Copy((Array) this.k, 0, (Array) output, outOff, length2);
      this.generatedBytes += length2;
      val2 -= length2;
      outOff += length2;
    }
    return length;
  }

  private void GenerateNext()
  {
    int num = this.generatedBytes / this.h + 1;
    switch (this.ios.Length)
    {
      case 1:
        this.ios[this.ios.Length - 1] = (byte) num;
        this.prf.BlockUpdate(this.fixedInputDataCtrPrefix, 0, this.fixedInputDataCtrPrefix.Length);
        this.prf.BlockUpdate(this.ios, 0, this.ios.Length);
        this.prf.BlockUpdate(this.fixedInputData_afterCtr, 0, this.fixedInputData_afterCtr.Length);
        this.prf.DoFinal(this.k, 0);
        break;
      case 2:
        this.ios[this.ios.Length - 2] = (byte) (num >> 8);
        goto case 1;
      case 3:
        this.ios[this.ios.Length - 3] = (byte) (num >> 16 /*0x10*/);
        goto case 2;
      case 4:
        this.ios[0] = (byte) (num >> 24);
        goto case 3;
      default:
        throw new InvalidOperationException("Unsupported size of counter i");
    }
  }
}
