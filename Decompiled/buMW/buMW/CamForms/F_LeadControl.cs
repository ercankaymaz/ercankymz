using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks.ToolpathParameters;
using buClass;
using buControls.Forms.WinControlForms.Views;
using buEyeBaseVer5;

namespace buMW.CamForms;

public class F_LeadControl : Form
{
	public FormProperties Properties = new FormProperties();

	public LeadController mwCamLeadController = null;

	public camParameters5 buCamParameter = null;

	public ToolBase5 Tool = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public static List<string> Captions = new List<string>();

	internal IContainer _0001 = null;

	public ComboBox cmb_leadtype;

	internal Label _0001;

	internal CheckBox _0001;

	public ComboBox cmb_axisorientation;

	internal Label _0002;

	internal Label _0003;

	internal NumericUpDown _0001;

	internal RadioButton _0001;

	internal Panel _0001;

	internal NumericUpDown _0002;

	internal Label _0004;

	internal NumericUpDown _0003;

	internal Label _0005;

	internal NumericUpDown _0004;

	internal Label _0006;

	internal NumericUpDown _0005;

	internal Label _0007;

	internal Panel _0002;

	internal NumericUpDown _0006;

	internal Label _0008;

	internal NumericUpDown _0007;

	internal Label _000E;

	internal RadioButton _0002;

	internal NumericUpDown _0008;

	internal Label _000F;

	internal NumericUpDown _000E;

	internal Label _0010;

	public ComboBox cmb_extensiontype;

	internal Label _0011;

	internal Panel _0003;

	internal Panel _0004;

	internal NumericUpDown _000F;

	internal Label _0012;

	internal NumericUpDown _0010;

	internal Label _0013;

	internal Panel _0005;

	internal NumericUpDown _0011;

	internal Label _0014;

	internal NumericUpDown _0012;

	internal Label _0015;

	internal Label _0016;

	internal RadioButton _0003;

	internal RadioButton _0004;

	internal CheckBox _0002;

	internal Label _0017;

	internal Panel _0006;

	internal Label _0018;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal CheckBox _0003;

	internal Button _0001;

	internal CheckBox _0004;

