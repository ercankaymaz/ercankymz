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

public class F_StockDef : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public ToolBase5 Tool = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public static List<string> Captions = new List<string>();

	internal IContainer _0001 = null;

	internal Panel _0001;

	internal Panel _0002;

	internal NumericUpDown _0001;

	internal NumericUpDown _0002;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Label _0001;

	internal NumericUpDown _0003;

	public ComboBox combo_stocktype;

	internal Label _0002;

	internal Label _0003;

	internal Label _0004;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal CheckBox _0001;

	internal Label _0005;

	public ComboBox combo_tool;

	internal Label _0006;

	internal Label _0007;

	internal NumericUpDown _0004;

	internal Button _0001;

	internal CheckBox _0002;

	public ComboBox combo_direction;

	internal Label _0008;

	public CheckBox chk_stovkhasundercut;

	public Panel pnl_area;

	internal CheckBox _0003;

	internal Label _000E;

	internal NumericUpDown _0005;

	public F_StockDef()
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
		if (!Configration.isTriangularMeshAdvanced)
		{
			_0095._007E_007F_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), false);
		}
		_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(buCamParameter.Options.StockHeight));
		_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0011_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0095._007E_0096_000F(chk_stovkhasundercut, global::_0003._007E_009A_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0012_0005(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0013_0005(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0013_0005(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)))));
		if (_0095_0005._007E_009F_0016(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter))) == CollCtrlOpStockParamsStockOffsetMode.SomExpand)
		{
			_0095._007E_0093_000F(this._0001, true);
		}
		else
		{
			_0095._007E_0093_000F(this._0002, true);
		}
		if (_0096_0005._007E_0001_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter))) == CollCtrlOpStockParamsStockType.StBoundingBox)
		{
			_0097._007E_008E_0011(combo_stocktype, 0);
		}
		else if (_0096_0005._007E_0001_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter))) == CollCtrlOpStockParamsStockType.StSurfaces)
		{
			_0097._007E_008E_0011(combo_stocktype, 1);
		}
		else
		{
			_0097._007E_008E_0011(combo_stocktype, 2);
		}
		if (_0097_0005._007E_0002_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter))) == CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolInside)
		{
			_0097._007E_008E_0011(combo_tool, 0);
		}
		else if (_0097_0005._007E_0002_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter))) == CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolCenter)
		{
			_0097._007E_008E_0011(combo_tool, 1);
		}
		else
		{
			_0097._007E_008E_0011(combo_tool, 2);
		}
		if (_0098_0005._007E_0003_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter))) == CollCtrlOpStockParamsStockDirection.StDirectionInX)
		{
			_0097._007E_008E_0011(combo_direction, 0);
		}
		else if (_0098_0005._007E_0003_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter))) == CollCtrlOpStockParamsStockDirection.StDirectionInY)
		{
			_0097._007E_008E_0011(combo_direction, 1);
		}
		else if (_0098_0005._007E_0003_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter))) == CollCtrlOpStockParamsStockDirection.StDirectionInZ)
		{
			_0097._007E_008E_0011(combo_direction, 2);
		}
		else if (_0098_0005._007E_0003_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter))) == CollCtrlOpStockParamsStockDirection.StDirectionCustomDefined)
		{
			_0097._007E_008E_0011(combo_direction, 3);
		}
		else
		{
			_0097._007E_008E_0011(combo_direction, 4);
		}
		ControlUpdate();
		global::_0005._0002._0001(this);
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
		_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0002));
		if (0 == 0)
		{
			_0095._007E_0095_000F(_0007, global::_0003._007E_0083(this._0002));
			if (0 == 0)
			{
				_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0002));
				_0095._007E_0095_000F(_0006, global::_0003._007E_0083(this._0002));
				_0095._007E_0095_000F(combo_tool, global::_0003._007E_0083(this._0002));
				goto IL_00c6;
			}
		}
		goto IL_01ed;
		IL_01b5:
		_0095._007E_0095_000F(_000E, true);
		_0095._007E_0095_000F(chk_stovkhasundercut, true);
		_0095._007E_0095_000F(pnl_area, true);
		goto IL_01ed;
		IL_01ed:
		if (global::_000E._007E_000E_0006(combo_stocktype) == 2)
		{
			_0095._007E_0095_000F(chk_stovkhasundercut, false);
			_0095._007E_0095_000F(pnl_area, false);
		}
		bool flag = !Configration.isTriangularMeshAdvanced;
		if (5u != 0)
		{
			if (flag)
			{
				_0095._007E_0095_000F(pnl_area, false);
				_0095._007E_0095_000F(chk_stovkhasundercut, false);
			}
			return;
		}
		goto IL_00c6;
		IL_00c6:
		if (global::_0003._007E_001C(this._0001))
		{
			_0095._007E_0095_000F(this._0001, true);
			_0095._007E_0095_000F(this._0002, false);
		}
		else
		{
			_0095._007E_0095_000F(this._0001, false);
			_0095._007E_0095_000F(this._0002, true);
		}
		_0095._007E_0095_000F(this._0005, false);
		_0095._007E_0095_000F(_000E, false);
		if (global::_000E._007E_000E_0006(combo_stocktype) == 0)
		{
			_0095._007E_0095_000F(chk_stovkhasundercut, false);
			_0095._007E_0095_000F(pnl_area, true);
			if (4 == 0)
			{
				goto IL_01b5;
			}
		}
		if (global::_000E._007E_000E_0006(combo_stocktype) == 1)
		{
			_0095._007E_0095_000F(this._0005, true);
			goto IL_01b5;
		}
		goto IL_01ed;
	}

	public void Apply()
	{
		_0094._007E_007F_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
		_0095._007E_007F_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(chk_stovkhasundercut));
		_0094._007E_0080_000E(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
		_0094._007E_0081_000E(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		_0094._007E_0081_000E(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		buCamParameter.Options.StockHeight = _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005));
		if (global::_000E._007E_000E_0006(combo_stocktype) == 0)
		{
			_0016_0002._007E_001E_0012(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)), CollCtrlOpStockParamsStockType.StBoundingBox);
		}
		else if (global::_000E._007E_000E_0006(combo_stocktype) == 1)
		{
			_0016_0002._007E_001E_0012(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)), CollCtrlOpStockParamsStockType.StSurfaces);
		}
		else if (global::_000E._007E_000E_0006(combo_stocktype) == 2)
		{
			_0016_0002._007E_001E_0012(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)), CollCtrlOpStockParamsStockType.St2dContainment);
		}
		if (global::_000E._007E_000E_0006(combo_tool) == 0)
		{
			_0099_0005._007E_0004_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)), CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolInside);
		}
		else if (global::_000E._007E_000E_0006(combo_tool) == 1)
		{
			_0099_0005._007E_0004_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)), CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolCenter);
		}
		else if (global::_000E._007E_000E_0006(combo_tool) == 2)
		{
			_0099_0005._007E_0004_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)), CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolOutside);
		}
		if (global::_000E._007E_000E_0006(combo_direction) == 0)
		{
			_009A_0005._007E_0005_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)), CollCtrlOpStockParamsStockDirection.StDirectionInX);
		}
		else if (global::_000E._007E_000E_0006(combo_direction) == 1)
		{
			_009A_0005._007E_0005_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)), CollCtrlOpStockParamsStockDirection.StDirectionInY);
		}
		else if (global::_000E._007E_000E_0006(combo_direction) == 2)
		{
			_009A_0005._007E_0005_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)), CollCtrlOpStockParamsStockDirection.StDirectionInZ);
		}
		else if (global::_000E._007E_000E_0006(combo_direction) == 3)
		{
			_009A_0005._007E_0005_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)), CollCtrlOpStockParamsStockDirection.StDirectionCustomDefined);
		}
		else if (global::_000E._007E_000E_0006(combo_direction) == 4)
		{
			_009A_0005._007E_0005_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)), CollCtrlOpStockParamsStockDirection.StDirectionMachiningDirection);
		}
		if (global::_0003._007E_001C(this._0001))
		{
			_009B_0005._007E_0006_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)), CollCtrlOpStockParamsStockOffsetMode.SomExpand);
		}
		else
		{
			_009B_0005._007E_0006_0017(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)), CollCtrlOpStockParamsStockOffsetMode.SomShrink);
		}
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		ControlUpdate();
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		bool num = PropertiesForm.Inited;
		while (true)
		{
			if (0 == 0)
			{
				bool flag = !num;
				if (false)
				{
					goto IL_005a;
				}
				num = flag;
			}
			if (false)
			{
				continue;
			}
			if (!num)
			{
				PropertiesForm.Inited = false;
				if (6u != 0)
				{
					Apply();
					goto IL_0053;
				}
			}
			goto IL_0066;
			IL_0053:
			ControlUpdate();
			goto IL_005a;
			IL_005a:
			PropertiesForm.Inited = true;
			goto IL_0066;
			IL_0066:
			if (true)
			{
				break;
			}
			goto IL_0053;
		}
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
		bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(combo_stocktype));
		while (true)
		{
			if (flag)
			{
				if (1 == 0)
				{
					continue;
				}
				if (global::_000E._007E_000E_0006(combo_stocktype) == 0)
				{
					goto IL_0092;
				}
				if (global::_000E._007E_000E_0006(combo_stocktype) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0018_001C());
				}
				else if (global::_000E._007E_000E_0006(combo_stocktype) == 2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0019_001C());
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(combo_direction)))
			{
				if (global::_000E._007E_000E_0006(combo_direction) == 0)
				{
					goto IL_016c;
				}
				if (global::_000E._007E_000E_0006(combo_direction) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				}
				else
				{
					if (global::_000E._007E_000E_0006(combo_direction) == 2)
					{
						goto IL_01e6;
					}
					if (global::_000E._007E_000E_0006(combo_direction) == 3)
					{
						if (0 == 0)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
						}
					}
					else if (global::_000E._007E_000E_0006(combo_direction) == 4 && 0 == 0)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
					}
				}
			}
			goto IL_027c;
			IL_01e6:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			goto IL_027c;
			IL_027c:
			while (true)
			{
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(combo_tool)))
				{
					bool flag2 = global::_000E._007E_000E_0006(combo_tool) == 0;
					if (5 == 0)
					{
						break;
					}
					if (flag2)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0012_0018());
					}
					else
					{
						bool num = global::_000E._007E_000E_0006(combo_tool) == 1;
						if (0 == 0)
						{
							if (num)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._0011_0018());
								goto IL_035b;
							}
							num = global::_000E._007E_000E_0006(combo_tool) == 2;
						}
						if (num)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0013_0018());
						}
					}
				}
				goto IL_035b;
				IL_035b:
				PropertiesForm.Inited = false;
				Apply();
				if (4 == 0)
				{
					continue;
				}
				goto IL_0374;
			}
			goto IL_0092;
			IL_0374:
			ControlUpdate();
			if (5u != 0)
			{
				break;
			}
			goto IL_016c;
			IL_0092:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0017_001C());
			goto IL_027c;
			IL_016c:
			if (1 == 0)
			{
				goto IL_01e6;
			}
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			goto IL_027c;
		}
		PropertiesForm.Inited = true;
	}

	internal void _0005(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		Control obj = (Control)P_0;
		if (0 == 0)
		{
			control = obj;
		}
		while (true)
		{
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(combo_stocktype)))
			{
				if (global::_000E._007E_000E_0006(combo_stocktype) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0017_001C());
					if (global::_0003._007E_0083(this._0003))
					{
						F_GifView f_GifView = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView);
						_0086_0003._007E_0018_0014(f_GifView, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView);
					}
					break;
				}
				if (global::_000E._007E_000E_0006(combo_stocktype) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0018_001C());
					if (global::_0003._007E_0083(this._0003))
					{
						F_GifView f_GifView2 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView2);
						_0086_0003._007E_0018_0014(f_GifView2, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView2);
					}
					break;
				}
				goto IL_014e;
			}
			bool num = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003));
			int num2;
			while (true)
			{
				bool flag = num;
				if (3 == 0)
				{
					break;
				}
				if (flag)
				{
					goto IL_0202;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
				{
					goto IL_0252;
				}
				bool flag2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001));
				num2 = (flag2 ? 1 : 0);
				if (6u != 0)
				{
					if (num2 != 0)
					{
						goto IL_033f;
					}
					if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
					{
						goto IL_041a;
					}
					if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
					{
						goto IL_04fb;
					}
					if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
					{
						goto IL_05d3;
					}
					num = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004));
					if (4 == 0)
					{
						continue;
					}
					goto IL_0673;
				}
				goto IL_078e;
			}
			continue;
			IL_041a:
			if (global::_000E._007E_000E_0006(combo_stocktype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001B_001C());
				break;
			}
			bool flag3 = global::_000E._007E_000E_0006(combo_stocktype) == 1;
			bool num3 = flag3;
			if (3u != 0)
			{
				if (num3)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_001C());
				}
				else if (global::_000E._007E_000E_0006(combo_stocktype) == 2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001D_001C());
				}
				break;
			}
			goto IL_0547;
			IL_014e:
			if (global::_000E._007E_000E_0006(combo_stocktype) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0019_001C());
				if (global::_0003._007E_0083(this._0003))
				{
					F_GifView f_GifView3 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView3);
					_0086_0003._007E_0018_0014(f_GifView3, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView3);
				}
			}
			break;
			IL_033f:
			if (global::_000E._007E_000E_0006(combo_stocktype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001E_001C());
			}
			else if (global::_000E._007E_000E_0006(combo_stocktype) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001F_001C());
			}
			else if (global::_000E._007E_000E_0006(combo_stocktype) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._007F_001C());
			}
			break;
			IL_078e:
			if (num2 == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0015_0018());
				if (global::_0003._007E_0083(this._0003))
				{
					F_GifView f_GifView4 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView4);
					_0086_0003._007E_0018_0014(f_GifView4, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView4);
				}
			}
			break;
			IL_05d3:
			if (0 == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0080_001C());
				if (global::_0003._007E_0083(this._0003))
				{
					F_GifView f_GifView5 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView5);
					if (0 == 0)
					{
						_0086_0003._007E_0018_0014(f_GifView5, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView5);
						break;
					}
					goto IL_014e;
				}
				break;
			}
			goto IL_075e;
			IL_0547:
			if (!num3)
			{
				if (global::_000E._007E_000E_0006(combo_stocktype) == 2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._007F_001C());
				}
				break;
			}
			goto IL_054d;
			IL_04fb:
			if (global::_000E._007E_000E_0006(combo_stocktype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001E_001C());
				break;
			}
			num3 = global::_000E._007E_000E_0006(combo_stocktype) == 1;
			goto IL_0547;
			IL_0673:
			F_GifView f_GifView7;
			if (num)
			{
				if (global::_000E._007E_000E_0006(combo_tool) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0014_0018());
					if (global::_0003._007E_0083(this._0003))
					{
						F_GifView f_GifView6 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView6);
						_0086_0003._007E_0018_0014(f_GifView6, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView6);
					}
					break;
				}
				if (global::_000E._007E_000E_0006(combo_tool) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0011_0018());
					if (global::_0003._007E_0083(this._0003))
					{
						f_GifView7 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView7);
						goto IL_075e;
					}
					break;
				}
				num2 = global::_000E._007E_000E_0006(combo_tool);
				goto IL_078e;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(chk_stovkhasundercut)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				if (global::_0003._007E_0083(this._0003))
				{
					F_GifView f_GifView8 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView8);
					_0086_0003._007E_0018_0014(f_GifView8, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView8);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			}
			break;
			IL_0202:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001A_001C());
			break;
			IL_0252:
			if (0 == 0)
			{
				if (global::_000E._007E_000E_0006(combo_stocktype) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001B_001C());
				}
				else if (global::_000E._007E_000E_0006(combo_stocktype) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_001C());
				}
				else if (global::_000E._007E_000E_0006(combo_stocktype) == 2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001D_001C());
					if (7 == 0)
					{
					}
				}
				break;
			}
			goto IL_054d;
			IL_054d:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001F_001C());
			break;
			IL_075e:
			_0086_0003._007E_0018_0014(f_GifView7, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView7);
			break;
		}
		do
		{
			_0095._007E_0096_000F(this._0003, false);
		}
		while (-1 == 0);
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
