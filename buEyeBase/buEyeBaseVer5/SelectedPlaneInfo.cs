// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SelectedPlaneInfo
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class SelectedPlaneInfo : buSerilization5
{
  public double RectangleDepth;
  public double RectangleAngle;
  public double RectangleRadius;
  public double RectangleChamfer;
  public double CircleRadius;
  public double CircleDepth;
  public double EllipseRadiusX;
  public double EllipseRadiusY;
  public double EllipseDepth;
  public double EllipseAngle;
  public double PolygonRadius;
  public int PolygonSide;
  public double PolygonDepth;
  public double PolygonAngle;
  public double SlotLength;

  public SelectedPlaneInfo()
  {
    ((SortbuFoundItems) this).Index = -1;
    ((SortbuFoundItems) this).Direction = camPathDirectionType.Normal;
    ((SortbuFoundItems) this).RefPoint = new Point3D();
    ((SortbuFoundItems) this).StartPoint = new Point3D();
    ((SortbuFoundItems) this).NextPoint = new Point3D();
    ((SortbuFoundItems) this).Entity = (Entity) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public SelectedPlaneInfo(SortFoundItems data)
  {
    ((SortbuFoundItems) this).Index = -1;
    ((SortbuFoundItems) this).Direction = camPathDirectionType.Normal;
    ((SortbuFoundItems) this).RefPoint = new Point3D();
    ((SortbuFoundItems) this).StartPoint = new Point3D();
    ((SortbuFoundItems) this).NextPoint = new Point3D();
    ((SortbuFoundItems) this).Entity = (Entity) null;
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
    buVector5.CopyEntities(((SortbuFoundItems) data).Entity, ref ((SortbuFoundItems) this).Entity);
  }

  public override string ToString()
  {
    return $"{((SortbuFoundItems) this).Index.ToString()} - {((SortbuFoundItems) this).Direction.ToString()} - {((SortbuFoundItems) this).Entity.ToString()}";
  }
}
