// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSawMillingRough
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using dummy_ptr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSawMillingRough : Form
{
  public buSpin spn_drillpocketdepthstep;
  public buSpin spn_drillpocketcontouroffset;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public marbleCavityPars varSettings;
  public MarbleToolType ToolType;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buSpin spn_ang;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buSpin spn_length;
  public buSpin spn_height;
  public buSpin spn_count;
  public buSpin spn_depth;
  public buSpin spn_space;

  public void Init()
  {
    ((F_MarbleSawMillingCam) this).PropertiesForm.Inited = false;
    if (((F_MarbleSawMillingCam) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleSawMillingCam) this).PropertiesForm.Height;
    if (((F_MarbleSawMillingCam) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleSawMillingCam) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleSawMillingCam) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleSawMillingCam) this).PropertiesForm.FormPosition;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleMaterialList) this);
    \u0007.\u0001.\u0001((F_MarbleMaterialList) this);
    for (int index = 0; index <= ((F_MarbleSawMillingCam) this).\u0001.Items.Count - 1; ++index)
    {
      if (((F_MarbleSawMillingCam) this).\u0001.Items[index].ToString().Trim() == ((marbleSlatPars) ((F_MarbleSawMillingCam) this).Settings).MaterialName)
      {
        ((F_MarbleSawMillingCam) this).\u0001.SelectedIndex = index;
        break;
      }
    }
    ((F_MarbleSawMillingCam) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleSawMillingCam) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_MarbleMaterialList) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleSawMillingCam) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleSawMillingCam) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSawMillingCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSawMillingCam) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleSawMillingCam) this).btn_ok.Name)
      {
        this.Apply();
        ((F_MarbleSawMillingCam) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleSawMillingCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleSawMillingCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleSawMillingCam) this).btn_close.Name | control2.Name == ((F_MarbleSawMillingCam) this).btn_cancel.Name)
      {
        ((F_MarbleSawMillingCam) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_MarbleSawMillingCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleSawMillingCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleProfileCurveCam) this).btn_save.Name)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = AppPath.Materials;
        saveFileDialog.Filter = "Marble Material Files (*.bumarblemats) |*.bumarblemats";
        saveFileDialog.FilterIndex = 1;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          this.Apply();
          ArrayList StringList = new ArrayList();
          StringList.AddRange((ICollection) ((F_MarbleSawMillingCam) this).Settings.ToDefAll("", 0, (SerilizationMode5) 1));
          buVector5.SaveToFile(StringList, saveFileDialog.FileName);
          \u0007.\u0001.\u0001((F_MarbleMaterialList) this);
        }
      }
      if (!(control2.Name == ((F_MarbleProfileCurveCam) this).btn_open.Name))
        return;
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = AppPath.Materials;
      openFileDialog.Filter = "Marble Material Files (*.bumarblemats) |*.bumarblemats";
      openFileDialog.FilterIndex = 1;
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      ((F_MarbleSawMillingCam) this).PropertiesForm.Inited = false;
      List<string> StringList1 = new List<string>();
      buVector5.OpenFromFile(openFileDialog.FileName, ref StringList1);
      buSerilization5.Decode(StringList1, "", (SerilizationMode5) 1, (object) ((F_MarbleSawMillingCam) this).Settings);
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleMaterialList) this);
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_MarbleSawMillingCam) this).PropertiesForm.Inited)
      return;
    buSpin buSpin = obj0 as buSpin;
    buSpin.Display.BackColor = clsVisualVars.parVisual.colorDataFocus;
    buSpin.SelectAll();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    FileInfo fileInfo1 = new FileInfo($"{AppPath.Materials}\\{((F_MarbleSawMillingCam) this).\u0001.Items[((F_MarbleSawMillingCam) this).\u0001.SelectedIndex].ToString()}.bumarblemats");
    if (!fileInfo1.Exists)
      return;
    ((F_MarbleSawMillingCam) this).PropertiesForm.Inited = false;
    List<string> StringList = new List<string>();
    buVector5.OpenFromFile(fileInfo1.FullName, ref StringList);
    buSerilization5.Decode(StringList, "", (SerilizationMode5) 1, (object) ((F_MarbleSawMillingCam) this).Settings);
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleMaterialList) this);
    FileInfo fileInfo2 = new FileInfo($"{AppPath.Materials}\\{((F_MarbleSawMillingCam) this).\u0001.Items[((F_MarbleSawMillingCam) this).\u0001.SelectedIndex].ToString()}.jpg");
    ((F_MarbleSawMillingCam) this).\u0001.Image = (Image) null;
    if (fileInfo2.Exists)
    {
      ((F_MarbleSawMillingCam) this).\u0001.Image = Image.FromFile(fileInfo2.FullName);
    }
    else
    {
      FileInfo fileInfo3 = new FileInfo($"{AppPath.Materials}\\{((F_MarbleSawMillingCam) this).\u0001.Items[((F_MarbleSawMillingCam) this).\u0001.SelectedIndex].ToString()}.png");
      if (fileInfo3.Exists)
      {
        ((F_MarbleSawMillingCam) this).\u0001.Image = Image.FromFile(fileInfo3.FullName);
      }
      else
      {
        FileInfo fileInfo4 = new FileInfo($"{AppPath.Materials}\\{((F_MarbleSawMillingCam) this).\u0001.Items[((F_MarbleSawMillingCam) this).\u0001.SelectedIndex].ToString()}.bmp");
        if (fileInfo4.Exists)
          ((F_MarbleSawMillingCam) this).\u0001.Image = Image.FromFile(fileInfo4.FullName);
      }
    }
    ((F_MarbleSawMillingCam) this).PropertiesForm.Inited = false;
  }
}
