// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleJobOPListV1
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Materials;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleJobOPListV1 : Form
{
  public buGround buGround1;
  public buButton btn_pencil3AX;
  public buButton btn_flatland3AX;
  public buButton btn_constantZ3AX;
  public buButton btn_paralllelcut3AX;
  public buButton btn_Rough3AX;
  public static byte f001A0C;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleCamType CommandType;
  public Color clrLabel;
  public Color clrFormCaption;
  public Color clrFormBackUpper;
  public Color clrFormBackDown;
  public Color clrButtonDisplay;
  public Color clrButtonOver;
  public Color clrButtonDown;
  internal IContainer \u0001;
  public buButton btn_close;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buGround buGround1;

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_MarbleCoordinatesV2) this).\u0001.Name)
    {
      ((F_MarbleCoordinatesV2) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_MarbleCoordinatesV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleCoordinatesV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_MarbleCoordinatesV2) this).\u0002.Name))
      return;
    ((F_MarbleCoordinatesV2) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCoordinatesV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCoordinatesV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleCoordinatesV2) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleCoordinatesV2) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCoordinatesV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCoordinatesV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleCoordinatesV2) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleCoordinatesV2) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public abstract void m000E42();

  public F_MarbleJobOPListV1()
  {
    ((F_MarbleCoordinatesV2) this).PropertiesForm = new FormProperties();
    ((F_MarbleCoordinatesV2) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((F_MarbleCoordinatesV2) this).OptionEntity = (List<Entity>) null;
    ((F_MarbleCoordinatesV2) this).EntClamper = (Entity) null;
    ((F_MarbleCoordinatesV2) this).\u0001 = new Timer();
    ((F_MarbleDrawV1) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MaterialRect3D) this);
    ((F_MarbleCoordinatesV2) this).\u0001.Tick += new EventHandler(((F_MarbleCoordinatesV1) this).\u0002);
  }

  public void Init(MaterialBase5 material)
  {
    ((F_MarbleCoordinatesV2) this).PropertiesForm.Inited = false;
    if (((F_MarbleCoordinatesV2) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleCoordinatesV2) this).PropertiesForm.Height;
    if (((F_MarbleCoordinatesV2) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleCoordinatesV2) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleCoordinatesV2) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleCoordinatesV2) this).PropertiesForm.FormPosition;
    ((F_MarbleDrawV1) this).btn_ok.Enabled = false;
    if (material != null)
      ((F_MarbleCoordinatesV2) this).Material = (MaterialBase5) new ShapeMultiCenterData(material);
    ((F_MarbleDrawV1) this).\u0001.Value = (Decimal) ((SortResult) ((F_MarbleCoordinatesV2) this).Material).Size.Width;
    ((F_MarbleDrawV1) this).\u0002.Value = (Decimal) ((SortResult) ((F_MarbleCoordinatesV2) this).Material).Size.Height;
    ((F_MarbleDrawV1) this).\u0003.Value = (Decimal) ((SortResult) ((F_MarbleCoordinatesV2) this).Material).Size.Depth;
    ((F_MarbleCoordinatesV1) this).ControlUpdate();
    this.LoadLanguage();
    ((F_MarbleCoordinatesV2) this).PropertiesForm.Inited = false;
    ((F_MarbleDrawV1) this).\u0001.Text = buLangTranslate.preDef.Width + " (X) ";
    ((F_MarbleDrawV1) this).\u0002.Text = buLangTranslate.preDef.Height + " (Y) ";
    ((F_MarbleDrawV1) this).\u0003.Text = buLangTranslate.preDef.Depth + " (Z) ";
    ((F_MarbleCoordinatesV2) this).\u0001.Interval = 100;
    ((F_MarbleCoordinatesV2) this).\u0001.Enabled = true;
    ((F_MarbleCoordinatesV2) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleCoordinatesV2) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_MarbleCoordinatesV2.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleCoordinatesV2) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleCoordinatesV2) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCoordinatesV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCoordinatesV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
