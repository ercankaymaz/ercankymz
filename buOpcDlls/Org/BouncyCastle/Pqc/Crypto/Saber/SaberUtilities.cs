// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Saber.SaberUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Saber;

internal class SaberUtilities
{
  private readonly int SABER_N;
  private readonly int SABER_L;
  private readonly int SABER_ET;
  private readonly int SABER_POLYBYTES;
  private readonly int SABER_EP;
  private readonly int SABER_KEYBYTES;
  private readonly bool usingEffectiveMasking;

  internal SaberUtilities(SaberEngine engine)
  {
    this.SABER_N = engine.N;
    this.SABER_L = engine.L;
    this.SABER_ET = engine.ET;
    this.SABER_POLYBYTES = engine.PolyBytes;
    this.SABER_EP = engine.EP;
    this.SABER_KEYBYTES = engine.KeyBytes;
    this.usingEffectiveMasking = engine.UsingEffectiveMasking;
  }

  public void POLT2BS(byte[] bytes, int byteIndex, short[] data)
  {
    if (this.SABER_ET == 3)
    {
      for (short index1 = 0; (int) index1 < this.SABER_N / 8; ++index1)
      {
        short num = (short) (3 * (int) index1);
        short index2 = (short) (8 * (int) index1);
        bytes[byteIndex + (int) num] = (byte) ((int) data[(int) index2] & 7 | ((int) data[(int) index2 + 1] & 7) << 3 | ((int) data[(int) index2 + 2] & 3) << 6);
        bytes[byteIndex + (int) num + 1] = (byte) ((int) data[(int) index2 + 2] >> 2 & 1 | ((int) data[(int) index2 + 3] & 7) << 1 | ((int) data[(int) index2 + 4] & 7) << 4 | ((int) data[(int) index2 + 5] & 1) << 7);
        bytes[byteIndex + (int) num + 2] = (byte) ((int) data[(int) index2 + 5] >> 1 & 3 | ((int) data[(int) index2 + 6] & 7) << 2 | ((int) data[(int) index2 + 7] & 7) << 5);
      }
    }
    else if (this.SABER_ET == 4)
    {
      for (short index3 = 0; (int) index3 < this.SABER_N / 2; ++index3)
      {
        short num = index3;
        short index4 = (short) (2 * (int) index3);
        bytes[byteIndex + (int) num] = (byte) ((int) data[(int) index4] & 15 | ((int) data[(int) index4 + 1] & 15) << 4);
      }
    }
    else
    {
      if (this.SABER_ET != 6)
        return;
      for (short index5 = 0; (int) index5 < this.SABER_N / 4; ++index5)
      {
        short num = (short) (3 * (int) index5);
        short index6 = (short) (4 * (int) index5);
        bytes[byteIndex + (int) num] = (byte) ((int) data[(int) index6] & 63 /*0x3F*/ | ((int) data[(int) index6 + 1] & 3) << 6);
        bytes[byteIndex + (int) num + 1] = (byte) ((int) data[(int) index6 + 1] >> 2 & 15 | ((int) data[(int) index6 + 2] & 15) << 4);
        bytes[byteIndex + (int) num + 2] = (byte) ((int) data[(int) index6 + 2] >> 4 & 3 | ((int) data[(int) index6 + 3] & 63 /*0x3F*/) << 2);
      }
    }
  }

