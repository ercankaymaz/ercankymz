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

public class F_RestRough : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public ToolBase5 Tool = null;

	public static List<string> Captions = new List<string>();

	internal IContainer _0001 = null;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal Label _0001;

	internal PictureBox _0001;

	internal ImageList _0002;

	internal Panel _0001;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Panel _0002;

	internal Label _0002;

	internal Panel _0003;

	internal Label _0003;

	internal CheckBox _0001;

	internal NumericUpDown _0001;

	internal NumericUpDown _0002;

	internal Label _0004;

	internal NumericUpDown _0003;

	internal Label _0005;

	internal Label _0006;

	internal NumericUpDown _0004;

	internal Label _0007;

	internal NumericUpDown _0005;

	internal Label _0008;

	internal NumericUpDown _0006;

	internal Label _000E;

	internal Label _000F;

	public F_RestRough()
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
		if (0 == 0)
		{
			if (PropertiesForm.Width > 10)
			{
				_0097._008D_0011(this, PropertiesForm.Width);
			}
			_0095._0092_000F(this, PropertiesForm.TopMost);
			_0086_0003._0018_0014(this, PropertiesForm.FormPosition);
			if (Configration.Mode == CamMode.TriangularMesh)
			{
				if (false)
				{
					goto IL_06e2;
				}
				if (7 == 0)
				{
					goto IL_0570;
				}
				_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0091_0004(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
				_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_008C_0004(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
				_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0090_0004(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
				_0088_0003._007E_001A_0014(_0006, _0087_0003._0019_0014(global::_0007._007E_008D_0004(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
				_0088_0003._007E_001A_0014(_0004, _0087_0003._0019_0014(global::_0007._007E_008F_0004(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
				_0088_0003._007E_001A_0014(_0005, _0087_0003._0019_0014(global::_0007._007E_008E_0004(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
				if (_0098_0004._007E_0092_0015(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaRoughingParamsRoughingOffsetType.RotGlobal)
				{
					_0095._007E_0093_000F(this._0002, true);
				}
				else if (_0098_0004._007E_0092_0015(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaRoughingParamsRoughingOffsetType.RotRadialAndAxial)
				{
					_0095._007E_0093_000F(this._0001, true);
				}
			}
			else if (Configration.Mode == CamMode.WireFrame)
			{
				_0095._007E_0095_000F(this._0001, false);
				if (_0098_0004._007E_0092_0015(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) != MachiningAreaRoughingParamsRoughingOffsetType.RotGlobal)
				{
					_0097_0004._007E_0091_0015(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaRoughingParamsRoughingOffsetType.RotGlobal);
				}
				_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0091_0004(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
				_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_008C_0004(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
				_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0090_0004(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
				_0088_0003._007E_001A_0014(_0006, _0087_0003._0019_0014(global::_0007._007E_008D_0004(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
				goto IL_0570;
			}
		}
		goto IL_06c3;
		IL_0570:
		_0088_0003._007E_001A_0014(_0004, _0087_0003._0019_0014(global::_0007._007E_008F_0004(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
		_0088_0003._007E_001A_0014(_0005, _0087_0003._0019_0014(global::_0007._007E_008E_0004(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
		if (_0098_0004._007E_0092_0015(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaRoughingParamsRoughingOffsetType.RotGlobal)
		{
			_0095._007E_0093_000F(this._0002, true);
		}
		else if (_0098_0004._007E_0092_0015(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaRoughingParamsRoughingOffsetType.RotRadialAndAxial)
		{
			_0095._007E_0093_000F(this._0001, true);
		}
		goto IL_06c3;
		IL_06c3:
		ControlUpdate();
		global::_0005._0002._0001(this);
		_008F_0003._007E_0082_0014(this._0001, null);
		goto IL_06e2;
		IL_06e2:
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
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
		if (false)
		{
			return;
		}
		do
		{
			_0095._007E_0095_000F(_0005, false);
			while (true)
			{
				_0095._007E_0095_000F(_000E, false);
				do
				{
					_0095._007E_0095_000F(_0004, false);
				}
				while (-1 == 0);
				_0095._007E_0095_000F(_0008, false);
				while (true)
				{
					_0095._007E_0095_000F(_0006, false);
					_0095._007E_0095_000F(_000F, false);
					if (8 == 0)
					{
						break;
					}
					if (!global::_0003._007E_001C(this._0002))
					{
						_0095._007E_0095_000F(_0005, true);
						_0095._007E_0095_000F(_000E, true);
						_0095._007E_0095_000F(_0004, true);
						_0095._007E_0095_000F(_0008, true);
						if (0 == 0)
						{
							return;
						}
						continue;
					}
					goto IL_00a1;
				}
				break;
				IL_00a1:
				if (0 == 0)
				{
					_0095._007E_0095_000F(_0006, true);
					_0095._007E_0095_000F(_000F, true);
					break;
				}
			}
		}
		while (8 == 0);
	}

	public void Apply()
	{
		if (Configration.Mode != CamMode.TriangularMesh)
		{
			if (Configration.Mode != CamMode.WireFrame)
			{
				return;
			}
			_0094._007E_0002_000E(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
			_0094._007E_009E_0008(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
			if (uint.MaxValue != 0)
			{
				_0094._007E_0001_000E(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
				_0094._007E_009C_0008(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0006)));
				_0094._007E_009F_0008(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0004)));
				do
				{
					_0094._007E_009D_0008(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0005)));
					_0097_0004._007E_0091_0015(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaRoughingParamsRoughingOffsetType.RotGlobal);
				}
				while (false);
				if (false)
				{
				}
				return;
			}
		}
		_0094._007E_0002_000E(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
		_0094._007E_009E_0008(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		_0094._007E_0001_000E(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		_0094._007E_009C_0008(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0006)));
		_0094._007E_009F_0008(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0004)));
		_0094._007E_009D_0008(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0005)));
		if (global::_0003._007E_001C(this._0002))
		{
			_0097_0004._007E_0091_0015(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaRoughingParamsRoughingOffsetType.RotGlobal);
		}
		else if (global::_0003._007E_001C(this._0001))
		{
			_0097_0004._007E_0091_0015(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaRoughingParamsRoughingOffsetType.RotRadialAndAxial);
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
		bool num;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			if (1 == 0)
			{
				goto IL_0159;
			}
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0017());
		}
		else
		{
			if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003));
				num = flag;
				goto IL_012c;
			}
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0017());
			if (global::_0003._007E_0083(this._0001))
			{
				F_GifView f_GifView = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView);
				_0086_0003._007E_0018_0014(f_GifView, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView);
			}
		}
		goto IL_02e1;
		IL_0159:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
		}
		else
		{
			if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0006)))
			{
				bool num2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0005));
				if (8u != 0)
				{
					bool flag2 = num2;
					num = flag2;
					if (false)
					{
						goto IL_012c;
					}
					if (num)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0096_0017());
						goto IL_02e1;
					}
					num2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0004));
				}
				bool flag3 = num2;
				num = flag3;
				goto IL_02c2;
			}
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0095_0017());
			if (false)
			{
			}
		}
		goto IL_02e1;
		IL_02e1:
		_0095._007E_0096_000F(this._0001, false);
		return;
		IL_012c:
		if (7u != 0)
		{
			if (num)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0017());
				if (3u != 0)
				{
					goto IL_02e1;
				}
			}
			goto IL_0159;
		}
		goto IL_02c2;
		IL_02c2:
		if (num)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0097_0017());
		}
		goto IL_02e1;
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
