// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Encoders.HexTranslator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Utilities.Encoders;

public class HexTranslator : ITranslator
{
  private static readonly byte[] hexTable = new byte[16 /*0x10*/]
  {
    (byte) 48 /*0x30*/,
    (byte) 49,
    (byte) 50,
    (byte) 51,
    (byte) 52,
    (byte) 53,
    (byte) 54,
    (byte) 55,
    (byte) 56,
    (byte) 57,
    (byte) 97,
    (byte) 98,
    (byte) 99,
    (byte) 100,
    (byte) 101,
    (byte) 102
  };

  public int GetEncodedBlockSize() => 2;

  public int Encode(byte[] input, int inOff, int length, byte[] outBytes, int outOff)
  {
    int num1 = 0;
    int num2 = 0;
    while (num1 < length)
    {
      outBytes[outOff + num2] = HexTranslator.hexTable[(int) input[inOff] >> 4 & 15];
      outBytes[outOff + num2 + 1] = HexTranslator.hexTable[(int) input[inOff] & 15];
      ++inOff;
      ++num1;
      num2 += 2;
    }
    return length * 2;
  }

  public int GetDecodedBlockSize() => 1;

  public int Decode(byte[] input, int inOff, int length, byte[] outBytes, int outOff)
  {
    int num1 = length / 2;
    for (int index = 0; index < num1; ++index)
    {
      byte num2 = input[inOff + index * 2];
      byte num3 = input[inOff + index * 2 + 1];
      outBytes[outOff] = num2 >= (byte) 97 ? (byte) ((int) num2 - 97 + 10 << 4) : (byte) ((int) num2 - 48 /*0x30*/ << 4);
      if (num3 < (byte) 97)
        outBytes[outOff] += (byte) ((uint) num3 - 48U /*0x30*/);
      else
        outBytes[outOff] += (byte) ((int) num3 - 97 + 10);
      ++outOff;
    }
    return num1;
  }
}
