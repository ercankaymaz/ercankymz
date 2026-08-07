// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Paddings.X923Padding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Crypto.Paddings;

public class X923Padding : IBlockCipherPadding
{
  private SecureRandom m_random;

  public void Init(SecureRandom random) => this.m_random = random;

  public string PaddingName => "X9.23";

  public int AddPadding(byte[] input, int inOff)
  {
    int num = input.Length - inOff;
    if (num > 1)
    {
      if (this.m_random == null)
        Arrays.Fill(input, inOff, input.Length - 1, (byte) 0);
      else
        this.m_random.NextBytes(input, inOff, num - 1);
    }
    input[input.Length - 1] = (byte) num;
    return num;
  }

  public int PadCount(byte[] input)
  {
    int num = (int) input[input.Length - 1];
    if ((input.Length - num | num - 1) >> 31 /*0x1F*/ != 0)
      throw new InvalidCipherTextException("pad block corrupted");
    return num;
  }
}
