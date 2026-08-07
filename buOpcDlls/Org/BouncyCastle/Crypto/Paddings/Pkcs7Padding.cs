// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Paddings.Pkcs7Padding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Crypto.Paddings;

public class Pkcs7Padding : IBlockCipherPadding
{
  public void Init(SecureRandom random)
  {
  }

  public string PaddingName => "PKCS7";

  public int AddPadding(byte[] input, int inOff)
  {
    int num1 = input.Length - inOff;
    byte num2 = (byte) num1;
    while (inOff < input.Length)
      input[inOff++] = num2;
    return num1;
  }

  public int PadCount(byte[] input)
  {
    byte num1 = input[input.Length - 1];
    int num2 = (int) num1;
    int num3 = input.Length - num2;
    int num4 = (num3 | num2 - 1) >> 31 /*0x1F*/;
    for (int index = 0; index < input.Length; ++index)
      num4 |= ((int) input[index] ^ (int) num1) & ~(index - num3 >> 31 /*0x1F*/);
    if (num4 != 0)
      throw new InvalidCipherTextException("pad block corrupted");
    return num2;
  }
}
