// Decompiled with JetBrains decompiler
// Type: buClass.LibraryRuntime
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class LibraryRuntime : buSerilization
{
  public double dX = 0.0;
  public double dY = 0.0;
  public bool isBasePositionMoved = false;
  public bool isCatchPositionMoved = false;
  public int EntitiyIndex = -1;
  public int DimensionEntityIndex = -1;
  public List<Pnt3D> MovedPoints = new List<Pnt3D>();

  public LibraryRuntime()
  {
  }

  public LibraryRuntime(LibraryRuntime data)
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
    this.MovedPoints.Clear();
    Pnt3D.Copy(data.MovedPoints, ref this.MovedPoints);
  }

  public LibraryRuntime(
    double dx,
    double dy,
    bool isBasePosition,
    bool isCatchPosition,
    int EntIndex)
  {
    this.dX = dx;
    this.dY = dy;
    this.isBasePositionMoved = isBasePosition;
    this.isCatchPositionMoved = isCatchPosition;
    this.EntitiyIndex = EntIndex;
  }

  public override string ToString()
  {
    return $"Ent Index:{this.EntitiyIndex.ToString()} - Dim Index:{this.DimensionEntityIndex.ToString()} - Catch:{this.isCatchPositionMoved.ToString()} - Base:{this.isBasePositionMoved.ToString()}";
  }
}
