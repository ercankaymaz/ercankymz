using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriMHeights : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	private IContainer m__0001 = null;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Label _0001;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	internal Panel _0001;

	internal Label _0002;

	internal NumericUpDown _0001;

	internal Label _0003;

	internal NumericUpDown _0002;

	internal Label _0004;

	public Button btn_ok;

	internal ImageList _0002;

	internal Panel _0002;

	internal Panel _0003;

	internal RadioButton _0003;

	internal RadioButton _0004;

	internal RadioButton _0005;

	public F_MwTriMHeights()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
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
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0084_0003(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0086_0003(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
		if (_0089_0003._007E_001D_0014(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))) == MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf)
		{
			_0095._007E_0093_000F(_0005, true);
		}
		else if (_0089_0003._007E_001D_0014(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))) == MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromStock)
		{
			_0095._007E_0093_000F(this._0004, true);
		}
		else
		{
			_0095._007E_0093_000F(this._0003, true);
		}
		if (_0005_0002._007E_0012_0012(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))) == MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic)
		{
			_0095._007E_0093_000F(this._0002, true);
		}
		else
		{
			_0095._007E_0093_000F(this._0001, true);
		}
		UpdateControlFromType();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
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
		bool flag = global::_0003._007E_001C(this._0002);
		if (0 == 0)
		{
			if (flag)
			{
				_0095._007E_0095_000F(this._0003, true);
				_0095._007E_0095_000F(this._0002, false);
				goto IL_007e;
			}
			_0095._007E_0095_000F(this._0003, false);
		}
		_0095._007E_0095_000F(this._0002, true);
		goto IL_007e;
		IL_007e:
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
		{
			_0095._007E_0095_000F(this._0003, true);
			_0095._007E_0095_000F(this._0004, true);
			_0095._007E_0095_000F(_0005, true);
		}
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts)
		{
			_0095._007E_0095_000F(this._0003, false);
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(_0005, true);
		}
	}

	public void Apply()
	{
		_0094._007E_0081_0007(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		_0094._007E_0082_0007(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		if (global::_0003._007E_001C(this._0002))
		{
			_009B._007E_009F_0011(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic);
		}
		else
		{
			_009B._007E_009F_0011(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined);
		}
		if (global::_0003._007E_001C(_0005))
		{
			_008C_0003._007E_007F_0014(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf);
		}
		else if (global::_0003._007E_001C(this._0004))
		{
			_008C_0003._007E_007F_0014(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromStock);
		}
		else if (global::_0003._007E_001C(this._0003))
		{
			_008C_0003._007E_007F_0014(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromBoth);
		}
	}

	internal void _0003(object P_0, EventArgs P_1)
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

	internal void _0004(object P_0, EventArgs P_1)
	{
		Control control;
		bool flag;
		if (2u != 0)
		{
			control = new Control();
			if (8u != 0)
			{
				control = (Control)P_0;
				flag = _0003_0003._007E_001E_0013(control) != null;
			}
		}
		while (flag)
		{
			_008F_0003._007E_0082_0014(this._0001, _008E_0003._007E_0081_0014(_008D_0003._007E_0080_0014(this._0002), _001D._0095_0006(_0003_0003._007E_001E_0013(control))));
			if (5 == 0)
			{
				continue;
			}
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
			int num = ((this.m__0001 != null) ? 1 : 0);
			goto IL_004b;
			IL_0025:
			global::_0011._007E_0019_0006(this.m__0001);
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
