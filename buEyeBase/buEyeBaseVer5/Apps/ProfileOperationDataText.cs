// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationDataText
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buCore;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataText : buSerilization5
{
  public int ID;
  public string ItemNo;
  public string SalesNo;
  public string Other;
  public string Aux;
  public double UserData;
  public string SequenceChar;
  public bool isMirror;
  public Color Color;
  public nestPartRotateType Rotation;
  public buEntitiesGroup EntitiesGroup;
  public static byte f00432C;

  public bool isOperationInsideClamperLimits(
    GProfileOperation OP,
    List<ProfileClamper> Clampers,
    OperationInsideClampers Options)
  {
    bool flag1;
    for (int index = 0; index <= Clampers.Count - 1; ++index)
    {
      bool flag2 = this.isOperationInsideClamper(OP, Clampers[index], Options);
      if (((MarbleRuntimeSettings) Options).IndexOpertion > 0 & ((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName == planeNames.Top & !((MarbleRuntimeSettings) Options).UseTopPlane)
        flag2 = false;
      if (flag2)
      {
        flag1 = true;
        goto label_8;
      }
    }
    flag1 = false;
label_8:
    return flag1;
  }

  public bool isClmpersAreSame(
    List<ProfileClamper> FirstClampers,
    List<ProfileClamper> SecondClampers)
  {
    try
    {
      if (FirstClampers.Count != SecondClampers.Count)
        return false;
      for (int index = 0; index <= FirstClampers.Count - 1; ++index)
      {
        if (!buCompare.EQ(((PanelCutMoveCommand) FirstClampers[index]).XPosition, ((PanelCutMoveCommand) SecondClampers[index]).XPosition))
          return false;
      }
      return true;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public bool isClmpersAreSameWhichAreMoved(
    List<ProfileClamper> FirstClampers,
    List<ProfileClamper> SecondClampers,
    ref List<int> MovedIndex)
  {
    try
    {
      bool flag = true;
      MovedIndex.Clear();
      if (FirstClampers.Count != SecondClampers.Count)
        return false;
      for (int index = 0; index <= FirstClampers.Count - 1; ++index)
      {
        if (!buCompare.EQ(((PanelCutMoveCommand) FirstClampers[index]).XPosition, ((PanelCutMoveCommand) SecondClampers[index]).XPosition))
        {
          flag = false;
          MovedIndex.Add(index);
        }
      }
      return flag;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public bool isOperationInsideClamper(
    GProfileOperation OP,
    ProfileClamper Clampers,
    OperationInsideClampers Options)
  {
    bool flag;
    if (((buMarbleCalc) Clampers).GeometrixMinX < ((FlatViewSettings) ((ProfileRuntimeSettings) OP).SizePoint).MinPoint.X & ((FlatViewSettings) ((ProfileRuntimeSettings) OP).SizePoint).MinPoint.X < ((buMarbleCalc) Clampers).GeometrixMaxX)
      flag = true;
    else if (((buMarbleCalc) Clampers).GeometrixMinX < ((MachineSimulation) ((ProfileRuntimeSettings) OP).SizePoint).MaxPoint.X & ((MachineSimulation) ((ProfileRuntimeSettings) OP).SizePoint).MaxPoint.X < ((buMarbleCalc) Clampers).GeometrixMaxX)
    {
      flag = true;
    }
    else
    {
      double num1 = ((FlatViewSettings) ((ProfileRuntimeSettings) OP).SizePoint).MinPoint.X - ((MarbleRuntimeSettings) Options).LeftDistance + ((MarbleRuntimeSettings) Options).ClamperWidth / 2.0;
      if (((buMarbleCalc) Clampers).GeometrixMinX < num1 & num1 < ((buMarbleCalc) Clampers).GeometrixMaxX)
      {
        flag = true;
      }
      else
      {
        double num2 = ((MachineSimulation) ((ProfileRuntimeSettings) OP).SizePoint).MaxPoint.X + ((MarbleRuntimeSettings) Options).RightDistance - ((MarbleRuntimeSettings) Options).ClamperWidth / 2.0;
        if (((buMarbleCalc) Clampers).GeometrixMinX < num2 & num2 < ((buMarbleCalc) Clampers).GeometrixMaxX)
          flag = true;
        else if (((FlatViewSettings) ((ProfileRuntimeSettings) OP).SizePoint).MinPoint.X < ((buMarbleCalc) Clampers).GeometrixMinX & ((buMarbleCalc) Clampers).GeometrixMinX < ((MachineSimulation) ((ProfileRuntimeSettings) OP).SizePoint).MaxPoint.X)
          flag = true;
        else if (((FlatViewSettings) ((ProfileRuntimeSettings) OP).SizePoint).MinPoint.X < ((buMarbleCalc) Clampers).GeometrixMaxX & ((buMarbleCalc) Clampers).GeometrixMaxX < ((MachineSimulation) ((ProfileRuntimeSettings) OP).SizePoint).MaxPoint.X)
        {
          flag = true;
        }
        else
        {
          double num3 = ((FlatViewSettings) ((ProfileRuntimeSettings) OP).SizePoint).MinPoint.X - ((MarbleRuntimeSettings) Options).LeftDistance + ((MarbleRuntimeSettings) Options).ClamperWidth / 2.0;
          double num4 = ((MachineSimulation) ((ProfileRuntimeSettings) OP).SizePoint).MaxPoint.X + ((MarbleRuntimeSettings) Options).RightDistance - ((MarbleRuntimeSettings) Options).ClamperWidth / 2.0;
          flag = num3 < ((buMarbleCalc) Clampers).GeometrixMinX & ((buMarbleCalc) Clampers).GeometrixMinX < num4 || num3 < ((buMarbleCalc) Clampers).GeometrixMaxX & ((buMarbleCalc) Clampers).GeometrixMaxX < num4;
        }
      }
    }
    return flag;
  }

  public bool isExistingClamperSuitableForNew(
    List<ProfileClamper> ExistingClampers,
    int indexExistingClamper,
    List<ProfileClamper> NewClampersList,
    ProfileClamper newClamper,
    GProfileOperation OP,
    ProfileExistingClamperCompare Options,
    ProfileClamperSettings ClamperSettings)
  {
    bool flag;
    if (indexExistingClamper >= 0 & indexExistingClamper <= ExistingClampers.Count - 1)
    {
      double num1 = ((PanelCutMoveCommand) ExistingClampers[indexExistingClamper]).XPosition - ((PanelCutMoveCommand) newClamper).XPosition;
      if (((MarbleRuntimeSettings) Options).UseBig)
      {
        if (Math.Abs(num1) < ((MarbleRuntimeSettings) Options).BigChangeGap)
        {
          if (NewClampersList.Count > 0)
          {
            double num2 = ((PanelCutMoveCommand) ExistingClampers[indexExistingClamper]).XPosition - ((PanelCutMoveCommand) NewClampersList[NewClampersList.Count - 1]).XPosition;
            if (num2 < ((buMarbleCalc) ClamperSettings).MinDistanceFor2Clamper)
            {
              flag = false;
              goto label_17;
            }
            if (num2 > ((buMarbleCalc) ClamperSettings).MaxDistanceFor2Clamper)
            {
              flag = false;
              goto label_17;
            }
          }
          flag = !this.isOperationInsideClamper(OP, ExistingClampers[indexExistingClamper], (OperationInsideClampers) new MarbleDisplaySettings(((MarbleRuntimeSettings) Options).LeftDistance, ((MarbleRuntimeSettings) Options).RightDistance, ((buMarbleCalc) ClamperSettings).ClamperWidth));
          goto label_17;
        }
      }
      else if (Math.Abs(num1) < ((MarbleRuntimeSettings) Options).SmallChangeGap)
      {
        if (NewClampersList.Count > 0)
        {
          double num3 = ((PanelCutMoveCommand) ExistingClampers[indexExistingClamper]).XPosition - ((PanelCutMoveCommand) NewClampersList[NewClampersList.Count - 1]).XPosition;
          if (num3 < ((buMarbleCalc) ClamperSettings).MinDistanceFor2Clamper)
          {
            flag = false;
            goto label_17;
          }
          if (num3 > ((buMarbleCalc) ClamperSettings).MaxDistanceFor2Clamper)
          {
            flag = false;
            goto label_17;
          }
        }
        flag = !this.isOperationInsideClamper(OP, ExistingClampers[indexExistingClamper], (OperationInsideClampers) new MarbleDisplaySettings(((MarbleRuntimeSettings) Options).LeftDistance, ((MarbleRuntimeSettings) Options).RightDistance, ((buMarbleCalc) ClamperSettings).ClamperWidth));
        goto label_17;
      }
    }
    flag = false;
label_17:
    return flag;
  }

  public void Clamper3D(
    double XPosition,
    int Type,
    double ProfileWidth,
    double ProfileHeight,
    ClamperData3D Data,
    ref List<Entity> ClamperEntities)
  {
    ClamperEntities = new List<Entity>();
    if (Type != 1)
      return;
    List<TriangleIndex> triangleIndexList = new List<TriangleIndex>();
    List<Pnt3D> pnt3DList = new List<Pnt3D>();
    Point3D point3D1 = new Point3D(XPosition, -(ProfileWidth + Data.TipPointThickness - Data.ConstantPointThickness) / 2.0, -Data.BottomThickness / 2.0);
    Brep box1 = Brep.CreateBox(Data.Width, ProfileWidth + Data.TipPointThickness + Data.ConstantPointThickness, Data.BottomThickness);
    box1.Regen(new RegenParams(buSystem.RegenDeviation));
    box1.Translate(-(box1.BoxMax.X - box1.BoxMin.X) / 2.0, -(box1.BoxMax.Y - box1.BoxMin.Y) / 2.0, -(box1.BoxMax.Z - box1.BoxMin.Z) / 2.0);
    box1.Translate(point3D1.X, point3D1.Y, point3D1.Z);
    Point3D point3D2 = new Point3D(XPosition, -(ProfileWidth + Data.TipPointThickness / 2.0), Data.ConstantPointHeight / 2.0);
    Brep box2 = Brep.CreateBox(Data.Width, Data.TipPointThickness, Data.ConstantPointHeight);
    box2.Regen(new RegenParams(buSystem.RegenDeviation));
    box2.Translate(-(box2.BoxMax.X - box2.BoxMin.X) / 2.0, -(box2.BoxMax.Y - box2.BoxMin.Y) / 2.0, -(box2.BoxMax.Z - box2.BoxMin.Z) / 2.0);
    box2.Translate(point3D2.X, point3D2.Y, point3D2.Z);
    Point3D point3D3 = new Point3D(XPosition, Data.ConstantPointThickness / 2.0, Data.TipPointHeight / 2.0);
    Brep box3 = Brep.CreateBox(Data.Width, Data.ConstantPointThickness, Data.TipPointHeight);
    box3.Regen(new RegenParams(buSystem.RegenDeviation));
    box3.Translate(-(box3.BoxMax.X - box3.BoxMin.X) / 2.0, -(box3.BoxMax.Y - box3.BoxMin.Y) / 2.0, -(box3.BoxMax.Z - box3.BoxMin.Z) / 2.0);
    box3.Translate(point3D3.X, point3D3.Y, point3D3.Z);
    ClamperEntities.Add((Entity) box1);
    ClamperEntities.Add((Entity) box2);
    ClamperEntities.Add((Entity) box3);
  }
}
