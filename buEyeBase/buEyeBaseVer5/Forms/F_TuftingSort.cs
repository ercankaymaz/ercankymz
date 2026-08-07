// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_TuftingSort
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.DialogBox;
using devDept.Eyeshot;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_TuftingSort : Form
{
  public FormProperties PropertiesForm;
  public SortSettings SortSetting;
  public static List<string> Captions;
  private IContainer \u0001;
  internal CheckBox \u0001;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal Panel \u0001;
  internal Panel \u0002;
  internal NumericUpDown \u0001;
  internal Label \u0001;
  internal NumericUpDown \u0002;
  internal Label \u0002;
  internal Label \u0003;
  internal NumericUpDown \u0003;
  internal Label \u0004;
  internal Label \u0005;
  internal ComboBox \u0001;
  internal CheckBox \u0002;
  internal Label \u0006;
  internal NumericUpDown \u0004;
  internal Label \u0007;
  internal ComboBox \u0002;
  internal Label \u0008;

  public void Init(
    viewType view,
    bool zoomFit,
    bool zoomAnimation,
    bool ViewToolbar,
    bool ViewCubeIcon,
    bool ViewOrigine,
    bool ViewCoordinate)
  {
    ((F_TuftingExchange) this).ZoomFit = zoomFit;
    ((F_TuftingExchange) this).View = view;
    ((F_TuftingExchange) this).ZoomAnimation = zoomAnimation;
    ((F_TuftingExchange) this).viewportLayout.ActiveViewport.ToolBar.Visible = ViewToolbar;
    ((F_TuftingExchange) this).viewportLayout.ActiveViewport.ViewCubeIcon.Visible = ViewToolbar;
    ((F_TuftingExchange) this).viewportLayout.ActiveViewport.OriginSymbol.Visible = ViewToolbar;
    ((F_TuftingExchange) this).viewportLayout.ActiveViewport.CoordinateSystemIcon.Visible = ViewToolbar;
    ((F_TuftingExchange) this).\u0001.Enabled = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    obj1.Cancel = true;
    this.Visible = false;
  }

  private void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_TuftingExchange) this).\u0001.Enabled = false;
    if (((F_TuftingExchange) this).viewportLayout == null)
      return;
    ((F_TuftingExchange) this).viewportLayout.SetView(((F_TuftingExchange) this).View, ((F_TuftingExchange) this).ZoomFit, ((F_TuftingExchange) this).ZoomAnimation);
    ((F_TuftingExchange) this).viewportLayout.Invalidate();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_TuftingExchange) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_TuftingExchange) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_TuftingSort()
  {
    ((F_TuftingExchange) this).Value = (LayerBase5) new EntityShapeInfo();
    ((F_TuftingExchange) this).Patterns = new List<drawingPattern>();
    ((F_TuftingExchange) this).Tools = new List<ToolBase5>();
    ((F_TuftingExchange) this).Result = DialogResult.None;
    ((F_TuftingExchange) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Layer) this);
  }

  public void Init(List<drawingPattern> pattern, List<ToolBase5> tool)
  {
    ((F_TuftingSetProps) this).\u0010.BackColor = ((DevideEventFormVars) ((F_TuftingExchange) this).Value).LayerColor;
    ((F_TuftingSetProps) this).\u0010.Text = buFile5.GetColorKnownName(((DevideEventFormVars) ((F_TuftingExchange) this).Value).LayerColor);
    ((F_TuftingSetProps) this).\u0010.ForeColor = buFile5.InvertColorNoGray(((DevideEventFormVars) ((F_TuftingExchange) this).Value).LayerColor);
    ((F_TuftingExchange) this).\u0001.Value = (Decimal) ((DevideEventFormVars) ((F_TuftingExchange) this).Value).LayerThickness;
    ((F_TuftingSetProps) this).\u0003.Value = (Decimal) ((DevideEventFormVars) ((F_TuftingExchange) this).Value).Transparency;
    ((F_TuftingImageList) this).\u0001.Text = ((DevideEventFormVars) ((F_TuftingExchange) this).Value).Name;
    ((F_TuftingImageList) this).\u0002.Text = ((DevideEventFormVars) ((F_TuftingExchange) this).Value).Tag;
    ((F_TuftingExchange) this).\u0001.Checked = ((ScaleEventFormVars) ((F_TuftingExchange) this).Value).Enable;
    ((F_TuftingImageList) this).\u0002.Checked = ((ScaleEventFormVars) ((F_TuftingExchange) this).Value).Lock;
    ((F_TuftingExchange) this).\u0001.Enabled = true;
    ((F_TuftingImageList) this).\u0002.Enabled = true;
    ((F_TuftingExchange) this).Patterns.Clear();
    ((F_TuftingExchange) this).Tools.Clear();
    if (pattern != null)
    {
      for (int index = 0; index <= pattern.Count - 1; ++index)
        ((F_TuftingExchange) this).Patterns.Add(new drawingPattern(pattern[index]));
    }
    for (int index = 0; index <= tool.Count - 1; ++index)
      ((F_TuftingExchange) this).Tools.Add((ToolBase5) new ToolGeometry5(tool[index]));
    ((F_TuftingExchange) this).\u0001.Items.Clear();
    if (((F_TuftingExchange) this).Patterns != null)
    {
      for (int index = 0; index <= ((F_TuftingExchange) this).Patterns.Count - 1; ++index)
        ((F_TuftingExchange) this).\u0001.Items.Add((object) ((F_TuftingExchange) this).Patterns[index].Name);
      if (((DevideEventFormVars) ((F_TuftingExchange) this).Value).Pattern != null)
      {
        ((F_TuftingExchange) this).\u0001.Text = ((DevideEventFormVars) ((F_TuftingExchange) this).Value).Pattern.Name;
        if (((F_TuftingExchange) this).\u0001.Items.Count == 0)
          ((F_TuftingExchange) this).\u0001.Enabled = false;
      }
    }
    else
      ((F_TuftingExchange) this).\u0001.Enabled = false;
    ((F_TuftingImageList) this).\u0002.Items.Clear();
    for (int index = 0; index <= ((F_TuftingExchange) this).Tools.Count - 1; ++index)
      ((F_TuftingImageList) this).\u0002.Items.Add((object) $"T{((ToolCamData5) ((ToolGeometry5) ((F_TuftingExchange) this).Tools[index]).Data).No.ToString()} - {((ToolCamData5) ((ToolGeometry5) ((F_TuftingExchange) this).Tools[index]).Data).Name}");
    if (((DeleteTypeEventFormVars) ((F_TuftingExchange) this).Value).Cam != null)
      ((F_TuftingImageList) this).\u0002.Text = $"T{((DeleteTypeEventFormVars) ((F_TuftingExchange) this).Value).Cam.CamTool.Data.No.ToString()} - {((DeleteTypeEventFormVars) ((F_TuftingExchange) this).Value).Cam.CamTool.Data.Name}";
    if (((F_TuftingImageList) this).\u0002.Items.Count == 0)
      ((F_TuftingImageList) this).\u0002.Enabled = false;
    this.LoadLanguage();
  }

  public void LoadLanguage()
  {
    string callMethod = "Layer LoadLanguage";
    try
    {
      if (F_TuftingExchange.Captions.Count <= 6)
        return;
      this.Text = F_TuftingExchange.Captions[0];
      ((F_TuftingImageList) this).\u0004.Text = F_TuftingExchange.Captions[1];
      ((F_TuftingImageList) this).\u0005.Text = F_TuftingExchange.Captions[2];
      ((F_TuftingImageList) this).\u0006.Text = F_TuftingExchange.Captions[3];
      ((F_TuftingImageList) this).\u0003.Text = F_TuftingExchange.Captions[4];
      ((F_TuftingExchange) this).\u0002.Text = F_TuftingExchange.Captions[5];
      ((F_TuftingExchange) this).\u0001.Text = F_TuftingExchange.Captions[6];
      ((F_TuftingImageList) this).\u0007.Text = F_TuftingExchange.Captions[7];
      ((F_TuftingImageList) this).\u000E.Text = F_TuftingExchange.Captions[8];
      ((F_TuftingImageList) this).\u0008.Text = F_TuftingExchange.Captions[9];
      ((F_TuftingImageList) this).btn_ok.Text = F_TuftingExchange.Captions[10];
      ((F_TuftingImageList) this).btn_cancel.Text = F_TuftingExchange.Captions[11];
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
    if (((F_TuftingExchange) this).\u0001.Value > 0M)
      ((DevideEventFormVars) ((F_TuftingExchange) this).Value).LayerThickness = (float) ((F_TuftingExchange) this).\u0001.Value;
    ((DevideEventFormVars) ((F_TuftingExchange) this).Value).Transparency = (int) ((F_TuftingSetProps) this).\u0003.Value;
    ((DevideEventFormVars) ((F_TuftingExchange) this).Value).LayerColor = ((F_TuftingSetProps) this).\u0010.BackColor;
    ((ScaleEventFormVars) ((F_TuftingExchange) this).Value).Enable = ((F_TuftingExchange) this).\u0001.Checked;
    ((ScaleEventFormVars) ((F_TuftingExchange) this).Value).Lock = ((F_TuftingImageList) this).\u0002.Checked;
    ((DevideEventFormVars) ((F_TuftingExchange) this).Value).Name = ((F_TuftingImageList) this).\u0001.Text;
    ((DevideEventFormVars) ((F_TuftingExchange) this).Value).Tag = ((F_TuftingImageList) this).\u0002.Text;
    for (int index = 0; index <= ((F_TuftingExchange) this).Patterns.Count - 1; ++index)
    {
      if (((F_TuftingExchange) this).Patterns[index].Name == ((F_TuftingExchange) this).\u0001.Text)
        ((DevideEventFormVars) ((F_TuftingExchange) this).Value).Pattern = new drawingPattern(((F_TuftingExchange) this).Patterns[index]);
    }
    ((F_TuftingExchange) this).Result = DialogResult.OK;
    this.Dispose();
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_TuftingExchange) this).Result = DialogResult.Cancel;
    this.Dispose();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ColorDialogBox.ShowDialog(((F_TuftingSetProps) this).\u0010.BackColor);
    if (ColorDialogBox.Result != DialogResult.OK)
      return;
    ((F_TuftingSetProps) this).\u0010.BackColor = ColorDialogBox.Color;
    ((F_TuftingSetProps) this).\u0010.ForeColor = buFile5.InvertColorNoGray(((F_TuftingSetProps) this).\u0010.BackColor);
    ((F_TuftingSetProps) this).\u0010.Text = buFile5.GetColorKnownName(((F_TuftingSetProps) this).\u0010.BackColor);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_TuftingExchange) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_TuftingExchange) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public event ApplyCommandWithDataEventHandler DataValueChanged;

  public event ApplyCommandWithDataEventHandler SelectedIndexChanged;
}
