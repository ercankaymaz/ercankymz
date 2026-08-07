// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buEntity
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.ClassViewer;
using buEyeBaseVer5.Forms.BarCodes;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Printer3D;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buEntity : buSerilization5
{
  public buSpin spn_depthendoffset;
  public buSpin spn_plungespeed;
  public buSpin spn_cuttingspeed;
  public buSpin spn_rapiddistance;
  public buSpin spn_safedistance;
  public buCheckBox chk_showadvancedsettings;
  public buSpin spn_leftoffset;
  public buSpin spn_rightoffset;
  public buButton btn_4_5AxesSettings;
  internal buLabel \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  public buSpin spn_sufaceoffset;
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm;
  public camParameters5 Settings;
  private IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public Panel pnl_base;

  public void Apply()
  {
    ((F_CamSettings1) this).Settings.Distances.Safe = ((F_CamSettings1) this).spn_safedistance.Value;
    ((camMaterial5) ((F_CamSettings1) this).Settings.Distances).Rapid = ((F_CamSettings1) this).spn_rapiddistance.Value;
    ((F_CamSettings1) this).Settings.Speeds.Feed = ((F_CamSettings1) this).spn_cuttingspeed.Value;
    ((F_CamSettings1) this).Settings.Speeds.Plunge = ((F_CamSettings1) this).spn_plungespeed.Value;
    ((F_CamSettings1) this).Settings.Steps.EndOffset = ((F_CamSettings1) this).spn_bottomoffst.Value;
    ((F_CamSettings1) this).Settings.Steps.StartOffset = ((F_CamSettings1) this).spn_topoffet.Value;
    ((F_CamSettings1) this).Settings.Strategy.CutTolerance = ((F_CamSettings1) this).spn_cuttolerance.Value;
    if (((F_CamSettings1) this).camType != CamType.Geodesic)
    {
      if (((F_CamSettings1) this).chk_zigzag.Check)
        ((F_CamSettings1) this).Settings.Strategy.CuttingMethod = CamCuttingMethod.MachtypeZigzag;
      else if (((F_CamSettings1) this).chk_oneway.Check)
        ((F_CamSettings1) this).Settings.Strategy.CuttingMethod = CamCuttingMethod.MachtypeOneway;
      else if (((F_CamSettings1) this).chk_spiral.Check)
        ((F_CamSettings1) this).Settings.Strategy.CuttingMethod = CamCuttingMethod.MachtypeSpiral;
      if (((F_CamRough4XSettings) this).chk_region.Check)
        ((F_CamSettings1) this).Settings.Strategy.MachiningAreaMode = CamMachiningAreaMode.MachByRegions;
      else if (((F_CamRough4XSettings) this).chk_level.Check)
        ((F_CamSettings1) this).Settings.Strategy.MachiningAreaMode = CamMachiningAreaMode.MachByLanes;
    }
    if (((F_CamSettings1) this).camType == CamType.ParallelCut)
      ((F_CamSettings1) this).Settings.Operations.Stepover = ((F_CamSettings1) this).spn_stepoverparallel.Value;
    if (((F_CamSettings1) this).camType == CamType.ConstantZ)
    {
      ((F_CamSettings1) this).Settings.Steps.DepthStep = ((F_BarCode) this).spn_depthstepconstantZ.Value;
      ((F_CamSettings1) this).Settings.Operations.Overlap = ((F_CamRough4XSettings) this).spn_overlapconstantZ.Value;
    }
    if (((F_CamSettings1) this).camType == CamType.Projection)
      ((F_CamSettings1) this).Settings.Operations.Stepover = ((buEntityUpdateType) this).spn_stepoverProjection.Value;
    if (((F_CamSettings1) this).camType == CamType.Rough)
    {
      ((F_CamSettings1) this).Settings.Operations.Stepover = ((F_CamSettings1) this).spn_stepoverrough.Value;
      ((F_CamSettings1) this).Settings.Steps.DepthStep = ((F_CamRough4XSettings) this).spn_depthsteprough.Value;
      if (((F_CamSettings1) this).chk_roughoffset.Check)
        ((camOperation5) ((F_CamSettings1) this).Settings.Pockets).PocketType = CamPocketType.WfbRghtOffset;
      else if (((F_CamSettings1) this).chk_roughparalel.Check)
        ((camOperation5) ((F_CamSettings1) this).Settings.Pockets).PocketType = CamPocketType.WfbRghtParallel;
      else if (((F_CamSettings1) this).chk_roughadaptive.Check)
        ((camOperation5) ((F_CamSettings1) this).Settings.Pockets).PocketType = CamPocketType.WfbRghtOffset;
    }
    if (((F_CamSettings1) this).camType == CamType.ConstantCusp)
    {
      ((F_CamSettings1) this).Settings.Operations.Stepover = ((buClassViewer5) this).spn_stepoverConstcusp.Value;
      ((F_CamSettings1) this).Settings.Steps.DepthStep = ((buClassViewer5) this).spn_depthstepoverConstcusp.Value;
      ((F_CamSettings1) this).Settings.Operations.Overlap = ((buClassViewer5) this).spn_overlapConstcusp.Value;
      if (((buClassViewer5) this).chk_cutorderstandartConstcusp.Check)
        ((F_CamSettings1) this).Settings.Strategy.CutOrder = CamCutOrder.OrderStandard;
      else if (((buClassViewer5) this).chk_cutorderfromcenterawayConstcusp.Check)
        ((F_CamSettings1) this).Settings.Strategy.CutOrder = CamCutOrder.OrderFromCenter;
      else if (((buClassViewer5) this).chk_cutorderfromoutsidetocenterConstcusp.Check)
        ((F_CamSettings1) this).Settings.Strategy.CutOrder = CamCutOrder.OrderFromOuter;
      else if (((buClassViewer5) this).chk_cutorderfromtoptobottomConstcusp.Check)
        ((F_CamSettings1) this).Settings.Strategy.CutOrder = CamCutOrder.OrderFromTopToBottom;
      else if (((buClassViewer5) this).chk_cutorderfrombottomtotopConstcusp.Check)
        ((F_CamSettings1) this).Settings.Strategy.CutOrder = CamCutOrder.OrderFromBottomToTop;
    }
    if (((F_CamSettings1) this).camType == CamType.Pencil)
    {
      ((F_CamSettings1) this).Settings.Operations.Stepover = ((buClassViewerColor5) this).spn_stepoverpencil.Value;
      ((F_CamSettings1) this).Settings.Operations.Overlap = ((buClassViewerColor5) this).spn_overthicknesspnecil.Value;
      if (((buClassViewerColor5) this).chk_cutorderstandartpencil.Check)
        ((F_CamSettings1) this).Settings.Strategy.CutOrder = CamCutOrder.OrderStandard;
      else if (((buClassViewerColor5) this).chk_cutorderfromcenterawaypencil.Check)
        ((F_CamSettings1) this).Settings.Strategy.CutOrder = CamCutOrder.OrderFromCenter;
      else if (((buClassViewerColor5) this).chk_cutorderfromoutsidetocenterpencil.Check)
        ((F_CamSettings1) this).Settings.Strategy.CutOrder = CamCutOrder.OrderFromOuter;
      else if (((buClassViewerColor5) this).chk_cutorderfromtoptobottompencil.Check)
        ((F_CamSettings1) this).Settings.Strategy.CutOrder = CamCutOrder.OrderFromTopToBottom;
      else if (((buClassViewerColor5) this).chk_cutorderfrombottomtotoppencil.Check)
        ((F_CamSettings1) this).Settings.Strategy.CutOrder = CamCutOrder.OrderFromBottomToTop;
    }
    if (((F_CamSettings1) this).camType == CamType.Flatlands)
    {
      ((F_CamSettings1) this).Settings.Operations.Stepover = ((buClassViewerColor5) this).spn_sepoverflatland.Value;
      ((F_CamSettings1) this).Settings.Steps.DepthStep = ((setComboBoxControl) this).spn_depthstepflatland.Value;
      if (((setColorComboControl) this).chk_flatlandoffset.Check)
        ((camOperation5) ((F_CamSettings1) this).Settings.Pockets).PocketType = CamPocketType.WfbRghtOffset;
      else if (((buClassViewerColor5) this).chk_flatlandparallel.Check)
        ((camOperation5) ((F_CamSettings1) this).Settings.Pockets).PocketType = CamPocketType.WfbRghtParallel;
      else if (((buClassViewerColor5) this).chk_flatlandadaptive.Check)
        ((camOperation5) ((F_CamSettings1) this).Settings.Pockets).PocketType = CamPocketType.WfbRghtOffset;
    }
    ((camOperation5) ((F_CamSettings1) this).Settings.Pockets).SharpCorner = ((F_CamSettings1) this).chk_roughsharpcorner.Check;
    ((F_CamSettings1) this).Settings.Strategy.RoughLeadOut = ((F_CamSettings1) this).chk_roughleadout.Check;
    ((F_CamSettings1) this).Settings.Strategy.MinimizeLink = ((F_CamSettings1) this).chk_roughminimizelink.Check;
    ((F_CamSettings1) this).Settings.Strategy.RemoveCornerPeg = ((F_CamSettings1) this).chk_roughremovecornerpeg.Check;
    ((F_CamSettings1) this).Settings.Strategy.ReverseCuttingOrder = ((F_CamRough4XSettings) this).chk_reversecuttingoderrrough.Check;
    ((F_CamSettings1) this).Settings.Strategy.ReverseCuttingOrder = ((buClassViewerColor5) this).chk_reversecuttingorderflatland.Check;
    ((F_CamSettings1) this).Settings.Strategy.MaintainCuttingDirection = ((F_CamRough4XSettings) this).chk_maintaincuttingdirectionrough.Check;
    ((F_CamSettings1) this).Settings.Strategy.MaintainCuttingDirection = ((F_BarCode) this).chk_maintaincuttingdirectionroughconstantz.Check;
    ((F_CamSettings1) this).Settings.Strategy.ClosedOffset = ((F_CamRough4XSettings) this).chk_closedoffsetrrough.Check;
    ((F_CamSettings1) this).Settings.Strategy.UseRamp = ((F_CamSettings1) this).chk_roughuseramp.Check;
    ((F_CamSettings1) this).Settings.Strategy.RampAngle = ((F_CamSettings1) this).spn_roughrampangle.Value;
    ((F_CamSettings1) this).Settings.Strategy.RampMaxDiameterFromToolPerc = ((F_CamSettings1) this).spn_roughrampdia.Value;
    if (((F_CamSettings1) this).chk_roughstockbox.Check)
      ((camRotary5) ((F_CamSettings1) this).Settings.Options).StockType = CamStockType.StBoundingBox;
    else if (((F_CamSettings1) this).chk_roughstocksurface.Check)
      ((camRotary5) ((F_CamSettings1) this).Settings.Options).StockType = CamStockType.StSurfaces;
    ((F_CamSettings1) this).Settings.Strategy.EdgeRolling = ((F_BarCode) this).chk_edgerollingconstantZ.Check;
    ((F_CamSettings1) this).Settings.Strategy.EdgeRolling = ((F_BarCode) this).chk_edgerollingparallel.Check;
    ((F_CamSettings1) this).Settings.Strategy.EdgeRolling = ((buClassViewer5) this).chk_edgerollingConstcusp.Check;
    if (((F_CamRough4XSettings) this).chk_cornerlowerrightparallel.Check)
      ((F_CamSettings1) this).Settings.Strategy.ParallelCutStartCorner = CamParallelCutsStartCorner.TmbScLowerRight;
    else if (((F_CamRough4XSettings) this).chk_cornerlowerleftparallel.Check)
      ((F_CamSettings1) this).Settings.Strategy.ParallelCutStartCorner = CamParallelCutsStartCorner.TmbScLowerLeft;
    else if (((F_CamRough4XSettings) this).chk_cornerupperleftparallel.Check)
      ((F_CamSettings1) this).Settings.Strategy.ParallelCutStartCorner = CamParallelCutsStartCorner.TmbScUpperLeft;
    else if (((F_CamRough4XSettings) this).chk_cornerupperrightparallel.Check)
      ((F_CamSettings1) this).Settings.Strategy.ParallelCutStartCorner = CamParallelCutsStartCorner.TmbScUpperRight;
    if (((F_CamRough4XSettings) this).chk_xdirectionparallel.Check)
      ((F_CamSettings1) this).Settings.Strategy.ParallelCutDireiton = CamParallelCutDirection.XDirection;
    else if (((F_CamRough4XSettings) this).chk_ydirectionparallel.Check)
      ((F_CamSettings1) this).Settings.Strategy.ParallelCutDireiton = CamParallelCutDirection.YDirection;
    else if (((F_CamRough4XSettings) this).chk_Angledirectionparallel.Check)
      ((F_CamSettings1) this).Settings.Strategy.ParallelCutDireiton = CamParallelCutDirection.AngleDirection;
    ((F_CamSettings1) this).Settings.Strategy.ParallelCutAngleXY = ((F_CamRough4XSettings) this).spn_parallelangleparallel.Value;
    if (((F_CamRough4XSettings) this).chk_StartAttopconstantZ.Check)
      ((F_CamSettings1) this).Settings.Strategy.ConstantZStart = CamConstantZStart.ShbZsTop;
    else if (((F_CamRough4XSettings) this).chk_StartAtbottomconstantZ.Check)
      ((F_CamSettings1) this).Settings.Strategy.ConstantZStart = CamConstantZStart.ShbZsBottom;
    if (((F_BarCode) this).chk_verticalwallexcludeconstantZ.Check)
    {
      ((F_CamSettings1) this).Settings.Strategy.VerticalWallMachine = false;
      ((F_CamSettings1) this).Settings.Strategy.VerticalWallExclude = true;
    }
    else if (((F_BarCode) this).chk_verticalwallincludeconstantZ.Check)
    {
      ((F_CamSettings1) this).Settings.Strategy.VerticalWallMachine = false;
      ((F_CamSettings1) this).Settings.Strategy.VerticalWallExclude = false;
    }
    else if (((F_BarCode) this).chk_verticalwallmachineonlyconstantZ.Check)
    {
      ((F_CamSettings1) this).Settings.Strategy.VerticalWallMachine = true;
      ((F_CamSettings1) this).Settings.Strategy.VerticalWallExclude = false;
    }
    ((F_CamSettings1) this).Settings.Strategy.FlatToleranceFactor = ((buClassViewerColor5) this).spn_flattolerancefactorflatland.Value;
    ((camSpeeds5) ((F_CamSettings1) this).Settings.Steps).DepthStepEnable = ((setTextBoxControl) this).chk_depthstepenableflatland.Check;
    ((camSpeeds5) ((F_CamSettings1) this).Settings.Steps).NumberOfPasses4DepthStep = (int) ((setLabelControl) this).spn_numberofpassesflatland.Value;
    ((camSpeeds5) ((F_CamSettings1) this).Settings.Steps).FinalDepthStep = ((setCheckBoxControl) this).spn_finaldepthstepflatland.Value;
    ((F_CamSettings1) this).Settings.Strategy.SingleCut = ((buClassViewerColor5) this).chk_singlestepflatland.Check;
    if (((buClassViewerColor5) this).chk_singlestepawideflatland.Check)
      ((F_CamSettings1) this).Settings.Strategy.MachiningAreaType = CamMachiningAreasType.MatWide;
    else if (((buClassViewerColor5) this).chk_singlestepnarrowflatland.Check)
      ((F_CamSettings1) this).Settings.Strategy.MachiningAreaType = CamMachiningAreasType.MatNarrow;
    else if (((buClassViewerColor5) this).chk_singlestepnarrowandwideflatland.Check)
      ((F_CamSettings1) this).Settings.Strategy.MachiningAreaType = CamMachiningAreasType.MatNarrowAndWide;
    ((F_CamSettings1) this).Settings.Strategy.MinWidth = ((buClassViewerColor5) this).spn_minwidthflatland.Value;
    ((F_CamSettings1) this).Settings.Strategy.MaxWidth = ((buClassViewerColor5) this).spn_maxwidthflatland.Value;
    ((F_CamSettings1) this).Settings.Strategy.MaxWidthFlg = ((buClassViewerColor5) this).chk_maxwidhtenableflatland.Check;
    ((F_CamSettings1) this).Settings.Strategy.ChainingDistanceInPercOfToolDiameter = ((buClassViewerColor5) this).spn_chaningdistanceflatland.Value;
    ((F_CamSettings1) this).Settings.Strategy.MultiPencil = ((buClassViewerColor5) this).chk_multipencil.Check;
    ((F_CamSettings1) this).Settings.Strategy.NumberOfCuts = (int) ((buClassViewerColor5) this).spn_multipencil.Value;
    ((F_CamSettings1) this).Settings.Strategy.CornerDetectionThresholdFlg = ((buClassViewerColor5) this).chk_cornerdetectionthresholdpencil.Check;
    ((F_CamSettings1) this).Settings.Strategy.CornerDetectionThreshold = ((buClassViewerColor5) this).spn_cornerdetectionthresholdpencil.Value;
    ((F_CamSettings1) this).Settings.Strategy.OverThicknessFlg = ((buClassViewerColor5) this).chk_overthicknesspnecil.Check;
    ((F_CamSettings1) this).Settings.Strategy.OverThickness = ((buClassViewerColor5) this).spn_overthicknesspnecil.Value;
    ((F_CamSettings1) this).Settings.Strategy.SteepStepoverFlg = ((buClassViewer5) this).chk_depthstepoverConstcusp.Check;
    ((F_CamSettings1) this).Settings.Strategy.SteepStepover = ((buClassViewer5) this).spn_depthstepoverConstcusp.Value;
    ((F_CamSettings1) this).Settings.Strategy.CornerRefinementFlg = ((buClassViewer5) this).chk_cornerefinementConstcusp.Check;
    ((F_CamSettings1) this).Settings.Strategy.RightDirNumberOfCutsFlg = ((buClassViewer5) this).chk_rightcutnumberConstcusp.Check;
    ((F_CamSettings1) this).Settings.Strategy.RightDirNumberOfCuts = (int) ((buClassViewer5) this).spn_rightcutnumberConstcusp.Value;
    ((F_CamSettings1) this).Settings.Strategy.LeftDirNumberOfCutsFlg = ((buClassViewerColor5) this).chk_leftcutnumberConstcusp.Check;
    ((F_CamSettings1) this).Settings.Strategy.LeftDirNumberOfCuts = (int) ((buClassViewer5) this).spn_leftcutnumberConstcusp.Value;
    if (((buClassViewer5) this).chk_stepdirbothConstcusp.Check)
      ((F_CamSettings1) this).Settings.Strategy.StepDirection = CamOffsetDirection.PcpOdBoth;
    else if (((buClassViewer5) this).chk_stepdirleftConstcusp.Check)
      ((F_CamSettings1) this).Settings.Strategy.StepDirection = CamOffsetDirection.PcpOdLeft;
    else if (((buClassViewer5) this).chk_stepdirrightConstcusp.Check)
      ((F_CamSettings1) this).Settings.Strategy.StepDirection = CamOffsetDirection.PcpOdRight;
    ((F_CamSettings1) this).Settings.Strategy.SilhouetteStockRemain = ((F_Printer3DSettings) this).spn_silhouetteoffset.Value;
    if (((F_Printer3DSettings) this).chk_silhouettepart.Check)
    {
      ((F_CamSettings1) this).Settings.Strategy.SilhouetteTriangleMeshType = CamSilhouetteContainmentTriangleMeshType.ScctPartSilhouette;
      ((F_CamSettings1) this).Settings.Strategy.SilhouetteEnable = true;
    }
    else if (((F_Printer3DSettings) this).chk_silhouettepartend.Check)
    {
      ((F_CamSettings1) this).Settings.Strategy.SilhouetteTriangleMeshType = CamSilhouetteContainmentTriangleMeshType.ScctPartEnd;
      ((F_CamSettings1) this).Settings.Strategy.SilhouetteEnable = true;
    }
    else if (((F_Printer3DSettings) this).chk_silhouettetoolcontact.Check)
    {
      ((F_CamSettings1) this).Settings.Strategy.SilhouetteTriangleMeshType = CamSilhouetteContainmentTriangleMeshType.ScctToolContact;
      ((F_CamSettings1) this).Settings.Strategy.SilhouetteEnable = true;
    }
    else
      ((F_CamSettings1) this).Settings.Strategy.SilhouetteEnable = false;
    ((camNotch5) ((F_CamSettings1) this).Settings.Strategy).RadiuFitFlag = ((F_Printer3DSettings) this).chk_roundcorner.Check;
    ((camNotch5) ((F_CamSettings1) this).Settings.Strategy).SplineMaxDeviation = ((F_Printer3DSettings) this).spn_maxdeviationrundcorner.Value;
    ((camNotch5) ((F_CamSettings1) this).Settings.Strategy).AngleRangeEnable = ((buClassViewer5) this).chk_Anglerangeenable.Check;
    ((camNotch5) ((F_CamSettings1) this).Settings.Strategy).AngleRangeSlopeAngleStart = ((buClassViewer5) this).spn_anglerangestart.Value;
    ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).AngleRangeSlopeAngleEnd = ((buClassViewer5) this).spn_anglerangeend.Value;
    if (((buClassViewer5) this).chk_anglerangebetweenslopeangles.Check)
      ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).AngleRangeMachiningAreaType = CamMachiningAreaType.MatSteepAreas;
    else if (((buClassViewer5) this).chk_anglerangeoutsideslopeangles.Check)
      ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).AngleRangeMachiningAreaType = CamMachiningAreaType.MatShallowAreas;
    ((F_CamSettings1) this).Settings.Rotary.MaxAngleChange = ((F_Printer3DSettings) this).spn_MaxAngleChange.Value;
    ((F_CamSettings1) this).Settings.Rotary.SideTiltAngle = ((F_Printer3DSettings) this).spn_SideTiltAngle.Value;
    ((F_CamSettings1) this).Settings.Rotary.LagAngle = ((F_Printer3DSettings) this).spn_LagAngle.Value;
    ((camHatch5) ((F_CamSettings1) this).Settings.Rotary).TiltAngleFixed = ((F_Printer3DSettings) this).spn_tiltangle.Value;
    ((camHatch5) ((F_CamSettings1) this).Settings.Rotary).RotaryAngle = ((F_Printer3DSettings) this).spn_rotaryangle.Value;
    ((camHatch5) ((F_CamSettings1) this).Settings.Rotary).MaxAngleFromInitialToolOrientation = ((F_Printer3DSettings) this).spn_smoothmaxtiltangle.Value;
    ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).BAngleLimitEndInXZPlane = ((F_Printer3DSettings) this).spn_BAngleLimitEndInXZPlane.Value;
    ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).BAngleLimitStartInXZPlane = ((F_Printer3DSettings) this).spn_BAngleLimitStartInXZPlane.Value;
    ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).AAngleLimitStartInYZPlane = ((F_Printer3DSettings) this).spn_AAngleLimitStartInYZPlane.Value;
    ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).AAngleLimitEndInYZPlane = ((F_Printer3DSettings) this).spn_AAngleLimitEndInYZPlane.Value;
    ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).CAngleLimitEndInXYPlane = ((F_Printer3DSettings) this).spn_CAngleLimitEndInXYPlane.Value;
    ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).CAngleLimitStartInXYPlane = ((F_Printer3DSettings) this).spn_CAngleLimitStartInXYPlane.Value;
    ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).WOrtAngleLimitEnd = ((F_Printer3DSettings) this).spn_WOrtAngleLimitEnd.Value;
    ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).WOrtAngleLimitStart = ((F_Printer3DSettings) this).spn_WOrtAngleLimitStart.Value;
    ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).AAngleLimitInYZPlaneFlg = ((F_Printer3DSettings) this).chk_AAngleLimit.Check;
    ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).BAngleLimitInXZPlaneFlg = ((F_Printer3DSettings) this).chk_BAngleLimit.Check;
    ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).CAngleLimitInXYPlaneFlg = ((F_Printer3DSettings) this).chk_CAngleLimit.Check;
    ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).WOrtAngleLimitFlg = ((F_Printer3DSettings) this).chk_WAngleLimit.Check;
    ((camHatch5) ((F_CamSettings1) this).Settings.Rotary).SmoothingFlg = ((F_Printer3DSettings) this).chk_smoot.Check;
    ((camHatch5) ((F_CamSettings1) this).Settings.Rotary).UndercutsFlg = ((F_BarCode) this).chk_undercut.Check;
    ((camHatch5) ((F_CamSettings1) this).Settings.Rotary).AxisMeetTiltFlg = ((F_Printer3DSettings) this).chk_toolaxiscrossestiltaxis.Check;
    ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).MaintainTiltFlg = ((F_Printer3DSettings) this).chk_maintaintiltaxis.Check;
    if (((F_Printer3DSettings) this).chk_tiltXAxis.Check)
      ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).TiltAxis = CamExtAxis.ExtAxisX;
    else if (((F_Printer3DSettings) this).chk_tiltYAxis.Check)
      ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).TiltAxis = CamExtAxis.ExtAxisY;
    else if (((F_Printer3DSettings) this).chk_tiltZAxis.Check)
      ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).TiltAxis = CamExtAxis.ExtAxisZ;
    if (((F_Printer3DSettings) this).chk_notbetilted.Check)
      ((F_CamSettings1) this).Settings.Rotary.TiltStrategy = CamTiltStrategy.NoTilt;
    else if (((F_Printer3DSettings) this).chk_betiltedeleative.Check)
      ((F_CamSettings1) this).Settings.Rotary.TiltStrategy = CamTiltStrategy.RelativeToCuttingDir;
    else if (((F_Printer3DSettings) this).chk_tiltedwithfixangle.Check)
      ((F_CamSettings1) this).Settings.Rotary.TiltStrategy = CamTiltStrategy.FixedAngle;
    if (((F_Printer3DSettings) this).chk_followsurfaceisodir.Check)
      ((F_CamSettings1) this).Settings.Rotary.SideTiltDefTypes = CamSideTiltDefTypes.FollowSurfIsoDir;
    else if (((F_Printer3DSettings) this).chk_orthotocutdirection.Check)
      ((F_CamSettings1) this).Settings.Rotary.SideTiltDefTypes = CamSideTiltDefTypes.OrthoToCutDirAtEachPos;
    else if (((F_Printer3DSettings) this).chk_usespindlemaindir.Check)
      ((F_CamSettings1) this).Settings.Rotary.SideTiltDefTypes = CamSideTiltDefTypes.UseSpindleMainDir;
    if (((F_CamSettings1) this).camType == CamType.Projection)
    {
      ((camStep5) ((F_CamSettings1) this).Settings.Offsets).AdditionalOffset = ((buEntityUpdateType) this).spn_offsetProjection.Value;
      ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).CylinderRadiusAroundLine = ((buEntityUpdateType) this).spn_radiusProjection.Value;
      ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).SideShift = ((buEntityUpdateType) this).spn_sideshiftProjection.Value;
      ((LeadOut5) ((F_CamSettings1) this).Settings.Strategy).ProjectionStartAngles = ((buEntityUpdateType) this).spn_startangleProjection.Value;
      ((LeadOut5) ((F_CamSettings1) this).Settings.Strategy).ProjectionEndAngles = ((buEntityUpdateType) this).spn_endangleProjection.Value;
      ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).ProjectionStartHeight = ((buEntityUpdateType) this).spn_startheightProjection.Value;
      ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).ProjectionEndHeight = ((buEntityUpdateType) this).spn_endheightProjection.Value;
      ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).ProjectionLineX = ((buEntityUpdateType) this).spn_lineXProjection.Value;
      ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).ProjectionLineY = ((buEntityUpdateType) this).spn_lineYProjection.Value;
      ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).ProjectionLineZ = ((buEntityUpdateType) this).spn_lineZProjection.Value;
      ((LeadOut5) ((F_CamSettings1) this).Settings.Strategy).MultiPassNumberOfRoughCuts = (int) ((buEntityUpdateType) this).spn_numberroughProjection.Value;
      ((LeadOut5) ((F_CamSettings1) this).Settings.Strategy).MultiPassRoughPassSpacing = ((buEntityUpdateType) this).spn_spacingroughProjection.Value;
      if (((buEntityUpdateType) this).chk_cutorderfromcenterProjection.Check)
        ((F_CamSettings1) this).Settings.Strategy.CutOrder = CamCutOrder.OrderFromCenter;
      else if (((buEntityUpdateType) this).chk_cutorderfromcenterProjection.Check)
        ((F_CamSettings1) this).Settings.Strategy.CutOrder = CamCutOrder.OrderFromOuter;
      else
        ((F_CamSettings1) this).Settings.Strategy.CutOrder = CamCutOrder.OrderStandard;
      if (((buEntityUpdateType) this).chk_cwprojection.Check)
        ((F_CamSettings1) this).Settings.Strategy.ClosedCutDirection = CamMachiningParamsDirection.DirClockwise;
      else
        ((F_CamSettings1) this).Settings.Strategy.ClosedCutDirection = CamMachiningParamsDirection.DirCounterClockwise;
      if (((buEntityUpdateType) this).chk_slicesProjection.Check)
        ((LeadOut5) ((F_CamSettings1) this).Settings.Strategy).MultiPassSortType = CamRoughSortType.McSortBySlices;
      else
        ((LeadOut5) ((F_CamSettings1) this).Settings.Strategy).MultiPassSortType = CamRoughSortType.McSortByPasses;
    }
    if (((F_CamSettings1) this).camType != CamType.Geodesic)
      return;
    ((F_CamSettings1) this).Settings.Distances.Safe = ((F_ClassViewerColorDialog5) this).spn_safedistancegeodesic.Value;
    ((camMaterial5) ((F_CamSettings1) this).Settings.Distances).Rapid = ((F_ClassViewerColorDialog5) this).spn_rapiddistancegeodesic.Value;
    ((F_CamSettings1) this).Settings.Speeds.Feed = ((F_ClassViewerColorDialog5) this).spn_cuttingspeedgeodesic.Value;
    ((F_CamSettings1) this).Settings.Speeds.Plunge = ((F_ClassViewerColorDialog5) this).spn_plungespeedgeodesic.Value;
    ((F_CamSettings1) this).Settings.Strategy.CutTolerance = ((F_ClassViewerColorDialog5) this).spn_cuttolerancegeodesic.Value;
    ((F_CamSettings1) this).Settings.Strategy.ReverseCut = ((buEntityUpdateType) this).chk_flipstepovergeodesic.Check;
    ((F_CamSettings1) this).Settings.Strategy.MachiningDirectionAsReferenceForDirectionOfCutsFlg = ((buEntityUpdateType) this).chk_usemachiningdirectiongeodesic.Check;
    ((camStep5) ((F_CamSettings1) this).Settings.Offsets).AdditionalOffset = ((buEntityUpdateType) this).spn_surfaceoffsetgeodesic.Value;
    ((F_CamSettings1) this).Settings.Operations.Stepover = ((buEntityUpdateType) this).spn_stepovergeodesic.Value;
    if (((F_ClassViewerColorDialog5) this).chk_zigzaggeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.CuttingMethod = CamCuttingMethod.MachtypeZigzag;
    else if (((F_ClassViewerColorDialog5) this).chk_onewaygeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.CuttingMethod = CamCuttingMethod.MachtypeOneway;
    else if (((F_ClassViewerColorDialog5) this).chk_spiralgeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.CuttingMethod = CamCuttingMethod.MachtypeSpiral;
    if (((F_ClassViewerColorDialog5) this).chk_regiongeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.MachiningAreaMode = CamMachiningAreaMode.MachByRegions;
    else if (((F_ClassViewerColorDialog5) this).chk_levelgeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.MachiningAreaMode = CamMachiningAreaMode.MachByLanes;
    if (((buClassViewer5) this).chk_toolcentermodegeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.OutputPatternFlag = false;
    else if (((buClassViewer5) this).chk_contactmodegeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.OutputPatternFlag = true;
    if (((F_ClassViewerDialog5) this).chk_morphbetweentwocurvegeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.GeodesicType = CamGeodesicType.TmbGeodesicMorph;
    else if (((F_ClassViewerDialog5) this).chk_paralleltomultiplecurvegeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.GeodesicType = CamGeodesicType.TmbGeodesicOffset;
    if (((F_ClassViewerDialog5) this).chk_cointainmentgeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.GeodesicDriveInputType = CamGeodesicDriveInputType.TmbGditMachining;
    else if (((F_ClassViewerDialog5) this).chk_medialaxisofcontainmentgeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.GeodesicDriveInputType = CamGeodesicDriveInputType.TmbGditUserDefinedMesh;
    else if (((F_ClassViewerDialog5) this).chk_circleatcentercontainmentgeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.GeodesicDriveInputType = CamGeodesicDriveInputType.TmbGditCenter;
    else if (((F_ClassViewerDialog5) this).chk_boundrycurvesmachiningsurfacegeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.GeodesicDriveInputType = CamGeodesicDriveInputType.TmbGditSurface;
    else if (((F_ClassViewerDialog5) this).chk_userdefinecontainmentgeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.GeodesicDriveInputType = CamGeodesicDriveInputType.TmbGditUserDefined;
    if (((F_ClassViewerDialog5) this).chk_automaticcontainmentgeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.GeodesicContainmetType = CamGeodesicContainmentType.TmbGdpdAuto;
    else if (((F_ClassViewerDialog5) this).chk_userdefinecontainmentgeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.GeodesicContainmetType = CamGeodesicContainmentType.TmbGdpdUserDefined;
    else if (((buEntityUpdateType) this).chk_userdefinecontainmentsillhouttegeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.GeodesicContainmetType = CamGeodesicContainmentType.TmbGdpdUserDefinedAndSilhouette;
    else if (((buEntityUpdateType) this).chk_sillhouttegeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.GeodesicContainmetType = CamGeodesicContainmentType.TmbGdpdSilhouette;
    if (((buEntityUpdateType) this).chk_contantstepovergeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.GeodesicStepoverType = CamGeodesicStepover.TmbGsConstant;
    else if (((buEntityUpdateType) this).chk_maxstepovergeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.GeodesicStepoverType = CamGeodesicStepover.TmbGsMaximum;
    else if (((buEntityUtilities) this).chk_autonocutgeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.GeodesicStepoverType = CamGeodesicStepover.TmbGsAuto;
    if (((buClassViewer5) this).chk_cutorderfromcenterawaygeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.CutOrder = CamCutOrder.OrderFromCenter;
    else if (((buClassViewer5) this).chk_cutorderfromoutsidetocentergeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.CutOrder = CamCutOrder.OrderFromOuter;
    else if (((buClassViewer5) this).chk_cutorderwipefromdirectiongeodesic.Check)
      ((F_CamSettings1) this).Settings.Strategy.CutOrder = CamCutOrder.OrderWipeFromOneSide;
    else
      ((F_CamSettings1) this).Settings.Strategy.CutOrder = CamCutOrder.OrderStandard;
  }

  public void MenuButtonColors(int PageIndex)
  {
    buEyeShotFunctions.SetVisualItem(((F_CamSettings1) this).buGround1.Controls);
    if (PageIndex == 0)
    {
      ((F_CamSettings1) this).btn_camstrategy.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_CamSettings1) this).btn_camstrategy.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      if (((F_CamSettings1) this).camType == CamType.Geodesic)
        ((F_CamSettings1) this).\u0002.SelectedIndex = 1;
      else
        ((F_CamSettings1) this).\u0002.SelectedIndex = PageIndex;
    }
    if (PageIndex == 1)
    {
      ((F_CamSettings1) this).btn_advanced.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_CamSettings1) this).btn_advanced.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_CamSettings1) this).\u0002.SelectedIndex = 2;
    }
    if (PageIndex != 2)
      return;
    ((F_CamSettings1) this).btn_5Axis.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    ((F_CamSettings1) this).btn_5Axis.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    ((F_CamSettings1) this).\u0002.SelectedIndex = 3;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_CamSettings1) this).btn_ok.Name)
      {
        this.Apply();
        ((F_CamSettings1) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_CamSettings1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        {
          // ISSUE: explicit non-virtual call
          __nonvirtual (((Component) this).Dispose());
        }
        if (((F_CamSettings1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          ((Control) this).Visible = false;
      }
      if (control2.Name == ((F_CamSettings1) this).btn_close.Name | control2.Name == ((F_CamSettings1) this).btn_cancel.Name)
      {
        ((F_CamSettings1) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_CamSettings1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        {
          // ISSUE: explicit non-virtual call
          __nonvirtual (((Component) this).Dispose());
        }
        if (((F_CamSettings1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          ((Control) this).Visible = false;
      }
      if (control2.Name == ((F_CamSettings1) this).btn_camstrategy.Name)
        this.MenuButtonColors(0);
      if (control2.Name == ((F_CamSettings1) this).btn_advanced.Name)
        this.MenuButtonColors(1);
      if (!(control2.Name == ((F_CamSettings1) this).btn_5Axis.Name))
        return;
      this.MenuButtonColors(2);
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_CamSettings1) this).PropertiesForm.Inited)
      return;
    (obj0 as buSpin).SelectAll();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (((F_CamSettings1) this).chk_zigzag.Name == control.Name | ((F_CamSettings1) this).chk_oneway.Name == control.Name | ((F_CamSettings1) this).chk_spiral.Name == control.Name)
    {
      ((F_CamSettings1) this).chk_zigzag.Check = false;
      ((F_CamSettings1) this).chk_oneway.Check = false;
      ((F_CamSettings1) this).chk_spiral.Check = false;
      if (((F_CamSettings1) this).chk_zigzag.Name == control.Name)
        ((F_CamSettings1) this).chk_zigzag.Check = true;
      if (((F_CamSettings1) this).chk_oneway.Name == control.Name)
        ((F_CamSettings1) this).chk_oneway.Check = true;
      if (((F_CamSettings1) this).chk_spiral.Name == control.Name)
        ((F_CamSettings1) this).chk_spiral.Check = true;
    }
    if (((F_CamRough4XSettings) this).chk_level.Name == control.Name | ((F_CamRough4XSettings) this).chk_region.Name == control.Name)
    {
      ((F_CamRough4XSettings) this).chk_level.Check = false;
      ((F_CamRough4XSettings) this).chk_region.Check = false;
      if (((F_CamRough4XSettings) this).chk_level.Name == control.Name)
        ((F_CamRough4XSettings) this).chk_level.Check = true;
      if (((F_CamRough4XSettings) this).chk_region.Name == control.Name)
        ((F_CamRough4XSettings) this).chk_region.Check = true;
    }
    if (((F_CamSettings1) this).chk_roughadaptive.Name == control.Name | ((F_CamSettings1) this).chk_roughoffset.Name == control.Name | ((F_CamSettings1) this).chk_roughparalel.Name == control.Name)
    {
      ((F_CamSettings1) this).chk_roughadaptive.Check = false;
      ((F_CamSettings1) this).chk_roughoffset.Check = false;
      ((F_CamSettings1) this).chk_spiral.Check = false;
      if (((F_CamSettings1) this).chk_roughadaptive.Name == control.Name)
        ((F_CamSettings1) this).chk_roughadaptive.Check = true;
      if (((F_CamSettings1) this).chk_roughoffset.Name == control.Name)
        ((F_CamSettings1) this).chk_roughoffset.Check = true;
      if (((F_CamSettings1) this).chk_roughparalel.Name == control.Name)
        ((F_CamSettings1) this).chk_roughparalel.Check = true;
    }
    if (((F_CamSettings1) this).chk_roughstocksurface.Name == control.Name | ((F_CamSettings1) this).chk_roughstockbox.Name == control.Name)
    {
      ((F_CamSettings1) this).chk_roughstocksurface.Check = false;
      ((F_CamSettings1) this).chk_roughstockbox.Check = false;
      if (((F_CamSettings1) this).chk_roughstocksurface.Name == control.Name)
        ((F_CamSettings1) this).chk_roughstocksurface.Check = true;
      if (((F_CamSettings1) this).chk_roughstockbox.Name == control.Name)
        ((F_CamSettings1) this).chk_roughstockbox.Check = true;
    }
    if (((F_CamRough4XSettings) this).chk_xdirectionparallel.Name == control.Name | ((F_CamRough4XSettings) this).chk_ydirectionparallel.Name == control.Name | ((F_CamRough4XSettings) this).chk_Angledirectionparallel.Name == control.Name)
    {
      ((F_CamRough4XSettings) this).chk_xdirectionparallel.Check = false;
      ((F_CamRough4XSettings) this).chk_ydirectionparallel.Check = false;
      ((F_CamRough4XSettings) this).chk_Angledirectionparallel.Check = false;
      if (((F_CamRough4XSettings) this).chk_xdirectionparallel.Name == control.Name)
        ((F_CamRough4XSettings) this).chk_xdirectionparallel.Check = true;
      if (((F_CamRough4XSettings) this).chk_ydirectionparallel.Name == control.Name)
        ((F_CamRough4XSettings) this).chk_ydirectionparallel.Check = true;
      if (((F_CamRough4XSettings) this).chk_Angledirectionparallel.Name == control.Name)
        ((F_CamRough4XSettings) this).chk_Angledirectionparallel.Check = true;
    }
    if (((F_CamRough4XSettings) this).chk_cornerlowerleftparallel.Name == control.Name | ((F_CamRough4XSettings) this).chk_cornerlowerrightparallel.Name == control.Name | ((F_CamRough4XSettings) this).chk_cornerupperleftparallel.Name == control.Name | ((F_CamRough4XSettings) this).chk_cornerupperrightparallel.Name == control.Name)
    {
      ((F_CamRough4XSettings) this).chk_cornerlowerleftparallel.Check = false;
      ((F_CamRough4XSettings) this).chk_cornerlowerrightparallel.Check = false;
      ((F_CamRough4XSettings) this).chk_cornerupperleftparallel.Check = false;
      ((F_CamRough4XSettings) this).chk_cornerupperrightparallel.Check = false;
      if (((F_CamRough4XSettings) this).chk_cornerlowerleftparallel.Name == control.Name)
        ((F_CamRough4XSettings) this).chk_cornerlowerleftparallel.Check = true;
      if (((F_CamRough4XSettings) this).chk_cornerlowerrightparallel.Name == control.Name)
        ((F_CamRough4XSettings) this).chk_cornerlowerrightparallel.Check = true;
      if (((F_CamRough4XSettings) this).chk_cornerupperleftparallel.Name == control.Name)
        ((F_CamRough4XSettings) this).chk_cornerupperleftparallel.Check = true;
      if (((F_CamRough4XSettings) this).chk_cornerupperrightparallel.Name == control.Name)
        ((F_CamRough4XSettings) this).chk_cornerupperrightparallel.Check = true;
    }
    if (((F_CamRough4XSettings) this).chk_StartAtbottomconstantZ.Name == control.Name | ((F_CamRough4XSettings) this).chk_StartAttopconstantZ.Name == control.Name)
    {
      ((F_CamRough4XSettings) this).chk_StartAtbottomconstantZ.Check = false;
      ((F_CamRough4XSettings) this).chk_StartAttopconstantZ.Check = false;
      if (((F_CamRough4XSettings) this).chk_StartAtbottomconstantZ.Name == control.Name)
        ((F_CamRough4XSettings) this).chk_StartAtbottomconstantZ.Check = true;
      if (((F_CamRough4XSettings) this).chk_StartAttopconstantZ.Name == control.Name)
        ((F_CamRough4XSettings) this).chk_StartAttopconstantZ.Check = true;
    }
    if (((F_BarCode) this).chk_verticalwallmachineonlyconstantZ.Name == control.Name | ((F_BarCode) this).chk_verticalwallincludeconstantZ.Name == control.Name | ((F_BarCode) this).chk_verticalwallexcludeconstantZ.Name == control.Name)
    {
      ((F_BarCode) this).chk_verticalwallmachineonlyconstantZ.Check = false;
      ((F_BarCode) this).chk_verticalwallincludeconstantZ.Check = false;
      ((F_BarCode) this).chk_verticalwallexcludeconstantZ.Check = false;
      if (((F_BarCode) this).chk_verticalwallmachineonlyconstantZ.Name == control.Name)
        ((F_BarCode) this).chk_verticalwallmachineonlyconstantZ.Check = true;
      if (((F_BarCode) this).chk_verticalwallincludeconstantZ.Name == control.Name)
        ((F_BarCode) this).chk_verticalwallincludeconstantZ.Check = true;
      if (((F_BarCode) this).chk_verticalwallexcludeconstantZ.Name == control.Name)
        ((F_BarCode) this).chk_verticalwallexcludeconstantZ.Check = true;
    }
    if (((buClassViewerColor5) this).chk_flatlandadaptive.Name == control.Name | ((setColorComboControl) this).chk_flatlandoffset.Name == control.Name | ((buClassViewerColor5) this).chk_flatlandparallel.Name == control.Name)
    {
      ((buClassViewerColor5) this).chk_flatlandadaptive.Check = false;
      ((setColorComboControl) this).chk_flatlandoffset.Check = false;
      ((buClassViewerColor5) this).chk_flatlandparallel.Check = false;
      if (((buClassViewerColor5) this).chk_flatlandadaptive.Name == control.Name)
        ((buClassViewerColor5) this).chk_flatlandadaptive.Check = true;
      if (((setColorComboControl) this).chk_flatlandoffset.Name == control.Name)
        ((setColorComboControl) this).chk_flatlandoffset.Check = true;
      if (((buClassViewerColor5) this).chk_flatlandparallel.Name == control.Name)
        ((buClassViewerColor5) this).chk_flatlandparallel.Check = true;
    }
    if (((buClassViewerColor5) this).chk_singlestepawideflatland.Name == control.Name | ((buClassViewerColor5) this).chk_singlestepnarrowandwideflatland.Name == control.Name | ((buClassViewerColor5) this).chk_singlestepnarrowflatland.Name == control.Name)
    {
      ((buClassViewerColor5) this).chk_singlestepawideflatland.Check = false;
      ((buClassViewerColor5) this).chk_singlestepnarrowandwideflatland.Check = false;
      ((buClassViewerColor5) this).chk_singlestepnarrowflatland.Check = false;
      if (((buClassViewerColor5) this).chk_singlestepawideflatland.Name == control.Name)
        ((buClassViewerColor5) this).chk_singlestepawideflatland.Check = true;
      if (((buClassViewerColor5) this).chk_singlestepnarrowandwideflatland.Name == control.Name)
        ((buClassViewerColor5) this).chk_singlestepnarrowandwideflatland.Check = true;
      if (((buClassViewerColor5) this).chk_singlestepnarrowflatland.Name == control.Name)
        ((buClassViewerColor5) this).chk_singlestepnarrowflatland.Check = true;
    }
    if (((buClassViewerColor5) this).chk_cutorderfrombottomtotoppencil.Name == control.Name | ((buClassViewerColor5) this).chk_cutorderfromcenterawaypencil.Name == control.Name | ((buClassViewerColor5) this).chk_cutorderfromoutsidetocenterpencil.Name == control.Name | ((buClassViewerColor5) this).chk_cutorderfromtoptobottompencil.Name == control.Name | ((buClassViewerColor5) this).chk_cutorderstandartpencil.Name == control.Name)
    {
      ((buClassViewerColor5) this).chk_cutorderfrombottomtotoppencil.Check = false;
      ((buClassViewerColor5) this).chk_cutorderfromcenterawaypencil.Check = false;
      ((buClassViewerColor5) this).chk_cutorderfromoutsidetocenterpencil.Check = false;
      ((buClassViewerColor5) this).chk_cutorderfromtoptobottompencil.Check = false;
      ((buClassViewerColor5) this).chk_cutorderstandartpencil.Check = false;
      if (((buClassViewerColor5) this).chk_cutorderfrombottomtotoppencil.Name == control.Name)
        ((buClassViewerColor5) this).chk_cutorderfrombottomtotoppencil.Check = true;
      if (((buClassViewerColor5) this).chk_cutorderfromcenterawaypencil.Name == control.Name)
        ((buClassViewerColor5) this).chk_cutorderfromcenterawaypencil.Check = true;
      if (((buClassViewerColor5) this).chk_cutorderfromoutsidetocenterpencil.Name == control.Name)
        ((buClassViewerColor5) this).chk_cutorderfromoutsidetocenterpencil.Check = true;
      if (((buClassViewerColor5) this).chk_cutorderfromtoptobottompencil.Name == control.Name)
        ((buClassViewerColor5) this).chk_cutorderfromtoptobottompencil.Check = true;
      if (((buClassViewerColor5) this).chk_cutorderstandartpencil.Name == control.Name)
        ((buClassViewerColor5) this).chk_cutorderstandartpencil.Check = true;
    }
    if (((buClassViewer5) this).chk_cutorderfrombottomtotopConstcusp.Name == control.Name | ((buClassViewer5) this).chk_cutorderfromcenterawayConstcusp.Name == control.Name | ((buClassViewer5) this).chk_cutorderfromoutsidetocenterConstcusp.Name == control.Name | ((buClassViewer5) this).chk_cutorderfromtoptobottomConstcusp.Name == control.Name | ((buClassViewer5) this).chk_cutorderstandartConstcusp.Name == control.Name)
    {
      ((buClassViewer5) this).chk_cutorderfrombottomtotopConstcusp.Check = false;
      ((buClassViewer5) this).chk_cutorderfromcenterawayConstcusp.Check = false;
      ((buClassViewer5) this).chk_cutorderfromoutsidetocenterConstcusp.Check = false;
      ((buClassViewer5) this).chk_cutorderfromtoptobottomConstcusp.Check = false;
      ((buClassViewer5) this).chk_cutorderstandartConstcusp.Check = false;
      if (((buClassViewer5) this).chk_cutorderfrombottomtotopConstcusp.Name == control.Name)
        ((buClassViewer5) this).chk_cutorderfrombottomtotopConstcusp.Check = true;
      if (((buClassViewer5) this).chk_cutorderfromcenterawayConstcusp.Name == control.Name)
        ((buClassViewer5) this).chk_cutorderfromcenterawayConstcusp.Check = true;
      if (((buClassViewer5) this).chk_cutorderfromoutsidetocenterConstcusp.Name == control.Name)
        ((buClassViewer5) this).chk_cutorderfromoutsidetocenterConstcusp.Check = true;
      if (((buClassViewer5) this).chk_cutorderfromtoptobottomConstcusp.Name == control.Name)
        ((buClassViewer5) this).chk_cutorderfromtoptobottomConstcusp.Check = true;
      if (((buClassViewer5) this).chk_cutorderstandartConstcusp.Name == control.Name)
        ((buClassViewer5) this).chk_cutorderstandartConstcusp.Check = true;
    }
    if (((buClassViewer5) this).chk_stepdirbothConstcusp.Name == control.Name | ((buClassViewer5) this).chk_stepdirleftConstcusp.Name == control.Name | ((buClassViewer5) this).chk_stepdirrightConstcusp.Name == control.Name)
    {
      ((buClassViewer5) this).chk_stepdirbothConstcusp.Check = false;
      ((buClassViewer5) this).chk_stepdirleftConstcusp.Check = false;
      ((buClassViewer5) this).chk_stepdirrightConstcusp.Check = false;
      if (((buClassViewer5) this).chk_stepdirbothConstcusp.Name == control.Name)
        ((buClassViewer5) this).chk_stepdirbothConstcusp.Check = true;
      if (((buClassViewer5) this).chk_stepdirleftConstcusp.Name == control.Name)
        ((buClassViewer5) this).chk_stepdirleftConstcusp.Check = true;
      if (((buClassViewer5) this).chk_stepdirrightConstcusp.Name == control.Name)
        ((buClassViewer5) this).chk_stepdirrightConstcusp.Check = true;
    }
    if (((F_Printer3DSettings) this).chk_silhouettenone.Name == control.Name | ((F_Printer3DSettings) this).chk_silhouettepart.Name == control.Name | ((F_Printer3DSettings) this).chk_silhouettepartend.Name == control.Name | ((F_Printer3DSettings) this).chk_silhouettetoolcontact.Name == control.Name)
    {
      ((F_Printer3DSettings) this).chk_silhouettenone.Check = false;
      ((F_Printer3DSettings) this).chk_silhouettepart.Check = false;
      ((F_Printer3DSettings) this).chk_silhouettepartend.Check = false;
      ((F_Printer3DSettings) this).chk_silhouettetoolcontact.Check = false;
      if (((F_Printer3DSettings) this).chk_silhouettenone.Name == control.Name)
        ((F_Printer3DSettings) this).chk_silhouettenone.Check = true;
      if (((F_Printer3DSettings) this).chk_silhouettepart.Name == control.Name)
        ((F_Printer3DSettings) this).chk_silhouettepart.Check = true;
      if (((F_Printer3DSettings) this).chk_silhouettepartend.Name == control.Name)
        ((F_Printer3DSettings) this).chk_silhouettepartend.Check = true;
      if (((F_Printer3DSettings) this).chk_silhouettetoolcontact.Name == control.Name)
        ((F_Printer3DSettings) this).chk_silhouettetoolcontact.Check = true;
    }
    if (((buClassViewer5) this).chk_anglerangebetweenslopeangles.Name == control.Name | ((buClassViewer5) this).chk_anglerangeoutsideslopeangles.Name == control.Name)
    {
      ((buClassViewer5) this).chk_anglerangebetweenslopeangles.Check = false;
      ((buClassViewer5) this).chk_anglerangeoutsideslopeangles.Check = false;
      if (((buClassViewer5) this).chk_anglerangebetweenslopeangles.Name == control.Name)
        ((buClassViewer5) this).chk_anglerangebetweenslopeangles.Check = true;
      if (((buClassViewer5) this).chk_anglerangeoutsideslopeangles.Name == control.Name)
        ((buClassViewer5) this).chk_anglerangeoutsideslopeangles.Check = true;
    }
    if (((F_Printer3DSettings) this).chk_notbetilted.Name == control.Name | ((F_Printer3DSettings) this).chk_betiltedeleative.Name == control.Name | ((F_Printer3DSettings) this).chk_tiltedwithfixangle.Name == control.Name)
    {
      ((F_Printer3DSettings) this).chk_notbetilted.Check = false;
      ((F_Printer3DSettings) this).chk_betiltedeleative.Check = false;
      ((F_Printer3DSettings) this).chk_tiltedwithfixangle.Check = false;
      if (((F_Printer3DSettings) this).chk_notbetilted.Name == control.Name)
        ((F_Printer3DSettings) this).chk_notbetilted.Check = true;
      if (((F_Printer3DSettings) this).chk_betiltedeleative.Name == control.Name)
        ((F_Printer3DSettings) this).chk_betiltedeleative.Check = true;
      if (((F_Printer3DSettings) this).chk_tiltedwithfixangle.Name == control.Name)
        ((F_Printer3DSettings) this).chk_tiltedwithfixangle.Check = true;
    }
    if (((F_Printer3DSettings) this).chk_orthotocutdirection.Name == control.Name | ((F_Printer3DSettings) this).chk_usespindlemaindir.Name == control.Name | ((F_Printer3DSettings) this).chk_followsurfaceisodir.Name == control.Name)
    {
      ((F_Printer3DSettings) this).chk_followsurfaceisodir.Check = false;
      ((F_Printer3DSettings) this).chk_betiltedeleative.Check = false;
      ((F_Printer3DSettings) this).chk_tiltedwithfixangle.Check = false;
      if (((F_Printer3DSettings) this).chk_followsurfaceisodir.Name == control.Name)
        ((F_Printer3DSettings) this).chk_followsurfaceisodir.Check = true;
      if (((F_Printer3DSettings) this).chk_orthotocutdirection.Name == control.Name)
        ((F_Printer3DSettings) this).chk_orthotocutdirection.Check = true;
      if (((F_Printer3DSettings) this).chk_usespindlemaindir.Name == control.Name)
        ((F_Printer3DSettings) this).chk_usespindlemaindir.Check = true;
    }
    if (((F_Printer3DSettings) this).chk_tiltXAxis.Name == control.Name | ((F_Printer3DSettings) this).chk_tiltYAxis.Name == control.Name | ((F_Printer3DSettings) this).chk_tiltZAxis.Name == control.Name)
    {
      ((F_Printer3DSettings) this).chk_tiltXAxis.Check = false;
      ((F_Printer3DSettings) this).chk_tiltYAxis.Check = false;
      ((F_Printer3DSettings) this).chk_tiltZAxis.Check = false;
      if (((F_Printer3DSettings) this).chk_tiltXAxis.Name == control.Name)
        ((F_Printer3DSettings) this).chk_tiltXAxis.Check = true;
      if (((F_Printer3DSettings) this).chk_tiltYAxis.Name == control.Name)
        ((F_Printer3DSettings) this).chk_tiltYAxis.Check = true;
      if (((F_Printer3DSettings) this).chk_tiltZAxis.Name == control.Name)
        ((F_Printer3DSettings) this).chk_tiltZAxis.Check = true;
    }
    if (((buEntityUpdateType) this).chk_contantstepovergeodesic.Name == control.Name | ((buEntityUpdateType) this).chk_maxstepovergeodesic.Name == control.Name | ((buEntityUtilities) this).chk_autonocutgeodesic.Name == control.Name)
    {
      ((buEntityUpdateType) this).chk_contantstepovergeodesic.Check = false;
      ((buEntityUpdateType) this).chk_maxstepovergeodesic.Check = false;
      ((buEntityUtilities) this).chk_autonocutgeodesic.Check = false;
      if (((buEntityUpdateType) this).chk_contantstepovergeodesic.Name == control.Name)
        ((buEntityUpdateType) this).chk_contantstepovergeodesic.Check = true;
      if (((buEntityUpdateType) this).chk_maxstepovergeodesic.Name == control.Name)
        ((buEntityUpdateType) this).chk_maxstepovergeodesic.Check = true;
      if (((buEntityUtilities) this).chk_autonocutgeodesic.Name == control.Name)
        ((buEntityUtilities) this).chk_autonocutgeodesic.Check = true;
    }
    if (((F_ClassViewerColorDialog5) this).chk_zigzaggeodesic.Name == control.Name | ((F_ClassViewerColorDialog5) this).chk_onewaygeodesic.Name == control.Name | ((F_ClassViewerColorDialog5) this).chk_spiralgeodesic.Name == control.Name)
    {
      ((F_ClassViewerColorDialog5) this).chk_zigzaggeodesic.Check = false;
      ((F_ClassViewerColorDialog5) this).chk_onewaygeodesic.Check = false;
      ((F_ClassViewerColorDialog5) this).chk_spiralgeodesic.Check = false;
      if (((F_ClassViewerColorDialog5) this).chk_zigzaggeodesic.Name == control.Name)
        ((F_ClassViewerColorDialog5) this).chk_zigzaggeodesic.Check = true;
      if (((F_ClassViewerColorDialog5) this).chk_onewaygeodesic.Name == control.Name)
        ((F_ClassViewerColorDialog5) this).chk_onewaygeodesic.Check = true;
      if (((F_ClassViewerColorDialog5) this).chk_spiralgeodesic.Name == control.Name)
        ((F_ClassViewerColorDialog5) this).chk_spiralgeodesic.Check = true;
    }
    if (((F_ClassViewerColorDialog5) this).chk_levelgeodesic.Name == control.Name | ((F_ClassViewerColorDialog5) this).chk_regiongeodesic.Name == control.Name)
    {
      ((F_ClassViewerColorDialog5) this).chk_levelgeodesic.Check = false;
      ((F_ClassViewerColorDialog5) this).chk_regiongeodesic.Check = false;
      if (((F_ClassViewerColorDialog5) this).chk_levelgeodesic.Name == control.Name)
        ((F_ClassViewerColorDialog5) this).chk_levelgeodesic.Check = true;
      if (((F_ClassViewerColorDialog5) this).chk_regiongeodesic.Name == control.Name)
        ((F_ClassViewerColorDialog5) this).chk_regiongeodesic.Check = true;
    }
    if (((buClassViewer5) this).chk_toolcentermodegeodesic.Name == control.Name | ((buClassViewer5) this).chk_contactmodegeodesic.Name == control.Name)
    {
      ((buClassViewer5) this).chk_toolcentermodegeodesic.Check = false;
      ((buClassViewer5) this).chk_contactmodegeodesic.Check = false;
      if (((buClassViewer5) this).chk_toolcentermodegeodesic.Name == control.Name)
        ((buClassViewer5) this).chk_toolcentermodegeodesic.Check = true;
      if (((buClassViewer5) this).chk_contactmodegeodesic.Name == control.Name)
        ((buClassViewer5) this).chk_contactmodegeodesic.Check = true;
    }
    if (((F_ClassViewerDialog5) this).chk_paralleltomultiplecurvegeodesic.Name == control.Name | ((F_ClassViewerDialog5) this).chk_morphbetweentwocurvegeodesic.Name == control.Name)
    {
      ((F_ClassViewerDialog5) this).chk_paralleltomultiplecurvegeodesic.Check = false;
      ((F_ClassViewerDialog5) this).chk_morphbetweentwocurvegeodesic.Check = false;
      if (((F_ClassViewerDialog5) this).chk_paralleltomultiplecurvegeodesic.Name == control.Name)
        ((F_ClassViewerDialog5) this).chk_paralleltomultiplecurvegeodesic.Check = true;
      if (((F_ClassViewerDialog5) this).chk_morphbetweentwocurvegeodesic.Name == control.Name)
        ((F_ClassViewerDialog5) this).chk_morphbetweentwocurvegeodesic.Check = true;
    }
    if (((F_ClassViewerDialog5) this).chk_cointainmentgeodesic.Name == control.Name | ((F_ClassViewerDialog5) this).chk_medialaxisofcontainmentgeodesic.Name == control.Name | ((F_ClassViewerDialog5) this).chk_circleatcentercontainmentgeodesic.Name == control.Name | ((F_ClassViewerDialog5) this).chk_boundrycurvesmachiningsurfacegeodesic.Name == control.Name | ((F_ClassViewerDialog5) this).chk_userdefinescurves.Name == control.Name)
    {
      ((F_ClassViewerDialog5) this).chk_userdefinescurves.Check = false;
      ((F_ClassViewerDialog5) this).chk_cointainmentgeodesic.Check = false;
      ((F_ClassViewerDialog5) this).chk_medialaxisofcontainmentgeodesic.Check = false;
      ((F_ClassViewerDialog5) this).chk_circleatcentercontainmentgeodesic.Check = false;
      ((F_ClassViewerDialog5) this).chk_boundrycurvesmachiningsurfacegeodesic.Check = false;
      if (((F_ClassViewerDialog5) this).chk_userdefinescurves.Name == control.Name)
        ((F_ClassViewerDialog5) this).chk_userdefinescurves.Check = true;
      if (((F_ClassViewerDialog5) this).chk_cointainmentgeodesic.Name == control.Name)
        ((F_ClassViewerDialog5) this).chk_cointainmentgeodesic.Check = true;
      if (((F_ClassViewerDialog5) this).chk_medialaxisofcontainmentgeodesic.Name == control.Name)
        ((F_ClassViewerDialog5) this).chk_medialaxisofcontainmentgeodesic.Check = true;
      if (((F_ClassViewerDialog5) this).chk_circleatcentercontainmentgeodesic.Name == control.Name)
        ((F_ClassViewerDialog5) this).chk_circleatcentercontainmentgeodesic.Check = true;
      if (((F_ClassViewerDialog5) this).chk_boundrycurvesmachiningsurfacegeodesic.Name == control.Name)
        ((F_ClassViewerDialog5) this).chk_boundrycurvesmachiningsurfacegeodesic.Check = true;
    }
    if (((F_ClassViewerDialog5) this).chk_automaticcontainmentgeodesic.Name == control.Name | ((F_ClassViewerDialog5) this).chk_userdefinecontainmentgeodesic.Name == control.Name | ((buEntityUpdateType) this).chk_sillhouttegeodesic.Name == control.Name | ((buEntityUpdateType) this).chk_userdefinecontainmentsillhouttegeodesic.Name == control.Name)
    {
      ((buEntityUpdateType) this).chk_userdefinecontainmentsillhouttegeodesic.Check = false;
      ((F_ClassViewerDialog5) this).chk_automaticcontainmentgeodesic.Check = false;
      ((F_ClassViewerDialog5) this).chk_userdefinecontainmentgeodesic.Check = false;
      ((buEntityUpdateType) this).chk_sillhouttegeodesic.Check = false;
      if (((buEntityUpdateType) this).chk_userdefinecontainmentsillhouttegeodesic.Name == control.Name)
        ((buEntityUpdateType) this).chk_userdefinecontainmentsillhouttegeodesic.Check = true;
      if (((F_ClassViewerDialog5) this).chk_automaticcontainmentgeodesic.Name == control.Name)
        ((F_ClassViewerDialog5) this).chk_automaticcontainmentgeodesic.Check = true;
      if (((F_ClassViewerDialog5) this).chk_userdefinecontainmentgeodesic.Name == control.Name)
        ((F_ClassViewerDialog5) this).chk_userdefinecontainmentgeodesic.Check = true;
      if (((buEntityUpdateType) this).chk_sillhouttegeodesic.Name == control.Name)
        ((buEntityUpdateType) this).chk_sillhouttegeodesic.Check = true;
    }
    if (((buClassViewer5) this).chk_cutorderstandartgeodesic.Name == control.Name | ((buClassViewer5) this).chk_cutorderfromcenterawaygeodesic.Name == control.Name | ((buClassViewer5) this).chk_cutorderfromoutsidetocentergeodesic.Name == control.Name | ((buClassViewer5) this).chk_cutorderwipefromdirectiongeodesic.Name == control.Name)
    {
      ((buClassViewer5) this).chk_cutorderwipefromdirectiongeodesic.Check = false;
      ((buClassViewer5) this).chk_cutorderfromoutsidetocentergeodesic.Check = false;
      ((buClassViewer5) this).chk_cutorderfromcenterawaygeodesic.Check = false;
      ((buClassViewer5) this).chk_cutorderstandartgeodesic.Check = false;
      if (((buClassViewer5) this).chk_cutorderwipefromdirectiongeodesic.Name == control.Name)
        ((buClassViewer5) this).chk_cutorderwipefromdirectiongeodesic.Check = true;
      if (((buClassViewer5) this).chk_cutorderfromoutsidetocentergeodesic.Name == control.Name)
        ((buClassViewer5) this).chk_cutorderfromoutsidetocentergeodesic.Check = true;
      if (((buClassViewer5) this).chk_cutorderfromcenterawaygeodesic.Name == control.Name)
        ((buClassViewer5) this).chk_cutorderfromcenterawaygeodesic.Check = true;
      if (((buClassViewer5) this).chk_cutorderstandartgeodesic.Name == control.Name)
        ((buClassViewer5) this).chk_cutorderstandartgeodesic.Check = true;
    }
    if (((buEntityUpdateType) this).chk_cwprojection.Name == control.Name | ((buEntityUpdateType) this).chk_ccwprojection.Name == control.Name)
    {
      ((buEntityUpdateType) this).chk_cwprojection.Check = false;
      ((buEntityUpdateType) this).chk_ccwprojection.Check = false;
      if (((buEntityUpdateType) this).chk_cwprojection.Name == control.Name)
        ((buEntityUpdateType) this).chk_cwprojection.Check = true;
      if (((buEntityUpdateType) this).chk_ccwprojection.Name == control.Name)
        ((buEntityUpdateType) this).chk_ccwprojection.Check = true;
    }
    if (((buEntityUpdateType) this).chk_slicesProjection.Name == control.Name | ((buEntityUpdateType) this).chk_passesProjection.Name == control.Name)
    {
      ((buEntityUpdateType) this).chk_slicesProjection.Check = false;
      ((buEntityUpdateType) this).chk_passesProjection.Check = false;
      if (((buEntityUpdateType) this).chk_slicesProjection.Name == control.Name)
        ((buEntityUpdateType) this).chk_slicesProjection.Check = true;
      if (((buEntityUpdateType) this).chk_passesProjection.Name == control.Name)
        ((buEntityUpdateType) this).chk_passesProjection.Check = true;
    }
    if (!(((buEntityUpdateType) this).chk_cutorderfromcenterProjection.Name == control.Name | ((buEntityUpdateType) this).chk_cutorderfromoutsideProjection.Name == control.Name | ((buEntityUpdateType) this).chk_cutorderstandartProjection.Name == control.Name))
      return;
    ((buEntityUpdateType) this).chk_cutorderstandartProjection.Check = false;
    ((buEntityUpdateType) this).chk_cutorderfromoutsideProjection.Check = false;
    ((buEntityUpdateType) this).chk_cutorderfromcenterProjection.Check = false;
    if (((buEntityUpdateType) this).chk_cutorderstandartProjection.Name == control.Name)
      ((buEntityUpdateType) this).chk_cutorderstandartProjection.Check = true;
    if (((buEntityUpdateType) this).chk_cutorderfromoutsideProjection.Name == control.Name)
      ((buEntityUpdateType) this).chk_cutorderfromoutsideProjection.Check = true;
    if (!(((buEntityUpdateType) this).chk_cutorderfromcenterProjection.Name == control.Name))
      return;
    ((buEntityUpdateType) this).chk_cutorderfromcenterProjection.Check = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CamSettings1) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CamSettings1) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }

  static buEntity() => F_CamSettings1.Captions = new List<string>();

  public buEntity()
  {
    ((buEntityUpdateType) this).PropertiesForm = new FormProperties();
    ((buEntityUpdateType) this).Settings = new camParameters5();
    ((buEntityUpdateType) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    ((Form) this).\u002Ector();
    \u0007.\u0001.\u0001((F_CamParallelCutSettings) this);
  }

  public void Init()
  {
    ((buEntityUpdateType) this).PropertiesForm.Inited = false;
    if (((buEntityUpdateType) this).PropertiesForm.Height > 10)
      ((Control) this).Height = ((buEntityUpdateType) this).PropertiesForm.Height;
    if (((buEntityUpdateType) this).PropertiesForm.Width > 10)
      ((Control) this).Width = ((buEntityUpdateType) this).PropertiesForm.Width;
    ((Form) this).TopMost = ((buEntityUpdateType) this).PropertiesForm.TopMost;
    ((Form) this).StartPosition = ((buEntityUpdateType) this).PropertiesForm.FormPosition;
    this.spn_depthendoffset.Value = ((buEntityUpdateType) this).Settings.Steps.EndOffset;
    ((buEntityUpdateType) this).spn_depthstartoffset.Value = ((buEntityUpdateType) this).Settings.Steps.StartOffset;
    this.spn_safedistance.Value = ((buEntityUpdateType) this).Settings.Distances.Safe;
    this.spn_rapiddistance.Value = ((camMaterial5) ((buEntityUpdateType) this).Settings.Distances).Rapid;
    this.spn_sufaceoffset.Value = ((buEntityUpdateType) this).Settings.Operations.SurfaceOffset;
    ((buEntityUpdateType) this).spn_toolstepover.Value = ((buEntityUpdateType) this).Settings.Operations.Stepover;
    this.spn_cuttingspeed.Value = ((buEntityUpdateType) this).Settings.Speeds.Feed;
    this.spn_plungespeed.Value = ((buEntityUpdateType) this).Settings.Speeds.Plunge;
    if (((camOptions5) ((buEntityUpdateType) this).Settings.Operations).isCircularCam)
    {
      if (((buEntityUpdateType) this).Settings.Strategy.RotaryAxis == VectorType.YVector)
      {
        ((buEntityUpdateType) this).spn_bottomoffst.Value = ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMaxOffset.Y;
        ((buEntityUpdateType) this).spn_topoffet.Value = ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMinOffset.Y;
        this.spn_rightoffset.Value = ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMaxOffset.X;
        this.spn_leftoffset.Value = ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMinOffset.X;
      }
      if (((buEntityUpdateType) this).Settings.Strategy.RotaryAxis == VectorType.XVector)
      {
        ((buEntityUpdateType) this).spn_bottomoffst.Value = ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMaxOffset.X;
        ((buEntityUpdateType) this).spn_topoffet.Value = ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMinOffset.X;
        this.spn_rightoffset.Value = ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMinOffset.Y;
        this.spn_leftoffset.Value = ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMaxOffset.Y;
      }
    }
    else
    {
      ((buEntityUpdateType) this).spn_bottomoffst.Value = ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMinOffset.Y;
      ((buEntityUpdateType) this).spn_topoffet.Value = ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMaxOffset.Y;
      this.spn_rightoffset.Value = ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMaxOffset.X;
      this.spn_leftoffset.Value = ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMinOffset.X;
    }
    ((buEntityUpdateType) this).PropertiesForm.Result = DialogResult.None;
    ((buEntityUpdateType) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_CamParallelCutSettings) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((buEntityUpdateType) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((buEntityUpdateType) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((buEntityUpdateType) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
    {
      // ISSUE: explicit non-virtual call
      __nonvirtual (((Component) this).Dispose());
    }
    if (((buEntityUpdateType) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    ((Control) this).Visible = false;
  }

  public void Apply()
  {
    ((buEntityUpdateType) this).Settings.Operations.SurfaceOffset = this.spn_sufaceoffset.Value;
    ((buEntityUpdateType) this).Settings.Operations.Stepover = ((buEntityUpdateType) this).spn_toolstepover.Value;
    ((buEntityUpdateType) this).Settings.Speeds.Feed = this.spn_cuttingspeed.Value;
    ((buEntityUpdateType) this).Settings.Speeds.Plunge = this.spn_plungespeed.Value;
    ((buEntityUpdateType) this).Settings.Steps.EndOffset = this.spn_depthendoffset.Value;
    ((buEntityUpdateType) this).Settings.Steps.StartOffset = ((buEntityUpdateType) this).spn_depthstartoffset.Value;
    ((buEntityUpdateType) this).Settings.Distances.Safe = this.spn_safedistance.Value;
    ((camMaterial5) ((buEntityUpdateType) this).Settings.Distances).Rapid = this.spn_rapiddistance.Value;
    if (((camOptions5) ((buEntityUpdateType) this).Settings.Operations).isCircularCam)
    {
      if (((buEntityUpdateType) this).Settings.Strategy.RotaryAxis == VectorType.YVector)
      {
        ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMaxOffset.Y = ((buEntityUpdateType) this).spn_bottomoffst.Value;
        ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMinOffset.Y = ((buEntityUpdateType) this).spn_topoffet.Value;
        ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMaxOffset.X = this.spn_rightoffset.Value;
        ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMinOffset.X = this.spn_leftoffset.Value;
      }
      if (((buEntityUpdateType) this).Settings.Strategy.RotaryAxis != VectorType.XVector)
        return;
      ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMaxOffset.X = ((buEntityUpdateType) this).spn_bottomoffst.Value;
      ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMinOffset.X = ((buEntityUpdateType) this).spn_topoffet.Value;
      ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMinOffset.Y = this.spn_rightoffset.Value;
      ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMaxOffset.Y = this.spn_leftoffset.Value;
    }
    else
    {
      ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMinOffset.Y = ((buEntityUpdateType) this).spn_bottomoffst.Value;
      ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMaxOffset.Y = ((buEntityUpdateType) this).spn_topoffet.Value;
      ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMaxOffset.X = this.spn_rightoffset.Value;
      ((camOptions5) ((buEntityUpdateType) this).Settings.Operations).BorderMinOffset.X = this.spn_leftoffset.Value;
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((buEntityUpdateType) this).btn_ok.Name)
      {
        this.Apply();
        ((buEntityUpdateType) this).PropertiesForm.Result = DialogResult.OK;
        if (((buEntityUpdateType) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        {
          // ISSUE: explicit non-virtual call
          __nonvirtual (((Component) this).Dispose());
        }
        if (((buEntityUpdateType) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          ((Control) this).Visible = false;
      }
      if (control2.Name == ((buEntityUpdateType) this).btn_close.Name | control2.Name == ((buEntityUpdateType) this).btn_cancel.Name)
      {
        ((buEntityUpdateType) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((buEntityUpdateType) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        {
          // ISSUE: explicit non-virtual call
          __nonvirtual (((Component) this).Dispose());
        }
        if (((buEntityUpdateType) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          ((Control) this).Visible = false;
      }
      if (!(control2.Name == this.btn_4_5AxesSettings.Name))
        return;
      F_Cam4And5AxisSettings and5AxisSettings = (F_Cam4And5AxisSettings) new buEntity();
      ((buEntity) and5AxisSettings).Settings = ((buEntityUpdateType) this).Settings;
      ((buEntity) and5AxisSettings).PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
      ((buEntity) and5AxisSettings).PropertiesForm.FormPosition = FormStartPosition.CenterParent;
      ((buEntity) and5AxisSettings).Init();
      int num = (int) and5AxisSettings.ShowDialog();
      if (((buEntity) and5AxisSettings).PropertiesForm.Result != DialogResult.OK)
        return;
      ((buEntityUpdateType) this).Settings = ((buEntity) and5AxisSettings).Settings;
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((buEntityUpdateType) this).PropertiesForm.Inited)
      return;
    (obj0 as buSpin).SelectAll();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((buEntityUpdateType) this).\u0001 != null ? 1 : 0)) != 0)
      ((buEntityUpdateType) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }

  static buEntity() => buEntityUpdateType.Captions = new List<string>();

  public buEntity()
  {
    // ISSUE: explicit constructor call
    ((Form) this).\u002Ector();
    \u0007.\u0001.\u0001((F_Cam4And5AxisSettings) this);
  }

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      ((Control) this).Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      ((Control) this).Width = this.PropertiesForm.Width;
    ((Form) this).TopMost = this.PropertiesForm.TopMost;
    ((Form) this).StartPosition = this.PropertiesForm.FormPosition;
    ((buArc) this).spn_SideTiltAngle.Value = this.Settings.Rotary.SideTiltAngle;
    ((buArc) this).spn_LagAngle.Value = this.Settings.Rotary.LagAngle;
    ((buCircle) this).spn_MaxAngleChange.Value = this.Settings.Rotary.MaxAngleChange;
    ((buCurve) this).spn_smoothmaxtiltangle.Value = ((camHatch5) this.Settings.Rotary).MaxAngleFromInitialToolOrientation;
    ((buCircle) this).spn_BAngleLimitEndInXZPlane.Value = ((camStrategy5) this.Settings.Rotary).BAngleLimitEndInXZPlane;
    ((buCircle) this).spn_BAngleLimitStartInXZPlane.Value = ((camStrategy5) this.Settings.Rotary).BAngleLimitStartInXZPlane;
    ((buArc) this).spn_AAngleLimitStartInYZPlane.Value = ((camStrategy5) this.Settings.Rotary).AAngleLimitStartInYZPlane;
    ((buArc) this).spn_AAngleLimitEndInYZPlane.Value = ((camStrategy5) this.Settings.Rotary).AAngleLimitEndInYZPlane;
    ((buEllipse) this).spn_CAngleLimitEndInXYPlane.Value = ((camStrategy5) this.Settings.Rotary).CAngleLimitEndInXYPlane;
    ((buEllipse) this).spn_CAngleLimitStartInXYPlane.Value = ((camStrategy5) this.Settings.Rotary).CAngleLimitStartInXYPlane;
    ((buEllipse) this).spn_WOrtAngleLimitEnd.Value = ((camStrategy5) this.Settings.Rotary).WOrtAngleLimitEnd;
    ((buEllipse) this).spn_WOrtAngleLimitStart.Value = ((camStrategy5) this.Settings.Rotary).WOrtAngleLimitStart;
    ((buCurve) this).chk_AAngleLimit.Check = ((camStrategy5) this.Settings.Rotary).AAngleLimitInYZPlaneFlg;
    ((buEllipse) this).chk_BAngleLimit.Check = ((camStrategy5) this.Settings.Rotary).BAngleLimitInXZPlaneFlg;
    ((buCurve) this).chk_CAngleLimit.Check = ((camStrategy5) this.Settings.Rotary).CAngleLimitInXYPlaneFlg;
    ((buCurve) this).chk_WAngleLimit.Check = ((camStrategy5) this.Settings.Rotary).WOrtAngleLimitFlg;
    ((buCompositeCurve) this).chk_smoot.Check = ((camHatch5) this.Settings.Rotary).SmoothingFlg;
    ((buMesh) this).chk_undercut.Check = ((camHatch5) this.Settings.Rotary).UndercutsFlg;
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_Cam4And5AxisSettings) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
    {
      // ISSUE: explicit non-virtual call
      __nonvirtual (((Component) this).Dispose());
    }
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    ((Control) this).Visible = false;
  }

  public void Apply()
  {
    this.Settings.Rotary.SideTiltAngle = ((buArc) this).spn_SideTiltAngle.Value;
    this.Settings.Rotary.LagAngle = ((buArc) this).spn_LagAngle.Value;
    this.Settings.Rotary.MaxAngleChange = ((buCircle) this).spn_MaxAngleChange.Value;
    ((camHatch5) this.Settings.Rotary).MaxAngleFromInitialToolOrientation = ((buCurve) this).spn_smoothmaxtiltangle.Value;
    ((camStrategy5) this.Settings.Rotary).BAngleLimitEndInXZPlane = ((buCircle) this).spn_BAngleLimitEndInXZPlane.Value;
    ((camStrategy5) this.Settings.Rotary).BAngleLimitStartInXZPlane = ((buCircle) this).spn_BAngleLimitStartInXZPlane.Value;
    ((camStrategy5) this.Settings.Rotary).AAngleLimitStartInYZPlane = ((buArc) this).spn_AAngleLimitStartInYZPlane.Value;
    ((camStrategy5) this.Settings.Rotary).AAngleLimitEndInYZPlane = ((buArc) this).spn_AAngleLimitEndInYZPlane.Value;
    ((camStrategy5) this.Settings.Rotary).CAngleLimitEndInXYPlane = ((buEllipse) this).spn_CAngleLimitEndInXYPlane.Value;
    ((camStrategy5) this.Settings.Rotary).CAngleLimitStartInXYPlane = ((buEllipse) this).spn_CAngleLimitStartInXYPlane.Value;
    ((camStrategy5) this.Settings.Rotary).WOrtAngleLimitEnd = ((buEllipse) this).spn_WOrtAngleLimitEnd.Value;
    ((camStrategy5) this.Settings.Rotary).WOrtAngleLimitStart = ((buEllipse) this).spn_WOrtAngleLimitStart.Value;
    ((camStrategy5) this.Settings.Rotary).AAngleLimitInYZPlaneFlg = ((buCurve) this).chk_AAngleLimit.Check;
    ((camStrategy5) this.Settings.Rotary).BAngleLimitInXZPlaneFlg = ((buEllipse) this).chk_BAngleLimit.Check;
    ((camStrategy5) this.Settings.Rotary).CAngleLimitInXYPlaneFlg = ((buCurve) this).chk_CAngleLimit.Check;
    ((camStrategy5) this.Settings.Rotary).WOrtAngleLimitFlg = ((buCurve) this).chk_WAngleLimit.Check;
    ((camHatch5) this.Settings.Rotary).SmoothingFlg = ((buCompositeCurve) this).chk_smoot.Check;
    ((camHatch5) this.Settings.Rotary).UndercutsFlg = ((buMesh) this).chk_undercut.Check;
    ((camHatch5) this.Settings.Rotary).LimitsFlg = false;
    if (!(((camStrategy5) this.Settings.Rotary).AAngleLimitInYZPlaneFlg | ((camStrategy5) this.Settings.Rotary).BAngleLimitInXZPlaneFlg | ((camStrategy5) this.Settings.Rotary).CAngleLimitInXYPlaneFlg | ((camStrategy5) this.Settings.Rotary).WOrtAngleLimitFlg))
      return;
    ((camHatch5) this.Settings.Rotary).LimitsFlg = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((buArc) this).btn_ok.Name)
      {
        this.Apply();
        this.PropertiesForm.Result = DialogResult.OK;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        {
          // ISSUE: explicit non-virtual call
          __nonvirtual (((Component) this).Dispose());
        }
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          ((Control) this).Visible = false;
      }
      if (!(control2.Name == this.btn_close.Name | control2.Name == ((buArc) this).btn_cancel.Name))
        return;
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (((Component) this).Dispose());
      }
      if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      ((Control) this).Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!this.PropertiesForm.Inited)
      return;
    (obj0 as buSpin).SelectAll();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }

  static buEntity()
  {
  }

  public buEntity()
  {
    ((buLinearDim) this).PropertiesForm = new FormProperties();
    ((buLinearDim) this).Settings = new camParameters5();
    ((buLinearDim) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    ((Form) this).\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_CamStockOffset) this);
  }

  public void Init()
  {
    ((buLinearDim) this).PropertiesForm.Inited = false;
    if (((buLinearDim) this).PropertiesForm.Height > 10)
      ((Control) this).Height = ((buLinearDim) this).PropertiesForm.Height;
    if (((buLinearDim) this).PropertiesForm.Width > 10)
      ((Control) this).Width = ((buLinearDim) this).PropertiesForm.Width;
    ((Form) this).TopMost = ((buLinearDim) this).PropertiesForm.TopMost;
    ((Form) this).StartPosition = ((buLinearDim) this).PropertiesForm.FormPosition;
    ((buAngularDim) this).spn_stockxplusoffset.Value = ((camRotary5) ((buLinearDim) this).Settings.Options).StockOffsetMax.X;
    ((buAngularDim) this).spn_stockxminusoffset.Value = ((camRotary5) ((buLinearDim) this).Settings.Options).StockOffsetMin.X;
    ((buDiametricDim) this).spn_stockyplusoffset.Value = ((camRotary5) ((buLinearDim) this).Settings.Options).StockOffsetMax.Y;
    ((buDiametricDim) this).spn_stockyminusoffset.Value = ((camRotary5) ((buLinearDim) this).Settings.Options).StockOffsetMin.Y;
    ((buAngularDim) this).spn_stockzplusoffset.Value = ((camRotary5) ((buLinearDim) this).Settings.Options).StockOffsetMax.Z;
    ((buAngularDim) this).spn_stockzminusoffset.Value = ((camRotary5) ((buLinearDim) this).Settings.Options).StockOffsetMin.Z;
    ((buAngularDim) this).spn_stocktolorance.Value = ((camRotary5) ((buLinearDim) this).Settings.Options).StockTolarance;
    ((buAngularDim) this).spn_stockoffset.Value = ((camRotary5) ((buLinearDim) this).Settings.Options).StockOffset;
    if (((camRotary5) ((buLinearDim) this).Settings.Options).StockOffsetMode == CamStockOffsetMode.SomExpand)
      ((buDiametricDim) this).\u0002.Checked = true;
    else
      ((buDiametricDim) this).\u0001.Checked = true;
    if (((camRotary5) ((buLinearDim) this).Settings.Options).StockType == CamStockType.StSurfaces)
      ((buOrdinateDim) this).\u0004.Checked = true;
    else if (((camRotary5) ((buLinearDim) this).Settings.Options).StockType == CamStockType.St2dContainment)
      ((buDiametricDim) this).\u0003.Checked = true;
    else
      ((buOrdinateDim) this).\u0005.Checked = true;
    ((buLinearDim) this).PropertiesForm.Result = DialogResult.None;
    ((buLinearDim) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_CamStockOffset) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((buLinearDim) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((buLinearDim) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((buLinearDim) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
    {
      // ISSUE: explicit non-virtual call
      __nonvirtual (((Component) this).Dispose());
    }
    if (((buLinearDim) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    ((Control) this).Visible = false;
  }

  public void Apply()
  {
    ((camRotary5) ((buLinearDim) this).Settings.Options).StockOffsetMax.X = ((buAngularDim) this).spn_stockxplusoffset.Value;
    ((camRotary5) ((buLinearDim) this).Settings.Options).StockOffsetMin.X = ((buAngularDim) this).spn_stockxminusoffset.Value;
    ((camRotary5) ((buLinearDim) this).Settings.Options).StockOffsetMax.Y = ((buDiametricDim) this).spn_stockyplusoffset.Value;
    ((camRotary5) ((buLinearDim) this).Settings.Options).StockOffsetMin.Y = ((buDiametricDim) this).spn_stockyminusoffset.Value;
    ((camRotary5) ((buLinearDim) this).Settings.Options).StockOffsetMax.Z = ((buAngularDim) this).spn_stockzplusoffset.Value;
    ((camRotary5) ((buLinearDim) this).Settings.Options).StockOffsetMin.Z = ((buAngularDim) this).spn_stockzminusoffset.Value;
    ((camRotary5) ((buLinearDim) this).Settings.Options).StockTolarance = ((buAngularDim) this).spn_stocktolorance.Value;
    ((camRotary5) ((buLinearDim) this).Settings.Options).StockOffset = ((buAngularDim) this).spn_stockoffset.Value;
    if (((buDiametricDim) this).\u0002.Checked)
      ((camRotary5) ((buLinearDim) this).Settings.Options).StockOffsetMode = CamStockOffsetMode.SomExpand;
    else
      ((camRotary5) ((buLinearDim) this).Settings.Options).StockOffsetMode = CamStockOffsetMode.SomShrink;
    if (((buDiametricDim) this).\u0003.Checked)
      ((camRotary5) ((buLinearDim) this).Settings.Options).StockType = CamStockType.St2dContainment;
    else if (((buOrdinateDim) this).\u0004.Checked)
      ((camRotary5) ((buLinearDim) this).Settings.Options).StockType = CamStockType.StSurfaces;
    else
      ((camRotary5) ((buLinearDim) this).Settings.Options).StockType = CamStockType.StBoundingBox;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((buAngularDim) this).btn_ok.Name)
      {
        this.Apply();
        ((buLinearDim) this).PropertiesForm.Result = DialogResult.OK;
        if (((buLinearDim) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        {
          // ISSUE: explicit non-virtual call
          __nonvirtual (((Component) this).Dispose());
        }
        if (((buLinearDim) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          ((Control) this).Visible = false;
      }
      if (!(control2.Name == ((buLinearDim) this).btn_close.Name | control2.Name == ((buAngularDim) this).btn_cancel.Name))
        return;
      ((buLinearDim) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((buLinearDim) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (((Component) this).Dispose());
      }
      if (((buLinearDim) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      ((Control) this).Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((buLinearDim) this).PropertiesForm.Inited)
      return;
    (obj0 as buSpin).SelectAll();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((buLinearDim) this).\u0001 != null ? 1 : 0)) != 0)
      ((buLinearDim) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }

  static buEntity() => buLinearDim.Captions = new List<string>();

  public buEntity()
  {
    // ISSUE: unable to decompile the method.
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (buOrdinateDim.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((buOrdinateDim) this).\u0001 != null ? 1 : 0)) != 0)
      ((buOrdinateDim) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }

  static buEntity() => buOrdinateDim.Captions = new List<string>();

  public buEntity()
  {
    ((buRadialDim) this).Properties = new FormProperties();
    ((buText) this).SourceList = new List<string>();
    ((buText) this).TargetList = new List<string>();
    ((buText) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    ((Form) this).\u002Ector();
    \u0007.\u0001.\u0001((F_CamSequence) this);
  }

  public void Init()
  {
    ((buRadialDim) this).Properties.Inited = false;
    if (((buRadialDim) this).Properties.Height > 10)
      ((Control) this).Height = ((buRadialDim) this).Properties.Height;
    if (((buRadialDim) this).Properties.Width > 10)
      ((Control) this).Width = ((buRadialDim) this).Properties.Width;
    ((Form) this).TopMost = ((buRadialDim) this).Properties.TopMost;
    ((Form) this).StartPosition = ((buRadialDim) this).Properties.FormPosition;
    ((buMultilineText) this).\u0001.Items.Clear();
    for (int index = 0; index <= ((buText) this).SourceList.Count - 1; ++index)
      ((buMultilineText) this).\u0001.Items.Add((object) ((buText) this).SourceList[index]);
    ((buMultilineText) this).\u0002.Items.Clear();
    for (int index = 0; index <= ((buText) this).TargetList.Count - 1; ++index)
      ((buMultilineText) this).\u0002.Items.Add((object) ((buText) this).TargetList[index]);
    ((buRadialDim) this).Properties.Result = DialogResult.None;
    ((buRadialDim) this).Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (buText.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((buText) this).btn_ok.Name)
    {
      if (!((buRadialDim) this).Properties.Inited)
        return;
      if (((buRadialDim) this).Properties.ReadOnly)
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (((Component) this).Dispose());
        return;
      }
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_CamSequence) this);
      ((buRadialDim) this).Properties.Result = DialogResult.OK;
      if (((buRadialDim) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (((Component) this).Dispose());
      }
      if (((buRadialDim) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        ((Control) this).Visible = false;
    }
    if (control2.Name == ((buText) this).btn_cancel.Name)
    {
      ((buRadialDim) this).Properties.Result = DialogResult.Cancel;
      if (((buRadialDim) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (((Component) this).Dispose());
      }
      if (((buRadialDim) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        ((Control) this).Visible = false;
    }
    if (control2.Name == ((buMultilineText) this).\u0001.Name && ((buMultilineText) this).\u0001.SelectedIndex >= 0 & ((buMultilineText) this).\u0001.SelectedIndex <= ((buMultilineText) this).\u0001.Items.Count - 1)
    {
      string str = ((buMultilineText) this).\u0001.Items[((buMultilineText) this).\u0001.SelectedIndex].ToString();
      bool flag = false;
      for (int index = 0; index <= ((buMultilineText) this).\u0002.Items.Count - 1; ++index)
      {
        if (str == ((buMultilineText) this).\u0002.Items[index].ToString())
          flag = true;
      }
      if (!flag)
        ((buMultilineText) this).\u0002.Items.Add((object) str);
    }
    if (control2.Name == ((buMultilineText) this).\u0002.Name && ((buMultilineText) this).\u0002.SelectedIndex >= 0 & ((buMultilineText) this).\u0002.SelectedIndex <= ((buMultilineText) this).\u0002.Items.Count - 1 && buNumeric5.MessageBoxQuestion(AppLanguage.CadCamMessages[132]) == DialogResult.Yes)
      ((buMultilineText) this).\u0002.Items.RemoveAt(((buMultilineText) this).\u0002.SelectedIndex);
    if (control2.Name == ((buMultilineText) this).\u0003.Name && ((buMultilineText) this).\u0002.Items.Count >= 0 & ((buMultilineText) this).\u0002.SelectedIndex > 0 & ((buMultilineText) this).\u0002.SelectedIndex <= ((buMultilineText) this).\u0002.Items.Count - 1)
    {
      int selectedIndex = ((buMultilineText) this).\u0002.SelectedIndex;
      string str = ((buMultilineText) this).\u0002.Items[selectedIndex].ToString();
      ((buMultilineText) this).\u0002.Items.RemoveAt(selectedIndex);
      int index = selectedIndex - 1;
      ((buMultilineText) this).\u0002.Items.Insert(index, (object) str);
      ((buMultilineText) this).\u0002.SelectedIndex = index;
    }
    if (!(control2.Name == ((buMultilineText) this).\u0004.Name) || !(((buMultilineText) this).\u0002.Items.Count >= 0 & ((buMultilineText) this).\u0002.SelectedIndex <= ((buMultilineText) this).\u0002.Items.Count - 2 & ((buMultilineText) this).\u0002.SelectedIndex <= ((buMultilineText) this).\u0002.Items.Count - 1))
      return;
    int selectedIndex1 = ((buMultilineText) this).\u0002.SelectedIndex;
    string str1 = ((buMultilineText) this).\u0002.Items[selectedIndex1].ToString();
    ((buMultilineText) this).\u0002.Items.RemoveAt(selectedIndex1);
    int index1 = selectedIndex1 + 1;
    ((buMultilineText) this).\u0002.Items.Insert(index1, (object) str1);
    ((buMultilineText) this).\u0002.SelectedIndex = index1;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((buText) this).\u0001 != null ? 1 : 0)) != 0)
      ((buText) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }

  static buEntity() => buText.Captions = new List<string>();

  public buEntity()
  {
    ((buMultilineText) this).Properties = new FormProperties();
    ((buMultilineText) this).CamPar = new camParameters5();
    ((buEntityList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    ((Form) this).\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_CamSettings1) this);
  }

  public void Init()
  {
    ((buMultilineText) this).Properties.Inited = false;
    if (((buMultilineText) this).Properties.Height > 10)
      ((Control) this).Height = ((buMultilineText) this).Properties.Height;
    if (((buMultilineText) this).Properties.Width > 10)
      ((Control) this).Width = ((buMultilineText) this).Properties.Width;
    ((Form) this).TopMost = ((buMultilineText) this).Properties.TopMost;
    ((Form) this).StartPosition = ((buMultilineText) this).Properties.FormPosition;
    ((buShape) this).spn_vellfeed.Value = (Decimal) ((buMultilineText) this).CamPar.Speeds.Feed;
    ((buEntityList) this).spn_velplunge.Value = (Decimal) ((buMultilineText) this).CamPar.Speeds.Plunge;
    ((buShape) this).spn_velleave.Value = (Decimal) ((buEyeBaseVer5.camSpeedsEnable) ((buMultilineText) this).CamPar.Speeds).Leave;
    ((buEntityList) this).spn_finishvelocity.Value = (Decimal) ((buEyeBaseVer5.camSpeedsEnable) ((buMultilineText) this).CamPar.Speeds).Finish;
    ((buEntityList) this).spn_areaclearancevelocity.Value = (Decimal) ((camDistances5) ((buMultilineText) this).CamPar.Speeds).Pocket;
    ((buShape) this).spn_dissafe.Value = (Decimal) ((buMultilineText) this).CamPar.Distances.Safe;
    ((buShape) this).spn_dissmallsafe.Value = (Decimal) ((camMaterial5) ((buMultilineText) this).CamPar.Distances).Rapid;
    ((buShape) this).spn_finishoffset.Value = (Decimal) ((camStep5) ((buMultilineText) this).CamPar.Offsets).FinishOffset;
    ((buShape) this).spn_stepcount.Value = (Decimal) ((buMultilineText) this).CamPar.Steps.NumberOfSlice;
    ((buShape) this).\u0001.Value = (Decimal) ((camOperation5) ((buMultilineText) this).CamPar.Pockets).StepOverPersentage;
    ((buShape) this).spn_leadin.Value = (Decimal) ((MWCalculationOptions) ((camRuntime5) ((buMultilineText) this).CamPar).LeadIn).Length;
    ((buShapeRectangle) this).spn_leadout.Value = (Decimal) ((MWCalculationOptions) ((camOffset5) ((buMultilineText) this).CamPar).LeadOut).Length;
    ((buShape) this).\u0002.Checked = ((camOperation5) ((buMultilineText) this).CamPar.Pockets).Enable;
    ((buShape) this).\u0004.Checked = ((buMultilineText) this).CamPar.Operations.FinishEnable;
    ((buShape) this).\u0001.Checked = ((buMultilineText) this).CamPar.Steps.Enable;
    ((buShape) this).\u0003.Checked = ((buMultilineText) this).CamPar.Strategy.OpenContourTwoDirectionCut;
    ((buShape) this).\u0004.Checked = ((buEyeBaseVer5.camSpeedsEnable) ((buMultilineText) this).CamPar.Speeds).FinishEnable;
    if (((camOperation5) ((buMultilineText) this).CamPar.Pockets).PocketInOut == InToOutType.OutToIn)
    {
      ((buEntityList) this).\u0001.Checked = true;
      ((buEntityList) this).\u0002.Checked = false;
    }
    else
    {
      ((buEntityList) this).\u0001.Checked = false;
      ((buEntityList) this).\u0002.Checked = true;
    }
    if (((camOptions5) ((buMultilineText) this).CamPar.Operations).Direction == ClockDirectionType.CW)
    {
      ((buShape) this).\u0004.Checked = true;
      ((buShape) this).\u0003.Checked = false;
    }
    if (((camOptions5) ((buMultilineText) this).CamPar.Operations).Direction == ClockDirectionType.CCW)
    {
      ((buShape) this).\u0004.Checked = false;
      ((buShape) this).\u0003.Checked = true;
    }
    if (((camStep5) ((buMultilineText) this).CamPar.Offsets).ClosedContour == CamClosedContourType.Inner)
    {
      ((buShape) this).\u0006.Checked = false;
      ((buShape) this).\u0005.Checked = false;
      ((buShape) this).\u0007.Checked = true;
    }
    if (((camStep5) ((buMultilineText) this).CamPar.Offsets).ClosedContour == CamClosedContourType.Outter)
    {
      ((buShape) this).\u0006.Checked = false;
      ((buShape) this).\u0005.Checked = true;
      ((buShape) this).\u0007.Checked = false;
    }
    if (((camStep5) ((buMultilineText) this).CamPar.Offsets).ClosedContour == CamClosedContourType.Center)
    {
      ((buShape) this).\u0006.Checked = true;
      ((buShape) this).\u0005.Checked = false;
      ((buShape) this).\u0007.Checked = false;
    }
    if (((camStep5) ((buMultilineText) this).CamPar.Offsets).OpenContour == CamOpenContourType.Center)
    {
      ((buShape) this).\u000E.Checked = true;
      ((buShape) this).\u000F.Checked = false;
      ((buShape) this).\u0008.Checked = false;
    }
    else if (((camStep5) ((buMultilineText) this).CamPar.Offsets).OpenContour == CamOpenContourType.Left)
    {
      ((buShape) this).\u000E.Checked = false;
      ((buShape) this).\u000F.Checked = true;
      ((buShape) this).\u0008.Checked = false;
    }
    else
    {
      ((buShape) this).\u000E.Checked = false;
      ((buShape) this).\u000F.Checked = false;
      ((buShape) this).\u0008.Checked = true;
    }
    ((buMultilineText) this).Properties.Result = DialogResult.None;
    ((buMultilineText) this).Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (buMultilineText.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((buShape) this).btn_ok.Name)
    {
      if (!((buMultilineText) this).Properties.Inited)
        return;
      if (((buMultilineText) this).Properties.ReadOnly)
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (((Component) this).Dispose());
        return;
      }
      \u0007.\u0001.\u0001((F_CamSettings1) this);
      ((buMultilineText) this).Properties.Result = DialogResult.OK;
      if (((buMultilineText) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (((Component) this).Dispose());
      }
      if (((buMultilineText) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        ((Control) this).Visible = false;
    }
    if (!(control2.Name == ((buShape) this).btn_cancel.Name))
      return;
    ((buMultilineText) this).Properties.Result = DialogResult.Cancel;
    if (((buMultilineText) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
    {
      // ISSUE: explicit non-virtual call
      __nonvirtual (((Component) this).Dispose());
    }
    if (((buMultilineText) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    ((Control) this).Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((buEntityList) this).\u0001 != null ? 1 : 0)) != 0)
      ((buEntityList) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }

  static buEntity() => buMultilineText.Captions = new List<string>();

  public buEntity()
  {
    ((buShapeRectangle) this).PropertiesForm = new FormProperties();
    ((buShapeCircle) this).Settings = new camParameters5();
    ((buShapeEllipse) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    ((Form) this).\u002Ector();
    \u0007.\u0001.\u0001((F_CamRough4XSettings) this);
  }

  public void Init()
  {
    ((buShapeRectangle) this).PropertiesForm.Inited = false;
    if (((buShapeRectangle) this).PropertiesForm.Height > 10)
      ((Control) this).Height = ((buShapeRectangle) this).PropertiesForm.Height;
    if (((buShapeRectangle) this).PropertiesForm.Width > 10)
      ((Control) this).Width = ((buShapeRectangle) this).PropertiesForm.Width;
    ((Form) this).TopMost = ((buShapeRectangle) this).PropertiesForm.TopMost;
    ((Form) this).StartPosition = ((buShapeRectangle) this).PropertiesForm.FormPosition;
    ((buShapeSlot) this).spn_depthstep.Value = ((buShapeCircle) this).Settings.Steps.DepthStep;
    ((buShapeKeyHole) this).spn_toolstepover.Value = ((buShapeCircle) this).Settings.Operations.Stepover;
    ((buShapeFreeDraw) this).spn_cuttingspeed.Value = ((buShapeCircle) this).Settings.Speeds.Feed;
    ((buShapeKeyHole) this).spn_plungespeed.Value = ((buShapeCircle) this).Settings.Speeds.Plunge;
    if (((camOptions5) ((buShapeCircle) this).Settings.Operations).isCircularCam)
    {
      if (((buShapeCircle) this).Settings.Strategy.RotaryAxis == VectorType.YVector)
      {
        ((buShapeSlot) this).spn_bottomoffst.Value = ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMaxOffset.Y;
        ((buShapePolygon) this).spn_topoffet.Value = ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMinOffset.Y;
        ((buShapeHole) this).spn_rightoffset.Value = ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMaxOffset.X;
        ((buShapeFreeLines) this).spn_leftoffset.Value = ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMinOffset.X;
      }
      if (((buShapeCircle) this).Settings.Strategy.RotaryAxis == VectorType.XVector)
      {
        ((buShapeSlot) this).spn_bottomoffst.Value = ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMaxOffset.X;
        ((buShapePolygon) this).spn_topoffet.Value = ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMinOffset.X;
        ((buShapeHole) this).spn_rightoffset.Value = ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMinOffset.Y;
        ((buShapeFreeLines) this).spn_leftoffset.Value = ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMaxOffset.Y;
      }
    }
    else
    {
      ((buShapeSlot) this).spn_bottomoffst.Value = ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMinOffset.Y;
      ((buShapePolygon) this).spn_topoffet.Value = ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMaxOffset.Y;
      ((buShapeHole) this).spn_rightoffset.Value = ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMinOffset.X;
      ((buShapeFreeLines) this).spn_leftoffset.Value = ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMaxOffset.X;
    }
    ((buShapeKeyHole) this).spn_depthendoffset.Value = ((buShapeCircle) this).Settings.Steps.EndOffset;
    ((buShapeKeyHole) this).spn_depthstartoffset.Value = ((buShapeCircle) this).Settings.Steps.StartOffset;
    ((buShapeFreeDraw) this).spn_safedistance.Value = ((buShapeCircle) this).Settings.Distances.Safe;
    ((buShapeFreeDraw) this).spn_rapiddistance.Value = ((camMaterial5) ((buShapeCircle) this).Settings.Distances).Rapid;
    ((buShapeRectangle) this).PropertiesForm.Result = DialogResult.None;
    ((buShapeRectangle) this).PropertiesForm.Inited = true;
    \u0001.\u0002.\u0001((F_CamRough4XSettings) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((buShapeRectangle) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((buShapeRectangle) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((buShapeRectangle) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
    {
      // ISSUE: explicit non-virtual call
      __nonvirtual (((Component) this).Dispose());
    }
    if (((buShapeRectangle) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    ((Control) this).Visible = false;
  }

  public void Apply()
  {
    ((buShapeCircle) this).Settings.Steps.DepthStep = ((buShapeSlot) this).spn_depthstep.Value;
    ((buShapeCircle) this).Settings.Operations.Stepover = ((buShapeKeyHole) this).spn_toolstepover.Value;
    ((buShapeCircle) this).Settings.Speeds.Feed = ((buShapeFreeDraw) this).spn_cuttingspeed.Value;
    ((buShapeCircle) this).Settings.Speeds.Plunge = ((buShapeKeyHole) this).spn_plungespeed.Value;
    if (((camOptions5) ((buShapeCircle) this).Settings.Operations).isCircularCam)
    {
      if (((buShapeCircle) this).Settings.Strategy.RotaryAxis == VectorType.YVector)
      {
        ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMaxOffset.Y = ((buShapeSlot) this).spn_bottomoffst.Value;
        ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMinOffset.Y = ((buShapePolygon) this).spn_topoffet.Value;
        ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMaxOffset.X = ((buShapeHole) this).spn_rightoffset.Value;
        ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMinOffset.X = ((buShapeFreeLines) this).spn_leftoffset.Value;
      }
      if (((buShapeCircle) this).Settings.Strategy.RotaryAxis == VectorType.XVector)
      {
        ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMaxOffset.X = ((buShapeSlot) this).spn_bottomoffst.Value;
        ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMinOffset.X = ((buShapePolygon) this).spn_topoffet.Value;
        ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMinOffset.Y = ((buShapeHole) this).spn_rightoffset.Value;
        ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMaxOffset.Y = ((buShapeFreeLines) this).spn_leftoffset.Value;
      }
    }
    else
    {
      ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMinOffset.Y = ((buShapeSlot) this).spn_bottomoffst.Value;
      ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMaxOffset.Y = ((buShapePolygon) this).spn_topoffet.Value;
      ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMinOffset.X = ((buShapeHole) this).spn_rightoffset.Value;
      ((camOptions5) ((buShapeCircle) this).Settings.Operations).BorderMaxOffset.X = ((buShapeFreeLines) this).spn_leftoffset.Value;
    }
    ((buShapeCircle) this).Settings.Steps.EndOffset = ((buShapeKeyHole) this).spn_depthendoffset.Value;
    ((buShapeCircle) this).Settings.Steps.StartOffset = ((buShapeKeyHole) this).spn_depthstartoffset.Value;
    ((buShapeCircle) this).Settings.Distances.Safe = ((buShapeFreeDraw) this).spn_safedistance.Value;
    ((camMaterial5) ((buShapeCircle) this).Settings.Distances).Rapid = ((buShapeFreeDraw) this).spn_rapiddistance.Value;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((buShapePolygon) this).btn_ok.Name)
      {
        this.Apply();
        ((buShapeRectangle) this).PropertiesForm.Result = DialogResult.OK;
        if (((buShapeRectangle) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        {
          // ISSUE: explicit non-virtual call
          __nonvirtual (((Component) this).Dispose());
        }
        if (((buShapeRectangle) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          ((Control) this).Visible = false;
      }
      if (control2.Name == ((buShapeEllipse) this).btn_close.Name | control2.Name == ((buShapeSlot) this).btn_cancel.Name)
      {
        ((buShapeRectangle) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((buShapeRectangle) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        {
          // ISSUE: explicit non-virtual call
          __nonvirtual (((Component) this).Dispose());
        }
        if (((buShapeRectangle) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          ((Control) this).Visible = false;
      }
      if (!(control2.Name == ((buShapeHole) this).btn_stocksettings.Name))
        return;
      F_CamStockOffset fCamStockOffset = (F_CamStockOffset) new buEntity();
      ((buLinearDim) fCamStockOffset).Settings = ((buShapeCircle) this).Settings;
      ((buLinearDim) fCamStockOffset).PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
      ((buLinearDim) fCamStockOffset).PropertiesForm.FormPosition = FormStartPosition.CenterParent;
      ((buEntity) fCamStockOffset).Init();
      int num = (int) fCamStockOffset.ShowDialog();
      if (((buLinearDim) fCamStockOffset).PropertiesForm.Result != DialogResult.OK)
        return;
      ((buShapeCircle) this).Settings = ((buLinearDim) fCamStockOffset).Settings;
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((buShapeRectangle) this).PropertiesForm.Inited)
      return;
    (obj0 as buSpin).SelectAll();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((buShapeEllipse) this).\u0001 != null ? 1 : 0)) != 0)
      ((buShapeEllipse) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }

  static buEntity() => buShapeRectangle.Captions = new List<string>();

  public buEntity()
  {
    ((buShapeHole) this).PropertiesForm = new FormProperties();
    ((buShapeHoleMulti) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    ((Form) this).\u002Ector();
    \u0007.\u0001.\u0001((F_BarCode) this);
  }

  public void Init()
  {
    ((buShapeHole) this).PropertiesForm.Inited = false;
    if (((buShapeHole) this).PropertiesForm.Height > 10)
      ((Control) this).Height = ((buShapeHole) this).PropertiesForm.Height;
    if (((buShapeHole) this).PropertiesForm.Width > 10)
      ((Control) this).Width = ((buShapeHole) this).PropertiesForm.Width;
    ((Form) this).TopMost = ((buShapeHole) this).PropertiesForm.TopMost;
    ((Form) this).StartPosition = ((buShapeHole) this).PropertiesForm.FormPosition;
    \u0007.\u0001.\u0001((F_BarCode) this);
    ((buShapeHole) this).PropertiesForm.Result = DialogResult.None;
    ((buShapeHole) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((buShapeHole) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((buShapeHole) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((buShapeHole) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
    {
      // ISSUE: explicit non-virtual call
      __nonvirtual (((Component) this).Dispose());
    }
    if (((buShapeHole) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    ((Control) this).Visible = false;
  }
}
