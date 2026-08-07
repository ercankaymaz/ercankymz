// Decompiled with JetBrains decompiler
// Type: buClass.eSurfaceNull
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class eSurfaceNull : eEntities
{
  public eSurfaceNull() => this.Triangles = new List<Triangle3D>();

  public eSurfaceNull(eEntities ent)
  {
    if (!(ent.GetType() == typeof (eSurfaceNull)))
      return;
    this.Triangles = new List<Triangle3D>();
    for (int index = 0; index <= ent.Triangles.Count - 1; ++index)
    {
      this.Triangles.Add(new Triangle3D(ent.Triangles[index]));
      this.Vertice.Add(new Pnt3D(this.Triangles[index].FirstPoint));
      this.Vertice.Add(new Pnt3D(this.Triangles[index].SecondPoint));
      this.Vertice.Add(new Pnt3D(this.Triangles[index].ThirdPoint));
    }
    eEntities.CopyBase(ent, (eEntities) this);
    this.Update();
  }

  public static eSurfaceNull DecodeSolid(List<string> Codes)
  {
    eSurfaceNull RefObject = new eSurfaceNull();
    List<cParameter> Vars = new List<cParameter>();
    buSerilization.GetClassVariableValuesFromStringCodes(Codes, (object) RefObject, ref Vars);
    if (Vars.Count > 0)
    {
      object ObjPar = (object) RefObject;
      buSerilization.SetClassVariables(ref ObjPar, Vars);
    }
    RefObject.Update();
    return RefObject;
  }
}
