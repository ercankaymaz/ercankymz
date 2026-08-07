// Decompiled with JetBrains decompiler
// Type: buClass.ePointGroup
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

public class ePointGroup : eEntities
{
  public ePointGroup()
  {
  }

  public ePointGroup(List<Pnt3D> Points)
  {
    this.Vertice.Clear();
    Pnt3D.Copy(Points, ref this.Vertice);
    this.Update();
  }

  public ePointGroup(List<Pnt3D> Points, float Thickness, Color Clr)
  {
    this.Vertice.Clear();
    Pnt3D.Copy(Points, ref this.Vertice);
    this.dispThickness = Thickness;
    this.dispColor = Clr;
    this.Update();
  }

  public ePointGroup(eEntities ent)
  {
    if (!(ent.GetType() == typeof (ePointGroup)))
      return;
    this.Vertice.Clear();
    Pnt3D.Copy(ent.Vertice, ref this.Vertice);
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

  public override string ToString() => "ePointGroup - Count :" + this.Vertice.Count.ToString();
}
