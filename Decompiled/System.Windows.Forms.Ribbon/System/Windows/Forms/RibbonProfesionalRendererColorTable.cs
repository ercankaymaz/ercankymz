using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms.RibbonHelpers;
using System.Xml;

namespace System.Windows.Forms;

public class RibbonProfesionalRendererColorTable
{
	public Color FormBorder = FromHexStr("#3B5A82");

	public Color OrbDropDownDarkBorder = Color.FromArgb(155, 175, 202);

	public Color OrbDropDownLightBorder = Color.FromArgb(255, 255, 255);

	public Color OrbDropDownBack = Color.FromArgb(191, 211, 235);

	public Color OrbDropDownNorthA = Color.FromArgb(215, 229, 247);

	public Color OrbDropDownNorthB = Color.FromArgb(212, 225, 243);

	public Color OrbDropDownNorthC = Color.FromArgb(198, 216, 238);

	public Color OrbDropDownNorthD = Color.FromArgb(183, 202, 230);

	public Color OrbDropDownSouthC = Color.FromArgb(176, 201, 234);

	public Color OrbDropDownSouthD = Color.FromArgb(207, 224, 245);

	public Color OrbDropDownContentbg = Color.FromArgb(233, 234, 238);

	public Color OrbDropDownContentbglight = Color.FromArgb(250, 250, 250);

	public Color OrbDropDownSeparatorlight = Color.FromArgb(245, 245, 245);

	public Color OrbDropDownSeparatordark = Color.FromArgb(197, 197, 197);

	public Color Caption1 = FromHexStr("#E3EBF6");

	public Color Caption2 = FromHexStr("#DAE9FD");

	public Color Caption3 = FromHexStr("#D5E5FA");

	public Color Caption4 = FromHexStr("#D9E7F9");

	public Color Caption5 = FromHexStr("#CADEF7");

	public Color Caption6 = FromHexStr("#E4EFFD");

	public Color Caption7 = FromHexStr("#B0CFF7");

	public Color QuickAccessBorderDark = FromHexStr("#B6CAE2");

	public Color QuickAccessBorderLight = FromHexStr("#F2F6FB");

	public Color QuickAccessUpper = FromHexStr("#E0EBF9");

	public Color QuickAccessLower = FromHexStr("#C9D9EE");

	public Color OrbOptionBorder = FromHexStr("#7793B9");

	public Color OrbOptionBackground = FromHexStr("#E8F1FC");

	public Color OrbOptionShine = FromHexStr("#D2E1F4");

	public Color Arrow = FromHexStr("#678CBD");

	public Color ArrowLight = Color.FromArgb(200, Color.White);

	public Color ArrowDisabled = FromHexStr("#B7B7B7");

	public Color Text = FromHexStr("#15428B");

	public Color OrbBackgroundDark = FromHexStr("#7C8CA4");

	public Color OrbBackgroundMedium = FromHexStr("#99ABC6");

	public Color OrbBackgroundLight = Color.White;

	public Color OrbLight = Color.White;

	public Color OrbSelectedBackgroundDark = FromHexStr("#DFAA1A");

	public Color OrbSelectedBackgroundMedium = FromHexStr("#F9D12E");

	public Color OrbSelectedBackgroundLight = FromHexStr("#FFEF36");

	public Color OrbSelectedLight = FromHexStr("#FFF52B");

	public Color OrbPressedBackgroundDark = FromHexStr("#CE8410");

	public Color OrbPressedBackgroundMedium = FromHexStr("#CE8410");

	public Color OrbPressedBackgroundLight = FromHexStr("#F57603");

	public Color OrbPressedLight = FromHexStr("#F08500");

	public Color OrbBorderAero = FromHexStr("#99A1AD");

	public Color OrbButtonText = Color.White;

	public Color OrbButtonBackground = Color.FromArgb(60, 120, 187);

	public Color OrbButtonDark = Color.FromArgb(25, 65, 135);

	public Color OrbButtonMedium = Color.FromArgb(56, 135, 191);

	public Color OrbButtonLight = Color.FromArgb(64, 154, 207);

	public Color OrbButtonPressedCenter = Color.FromArgb(25, 64, 136);

	public Color OrbButtonPressedNorth = Color.FromArgb(71, 132, 194);

	public Color OrbButtonPressedSouth = Color.FromArgb(56, 135, 191);

	public Color OrbButtonGlossyNorth = Color.FromArgb(71, 132, 194);

	public Color OrbButtonGlossySouth = Color.FromArgb(46, 104, 178);

	public Color OrbButtonBorderDark = Color.FromArgb(68, 135, 213);

	public Color OrbButtonBorderLight = Color.FromArgb(160, 204, 243);

	public Color RibbonBackground = FromHexStr("#BED0E8");

	public Color TabBorder = FromHexStr("#9FB2C7");

	public Color TabSelectedBorder = FromHexStr("#B1B5BA");

	public Color TabNorth = FromHexStr("#EBF3FE");

	public Color TabSouth = FromHexStr("#E1EAF6");

	public Color TabGlow = FromHexStr("#D1FBFF");

	public Color TabText = FromHexStr("#15428B");

	public Color TabActiveText = FromHexStr("#15428B");

	public Color TabContentNorth = FromHexStr("#C8D9ED");

	public Color TabContentSouth = FromHexStr("#E7F2FF");

	public Color TabSelectedGlow = FromHexStr("#E1D2A5");

	public Color PanelDarkBorder = Color.FromArgb(51, FromHexStr("#15428B"));

	public Color PanelLightBorder = Color.FromArgb(102, Color.White);

	public Color PanelTextBackground = FromHexStr("#C2D9F0");

	public Color PanelTextBackgroundSelected = FromHexStr("#C2D9F0");

	public Color PanelText = FromHexStr("#15428B");

	public Color PanelBackgroundSelected = Color.FromArgb(102, FromHexStr("#E8FFFD"));

	public Color PanelOverflowBackground = FromHexStr("#B9D1F0");

	public Color PanelOverflowBackgroundPressed = FromHexStr("#7699C8");

	public Color PanelOverflowBackgroundSelectedNorth = Color.FromArgb(100, Color.White);

	public Color PanelOverflowBackgroundSelectedSouth = Color.FromArgb(102, FromHexStr("#B8D7FD"));

	public Color ButtonBgOut = FromHexStr("#C1D5F1");

