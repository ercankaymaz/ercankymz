using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5;

namespace buMarble.Forms;

public class F_MarbleToolSawTypes : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public ToolBase5 Tool = new ToolBase5();

	private IContainer m__0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buLabel _0001;

	internal buLabel _0002;

	internal buLabel _0003;

	public buSpin spn_toolsocket;

	public buSpin spn_toolthickness;

	public buSpin spn_tooldia;

	internal buTextBox _0001;

	public Panel pnl_preview;

	public buSpin spn_toolspeed;

	public F_MarbleToolSawTypes()
	{
		_0005._0003._0001(this);
	}

	public void Init()
	{
		if (2 == 0)
		{
			goto IL_0072;
		}
		PropertiesForm.Inited = false;
		while (true)
		{
			bool flag = PropertiesForm.Height > 10;
			if (0 == 0)
			{
				if (false)
				{
					continue;
				}
				if (!flag)
				{
					break;
				}
			}
			global::_008D._008F_0007(this, PropertiesForm.Height);
			break;
		}
		goto IL_01c6;
		IL_0072:
		bool flag2 = default(bool);
		if (flag2)
		{
			global::_008D._008E_0007(this, PropertiesForm.Width);
		}
		global::_0082._008D_0005(this, PropertiesForm.TopMost);
		global::_009C._001A_0008(this, PropertiesForm.FormPosition);
		global::_008B._007E_0088_0006(this._0001, Tool.Data.Name);
		global::_0095._007E_0008_0008(spn_toolthickness, Tool.Geometry.Thickness);
		global::_0095._007E_0008_0008(spn_tooldia, Tool.Geometry.Diameter);
		global::_0095._007E_0008_0008(spn_toolsocket, Tool.Geometry.SocketThickness);
		global::_0095._007E_0008_0008(spn_toolspeed, Tool.CamData.SpindleSpeed);
		if (false)
		{
			goto IL_01c6;
		}
		_0005._0003._0001(this);
		clsAppMarbleVars.cmdMarble.DrawTool(Tool);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		return;
		IL_01c6:
		flag2 = PropertiesForm.Width > 10;
		goto IL_0072;
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
		Tool.Purpose = ToolPurpose.Saw;
		Tool.Data.Name = global::_0005._007E_0083(this._0001);
		Tool.CamData.SpindleSpeed = global::_0007._007E_0094(spn_toolspeed);
		Tool.Geometry.Thickness = global::_0007._007E_0094(spn_toolthickness);
		bool num;
		if (0 == 0)
		{
			Tool.Geometry.Diameter = global::_0007._007E_0094(spn_tooldia);
			Tool.Geometry.SocketThickness = global::_0007._007E_0094(spn_toolsocket);
			num = !(Tool.Geometry.Thickness <= 0.0);
			if (false)
			{
				goto IL_0141;
			}
			if (!num)
			{
				Tool.Geometry.CutLength = Tool.Geometry.Length * 0.75;
			}
		}
		bool flag = Tool.Geometry.Diameter <= 0.0;
		num = flag;
		goto IL_0141;
		IL_0141:
		if (!num)
		{
			clsAppMarbleVars.cmdMarble.DrawTool(Tool);
		}
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		try
		{
			Control control = new Control();
			control = (Control)P_0;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_ok)))
			{
				Apply();
				global::_0011._007E_0080_0003(global::_0098._007E_0015_0008(pnl_preview));
				PropertiesForm.Result = DialogResult.OK;
				if (0 == 0)
				{
					bool num = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
					do
					{
						if (num)
						{
							global::_0011._001D_0003(this);
						}
						num = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
					}
					while (-1 == 0);
					if (!num)
					{
						goto IL_00c3;
					}
				}
				global::_0082._0086_0005(this, false);
			}
			goto IL_00c3;
			IL_00c3:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_close)) | global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_cancel)))
			{
				global::_0011._007E_0080_0003(global::_0098._007E_0015_0008(pnl_preview));
				PropertiesForm.Result = DialogResult.Cancel;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					global::_0011._001D_0003(this);
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					global::_0082._0086_0005(this, false);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		while (true)
		{
			bool num = PropertiesForm.Inited;
			do
			{
				bool flag = !num;
				num = flag;
			}
			while (false);
			if (num)
			{
				if (false)
				{
					continue;
				}
				return;
			}
			break;
		}
		buSpin buSpin2 = P_0 as buSpin;
		global::_001F._007E_0002_0005(global::_0083._007E_0008_0006(buSpin2), buEyeVars.parVisual.colorDataFocus);
		while (2 == 0)
		{
		}
		global::_0011._007E_0099_0003(buSpin2);
	}

	internal void _0003(object P_0, EventArgs P_1)
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

	internal void _0001(object P_0, double P_1)
	{
		try
		{
			if (8 == 0)
			{
				goto IL_0020;
			}
			goto IL_003a;
			IL_003a:
			if (!PropertiesForm.Inited)
			{
				goto IL_001a;
			}
			goto IL_0020;
			IL_001a:
			if (3u != 0)
			{
				return;
			}
			goto IL_0020;
			IL_0020:
			if (false || 1 == 0)
			{
				goto IL_001a;
			}
			Control control = P_0 as Control;
			Apply();
			if (false)
			{
				goto IL_003a;
			}
		}
		catch (Exception)
		{
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
			int num = ((this.m__0001 != null) ? 1 : 0);
			goto IL_004b;
			IL_0025:
			global::_0011._007E_001A_0002(this.m__0001);
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
