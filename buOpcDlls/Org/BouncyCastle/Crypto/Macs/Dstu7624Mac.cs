// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Macs.Dstu7624Mac
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Macs;

public class Dstu7624Mac : IMac
{
  private int macSize;
  private Dstu7624Engine engine;
  private int blockSize;
  private byte[] c;
  private byte[] cTemp;
  private byte[] kDelta;
  private byte[] buf;
  private int bufOff;

  public Dstu7624Mac(int blockSizeBits, int q)
  {
    this.engine = new Dstu7624Engine(blockSizeBits);
    this.blockSize = blockSizeBits / 8;
    this.macSize = q / 8;
    this.c = new byte[this.blockSize];
    this.cTemp = new byte[this.blockSize];
    this.kDelta = new byte[this.blockSize];
    this.buf = new byte[this.blockSize];
  }

  public void Init(ICipherParameters parameters)
  {
    if (!(parameters is KeyParameter))
      throw new ArgumentException("invalid parameter passed to Dstu7624Mac init - " + Platform.GetTypeName((object) parameters));
    this.engine.Init(true, parameters);
    this.engine.ProcessBlock(this.kDelta, 0, this.kDelta, 0);
  }

  public string AlgorithmName => nameof (Dstu7624Mac);

  public int GetMacSize() => this.macSize;

  public void Update(byte input)
  {
    if (this.bufOff == this.buf.Length)
    {
      this.ProcessBlock(this.buf, 0);
      this.bufOff = 0;
    }
    this.buf[this.bufOff++] = input;
  }

  public void BlockUpdate(byte[] input, int inOff, int len)
  {
    if (len < 0)
      throw new ArgumentException("Can't have a negative input length!");
    int blockSize = this.engine.GetBlockSize();
    int length = blockSize - this.bufOff;
    if (len > length)
    {
      Array.Copy((Array) input, inOff, (Array) this.buf, this.bufOff, length);
      this.ProcessBlock(this.buf, 0);
      this.bufOff = 0;
      len -= length;
      inOff += length;
      while (len > blockSize)
      {
        this.ProcessBlock(input, inOff);
        len -= blockSize;
        inOff += blockSize;
      }
    }
    Array.Copy((Array) input, inOff, (Array) this.buf, this.bufOff, len);
    this.bufOff += len;
  }

  private void ProcessBlock(byte[] input, int inOff)
  {
    this.Xor(this.c, 0, input, inOff, this.cTemp);
    this.engine.ProcessBlock(this.cTemp, 0, this.c, 0);
  }

  private void Xor(byte[] c, int cOff, byte[] input, int inOff, byte[] xorResult)
  {
    for (int index = 0; index < this.blockSize; ++index)
      xorResult[index] = (byte) ((uint) c[index + cOff] ^ (uint) input[index + inOff]);
  }

  public int DoFinal(byte[] output, int outOff)
  {
    if (this.bufOff % this.buf.Length != 0)
      throw new DataLengthException("Input must be a multiple of blocksize");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, this.macSize, "output buffer too short");
    this.Xor(this.c, 0, this.buf, 0, this.cTemp);
    this.Xor(this.cTemp, 0, this.kDelta, 0, this.c);
    this.engine.ProcessBlock(this.c, 0, this.c, 0);
    Array.Copy((Array) this.c, 0, (Array) output, outOff, this.macSize);
    return this.macSize;
  }

  public void Reset()
  {
    Arrays.Fill(this.c, (byte) 0);
    Arrays.Fill(this.cTemp, (byte) 0);
    Arrays.Fill(this.kDelta, (byte) 0);
    Arrays.Fill(this.buf, (byte) 0);
    this.engine.ProcessBlock(this.kDelta, 0, this.kDelta, 0);
    this.bufOff = 0;
  }
}
