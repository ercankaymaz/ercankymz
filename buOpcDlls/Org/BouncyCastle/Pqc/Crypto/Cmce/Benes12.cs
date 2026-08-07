// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Cmce.Benes12
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Cmce;

internal class Benes12 : Benes
{
  internal Benes12(int n, int t, int m)
    : base(n, t, m)
  {
  }

  internal static void LayerBenes(ulong[] data, ulong[] bits, int lgs)
  {
    int num1 = 0;
    int num2 = 1 << lgs;
    for (int index1 = 0; index1 < 64 /*0x40*/; index1 += num2 * 2)
    {
      for (int index2 = index1; index2 < index1 + num2; ++index2)
      {
        ulong num3 = (data[index2] ^ data[index2 + num2]) & bits[num1++];
        data[index2] ^= num3;
        data[index2 + num2] ^= num3;
      }
    }
  }

  private void ApplyBenes(byte[] r, byte[] bits, int rev)
  {
    ulong[] numArray1 = new ulong[64 /*0x40*/];
    ulong[] numArray2 = new ulong[64 /*0x40*/];
    Utils.Load8(r, 0, numArray1, 0, 64 /*0x40*/);
    int num;
    int offset;
    if (rev == 0)
    {
      num = 256 /*0x0100*/;
      offset = this.SYS_T * 2 + 40;
    }
    else
    {
      num = -256;
      offset = this.SYS_T * 2 + 40 + (2 * this.GFBITS - 2) * 256 /*0x0100*/;
    }
    Benes.Transpose64x64(numArray1, numArray1);
    for (int lgs = 0; lgs <= 5; ++lgs)
    {
      for (int index = 0; index < 64 /*0x40*/; ++index)
        numArray2[index] = (ulong) Utils.Load4(bits, offset + index * 4);
      Benes.Transpose64x64(numArray2, numArray2);
      Benes12.LayerBenes(numArray1, numArray2, lgs);
      offset += num;
    }
    Benes.Transpose64x64(numArray1, numArray1);
    for (int lgs = 0; lgs <= 5; ++lgs)
    {
      Utils.Load8(bits, offset, numArray2, 0, 32 /*0x20*/);
      Benes12.LayerBenes(numArray1, numArray2, lgs);
      offset += num;
    }
    for (int lgs = 4; lgs >= 0; --lgs)
    {
      Utils.Load8(bits, offset, numArray2, 0, 32 /*0x20*/);
      Benes12.LayerBenes(numArray1, numArray2, lgs);
      offset += num;
    }
    Benes.Transpose64x64(numArray1, numArray1);
    for (int lgs = 5; lgs >= 0; --lgs)
    {
      for (int index = 0; index < 64 /*0x40*/; ++index)
        numArray2[index] = (ulong) Utils.Load4(bits, offset + index * 4);
      Benes.Transpose64x64(numArray2, numArray2);
      Benes12.LayerBenes(numArray1, numArray2, lgs);
      offset += num;
    }
    Benes.Transpose64x64(numArray1, numArray1);
    Utils.Store8(r, 0, numArray1, 0, 64 /*0x40*/);
  }

  internal override void SupportGen(ushort[] s, byte[] c)
  {
    byte[][] numArray = new byte[this.GFBITS][];
    for (int index1 = 0; index1 < this.GFBITS; ++index1)
    {
      for (int index2 = 0; index2 < (1 << this.GFBITS) / 8; ++index2)
        numArray[index1] = new byte[(1 << this.GFBITS) / 8];
    }
    for (ushort a = 0; (int) a < 1 << this.GFBITS; ++a)
    {
      ushort num = Utils.Bitrev(a, this.GFBITS);
      for (int index = 0; index < this.GFBITS; ++index)
        numArray[index][(int) a / 8] |= (byte) (((int) num >> index & 1) << (int) a % 8);
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
