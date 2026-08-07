// Decompiled with JetBrains decompiler
// Type: buClass.Selection
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class Selection : buSerilization
{
  public eEntities Entity = new eEntities();
  public eEntities SubEntity = new eEntities();
  public List<Pnt3D> Vertices = new List<Pnt3D>();
  public List<Pnt3D> ControlPoints = new List<Pnt3D>();
  public List<int> VerticeIndex = new List<int>();
  public List<int> ControlPointsIndex = new List<int>();
  public int Index = -1;
  public int EntityIndex = -1;
  public int ID = -1;
  public int SubIndex = -1;
  public int CloseIndex = -1;
  public int GroupIndex = -1;
  public Pnt3D ClickPoint = new Pnt3D();
  public SelectionClosestType ClosePointType = SelectionClosestType.Start;
  public SelectionType SelectType = SelectionType.None;

  public Selection()
  {
  }

  public Selection(int index) => this.Index = index;

  public Selection(Selection data)
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
    this.ClickPoint = new Pnt3D(data.ClickPoint);
    eEntities copiedEnt1 = new eEntities();
    eEntities.CopyEntity(data.Entity, ref copiedEnt1);
    this.Entity = copiedEnt1;
    eEntities copiedEnt2 = new eEntities();
    eEntities.CopyEntity(data.SubEntity, ref copiedEnt2);
    this.SubEntity = copiedEnt2;
    this.Vertices.Clear();
    Pnt3D.Copy(data.Vertices, ref this.Vertices);
    this.ControlPoints.Clear();
    Pnt3D.Copy(data.ControlPoints, ref this.ControlPoints);
    this.VerticeIndex.Clear();
    for (int index = 0; index <= data.VerticeIndex.Count - 1; ++index)
      this.VerticeIndex.Add(data.VerticeIndex[index]);
    this.ControlPointsIndex.Clear();
    for (int index = 0; index <= data.ControlPointsIndex.Count - 1; ++index)
      this.ControlPointsIndex.Add(data.ControlPointsIndex[index]);
  }

  public override string ToString()
  {
    return $"Index: {this.Index.ToString()} , Entitiy : {this.Entity.GetType().ToString()}";
  }
}
