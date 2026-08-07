// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Cmce.Benes13
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Cmce;

internal class Benes13 : Benes
{
  internal Benes13(int n, int t, int m)
    : base(n, t, m)
  {
  }

  internal static void LayerIn(ulong[] data, ulong[] bits, int lgs)
  {
    int num1 = 0;
    int num2 = 1 << lgs;
    for (int index1 = 0; index1 < 64 /*0x40*/; index1 += num2 * 2)
    {
      for (int index2 = index1; index2 < index1 + num2; ++index2)
      {
        long num3 = (long) (data[index2] ^ data[index2 + num2]);
        ulong[] numArray1 = bits;
        int index3 = num1;
        int num4 = index3 + 1;
        long num5 = (long) numArray1[index3];
        ulong num6 = (ulong) (num3 & num5);
        data[index2] ^= num6;
        data[index2 + num2] ^= num6;
        long num7 = (long) (data[64 /*0x40*/ + index2] ^ data[64 /*0x40*/ + index2 + num2]);
        ulong[] numArray2 = bits;
        int index4 = num4;
        num1 = index4 + 1;
        long num8 = (long) numArray2[index4];
        ulong num9 = (ulong) (num7 & num8);
        data[64 /*0x40*/ + index2] ^= num9;
        data[64 /*0x40*/ + index2 + num2] ^= num9;
      }
    }
  }

  internal static void LayerEx(ulong[] data, ulong[] bits, int lgs)
  {
    int num1 = 0;
    int num2 = 1 << lgs;
    for (int index1 = 0; index1 < 128 /*0x80*/; index1 += num2 * 2)
    {
      for (int index2 = index1; index2 < index1 + num2; ++index2)
      {
        ulong num3 = (data[index2] ^ data[index2 + num2]) & bits[num1++];
        data[index2] ^= num3;
        data[index2 + num2] ^= num3;
      }
    }
  }

  internal void ApplyBenes(byte[] r, byte[] bits, int rev)
  {
    int num1 = 0;
    ulong[] numArray1 = new ulong[128 /*0x80*/];
    ulong[] numArray2 = new ulong[128 /*0x80*/];
    ulong[] numArray3 = new ulong[64 /*0x40*/];
    ulong[] numArray4 = new ulong[64 /*0x40*/];
    int offset;
    int num2;
    if (rev == 0)
    {
      offset = this.SYS_T * 2 + 40;
      num2 = 0;
    }
    else
    {
      offset = this.SYS_T * 2 + 40 + 12288 /*0x3000*/;
      num2 = -1024;
    }
    for (int index = 0; index < 64 /*0x40*/; ++index)
    {
      numArray1[index] = Utils.Load8(r, num1 + index * 16 /*0x10*/);
      numArray1[index + 64 /*0x40*/] = Utils.Load8(r, num1 + index * 16 /*0x10*/ + 8);
    }
    Benes.Transpose64x64(numArray2, numArray1, 0);
    Benes.Transpose64x64(numArray2, numArray1, 64 /*0x40*/);
    for (int lgs = 0; lgs <= 6; ++lgs)
    {
      for (int index = 0; index < 64 /*0x40*/; ++index)
      {
        numArray3[index] = Utils.Load8(bits, offset);
        offset += 8;
      }
      offset += num2;
      Benes.Transpose64x64(numArray4, numArray3);
      Benes13.LayerEx(numArray2, numArray4, lgs);
    }
    Benes.Transpose64x64(numArray1, numArray2, 0);
    Benes.Transpose64x64(numArray1, numArray2, 64 /*0x40*/);
    for (int lgs = 0; lgs <= 5; ++lgs)
    {
      for (int index = 0; index < 64 /*0x40*/; ++index)
      {
        numArray3[index] = Utils.Load8(bits, offset);
        offset += 8;
      }
      offset += num2;
      Benes13.LayerIn(numArray1, numArray3, lgs);
    }
    for (int lgs = 4; lgs >= 0; --lgs)
    {
      for (int index = 0; index < 64 /*0x40*/; ++index)
      {
        numArray3[index] = Utils.Load8(bits, offset);
        offset += 8;
      }
      offset += num2;
      Benes13.LayerIn(numArray1, numArray3, lgs);
    }
    Benes.Transpose64x64(numArray2, numArray1, 0);
    Benes.Transpose64x64(numArray2, numArray1, 64 /*0x40*/);
    for (int lgs = 6; lgs >= 0; --lgs)
    {
      for (int index = 0; index < 64 /*0x40*/; ++index)
      {
        numArray3[index] = Utils.Load8(bits, offset);
        offset += 8;
      }
      offset += num2;
      Benes.Transpose64x64(numArray4, numArray3);
      Benes13.LayerEx(numArray2, numArray4, lgs);
    }
    Benes.Transpose64x64(numArray1, numArray2, 0);
    Benes.Transpose64x64(numArray1, numArray2, 64 /*0x40*/);
    for (int index = 0; index < 64 /*0x40*/; ++index)
    {
      Utils.Store8(r, num1 + index * 16 /*0x10*/, numArray1[index]);
      Utils.Store8(r, num1 + index * 16 /*0x10*/ + 8, numArray1[64 /*0x40*/ + index]);
    }
  }

  internal override void SupportGen(ushort[] s, byte[] c)
  {
    byte[][] numArray = new byte[this.GFBITS][];
    for (int index1 = 0; index1 < this.GFBITS; ++index1)
    {
      for (int index2 = 0; index2 < (1 << this.GFBITS) / 8; ++index2)
        numArray[index1] = new byte[(1 << this.GFBITS) / 8];
    }
    for (int a = 0; a < 1 << this.GFBITS; ++a)
    {
      ushort num = Utils.Bitrev((ushort) a, this.GFBITS);
      for (int index = 0; index < this.GFBITS; ++index)
        numArray[index][a / 8] |= (byte) (((int) num >> index & 1) << a % 8);
    }
    for (int index = 0; index < this.GFBITS; ++index)
      this.ApplyBenes(numArray[index], c, 0);
    for (int index3 = 0; index3 < this.SYS_N; ++index3)
    {
      s[index3] = (ushort) 0;
      for (int index4 = this.GFBITS - 1; index4 >= 0; --index4)
      {
        s[index3] <<= 1;
        s[index3] |= (ushort) ((int) numArray[index4][index3 / 8] >> index3 % 8 & 1);
      }
    }
  }
}