	public F_LeadControl()
	{
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			_0097._008C_0011(this, Properties.Height);
		}
		if (Properties.Width > 10)
		{
			_0097._008D_0011(this, Properties.Width);
		}
		_0095._0092_000F(this, Properties.TopMost);
		_0086_0003._0018_0014(this, Properties.FormPosition);
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_leadtype));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadtype), buMWCaptions.LeadParamsType[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadtype), buMWCaptions.LeadParamsType[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadtype), buMWCaptions.LeadParamsType[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadtype), buMWCaptions.LeadParamsType[8]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadtype), buMWCaptions.LeadParamsType[3]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadtype), buMWCaptions.LeadParamsType[4]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadtype), buMWCaptions.LeadParamsType[5]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadtype), buMWCaptions.LeadParamsType[7]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadtype), buMWCaptions.LeadParamsType[6]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadtype), buMWCaptions.LeadParamsType[14]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadtype), buMWCaptions.LeadParamsType[11]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadtype), buMWCaptions.LeadParamsType[9]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadtype), buMWCaptions.LeadParamsType[10]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_leadtype), buMWCaptions.LeadParamsType[19]);
		if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(mwCamLeadController)) == LeadParamsType.TangentialArc)
		{
			_0097._007E_008E_0011(cmb_leadtype, 0);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(mwCamLeadController)) == LeadParamsType.ReverseTangArc)
		{
			_0097._007E_008E_0011(cmb_leadtype, 1);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(mwCamLeadController)) == LeadParamsType.VerticalTangArc)
		{
			_0097._007E_008E_0011(cmb_leadtype, 2);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(mwCamLeadController)) == LeadParamsType.ReverseVertTangArc)
		{
			_0097._007E_008E_0011(cmb_leadtype, 3);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(mwCamLeadController)) == LeadParamsType.HorizontalTangArc)
		{
			_0097._007E_008E_0011(cmb_leadtype, 4);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(mwCamLeadController)) == LeadParamsType.OrthogonalArc)
		{
			_0097._007E_008E_0011(cmb_leadtype, 5);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(mwCamLeadController)) == LeadParamsType.TangentialLine)
		{
			_0097._007E_008E_0011(cmb_leadtype, 6);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(mwCamLeadController)) == LeadParamsType.ReverseTangLine)
		{
			_0097._007E_008E_0011(cmb_leadtype, 7);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(mwCamLeadController)) == LeadParamsType.OrthogonalLine)
		{
			_0097._007E_008E_0011(cmb_leadtype, 8);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(mwCamLeadController)) == LeadParamsType.ReverseOrthogonalLine)
		{
			_0097._007E_008E_0011(cmb_leadtype, 9);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(mwCamLeadController)) == LeadParamsType.VertProfileRamp)
		{
			_0097._007E_008E_0011(cmb_leadtype, 10);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(mwCamLeadController)) == LeadParamsType.ReverseVertProfileRamp)
		{
			_0097._007E_008E_0011(cmb_leadtype, 11);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(mwCamLeadController)) == LeadParamsType.PositionLine)
		{
			_0097._007E_008E_0011(cmb_leadtype, 12);
		}
		else if (_0013_0006._007E_008D_001C(_0084_0005._007E_008F_0016(mwCamLeadController)) == LeadParamsType.SlantLine)
		{
			_0097._007E_008E_0011(cmb_leadtype, 13);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_axisorientation));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_axisorientation), buMWCaptions.LeadParamsAxisOrientation[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_axisorientation), buMWCaptions.LeadParamsAxisOrientation[1]);
		if (_0018_0006._007E_0096_001C(_0084_0005._007E_008F_0016(mwCamLeadController)) == LeadParamsAxisOrientation.Fixed)
		{
			if (3 == 0)
			{
				goto IL_0c4f;
			}
			_0097._007E_008E_0011(cmb_axisorientation, 0);
		}
		else if (_0018_0006._007E_0096_001C(_0084_0005._007E_008F_0016(mwCamLeadController)) == LeadParamsAxisOrientation.Tangential)
		{
			_0097._007E_008E_0011(cmb_axisorientation, 1);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_extensiontype));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_extensiontype), buMWCaptions.LeadExtensionParamsType[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_extensiontype), buMWCaptions.LeadExtensionParamsType[3]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_extensiontype), buMWCaptions.LeadExtensionParamsType[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_extensiontype), buMWCaptions.LeadExtensionParamsType[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_extensiontype), buMWCaptions.LeadExtensionParamsType[4]);
		if (_001A_0006._007E_0098_001C(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController))) == LeadExtensionParamsType.TpNone)
		{
			_0097._007E_008E_0011(cmb_extensiontype, 0);
		}
		else if (_001A_0006._007E_0098_001C(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController))) == LeadExtensionParamsType.TpVerticalTangArc)
		{
			_0097._007E_008E_0011(cmb_extensiontype, 1);
		}
		else if (_001A_0006._007E_0098_001C(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController))) == LeadExtensionParamsType.TpHorizontalTangArc)
		{
			_0097._007E_008E_0011(cmb_extensiontype, 2);
		}
		else if (_001A_0006._007E_0098_001C(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController))) == LeadExtensionParamsType.TpTangentialLine)
		{
			_0097._007E_008E_0011(cmb_extensiontype, 3);
		}
		else if (_001A_0006._007E_0098_001C(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController))) == LeadExtensionParamsType.TpOrthogonalLine)
		{
			_0097._007E_008E_0011(cmb_extensiontype, 4);
		}
		if (global::_0003._007E_0006_0003(_0084_0005._007E_008F_0016(mwCamLeadController)))
		{
			_0095._007E_0093_000F(this._0001, true);
			_0095._007E_0093_000F(this._0002, false);
		}
		else
		{
			_0095._007E_0093_000F(this._0001, false);
			_0095._007E_0093_000F(this._0002, true);
		}
		if (global::_0003._007E_0007_0003(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController))))
		{
			_0095._007E_0093_000F(this._0003, false);
			_0095._007E_0093_000F(this._0004, true);
		}
		else
		{
			_0095._007E_0093_000F(this._0003, true);
			_0095._007E_0093_000F(this._0004, false);
		}
		_0095._007E_0096_000F(this._0003, global::_0003._007E_0008_0003(_0084_0005._007E_008F_0016(mwCamLeadController)));
		_0095._007E_0096_000F(this._0002, global::_0003._007E_000E_0003(_0084_0005._007E_008F_0016(mwCamLeadController)));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_000F_0003(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController))));
		_0088_0003._007E_001A_0014(_000E, _0087_0003._0019_0014(global::_0007._007E_008A_0005(_0084_0005._007E_008F_0016(mwCamLeadController))));
		_0088_0003._007E_001A_0014(_0008, _0087_0003._0019_0014(global::_0007._007E_008B_0005(_0084_0005._007E_008F_0016(mwCamLeadController))));
		_0088_0003._007E_001A_0014(_0007, _0087_0003._0019_0014(global::_0007._007E_008C_0005(_0084_0005._007E_008F_0016(mwCamLeadController))));
		_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_008D_0005(_0084_0005._007E_008F_0016(mwCamLeadController))));
		_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_008E_0005(_0084_0005._007E_008F_0016(mwCamLeadController))));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_008F_0005(_0084_0005._007E_008F_0016(mwCamLeadController))));
		_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0090_0005(_0084_0005._007E_008F_0016(mwCamLeadController))));
		_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_0091_0005(_0084_0005._007E_008F_0016(mwCamLeadController))));
		goto IL_0c4f;
		IL_0c4f:
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0092_0005(_0084_0005._007E_008F_0016(mwCamLeadController))));
		_0088_0003._007E_001A_0014(_000F, _0087_0003._0019_0014(global::_0007._007E_0093_0005(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController)))));
		_0088_0003._007E_001A_0014(_0010, _0087_0003._0019_0014(global::_0007._007E_0094_0005(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController)))));
		_0088_0003._007E_001A_0014(_0011, _0087_0003._0019_0014(global::_0007._007E_0095_0005(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController)))));
		_0088_0003._007E_001A_0014(_0012, _0087_0003._0019_0014(global::_0007._007E_0096_0005(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController)))));
		ControlUpdate();
		global::_0005._0002._0001(this);
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
	}

	internal void _0001(object P_0, FormClosingEventArgs P_1)
	{
		while (true)
		{
			bool num = Properties.Result == DialogResult.OK;
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
				Properties.Result = DialogResult.Cancel;
				bool flag2;
				do
				{
					flag2 = Properties.FormCloseMode == FormCloseModeType.Dispose;
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
			num2 = Properties.FormCloseMode == FormCloseModeType.Invisible;
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
			Properties.Result = DialogResult.OK;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
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
				Properties.Result = DialogResult.Cancel;
				if (Properties.FormCloseMode == FormCloseModeType.Dispose)
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
		num = Properties.FormCloseMode == FormCloseModeType.Invisible;
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
		num = Properties.FormCloseMode == FormCloseModeType.Invisible;
		goto IL_0093;
	}

	public void ControlUpdate()
	{
		_0095._007E_0095_000F(this._0001, false);
		if (global::_000E._007E_000E_0006(cmb_axisorientation) == 1)
		{
			_0095._007E_0095_000F(this._0001, true);
		}
		_0095._007E_0095_000F(_0008, true);
		_0095._007E_0095_000F(_000E, true);
		_0095._007E_0095_000F(this._0005, true);
		_0095._007E_0095_000F(this._0003, false);
		_0095._007E_0095_000F(this._0002, false);
		_0095._007E_0095_000F(this._0002, true);
		_0095._007E_0095_000F(this._0001, true);
		if (3u != 0)
		{
			_0095._007E_0095_000F(this._0002, true);
			_0095._007E_0094_000F(this._0003, false);
			_0095._007E_0094_000F(this._0001, false);
			if ((global::_000E._007E_000E_0006(cmb_leadtype) == 0) | (global::_000E._007E_000E_0006(cmb_leadtype) == 1) | (global::_000E._007E_000E_0006(cmb_leadtype) == 2) | (global::_000E._007E_000E_0006(cmb_leadtype) == 3) | (global::_000E._007E_000E_0006(cmb_leadtype) == 4) | (global::_000E._007E_000E_0006(cmb_leadtype) == 5))
			{
				if (global::_0003._007E_001C(this._0002))
				{
					_0095._007E_0095_000F(this._0002, true);
					_0095._007E_0095_000F(this._0001, false);
				}
				else
				{
					_0095._007E_0095_000F(this._0002, false);
					_0095._007E_0095_000F(this._0001, true);
				}
				if (global::_000E._007E_000E_0006(cmb_leadtype) == 2)
				{
					_0095._007E_0094_000F(this._0003, true);
				}
			}
			else
			{
				int num;
				if ((global::_000E._007E_000E_0006(cmb_leadtype) == 6) | (global::_000E._007E_000E_0006(cmb_leadtype) == 7) | (global::_000E._007E_000E_0006(cmb_leadtype) == 8) | (global::_000E._007E_000E_0006(cmb_leadtype) == 9) | (global::_000E._007E_000E_0006(cmb_leadtype) == 10) | (global::_000E._007E_000E_0006(cmb_leadtype) == 11) | (global::_000E._007E_000E_0006(cmb_leadtype) == 13))
				{
					_0095._007E_0095_000F(this._0002, false);
					_0095._007E_0093_000F(this._0001, true);
					_0095._007E_0093_000F(this._0002, false);
					_0095._007E_0095_000F(this._0002, false);
					_0095._007E_0095_000F(this._0001, true);
					_0095._007E_0095_000F(this._0005, false);
					_0095._007E_0095_000F(this._0002, false);
					if ((global::_000E._007E_000E_0006(cmb_leadtype) == 8) | (global::_000E._007E_000E_0006(cmb_leadtype) == 9))
					{
						_0095._007E_0095_000F(this._0002, true);
					}
					num = global::_000E._007E_000E_0006(cmb_leadtype);
					if (0 == 0)
					{
						if ((num == 10) | (global::_000E._007E_000E_0006(cmb_leadtype) == 13))
						{
							_0095._007E_0095_000F(this._0003, true);
						}
						goto IL_044f;
					}
				}
				else
				{
					num = global::_000E._007E_000E_0006(cmb_leadtype);
				}
				if (num == 12)
				{
					_0095._007E_0094_000F(this._0001, true);
					_0095._007E_0095_000F(this._0002, false);
					_0095._007E_0095_000F(this._0001, false);
					_0095._007E_0095_000F(_000E, false);
					_0095._007E_0095_000F(this._0002, false);
					_0095._007E_0095_000F(this._0005, false);
				}
			}
		}
		goto IL_044f;
		IL_044f:
		if (global::_000E._007E_000E_0006(cmb_extensiontype) == 0)
		{
			_0095._007E_0095_000F(this._0003, false);
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(this._0001, false);
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(this._0005, false);
		}
		else if ((global::_000E._007E_000E_0006(cmb_extensiontype) == 1) | (global::_000E._007E_000E_0006(cmb_extensiontype) == 2))
		{
			_0095._007E_0095_000F(this._0003, true);
			_0095._007E_0095_000F(this._0004, true);
			_0095._007E_0095_000F(this._0001, true);
			_0095._007E_0095_000F(_0012, true);
			_0095._007E_0095_000F(_0011, true);
			if (global::_0003._007E_001C(this._0003))
			{
				_0095._007E_0095_000F(this._0004, true);
				_0095._007E_0095_000F(this._0005, false);
			}
			else
			{
				_0095._007E_0095_000F(this._0004, false);
				_0095._007E_0095_000F(this._0005, true);
			}
		}
		else if ((global::_000E._007E_000E_0006(cmb_extensiontype) == 3) | (global::_000E._007E_000E_0006(cmb_extensiontype) == 4))
		{
			_0095._007E_0095_000F(this._0003, false);
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(this._0001, false);
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(this._0005, true);
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(this._0005, true);
			_0095._007E_0095_000F(_0012, false);
			_0095._007E_0095_000F(_0011, true);
		}
	}

	public void Apply()
	{
		bool num = global::_000E._007E_000E_0006(cmb_leadtype) == 0;
		bool flag = default(bool);
		if (0 == 0)
		{
			flag = num;
		}
		int num2;
		int num3;
		bool num4;
		if (flag)
		{
			_0086_0005._007E_0090_0016(_0084_0005._007E_008F_0016(mwCamLeadController), LeadParamsType.TangentialArc);
		}
		else if (global::_000E._007E_000E_0006(cmb_leadtype) == 1)
		{
			_0086_0005._007E_0090_0016(_0084_0005._007E_008F_0016(mwCamLeadController), LeadParamsType.ReverseTangArc);
		}
		else if (global::_000E._007E_000E_0006(cmb_leadtype) == 2)
		{
			_0086_0005._007E_0090_0016(_0084_0005._007E_008F_0016(mwCamLeadController), LeadParamsType.VerticalTangArc);
		}
		else if (global::_000E._007E_000E_0006(cmb_leadtype) == 3)
		{
			_0086_0005._007E_0090_0016(_0084_0005._007E_008F_0016(mwCamLeadController), LeadParamsType.ReverseVertTangArc);
		}
		else if (global::_000E._007E_000E_0006(cmb_leadtype) == 4)
		{
			_0086_0005._007E_0090_0016(_0084_0005._007E_008F_0016(mwCamLeadController), LeadParamsType.HorizontalTangArc);
		}
		else if (global::_000E._007E_000E_0006(cmb_leadtype) == 5)
		{
			_0086_0005._007E_0090_0016(_0084_0005._007E_008F_0016(mwCamLeadController), LeadParamsType.OrthogonalArc);
		}
		else if (global::_000E._007E_000E_0006(cmb_leadtype) == 6)
		{
			_0086_0005._007E_0090_0016(_0084_0005._007E_008F_0016(mwCamLeadController), LeadParamsType.TangentialLine);
		}
		else if (global::_000E._007E_000E_0006(cmb_leadtype) == 7)
		{
			_0086_0005._007E_0090_0016(_0084_0005._007E_008F_0016(mwCamLeadController), LeadParamsType.ReverseTangLine);
		}
		else if (global::_000E._007E_000E_0006(cmb_leadtype) == 8)
		{
			_0086_0005._007E_0090_0016(_0084_0005._007E_008F_0016(mwCamLeadController), LeadParamsType.OrthogonalLine);
		}
		else if (global::_000E._007E_000E_0006(cmb_leadtype) == 9)
		{
			_0086_0005._007E_0090_0016(_0084_0005._007E_008F_0016(mwCamLeadController), LeadParamsType.ReverseOrthogonalLine);
		}
		else if (global::_000E._007E_000E_0006(cmb_leadtype) == 10)
		{
			_0086_0005._007E_0090_0016(_0084_0005._007E_008F_0016(mwCamLeadController), LeadParamsType.VertProfileRamp);
		}
		else
		{
			num2 = global::_000E._007E_000E_0006(cmb_leadtype);
			num3 = 11;
			if (num3 == 0)
			{
				goto IL_048c;
			}
			num4 = num2 == num3;
			if (5 == 0)
			{
				goto IL_0492;
			}
			if (num4)
			{
				_0086_0005._007E_0090_0016(_0084_0005._007E_008F_0016(mwCamLeadController), LeadParamsType.ReverseVertProfileRamp);
			}
			else if (global::_000E._007E_000E_0006(cmb_leadtype) == 12)
			{
				_0086_0005._007E_0090_0016(_0084_0005._007E_008F_0016(mwCamLeadController), LeadParamsType.PositionLine);
			}
			else if (global::_000E._007E_000E_0006(cmb_leadtype) == 13)
			{
				_0086_0005._007E_0090_0016(_0084_0005._007E_008F_0016(mwCamLeadController), LeadParamsType.SlantLine);
			}
		}
		if (global::_000E._007E_000E_0006(cmb_extensiontype) == 0)
		{
			_001B_0006._007E_0099_001C(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController)), LeadExtensionParamsType.TpNone);
		}
		else if (global::_000E._007E_000E_0006(cmb_extensiontype) == 1)
		{
			_001B_0006._007E_0099_001C(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController)), LeadExtensionParamsType.TpVerticalTangArc);
		}
		else if (global::_000E._007E_000E_0006(cmb_extensiontype) == 2)
		{
			_001B_0006._007E_0099_001C(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController)), LeadExtensionParamsType.TpHorizontalTangArc);
		}
		else
		{
			if (global::_000E._007E_000E_0006(cmb_extensiontype) != 3)
			{
				num2 = global::_000E._007E_000E_0006(cmb_extensiontype);
				if (2u != 0)
				{
					num3 = 4;
					goto IL_048c;
				}
				goto IL_048e;
			}
			_001B_0006._007E_0099_001C(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController)), LeadExtensionParamsType.TpTangentialLine);
		}
		goto IL_04bc;
		IL_0492:
		if (num4)
		{
			_001B_0006._007E_0099_001C(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController)), LeadExtensionParamsType.TpOrthogonalLine);
		}
		goto IL_04bc;
		IL_048c:
		num2 = ((num2 == num3) ? 1 : 0);
		goto IL_048e;
		IL_048e:
		bool flag2 = (byte)num2 != 0;
		num4 = flag2;
		goto IL_0492;
		IL_04bc:
		if (global::_000E._007E_000E_0006(cmb_axisorientation) == 0)
		{
			_001C_0006._007E_009A_001C(_0084_0005._007E_008F_0016(mwCamLeadController), LeadParamsAxisOrientation.Fixed);
		}
		else if (global::_000E._007E_000E_0006(cmb_axisorientation) == 1)
		{
			_001C_0006._007E_009A_001C(_0084_0005._007E_008F_0016(mwCamLeadController), LeadParamsAxisOrientation.Tangential);
		}
		if (global::_0003._007E_001C(this._0002))
		{
			_0095._007E_0081_0011(_0084_0005._007E_008F_0016(mwCamLeadController), false);
		}
		else
		{
			_0095._007E_0081_0011(_0084_0005._007E_008F_0016(mwCamLeadController), true);
		}
		do
		{
			if (global::_0003._007E_001C(this._0003))
			{
				_0095._007E_0082_0011(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController)), false);
			}
			else
			{
				_0095._007E_0082_0011(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController)), true);
			}
			_0095._007E_0083_0011(_0084_0005._007E_008F_0016(mwCamLeadController), global::_0003._007E_0083(this._0003));
			_0095._007E_0084_0011(_0084_0005._007E_008F_0016(mwCamLeadController), global::_0003._007E_0083(this._0002));
			_0095._007E_0086_0011(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController)), global::_0003._007E_0083(this._0001));
			_0094._007E_0097_000E(_0084_0005._007E_008F_0016(mwCamLeadController), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_000E)));
			_0094._007E_0098_000E(_0084_0005._007E_008F_0016(mwCamLeadController), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0008)));
			_0094._007E_0099_000E(_0084_0005._007E_008F_0016(mwCamLeadController), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0007)));
			_0094._007E_009A_000E(_0084_0005._007E_008F_0016(mwCamLeadController), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0006)));
			_0094._007E_009B_000E(_0084_0005._007E_008F_0016(mwCamLeadController), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
			_0094._007E_009C_000E(_0084_0005._007E_008F_0016(mwCamLeadController), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
			_0094._007E_009D_000E(_0084_0005._007E_008F_0016(mwCamLeadController), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
			_0094._007E_009E_000E(_0084_0005._007E_008F_0016(mwCamLeadController), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
			_0094._007E_009F_000E(_0084_0005._007E_008F_0016(mwCamLeadController), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
			_0094._007E_0001_000F(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_000F)));
		}
		while (8 == 0);
		_0094._007E_0002_000F(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0010)));
		_0094._007E_0003_000F(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0011)));
		_0094._007E_0004_000F(_0019_0006._007E_0097_001C(_0084_0005._007E_008F_0016(mwCamLeadController)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0012)));
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		ControlUpdate();
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		Control obj = (Control)P_0;
		if (0 == 0)
		{
			control = obj;
		}
		while (true)
		{
			int num;
			bool num2;
			bool num3;
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0011)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_001A());
				num = global::_000E._007E_000E_0006(cmb_extensiontype);
				if (false)
				{
					goto IL_0bd4;
				}
				bool flag = num == 3;
				num2 = flag;
				if (0 == 0)
				{
					if (num2)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_001A());
					}
					break;
				}
			}
			else
			{
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_001A());
					break;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0012)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_001A());
					break;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_001A());
					break;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0010)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_001A());
					break;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0007)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_001A());
					break;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_000F)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_001A());
					break;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_001A());
					break;
				}
				num3 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001));
				if (-1 == 0)
				{
					goto IL_0f4d;
				}
				if (num3)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
					break;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
					break;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
					break;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
					break;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
					break;
				}
				num2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002));
			}
			if (num2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				break;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_001A());
				break;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				if (global::_000E._007E_000E_0006(cmb_leadtype) == 10)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_001A());
				}
				break;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				break;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_000E)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_001A());
				break;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0008)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				break;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				break;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_leadtype)))
			{
				if (global::_000E._007E_000E_0006(cmb_leadtype) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_001A());
					if (!global::_0003._007E_0083(this._0004))
					{
						break;
					}
					if (5u != 0)
					{
						F_GifView f_GifView = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView);
						_0086_0003._007E_0018_0014(f_GifView, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView);
						break;
					}
				}
				else
				{
					if (global::_000E._007E_000E_0006(cmb_leadtype) == 1)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_001A());
						if (global::_0003._007E_0083(this._0004))
						{
							F_GifView f_GifView2 = new F_GifView();
							global::_0011._007E_0084_0006(f_GifView2);
							_0086_0003._007E_0018_0014(f_GifView2, FormStartPosition.CenterParent);
							_009D_0003._007E_0091_0014(f_GifView2);
						}
						break;
					}
					if (global::_000E._007E_000E_0006(cmb_leadtype) != 2)
					{
						if (global::_000E._007E_000E_0006(cmb_leadtype) == 3)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_001A());
							if (global::_0003._007E_0083(this._0004))
							{
								F_GifView f_GifView3 = new F_GifView();
								global::_0011._007E_0084_0006(f_GifView3);
								_0086_0003._007E_0018_0014(f_GifView3, FormStartPosition.CenterParent);
								_009D_0003._007E_0091_0014(f_GifView3);
							}
							if (0 == 0)
							{
								break;
							}
						}
						else
						{
							if (global::_000E._007E_000E_0006(cmb_leadtype) == 4)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_001A());
								if (global::_0003._007E_0083(this._0004))
								{
									F_GifView f_GifView4 = new F_GifView();
									global::_0011._007E_0084_0006(f_GifView4);
									_0086_0003._007E_0018_0014(f_GifView4, FormStartPosition.CenterParent);
									_009D_0003._007E_0091_0014(f_GifView4);
								}
								break;
							}
							if (global::_000E._007E_000E_0006(cmb_leadtype) == 5)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._0095_001A());
								if (global::_0003._007E_0083(this._0004))
								{
									F_GifView f_GifView5 = new F_GifView();
									global::_0011._007E_0084_0006(f_GifView5);
									_0086_0003._007E_0018_0014(f_GifView5, FormStartPosition.CenterParent);
									_009D_0003._007E_0091_0014(f_GifView5);
								}
								break;
							}
							if (global::_000E._007E_000E_0006(cmb_leadtype) == 6)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._0096_001A());
								if (global::_0003._007E_0083(this._0004))
								{
									F_GifView f_GifView6 = new F_GifView();
									global::_0011._007E_0084_0006(f_GifView6);
									_0086_0003._007E_0018_0014(f_GifView6, FormStartPosition.CenterParent);
									_009D_0003._007E_0091_0014(f_GifView6);
								}
								break;
							}
							if (global::_000E._007E_000E_0006(cmb_leadtype) == 7)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._0097_001A());
								if (global::_0003._007E_0083(this._0004))
								{
									F_GifView f_GifView7 = new F_GifView();
									global::_0011._007E_0084_0006(f_GifView7);
									_0086_0003._007E_0018_0014(f_GifView7, FormStartPosition.CenterParent);
									_009D_0003._007E_0091_0014(f_GifView7);
								}
								break;
							}
							if (global::_000E._007E_000E_0006(cmb_leadtype) != 8)
							{
								if (global::_000E._007E_000E_0006(cmb_leadtype) == 9)
								{
									_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
									break;
								}
								bool flag2 = global::_000E._007E_000E_0006(cmb_leadtype) == 10;
								num = (flag2 ? 1 : 0);
								goto IL_0bd4;
							}
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0098_001A());
							if (global::_0003._007E_0083(this._0004))
							{
								F_GifView f_GifView8 = new F_GifView();
								global::_0011._007E_0084_0006(f_GifView8);
								_0086_0003._007E_0018_0014(f_GifView8, FormStartPosition.CenterParent);
								_009D_0003._007E_0091_0014(f_GifView8);
							}
						}
						if (4u != 0)
						{
							break;
						}
						continue;
					}
					if (false)
					{
						break;
					}
				}
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_001A());
				if (global::_0003._007E_0083(this._0004))
				{
					F_GifView f_GifView9 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView9);
					_0086_0003._007E_0018_0014(f_GifView9, FormStartPosition.CenterParent);
					if (8u != 0)
					{
						_009D_0003._007E_0091_0014(f_GifView9);
						break;
					}
					goto IL_0fee;
				}
				break;
			}
			if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_extensiontype)))
			{
				break;
			}
			if (global::_000E._007E_000E_0006(cmb_extensiontype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				if (global::_0003._007E_0083(this._0004))
				{
					F_GifView f_GifView10 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView10);
					_0086_0003._007E_0018_0014(f_GifView10, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView10);
				}
				if (3 == 0)
				{
					goto IL_0fee;
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_extensiontype) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009B_001A());
				if (global::_0003._007E_0083(this._0004))
				{
					F_GifView f_GifView11 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView11);
					_0086_0003._007E_0018_0014(f_GifView11, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView11);
				}
			}
			else
			{
				if (global::_000E._007E_000E_0006(cmb_extensiontype) != 2)
				{
					num3 = global::_000E._007E_000E_0006(cmb_extensiontype) == 3;
					goto IL_0f4d;
				}
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009C_001A());
				if (global::_0003._007E_0083(this._0004))
				{
					F_GifView f_GifView12 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView12);
					_0086_0003._007E_0018_0014(f_GifView12, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView12);
				}
			}
			goto IL_1036;
			IL_1036:
			if (0 == 0)
			{
				break;
			}
			goto IL_0c55;
			IL_0bd4:
			if (num != 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0099_001A());
				if (global::_0003._007E_0083(this._0004))
				{
					F_GifView f_GifView13 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView13);
					_0086_0003._007E_0018_0014(f_GifView13, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView13);
				}
				break;
			}
			bool flag3 = global::_000E._007E_000E_0006(cmb_leadtype) == 11;
			goto IL_0c55;
			IL_0fee:
			if (global::_0003._007E_0083(this._0004))
			{
				F_GifView f_GifView14 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView14);
				_0086_0003._007E_0018_0014(f_GifView14, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView14);
			}
			goto IL_1036;
			IL_0f4d:
			if (num3)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009D_001A());
				if (global::_0003._007E_0083(this._0004))
				{
					F_GifView f_GifView15 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView15);
					_0086_0003._007E_0018_0014(f_GifView15, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView15);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_extensiontype) == 4)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009E_001A());
				goto IL_0fee;
			}
			goto IL_1036;
			IL_0c55:
			if (flag3)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009A_001A());
				if (global::_0003._007E_0083(this._0004))
				{
					F_GifView f_GifView16 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView16);
					_0086_0003._007E_0018_0014(f_GifView16, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView16);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadtype) == 12)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				if (global::_0003._007E_0083(this._0004))
				{
					F_GifView f_GifView17 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView17);
					_0086_0003._007E_0018_0014(f_GifView17, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView17);
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_leadtype) == 13)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			}
			break;
		}
		_0095._007E_0096_000F(this._0004, false);
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		bool num = Properties.Inited;
		if (0 == 0)
		{
			if (!num)
			{
				return;
			}
			ControlUpdate();
			bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_leadtype));
			while (0 == 0)
			{
				if (flag)
				{
					if (global::_000E._007E_000E_0006(cmb_leadtype) != 0)
					{
						goto IL_00b9;
					}
					if (false)
					{
						continue;
					}
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_001A());
				}
				goto IL_03c8;
			}
			goto IL_0206;
		}
		goto IL_04f4;
		IL_027f:
		if (6u != 0)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0098_001A());
			goto IL_03c8;
		}
		goto IL_0514;
		IL_0206:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._0096_001A());
		goto IL_03c8;
		IL_02fc:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._0099_001A());
		goto IL_03c8;
		IL_04f4:
		if (num)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._009E_001A());
		}
		goto IL_0514;
		IL_03c8:
		bool flag2 = default(bool);
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_extensiontype)))
		{
			if (global::_000E._007E_000E_0006(cmb_extensiontype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			}
			else if (global::_000E._007E_000E_0006(cmb_extensiontype) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009B_001A());
			}
			else
			{
				if (global::_000E._007E_000E_0006(cmb_extensiontype) != 2)
				{
					flag2 = global::_000E._007E_000E_0006(cmb_extensiontype) == 3;
					goto IL_04ba;
				}
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009C_001A());
			}
		}
		goto IL_0514;
		IL_00b9:
		if (global::_000E._007E_000E_0006(cmb_leadtype) == 1)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_001A());
		}
		else if (global::_000E._007E_000E_0006(cmb_leadtype) == 2)
		{
			if (6 == 0)
			{
				goto IL_04ba;
			}
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_001A());
		}
		else if (global::_000E._007E_000E_0006(cmb_leadtype) == 3)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_001A());
			if (false)
			{
				goto IL_02fc;
			}
		}
		else if (global::_000E._007E_000E_0006(cmb_leadtype) == 4)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_001A());
		}
		else if (global::_000E._007E_000E_0006(cmb_leadtype) == 5)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0095_001A());
		}
		else
		{
			if (global::_000E._007E_000E_0006(cmb_leadtype) == 6)
			{
				goto IL_0206;
			}
			if (global::_000E._007E_000E_0006(cmb_leadtype) == 7)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0097_001A());
				if (false)
				{
					goto IL_027f;
				}
			}
			else
			{
				if (global::_000E._007E_000E_0006(cmb_leadtype) == 8)
				{
					goto IL_027f;
				}
				if (global::_000E._007E_000E_0006(cmb_leadtype) == 9)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				}
				else
				{
					if (global::_000E._007E_000E_0006(cmb_leadtype) == 10)
					{
						goto IL_02fc;
					}
					if (global::_000E._007E_000E_0006(cmb_leadtype) == 11)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._009A_001A());
					}
					else if (global::_000E._007E_000E_0006(cmb_leadtype) == 12)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
					}
					else if (global::_000E._007E_000E_0006(cmb_leadtype) == 13)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
					}
				}
			}
		}
		goto IL_03c8;
		IL_04ba:
		if (flag2)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._009D_001A());
			goto IL_0514;
		}
		bool flag3 = global::_000E._007E_000E_0006(cmb_extensiontype) == 4;
		num = flag3;
		goto IL_04f4;
		IL_0514:
		if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_axisorientation)))
		{
			return;
		}
		if (global::_000E._007E_000E_0006(cmb_axisorientation) == 0)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._009F_001A());
			if (7 == 0)
			{
				goto IL_03c8;
			}
			return;
		}
		if (global::_000E._007E_000E_0006(cmb_axisorientation) == 1)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0001_001B());
		}
	}

	internal void _0005(object P_0, EventArgs P_1)
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
