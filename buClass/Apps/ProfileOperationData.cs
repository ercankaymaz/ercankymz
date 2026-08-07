// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ProfileOperationData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class ProfileOperationData : buSerilization
{
  public ProfileOperationDataCircle CircleData = new ProfileOperationDataCircle();
  public ProfileOperationDataRectangle RectangleData = new ProfileOperationDataRectangle();
  public ProfileOperationDataRectangleRound RectangleRoundData = new ProfileOperationDataRectangleRound();
  public ProfileOperationDataCut CutData = new ProfileOperationDataCut();
  public ProfileOperationDataSlot SlotData = new ProfileOperationDataSlot();
  public ProfileOperationDataEllipse EllipseData = new ProfileOperationDataEllipse();
  public ProfileOperationDataNotch NotchData = new ProfileOperationDataNotch();
  public ProfileOperationDataHole HoleData = new ProfileOperationDataHole();
  public ProfileOperationDataBarel BarelData = new ProfileOperationDataBarel();
  public ProfileOperationDataFreeDraw FreeDrawData = new ProfileOperationDataFreeDraw();
  public ProfileOperationDataText TextData = new ProfileOperationDataText();
  public ProfileArray Array = new ProfileArray();
  public double DepthTopPlaneValue = 0.0;
  public double DepthLeftPlaneValue = 0.0;
  public double DepthRightPlaneValue = 0.0;
  public double DepthFreePlaneValue = 0.0;
  public double ExtraDepth = 0.0;
  public bool ExtraDepthEnable = false;
  public bool EachLayer = false;
  public bool IncrementalMode = false;
  public double SupportBlockZThickness = 0.0;
  public double SupportBlockYThickness = 0.0;
  public double ProfileLength = 0.0;
  public double PlaneSlopeLength = 10.0;
  public Pnt3D PositionLast = new Pnt3D();
  public Pnt3D Position = new Pnt3D();
  public Pnt3D PositionCircle = new Pnt3D();
  public Pnt3D PositionRectangle = new Pnt3D();
  public Pnt3D PositionRoundRect = new Pnt3D();
  public Pnt3D PositionSlot = new Pnt3D();
  public Pnt3D PositionHole = new Pnt3D();
  public Pnt3D PositionEllipse = new Pnt3D();
  public Pnt3D PositionKeyHole = new Pnt3D();
  public Pnt3D PositionText = new Pnt3D();
  public Pnt3D PositionFreeDraw = new Pnt3D();
  public Pnt3D PositionCut = new Pnt3D();
  public planeNames PlaneSelectedName = planeNames.Top;
  public WorkPlane PlaneSelected = new WorkPlane();
  public ProfileOperationTypes OperationType = ProfileOperationTypes.Circle;
  public ProfileDepth DepthData = new ProfileDepth();
  public ProfilePlaneData Plane = new ProfilePlaneData();
  public List<DepthPosition> DepthValues = new List<DepthPosition>();
  public List<DepthPosition> DepthSelectedValues = new List<DepthPosition>();
  public List<double> DepthAllPositions = new List<double>();
  public ProfileYAxisDirection YDirection = ProfileYAxisDirection.NegativeDirection;
  public static List<string> Captions = new List<string>();

  public ProfileOperationData()
  {
  }

  public ProfileOperationData(ProfileOperationData data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
    this.Array = new ProfileArray(data.Array);
    this.PlaneSelected = new WorkPlane(data.PlaneSelected);
    this.DepthData = new ProfileDepth(data.DepthData);
    this.Plane = new ProfilePlaneData(data.Plane);
    this.DepthValues.Clear();
    for (int index = 0; index <= data.DepthValues.Count - 1; ++index)
      this.DepthValues.Add(new DepthPosition(data.DepthValues[index]));
    this.DepthSelectedValues.Clear();
    for (int index = 0; index <= data.DepthSelectedValues.Count - 1; ++index)
      this.DepthSelectedValues.Add(new DepthPosition(data.DepthSelectedValues[index]));
    this.DepthAllPositions.Clear();
    for (int index = 0; index <= data.DepthAllPositions.Count - 1; ++index)
      this.DepthAllPositions.Add(data.DepthAllPositions[index]);
    this.CircleData = new ProfileOperationDataCircle(data.CircleData);
    this.RectangleData = new ProfileOperationDataRectangle(data.RectangleData);
    this.RectangleRoundData = new ProfileOperationDataRectangleRound(data.RectangleRoundData);
    this.SlotData = new ProfileOperationDataSlot(data.SlotData);
    this.EllipseData = new ProfileOperationDataEllipse(data.EllipseData);
    this.NotchData = new ProfileOperationDataNotch(data.NotchData);
    this.HoleData = new ProfileOperationDataHole(data.HoleData);
    this.BarelData = new ProfileOperationDataBarel(data.BarelData);
    this.FreeDrawData = new ProfileOperationDataFreeDraw(data.FreeDrawData);
    this.TextData = new ProfileOperationDataText(data.TextData);
    this.CutData = new ProfileOperationDataCut(data.CutData);
  }

  public override string ToString() => "OP : " + this.OperationType.ToString();
}
