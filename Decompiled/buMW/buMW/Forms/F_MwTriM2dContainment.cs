using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriM2dContainment : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	public bool Advanced = false;

	internal IContainer _0001 = null;

	internal Label _0001;

	internal NumericUpDown _0001;

	internal Label _0002;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal Panel _0001;

	internal Label _0003;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal RadioButton _0003;

	internal Panel _0002;

	internal Label _0004;

	internal RadioButton _0004;

	internal RadioButton _0005;

	public F_MwTriM2dContainment()
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
		if (!buMWCalcs.AdvancedTriMesh)
		{
			_009E_0003._007E_0092_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint);
			if (false)
			{
				goto IL_01e0;
			}
		}
		bool flag = _009F_0003._007E_0093_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))) == SharedMiscParamsOffset2dContainmentMethod.ShbOffsetNone;
		do
		{
			if (flag)
			{
				_0095._007E_0093_000F(this._0002, true);
				break;
			}
			if (_009F_0003._007E_0093_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))) == SharedMiscParamsOffset2dContainmentMethod.ShbOffsetInside)
			{
				_0095._007E_0093_000F(this._0003, true);
				break;
			}
			if (_009F_0003._007E_0093_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))) != SharedMiscParamsOffset2dContainmentMethod.ShbOffsetOutside)
			{
				break;
			}
			_0095._007E_0093_000F(this._0001, true);
		}
		while (3 == 0);
		goto IL_01e0;
		IL_01e0:
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
		{
			_009E_0003._007E_0092_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint);
		}
		if (_0001_0004._007E_0094_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))) == SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint)
		{
			_0095._007E_0093_000F(_0004, true);
		}
		else
		{
			_0095._007E_0093_000F(_0005, true);
		}
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
		{
		}
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0006_0004(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
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
		if ((_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough) | (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbPencil))
		{
			_0095._007E_0095_000F(_0005, false);
		}
		if ((_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ) | (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts))
		{
			_0095._007E_0095_000F(_0005, true);
		}
		_0095._007E_0095_000F(this._0001, !global::_0003._007E_001C(_0005));
		if (global::_0003._007E_001C(this._0003) | global::_0003._007E_001C(this._0001))
		{
			_0095._007E_0095_000F(this._0001, global::_0003._007E_008C(this._0001));
			_0095._007E_0095_000F(this._0001, global::_0003._007E_008C(this._0001));
		}
		if (global::_0003._007E_001C(this._0002))
		{
			_0095._007E_0095_000F(this._0001, false);
			_0095._007E_0095_000F(this._0001, false);
		}
		if (!buMWCalcs.AdvancedTriMesh)
		{
			_0095._007E_0095_000F(this._0002, false);
		}
	}

	public void Apply()
	{
		bool flag = default(bool);
		while (true)
		{
			_0094._007E_0080_0008(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
			if (false)
			{
				goto IL_0153;
			}
			if (uint.MaxValue != 0)
			{
				if (global::_0003._007E_001C(this._0002))
				{
					if (2u != 0)
					{
						_0002_0004._007E_0095_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), SharedMiscParamsOffset2dContainmentMethod.ShbOffsetNone);
						goto IL_0142;
					}
					goto IL_01d7;
				}
				flag = global::_0003._007E_001C(this._0003);
				goto IL_00c5;
			}
			goto IL_01fb;
			IL_01fb:
			_009E_0003._007E_0092_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint);
			while (1 == 0)
			{
			}
			return;
			IL_01d7:
			if (2 == 0)
			{
				continue;
			}
			goto IL_01de;
			IL_00c5:
			if (flag)
			{
				_0002_0004._007E_0095_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), SharedMiscParamsOffset2dContainmentMethod.ShbOffsetInside);
			}
			else if (global::_0003._007E_001C(this._0001))
			{
				_0002_0004._007E_0095_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), SharedMiscParamsOffset2dContainmentMethod.ShbOffsetOutside);
			}
			goto IL_0142;
			IL_0142:
			bool flag2 = global::_0003._007E_001C(_0004);
			goto IL_0153;
			IL_01de:
			if (6 == 0)
			{
				goto IL_0142;
			}
			if (!global::_0003._007E_001C(_0004))
			{
				break;
			}
			goto IL_01fb;
			IL_0153:
			if (flag2)
			{
				if (3 == 0)
				{
					goto IL_00c5;
				}
				_0002_0004._007E_0095_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), SharedMiscParamsOffset2dContainmentMethod.ShbOffsetNone);
			}
			else if (global::_0003._007E_001C(_0005))
			{
				_0002_0004._007E_0095_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), SharedMiscParamsOffset2dContainmentMethod.ShbOffsetInside);
				goto IL_01d7;
			}
			goto IL_01de;
		}
		_009E_0003._007E_0092_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), SharedMiscParamsContainmentTrimmingCriteria.CtcToolContactPoint);
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		UpdateControlFromType();
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
