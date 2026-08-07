// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortbuCamData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SortbuCamData : buSerilization5
{
  public double AngleMaxLimit;

  public SortbuCamData(Point3D PMin, Point3D PMax)
  {
    ((FlatViewSettings) this).MinPoint = new Point3D();
    ((FlatViewSettings) this).MidPoint = new Point3D();
    ((MachineSimulation) this).MaxPoint = new Point3D();
    ((MachineSimulation) this).Delta = new Vector3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((FlatViewSettings) this).MinPoint = F_NotchEdit.ToPoint3D(PMin);
    ((MachineSimulation) this).MaxPoint = F_NotchEdit.ToPoint3D(PMax);
    ((FlatViewSettings) this).MidPoint = new Point3D((PMin.X + PMax.X) / 2.0, (PMin.Y + PMax.Y) / 2.0, (PMin.Z + PMax.Z) / 2.0);
    ((MachineSimulation) this).Delta = new Vector3D(PMax.X - PMin.X, PMax.Y - PMin.Y, PMax.Z - PMin.Z);
  }

  public override string ToString()
  {
    return $"dX: {((MachineSimulation) this).Delta.X.ToString("f2")} , dY: {((MachineSimulation) this).Delta.Y.ToString("f2")} , dZ: {((MachineSimulation) this).Delta.Z.ToString("f2")} | MinX: {((FlatViewSettings) this).MinPoint.X.ToString("f2")} , MinY: {((FlatViewSettings) this).MinPoint.Y.ToString("f2")} , MinZ: {((FlatViewSettings) this).MinPoint.Z.ToString("f2")} | MaxX: {((MachineSimulation) this).MaxPoint.X.ToString("f2")} , MaxY: {((MachineSimulation) this).MaxPoint.Y.ToString("f2")} , MaxZ: {((MachineSimulation) this).MaxPoint.Z.ToString("f2")}";
  }
}
