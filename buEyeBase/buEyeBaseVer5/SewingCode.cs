// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SewingCode
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class SewingCode
{
  public bool SurfaceDelete;
  public bool SolidDelete;
  public bool HatchDelete;
  public ContentAlignment Alignment;
  public MirrorAxisXYType MirrorAxis;
  public bool ShowAligment;
  public bool DeleteOriginal;

  public SewingCode(DeleteTypeEventFormVars data)
  {
    ((SewingInfo) this).PointDelete = false;
    ((SewingInfo) this).PolylinDelete = false;
    ((SewingInfo) this).LineDelete = false;
    ((SewingInfo) this).CircleDelete = false;
    ((SewingInfo) this).ArcDelete = false;
    ((SewingInfo) this).EllipseDelete = false;
    ((SewingInfo) this).EllipseArcDelete = false;
    ((SewingInfo) this).CompositeCurveDelete = false;
    ((SewingVertex) this).CurveDelete = false;
    ((SewingVertex) this).DimensionDelete = false;
    ((SewingVertex) this).RegionDelete = false;
    ((SewingVertex) this).PictureDelete = false;
    ((SewingVertex) this).TextDelete = false;
    ((SewingVertex) this).MeshDelete = false;
    ((SewingVertex) this).BrepDelete = false;
    this.SurfaceDelete = false;
    this.SolidDelete = false;
    this.HatchDelete = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public SewingCode() => ((pageInfo) this).\u002Ector();

  public SewingCode(MirrorEventFormVars data)
  {
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public SewingCode()
  {
    ((SewingPunteriz) this).String = "";
    ((SewingPunteriz) this).Data = "";
    ((SewingPunteriz) this).Length = 0.0;
    ((SewingPunteriz) this).Angle = 0.0;
    ((SewingPunteriz) this).Direction = 0.0;
    ((SewingPunteriz) this).Height = 0.0;
    ((SewingPunteriz) this).Radius = 0.0;
    ((MarbleInfo) this).Width = 0.0;
    ((MarbleInfo) this).Depth = 0.0;
    ((MarbleInfo) this).HeadRadius = 0.0;
    ((MarbleInfo) this).Side = 0;
    ((MarbleInfo) this).Degree = 1;
    ((MarbleInfo) this).CurveType = entitySplineType.BsplineQuadratic;
    ((MarbleInfo) this).BasePoint = new Point3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
