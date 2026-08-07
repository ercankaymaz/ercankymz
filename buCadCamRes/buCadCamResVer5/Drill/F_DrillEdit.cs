// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Drill.F_DrillEdit
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using ns8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Drill;

public class F_DrillEdit : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public bool isList = false;
  public static List<string> Captions = new List<string>();
  public int RowIndex = -1;
  public int ColIndex = -1;
  private Timer timer_0 = new Timer();
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Panel pnl_viewport;
  internal Button button_0;
  internal Button button_1;
  internal Button button_2;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  internal Button button_6;
  internal Button button_7;
  public Label lbl_z;
  public Label lbl_y;
  public Label lbl_x;
  public TreeView tree_jobs;
  internal ImageList imageList_1;
  internal Button button_8;
  internal Button button_9;
  internal Button button_10;
  internal Button button_11;
  internal Panel panel_0;
  internal ImageList imageList_2;
  public DataGridView dgv_data;
  public Button btn_planeback;
  public Button btn_planeleft;
  public Button btn_planebottom;
  public Button btn_planefront;
  public Button btn_planetop;
  public Button btn_planeright;
  internal Label label_0;
  internal CheckBox checkBox_0;
  internal Button button_12;

  public F_DrillEdit()
  {
    Class5.smethod_28(this);
    this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
  }

  public event ValueChangedWithDataEventHandler ValueChanged;

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    this.PropertiesForm.Inited = true;
  }

  private void timer_0_Tick(object sender, EventArgs e)
  {
    this.timer_0.Enabled = false;
    this.PropertiesForm.Inited = true;
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
  }

  public object[] AddNewSheetRow(string Parameter, object Value, int baseIndex, int itemIndex)
  {
    return new object[4]
    {
      (object) Parameter,
      Value,
      (object) baseIndex,
      (object) itemIndex
    };
  }

  internal void method_2(object sender, EventArgs e)
  {
  }

  internal void method_3(object sender, TreeViewEventArgs e)
  {
  }

  public void PlaneColor(planeBoxNames Plane)
  {
  }

  internal void method_4(object sender, EventArgs e)
  {
  }

  internal void method_5(object sender, DataGridViewCellEventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
