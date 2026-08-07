// Decompiled with JetBrains decompiler
// Type: buClass.ePolylineGroup
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

public class ePolylineGroup : eEntities
{
  public List<List<Pnt3D>> GroupVertices = new List<List<Pnt3D>>();
  public List<List<Pnt3D>> InternalVertices = new List<List<Pnt3D>>();

  public ePolylineGroup()
  {
  }

  public ePolylineGroup(List<List<Pnt3D>> groupVertices)
  {
    this.GroupVertices.Clear();
    this.InternalVertices.Clear();
    Pnt3D.Copy(groupVertices, ref this.GroupVertices);
    this.Update();
  }

  public ePolylineGroup(List<List<Pnt3D>> groupVertices, List<List<Pnt3D>> internalVertices)
  {
    this.GroupVertices.Clear();
    this.InternalVertices.Clear();
    Pnt3D.Copy(groupVertices, ref this.GroupVertices);
    Pnt3D.Copy(internalVertices, ref this.InternalVertices);
    this.Update();
  }

  public ePolylineGroup(float Thickness, Color Color)
  {
    this.GroupVertices.Clear();
    this.InternalVertices.Clear();
    this.dispThickness = Thickness;
    this.dispColor = Color;
    this.Update();
  }

  public ePolylineGroup(List<List<Pnt3D>> groupVertices, float Thickness, Color Color)
  {
    this.GroupVertices.Clear();
    this.InternalVertices.Clear();
    Pnt3D.Copy(groupVertices, ref this.GroupVertices);
    this.dispThickness = Thickness;
    this.dispColor = Color;
    this.Update();
  }

  public ePolylineGroup(
    List<List<Pnt3D>> groupVertices,
    List<List<Pnt3D>> internalVertices,
    float Thickness,
    Color Color)
  {
    this.GroupVertices.Clear();
    this.InternalVertices.Clear();
    Pnt3D.Copy(groupVertices, ref this.GroupVertices);
    Pnt3D.Copy(internalVertices, ref this.InternalVertices);
    this.dispThickness = Thickness;
    this.dispColor = Color;
    this.Update();
  }

  public ePolylineGroup(eEntities ent)
  {
    if (!(ent.GetType() == typeof (ePolylineGroup)))
      return;
    this.GroupVertices.Clear();
    this.InternalVertices.Clear();
    Pnt3D.Copy(((ePolylineGroup) ent).GroupVertices, ref this.GroupVertices);
    Pnt3D.Copy(((ePolylineGroup) ent).InternalVertices, ref this.InternalVertices);
    eEntities.CopyBase(ent, (eEntities) this);
    this.Update();
  }

  public static ePolylineGroup DecodePolyline(List<string> Codes)
  {
    ePolylineGroup RefObject = new ePolylineGroup();
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

  public override string ToString()
  {
    int count = this.GroupVertices.Count;
    string str1 = count.ToString();
    count = this.InternalVertices.Count;
    string str2 = count.ToString();
    return $"ePolylineGroup -  Group Count : {str1} InternalCount : {str2}";
  }
}
