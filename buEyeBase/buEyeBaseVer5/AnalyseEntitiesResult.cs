// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.AnalyseEntitiesResult
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class AnalyseEntitiesResult : buSerilization5
{
  public int CamIndex;
  public bool CamSelected;

  public AnalyseEntitiesResult()
  {
    ((EntityDataSet) this).notchPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public AnalyseEntitiesResult(CutterInfo data)
  {
    ((EntityDataSet) this).notchPoint = new Point3D();
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
    ((EntityDataSet) this).notchPoint = new Point3D(((EntityDataSet) data).notchPoint.X, ((EntityDataSet) data).notchPoint.Y, ((EntityDataSet) data).notchPoint.Z);
  }

  public override string ToString()
  {
    return $"notchP: {((EntityDataSet) this).notchPoint.X.ToString("f3")} , {((EntityDataSet) this).notchPoint.Y.ToString("f3")}";
  }
}
