// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_ColorList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_ColorList : Form
{
  internal CheckBox \u0005;
  internal CheckBox \u0006;
  internal CheckBox \u0007;
  internal CheckBox \u0008;
  internal CheckBox \u000E;
  internal CheckBox \u000F;
  internal CheckBox \u0010;
  internal CheckBox \u0011;
  internal CheckBox \u0012;
  internal CheckBox \u0013;
  internal CheckBox \u0014;
  internal CheckBox \u0015;
  internal CheckBox \u0016;
  internal CheckBox \u0017;
  public FormProperties Properties;
  public static List<string> Captions;
  public MirrorEventFormVars Settings;
  internal IContainer \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal Panel \u0001;
  internal Panel \u0002;
  internal Label \u0001;
  public Button btn_rightbottom;
  public Button btn_bottom;
  public Button btn_leftbottom;
  public Button btn_right;
  public Button btn_center;
  public Button btn_left;
  public Button btn_righttop;
  public Button btn_top;
  public Button btn_lefttop;
  public Button btn_aligment;
  internal RadioButton \u0001;
  internal RadioButton \u0002;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_DeleteType) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_DeleteType) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ColorList() => F_DeleteType.Captions = new List<string>();

  public F_ColorList()
  {
    ((F_Mirror) this).OffsetType = CamClosedContourType.Outter;
    ((F_Mirror) this).OffsetValue = 0.0;
    ((F_Mirror) this).PropertiesForm = new FormProperties();
    ((F_Mirror) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    buCompare5.CultureSettings();
    \u0007.\u0001.\u0001((F_CutterOffsetEntities) this);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  public void Init()
  {
    ((F_Mirror) this).PropertiesForm.Inited = false;
    if (((F_Mirror) this).PropertiesForm.Height > 10)
      this.Height = ((F_Mirror) this).PropertiesForm.Height;
    if (((F_Mirror) this).PropertiesForm.Width > 10)
      this.Width = ((F_Mirror) this).PropertiesForm.Width;
    this.TopMost = ((F_Mirror) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_Mirror) this).PropertiesForm.FormPosition;
    ((F_Mirror) this).\u0001.Value = (Decimal) ((F_Mirror) this).OffsetValue;
    ((F_Mirror) this).\u0001.Checked = ((F_Mirror) this).DeleteOriginal;
    if (((F_Mirror) this).OffsetType == CamClosedContourType.Inner)
    {
      ((F_Mirror) this).\u0001.Checked = true;
      ((F_Mirror) this).\u0002.Checked = false;
    }
    else
    {
      ((F_Mirror) this).\u0001.Checked = false;
      ((F_Mirror) this).\u0002.Checked = true;
    }
    this.LoadLanguage();
    ((F_Mirror) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = "NestRectPartAdd LoadLanguage";
    try
    {
      if (F_DeleteType.Captions.Count < 6)
        return;
      this.Text = F_DeleteType.Captions[0];
      ((F_Mirror) this).\u0003.Text = F_DeleteType.Captions[1];
      ((F_Mirror) this).\u0005.Text = F_DeleteType.Captions[4];
      ((F_Mirror) this).\u0001.Text = F_DeleteType.Captions[5];
      ((F_Mirror) this).\u0002.Text = F_DeleteType.Captions[6];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_Mirror) this).\u0001.Name)
    {
      ((F_Mirror) this).OffsetValue = (double) ((F_Mirror) this).\u0001.Value;
      ((F_Mirror) this).DeleteOriginal = ((F_Mirror) this).\u0001.Checked;
      if (((F_Mirror) this).\u0002.Checked)
        ((F_Mirror) this).OffsetType = CamClosedContourType.Outter;
      else
        ((F_Mirror) this).OffsetType = CamClosedContourType.Inner;
      ((F_Mirror) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_Mirror) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_Mirror) this).PropertiesForm.FormCloseMode == FormCloseModeType.Close)
        this.Close();
      if (((F_Mirror) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_Mirror) this).\u0002.Name))
      return;
    if (((F_Mirror) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Mirror) this).PropertiesForm.FormCloseMode == FormCloseModeType.Close)
      this.Close();
    if (((F_Mirror) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_Mirror) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_Mirror) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_Mirror) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Mirror) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    if (((F_Mirror) this).PropertiesForm.FormCloseMode != FormCloseModeType.Close)
      return;
    this.Close();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Mirror) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Mirror) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
