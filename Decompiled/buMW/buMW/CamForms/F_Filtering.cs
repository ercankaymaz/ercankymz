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
using buEyeBaseVer5;

namespace buMW.CamForms;

public class F_Filtering : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public ToolBase5 Tool = null;

	public static List<string> Captions;

	internal IContainer _0001 = null;

	internal ImageList _0001;

	internal Label _0001;

	internal PictureBox _0001;

	public Button btn_ok;

	internal ImageList _0002;

	public Button btn_cancel;

	internal CheckBox _0001;

	internal Label _0002;

	internal NumericUpDown _0001;

	public ComboBox cmb_filteringtype;

	internal Label _0003;

	internal Label _0004;

	internal NumericUpDown _0002;

	public ComboBox cmb_filteringfilterby;

	internal Label _0005;

	[NonSerialized]
	internal static GetString _001A;

	public F_Filtering()
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
		if (PropertiesForm.Width > 10)
		{
			_0097._008D_0011(this, PropertiesForm.Width);
		}
		_0095._0092_000F(this, PropertiesForm.TopMost);
		_0086_0003._0018_0014(this, PropertiesForm.FormPosition);
		if (Configration.Mode == CamMode.TriangularMesh)
		{
			global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_filteringfilterby));
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_filteringfilterby), buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringMode[0]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_filteringfilterby), buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringMode[1]);
			if (_0090_0005._007E_009A_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByRegions)
			{
				_0097._007E_008E_0011(cmb_filteringfilterby, 0);
			}
			else if (_0090_0005._007E_009A_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByContours)
			{
				_0097._007E_008E_0011(cmb_filteringfilterby, 1);
			}
			global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_filteringtype));
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_filteringtype), buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringType[0]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_filteringtype), buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringType[1]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_filteringtype), buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringType[2]);
			if (_0091_0005._007E_009B_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsFilteringType.TmbFtInscribedCircle)
			{
				_0097._007E_008E_0011(cmb_filteringtype, 0);
			}
			else if (_0091_0005._007E_009B_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsFilteringType.TmbFtCircumscribedCircle)
			{
				_0097._007E_008E_0011(cmb_filteringtype, 1);
			}
			else if (_0091_0005._007E_009B_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsFilteringType.TmbFtDiagonalLength)
			{
				_0097._007E_008E_0011(cmb_filteringtype, 2);
			}
			_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0005_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0081_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			_0095._007E_0094_000F(this._0002, false);
			_0095._007E_0094_000F(this._0004, false);
			_0095._007E_0094_000F(_0005, false);
			_0095._007E_0094_000F(this._0003, false);
			_0095._007E_0094_000F(cmb_filteringfilterby, false);
			_0095._007E_0094_000F(cmb_filteringtype, false);
			if (Configration.isRough)
			{
				_0095._007E_0094_000F(this._0002, true);
				_0095._007E_0094_000F(this._0004, true);
				_0095._007E_0094_000F(_0005, true);
				_0095._007E_0094_000F(this._0003, true);
				_0095._007E_0094_000F(cmb_filteringfilterby, true);
				_0095._007E_0094_000F(cmb_filteringtype, true);
			}
		}
		ControlUpdate();
		LoadLanguage();
		_008F_0003._007E_0082_0014(this._0001, null);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string text = _001A(107397872);
		try
		{
			if (Captions.Count >= 9)
			{
				_0084_0003._007E_0016_0014(this, Captions[0]);
				goto IL_0051;
			}
			goto IL_0146;
			IL_0146:
			if (6u != 0)
			{
				return;
			}
			goto IL_0051;
			IL_0051:
			_0084_0003._007E_0016_0014(this._0002, Captions[1]);
			if (6u != 0 && 0 == 0 && 0 == 0)
			{
				_0084_0003._007E_0016_0014(this._0004, Captions[2]);
				goto IL_0097;
			}
			goto IL_00b3;
			IL_0097:
			_0084_0003._007E_0016_0014(_0005, Captions[3]);
			goto IL_00b3;
			IL_00b3:
			_0084_0003._007E_0016_0014(this._0003, Captions[4]);
			_0084_0003._007E_0016_0014(this._0001, Captions[5]);
			_0084_0003._007E_0016_0014(btn_ok, Captions[6]);
			_0084_0003._007E_0016_0014(btn_cancel, Captions[7]);
			_0084_0003._007E_0016_0014(this._0001, Captions[8]);
			if (7 == 0)
			{
				goto IL_0097;
			}
			goto IL_0146;
		}
		catch (Exception ex)
		{
			string text2 = _001A(107398686);
			if (0 == 0)
			{
				_0097_0002._0006_0013(text2, _001A(107398948), text);
				goto IL_01b6;
			}
			goto IL_01c6;
			IL_01c6:
			if (0 == 0)
			{
				return;
			}
			goto IL_01b6;
			IL_01b6:
			_0098_0002._0007_0013(ex, text, true, text2);
			goto IL_01c6;
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
		Apply();
		PropertiesForm.Result = DialogResult.OK;
		bool num = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
		if (4u != 0)
		{
			if (num)
			{
				global::_0011._001C_0006(this);
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
			_0095._0094_000F(this, false);
		}
	}

	internal void _0002(object P_0, EventArgs P_1)
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
				global::_0011._001C_0006(this);
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
			_0095._0094_000F(this, false);
		}
		return;
		IL_006f:
		num = flag;
		goto IL_002a;
	}

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
		if (Configration.Mode == CamMode.TriangularMesh)
		{
			if (global::_000E._007E_000E_0006(cmb_filteringfilterby) != 0)
			{
				goto IL_007e;
			}
			_0092_0005._007E_009C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByRegions);
			goto IL_00c7;
		}
		return;
		IL_007e:
		if (global::_000E._007E_000E_0006(cmb_filteringfilterby) == 1)
		{
			_0092_0005._007E_009C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByContours);
		}
		goto IL_00c7;
		IL_0132:
		bool num;
		if (num != 0)
		{
			_0093_0005._007E_009D_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsFilteringType.TmbFtCircumscribedCircle);
			if (4 == 0)
			{
				goto IL_007e;
			}
		}
		else if (global::_000E._007E_000E_0006(cmb_filteringtype) == 2)
		{
			_0093_0005._007E_009D_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsFilteringType.TmbFtDiagonalLength);
		}
		goto IL_01b9;
		IL_00c7:
		bool flag;
		if (global::_000E._007E_000E_0006(cmb_filteringtype) == 0)
		{
			_0093_0005._007E_009D_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsFilteringType.TmbFtInscribedCircle);
			if (0 == 0)
			{
				goto IL_01b9;
			}
		}
		else
		{
			num = global::_000E._007E_000E_0006(cmb_filteringtype) == 1;
			if (1 == 0)
			{
				goto IL_0132;
			}
			flag = num;
		}
		num = flag;
		goto IL_0132;
		IL_01b9:
		_0094._007E_0019_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _000F_0004._009F_0014(global::_0008._007E_0099_0005(this._0002)));
		_0094._007E_0091_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		if (false)
		{
			goto IL_00a6;
		}
		Control control = new Control();
		control = (Control)P_0;
		if (!PropertiesForm.Inited)
		{
			return;
		}
		bool flag;
		if (PropertiesForm.Inited)
		{
			while (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_filteringfilterby)))
			{
				flag = global::_000E._007E_000E_0006(cmb_filteringfilterby) == 0;
				if (false)
				{
					continue;
				}
				goto IL_00a1;
			}
			goto IL_0101;
		}
		goto IL_01ea;
		IL_00a6:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._001F_0017());
		goto IL_0101;
		IL_0101:
		bool flag2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_filteringtype));
		bool num = flag2;
		goto IL_012a;
		IL_012a:
		int num2;
		int num3;
		if (num)
		{
			num2 = global::_000E._007E_000E_0006(cmb_filteringtype);
			num3 = 0;
			goto IL_0141;
		}
		goto IL_01ea;
		IL_018a:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._0081_0017());
		if (3 == 0)
		{
		}
		goto IL_01ea;
		IL_00a1:
		if (flag)
		{
			goto IL_00a6;
		}
		num2 = global::_000E._007E_000E_0006(cmb_filteringfilterby);
		num3 = 1;
		if (num3 != 0)
		{
			num = num2 == num3;
			if (6u != 0)
			{
				if (num)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._007F_0017());
				}
				goto IL_0101;
			}
			goto IL_012a;
		}
		goto IL_0141;
		IL_01ea:
		PropertiesForm.Inited = false;
		Apply();
		ControlUpdate();
		goto IL_0204;
		IL_0141:
		bool flag3 = num2 == num3;
		bool num4 = flag3;
		while (!num4)
		{
			bool flag4 = global::_000E._007E_000E_0006(cmb_filteringtype) == 1;
			if (true)
			{
				if (flag4)
				{
					goto IL_018a;
				}
				num4 = global::_000E._007E_000E_0006(cmb_filteringtype) == 2;
				if (2 == 0)
				{
					continue;
				}
				goto IL_01c5;
			}
			goto IL_0204;
		}
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._0080_0017());
		goto IL_01ea;
		IL_01c5:
		if (num4)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0082_0017());
		}
		goto IL_01ea;
		IL_0204:
		PropertiesForm.Inited = true;
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		bool num = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001));
		while (true)
		{
			if (3u != 0)
			{
				if (num)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_0017());
					goto IL_0163;
				}
				bool num2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002));
				if (4u != 0)
				{
					bool flag = num2;
					if (4 == 0)
					{
						goto IL_0163;
					}
					if (flag)
					{
						goto IL_00a5;
					}
					num2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001));
				}
				bool flag2 = num2;
				num = flag2;
			}
			if (4 == 0)
			{
				continue;
			}
			if (num)
			{
				do
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_0017());
				}
				while (false);
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)) ? true : false)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0084_0017());
			}
			goto IL_0163;
			IL_0163:
			_0095._007E_0096_000F(this._0001, false);
			if (0 == 0)
			{
				break;
			}
			goto IL_00a5;
			IL_00a5:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0084_0017());
			goto IL_0163;
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

	static F_Filtering()
	{
		Strings.CreateGetStringDelegate(typeof(F_Filtering));
		Captions = new List<string>();
	}
}
