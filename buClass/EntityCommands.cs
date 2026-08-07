// Decompiled with JetBrains decompiler
// Type: buClass.EntityCommands
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public enum EntityCommands
{
  FirstStep = 1,
  NormalStep = 2,
  LastStep = 3,
  BackwardCut = 4,
  ForwardCut = 5,
  CircularMove = 6,
  NoneCircularMove = 7,
  DontMoveSafe = 8,
}
