// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleMachineOptionsSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

public class MarbleMachineOptionsSettings : buSerilization5
{
  public int indexCollapse;
  public int indexItem;
  public int indexCam;
  public int AxesNumber;
  public MarbleToolType ToolType;
  public MarbleCamType CamMarbleType;
  public MarbleCamMode CamMode;
  public CamWireFrameType WireType;
  public CamTriangularMeshType MeshType;
  public CamType CamType;
  public ClockDirectionType BaseClockDir;
  public InOutCenterType Direction;
  public planeNames CamPlane;
  public ObjectSize3D SizeCamItem;
  public ToolBase5 ToolSelected;
  public camTp CamBase;
  public camParameters5 setCam;
  public buEntityList EntityList;
  public List<buEntity> CamEntities;
  public List<List<buEntity>> WireAuxEntities;
  public List<List<buEntity>> WireEntities;
  public List<List<buEntity>> ConcaveEntities;
  public List<List<buEntity>> ConvexEntities;
  public List<buEntity> DrillEntities;
  public List<Entity> SolidEntities;
  public List<buEntity> DrawEntities;
  public static byte f00488D;
  public Point3D StartPoint;
  public Point3D EndPoint;
  public Entity VacuumCutDrawEntity;
  public buEntity VacuumCutEntity;
  public double OffsetX;
  public double OffsetY;
  public double MoveX;
  public double MoveY;
  public double RotateC;
  public int VacuumID;
  public bool Selected;
  public HorizontalVertical Direction;

  public MarbleMachineOptionsSettings(
    double smallChangeGap,
    double bigChangeGap,
    bool usebig,
    double leftdis,
    double rightdis)
  {
    ((MarbleRuntimeSettings) this).SmallChangeGap = 50.0;
    ((MarbleRuntimeSettings) this).BigChangeGap = 300.0;
    ((MarbleRuntimeSettings) this).LeftDistance = 0.0;
    ((MarbleRuntimeSettings) this).RightDistance = 0.0;
    ((MarbleRuntimeSettings) this).UseBig = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((MarbleRuntimeSettings) this).SmallChangeGap = smallChangeGap;
    ((MarbleRuntimeSettings) this).BigChangeGap = bigChangeGap;
    ((MarbleRuntimeSettings) this).UseBig = usebig;
    ((MarbleRuntimeSettings) this).LeftDistance = leftdis;
    ((MarbleRuntimeSettings) this).RightDistance = rightdis;
  }
}