	public Color ButtonBgCenter = FromHexStr("#CFE0F7");

	public Color ButtonBorderOut = FromHexStr("#B9D0ED");

	public Color ButtonBorderIn = FromHexStr("#E3EDFB");

	public Color ButtonGlossyNorth = FromHexStr("#DEEBFE");

	public Color ButtonGlossySouth = FromHexStr("#CBDEF6");

	public Color ButtonDisabledBgOut = FromHexStr("#E0E4E8");

	public Color ButtonDisabledBgCenter = FromHexStr("#E8EBEF");

	public Color ButtonDisabledBorderOut = FromHexStr("#C5D1DE");

	public Color ButtonDisabledBorderIn = FromHexStr("#F1F3F5");

	public Color ButtonDisabledGlossyNorth = FromHexStr("#F0F3F6");

	public Color ButtonDisabledGlossySouth = FromHexStr("#EAEDF1");

	public Color ButtonSelectedBgOut = FromHexStr("#FFD646");

	public Color ButtonSelectedBgCenter = FromHexStr("#FFEAAC");

	public Color ButtonSelectedBorderOut = FromHexStr("#C2A978");

	public Color ButtonSelectedBorderIn = FromHexStr("#FFF2C7");

	public Color ButtonSelectedGlossyNorth = FromHexStr("#FFFDDB");

	public Color ButtonSelectedGlossySouth = FromHexStr("#FFE793");

	public Color ButtonPressedBgOut = FromHexStr("#F88F2C");

	public Color ButtonPressedBgCenter = FromHexStr("#FDF1B0");

	public Color ButtonPressedBorderOut = FromHexStr("#8E8165");

	public Color ButtonPressedBorderIn = FromHexStr("#F9C65A");

	public Color ButtonPressedGlossyNorth = FromHexStr("#FDD5A8");

	public Color ButtonPressedGlossySouth = FromHexStr("#FBB062");

	public Color ButtonCheckedBgOut = FromHexStr("#F9AA45");

	public Color ButtonCheckedBgCenter = FromHexStr("#FDEA9D");

	public Color ButtonCheckedBorderOut = FromHexStr("#8E8165");

	public Color ButtonCheckedBorderIn = FromHexStr("#F9C65A");

	public Color ButtonCheckedGlossyNorth = FromHexStr("#F8DBB7");

	public Color ButtonCheckedGlossySouth = FromHexStr("#FED18E");

	public Color ButtonCheckedSelectedBgOut = FromHexStr("#F9AA45");

	public Color ButtonCheckedSelectedBgCenter = FromHexStr("#FDEA9D");

	public Color ButtonCheckedSelectedBorderOut = FromHexStr("#8E8165");

	public Color ButtonCheckedSelectedBorderIn = FromHexStr("#F9C65A");

	public Color ButtonCheckedSelectedGlossyNorth = FromHexStr("#F8DBB7");

	public Color ButtonCheckedSelectedGlossySouth = FromHexStr("#FED18E");

	public Color ItemGroupOuterBorder = FromHexStr("#9EBAE1");

	public Color ItemGroupInnerBorder = Color.FromArgb(51, Color.White);

	public Color ItemGroupSeparatorLight = Color.FromArgb(64, Color.White);

	public Color ItemGroupSeparatorDark = Color.FromArgb(38, FromHexStr("#9EBAE1"));

	public Color ItemGroupBgNorth = FromHexStr("#CADCF0");

	public Color ItemGroupBgSouth = FromHexStr("#D0E1F7");

	public Color ItemGroupBgGlossy = FromHexStr("#BCD0E9");

	public Color ButtonListBorder = FromHexStr("#B9D0ED");

	public Color ButtonListBg = FromHexStr("#D4E6F8");

	public Color ButtonListBgSelected = FromHexStr("#ECF3FB");

	public Color DropDownBg = FromHexStr("#FAFAFA");

	public Color DropDownImageBg = FromHexStr("#E9EEEE");

	public Color DropDownImageSeparator = FromHexStr("#C5C5C5");

	public Color DropDownBorder = FromHexStr("#868686");

	public Color DropDownGripNorth = FromHexStr("#FFFFFF");

	public Color DropDownGripSouth = FromHexStr("#DFE9EF");

	public Color DropDownGripBorder = FromHexStr("#DDE7EE");

	public Color DropDownGripDark = FromHexStr("#5574A7");

	public Color DropDownGripLight = FromHexStr("#FFFFFF");

	public Color DropDownCheckedButtonGlyphBg = FromHexStr("#FCF1C2");

	public Color DropDownCheckedButtonGlyphBorder = FromHexStr("#F29536");

	public Color SeparatorLight = FromHexStr("#FAFBFD");

	public Color SeparatorDark = FromHexStr("#96B4DA");

	public Color QATSeparatorLight = FromHexStr("#FAFBFD");

	public Color QATSeparatorDark = FromHexStr("#96B4DA");

	public Color SeparatorBg = FromHexStr("#DAE6EE");

	public Color SeparatorLine = FromHexStr("#C5C5C5");

	public Color TextBoxUnselectedBg = FromHexStr("#EAF2FB");

	public Color TextBoxBorder = FromHexStr("#ABC1DE");

	public Color ToolTipContentNorth = Color.FromArgb(250, 252, 254);

	public Color ToolTipContentSouth = Color.FromArgb(206, 220, 241);

	public Color ToolTipDarkBorder = Color.DarkGray;

	public Color ToolTipLightBorder = Color.FromArgb(102, Color.White);

	public Color ToolTipText = (WinApi.IsVista ? SystemColors.InactiveCaptionText : FromHexStr("#15428B"));

	public Color ToolStripItemTextPressed = FromHexStr("#444444");

	public Color ToolStripItemTextSelected = FromHexStr("#444444");

	public Color ToolStripItemText = FromHexStr("#444444");

	public Color clrVerBG_Shadow = Color.FromArgb(255, 181, 190, 206);

	public Color ButtonChecked_2013 = FromHexStr("#CDE6F7");

	public Color ButtonPressed_2013 = FromHexStr("#92C0E0");

	public Color ButtonSelected_2013 = FromHexStr("#CDE6F7");

	public Color OrbButton_2013 = FromHexStr("#0072C6");

	public Color OrbButtonSelected_2013 = FromHexStr("#2A8AD4");

	public Color OrbButtonPressed_2013 = FromHexStr("#2A8AD4");

