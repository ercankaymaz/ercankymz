// Decompiled with JetBrains decompiler
// Type: buClass.MoveScaleRotateExtentEventArg
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class MoveScaleRotateExtentEventArg
{
  public MoveScaleRotateStretchVar Data = new MoveScaleRotateStretchVar();
  public MoveScaleRotateStretchType Type = MoveScaleRotateStretchType.StretchXMinus;

  public override string ToString() => "Type : " + this.Type.ToString();
}
