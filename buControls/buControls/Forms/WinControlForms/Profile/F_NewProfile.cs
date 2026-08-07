// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Profile.F_NewProfile
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Viewer;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Profile;

public class F_NewProfile : Form
{
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public DialogResult Result = DialogResult.None;
  public ProfileNewType SelectedType = ProfileNewType.Rectangle;
  public List<eEntities> PreviewEnts = new List<eEntities>();
  public string ItemName = "";
  public string ItemLength = "";
  public double ItemWidth = 100.0;
  public double ItemHeight = 100.0;
  public double ItemThickness = 2.0;
  public double ItemRadius = 100.0;
  public double ItemDiameter = 100.0;
  private bool bool_0 = false;
  internal IContainer icontainer_0 = (IContainer) null;
  internal Button button_0;
  internal Button button_1;
  internal ImageList imageList_0;
  internal ListBox listBox_0;
  internal buViewer buViewer_0;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal Panel panel_0;
  internal Panel panel_1;
  internal NumericUpDown numericUpDown_1;
  internal Label label_1;
  internal Panel panel_2;
  internal NumericUpDown numericUpDown_2;
  internal Label label_2;
  internal Panel panel_3;
  internal NumericUpDown numericUpDown_3;
  internal Label label_3;
  internal Panel panel_4;
  internal NumericUpDown numericUpDown_4;
  internal Label label_4;
  internal Panel panel_5;
  internal NumericUpDown numericUpDown_5;
  internal Label label_5;
  internal Panel panel_6;
  internal NumericUpDown numericUpDown_6;
  internal Label label_6;
  internal Panel panel_7;
  internal NumericUpDown numericUpDown_7;
  internal Label label_7;
  internal CheckBox checkBox_0;
  internal ImageList imageList_1;
  internal CheckBox checkBox_1;
  internal Panel panel_8;
  internal Label label_8;
  internal Label label_9;
  public ComboBox cmb_length;
  public TextBox txt_name;

  public F_NewProfile() => Class39.smethod_206(this);

  public void Init()
  {
    this.bool_0 = false;
    this.cmb_length.Items.Clear();
    this.cmb_length.Items.Add((object) 100);
    this.cmb_length.Items.Add((object) 500);
    this.cmb_length.Items.Add((object) 800);
    this.cmb_length.Items.Add((object) 1000);
    this.cmb_length.Items.Add((object) 1200);
    this.cmb_length.Items.Add((object) 1500);
    this.cmb_length.Items.Add((object) 2000);
    this.cmb_length.Items.Add((object) 3000);
    this.cmb_length.Items.Add((object) 4000);
    this.cmb_length.Items.Add((object) 5000);
    this.cmb_length.Items.Add((object) 6000);
    this.listBox_0.Items.Clear();
    this.listBox_0.Items.Add((object) "Rectangle");
    this.listBox_0.Items.Add((object) "Circle");
    this.listBox_0.SelectedIndex = 0;
    this.bool_0 = true;
    this.numericUpDown_0.Value = (Decimal) this.ItemWidth;
    this.numericUpDown_1.Value = (Decimal) this.ItemHeight;
    this.numericUpDown_2.Value = (Decimal) this.ItemThickness;
    this.listBox_0.SelectedIndex = 0;
    this.UpdateByProfileType(0);
  }

  internal void method_0(object sender, EventArgs e)
  {
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.bool_0 = false;
    this.UpdateByProfileType(this.listBox_0.SelectedIndex);
    this.bool_0 = true;
  }

