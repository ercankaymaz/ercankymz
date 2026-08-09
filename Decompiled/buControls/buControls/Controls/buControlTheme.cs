using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns41;

namespace buControls.Controls;

[TypeConverter(typeof(Class107))]
public class buControlTheme
{
	public Control Parent;

	public static buControlGeometry Geometry = new buControlGeometry();

	public static buControlDisplay Display = new buControlDisplay();

	public static buControlDisplay DisplayText = new buControlDisplay();

	public static buControlDisplay DisplayButtonOver = new buControlDisplay();

	public static buControlDisplay DisplayButtonDown = new buControlDisplay();

	public static buControlDisplay DisplayButtonNormal = new buControlDisplay();

	public static buControlDisplay DisplayButton2Over = new buControlDisplay();

	public static buControlDisplay DisplayButton2Normal = new buControlDisplay();

	public static buControlDisplay DisplayButton2Down = new buControlDisplay();

	public static buControlDisplay DisplayGroundTop = new buControlDisplay();

	public static buControlDisplay DisplayGroundButtom = new buControlDisplay();

	public static buControlDisplay DisplayGroupTitle = new buControlDisplay();

	public static buControlDisplay DisplayDrawer = new buControlDisplay();

	public static buControlDisplay DisplayValue = new buControlDisplay();

	public static buControlDisplay DisplayDoneValue = new buControlDisplay();

	public static buControlDisplay DisplayCheckTick = new buControlDisplay();

	public static buControlCombo Combo = new buControlCombo();

	public static buControlCaption Caption = new buControlCaption();

	public static buControlGround Ground = new buControlGround();

	public static buControlStatus Status = new buControlStatus();

	public static buControlTab Tab = new buControlTab();

	public static buControlProgressBarCircular ProgressCircular = new buControlProgressBarCircular();

	public static buControlProgressBarLineer ProgressLineer = new buControlProgressBarLineer();

	private ThemeType themeType_0 = ThemeType.Standart;

