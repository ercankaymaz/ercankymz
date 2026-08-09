using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;
using buEyeBaseVer5;

namespace buMW.CamForms;

public class F_SharpCorner : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public ToolBase5 Tool = null;

	public static List<string> Captions = new List<string>();

	internal IContainer _0001 = null;

	internal ImageList _0001;

	internal Label _0001;

	internal PictureBox _0001;

	public Button btn_ok;

	internal ImageList _0002;

	public Button btn_cancel;

	internal CheckBox _0001;

	internal NumericUpDown _0001;

	internal Label _0002;

	internal NumericUpDown _0002;

	internal Label _0003;

	internal NumericUpDown _0003;

	internal Label _0004;

	internal Label _0005;

	internal NumericUpDown _0004;

	internal RadioButton _0001;

	internal RadioButton _0002;

	public ComboBox cmb_sharpcornertype;

	internal Label _0006;

	public F_SharpCorner()
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
		while (true)
		{
			_0095._0092_000F(this, PropertiesForm.TopMost);
			_0086_0003._0018_0014(this, PropertiesForm.FormPosition);
			bool num = Configration.Mode == CamMode.WireFrame;
			if (2u != 0)
			{
				if (!num)
				{
					break;
				}
				global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_sharpcornertype));
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_sharpcornertype), buMWCaptions.SharpCorners[0]);
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_sharpcornertype), buMWCaptions.SharpCorners[1]);
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_sharpcornertype), buMWCaptions.SharpCorners[2]);
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_sharpcornertype), buMWCaptions.SharpCorners[3]);
				bool flag = _0003_0006._007E_0081_001C(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == WireframeBasedTpCalcParamsSharpCorners.WfbScExtension;
				num = flag;
			}
			bool num2;
			if (num)
			{
				if (false)
				{
					continue;
				}
				_0097._007E_008E_0011(cmb_sharpcornertype, 0);
				_0095._007E_0093_000F(_0002, global::_0003._007E_009C_0002(_009F_0005._007E_0011_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
				bool flag2 = global::_0003._007E_009C_0002(_009F_0005._007E_0011_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
				if (7 == 0)
				{
					goto IL_06ba;
				}
				if (flag2)
				{
					_0088_0003._007E_001A_0014(_0004, _0087_0003._0019_0014(global::_0007._007E_0014_0005(_009F_0005._007E_0011_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
				}
				else
				{
					_0088_0003._007E_001A_0014(_0003, _0087_0003._0019_0014(global::_0007._007E_0015_0005(_009F_0005._007E_0011_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
				}
			}
			else
			{
				bool flag3 = _0003_0006._007E_0081_001C(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == WireframeBasedTpCalcParamsSharpCorners.WfbScLoop;
				if (true)
				{
					if (flag3)
					{
						goto IL_0352;
					}
					if (_0003_0006._007E_0081_001C(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == WireframeBasedTpCalcParamsSharpCorners.WfbScFishtail)
					{
						_0095._007E_0093_000F(_0002, global::_0003._007E_009C_0002(_009F_0005._007E_0011_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
						_0097._007E_008E_0011(cmb_sharpcornertype, 2);
						if (global::_0003._007E_009C_0002(_009F_0005._007E_0011_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))))
						{
							if (2u != 0)
							{
								_0088_0003._007E_001A_0014(_0004, _0087_0003._0019_0014(global::_0007._007E_0014_0005(_009F_0005._007E_0011_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
							}
						}
						else
						{
							_0088_0003._007E_001A_0014(_0003, _0087_0003._0019_0014(global::_0007._007E_0015_0005(_009F_0005._007E_0011_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
						}
					}
					else
					{
						bool flag4 = _0003_0006._007E_0081_001C(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == WireframeBasedTpCalcParamsSharpCorners.WfbScBisectorLine;
						num2 = flag4;
						if (4 == 0)
						{
							goto IL_0708;
						}
						if (num2)
						{
							_0095._007E_0093_000F(_0002, global::_0003._007E_009C_0002(_009F_0005._007E_0011_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
							goto IL_06ba;
						}
					}
				}
			}
			goto IL_07c0;
			IL_06ba:
			_0097._007E_008E_0011(cmb_sharpcornertype, 3);
			bool flag5 = global::_0003._007E_009C_0002(_009F_0005._007E_0011_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
			num2 = flag5;
			goto IL_0708;
			IL_07b8:
			if (6 == 0)
			{
				goto IL_0352;
			}
			goto IL_07c0;
			IL_0352:
			_0095._007E_0093_000F(_0002, global::_0003._007E_009C_0002(_009F_0005._007E_0012_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			_0097._007E_008E_0011(cmb_sharpcornertype, 1);
			if (global::_0003._007E_009C_0002(_009F_0005._007E_0012_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))))
			{
				if (6 == 0)
				{
					goto IL_07b8;
				}
				_0088_0003._007E_001A_0014(_0004, _0087_0003._0019_0014(global::_0007._007E_0014_0005(_009F_0005._007E_0012_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			}
			else
			{
				_0088_0003._007E_001A_0014(_0003, _0087_0003._0019_0014(global::_0007._007E_0015_0005(_009F_0005._007E_0012_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			}
			goto IL_07c0;
			IL_0708:
			if (num2)
			{
				_0088_0003._007E_001A_0014(_0004, _0087_0003._0019_0014(global::_0007._007E_0014_0005(_009F_0005._007E_0011_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
				goto IL_07c0;
			}
			if (0 == 0)
			{
				_0088_0003._007E_001A_0014(_0003, _0087_0003._0019_0014(global::_0007._007E_0015_0005(_009F_0005._007E_0011_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			}
			goto IL_07b8;
			IL_07c0:
			_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0016_0005(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0017_0005(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			break;
		}
		ControlUpdate();
		_008F_0003._007E_0082_0014(this._0001, null);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
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
		_0095._007E_0095_000F(this._0002, false);
		_0095._007E_0095_000F(this._0003, false);
		_0095._007E_0095_000F(this._0002, false);
		_0095._007E_0095_000F(this._0001, false);
		if ((global::_000E._007E_000E_0006(cmb_sharpcornertype) == 1) | (global::_000E._007E_000E_0006(cmb_sharpcornertype) == 2) | (global::_000E._007E_000E_0006(cmb_sharpcornertype) == 3))
		{
			_0095._007E_0095_000F(this._0002, true);
			_0095._007E_0095_000F(this._0003, true);
			_0095._007E_0095_000F(this._0002, true);
			_0095._007E_0095_000F(this._0001, true);
		}
		if (global::_0003._007E_001C(_0002))
		{
			_0095._007E_0095_000F(_0006, true);
			_0095._007E_0095_000F(_0004, true);
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(_0003, false);
		}
		else
		{
			_0095._007E_0095_000F(_0006, false);
			_0095._007E_0095_000F(_0004, false);
			_0095._007E_0095_000F(this._0004, true);
			_0095._007E_0095_000F(_0003, true);
		}
	}

	public void Apply()
	{
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected O, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		bool flag = Configration.Mode == CamMode.WireFrame;
		int num = (flag ? 1 : 0);
		while (num != 0)
		{
			if ((global::_000E._007E_000E_0006(cmb_sharpcornertype) == 0) | (global::_000E._007E_000E_0006(cmb_sharpcornertype) == 2) | (global::_000E._007E_000E_0006(cmb_sharpcornertype) == 3))
			{
				if (global::_000E._007E_000E_0006(cmb_sharpcornertype) == 0)
				{
					_0004_0006._007E_0082_001C(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), WireframeBasedTpCalcParamsSharpCorners.WfbScExtension);
				}
				else
				{
					num = global::_000E._007E_000E_0006(cmb_sharpcornertype);
					if (false)
					{
						continue;
					}
					if (num == 2)
					{
						_0004_0006._007E_0082_001C(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), WireframeBasedTpCalcParamsSharpCorners.WfbScLoop);
					}
					else if (global::_000E._007E_000E_0006(cmb_sharpcornertype) == 3)
					{
						_0004_0006._007E_0082_001C(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), WireframeBasedTpCalcParamsSharpCorners.WfbScBisectorLine);
					}
				}
				if (global::_0003._007E_001C(_0002))
				{
					PercentOrValueParameter val = new PercentOrValueParameter(_0083._007E_009C_0006(mwCamParameter), true);
					_0094._007E_0082_000E(val, _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0004)));
					do
					{
						_0001_0006._007E_0016_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), val);
					}
					while (3 == 0);
				}
				else
				{
					PercentOrValueParameter val2 = new PercentOrValueParameter(_0083._007E_009C_0006(mwCamParameter), false);
					_0094._007E_0083_000E(val2, _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0004)));
					_0001_0006._007E_0016_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), val2);
				}
			}
			if (global::_000E._007E_000E_0006(cmb_sharpcornertype) == 1)
			{
				_0004_0006._007E_0082_001C(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), WireframeBasedTpCalcParamsSharpCorners.WfbScLoop);
				if (global::_0003._007E_001C(_0002))
				{
					PercentOrValueParameter val3 = new PercentOrValueParameter(_0083._007E_009C_0006(mwCamParameter), true);
					_0094._007E_0082_000E(val3, _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0004)));
					_0001_0006._007E_0017_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), val3);
				}
				else
				{
					PercentOrValueParameter val4 = new PercentOrValueParameter(_0083._007E_009C_0006(mwCamParameter), false);
					_0094._007E_0083_000E(val4, _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0004)));
					_0001_0006._007E_0017_0017(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), val4);
				}
			}
			_0094._007E_0084_000E(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
			_0094._007E_0086_000E(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
			break;
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
