// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.HC256Engine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class HC256Engine : IStreamCipher
{
  private uint[] p = new uint[1024 /*0x0400*/];
  private uint[] q = new uint[1024 /*0x0400*/];
  private uint cnt;
  private byte[] key;
  private byte[] iv;
  private bool initialised;
  private byte[] buf = new byte[4];
  private int idx;

  private uint Step()
  {
    uint index = this.cnt & 1023U /*0x03FF*/;
    uint num1;
    if (this.cnt < 1024U /*0x0400*/)
    {
      uint x1 = this.p[(int) index - 3 & 1023 /*0x03FF*/];
      uint x2 = this.p[(int) index - 1023 /*0x03FF*/ & 1023 /*0x03FF*/];
      this.p[(int) index] += this.p[(int) index - 10 & 1023 /*0x03FF*/] + (HC256Engine.RotateRight(x1, 10) ^ HC256Engine.RotateRight(x2, 23)) + this.q[((int) x1 ^ (int) x2) & 1023 /*0x03FF*/];
      uint num2 = this.p[(int) index - 12 & 1023 /*0x03FF*/];
      num1 = this.q[(int) num2 & (int) byte.MaxValue] + this.q[((int) (num2 >> 8) & (int) byte.MaxValue) + 256 /*0x0100*/] + this.q[((int) (num2 >> 16 /*0x10*/) & (int) byte.MaxValue) + 512 /*0x0200*/] + this.q[((int) (num2 >> 24) & (int) byte.MaxValue) + 768 /*0x0300*/] ^ this.p[(int) index];
    }
    else
    {
      uint x3 = this.q[(int) index - 3 & 1023 /*0x03FF*/];
      uint x4 = this.q[(int) index - 1023 /*0x03FF*/ & 1023 /*0x03FF*/];
      this.q[(int) index] += this.q[(int) index - 10 & 1023 /*0x03FF*/] + (HC256Engine.RotateRight(x3, 10) ^ HC256Engine.RotateRight(x4, 23)) + this.p[((int) x3 ^ (int) x4) & 1023 /*0x03FF*/];
      uint num3 = this.q[(int) index - 12 & 1023 /*0x03FF*/];
      num1 = this.p[(int) num3 & (int) byte.MaxValue] + this.p[((int) (num3 >> 8) & (int) byte.MaxValue) + 256 /*0x0100*/] + this.p[((int) (num3 >> 16 /*0x10*/) & (int) byte.MaxValue) + 512 /*0x0200*/] + this.p[((int) (num3 >> 24) & (int) byte.MaxValue) + 768 /*0x0300*/] ^ this.q[(int) index];
    }
    this.cnt = (uint) ((int) this.cnt + 1 & 2047 /*0x07FF*/);
    return num1;
  }

  private void Init()
  {
    if (this.key.Length != 32 /*0x20*/ && this.key.Length != 16 /*0x10*/)
      throw new ArgumentException("The key must be 128/256 bits long");
    if (this.iv.Length < 16 /*0x10*/)
      throw new ArgumentException("The IV must be at least 128 bits long");
    if (this.key.Length != 32 /*0x20*/)
    {
      byte[] destinationArray = new byte[32 /*0x20*/];
      Array.Copy((Array) this.key, 0, (Array) destinationArray, 0, this.key.Length);
      Array.Copy((Array) this.key, 0, (Array) destinationArray, 16 /*0x10*/, this.key.Length);
      this.key = destinationArray;
    }
    if (this.iv.Length < 32 /*0x20*/)
    {
      byte[] destinationArray = new byte[32 /*0x20*/];
      Array.Copy((Array) this.iv, 0, (Array) destinationArray, 0, this.iv.Length);
      Array.Copy((Array) this.iv, 0, (Array) destinationArray, this.iv.Length, destinationArray.Length - this.iv.Length);
      this.iv = destinationArray;
    }
    this.idx = 0;
    this.cnt = 0U;
    uint[] sourceArray = new uint[2560 /*0x0A00*/];
    for (int index = 0; index < 32 /*0x20*/; ++index)
      sourceArray[index >> 2] |= (uint) this.key[index] << 8 * (index & 3);
    for (int index = 0; index < 32 /*0x20*/; ++index)
      sourceArray[(index >> 2) + 8] |= (uint) this.iv[index] << 8 * (index & 3);
    for (uint index = 16 /*0x10*/; index < 2560U /*0x0A00*/; ++index)
    {
      uint x1 = sourceArray[(int) index - 2];
      uint x2 = sourceArray[(int) index - 15];
      sourceArray[(int) index] = (uint) (((int) HC256Engine.RotateRight(x1, 17) ^ (int) HC256Engine.RotateRight(x1, 19) ^ (int) (x1 >> 10)) + (int) sourceArray[(int) index - 7] + ((int) HC256Engine.RotateRight(x2, 7) ^ (int) HC256Engine.RotateRight(x2, 18) ^ (int) (x2 >> 3))) + sourceArray[(int) index - 16 /*0x10*/] + index;
    }
    Array.Copy((Array) sourceArray, 512 /*0x0200*/, (Array) this.p, 0, 1024 /*0x0400*/);
    Array.Copy((Array) sourceArray, 1536 /*0x0600*/, (Array) this.q, 0, 1024 /*0x0400*/);
    for (int index = 0; index < 4096 /*0x1000*/; ++index)
    {
      int num = (int) this.Step();
    }
    this.cnt = 0U;
  }

  public virtual string AlgorithmName => "HC-256";

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    ICipherParameters cipherParameters = parameters;
    if (parameters is ParametersWithIV)
    {
      this.iv = ((ParametersWithIV) parameters).GetIV();
      cipherParameters = ((ParametersWithIV) parameters).Parameters;
    }
    else
      this.iv = new byte[0];
    this.key = cipherParameters is KeyParameter ? ((KeyParameter) cipherParameters).GetKey() : throw new ArgumentException("Invalid parameter passed to HC256 init - " + Platform.GetTypeName((object) parameters), nameof (parameters));
    this.Init();
    this.initialised = true;
  }

  private byte GetByte()
  {
    if (this.idx == 0)
      Pack.UInt32_To_LE(this.Step(), this.buf);
    int num = (int) this.buf[this.idx];
    this.idx = this.idx + 1 & 3;
    return (byte) num;
  }

  public virtual void ProcessBytes(byte[] input, int inOff, int len, byte[] output, int outOff)
  {
    if (!this.initialised)
      throw new InvalidOperationException(this.AlgorithmName + " not initialised");
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, len, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, len, "output buffer too short");
    for (int index = 0; index < len; ++index)
      output[outOff + index] = (byte) ((uint) input[inOff + index] ^ (uint) this.GetByte());
  }

  public virtual void Reset() => this.Init();

  public virtual byte ReturnByte(byte input) => (byte) ((uint) input ^ (uint) this.GetByte());

  private static uint RotateRight(uint x, int bits) => x >> bits | x << -bits;
}
