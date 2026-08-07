// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buQuilting
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class buQuilting
{
  public const WoodItemType Engraving = ; // Unable to render the field
  public const WoodItemType DrillByMilling = ; // Unable to render the field
  public const WoodItemType SlotByMilling = ; // Unable to render the field
  public const WoodItemType Profiling = ; // Unable to render the field

  public Design AddStraight(double dx, Design design1)
  {
    try
    {
      Surface surface1 = SewingTempVars._c1.ExtrudeAsSurface(-dx, 0.0, 0.0)[0];
      surface1.ColorMethod = colorMethodType.byEntity;
      surface1.Color = SewingSettings._pipeColor;
      PlanarSurface surface2 = Region.CreateCircle(Plane.YZ, Point2D.Origin, SewingSettings._pipeDiameter / 2.0).ConvertToSurface();
      surface2.ColorMethod = colorMethodType.byEntity;
      surface2.Color = SewingSettings._pipeColor;
      ++SewingSettings._straightPartCounter;
      Block block = new Block(SewingCodeDef.StraightBlockName + SewingSettings._straightPartCounter.ToString());
      block.Entities.Add((Entity) surface1);
      block.Entities.Add((Entity) surface2);
      design1.Blocks.Add(block);
      SewingSettings._surfList.Add((Entity) surface1);
      SewingSettings._surfList.Add((Entity) surface2);
      ((QuiltingRuntimeSettings) this).Translate(dx);
      return design1;
    }
    catch (Exception ex)
    {
      return design1;
    }
  }

  public Design AddStraightBack(double dx, Design design1)
  {
    Surface surface = SewingTempVars._c1.ExtrudeAsSurface(-dx, 0.0, 0.0)[0];
    surface.ColorMethod = colorMethodType.byEntity;
    surface.Color = SewingSettings._pipeColor;
    Block block = new Block(SewingSelectedPoint.StraightbackBlockName);
    block.Entities.Add((Entity) surface);
    design1.Blocks.Add(block);
    SewingSettings._surfList.Add((Entity) surface);
    return design1;
  }
}
