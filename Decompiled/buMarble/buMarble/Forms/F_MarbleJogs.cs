using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;

namespace buMarble.Forms;

public class F_MarbleJogs : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	internal IContainer _0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public ImageList IC32;

	public buCheckBox chk_partzero;

	public buCheckBox chk_machinezero;

	public buCheckBox chk_addsawthickness;

	public buCheckBox chk_incremental;

	public buSpin spn_apos;

	public buCheckBox chk_absolute;

	public buSpin spn_cpos;

	public buSpin spn_zpos;

	public buSpin spn_ypos;

	public buSpin spn_xpos;

	public buButton btn_xplus;

	public buButton btn_xminus;

	public buButton btn_yplus;

	public buButton btn_yminus;

	public buButton btn_aplus;

	public buButton btn_zminus;

	public buButton btn_aminus;

	public buButton btn_zplus;

	public buButton btn_cminus;

	public buButton btn_cplus;

	public buButton btn_stop;

	public buLabel lbl_Aposition;

	public buLabel lbl_Cpositions;

	public buButton btn_A46;

	public buButton btn_A90;

	public buButton btn_A0;

	public buButton btn_A45;

	public buButton btn_c270;

	public buButton btn_c90;

	public buButton btn_c0;

	public buButton btn_c180;

	public F_MarbleJogs()
	{
		_0005._0003._0001(this);
	}

	public void Init()
	{
		if (0 == 0)
		{
			PropertiesForm.Inited = false;
		}
		bool flag = PropertiesForm.Height > 10;
		if (false || flag)
		{
			goto IL_0037;
		}
		goto IL_0116;
		IL_0037:
		global::_008D._008F_0007(this, PropertiesForm.Height);
		goto IL_0116;
		IL_0116:
		bool flag2 = PropertiesForm.Width > 10;
		if ((false || flag2) && 0 == 0)
		{
			global::_008D._008E_0007(this, PropertiesForm.Width);
		}
		global::_0082._008D_0005(this, PropertiesForm.TopMost);
		while (true)
		{
			global::_009C._001A_0008(this, PropertiesForm.FormPosition);
			PropertiesForm.Result = DialogResult.None;
			if (false)
			{
				break;
			}
			PropertiesForm.Inited = true;
			_0005._0003._0001(this);
			if (0 == 0)
			{
				return;
			}
		}
		goto IL_0037;
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

	internal void _0001(object P_0, EventArgs P_1)
	{
		if (1 == 0)
		{
			return;
		}
		try
		{
			if (false)
			{
				goto IL_0065;
			}
			Control control = P_0 as Control;
			bool num = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_close));
			if (8 == 0)
			{
				goto IL_0098;
			}
			bool flag;
			if (2u != 0)
			{
				flag = num;
			}
			goto IL_00ec;
			IL_0098:
			if (num)
			{
				global::_0082._0086_0005(this, false);
			}
			if (2u != 0)
			{
				return;
			}
			goto IL_0097;
			IL_0065:
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				if (false)
				{
					goto IL_00ec;
				}
				global::_0011._001D_0003(this);
			}
			bool flag2 = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
			goto IL_0097;
			IL_0097:
			num = flag2;
			goto IL_0098;
			IL_00ec:
			if (flag)
			{
				PropertiesForm.Result = DialogResult.Cancel;
				goto IL_0065;
			}
		}
		catch (Exception)
		{
			if (false)
			{
			}
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		buSpin buSpin2 = P_0 as buSpin;
		bool num = AppBool.TouchPad;
		while (true)
		{
			bool flag = num;
			if (uint.MaxValue != 0)
			{
				num = flag;
				goto IL_0025;
			}
			goto IL_00a7;
			IL_0025:
			if (!num)
			{
				break;
			}
			F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
			F_KeyPadNumV1 f_KeyPadNumV2;
			if (7u != 0)
			{
				f_KeyPadNumV2 = f_KeyPadNumV;
			}
			goto IL_0037;
			IL_00a7:
			bool flag2;
			if (flag2 && 8u != 0)
			{
				global::_0095._007E_0008_0008(buSpin2, _0008_0005._007F_0011(f_KeyPadNumV2.Value));
				if (0 == 0)
				{
					break;
				}
				goto IL_0037;
			}
			break;
			IL_0037:
			global::_009C._007E_001A_0008(f_KeyPadNumV2, FormStartPosition.CenterParent);
			f_KeyPadNumV2.Caption = global::_0005._007E_008A(global::_0096._007E_0012_0008(buSpin2));
			if (0 == 0)
			{
				global::_008B._007E_009B_0006(f_KeyPadNumV2, global::_0007._007E_0094(buSpin2).ToString());
			}
			num = _0007_0005._001D_0011(f_KeyPadNumV2.Value);
			if (false)
			{
				continue;
			}
			if (1 == 0)
			{
				goto IL_0025;
			}
			flag2 = num;
			goto IL_00a7;
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
