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
using buEyeBaseVer5.Forms;

namespace buMW.CamForms;

public class F_WFContour4AX : Form
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

	internal Label _0005;

	internal Label _0006;

	internal NumericUpDown _0004;

	internal NumericUpDown _0005;

	internal NumericUpDown _0006;

	internal Label _0007;

	internal ComboBox _0002;

	internal Label _0008;

	internal Panel _0002;

	internal Button _0001;

	internal NumericUpDown _0007;

	internal Label _000E;

	internal Panel _0003;

	internal Panel _0004;

	internal Button _0002;

	internal NumericUpDown _0008;

	internal NumericUpDown _000E;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Label _000F;

	internal NumericUpDown _000F;

	internal RadioButton _0003;

	internal RadioButton _0004;

	internal RadioButton _0005;

	internal RadioButton _0006;

	internal NumericUpDown _0010;

	internal Label _0010;

	internal Panel _0005;

	internal ComboBox _0003;

	internal Label _0011;

	internal Panel _0006;

	internal Label _0012;

	internal Label _0013;

	internal Label _0014;

	internal Panel _0007;

	internal Label _0015;

	internal Label _0016;

	internal Label _0017;

	internal Panel _0008;

	internal Button _0003;

	internal Label _0018;

	internal NumericUpDown _0011;

	internal Label _0019;

	internal Label _001A;

	internal Label _001B;

	internal NumericUpDown _0012;

	internal Label _001C;

	internal NumericUpDown _0013;

	internal NumericUpDown _0014;

	internal PictureBox _0001;

	internal ImageList _0002;

	internal CheckBox _0002;

	internal Panel _000E;

	internal Label _001D;

	internal CheckBox _0003;

	internal Panel _000F;

	internal Button _0004;

	internal Label _001E;

	public ComboBox cmb_leadouttype;

	internal Label _001F;

	internal CheckBox _0004;

	internal Button _0005;

	internal Label _007F;

	public ComboBox cmb_leadintype;

	internal Panel _0010;

	internal CheckBox _0005;

	internal Label _0080;

	internal Panel _0011;

	internal CheckBox _0006;

	internal Label _0081;

	internal Panel _0012;

	internal Label _0082;

	internal Label _0083;

	internal NumericUpDown _0015;

	internal NumericUpDown _0016;

	internal CheckBox _0007;

	internal Panel _0013;

	internal Label _0084;

	internal NumericUpDown _0017;

	internal Label _0086;

	internal CheckBox _0008;

	internal Label _0087;

	internal ComboBox _0004;

	internal Button _0006;

	internal Panel _0014;

	internal Button _0007;

	internal CheckBox _000E;

	internal Label _0088;

	internal Button _0008;

	internal Button _000E;

	internal Panel _0015;

	internal Button _000F;

	internal Button _0010;

	internal CheckBox _000F;

	internal Label _0089;

	internal Panel _0016;

	internal Button _0011;

	internal CheckBox _0010;

	internal Label _008A;

	internal Panel _0017;

	internal CheckBox _0011;

	internal Label _008B;

	internal Button _0012;

	internal CheckBox _0012;

	internal Label _008C;

	internal CheckBox _0013;

	internal Panel _0018;

	internal PictureBox _0002;

	internal Label _008D;

	internal NumericUpDown _0018;

	internal NumericUpDown _0019;

	internal Label _008E;

	internal Label _008F;

	internal Label _0090;

	internal NumericUpDown _001A;

	internal Label _0091;

	internal NumericUpDown _001B;

	internal NumericUpDown _001C;

	internal CheckBox _0014;

	internal RadioButton _0007;

	internal RadioButton _0008;

	internal Panel _0019;

	internal Button _0013;

	internal Button _0014;

	internal CheckBox _0015;

	internal Label _0092;

	internal Button _0015;

	public F_WFContour4AX()
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
		_0088_0003._007E_001A_0014(this._000E, _0087_0003._0019_0014(global::_0007._007E_007F_0003(global::_008E._007E_0010_0007(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))))));
		_0088_0003._007E_001A_0014(this._0008, _0004_0004._0097_0014(global::_000E._007E_009F_0005(global::_008E._007E_0010_0007(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))))));
		_0088_0003._007E_001A_0014(this._0007, _0087_0003._0019_0014(global::_0007._007E_0083_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0017_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0018_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0019_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0012, _0087_0003._0019_0014(global::_0007._007E_001E_0003(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0013, _0087_0003._0019_0014(global::_0007._007E_001D_0003(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0014, _0087_0003._0019_0014(global::_0007._007E_001C_0003(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0011, _0087_0003._0019_0014(global::_0007._007E_001B_0003(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(buCamParameter.Steps.EndValue));
		_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(buCamParameter.Steps.StartValue));
		_0088_0003._007E_001A_0014(this._000F, _0087_0003._0019_0014(buCamParameter.Operations.Height));
		_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_0082_0003(global::_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0010, _0087_0003._0019_0014(buCamParameter.Speeds.SpindleSpeed));
		_0088_0003._007E_001A_0014(this._0017, _0087_0003._0019_0014(global::_0007._007E_001E_0004(_001A_0002._007E_0083_0012(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))))));
		_0088_0003._007E_001A_0014(_001C, _0087_0003._0019_0014(buCamParameter.Strategy.AngleLimit));
		_0088_0003._007E_001A_0014(this._0019, _0087_0003._0019_0014(buCamParameter.Strategy.ContantTangent));
		_0088_0003._007E_001A_0014(_001A, _0087_0003._0019_0014(buCamParameter.Strategy.MaxTangentValue));
		_0088_0003._007E_001A_0014(_001B, _0087_0003._0019_0014(buCamParameter.Strategy.MinTangentValue));
		_0088_0003._007E_001A_0014(_0018, _0087_0003._0019_0014(buCamParameter.Strategy.TangentOffset));
		if (buCamParameter.Strategy.UseContantTangent)
		{
			_0095._007E_0093_000F(_0008, true);
			_0095._007E_0093_000F(_0007, false);
		}
		else
		{
			_0095._007E_0093_000F(_0008, false);
			_0095._007E_0093_000F(_0007, true);
		}
		_0095._007E_0096_000F(this._0014, buCamParameter.Strategy.UseTangentLimit);
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0007(global::_0084._007E_009D_0006(mwCamParameter)));
		_0095._007E_0096_000F(this._0007, global::_0003._007E_0006(global::_0084._007E_009D_0006(mwCamParameter)));
		_0095._007E_0096_000F(this._0008, buCamParameter.Offsets.AddToolDiameterAsOffset);
		_0095._007E_0096_000F(this._0013, buCamParameter.Strategy.StartFromAnyPoint);
		if (!buCamParameter.Operations.isClosed)
		{
			global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0001));
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.CamOpenContourType[0]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.CamOpenContourType[1]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.CamOpenContourType[2]);
			if (_0093._007E_0017_0007(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft)
			{
				_0097._007E_008E_0011(this._0001, 0);
			}
			else if (_0093._007E_0017_0007(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == WireframeBasedTpCalcParamsCuttingSide.WfbCsRight)
			{
				_0097._007E_008E_0011(this._0001, 2);
			}
			else
			{
				_0097._007E_008E_0011(this._0001, 1);
			}
			if (_000F_0006._007E_0089_001C(_0082_0005._007E_008B_0016(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter))))) == CutterRadiusCompParamsCompensationType.CtOff)
			{
				_0097._007E_008E_0011(this._0001, 1);
			}
		}
		else
		{
			global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0001));
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.CamClosedContourType[0]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.CamClosedContourType[1]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.CamClosedContourType[2]);
			if (buCamParameter.Offsets.ClosedContour == CamClosedContourType.Inner)
			{
				_0097._007E_008E_0011(this._0001, 0);
			}
			else if (buCamParameter.Offsets.ClosedContour == CamClosedContourType.Outter)
			{
				_0097._007E_008E_0011(this._0001, 2);
			}
			else
			{
				_0097._007E_008E_0011(this._0001, 1);
			}
			if (_000F_0006._007E_0089_001C(_0082_0005._007E_008B_0016(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter))))) == CutterRadiusCompParamsCompensationType.CtOff)
			{
				_0097._007E_008E_0011(this._0001, 1);
			}
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
		else
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
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0004));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0004), buMWCaptions.ClockDirectionType[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0004), buMWCaptions.ClockDirectionType[1]);
		if (buCamParameter.Operations.Direction == ClockDirectionType.CW)
		{
			_0097._007E_008E_0011(this._0004, 0);
		}
		else if (buCamParameter.Operations.Direction == ClockDirectionType.CCW)
		{
			_0097._007E_008E_0011(this._0004, 1);
		}
		if (global::_008F._007E_0012_0007(global::_008E._007E_0010_0007(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
		{
			_0095._007E_0093_000F(this._0002, true);
			_0095._007E_0093_000F(this._0001, false);
		}
		else
		{
			_0095._007E_0093_000F(this._0002, false);
			_0095._007E_0093_000F(this._0001, true);
		}
		if (!buCamParameter.Steps.Enable)
		{
			_0095._007E_0093_000F(this._0003, true);
			_0095._007E_0093_000F(this._0004, false);
		}
		else
		{
			_0095._007E_0093_000F(this._0003, false);
			_0095._007E_0093_000F(this._0004, true);
		}
		if (buCamParameter.Speeds.SpindleDirection == ClockDirectionType.CW)
		{
			_0095._007E_0093_000F(this._0006, true);
			_0095._007E_0093_000F(this._0005, false);
		}
		else
		{
			_0095._007E_0093_000F(this._0006, false);
			_0095._007E_0093_000F(this._0005, true);
		}
		_0095._007E_0096_000F(this._0003, global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
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
		_0095._007E_0096_000F(this._0004, global::_0003._007E_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
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
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.PositionLine)
		{
			_0097._007E_008E_0011(cmb_leadouttype, 12);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.SlantLine)
		{
			_0097._007E_008E_0011(cmb_leadouttype, 13);
		}
		_0095._007E_0096_000F(this._0004, global::_0003._007E_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
		_0095._007E_0096_000F(this._0005, global::_0003._007E_009F_0002(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(this._000E, global::_0003._007E_0008_0002(_001C_0004._007E_0015_0015(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
		_0095._007E_0096_000F(this._0006, global::_0003._007E_0001_0003(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(_0010, global::_0003._007E_0002_0003(global::_0084._007E_009D_0006(mwCamParameter)));
		_0095._007E_0096_000F(_0011, global::_0003._007E_009E_0002(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(global::_0084._007E_009D_0006(mwCamParameter)))));
		Configration.Mode = CamMode.WireFrame;
		Configration.CamWireframeType = CamWireFrameType.Contour;
		if (!buCamParameter.Operations.isClosed)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0007_001A());
			_0015_0005._001C_0016(this, _0015_0006._0092_001C());
		}
		else
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0008_001A());
			_0015_0005._001C_0016(this, _0015_0006._0093_001C());
		}
		if (!Configration.ShowOptionPage)
		{
			_0097._007E_0099_0011(_0016_0006._007E_0094_001C(this._0001), 3);
		}
		if (!Configration.ShowLeadInOutPage)
		{
			_0097._007E_0099_0011(_0016_0006._007E_0094_001C(this._0001), 2);
		}
		global::_0011._007E_0086_0006(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		global::_0005._0002._0001(this);
		ControlUpdate();
	}

	public void ControlUpdate()
	{
		if (!buCamParameter.Operations.isClosed)
		{
			_0095._007E_0094_000F(_0087, false);
			_0095._007E_0094_000F(this._0004, false);
			_0095 obj = _0095._007E_0094_000F;
			Label label = _0084;
			if (0 == 0)
			{
				obj(label, false);
			}
			_0095._007E_0094_000F(this._0017, false);
		}
		else
		{
			_0095._007E_0094_000F(_0087, true);
			_0095._007E_0094_000F(this._0004, true);
			_0095._007E_0094_000F(_0084, true);
			_0095._007E_0094_000F(this._0017, true);
		}
		_0095._007E_0095_000F(this._0008, global::_0003._007E_0083(this._0005));
		_0095._007E_0095_000F(this._0007, global::_0003._007E_0083(this._000E));
		_0095._007E_0095_000F(_000E, global::_0003._007E_0083(this._0006));
		_0095._007E_0095_000F(this._0010, global::_0003._007E_0083(_000F));
		_0095._007E_0095_000F(this._000F, global::_0003._007E_0083(_000F));
		_0095._007E_0095_000F(this._0011, global::_0003._007E_0083(_0010));
		_0095._007E_0095_000F(this._0012, global::_0003._007E_0083(_0011));
		_0095._007E_0095_000F(this._0016, global::_0003._007E_0083(this._0007));
		if (global::_0003._007E_001C(this._0003))
		{
			_0095._007E_0095_000F(this._0005, true);
			_0095._007E_0095_000F(this._0004, false);
		}
		else
		{
			if (4 == 0)
			{
				goto IL_024b;
			}
			_0095._007E_0095_000F(this._0005, false);
			_0095._007E_0095_000F(this._0004, true);
		}
		if (global::_0003._007E_001C(this._0002))
		{
			goto IL_024b;
		}
		_0095._007E_0095_000F(this._000E, false);
		_0095._007E_0095_000F(this._0008, true);
		goto IL_0299;
		IL_024b:
		_0095._007E_0095_000F(this._000E, true);
		_0095._007E_0095_000F(this._0008, false);
		goto IL_0299;
		IL_0299:
		_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(this._0003));
		_0095._007E_0095_000F(cmb_leadintype, global::_0003._007E_0083(this._0003));
		_0095._007E_0095_000F(_007F, global::_0003._007E_0083(this._0003));
		_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0004));
		_0095._007E_0095_000F(cmb_leadouttype, global::_0003._007E_0083(this._0004));
		_0095._007E_0095_000F(_001E, global::_0003._007E_0083(this._0004));
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected O, but got Unknown
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Expected O, but got Unknown
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected O, but got Unknown
		//IL_1027: Unknown result type (might be due to invalid IL or missing references)
		//IL_1031: Expected O, but got Unknown
		//IL_104d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1057: Expected O, but got Unknown
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected O, but got Unknown
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Expected O, but got Unknown
		//IL_10b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10bb: Expected O, but got Unknown
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Expected O, but got Unknown
		//IL_22ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_22f8: Expected O, but got Unknown
		//IL_1eb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eba: Expected O, but got Unknown
		//IL_1ed6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ee0: Expected O, but got Unknown
		//IL_2356: Unknown result type (might be due to invalid IL or missing references)
		//IL_2360: Expected O, but got Unknown
		//IL_237c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2386: Expected O, but got Unknown
		//IL_1fd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe2: Expected O, but got Unknown
		//IL_1ffe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2008: Expected O, but got Unknown
		//IL_247e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2488: Expected O, but got Unknown
		//IL_24a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ae: Expected O, but got Unknown
		//IL_2106: Unknown result type (might be due to invalid IL or missing references)
		//IL_2110: Expected O, but got Unknown
		//IL_212c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2136: Expected O, but got Unknown
		//IL_1f70: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f7a: Expected O, but got Unknown
		//IL_25a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_25b0: Expected O, but got Unknown
		//IL_25cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_25d6: Expected O, but got Unknown
		//IL_2416: Unknown result type (might be due to invalid IL or missing references)
		//IL_2420: Expected O, but got Unknown
		//IL_222e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2238: Expected O, but got Unknown
		//IL_2254: Unknown result type (might be due to invalid IL or missing references)
		//IL_225e: Expected O, but got Unknown
		//IL_2098: Unknown result type (might be due to invalid IL or missing references)
		//IL_20a2: Expected O, but got Unknown
		//IL_253e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2548: Expected O, but got Unknown
		//IL_21c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d0: Expected O, but got Unknown
		//IL_2666: Unknown result type (might be due to invalid IL or missing references)
		//IL_2670: Expected O, but got Unknown
		Control control = new Control();
		control = (Control)P_0;
		bool num;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_ok)))
		{
			num = PropertiesForm.Inited;
			goto IL_005a;
		}
		goto IL_011a;
		IL_1e1c:
		_0095._007E_0096_000F(this._0004, global::_0003._007E_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
		goto IL_1e67;
		IL_005a:
		if (!num)
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
		goto IL_011a;
		IL_1e67:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0012)))
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0007)))
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
				if (false)
				{
					goto IL_0fde;
				}
				buCamParameter = new camParameters5(f_RestFinish.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000F)))
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
		F_SharpCorner f_SharpCorner;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0008)))
		{
			f_SharpCorner = new F_SharpCorner();
			f_SharpCorner.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_SharpCorner.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_SharpCorner.buCamParameter = new camParameters5(buCamParameter);
			goto IL_2271;
		}
		goto IL_230d;
		IL_1757:
		_0095._007E_0096_000F(this._0003, global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
		goto IL_17a2;
		IL_230d:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_000E)))
		{
			F_Tabs f_Tabs = new F_Tabs();
			f_Tabs.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_Tabs.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_Tabs.buCamParameter = new camParameters5(buCamParameter);
			f_Tabs.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_Tabs.Tool = new ToolBase5(f_Tabs.Tool);
			}
			f_Tabs.Init();
			_009D_0003._007E_0091_0014(f_Tabs);
			if (f_Tabs.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_Tabs.mwCamParameter)));
				buCamParameter = new camParameters5(f_Tabs.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0011)))
		{
			F_ExtendTrim f_ExtendTrim = new F_ExtendTrim();
			f_ExtendTrim.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_ExtendTrim.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_ExtendTrim.buCamParameter = new camParameters5(buCamParameter);
			f_ExtendTrim.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_ExtendTrim.Tool = new ToolBase5(f_ExtendTrim.Tool);
			}
			f_ExtendTrim.Init();
			_009D_0003._007E_0091_0014(f_ExtendTrim);
			if (f_ExtendTrim.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_ExtendTrim.mwCamParameter)));
				buCamParameter = new camParameters5(f_ExtendTrim.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0013)))
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
		return;
		IL_2271:
		f_SharpCorner.Configration = new MWCalculationOptions(Configration);
		if (Tool != null)
		{
			f_SharpCorner.Tool = new ToolBase5(f_SharpCorner.Tool);
		}
		f_SharpCorner.Init();
		_009D_0003._007E_0091_0014(f_SharpCorner);
		if (f_SharpCorner.PropertiesForm.Result == DialogResult.OK)
		{
			global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_SharpCorner.mwCamParameter)));
			buCamParameter = new camParameters5(f_SharpCorner.buCamParameter);
		}
		goto IL_230d;
		IL_17a2:
		bool num2;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			F_LeadControl f_LeadControl = new F_LeadControl();
			f_LeadControl.mwCamLeadController = _0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))));
			f_LeadControl.buCamParameter = new camParameters5(buCamParameter);
			f_LeadControl.Init();
			_009D_0003._007E_0091_0014(f_LeadControl);
			if (f_LeadControl.Properties.Result == DialogResult.OK)
			{
				_0014_0006._007E_008F_001C(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))), f_LeadControl.mwCamLeadController);
				if (0 == 0)
				{
					buCamParameter = new camParameters5(f_LeadControl.buCamParameter);
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
					else
					{
						if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) != LeadParamsType.ReverseTangLine)
						{
							if (7 == 0)
							{
								goto IL_025a;
							}
							num2 = _0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalLine;
							goto IL_1c07;
						}
						_0097._007E_008E_0011(cmb_leadouttype, 7);
					}
				}
				goto IL_1e1c;
			}
		}
		goto IL_1e67;
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0015)))
		{
			F_SortingSettings f_SortingSettings = new F_SortingSettings();
			f_SortingSettings.SortSetting = new SortSettings(buCamParameter.Sorting);
			global::_0011._007E_0087_0006(f_SortingSettings);
			_009D_0003._007E_0091_0014(f_SortingSettings);
			if (f_SortingSettings.PropertiesForm.Result == DialogResult.OK)
			{
				buCamParameter.Sorting = new SortSettings(f_SortingSettings.SortSetting);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			goto IL_025a;
		}
		goto IL_0323;
		IL_0323:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			F_SurfaceQuality f_SurfaceQuality = new F_SurfaceQuality();
			f_SurfaceQuality.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_SurfaceQuality.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_SurfaceQuality.buCamParameter = new camParameters5(buCamParameter);
			if (false)
			{
				goto IL_1e1c;
			}
			f_SurfaceQuality.Init();
			_009D_0003._007E_0091_0014(f_SurfaceQuality);
			if (f_SurfaceQuality.Properties.Result == DialogResult.OK)
			{
				if (2 == 0)
				{
					goto IL_0a35;
				}
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_SurfaceQuality.mwCamParameter)));
				buCamParameter = new camParameters5(f_SurfaceQuality.buCamParameter);
			}
		}
		bool num3;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
		{
			F_ContourLink f_ContourLink = new F_ContourLink();
			f_ContourLink.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_ContourLink.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_ContourLink.buCamParameter = new camParameters5(buCamParameter);
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
				else
				{
					num3 = _0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VerticalTangArc;
					if (false)
					{
						goto IL_166d;
					}
					if (num3)
					{
						_0097._007E_008E_0011(cmb_leadintype, 2);
					}
					else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertTangArc)
					{
						_0097._007E_008E_0011(cmb_leadintype, 3);
					}
					else
					{
						if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) != LeadParamsType.HorizontalTangArc)
						{
							goto IL_070f;
						}
						_0097._007E_008E_0011(cmb_leadintype, 4);
					}
				}
				goto IL_0a35;
			}
		}
		goto IL_0fde;
		IL_0d82:
		bool flag;
		if (flag)
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
		goto IL_0f93;
		IL_166d:
		if (num3)
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
			if (false)
			{
				goto IL_0d82;
			}
		}
		goto IL_1757;
		IL_0a35:
		_0095._007E_0096_000F(this._0003, global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
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
		else
		{
			if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) != LeadParamsType.TangentialLine)
			{
				flag = _0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseTangLine;
				goto IL_0d82;
			}
			_0097._007E_008E_0011(cmb_leadouttype, 6);
		}
		goto IL_0f93;
		IL_1c07:
		if (num2)
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
		goto IL_1e1c;
		IL_0fde:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			F_HeightAdvanced f_HeightAdvanced = new F_HeightAdvanced();
			f_HeightAdvanced.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_HeightAdvanced.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_HeightAdvanced.buCamParameter = new camParameters5(buCamParameter);
			f_HeightAdvanced.Init();
			_009D_0003._007E_0091_0014(f_HeightAdvanced);
			if (f_HeightAdvanced.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_HeightAdvanced.mwCamParameter)));
				if (false)
				{
					goto IL_070f;
				}
				buCamParameter = new camParameters5(f_HeightAdvanced.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
		{
			global::_0005._0002._0001(this);
			F_LeadControl f_LeadControl2 = new F_LeadControl();
			f_LeadControl2.mwCamLeadController = _0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))));
			f_LeadControl2.buCamParameter = new camParameters5(buCamParameter);
			f_LeadControl2.Init();
			_009D_0003._007E_0091_0014(f_LeadControl2);
			if (f_LeadControl2.Properties.Result == DialogResult.OK)
			{
				_0014_0006._007E_008E_001C(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))), f_LeadControl2.mwCamLeadController);
				buCamParameter = new camParameters5(f_LeadControl2.buCamParameter);
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
				else
				{
					bool flag2 = _0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VertProfileRamp;
					num = flag2;
					if (-1 == 0)
					{
						goto IL_005a;
					}
					if (!num)
					{
						num3 = _0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertProfileRamp;
						goto IL_166d;
					}
					_0097._007E_008E_0011(cmb_leadintype, 10);
				}
				goto IL_1757;
			}
		}
		goto IL_17a2;
		IL_070f:
		if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalArc)
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
		else
		{
			num2 = _0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.OrthogonalLine;
			if (3 == 0)
			{
				goto IL_1c07;
			}
			if (num2)
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
		}
		goto IL_0a35;
		IL_0f93:
		_0095._007E_0096_000F(this._0004, global::_0003._007E_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
		goto IL_0fde;
		IL_025a:
		F_DepthStepAdvanced f_DepthStepAdvanced = new F_DepthStepAdvanced();
		if (0 == 0)
		{
			f_DepthStepAdvanced.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_DepthStepAdvanced.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_DepthStepAdvanced.buCamParameter = new camParameters5(buCamParameter);
			f_DepthStepAdvanced.Init();
			_009D_0003._007E_0091_0014(f_DepthStepAdvanced);
			if (f_DepthStepAdvanced.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_DepthStepAdvanced.mwCamParameter)));
				buCamParameter = new camParameters5(f_DepthStepAdvanced.buCamParameter);
			}
			goto IL_0323;
		}
		goto IL_2271;
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			if (!buCamParameter.Operations.isClosed)
			{
				if (global::_000E._007E_000E_0006(this._0001) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._000E_001A());
				}
				else if (global::_000E._007E_000E_0006(this._0001) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._000F_001A());
				}
				else if (global::_000E._007E_000E_0006(this._0001) == 2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0010_001A());
				}
			}
			else if (global::_000E._007E_000E_0006(this._0001) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0011_001A());
			}
			else if (global::_000E._007E_000E_0006(this._0001) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0012_001A());
			}
			else if (global::_000E._007E_000E_0006(this._0001) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0013_001A());
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			if (global::_000E._007E_000E_0006(this._0004) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0014_001A());
			}
			else if (global::_000E._007E_000E_0006(this._0004) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0015_001A());
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			if (global::_000E._007E_000E_0006(this._0002) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0086_0018());
			}
			else if (global::_000E._007E_000E_0006(this._0002) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0087_0018());
			}
			else if (global::_000E._007E_000E_0006(this._0002) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0016_001A());
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			if (global::_000E._007E_000E_0006(this._0003) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0017_001A());
			}
			else if (global::_000E._007E_000E_0006(this._0003) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0018_001A());
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_leadintype)))
		{
			do
			{
				if (global::_000E._007E_000E_0006(cmb_leadintype) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadintype) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0018());
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadintype) == 2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0018());
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadintype) == 3)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadintype) == 4)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadintype) == 5)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadintype) == 6)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadintype) == 7)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadintype) == 8)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadintype) == 9)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadintype) == 10)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0018());
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadintype) == 11)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
					continue;
				}
				if (global::_000E._007E_000E_0006(cmb_leadintype) == 12)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0018());
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 13)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0018());
				}
				break;
			}
			while (false);
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_leadouttype)))
		{
			if (global::_000E._007E_000E_0006(cmb_leadouttype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 3)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 4)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 5)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 6)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 7)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 8)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 9)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			}
			else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 10)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 11)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 12)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 13)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0018());
			}
		}
	}

	internal void _0005(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		Control obj = (Control)P_0;
		if (0 == 0)
		{
			control = obj;
		}
		bool num;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
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
			if (!buCamParameter.Operations.isClosed)
			{
				if (global::_000E._007E_000E_0006(this._0001) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._000E_001A());
				}
				else if (global::_000E._007E_000E_0006(this._0001) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._000F_001A());
				}
				else if (global::_000E._007E_000E_0006(this._0001) == 2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0010_001A());
				}
			}
			else if (global::_000E._007E_000E_0006(this._0001) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0011_001A());
			}
			else if (global::_000E._007E_000E_0006(this._0001) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0012_001A());
			}
			else if (global::_000E._007E_000E_0006(this._0001) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0013_001A());
			}
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView2 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView2);
				_0086_0003._007E_0018_0014(f_GifView2, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView2);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000F)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0004_001A());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001A_0018());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001B_0018());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0014_0019());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0015_0019());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0008)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0015_0019());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000E)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0005_001A());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0006_001A());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0005_001A());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			if (global::_000E._007E_000E_0006(this._0002) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0086_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView3 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView3);
					_0086_0003._007E_0018_0014(f_GifView3, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView3);
				}
			}
			else if (global::_000E._007E_000E_0006(this._0002) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0087_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView4 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView4);
					_0086_0003._007E_0018_0014(f_GifView4, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView4);
				}
			}
			else if (global::_000E._007E_000E_0006(this._0002) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0016_001A());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView5 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView5);
					_0086_0003._007E_0018_0014(f_GifView5, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView5);
				}
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			if (global::_000E._007E_000E_0006(this._0003) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0017_001A());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView6 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView6);
					_0086_0003._007E_0018_0014(f_GifView6, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView6);
				}
			}
			else if (global::_000E._007E_000E_0006(this._0003) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0018_001A());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView7 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView7);
					_0086_0003._007E_0018_0014(f_GifView7, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView7);
				}
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			if (global::_000E._007E_000E_0006(this._0004) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0014_001A());
			}
			else if (global::_000E._007E_000E_0006(this._0004) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0015_001A());
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0007)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView8 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView8);
				_0086_0003._007E_0018_0014(f_GifView8, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView8);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0017)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0019_001A());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0096_0018());
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
			bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002));
			num = flag;
			if (8 == 0)
			{
				goto IL_1f6f;
			}
			if (num)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001D_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView10 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView10);
					_0086_0003._007E_0018_0014(f_GifView10, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView10);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001E_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView11 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView11);
					_0086_0003._007E_0018_0014(f_GifView11, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView11);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0016)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0097_0018());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001F_0018());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0007)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0097_0018());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0014)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._007F_0018());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0013)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0080_0018());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0012)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0098_0018());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0011)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0081_0018());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0010)))
			{
				if (global::_0003._007E_001C(this._0005))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0082_0018());
				}
				else
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_0018());
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0082_0018());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_0018());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0015)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001A_001A());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView12 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView12);
					_0086_0003._007E_0018_0014(f_GifView12, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView12);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0099_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView13 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView13);
					_0086_0003._007E_0018_0014(f_GifView13, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView13);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009A_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView14 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView14);
					_0086_0003._007E_0018_0014(f_GifView14, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView14);
				}
			}
		}
		while (true)
		{
			F_GifView f_GifView20;
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_leadintype)))
			{
				if (global::_000E._007E_000E_0006(cmb_leadintype) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView15 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView15);
						_0086_0003._007E_0018_0014(f_GifView15, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView15);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView16 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView16);
						_0086_0003._007E_0018_0014(f_GifView16, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView16);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView17 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView17);
						_0086_0003._007E_0018_0014(f_GifView17, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView17);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 3)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView18 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView18);
						_0086_0003._007E_0018_0014(f_GifView18, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView18);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 4)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView19 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView19);
						_0086_0003._007E_0018_0014(f_GifView19, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView19);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 5)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						f_GifView20 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView20);
						_0086_0003._007E_0018_0014(f_GifView20, FormStartPosition.CenterParent);
						goto IL_1390;
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 6)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView21 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView21);
						_0086_0003._007E_0018_0014(f_GifView21, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView21);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 7)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView22 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView22);
						_0086_0003._007E_0018_0014(f_GifView22, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView22);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 8)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView23 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView23);
						_0086_0003._007E_0018_0014(f_GifView23, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView23);
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
						F_GifView f_GifView24 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView24);
						_0086_0003._007E_0018_0014(f_GifView24, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView24);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadintype) == 11)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView25 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView25);
						_0086_0003._007E_0018_0014(f_GifView25, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView25);
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
			goto IL_16da;
			IL_16da:
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_leadouttype)))
			{
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView26 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView26);
						_0086_0003._007E_0018_0014(f_GifView26, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView26);
					}
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView27 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView27);
						_0086_0003._007E_0018_0014(f_GifView27, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView27);
					}
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView28 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView28);
						_0086_0003._007E_0018_0014(f_GifView28, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView28);
					}
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 3)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView29 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView29);
						_0086_0003._007E_0018_0014(f_GifView29, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView29);
					}
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 4)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView30 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView30);
						_0086_0003._007E_0018_0014(f_GifView30, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView30);
					}
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 5)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView31 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView31);
						_0086_0003._007E_0018_0014(f_GifView31, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView31);
					}
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 6)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView32 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView32);
						_0086_0003._007E_0018_0014(f_GifView32, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView32);
					}
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 7)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView33 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView33);
						_0086_0003._007E_0018_0014(f_GifView33, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView33);
					}
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 8)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView34 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView34);
						_0086_0003._007E_0018_0014(f_GifView34, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView34);
					}
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 9)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 10)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView35 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView35);
						_0086_0003._007E_0018_0014(f_GifView35, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView35);
						if (3 == 0)
						{
							continue;
						}
						break;
					}
					break;
				}
				goto IL_1c60;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001B_001A());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView36 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView36);
					_0086_0003._007E_0018_0014(f_GifView36, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView36);
				}
				break;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000E)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_001A());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView37 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView37);
					if (uint.MaxValue != 0)
					{
						_0086_0003._007E_0018_0014(f_GifView37, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView37);
						break;
					}
					goto IL_1390;
				}
				break;
			}
			goto IL_1e84;
			IL_1390:
			_009D_0003._007E_0091_0014(f_GifView20);
			goto IL_16da;
		}
		goto IL_208b;
		IL_1c60:
		if (global::_000E._007E_000E_0006(cmb_leadouttype) == 11)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView38 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView38);
				_0086_0003._007E_0018_0014(f_GifView38, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView38);
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
		goto IL_208b;
		IL_1e84:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_000F)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._007F_0019());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView39 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView39);
				_0086_0003._007E_0018_0014(f_GifView39, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView39);
			}
		}
		else
		{
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001D_001A());
				num = global::_0003._007E_0083(this._0002);
				goto IL_1f6f;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0010)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001E_001A());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0011)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001F_001A());
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0012)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._007F_001A());
			}
		}
		goto IL_208b;
		IL_1f6f:
		if (num)
		{
			F_GifView f_GifView40 = new F_GifView();
			global::_0011._007E_0084_0006(f_GifView40);
			_0086_0003._007E_0018_0014(f_GifView40, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView40);
		}
		goto IL_208b;
		IL_208b:
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
