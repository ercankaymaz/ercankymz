// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.HitSurfacePointsSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class HitSurfacePointsSettings : buSerilization5
{
  public double Height;
  public double Depth;
  public double Thickness;

  public HitSurfacePointsSettings()
  {
    ((MeshToSurfacePointsSettings) this).AngleXY = 0.0;
    ((MeshToSurfacePointsSettings) this).AngleXZ = 0.0;
    ((MeshToSurfacePointsSettings) this).AngleYZ = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public HitSurfacePointsSettings(PlaneAngle data)
  {
    ((MeshToSurfacePointsSettings) this).AngleXY = 0.0;
    ((MeshToSurfacePointsSettings) this).AngleXZ = 0.0;
    ((MeshToSurfacePointsSettings) this).AngleYZ = 0.0;
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
