// Decompiled with JetBrains decompiler
// Type: buClass.osnapMethodType
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public enum osnapMethodType
{
  None = -1, // 0xFFFFFFFF
  Osnap = 0,
  Snap = 1,
  Ortho = 2,
  Track = 3,
}
