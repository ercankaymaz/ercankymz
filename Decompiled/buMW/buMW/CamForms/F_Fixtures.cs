using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;
using buControls.Forms.WinControlForms.Views;
using buEyeBaseVer5;

namespace buMW.CamForms;

public class F_Fixtures : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public ToolBase5 Tool = null;

	public static List<string> Captions = new List<string>();

	internal IContainer _0001 = null;

	internal Label _0001;

	internal Panel _0001;

	internal RadioButton _0001;

	internal Panel _0002;

	internal RadioButton _0002;

	internal ImageList _0001;

	internal Label _0002;

	internal PictureBox _0001;

	public Button btn_ok;

	internal ImageList _0002;

	public Button btn_cancel;

	internal CheckBox _0001;

	internal NumericUpDown _0001;

	internal Label _0003;

	internal NumericUpDown _0002;

	internal Label _0004;

	public F_Fixtures()
	{
		_0005._0002._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		bool num = PropertiesForm.Height > 10;
		if (0 == 0)
		{
			bool flag = num;
			while (true)
			{
				if (flag)
				{
					_0097._008C_0011(this, PropertiesForm.Height);
				}
				if (PropertiesForm.Width <= 10)
				{
					break;
				}
				_0097._008D_0011(this, PropertiesForm.Width);
				if (false)
				{
					continue;
				}
				goto IL_008d;
			}
			goto IL_0094;
		}
		goto IL_0167;
		IL_017d:
		if (7u != 0)
		{
			_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_001F_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			goto IL_01cc;
		}
		goto IL_0313;
		IL_026a:
		_0095._007E_0093_000F(this._0002, true);
		goto IL_02cb;
		IL_0313:
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0080_0005(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		goto IL_035e;
		IL_035e:
		ControlUpdate();
		if (0 == 0)
		{
			_0005._0002._0001(this);
			_008F_0003._007E_0082_0014(this._0001, null);
			PropertiesForm.Result = DialogResult.None;
			PropertiesForm.Inited = true;
			return;
		}
		goto IL_01cc;
		IL_01cc:
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0016_0004(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		goto IL_035e;
		IL_008d:
		if (0 == 0)
		{
			goto IL_0094;
		}
		goto IL_026a;
		IL_0094:
		_0095._0092_000F(this, PropertiesForm.TopMost);
		if (8u != 0)
		{
			_0086_0003._0018_0014(this, PropertiesForm.FormPosition);
			bool num2 = Configration.Mode == CamMode.TriangularMesh;
			if (0 == 0)
			{
				bool flag2 = num2;
				num2 = flag2;
			}
			bool flag4;
			if (num2)
			{
				if (_0013_0004._007E_0004_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsFixtureCurveMode.FcmOutside)
				{
					_0095._007E_0093_000F(this._0002, true);
					goto IL_017d;
				}
				if (8u != 0)
				{
					bool flag3 = _0013_0004._007E_0004_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsFixtureCurveMode.FcmCenter;
					num = flag3;
					goto IL_0167;
				}
			}
			else
			{
				if (Configration.Mode != CamMode.WireFrame)
				{
					goto IL_035e;
				}
				flag4 = _0007_0006._007E_0086_001C(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == WireframeBasedTpCalcParamsFixtureCurveMode.FcmOutside;
			}
			if (flag4)
			{
				goto IL_026a;
			}
			if (_0007_0006._007E_0086_001C(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == WireframeBasedTpCalcParamsFixtureCurveMode.FcmCenter)
			{
				_0095._007E_0093_000F(this._0002, true);
			}
			goto IL_02cb;
		}
		goto IL_035e;
		IL_0167:
		if (num)
		{
			_0095._007E_0093_000F(this._0002, true);
		}
		goto IL_017d;
		IL_02cb:
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_007F_0005(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		goto IL_0313;
	}

	internal void _0001(object P_0, FormClosingEventArgs P_1)
	{
		while (true)
		{
			bool num = PropertiesForm.Result == DialogResult.OK;
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
				PropertiesForm.Result = DialogResult.Cancel;
				bool flag2;
				do
				{
					flag2 = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
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
			num2 = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
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
		Control control = new Control();
		control = (Control)P_0;
		if (0 == 0)
		{
			bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_ok));
			if (5 == 0)
			{
				goto IL_0098;
			}
			if (!flag)
			{
				goto IL_00a7;
			}
			Apply();
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				global::_0011._001C_0006(this);
			}
		}
		goto IL_0085;
		IL_0093:
		bool num;
		if (num != 0)
		{
			goto IL_0098;
		}
		goto IL_00a7;
		IL_0098:
		_0095._0094_000F(this, false);
		goto IL_00a7;
		IL_00a7:
		while (true)
		{
			bool flag2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_cancel));
			if (3 == 0)
			{
				break;
			}
			if (!flag2)
			{
				return;
			}
			do
			{
				PropertiesForm.Result = DialogResult.Cancel;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					if (4 == 0)
					{
						return;
					}
					global::_0011._001C_0006(this);
				}
			}
			while (5 == 0);
			if (1 == 0)
			{
				continue;
			}
			goto IL_010d;
		}
		goto IL_0085;
		IL_010d:
		num = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
		if (0 == 0)
		{
			if (num)
			{
				_0095._0094_000F(this, false);
			}
			return;
		}
		goto IL_0093;
		IL_0085:
		num = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
		goto IL_0093;
	}

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
		if (0 == 0)
		{
			if (Configration.Mode != CamMode.TriangularMesh)
			{
				if (Configration.Mode == CamMode.WireFrame)
				{
					if (global::_0003._007E_001C(this._0002))
					{
						_0008_0006._007E_0087_001C(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), WireframeBasedTpCalcParamsFixtureCurveMode.FcmOutside);
					}
					else if (global::_0003._007E_001C(this._0001))
					{
						_0008_0006._007E_0087_001C(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), WireframeBasedTpCalcParamsFixtureCurveMode.FcmCenter);
					}
					_0094._007E_008F_000E(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
					goto IL_0258;
				}
				return;
			}
			bool num = global::_0003._007E_001C(this._0002);
			bool flag = default(bool);
			if (0 == 0)
			{
				flag = num;
			}
			if (flag)
			{
				_0014_0004._007E_0005_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsFixtureCurveMode.FcmOutside);
				goto IL_00cc;
			}
		}
		if (global::_0003._007E_001C(this._0001))
		{
			_0014_0004._007E_0005_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsFixtureCurveMode.FcmCenter);
			if (false)
			{
				goto IL_0258;
			}
		}
		goto IL_00cc;
		IL_0258:
		_0094._007E_0090_000E(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		return;
		IL_00cc:
		_0094._007E_008E_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		_0094._007E_0088_0008(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		ControlUpdate();
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			goto IL_004b;
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			goto IL_0097;
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			if (0 == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001D_0017());
				if (global::_0003._007E_0083(this._0001))
				{
					F_GifView f_GifView = new F_GifView();
					if (5 == 0)
					{
						goto IL_0097;
					}
					global::_0011._007E_0084_0006(f_GifView);
					_0086_0003._007E_0018_0014(f_GifView, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView);
				}
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			goto IL_017e;
		}
		goto IL_01a4;
		IL_004b:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
		goto IL_01a4;
		IL_01a4:
		while (2 == 0)
		{
		}
		if (0 == 0)
		{
			_0095._007E_0096_000F(this._0001, false);
		}
		if (0 == 0)
		{
			return;
		}
		goto IL_017e;
		IL_0097:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
		goto IL_01a4;
		IL_017e:
		if (4u != 0)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001E_0017());
			if (7 == 0)
			{
				goto IL_004b;
			}
			goto IL_01a4;
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
