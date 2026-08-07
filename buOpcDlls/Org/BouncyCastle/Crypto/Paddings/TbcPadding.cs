// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Paddings.TbcPadding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Crypto.Paddings;

public class TbcPadding : IBlockCipherPadding
{
  public virtual void Init(SecureRandom random)
  {
  }

  public string PaddingName => "TBC";

  public virtual int AddPadding(byte[] input, int inOff)
  {
    int num1 = input.Length - inOff;
    byte num2 = (byte) (((inOff > 0 ? (int) input[inOff - 1] : (int) input[input.Length - 1]) & 1) - 1);
    while (inOff < input.Length)
      input[inOff++] = num2;
    return num1;
  }

  public virtual int PadCount(byte[] input)
  {
    int length = input.Length;
    int index;
    int num1 = (int) input[index = length - 1];
    int num2 = 1;
    int num3 = -1;
    while (--index >= 0)
    {
      int num4 = ((int) input[index] ^ num1) - 1 >> 31 /*0x1F*/;
      num3 &= num4;
      num2 -= num3;
    }
    return num2;
  }
}
