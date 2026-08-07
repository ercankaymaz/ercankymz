// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_SortingSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buCore;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_SortingSettings : Form
{
  internal ToolStripMenuItem \u0007;
  internal ToolStripMenuItem \u0008;
  internal ToolStripMenuItem \u000E;
  internal ToolStripSeparator \u0003;
  internal ToolStripMenuItem \u000F;
  internal ToolStripSeparator \u0004;
  internal ToolStripMenuItem \u0010;
  internal ToolStripMenuItem \u0011;
  internal Button \u0010;
  internal Button \u0011;
  internal Button \u0012;
  internal Button \u0013;
  internal Panel \u0002;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal Panel \u0003;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal RadioButton \u0006;
  internal ToolStripSeparator \u0005;
  internal ToolStripMenuItem \u0012;
  public CheckBox chk_preview;
  internal ToolStripSeparator \u0006;
  internal ToolStripMenuItem \u0013;
  internal Label \u0005;

  static F_SortingSettings() => F_NestSheetPartList.Captions = new List<string>();

  public F_SortingSettings()
  {
    ((F_NestSheetPartList) this).Result = DialogResult.None;
    ((F_NestSheetPartList) this).FormCloseMode = FormCloseModeType.Dispose;
    ((F_NestSheetPartList) this).Part = (buNestingPart) new ProfileOperationBarrel();
    ((F_NestSheetPartList) this).Settings = (buNestingVar) new ProfileOperationDataBarel();
    ((F_NestSheetPartList) this).ShowItemNo = false;
    ((F_NestSheetPartList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    buCompare5.CultureSettings();
    \u0007.\u0001.\u0001((F_NestRectPartAdd) this);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  public void Init()
  {
    ((F_NestSheetPartList) this).Result = DialogResult.None;
    ((F_NestSheetPartList) this).\u0001.Visible = ((F_NestSheetPartList) this).ShowItemNo;
    ArrayList EnumItems = new ArrayList();
    buCompare5.GetEnumTypeValues((object) ((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).Rotation, ref EnumItems);
    buCompare5.ComboboxAddItem(EnumItems, Convert.ToInt32((object) ((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).Rotation), ref ((F_Layer) this).\u0001);
    ((F_PostProcessorSelect) this).\u0003.Value = (Decimal) ((ProfileOperationNotchOld) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddPart).Height;
    ((F_Preview) this).\u0004.Value = (Decimal) ((ProfileOperationNotchOld) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddPart).Width;
    ((F_Layer) this).\u0005.Value = (Decimal) ((ProfileOperationNotch) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddPart).Priority;
    ((F_PostProcessorSelect) this).\u0001.Value = (Decimal) ((ProfileOperationNotchOld) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddPart).Quantity;
    ((F_PostProcessorSelect) this).\u0002.Value = (Decimal) ((ProfileOperationNotchOld) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddPart).Thickness;
    ((F_Preview) this).\u0002.Text = ((ProfileOperationNotchOld) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddPart).Name;
    ((F_Layer) this).\u0006.Value = (Decimal) ((ProfileOperationFreeDraw) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddPart).AdditionalRotation;
    this.LoadLanguage();
  }

  public void LoadLanguage()
  {
    string callMethod = "NestRectPartAdd LoadLanguage";
    try
    {
      if (F_NestSheetPartList.Captions.Count < 10)
        return;
      this.Text = F_NestSheetPartList.Captions[0];
      ((F_Preview) this).\u0014.Text = F_NestSheetPartList.Captions[1];
      ((F_PostProcessorSelect) this).\u0007.Text = F_NestSheetPartList.Captions[2];
      ((F_NestSheetPartList) this).\u0004.Text = F_NestSheetPartList.Captions[3];
      ((F_Layer) this).\u0016.Text = F_NestSheetPartList.Captions[4];
      ((F_Layer) this).\u0018.Text = F_NestSheetPartList.Captions[5];
      ((F_Layer) this).\u0001.Text = F_NestSheetPartList.Captions[6];
      ((F_Layer) this).\u0002.Text = F_NestSheetPartList.Captions[7];
      ((F_Preview) this).\u0012.Text = F_NestSheetPartList.Captions[8];
      ((F_PostProcessorSelect) this).\u000F.Text = F_NestSheetPartList.Captions[9];
      ((F_NestSheetPartList) this).\u0002.Text = F_NestSheetPartList.Captions[10];
      ((F_Layer) this).\u001A.Text = F_NestSheetPartList.Captions[11];
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
    if (control2.Name == ((F_Layer) this).\u0001.Name)
    {
      ((ProfileOperationNotch) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddPart).Priority = (int) ((F_Layer) this).\u0005.Value;
      ((ProfileOperationNotchOld) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddPart).Quantity = (int) ((F_PostProcessorSelect) this).\u0001.Value;
      ((ProfileOperationNotchOld) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddPart).Thickness = (double) ((F_PostProcessorSelect) this).\u0002.Value;
      ((ProfileOperationFreeDraw) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddPart).Rotation = (nestPartRotateType) buGeneral.EnumValueFromInt((object) ((ProfileOperationFreeDraw) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddPart).Rotation, ((F_Layer) this).\u0001.SelectedIndex);
      ((ProfileOperationNotchOld) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddPart).Width = (double) ((F_Preview) this).\u0004.Value;
      ((ProfileOperationNotchOld) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddPart).Height = (double) ((F_PostProcessorSelect) this).\u0003.Value;
      ((ProfileOperationFreeDraw) ((ProfileSupportBlock) ((F_NestSheetPartList) this).Settings).AddPart).AdditionalRotation = (double) ((F_Layer) this).\u0006.Value;
      ((F_NestSheetPartList) this).Part = (buNestingPart) new ProfileOperationBarrel();
      ((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).AdditionalRotation = (double) ((F_Layer) this).\u0006.Value;
      ((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).Width = (double) ((F_Preview) this).\u0004.Value;
      ((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).Height = (double) ((F_PostProcessorSelect) this).\u0003.Value;
      ((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).Thickness = (double) ((F_PostProcessorSelect) this).\u0002.Value;
      ((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).Quantity = (int) ((F_PostProcessorSelect) this).\u0001.Value;
      ((ProfileOperation) ((F_NestSheetPartList) this).Part).Remain = (int) ((F_PostProcessorSelect) this).\u0001.Value;
      ((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).Priority = (int) ((F_Layer) this).\u0005.Value;
      ((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).Name = ((F_Preview) this).\u0002.Text;
      ((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).ItemNo = ((F_NestSheetPartList) this).\u0001.Text;
      ((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).Rotation = (nestPartRotateType) buGeneral.EnumValueFromInt((object) ((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).Rotation, ((F_Layer) this).\u0001.SelectedIndex);
      buEntity rectangleEntity = (buEntity) null;
      buCall.\u0001.DrawRectangle(new Point3D(), ((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).Width, ((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).Height, Plane.XY, ref rectangleEntity);
      ((ProfileOperationRectangle) ((F_NestSheetPartList) this).Part).EntitiesGroup = new buEntitiesGroup();
      ((\u0084.\u0001) ((ProfileOperationRectangle) ((F_NestSheetPartList) this).Part).EntitiesGroup.Outside).Entities.Add(rectangleEntity);
      ((\u0084.\u0001) ((ProfileOperationRectangle) ((F_NestSheetPartList) this).Part).EntitiesGroup.Outside).Points = new List<Point3D>();
      buCall.\u0001.EntitiesToPointsWithCamDirection(((\u0084.\u0001) ((ProfileOperationRectangle) ((F_NestSheetPartList) this).Part).EntitiesGroup.Outside).Entities, ref ((\u0084.\u0001) ((ProfileOperationRectangle) ((F_NestSheetPartList) this).Part).EntitiesGroup.Outside).Points);
      if (((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).Quantity <= 0)
      {
        buNumeric5.MessageBoxWarning(AppLanguage.CadCamMessages[37]);
        return;
      }
      if (((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).Width <= 0.0)
      {
        buNumeric5.MessageBoxWarning(AppLanguage.CadCamMessages[38]);
        return;
      }
      if (((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).Height <= 0.0)
      {
        buNumeric5.MessageBoxWarning(AppLanguage.CadCamMessages[39]);
        return;
      }
      if (((ProfileOperation) ((ProfileOperation) ((F_NestSheetPartList) this).Part).PartData).Thickness <= 0.0 & ((F_PostProcessorSelect) this).\u0003.Visible)
      {
        buNumeric5.MessageBoxWarning(AppLanguage.CadCamMessages[40]);
        return;
      }
      ((F_NestSheetPartList) this).Result = DialogResult.OK;
      if (((F_NestSheetPartList) this).FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_NestSheetPartList) this).FormCloseMode == FormCloseModeType.Close)
        this.Close();
      if (((F_NestSheetPartList) this).FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_Layer) this).\u0002.Name))
      return;
    if (((F_NestSheetPartList) this).FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestSheetPartList) this).FormCloseMode == FormCloseModeType.Close)
      this.Close();
    if (((F_NestSheetPartList) this).FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_NestSheetPartList) this).Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_NestSheetPartList) this).Result = DialogResult.Cancel;
    if (((F_NestSheetPartList) this).FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestSheetPartList) this).FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    if (((F_NestSheetPartList) this).FormCloseMode != FormCloseModeType.Close)
      return;
    this.Close();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_NestSheetPartList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_NestSheetPartList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_SortingSettings() => F_NestSheetPartList.Captions = new List<string>();

  public F_SortingSettings()
  {
    ((F_Layer) this).Result = DialogResult.None;
    ((F_Layer) this).FormCloseMode = FormCloseModeType.Dispose;
    ((F_Layer) this).Sheet = (buNestingSheet) new ProfileOperation();
    ((F_Layer) this).ShowItemNo = false;
    ((F_Layer) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    buCompare5.CultureSettings();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_NestSheetAdd) this);
  }

  public void Init()
  {
    ((F_Layer) this).Result = DialogResult.None;
    ((F_QuiltingSettings) this).\u0006.Visible = ((F_Layer) this).ShowItemNo;
    this.LoadLanguage();
  }

  public void LoadLanguage()
  {
    string callMethod = "SheetAdd LoadLanguage";
    try
    {
      if (F_Layer.Captions.Count < 8)
        return;
      this.Text = F_Layer.Captions[0];
      ((F_Layer) this).\u0001.Text = F_Layer.Captions[1];
      ((F_QuiltingSetProperties) this).\u0003.Text = F_Layer.Captions[2];
      ((F_QuiltingSetProperties) this).\u0005.Text = F_Layer.Captions[3];
      ((F_QuiltingSetProperties) this).\u0007.Text = F_Layer.Captions[4];
      ((F_QuiltingSetProperties) this).\u0008.Text = F_Layer.Captions[5];
      ((F_Layer) this).\u0001.Text = F_Layer.Captions[6];
      ((F_Layer) this).\u0002.Text = F_Layer.Captions[7];
      ((F_QuiltingSettings) this).\u000E.Text = F_Layer.Captions[8];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_Layer) this).\u0001.Name)
    {
      ((ProfileItem) ((ProfileItemCalc) ((F_Layer) this).Sheet).MaterialData).Width = (double) ((F_Layer) this).\u0001.Value;
      ((ProfileItem) ((ProfileItemCalc) ((F_Layer) this).Sheet).MaterialData).Height = (double) ((F_QuiltingSetProperties) this).\u0002.Value;
      ((ProfileItem) ((ProfileItemCalc) ((F_Layer) this).Sheet).MaterialData).Thickness = (double) ((F_QuiltingSetProperties) this).\u0003.Value;
      ((ProfileItem) ((ProfileItemCalc) ((F_Layer) this).Sheet).MaterialData).Quantity = (int) ((F_QuiltingSettings) this).\u0004.Value;
      ((ProfileItemCalc) ((F_Layer) this).Sheet).Remain = (int) ((F_QuiltingSettings) this).\u0004.Value;
      ((ProfileItem) ((ProfileItemCalc) ((F_Layer) this).Sheet).MaterialData).Name = ((F_Layer) this).\u0001.Text;
      ((ProfileItem) ((ProfileItemCalc) ((F_Layer) this).Sheet).MaterialData).ItemNo = ((F_QuiltingSettings) this).\u0002.Text;
      ((GProfileOperation) buCall.\u0001).SheetRectangle(((ProfileItem) ((ProfileItemCalc) ((F_Layer) this).Sheet).MaterialData).Width, ((ProfileItem) ((ProfileItemCalc) ((F_Layer) this).Sheet).MaterialData).Height, ref ((F_Layer) this).Sheet);
      if (((ProfileItem) ((ProfileItemCalc) ((F_Layer) this).Sheet).MaterialData).Quantity <= 0)
      {
        buNumeric5.MessageBoxWarning(AppLanguage.CadCamMessages[37]);
        return;
      }
      if (((ProfileItem) ((ProfileItemCalc) ((F_Layer) this).Sheet).MaterialData).Width <= 0.0)
      {
        buNumeric5.MessageBoxWarning(AppLanguage.CadCamMessages[38]);
        return;
      }
      if (((ProfileItem) ((ProfileItemCalc) ((F_Layer) this).Sheet).MaterialData).Height <= 0.0)
      {
        buNumeric5.MessageBoxWarning(AppLanguage.CadCamMessages[39]);
        return;
      }
      if (((ProfileItem) ((ProfileItemCalc) ((F_Layer) this).Sheet).MaterialData).Thickness <= 0.0 & ((F_QuiltingSetProperties) this).\u0004.Visible)
      {
        buNumeric5.MessageBoxWarning(AppLanguage.CadCamMessages[40]);
        return;
      }
      ((F_Layer) this).Result = DialogResult.OK;
      if (((F_Layer) this).FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_Layer) this).FormCloseMode == FormCloseModeType.Close)
        this.Close();
      if (((F_Layer) this).FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_Layer) this).\u0002.Name))
      return;
    if (((F_Layer) this).FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Layer) this).FormCloseMode == FormCloseModeType.Close)
      this.Close();
    if (((F_Layer) this).FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
  }
}
