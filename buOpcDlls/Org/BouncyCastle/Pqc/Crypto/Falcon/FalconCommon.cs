// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Falcon.FalconCommon
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Falcon;

internal class FalconCommon
{
  internal uint[] l2bound = new uint[11]
  {
    0U,
    101498U,
    208714U,
    428865U,
    892039U,
    1852696U,
    3842630U,
    7959734U,
    16468416U,
    34034726U,
    70265242U
  };

  internal void hash_to_point_vartime(SHAKE256 sc, ushort[] xsrc, int x, uint logn)
  {
    int num1 = 1 << (int) logn;
    while (num1 > 0)
    {
      byte[] outsrc = new byte[2];
      sc.i_shake256_extract(outsrc, 0, 2);
      uint num2 = (uint) outsrc[0] << 8 | (uint) outsrc[1];
      if (num2 < 61445U)
      {
        while (num2 >= 12289U)
          num2 -= 12289U;
        xsrc[x++] = (ushort) num2;
        --num1;
      }
    }
  }

  internal bool is_short(short[] s1src, int s1, short[] s2src, int s2, uint logn)
  {
    int num1 = 1 << (int) logn;
    uint num2 = 0;
    uint num3 = 0;
    for (int index = 0; index < num1; ++index)
    {
      int num4 = (int) s1src[s1 + index];
      uint num5 = num2 + (uint) (num4 * num4);
      uint num6 = num3 | num5;
      int num7 = (int) s2src[s2 + index];
      num2 = num5 + (uint) (num7 * num7);
      num3 = num6 | num2;
    }
    return (num2 | -(num3 >> 31 /*0x1F*/)) <= this.l2bound[(int) logn];
  }

  internal bool is_short_half(uint sqn, short[] s2src, int s2, uint logn)
  {
    int num1 = 1 << (int) logn;
    uint num2 = -(sqn >> 31 /*0x1F*/);
    for (int index = 0; index < num1; ++index)
    {
      int num3 = (int) s2src[s2 + index];
      sqn += (uint) (num3 * num3);
      num2 |= sqn;
    }
    sqn |= -(num2 >> 31 /*0x1F*/);
    return sqn <= this.l2bound[(int) logn];
  }
}
