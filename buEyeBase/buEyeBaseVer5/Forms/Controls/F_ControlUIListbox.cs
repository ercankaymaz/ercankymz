// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Controls.F_ControlUIListbox
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buCore;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Customer.DincMak;
using buEyeBaseVer5.Forms.File;
using devDept.Eyeshot.Control;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUIListbox : Form
{
  public buSpin spn_movex;
  public TabPage tabPage_lineararray;
  public TabPage tabPage_mirror;
  public TabPage tabPage_copy;
  public TabPage tabPage_rotate;
  public TabPage tabPage_circulararray;
  public buSpin spn_scalex;
  public buSpin spn_scaley;
  internal PictureBox \u0002;
  public buSpin spn_lineararraydisx;
  public buSpin spn_lineararraydisy;
  public buSpin spn_lineararraycountx;
  public buSpin spn_lineararraycounty;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_VShapePocket) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_VShapePocket) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_VShapePocket) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_VShapePocket) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_VShapePocket) this).\u0001.Name)
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.SelectedPath = ((F_VShapePocket) this).Path;
      if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        ((F_VShapePocket) this).Path = folderBrowserDialog.SelectedPath;
      ((F_ControlUIPanel) this).Init();
    }
    if (control2.Name == ((F_ControlUICheck) this).\u000E.Name)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "All Files |";
      for (int index = 0; index <= ((F_VShapePocket) this).ExtensionList.Count - 1; ++index)
      {
        if (index <= ((F_VShapePocket) this).ExtensionList.Count - 1)
          openFileDialog.Filter = $"{openFileDialog.Filter}*{((F_VShapePocket) this).ExtensionList[index]};";
      }
      openFileDialog.InitialDirectory = ((F_VShapePocket) this).Path;
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        \u0007.\u0001.\u0001(openFileDialog.FileName, (F_AddImageFromFile) this);
        ((F_VShapePocket) this).\u0001 = buFile5.bunesting.getFileNameWithoutExtension(openFileDialog.FileName);
        ((F_VShapePocket) this).Path = buFile5.bunesting.GetPath(openFileDialog.FileName);
        ((F_VShapePocket) this).\u0001.Clear();
        ((F_VShapePocket) this).\u0001 = new List<string>();
      }
    }
    if (control2.Name == ((F_ControlUICheck) this).\u0008.Name && ((F_VShapePocket) this).\u0002 >= 0)
    {
      FileInfo fileInfo = new FileInfo($"{((F_VShapePocket) this).Path}\\{((F_ControlUICheck) this).grid_files.Rows[((F_VShapePocket) this).\u0002].Cells[1].Value.ToString()}");
      if (fileInfo.Exists)
      {
        string fileName = buFile.getFileName(fileInfo.FullName);
        if (buString.MessageBoxQuestion($"{AppLanguage.CadCamMessages[107]} : {fileName}") == DialogResult.Yes)
        {
          fileInfo.Delete();
          \u0007.\u0001.\u0001((F_AddImageFromFile) this);
        }
      }
    }
    if (control2.Name == ((F_VShapePocket) this).\u0004.Name)
    {
      ((F_VShapePocket) this).\u0001.Add("RotateLeft");
      ((F_VShapePocket) this).PropertiesForm.Inited = true;
    }
    if (control2.Name == ((F_ControlUICheck) this).\u0005.Name)
    {
      ((F_VShapePocket) this).\u0001.Add("RotateRight");
      ((F_VShapePocket) this).PropertiesForm.Inited = true;
    }
    if (control2.Name == ((F_ControlUICheck) this).\u0006.Name)
    {
      ((F_VShapePocket) this).\u0001.Add("MirrorHorizontal");
      ((F_VShapePocket) this).PropertiesForm.Inited = true;
    }
    if (control2.Name == ((F_ControlUICheck) this).\u0007.Name)
    {
      ((F_VShapePocket) this).\u0001.Add("MirrorVertical");
      ((F_VShapePocket) this).PropertiesForm.Inited = true;
    }
    if (control2.Name == ((F_VShapePocket) this).\u0003.Name)
    {
      ((F_VShapePocket) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_VShapePocket) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_VShapePocket) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_VShapePocket) this).\u0002.Name))
      return;
    ((F_VShapePocket) this).refImage = ((F_ControlUICheck) this).\u0001.Image;
    ((F_VShapePocket) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_VShapePocket) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_VShapePocket) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_VShapePocket) this).PropertiesForm.Inited)
      return;
    System.Windows.Forms.Control control = new System.Windows.Forms.Control();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      int num = 1;
      ((F_VShapePocket) this).\u0001 = true;
      if (((F_VShapePocket) this).\u0001.Text.Length == 0)
      {
        \u0007.\u0001.\u0001((F_AddImageFromFile) this);
      }
      else
      {
        ((F_ControlUICheck) this).grid_files.Rows.Clear();
        for (int index = 0; index <= ((F_VShapePocket) this).\u0002.Count - 1; ++index)
        {
          string fileName = buFile.getFileName(((F_VShapePocket) this).\u0002[index]);
          if (fileName.ToLower().IndexOf(((F_VShapePocket) this).\u0001.Text.ToLower()) >= 0)
          {
            ((F_ControlUICheck) this).grid_files.Rows.Add((object) num, (object) fileName);
            ++num;
          }
        }
      }
      ((F_VShapePocket) this).\u0001 = false;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_VShapePocket) this).PropertiesForm.Inited)
      return;
    ((F_VShapePocket) this).KeepRatio = ((F_ControlUICheck) this).\u0001.Checked;
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    ((F_VShapePocket) this).\u0001 = obj1.ColumnIndex;
    ((F_VShapePocket) this).\u0002 = obj1.RowIndex;
    if (((F_VShapePocket) this).\u0002 < 0)
      return;
    \u0007.\u0001.\u0001($"{((F_VShapePocket) this).Path}\\{((F_ControlUICheck) this).grid_files.Rows[((F_VShapePocket) this).\u0002].Cells[1].Value.ToString()}", (F_AddImageFromFile) this);
    ((F_VShapePocket) this).\u0001 = ((F_ControlUICheck) this).grid_files.Rows[((F_VShapePocket) this).\u0002].Cells[1].Value.ToString();
    ((F_VShapePocket) this).\u0001.Clear();
    ((F_VShapePocket) this).\u0001 = new List<string>();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_VShapePocket) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_VShapePocket) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public abstract void m0015A4();

  public F_ControlUIListbox()
  {
    ((F_ControlUICheck) this).PropertiesForm = new FormProperties();
    ((F_ControlUICheck) this).EntitiesTransformed = new List<buEntity>();
    ((F_ControlUICheck) this).Layers = new List<LayerBase5>();
    ((F_ControlUICoordinate) this).Path = Application.StartupPath;
    ((F_ControlUICoordinate) this).FileName = Application.StartupPath;
    ((F_ControlUICoordinate) this).KeepRatio = true;
    ((F_ControlUICoordinate) this).MoveEntities = true;
    ((F_ControlUICoordinate) this).MoveReverse = false;
    ((F_ControlUICoordinate) this).MoveRef = MinMaxType.Min;
    ((F_ControlUICoordinate) this).viewport = (Design) null;
    ((F_ControlUICoordinate) this).ExtensionList = new List<string>();
    ((F_ControlUICoordinate) this).\u0001 = new List<string>();
    ((F_ControlUICoordinate) this).\u0001 = -1;
    ((F_ControlUICoordinate) this).\u0002 = -1;
    ((F_ControlUICoordinate) this).\u0001 = "";
    ((F_ControlUICoordinate) this).\u0001 = false;
    ((F_ControlUICoordinate) this).\u0001 = new Point3D();
    ((F_ControlUICoordinate) this).\u0002 = new Point3D();
    ((F_ControlUICoordinate) this).\u0003 = new Point3D();
    ((F_ControlUICoordinate) this).\u0002 = new List<string>();
    ((F_ControlUIGround) this).\u0001 = (System.Windows.Forms.Timer) null;
    ((F_ControlUIGround) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_AddFromFile) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_ReadFile(OkCommandWithTwoDataEventHandler value)
  {
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_ControlUICheck) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_ControlUICheck) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_ReadFile(OkCommandWithTwoDataEventHandler value)
  {
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_ControlUICheck) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_ControlUICheck) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }
}
