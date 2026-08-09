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

namespace buMarble.Forms;

public class F_MarbleCalculators : Form
{
	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions;

	public FormProperties PropertiesForm = new FormProperties();

	public int SelectedTab = 0;

	internal IContainer _0001 = null;

	internal buGround _0001;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buTab buTab_tools;

	public TabPage tabPage_saw;

	public TabPage tabPage_mlling;

	public buButton btn_sawdiscalculate;

	public buSpin spn_sawdistooldiameter;

	internal Panel _0001;

	internal PictureBox _0001;

	public buButton btn_pointmove;

	public buButton btn_sawdistance;

	public buButton btn_closecross;

	internal ImageList _0001;

	public buSpin spn_sawdiscalculatedvalue;

	public buSpin spn_sawdissafedistance;

	public buSpin spn_sawdisAAngle;

	public buSpin spn_sawdistargetz;

	public buSpin spn_sawdismaterialdistance;

	public buButton btn_pointmovecalc;

	[NonSerialized]
	internal static GetString _0087;

	public F_MarbleCalculators()
	{
		_0005._0003._0001(this);
	}

	public void Init()
	{
		if (0 == 0)
		{
			PropertiesForm.Inited = false;
			int num = PropertiesForm.Height;
			int num2 = 10;
			bool num3;
			while (true)
			{
				num3 = num > num2;
				if (3u != 0)
				{
					if (num3)
					{
						global::_008D._008F_0007(this, PropertiesForm.Height);
					}
					num = PropertiesForm.Width;
					num2 = 10;
					if (num2 != 0)
					{
						num3 = num > num2;
						break;
					}
					continue;
				}
				break;
			}
			if (num3)
			{
				global::_008D._008E_0007(this, PropertiesForm.Width);
			}
			global::_0082._008D_0005(this, PropertiesForm.TopMost);
			global::_009C._001A_0008(this, PropertiesForm.FormPosition);
			global::_008C._007E_0002_0007(buTab_tools, new Size(1, 1));
			while (7 == 0)
			{
			}
			global::_0095._007E_0008_0008(spn_sawdistooldiameter, buMarbleCalc.activeToolSaw.Geometry.Diameter);
			global::_0095._007E_0008_0008(spn_sawdismaterialdistance, buMarbleCalc.varOperation.MaterialParameter.MaterialThickness);
		}
		global::_0095._007E_0008_0008(spn_sawdistargetz, buMarbleCalc.varOperation.settingMarbleCam.TargetZ);
		LoadLanguage();
		MenuButtonColors(SelectedTab);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			global::_008B._007E_0088_0006(this._0001, buLangTranslate.preDef.Calculate);
			global::_008B._007E_0088_0006(btn_ok, buLangTranslate.preDef.Ok);
			global::_008B._007E_0088_0006(btn_cancel, buLangTranslate.preDef.Cancel);
			global::_008B._007E_0088_0006(btn_sawdistance, global::_0014._009F_0003(buLangTranslate.preDef.Saw, _0087(107396067), buLangTranslate.preDef.Distance));
			global::_008B._007E_0088_0006(btn_sawdiscalculate, buLangTranslate.preDef.Calculate);
			global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_sawdistooldiameter), global::_0014._009F_0003(buLangTranslate.preDef.Tool, _0087(107396067), buLangTranslate.preDef.Diameter));
			global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_sawdisAAngle), global::_0014._009F_0003(buLangTranslate.preChar.A, _0087(107396067), buLangTranslate.preDef.Angle));
			if (8u != 0)
			{
				global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_sawdiscalculatedvalue), global::_0014._009F_0003(buLangTranslate.preDef.Calculated, _0087(107396067), buLangTranslate.preDef.Value));
				global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_sawdismaterialdistance), global::_0014._009F_0003(buLangTranslate.preDef.Material, _0087(107396067), buLangTranslate.preDef.Thickness));
				global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_sawdissafedistance), global::_0014._009F_0003(buLangTranslate.preDef.Safe, _0087(107396067), buLangTranslate.preDef.Length));
				global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_sawdistargetz), global::_0014._009F_0003(buLangTranslate.preDef.Target, _0087(107396067), buLangTranslate.preChar.Z));
			}
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
			string message = _0087(107397450);
			do
			{
				CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, global::_0005._007E_0080(_0019_0003._000E_000F()), message, _0087(107372245), _0087(107397450), _0087(107397450), id, ee);
				_009E_0004._0014_0011(calculationErrorEventArg, true);
			}
			while (false);
		}
	}

	public void Apply()
	{
	}

	public void MenuButtonColors(int PageIndex)
	{
		Control.ControlCollection controlCollection = global::_0098._007E_0015_0008(this._0001);
		Control.ControlCollection controlCollection2 = default(Control.ControlCollection);
		if (0 == 0)
		{
			controlCollection2 = controlCollection;
		}
		controlCollection2 = _0099_0006._001D_0013(controlCollection2);
		if (PageIndex == 0)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_sawdistance)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_sawdistance)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 1)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_pointmove)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_pointmove)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		SelectedTab = PageIndex;
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		Control control = P_0 as Control;
		if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_cancel)) | global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_closecross)))
		{
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				global::_0011._001D_0003(this);
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				global::_0082._0086_0005(this, false);
			}
		}
		if (0 == 0)
		{
			bool flag = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_ok));
			bool num = flag;
			if (0 == 0)
			{
				if (num)
				{
					Apply();
					PropertiesForm.Result = DialogResult.OK;
					if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
					{
						global::_0011._001D_0003(this);
					}
					if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
					{
						global::_0082._0086_0005(this, false);
					}
				}
				if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawdiscalculate)))
				{
					global::_0095._007E_0008_0008(spn_sawdiscalculatedvalue, _009A_0006._007E_001E_0013(clsInit.cMarble, global::_0007._007E_0094(spn_sawdistooldiameter), global::_0007._007E_0094(spn_sawdismaterialdistance), global::_0007._007E_0094(spn_sawdistargetz), global::_0007._007E_0094(spn_sawdissafedistance), global::_0007._007E_0094(spn_sawdisAAngle)));
				}
				if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_pointmovecalc)))
				{
					clsAppMarbleVars.cmdMarble.DebugCreateRTCPCodesFromPointList();
					_0002(btn_cancel, null);
				}
				num = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawdistance));
			}
			if (!num)
			{
				goto IL_0275;
			}
			global::_008D._007E_000F_0007(buTab_tools, 0);
		}
		MenuButtonColors(0);
		goto IL_0275;
		IL_0275:
		if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_pointmove)))
		{
			global::_008D._007E_000F_0007(buTab_tools, 1);
			MenuButtonColors(1);
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
			int num = ((this._0001 != null) ? 1 : 0);
			goto IL_004b;
			IL_0025:
			global::_0011._007E_001A_0002(this._0001);
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

	static F_MarbleCalculators()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarbleCalculators));
		Captions = new List<string>();
	}
}
