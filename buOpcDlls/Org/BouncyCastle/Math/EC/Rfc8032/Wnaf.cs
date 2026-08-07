// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Rfc8032.Wnaf
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Rfc8032;

internal static class Wnaf
{
  internal static void GetSignedVar(uint[] n, int width, sbyte[] ws)
  {
    uint[] numArray = new uint[n.Length * 2];
    uint num1 = (uint) -(int) (n[n.Length - 1] >> 31 /*0x1F*/);
    int num2 = numArray.Length;
    int length = n.Length;
    while (--length >= 0)
    {
      uint num3 = n[length];
      int num4;
      numArray[num4 = num2 - 1] = num3 >> 16 /*0x10*/ | num1 << 16 /*0x10*/;
      numArray[num2 = num4 - 1] = num1 = num3;
    }
    int num5 = 0;
    int num6 = 32 /*0x20*/ - width;
    int num7 = 0;
    int index = 0;
    while (index < numArray.Length)
    {
      uint num8 = numArray[index];
      while (num5 < 16 /*0x10*/)
      {
        int num9 = (int) (num8 >> num5);
        int num10 = Integers.NumberOfTrailingZeros(num7 ^ num9 | 65536 /*0x010000*/);
        if (num10 > 0)
        {
          num5 += num10;
        }
        else
        {
          int num11 = (num9 | 1) << num6;
          num7 = num11 >> 31 /*0x1F*/;
          ws[(index << 4) + num5] = (sbyte) (num11 >> num6);
          num5 += width;
        }
      }
      ++index;
      num5 -= 16 /*0x10*/;
    }
  }
}
