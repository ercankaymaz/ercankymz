// Decompiled with JetBrains decompiler
// Type: buClass.SurfaceFromProfileAndHeight
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class SurfaceFromProfileAndHeight : buSerilization
{
  public List<Pnt3D> ContourPoints = new List<Pnt3D>();
  public List<List<Pnt3D>> XDirPoints = new List<List<Pnt3D>>();
  public List<List<Pnt3D>> YDirPoints = new List<List<Pnt3D>>();
  public eEntities ContourEntity = new eEntities();
  public List<eEntities> XDirEntities = new List<eEntities>();
  public List<eEntities> YDirEntities = new List<eEntities>();
  public double ZHeightValue = 0.0;
  public ZHeightProfileType ZType = ZHeightProfileType.Linear;

  public SurfaceFromProfileAndHeight()
  {
  }

  public SurfaceFromProfileAndHeight(SurfaceFromProfileAndHeight data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    this.ContourPoints.Clear();
    this.ContourPoints = new List<Pnt3D>();
    Pnt3D.Copy(data.ContourPoints, ref this.ContourPoints);
    this.XDirPoints.Clear();
    this.XDirPoints = new List<List<Pnt3D>>();
    Pnt3D.Copy(data.XDirPoints, ref this.XDirPoints);
    this.YDirPoints.Clear();
    this.YDirPoints = new List<List<Pnt3D>>();
    Pnt3D.Copy(data.YDirPoints, ref this.YDirPoints);
    eEntities.CopyEntity(data.ContourEntity, ref this.ContourEntity);
    eEntities.CopyEntities(data.XDirEntities, ref this.XDirEntities);
    eEntities.CopyEntities(data.YDirEntities, ref this.YDirEntities);
  }
}
