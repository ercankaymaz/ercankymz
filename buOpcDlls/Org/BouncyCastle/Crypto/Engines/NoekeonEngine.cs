// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.NoekeonEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class NoekeonEngine : IBlockCipher
{
  private const int Size = 16 /*0x10*/;
  private static readonly byte[] RoundConstants = new byte[17]
  {
    (byte) 128 /*0x80*/,
    (byte) 27,
    (byte) 54,
    (byte) 108,
    (byte) 216,
    (byte) 171,
    (byte) 77,
    (byte) 154,
    (byte) 47,
    (byte) 94,
    (byte) 188,
    (byte) 99,
    (byte) 198,
    (byte) 151,
    (byte) 53,
    (byte) 106,
    (byte) 212
  };
  private readonly uint[] k = new uint[4];
  private bool _initialised;
  private bool _forEncryption;

  public NoekeonEngine() => this._initialised = false;

  public virtual string AlgorithmName => "Noekeon";

  public virtual int GetBlockSize() => 16 /*0x10*/;

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    byte[] bs = parameters is KeyParameter ? ((KeyParameter) parameters).GetKey() : throw new ArgumentException("Invalid parameters passed to Noekeon init - " + Platform.GetTypeName((object) parameters), nameof (parameters));
    if (bs.Length != 16 /*0x10*/)
      throw new ArgumentException("Key length not 128 bits.");
    Pack.BE_To_UInt32(bs, 0, this.k, 0, 4);
    if (!forEncryption)
    {
      uint num1 = this.k[0];
      uint num2 = this.k[1];
      uint num3 = this.k[2];
      uint num4 = this.k[3];
      uint i1 = num1 ^ num3;
      uint num5 = i1 ^ Integers.RotateLeft(i1, 8) ^ Integers.RotateLeft(i1, 24);
      uint i2 = num2 ^ num4;
      uint num6 = i2 ^ Integers.RotateLeft(i2, 8) ^ Integers.RotateLeft(i2, 24);
      uint num7 = num1 ^ num6;
      uint num8 = num2 ^ num5;
      uint num9 = num3 ^ num6;
      uint num10 = num4 ^ num5;
      this.k[0] = num7;
      this.k[1] = num8;
      this.k[2] = num9;
      this.k[3] = num10;
    }
    this._forEncryption = forEncryption;
    this._initialised = true;
  }

  public virtual int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    if (!this._initialised)
      throw new InvalidOperationException(this.AlgorithmName + " not initialised");
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, 16 /*0x10*/, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, 16 /*0x10*/, "output buffer too short");
    return !this._forEncryption ? this.DecryptBlock(input, inOff, output, outOff) : this.EncryptBlock(input, inOff, output, outOff);
  }

  private int EncryptBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    uint num1 = Pack.BE_To_UInt32(input, inOff);
    uint num2 = Pack.BE_To_UInt32(input, inOff + 4);
    uint num3 = Pack.BE_To_UInt32(input, inOff + 8);
    uint num4 = Pack.BE_To_UInt32(input, inOff + 12);
    uint num5 = this.k[0];
    uint num6 = this.k[1];
    uint num7 = this.k[2];
    uint num8 = this.k[3];
    int index = 0;
    uint num9;
    uint num10;
    uint num11;
    uint n;
    while (true)
    {
      uint num12 = num1 ^ (uint) NoekeonEngine.RoundConstants[index];
      uint i1 = num12 ^ num3;
      uint num13 = i1 ^ Integers.RotateLeft(i1, 8) ^ Integers.RotateLeft(i1, 24);
      uint num14 = num12 ^ num5;
      uint num15 = num2 ^ num6;
      uint num16 = num3 ^ num7;
      uint num17 = num4 ^ num8;
      uint i2 = num15 ^ num17;
      uint num18 = i2 ^ Integers.RotateLeft(i2, 8) ^ Integers.RotateLeft(i2, 24);
      n = num14 ^ num18;
      num9 = num15 ^ num13;
      num10 = num16 ^ num18;
      num11 = num17 ^ num13;
      if (++index <= 16 /*0x10*/)
      {
        uint num19 = Integers.RotateLeft(num9, 1);
        uint num20 = Integers.RotateLeft(num10, 5);
        uint num21 = Integers.RotateLeft(num11, 2);
        int num22 = (int) num21;
        uint num23 = num19 ^ (num21 | num20);
        uint i3 = n ^ num20 & ~num23;
        uint i4 = (uint) (num22 ^ ~(int) num23) ^ num20 ^ i3;
        uint i5 = num23 ^ (i3 | i4);
        num1 = (uint) (num22 ^ (int) i4 & (int) i5);
        num2 = Integers.RotateLeft(i5, 31 /*0x1F*/);
        num3 = Integers.RotateLeft(i4, 27);
        num4 = Integers.RotateLeft(i3, 30);
      }
      else
        break;
    }
    Pack.UInt32_To_BE(n, output, outOff);
    Pack.UInt32_To_BE(num9, output, outOff + 4);
    Pack.UInt32_To_BE(num10, output, outOff + 8);
    Pack.UInt32_To_BE(num11, output, outOff + 12);
    return 16 /*0x10*/;
  }

  private int DecryptBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    uint num1 = Pack.BE_To_UInt32(input, inOff);
    uint num2 = Pack.BE_To_UInt32(input, inOff + 4);
    uint num3 = Pack.BE_To_UInt32(input, inOff + 8);
    uint num4 = Pack.BE_To_UInt32(input, inOff + 12);
    uint num5 = this.k[0];
    uint num6 = this.k[1];
    uint num7 = this.k[2];
    uint num8 = this.k[3];
    int index = 16 /*0x10*/;
    uint num9;
    uint num10;
    uint num11;
    uint n;
    while (true)
    {
      uint i1 = num1 ^ num3;
      uint num12 = i1 ^ Integers.RotateLeft(i1, 8) ^ Integers.RotateLeft(i1, 24);
      uint num13 = num1 ^ num5;
      uint num14 = num2 ^ num6;
      uint num15 = num3 ^ num7;
      uint num16 = num4 ^ num8;
      uint i2 = num14 ^ num16;
      uint num17 = i2 ^ Integers.RotateLeft(i2, 8) ^ Integers.RotateLeft(i2, 24);
      uint num18 = num13 ^ num17;
      num9 = num14 ^ num12;
      num10 = num15 ^ num17;
      num11 = num16 ^ num12;
      n = num18 ^ (uint) NoekeonEngine.RoundConstants[index];
      if (--index >= 0)
      {
        uint num19 = Integers.RotateLeft(num9, 1);
        uint num20 = Integers.RotateLeft(num10, 5);
        uint num21 = Integers.RotateLeft(num11, 2);
        int num22 = (int) num21;
        uint num23 = num19 ^ (num21 | num20);
        uint i3 = n ^ num20 & ~num23;
        uint i4 = (uint) (num22 ^ ~(int) num23) ^ num20 ^ i3;
        uint i5 = num23 ^ (i3 | i4);
        num1 = (uint) (num22 ^ (int) i4 & (int) i5);
        num2 = Integers.RotateLeft(i5, 31 /*0x1F*/);
        num3 = Integers.RotateLeft(i4, 27);
        num4 = Integers.RotateLeft(i3, 30);
      }
      else
        break;
    }
    Pack.UInt32_To_BE(n, output, outOff);
    Pack.UInt32_To_BE(num9, output, outOff + 4);
    Pack.UInt32_To_BE(num10, output, outOff + 8);
    Pack.UInt32_To_BE(num11, output, outOff + 12);
    return 16 /*0x10*/;
  }
}
