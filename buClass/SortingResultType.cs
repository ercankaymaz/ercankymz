// Decompiled with JetBrains decompiler
// Type: buClass.SortingResultType
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public enum SortingResultType
{
  Error = -1, // 0xFFFFFFFF
  None = 0,
  Done = 1,
  MultipleEntities = 5,
  SelectNextGroup = 6,
  UpperFound = 7,
  Stoped = 8,
}
