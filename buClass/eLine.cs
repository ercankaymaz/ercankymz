// Decompiled with JetBrains decompiler
// Type: buClass.eLine
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class eLine : eEntities
{
  public Pnt3D StartPoint = new Pnt3D();
  public Pnt3D EndPoint = new Pnt3D();

  public eLine()
  {
  }

  public eLine(Pnt3D StartPoint, Pnt3D EndPoint)
  {
    this.StartPoint = new Pnt3D(StartPoint);
    this.EndPoint = new Pnt3D(EndPoint);
    this.Update();
  }

  public eLine(Pnt3D StartPoint, Pnt3D EndPoint, float Thickness, Color Clr)
  {
    this.StartPoint = new Pnt3D(StartPoint);
    this.EndPoint = new Pnt3D(EndPoint);
    this.dispThickness = Thickness;
    this.dispColor = Clr;
    this.Update();
  }

  public eLine(eEntities ent)
  {
    if (!(ent.GetType() == typeof (eLine)))
      return;
    this.StartPoint = new Pnt3D(((eLine) ent).StartPoint);
    this.EndPoint = new Pnt3D(((eLine) ent).EndPoint);
    eEntities.CopyBase(ent, (eEntities) this);
    this.Update();
  }

  public static eEntities DecodeLine(List<string> Codes)
  {
    eLine RefObject = new eLine();
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
    return $"eLine - SP : {this.StartPoint.ToString(3)} - EP : {this.EndPoint.ToString(3)} - Dir: {this.camDirections.ToString()}";
  }
}
