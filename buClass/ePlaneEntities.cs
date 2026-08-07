// Decompiled with JetBrains decompiler
// Type: buClass.ePlaneEntities
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class ePlaneEntities : eEntities
{
  public WorkPlane Plane = new WorkPlane();
  public Pnt3D CenterPoint = new Pnt3D();

  public ePlaneEntities()
  {
  }

  public ePlaneEntities(ePlaneEntities ent) => this.Plane = new WorkPlane(ent.Plane);

  public static void CopyPlaneBase(eEntities baseEnt, ref eEntities copiedEnt)
  {
    ((ePlaneEntities) copiedEnt).Plane = new WorkPlane(((ePlaneEntities) baseEnt).Plane);
  }
}
