using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriMRoughLink : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	internal IContainer _0001 = null;

	internal Panel _0001;

	internal Label _0001;

	internal Label _0002;

	internal Label _0003;

	internal CheckBox _0001;

	internal CheckBox _0002;

	internal CheckBox _0003;

	internal CheckBox _0004;

	internal Panel _0002;

	internal Label _0004;

	internal Label _0005;

	internal Label _0006;

	public ComboBox combo_firstentry;

	public ComboBox combo_lastexitramp;

	public ComboBox combo_firstentryramp;

	public ComboBox combo_lastexit;

	public ComboBox combo_arealinkbetweengroupramp;

	public ComboBox combo_arealinkbetweengroup;

	public ComboBox combo_arealinkwithingroupramp;

	public ComboBox combo_arealinkswithingroup;

	internal Panel _0003;

	public ComboBox combo_linkbetweenslicesramp;

	public ComboBox combo_linkbetweenslices;

	internal Label _0007;

	internal Label _0008;

	internal Panel _0004;

	public ComboBox combo_linkbetweenregionrapm;

	public ComboBox combo_linkbetweenregion;

	internal Label _000E;

	internal Label _000F;

	internal Button _0001;

	internal Label _0010;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	public F_MwTriMRoughLink()
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
		if (false)
		{
			goto IL_0aa7;
		}
		if (Properties.Width > 10)
		{
			_0097._008D_0011(this, Properties.Width);
		}
		bool flag2;
		while (true)
		{
			_0095._0092_000F(this, Properties.TopMost);
			_0086_0003._0018_0014(this, Properties.FormPosition);
			if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(Par))) == FirstEntryType.FromRapidPlane)
			{
				_0097._007E_008E_0011(combo_firstentry, 0);
			}
			else if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(Par))) == FirstEntryType.UseRapidDistance)
			{
				_0097._007E_008E_0011(combo_firstentry, 1);
			}
			else if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(Par))) == FirstEntryType.UseFeedDistance)
			{
				_0097._007E_008E_0011(combo_firstentry, 2);
			}
			else
			{
				_0097._007E_008E_0011(combo_firstentry, 0);
			}
			if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(Par))) == LastExitType.BackToRapidPlane)
			{
				goto IL_01c2;
			}
			if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(Par))) == LastExitType.UseRapidDistance)
			{
				if (false)
				{
					goto IL_01c2;
				}
				_0097._007E_008E_0011(combo_lastexit, 1);
			}
			else
			{
				if (7 == 0)
				{
					goto IL_06e5;
				}
				if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(Par))) == LastExitType.UseFeedDistance)
				{
					_0097._007E_008E_0011(combo_lastexit, 2);
				}
				else
				{
					_0097._007E_008E_0011(combo_lastexit, 0);
				}
			}
			goto IL_027e;
			IL_070e:
			if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapDirect)
			{
				_0097._007E_008E_0011(combo_linkbetweenslices, 0);
			}
			else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapBlendSpline)
			{
				_0097._007E_008E_0011(combo_linkbetweenslices, 1);
			}
			else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapStep)
			{
				_0097._007E_008E_0011(combo_linkbetweenslices, 2);
			}
			else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapBrokenFeed)
			{
				_0097._007E_008E_0011(combo_linkbetweenslices, 3);
				if (false)
				{
					continue;
				}
			}
			else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapBrokenFeedRap)
			{
				if (5 == 0)
				{
					break;
				}
				_0097._007E_008E_0011(combo_linkbetweenslices, 4);
			}
			else
			{
				if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(Par)))) != MoveHandlingAction.ActionGapRapidPlane)
				{
					goto IL_08f4;
				}
				_0097._007E_008E_0011(combo_linkbetweenslices, 5);
			}
			goto IL_0908;
			IL_01c2:
			_0097._007E_008E_0011(combo_lastexit, 0);
			goto IL_027e;
			IL_08f4:
			_0097._007E_008E_0011(combo_linkbetweenslices, 3);
			goto IL_0908;
			IL_0908:
			if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(Par)))))))
			{
				_0097._007E_008E_0011(combo_linkbetweenslicesramp, 0);
			}
			else
			{
				_0097._007E_008E_0011(combo_linkbetweenslicesramp, 1);
			}
			bool flag = _0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapDirect;
			bool num = flag;
			goto IL_09af;
			IL_09af:
			if (num)
			{
				goto IL_09b1;
			}
			if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapBlendSpline)
			{
				goto IL_0a01;
			}
			if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapBrokenFeed)
			{
				goto IL_0a51;
			}
			flag2 = _0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapBrokenFeedRap;
			if (false)
			{
				goto IL_08f4;
			}
			goto IL_0aa3;
			IL_06e5:
			_0097._007E_008E_0011(combo_arealinkbetweengroupramp, 0);
			goto IL_070e;
			IL_069c:
			if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par)))))))
			{
				goto IL_06e5;
			}
			_0097._007E_008E_0011(combo_arealinkbetweengroupramp, 1);
			goto IL_070e;
			IL_027e:
			if (global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(Par)))))
			{
				_0097._007E_008E_0011(combo_firstentryramp, 0);
			}
			else
			{
				_0097._007E_008E_0011(combo_firstentryramp, 1);
			}
			if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapDirect)
			{
				_0097._007E_008E_0011(combo_arealinkswithingroup, 0);
			}
			else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapBlendSpline)
			{
				_0097._007E_008E_0011(combo_arealinkswithingroup, 1);
			}
			else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapBrokenFeed)
			{
				_0097._007E_008E_0011(combo_arealinkswithingroup, 2);
			}
			else
			{
				num = _0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapBrokenFeedRap;
				if (7 == 0)
				{
					goto IL_09af;
				}
				if (num)
				{
					_0097._007E_008E_0011(combo_arealinkswithingroup, 3);
				}
				else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapRapidPlane)
				{
					_0097._007E_008E_0011(combo_arealinkswithingroup, 4);
				}
				else
				{
					_0097._007E_008E_0011(combo_arealinkswithingroup, 3);
				}
			}
			if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par)))))))
			{
				_0097._007E_008E_0011(combo_arealinkwithingroupramp, 0);
				if (8 == 0)
				{
					goto IL_069c;
				}
			}
			else
			{
				_0097._007E_008E_0011(combo_arealinkwithingroupramp, 1);
			}
			num = _0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapDirect;
			if (0 == 0)
			{
				if (num)
				{
					_0097._007E_008E_0011(combo_arealinkbetweengroup, 0);
				}
				else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapBlendSpline)
				{
					_0097._007E_008E_0011(combo_arealinkbetweengroup, 1);
				}
				else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapBrokenFeed)
				{
					_0097._007E_008E_0011(combo_arealinkbetweengroup, 2);
				}
				else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapBrokenFeedRap)
				{
					_0097._007E_008E_0011(combo_arealinkbetweengroup, 3);
				}
				else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapRapidPlane)
				{
					_0097._007E_008E_0011(combo_arealinkbetweengroup, 4);
				}
				else
				{
					_0097._007E_008E_0011(combo_arealinkbetweengroup, 3);
				}
				goto IL_069c;
			}
			goto IL_09af;
		}
		goto IL_0b90;
		IL_09b1:
		_0097._007E_008E_0011(combo_linkbetweenregion, 0);
		goto IL_0b1e;
		IL_0a01:
		_0097._007E_008E_0011(combo_linkbetweenregion, 1);
		goto IL_0b1e;
		IL_0aa3:
		if (flag2)
		{
			goto IL_0aa7;
		}
		if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(Par)))) == MoveHandlingAction.ActionGapRapidPlane)
		{
			_0097._007E_008E_0011(combo_linkbetweenregion, 4);
		}
		else
		{
			_0097._007E_008E_0011(combo_linkbetweenregion, 3);
		}
		goto IL_0b1e;
		IL_0a51:
		_0097._007E_008E_0011(combo_linkbetweenregion, 2);
		goto IL_0b1e;
		IL_0b90:
		_0095._007E_0096_000F(this._0003, global::_0003._007E_0018_0002(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(Par))));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0019_0002(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(Par))));
		_0095._007E_0096_000F(this._0004, global::_0003._007E_001A_0002(_009F._007E_0004_0012(_008B._007E_0008_0007(Par))));
		_0095._007E_0096_000F(this._0002, global::_0003._007E_001B_0002(_009F._007E_0004_0012(_008B._007E_0008_0007(Par))));
		UpdateControlFromType();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		return;
		IL_0aa7:
		_0097._007E_008E_0011(combo_linkbetweenregion, 3);
		goto IL_0b1e;
		IL_0b1e:
		if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(Par)))))))
		{
			_0097._007E_008E_0011(combo_linkbetweenregionrapm, 0);
		}
		else
		{
			_0097._007E_008E_0011(combo_linkbetweenregionrapm, 1);
		}
		goto IL_0b90;
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
		_0095._007E_008D_0010(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(Par)), global::_0003._007E_0083(this._0003));
		_0095._007E_008E_0010(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(Par)), global::_0003._007E_0083(this._0001));
		_0095._007E_008F_0010(_009F._007E_0004_0012(_008B._007E_0008_0007(Par)), global::_0003._007E_0083(this._0004));
		_0095._007E_0090_0010(_009F._007E_0004_0012(_008B._007E_0008_0007(Par)), global::_0003._007E_0083(this._0002));
		int num = global::_000E._007E_000E_0006(combo_firstentry);
		int num2 = 0;
		bool num3;
		if (num2 == 0)
		{
			if (num == num2)
			{
				_0094_0004._007E_008E_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(Par)), FirstEntryType.FromRapidPlane);
			}
			else if (global::_000E._007E_000E_0006(combo_firstentry) == 1)
			{
				_0094_0004._007E_008E_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(Par)), FirstEntryType.UseRapidDistance);
			}
			else if (global::_000E._007E_000E_0006(combo_firstentry) == 2)
			{
				_0094_0004._007E_008E_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(Par)), FirstEntryType.UseFeedDistance);
			}
			if (global::_000E._007E_000E_0006(combo_firstentryramp) == 0)
			{
				_0095._007E_0081_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(Par))), true);
			}
			else
			{
				_0095._007E_0081_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(Par))), false);
			}
			if (global::_000E._007E_000E_0006(combo_lastexit) == 0)
			{
				_0095_0004._007E_008F_0015(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(Par)), LastExitType.BackToRapidPlane);
				goto IL_02f2;
			}
			num3 = global::_000E._007E_000E_0006(combo_lastexit) == 1;
			goto IL_0281;
		}
		goto IL_06fc;
		IL_0a1a:
		if (global::_000E._007E_000E_0006(combo_linkbetweenregion) == 0)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapDirect);
		}
		else if (global::_000E._007E_000E_0006(combo_linkbetweenregion) == 1)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapBlendSpline);
		}
		else if (global::_000E._007E_000E_0006(combo_linkbetweenregion) == 2)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapBrokenFeed);
		}
		else if (global::_000E._007E_000E_0006(combo_linkbetweenregion) == 3)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapBrokenFeedRap);
		}
		else if (global::_000E._007E_000E_0006(combo_linkbetweenregion) == 4)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapRapidPlane);
		}
		if (global::_000E._007E_000E_0006(combo_linkbetweenregionrapm) == 0)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(Par))))), true);
		}
		else
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(Par))))), false);
		}
		return;
		IL_093a:
		bool flag;
		if (flag)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapRapidPlane);
			if (false)
			{
				goto IL_0a1a;
			}
		}
		goto IL_0973;
		IL_02f2:
		_0095._007E_0081_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(Par))), false);
		if (global::_000E._007E_000E_0006(combo_arealinkswithingroup) == 0)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapDirect);
		}
		else if (global::_000E._007E_000E_0006(combo_arealinkswithingroup) == 1)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapBlendSpline);
		}
		else
		{
			num3 = global::_000E._007E_000E_0006(combo_arealinkswithingroup) == 2;
			if (false)
			{
				goto IL_0281;
			}
			if (num3)
			{
				_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapBrokenFeed);
			}
			else
			{
				bool flag2 = global::_000E._007E_000E_0006(combo_arealinkswithingroup) == 3;
				if (false)
				{
					goto IL_093a;
				}
				if (flag2)
				{
					_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapBrokenFeedRap);
				}
				else if (global::_000E._007E_000E_0006(combo_arealinkswithingroup) == 4)
				{
					_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapRapidPlane);
				}
			}
		}
		if (global::_000E._007E_000E_0006(combo_arealinkwithingroupramp) == 0)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par))))), true);
		}
		else
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par))))), false);
		}
		if (global::_000E._007E_000E_0006(combo_arealinkbetweengroup) == 0)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapDirect);
		}
		else if (global::_000E._007E_000E_0006(combo_arealinkbetweengroup) == 1)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapBlendSpline);
		}
		else if (global::_000E._007E_000E_0006(combo_arealinkbetweengroup) == 2)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapBrokenFeed);
		}
		else if (global::_000E._007E_000E_0006(combo_arealinkbetweengroup) == 3)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapBrokenFeedRap);
		}
		else if (global::_000E._007E_000E_0006(combo_arealinkbetweengroup) == 4)
		{
			if (1 == 0)
			{
				goto IL_0a1a;
			}
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapRapidPlane);
		}
		num = global::_000E._007E_000E_0006(combo_arealinkbetweengroupramp);
		num2 = 0;
		goto IL_06fc;
		IL_06fc:
		if (num == num2)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par))))), true);
		}
		else
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(Par))))), false);
		}
		int num4;
		if (global::_000E._007E_000E_0006(combo_linkbetweenslices) == 0)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapDirect);
		}
		else if (global::_000E._007E_000E_0006(combo_linkbetweenslices) == 1)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapBlendSpline);
		}
		else
		{
			num4 = global::_000E._007E_000E_0006(combo_linkbetweenslices);
			if (false)
			{
				goto IL_0986;
			}
			if (num4 == 2)
			{
				_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapStep);
			}
			else if (global::_000E._007E_000E_0006(combo_linkbetweenslices) == 3)
			{
				_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapBrokenFeed);
			}
			else
			{
				if (global::_000E._007E_000E_0006(combo_linkbetweenslices) != 4)
				{
					flag = global::_000E._007E_000E_0006(combo_linkbetweenslices) == 5;
					goto IL_093a;
				}
				_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(Par))), MoveHandlingAction.ActionGapBrokenFeedRap);
			}
		}
		goto IL_0973;
		IL_0973:
		num4 = ((global::_000E._007E_000E_0006(combo_linkbetweenslicesramp) == 0) ? 1 : 0);
		goto IL_0986;
		IL_0986:
		if (num4 != 0)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(Par))))), true);
		}
		else
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(Par))))), false);
		}
		goto IL_0a1a;
		IL_0281:
		if (num3)
		{
			_0095_0004._007E_008F_0015(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(Par)), LastExitType.UseRapidDistance);
		}
		else if (global::_000E._007E_000E_0006(combo_lastexit) == 2)
		{
			_0095_0004._007E_008F_0015(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(Par)), LastExitType.UseFeedDistance);
		}
		goto IL_02f2;
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

	internal void _0004(object P_0, EventArgs P_1)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		F_MwTriMRetract f_MwTriMRetract = default(F_MwTriMRetract);
		if (0 == 0 && uint.MaxValue != 0)
		{
			f_MwTriMRetract = new F_MwTriMRetract();
		}
		do
		{
			f_MwTriMRetract.Par = new MachiningParams(Par);
			f_MwTriMRetract.Init();
		}
		while (false);
		_009D_0003._007E_0091_0014(f_MwTriMRetract);
		bool num = f_MwTriMRetract.Properties.Result == DialogResult.OK;
		if (7u != 0)
		{
			bool flag = num;
			num = flag;
		}
		if (num)
		{
			while (false)
			{
			}
			Par = new MachiningParams(f_MwTriMRetract.Par);
			global::_0011._007E_001C_0006(f_MwTriMRetract);
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