  public void BS2POLT(byte[] bytes, int byteIndex, short[] data)
  {
    if (this.SABER_ET == 3)
    {
      for (short index1 = 0; (int) index1 < this.SABER_N / 8; ++index1)
      {
        short num = (short) (3 * (int) index1);
        short index2 = (short) (8 * (int) index1);
        data[(int) index2] = (short) ((int) bytes[byteIndex + (int) num] & 7);
        data[(int) index2 + 1] = (short) ((int) bytes[byteIndex + (int) num] >> 3 & 7);
        data[(int) index2 + 2] = (short) ((int) bytes[byteIndex + (int) num] >> 6 & 3 | ((int) bytes[byteIndex + (int) num + 1] & 1) << 2);
        data[(int) index2 + 3] = (short) ((int) bytes[byteIndex + (int) num + 1] >> 1 & 7);
        data[(int) index2 + 4] = (short) ((int) bytes[byteIndex + (int) num + 1] >> 4 & 7);
        data[(int) index2 + 5] = (short) ((int) bytes[byteIndex + (int) num + 1] >> 7 & 1 | ((int) bytes[byteIndex + (int) num + 2] & 3) << 1);
        data[(int) index2 + 6] = (short) ((int) bytes[byteIndex + (int) num + 2] >> 2 & 7);
        data[(int) index2 + 7] = (short) ((int) bytes[byteIndex + (int) num + 2] >> 5 & 7);
      }
    }
    else if (this.SABER_ET == 4)
    {
      for (short index3 = 0; (int) index3 < this.SABER_N / 2; ++index3)
      {
        short num = index3;
        short index4 = (short) (2 * (int) index3);
        data[(int) index4] = (short) ((int) bytes[byteIndex + (int) num] & 15);
        data[(int) index4 + 1] = (short) ((int) bytes[byteIndex + (int) num] >> 4 & 15);
      }
    }
    else
    {
      if (this.SABER_ET != 6)
        return;
      for (short index5 = 0; (int) index5 < this.SABER_N / 4; ++index5)
      {
        short num = (short) (3 * (int) index5);
        short index6 = (short) (4 * (int) index5);
        data[(int) index6] = (short) ((int) bytes[byteIndex + (int) num] & 63 /*0x3F*/);
        data[(int) index6 + 1] = (short) ((int) bytes[byteIndex + (int) num] >> 6 & 3 | ((int) bytes[byteIndex + (int) num + 1] & 15) << 2);
        data[(int) index6 + 2] = (short) (((int) bytes[byteIndex + (int) num + 1] & (int) byte.MaxValue) >> 4 | ((int) bytes[byteIndex + (int) num + 2] & 3) << 4);
        data[(int) index6 + 3] = (short) (((int) bytes[byteIndex + (int) num + 2] & (int) byte.MaxValue) >> 2);
      }
    }
  }

  private void POLq2BS(byte[] bytes, int byteIndex, short[] data)
  {
    if (!this.usingEffectiveMasking)
    {
      for (short index1 = 0; (int) index1 < this.SABER_N / 8; ++index1)
      {
        short num = (short) (13 * (int) index1);
        short index2 = (short) (8 * (int) index1);
        bytes[byteIndex + (int) num] = (byte) ((uint) data[(int) index2] & (uint) byte.MaxValue);
        bytes[byteIndex + (int) num + 1] = (byte) ((int) data[(int) index2] >> 8 & 31 /*0x1F*/ | ((int) data[(int) index2 + 1] & 7) << 5);
        bytes[byteIndex + (int) num + 2] = (byte) ((int) data[(int) index2 + 1] >> 3 & (int) byte.MaxValue);
        bytes[byteIndex + (int) num + 3] = (byte) ((int) data[(int) index2 + 1] >> 11 & 3 | ((int) data[(int) index2 + 2] & 63 /*0x3F*/) << 2);
        bytes[byteIndex + (int) num + 4] = (byte) ((int) data[(int) index2 + 2] >> 6 & (int) sbyte.MaxValue | ((int) data[(int) index2 + 3] & 1) << 7);
        bytes[byteIndex + (int) num + 5] = (byte) ((int) data[(int) index2 + 3] >> 1 & (int) byte.MaxValue);
        bytes[byteIndex + (int) num + 6] = (byte) ((int) data[(int) index2 + 3] >> 9 & 15 | ((int) data[(int) index2 + 4] & 15) << 4);
        bytes[byteIndex + (int) num + 7] = (byte) ((int) data[(int) index2 + 4] >> 4 & (int) byte.MaxValue);
        bytes[byteIndex + (int) num + 8] = (byte) ((int) data[(int) index2 + 4] >> 12 & 1 | ((int) data[(int) index2 + 5] & (int) sbyte.MaxValue) << 1);
        bytes[byteIndex + (int) num + 9] = (byte) ((int) data[(int) index2 + 5] >> 7 & 63 /*0x3F*/ | ((int) data[(int) index2 + 6] & 3) << 6);
        bytes[byteIndex + (int) num + 10] = (byte) ((int) data[(int) index2 + 6] >> 2 & (int) byte.MaxValue);
        bytes[byteIndex + (int) num + 11] = (byte) ((int) data[(int) index2 + 6] >> 10 & 7 | ((int) data[(int) index2 + 7] & 31 /*0x1F*/) << 3);
        bytes[byteIndex + (int) num + 12] = (byte) ((int) data[(int) index2 + 7] >> 5 & (int) byte.MaxValue);
      }
    }
    else
    {
      for (short index3 = 0; (int) index3 < this.SABER_N / 2; ++index3)
      {
        short num = (short) (3 * (int) index3);
        short index4 = (short) (2 * (int) index3);
        bytes[byteIndex + (int) num] = (byte) ((uint) data[(int) index4] & (uint) byte.MaxValue);
        bytes[byteIndex + (int) num + 1] = (byte) ((int) data[(int) index4] >> 8 & 15 | ((int) data[(int) index4 + 1] & 15) << 4);
        bytes[byteIndex + (int) num + 2] = (byte) ((int) data[(int) index4 + 1] >> 4 & (int) byte.MaxValue);
      }
    }
  }

