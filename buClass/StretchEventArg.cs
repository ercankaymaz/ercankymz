// Decompiled with JetBrains decompiler
// Type: buClass.StretchEventArg
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;

#nullable disable
namespace buClass;

public class StretchEventArg
{
  public Pnt3D BasePoint = new Pnt3D();
  public Pnt3D MinPoint = new Pnt3D();
  public Pnt3D MaxPoint = new Pnt3D();
  public VectorType StretchDirection = VectorType.XVector;
  public double StretchValue = 1.0;
  public double EntityMaxDistance = 0.0;
  public PlusMinus Sign = PlusMinus.Plus;
  public bool ScaleRational = false;
  public bool UseRatioFromXPoint = false;
  public double XRatioPosition = 0.0;
  public bool UseRatioFromYPoint = false;
  public double YRatioPosition = 0.0;
  public List<Pnt3D> SelectedAreaPoints = new List<Pnt3D>();

  public StretchEventArg()
  {
  }

  public StretchEventArg(
    Pnt3D basePoint,
    VectorType stretchDirection,
    double stretchValue,
    double entityMaxDistance,
    PlusMinus sign,
    bool scaleRational,
    List<Pnt3D> selectedAreaPoints)
  {
    this.BasePoint = new Pnt3D(basePoint);
    this.StretchDirection = stretchDirection;
    this.StretchValue = stretchValue;
    this.EntityMaxDistance = entityMaxDistance;
    this.Sign = sign;
    this.ScaleRational = scaleRational;
    this.SelectedAreaPoints.Clear();
    Pnt3D.Copy(selectedAreaPoints, ref this.SelectedAreaPoints);
  }

  public override string ToString() => "StretchValue : " + this.StretchValue.ToString();
}
