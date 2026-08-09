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

public class F_MwTriMProjectCurStd : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	[CompilerGenerated]
	private MWDataOrjOkHandler m__0001;

	[CompilerGenerated]
	private CancelCommandEventHandler m__0001;

	private IContainer m__0001 = null;

	internal Panel _0001;

	internal Label _0001;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Button _0001;

	internal Label _0002;

	internal PictureBox _0001;

	internal Button _0002;

	public Button btn_cancel;

	internal ImageList _0001;

	internal Label _0003;

	internal CheckBox _0001;

	internal Label _0004;

	internal NumericUpDown _0001;

	internal Label _0005;

	internal NumericUpDown _0002;

	internal Label _0006;

	internal NumericUpDown _0003;

	internal Label _0007;

	public Button btn_ok;

	internal Panel _0002;

	internal Button _0003;

	internal Panel _0003;

	internal Button _0004;

	internal Button _0005;

	internal Label _0008;

	internal TabPage _0001;

	internal Button _0006;

	internal Panel _0004;

	internal CheckBox _0002;

	internal Button _0007;

	internal CheckBox _0003;

	internal Button _0008;

	internal CheckBox _0004;

	internal Button _000E;

	internal CheckBox _0005;

	internal Button _000F;

	internal CheckBox _0006;

	internal Label _000E;

	internal Button _0010;

	internal Panel _0005;

	internal Panel _0006;

	internal Label _000F;

	internal Button _0011;

	internal NumericUpDown _0004;

	internal Label _0010;

	internal Panel _0007;

	internal Label _0011;

	internal TabControl _0001;

	internal RadioButton _0003;

	internal Button _0012;

	internal Panel _0008;

	internal Label _0012;

	internal RadioButton _0004;

	internal RadioButton _0005;

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

	public F_MwTriMProjectCurStd()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		int num = Properties.Height;
		if (7 == 0)
		{
			goto IL_00db;
		}
		if (num > 10)
		{
			_0097._008C_0011(this, Properties.Height);
		}
		bool num2 = Properties.Width > 10;
		if (0 == 0)
		{
			if (num2)
			{
				goto IL_0076;
			}
			goto IL_0094;
		}
		goto IL_00dd;
		IL_00db:
		bool flag = (byte)num != 0;
		num2 = flag;
		goto IL_00dd;
		IL_0376:
		UpdateControlFromType();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		return;
		IL_00dd:
		if (num2)
		{
			_0095._007E_0093_000F(this._0001, true);
		}
		else if (_0092._007E_0016_0007(Par) == MachiningParamsMachType.MachtypeZigzag)
		{
			_0095._007E_0093_000F(this._0002, true);
		}
		else if (_0092._007E_0016_0007(Par) == MachiningParamsMachType.MachtypeUserDefined)
		{
			_0095._007E_0093_000F(this._0003, true);
			if (false)
			{
				goto IL_0076;
			}
		}
		while (true)
		{
			if (_0015_0004._007E_0006_0015(Par) == MachiningParamsDirection.DirConventional)
			{
				_0095._007E_0093_000F(this._0004, true);
				if (false)
				{
					goto IL_027a;
				}
			}
			else
			{
				_0095._007E_0093_000F(this._0005, true);
			}
			_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0083_0003(Par)));
			_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0019_0003(Par)));
			_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0018_0003(Par)));
			if (1 == 0)
			{
				break;
			}
			_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0017_0003(Par)));
			_0095._007E_0096_000F(this._0004, global::_0003._007E_0003_0002(_0016_0004._007E_0007_0015(Par)));
			goto IL_027a;
			IL_027a:
			_0095._007E_0096_000F(this._0005, global::_0003._007E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
			if (1 == 0)
			{
				continue;
			}
			goto IL_02b6;
		}
		goto IL_0376;
		IL_02ea:
		_0095._007E_0096_000F(this._0003, global::_0003._007E_0008_0002(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0095._007E_0096_000F(this._0002, global::_0003._007E_000E_0002(_0084_0002._007E_008F_0012(Par)));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0007(Par));
		goto IL_0376;
		IL_0076:
		_0097._008D_0011(this, Properties.Width);
		if (0 == 0)
		{
			goto IL_0094;
		}
		goto IL_02ea;
		IL_0094:
		_0095._0092_000F(this, Properties.TopMost);
		if (4u != 0)
		{
			_0086_0003._0018_0014(this, Properties.FormPosition);
			num = ((_0092._007E_0016_0007(Par) == MachiningParamsMachType.MachtypeOneway) ? 1 : 0);
			goto IL_00db;
		}
		goto IL_0376;
		IL_02b6:
		_0095._007E_0096_000F(this._0006, global::_0003._007E_0012_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
		goto IL_02ea;
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
		if (false)
		{
			return;
		}
		if (5u != 0)
		{
			_0095._007E_0095_000F(this._000F, global::_0003._007E_008C(this._0005) & global::_0003._007E_0083(this._0005));
			if (1 == 0)
			{
				return;
			}
			if (2u != 0)
			{
			}
			_0095._007E_0095_000F(this._0008, global::_0003._007E_008C(this._0003) & global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._000E, global::_0003._007E_008C(this._0004) & global::_0003._007E_0083(this._0004));
		}
		_0095._007E_0095_000F(this._0007, global::_0003._007E_008C(this._0002) & global::_0003._007E_0083(this._0002));
	}

	public void Apply()
	{
		while (true)
		{
			_0094._007E_0087_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
			_0094._007E_001A_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
			while (true)
			{
				bool flag;
				if (8u != 0)
				{
					_0094._007E_0019_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
					_0094._007E_0018_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
					if (0 == 0)
					{
						_0095._007E_001F_0010(_0016_0004._007E_0007_0015(Par), global::_0003._007E_0083(this._0004));
						_0095._007E_0083_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0005));
						_0095._007E_0083_0010(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), global::_0003._007E_0083(this._0003));
						_0095._007E_0084_000F(_0084_0002._007E_008F_0012(Par), global::_0003._007E_0083(this._0002));
						_0095._007E_0087_0010(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0006));
						_0095._007E_0007_000F(Par, global::_0003._007E_0083(this._0001));
						if (false)
						{
							goto IL_028f;
						}
						if (global::_0003._007E_001C(this._0001))
						{
							_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeOneway);
							goto IL_027b;
						}
					}
					flag = global::_0003._007E_001C(this._0002);
				}
				if (flag)
				{
					if (5 == 0)
					{
						break;
					}
					_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeZigzag);
				}
				else if (global::_0003._007E_001C(this._0003))
				{
					_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeUserDefined);
				}
				goto IL_027b;
				IL_02d2:
				if (3u != 0)
				{
					return;
				}
				continue;
				IL_028c:
				bool flag2;
				if (flag2)
				{
					goto IL_028f;
				}
				if (global::_0003._007E_001C(this._0004))
				{
					_0017_0002._007E_001F_0012(Par, MachiningParamsDirection.DirConventional);
				}
				goto IL_02d2;
				IL_028f:
				_0017_0002._007E_001F_0012(Par, MachiningParamsDirection.DirClimb);
				if (2 == 0)
				{
					goto IL_028c;
				}
				goto IL_02d2;
				IL_027b:
				flag2 = global::_0003._007E_001C(this._0005);
				goto IL_028c;
			}
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
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Expected O, but got Unknown
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Expected O, but got Unknown
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected O, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Expected O, but got Unknown
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Expected O, but got Unknown
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f6: Expected O, but got Unknown
		//IL_0498: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a2: Expected O, but got Unknown
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Expected O, but got Unknown
		//IL_0583: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Expected O, but got Unknown
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Expected O, but got Unknown
		//IL_0614: Unknown result type (might be due to invalid IL or missing references)
		//IL_061e: Expected O, but got Unknown
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Expected O, but got Unknown
		//IL_06a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06af: Expected O, but got Unknown
		//IL_0651: Unknown result type (might be due to invalid IL or missing references)
		//IL_065b: Expected O, but got Unknown
		//IL_06e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ec: Expected O, but got Unknown
		Control control = new Control();
		control = (Control)P_0;
		bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002));
		bool num = flag;
		if (3u != 0)
		{
			if (num)
			{
				F_MWTriMDynamicalHolderColl f_MWTriMDynamicalHolderColl = new F_MWTriMDynamicalHolderColl();
				f_MWTriMDynamicalHolderColl.Par = new MachiningParams(Par);
				f_MWTriMDynamicalHolderColl.Init();
				_009D_0003._007E_0091_0014(f_MWTriMDynamicalHolderColl);
				if (f_MWTriMDynamicalHolderColl.Properties.Result == DialogResult.OK)
				{
					Par = new MachiningParams(f_MWTriMDynamicalHolderColl.Par);
					global::_0011._007E_001C_0006(f_MWTriMDynamicalHolderColl);
				}
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
			{
				F_MwTriMHeights f_MwTriMHeights = new F_MwTriMHeights();
				f_MwTriMHeights.Par = new MachiningParams(Par);
				f_MwTriMHeights.Init();
				if (8 == 0)
				{
					goto IL_02fe;
				}
				_009D_0003._007E_0091_0014(f_MwTriMHeights);
				if (f_MwTriMHeights.Properties.Result == DialogResult.OK)
				{
					Par = new MachiningParams(f_MwTriMHeights.Par);
					global::_0011._007E_001C_0006(f_MwTriMHeights);
				}
			}
			while (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
			{
				F_MwTriMOffset f_MwTriMOffset = new F_MwTriMOffset();
				f_MwTriMOffset.Par = new MachiningParams(Par);
				f_MwTriMOffset.Init();
				_009D_0003._007E_0091_0014(f_MwTriMOffset);
				if (f_MwTriMOffset.Properties.Result != DialogResult.OK)
				{
					break;
				}
				Par = new MachiningParams(f_MwTriMOffset.Par);
				global::_0011._007E_001C_0006(f_MwTriMOffset);
				if (5u != 0)
				{
					break;
				}
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
			{
				F_MwTriMRoughLink f_MwTriMRoughLink = new F_MwTriMRoughLink();
				f_MwTriMRoughLink.Par = new MachiningParams(Par);
				f_MwTriMRoughLink.Init();
				_009D_0003._007E_0091_0014(f_MwTriMRoughLink);
				if (f_MwTriMRoughLink.Properties.Result == DialogResult.OK)
				{
					Par = new MachiningParams(f_MwTriMRoughLink.Par);
					global::_0011._007E_001C_0006(f_MwTriMRoughLink);
				}
			}
			bool flag2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006));
			num = flag2;
		}
		if (num)
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
		goto IL_02fe;
		IL_066a:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0010)))
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
		IL_02fe:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0007)))
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0011)))
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000F)))
		{
			F_MwTriMSilhouette f_MwTriMSilhouette = new F_MwTriMSilhouette();
			f_MwTriMSilhouette.Par = new MachiningParams(Par);
			f_MwTriMSilhouette.Init();
			_009D_0003._007E_0091_0014(f_MwTriMSilhouette);
			if (f_MwTriMSilhouette.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMSilhouette.Par);
				global::_0011._007E_001C_0006(f_MwTriMSilhouette);
				if (7 == 0)
				{
					goto IL_066a;
				}
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0008)))
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000E)))
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
		goto IL_066a;
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
