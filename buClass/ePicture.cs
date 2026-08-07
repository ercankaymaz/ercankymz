// Decompiled with JetBrains decompiler
// Type: buClass.ePicture
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;

#nullable disable
namespace buClass;

public class ePicture : ePlaneEntities
{
  public Pnt3D StartPoint = new Pnt3D();
  public Pnt3D EndPoint = new Pnt3D();
  public string PicturePath = "";

  public ePicture()
  {
  }

  public ePicture(Pnt3D Start, Pnt3D End, string Name)
  {
    this.StartPoint = new Pnt3D(Start);
    this.EndPoint = new Pnt3D(End);
    this.PicturePath = Name;
    this.Plane = new WorkPlane();
    this.Update();
  }

  public ePicture(Pnt3D Start, Pnt3D End, string Name, WorkPlane Plane_)
  {
    this.StartPoint = new Pnt3D(Start);
    this.EndPoint = new Pnt3D(End);
    this.PicturePath = Name;
    this.Plane = Plane_;
    this.Update();
  }

  public ePicture(eEntities Ent)
  {
    if (!(Ent.GetType() == typeof (ePicture)))
      return;
    this.PicturePath = ((ePicture) Ent).PicturePath;
    this.Plane = WorkPlane.Copy(((ePlaneEntities) Ent).Plane);
    this.StartPoint = Pnt3D.Copy(((ePicture) Ent).StartPoint);
    this.EndPoint = Pnt3D.Copy(((ePicture) Ent).EndPoint);
    eEntities.CopyBase(Ent, (eEntities) this);
    this.Update();
  }

  public static eEntities DecodePicture(List<string> Codes)
  {
    ePicture RefObject = new ePicture();
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
    return $"ePicture - SP : {this.StartPoint.ToString(3)} - EP : {this.EndPoint.ToString(3)}";
  }
}
