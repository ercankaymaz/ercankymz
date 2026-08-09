using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriMSurfaceQuality : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	internal IContainer _0001 = null;

	internal Label _0001;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal CheckBox _0001;

	internal Label _0002;

	internal Panel _0001;

	internal Label _0003;

	internal NumericUpDown _0001;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal CheckBox _0002;

	internal CheckBox _0003;

	internal NumericUpDown _0002;

	internal NumericUpDown _0003;

	internal NumericUpDown _0004;

	internal Label _0004;

	internal Label _0005;

	internal Panel _0002;

	public F_MwTriMSurfaceQuality()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		while (true)
		{
			Properties.Inited = false;
			int num = Properties.Height;
			int num2 = 10;
			while (true)
			{
				bool flag = num > num2;
				if (false)
				{
					break;
				}
				if (5u != 0 && flag)
				{
					_0097._008C_0011(this, Properties.Height);
				}
				num = Properties.Width;
				num2 = 10;
				if (num2 == 0)
				{
					continue;
				}
				bool num3 = num > num2;
				while (true)
				{
					bool flag2;
					if (3u != 0)
					{
						flag2 = num3;
					}
					if (flag2)
					{
						_0097._008D_0011(this, Properties.Width);
						if (false)
						{
							break;
						}
					}
					_0095._0092_000F(this, Properties.TopMost);
					_0086_0003._0018_0014(this, Properties.FormPosition);
					bool flag3 = _009B_0004._007E_0095_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsArcFitPlaneType.AfPlaneAny;
					num3 = flag3;
					if (true)
					{
						if (num3)
						{
							_0095._007E_0093_000F(this._0002, true);
						}
						else if (_009B_0004._007E_0095_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsArcFitPlaneType.AfPlaneCoordinate)
						{
							_0095._007E_0093_000F(this._0001, true);
						}
						_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_009A_0004(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
						_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_009B_0004(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
						break;
					}
				}
				do
				{
					_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_009C_0004(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
					_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_009D_0004(Par)));
				}
				while (2 == 0);
				_0095._007E_0096_000F(this._0001, global::_0003._007E_0084_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
				if (0 == 0)
				{
					_0095._007E_0096_000F(this._0003, global::_0003._007E_0086_0002(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
					_0095._007E_0096_000F(this._0002, global::_0003._007E_0087_0002(Par));
					UpdateControlFromType();
					Properties.Result = DialogResult.None;
				}
				Properties.Inited = true;
				return;
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
		if (0 == 0)
		{
			_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0001));
			goto IL_002f;
		}
		goto IL_00a4;
		IL_00a4:
		if (3 == 0)
		{
			goto IL_002f;
		}
		if (0 == 0)
		{
			return;
		}
		goto IL_0059;
		IL_002f:
		_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0002));
		goto IL_0059;
		IL_0059:
		if (0 == 0)
		{
			_0095._007E_0095_000F(this._0002, global::_0003._007E_0083(this._0003));
		}
		if (6 == 0)
		{
			goto IL_002f;
		}
		_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0003));
		goto IL_00a4;
	}

	public void Apply()
	{
		_0094._007E_000E_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		_0094._007E_000F_000E(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
		_0094._007E_0010_000E(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		if (uint.MaxValue != 0)
		{
			_0094._007E_0011_000E(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
			_0095._007E_0098_0010(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0001));
			_0095._007E_0099_0010(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), global::_0003._007E_0083(this._0003));
			if (4u != 0)
			{
				goto IL_018a;
			}
			goto IL_01ab;
		}
		return;
		IL_01ab:
		bool num = global::_0003._007E_001C(this._0002);
		do
		{
			if (num)
			{
				_009C_0004._007E_0096_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsArcFitPlaneType.AfPlaneAny);
				return;
			}
			bool flag = global::_0003._007E_001C(this._0001);
			num = flag;
		}
		while (false);
		if (num)
		{
			if (0 == 0)
			{
				_009C_0004._007E_0096_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsArcFitPlaneType.AfPlaneCoordinate);
				return;
			}
			goto IL_018a;
		}
		return;
		IL_018a:
		_0095._007E_009A_0010(Par, global::_0003._007E_0083(this._0002));
		goto IL_01ab;
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
