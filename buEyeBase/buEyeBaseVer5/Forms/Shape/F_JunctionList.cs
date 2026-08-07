// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Shape.F_JunctionList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.SheetBending;
using buEyeBaseVer5.Forms.Simulation;
using buEyeBaseVer5.Forms.Text;
using buEyeBaseVer5.Forms.Viewport;
using devDept.Eyeshot.Entities;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Shape;

public class F_JunctionList : Form
{
  public double StitchLen;
  private IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal Panel \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0001;
  internal Label \u0003;
  internal NumericUpDown \u0002;
  internal Label \u0004;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  public static byte f0010E1;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public TuftingSettings Settings;
  public int SelectedLayerIndex;
  public string SelectedLayerName;
  public List<LayerBase5> Layers;
  internal IContainer \u0001;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  internal Panel \u0001;
  internal PictureBox \u0001;
  internal Panel \u0002;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal RadioButton \u0006;
  internal RadioButton \u0007;
  internal RadioButton \u0008;
  internal CheckBox \u0001;
  internal ListView \u0001;
  internal CheckBox \u0002;
  public static byte f0010FC;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public TuftingSettings Settings;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal Panel \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal NumericUpDown \u0001;
  internal NumericUpDown \u0002;
  internal Label \u0004;
  internal NumericUpDown \u0003;
  public static byte f00110C;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (((F_TextWireframe) this).\u0001.SelectedItems.Count <= 0)
      return;
    ((F_ViewportMouseCfg) this).\u0001 = ((F_TextWireframe) this).\u0001.SelectedItems[0].Index;
    if (((F_ViewportMouseCfg) this).\u0001 >= 0)
    {
      for (int index = 0; index <= ((F_ViewportMouseCfg) this).\u0001.Entities.Count - 1; ++index)
        ((F_ViewportMouseCfg) this).\u0001.Entities[index].Selected = false;
      ((F_ViewportMouseCfg) this).\u0001.Entities[((F_ViewportMouseCfg) this).\u0001].Selected = true;
      if (((F_ViewportMouseCfg) this).\u0001.Entities.Count >= 2)
      {
        if (((F_ViewportMouseCfg) this).\u0001.Entities[((F_ViewportMouseCfg) this).\u0001.Entities.Count - 1] is Brep)
          ((F_ViewportMouseCfg) this).\u0001.Entities.RemoveAt(((F_ViewportMouseCfg) this).\u0001.Entities.Count - 1);
        if (((F_ViewportMouseCfg) this).\u0001.Entities[((F_ViewportMouseCfg) this).\u0001.Entities.Count - 1] is Brep)
          ((F_ViewportMouseCfg) this).\u0001.Entities.RemoveAt(((F_ViewportMouseCfg) this).\u0001.Entities.Count - 1);
      }
      Brep box = Brep.CreateBox(10.0, 10.0, 1.0);
      box.Translate(((ICurve) ((F_ViewportMouseCfg) this).\u0001.Entities[((F_ViewportMouseCfg) this).\u0001]).StartPoint.X - 5.0, ((ICurve) ((F_ViewportMouseCfg) this).\u0001.Entities[((F_ViewportMouseCfg) this).\u0001]).StartPoint.Y - 5.0, -1.5);
      box.ColorMethod = colorMethodType.byEntity;
      box.Color = Color.Lime;
      ((F_ViewportMouseCfg) this).\u0001.Entities.Add((Entity) box);
      Brep cylinder = Brep.CreateCylinder(5.0, 1.0);
      cylinder.Translate(((ICurve) ((F_ViewportMouseCfg) this).\u0001.Entities[((F_ViewportMouseCfg) this).\u0001]).EndPoint.X, ((ICurve) ((F_ViewportMouseCfg) this).\u0001.Entities[((F_ViewportMouseCfg) this).\u0001]).EndPoint.Y, -1.5);
      cylinder.ColorMethod = colorMethodType.byEntity;
      cylinder.Color = Color.Cyan;
      ((F_ViewportMouseCfg) this).\u0001.Entities.Add((Entity) cylinder);
    }
    ((F_ViewportMouseCfg) this).\u0001.Invalidate();
  }

  private void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (((F_ViewportMouseCfg) this).\u0002 >= 0 & ((F_ViewportMouseCfg) this).\u0002 <= ((buEyeBaseVer5.Apps.ProfileItem) ((F_ViewportMouseCfg) this).TuftSequence).SortedEntities.Count - 1)
    {
      ((F_TextWireframe) this).\u0001.SelectedItems.Clear();
      ((F_TextWireframe) this).\u0001.Items[((F_ViewportMouseCfg) this).\u0002].Selected = true;
      ((F_ViewportMouseCfg) this).\u0002 = ((F_ViewportMouseCfg) this).\u0002 + 1;
    }
    else
    {
      ((F_ViewportMouseCfg) this).\u0002 = 0;
      ((F_ViewportMouseCfg) this).\u0001.Enabled = false;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ViewportMouseCfg) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ViewportMouseCfg) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_JunctionList() => F_ViewportMouseCfg.Captions = new List<string>();

  public F_JunctionList()
  {
    ((F_SimulationPanel) this).PropertiesForm = new FormProperties();
    ((F_SimulationPanel) this).Images = new List<Picture>();
    ((F_SimulationPanel) this).ImageIndex = new List<int>();
    ((F_SimulationPanel) this).\u0001 = -1;
    ((F_SheetBendData) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_TuftingImageList) this);
  }

  public void Init()
  {
    ((F_SimulationPanel) this).PropertiesForm.Inited = false;
    ((F_SheetBendData) this).\u0001.HeaderStyle = ColumnHeaderStyle.None;
    ((F_SheetBendData) this).\u0001.View = System.Windows.Forms.View.Details;
    ((F_SheetBendData) this).\u0001.FullRowSelect = true;
    ((F_SheetBendData) this).\u0001.Columns.Add("", -2);
    ((F_SheetBendData) this).\u0001.Columns[0].Width = ((F_SheetBendData) this).\u0001.Width - 5;
    for (int index = 0; index <= ((F_SimulationPanel) this).Images.Count - 1; ++index)
    {
      string text = "Img" + (index + 1).ToString();
      if (((CutterRuntimeSettings) ((F_SimulationPanel) this).Images[index].EntityData).get_infoString() != null && ((CutterRuntimeSettings) ((F_SimulationPanel) this).Images[index].EntityData).get_infoString().Length > 0)
      {
        string withoutExtension = buFile5.bunesting.getFileNameWithoutExtension(((CutterRuntimeSettings) ((F_SimulationPanel) this).Images[index].EntityData).get_infoString());
        if (withoutExtension.Length > 0)
          text = withoutExtension;
      }
      ((F_SheetBendData) this).\u0001.Items.Add(new ListViewItem(text));
    }
    if (((F_SheetBendData) this).\u0001.Items.Count > 0)
      ((F_SheetBendData) this).\u0001.Items[0].Selected = true;
    this.LoadLanguage();
    ((F_SimulationPanel) this).PropertiesForm.Result = DialogResult.None;
    ((F_SimulationPanel) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = "NestSheetPart LoadLanguage";
    try
    {
      if (F_SimulationPanel.Captions.Count < 33)
        return;
      this.Text = F_SimulationPanel.Captions[0];
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

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (obj0.GetType() == typeof (Control) | obj0.GetType() == typeof (Button))
    {
      control = (Control) obj0;
      string name = control.Name;
    }
    if (obj0.GetType() == typeof (ToolStripMenuItem))
    {
      string name1 = ((ToolStripItem) obj0).Name;
    }
    if (control.Name == ((F_SheetBendData) this).\u0001.Name)
    {
      this.Apply();
      ((F_SimulationPanel) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_SimulationPanel) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_SimulationPanel) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control.Name == ((F_SheetBendData) this).\u0002.Name))
      return;
    ((F_SimulationPanel) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_SimulationPanel) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_SimulationPanel) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_SimulationPanel) this).PropertiesForm.Inited || ((F_SheetBendData) this).\u0001.SelectedItems.Count <= 0 || !(((F_SheetBendData) this).\u0001.SelectedItems[0].Index >= 0 & ((F_SheetBendData) this).\u0001.SelectedItems[0].Index <= ((F_SimulationPanel) this).Images.Count - 1))
      return;
    ((F_SimulationPanel) this).PropertiesForm.Inited = false;
    ((F_SimulationPanel) this).\u0001 = ((F_SheetBendData) this).\u0001.SelectedItems[0].Index;
    using (MemoryStream memoryStream = new MemoryStream(((F_SimulationPanel) this).Images[((F_SimulationPanel) this).\u0001].Image))
      ((F_SheetBendData) this).\u0001.Image = Image.FromStream((Stream) memoryStream);
    ((F_SheetBendData) this).\u0001.Checked = ((F_SimulationPanel) this).Images[((F_SimulationPanel) this).\u0001].Selectable;
    ((F_SheetBendData) this).\u0002.Checked = ((F_SimulationPanel) this).Images[((F_SimulationPanel) this).\u0001].Visible;
    ((F_SimulationPanel) this).PropertiesForm.Inited = true;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_SimulationPanel) this).PropertiesForm.Inited || ((F_SimulationPanel) this).\u0001 < 0)
      return;
    ((F_SimulationPanel) this).Images[((F_SimulationPanel) this).\u0001].Visible = ((F_SheetBendData) this).\u0002.Checked;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_SimulationPanel) this).PropertiesForm.Inited || ((F_SimulationPanel) this).\u0001 < 0)
      return;
    ((F_SimulationPanel) this).Images[((F_SimulationPanel) this).\u0001].Selectable = ((F_SheetBendData) this).\u0001.Checked;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_SheetBendData) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_SheetBendData) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_JunctionList() => F_SimulationPanel.Captions = new List<string>();

  public F_JunctionList()
  {
    ((F_SheetBendData) this).PropertiesForm = new FormProperties();
    ((F_SheetBendData) this).Settings = new TuftingSettings();
    ((F_SheetBendData) this).TuftingMode = tuftingStitchModeType.Cut;
    ((F_SheetBendData) this).PileHeight = 0.0;
    this.StitchLen = 0.0;
    this.\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_TuftingSetProps) this);
  }

  public void Init()
  {
    ((F_SheetBendData) this).PropertiesForm.Inited = false;
    if (((F_SheetBendData) this).PropertiesForm.Height > 10)
      this.Height = ((F_SheetBendData) this).PropertiesForm.Height;
    if (((F_SheetBendData) this).PropertiesForm.Width > 10)
      this.Width = ((F_SheetBendData) this).PropertiesForm.Width;
    this.TopMost = ((F_SheetBendData) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_SheetBendData) this).PropertiesForm.FormPosition;
    this.\u0001.Value = (Decimal) ((F_SheetBendData) this).PileHeight;
    this.\u0002.Value = (Decimal) this.StitchLen;
    if (((F_SheetBendData) this).TuftingMode == tuftingStitchModeType.Cut)
      this.\u0002.Checked = true;
    else if (((F_SheetBendData) this).TuftingMode == tuftingStitchModeType.Loop)
      this.\u0001.Checked = true;
    else
      this.\u0003.Checked = true;
    this.ControlUpdate();
    this.LoadLanguage();
    ((F_SheetBendData) this).PropertiesForm.Result = DialogResult.None;
    ((F_SheetBendData) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_SheetBendData.Captions.Count >= 9)
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
    if (((F_SheetBendData) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_SheetBendData) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_SheetBendData) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_SheetBendData) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.btn_ok.Name)
    {
      ((F_SheetBendData) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_SheetBendData) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_SheetBendData) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      ((F_SheetBendData) this).PileHeight = (double) this.\u0001.Value;
      this.StitchLen = (double) this.\u0002.Value;
      if (this.\u0002.Checked)
        ((F_SheetBendData) this).TuftingMode = tuftingStitchModeType.Cut;
      else if (this.\u0001.Checked)
        ((F_SheetBendData) this).TuftingMode = tuftingStitchModeType.Loop;
      else
        ((F_SheetBendData) this).TuftingMode = tuftingStitchModeType.None;
    }
    if (!(control2.Name == this.btn_cancel.Name))
      return;
    ((F_SheetBendData) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_SheetBendData) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_SheetBendData) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
  }

  public event OkCommandWithTwoDataEventHandler DataOk;

  public event CancelCommandEventHandler DataCancel;
}
