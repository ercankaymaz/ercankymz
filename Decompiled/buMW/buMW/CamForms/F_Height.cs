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

public class F_Height : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public ToolBase5 Tool = null;

	public static List<string> Captions = new List<string>();

	internal IContainer _0001 = null;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Label _0001;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	internal Panel _0001;

	internal Label _0002;

	internal NumericUpDown _0001;

	internal Label _0003;

	internal NumericUpDown _0002;

	internal Label _0004;

	public Button btn_ok;

	internal ImageList _0002;

	internal Panel _0002;

	internal Panel _0003;

	internal RadioButton _0003;

	internal RadioButton _0004;

	internal RadioButton _0005;

	internal CheckBox _0001;

	public F_Height()
	{
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			_0097._008C_0011(this, PropertiesForm.Height);
		}
		if (PropertiesForm.Width > 10)
		{
			_0097._008D_0011(this, PropertiesForm.Width);
		}
		_0095._0092_000F(this, PropertiesForm.TopMost);
		_0086_0003._0018_0014(this, PropertiesForm.FormPosition);
		_0095._007E_0095_000F(this._0003, true);
		_0095._007E_0095_000F(this._0004, true);
		if (Configration.Mode == CamMode.TriangularMesh)
		{
			if (Configration.CamTriMeshType == CamTriangularMeshType.ConstantZ)
			{
				_008C_0003._007E_007F_0014(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf);
				_0095._007E_0095_000F(this._0003, false);
				_0095._007E_0095_000F(this._0004, false);
			}
			_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0084_0003(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0086_0003(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			if (_0089_0003._007E_001D_0014(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf)
			{
				_0095._007E_0093_000F(_0005, true);
			}
			else if (_0089_0003._007E_001D_0014(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromStock)
			{
				_0095._007E_0093_000F(this._0004, true);
			}
			else
			{
				_0095._007E_0093_000F(this._0003, true);
			}
			if (_0005_0002._007E_0012_0012(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic)
			{
				_0095._007E_0093_000F(this._0002, true);
			}
			else
			{
				_0095._007E_0093_000F(this._0001, true);
			}
		}
		else
		{
			_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0084_0003(_0099._007E_009C_0011(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0086_0003(_0099._007E_009C_0011(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			if (_0089_0003._007E_001D_0014(_0099._007E_009C_0011(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf)
			{
				_0095._007E_0093_000F(_0005, true);
			}
			else if (_0089_0003._007E_001D_0014(_0099._007E_009C_0011(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromStock)
			{
				_0095._007E_0093_000F(this._0004, true);
			}
			else
			{
				_0095._007E_0093_000F(this._0003, true);
			}
			if (_0005_0002._007E_0012_0012(_0099._007E_009C_0011(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic)
			{
				_0095._007E_0093_000F(this._0002, true);
			}
			else
			{
				_0095._007E_0093_000F(this._0001, true);
			}
		}
		global::_0011._007E_0086_0006(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		global::_0005._0002._0001(this);
		ControlUpdate();
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
		bool num = global::_0003._007E_001C(this._0002);
		if (0 == 0)
		{
			bool flag = num;
			if (false)
			{
				goto IL_0047;
			}
			num = flag;
		}
		if (num)
		{
			_0095._007E_0095_000F(this._0003, true);
			_0095._007E_0095_000F(this._0002, false);
			goto IL_0047;
		}
		_0095._007E_0095_000F(this._0003, false);
		goto IL_0064;
		IL_0064:
		if (6u != 0)
		{
			_0095._007E_0095_000F(this._0002, true);
		}
		return;
		IL_0047:
		if (false || 0 == 0)
		{
			return;
		}
		goto IL_0064;
	}

	public void Apply()
	{
		if (Configration.Mode == CamMode.TriangularMesh)
		{
			_0094._007E_0081_0007(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
			_0094._007E_0082_0007(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
			if (global::_0003._007E_001C(this._0002))
			{
				_009B._007E_009F_0011(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic);
			}
			else
			{
				_009B._007E_009F_0011(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined);
			}
			if (global::_0003._007E_001C(_0005))
			{
				_008C_0003._007E_007F_0014(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf);
			}
			else if (global::_0003._007E_001C(this._0004))
			{
				_008C_0003._007E_007F_0014(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromStock);
			}
			else if (global::_0003._007E_001C(this._0003))
			{
				_008C_0003._007E_007F_0014(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromBoth);
			}
		}
		else
		{
			_0094._007E_0081_0007(_0099._007E_009C_0011(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
			_0094._007E_0082_0007(_0099._007E_009C_0011(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
			if (global::_0003._007E_001C(this._0002))
			{
				_009B._007E_009F_0011(_0099._007E_009C_0011(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic);
			}
			else
			{
				_009B._007E_009F_0011(_0099._007E_009C_0011(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined);
			}
			if (global::_0003._007E_001C(_0005))
			{
				_008C_0003._007E_007F_0014(_0099._007E_009C_0011(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf);
			}
			else if (global::_0003._007E_001C(this._0004))
			{
				_008C_0003._007E_007F_0014(_0099._007E_009C_0011(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromStock);
			}
			else if (global::_0003._007E_001C(this._0003))
			{
				_008C_0003._007E_007F_0014(_0099._007E_009C_0011(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromBoth);
			}
		}
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		bool num = PropertiesForm.Inited;
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
				PropertiesForm.Inited = false;
				if (6u != 0)
				{
					Apply();
					goto IL_0053;
				}
			}
			goto IL_0066;
			IL_0053:
			ControlUpdate();
			goto IL_005a;
			IL_005a:
			PropertiesForm.Inited = true;
			goto IL_0066;
			IL_0066:
			if (true)
			{
				break;
			}
			goto IL_0053;
		}
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		bool num = PropertiesForm.Inited;
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
				PropertiesForm.Inited = false;
				if (6u != 0)
				{
					Apply();
					goto IL_0053;
				}
			}
			goto IL_0066;
			IL_0053:
			ControlUpdate();
			goto IL_005a;
			IL_005a:
			PropertiesForm.Inited = true;
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
		Control control = new Control();
		control = (Control)P_0;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0005)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0008_001B());
			if (global::_0003._007E_0083(this._0001))
			{
				F_GifView f_GifView = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView);
				_0086_0003._007E_0018_0014(f_GifView, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			if (global::_0003._007E_0083(this._0001))
			{
				F_GifView f_GifView2 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView2);
				_0086_0003._007E_0018_0014(f_GifView2, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView2);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			if (global::_0003._007E_0083(this._0001))
			{
				F_GifView f_GifView3 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView3);
				_0086_0003._007E_0018_0014(f_GifView3, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView3);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._000E_001B());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._000F_001B());
		}
		_0095._007E_0096_000F(this._0001, false);
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
