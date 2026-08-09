using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriMSilhouette : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	public bool Advanced = false;

	public bool SilhouetteTopEnable = false;

	public bool SilhouetteBottomEnable = false;

	internal IContainer _0001 = null;

	internal Panel _0001;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal RadioButton _0003;

	internal Label _0001;

	internal NumericUpDown _0001;

	internal Label _0002;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal RadioButton _0004;

	internal RadioButton _0005;

	public F_MwTriMSilhouette()
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
			if (false)
			{
				goto IL_01f2;
			}
			_0097._008C_0011(this, Properties.Height);
		}
		int advancedTriMesh = Properties.Width;
		if (4u != 0)
		{
			if (advancedTriMesh > 10)
			{
				_0097._008D_0011(this, Properties.Width);
			}
			_0095._0092_000F(this, Properties.TopMost);
			_0086_0003._0018_0014(this, Properties.FormPosition);
			if (false)
			{
				goto IL_0265;
			}
			advancedTriMesh = (buMWCalcs.AdvancedTriMesh ? 1 : 0);
		}
		if (advancedTriMesh == 0)
		{
			if (false)
			{
				goto IL_0210;
			}
			_0081_0002._007E_008C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartEnd);
		}
		goto IL_00fc;
		IL_0210:
		if (7 == 0)
		{
			goto IL_01f6;
		}
		_0095._007E_0093_000F(this._0003, true);
		goto IL_0226;
		IL_01f2:
		bool flag;
		if (flag)
		{
			goto IL_01f6;
		}
		goto IL_0210;
		IL_0226:
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0099_0004(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		goto IL_0265;
		IL_00fc:
		if (_0006_0002._007E_0013_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctTop)
		{
			_0095._007E_0093_000F(_0005, true);
		}
		else if (_0006_0002._007E_0013_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctBottom)
		{
			_0095._007E_0093_000F(_0004, true);
		}
		else
		{
			if (_0006_0002._007E_0013_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) != TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartEnd)
			{
				flag = _0006_0002._007E_0013_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctToolContact;
				goto IL_01f2;
			}
			_0095._007E_0093_000F(this._0002, true);
		}
		goto IL_0226;
		IL_0265:
		UpdateControlFromType();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		if (true)
		{
			return;
		}
		goto IL_00fc;
		IL_01f6:
		if (2u != 0)
		{
			_0095._007E_0093_000F(this._0001, true);
		}
		goto IL_0226;
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
		bool num = _008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough;
		if (0 == 0)
		{
			if (num)
			{
				goto IL_003f;
			}
			goto IL_0078;
		}
		goto IL_0158;
		IL_0158:
		if (num)
		{
			if (false)
			{
				goto IL_003f;
			}
			_0095._007E_0095_000F(_0004, false);
			if (0 == 0)
			{
				_0095._007E_0095_000F(this._0003, false);
				_0095._007E_0095_000F(this._0001, false);
				_0095._007E_0095_000F(_0005, false);
				return;
			}
			goto IL_0120;
		}
		return;
		IL_003f:
		if (uint.MaxValue != 0)
		{
			_0095._007E_0095_000F(_0004, false);
			if (2u != 0)
			{
				_0095._007E_0095_000F(_0005, false);
				goto IL_0078;
			}
			return;
		}
		goto IL_014d;
		IL_0120:
		_0095._007E_0095_000F(_0004, SilhouetteBottomEnable);
		_0095._007E_0095_000F(_0005, SilhouetteTopEnable);
		goto IL_014d;
		IL_014d:
		bool flag = !buMWCalcs.AdvancedTriMesh;
		num = flag;
		goto IL_0158;
		IL_0078:
		bool num2;
		while (true)
		{
			bool flag2 = _008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ;
			num2 = flag2;
			if (false)
			{
				break;
			}
			if (num2)
			{
				_0095._007E_0095_000F(_0004, true);
				_0095._007E_0095_000F(_0005, true);
			}
			if (0 == 0)
			{
				bool flag3 = _008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbPencil;
				num2 = flag3;
				break;
			}
		}
		if (num2)
		{
			_0095._007E_0095_000F(_0004, false);
			_0095._007E_0095_000F(_0005, false);
		}
		goto IL_0120;
	}

	public void Apply()
	{
		_0094._007E_0097_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		bool flag3;
		do
		{
			if (-1 == 0)
			{
				return;
			}
			bool flag = global::_0003._007E_001C(_0004);
			bool num = flag;
			while (true)
			{
				IL_0065:
				if (num)
				{
					_0081_0002._007E_008C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctBottom);
					return;
				}
				while (true)
				{
					bool flag2 = global::_0003._007E_001C(this._0003);
					if (8 == 0)
					{
						return;
					}
					if (!flag2)
					{
						if (false)
						{
							break;
						}
						num = global::_0003._007E_001C(this._0002);
						if (2 == 0)
						{
							goto IL_0065;
						}
						if (num)
						{
							_0081_0002._007E_008C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartEnd);
							return;
						}
						if (!global::_0003._007E_001C(this._0001))
						{
							break;
						}
						_0081_0002._007E_008C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctToolContact);
						if (0 == 0)
						{
							return;
						}
					}
					if (0 == 0)
					{
						_0081_0002._007E_008C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartSilhouette);
						return;
					}
				}
				break;
			}
			flag3 = global::_0003._007E_001C(_0005);
		}
		while (false);
		if (flag3)
		{
			_0081_0002._007E_008C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctTop);
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
