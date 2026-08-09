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

public class F_WFSpin : Form
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

	internal NumericUpDown _0015;

	internal CheckBox _0005;

	internal Panel _0010;

	internal Label _0080;

	internal NumericUpDown _0016;

	internal Label _0081;

	internal CheckBox _0006;

	internal Label _0082;

	internal ComboBox _0004;

	internal Button _0006;

	internal Button _0007;

	internal Panel _0011;

	internal Label _0083;

	internal NumericUpDown _0017;

	internal Label _0084;

	internal Label _0086;

	internal NumericUpDown _0018;

	public F_WFSpin()
	{
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			_0097 obj = _0097._008C_0011;
			int num = PropertiesForm.Height;
			if (4u != 0)
			{
				obj(this, num);
			}
		}
		bool flag = PropertiesForm.Width > 10;
		if (8 == 0)
		{
			goto IL_0668;
		}
		int num2 = (flag ? 1 : 0);
		if (5u != 0)
		{
			if (num2 != 0)
			{
				_0097._008D_0011(this, PropertiesForm.Width);
			}
			_0095._007E_0094_000F(this._0002, PropertiesForm.ShowHelp);
			_0088_0003._007E_001A_0014(this._000E, _0087_0003._0019_0014(global::_0007._007E_007F_0003(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0008, _0004_0004._0097_0014(global::_000E._007E_009F_0005(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0007, _0087_0003._0019_0014(global::_0007._007E_0083_0003(global::_0084._007E_009D_0006(mwCamParameter))));
			_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0017_0003(global::_0084._007E_009D_0006(mwCamParameter))));
			_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0018_0003(global::_0084._007E_009D_0006(mwCamParameter))));
			_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0019_0003(global::_0084._007E_009D_0006(mwCamParameter))));
			_0088_0003._007E_001A_0014(_0012, _0087_0003._0019_0014(global::_0007._007E_001E_0003(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
			_0088_0003._007E_001A_0014(_0013, _0087_0003._0019_0014(global::_0007._007E_001D_0003(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
			_0088_0003._007E_001A_0014(_0014, _0087_0003._0019_0014(global::_0007._007E_001C_0003(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
			_0088_0003._007E_001A_0014(this._0011, _0087_0003._0019_0014(global::_0007._007E_001B_0003(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
			_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(buCamParameter.Steps.EndValue));
			_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(buCamParameter.Steps.StartValue));
			_0088_0003._007E_001A_0014(this._000F, _0087_0003._0019_0014(buCamParameter.Operations.Height));
			_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_0082_0003(global::_0084._007E_009D_0006(mwCamParameter))));
			_0088_0003._007E_001A_0014(this._0010, _0087_0003._0019_0014(buCamParameter.Speeds.SpindleSpeed));
			_0088_0003._007E_001A_0014(_0018, _0087_0003._0019_0014(buCamParameter.Strategy.SpinCStartAngle));
			_0088_0003._007E_001A_0014(_0017, _0087_0003._0019_0014(buCamParameter.Strategy.SpinCEndAngle));
			_0088_0003._007E_001A_0014(_0016, _0087_0003._0019_0014(global::_0007._007E_001E_0004(_001A_0002._007E_0083_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))))));
			_0095._007E_0096_000F(this._0001, global::_0003._007E_0007(global::_0084._007E_009D_0006(mwCamParameter)));
			_0095._007E_0096_000F(this._0005, global::_0003._007E_0006(global::_0084._007E_009D_0006(mwCamParameter)));
			_0095._007E_0096_000F(this._0006, buCamParameter.Offsets.AddToolDiameterAsOffset);
			if (!buCamParameter.Operations.isClosed)
			{
				global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0001));
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.CamOpenContourType[0]);
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.CamOpenContourType[1]);
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.CamOpenContourType[2]);
				if (_0093._007E_0017_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft)
				{
					_0097._007E_008E_0011(this._0001, 0);
				}
				else
				{
					if (_0093._007E_0017_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))) != WireframeBasedTpCalcParamsCuttingSide.WfbCsRight)
					{
						goto IL_0668;
					}
					_0097._007E_008E_0011(this._0001, 2);
				}
				goto IL_067c;
			}
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
			if (_000F_0006._007E_0089_001C(_0082_0005._007E_008B_0016(_008D._007E_000F_0007(_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter))))) == CutterRadiusCompParamsCompensationType.CtOff)
			{
				_0097._007E_008E_0011(this._0001, 1);
			}
			goto IL_082d;
		}
		goto IL_1667;
		IL_14c2:
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
		num2 = _000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[10]);
		goto IL_1667;
		IL_1667:
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[19]);
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
		_0095._007E_0096_000F(this._0004, global::_0003._007E_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
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
		global::_0011._007E_0086_0006(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		global::_0005._0002._0001(this);
		ControlUpdate();
		return;
		IL_0668:
		_0097._007E_008E_0011(this._0001, 1);
		goto IL_067c;
		IL_067c:
		if (_000F_0006._007E_0089_001C(_0082_0005._007E_008B_0016(_008D._007E_000F_0007(_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter))))) == CutterRadiusCompParamsCompensationType.CtOff)
		{
			_0097._007E_008E_0011(this._0001, 1);
		}
		goto IL_082d;
		IL_082d:
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0002));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0002), buMWCaptions.MachiningParamsMachType[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0002), buMWCaptions.MachiningParamsMachType[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0002), buMWCaptions.MachiningParamsMachType[2]);
		if (_0092._007E_0016_0007(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsMachType.MachtypeOneway)
		{
			_0097._007E_008E_0011(this._0002, 0);
		}
		else if (_0092._007E_0016_0007(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsMachType.MachtypeZigzag)
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
		if (_0091._007E_0015_0007(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsMachiningAreaMode.MachByLanes)
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
		if (_008F._007E_0012_0007(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
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
			if (false)
			{
				goto IL_14c2;
			}
			_0095._007E_0093_000F(this._0005, false);
		}
		else
		{
			_0095._007E_0093_000F(this._0006, false);
			_0095._007E_0093_000F(this._0005, true);
		}
		_0095._007E_0096_000F(this._0003, global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
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
		if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialArc)
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
		_0095._007E_0096_000F(this._0004, global::_0003._007E_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_leadouttype));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadouttype), buMWCaptions.LeadParamsType[1]);
		goto IL_14c2;
	}

	public void ControlUpdate()
	{
		if (false)
		{
			goto IL_00ad;
		}
		if (buCamParameter.Operations.isClosed)
		{
			goto IL_0088;
		}
		if (0 == 0)
		{
			_0095._007E_0094_000F(_0082, false);
			_0095._007E_0094_000F(this._0004, false);
			_0095._007E_0094_000F(_0080, false);
			_0095._007E_0094_000F(_0016, false);
			goto IL_00d2;
		}
		goto IL_0155;
		IL_00ad:
		_0095._007E_0094_000F(_0080, true);
		_0095._007E_0094_000F(_0016, true);
		goto IL_00d2;
		IL_0155:
		if (global::_0003._007E_001C(this._0002))
		{
			_0095._007E_0095_000F(this._000E, true);
			_0095._007E_0095_000F(this._0008, false);
		}
		else
		{
			if (3 == 0)
			{
				goto IL_0226;
			}
			_0095._007E_0095_000F(this._000E, false);
			if (-1 == 0)
			{
				goto IL_0088;
			}
			_0095._007E_0095_000F(this._0008, true);
		}
		_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(this._0003));
		_0095._007E_0095_000F(cmb_leadintype, global::_0003._007E_0083(this._0003));
		_0095._007E_0095_000F(_007F, global::_0003._007E_0083(this._0003));
		goto IL_0226;
		IL_0226:
		_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0004));
		_0095._007E_0095_000F(cmb_leadouttype, global::_0003._007E_0083(this._0004));
		_0095._007E_0095_000F(_001E, global::_0003._007E_0083(this._0004));
		return;
		IL_00d2:
		_0095._007E_0095_000F(_0015, global::_0003._007E_0083(this._0005));
		if (global::_0003._007E_001C(this._0003))
		{
			_0095._007E_0095_000F(this._0005, true);
			_0095._007E_0095_000F(this._0004, false);
		}
		else
		{
			_0095._007E_0095_000F(this._0005, false);
			_0095._007E_0095_000F(this._0004, true);
		}
		goto IL_0155;
		IL_0088:
		_0095._007E_0094_000F(_0082, true);
		_0095._007E_0094_000F(this._0004, true);
		goto IL_00ad;
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected O, but got Unknown
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Expected O, but got Unknown
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Expected O, but got Unknown
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Expected O, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected O, but got Unknown
		//IL_100f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1019: Expected O, but got Unknown
		//IL_1035: Unknown result type (might be due to invalid IL or missing references)
		//IL_103f: Expected O, but got Unknown
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Expected O, but got Unknown
		//IL_1099: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a3: Expected O, but got Unknown
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f5: Expected O, but got Unknown
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0007)))
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
		F_DepthStepAdvanced f_DepthStepAdvanced = default(F_DepthStepAdvanced);
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			f_DepthStepAdvanced = new F_DepthStepAdvanced();
			f_DepthStepAdvanced.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_DepthStepAdvanced.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			goto IL_02a5;
		}
		goto IL_031d;
		IL_172d:
		_0095._007E_0096_000F(this._0003, global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
		goto IL_1778;
		IL_15ea:
		_0097._007E_008E_0011(cmb_leadintype, 10);
		goto IL_172d;
		IL_031d:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			F_SurfaceQuality f_SurfaceQuality = new F_SurfaceQuality();
			f_SurfaceQuality.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_SurfaceQuality.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_SurfaceQuality.buCamParameter = new camParameters5(buCamParameter);
			f_SurfaceQuality.Init();
			_009D_0003._007E_0091_0014(f_SurfaceQuality);
			if (f_SurfaceQuality.Properties.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_SurfaceQuality.mwCamParameter)));
				buCamParameter = new camParameters5(f_SurfaceQuality.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
		{
			F_ContourLink f_ContourLink = new F_ContourLink();
			f_ContourLink.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			if (false)
			{
				goto IL_15ea;
			}
			global::_0086._007E_009E_0006(f_ContourLink.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_ContourLink.buCamParameter = new camParameters5(buCamParameter);
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
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.SlantLine)
				{
					_0097._007E_008E_0011(cmb_leadintype, 12);
				}
				_0095._007E_0096_000F(this._0003, global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
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
				else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.SlantLine)
				{
					_0097._007E_008E_0011(cmb_leadouttype, 12);
				}
				_0095._007E_0096_000F(this._0004, global::_0003._007E_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
			}
		}
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
				buCamParameter = new camParameters5(f_HeightAdvanced.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
		{
			global::_0005._0002._0001(this);
			F_LeadControl f_LeadControl = new F_LeadControl();
			f_LeadControl.mwCamLeadController = _0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))));
			f_LeadControl.buCamParameter = new camParameters5(buCamParameter);
			f_LeadControl.Init();
			_009D_0003._007E_0091_0014(f_LeadControl);
			if (f_LeadControl.Properties.Result == DialogResult.OK)
			{
				_0014_0006._007E_008E_001C(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))), f_LeadControl.mwCamLeadController);
				buCamParameter = new camParameters5(f_LeadControl.buCamParameter);
				if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.TangentialArc)
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
				else
				{
					if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VertProfileRamp)
					{
						goto IL_15ea;
					}
					if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.ReverseVertProfileRamp)
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
				}
				goto IL_172d;
			}
		}
		goto IL_1778;
		IL_02a5:
		f_DepthStepAdvanced.buCamParameter = new camParameters5(buCamParameter);
		f_DepthStepAdvanced.Init();
		_009D_0003._007E_0091_0014(f_DepthStepAdvanced);
		if (f_DepthStepAdvanced.PropertiesForm.Result == DialogResult.OK)
		{
			global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_DepthStepAdvanced.mwCamParameter)));
			buCamParameter = new camParameters5(f_DepthStepAdvanced.buCamParameter);
		}
		goto IL_031d;
		IL_1778:
		if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			return;
		}
		F_LeadControl f_LeadControl2 = new F_LeadControl();
		f_LeadControl2.mwCamLeadController = _0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter))));
		f_LeadControl2.buCamParameter = new camParameters5(buCamParameter);
		f_LeadControl2.Init();
		_009D_0003._007E_0091_0014(f_LeadControl2);
		if (f_LeadControl2.Properties.Result != DialogResult.OK)
		{
			return;
		}
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
		else
		{
			if (-1 == 0)
			{
				goto IL_02a5;
			}
			if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))))) == LeadParamsType.VerticalTangArc)
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
		control = (Control)P_0;
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
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0016)))
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
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
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
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0015)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0097_0018());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001F_0018());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0097_0018());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0014)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._007F_0018());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0013)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0080_0018());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0012)))
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
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0099_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView12 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView12);
				_0086_0003._007E_0018_0014(f_GifView12, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView12);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._009A_0018());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView13 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView13);
				_0086_0003._007E_0018_0014(f_GifView13, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView13);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_leadintype)))
		{
			if (global::_000E._007E_000E_0006(cmb_leadintype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView14 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView14);
					_0086_0003._007E_0018_0014(f_GifView14, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView14);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView15 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView15);
					_0086_0003._007E_0018_0014(f_GifView15, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView15);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView16 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView16);
					_0086_0003._007E_0018_0014(f_GifView16, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView16);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 3)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView17 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView17);
					_0086_0003._007E_0018_0014(f_GifView17, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView17);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 4)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView18 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView18);
					_0086_0003._007E_0018_0014(f_GifView18, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView18);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 5)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView19 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView19);
					_0086_0003._007E_0018_0014(f_GifView19, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView19);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 6)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView20 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView20);
					_0086_0003._007E_0018_0014(f_GifView20, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView20);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 7)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView21 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView21);
					_0086_0003._007E_0018_0014(f_GifView21, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView21);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 8)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView22 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView22);
					_0086_0003._007E_0018_0014(f_GifView22, FormStartPosition.CenterParent);
					if (false)
					{
						goto IL_17ab;
					}
					_009D_0003._007E_0091_0014(f_GifView22);
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
					F_GifView f_GifView23 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView23);
					_0086_0003._007E_0018_0014(f_GifView23, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView23);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadintype) == 11)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView24 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView24);
					_0086_0003._007E_0018_0014(f_GifView24, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView24);
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_leadouttype)))
		{
			if (global::_000E._007E_000E_0006(cmb_leadouttype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView25 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView25);
					_0086_0003._007E_0018_0014(f_GifView25, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView25);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0018());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView26 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView26);
					_0086_0003._007E_0018_0014(f_GifView26, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView26);
				}
			}
			else
			{
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0018());
					goto IL_17ab;
				}
				if (global::_000E._007E_000E_0006(cmb_leadouttype) == 3)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView27 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView27);
						_0086_0003._007E_0018_0014(f_GifView27, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView27);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 4)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView28 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView28);
						_0086_0003._007E_0018_0014(f_GifView28, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView28);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 5)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView29 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView29);
						_0086_0003._007E_0018_0014(f_GifView29, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView29);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 6)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView30 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView30);
						_0086_0003._007E_0018_0014(f_GifView30, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView30);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 7)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView31 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView31);
						_0086_0003._007E_0018_0014(f_GifView31, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView31);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 8)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView32 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView32);
						_0086_0003._007E_0018_0014(f_GifView32, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView32);
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
						F_GifView f_GifView33 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView33);
						_0086_0003._007E_0018_0014(f_GifView33, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView33);
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_leadouttype) == 11)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView34 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView34);
						_0086_0003._007E_0018_0014(f_GifView34, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView34);
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
			}
		}
		goto IL_1cb5;
		IL_1cb5:
		_0095._007E_0096_000F(this._0002, false);
		return;
		IL_17ab:
		if (global::_0003._007E_0083(this._0002))
		{
			F_GifView f_GifView35 = new F_GifView();
			global::_0011._007E_0084_0006(f_GifView35);
			_0086_0003._007E_0018_0014(f_GifView35, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView35);
		}
		goto IL_1cb5;
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
