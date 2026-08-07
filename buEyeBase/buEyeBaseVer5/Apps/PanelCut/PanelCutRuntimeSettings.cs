// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PanelCut.PanelCutRuntimeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public class PanelCutRuntimeSettings : buSerilization5
{
  public double velLeave;
  public double velAreaClearance;
  public double stepDistance;

  public PanelCutRuntimeSettings()
  {
    ((ProfileSettings) this).ItemName = "";
    ((ProfileSettings) this).FileName = "";
    ((ProfileSettings) this).FileNameFull = "";
    ((ProfileSettings) this).IsClamperDone = false;
    ((ProfileSettings) this).isSimulationDone = false;
    ((ProfileSettings) this).isCollisionControlDone = false;
    ((ProfileSettings) this).isError = false;
    ((ProfileSettings) this).isSupportBlockOffsetAdd = false;
    ((ProfileSettings) this).isStandartProfile = false;
    ((ProfileSettings) this).isCollisionOnlineAvailable = false;
    ((ProfileSettings) this).isCollisionOfflineAvailable = false;
    ((ProfileSettings) this).isGCodeCreated = false;
    ((ProfileSettings) this).isGCodeSimMoveCreated = false;
    ((ProfileSettings) this).CreatedFromDrawing = false;
    ((ProfileSettings) this).Enable = true;
    ((ProfileSettings) this).Selected = false;
    ((ProfileSettings) this).ClamperChanged = false;
    ((ProfileSettings) this).YDirection = 1;
    ((ProfileSettings) this).StandartProfileIndex = -1;
    ((ProfileSettings) this).Length = 1000.0;
    ((ProfileSettings) this).Width = 0.0;
    ((ProfileSettings) this).Height = 0.0;
    ((ProfileSettings) this).TotalWidth = 0.0;
    ((ProfileSettings) this).Thickness = 1.0;
    ((ProfileSettings) this).LeftAngle = 0.0;
    ((ProfileSettings) this).RightAngle = 0.0;
    ((ProfileSettings) this).MaxOperationXPosition = 0.0;
    ((ProfileSettings) this).MaxClamperNumber = 4;
    ((ProfileSettings) this).TextureName = "";
    ((ProfileSettings) this).colorProfile = Color.DarkGray;
    ((ProfileSettings) this).colorSupportBlock = Color.Lime;
    ((ProfileSettings) this).TotalOffset = new Point3D();
    ((ProfileSettings) this).ProfileMinPoint = new Point3D();
    ((ProfileSettings) this).ProfileMaxPoint = new Point3D();
    ((ProfileSettings) this).ProfileCenterPoint = new Point3D();
    ((ProfileSettings) this).ProfileOffset = new Point3D();
    ((ProfileSettings) this).XReferanceLocation = LeftRightType.Left;
    ((ProfileSettings) this).ProfileType = ProfileNewType.Drawing;
    ((ProfileSettings) this).Color = Color.DarkGray;
    ((ProfileSettings) this).Transparency = 120;
    ((ProfileSettings) this).Direction = new Vector3D(1.0, 0.0, 0.0);
    ((ProfileSettings) this).SupportBlock = (ProfileSupportBlock) new MarbleTempVars();
    ((ProfileSettings) this).MultiplyProfile = (ProfileMultiply) new MarbleRuntimeSettings();
    ((ProfileSettings) this).Skin = new MaterialSkin();
    ((ProfileSettings) this).selectedFreePlanes = new List<SelectedPlaneInfo>();
    ((ProfileSettings) this).Operations = new List<ProfileOperation>();
    ((ProfileSettings) this).CalculationData = new List<ProfileItemCalc>();
    ((ProfileSettings) this).Items = new List<buShape>();
    ((ProfileSettings) this).Drawings = new List<ProfileDrawings>();
    ((ProfileSettings) this).ClamperSettings = (ProfileClamperSettings) new MarbleItemExtend();
    ((ProfileSettings) this).LeftAngleEntity = (Entity) null;
    ((ProfileSettings) this).RightAngleEntity = (Entity) null;
    ((ProfileSettings) this).ProfileReferanceEntity = (Entity) null;
    ((ProfileSettings) this).ProfileReferanceBottomEntity = (Entity) null;
    ((ProfileSettings) this).ProfileReferanceBackEntity = (Entity) null;
    ((ProfileSettings) this).SupportBlockEntities = (List<Entity>) null;
    ((ProfileSettings) this).auxEntities = (List<Entity>) null;
    ((ProfileSettings) this).ProfileTraformations = new List<string>();
    ((ProfileSettings) this).GCodeList = new List<string>();
    ((ProfileSettings) this).warningAllList = new List<string>();
    ((ProfileSettings) this).errorAllList = new List<string>();
    ((ProfileSettings) this).infoAllList = new List<string>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public PanelCutRuntimeSettings(ProfileItem data, bool Less = false)
  {
    ((ProfileSettings) this).ItemName = "";
    ((ProfileSettings) this).FileName = "";
    ((ProfileSettings) this).FileNameFull = "";
    ((ProfileSettings) this).IsClamperDone = false;
    ((ProfileSettings) this).isSimulationDone = false;
    ((ProfileSettings) this).isCollisionControlDone = false;
    ((ProfileSettings) this).isError = false;
    ((ProfileSettings) this).isSupportBlockOffsetAdd = false;
    ((ProfileSettings) this).isStandartProfile = false;
    ((ProfileSettings) this).isCollisionOnlineAvailable = false;
    ((ProfileSettings) this).isCollisionOfflineAvailable = false;
    ((ProfileSettings) this).isGCodeCreated = false;
    ((ProfileSettings) this).isGCodeSimMoveCreated = false;
    ((ProfileSettings) this).CreatedFromDrawing = false;
    ((ProfileSettings) this).Enable = true;
    ((ProfileSettings) this).Selected = false;
    ((ProfileSettings) this).ClamperChanged = false;
    ((ProfileSettings) this).YDirection = 1;
    ((ProfileSettings) this).StandartProfileIndex = -1;
    ((ProfileSettings) this).Length = 1000.0;
    ((ProfileSettings) this).Width = 0.0;
    ((ProfileSettings) this).Height = 0.0;
    ((ProfileSettings) this).TotalWidth = 0.0;
    ((ProfileSettings) this).Thickness = 1.0;
    ((ProfileSettings) this).LeftAngle = 0.0;
    ((ProfileSettings) this).RightAngle = 0.0;
    ((ProfileSettings) this).MaxOperationXPosition = 0.0;
    ((ProfileSettings) this).MaxClamperNumber = 4;
    ((ProfileSettings) this).TextureName = "";
    ((ProfileSettings) this).colorProfile = Color.DarkGray;
    ((ProfileSettings) this).colorSupportBlock = Color.Lime;
    ((ProfileSettings) this).TotalOffset = new Point3D();
    ((ProfileSettings) this).ProfileMinPoint = new Point3D();
    ((ProfileSettings) this).ProfileMaxPoint = new Point3D();
    ((ProfileSettings) this).ProfileCenterPoint = new Point3D();
    ((ProfileSettings) this).ProfileOffset = new Point3D();
    ((ProfileSettings) this).XReferanceLocation = LeftRightType.Left;
    ((ProfileSettings) this).ProfileType = ProfileNewType.Drawing;
    ((ProfileSettings) this).Color = Color.DarkGray;
    ((ProfileSettings) this).Transparency = 120;
    ((ProfileSettings) this).Direction = new Vector3D(1.0, 0.0, 0.0);
    ((ProfileSettings) this).SupportBlock = (ProfileSupportBlock) new MarbleTempVars();
    ((ProfileSettings) this).MultiplyProfile = (ProfileMultiply) new MarbleRuntimeSettings();
    ((ProfileSettings) this).Skin = new MaterialSkin();
    ((ProfileSettings) this).selectedFreePlanes = new List<SelectedPlaneInfo>();
    ((ProfileSettings) this).Operations = new List<ProfileOperation>();
    ((ProfileSettings) this).CalculationData = new List<ProfileItemCalc>();
    ((ProfileSettings) this).Items = new List<buShape>();
    ((ProfileSettings) this).Drawings = new List<ProfileDrawings>();
    ((ProfileSettings) this).ClamperSettings = (ProfileClamperSettings) new MarbleItemExtend();
    ((ProfileSettings) this).LeftAngleEntity = (Entity) null;
    ((ProfileSettings) this).RightAngleEntity = (Entity) null;
    ((ProfileSettings) this).ProfileReferanceEntity = (Entity) null;
    ((ProfileSettings) this).ProfileReferanceBottomEntity = (Entity) null;
    ((ProfileSettings) this).ProfileReferanceBackEntity = (Entity) null;
    ((ProfileSettings) this).SupportBlockEntities = (List<Entity>) null;
    ((ProfileSettings) this).auxEntities = (List<Entity>) null;
    ((ProfileSettings) this).ProfileTraformations = new List<string>();
    ((ProfileSettings) this).GCodeList = new List<string>();
    ((ProfileSettings) this).warningAllList = new List<string>();
    ((ProfileSettings) this).errorAllList = new List<string>();
    ((ProfileSettings) this).infoAllList = new List<string>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    if (data == null)
      return;
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    ((ProfileSettings) this).ProfileCenterPoint = new Point3D(((ProfileSettings) data).ProfileCenterPoint.X, ((ProfileSettings) data).ProfileCenterPoint.Y, ((ProfileSettings) data).ProfileCenterPoint.Z);
    ((ProfileSettings) this).ProfileMinPoint = new Point3D(((ProfileSettings) data).ProfileMinPoint.X, ((ProfileSettings) data).ProfileMinPoint.Y, ((ProfileSettings) data).ProfileMinPoint.Z);
    ((ProfileSettings) this).ProfileMaxPoint = new Point3D(((ProfileSettings) data).ProfileMaxPoint.X, ((ProfileSettings) data).ProfileMaxPoint.Y, ((ProfileSettings) data).ProfileMaxPoint.Z);
    ((ProfileSettings) this).ClamperSettings = (ProfileClamperSettings) new MarbleItemExtend(((ProfileSettings) data).ClamperSettings);
    ((ProfileSettings) this).SupportBlock = (ProfileSupportBlock) new MarbleRuntimeSettings(((ProfileSettings) data).SupportBlock);
    ((ProfileSettings) this).MultiplyProfile = (ProfileMultiply) new MarbleRuntimeSettings(((ProfileSettings) data).MultiplyProfile);
    buLineCam.Copy(((ProfileSettings) data).Items, ref ((ProfileSettings) this).Items);
    if (((ProfileSettings) data).CalculationData != null)
    {
      for (int index = 0; index <= ((ProfileSettings) data).CalculationData.Count - 1; ++index)
        ((ProfileSettings) this).CalculationData.Add((ProfileItemCalc) new buMarbleCalc(((ProfileSettings) data).CalculationData[index]));
    }
    if (!Less)
    {
      for (int index = 0; index <= ((ProfileSettings) data).selectedFreePlanes.Count - 1; ++index)
        ((ProfileSettings) this).selectedFreePlanes.Add((SelectedPlaneInfo) new hmiUISettings(((ProfileSettings) data).selectedFreePlanes[index]));
      if (((ProfileSettings) data).ProfileReferanceEntity != null)
        ((ProfileSettings) this).ProfileReferanceEntity = buVector5.CopyEntities(((ProfileSettings) data).ProfileReferanceEntity);
      if (((ProfileSettings) data).ProfileReferanceBottomEntity != null)
        ((ProfileSettings) this).ProfileReferanceBottomEntity = buVector5.CopyEntities(((ProfileSettings) data).ProfileReferanceBottomEntity);
      if (((ProfileSettings) data).ProfileReferanceBackEntity != null)
        ((ProfileSettings) this).ProfileReferanceBackEntity = buVector5.CopyEntities(((ProfileSettings) data).ProfileReferanceBackEntity);
      if (((ProfileSettings) data).LeftAngleEntity != null)
        ((ProfileSettings) this).LeftAngleEntity = buVector5.CopyEntities(((ProfileSettings) data).LeftAngleEntity);
      if (((ProfileSettings) data).RightAngleEntity != null)
        ((ProfileSettings) this).RightAngleEntity = buVector5.CopyEntities(((ProfileSettings) data).RightAngleEntity);
      if (((ProfileSettings) this).SupportBlockEntities != null)
      {
        for (int index = 0; index <= ((ProfileSettings) data).SupportBlockEntities.Count - 1; ++index)
          ((ProfileSettings) this).SupportBlockEntities.Add(buVector5.CopyEntities(((ProfileSettings) data).SupportBlockEntities[index]));
      }
      if (((ProfileSettings) this).auxEntities != null)
      {
        for (int index = 0; index <= ((ProfileSettings) data).auxEntities.Count - 1; ++index)
          ((ProfileSettings) this).auxEntities.Add(buVector5.CopyEntities(((ProfileSettings) data).auxEntities[index]));
      }
      if (((ProfileSettings) data).Drawings != null)
      {
        for (int index = 0; index <= ((ProfileSettings) data).Drawings.Count - 1; ++index)
          ((ProfileSettings) this).Drawings.Add((ProfileDrawings) new MarbleItemOperations(((ProfileSettings) data).Drawings[index]));
      }
    }
    ((ProfileSettings) this).Operations = new List<ProfileOperation>();
    buMarbleCalc.Copy(((ProfileSettings) data).Operations, ref ((ProfileSettings) this).Operations);
  }
}
