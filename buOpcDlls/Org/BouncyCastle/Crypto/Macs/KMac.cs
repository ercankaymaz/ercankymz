// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Macs.KMac
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Macs;

public class KMac : IMac, IXof, IDigest
{
  private static readonly byte[] padding = new byte[100];
  private readonly CShakeDigest cshake;
  private readonly int bitLength;
  private readonly int outputLength;
  private byte[] key;
  private bool initialised;
  private bool firstOutput;

  public KMac(int bitLength, byte[] S)
  {
    this.cshake = new CShakeDigest(bitLength, Strings.ToAsciiByteArray("KMAC"), S);
    this.bitLength = bitLength;
    this.outputLength = bitLength * 2 / 8;
  }

  public string AlgorithmName => "KMAC" + this.cshake.AlgorithmName.Substring(6);

  public void BlockUpdate(byte[] input, int inOff, int len)
  {
    if (!this.initialised)
      throw new InvalidOperationException("KMAC not initialized");
    this.cshake.BlockUpdate(input, inOff, len);
  }

  public int DoFinal(byte[] output, int outOff)
  {
    if (this.firstOutput)
    {
      if (!this.initialised)
        throw new InvalidOperationException("KMAC not initialized");
      byte[] input = XofUtilities.RightEncode((long) (this.GetMacSize() * 8));
      this.cshake.BlockUpdate(input, 0, input.Length);
    }
    int num = this.cshake.OutputFinal(output, outOff, this.GetMacSize());
    this.Reset();
    return num;
  }

  public int OutputFinal(byte[] output, int outOff, int outLen)
  {
    if (this.firstOutput)
    {
      if (!this.initialised)
        throw new InvalidOperationException("KMAC not initialized");
      byte[] input = XofUtilities.RightEncode((long) (outLen * 8));
      this.cshake.BlockUpdate(input, 0, input.Length);
    }
    int num = this.cshake.OutputFinal(output, outOff, outLen);
    this.Reset();
    return num;
  }

  public int Output(byte[] output, int outOff, int outLen)
  {
    if (this.firstOutput)
    {
      if (!this.initialised)
        throw new InvalidOperationException("KMAC not initialized");
      byte[] input = XofUtilities.RightEncode(0L);
      this.cshake.BlockUpdate(input, 0, input.Length);
      this.firstOutput = false;
    }
    return this.cshake.Output(output, outOff, outLen);
  }

  public int GetByteLength() => this.cshake.GetByteLength();

  public int GetDigestSize() => this.outputLength;

  public int GetMacSize() => this.outputLength;

  public void Init(ICipherParameters parameters)
  {
    this.key = Arrays.Clone(((KeyParameter) parameters).GetKey());
    this.initialised = true;
    this.Reset();
  }

  public void Reset()
  {
    this.cshake.Reset();
    if (this.key != null)
    {
      if (this.bitLength == 128 /*0x80*/)
        this.bytePad(this.key, 168);
      else
        this.bytePad(this.key, 136);
    }
    this.firstOutput = true;
  }

  private void bytePad(byte[] X, int w)
  {
    byte[] input1 = XofUtilities.LeftEncode((long) w);
    this.BlockUpdate(input1, 0, input1.Length);
    byte[] input2 = KMac.encode(X);
    this.BlockUpdate(input2, 0, input2.Length);
    int len = w - (input1.Length + input2.Length) % w;
    if (len <= 0 || len == w)
      return;
    for (; len > KMac.padding.Length; len -= KMac.padding.Length)
      this.BlockUpdate(KMac.padding, 0, KMac.padding.Length);
    this.BlockUpdate(KMac.padding, 0, len);
  }

  private static byte[] encode(byte[] X)
  {
    return Arrays.Concatenate(XofUtilities.LeftEncode((long) (X.Length * 8)), X);
  }

  public void Update(byte input)
  {
    if (!this.initialised)
      throw new InvalidOperationException("KMAC not initialized");
    this.cshake.Update(input);
  }
}
