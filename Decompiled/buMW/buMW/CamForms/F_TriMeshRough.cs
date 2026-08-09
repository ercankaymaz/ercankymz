using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;
using buControls.Forms.WinControlForms.Views;
using buEyeBaseVer5;

namespace buMW.CamForms;

public class F_TriMeshRough : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public ToolBase5 Tool = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public static List<string> Captions = new List<string>();

	internal IContainer _0001 = null;

	internal ImageList _0001;

	public Button btn_cancel;

	public Button btn_ok;

	internal TabControl _0001;

	internal TabPage _0001;

	internal TabPage _0002;

	internal TabPage _0003;

	internal TabPage _0004;

	internal ComboBox _0001;

	internal Label _0001;

	internal CheckBox _0001;

	internal NumericUpDown _0001;

	internal Label _0002;

	internal NumericUpDown _0002;

	internal Label _0003;

	internal NumericUpDown _0003;

	internal Label _0004;

	internal Panel _0001;

	internal ComboBox _0002;

	internal Label _0005;

	internal Panel _0002;

	internal Button _0001;

	internal NumericUpDown _0004;

	internal Label _0006;

	internal Panel _0003;

	internal Button _0002;

	internal NumericUpDown _0005;

	internal NumericUpDown _0006;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal RadioButton _0003;

	internal RadioButton _0004;

	internal NumericUpDown _0007;

	internal Label _0007;

	internal ComboBox _0003;

	internal Label _0008;

	internal Panel _0004;

	internal Label _000E;

	internal Label _000F;

	internal Label _0010;

	internal Panel _0005;

	internal Label _0011;

	internal Label _0012;

	internal Label _0013;

	internal Panel _0006;

	internal Button _0003;

	internal Label _0014;

	internal NumericUpDown _0008;

	internal Label _0015;

	internal Label _0016;

	internal Label _0017;

	internal NumericUpDown _000E;

	internal Label _0018;

	internal NumericUpDown _000F;

	internal NumericUpDown _0010;

	internal PictureBox _0001;

	internal ImageList _0002;

	internal CheckBox _0002;

	internal Panel _0007;

	internal Label _0019;

	internal CheckBox _0003;

	internal Panel _0008;

	internal Label _001A;

	public ComboBox cmb_exitramptype;

	internal Label _001B;

	internal Button _0004;

	internal Label _001C;

	public ComboBox cmb_entryramptype;

	internal Panel _000E;

	internal CheckBox _0004;

	internal Label _001D;

	internal Panel _000F;

	internal CheckBox _0005;

	internal Label _001E;

	internal Panel _0010;

	internal Label _001F;

	internal Label _007F;

	internal NumericUpDown _0011;

	internal Panel _0011;

	internal Button _0005;

	internal CheckBox _0006;

	internal Label _0080;

	internal NumericUpDown _0012;

	internal Panel _0012;

	internal Button _0006;

	internal Button _0007;

	internal Label _0081;

	internal NumericUpDown _0013;

	internal Label _0082;

	internal NumericUpDown _0014;

	internal Label _0083;

	internal NumericUpDown _0015;

	internal CheckBox _0007;

	internal Panel _0013;

	internal Label _0084;

	internal Label _0086;

	internal Label _0087;

	internal ComboBox _0004;

	internal CheckBox _0008;

	internal Label _0088;

	internal NumericUpDown _0016;

	internal CheckBox _000E;

	internal CheckBox _000F;

	internal Panel _0014;

	internal Label _0089;

	internal Label _008A;

	internal NumericUpDown _0017;

	internal CheckBox _0010;

	internal Button _0008;

	internal NumericUpDown _0018;

	internal Label _008B;

	internal Label _008C;

	internal NumericUpDown _0019;

	internal Button _000E;

	internal NumericUpDown _001A;

	internal Label _008D;

	internal NumericUpDown _001B;

	internal Label _008E;

	internal NumericUpDown _001C;

	internal Label _008F;

	internal Label _0090;

	internal ComboBox _0005;

	internal Button _000F;

	internal Button _0010;

	internal Button _0011;

	internal Button _0012;

	internal Panel _0015;

	internal Button _0013;

	internal Label _0091;

	internal Panel _0016;

	internal Button _0014;

	internal CheckBox _0011;

	internal Label _0092;

	internal Panel _0017;

	internal Button _0015;

	internal CheckBox _0012;

	internal Label _0093;

	internal Button _0016;

	public F_TriMeshRough()
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
		_0095._007E_0094_000F(this._0002, PropertiesForm.ShowHelp);
		_0088_0003._007E_001A_0014(_0018, _0087_0003._0019_0014(global::_0007._007E_0017_0004(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(_001A, _0087_0003._0019_0014(global::_0007._007E_001D_0004(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(_001B, _0087_0003._0019_0014(global::_0007._007E_001C_0004(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(_001C, _0087_0003._0019_0014(global::_0007._007E_0082_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_007F_0003(global::_008E._007E_0011_0007(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))))));
		_0088_0003._007E_001A_0014(this._0005, _0004_0004._0097_0014(global::_000E._007E_009F_0005(global::_008E._007E_0011_0007(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))))));
		_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0083_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0017_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0018_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0019_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0016, _0087_0003._0019_0014(global::_0007._007E_001B_0004(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._000E, _0087_0003._0019_0014(global::_0007._007E_001E_0003(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._000F, _0087_0003._0019_0014(global::_0007._007E_001D_0003(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0010, _0087_0003._0019_0014(global::_0007._007E_001C_0003(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0008, _0087_0003._0019_0014(global::_0007._007E_001B_0003(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0007, _0087_0003._0019_0014(buCamParameter.Speeds.SpindleSpeed));
		_0088_0003._007E_001A_0014(this._0017, _0087_0003._0019_0014(global::_0007._007E_0087_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		if (Tool != null)
		{
			_0088_0003._007E_001A_0014(_0019, _0087_0003._0019_0014(global::_0007._007E_0087_0003(global::_0084._007E_009D_0006(mwCamParameter)) / Tool.Geometry.Diameter * 100.0));
		}
		_0095._007E_0096_000F(this._0008, global::_0003._007E_0081_0002(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0007(global::_0084._007E_009D_0006(mwCamParameter)));
		_0095._007E_0096_000F(_0007, global::_0003._007E_0006(global::_0084._007E_009D_0006(mwCamParameter)));
		_0095._007E_0096_000F(this._000F, global::_0003._007E_0005_0002(global::_0084._007E_009D_0006(mwCamParameter)));
		_0095._007E_0096_000F(this._000E, global::_0003._007E_0004_0002(global::_0084._007E_009D_0006(mwCamParameter)));
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0001));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.TriangleMeshBasedTpCalcParamsRoughType[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.TriangleMeshBasedTpCalcParamsRoughType[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.TriangleMeshBasedTpCalcParamsRoughType[2]);
		if (_0007_0002._007E_0014_0012(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset)
		{
			_0097._007E_008E_0011(this._0001, 0);
		}
		else if (_0007_0002._007E_0014_0012(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel)
		{
			_0097._007E_008E_0011(this._0001, 1);
		}
		else
		{
			_0097._007E_008E_0011(this._0001, 2);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0005));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0005), buMWCaptions.MachiningParamsStockRemainType[0]);
		int num = _000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0005), buMWCaptions.MachiningParamsStockRemainType[1]);
		do
		{
			if (_001A_0004._007E_0012_0015(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsStockRemainType.SrtGlobal)
			{
				_0097._007E_008E_0011(this._0005, 0);
			}
			else if (_001A_0004._007E_0012_0015(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsStockRemainType.SrtRadialAndAxial)
			{
				_0097._007E_008E_0011(this._0005, 1);
			}
			global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0004));
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0004), buMWCaptions.MachiningParamsDirection[2]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0004), buMWCaptions.MachiningParamsDirection[3]);
			if (_0015_0004._007E_0006_0015(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsDirection.DirClimb)
			{
				_0097._007E_008E_0011(this._0004, 0);
			}
			else if (_0015_0004._007E_0006_0015(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsDirection.DirConventional)
			{
				_0097._007E_008E_0011(this._0004, 1);
			}
			global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0002));
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0002), buMWCaptions.MachiningParamsMachType[0]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0002), buMWCaptions.MachiningParamsMachType[1]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0002), buMWCaptions.MachiningParamsMachType[2]);
			if (global::_0092._007E_0016_0007(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsMachType.MachtypeOneway)
			{
				_0097._007E_008E_0011(this._0002, 0);
			}
			else if (global::_0092._007E_0016_0007(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsMachType.MachtypeZigzag)
			{
				_0097._007E_008E_0011(this._0002, 1);
			}
			else if (global::_0092._007E_0016_0007(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsMachType.MachtypeSpiral)
			{
				_0097._007E_008E_0011(this._0002, 2);
			}
			global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0003));
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0003), buMWCaptions.MachiningParamsMachiningAreaMode[0]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0003), buMWCaptions.MachiningParamsMachiningAreaMode[1]);
			if (global::_0091._007E_0015_0007(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsMachiningAreaMode.MachByLanes)
			{
				_0097._007E_008E_0011(this._0003, 0);
			}
			else
			{
				_0097._007E_008E_0011(this._0003, 1);
			}
			if (global::_008F._007E_0012_0007(global::_008E._007E_0011_0007(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
			{
				_0095._007E_0093_000F(this._0002, true);
				_0095._007E_0093_000F(this._0001, false);
			}
			else
			{
				_0095._007E_0093_000F(this._0002, false);
				_0095._007E_0093_000F(this._0001, true);
			}
			if (buCamParameter.Speeds.SpindleDirection == ClockDirectionType.CW)
			{
				_0095._007E_0093_000F(this._0004, true);
				_0095._007E_0093_000F(this._0003, false);
			}
			else
			{
				_0095._007E_0093_000F(this._0004, false);
				_0095._007E_0093_000F(this._0003, true);
			}
			_0095._007E_0096_000F(this._0003, global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
			global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_entryramptype));
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_entryramptype), buMWCaptions.FirstEntryType[0]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_entryramptype), buMWCaptions.FirstEntryType[1]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_entryramptype), buMWCaptions.FirstEntryType[2]);
			if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.FromRapidPlane)
			{
				_0097._007E_008E_0011(cmb_entryramptype, 0);
			}
			else if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.UseRapidDistance)
			{
				_0097._007E_008E_0011(cmb_entryramptype, 1);
			}
			else if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.UseFeedDistance)
			{
				_0097._007E_008E_0011(cmb_entryramptype, 2);
			}
			global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_exitramptype));
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_exitramptype), buMWCaptions.LastExitType[0]);
			num = _000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_exitramptype), buMWCaptions.LastExitType[1]);
		}
		while (false);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_exitramptype), buMWCaptions.LastExitType[2]);
		if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == LastExitType.BackToRapidPlane)
		{
			_0097._007E_008E_0011(cmb_exitramptype, 0);
		}
		else if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == LastExitType.UseRapidDistance)
		{
			_0097._007E_008E_0011(cmb_exitramptype, 1);
		}
		else if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == LastExitType.UseFeedDistance)
		{
			_0097._007E_008E_0011(cmb_exitramptype, 2);
		}
		_0088_0003._007E_001A_0014(this._0011, _0087_0003._0019_0014(global::_0007._007E_0097_0004(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
		_0095._007E_0096_000F(this._0010, global::_0003._007E_0080_0002(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(this._0005, global::_0003._007E_001F_0002(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(this._0004, global::_0003._007E_007F_0002(global::_008E._007E_0011_0007(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
		_0095._007E_0096_000F(this._0006, global::_0003._007E_0003_0002(_0016_0004._007E_0007_0015(global::_0084._007E_009D_0006(mwCamParameter))));
		_0095._007E_0096_000F(_0012, global::_0003._007E_0096_0002(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(_0011, global::_0003._007E_0014(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._0084_0018());
		Configration.Mode = CamMode.TriangularMesh;
		Configration.CamTriMeshType = CamTriangularMeshType.Rough;
		global::_0011._007E_0086_0006(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		global::_0005._0002._0001(this);
		ControlUpdate();
	}

	public void ControlUpdate()
	{
		_0095._007E_0095_000F(_0018, false);
		_0095._007E_0095_000F(_008B, false);
		if (global::_000E._007E_000E_0006(this._0001) == 1)
		{
			goto IL_0050;
		}
		goto IL_007a;
		IL_0050:
		_0095._007E_0095_000F(_0018, true);
		_0095._007E_0095_000F(_008B, true);
		goto IL_007a;
		IL_007a:
		_0095._007E_0095_000F(_001C, false);
		_0095._007E_0095_000F(_008F, false);
		_0095._007E_0095_000F(_001B, false);
		_0095._007E_0095_000F(_008E, false);
		_0095._007E_0095_000F(_001A, false);
		_0095._007E_0095_000F(_008D, false);
		if (global::_000E._007E_000E_0006(this._0005) == 0)
		{
			_0095._007E_0095_000F(_001C, true);
			_0095._007E_0095_000F(_008F, true);
		}
		else
		{
			_0095._007E_0095_000F(_001B, true);
			_0095._007E_0095_000F(_008E, true);
			_0095._007E_0095_000F(_001A, true);
			_0095._007E_0095_000F(_008D, true);
		}
		if (global::_0003._007E_001C(this._0002))
		{
			_0095._007E_0095_000F(this._0006, true);
			_0095._007E_0095_000F(this._0005, false);
			goto IL_01d1;
		}
		_0095._007E_0095_000F(this._0006, false);
		goto IL_01bd;
		IL_01d1:
		_0095._007E_0095_000F(this._0015, global::_0003._007E_0083(_0007));
		_0095._007E_0095_000F(this._0016, global::_0003._007E_0083(this._000E));
		_0095._007E_0095_000F(cmb_entryramptype, global::_0003._007E_0083(this._0003));
		_0095._007E_0095_000F(this._0012, global::_0003._007E_0083(this._0004));
		if (7 == 0)
		{
			goto IL_0050;
		}
		_0095._007E_0095_000F(_0010, global::_0003._007E_0083(this._0006));
		if (true)
		{
			_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(this._0006));
			_0095._007E_0095_000F(_0015, global::_0003._007E_0083(_0012));
			_0095._007E_0095_000F(_0014, global::_0003._007E_0083(_0011));
			_0095._007E_0095_000F(_0008, global::_0003._007E_0083(this._0005));
			_0095._007E_0095_000F(this._0011, global::_0003._007E_0083(this._0005));
			return;
		}
		goto IL_01bd;
		IL_01bd:
		_0095._007E_0095_000F(this._0005, true);
		goto IL_01d1;
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Expected O, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Expected O, but got Unknown
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Expected O, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Expected O, but got Unknown
		//IL_0585: Unknown result type (might be due to invalid IL or missing references)
		//IL_058f: Expected O, but got Unknown
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Expected O, but got Unknown
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected O, but got Unknown
		//IL_09de: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e8: Expected O, but got Unknown
		//IL_0a04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0e: Expected O, but got Unknown
		//IL_08a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b3: Expected O, but got Unknown
		//IL_08cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d9: Expected O, but got Unknown
		//IL_0622: Unknown result type (might be due to invalid IL or missing references)
		//IL_062c: Expected O, but got Unknown
		//IL_0db8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc2: Expected O, but got Unknown
		//IL_0dde: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de8: Expected O, but got Unknown
		//IL_0fa0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0faa: Expected O, but got Unknown
		//IL_0ee0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eea: Expected O, but got Unknown
		//IL_0f06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f10: Expected O, but got Unknown
		//IL_0969: Unknown result type (might be due to invalid IL or missing references)
		//IL_0973: Expected O, but got Unknown
		//IL_1008: Unknown result type (might be due to invalid IL or missing references)
		//IL_1012: Expected O, but got Unknown
		//IL_102e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1038: Expected O, but got Unknown
		//IL_0e78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e82: Expected O, but got Unknown
		//IL_1130: Unknown result type (might be due to invalid IL or missing references)
		//IL_113a: Expected O, but got Unknown
		//IL_1156: Unknown result type (might be due to invalid IL or missing references)
		//IL_1160: Expected O, but got Unknown
		//IL_0b15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1f: Expected O, but got Unknown
		//IL_125e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1268: Expected O, but got Unknown
		//IL_1284: Unknown result type (might be due to invalid IL or missing references)
		//IL_128e: Expected O, but got Unknown
		//IL_10c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d2: Expected O, but got Unknown
		//IL_1386: Unknown result type (might be due to invalid IL or missing references)
		//IL_1390: Expected O, but got Unknown
		//IL_13ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b6: Expected O, but got Unknown
		//IL_131e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1328: Expected O, but got Unknown
		//IL_11f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1200: Expected O, but got Unknown
		//IL_1446: Unknown result type (might be due to invalid IL or missing references)
		//IL_1450: Expected O, but got Unknown
		Control control = new Control();
		control = (Control)P_0;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_ok)))
		{
			if (!PropertiesForm.Inited)
			{
				return;
			}
			if (PropertiesForm.ReadOnly)
			{
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					global::_0011._001C_0006(this);
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					_0095._0094_000F(this, false);
				}
				return;
			}
			global::_0005._0002._0001(this);
			goto IL_00c8;
		}
		goto IL_011a;
		IL_0f59:
		F_ProfilePass f_ProfilePass = default(F_ProfilePass);
		f_ProfilePass.Init();
		_009D_0003._007E_0091_0014(f_ProfilePass);
		if (f_ProfilePass.PropertiesForm.Result == DialogResult.OK)
		{
			global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_ProfilePass.mwCamParameter)));
			buCamParameter = new camParameters5(f_ProfilePass.buCamParameter);
		}
		goto IL_0fbf;
		IL_0acb:
		F_Roughing f_Roughing = default(F_Roughing);
		f_Roughing.Init();
		_009D_0003._007E_0091_0014(f_Roughing);
		if (f_Roughing.PropertiesForm.Result == DialogResult.OK)
		{
			global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_Roughing.mwCamParameter)));
			global::_0088._007E_0002_0007(mwCamParameter, global::_0087._007E_009F_0006(f_Roughing.mwCamParameter));
			buCamParameter = new camParameters5(f_Roughing.buCamParameter);
			if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.FromRapidPlane)
			{
				_0097._007E_008E_0011(cmb_entryramptype, 0);
			}
			else if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.UseRapidDistance)
			{
				_0097._007E_008E_0011(cmb_entryramptype, 1);
			}
			else if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.UseFeedDistance)
			{
				goto IL_0c29;
			}
			goto IL_0c3c;
		}
		goto IL_0d6f;
		IL_0a68:
		_0095._007E_0094_000F(f_Roughing.btn_mirror, false);
		if (3u != 0)
		{
			_0095._007E_0094_000F(f_Roughing.btn_transformrotate, false);
			f_Roughing.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_Roughing.Tool = new ToolBase5(f_Roughing.Tool);
			}
			goto IL_0acb;
		}
		goto IL_0c29;
		IL_00c8:
		PropertiesForm.Result = DialogResult.OK;
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
		{
			global::_0011._001C_0006(this);
		}
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
		{
			_0095._0094_000F(this, false);
		}
		goto IL_011a;
		IL_0fbf:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0010)))
		{
			F_2DContainment f_2DContainment = new F_2DContainment();
			f_2DContainment.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_2DContainment.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_2DContainment.buCamParameter = new camParameters5(buCamParameter);
			f_2DContainment.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_2DContainment.Tool = new ToolBase5(f_2DContainment.Tool);
			}
			f_2DContainment.Init();
			_009D_0003._007E_0091_0014(f_2DContainment);
			if (f_2DContainment.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_2DContainment.mwCamParameter)));
				buCamParameter = new camParameters5(f_2DContainment.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0011)))
		{
			F_Fixtures f_Fixtures = new F_Fixtures();
			f_Fixtures.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_Fixtures.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_Fixtures.buCamParameter = new camParameters5(buCamParameter);
			f_Fixtures.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_Fixtures.Tool = new ToolBase5(f_Fixtures.Tool);
			}
			f_Fixtures.Init();
			_009D_0003._007E_0091_0014(f_Fixtures);
			bool flag = f_Fixtures.PropertiesForm.Result == DialogResult.OK;
			if (false)
			{
				goto IL_0acb;
			}
			if (flag)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_Fixtures.mwCamParameter)));
				buCamParameter = new camParameters5(f_Fixtures.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0014)))
		{
			F_Silhouette f_Silhouette = new F_Silhouette();
			f_Silhouette.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_Silhouette.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_Silhouette.buCamParameter = new camParameters5(buCamParameter);
			f_Silhouette.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_Silhouette.Tool = new ToolBase5(f_Silhouette.Tool);
			}
			f_Silhouette.Init();
			_009D_0003._007E_0091_0014(f_Silhouette);
			if (f_Silhouette.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_Silhouette.mwCamParameter)));
				buCamParameter = new camParameters5(f_Silhouette.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0013)))
		{
			F_Filtering f_Filtering = new F_Filtering();
			f_Filtering.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_Filtering.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_Filtering.buCamParameter = new camParameters5(buCamParameter);
			f_Filtering.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_Filtering.Tool = new ToolBase5(f_Filtering.Tool);
			}
			f_Filtering.Init();
			_009D_0003._007E_0091_0014(f_Filtering);
			if (f_Filtering.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_Filtering.mwCamParameter)));
				buCamParameter = new camParameters5(f_Filtering.buCamParameter);
			}
		}
		return;
		IL_0d6f:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0012)))
		{
			F_RestRough f_RestRough = new F_RestRough();
			f_RestRough.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_RestRough.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_RestRough.buCamParameter = new camParameters5(buCamParameter);
			f_RestRough.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_RestRough.Tool = new ToolBase5(f_RestRough.Tool);
			}
			f_RestRough.Init();
			_009D_0003._007E_0091_0014(f_RestRough);
			if (f_RestRough.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_RestRough.mwCamParameter)));
				buCamParameter = new camParameters5(f_RestRough.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0015)))
		{
			f_ProfilePass = new F_ProfilePass();
			f_ProfilePass.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_ProfilePass.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_ProfilePass.buCamParameter = new camParameters5(buCamParameter);
			f_ProfilePass.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_ProfilePass.Tool = new ToolBase5(f_ProfilePass.Tool);
			}
			goto IL_0f59;
		}
		goto IL_0fbf;
		IL_0c3c:
		if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == LastExitType.BackToRapidPlane)
		{
			_0097._007E_008E_0011(cmb_exitramptype, 0);
		}
		else if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == LastExitType.UseRapidDistance)
		{
			_0097._007E_008E_0011(cmb_exitramptype, 1);
		}
		else if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == LastExitType.UseFeedDistance)
		{
			_0097._007E_008E_0011(cmb_exitramptype, 2);
		}
		_0095._007E_0096_000F(this._0003, global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
		goto IL_0d6f;
		IL_011a:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_cancel)))
		{
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				global::_0011._001C_0006(this);
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				_0095._0094_000F(this, false);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			F_DepthStepAdvanced f_DepthStepAdvanced = new F_DepthStepAdvanced();
			f_DepthStepAdvanced.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_DepthStepAdvanced.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_DepthStepAdvanced.buCamParameter = new camParameters5(buCamParameter);
			f_DepthStepAdvanced.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_DepthStepAdvanced.Tool = new ToolBase5(f_DepthStepAdvanced.Tool);
			}
			f_DepthStepAdvanced.Init();
			_009D_0003._007E_0091_0014(f_DepthStepAdvanced);
			if (f_DepthStepAdvanced.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_DepthStepAdvanced.mwCamParameter)));
				buCamParameter = new camParameters5(f_DepthStepAdvanced.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_000E)))
		{
			F_Height f_Height = new F_Height();
			f_Height.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_Height.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_Height.buCamParameter = new camParameters5(buCamParameter);
			f_Height.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				if (8 == 0)
				{
					goto IL_00c8;
				}
				f_Height.Tool = new ToolBase5(f_Height.Tool);
			}
			f_Height.Init();
			_009D_0003._007E_0091_0014(f_Height);
			if (f_Height.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_Height.mwCamParameter)));
				buCamParameter = new camParameters5(f_Height.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			F_SurfaceQuality f_SurfaceQuality = new F_SurfaceQuality();
			f_SurfaceQuality.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_SurfaceQuality.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_SurfaceQuality.buCamParameter = new camParameters5(buCamParameter);
			f_SurfaceQuality.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_SurfaceQuality.Tool = new ToolBase5(f_SurfaceQuality.Tool);
			}
			f_SurfaceQuality.Init();
			_009D_0003._007E_0091_0014(f_SurfaceQuality);
			if (f_SurfaceQuality.Properties.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_SurfaceQuality.mwCamParameter)));
				buCamParameter = new camParameters5(f_SurfaceQuality.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_000F)))
		{
			F_RoughLink f_RoughLink = new F_RoughLink();
			f_RoughLink.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_RoughLink.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_RoughLink.buCamParameter = new camParameters5(buCamParameter);
			f_RoughLink.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_RoughLink.Tool = new ToolBase5(f_RoughLink.Tool);
			}
			f_RoughLink.Init();
			_009D_0003._007E_0091_0014(f_RoughLink);
			if (f_RoughLink.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_RoughLink.mwCamParameter)));
				buCamParameter = new camParameters5(f_RoughLink.buCamParameter);
				if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.FromRapidPlane)
				{
					_0097._007E_008E_0011(cmb_entryramptype, 0);
				}
				else if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.UseRapidDistance)
				{
					_0097._007E_008E_0011(cmb_entryramptype, 1);
				}
				else if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.UseFeedDistance)
				{
					_0097._007E_008E_0011(cmb_entryramptype, 2);
				}
				if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == LastExitType.BackToRapidPlane)
				{
					_0097._007E_008E_0011(cmb_exitramptype, 0);
				}
				else if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == LastExitType.UseRapidDistance)
				{
					_0097._007E_008E_0011(cmb_exitramptype, 1);
				}
				else if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == LastExitType.UseFeedDistance)
				{
					_0097._007E_008E_0011(cmb_exitramptype, 2);
				}
				_0095._007E_0096_000F(this._0003, global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			F_HeightAdvanced f_HeightAdvanced = new F_HeightAdvanced();
			if (4 == 0)
			{
				goto IL_0f59;
			}
			f_HeightAdvanced.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_HeightAdvanced.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_HeightAdvanced.buCamParameter = new camParameters5(buCamParameter);
			f_HeightAdvanced.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_HeightAdvanced.Tool = new ToolBase5(f_HeightAdvanced.Tool);
			}
			f_HeightAdvanced.Init();
			_009D_0003._007E_0091_0014(f_HeightAdvanced);
			if (f_HeightAdvanced.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_HeightAdvanced.mwCamParameter)));
				if (7 == 0)
				{
					goto IL_0a68;
				}
				buCamParameter = new camParameters5(f_HeightAdvanced.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			global::_0005._0002._0001(this);
			f_Roughing = new F_Roughing();
			f_Roughing.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_Roughing.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			global::_0088._007E_0002_0007(f_Roughing.mwCamParameter, global::_0087._007E_009F_0006(mwCamParameter));
			f_Roughing.buCamParameter = new camParameters5(buCamParameter);
			_0095._007E_0094_000F(f_Roughing.chk_mirror, false);
			_0095._007E_0094_000F(f_Roughing.chk_transformrotate, false);
			goto IL_0a68;
		}
		goto IL_0d6f;
		IL_0c29:
		_0097._007E_008E_0011(cmb_entryramptype, 2);
		goto IL_0c3c;
	}

	internal void _0001(object P_0, KeyEventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		if ((_009C_0005._007E_0007_0017(P_1) == Keys.Return) | (_009C_0005._007E_0007_0017(P_1) == Keys.Tab))
		{
			int num = 0;
			_009D_0005._0008_0017(global::_0005._007E_0013_0003(_0003_0003._007E_001E_0013(control)), ref num);
			_009E_0005._000E_0017(_0013_0005._007E_001A_0016(_0012_0006._007E_008C_001C(this._0001)), num, global::_0003._007E_009B_0002(P_1));
		}
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		bool flag = default(bool);
		if (0 == 0 && uint.MaxValue != 0)
		{
			bool touchPad = PropertiesForm.TouchPad;
			bool num = global::_0003._007E_0083(this._0002);
			do
			{
				num = !num;
			}
			while (false);
			flag = touchPad && num;
		}
		if (!flag)
		{
			return;
		}
		NumericUpDown numericUpDown = new NumericUpDown();
		numericUpDown = (NumericUpDown)P_0;
		if (7u != 0)
		{
			bool flag2 = global::_0003._007E_008C(numericUpDown);
			if (false || flag2)
			{
				_0010_0006._008A_001C(this, numericUpDown);
			}
		}
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		ControlUpdate();
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		if (!PropertiesForm.Inited)
		{
			return;
		}
		ControlUpdate();
		int num;
		int num2;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			if (global::_000E._007E_000E_0006(this._0001) != 0)
			{
				num = global::_000E._007E_000E_0006(this._0001);
				num2 = 1;
				goto IL_00b8;
			}
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0084_0018());
		}
		goto IL_0116;
		IL_00b8:
		if (num == num2)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._009B_0018());
		}
		else if (global::_000E._007E_000E_0006(this._0001) == 2)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._009C_0018());
		}
		goto IL_0116;
		IL_0116:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
		{
			if (global::_000E._007E_000E_0006(this._0005) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			}
			else if (global::_000E._007E_000E_0006(this._0005) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				if (false)
				{
					goto IL_0876;
				}
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			if (global::_000E._007E_000E_0006(this._0004) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009D_0018());
			}
			else if (global::_000E._007E_000E_0006(this._0004) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009E_0018());
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			if (global::_000E._007E_000E_0006(this._0002) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009F_0018());
			}
			else if (global::_000E._007E_000E_0006(this._0002) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0001_0019());
			}
			else
			{
				num = global::_000E._007E_000E_0006(this._0002);
				num2 = 2;
				if (num2 == 0)
				{
					goto IL_00b8;
				}
				if (num == num2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0002_0019());
				}
			}
		}
		while (true)
		{
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
			{
				if (global::_000E._007E_000E_0006(this._0003) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0003_0019());
				}
				else if (global::_000E._007E_000E_0006(this._0003) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0004_0019());
				}
			}
			int num3;
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_entryramptype)))
			{
				if (global::_000E._007E_000E_0006(cmb_entryramptype) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0005_0019());
				}
				else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0006_0019());
				}
				else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0007_0019());
				}
				else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 3)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
				}
				else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 4)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
				}
				else
				{
					if (global::_000E._007E_000E_0006(cmb_entryramptype) != 5)
					{
						num3 = global::_000E._007E_000E_0006(cmb_entryramptype);
						goto IL_056a;
					}
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
				}
			}
			goto IL_0733;
			IL_056a:
			if (num3 == 6)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 7)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 8)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
			}
			else
			{
				bool flag = global::_000E._007E_000E_0006(cmb_entryramptype) == 9;
				if (false)
				{
					goto IL_0a23;
				}
				if (flag)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				}
				else
				{
					if (global::_000E._007E_000E_0006(cmb_entryramptype) != 10)
					{
						goto IL_0689;
					}
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0018());
				}
			}
			goto IL_0733;
			IL_0689:
			if (global::_000E._007E_000E_0006(cmb_entryramptype) == 11)
			{
				goto IL_06a4;
			}
			if (global::_000E._007E_000E_0006(cmb_entryramptype) == 12)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 13)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0018());
			}
			goto IL_0733;
			IL_0733:
			if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_exitramptype)))
			{
				return;
			}
			if (global::_000E._007E_000E_0006(cmb_exitramptype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0008_0019());
				return;
			}
			if (0 == 0)
			{
				num3 = global::_000E._007E_000E_0006(cmb_exitramptype);
				if (-1 == 0)
				{
					goto IL_056a;
				}
				if (num3 == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._000E_0019());
					return;
				}
				bool num4 = global::_000E._007E_000E_0006(cmb_exitramptype) == 2;
				if (0 == 0)
				{
					if (num4)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._000F_0019());
						return;
					}
					bool flag2 = global::_000E._007E_000E_0006(cmb_exitramptype) == 3;
					num4 = flag2;
				}
				if (num4)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
					return;
				}
				if (global::_000E._007E_000E_0006(cmb_exitramptype) == 4)
				{
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_exitramptype) != 5)
				{
					if (global::_000E._007E_000E_0006(cmb_exitramptype) == 6)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
						return;
					}
					if (global::_000E._007E_000E_0006(cmb_exitramptype) == 7)
					{
						if (4u != 0)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
							if (0 == 0)
							{
								return;
							}
							goto IL_0689;
						}
						goto IL_06a4;
					}
					if (global::_000E._007E_000E_0006(cmb_exitramptype) == 8)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
						return;
					}
					if (global::_000E._007E_000E_0006(cmb_exitramptype) == 9)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
						return;
					}
					if (global::_000E._007E_000E_0006(cmb_exitramptype) == 10)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0018());
						return;
					}
					if (global::_000E._007E_000E_0006(cmb_exitramptype) != 11)
					{
						if (global::_000E._007E_000E_0006(cmb_exitramptype) == 12)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0018());
							return;
						}
						if (false)
						{
							continue;
						}
						if (global::_000E._007E_000E_0006(cmb_exitramptype) == 13)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0018());
						}
						return;
					}
					goto IL_0a23;
				}
			}
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
			return;
			IL_06a4:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
			goto IL_0733;
			IL_0a23:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
			return;
		}
		goto IL_0876;
		IL_0876:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
	}

	internal void _0005(object P_0, EventArgs P_1)
	{
		Control control;
		if (4u != 0)
		{
			control = new Control();
			control = (Control)P_0;
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_001C)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0010_0019());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView);
					_0086_0003._007E_0018_0014(f_GifView, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_001B)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0011_0019());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView2 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView2);
					_0086_0003._007E_0018_0014(f_GifView2, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView2);
				}
			}
			else
			{
				if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_001A)))
				{
					goto IL_01dc;
				}
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0012_0019());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView3 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView3);
					_0086_0003._007E_0018_0014(f_GifView3, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView3);
				}
			}
			goto IL_11bb;
		}
		goto IL_138b;
		IL_1838:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_exitramptype)))
		{
			bool flag = global::_000E._007E_000E_0006(cmb_exitramptype) == 0;
			if (false)
			{
				goto IL_01dc;
			}
			if (flag)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0008_0019());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView4 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView4);
					_0086_0003._007E_0018_0014(f_GifView4, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView4);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._000E_0019());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView5 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView5);
					_0086_0003._007E_0018_0014(f_GifView5, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView5);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._000F_0019());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView6 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView6);
					_0086_0003._007E_0018_0014(f_GifView6, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView6);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 3)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView7 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView7);
					_0086_0003._007E_0018_0014(f_GifView7, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView7);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 4)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView8 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView8);
					_0086_0003._007E_0018_0014(f_GifView8, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView8);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 5)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView9 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView9);
					_0086_0003._007E_0018_0014(f_GifView9, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView9);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 6)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView10 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView10);
					_0086_0003._007E_0018_0014(f_GifView10, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView10);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 7)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView11 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView11);
					_0086_0003._007E_0018_0014(f_GifView11, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView11);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 8)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView12 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView12);
					_0086_0003._007E_0018_0014(f_GifView12, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView12);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 9)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			}
			else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 10)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView13 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView13);
					_0086_0003._007E_0018_0014(f_GifView13, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView13);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 11)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView14 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView14);
					_0086_0003._007E_0018_0014(f_GifView14, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView14);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 12)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 13)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0018());
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0010)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001D_0019());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView15 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView15);
				_0086_0003._007E_0018_0014(f_GifView15, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView15);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001E_0019());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView16 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView16);
				_0086_0003._007E_0018_0014(f_GifView16, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView16);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001F_0019());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView17 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView17);
				_0086_0003._007E_0018_0014(f_GifView17, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView17);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._007F_0019());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView18 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView18);
				_0086_0003._007E_0018_0014(f_GifView18, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView18);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0012)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0080_0019());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView19 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView19);
				_0086_0003._007E_0018_0014(f_GifView19, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView19);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0011)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0081_0019());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView20 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView20);
				_0086_0003._007E_0018_0014(f_GifView20, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView20);
			}
		}
		goto IL_2227;
		IL_11bb:
		bool flag3;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_entryramptype)))
		{
			if (global::_000E._007E_000E_0006(cmb_entryramptype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0005_0019());
				bool flag2 = global::_0003._007E_0083(this._0002);
				if (false)
				{
					goto IL_13aa;
				}
				if (flag2)
				{
					F_GifView f_GifView21 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView21);
					_0086_0003._007E_0018_0014(f_GifView21, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView21);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0006_0019());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView22 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView22);
					_0086_0003._007E_0018_0014(f_GifView22, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView22);
				}
			}
			else
			{
				if (global::_000E._007E_000E_0006(cmb_entryramptype) != 2)
				{
					flag3 = global::_000E._007E_000E_0006(cmb_entryramptype) == 3;
					goto IL_138b;
				}
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0007_0019());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView23 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView23);
					_0086_0003._007E_0018_0014(f_GifView23, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView23);
				}
			}
		}
		goto IL_1838;
		IL_01dc:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			if (global::_000E._007E_000E_0006(this._0001) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0084_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView24 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView24);
					_0086_0003._007E_0018_0014(f_GifView24, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView24);
				}
			}
			else if (global::_000E._007E_000E_0006(this._0001) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009B_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView25 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView25);
					_0086_0003._007E_0018_0014(f_GifView25, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView25);
				}
			}
			else if (global::_000E._007E_000E_0006(this._0001) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009C_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView26 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView26);
					_0086_0003._007E_0018_0014(f_GifView26, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView26);
				}
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0018)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0013_0019());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0014_0019());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0015_0019());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0015_0019());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0016_0019());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			if (global::_000E._007E_000E_0006(this._0002) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009F_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView27 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView27);
					_0086_0003._007E_0018_0014(f_GifView27, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView27);
				}
			}
			else if (global::_000E._007E_000E_0006(this._0002) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0001_0019());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView28 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView28);
					_0086_0003._007E_0018_0014(f_GifView28, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView28);
				}
			}
			else if (global::_000E._007E_000E_0006(this._0002) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0002_0019());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView29 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView29);
					_0086_0003._007E_0018_0014(f_GifView29, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView29);
				}
			}
		}
		else
		{
			bool flag4 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003));
			while (flag4)
			{
				if (global::_000E._007E_000E_0006(this._0003) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0003_0019());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView30 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView30);
						_0086_0003._007E_0018_0014(f_GifView30, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView30);
					}
				}
				else if (global::_000E._007E_000E_0006(this._0003) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0004_0019());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView31 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView31);
						if (7 == 0)
						{
							continue;
						}
						_0086_0003._007E_0018_0014(f_GifView31, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView31);
					}
				}
				goto IL_11bb;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
			{
				bool flag5 = global::_000E._007E_000E_0006(this._0004) == 0;
				if (false)
				{
					goto IL_2227;
				}
				if (flag5)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._009D_0018());
				}
				else if (global::_000E._007E_000E_0006(this._0004) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._009E_0018());
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView32 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView32);
					_0086_0003._007E_0018_0014(f_GifView32, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView32);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0008)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0017_0019());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView33 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView33);
					_0086_0003._007E_0018_0014(f_GifView33, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView33);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView34 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView34);
					_0086_0003._007E_0018_0014(f_GifView34, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView34);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView35 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView35);
					_0086_0003._007E_0018_0014(f_GifView35, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView35);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView36 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView36);
					_0086_0003._007E_0018_0014(f_GifView36, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView36);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0015)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000F)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0007)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000E)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView37 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView37);
					_0086_0003._007E_0018_0014(f_GifView37, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView37);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0016)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView38 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView38);
					_0086_0003._007E_0018_0014(f_GifView38, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView38);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0010)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._007F_0018());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000F)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0080_0018());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000E)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0098_0018());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0008)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0081_0018());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0007)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0018_0019());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0019_0019());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001A_0019());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0011)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001B_0019());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView39 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView39);
					_0086_0003._007E_0018_0014(f_GifView39, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView39);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0017)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0019());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0019)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0099_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView40 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView40);
					_0086_0003._007E_0018_0014(f_GifView40, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView40);
				}
			}
		}
		goto IL_11bb;
		IL_138b:
		if (flag3)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
			goto IL_13aa;
		}
		bool num;
		if (global::_000E._007E_000E_0006(cmb_entryramptype) == 4)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView41 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView41);
				_0086_0003._007E_0018_0014(f_GifView41, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView41);
			}
		}
		else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 5)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView42 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView42);
				_0086_0003._007E_0018_0014(f_GifView42, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView42);
			}
		}
		else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 6)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView43 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView43);
				_0086_0003._007E_0018_0014(f_GifView43, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView43);
			}
		}
		else
		{
			num = global::_000E._007E_000E_0006(cmb_entryramptype) == 7;
			if (5 == 0)
			{
				goto IL_170e;
			}
			if (num)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView44 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView44);
					_0086_0003._007E_0018_0014(f_GifView44, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView44);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 8)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView45 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView45);
					_0086_0003._007E_0018_0014(f_GifView45, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView45);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 9)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			}
			else
			{
				if (global::_000E._007E_000E_0006(cmb_entryramptype) == 10)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0018());
					bool flag6 = global::_0003._007E_0083(this._0002);
					num = flag6;
					goto IL_170e;
				}
				if (global::_000E._007E_000E_0006(cmb_entryramptype) == 11)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView46 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView46);
						_0086_0003._007E_0018_0014(f_GifView46, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView46);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 12)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0018());
				}
				else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 13)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0018());
				}
			}
		}
		goto IL_1838;
		IL_170e:
		if (num)
		{
			F_GifView f_GifView47 = new F_GifView();
			global::_0011._007E_0084_0006(f_GifView47);
			_0086_0003._007E_0018_0014(f_GifView47, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView47);
		}
		goto IL_1838;
		IL_13aa:
		if (global::_0003._007E_0083(this._0002))
		{
			F_GifView f_GifView48 = new F_GifView();
			global::_0011._007E_0084_0006(f_GifView48);
			_0086_0003._007E_0018_0014(f_GifView48, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView48);
		}
		goto IL_1838;
		IL_2227:
		_0095._007E_0096_000F(this._0002, false);
	}

	internal void _0006(object P_0, EventArgs P_1)
	{
		ControlUpdate();
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
}
