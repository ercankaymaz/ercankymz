// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.FoamActiveBlock
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamActiveBlock : buSerilization5
{
  public string TextureName;
  public Color colorFoam;
  public int Transparency;

  public actionTypeBU CamMeshTypeToAction(CamTriangularMeshType MeshType)
  {
    actionTypeBU action;
    switch (MeshType)
    {
      case CamTriangularMeshType.Rough:
        action = actionTypeBU.routerCamMesh3DRough;
        break;
      case CamTriangularMeshType.ParallelCuts:
        action = actionTypeBU.routerCamMesh3DParalelCut;
        break;
      case CamTriangularMeshType.ConstantZ:
        action = actionTypeBU.routerCamMesh3DConstantZ;
        break;
      case CamTriangularMeshType.Flatlands:
        action = actionTypeBU.routerCamMesh3DFlatLand;
        break;
      case CamTriangularMeshType.Pencil:
        action = actionTypeBU.routerCamMesh3DPencil;
        break;
      default:
        action = actionTypeBU.None;
        break;
    }
    return action;
  }

  public actionTypeBU CamMeshTypeToAction(CamTriangularMesh5AxType MeshType)
  {
    actionTypeBU action;
    switch (MeshType)
    {
      case CamTriangularMesh5AxType.Rough:
        action = actionTypeBU.routerCamMesh5AXRough;
        break;
      case CamTriangularMesh5AxType.ParallelCuts:
        action = actionTypeBU.routerCamMesh5AXParalelCut;
        break;
      case CamTriangularMesh5AxType.ConstantZ:
        action = actionTypeBU.routerCamMesh5AXConstantZ;
        break;
      default:
        action = actionTypeBU.None;
        break;
    }
    return action;
  }

  public actionTypeBU CamSurfaceTypeToAction(CamSurfaceType MeshType)
  {
    return MeshType != CamSurfaceType.SurfaceParalel ? actionTypeBU.None : actionTypeBU.routerCamSurface5AXParalelCut;
  }
}
