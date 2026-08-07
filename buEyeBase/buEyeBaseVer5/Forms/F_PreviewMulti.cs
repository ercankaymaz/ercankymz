// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_PreviewMulti
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_PreviewMulti : Form
{
  internal Panel \u0001;
  internal Panel \u0002;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    string str = "btn_Click";
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_NestExecute) this).btn_ok.Name)
      {
        ((F_LaserMaterial) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_LaserMaterial) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_LaserMaterial) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_NestExecute) this).btn_cancel.Name)
      {
        ((F_LaserMaterial) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_LaserMaterial) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_LaserMaterial) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_NestExecute) this).btn_add.Name && ((F_LaserMaterial) this).SelectedIndex >= 0 & ((F_LaserMaterial) this).SelectedIndex <= FoamCalcVars.DiskBlocks.Count - 1)
      {
        PipeBendDiskBlocks pipeBendDiskBlocks = (PipeBendDiskBlocks) new buDrillCalc(FoamCalcVars.DiskBlocks[((F_LaserMaterial) this).SelectedIndex]);
        FoamCalcVars.DiskBlocks.Add(pipeBendDiskBlocks);
        ((F_NestExecute) this).treeView_bend = ((SewingJobItem) buCall.\u0001).UpdateItems(((F_NestExecute) this).treeView_bend);
      }
      if (control2.Name == ((F_NestExecute) this).btnn_remove.Name && ((F_LaserMaterial) this).SelectedIndex >= 0 & ((F_LaserMaterial) this).SelectedIndex <= FoamCalcVars.DiskBlocks.Count - 1 && buNumeric5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWantToDelete) == DialogResult.Yes)
      {
        FoamCalcVars.DiskBlocks.RemoveAt(((F_LaserMaterial) this).SelectedIndex);
        if (((F_LaserMaterial) this).SelectedIndex > 0)
          ((F_LaserMaterial) this).SelectedIndex = ((F_LaserMaterial) this).SelectedIndex - 1;
        if (FoamCalcVars.DiskBlocks.Count == 0)
        {
          ((F_LaserMaterial) this).SelectedIndex = -1;
          ((F_LaserMaterial) this).DiskIndex = -1;
        }
        ((F_NestExecute) this).treeView_bend = ((SewingJobItem) buCall.\u0001).UpdateItems(((F_NestExecute) this).treeView_bend);
      }
      if (control2.Name == ((F_NestExecute) this).btn_save.Name)
        ;
      if (control2.Name == ((F_NestExecute) this).btn_open.Name)
        ;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_LaserMaterial) this).PropertiesForm.sClassName, str, ex.Message, "Exception");
      buException.throwException(ex, str, false, ((F_LaserMaterial) this).PropertiesForm.sClassName);
    }
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    string str = "spn_ValueChanged";
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (!((F_LaserMaterial) this).PropertiesForm.Inited || !(obj1.KeyCode == Keys.Return | obj1.KeyCode == Keys.Tab))
        return;
      int result = 0;
      int.TryParse(control2.Tag.ToString(), out result);
    }
    catch (Exception ex)
    {
      ((F_LaserMaterial) this).PropertiesForm.Inited = true;
      buLogVer5.addToLog(((F_LaserMaterial) this).PropertiesForm.sClassName, str, ex.Message, "Exception");
      buException.throwException(ex, str, false, ((F_LaserMaterial) this).PropertiesForm.sClassName);
    }
  }

  internal void \u0001([In] object obj0, [In] double obj1)
  {
    string str = "spn_ValueChanged";
    try
    {
      if (!((F_LaserMaterial) this).PropertiesForm.Inited)
        return;
      ((F_Layer) this).ControlsToItem();
      ((F_Layer) this).DrawDiskBlock(((F_LaserMaterial) this).SelectedIndex, ((F_LaserMaterial) this).DiskIndex);
    }
    catch (Exception ex)
    {
      ((F_LaserMaterial) this).PropertiesForm.Inited = true;
      buLogVer5.addToLog(((F_LaserMaterial) this).PropertiesForm.sClassName, str, ex.Message, "Exception");
      buException.throwException(ex, str, false, ((F_LaserMaterial) this).PropertiesForm.sClassName);
    }
  }
}
