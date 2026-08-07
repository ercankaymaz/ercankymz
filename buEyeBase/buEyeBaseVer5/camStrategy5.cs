// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camStrategy5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class camStrategy5 : buSerilization5
{
  public bool MaintainTiltFlg;
  public CamExtAxis TiltAxis;
  public bool BAngleLimitInXZPlaneFlg;
  public double BAngleLimitStartInXZPlane;
  public double BAngleLimitEndInXZPlane;
  public bool AAngleLimitInYZPlaneFlg;
  public double AAngleLimitStartInYZPlane;
  public double AAngleLimitEndInYZPlane;
  public bool CAngleLimitInXYPlaneFlg;
  public double CAngleLimitStartInXYPlane;
  public double CAngleLimitEndInXYPlane;
  public bool WOrtAngleLimitFlg;
  public double WOrtAngleLimitStart;
  public double WOrtAngleLimitEnd;
  public static List<string> Captions;
  public double CutStep;
  public double XDirectionLength;
  public double YDirectionWidth;
  public Pnt3D CornerPoint;
  public CamHatchCuttingDirection CuttingDirection;
  public CamHatchCuttingMode CuttingModes;
  public static List<string> Captions;
  public static byte f0002AA;
  public bool UseTangentLimit;
  public bool UseLimitAngleForOtherPlane;
  public bool TangentFirstAngleGreaterThen180StartMinusAngle;
  public double AngleLimitXY;
  public double AngleLimitXZ;
  public double AngleLimitYZ;
  public double AngleLimit;
  public double ParallelCutAngleXY;
  public double ParallelMachAngleFromZ;
  public double MinTangentValue;
  public double MaxTangentValue;
  public double TangentOffset;
  public double ContantTangent;
  public double OverrideC;
  public double SpinCStartAngle;
  public double SpinCEndAngle;
  public double SpinSpeed;
  public double CutTolerance;
  public bool UseContantTangent;
  public bool OverrideCEnable;
  public bool ArcToPoints;
  public bool StartFromAnyPoint;
  public bool OpenContourTwoDirectionCut;
  public bool RemoveCornerPeg;
  public bool RoughLeadOut;
  public bool MinimizeLink;
  public bool ReverseCuttingOrder;
  public bool ReverseCut;
  public bool MaintainCuttingDirection;
  public bool ClosedOffset;
  public bool EdgeRolling;
  public bool MachiningDirectionAsReferenceForDirectionOfCutsFlg;
  public bool VerticalWallMachine;
  public bool VerticalWallExclude;
  public bool OutputPatternFlag;
  public CamSilhouetteContainmentTriangleMeshType SilhouetteTriangleMeshType;
  public double SilhouetteStockRemain;
  public bool SilhouetteEnable;
  public bool UseRamp;
  public bool UseRampAreaLinks;
  public bool UseRampBetweenSlices;
  public bool UseRampBetweenRegion;
  public double RampMaxDiameterFromToolPerc;
  public double RampMinDiameterFromToolPerc;
  public CamRampModeTriangleMeshType RampModeTriangleMesh;
  public CamRampTypeTriangleMeshType RampTypeTriangleMesh;
  public double RampAngle;
  public double RampPitch;
  public bool RampMinDiameterToolDiameterEnable;
  public CamParallelCutDirection ParallelCutDireiton;
  public CamParallelCutsStartCorner ParallelCutStartCorner;
  public CamConstantZStart ConstantZStart;
  public VectorType RotaryAxis;
  public CamCuttingMethod CuttingMethod;
  public CamGroupMethod GroupMethod;
  public CamMachiningParamsDirection ClosedCutDirection;
  public CamMachiningAreaMode MachiningAreaMode;
  public CamGeodesicType GeodesicType;
  public CamGeodesicDriveInputType GeodesicDriveInputType;
  public CamGeodesicContainmentType GeodesicContainmetType;
  public CamGeodesicStepover GeodesicStepoverType;
  public double FlatToleranceFactor;
  public double MinWidth;
  public bool MaxWidthFlg;
  public double MaxWidth;
  public double ChainingDistanceInPercOfToolDiameter;
  public bool SingleCut;
  public CamMachiningAreasType MachiningAreaType;
  public bool CornerDetectionThresholdFlg;
  public bool OverThicknessFlg;
  public double CornerDetectionThreshold;
  public double OverThickness;
  public bool MultiPencil;
  public int NumberOfCuts;
  public CamOffsetDirection StepDirection;
  public bool LeftDirNumberOfCutsFlg;
  public int LeftDirNumberOfCuts;
  public bool RightDirNumberOfCutsFlg;
  public int RightDirNumberOfCuts;
  public bool SteepStepoverFlg;
  public double SteepStepover;
  public bool CornerRefinementFlg;
  public CamCutOrder CutOrder;

  public camStrategy5(camOptions5 data)
  {
    ((camOptions5) this).ShowAdvancedPArameters = false;
    ((camOptions5) this).ShpwCoreParameters = false;
    ((camOptions5) this).SelectAllPoints = false;
    ((camOptions5) this).SelectAllDrawings = false;
    ((camOptions5) this).ToolDataToCamData = true;
    ((camOptions5) this).PocketNextContourMaxDistance = 10.0;
    ((camOptions5) this).AxesLimit = new camAxesLimits();
    ((camOptions5) this).StockHeight = 10.0;
    ((camOptions5) this).SpinSpeed = 100.0;
    ((camOptions5) this).FeedFromEntityFeedrate = false;
    ((camOptions5) this).Vacuum1 = false;
    ((camOptions5) this).Vacuum2 = false;
    ((camOptions5) this).Vacuum3 = false;
    ((camRotary5) this).Vacuum4 = false;
    ((camRotary5) this).Vacuum5 = false;
    ((camRotary5) this).Vacuum6 = false;
    ((camRotary5) this).Vacuum7 = false;
    ((camRotary5) this).Vacuum8 = false;
    ((camRotary5) this).WidthXDirection = 0.0;
    ((camRotary5) this).WidthYDirection = 0.0;
    ((camRotary5) this).WidthXYDirection = 0.0;
    ((camRotary5) this).ExtendPatternOutput = 0.0;
    ((camRotary5) this).UseXZPlane = false;
    ((camRotary5) this).StockEnable = false;
    ((camRotary5) this).StockSilhouette = false;
    ((camRotary5) this).StockTolarance = 0.1;
    ((camRotary5) this).StockOffset = 0.0;
    ((camRotary5) this).StockOffsetMode = CamStockOffsetMode.SomExpand;
    ((camRotary5) this).StockType = CamStockType.StBoundingBox;
    ((camRotary5) this).StockSilhouetteType = CamStockSilhouetteType.partEnd;
    ((camRotary5) this).StockOffsetMin = new Point3D();
    ((camRotary5) this).StockOffsetMax = new Point3D();
    ((camRotary5) this).RegenList = new List<RegenResolutionData>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null)
    {
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
      if (((camRotary5) data).RegenList.Count > 0)
      {
        for (int index = 0; index <= ((camRotary5) data).RegenList.Count - 1; ++index)
          ((camRotary5) this).RegenList.Add((RegenResolutionData) new ToolBase5(((camRotary5) this).RegenList[index]));
      }
    }
    ((camOptions5) CopiedClass).AxesLimit = new camAxesLimits(data.AxesLimit);
  }

  public override string ToString()
  {
    return "SelectAllPoints: " + ((camOptions5) this).SelectAllPoints.ToString();
  }

  static camStrategy5() => camRotary5.Captions = new List<string>();

  public camStrategy5()
  {
    ((camRotary5) this).TiltStrategy = CamTiltStrategy.NoTilt;
    ((camRotary5) this).SideTiltDefTypes = CamSideTiltDefTypes.OrthoToCutDirAtEachPos;
    ((camRotary5) this).LagAngle = 0.0;
    ((camRotary5) this).SideTiltAngle = 0.0;
    ((camRotary5) this).MaxAngleChange = 3.0;
    ((camHatch5) this).LimitsFlg = true;
    ((camHatch5) this).SmoothingFlg = true;
    ((camHatch5) this).MaxAngleFromInitialToolOrientation = 30.0;
    ((camHatch5) this).UndercutsFlg = false;
    ((camHatch5) this).TiltAngleFixed = 0.0;
    ((camHatch5) this).RotaryAngle = 0.0;
    ((camHatch5) this).AxisMeetTiltFlg = false;
    this.MaintainTiltFlg = false;
    this.TiltAxis = CamExtAxis.ExtAxisZ;
    this.BAngleLimitInXZPlaneFlg = false;
    this.BAngleLimitStartInXZPlane = 45.0;
    this.BAngleLimitEndInXZPlane = 135.0;
    this.AAngleLimitInYZPlaneFlg = false;
    this.AAngleLimitStartInYZPlane = 45.0;
    this.AAngleLimitEndInYZPlane = 135.0;
    this.CAngleLimitInXYPlaneFlg = false;
    this.CAngleLimitStartInXYPlane = 0.0;
    this.CAngleLimitEndInXYPlane = 360.0;
    this.WOrtAngleLimitFlg = false;
    this.WOrtAngleLimitStart = 0.0;
    this.WOrtAngleLimitEnd = 100.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public camStrategy5(camRotary5 data)
  {
    ((camRotary5) this).TiltStrategy = CamTiltStrategy.NoTilt;
    ((camRotary5) this).SideTiltDefTypes = CamSideTiltDefTypes.OrthoToCutDirAtEachPos;
    ((camRotary5) this).LagAngle = 0.0;
    ((camRotary5) this).SideTiltAngle = 0.0;
    ((camRotary5) this).MaxAngleChange = 3.0;
    ((camHatch5) this).LimitsFlg = true;
    ((camHatch5) this).SmoothingFlg = true;
    ((camHatch5) this).MaxAngleFromInitialToolOrientation = 30.0;
    ((camHatch5) this).UndercutsFlg = false;
    ((camHatch5) this).TiltAngleFixed = 0.0;
    ((camHatch5) this).RotaryAngle = 0.0;
    ((camHatch5) this).AxisMeetTiltFlg = false;
    this.MaintainTiltFlg = false;
    this.TiltAxis = CamExtAxis.ExtAxisZ;
    this.BAngleLimitInXZPlaneFlg = false;
    this.BAngleLimitStartInXZPlane = 45.0;
    this.BAngleLimitEndInXZPlane = 135.0;
    this.AAngleLimitInYZPlaneFlg = false;
    this.AAngleLimitStartInYZPlane = 45.0;
    this.AAngleLimitEndInYZPlane = 135.0;
    this.CAngleLimitInXYPlaneFlg = false;
    this.CAngleLimitStartInXYPlane = 0.0;
    this.CAngleLimitEndInXYPlane = 360.0;
    this.WOrtAngleLimitFlg = false;
    this.WOrtAngleLimitStart = 0.0;
    this.WOrtAngleLimitEnd = 100.0;
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
}
