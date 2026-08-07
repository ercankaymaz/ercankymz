// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_Layer
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_Layer : Form
{
  internal Panel \u0006;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  internal Panel \u0007;
  internal Label \u0015;
  internal Label \u0016;
  internal NumericUpDown \u0005;
  internal Panel \u0008;
  internal ComboBox \u0001;
  internal Label \u0017;
  internal Label \u0018;
  internal Label \u0019;
  internal Label \u001A;
  internal NumericUpDown \u0006;
  public static byte f000F57;
  public static List<string> Captions;
  public DialogResult Result;
  public FormCloseModeType FormCloseMode;
  public buNestingSheet Sheet;
  public bool ShowItemNo;
  private IContainer \u0001;
  internal ImageList \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal Label \u0001;
  internal TextBox \u0001;
  internal NumericUpDown \u0001;

  public void LoadLanguage()
  {
    string str = nameof (LoadLanguage);
    try
    {
      if (F_LaserMaterial.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_LaserMaterial) this).PropertiesForm.sClassName, str, ex.Message, "Exception");
      buException.throwException(ex, str, true, ((F_LaserMaterial) this).PropertiesForm.sClassName);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_LaserMaterial) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_LaserMaterial) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_LaserMaterial) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_LaserMaterial) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Tick_Timer(object sender, EventArgs e)
  {
    string str = nameof (Tick_Timer);
    try
    {
      if (!buEyeItems.viewportDialogs.IsHandleCreated)
        return;
      ((F_LaserMaterial) this).\u0001.Enabled = false;
      if (((F_LaserMaterial) this).SelectedIndex >= 0 & ((F_LaserMaterial) this).SelectedIndex <= FoamCalcVars.DiskBlocks.Count - 1)
      {
        this.ItemToControls(FoamCalcVars.DiskBlocks[((F_LaserMaterial) this).SelectedIndex]);
        this.DrawDiskBlock(0, -1);
      }
      buEyeItems.viewportDialogs.SetView(viewType.Trimetric);
      buEyeItems.viewportDialogs.ZoomFit(5);
      buEyeItems.viewportDialogs.Invalidate();
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_LaserMaterial) this).PropertiesForm.sClassName, str, ex.Message, "Exception");
      buException.throwException(ex, str, false, ((F_LaserMaterial) this).PropertiesForm.sClassName);
    }
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
  }

  public void ItemToControls(PipeBendDiskBlocks DiskData)
  {
    ((F_LaserMaterial) this).PropertiesForm.Inited = false;
    ((F_NestExecute) this).spn_blockdepth.Value = ((SewingDevideOptions) DiskData).BlockDepth;
    ((F_NestExecute) this).spn_blcokheight.Value = ((SewingEntityCustomData) DiskData).BlockHeight;
    ((F_NestExecute) this).spn_blockwidth.Value = ((SewingEntityCustomData) DiskData).BlockWidth;
    ((F_NestExecute) this).spn_diskblocklength.Value = ((SewingEntityCustomData) DiskData).DiskBlockLength;
    ((F_NestExecute) this).spn_diskblockwidth.Value = ((SewingEntityCustomData) DiskData).DiskBlockWidth;
    ((F_NestExecute) this).spn_diskdiameter.Value = ((SewingEntityCustomData) DiskData).DiskDiameter;
    ((F_NestExecute) this).spn_diskHeight.Value = ((SewingEntityCustomData) DiskData).DiskHeight;
    ((F_NestExecute) this).spn_diskthickness.Value = ((SewingEntityCustomData) DiskData).DiskThickness;
    ((F_NestExecute) this).spn_pipediameter.Value = ((SewingMain) DiskData).BlockPipeDiameter;
    ((F_LaserMaterial) this).PropertiesForm.Inited = true;
  }

  public void ControlsToItem()
  {
    if (!(((F_LaserMaterial) this).SelectedIndex >= 0 & ((F_LaserMaterial) this).SelectedIndex <= FoamCalcVars.DiskBlocks.Count - 1))
      return;
    PipeBendDiskBlocks diskBlock = FoamCalcVars.DiskBlocks[((F_LaserMaterial) this).SelectedIndex];
    ((SewingDevideOptions) diskBlock).BlockDepth = ((F_NestExecute) this).spn_blockdepth.Value;
    ((SewingEntityCustomData) diskBlock).BlockHeight = ((F_NestExecute) this).spn_blcokheight.Value;
    ((SewingEntityCustomData) diskBlock).BlockWidth = ((F_NestExecute) this).spn_blockwidth.Value;
    ((SewingEntityCustomData) diskBlock).DiskBlockLength = ((F_NestExecute) this).spn_diskblocklength.Value;
    ((SewingEntityCustomData) diskBlock).DiskBlockWidth = ((F_NestExecute) this).spn_diskblockwidth.Value;
    ((SewingEntityCustomData) diskBlock).DiskDiameter = ((F_NestExecute) this).spn_diskdiameter.Value;
    ((SewingEntityCustomData) diskBlock).DiskHeight = ((F_NestExecute) this).spn_diskHeight.Value;
    ((SewingEntityCustomData) diskBlock).DiskThickness = ((F_NestExecute) this).spn_diskthickness.Value;
    ((SewingMain) diskBlock).BlockPipeDiameter = ((F_NestExecute) this).spn_pipediameter.Value;
  }

  public void DrawDiskBlock(int Index, int DiskIndex)
  {
    buEyeItems.viewportDialogs.Entities.Clear();
    if (Index >= 0 & Index <= FoamCalcVars.DiskBlocks.Count - 1)
    {
      Entity entDisk = (Entity) null;
      Entity entBlock = (Entity) null;
      ((SewingJobItem) buCall.\u0001).CreateDiskBlocks(FoamCalcVars.DiskBlocks[Index], ref entDisk, ref entBlock);
      bool flag1 = true;
      bool flag2 = true;
      if (DiskIndex == 0)
        flag2 = false;
      if (DiskIndex == 1)
        flag1 = false;
      if (entDisk != null & flag1)
      {
        entDisk.Rotate(Utility.DegToRad(-90.0), Vector3D.AxisZ, Point3D.Origin);
        buEyeItems.viewportDialogs.Entities.Add(entDisk);
      }
      if (entBlock != null & flag2)
      {
        entBlock.Translate(-((SewingEntityCustomData) FoamCalcVars.DiskBlocks[Index]).BlockWidth + ((SewingEntityCustomData) FoamCalcVars.DiskBlocks[Index]).DiskDiameter / 2.0, ((SewingDevideOptions) FoamCalcVars.DiskBlocks[Index]).BlockDepth);
        buEyeItems.viewportDialogs.Entities.Add(entBlock);
      }
    }
    else
    {
      for (int index = 0; index <= FoamCalcVars.DiskBlocks.Count - 1; ++index)
      {
        Entity entDisk = (Entity) null;
        Entity entBlock = (Entity) null;
        ((SewingJobItem) buCall.\u0001).CreateDiskBlocks(FoamCalcVars.DiskBlocks[index], ref entDisk, ref entBlock);
        bool flag3 = true;
        bool flag4 = true;
        if (DiskIndex == 0)
          flag4 = false;
        if (DiskIndex == 1)
          flag3 = false;
        if (entDisk != null & flag3)
        {
          entDisk.Rotate(Utility.DegToRad(-90.0), Vector3D.AxisZ, Point3D.Origin);
          entDisk.Translate(0.0, 0.0, (double) index * ((SewingEntityCustomData) FoamCalcVars.DiskBlocks[index]).DiskHeight);
          buEyeItems.viewportDialogs.Entities.Add(entDisk);
        }
        if (entBlock != null & flag4)
        {
          entBlock.Translate(-((SewingEntityCustomData) FoamCalcVars.DiskBlocks[index]).BlockWidth, ((SewingDevideOptions) FoamCalcVars.DiskBlocks[index]).BlockDepth, (double) index * ((SewingEntityCustomData) FoamCalcVars.DiskBlocks[index]).DiskHeight);
          buEyeItems.viewportDialogs.Entities.Add(entBlock);
        }
      }
    }
    buEyeItems.viewportDialogs.Invalidate();
  }
}
