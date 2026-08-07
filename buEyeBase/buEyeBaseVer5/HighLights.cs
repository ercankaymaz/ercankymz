// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.HighLights
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class HighLights
{
  public double MaxZ;
  public double MinZ;
  public double InsideOffset;

  public HighLights(SortbuFoundItems data)
  {
    ((ShapeRuntimeData) this).Index = -1;
    ((ShapeRuntimeData) this).BaseIndex = -1;
    ((ShapeRuntimeData) this).Direction = camPathDirectionType.Normal;
    ((ShapeRuntimeData) this).RefPoint = new Point3D();
    ((ShapeRuntimeData) this).StartPoint = new Point3D();
    ((ShapeRuntimeData) this).NextPoint = new Point3D();
    ((ShapeRuntimeData) this).Entity = (buEntity) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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
    buDiametricDim.Copy(((ShapeRuntimeData) data).Entity, ref ((ShapeRuntimeData) this).Entity);
  }
}
