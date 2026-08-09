using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriMStockDef : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

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

	internal CheckBox _0001;

	internal Label _0004;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal Panel _0003;

	internal CheckBox _0002;

	internal Label _0005;

	public ComboBox combo_tool;

	internal Label _0006;

	internal Label _0007;

	internal NumericUpDown _0004;

	internal Button _0001;

	internal CheckBox _0003;

	public ComboBox combo_direction;

	internal Label _0008;

	public F_MwTriMStockDef()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		bool flag = Properties.Height > 10;
		while (true)
		{
			bool num = flag;
			if (5 == 0)
			{
				goto IL_03bc;
			}
			if (num)
			{
				_0097._008C_0011(this, Properties.Height);
			}
			goto IL_04b5;
			IL_0461:
			UpdateControlFromType();
			Properties.Result = DialogResult.None;
			if (0 == 0)
			{
				break;
			}
			goto IL_0072;
			IL_0072:
			_0097._008D_0011(this, Properties.Width);
			if (6 == 0)
			{
				goto IL_04b5;
			}
			if (false)
			{
				continue;
			}
			goto IL_0091;
			IL_03bc:
			if (num)
			{
				_0097._007E_008E_0011(combo_direction, 1);
				goto IL_0461;
			}
			bool flag2 = _0098_0005._007E_0003_0017(_0015_0002._007E_001D_0012(Par)) == CollCtrlOpStockParamsStockDirection.StDirectionInZ;
			bool num2 = flag2;
			goto IL_03fc;
			IL_0091:
			_0095._0092_000F(this, Properties.TopMost);
			_0086_0003._0018_0014(this, Properties.FormPosition);
			if (!buMWCalcs.AdvancedTriMesh)
			{
				_0095._007E_007F_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), false);
			}
			_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0011_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
			_0095._007E_0096_000F(this._0001, global::_0003._007E_009A_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
			_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0012_0005(_0015_0002._007E_001D_0012(Par))));
			_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0013_0005(_0015_0002._007E_001D_0012(Par))));
			_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0013_0005(_0015_0002._007E_001D_0012(Par))));
			if (_0095_0005._007E_009F_0016(_0015_0002._007E_001D_0012(Par)) == CollCtrlOpStockParamsStockOffsetMode.SomExpand)
			{
				_0095._007E_0093_000F(this._0001, true);
			}
			else
			{
				_0095._007E_0093_000F(this._0002, true);
			}
			num2 = _0096_0005._007E_0001_0017(_0015_0002._007E_001D_0012(Par)) == CollCtrlOpStockParamsStockType.StBoundingBox;
			if (1 == 0)
			{
				goto IL_03fc;
			}
			if (num2)
			{
				_0097._007E_008E_0011(combo_stocktype, 0);
			}
			else if (_0096_0005._007E_0001_0017(_0015_0002._007E_001D_0012(Par)) == CollCtrlOpStockParamsStockType.StSurfaces)
			{
				_0097._007E_008E_0011(combo_stocktype, 1);
			}
			else
			{
				_0097._007E_008E_0011(combo_stocktype, 2);
			}
			if (_0097_0005._007E_0002_0017(_0015_0002._007E_001D_0012(Par)) == CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolInside)
			{
				_0097._007E_008E_0011(combo_tool, 0);
			}
			else if (_0097_0005._007E_0002_0017(_0015_0002._007E_001D_0012(Par)) == CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolCenter)
			{
				_0097._007E_008E_0011(combo_tool, 1);
			}
			else
			{
				_0097._007E_008E_0011(combo_tool, 2);
			}
			if (_0098_0005._007E_0003_0017(_0015_0002._007E_001D_0012(Par)) == CollCtrlOpStockParamsStockDirection.StDirectionInX)
			{
				_0097._007E_008E_0011(combo_direction, 0);
				goto IL_0461;
			}
			num = _0098_0005._007E_0003_0017(_0015_0002._007E_001D_0012(Par)) == CollCtrlOpStockParamsStockDirection.StDirectionInY;
			goto IL_03bc;
			IL_04b5:
			if (Properties.Width > 10)
			{
				goto IL_0072;
			}
			goto IL_0091;
			IL_03fc:
			if (num2)
			{
				_0097._007E_008E_0011(combo_direction, 2);
			}
			else if (_0098_0005._007E_0003_0017(_0015_0002._007E_001D_0012(Par)) == CollCtrlOpStockParamsStockDirection.StDirectionCustomDefined)
			{
				_0097._007E_008E_0011(combo_direction, 3);
			}
			else
			{
				_0097._007E_008E_0011(combo_direction, 4);
			}
			goto IL_0461;
		}
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
		Apply();
		Properties.Result = DialogResult.OK;
		bool num = Properties.FormCloseMode == FormCloseModeType.Dispose;
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
			bool flag = Properties.FormCloseMode == FormCloseModeType.Invisible;
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
			Properties.Result = DialogResult.Cancel;
		}
		bool num = Properties.FormCloseMode == FormCloseModeType.Dispose;
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
			num = Properties.FormCloseMode == FormCloseModeType.Invisible;
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

	public void UpdateControlFromType()
	{
		bool flag2 = default(bool);
		while (true)
		{
			_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0003));
			if (6 == 0)
			{
				goto IL_017f;
			}
			if (true)
			{
				_0095._007E_0095_000F(_0007, global::_0003._007E_0083(this._0003));
				_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0003));
			}
			_0095._007E_0095_000F(_0006, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(combo_tool, global::_0003._007E_0083(this._0003));
			bool flag = global::_0003._007E_001C(this._0001);
			if (0 == 0)
			{
				if (flag)
				{
					_0095._007E_0095_000F(this._0001, true);
					goto IL_00ef;
				}
				goto IL_0106;
			}
			goto IL_01ae;
			IL_017f:
			if (flag2)
			{
				_0095._007E_0095_000F(this._0001, true);
				if (7 == 0)
				{
					continue;
				}
				_0095._007E_0095_000F(this._0003, true);
			}
			goto IL_01ae;
			IL_0106:
			_0095._007E_0095_000F(this._0001, false);
			_0095._007E_0095_000F(this._0002, true);
			goto IL_012b;
			IL_012b:
			bool flag3 = global::_000E._007E_000E_0006(combo_stocktype) == 0;
			int num = (flag3 ? 1 : 0);
			do
			{
				if (num != 0)
				{
					_0095._007E_0095_000F(this._0001, false);
					_0095._007E_0095_000F(this._0003, true);
				}
				num = global::_000E._007E_000E_0006(combo_stocktype);
			}
			while (6 == 0);
			flag2 = num == 1;
			goto IL_017f;
			IL_01ae:
			if (global::_000E._007E_000E_0006(combo_stocktype) == 2)
			{
				_0095._007E_0095_000F(this._0001, false);
				_0095._007E_0095_000F(this._0003, false);
			}
			if (buMWCalcs.AdvancedTriMesh)
			{
				break;
			}
			_0095._007E_0095_000F(this._0003, false);
			if (0 == 0)
			{
				_0095._007E_0095_000F(this._0001, false);
				if (7u != 0)
				{
					break;
				}
				goto IL_00ef;
			}
			goto IL_0106;
			IL_00ef:
			_0095._007E_0095_000F(this._0002, false);
			goto IL_012b;
		}
	}

	public void Apply()
	{
		_0094 obj = _0094._007E_007F_000E;
		TriangleMeshBasedTpCalcParams obj2 = _009A._007E_009E_0011(_008C._007E_000E_0007(Par));
		double num = _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003));
		if (0 == 0)
		{
			obj(obj2, num);
		}
		_0095._007E_007F_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0001));
		_0094._007E_0080_000E(_0015_0002._007E_001D_0012(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
		_0094._007E_0081_000E(_0015_0002._007E_001D_0012(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		_0094._007E_0081_000E(_0015_0002._007E_001D_0012(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		int num2 = global::_000E._007E_000E_0006(combo_stocktype);
		int num3;
		if (5u != 0)
		{
			num3 = 0;
			goto IL_013f;
		}
		goto IL_0399;
		IL_02d7:
		if (num2 != num3)
		{
			goto IL_0308;
		}
		_009A_0005._007E_0005_0017(_0015_0002._007E_001D_0012(Par), CollCtrlOpStockParamsStockDirection.StDirectionInY);
		if (false)
		{
			goto IL_028a;
		}
		goto IL_03bd;
		IL_01d7:
		int num4 = ((global::_000E._007E_000E_0006(combo_tool) == 0) ? 1 : 0);
		if (0 == 0)
		{
			if (num4 != 0)
			{
				_0099_0005._007E_0004_0017(_0015_0002._007E_001D_0012(Par), CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolInside);
			}
			else if (global::_000E._007E_000E_0006(combo_tool) == 1)
			{
				_0099_0005._007E_0004_0017(_0015_0002._007E_001D_0012(Par), CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolCenter);
				if (false)
				{
					goto IL_0146;
				}
			}
			else if (global::_000E._007E_000E_0006(combo_tool) == 2)
			{
				_0099_0005._007E_0004_0017(_0015_0002._007E_001D_0012(Par), CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolOutside);
			}
			goto IL_028a;
		}
		goto IL_0351;
		IL_03bd:
		if (global::_0003._007E_001C(this._0001))
		{
			_009B_0005._007E_0006_0017(_0015_0002._007E_001D_0012(Par), CollCtrlOpStockParamsStockOffsetMode.SomExpand);
			if (4u != 0)
			{
				return;
			}
			goto IL_0308;
		}
		_009B_0005._007E_0006_0017(_0015_0002._007E_001D_0012(Par), CollCtrlOpStockParamsStockOffsetMode.SomShrink);
		return;
		IL_013f:
		if (num2 == num3)
		{
			goto IL_0146;
		}
		if (global::_000E._007E_000E_0006(combo_stocktype) == 1)
		{
			if (6 == 0)
			{
				goto IL_029f;
			}
			_0016_0002._007E_001E_0012(_0015_0002._007E_001D_0012(Par), CollCtrlOpStockParamsStockType.StSurfaces);
		}
		else if (global::_000E._007E_000E_0006(combo_stocktype) == 2)
		{
			_0016_0002._007E_001E_0012(_0015_0002._007E_001D_0012(Par), CollCtrlOpStockParamsStockType.St2dContainment);
		}
		goto IL_01d7;
		IL_029f:
		bool flag = default(bool);
		if (flag)
		{
			_009A_0005._007E_0005_0017(_0015_0002._007E_001D_0012(Par), CollCtrlOpStockParamsStockDirection.StDirectionInX);
			goto IL_03bd;
		}
		num2 = global::_000E._007E_000E_0006(combo_direction);
		num3 = 1;
		goto IL_02d7;
		IL_0308:
		if (global::_000E._007E_000E_0006(combo_direction) == 2)
		{
			_009A_0005._007E_0005_0017(_0015_0002._007E_001D_0012(Par), CollCtrlOpStockParamsStockDirection.StDirectionInZ);
			goto IL_03bd;
		}
		num4 = global::_000E._007E_000E_0006(combo_direction);
		goto IL_0351;
		IL_0351:
		if (num4 == 3)
		{
			_009A_0005._007E_0005_0017(_0015_0002._007E_001D_0012(Par), CollCtrlOpStockParamsStockDirection.StDirectionCustomDefined);
			goto IL_03bd;
		}
		num2 = global::_000E._007E_000E_0006(combo_direction);
		num3 = 4;
		if (num3 == 0)
		{
			goto IL_02d7;
		}
		if (num3 == 0)
		{
			goto IL_013f;
		}
		num2 = ((num2 == num3) ? 1 : 0);
		goto IL_0399;
		IL_0399:
		if (num2 != 0)
		{
			_009A_0005._007E_0005_0017(_0015_0002._007E_001D_0012(Par), CollCtrlOpStockParamsStockDirection.StDirectionMachiningDirection);
		}
		goto IL_03bd;
		IL_028a:
		flag = global::_000E._007E_000E_0006(combo_direction) == 0;
		goto IL_029f;
		IL_0146:
		_0016_0002._007E_001E_0012(_0015_0002._007E_001D_0012(Par), CollCtrlOpStockParamsStockType.StBoundingBox);
		goto IL_01d7;
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		UpdateControlFromType();
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		bool num = Properties.Inited;
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
				Properties.Inited = false;
				if (6u != 0)
				{
					Apply();
					goto IL_0053;
				}
			}
			goto IL_0066;
			IL_0053:
			UpdateControlFromType();
			goto IL_005a;
			IL_005a:
			Properties.Inited = true;
			goto IL_0066;
			IL_0066:
			if (true)
			{
				break;
			}
			goto IL_0053;
		}
	}

	internal void _0005(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		bool num = Properties.Inited;
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
				Properties.Inited = false;
				if (6u != 0)
				{
					Apply();
					goto IL_0053;
				}
			}
			goto IL_0066;
			IL_0053:
			UpdateControlFromType();
			goto IL_005a;
			IL_005a:
			Properties.Inited = true;
			goto IL_0066;
			IL_0066:
			if (true)
			{
				break;
			}
			goto IL_0053;
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