  private void BS2POLq(byte[] bytes, int byteIndex, short[] data)
  {
    if (!this.usingEffectiveMasking)
    {
      for (short index1 = 0; (int) index1 < this.SABER_N / 8; ++index1)
      {
        short num = (short) (13 * (int) index1);
        short index2 = (short) (8 * (int) index1);
        data[(int) index2] = (short) ((int) bytes[byteIndex + (int) num] & (int) byte.MaxValue | ((int) bytes[byteIndex + (int) num + 1] & 31 /*0x1F*/) << 8);
        data[(int) index2 + 1] = (short) ((int) bytes[byteIndex + (int) num + 1] >> 5 & 7 | ((int) bytes[byteIndex + (int) num + 2] & (int) byte.MaxValue) << 3 | ((int) bytes[byteIndex + (int) num + 3] & 3) << 11);
        data[(int) index2 + 2] = (short) ((int) bytes[byteIndex + (int) num + 3] >> 2 & 63 /*0x3F*/ | ((int) bytes[byteIndex + (int) num + 4] & (int) sbyte.MaxValue) << 6);
        data[(int) index2 + 3] = (short) ((int) bytes[byteIndex + (int) num + 4] >> 7 & 1 | ((int) bytes[byteIndex + (int) num + 5] & (int) byte.MaxValue) << 1 | ((int) bytes[byteIndex + (int) num + 6] & 15) << 9);
        data[(int) index2 + 4] = (short) ((int) bytes[byteIndex + (int) num + 6] >> 4 & 15 | ((int) bytes[byteIndex + (int) num + 7] & (int) byte.MaxValue) << 4 | ((int) bytes[byteIndex + (int) num + 8] & 1) << 12);
        data[(int) index2 + 5] = (short) ((int) bytes[byteIndex + (int) num + 8] >> 1 & (int) sbyte.MaxValue | ((int) bytes[byteIndex + (int) num + 9] & 63 /*0x3F*/) << 7);
        data[(int) index2 + 6] = (short) ((int) bytes[byteIndex + (int) num + 9] >> 6 & 3 | ((int) bytes[byteIndex + (int) num + 10] & (int) byte.MaxValue) << 2 | ((int) bytes[byteIndex + (int) num + 11] & 7) << 10);
        data[(int) index2 + 7] = (short) ((int) bytes[byteIndex + (int) num + 11] >> 3 & 31 /*0x1F*/ | ((int) bytes[byteIndex + (int) num + 12] & (int) byte.MaxValue) << 5);
      }
    }
    else
    {
      for (short index3 = 0; (int) index3 < this.SABER_N / 2; ++index3)
      {
        short num = (short) (3 * (int) index3);
        short index4 = (short) (2 * (int) index3);
        data[(int) index4] = (short) ((int) bytes[byteIndex + (int) num] & (int) byte.MaxValue | ((int) bytes[byteIndex + (int) num + 1] & 15) << 8);
        data[(int) index4 + 1] = (short) ((int) bytes[byteIndex + (int) num + 1] >> 4 & 15 | ((int) bytes[byteIndex + (int) num + 2] & (int) byte.MaxValue) << 4);
      }
    }
  }