	public Color TabText_2013 = FromHexStr("#0072C6");

	public Color TabTextSelected_2013 = FromHexStr("#444444");

	public Color PanelBorder_2013 = FromHexStr("#15428B");

	public Color RibbonBackground_2013 = FromHexStr("#FFFFFF");

	public Color TabCompleteBackground_2013 = FromHexStr("#FFFFFF");

	public Color TabNormalBackground_2013 = FromHexStr("#FFFFFF");

	public Color TabActiveBackbround_2013 = FromHexStr("#FFFFFF");

	public Color TabBorder_2013 = FromHexStr("#D4D4D4");

	public Color TabCompleteBorder_2013 = FromHexStr("#D4D4D4");

	public Color TabActiveBorder_2013 = FromHexStr("#D4D4D4");

	public Color OrbButtonText_2013 = FromHexStr("#FFFFFF");

	public Color PanelText_2013 = FromHexStr("#666666");

	public Color RibbonItemText_2013 = FromHexStr("#444444");

	public Color ToolTipText_2013 = FromHexStr("#262626");

	public Color ToolStripItemTextPressed_2013 = FromHexStr("#444444");

	public Color ToolStripItemTextSelected_2013 = FromHexStr("#444444");

	public Color ToolStripItemText_2013 = FromHexStr("#444444");

	public string ThemeName { get; set; }

	public string ThemeAuthor { get; set; }

	public string ThemeAuthorEmail { get; set; }

	public string ThemeAuthorWebsite { get; set; }

	public string ThemeDateCreated { get; set; }

