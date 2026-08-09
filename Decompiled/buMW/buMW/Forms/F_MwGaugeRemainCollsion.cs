using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwGaugeRemainCollsion : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	internal IContainer _0001 = null;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal Panel _0001;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal RadioButton _0003;

	internal CheckBox _0001;

	internal Panel _0002;

	internal Label _0001;

	public F_MwGaugeRemainCollsion()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		_0005._0002._0001(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			_0097._008C_0011(this, Properties.Height);
		}
		bool flag;
		do
		{
			flag = Properties.Width > 10;
		}
		while (false);
		if (flag)
		{
			_0097._008D_0011(this, Properties.Width);
		}
		_0095._0092_000F(this, Properties.TopMost);
		_0086_0003._0018_0014(this, Properties.FormPosition);
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0094(_0090_0003._007E_0083_0014(Par)));
		if (global::_0003._007E_0095(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)))
		{
			_0095._007E_0093_000F(_0003, true);
			if (2 == 0)
			{
				goto IL_0175;
			}
		}
		if (global::_0003._007E_0096(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) && 4u != 0)
		{
			_0095._007E_0093_000F(this._0001, true);
		}
		goto IL_0175;
		IL_0175:
		if (!global::_0003._007E_0095(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) & !global::_0003._007E_0096(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)))
		{
			_0095._007E_0093_000F(this._0002, true);
		}
		UpdateControlFromType();
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
		if (0 == 0)
		{
			do
			{
				if (4u != 0)
				{
					bool num = _0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpBaseParamsCollStrategy.CsReportCollisions;
					do
					{
						bool flag = num | (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpBaseParamsCollStrategy.CsReportCollisions) | (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpBaseParamsCollStrategy.CsReportCollisions) | (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpBaseParamsCollStrategy.CsReportCollisions);
						num = flag;
					}
					while (false);
					if (!num)
					{
						_0095._007E_0095_000F(this._0001, false);
						break;
					}
					_0095._007E_0095_000F(this._0001, true);
				}
			}
			while (false);
		}
		while (3 == 0)
		{
		}
	}

	public void Apply()
	{
		if (5u != 0)
		{
			_0095._007E_0013_0010(_0090_0003._007E_0083_0014(Par), global::_0003._007E_0083(this._0001));
			if (false)
			{
				goto IL_02d5;
			}
			if (!global::_0003._007E_001C(_0003))
			{
				goto IL_01f9;
			}
			_0095._007E_0014_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), true);
			_0095._007E_0015_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), false);
			_0095._007E_0014_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), true);
			_0095._007E_0015_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), false);
		}
		if (true)
		{
			_0095._007E_0014_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), true);
			_0095._007E_0015_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), false);
			if (3u != 0)
			{
				_0095._007E_0014_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), true);
				_0095._007E_0015_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), false);
				goto IL_01f9;
			}
		}
		goto IL_0367;
		IL_01f9:
		if (global::_0003._007E_001C(this._0001))
		{
			_0095._007E_0014_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), false);
			_0095._007E_0015_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), true);
			_0095._007E_0014_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), false);
			_0095._007E_0015_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), true);
			goto IL_02d5;
		}
		goto IL_039a;
		IL_039a:
		while (true)
		{
			if (!global::_0003._007E_001C(this._0002))
			{
				return;
			}
			_0095._007E_0014_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), false);
			_0095._007E_0015_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), false);
			if (false)
			{
				break;
			}
			_0095._007E_0014_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), false);
			while (0 == 0)
			{
				_0095._007E_0015_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), false);
				if (uint.MaxValue != 0)
				{
					_0095._007E_0014_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), false);
					_0095._007E_0015_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), false);
					_0095._007E_0014_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), false);
					_0095._007E_0015_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), false);
					return;
				}
			}
		}
		goto IL_0305;
		IL_02d5:
		_0095._007E_0014_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), false);
		goto IL_0305;
		IL_0367:
		_0095._007E_0015_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), true);
		goto IL_039a;
		IL_0305:
		_0095._007E_0015_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), true);
		_0095._007E_0014_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), false);
		goto IL_0367;
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
