// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCutRemainMaterial
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCutRemainMaterial : buSerilization5
{
  public bool ShapeLinearArrayEnable;
  public double ShapeLinearArrayXCount;
  public double ShapeLinearArrayYCount;
  public double ShapeLinearArrayXDistance;
  public double ShapeLinearArrayYDistance;
  public double ShapeCircularArrayCount;
  public double ShapeCircularArrarAngle;
  public bool selectedSheetAddNesting;
  public bool selectedPhotoAddNesting;
  public bool selectedContourAddNesting;
  public bool selectedProfileAddNesting;

  public void RectangleToMesh(
    Rectangle2D rectangle,
    double PanelDepth,
    Color color,
    int DepthLevel,
    int xIndex,
    int yIndex,
    NestingPanelNode node,
    ref Mesh meshPanel)
  {
    List<Point3D> points = new List<Point3D>();
    DirectionArrowSetting.Rectangle3DToVertices(rectangle, ref points);
    ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref points);
    if (points.Count < 3)
      return;
    devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region((ICurve) new LinearPath((ICollection<Point3D>) points));
    meshPanel = region.ExtrudeAsMesh(PanelDepth, 0.1, Mesh.natureType.RichSmooth);
    meshPanel.Color = color;
    meshPanel.ColorMethod = colorMethodType.byEntity;
    meshPanel.Selectable = false;
    PanelEntityData panelEntityData = (PanelEntityData) new marbleEventPar();
    ((MarbleRuntimeSettings) panelEntityData).Depth = DepthLevel;
    if (node != null)
    {
      ((MarbleRuntimeSettings) panelEntityData).NodeType = ((MarbleRuntimeSettings) node).NodeType;
      ((MarbleRuntimeSettings) panelEntityData).NodeID = ((MarbleRuntimeSettings) node).NodeID;
    }
    ((MarbleRuntimeSettings) panelEntityData).XIndex = xIndex;
    ((MarbleRuntimeSettings) panelEntityData).YIndex = yIndex;
    meshPanel.EntityData = (object) panelEntityData;
  }

  public void GetPanelPartArea(
    List<Rectangle2D> Parts,
    List<NestingPanelNode> Nodes,
    ref double Area)
  {
    for (int index = 0; index <= Nodes.Count - 1; ++index)
    {
      if (((MarbleRuntimeSettings) Nodes[index]).NodeType == nestPanelNodeType.CutLine && ((MarbleRuntimeSettings) Nodes[index]).PartID >= 0 & ((MarbleRuntimeSettings) Nodes[index]).PartID <= Parts.Count - 1 & ((MarbleRuntimeSettings) Nodes[index]).Node.Count == 0)
        Area += ((EntityDataSet) Parts[((MarbleRuntimeSettings) Nodes[index]).PartID]).Width * ((EntityDataSet) Parts[((MarbleRuntimeSettings) Nodes[index]).PartID]).Height;
      if (((MarbleRuntimeSettings) Nodes[index]).Node.Count > 0)
        this.GetPanelPartArea(Parts, ((MarbleRuntimeSettings) Nodes[index]).Node, ref Area);
    }
  }

  public int SimCountFromLength(double MaxLen, double SimLen)
  {
    double num = 3.0;
    if (SimLen > 0.0)
      num = MaxLen / SimLen;
    if (num < 3.0)
      num = 3.0;
    return Convert.ToInt32(num);
  }
}
