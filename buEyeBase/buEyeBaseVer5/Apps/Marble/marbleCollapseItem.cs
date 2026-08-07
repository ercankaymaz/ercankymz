// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCollapseItem
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCollapseItem : buSerilization5
{
  public marbleCountertopTapData TapFirstData;
  public marbleCountertopTapData TapSecondData;
  public marbleCountertopTapData TapThirdData;
  public marbleCountertopTapData TapFourthData;
  public marbleCountertopCavityData CavityFirstData;
  public marbleCountertopCavityData CavitySecondData;
  public marbleSlatData SlatData;
  public marbleChamferBothSideData ChamferEdgeData;
  public marbleChamferBothSideData ChamferSlatData;
  public double SawSafeDistance;
  public double SawRapidDistance;
  public double SawPlungeVelocity;
  public double SawLeaveVelocity;
  public double SawPlungeFirstVelocity;
  public double SawForwardFirstCuttingVelocity;

  public void MoveVacuumCut(ref MarbleJob Job, double dX, double dY, int VacuumIndex)
  {
    if (!(VacuumIndex >= 0 & VacuumIndex <= ((MarbleProgramSettings) Job).VacuumCuts.Count - 1))
      return;
    MarbleVacuumCut vacuumCut = ((MarbleProgramSettings) Job).VacuumCuts[VacuumIndex];
    ((MarbleMachineOptionsSettings) vacuumCut).MoveX = ((MarbleMachineOptionsSettings) vacuumCut).MoveX + dX;
    ((MarbleMachineOptionsSettings) vacuumCut).MoveY = ((MarbleMachineOptionsSettings) vacuumCut).MoveY + dY;
    for (int index = 0; index <= ((MarbleProgramSettings) Job).Items.Count - 1; ++index)
    {
      MarbleItem marbleItem = ((MarbleProgramSettings) Job).Items[index];
      ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index]).OffsetX = 0.0;
      ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index]).OffsetY = 0.0;
      if (((MarbleMachineOptionsSettings) vacuumCut).Direction == HorizontalVertical.Vertical && ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index]).SizeItem).MinPoint.X > ((MarbleMachineOptionsSettings) vacuumCut).StartPoint.X)
        ((marbleCountertopCavityPars) this).MoveItem(ref marbleItem, ((MarbleMachineOptionsSettings) vacuumCut).MoveX, 0.0, 0.0);
      if (((MarbleMachineOptionsSettings) vacuumCut).Direction == HorizontalVertical.Horizontal && buConversion5.GT(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index]).SizeItem).MinPoint.Y, ((MarbleMachineOptionsSettings) vacuumCut).StartPoint.Y, 1.0) && buConversion5.LE(((MarbleMachineOptionsSettings) vacuumCut).StartPoint.X, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index]).SizeItem).MinPoint.X, 2.0) & buConversion5.LE(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index]).SizeItem).MaxPoint.X, ((MarbleMachineOptionsSettings) vacuumCut).EndPoint.X, 2.0))
        ((marbleCountertopCavityPars) this).MoveItem(ref marbleItem, 0.0, ((MarbleMachineOptionsSettings) vacuumCut).MoveY, 0.0);
    }
    int num = 0;
    while (num <= ((MarbleProgramSettings) Job).VacuumMaterials.Count - 1)
      ++num;
    for (int index1 = 0; index1 <= ((MarbleProgramSettings) Job).VacuumCuts.Count - 1; ++index1)
    {
      ((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index1]).OffsetX = 0.0;
      ((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index1]).OffsetY = 0.0;
      for (int index2 = 0; index2 <= VacuumIndex; ++index2)
      {
        if (((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index1]).VacuumID != ((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index2]).VacuumID)
        {
          if (((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index2]).Direction == HorizontalVertical.Vertical && ((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index1]).StartPoint.X > ((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index2]).StartPoint.X & ((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index1]).EndPoint.X > ((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index2]).StartPoint.X)
            ((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index1]).OffsetX = ((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index1]).OffsetX + ((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index2]).MoveX;
          if (((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index2]).Direction == HorizontalVertical.Horizontal && ((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index1]).StartPoint.Y > ((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index2]).StartPoint.Y & ((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index1]).EndPoint.Y > ((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index2]).StartPoint.Y)
            ((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index1]).OffsetY = ((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index1]).OffsetY + ((MarbleMachineOptionsSettings) ((MarbleProgramSettings) Job).VacuumCuts[index2]).MoveY;
        }
      }
    }
  }

  public void DevideVacuumMaterial(
    MaterialBase5 baseMaterial,
    MarbleVacuumCut CutLine,
    double SecondMoveX,
    double SecondMoveY,
    ref MaterialBase5 FirstMaterial,
    ref MaterialBase5 SecondMaterial)
  {
    if (((MarbleMachineOptionsSettings) CutLine).Direction == HorizontalVertical.Vertical && ((SortOptions) baseMaterial).BoxMinPoint.X < ((MarbleMachineOptionsSettings) CutLine).StartPoint.X & ((MarbleMachineOptionsSettings) CutLine).StartPoint.X < ((SortCamData) baseMaterial).BoxMaxPoint.X)
    {
      double num1 = ((MarbleMachineOptionsSettings) CutLine).StartPoint.X - ((SortOptions) baseMaterial).BoxMinPoint.X;
      double height1 = ((SortResult) baseMaterial).Size.Height;
      List<Point3D> PLOutter1 = new List<Point3D>();
      PLOutter1.Add(new Point3D(((SortOptions) baseMaterial).BoxMinPoint.X, ((SortOptions) baseMaterial).BoxMinPoint.Y, ((SortOptions) baseMaterial).BoxMinPoint.Z));
      PLOutter1.Add(new Point3D(((SortOptions) baseMaterial).BoxMinPoint.X + num1, ((SortOptions) baseMaterial).BoxMinPoint.Y, ((SortOptions) baseMaterial).BoxMinPoint.Z));
      PLOutter1.Add(new Point3D(((SortOptions) baseMaterial).BoxMinPoint.X + num1, ((SortOptions) baseMaterial).BoxMinPoint.Y + height1, ((SortOptions) baseMaterial).BoxMinPoint.Z));
      PLOutter1.Add(new Point3D(((SortOptions) baseMaterial).BoxMinPoint.X, ((SortOptions) baseMaterial).BoxMinPoint.Y + height1, ((SortOptions) baseMaterial).BoxMinPoint.Z));
      PLOutter1.Add(new Point3D(((SortOptions) baseMaterial).BoxMinPoint.X, ((SortOptions) baseMaterial).BoxMinPoint.Y, ((SortOptions) baseMaterial).BoxMinPoint.Z));
      FirstMaterial = (MaterialBase5) new ShapeMultiCenterData(baseMaterial);
      ((MostClosestPointOption) FirstMaterial).Entities.Clear();
      ((marbleCounterTopPars) this).CreateMaterial(PLOutter1, (List<List<Point3D>>) null, ((SortAskMe) baseMaterial).Shapes, ((SortResult) baseMaterial).Size.Depth, ((SortResult) baseMaterial).matImage, ref FirstMaterial);
      double num2 = ((SortCamData) baseMaterial).BoxMaxPoint.X - ((MarbleMachineOptionsSettings) CutLine).StartPoint.X;
      double height2 = ((SortResult) baseMaterial).Size.Height;
      List<Point3D> PLOutter2 = new List<Point3D>();
      PLOutter2.Add(new Point3D(((MarbleMachineOptionsSettings) CutLine).StartPoint.X + SecondMoveX, ((SortOptions) baseMaterial).BoxMinPoint.Y + SecondMoveY, ((SortOptions) baseMaterial).BoxMinPoint.Z));
      PLOutter2.Add(new Point3D(((MarbleMachineOptionsSettings) CutLine).StartPoint.X + num2 + SecondMoveX, ((SortOptions) baseMaterial).BoxMinPoint.Y + SecondMoveY, ((SortOptions) baseMaterial).BoxMinPoint.Z));
      PLOutter2.Add(new Point3D(((MarbleMachineOptionsSettings) CutLine).StartPoint.X + num2 + SecondMoveX, ((SortOptions) baseMaterial).BoxMinPoint.Y + height2 + SecondMoveY, ((SortOptions) baseMaterial).BoxMinPoint.Z));
      PLOutter2.Add(new Point3D(((MarbleMachineOptionsSettings) CutLine).StartPoint.X + SecondMoveX, ((SortOptions) baseMaterial).BoxMinPoint.Y + height2 + SecondMoveY, ((SortOptions) baseMaterial).BoxMinPoint.Z));
      PLOutter2.Add(new Point3D(((MarbleMachineOptionsSettings) CutLine).StartPoint.X + SecondMoveX, ((SortOptions) baseMaterial).BoxMinPoint.Y + SecondMoveY, ((SortOptions) baseMaterial).BoxMinPoint.Z));
      SecondMaterial = (MaterialBase5) new ShapeMultiCenterData(baseMaterial);
      ((MostClosestPointOption) SecondMaterial).Entities.Clear();
      ((marbleCounterTopPars) this).CreateMaterial(PLOutter2, (List<List<Point3D>>) null, ((SortAskMe) baseMaterial).Shapes, ((SortResult) baseMaterial).Size.Depth, ((SortResult) baseMaterial).matImage, ref SecondMaterial);
    }
    if (((MarbleMachineOptionsSettings) CutLine).Direction != HorizontalVertical.Horizontal || !(((SortOptions) baseMaterial).BoxMinPoint.Y < ((MarbleMachineOptionsSettings) CutLine).StartPoint.Y & ((MarbleMachineOptionsSettings) CutLine).StartPoint.Y < ((SortCamData) baseMaterial).BoxMaxPoint.Y))
      return;
    double width1 = ((SortResult) baseMaterial).Size.Width;
    double num3 = ((MarbleMachineOptionsSettings) CutLine).EndPoint.Y - ((SortOptions) baseMaterial).BoxMinPoint.Y;
    List<Point3D> PLOutter3 = new List<Point3D>();
    PLOutter3.Add(new Point3D(((SortOptions) baseMaterial).BoxMinPoint.X, ((SortOptions) baseMaterial).BoxMinPoint.Y, ((SortOptions) baseMaterial).BoxMinPoint.Z));
    PLOutter3.Add(new Point3D(((SortOptions) baseMaterial).BoxMinPoint.X + width1, ((SortOptions) baseMaterial).BoxMinPoint.Y, ((SortOptions) baseMaterial).BoxMinPoint.Z));
    PLOutter3.Add(new Point3D(((SortOptions) baseMaterial).BoxMinPoint.X + width1, ((SortOptions) baseMaterial).BoxMinPoint.Y + num3, ((SortOptions) baseMaterial).BoxMinPoint.Z));
    PLOutter3.Add(new Point3D(((SortOptions) baseMaterial).BoxMinPoint.X, ((SortOptions) baseMaterial).BoxMinPoint.Y + num3, ((SortOptions) baseMaterial).BoxMinPoint.Z));
    PLOutter3.Add(new Point3D(((SortOptions) baseMaterial).BoxMinPoint.X, ((SortOptions) baseMaterial).BoxMinPoint.Y, ((SortOptions) baseMaterial).BoxMinPoint.Z));
    FirstMaterial = (MaterialBase5) new ShapeMultiCenterData(baseMaterial);
    ((MostClosestPointOption) FirstMaterial).Entities.Clear();
    ((marbleCounterTopPars) this).CreateMaterial(PLOutter3, (List<List<Point3D>>) null, ((SortAskMe) baseMaterial).Shapes, ((SortResult) baseMaterial).Size.Depth, ((SortResult) baseMaterial).matImage, ref FirstMaterial);
    double width2 = ((SortResult) baseMaterial).Size.Width;
    double num4 = ((SortCamData) baseMaterial).BoxMaxPoint.Y - ((MarbleMachineOptionsSettings) CutLine).StartPoint.Y;
    List<Point3D> PLOutter4 = new List<Point3D>();
    PLOutter4.Add(new Point3D(((SortOptions) baseMaterial).BoxMinPoint.X + SecondMoveX, ((MarbleMachineOptionsSettings) CutLine).StartPoint.Y + SecondMoveY, ((SortOptions) baseMaterial).BoxMinPoint.Z));
    PLOutter4.Add(new Point3D(((SortOptions) baseMaterial).BoxMinPoint.X + width2 + SecondMoveX, ((MarbleMachineOptionsSettings) CutLine).StartPoint.Y + SecondMoveY, ((SortOptions) baseMaterial).BoxMinPoint.Z));
    PLOutter4.Add(new Point3D(((SortOptions) baseMaterial).BoxMinPoint.X + width2 + SecondMoveX, ((MarbleMachineOptionsSettings) CutLine).StartPoint.Y + num4 + SecondMoveY, ((SortOptions) baseMaterial).BoxMinPoint.Z));
    PLOutter4.Add(new Point3D(((SortOptions) baseMaterial).BoxMinPoint.X + SecondMoveX, ((MarbleMachineOptionsSettings) CutLine).StartPoint.Y + num4 + SecondMoveY, ((SortOptions) baseMaterial).BoxMinPoint.Z));
    PLOutter4.Add(new Point3D(((SortOptions) baseMaterial).BoxMinPoint.X + SecondMoveX, ((MarbleMachineOptionsSettings) CutLine).StartPoint.Y + SecondMoveY, ((SortOptions) baseMaterial).BoxMinPoint.Z));
    SecondMaterial = (MaterialBase5) new ShapeMultiCenterData(baseMaterial);
    ((MostClosestPointOption) SecondMaterial).Entities.Clear();
    ((marbleCounterTopPars) this).CreateMaterial(PLOutter4, (List<List<Point3D>>) null, ((SortAskMe) baseMaterial).Shapes, ((SortResult) baseMaterial).Size.Depth, ((SortResult) baseMaterial).matImage, ref SecondMaterial);
  }

  public bool isVacuumCutInsideMaterial(MaterialBase5 Material, MarbleVacuumCut CutLine)
  {
    try
    {
      return buCall.\u0001.IsPointInsideWindow(((SortOptions) Material).BoxMinPoint, ((SortCamData) Material).BoxMaxPoint, ((MarbleMachineOptionsSettings) CutLine).StartPoint, Plane.XY, true);
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public void mouseMoveViewport(object sender, MouseEventArgs e)
  {
    if ((sender as Control).Name == buEyeItems.viewportDialogs.Name)
      ;
  }
}
