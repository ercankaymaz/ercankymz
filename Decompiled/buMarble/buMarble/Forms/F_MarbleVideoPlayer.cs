using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using _0005;
using buClass;
using buControls.Controls;

namespace buMarble.Forms;

public class F_MarbleVideoPlayer : Form
{
	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public int SelectedTab = 0;

	internal IContainer _0001 = null;

	internal buGround _0001;

	public buButton btn_closecross;

	internal ImageList _0001;

	public F_MarbleVideoPlayer()
	{
		_0005._0003._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		bool flag = default(bool);
		do
		{
			int num = PropertiesForm.Height;
			while (true)
			{
				if (num <= 10)
				{
					goto IL_0125;
				}
				global::_008D._008F_0007(this, PropertiesForm.Height);
				goto IL_004f;
				IL_006e:
				num = (flag ? 1 : 0);
				if (false)
				{
					continue;
				}
				if (num != 0)
				{
					global::_008D._008E_0007(this, PropertiesForm.Width);
				}
				while (false)
				{
				}
				global::_0082._008D_0005(this, PropertiesForm.TopMost);
				global::_009C._001A_0008(this, PropertiesForm.FormPosition);
				while (0 == 0)
				{
					LoadLanguage();
					if (0 == 0)
					{
						goto end_IL_0020;
					}
				}
				goto IL_004f;
				IL_0125:
				bool num2 = PropertiesForm.Width > 10;
				if (0 == 0)
				{
					flag = num2;
				}
				goto IL_006e;
				IL_004f:
				if (4 == 0)
				{
					goto IL_006e;
				}
				goto IL_0125;
				continue;
				end_IL_0020:
				break;
			}
			MenuButtonColors(SelectedTab);
		}
		while (7 == 0);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			while (8u != 0)
			{
				if (5u != 0)
				{
					global::_008B._007E_0088_0006(this._0001, buLangTranslate.preDef.Calculate);
					if (0 == 0)
					{
						break;
					}
				}
			}
		}
		catch (Exception)
		{
			if (false)
			{
			}
		}
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
				global::_0082._007E_009C_0005(P_1, true);
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
				global::_0011._001D_0003(this);
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
				global::_0082._0086_0005(this, false);
			}
			break;
		}
	}

	public void Apply()
	{
	}

	public void MenuButtonColors(int PageIndex)
	{
		if (4 == 0)
		{
			return;
		}
		if (2u != 0)
		{
			Control.ControlCollection controlCollection = global::_0098._007E_0015_0008(this._0001);
			if (0 == 0)
			{
				controlCollection = _0099_0006._001D_0013(controlCollection);
			}
		}
		if (6u != 0)
		{
			SelectedTab = PageIndex;
		}
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		Control control = P_0 as Control;
		if (5 == 0)
		{
			goto IL_0072;
		}
		bool num = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_closecross));
		goto IL_00e1;
		IL_0097:
		bool flag;
		if (flag)
		{
			global::_0082._0086_0005(this, false);
		}
		return;
		IL_00e1:
		if (num)
		{
			PropertiesForm.Result = DialogResult.Cancel;
			bool flag2 = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
			if (false || 6 == 0 || flag2)
			{
				goto IL_0072;
			}
			goto IL_0085;
		}
		return;
		IL_0085:
		num = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
		if (8 == 0)
		{
			goto IL_00e1;
		}
		flag = num;
		goto IL_0097;
		IL_0072:
		global::_0011._001D_0003(this);
		if (8u != 0)
		{
			if (0 == 0)
			{
				goto IL_0085;
			}
			goto IL_0097;
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
			global::_0011._007E_001A_0002(this._0001);
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
		global::_0082._009D_0005(this, disposing);
	}
}
