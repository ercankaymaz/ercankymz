// Decompiled with JetBrains decompiler
// Type: buClass.CamSafeForLeave
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public enum CamSafeForLeave
{
  None = 0,
  SmallSafeThenSafe = 1,
  Safe = 2,
  SmallSafe = 3,
  SafeThenAir = 4,
  SmallSafeThenAir = 5,
  Air = 6,
  NotMove = 8,
}
