// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.RC6Engine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class RC6Engine : IBlockCipher
{
  private static readonly int _noRounds = 20;
  private int[] _S;
  private static readonly int P32 = -1209970333;
  private static readonly int Q32 = -1640531527;
  private static readonly int LGW = 5;
  private bool forEncryption;

  public virtual string AlgorithmName => "RC6";

  public virtual int GetBlockSize() => 16 /*0x10*/;

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    if (!(parameters is KeyParameter keyParameter))
      throw new ArgumentException("invalid parameter passed to RC6 init - " + Platform.GetTypeName((object) parameters));
    this.forEncryption = forEncryption;
    this.SetKey(keyParameter.GetKey());
  }

  public virtual int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    if (this._S == null)
      throw new InvalidOperationException("RC6 engine not initialised");
    int blockSize = this.GetBlockSize();
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, blockSize, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, blockSize, "output buffer too short");
    return !this.forEncryption ? this.DecryptBlock(input, inOff, output, outOff) : this.EncryptBlock(input, inOff, output, outOff);
  }

  private void SetKey(byte[] key)
  {
    int[] numArray = new int[(key.Length + 3) / 4];
    for (int index = key.Length - 1; index >= 0; --index)
      numArray[index / 4] = (numArray[index / 4] << 8) + ((int) key[index] & (int) byte.MaxValue);
    this._S = new int[2 + 2 * RC6Engine._noRounds + 2];
    this._S[0] = RC6Engine.P32;
    for (int index = 1; index < this._S.Length; ++index)
      this._S[index] = this._S[index - 1] + RC6Engine.Q32;
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
    int num1 = (int) Pack.LE_To_UInt32(input, inOff);
    int uint32_1 = (int) Pack.LE_To_UInt32(input, inOff + 4);
    int num2 = (int) Pack.LE_To_UInt32(input, inOff + 8);
    int uint32_2 = (int) Pack.LE_To_UInt32(input, inOff + 12);
    int n1 = uint32_1 + this._S[0];
    int n2 = uint32_2 + this._S[1];
    for (int index = 1; index <= RC6Engine._noRounds; ++index)
    {
      int distance1 = Integers.RotateLeft(n1 * (2 * n1 + 1), 5);
      int distance2 = Integers.RotateLeft(n2 * (2 * n2 + 1), 5);
      int num3 = Integers.RotateLeft(num1 ^ distance1, distance2) + this._S[2 * index];
      int num4 = Integers.RotateLeft(num2 ^ distance2, distance1) + this._S[2 * index + 1];
      int num5 = num3;
      num1 = n1;
      n1 = num4;
      num2 = n2;
      n2 = num5;
    }
    int n3 = num1 + this._S[2 * RC6Engine._noRounds + 2];
    int n4 = num2 + this._S[2 * RC6Engine._noRounds + 3];
    Pack.UInt32_To_LE((uint) n3, outBytes, outOff);
    Pack.UInt32_To_LE((uint) n1, outBytes, outOff + 4);
    Pack.UInt32_To_LE((uint) n4, outBytes, outOff + 8);
    Pack.UInt32_To_LE((uint) n2, outBytes, outOff + 12);
    return 16 /*0x10*/;
  }

  private int DecryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
  {
    int uint32_1 = (int) Pack.LE_To_UInt32(input, inOff);
    int num1 = (int) Pack.LE_To_UInt32(input, inOff + 4);
    int uint32_2 = (int) Pack.LE_To_UInt32(input, inOff + 8);
    int num2 = (int) Pack.LE_To_UInt32(input, inOff + 12);
    int n1 = uint32_2 - this._S[2 * RC6Engine._noRounds + 3];
    int n2 = uint32_1 - this._S[2 * RC6Engine._noRounds + 2];
    for (int noRounds = RC6Engine._noRounds; noRounds >= 1; --noRounds)
    {
      int num3 = num2;
      num2 = n1;
      int num4 = num1;
      num1 = n2;
      int num5 = num3;
      int distance1 = Integers.RotateLeft(num1 * (2 * num1 + 1), RC6Engine.LGW);
      int distance2 = Integers.RotateLeft(num2 * (2 * num2 + 1), RC6Engine.LGW);
      n1 = Integers.RotateRight(num4 - this._S[2 * noRounds + 1], distance1) ^ distance2;
      n2 = Integers.RotateRight(num5 - this._S[2 * noRounds], distance2) ^ distance1;
    }
    int n3 = num2 - this._S[1];
    int n4 = num1 - this._S[0];
    Pack.UInt32_To_LE((uint) n2, outBytes, outOff);
    Pack.UInt32_To_LE((uint) n4, outBytes, outOff + 4);
    Pack.UInt32_To_LE((uint) n1, outBytes, outOff + 8);
    Pack.UInt32_To_LE((uint) n3, outBytes, outOff + 12);
    return 16 /*0x10*/;
  }
}
