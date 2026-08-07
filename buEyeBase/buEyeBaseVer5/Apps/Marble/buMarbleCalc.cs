// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.buMarbleCalc
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

public class buMarbleCalc
{
  public double GeometrixMaxX;
  public double GeometrixMinX;
  public double XOffset;
  public double Width;
  public string Text;
  public double MaxPositionRange;
  public double MinPositionRange;
  public bool Used;
  public bool Enable;
  public bool isCollision;
  public static byte f004598;
  public double MinDistanceFor2Clamper;
  public double MaxDistanceFor2Clamper;
  public double ClamperWidth;
  public double ClamperSafeDistance;
  public double OperationFrontLeftMinDistance;
  public double OperationFrontRightMinDistance;
  public double OperationBackLeftMinDistance;
  public double OperationBackRightMinDistance;
  public double OperationTopLeftMinDistance;
  public double OperationTopRightMinDistance;
  public double StartOffset;
  public double EndOffset;
  public double StartMaxDistance;
  public double EndMaxDistance;
  public double ClamperMaxHeight;
  public double NotchSafeXDistance;
  public double NextOperationsSearchDistance;
  public double ClamperOptimisationLevel;
  public bool ApplyManuelNewClamperToNext;
  public double FreePlaneToBackFrontAngleLimit;
  public double ClamperProfileOutsideOffset;
  public bool IfClamperOverOrCloseToAnotherOneMovetoLimit;
  public double OperationClamperLeftMaxDistance;
  public double OperationClamperRightMaxDistance;
  public double LastClamperExtensionLimit;
  public profileSortSequenceAtSamePosition SortSequenceAtSamePosition;
  public int ClamperCalculationMode;
  public double ProfileLength;

  public static void Decode(ArrayList AL, ref List<ProfileItem> Items)
  {
    Items.Clear();
    Items = new List<ProfileItem>();
    List<List<string>> stringListList = new List<List<string>>();
    List<List<string>> CalcList = new List<List<string>>();
    buStatics.ListToSpecificList("<ProfileItem>", "</ProfileItem>", true, AL, ref CalcList);
    for (int index = 0; index <= CalcList.Count - 1; ++index)
    {
      ArrayList AL1 = new ArrayList();
      AL1.AddRange((ICollection) CalcList[index].ToArray());
      ProfileItem profileItem = (ProfileItem) new PanelCutRuntimeSettings();
      buMarbleCalc.Decode(AL1, ref profileItem);
      Items.Add(profileItem);
    }
  }

