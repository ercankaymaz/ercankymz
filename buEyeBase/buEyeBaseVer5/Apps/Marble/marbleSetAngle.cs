// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleSetAngle
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.PanelCut;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleSetAngle : buSerilization5
{
  public double ShapeRotation;
  public double ShapeRotateAngle;

  public int PanelCutDirToImageIndex(DirectionXandY Dir)
  {
    return Dir != DirectionXandY.XDirection ? 1 : 0;
  }

  public string PanelCutToString(NestingPanelNode Node)
  {
    string str = ((MarbleRuntimeSettings) Node).NodeType.ToString();
    if (((MarbleRuntimeSettings) Node).NodeType == nestPanelNodeType.CutLine)
    {
      if (((MarbleRuntimeSettings) Node).Direction == DirectionXandY.XDirection && ((MarbleRuntimeSettings) Node).CutLine != null)
        str = ((EntityDataSet) ((MarbleRuntimeSettings) Node).CutLine).StartPoint.X.ToString("f2");
      if (((MarbleRuntimeSettings) Node).Direction == DirectionXandY.YDirection && ((MarbleRuntimeSettings) Node).CutLine != null)
        str = ((EntityDataSet) ((MarbleRuntimeSettings) Node).CutLine).StartPoint.Y.ToString("f2");
    }
    else if (((MarbleRuntimeSettings) Node).NodeType == nestPanelNodeType.Module)
      str = $"Module - X= {((MarbleRuntimeSettings) Node).DimensionX.ToString("f2")} , Y = {((MarbleRuntimeSettings) Node).DimensionY.ToString("f2")}";
    else if (((MarbleRuntimeSettings) Node).NodeType == nestPanelNodeType.Assembly)
      str = $"Assembly - X= {((MarbleRuntimeSettings) Node).DimensionX.ToString("f2")} , Y = {((MarbleRuntimeSettings) Node).DimensionY.ToString("f2")}";
    return str;
  }

  public void GetPartFromPartListWithID(
    List<Rectangle2D> Parts,
    double PanelDepth,
    int ID,
    Color color,
    bool RotateToLongWidth,
    ref Mesh partEntity,
    ref Rectangle2D foundRect)
  {
    if (!(ID >= 0 & ID <= Parts.Count - 1))
      return;
    foundRect = ((EntityDataSet) Parts[ID]).Width <= ((EntityDataSet) Parts[ID]).Height ? (Rectangle2D) new DirectionArrowSetting(((EntityDataSet) Parts[ID]).Height, ((EntityDataSet) Parts[ID]).Width) : (Rectangle2D) new DirectionArrowSetting(((EntityDataSet) Parts[ID]).Width, ((EntityDataSet) Parts[ID]).Height);
    ((marbleCutRemainMaterial) this).RectangleToMesh(foundRect, PanelDepth, color, 0, -1, -1, (NestingPanelNode) null, ref partEntity);
  }
}