  private void POLp2BS(byte[] bytes, int byteIndex, short[] data)
  {
    for (short index1 = 0; (int) index1 < this.SABER_N / 4; ++index1)
    {
      short num = (short) (5 * (int) index1);
      short index2 = (short) (4 * (int) index1);
      bytes[byteIndex + (int) num] = (byte) ((uint) data[(int) index2] & (uint) byte.MaxValue);
      bytes[byteIndex + (int) num + 1] = (byte) ((int) data[(int) index2] >> 8 & 3 | ((int) data[(int) index2 + 1] & 63 /*0x3F*/) << 2);
      bytes[byteIndex + (int) num + 2] = (byte) ((int) data[(int) index2 + 1] >> 6 & 15 | ((int) data[(int) index2 + 2] & 15) << 4);
      bytes[byteIndex + (int) num + 3] = (byte) ((int) data[(int) index2 + 2] >> 4 & 63 /*0x3F*/ | ((int) data[(int) index2 + 3] & 3) << 6);
      bytes[byteIndex + (int) num + 4] = (byte) ((int) data[(int) index2 + 3] >> 2 & (int) byte.MaxValue);
    }
  }

  public void BS2POLp(byte[] bytes, int byteIndex, short[] data)
  {
    for (short index1 = 0; (int) index1 < this.SABER_N / 4; ++index1)
    {
      short num = (short) (5 * (int) index1);
      short index2 = (short) (4 * (int) index1);
      data[(int) index2] = (short) ((int) bytes[byteIndex + (int) num] & (int) byte.MaxValue | ((int) bytes[byteIndex + (int) num + 1] & 3) << 8);
      data[(int) index2 + 1] = (short) ((int) bytes[byteIndex + (int) num + 1] >> 2 & 63 /*0x3F*/ | ((int) bytes[byteIndex + (int) num + 2] & 15) << 6);
      data[(int) index2 + 2] = (short) ((int) bytes[byteIndex + (int) num + 2] >> 4 & 15 | ((int) bytes[byteIndex + (int) num + 3] & 63 /*0x3F*/) << 4);
      data[(int) index2 + 3] = (short) ((int) bytes[byteIndex + (int) num + 3] >> 6 & 3 | ((int) bytes[byteIndex + (int) num + 4] & (int) byte.MaxValue) << 2);
    }
  }

  public void POLVECq2BS(byte[] bytes, short[][] data)
  {
    for (byte index = 0; (int) index < this.SABER_L; ++index)
      this.POLq2BS(bytes, (int) index * this.SABER_POLYBYTES, data[(int) index]);
  }

  public void BS2POLVECq(byte[] bytes, int byteIndex, short[][] data)
  {
    for (byte index = 0; (int) index < this.SABER_L; ++index)
      this.BS2POLq(bytes, byteIndex + (int) index * this.SABER_POLYBYTES, data[(int) index]);
  }

  public void POLVECp2BS(byte[] bytes, short[][] data)
  {
    for (byte index = 0; (int) index < this.SABER_L; ++index)
      this.POLp2BS(bytes, (int) index * (this.SABER_EP * this.SABER_N / 8), data[(int) index]);
  }

  public void BS2POLVECp(byte[] bytes, short[][] data)
  {
    for (byte index = 0; (int) index < this.SABER_L; ++index)
      this.BS2POLp(bytes, (int) index * (this.SABER_EP * this.SABER_N / 8), data[(int) index]);
  }

  public void BS2POLmsg(byte[] bytes, short[] data)
  {
    for (byte index1 = 0; (int) index1 < this.SABER_KEYBYTES; ++index1)
    {
      for (byte index2 = 0; index2 < (byte) 8; ++index2)
        data[(int) index1 * 8 + (int) index2] = (short) ((int) bytes[(int) index1] >> (int) index2 & 1);
    }
  }

  public void POLmsg2BS(byte[] bytes, short[] data)
  {
    for (byte index1 = 0; (int) index1 < this.SABER_KEYBYTES; ++index1)
    {
      for (byte index2 = 0; index2 < (byte) 8; ++index2)
        bytes[(int) index1] = (byte) ((uint) bytes[(int) index1] | ((uint) data[(int) index1 * 8 + (int) index2] & 1U) << (int) index2);
    }
  }
}
