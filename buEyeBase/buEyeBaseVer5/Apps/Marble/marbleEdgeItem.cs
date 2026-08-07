// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleEdgeItem
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleEdgeItem : buSerilization5
{
  public double SawForwardCuttingVelocity;
  public double SawForwardCircularCuttingVelocity;
  public double SawForwardCircularFirstCuttingVelocity;
  public double SawBackwardCuttingVelocity;
  public double SawBackwardCircularCuttingVelocity;
  public double SawForwardStepFirstDownDistance;
  public double SawForwardStepDownDistance;
  public double SawForwardCircularStepFirstDownDistance;
  public double SawForwardCircularStepDownDistance;
  public double SawBackwardStepDownDistance;
  public double MillingSafeDistance;
  public double MillingRapidDistance;
  public double MillingPlungeVelocity;
  public double MillingPlungeFirstVelocity;
  public double MillingCuttingVelocity;
  public double MillingFirstCuttingVelocity;
  public double MillingDrillVelocity;
  public double MillingDrillLeaveVelocity;
  public double MillingFirstStepDown;
  public double MillingStepDown;
  public double MillingStepOverPersentage;
  public double MillingHeadPlungeVelocity;
  public double MillingHeadPlungeFirstVelocity;
  public double MillingHeadSafeDistance;
  public double MillingHeadRapidDistance;
  public double MillingHeadCuttingVelocity;
  public double MillingHeadFirstCuttingVelocity;
  public double MillingHeadDrillVelocity;
  public double MillingHeadDrillLeaveVelocity;
  public double MillingHeadFirstStepDown;
  public double MillingHeadStepDown;
  public double MillingHeadStepOverPersentage;
  public double WaterjetSafeDistance;
  public double WaterjetRapidDistance;
  public double TargetZ;

  public void mouseDownViewport(object sender, MouseEventArgs e)
  {
    if ((sender as System.Windows.Forms.Control).Name == buEyeItems.viewportDialogs.Name)
      ;
  }

  public void mouseUpViewport(object sender, MouseEventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (e.Button != MouseButtons.Left || control.Name == buEyeItems.viewportCadCam.Name)
      ;
  }

  public void RegenEntities(ref List<Entity> EntityList, double Regen, Design Doc)
  {
    for (int index = 0; index <= EntityList.Count - 1; ++index)
    {
      Entity Entity = EntityList[index];
      this.RegenEntities(ref Entity, Regen, Doc);
    }
  }

  public void RegenEntities(ref Entity Entity, double Regen, Design Doc)
  {
    RegenParams data = new RegenParams(Regen, (IWorkspace) Doc);
    Entity.Regen(data);
  }

  public Entity SetEntityData(
    Entity Ent,
    MarbleItem MI,
    int indexItem,
    int indexRef,
    int indexCam,
    string Name,
    entityTypeDefination EntType,
    string LayerName,
    bool Selectable,
    double Thickess,
    Color Clr)
  {
    // ISSUE: unable to decompile the method.
  }

  public void CameraNewPositionandSizeCalculation(
    double NewHeight,
    ref double XOffset,
    ref double YOffset,
    ref double WidthOffset,
    ref double HegihtOffset)
  {
    XOffset = (NewHeight - 0.0) / ((marbleProfileCurveCutPars) MarbleRuntimeSettings.varMarbleSettings).CameraLensXRatio + ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).CameraFirstXPosition;
    YOffset = (NewHeight - 0.0) / ((marbleProfileCurveCutPars) MarbleRuntimeSettings.varMarbleSettings).CameraLensYRatio + ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).CameraFirstYPosition;
    WidthOffset = ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).CameraFirstXPosition - XOffset;
    HegihtOffset = ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).CameraFirstYPosition - YOffset;
  }

  public void ARotationCenterCalc(
    double dZ,
    double dY,
    double Angle,
    double SawDiameter,
    double SawThickness,
    ref double CenterDistance)
  {
    CenterDistance = 0.0;
    double x = Math.Sqrt(Math.Pow(dY, 2.0) + Math.Pow(dZ, 2.0)) / (Math.Sin(buString5.DegreeToRadian(Angle / 2.0)) * 2.0);
    CenterDistance = Math.Sqrt(Math.Pow(x, 2.0) - Math.Pow(SawDiameter / 2.0, 2.0));
  }

  public void AddInfoType(InfoType I, ref List<InfoType> List)
  {
    if (List.Count == 0)
    {
      List.Add(I);
    }
    else
    {
      bool flag = false;
      for (int index = 0; index <= List.Count - 1; ++index)
      {
        if (List[index].Mode == I.Mode)
        {
          if (List[index].CodeType == I.CodeType & List[index].Code == I.Code & List[index].Axis == I.Axis)
          {
            flag = true;
            index = List.Count;
          }
          else if (List[index].Message == I.Message & List[index].Code == I.Code & List[index].Axis == I.Axis)
          {
            flag = true;
            index = List.Count;
          }
        }
      }
      if (flag)
        return;
      List.Add(I);
    }
  }

  public void SawCornerConnect(
    Point3D pntMin,
    Point3D pntMax,
    Point3D firstP,
    Point3D lastP,
    bool isLast,
    ref List<Point3D> PLFill)
  {
    for (int index = 1; index <= 4; ++index)
    {
      if (buConversion5.EQ(lastP.X, pntMin.X))
      {
        if (buConversion5.EQ(lastP.X, pntMin.X) & buConversion5.EQ(lastP.Y, pntMin.Y))
        {
          PLFill.Add(new Point3D(pntMax.X, pntMin.Y, lastP.Z));
          lastP = PLFill[PLFill.Count - 1];
        }
        else if (buConversion5.EQ(lastP.X, pntMin.X) & buConversion5.EQ(lastP.Y, pntMax.Y))
        {
          PLFill.Add(new Point3D(pntMin.X, pntMin.Y, lastP.Z));
          lastP = PLFill[PLFill.Count - 1];
        }
        else
        {
          PLFill.Add(new Point3D(pntMin.X, pntMin.Y, lastP.Z));
          lastP = PLFill[PLFill.Count - 1];
        }
      }
      else if (buConversion5.EQ(lastP.Y, pntMin.Y))
      {
        if (buConversion5.EQ(lastP.X, pntMax.X) & buConversion5.EQ(lastP.Y, pntMin.Y))
        {
          PLFill.Add(new Point3D(pntMax.X, pntMax.Y, lastP.Z));
          lastP = PLFill[PLFill.Count - 1];
        }
        else if (buConversion5.EQ(lastP.X, pntMin.X) & buConversion5.EQ(lastP.Y, pntMin.Y))
        {
          PLFill.Add(new Point3D(pntMax.X, pntMin.Y, lastP.Z));
          lastP = PLFill[PLFill.Count - 1];
        }
        else
        {
          PLFill.Add(new Point3D(pntMax.X, pntMin.Y, lastP.Z));
          lastP = PLFill[PLFill.Count - 1];
        }
      }
      else if (buConversion5.EQ(lastP.X, pntMax.X))
      {
        if (buConversion5.EQ(lastP.X, pntMax.X) & buConversion5.EQ(lastP.Y, pntMin.Y))
        {
          PLFill.Add(new Point3D(pntMax.X, pntMax.Y, lastP.Z));
          lastP = PLFill[PLFill.Count - 1];
        }
        else if (buConversion5.EQ(lastP.X, pntMax.X) & buConversion5.EQ(lastP.Y, pntMax.Y))
        {
          PLFill.Add(new Point3D(pntMin.X, pntMax.Y, lastP.Z));
          lastP = PLFill[PLFill.Count - 1];
        }
        else
        {
          PLFill.Add(new Point3D(pntMax.X, pntMax.Y, lastP.Z));
          lastP = PLFill[PLFill.Count - 1];
        }
      }
      else if (buConversion5.EQ(lastP.Y, pntMax.Y))
      {
        if (buConversion5.EQ(lastP.X, pntMax.X) & buConversion5.EQ(lastP.Y, pntMax.Y))
        {
          PLFill.Add(new Point3D(pntMin.X, pntMax.Y, lastP.Z));
          lastP = PLFill[PLFill.Count - 1];
        }
        else if (buConversion5.EQ(lastP.X, pntMin.X) & buConversion5.EQ(lastP.Y, pntMax.Y))
        {
          PLFill.Add(new Point3D(pntMin.X, pntMin.Y, lastP.Z));
          lastP = PLFill[PLFill.Count - 1];
        }
        else
        {
          PLFill.Add(new Point3D(pntMin.X, pntMax.Y, lastP.Z));
          lastP = PLFill[PLFill.Count - 1];
        }
      }
      if (buConversion5.EQ(lastP.X, firstP.X) | buConversion5.EQ(lastP.Y, firstP.Y))
      {
        if (isLast)
          PLFill.Add(F_NotchEdit.ToPoint3D(PLFill[0]));
        index = 5;
      }
    }
  }
}
