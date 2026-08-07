// Decompiled with JetBrains decompiler
// Type: buClass.eUpperLine
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

public class eUpperLine : eLine
{
  public eUpperLine()
  {
  }

  public eUpperLine(Pnt3D StartPoint, Pnt3D EndPoint)
  {
    this.StartPoint = new Pnt3D(StartPoint);
    this.EndPoint = new Pnt3D(EndPoint);
    this.Update();
  }

  public eUpperLine(Pnt3D StartPoint, Pnt3D EndPoint, float Thickness, Color Clr)
  {
    this.StartPoint = new Pnt3D(StartPoint);
    this.EndPoint = new Pnt3D(EndPoint);
    this.dispThickness = Thickness;
    this.dispColor = Clr;
    this.Update();
  }

  public eUpperLine(eEntities ent)
  {
    if (!(ent.GetType() == typeof (eUpperLine)))
      return;
    this.StartPoint = new Pnt3D(((eLine) ent).StartPoint);
    this.EndPoint = new Pnt3D(((eLine) ent).EndPoint);
    eEntities.CopyBase(ent, (eEntities) this);
    this.Update();
  }

  public static eEntities DecodeUpperLine(List<string> Codes)
  {
    eUpperLine RefObject = new eUpperLine();
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
    return $"eUpperLine - SP : {this.StartPoint.ToString(3)} - EP : {this.EndPoint.ToString(3)}";
  }
}
