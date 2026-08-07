// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.ParallelHash
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public class ParallelHash : IXof, IDigest
{
  private static readonly byte[] N_PARALLEL_HASH = Strings.ToByteArray(nameof (ParallelHash));
  private readonly CShakeDigest cshake;
  private readonly CShakeDigest compressor;
  private readonly int bitLength;
  private readonly int outputLength;
  private readonly int B;
  private readonly byte[] buffer;
  private readonly byte[] compressorBuffer;
  private bool firstOutput;
  private int nCount;
  private int bufOff;

  public ParallelHash(int bitLength, byte[] S, int B)
    : this(bitLength, S, B, bitLength * 2)
  {
  }

  public ParallelHash(int bitLength, byte[] S, int B, int outputSize)
  {
    this.cshake = new CShakeDigest(bitLength, ParallelHash.N_PARALLEL_HASH, S);
    this.compressor = new CShakeDigest(bitLength, new byte[0], new byte[0]);
    this.bitLength = bitLength;
    this.B = B;
    this.outputLength = (outputSize + 7) / 8;
    this.buffer = new byte[B];
    this.compressorBuffer = new byte[bitLength * 2 / 8];
    this.Reset();
  }

  public ParallelHash(ParallelHash source)
  {
    this.cshake = new CShakeDigest(source.cshake);
    this.compressor = new CShakeDigest(source.compressor);
    this.bitLength = source.bitLength;
    this.B = source.B;
    this.outputLength = source.outputLength;
    this.buffer = Arrays.Clone(source.buffer);
    this.compressorBuffer = Arrays.Clone(source.compressorBuffer);
    this.firstOutput = source.firstOutput;
    this.nCount = source.nCount;
    this.bufOff = source.bufOff;
  }

  public virtual string AlgorithmName
  {
    get => nameof (ParallelHash) + this.cshake.AlgorithmName.Substring(6);
  }

  public virtual int GetByteLength() => this.cshake.GetByteLength();

  public virtual int GetDigestSize() => this.outputLength;

  public virtual void Update(byte b)
  {
    this.buffer[this.bufOff++] = b;
    if (this.bufOff != this.buffer.Length)
      return;
    this.Compress();
  }

  public virtual void BlockUpdate(byte[] inBuf, int inOff, int len)
  {
    len = Math.Max(0, len);
    int num = 0;
    if (this.bufOff != 0)
    {
      while (num < len && this.bufOff != this.buffer.Length)
        this.buffer[this.bufOff++] = inBuf[inOff + num++];
      if (this.bufOff == this.buffer.Length)
        this.Compress();
    }
    if (num < len)
    {
      for (; len - num >= this.B; num += this.B)
        this.Compress(inBuf, inOff + num, this.B);
    }
    while (num < len)
      this.Update(inBuf[inOff + num++]);
  }

  private void Compress()
  {
    this.Compress(this.buffer, 0, this.bufOff);
    this.bufOff = 0;
  }

  private void Compress(byte[] buf, int offSet, int len)
  {
    this.compressor.BlockUpdate(buf, offSet, len);
    this.compressor.OutputFinal(this.compressorBuffer, 0, this.compressorBuffer.Length);
    this.cshake.BlockUpdate(this.compressorBuffer, 0, this.compressorBuffer.Length);
    ++this.nCount;
  }

  private void WrapUp(int outputSize)
  {
    if (this.bufOff != 0)
      this.Compress();
    byte[] input1 = XofUtilities.RightEncode((long) this.nCount);
    byte[] input2 = XofUtilities.RightEncode((long) (outputSize * 8));
    this.cshake.BlockUpdate(input1, 0, input1.Length);
    this.cshake.BlockUpdate(input2, 0, input2.Length);
    this.firstOutput = false;
  }

  public virtual int DoFinal(byte[] outBuf, int outOff)
  {
    if (this.firstOutput)
      this.WrapUp(this.outputLength);
    int num = this.cshake.DoFinal(outBuf, outOff);
    this.Reset();
    return num;
  }

  public virtual int OutputFinal(byte[] outBuf, int outOff, int outLen)
  {
    if (this.firstOutput)
      this.WrapUp(this.outputLength);
    int num = this.cshake.OutputFinal(outBuf, outOff, outLen);
    this.Reset();
    return num;
  }

  public virtual int Output(byte[] outBuf, int outOff, int outLen)
  {
    if (this.firstOutput)
      this.WrapUp(0);
    return this.cshake.Output(outBuf, outOff, outLen);
  }

  public virtual void Reset()
  {
    this.cshake.Reset();
    Arrays.Clear(this.buffer);
    byte[] input = XofUtilities.LeftEncode((long) this.B);
    this.cshake.BlockUpdate(input, 0, input.Length);
    this.nCount = 0;
    this.bufOff = 0;
    this.firstOutput = true;
  }
}
