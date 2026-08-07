// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.KdfDoublePipelineIterationBytesGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public sealed class KdfDoublePipelineIterationBytesGenerator : 
  IMacDerivationFunction,
  IDerivationFunction
{
  private readonly IMac prf;
  private readonly int h;
  private byte[] fixedInputData;
  private int maxSizeExcl;
  private byte[] ios;
  private bool useCounter;
  private int generatedBytes;
  private byte[] a;
  private byte[] k;

  public KdfDoublePipelineIterationBytesGenerator(IMac prf)
  {
    this.prf = prf;
    this.h = prf.GetMacSize();
    this.a = new byte[this.h];
    this.k = new byte[this.h];
  }

  public void Init(IDerivationParameters parameters)
  {
    if (!(parameters is KdfDoublePipelineIterationParameters iterationParameters))
      throw new ArgumentException("Wrong type of arguments given");
    this.prf.Init((ICipherParameters) new KeyParameter(iterationParameters.Ki));
    this.fixedInputData = iterationParameters.FixedInputData;
    int r = iterationParameters.R;
    this.ios = new byte[r / 8];
    if (iterationParameters.UseCounter)
    {
      BigInteger bigInteger = BigInteger.One.ShiftLeft(r).Multiply(BigInteger.ValueOf((long) this.h));
      this.maxSizeExcl = bigInteger.BitLength > 31 /*0x1F*/ ? int.MaxValue : bigInteger.IntValueExact;
    }
    else
      this.maxSizeExcl = int.MaxValue;
    this.useCounter = iterationParameters.UseCounter;
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
    if (this.generatedBytes == 0)
    {
      this.prf.BlockUpdate(this.fixedInputData, 0, this.fixedInputData.Length);
      this.prf.DoFinal(this.a, 0);
    }
    else
    {
      this.prf.BlockUpdate(this.a, 0, this.a.Length);
      this.prf.DoFinal(this.a, 0);
    }
    this.prf.BlockUpdate(this.a, 0, this.a.Length);
    if (this.useCounter)
    {
      int num = this.generatedBytes / this.h + 1;
      switch (this.ios.Length)
      {
        case 1:
          this.ios[this.ios.Length - 1] = (byte) num;
          this.prf.BlockUpdate(this.ios, 0, this.ios.Length);
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
    this.prf.BlockUpdate(this.fixedInputData, 0, this.fixedInputData.Length);
    this.prf.DoFinal(this.k, 0);
  }
}
