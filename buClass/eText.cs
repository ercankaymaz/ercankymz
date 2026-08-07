// Decompiled with JetBrains decompiler
// Type: buClass.eText
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

public class eText : ePlaneEntities
{
  public Pnt3D StartPoint = new Pnt3D();
  public double Height = 0.0;
  public double Angle = 0.0;
  public string TextString = "";
  public Font TextFont = new Font("Arial", 12f);

  public eText()
  {
  }

  public eText(Pnt3D Pnt, string TextString_, double Height_, WorkPlane Plane_)
  {
    this.StartPoint = new Pnt3D(Pnt);
    this.TextString = TextString_;
    this.Height = Height_;
    this.Plane = Plane_;
    this.Update();
  }

  public eText(Pnt3D Pnt, string TextString_, double Height_, Color EntColor, WorkPlane Plane_)
  {
    this.StartPoint = new Pnt3D(Pnt);
    this.TextString = TextString_;
    this.Height = Height_;
    this.dispColor = EntColor;
    this.Plane = Plane_;
    this.Update();
  }

  public eText(eEntities Ent)
  {
    if (!(Ent.GetType() == typeof (eText)))
      return;
    this.TextString = ((eText) Ent).TextString;
    this.Angle = ((eText) Ent).Angle;
    this.Height = ((eText) Ent).Height;
    this.Plane = WorkPlane.Copy(((ePlaneEntities) Ent).Plane);
    this.StartPoint = Pnt3D.Copy(((eText) Ent).StartPoint);
    eEntities.CopyBase(Ent, (eEntities) this);
    this.Update();
  }

  public static eEntities DecodeText(List<string> Codes)
  {
    eText RefObject = new eText();
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
    return $"eText - SP : {this.StartPoint.ToString(3)} - Text : {this.TextString} - Height : {this.Height.ToString("f3")}";
  }
}
