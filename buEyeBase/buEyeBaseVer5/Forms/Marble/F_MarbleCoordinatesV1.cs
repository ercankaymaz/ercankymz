// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCoordinatesV1
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
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

public class F_MarbleCoordinatesV1 : Form
{
  public buButton btn_constantZ3AX;
  public buButton btn_paralllelcut3AX;
  public buButton btn_profilefinish;
  public buButton btn_profilerough;
  public buButton btn_Rough3AX;
  public buButton btn_surfaceclear;
  public buButton btn_profileroughoutside;
  public buButton btn_profiloffset;
  public static byte f001A27;
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

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_MarbleDrawV1) this).btn_ok.Name)
    {
      this.Apply();
      ((MostClosestPointOption) ((F_MarbleCoordinatesV2) this).Material).Entities.Clear();
      for (int index = 0; index <= ((F_MarbleCoordinatesV2) this).viewportLayout.Entities.Count - 1; ++index)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(((F_MarbleCoordinatesV2) this).viewportLayout.Entities[index], ref copiedEnt);
        CustomData customData = (CustomData) new ClipperOffset();
        copiedEnt.EntityData = (object) customData;
        ((MostClosestPointOption) ((F_MarbleCoordinatesV2) this).Material).Entities.Add(copiedEnt);
      }
      ((F_MarbleCoordinatesV2) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_MarbleCoordinatesV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleCoordinatesV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_MarbleDrawV1) this).btn_cancel.Name))
      return;
    ((F_MarbleCoordinatesV2) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCoordinatesV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCoordinatesV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  private void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    \u0007.\u0001.\u0001((F_MaterialRect3D) this);
    ((F_MarbleDrawV1) this).btn_ok.Enabled = true;
    ((F_MarbleCoordinatesV2) this).\u0001.Enabled = false;
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
    ((SortResult) ((F_MarbleCoordinatesV2) this).Material).Size.Width = (double) ((F_MarbleDrawV1) this).\u0001.Value;
    ((SortResult) ((F_MarbleCoordinatesV2) this).Material).Size.Height = (double) ((F_MarbleDrawV1) this).\u0002.Value;
    ((SortResult) ((F_MarbleCoordinatesV2) this).Material).Size.Depth = (double) ((F_MarbleDrawV1) this).\u0003.Value;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MarbleCoordinatesV2) this).PropertiesForm.Inited)
      return;
    ((SortResult) ((F_MarbleCoordinatesV2) this).Material).Size.Width = (double) ((F_MarbleDrawV1) this).\u0001.Value;
    ((SortResult) ((F_MarbleCoordinatesV2) this).Material).Size.Height = (double) ((F_MarbleDrawV1) this).\u0002.Value;
    \u0007.\u0001.\u0001((F_MaterialRect3D) this);
    ((F_MarbleCoordinatesV2) this).PropertiesForm.Inited = true;
  }

  public void FindFirstClamperPositions(
    double Width,
    double ClamperLength,
    ref double X1,
    ref double X2)
  {
    X2 = ClamperLength / 2.0;
    X1 = Width - ClamperLength / 2.0;
    if (X1 - X2 >= ClamperLength + 10.0)
      return;
    double num = ClamperLength + 10.0 - (X2 - X1);
    if (num <= 0.0)
      return;
    X2 += num / 2.0;
    X1 -= num / 2.0;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleDrawV1) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleDrawV1) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCoordinatesV1() => F_MarbleCoordinatesV2.Captions = new List<string>();

  public F_MarbleCoordinatesV1()
  {
    ((F_MarbleDrawV1) this).PropertiesForm = new FormProperties();
    ((F_MarbleDrawV1) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((F_MarbleJobOPListV2) this).OptionEntity = (List<Entity>) null;
    ((F_MarbleJobOPListV2) this).EntClamper = (Entity) null;
    ((F_MarbleJobOPListV2) this).\u0001 = new Timer();
    ((F_MarbleJobOPListV2) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MaterialRect2D) this);
    ((F_MarbleJobOPListV2) this).\u0001.Tick += new EventHandler(((F_MarbleGCodeViewV1) this).\u0002);
  }

  public void Init(MaterialBase5 material)
  {
    ((F_MarbleDrawV1) this).PropertiesForm.Inited = false;
    if (((F_MarbleDrawV1) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleDrawV1) this).PropertiesForm.Height;
    if (((F_MarbleDrawV1) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleDrawV1) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleDrawV1) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleDrawV1) this).PropertiesForm.FormPosition;
    ((F_MarbleJobOPListV2) this).btn_ok.Enabled = false;
    if (material != null)
      ((F_MarbleDrawV1) this).Material = (MaterialBase5) new ShapeMultiCenterData(material);
    ((F_MarbleJobOPListV2) this).\u0001.Value = (Decimal) ((SortResult) ((F_MarbleDrawV1) this).Material).Size.Width;
    ((F_MarbleJobOPListV2) this).\u0002.Value = (Decimal) ((SortResult) ((F_MarbleDrawV1) this).Material).Size.Height;
    ((F_MarbleGCodeViewV1) this).ControlUpdate();
    ((F_MarbleGCodeViewV1) this).LoadLanguage();
    ((F_MarbleDrawV1) this).PropertiesForm.Inited = false;
    ((F_MarbleJobOPListV2) this).\u0001.Text = buLangTranslate.preDef.Width + " (X) ";
    ((F_MarbleJobOPListV2) this).\u0002.Text = buLangTranslate.preDef.Height + " (Y) ";
    ((F_MarbleJobOPListV2) this).\u0001.Interval = 100;
    ((F_MarbleJobOPListV2) this).\u0001.Enabled = true;
    ((F_MarbleDrawV1) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleDrawV1) this).PropertiesForm.Inited = true;
  }
}
