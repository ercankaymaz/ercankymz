using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5;

namespace buMarble.Forms;

public class F_MarbleToolTypes : Form
{
	public static List<string> Captions;

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

	public buCheckBox chk_slot;

	public buCheckBox chk_grinding;

	internal buSeparator _0001;

	internal buLabel _0004;

	public buCheckBox chk_cornerfull;

	public buCheckBox chk_cornercorner;

	public buCheckBox chk_cornernone;

	public buSpin spn_tooloutsidedia;

	public buCheckBox chk_barrel;

	public buCheckBox chk_dove;

	public buCheckBox chk_lollipop;

	public buCheckBox chk_chamfer;

	public buCheckBox chk_taper;

	public buCheckBox chk_boolnose;

	public buCheckBox chk_sphare;

	public buCheckBox chk_flat;

	public buSpin spn_tooltaperangle;

	public buSpin spn_toollowerradius;

	public buSpin spn_toolcuttinglen;

	public buSpin spn_toollength;

	public buSpin spn_tooldia;

	internal Panel _0001;

	internal buTextBox _0001;

	public Panel pnl_preview;

	public buSpin spn_toolspeed;

	[NonSerialized]
	internal static GetString _008F;

	public F_MarbleToolTypes()
	{
		global::_0005._0003._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		int num = PropertiesForm.Height;
		while (true)
		{
			if (num > 10)
			{
				global::_008D._008F_0007(this, PropertiesForm.Height);
				if (false)
				{
					goto IL_011b;
				}
			}
			if (PropertiesForm.Width > 10)
			{
				global::_008D._008E_0007(this, PropertiesForm.Width);
			}
			global::_0082._008D_0005(this, PropertiesForm.TopMost);
			global::_009C._001A_0008(this, PropertiesForm.FormPosition);
			global::_008B._007E_0088_0006(this._0001, Tool.Data.Name);
			global::_0095._007E_0008_0008(spn_toollength, Tool.Geometry.Length);
			global::_0095._007E_0008_0008(spn_tooldia, Tool.Geometry.Diameter);
			goto IL_011b;
			IL_011b:
			global::_0095._007E_0008_0008(spn_toolcuttinglen, Tool.Geometry.CutLength);
			global::_0095._007E_0008_0008(spn_toollowerradius, Tool.Geometry.LowerRadius);
			global::_0095._007E_0008_0008(spn_tooloutsidedia, Tool.Geometry.OutsideDiameter);
			global::_0095._007E_0008_0008(spn_tooltaperangle, Tool.Geometry.TaperAngle);
			global::_0095._007E_0008_0008(spn_toolspeed, Tool.CamData.SpindleSpeed);
			global::_0082._007E_0089_0005(chk_flat, false);
			global::_0082._007E_0089_0005(chk_sphare, false);
			while (true)
			{
				global::_0082._007E_0089_0005(chk_boolnose, false);
				global::_0082._007E_0089_0005(chk_taper, false);
				while (true)
				{
					global::_0082._007E_0089_0005(chk_chamfer, false);
					while (true)
					{
						global::_0082._007E_0089_0005(chk_grinding, false);
						global::_0082._007E_0089_0005(chk_barrel, false);
						global::_0082._007E_0089_0005(chk_lollipop, false);
						global::_0082._007E_0089_0005(chk_slot, false);
						if (false)
						{
							break;
						}
						global::_0082._007E_0089_0005(chk_dove, false);
						bool flag3;
						if (8u != 0)
						{
							if (3 == 0)
							{
								goto end_IL_0209;
							}
							bool flag = Tool.Geometry.GeometryType == ToolType.Flat;
							if (0 == 0)
							{
								if (flag)
								{
									global::_0082._007E_0089_0005(chk_flat, true);
								}
								else if (Tool.Geometry.GeometryType == ToolType.Sphere)
								{
									global::_0082._007E_0089_0005(chk_sphare, true);
								}
								else if (Tool.Geometry.GeometryType == ToolType.Bullnose)
								{
									global::_0082._007E_0089_0005(chk_boolnose, true);
								}
								else if (Tool.Geometry.GeometryType == ToolType.Taper)
								{
									if (false)
									{
										continue;
									}
									global::_0082._007E_0089_0005(chk_taper, true);
								}
								else if (Tool.Geometry.GeometryType == ToolType.Dove)
								{
									global::_0082._007E_0089_0005(chk_dove, true);
								}
								else if (Tool.Geometry.GeometryType == ToolType.Chamfer)
								{
									global::_0082._007E_0089_0005(chk_chamfer, true);
								}
								else if (Tool.Geometry.GeometryType == ToolType.Lollipop)
								{
									global::_0082._007E_0089_0005(chk_lollipop, true);
								}
								else
								{
									bool flag2 = Tool.Geometry.GeometryType == ToolType.Barrel;
									num = (flag2 ? 1 : 0);
									if (false)
									{
										goto end_IL_01e5;
									}
									if (num == 0)
									{
										flag3 = Tool.Geometry.GeometryType == ToolType.Slot;
										goto IL_0432;
									}
									global::_0082._007E_0089_0005(chk_barrel, true);
								}
							}
						}
						goto IL_047a;
						IL_0432:
						if (flag3)
						{
							global::_0082._007E_0089_0005(chk_slot, true);
						}
						else if (Tool.Geometry.GeometryType == ToolType.Grinding)
						{
							global::_0082._007E_0089_0005(chk_grinding, true);
						}
						goto IL_047a;
						IL_047a:
						global::_0082._007E_0089_0005(chk_cornercorner, false);
						global::_0082._007E_0089_0005(chk_cornerfull, false);
						global::_0082._007E_0089_0005(chk_cornernone, false);
						if (Tool.Geometry.CornerRadiusType == ToolCornerRadiusType.None)
						{
							global::_0082._007E_0089_0005(chk_cornernone, true);
						}
						if (Tool.Geometry.CornerRadiusType == ToolCornerRadiusType.Full)
						{
							global::_0082._007E_0089_0005(chk_cornerfull, true);
						}
						if (Tool.Geometry.CornerRadiusType == ToolCornerRadiusType.Corner)
						{
							if (false)
							{
								goto IL_0432;
							}
							global::_0082._007E_0089_0005(chk_cornercorner, true);
						}
						global::_0005._0003._0001(this);
						ControlUpdate();
						clsAppMarbleVars.cmdMarble.DrawTool(Tool);
						PropertiesForm.Result = DialogResult.None;
						PropertiesForm.Inited = true;
						return;
					}
					continue;
					end_IL_0209:
					break;
				}
				continue;
				end_IL_01e5:
				break;
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

	public void ControlUpdate()
	{
		do
		{
			global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_tooldia), global::_0014._009F_0003(buLangTranslate.preDef.Tool, _008F(107398222), buLangTranslate.preDef.Diameter));
			global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_toollength), global::_0014._009F_0003(buLangTranslate.preDef.Tool, _008F(107398222), buLangTranslate.preDef.Length));
		}
		while (false);
		global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_tooloutsidedia), global::_0013_0002._0090_0008(new string[5]
		{
			buLangTranslate.preDef.Tool,
			_008F(107398222),
			buLangTranslate.preDef.Outside,
			_008F(107398222),
			buLangTranslate.preDef.Diameter
		}));
		global::_0082._007E_0086_0005(spn_toolcuttinglen, true);
		bool flag2;
		if (0 == 0)
		{
			global::_0082._007E_0086_0005(spn_toollowerradius, false);
			global::_0082._007E_0086_0005(spn_tooloutsidedia, false);
			global::_0082._007E_0086_0005(spn_tooltaperangle, false);
			global::_0082._007E_0086_0005(this._0001, false);
			global::_0082._007E_0086_0005(chk_cornerfull, true);
			if (Tool.Geometry.GeometryType == ToolType.Bullnose)
			{
				global::_0082._007E_0086_0005(spn_toollowerradius, true);
				if (false || 0 == 0)
				{
					return;
				}
			}
			else if (Tool.Geometry.GeometryType == ToolType.Slot)
			{
				global::_0082._007E_0086_0005(spn_toollowerradius, true);
				global::_0082._007E_0086_0005(this._0001, true);
				return;
			}
			if ((Tool.Geometry.GeometryType == ToolType.Taper) | (Tool.Geometry.GeometryType == ToolType.Dove))
			{
				global::_0082._007E_0086_0005(spn_toollowerradius, true);
				global::_0082._007E_0086_0005(spn_tooltaperangle, true);
				global::_0082._007E_0086_0005(this._0001, true);
				return;
			}
			if (Tool.Geometry.GeometryType == ToolType.Dove)
			{
				global::_0082._007E_0086_0005(spn_toollowerradius, true);
				global::_0082._007E_0086_0005(spn_tooltaperangle, true);
				global::_0082._007E_0086_0005(this._0001, true);
				global::_0082._007E_0086_0005(chk_cornerfull, false);
				if (2 == 0)
				{
				}
				return;
			}
			bool num = Tool.Geometry.GeometryType == ToolType.Chamfer;
			do
			{
				bool flag = num;
				num = flag;
			}
			while (false);
			if (num)
			{
				if (7u != 0)
				{
					global::_0082._007E_0086_0005(spn_toollowerradius, true);
					global::_0082._007E_0086_0005(spn_tooltaperangle, true);
					global::_0082._007E_0086_0005(spn_tooloutsidedia, true);
					if (2u != 0)
					{
						global::_0082._007E_0086_0005(this._0001, true);
						return;
					}
					goto IL_0376;
				}
				return;
			}
			flag2 = Tool.Geometry.GeometryType == ToolType.Lollipop;
		}
		if (flag2)
		{
			global::_0082._007E_0086_0005(spn_tooloutsidedia, true);
			return;
		}
		goto IL_0376;
		IL_0376:
		if (Tool.Geometry.GeometryType == ToolType.Grinding)
		{
			global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_tooloutsidedia), global::_0013_0002._0090_0008(new string[5]
			{
				buLangTranslate.preDef.Tool,
				_008F(107398222),
				buLangTranslate.preDef.Inside,
				_008F(107398222),
				buLangTranslate.preDef.Diameter
			}));
			global::_0082._007E_0086_0005(spn_tooloutsidedia, true);
		}
	}

	public void Apply()
	{
		Tool.Data.Name = global::_0005._007E_0083(this._0001);
		Tool.CamData.SpindleSpeed = global::_0007._007E_0094(spn_toolspeed);
		Tool.Geometry.Length = global::_0007._007E_0094(spn_toollength);
		Tool.Geometry.Diameter = global::_0007._007E_0094(spn_tooldia);
		Tool.Geometry.CutLength = global::_0007._007E_0094(spn_toolcuttinglen);
		Tool.Geometry.LowerRadius = global::_0007._007E_0094(spn_toollowerradius);
		Tool.Geometry.RoundRadius = global::_0007._007E_0094(spn_toollowerradius);
		Tool.Geometry.OutsideDiameter = global::_0007._007E_0094(spn_tooloutsidedia);
		Tool.Geometry.TaperAngle = global::_0007._007E_0094(spn_tooltaperangle);
		Tool.Geometry.DrawArbor = false;
		Tool.Geometry.DrawHolder = false;
		if (Tool.Geometry.CutLength <= 0.0)
		{
			Tool.Geometry.CutLength = Tool.Geometry.Length * 0.75;
		}
		if (!(Tool.Geometry.Diameter <= 0.0))
		{
			if (global::_0003._007E_0010(chk_flat))
			{
				Tool.Geometry.GeometryType = ToolType.Flat;
				Tool.Purpose = ToolPurpose.Milling;
			}
			else if (global::_0003._007E_0010(chk_sphare))
			{
				Tool.Geometry.GeometryType = ToolType.Sphere;
				Tool.Purpose = ToolPurpose.Milling;
			}
			else if (global::_0003._007E_0010(chk_boolnose))
			{
				Tool.Geometry.GeometryType = ToolType.Bullnose;
				Tool.Purpose = ToolPurpose.Milling;
			}
			else if (global::_0003._007E_0010(chk_taper))
			{
				Tool.Geometry.GeometryType = ToolType.Taper;
				Tool.Purpose = ToolPurpose.Milling;
			}
			else if (global::_0003._007E_0010(chk_lollipop))
			{
				Tool.Geometry.GeometryType = ToolType.Lollipop;
				Tool.Purpose = ToolPurpose.Milling;
			}
			else if (global::_0003._007E_0010(chk_chamfer))
			{
				Tool.Geometry.GeometryType = ToolType.Chamfer;
				Tool.Purpose = ToolPurpose.Milling;
			}
			else if (global::_0003._007E_0010(chk_dove))
			{
				Tool.Geometry.GeometryType = ToolType.Dove;
				Tool.Purpose = ToolPurpose.Milling;
			}
			else if (global::_0003._007E_0010(chk_barrel))
			{
				Tool.Geometry.GeometryType = ToolType.Barrel;
				Tool.Purpose = ToolPurpose.Milling;
			}
			else if (global::_0003._007E_0010(chk_slot))
			{
				Tool.Geometry.GeometryType = ToolType.Slot;
				Tool.Purpose = ToolPurpose.Milling;
			}
			else if (global::_0003._007E_0010(chk_grinding))
			{
				Tool.Geometry.GeometryType = ToolType.Grinding;
				Tool.Purpose = ToolPurpose.Milling;
			}
			if (global::_0003._007E_0010(chk_cornercorner))
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Corner;
			}
			else if (global::_0003._007E_0010(chk_cornerfull))
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Full;
			}
			else
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.None;
			}
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

	internal void _0002(object P_0, EventArgs P_1)
	{
		try
		{
			Control control = new Control();
			Control obj = (Control)P_0;
			if (0 == 0)
			{
				control = obj;
			}
			global::_0082._007E_0089_0005(chk_flat, false);
			global::_0082._007E_0089_0005(chk_sphare, false);
			global::_0082._007E_0089_0005(chk_boolnose, false);
			while (true)
			{
				global::_0082._007E_0089_0005(chk_taper, false);
				global::_0082._007E_0089_0005(chk_chamfer, false);
				global::_0082._007E_0089_0005(chk_grinding, false);
				global::_0082._007E_0089_0005(chk_barrel, false);
				global::_0082._007E_0089_0005(chk_lollipop, false);
				global::_0082._007E_0089_0005(chk_slot, false);
				global::_0082._007E_0089_0005(chk_dove, false);
				bool num;
				if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(chk_flat)))
				{
					Tool.Geometry.GeometryType = ToolType.Flat;
				}
				else
				{
					if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(chk_sphare)))
					{
						Tool.Geometry.GeometryType = ToolType.Sphere;
						Tool.Purpose = ToolPurpose.Milling;
						global::_0082._007E_0089_0005(chk_sphare, true);
						break;
					}
					if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(chk_boolnose)))
					{
						Tool.Geometry.GeometryType = ToolType.Bullnose;
						if (Tool.Geometry.Diameter < Tool.Geometry.RoundRadius * 2.0)
						{
							Tool.Geometry.Diameter = Tool.Geometry.RoundRadius * 2.5;
							global::_0095._007E_0008_0008(spn_tooldia, Tool.Geometry.Diameter);
						}
						Tool.Purpose = ToolPurpose.Milling;
						if (Tool.Geometry.CornerRadiusType == ToolCornerRadiusType.Corner && Tool.Geometry.RoundRadius > Tool.Geometry.Diameter / 2.0)
						{
							Tool.Geometry.RoundRadius = Tool.Geometry.Diameter * 0.4;
							global::_0095._007E_0008_0008(spn_toollowerradius, Tool.Geometry.RoundRadius);
							if (false)
							{
								continue;
							}
						}
						global::_0082._007E_0089_0005(chk_boolnose, true);
						break;
					}
					if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(chk_taper)))
					{
						Tool.Geometry.GeometryType = ToolType.Taper;
						Tool.Purpose = ToolPurpose.Milling;
						if (Tool.Geometry.CornerRadiusType == ToolCornerRadiusType.Corner && Tool.Geometry.LowerRadius > Tool.Geometry.Diameter / 2.0)
						{
							Tool.Geometry.LowerRadius = Tool.Geometry.Diameter * 0.4;
							global::_0095._007E_0008_0008(spn_toollowerradius, Tool.Geometry.LowerRadius);
						}
						global::_0082._007E_0089_0005(chk_taper, true);
						break;
					}
					if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(chk_dove)))
					{
						Tool.Geometry.GeometryType = ToolType.Dove;
						Tool.Purpose = ToolPurpose.Milling;
						if (Tool.Geometry.CornerRadiusType == ToolCornerRadiusType.Corner)
						{
							bool flag = Tool.Geometry.LowerRadius > Tool.Geometry.Diameter / 2.0;
							num = flag;
							if (5 == 0)
							{
								goto IL_06dc;
							}
							if (num)
							{
								goto IL_04c1;
							}
						}
						goto IL_050f;
					}
					if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(chk_chamfer)))
					{
						Tool.Geometry.GeometryType = ToolType.Chamfer;
						Tool.Purpose = ToolPurpose.Milling;
						global::_0082._007E_0089_0005(chk_chamfer, true);
						break;
					}
					if (!global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(chk_barrel)))
					{
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(chk_slot)))
						{
							Tool.Geometry.GeometryType = ToolType.Slot;
							Tool.Purpose = ToolPurpose.Milling;
							global::_0082._007E_0089_0005(chk_slot, true);
							break;
						}
						if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(chk_grinding)))
						{
							Tool.Geometry.GeometryType = ToolType.Grinding;
							Tool.Purpose = ToolPurpose.Milling;
							global::_0082._007E_0089_0005(chk_grinding, true);
							break;
						}
						bool flag2 = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(chk_lollipop));
						num = flag2;
						goto IL_06dc;
					}
					Tool.Geometry.GeometryType = ToolType.Barrel;
					if (7u != 0)
					{
						Tool.Purpose = ToolPurpose.Milling;
						global::_0082._007E_0089_0005(chk_barrel, true);
						break;
					}
				}
				Tool.Purpose = ToolPurpose.Milling;
				global::_0082._007E_0089_0005(chk_flat, true);
				break;
				IL_050f:
				global::_0082._007E_0089_0005(chk_dove, true);
				break;
				IL_06dc:
				if (!num)
				{
					break;
				}
				Tool.Geometry.GeometryType = ToolType.Lollipop;
				Tool.Purpose = ToolPurpose.Milling;
				if (Tool.Geometry.OutsideDiameter > Tool.Geometry.Diameter / 2.0)
				{
					if (6 == 0)
					{
						goto IL_04c1;
					}
					Tool.Geometry.OutsideDiameter = Tool.Geometry.Diameter * 0.3;
					global::_0095._007E_0008_0008(spn_tooloutsidedia, Tool.Geometry.OutsideDiameter);
				}
				global::_0082._007E_0089_0005(chk_lollipop, true);
				break;
				IL_04c1:
				Tool.Geometry.LowerRadius = Tool.Geometry.Diameter * 0.4;
				global::_0095._007E_0008_0008(spn_toollowerradius, Tool.Geometry.LowerRadius);
				goto IL_050f;
			}
			ControlUpdate();
			Apply();
		}
		catch (Exception)
		{
		}
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		try
		{
			Control control = new Control();
			Control control2;
			if (8u != 0)
			{
				control2 = control;
			}
			control2 = (Control)P_0;
			global::_0082._007E_0089_0005(chk_cornercorner, false);
			global::_0082._007E_0089_0005(chk_cornerfull, false);
			global::_0082._007E_0089_0005(chk_cornernone, false);
			if (global::_0001._0001(global::_0005._007E_0084(control2), global::_0005._007E_0084(chk_cornercorner)))
			{
				goto IL_008c;
			}
			if (global::_0001._0001(global::_0005._007E_0084(control2), global::_0005._007E_0084(chk_cornerfull)))
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Full;
				global::_0082._007E_0089_0005(chk_cornerfull, true);
			}
			else
			{
				if (false)
				{
					goto IL_008c;
				}
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.None;
				global::_0082._007E_0089_0005(chk_cornernone, true);
			}
			goto IL_01aa;
			IL_008c:
			Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Corner;
			if (Tool.Geometry.LowerRadius > Tool.Geometry.Diameter / 2.0)
			{
				Tool.Geometry.LowerRadius = Tool.Geometry.Diameter * 0.4;
				global::_0095._007E_0008_0008(spn_toollowerradius, Tool.Geometry.LowerRadius);
			}
			global::_0082._007E_0089_0005(chk_cornercorner, true);
			goto IL_01aa;
			IL_01aa:
			ControlUpdate();
			Apply();
		}
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
	}

	internal void _0004(object P_0, EventArgs P_1)
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

	internal void _0005(object P_0, EventArgs P_1)
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

	static F_MarbleToolTypes()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarbleToolTypes));
		Captions = new List<string>();
	}
}
