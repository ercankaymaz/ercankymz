// Decompiled with JetBrains decompiler
// Type: buClass.ShapeEntityIndex
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class ShapeEntityIndex : buSerilization
{
  public int indexEntitySub = -1;
  public int indexEntity = -1;
  public int indexCam = -1;
  public int indexInside = -1;
  public int CamID = -1;
  public int ItemID = -1;
  public int EdgeID = -1;
  public int indexEdge = -1;
  public bool Outside = false;
  public int ID = -1;
  public double Value = 0.0;

  public ShapeEntityIndex()
  {
  }

  public ShapeEntityIndex(int indexentitysub, int indexentity)
  {
    this.indexEntitySub = indexentitysub;
    this.indexEntity = indexentity;
  }

  public ShapeEntityIndex(int indexentitysub, int indexentity, int id, bool outside)
  {
    this.indexEntitySub = indexentitysub;
    this.indexEntity = indexentity;
    this.Outside = outside;
    this.ID = id;
  }

  public ShapeEntityIndex(
    int indexentitysub,
    int indexentity,
    int id,
    bool outside,
    double value)
  {
    this.indexEntitySub = indexentitysub;
    this.indexEntity = indexentity;
    this.Outside = outside;
    this.ID = id;
    this.Value = value;
  }

  public ShapeEntityIndex(
    int indexentitysub,
    int indexentity,
    int id,
    bool outside,
    double value,
    int indexedge)
  {
    this.indexEntitySub = indexentitysub;
    this.indexEntity = indexentity;
    this.Outside = outside;
    this.ID = id;
    this.Value = value;
    this.indexEdge = indexedge;
  }

  public ShapeEntityIndex(
    int indexentitysub,
    int indexentity,
    int id,
    bool outside,
    double value,
    int indexedge,
    int indexcam)
  {
    this.indexEntitySub = indexentitysub;
    this.indexEntity = indexentity;
    this.Outside = outside;
    this.ID = id;
    this.Value = value;
    this.indexEdge = indexedge;
    this.indexCam = indexcam;
  }

  public override string ToString()
  {
    return $"Entity: {this.indexEntity.ToString()} - EntitySub: {this.indexEntitySub.ToString()}";
  }
}
