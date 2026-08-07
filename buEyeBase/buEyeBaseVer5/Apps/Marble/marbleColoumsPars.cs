// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleColoumsPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleColoumsPars : buSerilization5
{
  public bool DrawLaserPointer;
  public bool DrawWaterjet;
  public bool DrawAllTool;
  public bool DrawSawToolForMillingHeadOperation;
  public bool MovePartFromKinematicDistances;
  public double SimACAxesZDistance;
  public double SimDrawCommonOffsetX;
  public double SimDrawCommonOffsetY;
  public double SimDrawCommonOffsetZ;

  [CompilerGenerated]
  [SpecialName]
  public void add_MarbleCalcCommandSend(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((MarbleRuntimeSettings) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((MarbleRuntimeSettings) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_MarbleCalcCommandSend(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((MarbleRuntimeSettings) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((MarbleRuntimeSettings) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void GetSurfaceData(MarbleItem Item, ref List<List<buEntity>> calcEntities)
  {
    for (int index1 = 0; index1 <= ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities.Count - 1; ++index1)
    {
      List<buEntity> buEntityList = new List<buEntity>();
      List<Point3D> Points = new List<Point3D>();
      EntitiesResolution entitiesResolution = new EntitiesResolution()
      {
        ArcResolution = new EntityResolution(((MarbleCamType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).ReadSurfaceParameter).SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
        CircleResolution = new EntityResolution(((MarbleCamType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).ReadSurfaceParameter).SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
        CurveResolution = new EntityResolution(((MarbleCamType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).ReadSurfaceParameter).SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
        EllipseResolution = new EntityResolution(((MarbleCamType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).ReadSurfaceParameter).SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
        LineResolution = new EntityResolution(((MarbleCamType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).ReadSurfaceParameter).SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
        OtherResolution = new EntityResolution(((MarbleCamType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).ReadSurfaceParameter).SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
        PolylineResolution = new EntityResolution(((MarbleCamType) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Settings).ReadSurfaceParameter).SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength)
      };
      buCall.\u0001.EntitiesToPointsWithCamDirection(((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities[index1], 0.01, ref Points);
      Points[Points.Count - 1] = new Point3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, 5.0);
      for (int index2 = 0; index2 <= Points.Count - 1; ++index2)
      {
        double num = 0.0;
        int index3 = Convert.ToInt32(Points[index2].X);
        int index4 = Convert.ToInt32(Points[index2].Y);
        if (index3 < 0)
          index3 = 0;
        if (index4 < 0)
          index4 = 0;
        if (index4 >= 0 & index4 <= MarbleProgramSettings.pntTeachGrids.Count - 1 && index3 >= 0 & index3 <= MarbleProgramSettings.pntTeachGrids[index4].Count - 1)
          num = MarbleProgramSettings.pntTeachGrids[index4][index3].Z;
        Points[index2] = new Point3D(Points[index2].X, Points[index2].Y, Points[index2].Z + num);
      }
      buLinearPath buLinearPath = (buLinearPath) new buShape(Points);
      ((CustomDataSurrogate) buLinearPath).Orientation = new OrientationAngle(((CustomDataSurrogate) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).WireEntities[index1][0]).Orientation);
      buEntityList.Add((buEntity) buLinearPath);
      calcEntities.Add(buEntityList);
    }
  }

  public void KinematicCalc(
    KinematicBase5 refKinematic,
    ToolBase5 Tool,
    ref KinematicBase5 Kinematic)
  {
    double num = ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness / 2.0;
    if (((ToolGeometry5) Tool).Geometry.SocketThickness > 0.0 & ((ToolGeometry5) Tool).Geometry.SocketThickness > ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness)
      num -= (((ToolGeometry5) Tool).Geometry.SocketThickness - ((ToolDisplay5) ((ToolGeometry5) Tool).Geometry).Thickness) / 2.0;
    Kinematic = (KinematicBase5) new OsnapPoint(refKinematic);
    ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Y = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Y + ((ToolGeometry5) Tool).Geometry.ShoulderThickness + num;
    ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y = ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Y + ((ToolGeometry5) Tool).Geometry.ShoulderThickness + num;
  }

  public void CalculateMarbleWireFrameWithSaw(
    KinematicBase5 refKinematic,
    ToolBase5 Tool,
    MarbleJob Job,
    int indexBase,
    bool isLast,
    TpPnt9D LastP9,
    ref MarbleItem Item,
    ref MarbleItemCam marbleCam)
  {
    // ISSUE: unable to decompile the method.
  }
}
