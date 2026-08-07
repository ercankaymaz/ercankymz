// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.Tape
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

internal class Tape
{
  internal byte[][] tapes;
  internal int pos;
  private int nTapes;
  private readonly PicnicEngine engine;

  internal Tape(PicnicEngine engine)
  {
    this.engine = engine;
    this.tapes = new byte[engine.numMPCParties][];
    for (int index = 0; index < engine.numMPCParties; ++index)
      this.tapes[index] = new byte[2 * engine.andSizeBytes];
    this.pos = 0;
    this.nTapes = engine.numMPCParties;
  }

  internal void SetAuxBits(byte[] input)
  {
    int index1 = this.engine.numMPCParties - 1;
    int num = 0;
    int stateSizeBits = this.engine.stateSizeBits;
    for (int index2 = 0; index2 < this.engine.numRounds; ++index2)
    {
      for (int index3 = 0; index3 < stateSizeBits; ++index3)
        PicnicUtilities.SetBit(this.tapes[index1], stateSizeBits + stateSizeBits * 2 * index2 + index3, PicnicUtilities.GetBit(input, num++));
    }
  }

  internal void ComputeAuxTape(byte[] inputs)
  {
    uint[] numArray1 = new uint[(int) PicnicEngine.LOWMC_MAX_WORDS];
    uint[] numArray2 = new uint[(int) PicnicEngine.LOWMC_MAX_WORDS];
    uint[] output = new uint[(int) PicnicEngine.LOWMC_MAX_WORDS];
    uint[] numArray3 = new uint[(int) PicnicEngine.LOWMC_MAX_WORDS];
    uint[] numArray4 = new uint[(int) PicnicEngine.LOWMC_MAX_WORDS];
    numArray4[this.engine.stateSizeWords - 1] = 0U;
    this.TapesToParityBits(numArray4, this.engine.stateSizeBits);
    KMatricesWithPointer kmatricesWithPointer1 = this.engine._lowmcConstants.KMatrixInv(this.engine, 0);
    this.engine.matrix_mul(numArray3, numArray4, kmatricesWithPointer1.GetData(), kmatricesWithPointer1.GetMatrixPointer());
    if (inputs != null)
      Pack.UInt32_To_LE(Arrays.CopyOf(numArray3, this.engine.stateSizeWords), inputs, 0);
    for (int numRounds = this.engine.numRounds; numRounds > 0; --numRounds)
    {
      KMatricesWithPointer kmatricesWithPointer2 = this.engine._lowmcConstants.KMatrix(this.engine, numRounds);
      this.engine.matrix_mul(numArray1, numArray3, kmatricesWithPointer2.GetData(), kmatricesWithPointer2.GetMatrixPointer());
      this.engine.xor_array(numArray2, numArray2, numArray1, 0, this.engine.stateSizeWords);
      KMatricesWithPointer kmatricesWithPointer3 = this.engine._lowmcConstants.LMatrixInv(this.engine, numRounds - 1);
      this.engine.matrix_mul(output, numArray2, kmatricesWithPointer3.GetData(), kmatricesWithPointer3.GetMatrixPointer());
      if (numRounds == 1)
      {
        Array.Copy((Array) numArray4, 0, (Array) numArray2, 0, numArray4.Length);
      }
      else
      {
        this.pos = this.engine.stateSizeBits * 2 * (numRounds - 1);
        this.TapesToParityBits(numArray2, this.engine.stateSizeBits);
      }
      this.pos = this.engine.stateSizeBits * 2 * (numRounds - 1) + this.engine.stateSizeBits;
      this.engine.aux_mpc_sbox(numArray2, output, this);
    }
    this.pos = 0;
  }

  private void TapesToParityBits(uint[] output, int outputBitLen)
  {
    for (int bitNumber = 0; bitNumber < outputBitLen; ++bitNumber)
      PicnicUtilities.SetBitInWordArray(output, bitNumber, PicnicUtilities.Parity16(this.TapesToWord()));
  }

  internal uint TapesToWord()
  {
    int index = this.pos >> 3;
    int num1 = this.pos & 7 ^ 7;
    uint num2 = (uint) (1 << num1);
    int num3 = 0 | ((int) this.tapes[0][index] & (int) num2) << 7 | ((int) this.tapes[1][index] & (int) num2) << 6 | ((int) this.tapes[2][index] & (int) num2) << 5 | ((int) this.tapes[3][index] & (int) num2) << 4 | ((int) this.tapes[4][index] & (int) num2) << 3 | ((int) this.tapes[5][index] & (int) num2) << 2 | ((int) this.tapes[6][index] & (int) num2) << 1 | (int) this.tapes[7][index] & (int) num2 | ((int) this.tapes[8][index] & (int) num2) << 15 | ((int) this.tapes[9][index] & (int) num2) << 14 | ((int) this.tapes[10][index] & (int) num2) << 13 | ((int) this.tapes[11][index] & (int) num2) << 12 | ((int) this.tapes[12][index] & (int) num2) << 11 | ((int) this.tapes[13][index] & (int) num2) << 10 | ((int) this.tapes[14][index] & (int) num2) << 9 | ((int) this.tapes[15][index] & (int) num2) << 8;
    ++this.pos;
    int num4 = num1 & 31 /*0x1F*/;
    return (uint) (num3 >>> num4);
  }
}
