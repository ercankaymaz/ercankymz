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

public class F_TriMeshParallelCut : Form
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

	internal CheckBox _0001;

	internal NumericUpDown _0001;

	internal Label _0001;

	internal NumericUpDown _0002;

	internal Label _0002;

	internal NumericUpDown _0003;

	internal Label _0003;

	internal ComboBox _0001;

	internal Label _0004;

	internal Panel _0001;

	internal Button _0001;

	internal NumericUpDown _0004;

	internal Label _0005;

	internal Panel _0002;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal NumericUpDown _0005;

	internal Label _0006;

	internal ComboBox _0002;

	internal Label _0007;

	internal Panel _0003;

	internal Label _0008;

	internal Label _000E;

	internal Label _000F;

	internal Panel _0004;

	internal Label _0010;

	internal Label _0011;

	internal Label _0012;

	internal Panel _0005;

	internal Button _0002;

	internal Label _0013;

	internal NumericUpDown _0006;

	internal Label _0014;

	internal Label _0015;

	internal Label _0016;

	internal NumericUpDown _0007;

	internal Label _0017;

	internal NumericUpDown _0008;

	internal NumericUpDown _000E;

	internal PictureBox _0001;

	internal CheckBox _0002;

	internal NumericUpDown _000F;

	internal CheckBox _0003;

	internal Panel _0006;

	internal Label _0018;

	internal Panel _0007;

	internal Label _0019;

	internal Label _001A;

	internal NumericUpDown _0010;

	internal NumericUpDown _0011;

	internal Label _001B;

	internal Label _001C;

	internal NumericUpDown _0012;

	internal Button _0003;

	internal NumericUpDown _0013;

	internal Label _001D;

	internal NumericUpDown _0014;

	internal Label _001E;

	internal NumericUpDown _0015;

	internal Label _001F;

	internal ComboBox _0003;

	internal Button _0004;

	internal NumericUpDown _0016;

	internal Label _007F;

	internal CheckBox _0004;

	internal Label _0080;

	internal NumericUpDown _0017;

	internal CheckBox _0005;

	internal CheckBox _0006;

	internal Label _0081;

	internal NumericUpDown _0018;

	internal Label _0082;

	internal NumericUpDown _0019;

	internal CheckBox _0007;

	internal Panel _0008;

	internal Button _0005;

	internal Label _0083;

	public ComboBox cmb_leadouttype;

	internal Label _0084;

	internal CheckBox _0008;

	internal Panel _000E;

	internal Button _0006;

	internal Label _0086;

	public ComboBox cmb_leadintype;

	internal Label _0087;

	internal CheckBox _000E;

	internal Button _0007;

	internal Label _0088;

	internal CheckBox _000F;

	internal Panel _000F;

	internal Button _0008;

	internal Label _0089;

	internal Panel _0010;

	internal Button _000E;

	internal CheckBox _0010;

	internal Label _008A;

	internal Panel _0011;

	internal Button _000F;

	internal CheckBox _0011;

	internal Label _008B;

	internal Panel _0012;

	internal Button _0010;

	internal Button _0011;

	internal CheckBox _0012;

	internal Label _008C;

	internal Panel _0013;

	internal Button _0012;

	internal CheckBox _0013;

	internal Label _008D;

	internal Panel _0014;

	internal CheckBox _0014;

	internal Button _0013;

	internal Label _008E;

	internal Panel _0015;

	internal Button _0014;

	internal CheckBox _0015;

	internal Label _008F;

	internal Button _0015;

	internal Panel _0016;

	internal Button _0016;

	internal Button _0017;

	internal CheckBox _0016;

	internal Label _0090;

	public F_TriMeshParallelCut()
	{
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			if (2 == 0)
			{
				goto IL_0088;
			}
			_0097._008C_0011(this, PropertiesForm.Height);
		}
		if (PropertiesForm.Width > 10)
		{
			_0097._008D_0011(this, PropertiesForm.Width);
		}
		goto IL_0088;
		IL_0088:
		_0095._007E_0094_000F(this._0002, PropertiesForm.ShowHelp);
		_0088_0003._007E_001A_0014(this._0011, _0087_0003._0019_0014(global::_0007._007E_0017_0004(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0013, _0087_0003._0019_0014(global::_0007._007E_001D_0004(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0014, _0087_0003._0019_0014(global::_0007._007E_001C_0004(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0015, _0087_0003._0019_0014(global::_0007._007E_0082_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0083_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0017_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0018_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0019_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0007, _0087_0003._0019_0014(global::_0007._007E_001E_0003(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0008, _0087_0003._0019_0014(global::_0007._007E_001D_0003(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._000E, _0087_0003._0019_0014(global::_0007._007E_001C_0003(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_001B_0003(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(buCamParameter.Speeds.SpindleSpeed));
		_0088_0003._007E_001A_0014(this._0010, _0087_0003._0019_0014(global::_0007._007E_0087_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		if (Tool != null)
		{
			_0088_0003._007E_001A_0014(this._0012, _0087_0003._0019_0014(global::_0007._007E_0087_0003(global::_0084._007E_009D_0006(mwCamParameter)) / Tool.Geometry.Diameter * 100.0));
		}
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0007(global::_0084._007E_009D_0006(mwCamParameter)));
		_0095._007E_0096_000F(this._0003, global::_0003._007E_0006(global::_0084._007E_009D_0006(mwCamParameter)));
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0003));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0003), buMWCaptions.MachiningParamsStockRemainType[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0003), buMWCaptions.MachiningParamsStockRemainType[1]);
		if (_001A_0004._007E_0012_0015(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsStockRemainType.SrtGlobal)
		{
			_0097._007E_008E_0011(this._0003, 0);
		}
		else if (_001A_0004._007E_0012_0015(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsStockRemainType.SrtRadialAndAxial)
		{
			_0097._007E_008E_0011(this._0003, 1);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0001));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.MachiningParamsMachType[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.MachiningParamsMachType[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.MachiningParamsMachType[3]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.MachiningParamsMachType[4]);
		if (_0092._007E_0016_0007(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsMachType.MachtypeOneway)
		{
			_0097._007E_008E_0011(this._0001, 0);
		}
		else if (_0092._007E_0016_0007(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsMachType.MachtypeZigzag)
		{
			_0097._007E_008E_0011(this._0001, 1);
		}
		else if (_0092._007E_0016_0007(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsMachType.MachtypeUp)
		{
			_0097._007E_008E_0011(this._0001, 2);
		}
		else if (_0092._007E_0016_0007(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsMachType.MachtypeDown)
		{
			_0097._007E_008E_0011(this._0001, 3);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0002));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0002), buMWCaptions.TriangleMeshBasedTpCalcParamsParallelCutsStartCorner[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0002), buMWCaptions.TriangleMeshBasedTpCalcParamsParallelCutsStartCorner[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0002), buMWCaptions.TriangleMeshBasedTpCalcParamsParallelCutsStartCorner[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0002), buMWCaptions.TriangleMeshBasedTpCalcParamsParallelCutsStartCorner[3]);
		if (_0099_0004._007E_0093_0015(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScLowerLeft)
		{
			_0097._007E_008E_0011(this._0002, 0);
		}
		else if (_0099_0004._007E_0093_0015(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScLowerRight)
		{
			_0097._007E_008E_0011(this._0002, 1);
		}
		else if (_0099_0004._007E_0093_0015(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScUpperLeft)
		{
			_0097._007E_008E_0011(this._0002, 2);
		}
		else if (_0099_0004._007E_0093_0015(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScUpperRight)
		{
			_0097._007E_008E_0011(this._0002, 3);
		}
		if (buCamParameter.Speeds.SpindleDirection == ClockDirectionType.CW)
		{
			_0095._007E_0093_000F(this._0002, true);
			_0095._007E_0093_000F(this._0001, false);
		}
		else
		{
			_0095._007E_0093_000F(this._0002, false);
			_0095._007E_0093_000F(this._0001, true);
		}
		_0095._007E_0096_000F(this._000E, global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_leadintype));
		do
		{
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadintype), buMWCaptions.LeadParamsType[0]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadintype), buMWCaptions.LeadParamsType[1]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadintype), buMWCaptions.LeadParamsType[2]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadintype), buMWCaptions.LeadParamsType[8]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadintype), buMWCaptions.LeadParamsType[3]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadintype), buMWCaptions.LeadParamsType[4]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadintype), buMWCaptions.LeadParamsType[5]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadintype), buMWCaptions.LeadParamsType[7]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadintype), buMWCaptions.LeadParamsType[6]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadintype), buMWCaptions.LeadParamsType[14]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadintype), buMWCaptions.LeadParamsType[11]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadintype), buMWCaptions.LeadParamsType[9]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadintype), buMWCaptions.LeadParamsType[10]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadintype), buMWCaptions.LeadParamsType[19]);
			if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialArc)
			{
				_0097._007E_008E_0011(cmb_leadintype, 0);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangArc)
			{
				_0097._007E_008E_0011(cmb_leadintype, 1);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VerticalTangArc)
			{
				_0097._007E_008E_0011(cmb_leadintype, 2);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertTangArc)
			{
				_0097._007E_008E_0011(cmb_leadintype, 3);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.HorizontalTangArc)
			{
				_0097._007E_008E_0011(cmb_leadintype, 4);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalArc)
			{
				_0097._007E_008E_0011(cmb_leadintype, 5);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 6);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 7);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 8);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseOrthogonalLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 9);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VertProfileRamp)
			{
				_0097._007E_008E_0011(cmb_leadintype, 10);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertProfileRamp)
			{
				_0097._007E_008E_0011(cmb_leadintype, 11);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.PositionLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 12);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.SlantLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 13);
			}
			_0095._007E_0096_000F(this._0008, global::_0003._007E_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
			global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_leadouttype));
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[0]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[1]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[2]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[8]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[3]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[4]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[5]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[7]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[6]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[14]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[11]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[9]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[10]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[19]);
			bool flag2;
			if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialArc)
			{
				_0097._007E_008E_0011(cmb_leadouttype, 0);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangArc)
			{
				_0097._007E_008E_0011(cmb_leadouttype, 1);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VerticalTangArc)
			{
				_0097._007E_008E_0011(cmb_leadouttype, 2);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertTangArc)
			{
				_0097._007E_008E_0011(cmb_leadouttype, 3);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.HorizontalTangArc)
			{
				_0097._007E_008E_0011(cmb_leadouttype, 4);
			}
			else
			{
				bool flag = _0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalArc;
				if (false)
				{
					goto IL_17ca;
				}
				if (flag)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 5);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialLine)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 6);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangLine)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 7);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalLine)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 8);
				}
				else
				{
					if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) != LeadParamsType.ReverseOrthogonalLine)
					{
						flag2 = _0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VertProfileRamp;
						goto IL_17ca;
					}
					_0097._007E_008E_0011(cmb_leadouttype, 9);
				}
			}
			goto IL_1912;
			IL_17ca:
			if (flag2)
			{
				_0097._007E_008E_0011(cmb_leadouttype, 10);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertProfileRamp)
			{
				_0097._007E_008E_0011(cmb_leadouttype, 11);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.PositionLine)
			{
				_0097._007E_008E_0011(cmb_leadouttype, 12);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.SlantLine)
			{
				_0097._007E_008E_0011(cmb_leadouttype, 13);
			}
			goto IL_1912;
			IL_1912:
			_0095._007E_0096_000F(this._0008, global::_0003._007E_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
			_0095._007E_0096_000F(this._0013, global::_0003._007E_0008_0002(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
			_0095._007E_0096_000F(this._0012, global::_0003._007E_0003_0002(_0016_0004._007E_0007_0015(global::_0084._007E_009D_0006(mwCamParameter))));
		}
		while (-1 == 0);
		_0095._007E_0096_000F(this._0014, global::_0003._007E_009E_0002(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(this._0010, global::_0003._007E_0014(_009A._007E_009E_0011(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(this._0011, global::_0003._007E_000F_0002(global::_0084._007E_009D_0006(mwCamParameter)));
		_0095._007E_0096_000F(this._0015, global::_0003._007E_000E_0002(_0084_0002._007E_008F_0012(global::_0084._007E_009D_0006(mwCamParameter))));
		_0095._007E_0096_000F(_0016, global::_0003._007E_008B_0002(_0089_0005._007E_0093_0016(global::_0084._007E_009D_0006(mwCamParameter))));
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._0084_0018());
		Configration.Mode = CamMode.TriangularMesh;
		Configration.CamTriMeshType = CamTriangularMeshType.ParallelCuts;
		global::_0011._007E_0086_0006(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		global::_0005._0002._0001(this);
		ControlUpdate();
	}

	public void ControlUpdate()
	{
		_0095._007E_0095_000F(this._0016, global::_0003._007E_0083(this._0004));
		_0095._007E_0095_000F(_007F, global::_0003._007E_0083(this._0004));
		_0095._007E_0095_000F(this._0007, false);
		if ((global::_000E._007E_000E_0006(this._0001) == 2) | (global::_000E._007E_000E_0006(this._0001) == 3))
		{
			_0095._007E_0095_000F(this._0007, true);
		}
		_0095._007E_0095_000F(this._0015, false);
		_0095._007E_0095_000F(_0088, false);
		_0095._007E_0095_000F(this._0014, false);
		_0095._007E_0095_000F(_001E, false);
		_0095._007E_0095_000F(this._0013, false);
		_0095._007E_0095_000F(_001D, false);
		if (global::_000E._007E_000E_0006(this._0003) == 0)
		{
			_0095._007E_0095_000F(this._0015, true);
			goto IL_013d;
		}
		_0095._007E_0095_000F(this._0014, true);
		_0095._007E_0095_000F(_001E, true);
		_0095._007E_0095_000F(this._0013, true);
		_0095._007E_0095_000F(_001D, true);
		goto IL_019d;
		IL_013d:
		_0095._007E_0095_000F(_0088, true);
		goto IL_019d;
		IL_019d:
		_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._000E));
		_0095._007E_0095_000F(cmb_leadintype, global::_0003._007E_0083(this._000E));
		_0095._007E_0095_000F(_0086, global::_0003._007E_0083(this._000E));
		_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(this._0008));
		if (6u != 0)
		{
			_0095._007E_0095_000F(cmb_leadouttype, global::_0003._007E_0083(this._0008));
			_0095._007E_0095_000F(_0083, global::_0003._007E_0083(this._0008));
			_0095._007E_0095_000F(_0013, global::_0003._007E_0083(this._0014));
			_0095._007E_0095_000F(_0012, global::_0003._007E_0083(this._0013));
			_0095._007E_0095_000F(_000F, global::_0003._007E_0083(this._0011));
			_0095._007E_0095_000F(_000E, global::_0003._007E_0083(this._0010));
			_0095._007E_0095_000F(_0014, global::_0003._007E_0083(this._0015));
			_0095._007E_0095_000F(_0010, global::_0003._007E_0083(this._0012));
			_0095._007E_0095_000F(this._000F, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0006, !global::_0003._007E_0083(this._0005));
			_0095._007E_0095_000F(_0080, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005));
			_0095._007E_0095_000F(this._0017, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005));
			_0095._007E_0095_000F(this._0005, !global::_0003._007E_0083(this._0006));
			_0095._007E_0095_000F(_0082, global::_0003._007E_0083(this._0006) & global::_0003._007E_008C(this._0006));
			_0095._007E_0095_000F(_0019, global::_0003._007E_0083(this._0006) & global::_0003._007E_008C(this._0006));
			_0095._007E_0095_000F(_0081, global::_0003._007E_0083(this._0006) & global::_0003._007E_008C(this._0006));
			_0095._007E_0095_000F(_0018, global::_0003._007E_0083(this._0006) & global::_0003._007E_008C(this._0006));
			if (!buMWCalcs.AdvancedTriMesh)
			{
				_0095._007E_0095_000F(this._0013, false);
				_0095._007E_0095_000F(_0012, false);
			}
			return;
		}
		goto IL_013d;
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Expected O, but got Unknown
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Expected O, but got Unknown
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_043d: Expected O, but got Unknown
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Expected O, but got Unknown
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Expected O, but got Unknown
		//IL_055b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Expected O, but got Unknown
		//IL_0581: Unknown result type (might be due to invalid IL or missing references)
		//IL_058b: Expected O, but got Unknown
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Expected O, but got Unknown
		//IL_1142: Unknown result type (might be due to invalid IL or missing references)
		//IL_114c: Expected O, but got Unknown
		//IL_1168: Unknown result type (might be due to invalid IL or missing references)
		//IL_1172: Expected O, but got Unknown
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Expected O, but got Unknown
		//IL_061e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Expected O, but got Unknown
		//IL_1202: Unknown result type (might be due to invalid IL or missing references)
		//IL_120c: Expected O, but got Unknown
		//IL_2055: Unknown result type (might be due to invalid IL or missing references)
		//IL_205f: Expected O, but got Unknown
		//IL_207b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2085: Expected O, but got Unknown
		//IL_217d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2187: Expected O, but got Unknown
		//IL_21a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_21ad: Expected O, but got Unknown
		//IL_22a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_22af: Expected O, but got Unknown
		//IL_22cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_22d5: Expected O, but got Unknown
		//IL_2115: Unknown result type (might be due to invalid IL or missing references)
		//IL_211f: Expected O, but got Unknown
		//IL_23cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_23d7: Expected O, but got Unknown
		//IL_23f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_23fd: Expected O, but got Unknown
		//IL_223d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2247: Expected O, but got Unknown
		//IL_24f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ff: Expected O, but got Unknown
		//IL_251b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2525: Expected O, but got Unknown
		//IL_2365: Unknown result type (might be due to invalid IL or missing references)
		//IL_236f: Expected O, but got Unknown
		//IL_261d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2627: Expected O, but got Unknown
		//IL_2643: Unknown result type (might be due to invalid IL or missing references)
		//IL_264d: Expected O, but got Unknown
		//IL_248d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2497: Expected O, but got Unknown
		//IL_2745: Unknown result type (might be due to invalid IL or missing references)
		//IL_274f: Expected O, but got Unknown
		//IL_276b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2775: Expected O, but got Unknown
		//IL_25b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_25bf: Expected O, but got Unknown
		//IL_286d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2877: Expected O, but got Unknown
		//IL_2893: Unknown result type (might be due to invalid IL or missing references)
		//IL_289d: Expected O, but got Unknown
		//IL_26dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_26e7: Expected O, but got Unknown
		//IL_2805: Unknown result type (might be due to invalid IL or missing references)
		//IL_280f: Expected O, but got Unknown
		//IL_292d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2937: Expected O, but got Unknown
		Control control = new Control();
		Control control2;
		if (7u != 0)
		{
			control2 = control;
		}
		control2 = (Control)P_0;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(btn_ok)))
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
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				global::_0011._001C_0006(this);
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				_0095._0094_000F(this, false);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(btn_cancel)))
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(this._0007)))
		{
			F_CuttingMethodAdvanced f_CuttingMethodAdvanced = new F_CuttingMethodAdvanced();
			f_CuttingMethodAdvanced.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_CuttingMethodAdvanced.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_CuttingMethodAdvanced.buCamParameter = new camParameters5(buCamParameter);
			f_CuttingMethodAdvanced.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_CuttingMethodAdvanced.Tool = new ToolBase5(f_CuttingMethodAdvanced.Tool);
			}
			f_CuttingMethodAdvanced.Init();
			_009D_0003._007E_0091_0014(f_CuttingMethodAdvanced);
			if (f_CuttingMethodAdvanced.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_CuttingMethodAdvanced.mwCamParameter)));
				buCamParameter = new camParameters5(f_CuttingMethodAdvanced.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(this._0003)))
		{
			F_Height f_Height = new F_Height();
			f_Height.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_Height.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_Height.buCamParameter = new camParameters5(buCamParameter);
			f_Height.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(this._0001)))
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(this._0004)))
		{
			F_ContourLink f_ContourLink = new F_ContourLink();
			f_ContourLink.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_ContourLink.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_ContourLink.buCamParameter = new camParameters5(buCamParameter);
			f_ContourLink.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_ContourLink.Tool = new ToolBase5(f_ContourLink.Tool);
			}
			f_ContourLink.Init();
			_009D_0003._007E_0091_0014(f_ContourLink);
			if (f_ContourLink.Properties.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_ContourLink.mwCamParameter)));
				buCamParameter = new camParameters5(f_ContourLink.buCamParameter);
				if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialArc)
				{
					_0097._007E_008E_0011(cmb_leadintype, 0);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangArc)
				{
					_0097._007E_008E_0011(cmb_leadintype, 1);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VerticalTangArc)
				{
					_0097._007E_008E_0011(cmb_leadintype, 2);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertTangArc)
				{
					_0097._007E_008E_0011(cmb_leadintype, 3);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.HorizontalTangArc)
				{
					_0097._007E_008E_0011(cmb_leadintype, 4);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalArc)
				{
					_0097._007E_008E_0011(cmb_leadintype, 5);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialLine)
				{
					_0097._007E_008E_0011(cmb_leadintype, 6);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangLine)
				{
					_0097._007E_008E_0011(cmb_leadintype, 7);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalLine)
				{
					_0097._007E_008E_0011(cmb_leadintype, 8);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseOrthogonalLine)
				{
					_0097._007E_008E_0011(cmb_leadintype, 9);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VertProfileRamp)
				{
					_0097._007E_008E_0011(cmb_leadintype, 10);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertProfileRamp)
				{
					_0097._007E_008E_0011(cmb_leadintype, 11);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.SlantLine)
				{
					_0097._007E_008E_0011(cmb_leadintype, 12);
				}
				_0095._007E_0096_000F(this._000E, global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
				if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialArc)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 0);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangArc)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 1);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VerticalTangArc)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 2);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertTangArc)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 3);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.HorizontalTangArc)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 4);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalArc)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 5);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialLine)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 6);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangLine)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 7);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalLine)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 8);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseOrthogonalLine)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 9);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VertProfileRamp)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 10);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertProfileRamp)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 11);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.SlantLine)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 12);
				}
				_0095._007E_0096_000F(this._0008, global::_0003._007E_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(this._0002)))
		{
			F_HeightAdvanced f_HeightAdvanced = new F_HeightAdvanced();
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
				buCamParameter = new camParameters5(f_HeightAdvanced.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(this._0006)))
		{
			global::_0005._0002._0001(this);
			F_LeadControl f_LeadControl = new F_LeadControl();
			f_LeadControl.mwCamLeadController = _0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))));
			f_LeadControl.buCamParameter = new camParameters5(buCamParameter);
			f_LeadControl.Configration = new MWCalculationOptions(Configration);
			bool flag = Tool != null;
			if (false)
			{
				goto IL_1c9f;
			}
			if (flag)
			{
				f_LeadControl.Tool = new ToolBase5(f_LeadControl.Tool);
			}
			f_LeadControl.Init();
			_009D_0003._007E_0091_0014(f_LeadControl);
			if (f_LeadControl.Properties.Result == DialogResult.OK)
			{
				_0014_0006._007E_008E_001C(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))), f_LeadControl.mwCamLeadController);
				buCamParameter = new camParameters5(f_LeadControl.buCamParameter);
				if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialArc)
				{
					_0097._007E_008E_0011(cmb_leadintype, 0);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangArc)
				{
					_0097._007E_008E_0011(cmb_leadintype, 1);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VerticalTangArc)
				{
					_0097._007E_008E_0011(cmb_leadintype, 2);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertTangArc)
				{
					_0097._007E_008E_0011(cmb_leadintype, 3);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.HorizontalTangArc)
				{
					_0097._007E_008E_0011(cmb_leadintype, 4);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalArc)
				{
					_0097._007E_008E_0011(cmb_leadintype, 5);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialLine)
				{
					_0097._007E_008E_0011(cmb_leadintype, 6);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangLine)
				{
					_0097._007E_008E_0011(cmb_leadintype, 7);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalLine)
				{
					_0097._007E_008E_0011(cmb_leadintype, 8);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseOrthogonalLine)
				{
					_0097._007E_008E_0011(cmb_leadintype, 9);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VertProfileRamp)
				{
					_0097._007E_008E_0011(cmb_leadintype, 10);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertProfileRamp)
				{
					_0097._007E_008E_0011(cmb_leadintype, 11);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.PositionLine)
				{
					_0097._007E_008E_0011(cmb_leadintype, 12);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.SlantLine)
				{
					_0097._007E_008E_0011(cmb_leadintype, 13);
				}
				_0095._007E_0096_000F(this._000E, global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(this._0005)))
		{
			F_LeadControl f_LeadControl2 = new F_LeadControl();
			f_LeadControl2.mwCamLeadController = _0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))));
			f_LeadControl2.buCamParameter = new camParameters5(buCamParameter);
			f_LeadControl2.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_LeadControl2.Tool = new ToolBase5(f_LeadControl2.Tool);
			}
			f_LeadControl2.Init();
			_009D_0003._007E_0091_0014(f_LeadControl2);
			if (f_LeadControl2.Properties.Result == DialogResult.OK)
			{
				_0014_0006._007E_008F_001C(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))), f_LeadControl2.mwCamLeadController);
				buCamParameter = new camParameters5(f_LeadControl2.buCamParameter);
				if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialArc)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 0);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangArc)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 1);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VerticalTangArc)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 2);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertTangArc)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 3);
				}
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.HorizontalTangArc)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 4);
				}
				else
				{
					if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) != LeadParamsType.OrthogonalArc)
					{
						goto IL_1c9f;
					}
					_0097._007E_008E_0011(cmb_leadouttype, 5);
				}
				goto IL_1fc1;
			}
		}
		goto IL_200c;
		IL_1c9f:
		if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialLine)
		{
			_0097._007E_008E_0011(cmb_leadouttype, 6);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangLine)
		{
			_0097._007E_008E_0011(cmb_leadouttype, 7);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalLine)
		{
			_0097._007E_008E_0011(cmb_leadouttype, 8);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseOrthogonalLine)
		{
			_0097._007E_008E_0011(cmb_leadouttype, 9);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VertProfileRamp)
		{
			_0097._007E_008E_0011(cmb_leadouttype, 10);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertProfileRamp)
		{
			_0097._007E_008E_0011(cmb_leadouttype, 11);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.PositionLine)
		{
			_0097._007E_008E_0011(cmb_leadouttype, 12);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.SlantLine)
		{
			_0097._007E_008E_0011(cmb_leadouttype, 13);
		}
		goto IL_1fc1;
		IL_1fc1:
		_0095._007E_0096_000F(this._0008, global::_0003._007E_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
		goto IL_200c;
		IL_200c:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(_0014)))
		{
			F_AngleRange f_AngleRange = new F_AngleRange();
			f_AngleRange.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_AngleRange.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_AngleRange.buCamParameter = new camParameters5(buCamParameter);
			f_AngleRange.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_AngleRange.Tool = new ToolBase5(f_AngleRange.Tool);
			}
			f_AngleRange.Init();
			_009D_0003._007E_0091_0014(f_AngleRange);
			if (f_AngleRange.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_AngleRange.mwCamParameter)));
				buCamParameter = new camParameters5(f_AngleRange.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(_0013)))
		{
			F_MultiPass f_MultiPass = new F_MultiPass();
			f_MultiPass.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_MultiPass.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_MultiPass.buCamParameter = new camParameters5(buCamParameter);
			f_MultiPass.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_MultiPass.Tool = new ToolBase5(f_MultiPass.Tool);
			}
			f_MultiPass.Init();
			_009D_0003._007E_0091_0014(f_MultiPass);
			if (f_MultiPass.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_MultiPass.mwCamParameter)));
				buCamParameter = new camParameters5(f_MultiPass.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(_0012)))
		{
			F_RestFinish f_RestFinish = new F_RestFinish();
			f_RestFinish.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_RestFinish.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_RestFinish.buCamParameter = new camParameters5(buCamParameter);
			f_RestFinish.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_RestFinish.Tool = new ToolBase5(f_RestFinish.Tool);
			}
			f_RestFinish.Init();
			_009D_0003._007E_0091_0014(f_RestFinish);
			if (f_RestFinish.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_RestFinish.mwCamParameter)));
				buCamParameter = new camParameters5(f_RestFinish.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(_0010)))
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(_000F)))
		{
			F_RoundCorner f_RoundCorner = new F_RoundCorner();
			f_RoundCorner.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_RoundCorner.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_RoundCorner.buCamParameter = new camParameters5(buCamParameter);
			f_RoundCorner.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_RoundCorner.Tool = new ToolBase5(f_RoundCorner.Tool);
			}
			f_RoundCorner.Init();
			_009D_0003._007E_0091_0014(f_RoundCorner);
			if (f_RoundCorner.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_RoundCorner.mwCamParameter)));
				buCamParameter = new camParameters5(f_RoundCorner.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(_000E)))
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(_0008)))
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(this._0016)))
		{
			F_FeedZone f_FeedZone = new F_FeedZone();
			f_FeedZone.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_FeedZone.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_FeedZone.buCamParameter = new camParameters5(buCamParameter);
			f_FeedZone.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_FeedZone.Tool = new ToolBase5(f_FeedZone.Tool);
			}
			f_FeedZone.Init();
			_009D_0003._007E_0091_0014(f_FeedZone);
			if (f_FeedZone.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_FeedZone.mwCamParameter)));
				buCamParameter = new camParameters5(f_FeedZone.buCamParameter);
			}
		}
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		if (!PropertiesForm.Inited)
		{
		}
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

	internal void _0003(object P_0, EventArgs P_1)
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

	internal void _0004(object P_0, EventArgs P_1)
	{
		ControlUpdate();
	}

	internal void _0005(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		if (!PropertiesForm.Inited)
		{
			return;
		}
		while (true)
		{
			ControlUpdate();
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				if (global::_000E._007E_000E_0006(this._0001) != 0)
				{
					goto IL_00a7;
				}
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0086_0018());
			}
			goto IL_00fb;
			IL_00a7:
			if (global::_000E._007E_000E_0006(this._0001) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0087_0018());
			}
			else if (global::_000E._007E_000E_0006(this._0001) != 2)
			{
			}
			goto IL_00fb;
			IL_07e7:
			if (global::_000E._007E_000E_0006(cmb_leadouttype) == 12)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0018());
				break;
			}
			if (global::_000E._007E_000E_0006(cmb_leadouttype) == 13)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0018());
				if (0 == 0)
				{
					break;
				}
				goto IL_00a7;
			}
			break;
			IL_00fb:
			bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002));
			if (uint.MaxValue != 0)
			{
				if (!flag || global::_000E._007E_000E_0006(this._0002) == 0 || global::_000E._007E_000E_0006(this._0002) == 1)
				{
				}
				while (true)
				{
					int num;
					int num2;
					if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_leadintype)))
					{
						if (false)
						{
							return;
						}
						if (global::_000E._007E_000E_0006(cmb_leadintype) == 0)
						{
							if (false)
							{
								break;
							}
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
						}
						else
						{
							bool flag2 = global::_000E._007E_000E_0006(cmb_leadintype) == 1;
							if (0 == 0)
							{
								if (!flag2)
								{
									num = global::_000E._007E_000E_0006(cmb_leadintype);
									num2 = 2;
									goto IL_022e;
								}
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0018());
							}
						}
					}
					goto IL_04e8;
					IL_022e:
					if (num == num2)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0018());
					}
					else if (global::_000E._007E_000E_0006(cmb_leadintype) == 3)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
					}
					else
					{
						bool flag3 = global::_000E._007E_000E_0006(cmb_leadintype) == 4;
						if (5 == 0)
						{
							return;
						}
						if (flag3)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
						}
						else if (global::_000E._007E_000E_0006(cmb_leadintype) == 5)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
						}
						else if (global::_000E._007E_000E_0006(cmb_leadintype) == 6)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
						}
						else if (global::_000E._007E_000E_0006(cmb_leadintype) == 7)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
						}
						else if (global::_000E._007E_000E_0006(cmb_leadintype) == 8)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
						}
						else if (global::_000E._007E_000E_0006(cmb_leadintype) == 9)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
						}
						else if (global::_000E._007E_000E_0006(cmb_leadintype) == 10)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0018());
						}
						else if (global::_000E._007E_000E_0006(cmb_leadintype) == 11)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
						}
						else if (global::_000E._007E_000E_0006(cmb_leadintype) == 12)
						{
							if (6u != 0)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0018());
							}
						}
						else if (global::_000E._007E_000E_0006(cmb_leadintype) == 13)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0018());
						}
					}
					goto IL_04e8;
					IL_04e8:
					if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_leadouttype)))
					{
						if (global::_000E._007E_000E_0006(cmb_leadouttype) == 0)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
							return;
						}
						if (global::_000E._007E_000E_0006(cmb_leadouttype) == 1)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0018());
							return;
						}
						if (global::_000E._007E_000E_0006(cmb_leadouttype) == 2)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0018());
							return;
						}
						num = global::_000E._007E_000E_0006(cmb_leadouttype);
						num2 = 3;
						if (num2 == 0)
						{
							goto IL_022e;
						}
						if (num == num2)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
							return;
						}
						if (global::_000E._007E_000E_0006(cmb_leadouttype) == 4)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
							return;
						}
						if (global::_000E._007E_000E_0006(cmb_leadouttype) == 5)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
							return;
						}
						if (global::_000E._007E_000E_0006(cmb_leadouttype) == 6)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
							return;
						}
						if (global::_000E._007E_000E_0006(cmb_leadouttype) == 7)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
							return;
						}
						if (global::_000E._007E_000E_0006(cmb_leadouttype) == 8)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
							return;
						}
						if (global::_000E._007E_000E_0006(cmb_leadouttype) == 9)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
							return;
						}
						if (false)
						{
							continue;
						}
						goto IL_0772;
					}
					return;
				}
				continue;
			}
			goto IL_07e7;
			IL_0772:
			if (global::_000E._007E_000E_0006(cmb_leadouttype) == 10)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0018());
				break;
			}
			if (global::_000E._007E_000E_0006(cmb_leadouttype) == 11)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
				break;
			}
			goto IL_07e7;
		}
	}

	internal void _0006(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		F_GifView f_GifView6 = default(F_GifView);
		bool num;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0015)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0095_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView);
				_0086_0003._007E_0018_0014(f_GifView, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			if (global::_000E._007E_000E_0006(this._0001) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0086_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView2 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView2);
					_0086_0003._007E_0018_0014(f_GifView2, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView2);
				}
			}
			else if (global::_000E._007E_000E_0006(this._0001) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0087_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView3 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView3);
					_0086_0003._007E_0018_0014(f_GifView3, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView3);
				}
			}
			else if (global::_000E._007E_000E_0006(this._0001) != 2)
			{
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			if (global::_000E._007E_000E_0006(this._0002) != 0 && global::_000E._007E_000E_0006(this._0002) != 1)
			{
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView4 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView4);
				_0086_0003._007E_0018_0014(f_GifView4, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView4);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0096_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView5 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView5);
				_0086_0003._007E_0018_0014(f_GifView5, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView5);
			}
			if (false)
			{
				goto IL_0c2d;
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001D_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				f_GifView6 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView6);
				goto IL_0409;
			}
		}
		else
		{
			if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
			{
				bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000F));
				num = flag;
				goto IL_04e8;
			}
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001E_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView7 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView7);
				_0086_0003._007E_0018_0014(f_GifView7, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView7);
			}
		}
		goto IL_0927;
		IL_109e:
		bool num2;
		if (num2 != 0)
		{
			F_GifView f_GifView8 = new F_GifView();
			global::_0011._007E_0084_0006(f_GifView8);
			_0086_0003._007E_0018_0014(f_GifView8, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView8);
		}
		goto IL_162d;
		IL_162d:
		_0095._007E_0096_000F(this._0002, false);
		if (0 == 0)
		{
			return;
		}
		goto IL_1610;
		IL_0fa4:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_leadouttype)))
		{
			if (global::_000E._007E_000E_0006(cmb_leadouttype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView9 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView9);
					_0086_0003._007E_0018_0014(f_GifView9, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView9);
				}
			}
			else
			{
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0018());
					bool flag2 = global::_0003._007E_0083(this._0002);
					num2 = flag2;
					goto IL_109e;
				}
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView10 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView10);
						if (6 == 0)
						{
							goto IL_0409;
						}
						_0086_0003._007E_0018_0014(f_GifView10, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView10);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 3)
				{
					if (2 == 0)
					{
						goto IL_0553;
					}
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						if (5 == 0)
						{
							goto IL_0724;
						}
						F_GifView f_GifView11 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView11);
						_0086_0003._007E_0018_0014(f_GifView11, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView11);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 4)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView12 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView12);
						_0086_0003._007E_0018_0014(f_GifView12, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView12);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 5)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView13 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView13);
						_0086_0003._007E_0018_0014(f_GifView13, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView13);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 6)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView14 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView14);
						_0086_0003._007E_0018_0014(f_GifView14, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView14);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 7)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView15 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView15);
						_0086_0003._007E_0018_0014(f_GifView15, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView15);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 8)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView16 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView16);
						_0086_0003._007E_0018_0014(f_GifView16, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView16);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 9)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				}
				else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 10)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView17 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView17);
						_0086_0003._007E_0018_0014(f_GifView17, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView17);
					}
				}
				else
				{
					bool flag3 = global::_000E._007E_000E_0006(cmb_leadouttype) == 11;
					num2 = flag3;
					if (false)
					{
						goto IL_109e;
					}
					if (num2)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
						if (global::_0003._007E_0083(this._0002))
						{
							F_GifView f_GifView18 = new F_GifView();
							global::_0011._007E_0084_0006(f_GifView18);
							_0086_0003._007E_0018_0014(f_GifView18, FormStartPosition.CenterParent);
							_009D_0003._007E_0091_0014(f_GifView18);
						}
					}
					else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 12)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0018());
					}
					else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 13)
					{
						goto IL_1610;
					}
				}
			}
		}
		goto IL_162d;
		IL_0927:
		bool flag4;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_leadintype)))
		{
			if (global::_000E._007E_000E_0006(cmb_leadintype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView19 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView19);
					_0086_0003._007E_0018_0014(f_GifView19, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView19);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					if (3 == 0)
					{
						goto IL_1610;
					}
					F_GifView f_GifView20 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView20);
					_0086_0003._007E_0018_0014(f_GifView20, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView20);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView21 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView21);
					_0086_0003._007E_0018_0014(f_GifView21, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView21);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 3)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView22 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView22);
					_0086_0003._007E_0018_0014(f_GifView22, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView22);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 4)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView23 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView23);
					_0086_0003._007E_0018_0014(f_GifView23, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView23);
				}
			}
			else
			{
				if (global::_000E._007E_000E_0006(cmb_leadintype) == 5)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
					flag4 = global::_0003._007E_0083(this._0002);
					goto IL_0c2d;
				}
				if (global::_000E._007E_000E_0006(cmb_leadintype) == 6)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
					bool flag5 = global::_0003._007E_0083(this._0002);
					num = flag5;
					if (-1 == 0)
					{
						goto IL_04e8;
					}
					if (num)
					{
						F_GifView f_GifView24 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView24);
						_0086_0003._007E_0018_0014(f_GifView24, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView24);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 7)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView25 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView25);
						_0086_0003._007E_0018_0014(f_GifView25, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView25);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 8)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView26 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView26);
						_0086_0003._007E_0018_0014(f_GifView26, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView26);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 9)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 10)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView27 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView27);
						_0086_0003._007E_0018_0014(f_GifView27, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView27);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 11)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView28 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView28);
						_0086_0003._007E_0018_0014(f_GifView28, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView28);
					}
				}
				else
				{
					if (global::_000E._007E_000E_0006(cmb_leadintype) != 12)
					{
						goto IL_0f6c;
					}
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0018());
				}
			}
		}
		goto IL_0fa4;
		IL_1610:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0018());
		goto IL_162d;
		IL_0c2d:
		if (flag4)
		{
			F_GifView f_GifView29 = new F_GifView();
			global::_0011._007E_0084_0006(f_GifView29);
			_0086_0003._007E_0018_0014(f_GifView29, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView29);
		}
		goto IL_0fa4;
		IL_0793:
		bool num3;
		if (num3 != 0)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0082_0018());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_0018());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000E)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0099_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView30 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView30);
				_0086_0003._007E_0018_0014(f_GifView30, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView30);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0008)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._009A_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView31 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView31);
				_0086_0003._007E_0018_0014(f_GifView31, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView31);
			}
		}
		goto IL_0927;
		IL_04e8:
		bool flag6 = default(bool);
		if (num)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0097_0018());
		}
		else
		{
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001F_0018());
				goto IL_0553;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0097_0018());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000E)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._007F_0018());
			}
			else
			{
				num3 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0008));
				if (false)
				{
					goto IL_0793;
				}
				if (num3)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0080_0018());
				}
				else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0007)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0098_0018());
				}
				else
				{
					if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
					{
						if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
						{
							flag6 = global::_0003._007E_001C(this._0001);
							goto IL_0724;
						}
						bool flag7 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001));
						num3 = flag7;
						goto IL_0793;
					}
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0081_0018());
				}
			}
		}
		goto IL_0927;
		IL_0553:
		if (3u != 0)
		{
			goto IL_0927;
		}
		goto IL_0f6c;
		IL_0409:
		_0086_0003._007E_0018_0014(f_GifView6, FormStartPosition.CenterParent);
		_009D_0003._007E_0091_0014(f_GifView6);
		goto IL_0927;
		IL_0724:
		if (flag6)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0082_0018());
		}
		else
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_0018());
		}
		goto IL_0927;
		IL_0f6c:
		if (global::_000E._007E_000E_0006(cmb_leadintype) == 13)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0018());
		}
		goto IL_0fa4;
	}

	internal void _0007(object P_0, EventArgs P_1)
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
