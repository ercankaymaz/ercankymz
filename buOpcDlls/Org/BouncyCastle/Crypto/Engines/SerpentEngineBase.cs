// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.SerpentEngineBase
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public abstract class SerpentEngineBase : IBlockCipher
{
  protected static readonly int BlockSize = 16 /*0x10*/;
  internal const int ROUNDS = 32 /*0x20*/;
  internal const int PHI = -1640531527;
  protected bool encrypting;
  protected int[] wKey;
  protected int X0;
  protected int X1;
  protected int X2;
  protected int X3;

  internal SerpentEngineBase()
  {
  }

  public virtual void Init(bool encrypting, ICipherParameters parameters)
  {
    if (!(parameters is KeyParameter))
      throw new ArgumentException($"invalid parameter passed to {this.AlgorithmName} init - {Platform.GetTypeName((object) parameters)}");
    this.encrypting = encrypting;
    this.wKey = this.MakeWorkingKey(((KeyParameter) parameters).GetKey());
  }

  public virtual string AlgorithmName => "Serpent";

  public virtual int GetBlockSize() => SerpentEngineBase.BlockSize;

  public int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    if (this.wKey == null)
      throw new InvalidOperationException(this.AlgorithmName + " not initialised");
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, SerpentEngineBase.BlockSize, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, SerpentEngineBase.BlockSize, "output buffer too short");
    if (this.encrypting)
      this.EncryptBlock(input, inOff, output, outOff);
    else
      this.DecryptBlock(input, inOff, output, outOff);
    return SerpentEngineBase.BlockSize;
  }

  protected void Sb0(int a, int b, int c, int d)
  {
    int num1 = a ^ d;
    int num2 = c ^ num1;
    int num3 = b ^ num2;
    this.X3 = a & d ^ num3;
    int num4 = a ^ b & num1;
    this.X2 = num3 ^ (c | num4);
    int num5 = this.X3 & (num2 ^ num4);
    this.X1 = ~num2 ^ num5;
    this.X0 = num5 ^ ~num4;
  }

  protected void Ib0(int a, int b, int c, int d)
  {
    int num1 = ~a;
    int num2 = a ^ b;
    int num3 = d ^ (num1 | num2);
    int num4 = c ^ num3;
    this.X2 = num2 ^ num4;
    int num5 = num1 ^ d & num2;
    this.X1 = num3 ^ this.X2 & num5;
    this.X3 = a & num3 ^ (num4 | this.X1);
    this.X0 = this.X3 ^ num4 ^ num5;
  }

  protected void Sb1(int a, int b, int c, int d)
  {
    int num1 = b ^ ~a;
    int num2 = c ^ (a | num1);
    this.X2 = d ^ num2;
    int num3 = b ^ (d | num1);
    int num4 = num1 ^ this.X2;
    this.X3 = num4 ^ num2 & num3;
    int num5 = num2 ^ num3;
    this.X1 = this.X3 ^ num5;
    this.X0 = num2 ^ num4 & num5;
  }

  protected void Ib1(int a, int b, int c, int d)
  {
    int num1 = b ^ d;
    int num2 = a ^ b & num1;
    int num3 = num1 ^ num2;
    this.X3 = c ^ num3;
    int num4 = b ^ num1 & num2;
    int num5 = this.X3 | num4;
    this.X1 = num2 ^ num5;
    int num6 = ~this.X1;
    int num7 = this.X3 ^ num4;
    this.X0 = num6 ^ num7;
    this.X2 = num3 ^ (num6 | num7);
  }

  protected void Sb2(int a, int b, int c, int d)
  {
    int num1 = ~a;
    int num2 = b ^ d;
    int num3 = c & num1;
    this.X0 = num2 ^ num3;
    int num4 = c ^ num1;
    int num5 = c ^ this.X0;
    int num6 = b & num5;
    this.X3 = num4 ^ num6;
    this.X2 = a ^ (d | num6) & (this.X0 | num4);
    this.X1 = num2 ^ this.X3 ^ this.X2 ^ (d | num1);
  }

  protected void Ib2(int a, int b, int c, int d)
  {
    int num1 = b ^ d;
    int num2 = ~num1;
    int num3 = a ^ c;
    int num4 = c ^ num1;
    int num5 = b & num4;
    this.X0 = num3 ^ num5;
    int num6 = a | num2;
    int num7 = d ^ num6;
    int num8 = num3 | num7;
    this.X3 = num1 ^ num8;
    int num9 = ~num4;
    int num10 = this.X0 | this.X3;
    this.X1 = num9 ^ num10;
    this.X2 = d & num9 ^ num3 ^ num10;
  }

  protected void Sb3(int a, int b, int c, int d)
  {
    int num1 = a ^ b;
    int num2 = a & c;
    int num3 = a | d;
    int num4 = c ^ d;
    int num5 = num1 & num3;
    int num6 = num2 | num5;
    this.X2 = num4 ^ num6;
    int num7 = b ^ num3;
    int num8 = num6 ^ num7;
    int num9 = num4 & num8;
    this.X0 = num1 ^ num9;
    int num10 = this.X2 & this.X0;
    this.X1 = num8 ^ num10;
    this.X3 = (b | d) ^ num4 ^ num10;
  }

  protected void Ib3(int a, int b, int c, int d)
  {
    int num1 = a | b;
    int num2 = b ^ c;
    int num3 = b & num2;
    int num4 = a ^ num3;
    int num5 = c ^ num4;
    int num6 = d | num4;
    this.X0 = num2 ^ num6;
    int num7 = num2 | num6;
    int num8 = d ^ num7;
    this.X2 = num5 ^ num8;
    int num9 = num8;
    int num10 = num1 ^ num9;
    int num11 = this.X0 & num10;
    this.X3 = num4 ^ num11;
    this.X1 = this.X3 ^ this.X0 ^ num10;
  }

  protected void Sb4(int a, int b, int c, int d)
  {
    int num1 = a ^ d;
    int num2 = d & num1;
    int num3 = c ^ num2;
    int num4 = b | num3;
    this.X3 = num1 ^ num4;
    int num5 = ~b;
    int num6 = num1 | num5;
    this.X0 = num3 ^ num6;
    int num7 = a & this.X0;
    int num8 = num1 ^ num5;
    int num9 = num4 & num8;
    this.X2 = num7 ^ num9;
    this.X1 = a ^ num3 ^ num8 & this.X2;
  }

  protected void Ib4(int a, int b, int c, int d)
  {
    int num1 = c | d;
    int num2 = a & num1;
    int num3 = b ^ num2;
    int num4 = a & num3;
    int num5 = c ^ num4;
    this.X1 = d ^ num5;
    int num6 = ~a;
    int num7 = num5 & this.X1;
    this.X3 = num3 ^ num7;
    int num8 = this.X1 | num6;
    int num9 = d ^ num8;
    this.X0 = this.X3 ^ num9;
    this.X2 = num3 & num9 ^ this.X1 ^ num6;
  }

  protected void Sb5(int a, int b, int c, int d)
  {
    int num1 = ~a;
    int num2 = a ^ b;
    int num3 = a ^ d;
    this.X0 = c ^ num1 ^ (num2 | num3);
    int num4 = d & this.X0;
    int num5 = num2 ^ this.X0;
    this.X1 = num4 ^ num5;
    int num6 = num1 | this.X0;
    int num7 = num2 | num4;
    int num8 = num3 ^ num6;
    this.X2 = num7 ^ num8;
    this.X3 = b ^ num4 ^ this.X1 & num8;
  }

  protected void Ib5(int a, int b, int c, int d)
  {
    int num1 = ~c;
    int num2 = b & num1;
    int num3 = d ^ num2;
    int num4 = a & num3;
    int num5 = b ^ num1;
    this.X3 = num4 ^ num5;
    int num6 = b | this.X3;
    int num7 = a & num6;
    this.X1 = num3 ^ num7;
    int num8 = a | d;
    int num9 = num1 ^ num6;
    this.X0 = num8 ^ num9;
    this.X2 = b & num8 ^ (num4 | a ^ c);
  }

  protected void Sb6(int a, int b, int c, int d)
  {
    int num1 = ~a;
    int num2 = a ^ d;
    int num3 = b ^ num2;
    int num4 = num2;
    int num5 = num1 | num4;
    int num6 = c ^ num5;
    this.X1 = b ^ num6;
    int num7 = num2 | this.X1;
    int num8 = d ^ num7;
    int num9 = num6 & num8;
    this.X2 = num3 ^ num9;
    int num10 = num6 ^ num8;
    this.X0 = this.X2 ^ num10;
    this.X3 = ~num6 ^ num3 & num10;
  }

  protected void Ib6(int a, int b, int c, int d)
  {
    int num1 = ~a;
    int num2 = a ^ b;
    int num3 = c ^ num2;
    int num4 = c | num1;
    int num5 = d ^ num4;
    this.X1 = num3 ^ num5;
    int num6 = num3 & num5;
    int num7 = num2 ^ num6;
    int num8 = b | num7;
    this.X3 = num5 ^ num8;
    int num9 = b | this.X3;
    this.X0 = num7 ^ num9;
    this.X2 = d & num1 ^ num3 ^ num9;
  }

  protected void Sb7(int a, int b, int c, int d)
  {
    int num1 = b ^ c;
    int num2 = c & num1;
    int num3 = d ^ num2;
    int num4 = a ^ num3;
    int num5 = d | num1;
    int num6 = num4 & num5;
    this.X1 = b ^ num6;
    int num7 = num3 | this.X1;
    int num8 = a & num4;
    this.X3 = num1 ^ num8;
    int num9 = num4 ^ num7;
    int num10 = this.X3 & num9;
    this.X2 = num3 ^ num10;
    this.X0 = ~num9 ^ this.X3 & this.X2;
  }

  protected void Ib7(int a, int b, int c, int d)
  {
    int num1 = c | a & b;
    int num2 = d & (a | b);
    this.X3 = num1 ^ num2;
    int num3 = ~d;
    int num4 = b ^ num2;
    int num5 = num4 | this.X3 ^ num3;
    this.X1 = a ^ num5;
    this.X0 = c ^ num4 ^ (d | this.X1);
    this.X2 = num1 ^ this.X1 ^ this.X0 ^ a & this.X3;
  }

  protected void LT()
  {
    int num1 = Integers.RotateLeft(this.X0, 13);
    int num2 = Integers.RotateLeft(this.X2, 3);
    int i1 = this.X1 ^ num1 ^ num2;
    int i2 = this.X3 ^ num2 ^ num1 << 3;
    this.X1 = Integers.RotateLeft(i1, 1);
    this.X3 = Integers.RotateLeft(i2, 7);
    this.X0 = Integers.RotateLeft(num1 ^ this.X1 ^ this.X3, 5);
    this.X2 = Integers.RotateLeft(num2 ^ this.X3 ^ this.X1 << 7, 22);
  }

  protected void InverseLT()
  {
    int i1 = Integers.RotateRight(this.X2, 22) ^ this.X3 ^ this.X1 << 7;
    int i2 = Integers.RotateRight(this.X0, 5) ^ this.X1 ^ this.X3;
    int num1 = Integers.RotateRight(this.X3, 7);
    int num2 = Integers.RotateRight(this.X1, 1);
    this.X3 = num1 ^ i1 ^ i2 << 3;
    this.X1 = num2 ^ i2 ^ i1;
    this.X2 = Integers.RotateRight(i1, 3);
    this.X0 = Integers.RotateRight(i2, 13);
  }

  internal abstract int[] MakeWorkingKey(byte[] key);

  internal abstract void EncryptBlock(byte[] input, int inOff, byte[] output, int outOff);

  internal abstract void DecryptBlock(byte[] input, int inOff, byte[] output, int outOff);
}
