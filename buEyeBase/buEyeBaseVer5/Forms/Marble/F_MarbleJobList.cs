// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleJobList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Materials;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleJobList : Form
{
  public buButton btn_cornercleaning;
  public buButton btn_rough3plus2back;
  public buButton btn_rough3plus2front;
  public buButton btn_roughrotary;
  public buButton btn_finishprojection;
  public buButton btn_roughprojection;
  public buButton btn_5axisgeodesicmilling;
  internal buLabel \u0001;
  internal buLabel \u0002;
  public buButton btn_constantcusp3AX;
  public static byte f001A52;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal ImageList \u0001;
  public buPanel pnl_base;
  public buButton btn_parkpos;
  public buButton btn_sawstart;
  public buButton btn_water;

  static F_MarbleJobList() => F_MarbleJobOPListV2.Captions = new List<string>();

  public F_MarbleJobList()
  {
    ((F_MarbleJobOPListV2) this).PropertiesForm = new FormProperties();
    ((F_MarbleJobOPListV2) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((F_MarbleJobOPListV2) this).OptionEntity = (List<Entity>) null;
    ((F_MarbleJobOPListV2) this).EntClamper = (Entity) null;
    ((F_MarbleJobOPListV2) this).DrawDimension = false;
    ((F_MarbleJobOPListV2) this).\u0001 = new Timer();
    ((F_MarbleJobOPListV2) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_Material3D) this);
    ((F_MarbleJobOPListV2) this).\u0001.Tick += new EventHandler(this.\u0002);
  }

  public void Init(MaterialBase5 material)
  {
    ((F_MarbleJobOPListV2) this).PropertiesForm.Inited = false;
    if (((F_MarbleJobOPListV2) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleJobOPListV2) this).PropertiesForm.Height;
    if (((F_MarbleJobOPListV2) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleJobOPListV2) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleJobOPListV2) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleJobOPListV2) this).PropertiesForm.FormPosition;
    ((F_MarbleJobOPListV2) this).btn_ok.Enabled = false;
    ((F_MarbleJobOPListV2) this).\u0001.Items.Clear();
    ((F_MarbleJobOPListV2) this).\u0001.Items.Add((object) AppLanguage.CadCamDynamic[62]);
    ((F_MarbleJobOPListV2) this).\u0001.Items.Add((object) AppLanguage.CadCamDynamic[51]);
    ((F_MarbleJobOPListV2) this).\u0001.Items.Add((object) AppLanguage.CadCamDynamic[54]);
    ((F_MarbleJobOPListV2) this).\u0001.Items.Add((object) AppLanguage.CadCamDynamic[63 /*0x3F*/]);
    ((F_MarbleJobOPListV2) this).\u0001.Items.Add((object) AppLanguage.CadCamDynamic[64 /*0x40*/]);
    if (material != null)
      ((F_MarbleJobOPListV2) this).Material = (MaterialBase5) new ShapeMultiCenterData(material);
    ((F_MarbleSpeedsV1) this).ControlUpdate();
    this.LoadLanguage();
    this.TypeToControl();
    ((F_MarbleJobOPListV2) this).PropertiesForm.Inited = false;
    if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.Rectangle)
    {
      ((F_MarbleJobOPListV2) this).\u0001.SelectedIndex = 0;
      ((F_MarbleJobOPListV2) this).\u0002.Text = buLangTranslate.preDef.Width + " (X) ";
      ((F_MarbleJobOPListV2) this).\u0003.Text = buLangTranslate.preDef.Height + " (Y) ";
      ((F_MarbleJobOPListV2) this).\u0004.Text = buLangTranslate.preDef.Depth + " (Z) ";
    }
    if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.Circle)
      ((F_MarbleJobOPListV2) this).\u0001.SelectedIndex = 1;
    if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.Ellipse)
      ((F_MarbleJobOPListV2) this).\u0001.SelectedIndex = 2;
    if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.RectangleRound)
      ((F_MarbleJobOPListV2) this).\u0001.SelectedIndex = 3;
    if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.RectangleChamfer)
      ((F_MarbleJobOPListV2) this).\u0001.SelectedIndex = 4;
    ((F_MarbleJobOPListV2) this).\u0001.Interval = 100;
    ((F_MarbleJobOPListV2) this).\u0001.Enabled = true;
    ((F_MarbleJobOPListV2) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleJobOPListV2) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_MarbleJobOPListV2.Captions.Count >= 9)
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
    if (((F_MarbleJobOPListV2) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleJobOPListV2) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleJobOPListV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleJobOPListV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_MarbleJobOPListV2) this).btn_ok.Name)
    {
      ((MostClosestPointOption) ((F_MarbleJobOPListV2) this).Material).Entities.Clear();
      for (int index = 0; index <= ((F_MarbleJobOPListV2) this).viewportLayout.Entities.Count - 1; ++index)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(((F_MarbleJobOPListV2) this).viewportLayout.Entities[index], ref copiedEnt);
        CustomData customData = (CustomData) new ClipperOffset();
        copiedEnt.EntityData = (object) customData;
        ((MostClosestPointOption) ((F_MarbleJobOPListV2) this).Material).Entities.Add(copiedEnt);
      }
      ((F_MarbleJobOPListV2) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_MarbleJobOPListV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleJobOPListV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_MarbleJobOPListV2) this).btn_cancel.Name))
      return;
    ((F_MarbleJobOPListV2) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleJobOPListV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleJobOPListV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  private void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_MarbleJobOPListV2) this).viewportLayout.IsHandleCreated)
      return;
    ((F_MarbleSpeedsV1) this).\u0001();
    ((F_MarbleJobOPListV2) this).btn_ok.Enabled = true;
    ((F_MarbleJobOPListV2) this).\u0001.Enabled = false;
  }

  public void TypeToControl()
  {
    ((F_MarbleJobOPListV2) this).\u0002.Visible = false;
    ((F_MarbleJobOPListV2) this).\u0003.Visible = false;
    ((F_MarbleJobOPListV2) this).\u0004.Visible = false;
    ((F_MarbleStartLine) this).\u0005.Visible = false;
    ((F_MarbleStartLine) this).\u0006.Visible = false;
    ((F_MarbleJobOPListV2) this).\u0001.Visible = false;
    ((F_MarbleJobOPListV2) this).\u0002.Visible = false;
    ((F_MarbleJobOPListV2) this).\u0003.Visible = false;
    ((F_MarbleStartLine) this).\u0004.Visible = false;
    ((F_MarbleStartLine) this).\u0005.Visible = false;
    ((F_MarbleJobOPListV2) this).PropertiesForm.Inited = false;
    if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.Rectangle)
    {
      ((F_MarbleJobOPListV2) this).\u0002.Text = AppLanguage.CadCamDynamic[15] + " (X) ";
      ((F_MarbleJobOPListV2) this).\u0003.Text = AppLanguage.CadCamDynamic[16 /*0x10*/] + " (Y) ";
      ((F_MarbleJobOPListV2) this).\u0004.Text = AppLanguage.CadCamDynamic[113] + " (Z) ";
      ((F_MarbleStartLine) this).\u0005.Text = AppLanguage.CadCamDynamic[2];
      ((F_MarbleJobOPListV2) this).\u0001.Value = (Decimal) ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Width;
      ((F_MarbleJobOPListV2) this).\u0002.Value = (Decimal) ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Height;
      ((F_MarbleJobOPListV2) this).\u0003.Value = (Decimal) ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth;
      ((F_MarbleStartLine) this).\u0004.Value = (Decimal) ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Angle;
      ((F_MarbleJobOPListV2) this).\u0002.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0003.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0004.Visible = true;
      ((F_MarbleStartLine) this).\u0005.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0001.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0002.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0003.Visible = true;
      ((F_MarbleStartLine) this).\u0004.Visible = true;
    }
    if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.Circle)
    {
      ((F_MarbleJobOPListV2) this).\u0002.Text = AppLanguage.CadCamDynamic[57];
      ((F_MarbleJobOPListV2) this).\u0003.Text = AppLanguage.CadCamDynamic[113];
      ((F_MarbleJobOPListV2) this).\u0001.Value = (Decimal) ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Diameter;
      ((F_MarbleJobOPListV2) this).\u0002.Value = (Decimal) ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth;
      ((F_MarbleJobOPListV2) this).\u0002.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0003.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0001.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0002.Visible = true;
    }
    if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.Ellipse)
    {
      ((F_MarbleJobOPListV2) this).\u0002.Text = AppLanguage.CadCamDynamic[20];
      ((F_MarbleJobOPListV2) this).\u0003.Text = AppLanguage.CadCamDynamic[21];
      ((F_MarbleJobOPListV2) this).\u0004.Text = AppLanguage.CadCamDynamic[113];
      ((F_MarbleStartLine) this).\u0005.Text = AppLanguage.CadCamDynamic[2];
      ((F_MarbleJobOPListV2) this).\u0001.Value = (Decimal) ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).MajorRadius;
      ((F_MarbleJobOPListV2) this).\u0002.Value = (Decimal) ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).MinorRadius;
      ((F_MarbleJobOPListV2) this).\u0003.Value = (Decimal) ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth;
      ((F_MarbleStartLine) this).\u0004.Value = (Decimal) ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Angle;
      ((F_MarbleJobOPListV2) this).\u0002.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0003.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0004.Visible = true;
      ((F_MarbleStartLine) this).\u0005.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0001.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0002.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0003.Visible = true;
      ((F_MarbleStartLine) this).\u0004.Visible = true;
    }
    if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.RectangleRound)
    {
      ((F_MarbleJobOPListV2) this).\u0002.Text = AppLanguage.CadCamDynamic[20];
      ((F_MarbleJobOPListV2) this).\u0003.Text = AppLanguage.CadCamDynamic[21];
      ((F_MarbleJobOPListV2) this).\u0004.Text = AppLanguage.CadCamDynamic[19];
      ((F_MarbleStartLine) this).\u0005.Text = AppLanguage.CadCamDynamic[113];
      ((F_MarbleStartLine) this).\u0006.Text = AppLanguage.CadCamDynamic[2];
      ((F_MarbleJobOPListV2) this).\u0001.Value = (Decimal) ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Width;
      ((F_MarbleJobOPListV2) this).\u0002.Value = (Decimal) ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Height;
      ((F_MarbleJobOPListV2) this).\u0003.Value = (Decimal) ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Radius;
      ((F_MarbleStartLine) this).\u0004.Value = (Decimal) ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth;
      ((F_MarbleStartLine) this).\u0005.Value = (Decimal) ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Angle;
      ((F_MarbleJobOPListV2) this).\u0002.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0003.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0004.Visible = true;
      ((F_MarbleStartLine) this).\u0005.Visible = true;
      ((F_MarbleStartLine) this).\u0006.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0001.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0002.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0003.Visible = true;
      ((F_MarbleStartLine) this).\u0004.Visible = true;
      ((F_MarbleStartLine) this).\u0005.Visible = true;
    }
    if (((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Shapes == MaterialShapes.RectangleChamfer)
    {
      ((F_MarbleJobOPListV2) this).\u0002.Text = AppLanguage.CadCamDynamic[20];
      ((F_MarbleJobOPListV2) this).\u0003.Text = AppLanguage.CadCamDynamic[21];
      ((F_MarbleJobOPListV2) this).\u0004.Text = AppLanguage.CadCamDynamic[65];
      ((F_MarbleStartLine) this).\u0005.Text = AppLanguage.CadCamDynamic[113];
      ((F_MarbleStartLine) this).\u0006.Text = AppLanguage.CadCamDynamic[2];
      ((F_MarbleJobOPListV2) this).\u0001.Value = (Decimal) ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Width;
      ((F_MarbleJobOPListV2) this).\u0002.Value = (Decimal) ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Height;
      ((F_MarbleJobOPListV2) this).\u0003.Value = (Decimal) ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).ChamferLength;
      ((F_MarbleStartLine) this).\u0004.Value = (Decimal) ((SortResult) ((F_MarbleJobOPListV2) this).Material).Size.Depth;
      ((F_MarbleStartLine) this).\u0005.Value = (Decimal) ((SortAskMe) ((F_MarbleJobOPListV2) this).Material).Angle;
      ((F_MarbleJobOPListV2) this).\u0002.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0003.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0004.Visible = true;
      ((F_MarbleStartLine) this).\u0005.Visible = true;
      ((F_MarbleStartLine) this).\u0006.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0001.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0002.Visible = true;
      ((F_MarbleJobOPListV2) this).\u0003.Visible = true;
      ((F_MarbleStartLine) this).\u0004.Visible = true;
      ((F_MarbleStartLine) this).\u0005.Visible = true;
    }
    ((F_MarbleJobOPListV2) this).PropertiesForm.Inited = true;
  }
}
