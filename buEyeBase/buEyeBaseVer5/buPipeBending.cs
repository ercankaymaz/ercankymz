// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buPipeBending
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buControls.Controls;
using System;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5;

public class buPipeBending
{
  public string E;

  public static buLabel hmiToBuLabel(hmiUIBasicSettings data, buLabel Lbl)
  {
    try
    {
      Lbl.Geometry.ArcDiameter = ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryArcDiameer;
      Lbl.Geometry.ShapeMode = ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType;
      Lbl.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Display, Lbl.Display);
      if (((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType != 0)
        Lbl.BackColor = Color.Transparent;
      return Lbl;
    }
    catch (Exception ex)
    {
      return Lbl;
    }
  }
}
