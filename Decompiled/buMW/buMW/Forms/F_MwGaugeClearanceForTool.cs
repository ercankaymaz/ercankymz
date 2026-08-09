using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwGaugeClearanceForTool : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	internal IContainer _0001 = null;

	internal Label _0001;

	internal PictureBox _0001;

	public Button btn_ok;

	internal ImageList _0001;

	internal Panel _0001;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Label _0002;

	internal NumericUpDown _0001;

	public Button btn_cancel;

	internal Label _0003;

	internal NumericUpDown _0002;

	internal Label _0004;

	internal NumericUpDown _0003;

	internal NumericUpDown _0004;

	internal NumericUpDown _0005;

	internal NumericUpDown _0006;

	internal Label _0005;

	internal Label _0006;

	internal Label _0007;

	internal NumericUpDown _0007;

	internal Panel _0002;

	internal Label _0008;

	public F_MwGaugeClearanceForTool()
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
			if (flag)
			{
				_0097._008C_0011(this, Properties.Height);
			}
			if (0 == 0)
			{
				if (Properties.Width > 10)
				{
					_0097._008D_0011(this, Properties.Width);
					if (5 == 0)
					{
						continue;
					}
				}
				_0095._0092_000F(this, Properties.TopMost);
				do
				{
					_0086_0003._0018_0014(this, Properties.FormPosition);
					_0088_0003._007E_001A_0014(_0007, _0087_0003._0019_0014(global::_0007._007E_0099_0003(_0090_0003._007E_0083_0014(Par))));
				}
				while (6 == 0);
				_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_009A_0003(_0090_0003._007E_0083_0014(Par))));
				_0088_0003._007E_001A_0014(_0004, _0087_0003._0019_0014(global::_0007._007E_009B_0003(_0090_0003._007E_0083_0014(Par))));
				_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_009C_0003(_0090_0003._007E_0083_0014(Par))));
				_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_009D_0003(_0090_0003._007E_0083_0014(Par))));
				_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_009E_0003(_0090_0003._007E_0083_0014(Par))));
				_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_009F_0003(_0090_0003._007E_0083_0014(Par))));
				if (_0093_0003._007E_0087_0014(_0090_0003._007E_0083_0014(Par)) == CollCtrlParamsCollCtrlClearanceType.CcCtCylindrical)
				{
					if (0 == 0)
					{
						_0095._007E_0093_000F(this._0002, true);
					}
					break;
				}
			}
			_0095._007E_0093_000F(this._0001, true);
			break;
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
		bool num = global::_0003._007E_001C(this._0002);
		while (true)
		{
			bool flag = num;
			if (false)
			{
				break;
			}
			num = flag;
			if (false)
			{
				continue;
			}
			if (!num)
			{
				_0095._007E_0095_000F(this._0002, true);
				break;
			}
			_0095._007E_0095_000F(this._0002, false);
			_0095._007E_0095_000F(this._0003, false);
			do
			{
				_0095._007E_0095_000F(this._0001, false);
			}
			while (false);
			_0095._007E_0095_000F(_0005, false);
			return;
		}
		if (true)
		{
			if (0 == 0)
			{
				_0095._007E_0095_000F(this._0003, true);
			}
			_0095._007E_0095_000F(this._0001, true);
			do
			{
				_0095._007E_0095_000F(_0005, true);
			}
			while (false);
		}
	}

	public void Apply()
	{
		_0094._007E_0015_0008(_0090_0003._007E_0083_0014(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0007)));
		_0094._007E_0016_0008(_0090_0003._007E_0083_0014(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
		_0094._007E_0017_0008(_0090_0003._007E_0083_0014(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0004)));
		_0094._007E_0018_0008(_0090_0003._007E_0083_0014(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		_0094._007E_0019_0008(_0090_0003._007E_0083_0014(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
		_0094._007E_001A_0008(_0090_0003._007E_0083_0014(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		_0094._007E_001B_0008(_0090_0003._007E_0083_0014(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0006)));
		if (global::_0003._007E_001C(this._0002))
		{
			_0094_0003._007E_0088_0014(_0090_0003._007E_0083_0014(Par), CollCtrlParamsCollCtrlClearanceType.CcCtCylindrical);
		}
		else
		{
			_0094_0003._007E_0088_0014(_0090_0003._007E_0083_0014(Par), CollCtrlParamsCollCtrlClearanceType.CcCtConical);
		}
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
