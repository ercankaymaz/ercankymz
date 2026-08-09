using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriMFixtureCurves : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

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

	public F_MwTriMFixtureCurves()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		_0005._0002._0001(this);
	}

	public void Init()
	{
		bool flag = default(bool);
		while (true)
		{
			Properties.Inited = false;
			if (false)
			{
				continue;
			}
			int num = Properties.Height;
			int num2 = 10;
			if (num2 != 0)
			{
				if (num > num2)
				{
					_0097._008C_0011(this, Properties.Height);
				}
				num = Properties.Width;
				num2 = 10;
			}
			bool num3 = num > num2;
			if (0 == 0)
			{
				flag = num3;
			}
			if (flag)
			{
				if (1 == 0)
				{
					continue;
				}
				_0097._008D_0011(this, Properties.Width);
			}
			_0095._0092_000F(this, Properties.TopMost);
			_0086_0003._0018_0014(this, Properties.FormPosition);
			while (true)
			{
				bool flag2 = _0013_0004._007E_0004_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsFixtureCurveMode.FcmCenter;
				while (true)
				{
					if (flag2)
					{
						_0095._007E_0093_000F(this._0001, true);
					}
					else if (_0013_0004._007E_0004_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsFixtureCurveMode.FcmOutside)
					{
						goto IL_012d;
					}
					goto IL_0147;
					IL_0147:
					_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0016_0004(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
					if (false)
					{
						continue;
					}
					if (6u != 0)
					{
						break;
					}
					goto IL_012d;
					IL_012d:
					_0095._007E_0093_000F(this._0002, true);
					if (5 == 0)
					{
						goto end_IL_00c1;
					}
					goto IL_0147;
				}
				if (0 == 0)
				{
					UpdateControlFromType();
					Properties.Result = DialogResult.None;
					Properties.Inited = true;
					return;
				}
				continue;
				end_IL_00c1:
				break;
			}
		}
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
	}

	public void Apply()
	{
		while (true)
		{
			_0094._007E_0088_0008(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
			if (1 == 0)
			{
				break;
			}
			bool num;
			bool flag;
			if (uint.MaxValue != 0)
			{
				num = global::_0003._007E_001C(this._0001);
				if (5 == 0)
				{
					goto IL_00b0;
				}
				flag = num;
			}
			if (flag)
			{
				if (false)
				{
					continue;
				}
				_0014_0004._007E_0005_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsFixtureCurveMode.FcmCenter);
				if (3u != 0)
				{
					if (false)
					{
					}
					break;
				}
				goto IL_00b4;
			}
			num = global::_0003._007E_001C(this._0002);
			goto IL_00b0;
			IL_00b0:
			if (!num)
			{
				break;
			}
			goto IL_00b4;
			IL_00b4:
			_0014_0004._007E_0005_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsFixtureCurveMode.FcmOutside);
			break;
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
