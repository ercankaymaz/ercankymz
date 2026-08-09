using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using _0005;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buCadCamResVer5;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using devDept.Geometry;

namespace buMarble.Forms;

public class F_MarbleKinematic : Form
{
	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions;

	public KinematicBase5 Kinematic = new KinematicBase5();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer m__0001 = null;

	internal buGround _0001;

	public buSpin spn_A_AxisSawDistance;

	public buSpin spn_motor_A_AxisZDistance;

	public buSpin spn_C_AxisSawDistance;

	internal PictureBox _0001;

	internal buLabel _0001;

	internal buLabel _0002;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buButton btn_openkinematic;

	public buButton btn_savekinemtic;

	public buButton btn_options;

	internal buPanel _0001;

	public buButton btn_closeadvanced;

	internal buLabel _0003;

	public buSpin spn_c0ZDisA0;

	internal buLabel _0004;

	internal buLabel _0005;

	internal buLabel _0006;

	internal buLabel _0007;

	internal buLabel _0008;

	internal buLabel _000E;

	internal buLabel _000F;

	public buSpin spn_c270ZDisA45;

	public buSpin spn_c180ZDisA45;

	public buSpin spn_c90ZDisA45;

	public buSpin spn_c0ZDisA45;

	public buSpin spn_c270ADisA45;

	public buSpin spn_c180ADisA45;

	public buSpin spn_c90ADisA45;

	public buSpin spn_c0ADisA45;

	public buSpin spn_c270ZDisA0;

	public buSpin spn_c180ZDisA0;

	public buSpin spn_c90ZDisA0;

	internal buPanel _0002;

	internal buLabel _0010;

	internal buLabel _0011;

	public buSpin spn_measuredYDistanceA0A45;

	public buButton btn_adistancecalc;

	internal buLabel _0012;

	public buSpin spn_ACalculated;

	public buButton btn_acentercalcshow;

	public buButton btn_closeAcalc;

	public buButton btn_A45ZPosGet;

	internal buLabel _0013;

	public buSpin spn_A45ZPos;

	public buButton btn_A0ZPosGet;

	internal buLabel _0014;

	public buSpin spn_A0ZPos;

	public buSpin spn_c270CDis;

	public buSpin spn_c180CDis;

	public buSpin spn_c90CDis;

	public buSpin spn_c0CDis;

	internal buLabel _0015;

	public buButton btn_stop;

	public buButton btn_closecross;

	public buButton btn_mdi;

	public buButton btn_jog;

	[NonSerialized]
	internal static GetString _0080;

