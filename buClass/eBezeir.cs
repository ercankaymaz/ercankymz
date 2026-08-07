// Decompiled with JetBrains decompiler
// Type: buClass.eBezeir
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

public class eBezeir : eCurveEntities
{
  public eBezeir()
  {
  }

  public eBezeir(List<Pnt3D> Points)
  {
    this.ControlPoints.Clear();
    for (int index = 0; index <= Points.Count - 1; ++index)
      this.ControlPoints.Add(new Pnt3D(Points[index]));
    this.Update();
  }

  public eBezeir(List<Pnt3D> Points, float Thickness, Color EntColor)
  {
    this.ControlPoints.Clear();
    for (int index = 0; index <= Points.Count - 1; ++index)
      this.ControlPoints.Add(new Pnt3D(Points[index]));
    this.dispThickness = Thickness;
    this.dispColor = EntColor;
    this.Update();
  }

  public eBezeir(eEntities Ent)
  {
    if (!(Ent.GetType() == typeof (eBezeir)))
      return;
    for (int index = 0; index <= ((eCurveEntities) Ent).ControlPoints.Count - 1; ++index)
      this.ControlPoints.Add(new Pnt3D(((eCurveEntities) Ent).ControlPoints[index]));
    this.StartPoint = Pnt3D.Copy(((eCurveEntities) Ent).StartPoint);
    this.EndPoint = Pnt3D.Copy(((eCurveEntities) Ent).EndPoint);
    eEntities.CopyBase(Ent, (eEntities) this);
    this.Update();
  }

  public static eEntities DecodeBezeir(List<string> Codes)
  {
    eBezeir RefObject = new eBezeir();
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

  public override string ToString() => "eBezeir - Count : " + this.ControlPoints.Count.ToString();
}
