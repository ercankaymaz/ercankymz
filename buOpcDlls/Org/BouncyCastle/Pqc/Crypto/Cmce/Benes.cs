// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Cmce.Benes
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Cmce;

internal abstract class Benes
{
  protected int SYS_N;
  protected int SYS_T;
  protected int GFBITS;

  internal Benes(int n, int t, int m)
  {
    this.SYS_N = n;
    this.SYS_T = t;
    this.GFBITS = m;
  }

  internal static void Transpose64x64(ulong[] output, ulong[] input)
  {
    ulong[,] numArray = new ulong[6, 2]
    {
      {
        6148914691236517205UL /*0x5555555555555555*/,
        12297829382473034410UL /*0xAAAAAAAAAAAAAAAA*/
      },
      {
        3689348814741910323UL /*0x3333333333333333*/,
        14757395258967641292UL /*0xCCCCCCCCCCCCCCCC*/
      },
      {
        1085102592571150095UL,
        17361641481138401520UL /*0xF0F0F0F0F0F0F0F0*/
      },
      {
        71777214294589695UL,
        18374966859414961920UL /*0xFF00FF00FF00FF00*/
      },
      {
        281470681808895UL,
        18446462603027742720UL /*0xFFFF0000FFFF0000*/
      },
      {
        (ulong) uint.MaxValue,
        18446744069414584320UL
      }
    };
    for (int index = 0; index < 64 /*0x40*/; ++index)
      output[index] = input[index];
    for (int index1 = 5; index1 >= 0; --index1)
    {
      int num1 = 1 << index1;
      for (int index2 = 0; index2 < 64 /*0x40*/; index2 += num1 * 2)
      {
        for (int index3 = index2; index3 < index2 + num1; ++index3)
        {
          ulong num2 = (ulong) ((long) output[index3] & (long) numArray[index1, 0] | ((long) output[index3 + num1] & (long) numArray[index1, 0]) << num1);
          ulong num3 = (output[index3] & numArray[index1, 1]) >> num1 | output[index3 + num1] & numArray[index1, 1];
          output[index3] = num2;
          output[index3 + num1] = num3;
        }
      }
    }
  }

  internal static void Transpose64x64(ulong[] output, ulong[] input, int offset)
  {
    ulong[,] numArray = new ulong[6, 2]
    {
      {
        6148914691236517205UL /*0x5555555555555555*/,
        12297829382473034410UL /*0xAAAAAAAAAAAAAAAA*/
      },
      {
        3689348814741910323UL /*0x3333333333333333*/,
        14757395258967641292UL /*0xCCCCCCCCCCCCCCCC*/
      },
      {
        1085102592571150095UL,
        17361641481138401520UL /*0xF0F0F0F0F0F0F0F0*/
      },
      {
        71777214294589695UL,
        18374966859414961920UL /*0xFF00FF00FF00FF00*/
      },
      {
        281470681808895UL,
        18446462603027742720UL /*0xFFFF0000FFFF0000*/
      },
      {
        (ulong) uint.MaxValue,
        18446744069414584320UL
      }
    };
    for (int index = 0; index < 64 /*0x40*/; ++index)
      output[index + offset] = input[index + offset];
    for (int index1 = 5; index1 >= 0; --index1)
    {
      int num1 = 1 << index1;
      for (int index2 = 0; index2 < 64 /*0x40*/; index2 += num1 * 2)
      {
        for (int index3 = index2; index3 < index2 + num1; ++index3)
        {
          ulong num2 = (ulong) ((long) output[index3 + offset] & (long) numArray[index1, 0] | ((long) output[index3 + num1 + offset] & (long) numArray[index1, 0]) << num1);
          ulong num3 = (output[index3 + offset] & numArray[index1, 1]) >> num1 | output[index3 + num1 + offset] & numArray[index1, 1];
          output[index3 + offset] = num2;
          output[index3 + num1 + offset] = num3;
        }
      }
    }
  }

  internal abstract void SupportGen(ushort[] s, byte[] c);
}
