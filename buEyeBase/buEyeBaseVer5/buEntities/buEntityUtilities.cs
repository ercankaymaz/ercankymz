// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buEntityUtilities
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.ClassViewer;
using buEyeBaseVer5.Forms.BarCodes;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Printer3D;
using dummy_ptr;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buEntityUtilities
{
  public buCheckBox chk_autonocutgeodesic;

  public buEntityUtilities()
  {
    ((F_CamSettings1) this).PropertiesForm = new FormProperties();
    ((F_CamSettings1) this).Settings = new camParameters5();
    ((F_CamSettings1) this).camType = CamType.Rough;
    ((F_CamSettings1) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    ((Form) this).\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_CamTriMeshSettings) this);
  }

  public void Init(CamType Type, bool is5Axis)
  {
    ((F_CamSettings1) this).camType = Type;
    ((F_CamSettings1) this).PropertiesForm.Inited = false;
    if (((F_CamSettings1) this).PropertiesForm.Height > 10)
      ((Control) this).Height = ((F_CamSettings1) this).PropertiesForm.Height;
    if (((F_CamSettings1) this).PropertiesForm.Width > 10)
      ((Control) this).Width = ((F_CamSettings1) this).PropertiesForm.Width;
    ((Form) this).TopMost = ((F_CamSettings1) this).PropertiesForm.TopMost;
    ((Form) this).StartPosition = ((F_CamSettings1) this).PropertiesForm.FormPosition;
    ((F_CamSettings1) this).\u0001.ItemSize = new Size(1, 1);
    ((F_CamSettings1) this).\u0002.ItemSize = new Size(1, 1);
    switch (Type)
    {
      case CamType.Rough:
        ((F_CamSettings1) this).\u0001.SelectedIndex = 0;
        break;
      case CamType.ParallelCut:
        ((F_CamSettings1) this).\u0001.SelectedIndex = 1;
        break;
      case CamType.ConstantZ:
        ((F_CamSettings1) this).\u0001.SelectedIndex = 2;
        break;
      case CamType.Pencil:
        ((F_CamSettings1) this).\u0001.SelectedIndex = 4;
        break;
      case CamType.Flatlands:
        ((F_CamSettings1) this).\u0001.SelectedIndex = 3;
        break;
      case CamType.ConstantCusp:
        ((F_CamSettings1) this).\u0001.SelectedIndex = 5;
        break;
      case CamType.Projection:
        ((F_CamSettings1) this).\u0001.SelectedIndex = 6;
        break;
    }
    ((F_CamSettings1) this).spn_safedistance.Value = ((F_CamSettings1) this).Settings.Distances.Safe;
    ((F_CamSettings1) this).spn_rapiddistance.Value = ((camMaterial5) ((F_CamSettings1) this).Settings.Distances).Rapid;
    ((F_CamSettings1) this).spn_cuttingspeed.Value = ((F_CamSettings1) this).Settings.Speeds.Feed;
    ((F_CamSettings1) this).spn_plungespeed.Value = ((F_CamSettings1) this).Settings.Speeds.Plunge;
    ((F_CamSettings1) this).spn_bottomoffst.Value = ((F_CamSettings1) this).Settings.Steps.EndOffset;
    ((F_CamSettings1) this).spn_topoffet.Value = ((F_CamSettings1) this).Settings.Steps.StartOffset;
    ((F_CamSettings1) this).spn_cuttolerance.Value = ((F_CamSettings1) this).Settings.Strategy.CutTolerance;
    ((F_CamSettings1) this).chk_zigzag.Check = false;
    ((F_CamSettings1) this).chk_oneway.Check = false;
    ((F_CamSettings1) this).chk_spiral.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.CuttingMethod == CamCuttingMethod.MachtypeZigzag)
      ((F_CamSettings1) this).chk_zigzag.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.CuttingMethod == CamCuttingMethod.MachtypeOneway)
      ((F_CamSettings1) this).chk_oneway.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.CuttingMethod == CamCuttingMethod.MachtypeSpiral)
      ((F_CamSettings1) this).chk_spiral.Check = true;
    ((F_CamRough4XSettings) this).chk_region.Check = false;
    ((F_CamRough4XSettings) this).chk_level.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByRegions)
      ((F_CamRough4XSettings) this).chk_region.Check = true;
    else
      ((F_CamRough4XSettings) this).chk_level.Check = true;
    if (((F_CamSettings1) this).Settings.Operations.Stepover <= 0.0)
      ((F_CamSettings1) this).Settings.Operations.Stepover = 1.0;
    ((F_CamSettings1) this).spn_stepoverparallel.Value = ((F_CamSettings1) this).Settings.Operations.Stepover;
    ((buClassViewerColor5) this).spn_stepoverpencil.Value = ((F_CamSettings1) this).Settings.Operations.Stepover;
    ((F_CamSettings1) this).spn_stepoverrough.Value = ((F_CamSettings1) this).Settings.Operations.Stepover;
    ((buClassViewer5) this).spn_stepoverConstcusp.Value = ((F_CamSettings1) this).Settings.Operations.Stepover;
    ((buClassViewerColor5) this).spn_sepoverflatland.Value = ((F_CamSettings1) this).Settings.Operations.Stepover;
    ((buEntityUpdateType) this).spn_stepoverProjection.Value = ((F_CamSettings1) this).Settings.Operations.Stepover;
    if (((F_CamSettings1) this).Settings.Steps.DepthStep <= 0.0)
      ((F_CamSettings1) this).Settings.Steps.DepthStep = 1.0;
    ((F_CamRough4XSettings) this).spn_depthsteprough.Value = ((F_CamSettings1) this).Settings.Steps.DepthStep;
    ((F_BarCode) this).spn_depthstepconstantZ.Value = ((F_CamSettings1) this).Settings.Steps.DepthStep;
    ((setComboBoxControl) this).spn_depthstepflatland.Value = ((F_CamSettings1) this).Settings.Steps.DepthStep;
    ((buClassViewer5) this).spn_depthstepoverConstcusp.Value = ((F_CamSettings1) this).Settings.Steps.DepthStep;
    ((F_CamSettings1) this).chk_roughoffset.Check = false;
    ((F_CamSettings1) this).chk_roughparalel.Check = false;
    ((F_CamSettings1) this).chk_roughadaptive.Check = false;
    if (((camOperation5) ((F_CamSettings1) this).Settings.Pockets).PocketType == CamPocketType.WfbRghtParallel)
      ((F_CamSettings1) this).chk_roughparalel.Check = true;
    else if (((camOperation5) ((F_CamSettings1) this).Settings.Pockets).PocketType == CamPocketType.WfbRghtOffset)
      ((F_CamSettings1) this).chk_roughoffset.Check = true;
    else if (((camOperation5) ((F_CamSettings1) this).Settings.Pockets).PocketType == CamPocketType.WfbRghtAdaptive)
      ((F_CamSettings1) this).chk_roughadaptive.Check = true;
    ((setColorComboControl) this).chk_flatlandoffset.Check = false;
    ((buClassViewerColor5) this).chk_flatlandparallel.Check = false;
    ((buClassViewerColor5) this).chk_flatlandadaptive.Check = false;
    if (((camOperation5) ((F_CamSettings1) this).Settings.Pockets).PocketType == CamPocketType.WfbRghtParallel)
      ((buClassViewerColor5) this).chk_flatlandparallel.Check = true;
    else if (((camOperation5) ((F_CamSettings1) this).Settings.Pockets).PocketType == CamPocketType.WfbRghtOffset)
      ((setColorComboControl) this).chk_flatlandoffset.Check = true;
    else if (((camOperation5) ((F_CamSettings1) this).Settings.Pockets).PocketType == CamPocketType.WfbRghtAdaptive)
      ((buClassViewerColor5) this).chk_flatlandadaptive.Check = true;
    ((F_CamSettings1) this).chk_roughsharpcorner.Check = ((camOperation5) ((F_CamSettings1) this).Settings.Pockets).SharpCorner;
    ((F_CamSettings1) this).chk_roughleadout.Check = ((F_CamSettings1) this).Settings.Strategy.RoughLeadOut;
    ((F_CamSettings1) this).chk_roughminimizelink.Check = ((F_CamSettings1) this).Settings.Strategy.MinimizeLink;
    ((F_CamSettings1) this).chk_roughremovecornerpeg.Check = ((F_CamSettings1) this).Settings.Strategy.RemoveCornerPeg;
    ((F_CamRough4XSettings) this).chk_reversecuttingoderrrough.Check = ((F_CamSettings1) this).Settings.Strategy.ReverseCuttingOrder;
    ((buClassViewerColor5) this).chk_reversecuttingorderflatland.Check = ((F_CamSettings1) this).Settings.Strategy.ReverseCuttingOrder;
    ((F_CamRough4XSettings) this).chk_maintaincuttingdirectionrough.Check = ((F_CamSettings1) this).Settings.Strategy.MaintainCuttingDirection;
    ((F_BarCode) this).chk_maintaincuttingdirectionroughconstantz.Check = ((F_CamSettings1) this).Settings.Strategy.MaintainCuttingDirection;
    ((F_CamRough4XSettings) this).chk_closedoffsetrrough.Check = ((F_CamSettings1) this).Settings.Strategy.ClosedOffset;
    ((F_CamSettings1) this).chk_roughuseramp.Check = ((F_CamSettings1) this).Settings.Strategy.UseRamp;
    ((F_CamSettings1) this).spn_roughrampangle.Value = ((F_CamSettings1) this).Settings.Strategy.RampAngle;
    ((F_CamSettings1) this).spn_roughrampdia.Value = ((F_CamSettings1) this).Settings.Strategy.RampMaxDiameterFromToolPerc;
    ((F_CamSettings1) this).chk_roughstockbox.Check = false;
    ((F_CamSettings1) this).chk_roughstocksurface.Check = false;
    if (((camRotary5) ((F_CamSettings1) this).Settings.Options).StockType == CamStockType.StSurfaces)
      ((F_CamSettings1) this).chk_roughstockbox.Check = true;
    else
      ((F_CamSettings1) this).chk_roughstocksurface.Check = true;
    ((F_BarCode) this).chk_edgerollingconstantZ.Check = ((F_CamSettings1) this).Settings.Strategy.EdgeRolling;
    ((F_BarCode) this).chk_edgerollingparallel.Check = ((F_CamSettings1) this).Settings.Strategy.EdgeRolling;
    ((buClassViewer5) this).chk_edgerollingConstcusp.Check = ((F_CamSettings1) this).Settings.Strategy.EdgeRolling;
    ((F_CamRough4XSettings) this).chk_cornerlowerrightparallel.Check = false;
    ((F_CamRough4XSettings) this).chk_cornerlowerleftparallel.Check = false;
    ((F_CamRough4XSettings) this).chk_cornerupperleftparallel.Check = false;
    ((F_CamRough4XSettings) this).chk_cornerupperrightparallel.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.ParallelCutStartCorner == CamParallelCutsStartCorner.TmbScLowerRight)
      ((F_CamRough4XSettings) this).chk_cornerlowerrightparallel.Check = true;
    if (((F_CamSettings1) this).Settings.Strategy.ParallelCutStartCorner == CamParallelCutsStartCorner.TmbScUpperRight)
      ((F_CamRough4XSettings) this).chk_cornerupperrightparallel.Check = true;
    if (((F_CamSettings1) this).Settings.Strategy.ParallelCutStartCorner == CamParallelCutsStartCorner.TmbScLowerLeft)
      ((F_CamRough4XSettings) this).chk_cornerlowerleftparallel.Check = true;
    if (((F_CamSettings1) this).Settings.Strategy.ParallelCutStartCorner == CamParallelCutsStartCorner.TmbScUpperLeft)
      ((F_CamRough4XSettings) this).chk_cornerupperleftparallel.Check = true;
    ((F_CamRough4XSettings) this).chk_xdirectionparallel.Check = false;
    ((F_CamRough4XSettings) this).chk_ydirectionparallel.Check = false;
    ((F_CamRough4XSettings) this).chk_Angledirectionparallel.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.ParallelCutDireiton == CamParallelCutDirection.XDirection)
      ((F_CamRough4XSettings) this).chk_xdirectionparallel.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.ParallelCutDireiton == CamParallelCutDirection.YDirection)
      ((F_CamRough4XSettings) this).chk_ydirectionparallel.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.ParallelCutDireiton == CamParallelCutDirection.AngleDirection)
      ((F_CamRough4XSettings) this).chk_Angledirectionparallel.Check = true;
    ((F_CamRough4XSettings) this).spn_parallelangleparallel.Value = ((F_CamSettings1) this).Settings.Strategy.ParallelCutAngleXY;
    ((F_CamRough4XSettings) this).spn_overlapconstantZ.Value = ((F_CamSettings1) this).Settings.Operations.Overlap;
    ((buClassViewer5) this).spn_overlapConstcusp.Value = ((F_CamSettings1) this).Settings.Operations.Overlap;
    ((buClassViewerColor5) this).spn_overthicknesspnecil.Value = ((F_CamSettings1) this).Settings.Operations.Overlap;
    ((F_CamRough4XSettings) this).chk_StartAttopconstantZ.Check = false;
    ((F_CamRough4XSettings) this).chk_StartAtbottomconstantZ.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.ConstantZStart == CamConstantZStart.ShbZsTop)
      ((F_CamRough4XSettings) this).chk_StartAttopconstantZ.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.ConstantZStart == CamConstantZStart.ShbZsBottom)
      ((F_CamRough4XSettings) this).chk_StartAtbottomconstantZ.Check = true;
    ((F_BarCode) this).chk_verticalwallexcludeconstantZ.Check = false;
    ((F_BarCode) this).chk_verticalwallincludeconstantZ.Check = false;
    ((F_BarCode) this).chk_verticalwallmachineonlyconstantZ.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.VerticalWallMachine)
      ((F_BarCode) this).chk_verticalwallmachineonlyconstantZ.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.VerticalWallExclude)
      ((F_BarCode) this).chk_verticalwallexcludeconstantZ.Check = true;
    else
      ((F_BarCode) this).chk_verticalwallincludeconstantZ.Check = true;
    ((buClassViewerColor5) this).spn_flattolerancefactorflatland.Value = ((F_CamSettings1) this).Settings.Strategy.FlatToleranceFactor;
    ((setTextBoxControl) this).chk_depthstepenableflatland.Check = ((camSpeeds5) ((F_CamSettings1) this).Settings.Steps).DepthStepEnable;
    ((setLabelControl) this).spn_numberofpassesflatland.Value = (double) ((camSpeeds5) ((F_CamSettings1) this).Settings.Steps).NumberOfPasses4DepthStep;
    ((setCheckBoxControl) this).spn_finaldepthstepflatland.Value = ((camSpeeds5) ((F_CamSettings1) this).Settings.Steps).FinalDepthStep;
    ((buClassViewerColor5) this).chk_singlestepflatland.Check = ((F_CamSettings1) this).Settings.Strategy.SingleCut;
    ((buClassViewerColor5) this).chk_singlestepawideflatland.Check = false;
    ((buClassViewerColor5) this).chk_singlestepnarrowflatland.Check = false;
    ((buClassViewerColor5) this).chk_singlestepnarrowandwideflatland.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.MachiningAreaType == CamMachiningAreasType.MatNarrow)
      ((buClassViewerColor5) this).chk_singlestepnarrowflatland.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.MachiningAreaType == CamMachiningAreasType.MatWide)
      ((buClassViewerColor5) this).chk_singlestepawideflatland.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.MachiningAreaType == CamMachiningAreasType.MatNarrowAndWide)
      ((buClassViewerColor5) this).chk_singlestepnarrowandwideflatland.Check = true;
    ((buClassViewerColor5) this).spn_minwidthflatland.Value = ((F_CamSettings1) this).Settings.Strategy.MinWidth;
    ((buClassViewerColor5) this).spn_maxwidthflatland.Value = ((F_CamSettings1) this).Settings.Strategy.MaxWidth;
    ((buClassViewerColor5) this).chk_maxwidhtenableflatland.Check = ((F_CamSettings1) this).Settings.Strategy.MaxWidthFlg;
    ((buClassViewerColor5) this).spn_chaningdistanceflatland.Value = ((F_CamSettings1) this).Settings.Strategy.ChainingDistanceInPercOfToolDiameter;
    ((buClassViewerColor5) this).chk_multipencil.Check = ((F_CamSettings1) this).Settings.Strategy.MultiPencil;
    ((buClassViewerColor5) this).spn_multipencil.Value = (double) ((F_CamSettings1) this).Settings.Strategy.NumberOfCuts;
    ((buClassViewerColor5) this).chk_cornerdetectionthresholdpencil.Check = ((F_CamSettings1) this).Settings.Strategy.CornerDetectionThresholdFlg;
    ((buClassViewerColor5) this).spn_cornerdetectionthresholdpencil.Value = ((F_CamSettings1) this).Settings.Strategy.CornerDetectionThreshold;
    ((buClassViewerColor5) this).chk_overthicknesspnecil.Check = ((F_CamSettings1) this).Settings.Strategy.OverThicknessFlg;
    ((buClassViewerColor5) this).spn_overthicknesspnecil.Value = ((F_CamSettings1) this).Settings.Strategy.OverThickness;
    ((buClassViewerColor5) this).chk_cutorderstandartpencil.Check = false;
    ((buClassViewerColor5) this).chk_cutorderfromcenterawaypencil.Check = false;
    ((buClassViewerColor5) this).chk_cutorderfromoutsidetocenterpencil.Check = false;
    ((buClassViewerColor5) this).chk_cutorderfromtoptobottompencil.Check = false;
    ((buClassViewerColor5) this).chk_cutorderfrombottomtotoppencil.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.CutOrder == CamCutOrder.OrderStandard)
      ((buClassViewerColor5) this).chk_cutorderstandartpencil.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.CutOrder == CamCutOrder.OrderFromCenter)
      ((buClassViewerColor5) this).chk_cutorderfromcenterawaypencil.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.CutOrder == CamCutOrder.OrderFromOuter)
      ((buClassViewerColor5) this).chk_cutorderfromoutsidetocenterpencil.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.CutOrder == CamCutOrder.OrderFromTopToBottom)
      ((buClassViewerColor5) this).chk_cutorderfromtoptobottompencil.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.CutOrder == CamCutOrder.OrderFromBottomToTop)
      ((buClassViewerColor5) this).chk_cutorderfrombottomtotoppencil.Check = true;
    ((buClassViewer5) this).chk_cutorderstandartConstcusp.Check = false;
    ((buClassViewer5) this).chk_cutorderfromcenterawayConstcusp.Check = false;
    ((buClassViewer5) this).chk_cutorderfromoutsidetocenterConstcusp.Check = false;
    ((buClassViewer5) this).chk_cutorderfromtoptobottomConstcusp.Check = false;
    ((buClassViewer5) this).chk_cutorderfrombottomtotopConstcusp.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.CutOrder == CamCutOrder.OrderStandard)
      ((buClassViewer5) this).chk_cutorderstandartConstcusp.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.CutOrder == CamCutOrder.OrderFromCenter)
      ((buClassViewer5) this).chk_cutorderfromcenterawayConstcusp.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.CutOrder == CamCutOrder.OrderFromOuter)
      ((buClassViewer5) this).chk_cutorderfromoutsidetocenterConstcusp.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.CutOrder == CamCutOrder.OrderFromTopToBottom)
      ((buClassViewer5) this).chk_cutorderfromtoptobottomConstcusp.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.CutOrder == CamCutOrder.OrderFromBottomToTop)
      ((buClassViewer5) this).chk_cutorderfrombottomtotopConstcusp.Check = true;
    ((buClassViewer5) this).chk_depthstepoverConstcusp.Check = ((F_CamSettings1) this).Settings.Strategy.SteepStepoverFlg;
    ((buClassViewer5) this).spn_depthstepoverConstcusp.Value = ((F_CamSettings1) this).Settings.Strategy.SteepStepover;
    ((buClassViewer5) this).chk_cornerefinementConstcusp.Check = ((F_CamSettings1) this).Settings.Strategy.CornerRefinementFlg;
    ((buClassViewer5) this).chk_rightcutnumberConstcusp.Check = ((F_CamSettings1) this).Settings.Strategy.RightDirNumberOfCutsFlg;
    ((buClassViewer5) this).spn_rightcutnumberConstcusp.Value = (double) ((F_CamSettings1) this).Settings.Strategy.RightDirNumberOfCuts;
    ((buClassViewerColor5) this).chk_leftcutnumberConstcusp.Check = ((F_CamSettings1) this).Settings.Strategy.LeftDirNumberOfCutsFlg;
    ((buClassViewer5) this).spn_leftcutnumberConstcusp.Value = (double) ((F_CamSettings1) this).Settings.Strategy.LeftDirNumberOfCuts;
    ((buClassViewer5) this).chk_stepdirbothConstcusp.Check = false;
    ((buClassViewer5) this).chk_stepdirleftConstcusp.Check = false;
    ((buClassViewer5) this).chk_stepdirrightConstcusp.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.StepDirection == CamOffsetDirection.PcpOdLeft)
      ((buClassViewer5) this).chk_stepdirleftConstcusp.Check = true;
    if (((F_CamSettings1) this).Settings.Strategy.StepDirection == CamOffsetDirection.PcpOdRight)
      ((buClassViewer5) this).chk_stepdirrightConstcusp.Check = true;
    if (((F_CamSettings1) this).Settings.Strategy.StepDirection == CamOffsetDirection.PcpOdBoth)
      ((buClassViewer5) this).chk_stepdirbothConstcusp.Check = true;
    ((F_Printer3DSettings) this).spn_silhouetteoffset.Value = ((F_CamSettings1) this).Settings.Strategy.SilhouetteStockRemain;
    if (!((F_CamSettings1) this).Settings.Strategy.SilhouetteEnable)
      ((F_Printer3DSettings) this).chk_silhouettenone.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.SilhouetteTriangleMeshType == CamSilhouetteContainmentTriangleMeshType.ScctPartEnd)
      ((F_Printer3DSettings) this).chk_silhouettepartend.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.SilhouetteTriangleMeshType == CamSilhouetteContainmentTriangleMeshType.ScctToolContact)
      ((F_Printer3DSettings) this).chk_silhouettetoolcontact.Check = true;
    else
      ((F_Printer3DSettings) this).chk_silhouettepart.Check = true;
    ((F_Printer3DSettings) this).chk_roundcorner.Check = ((camNotch5) ((F_CamSettings1) this).Settings.Strategy).RadiuFitFlag;
    ((F_Printer3DSettings) this).spn_maxdeviationrundcorner.Value = ((camNotch5) ((F_CamSettings1) this).Settings.Strategy).SplineMaxDeviation;
    ((buClassViewer5) this).chk_Anglerangeenable.Check = ((camNotch5) ((F_CamSettings1) this).Settings.Strategy).AngleRangeEnable;
    ((buClassViewer5) this).spn_anglerangestart.Value = ((camNotch5) ((F_CamSettings1) this).Settings.Strategy).AngleRangeSlopeAngleStart;
    ((buClassViewer5) this).spn_anglerangeend.Value = ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).AngleRangeSlopeAngleEnd;
    ((buClassViewer5) this).chk_anglerangebetweenslopeangles.Check = false;
    ((buClassViewer5) this).chk_anglerangeoutsideslopeangles.Check = false;
    if (((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).AngleRangeMachiningAreaType == CamMachiningAreaType.MatSteepAreas)
      ((buClassViewer5) this).chk_anglerangebetweenslopeangles.Check = true;
    else if (((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).AngleRangeMachiningAreaType == CamMachiningAreaType.MatShallowAreas)
      ((buClassViewer5) this).chk_anglerangeoutsideslopeangles.Check = true;
    ((F_Printer3DSettings) this).spn_MaxAngleChange.Value = ((F_CamSettings1) this).Settings.Rotary.MaxAngleChange;
    ((F_Printer3DSettings) this).spn_SideTiltAngle.Value = ((F_CamSettings1) this).Settings.Rotary.SideTiltAngle;
    ((F_Printer3DSettings) this).spn_LagAngle.Value = ((F_CamSettings1) this).Settings.Rotary.LagAngle;
    ((F_Printer3DSettings) this).spn_tiltangle.Value = ((camHatch5) ((F_CamSettings1) this).Settings.Rotary).TiltAngleFixed;
    ((F_Printer3DSettings) this).spn_rotaryangle.Value = ((camHatch5) ((F_CamSettings1) this).Settings.Rotary).RotaryAngle;
    ((F_Printer3DSettings) this).spn_smoothmaxtiltangle.Value = ((camHatch5) ((F_CamSettings1) this).Settings.Rotary).MaxAngleFromInitialToolOrientation;
    ((F_Printer3DSettings) this).spn_BAngleLimitEndInXZPlane.Value = ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).BAngleLimitEndInXZPlane;
    ((F_Printer3DSettings) this).spn_BAngleLimitStartInXZPlane.Value = ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).BAngleLimitStartInXZPlane;
    ((F_Printer3DSettings) this).spn_AAngleLimitStartInYZPlane.Value = ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).AAngleLimitStartInYZPlane;
    ((F_Printer3DSettings) this).spn_AAngleLimitEndInYZPlane.Value = ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).AAngleLimitEndInYZPlane;
    ((F_Printer3DSettings) this).spn_CAngleLimitEndInXYPlane.Value = ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).CAngleLimitEndInXYPlane;
    ((F_Printer3DSettings) this).spn_CAngleLimitStartInXYPlane.Value = ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).CAngleLimitStartInXYPlane;
    ((F_Printer3DSettings) this).spn_WOrtAngleLimitEnd.Value = ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).WOrtAngleLimitEnd;
    ((F_Printer3DSettings) this).spn_WOrtAngleLimitStart.Value = ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).WOrtAngleLimitStart;
    ((F_Printer3DSettings) this).chk_AAngleLimit.Check = ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).AAngleLimitInYZPlaneFlg;
    ((F_Printer3DSettings) this).chk_BAngleLimit.Check = ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).BAngleLimitInXZPlaneFlg;
    ((F_Printer3DSettings) this).chk_CAngleLimit.Check = ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).CAngleLimitInXYPlaneFlg;
    ((F_Printer3DSettings) this).chk_WAngleLimit.Check = ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).WOrtAngleLimitFlg;
    ((F_Printer3DSettings) this).chk_smoot.Check = ((camHatch5) ((F_CamSettings1) this).Settings.Rotary).SmoothingFlg;
    ((F_BarCode) this).chk_undercut.Check = ((camHatch5) ((F_CamSettings1) this).Settings.Rotary).UndercutsFlg;
    ((F_Printer3DSettings) this).chk_toolaxiscrossestiltaxis.Check = ((camHatch5) ((F_CamSettings1) this).Settings.Rotary).AxisMeetTiltFlg;
    ((F_Printer3DSettings) this).chk_maintaintiltaxis.Check = ((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).MaintainTiltFlg;
    ((F_Printer3DSettings) this).chk_tiltXAxis.Check = false;
    ((F_Printer3DSettings) this).chk_tiltYAxis.Check = false;
    ((F_Printer3DSettings) this).chk_tiltZAxis.Check = false;
    if (((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).TiltAxis == CamExtAxis.ExtAxisZ)
      ((F_Printer3DSettings) this).chk_tiltZAxis.Check = true;
    else if (((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).TiltAxis == CamExtAxis.ExtAxisX)
      ((F_Printer3DSettings) this).chk_tiltXAxis.Check = true;
    else if (((camStrategy5) ((F_CamSettings1) this).Settings.Rotary).TiltAxis == CamExtAxis.ExtAxisY)
      ((F_Printer3DSettings) this).chk_tiltYAxis.Check = true;
    ((F_Printer3DSettings) this).chk_notbetilted.Check = false;
    ((F_Printer3DSettings) this).chk_betiltedeleative.Check = false;
    ((F_Printer3DSettings) this).chk_tiltedwithfixangle.Check = false;
    if (((F_CamSettings1) this).Settings.Rotary.TiltStrategy == CamTiltStrategy.NoTilt)
      ((F_Printer3DSettings) this).chk_notbetilted.Check = true;
    else if (((F_CamSettings1) this).Settings.Rotary.TiltStrategy == CamTiltStrategy.RelativeToCuttingDir)
      ((F_Printer3DSettings) this).chk_betiltedeleative.Check = true;
    else
      ((F_Printer3DSettings) this).chk_tiltedwithfixangle.Check = true;
    ((F_Printer3DSettings) this).chk_followsurfaceisodir.Check = false;
    ((F_Printer3DSettings) this).chk_orthotocutdirection.Check = false;
    ((F_Printer3DSettings) this).chk_usespindlemaindir.Check = false;
    if (((F_CamSettings1) this).Settings.Rotary.SideTiltDefTypes == CamSideTiltDefTypes.FollowSurfIsoDir)
      ((F_Printer3DSettings) this).chk_followsurfaceisodir.Check = true;
    else if (((F_CamSettings1) this).Settings.Rotary.SideTiltDefTypes == CamSideTiltDefTypes.OrthoToCutDirAtEachPos)
      ((F_Printer3DSettings) this).chk_orthotocutdirection.Check = true;
    else
      ((F_Printer3DSettings) this).chk_usespindlemaindir.Check = true;
    ((buEntityUpdateType) this).spn_offsetProjection.Value = ((camStep5) ((F_CamSettings1) this).Settings.Offsets).AdditionalOffset;
    ((buEntityUpdateType) this).spn_radiusProjection.Value = ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).CylinderRadiusAroundLine;
    ((buEntityUpdateType) this).spn_sideshiftProjection.Value = ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).SideShift;
    ((buEntityUpdateType) this).spn_startangleProjection.Value = ((LeadOut5) ((F_CamSettings1) this).Settings.Strategy).ProjectionStartAngles;
    ((buEntityUpdateType) this).spn_endangleProjection.Value = ((LeadOut5) ((F_CamSettings1) this).Settings.Strategy).ProjectionEndAngles;
    ((buEntityUpdateType) this).spn_startheightProjection.Value = ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).ProjectionStartHeight;
    ((buEntityUpdateType) this).spn_endheightProjection.Value = ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).ProjectionEndHeight;
    ((buEntityUpdateType) this).spn_lineXProjection.Value = ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).ProjectionLineX;
    ((buEntityUpdateType) this).spn_lineYProjection.Value = ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).ProjectionLineY;
    ((buEntityUpdateType) this).spn_lineZProjection.Value = ((LeadIn5) ((F_CamSettings1) this).Settings.Strategy).ProjectionLineZ;
    ((buEntityUpdateType) this).spn_numberroughProjection.Value = (double) ((LeadOut5) ((F_CamSettings1) this).Settings.Strategy).MultiPassNumberOfRoughCuts;
    ((buEntityUpdateType) this).spn_spacingroughProjection.Value = ((LeadOut5) ((F_CamSettings1) this).Settings.Strategy).MultiPassRoughPassSpacing;
    ((buEntityUpdateType) this).chk_cutorderstandartProjection.Check = false;
    ((buEntityUpdateType) this).chk_cutorderfromcenterProjection.Check = false;
    ((buEntityUpdateType) this).chk_cutorderfromoutsideProjection.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.CutOrder == CamCutOrder.OrderStandard)
      ((buEntityUpdateType) this).chk_cutorderstandartProjection.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.CutOrder == CamCutOrder.OrderFromCenter)
      ((buEntityUpdateType) this).chk_cutorderfromcenterProjection.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.CutOrder == CamCutOrder.OrderFromOuter)
      ((buEntityUpdateType) this).chk_cutorderfromoutsideProjection.Check = true;
    ((buEntityUpdateType) this).chk_cwprojection.Check = false;
    ((buEntityUpdateType) this).chk_ccwprojection.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.ClosedCutDirection == CamMachiningParamsDirection.DirClockwise)
      ((buEntityUpdateType) this).chk_cwprojection.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.ClosedCutDirection == CamMachiningParamsDirection.DirCounterClockwise)
      ((buEntityUpdateType) this).chk_ccwprojection.Check = true;
    if (!((buEntityUpdateType) this).chk_cwprojection.Check & !((buEntityUpdateType) this).chk_ccwprojection.Check)
      ((buEntityUpdateType) this).chk_ccwprojection.Check = true;
    ((buEntityUpdateType) this).chk_slicesProjection.Check = false;
    ((buEntityUpdateType) this).chk_passesProjection.Check = false;
    if (((LeadOut5) ((F_CamSettings1) this).Settings.Strategy).MultiPassSortType == CamRoughSortType.McSortByPasses)
      ((buEntityUpdateType) this).chk_passesProjection.Check = true;
    else if (((LeadOut5) ((F_CamSettings1) this).Settings.Strategy).MultiPassSortType == CamRoughSortType.McSortBySlices)
      ((buEntityUpdateType) this).chk_slicesProjection.Check = true;
    if (!((buEntityUpdateType) this).chk_passesProjection.Check & !((buEntityUpdateType) this).chk_slicesProjection.Check)
      ((buEntityUpdateType) this).chk_passesProjection.Check = true;
    ((F_ClassViewerColorDialog5) this).spn_safedistancegeodesic.Value = ((F_CamSettings1) this).Settings.Distances.Safe;
    ((F_ClassViewerColorDialog5) this).spn_rapiddistancegeodesic.Value = ((camMaterial5) ((F_CamSettings1) this).Settings.Distances).Rapid;
    ((F_ClassViewerColorDialog5) this).spn_cuttingspeedgeodesic.Value = ((F_CamSettings1) this).Settings.Speeds.Feed;
    ((F_ClassViewerColorDialog5) this).spn_plungespeedgeodesic.Value = ((F_CamSettings1) this).Settings.Speeds.Plunge;
    ((F_ClassViewerColorDialog5) this).spn_cuttolerancegeodesic.Value = ((F_CamSettings1) this).Settings.Strategy.CutTolerance;
    ((buEntityUpdateType) this).chk_flipstepovergeodesic.Check = ((F_CamSettings1) this).Settings.Strategy.ReverseCut;
    ((buEntityUpdateType) this).chk_usemachiningdirectiongeodesic.Check = ((F_CamSettings1) this).Settings.Strategy.MachiningDirectionAsReferenceForDirectionOfCutsFlg;
    ((buEntityUpdateType) this).spn_surfaceoffsetgeodesic.Value = ((camStep5) ((F_CamSettings1) this).Settings.Offsets).AdditionalOffset;
    ((buEntityUpdateType) this).spn_stepovergeodesic.Value = ((F_CamSettings1) this).Settings.Operations.Stepover;
    ((buClassViewer5) this).chk_toolcentermodegeodesic.Check = false;
    ((buClassViewer5) this).chk_contactmodegeodesic.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.OutputPatternFlag)
      ((buClassViewer5) this).chk_contactmodegeodesic.Check = true;
    else
      ((buClassViewer5) this).chk_toolcentermodegeodesic.Check = true;
    ((F_ClassViewerDialog5) this).chk_morphbetweentwocurvegeodesic.Check = false;
    ((F_ClassViewerDialog5) this).chk_paralleltomultiplecurvegeodesic.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.GeodesicType == CamGeodesicType.TmbGeodesicOffset)
      ((F_ClassViewerDialog5) this).chk_paralleltomultiplecurvegeodesic.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.GeodesicType == CamGeodesicType.TmbGeodesicMorph)
      ((F_ClassViewerDialog5) this).chk_morphbetweentwocurvegeodesic.Check = true;
    ((F_ClassViewerDialog5) this).chk_cointainmentgeodesic.Check = false;
    ((F_ClassViewerDialog5) this).chk_medialaxisofcontainmentgeodesic.Check = false;
    ((F_ClassViewerDialog5) this).chk_circleatcentercontainmentgeodesic.Check = false;
    ((F_ClassViewerDialog5) this).chk_boundrycurvesmachiningsurfacegeodesic.Check = false;
    ((F_ClassViewerDialog5) this).chk_userdefinecontainmentgeodesic.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.GeodesicDriveInputType == CamGeodesicDriveInputType.TmbGditMachining)
      ((F_ClassViewerDialog5) this).chk_cointainmentgeodesic.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.GeodesicDriveInputType == CamGeodesicDriveInputType.TmbGditUserDefinedMesh)
      ((F_ClassViewerDialog5) this).chk_medialaxisofcontainmentgeodesic.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.GeodesicDriveInputType == CamGeodesicDriveInputType.TmbGditCenter)
      ((F_ClassViewerDialog5) this).chk_circleatcentercontainmentgeodesic.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.GeodesicDriveInputType == CamGeodesicDriveInputType.TmbGditSurface)
      ((F_ClassViewerDialog5) this).chk_boundrycurvesmachiningsurfacegeodesic.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.GeodesicDriveInputType == CamGeodesicDriveInputType.TmbGditUserDefined)
      ((F_ClassViewerDialog5) this).chk_userdefinecontainmentgeodesic.Check = true;
    ((F_ClassViewerDialog5) this).chk_automaticcontainmentgeodesic.Check = false;
    ((F_ClassViewerDialog5) this).chk_userdefinecontainmentgeodesic.Check = false;
    ((buEntityUpdateType) this).chk_userdefinecontainmentsillhouttegeodesic.Check = false;
    ((buEntityUpdateType) this).chk_sillhouttegeodesic.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.GeodesicContainmetType == CamGeodesicContainmentType.TmbGdpdAuto)
      ((F_ClassViewerDialog5) this).chk_automaticcontainmentgeodesic.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.GeodesicContainmetType == CamGeodesicContainmentType.TmbGdpdSilhouette)
      ((buEntityUpdateType) this).chk_sillhouttegeodesic.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.GeodesicContainmetType == CamGeodesicContainmentType.TmbGdpdUserDefinedAndSilhouette)
      ((buEntityUpdateType) this).chk_userdefinecontainmentsillhouttegeodesic.Check = true;
    else
      ((F_ClassViewerDialog5) this).chk_userdefinecontainmentgeodesic.Check = true;
    ((buEntityUpdateType) this).chk_contantstepovergeodesic.Check = false;
    ((buEntityUpdateType) this).chk_maxstepovergeodesic.Check = false;
    this.chk_autonocutgeodesic.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.GeodesicStepoverType == CamGeodesicStepover.TmbGsMaximum)
      ((buEntityUpdateType) this).chk_maxstepovergeodesic.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.GeodesicStepoverType == CamGeodesicStepover.TmbGsConstant)
      ((buEntityUpdateType) this).chk_contantstepovergeodesic.Check = true;
    else
      this.chk_autonocutgeodesic.Check = true;
    ((F_ClassViewerColorDialog5) this).chk_zigzaggeodesic.Check = false;
    ((F_ClassViewerColorDialog5) this).chk_onewaygeodesic.Check = false;
    ((F_ClassViewerColorDialog5) this).chk_spiralgeodesic.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.CuttingMethod == CamCuttingMethod.MachtypeZigzag)
      ((F_ClassViewerColorDialog5) this).chk_zigzaggeodesic.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.CuttingMethod == CamCuttingMethod.MachtypeOneway)
      ((F_ClassViewerColorDialog5) this).chk_onewaygeodesic.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.CuttingMethod == CamCuttingMethod.MachtypeSpiral)
      ((F_ClassViewerColorDialog5) this).chk_spiralgeodesic.Check = true;
    ((F_ClassViewerColorDialog5) this).chk_regiongeodesic.Check = false;
    ((F_ClassViewerColorDialog5) this).chk_levelgeodesic.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByRegions)
      ((F_ClassViewerColorDialog5) this).chk_regiongeodesic.Check = true;
    else
      ((F_ClassViewerColorDialog5) this).chk_levelgeodesic.Check = true;
    ((buClassViewer5) this).chk_cutorderstandartgeodesic.Check = false;
    ((buClassViewer5) this).chk_cutorderfromcenterawaygeodesic.Check = false;
    ((buClassViewer5) this).chk_cutorderfromoutsidetocentergeodesic.Check = false;
    ((buClassViewer5) this).chk_cutorderwipefromdirectiongeodesic.Check = false;
    if (((F_CamSettings1) this).Settings.Strategy.CutOrder == CamCutOrder.OrderFromCenter)
      ((buClassViewer5) this).chk_cutorderfromcenterawaygeodesic.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.CutOrder == CamCutOrder.OrderFromOuter)
      ((buClassViewer5) this).chk_cutorderfromoutsidetocentergeodesic.Check = true;
    else if (((F_CamSettings1) this).Settings.Strategy.CutOrder == CamCutOrder.OrderWipeFromOneSide)
      ((buClassViewer5) this).chk_cutorderwipefromdirectiongeodesic.Check = true;
    else
      ((buClassViewer5) this).chk_cutorderstandartgeodesic.Check = true;
    ((buEntity) this).MenuButtonColors(0);
    ((F_CamSettings1) this).PropertiesForm.Result = DialogResult.None;
    ((F_CamSettings1) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_CamTriMeshSettings) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_CamSettings1) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_CamSettings1) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_CamSettings1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
    {
      // ISSUE: explicit non-virtual call
      __nonvirtual (((Component) this).Dispose());
    }
    if (((F_CamSettings1) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    ((Control) this).Visible = false;
  }
}
