// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCamPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCamPars : buSerilization5
{
  public double CutLengthHorizontal;
  public double CutLengthVertical;
  public double CutLengthHorVerHorizontal;
  public double CutLengthHorVerVertical;
  public double HorizontalWidth;
  public double HorizontalCount;
  public double HorizontalStartAngle;
  public double HorizontalEndAngle;
  public double VerticalWidth;
  public double VerticalCount;
  public double VerticalStartAngle;
  public double VerticalEndAngle;
  public double SingleCutLength;
  public double SingleCutAAngle;
  public double SliceWidth;
  public double SliceLength;
  public int SliceCount;
  public double SliceStartAngle;
  public double SliceEndAngle;
  public HorizontalVertical SliceType;
  public double ScaleWidth;
  public double ScaleHeight;
  public double ScaleDepth;
  public double ScaleLength;
  public double ScaleBaseHeight;
  public bool ScaleKeepRatio;
  public double SlatWidth;
  public double SlatStartAngle;
  public double SlatEndAngle;
  public double SlatOffset;
  public bool SlatAddAngleSelectedEdge;
  public double CollapseDepth;
  public double CollapseOffset;
  public double CollapseStep;
  public OutsideInsideType CollapseDirection;
  public MarbleToolType CollapseToolType;
  public bool CollapseEnable;
  public double BorderLeft;
  public double BorderRight;
  public double BorderTop;
  public double BorderBottom;
  public bool BorderEnable;
  public double ArrayXCount;
  public double ArrayXDistance;
  public double ArrayYCount;
  public double ArrayYDistance;
  public double CopyXDistance;
  public double CopyYDistance;
  public double CopyXCount;
  public double CopyYCount;
  public MarbleCopyType CopyType;
  public MirrorAxisXYType MirrorType;
  public double MirrorDistance;
  public bool MirrorDeleteOriginale;
  public double AlignMagnetOffset;
  public double AlignMoveValue;
  public double AlignSideOffset;
  public double ExtendLength;
  public double VacuumMove;
  public double BreakDistance;
  public MarbleBreakType BreakType;
  public double OffsetDistance;
  public double Shape3DHeight;
  public double Shape3DDepth;
  public double Shape3DOffsetX;
  public double Shape3DOffsetY;
  public double Shape3DInOffsetX;
  public double Shape3DInOffsetY;
  public planeNames Shape3DPlane;
  public double BasicDrawAngle;
  public double BasicDrawLength;
  public double BasicDrawDx;
  public double BasicDrawDy;
  public double BasicDrawWidth;
  public double BasicDrawHeight;
  public double BasicDrawDiameter;
  public int BasicDrawLineMethod;
  public double ShapeRectangleWidth;
  public double ShapeRectangleHeight;
  public double ShapeRectangleTopAngle;
  public double ShapeRectangleBottomAngle;
  public double ShapeRectangleLeftAngle;
  public double ShapeRectangleRightAngle;
  public double ShapeRectangleCrossWidth;
  public double ShapeRectangleCrossHeight;
  public double ShapeRectangleCrossTopAngle;
  public double ShapeRectangleCrossBottomAngle;
  public double ShapeRectangleCrossLeftAngle;
  public double ShapeRectangleCrossRightAngle;
  public double ShapeRectangleRoundWidth;
  public double ShapeRectangleRoundHeight;
  public double ShapeRectangleRoundRadius;
  public double ShapeRectangleRoundAngle;
  public double ShapeRectangleRoundTopAngle;
  public double ShapeRectangleRoundBottomAngle;
  public double ShapeRectangleRoundLeftAngle;
  public double ShapeRectangleRoundRightAngle;
  public double ShapeRectangleChamferWidth;
  public double ShapeRectangleChamferHeight;
  public double ShapeRectangleChamferLength;
  public double ShapeRectangleChamferAngle;
  public double ShapeRectangleChamferTopAngle;
  public double ShapeRectangleChamferBottomAngle;
  public double ShapeRectangleChamferLeftAngle;
  public double ShapeRectangleChamferRightAngle;
  public double ShapeCircleDiameter;
  public double ShapeCircleAngle;
  public double ShapeEllipseWidth;
  public double ShapeEllipseHeight;
  public double ShapeEllipseAngle;
  public double ShapePolygonRadius;
  public int ShapePolygonSide;
  public double ShapePolygonAngle;
  public double ShapeTriangleWidth;
  public double ShapeTriangleHeight;
  public double ShapeTriangleLeftAngle;
  public double ShapeTriangleBottomAngle;

  public marbleCamPars(ProfileDepth data)
  {
    ((MarbleRuntimeSettings) this).Distance = 100.0;
    ((MarbleRuntimeSettings) this).CutSpace = 2.0;
    ((MarbleRuntimeSettings) this).Count = 1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
    return $"Distance : {((MarbleRuntimeSettings) this).Distance.ToString()}  , Count: {((MarbleRuntimeSettings) this).Count.ToString()}";
  }

  public abstract void m001ECB();

  public marbleCamPars()
  {
    ((MarbleRuntimeSettings) this).OnlyDrawing = false;
    ((MarbleRuntimeSettings) this).AutoToolFound = false;
    ((MarbleRuntimeSettings) this).ToolAuxName = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public marbleCamPars(ProfileOnlineOpOptions data)
  {
    ((MarbleRuntimeSettings) this).OnlyDrawing = false;
    ((MarbleRuntimeSettings) this).AutoToolFound = false;
    ((MarbleRuntimeSettings) this).ToolAuxName = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
}
