// Decompiled with JetBrains decompiler
// Type: buClass.eCam
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

public class eCam : eEntities
{
  public CamMoveType MoveType = CamMoveType.G1;
  public int BaseEntityIndex = -1;

  public eCam()
  {
  }

  public eCam(List<Pnt3D> Vertices)
  {
    this.Vertice.Clear();
    for (int index = 0; index <= Vertices.Count - 1; ++index)
      this.Vertice.Add(new Pnt3D(Vertices[index]));
    this.Update();
  }

  public eCam(List<Pnt3D> Vertices, float Thickness, Color Color)
  {
    this.Vertice.Clear();
    for (int index = 0; index <= Vertices.Count - 1; ++index)
      this.Vertice.Add(new Pnt3D(Vertices[index]));
    this.dispThickness = Thickness;
    this.dispColor = Color;
    this.Update();
  }

  public eCam(List<Pnt3D> Vertices, float Thickness, Color Color, CamMoveType move)
  {
    this.Vertice.Clear();
    for (int index = 0; index <= Vertices.Count - 1; ++index)
      this.Vertice.Add(new Pnt3D(Vertices[index]));
    this.dispThickness = Thickness;
    this.dispColor = Color;
    this.MoveType = move;
    this.Update();
  }

  public eCam(eEntities ent)
  {
    if (!(ent.GetType() == typeof (eCam)))
      return;
    Pnt3D.Copy(ent.Vertice, ref this.Vertice);
    this.BaseEntityIndex = ((eCam) ent).BaseEntityIndex;
    eEntities.CopyBase(ent, (eEntities) this);
    this.Update();
  }

  public static eEntities DecodePolyline(List<string> Codes)
  {
    eCam RefObject = new eCam();
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
    string str = "";
    if (this.Vertice.Count > 0)
      str = $"SP: {this.Vertice[0].ToString(3)} EP: {this.Vertice[this.Vertice.Count - 1].ToString(3)}";
    return $"eCam - {str} Count : {this.Vertice.Count.ToString()}";
  }
}
