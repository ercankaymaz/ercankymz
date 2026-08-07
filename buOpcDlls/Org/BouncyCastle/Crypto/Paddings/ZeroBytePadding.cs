// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Paddings.ZeroBytePadding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Crypto.Paddings;

public class ZeroBytePadding : IBlockCipherPadding
{
  public string PaddingName => nameof (ZeroBytePadding);

  public void Init(SecureRandom random)
  {
  }

  public int AddPadding(byte[] input, int inOff)
  {
    int num = input.Length - inOff;
    while (inOff < input.Length)
      input[inOff++] = (byte) 0;
    return num;
  }

  public int PadCount(byte[] input)
  {
    int num1 = 0;
    int num2 = -1;
    int length = input.Length;
    while (--length >= 0)
    {
      int num3 = ((int) input[length] ^ 0) - 1 >> 31 /*0x1F*/;
      num2 &= num3;
      num1 -= num2;
    }
    return num1;
  }
}
