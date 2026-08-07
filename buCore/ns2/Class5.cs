// Decompiled with JetBrains decompiler
// Type: ns2.Class5
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

#nullable disable
namespace ns2;

internal static class Class5
{
  internal static readonly byte[] byte_0 = new byte[64 /*0x40*/];
  internal static readonly byte[] byte_1 = new byte[64 /*0x40*/];

  static Class5()
  {
    for (int index = 0; index < Class5.byte_0.Length; ++index)
    {
      Class5.byte_0[index] = (byte) 54;
      Class5.byte_1[index] = (byte) 92;
    }
  }
}
