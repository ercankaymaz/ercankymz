using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;
using buControls.Forms.WinControlForms.Views;
using buEyeBaseVer5;

namespace buMW.CamForms;

public class F_RoughingAdvanced : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public ToolBase5 Tool = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public static List<string> Captions;

	internal IContainer _0001 = null;

	internal Label _0001;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal Panel _0001;

	public ComboBox combo_type;

	internal Label _0002;

	internal Label _0003;

	internal NumericUpDown _0001;

	internal Label _0004;

	public ComboBox combo_filterby;

	internal Label _0005;

	internal Panel _0002;

	internal Label _0006;

	internal NumericUpDown _0002;

	internal Panel _0003;

	internal Panel _0004;

	internal NumericUpDown _0003;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal CheckBox _0001;

	internal Label _0007;

	internal NumericUpDown _0004;

	internal CheckBox _0002;

	internal Label _0008;

	internal NumericUpDown _0005;

	internal CheckBox _0003;

	internal Label _000E;

	internal NumericUpDown _0006;

	internal CheckBox _0004;

	internal Label _000F;

	internal NumericUpDown _0007;

	internal CheckBox _0005;

	internal Label _0010;

	internal CheckBox _0006;

	internal Panel _0005;

	internal Label _0011;

	internal NumericUpDown _0008;

	internal Label _0012;

	internal CheckBox _0007;

	public ComboBox cmb_removecornerpeg;

	internal Label _0013;

	internal NumericUpDown _000E;

	internal CheckBox _0008;

	internal CheckBox _000E;

	[NonSerialized]
	internal static GetString _0087;

	public F_RoughingAdvanced()
	{
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			_0097._008C_0011(this, PropertiesForm.Height);
		}
		bool num = PropertiesForm.Width > 10;
		bool flag = default(bool);
		if (0 == 0)
		{
			flag = num;
		}
		if (flag)
		{
			_0097._008D_0011(this, PropertiesForm.Width);
		}
		_0095._0092_000F(this, PropertiesForm.TopMost);
		_0086_0003._0018_0014(this, PropertiesForm.FormPosition);
		if (!buMWCalcs.AdvancedTriMesh)
		{
			_0095._007E_001C_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), false);
			_0095._007E_001D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), false);
			_0095._007E_001E_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), false);
			_0095._007E_001F_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), false);
		}
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0005_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_0006_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0088_0003._007E_001A_0014(this._0007, _0087_0003._0019_0014(global::_0007._007E_0007_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_0008_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_000E_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_000F_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0010_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0088_0003._007E_001A_0014(this._000E, _0087_0003._0019_0014(global::_0007._007E_0097_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0095._007E_0096_000F(_0007, global::_0003._007E_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(_0006, global::_0003._007E_0013(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(this._0002, global::_0003._007E_0095_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0096_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(this._0003, global::_0003._007E_0097_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(this._0004, global::_0003._007E_0098_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(this._0005, global::_0003._007E_0099_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(_0008, global::_0003._007E_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
		if (_008F_0005._007E_0099_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsContourPassType.TmbCptAllSlices)
		{
			_0095._007E_0093_000F(this._0002, true);
		}
		else
		{
			_0095._007E_0093_000F(this._0001, true);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(combo_filterby));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(combo_filterby), buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringMode[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(combo_filterby), buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringMode[1]);
		if (_0090_0005._007E_009A_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByRegions)
		{
			_0097._007E_008E_0011(combo_filterby, 0);
		}
		else
		{
			_0097._007E_008E_0011(combo_filterby, 1);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(combo_type));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(combo_type), buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringType[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(combo_type), buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringType[1]);
		if (_0091_0005._007E_009B_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsFilteringType.TmbFtInscribedCircle)
		{
			_0097._007E_008E_0011(combo_type, 0);
		}
		else
		{
			_0097._007E_008E_0011(combo_type, 1);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_removecornerpeg));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_removecornerpeg), buMWCaptions.TriangleMeshBasedTpCalcParamsCornerPegs[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_removecornerpeg), buMWCaptions.TriangleMeshBasedTpCalcParamsCornerPegs[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_removecornerpeg), buMWCaptions.TriangleMeshBasedTpCalcParamsCornerPegs[2]);
		if (_001F_0006._007E_009D_001C(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsCornerPegs.CpLineArcLine)
		{
			_0097._007E_008E_0011(cmb_removecornerpeg, 0);
		}
		else if (_001F_0006._007E_009D_001C(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsCornerPegs.CpArc)
		{
			_0097._007E_008E_0011(cmb_removecornerpeg, 1);
		}
		else
		{
			_0097._007E_008E_0011(cmb_removecornerpeg, 2);
		}
		ControlUpdate();
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string text = _0087(107399553);
		try
		{
			if (Captions.Count >= 26)
			{
				_0084_0003._007E_0016_0014(_0010, Captions[0]);
				_0084_0003._007E_0016_0014(this._0005, Captions[1]);
				_0084_0003._007E_0016_0014(_000F, Captions[2]);
				_0084_0003._007E_0016_0014(this._0004, Captions[3]);
				_0084_0003._007E_0016_0014(this._000E, Captions[4]);
				_0084_0003._007E_0016_0014(this._0003, Captions[5]);
				_0084_0003._007E_0016_0014(this._0008, Captions[6]);
				_0084_0003._007E_0016_0014(this._0002, Captions[7]);
				_0084_0003._007E_0016_0014(this._0007, Captions[8]);
				_0084_0003._007E_0016_0014(this._0006, Captions[9]);
				_0084_0003._007E_0016_0014(_0007, Captions[10]);
				_0084_0003._007E_0016_0014(this._0001, Captions[11]);
				_0084_0003._007E_0016_0014(this._0002, Captions[12]);
				_0084_0003._007E_0016_0014(this._0001, Captions[13]);
				_0084_0003._007E_0016_0014(this._0004, Captions[14]);
				_0084_0003._007E_0016_0014(this._0005, Captions[15]);
				_0084_0003._007E_0016_0014(this._0002, Captions[16]);
				_0084_0003._007E_0016_0014(this._0003, Captions[17]);
				_0084_0003._007E_0016_0014(_0012, Captions[18]);
				_0084_0003._007E_0016_0014(_0011, Captions[19]);
				_0084_0003._007E_0016_0014(_0006, Captions[20]);
				_0084_0003._007E_0016_0014(_0008, Captions[21]);
				_0084_0003._007E_0016_0014(_0013, Captions[22]);
				_0084_0003._007E_0016_0014(_000E, Captions[23]);
				_0084_0003._007E_0016_0014(btn_ok, Captions[24]);
				_0084_0003._007E_0016_0014(btn_cancel, Captions[25]);
			}
		}
		catch (Exception ex)
		{
			string text2 = _0087(107400367);
			_0097_0002._0006_0013(text2, _0087(107400629), text);
			_0098_0002._0007_0013(ex, text, true, text2);
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
				_0095._007E_009E_000F(P_1, true);
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
				global::_0011._001C_0006(this);
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
				_0095._0094_000F(this, false);
			}
			break;
		}
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		if (0 == 0)
		{
			bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_ok));
			if (5 == 0)
			{
				goto IL_0098;
			}
			if (!flag)
			{
				goto IL_00a7;
			}
			Apply();
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				global::_0011._001C_0006(this);
			}
		}
		goto IL_0085;
		IL_0093:
		bool num;
		if (num != 0)
		{
			goto IL_0098;
		}
		goto IL_00a7;
		IL_0098:
		_0095._0094_000F(this, false);
		goto IL_00a7;
		IL_00a7:
		while (true)
		{
			bool flag2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_cancel));
			if (3 == 0)
			{
				break;
			}
			if (!flag2)
			{
				return;
			}
			do
			{
				PropertiesForm.Result = DialogResult.Cancel;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					if (4 == 0)
					{
						return;
					}
					global::_0011._001C_0006(this);
				}
			}
			while (5 == 0);
			if (1 == 0)
			{
				continue;
			}
			goto IL_010d;
		}
		goto IL_0085;
		IL_010d:
		num = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
		if (0 == 0)
		{
			if (num)
			{
				_0095._0094_000F(this, false);
			}
			return;
		}
		goto IL_0093;
		IL_0085:
		num = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
		goto IL_0093;
	}

	public void ControlUpdate()
	{
		if (_0007_0002._007E_0014_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset)
		{
			_0095._007E_0095_000F(this._0005, true);
			_0095._007E_0095_000F(_000F, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005));
			_0095._007E_0095_000F(this._0007, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005));
			_0095._007E_0095_000F(this._0004, true);
			_0095._007E_0095_000F(this._000E, global::_0003._007E_0083(this._0004) & global::_0003._007E_008C(this._0004));
			_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0004) & global::_0003._007E_008C(this._0004));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005));
			_0095._007E_0095_000F(this._0008, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005) & global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005) & global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(_0007, true);
			_0095._007E_0095_000F(_0006, true);
			_0095._007E_0095_000F(this._0002, false);
			_0095._007E_0095_000F(this._0007, global::_0003._007E_008C(this._0002) & global::_0003._007E_0083(this._0002));
			_0095._007E_0095_000F(this._0004, global::_0003._007E_008C(this._0002) & global::_0003._007E_0083(this._0002));
			_0095._007E_0095_000F(this._0006, false);
			_0095._007E_0095_000F(this._0002, false);
			_0095._007E_0095_000F(cmb_removecornerpeg, global::_0003._007E_0083(_0006));
			_0095._007E_0095_000F(_0013, global::_0003._007E_0083(_0008));
			_0095._007E_0095_000F(this._000E, global::_0003._007E_0083(_0008));
			_0095._007E_0095_000F(this._0003, false);
			_0095._007E_0095_000F(_0005, false);
			_0095._007E_0095_000F(combo_filterby, true);
			_0095._007E_0095_000F(this._0005, true);
			_0095._007E_0095_000F(combo_type, true);
			_0095._007E_0095_000F(this._0002, true);
		}
		if (_0007_0002._007E_0014_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel)
		{
			_0095._007E_0095_000F(this._0005, false);
			_0095._007E_0095_000F(_000F, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005));
			_0095._007E_0095_000F(this._0007, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005));
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(this._000E, global::_0003._007E_0083(this._0004) & global::_0003._007E_008C(this._0004));
			_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0004) & global::_0003._007E_008C(this._0004));
			_0095._007E_0095_000F(this._0003, true);
			_0095._007E_0095_000F(this._0008, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(_0007, false);
			_0095._007E_0095_000F(_0006, false);
			_0095._007E_0095_000F(this._0002, true);
			_0095._007E_0095_000F(this._0007, global::_0003._007E_008C(this._0002) & global::_0003._007E_0083(this._0002));
			_0095._007E_0095_000F(this._0004, global::_0003._007E_008C(this._0002) & global::_0003._007E_0083(this._0002));
			_0095._007E_0095_000F(this._0006, false);
			_0095._007E_0095_000F(this._0002, false);
			_0095._007E_0095_000F(this._0003, true);
			_0095._007E_0095_000F(_0005, false);
			_0095._007E_0095_000F(combo_filterby, false);
			_0095._007E_0095_000F(this._0005, false);
			_0095._007E_0095_000F(combo_type, true);
			_0095._007E_0095_000F(this._0002, true);
			_0095._007E_0095_000F(this._0002, global::_0003._007E_0083(this._0001));
			_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0001));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0001));
			if (!buMWCalcs.AdvancedTriMesh)
			{
				_0095._007E_0095_000F(this._0002, false);
				_0095._007E_0095_000F(this._0005, false);
				_0095._007E_0095_000F(this._0003, false);
				_0095._007E_0095_000F(this._0004, false);
			}
		}
		if (_0007_0002._007E_0014_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtAdaptive)
		{
			_0095._007E_0095_000F(this._0005, false);
			_0095._007E_0095_000F(_000F, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005));
			_0095._007E_0095_000F(this._0007, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005));
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(this._000E, global::_0003._007E_0083(this._0004) & global::_0003._007E_008C(this._0004));
			_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0004) & global::_0003._007E_008C(this._0004));
			_0095._007E_0095_000F(this._0003, false);
			_0095._007E_0095_000F(this._0008, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005) & global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005) & global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(_0007, false);
			_0095._007E_0095_000F(_0006, false);
			_0095._007E_0095_000F(this._0002, false);
			_0095._007E_0095_000F(this._0007, global::_0003._007E_008C(this._0002) & global::_0003._007E_0083(this._0002));
			_0095._007E_0095_000F(this._0004, global::_0003._007E_008C(this._0002) & global::_0003._007E_0083(this._0002));
			_0095._007E_0095_000F(this._0006, true);
			_0095._007E_0095_000F(this._0002, true);
			_0095._007E_0095_000F(this._0003, false);
			_0095._007E_0095_000F(_0005, true);
			_0095._007E_0095_000F(combo_filterby, false);
			_0095._007E_0095_000F(this._0005, false);
			_0095._007E_0095_000F(combo_type, true);
			_0095._007E_0095_000F(this._0002, true);
		}
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts)
		{
			_0095._007E_0095_000F(_0005, false);
			_0095._007E_0095_000F(this._0002, false);
			_0095._007E_0095_000F(_0006, false);
			_0095._007E_0095_000F(this._0001, true);
			_0095._007E_0095_000F(combo_filterby, false);
			_0095._007E_0095_000F(this._0005, false);
			_0095._007E_0095_000F(combo_type, false);
			_0095._007E_0095_000F(this._0002, false);
		}
	}

	public void Apply()
	{
		_0094._007E_0005_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._000E)));
		_0094._007E_0019_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _000F_0004._009F_0014(global::_0008._007E_0099_0005(this._0001)));
		_0094._007E_001A_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
		_0094._007E_001B_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0007)));
		_0094._007E_001C_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0006)));
		if (0 == 0)
		{
			_0094._007E_001D_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
			_0094._007E_001E_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
			goto IL_0219;
		}
		goto IL_031f;
		IL_031f:
		_0095._007E_0011_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0001));
		_0095._007E_001D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0003));
		_0095._007E_001E_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0004));
		do
		{
			_0095._007E_001F_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0005));
		}
		while (false);
		_0095._007E_0012_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(_0008));
		if (global::_000E._007E_000E_0006(cmb_removecornerpeg) == 0)
		{
			_007F_0006._007E_009E_001C(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsCornerPegs.CpLineArcLine);
		}
		else if (global::_000E._007E_000E_0006(cmb_removecornerpeg) == 1)
		{
			_007F_0006._007E_009E_001C(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsCornerPegs.CpArc);
		}
		else if (6u != 0 && global::_000E._007E_000E_0006(cmb_removecornerpeg) == 2)
		{
			_007F_0006._007E_009E_001C(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsCornerPegs.CpLine);
		}
		int num = global::_000E._007E_000E_0006(combo_filterby);
		if (0 == 0)
		{
			if (num == 0)
			{
				_0092_0005._007E_009C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByRegions);
			}
			else if (global::_000E._007E_000E_0006(combo_filterby) == 1)
			{
				_0092_0005._007E_009C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByContours);
			}
			bool flag = global::_000E._007E_000E_0006(combo_type) == 0;
			num = (flag ? 1 : 0);
		}
		if (num != 0)
		{
			_0093_0005._007E_009D_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsFilteringType.TmbFtInscribedCircle);
		}
		else if (global::_000E._007E_000E_0006(combo_type) == 1)
		{
			_0093_0005._007E_009D_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsFilteringType.TmbFtDiagonalLength);
			if (false)
			{
				goto IL_0219;
			}
		}
		if (global::_0003._007E_001C(this._0002))
		{
			_0094_0005._007E_009E_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsContourPassType.TmbCptAllSlices);
		}
		else
		{
			_0094_0005._007E_009E_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsContourPassType.TmbCptLastSlice);
		}
		return;
		IL_0219:
		_0094._007E_001F_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		_0095._007E_0013_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(_0007));
		_0095._007E_0014_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(_0006));
		_0095._007E_001C_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0002));
		goto IL_031f;
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		while (true)
		{
			Control control = new Control();
			control = (Control)P_0;
			if (!PropertiesForm.Inited || 1 == 0)
			{
				return;
			}
			ControlUpdate();
			bool num;
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0097_001B());
			}
			else
			{
				num = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004));
				if (5 == 0)
				{
					goto IL_01fe;
				}
				if (num)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0098_001B());
				}
				else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0007)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0099_001B());
				}
				else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
				{
					if (false)
					{
						break;
					}
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._009A_001B());
				}
				else
				{
					if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
					{
						num = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0008));
						goto IL_01fe;
					}
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._009B_001B());
					if (3 == 0)
					{
						goto IL_0204;
					}
				}
			}
			goto IL_02c4;
			IL_0226:
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0006)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009D_001B());
				if (false)
				{
				}
			}
			else
			{
				if (false)
				{
					continue;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				}
			}
			goto IL_02c4;
			IL_02c4:
			PropertiesForm.Inited = false;
			Apply();
			if (0 == 0)
			{
				break;
			}
			goto IL_0226;
			IL_0204:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._009C_001B());
			goto IL_02c4;
			IL_01fe:
			if (num)
			{
				goto IL_0204;
			}
			goto IL_0226;
		}
		ControlUpdate();
		PropertiesForm.Inited = true;
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		if (7u != 0)
		{
			control = (Control)P_0;
			if (PropertiesForm.Inited)
			{
				ControlUpdate();
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(combo_filterby)))
				{
					bool flag = global::_000E._007E_000E_0006(combo_filterby) == 0;
					if (6u != 0)
					{
						if (flag)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._001F_0017());
						}
						else if (global::_000E._007E_000E_0006(combo_filterby) == 1)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._007F_0017());
						}
						goto IL_0271;
					}
				}
				bool flag2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(combo_type));
				bool num = flag2;
				while (true)
				{
					if (num)
					{
						while (true)
						{
							num = global::_000E._007E_000E_0006(combo_type) == 0;
							if (3 == 0)
							{
								break;
							}
							if (num)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._0080_0017());
								if (false)
								{
									continue;
								}
								goto IL_0155;
							}
							goto IL_015f;
						}
						continue;
					}
					if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_removecornerpeg)))
					{
						break;
					}
					if (global::_000E._007E_000E_0006(cmb_removecornerpeg) == 0)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._009E_001B());
						break;
					}
					if (global::_000E._007E_000E_0006(cmb_removecornerpeg) == 1)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._009F_001B());
						break;
					}
					goto IL_023a;
					IL_023a:
					if (global::_000E._007E_000E_0006(cmb_removecornerpeg) == 2)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0001_001C());
					}
					break;
					IL_0155:
					if (true)
					{
						break;
					}
					goto IL_023a;
					IL_015f:
					if (global::_000E._007E_000E_0006(combo_type) == 1)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0081_0017());
					}
					break;
				}
				goto IL_0271;
			}
		}
		goto IL_029e;
		IL_0271:
		do
		{
			PropertiesForm.Inited = false;
			Apply();
		}
		while (false);
		ControlUpdate();
		PropertiesForm.Inited = true;
		goto IL_029e;
		IL_029e:
		if (1 == 0)
		{
			goto IL_0271;
		}
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0007));
		do
		{
			F_GifView f_GifView;
			bool num2;
			if (flag)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0002_001C());
			}
			else
			{
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
				{
					goto IL_009d;
				}
				if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
				{
					if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0004_001C());
						if (3u != 0)
						{
							break;
						}
						goto IL_05b8;
					}
					int num = (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000E)) ? 1 : 0);
					if (3u != 0)
					{
						if (num != 0)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0005_001C());
							if (global::_0003._007E_0083(_000E))
							{
								f_GifView = new F_GifView();
								global::_0011._007E_0084_0006(f_GifView);
								_0086_0003._007E_0018_0014(f_GifView, FormStartPosition.CenterParent);
								goto IL_022f;
							}
							continue;
						}
						if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0008)))
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
							if (global::_0003._007E_0083(_000E))
							{
								F_GifView f_GifView2 = new F_GifView();
								global::_0011._007E_0084_0006(f_GifView2);
								_0086_0003._007E_0018_0014(f_GifView2, FormStartPosition.CenterParent);
								_009D_0003._007E_0091_0014(f_GifView2);
							}
							break;
						}
						if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_removecornerpeg)))
						{
							if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
								break;
							}
							if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
								break;
							}
							if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
								break;
							}
							bool flag2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002));
							num2 = flag2;
							goto IL_05b5;
						}
						if (2 == 0)
						{
							break;
						}
						num = global::_000E._007E_000E_0006(cmb_removecornerpeg);
					}
					if (num == 0)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._009E_001B());
						if (global::_0003._007E_0083(_000E))
						{
							F_GifView f_GifView3 = new F_GifView();
							global::_0011._007E_0084_0006(f_GifView3);
							_0086_0003._007E_0018_0014(f_GifView3, FormStartPosition.CenterParent);
							_009D_0003._007E_0091_0014(f_GifView3);
						}
						break;
					}
					if (global::_000E._007E_000E_0006(cmb_removecornerpeg) == 1)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._009F_001B());
						if (global::_0003._007E_0083(_000E))
						{
							F_GifView f_GifView4 = new F_GifView();
							global::_0011._007E_0084_0006(f_GifView4);
							_0086_0003._007E_0018_0014(f_GifView4, FormStartPosition.CenterParent);
							_009D_0003._007E_0091_0014(f_GifView4);
						}
						break;
					}
					num2 = global::_000E._007E_000E_0006(cmb_removecornerpeg) == 2;
					if (6u != 0)
					{
						if (num2)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0001_001C());
							if (global::_0003._007E_0083(_000E))
							{
								F_GifView f_GifView5 = new F_GifView();
								global::_0011._007E_0084_0006(f_GifView5);
								_0086_0003._007E_0018_0014(f_GifView5, FormStartPosition.CenterParent);
								_009D_0003._007E_0091_0014(f_GifView5);
							}
						}
						break;
					}
					goto IL_05b5;
				}
				if (7u != 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._009B_001B());
					if (global::_0003._007E_0083(_000E))
					{
						F_GifView f_GifView6 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView6);
						_0086_0003._007E_0018_0014(f_GifView6, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView6);
					}
					break;
				}
			}
			if (5u != 0)
			{
				break;
			}
			goto IL_022f;
			IL_05b5:
			if (!num2)
			{
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				}
				else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				}
				break;
			}
			goto IL_05b8;
			IL_05b8:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			break;
			IL_022f:
			_009D_0003._007E_0091_0014(f_GifView);
			if (1 == 0)
			{
				goto IL_009d;
			}
			continue;
			IL_009d:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0003_001C());
			break;
		}
		while (1 == 0);
		do
		{
			_0095._007E_0096_000F(_000E, false);
		}
		while (3 == 0);
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
			global::_0011._007E_0019_0006(this._0001);
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
		_0095._0091_000F(this, disposing);
	}

	static F_RoughingAdvanced()
	{
		Strings.CreateGetStringDelegate(typeof(F_RoughingAdvanced));
		Captions = new List<string>();
	}
}
