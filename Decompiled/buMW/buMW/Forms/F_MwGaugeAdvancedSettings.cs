using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwGaugeAdvancedSettings : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	internal IContainer _0001 = null;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal CheckBox _0001;

	internal Label _0001;

	internal PictureBox _0001;

	internal Panel _0001;

	internal CheckBox _0002;

	internal CheckBox _0003;

	internal Label _0002;

	internal Panel _0002;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Panel _0003;

	internal CheckBox _0004;

	internal CheckBox _0005;

	internal CheckBox _0006;

	internal CheckBox _0007;

	internal Label _0003;

	public F_MwGaugeAdvancedSettings()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		if (8u != 0)
		{
			Properties.Inited = false;
			bool num = Properties.Height > 10;
			bool flag;
			if (5u != 0)
			{
				flag = num;
			}
			if (flag)
			{
				_0097._008C_0011(this, Properties.Height);
			}
			if (Properties.Width > 10)
			{
				_0097._008D_0011(this, Properties.Width);
			}
			_0095._0092_000F(this, Properties.TopMost);
			if (8u != 0)
			{
				_0086_0003._0018_0014(this, Properties.FormPosition);
				_0095._007E_0096_000F(this._0003, global::_0003._007E_001D(_0090_0003._007E_0083_0014(Par)));
				if (0 == 0)
				{
					_0095._007E_0096_000F(this._0002, global::_0003._007E_001E(_0090_0003._007E_0083_0014(Par)));
				}
				_0095._007E_0096_000F(this._0001, global::_0003._007E_001F(_0090_0003._007E_0083_0014(Par)));
				_0095._007E_0096_000F(_0006, global::_0003._007E_007F(_0090_0003._007E_0083_0014(Par)));
				_0095._007E_0096_000F(_0005, global::_0003._007E_0080(_0090_0003._007E_0083_0014(Par)));
				_0095._007E_0096_000F(_0004, global::_0003._007E_0081(_0090_0003._007E_0083_0014(Par)));
				_0095._007E_0096_000F(_0007, global::_0003._007E_0082(_0090_0003._007E_0083_0014(Par)));
				if (_0091_0003._007E_0084_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsLinksCheckContainmentType.Lct2dContainmentGeo)
				{
					_0095._007E_0093_000F(this._0002, true);
				}
				else
				{
					_0095._007E_0093_000F(this._0001, true);
				}
			}
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
		_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0001));
		_0095._007E_0095_000F(this._0002, global::_0003._007E_0083(this._0002));
		_0095._007E_0095_000F(_0005, false);
		_0095._007E_0095_000F(_0004, false);
	}

	public void Apply()
	{
		_0095._007E_0097_000F(_0090_0003._007E_0083_0014(Par), global::_0003._007E_0083(this._0003));
		_0095._007E_0098_000F(_0090_0003._007E_0083_0014(Par), global::_0003._007E_0083(this._0002));
		_0095._007E_0099_000F(_0090_0003._007E_0083_0014(Par), global::_0003._007E_0083(this._0001));
		_0095._007E_009A_000F(_0090_0003._007E_0083_0014(Par), global::_0003._007E_0083(_0006));
		_0095._007E_009B_000F(_0090_0003._007E_0083_0014(Par), global::_0003._007E_0083(_0005));
		_0095._007E_009C_000F(_0090_0003._007E_0083_0014(Par), global::_0003._007E_0083(_0004));
		_0095._007E_009D_000F(_0090_0003._007E_0083_0014(Par), global::_0003._007E_0083(_0007));
		if (global::_0003._007E_001C(this._0002))
		{
			_0092_0003._007E_0086_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsLinksCheckContainmentType.Lct2dContainmentGeo);
		}
		else
		{
			_0092_0003._007E_0086_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsLinksCheckContainmentType.LctCustomGeo);
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
