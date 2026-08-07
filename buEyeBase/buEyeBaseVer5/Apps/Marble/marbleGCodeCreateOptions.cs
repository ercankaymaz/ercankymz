// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleGCodeCreateOptions
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleGCodeCreateOptions : buSerilization5
{
  public double CountertopRectangleWidth;
  public double CountertopRectangleHeight;
  public double CountertopLWidth;

  public string SetEntityCommand(
    string Cmd,
    int ItemID,
    int EdgeIndex,
    int EntityOutsideIndex,
    int EntityInsideIndex,
    int EntityInsideSubIndex,
    string Info,
    string Aux)
  {
    return $"{Cmd};{ItemID.ToString()};{EdgeIndex.ToString()};{EntityOutsideIndex.ToString()};{EntityInsideIndex.ToString()};{EntityInsideSubIndex.ToString()};{Info};{Aux}";
  }

  public bool GetEntityCommand(string refWord, ref EntityCommandArgs e)
  {
    string[] strArray = refWord.Split(';');
    bool entityCommand;
    if ((strArray == null ? 0 : (strArray.Length >= 8 ? 1 : 0)) != 0)
    {
      ((buMarbleForms) e).Command = strArray[0];
      ((buMarbleForms) e).ItemID = Convert.ToInt32(strArray[1]);
      ((buMarbleForms) e).EdgeIndex = Convert.ToInt32(strArray[2]);
      ((buMarbleForms) e).EntityOutsideIndex = Convert.ToInt32(strArray[3]);
      ((buMarbleForms) e).EntityInsideIndex = Convert.ToInt32(strArray[4]);
      ((buMarbleForms) e).EntityInsideSubIndex = Convert.ToInt32(strArray[5]);
      ((buMarbleForms) e).Info = strArray[6];
      ((buMarbleForms) e).Aux = strArray[7];
      entityCommand = true;
    }
    else
      entityCommand = false;
    return entityCommand;
  }

  public void CreatedSlatEntities(
    buEntity EdgeEntity,
    buEntitiesGroup EntGroup,
    ref Entity entSolid,
    ref List<buEntity> LongCutEntities,
    ref List<buEntity> ShortCutEntities)
  {
    ClockDirectionType clockDirectionType = buCall.\u0001.EntitiesClockDirection(((\u0084.\u0001) EntGroup.Outside).Entities);
    CamOpenContourType Direction = CamOpenContourType.Right;
    if (clockDirectionType == ClockDirectionType.CW)
      Direction = CamOpenContourType.Left;
    List<Point3D> calcPoints = new List<Point3D>();
    buEntity calcEntity = (buEntity) null;
    buCall.\u0001.OffsetEntityAndCreateEntityByDirection(EdgeEntity, ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).SlatOffset, ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).SlatWidth, Direction, ((marbleCountertopCavityPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).OutsideContourLeadIn, ((marbleCountertopCavityPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).OutsideContourLeadOut, ref calcPoints, ref calcEntity, ref LongCutEntities, ref ShortCutEntities);
    devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region((ICurve) new LinearPath((ICollection<Point3D>) calcPoints), Plane.XY);
    entSolid = (Entity) region.ExtrudeAsBrep(((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).MaterialThickness, 0.0, 0.0);
    entSolid.Color = Color.FromArgb(((hmiUIOptions) ((marbleSlicesPars) MarbleEntitiesSettings.varMarbleColorSettings).colorItemContour).Transperancy, ((hmiUIOptions) ((marbleSlicesPars) MarbleEntitiesSettings.varMarbleColorSettings).colorItemContour).Color);
    entSolid.ColorMethod = colorMethodType.byEntity;
  }

  public void CreateInsideCutCamItem(
    MarbleJob Job,
    ref MarbleItem MI,
    ToolBase5 toolSaw,
    camParameters5 buPar)
  {
    // ISSUE: unable to decompile the method.
  }

  public void CreateEdgesFromEntityGroup(
    buEntitiesGroup EntGroup,
    double Thickness,
    double ToolDiameter,
    ref List<marbleEdgeItem> Edges)
  {
    if (Edges == null)
      Edges = new List<marbleEdgeItem>();
    Edges.Clear();
    ClockDirectionType clock = buCall.\u0001.EntitiesClockDirection(((\u0084.\u0001) EntGroup.Outside).Entities);
    for (int index = 0; index <= ((\u0084.\u0001) EntGroup.Outside).Entities.Count - 1; ++index)
    {
      string name = "";
      if (((EntityDataSet) ((CustomData) ((\u0084.\u0001) EntGroup.Outside).Entities[index]).Info).Data != null)
        name = ((EntityDataSet) ((CustomData) ((\u0084.\u0001) EntGroup.Outside).Entities[index]).Info).Data;
      if (name.Trim().Length == 0)
        name = buLangTranslate.preDef.Edge;
      marbleEdgeItem marbleEdgeItem = (marbleEdgeItem) new \u0007.\u0001(name, 0.0, clock, Thickness, false, ((marbleMaterialPars) MarbleEntitiesSettings.varCountertopSettings).SocketDefaultWidth, ((marbleMaterialPars) MarbleEntitiesSettings.varCountertopSettings).SocketDefaultHeight);
      ((MarbleCornerCleanToolType) marbleEdgeItem).IndexEntity = index;
      buDiametricDim.Copy(((\u0084.\u0001) EntGroup.Outside).Entities[index], ref ((MarbleSliceType) marbleEdgeItem).refEntity);
      ((AnalyseEntitiesSetting) ((CustomData) ((MarbleSliceType) marbleEdgeItem).refEntity).Info).EntityIndex = index;
      Edges.Add(marbleEdgeItem);
    }
    if (EntGroup.Inside == null)
      return;
    for (int index1 = 0; index1 <= EntGroup.Inside.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ((\u0084.\u0001) EntGroup.Inside[index1]).Entities.Count - 1; ++index2)
      {
        string name = "";
        if (((EntityDataSet) ((CustomData) ((\u0084.\u0001) EntGroup.Inside[index1]).Entities[index2]).Info).Data != null)
          name = ((EntityDataSet) ((CustomData) ((\u0084.\u0001) EntGroup.Inside[index1]).Entities[index2]).Info).Data;
        if (name.Trim().Length == 0)
          name = buLangTranslate.preDef.Edge;
        double num1 = buCall.\u0001.EntityLength(((\u0084.\u0001) EntGroup.Inside[index1]).Entities[index2]);
        double num2 = ((marbleDrillPars) buCall.\u0001).DistanceCalcFromToolDiameterAndThickness(ToolDiameter, ((MarbleCamType) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).MaterialParameter).MaterialThickness, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).TargetZ, 0.0, 0.0) + ((marbleCountertopCavityPars) ((MarbleMachineSimultionSettings) MarbleRuntimeSettings.varOperation).settingMarbleCam).InnerCutSafeDistance;
        if (ToolDiameter == 0.0)
          num2 = 0.0;
        if (num1 > num2)
        {
          marbleEdgeItem marbleEdgeItem = (marbleEdgeItem) new \u0007.\u0001(name, 0.0, clock, Thickness, true, ((marbleMaterialPars) MarbleEntitiesSettings.varCountertopSettings).SocketDefaultWidth, ((marbleMaterialPars) MarbleEntitiesSettings.varCountertopSettings).SocketDefaultHeight);
          ((MarbleSliceType) marbleEdgeItem).OutsideInside = OutsideInsideType.Inside;
          ((MarbleCornerCleanToolType) marbleEdgeItem).IndexEntity = index2;
          ((MarbleMillingToolType) marbleEdgeItem).IndexEntitySub = index1;
          buDiametricDim.Copy(((\u0084.\u0001) EntGroup.Inside[index1]).Entities[index2], ref ((MarbleSliceType) marbleEdgeItem).refEntity);
          ((AnalyseEntitiesSetting) ((CustomData) ((MarbleSliceType) marbleEdgeItem).refEntity).Info).EntityIndex = index2;
          ((AnalyseEntitiesSetting) ((CustomData) ((MarbleSliceType) marbleEdgeItem).refEntity).Info).EntitySubIndex = index1;
          Edges.Add(marbleEdgeItem);
        }
      }
    }
  }
}
