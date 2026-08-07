// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.TupleHash
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public class TupleHash : IXof, IDigest
{
  private static readonly byte[] N_TUPLE_HASH = Strings.ToByteArray(nameof (TupleHash));
  private readonly CShakeDigest cshake;
  private readonly int bitLength;
  private readonly int outputLength;
  private bool firstOutput;

  public TupleHash(int bitLength, byte[] S)
    : this(bitLength, S, bitLength * 2)
  {
  }

  public TupleHash(int bitLength, byte[] S, int outputSize)
  {
    this.cshake = new CShakeDigest(bitLength, TupleHash.N_TUPLE_HASH, S);
    this.bitLength = bitLength;
    this.outputLength = (outputSize + 7) / 8;
    this.Reset();
  }

  public TupleHash(TupleHash original)
  {
    this.cshake = new CShakeDigest(original.cshake);
    this.bitLength = this.cshake.fixedOutputLength;
    this.outputLength = this.bitLength * 2 / 8;
    this.firstOutput = original.firstOutput;
  }

  public virtual string AlgorithmName
  {
    get => nameof (TupleHash) + this.cshake.AlgorithmName.Substring(6);
  }

  public virtual int GetByteLength() => this.cshake.GetByteLength();

  public virtual int GetDigestSize() => this.outputLength;

  public virtual void Update(byte b)
  {
    byte[] input = XofUtilities.Encode(b);
    this.cshake.BlockUpdate(input, 0, input.Length);
  }

  public virtual void BlockUpdate(byte[] inBuf, int inOff, int len)
  {
    byte[] input = XofUtilities.Encode(inBuf, inOff, len);
    this.cshake.BlockUpdate(input, 0, input.Length);
  }

  private void WrapUp(int outputSize)
  {
    byte[] input = XofUtilities.RightEncode((long) (outputSize * 8));
    this.cshake.BlockUpdate(input, 0, input.Length);
    this.firstOutput = false;
  }

  public virtual int DoFinal(byte[] outBuf, int outOff)
  {
    return this.OutputFinal(outBuf, outOff, this.GetDigestSize());
  }

  public virtual int OutputFinal(byte[] outBuf, int outOff, int outLen)
  {
    if (this.firstOutput)
      this.WrapUp(this.GetDigestSize());
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
    this.firstOutput = true;
  }
}
