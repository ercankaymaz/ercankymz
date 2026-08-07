// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.ChaChaEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class ChaChaEngine : Salsa20Engine
{
  public ChaChaEngine()
  {
  }

  public ChaChaEngine(int rounds)
    : base(rounds)
  {
  }

  public override string AlgorithmName => "ChaCha" + this.rounds.ToString();

  protected override void AdvanceCounter()
  {
    if (++this.engineState[12] != 0U)
      return;
    ++this.engineState[13];
  }

  protected override void ResetCounter()
  {
    uint[] engineState = this.engineState;
    this.engineState[13] = 0U;
    engineState[12] = 0U;
  }

  protected override void SetKey(byte[] keyBytes, byte[] ivBytes)
  {
    if (keyBytes != null)
    {
      if (keyBytes.Length != 16 /*0x10*/ && keyBytes.Length != 32 /*0x20*/)
        throw new ArgumentException(this.AlgorithmName + " requires 128 bit or 256 bit key");
      Salsa20Engine.PackTauOrSigma(keyBytes.Length, this.engineState, 0);
      Pack.LE_To_UInt32(keyBytes, 0, this.engineState, 4, 4);
      Pack.LE_To_UInt32(keyBytes, keyBytes.Length - 16 /*0x10*/, this.engineState, 8, 4);
    }
    Pack.LE_To_UInt32(ivBytes, 0, this.engineState, 14, 2);
  }

  protected override void GenerateKeyStream(byte[] output)
  {
    ChaChaEngine.ChachaCore(this.rounds, this.engineState, output);
  }

  internal static void ChachaCore(int rounds, uint[] input, byte[] output)
  {
    uint num1 = input[0];
    uint num2 = input[1];
    uint num3 = input[2];
    uint num4 = input[3];
    uint num5 = input[4];
    uint num6 = input[5];
    uint num7 = input[6];
    uint num8 = input[7];
    uint num9 = input[8];
    uint num10 = input[9];
    uint num11 = input[10];
    uint num12 = input[11];
    uint num13 = input[12];
    uint num14 = input[13];
    uint num15 = input[14];
    uint num16 = input[15];
    for (int index = rounds; index > 0; index -= 2)
    {
      uint num17 = num1 + num5;
      uint num18 = Integers.RotateLeft(num13 ^ num17, 16 /*0x10*/);
      uint num19 = num2 + num6;
      uint num20 = Integers.RotateLeft(num14 ^ num19, 16 /*0x10*/);
      uint num21 = num3 + num7;
      uint num22 = Integers.RotateLeft(num15 ^ num21, 16 /*0x10*/);
      uint num23 = num4 + num8;
      uint num24 = Integers.RotateLeft(num16 ^ num23, 16 /*0x10*/);
      uint num25 = num9 + num18;
      uint num26 = Integers.RotateLeft(num5 ^ num25, 12);
      uint num27 = num10 + num20;
      uint num28 = Integers.RotateLeft(num6 ^ num27, 12);
      uint num29 = num11 + num22;
      uint num30 = Integers.RotateLeft(num7 ^ num29, 12);
      uint num31 = num12 + num24;
      uint num32 = Integers.RotateLeft(num8 ^ num31, 12);
      uint num33 = num17 + num26;
      uint num34 = Integers.RotateLeft(num18 ^ num33, 8);
      uint num35 = num19 + num28;
      uint num36 = Integers.RotateLeft(num20 ^ num35, 8);
      uint num37 = num21 + num30;
      uint num38 = Integers.RotateLeft(num22 ^ num37, 8);
      uint num39 = num23 + num32;
      uint num40 = Integers.RotateLeft(num24 ^ num39, 8);
      uint num41 = num25 + num34;
      uint num42 = Integers.RotateLeft(num26 ^ num41, 7);
      uint num43 = num27 + num36;
      uint num44 = Integers.RotateLeft(num28 ^ num43, 7);
      uint num45 = num29 + num38;
      uint num46 = Integers.RotateLeft(num30 ^ num45, 7);
      uint num47 = num31 + num40;
      uint num48 = Integers.RotateLeft(num32 ^ num47, 7);
      uint num49 = num33 + num44;
      uint num50 = Integers.RotateLeft(num40 ^ num49, 16 /*0x10*/);
      uint num51 = num35 + num46;
      uint num52 = Integers.RotateLeft(num34 ^ num51, 16 /*0x10*/);
      uint num53 = num37 + num48;
      uint num54 = Integers.RotateLeft(num36 ^ num53, 16 /*0x10*/);
      uint num55 = num39 + num42;
      uint num56 = Integers.RotateLeft(num38 ^ num55, 16 /*0x10*/);
      uint num57 = num45 + num50;
      uint num58 = Integers.RotateLeft(num44 ^ num57, 12);
      uint num59 = num47 + num52;
      uint num60 = Integers.RotateLeft(num46 ^ num59, 12);
      uint num61 = num41 + num54;
      uint num62 = Integers.RotateLeft(num48 ^ num61, 12);
      uint num63 = num43 + num56;
      uint num64 = Integers.RotateLeft(num42 ^ num63, 12);
      num1 = num49 + num58;
      num16 = Integers.RotateLeft(num50 ^ num1, 8);
      num2 = num51 + num60;
      num13 = Integers.RotateLeft(num52 ^ num2, 8);
      num3 = num53 + num62;
      num14 = Integers.RotateLeft(num54 ^ num3, 8);
      num4 = num55 + num64;
      num15 = Integers.RotateLeft(num56 ^ num4, 8);
      num11 = num57 + num16;
      num6 = Integers.RotateLeft(num58 ^ num11, 7);
      num12 = num59 + num13;
      num7 = Integers.RotateLeft(num60 ^ num12, 7);
      num9 = num61 + num14;
      num8 = Integers.RotateLeft(num62 ^ num9, 7);
      num10 = num63 + num15;
      num5 = Integers.RotateLeft(num64 ^ num10, 7);
    }
    Pack.UInt32_To_LE(num1 + input[0], output, 0);
    Pack.UInt32_To_LE(num2 + input[1], output, 4);
    Pack.UInt32_To_LE(num3 + input[2], output, 8);
    Pack.UInt32_To_LE(num4 + input[3], output, 12);
    Pack.UInt32_To_LE(num5 + input[4], output, 16 /*0x10*/);
    Pack.UInt32_To_LE(num6 + input[5], output, 20);
    Pack.UInt32_To_LE(num7 + input[6], output, 24);
    Pack.UInt32_To_LE(num8 + input[7], output, 28);
    Pack.UInt32_To_LE(num9 + input[8], output, 32 /*0x20*/);
    Pack.UInt32_To_LE(num10 + input[9], output, 36);
    Pack.UInt32_To_LE(num11 + input[10], output, 40);
    Pack.UInt32_To_LE(num12 + input[11], output, 44);
    Pack.UInt32_To_LE(num13 + input[12], output, 48 /*0x30*/);
    Pack.UInt32_To_LE(num14 + input[13], output, 52);
    Pack.UInt32_To_LE(num15 + input[14], output, 56);
    Pack.UInt32_To_LE(num16 + input[15], output, 60);
  }
}
