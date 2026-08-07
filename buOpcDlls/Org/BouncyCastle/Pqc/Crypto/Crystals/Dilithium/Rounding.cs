// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium.Rounding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

internal class Rounding
{
  public static int[] Power2Round(int a)
  {
    int[] numArray = new int[2]
    {
      a + 4096 /*0x1000*/ - 1 >> 13,
      0
    };
    numArray[1] = a - (numArray[0] << 13);
    return numArray;
  }

  public static int[] Decompose(int a, int gamma2)
  {
    int num1 = a + (int) sbyte.MaxValue >> 7;
    int num2;
    if (gamma2 == 261888)
    {
      num2 = num1 * 1025 + 2097152 /*0x200000*/ >> 22 & 15;
    }
    else
    {
      if (gamma2 != 95232)
        throw new ArgumentException("Wrong Gamma2!");
      int num3 = num1 * 11275 + 8388608 /*0x800000*/ >> 24;
      num2 = num3 ^ 43 - num3 >> 31 /*0x1F*/ & num3;
    }
    int num4 = a - num2 * 2 * gamma2;
    return new int[2]
    {
      num4 - (4190208 - num4 >> 31 /*0x1F*/ & 8380417),
      num2
    };
  }

  public static int MakeHint(int a0, int a1, DilithiumEngine engine)
  {
    int gamma2 = engine.Gamma2;
    int num = 8380417;
    return a0 > gamma2 && a0 <= num - gamma2 && (a0 != num - gamma2 || a1 != 0) ? 1 : 0;
  }

  public static int UseHint(int a, int hint, int gamma2)
  {
    int[] numArray = Rounding.Decompose(a, gamma2);
    int num1 = numArray[0];
    int num2 = numArray[1];
    if (hint == 0)
      return num2;
    if (gamma2 == 261888)
      return num1 > 0 ? num2 + 1 & 15 : num2 - 1 & 15;
    if (gamma2 != 95232)
      throw new ArgumentException("Wrong Gamma2!");
    return num1 > 0 ? (num2 != 43 ? num2 + 1 : 0) : (num2 != 0 ? num2 - 1 : 43);
  }
}
