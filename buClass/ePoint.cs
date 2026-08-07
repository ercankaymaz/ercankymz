// Decompiled with JetBrains decompiler
// Type: buClass.ePoint
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

public class ePoint : eEntities
{
  public Pnt3D StartPoint = new Pnt3D();
  public bool DrawAsCircle = false;

  public ePoint()
  {
  }

  public ePoint(Pnt3D StartPoint)
  {
    this.StartPoint = new Pnt3D(StartPoint);
    this.Update();
  }

  public ePoint(Pnt3D StartPoint, float Thickness, Color Clr)
  {
    this.StartPoint = new Pnt3D(StartPoint);
    this.dispThickness = Thickness;
    this.dispColor = Clr;
    this.Update();
  }

  public ePoint(eEntities ent)
  {
    if (!(ent.GetType() == typeof (ePoint)))
      return;
    this.StartPoint = new Pnt3D(((ePoint) ent).StartPoint);
    this.DrawAsCircle = ((ePoint) ent).DrawAsCircle;
    eEntities.CopyBase(ent, (eEntities) this);
    this.Update();
  }

  public static eEntities DecodePoint(List<string> Codes)
  {
    ePoint RefObject = new ePoint();
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

  public override string ToString() => "ePoint - SP :" + this.StartPoint.ToString(3);
}
