// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Paddings.ISO7816d4Padding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Crypto.Paddings;

public class ISO7816d4Padding : IBlockCipherPadding
{
  public void Init(SecureRandom random)
  {
  }

  public string PaddingName => "ISO7816-4";

  public int AddPadding(byte[] input, int inOff)
  {
    int num = input.Length - inOff;
    input[inOff] = (byte) 128 /*0x80*/;
    while (++inOff < input.Length)
      input[inOff] = (byte) 0;
    return num;
  }

  public int PadCount(byte[] input)
  {
    int num1 = -1;
    int num2 = -1;
    int length = input.Length;
    while (--length >= 0)
    {
      int num3 = (int) input[length];
      int num4 = (num3 ^ 0) - 1 >> 31 /*0x1F*/;
      int num5 = (num3 ^ 128 /*0x80*/) - 1 >> 31 /*0x1F*/;
      num1 ^= (length ^ num1) & num2 & num5;
      num2 &= num4;
    }
    if (num1 < 0)
      throw new InvalidCipherTextException("pad block corrupted");
    return input.Length - num1;
  }
}
