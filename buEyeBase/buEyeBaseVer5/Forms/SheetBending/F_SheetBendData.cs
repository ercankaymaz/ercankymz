// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.SheetBending.F_SheetBendData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Shape;
using buEyeBaseVer5.Forms.Simulation;
using buEyeBaseVer5.Forms.Text;
using buEyeBaseVer5.Forms.Viewport;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.SheetBending;

public class F_SheetBendData : Form
{
  internal IContainer \u0001;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  internal ListView \u0001;
  internal PictureBox \u0001;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  public static byte f0010CC;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public TuftingSettings Settings;
  public tuftingStitchModeType TuftingMode;
  public double PileHeight;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (((F_ViewportMouseCfg) this).PropertiesForm.Inited)
      ;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ViewportMouseCfg) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ViewportMouseCfg) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_SheetBendData() => F_ViewportMouseCfg.Captions = new List<string>();

  public F_SheetBendData()
  {
    ((F_ViewportMouseCfg) this).PropertiesForm = new FormProperties();
    ((F_ViewportMouseCfg) this).TuftSequence = (TuftingSequenceItem) new buProfileCalc();
    ((F_ViewportMouseCfg) this).AllEntities = new List<Entity>();
    ((F_ViewportMouseCfg) this).layerSelected = (LayerBase5) new EntityShapeInfo();
    ((F_ViewportMouseCfg) this).\u0001 = (Design) null;
    ((F_ViewportMouseCfg) this).\u0001 = Color.Black;
    ((F_ViewportMouseCfg) this).\u0001 = -1;
    ((F_ViewportMouseCfg) this).\u0002 = -1;
    ((F_ViewportMouseCfg) this).\u0003 = -1;
    ((F_ViewportMouseCfg) this).\u0004 = -1;
    ((F_ViewportMouseCfg) this).\u0001 = new Timer();
    ((F_ViewportMouseCfg) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_TuftingExchange) this);
  }

  public void Init()
  {
    ((F_ViewportMouseCfg) this).PropertiesForm.Inited = false;
    if (((F_ViewportMouseCfg) this).PropertiesForm.Height > 10)
      this.Height = ((F_ViewportMouseCfg) this).PropertiesForm.Height;
    if (((F_ViewportMouseCfg) this).PropertiesForm.Width > 10)
      this.Width = ((F_ViewportMouseCfg) this).PropertiesForm.Width;
    this.TopMost = ((F_ViewportMouseCfg) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_ViewportMouseCfg) this).PropertiesForm.FormPosition;
    if (((F_ViewportMouseCfg) this).\u0001 == null)
    {
      EyeCreateProps Properties = (EyeCreateProps) new ShapeEdit();
      ((DiameterDepthPoint) Properties).ShowToolBar = false;
      ((DiameterDepthPoint) Properties).ShowViewCube = false;
      ((MaterialBase5) Properties).ShowCoordinateArrow = false;
      buConversion5.CreateControlsTool(true, Properties, ref ((F_ViewportMouseCfg) this).\u0001);
      ((F_ViewportMouseCfg) this).\u0001.Dock = DockStyle.Fill;
      ((F_TextWireframe) this).\u0002.Controls.Add((System.Windows.Forms.Control) ((F_ViewportMouseCfg) this).\u0001);
    }
    ((F_TextWireframe) this).\u0001.HeaderStyle = ColumnHeaderStyle.None;
    ((F_TextWireframe) this).\u0001.View = System.Windows.Forms.View.Details;
    ((F_TextWireframe) this).\u0001.FullRowSelect = true;
    ((F_TextWireframe) this).\u0001.Columns.Add("", -2);
    ((F_TextWireframe) this).\u0001.Columns[0].Width = ((F_TextWireframe) this).\u0001.Width - 5;
    ((F_TextWireframe) this).\u0001.Text = ((DevideEventFormVars) ((F_ViewportMouseCfg) this).layerSelected).Name;
    for (int index = 0; index <= ((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.Count - 1; ++index)
    {
      ((F_TextWireframe) this).\u0001.Items.Add(new ListViewItem((index + 1).ToString() + " - Path")
      {
        Checked = true
      });
      Entity copiedEnt = (Entity) null;
      buVector5.CopyEntities(((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities[index], ref copiedEnt);
      copiedEnt.ColorMethod = colorMethodType.byEntity;
      copiedEnt.LayerName = ((F_ViewportMouseCfg) this).\u0001.Layers[0].Name;
      copiedEnt.Color = ((DevideEventFormVars) ((F_ViewportMouseCfg) this).layerSelected).LayerColor;
      copiedEnt.LineWeightMethod = colorMethodType.byEntity;
      copiedEnt.LineWeight = 2f;
      ((F_ViewportMouseCfg) this).\u0001.Entities.Add(copiedEnt);
      ((F_ViewportMouseCfg) this).\u0001 = ((DevideEventFormVars) ((F_ViewportMouseCfg) this).layerSelected).LayerColor;
    }
    for (int index = 0; index <= ((F_ViewportMouseCfg) this).AllEntities.Count - 1; ++index)
    {
      Entity copiedEnt = (Entity) null;
      buVector5.CopyEntities(((F_ViewportMouseCfg) this).AllEntities[index], ref copiedEnt);
      copiedEnt.ColorMethod = colorMethodType.byEntity;
      copiedEnt.LayerName = ((F_ViewportMouseCfg) this).\u0001.Layers[0].Name;
      copiedEnt.Color = Color.Gray;
      ((F_ViewportMouseCfg) this).\u0001.Entities.Add(copiedEnt);
    }
    ((F_ViewportMouseCfg) this).\u0001.SetView(viewType.Top, true, false);
    ((F_ViewportMouseCfg) this).\u0001.Invalidate();
    this.LoadLanguage();
    ((F_ViewportMouseCfg) this).PropertiesForm.Result = DialogResult.None;
    ((F_ViewportMouseCfg) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_ViewportMouseCfg) this).\u0001.Interval = 50;
    ((F_ViewportMouseCfg) this).\u0001.Tick += new EventHandler(((F_JunctionList) this).\u0004);
  }

  public void LoadLanguage()
  {
    string callMethod = "NestSheetPart LoadLanguage";
    try
    {
      if (F_ViewportMouseCfg.Captions.Count < 33)
        return;
      this.Text = F_ViewportMouseCfg.Captions[0];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void Apply()
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = new System.Windows.Forms.Control();
    if (obj0.GetType() == typeof (System.Windows.Forms.Control) | obj0.GetType() == typeof (Button))
    {
      control = (System.Windows.Forms.Control) obj0;
      string name = control.Name;
    }
    if (obj0.GetType() == typeof (ToolStripMenuItem))
    {
      string name1 = ((ToolStripItem) obj0).Name;
    }
    if (control.Name == ((F_TextWireframe) this).\u0003.Name && ((F_ViewportMouseCfg) this).\u0001 >= 0)
    {
      if (((F_TextWireframe) this).\u0004.Checked)
      {
        Entity copiedEnt1 = (Entity) null;
        buVector5.CopyEntities(((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities[((F_ViewportMouseCfg) this).\u0001], ref copiedEnt1);
        ((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.RemoveAt(((F_ViewportMouseCfg) this).\u0001);
        ((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.Insert(0, copiedEnt1);
        Entity copiedEnt2 = (Entity) null;
        buVector5.CopyEntities(((F_ViewportMouseCfg) this).\u0001.Entities[((F_ViewportMouseCfg) this).\u0001], ref copiedEnt2);
        ((F_ViewportMouseCfg) this).\u0001.Entities.RemoveAt(((F_ViewportMouseCfg) this).\u0001);
        ((F_ViewportMouseCfg) this).\u0001.Entities.Insert(0, copiedEnt2);
        ((F_ViewportMouseCfg) this).\u0001.Entities.Regen();
        ((F_ViewportMouseCfg) this).\u0001.Invalidate();
        ((F_TextWireframe) this).\u0001.SelectedItems.Clear();
        ((F_TextWireframe) this).\u0001.Items[0].Selected = true;
        ((F_TextWireframe) this).\u0001.Invalidate();
      }
      else if (((F_TextWireframe) this).\u0002.Checked)
      {
        Entity copiedEnt3 = (Entity) null;
        buVector5.CopyEntities(((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities[((F_ViewportMouseCfg) this).\u0001], ref copiedEnt3);
        ((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.RemoveAt(((F_ViewportMouseCfg) this).\u0001);
        ((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.Add(copiedEnt3);
        Entity copiedEnt4 = (Entity) null;
        buVector5.CopyEntities(((F_ViewportMouseCfg) this).\u0001.Entities[((F_ViewportMouseCfg) this).\u0001], ref copiedEnt4);
        ((F_ViewportMouseCfg) this).\u0001.Entities.RemoveAt(((F_ViewportMouseCfg) this).\u0001);
        ((F_ViewportMouseCfg) this).\u0001.Entities.Insert(((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.Count - 1, copiedEnt4);
        ((F_ViewportMouseCfg) this).\u0001.Entities.Regen();
        ((F_ViewportMouseCfg) this).\u0001.Invalidate();
        ((F_TextWireframe) this).\u0001.SelectedItems.Clear();
        ((F_TextWireframe) this).\u0001.Items[((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.Count - 1].Selected = true;
        ((F_TextWireframe) this).\u0001.Invalidate();
      }
      else if (((F_TextWireframe) this).\u0003.Checked)
      {
        if (((F_ViewportMouseCfg) this).\u0001 >= 1)
        {
          Entity copiedEnt5 = (Entity) null;
          buVector5.CopyEntities(((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities[((F_ViewportMouseCfg) this).\u0001], ref copiedEnt5);
          ((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.RemoveAt(((F_ViewportMouseCfg) this).\u0001);
          ((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.Insert(((F_ViewportMouseCfg) this).\u0001 - 1, copiedEnt5);
          Entity copiedEnt6 = (Entity) null;
          buVector5.CopyEntities(((F_ViewportMouseCfg) this).\u0001.Entities[((F_ViewportMouseCfg) this).\u0001], ref copiedEnt6);
          ((F_ViewportMouseCfg) this).\u0001.Entities.RemoveAt(((F_ViewportMouseCfg) this).\u0001);
          ((F_ViewportMouseCfg) this).\u0001.Entities.Insert(((F_ViewportMouseCfg) this).\u0001 - 1, copiedEnt6);
          ((F_ViewportMouseCfg) this).\u0001.Entities.Regen();
          ((F_ViewportMouseCfg) this).\u0001.Invalidate();
          ((F_TextWireframe) this).\u0001.SelectedItems.Clear();
          ((F_TextWireframe) this).\u0001.Items[((F_ViewportMouseCfg) this).\u0001 - 1].Selected = true;
          ((F_TextWireframe) this).\u0001.Invalidate();
        }
      }
      else if (((F_TextWireframe) this).\u0001.Checked)
      {
        if (((F_ViewportMouseCfg) this).\u0001 < ((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.Count - 1)
        {
          Entity copiedEnt7 = (Entity) null;
          buVector5.CopyEntities(((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities[((F_ViewportMouseCfg) this).\u0001], ref copiedEnt7);
          ((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.RemoveAt(((F_ViewportMouseCfg) this).\u0001);
          ((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.Insert(((F_ViewportMouseCfg) this).\u0001 + 1, copiedEnt7);
          Entity copiedEnt8 = (Entity) null;
          buVector5.CopyEntities(((F_ViewportMouseCfg) this).\u0001.Entities[((F_ViewportMouseCfg) this).\u0001], ref copiedEnt8);
          ((F_ViewportMouseCfg) this).\u0001.Entities.RemoveAt(((F_ViewportMouseCfg) this).\u0001);
          ((F_ViewportMouseCfg) this).\u0001.Entities.Insert(((F_ViewportMouseCfg) this).\u0001 + 1, copiedEnt8);
          ((F_ViewportMouseCfg) this).\u0001.Entities.Regen();
          ((F_ViewportMouseCfg) this).\u0001.Invalidate();
          ((F_TextWireframe) this).\u0001.SelectedItems.Clear();
          ((F_TextWireframe) this).\u0001.Items[((F_ViewportMouseCfg) this).\u0001 + 1].Selected = true;
          ((F_TextWireframe) this).\u0001.Invalidate();
        }
      }
      else if (((F_SimulationPanel) this).\u0006.Checked)
      {
        if (((F_ViewportMouseCfg) this).\u0003 >= 0 & ((F_ViewportMouseCfg) this).\u0004 >= 0 & ((F_ViewportMouseCfg) this).\u0003 != ((F_ViewportMouseCfg) this).\u0004)
        {
          Entity copiedEnt9 = (Entity) null;
          buVector5.CopyEntities(((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities[((F_ViewportMouseCfg) this).\u0004], ref copiedEnt9);
          ((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.RemoveAt(((F_ViewportMouseCfg) this).\u0004);
          ((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.Insert(((F_ViewportMouseCfg) this).\u0003, copiedEnt9);
          Entity copiedEnt10 = (Entity) null;
          buVector5.CopyEntities(((F_ViewportMouseCfg) this).\u0001.Entities[((F_ViewportMouseCfg) this).\u0004], ref copiedEnt10);
          ((F_ViewportMouseCfg) this).\u0001.Entities.RemoveAt(((F_ViewportMouseCfg) this).\u0004);
          ((F_ViewportMouseCfg) this).\u0001.Entities.Insert(((F_ViewportMouseCfg) this).\u0003, copiedEnt10);
          ((F_ViewportMouseCfg) this).\u0001.Entities.Regen();
          ((F_ViewportMouseCfg) this).\u0001.Invalidate();
          ((F_TextWireframe) this).\u0001.SelectedItems.Clear();
          ((F_TextWireframe) this).\u0001.Items[((F_ViewportMouseCfg) this).\u0003].Selected = true;
          ((F_TextWireframe) this).\u0001.Invalidate();
        }
      }
      else if (((F_SimulationPanel) this).\u0006.Checked && ((F_ViewportMouseCfg) this).\u0003 >= 0 & ((F_ViewportMouseCfg) this).\u0004 >= 0 & ((F_ViewportMouseCfg) this).\u0003 != ((F_ViewportMouseCfg) this).\u0004)
      {
        Entity copiedEnt11 = (Entity) null;
        buVector5.CopyEntities(((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities[((F_ViewportMouseCfg) this).\u0004], ref copiedEnt11);
        ((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.RemoveAt(((F_ViewportMouseCfg) this).\u0004);
        if (((F_ViewportMouseCfg) this).\u0003 < ((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.Count - 1)
          ((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.Insert(((F_ViewportMouseCfg) this).\u0003 + 1, copiedEnt11);
        else
          ((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.Add(copiedEnt11);
        Entity copiedEnt12 = (Entity) null;
        buVector5.CopyEntities(((F_ViewportMouseCfg) this).\u0001.Entities[((F_ViewportMouseCfg) this).\u0004], ref copiedEnt12);
        ((F_ViewportMouseCfg) this).\u0001.Entities.RemoveAt(((F_ViewportMouseCfg) this).\u0004);
        if (((F_ViewportMouseCfg) this).\u0003 < ((F_ViewportMouseCfg) this).\u0001.Entities.Count - 1)
          ((F_ViewportMouseCfg) this).\u0001.Entities.Insert(((F_ViewportMouseCfg) this).\u0003 + 1, copiedEnt12);
        else
          ((F_ViewportMouseCfg) this).\u0001.Entities.Add(copiedEnt12);
        ((F_ViewportMouseCfg) this).\u0001.Entities.Regen();
        ((F_ViewportMouseCfg) this).\u0001.Invalidate();
        ((F_TextWireframe) this).\u0001.SelectedItems.Clear();
        ((F_TextWireframe) this).\u0001.Items[((F_ViewportMouseCfg) this).\u0003 + 1].Selected = true;
        ((F_TextWireframe) this).\u0001.Invalidate();
      }
    }
    if (control.Name == ((F_ViewportMouseCfg) this).\u0001.Name)
    {
      this.Apply();
      ((F_ViewportMouseCfg) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_ViewportMouseCfg) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ViewportMouseCfg) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control.Name == ((F_SimulationPanel) this).\u0006.Name && ((F_ViewportMouseCfg) this).\u0001 >= 0)
    {
      ((F_ViewportMouseCfg) this).\u0003 = ((F_ViewportMouseCfg) this).\u0001;
      for (int index = 0; index <= ((F_ViewportMouseCfg) this).\u0001.Entities.Count - 1; ++index)
      {
        if (((F_ViewportMouseCfg) this).\u0003 == index)
          ((F_ViewportMouseCfg) this).\u0001.Entities[index].Color = Color.Lime;
        else if (((F_ViewportMouseCfg) this).\u0004 == index)
          ((F_ViewportMouseCfg) this).\u0001.Entities[index].Color = Color.Cyan;
        else
          ((F_ViewportMouseCfg) this).\u0001.Entities[index].Color = ((F_ViewportMouseCfg) this).\u0001;
      }
      ((F_ViewportMouseCfg) this).\u0001.Invalidate();
    }
    if (control.Name == ((F_SimulationPanel) this).\u0007.Name && ((F_ViewportMouseCfg) this).\u0001 >= 0)
    {
      ((F_ViewportMouseCfg) this).\u0004 = ((F_ViewportMouseCfg) this).\u0001;
      for (int index = 0; index <= ((F_ViewportMouseCfg) this).\u0001.Entities.Count - 1; ++index)
      {
        if (((F_ViewportMouseCfg) this).\u0003 == index)
          ((F_ViewportMouseCfg) this).\u0001.Entities[index].Color = Color.Lime;
        else if (((F_ViewportMouseCfg) this).\u0004 == index)
          ((F_ViewportMouseCfg) this).\u0001.Entities[index].Color = Color.Cyan;
        else
          ((F_ViewportMouseCfg) this).\u0001.Entities[index].Color = ((F_ViewportMouseCfg) this).\u0001;
      }
      ((F_ViewportMouseCfg) this).\u0001.Invalidate();
    }
    if (control.Name == ((F_TextWireframe) this).\u0002.Name)
    {
      ((F_ViewportMouseCfg) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_ViewportMouseCfg) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ViewportMouseCfg) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control.Name == ((F_SimulationPanel) this).\u0004.Name)
    {
      ((F_ViewportMouseCfg) this).\u0001.Interval = (int) ((F_SimulationPanel) this).\u0001.Value;
      ((F_ViewportMouseCfg) this).\u0001.Enabled = true;
    }
    if (!(control.Name == ((F_SimulationPanel) this).\u0005.Name))
      return;
    if (((F_ViewportMouseCfg) this).\u0001.Enabled)
    {
      ((F_ViewportMouseCfg) this).\u0001.Enabled = false;
    }
    else
    {
      if (((F_ViewportMouseCfg) this).\u0001.Enabled)
        return;
      ((F_ViewportMouseCfg) this).\u0002 = 0;
    }
  }
}
