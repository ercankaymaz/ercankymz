// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.Cast6Engine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public sealed class Cast6Engine : Cast5Engine
{
  private const int ROUNDS = 12;
  private const int BLOCK_SIZE = 16 /*0x10*/;
  private int[] _Kr = new int[48 /*0x30*/];
  private uint[] _Km = new uint[48 /*0x30*/];
  private int[] _Tr = new int[192 /*0xC0*/];
  private uint[] _Tm = new uint[192 /*0xC0*/];
  private uint[] _workingKey = new uint[8];

  public override string AlgorithmName => "CAST6";

  public override int GetBlockSize() => 16 /*0x10*/;

  internal override void SetKey(byte[] key)
  {
    uint num1 = 1518500249;
    uint num2 = 1859775393;
    int num3 = 19;
    int num4 = 17;
    for (int index1 = 0; index1 < 24; ++index1)
    {
      for (int index2 = 0; index2 < 8; ++index2)
      {
        this._Tm[index1 * 8 + index2] = num1;
        num1 += num2;
        this._Tr[index1 * 8 + index2] = num3;
        num3 = num3 + num4 & 31 /*0x1F*/;
      }
    }
    byte[] bs = new byte[64 /*0x40*/];
    key.CopyTo((Array) bs, 0);
    for (int index = 0; index < 8; ++index)
      this._workingKey[index] = Pack.BE_To_UInt32(bs, index * 4);
    for (int index3 = 0; index3 < 12; ++index3)
    {
      int index4 = index3 * 2 * 8;
      this._workingKey[6] ^= Cast5Engine.F1(this._workingKey[7], this._Tm[index4], this._Tr[index4]);
      this._workingKey[5] ^= Cast5Engine.F2(this._workingKey[6], this._Tm[index4 + 1], this._Tr[index4 + 1]);
      this._workingKey[4] ^= Cast5Engine.F3(this._workingKey[5], this._Tm[index4 + 2], this._Tr[index4 + 2]);
      this._workingKey[3] ^= Cast5Engine.F1(this._workingKey[4], this._Tm[index4 + 3], this._Tr[index4 + 3]);
      this._workingKey[2] ^= Cast5Engine.F2(this._workingKey[3], this._Tm[index4 + 4], this._Tr[index4 + 4]);
      this._workingKey[1] ^= Cast5Engine.F3(this._workingKey[2], this._Tm[index4 + 5], this._Tr[index4 + 5]);
      this._workingKey[0] ^= Cast5Engine.F1(this._workingKey[1], this._Tm[index4 + 6], this._Tr[index4 + 6]);
      this._workingKey[7] ^= Cast5Engine.F2(this._workingKey[0], this._Tm[index4 + 7], this._Tr[index4 + 7]);
      int index5 = (index3 * 2 + 1) * 8;
      this._workingKey[6] ^= Cast5Engine.F1(this._workingKey[7], this._Tm[index5], this._Tr[index5]);
      this._workingKey[5] ^= Cast5Engine.F2(this._workingKey[6], this._Tm[index5 + 1], this._Tr[index5 + 1]);
      this._workingKey[4] ^= Cast5Engine.F3(this._workingKey[5], this._Tm[index5 + 2], this._Tr[index5 + 2]);
      this._workingKey[3] ^= Cast5Engine.F1(this._workingKey[4], this._Tm[index5 + 3], this._Tr[index5 + 3]);
      this._workingKey[2] ^= Cast5Engine.F2(this._workingKey[3], this._Tm[index5 + 4], this._Tr[index5 + 4]);
      this._workingKey[1] ^= Cast5Engine.F3(this._workingKey[2], this._Tm[index5 + 5], this._Tr[index5 + 5]);
      this._workingKey[0] ^= Cast5Engine.F1(this._workingKey[1], this._Tm[index5 + 6], this._Tr[index5 + 6]);
      this._workingKey[7] ^= Cast5Engine.F2(this._workingKey[0], this._Tm[index5 + 7], this._Tr[index5 + 7]);
      this._Kr[index3 * 4] = (int) this._workingKey[0] & 31 /*0x1F*/;
      this._Kr[index3 * 4 + 1] = (int) this._workingKey[2] & 31 /*0x1F*/;
      this._Kr[index3 * 4 + 2] = (int) this._workingKey[4] & 31 /*0x1F*/;
      this._Kr[index3 * 4 + 3] = (int) this._workingKey[6] & 31 /*0x1F*/;
      this._Km[index3 * 4] = this._workingKey[7];
      this._Km[index3 * 4 + 1] = this._workingKey[5];
      this._Km[index3 * 4 + 2] = this._workingKey[3];
      this._Km[index3 * 4 + 3] = this._workingKey[1];
    }
  }

  internal override int EncryptBlock(byte[] src, int srcIndex, byte[] dst, int dstIndex)
  {
    uint uint32_1 = Pack.BE_To_UInt32(src, srcIndex);
    uint uint32_2 = Pack.BE_To_UInt32(src, srcIndex + 4);
    uint uint32_3 = Pack.BE_To_UInt32(src, srcIndex + 8);
    uint uint32_4 = Pack.BE_To_UInt32(src, srcIndex + 12);
    uint[] result = new uint[4];
    this.CAST_Encipher(uint32_1, uint32_2, uint32_3, uint32_4, result);
    Pack.UInt32_To_BE(result[0], dst, dstIndex);
    Pack.UInt32_To_BE(result[1], dst, dstIndex + 4);
    Pack.UInt32_To_BE(result[2], dst, dstIndex + 8);
    Pack.UInt32_To_BE(result[3], dst, dstIndex + 12);
    return 16 /*0x10*/;
  }

  internal override int DecryptBlock(byte[] src, int srcIndex, byte[] dst, int dstIndex)
  {
    uint uint32_1 = Pack.BE_To_UInt32(src, srcIndex);
    uint uint32_2 = Pack.BE_To_UInt32(src, srcIndex + 4);
    uint uint32_3 = Pack.BE_To_UInt32(src, srcIndex + 8);
    uint uint32_4 = Pack.BE_To_UInt32(src, srcIndex + 12);
    uint[] result = new uint[4];
    this.CAST_Decipher(uint32_1, uint32_2, uint32_3, uint32_4, result);
    Pack.UInt32_To_BE(result[0], dst, dstIndex);
    Pack.UInt32_To_BE(result[1], dst, dstIndex + 4);
    Pack.UInt32_To_BE(result[2], dst, dstIndex + 8);
    Pack.UInt32_To_BE(result[3], dst, dstIndex + 12);
    return 16 /*0x10*/;
  }

  private void CAST_Encipher(uint A, uint B, uint C, uint D, uint[] result)
  {
    for (int index1 = 0; index1 < 6; ++index1)
    {
      int index2 = index1 * 4;
      C ^= Cast5Engine.F1(D, this._Km[index2], this._Kr[index2]);
      B ^= Cast5Engine.F2(C, this._Km[index2 + 1], this._Kr[index2 + 1]);
      A ^= Cast5Engine.F3(B, this._Km[index2 + 2], this._Kr[index2 + 2]);
      D ^= Cast5Engine.F1(A, this._Km[index2 + 3], this._Kr[index2 + 3]);
    }
    for (int index3 = 6; index3 < 12; ++index3)
    {
      int index4 = index3 * 4;
      D ^= Cast5Engine.F1(A, this._Km[index4 + 3], this._Kr[index4 + 3]);
      A ^= Cast5Engine.F3(B, this._Km[index4 + 2], this._Kr[index4 + 2]);
      B ^= Cast5Engine.F2(C, this._Km[index4 + 1], this._Kr[index4 + 1]);
      C ^= Cast5Engine.F1(D, this._Km[index4], this._Kr[index4]);
    }
    result[0] = A;
    result[1] = B;
    result[2] = C;
    result[3] = D;
  }

  private void CAST_Decipher(uint A, uint B, uint C, uint D, uint[] result)
  {
    for (int index1 = 0; index1 < 6; ++index1)
    {
      int index2 = (11 - index1) * 4;
      C ^= Cast5Engine.F1(D, this._Km[index2], this._Kr[index2]);
      B ^= Cast5Engine.F2(C, this._Km[index2 + 1], this._Kr[index2 + 1]);
      A ^= Cast5Engine.F3(B, this._Km[index2 + 2], this._Kr[index2 + 2]);
      D ^= Cast5Engine.F1(A, this._Km[index2 + 3], this._Kr[index2 + 3]);
    }
    for (int index3 = 6; index3 < 12; ++index3)
    {
      int index4 = (11 - index3) * 4;
      D ^= Cast5Engine.F1(A, this._Km[index4 + 3], this._Kr[index4 + 3]);
      A ^= Cast5Engine.F3(B, this._Km[index4 + 2], this._Kr[index4 + 2]);
      B ^= Cast5Engine.F2(C, this._Km[index4 + 1], this._Kr[index4 + 1]);
      C ^= Cast5Engine.F1(D, this._Km[index4], this._Kr[index4]);
    }
    result[0] = A;
    result[1] = B;
    result[2] = C;
    result[3] = D;
  }
}
