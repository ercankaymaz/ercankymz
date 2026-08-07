// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber.Cbd
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;

internal static class Cbd
{
  internal static void Eta(Poly r, byte[] bytes, int eta)
  {
    if (eta != 2)
    {
      if (eta != 3)
        throw new ArgumentException("Wrong Eta");
      for (int index1 = 0; index1 < 64 /*0x40*/; ++index1)
      {
        uint uint24 = Pack.LE_To_UInt24(bytes, 3 * index1);
        uint num1 = (uint24 & 2396745U /*0x249249*/) + (uint24 >> 1 & 2396745U /*0x249249*/) + (uint24 >> 2 & 2396745U /*0x249249*/);
        for (int index2 = 0; index2 < 4; ++index2)
        {
          short num2 = (short) ((int) (num1 >> 6 * index2) & 7);
          short num3 = (short) ((int) (num1 >> 6 * index2 + 3) & 7);
          r.m_coeffs[4 * index1 + index2] = (short) ((int) num2 - (int) num3);
        }
      }
    }
    else
    {
      for (int index3 = 0; index3 < 32 /*0x20*/; ++index3)
      {
        uint uint32 = Pack.LE_To_UInt32(bytes, 4 * index3);
        uint num4 = (uint32 & 1431655765U /*0x55555555*/) + (uint32 >> 1 & 1431655765U /*0x55555555*/);
        for (int index4 = 0; index4 < 8; ++index4)
        {
          short num5 = (short) ((int) (num4 >> 4 * index4) & 3);
          short num6 = (short) ((int) (num4 >> 4 * index4 + eta) & 3);
          r.m_coeffs[8 * index3 + index4] = (short) ((int) num5 - (int) num6);
        }
      }
    }
  }
}
