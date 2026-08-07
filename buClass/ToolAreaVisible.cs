// Decompiled with JetBrains decompiler
// Type: buClass.ToolAreaVisible
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ToolAreaVisible : buSerilization
{
  public bool Name = true;
  public bool No = true;
  public bool Sector = true;
  public bool HeightOffsetIndex = true;
  public bool Tag = true;
  public bool Purpose = true;
  public bool Clone = true;
  public bool Broken = true;
  public bool Diameter = true;
  public bool Length = true;
  public bool Thickness = true;
  public bool MinLength = true;
  public bool VectorDirection = true;
  public bool Geometry = true;
  public bool Stepover = true;
  public bool Cutover = true;
  public bool OperationHeight = true;
  public bool FeedSpeed = true;
  public bool PlungeSpeed = true;
  public bool FinishSpeed = true;
  public bool AreaClearanceSpeed = true;
  public bool SpindleSpeed = true;
  public bool OperationHeigthForSecond = true;
  public bool SafeDistance = true;
  public bool SpindleDirection = true;
  public bool SolidColor = true;
  public bool CutColor = true;
  public bool HolderColor = true;
  public bool BodyColor = true;
  public bool CamColor = true;
  public bool UpperCamColor = true;
  public bool PlungeColor = true;
  public bool LeaveColor = true;
  public bool SetPositionXYZ = true;
  public bool SetPositionABC = true;
  public bool OffsetXYZ = true;
  public bool OffsetABC = true;
  public bool AngularPosition = true;
  public bool LimitAxisA = true;
  public bool LimitAxisB = true;
  public bool LimitAxisC = true;
  public bool PlaneLimits = true;
  public bool Outputs = true;
  public bool Water = true;
  public bool Air = true;
  public bool Oil = true;
  public bool InnerCooling = true;
  public bool ToolType = true;
  public bool Priority = true;
  public bool DistanceForOrientation = true;
  public bool Size = true;
  public bool PositionAngle = true;
  public bool DataTabVisible = true;
  public bool GeometryTabVisible = true;
  public bool CamTabVisible = true;
  public bool PositionTabVisible = false;
  public bool AuxTabVisible = true;
  public bool ColorTabVisible = true;
  public bool LimitTabVisible = true;

  public ToolAreaVisible()
  {
  }

  public ToolAreaVisible(ToolAreaVisible geo)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) geo, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
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

  public ToolAreaVisible(ToolPageVisible data)
  {
    this.Air = data.ShowAir;
    this.AngularPosition = data.ShowAngularPosition;
    this.AreaClearanceSpeed = data.ShowAreaClearanceVelocity;
    this.BodyColor = data.ShowColorBody;
    this.CamColor = data.ShowColorCam;
    this.Clone = data.ShowClone;
    this.CutColor = data.ShowColorToolCuttings;
    this.Cutover = data.ShowCutOverride;
    this.FeedSpeed = data.ShowFeedVelocity;
    this.FinishSpeed = data.ShowFinishVelocity;
    this.HeightOffsetIndex = data.ShowHeightOffsetIndex;
    this.HolderColor = data.ShowColorHolder;
    this.InnerCooling = data.ShowInnerCooler;
    this.LimitAxisA = data.ShowAxisALimits;
    this.LimitAxisB = data.ShowAxisBLimits;
    this.LimitAxisC = data.ShowAxisCLimits;
    this.MinLength = data.ShowMinLength;
    this.Name = data.ShowName;
    this.No = data.ShowNo;
    this.OffsetABC = data.ShowOffsetABC;
    this.OffsetXYZ = data.ShowOfsetXYZ;
    this.Oil = data.ShowOil;
    this.OperationHeight = data.ShowOperationHeight;
    this.OperationHeigthForSecond = data.ShowSecondHeadHeight;
    this.Outputs = data.ShowOutputs;
    this.PlaneLimits = data.ShowPlaneLimits;
    this.PlungeSpeed = data.ShowPlungeVelocity;
    this.Purpose = data.ShowPurpose;
    this.SafeDistance = data.ShowSafeDistance;
    this.Sector = data.ShowSector;
    this.SetPositionABC = data.ShowSetPositionABC;
    this.SetPositionXYZ = data.ShowSetPositionXYZ;
    this.SolidColor = data.ShowColorToolBody;
    this.SpindleDirection = data.ShowSpindleDirection;
    this.SpindleSpeed = data.ShowSpindleSpeed;
    this.Stepover = data.ShowStepOverride;
    this.Tag = data.ShowTag;
    this.ToolType = data.ShowGeometryType;
    this.UpperCamColor = data.ShowColorUpper;
    this.VectorDirection = data.ShowVector;
    this.Water = data.ShowWater;
    this.PlungeColor = data.ShowColorPlunge;
    this.LeaveColor = data.ShowColorLeave;
    this.DataTabVisible = data.ShowTabData;
    this.GeometryTabVisible = data.ShowTabGeometry;
    this.CamTabVisible = data.ShowTabCam;
    this.AuxTabVisible = data.ShowTabAux;
    this.LimitTabVisible = data.ShowTabLimit;
    this.PositionTabVisible = data.ShowTabPosition;
    this.ColorTabVisible = data.ShowTabColor;
  }
}
