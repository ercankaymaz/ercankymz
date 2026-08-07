// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Crc24
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public sealed class Crc24
{
  private const int Crc24Init = 11994318;
  private const int Crc24Poly = 25578747;
  private static readonly int[] Table0;
  private static readonly int[] Table8;
  private static readonly int[] Table16;
  private int m_crc = 11994318;

  static Crc24()
  {
    int[] numArray1 = new int[256 /*0x0100*/];
    int[] numArray2 = new int[256 /*0x0100*/];
    int[] numArray3 = new int[256 /*0x0100*/];
    int num1 = 8388608 /*0x800000*/;
    for (int index1 = 1; index1 < 256 /*0x0100*/; index1 <<= 1)
    {
      int num2 = num1 << 8 >> 31 /*0x1F*/ & 25578747;
      num1 = num1 << 1 ^ num2;
      for (int index2 = 0; index2 < index1; ++index2)
        numArray1[index1 + index2] = num1 ^ numArray1[index2];
    }
    for (int index = 1; index < 256 /*0x0100*/; ++index)
    {
      int num3 = numArray1[index];
      int num4 = (num3 & (int) ushort.MaxValue) << 8 ^ numArray1[num3 >> 16 /*0x10*/ & (int) byte.MaxValue];
      int num5 = (num4 & (int) ushort.MaxValue) << 8 ^ numArray1[num4 >> 16 /*0x10*/ & (int) byte.MaxValue];
      numArray2[index] = num4;
      numArray3[index] = num5;
    }
    Crc24.Table0 = numArray1;
    Crc24.Table8 = numArray2;
    Crc24.Table16 = numArray3;
  }

  public void Update(byte b)
  {
    int index = ((int) b ^ this.m_crc >> 16 /*0x10*/) & (int) byte.MaxValue;
    this.m_crc = this.m_crc << 8 ^ Crc24.Table0[index];
  }

  public void Update3(byte[] buf, int off)
  {
    this.m_crc = Crc24.Table16[((int) buf[off] ^ this.m_crc >> 16 /*0x10*/) & (int) byte.MaxValue] ^ Crc24.Table8[((int) buf[off + 1] ^ this.m_crc >> 8) & (int) byte.MaxValue] ^ Crc24.Table0[((int) buf[off + 2] ^ this.m_crc) & (int) byte.MaxValue];
  }

  public int Value => this.m_crc & 16777215 /*0xFFFFFF*/;

  public void Reset() => this.m_crc = 11994318;
}
