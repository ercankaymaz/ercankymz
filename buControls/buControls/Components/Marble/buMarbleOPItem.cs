// Decompiled with JetBrains decompiler
// Type: buControls.Components.Marble.buMarbleOPItem
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using buCore;
using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Components.Marble;

public class buMarbleOPItem : UserControl
{
  private Color color_0 = Color.Gray;
  private Color color_1 = Color.LightGreen;
  private Color color_2 = Color.LightCoral;
  private int int_0 = -1;
  private bool bool_0 = false;
  public bool OperationEnable = false;
  public bool OperationSelected = false;
  public string OperationName = "-";
  public int OperationIndex = -1;
  public int OperationID = -1;
  public string OperationInfo = "";
  private IContainer icontainer_0 = (IContainer) null;
  internal buButton buButton_0;
  internal buButton buButton_1;
  internal buButton buButton_2;
  internal buCheckBox buCheckBox_0;
  internal buButton buButton_3;
  internal buPanel buPanel_0;
  internal buButton buButton_4;
  internal buButton buButton_5;

  public event ItemCommandEventHandler ItemCommand;

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "Gray")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color OperationItemColor
  {
    get => this.color_0;
    set => this.color_0 = value;
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "LightGreen")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color SelectedItemColor
  {
    get => this.color_1;
    set => this.color_1 = value;
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "LightCoral")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color DisableColor
  {
    get => this.color_2;
    set => this.color_2 = value;
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (int), "-1")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int IndexControl
  {
    get => this.int_0;
    set => this.int_0 = value;
  }

  public buMarbleOPItem()
  {
    Class39.smethod_637(this);
    this.buCheckBox_0.CheckedChanged += new buControlEvents.buCheckedChangedEventHandler(this.buCheckBox_0_CheckedChanged);
    this.buButton_0.Click += new EventHandler(this.buButton_0_Click);
    this.buButton_0.DoubleClick += new EventHandler(this.buButton_0_DoubleClick);
    this.buButton_3.Click += new EventHandler(this.buButton_3_Click);
    this.buButton_1.Click += new EventHandler(this.buButton_5_Click);
    this.buButton_2.Click += new EventHandler(this.buButton_5_Click);
    this.buButton_4.Click += new EventHandler(this.buButton_5_Click);
    this.buButton_5.Click += new EventHandler(this.buButton_5_Click);
  }

  public void UpdateControl()
  {
    this.bool_0 = true;
    this.buButton_0.Text = this.OperationName;
    if (this.OperationEnable)
    {
      if (this.OperationSelected)
      {
        this.buButton_0.Display.BackColor = this.color_1;
        this.buButton_0.ButtonDownDisplay.BackColor = buImage.ColorToneChange(this.color_1, 0.9);
        this.buButton_0.ButtonOverDisplay.BackColor = buImage.ColorToneChange(this.color_1, 1.1);
        this.buCheckBox_0.Display.BackColor = this.color_1;
      }
      else
      {
        this.buButton_0.Display.BackColor = this.color_0;
        this.buButton_0.ButtonDownDisplay.BackColor = buImage.ColorToneChange(this.color_0, 0.9);
        this.buButton_0.ButtonOverDisplay.BackColor = buImage.ColorToneChange(this.color_0, 1.1);
        this.buCheckBox_0.Display.BackColor = this.color_0;
      }
    }
    else
    {
      this.buButton_0.Display.BackColor = this.color_2;
      this.buButton_0.ButtonDownDisplay.BackColor = buImage.ColorToneChange(this.color_2, 0.9);
      this.buButton_0.ButtonOverDisplay.BackColor = buImage.ColorToneChange(this.color_2, 1.1);
      this.buCheckBox_0.Display.BackColor = this.color_2;
    }
    this.buCheckBox_0.Check = this.OperationEnable;
    this.bool_0 = false;
  }

  private void buButton_0_Click(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (!(this.itemCommandEventHandler_0 != null & !this.bool_0) || this.OperationID < 1)
      return;
    this.OperationIndex = this.IndexControl;
    this.OperationSelected = !this.OperationSelected;
    this.UpdateControl();
    // ISSUE: reference to a compiler-generated field
    this.itemCommandEventHandler_0((object) this, new ItemCommandEventArgs(MarbleOperationMenuCommands.IndexChanged, this.OperationIndex, this.buCheckBox_0.Check, this.OperationID, this.IndexControl, this.OperationSelected));
  }

  private void buButton_5_Click(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (!(this.itemCommandEventHandler_0 != null & !this.bool_0))
      return;
    Control control = sender as Control;
    if (control.Name == this.buButton_1.Name)
    {
      this.buPanel_0.Visible = false;
      // ISSUE: reference to a compiler-generated field
      this.itemCommandEventHandler_0((object) this, new ItemCommandEventArgs(MarbleOperationMenuCommands.Up, this.OperationIndex, this.buCheckBox_0.Check, this.OperationID, this.IndexControl, this.OperationSelected));
    }
    if (control.Name == this.buButton_2.Name)
    {
      this.buPanel_0.Visible = false;
      // ISSUE: reference to a compiler-generated field
      this.itemCommandEventHandler_0((object) this, new ItemCommandEventArgs(MarbleOperationMenuCommands.Down, this.OperationIndex, this.buCheckBox_0.Check, this.OperationID, this.IndexControl, this.OperationSelected));
    }
    if (control.Name == this.buButton_4.Name)
    {
      this.buPanel_0.Visible = false;
      // ISSUE: reference to a compiler-generated field
      this.itemCommandEventHandler_0((object) this, new ItemCommandEventArgs(MarbleOperationMenuCommands.Edit, this.OperationIndex, this.buCheckBox_0.Check, this.OperationID, this.IndexControl, this.OperationSelected));
    }
    if (!(control.Name == this.buButton_5.Name))
      return;
    this.buPanel_0.Visible = false;
    // ISSUE: reference to a compiler-generated field
    this.itemCommandEventHandler_0((object) this, new ItemCommandEventArgs(MarbleOperationMenuCommands.Delete, this.OperationIndex, this.buCheckBox_0.Check, this.OperationID, this.IndexControl, this.OperationSelected));
  }

  private void buButton_3_Click(object sender, EventArgs e)
  {
    if (this.buPanel_0.Visible)
      this.buPanel_0.Visible = false;
    else
      this.buPanel_0.Visible = true;
  }

  private void buButton_0_DoubleClick(object sender, EventArgs e)
  {
  }

  private void buCheckBox_0_CheckedChanged(object object_0, bool bool_1)
  {
    if (this.bool_0)
      return;
    this.OperationIndex = this.IndexControl;
    this.OperationEnable = bool_1;
    this.UpdateControl();
    // ISSUE: reference to a compiler-generated field
    if (this.itemCommandEventHandler_0 == null)
      return;
    if (this.buCheckBox_0.Check)
    {
      // ISSUE: reference to a compiler-generated field
      this.itemCommandEventHandler_0((object) this, new ItemCommandEventArgs(MarbleOperationMenuCommands.Enable, this.OperationIndex, this.buCheckBox_0.Check, this.OperationID, this.IndexControl, this.OperationSelected));
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      this.itemCommandEventHandler_0((object) this, new ItemCommandEventArgs(MarbleOperationMenuCommands.Disable, this.OperationIndex, this.buCheckBox_0.Check, this.OperationID, this.IndexControl, this.OperationSelected));
    }
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
