// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.SewingJobItem
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class SewingJobItem : buSerilization5
{
  public string pathFromFile;
  public static byte f003CC6;
  public bool SelectMode;
  public ShapeTypes ShapeType;
  public planeBoxNames LastPlane;
  public MaterialCornerLocation LastCorner;
  public ShapeRuntimeData ShapeDataParameters;
  public string layerPanel;
  public string layerOperation;
  public string layerGeneral;
  public string layerSelected;
  public string layerCam;
  public buShape lastShape;
  public static byte f003CD2;
  [SpecialName]
  public int value__;

  public void showDiskBlockPage()
  {
    if (FoamCalcVars.frmDiskBlocks == null)
    {
      FoamCalcVars.frmDiskBlocks = (F_BendingRotaryDisk) new F_Preview();
      ((F_LaserMaterial) FoamCalcVars.frmDiskBlocks).PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      ((F_LaserMaterial) FoamCalcVars.frmDiskBlocks).PropertiesForm.FormPosition = FormStartPosition.CenterParent;
    }
    if (((F_NestExecute) FoamCalcVars.frmDiskBlocks).pnl_viewport.Controls.Count == 0)
      ((F_NestExecute) FoamCalcVars.frmDiskBlocks).pnl_viewport.Controls.Add((Control) buEyeItems.viewportDialogs);
    ((F_Preview) FoamCalcVars.frmDiskBlocks).Init();
    int num = (int) FoamCalcVars.frmDiskBlocks.ShowDialog();
    ((F_NestExecute) FoamCalcVars.frmDiskBlocks).pnl_viewport.Controls.Clear();
  }

  public TreeView UpdateItems(TreeView Tree)
  {
    Tree.Nodes.Clear();
    buTreeNode buTreeNode1 = new buTreeNode($"{buLangTranslate.preDef.Bending} {buLangTranslate.preDef.Block}");
    buTreeNode1.ImageIndex = 0;
    buTreeNode1.SelectedImageIndex = 0;
    buTreeNode1.Tag = (object) "-1";
    buTreeNode1.ClassIndex = 0;
    buTreeNode1.ClassSubIndex = -1;
    buTreeNode1.ClassSubSubIndex = -1;
    buTreeNode1.Command = "bendbase";
    buTreeNode1.Name = "base";
    buTreeNode1.Info = "base";
    buTreeNode1.NodeIndex = 0;
    buTreeNode1.Checked = false;
    buTreeNode node1 = buTreeNode1;
    Tree.Nodes.Add((TreeNode) node1);
    for (int index = 0; index <= FoamCalcVars.DiskBlocks.Count - 1; ++index)
    {
      buTreeNode buTreeNode2 = new buTreeNode($"{buLangTranslate.preDef.Bending} {buLangTranslate.preDef.Block}");
      buTreeNode2.ImageIndex = 0;
      buTreeNode2.SelectedImageIndex = 0;
      buTreeNode2.Tag = (object) "-1";
      buTreeNode2.ClassIndex = 0;
      buTreeNode2.ClassSubIndex = index;
      buTreeNode2.ClassSubSubIndex = -1;
      buTreeNode2.Command = "benddisk";
      buTreeNode2.Name = "base";
      buTreeNode2.Info = "base";
      buTreeNode2.NodeIndex = 0;
      buTreeNode2.Checked = false;
      buTreeNode node2 = buTreeNode2;
      buTreeNode buTreeNode3 = new buTreeNode(buLangTranslate.preDef.Disk);
      buTreeNode3.ImageIndex = 1;
      buTreeNode3.SelectedImageIndex = 1;
      buTreeNode3.Tag = (object) "-1";
      buTreeNode3.ClassIndex = 0;
      buTreeNode3.ClassSubIndex = index;
      buTreeNode3.ClassSubSubIndex = 0;
      buTreeNode3.Command = "disk";
      buTreeNode3.Name = "base";
      buTreeNode3.Info = "base";
      buTreeNode3.NodeIndex = 1;
      buTreeNode3.Checked = false;
      buTreeNode node3 = buTreeNode3;
      buTreeNode buTreeNode4 = new buTreeNode(buLangTranslate.preDef.Block);
      buTreeNode4.ImageIndex = 2;
      buTreeNode4.SelectedImageIndex = 2;
      buTreeNode4.Tag = (object) "-1";
      buTreeNode4.ClassIndex = 0;
      buTreeNode4.ClassSubIndex = index;
      buTreeNode4.ClassSubSubIndex = 1;
      buTreeNode4.Command = "block";
      buTreeNode4.Name = "base";
      buTreeNode4.Info = "base";
      buTreeNode4.NodeIndex = 2;
      buTreeNode4.Checked = false;
      buTreeNode node4 = buTreeNode4;
      node2.Nodes.Add((TreeNode) node3);
      node2.Nodes.Add((TreeNode) node4);
      node1.Nodes.Add((TreeNode) node2);
    }
    return Tree;
  }

  public void CreateDiskBlocks(
    PipeBendDiskBlocks DiskData,
    ref Entity entDisk,
    ref Entity entBlock)
  {
    Circle C2 = new Circle(Plane.XY, new Point3D(), ((SewingEntityCustomData) DiskData).DiskDiameter / 2.0);
    CompositeCurve.CreateRectangle(((SewingEntityCustomData) DiskData).DiskBlockWidth, ((SewingEntityCustomData) DiskData).DiskBlockLength).Translate(-((SewingEntityCustomData) DiskData).DiskDiameter / 2.0, 0.0);
    Point3D[] point3DArray = new Line(new Point3D(((SewingEntityCustomData) DiskData).DiskBlockWidth - ((SewingEntityCustomData) DiskData).DiskDiameter / 2.0, 0.0, 0.0), new Point3D(((SewingEntityCustomData) DiskData).DiskBlockWidth - ((SewingEntityCustomData) DiskData).DiskDiameter / 2.0, ((SewingEntityCustomData) DiskData).DiskDiameter / 2.0, 0.0)).IntersectWith((ICurve) C2, 0.0, true);
    List<Point3D> Points = new List<Point3D>();
    double degrees = buCall.\u0001.PointAngle(point3DArray[0], new Point3D());
    Arc arc1 = new Arc(Plane.XY, (Point2D) new Point3D(-((SewingEntityCustomData) DiskData).DiskDiameter / 2.0, 0.0, 0.0), (Point2D) new Point3D(0.0, -((SewingEntityCustomData) DiskData).DiskDiameter / 2.0, 0.0), (Point2D) point3DArray[0], false);
    Arc arc2 = new Arc(Plane.XY, new Point3D(0.0, 0.0, 0.0), ((SewingEntityCustomData) DiskData).DiskDiameter / 2.0, Utility.DegToRad(-180.0), Utility.DegToRad(degrees));
    arc2.Regen(0.1);
    Points.Add(new Point3D(point3DArray[0].X, point3DArray[0].Y, point3DArray[0].Z));
    Points.Add(new Point3D(point3DArray[0].X, ((SewingEntityCustomData) DiskData).DiskBlockLength, point3DArray[0].Z));
    Points.Add(new Point3D(-((SewingEntityCustomData) DiskData).DiskDiameter / 2.0, ((SewingEntityCustomData) DiskData).DiskBlockLength, point3DArray[0].Z));
    Points.Add(new Point3D(-((SewingEntityCustomData) DiskData).DiskDiameter / 2.0, 0.0, point3DArray[0].Z));
    ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref Points);
    LinearPath linearPath1 = new LinearPath((ICollection<Point3D>) Points);
    CompositeCurve outer = new CompositeCurve((IEnumerable<ICurve>) new List<ICurve>()
    {
      (ICurve) arc2,
      (ICurve) new Line(Points[0], Points[1]),
      (ICurve) new Line(Points[1], Points[2]),
      (ICurve) new Line(Points[2], Points[3])
    });
    outer.Regen(0.1);
    devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region((ICurve) outer);
    region.Regen(0.1);
    Brep brep1 = region.ExtrudeAsBrep(((SewingEntityCustomData) DiskData).DiskHeight, 0.0, 0.0);
    Circle circle = new Circle(Plane.XZ, new Point3D(-((SewingEntityCustomData) DiskData).DiskDiameter / 2.0, 0.0, ((SewingEntityCustomData) DiskData).DiskHeight / 2.0), ((SewingMain) DiskData).BlockPipeDiameter / 2.0);
    circle.Regen(0.1);
    LinearPath linearPath2 = new LinearPath(circle.Vertices);
    devDept.Eyeshot.Entities.Region reg1 = new devDept.Eyeshot.Entities.Region((IList<ICurve>) new List<ICurve>()
    {
      (ICurve) circle
    });
    reg1.Regen(0.1);
    brep1.ExtrudeRemove(reg1, -150.0);
    brep1.RevolveRemove(reg1, Utility.DegToRad(360.0), Vector3D.AxisZ, Point3D.Origin);
    if (brep1 != null)
    {
      brep1.ColorMethod = colorMethodType.byEntity;
      brep1.Color = Color.FromArgb(100, Color.Green);
      entDisk = (Entity) brep1;
    }
    Brep brep2 = new devDept.Eyeshot.Entities.Region((ICurve) CompositeCurve.CreateRectangle(((SewingEntityCustomData) DiskData).BlockWidth, ((SewingDevideOptions) DiskData).BlockDepth)).ExtrudeAsBrep(new Vector3D(0.0, 0.0, ((SewingEntityCustomData) DiskData).BlockHeight));
    devDept.Eyeshot.Entities.Region reg2 = new devDept.Eyeshot.Entities.Region((ICurve) new Circle(Plane.YZ, new Point3D(0.0, 0.0, ((SewingEntityCustomData) DiskData).DiskHeight / 2.0), ((SewingMain) DiskData).BlockPipeDiameter / 2.0));
    brep2.ExtrudeRemove(reg2, ((SewingEntityCustomData) DiskData).BlockWidth);
    if (brep2 == null)
      return;
    brep2.ColorMethod = colorMethodType.byEntity;
    brep2.Color = Color.FromArgb(100, Color.GreenYellow);
    entBlock = (Entity) brep2;
  }
}
