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

public class F_MwTriMParallelCut : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	[CompilerGenerated]
	private MWDataOrjOkHandler m__0001;

	[CompilerGenerated]
	private CancelCommandEventHandler m__0001;

	private IContainer m__0001 = null;

	internal Button _0001;

	internal NumericUpDown _0001;

	internal Label _0001;

	internal Panel _0001;

	internal Label _0002;

	internal Button _0002;

	internal NumericUpDown _0002;

	internal Label _0003;

	internal CheckBox _0001;

	internal Label _0004;

	internal NumericUpDown _0003;

	internal Panel _0002;

	internal Label _0005;

	internal NumericUpDown _0004;

	internal TabControl _0001;

	internal TabPage _0001;

	internal Panel _0003;

	internal CheckBox _0002;

	internal Button _0003;

	internal CheckBox _0003;

	internal Button _0004;

	internal CheckBox _0004;

	internal Button _0005;

	internal CheckBox _0005;

	internal Button _0006;

	internal CheckBox _0006;

	internal Button _0007;

	internal CheckBox _0007;

	internal Button _0008;

	internal CheckBox _0008;

	internal Label _0006;

	internal Panel _0004;

	internal Panel _0005;

	internal Label _0007;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Panel _0006;

	internal RadioButton _0003;

	internal Label _0008;

	internal RadioButton _0004;

	internal RadioButton _0005;

	internal Label _000E;

	internal Panel _0007;

	internal Label _000F;

	internal NumericUpDown _0005;

	internal Label _0010;

	internal NumericUpDown _0006;

	internal Label _0011;

	internal Label _0012;

	public Button btn_ok;

	internal ImageList _0001;

	internal Panel _0008;

	internal NumericUpDown _0007;

	internal Label _0013;

	internal NumericUpDown _0008;

	internal Label _0014;

	internal NumericUpDown _000E;

	internal Label _0015;

	internal NumericUpDown _000F;

	internal Label _0016;

	public Button btn_cancel;

	internal Button _000E;

	internal Button _000F;

	internal Button _0010;

	internal Label _0017;

	internal PictureBox _0001;

	internal CheckBox _000E;

	internal CheckBox _000F;

	internal CheckBox _0010;

	internal RadioButton _0006;

	internal RadioButton _0007;

	internal RadioButton _0008;

	internal Label _0018;

	internal Label _0019;

	internal NumericUpDown _0010;

	internal Label _001A;

	internal NumericUpDown _0011;

	internal Button _0011;

	internal Panel _000E;

	internal Button _0012;

	internal Button _0013;

	internal Label _001B;

	internal Button _0014;

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

	public F_MwTriMParallelCut()
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
			_0095._007E_0083_0010(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), false);
			_0095._007E_0084_0010(_001D_0004._007E_0016_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), false);
		}
		if (_0099_0004._007E_0093_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScLowerLeft)
		{
			_0095._007E_0093_000F(this._0002, true);
		}
		else if (_0099_0004._007E_0093_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScLowerRight)
		{
			_0095._007E_0093_000F(this._0001, true);
		}
		else if (_0099_0004._007E_0093_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScUpperLeft)
		{
			_0095._007E_0093_000F(_0007, true);
		}
		else
		{
			_0095._007E_0093_000F(_0006, true);
		}
		if (_0092._007E_0016_0007(Par) == MachiningParamsMachType.MachtypeOneway)
		{
			_0095._007E_0093_000F(this._0004, true);
		}
		else
		{
			if (-1 == 0)
			{
				goto IL_0298;
			}
			if (_0092._007E_0016_0007(Par) == MachiningParamsMachType.MachtypeZigzag)
			{
				_0095._007E_0093_000F(this._0005, true);
			}
			else
			{
				if (_0092._007E_0016_0007(Par) != MachiningParamsMachType.MachtypeUp)
				{
					goto IL_0298;
				}
				_0095._007E_0093_000F(this._0003, true);
				if (false)
				{
					goto IL_051b;
				}
			}
		}
		goto IL_02be;
		IL_02be:
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0017_0004(Par)));
		_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_007F_0003(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
		_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_0087_0003(Par)));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0083_0003(Par)));
		_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_0092_0004(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0093_0004(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0088_0003._007E_001A_0014(this._0011, _0087_0003._0019_0014(global::_0007._007E_0094_0004(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0088_0003._007E_001A_0014(this._0008, _0087_0003._0019_0014(global::_0007._007E_0019_0003(Par)));
		_0088_0003._007E_001A_0014(this._000E, _0087_0003._0019_0014(global::_0007._007E_0018_0003(Par)));
		_0088_0003._007E_001A_0014(this._000F, _0087_0003._0019_0014(global::_0007._007E_0017_0003(Par)));
		_0088_0003._007E_001A_0014(this._0007, _0087_0003._0019_0014(global::_0007._007E_0095_0004(Par)));
		_0088_0003._007E_001A_0014(_0010, _0087_0003._0019_0014(global::_0007._007E_0096_0004(Par)));
		goto IL_051b;
		IL_051b:
		_0095._007E_0096_000F(this._0006, global::_0003._007E_0003_0002(_0016_0004._007E_0007_0015(Par)));
		_0095._007E_0096_000F(this._0007, global::_0003._007E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
		_0095._007E_0096_000F(this._0003, global::_0003._007E_0007_0002(_001D_0004._007E_0016_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0095._007E_0096_000F(this._0005, global::_0003._007E_0008_0002(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0095._007E_0096_000F(this._0008, global::_0003._007E_0012_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
		_0095._007E_0096_000F(_000F, global::_0003._007E_001C_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
		_0095._007E_0096_000F(this._000E, global::_0003._007E_001D_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
		_0095._007E_0096_000F(this._0002, global::_0003._007E_000E_0002(_0084_0002._007E_008F_0012(Par)));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_001E_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
		_0095._007E_0096_000F(this._0004, global::_0003._007E_000F_0002(Par));
		_0095._007E_0096_000F(this._0010, global::_0003._007E_0007(Par));
		UpdateControlFromType();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		return;
		IL_0298:
		_0095._007E_0093_000F(_0008, true);
		_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeDown);
		goto IL_02be;
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
		_0095._007E_0094_000F(this._0003, false);
		_0095._007E_0094_000F(this._0004, false);
		_0095._007E_0095_000F(_0018, global::_0003._007E_0083(this._0001));
		_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0001));
		_0095._007E_0095_000F(this._0004, !global::_0003._007E_0083(this._0003));
		_0095._007E_0095_000F(this._0005, global::_0003._007E_008C(this._0004) & global::_0003._007E_0083(this._0004));
		_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0003));
		_0095._007E_0095_000F(this._0008, global::_0003._007E_0083(this._0007));
		do
		{
			_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0005));
			_0095._007E_0095_000F(this._0007, global::_0003._007E_0083(this._0006));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0002));
			bool flag = global::_0003._007E_001C(_0008) | global::_0003._007E_001C(this._0003);
			if (8u != 0)
			{
				if (flag)
				{
					_0095._007E_0095_000F(_0011, true);
				}
				else
				{
					_0095._007E_0095_000F(_0011, false);
				}
				if (0 == 0)
				{
					_0095._007E_0095_000F(_000F, !global::_0003._007E_0083(this._000E));
					_0095._007E_0095_000F(_001A, global::_0003._007E_0083(this._000E) & global::_0003._007E_008C(this._000E));
					_0095._007E_0095_000F(this._0011, global::_0003._007E_0083(this._000E) & global::_0003._007E_008C(this._000E));
					_0095._007E_0095_000F(this._000E, !global::_0003._007E_0083(_000F));
					_0095._007E_0095_000F(this._000F, global::_0003._007E_0083(_000F) & global::_0003._007E_008C(_000F));
					_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(_000F) & global::_0003._007E_008C(_000F));
					_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(_000F) & global::_0003._007E_008C(_000F));
					_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(_000F) & global::_0003._007E_008C(_000F));
				}
				if (!buMWCalcs.AdvancedTriMesh)
				{
					_0095._007E_0095_000F(this._0005, false);
					_0095._007E_0095_000F(this._0006, false);
					_0095._007E_0095_000F(this._0003, false);
					_0095._007E_0095_000F(this._0004, false);
					_0095._007E_0095_000F(_0014, false);
					continue;
				}
				break;
			}
			break;
		}
		while (false);
	}

	public void Apply()
	{
		_0094 obj = _0094._007E_0091_0007;
		MachiningParams par = Par;
		double num = _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001));
		if (uint.MaxValue != 0)
		{
			obj(par, num);
		}
		_0094._007E_0080_0007(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
		_0094._007E_0088_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0006)));
		_0094._007E_0087_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		_0094._007E_0003_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
		_0094._007E_0004_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
		_0094._007E_0005_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0011)));
		_0094._007E_001A_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0008)));
		_0094._007E_0019_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._000E)));
		_0094._007E_0018_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._000F)));
		_0094._007E_0006_000E(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0007)));
		_0094._007E_0007_000E(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0010)));
		_0095._007E_001F_0010(_0016_0004._007E_0007_0015(Par), global::_0003._007E_0083(this._0006));
		_0095._007E_0083_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0007));
		_0095._007E_0084_0010(_001D_0004._007E_0016_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), global::_0003._007E_0083(this._0003));
		_0095._007E_0083_0010(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), global::_0003._007E_0083(this._0005));
		_0095._007E_0087_0010(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0008));
		_0095._007E_0091_0010(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(_000F));
		_0095._007E_0092_0010(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._000E));
		_0095._007E_0084_000F(_0084_0002._007E_008F_0012(Par), global::_0003._007E_0083(this._0002));
		_0095._007E_0093_0010(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0001));
		_0095._007E_0086_000F(Par, global::_0003._007E_0083(this._0004));
		_0095._007E_0007_000F(Par, global::_0003._007E_0083(this._0010));
		bool num2 = global::_0003._007E_001C(this._0002);
		if (4 == 0)
		{
			goto IL_053d;
		}
		if (true)
		{
			if (num2)
			{
				_001C_0002._007E_0086_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScLowerLeft);
			}
			else
			{
				if (!global::_0003._007E_001C(this._0001))
				{
					bool flag = global::_0003._007E_001C(_0007);
					num2 = flag;
					goto IL_053d;
				}
				_001C_0002._007E_0086_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScLowerRight);
				if (6 == 0)
				{
					goto IL_05d4;
				}
			}
			goto IL_05a5;
		}
		goto IL_05b9;
		IL_05d4:
		if (global::_0003._007E_001C(this._0005))
		{
			_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeZigzag);
		}
		else if (global::_0003._007E_001C(this._0003))
		{
			_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeUp);
		}
		else if (global::_0003._007E_001C(_0008))
		{
			_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeDown);
		}
		return;
		IL_05a5:
		bool flag2 = global::_0003._007E_001C(this._0004);
		num2 = flag2;
		goto IL_05b9;
		IL_053d:
		if (num2)
		{
			_001C_0002._007E_0086_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScUpperLeft);
		}
		else if (global::_0003._007E_001C(_0006))
		{
			_001C_0002._007E_0086_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScUpperRight);
		}
		goto IL_05a5;
		IL_05b9:
		if (num2)
		{
			_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeOneway);
			return;
		}
		goto IL_05d4;
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
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_049b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a5: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Expected O, but got Unknown
		//IL_05d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e2: Expected O, but got Unknown
		//IL_04f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ff: Expected O, but got Unknown
		//IL_0532: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Expected O, but got Unknown
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_0595: Unknown result type (might be due to invalid IL or missing references)
		//IL_059f: Expected O, but got Unknown
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		//IL_062c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0636: Expected O, but got Unknown
		//IL_06bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c7: Expected O, but got Unknown
		//IL_0669: Unknown result type (might be due to invalid IL or missing references)
		//IL_0673: Expected O, but got Unknown
		//IL_074e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0758: Expected O, but got Unknown
		//IL_06fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0704: Expected O, but got Unknown
		//IL_07df: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e9: Expected O, but got Unknown
		//IL_078b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0795: Expected O, but got Unknown
		//IL_081c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0826: Expected O, but got Unknown
		Control control = new Control();
		control = (Control)P_0;
		bool num = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0014));
		F_MwTriMRoughLink f_MwTriMRoughLink;
		if (4u != 0)
		{
			if (num)
			{
				F_MWTriMDynamicalHolderColl f_MWTriMDynamicalHolderColl = new F_MWTriMDynamicalHolderColl();
				f_MWTriMDynamicalHolderColl.Par = new MachiningParams(Par);
				f_MWTriMDynamicalHolderColl.Init();
				_009D_0003._007E_0091_0014(f_MWTriMDynamicalHolderColl);
				if (f_MWTriMDynamicalHolderColl.Properties.Result == DialogResult.OK)
				{
					if (false)
					{
						goto IL_0222;
					}
					Par = new MachiningParams(f_MWTriMDynamicalHolderColl.Par);
					global::_0011._007E_001C_0006(f_MWTriMDynamicalHolderColl);
				}
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0013)))
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
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0012)))
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
				goto IL_0222;
			}
			goto IL_0267;
		}
		goto IL_03f5;
		IL_03f5:
		F_MwTriMAngleRange f_MwTriMAngleRange;
		if (num)
		{
			Par = new MachiningParams(f_MwTriMAngleRange.Par);
			global::_0011._007E_001C_0006(f_MwTriMAngleRange);
		}
		goto IL_041d;
		IL_02d4:
		bool num2;
		F_MwTriMRoughing f_MwTriMRoughing = default(F_MwTriMRoughing);
		if (num2 != 0)
		{
			Par = new MachiningParams(f_MwTriMRoughing.Par);
			global::_0011._007E_001C_0006(f_MwTriMRoughing);
		}
		goto IL_02f8;
		IL_037d:
		F_MwGaugeCheck f_MwGaugeCheck = default(F_MwGaugeCheck);
		global::_0011._007E_001C_0006(f_MwGaugeCheck);
		goto IL_038c;
		IL_0222:
		_009D_0003._007E_0091_0014(f_MwTriMRoughLink);
		if (f_MwTriMRoughLink.Properties.Result == DialogResult.OK)
		{
			Par = new MachiningParams(f_MwTriMRoughLink.Par);
			global::_0011._007E_001C_0006(f_MwTriMRoughLink);
		}
		goto IL_0267;
		IL_02f8:
		bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000F));
		num2 = flag;
		if (2 == 0)
		{
			goto IL_02d4;
		}
		if (num2)
		{
			f_MwGaugeCheck = new F_MwGaugeCheck();
			f_MwGaugeCheck.Par = new MachiningParams(Par);
			f_MwGaugeCheck.Init();
			_009D_0003._007E_0091_0014(f_MwGaugeCheck);
			if (f_MwGaugeCheck.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwGaugeCheck.Par);
				goto IL_037d;
			}
		}
		goto IL_038c;
		IL_0267:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			f_MwTriMRoughing = new F_MwTriMRoughing();
			f_MwTriMRoughing.Par = new MachiningParams(Par);
			f_MwTriMRoughing.Init();
			_009D_0003._007E_0091_0014(f_MwTriMRoughing);
			bool flag2 = f_MwTriMRoughing.Properties.Result == DialogResult.OK;
			num2 = flag2;
			goto IL_02d4;
		}
		goto IL_02f8;
		IL_041d:
		F_MwTriMRoundCorner f_MwTriMRoundCorner = default(F_MwTriMRoundCorner);
		while (true)
		{
			bool flag3 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002));
			if (7 == 0)
			{
				break;
			}
			if (flag3)
			{
				F_MwTriMSurfaceQuality f_MwTriMSurfaceQuality = new F_MwTriMSurfaceQuality();
				f_MwTriMSurfaceQuality.Par = new MachiningParams(Par);
				f_MwTriMSurfaceQuality.Init();
				_009D_0003._007E_0091_0014(f_MwTriMSurfaceQuality);
				if (f_MwTriMSurfaceQuality.Properties.Result == DialogResult.OK)
				{
					Par = new MachiningParams(f_MwTriMSurfaceQuality.Par);
					global::_0011._007E_001C_0006(f_MwTriMSurfaceQuality);
				}
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0008)))
			{
				if (false)
				{
					continue;
				}
				F_MwTriMSilhouette f_MwTriMSilhouette = new F_MwTriMSilhouette();
				f_MwTriMSilhouette.Par = new MachiningParams(Par);
				f_MwTriMSilhouette.Init();
				_009D_0003._007E_0091_0014(f_MwTriMSilhouette);
				if (f_MwTriMSilhouette.Properties.Result == DialogResult.OK)
				{
					Par = new MachiningParams(f_MwTriMSilhouette.Par);
					global::_0011._007E_001C_0006(f_MwTriMSilhouette);
					if (false)
					{
						goto IL_0682;
					}
				}
			}
			if (6 == 0)
			{
				goto IL_05cf;
			}
			bool flag4 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005));
			if (7u != 0)
			{
				if (flag4)
				{
					f_MwTriMRoundCorner = new F_MwTriMRoundCorner();
					f_MwTriMRoundCorner.Par = new MachiningParams(Par);
					f_MwTriMRoundCorner.Init();
					if (false)
					{
						goto IL_06b5;
					}
					_009D_0003._007E_0091_0014(f_MwTriMRoundCorner);
					if (f_MwTriMRoundCorner.Properties.Result == DialogResult.OK)
					{
						goto IL_05cf;
					}
				}
				goto IL_05f1;
			}
			goto IL_0713;
			IL_0682:
			F_MwTriM2dContainment f_MwTriM2dContainment;
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0007)))
			{
				f_MwTriM2dContainment = new F_MwTriM2dContainment();
				goto IL_06b5;
			}
			goto IL_0713;
			IL_0713:
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0011)))
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
			return;
			IL_05f1:
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
			goto IL_0682;
			IL_05cf:
			Par = new MachiningParams(f_MwTriMRoundCorner.Par);
			global::_0011._007E_001C_0006(f_MwTriMRoundCorner);
			goto IL_05f1;
			IL_06b5:
			f_MwTriM2dContainment.Par = new MachiningParams(Par);
			f_MwTriM2dContainment.Init();
			_009D_0003._007E_0091_0014(f_MwTriM2dContainment);
			if (f_MwTriM2dContainment.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriM2dContainment.Par);
				global::_0011._007E_001C_0006(f_MwTriM2dContainment);
			}
			goto IL_0713;
		}
		goto IL_037d;
		IL_038c:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			f_MwTriMAngleRange = new F_MwTriMAngleRange();
			f_MwTriMAngleRange.Par = new MachiningParams(Par);
			f_MwTriMAngleRange.Init();
			_009D_0003._007E_0091_0014(f_MwTriMAngleRange);
			num = f_MwTriMAngleRange.Properties.Result == DialogResult.OK;
			goto IL_03f5;
		}
		goto IL_041d;
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
