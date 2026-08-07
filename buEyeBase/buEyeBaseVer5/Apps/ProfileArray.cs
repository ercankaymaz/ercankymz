// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileArray
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buCore;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileArray : buSerilization5
{
  public camParameters5 CamParMilling;
  public camParameters5 CamParNotch;
  public double ExternalDepth;
  public double ExtraDepth;
  public double IncrementalDistance;
  public double ManuelZVal;
  public double SelectedPlaneLength;
  public bool ExtraDepthEnable;

  public void TotalWidthOfProfile(ref ProfileItem Item, ref int cntProfile)
  {
    cntProfile = 0;
    if (((MarbleJob) ((ProfileSettings) Item).MultiplyProfile).ProfileMultiplyEnable)
      cntProfile = ((MarbleJob) ((ProfileSettings) Item).MultiplyProfile).ProfileMultiplyCount - 1;
    if (cntProfile < 0)
      cntProfile = 0;
    ((ProfileSettings) Item).TotalWidth = ((ProfileSettings) Item).Width;
    if (cntProfile <= 0)
      return;
    ((ProfileSettings) Item).TotalWidth = ((ProfileSettings) Item).Width + (((ProfileSettings) Item).Width + ((MarbleJob) ((ProfileSettings) Item).MultiplyProfile).ProfileMultiplySpace) * (double) (((MarbleJob) ((ProfileSettings) Item).MultiplyProfile).ProfileMultiplyCount - 1);
  }

  public void CreateProfileFromData(
    List<Entity> Entities,
    CreateProfileFromDataOptions Options,
    ref ProfileItem Profile)
  {
    List<buEntity> refEntities = new List<buEntity>();
    double leftAngle = ((ProfileSettings) Profile).LeftAngle;
    double rightAngle = ((ProfileSettings) Profile).RightAngle;
    Profile = (ProfileItem) new PanelCutRuntimeSettings();
    ((ProfileSettings) Profile).LeftAngle = leftAngle;
    ((ProfileSettings) Profile).RightAngle = rightAngle;
    Point3D MinPoint1 = new Point3D();
    Point3D MaxPoint1 = new Point3D();
    Point3D MidPoint1 = new Point3D();
    buCall.\u0001.BoxSizeCalculate(Entities, ref MinPoint1, ref MidPoint1, ref MaxPoint1);
    buCall.\u0001.Move(-MinPoint1.X, -MinPoint1.Y, -MinPoint1.Z, ref Entities);
    for (int index = 0; index <= Entities.Count - 1; ++index)
    {
      if (index == 312)
        ;
      if (Entities[index] is CompositeCurve)
      {
        buEntity copiedEntity = (buEntity) null;
        buAngularDim.Copy(Entities[index], ref copiedEntity);
        if (Entities[index] is ICurve)
        {
          ((AnalyseEntitiesSetting) ((CustomData) copiedEntity).Info).RefIndex = index;
          if (((ICurve) Entities[index]).Length() > 0.01)
            refEntities.Add(copiedEntity);
        }
      }
      else
      {
        buEntity copiedEntity = (buEntity) null;
        buAngularDim.Copy(Entities[index], ref copiedEntity);
        if (Entities[index] is ICurve)
        {
          ((AnalyseEntitiesSetting) ((CustomData) copiedEntity).Info).RefIndex = index;
          if (((ICurve) Entities[index]).Length() > 0.01)
            refEntities.Add(copiedEntity);
        }
      }
    }
    buMesh.ZPointToZero(ref refEntities);
    ((ProfileSettings) Profile).ItemName = ((MarbleRuntimeSettings) Options).Name;
    ((ProfileSettings) Profile).FileName = ((MarbleRuntimeSettings) Options).FileName;
    ((ProfileSettings) Profile).FileNameFull = ((MarbleRuntimeSettings) Options).FullName;
    ((ProfileSettings) Profile).Length = ((MarbleRuntimeSettings) Options).Length;
    ((ProfileSettings) Profile).colorProfile = ((MarbleRuntimeSettings) Options).color;
    ((ProfileSettings) Profile).Transparency = ((MarbleRuntimeSettings) Options).Transparency;
    List<Point3D> point3DList = new List<Point3D>();
    Point3D MinPoint2 = new Point3D();
    Point3D MidPoint2 = new Point3D();
    Point3D MaxPoint2 = new Point3D();
    buCall.\u0001.BoxSizeCalculate(refEntities, ref MinPoint2, ref MidPoint2, ref MaxPoint2);
    ((ProfileSettings) Profile).Width = Math.Round(MaxPoint2.X - MinPoint2.X, 3);
    ((ProfileSettings) Profile).Height = Math.Round(MaxPoint2.Y - MinPoint2.Y, 3);
    double scaleX = ((MarbleRuntimeSettings) Options).NeededWidth / ((ProfileSettings) Profile).Width;
    double scaleY = ((MarbleRuntimeSettings) Options).NeededHeight / ((ProfileSettings) Profile).Height;
    if (!buCompare.EQ(scaleX, 1.0, 0.001) | !buCompare.EQ(scaleY, 1.0, 0.001) && scaleX > 0.0 & scaleY > 0.0)
      buCall.\u0001.Scale(MinPoint2, scaleX, scaleY, 1.0, ref refEntities);
    if (((MarbleRuntimeSettings) Options).ConnectSmallGap)
      buCall.\u0001.ConnnectEntitiesGap(ref refEntities, ((MarbleRuntimeSettings) Options).GapConnection);
    double num1 = double.MaxValue;
    int index1 = -1;
    Point3D RefPoint = new Point3D();
    for (int index2 = 0; index2 <= refEntities.Count - 1; ++index2)
    {
      for (int index3 = 0; index3 <= ((CustomDataSurrogate) refEntities[index2]).Vertices.Count - 1; ++index3)
      {
        double num2 = Point3D.Distance(((CustomDataSurrogate) refEntities[index2]).Vertices[index3], new Point3D());
        if (num2 < num1)
        {
          num1 = num2;
          index1 = index2;
        }
      }
    }
    if (index1 >= 0)
      RefPoint = F_NotchEdit.ToPoint3D(((CustomData) refEntities[index1]).StartPoint);
    List<buEntitiesGroup> Groups = new List<buEntitiesGroup>();
    buCall.\u0001.FindEntitiesGroupFromEntities(RefPoint, refEntities, Plane.XY, ref Groups, ((MarbleRuntimeSettings) Options).SortResolituon, ((MarbleRuntimeSettings) Options).IntersectionRules);
    if (Groups.Count == 0)
      return;
    for (int index4 = 0; index4 <= Groups.Count - 1; ++index4)
    {
      ProfileDrawings profileDrawings = (ProfileDrawings) new MarbleItemOperations();
      if (((\u0084.\u0001) Groups[index4].Outside).Entities.Count > 0)
      {
        buRadialDim.Copy(((\u0084.\u0001) Groups[index4].Outside).Entities, ref ((MarbleJob) profileDrawings).OutterEntitites);
        buCall.\u0001.EntitiesToPointsWithCamDirection(((MarbleJob) profileDrawings).OutterEntitites, ref ((MarbleJob) profileDrawings).OutterPoints);
        ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref ((MarbleJob) profileDrawings).OutterPoints);
      }
      if (Groups[index4].Inside.Count > 0)
      {
        for (int index5 = 0; index5 <= Groups[index4].Inside.Count - 1; ++index5)
        {
          List<buEntity> copiedEntities = new List<buEntity>();
          List<Point3D> Points = new List<Point3D>();
          buRadialDim.Copy(((\u0084.\u0001) Groups[index4].Inside[index5]).Entities, ref copiedEntities);
          buCall.\u0001.EntitiesToPointsWithCamDirection(copiedEntities, ref Points);
          ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref Points);
          ((MarbleJob) profileDrawings).InnerEntities.Add(copiedEntities);
          ((MarbleJob) profileDrawings).InnerPoints.Add(Points);
        }
      }
      ((ProfileSettings) Profile).Drawings.Add(profileDrawings);
    }
    ((MarbleJob) ((ProfileSettings) Profile).SupportBlock).SupportBlockZLength = ((MarbleRuntimeSettings) Options).Length;
    ((MarbleJob) ((ProfileSettings) Profile).SupportBlock).SupportBlockZWidth = ((MarbleRuntimeSettings) Options).SupportBlockZWidth;
    ((MarbleJob) ((ProfileSettings) Profile).SupportBlock).SupportBlockZHeight = ((MarbleRuntimeSettings) Options).SupportBlockZHeight;
    ((MarbleJob) ((ProfileSettings) Profile).SupportBlock).SupportBlockY1FrontLength = ((MarbleRuntimeSettings) Options).Length;
    ((MarbleJob) ((ProfileSettings) Profile).SupportBlock).SupportBlockY1FrontWidth = ((MarbleRuntimeSettings) Options).SupportBlockY1Width;
    ((MarbleJob) ((ProfileSettings) Profile).SupportBlock).SupportBlockY1FrontHeight = ((MarbleRuntimeSettings) Options).SupportBlockY1Height;
    ((MarbleJob) ((ProfileSettings) Profile).SupportBlock).SupportBlockY2BackLength = ((MarbleRuntimeSettings) Options).Length;
    ((MarbleJob) ((ProfileSettings) Profile).SupportBlock).SupportBlockY2BackWidth = ((MarbleRuntimeSettings) Options).SupportBlockY2Width;
    ((MarbleJob) ((ProfileSettings) Profile).SupportBlock).SupportBlockY2BackHeight = ((MarbleRuntimeSettings) Options).SupportBlockY2Height;
  }

  public void CreateProfile(
    ProfileItem Profile,
    Plane ProfilePlane,
    Point3D ProfileOffset,
    ref Entity entProfile)
  {
    Brep brep = new Region((IList<ICurve>) new ICurve[2]
    {
      (ICurve) CompositeCurve.CreateRectangle(ProfilePlane, ((ProfileSettings) Profile).Width, ((ProfileSettings) Profile).Height, true),
      (ICurve) CompositeCurve.CreateRectangle(ProfilePlane, ((ProfileSettings) Profile).Width - ((ProfileSettings) Profile).Thickness, ((ProfileSettings) Profile).Height - ((ProfileSettings) Profile).Thickness, true)
    }, ProfilePlane, false).ExtrudeAsBrep(((ProfileSettings) Profile).Length, 0.0, 0.0);
    brep.Color = ((ProfileSettings) Profile).Color;
    brep.ColorMethod = colorMethodType.byEntity;
    brep.Translate(ProfileOffset.X, ProfileOffset.Y, ProfileOffset.Z);
    brep.Regen(0.01);
    entProfile = (Entity) brep;
  }
}
