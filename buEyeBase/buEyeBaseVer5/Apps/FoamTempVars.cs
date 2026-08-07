// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.FoamTempVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamTempVars
{
  public MaterialBase5 Material;
  public List<Block> BlockList;
  public List<Entity> EntityList;
  public List<buEntity> calcEntities;
  public List<Entity> AuxEntityList;
  public static byte f003C3D;
  public double XPos;
  public double YPos;
  public double ZPos;
  public double BendPos;

  public FoamTempVars(Router3AXCAM data)
  {
    ((FoamPatternInfo) this).CamName = "";
    ((FoamPatternInfo) this).isError = false;
    ((FoamPatternInfo) this).Enable = true;
    ((FoamPatternInfo) this).MinPoint = new Point3D();
    ((FoamPatternInfo) this).MaxPoint = new Point3D();
    ((FoamSettings) this).planeName = planeBoxNames.Top;
    ((FoamSettings) this).CamData = new camTp();
    ((FoamSettings) this).Tool = (ToolBase5) new ToolGeometry5();
    ((FoamSettings) this).CamPars = new camParameters5();
    ((FoamSettings) this).CamEntities = new List<buEntity>();
    ((FoamSettings) this).entitiesPlane = (Router3AXCamPlane) null;
    ((FoamSettings) this).camMode = CamMode.WireFrame;
    ((FoamSettings) this).camWireframeType = CamWireFrameType.Contour;
    ((FoamSettings) this).camMeshType = CamTriangularMeshType.ParallelCuts;
    ((FoamSettings) this).camMesh5AXType = CamTriangularMesh5AxType.ParallelCuts;
    ((FoamSettings) this).camSurfType = CamSurfaceType.SurfaceParalel;
    ((FoamSettings) this).camDrillType = CamDrillType.Point;
    ((FoamSettings) this).Purpose = Router3AXLayerPurpose.None;
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
    ((FoamSettings) this).CamPars = (camParameters5) new camRuntime5(((FoamSettings) data).CamPars);
    buRadialDim.Copy(((FoamSettings) data).CamEntities, ref ((FoamSettings) this).CamEntities);
    ((FoamSettings) this).CamData = new camTp(((FoamSettings) data).CamData);
    if (((FoamSettings) data).entitiesPlane == null)
      return;
    ((FoamSettings) this).entitiesPlane = (Router3AXCamPlane) new OperationSizeCalcArgs(((FoamSettings) data).entitiesPlane);
  }

  public static void Decode(List<string> AL, ref FoamBlock Item)
  {
  }
}
