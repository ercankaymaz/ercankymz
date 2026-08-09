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

public class F_MwTriMPencil : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	[CompilerGenerated]
	private MWDataOrjOkHandler m__0001;

	[CompilerGenerated]
	private CancelCommandEventHandler m__0001;

	internal IContainer _0001 = null;

	internal Panel _0001;

	internal Label _0001;

	internal RadioButton _0001;

	internal Label _0002;

	internal RadioButton _0002;

	internal RadioButton _0003;

	internal Panel _0002;

	internal Button _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	internal Label _0003;

	internal Label _0004;

	internal NumericUpDown _0001;

	internal Label _0005;

	internal NumericUpDown _0002;

	internal Label _0006;

	internal Panel _0003;

	internal CheckBox _0001;

	internal Label _0007;

	internal NumericUpDown _0003;

	internal Label _0008;

	internal CheckBox _0002;

	internal Label _000E;

	internal Panel _0004;

	internal NumericUpDown _0004;

	public Button btn_ok;

	internal Label _000F;

	internal Button _0002;

	internal Button _0003;

	internal Panel _0005;

	internal Label _0010;

	internal TabPage _0001;

	internal Panel _0006;

	internal CheckBox _0003;

	internal Button _0004;

	internal CheckBox _0004;

	internal Button _0005;

	internal CheckBox _0005;

	internal Button _0006;

	internal Label _0011;

	internal Button _0007;

	internal Button _0008;

	internal Panel _0007;

	internal Label _0012;

	internal Button _000E;

	internal NumericUpDown _0005;

	internal Label _0013;

	internal Button _000F;

	internal Panel _0008;

	internal TabControl _0001;

	internal PictureBox _0001;

	internal Label _0014;

	internal NumericUpDown _0006;

	internal RadioButton _0004;

	internal Button _0010;

	internal CheckBox _0006;

	internal Button _0011;

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
					MWDataOrjOkHandler obj = (MWDataOrjOkHandler)_0016._008D_0006(mWDataOrjOkHandler2, value);
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
					MWDataOrjOkHandler obj = (MWDataOrjOkHandler)_0016._008E_0006(mWDataOrjOkHandler2, value);
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
					CancelCommandEventHandler obj = (CancelCommandEventHandler)_0016._008D_0006(cancelCommandEventHandler2, value);
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
					CancelCommandEventHandler obj = (CancelCommandEventHandler)_0016._008E_0006(cancelCommandEventHandler2, value);
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

	public F_MwTriMPencil()
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
		bool num = Properties.Width > 10;
		bool flag = default(bool);
		if (0 == 0)
		{
			flag = num;
		}
		if (flag)
		{
			_0097._008D_0011(this, Properties.Width);
		}
		_0095._0092_000F(this, Properties.TopMost);
		_0086_0003._0018_0014(this, Properties.FormPosition);
		if (!buMWCalcs.AdvancedTriMesh)
		{
			_0095._007E_001B_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), false);
			_0095._007E_0082_0010(Par, false);
		}
		if (_0092._007E_0016_0007(Par) == MachiningParamsMachType.MachtypeOneway)
		{
			_0095._007E_0093_000F(this._0001, true);
		}
		else if (_0092._007E_0016_0007(Par) == MachiningParamsMachType.MachtypeZigzag)
		{
			_0095._007E_0093_000F(this._0004, true);
		}
		if (_0015_0004._007E_0006_0015(Par) == MachiningParamsDirection.DirConventional)
		{
			_0095._007E_0093_000F(this._0002, true);
		}
		else
		{
			_0095._007E_0093_000F(this._0003, true);
		}
		_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_0083_0003(Par)));
		_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0019_0003(Par)));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0018_0003(Par)));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0017_0003(Par)));
		_0088_0003._007E_001A_0014(this._0003, _0004_0004._0097_0014(global::_000E._007E_0012_0006(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_0087_0003(Par)));
		_0095._007E_0096_000F(this._0004, global::_0003._007E_0003_0002(_0016_0004._007E_0007_0015(Par)));
		_0095._007E_0096_000F(this._0005, global::_0003._007E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_008D_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
		_0095._007E_0096_000F(this._0003, global::_0003._007E_000E_0002(_0084_0002._007E_008F_0012(Par)));
		_0095._007E_0096_000F(this._0002, global::_0003._007E_0007(Par));
		_0095._007E_0096_000F(_0006, global::_0003._007E_0010_0002(Par));
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
		_0095._007E_0095_000F(this._0007, global::_0003._007E_0083(this._0001));
		while (true)
		{
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0001));
			if (0 == 0)
			{
				_0095._007E_0095_000F(_0014, global::_0003._007E_0083(this._0001));
				_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0001));
				if (false)
				{
					goto IL_0176;
				}
				_0095._007E_0095_000F(this._0006, global::_0003._007E_008C(this._0005) & global::_0003._007E_0083(this._0005));
			}
			if (false)
			{
				continue;
			}
			_0095._007E_0095_000F(this._0005, global::_0003._007E_008C(this._0004) & global::_0003._007E_0083(this._0004));
			if (0 == 0)
			{
				_0095._007E_0095_000F(this._0004, global::_0003._007E_008C(this._0003) & global::_0003._007E_0083(this._0003));
				_0095._007E_0095_000F(_0010, global::_0003._007E_008C(_0006) & global::_0003._007E_0083(_0006));
				goto IL_0176;
			}
			goto IL_01ea;
			IL_0176:
			bool num = global::_0003._007E_0083(this._0001);
			if (0 == 0)
			{
				if (num)
				{
					_0095._007E_0095_000F(this._0004, true);
				}
				else
				{
					_0095._007E_0095_000F(this._0004, false);
					_0095._007E_0093_000F(this._0001, true);
					if (false)
					{
						goto IL_01fc;
					}
				}
				bool flag = !buMWCalcs.AdvancedTriMesh;
				num = flag;
			}
			if (num)
			{
				_0095._007E_0095_000F(this._0001, false);
				goto IL_01ea;
			}
			break;
			IL_01ea:
			_0095._007E_0095_000F(this._0003, false);
			goto IL_01fc;
			IL_01fc:
			_0095._007E_0095_000F(this._0007, false);
			_0095._007E_0095_000F(_0006, false);
			_0095._007E_0095_000F(_0010, false);
			if (0 == 0)
			{
				_0095._007E_0095_000F(this._0001, false);
				break;
			}
			goto IL_0176;
		}
	}

	public void Apply()
	{
		_0094._007E_0088_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0006)));
		while (true)
		{
			if (6 == 0)
			{
				goto IL_019e;
			}
			_0094._007E_0087_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
			if (0 == 0)
			{
				_0094._007E_001A_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
				if (false)
				{
					break;
				}
				_0094._007E_0019_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
				_0094._007E_0018_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
				_0097._007E_0089_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _000F_0004._009F_0014(global::_0008._007E_0099_0005(this._0003)));
				_0095._007E_001F_0010(_0016_0004._007E_0007_0015(Par), global::_0003._007E_0083(this._0004));
				goto IL_0168;
			}
			goto IL_0252;
			IL_02bf:
			_0017_0002._007E_001F_0012(Par, MachiningParamsDirection.DirClimb);
			return;
			IL_0168:
			_0095._007E_0083_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0005));
			goto IL_019e;
			IL_0252:
			if (global::_0003._007E_001C(this._0001))
			{
				_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeOneway);
				if (false)
				{
					goto IL_0168;
				}
			}
			else if (global::_0003._007E_001C(this._0004))
			{
				_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeZigzag);
			}
			if (!global::_0003._007E_001C(this._0003))
			{
				break;
			}
			goto IL_02bf;
			IL_019e:
			_0095._007E_0084_000F(_0084_0002._007E_008F_0012(Par), global::_0003._007E_0083(this._0003));
			_0095._007E_001B_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0001));
			_0095._007E_0007_000F(Par, global::_0003._007E_0083(this._0002));
			if (0 == 0)
			{
				if (0 == 0)
				{
					_0095._007E_0082_0010(Par, global::_0003._007E_0083(_0006));
					if (false)
					{
						continue;
					}
					goto IL_0252;
				}
				return;
			}
			goto IL_02bf;
		}
		if (global::_0003._007E_001C(this._0002))
		{
			_0017_0002._007E_001F_0012(Par, MachiningParamsDirection.DirConventional);
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
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_047d: Expected O, but got Unknown
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_050e: Expected O, but got Unknown
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Expected O, but got Unknown
		//IL_059b: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Expected O, but got Unknown
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ba: Expected O, but got Unknown
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_063c: Expected O, but got Unknown
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_0551: Expected O, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		//IL_066f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0679: Expected O, but got Unknown
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e8: Expected O, but got Unknown
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected O, but got Unknown
		Control control = new Control();
		control = (Control)P_0;
		F_MWTriMDynamicalHolderColl f_MWTriMDynamicalHolderColl;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			f_MWTriMDynamicalHolderColl = new F_MWTriMDynamicalHolderColl();
			f_MWTriMDynamicalHolderColl.Par = new MachiningParams(Par);
			f_MWTriMDynamicalHolderColl.Init();
			_009D_0003._007E_0091_0014(f_MWTriMDynamicalHolderColl);
			if (f_MWTriMDynamicalHolderColl.Properties.Result == DialogResult.OK)
			{
				goto IL_0089;
			}
		}
		goto IL_00a8;
		IL_00a8:
		F_MwTriMRoughLink f_MwTriMRoughLink = default(F_MwTriMRoughLink);
		bool flag = default(bool);
		while (true)
		{
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
			{
				if (false)
				{
					goto IL_0417;
				}
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
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0011)))
			{
				goto IL_016a;
			}
			goto IL_01d0;
			IL_0438:
			F_MwTriMSurfaceQuality f_MwTriMSurfaceQuality;
			bool num;
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_000E)))
			{
				f_MwTriMSurfaceQuality = new F_MwTriMSurfaceQuality();
				f_MwTriMSurfaceQuality.Par = new MachiningParams(Par);
				f_MwTriMSurfaceQuality.Init();
				_009D_0003._007E_0091_0014(f_MwTriMSurfaceQuality);
				num = f_MwTriMSurfaceQuality.Properties.Result == DialogResult.OK;
				goto IL_04a1;
			}
			goto IL_04c9;
			IL_04a1:
			if (num)
			{
				Par = new MachiningParams(f_MwTriMSurfaceQuality.Par);
				global::_0011._007E_001C_0006(f_MwTriMSurfaceQuality);
			}
			goto IL_04c9;
			IL_016a:
			F_MwTriMOffset f_MwTriMOffset = new F_MwTriMOffset();
			f_MwTriMOffset.Par = new MachiningParams(Par);
			f_MwTriMOffset.Init();
			_009D_0003._007E_0091_0014(f_MwTriMOffset);
			if (f_MwTriMOffset.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMOffset.Par);
				global::_0011._007E_001C_0006(f_MwTriMOffset);
			}
			goto IL_01d0;
			IL_0417:
			F_MwTriMAngleRange f_MwTriMAngleRange;
			Par = new MachiningParams(f_MwTriMAngleRange.Par);
			global::_0011._007E_001C_0006(f_MwTriMAngleRange);
			goto IL_0438;
			IL_01d0:
			if (4 == 0)
			{
				continue;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_000F)))
			{
				f_MwTriMRoughLink = new F_MwTriMRoughLink();
				f_MwTriMRoughLink.Par = new MachiningParams(Par);
				f_MwTriMRoughLink.Init();
				_009D_0003._007E_0091_0014(f_MwTriMRoughLink);
				flag = f_MwTriMRoughLink.Properties.Result == DialogResult.OK;
				goto IL_0241;
			}
			goto IL_0267;
			IL_04c9:
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
			{
				F_MwTriMSilhouette f_MwTriMSilhouette = new F_MwTriMSilhouette();
				f_MwTriMSilhouette.Par = new MachiningParams(Par);
				if (false)
				{
					goto IL_01d0;
				}
				f_MwTriMSilhouette.Init();
				_009D_0003._007E_0091_0014(f_MwTriMSilhouette);
				if (f_MwTriMSilhouette.Properties.Result == DialogResult.OK)
				{
					Par = new MachiningParams(f_MwTriMSilhouette.Par);
					global::_0011._007E_001C_0006(f_MwTriMSilhouette);
				}
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
			{
				F_MwTriM2dContainment f_MwTriM2dContainment = new F_MwTriM2dContainment();
				f_MwTriM2dContainment.Par = new MachiningParams(Par);
				f_MwTriM2dContainment.Init();
				if (false)
				{
					goto IL_016a;
				}
				_009D_0003._007E_0091_0014(f_MwTriM2dContainment);
				if (f_MwTriM2dContainment.Properties.Result == DialogResult.OK)
				{
					Par = new MachiningParams(f_MwTriM2dContainment.Par);
					global::_0011._007E_001C_0006(f_MwTriM2dContainment);
				}
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0007)))
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
			IL_0241:
			if (flag)
			{
				Par = new MachiningParams(f_MwTriMRoughLink.Par);
				global::_0011._007E_001C_0006(f_MwTriMRoughLink);
			}
			goto IL_0267;
			IL_0267:
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
			{
				F_MwTriMRoughing f_MwTriMRoughing = new F_MwTriMRoughing();
				f_MwTriMRoughing.Par = new MachiningParams(Par);
				f_MwTriMRoughing.Init();
				_009D_0003._007E_0091_0014(f_MwTriMRoughing);
				if (f_MwTriMRoughing.Properties.Result == DialogResult.OK)
				{
					Par = new MachiningParams(f_MwTriMRoughing.Par);
					global::_0011._007E_001C_0006(f_MwTriMRoughing);
				}
			}
			bool num2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0008));
			if (0 == 0)
			{
				bool flag2 = num2;
				num = flag2;
				if (false)
				{
					goto IL_04a1;
				}
				if (num)
				{
					if (false)
					{
						break;
					}
					F_MwGaugeCheck f_MwGaugeCheck = new F_MwGaugeCheck();
					f_MwGaugeCheck.Par = new MachiningParams(Par);
					if (7 == 0)
					{
						goto IL_0241;
					}
					f_MwGaugeCheck.Init();
					_009D_0003._007E_0091_0014(f_MwGaugeCheck);
					if (f_MwGaugeCheck.Properties.Result == DialogResult.OK)
					{
						Par = new MachiningParams(f_MwGaugeCheck.Par);
						global::_0011._007E_001C_0006(f_MwGaugeCheck);
					}
				}
				if (false)
				{
					continue;
				}
				bool flag3 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004));
				num2 = flag3;
			}
			if (num2)
			{
				f_MwTriMAngleRange = new F_MwTriMAngleRange();
				f_MwTriMAngleRange.Par = new MachiningParams(Par);
				f_MwTriMAngleRange.Init();
				_009D_0003._007E_0091_0014(f_MwTriMAngleRange);
				if (f_MwTriMAngleRange.Properties.Result == DialogResult.OK)
				{
					goto IL_0417;
				}
			}
			goto IL_0438;
		}
		goto IL_0089;
		IL_0089:
		Par = new MachiningParams(f_MWTriMDynamicalHolderColl.Par);
		global::_0011._007E_001C_0006(f_MWTriMDynamicalHolderColl);
		goto IL_00a8;
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
