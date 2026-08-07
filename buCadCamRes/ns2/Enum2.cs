// Decompiled with JetBrains decompiler
// Type: ns2.Enum2
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using System;

#nullable disable
namespace ns2;

[Flags]
internal enum Enum2
{
  flag_0 = 1,
  flag_1 = 2,
  flag_2 = 4,
  flag_3 = 8,
  flag_4 = 16, // 0x00000010
  flag_5 = 32, // 0x00000020
  flag_6 = 64, // 0x00000040
  flag_7 = 128, // 0x00000080
  flag_8 = 256, // 0x00000100
  flag_9 = 512, // 0x00000200
  flag_10 = 1024, // 0x00000400
  flag_11 = flag_5, // 0x00000020
  flag_12 = flag_9, // 0x00000200
  flag_13 = 8192, // 0x00002000
  flag_14 = 16384, // 0x00004000
}
