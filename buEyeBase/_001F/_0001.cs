// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.Forms.Marble;
using buEyeBaseVer5.Forms.Profile;
using buEyeBaseVer5.Forms.RollerBend;
using buEyeBaseVer5.Forms.Shape;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace \u001F;

internal class \u0001
{
  public const MarbleMachineType BridgeCut4Axis = ; // Unable to render the field
  public const MarbleMachineType BridgeCut3Axis = ; // Unable to render the field
  public const MarbleMachineType SideCut5Axis = ; // Unable to render the field

  static void \u0001([In] F_MarbleProfileCutCad obj0)
  {
    string callMethod = "Profile Cut LoadLanguage";
    try
    {
      ((F_MarbleBaseMatClear) obj0).\u0001.Text = buLangTranslate.preDef.Profile;
      ((F_MarbleBaseMatClear) obj0).spn_baseheight.Caption.Caption = buLangTranslate.preDef.BaseHeight;
      ((F_MarbleBaseMatClear) obj0).spn_length.Caption.Caption = buLangTranslate.preDef.Length;
      ((F_MarbleBaseMatClear) obj0).spn_ang.Caption.Caption = buLangTranslate.preDef.Angle;
      ((F_MarbleBaseMatClear) obj0).chk_finish.Text = $"{buLangTranslate.preDef.Finish} {buLangTranslate.preDef.Operation}";
      ((F_MarbleBaseMatClear) obj0).chk_rough.Text = $"{buLangTranslate.preDef.Rough} {buLangTranslate.preDef.Operation}";
      ((F_MarbleBaseMatClear) obj0).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleBaseMatClear) obj0).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_MarbleBaseMatClear) obj0).btn_settings.Text = buLangTranslate.preDef.Setting;
      ((F_MarbleMaterialSize) obj0).chk_twistenable.Text = $"{buLangTranslate.preDef.Twist} {buLangTranslate.preDef.Enable}";
      ((F_MarbleMaterialSize) obj0).spn_twistSA.Caption.Caption = $"{buLangTranslate.preDef.Twist} {buLangTranslate.preDef.StartAngle}";
      ((F_MarbleBaseMatClear) obj0).spn_twistEA.Caption.Caption = $"{buLangTranslate.preDef.Twist} {buLangTranslate.preDef.EndAngle}";
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  static void \u0001([In] F_RollerRectangle obj0)
  {
    string callMethod = "LoadLanguage";
    try
    {
      ((F_Settnigs) obj0).buGround1.Text = buLangTranslate.preDef.Rectangle;
      ((F_Settnigs) obj0).spn_width.Caption.Caption = buLangTranslate.preDef.Width;
      ((F_Settnigs) obj0).spn_hegiht.Caption.Caption = buLangTranslate.preDef.Height;
      ((F_Settnigs) obj0).spn_radius.Caption.Caption = buLangTranslate.preDef.Radius;
      ((F_Settnigs) obj0).spn_length.Caption.Caption = buLangTranslate.preDef.Length;
      ((F_Settnigs) obj0).spn_thickness.Caption.Caption = buLangTranslate.preDef.Thickness;
      ((F_Settnigs) obj0).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_Settnigs) obj0).btn_cancel.Text = buLangTranslate.preDef.Cancel;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  static void \u0001([In] EventArgs obj0, [In] object obj1, [In] F_ProfilingList obj2)
  {
    Control control = new Control();
  }

  internal static bool IsWebApplication
  {
    [SpecialName] get
    {
      try
      {
        switch (Process.GetCurrentProcess().MainModule.ModuleName.ToLower())
        {
          case "w3wp.exe":
            return true;
          case "aspnet_wp.exe":
            return true;
        }
      }
      catch
      {
      }
      return false;
    }
  }

  internal struct \u0001
  {
    public const MarbleMachineType SideCut4Axis = ; // Unable to render the field
    public const MarbleMachineType SideCut3Axis = ; // Unable to render the field
    public const MarbleMachineType Milling3Axis = ; // Unable to render the field
    public const MarbleMachineType Milling5Axis = ; // Unable to render the field

    static object[] \u0001(
      [In] double obj0,
      [In] bool obj1,
      [In] string obj2,
      [In] bool obj3,
      [In] int obj4,
      [In] double obj5,
      [In] Image obj6,
      [In] string obj7,
      [In] int obj8,
      [In] string obj9,
      [In] string obj10,
      [In] int obj11,
      [In] Enum obj12,
      [In] int obj13,
      [In] int obj14,
      [In] string obj15,
      [In] F_NestSheetPartList obj16)
    {
      return new object[16 /*0x10*/]
      {
        (object) obj14,
        (object) obj1,
        (object) obj7,
        (object) obj6,
        (object) Math.Round(obj5, 3),
        (object) Math.Round(obj0, 3),
        (object) obj4,
        (object) obj8,
        (object) obj11,
        (object) obj13,
        (object) obj12,
        (object) obj3,
        (object) obj2,
        (object) obj9,
        (object) obj15,
        (object) obj10
      };
    }

    static void \u0001([In] F_MarbleEditBaseHAndXY obj0)
    {
      string callMethod = "F_MarbleEditBaseHAndXY LoadLanguage";
      try
      {
        ((F_MarbleToolSpindleAndMagazine) obj0).\u0001.Text = buLangTranslate.preDef.Edit;
        ((F_MarbleToolSpindleAndMagazine) obj0).spn_baseheight.Caption.Caption = buLangTranslate.preDef.BaseHeight;
        ((F_MarbleToolSpindleAndMagazine) obj0).spn_scalewidth.Caption.Caption = $"{buLangTranslate.preDef.Scale} {buLangTranslate.preDef.Width}";
        ((F_MarbleToolSpindleAndMagazine) obj0).spn_scaleheight.Caption.Caption = $"{buLangTranslate.preDef.Scale} {buLangTranslate.preDef.Height}";
        ((F_MarbleToolSpindleAndMagazine) obj0).chk_keepratio.Text = buLangTranslate.preDef.KeepRatio;
        ((F_MarbleToolSpindleAndMagazine) obj0).btn_ok.Text = buLangTranslate.preDef.Ok;
        ((F_MarbleToolSpindleAndMagazine) obj0).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      }
      catch (Exception ex)
      {
        string str = "";
        buLog.addLog(str, "Not Ok", callMethod);
        buException.throwException(ex, callMethod, true, str);
      }
    }
  }
}