  public void UpdateByProfileType(int Index)
  {
    this.panel_0.Visible = false;
    this.panel_1.Visible = false;
    this.panel_2.Visible = false;
    this.panel_3.Visible = false;
    this.panel_7.Visible = false;
    this.panel_6.Visible = false;
    this.panel_5.Visible = false;
    this.panel_4.Visible = false;
    if (Index == 0)
    {
      this.panel_0.Visible = true;
      this.panel_1.Visible = true;
      this.panel_2.Visible = true;
      this.label_0.Text = "Width";
      this.label_1.Text = "Height";
      this.label_2.Text = "Thickness";
      this.numericUpDown_0.Value = (Decimal) this.ItemWidth;
      this.numericUpDown_1.Value = (Decimal) this.ItemHeight;
      this.numericUpDown_2.Value = (Decimal) this.ItemThickness;
      this.PreviewEnts.Clear();
      List<Pnt3D> Vertices1 = new List<Pnt3D>();
      buControlCoreClass.cVector.RectangleCenter(new Pnt3D(this.ItemWidth / 2.0, this.ItemHeight / 2.0), this.ItemWidth, this.ItemHeight, new WorkPlane(), ref Vertices1);
      for (int index = 1; index <= Vertices1.Count - 1; ++index)
        this.PreviewEnts.Add((eEntities) new eLine(new Pnt3D(Vertices1[index - 1]), new Pnt3D(Vertices1[index])));
      if (this.ItemThickness > 0.0)
      {
        List<Pnt3D> Vertices2 = new List<Pnt3D>();
        buControlCoreClass.cVector.RectangleCenter(new Pnt3D(this.ItemWidth / 2.0, this.ItemHeight / 2.0), this.ItemWidth - this.ItemThickness * 2.0, this.ItemHeight - this.ItemThickness * 2.0, new WorkPlane(), ref Vertices2);
        for (int index = 1; index <= Vertices2.Count - 1; ++index)
          this.PreviewEnts.Add((eEntities) new eLine(new Pnt3D(Vertices2[index - 1]), new Pnt3D(Vertices2[index])));
      }
      this.buViewer_0.Entities.Clear();
      this.buViewer_0.AddEntities(this.PreviewEnts);
      this.buViewer_0.DrawEntities();
      this.buViewer_0.ZoomFit();
      this.buViewer_0.ZoomOut();
      this.SelectedType = ProfileNewType.Rectangle;
    }
    if (Index != 1)
      return;
    this.panel_0.Visible = true;
    this.panel_1.Visible = true;
    this.label_0.Text = "Diameter";
    this.label_1.Text = "Thickness";
    this.numericUpDown_0.Value = (Decimal) this.ItemDiameter;
    this.numericUpDown_1.Value = (Decimal) this.ItemThickness;
    this.PreviewEnts.Clear();
    List<Pnt3D> Vertices3 = new List<Pnt3D>();
    buControlCoreClass.cVector.CircleWithCenter(new Pnt3D(this.ItemDiameter / 2.0, this.ItemDiameter / 2.0), this.ItemDiameter / 2.0, new WorkPlane(), new EntityResolution(), ref Vertices3);
    for (int index = 1; index <= Vertices3.Count - 1; ++index)
      this.PreviewEnts.Add((eEntities) new eLine(new Pnt3D(Vertices3[index - 1]), new Pnt3D(Vertices3[index])));
    if (this.ItemThickness > 0.0)
    {
      List<Pnt3D> Vertices4 = new List<Pnt3D>();
      buControlCoreClass.cVector.CircleWithCenter(new Pnt3D(this.ItemDiameter / 2.0, this.ItemDiameter / 2.0), this.ItemDiameter / 2.0 - this.ItemThickness, new WorkPlane(), new EntityResolution(), ref Vertices4);
      for (int index = 1; index <= Vertices4.Count - 1; ++index)
        this.PreviewEnts.Add((eEntities) new eLine(new Pnt3D(Vertices4[index - 1]), new Pnt3D(Vertices4[index])));
    }
    this.buViewer_0.Entities.Clear();
    this.buViewer_0.AddEntities(this.PreviewEnts);
    this.buViewer_0.DrawEntities();
    this.buViewer_0.ZoomFit();
    this.buViewer_0.ZoomOut();
    this.SelectedType = ProfileNewType.Rectangle;
  }

  public void UpdateData(int Index)
  {
    if (Index == 0)
    {
      this.ItemWidth = (double) this.numericUpDown_0.Value;
      this.ItemHeight = (double) this.numericUpDown_1.Value;
      this.ItemThickness = (double) this.numericUpDown_2.Value;
    }
    if (Index != 1)
      return;
    this.ItemDiameter = (double) this.numericUpDown_0.Value;
    this.ItemThickness = (double) this.numericUpDown_1.Value;
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.button_0.Name)
    {
      this.UpdateByProfileType(this.listBox_0.SelectedIndex);
      this.ItemLength = this.cmb_length.Text;
      this.ItemName = this.txt_name.Text;
      this.Result = DialogResult.OK;
      if (this.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.button_1.Name))
      return;
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_3(object sender, FormClosingEventArgs e)
  {
    if (this.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_4(object sender, EventArgs e)
  {
    if (!this.bool_0)
      return;
    this.UpdateData(this.listBox_0.SelectedIndex);
    this.UpdateByProfileType(this.listBox_0.SelectedIndex);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
