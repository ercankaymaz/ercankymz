using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriMConstantZ : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	[CompilerGenerated]
	private MWDataOrjOkHandler m__0001;

	[CompilerGenerated]
	private CancelCommandEventHandler m__0001;

	internal IContainer _0001 = null;

	internal Button _0001;

	internal Panel _0001;

	internal Label _0001;

	internal Button _0002;

	internal NumericUpDown _0001;

	internal Label _0002;

	internal TabControl _0001;

	internal TabPage _0001;

	internal Panel _0002;

	internal CheckBox _0001;

	internal Button _0003;

	internal CheckBox _0002;

	internal Button _0004;

	internal CheckBox _0003;

	internal Button _0005;

	internal CheckBox _0004;

	internal Button _0006;

	internal CheckBox _0005;

	internal Button _0007;

	internal CheckBox _0006;

	internal Button _0008;

	internal Label _0003;

	internal Panel _0003;

	internal Panel _0004;

	internal Label _0004;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Panel _0005;

	internal RadioButton _0003;

	internal Label _0005;

	internal RadioButton _0004;

	internal RadioButton _0005;

	internal Label _0006;

	public Button btn_ok;

	internal ImageList _0001;

	internal Panel _0006;

	internal Label _0007;

	internal NumericUpDown _0002;

	internal Label _0008;

	internal NumericUpDown _0003;

	internal Label _000E;

	internal NumericUpDown _0004;

	internal Label _000F;

	public Button btn_cancel;

	internal Button _000E;

	internal Button _000F;

	internal Button _0010;

	internal Label _0010;

	internal PictureBox _0001;

	internal CheckBox _0007;

	internal Button _0011;

	internal Panel _0007;

	internal Button _0012;

	internal Button _0013;

	internal Label _0011;

	internal Button _0014;

	internal Panel _0008;

	internal Button _0015;

	internal NumericUpDown _0005;

	internal NumericUpDown _0006;

	internal RadioButton _0006;

	internal RadioButton _0007;

	internal Label _0012;

	internal CheckBox _0008;

	internal Button _0016;

	internal Panel _000E;

	internal Label _0013;

	internal RadioButton _0008;

	internal RadioButton _000E;

	internal Panel _000F;

	internal Label _0014;

	internal RadioButton _000F;

	internal RadioButton _0010;

	internal Button _0017;

	internal CheckBox _000E;

	internal Label _0015;

	internal CheckBox _000F;

	internal NumericUpDown _0007;

	public event MWDataOrjOkHandler OkClick
	{
		[CompilerGenerated]
		add
		{
			MWDataOrjOkHandler mWDataOrjOkHandler = this.m__0001;
			while (true)
			{
				MWDataOrjOkHandler mWDataOrjOkHandler2 = mWDataOrjOkHandler;
				while (true)
				{
					MWDataOrjOkHandler obj = (MWDataOrjOkHandler)global::_0016._008D_0006(mWDataOrjOkHandler2, value);
					MWDataOrjOkHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					mWDataOrjOkHandler = Interlocked.CompareExchange(ref this.m__0001, value2, mWDataOrjOkHandler2);
					if ((object)mWDataOrjOkHandler != mWDataOrjOkHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
		[CompilerGenerated]
		remove
		{
			MWDataOrjOkHandler mWDataOrjOkHandler = this.m__0001;
			while (true)
			{
				MWDataOrjOkHandler mWDataOrjOkHandler2 = mWDataOrjOkHandler;
				while (true)
				{
					MWDataOrjOkHandler obj = (MWDataOrjOkHandler)global::_0016._008E_0006(mWDataOrjOkHandler2, value);
					MWDataOrjOkHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					mWDataOrjOkHandler = Interlocked.CompareExchange(ref this.m__0001, value2, mWDataOrjOkHandler2);
					if ((object)mWDataOrjOkHandler != mWDataOrjOkHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public event CancelCommandEventHandler CancelClick
	{
		[CompilerGenerated]
		add
		{
			CancelCommandEventHandler cancelCommandEventHandler = this.m__0001;
			while (true)
			{
				CancelCommandEventHandler cancelCommandEventHandler2 = cancelCommandEventHandler;
				while (true)
				{
					CancelCommandEventHandler obj = (CancelCommandEventHandler)global::_0016._008D_0006(cancelCommandEventHandler2, value);
					CancelCommandEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					cancelCommandEventHandler = Interlocked.CompareExchange(ref this.m__0001, value2, cancelCommandEventHandler2);
					if ((object)cancelCommandEventHandler != cancelCommandEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
		[CompilerGenerated]
		remove
		{
			CancelCommandEventHandler cancelCommandEventHandler = this.m__0001;
			while (true)
			{
				CancelCommandEventHandler cancelCommandEventHandler2 = cancelCommandEventHandler;
				while (true)
				{
					CancelCommandEventHandler obj = (CancelCommandEventHandler)global::_0016._008E_0006(cancelCommandEventHandler2, value);
					CancelCommandEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					cancelCommandEventHandler = Interlocked.CompareExchange(ref this.m__0001, value2, cancelCommandEventHandler2);
					if ((object)cancelCommandEventHandler != cancelCommandEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public F_MwTriMConstantZ()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		bool num = Properties.Height > 10;
		bool flag;
		if (uint.MaxValue != 0)
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
		_0086_0003._0018_0014(this, Properties.FormPosition);
		if (!buMWCalcs.AdvancedTriMesh)
		{
			_0095._007E_0082_0010(Par, false);
			_0095._007E_0083_0010(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), false);
			_0095._007E_0084_0010(_001D_0004._007E_0016_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), false);
		}
		if (_001E_0004._007E_0017_0015(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))) == SharedMiscParamsConstantZStart.ShbZsTop)
		{
			_0095._007E_0093_000F(this._0002, true);
		}
		else if (_001E_0004._007E_0017_0015(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))) == SharedMiscParamsConstantZStart.ShbZsBottom)
		{
			_0095._007E_0093_000F(this._0001, true);
		}
		if (_0092._007E_0016_0007(Par) == MachiningParamsMachType.MachtypeOneway)
		{
			_0095._007E_0093_000F(this._0004, true);
		}
		else if (_0092._007E_0016_0007(Par) == MachiningParamsMachType.MachtypeZigzag)
		{
			_0095._007E_0093_000F(this._0005, true);
		}
		else if (_0092._007E_0016_0007(Par) == MachiningParamsMachType.MachtypeSpiral)
		{
			_0095._007E_0093_000F(this._0003, true);
		}
		if (_008F._007E_0012_0007(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))) == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
		{
			_0095._007E_0093_000F(this._0007, true);
		}
		else
		{
			_0095._007E_0093_000F(_0006, true);
		}
		if (_0091._007E_0015_0007(Par) == MachiningParamsMachiningAreaMode.MachByLanes)
		{
			_0095._007E_0093_000F(this._000E, true);
		}
		else
		{
			_0095._007E_0093_000F(_0008, true);
		}
		if (_0015_0004._007E_0006_0015(Par) == MachiningParamsDirection.DirConventional)
		{
			_0095._007E_0093_000F(this._000F, true);
		}
		else
		{
			_0095._007E_0093_000F(_0010, true);
		}
		_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_007F_0003(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0083_0003(Par)));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0019_0003(Par)));
		_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0018_0003(Par)));
		_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0017_0003(Par)));
		_0088_0003._007E_001A_0014(this._0005, _0004_0004._0097_0014(global::_000E._007E_009F_0005(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
		_0088_0003._007E_001A_0014(_0007, _0087_0003._0019_0014(global::_0007._007E_001E_0004(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
		_0095._007E_0096_000F(this._0005, global::_0003._007E_0003_0002(_0016_0004._007E_0007_0015(Par)));
		_0095._007E_0096_000F(this._0006, global::_0003._007E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
		_0095._007E_0096_000F(this._0002, global::_0003._007E_0007_0002(_001D_0004._007E_0016_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0095._007E_0096_000F(this._0004, global::_0003._007E_0008_0002(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_000E_0002(_0084_0002._007E_008F_0012(Par)));
		_0095._007E_0096_000F(this._0003, global::_0003._007E_000F_0002(Par));
		_0095._007E_0096_000F(this._0007, global::_0003._007E_0007(Par));
		_0095._007E_0096_000F(_000E, global::_0003._007E_0010_0002(Par));
		_0095._007E_0096_000F(this._0008, global::_0003._007E_0011_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
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
		bool flag = this.m__0001 != null;
		bool num;
		if (true)
		{
			num = flag;
			if (-1 == 0 || !num)
			{
				return;
			}
		}
		Apply();
		Properties.Result = DialogResult.OK;
		bool num2 = Properties.FormCloseMode == FormCloseModeType.Dispose;
		if (7u != 0)
		{
			bool flag2 = num2;
			num2 = flag2;
		}
		if (num2)
		{
			global::_0011._001C_0006(this);
			if (false)
			{
				goto IL_0097;
			}
			if (4 == 0)
			{
				goto IL_009b;
			}
		}
		if (Properties.FormCloseMode == FormCloseModeType.Invisible)
		{
			_0095._0094_000F(this, false);
			goto IL_0097;
		}
		goto IL_009b;
		IL_0097:
		if (8 == 0)
		{
		}
		goto IL_009b;
		IL_009b:
		num = this.m__0001(Par);
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		if (3 == 0)
		{
			goto IL_0067;
		}
		bool num;
		if (this.m__0001 != null)
		{
			Properties.Result = DialogResult.Cancel;
			num = Properties.FormCloseMode == FormCloseModeType.Dispose;
			goto IL_009c;
		}
		return;
		IL_0066:
		bool flag = num;
		goto IL_0067;
		IL_0067:
		num = flag;
		if (false)
		{
			goto IL_009c;
		}
		if (!num)
		{
			return;
		}
		goto IL_006d;
		IL_009c:
		while (true)
		{
			if (num)
			{
				if (7 == 0)
				{
					break;
				}
				global::_0011 obj = global::_0011._001C_0006;
				if (0 == 0)
				{
					obj(this);
				}
			}
			num = Properties.FormCloseMode == FormCloseModeType.Invisible;
			if (-1 == 0)
			{
				continue;
			}
			goto IL_0066;
		}
		goto IL_006d;
		IL_006d:
		_0095._0094_000F(this, false);
	}

	public void UpdateControlFromType()
	{
		_0095._007E_0094_000F(this._0002, false);
		_0095._007E_0094_000F(this._0004, false);
		while (true)
		{
			_0095._007E_0094_000F(this._0008, false);
			_0095._007E_0094_000F(_0016, false);
			_0095._007E_0095_000F(_000F, false);
			_0095._007E_0095_000F(this._0006, global::_0003._007E_001C(this._0007));
			_0095._007E_0095_000F(this._0005, global::_0003._007E_001C(_0006));
			bool flag;
			if (global::_0003._007E_001C(this._0005))
			{
				_0095._007E_0095_000F(this._000E, true);
				_0095._007E_0095_000F(this._0011, false);
				_0095._007E_0095_000F(_000F, true);
				if (-1 == 0)
				{
					continue;
				}
			}
			else
			{
				if (!global::_0003._007E_001C(this._0004))
				{
					flag = global::_0003._007E_001C(this._0003);
					goto IL_0152;
				}
				_0095._007E_0095_000F(this._000E, true);
				_0095._007E_0095_000F(this._0011, false);
			}
			goto IL_017b;
			IL_0152:
			if (flag)
			{
				_0095._007E_0095_000F(this._000E, false);
				_0095._007E_0095_000F(this._0011, true);
			}
			goto IL_017b;
			IL_017b:
			_0095._007E_0095_000F(this._0002, !global::_0003._007E_0083(this._0008));
			_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0002) & global::_0003._007E_008C(this._0002));
			if (true)
			{
				break;
			}
			goto IL_0152;
		}
		_0095._007E_0095_000F(this._0008, !global::_0003._007E_0083(this._0002));
		_0095._007E_0095_000F(_0016, global::_0003._007E_008C(this._0008) & global::_0003._007E_0083(this._0008));
		_0095._007E_0095_000F(this._0003, !global::_0003._007E_0083(this._0002));
		_0095._007E_0095_000F(this._0005, global::_0003._007E_008C(this._0003) & global::_0003._007E_0083(this._0003));
		_0095._007E_0095_000F(this._0006, !global::_0003._007E_0083(this._0002));
		_0095._007E_0095_000F(this._0008, global::_0003._007E_008C(this._0006) & global::_0003._007E_0083(this._0006));
		_0095._007E_0095_000F(this._0004, !global::_0003._007E_0083(this._0002));
		_0095._007E_0095_000F(this._0006, global::_0003._007E_008C(this._0004) & global::_0003._007E_0083(this._0004));
		_0095._007E_0095_000F(this._0005, !global::_0003._007E_0083(this._0002));
		_0095._007E_0095_000F(this._0007, global::_0003._007E_008C(this._0005) & global::_0003._007E_0083(this._0005));
		_0095._007E_0095_000F(this._0001, !global::_0003._007E_0083(this._0002));
		_0095._007E_0095_000F(this._0003, global::_0003._007E_008C(this._0001) & global::_0003._007E_0083(this._0001));
		_0095._007E_0095_000F(_0017, global::_0003._007E_008C(_000E) & global::_0003._007E_0083(_000E));
		if (!buMWCalcs.AdvancedTriMesh)
		{
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(this._0006, false);
			_0095._007E_0095_000F(this._0002, false);
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(_000E, false);
			_0095._007E_0095_000F(_0017, false);
			_0095._007E_0095_000F(this._0014, false);
		}
	}

	public void Apply()
	{
		_0094._007E_0080_0007(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0006)));
		_0094._007E_0087_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		_0094._007E_001A_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		_0094._007E_0019_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
		_0094._007E_0018_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
		while (true)
		{
			_0097._007E_0088_0011(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _000F_0004._009F_0014(global::_0008._007E_0099_0005(this._0005)));
			_0094._007E_0090_0007(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0007)));
			_0095._007E_001F_0010(_0016_0004._007E_0007_0015(Par), global::_0003._007E_0083(this._0005));
			_0095._007E_0083_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0006));
			_0095._007E_0084_0010(_001D_0004._007E_0016_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), global::_0003._007E_0083(this._0002));
			_0095._007E_0083_0010(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), global::_0003._007E_0083(this._0004));
			_0095._007E_0084_000F(_0084_0002._007E_008F_0012(Par), global::_0003._007E_0083(this._0001));
			_0095._007E_0086_000F(Par, global::_0003._007E_0083(this._0003));
			_0095._007E_0007_000F(Par, global::_0003._007E_0083(this._0007));
			bool num;
			if (0 == 0)
			{
				_0095._007E_0082_0010(Par, global::_0003._007E_0083(_000E));
				_0095._007E_0086_0010(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0008));
				if (global::_0003._007E_001C(this._0002))
				{
					_001D_0002._007E_0087_0012(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), SharedMiscParamsConstantZStart.ShbZsTop);
					goto IL_03cf;
				}
				num = global::_0003._007E_001C(this._0001);
				goto IL_0399;
			}
			goto IL_0441;
			IL_03cf:
			bool flag2;
			if (true)
			{
				if (global::_0003._007E_001C(this._0004))
				{
					_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeOneway);
				}
				else
				{
					bool flag = global::_0003._007E_001C(this._0005);
					num = flag;
					if (false)
					{
						goto IL_0399;
					}
					if (!num)
					{
						flag2 = global::_0003._007E_001C(this._0003);
						goto IL_0441;
					}
					_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeZigzag);
				}
				goto IL_045f;
			}
			goto IL_04fd;
			IL_0441:
			if (flag2)
			{
				if (1 == 0)
				{
					continue;
				}
				_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeSpiral);
			}
			goto IL_045f;
			IL_045f:
			if (global::_0003._007E_001C(_0010))
			{
				_0017_0002._007E_001F_0012(Par, MachiningParamsDirection.DirClimb);
			}
			else if (global::_0003._007E_001C(this._000F))
			{
				_0017_0002._007E_001F_0012(Par, MachiningParamsDirection.DirConventional);
			}
			if (global::_0003._007E_001C(this._000E))
			{
				_009D._007E_0002_0012(Par, MachiningParamsMachiningAreaMode.MachByLanes);
				break;
			}
			if (false)
			{
				goto IL_0441;
			}
			if (!global::_0003._007E_001C(_0008))
			{
				break;
			}
			goto IL_04fd;
			IL_0399:
			if (num)
			{
				_001D_0002._007E_0087_0012(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), SharedMiscParamsConstantZStart.ShbZsBottom);
			}
			goto IL_03cf;
			IL_04fd:
			_009D._007E_0002_0012(Par, MachiningParamsMachiningAreaMode.MachByRegions);
			break;
		}
		if (global::_0003._007E_001C(this._0007))
		{
			_0098._007E_009A_0011(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep);
		}
		else if (global::_0003._007E_001C(_0006))
		{
			_0098._007E_009A_0011(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices);
		}
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
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected O, but got Unknown
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected O, but got Unknown
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Expected O, but got Unknown
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Expected O, but got Unknown
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Expected O, but got Unknown
		//IL_044f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Expected O, but got Unknown
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Expected O, but got Unknown
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_0581: Expected O, but got Unknown
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Expected O, but got Unknown
		//IL_0608: Unknown result type (might be due to invalid IL or missing references)
		//IL_0612: Expected O, but got Unknown
		//IL_05b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Expected O, but got Unknown
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_052d: Expected O, but got Unknown
		//IL_0492: Unknown result type (might be due to invalid IL or missing references)
		//IL_049c: Expected O, but got Unknown
		//IL_0699: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a3: Expected O, but got Unknown
		//IL_0645: Unknown result type (might be due to invalid IL or missing references)
		//IL_064f: Expected O, but got Unknown
		//IL_072a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0734: Expected O, but got Unknown
		//IL_06d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e0: Expected O, but got Unknown
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c5: Expected O, but got Unknown
		//IL_0767: Unknown result type (might be due to invalid IL or missing references)
		//IL_0771: Expected O, but got Unknown
		//IL_084c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0856: Expected O, but got Unknown
		//IL_07f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0802: Expected O, but got Unknown
		//IL_08dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e7: Expected O, but got Unknown
		//IL_0889: Unknown result type (might be due to invalid IL or missing references)
		//IL_0893: Expected O, but got Unknown
		//IL_0920: Unknown result type (might be due to invalid IL or missing references)
		//IL_092a: Expected O, but got Unknown
		Control control = new Control();
		control = (Control)P_0;
		F_MWTriMDynamicalHolderColl f_MWTriMDynamicalHolderColl;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0014)))
		{
			f_MWTriMDynamicalHolderColl = new F_MWTriMDynamicalHolderColl();
			goto IL_0052;
		}
		goto IL_00a8;
		IL_0216:
		F_MwTriMRoughLink f_MwTriMRoughLink;
		_009D_0003._007E_0091_0014(f_MwTriMRoughLink);
		if (f_MwTriMRoughLink.Properties.Result == DialogResult.OK)
		{
			Par = new MachiningParams(f_MwTriMRoughLink.Par);
			global::_0011._007E_001C_0006(f_MwTriMRoughLink);
		}
		goto IL_025b;
		IL_0052:
		f_MWTriMDynamicalHolderColl.Par = new MachiningParams(Par);
		f_MWTriMDynamicalHolderColl.Init();
		_009D_0003._007E_0091_0014(f_MWTriMDynamicalHolderColl);
		if (f_MWTriMDynamicalHolderColl.Properties.Result == DialogResult.OK)
		{
			Par = new MachiningParams(f_MWTriMDynamicalHolderColl.Par);
			global::_0011._007E_001C_0006(f_MWTriMDynamicalHolderColl);
		}
		goto IL_00a8;
		IL_025b:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			F_MwTriMRoughing f_MwTriMRoughing = new F_MwTriMRoughing();
			f_MwTriMRoughing.Par = new MachiningParams(Par);
			f_MwTriMRoughing.Init();
			_009D_0003._007E_0091_0014(f_MwTriMRoughing);
			bool flag = f_MwTriMRoughing.Properties.Result == DialogResult.OK;
			if (7 == 0)
			{
				goto IL_053c;
			}
			if (flag)
			{
				Par = new MachiningParams(f_MwTriMRoughing.Par);
				global::_0011._007E_001C_0006(f_MwTriMRoughing);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000F)))
		{
			F_MwGaugeCheck f_MwGaugeCheck = new F_MwGaugeCheck();
			f_MwGaugeCheck.Par = new MachiningParams(Par);
			f_MwGaugeCheck.Init();
			_009D_0003._007E_0091_0014(f_MwGaugeCheck);
			if (f_MwGaugeCheck.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwGaugeCheck.Par);
				global::_0011._007E_001C_0006(f_MwGaugeCheck);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			F_MwTriMAngleRange f_MwTriMAngleRange = new F_MwTriMAngleRange();
			f_MwTriMAngleRange.Par = new MachiningParams(Par);
			f_MwTriMAngleRange.Init();
			_009D_0003._007E_0091_0014(f_MwTriMAngleRange);
			if (f_MwTriMAngleRange.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMAngleRange.Par);
				global::_0011._007E_001C_0006(f_MwTriMAngleRange);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			F_MwTriMSurfaceQuality f_MwTriMSurfaceQuality = new F_MwTriMSurfaceQuality();
			f_MwTriMSurfaceQuality.Par = new MachiningParams(Par);
			f_MwTriMSurfaceQuality.Init();
			if (false)
			{
				goto IL_0052;
			}
			_009D_0003._007E_0091_0014(f_MwTriMSurfaceQuality);
			if (f_MwTriMSurfaceQuality.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMSurfaceQuality.Par);
				global::_0011._007E_001C_0006(f_MwTriMSurfaceQuality);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0008)))
		{
			F_MwTriMSilhouette f_MwTriMSilhouette = new F_MwTriMSilhouette();
			f_MwTriMSilhouette.Par = new MachiningParams(Par);
			f_MwTriMSilhouette.Init();
			_009D_0003._007E_0091_0014(f_MwTriMSilhouette);
			if (f_MwTriMSilhouette.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMSilhouette.Par);
				global::_0011._007E_001C_0006(f_MwTriMSilhouette);
			}
		}
		goto IL_053c;
		IL_00a8:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0013)))
		{
			F_MwTriMHeights f_MwTriMHeights = new F_MwTriMHeights();
			f_MwTriMHeights.Par = new MachiningParams(Par);
			f_MwTriMHeights.Init();
			_009D_0003._007E_0091_0014(f_MwTriMHeights);
			if (f_MwTriMHeights.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMHeights.Par);
				global::_0011._007E_001C_0006(f_MwTriMHeights);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0012)))
		{
			F_MwTriMOffset f_MwTriMOffset = new F_MwTriMOffset();
			f_MwTriMOffset.Par = new MachiningParams(Par);
			f_MwTriMOffset.Init();
			_009D_0003._007E_0091_0014(f_MwTriMOffset);
			if (f_MwTriMOffset.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMOffset.Par);
				global::_0011._007E_001C_0006(f_MwTriMOffset);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0010)))
		{
			f_MwTriMRoughLink = new F_MwTriMRoughLink();
			f_MwTriMRoughLink.Par = new MachiningParams(Par);
			f_MwTriMRoughLink.Init();
			goto IL_0216;
		}
		goto IL_025b;
		IL_053c:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
		{
			F_MwTriMRoundCorner f_MwTriMRoundCorner = new F_MwTriMRoundCorner();
			f_MwTriMRoundCorner.Par = new MachiningParams(Par);
			f_MwTriMRoundCorner.Init();
			_009D_0003._007E_0091_0014(f_MwTriMRoundCorner);
			if (f_MwTriMRoundCorner.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMRoundCorner.Par);
				global::_0011._007E_001C_0006(f_MwTriMRoundCorner);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
		{
			F_MwTriMRestFinish f_MwTriMRestFinish = new F_MwTriMRestFinish();
			f_MwTriMRestFinish.Par = new MachiningParams(Par);
			f_MwTriMRestFinish.Init();
			_009D_0003._007E_0091_0014(f_MwTriMRestFinish);
			if (f_MwTriMRestFinish.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMRestFinish.Par);
				global::_0011._007E_001C_0006(f_MwTriMRestFinish);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0007)))
		{
			F_MwTriM2dContainment f_MwTriM2dContainment = new F_MwTriM2dContainment();
			f_MwTriM2dContainment.Par = new MachiningParams(Par);
			f_MwTriM2dContainment.Init();
			_009D_0003._007E_0091_0014(f_MwTriM2dContainment);
			if (f_MwTriM2dContainment.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriM2dContainment.Par);
				global::_0011._007E_001C_0006(f_MwTriM2dContainment);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0011)))
		{
			F_MwTriMUpDownAdvanced f_MwTriMUpDownAdvanced = new F_MwTriMUpDownAdvanced();
			f_MwTriMUpDownAdvanced.Par = new MachiningParams(Par);
			f_MwTriMUpDownAdvanced.Init();
			_009D_0003._007E_0091_0014(f_MwTriMUpDownAdvanced);
			if (f_MwTriMUpDownAdvanced.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMUpDownAdvanced.Par);
				global::_0011._007E_001C_0006(f_MwTriMUpDownAdvanced);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000E)))
		{
			F_MwTriMUtility f_MwTriMUtility = new F_MwTriMUtility();
			f_MwTriMUtility.Par = new MachiningParams(Par);
			f_MwTriMUtility.Init();
			_009D_0003._007E_0091_0014(f_MwTriMUtility);
			if (f_MwTriMUtility.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMUtility.Par);
				global::_0011._007E_001C_0006(f_MwTriMUtility);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0011)))
		{
			F_MwTriMSpiralAdvanced f_MwTriMSpiralAdvanced = new F_MwTriMSpiralAdvanced();
			f_MwTriMSpiralAdvanced.Par = new MachiningParams(Par);
			f_MwTriMSpiralAdvanced.Init();
			_009D_0003._007E_0091_0014(f_MwTriMSpiralAdvanced);
			if (f_MwTriMSpiralAdvanced.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMSpiralAdvanced.Par);
				global::_0011._007E_001C_0006(f_MwTriMSpiralAdvanced);
			}
		}
		if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0015)))
		{
			return;
		}
		F_MwTriMDepthAdvanced f_MwTriMDepthAdvanced = new F_MwTriMDepthAdvanced();
		f_MwTriMDepthAdvanced.Par = new MachiningParams(Par);
		f_MwTriMDepthAdvanced.Init();
		_009D_0003._007E_0091_0014(f_MwTriMDepthAdvanced);
		bool flag2 = f_MwTriMDepthAdvanced.Properties.Result == DialogResult.OK;
		if (true)
		{
			if (flag2)
			{
				Par = new MachiningParams(f_MwTriMDepthAdvanced.Par);
				global::_0011._007E_001C_0006(f_MwTriMDepthAdvanced);
			}
			return;
		}
		goto IL_0216;
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
