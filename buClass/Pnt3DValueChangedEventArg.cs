// Decompiled with JetBrains decompiler
// Type: buClass.Pnt3DValueChangedEventArg
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class Pnt3DValueChangedEventArg
{
  public Pnt3D Point = new Pnt3D();
  public double X = 0.0;
  public double Y = 0.0;
  public double Z = 0.0;
  public AxesEnableXYZ Enable = new AxesEnableXYZ();

  public override string ToString()
  {
    return $"X : {this.Point.X.ToString()} , Y : {this.Point.Y.ToString()} , Z : {this.Point.Z.ToString()}";
  }
}
