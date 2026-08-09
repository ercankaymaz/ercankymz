using System;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteProfessionalOffice2003 : PaletteProfessionalSystem
{
	private static readonly Color[] _colorsB = new Color[2]
	{
		Color.FromArgb(89, 135, 214),
		Color.FromArgb(4, 57, 148)
	};

	private static readonly Color[] _colorsG = new Color[2]
	{
		Color.FromArgb(175, 192, 130),
		Color.FromArgb(99, 122, 69)
	};

	private static readonly Color[] _colorsS = new Color[2]
	{
		Color.FromArgb(168, 167, 191),
		Color.FromArgb(113, 112, 145)
	};

	private bool _usingOffice2003;

	internal override KryptonProfessionalKCT GenerateColorTable()
	{
		if (Environment.OSVersion.Version.Major < 6 && VisualStyleInformation.IsEnabledByUser)
		{
			switch (VisualStyleInformation.ColorScheme)
			{
			case "NormalColor":
				_usingOffice2003 = true;
				return new KryptonProfessionalKCT(_colorsB, useSystemColors: false, this);
			case "HomeStead":
				_usingOffice2003 = true;
				return new KryptonProfessionalKCT(_colorsG, useSystemColors: false, this);
			case "Metallic":
				_usingOffice2003 = true;
				return new KryptonProfessionalKCT(_colorsS, useSystemColors: false, this);
			}
		}
		_usingOffice2003 = false;
		return base.GenerateColorTable();
	}

	public override PaletteColorStyle GetBackColorStyle(PaletteBackStyle style, PaletteState state)
	{
		if (_usingOffice2003)
		{
			if ((uint)(style - 51) <= 1u)
			{
				return PaletteColorStyle.Solid;
			}
		}
		return base.GetBackColorStyle(style, state);
	}

	public override Color GetBackColor1(PaletteBackStyle style, PaletteState state)
	{
		if (_usingOffice2003)
		{
			switch (style)
			{
			case PaletteBackStyle.ContextMenuItemHighlight:
				switch (state)
				{
				case PaletteState.Disabled:
					return SystemColors.Control;
				case PaletteState.Normal:
					return Color.Empty;
				case PaletteState.Tracking:
					return ColorTable.MenuItemSelectedGradientBegin;
				}
				break;
			case PaletteBackStyle.HeaderDockInactive:
				if (state == PaletteState.Disabled)
				{
					return SystemColors.Control;
				}
				return ColorTable.ButtonCheckedHighlight;
			case PaletteBackStyle.HeaderDockActive:
				if (state == PaletteState.Disabled)
				{
					return SystemColors.Control;
				}
				return SystemColors.Highlight;
			}
		}
		return base.GetBackColor1(style, state);
	}

	public override Color GetBackColor2(PaletteBackStyle style, PaletteState state)
	{
		if (_usingOffice2003)
		{
			switch (style)
			{
			case PaletteBackStyle.ContextMenuItemHighlight:
				switch (state)
				{
				case PaletteState.Disabled:
					return SystemColors.Control;
				case PaletteState.Normal:
					return Color.Empty;
				case PaletteState.Tracking:
					return ColorTable.MenuItemSelectedGradientBegin;
				}
				break;
			case PaletteBackStyle.HeaderDockInactive:
				if (state == PaletteState.Disabled)
				{
					return SystemColors.Control;
				}
				return ColorTable.ButtonCheckedHighlight;
			case PaletteBackStyle.HeaderDockActive:
				if (state == PaletteState.Disabled)
				{
					return SystemColors.Control;
				}
				return SystemColors.Highlight;
			case PaletteBackStyle.TabDock:
				switch (state)
				{
				case PaletteState.Disabled:
					return SystemColors.Control;
				case PaletteState.Normal:
					return PaletteBase.MergeColors(SystemColors.Window, 0.1f, ColorTable.ButtonCheckedHighlight, 0.9f);
				case PaletteState.Tracking:
				case PaletteState.Pressed:
					return PaletteBase.MergeColors(SystemColors.Window, 0.4f, ColorTable.ButtonCheckedGradientMiddle, 0.6f);
				case PaletteState.CheckedNormal:
				case PaletteState.CheckedTracking:
				case PaletteState.CheckedPressed:
					return SystemColors.Window;
				}
				break;
			}
		}
		return base.GetBackColor2(style, state);
	}

	public override Color GetContentShortTextColor1(PaletteContentStyle style, PaletteState state)
	{
		if (_usingOffice2003)
		{
			if (state == PaletteState.Disabled)
			{
				return SystemColors.ControlDark;
			}
			switch (style)
			{
			case PaletteContentStyle.GridHeaderColumnList:
			case PaletteContentStyle.GridHeaderRowList:
			case PaletteContentStyle.GridHeaderColumnSheet:
			case PaletteContentStyle.GridHeaderRowSheet:
			case PaletteContentStyle.GridHeaderColumnCustom1:
			case PaletteContentStyle.GridHeaderRowCustom1:
			case PaletteContentStyle.HeaderDockInactive:
				return SystemColors.ControlText;
			case PaletteContentStyle.HeaderDockActive:
				return SystemColors.ActiveCaptionText;
			}
		}
		return base.GetContentShortTextColor1(style, state);
	}

	public override Color GetContentShortTextColor2(PaletteContentStyle style, PaletteState state)
	{
		if (_usingOffice2003)
		{
			if (state == PaletteState.Disabled)
			{
				return SystemColors.ControlDark;
			}
			switch (style)
			{
			case PaletteContentStyle.HeaderDockInactive:
				return SystemColors.ControlText;
			case PaletteContentStyle.HeaderDockActive:
				return SystemColors.ActiveCaptionText;
			}
		}
		return base.GetContentShortTextColor2(style, state);
	}
}
