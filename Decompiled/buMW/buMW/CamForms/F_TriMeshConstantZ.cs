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

public class F_TriMeshConstantZ : Form
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

	internal Panel _0001;

	internal Button _0001;

	internal NumericUpDown _0004;

	internal Label _0004;

	internal Panel _0002;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal NumericUpDown _0005;

	internal Label _0005;

	internal Panel _0003;

	internal Label _0006;

	internal Label _0007;

	internal Panel _0004;

	internal Label _0008;

	internal Label _000E;

	internal Label _000F;

	internal Panel _0005;

	internal Button _0002;

	internal Label _0010;

	internal NumericUpDown _0006;

	internal Label _0011;

	internal Label _0012;

	internal Label _0013;

	internal NumericUpDown _0007;

	internal Label _0014;

	internal NumericUpDown _0008;

	internal NumericUpDown _000E;

	internal PictureBox _0001;

	internal CheckBox _0002;

	internal NumericUpDown _000F;

	internal CheckBox _0003;

	internal NumericUpDown _0010;

	internal Label _0015;

	internal NumericUpDown _0011;

	internal Label _0016;

	internal NumericUpDown _0012;

	internal Label _0017;

	internal ComboBox _0001;

	internal Button _0003;

	internal Panel _0006;

	internal Button _0004;

	internal Label _0018;

	public ComboBox cmb_leadouttype;

	internal Label _0019;

	internal CheckBox _0004;

	internal Panel _0007;

	internal Button _0005;

	internal Label _001A;

	public ComboBox cmb_leadintype;

	internal Label _001B;

	internal CheckBox _0005;

	internal Label _001C;

	internal Panel _0008;

	internal Button _0006;

	internal Label _001D;

	internal Panel _000E;

	internal Button _0007;

	internal CheckBox _0006;

	internal Label _001E;

	internal Panel _000F;

	internal Button _0008;

	internal CheckBox _0007;

	internal Label _001F;

	internal Panel _0010;

	internal Button _000E;

	internal Button _000F;

	internal CheckBox _0008;

	internal Label _007F;

	internal Panel _0011;

	internal Button _0010;

	internal CheckBox _000E;

	internal Label _0080;

	internal Panel _0012;

	internal CheckBox _000F;

	internal Button _0011;

	internal Label _0081;

	internal Panel _0013;

	internal Button _0012;

	internal CheckBox _0010;

	internal Label _0082;

	internal Button _0013;

	internal Panel _0014;

	internal Button _0014;

	internal Button _0015;

	internal CheckBox _0011;

	internal Label _0083;

	internal Panel _0015;

	internal Button _0016;

	internal NumericUpDown _0013;

	internal Button _0017;

	internal NumericUpDown _0014;

	internal RadioButton _0003;

	internal Label _0084;

	internal RadioButton _0004;

	internal Panel _0016;

	internal Label _0086;

	internal ComboBox _0002;

	internal Label _0087;

	internal ComboBox _0003;

	internal Label _0088;

	internal ComboBox _0004;

	internal Label _0089;

	internal Label _008A;

	internal NumericUpDown _0015;

	public F_TriMeshConstantZ()
	{
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		bool num = PropertiesForm.Height > 10;
		bool flag;
		if (8u != 0)
		{
			flag = num;
		}
		if (flag)
		{
			_0097._008C_0011(this, PropertiesForm.Height);
		}
		if (PropertiesForm.Width > 10)
		{
			_0097._008D_0011(this, PropertiesForm.Width);
		}
		_0095._007E_0094_000F(this._0002, PropertiesForm.ShowHelp);
		_0088_0003._007E_001A_0014(this._0010, _0087_0003._0019_0014(global::_0007._007E_001D_0004(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0011, _0087_0003._0019_0014(global::_0007._007E_001C_0004(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0012, _0087_0003._0019_0014(global::_0007._007E_0082_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0083_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(_0014, _0087_0003._0019_0014(global::_0007._007E_007F_0003(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))))));
		_0088_0003._007E_001A_0014(_0013, _0004_0004._0097_0014(global::_000E._007E_009F_0005(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))))));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0017_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0018_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0019_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0007, _0087_0003._0019_0014(global::_0007._007E_001E_0003(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0008, _0087_0003._0019_0014(global::_0007._007E_001D_0003(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._000E, _0087_0003._0019_0014(global::_0007._007E_001C_0003(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_001B_0003(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(buCamParameter.Speeds.SpindleSpeed));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0007(global::_0084._007E_009D_0006(mwCamParameter)));
		_0095._007E_0096_000F(this._0003, global::_0003._007E_0006(global::_0084._007E_009D_0006(mwCamParameter)));
		_0088_0003._007E_001A_0014(_0015, _0087_0003._0019_0014(global::_0007._007E_001E_0004(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))))));
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0001));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.MachiningParamsStockRemainType[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.MachiningParamsStockRemainType[1]);
		if (_001A_0004._007E_0012_0015(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsStockRemainType.SrtGlobal)
		{
			_0097._007E_008E_0011(this._0001, 0);
		}
		else if (_001A_0004._007E_0012_0015(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsStockRemainType.SrtRadialAndAxial)
		{
			_0097._007E_008E_0011(this._0001, 1);
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
		if (_008F._007E_0012_0007(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
		{
			_0095._007E_0093_000F(this._0004, true);
			_0095._007E_0093_000F(this._0003, false);
		}
		else
		{
			_0095._007E_0093_000F(this._0004, false);
			_0095._007E_0093_000F(this._0003, true);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0002));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0002), buMWCaptions.MachiningParamsDirection[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0002), buMWCaptions.MachiningParamsDirection[3]);
		if (_0015_0004._007E_0006_0015(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsDirection.DirClimb)
		{
			_0097._007E_008E_0011(this._0002, 0);
		}
		else if (_0015_0004._007E_0006_0015(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsDirection.DirConventional)
		{
			_0097._007E_008E_0011(this._0002, 1);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0004));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0004), buMWCaptions.MachiningParamsMachType[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0004), buMWCaptions.MachiningParamsMachType[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0004), buMWCaptions.MachiningParamsMachType[2]);
		if (_0092._007E_0016_0007(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsMachType.MachtypeOneway)
		{
			_0097._007E_008E_0011(this._0004, 0);
		}
		else if (_0092._007E_0016_0007(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsMachType.MachtypeZigzag)
		{
			_0097._007E_008E_0011(this._0004, 1);
		}
		else if (_0092._007E_0016_0007(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsMachType.MachtypeSpiral)
		{
			_0097._007E_008E_0011(this._0004, 2);
		}
		while (true)
		{
			global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0003));
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0003), buMWCaptions.MachiningParamsMachiningAreaMode[0]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0003), buMWCaptions.MachiningParamsMachiningAreaMode[1]);
			bool flag2 = _0091._007E_0015_0007(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsMachiningAreaMode.MachByLanes;
			if (false)
			{
				goto IL_0ca8;
			}
			if (flag2)
			{
				_0097._007E_008E_0011(this._0003, 0);
			}
			else
			{
				_0097._007E_008E_0011(this._0003, 1);
			}
			_0095._007E_0096_000F(this._0005, global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
			global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_leadintype));
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
			bool flag3;
			if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialArc)
			{
				_0097._007E_008E_0011(cmb_leadintype, 0);
			}
			else
			{
				if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) != LeadParamsType.ReverseTangArc)
				{
					flag3 = _0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VerticalTangArc;
					goto IL_0ca8;
				}
				_0097._007E_008E_0011(cmb_leadintype, 1);
			}
			goto IL_1114;
			IL_1114:
			_0095._007E_0096_000F(this._0004, global::_0003._007E_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
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
			int num2 = _000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[19]);
			while (true)
			{
				if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialArc)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 0);
				}
				else
				{
					num2 = ((_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangArc) ? 1 : 0);
					if (2 == 0)
					{
						continue;
					}
					if (num2 != 0)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 1);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VerticalTangArc)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 2);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertTangArc)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 3);
						if (false)
						{
							break;
						}
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.HorizontalTangArc)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 4);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalArc)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 5);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialLine)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 6);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangLine)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 7);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalLine)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 8);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseOrthogonalLine)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 9);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VertProfileRamp)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 10);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertProfileRamp)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 11);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.PositionLine)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 12);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.SlantLine)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 13);
					}
				}
				_0095._007E_0096_000F(this._0004, global::_0003._007E_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
				_0095._007E_0096_000F(_000E, global::_0003._007E_0008_0002(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
				_0095._007E_0096_000F(_0008, global::_0003._007E_0003_0002(_0016_0004._007E_0007_0015(global::_0084._007E_009D_0006(mwCamParameter))));
				_0095._007E_0096_000F(_000F, global::_0003._007E_009E_0002(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(global::_0084._007E_009D_0006(mwCamParameter)))));
				_0095._007E_0096_000F(this._0006, global::_0003._007E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
				_0095._007E_0096_000F(this._0007, global::_0003._007E_000F_0002(global::_0084._007E_009D_0006(mwCamParameter)));
				_0095._007E_0096_000F(_0010, global::_0003._007E_000E_0002(_0084_0002._007E_008F_0012(global::_0084._007E_009D_0006(mwCamParameter))));
				_0095._007E_0096_000F(_0011, global::_0003._007E_008B_0002(_0089_0005._007E_0093_0016(global::_0084._007E_009D_0006(mwCamParameter))));
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0084_0018());
				global::_0011._007E_0086_0006(this);
				PropertiesForm.Result = DialogResult.None;
				PropertiesForm.Inited = true;
				global::_0005._0002._0001(this);
				ControlUpdate();
				return;
			}
			continue;
			IL_0ca8:
			if (flag3)
			{
				_0097._007E_008E_0011(cmb_leadintype, 2);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertTangArc)
			{
				_0097._007E_008E_0011(cmb_leadintype, 3);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.HorizontalTangArc)
			{
				_0097._007E_008E_0011(cmb_leadintype, 4);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalArc)
			{
				_0097._007E_008E_0011(cmb_leadintype, 5);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 6);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 7);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 8);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseOrthogonalLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 9);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VertProfileRamp)
			{
				_0097._007E_008E_0011(cmb_leadintype, 10);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertProfileRamp)
			{
				_0097._007E_008E_0011(cmb_leadintype, 11);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.PositionLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 12);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.SlantLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 13);
			}
			goto IL_1114;
		}
	}

	public void ControlUpdate()
	{
		_0095._007E_0095_000F(this._0012, false);
		_0095._007E_0095_000F(_001C, false);
		if (0 == 0)
		{
			_0095._007E_0095_000F(this._0011, false);
			_0095._007E_0095_000F(this._0016, false);
		}
		_0095._007E_0095_000F(this._0010, false);
		_0095._007E_0095_000F(this._0015, false);
		while (true)
		{
			if (global::_000E._007E_000E_0006(this._0001) == 0)
			{
				_0095._007E_0095_000F(this._0012, true);
				_0095._007E_0095_000F(_001C, true);
				goto IL_0113;
			}
			if (false)
			{
				break;
			}
			_0095._007E_0095_000F(this._0011, true);
			_0095._007E_0095_000F(this._0016, true);
			_0095._007E_0095_000F(this._0010, true);
			goto IL_0100;
			IL_0113:
			_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(this._0005));
			_0095._007E_0095_000F(cmb_leadintype, global::_0003._007E_0083(this._0005));
			_0095._007E_0095_000F(_001A, global::_0003._007E_0083(this._0005));
			_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0004));
			if (0 == 0)
			{
				_0095._007E_0095_000F(cmb_leadouttype, global::_0003._007E_0083(this._0004));
				_0095._007E_0095_000F(_0018, global::_0003._007E_0083(this._0004));
				_0095._007E_0095_000F(this._0011, global::_0003._007E_0083(_000F));
				_0095._007E_0095_000F(this._0010, global::_0003._007E_0083(_000E));
				_0095._007E_0095_000F(this._0008, global::_0003._007E_0083(this._0007));
				_0095._007E_0095_000F(this._0007, global::_0003._007E_0083(this._0006));
				if (2u != 0)
				{
					_0095._007E_0095_000F(_0012, global::_0003._007E_0083(_0010));
					_0095._007E_0095_000F(this._000E, global::_0003._007E_0083(_0008));
					break;
				}
				continue;
			}
			goto IL_0100;
			IL_0100:
			_0095._007E_0095_000F(this._0015, true);
			goto IL_0113;
		}
		_0095._007E_0095_000F(this._000F, global::_0003._007E_0083(this._0003));
		if (!buMWCalcs.AdvancedTriMesh)
		{
			_0095._007E_0095_000F(_000E, false);
			_0095._007E_0095_000F(this._0010, false);
		}
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Expected O, but got Unknown
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Expected O, but got Unknown
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected O, but got Unknown
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected O, but got Unknown
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Expected O, but got Unknown
		//IL_0585: Unknown result type (might be due to invalid IL or missing references)
		//IL_058f: Expected O, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected O, but got Unknown
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Expected O, but got Unknown
		//IL_1164: Unknown result type (might be due to invalid IL or missing references)
		//IL_116e: Expected O, but got Unknown
		//IL_118a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1194: Expected O, but got Unknown
		//IL_0622: Unknown result type (might be due to invalid IL or missing references)
		//IL_062c: Expected O, but got Unknown
		//IL_2077: Unknown result type (might be due to invalid IL or missing references)
		//IL_2081: Expected O, but got Unknown
		//IL_209d: Unknown result type (might be due to invalid IL or missing references)
		//IL_20a7: Expected O, but got Unknown
		//IL_21a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_21af: Expected O, but got Unknown
		//IL_21cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d5: Expected O, but got Unknown
		//IL_1224: Unknown result type (might be due to invalid IL or missing references)
		//IL_122e: Expected O, but got Unknown
		//IL_22d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_22dd: Expected O, but got Unknown
		//IL_22f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2303: Expected O, but got Unknown
		//IL_2137: Unknown result type (might be due to invalid IL or missing references)
		//IL_2141: Expected O, but got Unknown
		//IL_23fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2405: Expected O, but got Unknown
		//IL_2421: Unknown result type (might be due to invalid IL or missing references)
		//IL_242b: Expected O, but got Unknown
		//IL_226b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2275: Expected O, but got Unknown
		//IL_2523: Unknown result type (might be due to invalid IL or missing references)
		//IL_252d: Expected O, but got Unknown
		//IL_2549: Unknown result type (might be due to invalid IL or missing references)
		//IL_2553: Expected O, but got Unknown
		//IL_2393: Unknown result type (might be due to invalid IL or missing references)
		//IL_239d: Expected O, but got Unknown
		//IL_2651: Unknown result type (might be due to invalid IL or missing references)
		//IL_265b: Expected O, but got Unknown
		//IL_2677: Unknown result type (might be due to invalid IL or missing references)
		//IL_2681: Expected O, but got Unknown
		//IL_24bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_24c5: Expected O, but got Unknown
		//IL_2779: Unknown result type (might be due to invalid IL or missing references)
		//IL_2783: Expected O, but got Unknown
		//IL_279f: Unknown result type (might be due to invalid IL or missing references)
		//IL_27a9: Expected O, but got Unknown
		//IL_28a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_28ab: Expected O, but got Unknown
		//IL_28c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_28d1: Expected O, but got Unknown
		//IL_2711: Unknown result type (might be due to invalid IL or missing references)
		//IL_271b: Expected O, but got Unknown
		//IL_29c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_29d3: Expected O, but got Unknown
		//IL_29ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_29f9: Expected O, but got Unknown
		//IL_2839: Unknown result type (might be due to invalid IL or missing references)
		//IL_2843: Expected O, but got Unknown
		//IL_25e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_25f3: Expected O, but got Unknown
		//IL_2961: Unknown result type (might be due to invalid IL or missing references)
		//IL_296b: Expected O, but got Unknown
		//IL_2a89: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a93: Expected O, but got Unknown
		Control control;
		F_DepthStepAdvanced f_DepthStepAdvanced = default(F_DepthStepAdvanced);
		F_RoundCorner f_RoundCorner = default(F_RoundCorner);
		while (true)
		{
			control = new Control();
			control = (Control)P_0;
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_ok)))
			{
				if (!PropertiesForm.Inited)
				{
					return;
				}
				if (PropertiesForm.ReadOnly)
				{
					goto IL_0076;
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
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0017)))
			{
				f_DepthStepAdvanced = new F_DepthStepAdvanced();
				f_DepthStepAdvanced.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
				global::_0086._007E_009E_0006(f_DepthStepAdvanced.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
				f_DepthStepAdvanced.buCamParameter = new camParameters5(buCamParameter);
				f_DepthStepAdvanced.Configration = new MWCalculationOptions(Configration);
				goto IL_0236;
			}
			goto IL_02c0;
			IL_1939:
			bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004));
			bool num = flag;
			goto IL_1962;
			IL_1fe3:
			_0095._007E_0096_000F(this._0004, global::_0003._007E_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
			goto IL_202e;
			IL_0284:
			global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_DepthStepAdvanced.mwCamParameter)));
			buCamParameter = new camParameters5(f_DepthStepAdvanced.buCamParameter);
			goto IL_02c0;
			IL_202e:
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0012)))
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
					if (false)
					{
						goto IL_1195;
					}
				}
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0011)))
			{
				F_MultiPass f_MultiPass = new F_MultiPass();
				f_MultiPass.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
				global::_0086._007E_009E_0006(f_MultiPass.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
				f_MultiPass.buCamParameter = new camParameters5(buCamParameter);
				f_MultiPass.Configration = new MWCalculationOptions(Configration);
				if (Tool != null)
				{
					f_MultiPass.Tool = new ToolBase5(f_MultiPass.Tool);
					if (false)
					{
						goto IL_18ee;
					}
				}
				f_MultiPass.Init();
				_009D_0003._007E_0091_0014(f_MultiPass);
				if (f_MultiPass.PropertiesForm.Result == DialogResult.OK)
				{
					global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_MultiPass.mwCamParameter)));
					buCamParameter = new camParameters5(f_MultiPass.buCamParameter);
				}
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0010)))
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
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000E)))
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
			if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0008)))
			{
				break;
			}
			f_RoundCorner = new F_RoundCorner();
			f_RoundCorner.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_RoundCorner.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_RoundCorner.buCamParameter = new camParameters5(buCamParameter);
			f_RoundCorner.Configration = new MWCalculationOptions(Configration);
			num = Tool != null;
			if (false)
			{
				goto IL_1962;
			}
			if (num)
			{
				f_RoundCorner.Tool = new ToolBase5(f_RoundCorner.Tool);
			}
			f_RoundCorner.Init();
			_009D_0003._007E_0091_0014(f_RoundCorner);
			bool flag2 = f_RoundCorner.PropertiesForm.Result == DialogResult.OK;
			bool num2 = flag2;
			goto IL_25ca;
			IL_1fce:
			_0097._007E_008E_0011(cmb_leadouttype, 13);
			goto IL_1fe3;
			IL_1243:
			bool num3;
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
			{
				global::_0005._0002._0001(this);
				F_LeadControl f_LeadControl = new F_LeadControl();
				f_LeadControl.mwCamLeadController = _0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))));
				f_LeadControl.buCamParameter = new camParameters5(buCamParameter);
				f_LeadControl.Configration = new MWCalculationOptions(Configration);
				if (Tool != null)
				{
					f_LeadControl.Tool = new ToolBase5(f_LeadControl.Tool);
				}
				f_LeadControl.Init();
				_009D_0003._007E_0091_0014(f_LeadControl);
				if (f_LeadControl.Properties.Result == DialogResult.OK)
				{
					_0014_0006._007E_008E_001C(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))), f_LeadControl.mwCamLeadController);
					buCamParameter = new camParameters5(f_LeadControl.buCamParameter);
					num3 = _0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialArc;
					goto IL_13b8;
				}
			}
			goto IL_1939;
			IL_13b8:
			if (num3)
			{
				_0097._007E_008E_0011(cmb_leadintype, 0);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangArc)
			{
				_0097._007E_008E_0011(cmb_leadintype, 1);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VerticalTangArc)
			{
				_0097._007E_008E_0011(cmb_leadintype, 2);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertTangArc)
			{
				_0097._007E_008E_0011(cmb_leadintype, 3);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.HorizontalTangArc)
			{
				_0097._007E_008E_0011(cmb_leadintype, 4);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalArc)
			{
				_0097._007E_008E_0011(cmb_leadintype, 5);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 6);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 7);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 8);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseOrthogonalLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 9);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VertProfileRamp)
			{
				_0097._007E_008E_0011(cmb_leadintype, 10);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertProfileRamp)
			{
				_0097._007E_008E_0011(cmb_leadintype, 11);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.PositionLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 12);
			}
			else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.SlantLine)
			{
				_0097._007E_008E_0011(cmb_leadintype, 13);
			}
			goto IL_18ee;
			IL_0076:
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				global::_0011._001C_0006(this);
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				_0095._0094_000F(this, false);
			}
			return;
			IL_25ca:
			if (num2)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_RoundCorner.mwCamParameter)));
				buCamParameter = new camParameters5(f_RoundCorner.buCamParameter);
			}
			break;
			IL_18ee:
			_0095._007E_0096_000F(this._0005, global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
			goto IL_1939;
			IL_1195:
			F_HeightAdvanced f_HeightAdvanced;
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
			goto IL_1243;
			IL_0236:
			if (Tool != null)
			{
				f_DepthStepAdvanced.Tool = new ToolBase5(f_DepthStepAdvanced.Tool);
			}
			f_DepthStepAdvanced.Init();
			_009D_0003._007E_0091_0014(f_DepthStepAdvanced);
			if (f_DepthStepAdvanced.PropertiesForm.Result == DialogResult.OK)
			{
				goto IL_0284;
			}
			goto IL_02c0;
			IL_1962:
			if (num)
			{
				F_LeadControl f_LeadControl2 = new F_LeadControl();
				f_LeadControl2.mwCamLeadController = _0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))));
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
					_0014_0006._007E_008F_001C(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))), f_LeadControl2.mwCamLeadController);
					buCamParameter = new camParameters5(f_LeadControl2.buCamParameter);
					if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialArc)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 0);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangArc)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 1);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VerticalTangArc)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 2);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertTangArc)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 3);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.HorizontalTangArc)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 4);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalArc)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 5);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialLine)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 6);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangLine)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 7);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalLine)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 8);
						if (6 == 0)
						{
							goto IL_0076;
						}
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseOrthogonalLine)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 9);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VertProfileRamp)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 10);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertProfileRamp)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 11);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.PositionLine)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 12);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.SlantLine)
					{
						goto IL_1fce;
					}
					goto IL_1fe3;
				}
			}
			goto IL_202e;
			IL_02c0:
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0016)))
			{
				if (4 == 0)
				{
					goto IL_1fce;
				}
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
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
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
					if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialArc)
					{
						_0097._007E_008E_0011(cmb_leadintype, 0);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangArc)
					{
						_0097._007E_008E_0011(cmb_leadintype, 1);
					}
					else
					{
						bool flag3 = _0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VerticalTangArc;
						num3 = flag3;
						if (false)
						{
							goto IL_13b8;
						}
						if (num3)
						{
							_0097._007E_008E_0011(cmb_leadintype, 2);
						}
						else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertTangArc)
						{
							_0097._007E_008E_0011(cmb_leadintype, 3);
						}
						else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.HorizontalTangArc)
						{
							_0097._007E_008E_0011(cmb_leadintype, 4);
						}
						else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalArc)
						{
							_0097._007E_008E_0011(cmb_leadintype, 5);
						}
						else
						{
							bool flag4 = _0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialLine;
							if (3 == 0)
							{
								goto IL_0284;
							}
							if (flag4)
							{
								_0097._007E_008E_0011(cmb_leadintype, 6);
							}
							else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangLine)
							{
								_0097._007E_008E_0011(cmb_leadintype, 7);
							}
							else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalLine)
							{
								_0097._007E_008E_0011(cmb_leadintype, 8);
							}
							else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseOrthogonalLine)
							{
								_0097._007E_008E_0011(cmb_leadintype, 9);
							}
							else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VertProfileRamp)
							{
								_0097._007E_008E_0011(cmb_leadintype, 10);
							}
							else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertProfileRamp)
							{
								_0097._007E_008E_0011(cmb_leadintype, 11);
							}
							else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.SlantLine)
							{
								_0097._007E_008E_0011(cmb_leadintype, 12);
							}
						}
					}
					_0095._007E_0096_000F(this._0005, global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
					if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialArc)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 0);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangArc)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 1);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VerticalTangArc)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 2);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertTangArc)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 3);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.HorizontalTangArc)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 4);
						if (false)
						{
							goto IL_0236;
						}
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalArc)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 5);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialLine)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 6);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangLine)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 7);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalLine)
					{
						_0097._007E_008E_0011(cmb_leadouttype, 8);
					}
					else
					{
						bool flag5 = _0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseOrthogonalLine;
						num2 = flag5;
						if (5 == 0)
						{
							goto IL_25ca;
						}
						if (num2)
						{
							_0097._007E_008E_0011(cmb_leadouttype, 9);
						}
						else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VertProfileRamp)
						{
							_0097._007E_008E_0011(cmb_leadouttype, 10);
						}
						else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertProfileRamp)
						{
							_0097._007E_008E_0011(cmb_leadouttype, 11);
						}
						else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.SlantLine)
						{
							_0097._007E_008E_0011(cmb_leadouttype, 12);
						}
					}
					_0095._007E_0096_000F(this._0004, global::_0003._007E_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
				}
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
			{
				if (-1 == 0)
				{
					continue;
				}
				f_HeightAdvanced = new F_HeightAdvanced();
				f_HeightAdvanced.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
				global::_0086._007E_009E_0006(f_HeightAdvanced.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
				goto IL_1195;
			}
			goto IL_1243;
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0007)))
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0014)))
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0013)))
		{
			F_FeedAdvanced f_FeedAdvanced = new F_FeedAdvanced();
			f_FeedAdvanced.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_FeedAdvanced.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_FeedAdvanced.buCamParameter = new camParameters5(buCamParameter);
			f_FeedAdvanced.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_FeedAdvanced.Tool = new ToolBase5(f_FeedAdvanced.Tool);
			}
			f_FeedAdvanced.Init();
			_009D_0003._007E_0091_0014(f_FeedAdvanced);
			if (f_FeedAdvanced.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_FeedAdvanced.mwCamParameter)));
				buCamParameter = new camParameters5(f_FeedAdvanced.buCamParameter);
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
		ControlUpdate();
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			if (global::_000E._007E_000E_0006(this._0004) == 0)
			{
				goto IL_0089;
			}
			if (global::_000E._007E_000E_0006(this._0004) == 1)
			{
				if (false)
				{
					return;
				}
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0087_0018());
			}
			else if (global::_000E._007E_000E_0006(this._0004) != 2)
			{
			}
		}
		goto IL_0101;
		IL_0101:
		while (true)
		{
			int num;
			int num2;
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_leadintype)))
			{
				if (global::_000E._007E_000E_0006(cmb_leadintype) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0018());
				}
				else
				{
					if (global::_000E._007E_000E_0006(cmb_leadintype) == 2)
					{
						goto IL_01bf;
					}
					if (global::_000E._007E_000E_0006(cmb_leadintype) == 3)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
					}
					else
					{
						if (false)
						{
							continue;
						}
						if (global::_000E._007E_000E_0006(cmb_leadintype) == 4)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
						}
						else if (global::_000E._007E_000E_0006(cmb_leadintype) == 5)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
						}
						else
						{
							if (false)
							{
								goto IL_0501;
							}
							if (global::_000E._007E_000E_0006(cmb_leadintype) == 6)
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
							else
							{
								if (global::_000E._007E_000E_0006(cmb_leadintype) != 9)
								{
									num = global::_000E._007E_000E_0006(cmb_leadintype);
									num2 = 10;
									goto IL_039d;
								}
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
							}
						}
					}
				}
			}
			goto IL_0477;
			IL_05e4:
			int num3;
			int num4;
			if (num3 == num4)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
				return;
			}
			num = global::_000E._007E_000E_0006(cmb_leadouttype);
			num2 = 6;
			if (num2 == 0)
			{
				goto IL_039d;
			}
			if (num == num2)
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
			if (global::_000E._007E_000E_0006(cmb_leadouttype) == 10)
			{
				break;
			}
			if (global::_000E._007E_000E_0006(cmb_leadouttype) == 11)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
				return;
			}
			if (global::_000E._007E_000E_0006(cmb_leadouttype) == 12)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0018());
				return;
			}
			num3 = global::_000E._007E_000E_0006(cmb_leadouttype);
			num4 = 13;
			goto IL_07c7;
			IL_039d:
			if (num == num2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 11)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 12)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 13)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0018());
				if (false)
				{
				}
			}
			goto IL_0477;
			IL_07c7:
			if (num4 != 0)
			{
				bool flag = num3 == num4;
				if (0 == 0)
				{
					if (flag)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0018());
					}
					return;
				}
				goto IL_01bf;
			}
			goto IL_05e4;
			IL_0501:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0018());
			return;
			IL_0477:
			if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_leadouttype)))
			{
				return;
			}
			if (global::_000E._007E_000E_0006(cmb_leadouttype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
				return;
			}
			num3 = global::_000E._007E_000E_0006(cmb_leadouttype);
			num4 = 1;
			if (num4 != 0)
			{
				if (num3 == num4)
				{
					goto IL_0501;
				}
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0018());
					return;
				}
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 3)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
					return;
				}
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 4)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
					return;
				}
				num3 = global::_000E._007E_000E_0006(cmb_leadouttype);
				num4 = 5;
				goto IL_05e4;
			}
			goto IL_07c7;
			IL_01bf:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0018());
			goto IL_0477;
		}
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0018());
		if (0 == 0)
		{
			return;
		}
		goto IL_0089;
		IL_0089:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._0086_0018());
		goto IL_0101;
	}

	internal void _0006(object P_0, EventArgs P_1)
	{
		Control control;
		int num;
		int num2;
		if (0 == 0)
		{
			control = new Control();
			control = (Control)P_0;
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0012)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0095_0018());
				if (0 == 0)
				{
					goto IL_0073;
				}
				goto IL_0e18;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
			{
				if (global::_000E._007E_000E_0006(this._0004) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0086_0018());
					goto IL_011d;
				}
				num = global::_000E._007E_000E_0006(this._0004);
				num2 = 1;
				goto IL_017c;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0018());
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
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0096_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView2 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView2);
					_0086_0003._007E_0018_0014(f_GifView2, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView2);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001D_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView3 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView3);
					_0086_0003._007E_0018_0014(f_GifView3, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView3);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001E_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView4 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView4);
					_0086_0003._007E_0018_0014(f_GifView4, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView4);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000F)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0097_0018());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001F_0018());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0097_0018());
			}
			else
			{
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000E)))
				{
					goto IL_056d;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0008)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0080_0018());
				}
				else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0007)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0098_0018());
				}
				else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0081_0018());
				}
				else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
				{
					if (global::_0003._007E_001C(this._0001))
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0082_0018());
					}
					else
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_0018());
					}
				}
				else
				{
					if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
					{
						goto IL_0726;
					}
					if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_0018());
					}
					else
					{
						if (false)
						{
							goto IL_011d;
						}
						if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
						{
							if (2 == 0)
							{
								goto IL_0726;
							}
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0099_0018());
							if (global::_0003._007E_0083(this._0002))
							{
								F_GifView f_GifView5 = new F_GifView();
								global::_0011._007E_0084_0006(f_GifView5);
								_0086_0003._007E_0018_0014(f_GifView5, FormStartPosition.CenterParent);
								_009D_0003._007E_0091_0014(f_GifView5);
							}
						}
						else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._009A_0018());
							if (global::_0003._007E_0083(this._0002))
							{
								F_GifView f_GifView6 = new F_GifView();
								global::_0011._007E_0084_0006(f_GifView6);
								_0086_0003._007E_0018_0014(f_GifView6, FormStartPosition.CenterParent);
								_009D_0003._007E_0091_0014(f_GifView6);
							}
						}
					}
				}
			}
			goto IL_08c3;
		}
		goto IL_15c3;
		IL_0f40:
		while (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_leadouttype)))
		{
			if (global::_000E._007E_000E_0006(cmb_leadouttype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView7 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView7);
					_0086_0003._007E_0018_0014(f_GifView7, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView7);
				}
				break;
			}
			if (global::_000E._007E_000E_0006(cmb_leadouttype) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView8 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView8);
					_0086_0003._007E_0018_0014(f_GifView8, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView8);
				}
				break;
			}
			if (global::_000E._007E_000E_0006(cmb_leadouttype) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView9 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView9);
					_0086_0003._007E_0018_0014(f_GifView9, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView9);
				}
				break;
			}
			if (global::_000E._007E_000E_0006(cmb_leadouttype) == 3)
			{
				goto IL_110e;
			}
			if (global::_000E._007E_000E_0006(cmb_leadouttype) == 4)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView10 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView10);
					_0086_0003._007E_0018_0014(f_GifView10, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView10);
				}
				break;
			}
			if (global::_000E._007E_000E_0006(cmb_leadouttype) == 5)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView11 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView11);
					_0086_0003._007E_0018_0014(f_GifView11, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView11);
				}
				if (false)
				{
					continue;
				}
				break;
			}
			goto IL_1287;
		}
		goto IL_15c3;
		IL_08c3:
		F_GifView f_GifView15 = default(F_GifView);
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_leadintype)))
		{
			if (global::_000E._007E_000E_0006(cmb_leadintype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView12 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView12);
					_0086_0003._007E_0018_0014(f_GifView12, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView12);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView13 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView13);
					_0086_0003._007E_0018_0014(f_GifView13, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView13);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView14 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView14);
					_0086_0003._007E_0018_0014(f_GifView14, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView14);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 3)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					f_GifView15 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView15);
					goto IL_0ad7;
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 4)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView16 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView16);
					_0086_0003._007E_0018_0014(f_GifView16, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView16);
				}
			}
			else
			{
				num = global::_000E._007E_000E_0006(cmb_leadintype);
				num2 = 5;
				if (num2 == 0)
				{
					goto IL_017c;
				}
				if (num == num2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView17 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView17);
						_0086_0003._007E_0018_0014(f_GifView17, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView17);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 6)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView18 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView18);
						_0086_0003._007E_0018_0014(f_GifView18, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView18);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 7)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView19 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView19);
						if (3 == 0)
						{
							goto IL_0073;
						}
						_0086_0003._007E_0018_0014(f_GifView19, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView19);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 8)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView20 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView20);
						_0086_0003._007E_0018_0014(f_GifView20, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView20);
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
						goto IL_0e18;
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 11)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView21 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView21);
						_0086_0003._007E_0018_0014(f_GifView21, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView21);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 12)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0018());
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 13)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0018());
				}
			}
		}
		goto IL_0f40;
		IL_056d:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._007F_0018());
		goto IL_08c3;
		IL_1287:
		if (global::_000E._007E_000E_0006(cmb_leadouttype) == 6)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView22 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView22);
				_0086_0003._007E_0018_0014(f_GifView22, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView22);
			}
		}
		else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 7)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView23 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView23);
				_0086_0003._007E_0018_0014(f_GifView23, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView23);
			}
		}
		else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 8)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView24 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView24);
				_0086_0003._007E_0018_0014(f_GifView24, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView24);
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
				F_GifView f_GifView25 = new F_GifView();
				if (5 == 0)
				{
					goto IL_0ad7;
				}
				global::_0011._007E_0084_0006(f_GifView25);
				_0086_0003._007E_0018_0014(f_GifView25, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView25);
			}
		}
		else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 11)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView26 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView26);
				_0086_0003._007E_0018_0014(f_GifView26, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView26);
			}
		}
		else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 12)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0018());
		}
		else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 13)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0018());
		}
		goto IL_15c3;
		IL_15c3:
		_0095._007E_0096_000F(this._0002, false);
		return;
		IL_110e:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
		if (global::_0003._007E_0083(this._0002))
		{
			F_GifView f_GifView27 = new F_GifView();
			global::_0011._007E_0084_0006(f_GifView27);
			if (false)
			{
				goto IL_056d;
			}
			_0086_0003._007E_0018_0014(f_GifView27, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView27);
		}
		goto IL_15c3;
		IL_0ad7:
		_0086_0003._007E_0018_0014(f_GifView15, FormStartPosition.CenterParent);
		_009D_0003._007E_0091_0014(f_GifView15);
		goto IL_0f40;
		IL_011d:
		if (global::_0003._007E_0083(this._0002))
		{
			F_GifView f_GifView28 = new F_GifView();
			global::_0011._007E_0084_0006(f_GifView28);
			_0086_0003._007E_0018_0014(f_GifView28, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView28);
		}
		goto IL_08c3;
		IL_017c:
		if (num == num2)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0087_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView29 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView29);
				_0086_0003._007E_0018_0014(f_GifView29, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView29);
			}
		}
		else if (global::_000E._007E_000E_0006(this._0004) != 2)
		{
		}
		goto IL_08c3;
		IL_0073:
		if (global::_0003._007E_0083(this._0002))
		{
			F_GifView f_GifView30 = new F_GifView();
			global::_0011._007E_0084_0006(f_GifView30);
			_0086_0003._007E_0018_0014(f_GifView30, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView30);
		}
		goto IL_08c3;
		IL_0726:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._0082_0018());
		goto IL_08c3;
		IL_0e18:
		F_GifView f_GifView31 = new F_GifView();
		global::_0011._007E_0084_0006(f_GifView31);
		_0086_0003._007E_0018_0014(f_GifView31, FormStartPosition.CenterParent);
		_009D_0003._007E_0091_0014(f_GifView31);
		goto IL_0f40;
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
