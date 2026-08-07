// Decompiled with JetBrains decompiler
// Type: buClass.eDimLineer
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

public class eDimLineer : eDimension
{
  public Pnt3D StartPoint = new Pnt3D();
  public Pnt3D EndPoint = new Pnt3D();
  public Pnt3D SetPoint = new Pnt3D();
  public bool Aligned = false;

  public eDimLineer()
  {
  }

  public eDimLineer(Pnt3D StartPoint, Pnt3D EndPoint, Pnt3D SetPoint, bool Aligned)
  {
    this.StartPoint = new Pnt3D(StartPoint);
    this.EndPoint = new Pnt3D(EndPoint);
    this.SetPoint = new Pnt3D(SetPoint);
    this.Aligned = Aligned;
    this.Update();
  }

  public eDimLineer(
    Pnt3D StartPoint,
    Pnt3D EndPoint,
    Pnt3D SetPoint,
    bool Aligned,
    float Thickness,
    Color Clr)
  {
    this.StartPoint = new Pnt3D(StartPoint);
    this.EndPoint = new Pnt3D(EndPoint);
    this.SetPoint = new Pnt3D(SetPoint);
    this.Aligned = Aligned;
    this.dispThickness = Thickness;
    this.dispColor = Clr;
    this.Update();
  }

  public eDimLineer(eEntities ent)
  {
    if (!(ent.GetType() == typeof (eDimLineer)))
      return;
    this.StartPoint = new Pnt3D(((eDimLineer) ent).StartPoint);
    this.EndPoint = new Pnt3D(((eDimLineer) ent).EndPoint);
    this.SetPoint = new Pnt3D(((eDimLineer) ent).SetPoint);
    this.TextHeight = ((eDimension) ent).TextHeight;
    this.Aligned = ((eDimLineer) ent).Aligned;
    this.DimData = new DimensionData(((eDimension) ent).DimData);
    eEntities.CopyBase(ent, (eEntities) this);
    this.Update();
  }

  public static eEntities DecodeDimLinear(List<string> Codes)
  {
    eDimLineer RefObject = new eDimLineer();
    List<cParameter> Vars = new List<cParameter>();
    buSerilization.GetClassVariableValuesFromStringCodes(Codes, (object) RefObject, ref Vars);
    if (Vars.Count > 0)
    {
      object ObjPar = (object) RefObject;
      buSerilization.SetClassVariables(ref ObjPar, Vars);
    }
    RefObject.Update();
    return (eEntities) RefObject;
  }

  public override string ToString()
  {
    return $"eDimLineer - SP : {this.StartPoint.ToString(3)} - EP : {this.EndPoint.ToString(3)} - Set Pnt : {this.SetPoint.ToString(3)} - Aligned : {this.Aligned.ToString()} - Type : {this.DimData.Type.ToString()}";
  }
}
