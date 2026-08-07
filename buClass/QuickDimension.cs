// Decompiled with JetBrains decompiler
// Type: buClass.QuickDimension
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class QuickDimension : buSerilization
{
  public bool ForceVertical = false;
  public bool ForceHorizontal = false;
  public bool AngleEnable = false;
  public double Angle = 0.0;
  public double Length = 0.0;
}
