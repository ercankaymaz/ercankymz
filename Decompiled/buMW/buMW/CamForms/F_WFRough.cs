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

public class F_WFRough : Form
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

	internal Label _001E;

	public ComboBox cmb_exitramptype;

	internal Label _001F;

	internal Button _0004;

	internal Label _007F;

	public ComboBox cmb_entryramptype;

	internal Panel _0010;

	internal Label _0080;

	internal Label _0081;

	internal NumericUpDown _0015;

	internal NumericUpDown _0016;

	internal CheckBox _0004;

	internal Panel _0011;

	internal Label _0082;

	internal Label _0083;

	internal CheckBox _0005;

	internal Label _0084;

	internal ComboBox _0004;

	internal CheckBox _0006;

	internal Label _0086;

	internal NumericUpDown _0017;

	internal CheckBox _0007;

	internal CheckBox _0008;

	internal Panel _0012;

	internal Label _0087;

	internal Label _0088;

	internal NumericUpDown _0018;

	internal CheckBox _000E;

	internal CheckBox _000F;

	internal CheckBox _0010;

	internal NumericUpDown _0019;

	internal Label _0089;

	internal Label _008A;

	internal NumericUpDown _001A;

	internal Button _0005;

	internal Panel _0013;

	internal Button _0006;

	internal Button _0007;

	internal CheckBox _0011;

	internal Label _008B;

	internal Panel _0014;

	internal Button _0008;

	internal CheckBox _0012;

	internal Label _008C;

	internal Panel _0015;

	internal Button _000E;

	internal Button _000F;

	internal CheckBox _0013;

	internal Button _0010;

	internal Label _008D;

	internal Panel _0016;

	internal Button _0011;

	internal CheckBox _0014;

	internal Label _008E;

	internal Panel _0017;

	internal Button _0012;

	internal Button _0013;

	internal CheckBox _0015;

	internal Label _008F;

	internal Button _0014;

	public F_WFRough()
	{
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		while (true)
		{
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
			bool num2 = PropertiesForm.Width > 10;
			bool flag2;
			if (uint.MaxValue != 0)
			{
				flag2 = num2;
			}
			if (flag2)
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
			_0088_0003._007E_001A_0014(_0019, _0087_0003._0019_0014(global::_0007._007E_0017_0004(global::_0084._007E_009D_0006(mwCamParameter))));
			_0088_0003._007E_001A_0014(this._0012, _0087_0003._0019_0014(global::_0007._007E_001E_0003(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
			_0088_0003._007E_001A_0014(this._0013, _0087_0003._0019_0014(global::_0007._007E_001D_0003(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
			_0088_0003._007E_001A_0014(this._0014, _0087_0003._0019_0014(global::_0007._007E_001C_0003(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
			_0088_0003._007E_001A_0014(this._0011, _0087_0003._0019_0014(global::_0007._007E_001B_0003(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
			_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(buCamParameter.Steps.EndValue));
			_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(buCamParameter.Steps.StartValue));
			_0088_0003._007E_001A_0014(this._000F, _0087_0003._0019_0014(buCamParameter.Operations.Height));
			while (true)
			{
				_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_0082_0003(global::_0084._007E_009D_0006(mwCamParameter))));
				_0088_0003._007E_001A_0014(this._0010, _0087_0003._0019_0014(buCamParameter.Speeds.SpindleSpeed));
				_0095._007E_0096_000F(this._0001, global::_0003._007E_0007(global::_0084._007E_009D_0006(mwCamParameter)));
				_0095._007E_0096_000F(this._0006, global::_0003._007E_0003_0003(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
				if (false)
				{
					goto IL_074b;
				}
				if (0 == 0)
				{
					_0095._007E_0096_000F(this._0004, global::_0003._007E_0006(global::_0084._007E_009D_0006(mwCamParameter)));
					goto IL_04d2;
				}
				goto IL_0f2d;
				IL_04d2:
				_0095._007E_0096_000F(this._0005, buCamParameter.Offsets.AddToolDiameterAsOffset);
				_0095._007E_0096_000F(this._0008, global::_0003._007E_0005_0002(global::_0084._007E_009D_0006(mwCamParameter)));
				_0095._007E_0096_000F(this._0007, global::_0003._007E_0004_0002(global::_0084._007E_009D_0006(mwCamParameter)));
				_0088_0003._007E_001A_0014(this._0017, _0087_0003._0019_0014(global::_0007._007E_001B_0004(global::_0084._007E_009D_0006(mwCamParameter))));
				_0088_0003._007E_001A_0014(_0018, _0087_0003._0019_0014(global::_0007._007E_0087_0003(global::_0084._007E_009D_0006(mwCamParameter))));
				if (Tool != null)
				{
					goto IL_05c0;
				}
				goto IL_0612;
				IL_0da5:
				_0097._007E_008E_0011(cmb_exitramptype, 0);
				goto IL_0e5b;
				IL_074b:
				global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0004));
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0004), buMWCaptions.MachiningParamsDirection[2]);
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0004), buMWCaptions.MachiningParamsDirection[3]);
				if (_0015_0004._007E_0006_0015(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsDirection.DirClimb)
				{
					_0097._007E_008E_0011(this._0004, 0);
					if (false)
					{
						break;
					}
				}
				else if (_0015_0004._007E_0006_0015(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsDirection.DirConventional)
				{
					_0097._007E_008E_0011(this._0004, 1);
				}
				global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0002));
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0002), buMWCaptions.MachiningParamsMachType[0]);
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0002), buMWCaptions.MachiningParamsMachType[1]);
				if (_0092._007E_0016_0007(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsMachType.MachtypeOneway)
				{
					_0097._007E_008E_0011(this._0002, 0);
				}
				else if (_0092._007E_0016_0007(global::_0084._007E_009D_0006(mwCamParameter)) == MachiningParamsMachType.MachtypeZigzag)
				{
					_0097._007E_008E_0011(this._0002, 1);
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
				if (global::_008F._007E_0012_0007(global::_008E._007E_0010_0007(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
				{
					_0095._007E_0093_000F(this._0002, true);
					_0095._007E_0093_000F(this._0001, false);
					if (false)
					{
						goto IL_0da5;
					}
				}
				else
				{
					if (false)
					{
						goto IL_04d2;
					}
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
					if (1 == 0)
					{
						goto IL_0c7f;
					}
					_0095._007E_0093_000F(this._0005, true);
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
				else
				{
					if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.UseRapidDistance)
					{
						goto IL_0c7f;
					}
					if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.UseFeedDistance)
					{
						_0097._007E_008E_0011(cmb_entryramptype, 2);
					}
				}
				goto IL_0ce0;
				IL_0e5b:
				_0088_0003._007E_001A_0014(this._0015, _0087_0003._0019_0014(global::_0007._007E_0089_0005(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
				if (7 == 0)
				{
					continue;
				}
				_0095._007E_0096_000F(this._0011, global::_0003._007E_0004_0003(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
				if (0 == 0)
				{
					_0095._007E_0096_000F(this._0010, global::_0003._007E_009F_0002(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
					goto IL_0f2d;
				}
				goto IL_0fb6;
				IL_0ce0:
				global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_exitramptype));
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_exitramptype), buMWCaptions.LastExitType[0]);
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_exitramptype), buMWCaptions.LastExitType[1]);
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_exitramptype), buMWCaptions.LastExitType[2]);
				if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == LastExitType.BackToRapidPlane)
				{
					goto IL_0da5;
				}
				if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == LastExitType.UseRapidDistance)
				{
					_0097._007E_008E_0011(cmb_exitramptype, 1);
				}
				else if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(global::_008B._007E_0008_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == LastExitType.UseFeedDistance)
				{
					_0097._007E_008E_0011(cmb_exitramptype, 2);
					if (false)
					{
						goto IL_05c0;
					}
				}
				goto IL_0e5b;
				IL_0fb6:
				_0095._007E_0096_000F(this._0013, global::_0003._007E_0003_0002(_0016_0004._007E_0007_0015(global::_0084._007E_009D_0006(mwCamParameter))));
				_0095._007E_0096_000F(this._0014, global::_0003._007E_009E_0002(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(global::_0084._007E_009D_0006(mwCamParameter)))));
				_0095._007E_0096_000F(_0015, global::_0003._007E_008B_0002(_0089_0005._007E_0093_0016(global::_0084._007E_009D_0006(mwCamParameter))));
				Configration.Mode = CamMode.WireFrame;
				Configration.CamWireframeType = CamWireFrameType.Pocket;
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0084_0018());
				global::_0011._007E_0086_0006(this);
				PropertiesForm.Result = DialogResult.None;
				PropertiesForm.Inited = true;
				global::_0005._0002._0001(this);
				ControlUpdate();
				return;
				IL_0612:
				global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0001));
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.WireframeBasedTpCalcParamsRoughType[0]);
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.WireframeBasedTpCalcParamsRoughType[1]);
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.WireframeBasedTpCalcParamsRoughType[2]);
				if (_0017_0006._007E_0095_001C(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == WireframeBasedTpCalcParamsRoughType.WfbRghtOffset)
				{
					_0097._007E_008E_0011(this._0001, 0);
				}
				else if (_0017_0006._007E_0095_001C(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))) == WireframeBasedTpCalcParamsRoughType.WfbRghtParallel)
				{
					_0097._007E_008E_0011(this._0001, 1);
				}
				else
				{
					_0097._007E_008E_0011(this._0001, 2);
				}
				goto IL_074b;
				IL_0f2d:
				_0095._007E_0096_000F(this._000F, global::_0003._007E_0005_0003(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter)))));
				_0095._007E_0096_000F(this._0012, global::_0003._007E_007F_0002(global::_008E._007E_0010_0007(global::_008D._007E_000F_0007(global::_008C._007E_000E_0007(global::_0084._007E_009D_0006(mwCamParameter))))));
				goto IL_0fb6;
				IL_05c0:
				_0088_0003._007E_001A_0014(_001A, _0087_0003._0019_0014(global::_0007._007E_0087_0003(global::_0084._007E_009D_0006(mwCamParameter)) / Tool.Geometry.Diameter * 100.0));
				goto IL_0612;
				IL_0c7f:
				_0097._007E_008E_0011(cmb_entryramptype, 1);
				goto IL_0ce0;
			}
		}
	}

	public void ControlUpdate()
	{
		_0095._007E_0095_000F(this._0008, global::_0003._007E_0083(this._0012));
		_0095._007E_0095_000F(this._0007, global::_0003._007E_0083(this._0011));
		if (4u != 0)
		{
			_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0011));
			_0095._007E_0095_000F(_000F, global::_0003._007E_0083(this._0013));
			_0095._007E_0095_000F(_0010, global::_0003._007E_0083(this._0013));
			_0095._007E_0095_000F(_0011, global::_0003._007E_0083(this._0014));
			if (false)
			{
				goto IL_020e;
			}
			_0095._007E_0095_000F(_0013, global::_0003._007E_0083(_0015));
			_0095._007E_0095_000F(_0012, global::_0003._007E_0083(_0015));
			_0095._007E_0095_000F(this._0016, global::_0003._007E_0083(this._0004));
			if (global::_0003._007E_001C(this._0003))
			{
				_0095._007E_0095_000F(this._0005, true);
				_0095._007E_0095_000F(this._0004, false);
				goto IL_01ac;
			}
			_0095._007E_0095_000F(this._0005, false);
		}
		_0095._007E_0095_000F(this._0004, true);
		goto IL_01ac;
		IL_020e:
		_0095._007E_0095_000F(cmb_entryramptype, global::_0003._007E_0083(this._0003));
		_0095._007E_0095_000F(_007F, global::_0003._007E_0083(this._0003));
		return;
		IL_01ac:
		if (global::_0003._007E_001C(this._0002))
		{
			_0095._007E_0095_000F(this._000E, true);
			_0095._007E_0095_000F(this._0008, false);
		}
		else
		{
			_0095._007E_0095_000F(this._000E, false);
			_0095._007E_0095_000F(this._0008, true);
		}
		goto IL_020e;
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected O, but got Unknown
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Expected O, but got Unknown
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Expected O, but got Unknown
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Expected O, but got Unknown
		//IL_04e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Expected O, but got Unknown
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Expected O, but got Unknown
		//IL_07d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07dc: Expected O, but got Unknown
		//IL_07f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0802: Expected O, but got Unknown
		//IL_054a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Expected O, but got Unknown
		//IL_0b70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7a: Expected O, but got Unknown
		//IL_0b96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba0: Expected O, but got Unknown
		//IL_0455: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Expected O, but got Unknown
		//IL_08cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d7: Expected O, but got Unknown
		//IL_0c98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca2: Expected O, but got Unknown
		//IL_0cbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc8: Expected O, but got Unknown
		//IL_0dc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dca: Expected O, but got Unknown
		//IL_0de6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df0: Expected O, but got Unknown
		//IL_0c30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3a: Expected O, but got Unknown
		//IL_0ee8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef2: Expected O, but got Unknown
		//IL_0f0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f18: Expected O, but got Unknown
		//IL_0d58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d62: Expected O, but got Unknown
		//IL_0e80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8a: Expected O, but got Unknown
		//IL_1144: Unknown result type (might be due to invalid IL or missing references)
		//IL_114e: Expected O, but got Unknown
		//IL_116a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1174: Expected O, but got Unknown
		//IL_101c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1026: Expected O, but got Unknown
		//IL_1042: Unknown result type (might be due to invalid IL or missing references)
		//IL_104c: Expected O, but got Unknown
		//IL_0fae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb8: Expected O, but got Unknown
		//IL_1204: Unknown result type (might be due to invalid IL or missing references)
		//IL_120e: Expected O, but got Unknown
		//IL_10dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e6: Expected O, but got Unknown
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			F_DepthStepAdvanced f_DepthStepAdvanced = new F_DepthStepAdvanced();
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
		}
		F_SurfaceQuality f_SurfaceQuality;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			f_SurfaceQuality = new F_SurfaceQuality();
			f_SurfaceQuality.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_SurfaceQuality.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_SurfaceQuality.buCamParameter = new camParameters5(buCamParameter);
			f_SurfaceQuality.Init();
			goto IL_031d;
		}
		goto IL_037c;
		IL_064f:
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
		goto IL_0782;
		IL_031d:
		_009D_0003._007E_0091_0014(f_SurfaceQuality);
		if (f_SurfaceQuality.Properties.Result == DialogResult.OK)
		{
			global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_SurfaceQuality.mwCamParameter)));
			buCamParameter = new camParameters5(f_SurfaceQuality.buCamParameter);
		}
		goto IL_037c;
		IL_037c:
		bool num;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			F_HeightAdvanced f_HeightAdvanced = new F_HeightAdvanced();
			f_HeightAdvanced.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_HeightAdvanced.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_HeightAdvanced.buCamParameter = new camParameters5(buCamParameter);
			f_HeightAdvanced.Init();
			_009D_0003._007E_0091_0014(f_HeightAdvanced);
			bool flag = f_HeightAdvanced.PropertiesForm.Result == DialogResult.OK;
			num = flag;
			if (false)
			{
				goto IL_0b4c;
			}
			if (num)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_HeightAdvanced.mwCamParameter)));
				buCamParameter = new camParameters5(f_HeightAdvanced.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
		{
			F_RoughLink f_RoughLink = new F_RoughLink();
			f_RoughLink.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_RoughLink.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_RoughLink.buCamParameter = new camParameters5(buCamParameter);
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
				goto IL_064f;
			}
		}
		goto IL_0782;
		IL_0b4c:
		if (num)
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0008)))
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_000F)))
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
		{
			F_Fixtures f_Fixtures = new F_Fixtures();
			f_Fixtures.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_Fixtures.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_Fixtures.buCamParameter = new camParameters5(buCamParameter);
			f_Fixtures.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				if (false)
				{
					goto IL_064f;
				}
				f_Fixtures.Tool = new ToolBase5(f_Fixtures.Tool);
			}
			f_Fixtures.Init();
			_009D_0003._007E_0091_0014(f_Fixtures);
			if (f_Fixtures.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_Fixtures.mwCamParameter)));
				buCamParameter = new camParameters5(f_Fixtures.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0011)))
		{
			if (false)
			{
				goto IL_031d;
			}
			F_ProfilePass f_ProfilePass = new F_ProfilePass();
			f_ProfilePass.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_ProfilePass.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			f_ProfilePass.buCamParameter = new camParameters5(buCamParameter);
			f_ProfilePass.Configration = new MWCalculationOptions(Configration);
			if (Tool != null)
			{
				f_ProfilePass.Tool = new ToolBase5(f_ProfilePass.Tool);
			}
			f_ProfilePass.Init();
			_009D_0003._007E_0091_0014(f_ProfilePass);
			if (f_ProfilePass.PropertiesForm.Result == DialogResult.OK)
			{
				global::_0086._007E_009E_0006(mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(f_ProfilePass.mwCamParameter)));
				buCamParameter = new camParameters5(f_ProfilePass.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0012)))
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
		IL_0782:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			global::_0005._0002._0001(this);
			F_Roughing f_Roughing = new F_Roughing();
			f_Roughing.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
			global::_0086._007E_009E_0006(f_Roughing.mwCamParameter, new MachiningParams(global::_0084._007E_009D_0006(mwCamParameter)));
			global::_0088._007E_0002_0007(f_Roughing.mwCamParameter, global::_0087._007E_009F_0006(mwCamParameter));
			f_Roughing.buCamParameter = new camParameters5(buCamParameter);
			_0095._007E_0094_000F(f_Roughing.chk_mirror, false);
			_0095._007E_0094_000F(f_Roughing.chk_transformrotate, false);
			_0095._007E_0094_000F(f_Roughing.btn_mirror, false);
			_0095._007E_0094_000F(f_Roughing.btn_transformrotate, false);
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
		num = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0014));
		goto IL_0b4c;
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
		bool num;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			if (global::_000E._007E_000E_0006(this._0001) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0084_0018());
			}
			else if (global::_000E._007E_000E_0006(this._0001) == 1)
			{
				if (1 == 0)
				{
					goto IL_0895;
				}
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009B_0018());
			}
			else
			{
				bool flag = global::_000E._007E_000E_0006(this._0001) == 2;
				num = flag;
				if (false)
				{
					goto IL_09bd;
				}
				if (num)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._009C_0018());
				}
			}
		}
		bool num2;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			if (global::_000E._007E_000E_0006(this._0004) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0014_001A());
			}
			else
			{
				bool flag2 = global::_000E._007E_000E_0006(this._0004) == 1;
				num2 = flag2;
				if (false)
				{
					goto IL_084e;
				}
				if (num2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0015_001A());
				}
			}
		}
		bool flag3 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002));
		num2 = flag3;
		goto IL_01ec;
		IL_084e:
		if (8 == 0)
		{
			goto IL_01ec;
		}
		if (num2)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
			return;
		}
		if (global::_000E._007E_000E_0006(cmb_exitramptype) == 7)
		{
			goto IL_0895;
		}
		if (global::_000E._007E_000E_0006(cmb_exitramptype) == 8)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
			return;
		}
		int num3 = global::_000E._007E_000E_0006(cmb_exitramptype);
		int num4 = 9;
		if (num4 == 0)
		{
			goto IL_0760;
		}
		if (num3 == num4)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			return;
		}
		if (global::_000E._007E_000E_0006(cmb_exitramptype) == 10)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0018());
			return;
		}
		if (global::_000E._007E_000E_0006(cmb_exitramptype) == 11)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
			return;
		}
		num = global::_000E._007E_000E_0006(cmb_exitramptype) == 12;
		goto IL_09bd;
		IL_04e2:
		int num5;
		int num6;
		bool flag4 = num5 == num6;
		bool num7 = flag4;
		while (true)
		{
			if (num7)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
				break;
			}
			if (global::_000E._007E_000E_0006(cmb_entryramptype) == 7)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
				break;
			}
			bool flag5 = global::_000E._007E_000E_0006(cmb_entryramptype) == 8;
			num7 = flag5;
			if (true)
			{
				if (num7)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
				}
				else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 9)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				}
				else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 10)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0018());
				}
				else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 11)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
				}
				else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 12)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0018());
				}
				else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 13)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0018());
				}
				break;
			}
		}
		goto IL_06aa;
		IL_06aa:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_exitramptype)))
		{
			if (global::_000E._007E_000E_0006(cmb_exitramptype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
				return;
			}
			if (global::_000E._007E_000E_0006(cmb_exitramptype) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0018());
				return;
			}
			num3 = global::_000E._007E_000E_0006(cmb_exitramptype);
			num4 = 2;
			goto IL_0760;
		}
		return;
		IL_0813:
		bool num8;
		if (num8 != 0)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
			return;
		}
		num2 = global::_000E._007E_000E_0006(cmb_exitramptype) == 6;
		goto IL_084e;
		IL_01ec:
		if (num2)
		{
			if (global::_000E._007E_000E_0006(this._0002) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0086_0018());
			}
			else if (global::_000E._007E_000E_0006(this._0002) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0087_0018());
			}
			else
			{
				num8 = global::_000E._007E_000E_0006(this._0002) == 2;
				if (5 == 0)
				{
					goto IL_0813;
				}
				if (num8)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0016_001A());
				}
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_entryramptype)))
		{
			if (global::_000E._007E_000E_0006(cmb_entryramptype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0018());
			}
			else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0018());
			}
			else
			{
				num5 = global::_000E._007E_000E_0006(cmb_entryramptype);
				num6 = 3;
				if (num6 == 0)
				{
					goto IL_04e2;
				}
				if (num5 == num6)
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
						num5 = global::_000E._007E_000E_0006(cmb_entryramptype);
						num6 = 6;
						goto IL_04e2;
					}
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
				}
			}
		}
		goto IL_06aa;
		IL_0760:
		if (num3 == num4)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0018());
			return;
		}
		if (global::_000E._007E_000E_0006(cmb_exitramptype) == 3)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
			return;
		}
		if (global::_000E._007E_000E_0006(cmb_exitramptype) == 4)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
			return;
		}
		num8 = global::_000E._007E_000E_0006(cmb_exitramptype) == 5;
		goto IL_0813;
		IL_0895:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
		return;
		IL_09bd:
		if (num)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0018());
		}
		else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 13)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0018());
		}
	}

	internal void _0005(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		bool num;
		int num2;
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
			if (global::_000E._007E_000E_0006(this._0001) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0084_0018());
			}
			else if (global::_000E._007E_000E_0006(this._0001) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009B_0018());
			}
			else if (global::_000E._007E_000E_0006(this._0001) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009C_0018());
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
			else
			{
				if (global::_000E._007E_000E_0006(this._0002) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0087_0018());
					bool flag = global::_0003._007E_0083(this._0002);
					num = flag;
					goto IL_057f;
				}
				if (global::_000E._007E_000E_0006(this._0002) == 2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0016_001A());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView4 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView4);
						_0086_0003._007E_0018_0014(f_GifView4, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView4);
					}
				}
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			bool flag2 = global::_000E._007E_000E_0006(this._0003) == 0;
			if (5 == 0)
			{
				goto IL_0c9a;
			}
			if (flag2)
			{
				goto IL_0687;
			}
			if (global::_000E._007E_000E_0006(this._0003) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0018_001A());
				if (global::_0003._007E_0083(this._0002))
				{
					F_GifView f_GifView5 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView5);
					_0086_0003._007E_0018_0014(f_GifView5, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView5);
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
				F_GifView f_GifView6 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView6);
				_0086_0003._007E_0018_0014(f_GifView6, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView6);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0019)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView7 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView7);
				_0086_0003._007E_0018_0014(f_GifView7, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView7);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0017_0019());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView8 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView8);
				_0086_0003._007E_0018_0014(f_GifView8, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView8);
			}
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
				if (-1 == 0)
				{
					goto IL_0687;
				}
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
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0018)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0019());
			if (global::_0003._007E_0083(this._0002))
			{
				F_GifView f_GifView12 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView12);
				_0086_0003._007E_0018_0014(f_GifView12, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView12);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0016)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0097_0018());
		}
		else
		{
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				goto IL_0c9a;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
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
			else
			{
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
				{
					goto IL_0f39;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0015)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001A_001A());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView13 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView13);
						_0086_0003._007E_0018_0014(f_GifView13, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView13);
					}
				}
				else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0099_0018());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView14 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView14);
						_0086_0003._007E_0018_0014(f_GifView14, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView14);
					}
				}
				else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_entryramptype)))
				{
					if (global::_000E._007E_000E_0006(cmb_entryramptype) == 0)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
						if (global::_0003._007E_0083(this._0002))
						{
							F_GifView f_GifView15 = new F_GifView();
							global::_0011._007E_0084_0006(f_GifView15);
							_0086_0003._007E_0018_0014(f_GifView15, FormStartPosition.CenterParent);
							_009D_0003._007E_0091_0014(f_GifView15);
							if (4 == 0)
							{
								goto IL_1361;
							}
						}
					}
					else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 1)
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
					else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 2)
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
					else
					{
						if (global::_000E._007E_000E_0006(cmb_entryramptype) == 3)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
							goto IL_1272;
						}
						if (global::_000E._007E_000E_0006(cmb_entryramptype) == 4)
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
						else
						{
							if (global::_000E._007E_000E_0006(cmb_entryramptype) == 5)
							{
								goto IL_1361;
							}
							if (global::_000E._007E_000E_0006(cmb_entryramptype) == 6)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
								if (global::_0003._007E_0083(this._0002))
								{
									F_GifView f_GifView19 = new F_GifView();
									global::_0011._007E_0084_0006(f_GifView19);
									_0086_0003._007E_0018_0014(f_GifView19, FormStartPosition.CenterParent);
									_009D_0003._007E_0091_0014(f_GifView19);
								}
							}
							else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 7)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
								if (global::_0003._007E_0083(this._0002))
								{
									F_GifView f_GifView20 = new F_GifView();
									global::_0011._007E_0084_0006(f_GifView20);
									_0086_0003._007E_0018_0014(f_GifView20, FormStartPosition.CenterParent);
									_009D_0003._007E_0091_0014(f_GifView20);
								}
							}
							else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 8)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
								if (global::_0003._007E_0083(this._0002))
								{
									F_GifView f_GifView21 = new F_GifView();
									global::_0011._007E_0084_0006(f_GifView21);
									_0086_0003._007E_0018_0014(f_GifView21, FormStartPosition.CenterParent);
									_009D_0003._007E_0091_0014(f_GifView21);
								}
							}
							else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 9)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
							}
							else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 10)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0018());
								if (global::_0003._007E_0083(this._0002))
								{
									F_GifView f_GifView22 = new F_GifView();
									global::_0011._007E_0084_0006(f_GifView22);
									_0086_0003._007E_0018_0014(f_GifView22, FormStartPosition.CenterParent);
									_009D_0003._007E_0091_0014(f_GifView22);
								}
							}
							else if (global::_000E._007E_000E_0006(cmb_entryramptype) == 11)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
								if (global::_0003._007E_0083(this._0002))
								{
									F_GifView f_GifView23 = new F_GifView();
									global::_0011._007E_0084_0006(f_GifView23);
									_0086_0003._007E_0018_0014(f_GifView23, FormStartPosition.CenterParent);
									_009D_0003._007E_0091_0014(f_GifView23);
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
				}
				else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_exitramptype)))
				{
					if (global::_000E._007E_000E_0006(cmb_exitramptype) == 0)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0018());
						if (global::_0003._007E_0083(this._0002))
						{
							F_GifView f_GifView24 = new F_GifView();
							global::_0011._007E_0084_0006(f_GifView24);
							_0086_0003._007E_0018_0014(f_GifView24, FormStartPosition.CenterParent);
							_009D_0003._007E_0091_0014(f_GifView24);
						}
					}
					else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 1)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0018());
						if (global::_0003._007E_0083(this._0002))
						{
							F_GifView f_GifView25 = new F_GifView();
							global::_0011._007E_0084_0006(f_GifView25);
							_0086_0003._007E_0018_0014(f_GifView25, FormStartPosition.CenterParent);
							_009D_0003._007E_0091_0014(f_GifView25);
						}
					}
					else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 2)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0018());
						if (global::_0003._007E_0083(this._0002))
						{
							F_GifView f_GifView26 = new F_GifView();
							global::_0011._007E_0084_0006(f_GifView26);
							_0086_0003._007E_0018_0014(f_GifView26, FormStartPosition.CenterParent);
							_009D_0003._007E_0091_0014(f_GifView26);
						}
					}
					else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 3)
					{
						if (4 == 0)
						{
							goto IL_1272;
						}
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0018());
						if (global::_0003._007E_0083(this._0002))
						{
							F_GifView f_GifView27 = new F_GifView();
							global::_0011._007E_0084_0006(f_GifView27);
							_0086_0003._007E_0018_0014(f_GifView27, FormStartPosition.CenterParent);
							_009D_0003._007E_0091_0014(f_GifView27);
						}
					}
					else
					{
						if (global::_000E._007E_000E_0006(cmb_exitramptype) == 4)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0018());
							bool flag3 = global::_0003._007E_0083(this._0002);
							num2 = (flag3 ? 1 : 0);
							goto IL_198a;
						}
						if (global::_000E._007E_000E_0006(cmb_exitramptype) == 5)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
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
							num2 = global::_000E._007E_000E_0006(cmb_exitramptype);
							if (5 == 0)
							{
								goto IL_198a;
							}
							if (num2 == 6)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0018());
								if (global::_0003._007E_0083(this._0002))
								{
									F_GifView f_GifView29 = new F_GifView();
									global::_0011._007E_0084_0006(f_GifView29);
									_0086_0003._007E_0018_0014(f_GifView29, FormStartPosition.CenterParent);
									_009D_0003._007E_0091_0014(f_GifView29);
								}
							}
							else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 7)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0018());
								if (global::_0003._007E_0083(this._0002))
								{
									F_GifView f_GifView30 = new F_GifView();
									global::_0011._007E_0084_0006(f_GifView30);
									_0086_0003._007E_0018_0014(f_GifView30, FormStartPosition.CenterParent);
									_009D_0003._007E_0091_0014(f_GifView30);
								}
							}
							else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 8)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0018());
								if (global::_0003._007E_0083(this._0002))
								{
									F_GifView f_GifView31 = new F_GifView();
									global::_0011._007E_0084_0006(f_GifView31);
									_0086_0003._007E_0018_0014(f_GifView31, FormStartPosition.CenterParent);
									_009D_0003._007E_0091_0014(f_GifView31);
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
									F_GifView f_GifView32 = new F_GifView();
									global::_0011._007E_0084_0006(f_GifView32);
									_0086_0003._007E_0018_0014(f_GifView32, FormStartPosition.CenterParent);
									_009D_0003._007E_0091_0014(f_GifView32);
								}
							}
							else if (global::_000E._007E_000E_0006(cmb_exitramptype) == 11)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0018());
								if (global::_0003._007E_0083(this._0002))
								{
									F_GifView f_GifView33 = new F_GifView();
									global::_0011._007E_0084_0006(f_GifView33);
									_0086_0003._007E_0018_0014(f_GifView33, FormStartPosition.CenterParent);
									_009D_0003._007E_0091_0014(f_GifView33);
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
					}
				}
				else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0012)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_001A());
					if (global::_0003._007E_0083(this._0002))
					{
						F_GifView f_GifView34 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView34);
						_0086_0003._007E_0018_0014(f_GifView34, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView34);
					}
				}
				else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0013)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._007F_0019());
					num = global::_0003._007E_0083(this._0002);
					if (1 == 0)
					{
						goto IL_057f;
					}
					if (num)
					{
						F_GifView f_GifView35 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView35);
						_0086_0003._007E_0018_0014(f_GifView35, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView35);
					}
				}
				else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0014)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001F_001A());
				}
				else
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				}
			}
		}
		goto IL_1f18;
		IL_057f:
		if (num)
		{
			F_GifView f_GifView36 = new F_GifView();
			global::_0011._007E_0084_0006(f_GifView36);
			_0086_0003._007E_0018_0014(f_GifView36, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView36);
		}
		goto IL_1f18;
		IL_198a:
		if (num2 != 0)
		{
			F_GifView f_GifView37 = new F_GifView();
			global::_0011._007E_0084_0006(f_GifView37);
			_0086_0003._007E_0018_0014(f_GifView37, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView37);
		}
		goto IL_1f18;
		IL_1f18:
		_0095._007E_0096_000F(this._0002, false);
		return;
		IL_0c9a:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._001F_0018());
		goto IL_1f18;
		IL_1361:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0018());
		if (global::_0003._007E_0083(this._0002))
		{
			F_GifView f_GifView38 = new F_GifView();
			global::_0011._007E_0084_0006(f_GifView38);
			_0086_0003._007E_0018_0014(f_GifView38, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView38);
		}
		goto IL_1f18;
		IL_0f39:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_0018());
		goto IL_1f18;
		IL_0687:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._0017_001A());
		if (global::_0003._007E_0083(this._0002))
		{
			F_GifView f_GifView39 = new F_GifView();
			global::_0011._007E_0084_0006(f_GifView39);
			_0086_0003._007E_0018_0014(f_GifView39, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView39);
		}
		goto IL_1f18;
		IL_1272:
		if (global::_0003._007E_0083(this._0002))
		{
			F_GifView f_GifView40 = new F_GifView();
			global::_0011._007E_0084_0006(f_GifView40);
			_0086_0003._007E_0018_0014(f_GifView40, FormStartPosition.CenterParent);
			if (3 == 0)
			{
				goto IL_0f39;
			}
			_009D_0003._007E_0091_0014(f_GifView40);
		}
		goto IL_1f18;
	}

	internal void _0006(object P_0, EventArgs P_1)
	{
		ControlUpdate();
	}

	internal void _0007(object P_0, EventArgs P_1)
	{
		if (PropertiesForm.Inited)
		{
			_0094._007E_0088_0007(global::_0084._007E_009D_0006(mwCamParameter), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_001A)) / Tool.Geometry.Diameter);
			PropertiesForm.Inited = false;
			_0088_0003._007E_001A_0014(_0018, _0087_0003._0019_0014(global::_0007._007E_0087_0003(global::_0084._007E_009D_0006(mwCamParameter))));
			PropertiesForm.Inited = true;
		}
	}

	internal void _0008(object P_0, EventArgs P_1)
	{
		if (PropertiesForm.Inited)
		{
			_0094._007E_0088_0007(global::_0084._007E_009D_0006(mwCamParameter), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0018)));
			PropertiesForm.Inited = false;
			if (Tool != null)
			{
				_0088_0003._007E_001A_0014(_001A, _0087_0003._0019_0014(global::_0007._007E_0087_0003(global::_0084._007E_009D_0006(mwCamParameter)) / Tool.Geometry.Diameter * 100.0));
			}
			PropertiesForm.Inited = true;
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
}
