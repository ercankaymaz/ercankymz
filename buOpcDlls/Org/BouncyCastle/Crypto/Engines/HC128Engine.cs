// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.HC128Engine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class HC128Engine : IStreamCipher
{
  private uint[] p = new uint[512 /*0x0200*/];
  private uint[] q = new uint[512 /*0x0200*/];
  private uint cnt;
  private byte[] key;
  private byte[] iv;
  private bool initialised;
  private byte[] buf = new byte[4];
  private int idx;

  private static uint F1(uint x)
  {
    return HC128Engine.RotateRight(x, 7) ^ HC128Engine.RotateRight(x, 18) ^ x >> 3;
  }

  private static uint F2(uint x)
  {
    return HC128Engine.RotateRight(x, 17) ^ HC128Engine.RotateRight(x, 19) ^ x >> 10;
  }

  private uint G1(uint x, uint y, uint z)
  {
    return (HC128Engine.RotateRight(x, 10) ^ HC128Engine.RotateRight(z, 23)) + HC128Engine.RotateRight(y, 8);
  }

  private uint G2(uint x, uint y, uint z)
  {
    return (HC128Engine.RotateLeft(x, 10) ^ HC128Engine.RotateLeft(z, 23)) + HC128Engine.RotateLeft(y, 8);
  }

  private static uint RotateLeft(uint x, int bits) => x << bits | x >> -bits;

  private static uint RotateRight(uint x, int bits) => x >> bits | x << -bits;

  private uint H1(uint x)
  {
    return this.q[(int) x & (int) byte.MaxValue] + this.q[((int) (x >> 16 /*0x10*/) & (int) byte.MaxValue) + 256 /*0x0100*/];
  }

  private uint H2(uint x)
  {
    return this.p[(int) x & (int) byte.MaxValue] + this.p[((int) (x >> 16 /*0x10*/) & (int) byte.MaxValue) + 256 /*0x0100*/];
  }

  private static uint Mod1024(uint x) => x & 1023U /*0x03FF*/;

  private static uint Mod512(uint x) => x & 511U /*0x01FF*/;

  private static uint Dim(uint x, uint y) => HC128Engine.Mod512(x - y);

  private uint Step()
  {
    uint x = HC128Engine.Mod512(this.cnt);
    uint num;
    if (this.cnt < 512U /*0x0200*/)
    {
      this.p[(int) x] += this.G1(this.p[(int) HC128Engine.Dim(x, 3U)], this.p[(int) HC128Engine.Dim(x, 10U)], this.p[(int) HC128Engine.Dim(x, 511U /*0x01FF*/)]);
      num = this.H1(this.p[(int) HC128Engine.Dim(x, 12U)]) ^ this.p[(int) x];
    }
    else
    {
      this.q[(int) x] += this.G2(this.q[(int) HC128Engine.Dim(x, 3U)], this.q[(int) HC128Engine.Dim(x, 10U)], this.q[(int) HC128Engine.Dim(x, 511U /*0x01FF*/)]);
      num = this.H2(this.q[(int) HC128Engine.Dim(x, 12U)]) ^ this.q[(int) x];
    }
    this.cnt = HC128Engine.Mod1024(this.cnt + 1U);
    return num;
  }

  private void Init()
  {
    if (this.key.Length != 16 /*0x10*/)
      throw new ArgumentException("The key must be 128 bits long");
    this.idx = 0;
    this.cnt = 0U;
    uint[] numArray = new uint[1280 /*0x0500*/];
    for (int index = 0; index < 16 /*0x10*/; ++index)
      numArray[index >> 2] |= (uint) this.key[index] << 8 * (index & 3);
    Array.Copy((Array) numArray, 0, (Array) numArray, 4, 4);
    for (int index = 0; index < this.iv.Length && index < 16 /*0x10*/; ++index)
      numArray[(index >> 2) + 8] |= (uint) this.iv[index] << 8 * (index & 3);
    Array.Copy((Array) numArray, 8, (Array) numArray, 12, 4);
    for (uint index = 16 /*0x10*/; index < 1280U /*0x0500*/; ++index)
      numArray[(int) index] = HC128Engine.F2(numArray[(int) index - 2]) + numArray[(int) index - 7] + HC128Engine.F1(numArray[(int) index - 15]) + numArray[(int) index - 16 /*0x10*/] + index;
    Array.Copy((Array) numArray, 256 /*0x0100*/, (Array) this.p, 0, 512 /*0x0200*/);
    Array.Copy((Array) numArray, 768 /*0x0300*/, (Array) this.q, 0, 512 /*0x0200*/);
    for (int index = 0; index < 512 /*0x0200*/; ++index)
      this.p[index] = this.Step();
    for (int index = 0; index < 512 /*0x0200*/; ++index)
      this.q[index] = this.Step();
    this.cnt = 0U;
  }

  public virtual string AlgorithmName => "HC-128";

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
    this.key = cipherParameters is KeyParameter ? ((KeyParameter) cipherParameters).GetKey() : throw new ArgumentException("Invalid parameter passed to HC128 init - " + Platform.GetTypeName((object) parameters), nameof (parameters));
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
}
