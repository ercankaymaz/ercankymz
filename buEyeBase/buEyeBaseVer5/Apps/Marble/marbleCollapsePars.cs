// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCollapsePars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCollapsePars : buSerilization5
{
  public double ConcaveCornerExtraOffset;
  public double ConvexCornerExtraOffset;
  public double OutterCutSafeDistance;
  public double Inside45DegreeExtraOffset;
  public double Inside0DegreeExtraOffset;
  public bool DontMoveSafeForForwardBackwardDirection;
  public double RegenDeviation;
  public MarbleConcaveArcOffsetCalculationType ConcaveArcOffsetType;

  public void MirrorItem(ref MarbleItem Item, Point3D pointBase, Point3D pointMirror)
  {
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SolidEntity != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SolidEntity.Count - 1; ++index)
      {
        Entity refEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SolidEntity[index];
        buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).TextEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).TextEntities.Count - 1; ++index)
      {
        buEntity textEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).TextEntities[index];
        buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref textEntity);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrawWireEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrawWireEntities.Count - 1; ++index)
      {
        buEntity drawWireEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrawWireEntities[index];
        buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref drawWireEntity);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities != null)
    {
      for (int index1 = 0; index1 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities[index1].Count - 1; ++index2)
        {
          buEntity refEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities[index1][index2];
          buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity);
        }
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SourceEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SourceEntities.Count - 1; ++index)
      {
        buEntity sourceEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SourceEntities[index];
        buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref sourceEntity);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BaseEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BaseEntities.Count - 1; ++index)
      {
        buEntity baseEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BaseEntities[index];
        buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref baseEntity);
      }
    }
    if (((MarbleScreenCaptureSettings) Item).EntGroup != null)
      buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref ((MarbleScreenCaptureSettings) Item).EntGroup);
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConcaveEntities != null)
    {
      for (int index3 = 0; index3 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConcaveEntities.Count - 1; ++index3)
      {
        for (int index4 = 0; index4 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConcaveEntities[index3].Count - 1; ++index4)
        {
          buEntity refEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConcaveEntities[index3][index4];
          buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity);
        }
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConvexEntities != null)
    {
      for (int index5 = 0; index5 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConvexEntities.Count - 1; ++index5)
      {
        for (int index6 = 0; index6 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConvexEntities[index5].Count - 1; ++index6)
        {
          buEntity refEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConvexEntities[index5][index6];
          buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity);
        }
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities.Count - 1; ++index)
      {
        buEntity edgeEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities[index];
        buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref edgeEntity);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ExtensionEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ExtensionEntities.Count - 1; ++index)
      {
        buEntity extensionEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ExtensionEntities[index];
        buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref extensionEntity);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EngravingEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EngravingEntities.Count - 1; ++index)
      {
        buEntity engravingEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EngravingEntities[index];
        buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref engravingEntity);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BorderEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BorderEntities.Count - 1; ++index)
      {
        buEntity borderEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BorderEntities[index];
        buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref borderEntity);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrillEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrillEntities.Count - 1; ++index)
      {
        buEntity drillEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrillEntities[index];
        buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref drillEntity);
      }
    }
    for (int index = 0; index <= ((MarbleScreenCaptureSettings) Item).Edges.Count - 1; ++index)
    {
      buEntity refEntity = ((MarbleSliceType) ((MarbleScreenCaptureSettings) Item).Edges[index]).refEntity;
      buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity);
      buEntity drawEntity = ((MarbleSliceType) ((MarbleScreenCaptureSettings) Item).Edges[index]).drawEntity;
      buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref drawEntity);
      if (((MarbleMachineToolType) ((MarbleContourMenuType) ((MarbleScreenCaptureSettings) Item).Edges[index]).Slat).Solid != null)
      {
        Entity solid = ((MarbleMachineToolType) ((MarbleContourMenuType) ((MarbleScreenCaptureSettings) Item).Edges[index]).Slat).Solid;
        buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref solid);
      }
    }
    if ((((MarbleScreenCaptureSettings) Item).CamList == null ? 0 : (((MarbleScreenCaptureSettings) Item).CamList.Count > 0 ? 1 : 0)) != 0)
    {
      for (int index7 = 0; index7 <= ((MarbleScreenCaptureSettings) Item).CamList.Count - 1; ++index7)
      {
        ((MarbleScreenCaptureSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).isCamCalculated = false;
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase != null)
        {
          for (int index8 = 0; index8 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesG0.Count - 1; ++index8)
          {
            Entity refEntity = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesG0[index8];
            buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity);
          }
          for (int index9 = 0; index9 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesG1.Count - 1; ++index9)
          {
            Entity refEntity = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesG1[index9];
            buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity);
          }
          for (int index10 = 0; index10 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesLeave.Count - 1; ++index10)
          {
            Entity refEntity = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesLeave[index10];
            buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity);
          }
          for (int index11 = 0; index11 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesPlunge.Count - 1; ++index11)
          {
            Entity refEntity = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesPlunge[index11];
            buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity);
          }
          for (int index12 = 0; index12 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesLeadIn.Count - 1; ++index12)
          {
            Entity refEntity = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesLeadIn[index12];
            buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity);
          }
          for (int index13 = 0; index13 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesLeadOut.Count - 1; ++index13)
          {
            Entity refEntity = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesLeadOut[index13];
            buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity);
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).WireEntities != null)
        {
          for (int index14 = 0; index14 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).WireEntities.Count - 1; ++index14)
          {
            for (int index15 = 0; index15 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).WireEntities[index14].Count - 1; ++index15)
            {
              buEntity refEntity = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).WireEntities[index14][index15];
              buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity);
            }
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).EntityList != null)
          buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref ((\u0084.\u0001) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).EntityList).Entities);
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).WireAuxEntities != null)
        {
          for (int index16 = 0; index16 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).WireAuxEntities.Count - 1; ++index16)
          {
            for (int index17 = 0; index17 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).WireAuxEntities[index16].Count - 1; ++index17)
            {
              buEntity refEntity = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).WireAuxEntities[index16][index17];
              buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity);
            }
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).ConcaveEntities != null)
        {
          for (int index18 = 0; index18 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).ConcaveEntities.Count - 1; ++index18)
          {
            for (int index19 = 0; index19 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).ConcaveEntities[index18].Count - 1; ++index19)
            {
              buEntity refEntity = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).ConcaveEntities[index18][index19];
              buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity);
            }
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).ConvexEntities != null)
        {
          for (int index20 = 0; index20 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).ConvexEntities.Count - 1; ++index20)
          {
            for (int index21 = 0; index21 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).ConvexEntities[index20].Count - 1; ++index21)
            {
              buEntity refEntity = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).ConvexEntities[index20][index21];
              buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity);
            }
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).DrillEntities != null)
        {
          for (int index22 = 0; index22 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).DrillEntities.Count - 1; ++index22)
          {
            buEntity drillEntity = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).DrillEntities[index22];
            buCall.\u0001.Mirror(pointBase, pointMirror, Plane.XY, ref drillEntity);
          }
        }
      }
    }
    ((marbleMaterialPars) this).ItemSizeCalculation(ref Item);
  }

  public void ScaleItem(ref MarbleItem Item, Point3D pointBase, double RatioX, double RatioY)
  {
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SolidEntity != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SolidEntity.Count - 1; ++index)
      {
        Entity refEntities = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SolidEntity[index];
        buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).TextEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).TextEntities.Count - 1; ++index)
      {
        buEntity textEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).TextEntities[index];
        buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref textEntity);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrawWireEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrawWireEntities.Count - 1; ++index)
      {
        buEntity drawWireEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrawWireEntities[index];
        buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref drawWireEntity);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities != null)
    {
      for (int index1 = 0; index1 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities[index1].Count - 1; ++index2)
        {
          buEntity refEntities = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities[index1][index2];
          buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities);
        }
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SourceEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SourceEntities.Count - 1; ++index)
      {
        buEntity sourceEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SourceEntities[index];
        buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref sourceEntity);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BaseEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BaseEntities.Count - 1; ++index)
      {
        buEntity baseEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BaseEntities[index];
        buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref baseEntity);
      }
    }
    if (((MarbleScreenCaptureSettings) Item).EntGroup != null)
      buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref ((MarbleScreenCaptureSettings) Item).EntGroup);
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConcaveEntities != null)
    {
      for (int index3 = 0; index3 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConcaveEntities.Count - 1; ++index3)
      {
        for (int index4 = 0; index4 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConcaveEntities[index3].Count - 1; ++index4)
        {
          buEntity refEntities = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConcaveEntities[index3][index4];
          buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities);
        }
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConvexEntities != null)
    {
      for (int index5 = 0; index5 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConvexEntities.Count - 1; ++index5)
      {
        for (int index6 = 0; index6 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConvexEntities[index5].Count - 1; ++index6)
        {
          buEntity refEntities = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ConvexEntities[index5][index6];
          buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities);
        }
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities.Count - 1; ++index)
      {
        buEntity edgeEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities[index];
        buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref edgeEntity);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ExtensionEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ExtensionEntities.Count - 1; ++index)
      {
        buEntity extensionEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ExtensionEntities[index];
        buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref extensionEntity);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EngravingEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EngravingEntities.Count - 1; ++index)
      {
        buEntity engravingEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EngravingEntities[index];
        buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref engravingEntity);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BorderEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BorderEntities.Count - 1; ++index)
      {
        buEntity borderEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).BorderEntities[index];
        buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref borderEntity);
      }
    }
    if (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrillEntities != null)
    {
      for (int index = 0; index <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrillEntities.Count - 1; ++index)
      {
        buEntity drillEntity = ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrillEntities[index];
        buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref drillEntity);
      }
    }
    for (int index = 0; index <= ((MarbleScreenCaptureSettings) Item).Edges.Count - 1; ++index)
    {
      buEntity refEntity = ((MarbleSliceType) ((MarbleScreenCaptureSettings) Item).Edges[index]).refEntity;
      buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntity);
      buEntity drawEntity = ((MarbleSliceType) ((MarbleScreenCaptureSettings) Item).Edges[index]).drawEntity;
      buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref drawEntity);
      if (((MarbleMachineToolType) ((MarbleContourMenuType) ((MarbleScreenCaptureSettings) Item).Edges[index]).Slat).Solid != null)
      {
        Entity solid = ((MarbleMachineToolType) ((MarbleContourMenuType) ((MarbleScreenCaptureSettings) Item).Edges[index]).Slat).Solid;
        buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref solid);
      }
    }
    if ((((MarbleScreenCaptureSettings) Item).CamList == null ? 0 : (((MarbleScreenCaptureSettings) Item).CamList.Count > 0 ? 1 : 0)) != 0)
    {
      for (int index7 = 0; index7 <= ((MarbleScreenCaptureSettings) Item).CamList.Count - 1; ++index7)
      {
        ((MarbleScreenCaptureSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).isCamCalculated = false;
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase != null)
        {
          for (int index8 = 0; index8 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesG0.Count - 1; ++index8)
          {
            Entity refEntities = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesG0[index8];
            buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities);
          }
          for (int index9 = 0; index9 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesG1.Count - 1; ++index9)
          {
            Entity refEntities = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesG1[index9];
            buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities);
          }
          for (int index10 = 0; index10 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesLeave.Count - 1; ++index10)
          {
            Entity refEntities = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesLeave[index10];
            buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities);
          }
          for (int index11 = 0; index11 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesPlunge.Count - 1; ++index11)
          {
            Entity refEntities = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesPlunge[index11];
            buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities);
          }
          for (int index12 = 0; index12 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesLeadIn.Count - 1; ++index12)
          {
            Entity refEntities = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesLeadIn[index12];
            buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities);
          }
          for (int index13 = 0; index13 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesLeadOut.Count - 1; ++index13)
          {
            Entity refEntities = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).CamBase.EntitiesLeadOut[index13];
            buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities);
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).WireEntities != null)
        {
          for (int index14 = 0; index14 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).WireEntities.Count - 1; ++index14)
          {
            for (int index15 = 0; index15 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).WireEntities[index14].Count - 1; ++index15)
            {
              buEntity refEntities = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).WireEntities[index14][index15];
              buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities);
            }
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).EntityList != null)
          buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref ((\u0084.\u0001) ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).EntityList).Entities);
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).WireAuxEntities != null)
        {
          for (int index16 = 0; index16 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).WireAuxEntities.Count - 1; ++index16)
          {
            for (int index17 = 0; index17 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).WireAuxEntities[index16].Count - 1; ++index17)
            {
              buEntity refEntities = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).WireAuxEntities[index16][index17];
              buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities);
            }
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).ConcaveEntities != null)
        {
          for (int index18 = 0; index18 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).ConcaveEntities.Count - 1; ++index18)
          {
            for (int index19 = 0; index19 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).ConcaveEntities[index18].Count - 1; ++index19)
            {
              buEntity refEntities = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).ConcaveEntities[index18][index19];
              buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities);
            }
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).ConvexEntities != null)
        {
          for (int index20 = 0; index20 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).ConvexEntities.Count - 1; ++index20)
          {
            for (int index21 = 0; index21 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).ConvexEntities[index20].Count - 1; ++index21)
            {
              buEntity refEntities = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).ConvexEntities[index20][index21];
              buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities);
            }
          }
        }
        if (((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).DrillEntities != null)
        {
          for (int index22 = 0; index22 <= ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).DrillEntities.Count - 1; ++index22)
          {
            buEntity drillEntity = ((MarbleMachineOptionsSettings) ((MarbleScreenCaptureSettings) Item).CamList[index7]).DrillEntities[index22];
            buCall.\u0001.Scale(pointBase, RatioX, RatioY, 1.0, ref drillEntity);
          }
        }
      }
    }
    ((marbleMaterialPars) this).ItemSizeCalculation(ref Item);
  }

  public void ExtendItem(
    ref MarbleItem refItem,
    int EntityIndex,
    int EntitySubIndex,
    int EdgeIndex,
    Point3D pntExtend,
    double ExtendLength)
  {
    // ISSUE: unable to decompile the method.
  }

  public void BreakItem(
    ref MarbleItem refItem,
    int EntityIndex,
    int EntitySubIndex,
    int EdgeID,
    int CamID,
    Point3D pntBreak,
    double BreakLength,
    MarbleBreakType BreakType)
  {
    // ISSUE: unable to decompile the method.
  }
}
