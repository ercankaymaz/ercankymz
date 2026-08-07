// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlTheme
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns21;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class70))]
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

  public buControlTheme()
  {
  }

  public buControlTheme(buControlTheme theme) => this.Type = theme.Type;

  public static void UpdateTheme(ThemeType type, ref buControlThemeVars Vars)
  {
    if (type == ThemeType.Standart)
      buControlTheme.ThemeStandart();
    if (type == ThemeType.Black)
      buControlTheme.ThemeBlack();
    Vars.Caption = new buControlCaption(buControlTheme.Caption);
    Vars.DisplayCheckTick = new buControlDisplay(buControlTheme.DisplayCheckTick);
    Vars.Combo = new buControlCombo(buControlTheme.Combo);
    Vars.Display = new buControlDisplay(buControlTheme.Display);
    Vars.DisplayText = new buControlDisplay(buControlTheme.DisplayText);
    Vars.DisplayButtonDown = new buControlDisplay(buControlTheme.DisplayButtonDown);
    Vars.DisplayButtonNormal = new buControlDisplay(buControlTheme.DisplayButtonNormal);
    Vars.DisplayButtonOver = new buControlDisplay(buControlTheme.DisplayButtonOver);
    Vars.DisplayButton2Down = new buControlDisplay(buControlTheme.DisplayButton2Down);
    Vars.DisplayButton2Normal = new buControlDisplay(buControlTheme.DisplayButton2Normal);
    Vars.DisplayButton2Over = new buControlDisplay(buControlTheme.DisplayButton2Over);
    Vars.DisplayGroundButtom = new buControlDisplay(buControlTheme.DisplayGroundButtom);
    Vars.DisplayGroundTop = new buControlDisplay(buControlTheme.DisplayGroundTop);
    Vars.DisplayGroupTitle = new buControlDisplay(buControlTheme.DisplayGroupTitle);
    Vars.Geometry = new buControlGeometry(buControlTheme.Geometry);
    Vars.Ground = new buControlGround(buControlTheme.Ground);
    Vars.Status.Alarm = new buControlDisplay(buControlTheme.Status.Alarm);
    Vars.Status.Warning = new buControlDisplay(buControlTheme.Status.Warning);
    Vars.Status.Information = new buControlDisplay(buControlTheme.Status.Information);
    Vars.Status.Status = new buControlDisplay(buControlTheme.Status.Status);
    Vars.DisplayDoneValue = new buControlDisplay(buControlTheme.DisplayDoneValue);
    Vars.DisplayDrawer = new buControlDisplay(buControlTheme.DisplayDrawer);
    Vars.DisplayValue = new buControlDisplay(buControlTheme.DisplayValue);
    Vars.Tab.Header = new buControlDisplay(buControlTheme.Tab.Header);
    Vars.Tab.HeaderSelected = new buControlDisplay(buControlTheme.Tab.HeaderSelected);
    Vars.Tab.TabPageColor = buControlTheme.Tab.TabPageColor;
    Vars.ProgressCircular.CoreBorderColor = buControlTheme.ProgressCircular.CoreBorderColor;
    Vars.ProgressCircular.CoreColor1 = buControlTheme.ProgressCircular.CoreColor1;
    Vars.ProgressCircular.CoreColor2 = buControlTheme.ProgressCircular.CoreColor2;
    Vars.ProgressCircular.InnerBorderSpace = buControlTheme.ProgressCircular.InnerBorderSpace;
    Vars.ProgressCircular.ProgressColor1 = buControlTheme.ProgressCircular.ProgressColor1;
    Vars.ProgressCircular.ProgressColor2 = buControlTheme.ProgressCircular.ProgressColor2;
    Vars.ProgressCircular.ProgressShape = buControlTheme.ProgressCircular.ProgressShape;
    Vars.ProgressLineer.DoneDisplay = new buControlDisplay(buControlTheme.ProgressLineer.DoneDisplay);
  }

  public static void ThemeBlack()
  {
    buControlTheme.Geometry.ArcDiameter = 8;
    buControlTheme.Geometry.ShapeMode = ShapeType.Rectangle;
    buControlTheme.Geometry.Space = 0.0f;
    buControlTheme.Display.BackColor = Color.Black;
    buControlTheme.Display.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.Display.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.Display.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.Display.Border.Color = Color.Gray;
    buControlTheme.DisplayText.BackColor = Color.Gray;
    buControlTheme.DisplayText.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.DisplayText.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.DisplayText.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.DisplayText.Border.Color = Color.Gray;
    buControlTheme.DisplayButtonNormal.BackColor = Color.DarkGray;
    buControlTheme.DisplayButtonNormal.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.DisplayButtonNormal.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.DisplayButtonNormal.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.DisplayButtonNormal.Border.Color = Color.DimGray;
    buControlTheme.DisplayButtonOver.BackColor = Color.DimGray;
    buControlTheme.DisplayButtonOver.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.DisplayButtonOver.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.DisplayButtonOver.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.DisplayButtonOver.Border.Color = Color.DimGray;
    buControlTheme.DisplayButtonDown.BackColor = Color.DimGray;
    buControlTheme.DisplayButtonDown.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.DisplayButtonDown.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.DisplayButtonDown.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.DisplayButtonDown.Border.Color = Color.DimGray;
    buControlTheme.DisplayButton2Normal.BackColor = Color.DarkGray;
    buControlTheme.DisplayButton2Normal.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.DisplayButton2Normal.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.DisplayButton2Normal.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.DisplayButton2Normal.Border.Color = Color.DimGray;
    buControlTheme.DisplayButton2Over.BackColor = Color.DimGray;
    buControlTheme.DisplayButton2Over.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.DisplayButton2Over.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.DisplayButton2Over.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.DisplayButton2Over.Border.Color = Color.DimGray;
    buControlTheme.DisplayButton2Down.BackColor = Color.DimGray;
    buControlTheme.DisplayButton2Down.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.DisplayButton2Down.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.DisplayButton2Down.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.DisplayButton2Down.Border.Color = Color.DimGray;
    buControlTheme.DisplayCheckTick.BackColor = Color.Black;
    buControlTheme.DisplayCheckTick.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.DisplayCheckTick.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.DisplayCheckTick.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.DisplayCheckTick.Border.Color = Color.Gray;
    buControlTheme.Caption.Display.BackColor = Color.DimGray;
    buControlTheme.Caption.Display.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.Caption.Display.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.Caption.Display.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.Caption.Display.Border.Color = Color.Gray;
    buControlTheme.Combo.ArrowColor = Color.WhiteSmoke;
    buControlTheme.Combo.ArrowLineColor = Color.DimGray;
    buControlTheme.Combo.DropBoxColor = Color.Black;
    buControlTheme.Combo.ValueColor = Color.Black;
    buControlTheme.DisplayGroundButtom.BackColor = Color.DimGray;
    buControlTheme.DisplayGroundButtom.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.DisplayGroundButtom.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.DisplayGroundButtom.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.DisplayGroundButtom.Border.Color = Color.DimGray;
    buControlTheme.DisplayGroundTop.BackColor = Color.DimGray;
    buControlTheme.DisplayGroundTop.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.DisplayGroundTop.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.DisplayGroundTop.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.DisplayGroundTop.Border.Color = Color.DimGray;
    buControlTheme.DisplayDoneValue.BackColor = Color.DarkOrange;
    buControlTheme.DisplayDoneValue.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.DisplayDoneValue.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.DisplayDoneValue.Fonts.ForeColor = Color.Black;
    buControlTheme.DisplayDoneValue.Border.Color = Color.DimGray;
    buControlTheme.DisplayValue.BackColor = Color.DimGray;
    buControlTheme.DisplayValue.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.DisplayValue.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.DisplayValue.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.DisplayValue.Border.Color = Color.DimGray;
    buControlTheme.DisplayDrawer.BackColor = Color.DimGray;
    buControlTheme.DisplayDrawer.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.DisplayDrawer.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.DisplayDrawer.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.DisplayDrawer.Border.Color = Color.DimGray;
    buControlTheme.Ground.BottomHeight = 0;
    buControlTheme.Ground.TopHeight = 25;
    buControlTheme.DisplayGroupTitle.BackColor = Color.DimGray;
    buControlTheme.DisplayGroupTitle.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.DisplayGroupTitle.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.DisplayGroupTitle.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.DisplayGroupTitle.Border.Color = Color.DimGray;
    buControlTheme.Status.Alarm.BackColor = Color.DarkRed;
    buControlTheme.Status.Alarm.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.Status.Alarm.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.Status.Alarm.Fonts.ForeColor = Color.Black;
    buControlTheme.Status.Alarm.Border.Color = Color.DimGray;
    buControlTheme.Status.Warning.BackColor = Color.Orange;
    buControlTheme.Status.Warning.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.Status.Warning.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.Status.Warning.Fonts.ForeColor = Color.Black;
    buControlTheme.Status.Warning.Border.Color = Color.DimGray;
    buControlTheme.Status.Information.BackColor = Color.Navy;
    buControlTheme.Status.Information.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.Status.Information.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.Status.Information.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.Status.Information.Border.Color = Color.DimGray;
    buControlTheme.Status.Status.BackColor = Color.DimGray;
    buControlTheme.Status.Status.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.Status.Status.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.Status.Status.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.Status.Status.Border.Color = Color.DimGray;
    buControlTheme.Tab.Header.BackColor = Color.DimGray;
    buControlTheme.Tab.Header.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.Tab.Header.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.Tab.Header.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.Tab.Header.Border.Color = Color.DimGray;
    buControlTheme.Tab.HeaderSelected.BackColor = Color.DarkOrange;
    buControlTheme.Tab.HeaderSelected.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.Tab.HeaderSelected.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.Tab.HeaderSelected.Fonts.ForeColor = Color.WhiteSmoke;
    buControlTheme.Tab.HeaderSelected.Border.Color = Color.DimGray;
    buControlTheme.Tab.TabPageColor = Color.Black;
    buControlTheme.ProgressLineer.DoneDisplay.BackColor = Color.DarkOrange;
    buControlTheme.ProgressLineer.DoneDisplay.Fonts.Font = new Font("Times New Roman", 12f);
    buControlTheme.ProgressLineer.DoneDisplay.Fonts.Alignment = ContentAlignment.MiddleCenter;
    buControlTheme.ProgressLineer.DoneDisplay.Fonts.ForeColor = Color.Black;
    buControlTheme.ProgressLineer.DoneDisplay.Border.Color = Color.Black;
    buControlTheme.ProgressCircular.CoreBorderColor = Color.Black;
    buControlTheme.ProgressCircular.CoreColor1 = Color.DimGray;
    buControlTheme.ProgressCircular.CoreColor2 = Color.DimGray;
    buControlTheme.ProgressCircular.InnerBorderSpace = 6;
    buControlTheme.ProgressCircular.ProgressColor1 = Color.DarkOrange;
    buControlTheme.ProgressCircular.ProgressColor2 = Color.DarkOrange;
    buControlTheme.ProgressCircular.ProgressShape = CircularProgressShape.Flat;
  }

  public static void ThemeStandart()
  {
    buControlTheme.Geometry = new buControlGeometry();
    buControlTheme.Display = new buControlDisplay();
    buControlTheme.DisplayText = new buControlDisplay();
    buControlTheme.DisplayText.BackColor = Color.WhiteSmoke;
    buControlTheme.DisplayButtonOver = new buControlDisplay();
    buControlTheme.DisplayButtonDown = new buControlDisplay();
    buControlTheme.DisplayButtonNormal = new buControlDisplay();
    buControlTheme.DisplayButton2Over = new buControlDisplay();
    buControlTheme.DisplayButton2Down = new buControlDisplay();
    buControlTheme.DisplayButton2Normal = new buControlDisplay();
    buControlTheme.DisplayCheckTick = new buControlDisplay();
    buControlTheme.DisplayCheckTick.BackColor = Color.WhiteSmoke;
    buControlTheme.Caption = new buControlCaption();
    buControlTheme.Combo = new buControlCombo();
    buControlTheme.DisplayGroundButtom = new buControlDisplay();
    buControlTheme.DisplayGroundTop = new buControlDisplay();
    buControlTheme.DisplayGroundTop.BackColor = Color.Gray;
    buControlTheme.DisplayGroundButtom.BackColor = Color.Gray;
    buControlTheme.Ground = new buControlGround();
    buControlTheme.DisplayGroupTitle = new buControlDisplay();
    buControlTheme.Status.Alarm = new buControlDisplay();
    buControlTheme.Status.Alarm.BackColor = Color.Red;
    buControlTheme.Status.Warning = new buControlDisplay();
    buControlTheme.Status.Warning.BackColor = Color.Gold;
    buControlTheme.Status.Information = new buControlDisplay();
    buControlTheme.Status.Information.BackColor = Color.Blue;
    buControlTheme.Status.Status = new buControlDisplay();
    buControlTheme.Status.Status.BackColor = Color.LightGray;
    buControlTheme.Tab.Header = new buControlDisplay();
    buControlTheme.Tab.HeaderSelected = new buControlDisplay();
    buControlTheme.Tab.HeaderSelected.BackColor = Color.DarkGray;
    buControlTheme.Tab.TabPageColor = Color.Gray;
    buControlTheme.ProgressLineer.DoneDisplay = new buControlDisplay();
    buControlTheme.ProgressCircular = new buControlProgressBarCircular();
    buControlTheme.DisplayValue = new buControlDisplay();
    buControlTheme.DisplayDrawer = new buControlDisplay();
    buControlTheme.DisplayDoneValue = new buControlDisplay();
    buControlTheme.DisplayDoneValue.BackColor = Color.Green;
  }

  [DefaultValue(ThemeType.Standart)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public ThemeType Type
  {
    get => this.themeType_0;
    set
    {
      this.themeType_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  public override string ToString() => this.Type.ToString();
}
