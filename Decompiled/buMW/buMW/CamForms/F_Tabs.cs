using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;
using buEyeBaseVer5;

namespace buMW.CamForms;

public class F_Tabs : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public ToolBase5 Tool = null;

	public static List<string> Captions;

	internal IContainer _0001 = null;

	internal ImageList _0001;

	internal Label _0001;

	internal PictureBox _0001;

	public Button btn_ok;

	internal ImageList _0002;

	public Button btn_cancel;

	internal CheckBox _0001;

	internal Label _0002;

	internal Button _0001;

	internal Button _0002;

	internal ListBox _0001;

	internal NumericUpDown _0001;

	internal Label _0003;

	internal NumericUpDown _0002;

	internal Label _0004;

	internal NumericUpDown _0003;

	internal Label _0005;

	internal NumericUpDown _0004;

	internal Label _0006;

	internal Panel _0001;

	internal Button _0003;

	internal Button _0004;

	internal Label _0007;

	internal NumericUpDown _0005;

	internal Label _0008;

	internal NumericUpDown _0006;

	internal Label _000E;

	internal NumericUpDown _0007;

	[NonSerialized]
	internal static GetString _0003;

	public F_Tabs()
	{
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		do
		{
			PropertiesForm.Inited = false;
			if (PropertiesForm.Height > 10)
			{
				_0097._008C_0011(this, PropertiesForm.Height);
			}
			while (true)
			{
				if (PropertiesForm.Width > 10)
				{
					_0097._008D_0011(this, PropertiesForm.Width);
				}
				_0095._0092_000F(this, PropertiesForm.TopMost);
				_0086_0003._0018_0014(this, PropertiesForm.FormPosition);
				if (Configration.Mode != CamMode.WireFrame)
				{
					break;
				}
				_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0018_0005(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
				_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0019_0005(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
				_0088_0003._007E_001A_0014(_0002, _0087_0003._0019_0014(global::_0007._007E_001A_0005(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
				_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_001B_0005(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
				while (0 == 0)
				{
					global::_0011._007E_001D_0006(_0006_0004._007E_009A_0014(this._0001));
					int num = 0;
					while (true)
					{
						bool flag = num <= _0087._007E_0001_0007(mwCamParameter).Count() - 1;
						int num2 = (flag ? 1 : 0);
						while (num2 != 0)
						{
							num2 = _000E_0004._007E_009D_0014(_0006_0004._007E_009A_0014(this._0001), _0081._009A_0006(new string[5]
							{
								_0087._007E_0001_0007(mwCamParameter).ElementAt(num).X.ToString(),
								_0003(107354157),
								_0087._007E_0001_0007(mwCamParameter).ElementAt(num).Y.ToString(),
								_0003(107354157),
								_0087._007E_0001_0007(mwCamParameter).ElementAt(num).Z.ToString()
							}));
							if (2 == 0)
							{
								continue;
							}
							goto IL_02dc;
						}
						break;
						IL_02dc:
						if (false)
						{
							goto IL_01ec;
						}
						num++;
					}
					goto end_IL_0375;
					IL_01ec:;
				}
				continue;
				end_IL_0375:
				break;
			}
			ControlUpdate();
			_008F_0003._007E_0082_0014(this._0001, null);
			PropertiesForm.Result = DialogResult.None;
			PropertiesForm.Inited = true;
		}
		while (false);
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_ok)))
		{
			Apply();
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				global::_0011._001C_0006(this);
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				_0095._0094_000F(this, false);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_cancel)))
		{
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				global::_0011._001C_0006(this);
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				_0095._0094_000F(this, false);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			_000E_0004._007E_009D_0014(_0006_0004._007E_009A_0014(this._0001), _0081._009A_0006(new string[5]
			{
				global::_0008._007E_0099_0005(_0007).ToString(),
				_0003(107354152),
				global::_0008._007E_0099_0005(_0006).ToString(),
				_0003(107354152),
				global::_0008._007E_0099_0005(_0005).ToString()
			}));
			_0095._007E_0094_000F(this._0001, false);
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0004)))
		{
			_0095._007E_0094_000F(this._0001, false);
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			_0095._007E_0094_000F(this._0001, true);
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			bool num = global::_000E._007E_000E_0006(this._0001) >= 0;
			int num2 = global::_000E._007E_000E_0006(this._0001);
			if (0 == 0)
			{
				num2 = ((num2 > global::_000E._007E_0011_0006(_0006_0004._007E_009A_0014(this._0001)) - 1) ? 1 : 0);
			}
			if (num && num2 == 0)
			{
				_0097._007E_0090_0011(_0006_0004._007E_009A_0014(this._0001), global::_000E._007E_000E_0006(this._0001));
			}
		}
	}

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
		bool num = Configration.Mode == CamMode.WireFrame;
		bool flag;
		if (8u != 0)
		{
			flag = num;
		}
		int num2 = (flag ? 1 : 0);
		while (num2 != 0)
		{
			_0094._007E_0087_000E(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
			_0094._007E_0088_000E(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
			_0094._007E_0089_000E(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0002)));
			_0094._007E_008A_000E(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
			List<Point3d<double>> list = _0087._007E_0001_0007(mwCamParameter).ToList();
			list.Clear();
			int num3 = 0;
			while (true)
			{
				bool flag2 = num3 <= global::_000E._007E_0011_0006(_0006_0004._007E_009A_0014(this._0001)) - 1;
				int num4;
				while (true)
				{
					if (flag2)
					{
						while (true)
						{
							IL_017a:
							string[] array = _0005_0006._007E_0083_001C(global::_0005._007E_0013_0003(_0010_0004._007E_0001_0015(_0006_0004._007E_009A_0014(this._0001), num3)), new char[1] { ';' });
							bool flag3;
							do
							{
								flag3 = array != null;
							}
							while (5 == 0);
							num4 = (flag3 ? 1 : 0);
							while (true)
							{
								if (num4 != 0)
								{
									bool flag4 = array.Length == 3;
									if (false)
									{
										break;
									}
									if (flag4 && 0 == 0)
									{
										double num5 = 0.0;
										double num6 = 0.0;
										double z = 0.0;
										_0006_0006._0084_001C(array[0], ref num5);
										_0006_0006._0084_001C(array[1], ref num6);
										_0006_0006._0084_001C(array[2], ref z);
										list.Add(new Point3d<double>(num5, num6, z));
									}
									if (false)
									{
										goto IL_017a;
									}
								}
								num4 = num3;
								if (4u != 0)
								{
									goto end_IL_027c;
								}
							}
							break;
						}
						continue;
					}
					_0088._007E_0003_0007(mwCamParameter, list);
					return;
					continue;
					end_IL_027c:
					break;
				}
				num2 = num4 + 1;
				if (8 == 0)
				{
					break;
				}
				num3 = num2;
			}
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

	static F_Tabs()
	{
		Strings.CreateGetStringDelegate(typeof(F_Tabs));
		Captions = new List<string>();
	}
}
