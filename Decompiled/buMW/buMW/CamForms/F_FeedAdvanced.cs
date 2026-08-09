using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using buClass;
using buEyeBaseVer5;

namespace buMW.CamForms;

public class F_FeedAdvanced : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public ToolBase5 Tool = null;

	public static List<string> Captions = new List<string>();

	internal IContainer _0001 = null;

	internal ImageList _0001;

	internal Label _0001;

	internal PictureBox _0001;

	public Button btn_ok;

	internal ImageList _0002;

	public Button btn_cancel;

	internal CheckBox _0001;

	internal Panel _0001;

	internal CheckBox _0002;

	internal CheckBox _0003;

	internal NumericUpDown _0001;

	internal Label _0002;

	internal CheckBox _0004;

	internal NumericUpDown _0002;

	internal CheckBox _0005;

	internal NumericUpDown _0003;

	internal CheckBox _0006;

	public F_FeedAdvanced()
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
		_0095._007E_0095_000F(this._0002, true);
		_0095._007E_0095_000F(this._0004, true);
		_0095._007E_0095_000F(this._0001, true);
		_0095._007E_0096_000F(_0006, global::_0003._007E_008A_0002(_008A_0005._007E_0094_0016(_0084._007E_009D_0006(mwCamParameter))));
		_0095._007E_0096_000F(this._0004, global::_0003._007E_0088_0002(_008A_0005._007E_0094_0016(_0084._007E_009D_0006(mwCamParameter))));
		_0095._007E_0096_000F(_0005, global::_0003._007E_0089_0002(_008A_0005._007E_0094_0016(_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0003_0005(_008A_0005._007E_0094_0016(_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0001_0005(_008A_0005._007E_0094_0016(_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0002_0005(_008A_0005._007E_0094_0016(_0084._007E_009D_0006(mwCamParameter)))));
		if (Configration.Mode == CamMode.TriangularMesh && Configration.CamTriMeshType == CamTriangularMeshType.ConstantZ)
		{
			_0095._007E_0095_000F(this._0003, false);
			_0095._007E_0095_000F(this._0002, false);
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(this._0001, false);
		}
		ControlUpdate();
		_008F_0003._007E_0082_0014(this._0001, null);
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
		do
		{
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(_0006));
			_0095._007E_0095_000F(this._0002, global::_0003._007E_008C(_0006));
			while (true)
			{
				_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(_0006));
				if (1 == 0)
				{
					continue;
				}
				_0095._007E_0095_000F(this._0002, global::_0003._007E_0083(_0005));
				_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0004));
				if (Configration.Mode == CamMode.TriangularMesh)
				{
					bool flag;
					if (7u != 0)
					{
						flag = Configration.CamTriMeshType == CamTriangularMeshType.ParallelCuts;
					}
					if (flag)
					{
						_0095._007E_0095_000F(this._0001, false);
						return;
					}
				}
				else
				{
					bool flag2 = Configration.Mode == CamMode.WireFrame;
					if (5u != 0)
					{
						if (!flag2)
						{
							return;
						}
						if (Configration.CamWireframeType == CamWireFrameType.Pocket)
						{
							_0095._007E_0095_000F(this._0002, false);
							if (0 == 0)
							{
								break;
							}
							continue;
						}
						bool flag3 = Configration.CamWireframeType == CamWireFrameType.Contour;
						if (0 == 0)
						{
							if (flag3)
							{
								_0095._007E_0095_000F(this._0001, false);
							}
							return;
						}
						goto IL_013f;
					}
				}
				if (Configration.CamTriMeshType == CamTriangularMeshType.Rough)
				{
					_0095._007E_0095_000F(this._0001, true);
					if (false)
					{
					}
					return;
				}
				if (Configration.CamTriMeshType != CamTriangularMeshType.ConstantZ)
				{
					return;
				}
				goto IL_013f;
				IL_013f:
				_0095._007E_0095_000F(this._0001, true);
				_0095._007E_0095_000F(this._0002, false);
				_0095._007E_0095_000F(this._0003, false);
				_0095._007E_0095_000F(this._0001, false);
				return;
			}
			_0095._007E_0095_000F(this._0003, false);
		}
		while (4 == 0);
	}

	public void Apply()
	{
		do
		{
			_0095._007E_0014_0011(_008A_0005._007E_0094_0016(_0084._007E_009D_0006(mwCamParameter)), global::_0003._007E_0083(_0006));
			_0095._007E_0012_0011(_008A_0005._007E_0094_0016(_0084._007E_009D_0006(mwCamParameter)), global::_0003._007E_0083(this._0004));
			_0095._007E_0013_0011(_008A_0005._007E_0094_0016(_0084._007E_009D_0006(mwCamParameter)), global::_0003._007E_0083(_0005));
			do
			{
				_0094._007E_0017_000E(_008A_0005._007E_0094_0016(_0084._007E_009D_0006(mwCamParameter)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
				_0094._007E_0015_000E(_008A_0005._007E_0094_0016(_0084._007E_009D_0006(mwCamParameter)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
				while (false)
				{
				}
				_0094._007E_0016_000E(_008A_0005._007E_0094_0016(_0084._007E_009D_0006(mwCamParameter)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
			}
			while (false);
		}
		while (8 == 0);
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		bool flag;
		do
		{
			if (true)
			{
				Control control = new Control();
				Control obj = (Control)P_0;
				if (4u != 0)
				{
					control = obj;
				}
				flag = !PropertiesForm.Inited;
			}
		}
		while (7 == 0);
		if (flag)
		{
			if (0 == 0 && false)
			{
			}
		}
		else
		{
			PropertiesForm.Inited = true;
		}
	}

	internal void _0001(object P_0, KeyEventArgs P_1)
	{
		Control control;
		do
		{
			control = new Control();
		}
		while (4 == 0);
		control = (Control)P_0;
		int num = (((_009C_0005._007E_0007_0017(P_1) == Keys.Return) | (_009C_0005._007E_0007_0017(P_1) == Keys.Tab)) ? 1 : 0);
		while (true)
		{
			bool flag = (byte)num != 0;
			bool num2;
			if (7u != 0)
			{
				num2 = flag;
				goto IL_004d;
			}
			goto IL_0050;
			IL_004d:
			if (!num2)
			{
				break;
			}
			goto IL_0050;
			IL_0050:
			num = 0;
			if (num != 0)
			{
				continue;
			}
			int num3 = num;
			num2 = _009D_0005._0008_0017(global::_0005._007E_0013_0003(_0003_0003._007E_001E_0013(control)), ref num3);
			if (8u != 0)
			{
				_009E_0005._000E_0017(_0013_0005._001A_0016(this), num3, global::_0003._007E_009B_0002(P_1));
				break;
			}
			goto IL_004d;
		}
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		if (3u != 0)
		{
		}
		Control control = new Control();
		control = (Control)P_0;
		bool num = !PropertiesForm.Inited;
		while (true)
		{
			bool flag = num;
			while (true)
			{
				num = flag;
				if (false)
				{
					break;
				}
				if (!num)
				{
					PropertiesForm.Inited = false;
					if (0 == 0)
					{
						Apply();
						ControlUpdate();
						PropertiesForm.Inited = true;
						_0004(P_0, null);
					}
				}
				if (2 == 0)
				{
					continue;
				}
				return;
			}
		}
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
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
