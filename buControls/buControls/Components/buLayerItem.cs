// Decompiled with JetBrains decompiler
// Type: buControls.Components.buLayerItem
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buControls.Controls;
using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Components;

public class buLayerItem : UserControl
{
  private Color color_0;
  private Color color_1;
  private bool bool_0 = false;
  public int LayerIndex = -1;
  public string LayerName = "Default";
  public Color LayerColor = Color.Blue;
  public bool LayerVisible = true;
  public bool LayerLock = false;
  private IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal CheckBox checkBox_0;
  internal Label label_1;
  internal CheckBox checkBox_1;

  public event buControlEvents.buLayerChangedEventHandler LayerChanged;

  public event buControlEvents.buLayerDoubleClickEventHandler LayerDoubleClick;

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "Gray")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color LayerNameItemColor
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      this.label_0.BackColor = this.color_0;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "White")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color LayerColorItemColor
  {
    get => this.color_1;
    set
    {
      this.color_1 = value;
      this.label_1.BackColor = this.color_1;
    }
  }

  public buLayerItem()
  {
    Class39.smethod_91(this);
    this.Height = 25;
    this.checkBox_0.CheckedChanged += new EventHandler(this.checkBox_0_CheckedChanged);
    this.checkBox_1.CheckedChanged += new EventHandler(this.checkBox_1_CheckedChanged);
    this.label_0.Click += new EventHandler(this.label_0_Click);
    this.label_0.DoubleClick += new EventHandler(this.label_0_DoubleClick);
  }

  public void UpdateControl()
  {
    this.bool_0 = true;
    this.label_0.Text = this.LayerName;
    this.label_1.BackColor = this.LayerColor;
    this.checkBox_0.Checked = this.LayerVisible;
    this.checkBox_1.Checked = this.LayerLock;
    this.bool_0 = false;
  }

  private void label_0_Click(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (!(this.buLayerChangedEventHandler_0 != null & !this.bool_0))
      return;
    this.LayerVisible = this.checkBox_0.Checked;
    this.LayerLock = this.checkBox_1.Checked;
    this.LayerName = this.label_0.Text;
    this.LayerColor = this.label_1.BackColor;
    // ISSUE: reference to a compiler-generated field
    this.buLayerChangedEventHandler_0((object) this, this.LayerColor, this.LayerVisible, this.LayerLock, this.LayerName, this.LayerIndex);
  }

  private void label_0_DoubleClick(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (!(this.buLayerDoubleClickEventHandler_0 != null & !this.bool_0))
      return;
    this.LayerVisible = this.checkBox_0.Checked;
    this.LayerLock = this.checkBox_1.Checked;
    this.LayerName = this.label_0.Text;
    this.LayerColor = this.label_1.BackColor;
    // ISSUE: reference to a compiler-generated field
    this.buLayerDoubleClickEventHandler_0((object) this, this.LayerColor, this.LayerVisible, this.LayerLock, this.LayerName, this.LayerIndex);
  }

  private void checkBox_0_CheckedChanged(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (!(this.buLayerChangedEventHandler_0 != null & !this.bool_0))
      return;
    this.LayerVisible = this.checkBox_0.Checked;
    this.LayerLock = this.checkBox_1.Checked;
    this.LayerName = this.label_0.Text;
    this.LayerColor = this.label_1.BackColor;
    // ISSUE: reference to a compiler-generated field
    this.buLayerChangedEventHandler_0((object) this, this.LayerColor, this.LayerVisible, this.LayerLock, this.LayerName, this.LayerIndex);
  }

  private void checkBox_1_CheckedChanged(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (!(this.buLayerChangedEventHandler_0 != null & !this.bool_0))
      return;
    this.LayerVisible = this.checkBox_0.Checked;
    this.LayerLock = this.checkBox_1.Checked;
    this.LayerName = this.label_0.Text;
    this.LayerColor = this.label_1.BackColor;
    // ISSUE: reference to a compiler-generated field
    this.buLayerChangedEventHandler_0((object) this, this.LayerColor, this.LayerVisible, this.LayerLock, this.LayerName, this.LayerIndex);
  }

  internal void method_0(object sender, EventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
