using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using ns71;

namespace buEyeBaseVer5.Forms.Cam;

public class F_CamTriMeshSettings : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public camParameters5 Settings = new camParameters5();

	public CamType camType = CamType.Rough;

	private IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buSpin spn_topoffet;

	public buButton btn_ok;

	public buSpin spn_bottomoffst;

	public buButton btn_cancel;

	public buSpin spn_stepoverparallel;

	public buSpin spn_plungespeed;

	public buSpin spn_cuttingspeed;

	public buSpin spn_rapiddistance;

	public buSpin spn_safedistance;

	internal buTab buTab_0;

	internal TabPage tabPage_0;

	public buCheckBox chk_roughstocksurface;

	public buCheckBox chk_roughstockbox;

	public buCheckBox chk_roughminimizelink;

	public buCheckBox chk_roughremovecornerpeg;

	public buCheckBox chk_roughleadout;

	public buCheckBox chk_roughuseramp;

	public buCheckBox chk_roughsharpcorner;

	public buCheckBox chk_roughadaptive;

	public buCheckBox chk_roughoffset;

	public buCheckBox chk_roughparalel;

	internal TabPage tabPage_1;

	internal buLabel buLabel_0;

	internal TabPage tabPage_2;

	internal TabPage tabPage_3;

	internal TabPage tabPage_4;

	internal buTab buTab_1;

	internal TabPage tabPage_5;

	internal TabPage tabPage_6;

	internal TabPage tabPage_7;

	public buButton btn_advanced;

	public buButton btn_5Axis;

	public buButton btn_camstrategy;

	internal buGroup buGroup_0;

	internal buGroup buGroup_1;

	internal buGroup buGroup_2;

	public buSpin spn_stepoverrough;

	public buSpin spn_roughrampangle;

	public buSpin spn_roughrampdia;

	public buSpin spn_cuttolerance;

	internal buGroup buGroup_3;

	public buCheckBox chk_zigzag;

	public buCheckBox chk_oneway;

	public buCheckBox chk_spiral;

	internal buGroup buGroup_4;

	public buCheckBox chk_level;

	public buCheckBox chk_region;

	public buButton btn_stocksettingsrrough;

	public buButton btn_rampsettingsrrough;

	internal buGroup buGroup_5;

	public buCheckBox chk_xdirectionparallel;

	public buCheckBox chk_ydirectionparallel;

	internal buGroup buGroup_6;

	public buCheckBox chk_cornerupperleftparallel;

	public buCheckBox chk_cornerlowerleftparallel;

	public buCheckBox chk_cornerupperrightparallel;

	public buCheckBox chk_cornerlowerrightparallel;

	public buSpin spn_parallelangleparallel;

	public buCheckBox chk_Angledirectionparallel;

	public buSpin spn_depthsteprough;

	public buCheckBox chk_closedoffsetrrough;

	public buCheckBox chk_maintaincuttingdirectionrough;

	public buCheckBox chk_reversecuttingoderrrough;

	public buSpin spn_overlapconstantZ;

	internal buGroup buGroup_7;

	public buCheckBox chk_StartAttopconstantZ;

	public buCheckBox chk_StartAtbottomconstantZ;

	public buSpin spn_depthstepconstantZ;

	public buCheckBox chk_edgerollingparallel;

	public buCheckBox chk_edgerollingconstantZ;

	internal buGroup buGroup_8;

	public buCheckBox chk_verticalwallmachineonlyconstantZ;

	public buCheckBox chk_verticalwallincludeconstantZ;

	public buCheckBox chk_verticalwallexcludeconstantZ;

	public buCheckBox chk_maintaincuttingdirectionroughconstantz;

	public buCheckBox chk_undercut;

	public buSpin spn_smoothmaxtiltangle;

	public buCheckBox chk_smoot;

	public buCheckBox chk_WAngleLimit;

	public buCheckBox chk_CAngleLimit;

	public buCheckBox chk_AAngleLimit;

	public buCheckBox chk_BAngleLimit;

	public buSpin spn_CAngleLimitStartInXYPlane;

	public buSpin spn_CAngleLimitEndInXYPlane;

	public buSpin spn_WOrtAngleLimitStart;

	public buSpin spn_WOrtAngleLimitEnd;

	public buSpin spn_MaxAngleChange;

	public buSpin spn_BAngleLimitStartInXZPlane;

	public buSpin spn_BAngleLimitEndInXZPlane;

	public buSpin spn_LagAngle;

	public buSpin spn_SideTiltAngle;

	public buSpin spn_AAngleLimitStartInYZPlane;

	public buSpin spn_AAngleLimitEndInYZPlane;

	public buCheckBox chk_silhouettetoolcontact;

	public buCheckBox chk_silhouettepartend;

	public buCheckBox chk_silhouettepart;

	public buCheckBox chk_silhouettenone;

	internal buGroup buGroup_9;

	public buSpin spn_silhouetteoffset;

	internal buGroup buGroup_10;

	public buSpin spn_maxdeviationrundcorner;

	public buCheckBox chk_roundcorner;

	internal buGroup buGroup_11;

	public buCheckBox chk_tiltedwithfixangle;

	public buCheckBox chk_betiltedeleative;

	public buCheckBox chk_notbetilted;

	internal buGroup buGroup_12;

	public buCheckBox chk_tiltZAxis;

	public buCheckBox chk_tiltYAxis;

	public buCheckBox chk_tiltXAxis;

	public buCheckBox chk_maintaintiltaxis;

	public buCheckBox chk_toolaxiscrossestiltaxis;

	public buSpin spn_rotaryangle;

	public buSpin spn_tiltangle;

	internal buGroup buGroup_13;

	public buCheckBox chk_usespindlemaindir;

	public buCheckBox chk_orthotocutdirection;

	public buCheckBox chk_followsurfaceisodir;

	internal buGroup buGroup_14;

	internal buGroup buGroup_15;

	internal buGroup buGroup_16;

	public buCheckBox chk_depthstepenableflatland;

	public buSpin spn_finaldepthstepflatland;

	public buSpin spn_numberofpassesflatland;

	public buSpin spn_depthstepflatland;

	internal buGroup buGroup_17;

	public buCheckBox chk_flatlandoffset;

	public buCheckBox chk_flatlandparallel;

	public buCheckBox chk_flatlandadaptive;

	public buSpin spn_flattolerancefactorflatland;

	public buSpin spn_sepoverflatland;

	internal buGroup buGroup_18;

	public buCheckBox chk_maxwidhtenableflatland;

	public buSpin spn_maxwidthflatland;

	public buSpin spn_minwidthflatland;

	internal buGroup buGroup_19;

	public buCheckBox chk_singlestepnarrowflatland;

	public buCheckBox chk_singlestepawideflatland;

	public buCheckBox chk_singlestepnarrowandwideflatland;

	public buCheckBox chk_singlestepflatland;

	internal buGroup buGroup_20;

	public buCheckBox chk_reversecuttingorderflatland;

	public buSpin spn_chaningdistanceflatland;

	internal buGroup buGroup_21;

	public buCheckBox chk_cutorderstandartpencil;

	public buCheckBox chk_cutorderfromcenterawaypencil;

	public buCheckBox chk_cutorderfromoutsidetocenterpencil;

	internal buGroup buGroup_22;

	public buCheckBox chk_overthicknesspnecil;

	public buSpin spn_overthicknesspnecil;

	public buCheckBox chk_cornerdetectionthresholdpencil;

	public buSpin spn_cornerdetectionthresholdpencil;

	public buCheckBox chk_multipencil;

	public buSpin spn_multipencil;

	public buSpin spn_stepoverpencil;

	public buCheckBox chk_cutorderfrombottomtotoppencil;

	public buCheckBox chk_cutorderfromtoptobottompencil;

	internal TabPage tabPage_8;

	internal buGroup buGroup_23;

	public buCheckBox chk_leftcutnumberConstcusp;

	public buSpin spn_leftcutnumberConstcusp;

	public buCheckBox chk_depthstepoverConstcusp;

	public buSpin spn_depthstepoverConstcusp;

	internal buGroup buGroup_24;

	public buCheckBox chk_cutorderfrombottomtotopConstcusp;

	public buCheckBox chk_cutorderfromtoptobottomConstcusp;

	public buCheckBox chk_cutorderstandartConstcusp;

	public buCheckBox chk_cutorderfromcenterawayConstcusp;

	public buCheckBox chk_cutorderfromoutsidetocenterConstcusp;

	public buSpin spn_stepoverConstcusp;

	public buCheckBox chk_edgerollingConstcusp;

	public buSpin spn_overlapConstcusp;

	public buCheckBox chk_cornerefinementConstcusp;

	public buCheckBox chk_rightcutnumberConstcusp;

	public buSpin spn_rightcutnumberConstcusp;

	public buCheckBox chk_stepdirleftConstcusp;

	public buCheckBox chk_stepdirbothConstcusp;

	public buCheckBox chk_stepdirrightConstcusp;

	internal buGroup buGroup_25;

	public buSpin spn_anglerangeend;

	public buSpin spn_anglerangestart;

	public buCheckBox chk_Anglerangeenable;

	public buCheckBox chk_anglerangebetweenslopeangles;

	public buCheckBox chk_anglerangeoutsideslopeangles;

	internal TabPage tabPage_9;

	internal buGroup buGroup_26;

	public buCheckBox chk_toolcentermodegeodesic;

	public buCheckBox chk_contactmodegeodesic;

	internal buGroup buGroup_27;

	public buCheckBox chk_cutorderwipefromdirectiongeodesic;

	public buCheckBox chk_cutorderstandartgeodesic;

	public buCheckBox chk_cutorderfromcenterawaygeodesic;

	public buCheckBox chk_cutorderfromoutsidetocentergeodesic;

	internal buGroup buGroup_28;

	public buCheckBox chk_levelgeodesic;

	public buCheckBox chk_regiongeodesic;

	internal buGroup buGroup_29;

	public buCheckBox chk_zigzaggeodesic;

	public buCheckBox chk_onewaygeodesic;

	public buCheckBox chk_spiralgeodesic;

	public buSpin spn_cuttolerancegeodesic;

	internal buLabel buLabel_1;

	public buSpin spn_cuttingspeedgeodesic;

	public buSpin spn_plungespeedgeodesic;

	public buSpin spn_safedistancegeodesic;

	public buSpin spn_rapiddistancegeodesic;

	internal buGroup buGroup_30;

	public buCheckBox chk_userdefinescurves;

	public buCheckBox chk_boundrycurvesmachiningsurfacegeodesic;

	public buCheckBox chk_cointainmentgeodesic;

	public buCheckBox chk_medialaxisofcontainmentgeodesic;

	public buCheckBox chk_circleatcentercontainmentgeodesic;

	internal buGroup buGroup_31;

	public buCheckBox chk_paralleltomultiplecurvegeodesic;

	public buCheckBox chk_morphbetweentwocurvegeodesic;

	internal buGroup buGroup_32;

	public buCheckBox chk_automaticcontainmentgeodesic;

	public buCheckBox chk_userdefinecontainmentgeodesic;

	internal buGroup buGroup_33;

	public buCheckBox chk_autonocutgeodesic;

	public buCheckBox chk_contantstepovergeodesic;

	public buSpin spn_stepovergeodesic;

	public buCheckBox chk_maxstepovergeodesic;

	public buSpin spn_surfaceoffsetgeodesic;

	public buCheckBox chk_usemachiningdirectiongeodesic;

	public buCheckBox chk_flipstepovergeodesic;

	public buButton btn_calculationtypesettinggeodesic;

	public buButton buButton3;

	public buButton btn_guidecurvesettinggeodesic;

	public buCheckBox chk_sillhouttegeodesic;

	public buCheckBox chk_userdefinecontainmentsillhouttegeodesic;

	internal TabPage tabPage_10;

	public buSpin spn_offsetProjection;

	public buSpin spn_radiusProjection;

	internal buGroup buGroup_34;

	public buSpin spn_lineZProjection;

	public buSpin spn_lineXProjection;

	public buSpin spn_lineYProjection;

	public buSpin spn_sideshiftProjection;

	public buSpin spn_stepoverProjection;

	public buSpin spn_endheightProjection;

	public buSpin spn_startheightProjection;

	public buSpin spn_endangleProjection;

	public buSpin spn_startangleProjection;

	internal buGroup buGroup_35;

	public buCheckBox chk_cutorderstandartProjection;

	public buCheckBox chk_cutorderfromcenterProjection;

	public buCheckBox chk_cutorderfromoutsideProjection;

	internal buGroup buGroup_36;

	public buCheckBox chk_cwprojection;

	public buCheckBox chk_ccwprojection;

	internal buGroup buGroup_37;

	public buCheckBox chk_slicesProjection;

	public buCheckBox chk_passesProjection;

	public buSpin spn_spacingroughProjection;

	public buSpin spn_numberroughProjection;

	public F_CamTriMeshSettings()
	{
		Class186.smethod_645(this);
	}

	public void Init(CamType Type, bool is5Axis)
	{
		camType = Type;
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		buTab_0.ItemSize = new Size(1, 1);
		buTab_1.ItemSize = new Size(1, 1);
		if (Type != CamType.Rough)
		{
			if (Type != CamType.ParallelCut)
			{
				if (Type != CamType.ConstantZ)
				{
					if (Type != CamType.Flatlands)
					{
						if (Type != CamType.Pencil)
						{
							if (Type != CamType.ConstantCusp)
							{
								if (Type == CamType.Projection)
								{
									buTab_0.SelectedIndex = 6;
								}
							}
							else
							{
								buTab_0.SelectedIndex = 5;
							}
						}
						else
						{
							buTab_0.SelectedIndex = 4;
						}
					}
					else
					{
						buTab_0.SelectedIndex = 3;
					}
				}
				else
				{
					buTab_0.SelectedIndex = 2;
				}
			}
			else
			{
				buTab_0.SelectedIndex = 1;
			}
		}
		else
		{
			buTab_0.SelectedIndex = 0;
		}
		spn_safedistance.Value = Settings.Distances.Safe;
		spn_rapiddistance.Value = Settings.Distances.Rapid;
		spn_cuttingspeed.Value = Settings.Speeds.Feed;
		spn_plungespeed.Value = Settings.Speeds.Plunge;
		spn_bottomoffst.Value = Settings.Steps.EndOffset;
		spn_topoffet.Value = Settings.Steps.StartOffset;
		spn_cuttolerance.Value = Settings.Strategy.CutTolerance;
		chk_zigzag.Check = false;
		chk_oneway.Check = false;
		chk_spiral.Check = false;
		if (Settings.Strategy.CuttingMethod != CamCuttingMethod.MachtypeZigzag)
		{
			if (Settings.Strategy.CuttingMethod != CamCuttingMethod.MachtypeOneway)
			{
				if (Settings.Strategy.CuttingMethod == CamCuttingMethod.MachtypeSpiral)
				{
					chk_spiral.Check = true;
				}
			}
			else
			{
				chk_oneway.Check = true;
			}
		}
		else
		{
			chk_zigzag.Check = true;
		}
		chk_region.Check = false;
		chk_level.Check = false;
		if (Settings.Strategy.MachiningAreaMode != CamMachiningAreaMode.MachByRegions)
		{
			chk_level.Check = true;
		}
		else
		{
			chk_region.Check = true;
		}
		if (Settings.Operations.Stepover <= 0.0)
		{
			Settings.Operations.Stepover = 1.0;
		}
		spn_stepoverparallel.Value = Settings.Operations.Stepover;
		spn_stepoverpencil.Value = Settings.Operations.Stepover;
		spn_stepoverrough.Value = Settings.Operations.Stepover;
		spn_stepoverConstcusp.Value = Settings.Operations.Stepover;
		spn_sepoverflatland.Value = Settings.Operations.Stepover;
		spn_stepoverProjection.Value = Settings.Operations.Stepover;
		if (Settings.Steps.DepthStep <= 0.0)
		{
			Settings.Steps.DepthStep = 1.0;
		}
		spn_depthsteprough.Value = Settings.Steps.DepthStep;
		spn_depthstepconstantZ.Value = Settings.Steps.DepthStep;
		spn_depthstepflatland.Value = Settings.Steps.DepthStep;
		spn_depthstepoverConstcusp.Value = Settings.Steps.DepthStep;
		chk_roughoffset.Check = false;
		chk_roughparalel.Check = false;
		chk_roughadaptive.Check = false;
		if (Settings.Pockets.PocketType != CamPocketType.WfbRghtParallel)
		{
			if (Settings.Pockets.PocketType != CamPocketType.WfbRghtOffset)
			{
				if (Settings.Pockets.PocketType == CamPocketType.WfbRghtAdaptive)
				{
					chk_roughadaptive.Check = true;
				}
			}
			else
			{
				chk_roughoffset.Check = true;
			}
		}
		else
		{
			chk_roughparalel.Check = true;
		}
		chk_flatlandoffset.Check = false;
		chk_flatlandparallel.Check = false;
		chk_flatlandadaptive.Check = false;
		if (Settings.Pockets.PocketType != CamPocketType.WfbRghtParallel)
		{
			if (Settings.Pockets.PocketType != CamPocketType.WfbRghtOffset)
			{
				if (Settings.Pockets.PocketType == CamPocketType.WfbRghtAdaptive)
				{
					chk_flatlandadaptive.Check = true;
				}
			}
			else
			{
				chk_flatlandoffset.Check = true;
			}
		}
		else
		{
			chk_flatlandparallel.Check = true;
		}
		chk_roughsharpcorner.Check = Settings.Pockets.SharpCorner;
		chk_roughleadout.Check = Settings.Strategy.RoughLeadOut;
		chk_roughminimizelink.Check = Settings.Strategy.MinimizeLink;
		chk_roughremovecornerpeg.Check = Settings.Strategy.RemoveCornerPeg;
		chk_reversecuttingoderrrough.Check = Settings.Strategy.ReverseCuttingOrder;
		chk_reversecuttingorderflatland.Check = Settings.Strategy.ReverseCuttingOrder;
		chk_maintaincuttingdirectionrough.Check = Settings.Strategy.MaintainCuttingDirection;
		chk_maintaincuttingdirectionroughconstantz.Check = Settings.Strategy.MaintainCuttingDirection;
		chk_closedoffsetrrough.Check = Settings.Strategy.ClosedOffset;
		chk_roughuseramp.Check = Settings.Strategy.UseRamp;
		spn_roughrampangle.Value = Settings.Strategy.RampAngle;
		spn_roughrampdia.Value = Settings.Strategy.RampMaxDiameterFromToolPerc;
		chk_roughstockbox.Check = false;
		chk_roughstocksurface.Check = false;
		if (Settings.Options.StockType != CamStockType.StSurfaces)
		{
			chk_roughstocksurface.Check = true;
		}
		else
		{
			chk_roughstockbox.Check = true;
		}
		chk_edgerollingconstantZ.Check = Settings.Strategy.EdgeRolling;
		chk_edgerollingparallel.Check = Settings.Strategy.EdgeRolling;
		chk_edgerollingConstcusp.Check = Settings.Strategy.EdgeRolling;
		chk_cornerlowerrightparallel.Check = false;
		chk_cornerlowerleftparallel.Check = false;
		chk_cornerupperleftparallel.Check = false;
		chk_cornerupperrightparallel.Check = false;
		if (Settings.Strategy.ParallelCutStartCorner == CamParallelCutsStartCorner.TmbScLowerRight)
		{
			chk_cornerlowerrightparallel.Check = true;
		}
		if (Settings.Strategy.ParallelCutStartCorner == CamParallelCutsStartCorner.TmbScUpperRight)
		{
			chk_cornerupperrightparallel.Check = true;
		}
		if (Settings.Strategy.ParallelCutStartCorner == CamParallelCutsStartCorner.TmbScLowerLeft)
		{
			chk_cornerlowerleftparallel.Check = true;
		}
		if (Settings.Strategy.ParallelCutStartCorner == CamParallelCutsStartCorner.TmbScUpperLeft)
		{
			chk_cornerupperleftparallel.Check = true;
		}
		chk_xdirectionparallel.Check = false;
		chk_ydirectionparallel.Check = false;
		chk_Angledirectionparallel.Check = false;
		if (Settings.Strategy.ParallelCutDireiton != CamParallelCutDirection.XDirection)
		{
			if (Settings.Strategy.ParallelCutDireiton != CamParallelCutDirection.YDirection)
			{
				if (Settings.Strategy.ParallelCutDireiton == CamParallelCutDirection.AngleDirection)
				{
					chk_Angledirectionparallel.Check = true;
				}
			}
			else
			{
				chk_ydirectionparallel.Check = true;
			}
		}
		else
		{
			chk_xdirectionparallel.Check = true;
		}
		spn_parallelangleparallel.Value = Settings.Strategy.ParallelCutAngleXY;
		spn_overlapconstantZ.Value = Settings.Operations.Overlap;
		spn_overlapConstcusp.Value = Settings.Operations.Overlap;
		spn_overthicknesspnecil.Value = Settings.Operations.Overlap;
		chk_StartAttopconstantZ.Check = false;
		chk_StartAtbottomconstantZ.Check = false;
		if (Settings.Strategy.ConstantZStart != CamConstantZStart.ShbZsTop)
		{
			if (Settings.Strategy.ConstantZStart == CamConstantZStart.ShbZsBottom)
			{
				chk_StartAtbottomconstantZ.Check = true;
			}
		}
		else
		{
			chk_StartAttopconstantZ.Check = true;
		}
		chk_verticalwallexcludeconstantZ.Check = false;
		chk_verticalwallincludeconstantZ.Check = false;
		chk_verticalwallmachineonlyconstantZ.Check = false;
		if (!Settings.Strategy.VerticalWallMachine)
		{
			if (!Settings.Strategy.VerticalWallExclude)
			{
				chk_verticalwallincludeconstantZ.Check = true;
			}
			else
			{
				chk_verticalwallexcludeconstantZ.Check = true;
			}
		}
		else
		{
			chk_verticalwallmachineonlyconstantZ.Check = true;
		}
		spn_flattolerancefactorflatland.Value = Settings.Strategy.FlatToleranceFactor;
		chk_depthstepenableflatland.Check = Settings.Steps.DepthStepEnable;
		spn_numberofpassesflatland.Value = Settings.Steps.NumberOfPasses4DepthStep;
		spn_finaldepthstepflatland.Value = Settings.Steps.FinalDepthStep;
		chk_singlestepflatland.Check = Settings.Strategy.SingleCut;
		chk_singlestepawideflatland.Check = false;
		chk_singlestepnarrowflatland.Check = false;
		chk_singlestepnarrowandwideflatland.Check = false;
		if (Settings.Strategy.MachiningAreaType != CamMachiningAreasType.MatNarrow)
		{
			if (Settings.Strategy.MachiningAreaType != CamMachiningAreasType.MatWide)
			{
				if (Settings.Strategy.MachiningAreaType == CamMachiningAreasType.MatNarrowAndWide)
				{
					chk_singlestepnarrowandwideflatland.Check = true;
				}
			}
			else
			{
				chk_singlestepawideflatland.Check = true;
			}
		}
		else
		{
			chk_singlestepnarrowflatland.Check = true;
		}
		spn_minwidthflatland.Value = Settings.Strategy.MinWidth;
		spn_maxwidthflatland.Value = Settings.Strategy.MaxWidth;
		chk_maxwidhtenableflatland.Check = Settings.Strategy.MaxWidthFlg;
		spn_chaningdistanceflatland.Value = Settings.Strategy.ChainingDistanceInPercOfToolDiameter;
		chk_multipencil.Check = Settings.Strategy.MultiPencil;
		spn_multipencil.Value = Settings.Strategy.NumberOfCuts;
		chk_cornerdetectionthresholdpencil.Check = Settings.Strategy.CornerDetectionThresholdFlg;
		spn_cornerdetectionthresholdpencil.Value = Settings.Strategy.CornerDetectionThreshold;
		chk_overthicknesspnecil.Check = Settings.Strategy.OverThicknessFlg;
		spn_overthicknesspnecil.Value = Settings.Strategy.OverThickness;
		chk_cutorderstandartpencil.Check = false;
		chk_cutorderfromcenterawaypencil.Check = false;
		chk_cutorderfromoutsidetocenterpencil.Check = false;
		chk_cutorderfromtoptobottompencil.Check = false;
		chk_cutorderfrombottomtotoppencil.Check = false;
		if (Settings.Strategy.CutOrder != CamCutOrder.OrderStandard)
		{
			if (Settings.Strategy.CutOrder != CamCutOrder.OrderFromCenter)
			{
				if (Settings.Strategy.CutOrder != CamCutOrder.OrderFromOuter)
				{
					if (Settings.Strategy.CutOrder != CamCutOrder.OrderFromTopToBottom)
					{
						if (Settings.Strategy.CutOrder == CamCutOrder.OrderFromBottomToTop)
						{
							chk_cutorderfrombottomtotoppencil.Check = true;
						}
					}
					else
					{
						chk_cutorderfromtoptobottompencil.Check = true;
					}
				}
				else
				{
					chk_cutorderfromoutsidetocenterpencil.Check = true;
				}
			}
			else
			{
				chk_cutorderfromcenterawaypencil.Check = true;
			}
		}
		else
		{
			chk_cutorderstandartpencil.Check = true;
		}
		chk_cutorderstandartConstcusp.Check = false;
		chk_cutorderfromcenterawayConstcusp.Check = false;
		chk_cutorderfromoutsidetocenterConstcusp.Check = false;
		chk_cutorderfromtoptobottomConstcusp.Check = false;
		chk_cutorderfrombottomtotopConstcusp.Check = false;
		if (Settings.Strategy.CutOrder != CamCutOrder.OrderStandard)
		{
			if (Settings.Strategy.CutOrder != CamCutOrder.OrderFromCenter)
			{
				if (Settings.Strategy.CutOrder != CamCutOrder.OrderFromOuter)
				{
					if (Settings.Strategy.CutOrder != CamCutOrder.OrderFromTopToBottom)
					{
						if (Settings.Strategy.CutOrder == CamCutOrder.OrderFromBottomToTop)
						{
							chk_cutorderfrombottomtotopConstcusp.Check = true;
						}
					}
					else
					{
						chk_cutorderfromtoptobottomConstcusp.Check = true;
					}
				}
				else
				{
					chk_cutorderfromoutsidetocenterConstcusp.Check = true;
				}
			}
			else
			{
				chk_cutorderfromcenterawayConstcusp.Check = true;
			}
		}
		else
		{
			chk_cutorderstandartConstcusp.Check = true;
		}
		chk_depthstepoverConstcusp.Check = Settings.Strategy.SteepStepoverFlg;
		spn_depthstepoverConstcusp.Value = Settings.Strategy.SteepStepover;
		chk_cornerefinementConstcusp.Check = Settings.Strategy.CornerRefinementFlg;
		chk_rightcutnumberConstcusp.Check = Settings.Strategy.RightDirNumberOfCutsFlg;
		spn_rightcutnumberConstcusp.Value = Settings.Strategy.RightDirNumberOfCuts;
		chk_leftcutnumberConstcusp.Check = Settings.Strategy.LeftDirNumberOfCutsFlg;
		spn_leftcutnumberConstcusp.Value = Settings.Strategy.LeftDirNumberOfCuts;
		chk_stepdirbothConstcusp.Check = false;
		chk_stepdirleftConstcusp.Check = false;
		chk_stepdirrightConstcusp.Check = false;
		if (Settings.Strategy.StepDirection == CamOffsetDirection.PcpOdLeft)
		{
			chk_stepdirleftConstcusp.Check = true;
		}
		if (Settings.Strategy.StepDirection == CamOffsetDirection.PcpOdRight)
		{
			chk_stepdirrightConstcusp.Check = true;
		}
		if (Settings.Strategy.StepDirection == CamOffsetDirection.PcpOdBoth)
		{
			chk_stepdirbothConstcusp.Check = true;
		}
		spn_silhouetteoffset.Value = Settings.Strategy.SilhouetteStockRemain;
		if (Settings.Strategy.SilhouetteEnable)
		{
			if (Settings.Strategy.SilhouetteTriangleMeshType != CamSilhouetteContainmentTriangleMeshType.ScctPartEnd)
			{
				if (Settings.Strategy.SilhouetteTriangleMeshType != CamSilhouetteContainmentTriangleMeshType.ScctToolContact)
				{
					chk_silhouettepart.Check = true;
				}
				else
				{
					chk_silhouettetoolcontact.Check = true;
				}
			}
			else
			{
				chk_silhouettepartend.Check = true;
			}
		}
		else
		{
			chk_silhouettenone.Check = true;
		}
		chk_roundcorner.Check = Settings.Strategy.RadiuFitFlag;
		spn_maxdeviationrundcorner.Value = Settings.Strategy.SplineMaxDeviation;
		chk_Anglerangeenable.Check = Settings.Strategy.AngleRangeEnable;
		spn_anglerangestart.Value = Settings.Strategy.AngleRangeSlopeAngleStart;
		spn_anglerangeend.Value = Settings.Strategy.AngleRangeSlopeAngleEnd;
		chk_anglerangebetweenslopeangles.Check = false;
		chk_anglerangeoutsideslopeangles.Check = false;
		if (Settings.Strategy.AngleRangeMachiningAreaType != CamMachiningAreaType.MatSteepAreas)
		{
			if (Settings.Strategy.AngleRangeMachiningAreaType == CamMachiningAreaType.MatShallowAreas)
			{
				chk_anglerangeoutsideslopeangles.Check = true;
			}
		}
		else
		{
			chk_anglerangebetweenslopeangles.Check = true;
		}
		spn_MaxAngleChange.Value = Settings.Rotary.MaxAngleChange;
		spn_SideTiltAngle.Value = Settings.Rotary.SideTiltAngle;
		spn_LagAngle.Value = Settings.Rotary.LagAngle;
		spn_tiltangle.Value = Settings.Rotary.TiltAngleFixed;
		spn_rotaryangle.Value = Settings.Rotary.RotaryAngle;
		spn_smoothmaxtiltangle.Value = Settings.Rotary.MaxAngleFromInitialToolOrientation;
		spn_BAngleLimitEndInXZPlane.Value = Settings.Rotary.BAngleLimitEndInXZPlane;
		spn_BAngleLimitStartInXZPlane.Value = Settings.Rotary.BAngleLimitStartInXZPlane;
		spn_AAngleLimitStartInYZPlane.Value = Settings.Rotary.AAngleLimitStartInYZPlane;
		spn_AAngleLimitEndInYZPlane.Value = Settings.Rotary.AAngleLimitEndInYZPlane;
		spn_CAngleLimitEndInXYPlane.Value = Settings.Rotary.CAngleLimitEndInXYPlane;
		spn_CAngleLimitStartInXYPlane.Value = Settings.Rotary.CAngleLimitStartInXYPlane;
		spn_WOrtAngleLimitEnd.Value = Settings.Rotary.WOrtAngleLimitEnd;
		spn_WOrtAngleLimitStart.Value = Settings.Rotary.WOrtAngleLimitStart;
		chk_AAngleLimit.Check = Settings.Rotary.AAngleLimitInYZPlaneFlg;
		chk_BAngleLimit.Check = Settings.Rotary.BAngleLimitInXZPlaneFlg;
		chk_CAngleLimit.Check = Settings.Rotary.CAngleLimitInXYPlaneFlg;
		chk_WAngleLimit.Check = Settings.Rotary.WOrtAngleLimitFlg;
		chk_smoot.Check = Settings.Rotary.SmoothingFlg;
		chk_undercut.Check = Settings.Rotary.UndercutsFlg;
		chk_toolaxiscrossestiltaxis.Check = Settings.Rotary.AxisMeetTiltFlg;
		chk_maintaintiltaxis.Check = Settings.Rotary.MaintainTiltFlg;
		chk_tiltXAxis.Check = false;
		chk_tiltYAxis.Check = false;
		chk_tiltZAxis.Check = false;
		if (Settings.Rotary.TiltAxis != CamExtAxis.ExtAxisZ)
		{
			if (Settings.Rotary.TiltAxis != CamExtAxis.ExtAxisX)
			{
				if (Settings.Rotary.TiltAxis == CamExtAxis.ExtAxisY)
				{
					chk_tiltYAxis.Check = true;
				}
			}
			else
			{
				chk_tiltXAxis.Check = true;
			}
		}
		else
		{
			chk_tiltZAxis.Check = true;
		}
		chk_notbetilted.Check = false;
		chk_betiltedeleative.Check = false;
		chk_tiltedwithfixangle.Check = false;
		if (Settings.Rotary.TiltStrategy != CamTiltStrategy.NoTilt)
		{
			if (Settings.Rotary.TiltStrategy != CamTiltStrategy.RelativeToCuttingDir)
			{
				chk_tiltedwithfixangle.Check = true;
			}
			else
			{
				chk_betiltedeleative.Check = true;
			}
		}
		else
		{
			chk_notbetilted.Check = true;
		}
		chk_followsurfaceisodir.Check = false;
		chk_orthotocutdirection.Check = false;
		chk_usespindlemaindir.Check = false;
		if (Settings.Rotary.SideTiltDefTypes != CamSideTiltDefTypes.FollowSurfIsoDir)
		{
			if (Settings.Rotary.SideTiltDefTypes != CamSideTiltDefTypes.OrthoToCutDirAtEachPos)
			{
				chk_usespindlemaindir.Check = true;
			}
			else
			{
				chk_orthotocutdirection.Check = true;
			}
		}
		else
		{
			chk_followsurfaceisodir.Check = true;
		}
		spn_offsetProjection.Value = Settings.Offsets.AdditionalOffset;
		spn_radiusProjection.Value = Settings.Strategy.CylinderRadiusAroundLine;
		spn_sideshiftProjection.Value = Settings.Strategy.SideShift;
		spn_startangleProjection.Value = Settings.Strategy.ProjectionStartAngles;
		spn_endangleProjection.Value = Settings.Strategy.ProjectionEndAngles;
		spn_startheightProjection.Value = Settings.Strategy.ProjectionStartHeight;
		spn_endheightProjection.Value = Settings.Strategy.ProjectionEndHeight;
		spn_lineXProjection.Value = Settings.Strategy.ProjectionLineX;
		spn_lineYProjection.Value = Settings.Strategy.ProjectionLineY;
		spn_lineZProjection.Value = Settings.Strategy.ProjectionLineZ;
		spn_numberroughProjection.Value = Settings.Strategy.MultiPassNumberOfRoughCuts;
		spn_spacingroughProjection.Value = Settings.Strategy.MultiPassRoughPassSpacing;
		chk_cutorderstandartProjection.Check = false;
		chk_cutorderfromcenterProjection.Check = false;
		chk_cutorderfromoutsideProjection.Check = false;
		if (Settings.Strategy.CutOrder != CamCutOrder.OrderStandard)
		{
			if (Settings.Strategy.CutOrder != CamCutOrder.OrderFromCenter)
			{
				if (Settings.Strategy.CutOrder == CamCutOrder.OrderFromOuter)
				{
					chk_cutorderfromoutsideProjection.Check = true;
				}
			}
			else
			{
				chk_cutorderfromcenterProjection.Check = true;
			}
		}
		else
		{
			chk_cutorderstandartProjection.Check = true;
		}
		chk_cwprojection.Check = false;
		chk_ccwprojection.Check = false;
		if (Settings.Strategy.ClosedCutDirection != CamMachiningParamsDirection.DirClockwise)
		{
			if (Settings.Strategy.ClosedCutDirection == CamMachiningParamsDirection.DirCounterClockwise)
			{
				chk_ccwprojection.Check = true;
			}
		}
		else
		{
			chk_cwprojection.Check = true;
		}
		if (!chk_cwprojection.Check & !chk_ccwprojection.Check)
		{
			chk_ccwprojection.Check = true;
		}
		chk_slicesProjection.Check = false;
		chk_passesProjection.Check = false;
		if (Settings.Strategy.MultiPassSortType != CamRoughSortType.McSortByPasses)
		{
			if (Settings.Strategy.MultiPassSortType == CamRoughSortType.McSortBySlices)
			{
				chk_slicesProjection.Check = true;
			}
		}
		else
		{
			chk_passesProjection.Check = true;
		}
		if (!chk_passesProjection.Check & !chk_slicesProjection.Check)
		{
			chk_passesProjection.Check = true;
		}
		spn_safedistancegeodesic.Value = Settings.Distances.Safe;
		spn_rapiddistancegeodesic.Value = Settings.Distances.Rapid;
		spn_cuttingspeedgeodesic.Value = Settings.Speeds.Feed;
		spn_plungespeedgeodesic.Value = Settings.Speeds.Plunge;
		spn_cuttolerancegeodesic.Value = Settings.Strategy.CutTolerance;
		chk_flipstepovergeodesic.Check = Settings.Strategy.ReverseCut;
		chk_usemachiningdirectiongeodesic.Check = Settings.Strategy.MachiningDirectionAsReferenceForDirectionOfCutsFlg;
		spn_surfaceoffsetgeodesic.Value = Settings.Offsets.AdditionalOffset;
		spn_stepovergeodesic.Value = Settings.Operations.Stepover;
		chk_toolcentermodegeodesic.Check = false;
		chk_contactmodegeodesic.Check = false;
		if (!Settings.Strategy.OutputPatternFlag)
		{
			chk_toolcentermodegeodesic.Check = true;
		}
		else
		{
			chk_contactmodegeodesic.Check = true;
		}
		chk_morphbetweentwocurvegeodesic.Check = false;
		chk_paralleltomultiplecurvegeodesic.Check = false;
		if (Settings.Strategy.GeodesicType != CamGeodesicType.TmbGeodesicOffset)
		{
			if (Settings.Strategy.GeodesicType == CamGeodesicType.TmbGeodesicMorph)
			{
				chk_morphbetweentwocurvegeodesic.Check = true;
			}
		}
		else
		{
			chk_paralleltomultiplecurvegeodesic.Check = true;
		}
		chk_cointainmentgeodesic.Check = false;
		chk_medialaxisofcontainmentgeodesic.Check = false;
		chk_circleatcentercontainmentgeodesic.Check = false;
		chk_boundrycurvesmachiningsurfacegeodesic.Check = false;
		chk_userdefinecontainmentgeodesic.Check = false;
		if (Settings.Strategy.GeodesicDriveInputType != CamGeodesicDriveInputType.TmbGditMachining)
		{
			if (Settings.Strategy.GeodesicDriveInputType != CamGeodesicDriveInputType.TmbGditUserDefinedMesh)
			{
				if (Settings.Strategy.GeodesicDriveInputType != CamGeodesicDriveInputType.TmbGditCenter)
				{
					if (Settings.Strategy.GeodesicDriveInputType != CamGeodesicDriveInputType.TmbGditSurface)
					{
						if (Settings.Strategy.GeodesicDriveInputType == CamGeodesicDriveInputType.TmbGditUserDefined)
						{
							chk_userdefinecontainmentgeodesic.Check = true;
						}
					}
					else
					{
						chk_boundrycurvesmachiningsurfacegeodesic.Check = true;
					}
				}
				else
				{
					chk_circleatcentercontainmentgeodesic.Check = true;
				}
			}
			else
			{
				chk_medialaxisofcontainmentgeodesic.Check = true;
			}
		}
		else
		{
			chk_cointainmentgeodesic.Check = true;
		}
		chk_automaticcontainmentgeodesic.Check = false;
		chk_userdefinecontainmentgeodesic.Check = false;
		chk_userdefinecontainmentsillhouttegeodesic.Check = false;
		chk_sillhouttegeodesic.Check = false;
		if (Settings.Strategy.GeodesicContainmetType != CamGeodesicContainmentType.TmbGdpdAuto)
		{
			if (Settings.Strategy.GeodesicContainmetType != CamGeodesicContainmentType.TmbGdpdSilhouette)
			{
				if (Settings.Strategy.GeodesicContainmetType != CamGeodesicContainmentType.TmbGdpdUserDefinedAndSilhouette)
				{
					chk_userdefinecontainmentgeodesic.Check = true;
				}
				else
				{
					chk_userdefinecontainmentsillhouttegeodesic.Check = true;
				}
			}
			else
			{
				chk_sillhouttegeodesic.Check = true;
			}
		}
		else
		{
			chk_automaticcontainmentgeodesic.Check = true;
		}
		chk_contantstepovergeodesic.Check = false;
		chk_maxstepovergeodesic.Check = false;
		chk_autonocutgeodesic.Check = false;
		if (Settings.Strategy.GeodesicStepoverType != CamGeodesicStepover.TmbGsMaximum)
		{
			if (Settings.Strategy.GeodesicStepoverType != CamGeodesicStepover.TmbGsConstant)
			{
				chk_autonocutgeodesic.Check = true;
			}
			else
			{
				chk_contantstepovergeodesic.Check = true;
			}
		}
		else
		{
			chk_maxstepovergeodesic.Check = true;
		}
		chk_zigzaggeodesic.Check = false;
		chk_onewaygeodesic.Check = false;
		chk_spiralgeodesic.Check = false;
		if (Settings.Strategy.CuttingMethod != CamCuttingMethod.MachtypeZigzag)
		{
			if (Settings.Strategy.CuttingMethod != CamCuttingMethod.MachtypeOneway)
			{
				if (Settings.Strategy.CuttingMethod == CamCuttingMethod.MachtypeSpiral)
				{
					chk_spiralgeodesic.Check = true;
				}
			}
			else
			{
				chk_onewaygeodesic.Check = true;
			}
		}
		else
		{
			chk_zigzaggeodesic.Check = true;
		}
		chk_regiongeodesic.Check = false;
		chk_levelgeodesic.Check = false;
		if (Settings.Strategy.MachiningAreaMode != CamMachiningAreaMode.MachByRegions)
		{
			chk_levelgeodesic.Check = true;
		}
		else
		{
			chk_regiongeodesic.Check = true;
		}
		chk_cutorderstandartgeodesic.Check = false;
		chk_cutorderfromcenterawaygeodesic.Check = false;
		chk_cutorderfromoutsidetocentergeodesic.Check = false;
		chk_cutorderwipefromdirectiongeodesic.Check = false;
		if (Settings.Strategy.CutOrder != CamCutOrder.OrderFromCenter)
		{
			if (Settings.Strategy.CutOrder != CamCutOrder.OrderFromOuter)
			{
				if (Settings.Strategy.CutOrder != CamCutOrder.OrderWipeFromOneSide)
				{
					chk_cutorderstandartgeodesic.Check = true;
				}
				else
				{
					chk_cutorderwipefromdirectiongeodesic.Check = true;
				}
			}
			else
			{
				chk_cutorderfromoutsidetocentergeodesic.Check = true;
			}
		}
		else
		{
			chk_cutorderfromcenterawaygeodesic.Check = true;
		}
		MenuButtonColors(0);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_312(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	public void Apply()
	{
		Settings.Distances.Safe = spn_safedistance.Value;
		Settings.Distances.Rapid = spn_rapiddistance.Value;
		Settings.Speeds.Feed = spn_cuttingspeed.Value;
		Settings.Speeds.Plunge = spn_plungespeed.Value;
		Settings.Steps.EndOffset = spn_bottomoffst.Value;
		Settings.Steps.StartOffset = spn_topoffet.Value;
		Settings.Strategy.CutTolerance = spn_cuttolerance.Value;
		if (camType != CamType.Geodesic)
		{
			if (!chk_zigzag.Check)
			{
				if (!chk_oneway.Check)
				{
					if (chk_spiral.Check)
					{
						Settings.Strategy.CuttingMethod = CamCuttingMethod.MachtypeSpiral;
					}
				}
				else
				{
					Settings.Strategy.CuttingMethod = CamCuttingMethod.MachtypeOneway;
				}
			}
			else
			{
				Settings.Strategy.CuttingMethod = CamCuttingMethod.MachtypeZigzag;
			}
			if (!chk_region.Check)
			{
				if (chk_level.Check)
				{
					Settings.Strategy.MachiningAreaMode = CamMachiningAreaMode.MachByLanes;
				}
			}
			else
			{
				Settings.Strategy.MachiningAreaMode = CamMachiningAreaMode.MachByRegions;
			}
		}
		if (camType == CamType.ParallelCut)
		{
			Settings.Operations.Stepover = spn_stepoverparallel.Value;
		}
		if (camType == CamType.ConstantZ)
		{
			Settings.Steps.DepthStep = spn_depthstepconstantZ.Value;
			Settings.Operations.Overlap = spn_overlapconstantZ.Value;
		}
		if (camType == CamType.Projection)
		{
			Settings.Operations.Stepover = spn_stepoverProjection.Value;
		}
		if (camType == CamType.Rough)
		{
			Settings.Operations.Stepover = spn_stepoverrough.Value;
			Settings.Steps.DepthStep = spn_depthsteprough.Value;
			if (!chk_roughoffset.Check)
			{
				if (!chk_roughparalel.Check)
				{
					if (chk_roughadaptive.Check)
					{
						Settings.Pockets.PocketType = CamPocketType.WfbRghtOffset;
					}
				}
				else
				{
					Settings.Pockets.PocketType = CamPocketType.WfbRghtParallel;
				}
			}
			else
			{
				Settings.Pockets.PocketType = CamPocketType.WfbRghtOffset;
			}
		}
		if (camType == CamType.ConstantCusp)
		{
			Settings.Operations.Stepover = spn_stepoverConstcusp.Value;
			Settings.Steps.DepthStep = spn_depthstepoverConstcusp.Value;
			Settings.Operations.Overlap = spn_overlapConstcusp.Value;
			if (!chk_cutorderstandartConstcusp.Check)
			{
				if (!chk_cutorderfromcenterawayConstcusp.Check)
				{
					if (!chk_cutorderfromoutsidetocenterConstcusp.Check)
					{
						if (!chk_cutorderfromtoptobottomConstcusp.Check)
						{
							if (chk_cutorderfrombottomtotopConstcusp.Check)
							{
								Settings.Strategy.CutOrder = CamCutOrder.OrderFromBottomToTop;
							}
						}
						else
						{
							Settings.Strategy.CutOrder = CamCutOrder.OrderFromTopToBottom;
						}
					}
					else
					{
						Settings.Strategy.CutOrder = CamCutOrder.OrderFromOuter;
					}
				}
				else
				{
					Settings.Strategy.CutOrder = CamCutOrder.OrderFromCenter;
				}
			}
			else
			{
				Settings.Strategy.CutOrder = CamCutOrder.OrderStandard;
			}
		}
		if (camType == CamType.Pencil)
		{
			Settings.Operations.Stepover = spn_stepoverpencil.Value;
			Settings.Operations.Overlap = spn_overthicknesspnecil.Value;
			if (!chk_cutorderstandartpencil.Check)
			{
				if (!chk_cutorderfromcenterawaypencil.Check)
				{
					if (!chk_cutorderfromoutsidetocenterpencil.Check)
					{
						if (!chk_cutorderfromtoptobottompencil.Check)
						{
							if (chk_cutorderfrombottomtotoppencil.Check)
							{
								Settings.Strategy.CutOrder = CamCutOrder.OrderFromBottomToTop;
							}
						}
						else
						{
							Settings.Strategy.CutOrder = CamCutOrder.OrderFromTopToBottom;
						}
					}
					else
					{
						Settings.Strategy.CutOrder = CamCutOrder.OrderFromOuter;
					}
				}
				else
				{
					Settings.Strategy.CutOrder = CamCutOrder.OrderFromCenter;
				}
			}
			else
			{
				Settings.Strategy.CutOrder = CamCutOrder.OrderStandard;
			}
		}
		if (camType == CamType.Flatlands)
		{
			Settings.Operations.Stepover = spn_sepoverflatland.Value;
			Settings.Steps.DepthStep = spn_depthstepflatland.Value;
			if (!chk_flatlandoffset.Check)
			{
				if (!chk_flatlandparallel.Check)
				{
					if (chk_flatlandadaptive.Check)
					{
						Settings.Pockets.PocketType = CamPocketType.WfbRghtOffset;
					}
				}
				else
				{
					Settings.Pockets.PocketType = CamPocketType.WfbRghtParallel;
				}
			}
			else
			{
				Settings.Pockets.PocketType = CamPocketType.WfbRghtOffset;
			}
		}
		Settings.Pockets.SharpCorner = chk_roughsharpcorner.Check;
		Settings.Strategy.RoughLeadOut = chk_roughleadout.Check;
		Settings.Strategy.MinimizeLink = chk_roughminimizelink.Check;
		Settings.Strategy.RemoveCornerPeg = chk_roughremovecornerpeg.Check;
		Settings.Strategy.ReverseCuttingOrder = chk_reversecuttingoderrrough.Check;
		Settings.Strategy.ReverseCuttingOrder = chk_reversecuttingorderflatland.Check;
		Settings.Strategy.MaintainCuttingDirection = chk_maintaincuttingdirectionrough.Check;
		Settings.Strategy.MaintainCuttingDirection = chk_maintaincuttingdirectionroughconstantz.Check;
		Settings.Strategy.ClosedOffset = chk_closedoffsetrrough.Check;
		Settings.Strategy.UseRamp = chk_roughuseramp.Check;
		Settings.Strategy.RampAngle = spn_roughrampangle.Value;
		Settings.Strategy.RampMaxDiameterFromToolPerc = spn_roughrampdia.Value;
		if (!chk_roughstockbox.Check)
		{
			if (chk_roughstocksurface.Check)
			{
				Settings.Options.StockType = CamStockType.StSurfaces;
			}
		}
		else
		{
			Settings.Options.StockType = CamStockType.StBoundingBox;
		}
		Settings.Strategy.EdgeRolling = chk_edgerollingconstantZ.Check;
		Settings.Strategy.EdgeRolling = chk_edgerollingparallel.Check;
		Settings.Strategy.EdgeRolling = chk_edgerollingConstcusp.Check;
		if (!chk_cornerlowerrightparallel.Check)
		{
			if (!chk_cornerlowerleftparallel.Check)
			{
				if (!chk_cornerupperleftparallel.Check)
				{
					if (chk_cornerupperrightparallel.Check)
					{
						Settings.Strategy.ParallelCutStartCorner = CamParallelCutsStartCorner.TmbScUpperRight;
					}
				}
				else
				{
					Settings.Strategy.ParallelCutStartCorner = CamParallelCutsStartCorner.TmbScUpperLeft;
				}
			}
			else
			{
				Settings.Strategy.ParallelCutStartCorner = CamParallelCutsStartCorner.TmbScLowerLeft;
			}
		}
		else
		{
			Settings.Strategy.ParallelCutStartCorner = CamParallelCutsStartCorner.TmbScLowerRight;
		}
		if (!chk_xdirectionparallel.Check)
		{
			if (!chk_ydirectionparallel.Check)
			{
				if (chk_Angledirectionparallel.Check)
				{
					Settings.Strategy.ParallelCutDireiton = CamParallelCutDirection.AngleDirection;
				}
			}
			else
			{
				Settings.Strategy.ParallelCutDireiton = CamParallelCutDirection.YDirection;
			}
		}
		else
		{
			Settings.Strategy.ParallelCutDireiton = CamParallelCutDirection.XDirection;
		}
		Settings.Strategy.ParallelCutAngleXY = spn_parallelangleparallel.Value;
		if (!chk_StartAttopconstantZ.Check)
		{
			if (chk_StartAtbottomconstantZ.Check)
			{
				Settings.Strategy.ConstantZStart = CamConstantZStart.ShbZsBottom;
			}
		}
		else
		{
			Settings.Strategy.ConstantZStart = CamConstantZStart.ShbZsTop;
		}
		if (!chk_verticalwallexcludeconstantZ.Check)
		{
			if (!chk_verticalwallincludeconstantZ.Check)
			{
				if (chk_verticalwallmachineonlyconstantZ.Check)
				{
					Settings.Strategy.VerticalWallMachine = true;
					Settings.Strategy.VerticalWallExclude = false;
				}
			}
			else
			{
				Settings.Strategy.VerticalWallMachine = false;
				Settings.Strategy.VerticalWallExclude = false;
			}
		}
		else
		{
			Settings.Strategy.VerticalWallMachine = false;
			Settings.Strategy.VerticalWallExclude = true;
		}
		Settings.Strategy.FlatToleranceFactor = spn_flattolerancefactorflatland.Value;
		Settings.Steps.DepthStepEnable = chk_depthstepenableflatland.Check;
		Settings.Steps.NumberOfPasses4DepthStep = (int)spn_numberofpassesflatland.Value;
		Settings.Steps.FinalDepthStep = spn_finaldepthstepflatland.Value;
		Settings.Strategy.SingleCut = chk_singlestepflatland.Check;
		if (!chk_singlestepawideflatland.Check)
		{
			if (!chk_singlestepnarrowflatland.Check)
			{
				if (chk_singlestepnarrowandwideflatland.Check)
				{
					Settings.Strategy.MachiningAreaType = CamMachiningAreasType.MatNarrowAndWide;
				}
			}
			else
			{
				Settings.Strategy.MachiningAreaType = CamMachiningAreasType.MatNarrow;
			}
		}
		else
		{
			Settings.Strategy.MachiningAreaType = CamMachiningAreasType.MatWide;
		}
		Settings.Strategy.MinWidth = spn_minwidthflatland.Value;
		Settings.Strategy.MaxWidth = spn_maxwidthflatland.Value;
		Settings.Strategy.MaxWidthFlg = chk_maxwidhtenableflatland.Check;
		Settings.Strategy.ChainingDistanceInPercOfToolDiameter = spn_chaningdistanceflatland.Value;
		Settings.Strategy.MultiPencil = chk_multipencil.Check;
		Settings.Strategy.NumberOfCuts = (int)spn_multipencil.Value;
		Settings.Strategy.CornerDetectionThresholdFlg = chk_cornerdetectionthresholdpencil.Check;
		Settings.Strategy.CornerDetectionThreshold = spn_cornerdetectionthresholdpencil.Value;
		Settings.Strategy.OverThicknessFlg = chk_overthicknesspnecil.Check;
		Settings.Strategy.OverThickness = spn_overthicknesspnecil.Value;
		Settings.Strategy.SteepStepoverFlg = chk_depthstepoverConstcusp.Check;
		Settings.Strategy.SteepStepover = spn_depthstepoverConstcusp.Value;
		Settings.Strategy.CornerRefinementFlg = chk_cornerefinementConstcusp.Check;
		Settings.Strategy.RightDirNumberOfCutsFlg = chk_rightcutnumberConstcusp.Check;
		Settings.Strategy.RightDirNumberOfCuts = (int)spn_rightcutnumberConstcusp.Value;
		Settings.Strategy.LeftDirNumberOfCutsFlg = chk_leftcutnumberConstcusp.Check;
		Settings.Strategy.LeftDirNumberOfCuts = (int)spn_leftcutnumberConstcusp.Value;
		if (!chk_stepdirbothConstcusp.Check)
		{
			if (!chk_stepdirleftConstcusp.Check)
			{
				if (chk_stepdirrightConstcusp.Check)
				{
					Settings.Strategy.StepDirection = CamOffsetDirection.PcpOdRight;
				}
			}
			else
			{
				Settings.Strategy.StepDirection = CamOffsetDirection.PcpOdLeft;
			}
		}
		else
		{
			Settings.Strategy.StepDirection = CamOffsetDirection.PcpOdBoth;
		}
		Settings.Strategy.SilhouetteStockRemain = spn_silhouetteoffset.Value;
		if (!chk_silhouettepart.Check)
		{
			if (!chk_silhouettepartend.Check)
			{
				if (!chk_silhouettetoolcontact.Check)
				{
					Settings.Strategy.SilhouetteEnable = false;
				}
				else
				{
					Settings.Strategy.SilhouetteTriangleMeshType = CamSilhouetteContainmentTriangleMeshType.ScctToolContact;
					Settings.Strategy.SilhouetteEnable = true;
				}
			}
			else
			{
				Settings.Strategy.SilhouetteTriangleMeshType = CamSilhouetteContainmentTriangleMeshType.ScctPartEnd;
				Settings.Strategy.SilhouetteEnable = true;
			}
		}
		else
		{
			Settings.Strategy.SilhouetteTriangleMeshType = CamSilhouetteContainmentTriangleMeshType.ScctPartSilhouette;
			Settings.Strategy.SilhouetteEnable = true;
		}
		Settings.Strategy.RadiuFitFlag = chk_roundcorner.Check;
		Settings.Strategy.SplineMaxDeviation = spn_maxdeviationrundcorner.Value;
		Settings.Strategy.AngleRangeEnable = chk_Anglerangeenable.Check;
		Settings.Strategy.AngleRangeSlopeAngleStart = spn_anglerangestart.Value;
		Settings.Strategy.AngleRangeSlopeAngleEnd = spn_anglerangeend.Value;
		if (!chk_anglerangebetweenslopeangles.Check)
		{
			if (chk_anglerangeoutsideslopeangles.Check)
			{
				Settings.Strategy.AngleRangeMachiningAreaType = CamMachiningAreaType.MatShallowAreas;
			}
		}
		else
		{
			Settings.Strategy.AngleRangeMachiningAreaType = CamMachiningAreaType.MatSteepAreas;
		}
		Settings.Rotary.MaxAngleChange = spn_MaxAngleChange.Value;
		Settings.Rotary.SideTiltAngle = spn_SideTiltAngle.Value;
		Settings.Rotary.LagAngle = spn_LagAngle.Value;
		Settings.Rotary.TiltAngleFixed = spn_tiltangle.Value;
		Settings.Rotary.RotaryAngle = spn_rotaryangle.Value;
		Settings.Rotary.MaxAngleFromInitialToolOrientation = spn_smoothmaxtiltangle.Value;
		Settings.Rotary.BAngleLimitEndInXZPlane = spn_BAngleLimitEndInXZPlane.Value;
		Settings.Rotary.BAngleLimitStartInXZPlane = spn_BAngleLimitStartInXZPlane.Value;
		Settings.Rotary.AAngleLimitStartInYZPlane = spn_AAngleLimitStartInYZPlane.Value;
		Settings.Rotary.AAngleLimitEndInYZPlane = spn_AAngleLimitEndInYZPlane.Value;
		Settings.Rotary.CAngleLimitEndInXYPlane = spn_CAngleLimitEndInXYPlane.Value;
		Settings.Rotary.CAngleLimitStartInXYPlane = spn_CAngleLimitStartInXYPlane.Value;
		Settings.Rotary.WOrtAngleLimitEnd = spn_WOrtAngleLimitEnd.Value;
		Settings.Rotary.WOrtAngleLimitStart = spn_WOrtAngleLimitStart.Value;
		Settings.Rotary.AAngleLimitInYZPlaneFlg = chk_AAngleLimit.Check;
		Settings.Rotary.BAngleLimitInXZPlaneFlg = chk_BAngleLimit.Check;
		Settings.Rotary.CAngleLimitInXYPlaneFlg = chk_CAngleLimit.Check;
		Settings.Rotary.WOrtAngleLimitFlg = chk_WAngleLimit.Check;
		Settings.Rotary.SmoothingFlg = chk_smoot.Check;
		Settings.Rotary.UndercutsFlg = chk_undercut.Check;
		Settings.Rotary.AxisMeetTiltFlg = chk_toolaxiscrossestiltaxis.Check;
		Settings.Rotary.MaintainTiltFlg = chk_maintaintiltaxis.Check;
		if (!chk_tiltXAxis.Check)
		{
			if (!chk_tiltYAxis.Check)
			{
				if (chk_tiltZAxis.Check)
				{
					Settings.Rotary.TiltAxis = CamExtAxis.ExtAxisZ;
				}
			}
			else
			{
				Settings.Rotary.TiltAxis = CamExtAxis.ExtAxisY;
			}
		}
		else
		{
			Settings.Rotary.TiltAxis = CamExtAxis.ExtAxisX;
		}
		if (!chk_notbetilted.Check)
		{
			if (!chk_betiltedeleative.Check)
			{
				if (chk_tiltedwithfixangle.Check)
				{
					Settings.Rotary.TiltStrategy = CamTiltStrategy.FixedAngle;
				}
			}
			else
			{
				Settings.Rotary.TiltStrategy = CamTiltStrategy.RelativeToCuttingDir;
			}
		}
		else
		{
			Settings.Rotary.TiltStrategy = CamTiltStrategy.NoTilt;
		}
		if (!chk_followsurfaceisodir.Check)
		{
			if (!chk_orthotocutdirection.Check)
			{
				if (chk_usespindlemaindir.Check)
				{
					Settings.Rotary.SideTiltDefTypes = CamSideTiltDefTypes.UseSpindleMainDir;
				}
			}
			else
			{
				Settings.Rotary.SideTiltDefTypes = CamSideTiltDefTypes.OrthoToCutDirAtEachPos;
			}
		}
		else
		{
			Settings.Rotary.SideTiltDefTypes = CamSideTiltDefTypes.FollowSurfIsoDir;
		}
		if (camType == CamType.Projection)
		{
			Settings.Offsets.AdditionalOffset = spn_offsetProjection.Value;
			Settings.Strategy.CylinderRadiusAroundLine = spn_radiusProjection.Value;
			Settings.Strategy.SideShift = spn_sideshiftProjection.Value;
			Settings.Strategy.ProjectionStartAngles = spn_startangleProjection.Value;
			Settings.Strategy.ProjectionEndAngles = spn_endangleProjection.Value;
			Settings.Strategy.ProjectionStartHeight = spn_startheightProjection.Value;
			Settings.Strategy.ProjectionEndHeight = spn_endheightProjection.Value;
			Settings.Strategy.ProjectionLineX = spn_lineXProjection.Value;
			Settings.Strategy.ProjectionLineY = spn_lineYProjection.Value;
			Settings.Strategy.ProjectionLineZ = spn_lineZProjection.Value;
			Settings.Strategy.MultiPassNumberOfRoughCuts = (int)spn_numberroughProjection.Value;
			Settings.Strategy.MultiPassRoughPassSpacing = spn_spacingroughProjection.Value;
			if (!chk_cutorderfromcenterProjection.Check)
			{
				if (!chk_cutorderfromcenterProjection.Check)
				{
					Settings.Strategy.CutOrder = CamCutOrder.OrderStandard;
				}
				else
				{
					Settings.Strategy.CutOrder = CamCutOrder.OrderFromOuter;
				}
			}
			else
			{
				Settings.Strategy.CutOrder = CamCutOrder.OrderFromCenter;
			}
			if (!chk_cwprojection.Check)
			{
				Settings.Strategy.ClosedCutDirection = CamMachiningParamsDirection.DirCounterClockwise;
			}
			else
			{
				Settings.Strategy.ClosedCutDirection = CamMachiningParamsDirection.DirClockwise;
			}
			if (!chk_slicesProjection.Check)
			{
				Settings.Strategy.MultiPassSortType = CamRoughSortType.McSortByPasses;
			}
			else
			{
				Settings.Strategy.MultiPassSortType = CamRoughSortType.McSortBySlices;
			}
		}
		if (camType != CamType.Geodesic)
		{
			return;
		}
		Settings.Distances.Safe = spn_safedistancegeodesic.Value;
		Settings.Distances.Rapid = spn_rapiddistancegeodesic.Value;
		Settings.Speeds.Feed = spn_cuttingspeedgeodesic.Value;
		Settings.Speeds.Plunge = spn_plungespeedgeodesic.Value;
		Settings.Strategy.CutTolerance = spn_cuttolerancegeodesic.Value;
		Settings.Strategy.ReverseCut = chk_flipstepovergeodesic.Check;
		Settings.Strategy.MachiningDirectionAsReferenceForDirectionOfCutsFlg = chk_usemachiningdirectiongeodesic.Check;
		Settings.Offsets.AdditionalOffset = spn_surfaceoffsetgeodesic.Value;
		Settings.Operations.Stepover = spn_stepovergeodesic.Value;
		if (!chk_zigzaggeodesic.Check)
		{
			if (!chk_onewaygeodesic.Check)
			{
				if (chk_spiralgeodesic.Check)
				{
					Settings.Strategy.CuttingMethod = CamCuttingMethod.MachtypeSpiral;
				}
			}
			else
			{
				Settings.Strategy.CuttingMethod = CamCuttingMethod.MachtypeOneway;
			}
		}
		else
		{
			Settings.Strategy.CuttingMethod = CamCuttingMethod.MachtypeZigzag;
		}
		if (!chk_regiongeodesic.Check)
		{
			if (chk_levelgeodesic.Check)
			{
				Settings.Strategy.MachiningAreaMode = CamMachiningAreaMode.MachByLanes;
			}
		}
		else
		{
			Settings.Strategy.MachiningAreaMode = CamMachiningAreaMode.MachByRegions;
		}
		if (!chk_toolcentermodegeodesic.Check)
		{
			if (chk_contactmodegeodesic.Check)
			{
				Settings.Strategy.OutputPatternFlag = true;
			}
		}
		else
		{
			Settings.Strategy.OutputPatternFlag = false;
		}
		if (!chk_morphbetweentwocurvegeodesic.Check)
		{
			if (chk_paralleltomultiplecurvegeodesic.Check)
			{
				Settings.Strategy.GeodesicType = CamGeodesicType.TmbGeodesicOffset;
			}
		}
		else
		{
			Settings.Strategy.GeodesicType = CamGeodesicType.TmbGeodesicMorph;
		}
		if (!chk_cointainmentgeodesic.Check)
		{
			if (!chk_medialaxisofcontainmentgeodesic.Check)
			{
				if (!chk_circleatcentercontainmentgeodesic.Check)
				{
					if (!chk_boundrycurvesmachiningsurfacegeodesic.Check)
					{
						if (chk_userdefinecontainmentgeodesic.Check)
						{
							Settings.Strategy.GeodesicDriveInputType = CamGeodesicDriveInputType.TmbGditUserDefined;
						}
					}
					else
					{
						Settings.Strategy.GeodesicDriveInputType = CamGeodesicDriveInputType.TmbGditSurface;
					}
				}
				else
				{
					Settings.Strategy.GeodesicDriveInputType = CamGeodesicDriveInputType.TmbGditCenter;
				}
			}
			else
			{
				Settings.Strategy.GeodesicDriveInputType = CamGeodesicDriveInputType.TmbGditUserDefinedMesh;
			}
		}
		else
		{
			Settings.Strategy.GeodesicDriveInputType = CamGeodesicDriveInputType.TmbGditMachining;
		}
		if (!chk_automaticcontainmentgeodesic.Check)
		{
			if (!chk_userdefinecontainmentgeodesic.Check)
			{
				if (!chk_userdefinecontainmentsillhouttegeodesic.Check)
				{
					if (chk_sillhouttegeodesic.Check)
					{
						Settings.Strategy.GeodesicContainmetType = CamGeodesicContainmentType.TmbGdpdSilhouette;
					}
				}
				else
				{
					Settings.Strategy.GeodesicContainmetType = CamGeodesicContainmentType.TmbGdpdUserDefinedAndSilhouette;
				}
			}
			else
			{
				Settings.Strategy.GeodesicContainmetType = CamGeodesicContainmentType.TmbGdpdUserDefined;
			}
		}
		else
		{
			Settings.Strategy.GeodesicContainmetType = CamGeodesicContainmentType.TmbGdpdAuto;
		}
		if (!chk_contantstepovergeodesic.Check)
		{
			if (!chk_maxstepovergeodesic.Check)
			{
				if (chk_autonocutgeodesic.Check)
				{
					Settings.Strategy.GeodesicStepoverType = CamGeodesicStepover.TmbGsAuto;
				}
			}
			else
			{
				Settings.Strategy.GeodesicStepoverType = CamGeodesicStepover.TmbGsMaximum;
			}
		}
		else
		{
			Settings.Strategy.GeodesicStepoverType = CamGeodesicStepover.TmbGsConstant;
		}
		if (!chk_cutorderfromcenterawaygeodesic.Check)
		{
			if (!chk_cutorderfromoutsidetocentergeodesic.Check)
			{
				if (!chk_cutorderwipefromdirectiongeodesic.Check)
				{
					Settings.Strategy.CutOrder = CamCutOrder.OrderStandard;
				}
				else
				{
					Settings.Strategy.CutOrder = CamCutOrder.OrderWipeFromOneSide;
				}
			}
			else
			{
				Settings.Strategy.CutOrder = CamCutOrder.OrderFromOuter;
			}
		}
		else
		{
			Settings.Strategy.CutOrder = CamCutOrder.OrderFromCenter;
		}
	}

	public void MenuButtonColors(int PageIndex)
	{
		Control.ControlCollection controls = buGround1.Controls;
		controls = hmiUICommands.SetVisualItem(controls);
		if (PageIndex == 0)
		{
			btn_camstrategy.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_camstrategy.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			if (camType != CamType.Geodesic)
			{
				buTab_1.SelectedIndex = PageIndex;
			}
			else
			{
				buTab_1.SelectedIndex = 1;
			}
		}
		if (PageIndex == 1)
		{
			btn_advanced.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_advanced.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			buTab_1.SelectedIndex = 2;
		}
		if (PageIndex == 2)
		{
			btn_5Axis.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_5Axis.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			buTab_1.SelectedIndex = 3;
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == btn_ok.Name)
			{
				Apply();
				PropertiesForm.Result = DialogResult.OK;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
			if ((control.Name == btn_close.Name) | (control.Name == btn_cancel.Name))
			{
				PropertiesForm.Result = DialogResult.Cancel;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
			if (control.Name == btn_camstrategy.Name)
			{
				MenuButtonColors(0);
			}
			if (control.Name == btn_advanced.Name)
			{
				MenuButtonColors(1);
			}
			if (control.Name == btn_5Axis.Name)
			{
				MenuButtonColors(2);
			}
		}
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			buSpin buSpin2 = sender as buSpin;
			buSpin2.SelectAll();
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
		if (AppBool.TouchPad)
		{
			F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
			f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadNumV.Caption = buSpin2.Caption.Caption;
			f_KeyPadNumV.ShowDialog(buSpin2.Value.ToString());
			if (buNumeric5.IsNumeric(f_KeyPadNumV.Value))
			{
				buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
			}
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if ((chk_zigzag.Name == control.Name) | (chk_oneway.Name == control.Name) | (chk_spiral.Name == control.Name))
		{
			chk_zigzag.Check = false;
			chk_oneway.Check = false;
			chk_spiral.Check = false;
			if (chk_zigzag.Name == control.Name)
			{
				chk_zigzag.Check = true;
			}
			if (chk_oneway.Name == control.Name)
			{
				chk_oneway.Check = true;
			}
			if (chk_spiral.Name == control.Name)
			{
				chk_spiral.Check = true;
			}
		}
		if ((chk_level.Name == control.Name) | (chk_region.Name == control.Name))
		{
			chk_level.Check = false;
			chk_region.Check = false;
			if (chk_level.Name == control.Name)
			{
				chk_level.Check = true;
			}
			if (chk_region.Name == control.Name)
			{
				chk_region.Check = true;
			}
		}
		if ((chk_roughadaptive.Name == control.Name) | (chk_roughoffset.Name == control.Name) | (chk_roughparalel.Name == control.Name))
		{
			chk_roughadaptive.Check = false;
			chk_roughoffset.Check = false;
			chk_spiral.Check = false;
			if (chk_roughadaptive.Name == control.Name)
			{
				chk_roughadaptive.Check = true;
			}
			if (chk_roughoffset.Name == control.Name)
			{
				chk_roughoffset.Check = true;
			}
			if (chk_roughparalel.Name == control.Name)
			{
				chk_roughparalel.Check = true;
			}
		}
		if ((chk_roughstocksurface.Name == control.Name) | (chk_roughstockbox.Name == control.Name))
		{
			chk_roughstocksurface.Check = false;
			chk_roughstockbox.Check = false;
			if (chk_roughstocksurface.Name == control.Name)
			{
				chk_roughstocksurface.Check = true;
			}
			if (chk_roughstockbox.Name == control.Name)
			{
				chk_roughstockbox.Check = true;
			}
		}
		if ((chk_xdirectionparallel.Name == control.Name) | (chk_ydirectionparallel.Name == control.Name) | (chk_Angledirectionparallel.Name == control.Name))
		{
			chk_xdirectionparallel.Check = false;
			chk_ydirectionparallel.Check = false;
			chk_Angledirectionparallel.Check = false;
			if (chk_xdirectionparallel.Name == control.Name)
			{
				chk_xdirectionparallel.Check = true;
			}
			if (chk_ydirectionparallel.Name == control.Name)
			{
				chk_ydirectionparallel.Check = true;
			}
			if (chk_Angledirectionparallel.Name == control.Name)
			{
				chk_Angledirectionparallel.Check = true;
			}
		}
		if ((chk_cornerlowerleftparallel.Name == control.Name) | (chk_cornerlowerrightparallel.Name == control.Name) | (chk_cornerupperleftparallel.Name == control.Name) | (chk_cornerupperrightparallel.Name == control.Name))
		{
			chk_cornerlowerleftparallel.Check = false;
			chk_cornerlowerrightparallel.Check = false;
			chk_cornerupperleftparallel.Check = false;
			chk_cornerupperrightparallel.Check = false;
			if (chk_cornerlowerleftparallel.Name == control.Name)
			{
				chk_cornerlowerleftparallel.Check = true;
			}
			if (chk_cornerlowerrightparallel.Name == control.Name)
			{
				chk_cornerlowerrightparallel.Check = true;
			}
			if (chk_cornerupperleftparallel.Name == control.Name)
			{
				chk_cornerupperleftparallel.Check = true;
			}
			if (chk_cornerupperrightparallel.Name == control.Name)
			{
				chk_cornerupperrightparallel.Check = true;
			}
		}
		if ((chk_StartAtbottomconstantZ.Name == control.Name) | (chk_StartAttopconstantZ.Name == control.Name))
		{
			chk_StartAtbottomconstantZ.Check = false;
			chk_StartAttopconstantZ.Check = false;
			if (chk_StartAtbottomconstantZ.Name == control.Name)
			{
				chk_StartAtbottomconstantZ.Check = true;
			}
			if (chk_StartAttopconstantZ.Name == control.Name)
			{
				chk_StartAttopconstantZ.Check = true;
			}
		}
		if ((chk_verticalwallmachineonlyconstantZ.Name == control.Name) | (chk_verticalwallincludeconstantZ.Name == control.Name) | (chk_verticalwallexcludeconstantZ.Name == control.Name))
		{
			chk_verticalwallmachineonlyconstantZ.Check = false;
			chk_verticalwallincludeconstantZ.Check = false;
			chk_verticalwallexcludeconstantZ.Check = false;
			if (chk_verticalwallmachineonlyconstantZ.Name == control.Name)
			{
				chk_verticalwallmachineonlyconstantZ.Check = true;
			}
			if (chk_verticalwallincludeconstantZ.Name == control.Name)
			{
				chk_verticalwallincludeconstantZ.Check = true;
			}
			if (chk_verticalwallexcludeconstantZ.Name == control.Name)
			{
				chk_verticalwallexcludeconstantZ.Check = true;
			}
		}
		if ((chk_flatlandadaptive.Name == control.Name) | (chk_flatlandoffset.Name == control.Name) | (chk_flatlandparallel.Name == control.Name))
		{
			chk_flatlandadaptive.Check = false;
			chk_flatlandoffset.Check = false;
			chk_flatlandparallel.Check = false;
			if (chk_flatlandadaptive.Name == control.Name)
			{
				chk_flatlandadaptive.Check = true;
			}
			if (chk_flatlandoffset.Name == control.Name)
			{
				chk_flatlandoffset.Check = true;
			}
			if (chk_flatlandparallel.Name == control.Name)
			{
				chk_flatlandparallel.Check = true;
			}
		}
		if ((chk_singlestepawideflatland.Name == control.Name) | (chk_singlestepnarrowandwideflatland.Name == control.Name) | (chk_singlestepnarrowflatland.Name == control.Name))
		{
			chk_singlestepawideflatland.Check = false;
			chk_singlestepnarrowandwideflatland.Check = false;
			chk_singlestepnarrowflatland.Check = false;
			if (chk_singlestepawideflatland.Name == control.Name)
			{
				chk_singlestepawideflatland.Check = true;
			}
			if (chk_singlestepnarrowandwideflatland.Name == control.Name)
			{
				chk_singlestepnarrowandwideflatland.Check = true;
			}
			if (chk_singlestepnarrowflatland.Name == control.Name)
			{
				chk_singlestepnarrowflatland.Check = true;
			}
		}
		if ((chk_cutorderfrombottomtotoppencil.Name == control.Name) | (chk_cutorderfromcenterawaypencil.Name == control.Name) | (chk_cutorderfromoutsidetocenterpencil.Name == control.Name) | (chk_cutorderfromtoptobottompencil.Name == control.Name) | (chk_cutorderstandartpencil.Name == control.Name))
		{
			chk_cutorderfrombottomtotoppencil.Check = false;
			chk_cutorderfromcenterawaypencil.Check = false;
			chk_cutorderfromoutsidetocenterpencil.Check = false;
			chk_cutorderfromtoptobottompencil.Check = false;
			chk_cutorderstandartpencil.Check = false;
			if (chk_cutorderfrombottomtotoppencil.Name == control.Name)
			{
				chk_cutorderfrombottomtotoppencil.Check = true;
			}
			if (chk_cutorderfromcenterawaypencil.Name == control.Name)
			{
				chk_cutorderfromcenterawaypencil.Check = true;
			}
			if (chk_cutorderfromoutsidetocenterpencil.Name == control.Name)
			{
				chk_cutorderfromoutsidetocenterpencil.Check = true;
			}
			if (chk_cutorderfromtoptobottompencil.Name == control.Name)
			{
				chk_cutorderfromtoptobottompencil.Check = true;
			}
			if (chk_cutorderstandartpencil.Name == control.Name)
			{
				chk_cutorderstandartpencil.Check = true;
			}
		}
		if ((chk_cutorderfrombottomtotopConstcusp.Name == control.Name) | (chk_cutorderfromcenterawayConstcusp.Name == control.Name) | (chk_cutorderfromoutsidetocenterConstcusp.Name == control.Name) | (chk_cutorderfromtoptobottomConstcusp.Name == control.Name) | (chk_cutorderstandartConstcusp.Name == control.Name))
		{
			chk_cutorderfrombottomtotopConstcusp.Check = false;
			chk_cutorderfromcenterawayConstcusp.Check = false;
			chk_cutorderfromoutsidetocenterConstcusp.Check = false;
			chk_cutorderfromtoptobottomConstcusp.Check = false;
			chk_cutorderstandartConstcusp.Check = false;
			if (chk_cutorderfrombottomtotopConstcusp.Name == control.Name)
			{
				chk_cutorderfrombottomtotopConstcusp.Check = true;
			}
			if (chk_cutorderfromcenterawayConstcusp.Name == control.Name)
			{
				chk_cutorderfromcenterawayConstcusp.Check = true;
			}
			if (chk_cutorderfromoutsidetocenterConstcusp.Name == control.Name)
			{
				chk_cutorderfromoutsidetocenterConstcusp.Check = true;
			}
			if (chk_cutorderfromtoptobottomConstcusp.Name == control.Name)
			{
				chk_cutorderfromtoptobottomConstcusp.Check = true;
			}
			if (chk_cutorderstandartConstcusp.Name == control.Name)
			{
				chk_cutorderstandartConstcusp.Check = true;
			}
		}
		if ((chk_stepdirbothConstcusp.Name == control.Name) | (chk_stepdirleftConstcusp.Name == control.Name) | (chk_stepdirrightConstcusp.Name == control.Name))
		{
			chk_stepdirbothConstcusp.Check = false;
			chk_stepdirleftConstcusp.Check = false;
			chk_stepdirrightConstcusp.Check = false;
			if (chk_stepdirbothConstcusp.Name == control.Name)
			{
				chk_stepdirbothConstcusp.Check = true;
			}
			if (chk_stepdirleftConstcusp.Name == control.Name)
			{
				chk_stepdirleftConstcusp.Check = true;
			}
			if (chk_stepdirrightConstcusp.Name == control.Name)
			{
				chk_stepdirrightConstcusp.Check = true;
			}
		}
		if ((chk_silhouettenone.Name == control.Name) | (chk_silhouettepart.Name == control.Name) | (chk_silhouettepartend.Name == control.Name) | (chk_silhouettetoolcontact.Name == control.Name))
		{
			chk_silhouettenone.Check = false;
			chk_silhouettepart.Check = false;
			chk_silhouettepartend.Check = false;
			chk_silhouettetoolcontact.Check = false;
			if (chk_silhouettenone.Name == control.Name)
			{
				chk_silhouettenone.Check = true;
			}
			if (chk_silhouettepart.Name == control.Name)
			{
				chk_silhouettepart.Check = true;
			}
			if (chk_silhouettepartend.Name == control.Name)
			{
				chk_silhouettepartend.Check = true;
			}
			if (chk_silhouettetoolcontact.Name == control.Name)
			{
				chk_silhouettetoolcontact.Check = true;
			}
		}
		if ((chk_anglerangebetweenslopeangles.Name == control.Name) | (chk_anglerangeoutsideslopeangles.Name == control.Name))
		{
			chk_anglerangebetweenslopeangles.Check = false;
			chk_anglerangeoutsideslopeangles.Check = false;
			if (chk_anglerangebetweenslopeangles.Name == control.Name)
			{
				chk_anglerangebetweenslopeangles.Check = true;
			}
			if (chk_anglerangeoutsideslopeangles.Name == control.Name)
			{
				chk_anglerangeoutsideslopeangles.Check = true;
			}
		}
		if ((chk_notbetilted.Name == control.Name) | (chk_betiltedeleative.Name == control.Name) | (chk_tiltedwithfixangle.Name == control.Name))
		{
			chk_notbetilted.Check = false;
			chk_betiltedeleative.Check = false;
			chk_tiltedwithfixangle.Check = false;
			if (chk_notbetilted.Name == control.Name)
			{
				chk_notbetilted.Check = true;
			}
			if (chk_betiltedeleative.Name == control.Name)
			{
				chk_betiltedeleative.Check = true;
			}
			if (chk_tiltedwithfixangle.Name == control.Name)
			{
				chk_tiltedwithfixangle.Check = true;
			}
		}
		if ((chk_orthotocutdirection.Name == control.Name) | (chk_usespindlemaindir.Name == control.Name) | (chk_followsurfaceisodir.Name == control.Name))
		{
			chk_followsurfaceisodir.Check = false;
			chk_betiltedeleative.Check = false;
			chk_tiltedwithfixangle.Check = false;
			if (chk_followsurfaceisodir.Name == control.Name)
			{
				chk_followsurfaceisodir.Check = true;
			}
			if (chk_orthotocutdirection.Name == control.Name)
			{
				chk_orthotocutdirection.Check = true;
			}
			if (chk_usespindlemaindir.Name == control.Name)
			{
				chk_usespindlemaindir.Check = true;
			}
		}
		if ((chk_tiltXAxis.Name == control.Name) | (chk_tiltYAxis.Name == control.Name) | (chk_tiltZAxis.Name == control.Name))
		{
			chk_tiltXAxis.Check = false;
			chk_tiltYAxis.Check = false;
			chk_tiltZAxis.Check = false;
			if (chk_tiltXAxis.Name == control.Name)
			{
				chk_tiltXAxis.Check = true;
			}
			if (chk_tiltYAxis.Name == control.Name)
			{
				chk_tiltYAxis.Check = true;
			}
			if (chk_tiltZAxis.Name == control.Name)
			{
				chk_tiltZAxis.Check = true;
			}
		}
		if ((chk_contantstepovergeodesic.Name == control.Name) | (chk_maxstepovergeodesic.Name == control.Name) | (chk_autonocutgeodesic.Name == control.Name))
		{
			chk_contantstepovergeodesic.Check = false;
			chk_maxstepovergeodesic.Check = false;
			chk_autonocutgeodesic.Check = false;
			if (chk_contantstepovergeodesic.Name == control.Name)
			{
				chk_contantstepovergeodesic.Check = true;
			}
			if (chk_maxstepovergeodesic.Name == control.Name)
			{
				chk_maxstepovergeodesic.Check = true;
			}
			if (chk_autonocutgeodesic.Name == control.Name)
			{
				chk_autonocutgeodesic.Check = true;
			}
		}
		if ((chk_zigzaggeodesic.Name == control.Name) | (chk_onewaygeodesic.Name == control.Name) | (chk_spiralgeodesic.Name == control.Name))
		{
			chk_zigzaggeodesic.Check = false;
			chk_onewaygeodesic.Check = false;
			chk_spiralgeodesic.Check = false;
			if (chk_zigzaggeodesic.Name == control.Name)
			{
				chk_zigzaggeodesic.Check = true;
			}
			if (chk_onewaygeodesic.Name == control.Name)
			{
				chk_onewaygeodesic.Check = true;
			}
			if (chk_spiralgeodesic.Name == control.Name)
			{
				chk_spiralgeodesic.Check = true;
			}
		}
		if ((chk_levelgeodesic.Name == control.Name) | (chk_regiongeodesic.Name == control.Name))
		{
			chk_levelgeodesic.Check = false;
			chk_regiongeodesic.Check = false;
			if (chk_levelgeodesic.Name == control.Name)
			{
				chk_levelgeodesic.Check = true;
			}
			if (chk_regiongeodesic.Name == control.Name)
			{
				chk_regiongeodesic.Check = true;
			}
		}
		if ((chk_toolcentermodegeodesic.Name == control.Name) | (chk_contactmodegeodesic.Name == control.Name))
		{
			chk_toolcentermodegeodesic.Check = false;
			chk_contactmodegeodesic.Check = false;
			if (chk_toolcentermodegeodesic.Name == control.Name)
			{
				chk_toolcentermodegeodesic.Check = true;
			}
			if (chk_contactmodegeodesic.Name == control.Name)
			{
				chk_contactmodegeodesic.Check = true;
			}
		}
		if ((chk_paralleltomultiplecurvegeodesic.Name == control.Name) | (chk_morphbetweentwocurvegeodesic.Name == control.Name))
		{
			chk_paralleltomultiplecurvegeodesic.Check = false;
			chk_morphbetweentwocurvegeodesic.Check = false;
			if (chk_paralleltomultiplecurvegeodesic.Name == control.Name)
			{
				chk_paralleltomultiplecurvegeodesic.Check = true;
			}
			if (chk_morphbetweentwocurvegeodesic.Name == control.Name)
			{
				chk_morphbetweentwocurvegeodesic.Check = true;
			}
		}
		if ((chk_cointainmentgeodesic.Name == control.Name) | (chk_medialaxisofcontainmentgeodesic.Name == control.Name) | (chk_circleatcentercontainmentgeodesic.Name == control.Name) | (chk_boundrycurvesmachiningsurfacegeodesic.Name == control.Name) | (chk_userdefinescurves.Name == control.Name))
		{
			chk_userdefinescurves.Check = false;
			chk_cointainmentgeodesic.Check = false;
			chk_medialaxisofcontainmentgeodesic.Check = false;
			chk_circleatcentercontainmentgeodesic.Check = false;
			chk_boundrycurvesmachiningsurfacegeodesic.Check = false;
			if (chk_userdefinescurves.Name == control.Name)
			{
				chk_userdefinescurves.Check = true;
			}
			if (chk_cointainmentgeodesic.Name == control.Name)
			{
				chk_cointainmentgeodesic.Check = true;
			}
			if (chk_medialaxisofcontainmentgeodesic.Name == control.Name)
			{
				chk_medialaxisofcontainmentgeodesic.Check = true;
			}
			if (chk_circleatcentercontainmentgeodesic.Name == control.Name)
			{
				chk_circleatcentercontainmentgeodesic.Check = true;
			}
			if (chk_boundrycurvesmachiningsurfacegeodesic.Name == control.Name)
			{
				chk_boundrycurvesmachiningsurfacegeodesic.Check = true;
			}
		}
		if ((chk_automaticcontainmentgeodesic.Name == control.Name) | (chk_userdefinecontainmentgeodesic.Name == control.Name) | (chk_sillhouttegeodesic.Name == control.Name) | (chk_userdefinecontainmentsillhouttegeodesic.Name == control.Name))
		{
			chk_userdefinecontainmentsillhouttegeodesic.Check = false;
			chk_automaticcontainmentgeodesic.Check = false;
			chk_userdefinecontainmentgeodesic.Check = false;
			chk_sillhouttegeodesic.Check = false;
			if (chk_userdefinecontainmentsillhouttegeodesic.Name == control.Name)
			{
				chk_userdefinecontainmentsillhouttegeodesic.Check = true;
			}
			if (chk_automaticcontainmentgeodesic.Name == control.Name)
			{
				chk_automaticcontainmentgeodesic.Check = true;
			}
			if (chk_userdefinecontainmentgeodesic.Name == control.Name)
			{
				chk_userdefinecontainmentgeodesic.Check = true;
			}
			if (chk_sillhouttegeodesic.Name == control.Name)
			{
				chk_sillhouttegeodesic.Check = true;
			}
		}
		if ((chk_cutorderstandartgeodesic.Name == control.Name) | (chk_cutorderfromcenterawaygeodesic.Name == control.Name) | (chk_cutorderfromoutsidetocentergeodesic.Name == control.Name) | (chk_cutorderwipefromdirectiongeodesic.Name == control.Name))
		{
			chk_cutorderwipefromdirectiongeodesic.Check = false;
			chk_cutorderfromoutsidetocentergeodesic.Check = false;
			chk_cutorderfromcenterawaygeodesic.Check = false;
			chk_cutorderstandartgeodesic.Check = false;
			if (chk_cutorderwipefromdirectiongeodesic.Name == control.Name)
			{
				chk_cutorderwipefromdirectiongeodesic.Check = true;
			}
			if (chk_cutorderfromoutsidetocentergeodesic.Name == control.Name)
			{
				chk_cutorderfromoutsidetocentergeodesic.Check = true;
			}
			if (chk_cutorderfromcenterawaygeodesic.Name == control.Name)
			{
				chk_cutorderfromcenterawaygeodesic.Check = true;
			}
			if (chk_cutorderstandartgeodesic.Name == control.Name)
			{
				chk_cutorderstandartgeodesic.Check = true;
			}
		}
		if ((chk_cwprojection.Name == control.Name) | (chk_ccwprojection.Name == control.Name))
		{
			chk_cwprojection.Check = false;
			chk_ccwprojection.Check = false;
			if (chk_cwprojection.Name == control.Name)
			{
				chk_cwprojection.Check = true;
			}
			if (chk_ccwprojection.Name == control.Name)
			{
				chk_ccwprojection.Check = true;
			}
		}
		if ((chk_slicesProjection.Name == control.Name) | (chk_passesProjection.Name == control.Name))
		{
			chk_slicesProjection.Check = false;
			chk_passesProjection.Check = false;
			if (chk_slicesProjection.Name == control.Name)
			{
				chk_slicesProjection.Check = true;
			}
			if (chk_passesProjection.Name == control.Name)
			{
				chk_passesProjection.Check = true;
			}
		}
		if ((chk_cutorderfromcenterProjection.Name == control.Name) | (chk_cutorderfromoutsideProjection.Name == control.Name) | (chk_cutorderstandartProjection.Name == control.Name))
		{
			chk_cutorderstandartProjection.Check = false;
			chk_cutorderfromoutsideProjection.Check = false;
			chk_cutorderfromcenterProjection.Check = false;
			if (chk_cutorderstandartProjection.Name == control.Name)
			{
				chk_cutorderstandartProjection.Check = true;
			}
			if (chk_cutorderfromoutsideProjection.Name == control.Name)
			{
				chk_cutorderfromoutsideProjection.Check = true;
			}
			if (chk_cutorderfromcenterProjection.Name == control.Name)
			{
				chk_cutorderfromcenterProjection.Check = true;
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
