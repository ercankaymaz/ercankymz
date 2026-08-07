// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Holes.F_DrawingMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.UserFiles.buCad;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Events;
using buEyeBaseVer5.Forms.Library;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Holes;

public class F_DrawingMenu : Form
{
  internal Label \u0082;
  internal Label \u0083;
  internal Label \u0084;
  internal TextBox \u0001;
  internal TextBox \u0002;
  internal TextBox \u0003;
  internal Label \u0086;
  internal Label \u0087;
  internal Label \u0088;
  internal Label \u0089;
  internal TextBox \u0004;

  public F_DrawingMenu()
  {
    ((F_RotatePanel) this).PropertiesForm = new FormProperties();
    ((F_RotatePanel) this).OpenCustomData = new List<EditorCustomData>();
    ((F_RotatePanel) this).viewport = (Design) null;
    ((F_RotatePanel) this).\u0001 = -1;
    ((F_RotatePanel) this).\u0002 = -1;
    ((F_RotatePanel) this).\u0001 = new List<string>();
    ((F_RotatePanel) this).LibraryEntities = new List<buEntity>();
    ((F_RotatePanel) this).\u0001 = new Timer();
    ((F_RotatePanel) this).\u0002 = new Timer();
    ((F_RotatePanel) this).selectedEntity = (Entity) null;
    ((F_MirrorOP) this).\u0001 = false;
    ((F_MirrorOP) this).varLib = new setLibrary();
    ((F_MirrorOP) this).\u0001 = "Angle";
    ((F_MirrorOP) this).ShowAux = false;
    ((F_MirrorOP) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SketchLibrary) this);
    ((F_RotatePanel) this).\u0002.Interval = 100;
    ((F_RotatePanel) this).\u0002.Tick += new EventHandler(this.\u0003);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_RotatePanel) this).\u0001.Interval = 50;
    ((F_RotatePanel) this).\u0001.Tick += new EventHandler(this.\u0002);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_RotatePanel) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_RotatePanel) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_RotatePanel) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_RotatePanel) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Init()
  {
    ((F_RotatePanel) this).PropertiesForm.Inited = false;
    if (((F_RotatePanel) this).PropertiesForm.Height > 10)
      this.Height = ((F_RotatePanel) this).PropertiesForm.Height;
    if (((F_RotatePanel) this).PropertiesForm.Width > 10)
      this.Width = ((F_RotatePanel) this).PropertiesForm.Width;
    this.TopMost = ((F_RotatePanel) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_RotatePanel) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    DirectoryInfo dir = new DirectoryInfo(AppPath.Base + "\\L");
    if (dir.Exists)
    {
      this.setAttributesNormal(dir);
      dir.Delete(true);
    }
    if (((F_RotatePanel) this).viewport == null)
    {
      CreateModelProperties Properties = (CreateModelProperties) new ShapeEdit();
      ((ViewportDrawOptions) Properties).BottomColor = Color.WhiteSmoke;
      ((ViewportDrawOptions) Properties).TopColor = Color.Gainsboro;
      ((MaterialBase5) Properties).CoordinateSystemIconVisible = false;
      ((MaterialBase5) Properties).ViewCubeIconVisible = false;
      ((MaterialBase5) Properties).OrigineCaptionVisible = false;
      ((MaterialBase5) Properties).ToolBorVisible = false;
      ((MaterialBase5) Properties).OriginSymbolVisible = false;
      ((DrawingFinisedEvent) buCall.\u0001).CreateModelControl(ref ((F_RotatePanel) this).viewport, "", Properties);
      ((F_RotatePanel) this).viewport.MouseMove += new MouseEventHandler(((F_HoleMenu) this).\u0001);
      ((F_RotatePanel) this).viewport.MouseDown += new MouseEventHandler(((F_HoleMenu) this).\u0002);
      ((F_RotatePanel) this).viewport.MouseDoubleClick += new MouseEventHandler(((F_HoleMenu) this).\u0003);
      ((F_RotatePanel) this).viewport.WorkCompleted += new WorkUnit.WorkCompletedEventHandler(this.Desing_WorkCompleted);
      ((F_RotatePanel) this).viewport.Layers.Add(new Layer("Gen", Color.Blue));
      ((F_RotatePanel) this).viewport.Layers.RemoveAt(0);
      ((F_RotatePanel) this).viewport.Selection.Color = Color.DarkOrange;
      ((F_MirrorOP) this).\u0001.Controls.Add((System.Windows.Forms.Control) ((F_RotatePanel) this).viewport);
    }
    ((F_MirrorOP) this).\u0001 = false;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SketchLibrary) this);
    ((F_MirrorOP) this).\u0001.RowHeadersVisible = false;
    ((F_MirrorOP) this).\u0001.ColumnHeadersVisible = false;
    ((F_MirrorOP) this).\u0001.AllowUserToAddRows = false;
    ((F_MirrorOP) this).\u0001.AllowUserToResizeColumns = false;
    ((F_MirrorOP) this).\u0001.AllowUserToResizeRows = false;
    ((F_MirrorOP) this).\u0001.Columns.Clear();
    ((F_MirrorOP) this).\u0001.Rows.Clear();
    DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
    dataGridViewColumn1.Width = 180;
    dataGridViewColumn1.HeaderText = buLangTranslate.preDef.Name;
    dataGridViewColumn1.Name = "Name";
    dataGridViewColumn1.ReadOnly = true;
    dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    ((F_MirrorOP) this).\u0001.Columns.Add(dataGridViewColumn1);
    if (!((F_MirrorOP) this).ShowAux)
    {
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.Width = ((F_MirrorOP) this).\u0001.Width - dataGridViewColumn1.Width - 10;
      dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Value;
      dataGridViewColumn2.Name = "Value";
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.ReadOnly = false;
      ((F_MirrorOP) this).\u0001.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.Width = 1;
      dataGridViewColumn3.HeaderText = buLangTranslate.preDef.Value;
      dataGridViewColumn3.Name = "Aux";
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.Visible = false;
      ((F_MirrorOP) this).\u0001.Columns.Add(dataGridViewColumn3);
    }
    else
    {
      dataGridViewColumn1.Width = 140;
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.Width = 80 /*0x50*/;
      dataGridViewColumn4.HeaderText = buLangTranslate.preDef.Value;
      dataGridViewColumn4.Name = "Value";
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.ReadOnly = false;
      ((F_MirrorOP) this).\u0001.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.Width = ((F_MirrorOP) this).\u0001.Width - dataGridViewColumn1.Width - dataGridViewColumn4.Width - 10;
      dataGridViewColumn5.HeaderText = ((F_MirrorOP) this).\u0001;
      dataGridViewColumn5.Name = "Aux";
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.ReadOnly = false;
      ((F_MirrorOP) this).\u0001.Columns.Add(dataGridViewColumn5);
    }
    ((F_RotatePanel) this).selectedEntity = (Entity) null;
    ((F_RotatePanel) this).PropertiesForm.Result = DialogResult.None;
    ((F_RotatePanel) this).PropertiesForm.Inited = true;
    ((F_RotatePanel) this).\u0001.Enabled = true;
  }

  public void setAttributesNormal(DirectoryInfo dir)
  {
    foreach (DirectoryInfo directory in dir.GetDirectories())
      this.setAttributesNormal(directory);
    foreach (FileSystemInfo file in dir.GetFiles())
      file.Attributes = FileAttributes.Normal;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MirrorOP) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_MirrorOP) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_MirrorOP) this).\u0001.Caption.Caption = buLangTranslate.preDef.Search;
      ((F_MirrorOP) this).ground_base.Text = buLangTranslate.preDef.Library;
    }
    catch (Exception ex)
    {
    }
  }

  private void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      if (((F_MirrorOP) this).\u0001.Items.Count > 0)
        ((F_CutMenu) this).\u0006((object) null, (EventArgs) null);
      ((F_RotatePanel) this).\u0001.Enabled = false;
    }
    catch (Exception ex)
    {
    }
  }

  private void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      if (!((F_RotatePanel) this).viewport.IsHandleCreated)
        return;
      ((F_RotatePanel) this).\u0002.Enabled = false;
      ((F_RotatePanel) this).viewport.SetView(viewType.Top);
      if ((((F_RotatePanel) this).viewport.Entities == null ? 0 : (((F_RotatePanel) this).viewport.Entities.Count > 0 ? 1 : 0)) != 0)
      {
        ((F_RotatePanel) this).viewport.Entities.Regen();
        ((F_RotatePanel) this).viewport.Entities.RegenAllCurved();
        ((F_RotatePanel) this).viewport.ZoomFit(10);
        ((F_RotatePanel) this).viewport.UpdateBoundingBox();
      }
      ((F_RotatePanel) this).viewport.Invalidate();
    }
    catch (Exception ex)
    {
    }
  }

  public void Desing_WorkCompleted(object sender, WorkCompletedEventArgs e)
  {
    try
    {
      if (!(e.WorkUnit is ReadFileAsync))
        return;
      ReadFileAsync workUnit1 = (ReadFileAsync) e.WorkUnit;
      RegenOptions ro = new RegenOptions();
      ReadFile workUnit2 = e.WorkUnit as ReadFile;
      workUnit1.OpenTo((IDesign) ((F_RotatePanel) this).viewport, ro);
      ((F_CutMenu) this).FileOpened();
    }
    catch (Exception ex)
    {
    }
  }
}
