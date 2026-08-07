// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.QuiltingRuntimeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class QuiltingRuntimeSettings : buSerilization5
{
  public const WoodItemType Junktion = ; // Unable to render the field
  public const WoodItemType Profile = ; // Unable to render the field

  public Design AddTurn(double angle, Vector3D axis, Point3D center, Design design1)
  {
    Surface surface = SewingTempVars._c1.RevolveAsSurface(0.0, Math.Abs(angle), axis, center)[0];
    if (angle < 0.0)
      surface.Rotate(Math.PI, new Vector3D(1.0, 0.0, 0.0));
    surface.ColorMethod = colorMethodType.byEntity;
    surface.Color = SewingSettings._pipeColor;
    if (angle > 0.0)
      this.RotatePipe(angle, axis, new Point3D(center.X, center.Y, center.Z));
    else
      this.RotatePipe(angle, axis, new Point3D(center.X, -center.Y, center.Z));
    ++SewingTempVars._bendPartCounter;
    Block block = new Block(SewingSelectedPoint.BendBlockName + SewingTempVars._bendPartCounter.ToString());
    block.Entities.Add((Entity) surface);
    design1.Blocks.Add(block);
    SewingSettings._surfList.Add((Entity) surface);
    return design1;
  }

  public void Translate(double dx)
  {
    foreach (Entity surf in SewingSettings._surfList)
      surf.Translate(dx, 0.0);
  }

  public void RotatePipe(double angle, Vector3D axis, Point3D cen)
  {
    foreach (Entity surf in SewingSettings._surfList)
      surf.Rotate(angle, axis, cen);
  }

  public double GetPipeLength(List<BendingLRAMaterialData> BendingList)
  {
    double pipeLength = 0.0;
    for (int index = 0; index <= BendingList.Count - 1; ++index)
      pipeLength = pipeLength + ((FoamWaveShapeArgs) BendingList[index]).Length + 2.0 * ((FoamWaveShapeArgs) BendingList[index]).Radius * Math.PI / 360.0 * ((FoamWaveShapeArgs) BendingList[index]).Angle;
    return pipeLength;
  }
}
