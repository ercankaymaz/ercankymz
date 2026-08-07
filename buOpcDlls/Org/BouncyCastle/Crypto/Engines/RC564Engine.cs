// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.RC564Engine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class RC564Engine : IBlockCipher
{
  private int _noRounds;
  private long[] _S;
  private static readonly long P64 = -5196783011329398165;
  private static readonly long Q64 = -7046029254386353131;
  private bool forEncryption;

  public RC564Engine() => this._noRounds = 12;

  public virtual string AlgorithmName => "RC5-64";

  public virtual int GetBlockSize() => 16 /*0x10*/;

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    if (!(parameters is RC5Parameters rc5Parameters))
      throw new ArgumentException("invalid parameter passed to RC564 init - " + Platform.GetTypeName((object) parameters));
    this.forEncryption = forEncryption;
    this._noRounds = rc5Parameters.Rounds;
    this.SetKey(rc5Parameters.GetKey());
  }

  public virtual int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    return !this.forEncryption ? this.DecryptBlock(input, inOff, output, outOff) : this.EncryptBlock(input, inOff, output, outOff);
  }

  private void SetKey(byte[] key)
  {
    long[] numArray = new long[(key.Length + 7) / 8];
    for (int index = 0; index != key.Length; ++index)
      numArray[index / 8] += (long) ((int) key[index] & (int) byte.MaxValue) << 8 * (index % 8);
    this._S = new long[2 * (this._noRounds + 1)];
    this._S[0] = RC564Engine.P64;
    for (int index = 1; index < this._S.Length; ++index)
      this._S[index] = this._S[index - 1] + RC564Engine.Q64;
    int num1 = numArray.Length <= this._S.Length ? 3 * this._S.Length : 3 * numArray.Length;
    long num2 = 0;
    long num3 = 0;
    int index1 = 0;
    int index2 = 0;
    for (int index3 = 0; index3 < num1; ++index3)
    {
      num2 = this._S[index1] = Longs.RotateLeft(this._S[index1] + num2 + num3, 3);
      num3 = numArray[index2] = Longs.RotateLeft(numArray[index2] + num2 + num3, (int) (num2 + num3));
      index1 = (index1 + 1) % this._S.Length;
      index2 = (index2 + 1) % numArray.Length;
    }
  }

  private int EncryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
  {
    long num1 = (long) Pack.LE_To_UInt64(input, inOff) + this._S[0];
    long num2 = (long) Pack.LE_To_UInt64(input, inOff + 8) + this._S[1];
    for (int index = 1; index <= this._noRounds; ++index)
    {
      num1 = Longs.RotateLeft(num1 ^ num2, (int) num2) + this._S[2 * index];
      num2 = Longs.RotateLeft(num2 ^ num1, (int) num1) + this._S[2 * index + 1];
    }
    Pack.UInt64_To_LE((ulong) num1, outBytes, outOff);
    Pack.UInt64_To_LE((ulong) num2, outBytes, outOff + 8);
    return 16 /*0x10*/;
  }

  private int DecryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
  {
    long distance1 = (long) Pack.LE_To_UInt64(input, inOff);
    long distance2 = (long) Pack.LE_To_UInt64(input, inOff + 8);
    for (int noRounds = this._noRounds; noRounds >= 1; --noRounds)
    {
      distance2 = Longs.RotateRight(distance2 - this._S[2 * noRounds + 1], (int) distance1) ^ distance1;
      distance1 = Longs.RotateRight(distance1 - this._S[2 * noRounds], (int) distance2) ^ distance2;
    }
    Pack.UInt64_To_LE((ulong) (distance1 - this._S[0]), outBytes, outOff);
    Pack.UInt64_To_LE((ulong) (distance2 - this._S[1]), outBytes, outOff + 8);
    return 16 /*0x10*/;
  }
}
