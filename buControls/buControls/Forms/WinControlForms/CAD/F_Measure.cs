// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.CAD.F_Measure
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.CAD;

public class F_Measure : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal Panel panel_0;
  internal ImageList imageList_0;
  internal PictureBox pictureBox_0;
  public TextBox txt_explanation;
  public Button btn_clear;
  public Button btn_vertex;
  public Button btn_entity;
  public Button btn_edge;
  public Button btn_face;
  public TreeView tree_item;
  public RadioButton radio_max;
  public RadioButton radio_min;
  internal PictureBox pictureBox_1;
  internal PictureBox pictureBox_2;
  public CheckBox chk_z;
  public CheckBox chk_y;
  public CheckBox chk_x;
  internal ImageList imageList_1;
  public Label lbl_selected;
  public Button btn_clearlast;
  public Button btn_points;

  public F_Measure() => Class39.smethod_378(this);

  public event OkCommandWithDataEventHandler CommandMeasure;

  public void Init()
  {
    this.Properties.Inited = false;
    this.Properties.Result = DialogResult.None;
    this.LoadLangueage();
    this.Properties.Inited = true;
  }

  public void LoadLangueage()
  {
    string callMethod = "Report LoadLanguage";
    try
    {
      if (F_Measure.Captions.Count < 8)
        return;
      this.Text = F_Measure.Captions[0];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    // ISSUE: reference to a compiler-generated field
    if (this.btn_clear.Name == control2.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) "clear");
    }
    // ISSUE: reference to a compiler-generated field
    if (this.btn_clearlast.Name == control2.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) "clearlast");
    }
    // ISSUE: reference to a compiler-generated field
    if (this.btn_face.Name == control2.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) "face");
    }
    // ISSUE: reference to a compiler-generated field
    if (this.btn_edge.Name == control2.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) "edge");
    }
    // ISSUE: reference to a compiler-generated field
    if (this.btn_entity.Name == control2.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) "entity");
    }
    // ISSUE: reference to a compiler-generated field
    if (this.btn_vertex.Name == control2.Name && this.okCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) "vertex");
    }
    // ISSUE: reference to a compiler-generated field
    if (!(this.btn_points.Name == control2.Name) || this.okCommandWithDataEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.okCommandWithDataEventHandler_0((object) "point");
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control = new Control();
    if (!this.Properties.Inited)
      return;
    if (this.radio_min.Checked)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) "min");
    }
    if (!this.radio_max.Checked)
      return;
    // ISSUE: reference to a compiler-generated field
    this.okCommandWithDataEventHandler_0((object) "max");
  }

  internal void method_3(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!this.Properties.Inited)
      return;
    if (this.chk_x.Name == control2.Name)
    {
      if (this.chk_x.Checked)
      {
        // ISSUE: reference to a compiler-generated field
        this.okCommandWithDataEventHandler_0((object) "xenable");
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        this.okCommandWithDataEventHandler_0((object) "xdisable");
      }
    }
    if (this.chk_y.Name == control2.Name)
    {
      if (this.chk_y.Checked)
      {
        // ISSUE: reference to a compiler-generated field
        this.okCommandWithDataEventHandler_0((object) "yenable");
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        this.okCommandWithDataEventHandler_0((object) "ydisable");
      }
    }
    if (!(this.chk_z.Name == control2.Name))
      return;
    if (this.chk_z.Checked)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) "zenable");
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) "zdisable");
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
