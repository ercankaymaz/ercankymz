// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.RC532Engine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class RC532Engine : IBlockCipher
{
  private int _noRounds;
  private int[] _S;
  private static readonly int P32 = -1209970333;
  private static readonly int Q32 = -1640531527;
  private bool forEncryption;

  public RC532Engine() => this._noRounds = 12;

  public virtual string AlgorithmName => "RC5-32";

  public virtual int GetBlockSize() => 8;

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    switch (parameters)
    {
      case RC5Parameters rc5Parameters:
        this._noRounds = rc5Parameters.Rounds;
        this.SetKey(rc5Parameters.GetKey());
        break;
      case KeyParameter keyParameter:
        this.SetKey(keyParameter.GetKey());
        break;
      default:
        throw new ArgumentException("invalid parameter passed to RC532 init - " + Platform.GetTypeName((object) parameters));
    }
    this.forEncryption = forEncryption;
  }

  public virtual int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    return !this.forEncryption ? this.DecryptBlock(input, inOff, output, outOff) : this.EncryptBlock(input, inOff, output, outOff);
  }

  private void SetKey(byte[] key)
  {
    int[] numArray = new int[(key.Length + 3) / 4];
    for (int index = 0; index != key.Length; ++index)
      numArray[index / 4] += ((int) key[index] & (int) byte.MaxValue) << 8 * (index % 4);
    this._S = new int[2 * (this._noRounds + 1)];
    this._S[0] = RC532Engine.P32;
    for (int index = 1; index < this._S.Length; ++index)
      this._S[index] = this._S[index - 1] + RC532Engine.Q32;
    int num1 = numArray.Length <= this._S.Length ? 3 * this._S.Length : 3 * numArray.Length;
    int num2 = 0;
    int num3 = 0;
    int index1 = 0;
    int index2 = 0;
    for (int index3 = 0; index3 < num1; ++index3)
    {
      num2 = this._S[index1] = Integers.RotateLeft(this._S[index1] + num2 + num3, 3);
      num3 = numArray[index2] = Integers.RotateLeft(numArray[index2] + num2 + num3, num2 + num3);
      index1 = (index1 + 1) % this._S.Length;
      index2 = (index2 + 1) % numArray.Length;
    }
  }

  private int EncryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
  {
    int num1 = (int) Pack.LE_To_UInt32(input, inOff) + this._S[0];
    int num2 = (int) Pack.LE_To_UInt32(input, inOff + 4) + this._S[1];
    for (int index = 1; index <= this._noRounds; ++index)
    {
      num1 = Integers.RotateLeft(num1 ^ num2, num2) + this._S[2 * index];
      num2 = Integers.RotateLeft(num2 ^ num1, num1) + this._S[2 * index + 1];
    }
    Pack.UInt32_To_LE((uint) num1, outBytes, outOff);
    Pack.UInt32_To_LE((uint) num2, outBytes, outOff + 4);
    return 8;
  }

  private int DecryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
  {
    int distance1 = (int) Pack.LE_To_UInt32(input, inOff);
    int distance2 = (int) Pack.LE_To_UInt32(input, inOff + 4);
    for (int noRounds = this._noRounds; noRounds >= 1; --noRounds)
    {
      distance2 = Integers.RotateRight(distance2 - this._S[2 * noRounds + 1], distance1) ^ distance1;
      distance1 = Integers.RotateRight(distance1 - this._S[2 * noRounds], distance2) ^ distance2;
    }
    Pack.UInt32_To_LE((uint) (distance1 - this._S[0]), outBytes, outOff);
    Pack.UInt32_To_LE((uint) (distance2 - this._S[1]), outBytes, outOff + 4);
    return 8;
  }
}
