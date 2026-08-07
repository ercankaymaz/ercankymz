// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.FoamSortGroup
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using System;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamSortGroup : buSerilization5
{
  public int Index;
  public bool isError;
  public bool isGCodeCreated;
  public bool CreatedFromDrawing;
  public MaterialBase5 Material;

  public void CreatePlaneEntities(
    buEntity refPlaneEntity,
    buEntity refTextEntity,
    CamPlaneHeightType HeightType,
    int Index,
    Router3AXDisplaySettings Settings,
    ref Entity entPlane,
    ref Entity entText)
  {
    entPlane = (Entity) null;
    entText = (Entity) null;
    Color color = ((hmiUIOptions) ((FoamSettings) Settings).colorPlaneBottom).Color;
    int transperancy = ((hmiUIOptions) ((FoamSettings) Settings).colorPlaneBottom).Transperancy;
    if (HeightType == CamPlaneHeightType.Top)
    {
      color = ((hmiUIOptions) ((FoamSettings) Settings).colorPlaneTop).Color;
      transperancy = ((hmiUIOptions) ((FoamSettings) Settings).colorPlaneTop).Transperancy;
    }
    if (HeightType == CamPlaneHeightType.Retract)
    {
      color = ((hmiUIOptions) ((FoamSettings) Settings).colorPlaneRetract).Color;
      transperancy = ((hmiUIOptions) ((FoamSettings) Settings).colorPlaneRetract).Transperancy;
    }
    if (HeightType == CamPlaneHeightType.Clearance)
    {
      color = ((hmiUIOptions) ((FoamSettings) Settings).colorPlaneClearance).Color;
      transperancy = ((hmiUIOptions) ((FoamSettings) Settings).colorPlaneClearance).Transperancy;
    }
    if (refPlaneEntity != null)
    {
      buAngularDim.Copy(refPlaneEntity, ref entPlane);
      if (entPlane != null)
      {
        if (entPlane.EntityData == null)
          entPlane.EntityData = (object) new ClipperOffset();
        else if (entPlane.EntityData.GetType() != typeof (CustomData))
          entPlane.EntityData = (object) new ClipperOffset();
        CustomData entityData = entPlane.EntityData as CustomData;
        entPlane.Color = Color.FromArgb(transperancy, color);
        entPlane.ColorMethod = colorMethodType.byEntity;
        entPlane.LineTypeMethod = colorMethodType.byEntity;
        entPlane.Selectable = false;
        ((CutterRuntimeSettings) entityData).set_typeDefination(entityTypeDefination.Plane);
        ((DiemakerGrindingShapeSettings) entityData).set_RefIndex(Index);
        ((\u001D.\u0001) entityData).set_ActionName(HeightType.ToString());
      }
    }
    if (refTextEntity == null)
      return;
    buAngularDim.Copy(refTextEntity, ref entText);
    if (entText == null)
      return;
    if (entText.EntityData == null)
      entText.EntityData = (object) new ClipperOffset();
    else if (entText.EntityData.GetType() != typeof (CustomData))
      entText.EntityData = (object) new ClipperOffset();
    CustomData entityData1 = entText.EntityData as CustomData;
    entText.Color = Color.FromArgb(((hmiUIOptions) ((FoamSettings) Settings).colorPlaneText).Transperancy, ((hmiUIOptions) ((FoamSettings) Settings).colorPlaneText).Color);
    entText.ColorMethod = colorMethodType.byEntity;
    entText.LineTypeMethod = colorMethodType.byEntity;
    entText.Selectable = false;
    ((CutterRuntimeSettings) entityData1).set_typeDefination(entityTypeDefination.Plane);
    ((DiemakerGrindingShapeSettings) entityData1).set_RefIndex(Index);
    ((\u001D.\u0001) entityData1).set_ActionName(HeightType.ToString());
  }

  public actionTypeBU CamDrillTypeToAction(CamDrillType DrillType)
  {
    return DrillType != CamDrillType.Point ? actionTypeBU.None : actionTypeBU.routerCamDrillPoint;
  }

  public actionTypeBU CamWireframeTypeToAction(CamWireFrameType WireType)
  {
    actionTypeBU action;
    switch (WireType)
    {
      case CamWireFrameType.Contour:
        action = actionTypeBU.routerCamContours;
        break;
      case CamWireFrameType.Pocket:
        action = actionTypeBU.routerCamPocketing;
        break;
      case CamWireFrameType.FloorFinish:
        action = actionTypeBU.routerCamFloorFinish;
        break;
      case CamWireFrameType.Engrave:
        action = actionTypeBU.routerCamEngrave;
        break;
      case CamWireFrameType.TextEngrave:
        action = actionTypeBU.routerCamTextEngrave;
        break;
      case CamWireFrameType.Chamfer2D:
        action = actionTypeBU.routerCamChamfer;
        break;
      case CamWireFrameType.Face:
        action = actionTypeBU.routerCamFace;
        break;
      case CamWireFrameType.Trochoidal:
        action = actionTypeBU.routerCamTrochoidial;
        break;
      case CamWireFrameType.CenterPath:
        action = actionTypeBU.routerCamCenterPath;
        break;
      default:
        action = actionTypeBU.None;
        break;
    }
    return action;
  }
}
