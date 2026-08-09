using System;
using System.Collections;
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

public class F_SurfaceQuality : Form
{
	public FormProperties Properties = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public ToolBase5 Tool = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public static List<string> Captions = new List<string>();

	internal IContainer _0001 = null;

	internal Panel _0001;

	internal Label _0001;

	internal Label _0002;

	internal NumericUpDown _0001;

	internal NumericUpDown _0002;

	internal CheckBox _0001;

	internal NumericUpDown _0003;

	internal CheckBox _0002;

	internal Label _0003;

	internal RadioButton _0001;

	internal NumericUpDown _0004;

	internal RadioButton _0002;

	public Button btn_ok;

	internal ImageList _0001;

	internal Label _0004;

	public Button btn_cancel;

	internal Panel _0002;

	internal CheckBox _0003;

	internal PictureBox _0001;

	internal ComboBox _0001;

	internal Label _0005;

	internal CheckBox _0004;

	internal Label _0006;

	public F_SurfaceQuality()
	{
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		ArrayList arrayList = new ArrayList();
		if (Properties.Height > 10)
		{
			_0097._008C_0011(this, Properties.Height);
		}
		if (0 == 0 && Properties.Width > 10)
		{
			_0097._008D_0011(this, Properties.Width);
		}
		_0095._0092_000F(this, Properties.TopMost);
		_0086_0003._0018_0014(this, Properties.FormPosition);
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(this._0001));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.TriangleMeshBasedTpCalcParamsToolpathOutputType[3]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.TriangleMeshBasedTpCalcParamsToolpathOutputType[4]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(this._0001), buMWCaptions.TriangleMeshBasedTpCalcParamsToolpathOutputType[2]);
		if (_001D_0006._007E_009B_001C(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsToolpathOutputType.TotFitArcsAndPointDistribution)
		{
			_0097._007E_008E_0011(this._0001, 0);
		}
		else if (_001D_0006._007E_009B_001C(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution)
		{
			_0097._007E_008E_0011(this._0001, 1);
		}
		else
		{
			_0097._007E_008E_0011(this._0001, 2);
		}
		if (_009B_0004._007E_0095_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsArcFitPlaneType.AfPlaneAny)
		{
			_0095._007E_0093_000F(this._0002, true);
		}
		else if (_009B_0004._007E_0095_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsArcFitPlaneType.AfPlaneCoordinate)
		{
			_0095._007E_0093_000F(this._0001, true);
		}
		_0095._007E_0096_000F(this._0004, global::_0003._007E_0084_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_009A_0004(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_009D_0004(_0084._007E_009D_0006(mwCamParameter))));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0087_0002(_0084._007E_009D_0006(mwCamParameter)));
		if (Configration.Mode == CamMode.TriangularMesh)
		{
			_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_009B_0004(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_009C_0004(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0095._007E_0096_000F(this._0002, global::_0003._007E_0086_0002(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		}
		else if (Configration.Mode == CamMode.WireFrame)
		{
			_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_009B_0004(_001A_0002._007E_0083_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_009C_0004(_001A_0002._007E_0083_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0095._007E_0096_000F(this._0002, global::_0003._007E_0086_0002(_001A_0002._007E_0083_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		}
		global::_0011._007E_0086_0006(this);
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		global::_0005._0002._0001(this);
		ControlUpdate();
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
			Properties.Result = DialogResult.OK;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
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
				Properties.Result = DialogResult.Cancel;
				if (Properties.FormCloseMode == FormCloseModeType.Dispose)
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
		num = Properties.FormCloseMode == FormCloseModeType.Invisible;
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
		num = Properties.FormCloseMode == FormCloseModeType.Invisible;
		goto IL_0093;
	}

	public void ControlUpdate()
	{
		_0095._007E_0095_000F(this._0004, true);
		_0095._007E_0095_000F(this._0002, true);
		_0095._007E_0095_000F(this._0001, true);
		if (global::_000E._007E_000E_0006(this._0001) == 1)
		{
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(this._0002, false);
		}
		else if (global::_000E._007E_000E_0006(this._0001) == 2)
		{
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(this._0002, false);
			_0095._007E_0095_000F(this._0001, false);
		}
		_0095._007E_0095_000F(this._0002, global::_0003._007E_0083(this._0004) & global::_0003._007E_008C(this._0004));
		if (0 == 0)
		{
			_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0001) & global::_0003._007E_008C(this._0001));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0002) & global::_0003._007E_008C(this._0001));
		}
		_0095._007E_0095_000F(this._0002, global::_0003._007E_0083(this._0002) & global::_0003._007E_008C(this._0001));
	}

	public void Apply()
	{
		_0094._007E_000E_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
		_0095._007E_0098_0010(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0004));
		_0094._007E_0011_000E(_0084._007E_009D_0006(mwCamParameter), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		_0095._007E_009A_0010(_0084._007E_009D_0006(mwCamParameter), global::_0003._007E_0083(this._0001));
		if (Configration.Mode == CamMode.TriangularMesh)
		{
			_0094._007E_000F_000E(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
			_0094._007E_0010_000E(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
			_0095._007E_0099_0010(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), global::_0003._007E_0083(this._0002));
		}
		else
		{
			_0094._007E_000F_000E(_001A_0002._007E_0083_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
			_0094._007E_0010_000E(_001A_0002._007E_0083_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
			_0095._007E_0099_0010(_001A_0002._007E_0083_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), global::_0003._007E_0083(this._0002));
		}
		if (global::_0003._007E_001C(this._0002))
		{
			_009C_0004._007E_0096_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsArcFitPlaneType.AfPlaneAny);
		}
		else if (global::_0003._007E_001C(this._0001))
		{
			_009C_0004._007E_0096_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsArcFitPlaneType.AfPlaneCoordinate);
		}
		if (global::_000E._007E_000E_0006(this._0001) == 0)
		{
			_001E_0006._007E_009C_001C(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsToolpathOutputType.TotFitArcsAndPointDistribution);
		}
		else if (global::_000E._007E_000E_0006(this._0001) == 1)
		{
			_001E_0006._007E_009C_001C(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution);
		}
		else if (global::_000E._007E_000E_0006(this._0001) == 2)
		{
			_001E_0006._007E_009C_001C(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsToolpathOutputType.TotHighSurfaceQuality);
		}
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		ControlUpdate();
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		while (true)
		{
			control = (Control)P_0;
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				break;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
			{
				goto IL_0096;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0003_001B());
				if (global::_0003._007E_0083(this._0003))
				{
					F_GifView f_GifView = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView);
					_0086_0003._007E_0018_0014(f_GifView, FormStartPosition.CenterParent);
					if (false)
					{
						continue;
					}
					_009D_0003._007E_0091_0014(f_GifView);
					break;
				}
				break;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				break;
			}
			bool num = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001));
			goto IL_0215;
			IL_0215:
			if (num)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0004_001B());
				if (global::_0003._007E_0083(this._0003))
				{
					F_GifView f_GifView2 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView2);
					_0086_0003._007E_0018_0014(f_GifView2, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView2);
				}
				break;
			}
			F_GifView f_GifView3;
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0005_001B());
				if (global::_0003._007E_0083(this._0003))
				{
					f_GifView3 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView3);
					goto IL_02f6;
				}
				break;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0006_001B());
				break;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0007_001B());
				break;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				if (3u != 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0004_001B());
					if (global::_0003._007E_0083(this._0003))
					{
						F_GifView f_GifView4 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView4);
						_0086_0003._007E_0018_0014(f_GifView4, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView4);
					}
					break;
				}
				goto IL_0096;
			}
			if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
			{
				break;
			}
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0005_001B());
			if (8u != 0)
			{
				if (global::_0003._007E_0083(this._0003))
				{
					F_GifView f_GifView5 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView5);
					_0086_0003._007E_0018_0014(f_GifView5, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView5);
				}
				break;
			}
			goto IL_00b2;
			IL_00b2:
			bool flag = global::_0003._007E_0083(this._0003);
			if (8u != 0)
			{
				num = flag;
				if (0 == 0)
				{
					if (num)
					{
						F_GifView f_GifView6 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView6);
						_0086_0003._007E_0018_0014(f_GifView6, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView6);
					}
					break;
				}
				goto IL_0215;
			}
			goto IL_02f6;
			IL_02f6:
			_0086_0003._007E_0018_0014(f_GifView3, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView3);
			break;
			IL_0096:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0002_001B());
			goto IL_00b2;
		}
		_0095._007E_0096_000F(this._0003, false);
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		ControlUpdate();
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
