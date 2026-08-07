// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SewingPunteriz
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class SewingPunteriz
{
  public string String;
  public string Data;
  public double Length;
  public double Angle;
  public double Direction;
  public double Height;
  public double Radius;

  public SewingPunteriz(EntityShapeInfo data)
  {
    ((MarbleInfo) this).Width = 0.0;
    ((MarbleInfo) this).Depth = 0.0;
    ((MarbleInfo) this).HeadRadius = 0.0;
    ((MarbleInfo) this).Side = 0;
    ((MarbleInfo) this).Degree = 1;
    ((MarbleInfo) this).CurveType = entitySplineType.BsplineQuadratic;
    ((MarbleInfo) this).BasePoint = new Point3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
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
    ((MarbleInfo) this).BasePoint = new Point3D(((MarbleInfo) data).BasePoint.X, ((MarbleInfo) data).BasePoint.Y, ((MarbleInfo) data).BasePoint.Z);
  }

  public override string ToString() => "Angle: " + this.Angle.ToString("f2");

  public abstract void m0001CF();
}