  public static void Decode(ArrayList AL, ref ProfileItem Item)
  {
    Item = (ProfileItem) new PanelCutRuntimeSettings();
    buSerilization5.Decode(AL, "", (SerilizationMode5) 1, (object) Item);
    List<List<string>> CalcList1 = new List<List<string>>();
    List<List<string>> CalcList2 = new List<List<string>>();
    buStatics.ListToSpecificList("<Drawings>", "</Drawings>", true, AL, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      for (int index1 = 0; index1 <= CalcList2.Count - 1; ++index1)
      {
        List<string> CalcList3 = new List<string>();
        buStatics.ListToSpecificList("<Drawings>", "</Drawings>", true, CalcList2[index1], ref CalcList3);
        ProfileDrawings profileDrawings = (ProfileDrawings) new MarbleItemOperations();
        List<string> CalcList4 = new List<string>();
        buStatics.ListToSpecificList("<OutterEntitites>", "</OutterEntitites>", false, CalcList3, ref CalcList4);
        buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList4, ref CalcList1);
        for (int index2 = 0; index2 <= CalcList1.Count - 1; ++index2)
        {
          buEntity buEntity = buText.Decode(CalcList1[index2]);
          if (buEntity != null)
            ((MarbleJob) profileDrawings).OutterEntitites.Add(buEntity);
        }
        List<string> CalcList5 = new List<string>();
        List<List<string>> CalcList6 = new List<List<string>>();
        buStatics.ListToSpecificList("<InnerEntitites>", "</InnerEntitites>", false, CalcList3, ref CalcList5);
        buStatics.ListToSpecificList("<InnerEntititesSub>", "</InnerEntititesSub>", false, CalcList5, ref CalcList6);
        for (int index3 = 0; index3 <= CalcList6.Count - 1; ++index3)
        {
          buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList6[index3], ref CalcList1);
          List<buEntity> buEntityList = new List<buEntity>();
          for (int index4 = 0; index4 <= CalcList1.Count - 1; ++index4)
          {
            buEntity buEntity = buText.Decode(CalcList1[index4]);
            if (buEntity != null)
              buEntityList.Add(buEntity);
          }
          if (buEntityList.Count > 0)
            ((MarbleJob) profileDrawings).InnerEntities.Add(buEntityList);
        }
        ((ProfileSettings) Item).Drawings.Add(profileDrawings);
        CalcList3.Clear();
      }
    }
    else
    {
      ProfileDrawings profileDrawings = (ProfileDrawings) new MarbleItemOperations();
      List<string> CalcList7 = new List<string>();
      buStatics.ListToSpecificList("<OutterEntitites>", "</OutterEntitites>", false, AL, ref CalcList7);
      buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList7, ref CalcList1);
      for (int index = 0; index <= CalcList1.Count - 1; ++index)
      {
        buEntity buEntity = buText.Decode(CalcList1[index]);
        if (buEntity != null)
          ((MarbleJob) profileDrawings).OutterEntitites.Add(buEntity);
      }
      List<string> CalcList8 = new List<string>();
      List<List<string>> CalcList9 = new List<List<string>>();
      buStatics.ListToSpecificList("<InnerEntitites>", "</InnerEntitites>", false, AL, ref CalcList8);
      buStatics.ListToSpecificList("<InnerEntititesSub>", "</InnerEntititesSub>", false, CalcList8, ref CalcList9);
      for (int index5 = 0; index5 <= CalcList9.Count - 1; ++index5)
      {
        buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList9[index5], ref CalcList1);
        List<buEntity> buEntityList = new List<buEntity>();
        for (int index6 = 0; index6 <= CalcList1.Count - 1; ++index6)
        {
          buEntity buEntity = buText.Decode(CalcList1[index6]);
          if (buEntity != null)
            buEntityList.Add(buEntity);
        }
        if (buEntityList.Count > 0)
          ((MarbleJob) profileDrawings).InnerEntities.Add(buEntityList);
      }
      ((ProfileSettings) Item).Drawings.Add(profileDrawings);
    }
    CalcList1 = new List<List<string>>();
    buStatics.ListToSpecificList("<PrfOperation>", "</PrfOperation>", false, AL, ref CalcList1);
    if (CalcList1.Count == 0)
      buStatics.ListToSpecificList("<Operations>", "</Operations>", false, AL, ref CalcList1);
    for (int index7 = 0; index7 <= CalcList1.Count - 1; ++index7)
    {
      new ArrayList().AddRange((ICollection) CalcList1[index7].ToArray());
      ProfileOperation OP = (ProfileOperation) new buMarbleCalc();
      buMarbleCalc.Decode(CalcList1[index7], ref OP);
      if (((ProfileRuntimeSettings) OP).MinPoint.X != ((ProfileRuntimeSettings) OP).MaxPoint.X)
      {
        ((MWCalculationOptions) ((camOffset5) ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).CamParNotch).Notch).NotchCutType = ((PanelCutMoveCommand) ((ProfileRuntimeSettings) OP).CamOPData).NotchCutType;
        if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.FreeDraw)
        {
          ((ProfileRuntimeSettings) OP).EntityMultiContour = new List<buEntity>();
          ((ProfileRuntimeSettings) OP).EntityMultiXYPlane = new List<buEntity>();
          List<string> CalcList10 = new List<string>();
          buStatics.ListToSpecificList("<ContourEntitites>", "</ContourEntitites>", false, CalcList1[index7], ref CalcList10);
          if (CalcList10.Count > 0)
          {
            List<List<string>> CalcList11 = new List<List<string>>();
            buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList10, ref CalcList11);
            for (int index8 = 0; index8 <= CalcList11.Count - 1; ++index8)
            {
              buEntity buEntity = buText.Decode(CalcList11[index8]);
              if (buEntity != null)
                ((ProfileRuntimeSettings) OP).EntityMultiContour.Add(buEntity);
            }
            CalcList11.Clear();
          }
          CalcList10.Clear();
          List<string> CalcList12 = new List<string>();
          buStatics.ListToSpecificList("<ContourEntititesXY>", "</ContourEntititesXY>", false, CalcList1[index7], ref CalcList12);
          if (CalcList12.Count > 0)
          {
            List<List<string>> CalcList13 = new List<List<string>>();
            buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList12, ref CalcList13);
            for (int index9 = 0; index9 <= CalcList13.Count - 1; ++index9)
            {
              buEntity buEntity = buText.Decode(CalcList13[index9]);
              if (buEntity != null)
                ((ProfileRuntimeSettings) OP).EntityMultiXYPlane.Add(buEntity);
            }
            CalcList13.Clear();
          }
          CalcList12.Clear();
        }
        ((ProfileSettings) Item).Operations.Add(OP);
      }
    }
    CalcList1.Clear();
    CalcList2.Clear();
  }

  public override string ToString()
  {
    return $"{((ProfileSettings) this).ItemName.ToString()}- Len: {((ProfileSettings) this).Length.ToString("f3")} - OP: {((ProfileSettings) this).Operations.Count.ToString()}";
  }

  public abstract void m001DC3();

  public buMarbleCalc()
  {
    ((ProfileSettings) this).IsClamperDone = false;
    ((ProfileSettings) this).isSimulationDone = false;
    ((ProfileSettings) this).isError = false;
    ((ProfileSettings) this).OriginalIsLongProfile = false;
    ((ProfileSettings) this).Width = 0.0;
    ((ProfileSettings) this).Height = 0.0;
    ((ProfileSettings) this).Length = 1000.0;
    ((ProfileSettings) this).MaxOperationXPosition = 0.0;
    ((ProfileSettings) this).LongProfileFirstPartLength = 0.0;
    ((ProfileSettings) this).MaxClamperNumber = 4;
    ((ProfileSettings) this).TotalOffset = new Point3D();
    ((ProfileSettings) this).ProfileMinPoint = new Point3D();
    ((ProfileSettings) this).ProfileMaxPoint = new Point3D();
    ((ProfileSettings) this).ProfileCenterPoint = new Point3D();
    ((ProfileSettings) this).XReferanceLocation = LeftRightType.Left;
    ((ProfileSettings) this).CalcType = ProfileExcType.Normal;
    ((ProfileSettings) this).calcOperations = new List<GProfileOperation>();
    ((ProfileSettings) this).ClamperSettings = (ProfileClamperSettings) new MarbleItemExtend();
    ((ProfileSettings) this).SimMoves = new List<Pnt6DSimMove>();
    ((ProfileSettings) this).ProfileTraformations = new List<string>();
    ((ProfileSettings) this).Cams = new List<camTp>();
    ((ProfileSettings) this).GCodesItem = new List<string>();
    ((ProfileSettings) this).ClamperLists = new List<List<ProfileClamper>>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buMarbleCalc(ProfileItemCalc data)
  {
    ((ProfileSettings) this).IsClamperDone = false;
    ((ProfileSettings) this).isSimulationDone = false;
    ((ProfileSettings) this).isError = false;
    ((ProfileSettings) this).OriginalIsLongProfile = false;
    ((ProfileSettings) this).Width = 0.0;
    ((ProfileSettings) this).Height = 0.0;
    ((ProfileSettings) this).Length = 1000.0;
    ((ProfileSettings) this).MaxOperationXPosition = 0.0;
    ((ProfileSettings) this).LongProfileFirstPartLength = 0.0;
    ((ProfileSettings) this).MaxClamperNumber = 4;
    ((ProfileSettings) this).TotalOffset = new Point3D();
    ((ProfileSettings) this).ProfileMinPoint = new Point3D();
    ((ProfileSettings) this).ProfileMaxPoint = new Point3D();
    ((ProfileSettings) this).ProfileCenterPoint = new Point3D();
    ((ProfileSettings) this).XReferanceLocation = LeftRightType.Left;
    ((ProfileSettings) this).CalcType = ProfileExcType.Normal;
    ((ProfileSettings) this).calcOperations = new List<GProfileOperation>();
    ((ProfileSettings) this).ClamperSettings = (ProfileClamperSettings) new MarbleItemExtend();
    ((ProfileSettings) this).SimMoves = new List<Pnt6DSimMove>();
    ((ProfileSettings) this).ProfileTraformations = new List<string>();
    ((ProfileSettings) this).Cams = new List<camTp>();
    ((ProfileSettings) this).GCodesItem = new List<string>();
    ((ProfileSettings) this).ClamperLists = new List<List<ProfileClamper>>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
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
    ((ProfileSettings) this).calcOperations = new List<GProfileOperation>();
    buMarbleCalc.Copy(((ProfileSettings) data).calcOperations, ref ((ProfileSettings) this).calcOperations);
    PointABC.Copy(((ProfileSettings) data).SimMoves, ref ((ProfileSettings) this).SimMoves);
    for (int index = 0; index <= ((ProfileSettings) data).Cams.Count - 1; ++index)
      ((ProfileSettings) this).Cams.Add(new camTp(((ProfileSettings) data).Cams[index]));
    for (int index = 0; index <= ((ProfileSettings) data).ClamperLists.Count - 1; ++index)
    {
      List<ProfileClamper> CopiedClamper = new List<ProfileClamper>();
      MarbleItemEntities.Copy(((ProfileSettings) data).ClamperLists[index], ref CopiedClamper);
      ((ProfileSettings) this).ClamperLists.Add(CopiedClamper);
    }
  }

  public buMarbleCalc(ProfileItem data, bool CopyOperations = false)
  {
    ((ProfileSettings) this).IsClamperDone = false;
    ((ProfileSettings) this).isSimulationDone = false;
    ((ProfileSettings) this).isError = false;
    ((ProfileSettings) this).OriginalIsLongProfile = false;
    ((ProfileSettings) this).Width = 0.0;
    ((ProfileSettings) this).Height = 0.0;
    ((ProfileSettings) this).Length = 1000.0;
    ((ProfileSettings) this).MaxOperationXPosition = 0.0;
    ((ProfileSettings) this).LongProfileFirstPartLength = 0.0;
    ((ProfileSettings) this).MaxClamperNumber = 4;
    ((ProfileSettings) this).TotalOffset = new Point3D();
    ((ProfileSettings) this).ProfileMinPoint = new Point3D();
    ((ProfileSettings) this).ProfileMaxPoint = new Point3D();
    ((ProfileSettings) this).ProfileCenterPoint = new Point3D();
    ((ProfileSettings) this).XReferanceLocation = LeftRightType.Left;
    ((ProfileSettings) this).CalcType = ProfileExcType.Normal;
    ((ProfileSettings) this).calcOperations = new List<GProfileOperation>();
    ((ProfileSettings) this).ClamperSettings = (ProfileClamperSettings) new MarbleItemExtend();
    ((ProfileSettings) this).SimMoves = new List<Pnt6DSimMove>();
    ((ProfileSettings) this).ProfileTraformations = new List<string>();
    ((ProfileSettings) this).Cams = new List<camTp>();
    ((ProfileSettings) this).GCodesItem = new List<string>();
    ((ProfileSettings) this).ClamperLists = new List<List<ProfileClamper>>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((ProfileSettings) this).Length = ((ProfileSettings) data).Length;
    ((ProfileSettings) this).Width = ((ProfileSettings) data).Width;
    ((ProfileSettings) this).Height = ((ProfileSettings) data).Height;
    ((ProfileSettings) this).MaxOperationXPosition = ((ProfileSettings) data).MaxOperationXPosition;
    ((ProfileSettings) this).MaxClamperNumber = ((ProfileSettings) data).MaxClamperNumber;
    ((ProfileSettings) this).IsClamperDone = ((ProfileSettings) data).IsClamperDone;
    ((ProfileSettings) this).isSimulationDone = ((ProfileSettings) data).isSimulationDone;
    ((ProfileSettings) this).isError = ((ProfileSettings) data).isError;
    ((ProfileSettings) this).XReferanceLocation = ((ProfileSettings) data).XReferanceLocation;
    ((ProfileSettings) this).TotalOffset = new Point3D(((ProfileSettings) data).TotalOffset.X, ((ProfileSettings) data).TotalOffset.Y, ((ProfileSettings) data).TotalOffset.Z);
    ((ProfileSettings) this).ProfileCenterPoint = new Point3D(((ProfileSettings) data).ProfileCenterPoint.X, ((ProfileSettings) data).ProfileCenterPoint.Y, ((ProfileSettings) data).ProfileCenterPoint.Z);
    ((ProfileSettings) this).ProfileMinPoint = new Point3D(((ProfileSettings) data).ProfileMinPoint.X, ((ProfileSettings) data).ProfileMinPoint.Y, ((ProfileSettings) data).ProfileMinPoint.Z);
    ((ProfileSettings) this).ProfileMaxPoint = new Point3D(((ProfileSettings) data).ProfileMaxPoint.X, ((ProfileSettings) data).ProfileMaxPoint.Y, ((ProfileSettings) data).ProfileMaxPoint.Z);
    ((ProfileSettings) this).ClamperSettings = (ProfileClamperSettings) new MarbleItemExtend(((ProfileSettings) data).ClamperSettings);
    ((ProfileSettings) this).calcOperations = new List<GProfileOperation>();
    if (CopyOperations)
    {
      for (int index1 = 0; index1 <= ((ProfileSettings) data).Operations.Count - 1; ++index1)
      {
        if (((ShapeRuntimeData) ((DepthPositionOptions) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index1]).OperationData).Array).LineerEnable & ((ShapeRuntimeData) ((DepthPositionOptions) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index1]).OperationData).Array).LineerXCount * ((ShapeRuntimeData) ((DepthPositionOptions) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index1]).OperationData).Array).LineerYCount > 1)
        {
          int num = ((ShapeRuntimeData) ((DepthPositionOptions) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index1]).OperationData).Array).LineerXCount * ((ShapeRuntimeData) ((DepthPositionOptions) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index1]).OperationData).Array).LineerYCount;
          for (int index2 = 0; index2 <= num - 1; ++index2)
          {
            GProfileOperation data1 = (GProfileOperation) new buMarbleCalc(((ProfileSettings) data).Operations[index1]);
            ((ProfileRuntimeSettings) data1).EntityMultiCam.Clear();
            List<buEntity> refEntities = new List<buEntity>();
            for (int index3 = 0; index3 <= ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index1]).EntityMultiCam.Count - 1; ++index3)
            {
              if (((EntityDataSet) ((CustomData) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index1]).EntityMultiCam[index3]).Info).CamID == index2)
                ((ProfileRuntimeSettings) data1).EntityMultiCam.Add(buAngularDim.Copy(((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index1]).EntityMultiCam[index3]));
            }
            for (int index4 = 0; index4 <= ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index1]).EntityMultiContour.Count - 1; ++index4)
            {
              if (((EntityDataSet) ((CustomData) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index1]).EntityMultiContour[index4]).Info).CamID == index2)
                refEntities.Add(buAngularDim.Copy(((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index1]).EntityMultiContour[index4]));
            }
            if (refEntities.Count > 0)
            {
              buCall.\u0001.BoxSizeCalculate(refEntities, ref ((FlatViewSettings) ((ProfileRuntimeSettings) data1).SizePoint).MinPoint, ref ((FlatViewSettings) ((ProfileRuntimeSettings) data1).SizePoint).MidPoint, ref ((MachineSimulation) ((ProfileRuntimeSettings) data1).SizePoint).MaxPoint);
              ((MachineSimulation) ((ProfileRuntimeSettings) data1).SizePoint).Delta.X = ((MachineSimulation) ((ProfileRuntimeSettings) data1).SizePoint).MaxPoint.X - ((FlatViewSettings) ((ProfileRuntimeSettings) data1).SizePoint).MinPoint.X;
              ((MachineSimulation) ((ProfileRuntimeSettings) data1).SizePoint).Delta.Y = ((MachineSimulation) ((ProfileRuntimeSettings) data1).SizePoint).MaxPoint.Y - ((FlatViewSettings) ((ProfileRuntimeSettings) data1).SizePoint).MinPoint.Y;
              ((MachineSimulation) ((ProfileRuntimeSettings) data1).SizePoint).Delta.Z = ((MachineSimulation) ((ProfileRuntimeSettings) data1).SizePoint).MaxPoint.Z - ((FlatViewSettings) ((ProfileRuntimeSettings) data1).SizePoint).MinPoint.Z;
              ((ProfilePatternCopy) ((ProfileRuntimeSettings) data1).OperationData).Position.X = ((FlatViewSettings) ((ProfileRuntimeSettings) data1).SizePoint).MidPoint.X;
            }
            refEntities.Clear();
            if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index1]).OperationData).OperationType == ProfileOperationTypes.Tapping)
            {
              GProfileOperation gprofileOperation = (GProfileOperation) new buMarbleCalc(data1);
              ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) gprofileOperation).OperationData).OperationType = ProfileOperationTypes.Hole;
              ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) gprofileOperation).OperationData).Action = actionTypeBU.profileHole;
              if (((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index1]).ToolAux != null)
                ((ProfileRuntimeSettings) gprofileOperation).Tool = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index1]).ToolAux);
              ((ProfileSettings) this).calcOperations.Add(gprofileOperation);
            }
            ((ProfileSettings) this).calcOperations.Add(data1);
          }
        }
        else if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index1]).OperationData).OperationType == ProfileOperationTypes.Tapping)
        {
          GProfileOperation gprofileOperation1 = (GProfileOperation) new buMarbleCalc(((ProfileSettings) data).Operations[index1]);
          ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) gprofileOperation1).OperationData).OperationType = ProfileOperationTypes.Hole;
          ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) gprofileOperation1).OperationData).Action = actionTypeBU.profileHole;
          if (((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index1]).ToolAux != null)
            ((ProfileRuntimeSettings) gprofileOperation1).Tool = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index1]).ToolAux);
          ((ProfileSettings) this).calcOperations.Add(gprofileOperation1);
          GProfileOperation gprofileOperation2 = (GProfileOperation) new buMarbleCalc(((ProfileSettings) data).Operations[index1]);
          if (((ProfileMirror) ((ProfileRuntimeSettings) gprofileOperation2).OperationData).selectedPlaneName == planeNames.Top)
          {
            if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) gprofileOperation2).OperationData).DepthValues.Count > 0)
            {
              double num = ((NestingPanelNode) ((DepthPositions) ((ProfileRuntimeSettings) gprofileOperation2).OperationData).HoleData).TappingDepth - Math.Abs(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) gprofileOperation2).OperationData).DepthValues[0]).Depth);
              for (int index5 = 0; index5 <= ((ProfileRuntimeSettings) gprofileOperation2).CamCalculation[0].CamPoints[0].Points.Count - 1; ++index5)
              {
                if (((ProfileRuntimeSettings) gprofileOperation2).CamCalculation[0].CamPoints[0].Points[index5].PlungeAxisMovement)
                  ((TpArcData) ((ProfileRuntimeSettings) gprofileOperation2).CamCalculation[0].CamPoints[0].Points[index5]).P9.Z = ((TpArcData) ((ProfileRuntimeSettings) gprofileOperation2).CamCalculation[0].CamPoints[0].Points[index5]).P9.Z - num;
              }
            }
          }
          if (((ProfileMirror) ((ProfileRuntimeSettings) gprofileOperation2).OperationData).selectedPlaneName == planeNames.Front)
          {
            if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) gprofileOperation2).OperationData).DepthValues.Count > 0)
            {
              double num = ((NestingPanelNode) ((DepthPositions) ((ProfileRuntimeSettings) gprofileOperation2).OperationData).HoleData).TappingDepth - Math.Abs(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) gprofileOperation2).OperationData).DepthValues[0]).Depth);
              for (int index6 = 0; index6 <= ((ProfileRuntimeSettings) gprofileOperation2).CamCalculation[0].CamPoints[0].Points.Count - 1; ++index6)
              {
                if (((ProfileRuntimeSettings) gprofileOperation2).CamCalculation[0].CamPoints[0].Points[index6].PlungeAxisMovement)
                  ((TpArcData) ((ProfileRuntimeSettings) gprofileOperation2).CamCalculation[0].CamPoints[0].Points[index6]).P9.Y = ((TpArcData) ((ProfileRuntimeSettings) gprofileOperation2).CamCalculation[0].CamPoints[0].Points[index6]).P9.Y + num;
              }
            }
          }
          if (((ProfileMirror) ((ProfileRuntimeSettings) gprofileOperation2).OperationData).selectedPlaneName == planeNames.Back)
          {
            if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) gprofileOperation2).OperationData).DepthValues.Count > 0)
            {
              double num = ((NestingPanelNode) ((DepthPositions) ((ProfileRuntimeSettings) gprofileOperation2).OperationData).HoleData).TappingDepth - Math.Abs(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) gprofileOperation2).OperationData).DepthValues[0]).Depth);
              for (int index7 = 0; index7 <= ((ProfileRuntimeSettings) gprofileOperation2).CamCalculation[0].CamPoints[0].Points.Count - 1; ++index7)
              {
                if (((ProfileRuntimeSettings) gprofileOperation2).CamCalculation[0].CamPoints[0].Points[index7].PlungeAxisMovement)
                {
                  ((ProfileRuntimeSettings) gprofileOperation2).CamCalculation[0].CamPoints[0].Points[index7].Type = 0;
                  ((TpArcData) ((ProfileRuntimeSettings) gprofileOperation2).CamCalculation[0].CamPoints[0].Points[index7]).P9.Y = ((TpArcData) ((ProfileRuntimeSettings) gprofileOperation2).CamCalculation[0].CamPoints[0].Points[index7]).P9.Y - num;
                }
              }
            }
          }
          ((ProfileSettings) this).calcOperations.Add(gprofileOperation2);
        }
        else
          ((ProfileSettings) this).calcOperations.Add((GProfileOperation) new buMarbleCalc(((ProfileSettings) data).Operations[index1]));
      }
    }
    if (((MarbleJob) ((ProfileSettings) data).MultiplyProfile).ProfileMultiplyEnable & ((MarbleJob) ((ProfileSettings) data).MultiplyProfile).ProfileMultiplyCount > 1)
    {
      if (!((MarbleJob) ((ProfileSettings) data).MultiplyProfile).ProfileMultiplyMirror)
      {
        for (int index8 = 1; index8 <= ((MarbleJob) ((ProfileSettings) data).MultiplyProfile).ProfileMultiplyCount - 1; ++index8)
        {
          double num = (double) index8 * (((ProfileSettings) data).Width + ((MarbleJob) ((ProfileSettings) data).MultiplyProfile).ProfileMultiplySpace);
          for (int index9 = 0; index9 <= ((ProfileSettings) data).Operations.Count - 1; ++index9)
          {
            GProfileOperation gprofileOperation = (GProfileOperation) new buMarbleCalc(((ProfileSettings) data).Operations[index9]);
            buCall.\u0001.Move(0.0, -num, 0.0, ref ((ProfileRuntimeSettings) gprofileOperation).EntityMultiCam);
            for (int index10 = 0; index10 <= ((ProfileRuntimeSettings) gprofileOperation).CamCalculation.Count - 1; ++index10)
            {
              camTp Cam = ((ProfileRuntimeSettings) gprofileOperation).CamCalculation[index10];
              buCall.\u0001.MoveCam(0.0, -num, 0.0, ref Cam);
            }
            ((ProfileSettings) this).calcOperations.Add(gprofileOperation);
          }
        }
      }
      else
      {
        double y = -(((ProfileSettings) data).Width + ((MarbleJob) ((ProfileSettings) data).MultiplyProfile).ProfileMultiplySpace / 2.0);
        Mirror mirror1 = new Mirror(new Plane(new Point3D(0.0, y, 0.0), Vector3D.AxisZ, Vector3D.AxisX));
        Mirror mirror2 = new Mirror(new Plane(new Point3D(((ProfileSettings) data).Length / 2.0, 0.0, 0.0), Vector3D.AxisZ, Vector3D.AxisY));
        for (int index11 = 0; index11 <= ((ProfileSettings) data).Operations.Count - 1; ++index11)
        {
          GProfileOperation gprofileOperation = (GProfileOperation) new buMarbleCalc(((ProfileSettings) data).Operations[index11]);
          Point3D P = new Point3D(((ProfilePatternCopy) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index11]).OperationData).selectedPlane.Origin.X, ((ProfilePatternCopy) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index11]).OperationData).selectedPlane.Origin.Y, ((ProfilePatternCopy) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index11]).OperationData).selectedPlane.Origin.Z);
          Vector3D vector3D = new Vector3D(((ProfilePatternCopy) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index11]).OperationData).selectedPlane.AxisZ.X, ((ProfilePatternCopy) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index11]).OperationData).selectedPlane.AxisZ.Y, ((ProfilePatternCopy) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index11]).OperationData).selectedPlane.AxisZ.Z);
          Vector3D Y = new Vector3D(((ProfilePatternCopy) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index11]).OperationData).selectedPlane.AxisY.X, ((ProfilePatternCopy) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index11]).OperationData).selectedPlane.AxisY.Y, ((ProfilePatternCopy) ((ProfileRuntimeSettings) ((ProfileSettings) data).Operations[index11]).OperationData).selectedPlane.AxisY.Z);
          P.TransformBy((Transformation) mirror1);
          Y.TransformBy((Transformation) mirror1);
          P.TransformBy((Transformation) mirror2);
          Y.TransformBy((Transformation) mirror2);
          ((ProfilePatternCopy) ((ProfileRuntimeSettings) gprofileOperation).OperationData).selectedPlane = new Plane(P, ((ProfilePatternCopy) ((ProfileRuntimeSettings) gprofileOperation).OperationData).selectedPlane.AxisX * -1.0, Y);
          for (int index12 = 0; index12 <= ((ProfileRuntimeSettings) gprofileOperation).EntityMultiCam.Count - 1; ++index12)
          {
            ((buAngularDim) ((ProfileRuntimeSettings) gprofileOperation).EntityMultiCam[index12]).TransformBy((Transformation) mirror1);
            ((buAngularDim) ((ProfileRuntimeSettings) gprofileOperation).EntityMultiCam[index12]).TransformBy((Transformation) mirror2);
            ((CustomDataSurrogate) ((ProfileRuntimeSettings) gprofileOperation).EntityMultiCam[index12]).Orientation.A = -((CustomDataSurrogate) ((ProfileRuntimeSettings) gprofileOperation).EntityMultiCam[index12]).Orientation.A;
          }
          for (int index13 = 0; index13 <= ((ProfileRuntimeSettings) gprofileOperation).CamCalculation.Count - 1; ++index13)
          {
            camTp camTp = ((ProfileRuntimeSettings) gprofileOperation).CamCalculation[index13];
            for (int index14 = 0; index14 <= camTp.CamPoints.Count - 1; ++index14)
            {
              for (int index15 = 0; index15 <= camTp.CamPoints[index14].Points.Count - 1; ++index15)
              {
                TpPnt9D point = camTp.CamPoints[index14].Points[index15];
                ((TpArcData) point).P9.A = -((TpArcData) point).P9.A;
                double num1 = y - ((TpArcData) point).P9.Y;
                ((TpArcData) point).P9.Y = y + num1;
                double num2 = ((ProfileSettings) data).Length - ((TpArcData) point).P9.X;
                ((TpArcData) point).P9.X = num2;
              }
            }
          }
          if (((ProfileMirror) ((ProfileRuntimeSettings) gprofileOperation).OperationData).selectedPlaneName == planeNames.Front)
            ((ProfileMirror) ((ProfileRuntimeSettings) gprofileOperation).OperationData).selectedPlaneName = planeNames.Back;
          else if (((ProfileMirror) ((ProfileRuntimeSettings) gprofileOperation).OperationData).selectedPlaneName == planeNames.Back)
            ((ProfileMirror) ((ProfileRuntimeSettings) gprofileOperation).OperationData).selectedPlaneName = planeNames.Front;
          ((ProfileSettings) this).calcOperations.Add(gprofileOperation);
        }
      }
    }
    for (int index = 0; index <= ((ProfileSettings) data).ProfileTraformations.Count - 1; ++index)
      ((ProfileSettings) this).ProfileTraformations.Add(((ProfileSettings) data).ProfileTraformations[index]);
  }

  public override string ToString()
  {
    return $"Len: {((ProfileSettings) this).Length.ToString("f3")} - OP: {((ProfileSettings) this).calcOperations.Count.ToString()}";
  }

  public abstract void m001DC8();

  public buMarbleCalc()
  {
    ((ProfileSettings) this).OpList = new List<GProfileOperation>();
    ((ProfileSettings) this).Size = (BoxSize5) new SortbuOptions();
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public buMarbleCalc(GProfileOperationGroup data)
  {
    ((ProfileSettings) this).OpList = new List<GProfileOperation>();
    ((ProfileSettings) this).Size = (BoxSize5) new SortbuOptions();
    // ISSUE: explicit constructor call
    base.\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
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
    ((ProfileSettings) this).Size = (BoxSize5) new SortbuOptions(((ProfileSettings) data).Size);
    ((ProfileSettings) this).OpList.Clear();
    for (int index = 0; index <= ((ProfileSettings) data).OpList.Count - 1; ++index)
      ((ProfileSettings) this).OpList.Add((GProfileOperation) new buMarbleCalc(((ProfileSettings) data).OpList[index]));
  }

  public override string ToString()
  {
    return $"Op Cnt: {((ProfileSettings) this).OpList.Count.ToString()} - MinX: {((FlatViewSettings) ((ProfileSettings) this).Size).MinPoint.X.ToString("f2")} , MaxX: {((MachineSimulation) ((ProfileSettings) this).Size).MaxPoint.X.ToString("f2")} |  dX: {((MachineSimulation) ((ProfileSettings) this).Size).Delta.X.ToString("f2")}";
  }

  public abstract void m001DCC();

  public buMarbleCalc()
  {
    ((ProfileVisualSettings) this).Depth = 0.0;
    ((ProfileVisualSettings) this).ProfileName = "";
    ((ProfileVisualSettings) this).ProfileWidth = 0.0;
    ((ProfileVisualSettings) this).ProfileHeight = 0.0;
    ((ProfileVisualSettings) this).ProfileLength = 0.0;
    ((ProfileVisualSettings) this).Name = "";
    ((ProfileVisualSettings) this).ID = "";
    ((ProfileVisualSettings) this).Used = false;
    ((ProfileVisualSettings) this).Enable = true;
    ((ProfileVisualSettings) this).isClamperOver = false;
    ((ProfileVisualSettings) this).MoveSafeBeforeOperation = false;
    ((ProfileVisualSettings) this).MoveSafeAfterOperation = false;
    ((ProfileVisualSettings) this).Error = false;
    ((ProfileVisualSettings) this).isCollision = false;
    ((ProfileVisualSettings) this).Calculated = false;
    ((ProfileVisualSettings) this).Selected = false;
    ((ProfileVisualSettings) this).Priority = 0;
    ((ProfileVisualSettings) this).ClamperIndex = -1;
    ((ProfileVisualSettings) this).CollisionClamperIndex = -1;
    ((ProfileVisualSettings) this).Action = actionTypeBU.None;
    ((ProfileVisualSettings) this).XReferanceLocation = LeftRightType.Left;
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc();
    ((ProfileRuntimeSettings) this).CamOPData = (ProfileOperationCamData) new MarbleItemCam();
    ((ProfileRuntimeSettings) this).CamCalculation = new List<camTp>();
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5();
    ((ProfileRuntimeSettings) this).SizePoint = (BoxSize5) new SortbuOptions();
    ((ProfileRuntimeSettings) this).Clampers = new List<ProfileClamper>();
    ((ProfileRuntimeSettings) this).EntityMultiCam = (List<buEntity>) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buMarbleCalc(GProfileOperation data)
  {
    ((ProfileVisualSettings) this).Depth = 0.0;
    ((ProfileVisualSettings) this).ProfileName = "";
    ((ProfileVisualSettings) this).ProfileWidth = 0.0;
    ((ProfileVisualSettings) this).ProfileHeight = 0.0;
    ((ProfileVisualSettings) this).ProfileLength = 0.0;
    ((ProfileVisualSettings) this).Name = "";
    ((ProfileVisualSettings) this).ID = "";
    ((ProfileVisualSettings) this).Used = false;
    ((ProfileVisualSettings) this).Enable = true;
    ((ProfileVisualSettings) this).isClamperOver = false;
    ((ProfileVisualSettings) this).MoveSafeBeforeOperation = false;
    ((ProfileVisualSettings) this).MoveSafeAfterOperation = false;
    ((ProfileVisualSettings) this).Error = false;
    ((ProfileVisualSettings) this).isCollision = false;
    ((ProfileVisualSettings) this).Calculated = false;
    ((ProfileVisualSettings) this).Selected = false;
    ((ProfileVisualSettings) this).Priority = 0;
    ((ProfileVisualSettings) this).ClamperIndex = -1;
    ((ProfileVisualSettings) this).CollisionClamperIndex = -1;
    ((ProfileVisualSettings) this).Action = actionTypeBU.None;
    ((ProfileVisualSettings) this).XReferanceLocation = LeftRightType.Left;
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc();
    ((ProfileRuntimeSettings) this).CamOPData = (ProfileOperationCamData) new MarbleItemCam();
    ((ProfileRuntimeSettings) this).CamCalculation = new List<camTp>();
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5();
    ((ProfileRuntimeSettings) this).SizePoint = (BoxSize5) new SortbuOptions();
    ((ProfileRuntimeSettings) this).Clampers = new List<ProfileClamper>();
    ((ProfileRuntimeSettings) this).EntityMultiCam = (List<buEntity>) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
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
    ((ProfileRuntimeSettings) this).Clampers.Clear();
    ((ProfileRuntimeSettings) this).Clampers = new List<ProfileClamper>();
    for (int index = 0; index <= ((ProfileRuntimeSettings) data).Clampers.Count - 1; ++index)
      ((ProfileRuntimeSettings) this).Clampers.Add((ProfileClamper) new MarbleItemSettings(((ProfileRuntimeSettings) data).Clampers[index]));
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc(((ProfileRuntimeSettings) data).OperationData);
    ((ProfileRuntimeSettings) this).CamOPData = (ProfileOperationCamData) new MarbleItemCam(((ProfileRuntimeSettings) data).CamOPData);
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) data).Tool);
    ((ProfileRuntimeSettings) this).SizePoint = (BoxSize5) new SortbuOptions(((ProfileRuntimeSettings) data).SizePoint);
    ((ProfileRuntimeSettings) this).CamCalculation = new List<camTp>();
    for (int index = 0; index <= ((ProfileRuntimeSettings) data).CamCalculation.Count - 1; ++index)
      ((ProfileRuntimeSettings) this).CamCalculation.Add(new camTp(((ProfileRuntimeSettings) data).CamCalculation[index]));
    if (((ProfileRuntimeSettings) data).EntityMultiCam == null)
      return;
    ((ProfileRuntimeSettings) this).EntityMultiCam = buDiametricDim.Copy(((ProfileRuntimeSettings) data).EntityMultiCam);
  }

  public buMarbleCalc(ProfileOperation Operation)
  {
    ((ProfileVisualSettings) this).Depth = 0.0;
    ((ProfileVisualSettings) this).ProfileName = "";
    ((ProfileVisualSettings) this).ProfileWidth = 0.0;
    ((ProfileVisualSettings) this).ProfileHeight = 0.0;
    ((ProfileVisualSettings) this).ProfileLength = 0.0;
    ((ProfileVisualSettings) this).Name = "";
    ((ProfileVisualSettings) this).ID = "";
    ((ProfileVisualSettings) this).Used = false;
    ((ProfileVisualSettings) this).Enable = true;
    ((ProfileVisualSettings) this).isClamperOver = false;
    ((ProfileVisualSettings) this).MoveSafeBeforeOperation = false;
    ((ProfileVisualSettings) this).MoveSafeAfterOperation = false;
    ((ProfileVisualSettings) this).Error = false;
    ((ProfileVisualSettings) this).isCollision = false;
    ((ProfileVisualSettings) this).Calculated = false;
    ((ProfileVisualSettings) this).Selected = false;
    ((ProfileVisualSettings) this).Priority = 0;
    ((ProfileVisualSettings) this).ClamperIndex = -1;
    ((ProfileVisualSettings) this).CollisionClamperIndex = -1;
    ((ProfileVisualSettings) this).Action = actionTypeBU.None;
    ((ProfileVisualSettings) this).XReferanceLocation = LeftRightType.Left;
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc();
    ((ProfileRuntimeSettings) this).CamOPData = (ProfileOperationCamData) new MarbleItemCam();
    ((ProfileRuntimeSettings) this).CamCalculation = new List<camTp>();
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5();
    ((ProfileRuntimeSettings) this).SizePoint = (BoxSize5) new SortbuOptions();
    ((ProfileRuntimeSettings) this).Clampers = new List<ProfileClamper>();
    ((ProfileRuntimeSettings) this).EntityMultiCam = (List<buEntity>) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((ProfileVisualSettings) this).Error = ((ProfileRuntimeSettings) Operation).Error;
    ((ProfileVisualSettings) this).Depth = ((ProfileRuntimeSettings) Operation).Depth;
    ((ProfileVisualSettings) this).Action = ((ProfileRuntimeSettings) Operation).Action;
    ((ProfileVisualSettings) this).Enable = ((ProfileRuntimeSettings) Operation).Enable;
    ((ProfileVisualSettings) this).ID = ((ProfileRuntimeSettings) Operation).ID;
    ((ProfileVisualSettings) this).isClamperOver = ((ProfileRuntimeSettings) Operation).isClamperOver;
    ((ProfileVisualSettings) this).MoveSafeAfterOperation = ((ProfileRuntimeSettings) Operation).MoveSafeAfterOperation;
    ((ProfileVisualSettings) this).MoveSafeBeforeOperation = ((ProfileRuntimeSettings) Operation).MoveSafeBeforeOperation;
    ((ProfileVisualSettings) this).Name = ((ProfileRuntimeSettings) Operation).Name;
    ((ProfileVisualSettings) this).ProfileHeight = ((ProfileRuntimeSettings) Operation).ProfileHeight;
    ((ProfileVisualSettings) this).ProfileLength = ((ProfileRuntimeSettings) Operation).ProfileLength;
    ((ProfileVisualSettings) this).ProfileWidth = ((ProfileRuntimeSettings) Operation).ProfileWidth;
    ((ProfileVisualSettings) this).ProfileName = ((ProfileRuntimeSettings) Operation).ProfileName;
    ((ProfileVisualSettings) this).Used = ((ProfileRuntimeSettings) Operation).Used;
    ((ProfileVisualSettings) this).Priority = ((ProfileRuntimeSettings) Operation).Priority;
    ((ProfileVisualSettings) this).XReferanceLocation = ((ProfileRuntimeSettings) Operation).ParentXReferance;
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc(((ProfileRuntimeSettings) Operation).OperationData);
    ((ProfileRuntimeSettings) this).CamOPData = (ProfileOperationCamData) new MarbleItemCam(((ProfileRuntimeSettings) Operation).CamOPData);
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) Operation).Tool);
    ((ProfileRuntimeSettings) this).SizePoint = (BoxSize5) new SortbuCamData(((ProfileRuntimeSettings) Operation).MinPoint, ((ProfileRuntimeSettings) Operation).MaxPoint);
    ((ProfileRuntimeSettings) this).Clampers.Clear();
    for (int index = 0; index <= ((ProfileRuntimeSettings) Operation).Clampers.Count - 1; ++index)
      ((ProfileRuntimeSettings) this).Clampers.Add((ProfileClamper) new MarbleItemSettings(((ProfileRuntimeSettings) Operation).Clampers[index]));
    if (((ProfileRuntimeSettings) Operation).EntityMultiCam != null)
      ((ProfileRuntimeSettings) this).EntityMultiCam = buDiametricDim.Copy(((ProfileRuntimeSettings) Operation).EntityMultiCam);
    ((ProfileRuntimeSettings) this).CamCalculation = new List<camTp>();
    for (int index = 0; index <= ((ProfileRuntimeSettings) Operation).CamCalculation.Count - 1; ++index)
      ((ProfileRuntimeSettings) this).CamCalculation.Add(new camTp(((ProfileRuntimeSettings) Operation).CamCalculation[index]));
  }

  public static void Copy(
    List<List<GProfileOperation>> RefOperation,
    ref List<List<GProfileOperation>> CopiedOperation)
  {
    CopiedOperation.Clear();
    CopiedOperation = new List<List<GProfileOperation>>();
    for (int index = 0; index <= RefOperation.Count - 1; ++index)
    {
      List<GProfileOperation> CopiedOperation1 = new List<GProfileOperation>();
      buMarbleCalc.Copy(RefOperation[index], ref CopiedOperation1);
      CopiedOperation.Add(CopiedOperation1);
    }
  }

  public static void Copy(
    List<GProfileOperation> RefOperation,
    ref List<GProfileOperation> CopiedOperation)
  {
    CopiedOperation.Clear();
    CopiedOperation = new List<GProfileOperation>();
    for (int index = 0; index <= RefOperation.Count - 1; ++index)
    {
      GProfileOperation CopiedOperation1 = (GProfileOperation) new buMarbleCalc();
      buMarbleCalc.Copy(RefOperation[index], ref CopiedOperation1);
      CopiedOperation.Add(CopiedOperation1);
    }
  }

  public static void Copy(GProfileOperation RefOperation, ref GProfileOperation CopiedOperation)
  {
    CopiedOperation = (GProfileOperation) new buMarbleCalc(RefOperation);
  }

  public override string ToString()
  {
    string str = $"{((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) this).OperationData).OperationType.ToString()} =  {((ProfileMirror) ((ProfileRuntimeSettings) this).OperationData).selectedPlaneName.ToString()} - P( {((ProfilePatternCopy) ((ProfileRuntimeSettings) this).OperationData).Position.X.ToString("f2")} , ";
    if (((ProfileMirror) ((ProfileRuntimeSettings) this).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) this).OperationData).selectedPlaneName == planeNames.Bottom | ((ProfileMirror) ((ProfileRuntimeSettings) this).OperationData).selectedPlaneName == planeNames.Free)
      str = $"{str}{((ProfilePatternCopy) ((ProfileRuntimeSettings) this).OperationData).Position.Y.ToString("f2")} )";
    else if (((ProfileMirror) ((ProfileRuntimeSettings) this).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) this).OperationData).selectedPlaneName == planeNames.Back)
      str = $"{str}{((ProfilePatternCopy) ((ProfileRuntimeSettings) this).OperationData).Position.Z.ToString("f2")} )";
    return $"{$"{str} , MinX: {((FlatViewSettings) ((ProfileRuntimeSettings) this).SizePoint).MinPoint.X.ToString("f2")} , MaxX: {((MachineSimulation) ((ProfileRuntimeSettings) this).SizePoint).MaxPoint.X.ToString("f2")}"} - T{((ToolCamData5) ((ToolGeometry5) ((ProfileRuntimeSettings) this).Tool).Data).No.ToString()} Dia: {((ToolGeometry5) ((ProfileRuntimeSettings) this).Tool).Geometry.Diameter.ToString()} ID: {((ProfileVisualSettings) this).ID}";
  }

  public abstract void m001DD4();

  public buMarbleCalc()
  {
    ((ProfileRuntimeSettings) this).Depth = 0.0;
    ((ProfileRuntimeSettings) this).ProfileName = "";
    ((ProfileRuntimeSettings) this).ProfileWidth = 0.0;
    ((ProfileRuntimeSettings) this).ProfileHeight = 0.0;
    ((ProfileRuntimeSettings) this).ProfileLength = 0.0;
    ((ProfileRuntimeSettings) this).Name = "";
    ((ProfileRuntimeSettings) this).ID = "";
    ((ProfileRuntimeSettings) this).Used = false;
    ((ProfileRuntimeSettings) this).Enable = true;
    ((ProfileRuntimeSettings) this).isClamperOver = false;
    ((ProfileRuntimeSettings) this).MoveSafeBeforeOperation = false;
    ((ProfileRuntimeSettings) this).MoveSafeAfterOperation = false;
    ((ProfileRuntimeSettings) this).Error = false;
    ((ProfileRuntimeSettings) this).Selected = false;
    ((ProfileRuntimeSettings) this).XRefFromEnd = false;
    ((ProfileRuntimeSettings) this).Locked = false;
    ((ProfileRuntimeSettings) this).CamAssinged = false;
    ((ProfileRuntimeSettings) this).Priority = 0;
    ((ProfileRuntimeSettings) this).Action = actionTypeBU.None;
    ((ProfileRuntimeSettings) this).ParentXReferance = LeftRightType.Left;
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc();
    ((ProfileRuntimeSettings) this).CamOPData = (ProfileOperationCamData) new MarbleItemCam();
    ((ProfileRuntimeSettings) this).CamCalculation = new List<camTp>();
    ((ProfileRuntimeSettings) this).CamInsideVector = new Vector3D();
    ((ProfileRuntimeSettings) this).CamOutsideVector = new Vector3D();
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5();
    ((ProfileRuntimeSettings) this).ToolNotch = (ToolBase5) new ToolGeometry5();
    ((ProfileRuntimeSettings) this).ToolAux = (ToolBase5) null;
    ((ProfileRuntimeSettings) this).MinPoint = new Point3D();
    ((ProfileRuntimeSettings) this).MaxPoint = new Point3D();
    ((ProfileRuntimeSettings) this).GeoSize = new Point3D();
    ((ProfileRuntimeSettings) this).Clampers = new List<ProfileClamper>();
    ((ProfileRuntimeSettings) this).EntityMultiCam = (List<buEntity>) null;
    ((ProfileRuntimeSettings) this).EntityMultiCamAux = (List<buEntity>) null;
    ((ProfileRuntimeSettings) this).EntityMultiContour = (List<buEntity>) null;
    ((ProfileRuntimeSettings) this).EntityMultiSolidDepth = (List<Entity>) null;
    ((ProfileRuntimeSettings) this).EntityMultiXYPlane = (List<buEntity>) null;
    ((ProfileRuntimeSettings) this).EntityDimension = (List<DimensionGroup>) null;
    ((ProfileRuntimeSettings) this).warningList = new List<string>();
    ((ProfileRuntimeSettings) this).errorList = new List<string>();
    ((ProfileRuntimeSettings) this).infoList = new List<string>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public static void Copy(
    List<List<ProfileOperation>> RefOperation,
    ref List<List<ProfileOperation>> CopiedOperation)
  {
    CopiedOperation.Clear();
    CopiedOperation = new List<List<ProfileOperation>>();
    for (int index = 0; index <= RefOperation.Count - 1; ++index)
    {
      List<ProfileOperation> CopiedOperation1 = new List<ProfileOperation>();
      buMarbleCalc.Copy(RefOperation[index], ref CopiedOperation1);
      CopiedOperation.Add(CopiedOperation1);
    }
  }

  public static void Copy(
    List<ProfileOperation> RefOperation,
    ref List<ProfileOperation> CopiedOperation)
  {
    CopiedOperation.Clear();
    CopiedOperation = new List<ProfileOperation>();
    if (RefOperation.Count <= 0)
      return;
    for (int index = 0; index <= RefOperation.Count - 1; ++index)
    {
      ProfileOperation CopiedOperation1 = (ProfileOperation) new buMarbleCalc();
      buMarbleCalc.Copy(RefOperation[index], ref CopiedOperation1);
      CopiedOperation.Add(CopiedOperation1);
    }
  }

  public static void Copy(ProfileOperation RefOperation, ref ProfileOperation CopiedOperation)
  {
    if (RefOperation.GetType() == typeof (ProfileOperationCircle) | ((ProfileRuntimeSettings) RefOperation).Action == actionTypeBU.profileCircle)
      CopiedOperation = (ProfileOperation) new buMarbleCalc((ProfileOperationCircle) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationRectangle) | ((ProfileRuntimeSettings) RefOperation).Action == actionTypeBU.profileRectangle)
      CopiedOperation = (ProfileOperation) new buMarbleCalc((ProfileOperationRectangle) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationRoundRectangle) | ((ProfileRuntimeSettings) RefOperation).Action == actionTypeBU.profileRoundRectangle)
      CopiedOperation = (ProfileOperation) new buMarbleCalc((ProfileOperationRoundRectangle) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationBarrel) | ((ProfileRuntimeSettings) RefOperation).Action == actionTypeBU.profileBarrel)
      CopiedOperation = (ProfileOperation) new buMarbleCalc((ProfileOperationBarrel) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationEllipse) | ((ProfileRuntimeSettings) RefOperation).Action == actionTypeBU.profileEllipse)
      CopiedOperation = (ProfileOperation) new buMarbleCalc((ProfileOperationEllipse) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationFreeDraw) | ((ProfileRuntimeSettings) RefOperation).Action == actionTypeBU.profileFreeDraw)
      CopiedOperation = (ProfileOperation) new buMarbleCalc((ProfileOperationFreeDraw) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationText) | ((ProfileRuntimeSettings) RefOperation).Action == actionTypeBU.profileText)
      CopiedOperation = (ProfileOperation) new buMarbleCalc((ProfileOperationText) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationText) | ((ProfileRuntimeSettings) RefOperation).Action == actionTypeBU.profileWireText)
      CopiedOperation = (ProfileOperation) new buMarbleCalc((ProfileOperationText) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationHole) | ((ProfileRuntimeSettings) RefOperation).Action == actionTypeBU.profileHole)
      CopiedOperation = (ProfileOperation) new buMarbleCalc((ProfileOperationHole) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationSlot) | ((ProfileRuntimeSettings) RefOperation).Action == actionTypeBU.profileSlot)
      CopiedOperation = (ProfileOperation) new buMarbleCalc((ProfileOperationSlot) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationCut) | ((ProfileRuntimeSettings) RefOperation).Action == actionTypeBU.profileCut)
      CopiedOperation = (ProfileOperation) new buMarbleCalc((ProfileOperationCut) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationNotch) | ((ProfileRuntimeSettings) RefOperation).Action == actionTypeBU.profileNotch)
      CopiedOperation = (ProfileOperation) new buMarbleCalc((ProfileOperationNotch) RefOperation);
    if (RefOperation.GetType() == typeof (ProfileOperationPolygon) | ((ProfileRuntimeSettings) RefOperation).Action == actionTypeBU.profilePolygon)
      CopiedOperation = (ProfileOperation) new buMarbleCalc((ProfileOperationPolygon) RefOperation);
    ((ProfileRuntimeSettings) CopiedOperation).CamOPData = (ProfileOperationCamData) new MarbleItemCam(((ProfileRuntimeSettings) RefOperation).CamOPData);
    ((ProfileRuntimeSettings) CopiedOperation).Clampers.Clear();
    ((ProfileRuntimeSettings) CopiedOperation).Clampers = new List<ProfileClamper>();
    for (int index = 0; index <= ((ProfileRuntimeSettings) RefOperation).Clampers.Count - 1; ++index)
    {
      ProfileClamper profileClamper = (ProfileClamper) new MarbleItemSettings(((ProfileRuntimeSettings) RefOperation).Clampers[index]);
      ((ProfileRuntimeSettings) CopiedOperation).Clampers.Add(profileClamper);
    }
    if (((ProfileRuntimeSettings) RefOperation).EntityDimension != null)
    {
      ((ProfileRuntimeSettings) CopiedOperation).EntityDimension = new List<DimensionGroup>();
      for (int index = 0; index <= ((ProfileRuntimeSettings) RefOperation).EntityDimension.Count - 1; ++index)
        ((ProfileRuntimeSettings) CopiedOperation).EntityDimension.Add((DimensionGroup) new camTp(((ProfileRuntimeSettings) RefOperation).EntityDimension[index]));
    }
    if (((ProfileRuntimeSettings) RefOperation).EntityMultiContour != null)
      ((ProfileRuntimeSettings) CopiedOperation).EntityMultiContour = buDiametricDim.Copy(((ProfileRuntimeSettings) RefOperation).EntityMultiContour);
    if (((ProfileRuntimeSettings) RefOperation).EntityMultiCam != null)
      ((ProfileRuntimeSettings) CopiedOperation).EntityMultiCam = buDiametricDim.Copy(((ProfileRuntimeSettings) RefOperation).EntityMultiCam);
    if (((ProfileRuntimeSettings) RefOperation).EntityMultiCamAux != null)
      ((ProfileRuntimeSettings) CopiedOperation).EntityMultiCamAux = buDiametricDim.Copy(((ProfileRuntimeSettings) RefOperation).EntityMultiCamAux);
    if (((ProfileRuntimeSettings) RefOperation).EntityMultiSolidDepth != null)
      ((ProfileRuntimeSettings) CopiedOperation).EntityMultiSolidDepth = buVector5.CopyEntities(((ProfileRuntimeSettings) RefOperation).EntityMultiSolidDepth);
    if (((ProfileRuntimeSettings) RefOperation).EntityMultiXYPlane != null)
      ((ProfileRuntimeSettings) CopiedOperation).EntityMultiXYPlane = buDiametricDim.Copy(((ProfileRuntimeSettings) RefOperation).EntityMultiXYPlane);
    if (((ProfileRuntimeSettings) CopiedOperation).CamCalculation == null)
    {
      ((ProfileRuntimeSettings) CopiedOperation).CamCalculation = new List<camTp>();
      camTpPoint.CopyCam(((ProfileRuntimeSettings) RefOperation).CamCalculation, ref ((ProfileRuntimeSettings) CopiedOperation).CamCalculation);
    }
    else if (((ProfileRuntimeSettings) RefOperation).CamCalculation.Count != ((ProfileRuntimeSettings) CopiedOperation).CamCalculation.Count)
      camTpPoint.CopyCam(((ProfileRuntimeSettings) RefOperation).CamCalculation, ref ((ProfileRuntimeSettings) CopiedOperation).CamCalculation);
    if (((ProfileRuntimeSettings) RefOperation).ToolAux != null)
      ((ProfileRuntimeSettings) CopiedOperation).ToolAux = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) RefOperation).ToolAux);
    ((ProfileRuntimeSettings) CopiedOperation).ToolNotch = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) RefOperation).ToolNotch);
    ((ProfileRuntimeSettings) CopiedOperation).MinPoint = new Point3D(((ProfileRuntimeSettings) RefOperation).MinPoint.X, ((ProfileRuntimeSettings) RefOperation).MinPoint.Y, ((ProfileRuntimeSettings) RefOperation).MinPoint.Z);
    ((ProfileRuntimeSettings) CopiedOperation).MaxPoint = new Point3D(((ProfileRuntimeSettings) RefOperation).MaxPoint.X, ((ProfileRuntimeSettings) RefOperation).MaxPoint.Y, ((ProfileRuntimeSettings) RefOperation).MaxPoint.Z);
    ((ProfileRuntimeSettings) CopiedOperation).GeoSize = new Point3D(((ProfileRuntimeSettings) RefOperation).GeoSize.X, ((ProfileRuntimeSettings) RefOperation).GeoSize.Y, ((ProfileRuntimeSettings) RefOperation).GeoSize.Z);
    ((ProfileRuntimeSettings) CopiedOperation).CamInsideVector = new Vector3D(((ProfileRuntimeSettings) RefOperation).CamInsideVector.X, ((ProfileRuntimeSettings) RefOperation).CamInsideVector.Y, ((ProfileRuntimeSettings) RefOperation).CamInsideVector.Z);
    ((ProfileRuntimeSettings) CopiedOperation).CamOutsideVector = new Vector3D(((ProfileRuntimeSettings) RefOperation).CamOutsideVector.X, ((ProfileRuntimeSettings) RefOperation).CamOutsideVector.Y, ((ProfileRuntimeSettings) RefOperation).CamOutsideVector.Z);
  }

  public static ArrayList ToDef(List<List<ProfileOperation>> Items, string Char, int Space)
  {
    string str = new string(' ', Space + 2);
    ArrayList def = new ArrayList();
    for (int index1 = 0; index1 <= Items.Count - 1; ++index1)
    {
      ArrayList arrayList = new ArrayList();
      arrayList.Add((object) (str + "<ProfileOperationMain>"));
      for (int index2 = 0; index2 <= Items[index1].Count - 1; ++index2)
      {
        arrayList.Add((object) (str + "<ProfileOperation>"));
        arrayList.AddRange((ICollection) buMarbleCalc.ToDef(Items[index1], Char, Space + 2).ToArray());
        arrayList.Add((object) (str + "</ProfileOperation>"));
      }
      arrayList.Add((object) (str + "</ProfileOperationMain>"));
      def.AddRange((ICollection) arrayList.ToArray());
    }
    return def;
  }

  public static ArrayList ToDef(List<ProfileOperation> Items, string Char, int Space)
  {
    string str = new string(' ', Space + 2);
    ArrayList def = new ArrayList();
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      ArrayList arrayList = new ArrayList();
      arrayList.Add((object) $"{str}<ProfileOperation{Char}>");
      arrayList.AddRange((ICollection) buMarbleCalc.ToDef(Items[index], "", Space + 2).ToArray());
      arrayList.Add((object) $"{str}</ProfileOperation{Char}>");
      def.AddRange((ICollection) arrayList.ToArray());
    }
    return def;
  }

  public static ArrayList ToDef(ProfileOperation Item, string Char, int Space)
  {
    string str = new string(' ', Space);
    ArrayList def = new ArrayList();
    def.Add((object) (buImage5.SpaceChar(Space) + ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Item).OperationData).OperationType.ToString()));
    def.AddRange((ICollection) buMarbleCalc.ToDefPars(Item, Space));
    def.AddRange((ICollection) buMarbleCalc.ToDefPars(((ProfileRuntimeSettings) Item).OperationData, Space));
    def.AddRange((ICollection) MarbleItemCam.ToDefPars(((ProfileRuntimeSettings) Item).CamOPData, Space));
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Item).OperationData).OperationType == ProfileOperationTypes.Circle)
      def.AddRange((ICollection) buMarbleCalc.ToDefPars(((OperationInsideClampers) ((ProfileRuntimeSettings) Item).OperationData).CircleData, Space));
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Item).OperationData).OperationType == ProfileOperationTypes.Rectangle)
      def.AddRange((ICollection) buMarbleCalc.ToDefPars(((DepthPositions) ((ProfileRuntimeSettings) Item).OperationData).RectangleData, Space));
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Item).OperationData).OperationType == ProfileOperationTypes.RoundRectangle)
      def.AddRange((ICollection) buMarbleCalc.ToDefPars(((DepthPositions) ((ProfileRuntimeSettings) Item).OperationData).RectangleRoundData, Space));
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Item).OperationData).OperationType == ProfileOperationTypes.Ellipse)
      def.AddRange((ICollection) buMarbleCalc.ToDefPars(((DepthPositions) ((ProfileRuntimeSettings) Item).OperationData).EllipseData, Space));
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Item).OperationData).OperationType == ProfileOperationTypes.Slot)
      def.AddRange((ICollection) buMarbleCalc.ToDefPars(((DepthPositions) ((ProfileRuntimeSettings) Item).OperationData).SlotData, Space));
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Item).OperationData).OperationType == ProfileOperationTypes.Barrel)
      def.AddRange((ICollection) buMarbleCalc.ToDefPars(((DepthPositions) ((ProfileRuntimeSettings) Item).OperationData).BarelData, Space));
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Item).OperationData).OperationType == ProfileOperationTypes.Polygon)
      def.AddRange((ICollection) buMarbleCalc.ToDefPars(((DepthPositionOptions) ((ProfileRuntimeSettings) Item).OperationData).PolygonData, Space));
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Item).OperationData).OperationType == ProfileOperationTypes.Hole)
    {
      // ISSUE: reference to a compiler-generated method
      def.AddRange((ICollection) buMarbleCalc.\u003C\u003Ec.ToDefPars(((DepthPositions) ((ProfileRuntimeSettings) Item).OperationData).HoleData, Space));
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Item).OperationData).OperationType == ProfileOperationTypes.FreeDraw)
      def.AddRange((ICollection) MarbleJob.ToDefPars(((DepthPositionOptions) ((ProfileRuntimeSettings) Item).OperationData).FreeDrawData, Space));
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Item).OperationData).OperationType == ProfileOperationTypes.Text)
      def.AddRange((ICollection) MarbleItem.ToDefPars(((DepthPositionOptions) ((ProfileRuntimeSettings) Item).OperationData).TextData, Space));
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Item).OperationData).OperationType == ProfileOperationTypes.WireText)
      def.AddRange((ICollection) MarbleItem.ToDefPars(((DepthPositionOptions) ((ProfileRuntimeSettings) Item).OperationData).TextData, Space));
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Item).OperationData).OperationType == ProfileOperationTypes.Cut)
      def.AddRange((ICollection) buMarbleCalc.ToDefPars(((DepthPositions) ((ProfileRuntimeSettings) Item).OperationData).CutData, Space));
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Item).OperationData).OperationType == ProfileOperationTypes.Notch)
      def.AddRange((ICollection) buMarbleCalc.ToDefPars(((DepthPositions) ((ProfileRuntimeSettings) Item).OperationData).NotchData, Space));
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Item).OperationData).OperationType == ProfileOperationTypes.Polygon)
      def.AddRange((ICollection) buMarbleCalc.ToDefPars(((DepthPositionOptions) ((ProfileRuntimeSettings) Item).OperationData).PolygonData, Space));
    def.Add((object) (buImage5.SpaceChar(Space) + "<Clampers>"));
    for (int index = 0; index <= ((ProfileRuntimeSettings) Item).Clampers.Count - 1; ++index)
      def.AddRange((ICollection) ((ProfileRuntimeSettings) Item).Clampers[index].ToDefAll(Char, Space + 2, (SerilizationMode5) 1));
    def.Add((object) (buImage5.SpaceChar(Space) + "</Clampers>"));
    def.Add((object) (buImage5.SpaceChar(Space) + "<DepthValues>"));
    for (int index = 0; index <= ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Item).OperationData).DepthValues.Count - 1; ++index)
      def.AddRange((ICollection) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Item).OperationData).DepthValues[index].ToDefAll(Char, Space + 2, (SerilizationMode5) 1));
    def.Add((object) (buImage5.SpaceChar(Space) + "</DepthValues>"));
    return def;
  }

  public static ArrayList ToDefPars(ProfileOperation P, int Space)
  {
    return new ArrayList()
    {
      (object) (buImage5.SpaceChar(Space) + "<ProfileOperationPars>"),
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) (buImage5.SpaceChar(Space) + "</ProfileOperationPars>")
    };
  }

  public static string ToDefPars(ProfileOperation P) => buSerilization5.ClassToString((object) P);

  public static void Decode(List<string> Lines, ref ProfileOperation OP)
  {
    if (Lines.Count <= 0)
      return;
    if (Lines[0].Trim().ToLower() == "rectangle")
      OP = (ProfileOperation) new buMarbleCalc();
    if (Lines[0].Trim().ToLower() == "circle")
      OP = (ProfileOperation) new buMarbleCalc();
    if (Lines[0].Trim().ToLower() == "roundrectangle")
      OP = (ProfileOperation) new buMarbleCalc();
    if (Lines[0].Trim().ToLower() == "barrel")
      OP = (ProfileOperation) new buMarbleCalc();
    if (Lines[0].Trim().ToLower() == "ellipse")
      OP = (ProfileOperation) new buMarbleCalc();
    if (Lines[0].Trim().ToLower() == "hole")
      OP = (ProfileOperation) new buMarbleCalc();
    if (Lines[0].Trim().ToLower() == "notch")
      OP = (ProfileOperation) new buMarbleCalc();
    if (Lines[0].Trim().ToLower() == "freedraw")
      OP = (ProfileOperation) new buMarbleCalc();
    if (Lines[0].Trim().ToLower() == "text")
      OP = (ProfileOperation) new buMarbleCalc();
    if (Lines[0].Trim().ToLower() == "wiretext")
      OP = (ProfileOperation) new buMarbleCalc();
    if (Lines[0].Trim().ToLower() == "slot")
      OP = (ProfileOperation) new buMarbleCalc();
    if (Lines[0].Trim().ToLower() == "cut")
      OP = (ProfileOperation) new buMarbleCalc();
    if (Lines[0].Trim().ToLower() == "polygon")
      OP = (ProfileOperation) new buMarbleCalc();
    if (OP == null)
      return;
    List<string> CalcList1 = new List<string>();
    buStatics.ListToSpecificList("<ProfileOperationPars>", "</ProfileOperationPars>", false, Lines, ref CalcList1);
    if (CalcList1.Count > 0)
    {
      object ObjPar = (object) OP;
      buSerilization5.StringToClass(ref ObjPar, CalcList1[0]);
    }
    List<string> CalcList2 = new List<string>();
    buStatics.ListToSpecificList("<ProfileOperationDataPars>", "</ProfileOperationDataPars>", false, Lines, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      object operationData = (object) ((ProfileRuntimeSettings) OP).OperationData;
      buSerilization5.StringToClass(ref operationData, CalcList2[0]);
    }
    List<string> CalcList3 = new List<string>();
    buStatics.ListToSpecificList("<ProfileOperationCamDataPars>", "</ProfileOperationCamDataPars>", false, Lines, ref CalcList3);
    if (CalcList3.Count > 0)
    {
      object camOpData = (object) ((ProfileRuntimeSettings) OP).CamOPData;
      buSerilization5.StringToClass(ref camOpData, CalcList3[0]);
    }
    List<string> CalcList4 = new List<string>();
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Rectangle)
    {
      buStatics.ListToSpecificList("<ProfileOperationDataRectanglePars>", "</ProfileOperationDataRectanglePars>", false, Lines, ref CalcList4);
      if (CalcList4.Count > 0)
      {
        object rectangleData = (object) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).RectangleData;
        buSerilization5.StringToClass(ref rectangleData, CalcList4[0]);
      }
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Circle)
    {
      buStatics.ListToSpecificList("<ProfileOperationDataCirclePars>", "</ProfileOperationDataCirclePars>", false, Lines, ref CalcList4);
      if (CalcList4.Count > 0)
      {
        object circleData = (object) ((OperationInsideClampers) ((ProfileRuntimeSettings) OP).OperationData).CircleData;
        buSerilization5.StringToClass(ref circleData, CalcList4[0]);
      }
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.RoundRectangle)
    {
      buStatics.ListToSpecificList("<ProfileOperationDataRoundRectanglePars>", "</ProfileOperationDataRoundRectanglePars>", false, Lines, ref CalcList4);
      if (CalcList4.Count > 0)
      {
        object rectangleRoundData = (object) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).RectangleRoundData;
        buSerilization5.StringToClass(ref rectangleRoundData, CalcList4[0]);
      }
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Barrel)
    {
      buStatics.ListToSpecificList("<ProfileOperationDataBarelPars>", "</ProfileOperationDataBarelPars>", false, Lines, ref CalcList4);
      if (CalcList4.Count > 0)
      {
        object barelData = (object) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData;
        buSerilization5.StringToClass(ref barelData, CalcList4[0]);
      }
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Ellipse)
    {
      buStatics.ListToSpecificList("<ProfileOperationDataEllipsePars>", "</ProfileOperationDataEllipsePars>", false, Lines, ref CalcList4);
      if (CalcList4.Count > 0)
      {
        object ellipseData = (object) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).EllipseData;
        buSerilization5.StringToClass(ref ellipseData, CalcList4[0]);
      }
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Hole)
    {
      buStatics.ListToSpecificList("<ProfileOperationDataHolePars>", "</ProfileOperationDataHolePars>", false, Lines, ref CalcList4);
      if (CalcList4.Count > 0)
      {
        object holeData = (object) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).HoleData;
        buSerilization5.StringToClass(ref holeData, CalcList4[0]);
      }
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Slot)
    {
      buStatics.ListToSpecificList("<ProfileOperationDataSlotPars>", "</ProfileOperationDataSlotPars>", false, Lines, ref CalcList4);
      if (CalcList4.Count > 0)
      {
        object slotData = (object) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).SlotData;
        buSerilization5.StringToClass(ref slotData, CalcList4[0]);
      }
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Cut)
    {
      buStatics.ListToSpecificList("<ProfileOperationDataCutPars>", "</ProfileOperationDataCutPars>", false, Lines, ref CalcList4);
      if (CalcList4.Count > 0)
      {
        object cutData = (object) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).CutData;
        buSerilization5.StringToClass(ref cutData, CalcList4[0]);
      }
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.FreeDraw)
    {
      buStatics.ListToSpecificList("<ProfileOperationDataFreeDrawPars>", "</ProfileOperationDataFreeDrawPars>", false, Lines, ref CalcList4);
      if (CalcList4.Count > 0)
      {
        object freeDrawData = (object) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).FreeDrawData;
        buSerilization5.StringToClass(ref freeDrawData, CalcList4[0]);
      }
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Text)
    {
      buStatics.ListToSpecificList("<ProfileOperationDataTextPars>", "</ProfileOperationDataTextPars>", false, Lines, ref CalcList4);
      if (CalcList4.Count > 0)
      {
        object textData = (object) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).TextData;
        buSerilization5.StringToClass(ref textData, CalcList4[0]);
      }
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.WireText)
    {
      buStatics.ListToSpecificList("<ProfileOperationDataTextPars>", "</ProfileOperationDataTextPars>", false, Lines, ref CalcList4);
      if (CalcList4.Count > 0)
      {
        object textData = (object) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).TextData;
        buSerilization5.StringToClass(ref textData, CalcList4[0]);
      }
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Notch)
    {
      buStatics.ListToSpecificList("<ProfileOperationDataNotchPars>", "</ProfileOperationDataNotchPars>", false, Lines, ref CalcList4);
      if (CalcList4.Count > 0)
      {
        object notchData = (object) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData;
        buSerilization5.StringToClass(ref notchData, CalcList4[0]);
      }
    }
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Polygon)
    {
      buStatics.ListToSpecificList("<ProfileOperationDataPolygonPars>", "</ProfileOperationDataPolygonPars>", false, Lines, ref CalcList4);
      if (CalcList4.Count > 0)
      {
        object polygonData = (object) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).PolygonData;
        buSerilization5.StringToClass(ref polygonData, CalcList4[0]);
      }
    }
    List<List<string>> CalcList5 = new List<List<string>>();
    buStatics.ListToSpecificList("<DepthPositions>", "</DepthPositions>", true, Lines, ref CalcList5);
    for (int index = 0; index <= CalcList5.Count - 1; ++index)
    {
      DepthPositions depthPositions = (DepthPositions) new MarbleColorSettings();
      buSerilization5.Decode(CalcList5[index], "", (SerilizationMode5) 1, (object) depthPositions);
      ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).DepthValues.Add(depthPositions);
    }
  }

  public override string ToString()
  {
    string str1 = $" {((ProfileMirror) ((ProfileRuntimeSettings) this).OperationData).selectedPlaneName.ToString()} - P( {((ProfilePatternCopy) ((ProfileRuntimeSettings) this).OperationData).Position.X.ToString("f2")} , ";
    if (((ProfileMirror) ((ProfileRuntimeSettings) this).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) this).OperationData).selectedPlaneName == planeNames.Bottom | ((ProfileMirror) ((ProfileRuntimeSettings) this).OperationData).selectedPlaneName == planeNames.Free)
      str1 = $"{str1}{((ProfilePatternCopy) ((ProfileRuntimeSettings) this).OperationData).Position.Y.ToString("f2")} )";
    else if (((ProfileMirror) ((ProfileRuntimeSettings) this).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) this).OperationData).selectedPlaneName == planeNames.Back)
      str1 = $"{str1}{((ProfilePatternCopy) ((ProfileRuntimeSettings) this).OperationData).Position.Z.ToString("f2")} )";
    string str2 = $"{str1} - T{((ToolCamData5) ((ToolGeometry5) ((ProfileRuntimeSettings) this).Tool).Data).No.ToString()} Dia: {((ToolGeometry5) ((ProfileRuntimeSettings) this).Tool).Geometry.Diameter.ToString()}";
    string str3;
    if (this.GetType() == typeof (ProfileOperationCircle))
      str3 = $"{((ProfileRuntimeSettings) this).Name} - {MarbleJob.strCircle}D: {((CreateProfileFromDataOptions) ((OperationInsideClampers) ((ProfileRuntimeSettings) this).OperationData).CircleData).CircleDiameter.ToString("f3")}{str2}";
    else if (this.GetType() == typeof (ProfileOperationRectangle))
      str3 = $"{((ProfileRuntimeSettings) this).Name} - {MarbleJob.strRectangle}W: {((CreateProfileFromDataOptions) ((DepthPositions) ((ProfileRuntimeSettings) this).OperationData).RectangleData).RectangleWidth.ToString("f3")} - H: {((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) this).OperationData).RectangleData).RectangleHeight.ToString("f3")}{str2}";
    else if (this.GetType() == typeof (ProfileOperationRoundRectangle))
      str3 = $"{((ProfileRuntimeSettings) this).Name} - {MarbleItem.strRoundRect}W: {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) this).OperationData).RectangleRoundData).RoundRectangleWidth.ToString("f3")} - H: {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) this).OperationData).RectangleRoundData).RoundRectangleHeight.ToString("f3")} - R: {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) this).OperationData).RectangleRoundData).RoundRectangleRadius.ToString("f3")}{str2}";
    else if (this.GetType() == typeof (ProfileOperationSlot))
      str3 = $"{((ProfileRuntimeSettings) this).Name} - {MarbleItem.strSlot}W: {((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) this).OperationData).SlotData).SlotWidth.ToString("f3")} - D: {((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) this).OperationData).SlotData).SlotDiameter.ToString("f3")}{str2}";
    else if (this.GetType() == typeof (ProfileOperationBarrel))
      str3 = $"{((ProfileRuntimeSettings) this).Name} - W: {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) this).OperationData).BarelData).BarrelWidth.ToString("f3")} - D: {((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) this).OperationData).BarelData).BarrelDiameter.ToString("f3")}{str2}";
    else if (this.GetType() == typeof (ProfileOperationEllipse))
      str3 = $"{((ProfileRuntimeSettings) this).Name} - {MarbleJob.strEllipse}W: {((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) this).OperationData).EllipseData).EllipseWidth.ToString("f3")} - H: {((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) this).OperationData).EllipseData).EllipseHeight.ToString("f3")}{str2}";
    else if (this.GetType() == typeof (ProfileOperationHole))
    {
      string str4 = "";
      if (((ProfileRuntimeSettings) this).Tapping)
        str4 = "Tapping";
      str3 = $"{((ProfileRuntimeSettings) this).Name} - {MarbleJob.strHole}D: {((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) this).OperationData).HoleData).HoleDiameter.ToString("f3")}{str2} {str4}";
    }
    else if (this.GetType() == typeof (ProfileOperationNotch))
    {
      string str5 = $" - TNotch{((ToolCamData5) ((ToolGeometry5) ((ProfileRuntimeSettings) this).Tool).Data).No.ToString()} Dia: {((ToolGeometry5) ((ProfileRuntimeSettings) this).Tool).Geometry.Diameter.ToString()}";
      str3 = $"{((ProfileRuntimeSettings) this).Name} - {MarbleItem.strNotch}{((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) this).OperationData).NotchData).NotchWidth.ToString("f3")} - H: {((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) this).OperationData).NotchData).NotchHeight.ToString("f3")}{str5}";
    }
    else if (this.GetType() == typeof (ProfileOperationFreeDraw))
      str3 = ((ProfileRuntimeSettings) this).Name + MarbleItem.strFreeDraw + str2;
    else if (this.GetType() == typeof (ProfileOperationText))
      str3 = $"{((ProfileRuntimeSettings) this).Name} - {MarbleItem.strText}T: {((ProfileExistingClamperCompare) this).Text.ToString()} - H: {((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) this).OperationData).TextData).TextHeight.ToString("f3")}{str2}";
    else if (this.GetType() == typeof (ProfileOperationPolygon))
      str3 = $"{((ProfileRuntimeSettings) this).Name} - {MarbleItem.strPoylgon}Side: {((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) this).OperationData).PolygonData).PolygonSide.ToString()} - Dia: {((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) this).OperationData).PolygonData).PolygonDiameter.ToString("f3")}{str2}";
    else if (this.GetType() == typeof (ProfileOperationCut))
      str3 = $"{((ProfileRuntimeSettings) this).Name} - {MarbleItem.strCut}W: {((PanelDonePart) ((DepthPositions) ((ProfileRuntimeSettings) this).OperationData).CutData).CutWidth.ToString()} - H: {((PanelDonePart) ((DepthPositions) ((ProfileRuntimeSettings) this).OperationData).CutData).CutHeigth.ToString("f3")}{str2}";
    else
      str3 = ((ProfileRuntimeSettings) this).Name;
    return str3;
  }

  public abstract void m001DE0();

  public buMarbleCalc()
  {
    ((ProfileRuntimeSettings) this).Diameter = 10.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
  }

  public buMarbleCalc(ProfileOperationCircle data)
  {
    ((ProfileRuntimeSettings) this).Diameter = 10.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
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
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc(((ProfileRuntimeSettings) data).OperationData);
    ((ProfileRuntimeSettings) this).Depth = ((ProfileRuntimeSettings) data).Depth;
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) data).Tool);
    camTpPoint.CopyCam(((ProfileRuntimeSettings) data).CamCalculation, ref ((ProfileRuntimeSettings) this).CamCalculation);
  }

  public override string ToString()
  {
    return $"{MarbleJob.strCircle} X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) this).OperationData).Position.X.ToString("f2")} D: {((ProfileRuntimeSettings) this).Diameter.ToString("f3")}";
  }

  public abstract void m001DE4();

  public buMarbleCalc()
  {
    ((ProfileRuntimeSettings) this).Width = 10.0;
    ((ProfileRuntimeSettings) this).Height = 10.0;
    ((ProfileRuntimeSettings) this).Radius = 0.0;
    ((ProfileRuntimeSettings) this).Chamfer = 0.0;
    ((ProfileRuntimeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
  }

  public buMarbleCalc(ProfileOperationRectangle data)
  {
    ((ProfileRuntimeSettings) this).Width = 10.0;
    ((ProfileRuntimeSettings) this).Height = 10.0;
    ((ProfileRuntimeSettings) this).Radius = 0.0;
    ((ProfileRuntimeSettings) this).Chamfer = 0.0;
    ((ProfileRuntimeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
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
    ((ProfileRuntimeSettings) this).Depth = ((ProfileRuntimeSettings) data).Depth;
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc(((ProfileRuntimeSettings) data).OperationData);
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) data).Tool);
    camTpPoint.CopyCam(((ProfileRuntimeSettings) data).CamCalculation, ref ((ProfileRuntimeSettings) this).CamCalculation);
  }

  public buMarbleCalc()
  {
    ((ProfileRuntimeSettings) this).Width = 10.0;
    ((ProfileRuntimeSettings) this).Diameter = 10.0;
    ((ProfileRuntimeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
  }

  public buMarbleCalc(ProfileOperationSlot data)
  {
    ((ProfileRuntimeSettings) this).Width = 10.0;
    ((ProfileRuntimeSettings) this).Diameter = 10.0;
    ((ProfileRuntimeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
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
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc(((ProfileRuntimeSettings) data).OperationData);
    ((ProfileRuntimeSettings) this).Depth = ((ProfileRuntimeSettings) data).Depth;
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) data).Tool);
    camTpPoint.CopyCam(((ProfileRuntimeSettings) data).CamCalculation, ref ((ProfileRuntimeSettings) this).CamCalculation);
  }

  public override string ToString()
  {
    return $"{MarbleItem.strSlot} X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) this).OperationData).Position.X.ToString("f2")} W: {((ProfileRuntimeSettings) this).Width.ToString("f3")} - D: {((ProfileRuntimeSettings) this).Diameter.ToString("f3")}";
  }

  public abstract void m001DEA();

  public buMarbleCalc()
  {
    ((ProfileRuntimeSettings) this).CutWidth = 10.0;
    ((ProfileRuntimeSettings) this).CutHeight = 40.0;
    ((ProfileRuntimeSettings) this).CutDepth = 50.0;
    ((ProfileRuntimeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
  }

  public buMarbleCalc(ProfileOperationCut data)
  {
    ((ProfileRuntimeSettings) this).CutWidth = 10.0;
    ((ProfileRuntimeSettings) this).CutHeight = 40.0;
    ((ProfileRuntimeSettings) this).CutDepth = 50.0;
    ((ProfileRuntimeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
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
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc(((ProfileRuntimeSettings) data).OperationData);
    ((ProfileRuntimeSettings) this).Depth = ((ProfileRuntimeSettings) data).Depth;
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) data).Tool);
    camTpPoint.CopyCam(((ProfileRuntimeSettings) data).CamCalculation, ref ((ProfileRuntimeSettings) this).CamCalculation);
  }

  public override string ToString()
  {
    return $"{MarbleItem.strCut} X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) this).OperationData).Position.X.ToString("f2")} W: {((ProfileRuntimeSettings) this).CutWidth.ToString("f3")} - H: {((ProfileRuntimeSettings) this).CutHeight.ToString("f3")}";
  }

  public abstract void m001DEE();

  public buMarbleCalc()
  {
    ((ProfileRuntimeSettings) this).Width = 10.0;
    ((ProfileRuntimeSettings) this).Height = 10.0;
    ((ProfileRuntimeSettings) this).Radius = 2.0;
    ((ProfileRuntimeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
  }

  public buMarbleCalc(ProfileOperationRoundRectangle data)
  {
    ((ProfileRuntimeSettings) this).Width = 10.0;
    ((ProfileRuntimeSettings) this).Height = 10.0;
    ((ProfileRuntimeSettings) this).Radius = 2.0;
    ((ProfileRuntimeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
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
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc(((ProfileRuntimeSettings) data).OperationData);
    ((ProfileRuntimeSettings) this).Depth = ((ProfileRuntimeSettings) data).Depth;
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) data).Tool);
    camTpPoint.CopyCam(((ProfileRuntimeSettings) data).CamCalculation, ref ((ProfileRuntimeSettings) this).CamCalculation);
  }

  public override string ToString()
  {
    return $"{MarbleItem.strRoundRect} X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) this).OperationData).Position.X.ToString("f2")} W: {((ProfileRuntimeSettings) this).Width.ToString("f3")} - H: {((ProfileRuntimeSettings) this).Height.ToString("f3")} - R: {((ProfileRuntimeSettings) this).Radius.ToString("f3")}";
  }

  public abstract void m001DF2();

  public buMarbleCalc()
  {
    ((ProfileRuntimeSettings) this).Diameter = 20.0;
    ((ProfileRuntimeSettings) this).Length = 40.0;
    ((ProfileRuntimeSettings) this).Width = 10.0;
    ((ProfileRuntimeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
  }

  public buMarbleCalc(ProfileOperationBarrel data)
  {
    ((ProfileRuntimeSettings) this).Diameter = 20.0;
    ((ProfileRuntimeSettings) this).Length = 40.0;
    ((ProfileRuntimeSettings) this).Width = 10.0;
    ((ProfileRuntimeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
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
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc(((ProfileRuntimeSettings) data).OperationData);
    ((ProfileRuntimeSettings) this).Depth = ((ProfileRuntimeSettings) data).Depth;
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) data).Tool);
    camTpPoint.CopyCam(((ProfileRuntimeSettings) data).CamCalculation, ref ((ProfileRuntimeSettings) this).CamCalculation);
  }

  public override string ToString()
  {
    return $"{MarbleJob.strKeyHole} X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) this).OperationData).Position.X.ToString("f2")} W: {((ProfileRuntimeSettings) this).Width.ToString("f3")} - D: {((ProfileRuntimeSettings) this).Diameter.ToString("f3")}";
  }

  public abstract void m001DF6();

  public buMarbleCalc()
  {
    ((ProfileRuntimeSettings) this).Width = 10.0;
    ((ProfileRuntimeSettings) this).Height = 10.0;
    ((ProfileRuntimeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
  }

  public buMarbleCalc(ProfileOperationEllipse data)
  {
    ((ProfileRuntimeSettings) this).Width = 10.0;
    ((ProfileRuntimeSettings) this).Height = 10.0;
    ((ProfileRuntimeSettings) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
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
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc(((ProfileRuntimeSettings) data).OperationData);
    ((ProfileRuntimeSettings) this).Depth = ((ProfileRuntimeSettings) data).Depth;
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) data).Tool);
    camTpPoint.CopyCam(((ProfileRuntimeSettings) data).CamCalculation, ref ((ProfileRuntimeSettings) this).CamCalculation);
  }

  public override string ToString()
  {
    return $"{MarbleJob.strEllipse} X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) this).OperationData).Position.X.ToString("f2")} W: {((ProfileRuntimeSettings) this).Width.ToString("f3")} - H: {((ProfileRuntimeSettings) this).Height.ToString("f3")}";
  }

  public abstract void m001DFA();

  public buMarbleCalc()
  {
    ((ProfileRuntimeSettings) this).Diameter = 10.0;
    ((ProfileRuntimeSettings) this).DiameterTapping = 11.0;
    ((ProfileRuntimeSettings) this).DepthTapping = 5.0;
    ((ProfileRuntimeSettings) this).TappingPitch = 5.0;
    ((ProfileRuntimeSettings) this).TappingAdditional = 1.0;
    ((ProfileRuntimeSettings) this).Tapping = false;
    // ISSUE: explicit constructor call
    this.\u002Ector();
  }

  public buMarbleCalc(ProfileOperationHole data)
  {
    ((ProfileRuntimeSettings) this).Diameter = 10.0;
    ((ProfileRuntimeSettings) this).DiameterTapping = 11.0;
    ((ProfileRuntimeSettings) this).DepthTapping = 5.0;
    ((ProfileRuntimeSettings) this).TappingPitch = 5.0;
    ((ProfileRuntimeSettings) this).TappingAdditional = 1.0;
    ((ProfileRuntimeSettings) this).Tapping = false;
    // ISSUE: explicit constructor call
    this.\u002Ector();
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
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc(((ProfileRuntimeSettings) data).OperationData);
    ((ProfileRuntimeSettings) this).Depth = ((ProfileRuntimeSettings) data).Depth;
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) data).Tool);
    camTpPoint.CopyCam(((ProfileRuntimeSettings) data).CamCalculation, ref ((ProfileRuntimeSettings) this).CamCalculation);
  }

  public override string ToString()
  {
    string str = "";
    if (((ProfileRuntimeSettings) this).Tapping)
      str = $" Tapping Pitch:{((ProfileRuntimeSettings) this).TappingPitch.ToString("f2")} - Dia: {((ProfileRuntimeSettings) this).DiameterTapping.ToString("f2")} Depth: {((ProfileRuntimeSettings) this).DepthTapping.ToString("f2")}";
    return $"{MarbleJob.strHole} X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) this).OperationData).Position.X.ToString("f2")} D: {((ProfileRuntimeSettings) this).Diameter.ToString("f3")}{str}";
  }

  public abstract void m001DFE();

  public buMarbleCalc()
  {
    ((ProfileRuntimeSettings) this).Width = 10.0;
    ((ProfileRuntimeSettings) this).Height = 10.0;
    ((ProfileRuntimeSettings) this).Start = 10.0;
    ((ProfileRuntimeSettings) this).Angle = 0.0;
    ((ProfileRuntimeSettings) this).UpDown = UpDownLocationType.Up;
    ((ProfileRuntimeSettings) this).NotchLocation = ProfileNotchLocationType.Left;
    ((ProfileRuntimeSettings) this).OPType = ProfileNotchOperationType.Side;
    // ISSUE: explicit constructor call
    this.\u002Ector();
  }

  public buMarbleCalc(ProfileOperationNotch data)
  {
    ((ProfileRuntimeSettings) this).Width = 10.0;
    ((ProfileRuntimeSettings) this).Height = 10.0;
    ((ProfileRuntimeSettings) this).Start = 10.0;
    ((ProfileRuntimeSettings) this).Angle = 0.0;
    ((ProfileRuntimeSettings) this).UpDown = UpDownLocationType.Up;
    ((ProfileRuntimeSettings) this).NotchLocation = ProfileNotchLocationType.Left;
    ((ProfileRuntimeSettings) this).OPType = ProfileNotchOperationType.Side;
    // ISSUE: explicit constructor call
    this.\u002Ector();
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
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc(((ProfileRuntimeSettings) data).OperationData);
    ((ProfileRuntimeSettings) this).Depth = ((ProfileRuntimeSettings) data).Depth;
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) data).Tool);
    ((ProfileRuntimeSettings) this).ToolNotch = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) data).ToolNotch);
    camTpPoint.CopyCam(((ProfileRuntimeSettings) data).CamCalculation, ref ((ProfileRuntimeSettings) this).CamCalculation);
  }

  public override string ToString()
  {
    return $"{MarbleItem.strNotch} {((ProfileRuntimeSettings) this).OPType.ToString()} W: {((ProfileRuntimeSettings) this).Width.ToString("f3")} - H: {((ProfileRuntimeSettings) this).Height.ToString("f3")}";
  }

  public abstract void m001E02();

  public buMarbleCalc()
  {
    ((ProfileRuntimeSettings) this).Width = 10.0;
    ((ProfileRuntimeSettings) this).Height = 10.0;
    ((ProfileRuntimeSettings) this).Start = 10.0;
    ((ProfileRuntimeSettings) this).ToolCutPersentage = 90.0;
    ((ProfileRuntimeSettings) this).Type = ProfileNotchType.LType;
    ((ClamperLeftRightPars) this).UpDown = UpDownLocationType.Up;
    ((ClamperLeftRightPars) this).LeftRight = LeftRightLocationType.Left;
    // ISSUE: explicit constructor call
    this.\u002Ector();
  }

  public buMarbleCalc(ProfileOperationNotchOld data)
  {
    ((ProfileRuntimeSettings) this).Width = 10.0;
    ((ProfileRuntimeSettings) this).Height = 10.0;
    ((ProfileRuntimeSettings) this).Start = 10.0;
    ((ProfileRuntimeSettings) this).ToolCutPersentage = 90.0;
    ((ProfileRuntimeSettings) this).Type = ProfileNotchType.LType;
    ((ClamperLeftRightPars) this).UpDown = UpDownLocationType.Up;
    ((ClamperLeftRightPars) this).LeftRight = LeftRightLocationType.Left;
    // ISSUE: explicit constructor call
    this.\u002Ector();
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
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc(((ProfileRuntimeSettings) data).OperationData);
    ((ProfileRuntimeSettings) this).Depth = ((ProfileRuntimeSettings) data).Depth;
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) data).Tool);
    camTpPoint.CopyCam(((ProfileRuntimeSettings) data).CamCalculation, ref ((ProfileRuntimeSettings) this).CamCalculation);
  }

  public override string ToString()
  {
    return $"{MarbleItem.strNotch} W: {((ProfileRuntimeSettings) this).Width.ToString("f3")} - H: {((ProfileRuntimeSettings) this).Height.ToString("f3")}";
  }

  public abstract void m001E06();

  public buMarbleCalc()
  {
    ((ClamperLeftRightPars) this).Width = 10.0;
    ((ClamperLeftRightPars) this).Height = 10.0;
    ((ClamperLeftRightPars) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
  }

  public buMarbleCalc(ProfileOperationFreeDraw data)
  {
    ((ClamperLeftRightPars) this).Width = 10.0;
    ((ClamperLeftRightPars) this).Height = 10.0;
    ((ClamperLeftRightPars) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
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
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc(((ProfileRuntimeSettings) data).OperationData);
    ((ProfileRuntimeSettings) this).Depth = ((ProfileRuntimeSettings) data).Depth;
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) data).Tool);
    camTpPoint.CopyCam(((ProfileRuntimeSettings) data).CamCalculation, ref ((ProfileRuntimeSettings) this).CamCalculation);
  }

  public override string ToString()
  {
    return $"{MarbleItem.strFreeDraw} X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) this).OperationData).Position.X.ToString("f2")} - H: {((ClamperLeftRightPars) this).Height.ToString("f3")}";
  }

  public abstract void m001E0A();

  public buMarbleCalc()
  {
    ((ClamperLeftRightPars) this).Width = 10.0;
    ((ClamperLeftRightPars) this).Height = 10.0;
    ((ProfileExistingClamperCompare) this).Angle = 0.0;
    ((ProfileExistingClamperCompare) this).Text = "";
    ((ProfileExistingClamperCompare) this).isWire = false;
    ((ProfileExistingClamperCompare) this).TextFont = new Font("Arial", 12f);
    // ISSUE: explicit constructor call
    this.\u002Ector();
  }

  public buMarbleCalc(ProfileOperationText data)
  {
    ((ClamperLeftRightPars) this).Width = 10.0;
    ((ClamperLeftRightPars) this).Height = 10.0;
    ((ProfileExistingClamperCompare) this).Angle = 0.0;
    ((ProfileExistingClamperCompare) this).Text = "";
    ((ProfileExistingClamperCompare) this).isWire = false;
    ((ProfileExistingClamperCompare) this).TextFont = new Font("Arial", 12f);
    // ISSUE: explicit constructor call
    this.\u002Ector();
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
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc(((ProfileRuntimeSettings) data).OperationData);
    ((ProfileRuntimeSettings) this).Depth = ((ProfileRuntimeSettings) data).Depth;
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) data).Tool);
    camTpPoint.CopyCam(((ProfileRuntimeSettings) data).CamCalculation, ref ((ProfileRuntimeSettings) this).CamCalculation);
  }

  public override string ToString()
  {
    return $"{MarbleItem.strText} X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) this).OperationData).Position.X.ToString("f2")} T: {((ProfileExistingClamperCompare) this).Text.ToString()} - H: {((ClamperLeftRightPars) this).Height.ToString("f3")}";
  }

  public abstract void m001E0E();

  public buMarbleCalc()
  {
    ((OperationInsideClampers) this).Side = 6;
    ((OperationInsideClampers) this).Diameter = 10.0;
    ((OperationInsideClampers) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
  }

  public buMarbleCalc(ProfileOperationPolygon data)
  {
    ((OperationInsideClampers) this).Side = 6;
    ((OperationInsideClampers) this).Diameter = 10.0;
    ((OperationInsideClampers) this).Angle = 0.0;
    // ISSUE: explicit constructor call
    this.\u002Ector();
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
    ((ProfileRuntimeSettings) this).OperationData = (ProfileOperationData) new buMarbleCalc(((ProfileRuntimeSettings) data).OperationData);
    ((OperationInsideClampers) this).Side = ((OperationInsideClampers) data).Side;
    ((OperationInsideClampers) this).Diameter = ((OperationInsideClampers) data).Diameter;
    ((OperationInsideClampers) this).Angle = ((OperationInsideClampers) data).Angle;
    ((ProfileRuntimeSettings) this).Tool = (ToolBase5) new ToolGeometry5(((ProfileRuntimeSettings) data).Tool);
    camTpPoint.CopyCam(((ProfileRuntimeSettings) data).CamCalculation, ref ((ProfileRuntimeSettings) this).CamCalculation);
  }

  public override string ToString()
  {
    return $"{MarbleItem.strPoylgon} X: {((ProfilePatternCopy) ((ProfileRuntimeSettings) this).OperationData).Position.X.ToString("f2")} S: {((OperationInsideClampers) this).Side.ToString("f3")} - D: {((OperationInsideClampers) this).Diameter.ToString("f3")}";
  }

  public abstract void m001E12();

  public buMarbleCalc()
  {
    ((OperationInsideClampers) this).CircleData = (ProfileOperationDataCircle) new buMarbleCalc();
    ((DepthPositions) this).RectangleData = (ProfileOperationDataRectangle) new buMarbleCalc();
    ((DepthPositions) this).RectangleRoundData = (ProfileOperationDataRectangleRound) new buMarbleCalc();
    ((DepthPositions) this).CutData = (ProfileOperationDataCut) new buMarbleCalc();
    ((DepthPositions) this).SlotData = (ProfileOperationDataSlot) new buMarbleCalc();
    ((DepthPositions) this).EllipseData = (ProfileOperationDataEllipse) new buMarbleCalc();
    ((DepthPositions) this).NotchData = (ProfileOperationDataNotch) new buMarbleCalc();
    ((DepthPositions) this).HoleData = (ProfileOperationDataHole) new buMarbleCalc();
    ((DepthPositions) this).BarelData = (ProfileOperationDataBarel) new buMarbleCalc();
    // ISSUE: object of a compiler-generated type is created
    ((DepthPositionOptions) this).FreeDrawData = (ProfileOperationDataFreeDraw) new buMarbleCalc.\u0001();
    ((DepthPositionOptions) this).TextData = (ProfileOperationDataText) new MarbleItem();
    ((DepthPositionOptions) this).PolygonData = (ProfileOperationDataPolygon) new buMarbleCalc();
    ((DepthPositionOptions) this).Array = (ShapeArray) new ColorDrawType();
    ((DepthPositionOptions) this).Mirror = (ShapeMirror) new GCodeConverter();
    ((ProfileArray) this).CamParMilling = new camParameters5();
    ((ProfileArray) this).CamParNotch = new camParameters5();
    ((ProfileArray) this).ExternalDepth = 0.0;
    ((ProfileArray) this).ExtraDepth = 0.0;
    ((ProfileArray) this).IncrementalDistance = 100.0;
    ((ProfileArray) this).ManuelZVal = 0.0;
    ((ProfileArray) this).SelectedPlaneLength = 0.0;
    ((ProfileArray) this).ExtraDepthEnable = false;
    ((ProfileMirror) this).EachLayer = false;
    ((ProfileMirror) this).ManuelZEnable = false;
    ((ProfileMirror) this).XRefFromProfileEnd = false;
    ((ProfileMirror) this).selectedPlaneName = planeNames.Top;
    ((ProfileMirror) this).selectedPlaneInfo = (SelectedPlaneInfo) new hmiUISettings();
    ((ProfilePatternCopy) this).selectedPlane = new Plane();
    ((ProfilePatternCopy) this).movePlanePoint = new Point3D();
    ((ProfilePatternCopy) this).Position = new Point3D();
    ((ProfileOnlineOpOptions) this).basePosition = new Point3D();
    ((ProfileOnlineOpOptions) this).cornerPosition = new Point3D();
    ((ProfileOnlineOpOptions) this).ToolName = "";
    ((ToolCheckOption) this).ToolNotchName = "";
    ((ToolCheckOption) this).ToolAuxName = "";
    ((CreateProfileFromDataOptions) this).Action = actionTypeBU.None;
    ((CreateProfileFromDataOptions) this).OperationType = ProfileOperationTypes.Circle;
    ((CreateProfileFromDataOptions) this).Corner = CornerLocation.RightTop;
    ((CreateProfileFromDataOptions) this).Alignment = ObjectAlignment.MiddleCenter;
    ((CreateProfileFromDataOptions) this).Depth = (DepthPositions) new MarbleColorSettings();
    ((CreateProfileFromDataOptions) this).DepthValues = new List<DepthPositions>();
    ((CreateProfileFromDataOptions) this).DepthForced = false;
    ((CreateProfileFromDataOptions) this).ToolDiameter = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buMarbleCalc(ProfileOperationData data)
  {
    ((OperationInsideClampers) this).CircleData = (ProfileOperationDataCircle) new buMarbleCalc();
    ((DepthPositions) this).RectangleData = (ProfileOperationDataRectangle) new buMarbleCalc();
    ((DepthPositions) this).RectangleRoundData = (ProfileOperationDataRectangleRound) new buMarbleCalc();
    ((DepthPositions) this).CutData = (ProfileOperationDataCut) new buMarbleCalc();
    ((DepthPositions) this).SlotData = (ProfileOperationDataSlot) new buMarbleCalc();
    ((DepthPositions) this).EllipseData = (ProfileOperationDataEllipse) new buMarbleCalc();
    ((DepthPositions) this).NotchData = (ProfileOperationDataNotch) new buMarbleCalc();
    ((DepthPositions) this).HoleData = (ProfileOperationDataHole) new buMarbleCalc();
    ((DepthPositions) this).BarelData = (ProfileOperationDataBarel) new buMarbleCalc();
    // ISSUE: object of a compiler-generated type is created
    ((DepthPositionOptions) this).FreeDrawData = (ProfileOperationDataFreeDraw) new buMarbleCalc.\u0001();
    ((DepthPositionOptions) this).TextData = (ProfileOperationDataText) new MarbleItem();
    ((DepthPositionOptions) this).PolygonData = (ProfileOperationDataPolygon) new buMarbleCalc();
    ((DepthPositionOptions) this).Array = (ShapeArray) new ColorDrawType();
    ((DepthPositionOptions) this).Mirror = (ShapeMirror) new GCodeConverter();
    ((ProfileArray) this).CamParMilling = new camParameters5();
    ((ProfileArray) this).CamParNotch = new camParameters5();
    ((ProfileArray) this).ExternalDepth = 0.0;
    ((ProfileArray) this).ExtraDepth = 0.0;
    ((ProfileArray) this).IncrementalDistance = 100.0;
    ((ProfileArray) this).ManuelZVal = 0.0;
    ((ProfileArray) this).SelectedPlaneLength = 0.0;
    ((ProfileArray) this).ExtraDepthEnable = false;
    ((ProfileMirror) this).EachLayer = false;
    ((ProfileMirror) this).ManuelZEnable = false;
    ((ProfileMirror) this).XRefFromProfileEnd = false;
    ((ProfileMirror) this).selectedPlaneName = planeNames.Top;
    ((ProfileMirror) this).selectedPlaneInfo = (SelectedPlaneInfo) new hmiUISettings();
    ((ProfilePatternCopy) this).selectedPlane = new Plane();
    ((ProfilePatternCopy) this).movePlanePoint = new Point3D();
    ((ProfilePatternCopy) this).Position = new Point3D();
    ((ProfileOnlineOpOptions) this).basePosition = new Point3D();
    ((ProfileOnlineOpOptions) this).cornerPosition = new Point3D();
    ((ProfileOnlineOpOptions) this).ToolName = "";
    ((ToolCheckOption) this).ToolNotchName = "";
    ((ToolCheckOption) this).ToolAuxName = "";
    ((CreateProfileFromDataOptions) this).Action = actionTypeBU.None;
    ((CreateProfileFromDataOptions) this).OperationType = ProfileOperationTypes.Circle;
    ((CreateProfileFromDataOptions) this).Corner = CornerLocation.RightTop;
    ((CreateProfileFromDataOptions) this).Alignment = ObjectAlignment.MiddleCenter;
    ((CreateProfileFromDataOptions) this).Depth = (DepthPositions) new MarbleColorSettings();
    ((CreateProfileFromDataOptions) this).DepthValues = new List<DepthPositions>();
    ((CreateProfileFromDataOptions) this).DepthForced = false;
    ((CreateProfileFromDataOptions) this).ToolDiameter = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
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
    ((ProfileMirror) this).selectedPlaneInfo = (SelectedPlaneInfo) new hmiUISettings(((ProfileMirror) data).selectedPlaneInfo);
    ((ProfileArray) this).CamParMilling = (camParameters5) new camRuntime5(((ProfileArray) data).CamParMilling);
    ((ProfileArray) this).CamParNotch = (camParameters5) new camRuntime5(((ProfileArray) data).CamParNotch);
    ((ProfilePatternCopy) this).selectedPlane = (Plane) ((ProfilePatternCopy) data).selectedPlane.Clone();
    ((ProfilePatternCopy) this).Position = F_NotchEdit.ToPoint3D(((ProfilePatternCopy) data).Position);
    ((ProfileOnlineOpOptions) this).basePosition = F_NotchEdit.ToPoint3D(((ProfileOnlineOpOptions) data).basePosition);
    ((ProfilePatternCopy) this).movePlanePoint = F_NotchEdit.ToPoint3D(((ProfilePatternCopy) data).movePlanePoint);
    ((CreateProfileFromDataOptions) this).DepthValues.Clear();
    for (int index = 0; index <= ((CreateProfileFromDataOptions) data).DepthValues.Count - 1; ++index)
      ((CreateProfileFromDataOptions) this).DepthValues.Add((DepthPositions) new MarbleColorSettings(((CreateProfileFromDataOptions) data).DepthValues[index]));
    ((DepthPositionOptions) this).Array = (ShapeArray) new GCodeConverter(((DepthPositionOptions) data).Array);
    ((CreateProfileFromDataOptions) this).Depth = (DepthPositions) new MarbleColorSettings(((CreateProfileFromDataOptions) data).Depth);
    ((DepthPositionOptions) this).Mirror = (ShapeMirror) new GCodePoint5(((DepthPositionOptions) data).Mirror);
    ((OperationInsideClampers) this).CircleData = (ProfileOperationDataCircle) new buMarbleCalc(((OperationInsideClampers) data).CircleData);
    ((DepthPositions) this).RectangleData = (ProfileOperationDataRectangle) new buMarbleCalc(((DepthPositions) data).RectangleData);
    ((DepthPositions) this).RectangleRoundData = (ProfileOperationDataRectangleRound) new buMarbleCalc(((DepthPositions) data).RectangleRoundData);
    ((DepthPositions) this).SlotData = (ProfileOperationDataSlot) new buMarbleCalc(((DepthPositions) data).SlotData);
    ((DepthPositions) this).EllipseData = (ProfileOperationDataEllipse) new buMarbleCalc(((DepthPositions) data).EllipseData);
    ((DepthPositions) this).NotchData = (ProfileOperationDataNotch) new buMarbleCalc(((DepthPositions) data).NotchData);
    ((DepthPositions) this).HoleData = (ProfileOperationDataHole) new buMarbleCalc(((DepthPositions) data).HoleData);
    ((DepthPositions) this).BarelData = (ProfileOperationDataBarel) new buMarbleCalc(((DepthPositions) data).BarelData);
    ((DepthPositionOptions) this).FreeDrawData = (ProfileOperationDataFreeDraw) new MarbleJob(((DepthPositionOptions) data).FreeDrawData);
    ((DepthPositionOptions) this).TextData = (ProfileOperationDataText) new MarbleItem(((DepthPositionOptions) data).TextData);
    ((DepthPositions) this).CutData = (ProfileOperationDataCut) new buMarbleCalc(((DepthPositions) data).CutData);
    ((DepthPositionOptions) this).PolygonData = (ProfileOperationDataPolygon) new buMarbleCalc(((DepthPositionOptions) data).PolygonData);
  }

  public void MmToInch()
  {
    ((CreateProfileFromDataOptions) ((OperationInsideClampers) this).CircleData).CircleDiameter = Math.Round(((CreateProfileFromDataOptions) ((OperationInsideClampers) this).CircleData).CircleDiameter * buSystem.MmToInchRatio, 5);
    ((CreateProfileFromDataOptions) ((OperationInsideClampers) this).CircleData).CircleThickness = Math.Round(((CreateProfileFromDataOptions) ((OperationInsideClampers) this).CircleData).CircleDiameter * buSystem.MmToInchRatio, 5);
    ((OperationUpdateArg) ((DepthPositions) this).RectangleData).RectangleChamfer = Math.Round(((OperationUpdateArg) ((DepthPositions) this).RectangleData).RectangleChamfer * buSystem.MmToInchRatio, 5);
    ((OperationUpdateArg) ((DepthPositions) this).RectangleData).RectangleHeight = Math.Round(((OperationUpdateArg) ((DepthPositions) this).RectangleData).RectangleHeight * buSystem.MmToInchRatio, 5);
    ((OperationUpdateArg) ((DepthPositions) this).RectangleData).RectangleRadius = Math.Round(((OperationUpdateArg) ((DepthPositions) this).RectangleData).RectangleRadius * buSystem.MmToInchRatio, 5);
    ((profileSortSequenceAtSamePosition) ((DepthPositions) this).RectangleData).RectangleThickness = Math.Round(((profileSortSequenceAtSamePosition) ((DepthPositions) this).RectangleData).RectangleThickness * buSystem.MmToInchRatio, 5);
    ((CreateProfileFromDataOptions) ((DepthPositions) this).RectangleData).RectangleWidth = Math.Round(((CreateProfileFromDataOptions) ((DepthPositions) this).RectangleData).RectangleWidth * buSystem.MmToInchRatio, 5);
    ((PanelCutMove) ((DepthPositions) this).RectangleRoundData).RoundRectangleHeight = Math.Round(((PanelCutMove) ((DepthPositions) this).RectangleRoundData).RoundRectangleHeight * buSystem.MmToInchRatio, 5);
    ((PanelCutMove) ((DepthPositions) this).RectangleRoundData).RoundRectangleRadius = Math.Round(((PanelCutMove) ((DepthPositions) this).RectangleRoundData).RoundRectangleRadius * buSystem.MmToInchRatio, 5);
    ((PanelCutMove) ((DepthPositions) this).RectangleRoundData).RoundRectangleThickness = Math.Round(((PanelCutMove) ((DepthPositions) this).RectangleRoundData).RoundRectangleThickness * buSystem.MmToInchRatio, 5);
    ((PanelCutMove) ((DepthPositions) this).RectangleRoundData).RoundRectangleWidth = Math.Round(((PanelCutMove) ((DepthPositions) this).RectangleRoundData).RoundRectangleWidth * buSystem.MmToInchRatio, 5);
    ((PanelDonePart) ((DepthPositions) this).CutData).CutDepth = Math.Round(((PanelDonePart) ((DepthPositions) this).CutData).CutDepth * buSystem.MmToInchRatio, 5);
    ((PanelDonePart) ((DepthPositions) this).CutData).CutHeigth = Math.Round(((PanelDonePart) ((DepthPositions) this).CutData).CutHeigth * buSystem.MmToInchRatio, 5);
    ((PanelWaitAssembly) ((DepthPositions) this).CutData).CutThickness = Math.Round(((PanelWaitAssembly) ((DepthPositions) this).CutData).CutThickness * buSystem.MmToInchRatio, 5);
    ((PanelDonePart) ((DepthPositions) this).CutData).CutWidth = Math.Round(((PanelDonePart) ((DepthPositions) this).CutData).CutWidth * buSystem.MmToInchRatio, 5);
    ((PanelEntityData) ((DepthPositions) this).SlotData).SlotDiameter = Math.Round(((PanelEntityData) ((DepthPositions) this).SlotData).SlotDiameter * buSystem.MmToInchRatio, 5);
    ((PanelEntityData) ((DepthPositions) this).SlotData).SlotThickness = Math.Round(((PanelEntityData) ((DepthPositions) this).SlotData).SlotThickness * buSystem.MmToInchRatio, 5);
    ((PanelEntityData) ((DepthPositions) this).SlotData).SlotWidth = Math.Round(((PanelEntityData) ((DepthPositions) this).SlotData).SlotWidth * buSystem.MmToInchRatio, 5);
    ((NestingPanelJob) ((DepthPositions) this).EllipseData).EllipseHeight = Math.Round(((NestingPanelJob) ((DepthPositions) this).EllipseData).EllipseHeight * buSystem.MmToInchRatio, 5);
    ((NestingPanelJob) ((DepthPositions) this).EllipseData).EllipseThickness = Math.Round(((NestingPanelJob) ((DepthPositions) this).EllipseData).EllipseThickness * buSystem.MmToInchRatio, 5);
    ((NestingPanelJob) ((DepthPositions) this).EllipseData).EllipseWidth = Math.Round(((NestingPanelJob) ((DepthPositions) this).EllipseData).EllipseWidth * buSystem.MmToInchRatio, 5);
    ((NestingPanelJob) ((DepthPositions) this).NotchData).NotchDepth = Math.Round(((NestingPanelJob) ((DepthPositions) this).NotchData).NotchDepth * buSystem.MmToInchRatio, 5);
    ((NestingPanelJob) ((DepthPositions) this).NotchData).NotchHeight = Math.Round(((NestingPanelJob) ((DepthPositions) this).NotchData).NotchHeight * buSystem.MmToInchRatio, 5);
    ((NestingPanel) ((DepthPositions) this).NotchData).NotchStart = Math.Round(((NestingPanel) ((DepthPositions) this).NotchData).NotchStart * buSystem.MmToInchRatio, 5);
    ((NestingPanel) ((DepthPositions) this).NotchData).NotchThickness = Math.Round(((NestingPanel) ((DepthPositions) this).NotchData).NotchThickness * buSystem.MmToInchRatio, 5);
    ((NestingPanelJob) ((DepthPositions) this).NotchData).NotchWidth = Math.Round(((NestingPanelJob) ((DepthPositions) this).NotchData).NotchWidth * buSystem.MmToInchRatio, 5);
    ((NestingPanel) ((DepthPositions) this).HoleData).HoleDepth = Math.Round(((NestingPanel) ((DepthPositions) this).HoleData).HoleDepth * buSystem.MmToInchRatio, 5);
    ((NestingPanel) ((DepthPositions) this).HoleData).HoleDiameter = Math.Round(((NestingPanel) ((DepthPositions) this).HoleData).HoleDiameter * buSystem.MmToInchRatio, 5);
    ((NestingPanel) ((DepthPositions) this).HoleData).HoleThickness = Math.Round(((NestingPanel) ((DepthPositions) this).HoleData).HoleThickness * buSystem.MmToInchRatio, 5);
    ((PanelCutMove) ((DepthPositions) this).BarelData).BarrelDiameter = Math.Round(((PanelCutMove) ((DepthPositions) this).BarelData).BarrelDiameter * buSystem.MmToInchRatio, 5);
    ((PanelCutMove) ((DepthPositions) this).BarelData).BarrelLength = Math.Round(((PanelCutMove) ((DepthPositions) this).BarelData).BarrelLength * buSystem.MmToInchRatio, 5);
    ((PanelCutMove) ((DepthPositions) this).BarelData).BarrelThickness = Math.Round(((PanelCutMove) ((DepthPositions) this).BarelData).BarrelThickness * buSystem.MmToInchRatio, 5);
    ((PanelCutMove) ((DepthPositions) this).BarelData).BarrelWidth = Math.Round(((PanelCutMove) ((DepthPositions) this).BarelData).BarrelWidth * buSystem.MmToInchRatio, 5);
    ((NestingPanelNode) ((DepthPositionOptions) this).FreeDrawData).FreeDrawHeight = Math.Round(((NestingPanelNode) ((DepthPositionOptions) this).FreeDrawData).FreeDrawHeight * buSystem.MmToInchRatio, 5);
    ((NestingPanelNode) ((DepthPositionOptions) this).FreeDrawData).FreeDrawThickness = Math.Round(((NestingPanelNode) ((DepthPositionOptions) this).FreeDrawData).FreeDrawThickness * buSystem.MmToInchRatio, 5);
    ((NestingPanelNode) ((DepthPositionOptions) this).FreeDrawData).FreeDrawWidth = Math.Round(((NestingPanelNode) ((DepthPositionOptions) this).FreeDrawData).FreeDrawThickness * buSystem.MmToInchRatio, 5);
    ((NestingPanelNode) ((DepthPositionOptions) this).TextData).CharSpace = Math.Round(((NestingPanelNode) ((DepthPositionOptions) this).TextData).CharSpace * buSystem.MmToInchRatio, 5);
    ((NestingPanelNode) ((DepthPositionOptions) this).TextData).SpaceValue = Math.Round(((NestingPanelNode) ((DepthPositionOptions) this).TextData).SpaceValue * buSystem.MmToInchRatio, 5);
    ((NestingPanelNode) ((DepthPositionOptions) this).TextData).TextHeight = Math.Round(((NestingPanelNode) ((DepthPositionOptions) this).TextData).TextHeight * buSystem.MmToInchRatio, 5);
    ((PanelCutSettings) ((DepthPositionOptions) this).TextData).TextThickness = Math.Round(((PanelCutSettings) ((DepthPositionOptions) this).TextData).TextThickness * buSystem.MmToInchRatio, 5);
    ((NestingPanelNode) ((DepthPositionOptions) this).TextData).TextWidth = Math.Round(((NestingPanelNode) ((DepthPositionOptions) this).TextData).TextWidth * buSystem.MmToInchRatio, 5);
    ((CreateProfileFromDataOptions) ((DepthPositionOptions) this).PolygonData).PolygonDiameter = Math.Round(((CreateProfileFromDataOptions) ((DepthPositionOptions) this).PolygonData).PolygonDiameter * buSystem.MmToInchRatio, 5);
    ((CreateProfileFromDataOptions) ((DepthPositionOptions) this).PolygonData).PolygonThickness = Math.Round(((CreateProfileFromDataOptions) ((DepthPositionOptions) this).PolygonData).PolygonThickness * buSystem.MmToInchRatio, 5);
    ((ShapeRuntimeData) ((DepthPositionOptions) this).Array).LineerXDistance = Math.Round(((ShapeRuntimeData) ((DepthPositionOptions) this).Array).LineerXDistance * buSystem.MmToInchRatio, 5);
    ((ShapeRuntimeData) ((DepthPositionOptions) this).Array).LineerYDistance = Math.Round(((ShapeRuntimeData) ((DepthPositionOptions) this).Array).LineerXDistance * buSystem.MmToInchRatio, 5);
    ((ShapeRuntimeData) ((DepthPositionOptions) this).Mirror).MirrorDistance = Math.Round(((ShapeRuntimeData) ((DepthPositionOptions) this).Mirror).MirrorDistance * buSystem.MmToInchRatio, 5);
    ((ProfileArray) this).ExternalDepth = Math.Round(((ProfileArray) this).ExternalDepth * buSystem.MmToInchRatio, 5);
    ((ProfileArray) this).ExtraDepth = Math.Round(((ProfileArray) this).ExtraDepth * buSystem.MmToInchRatio, 5);
    ((ProfileArray) this).IncrementalDistance = Math.Round(((ProfileArray) this).IncrementalDistance * buSystem.MmToInchRatio, 5);
    ((ProfileArray) this).ManuelZVal = Math.Round(((ProfileArray) this).ManuelZVal * buSystem.MmToInchRatio, 5);
    ((ProfileArray) this).SelectedPlaneLength = Math.Round(((ProfileArray) this).SelectedPlaneLength * buSystem.MmToInchRatio, 5);
    ((ProfilePatternCopy) this).movePlanePoint.X = Math.Round(((ProfilePatternCopy) this).movePlanePoint.X * buSystem.MmToInchRatio, 5);
    ((ProfilePatternCopy) this).movePlanePoint.Y = Math.Round(((ProfilePatternCopy) this).movePlanePoint.Y * buSystem.MmToInchRatio, 5);
    ((ProfilePatternCopy) this).movePlanePoint.Z = Math.Round(((ProfilePatternCopy) this).movePlanePoint.Z * buSystem.MmToInchRatio, 5);
    ((ProfilePatternCopy) this).Position.X = Math.Round(((ProfilePatternCopy) this).Position.X * buSystem.MmToInchRatio, 5);
    ((ProfilePatternCopy) this).Position.Y = Math.Round(((ProfilePatternCopy) this).Position.Y * buSystem.MmToInchRatio, 5);
    ((ProfilePatternCopy) this).Position.Z = Math.Round(((ProfilePatternCopy) this).Position.Z * buSystem.MmToInchRatio, 5);
    ((ProfileOnlineOpOptions) this).basePosition.X = Math.Round(((ProfileOnlineOpOptions) this).basePosition.X * buSystem.MmToInchRatio, 5);
    ((ProfileOnlineOpOptions) this).basePosition.Y = Math.Round(((ProfileOnlineOpOptions) this).basePosition.Y * buSystem.MmToInchRatio, 5);
    ((ProfileOnlineOpOptions) this).basePosition.Z = Math.Round(((ProfileOnlineOpOptions) this).basePosition.Z * buSystem.MmToInchRatio, 5);
    ((ProfileOnlineOpOptions) this).cornerPosition.X = Math.Round(((ProfileOnlineOpOptions) this).cornerPosition.X * buSystem.MmToInchRatio, 5);
    ((ProfileOnlineOpOptions) this).cornerPosition.Y = Math.Round(((ProfileOnlineOpOptions) this).cornerPosition.Y * buSystem.MmToInchRatio, 5);
    ((ProfileOnlineOpOptions) this).cornerPosition.Z = Math.Round(((ProfileOnlineOpOptions) this).cornerPosition.Z * buSystem.MmToInchRatio, 5);
    ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).Depth).BottomPosition = Math.Round(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).Depth).BottomPosition * buSystem.MmToInchRatio, 5);
    ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).Depth).Depth = Math.Round(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).Depth).Depth * buSystem.MmToInchRatio, 5);
    ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).Depth).TopPosition = Math.Round(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).Depth).TopPosition * buSystem.MmToInchRatio, 5);
    for (int index = 0; index <= ((CreateProfileFromDataOptions) this).DepthValues.Count - 1; ++index)
    {
      ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).DepthValues[index]).BottomPosition = Math.Round(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).DepthValues[index]).BottomPosition * buSystem.MmToInchRatio, 5);
      ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).DepthValues[index]).Depth = Math.Round(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).DepthValues[index]).Depth * buSystem.MmToInchRatio, 5);
      ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).DepthValues[index]).TopPosition = Math.Round(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).DepthValues[index]).TopPosition * buSystem.MmToInchRatio, 5);
    }
  }

  public void InchToMm()
  {
    ((CreateProfileFromDataOptions) ((OperationInsideClampers) this).CircleData).CircleDiameter = Math.Round(((CreateProfileFromDataOptions) ((OperationInsideClampers) this).CircleData).CircleDiameter * buSystem.InchToMmRatio, 5);
    ((CreateProfileFromDataOptions) ((OperationInsideClampers) this).CircleData).CircleThickness = Math.Round(((CreateProfileFromDataOptions) ((OperationInsideClampers) this).CircleData).CircleDiameter * buSystem.InchToMmRatio, 5);
    ((OperationUpdateArg) ((DepthPositions) this).RectangleData).RectangleChamfer = Math.Round(((OperationUpdateArg) ((DepthPositions) this).RectangleData).RectangleChamfer * buSystem.InchToMmRatio, 5);
    ((OperationUpdateArg) ((DepthPositions) this).RectangleData).RectangleHeight = Math.Round(((OperationUpdateArg) ((DepthPositions) this).RectangleData).RectangleHeight * buSystem.InchToMmRatio, 5);
    ((OperationUpdateArg) ((DepthPositions) this).RectangleData).RectangleRadius = Math.Round(((OperationUpdateArg) ((DepthPositions) this).RectangleData).RectangleRadius * buSystem.InchToMmRatio, 5);
    ((profileSortSequenceAtSamePosition) ((DepthPositions) this).RectangleData).RectangleThickness = Math.Round(((profileSortSequenceAtSamePosition) ((DepthPositions) this).RectangleData).RectangleThickness * buSystem.InchToMmRatio, 5);
    ((CreateProfileFromDataOptions) ((DepthPositions) this).RectangleData).RectangleWidth = Math.Round(((CreateProfileFromDataOptions) ((DepthPositions) this).RectangleData).RectangleWidth * buSystem.InchToMmRatio, 5);
    ((PanelCutMove) ((DepthPositions) this).RectangleRoundData).RoundRectangleHeight = Math.Round(((PanelCutMove) ((DepthPositions) this).RectangleRoundData).RoundRectangleHeight * buSystem.InchToMmRatio, 5);
    ((PanelCutMove) ((DepthPositions) this).RectangleRoundData).RoundRectangleRadius = Math.Round(((PanelCutMove) ((DepthPositions) this).RectangleRoundData).RoundRectangleRadius * buSystem.InchToMmRatio, 5);
    ((PanelCutMove) ((DepthPositions) this).RectangleRoundData).RoundRectangleThickness = Math.Round(((PanelCutMove) ((DepthPositions) this).RectangleRoundData).RoundRectangleThickness * buSystem.InchToMmRatio, 5);
    ((PanelCutMove) ((DepthPositions) this).RectangleRoundData).RoundRectangleWidth = Math.Round(((PanelCutMove) ((DepthPositions) this).RectangleRoundData).RoundRectangleWidth * buSystem.InchToMmRatio, 5);
    ((PanelDonePart) ((DepthPositions) this).CutData).CutDepth = Math.Round(((PanelDonePart) ((DepthPositions) this).CutData).CutDepth * buSystem.InchToMmRatio, 5);
    ((PanelDonePart) ((DepthPositions) this).CutData).CutHeigth = Math.Round(((PanelDonePart) ((DepthPositions) this).CutData).CutHeigth * buSystem.InchToMmRatio, 5);
    ((PanelWaitAssembly) ((DepthPositions) this).CutData).CutThickness = Math.Round(((PanelWaitAssembly) ((DepthPositions) this).CutData).CutThickness * buSystem.InchToMmRatio, 5);
    ((PanelDonePart) ((DepthPositions) this).CutData).CutWidth = Math.Round(((PanelDonePart) ((DepthPositions) this).CutData).CutWidth * buSystem.InchToMmRatio, 5);
    ((PanelEntityData) ((DepthPositions) this).SlotData).SlotDiameter = Math.Round(((PanelEntityData) ((DepthPositions) this).SlotData).SlotDiameter * buSystem.InchToMmRatio, 5);
    ((PanelEntityData) ((DepthPositions) this).SlotData).SlotThickness = Math.Round(((PanelEntityData) ((DepthPositions) this).SlotData).SlotThickness * buSystem.InchToMmRatio, 5);
    ((PanelEntityData) ((DepthPositions) this).SlotData).SlotWidth = Math.Round(((PanelEntityData) ((DepthPositions) this).SlotData).SlotWidth * buSystem.InchToMmRatio, 5);
    ((NestingPanelJob) ((DepthPositions) this).EllipseData).EllipseHeight = Math.Round(((NestingPanelJob) ((DepthPositions) this).EllipseData).EllipseHeight * buSystem.InchToMmRatio, 5);
    ((NestingPanelJob) ((DepthPositions) this).EllipseData).EllipseThickness = Math.Round(((NestingPanelJob) ((DepthPositions) this).EllipseData).EllipseThickness * buSystem.InchToMmRatio, 5);
    ((NestingPanelJob) ((DepthPositions) this).EllipseData).EllipseWidth = Math.Round(((NestingPanelJob) ((DepthPositions) this).EllipseData).EllipseWidth * buSystem.InchToMmRatio, 5);
    ((NestingPanelJob) ((DepthPositions) this).NotchData).NotchDepth = Math.Round(((NestingPanelJob) ((DepthPositions) this).NotchData).NotchDepth * buSystem.InchToMmRatio, 5);
    ((NestingPanelJob) ((DepthPositions) this).NotchData).NotchHeight = Math.Round(((NestingPanelJob) ((DepthPositions) this).NotchData).NotchHeight * buSystem.InchToMmRatio, 5);
    ((NestingPanel) ((DepthPositions) this).NotchData).NotchStart = Math.Round(((NestingPanel) ((DepthPositions) this).NotchData).NotchStart * buSystem.InchToMmRatio, 5);
    ((NestingPanel) ((DepthPositions) this).NotchData).NotchThickness = Math.Round(((NestingPanel) ((DepthPositions) this).NotchData).NotchThickness * buSystem.InchToMmRatio, 5);
    ((NestingPanelJob) ((DepthPositions) this).NotchData).NotchWidth = Math.Round(((NestingPanelJob) ((DepthPositions) this).NotchData).NotchWidth * buSystem.InchToMmRatio, 5);
    ((NestingPanel) ((DepthPositions) this).HoleData).HoleDepth = Math.Round(((NestingPanel) ((DepthPositions) this).HoleData).HoleDepth * buSystem.InchToMmRatio, 5);
    ((NestingPanel) ((DepthPositions) this).HoleData).HoleDiameter = Math.Round(((NestingPanel) ((DepthPositions) this).HoleData).HoleDiameter * buSystem.InchToMmRatio, 5);
    ((NestingPanel) ((DepthPositions) this).HoleData).HoleThickness = Math.Round(((NestingPanel) ((DepthPositions) this).HoleData).HoleThickness * buSystem.InchToMmRatio, 5);
    ((PanelCutMove) ((DepthPositions) this).BarelData).BarrelDiameter = Math.Round(((PanelCutMove) ((DepthPositions) this).BarelData).BarrelDiameter * buSystem.InchToMmRatio, 5);
    ((PanelCutMove) ((DepthPositions) this).BarelData).BarrelLength = Math.Round(((PanelCutMove) ((DepthPositions) this).BarelData).BarrelLength * buSystem.InchToMmRatio, 5);
    ((PanelCutMove) ((DepthPositions) this).BarelData).BarrelThickness = Math.Round(((PanelCutMove) ((DepthPositions) this).BarelData).BarrelThickness * buSystem.InchToMmRatio, 5);
    ((PanelCutMove) ((DepthPositions) this).BarelData).BarrelWidth = Math.Round(((PanelCutMove) ((DepthPositions) this).BarelData).BarrelWidth * buSystem.InchToMmRatio, 5);
    ((NestingPanelNode) ((DepthPositionOptions) this).FreeDrawData).FreeDrawHeight = Math.Round(((NestingPanelNode) ((DepthPositionOptions) this).FreeDrawData).FreeDrawHeight * buSystem.InchToMmRatio, 5);
    ((NestingPanelNode) ((DepthPositionOptions) this).FreeDrawData).FreeDrawThickness = Math.Round(((NestingPanelNode) ((DepthPositionOptions) this).FreeDrawData).FreeDrawThickness * buSystem.InchToMmRatio, 5);
    ((NestingPanelNode) ((DepthPositionOptions) this).FreeDrawData).FreeDrawWidth = Math.Round(((NestingPanelNode) ((DepthPositionOptions) this).FreeDrawData).FreeDrawThickness * buSystem.InchToMmRatio, 5);
    ((NestingPanelNode) ((DepthPositionOptions) this).TextData).CharSpace = Math.Round(((NestingPanelNode) ((DepthPositionOptions) this).TextData).CharSpace * buSystem.InchToMmRatio, 5);
    ((NestingPanelNode) ((DepthPositionOptions) this).TextData).SpaceValue = Math.Round(((NestingPanelNode) ((DepthPositionOptions) this).TextData).SpaceValue * buSystem.InchToMmRatio, 5);
    ((NestingPanelNode) ((DepthPositionOptions) this).TextData).TextHeight = Math.Round(((NestingPanelNode) ((DepthPositionOptions) this).TextData).TextHeight * buSystem.InchToMmRatio, 5);
    ((PanelCutSettings) ((DepthPositionOptions) this).TextData).TextThickness = Math.Round(((PanelCutSettings) ((DepthPositionOptions) this).TextData).TextThickness * buSystem.InchToMmRatio, 5);
    ((NestingPanelNode) ((DepthPositionOptions) this).TextData).TextWidth = Math.Round(((NestingPanelNode) ((DepthPositionOptions) this).TextData).TextWidth * buSystem.InchToMmRatio, 5);
    ((CreateProfileFromDataOptions) ((DepthPositionOptions) this).PolygonData).PolygonDiameter = Math.Round(((CreateProfileFromDataOptions) ((DepthPositionOptions) this).PolygonData).PolygonDiameter * buSystem.InchToMmRatio, 5);
    ((CreateProfileFromDataOptions) ((DepthPositionOptions) this).PolygonData).PolygonThickness = Math.Round(((CreateProfileFromDataOptions) ((DepthPositionOptions) this).PolygonData).PolygonThickness * buSystem.InchToMmRatio, 5);
    ((ShapeRuntimeData) ((DepthPositionOptions) this).Array).LineerXDistance = Math.Round(((ShapeRuntimeData) ((DepthPositionOptions) this).Array).LineerXDistance * buSystem.InchToMmRatio, 5);
    ((ShapeRuntimeData) ((DepthPositionOptions) this).Array).LineerYDistance = Math.Round(((ShapeRuntimeData) ((DepthPositionOptions) this).Array).LineerXDistance * buSystem.InchToMmRatio, 5);
    ((ShapeRuntimeData) ((DepthPositionOptions) this).Mirror).MirrorDistance = Math.Round(((ShapeRuntimeData) ((DepthPositionOptions) this).Mirror).MirrorDistance * buSystem.InchToMmRatio, 5);
    ((ProfileArray) this).ExternalDepth = Math.Round(((ProfileArray) this).ExternalDepth * buSystem.InchToMmRatio, 5);
    ((ProfileArray) this).ExtraDepth = Math.Round(((ProfileArray) this).ExtraDepth * buSystem.InchToMmRatio, 5);
    ((ProfileArray) this).IncrementalDistance = Math.Round(((ProfileArray) this).IncrementalDistance * buSystem.InchToMmRatio, 5);
    ((ProfileArray) this).ManuelZVal = Math.Round(((ProfileArray) this).ManuelZVal * buSystem.InchToMmRatio, 5);
    ((ProfileArray) this).SelectedPlaneLength = Math.Round(((ProfileArray) this).SelectedPlaneLength * buSystem.InchToMmRatio, 5);
    ((ProfilePatternCopy) this).movePlanePoint.X = Math.Round(((ProfilePatternCopy) this).movePlanePoint.X * buSystem.InchToMmRatio, 5);
    ((ProfilePatternCopy) this).movePlanePoint.Y = Math.Round(((ProfilePatternCopy) this).movePlanePoint.Y * buSystem.InchToMmRatio, 5);
    ((ProfilePatternCopy) this).movePlanePoint.Z = Math.Round(((ProfilePatternCopy) this).movePlanePoint.Z * buSystem.InchToMmRatio, 5);
    ((ProfilePatternCopy) this).Position.X = Math.Round(((ProfilePatternCopy) this).Position.X * buSystem.InchToMmRatio, 5);
    ((ProfilePatternCopy) this).Position.Y = Math.Round(((ProfilePatternCopy) this).Position.Y * buSystem.InchToMmRatio, 5);
    ((ProfilePatternCopy) this).Position.Z = Math.Round(((ProfilePatternCopy) this).Position.Z * buSystem.InchToMmRatio, 5);
    ((ProfileOnlineOpOptions) this).basePosition.X = Math.Round(((ProfileOnlineOpOptions) this).basePosition.X * buSystem.InchToMmRatio, 5);
    ((ProfileOnlineOpOptions) this).basePosition.Y = Math.Round(((ProfileOnlineOpOptions) this).basePosition.Y * buSystem.InchToMmRatio, 5);
    ((ProfileOnlineOpOptions) this).basePosition.Z = Math.Round(((ProfileOnlineOpOptions) this).basePosition.Z * buSystem.InchToMmRatio, 5);
    ((ProfileOnlineOpOptions) this).cornerPosition.X = Math.Round(((ProfileOnlineOpOptions) this).cornerPosition.X * buSystem.InchToMmRatio, 5);
    ((ProfileOnlineOpOptions) this).cornerPosition.Y = Math.Round(((ProfileOnlineOpOptions) this).cornerPosition.Y * buSystem.InchToMmRatio, 5);
    ((ProfileOnlineOpOptions) this).cornerPosition.Z = Math.Round(((ProfileOnlineOpOptions) this).cornerPosition.Z * buSystem.InchToMmRatio, 5);
    ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).Depth).BottomPosition = Math.Round(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).Depth).BottomPosition * buSystem.InchToMmRatio, 5);
    ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).Depth).Depth = Math.Round(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).Depth).Depth * buSystem.InchToMmRatio, 5);
    ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).Depth).TopPosition = Math.Round(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).Depth).TopPosition * buSystem.InchToMmRatio, 5);
    for (int index = 0; index <= ((CreateProfileFromDataOptions) this).DepthValues.Count - 1; ++index)
    {
      ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).DepthValues[index]).BottomPosition = Math.Round(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).DepthValues[index]).BottomPosition * buSystem.InchToMmRatio, 5);
      ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).DepthValues[index]).Depth = Math.Round(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).DepthValues[index]).Depth * buSystem.InchToMmRatio, 5);
      ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).DepthValues[index]).TopPosition = Math.Round(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) this).DepthValues[index]).TopPosition * buSystem.InchToMmRatio, 5);
    }
  }

  public override string ToString()
  {
    string str = $"{((CreateProfileFromDataOptions) this).OperationType.ToString()} , Plane: {((ProfileMirror) this).selectedPlaneName.ToString()} , Pos: {((ProfilePatternCopy) this).Position.ToString()}";
    if (((ProfileOnlineOpOptions) this).ToolName.Length > 0)
      str = $"{str}, Tool: {((ProfileOnlineOpOptions) this).ToolName}";
    return str;
  }

  public static ArrayList ToDefPars(ProfileOperationData P, string Char, int Space)
  {
    string str = "ProfileOperationDataPars";
    if (Char.Trim().Length > 0)
      str = Char;
    return new ArrayList()
    {
      (object) $"{buImage5.SpaceChar(Space)}<{str}",
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) $"{buImage5.SpaceChar(Space)}</{str}"
    };
  }

  public static ArrayList ToDefPars(ProfileOperationData P, int Space)
  {
    return new ArrayList()
    {
      (object) (buImage5.SpaceChar(Space) + "<ProfileOperationDataPars>"),
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) (buImage5.SpaceChar(Space) + "</ProfileOperationDataPars>")
    };
  }

  public static string ToDefPars(ProfileOperationData P)
  {
    return buSerilization5.ClassToString((object) P);
  }

  static buMarbleCalc() => CreateProfileFromDataOptions.Captions = new List<string>();

  public buMarbleCalc()
  {
    ((CreateProfileFromDataOptions) this).CircleDiameter = 10.0;
    ((CreateProfileFromDataOptions) this).CircleColor = Color.Blue;
    ((CreateProfileFromDataOptions) this).CircleThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buMarbleCalc(ProfileOperationDataCircle data)
  {
    ((CreateProfileFromDataOptions) this).CircleDiameter = 10.0;
    ((CreateProfileFromDataOptions) this).CircleColor = Color.Blue;
    ((CreateProfileFromDataOptions) this).CircleThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    return "Dia : " + ((CreateProfileFromDataOptions) this).CircleDiameter.ToString();
  }

  public static ArrayList ToDefPars(ProfileOperationDataCircle P, string Char, int Space)
  {
    string str = "ProfileOperationDataCirclePars";
    if (Char.Trim().Length > 0)
      str = Char;
    return new ArrayList()
    {
      (object) $"{buImage5.SpaceChar(Space)}<{str}",
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) $"{buImage5.SpaceChar(Space)}</{str}"
    };
  }

  public static ArrayList ToDefPars(ProfileOperationDataCircle P, int Space)
  {
    return new ArrayList()
    {
      (object) (buImage5.SpaceChar(Space) + "<ProfileOperationDataCirclePars>"),
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) (buImage5.SpaceChar(Space) + "</ProfileOperationDataCirclePars>")
    };
  }

  public static string ToDefPars(ProfileOperationDataCircle P)
  {
    return buSerilization5.ClassToString((object) P);
  }

  public abstract void m001E22();

  public buMarbleCalc()
  {
    ((CreateProfileFromDataOptions) this).PolygonSide = 6;
    ((CreateProfileFromDataOptions) this).PolygonDiameter = 20.0;
    ((CreateProfileFromDataOptions) this).PolygonAngle = 0.0;
    ((CreateProfileFromDataOptions) this).PolygonColor = Color.Blue;
    ((CreateProfileFromDataOptions) this).PolygonThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buMarbleCalc(ProfileOperationDataPolygon data)
  {
    ((CreateProfileFromDataOptions) this).PolygonSide = 6;
    ((CreateProfileFromDataOptions) this).PolygonDiameter = 20.0;
    ((CreateProfileFromDataOptions) this).PolygonAngle = 0.0;
    ((CreateProfileFromDataOptions) this).PolygonColor = Color.Blue;
    ((CreateProfileFromDataOptions) this).PolygonThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    return "Side : " + ((CreateProfileFromDataOptions) this).PolygonSide.ToString();
  }

  public static ArrayList ToDefPars(ProfileOperationDataPolygon P, string Char, int Space)
  {
    string str = "ProfileOperationDataPolygonPars";
    if (Char.Trim().Length > 0)
      str = Char;
    return new ArrayList()
    {
      (object) $"{buImage5.SpaceChar(Space)}<{str}",
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) $"{buImage5.SpaceChar(Space)}</{str}"
    };
  }

  public static ArrayList ToDefPars(ProfileOperationDataPolygon P, int Space)
  {
    return new ArrayList()
    {
      (object) (buImage5.SpaceChar(Space) + "<ProfileOperationDataPolygonPars>"),
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) (buImage5.SpaceChar(Space) + "</ProfileOperationDataPolygonPars>")
    };
  }

  public static string ToDefPars(ProfileOperationDataPolygon P)
  {
    return buSerilization5.ClassToString((object) P);
  }

  public abstract void m001E29();

  public buMarbleCalc()
  {
    ((CreateProfileFromDataOptions) this).RectangleWidth = 20.0;
    ((OperationUpdateArg) this).RectangleHeight = 20.0;
    ((OperationUpdateArg) this).RectangleRadius = 0.0;
    ((OperationUpdateArg) this).RectangleChamfer = 0.0;
    ((OperationUpdateArg) this).RectangleAngle = 0.0;
    ((profileSortSequenceAtSamePosition) this).RectangleColor = Color.Blue;
    ((profileSortSequenceAtSamePosition) this).RectangleThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buMarbleCalc(ProfileOperationDataRectangle data)
  {
    ((CreateProfileFromDataOptions) this).RectangleWidth = 20.0;
    ((OperationUpdateArg) this).RectangleHeight = 20.0;
    ((OperationUpdateArg) this).RectangleRadius = 0.0;
    ((OperationUpdateArg) this).RectangleChamfer = 0.0;
    ((OperationUpdateArg) this).RectangleAngle = 0.0;
    ((profileSortSequenceAtSamePosition) this).RectangleColor = Color.Blue;
    ((profileSortSequenceAtSamePosition) this).RectangleThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    return $"Width : {((CreateProfileFromDataOptions) this).RectangleWidth.ToString()} - Height : {((OperationUpdateArg) this).RectangleHeight.ToString()}";
  }

  public static ArrayList ToDefPars(ProfileOperationDataRectangle P, string Char, int Space)
  {
    string str = "ProfileOperationDataRectanglePars";
    if (Char.Trim().Length > 0)
      str = Char;
    return new ArrayList()
    {
      (object) $"{buImage5.SpaceChar(Space)}<{str}",
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) $"{buImage5.SpaceChar(Space)}</{str}"
    };
  }

  public static ArrayList ToDefPars(ProfileOperationDataRectangle P, int Space)
  {
    return new ArrayList()
    {
      (object) (buImage5.SpaceChar(Space) + "<ProfileOperationDataRectanglePars>"),
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) (buImage5.SpaceChar(Space) + "</ProfileOperationDataRectanglePars>")
    };
  }

  public static string ToDefPars(ProfileOperationDataRectangle P)
  {
    return buSerilization5.ClassToString((object) P);
  }

  public abstract void m001E30();

  public buMarbleCalc()
  {
    ((PanelCutMove) this).RoundRectangleWidth = 20.0;
    ((PanelCutMove) this).RoundRectangleHeight = 20.0;
    ((PanelCutMove) this).RoundRectangleRadius = 2.0;
    ((PanelCutMove) this).RoundRectangleAngle = 0.0;
    ((PanelCutMove) this).RoundRectangleColor = Color.Blue;
    ((PanelCutMove) this).RoundRectangleThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buMarbleCalc(ProfileOperationDataRectangleRound data)
  {
    ((PanelCutMove) this).RoundRectangleWidth = 20.0;
    ((PanelCutMove) this).RoundRectangleHeight = 20.0;
    ((PanelCutMove) this).RoundRectangleRadius = 2.0;
    ((PanelCutMove) this).RoundRectangleAngle = 0.0;
    ((PanelCutMove) this).RoundRectangleColor = Color.Blue;
    ((PanelCutMove) this).RoundRectangleThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    return $"Width : {((PanelCutMove) this).RoundRectangleWidth.ToString()} - Height : {((PanelCutMove) this).RoundRectangleHeight.ToString()} - Radius : {((PanelCutMove) this).RoundRectangleRadius.ToString()}";
  }

  public static ArrayList ToDefPars(ProfileOperationDataRectangleRound P, string Char, int Space)
  {
    string str = "ProfileOperationDataRectangleRoundPars";
    if (Char.Trim().Length > 0)
      str = Char;
    return new ArrayList()
    {
      (object) $"{buImage5.SpaceChar(Space)}<{str}",
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) $"{buImage5.SpaceChar(Space)}</{str}"
    };
  }

  public static ArrayList ToDefPars(ProfileOperationDataRectangleRound P, int Space)
  {
    return new ArrayList()
    {
      (object) (buImage5.SpaceChar(Space) + "<ProfileOperationDataRectangleRoundPars>"),
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) (buImage5.SpaceChar(Space) + "</ProfileOperationDataRectangleRoundPars>")
    };
  }

  public static string ToDefPars(ProfileOperationDataRectangleRound P)
  {
    return buSerilization5.ClassToString((object) P);
  }

  public abstract void m001E37();

  public buMarbleCalc()
  {
    ((PanelCutMove) this).BarrelLength = 50.0;
    ((PanelCutMove) this).BarrelDiameter = 16.0;
    ((PanelCutMove) this).BarrelWidth = 10.0;
    ((PanelCutMove) this).BarrelAngle = 0.0;
    ((PanelCutMove) this).BarrelColor = Color.Blue;
    ((PanelCutMove) this).BarrelThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buMarbleCalc(ProfileOperationDataBarel data)
  {
    ((PanelCutMove) this).BarrelLength = 50.0;
    ((PanelCutMove) this).BarrelDiameter = 16.0;
    ((PanelCutMove) this).BarrelWidth = 10.0;
    ((PanelCutMove) this).BarrelAngle = 0.0;
    ((PanelCutMove) this).BarrelColor = Color.Blue;
    ((PanelCutMove) this).BarrelThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    return $"Len : {((PanelCutMove) this).BarrelLength.ToString()} - Dia : {((PanelCutMove) this).BarrelDiameter.ToString()} - Width : {((PanelCutMove) this).BarrelWidth.ToString()}";
  }

  public static ArrayList ToDefPars(ProfileOperationDataBarel P, string Char, int Space)
  {
    string str = "ProfileOperationDataPars";
    if (Char.Trim().Length > 0)
      str = Char;
    return new ArrayList()
    {
      (object) $"{buImage5.SpaceChar(Space)}<{str}",
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) $"{buImage5.SpaceChar(Space)}</{str}"
    };
  }

  public static ArrayList ToDefPars(ProfileOperationDataBarel P, int Space)
  {
    return new ArrayList()
    {
      (object) (buImage5.SpaceChar(Space) + "<ProfileOperationDataBarelPars>"),
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) (buImage5.SpaceChar(Space) + "</ProfileOperationDataBarelPars>")
    };
  }

  public static string ToDefPars(ProfileOperationDataBarel P)
  {
    return buSerilization5.ClassToString((object) P);
  }

  public abstract void m001E3E();

  public buMarbleCalc()
  {
    ((PanelEntityData) this).SlotWidth = 50.0;
    ((PanelEntityData) this).SlotDiameter = 10.0;
    ((PanelEntityData) this).SlotAngle = 0.0;
    ((PanelEntityData) this).SlotColor = Color.Blue;
    ((PanelEntityData) this).SlotThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buMarbleCalc(ProfileOperationDataSlot data)
  {
    ((PanelEntityData) this).SlotWidth = 50.0;
    ((PanelEntityData) this).SlotDiameter = 10.0;
    ((PanelEntityData) this).SlotAngle = 0.0;
    ((PanelEntityData) this).SlotColor = Color.Blue;
    ((PanelEntityData) this).SlotThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    return $"Width : {((PanelEntityData) this).SlotWidth.ToString()} - Dia : {((PanelEntityData) this).SlotDiameter.ToString()}";
  }

  public static ArrayList ToDefPars(ProfileOperationDataSlot P, string Char, int Space)
  {
    string str = "ProfileOperationDataSlotPars";
    if (Char.Trim().Length > 0)
      str = Char;
    return new ArrayList()
    {
      (object) $"{buImage5.SpaceChar(Space)}<{str}",
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) $"{buImage5.SpaceChar(Space)}</{str}"
    };
  }

  public static ArrayList ToDefPars(ProfileOperationDataSlot P, int Space)
  {
    return new ArrayList()
    {
      (object) (buImage5.SpaceChar(Space) + "<ProfileOperationDataSlotPars>"),
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) (buImage5.SpaceChar(Space) + "</ProfileOperationDataSlotPars>")
    };
  }

  public static string ToDefPars(ProfileOperationDataSlot P)
  {
    return buSerilization5.ClassToString((object) P);
  }

  public abstract void m001E45();

  public buMarbleCalc()
  {
    ((PanelDonePart) this).CutWidth = 10.0;
    ((PanelDonePart) this).CutHeigth = 50.0;
    ((PanelDonePart) this).CutDepth = 10.0;
    ((PanelWaitAssembly) this).CutAngle = 0.0;
    ((PanelWaitAssembly) this).CutColor = Color.Blue;
    ((PanelWaitAssembly) this).CutThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buMarbleCalc(ProfileOperationDataCut data)
  {
    ((PanelDonePart) this).CutWidth = 10.0;
    ((PanelDonePart) this).CutHeigth = 50.0;
    ((PanelDonePart) this).CutDepth = 10.0;
    ((PanelWaitAssembly) this).CutAngle = 0.0;
    ((PanelWaitAssembly) this).CutColor = Color.Blue;
    ((PanelWaitAssembly) this).CutThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    return $"Width : {((PanelDonePart) this).CutWidth.ToString()} - H : {((PanelDonePart) this).CutHeigth.ToString()}";
  }

  public static ArrayList ToDefPars(ProfileOperationDataCut P, string Char, int Space)
  {
    string str = "ProfileOperationDataCutPars";
    if (Char.Trim().Length > 0)
      str = Char;
    return new ArrayList()
    {
      (object) $"{buImage5.SpaceChar(Space)}<{str}",
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) $"{buImage5.SpaceChar(Space)}</{str}"
    };
  }

  public static ArrayList ToDefPars(ProfileOperationDataCut P, int Space)
  {
    return new ArrayList()
    {
      (object) (buImage5.SpaceChar(Space) + "<ProfileOperationDataCutPars>"),
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) (buImage5.SpaceChar(Space) + "</ProfileOperationDataCutPars>")
    };
  }

  public static string ToDefPars(ProfileOperationDataCut P)
  {
    return buSerilization5.ClassToString((object) P);
  }

  public abstract void m001E4C();

  public buMarbleCalc()
  {
    ((NestingPanelJob) this).EllipseWidth = 20.0;
    ((NestingPanelJob) this).EllipseHeight = 20.0;
    ((NestingPanelJob) this).EllipseAngle = 0.0;
    ((NestingPanelJob) this).EllipseColor = Color.Blue;
    ((NestingPanelJob) this).EllipseThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buMarbleCalc(ProfileOperationDataEllipse data)
  {
    ((NestingPanelJob) this).EllipseWidth = 20.0;
    ((NestingPanelJob) this).EllipseHeight = 20.0;
    ((NestingPanelJob) this).EllipseAngle = 0.0;
    ((NestingPanelJob) this).EllipseColor = Color.Blue;
    ((NestingPanelJob) this).EllipseThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    return $"Width : {((NestingPanelJob) this).EllipseWidth.ToString()} - EllipseHeight : {((NestingPanelJob) this).EllipseHeight.ToString()}";
  }

  public static ArrayList ToDefPars(ProfileOperationDataEllipse P, string Char, int Space)
  {
    string str = "ProfileOperationDataEllipsePars";
    if (Char.Trim().Length > 0)
      str = Char;
    return new ArrayList()
    {
      (object) $"{buImage5.SpaceChar(Space)}<{str}",
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) $"{buImage5.SpaceChar(Space)}</{str}"
    };
  }

  public static ArrayList ToDefPars(ProfileOperationDataEllipse P, int Space)
  {
    return new ArrayList()
    {
      (object) (buImage5.SpaceChar(Space) + "<ProfileOperationDataEllipsePars>"),
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) (buImage5.SpaceChar(Space) + "</ProfileOperationDataEllipsePars>")
    };
  }

  public static string ToDefPars(ProfileOperationDataEllipse P)
  {
    return buSerilization5.ClassToString((object) P);
  }

  public abstract void m001E53();

  public buMarbleCalc()
  {
    ((NestingPanelJob) this).NotchDepth = 20.0;
    ((NestingPanelJob) this).NotchWidth = 10.0;
    ((NestingPanelJob) this).NotchHeight = 20.0;
    ((NestingPanel) this).NotchUpDown = UpDownLocationType.Up;
    ((NestingPanel) this).NotchFrontBack = FrontBackType.Front;
    ((NestingPanel) this).NotchOPType = ProfileNotchOperationType.Side;
    ((NestingPanel) this).NotchStart = 10.0;
    ((NestingPanel) this).NotchLocation = ProfileNotchLocationType.Left;
    ((NestingPanel) this).NotchColor = Color.Blue;
    ((NestingPanel) this).NotchThickness = 1.0;
    ((NestingPanel) this).UseMilling = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buMarbleCalc(ProfileOperationDataNotch data)
  {
    ((NestingPanelJob) this).NotchDepth = 20.0;
    ((NestingPanelJob) this).NotchWidth = 10.0;
    ((NestingPanelJob) this).NotchHeight = 20.0;
    ((NestingPanel) this).NotchUpDown = UpDownLocationType.Up;
    ((NestingPanel) this).NotchFrontBack = FrontBackType.Front;
    ((NestingPanel) this).NotchOPType = ProfileNotchOperationType.Side;
    ((NestingPanel) this).NotchStart = 10.0;
    ((NestingPanel) this).NotchLocation = ProfileNotchLocationType.Left;
    ((NestingPanel) this).NotchColor = Color.Blue;
    ((NestingPanel) this).NotchThickness = 1.0;
    ((NestingPanel) this).UseMilling = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    string str = $"Depth: {((NestingPanelJob) this).NotchDepth.ToString("f1")} - Width: {((NestingPanelJob) this).NotchWidth.ToString("f1")} - Height: {((NestingPanelJob) this).NotchHeight.ToString("f1")} - {((NestingPanel) this).NotchLocation.ToString()} - {((NestingPanel) this).NotchUpDown.ToString()} - {((NestingPanel) this).NotchFrontBack.ToString()}";
    if (((NestingPanel) this).UseMilling)
      str = $"{str} - Milling: {((NestingPanel) this).UseMilling.ToString()}";
    return str;
  }

  public static ArrayList ToDefPars(ProfileOperationDataNotch P, string Char, int Space)
  {
    string str = "ProfileOperationDataNotchPars";
    if (Char.Trim().Length > 0)
      str = Char;
    return new ArrayList()
    {
      (object) $"{buImage5.SpaceChar(Space)}<{str}",
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) $"{buImage5.SpaceChar(Space)}</{str}"
    };
  }

  public static ArrayList ToDefPars(ProfileOperationDataNotch P, int Space)
  {
    return new ArrayList()
    {
      (object) (buImage5.SpaceChar(Space) + "<ProfileOperationDataNotchPars>"),
      (object) (buImage5.SpaceChar(Space + 2) + buMarbleCalc.ToDefPars(P)),
      (object) (buImage5.SpaceChar(Space) + "</ProfileOperationDataNotchPars>")
    };
  }

  public static string ToDefPars(ProfileOperationDataNotch P)
  {
    return buSerilization5.ClassToString((object) P);
  }

  public abstract void m001E5A();

  public buMarbleCalc()
  {
    ((NestingPanel) this).HoleDepth = 10.0;
    ((NestingPanel) this).HoleDiameter = 10.0;
    ((NestingPanel) this).HoleColor = Color.Blue;
    ((NestingPanel) this).HoleThickness = 1.0;
    ((NestingPanel) this).Tapping = false;
    ((NestingPanelNode) this).TappingDiameter = 5.0;
    ((NestingPanelNode) this).TappingDepth = 8.0;
    ((NestingPanelNode) this).TappingPitch = 2.0;
    ((NestingPanelNode) this).TappingAddition = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buMarbleCalc(ProfileOperationDataHole data)
  {
    ((NestingPanel) this).HoleDepth = 10.0;
    ((NestingPanel) this).HoleDiameter = 10.0;
    ((NestingPanel) this).HoleColor = Color.Blue;
    ((NestingPanel) this).HoleThickness = 1.0;
    ((NestingPanel) this).Tapping = false;
    ((NestingPanelNode) this).TappingDiameter = 5.0;
    ((NestingPanelNode) this).TappingDepth = 8.0;
    ((NestingPanelNode) this).TappingPitch = 2.0;
    ((NestingPanelNode) this).TappingAddition = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    string str = "Dia : " + ((NestingPanel) this).HoleDiameter.ToString();
    if (((NestingPanel) this).Tapping)
      str = $"{str} - Tapping Dia: {((NestingPanelNode) this).TappingDiameter.ToString("f1")}";
    return str;
  }

  public event OkCommandWithFiveDataEventHandler MarbleCalcCommandSend;
}
