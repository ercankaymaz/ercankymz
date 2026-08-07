// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileMirror
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileMirror : buSerilization5
{
  public bool EachLayer;
  public bool ManuelZEnable;
  public bool XRefFromProfileEnd;
  public planeNames selectedPlaneName;
  public SelectedPlaneInfo selectedPlaneInfo;

  public void CreateProfileFromDrawing(
    ref ProfileItem Profile,
    Plane ProfilePlane,
    Point3D ProfileOffset,
    bool isNewProfile,
    ProfileSettings Settings,
    ProfileVisualSettings VisualSettings,
    double ProfileRefEntityThickness = 10.0,
    double MinPointFilterLength = 0.0)
  {
    try
    {
      for (int index1 = 0; index1 <= ((ProfileSettings) Profile).Drawings.Count - 1; ++index1)
      {
        List<ICurve> curveList1 = new List<ICurve>();
        List<ICurve> curveList2 = new List<ICurve>();
        List<Point3D> point3DList = new List<Point3D>();
        if (isNewProfile)
        {
          List<Point3D> copiedPoint = new List<Point3D>();
          buVector5.Copy(((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).OutterPoints, ref copiedPoint);
          ((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).OutterPoints.Clear();
          for (int index2 = 0; index2 <= copiedPoint.Count - 1; ++index2)
          {
            double x = copiedPoint[index2].X;
            double y = copiedPoint[index2].Y;
            ((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).OutterPoints.Add(new Point3D(ProfileOffset.X, x + ProfileOffset.Y, y + ProfileOffset.Z));
            point3DList.Add(new Point3D(ProfileOffset.X, x + ProfileOffset.Y, y + ProfileOffset.Z));
          }
          ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref point3DList);
          if (MinPointFilterLength > 0.0)
            buCall.\u0001.RemoveSmallLengthFromPoints(MinPointFilterLength, ref point3DList);
        }
        else
          buVector5.Copy(((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).OutterPoints, ref point3DList);
        curveList1.Add((ICurve) new LinearPath((ICollection<Point3D>) point3DList));
        if (isNewProfile)
        {
          List<List<Point3D>> copiedPoint = new List<List<Point3D>>();
          buVector5.Copy(((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).InnerPoints, ref copiedPoint);
          ((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).InnerPoints = new List<List<Point3D>>();
          for (int index3 = 0; index3 <= copiedPoint.Count - 1; ++index3)
          {
            point3DList = new List<Point3D>();
            List<Point3D> points = new List<Point3D>();
            for (int index4 = 0; index4 <= copiedPoint[index3].Count - 1; ++index4)
            {
              double x = copiedPoint[index3][index4].X;
              double y = copiedPoint[index3][index4].Y;
              point3DList.Add(new Point3D(ProfileOffset.X, x + ProfileOffset.Y, y + ProfileOffset.Z));
              points.Add(new Point3D(ProfileOffset.X, x + ProfileOffset.Y, y + ProfileOffset.Z));
            }
            ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref point3DList);
            if (MinPointFilterLength > 0.0)
              buCall.\u0001.RemoveSmallLengthFromPoints(MinPointFilterLength, ref point3DList);
            bool flag = Utility.IsOrientedClockwise<Point3D>((IList<Point3D>) point3DList);
            point3DList.Reverse();
            if (!flag)
              ;
            ((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).InnerPoints.Add(point3DList);
            curveList2.Add((ICurve) new LinearPath((ICollection<Point3D>) points));
          }
        }
        else
        {
          for (int index5 = 0; index5 <= ((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).InnerPoints.Count - 1; ++index5)
          {
            point3DList = new List<Point3D>();
            buVector5.Copy(((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).InnerPoints[index5], ref point3DList);
            curveList2.Add((ICurve) new LinearPath((ICollection<Point3D>) point3DList));
          }
        }
        if (curveList1.Count > 0)
        {
          devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region((IList<ICurve>) new ICurve[1]
          {
            (ICurve) new CompositeCurve((IEnumerable<ICurve>) curveList1)
          }, ProfilePlane, false);
          for (int index6 = 0; index6 <= curveList2.Count - 1; ++index6)
            region.ContourList.Add(curveList2[index6]);
          double num = 0.0;
          if (((ProfileSettings) Profile).RightAngle > 0.0)
            ;
          Brep brep = region.ExtrudeAsBrep(((ProfileSettings) Profile).Length + num, 0.0, 0.0);
          brep.Color = ((ProfileSettings) Profile).Color;
          brep.ColorMethod = colorMethodType.byEntity;
          if (((ProfileSettings) Profile).XReferanceLocation == LeftRightType.Left)
          {
            Mesh box1 = Mesh.CreateBox(ProfileRefEntityThickness, ((ProfileSettings) Profile).Width, ((ProfileSettings) Profile).Height, Mesh.natureType.RichSmooth);
            box1.Translate(-ProfileRefEntityThickness, ProfileOffset.Y);
            box1.Color = Color.FromArgb(((MarbleTempVars) VisualSettings).ProfileRefeanceTranparentLeft, ((MarbleTempVars) VisualSettings).ProfileRefeanceColor);
            box1.ColorMethod = colorMethodType.byEntity;
            CustomData customData1 = (CustomData) new ClipperOffset(entityTypeDefination.Lean);
            box1.EntityData = (object) customData1;
            box1.Selectable = false;
            ((ProfileSettings) Profile).ProfileReferanceEntity = (Entity) box1;
            if (((MarbleItemOperations) Settings).ShowBottomReferanceEntity)
            {
              Mesh box2 = Mesh.CreateBox(((ProfileSettings) Profile).Length + ProfileRefEntityThickness, ((ProfileSettings) Profile).Width, ProfileRefEntityThickness / 2.0, Mesh.natureType.RichSmooth);
              box2.Translate(-ProfileRefEntityThickness, ProfileOffset.Y, -ProfileRefEntityThickness / 2.0);
              box2.Color = Color.FromArgb(((MarbleTempVars) VisualSettings).ProfileRefeanceTranparentBottom, ((MarbleTempVars) VisualSettings).ProfileRefeanceColor);
              box2.ColorMethod = colorMethodType.byEntity;
              CustomData customData2 = (CustomData) new ClipperOffset(entityTypeDefination.Lean);
              box2.EntityData = (object) customData2;
              box2.Selectable = false;
              ((ProfileSettings) Profile).ProfileReferanceBottomEntity = (Entity) box2;
            }
            if (((MarbleItemOperations) Settings).ShowBackReferanceEntity)
            {
              Mesh box3 = Mesh.CreateBox(((ProfileSettings) Profile).Length + ProfileRefEntityThickness, ProfileRefEntityThickness / 2.0, ((ProfileSettings) Profile).Height, Mesh.natureType.RichSmooth);
              box3.Translate(-ProfileRefEntityThickness, 0.0);
              box3.Color = Color.FromArgb(((MarbleTempVars) VisualSettings).ProfileRefeanceTranparentBack, ((MarbleTempVars) VisualSettings).ProfileRefeanceColor);
              box3.ColorMethod = colorMethodType.byEntity;
              CustomData customData3 = (CustomData) new ClipperOffset(entityTypeDefination.Lean);
              box3.EntityData = (object) customData3;
              box3.Selectable = false;
              ((ProfileSettings) Profile).ProfileReferanceBackEntity = (Entity) box3;
            }
            if (((MarbleItemEntities) Settings).RemoveProfileAngle)
            {
              if (((ProfileSettings) Profile).LeftAngle > 0.0)
              {
                double height = ((ProfileSettings) Profile).Height / Math.Cos(buString5.DegreeToRadian(((ProfileSettings) Profile).LeftAngle));
                devDept.Eyeshot.Entities.Region.CreateRectangle(Plane.YZ, ((ProfileSettings) Profile).Width, height).Translate(0.0, ProfileOffset.Y);
              }
              if (((ProfileSettings) Profile).LeftAngle < 0.0)
              {
                double height = ((ProfileSettings) Profile).Height / Math.Cos(buString5.DegreeToRadian(((ProfileSettings) Profile).LeftAngle));
                devDept.Eyeshot.Entities.Region.CreateRectangle(Plane.YZ, ((ProfileSettings) Profile).Width, height).Translate(0.0, ProfileOffset.Y, ((ProfileSettings) Profile).Height - height);
              }
              if (((ProfileSettings) Profile).RightAngle < 0.0)
              {
                double height = ((ProfileSettings) Profile).Height / Math.Cos(buString5.DegreeToRadian(((ProfileSettings) Profile).RightAngle));
                devDept.Eyeshot.Entities.Region.CreateRectangle(Plane.YZ, ((ProfileSettings) Profile).Width, height).Translate(((ProfileSettings) Profile).Length, ProfileOffset.Y);
              }
              if (((ProfileSettings) Profile).RightAngle > 0.0)
              {
                double height = ((ProfileSettings) Profile).Height / Math.Cos(buString5.DegreeToRadian(((ProfileSettings) Profile).RightAngle));
                devDept.Eyeshot.Entities.Region.CreateRectangle(Plane.YZ, ((ProfileSettings) Profile).Width, height).Translate(((ProfileSettings) Profile).Length, ProfileOffset.Y, ((ProfileSettings) Profile).Height - height);
              }
            }
          }
          if (((ProfileSettings) Profile).XReferanceLocation == LeftRightType.Right)
          {
            Mesh box4 = Mesh.CreateBox(ProfileRefEntityThickness, ((ProfileSettings) Profile).Width, ((ProfileSettings) Profile).Height, Mesh.natureType.RichSmooth);
            box4.Translate(((ProfileSettings) Profile).Length, ProfileOffset.Y);
            box4.Color = Color.FromArgb(((MarbleTempVars) VisualSettings).ProfileRefeanceTranparentLeft, ((MarbleTempVars) VisualSettings).ProfileRefeanceColor);
            box4.ColorMethod = colorMethodType.byEntity;
            CustomData customData4 = (CustomData) new ClipperOffset(entityTypeDefination.Lean);
            box4.EntityData = (object) customData4;
            box4.Selectable = false;
            ((ProfileSettings) Profile).ProfileReferanceEntity = (Entity) box4;
            if (((MarbleItemOperations) Settings).ShowBottomReferanceEntity)
            {
              Mesh box5 = Mesh.CreateBox(((ProfileSettings) Profile).Length + ProfileRefEntityThickness, ((ProfileSettings) Profile).Width, ProfileRefEntityThickness / 2.0, Mesh.natureType.RichSmooth);
              box5.Translate(0.0, ProfileOffset.Y, -ProfileRefEntityThickness / 2.0);
              box5.Color = Color.FromArgb(((MarbleTempVars) VisualSettings).ProfileRefeanceTranparentBottom, ((MarbleTempVars) VisualSettings).ProfileRefeanceColor);
              box5.ColorMethod = colorMethodType.byEntity;
              CustomData customData5 = (CustomData) new ClipperOffset(entityTypeDefination.Lean);
              box5.EntityData = (object) customData5;
              box5.Selectable = false;
              ((ProfileSettings) Profile).ProfileReferanceBottomEntity = (Entity) box5;
            }
            if (((MarbleItemOperations) Settings).ShowBackReferanceEntity)
            {
              Mesh box6 = Mesh.CreateBox(((ProfileSettings) Profile).Length + ProfileRefEntityThickness, ProfileRefEntityThickness / 2.0, ((ProfileSettings) Profile).Height, Mesh.natureType.RichSmooth);
              box6.Translate(0.0, 0.0);
              box6.Color = Color.FromArgb(((MarbleTempVars) VisualSettings).ProfileRefeanceTranparentBack, ((MarbleTempVars) VisualSettings).ProfileRefeanceColor);
              box6.ColorMethod = colorMethodType.byEntity;
              CustomData customData6 = (CustomData) new ClipperOffset(entityTypeDefination.Lean);
              box6.EntityData = (object) customData6;
              box6.Selectable = false;
              ((ProfileSettings) Profile).ProfileReferanceBackEntity = (Entity) box6;
            }
          }
          brep.Regen(0.01);
          brep.Color = Color.FromArgb(((ProfileSettings) Profile).Transparency, ((ProfileSettings) Profile).colorProfile);
          CustomData customData = (CustomData) new ClipperOffset(entityTypeDefination.Profile);
          brep.EntityData = (object) customData;
          // ISSUE: reference to a compiler-generated field
          ((buMarbleCalc.\u0001) ((ProfileSettings) Profile).Drawings[index1]).SolidEntity = (Entity) brep;
        }
      }
      double height1 = ((ProfileSettings) Profile).Height / Math.Cos(buString5.DegreeToRadian(((ProfileSettings) Profile).LeftAngle));
      if (((ProfileSettings) Profile).LeftAngle > 0.0)
      {
        Mesh mesh = devDept.Eyeshot.Entities.Region.CreateRectangle(Plane.YZ, ((ProfileSettings) Profile).Width, height1).ExtrudeAsMesh(ProfileRefEntityThickness * 0.1, 0.1, Mesh.natureType.RichSmooth);
        mesh.Rotate(buString5.DegreeToRadian(((ProfileSettings) Profile).LeftAngle), Vector3D.AxisY);
        mesh.Regen(0.01);
        mesh.Translate(-mesh.BoxMin.X, ProfileOffset.Y);
        CustomData customData = (CustomData) new ClipperOffset(entityTypeDefination.Angle);
        mesh.EntityData = (object) customData;
      }
      else if (((ProfileSettings) Profile).LeftAngle < 0.0)
      {
        Mesh mesh = devDept.Eyeshot.Entities.Region.CreateRectangle(Plane.YZ, ((ProfileSettings) Profile).Width + 1.0, height1).ExtrudeAsMesh(ProfileRefEntityThickness * 0.1, 0.1, Mesh.natureType.RichSmooth);
        mesh.Rotate(buString5.DegreeToRadian(((ProfileSettings) Profile).LeftAngle), Vector3D.AxisY);
        mesh.Regen(0.01);
        mesh.Translate(-mesh.BoxMin.X, ProfileOffset.Y);
        CustomData customData = (CustomData) new ClipperOffset(entityTypeDefination.Angle);
        mesh.EntityData = (object) customData;
      }
      if (((ProfileSettings) Profile).RightAngle < 0.0)
      {
        double height2 = ((ProfileSettings) Profile).Height / Math.Cos(buString5.DegreeToRadian(((ProfileSettings) Profile).RightAngle));
        Mesh mesh = devDept.Eyeshot.Entities.Region.CreateRectangle(Plane.YZ, ((ProfileSettings) Profile).Width, height2).ExtrudeAsMesh(ProfileRefEntityThickness * 0.1, 0.1, Mesh.natureType.RichSmooth);
        mesh.Rotate(buString5.DegreeToRadian(((ProfileSettings) Profile).RightAngle), Vector3D.AxisY);
        mesh.Regen(0.01);
        mesh.Translate(((ProfileSettings) Profile).Length - mesh.BoxMax.X, ProfileOffset.Y);
        CustomData customData = (CustomData) new ClipperOffset(entityTypeDefination.Angle);
        mesh.EntityData = (object) customData;
        ((ProfileSettings) Profile).RightAngleEntity = (Entity) mesh;
      }
      if (((ProfileSettings) Profile).RightAngle <= 0.0)
        return;
      double height3 = ((ProfileSettings) Profile).Height / Math.Cos(buString5.DegreeToRadian(((ProfileSettings) Profile).RightAngle));
      Mesh mesh1 = devDept.Eyeshot.Entities.Region.CreateRectangle(Plane.YZ, ((ProfileSettings) Profile).Width, height3).ExtrudeAsMesh(ProfileRefEntityThickness * 0.1, 0.1, Mesh.natureType.RichSmooth);
      mesh1.Rotate(buString5.DegreeToRadian(((ProfileSettings) Profile).RightAngle), Vector3D.AxisY);
      mesh1.Regen(0.01);
      mesh1.Translate(((ProfileSettings) Profile).Length - mesh1.BoxMax.X, ProfileOffset.Y);
      CustomData customData7 = (CustomData) new ClipperOffset(entityTypeDefination.Angle);
      mesh1.EntityData = (object) customData7;
      ((ProfileSettings) Profile).RightAngleEntity = (Entity) mesh1;
    }
    catch (Exception ex)
    {
    }
  }

  public void BoxSizeProfile(
    ProfileItem Profile,
    ref Point3D MinPoint,
    ref Point3D MidPoint,
    ref Point3D MaxPoint)
  {
    List<Point3D> Points = new List<Point3D>();
    for (int index1 = 0; index1 <= ((ProfileSettings) Profile).Drawings.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).OutterPoints.Count - 1; ++index2)
        Points.Add(((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).OutterPoints[index2]);
    }
    buCall.\u0001.BoxSizeCalculate(Points, ref MinPoint, ref MidPoint, ref MaxPoint);
  }

  public void FindIntersectBetweenCenterLineAndSurface(
    ProfileItem Profile,
    planeNames PlaneNames,
    Point3D refPoint,
    ref List<Point3D> pntIntersect)
  {
    try
    {
      pntIntersect = new List<Point3D>();
      for (int index1 = 0; index1 <= ((ProfileSettings) Profile).Drawings.Count - 1; ++index1)
      {
        LinearPath linearPath = new LinearPath((ICollection<Point3D>) ((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).OutterPoints);
        Line C2 = (Line) null;
        if (PlaneNames == planeNames.Top | PlaneNames == planeNames.Bottom)
          C2 = new Line(new Point3D(0.0, refPoint.Y, -10000.0), new Point3D(0.0, refPoint.Y, 10000.0));
        else if (PlaneNames == planeNames.Back | PlaneNames == planeNames.Front)
          C2 = new Line(new Point3D(0.0, -10000.0, refPoint.Z), new Point3D(0.0, 10000.0, refPoint.Z));
        Point3D[] collection1 = linearPath.IntersectWith((ICurve) C2, 0.0, true);
        pntIntersect.AddRange((IEnumerable<Point3D>) collection1);
        for (int index2 = 0; index2 <= ((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).InnerPoints.Count - 1; ++index2)
        {
          Point3D[] collection2 = new LinearPath((ICollection<Point3D>) ((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).InnerPoints[index2]).IntersectWith((ICurve) C2, 0.0, true);
          pntIntersect.AddRange((IEnumerable<Point3D>) collection2);
        }
      }
    }
    catch (Exception ex)
    {
    }
  }
}
