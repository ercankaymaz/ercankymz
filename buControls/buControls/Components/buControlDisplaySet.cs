// Decompiled with JetBrains decompiler
// Type: buControls.Components.buControlDisplaySet
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buControls.Controls;
using buControls.DialogBox;
using buCore;
using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buControls.Components;

[DefaultProperty("Display")]
[DefaultEvent("Click")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
[ToolboxBitmap(typeof (Label))]
[DefaultBindingProperty("Display")]
public class buControlDisplaySet : UserControl
{
  private bool bool_0 = false;
  private buControlDisplay buControlDisplay_0 = (buControlDisplay) null;
  private string string_0 = "";
  private IContainer icontainer_0 = (IContainer) null;
  internal buComboBox buComboBox_0;
  public buSpin spn_thickness;
  internal buLabel buLabel_0;
  internal Panel panel_0;
  public buButton btn_defvals;
  internal buLabel buLabel_1;
  public buButton btn_savefiles;
  public buButton btn_openfiles;
  internal buCheckBox buCheckBox_0;
  internal buLabel buLabel_2;
  internal buLabel buLabel_3;
  internal buLabel buLabel_4;
  public buButton btn_font;
  internal buLabel buLabel_5;
  internal buComboBox buComboBox_1;
  internal TabPage tabPage_0;
  internal buLabel buLabel_6;
  internal buLabel buLabel_7;
  internal buLabel buLabel_8;
  internal buLabel buLabel_9;
  internal buLabel buLabel_10;
  internal buLabel buLabel_11;
  internal buLabel buLabel_12;
  internal buLabel buLabel_13;
  internal TabPage tabPage_1;
  internal buLabel buLabel_14;
  internal buLabel buLabel_15;
  internal buLabel buLabel_16;
  internal buLabel buLabel_17;
  internal TabPage tabPage_2;
  public buSpin spn_lineardegree;
  internal buLabel buLabel_18;
  internal buLabel buLabel_19;
  internal buLabel buLabel_20;
  internal buLabel buLabel_21;
  internal TabPage tabPage_3;
  internal buLabel buLabel_22;
  internal buLabel buLabel_23;
  internal buTab buTab_0;
  internal buLabel buLabel_24;
  internal buLabel buLabel_25;

  public event EventHandler Changed;

  public buControlDisplaySet()
  {
    this.buControlDisplay_0 = new buControlDisplay();
    this.Display.Parent = (Control) this;
    Class39.smethod_845(this);
    this.buComboBox_1.Items.Clear();
    this.buComboBox_1.Items.AddRange(Enum.GetValues(typeof (ContentAlignment)).Cast<object>().ToArray<object>());
    this.buControlDisplay_0.Changed += new EventHandler(this.DisplayChanged);
    this.UpdateControl();
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue("")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string Caption
  {
    get => this.string_0;
    set
    {
      this.string_0 = value;
      this.buLabel_0.Text = this.string_0;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay Display
  {
    get => this.buControlDisplay_0;
    set
    {
      this.buControlDisplay_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  public void UpdateControl()
  {
    this.bool_0 = true;
    this.buLabel_23.Display.BackColor = this.Display.BackColor;
    this.buLabel_23.Text = buImage.GetColorKnownName(this.buLabel_23.Display.BackColor);
    if (this.Display.BackColor == Color.Black)
      this.buLabel_23.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      this.buLabel_23.Display.Fonts.ForeColor = Color.Black;
    this.buLabel_21.Display.BackColor = this.Display.LineerGradient.FirstColor;
    this.buLabel_21.Text = buImage.GetColorKnownName(this.buLabel_21.Display.BackColor);
    if (this.Display.LineerGradient.FirstColor == Color.Black)
      this.buLabel_21.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      this.buLabel_21.Display.Fonts.ForeColor = Color.Black;
    this.buLabel_19.Display.BackColor = this.Display.LineerGradient.SecondColor;
    this.buLabel_19.Text = buImage.GetColorKnownName(this.buLabel_19.Display.BackColor);
    if (this.Display.LineerGradient.SecondColor == Color.Black)
      this.buLabel_19.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      this.buLabel_19.Display.Fonts.ForeColor = Color.Black;
    this.buLabel_17.Display.BackColor = this.Display.PathGradient.CenterColor;
    this.buLabel_17.Text = buImage.GetColorKnownName(this.buLabel_16.Display.BackColor);
    if (this.Display.PathGradient.CenterColor == Color.Black)
      this.buLabel_17.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      this.buLabel_17.Display.Fonts.ForeColor = Color.Black;
    this.buLabel_15.Display.BackColor = this.Display.PathGradient.SurroundColor;
    this.buLabel_15.Text = buImage.GetColorKnownName(this.buLabel_15.Display.BackColor);
    if (this.Display.PathGradient.SurroundColor == Color.Black)
      this.buLabel_15.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      this.buLabel_15.Display.Fonts.ForeColor = Color.Black;
    this.buLabel_13.Display.BackColor = this.Display.PathInterpolatedGradient.FirstColor;
    this.buLabel_13.Text = buImage.GetColorKnownName(this.buLabel_13.Display.BackColor);
    if (this.Display.PathInterpolatedGradient.FirstColor == Color.Black)
      this.buLabel_13.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      this.buLabel_13.Display.Fonts.ForeColor = Color.Black;
    this.buLabel_11.Display.BackColor = this.Display.PathInterpolatedGradient.SecondColor;
    this.buLabel_11.Text = buImage.GetColorKnownName(this.buLabel_11.Display.BackColor);
    if (this.Display.PathInterpolatedGradient.SecondColor == Color.Black)
      this.buLabel_11.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      this.buLabel_11.Display.Fonts.ForeColor = Color.Black;
    this.buLabel_9.Display.BackColor = this.Display.PathInterpolatedGradient.ThirdColor;
    this.buLabel_9.Text = buImage.GetColorKnownName(this.buLabel_9.Display.BackColor);
    if (this.Display.PathInterpolatedGradient.ThirdColor == Color.Black)
      this.buLabel_9.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      this.buLabel_9.Display.Fonts.ForeColor = Color.Black;
    this.buLabel_7.Display.BackColor = this.Display.PathInterpolatedGradient.FourthColor;
    this.buLabel_7.Text = buImage.GetColorKnownName(this.buLabel_7.Display.BackColor);
    if (this.Display.PathInterpolatedGradient.FourthColor == Color.Black)
      this.buLabel_7.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      this.buLabel_7.Display.Fonts.ForeColor = Color.Black;
    this.buLabel_3.Display.BackColor = this.Display.SelectionColor;
    this.buLabel_3.Text = buImage.GetColorKnownName(this.buLabel_3.Display.BackColor);
    if (this.Display.SelectionColor == Color.Black)
      this.buLabel_3.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      this.buLabel_3.Display.Fonts.ForeColor = Color.Black;
    this.buLabel_25.Display.BackColor = this.Display.TitleForeColor;
    this.buLabel_25.Text = buImage.GetColorKnownName(this.buLabel_25.Display.BackColor);
    if (this.Display.TitleForeColor == Color.Black)
      this.buLabel_25.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      this.buLabel_25.Display.Fonts.ForeColor = Color.Black;
    this.buCheckBox_0.Check = this.Display.Border.Visible;
    this.spn_thickness.Value = (double) this.Display.Border.Thickness;
    this.buLabel_2.Display.BackColor = this.Display.Border.Color;
    this.buLabel_2.Text = buImage.GetColorKnownName(this.buLabel_2.Display.BackColor);
    if (this.Display.Border.Color == Color.Black)
      this.buLabel_2.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      this.buLabel_2.Display.Fonts.ForeColor = Color.Black;
    this.spn_lineardegree.Value = (double) this.buControlDisplay_0.LineerGradient.GradientAngle;
    if (this.Display.GradientType == GradientMode.Solid)
    {
      this.buComboBox_0.SelectedIndex = 0;
      this.buTab_0.SelectedIndex = 0;
    }
    else if (this.Display.GradientType == GradientMode.Lineer)
    {
      this.buComboBox_0.SelectedIndex = 1;
      this.buTab_0.SelectedIndex = 1;
    }
    else if (this.Display.GradientType == GradientMode.Path)
    {
      this.buComboBox_0.SelectedIndex = 2;
      this.buTab_0.SelectedIndex = 2;
    }
    else
    {
      this.buComboBox_0.SelectedIndex = 3;
      this.buTab_0.SelectedIndex = 3;
    }
    this.btn_font.Text = $"{this.Display.Fonts.Font.Name} - {this.Display.Fonts.Font.Size.ToString()}";
    this.btn_font.Display.BackColor = this.Display.Fonts.ForeColor;
    this.btn_font.ButtonDownDisplay.BackColor = this.Display.Fonts.ForeColor;
    this.btn_font.ButtonOverDisplay.BackColor = this.Display.Fonts.ForeColor;
    if (this.Display.Fonts.ForeColor == Color.Black)
    {
      this.btn_font.Display.Fonts.ForeColor = Color.WhiteSmoke;
      this.btn_font.ButtonDownDisplay.Fonts.ForeColor = Color.WhiteSmoke;
      this.btn_font.ButtonOverDisplay.Fonts.ForeColor = Color.WhiteSmoke;
    }
    else
    {
      this.btn_font.Display.Fonts.ForeColor = Color.Black;
      this.btn_font.ButtonDownDisplay.Fonts.ForeColor = Color.Black;
      this.btn_font.ButtonOverDisplay.Fonts.ForeColor = Color.Black;
    }
    this.buLabel_5.Display.BackColor = this.Display.Fonts.ForeColor;
    this.buLabel_5.Text = buImage.GetColorKnownName(this.buLabel_5.Display.BackColor);
    if (this.Display.Fonts.ForeColor == Color.Black)
      this.buLabel_5.Display.Fonts.ForeColor = Color.WhiteSmoke;
    else
      this.buLabel_5.Display.Fonts.ForeColor = Color.Black;
    this.buComboBox_1.SelectedItem = (object) this.Display.Fonts.Alignment;
    this.buLabel_0.Display.BackColor = this.Display.BackColor;
    this.buLabel_0.Display.SelectionColor = this.Display.SelectionColor;
    this.buLabel_0.Display.TitleForeColor = this.Display.TitleForeColor;
    this.buLabel_0.Display.GradientType = this.Display.GradientType;
    this.buLabel_0.Display.LineerGradient.FirstColor = this.Display.LineerGradient.FirstColor;
    this.buLabel_0.Display.LineerGradient.SecondColor = this.Display.LineerGradient.SecondColor;
    this.buLabel_0.Display.LineerGradient.GradientAngle = this.Display.LineerGradient.GradientAngle;
    this.buLabel_0.Display.PathGradient.CenterColor = this.Display.PathGradient.CenterColor;
    this.buLabel_0.Display.PathGradient.SurroundColor = this.Display.PathGradient.SurroundColor;
    this.buLabel_0.Display.PathInterpolatedGradient.FirstColor = this.Display.PathInterpolatedGradient.FirstColor;
    this.buLabel_0.Display.PathInterpolatedGradient.SecondColor = this.Display.PathInterpolatedGradient.SecondColor;
    this.buLabel_0.Display.PathInterpolatedGradient.ThirdColor = this.Display.PathInterpolatedGradient.ThirdColor;
    this.buLabel_0.Display.PathInterpolatedGradient.FourthColor = this.Display.PathInterpolatedGradient.FourthColor;
    this.buLabel_0.Display.Border.Visible = this.Display.Border.Visible;
    this.buLabel_0.Display.Border.Thickness = this.Display.Border.Thickness;
    this.buLabel_0.Display.Border.Color = this.Display.Border.Color;
    this.buLabel_0.Display.Fonts.ForeColor = this.Display.Fonts.ForeColor;
    this.buLabel_0.Display.Fonts.Alignment = this.Display.Fonts.Alignment;
    this.buLabel_0.Display.Fonts.Font = this.Display.Fonts.Font;
    this.bool_0 = false;
  }

  protected void DisplayChanged(object sender, EventArgs e)
  {
  }

  internal void method_0(object sender, EventArgs e)
  {
  }

  internal void method_1(object sender, EventArgs e)
  {
    if (this.bool_0)
      return;
    Control control = sender as Control;
    if (control.Name == this.buComboBox_0.Name)
    {
      if (this.buComboBox_0.SelectedIndex == 0)
      {
        this.buTab_0.SelectedIndex = 0;
        this.Display.GradientType = GradientMode.Solid;
      }
      else if (this.buComboBox_0.SelectedIndex == 1)
      {
        this.buTab_0.SelectedIndex = 1;
        this.Display.GradientType = GradientMode.Lineer;
      }
      else if (this.buComboBox_0.SelectedIndex == 2)
      {
        this.buTab_0.SelectedIndex = 2;
        this.Display.GradientType = GradientMode.Path;
      }
      else
      {
        this.buTab_0.SelectedIndex = 3;
        this.Display.GradientType = GradientMode.InterpolatedPath;
      }
      this.UpdateControl();
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_0((object) this, new EventArgs());
      }
    }
    if (!(control.Name == this.buComboBox_1.Name))
      return;
    ContentAlignment result;
    Enum.TryParse<ContentAlignment>(this.buComboBox_1.SelectedItem.ToString(), out result);
    this.Display.Fonts.Alignment = result;
    this.UpdateControl();
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) this, new EventArgs());
  }

  internal void method_2(object sender, EventArgs e)
  {
    buLabel buLabel = sender as buLabel;
    if (buLabel.Name == this.buLabel_23.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        this.Display.BackColor = backColor;
        this.UpdateControl();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.eventHandler_0((object) this, new EventArgs());
        }
      }
    }
    if (buLabel.Name == this.buLabel_21.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        this.Display.LineerGradient.FirstColor = backColor;
        this.UpdateControl();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.eventHandler_0((object) this, new EventArgs());
        }
      }
    }
    if (buLabel.Name == this.buLabel_19.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        this.Display.LineerGradient.SecondColor = backColor;
        this.UpdateControl();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.eventHandler_0((object) this, new EventArgs());
        }
      }
    }
    if (buLabel.Name == this.buLabel_17.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        this.Display.PathGradient.CenterColor = backColor;
        this.UpdateControl();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.eventHandler_0((object) this, new EventArgs());
        }
      }
    }
    if (buLabel.Name == this.buLabel_15.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        this.Display.PathGradient.SurroundColor = backColor;
        this.UpdateControl();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.eventHandler_0((object) this, new EventArgs());
        }
      }
    }
    if (buLabel.Name == this.buLabel_13.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        this.Display.PathInterpolatedGradient.FirstColor = backColor;
        this.UpdateControl();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.eventHandler_0((object) this, new EventArgs());
        }
      }
    }
    if (buLabel.Name == this.buLabel_11.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        this.Display.PathInterpolatedGradient.SecondColor = backColor;
        this.UpdateControl();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.eventHandler_0((object) this, new EventArgs());
        }
      }
    }
    if (buLabel.Name == this.buLabel_9.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        this.Display.PathInterpolatedGradient.ThirdColor = backColor;
        this.UpdateControl();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.eventHandler_0((object) this, new EventArgs());
        }
      }
    }
    if (buLabel.Name == this.buLabel_7.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        this.Display.PathInterpolatedGradient.FourthColor = backColor;
        this.UpdateControl();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.eventHandler_0((object) this, new EventArgs());
        }
      }
    }
    if (buLabel.Name == this.buLabel_3.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        this.Display.SelectionColor = backColor;
        this.UpdateControl();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.eventHandler_0((object) this, new EventArgs());
        }
      }
    }
    if (buLabel.Name == this.buLabel_25.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        this.Display.TitleForeColor = backColor;
        this.UpdateControl();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.eventHandler_0((object) this, new EventArgs());
        }
      }
    }
    if (buLabel.Name == this.buLabel_2.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        this.Display.Border.Color = backColor;
        this.UpdateControl();
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.eventHandler_0((object) this, new EventArgs());
        }
      }
    }
    if (!(buLabel.Name == this.buLabel_5.Name))
      return;
    Color backColor1 = buLabel.Display.BackColor;
    if (ColorDialogBox.ShowDialog(ref backColor1) != DialogResult.OK)
      return;
    buLabel.Display.BackColor = backColor1;
    buLabel.Text = buImage.GetColorKnownName(backColor1);
    this.Display.Fonts.ForeColor = backColor1;
    this.UpdateControl();
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) this, new EventArgs());
  }

  internal void method_3(object object_0, bool bool_1)
  {
    if (this.bool_0)
      return;
    this.Display.Border.Visible = this.buCheckBox_0.Check;
    this.UpdateControl();
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) this, new EventArgs());
  }

  internal void method_4(object object_0, double double_0)
  {
    Control control = object_0 as Control;
    if (this.bool_0)
      return;
    if (control.Name == this.spn_thickness.Name)
    {
      this.Display.Border.Thickness = (float) this.spn_thickness.Value;
      this.UpdateControl();
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.eventHandler_0((object) this, new EventArgs());
      }
    }
    if (!(control.Name == this.spn_lineardegree.Name))
      return;
    this.Display.LineerGradient.GradientAngle = (float) this.spn_lineardegree.Value;
    this.UpdateControl();
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) this, new EventArgs());
  }

  internal void method_5(object sender, EventArgs e)
  {
    FontDialog fontDialog = new FontDialog();
    fontDialog.Font = this.Display.Fonts.Font;
    int num = (int) fontDialog.ShowDialog();
    this.Display.Fonts.Font = fontDialog.Font;
    this.UpdateControl();
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_0((object) this, new EventArgs());
  }

  internal void method_6(object sender, EventArgs e)
  {
    Control control = sender as Control;
    if (control.Name == this.buLabel_1.Name)
      this.panel_0.Visible = false;
    if (control.Name == this.btn_defvals.Name)
    {
      if (MessageBox.Show("Do You Want to Call Deafult Values", "Default", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        this.Display = new buControlDisplay();
        this.UpdateControl();
      }
      this.panel_0.Visible = false;
    }
    if (control.Name == this.btn_openfiles.Name)
      this.panel_0.Visible = false;
    if (!(control.Name == this.btn_savefiles.Name))
      return;
    this.panel_0.Visible = false;
  }

  internal void method_7(object sender, EventArgs e)
  {
    if (!this.panel_0.Visible)
    {
      this.panel_0.Height = 155;
      this.panel_0.Visible = true;
    }
    else
      this.panel_0.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
