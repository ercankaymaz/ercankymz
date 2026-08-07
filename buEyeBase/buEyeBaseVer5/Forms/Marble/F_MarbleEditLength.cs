// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEditLength
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEditLength : Form
{
  public buPanel pnl_base;
  public static byte f001B36;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public int BaseWidth;
  public int BaseHeight;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal ImageList \u0002;

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).ground_base.Text = buLangTranslate.preDef.Warning;
      ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).lbl_wagonup.Text = buLangTranslate.preSentencesMarble.WagonUpPosition;
      ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).lbl_operationspeedzero.Text = buLangTranslate.preSentencesMarble.CuttingSpeedisZero;
      ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).lbl_quickspeedzero.Text = buLangTranslate.preSentencesMarble.ManuelSpeedisZero;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleEditBaseHAndOffsetXY) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleEditBaseHAndOffsetXY) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleEditBaseHAndOffsetXY) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEditBaseHAndOffsetXY) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleEditBaseHAndOffsetXY) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleEditBaseHAndOffsetXY) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEditBaseHAndOffsetXY) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEditLength() => F_MarbleEditBaseHAndOffsetXY.Captions = new List<string>();

  public F_MarbleEditLength()
  {
    ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).\u0001 = "F_MarbleCoordinatesV1";
    ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).PropertiesForm = new FormProperties();
    ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleJobOPListV1) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      if (clsVisualVars.parVisual == null)
        return;
      ((F_MarbleEditBaseH) this).LoadLanguage();
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }
}