	private static Color FromHexStr(string hex)
	{
		if (hex.StartsWith("#"))
		{
			hex = hex.Substring(1);
		}
		return hex.Length switch
		{
			6 => Color.FromArgb(int.Parse(hex.Substring(0, 2), NumberStyles.HexNumber), int.Parse(hex.Substring(2, 2), NumberStyles.HexNumber), int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber)), 
			8 => Color.FromArgb(int.Parse(hex.Substring(0, 2), NumberStyles.HexNumber), int.Parse(hex.Substring(2, 2), NumberStyles.HexNumber), int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber), int.Parse(hex.Substring(6, 2), NumberStyles.HexNumber)), 
			_ => throw new ArgumentException("Color not valid"), 
		};
	}

	public Color FromHex(string hex)
	{
		return FromHexStr(hex);
	}

	internal static Color ToGray(Color c)
	{
		int num = (c.R + c.G + c.B) / 3;
		return Color.FromArgb(num, num, num);
	}

	public void SetColor(RibbonColorPart ribbonColorPart, int red, int green, int blue)
	{
		SetColor(ribbonColorPart, Color.FromArgb(red, green, blue));
	}

	public void SetColor(RibbonColorPart ribbonColorPart, string hexColor)
	{
		SetColor(ribbonColorPart, FromHex(hexColor));
	}

	public void SetColor(RibbonColorPart ribbonColorPart, Color color)
	{
		switch (ribbonColorPart)
		{
		case RibbonColorPart.OrbDropDownDarkBorder:
			OrbDropDownDarkBorder = color;
			break;
		case RibbonColorPart.OrbDropDownLightBorder:
			OrbDropDownLightBorder = color;
			break;
		case RibbonColorPart.OrbDropDownBack:
			OrbDropDownBack = color;
			break;
		case RibbonColorPart.OrbDropDownNorthA:
			OrbDropDownNorthA = color;
			break;
		case RibbonColorPart.OrbDropDownNorthB:
			OrbDropDownNorthB = color;
			break;
		case RibbonColorPart.OrbDropDownNorthC:
			OrbDropDownNorthC = color;
			break;
		case RibbonColorPart.OrbDropDownNorthD:
			OrbDropDownNorthD = color;
			break;
		case RibbonColorPart.OrbDropDownSouthC:
			OrbDropDownSouthC = color;
			break;
		case RibbonColorPart.OrbDropDownSouthD:
			OrbDropDownSouthD = color;
			break;
		case RibbonColorPart.OrbDropDownContentbg:
			OrbDropDownContentbg = color;
			break;
		case RibbonColorPart.OrbDropDownContentbglight:
			OrbDropDownContentbglight = color;
			break;
		case RibbonColorPart.OrbDropDownSeparatorlight:
			OrbDropDownSeparatorlight = color;
			break;
		case RibbonColorPart.OrbDropDownSeparatordark:
			OrbDropDownSeparatordark = color;
			break;
		case RibbonColorPart.Caption1:
			Caption1 = color;
			break;
		case RibbonColorPart.Caption2:
			Caption2 = color;
			break;
		case RibbonColorPart.Caption3:
			Caption3 = color;
			break;
		case RibbonColorPart.Caption4:
			Caption4 = color;
			break;
		case RibbonColorPart.Caption5:
			Caption5 = color;
			break;
		case RibbonColorPart.Caption6:
			Caption6 = color;
			break;
		case RibbonColorPart.Caption7:
			Caption7 = color;
			break;
		case RibbonColorPart.QuickAccessBorderDark:
			QuickAccessBorderDark = color;
			break;
		case RibbonColorPart.QuickAccessBorderLight:
			QuickAccessBorderLight = color;
			break;
		case RibbonColorPart.QuickAccessUpper:
			QuickAccessUpper = color;
			break;
		case RibbonColorPart.QuickAccessLower:
			QuickAccessLower = color;
			break;
		case RibbonColorPart.OrbOptionBorder:
			OrbOptionBorder = color;
			break;
		case RibbonColorPart.OrbOptionBackground:
			OrbOptionBackground = color;
			break;
		case RibbonColorPart.OrbOptionShine:
			OrbOptionShine = color;
			break;
		case RibbonColorPart.Arrow:
			Arrow = color;
			break;
		case RibbonColorPart.ArrowLight:
			ArrowLight = color;
			break;
		case RibbonColorPart.ArrowDisabled:
			ArrowDisabled = color;
			break;
		case RibbonColorPart.Text:
			Text = color;
			break;
		case RibbonColorPart.RibbonBackground:
			RibbonBackground = color;
			break;
		case RibbonColorPart.TabBorder:
			TabBorder = color;
			break;
		case RibbonColorPart.TabNorth:
			TabNorth = color;
			break;
		case RibbonColorPart.TabSouth:
			TabSouth = color;
			break;
		case RibbonColorPart.TabGlow:
			TabGlow = color;
			break;
		case RibbonColorPart.TabText:
			TabText = color;
			break;
		case RibbonColorPart.TabActiveText:
			TabActiveText = color;
			break;
		case RibbonColorPart.TabContentNorth:
			TabContentNorth = color;
			break;
		case RibbonColorPart.TabContentSouth:
			TabContentSouth = color;
			break;
		case RibbonColorPart.TabSelectedGlow:
			TabSelectedGlow = color;
			break;
		case RibbonColorPart.PanelDarkBorder:
			PanelDarkBorder = color;
			break;
		case RibbonColorPart.PanelLightBorder:
			PanelLightBorder = color;
			break;
		case RibbonColorPart.PanelTextBackground:
			PanelTextBackground = color;
			break;
		case RibbonColorPart.PanelTextBackgroundSelected:
			PanelTextBackgroundSelected = color;
			break;
		case RibbonColorPart.PanelText:
			PanelText = color;
			break;
		case RibbonColorPart.PanelBackgroundSelected:
			PanelBackgroundSelected = color;
			break;
		case RibbonColorPart.PanelOverflowBackground:
			PanelOverflowBackground = color;
			break;
		case RibbonColorPart.PanelOverflowBackgroundPressed:
			PanelOverflowBackgroundPressed = color;
			break;
		case RibbonColorPart.PanelOverflowBackgroundSelectedNorth:
			PanelOverflowBackgroundSelectedNorth = color;
			break;
		case RibbonColorPart.PanelOverflowBackgroundSelectedSouth:
			PanelOverflowBackgroundSelectedSouth = color;
			break;
		case RibbonColorPart.ButtonBgOut:
			ButtonBgOut = color;
			break;
		case RibbonColorPart.ButtonBgCenter:
			ButtonBgCenter = color;
			break;
		case RibbonColorPart.ButtonBorderOut:
			ButtonBorderOut = color;
			break;
		case RibbonColorPart.ButtonBorderIn:
			ButtonBorderIn = color;
			break;
		case RibbonColorPart.ButtonGlossyNorth:
			ButtonGlossyNorth = color;
			break;
		case RibbonColorPart.ButtonGlossySouth:
			ButtonGlossySouth = color;
			break;
		case RibbonColorPart.ButtonDisabledBgOut:
			ButtonDisabledBgOut = color;
			break;
		case RibbonColorPart.ButtonDisabledBgCenter:
			ButtonDisabledBgCenter = color;
			break;
		case RibbonColorPart.ButtonDisabledBorderOut:
			ButtonDisabledBorderOut = color;
			break;
		case RibbonColorPart.ButtonDisabledBorderIn:
			ButtonDisabledBorderIn = color;
			break;
		case RibbonColorPart.ButtonDisabledGlossyNorth:
			ButtonDisabledGlossyNorth = color;
			break;
		case RibbonColorPart.ButtonDisabledGlossySouth:
			ButtonDisabledGlossySouth = color;
			break;
		case RibbonColorPart.ButtonSelectedBgOut:
			ButtonSelectedBgOut = color;
			break;
		case RibbonColorPart.ButtonSelectedBgCenter:
			ButtonSelectedBgCenter = color;
			break;
		case RibbonColorPart.ButtonSelectedBorderOut:
			ButtonSelectedBorderOut = color;
			break;
		case RibbonColorPart.ButtonSelectedBorderIn:
			ButtonSelectedBorderIn = color;
			break;
		case RibbonColorPart.ButtonSelectedGlossyNorth:
			ButtonSelectedGlossyNorth = color;
			break;
		case RibbonColorPart.ButtonSelectedGlossySouth:
			ButtonSelectedGlossySouth = color;
			break;
		case RibbonColorPart.ButtonPressedBgOut:
			ButtonPressedBgOut = color;
			break;
		case RibbonColorPart.ButtonPressedBgCenter:
			ButtonPressedBgCenter = color;
			break;
		case RibbonColorPart.ButtonPressedBorderOut:
			ButtonPressedBorderOut = color;
			break;
		case RibbonColorPart.ButtonPressedBorderIn:
			ButtonPressedBorderIn = color;
			break;
		case RibbonColorPart.ButtonPressedGlossyNorth:
			ButtonPressedGlossyNorth = color;
			break;
		case RibbonColorPart.ButtonPressedGlossySouth:
			ButtonPressedGlossySouth = color;
			break;
		case RibbonColorPart.ButtonCheckedBgOut:
			ButtonCheckedBgOut = color;
			break;
		case RibbonColorPart.ButtonCheckedBgCenter:
			ButtonCheckedBgCenter = color;
			break;
		case RibbonColorPart.ButtonCheckedBorderOut:
			ButtonCheckedBorderOut = color;
			break;
		case RibbonColorPart.ButtonCheckedBorderIn:
			ButtonCheckedBorderIn = color;
			break;
		case RibbonColorPart.ButtonCheckedGlossyNorth:
			ButtonCheckedGlossyNorth = color;
			break;
		case RibbonColorPart.ButtonCheckedGlossySouth:
			ButtonCheckedGlossySouth = color;
			break;
		case RibbonColorPart.ButtonCheckedSelectedBgOut:
			ButtonCheckedSelectedBgOut = color;
			break;
		case RibbonColorPart.ButtonCheckedSelectedBgCenter:
			ButtonCheckedSelectedBgCenter = color;
			break;
		case RibbonColorPart.ButtonCheckedSelectedBorderOut:
			ButtonCheckedSelectedBorderOut = color;
			break;
		case RibbonColorPart.ButtonCheckedSelectedBorderIn:
			ButtonCheckedSelectedBorderIn = color;
			break;
		case RibbonColorPart.ButtonCheckedSelectedGlossyNorth:
			ButtonCheckedSelectedGlossyNorth = color;
			break;
		case RibbonColorPart.ButtonCheckedSelectedGlossySouth:
			ButtonCheckedSelectedGlossySouth = color;
			break;
		case RibbonColorPart.ItemGroupOuterBorder:
			ItemGroupOuterBorder = color;
			break;
		case RibbonColorPart.ItemGroupInnerBorder:
			ItemGroupInnerBorder = color;
			break;
		case RibbonColorPart.ItemGroupSeparatorLight:
			ItemGroupSeparatorLight = color;
			break;
		case RibbonColorPart.ItemGroupSeparatorDark:
			ItemGroupSeparatorDark = color;
			break;
		case RibbonColorPart.ItemGroupBgNorth:
			ItemGroupBgNorth = color;
			break;
		case RibbonColorPart.ItemGroupBgSouth:
			ItemGroupBgSouth = color;
			break;
		case RibbonColorPart.ItemGroupBgGlossy:
			ItemGroupBgGlossy = color;
			break;
		case RibbonColorPart.ButtonListBorder:
			ButtonListBorder = color;
			break;
		case RibbonColorPart.ButtonListBg:
			ButtonListBg = color;
			break;
		case RibbonColorPart.ButtonListBgSelected:
			ButtonListBgSelected = color;
			break;
		case RibbonColorPart.DropDownBg:
			DropDownBg = color;
			break;
		case RibbonColorPart.DropDownImageBg:
			DropDownImageBg = color;
			break;
		case RibbonColorPart.DropDownImageSeparator:
			DropDownImageSeparator = color;
			break;
		case RibbonColorPart.DropDownBorder:
			DropDownBorder = color;
			break;
		case RibbonColorPart.DropDownGripNorth:
			DropDownGripNorth = color;
			break;
		case RibbonColorPart.DropDownGripSouth:
			DropDownGripSouth = color;
			break;
		case RibbonColorPart.DropDownGripBorder:
			DropDownGripBorder = color;
			break;
		case RibbonColorPart.DropDownGripDark:
			DropDownGripDark = color;
			break;
		case RibbonColorPart.DropDownGripLight:
			DropDownGripLight = color;
			break;
		case RibbonColorPart.DropDownCheckedButtonGlyphBg:
			DropDownCheckedButtonGlyphBg = color;
			break;
		case RibbonColorPart.DropDownCheckedButtonGlyphBorder:
			DropDownCheckedButtonGlyphBorder = color;
			break;
		case RibbonColorPart.SeparatorLight:
			SeparatorLight = color;
			break;
		case RibbonColorPart.SeparatorDark:
			SeparatorDark = color;
			break;
		case RibbonColorPart.QATSeparatorLight:
			QATSeparatorLight = color;
			break;
		case RibbonColorPart.QATSeparatorDark:
			QATSeparatorDark = color;
			break;
		case RibbonColorPart.SeparatorBg:
			SeparatorBg = color;
			break;
		case RibbonColorPart.SeparatorLine:
			SeparatorLine = color;
			break;
		case RibbonColorPart.TextBoxUnselectedBg:
			TextBoxUnselectedBg = color;
			break;
		case RibbonColorPart.TextBoxBorder:
			TextBoxBorder = color;
			break;
		case RibbonColorPart.ToolTipContentNorth:
			ToolTipContentNorth = color;
			break;
		case RibbonColorPart.ToolTipContentSouth:
			ToolTipContentSouth = color;
			break;
		case RibbonColorPart.ToolTipDarkBorder:
			ToolTipDarkBorder = color;
			break;
		case RibbonColorPart.ToolTipLightBorder:
			ToolTipLightBorder = color;
			break;
		case RibbonColorPart.ToolStripItemTextPressed:
			ToolStripItemTextPressed = color;
			break;
		case RibbonColorPart.ToolStripItemTextSelected:
			ToolStripItemTextSelected = color;
			break;
		case RibbonColorPart.ToolStripItemText:
			ToolStripItemText = color;
			break;
		case RibbonColorPart.ButtonChecked_2013:
			ButtonChecked_2013 = color;
			break;
		case RibbonColorPart.ButtonPressed_2013:
			ButtonPressed_2013 = color;
			break;
		case RibbonColorPart.ButtonSelected_2013:
			ButtonSelected_2013 = color;
			break;
		case RibbonColorPart.OrbButton_2013:
			OrbButton_2013 = color;
			break;
		case RibbonColorPart.OrbButtonSelected_2013:
			OrbButtonSelected_2013 = color;
			break;
		case RibbonColorPart.OrbButtonPressed_2013:
			OrbButtonPressed_2013 = color;
			break;
		case RibbonColorPart.TabText_2013:
			TabText_2013 = color;
			break;
		case RibbonColorPart.TabTextSelected_2013:
			TabTextSelected_2013 = color;
			break;
		case RibbonColorPart.PanelBorder_2013:
			PanelBorder_2013 = color;
			break;
		case RibbonColorPart.RibbonBackground_2013:
			RibbonBackground_2013 = color;
			break;
		case RibbonColorPart.TabCompleteBackground_2013:
			TabCompleteBackground_2013 = color;
			break;
		case RibbonColorPart.TabNormalBackground_2013:
			TabNormalBackground_2013 = color;
			break;
		case RibbonColorPart.TabActiveBackbround_2013:
			TabActiveBackbround_2013 = color;
			break;
		case RibbonColorPart.TabBorder_2013:
			TabBorder_2013 = color;
			break;
		case RibbonColorPart.TabCompleteBorder_2013:
			TabCompleteBorder_2013 = color;
			break;
		case RibbonColorPart.TabActiveBorder_2013:
			TabActiveBorder_2013 = color;
			break;
		case RibbonColorPart.OrbButtonText_2013:
			OrbButtonText_2013 = color;
			break;
		case RibbonColorPart.PanelText_2013:
			PanelText_2013 = color;
			break;
		case RibbonColorPart.RibbonItemText_2013:
			RibbonItemText_2013 = color;
			break;
		case RibbonColorPart.ToolTipText_2013:
			ToolTipText_2013 = color;
			break;
		case RibbonColorPart.ToolStripItemTextPressed_2013:
			ToolStripItemTextPressed_2013 = color;
			break;
		case RibbonColorPart.ToolStripItemTextSelected_2013:
			ToolStripItemTextSelected_2013 = color;
			break;
		case RibbonColorPart.ToolStripItemText_2013:
			ToolStripItemText_2013 = color;
			break;
		case RibbonColorPart.TabSelectedBorder:
		case RibbonColorPart.clrVerBG_Shadow:
			break;
		}
	}

	public string GetColorHexStr(RibbonColorPart ribbonColorPart)
	{
		Color color = GetColor(ribbonColorPart);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("#");
		stringBuilder.Append(BitConverter.ToString(new byte[1] { color.R }));
		stringBuilder.Append(BitConverter.ToString(new byte[1] { color.G }));
		stringBuilder.Append(BitConverter.ToString(new byte[1] { color.B }));
		return stringBuilder.ToString();
	}

	public string GetFullColorHexStr(RibbonColorPart ribbonColorPart)
	{
		Color color = GetColor(ribbonColorPart);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("#");
		stringBuilder.Append(BitConverter.ToString(new byte[1] { color.A }));
		stringBuilder.Append(BitConverter.ToString(new byte[1] { color.R }));
		stringBuilder.Append(BitConverter.ToString(new byte[1] { color.G }));
		stringBuilder.Append(BitConverter.ToString(new byte[1] { color.B }));
		return stringBuilder.ToString();
	}

	public Color GetColor(RibbonColorPart ribbonColorPart)
	{
		return ribbonColorPart switch
		{
			RibbonColorPart.OrbDropDownDarkBorder => OrbDropDownDarkBorder, 
			RibbonColorPart.OrbDropDownLightBorder => OrbDropDownLightBorder, 
			RibbonColorPart.OrbDropDownBack => OrbDropDownBack, 
			RibbonColorPart.OrbDropDownNorthA => OrbDropDownNorthA, 
			RibbonColorPart.OrbDropDownNorthB => OrbDropDownNorthB, 
			RibbonColorPart.OrbDropDownNorthC => OrbDropDownNorthC, 
			RibbonColorPart.OrbDropDownNorthD => OrbDropDownNorthD, 
			RibbonColorPart.OrbDropDownSouthC => OrbDropDownSouthC, 
			RibbonColorPart.OrbDropDownSouthD => OrbDropDownSouthD, 
			RibbonColorPart.OrbDropDownContentbg => OrbDropDownContentbg, 
			RibbonColorPart.OrbDropDownContentbglight => OrbDropDownContentbglight, 
			RibbonColorPart.OrbDropDownSeparatorlight => OrbDropDownSeparatorlight, 
			RibbonColorPart.OrbDropDownSeparatordark => OrbDropDownSeparatordark, 
			RibbonColorPart.Caption1 => Caption1, 
			RibbonColorPart.Caption2 => Caption2, 
			RibbonColorPart.Caption3 => Caption3, 
			RibbonColorPart.Caption4 => Caption4, 
			RibbonColorPart.Caption5 => Caption5, 
			RibbonColorPart.Caption6 => Caption6, 
			RibbonColorPart.Caption7 => Caption7, 
			RibbonColorPart.QuickAccessBorderDark => QuickAccessBorderDark, 
			RibbonColorPart.QuickAccessBorderLight => QuickAccessBorderLight, 
			RibbonColorPart.QuickAccessUpper => QuickAccessUpper, 
			RibbonColorPart.QuickAccessLower => QuickAccessLower, 
			RibbonColorPart.OrbOptionBorder => OrbOptionBorder, 
			RibbonColorPart.OrbOptionBackground => OrbOptionBackground, 
			RibbonColorPart.OrbOptionShine => OrbOptionShine, 
			RibbonColorPart.Arrow => Arrow, 
			RibbonColorPart.ArrowLight => ArrowLight, 
			RibbonColorPart.ArrowDisabled => ArrowDisabled, 
			RibbonColorPart.Text => Text, 
			RibbonColorPart.RibbonBackground => RibbonBackground, 
			RibbonColorPart.TabBorder => TabBorder, 
			RibbonColorPart.TabSelectedBorder => TabSelectedBorder, 
			RibbonColorPart.TabNorth => TabNorth, 
			RibbonColorPart.TabSouth => TabSouth, 
			RibbonColorPart.TabGlow => TabGlow, 
			RibbonColorPart.TabText => TabText, 
			RibbonColorPart.TabActiveText => TabActiveText, 
			RibbonColorPart.TabContentNorth => TabContentNorth, 
			RibbonColorPart.TabContentSouth => TabContentSouth, 
			RibbonColorPart.TabSelectedGlow => TabSelectedGlow, 
			RibbonColorPart.PanelDarkBorder => PanelDarkBorder, 
			RibbonColorPart.PanelLightBorder => PanelLightBorder, 
			RibbonColorPart.PanelTextBackground => PanelTextBackground, 
			RibbonColorPart.PanelTextBackgroundSelected => PanelTextBackgroundSelected, 
			RibbonColorPart.PanelText => PanelText, 
			RibbonColorPart.PanelBackgroundSelected => PanelBackgroundSelected, 
			RibbonColorPart.PanelOverflowBackground => PanelOverflowBackground, 
			RibbonColorPart.PanelOverflowBackgroundPressed => PanelOverflowBackgroundPressed, 
			RibbonColorPart.PanelOverflowBackgroundSelectedNorth => PanelOverflowBackgroundSelectedNorth, 
			RibbonColorPart.PanelOverflowBackgroundSelectedSouth => PanelOverflowBackgroundSelectedSouth, 
			RibbonColorPart.ButtonBgOut => ButtonBgOut, 
			RibbonColorPart.ButtonBgCenter => ButtonBgCenter, 
			RibbonColorPart.ButtonBorderOut => ButtonBorderOut, 
			RibbonColorPart.ButtonBorderIn => ButtonBorderIn, 
			RibbonColorPart.ButtonGlossyNorth => ButtonGlossyNorth, 
			RibbonColorPart.ButtonGlossySouth => ButtonGlossySouth, 
			RibbonColorPart.ButtonDisabledBgOut => ButtonDisabledBgOut, 
			RibbonColorPart.ButtonDisabledBgCenter => ButtonDisabledBgCenter, 
			RibbonColorPart.ButtonDisabledBorderOut => ButtonDisabledBorderOut, 
			RibbonColorPart.ButtonDisabledBorderIn => ButtonDisabledBorderIn, 
			RibbonColorPart.ButtonDisabledGlossyNorth => ButtonDisabledGlossyNorth, 
			RibbonColorPart.ButtonDisabledGlossySouth => ButtonDisabledGlossySouth, 
			RibbonColorPart.ButtonSelectedBgOut => ButtonSelectedBgOut, 
			RibbonColorPart.ButtonSelectedBgCenter => ButtonSelectedBgCenter, 
			RibbonColorPart.ButtonSelectedBorderOut => ButtonSelectedBorderOut, 
			RibbonColorPart.ButtonSelectedBorderIn => ButtonSelectedBorderIn, 
			RibbonColorPart.ButtonSelectedGlossyNorth => ButtonSelectedGlossyNorth, 
			RibbonColorPart.ButtonSelectedGlossySouth => ButtonSelectedGlossySouth, 
			RibbonColorPart.ButtonPressedBgOut => ButtonPressedBgOut, 
			RibbonColorPart.ButtonPressedBgCenter => ButtonPressedBgCenter, 
			RibbonColorPart.ButtonPressedBorderOut => ButtonPressedBorderOut, 
			RibbonColorPart.ButtonPressedBorderIn => ButtonPressedBorderIn, 
			RibbonColorPart.ButtonPressedGlossyNorth => ButtonPressedGlossyNorth, 
			RibbonColorPart.ButtonPressedGlossySouth => ButtonPressedGlossySouth, 
			RibbonColorPart.ButtonCheckedBgOut => ButtonCheckedBgOut, 
			RibbonColorPart.ButtonCheckedBgCenter => ButtonCheckedBgCenter, 
			RibbonColorPart.ButtonCheckedBorderOut => ButtonCheckedBorderOut, 
			RibbonColorPart.ButtonCheckedBorderIn => ButtonCheckedBorderIn, 
			RibbonColorPart.ButtonCheckedGlossyNorth => ButtonCheckedGlossyNorth, 
			RibbonColorPart.ButtonCheckedGlossySouth => ButtonCheckedGlossySouth, 
			RibbonColorPart.ButtonCheckedSelectedBgOut => ButtonCheckedSelectedBgOut, 
			RibbonColorPart.ButtonCheckedSelectedBgCenter => ButtonCheckedSelectedBgCenter, 
			RibbonColorPart.ButtonCheckedSelectedBorderOut => ButtonCheckedSelectedBorderOut, 
			RibbonColorPart.ButtonCheckedSelectedBorderIn => ButtonCheckedSelectedBorderIn, 
			RibbonColorPart.ButtonCheckedSelectedGlossyNorth => ButtonCheckedSelectedGlossyNorth, 
			RibbonColorPart.ButtonCheckedSelectedGlossySouth => ButtonCheckedSelectedGlossySouth, 
			RibbonColorPart.ItemGroupOuterBorder => ItemGroupOuterBorder, 
			RibbonColorPart.ItemGroupInnerBorder => ItemGroupInnerBorder, 
			RibbonColorPart.ItemGroupSeparatorLight => ItemGroupSeparatorLight, 
			RibbonColorPart.ItemGroupSeparatorDark => ItemGroupSeparatorDark, 
			RibbonColorPart.ItemGroupBgNorth => ItemGroupBgNorth, 
			RibbonColorPart.ItemGroupBgSouth => ItemGroupBgSouth, 
			RibbonColorPart.ItemGroupBgGlossy => ItemGroupBgGlossy, 
			RibbonColorPart.ButtonListBorder => ButtonListBorder, 
			RibbonColorPart.ButtonListBg => ButtonListBg, 
			RibbonColorPart.ButtonListBgSelected => ButtonListBgSelected, 
			RibbonColorPart.DropDownBg => DropDownBg, 
			RibbonColorPart.DropDownImageBg => DropDownImageBg, 
			RibbonColorPart.DropDownImageSeparator => DropDownImageSeparator, 
			RibbonColorPart.DropDownBorder => DropDownBorder, 
			RibbonColorPart.DropDownGripNorth => DropDownGripNorth, 
			RibbonColorPart.DropDownGripSouth => DropDownGripSouth, 
			RibbonColorPart.DropDownGripBorder => DropDownGripBorder, 
			RibbonColorPart.DropDownGripDark => DropDownGripDark, 
			RibbonColorPart.DropDownGripLight => DropDownGripLight, 
			RibbonColorPart.DropDownCheckedButtonGlyphBg => DropDownCheckedButtonGlyphBg, 
			RibbonColorPart.DropDownCheckedButtonGlyphBorder => DropDownCheckedButtonGlyphBorder, 
			RibbonColorPart.SeparatorLight => SeparatorLight, 
			RibbonColorPart.SeparatorDark => SeparatorDark, 
			RibbonColorPart.QATSeparatorLight => QATSeparatorLight, 
			RibbonColorPart.QATSeparatorDark => QATSeparatorDark, 
			RibbonColorPart.SeparatorBg => SeparatorBg, 
			RibbonColorPart.SeparatorLine => SeparatorLine, 
			RibbonColorPart.TextBoxUnselectedBg => TextBoxUnselectedBg, 
			RibbonColorPart.TextBoxBorder => TextBoxBorder, 
			RibbonColorPart.ToolTipContentNorth => ToolTipContentNorth, 
			RibbonColorPart.ToolTipContentSouth => ToolTipContentSouth, 
			RibbonColorPart.ToolTipDarkBorder => ToolTipDarkBorder, 
			RibbonColorPart.ToolTipLightBorder => ToolTipLightBorder, 
			RibbonColorPart.ToolStripItemTextPressed => ToolStripItemTextPressed, 
			RibbonColorPart.ToolStripItemTextSelected => ToolStripItemTextSelected, 
			RibbonColorPart.ToolStripItemText => ToolStripItemText, 
			RibbonColorPart.ButtonPressed_2013 => ButtonPressed_2013, 
			RibbonColorPart.ButtonSelected_2013 => ButtonSelected_2013, 
			RibbonColorPart.OrbButton_2013 => OrbButton_2013, 
			RibbonColorPart.OrbButtonSelected_2013 => OrbButtonSelected_2013, 
			RibbonColorPart.OrbButtonPressed_2013 => OrbButtonPressed_2013, 
			RibbonColorPart.TabText_2013 => TabText_2013, 
			RibbonColorPart.TabTextSelected_2013 => TabTextSelected_2013, 
			RibbonColorPart.PanelBorder_2013 => PanelBorder_2013, 
			RibbonColorPart.RibbonBackground_2013 => RibbonBackground_2013, 
			RibbonColorPart.TabCompleteBackground_2013 => TabCompleteBackground_2013, 
			RibbonColorPart.TabNormalBackground_2013 => TabNormalBackground_2013, 
			RibbonColorPart.TabActiveBackbround_2013 => TabActiveBackbround_2013, 
			RibbonColorPart.TabBorder_2013 => TabBorder_2013, 
			RibbonColorPart.TabCompleteBorder_2013 => TabCompleteBorder_2013, 
			RibbonColorPart.TabActiveBorder_2013 => TabActiveBorder_2013, 
			RibbonColorPart.OrbButtonText_2013 => OrbButtonText_2013, 
			RibbonColorPart.PanelText_2013 => PanelText_2013, 
			RibbonColorPart.RibbonItemText_2013 => RibbonItemText_2013, 
			RibbonColorPart.ToolTipText_2013 => ToolTipText_2013, 
			RibbonColorPart.ToolStripItemTextPressed_2013 => ToolStripItemTextPressed_2013, 
			RibbonColorPart.ToolStripItemTextSelected_2013 => ToolStripItemTextSelected_2013, 
			RibbonColorPart.ToolStripItemText_2013 => ToolStripItemText_2013, 
			_ => Color.White, 
		};
	}

	public string WriteThemeIniFile()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("[Properties]");
		stringBuilder.AppendLine("ThemeName = " + ThemeName);
		stringBuilder.AppendLine("Author = " + ThemeAuthor);
		stringBuilder.AppendLine("AuthorEmail = " + ThemeAuthorEmail);
		stringBuilder.AppendLine("AuthorWebsite = " + ThemeAuthorWebsite);
		stringBuilder.AppendLine("DateCreated = " + ThemeDateCreated);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("[ColorTable]");
		int num = Enum.GetNames(typeof(RibbonColorPart)).Length;
		for (int i = 0; i < num; i++)
		{
			stringBuilder.AppendLine(string.Concat((RibbonColorPart)i, " = ", GetFullColorHexStr((RibbonColorPart)i)));
		}
		return stringBuilder.ToString();
	}

	public void ReadThemeIniFile(string iniFileContent)
	{
		string[] array = null;
		if (iniFileContent.Contains("\r\n"))
		{
			array = iniFileContent.Split(new string[1] { "\r\n" }, StringSplitOptions.None);
		}
		else
		{
			if (!iniFileContent.Contains("\n"))
			{
				throw new ArgumentException("Unrecognized end line delimeter.");
			}
			array = iniFileContent.Split(new string[1] { "\n" }, StringSplitOptions.None);
		}
		Dictionary<string, RibbonColorPart> dictionary = new Dictionary<string, RibbonColorPart>();
		foreach (RibbonColorPart value in Enum.GetValues(typeof(RibbonColorPart)))
		{
			dictionary[value.ToString().ToLower()] = value;
		}
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			string text = array2[i].Trim();
			if (text.Length == 0)
			{
				continue;
			}
			string[] array3 = text.Split('=');
			if (array3.Length != 2)
			{
				continue;
			}
			string text2 = array3[0].Trim().ToLower();
			string text3 = array3[1].Trim();
			switch (text2)
			{
			case "author":
				ThemeAuthor = text3;
				continue;
			case "authorwebsite":
				ThemeAuthorWebsite = text3;
				continue;
			case "authoremail":
				ThemeAuthorEmail = text3;
				continue;
			case "datecreated":
				ThemeDateCreated = text3;
				continue;
			case "themename":
				ThemeName = text3;
				continue;
			}
			if (dictionary.ContainsKey(text2))
			{
				SetColor(dictionary[text2], text3);
			}
		}
	}

	public string WriteThemeXmlFile()
	{
		string text = "";
		StringWriter stringWriter;
		using XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter = new StringWriter());
		xmlTextWriter.WriteStartDocument();
		xmlTextWriter.WriteWhitespace("\r\n");
		xmlTextWriter.WriteStartElement("RibbonColorTheme");
		xmlTextWriter.WriteWhitespace("\r\n\t");
		xmlTextWriter.WriteStartElement("Properties");
		xmlTextWriter.WriteWhitespace("\r\n\t\t");
		xmlTextWriter.WriteElementString("ThemeName", ThemeName);
		xmlTextWriter.WriteWhitespace("\r\n\t\t");
		xmlTextWriter.WriteElementString("Author", ThemeAuthor);
		xmlTextWriter.WriteWhitespace("\r\n\t\t");
		xmlTextWriter.WriteElementString("AuthorEmail", ThemeAuthorEmail);
		xmlTextWriter.WriteWhitespace("\r\n\t\t");
		xmlTextWriter.WriteElementString("AuthorWebsite", ThemeAuthorWebsite);
		xmlTextWriter.WriteWhitespace("\r\n\t\t");
		xmlTextWriter.WriteElementString("DateCreated", ThemeDateCreated);
		xmlTextWriter.WriteWhitespace("\r\n\t");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteWhitespace("\r\n\t");
		xmlTextWriter.WriteStartElement("ColorTable");
		int num = Enum.GetNames(typeof(RibbonColorPart)).Length;
		for (int i = 0; i < num; i++)
		{
			xmlTextWriter.WriteWhitespace("\r\n\t\t");
			RibbonColorPart ribbonColorPart = (RibbonColorPart)i;
			xmlTextWriter.WriteElementString(ribbonColorPart.ToString(), GetFullColorHexStr((RibbonColorPart)i));
		}
		xmlTextWriter.WriteWhitespace("\r\n\t");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteWhitespace("\r\n");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteWhitespace("\r\n");
		xmlTextWriter.WriteEndDocument();
		return stringWriter.ToString();
	}

	public void ReadThemeXmlFile(string xmlFileContent)
	{
		Dictionary<string, RibbonColorPart> dictionary = new Dictionary<string, RibbonColorPart>();
		foreach (RibbonColorPart value in Enum.GetValues(typeof(RibbonColorPart)))
		{
			dictionary[value.ToString().ToLower()] = value;
		}
		using XmlTextReader xmlTextReader = new XmlTextReader(new StringReader(xmlFileContent));
		while (xmlTextReader.Read())
		{
			switch (xmlTextReader.Name)
			{
			case "ThemeName":
				ThemeName = xmlTextReader.ReadString();
				continue;
			case "Author":
				ThemeAuthor = xmlTextReader.ReadString();
				continue;
			case "AuthorEmail":
				ThemeAuthorEmail = xmlTextReader.ReadString();
				continue;
			case "AuthorWebsite":
				ThemeAuthorWebsite = xmlTextReader.ReadString();
				continue;
			case "DateCreated":
				ThemeDateCreated = xmlTextReader.ReadString();
				continue;
			}
			if (dictionary.ContainsKey(xmlTextReader.Name.ToLower()))
			{
				SetColor(dictionary[xmlTextReader.Name.ToLower()], xmlTextReader.ReadString());
			}
		}
	}
}