	public F_MarbleKinematic()
	{
		global::_0005._0003._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			global::_008D._008F_0007(this, PropertiesForm.Height);
		}
		if (PropertiesForm.Width > 10)
		{
			global::_008D._008E_0007(this, PropertiesForm.Width);
		}
		global::_0082._008D_0005(this, PropertiesForm.TopMost);
		global::_009C._001A_0008(this, PropertiesForm.FormPosition);
		global::_0095._007E_0008_0008(spn_A_AxisSawDistance, Kinematic.RotateCenterOffsetOfA.Y);
		global::_0095._007E_0008_0008(spn_motor_A_AxisZDistance, Kinematic.RotateCenterOffsetOfA.Z);
		do
		{
			global::_0095._007E_0008_0008(spn_C_AxisSawDistance, Kinematic.RotateCenterOffsetOfC.Y);
			global::_0095._007E_0008_0008(spn_c0ZDisA0, Kinematic.ZDistanceForA0AtC0);
		}
		while (false);
		global::_0095._007E_0008_0008(spn_c90ZDisA0, Kinematic.ZDistanceForA0AtC90);
		global::_0095._007E_0008_0008(spn_c180ZDisA0, Kinematic.ZDistanceForA0AtC180);
		do
		{
			global::_0095._007E_0008_0008(spn_c270ZDisA0, Kinematic.ZDistanceForA0AtC270);
			global::_0095._007E_0008_0008(spn_c0ZDisA45, Kinematic.ZDistanceForA45AtC0);
		}
		while (7 == 0);
		global::_0095._007E_0008_0008(spn_c90ZDisA45, Kinematic.ZDistanceForA45AtC90);
		global::_0095._007E_0008_0008(spn_c180ZDisA45, Kinematic.ZDistanceForA45AtC180);
		global::_0095._007E_0008_0008(spn_c270ZDisA45, Kinematic.ZDistanceForA45AtC270);
		global::_0095._007E_0008_0008(spn_c0ADisA45, Kinematic.ADistanceForA45AtC0);
		global::_0095._007E_0008_0008(spn_c90ADisA45, Kinematic.ADistanceForA45AtC90);
		global::_0095._007E_0008_0008(spn_c180ADisA45, Kinematic.ADistanceForA45AtC180);
		global::_0095._007E_0008_0008(spn_c270ADisA45, Kinematic.ADistanceForA45AtC270);
		global::_0095._007E_0008_0008(spn_c0CDis, Kinematic.CDistanceAtC0);
		global::_0095._007E_0008_0008(spn_c90CDis, Kinematic.CDistanceAtC90);
		global::_0095._007E_0008_0008(spn_c180CDis, Kinematic.CDistanceAtC180);
		global::_0095._007E_0008_0008(spn_c270CDis, Kinematic.CDistanceAtC270);
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			global::_008B._007E_0088_0006(this._0001, buLangTranslate.preDef.Kinematic);
			global::_008B._007E_0088_0006(this._0001, buLangTranslate.preCaptionMarble.CRotateCenter);
			global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_C_AxisSawDistance), buLangTranslate.preCaptionMarble.CAxisToSawEdgeDistance);
			global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_motor_A_AxisZDistance), buLangTranslate.preCaptionMarble.MotorShaftAndAAxisZDistance);
			global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_A_AxisSawDistance), buLangTranslate.preCaptionMarble.AAxisToSawEdgeDistance);
			global::_008B._007E_0088_0006(btn_cancel, buLangTranslate.preDef.Cancel);
			global::_008B._007E_0088_0006(btn_ok, buLangTranslate.preDef.Ok);
			global::_008B._007E_0088_0006(btn_openkinematic, buLangTranslate.preDef.Open);
			global::_008B._007E_0088_0006(btn_savekinemtic, buLangTranslate.preDef.Save);
			global::_008B._007E_0088_0006(btn_options, buLangTranslate.preDef.Option);
			global::_008B._007E_0088_0006(btn_acentercalcshow, global::_0014_0002._0091_0008(_0080(107386960), buLangTranslate.preDef.Distance, _0080(107396149), buLangTranslate.preDef.Calculate));
			global::_008B._007E_0088_0006(btn_jog, global::_0014._009F_0003(buLangTranslate.preDef.Jog, _0080(107396149), buLangTranslate.preDef.Page));
			global::_008B._007E_0088_0006(btn_mdi, _0080(107387564));
			global::_008B._007E_0088_0006(btn_A0ZPosGet, buLangTranslate.preDef.GetPosition);
			global::_008B._007E_0088_0006(btn_A45ZPosGet, buLangTranslate.preDef.GetPosition);
			global::_008B._007E_0088_0006(btn_adistancecalc, global::_0014_0002._0091_0008(_0080(107386960), buLangTranslate.preDef.Distance, _0080(107396149), buLangTranslate.preDef.Calculate));
			global::_008B._007E_0088_0006(this._0003, buLangTranslate.preDef.Option);
			global::_008B._007E_0088_0006(this._0004, global::_0014._009F_0003(_0080(107387509), buLangTranslate.preDef.Distance, _0080(107450559)));
			global::_008B._007E_0088_0006(_000E, global::_0014._009F_0003(_0080(107387509), buLangTranslate.preDef.Distance, _0080(107450514)));
			global::_008B._007E_0088_0006(_000F, global::_0014._009F_0003(_0080(107386960), buLangTranslate.preDef.Distance, _0080(107450514)));
			global::_008B._007E_0088_0006(_0011, global::_0014_0002._0091_0008(_0080(107386960), buLangTranslate.preDef.Distance, _0080(107396149), buLangTranslate.preDef.Calculate));
			global::_008B._007E_0088_0006(_0015, global::_0002._0003(_0080(107450501), buLangTranslate.preDef.Distance));
			global::_008B._007E_0088_0006(_0014, global::_0014._009F_0003(_0080(107387509), buLangTranslate.preDef.Position, _0080(107450528)));
			global::_008B._007E_0088_0006(_0013, global::_0014._009F_0003(_0080(107387509), buLangTranslate.preDef.Position, _0080(107450519)));
			global::_008B._007E_0088_0006(_0010, global::_0002._0003(_0080(107387509), buLangTranslate.preCaptionMarble.MeasuredYDistanceforA0andA45));
			global::_008B._007E_0088_0006(_0012, global::_0002._0003(_0080(107387509), buLangTranslate.preCaptionMarble.CalculatedARotationDistance));
		}
		catch (Exception)
		{
		}
	}

	internal void _0001(object P_0, FormClosingEventArgs P_1)
	{
		while (true)
		{
			bool num = PropertiesForm.Result == DialogResult.OK;
			if (-1 == 0)
			{
				goto IL_0069;
			}
			bool num2 = !num;
			goto IL_00ab;
			IL_00ab:
			bool flag = num2;
			num = flag;
			if (0 == 0)
			{
				if (!num)
				{
					break;
				}
				if (false)
				{
					continue;
				}
				global::_0082._007E_009C_0005(P_1, true);
				PropertiesForm.Result = DialogResult.Cancel;
				bool flag2;
				do
				{
					flag2 = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
				}
				while (6 == 0);
				num = flag2;
			}
			goto IL_0069;
			IL_0069:
			if (num)
			{
				global::_0011._001D_0003(this);
				if (8 == 0)
				{
					break;
				}
			}
			num2 = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
			if (8 == 0)
			{
				goto IL_00ab;
			}
			if (num2)
			{
				global::_0082._0086_0005(this, false);
			}
			break;
		}
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		try
		{
			buSpin buSpin2 = default(buSpin);
			bool touchPad;
			if (0 == 0)
			{
				buSpin obj = P_0 as buSpin;
				if (0 == 0)
				{
					buSpin2 = obj;
				}
				touchPad = AppBool.TouchPad;
			}
			if (6 == 0)
			{
				return;
			}
			bool num = touchPad;
			F_KeyPadNumV1 f_KeyPadNumV;
			if (0 == 0)
			{
				if (!num)
				{
					return;
				}
				f_KeyPadNumV = new F_KeyPadNumV1();
				global::_009C._007E_001A_0008(f_KeyPadNumV, FormStartPosition.CenterParent);
				f_KeyPadNumV.Caption = global::_0005._007E_008A(global::_0096._007E_0012_0008(buSpin2));
				if (0 == 0)
				{
					global::_008B._007E_009B_0006(f_KeyPadNumV, global::_0007._007E_0094(buSpin2).ToString());
					num = _0007_0005._001D_0011(f_KeyPadNumV.Value);
					goto IL_00a0;
				}
				goto IL_00a2;
			}
			goto IL_00a4;
			IL_00a4:
			if (0 == 0)
			{
				if (num)
				{
					global::_0095._007E_0008_0008(buSpin2, _0008_0005._007F_0011(f_KeyPadNumV.Value));
				}
				return;
			}
			goto IL_00a0;
			IL_00a2:
			bool flag;
			num = flag;
			goto IL_00a4;
			IL_00a0:
			flag = num;
			goto IL_00a2;
		}
		catch (Exception ee)
		{
			int id = -1;
			string message = _0080(107397532);
			do
			{
				CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, global::_0005._007E_0080(_0019_0003._000E_000F()), message, _0080(107372327), _0080(107397532), _0080(107397532), id, ee);
				_009E_0004._0014_0011(calculationErrorEventArg, true);
			}
			while (false);
		}
	}

	public void Apply()
	{
		Kinematic.RotateCenterOffsetOfA.Y = global::_0007._007E_0094(spn_A_AxisSawDistance);
		Kinematic.RotateCenterOffsetOfA.Z = global::_0007._007E_0094(spn_motor_A_AxisZDistance);
		Kinematic.RotateCenterOffsetOfC.Y = global::_0007._007E_0094(spn_C_AxisSawDistance);
		Kinematic.OffsetXYZ.Y = 0.0 - Kinematic.RotateCenterOffsetOfC.Y;
		Kinematic.ZDistanceForA0AtC0 = global::_0007._007E_0094(spn_c0ZDisA0);
		Kinematic.ZDistanceForA0AtC90 = global::_0007._007E_0094(spn_c90ZDisA0);
		Kinematic.ZDistanceForA0AtC180 = global::_0007._007E_0094(spn_c180ZDisA0);
		Kinematic.ZDistanceForA0AtC270 = global::_0007._007E_0094(spn_c270ZDisA0);
		Kinematic.ZDistanceForA45AtC0 = global::_0007._007E_0094(spn_c0ZDisA45);
		Kinematic.ZDistanceForA45AtC90 = global::_0007._007E_0094(spn_c90ZDisA45);
		if (8u != 0)
		{
			Kinematic.ZDistanceForA45AtC180 = global::_0007._007E_0094(spn_c180ZDisA45);
			Kinematic.ZDistanceForA45AtC270 = global::_0007._007E_0094(spn_c270ZDisA45);
			Kinematic.ADistanceForA45AtC0 = global::_0007._007E_0094(spn_c0ADisA45);
			Kinematic.ADistanceForA45AtC90 = global::_0007._007E_0094(spn_c90ADisA45);
			Kinematic.ADistanceForA45AtC180 = global::_0007._007E_0094(spn_c180ADisA45);
			Kinematic.ADistanceForA45AtC270 = global::_0007._007E_0094(spn_c270ADisA45);
			Kinematic.CDistanceAtC0 = global::_0007._007E_0094(spn_c0CDis);
			Kinematic.CDistanceAtC90 = global::_0007._007E_0094(spn_c90CDis);
			Kinematic.CDistanceAtC180 = global::_0007._007E_0094(spn_c180CDis);
		}
		Kinematic.CDistanceAtC270 = global::_0007._007E_0094(spn_c270CDis);
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		Apply();
		PropertiesForm.Result = DialogResult.OK;
		bool num = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
		if (4u != 0)
		{
			if (num)
			{
				global::_0011._001D_0003(this);
				if (false)
				{
					return;
				}
			}
			bool flag = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
			num = flag;
		}
		if (num)
		{
			global::_0082._0086_0005(this, false);
		}
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		if (0 == 0)
		{
			if (-1 == 0)
			{
				goto IL_006f;
			}
			PropertiesForm.Result = DialogResult.Cancel;
		}
		bool num = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
		if (false)
		{
			goto IL_002a;
		}
		bool flag = num;
		goto IL_006f;
		IL_002a:
		while (true)
		{
			if (num)
			{
				global::_0011._001D_0003(this);
			}
			num = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
			if (false)
			{
				break;
			}
			if (4u != 0)
			{
				bool flag2 = num;
				num = flag2;
				break;
			}
		}
		if (num)
		{
			global::_0082._0086_0005(this, false);
		}
		return;
		IL_006f:
		num = flag;
		goto IL_002a;
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		while (true)
		{
			if (uint.MaxValue != 0)
			{
				goto IL_0004;
			}
			goto IL_0010;
			IL_0010:
			buSpin buSpin2;
			while (true)
			{
				global::_001F._007E_0002_0005(global::_0083._007E_0008_0006(buSpin2), SpinFocusColor);
				if (false)
				{
					break;
				}
				if (0 == 0)
				{
					return;
				}
			}
			goto IL_0004;
			IL_0004:
			if (false)
			{
				continue;
			}
			buSpin2 = (buSpin)P_0;
			goto IL_0010;
		}
	}

	internal void _0005(object P_0, EventArgs P_1)
	{
		while (true)
		{
			if (uint.MaxValue != 0)
			{
				goto IL_0004;
			}
			goto IL_0010;
			IL_0010:
			buSpin buSpin2;
			while (true)
			{
				global::_001F._007E_0002_0005(global::_0083._007E_0008_0006(buSpin2), SpinBaseColor);
				if (false)
				{
					break;
				}
				if (0 == 0)
				{
					return;
				}
			}
			goto IL_0004;
			IL_0004:
			if (false)
			{
				continue;
			}
			buSpin2 = (buSpin)P_0;
			goto IL_0010;
		}
	}

	internal void _0006(object P_0, EventArgs P_1)
	{
		Control control = P_0 as Control;
		bool num;
		while (true)
		{
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_A0ZPosGet)))
			{
				bool flag = clsAppMarbleVars.cMachine != null;
				num = flag;
				if (8 == 0)
				{
					goto IL_0600;
				}
				if (false)
				{
					break;
				}
				if (num)
				{
					global::_0095._007E_0008_0008(spn_A0ZPos, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition);
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_A45ZPosGet)) && clsAppMarbleVars.cMachine != null)
			{
				global::_0095._007E_0008_0008(spn_A45ZPos, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_stop)) && clsAppMarbleVars.cmdMarble != null)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Stop);
				if (1 == 0)
				{
					goto IL_0584;
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_jog)))
			{
				if (clsAppMarbleItems.frmJogPageV1 != null)
				{
					clsAppMarbleItems.frmJogPageV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
					clsAppMarbleItems.frmJogPageV1.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
					clsAppMarbleItems.frmJogPageV1.Init();
					_0008_0004._007E_0008_0010(clsAppMarbleItems.frmJogPageV1);
				}
				if (false)
				{
					continue;
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_mdi)))
			{
				if (clsAppMarbleItems.frmMDIPageV1 != null)
				{
					clsAppMarbleItems.frmMDIPageV1.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
					clsAppMarbleItems.frmMDIPageV1.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
					clsAppMarbleItems.frmMDIPageV1.Init();
					_0008_0004._007E_0008_0010(clsAppMarbleItems.frmMDIPageV1);
				}
				else if (clsAppMarbleItems.frmMDIPageV2 != null)
				{
					clsAppMarbleItems.frmMDIPageV2.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
					clsAppMarbleItems.frmMDIPageV2.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
					clsAppMarbleItems.frmMDIPageV2.Init();
					_0008_0004._007E_0008_0010(clsAppMarbleItems.frmMDIPageV2);
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_adistancecalc)))
			{
				double num2 = -5.0;
				while (num2 <= 5.0)
				{
					double num3 = 0.0;
					if (8 == 0)
					{
						goto IL_0364;
					}
					double num4 = num3;
					double num5;
					if ((buMarbleCalc.activeToolSaw.Geometry.SocketThickness > 0.0) & (buMarbleCalc.activeToolSaw.Geometry.SocketThickness > buMarbleCalc.activeToolSaw.Geometry.Thickness))
					{
						num5 = buMarbleCalc.activeToolSaw.Geometry.SocketThickness;
						goto IL_0354;
					}
					goto IL_0371;
					IL_0364:
					num4 = num3 / 2.0;
					goto IL_0371;
					IL_0371:
					KinematicBase5 kinematicBase = new KinematicBase5(Kinematic);
					kinematicBase.RotateCenterOffsetOfA.Y = kinematicBase.RotateCenterOffsetOfA.Y + num2;
					kinematicBase.RotateCenterOffsetOfA.Y = kinematicBase.RotateCenterOffsetOfA.Y + num4;
					kinematicBase.RotateCenterOffsetOfC.Y = kinematicBase.RotateCenterOffsetOfC.Y + num4;
					double num6 = buMarbleCalc.activeToolSaw.Geometry.Diameter / 2.0;
					Point3D point3D = new Point3D();
					Pnt6D pnt6D = new Pnt6D();
					num5 = 0.0;
					if (0 == 0)
					{
						Point3D point3D2 = new Point3D(num5, 497.0, 0.0);
						Pnt6D pnt6D2 = new Pnt6D();
						_009B_0006._007E_001F_0013(clsInit.cKinematic5, num6, kinematicBase, new OrientationAngle(45.0, 0.0, 0.0), point3D, ref pnt6D);
						_009B_0006._007E_001F_0013(clsInit.cKinematic5, num6, kinematicBase, new OrientationAngle(45.0, 0.0, 180.0), point3D2, ref pnt6D2);
						double num7 = pnt6D.Y - pnt6D2.Y;
						num2 += 1.0;
						continue;
					}
					goto IL_0354;
					IL_0354:
					num3 = num5 - buMarbleCalc.activeToolSaw.Geometry.Thickness;
					goto IL_0364;
				}
				double num8 = 0.0;
				_009C_0006._007E_007F_0013(clsInit.cMarble, global::_0007._007E_0094(spn_A0ZPos) - global::_0007._007E_0094(spn_A45ZPos), global::_0007._007E_0094(spn_measuredYDistanceA0A45), 45.0, buMarbleCalc.activeToolSaw.Geometry.Diameter, buMarbleCalc.activeToolSaw.Geometry.SocketThickness, ref num8);
				global::_0095._007E_0008_0008(spn_ACalculated, num8);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_closeadvanced)))
			{
				goto IL_0584;
			}
			goto IL_0598;
			IL_0598:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_closeAcalc)))
			{
				global::_0082._007E_0086_0005(this._0002, false);
			}
			bool flag2 = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_acentercalcshow));
			num = flag2;
			goto IL_0600;
			IL_0584:
			global::_0082._007E_0086_0005(this._0001, false);
			goto IL_0598;
			IL_0600:
			if (num)
			{
				if (global::_0003._007E_0008(this._0002))
				{
					global::_0082._007E_0086_0005(this._0002, false);
				}
				else
				{
					global::_0082._007E_0086_0005(this._0002, true);
				}
			}
			num = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_options));
			break;
		}
		if (num)
		{
			if (global::_0003._007E_0008(this._0001))
			{
				global::_0082._007E_0086_0005(this._0001, false);
			}
			else
			{
				global::_0082._007E_0086_0005(this._0001, true);
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		do
		{
			if (8 == 0)
			{
				goto IL_0025;
			}
			if (!disposing)
			{
				goto IL_0014;
			}
			int num = ((this.m__0001 != null) ? 1 : 0);
			goto IL_004b;
			IL_0025:
			global::_0011._007E_001A_0002(this.m__0001);
			continue;
			IL_0014:
			num = 0;
			goto IL_004b;
			IL_004b:
			while (true)
			{
				bool flag = (byte)num != 0;
				while (true)
				{
					num = (flag ? 1 : 0);
					if (3 == 0)
					{
						break;
					}
					if (num == 0)
					{
						goto end_IL_004b;
					}
					if (false)
					{
						continue;
					}
					goto IL_0021;
				}
				continue;
				end_IL_004b:
				break;
			}
			continue;
			IL_0021:
			if (1 == 0)
			{
				goto IL_0014;
			}
			goto IL_0025;
		}
		while (false);
		global::_0082._009D_0005(this, disposing);
	}

	static F_MarbleKinematic()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarbleKinematic));
		Captions = new List<string>();
	}
}