	[DefaultValue(ThemeType.Standart)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public ThemeType Type
	{
		get
		{
			return themeType_0;
		}
		set
		{
			themeType_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	public buControlTheme()
	{
	}

	public buControlTheme(buControlTheme theme)
	{
		Type = theme.Type;
	}

	public static void UpdateTheme(ThemeType type, ref buControlThemeVars Vars)
	{
		if (type == ThemeType.Standart)
		{
			ThemeStandart();
		}
		if (type == ThemeType.Black)
		{
			ThemeBlack();
		}
		Vars.Caption = new buControlCaption(Caption);
		Vars.DisplayCheckTick = new buControlDisplay(DisplayCheckTick);
		Vars.Combo = new buControlCombo(Combo);
		Vars.Display = new buControlDisplay(Display);
		Vars.DisplayText = new buControlDisplay(DisplayText);
		Vars.DisplayButtonDown = new buControlDisplay(DisplayButtonDown);
		Vars.DisplayButtonNormal = new buControlDisplay(DisplayButtonNormal);
		Vars.DisplayButtonOver = new buControlDisplay(DisplayButtonOver);
		Vars.DisplayButton2Down = new buControlDisplay(DisplayButton2Down);
		Vars.DisplayButton2Normal = new buControlDisplay(DisplayButton2Normal);
		Vars.DisplayButton2Over = new buControlDisplay(DisplayButton2Over);
		Vars.DisplayGroundButtom = new buControlDisplay(DisplayGroundButtom);
		Vars.DisplayGroundTop = new buControlDisplay(DisplayGroundTop);
		Vars.DisplayGroupTitle = new buControlDisplay(DisplayGroupTitle);
		Vars.Geometry = new buControlGeometry(Geometry);
		Vars.Ground = new buControlGround(Ground);
		Vars.Status.Alarm = new buControlDisplay(Status.Alarm);
		Vars.Status.Warning = new buControlDisplay(Status.Warning);
		Vars.Status.Information = new buControlDisplay(Status.Information);
		Vars.Status.Status = new buControlDisplay(Status.Status);
		Vars.DisplayDoneValue = new buControlDisplay(DisplayDoneValue);
		Vars.DisplayDrawer = new buControlDisplay(DisplayDrawer);
		Vars.DisplayValue = new buControlDisplay(DisplayValue);
		Vars.Tab.Header = new buControlDisplay(Tab.Header);
		Vars.Tab.HeaderSelected = new buControlDisplay(Tab.HeaderSelected);
		Vars.Tab.TabPageColor = Tab.TabPageColor;
		Vars.ProgressCircular.CoreBorderColor = ProgressCircular.CoreBorderColor;
		Vars.ProgressCircular.CoreColor1 = ProgressCircular.CoreColor1;
		Vars.ProgressCircular.CoreColor2 = ProgressCircular.CoreColor2;
		Vars.ProgressCircular.InnerBorderSpace = ProgressCircular.InnerBorderSpace;
		Vars.ProgressCircular.ProgressColor1 = ProgressCircular.ProgressColor1;
		Vars.ProgressCircular.ProgressColor2 = ProgressCircular.ProgressColor2;
		Vars.ProgressCircular.ProgressShape = ProgressCircular.ProgressShape;
		Vars.ProgressLineer.DoneDisplay = new buControlDisplay(ProgressLineer.DoneDisplay);
	}

	public static void ThemeBlack()
	{
		Geometry.ArcDiameter = 8;
		Geometry.ShapeMode = ShapeType.Rectangle;
		Geometry.Space = 0f;
		Display.BackColor = Color.Black;
		Display.Fonts.Font = new Font("Times New Roman", 12f);
		Display.Fonts.Alignment = ContentAlignment.MiddleCenter;
		Display.Fonts.ForeColor = Color.WhiteSmoke;
		Display.Border.Color = Color.Gray;
		DisplayText.BackColor = Color.Gray;
		DisplayText.Fonts.Font = new Font("Times New Roman", 12f);
		DisplayText.Fonts.Alignment = ContentAlignment.MiddleCenter;
		DisplayText.Fonts.ForeColor = Color.WhiteSmoke;
		DisplayText.Border.Color = Color.Gray;
		DisplayButtonNormal.BackColor = Color.DarkGray;
		DisplayButtonNormal.Fonts.Font = new Font("Times New Roman", 12f);
		DisplayButtonNormal.Fonts.Alignment = ContentAlignment.MiddleCenter;
		DisplayButtonNormal.Fonts.ForeColor = Color.WhiteSmoke;
		DisplayButtonNormal.Border.Color = Color.DimGray;
		DisplayButtonOver.BackColor = Color.DimGray;
		DisplayButtonOver.Fonts.Font = new Font("Times New Roman", 12f);
		DisplayButtonOver.Fonts.Alignment = ContentAlignment.MiddleCenter;
		DisplayButtonOver.Fonts.ForeColor = Color.WhiteSmoke;
		DisplayButtonOver.Border.Color = Color.DimGray;
		DisplayButtonDown.BackColor = Color.DimGray;
		DisplayButtonDown.Fonts.Font = new Font("Times New Roman", 12f);
		DisplayButtonDown.Fonts.Alignment = ContentAlignment.MiddleCenter;
		DisplayButtonDown.Fonts.ForeColor = Color.WhiteSmoke;
		DisplayButtonDown.Border.Color = Color.DimGray;
		DisplayButton2Normal.BackColor = Color.DarkGray;
		DisplayButton2Normal.Fonts.Font = new Font("Times New Roman", 12f);
		DisplayButton2Normal.Fonts.Alignment = ContentAlignment.MiddleCenter;
		DisplayButton2Normal.Fonts.ForeColor = Color.WhiteSmoke;
		DisplayButton2Normal.Border.Color = Color.DimGray;
		DisplayButton2Over.BackColor = Color.DimGray;
		DisplayButton2Over.Fonts.Font = new Font("Times New Roman", 12f);
		DisplayButton2Over.Fonts.Alignment = ContentAlignment.MiddleCenter;
		DisplayButton2Over.Fonts.ForeColor = Color.WhiteSmoke;
		DisplayButton2Over.Border.Color = Color.DimGray;
		DisplayButton2Down.BackColor = Color.DimGray;
		DisplayButton2Down.Fonts.Font = new Font("Times New Roman", 12f);
		DisplayButton2Down.Fonts.Alignment = ContentAlignment.MiddleCenter;
		DisplayButton2Down.Fonts.ForeColor = Color.WhiteSmoke;
		DisplayButton2Down.Border.Color = Color.DimGray;
		DisplayCheckTick.BackColor = Color.Black;
		DisplayCheckTick.Fonts.Font = new Font("Times New Roman", 12f);
		DisplayCheckTick.Fonts.Alignment = ContentAlignment.MiddleCenter;
		DisplayCheckTick.Fonts.ForeColor = Color.WhiteSmoke;
		DisplayCheckTick.Border.Color = Color.Gray;
		Caption.Display.BackColor = Color.DimGray;
		Caption.Display.Fonts.Font = new Font("Times New Roman", 12f);
		Caption.Display.Fonts.Alignment = ContentAlignment.MiddleCenter;
		Caption.Display.Fonts.ForeColor = Color.WhiteSmoke;
		Caption.Display.Border.Color = Color.Gray;
		Combo.ArrowColor = Color.WhiteSmoke;
		Combo.ArrowLineColor = Color.DimGray;
		Combo.DropBoxColor = Color.Black;
		Combo.ValueColor = Color.Black;
		DisplayGroundButtom.BackColor = Color.DimGray;
		DisplayGroundButtom.Fonts.Font = new Font("Times New Roman", 12f);
		DisplayGroundButtom.Fonts.Alignment = ContentAlignment.MiddleCenter;
		DisplayGroundButtom.Fonts.ForeColor = Color.WhiteSmoke;
		DisplayGroundButtom.Border.Color = Color.DimGray;
		DisplayGroundTop.BackColor = Color.DimGray;
		DisplayGroundTop.Fonts.Font = new Font("Times New Roman", 12f);
		DisplayGroundTop.Fonts.Alignment = ContentAlignment.MiddleCenter;
		DisplayGroundTop.Fonts.ForeColor = Color.WhiteSmoke;
		DisplayGroundTop.Border.Color = Color.DimGray;
		DisplayDoneValue.BackColor = Color.DarkOrange;
		DisplayDoneValue.Fonts.Font = new Font("Times New Roman", 12f);
		DisplayDoneValue.Fonts.Alignment = ContentAlignment.MiddleCenter;
		DisplayDoneValue.Fonts.ForeColor = Color.Black;
		DisplayDoneValue.Border.Color = Color.DimGray;
		DisplayValue.BackColor = Color.DimGray;
		DisplayValue.Fonts.Font = new Font("Times New Roman", 12f);
		DisplayValue.Fonts.Alignment = ContentAlignment.MiddleCenter;
		DisplayValue.Fonts.ForeColor = Color.WhiteSmoke;
		DisplayValue.Border.Color = Color.DimGray;
		DisplayDrawer.BackColor = Color.DimGray;
		DisplayDrawer.Fonts.Font = new Font("Times New Roman", 12f);
		DisplayDrawer.Fonts.Alignment = ContentAlignment.MiddleCenter;
		DisplayDrawer.Fonts.ForeColor = Color.WhiteSmoke;
		DisplayDrawer.Border.Color = Color.DimGray;
		Ground.BottomHeight = 0;
		Ground.TopHeight = 25;
		DisplayGroupTitle.BackColor = Color.DimGray;
		DisplayGroupTitle.Fonts.Font = new Font("Times New Roman", 12f);
		DisplayGroupTitle.Fonts.Alignment = ContentAlignment.MiddleCenter;
		DisplayGroupTitle.Fonts.ForeColor = Color.WhiteSmoke;
		DisplayGroupTitle.Border.Color = Color.DimGray;
		Status.Alarm.BackColor = Color.DarkRed;
		Status.Alarm.Fonts.Font = new Font("Times New Roman", 12f);
		Status.Alarm.Fonts.Alignment = ContentAlignment.MiddleCenter;
		Status.Alarm.Fonts.ForeColor = Color.Black;
		Status.Alarm.Border.Color = Color.DimGray;
		Status.Warning.BackColor = Color.Orange;
		Status.Warning.Fonts.Font = new Font("Times New Roman", 12f);
		Status.Warning.Fonts.Alignment = ContentAlignment.MiddleCenter;
		Status.Warning.Fonts.ForeColor = Color.Black;
		Status.Warning.Border.Color = Color.DimGray;
		Status.Information.BackColor = Color.Navy;
		Status.Information.Fonts.Font = new Font("Times New Roman", 12f);
		Status.Information.Fonts.Alignment = ContentAlignment.MiddleCenter;
		Status.Information.Fonts.ForeColor = Color.WhiteSmoke;
		Status.Information.Border.Color = Color.DimGray;
		Status.Status.BackColor = Color.DimGray;
		Status.Status.Fonts.Font = new Font("Times New Roman", 12f);
		Status.Status.Fonts.Alignment = ContentAlignment.MiddleCenter;
		Status.Status.Fonts.ForeColor = Color.WhiteSmoke;
		Status.Status.Border.Color = Color.DimGray;
		Tab.Header.BackColor = Color.DimGray;
		Tab.Header.Fonts.Font = new Font("Times New Roman", 12f);
		Tab.Header.Fonts.Alignment = ContentAlignment.MiddleCenter;
		Tab.Header.Fonts.ForeColor = Color.WhiteSmoke;
		Tab.Header.Border.Color = Color.DimGray;
		Tab.HeaderSelected.BackColor = Color.DarkOrange;
		Tab.HeaderSelected.Fonts.Font = new Font("Times New Roman", 12f);
		Tab.HeaderSelected.Fonts.Alignment = ContentAlignment.MiddleCenter;
		Tab.HeaderSelected.Fonts.ForeColor = Color.WhiteSmoke;
		Tab.HeaderSelected.Border.Color = Color.DimGray;
		Tab.TabPageColor = Color.Black;
		ProgressLineer.DoneDisplay.BackColor = Color.DarkOrange;
		ProgressLineer.DoneDisplay.Fonts.Font = new Font("Times New Roman", 12f);
		ProgressLineer.DoneDisplay.Fonts.Alignment = ContentAlignment.MiddleCenter;
		ProgressLineer.DoneDisplay.Fonts.ForeColor = Color.Black;
		ProgressLineer.DoneDisplay.Border.Color = Color.Black;
		ProgressCircular.CoreBorderColor = Color.Black;
		ProgressCircular.CoreColor1 = Color.DimGray;
		ProgressCircular.CoreColor2 = Color.DimGray;
		ProgressCircular.InnerBorderSpace = 6;
		ProgressCircular.ProgressColor1 = Color.DarkOrange;
		ProgressCircular.ProgressColor2 = Color.DarkOrange;
		ProgressCircular.ProgressShape = CircularProgressShape.Flat;
	}

	public static void ThemeStandart()
	{
		Geometry = new buControlGeometry();
		Display = new buControlDisplay();
		DisplayText = new buControlDisplay();
		DisplayText.BackColor = Color.WhiteSmoke;
		DisplayButtonOver = new buControlDisplay();
		DisplayButtonDown = new buControlDisplay();
		DisplayButtonNormal = new buControlDisplay();
		DisplayButton2Over = new buControlDisplay();
		DisplayButton2Down = new buControlDisplay();
		DisplayButton2Normal = new buControlDisplay();
		DisplayCheckTick = new buControlDisplay();
		DisplayCheckTick.BackColor = Color.WhiteSmoke;
		Caption = new buControlCaption();
		Combo = new buControlCombo();
		DisplayGroundButtom = new buControlDisplay();
		DisplayGroundTop = new buControlDisplay();
		DisplayGroundTop.BackColor = Color.Gray;
		DisplayGroundButtom.BackColor = Color.Gray;
		Ground = new buControlGround();
		DisplayGroupTitle = new buControlDisplay();
		Status.Alarm = new buControlDisplay();
		Status.Alarm.BackColor = Color.Red;
		Status.Warning = new buControlDisplay();
		Status.Warning.BackColor = Color.Gold;
		Status.Information = new buControlDisplay();
		Status.Information.BackColor = Color.Blue;
		Status.Status = new buControlDisplay();
		Status.Status.BackColor = Color.LightGray;
		Tab.Header = new buControlDisplay();
		Tab.HeaderSelected = new buControlDisplay();
		Tab.HeaderSelected.BackColor = Color.DarkGray;
		Tab.TabPageColor = Color.Gray;
		ProgressLineer.DoneDisplay = new buControlDisplay();
		ProgressCircular = new buControlProgressBarCircular();
		DisplayValue = new buControlDisplay();
		DisplayDrawer = new buControlDisplay();
		DisplayDoneValue = new buControlDisplay();
		DisplayDoneValue.BackColor = Color.Green;
	}

	public override string ToString()
	{
		return Type.ToString();
	}
}
