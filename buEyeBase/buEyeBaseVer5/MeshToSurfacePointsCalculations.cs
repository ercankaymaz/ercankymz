// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MeshToSurfacePointsCalculations
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class MeshToSurfacePointsCalculations : buSerilization5
{
  public double SpindleRpm;
  public double ToolNo;
  public string ToolName;
  public Point3D Offset;
  public int GCode;
  public int Index;
  public bool isMCode;
  public int MCode;
  public double Aux1;
  public double Aux2;

  public MeshToSurfacePointsCalculations(double XPosition)
  {
    ((MeshToSurfacePointsSettings) this).XPosition = 0.0;
    ((MeshToSurfacePointsSettings) this).GeometrixMaxX = 0.0;
    ((MeshToSurfacePointsSettings) this).GeometrixMinX = 0.0;
    ((MeshToSurfacePointsSettings) this).XOffset = 0.0;
    ((MeshToSurfacePointsSettings) this).Width = 100.0;
    ((MeshToSurfacePointsSettings) this).Text = "";
    ((MeshToSurfacePointsSettings) this).MaxPositionRange = 10000.0;
    ((MeshToSurfacePointsSettings) this).MinPositionRange = 0.0;
    ((MeshToSurfacePointsSettings) this).Used = false;
    ((MeshToSurfacePointsSettings) this).Enable = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((MeshToSurfacePointsSettings) this).XPosition = XPosition;
  }

  public MeshToSurfacePointsCalculations(Clamper data)
  {
    ((MeshToSurfacePointsSettings) this).XPosition = 0.0;
    ((MeshToSurfacePointsSettings) this).GeometrixMaxX = 0.0;
    ((MeshToSurfacePointsSettings) this).GeometrixMinX = 0.0;
    ((MeshToSurfacePointsSettings) this).XOffset = 0.0;
    ((MeshToSurfacePointsSettings) this).Width = 100.0;
    ((MeshToSurfacePointsSettings) this).Text = "";
    ((MeshToSurfacePointsSettings) this).MaxPositionRange = 10000.0;
    ((MeshToSurfacePointsSettings) this).MinPositionRange = 0.0;
    ((MeshToSurfacePointsSettings) this).Used = false;
    ((MeshToSurfacePointsSettings) this).Enable = true;
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
}
