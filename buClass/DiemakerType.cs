// Decompiled with JetBrains decompiler
// Type: buClass.DiemakerType
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public enum DiemakerType
{
  None,
  Cutting,
  Creasing,
  Perfo,
  CutCrease,
  Balance,
  Striping,
  Bridge,
  Text,
  Side,
  Normal,
  Border,
  Nick,
  Broach,
  Other,
  WoodChamferTop,
  WoodChamferBottom,
  PertinaxIncut,
  PertinaxOutcut,
  PertinaxHole,
  PertinaxAllCut,
  PertinaxText,
  SteelPlateContour,
  SteelPlatePocket,
  SteelPlateText,
}
